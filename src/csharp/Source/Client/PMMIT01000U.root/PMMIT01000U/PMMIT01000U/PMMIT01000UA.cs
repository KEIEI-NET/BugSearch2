using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Collections.Generic;

using Infragistics.Win.UltraWinTabbedMdi;
using Infragistics.Win.UltraWinToolbars;

using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{

	/// <summary>
	/// 検索見積フレームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 検索見積のフレームクラスです。</br>
	/// <br>Programmer : 21024 佐々木　健</br>
	/// <br>Date       : 2008.06.18</br>
    /// <br>Update Note:</br>
    /// <br>2009.03.26 20056 對馬 大輔 №12625 最新情報ボタン追加</br>
    /// </remarks>
	public class PMMIT01000UA : System.Windows.Forms.Form
	{
		# region Private Members (Components)
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU00160UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU00160UA_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU00160UA_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU00160UA_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl Main_UTabControl;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		private TMemPos tMemPos1;
		private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private TArrowKeyControl tArrowKeyControl;
        private TRetKeyControl tRetKeyControl;
        private Infragistics.Win.Misc.UltraButton uButton_Close;
		private System.ComponentModel.IContainer components;
		#endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
        /// 検索見積フレームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : コンストラクタ内処理の概要を記述</br>
		/// <br>Programmer : 21024　佐々木　健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		public PMMIT01000UA()
		{
			InitializeComponent();		

			this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_CLOSE_KEY];
			this._returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_RETURN_KEY];
			this._forwardButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_FORWARD_KEY];
			this._printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_PRINT_KEY];
			this._newtButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_NEW_KEY];
			this._deleteSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_DELETESLIP_KEY];
			this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_UNDO_KEY];
			this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_GUIDE_KEY];
			this._readSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_READSLIP_KEY];
			this._slipCopyButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_SLIPCOPY_KEY];
			this._changePartsSearchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_CHANGEPARTSSEARCH_KEY];
			this._entryJoinPartsButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_ENTRYJOINPARTS_KEY];
			this._orderSelectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_ORDERSELECT_KEY];
			this._showSetButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_SHOWSET_KEY];
			this._settingButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_SETTING_KEY];
			this._changeDisplayButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_CHANGEDISPLAY_KEY];
            this._reNewalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_BUTTONTOOL_RENEWAL_KEY];

			this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_LABELTOOL_LOGINTITLE_KEY];
			this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_LABELTOOL_LOGINNAME_KEY];
			this._loginSectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_LABELTOOL_LOGINSECTIONTITLE_KEY];
			this._loginSectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.Main_ToolbarsManager.Tools[ctTOOLBAR_LABELTOOL_LOGINSECTIONNAME_KEY];

            this._secInfoAcs = new SecInfoAcs((int)SecInfoAcs.SearchMode.Remote);

            this.CacheOptionInfo();

            //モード別処理
            MovingModeSetting();
		}
		#endregion

		// ===================================================================================== //
		// 破棄
		// ===================================================================================== //
		#region Dispose
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
		#endregion

		// ===================================================================================== //
		// Windowsフォームデザイナで生成されたコード
		// ===================================================================================== //
		#region Windows フォーム デザイナで生成されたコード
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_File");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Edit");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Tool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_Dummy");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginSectionTitle");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginSectionName");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginTitle");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginName");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Close");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_New");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Print");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ReadSlip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_DeleteSlip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Return");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Forward");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Undo");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ChangePartsSearch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Guide");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ChangeDisplay");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_SlipCopy");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_EntryJoinParts");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_OrderSelect");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ShowSet");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Setting");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ReNewal");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_File");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_NewTab");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_CloseTab");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_New");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Print");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ReadSlip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_DeleteSlip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Close");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Tool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Setting");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Window");
            Infragistics.Win.UltraWinToolbars.ListTool listTool1 = new Infragistics.Win.UltraWinToolbars.ListTool("ListTool_TabForm");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_Dummy");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginTitle");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginName");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.MdiWindowListTool mdiWindowListTool1 = new Infragistics.Win.UltraWinToolbars.MdiWindowListTool("MDIWindowListTool_InputForm");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Print");
            Infragistics.Win.UltraWinToolbars.ListTool listTool2 = new Infragistics.Win.UltraWinToolbars.ListTool("ListTool_TabForm");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginSectionTitle");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Forward");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool28 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Return");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool29 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ChangePartsSearch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool30 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Guide");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool31 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ReadSlip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool32 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_SlipCopy");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool33 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_New");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool34 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Save");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool35 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Setting");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool36 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Undo");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool37 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Close");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool38 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_DeleteSlip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool39 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_OrderSelect");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool40 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_EntryJoinParts");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool41 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ShowSet");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool42 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_NewTab");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool43 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_CloseTab");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool44 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_CloseOtherTab_Mouse");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Edit");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool45 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Undo");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool46 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Guide");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool8 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Show");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool47 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Return");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool48 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Forward");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool9 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Mouse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool49 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_CloseTab_Mouse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool50 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_CloseOtherTab_Mouse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool51 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_NewTab_Mouse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool52 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_NewTab_Mouse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool53 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_CloseTab_Mouse");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool10 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginSectionName");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool54 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_CloseTab_Hidden");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool55 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ChangeDisplay");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool56 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_EstimateReference");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool57 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_ReNewal");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMMIT01000UA));
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Main_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.uButton_Close = new Infragistics.Win.Misc.UltraButton();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tArrowKeyControl = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this._MAKAU00160UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._MAKAU00160UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU00160UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).BeginInit();
            this.Main_UTabControl.SuspendLayout();
            this.ultraTabSharedControlsPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.ultraButton1);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(1014, 622);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(389, 198);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 0;
            this.ultraButton1.Text = "ultraButton1";
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 711);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            appearance3.TextHAlignAsString = "Center";
            this.ultraStatusBar1.PanelAppearance = appearance3;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "Text";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel2.Key = "Date";
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel2.Width = 90;
            ultraStatusPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel3.Key = "Time";
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel3.Width = 50;
            this.ultraStatusBar1.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3});
            this.ultraStatusBar1.Size = new System.Drawing.Size(1016, 23);
            this.ultraStatusBar1.TabIndex = 21;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            this.ultraStatusBar1.WrapText = false;
            // 
            // Main_UTabControl
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Main_UTabControl.Appearance = appearance2;
            this.Main_UTabControl.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.Main_UTabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.Main_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.Main_UTabControl.Location = new System.Drawing.Point(0, 125);
            this.Main_UTabControl.Name = "Main_UTabControl";
            this.Main_UTabControl.SharedControls.AddRange(new System.Windows.Forms.Control[] {
            this.uButton_Close});
            this.Main_UTabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.Main_UTabControl.Size = new System.Drawing.Size(1016, 586);
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.TabIndex = 23;
            this.Main_UTabControl.TabPadding = new System.Drawing.Size(3, 3);
            this.Main_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Main_UTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.Main_UTabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Main_UTabControl_MouseClick);
            this.Main_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.Main_UTabControl_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Controls.Add(this.uButton_Close);
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(1014, 565);
            // 
            // uButton_Close
            // 
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            appearance59.TextHAlignAsString = "Center";
            this.uButton_Close.Appearance = appearance59;
            this.uButton_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_Close.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Close.Location = new System.Drawing.Point(197, -78);
            this.uButton_Close.Name = "uButton_Close";
            this.uButton_Close.Size = new System.Drawing.Size(90, 25);
            this.uButton_Close.TabIndex = 34;
            this.uButton_Close.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Close.Click += new System.EventHandler(this.uButton_Close_Click);
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tArrowKeyControl
            // 
            this.tArrowKeyControl.OwnerForm = this;
            // 
            // tRetKeyControl
            // 
            this.tRetKeyControl.OwnerForm = this;
            this.tRetKeyControl.TabEnable = false;
            // 
            // _MAKAU00160UA_Toolbars_Dock_Area_Left
            // 
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 125);
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.Name = "_MAKAU00160UA_Toolbars_Dock_Area_Left";
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 586);
            this._MAKAU00160UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Main_ToolbarsManager
            // 
            this.Main_ToolbarsManager.DesignerFlags = 1;
            this.Main_ToolbarsManager.DockWithinContainer = this;
            this.Main_ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.Main_ToolbarsManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.Main_ToolbarsManager.ShowFullMenusDelay = 500;
            this.Main_ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            labelTool1.InstanceProps.Width = 25;
            labelTool3.InstanceProps.Width = 121;
            labelTool4.InstanceProps.Width = 103;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            popupMenuTool3,
            labelTool1,
            labelTool2,
            labelTool3,
            labelTool4,
            labelTool5});
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            buttonTool6.InstanceProps.IsFirstInGroup = true;
            buttonTool8.InstanceProps.IsFirstInGroup = true;
            buttonTool12.InstanceProps.IsFirstInGroup = true;
            buttonTool13.InstanceProps.IsFirstInGroup = true;
            buttonTool16.InstanceProps.IsFirstInGroup = true;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8,
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            buttonTool14,
            buttonTool15,
            buttonTool16,
            buttonTool17});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "標準";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            popupMenuTool4.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool4.SharedProps.MergeOrder = 10;
            buttonTool18.InstanceProps.IsFirstInGroup = true;
            buttonTool20.InstanceProps.IsFirstInGroup = true;
            buttonTool24.InstanceProps.IsFirstInGroup = true;
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool18,
            buttonTool19,
            buttonTool20,
            buttonTool21,
            buttonTool22,
            buttonTool23,
            buttonTool24});
            popupMenuTool5.SharedProps.Caption = "ツール(&T)";
            popupMenuTool5.SharedProps.MergeOrder = 20;
            popupMenuTool5.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool25});
            popupMenuTool6.SharedProps.Caption = "ウィンドウ(&W)";
            popupMenuTool6.SharedProps.MergeOrder = 30;
            popupMenuTool6.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            listTool1});
            labelTool6.SharedProps.MergeOrder = 40;
            labelTool6.SharedProps.Spring = true;
            labelTool7.SharedProps.Caption = "ログイン担当者";
            labelTool7.SharedProps.CustomizerCaption = "ログイン担当者タイトル";
            labelTool7.SharedProps.MergeOrder = 50;
            labelTool7.SharedProps.ShowInCustomizer = false;
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.TextHAlignAsString = "Left";
            labelTool8.SharedProps.AppearancesSmall.Appearance = appearance4;
            labelTool8.SharedProps.CustomizerCaption = "ログイン担当者ラベル";
            labelTool8.SharedProps.CustomizerDescription = "ログイン担当者ラベル";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool8.SharedProps.MergeOrder = 60;
            labelTool8.SharedProps.ShowInCustomizer = false;
            labelTool8.SharedProps.Width = 150;
            mdiWindowListTool1.DisplayArrangeIconsCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayCascadeCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayCloseWindowsCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayMinimizeCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayTileHorizontalCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayTileVerticalCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.SharedProps.Caption = "MDIWindowListTool_InputForm";
            buttonTool26.SharedProps.Caption = "印刷(F10)";
            buttonTool26.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool26.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            listTool2.SharedProps.Caption = "ListTool_TabForm";
            listTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool9.SharedProps.Caption = "ログイン拠点";
            labelTool9.SharedProps.CustomizerCaption = "ログイン拠点タイトル";
            labelTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool27.SharedProps.Caption = "進む(F3)";
            buttonTool27.SharedProps.CustomizerCaption = "進むボタン";
            buttonTool27.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool27.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F3;
            buttonTool28.SharedProps.Caption = "戻る(F2)";
            buttonTool28.SharedProps.CustomizerCaption = "戻るボタン";
            buttonTool28.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool28.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F2;
            buttonTool29.SharedProps.Caption = "検索切替(F4)";
            buttonTool29.SharedProps.CustomizerCaption = "検索切替ボタン";
            buttonTool29.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool29.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F4;
            buttonTool30.SharedProps.Caption = "ガイド(F5)";
            buttonTool30.SharedProps.CustomizerCaption = "ガイドボタン";
            buttonTool30.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool30.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F5;
            buttonTool31.SharedProps.Caption = "伝票呼出（F11)";
            buttonTool31.SharedProps.CustomizerCaption = "伝票呼出ボタン";
            buttonTool31.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool31.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F11;
            buttonTool32.SharedProps.Caption = "伝票複写(&P)";
            buttonTool32.SharedProps.CustomizerCaption = "伝票複写ボタン";
            buttonTool32.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool33.SharedProps.Caption = "新規(F9)";
            buttonTool33.SharedProps.CustomizerCaption = "新規ボタン";
            buttonTool33.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool33.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F9;
            buttonTool34.SharedProps.Caption = "保存(F10)";
            buttonTool34.SharedProps.CustomizerCaption = "保存ボタン";
            buttonTool34.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool34.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            buttonTool35.SharedProps.Caption = "設定(&O)";
            buttonTool35.SharedProps.CustomizerCaption = "設定ボタン";
            buttonTool35.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool36.SharedProps.Caption = "元に戻す(&U)";
            buttonTool36.SharedProps.CustomizerCaption = "元に戻すボタン";
            buttonTool36.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool37.SharedProps.Caption = "終了（F1)";
            buttonTool37.SharedProps.CustomizerCaption = "終了ボタン";
            buttonTool37.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool37.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;
            buttonTool38.SharedProps.Caption = "伝票削除(F12)";
            buttonTool38.SharedProps.CustomizerCaption = "伝票削除ボタン";
            buttonTool38.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool38.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F12;
            buttonTool39.SharedProps.Caption = "発注選択(F8)";
            buttonTool39.SharedProps.CustomizerCaption = "発注選択ボタン";
            buttonTool39.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool39.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F8;
            buttonTool40.SharedProps.Caption = "結合登録(F7)";
            buttonTool40.SharedProps.CustomizerCaption = "結合登録ボタン";
            buttonTool40.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool40.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F7;
            buttonTool41.SharedProps.Caption = "セット(&L)";
            buttonTool41.SharedProps.CustomizerCaption = "セットボタン";
            buttonTool41.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool42.SharedProps.Caption = "新しいタブ(&T)";
            buttonTool42.SharedProps.CustomizerCaption = "新しいタブボタン";
            buttonTool42.SharedProps.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
            buttonTool43.SharedProps.Caption = "タブを閉じる(&C)";
            buttonTool43.SharedProps.CustomizerCaption = "タブを閉じるボタン";
            buttonTool43.SharedProps.Shortcut = System.Windows.Forms.Shortcut.CtrlW;
            buttonTool44.SharedProps.Caption = "他のタブを閉じる（&O)";
            buttonTool44.SharedProps.CustomizerCaption = "他のタブを閉じるボタンマウス用";
            popupMenuTool7.SharedProps.Caption = "編集(&E)";
            popupMenuTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool7.SharedProps.MergeOrder = 10;
            popupMenuTool7.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool45,
            buttonTool46});
            popupMenuTool8.SharedProps.Caption = "表示(&V)";
            popupMenuTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool8.SharedProps.MergeOrder = 10;
            popupMenuTool8.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool47,
            buttonTool48});
            popupMenuTool9.SharedProps.Caption = "マウス用メニュー";
            popupMenuTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool9.SharedProps.MergeOrder = 10;
            buttonTool51.InstanceProps.IsFirstInGroup = true;
            popupMenuTool9.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool49,
            buttonTool50,
            buttonTool51});
            buttonTool52.SharedProps.Caption = "新しいタブ(&N)";
            buttonTool52.SharedProps.CustomizerCaption = "新しいタブボタンマウス用";
            buttonTool53.SharedProps.Caption = "閉じる(&C)";
            buttonTool53.SharedProps.CustomizerCaption = "タブを閉じるボタンマウス用";
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Left";
            labelTool10.SharedProps.AppearancesSmall.Appearance = appearance1;
            labelTool10.SharedProps.CustomizerCaption = "ログイン拠点名";
            labelTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool10.SharedProps.MergeOrder = 60;
            labelTool10.SharedProps.ShowInCustomizer = false;
            labelTool10.SharedProps.Width = 150;
            buttonTool54.SharedProps.Caption = "タブを閉じる(ショートカット用)";
            buttonTool54.SharedProps.CustomizerCaption = "タブを閉じる(ショートカット用)";
            buttonTool54.SharedProps.Shortcut = System.Windows.Forms.Shortcut.CtrlF4;
            buttonTool55.SharedProps.Caption = "画面切替(F6)";
            buttonTool55.SharedProps.CustomizerCaption = "画面切替ボタン";
            buttonTool55.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool55.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F6;
            buttonTool56.SharedProps.Caption = "見積履歴(&Q)";
            buttonTool56.SharedProps.CustomizerCaption = "見積履歴ボタン";
            buttonTool56.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool57.SharedProps.Caption = "最新情報(&A)";
            buttonTool57.SharedProps.CustomizerCaption = "最新情報ボタン";
            buttonTool57.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool4,
            popupMenuTool5,
            popupMenuTool6,
            labelTool6,
            labelTool7,
            labelTool8,
            mdiWindowListTool1,
            buttonTool26,
            listTool2,
            labelTool9,
            buttonTool27,
            buttonTool28,
            buttonTool29,
            buttonTool30,
            buttonTool31,
            buttonTool32,
            buttonTool33,
            buttonTool34,
            buttonTool35,
            buttonTool36,
            buttonTool37,
            buttonTool38,
            buttonTool39,
            buttonTool40,
            buttonTool41,
            buttonTool42,
            buttonTool43,
            buttonTool44,
            popupMenuTool7,
            popupMenuTool8,
            popupMenuTool9,
            buttonTool52,
            buttonTool53,
            labelTool10,
            buttonTool54,
            buttonTool55,
            buttonTool56,
            buttonTool57});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            // 
            // _MAKAU00160UA_Toolbars_Dock_Area_Right
            // 
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 125);
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.Name = "_MAKAU00160UA_Toolbars_Dock_Area_Right";
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 586);
            this._MAKAU00160UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _MAKAU00160UA_Toolbars_Dock_Area_Top
            // 
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.Name = "_MAKAU00160UA_Toolbars_Dock_Area_Top";
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 125);
            this._MAKAU00160UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _MAKAU00160UA_Toolbars_Dock_Area_Bottom
            // 
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 711);
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.Name = "_MAKAU00160UA_Toolbars_Dock_Area_Bottom";
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._MAKAU00160UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // PMMIT01000UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.CancelButton = this.uButton_Close;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.Main_UTabControl);
            this.Controls.Add(this._MAKAU00160UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._MAKAU00160UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._MAKAU00160UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._MAKAU00160UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMMIT01000UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "検索見積";
            this.Load += new System.EventHandler(this.PMMIT01000UA_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DCKAU00160UA_FormClosed);
            this.ultraTabPageControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).EndInit();
            this.Main_UTabControl.ResumeLayout(false);
            this.ultraTabSharedControlsPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		// ===============================================================================
		// プライベート列挙型
		// ===============================================================================
        #region private enum
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }
        #endregion

		// ===================================================================================== //
		// 定数定義
		// ===================================================================================== //
		#region Private Constant
        // 得意先元帳
		private const string TAB_PARTSSEARCH = "PARTSSEARCH_TAB";
			
		private const string NO_TAB = "";

		private const string ctTOOLBAR_BUTTONTOOL_CLOSE_KEY = "ButtonTool_Close";
		private const string ctTOOLBAR_BUTTONTOOL_RETURN_KEY = "ButtonTool_Return";
		private const string ctTOOLBAR_BUTTONTOOL_FORWARD_KEY = "ButtonTool_Forward";
		private const string ctTOOLBAR_BUTTONTOOL_PRINT_KEY = "ButtonTool_Print";
		private const string ctTOOLBAR_BUTTONTOOL_NEW_KEY = "ButtonTool_New";
		private const string ctTOOLBAR_BUTTONTOOL_DELETESLIP_KEY = "ButtonTool_DeleteSlip";
		private const string ctTOOLBAR_BUTTONTOOL_UNDO_KEY = "ButtonTool_Undo";
		private const string ctTOOLBAR_BUTTONTOOL_GUIDE_KEY = "ButtonTool_Guide";
		private const string ctTOOLBAR_BUTTONTOOL_READSLIP_KEY = "ButtonTool_ReadSlip";
		private const string ctTOOLBAR_BUTTONTOOL_SLIPCOPY_KEY = "ButtonTool_SlipCopy";
		private const string ctTOOLBAR_BUTTONTOOL_CHANGEPARTSSEARCH_KEY = "ButtonTool_ChangePartsSearch";
		private const string ctTOOLBAR_BUTTONTOOL_ENTRYJOINPARTS_KEY = "ButtonTool_EntryJoinParts";
		private const string ctTOOLBAR_BUTTONTOOL_ORDERSELECT_KEY = "ButtonTool_OrderSelect";
		private const string ctTOOLBAR_BUTTONTOOL_SHOWSET_KEY = "ButtonTool_ShowSet";
		private const string ctTOOLBAR_BUTTONTOOL_SETTING_KEY = "ButtonTool_Setting";
		private const string ctTOOLBAR_BUTTONTOOL_CHANGEDISPLAY_KEY = "ButtonTool_ChangeDisplay";
        private const string ctTOOLBAR_BUTTONTOOL_RENEWAL_KEY = "ButtonTool_ReNewal"; // 2009.03.26
		
		// タブ関連
		private const string ctTOOLBAR_BUTTONTOOL_NEWTAB_KEY = "ButtonTool_NewTab";
		private const string ctTOOLBAR_BUTTONTOOL_NEWTAB_MOUSE_KEY = "ButtonTool_NewTab_Mouse";
		private const string ctTOOLBAR_BUTTONTOOL_CLOSETAB_KEY = "ButtonTool_CloseTab";
		private const string ctTOOLBAR_BUTTONTOOL_CLOSETAB_MOUSE_KEY = "ButtonTool_CloseTab_Mouse";
		private const string ctTOOLBAR_BUTTONTOOL_CLOSETAB_HIDDEN_KEY = "ButtonTool_CloseTab_Hidden";
		private const string ctTOOLBAR_BUTTONTOOL_CLOSEOTHERTAB_MOUSE_KEY = "ButtonTool_CloseOtherTab_Mouse";

		private const string ctTOOLBAR_LABELTOOL_LOGINTITLE_KEY = "LabelTool_LoginTitle";
		private const string ctTOOLBAR_LABELTOOL_LOGINNAME_KEY = "LabelTool_LoginName";
		private const string ctTOOLBAR_LABELTOOL_LOGINSECTIONTITLE_KEY = "LabelTool_LoginSectionTitle";
		private const string ctTOOLBAR_LABELTOOL_LOGINSECTIONNAME_KEY = "LabelTool_LoginSectionName";
		private const string ctTOOLBAR_LISTTOOL_TABFORM_KEY = "ListTool_TabForm";

        private const int ctTAB_MAXCNT = 10;

        //MDI子画面PGID
		private const string MDIPARTSSEARCH = "PMMIT01010U";   // 検索画面MDI子画面PGID

		private const string ctAssemblyName = "PMMIT01000U";
     
		#endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		#region Private Member

		// 各種ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;              // 閉じるボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _returnButton;             // 戻るボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _forwardButton;            // 次へボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _printButton;              // 保存ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _newtButton;               // 新規ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteSlipButton;         // 伝票削除ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;               // 元に戻すボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;              // ガイドボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _readSlipButton;           // 伝票呼出ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _slipCopyButton;           // 伝票複写ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _changePartsSearchButton;  // 部品検索切替ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _entryJoinPartsButton;     // 結合登録ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _orderSelectButton;        // 発注選択ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _showSetButton;            // セットボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _settingButton;            // 設定ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _changeDisplayButton;      // 画面切替ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _reNewalButton;		   	// 最新情報ボタン // 2009.03.26

		private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;           // ログイン担当者タイトル
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;            // ログイン担当者名
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionTitleLabel;    // ログイン拠点タイトル
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionNameLabel;     // ログイン拠点名

		// フォーム制御リスト
		private Hashtable _formControlInfoTable = new Hashtable();
		private ArrayList _formControlInfoList = new ArrayList();

		// 起動パラメータ
		private string _enterpriseCode = "";
        private int _customerCode = 0;

		// 拠点選択デフォルト表示設定
		private bool _isEvent = false;															 // イベント制御フラグ

        private SecInfoAcs _secInfoAcs;
        private SecInfoSet _ownSecInfoSet;

		private List<int> _tabIndexList = new List<int>();

        /// <summary>オプション情報</summary>
        private bool _opt_CarMng = true;
        private bool _opt_FreeSearch = true;
        private bool _opt_UOE = true;

        #endregion
		
		// ===================================================================================== //
		// デリゲートイベント
		// ===================================================================================== //
		#region DelegateEvent
		private void ParentToolbarSettingEvent(object sender)
		{
			ToolBarButtonEnabledSetting(sender);
		}
		#endregion

		// ===================================================================================== //
		// 内部メソッド
		// ===================================================================================== //
		# region Private Methods


        #region ■オプション情報制御処理
        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ●車両管理オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_CarMng);
            this._opt_CarMng = ( ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract );
            #endregion

            #region ●自由検索オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_FreeSearch);
            this._opt_FreeSearch = (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract);
            #endregion

            #region ●ＵＯＥオプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_UOE);
            this._opt_UOE = (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract);
            #endregion
        }
        #endregion


        #region モード別起動処理

        /// <summary>
        /// モード別起動処理
        /// <remarks>
        /// <br>Note      :  起動引数毎にパラメータを振り分けます</br>
        /// <br>Programer :  21024 佐々木　健</br>
        /// <br>Date      :  2008.06.18</br>        
        /// </remarks>
        /// </summary>
        private void MovingModeSetting()
        {          
            string[] args = Program._parameter;

			// 起動パラメータ設定
			if ((args != null) && (args.Length > (int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_CUSTOMERCODE))
			{
                //得意先指定型
				this._enterpriseCode = args[(int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_ENTERPRISECODE];
				this._customerCode = TStrConv.StrToIntDef(args[(int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_CUSTOMERCODE].ToString(), 0);				
			}
        }

        #endregion

        #region 拠点情報取得処理

        /// <summary>
        ///  自拠点情報の取得
        /// </summary>
        private void GetOwnSecInfo()
        {
            // 自拠点の取得
            SecInfoSet secInfoSet;
            _secInfoAcs.GetSecInfo(LoginInfoAcquisition.Employee.BelongSectionCode, out secInfoSet);

            if (secInfoSet != null)
            {
                this._ownSecInfoSet = secInfoSet;
            }
        }

        #endregion

        #region ツールバー初期設定処理
        /// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : ツールバーを初期設定します</br>
		/// <br>Programer  : 21024　佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void SetToolbar()
		{
			// イメージリストを設定する
			Main_ToolbarsManager.ImageListSmall = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;

			// ログイン担当者へのアイコン設定
			this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

			// 「終了」のアイコン設定
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

			// 「戻る」のアイコン設定
			this._returnButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;

			// 「進む」のアイコン設定
			this._forwardButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT;

			// 「印刷」のアイコン設定
			this._printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;

			// 「新規」のアイコン設定
			this._newtButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;

			// 「伝票削除」のアイコン設定
			this._deleteSlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;

			// 「元に戻す」のアイコン設定
			this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;

			// 「ガイド」のアイコン設定
			this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;

			// 「伝票呼出」のアイコン設定
			this._readSlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPSEARCH;

			// 「伝票複写」のアイコン設定
			this._slipCopyButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPCOPY;

			// 「部品検索切替」のアイコン設定
			this._changePartsSearchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PARTSSELECT;

			// 「結合登録」のアイコン設定
			this._entryJoinPartsButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RECYCLE;

			// 「発注選択」のアイコン設定
			this._orderSelectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SELECT;

			// 「セット」のアイコン設定
			this._showSetButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.WORK;

			// 「設定」のアイコン設定
			this._settingButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

			// 「画面切替」のアイコン設定
			this._changeDisplayButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;

            // 2009.03.26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 「最新情報」のアイコン設定
            this._reNewalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            // 2009.03.26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// 拠点ラベルのアイコン設定
			this._loginSectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;

            if (this._ownSecInfoSet != null)
            {
                // 拠点名
                this._loginSectionNameLabel.SharedProps.Caption = this._ownSecInfoSet.SectionGuideNm;
            }

			// ログイン名
			this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
		}

        #endregion

		#region フォームコントロール制御情報クリア処理
		/// <summary>
		/// フォームコントロール制御情報クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : フォームコントロールクラスをクリエイトし、データを格納します。</br>
		/// <br>Programmer : 21024　佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void FormControlInfoClear()
		{
			this._formControlInfoTable.Clear();
			this._formControlInfoList.Clear();
			this._tabIndexList.Clear();
		}

		#endregion

		#region 検索見積フォームコントロールクラス生成処理

		/// <summary>
		/// 検索見積タブフォーム生成処理
		/// </summary>
		/// <param name="index">作成用インデックス</param>
		/// <returns></returns>
		private void CreateEstimateControlInfo( int index )
		{
			string key = string.Format("{0}[{1}]", TAB_PARTSSEARCH, index);

			FormControlInfo info = new FormControlInfo(key, MDIPARTSSEARCH, "Broadleaf.Windows.Forms.PMMIT01010UA", string.Format("検索見積[{0}]", index), IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH], NO_TAB, NO_TAB);

			this._formControlInfoTable.Add(key, info);

			this._tabIndexList.Add(index);
		}

		#endregion

		#region 検索見積フォームコントロールクラス削除処理

		/// <summary>
		/// 検索見積タブフォーム生成処理
		/// </summary>
		/// <param name="index">作成用インデックス</param>
		/// <returns></returns>
		private void DeleteEstimateControlInfo( int index )
		{
			string key = string.Format("{0}[{1}]", TAB_PARTSSEARCH, index);

			if (this._formControlInfoTable.ContainsKey(key))
			{
				this._formControlInfoTable.Remove(key);
			}

			if (this._tabIndexList.Contains(index))
			{
				this._tabIndexList.Remove(index);
			}
		}

		#endregion

        #region 検索見積Tabフォームキーよりインデックス取得

        /// <summary>
        /// 検索見積もりタブフォームインデックス取得処理
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int GetEstimateTabIndex(string key)
        {
            string work = key.Replace(TAB_PARTSSEARCH, string.Empty);
            work = work.Replace("[", string.Empty);
            work = work.Replace("]", string.Empty);

            return TStrConv.StrToIntDef(work, -1);
        }
        #endregion

        #region 検索見積Tabフォーム生成処理

        /// <summary>
		/// 検索見積Tabフォーム生成処理
		/// </summary>
		/// <param name="index">インデックス</param>
		/// <remarks>
		/// <br>Note       : Tabフォームを生成します。</br>
		/// <br>Programer  : 21024　佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private bool EstimateTabCreate( int index )
		{
			string key = string.Format("{0}[{1}]", TAB_PARTSSEARCH, index);

			return this.TabCreate(key);
		}

		#endregion

		#region Tabフォーム生成処理

		/// <summary>
		/// Tabフォーム生成処理
		/// </summary>
		/// <param name="key">キー</param>
		/// <remarks>
		/// <br>Note       : Tabフォームを生成します。</br>
		/// <br>Programer  : 21024　佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private bool TabCreate(string key)
		{
			// フォーム制御テーブルにキーが存在しない場合は処理しない
			if (!this._formControlInfoTable.Contains(key)) return false;

			FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];

			if (info == null) return false;

			Form form = info.Form;

			if (form == null)
			{
				form = this.CreateTabForm(info.AssemblyID, info.ClassID, info.Key, info.Name, info.Icon, info);

				if (form == null) return false;

				info.Form = form;
			}
			else
			{
				this.Main_UTabControl.Tabs[key].Visible = true;
			}

			return true;
        }

        #endregion

		#region Tabフォーム削除処理

		/// <summary>
		/// Tabフォーム削除処理
		/// </summary>
		/// <param name="key">キー</param>
		/// <remarks>
		/// <br>Note       : Tabフォームを生成します。</br>
		/// <br>Programer  : 21024　佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private bool TabDelete( string key )
		{
			this.Main_UTabControl.BeginUpdate();
			try
			{
				// 指定キーのタブが存在しない場合は処理しない
				if (!this.Main_UTabControl.Tabs.Exists(key)) return false;

                int index = GetEstimateTabIndex(key);

                if (index > 0)
                {
                    this.DeleteEstimateControlInfo(index);
                }

                this.Main_UTabControl.Tabs.Remove(this.Main_UTabControl.Tabs[key]);

				return true;
			}
			finally
			{
				this.Main_UTabControl.EndUpdate();
			}
		}

		#endregion

		#region 検索見積Tabフォーム追加処理
		/// <summary>
		/// 検索見積Tabフォーム追加処理
		/// </summary>
		/// <returns></returns>
		private void EstimateTabAdd()
		{
			int index = ( this._tabIndexList.Count > 0 ) ? this._tabIndexList[this._tabIndexList.Count - 1] + 1 : 1;
			this.CreateEstimateControlInfo(index);
			this.EstimateTabCreate(index);
		}
		#endregion

        #region タブアクティブ化処理
        /// <summary>
		/// タブアクティブ化処理
		/// </summary>
		/// <param name="key">アクティブにするフォームのキー情報</param>
		/// <returns>成否[TRUE:成功 FALSE:失敗]</returns>
		/// <remarks>
		/// <br>Note       : Tabフォームをアクティブにします。</br>
		/// <br>Programer  : 21024　佐々木　健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private bool TabActive(string key)
		{			
			// 指定キーのタブが存在しない場合は処理しない
			if (!this.Main_UTabControl.Tabs.Exists(key)) return false;

			bool result = false;

			switch (key)
			{
				default:
				{
					break;
				}
			}
			return result;
        }
        
        /// <summary>
		/// タブアクティブ化処理
		/// </summary>
		/// <param name="key">アクティブにするフォームのキー情報</param>
		/// <param name="form">アクティブフォーム</param>
		/// <returns>成否[TRUE:成功 FALSE:失敗]</returns>
		/// <remarks>
		/// <br>Note       : Tabフォームをアクティブにします。</br>
		/// <br>Programer  : 21024　佐々木　健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private bool TabActive(string key, ref Form form)
		{
			// タブコントロール上、キーが存在しない場合は処理しない
			if (!this.Main_UTabControl.Tabs.Exists(key)) return false;

			bool result = this.TabActive(key);

			// 該当キーのタブをアクティブにする
			if (result)
			{
				// フォームを取得する
				if (this.Main_UTabControl.Tabs[key].Tag is Form)
				{
					form = (Form)this.Main_UTabControl.Tabs[key].Tag;
				}
			}
			return result;
		}

        #endregion

        #region タブ子画面を生成処理
        /// <summary>
		/// タブ子画面を生成処理
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : MDI子画面を生成処理</br>
		/// <br>Programer  : 21024　佐々木　健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private Form CreateTabForm( string frmAssemblyName, string frmClassName, string frmName, string title, Image icon, FormControlInfo info )
		{
			Form form = null;

			form = (System.Windows.Forms.Form)this.LoadAssemblyFrom(info.AssemblyID, info.ClassID, typeof(System.Windows.Forms.Form));

			if (form == null)
			{
				form = new Form();
			}

			if (form != null)
			{
				// タブコントロールに追加するタブページをインスタンス化する
				Infragistics.Win.UltraWinTabControl.UltraTabPageControl dataviewTabPageControl =
					new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();

				// タブの外観を設定し、タブコントロールにタブを追加する
				Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

				dataviewTab.TabPage = dataviewTabPageControl;
				dataviewTab.Text = info.Name;
				dataviewTab.Key = info.Key;
				dataviewTab.Tag = form;
				dataviewTab.Appearance.Image = info.Icon;
				dataviewTab.Appearance.BackColor = Color.White;
				dataviewTab.Appearance.BackColor2 = Color.Lavender;
				dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
				dataviewTab.ActiveAppearance.BackColor = Color.White;
				dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
				dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
				dataviewTab.ActiveAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                
				this.Main_UTabControl.Controls.Add(dataviewTabPageControl);
				this.Main_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
				this.Main_UTabControl.SelectedTab = dataviewTab;

				// フォームプロパティ変更
				form.TopLevel = false;
				form.FormBorderStyle = FormBorderStyle.None;
				dataviewTabPageControl.Controls.Add(form);

				// ILedgerMDIChildインターフェイスを実装している場合は以下の処理を実行する。
				if (( form is IEstimateMDIChild ))
				{
					( (IEstimateMDIChild)form ).ParentToolbarLedgerSettingEvent += new ParentToolbarLedgerSettingEventHandler(this.ToolBarButtonEnabledSetting);

					( (IEstimateMDIChild)form ).Show(null);

				}
				else
					form.Show();

				form.Dock = System.Windows.Forms.DockStyle.Fill;
			}

			info.Form = form;
			return form;
		}

        #endregion

        #region アセンブリインスタンス化処理
        /// <summary>
		/// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化する
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
		private object LoadAssemblyFrom(string asmname, string classname, Type type)
		{
			object obj = null;
			try
			{
				System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
				Type objType = asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch (System.IO.FileNotFoundException er)
			{
				// 対象アセンブリなし！
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "画面のロードに失敗しました" + "\n\r" + er.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			catch (System.Exception er)
			{
				// 対象アセンブリなし
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "画面のロードに失敗しました" + "\n\r" + er.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			return obj;
        }

        #endregion

        #region ツールバーボタン有効無効設定処理
        /// <summary>
		/// ツールバーボタン有効無効設定処理
		/// </summary>
		/// <param name="activeForm">アクティブなフォーム</param>
		/// <remarks>
		/// <br>Note       : ツールーバーボタンの有効・無効設定を行います。</br>
		/// <br>Programer  : 21024　佐々木　健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void ToolBarButtonEnabledSetting(object activeForm)
		{
			if (activeForm is IEstimateMDIChild)
			{
                this.Main_ToolbarsManager.BeginUpdate();

                this._returnButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanReturnButton;
				this._forwardButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanForwardButton;
				this._printButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanPrintButton;
				this._newtButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanNewButton;
				this._deleteSlipButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanDeleteSlipButton;
				this._undoButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanUndoButton;
				this._guideButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanGuideButton;
				this._readSlipButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanReadSlipButton;
				this._slipCopyButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanCopySlipButton;
				this._changePartsSearchButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanChangePartsSearchButton;
				this._entryJoinPartsButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanEntryJoinPartsButton;
				this._orderSelectButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanOrderSelectButton;
				this._showSetButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanShowSetButton;
				this._changeDisplayButton.SharedProps.Enabled = ( (IEstimateMDIChild)activeForm ).CanChangeDisplayButton;

                this.Main_ToolbarsManager.EndUpdate();
			}
        }

        #endregion

        #region ツールバーのタブリスト作成処理
        /// <summary>
		/// ツールバーのタブリストを生成する
		/// </summary>
		/// <param name="sender">呼出元のオブジェクト</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Programer  : 21024　佐々木　健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void SetToolBarTabFormList(object sender)
		{
			Infragistics.Win.UltraWinToolbars.ListTool tabList = (Infragistics.Win.UltraWinToolbars.ListTool)Main_ToolbarsManager.Tools[ctTOOLBAR_LISTTOOL_TABFORM_KEY];
			tabList.ListToolItems.Clear();

			// ウィンドウ・ツールバーを再編成及び表示する
			for (int i = 0; i < this.Main_UTabControl.Tabs.Count; i++)
			{
				Infragistics.Win.UltraWinToolbars.ListToolItem itm = new Infragistics.Win.UltraWinToolbars.ListToolItem();
				if (this.Main_UTabControl.Tabs[i].Visible)
				{
					itm.Key = this.Main_UTabControl.Tabs[i].Key;
					itm.Text = string.Format("&{0:d} {1}", i + 1, this.Main_UTabControl.Tabs[i].Text);
					tabList.ListToolItems.Add(itm);
					if (this.Main_UTabControl.Tabs[i].Selected == true)
					{
						tabList.SelectedItemIndex = tabList.ListToolItems.Count - 1;
					}
				}
			}
        }
        #endregion

        #region エラーメッセージ表示処理
        /// <summary>
		/// エラーメッセージ表示
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="iMsg">エラーメッセージ</param>
		/// <param name="iSt">エラーステータス</param>
		/// <param name="iButton">表示ボタン</param>
		/// <param name="iDefButton">初期フォーカスボタン</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : エラーメッセージを表示します。</br>
		/// <br>Programmer : 21024　佐々木　健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }
        #endregion

        # endregion

        // ===================================================================================== //
		// コントロールイベント
		// ===================================================================================== //
		#region Control Event

        #region FormLoadイベント
        /// <summary>
		/// メインフレームのLOADイベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : メインフレームのLOADイベント</br>
		/// <br>Programer  : 21024　佐々木　健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
        private void PMMIT01000UA_Load(object sender, EventArgs e)
        {
            this.SettingOptionInfo();
            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// オプション情報設定
        /// </summary>
        private void SettingOptionInfo()
        {
            this._orderSelectButton.SharedProps.Visible = this._opt_UOE;
        }
        #endregion

        #region TimerTickイベント
        /// <summary>
		/// 起動タイマーイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
		private void Initial_Timer_Tick(object sender, EventArgs e)
		{
			this.Initial_Timer.Enabled = false;
			this._isEvent = false;

			try
			{
				this._isEvent = false;

                this.GetOwnSecInfo();

				// ツールバーを設定する
				this.SetToolbar();

				this.Main_UTabControl.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;

				// フォーム制御情報クリア
				this.FormControlInfoClear();

				// 検索見積のフォーム制御テーブル作成
				this.CreateEstimateControlInfo(1);

				// 部品検索タブ生成
				if (this.EstimateTabCreate(1))
				{
					//// 得意先元帳をアクティブにする
					//if (this.Main_UTabControl.Tabs.Exists(TAB_PARTSSEARCH))
					//{
					//    //Form form = (Form)this.Main_UTabControl.Tabs[TAB_PARTSSEARCH].Tag;
					//    //this.TabActive(NO0_CUSTOMERLEDGER_TAB, ref form);
					//}
				}

				ToolbarManagerCustomizeSettingAcs.LoadToolManagerCustomizeInfo(ctAssemblyName, ref this.Main_ToolbarsManager);
			}
			catch (Exception ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			finally
			{
				this._isEvent = true;
			}
        }

        #endregion

        #region ToolClickイベント
        /// <summary>
		/// ToolBarのclick・イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : ToolBarのclick・イベント</br>
		/// <br>Programer  : 21024　佐々木　健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolClick( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
		{
			switch (e.Tool.Key)
			{
				//---------------------------------------------------------------------
				// 終了ボタン
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_CLOSE_KEY:
					{
                        bool isClose = false;
                        if (this.Main_UTabControl.Tabs.Count > 1)
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_QUESTION,
                                this.Name,
                                "全てのタブを閉じます。よろしいですか？",
                                0,
                                MessageBoxButtons.OKCancel);

                            isClose = ( dialogResult == DialogResult.OK ) ? true : false;
                        }
                        else
                        {
                            isClose = true;
                        }
                        if (isClose)
                        {
                            foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Main_UTabControl.Tabs)
                            {
                                if (tab.Tag is System.Windows.Forms.Form)
                                {
                                    ( (System.Windows.Forms.Form)tab.Tag ).Close();
                                }
                            }
                           
                            // メイン画面のクローズ
                            this.Close();
                        }
						break;
					}

				//---------------------------------------------------------------------
				// 新しいタブ
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_NEWTAB_KEY:
				case ctTOOLBAR_BUTTONTOOL_NEWTAB_MOUSE_KEY:
					{
                        if (this.Main_UTabControl.Tabs.Count == ctTAB_MAXCNT)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "これ以上追加できません。",
                                0,
                                MessageBoxButtons.OK);
                        }
                        else
                        {
                            this.EstimateTabAdd();
                        }
						break;
					}

				//---------------------------------------------------------------------
				// タブを閉じる
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_CLOSETAB_KEY:
				case ctTOOLBAR_BUTTONTOOL_CLOSETAB_HIDDEN_KEY:
				case ctTOOLBAR_BUTTONTOOL_CLOSETAB_MOUSE_KEY:
					{
						if (this.Main_UTabControl.ActiveTab != null)
						{
							this.TabDelete(this.Main_UTabControl.ActiveTab.Key);
						}
						break;
					}

				//---------------------------------------------------------------------
				// 他のタブを閉じる
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_CLOSEOTHERTAB_MOUSE_KEY:
					{
						string key = this.Main_UTabControl.ActiveTab.Key;
						List<string> deleteKeyList = new List<string>();
						foreach(Infragistics.Win.UltraWinTabControl.UltraTab ultraTab in this.Main_UTabControl.Tabs)
						{
							if (ultraTab.Key != key)
							{
								deleteKeyList.Add(ultraTab.Key);
							}
						}

						foreach (string deleteKey in deleteKeyList)
						{
							this.TabDelete(deleteKey);
						}

						break;
					}

				//---------------------------------------------------------------------
				// 戻る
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_RETURN_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).FocusSet_Return();
						}
						break;
					}

				//---------------------------------------------------------------------
				// 進む
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_FORWARD_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).FocusSet_Forward();
						}
						break;
					}

				//---------------------------------------------------------------------
				// 画面切替
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_CHANGEDISPLAY_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).ChangeDisplay();
						}
						break;
					}

				//---------------------------------------------------------------------
				// 印刷
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_PRINT_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
                            if (( (IEstimateMDIChild)activeForm ).PrintBeforeCheack())
                            {
                                ( (IEstimateMDIChild)activeForm ).Print();
                            }
						}
						break;
					}

				//---------------------------------------------------------------------
				// 新規
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_NEW_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).CreateNewSlip();
						}
						break;
					}

				//---------------------------------------------------------------------
				// 伝票削除
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_DELETESLIP_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).DeleteSlip();
						}
						break;
					}

				//---------------------------------------------------------------------
				// 元に戻す
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_UNDO_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).Undo();
						}
						break;
					}

				//---------------------------------------------------------------------
				// ガイド
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_GUIDE_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).ExecuteGuide();
						}
						break;
					}

				//---------------------------------------------------------------------
				// 伝票呼出
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_READSLIP_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).ReadSlip();
						}
						break;
					}

				//---------------------------------------------------------------------
				// 伝票複写
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_SLIPCOPY_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).CopySlip();
						}
						break;
					}

				//---------------------------------------------------------------------
				// 部品検索切替
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_CHANGEPARTSSEARCH_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).ChangePartsSearch();
						}
						break;
					}

				//---------------------------------------------------------------------
				// 結合登録
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_ENTRYJOINPARTS_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).EntryJoinParts();
						}
						break;
					}

				//---------------------------------------------------------------------
				// 発注選択
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_ORDERSELECT_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).OrderSelect();
						}
						break;
					}

				//---------------------------------------------------------------------
				// セット
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_SHOWSET_KEY:
					{
						Form activeForm = (Form)this.Main_UTabControl.SelectedTab.Tag;
						if (( activeForm is IEstimateMDIChild ))
						{
							( (IEstimateMDIChild)activeForm ).ShowSet();
						}
						break;
					}

				//---------------------------------------------------------------------
				// 設定
				//---------------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_SETTING_KEY:
					{
						EstimateInputSetup _estimateInputSetup = new EstimateInputSetup();

						_estimateInputSetup.ShowDialog(this);
						break;
					}

                // 2009.03.26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //---------------------------------------------------------------------
                // 最新情報
                //---------------------------------------------------------------------
                case ctTOOLBAR_BUTTONTOOL_RENEWAL_KEY:
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "全てのタブの画面情報はクリアされます。" + "\r\n" + "\r\n" +
                            "よろしいですか？",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                        if (dialogResult == DialogResult.No) break;

                        foreach (Infragistics.Win.UltraWinTabControl.UltraTab ultraTab in this.Main_UTabControl.Tabs)
                        {
                            Form activeForm = (Form)ultraTab.Tag;
                            if ((activeForm is IEstimateMDIChild))
                            {
                                ((IEstimateMDIChild)activeForm).CreateNewSlip();
                            }
                        }

                        Form activeFormm = (Form)this.Main_UTabControl.SelectedTab.Tag;
                        if ((activeFormm is IEstimateMDIChild))
                        {
                            ((IEstimateMDIChild)activeFormm).ReNewal();
                        }

                        break;
                    }
                // 2009.03.26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			}
		}

        #endregion

        #region Form_Activatedイベント
		/// <summary>
		/// MDI子画面のActiveイベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : MDI子画面のActiveイベント</br>
		/// <br>Programer  : 21024　佐々木　健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void Form_Activated(object sender, System.EventArgs e)
		{
        }

        #endregion

        #region Form_Deactivatedイベント
        /// <summary>
		/// MDI子画面のDeactivedイベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : MDI子画面のDeactivedイベント</br>
		/// <br>Programer  : 21024　佐々木　健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void Form_Deactivated(object sender, System.EventArgs e)
		{
        }

        #endregion

        #region SelectedTabChangedイベント
        /// <summary>
		/// タブ子画面タブ選択後処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// <br>Note       : タブ子画面タブ選択後に発生するイベントです。</br>
		/// <br>Programer  : 21024　佐々木　健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		private void Main_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
		{
			if (!this._isEvent)
				return;

			this._isEvent = false;
			try
			{
				if (e.Tab == null)
					return;

				// アクティブ状態のタブからフォームを取得する
				object target = this.Main_UTabControl.SelectedTab.Tag;

				this.ToolBarButtonEnabledSetting(target);				
			}
			finally
			{
				this._isEvent = true;
			}
        }
        #endregion

        #region FormClosedイベント
        /// <summary>
		///	フォームを閉じようとした時のイベントです。
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : フォームが閉じられた後に発生します。</br>
		/// <br>Programmer  : 21024　佐々木　健</br>
		/// <br>Date        : 2008.06.18</br>
		/// </remarks>
        private void DCKAU00160UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            // イベントを発生させない為、フラグON
            this._isEvent = false;

			//// 子画面を破棄する
			//if (this._partsSearchForm != null)
			//{
			//    this._partsSearchForm.Close();
			//    this._partsSearchForm.Dispose();
			//}

            // 各帳票のブラウザに空アドレスを表示させます。表示しているPDFファイルを閉じる為です。
            foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Main_UTabControl.Tabs)
            {
                this.Main_UTabControl.Tabs.Remove(tab);
            }
			ToolbarManagerCustomizeSettingAcs.SaveToolManagerCustomizeInfo(ctAssemblyName, this.Main_ToolbarsManager);
        }
        #endregion

		#region MouseClickイベント
		/// <summary>
		/// タブ画面MouseClickイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : Tab領域がクリックされた場合に発生します。</br>
		/// <br>Programmer  : 21024　佐々木　健</br>
		/// <br>Date        : 2008.06.18</br>
		/// </remarks>
		private void Main_UTabControl_MouseClick( object sender, MouseEventArgs e )
		{
			if (e.Button == MouseButtons.Right)
			{
				// それ以外で右クリックされた場合は、編集のポップアップを表示する
				( (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools["PopupMenuTool_Mouse"] ).ShowPopup(System.Windows.Forms.Cursor.Position, this);
			}
		}
		#endregion

        // 2009.03.31 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region 終了ButtonClicイベント
        /// <summary>
        /// uButton_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            bool isClose = false;

            DialogResult dResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "終了してもよろしいですか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.Yes)
            {
                if (this.Main_UTabControl.Tabs.Count > 1)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "全てのタブを閉じます。よろしいですか？",
                        0,
                        MessageBoxButtons.OKCancel);

                    isClose = (dialogResult == DialogResult.OK) ? true : false;
                }
                else
                {
                    isClose = true;
                }
                if (isClose)
                {
                    foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Main_UTabControl.Tabs)
                    {
                        if (tab.Tag is System.Windows.Forms.Form)
                        {
                            ((System.Windows.Forms.Form)tab.Tag).Close();
                        }
                    }

                    // メイン画面のクローズ
                    this.Close();
                }
            }
        }
        #endregion
        // 2009.03.31 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion

    }
}