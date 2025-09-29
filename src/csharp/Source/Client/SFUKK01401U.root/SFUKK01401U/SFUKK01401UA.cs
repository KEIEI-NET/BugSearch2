using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;
using Infragistics.Win.UltraWinTabControl;
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 入金伝票入力メインフレームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金伝票入力メインフレームクラスです。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
    /// <br>Update Note: 2007.01.29 18322 T.Kimura MA.NS用に変更</br>
    /// <br>                                         1. 画面デザイン変更</br>
    /// <br>             2007.05.14 18322 T.Kimura 領収書の対応を行うまで「領収書」ボタンを非表示に変更</br>
    /// <br>             2008.02.20 20081 疋田 勇人 DC.NS用に変更(拠点取得方法を変更)</br>
    /// <br>             2008.06.26 30414 忍 幸史 Partsman用に変更(拠点取得方法を変更)</br>
    /// <br>             2009.07.21 22008 長内 数馬  MANTIS 13287</br>
    /// <br>Update Note: 2012/12/24 王君</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : Redmine#33741の対応</br>
    /// <br>Update Note: 2013/02/05 田建委</br>
    /// <br>管理番号   : 10801804-00 2013/03/13配信分</br>
    /// <br>           : Redmine#33735 画面を閉じるとき、例外が起こる対応</br>
    /// <br>Update Note: 2014/07/08 zhujw</br>
    /// <br>管理番号   : 11001635-00 </br>
    /// <br>           : Redmine#42902の⑧ 既存障害の修正</br>
    /// <br>Update Note: 2015/08/18 李侠</br>
    /// <br>管理番号   : 11170129-00 【№85】入金伝票入力の障害対応</br>
    /// <br>           : Redmine#47016 「最新情報」ボタンを押下した後、画面タイプリストを変更する場合、例外エラーの対応</br>
    /// </remarks>
	public class SFUKK01401UA : Form
	{
		# region Private Members (Component)
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private System.Windows.Forms.Panel SlipSearch_Panel;
		private Infragistics.Win.UltraWinDock.UltraDockManager Main_DockManager;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFUKK01401UAUnpinnedTabAreaLeft;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFUKK01401UAUnpinnedTabAreaTop;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFUKK01401UAUnpinnedTabAreaBottom;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFUKK01401UAUnpinnedTabAreaRight;
		private Infragistics.Win.UltraWinDock.AutoHideControl _SFUKK01401UAAutoHideControl;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01401UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01401UA_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01401UA_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01401UA_Toolbars_Dock_Area_Bottom;
		private System.Windows.Forms.Timer startTimer;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl Main_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private TMemPos tMemPos1;
        private Infragistics.Win.Misc.UltraButton uButton_Close;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// 入金伝票入力メインフレームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 使用するメンバの初期化を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public SFUKK01401UA()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			// --- クラスメンバ初期化 --- //
			this.depositRelDataAcs = new DepositRelDataAcs();				// 入金伝票入力設定データ系アクセスクラス

			this._parameter = 1;											// MDI表示パラメータ
		
			this.selectedDispTypeItem = null;								// 現在選択画面タイプ

			this.selectedSection = null;									// 現在選択拠点

			this.selectDispTypeFlg = false;									// 画面タイプ選択中フラグ

			this.selectedSectionFlg = false;								// 拠点選択中フラグ

			this._startingMode = StartingMode.Normal;						// 起動モード

			this._startingParameter = null;									// 起動パラメータ

			this._dockMemoryStream = null;									// ウィンドウ状態保持用

			this._firstStartFlg = 0;										// 初回起動フラグ

            this._demandAddUpSecCd = string.Empty;                          // 請求計上拠点コード

			// 番号タイプ管理マスタを取得処理(Thread)
			Thread SearchNoMngSetAcsThread = new Thread(new ThreadStart(SearchNoMngSetAcs));
			SearchNoMngSetAcsThread.Start();
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
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("a4832d9d-c5f9-4271-9cb2-b7c33d6c3bbb"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("25066978-2c70-4718-80f4-a985f619841e"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("a4832d9d-c5f9-4271-9cb2-b7c33d6c3bbb"), -1);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK01401UA));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("KYOTENNM");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("SectionCode_l");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("LOGINTITLE");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnClose");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnNew");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnSave");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnDelete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnAka");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnReceiptPrint");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnRenewal");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnReadslip");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar3 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar2");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("DispTypeList");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnNew");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnSave");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnDelete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnAka");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnReadslip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnClose");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnInitWindow");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LOGINTITLE");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnClose");
            Infragistics.Win.UltraWinToolbars.MdiWindowListTool mdiWindowListTool1 = new Infragistics.Win.UltraWinToolbars.MdiWindowListTool("InputForm_MDIWindowListTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Main_ButtonTool");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool2 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("DispTypeList");
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnNew");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnSave");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnDelete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnAka");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool("KYOTENNM");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool3 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("KYOTENCOMBO");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnInitWindow");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnReceiptPrint");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool10 = new Infragistics.Win.UltraWinToolbars.LabelTool("SectionCode");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool11 = new Infragistics.Win.UltraWinToolbars.LabelTool("SectionCode_l");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Edit");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnDelete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnAka");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnRenewal");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnReadslip");
            this.SlipSearch_Panel = new System.Windows.Forms.Panel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this._SFUKK01401UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFUKK01401UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFUKK01401UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFUKK01401UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFUKK01401UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.startTimer = new System.Windows.Forms.Timer(this.components);
            this.Main_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.uButton_Close = new Infragistics.Win.Misc.UltraButton();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this._SFUKK01401UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._SFUKK01401UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFUKK01401UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).BeginInit();
            this.dockableWindow1.SuspendLayout();
            this._SFUKK01401UAAutoHideControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).BeginInit();
            this.Main_UTabControl.SuspendLayout();
            this.ultraTabSharedControlsPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // SlipSearch_Panel
            // 
            this.SlipSearch_Panel.BackColor = System.Drawing.Color.GhostWhite;
            this.SlipSearch_Panel.Location = new System.Drawing.Point(0, 27);
            this.SlipSearch_Panel.Name = "SlipSearch_Panel";
            this.SlipSearch_Panel.Size = new System.Drawing.Size(312, 621);
            this.SlipSearch_Panel.TabIndex = 0;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 711);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
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
            // 
            // Main_DockManager
            // 
            this.Main_DockManager.AnimationSpeed = Infragistics.Win.UltraWinDock.AnimationSpeed.StandardSpeedPlus5;
            this.Main_DockManager.AutoHideDelay = 50;
            this.Main_DockManager.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
            this.Main_DockManager.ShowCloseButton = false;
            // ----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
            dockableControlPane1.Control = this.SlipSearch_Panel;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(312, -1);
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(40, 70, 270, 530);
            dockableControlPane1.Pinned = false;
            appearance1.FontData.SizeInPoints = 10F;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            dockableControlPane1.Settings.Appearance = appearance1;
            dockableControlPane1.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "得意先検索";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(297, 648);
            this.Main_DockManager.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.Main_DockManager.HostControl = this;
            this.Main_DockManager.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.SlipSearch_Panel);
            this.dockableWindow1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.Main_DockManager;
            this.dockableWindow1.Size = new System.Drawing.Size(350, 648);
            this.dockableWindow1.TabIndex = 28;
            // 
            // _SFUKK01401UAUnpinnedTabAreaLeft
            // 
            this._SFUKK01401UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._SFUKK01401UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFUKK01401UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 63);
            this._SFUKK01401UAUnpinnedTabAreaLeft.Name = "_SFUKK01401UAUnpinnedTabAreaLeft";
            this._SFUKK01401UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._SFUKK01401UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(22, 648);
            this._SFUKK01401UAUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _SFUKK01401UAUnpinnedTabAreaTop
            // 
            this._SFUKK01401UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._SFUKK01401UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFUKK01401UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(22, 63);
            this._SFUKK01401UAUnpinnedTabAreaTop.Name = "_SFUKK01401UAUnpinnedTabAreaTop";
            this._SFUKK01401UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._SFUKK01401UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(994, 0);
            this._SFUKK01401UAUnpinnedTabAreaTop.TabIndex = 7;
            // 
            // _SFUKK01401UAUnpinnedTabAreaBottom
            // 
            this._SFUKK01401UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._SFUKK01401UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFUKK01401UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(22, 711);
            this._SFUKK01401UAUnpinnedTabAreaBottom.Name = "_SFUKK01401UAUnpinnedTabAreaBottom";
            this._SFUKK01401UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._SFUKK01401UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(994, 0);
            this._SFUKK01401UAUnpinnedTabAreaBottom.TabIndex = 8;
            // 
            // _SFUKK01401UAUnpinnedTabAreaRight
            // 
            this._SFUKK01401UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._SFUKK01401UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFUKK01401UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(1016, 63);
            this._SFUKK01401UAUnpinnedTabAreaRight.Name = "_SFUKK01401UAUnpinnedTabAreaRight";
            this._SFUKK01401UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._SFUKK01401UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 648);
            this._SFUKK01401UAUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _SFUKK01401UAAutoHideControl
            // 
            this._SFUKK01401UAAutoHideControl.Controls.Add(this.dockableWindow1);
            this._SFUKK01401UAAutoHideControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFUKK01401UAAutoHideControl.Location = new System.Drawing.Point(22, 63);
            this._SFUKK01401UAAutoHideControl.Name = "_SFUKK01401UAAutoHideControl";
            this._SFUKK01401UAAutoHideControl.Owner = this.Main_DockManager;
            this._SFUKK01401UAAutoHideControl.Size = new System.Drawing.Size(77, 648);
            this._SFUKK01401UAAutoHideControl.TabIndex = 9;
            // 
            // startTimer
            // 
            this.startTimer.Interval = 1;
            this.startTimer.Tick += new System.EventHandler(this.startTimer_Tick);
            // 
            // Main_UTabControl
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.LightPink;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Main_UTabControl.ActiveTabAppearance = appearance2;
            this.Main_UTabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.Main_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.Main_UTabControl.Location = new System.Drawing.Point(22, 63);
            this.Main_UTabControl.Name = "Main_UTabControl";
            this.Main_UTabControl.SharedControls.AddRange(new System.Windows.Forms.Control[] {
            this.uButton_Close});
            this.Main_UTabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.Main_UTabControl.Size = new System.Drawing.Size(994, 648);
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.TabIndex = 23;
            this.Main_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Main_UTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Controls.Add(this.uButton_Close);
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(992, 627);
            // 
            // uButton_Close
            // 
            appearance112.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance112.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Close.Appearance = appearance112;
            this.uButton_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_Close.Location = new System.Drawing.Point(484, 301);
            this.uButton_Close.Name = "uButton_Close";
            this.uButton_Close.Size = new System.Drawing.Size(1, 1);
            this.uButton_Close.TabIndex = 2;
            this.uButton_Close.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Close.Click += new System.EventHandler(this.uButton_Close_Click);
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea1.Location = new System.Drawing.Point(22, 63);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.Main_DockManager;
            this.windowDockingArea1.Size = new System.Drawing.Size(302, 648);
            this.windowDockingArea1.TabIndex = 10;
            // 
            // _SFUKK01401UA_Toolbars_Dock_Area_Left
            // 
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.Name = "_SFUKK01401UA_Toolbars_Dock_Area_Left";
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 648);
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
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
            ultraToolbar1.FloatingSize = new System.Drawing.Size(751, 20);
            ultraToolbar1.IsMainMenuBar = true;
            labelTool1.InstanceProps.Width = 25;
            labelTool2.InstanceProps.Width = 54;
            labelTool3.InstanceProps.Width = 141;
            labelTool4.InstanceProps.Width = 103;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            labelTool1,
            labelTool2,
            labelTool3,
            labelTool4,
            labelTool5});
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "標準";
            ultraToolbar3.DockedColumn = 1;
            ultraToolbar3.DockedRow = 1;
            ultraToolbar3.FloatingSize = new System.Drawing.Size(359, 24);
            ultraToolbar3.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            comboBoxTool1});
            ultraToolbar3.Text = "画面タイプ";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2,
            ultraToolbar3});
            popupMenuTool2.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool2.SharedProps.MergeOrder = 10;
            buttonTool14.InstanceProps.IsFirstInGroup = true;
            popupMenuTool2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            buttonTool14});
            popupMenuTool3.SharedProps.Caption = "ウィンドウ(&W)";
            popupMenuTool3.SharedProps.MergeOrder = 30;
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool15});
            labelTool6.SharedProps.MergeOrder = 40;
            labelTool6.SharedProps.Spring = true;
            labelTool7.SharedProps.Caption = "ログイン担当者";
            labelTool7.SharedProps.MergeOrder = 50;
            labelTool7.SharedProps.ShowInCustomizer = false;
            labelTool7.SharedProps.Width = 100;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Left";
            labelTool8.SharedProps.AppearancesSmall.Appearance = appearance3;
            labelTool8.SharedProps.Caption = "ログイン名";
            labelTool8.SharedProps.MergeOrder = 60;
            labelTool8.SharedProps.ShowInCustomizer = false;
            labelTool8.SharedProps.Width = 150;
            buttonTool16.SharedProps.Caption = "終了(F1)";
            buttonTool16.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool16.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;
            mdiWindowListTool1.DisplayArrangeIconsCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayCascadeCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayCloseWindowsCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayMinimizeCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayTileHorizontalCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayTileVerticalCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.SharedProps.Caption = "InputForm_MDIWindowListTool";
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            buttonTool17.SharedProps.AppearancesSmall.Appearance = appearance4;
            buttonTool17.SharedProps.Caption = "メイン画面(&M)";
            buttonTool17.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            comboBoxTool2.SharedProps.Caption = "画面タイプ";
            comboBoxTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            comboBoxTool2.SharedProps.Width = 250;
            comboBoxTool2.ValueList = valueList1;
            buttonTool18.SharedProps.Caption = "新規(F9)";
            buttonTool18.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool18.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F9;
            buttonTool19.SharedProps.Caption = "保存(F10)";
            buttonTool19.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool19.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            buttonTool20.SharedProps.Caption = "伝票削除(F12)";
            buttonTool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool20.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F12;
            buttonTool21.SharedProps.Caption = "赤伝(&R)";
            buttonTool21.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool9.SharedProps.Caption = "ログイン拠点";
            labelTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance5.ForeColor = System.Drawing.Color.Black;
            comboBoxTool3.EditAppearance = appearance5;
            comboBoxTool3.Locked = true;
            comboBoxTool3.SharedProps.ToolTipText = "請求計上拠点";
            comboBoxTool3.ValueList = valueList2;
            buttonTool22.SharedProps.Caption = "ウィンドウを初期状態に戻す(&R)";
            buttonTool22.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool23.SharedProps.Caption = "領収書";
            buttonTool23.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool10.SharedProps.Caption = "拠点名";
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.TextHAlignAsString = "Left";
            labelTool11.SharedProps.AppearancesSmall.Appearance = appearance6;
            labelTool11.SharedProps.MinWidth = 0;
            labelTool11.SharedProps.ShowInCustomizer = false;
            labelTool11.SharedProps.Width = 150;
            popupMenuTool4.SharedProps.Caption = "編集(&E)";
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool24,
            buttonTool25});
            buttonTool26.SharedProps.Caption = "最新情報(&I)";
            buttonTool26.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool27.SharedProps.Caption = "伝票呼出(F11)";
            buttonTool27.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool27.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F11;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool2,
            popupMenuTool3,
            labelTool6,
            labelTool7,
            labelTool8,
            buttonTool16,
            mdiWindowListTool1,
            buttonTool17,
            comboBoxTool2,
            buttonTool18,
            buttonTool19,
            buttonTool20,
            buttonTool21,
            labelTool9,
            comboBoxTool3,
            buttonTool22,
            buttonTool23,
            labelTool10,
            labelTool11,
            popupMenuTool4,
            buttonTool26,
            buttonTool27});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            this.Main_ToolbarsManager.ToolValueChanged += new Infragistics.Win.UltraWinToolbars.ToolEventHandler(this.Main_ToolbarsManager_ToolValueChanged);
            // 
            // _SFUKK01401UA_Toolbars_Dock_Area_Right
            // 
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 63);
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.Name = "_SFUKK01401UA_Toolbars_Dock_Area_Right";
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 648);
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFUKK01401UA_Toolbars_Dock_Area_Top
            // 
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.Name = "_SFUKK01401UA_Toolbars_Dock_Area_Top";
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 63);
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFUKK01401UA_Toolbars_Dock_Area_Bottom
            // 
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 711);
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.Name = "_SFUKK01401UA_Toolbars_Dock_Area_Bottom";
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // SFUKK01401UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.CancelButton = this.uButton_Close;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this._SFUKK01401UAAutoHideControl);
            this.Controls.Add(this.Main_UTabControl);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this._SFUKK01401UAUnpinnedTabAreaTop);
            this.Controls.Add(this._SFUKK01401UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._SFUKK01401UAUnpinnedTabAreaRight);
            this.Controls.Add(this._SFUKK01401UAUnpinnedTabAreaLeft);
            this.Controls.Add(this._SFUKK01401UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SFUKK01401UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFUKK01401UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SFUKK01401UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKK01401UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入金伝票入力";
            this.Load += new System.EventHandler(this.SFUKK01401UA_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.onClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            this.dockableWindow1.ResumeLayout(false);
            this._SFUKK01401UAAutoHideControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).EndInit();
            this.Main_UTabControl.ResumeLayout(false);
            this.ultraTabSharedControlsPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		# region Private const Menbers
		/// <summary>入金伝票入力(入金型)タブ</summary>
		private const string TAB_NORMALTYPE = "NormalType";
		
		/// <summary>入金伝票入力(売上指定型)タブ</summary>
		private const string TAB_SALESTYPE = "SalesTypeAcs";
		
		/// <summary>ダミータブ</summary>
		private const string NO_TAB = "";
		# endregion

		# region Private Menbers
		/// <summary>入金伝票入力設定データ系アクセスクラス</summary>
		private DepositRelDataAcs depositRelDataAcs;

		/// <summary>スライダーパネルクラス(入金型)</summary>
		private SFCMN00221UA _superSliderDepo;

		/// <summary>   </summary>
		private SFCMN00221UA _superSliderOrder;

		/// <summary>番号タイプ管理マスタアクセスクラス</summary>
		private NoMngSetAcs noMngSetAcs;

		/// <summary>Tab子画面表示パラメータ</summary>
		private int _parameter;
		
		/// <summary>現在選択画面タイプ</summary>
		private object selectedDispTypeItem;

		/// <summary>現在選択拠点</summary>
		private object selectedSection;

		/// <summary>画面タイプ選択中フラグ</summary>
		private bool selectDispTypeFlg;

		/// <summary>拠点選択中フラグ</summary>
		private bool selectedSectionFlg;

		/// <summary>起動モード</summary>
		private StartingMode _startingMode;

		/// <summary>起動パラメータ</summary>
		private StartingParameter _startingParameter;

		/// <summary>ウィンドウ状態保持用</summary>
		private MemoryStream _dockMemoryStream;

        // ↓ 20070131 18322 a MA.NS用に追加
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // ↑ 20070131 18322 a

        /// <summary>請求計上拠点</summary>
        private string _demandAddUpSecCd;

		/// <summary>初回起動フラグ</summary>
		/// <remarks>0:初回, 1:２回目以降</remarks>
		private int _firstStartFlg;

        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト
		# endregion

        /// <summary>
        /// オペレーションコード
        /// </summary>
        internal enum OperationCode : int
        {
            /// <summary>修正</summary>
            Revision = 10,
            /// <summary>削除</summary>
            Delete = 11,
            /// <summary>赤伝</summary>
            RedSlip = 12,
        }

        // 操作権限の制御オブジェクトの保有
        /// <summary>
        /// 操作権限の制御オブジェクトを取得します。
        /// </summary>
        /// <value>操作権限の制御オブジェクト</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("SFUKK01400U", this);
                }
                return _operationAuthority;
            }
        }

        /// <summary>
        /// 操作権限の制御を開始します。
        /// </summary>
        private void BeginControllingByOperationAuthority()
        {
            // 伝票削除ボタン
            if (MyOpeCtrl.Disabled((int)OperationCode.Delete))
            {
                Main_ToolbarsManager.Tools["btnDelete"].SharedProps.Visible = false;
                Main_ToolbarsManager.Tools["btnDelete"].SharedProps.Shortcut = Shortcut.None;
            }

            // 赤伝ボタン
            if (MyOpeCtrl.Disabled((int)OperationCode.RedSlip))
            {
                Main_ToolbarsManager.Tools["btnAka"].SharedProps.Visible = false;
                Main_ToolbarsManager.Tools["btnAka"].SharedProps.Shortcut = Shortcut.None;
            }
        }

		# region Public Methods
		/// <summary>
		/// 入金伝票入力画面表示処理
		/// </summary>
		/// <param name="startingMode">起動モード</param>
		/// <param name="startingParameter">起動パラメータ</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : 入金伝票入力画面を起動します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public void Show(StartingMode startingMode, StartingParameter startingParameter)
		{
			// 起動モード
			this._startingMode = startingMode;

			// 起動パラメータ
			this._startingParameter = startingParameter;

			// 派生元呼び出し(本来のShowメソッド呼び出し)
			((Control)this).Show();
		}

		/// <summary>
		/// 入金伝票入力画面表示処理
		/// </summary>
		/// <param name="startingMode">起動モード</param>
		/// <param name="startingParameter">起動パラメータ</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : 入金伝票入力画面を起動します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public void ShowDialog(StartingMode startingMode, StartingParameter startingParameter)
		{
			// 起動モード
			this._startingMode = startingMode;

			// 起動パラメータ
			this._startingParameter = startingParameter;

			// 画面起動
			this.ShowDialog();
		}

		/// <summary>
		/// 顧客選択イベント(スライダーにて顧客選択時に発生)
		/// </summary>
		/// <param name="selectData">顧客選択情報</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : 顧客選択イベント(スライダーにて顧客選択時に発生)</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
        // ↓ 20070219 18322 c MA.NS用に変更
		//public void SelectedCustomerCar(CustomerCarSearchAcsRet selectData)
		//{

		public void SelectedCustomerCar(CustomerSearchRet selectData)
		{
        // ↑ 20070219 18322 c
			// 顧客が選択され場合に飛び込みます
			if (selectData != null)
			{
				// 子画面のデータ表示指示 (得意先コード指定モード)
				this.RefreshTabChildCustomerMode(selectData.CustomerCode);
			}
		}

        // ↓ 20070519 18322 d MK.NSでは使用しないので削除(SFMIT01207Eを使用)
		///// <summary>
		///// 伝票選択イベント(スライダーにて伝票選択時に発生)
		///// </summary>
		///// <param name="seldata">伝票選択情報</param>
		///// <returns>none</returns>
		///// <remarks>
		///// <br>Note       : 伝票選択イベント(スライダーにて伝票選択時に発生)</br>
		///// <br>Programer  : 97036 amami</br>
		///// <br>Date       : 2005.07.30</br>
		///// </remarks>
		//public void ModifyOrder(AcceptOdrSearchAcsRet seldata)
		//{
		//	// 伝票が選択され場合に飛び込みます
		//	if (seldata != null)
		//	{
        //        // ↓ 20070130 18322 c MA.NS用に変更
		//		//// 子画面のデータ表示指示 (受注番号指定モード)
		//		//this.RefreshTabChildAcceptAnOrderMode(seldata.CustomerCode, seldata.AcceptAnOrderNo);
        //
		//		// 子画面のデータ表示指示 (受注番号指定モード)
		//		this.RefreshTabChildSlipNumberMode(seldata.CustomerCode, seldata.AcceptAnOrderNo, "");
        //        // ↑ 20070130 18322 c
		//	}
		//}
        // ↑ 20070519 18322 d
		# endregion

		#region Private Delegate Methods
		/// <summary>
		/// ツールバーボタン制御イベント
		/// </summary>
		/// <param name="sender">オブジェクト</param>
		/// <remarks>
		/// <br>Note       : フレームのボタン有効無効制御をしたい場合に発生させます。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void ParentToolbarSettingEvent(object sender)
		{
			ToolBarButtonEnabledSetting(sender);
		}

		/// <summary>
		/// 拠点コード取得
		/// </summary>
		/// <param name="sender">オブジェクト</param>
		/// <remarks>
		/// <br>Note       : フレームにて選択されている拠点コードを取得します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private string GetSelectSectionCodeEvent(object sender)
		{
            // 現在選択拠点を返す
            ValueListItem secInfoList = selectedSection as ValueListItem;
            if (secInfoList != null)
            {
                return secInfoList.DataValue.ToString();
            }
            return "";
		}

        /// <summary>
        /// 請求計上拠点名称取得
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="sectionName">請求計上拠点名称</param>
        /// <remarks>
        /// <br>Note       : 請求計上拠点コードを取得します。</br>
        /// <br>Programer  : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.02.20</br>
        /// </remarks>
        private void HandOverAddUpSecNameEvent(object sender, string sectionName)
        {
            // 請求計上拠点を表示
            Main_ToolbarsManager.Tools["SectionCode_l"].SharedProps.Caption = sectionName;
        }
		#endregion

		# region Private Methods
		/// <summary>
		/// スーパースライダー初期化処理
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : スーパースライダーの初期化処理を行います。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void InitializeSlider()
		{
			this._superSliderDepo = new SFCMN00221UA();						// スライダーパネルクラス(入金型)
			this._superSliderOrder = new SFCMN00221UA();					// スライダーパネルクラス(受注指定型)

			// スーパースライダーアセンブリロード・ガイド追加処理(入金型)
            // ↓ 20070219 18322 d MA.NS用に変更
			//this._superSliderDepo.IsLocalDataExtract = false;						// ローカル検索をOFF
			//this._superSliderDepo.AcceptOrderListShow = false;						// 最近使用した伝票非表示
            // ↑ 20070219 18322 d
			Panel sldpanelDepo = this._superSliderDepo.GetMainPanel(0, 10);
			SlipSearch_Panel.Controls.Add(sldpanelDepo);							// ←貼り付けるパネルを指定
			sldpanelDepo.Dock = System.Windows.Forms.DockStyle.Fill;

			// 顧客選択イベント(スライダーにて顧客選択時に発生)
            // ↓ 20070309 18322 c MA.NS用に変更
			//this._superSliderDepo.SelectedCustomerCar += new SelectedCustomerCarHandler(SelectedCustomerCar);

			this._superSliderDepo.SelectedCustomer += new SelectedCustomerHandler(SelectedCustomerCar);
            // ↑ 20070309 18322 c

			// スーパースライダーアセンブリロード・ガイド追加処理(受注指定型)
            // ↓ 20070219 18322 d MA.NS用に変更
			//this._superSliderOrder.IsLocalDataExtract = false;						// ローカル検索をOFF
            // ↑ 20070219 18322 d
			Panel sldpanelOrder = this._superSliderOrder.GetMainPanel(0, 11);
			SlipSearch_Panel.Controls.Add(sldpanelOrder);							// ←貼り付けるパネルを指定
			sldpanelOrder.Dock = DockStyle.Fill;

			//// 顧客選択イベント(スライダーにて顧客選択時に発生)
            // ↓ 20070309 18322 c MA.NS用に変更
			//this._superSliderOrder.SelectedCustomerCar += new SelectedCustomerCarHandler(SelectedCustomerCar);

			this._superSliderOrder.SelectedCustomer += new SelectedCustomerHandler(SelectedCustomerCar);
            // ↑ 20070309 18322 c
            
			//// 伝票選択イベント(伝票呼び出し選択時に発生)
			//this._superSliderOrder.ModifyOrder += new ModifyOrderHandler(ModifyOrder);
		}

		/// <summary>
		/// 番号タイプ管理マスタを取得処理
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : 番号タイプ管理マスタを取得し部品のStaticバッファへセットします。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void SearchNoMngSetAcs()
		{
			ArrayList retNoTypMngList;

			//番号タイプ管理マスタを取得し部品のStaticバッファへセット
			if (this.noMngSetAcs == null) this.noMngSetAcs = new NoMngSetAcs();
			if (this.noMngSetAcs.Search(out retNoTypMngList, LoginInfoAcquisition.EnterpriseCode) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				NumberControl.NoTypeMngList = retNoTypMngList.ToArray(typeof(NoTypeMng)) as NoTypeMng[];
			}
		}
		
		/// <summary>
		/// ツールバーボタン有効無効設定処理
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : ツールーバーボタンの有効・無効設定を行います。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
        /// <br>Update Note: 2012/12/24 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : Redmine#33741の対応</br>
		/// </remarks>
		private void ToolBarButtonEnabledSetting(object sender)
		{
            if (this.Main_UTabControl.ActiveTab == null)
            {
                return;
            }

			// アクティブ状態のタブからフォームを取得する
			Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;

			// 割当済の時は表示する
			// IDepositInputMDIChildインターフェイスを実装している場合は以下を実行する。
			if ((frm == null) || (!(frm is IDepositInputMDIChild))) return;

			// 保存ボタン
			ButtonTool ButtonSave = Main_ToolbarsManager.Tools["btnSave"] as ButtonTool;
			if (ButtonSave != null) ButtonSave.SharedProps.Enabled = ((IDepositInputMDIChild)frm).SaveButton;

			// 新規ボタン
			ButtonTool ButtonNew = Main_ToolbarsManager.Tools["btnNew"] as ButtonTool;
			if (ButtonNew != null) ButtonNew.SharedProps.Enabled = ((IDepositInputMDIChild)frm).NewButton;

			// 削除ボタン
			ButtonTool ButtonDel = Main_ToolbarsManager.Tools["btnDelete"] as ButtonTool;
			if (ButtonDel != null) ButtonDel.SharedProps.Enabled = ((IDepositInputMDIChild)frm).DeleteButton;

			// 赤伝ボタン
			ButtonTool ButtonAka = Main_ToolbarsManager.Tools["btnAka"] as ButtonTool;
			if (ButtonAka != null) ButtonAka.SharedProps.Enabled = ((IDepositInputMDIChild)frm).AkaButton;

			// 領収書発行ボタン
			ButtonTool ButtonReceiptPrint = Main_ToolbarsManager.Tools["btnReceiptPrint"] as ButtonTool;
			if (ButtonReceiptPrint != null) ButtonReceiptPrint.SharedProps.Enabled = ((IDepositInputMDIChild)frm).ReceiptPrintButton;

            // 最新情報ボタン
            ButtonTool ButtonRenewal = Main_ToolbarsManager.Tools["btnRenewal"] as ButtonTool;
            if (ButtonRenewal != null) ButtonRenewal.SharedProps.Enabled = ((IDepositInputMDIChild)frm).RenewalButton;

            // -------　ADD 王君 2012/12/24 Redmine#33741 -------->>>>>
            // 入金伝票呼出ボタン
            ButtonTool ButtonReadSlip = Main_ToolbarsManager.Tools["btnReadSlip"] as ButtonTool;
            if (ButtonReadSlip != null) ButtonReadSlip.SharedProps.Enabled = ((IDepositInputMDIChild)frm).ReadSlipButton;
            // -------　ADD 王君 2012/12/24 Redmine#33741 --------<<<<<
            BeginControllingByOperationAuthority();
		}
		
		/// <summary>
		/// ツールボタン処理
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : ツールボタンの初期設定を行います。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
        /// <br>Update Note: 2012/12/24 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : Redmine#33741の対応</br>
		/// </remarks>
		private void ToolButtonSetting()
		{
			// イメージリストを設定する
			Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

			// 拠点
			LabelTool kyotenLabel = Main_ToolbarsManager.Tools["KYOTENNM"] as LabelTool;
			if (kyotenLabel != null) kyotenLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;

			// ログイン担当者
			LabelTool loginEmployeeLabel = Main_ToolbarsManager.Tools["LOGINTITLE"] as LabelTool;
			if (loginEmployeeLabel != null) loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

			// 終了ボタン
			ButtonTool buttonClose = Main_ToolbarsManager.Tools["btnClose"] as ButtonTool;
			if (buttonClose != null) buttonClose .SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

			// 保存ボタン
			ButtonTool ButtonSave = Main_ToolbarsManager.Tools["btnSave"] as ButtonTool;
			if (ButtonSave != null)
			{
				ButtonSave.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
				ButtonSave.SharedProps.Enabled = false;
			}

			// 新規ボタン
			ButtonTool ButtonNew = Main_ToolbarsManager.Tools["btnNew"] as ButtonTool;
			if (ButtonNew != null) 
			{
				ButtonNew.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
				ButtonNew.SharedProps.Enabled = false;
			}

			// 削除ボタン
			ButtonTool ButtonDel = Main_ToolbarsManager.Tools["btnDelete"] as ButtonTool;
			if (ButtonDel != null)
			{
				ButtonDel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
				ButtonDel.SharedProps.Enabled = false;
			}

			// 赤伝ボタン
			ButtonTool ButtonAka = Main_ToolbarsManager.Tools["btnAka"] as ButtonTool;
			if (ButtonAka != null)
			{
				ButtonAka.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.REDSLIP;
				ButtonAka.SharedProps.Enabled = false;
			}

			// 領収書発行ボタン
			ButtonTool ButtonReceiptPrint = Main_ToolbarsManager.Tools["btnReceiptPrint"] as ButtonTool;
			if (ButtonReceiptPrint != null)
			{
				ButtonReceiptPrint.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
				ButtonReceiptPrint.SharedProps.Enabled = false;
			}

            // 最新情報ボタン
            ButtonTool ButtonRenewal = Main_ToolbarsManager.Tools["btnRenewal"] as ButtonTool;
            if (ButtonRenewal != null)
            {
                ButtonRenewal.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
                ButtonRenewal.SharedProps.Enabled = false;
            }

            // ---- ADD 王君 2012/12/24 Redmine#33741 ---------->>>>>
            // 入金伝票呼出ボタン
            ButtonTool ButtonReadSlip = Main_ToolbarsManager.Tools["btnReadSlip"] as ButtonTool;
            if (ButtonReadSlip != null)
            {
                ButtonReadSlip.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPSEARCH;
                ButtonReadSlip.SharedProps.Enabled = false;
            }
            // ---- ADD 王君 2012/12/24 Redmine#33741 ----------<<<<<
            // ↓ 20070514 18322 c 領収書を作成するまでボタンを非表示にする。
            ButtonReceiptPrint.SharedProps.Visible = false;
            // ↑ 20070514 18322 c
		}

		/// <summary>
		/// 拠点リスト設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 拠点リストの設定を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SectionSetting()
		{
            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //Infragistics.Win.UltraWinToolbars.LabelTool labKyoten = Main_ToolbarsManager.Tools["KYOTENNM"] as Infragistics.Win.UltraWinToolbars.LabelTool;
            //Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbKyoten = Main_ToolbarsManager.Tools["KYOTENCOMBO"] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
            //if ((labKyoten != null) && (cmbKyoten != null))
            //{
            //    // 拠点リストを設定
            //    Infragistics.Win.ValueList secInfoList = new Infragistics.Win.ValueList();
            //    for (int ix = 0; ix < depositRelDataAcs.SlSection.Count; ix++)
            //    {
            //        Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
            //        secInfoItem.DataValue	= depositRelDataAcs.SlSection.GetKey(ix);
            //        secInfoItem.DisplayText	= (string)depositRelDataAcs.SlSection.GetByIndex(ix);
            //        secInfoList.ValueListItems.Add(secInfoItem);
            //    }
            //    cmbKyoten.ValueList = secInfoList;

            //    // 請求計上拠点をセット
            //    cmbKyoten.Value = this.depositRelDataAcs.DemandAddUpSecCd;

            //    // 本社機能拠点ではない時は表示を消す
            //    // ※拠点オプションが無い時は本社機能フラグはOFFになっている
            //    if (depositRelDataAcs.MainOfficeFuncFlag == 0)
            //    {
            //        labKyoten.SharedProps.Visible = false;
            //        cmbKyoten.SharedProps.Visible = false;
            //    }
            //}
            LabelTool labKyoten = Main_ToolbarsManager.Tools["KYOTENNM"] as LabelTool;
            LabelTool labKyotenNm = Main_ToolbarsManager.Tools["SectionCode_l"] as LabelTool;
            if ((labKyoten != null) && (labKyotenNm != null))
            {
                for (int ix = 0; ix < depositRelDataAcs.SlSection.Count; ix++)
                {
                    if ((string)depositRelDataAcs.SlSection.GetKey(ix) == this.depositRelDataAcs.DemandAddUpSecCd)
                    {
                        // 請求計上拠点名称をセット
                        labKyotenNm.SharedProps.Caption = (string)depositRelDataAcs.SlSection.GetByIndex(ix);
                        break;
                    }
                }
                
                // 本社機能拠点ではない時は表示を消す
                // ※拠点オプションが無い時は本社機能フラグはOFFになっている
                if (depositRelDataAcs.MainOfficeFuncFlag == 0)
                {
                    labKyoten.SharedProps.Visible = false;
                    labKyotenNm.SharedProps.Visible = false;
                }
            }
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
		}

		/// <summary>
		/// 画面タイプコンボボックス処理
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : ツールバーを初期設定する</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
        /// <br>Update Note: 2015/08/18 李侠</br>
        /// <br>管理番号   : 11170129-00 【№85】入金伝票入力の障害対応</br>
        /// <br>           : Redmine#47016 「最新情報」ボタンを押下した後、画面タイプリストを変更する場合、例外エラーの対応</br>
		/// </remarks>
		private void SetDispTypList()
		{
			// 画面タイプコンボボックスの取得
			ComboBoxTool dispTypeList = Main_ToolbarsManager.Tools["DispTypeList"] as ComboBoxTool;

			if (dispTypeList != null)
			{
				ValueList vl = new ValueList();

				// 画面タイプリストを作成
				foreach (DictionaryEntry myDE in depositRelDataAcs.SlDispType)
				{
					vl.ValueListItems.Add(myDE.Key, (string)myDE.Value);
				}

				// 画面タイプリストを設定
				dispTypeList.ValueList = vl;

                //----- ADD 2015/08/18 李侠 Redmine#47016 画面タイプリストを変更する場合、例外エラーの対応 ---------->>>>>
                // 現在選択画面タイプを保持
                selectedDispTypeItem = dispTypeList.SelectedItem;
                //----- ADD 2015/08/18 李侠 Redmine#47016 画面タイプリストを変更する場合、例外エラーの対応 ----------<<<<<
			}
		}

		/// <summary>
		/// デフォルト画面タイプ選択処理
		/// </summary>
		/// <param name="startingMode">起動モード</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : デフォルトの画面タイプを選択し起動します</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void DefaultSelectDispTypy(StartingMode startingMode)
		{
			// 画面タイプコンボボックスの取得
			ComboBoxTool dispTypeList = (ComboBoxTool)Main_ToolbarsManager.Tools["DispTypeList"];

			// デフォルト画面タイプを設定
			switch (startingMode)
			{
				case StartingMode.Normal :				// --- ノーマルモード --- //
				case StartingMode.CustomerCode :		// --- 得意先コード指定モード --- //
					
					// ただし、引当不可で受注指定型はだめ
					if ((depositRelDataAcs.AllowanceProc == 2) && (depositRelDataAcs.DefaultDispType == 2))
					{
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "「引当処理区分=不可」 の設定の為、「受注指定型」では起動できません。" + "\r\n\r\n" +
							"「入金型」で起動を行います。" + "\r\n\r\n" +
							"入金設定、請求設定 を確認してください。", 0, MessageBoxButtons.OK);
						depositRelDataAcs.DefaultDispType = 1;
					}
				
					dispTypeList.SelectedItem = dispTypeList.ValueList.FindByDataValue(depositRelDataAcs.DefaultDispType);

					break;
                // ↓ 20070129 18322 c MA.NS用に変更
				//case StartingMode.AcceptAnOrderNo :		// --- 受注番号指定モード: 入金型で起動 --- //
                //    
				//	dispTypeList.SelectedItem = dispTypeList.ValueList.FindByDataValue(1);
				//	
				//	break;

				case StartingMode.SalesSlipNum :		// --- 売上伝票番号指定モード: 売上伝票型で起動 --- //

					dispTypeList.SelectedItem = dispTypeList.ValueList.FindByDataValue(1);
					
					break;
                // ↑ 20070129 18322 c

				default :								// --- 終了時モード: 初期化する --- //
					
					dispTypeList.SelectedItem = null;

					break;
			}

			// 現在選択画面タイプを保持
			selectedDispTypeItem = dispTypeList.SelectedItem;
		}

		/// <summary>
		/// タブクリエイト処理
		/// </summary>
		/// <param name="key">画面種類</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : 子画面タブを生成します</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void TabCreate(string key)
		{
			// TAB子画面生成処理
			Form form = this.TabCreateAdd(key);
			
			// IDepositInputTabChildインターフェイスを実装している場合は以下の処理を実行する。
			if ((form is IDepositInputMDIChild))
			{
				// ツールバーボタン制御デリゲートの登録
				((IDepositInputMDIChild)form).ParentToolbarSettingEvent += new ParentToolbarDepositSettingEventHandler(this.ParentToolbarSettingEvent);

				// 選択拠点取得デリゲートの登録
				((IDepositInputMDIChild)form).GetSelectSectionCodeEvent += new GetDepositSelectSectionCodeEventHandler(this.GetSelectSectionCodeEvent);

                // 計上拠点取得デリゲートの登録
                ((IDepositInputMDIChild)form).HandOverAddUpSecNameEvent += new HandOverDepositAddUpSecNameEventHandler(this.HandOverAddUpSecNameEvent);

				((IDepositInputMDIChild)form).Show(this._parameter);
			}
			else 
			{
				form.Show();
			}
		}

		/// <summary>
		/// タブアクティブ化処理
		/// </summary>
		/// <param name="key">画面種類</param>
		/// <returns>処理結果</returns>
		/// <remarks>
		/// <br>Note       : 指定されたタブをアクティブ化します</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void TabActive(string key)
		{
			// タブが存在する時
			if (this.Main_UTabControl.Tabs.Exists(key))
			{
				this.Main_UTabControl.Tabs[key].Visible = true;
				this.Main_UTabControl.SelectedTab = this.Main_UTabControl.Tabs[key];
			}
		}

		/// <summary>
		/// タブ削除処理
		/// </summary>
		/// <param name="key">画面種類</param>
		/// <returns>処理結果</returns>
		/// <remarks>
		/// <br>Note       : 指定されたタブを削除します</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void TabRemove(string key)
		{
			// タブが存在する時
			if (this.Main_UTabControl.Tabs.Exists(key))
			{
				this.Main_UTabControl.Tabs.Remove(this.Main_UTabControl.Tabs[key]);
			}
		}
		
		/// <summary>
		/// TAB子画面生成処理
		/// </summary>
		/// <param name="key">画面種類</param>
		/// <returns>フォームクラス</returns>
		/// <remarks>
		/// <br>Note       : TAB子画面を生成します</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.05.19</br>
		/// </remarks>
		private Form TabCreateAdd(string key)
		{
			Form form = null;

			// クラスインスタンス化処理
			switch (key)
			{
				case TAB_NORMALTYPE:
					{
						form = new SFUKK01403UA();
						break;
					}
				case TAB_SALESTYPE:
					{
						form = new SFUKK01406UA();
						break;
					}
				default:
					{
						return null;
					}
			}

			// フォームプロパティ変更
			form.TopLevel = false;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Dock = DockStyle.Fill;

			// タブの外観を設定し、タブコントロールにタブを追加する
			UltraTab dataviewTab = this.Main_UTabControl.Tabs.Add(key);

			dataviewTab.Text = form.Text;
			dataviewTab.Tag = form;
			dataviewTab.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2];
			dataviewTab.TabPage.Controls.Add(form);

			this.Main_UTabControl.Controls.Add(dataviewTab.TabPage);

			return form;
		}
		
		/// <summary>
		/// Tab子画面のデータ表示指示 (得意先コード指定モード)
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
		/// <remarks>
		/// <br>Note       : Tab子画面のデータ表示指示</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void RefreshTabChildCustomerMode(int customerCode)
		{
			// パラメータが正常なとき
			if (customerCode != 0)
			{
				// 現在、アクティブな画面を取得する
				Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;

				if (frm != null)
				{
					// IDepositInputMDIChildインターフェイスを実装している場合は以下の処理を実行する。
					if ((frm is IDepositInputMDIChild))
					{
						object[] parameter = new object[1] {customerCode};

						((IDepositInputMDIChild)frm).ShowData(0, parameter);
					}
				}
			
				if (!this.Main_DockManager.ControlPanes[0].Pinned && this.Main_DockManager.ControlPanes[0].Manager.FlyoutPane != null)
					this.Main_DockManager.ControlPanes[0].Manager.FlyIn(true);
			}
		}

        /// <summary>
		/// Tab子画面のデータ表示指示 (受注番号指定モード)
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="acceptAnOrderNo">受注番号</param>
		/// <remarks>
		/// <br>Note       : Tab子画面のデータ表示指示</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void RefreshTabChildAcceptAnOrderMode(int customerCode, int acceptAnOrderNo)
		{
            // パラメータが正常なとき
			if ((customerCode != 0) && (acceptAnOrderNo != 0))
			{
				// 現在、アクティブな画面を取得する
				Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;
            
				if (frm != null)
				{
					// IDepositInputMDIChildインターフェイスを実装している場合は以下の処理を実行する。
					if ((frm is IDepositInputMDIChild))
					{
						object[] parameter = new object[2] {customerCode, acceptAnOrderNo};
            
						((IDepositInputMDIChild)frm).ShowData(1, parameter);
					}
				}
			
				if (!this.Main_DockManager.ControlPanes[0].Pinned && this.Main_DockManager.ControlPanes[0].Manager.FlyoutPane != null)
					this.Main_DockManager.ControlPanes[0].Manager.FlyIn(true);
			}
        }

        // ↓ 20070130 18322 a MA.NS用に変更
        /// <summary>
		/// Tab子画面のデータ表示指示 (伝票番号指定モード)
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="acceptAnOrderNo">受注番号</param>
		/// <param name="salesSlipNum">売上伝票番号</param>
		/// <remarks>
		/// <br>Note       : Tab子画面のデータ表示指示</br>
		/// <br>Programer  : 18322 T.Kimura</br>
		/// <br>Date       : 2007.01.30</br>
        /// <br>               MA.NS用に変更</br>
		/// </remarks>
		private void RefreshTabChildSlipNumberMode(int customerCode, int acceptAnOrderNo, string salesSlipNum)
		{
            // パラメータが正常なとき
			if ((customerCode != 0) && ((acceptAnOrderNo != 0) || (salesSlipNum != "")))
			{
				// 現在、アクティブな画面を取得する
				Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;
            
				if (frm != null)
				{
					// IDepositInputMDIChildインターフェイスを実装している場合は以下の処理を実行する。
					if ((frm is IDepositInputMDIChild))
					{
						object[] parameter = new object[3] {customerCode, acceptAnOrderNo, salesSlipNum};
            
						((IDepositInputMDIChild)frm).ShowData(1, parameter);
					}
				}
			
				if (!this.Main_DockManager.ControlPanes[0].Pinned && this.Main_DockManager.ControlPanes[0].Manager.FlyoutPane != null)
					this.Main_DockManager.ControlPanes[0].Manager.FlyIn(true);
			}
        }
        // ↑ 20070130 18322 a


        /// <summary>
		/// ウィンドウ初期化処理
		/// </summary>
		/// <param>none</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ウィンドウを初期化する</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void InitWindow()
		{
			if (this._dockMemoryStream == null)
			{
				return;
			}

			this._dockMemoryStream.Position = 0;

			this.Main_DockManager.LoadFromBinary(this._dockMemoryStream);
		}
		
		/// <summary>
		/// 文字列型の数字を数字型に変更する
		/// </summary>
		/// <param>none</param>
		/// <returns>false:確定は不要,true:確定が必要</returns>
		/// <remarks>
		/// <br>Note       : 文字列型の数字を数字型に変更する</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private int StrToIntDef(string s, int defInt)
		{
			try
			{
				return Convert.ToInt32(s);
			}
			catch(Exception)
			{
				return 0;
			}
		}
		# endregion

		# region Control Events
		/// <summary>
		/// メインフレームのLOADイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : メインフレームのLOADイベント</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void SFUKK01401UA_Load(object sender, EventArgs e)
		{
            // 初回起動フラグ
			if (this._firstStartFlg == 0)
			{
                // ↓ 20070131 18322 c MA.NS用に変更
                // 画面スキンファイルの読込(デフォルトスキン指定)
                this._controlScreenSkin.LoadSkin();

                // 画面スキン変更
                this._controlScreenSkin.SettingScreenSkin(this);
                // ↑ 20070131 18322 c

                // 入金伝票入力関連設定データ取得処理
				string errmsg;
                int st = this.depositRelDataAcs.GetInitialSettingData(out errmsg);
                if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // エラー発生
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, errmsg, st, MessageBoxButtons.OK);
                    return;
                }

				// ログイン担当者を表示
				Main_ToolbarsManager.Tools["LoginName_LabelTool"].SharedProps.Caption = ((Employee)LoginInfoAcquisition.Employee).Name;

				// ツールボタン処理
				this.ToolButtonSetting();

				// 拠点リスト設定処理
				this.SectionSetting();

				// 画面タイプコンボボックス処理
				this.SetDispTypList();

                BeginControllingByOperationAuthority();

				++this._firstStartFlg;
			}

			// 起動タイマー開始
			startTimer.Enabled = true;
		}

		/// <summary>
		/// 起動タイマー開始イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : 起動処理を行います。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void startTimer_Tick(object sender, EventArgs e)
		{
			// 起動タイマー終了
			startTimer.Enabled = false;

			// スーパースライダー初期化処理
            this.InitializeSlider();

			// デフォルト画面タイプ選択処理
			this.DefaultSelectDispTypy(this._startingMode);

			// 起動モードが指定されている時は
			switch (this._startingMode)
			{
				case StartingMode.CustomerCode :		// --- 得意先コード指定モード --- //

					// Tab子画面のデータ表示指示 (得意先コード指定モード)
					this.RefreshTabChildCustomerMode(this._startingParameter.CustomerCode);

					break;
                
                // ↓ 20070130 18322 c MA.NS用に変更
				//case StartingMode.AcceptAnOrderNo :		// --- 受注番号指定モード --- //
                //    
				//	// Tab子画面のデータ表示指示 (伝票番号指定モード)
				//	this.RefreshTabChildAcceptAnOrderMode(this._startingParameter.CustomerCode, this._startingParameter.AcceptAnOrderNo);
				//	
				//	break;

				case StartingMode.SalesSlipNum :		// --- 売上伝票番号指定モード --- //

					// Tab子画面のデータ表示指示 (売上伝票番号指定モード)
					this.RefreshTabChildSlipNumberMode(this._startingParameter.CustomerCode, 0, this._startingParameter.SalesSlipNum);
					
					break;
                // ↑ 20070130 18322 c
			}

			// DockManagerの状態を保持する
			this._dockMemoryStream = new MemoryStream();
			this.Main_DockManager.SaveAsBinary(this._dockMemoryStream);
		}

		/// <summary>
		/// ToolBarのclick・イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : ToolBarのclick・イベント</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
        /// <br>Update Note: 2012/12/24 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : Redmine#33741の対応</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "btnClose":			// --- 終了 --- //
				{
					// メイン画面のクローズ
					this.Close();
					return;
				}
				case "btnInitWindow":		// --- ウィンドウを初期化する --- //
				{
					// ウィンドウ初期化処理
					this.InitWindow();
					return;
				}
			}

			// 現在、アクティブな画面を取得する
			Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;

			// IDepositInputMDIChildインターフェイスを実装している場合のみ以下実行
			if ((frm == null) || (!(frm is IDepositInputMDIChild))) return;

			switch (e.Tool.Key)
			{
				case "btnSave":				// --- 保存 --- //
				{
                    DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                            "SFUKK01401U",
                                            "登録してもよろしいですか？",
                                            0,
                                            MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No)
                    {
                        return;
                    }

					// 保存処理
					((IDepositInputMDIChild)frm).SaveDepositProc();
					break;
				}
				case "btnNew":				// --- 新規 --- //
				{
					// 新規処理
					((IDepositInputMDIChild)frm).NewDepositProc();
					break;
				}
				case "btnDelete":			// --- 削除 --- //
				{
					// 削除処理
					((IDepositInputMDIChild)frm).DeleteDepositProc();
					break;
				}
			case "btnAka":					// --- 赤伝 --- //
				{
					// 赤伝処理
					((IDepositInputMDIChild)frm).AkaDepositProc();
					break;
				}
			case "btnReceiptPrint":			// --- 領収書発行 --- //
				{
					// 領収書発行処理
					((IDepositInputMDIChild)frm).ReceiptPrintProc();
					break;
				}
            case "btnRenewal":
                {
                    ((IDepositInputMDIChild)frm).RenewalProc();
                    // 2009/07/21 >>>>>>>>>>>>>>>>>>
                    SetDispTypList();
                    // 2009/07/21 <<<<<<<<<<<<<<<<<<
                    break;
                }

            // ----- ADD 王君 2012/12/24 Redmine#33741 ---------->>>>> 
            case "btnReadslip":             // --- 入金伝票呼出 --- //
                {
                    ((IDepositInputMDIChild)frm).ReadSlipProc();
                    break;
                }
            // ----- ADD 王君 2012/12/24 Redmine#33741 ----------<<<<<
			}
		}

		/// <summary>
		/// フォームＣＬＯＳＥ・イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : フォームＣＬＯＳＥ・イベント</br>
		/// <br>Programer  : 97036 amami</br>
        /// <br>Date       : 2005.07.30</br>
        /// <br>Update Note: 2013/02/05 田建委</br>
        /// <br>管理番号   : 10801804-00 2013/03/13配信分</br>
        /// <br>           : Redmine#33735 画面を閉じるとき、例外が起こる対応</br>
		/// </remarks>
		private void onClosing(object sender, CancelEventArgs e)
		{
			// 現在、アクティブな画面を取得する
			Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;

			// 割当済の時は表示する
			// IDepositInputMDIChildインターフェイスを実装している場合は以下の処理を実行する。
			if ((frm != null) && ((frm is IDepositInputMDIChild)))
			{
				object parameter = null;
				if (((IDepositInputMDIChild)frm).BeforeClose(parameter) != 0)
				{
					e.Cancel = true;
					return;
				}
			}

			if (this.Main_UTabControl.Tabs.Exists(TAB_NORMALTYPE))
			{
				// スライダーの表示内容を保存する
				if (this._superSliderDepo != null) this._superSliderDepo.ClosePanel();
			}
			if (this.Main_UTabControl.Tabs.Exists(TAB_SALESTYPE))
			{
				// スライダーの表示内容を保存する
				if (this._superSliderOrder != null) this._superSliderOrder.ClosePanel();
			}

			// タブ削除処理
			TabRemove(TAB_NORMALTYPE);
			TabRemove(TAB_SALESTYPE);

            // 得意先検索タブ削除処理
            this.Main_DockManager.HostControl = null;// ADD 2013/02/05 田建委 Redmine#33735

			// デフォルト画面タイプ選択処理
			this.DefaultSelectDispTypy(StartingMode.Closed);
		}

		/// <summary>
		/// ツールバー内容選択イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : ツールバーの各アイテム内容が選択された時に発生します</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolValueChanged(object sender, ToolEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "DispTypeList":			// --- 画面タイプ選択 --- //
					{
						// 二重起動防止フラグ判定
						if (selectDispTypeFlg == true) return;

						// 画面タイプコンボボックスの取得
						ComboBoxTool dispTypeList = (ComboBoxTool)e.Tool;
						if (dispTypeList.Value == null) return;

						// 現在アクティブタブがあるか
						if (this.Main_UTabControl.ActiveTab != null)
						{
							// 現在、アクティブな画面を取得する
							Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;

							// 割当済の時は表示する
							// IDepositInputMDIChildインターフェイスを実装している場合は以下の処理を実行する。
							if ((frm != null) && ((frm is IDepositInputMDIChild)))
							{
								object parameter = null;
								if (((IDepositInputMDIChild)frm).BeforeTabChange(parameter) != 0)
								{
									// 前回選択画面タイプに戻す 当イベントの二重起動防止フラグ使用
									selectDispTypeFlg = true;
                                    // --------- ADD BY zhujw 2014/07/08 RedMine#42902の⑧ 既存の障害改修---->>>>>
                                    if (null != selectedDispTypeItem)
                                    {
                                        for (int i = 0; i < dispTypeList.ValueList.ValueListItems.Count; i++)
                                        {
                                            if (dispTypeList.ValueList.ValueListItems[i].DisplayText == ((Infragistics.Win.ValueListItem)selectedDispTypeItem).DisplayText)
                                            {
                                                selectedDispTypeItem = dispTypeList.ValueList.ValueListItems[i];
                                            }
                                        }
                                    }
                                    // --------- ADD BY zhujw 2014/07/08 RedMine#42902の⑧ 既存の障害改修----<<<<<
									dispTypeList.SelectedItem = selectedDispTypeItem;
									selectDispTypeFlg = false;
									return;
								}
							}
						}

						// タブ削除処理
						TabRemove(TAB_NORMALTYPE);
						TabRemove(TAB_SALESTYPE);

						switch ((int)dispTypeList.Value)
						{
							case 1:

								// タブ生成
								this.TabCreate(TAB_NORMALTYPE);

								// タブアクティブ化処理
								this.TabActive(TAB_NORMALTYPE);

								// 入金型用スライダーの表示
								SlipSearch_Panel.Controls[0].Visible = true;
								SlipSearch_Panel.Controls[1].Visible = false;

								break;

							case 2:

								// タブ生成
								this.TabCreate(TAB_SALESTYPE);

								// タブアクティブ化処理
								this.TabActive(TAB_SALESTYPE);

                                //// 売上指定型用スライダーの表示
                                //SlipSearch_Panel.Controls[0].Visible = false;
                                //SlipSearch_Panel.Controls[1].Visible = true;

                                // 入金型用スライダーの表示
                                SlipSearch_Panel.Controls[0].Visible = true;
                                SlipSearch_Panel.Controls[1].Visible = false;

								break;
						}

                        //// メニューバーの終了ボタンを最後尾へ移動
                        //PopupMenuTool file_PopupMenu = (PopupMenuTool)Main_ToolbarsManager.Tools["File_PopupMenuTool"];
                        //file_PopupMenu.Tools.Remove(file_PopupMenu.Tools["btnClose"]);
                        //file_PopupMenu.Tools.AddTool("btnClose");

						// 現在選択画面タイプを保持
						selectedDispTypeItem = dispTypeList.SelectedItem;

						break;
					}
				case "KYOTENCOMBO":			// --- 拠点選択 --- //
					{
						// 二重起動防止フラグ判定
						if (selectedSectionFlg == true) return;

						// 拠点コンボボックスの取得
						ComboBoxTool sectionList = (ComboBoxTool)e.Tool;
						if (sectionList.Value == null) return;

						// 現在アクティブタブがあるか
						if (this.Main_UTabControl.ActiveTab != null)
						{
							// 現在、アクティブな画面を取得する
							Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;

							// 割当済の時は表示する
							// IDepositInputMDIChildインターフェイスを実装している場合は以下の処理を実行する。
							if ((frm != null) && ((frm is IDepositInputMDIChild)))
							{
								// 拠点変更前通知処理
								if (((IDepositInputMDIChild)frm).BeforeSectionChange() != 0)
								{
									// 前回選択拠点に戻す 当イベントの二重起動防止フラグ使用
									selectedSectionFlg = true;
									sectionList.SelectedItem = selectedSection;
									selectedSectionFlg = false;
									return;
								}

								// 現在選択拠点を保持
								selectedSection = sectionList.SelectedItem;

								// 拠点変更後通知処理
								((IDepositInputMDIChild)frm).AfterSectionChange();
							}
						}
						else
						{
							// 現在選択拠点を保持
							selectedSection = sectionList.SelectedItem;
						}

						break;
					}
			}
		}
		# endregion

		# region Public Enum
		/// <summary>
		/// 入金伝票入力起動モード
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金伝票入力画面の起動モード列挙型です。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public enum StartingMode
		{
			/// <summary>通常モード</summary>
			Normal = 0,

			/// <summary>得意先コード指定モード</summary>
			CustomerCode = 1,

			/// <summary>受注番号指定モード</summary>
			AcceptAnOrderNo = 2,

            // ↓ 20070130 18322 a MA.NS用に変更
			/// <summary>売上伝票番号指定モード</summary>
			SalesSlipNum = 3,
            // ↑ 20070130 18322 a

			/// <summary>終了モード</summary>
			Closed = -1
		}
		# endregion

		# region Public class (parameter)
		/// <summary>
		/// 入金伝票入力起動パラメーター
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金伝票入力画面の起動パラメータークラスです。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
        /// <br>Update Note: 2007.01.30 18322 T.Kimura MA.NS用に変更</br>
		/// </remarks>
		public class StartingParameter
		{
			/// <summary>コンストラクタ</summary>
			public StartingParameter()
			{
				_addSectionCode = "";
				_acceptAnOrderNo = 0;
				_customerCode = 0;
                // ↓ 20070130 18322 a MA.NS用に変更
                _salesSlipNum = "";
                // ↑ 20070130 18322 a
			}

			/// <summary>計上拠点</summary>
			private string _addSectionCode;

			/// <summary>受注番号</summary>
			private Int32 _acceptAnOrderNo;

			/// <summary>得意先コード</summary>
			private Int32 _customerCode;

            // ↓ 20070130 18322 a MA.NS用に変更
			/// <summary>売上伝票番号</summary>
			private string _salesSlipNum;
            // ↑ 20070130 18322 a

			/// <summary>計上拠点 プロパティ</summary>
			public string AddSectionCode
			{
				get{return _addSectionCode;}
				set{_addSectionCode = value;}
			}

			/// <summary>受注番号 プロパティ</summary>
			public Int32 AcceptAnOrderNo
			{
				get{return _acceptAnOrderNo;}
				set{_acceptAnOrderNo = value;}
			}

			/// <summary>得意先コード プロパティ</summary>
			public Int32 CustomerCode
			{
				get{return _customerCode;}
				set{_customerCode = value;}
			}

            // ↓ 20070130 18322 a MA.NS用に変更
			/// <summary>売上伝票番号 プロパティ</summary>
			public string SalesSlipNum
			{
				get{return _salesSlipNum;}
				set{_salesSlipNum = value;}
			}
            // ↑ 20070130 18322 a
        }
		# endregion

		# region Debug
		private static DateTime _dtime_s1, _dtime_e1;
		private static System.IO.FileStream _fs1 = null;
		private static System.IO.StreamWriter _sw1 = null;
		private static void DebugLogWrite(int mode, string msg)
		{
			_fs1 = new System.IO.FileStream("SFUKK01401U_Log.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
			_sw1 = new System.IO.StreamWriter(_fs1, System.Text.Encoding.GetEncoding("shift_jis"));
			if (mode == 0)
			{

				_dtime_s1 = DateTime.Now;
				TimeSpan ts = _dtime_s1.Subtract(_dtime_s1);
				string s = String.Format("{0,-20} {1,-5} ==> {2,-20} [0] {3} \n",
					_dtime_s1, _dtime_s1.Millisecond, ts.ToString(), msg);
				_sw1.WriteLine(s);
				//				System.Diagnostics.Debug.WriteLine( s );
			}
			else if (mode == 1)
			{
				_dtime_e1 = DateTime.Now;
				TimeSpan ts = _dtime_e1.Subtract(_dtime_s1);
				string s = string.Format("{0,-20} {1,-5} ==> {2,-20} [1] {3} \n",
					_dtime_e1, _dtime_e1.Millisecond, ts.ToString(), msg);

				_sw1.WriteLine(s);
				//				System.Diagnostics.Debug.WriteLine( s );

				_dtime_s1 = _dtime_e1;
			}
			else if (mode == 9)
			{
			}
			_sw1.Close();
			_fs1.Close();
		}

		private static DateTime _dtime_s2, _dtime_e2;
		private static System.IO.FileStream _fs2 = null;
		private static System.IO.StreamWriter _sw2 = null;
		private static void DebugLogWrite2(int mode, string msg)
		{
			_fs2 = new System.IO.FileStream("SFUKK01401U_Log.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
			_sw2 = new System.IO.StreamWriter(_fs2, System.Text.Encoding.GetEncoding("shift_jis"));
			if (mode == 0)
			{

				_dtime_s2 = DateTime.Now;
				TimeSpan ts = _dtime_s2.Subtract(_dtime_s2);
				string s = String.Format("{0,-20} {1,-5} ==> {2,-20} [0] {3} \n",
					_dtime_s2, _dtime_s2.Millisecond, ts.ToString(), msg);
				_sw2.WriteLine(s);
				//				System.Diagnostics.Debug.WriteLine( s );
			}
			else if (mode == 1)
			{
				_dtime_e2 = DateTime.Now;
				TimeSpan ts = _dtime_e2.Subtract(_dtime_s2);
				string s = string.Format("{0,-20} {1,-5} ==> {2,-20} [1] {3} \n",
					_dtime_e2, _dtime_e2.Millisecond, ts.ToString(), msg);

				_sw2.WriteLine(s);
				//				System.Diagnostics.Debug.WriteLine( s );

				_dtime_s2 = _dtime_e2;
			}
			else if (mode == 9)
			{
			}
			_sw2.Close();
			_fs2.Close();
		}
		# endregion

        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // ボタンを「Visible = False」にすると、イベントが発生しないため、
            // サイズを「1, 1」にし、実質的に見えないようにする

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
                this.Close();
            }
        }
	}
}
