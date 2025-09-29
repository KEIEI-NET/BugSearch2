using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Facade;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// マスタメンテナンスメインフレームフォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : マスタメンテナンスの制御全般を行います。</br>
    /// <br>Programmer : 陳永康</br>
    /// <br>Date       : 2014/12/23</br>
	/// <br></br>
    /// </remarks>
	public class PMKHN09760UA : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea2;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow2;
		private Infragistics.Win.UltraWinTree.UltraTree StartNavigatorTree;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl DataViewTabControl;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage DataViewTabSharedControlsPage;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar MainStatusBar;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinDock.UltraDockManager ultraDockManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ALPK000001VMAC_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ALPK000001VMAC_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ALPK000001VMAC_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ALPK000001VMAC_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _ALPK000001VMACUnpinnedTabAreaLeft;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _ALPK000001VMACUnpinnedTabAreaRight;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _ALPK000001VMACUnpinnedTabAreaTop;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _ALPK000001VMACUnpinnedTabAreaBottom;
		private Infragistics.Win.UltraWinDock.AutoHideControl _ALPK000001VMACAutoHideControl;
        private Timer Initialize_Timer;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// マスタメンテナンスメインフレームフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : マスタメンテナンスメインフレームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		public PMKHN09760UA()
		{
			InitializeComponent();

			System.Runtime.Remoting.RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

			this._constructionFilePath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME);

			Infragistics.Win.UltraWinToolbars.OptionSet optionSet = new Infragistics.Win.UltraWinToolbars.OptionSet("TabWindow");
			optionSet.AllowAllUp = false;
			this.ultraToolbarsManager1.OptionSets.Add(optionSet);
			this._controlScreenSkin = new ControlScreenSkin();
		}
		# endregion

		# region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (this._dockMemoryStream != null)
				{
					this._dockMemoryStream.Close();
					this._dockMemoryStream = null;
				}

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
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("04c95a0d-40ab-4ac9-b510-d49035561a47"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("5a1d46b4-3d29-4eb1-be3a-4f4ee095f573"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("04c95a0d-40ab-4ac9-b510-d49035561a47"), -1);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("ec6e3420-f1b1-4453-a0f5-4903ce30aa25"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("3590a19d-425f-446e-b3c2-28317376155e"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("ec6e3420-f1b1-4453-a0f5-4903ce30aa25"), -1);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.OptionSet optionSet1 = new Infragistics.Win.UltraWinToolbars.OptionSet("WindowStyle");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenuBar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_Menu");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_Menu");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_Label");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_Label");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("ButtonMenuBar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close_Button");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar3 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("SearchInfoBar");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("SearchTitle_Label");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("SearchItemTitle_Label");
            Infragistics.Win.UltraWinToolbars.TextBoxTool textBoxTool1 = new Infragistics.Win.UltraWinToolbars.TextBoxTool("SearchItem_TextBox");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("SearchPosition_Label");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("SearchPosition2_ComboBox");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool2 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("SearchPosition_ComboBox");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Search_Button");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_Menu");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close_Button");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_Menu");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ShowAll_Button");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("HideAll_Button");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Pinnall_Button");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UnPinAll_Button");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Reset_Button");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close_Button");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_Label");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_Label");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ShowAll_Button");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("HideAll_Button");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Pinnall_Button");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UnPinAll_Button");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Reset_Button");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool("SearchTitle_Label");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.TextBoxTool textBoxTool2 = new Infragistics.Win.UltraWinToolbars.TextBoxTool("SearchItem_TextBox");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool10 = new Infragistics.Win.UltraWinToolbars.LabelTool("SearchItemTitle_Label");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool11 = new Infragistics.Win.UltraWinToolbars.LabelTool("SearchPosition_Label");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool3 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("SearchPosition_ComboBox");
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Search_Button");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool12 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool4 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("SearchPosition2_ComboBox");
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool1 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("WindowStyle1_StateButtonTool", "WindowStyle");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool2 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("WindowStyle2_StateButtonTool", "WindowStyle");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09760UA));
            this.StartNavigatorTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.DataViewTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.DataViewTabSharedControlsPage = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.MainStatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._ALPK000001VMACUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ALPK000001VMACUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ALPK000001VMACUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ALPK000001VMACUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ALPK000001VMACAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.dockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.windowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.Initialize_Timer = new System.Windows.Forms.Timer(this.components);
            this._ALPK000001VMAC_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._ALPK000001VMAC_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ALPK000001VMAC_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ALPK000001VMAC_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewTabControl)).BeginInit();
            this.DataViewTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).BeginInit();
            this.windowDockingArea1.SuspendLayout();
            this.dockableWindow2.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            this.windowDockingArea2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartNavigatorTree
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            this.StartNavigatorTree.Appearance = appearance1;
            this.StartNavigatorTree.HideSelection = false;
            this.StartNavigatorTree.Location = new System.Drawing.Point(0, 27);
            this.StartNavigatorTree.Name = "StartNavigatorTree";
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Single;
            this.StartNavigatorTree.Override = _override1;
            this.StartNavigatorTree.Size = new System.Drawing.Size(250, 628);
            this.StartNavigatorTree.TabIndex = 10;
            this.StartNavigatorTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartNavigatorTree_MouseDown);
            this.StartNavigatorTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartNavigatorTree_KeyDown);
            this.StartNavigatorTree.DoubleClick += new System.EventHandler(this.StartNavigatorTree_DoubleClick);
            this.StartNavigatorTree.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.StartNavigatorTree_AfterCheck);
            // 
            // DataViewTabControl
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.DataViewTabControl.Appearance = appearance2;
            this.DataViewTabControl.Controls.Add(this.DataViewTabSharedControlsPage);
            this.DataViewTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(2);
            this.DataViewTabControl.Location = new System.Drawing.Point(0, 27);
            this.DataViewTabControl.Name = "DataViewTabControl";
            this.DataViewTabControl.SharedControlsPage = this.DataViewTabSharedControlsPage;
            this.DataViewTabControl.Size = new System.Drawing.Size(761, 628);
            this.DataViewTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.DataViewTabControl.TabIndex = 12;
            this.DataViewTabControl.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.MultiRowFixed;
            this.DataViewTabControl.TabStop = false;
            this.DataViewTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.DataViewTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.DataViewTabControl.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.DataViewTabControl_ControlRemoved);
            this.DataViewTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.DataViewTabControl_SelectedTabChanged);
            // 
            // DataViewTabSharedControlsPage
            // 
            this.DataViewTabSharedControlsPage.Location = new System.Drawing.Point(1, 20);
            this.DataViewTabSharedControlsPage.Name = "DataViewTabSharedControlsPage";
            this.DataViewTabSharedControlsPage.Size = new System.Drawing.Size(759, 607);
            // 
            // MainStatusBar
            // 
            this.MainStatusBar.Location = new System.Drawing.Point(0, 711);
            this.MainStatusBar.Name = "MainStatusBar";
            appearance6.TextHAlignAsString = "Center";
            this.MainStatusBar.PanelAppearance = appearance6;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "Text";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            appearance15.FontData.BoldAsString = "True";
            appearance15.ForeColor = System.Drawing.Color.Red;
            ultraStatusPanel2.Appearance = appearance15;
            ultraStatusPanel2.Key = "Msg";
            ultraStatusPanel2.Text = "設定更新後、PMタブレットアップロード処理を実行して下さい。";
            ultraStatusPanel2.Visible = false;
            ultraStatusPanel2.Width = 500;
            ultraStatusPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel3.Key = "Date";
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel3.Width = 90;
            ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel4.Key = "Time";
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel4.Width = 50;
            this.MainStatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4});
            this.MainStatusBar.Size = new System.Drawing.Size(1016, 23);
            this.MainStatusBar.TabIndex = 4;
            this.MainStatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            this.MainStatusBar.WrapText = false;
            // 
            // ultraDockManager1
            // 
            this.ultraDockManager1.AnimationSpeed = Infragistics.Win.UltraWinDock.AnimationSpeed.StandardSpeedPlus5;
            this.ultraDockManager1.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            dockAreaPane1.DockedBefore = new System.Guid("ec6e3420-f1b1-4453-a0f5-4903ce30aa25");
            dockableControlPane1.Control = this.StartNavigatorTree;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(250, -1);
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(140, 210, 250, 97);
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            appearance4.FontData.SizeInPoints = 10F;
            dockableControlPane1.Settings.Appearance = appearance4;
            dockableControlPane1.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "起動ナビゲーター";
            dockableControlPane1.TextTab = "起動ナビゲーター";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(250, 655);
            dockableControlPane2.Control = this.DataViewTabControl;
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(430, 480, 320, 140);
            dockableControlPane2.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane2.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane2.Settings.AllowPin = Infragistics.Win.DefaultableBoolean.False;
            appearance5.FontData.SizeInPoints = 10F;
            dockableControlPane2.Settings.Appearance = appearance5;
            dockableControlPane2.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane2.Size = new System.Drawing.Size(638, 668);
            dockableControlPane2.Text = "データビュー";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(761, 655);
            dockAreaPane2.UnfilledSize = new System.Drawing.Size(643, 668);
            this.ultraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2});
            this.ultraDockManager1.HostControl = this;
            this.ultraDockManager1.LayoutStyle = Infragistics.Win.UltraWinDock.DockAreaLayoutStyle.FillContainer;
            this.ultraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _ALPK000001VMACUnpinnedTabAreaLeft
            // 
            this._ALPK000001VMACUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._ALPK000001VMACUnpinnedTabAreaLeft.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._ALPK000001VMACUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 56);
            this._ALPK000001VMACUnpinnedTabAreaLeft.Name = "_ALPK000001VMACUnpinnedTabAreaLeft";
            this._ALPK000001VMACUnpinnedTabAreaLeft.Owner = this.ultraDockManager1;
            this._ALPK000001VMACUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 655);
            this._ALPK000001VMACUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _ALPK000001VMACUnpinnedTabAreaRight
            // 
            this._ALPK000001VMACUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._ALPK000001VMACUnpinnedTabAreaRight.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._ALPK000001VMACUnpinnedTabAreaRight.Location = new System.Drawing.Point(1016, 56);
            this._ALPK000001VMACUnpinnedTabAreaRight.Name = "_ALPK000001VMACUnpinnedTabAreaRight";
            this._ALPK000001VMACUnpinnedTabAreaRight.Owner = this.ultraDockManager1;
            this._ALPK000001VMACUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 655);
            this._ALPK000001VMACUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _ALPK000001VMACUnpinnedTabAreaTop
            // 
            this._ALPK000001VMACUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._ALPK000001VMACUnpinnedTabAreaTop.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._ALPK000001VMACUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 56);
            this._ALPK000001VMACUnpinnedTabAreaTop.Name = "_ALPK000001VMACUnpinnedTabAreaTop";
            this._ALPK000001VMACUnpinnedTabAreaTop.Owner = this.ultraDockManager1;
            this._ALPK000001VMACUnpinnedTabAreaTop.Size = new System.Drawing.Size(1016, 0);
            this._ALPK000001VMACUnpinnedTabAreaTop.TabIndex = 7;
            // 
            // _ALPK000001VMACUnpinnedTabAreaBottom
            // 
            this._ALPK000001VMACUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._ALPK000001VMACUnpinnedTabAreaBottom.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._ALPK000001VMACUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 711);
            this._ALPK000001VMACUnpinnedTabAreaBottom.Name = "_ALPK000001VMACUnpinnedTabAreaBottom";
            this._ALPK000001VMACUnpinnedTabAreaBottom.Owner = this.ultraDockManager1;
            this._ALPK000001VMACUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1016, 0);
            this._ALPK000001VMACUnpinnedTabAreaBottom.TabIndex = 8;
            // 
            // _ALPK000001VMACAutoHideControl
            // 
            this._ALPK000001VMACAutoHideControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._ALPK000001VMACAutoHideControl.Location = new System.Drawing.Point(22, 48);
            this._ALPK000001VMACAutoHideControl.Name = "_ALPK000001VMACAutoHideControl";
            this._ALPK000001VMACAutoHideControl.Owner = this.ultraDockManager1;
            this._ALPK000001VMACAutoHideControl.Size = new System.Drawing.Size(255, 663);
            this._ALPK000001VMACAutoHideControl.TabIndex = 9;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Controls.Add(this.dockableWindow2);
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea1.Location = new System.Drawing.Point(0, 56);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.ultraDockManager1;
            this.windowDockingArea1.Size = new System.Drawing.Size(255, 655);
            this.windowDockingArea1.TabIndex = 11;
            // 
            // dockableWindow2
            // 
            this.dockableWindow2.Controls.Add(this.StartNavigatorTree);
            this.dockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow2.Name = "dockableWindow2";
            this.dockableWindow2.Owner = this.ultraDockManager1;
            this.dockableWindow2.Size = new System.Drawing.Size(250, 655);
            this.dockableWindow2.TabIndex = 18;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.DataViewTabControl);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.ultraDockManager1;
            this.dockableWindow1.Size = new System.Drawing.Size(761, 655);
            this.dockableWindow1.TabIndex = 19;
            // 
            // windowDockingArea2
            // 
            this.windowDockingArea2.Controls.Add(this.dockableWindow1);
            this.windowDockingArea2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowDockingArea2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea2.Location = new System.Drawing.Point(255, 56);
            this.windowDockingArea2.Name = "windowDockingArea2";
            this.windowDockingArea2.Owner = this.ultraDockManager1;
            this.windowDockingArea2.Size = new System.Drawing.Size(761, 655);
            this.windowDockingArea2.TabIndex = 13;
            // 
            // Initialize_Timer
            // 
            this.Initialize_Timer.Interval = 1;
            this.Initialize_Timer.Tick += new System.EventHandler(this.Initialize_Timer_Tick);
            // 
            // _ALPK000001VMAC_Toolbars_Dock_Area_Left
            // 
            this._ALPK000001VMAC_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ALPK000001VMAC_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._ALPK000001VMAC_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._ALPK000001VMAC_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ALPK000001VMAC_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 56);
            this._ALPK000001VMAC_Toolbars_Dock_Area_Left.Name = "_ALPK000001VMAC_Toolbars_Dock_Area_Left";
            this._ALPK000001VMAC_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 655);
            this._ALPK000001VMAC_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.AlwaysShowMenusExpanded = Infragistics.Win.DefaultableBoolean.True;
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.SizeInPoints = 9F;
            this.ultraToolbarsManager1.Appearance = appearance3;
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            optionSet1.AllowAllUp = false;
            this.ultraToolbarsManager1.OptionSets.Add(optionSet1);
            this.ultraToolbarsManager1.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.ShowQuickCustomizeButton = false;
            this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            labelTool1.InstanceProps.Spring = Infragistics.Win.DefaultableBoolean.True;
            labelTool1.InstanceProps.Width = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            labelTool1,
            labelTool2,
            labelTool3});
            appearance7.FontData.SizeInPoints = 9F;
            ultraToolbar1.Settings.Appearance = appearance7;
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            buttonTool1.InstanceProps.IsFirstInGroup = true;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1});
            appearance8.FontData.SizeInPoints = 9F;
            ultraToolbar2.Settings.Appearance = appearance8;
            ultraToolbar2.Text = "標準";
            ultraToolbar3.DockedColumn = 1;
            ultraToolbar3.DockedRow = 1;
            labelTool5.InstanceProps.IsFirstInGroup = true;
            textBoxTool1.InstanceProps.Width = 127;
            labelTool6.InstanceProps.IsFirstInGroup = true;
            comboBoxTool2.InstanceProps.Width = 133;
            ultraToolbar3.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            labelTool4,
            labelTool5,
            textBoxTool1,
            labelTool6,
            comboBoxTool1,
            comboBoxTool2,
            buttonTool2});
            appearance9.FontData.SizeInPoints = 9F;
            ultraToolbar3.Settings.Appearance = appearance9;
            ultraToolbar3.Text = "検索";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2,
            ultraToolbar3});
            popupMenuTool3.Settings.IsSideStripVisible = Infragistics.Win.DefaultableBoolean.False;
            popupMenuTool3.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool3.SharedProps.ShowInCustomizer = false;
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3});
            popupMenuTool4.SharedProps.Caption = "ウィンドウ(&W)";
            popupMenuTool4.SharedProps.ShowInCustomizer = false;
            buttonTool4.InstanceProps.IsFirstInGroup = true;
            buttonTool8.InstanceProps.IsFirstInGroup = true;
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8});
            buttonTool9.SharedProps.Caption = "終了(&X)";
            buttonTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool9.SharedProps.ShowInCustomizer = false;
            buttonTool9.SharedProps.ToolTipText = "終了";
            appearance10.TextHAlignAsString = "Right";
            appearance10.TextVAlignAsString = "Middle";
            labelTool7.SharedProps.AppearancesSmall.Appearance = appearance10;
            labelTool7.SharedProps.Caption = "ログイン担当者";
            labelTool7.SharedProps.ShowInCustomizer = false;
            appearance11.BackColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            labelTool8.SharedProps.AppearancesSmall.Appearance = appearance11;
            labelTool8.SharedProps.Caption = "翼　太郎";
            labelTool8.SharedProps.ShowInCustomizer = false;
            labelTool8.SharedProps.Width = 150;
            buttonTool10.SharedProps.Caption = "すべてを表示(&S)";
            buttonTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool10.SharedProps.Enabled = false;
            buttonTool10.SharedProps.Visible = false;
            buttonTool11.SharedProps.Caption = "すべてを非表示(&H)";
            buttonTool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool11.SharedProps.Enabled = false;
            buttonTool11.SharedProps.Visible = false;
            buttonTool12.SharedProps.Caption = "すべてのプッシュピンを設定(&P)";
            buttonTool12.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool12.SharedProps.Enabled = false;
            buttonTool12.SharedProps.Visible = false;
            buttonTool13.SharedProps.Caption = "すべてのプッシュピンを解除(&U)";
            buttonTool13.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool13.SharedProps.Enabled = false;
            buttonTool13.SharedProps.Visible = false;
            buttonTool14.SharedProps.Caption = "ウィンドウを初期状態に戻す(&R)";
            appearance12.TextHAlignAsString = "Right";
            appearance12.TextVAlignAsString = "Middle";
            labelTool9.SharedProps.AppearancesSmall.Appearance = appearance12;
            labelTool9.SharedProps.Caption = "検索";
            labelTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool9.SharedProps.ShowInCustomizer = false;
            textBoxTool2.SharedProps.Caption = "SearchItem_TextBox";
            textBoxTool2.SharedProps.ShowInCustomizer = false;
            textBoxTool2.SharedProps.ToolTipText = "検索する文字列";
            appearance13.TextHAlignAsString = "Center";
            labelTool10.SharedProps.AppearancesSmall.Appearance = appearance13;
            labelTool10.SharedProps.Caption = "検索する文字列";
            labelTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool10.SharedProps.ShowInCustomizer = false;
            labelTool10.SharedProps.Spring = true;
            appearance14.TextHAlignAsString = "Center";
            labelTool11.SharedProps.AppearancesSmall.Appearance = appearance14;
            labelTool11.SharedProps.Caption = "探す場所";
            labelTool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool11.SharedProps.ShowInCustomizer = false;
            comboBoxTool3.SharedProps.Caption = "SearchPosition_ComboBox";
            comboBoxTool3.SharedProps.ShowInCustomizer = false;
            comboBoxTool3.SharedProps.ToolTipText = "探す場所（列）";
            comboBoxTool3.ValueList = valueList1;
            buttonTool15.SharedProps.Caption = "検索開始(&S)";
            buttonTool15.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool15.SharedProps.ShowInCustomizer = false;
            labelTool12.SharedProps.ShowInCustomizer = false;
            labelTool12.SharedProps.Spring = true;
            labelTool12.SharedProps.Width = 0;
            comboBoxTool4.SharedProps.Caption = "SearchPosition2_ComboBox";
            comboBoxTool4.SharedProps.ShowInCustomizer = false;
            comboBoxTool4.SharedProps.ToolTipText = "探す場所（データ）";
            comboBoxTool4.ValueList = valueList2;
            stateButtonTool1.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            stateButtonTool1.OptionSetKey = "WindowStyle";
            stateButtonTool1.SharedProps.Caption = "Office2003スタイル";
            stateButtonTool2.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            stateButtonTool2.OptionSetKey = "WindowStyle";
            stateButtonTool2.SharedProps.Caption = "VisualStudio2005スタイル";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool3,
            popupMenuTool4,
            buttonTool9,
            labelTool7,
            labelTool8,
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            buttonTool14,
            labelTool9,
            textBoxTool2,
            labelTool10,
            labelTool11,
            comboBoxTool3,
            buttonTool15,
            labelTool12,
            comboBoxTool4,
            stateButtonTool1,
            stateButtonTool2});
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            this.ultraToolbarsManager1.AfterToolCloseup += new Infragistics.Win.UltraWinToolbars.ToolDropdownEventHandler(this.ultraToolbarsManager1_AfterToolCloseup);
            // 
            // _ALPK000001VMAC_Toolbars_Dock_Area_Right
            // 
            this._ALPK000001VMAC_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ALPK000001VMAC_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._ALPK000001VMAC_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._ALPK000001VMAC_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ALPK000001VMAC_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 56);
            this._ALPK000001VMAC_Toolbars_Dock_Area_Right.Name = "_ALPK000001VMAC_Toolbars_Dock_Area_Right";
            this._ALPK000001VMAC_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 655);
            this._ALPK000001VMAC_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ALPK000001VMAC_Toolbars_Dock_Area_Top
            // 
            this._ALPK000001VMAC_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ALPK000001VMAC_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._ALPK000001VMAC_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._ALPK000001VMAC_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ALPK000001VMAC_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._ALPK000001VMAC_Toolbars_Dock_Area_Top.Name = "_ALPK000001VMAC_Toolbars_Dock_Area_Top";
            this._ALPK000001VMAC_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 56);
            this._ALPK000001VMAC_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ALPK000001VMAC_Toolbars_Dock_Area_Bottom
            // 
            this._ALPK000001VMAC_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ALPK000001VMAC_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._ALPK000001VMAC_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._ALPK000001VMAC_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ALPK000001VMAC_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 711);
            this._ALPK000001VMAC_Toolbars_Dock_Area_Bottom.Name = "_ALPK000001VMAC_Toolbars_Dock_Area_Bottom";
            this._ALPK000001VMAC_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._ALPK000001VMAC_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // PMKHN09760UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this._ALPK000001VMACAutoHideControl);
            this.Controls.Add(this.windowDockingArea2);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this._ALPK000001VMACUnpinnedTabAreaTop);
            this.Controls.Add(this._ALPK000001VMACUnpinnedTabAreaBottom);
            this.Controls.Add(this._ALPK000001VMACUnpinnedTabAreaRight);
            this.Controls.Add(this._ALPK000001VMACUnpinnedTabAreaLeft);
            this.Controls.Add(this._ALPK000001VMAC_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._ALPK000001VMAC_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._ALPK000001VMAC_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._ALPK000001VMAC_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.MainStatusBar);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09760UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "マスタメンテナンス";
            this.Load += new System.EventHandler(this.PMKHN09760UA_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09760UA_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMKHN09760UA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewTabControl)).EndInit();
            this.DataViewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).EndInit();
            this.windowDockingArea1.ResumeLayout(false);
            this.dockableWindow2.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.windowDockingArea2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private Point _lastMouseDown;
		private Hashtable _programTable;
		private Hashtable _instanceTable;
		private Hashtable _constructionTable;
		private ArrayList _constructionList;
		private MemoryStream _dockMemoryStream;
		private string _constructionFilePath;
		private static string[] _parameter;
		private static System.Windows.Forms.Form _form = null;
		private ControlScreenSkin _controlScreenSkin;

		private const string NAVIGATORTREE_DAT = "PMKHN09760U_Navigator.DAT";
		private const string XML_FILE_NAME = "PMKHN09760U_Construction.XML";
		private const string MAIN_TITLE = "マスタメンテナンス";
        #region 
        /// <summary>
        /// 拠点情報
        /// </summary>
        private const string DATAKEY_KYOTEN = "SFKTN09000U.DLL";
        /// <summary>
        /// 従業員情報
        /// </summary>
        private const string DATAKEY_JUGYOIN = "SFTOK09380U.DLL";
        /// <summary>
        /// BLコード設定情報
        /// </summary>
        private const string DATAKEY_BLCODESETTEI = "DCKHN09090U.DLL";
        /// <summary>
        /// 売上全体設定
        /// </summary>
        private const string DATAKEY_URIAGEZENTAISETTEI = "DCKHN09210U.DLL";
        /// <summary>
        /// 売上金額処理区分設定
        /// </summary>
        private const string DATAKEY_URIAGEKINGAKUSYORIKUBUN = "DCHNB09110U.DLL";
        /// <summary>
        /// 税率設定情報
        /// </summary>
        private const string DATAKEY_ZEIRITUSETTEI = "SFUKK09000U.DLL";
        /// <summary>
        /// ユーザーガイド
        /// </summary>
        private const string DATAKEY_YUUZAGAIDO = "SFCMN09060U.DLL";
        /// <summary>
        /// 備考ガイド
        /// </summary>
        private const string DATAKEY_BIKOUGAIDO = "SFTOK09400U.DLL";
        /// <summary>
        /// SCM納期設定
        /// </summary>
        private const string DATAKEY_SCMNOUKISETTEI = "PMSCM09030U.DLL";
        /// <summary>
        /// ロールグループ名称設定
        /// </summary>
        private const string DATAKEY_ROLEGROUPMEISYOU = "PMKHN09721U.DLL";
        /// <summary>
        /// ロールグループ権限設定
        /// </summary>
        private const string DATAKEY_ROLEGROUPKENGEN = "PMKHN09730U.DLL";
        /// <summary>
        /// 従業員ロール設定
        /// </summary>
        private const string DATAKEY_JYUGYOINROLE = "PMKHN09741U.DLL";
        /// <summary>
        /// 全体初期値設定マスタ
        /// </summary>
        private const string DATAKEY_ZENTAISYOKITI = "SFCMN09080U.DLL";

        /// <summary>
        /// ステータスバーのパネルリストのキー　メッセージ部分
        /// </summary>
        private const string MAINSTATUSBAR_PANELS_KEY_MSG = "Msg";
        #endregion

		#endregion

		# region Main
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(String[] args) 
		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				string msg = "";
				_parameter = args;

				LogWrt(0, "------------------ マスタメンテナンスフォームロード処理開始 ------------------");
				// アプリケーション開始準備処理
				// 第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
				int status = ApplicationStartControl.StartApplication(
					out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

				if (status == 0)
				{
					// オンライン状態判断
					if (!LoginInfoAcquisition.OnlineFlag)
					{
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN09760U",
							"オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
					}
					else
					{
						_form = new PMKHN09760UA();
						System.Windows.Forms.Application.Run(_form);
					}
				}
				else
				{
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN09760U", msg, 0, MessageBoxButtons.OK);
				}
			}
			catch(Exception ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,"PMKHN09760U",ex.Message,0,MessageBoxButtons.OK);
			}
			finally
			{
				ApplicationStartControl.EndApplication();
			}
		}

		/// <summary>
		/// アプリケーション終了イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">メッセージ</param>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
			//メッセージを出す前に全て開放
			ApplicationStartControl.EndApplication();
			//従業員ログオフのメッセージを表示
			if (_form != null)	TMsgDisp.Show(_form.Owner,	emErrorLevel.ERR_LEVEL_INFO,"PMKHN09760U",e.ToString(),0,MessageBoxButtons.OK);
			else				TMsgDisp.Show(				emErrorLevel.ERR_LEVEL_INFO,"PMKHN09760U",e.ToString(),0,MessageBoxButtons.OK);
			//アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}
		# endregion

		# region Internal Methods
		/// <summary>
		/// ツリーノードチェックボックスチェック処理
		/// </summary>
		/// <param name="viewForm">マスタメンテナンスのインスタンス</param>
		/// <remarks>
		/// <br>Note       : ツリーノードのチェックボックスにチェックを付けます</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		internal void TreeNodeCheckBoxChecked(object viewForm)
		{
			string key = this._instanceTable[viewForm].ToString();

			ProgramItem program = this._programTable[key] as ProgramItem;
			if (program == null)
			{
				return;
			}

			Infragistics.Win.UltraWinTree.UltraTreeNode utn = this.StartNavigatorTree.GetNodeByKey(key);

			if (utn != null)
			{
				program.Condition = ProgramCondition.Checked;
				utn.CheckedState = CheckState.Checked;
			}
		}

		/// <summary>
		/// マスタメンテナンス設定クラステーブル追加処理
		/// </summary>
		/// <param name="key">キー</param>
		/// <param name="construction">マスタメンテナンス設定クラス</param>
		/// <remarks>
		/// <br>Note       : マスタメンテナンスの設定ファイルを保存します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		internal void ConstructionTableAdd(string key, MasterMaintenanceConstruction construction)
		{
			if (this._constructionTable.Contains(key) == true)
			{
				this._constructionTable.Remove(key);
			}

			if (this._constructionList.Contains(key) == false)
			{
				this._constructionList.Add(key);
			}

			this._constructionTable.Add(key, construction);
		}

		/// <summary>
		/// マスタメンテナンス設定クラステーブル取得処理
		/// </summary>
		/// <param name="key">キー</param>
		/// <remarks>
		/// <br>Note       : マスタメンテナンスの設定ファイルを保存します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		internal MasterMaintenanceConstruction GetConstructionTable(string key)
		{
			if (this._constructionTable.Contains(key) == true)
			{
				return (MasterMaintenanceConstruction)this._constructionTable[key];
			}
			else
			{
				return new MasterMaintenanceConstruction(key);
			}
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// 画面非表示イベント用メソッド
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="me">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note       : マスタメンテナンスシングルレコードタイプの画面非表示イベント用メソッドです。
		///					 View用HTMLの再表示と、ツリーチェックボックスのチェック処理を実行します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void MasterMaintenanceSingleType_UnDisplaying(object sender, MasterMaintenanceUnDisplayingEventArgs me)
		{
			ProgramItem program = this._programTable[this._instanceTable[sender]] as ProgramItem;
			if (program == null)
			{
				return;
			}

			if (program.Pattern != ProgramPattern.Single)
			{
				return;
			}

			// 引数のDialogResultがOKまたはYesの場合は、ノードのチェックボックスに
			// チェックを付ける
			if ((me.DialogResult == DialogResult.OK) || (me.DialogResult == DialogResult.Yes))
			{
				string key = this._instanceTable[sender].ToString();
				Infragistics.Win.UltraWinTree.UltraTreeNode utn = this.StartNavigatorTree.GetNodeByKey(key);

				if (utn != null)
				{
					program.Condition = ProgramCondition.Checked;
					utn.CheckedState = CheckState.Checked;
				}

				IMasterMaintenanceSingleType singleType = (IMasterMaintenanceSingleType)program.Object;

				// HTMLによるビュー表示を更新する
				string htmlCode = singleType.GetHtmlCode();

				Infragistics.Win.UltraWinTabControl.UltraTab selectedTab = this.DataViewTabControl.Tabs[key];
				((PMKHN09760UB)selectedTab.Tag).WebBrowserWrite(htmlCode);
			}
		}

		/// <summary>
		/// 閉じるボタンクリック時実行処理 
		/// </summary>
		/// <param name="sender">単票表示、一覧表示フォームクラスのインスタンス</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note       : 単票表示、一覧表示フォームオブジェクトにて閉じるボタンがクリック
		///					 された際に実行されます。
		///					 各マスタメンテナンスのインスタンスを破棄し、ビュー用のタブを削除
		///					 します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void ViewForm_Closed(object sender, EventArgs e)
		{
			ProgramItem program = this._programTable[this._instanceTable[sender]] as ProgramItem;
			if (program == null)
			{
				return;
			}

			Infragistics.Win.UltraWinTabControl.UltraTab tb = this.DataViewTabControl.Tabs[program.Key];
			if (tb == null)
			{
				return;
			}

			Infragistics.Win.UltraWinTree.UltraTreeNode utn = this.StartNavigatorTree.GetNodeByKey(tb.Key);
			if (utn == null)
			{
				return;
			}

			// ツリーのノードを初期状態に戻す
			utn.Override.NodeAppearance.ForeColor = Color.Blue;
			program.Condition = ProgramCondition.UnChecked;
			utn.CheckedState = CheckState.Unchecked;
			this.DataViewTabControl.Tabs.Remove(tb);
		}

		/// <summary>
		/// ツリー情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツリー情報を構築します。
		///					（２階層目の表示非表示チェック、３階層目のカラー設定）</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void TreeNodeConstruction()
		{
			this.StartNavigatorTree.Appearance.BackColor = Color.White;
			this.StartNavigatorTree.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(222)), ((System.Byte)(239)), ((System.Byte)(255)));
			this.StartNavigatorTree.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.StartNavigatorTree.HideSelection = false;
			bool firstNode = true;

			// ================================================================================= //
			// ノードの表示非表示を制御する
			// ================================================================================= //
			if (_parameter.Length != 0)
			{
				// 選択ノードを先頭に移動させる
				firstNode = this.StartNavigatorTree.PerformAction(
					Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode, 
					false,
					false);

				if (!firstNode)
				{
					return;
				}
			
				foreach(Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
				{
					if (utn1.Nodes.Count != 0)
					{
						foreach(Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
						{
							if (utn2.Nodes.Count != 0)
							{
								foreach(Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
								{
                                    utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;

									bool nodeVisible = false;
									string productCodes = "";
									if (utn3.Override.NodeAppearance.Tag != null)
									{
										productCodes = utn3.Override.NodeAppearance.Tag.ToString();
									}

									string[] split = productCodes.Split(new Char [] {' '});

									if (productCodes == "")
									{
										// システムやオプションの設定が存在しない場合は無条件で表示する
										nodeVisible = true;
									}
									else
									{
										bool optionFlg = false;

										// ソフトウェアコード（サブシステムレベル）とソフトウェアコード（オプションレベル）をチェック
										foreach (string productCode in split)
										{
											if ((productCode != null) && (productCode.Trim() != ""))
											{
												if (!this.IsSoftwareCode_PAC(productCode))
												{
													if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(productCode) > 0)
													{
														optionFlg = true;
														nodeVisible = true;
														break;
													}
												}
											}
										}

										if (!optionFlg)
										{
											foreach (string productCode in split)
											{
												if ((productCode != null) && (productCode.Trim() != ""))
												{
													if (this.IsSoftwareCode_PAC(productCode))
													{
														if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(productCode) > 0)
														{
															nodeVisible = true;
															break;
														}
													}
												}
											}
										}
									}

									utn3.Visible = nodeVisible;
								}
							}
						}
					}
				}
			}

			// ================================================================================= //
			// グループの表示非表示を制御する
			// ================================================================================= //
			// 選択ノードを先頭に移動させる
			firstNode = this.StartNavigatorTree.PerformAction(
				Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode, 
				false,
				false);

			if (!firstNode)
			{
				return;
			}
			
			foreach(Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
			{
				if (utn1.Nodes.Count != 0)
				{
					utn1.Expanded = true;

					foreach(Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
					{
						bool utn2DeleteFlg = true;

						// パラメータが空白の場合は全ノードを表示する（デリバリ時には非表示とする）
						if (_parameter.Length == 0)
						{
							utn2DeleteFlg = false;
						}
						else
						{
							// Key値がnullの場合は非表示とする
							if (utn2.Key != null)
							{
								for (int i = 0; i < _parameter.Length; i++)
								{
									if (utn2.Key.ToString() == PMKHN09760UA._parameter[i])
									{
										utn2DeleteFlg = false;
										break;
									}
								}
							}
						}

						if (utn2DeleteFlg == true)
						{
							utn2.Visible = false;
						}
						else
						{
							if (utn2.Nodes.Count != 0)
							{
								// パラメータが空白以外場合はノードを展開する
								if (_parameter.Length != 0)
								{
									utn2.Expanded = true;
								}

								foreach(Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
								{
									utn3.Override.NodeAppearance.ForeColor = Color.Blue;
								}
							}
                            if ( visibleRootNode == null )
                            {
                                // 表示される1つ目のnodeをセット
                                visibleRootNode = utn2;
                            }
						}
					}
				}
			}
		}

        Infragistics.Win.UltraWinTree.UltraTreeNode visibleRootNode = null;

		/// <summary>
		/// プログラム情報コレクションクラス構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 全てのノードを検索し、プログラム情報コレクションクラスに格納します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void ProgramCollectionCreate()
		{
			// 選択ノードを先頭に移動させる
			bool result = this.StartNavigatorTree.PerformAction(
								Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode, 
								false,
								false);

			if (!result)
			{
				return;
			}
			
			// ツリーのノード情報を元に、プログラム情報コレクションクラスを構築する

			// ツリーのノードより取得する情報は以下の通り
			// [DataKey:アセンブリ名称]
			// [Tag:クラス厳密名]
			// [Text:プログラム名称]
			// [Tag:プログラムパターン]
			foreach(Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
			{
				if (utn1.Nodes.Count != 0)
				{
					foreach(Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
					{
						if (utn2.Nodes.Count != 0)
						{
							foreach(Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
							{
                                utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;

								// プログラムＩＤとコンストラクタのパラメータを取得する
								string[] split = utn3.DataKey.ToString().Split(new Char [] {' '});
								string assemblyID = "";
								string arguments = "";
								if (split.Length == 0)
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_STOPDISP,
										this.Name,
										"プログラムＩＤが設定されていません。",
										-1,
										MessageBoxButtons.OK);

									return;
								}
								else
								{
									if (split.Length >= 1)
									{
										assemblyID = split[0].ToString();
									}
									if (split.Length >= 2)
									{
										arguments = split[1].ToString();
									}
								}

								Guid guid = Guid.NewGuid();
								ProgramItem program = new ProgramItem(guid.ToString(),
									assemblyID,
									utn3.Tag.ToString(),
									utn3.Text,
									ProgramPattern.None,
									arguments);


								this._programTable.Add(guid.ToString(), program);

								utn3.Key = guid.ToString();
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// ウィンドウスタイル変更処理
		/// </summary>
		/// <param name="displayStyle">ウィンドウスタイル</param>
		/// <remarks>
		/// <br>Note       : ウィンドウスタイルを変更します。要変更</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void WindowStyleChange(Infragistics.Win.EmbeddableElementDisplayStyle displayStyle)
		{
			
		}

		/// <summary>
		/// マルチタイプ用検索場所コンボボックス構築処理
		/// </summary>
		/// <param name="list">検索場所コンボボックス格納リスト</param>
		/// <remarks>
		/// <br>Note       : 現在表示されているView用グリッドの列のタイトルを
		///					 検索場所コンボボックスに格納します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void SearchComboBoxConstructMultiType(ArrayList list)
		{
			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition_ComboBox"]).ValueList = null;

			Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList(0);
			Infragistics.Win.ValueListItem valueListItem;

			// "全ての列"を最初に追加する
			valueListItem = new Infragistics.Win.ValueListItem();
			valueListItem.DataValue = "全ての列";
			valueList.ValueListItems.Add(valueListItem);
			
			foreach(string s in list)
			{
				valueListItem = new Infragistics.Win.ValueListItem();
				valueListItem.DataValue = s;
				valueList.ValueListItems.Add(valueListItem);
			}

			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition_ComboBox"]).ValueList = valueList;
			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition_ComboBox"]).SelectedIndex = 0;
		}

		/// <summary>
		/// 配列タイプ用検索場所コンボボックス構築処理
		/// </summary>
		/// <param name="dataList">検索場所コンボボックス格納リスト</param>
		/// <param name="colList1">列コンボボックス格納リスト1</param>
		/// <param name="colList2">列コンボボックス格納リスト2</param>
		/// <param name="name">検索場所コンボボックス格納リスト名称</param>
		/// <remarks>
		/// <br>Note       : 現在表示されているView用グリッドの列のタイトルを
		///					 検索場所コンボボックスに格納します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void SearchComboBoxConstructArrayType(ArrayList dataList, ArrayList colList1, ArrayList colList2, string name)
		{
			Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
			Infragistics.Win.ValueListItem valueListItem;
			ArrayList list = new ArrayList();

			if (name == "")
			{
				// データ用の検索コンボボックス
				((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"]).ValueList = null;

				foreach(string s in dataList)
				{
					valueListItem = new Infragistics.Win.ValueListItem();
					valueListItem.DataValue = s;
					valueList1.ValueListItems.Add(valueListItem);
				}

				((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"]).ValueList = valueList1;
				((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"]).SelectedIndex = 0;

				list = colList1;
			}
			else
			{
				int index = dataList.IndexOf(name);

				if (index == 0)
				{
					list = colList1;
				}
				else
				{
					list = colList2;
				}
			}

			// 列用の検索コンボボックス
			Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(0);
			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition_ComboBox"]).ValueList = null;

			valueListItem = new Infragistics.Win.ValueListItem();
			valueListItem.DataValue = "全ての列";
			valueList2.ValueListItems.Add(valueListItem);
			
			foreach(string s in list)
			{
				valueListItem = new Infragistics.Win.ValueListItem();
				valueListItem.DataValue = s;
				valueList2.ValueListItems.Add(valueListItem);
			}

			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition_ComboBox"]).ValueList = valueList2;
			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition_ComboBox"]).SelectedIndex = 0;
		}

		/// <summary>
		/// 配列タイプ用検索場所コンボボックス構築処理
		/// </summary>
		/// <param name="dataList">検索場所コンボボックス格納リスト</param>
		/// <param name="colList1">列コンボボックス格納リスト1</param>
		/// <param name="colList2">列コンボボックス格納リスト2</param>
		/// <param name="colList3">列コンボボックス格納リスト3</param>
		/// <param name="name">検索場所コンボボックス格納リスト名称</param>
		/// <remarks>
		/// <br>Note       : 現在表示されているView用グリッドの列のタイトルを
		///					 検索場所コンボボックスに格納します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void SearchComboBoxConstructThreeArrayType(ArrayList dataList, ArrayList colList1, ArrayList colList2, ArrayList colList3, string name)
		{
			Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
			Infragistics.Win.ValueListItem valueListItem;
			ArrayList list = new ArrayList();

			if (name == "")
			{
				// データ用の検索コンボボックス
				((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"]).ValueList = null;

				foreach(string s in dataList)
				{
					valueListItem = new Infragistics.Win.ValueListItem();
					valueListItem.DataValue = s;
					valueList1.ValueListItems.Add(valueListItem);
				}

				((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"]).ValueList = valueList1;
				((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"]).SelectedIndex = 0;

				list = colList1;
			}
			else
			{
				int index = dataList.IndexOf(name);

				switch (index)
				{
					case (0):
					{
						list = colList1;
						break;
					}
					case (1):
					{
						list = colList2;
						break;
					}
					default:
					{
						list = colList3;
						break;
					}
				}
			}

			// 列用の検索コンボボックス
			Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(0);
			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition_ComboBox"]).ValueList = null;

			valueListItem = new Infragistics.Win.ValueListItem();
			valueListItem.DataValue = "全ての列";
			valueList2.ValueListItems.Add(valueListItem);
			
			foreach(string s in list)
			{
				valueListItem = new Infragistics.Win.ValueListItem();
				valueListItem.DataValue = s;
				valueList2.ValueListItems.Add(valueListItem);
			}

			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition_ComboBox"]).ValueList = valueList2;
			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition_ComboBox"]).SelectedIndex = 0;
		}

		/// <summary>
		/// 配列タイプ用検索場所コンボボックス構築処理
		/// </summary>
		/// <param name="dataList">検索場所コンボボックス格納リスト</param>
		/// <param name="colList1">列コンボボックス格納リスト1</param>
		/// <param name="colList2">列コンボボックス格納リスト2</param>
		/// <param name="colList3">列コンボボックス格納リスト3</param>
		/// <param name="colList4">列コンボボックス格納リスト4</param>
		/// <param name="name">検索場所コンボボックス格納リスト名称</param>
		/// <remarks>
		/// <br>Note       : 現在表示されているView用グリッドの列のタイトルを
		///					 検索場所コンボボックスに格納します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void SearchComboBoxConstructFourArrayType(ArrayList dataList, ArrayList colList1, ArrayList colList2, ArrayList colList3, ArrayList colList4, string name)
		{
			Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
			Infragistics.Win.ValueListItem valueListItem;
			ArrayList list = new ArrayList();

			if (name == "")
			{
				// データ用の検索コンボボックス
				((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"]).ValueList = null;

				foreach(string s in dataList)
				{
					valueListItem = new Infragistics.Win.ValueListItem();
					valueListItem.DataValue = s;
					valueList1.ValueListItems.Add(valueListItem);
				}

				((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"]).ValueList = valueList1;
				((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"]).SelectedIndex = 0;

				list = colList1;
			}
			else
			{
				int index = dataList.IndexOf(name);

				switch (index)
				{
					case (0):
					{
						list = colList1;
						break;
					}
					case (1):
					{
						list = colList2;
						break;
					}
					case (2):
					{
						list = colList3;
						break;
					}
					default:
					{
						list = colList4;
						break;
					}
				}
			}

			// 列用の検索コンボボックス
			Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(0);
			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition_ComboBox"]).ValueList = null;

			valueListItem = new Infragistics.Win.ValueListItem();
			valueListItem.DataValue = "全ての列";
			valueList2.ValueListItems.Add(valueListItem);
			
			foreach(string s in list)
			{
				valueListItem = new Infragistics.Win.ValueListItem();
				valueListItem.DataValue = s;
				valueList2.ValueListItems.Add(valueListItem);
			}

			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition_ComboBox"]).ValueList = valueList2;
			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition_ComboBox"]).SelectedIndex = 0;
		}

		/// <summary>
		/// グリッドテキスト検索処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : グリッドのテキスト検索を実行します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void GridTextSearchExecution()
		{
			ProgramItem program = this._programTable[this.DataViewTabControl.SelectedTab.Key.ToString()] as ProgramItem;
			if (program == null)
			{
				return;
			}

			string columnKey = 
				((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition_ComboBox"]).SelectedItem.ToString();
					
			string searchString =
				((Infragistics.Win.UltraWinToolbars.TextBoxTool)this.ultraToolbarsManager1.Tools["SearchItem_TextBox"]).Text;

			if (searchString == "")
			{
				return;
			}
			
			switch (program.Pattern)
			{
				case ProgramPattern.Single:
				{
					break;
				}
				case ProgramPattern.Multi:
				{
					PMKHN09760UC viewForm = (PMKHN09760UC)program.ViewForm;
					
					viewForm.GridTextSearch(columnKey, searchString);

					break;
				}
				case ProgramPattern.Array:
				{
					PMKHN09760UE viewForm = (PMKHN09760UE)program.ViewForm;
					
					viewForm.GridTextSearch(columnKey, searchString, ((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"]).SelectedItem.ToString());

					break;
				}
				case ProgramPattern.ThreeArray:
				{
					PMKHN09760UG viewForm = (PMKHN09760UG)program.ViewForm;
					
					viewForm.GridTextSearch(columnKey, searchString, ((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"]).SelectedItem.ToString());

					break;
				}
				case ProgramPattern.FourArray:
				{
					PMKHN09760UJ viewForm = (PMKHN09760UJ)program.ViewForm;
					
					viewForm.GridTextSearch(columnKey, searchString, ((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"]).SelectedItem.ToString());

					break;
				}
				default:
				{
					break;
				}
			}
		}

		/// <summary>
		/// 選択タブ変更時ツリーノード選択処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : タブが変更された場合に、変更されたタブに関連付け
		///					 られたツリーノードを選択します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void SelectedTabChangedNodeSelect()
		{
			Infragistics.Win.UltraWinTabControl.UltraTab tb = this.DataViewTabControl.SelectedTab;
			if (tb == null)
			{
				return;
			}

			Infragistics.Win.UltraWinTree.UltraTreeNode utn = this.StartNavigatorTree.GetNodeByKey(tb.Key);
            if (utn == null)
            {
                return;
            }
            else
            {
                // オプションチェック
                Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
                ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BasicTablet);
                if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                {
                    // オプションのタブレットが有効の場合
                    if (utn.DataKey.ToString().Equals(DATAKEY_KYOTEN)
                        || utn.DataKey.ToString().Equals(DATAKEY_JUGYOIN)
                        || utn.DataKey.ToString().Equals(DATAKEY_BLCODESETTEI)
                        || utn.DataKey.ToString().Equals(DATAKEY_URIAGEZENTAISETTEI)
                        || utn.DataKey.ToString().Equals(DATAKEY_URIAGEKINGAKUSYORIKUBUN)
                        || utn.DataKey.ToString().Equals(DATAKEY_ZEIRITUSETTEI)
                        || utn.DataKey.ToString().Equals(DATAKEY_YUUZAGAIDO)
                        || utn.DataKey.ToString().Equals(DATAKEY_BIKOUGAIDO)
                        || utn.DataKey.ToString().Equals(DATAKEY_SCMNOUKISETTEI)
                        || utn.DataKey.ToString().Equals(DATAKEY_ROLEGROUPMEISYOU)
                        || utn.DataKey.ToString().Equals(DATAKEY_ROLEGROUPKENGEN)
                        || utn.DataKey.ToString().Equals(DATAKEY_JYUGYOINROLE)
                        || utn.DataKey.ToString().Equals(DATAKEY_ZENTAISYOKITI)
                        )
                    {
                        MainStatusBar.Panels[MAINSTATUSBAR_PANELS_KEY_MSG].Visible = true;
                    }
                    else
                    {
                        MainStatusBar.Panels[MAINSTATUSBAR_PANELS_KEY_MSG].Visible = false;
                    }
                }
            }

			this.StartNavigatorTree.ActiveNode = utn;

			bool result;

			result = this.StartNavigatorTree.PerformAction(
						Infragistics.Win.UltraWinTree.UltraTreeAction.ClearAllSelectedNodes,
						false,
						false);
			if (!result)
			{
				return;
			}

			result = this.StartNavigatorTree.PerformAction(
						Infragistics.Win.UltraWinTree.UltraTreeAction.SelectActiveNode, 
						false,
						false);
			if (!result)
			{
				return;
			}
		}

		/// <summary>
		/// 選択タブ変更時ツールバー再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : タブが変更された場合に、表示中のビュー画面に
		///					 合わせてツールバーの表示を再構築します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void SelectedTabChangedToolBarReconstruction()
		{
			((Infragistics.Win.UltraWinToolbars.TextBoxTool)this.ultraToolbarsManager1.Tools["SearchItem_TextBox"]).Text = "";
			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.ultraToolbarsManager1.Tools["SearchPosition_ComboBox"]).Text = "";

			if (this.DataViewTabControl.SelectedTab == null)
			{
				// 検索用ツールバーを無効とする
				for (int i = 0; i < this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools.Count; i++)
				{
					this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools[i].SharedProps.Enabled = false;
				}
				this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"].SharedProps.Visible = false;

				return;
			}

			ProgramItem program = this._programTable[this.DataViewTabControl.SelectedTab.Key.ToString()] as ProgramItem;
			if (program == null)
			{
				return;
			}

			switch (program.Pattern)
			{
				case ProgramPattern.Single:
				{
					// 検索用ツールバーを無効とする
					for (int i = 0; i < this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools.Count; i++)
					{
						this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools[i].SharedProps.Enabled = false;
					}
					this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"].SharedProps.Visible = false;

					break;
				}
				case ProgramPattern.Multi:
				{

					// 検索用ツールバーを有効とする
					for (int i = 0; i < this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools.Count; i++)
					{
						this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools[i].SharedProps.Enabled = true;
					}
					this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"].SharedProps.Visible = false;

					if (program.ViewForm == null)
					{
						return;
					}

					PMKHN09760UC viewForm = (PMKHN09760UC)program.ViewForm;

					// 検索場所コンボボックス構築処理
					ArrayList list = viewForm.GetColKeyList();
					SearchComboBoxConstructMultiType(list);

					break;
				}
				case ProgramPattern.Array:
				{

					// 検索用ツールバーを有効とする
					for (int i = 0; i < this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools.Count; i++)
					{
						this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools[i].SharedProps.Enabled = true;
					}
					this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"].SharedProps.Visible = true;

					if (program.ViewForm == null)
					{
						return;
					}

					PMKHN09760UE viewForm = (PMKHN09760UE)program.ViewForm;

					// 検索場所コンボボックス構築処理
					ArrayList dataList;
					ArrayList colList1;
					ArrayList colList2;

					viewForm.GetColKeyList(out dataList, out colList1, out colList2);
					SearchComboBoxConstructArrayType(dataList, colList1, colList2, "");

					break;
				}
				case ProgramPattern.ThreeArray:
				{

					// 検索用ツールバーを有効とする
					for (int i = 0; i < this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools.Count; i++)
					{
						this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools[i].SharedProps.Enabled = true;
					}
					this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"].SharedProps.Visible = true;

					if (program.ViewForm == null)
					{
						return;
					}

					PMKHN09760UG viewForm = (PMKHN09760UG)program.ViewForm;

					// 検索場所コンボボックス構築処理
					ArrayList dataList;
					ArrayList colList1;
					ArrayList colList2;
					ArrayList colList3;

					viewForm.GetColKeyList(out dataList, out colList1, out colList2, out colList3);
					SearchComboBoxConstructThreeArrayType(dataList, colList1, colList2, colList3, "");

					break;
				}
				case ProgramPattern.FourArray:
				{
					// 検索用ツールバーを有効とする
					for (int i = 0; i < this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools.Count; i++)
					{
						this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools[i].SharedProps.Enabled = true;
					}
					this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"].SharedProps.Visible = true;

					if (program.ViewForm == null)
					{
						return;
					}

					PMKHN09760UJ viewForm = (PMKHN09760UJ)program.ViewForm;

					// 検索場所コンボボックス構築処理
					ArrayList dataList;
					ArrayList colList1;
					ArrayList colList2;
					ArrayList colList3;
					ArrayList colList4;

					viewForm.GetColKeyList(out dataList, out colList1, out colList2, out colList3, out colList4);
					SearchComboBoxConstructFourArrayType(dataList, colList1, colList2, colList3, colList4, "");

					break;
				}
				default:
				{
					// 検索用ツールバーを無効とする
					for (int i = 0; i < this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools.Count; i++)
					{
						this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools[i].SharedProps.Enabled = false;
					}
					this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"].SharedProps.Visible = false;

					break;
				}
			}
		}

		/// <summary>
		/// ビューフォームインスタンス破棄処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : インスタンス化されているビューフォームを破棄</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void ViewFormInstanceDispose()
		{
			if (this.DataViewTabControl.Tabs.Count == 0)
			{
				return;
			}

			for (int i = 0; i < this.DataViewTabControl.Tabs.Count; i++)
			{
				ProgramItem program = this._programTable[this.DataViewTabControl.Tabs[i].Key.ToString()] as ProgramItem;
				if (program == null)
				{
					return;
				}

				switch (program.Pattern)
				{
					case ProgramPattern.Single:
					{
						PMKHN09760UB viewForm = (PMKHN09760UB)program.ViewForm;
						viewForm.Close_Button_Click(this, null);

						break;
					}
					case ProgramPattern.Multi:
					{
						PMKHN09760UC viewForm = (PMKHN09760UC)program.ViewForm;
						viewForm.Close_Button_Click(this, null);

						break;
					}
					case ProgramPattern.Array:
					{
						PMKHN09760UE viewForm = (PMKHN09760UE)program.ViewForm;
						viewForm.Close_Button_Click(this, null);

						break;
					}
					case ProgramPattern.ThreeArray:
					{
						PMKHN09760UG viewForm = (PMKHN09760UG)program.ViewForm;
						viewForm.Close_Button_Click(this, null);

						break;
					}
					case ProgramPattern.FourArray:
					{
						PMKHN09760UJ viewForm = (PMKHN09760UJ)program.ViewForm;
						viewForm.Close_Button_Click(this, null);

						break;
					}
					default:
					{
						PMKHN09760UF viewForm = (PMKHN09760UF)program.ViewForm;
						viewForm.Close();

						break;
					}
				}
			}
		}
		
		/// <summary>
		/// マスタメンテナンス設定Listシリアライズ処理
		/// </summary>
		/// <param name="filePath">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : マスタメンテナンス設定List情報のシリアライズを行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void MasterMaintenanceConstructionListSerialize(string filePath)
		{
			ArrayList constructionList = new ArrayList();
			constructionList.Capacity = this._constructionTable.Count;

			foreach(string key in this._constructionList)
			{
				constructionList.Add(this._constructionTable[key]);
			}

			// マスタメンテナンス設定クラスリストをシリアライズ
			MasterMaintenanceConstruction[] constructions = (MasterMaintenanceConstruction[])constructionList.ToArray(typeof(MasterMaintenanceConstruction));
			UserSettingController.SerializeUserSetting(constructions, filePath);
		}

		/// <summary>
		/// マスタメンテナンス設定クラスデシリアライズ処理
		/// </summary>
		/// <param name="filePath">デシリアライズ対象XMLファイルフルパス</param>
		/// <remarks>
		/// <br>Note       : マスタメンテナンス設定リストクラスをデシリアライズします。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		public void MasterMaintenanceConstructionListDeserialize(string filePath)
		{
			if (System.IO.File.Exists(filePath) == true)
			{
				// ファイル名を渡してマスタメンテナンス設定クラスをデシリアライズする
				if (UserSettingController.ExistUserSetting(filePath))
				{
					MasterMaintenanceConstruction[] constructions = UserSettingController.DeserializeUserSetting<MasterMaintenanceConstruction[]>(filePath);

					// デシリアライズ結果をマスタメンテナンス設定クラスへコピー
					if (constructions != null)
					{
						for (int i = 0; i < constructions.Length; i++)
						{
							this._constructionList.Add(constructions[i].ToString());
							this._constructionTable.Add(constructions[i].ToString(), constructions[i]);
						}
					}
				}
			}
		}

		/// <summary>
		/// ウィンドウステートボタンツール構築処理
		/// </summary>
		private void CreateWindowStateButtonTools()
		{
			Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.ultraToolbarsManager1.Tools["Window_Menu"];
			windowPopupMenuTool.ResetTools();
			windowPopupMenuTool.Tools.AddTool("Reset_Button");

			for (int i = 0; i < this.DataViewTabControl.Tabs.Count; i++)
			{
				Infragistics.Win.UltraWinTabControl.UltraTab tab = this.DataViewTabControl.Tabs[i];

				string key = tab.Key;

				if (this.ultraToolbarsManager1.Tools.Exists(key))
				{
					windowPopupMenuTool.Tools.AddTool(key);
				}
				else
				{
					Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = new Infragistics.Win.UltraWinToolbars.StateButtonTool(key, "TabWindow");
					stateButtonTool.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
					stateButtonTool.SharedProps.Caption = tab.Text;
					stateButtonTool.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.WindowStateButtonTool_ToolClick);
					this.ultraToolbarsManager1.Tools.Add(stateButtonTool);

					windowPopupMenuTool.Tools.AddTool(key);
				}

				if ((i == 0) && (windowPopupMenuTool.Tools.Exists(key)))
				{
					Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[key];
					stateButtonTool.InstanceProps.IsFirstInGroup = true;
				}
			}
		}

		/// <summary>
		/// タブ選択処理
		/// </summary>
		/// <param name="key">タブ選択処理</param>
		private void SetActiveTab(string key)
		{
			Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.ultraToolbarsManager1.Tools["Window_Menu"];

			for (int i = 0; i < windowPopupMenuTool.Tools.Count; i++)
			{
				if (!(windowPopupMenuTool.Tools[i] is Infragistics.Win.UltraWinToolbars.StateButtonTool)) continue;
				
				Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[i];
				
				if ((this.DataViewTabControl.SelectedTab != null) && (this.DataViewTabControl.SelectedTab.Key == stateButtonTool.Key))
				{
					stateButtonTool.Checked = true;
				}
				else
				{
					stateButtonTool.Checked = false;
				}
			}
            // 別タブに切り替えて戻したときのフォーカス移動制御
            ProgramItem program = this._programTable[key] as ProgramItem;
            switch ( program.Pattern )
            {
                case ProgramPattern.Single:
                    {
                        PMKHN09760UB formUB = (PMKHN09760UB)program.ViewForm;
                        formUB.SetFocusOnParentTabActive();
                    }
                    break;
                case ProgramPattern.Multi:
                    {
                        PMKHN09760UC formUC = (PMKHN09760UC)program.ViewForm;
                        formUC.SetFocusOnParentTabActive();
                    }
                    break;
                case ProgramPattern.Array:
                    {
                        PMKHN09760UE formUE = (PMKHN09760UE)program.ViewForm;
                        formUE.SetFocusOnParentTabActive();
                    }
                    break;
                case ProgramPattern.ThreeArray:
                    {
                        PMKHN09760UG formUG = (PMKHN09760UG)program.ViewForm;
                        formUG.SetFocusOnParentTabActive();
                    }
                    break;
                case ProgramPattern.FourArray:
                    {
                        PMKHN09760UJ formUJ = (PMKHN09760UJ)program.ViewForm;
                        formUJ.SetFocusOnParentTabActive();
                    }
                    break;
                default:
                    {
                        PMKHN09760UF formUF = (PMKHN09760UF)program.ViewForm;
                        formUF.SetFocusOnParentTabActive();
                    }
                    break;
            }
		}

		/// <summary>
		/// ウィンドウステートボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void WindowStateButtonTool_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			if ((this.DataViewTabControl.Tabs.Exists(e.Tool.Key)))
			{
				if (!(e.Tool is Infragistics.Win.UltraWinToolbars.StateButtonTool)) return;

				Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)e.Tool;
				if (stateButtonTool.Checked)
				{
					this.DataViewTabControl.SelectedTab = this.DataViewTabControl.Tabs[e.Tool.Key];
				}
			}
		}

		/// <summary>
		/// ソフトウェアコード（システムレベル）チェック処理
		/// </summary>
		/// <param name="productCode">コード</param>
		/// <returns>true:ソフトウェアコード（システムレベル） false:ソフトウェアコード（システムレベル）以外</returns>
		private bool IsSoftwareCode_PAC(string productCode)
		{
			if (productCode.Length < 3)
			{
				return false;
			}

			string header = productCode.Substring(0,3);

			if ((header == "PAC") || (header == "SUB"))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// マスタメンテナンスプログラム起動処理
		/// </summary>
		/// <param name="selectedNode">選択済みノード</param>
		private void ProgramExecute(Infragistics.Win.UltraWinTree.UltraTreeNode selectedNode)
		{
			if (selectedNode == null)
			{
				return;
			}

			ProgramItem program = this._programTable[selectedNode.Key.ToString()] as ProgramItem;
			if (program == null)
			{
				return;
			}

			// タブの追加は青色のノードであった場合のみ行うのでノードの
			// フォント色が青色かどうかを確認する
			// 赤色の場合は既に起動済みなので、該当するタブを選択する
			if (selectedNode.Override.NodeAppearance.ForeColor.Equals(Color.Blue))
			{
				// 続行
			}
			else if (selectedNode.Override.NodeAppearance.ForeColor.Equals(Color.Red))
			{
				Infragistics.Win.UltraWinTabControl.UltraTab selectedTab = this.DataViewTabControl.Tabs[program.Key];

				if (selectedTab != null)
				{
					this.DataViewTabControl.SelectedTab = selectedTab;
				}

				return;
			}
			else
			{
				return;
			}

			// リフレクションを利用して、アセンブリのロードを行い、
			// オブジェクトのインスタンス化する
			string assemblyID = program.AssemblyID;
			string classID = program.ClassID;
			Assembly assmbly = Assembly.LoadFrom(assemblyID);
			System.Type type = assmbly.GetType(classID);

			program.ClassType = type;

			string arguments = program.Arguments;
			if (arguments != "")
			{
				object[] args = { arguments };
				program.Object = Activator.CreateInstance(type, args);
			}
			else
			{
				program.Object = Activator.CreateInstance(type);
			}

			program.CustomForm = (Form)program.Object;
			program.CustomForm.Icon = this.Icon;
			this._controlScreenSkin.SettingScreenSkin(program.CustomForm);

			if (program.Object is IMasterMaintenanceSingleType)
			{
				program.Pattern = ProgramPattern.Single;
			}
			else if (program.Object is IMasterMaintenanceMultiType)
			{
				program.Pattern = ProgramPattern.Multi;
			}
			else if (program.Object is IMasterMaintenanceArrayType)
			{
				program.Pattern = ProgramPattern.Array;
			}
			else if (program.Object is IMasterMaintenanceThreeArrayType)
			{
				program.Pattern = ProgramPattern.ThreeArray;
			}
			else if (program.Object is IMasterMaintenanceFourArrayType)
			{
				program.Pattern = ProgramPattern.FourArray;
			}
			else
			{
				program.Pattern = ProgramPattern.Other;
			}

			// タブコントロールに追加するタブページをインスタンス化する
			Infragistics.Win.UltraWinTabControl.UltraTabPageControl dataviewTabPageControl =
											new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();

			switch (program.Pattern)
			{
				case ProgramPattern.Single:
				{
					PMKHN09760UB viewForm = new PMKHN09760UB();

                    if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                        EntityUtil.CategoryCode.MasterMaintenance,
                        viewForm,
                        assemblyID,
                        selectedNode.Text
                    ))
                    {
                        break;
                    }

					this._controlScreenSkin.SettingScreenSkin(viewForm);

					// フォームインスタンスを待避する
					program.ViewForm = viewForm;

					// インスタンスを格納するハッシュテーブルに値をセットする(KEY:インスタンス Value:Guid)
					this._instanceTable.Add(program.ViewForm, program.Key);

					// タブの外観を設定し、タブコントロールにタブを追加する
					Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

					dataviewTab.TabPage = dataviewTabPageControl;
					dataviewTab.Text = selectedNode.Text;										// 名称
					dataviewTab.Key = selectedNode.Key.ToString();								// Guid
					dataviewTab.Tag = viewForm;														// フォームのインスタンス
					dataviewTab.Appearance.Image = selectedNode.Override.NodeAppearance.Image;	// アイコン
					dataviewTab.Appearance.BackColor = Color.White;
					dataviewTab.Appearance.BackColor2 = Color.Lavender;
					dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
					dataviewTab.ActiveAppearance.BackColor = Color.White;
					dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
					dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                    
					this.DataViewTabControl.Controls.Add(dataviewTabPageControl);
					this.DataViewTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
					this.DataViewTabControl.SelectedTab = dataviewTab;

					viewForm.Closed += new EventHandler(ViewForm_Closed);

					viewForm.TopLevel = false;
					viewForm.FormBorderStyle = FormBorderStyle.None;
					viewForm.ShowMe(this, program);
					dataviewTabPageControl.Controls.Add(viewForm);
					viewForm.Dock = System.Windows.Forms.DockStyle.Fill;

					selectedNode.Override.NodeAppearance.ForeColor = Color.Red;

					break;
				}
				case ProgramPattern.Multi:
				{
					PMKHN09760UC viewForm = new PMKHN09760UC();
                    
                    if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                        EntityUtil.CategoryCode.MasterMaintenance,
                        viewForm,
                        assemblyID,
                        selectedNode.Text
                    ))
                    {
                        break;
                    }

					this._controlScreenSkin.SettingScreenSkin(viewForm);

					// フォームインスタンスを待避する
					program.ViewForm = viewForm;

					// インスタンスを格納するハッシュテーブルに値をセットする(KEY:インスタンス Value:Guid)
					this._instanceTable.Add(program.ViewForm, program.Key);

					// タブの外観を設定し、タブコントロールにタブを追加する
					Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

					dataviewTab.TabPage = dataviewTabPageControl;
					dataviewTab.Text = selectedNode.Text;										// 名称
					dataviewTab.Key = selectedNode.Key.ToString();								// Guid
					dataviewTab.Tag = viewForm;														// フォームのインスタンス
					dataviewTab.Appearance.Image = selectedNode.Override.NodeAppearance.Image;	// アイコン
					dataviewTab.Appearance.BackColor = Color.White;
					dataviewTab.Appearance.BackColor2 = Color.Lavender;
					dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
					dataviewTab.ActiveAppearance.BackColor = Color.White;
					dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
					dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

					this.DataViewTabControl.Controls.Add(dataviewTabPageControl);
					this.DataViewTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
					this.DataViewTabControl.SelectedTab = dataviewTab;

					viewForm.Closed += new EventHandler(ViewForm_Closed);

					this.DataViewTabControl.Focus();

					viewForm.TopLevel = false;
					viewForm.FormBorderStyle = FormBorderStyle.None;
					viewForm.ShowMe(this, program);
					dataviewTabPageControl.Controls.Add(viewForm);
					viewForm.Dock = System.Windows.Forms.DockStyle.Fill;

					selectedNode.Override.NodeAppearance.ForeColor = Color.Red;

					// 検索場所コンボボックス構築処理
					ArrayList list = viewForm.GetColKeyList();
					SearchComboBoxConstructMultiType(list);

                    viewForm.Focus();

					break;
				}
				case ProgramPattern.Array:
				{
					PMKHN09760UE viewForm = new PMKHN09760UE();

                    if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                        EntityUtil.CategoryCode.MasterMaintenance,
                        viewForm,
                        assemblyID,
                        selectedNode.Text
                    ))
                    {
                        break;
                    }

					this._controlScreenSkin.SettingScreenSkin(viewForm);

					// フォームインスタンスを待避する
					program.ViewForm = viewForm;

					// インスタンスを格納するハッシュテーブルに値をセットする(KEY:インスタンス Value:Guid)
					this._instanceTable.Add(program.ViewForm, program.Key);

					// タブの外観を設定し、タブコントロールにタブを追加する
					Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

					dataviewTab.TabPage = dataviewTabPageControl;
					dataviewTab.Text = selectedNode.Text;										// 名称
					dataviewTab.Key = selectedNode.Key.ToString();								// Guid
					dataviewTab.Tag = viewForm;														// フォームのインスタンス
					dataviewTab.Appearance.Image = selectedNode.Override.NodeAppearance.Image;	// アイコン
					dataviewTab.Appearance.BackColor = Color.White;
					dataviewTab.Appearance.BackColor2 = Color.Lavender;
					dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
					dataviewTab.ActiveAppearance.BackColor = Color.White;
					dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
					dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

					this.DataViewTabControl.Controls.Add(dataviewTabPageControl);
					this.DataViewTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
					this.DataViewTabControl.SelectedTab = dataviewTab;

					viewForm.Closed += new EventHandler(ViewForm_Closed);

					viewForm.TopLevel = false;
					viewForm.FormBorderStyle = FormBorderStyle.None;
					viewForm.ShowMe(this, program);
					dataviewTabPageControl.Controls.Add(viewForm);
					viewForm.Dock = System.Windows.Forms.DockStyle.Fill;

					selectedNode.Override.NodeAppearance.ForeColor = Color.Red;

					// 検索場所コンボボックス構築処理
					ArrayList dataList;
					ArrayList colList1;
					ArrayList colList2;

					viewForm.GetColKeyList(out dataList, out colList1, out colList2);
					SearchComboBoxConstructArrayType(dataList, colList1, colList2, "");

                    viewForm.Focus();

					break;
				}
				case ProgramPattern.ThreeArray:
				{
					PMKHN09760UG viewForm = new PMKHN09760UG();

                    if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                        EntityUtil.CategoryCode.MasterMaintenance,
                        viewForm,
                        assemblyID,
                        selectedNode.Text
                    ))
                    {
                        break;
                    }

					this._controlScreenSkin.SettingScreenSkin(viewForm);

					// フォームインスタンスを待避する
					program.ViewForm = viewForm;

					// インスタンスを格納するハッシュテーブルに値をセットする(KEY:インスタンス Value:Guid)
					this._instanceTable.Add(program.ViewForm, program.Key);

					// タブの外観を設定し、タブコントロールにタブを追加する
					Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

					dataviewTab.TabPage = dataviewTabPageControl;
					dataviewTab.Text = selectedNode.Text;										// 名称
					dataviewTab.Key = selectedNode.Key.ToString();								// Guid
					dataviewTab.Tag = viewForm;														// フォームのインスタンス
					dataviewTab.Appearance.Image = selectedNode.Override.NodeAppearance.Image;	// アイコン
					dataviewTab.Appearance.BackColor = Color.White;
					dataviewTab.Appearance.BackColor2 = Color.Lavender;
					dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
					dataviewTab.ActiveAppearance.BackColor = Color.White;
					dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
					dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

					this.DataViewTabControl.Controls.Add(dataviewTabPageControl);
					this.DataViewTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
					this.DataViewTabControl.SelectedTab = dataviewTab;

					viewForm.Closed += new EventHandler(ViewForm_Closed);

					viewForm.TopLevel = false;
					viewForm.FormBorderStyle = FormBorderStyle.None;
					viewForm.ShowMe(this, program);
					dataviewTabPageControl.Controls.Add(viewForm);
					viewForm.Dock = System.Windows.Forms.DockStyle.Fill;

					selectedNode.Override.NodeAppearance.ForeColor = Color.Red;

					// 検索場所コンボボックス構築処理
					ArrayList dataList;
					ArrayList colList1;
					ArrayList colList2;
					ArrayList colList3;

					viewForm.GetColKeyList(out dataList, out colList1, out colList2, out colList3);
					SearchComboBoxConstructThreeArrayType(dataList, colList1, colList2, colList3, "");

                    viewForm.Focus();

					break;
				}
				case ProgramPattern.FourArray:
				{
					PMKHN09760UJ viewForm = new PMKHN09760UJ();

                    if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                        EntityUtil.CategoryCode.MasterMaintenance,
                        viewForm,
                        assemblyID,
                        selectedNode.Text
                    ))
                    {
                        break;
                    }

					this._controlScreenSkin.SettingScreenSkin(viewForm);

					// フォームインスタンスを待避する
					program.ViewForm = viewForm;

					// インスタンスを格納するハッシュテーブルに値をセットする(KEY:インスタンス Value:Guid)
					this._instanceTable.Add(program.ViewForm, program.Key);

					// タブの外観を設定し、タブコントロールにタブを追加する
					Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

					dataviewTab.TabPage = dataviewTabPageControl;
					dataviewTab.Text = selectedNode.Text;										// 名称
					dataviewTab.Key = selectedNode.Key.ToString();								// Guid
					dataviewTab.Tag = viewForm;														// フォームのインスタンス
					dataviewTab.Appearance.Image = selectedNode.Override.NodeAppearance.Image;	// アイコン
					dataviewTab.Appearance.BackColor = Color.White;
					dataviewTab.Appearance.BackColor2 = Color.Lavender;
					dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
					dataviewTab.ActiveAppearance.BackColor = Color.White;
					dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
					dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

					this.DataViewTabControl.Controls.Add(dataviewTabPageControl);
					this.DataViewTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
					this.DataViewTabControl.SelectedTab = dataviewTab;

					viewForm.Closed += new EventHandler(ViewForm_Closed);

					viewForm.TopLevel = false;
					viewForm.FormBorderStyle = FormBorderStyle.None;
					viewForm.ShowMe(this, program);
					dataviewTabPageControl.Controls.Add(viewForm);
					viewForm.Dock = System.Windows.Forms.DockStyle.Fill;

					selectedNode.Override.NodeAppearance.ForeColor = Color.Red;

					// 検索場所コンボボックス構築処理
					ArrayList dataList;
					ArrayList colList1;
					ArrayList colList2;
					ArrayList colList3;
					ArrayList colList4;

					viewForm.GetColKeyList(out dataList, out colList1, out colList2, out colList3, out colList4);
					SearchComboBoxConstructFourArrayType(dataList, colList1, colList2, colList3, colList4, "");

                    viewForm.Focus();

					break;
				}
				default:
				{
					PMKHN09760UF viewForm = new PMKHN09760UF();
					this._controlScreenSkin.SettingScreenSkin(viewForm);

					// フォームインスタンスを待避する
					program.ViewForm = viewForm;

					// インスタンスを格納するハッシュテーブルに値をセットする(KEY:インスタンス Value:Guid)
					this._instanceTable.Add(program.ViewForm, program.Key);

					// タブの外観を設定し、タブコントロールにタブを追加する
					Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

					dataviewTab.TabPage = dataviewTabPageControl;
					dataviewTab.Text = selectedNode.Text;										// 名称
					dataviewTab.Key = selectedNode.Key.ToString();								// Guid
					dataviewTab.Tag = viewForm;														// フォームのインスタンス
					dataviewTab.Appearance.Image = selectedNode.Override.NodeAppearance.Image;	// アイコン
					dataviewTab.Appearance.BackColor = Color.White;
					dataviewTab.Appearance.BackColor2 = Color.Lavender;
					dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
					dataviewTab.ActiveAppearance.BackColor = Color.White;
					dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
					dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

					this.DataViewTabControl.Controls.Add(dataviewTabPageControl);
					this.DataViewTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
					this.DataViewTabControl.SelectedTab = dataviewTab;

					viewForm.Closed += new EventHandler(ViewForm_Closed);

					viewForm.TopLevel = false;
					viewForm.FormBorderStyle = FormBorderStyle.None;
					viewForm.ShowMe(this, program);
					dataviewTabPageControl.Controls.Add(viewForm);
					viewForm.Dock = System.Windows.Forms.DockStyle.Fill;

					selectedNode.Override.NodeAppearance.ForeColor = Color.Red;

                    viewForm.Focus();

					break;
				}
			}
		}

		/// <summary>
		/// ログ出力(DEBUG)処理
		/// </summary>
		/// <param name="pMode">モード</param>
		/// <param name="pMsg">メッセージ</param>
		public static void LogWrt(int pMode, string pMsg)
		{
#if DEBUG
			System.IO.FileStream _fs;										// ファイルストリーム
			System.IO.StreamWriter _sw;										// ストリームwriter
			_fs = new FileStream("PMKHN09760U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
			_sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
			DateTime edt = DateTime.Now;
			//yyyy/MM/dd hh:mm:ss
			_sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
			if (_sw != null)
				_sw.Close();
			if (_fs != null)
				_fs.Close();
#endif
		}
		# endregion

		#region Control Events
		/// <summary>
		/// Form.Load イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void PMKHN09760UA_Load(object sender, System.EventArgs e)
		{
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);

			this.Text = MAIN_TITLE;
			StartNavigatorTree.Focus();

			// アイコンリソース管理クラスを使用して、アイコンを表示する
			this.ultraToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
			this.ultraToolbarsManager1.Tools["Close_Button"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			this.ultraToolbarsManager1.Tools["SearchTitle_Label"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
			this.ultraToolbarsManager1.Tools["LoginTitle_Label"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

			this.ultraToolbarsManager1.Tools["Close_Button"].SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			this.ultraToolbarsManager1.Tools["SearchTitle_Label"].SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			this.ultraToolbarsManager1.Tools["LoginTitle_Label"].SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;

			if (LoginInfoAcquisition.Employee != null)
			{
				this.ultraToolbarsManager1.Tools["LoginName_Label"].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
			}

			((Infragistics.Win.UltraWinToolbars.StateButtonTool)this.ultraToolbarsManager1.Tools["WindowStyle1_StateButtonTool"]).Checked = true;
			((Infragistics.Win.UltraWinToolbars.StateButtonTool)this.ultraToolbarsManager1.Tools["WindowStyle2_StateButtonTool"]).Checked = false;

			this.ultraDockManager1.ImageList = IconResourceManagement.ImageList16;
			this.ultraDockManager1.ControlPanes[0].Settings.Appearance.Image = Size16_Index.TREE;
			this.ultraDockManager1.ControlPanes[1].Settings.Appearance.Image = Size16_Index.VIEW;

			LogWrt(0, "LOAD END");
			this.Initialize_Timer.Enabled = true;
		}

		/// <summary>
		/// Form.Closing イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルイベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォームが閉じている間に発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void PMKHN09760UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.MasterMaintenanceConstructionListSerialize(this._constructionFilePath);
		}

		/// <summary>
		/// Control.DoubleClick イベント(StartNavigatorTree)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ツリーコントロールがダブルクリックされたときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void StartNavigatorTree_DoubleClick(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			Infragistics.Win.UltraWinTree.UltraTreeNode doubleClickedNode = 
											this.StartNavigatorTree.GetNodeFromPoint(this._lastMouseDown);

			// マスタメンテナンスプログラム起動処理
			this.ProgramExecute(doubleClickedNode);

			Cursor.Current = Cursors.Arrow;
		}

		/// <summary>
		/// Control.MouseDown イベント(StartNavigatorTree)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　 : ツリーコントロールにてマウスボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void StartNavigatorTree_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this._lastMouseDown = new Point(e.X, e.Y);
		}

		/// <summary>
		/// UltraTreeNode.AfterCheck イベント(StartNavigatorTree)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">ノードを取得するイベントで使用するイベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　 : ツリーコントロールのCheckedStateプロパティが変更された後に発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void StartNavigatorTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
		{
			// 以下は、ユーザーが任意にツリーのチェックボックスを変更できないように
			// するための処理です。

			ProgramItem program = this._programTable[e.TreeNode.Key.ToString()] as ProgramItem;
			if (program == null)
			{
				return;
			}

			switch (program.Condition)
			{
				case ProgramCondition.Checked:
				{
					e.TreeNode.CheckedState = CheckState.Checked;
					break;
				}
				case ProgramCondition.UnChecked:
				{
					e.TreeNode.CheckedState = CheckState.Unchecked;
					break;
				}
			}
		}

		/// <summary>
		/// ultraToolbarsManager.ToolClick イベント(ultraToolbarsManager1)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">ToolClickイベントに使用されるイベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ツールバーマネージャーのツールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 980076 妻鳥  謙一郎</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "File_Menu":
				{
					break;
				}
				case "Window_Menu":
				{
					break;
				}
				case "Close_Button":    
				{
					// ビューフォームインスタンス破棄処理
					this.Close();

					break;
				}
				case "Reset_Button":   
				{
					if (this._dockMemoryStream == null)
					{
						return;
					}

					this._dockMemoryStream.Position = 0;

					this.ultraDockManager1.LoadFromBinary(this._dockMemoryStream);

					if (((Infragistics.Win.UltraWinToolbars.StateButtonTool)this.ultraToolbarsManager1.Tools["WindowStyle1_StateButtonTool"]).Checked == true)
					{
						WindowStyleChange(Infragistics.Win.EmbeddableElementDisplayStyle.Office2003);
					}
					else
					{
						WindowStyleChange(Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005);
					}


					break;
				}
				case "ShowAll_Button":   
				{
					this.ultraDockManager1.ShowAll(false);
					break;
				}
				case "HideAll_Button":   
				{
					this.ultraDockManager1.HideAll();
					break;
				}
				case "Pinnall_Button":   
				{
					this.ultraDockManager1.PinAll();
					break;
				}
				case "UnPinAll_Button":  
				{
					this.ultraDockManager1.UnpinAll();
					break;
				}
				case "Search_Button":
				{
					this.GridTextSearchExecution();
					break;
				}
				case "WindowStyle1_StateButtonTool":
				{
					WindowStyleChange(Infragistics.Win.EmbeddableElementDisplayStyle.Office2003);
					break;
				}
				case "WindowStyle2_StateButtonTool":
				{
					WindowStyleChange(Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005);
					break;
				}
			}
		}

		/// <summary>
		/// ultraToolbarsManager.AfterToolCloseup イベント(ultraToolbarsManager1)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">ToolClickイベントに使用されるイベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ツールバーマネージャーのツールがクリックされたときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void ultraToolbarsManager1_AfterToolCloseup(object sender, Infragistics.Win.UltraWinToolbars.ToolDropdownEventArgs e)
		{
			if (e.Tool.Key == "SearchPosition2_ComboBox")　　
			{
				ProgramItem program = this._programTable[this.DataViewTabControl.SelectedTab.Key.ToString()] as ProgramItem;
				if (program == null)
				{
					return;
				}

				switch (program.Pattern)
				{
					case ProgramPattern.Single:
					{
						return;
					}
					case ProgramPattern.Multi:
					{
						return;
					}
					case ProgramPattern.Array:
					{
						Infragistics.Win.UltraWinToolbars.ComboBoxTool comboTool = e.Tool as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
						if (comboTool != null && comboTool.SelectedItem is Infragistics.Win.ValueListItem)
						{
							Infragistics.Win.ValueListItem item = comboTool.SelectedItem as Infragistics.Win.ValueListItem;

							// 検索場所コンボボックス構築処理
							ArrayList dataList;
							ArrayList colList1;
							ArrayList colList2;

							PMKHN09760UE viewForm = (PMKHN09760UE)program.ViewForm;
							viewForm.GetColKeyList(out dataList, out colList1, out colList2);
							SearchComboBoxConstructArrayType(dataList, colList1, colList2, item.DataValue.ToString());
						}

						break;
					}
					case ProgramPattern.ThreeArray:
					{
						Infragistics.Win.UltraWinToolbars.ComboBoxTool comboTool = e.Tool as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
						if (comboTool != null && comboTool.SelectedItem is Infragistics.Win.ValueListItem)
						{
							Infragistics.Win.ValueListItem item = comboTool.SelectedItem as Infragistics.Win.ValueListItem;

							// 検索場所コンボボックス構築処理
							ArrayList dataList;
							ArrayList colList1;
							ArrayList colList2;
							ArrayList colList3;

							PMKHN09760UG viewForm = (PMKHN09760UG)program.ViewForm;
							viewForm.GetColKeyList(out dataList, out colList1, out colList2, out colList3);
							SearchComboBoxConstructThreeArrayType(dataList, colList1, colList2, colList3, item.DataValue.ToString());
						}

						break;
					}
					case ProgramPattern.FourArray:
					{
						Infragistics.Win.UltraWinToolbars.ComboBoxTool comboTool = e.Tool as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
						if (comboTool != null && comboTool.SelectedItem is Infragistics.Win.ValueListItem)
						{
							Infragistics.Win.ValueListItem item = comboTool.SelectedItem as Infragistics.Win.ValueListItem;

							// 検索場所コンボボックス構築処理
							ArrayList dataList;
							ArrayList colList1;
							ArrayList colList2;
							ArrayList colList3;
							ArrayList colList4;

							PMKHN09760UJ viewForm = (PMKHN09760UJ)program.ViewForm;
							viewForm.GetColKeyList(out dataList, out colList1, out colList2, out colList3, out colList4);
							SearchComboBoxConstructFourArrayType(dataList, colList1, colList2, colList3, colList4, item.DataValue.ToString());
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

		/// <summary>
		/// UltraTabControl.SelectedTabChanged イベント(DataViewTabControl)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">SelectedTabChangedイベントに使用されるイベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　 : タブコントロールのSelectedTabが変更された後に発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void DataViewTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
		{
			// 選択タブ変更時ツリーノード選択処理
			SelectedTabChangedNodeSelect();

			// 選択タブ変更時ツールバー再構築処理
			SelectedTabChangedToolBarReconstruction();

			if (e.Tab != null)
			{
				this.Text = MAIN_TITLE + "－" + e.Tab.Text;
			}
			else
			{
				this.Text = MAIN_TITLE;
			}

			// ウィンドウステートボタンツール構築処理
			this.CreateWindowStateButtonTools();

			// タブアクティブ処理
			if (e.Tab != null)
			{
				this.SetActiveTab(e.Tab.Key);
			}
		}

		/// <summary>
		/// フォームクロージングイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void PMKHN09760UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = false;
		}

		/// <summary>
		/// 起動処理タイマーイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void Initialize_Timer_Tick(object sender, EventArgs e)
		{
			this.Initialize_Timer.Enabled = false;

			// マスタメンテナンス起動ナビゲーター情報が格納されたバイナリデータをロードする
			this.StartNavigatorTree.LoadFromBinary(NAVIGATORTREE_DAT);

			this._programTable = new Hashtable();
			this._instanceTable = new Hashtable();
			this._constructionTable = new Hashtable();
			this._constructionList = new ArrayList();
			this._dockMemoryStream = new MemoryStream();

			TreeNodeConstruction();
			ProgramCollectionCreate();

            if ( _parameter.Length > 0 && visibleRootNode != null )
            {
                this.StartNavigatorTree.Nodes[0] = visibleRootNode;
                visibleRootNode.Selected = true;
            }
            this.StartNavigatorTree.ShowRootLines = false;
            this.StartNavigatorTree.Nodes.Override.NodeSpacingBefore = 5;

			this.DataViewTabControl.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			for (int i = 0; i < this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools.Count; i++)
			{
				this.ultraToolbarsManager1.Toolbars["SearchInfoBar"].Tools[i].SharedProps.Enabled = false;
			}
			this.ultraToolbarsManager1.Tools["SearchPosition2_ComboBox"].SharedProps.Visible = false;

			// DockManagerの状態を保持する
			this.ultraDockManager1.SaveAsBinary(this._dockMemoryStream);

			// マスタメンテナンス設定クラスをデシリアライズする
			this.MasterMaintenanceConstructionListDeserialize(this._constructionFilePath);
		}

		/// <summary>
		/// ナビゲーターツリーキーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void StartNavigatorTree_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Return:
				{
					if ((this.StartNavigatorTree.SelectedNodes == null) || (this.StartNavigatorTree.SelectedNodes.Count == 0))
					{
						return;
					}

					Cursor.Current = Cursors.WaitCursor;

					Infragistics.Win.UltraWinTree.UltraTreeNode selectedNode = this.StartNavigatorTree.SelectedNodes[0];

					// マスタメンテナンスプログラム起動処理
					this.ProgramExecute(selectedNode);

					Cursor.Current = Cursors.Arrow;

					break;
				}
			}
		}

        /// <summary>
        /// コントロール削除イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataViewTabControl_ControlRemoved(object sender, ControlEventArgs e)
        {
            // 表示タブが無い場合、メッセージを非表示にする
            Infragistics.Win.UltraWinTabControl.UltraTabControl tabc = (Infragistics.Win.UltraWinTabControl.UltraTabControl)sender;
            if (tabc.ActiveTab == null)
            {
                MainStatusBar.Panels[MAINSTATUSBAR_PANELS_KEY_MSG].Visible = false;
            }
        }
        # endregion
	}
}
