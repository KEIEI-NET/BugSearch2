//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 請求書発行(電子帳簿連携)UIクラス
// プログラム概要   : 請求書発行(電子帳簿連携) UIフォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright 2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00   作成担当 : 陳艶丹
// 作 成 日  2022/03/07    修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11870080-00   作成担当 : 陳艶丹
// 作 成 日  2022/04/21    修正内容 : 電子帳簿2次対応
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Facade;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 請求書発行(電子帳簿連携)条件フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 請求書発行(電子帳簿連携)条件フォームクラスです。</br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2022/03/07</br>
    /// <br>Update Note  : 2020/04/21 陳艶丹</br>
    /// <br>管理番号     : 11870080-00 電子帳簿2次対応</br> 
    /// </remarks>
    public class MAKAU03000UA : System.Windows.Forms.Form
    {
        # region Private Members (Component)
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinDock.UltraDockManager Main_DockManager;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU03000UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU03000UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU03000UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU03000UA_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU03000UAUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU03000UAUnpinnedTabAreaRight;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU03000UAUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU03000UAUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.AutoHideControl _MAKAU03000UAAutoHideControl;
        private TMemPos tMemPos1;
        private ContextMenu TabControl_contextMenu;
        private MenuItem Close_menuItem;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl Main_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage DataViewTabSharedControlsPage;
        private System.ComponentModel.IContainer components;
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : コンストラクタ生成</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public MAKAU03000UA()
        {
            InitializeComponent();

            // 請求書データアクセスクラスインスタンス化
            this._demandPrintAcs = new DemandEBooksPrintAcs();

            // PDF削除リストテーブル作成
            this._delPDFList = new Hashtable();

            // PDF履歴管理部品
            this._pdfHistoryCtrl = new PdfHistoryControl();
        }
        #endregion

        // ===================================================================================== //
        // 破棄
        // ===================================================================================== //
        # region Dispose
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        /// <remarks>
        /// <br>Note        : 使用されているリソースに後処理を実行します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Sync_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Return_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PrintPreview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserSetUp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserSetUp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("PrintKindTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("PrintKind_ComboBoxTool");
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("STOP_LabelTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("PrtSuspendCnt_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool("Number_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Forms_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PrintPreview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Sync_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Return_ButtonTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKAU03000UA));
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._MAKAU03000UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU03000UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU03000UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU03000UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU03000UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.TabControl_contextMenu = new System.Windows.Forms.ContextMenu();
            this.Close_menuItem = new System.Windows.Forms.MenuItem();
            this.DataViewTabSharedControlsPage = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.Main_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this._MAKAU03000UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._MAKAU03000UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU03000UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).BeginInit();
            this.Main_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_DockManager
            // 
            this.Main_DockManager.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            this.Main_DockManager.HostControl = this;
            this.Main_DockManager.ShowCloseButton = false;
            this.Main_DockManager.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _MAKAU03000UAUnpinnedTabAreaLeft
            // 
            this._MAKAU03000UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._MAKAU03000UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03000UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 88);
            this._MAKAU03000UAUnpinnedTabAreaLeft.Name = "_MAKAU03000UAUnpinnedTabAreaLeft";
            this._MAKAU03000UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._MAKAU03000UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 623);
            this._MAKAU03000UAUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _MAKAU03000UAUnpinnedTabAreaRight
            // 
            this._MAKAU03000UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._MAKAU03000UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03000UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(1016, 88);
            this._MAKAU03000UAUnpinnedTabAreaRight.Name = "_MAKAU03000UAUnpinnedTabAreaRight";
            this._MAKAU03000UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._MAKAU03000UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 623);
            this._MAKAU03000UAUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _MAKAU03000UAUnpinnedTabAreaTop
            // 
            this._MAKAU03000UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._MAKAU03000UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03000UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 88);
            this._MAKAU03000UAUnpinnedTabAreaTop.Name = "_MAKAU03000UAUnpinnedTabAreaTop";
            this._MAKAU03000UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._MAKAU03000UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(1016, 0);
            this._MAKAU03000UAUnpinnedTabAreaTop.TabIndex = 7;
            // 
            // _MAKAU03000UAUnpinnedTabAreaBottom
            // 
            this._MAKAU03000UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._MAKAU03000UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03000UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 711);
            this._MAKAU03000UAUnpinnedTabAreaBottom.Name = "_MAKAU03000UAUnpinnedTabAreaBottom";
            this._MAKAU03000UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._MAKAU03000UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1016, 0);
            this._MAKAU03000UAUnpinnedTabAreaBottom.TabIndex = 8;
            // 
            // _MAKAU03000UAAutoHideControl
            // 
            this._MAKAU03000UAAutoHideControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03000UAAutoHideControl.Location = new System.Drawing.Point(22, 50);
            this._MAKAU03000UAAutoHideControl.Name = "_MAKAU03000UAAutoHideControl";
            this._MAKAU03000UAAutoHideControl.Owner = this.Main_DockManager;
            this._MAKAU03000UAAutoHideControl.Size = new System.Drawing.Size(233, 661);
            this._MAKAU03000UAAutoHideControl.TabIndex = 9;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point(0, 711);
            this.Main_StatusBar.Name = "Main_StatusBar";
            appearance4.TextHAlignAsString = "Left";
            this.Main_StatusBar.PanelAppearance = appearance4;
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
            this.Main_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3});
            this.Main_StatusBar.Size = new System.Drawing.Size(1016, 23);
            this.Main_StatusBar.TabIndex = 28;
            this.Main_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // TabControl_contextMenu
            // 
            this.TabControl_contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Close_menuItem});
            // 
            // Close_menuItem
            // 
            this.Close_menuItem.Index = 0;
            this.Close_menuItem.Text = "閉じる(&C)";
            this.Close_menuItem.Click += new System.EventHandler(this.Close_menuItem_Click);
            // 
            // DataViewTabSharedControlsPage
            // 
            this.DataViewTabSharedControlsPage.Location = new System.Drawing.Point(1, 20);
            this.DataViewTabSharedControlsPage.Name = "DataViewTabSharedControlsPage";
            this.DataViewTabSharedControlsPage.Size = new System.Drawing.Size(1014, 602);
            // 
            // Main_UTabControl
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Main_UTabControl.Appearance = appearance3;
            this.Main_UTabControl.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.Main_UTabControl.Controls.Add(this.DataViewTabSharedControlsPage);
            this.Main_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_UTabControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Main_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.Main_UTabControl.Location = new System.Drawing.Point(0, 88);
            this.Main_UTabControl.Name = "Main_UTabControl";
            this.Main_UTabControl.SharedControlsPage = this.DataViewTabSharedControlsPage;
            this.Main_UTabControl.Size = new System.Drawing.Size(1016, 623);
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.TabIndex = 29;
            this.Main_UTabControl.TabPadding = new System.Drawing.Size(3, 3);
            this.Main_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Main_UTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.Main_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.Main_UTabControl_SelectedTabChanged);
            // 
            // _MAKAU03000UA_Toolbars_Dock_Area_Left
            // 
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 88);
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.Name = "_MAKAU03000UA_Toolbars_Dock_Area_Left";
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 623);
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
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
            labelTool1.InstanceProps.Spring = Infragistics.Win.DefaultableBoolean.True;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            popupMenuTool3,
            labelTool1,
            labelTool2,
            labelTool3});
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            buttonTool5.InstanceProps.IsFirstInGroup = true;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8,
            buttonTool9});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "標準";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            popupMenuTool4.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool15.InstanceProps.IsFirstInGroup = true;
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            buttonTool14,
            buttonTool15});
            popupMenuTool5.SharedProps.Caption = "ツール(&T)";
            popupMenuTool5.SharedProps.Visible = false;
            popupMenuTool5.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool16});
            popupMenuTool6.SharedProps.Caption = "ウィンドウ(&W)";
            popupMenuTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool6.SharedProps.Visible = false;
            labelTool5.SharedProps.Caption = "ログイン担当者";
            labelTool5.SharedProps.ShowInCustomizer = false;
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Bottom";
            labelTool6.SharedProps.AppearancesSmall.Appearance = appearance5;
            labelTool6.SharedProps.ShowInCustomizer = false;
            labelTool6.SharedProps.Width = 150;
            buttonTool17.SharedProps.Caption = "終了(F1)";
            buttonTool17.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool17.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;
            buttonTool17.SharedProps.ShowInCustomizer = false;
            buttonTool18.SharedProps.Caption = "ユーザー設定(&C)";
            buttonTool18.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool18.SharedProps.ShowInCustomizer = false;
            labelTool7.SharedProps.Caption = "書類選択";
            labelTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            comboBoxTool1.MaxLength = 30;
            comboBoxTool1.SharedProps.Caption = "書類選択";
            valueListItem1.DataValue = ((short)(1));
            valueListItem1.DisplayText = "請求一覧表";
            valueListItem2.DataValue = ((short)(2));
            valueListItem2.DisplayText = "請求書（鑑）";
            valueListItem3.DataValue = ((short)(3));
            valueListItem3.DisplayText = "請求明細書(詳細)";
            valueListItem4.DataValue = ((short)(4));
            valueListItem4.DisplayText = "請求明細書(伝票)";
            valueListItem5.DataValue = ((short)(5));
            valueListItem5.DisplayText = "領収書";
            valueList1.ValueListItems.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5});
            comboBoxTool1.ValueList = valueList1;
            buttonTool19.SharedProps.Caption = "電子帳簿同期(&X)";
            buttonTool19.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool20.SharedProps.Caption = "PDF表示(F11)";
            buttonTool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool20.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F11;
            buttonTool21.SharedProps.Caption = "印刷(F10)";
            buttonTool21.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool21.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            labelTool8.SharedProps.Caption = "印刷一時中断枚数";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            controlContainerTool1.SharedProps.MaxWidth = 40;
            controlContainerTool1.SharedProps.MinWidth = 40;
            controlContainerTool1.SharedProps.Width = 41;
            labelTool9.SharedProps.Caption = "枚";
            labelTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool22.SharedProps.Caption = "PDF履歴保存(F12)";
            buttonTool22.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool22.SharedProps.Enabled = false;
            buttonTool22.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F12;
            buttonTool23.SharedProps.Caption = "テキスト出力(&O)";
            buttonTool23.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool23.SharedProps.Visible = false;
            popupMenuTool7.SharedProps.Caption = "タブ切替(&J)";
            popupMenuTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool7.SharedProps.ToolTipText = "画面を切り替えます。";
            buttonTool24.SharedProps.Caption = "印刷プレビュー(&W)";
            buttonTool24.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool25.SharedProps.Caption = "同期(&S)";
            buttonTool25.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool26.SharedProps.Caption = "抽出条件に戻る(F2)";
            buttonTool26.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool26.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F2;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool4,
            popupMenuTool5,
            popupMenuTool6,
            labelTool4,
            labelTool5,
            labelTool6,
            buttonTool17,
            buttonTool18,
            labelTool7,
            comboBoxTool1,
            buttonTool19,
            buttonTool20,
            buttonTool21,
            labelTool8,
            controlContainerTool1,
            labelTool9,
            buttonTool22,
            buttonTool23,
            popupMenuTool7,
            buttonTool24,
            buttonTool25,
            buttonTool26});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            // 
            // _MAKAU03000UA_Toolbars_Dock_Area_Right
            // 
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 88);
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.Name = "_MAKAU03000UA_Toolbars_Dock_Area_Right";
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 623);
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _MAKAU03000UA_Toolbars_Dock_Area_Top
            // 
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.Name = "_MAKAU03000UA_Toolbars_Dock_Area_Top";
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 88);
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _MAKAU03000UA_Toolbars_Dock_Area_Bottom
            // 
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 711);
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.Name = "_MAKAU03000UA_Toolbars_Dock_Area_Bottom";
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // MAKAU03000UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this._MAKAU03000UAAutoHideControl);
            this.Controls.Add(this.Main_UTabControl);
            this.Controls.Add(this._MAKAU03000UAUnpinnedTabAreaTop);
            this.Controls.Add(this._MAKAU03000UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._MAKAU03000UAUnpinnedTabAreaLeft);
            this.Controls.Add(this._MAKAU03000UAUnpinnedTabAreaRight);
            this.Controls.Add(this._MAKAU03000UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._MAKAU03000UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._MAKAU03000UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._MAKAU03000UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.Main_StatusBar);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAKAU03000UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "請求書系フレーム";
            this.Load += new System.EventHandler(this.MAKAU03000UA_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MAKAU03000UA_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).EndInit();
            this.Main_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        // ===================================================================================== //
        // メイン
        // ===================================================================================== //
        #region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <remarks>
        /// <br>Note        : アプリケーションのメイン エントリ ポイント。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string msg = string.Empty;
                _parameter = args;
                //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    // 起動モード取得
                    if (_parameter.Length != 0)
                    {
                        string param = _parameter[0].ToString();
                        _startMode = Broadleaf.Library.Text.TStrConv.StrToIntDef(param, 0);
                    }

                    // オンライン状態判定
                    if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        // オフライン情報
                        TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID,
                            MSG_OFFLINE, 0, MessageBoxButtons.OK);
                        form.TopMost = false;
                    }
                    else
                    {
                        System.Windows.Forms.Application.EnableVisualStyles();
                        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                        _form = new MAKAU03000UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                }
                if (status != 0)
                {
                    Form form = new Form();
                    form.TopMost = true;
                    TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, 0, MessageBoxButtons.OK);
                    form.TopMost = false;
                }
            }
            catch (Exception ex)
            {
                Form form = new Form();
                form.TopMost = true;
                TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, ex.Message, 0, MessageBoxButtons.OK);
                form.TopMost = false;
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
        /// <remarks>
        /// <br>Note        : アプリケーション終了イベント</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();
            //従業員ログオフのメッセージを表示
            Form form = new Form();
            form.TopMost = true;
            TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, e.ToString(), 0, MessageBoxButtons.OK);
            form.TopMost = false;
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
        #endregion

        // ===============================================================================
        // プライベート列挙型
        // ===============================================================================
        #region Private Enum
        /// <summary>印刷モード</summary>
        private enum emPrintMode : int
        {
            /// <summary>印刷</summary>
            emPrinter = 1,
            /// <summary>ＰＤＦ</summary>
            emPDF = 2,
            /// <summary>印刷＆ＰＤＦ</summary>
            emPrinterAndPDF = 3
        }
        #endregion

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        #region Private Constant
        private const string CT_PGID = "MAKAU03000U";
        private const string MAIN_FORM_TITLE = "請求管理 - ";
        private const string DEMANDMAIN_TITLE = "請求書発行(電子帳簿連携)";
        private const string DEMANDLISTMAIN_TITLE = "請求一覧表（電子帳簿連携）";
        private Hashtable _formControlInfoTable = new Hashtable();
        private const string DOCK_NAVIGATOR = "Navigator_Tree";
        private const string DOCK_EXPLORERBAR = "Main_ExplorerBar";
        private const string NO0_DEMANDMAIN_TAB = "DEMAND_MAIN_TAB";
        private const string NO1_LISTPREVIEW_TAB = "LISTPREVIEW_TAB";
        private const string NO2_TOTALPREVIEW_TAB = "TOTALPREVIEW_TAB";
        private const string TOTAL_PREVIEW_TAB_NAME = "請求書プレビュー";
        private const string LIST_PREVIEW_TAB_NAME = "請求一覧表プレビュー";
        private const string DEMANDMAIN_TAB_NAME = "請求書発行（電子帳簿連携）";
        private const string DEMANDLISTMAIN_TAB_NAME = "請求一覧表（電子帳簿連携）";
        private const string DXSTARTFILENAME = "\\eBookLauncher.vbs";
        private const string BLANK = "about:blank";
        private const string TEXT = "Text";

        // 起動モード定数
        private const int START_MODE_DEFAULT_LIST = 1;		 // 請求一覧表
        private const int START_MODE_DEFAULT_TOTAL = 2;		 // 請求書（鑑）

        // ツールバーツールキー設定
        private const string TOOLBAR_LOGINLABEL_TITLE = "LoginTitle_LabelTool";
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LoginName_LabelTool";
        private const string TOOLBAR_ENDBUTTON_KEY = "End_ButtonTool";
        private const string TOOLBAR_EXTRACTBUTTON_KEY = "Extract_ButtonTool";
        private const string TOOLBAR_SYNCBUTTON_KEY = "Sync_ButtonTool";
        private const string TOOLBAR_RETURNBUTTON_KEY = "Return_ButtonTool";// ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応
        private const string TOOLBAR_PREVIEWBUTTON_KEY = "Preview_ButtonTool";
        private const string TOOLBAR_PRINTBUTTON_KEY = "Print_ButtonTool";
        private const string TOOLBAR_PDFSAVEBUTTON_KEY = "PDFSave_ButtonTool";

        private const string TOOLBAR_PRINTPREVIEWBUTTON_KEY = "PrintPreview_ButtonTool";
        private const string TABCONTROL_EXTRAINFOSCREEN_KEY = "ExtractInfoTab";
        private const string TABCONTROL_EXTRADATASCREEN_KEY = "ExtractDataTab";

        // メッセージ
        private const string MSG_OFFLINE = "オフライン状態で本機能はご使用できません。";
        private const string MSG_PDFALREADYSAVE = "該当のＰＤＦは既に履歴登録されています。";
        private const string MSG_SAVESUCCESS = "保存しました。";
        private const string MSG_SAVEFAILE = "ＰＤＦの履歴保存に失敗しました。\n\r";
        private const string MSG_DXSTART = "電帳.DXを起動しますか？";
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region Private Members
        // 起動モード[0:請求書帳票(ALL),1:請求一覧表,2:請求書（鑑）,3:請求明細書,4:請求明細一覧表,5:領収書]
        private static int _startMode = 0;

        // 抽出条件設定フォーム
        private Form _extractionInfoForm = null;
        // 請求一覧用プレビューフォーム
        private Form _listPreviewForm = null;
        // 請求書（鑑）用プレビューフォーム
        private Form _totalPreviewForm = null;
        #region <PDF/>

        /// <summary>
        /// 複数表示用のプレビューフォームのマップ<br/>
        /// （※1つ目のプレビューフォームは<c>_totalPreviewForm</c>または<c>_receiptPreviewForm</c>
        /// </summary>
        private IDictionary<string, Form> _otherPDFPreviewFormMap;
        /// <summary>
        /// 複数表示用のプレビューフォームのマップを取得します。<br/>
        /// （※1つ目のプレビューフォームは<c>_totalPreviewForm</c>または<c>_receiptPreviewForm</c>
        /// </summary>
        private IDictionary<string, Form> OtherPDFPreviewFormMap
        {
            get
            {
                if (_otherPDFPreviewFormMap == null)
                {
                    _otherPDFPreviewFormMap = new Dictionary<string, Form>();
                }
                return _otherPDFPreviewFormMap;
            }
        }

        /// <summary>
        /// 複数表示用のプレビューフォームのマップのキーを取得します。
        /// </summary>
        /// <param name="originalKey">1つ目のプレビューフォームのキー</param>
        /// <param name="index">インデックス（1～）</param>
        /// <returns><c>originalKey + "," + index</c></returns>
        /// <remarks>
        /// <br>Note        : 複数表示用のプレビューフォームのマップのキーを取得します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetOtherPDFPreviewFormKey(
            string originalKey,
            int index
        )
        {
            return originalKey + "," + index.ToString();
        }

        /// <summary>現在の出力PDF情報</summary>
        /// <remarks>PDF出力時にインスタンスが更新されます。</remarks>
        private PDFManager _currentOutputPDF = new PDFManager(new List<string>(), new List<string>());
        /// <summary>
        /// 現在の出力PDF情報のアクセサ
        /// </summary>
        private PDFManager CurrentOutputPDF
        {
            get
            {
                if (_currentOutputPDF == null)
                {
                    _currentOutputPDF = new PDFManager(new List<string>(), new List<string>());
                }
                return _currentOutputPDF;
            }
            set { _currentOutputPDF = value; }
        }

        #endregion  // <PDF/>

        #region <操作権限制御/>

        /// <summary>操作権限の制御オブジェクトのマップ</summary>
        /// <remarks>キー：プログラムID</remarks>
        private readonly OperationAuthorityControllableMap<ReportController>
            _myOpeCtrlMap = new OperationAuthorityControllableMap<ReportController>();
        /// <summary>
        /// 操作権限の制御オブジェクトのマップを取得します。
        /// </summary>
        /// <value>操作権限の制御オブジェクトのマップ</value>
        private OperationAuthorityControllableMap<ReportController> MyOpeCtrlMap
        {
            get { return _myOpeCtrlMap; }
        }

        /// <summary>
        /// 操作権限の制御を開始します。
        /// </summary>
        /// <param name="assemblyId">アセンブリID</param>
        /// <remarks>
        /// <br>Note        : 操作権限の制御を開始します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void BeginControllingByOperationAuthority(string assemblyId)
        {
            #region <Guard Phrase/>

            if (!MyOpeCtrlMap.ContainsKey(assemblyId)) return;

            #endregion  // <Guard Phrase/>

            // ツールボタンの操作権限の制御設定
            List<ToolButtonInfo> toolButtonInfoList = new List<ToolButtonInfo>();

            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PRINTBUTTON_KEY, ReportFrameOpeCode.Print, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PRINTPREVIEWBUTTON_KEY, ReportFrameOpeCode.Print, false)); // 印刷プレビュー(印刷と同制御)
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_EXTRACTBUTTON_KEY, ReportFrameOpeCode.Extract, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PREVIEWBUTTON_KEY, ReportFrameOpeCode.OutputPDF, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PDFSAVEBUTTON_KEY, ReportFrameOpeCode.SavePDF, false));

            MyOpeCtrlMap[assemblyId].MyOpeCtrl.AddControlItem(this.Main_ToolbarsManager, toolButtonInfoList);

            // 操作権限の制御を開始
            MyOpeCtrlMap[assemblyId].MyOpeCtrl.BeginControl();
        }

        #endregion  // <操作権限制御/>

        private static string[] _parameter;
        private static System.Windows.Forms.Form _form = null;
        private DemandEBooksPrintAcs _demandPrintAcs = null;

        // イベントフラグ
        private bool _eventDoFlag = false;
        private Hashtable _delPDFList = null;							// 削除PDF格納リスト

        private PdfHistoryControl _pdfHistoryCtrl = null;				// PDF履歴管理部品        

        private string _tabKey = TABCONTROL_EXTRAINFOSCREEN_KEY;
        #endregion

        // ===================================================================================== //
        // 内部メソッド
        // ===================================================================================== //
        #region private method
        /// <summary>
        /// 初期設定データ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 初期設定データの読込を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int InitalDataRead()
        {
            string message;

            // 請求印刷設定データ読込
            int status = this._demandPrintAcs.ReadBillPrtSt(LoginInfoAcquisition.EnterpriseCode, out message);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                        message,
                        status,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);
                    break;
            }
            return status;
        }

        /// <summary>
        /// 初期画面設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 初期画面設定を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note : 2020/04/21 陳艶丹</br>
        /// <br>管理番号    : 11870080-00 電子帳簿2次対応</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            // ツールバーアイコン設定
            this.Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            // ログイン担当者へのアイコン設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_LOGINLABEL_TITLE];
            if (loginEmployeeLabel != null) loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // 終了のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_ENDBUTTON_KEY];
            if (closeButton != null) closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            switch (_startMode)
            {
                case START_MODE_DEFAULT_LIST: // 請求一覧表
                    {
                        // 抽出のアイコン設定
                        Infragistics.Win.UltraWinToolbars.ButtonTool extractButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                        if (extractButton != null)
                        {
                            extractButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
                            extractButton.SharedProps.Caption = "抽出(&E)";
                        }
                        break;
                    }
                case START_MODE_DEFAULT_TOTAL:// 請求書
                    {
                        // 電子帳簿同期のアイコン設定
                        Infragistics.Win.UltraWinToolbars.ButtonTool extractButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                        if (extractButton != null) extractButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
                        break;
                    }
            }

            // 同期のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool syncButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
            if (syncButton != null) syncButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;

            //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>>
            // 抽出条件に戻るのアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
            if (returnButton != null) returnButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<

            // プレビューのアイコン設定            
            Infragistics.Win.UltraWinToolbars.ButtonTool previewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
            if (previewButton != null) previewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;

            // 印刷のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
            if (printButton != null) printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;

            // 印刷プレビューのアイコン設定(PDF出力と同じ)
            Infragistics.Win.UltraWinToolbars.ButtonTool printPreviewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
            if (printPreviewButton != null) printPreviewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;

            // ログイン名
            Infragistics.Win.UltraWinToolbars.LabelTool LoginName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_LOGINNAMELABEL_KEY];
            if (LoginName != null && LoginInfoAcquisition.Employee != null)
            {
                Employee employee = new Employee();
                employee = LoginInfoAcquisition.Employee;
                LoginName.SharedProps.Caption = employee.Name;
            }

            // プレビューのアイコン設定            
            Infragistics.Win.UltraWinToolbars.ButtonTool pdfSaveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
            if (pdfSaveButton != null) pdfSaveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;

            // タブコントロールの設定
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.InterTabSpacing = 2;
            this.Main_UTabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopLeft;
            this.Main_UTabControl.Appearance.FontData.SizeInPoints = 11;
        }

        /// <summary>
        /// フォームコントロールクラスクリエイト処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : フォームコントロールクラスをクリエイトし、データを格納します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void FormControlInfoCreate()
        {
            this._formControlInfoTable.Clear();
            FormControlInfo info0 = null;
            FormControlInfo info1 = null;
            FormControlInfo info2 = null;

            switch (_startMode)
            {
                case START_MODE_DEFAULT_LIST: // 請求一覧表
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, CT_PGID, "Broadleaf.Windows.Forms.MAKAU03002UA", DEMANDLISTMAIN_TAB_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
                case START_MODE_DEFAULT_TOTAL:// 請求書
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, CT_PGID, "Broadleaf.Windows.Forms.MAKAU03002UA", DEMANDMAIN_TAB_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
            }

            info1 = new FormControlInfo(NO1_LISTPREVIEW_TAB, CT_PGID, "Broadleaf.Windows.Forms.MAKAU03000UB", LIST_PREVIEW_TAB_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.PREVIEW]);
            this._formControlInfoTable.Add(NO1_LISTPREVIEW_TAB, info1);

            info2 = new FormControlInfo(NO2_TOTALPREVIEW_TAB, CT_PGID, "Broadleaf.Windows.Forms.MAKAU03000UB", TOTAL_PREVIEW_TAB_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.PREVIEW]);   // MOD 2009/03/06 請求書系フレーム修正 "請求書（鑑）プレビュー"→TOTAL_PREVIEW_NAME
            this._formControlInfoTable.Add(NO2_TOTALPREVIEW_TAB, info2);
        }

        /// <summary>
        /// タブクリエイト処理
        /// </summary>
        /// <param name="key">tab</param>
        /// <remarks>
        /// <br>Note        : タブフォームを生成します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void TabCreate(string key)
        {
            switch (key)
            {
                case NO0_DEMANDMAIN_TAB:
                    if (this._extractionInfoForm == null)
                    {
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        if (info == null) return;

                        this._extractionInfoForm = this.CreateTabForm(info);
                        if (_extractionInfoForm == null) return;
                    }
                    else
                    {
                        if (this._extractionInfoForm is IDemandEbooksChildMain)
                        {
                            ((IDemandEbooksChildMain)this._extractionInfoForm).Show((Object)_startMode);
                        }
                        else
                        {
                            this._extractionInfoForm.Show();
                        }
                    }
                    break;
                case NO1_LISTPREVIEW_TAB:
                    if (this._listPreviewForm == null)
                    {
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        if (info == null) return;

                        this._listPreviewForm = this.CreateTabForm(info);
                        if (_listPreviewForm == null) return;
                    }
                    else
                    {
                        this._listPreviewForm.Show();
                    }
                    break;
                case NO2_TOTALPREVIEW_TAB:
                    if (this._totalPreviewForm == null)
                    {
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        if (info == null) return;

                        // プレビュータブを複数表示（請求書1表示目）
                        string originalName = info.Name;
                        if (CurrentOutputPDF.ExistsOtherPDFPreview)
                        {
                            info.Name = originalName + "1";
                        }

                        this._totalPreviewForm = this.CreateTabForm(info);
                        if (_totalPreviewForm == null) return;
                    }
                    else
                    {
                        this._totalPreviewForm.Show();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 二つ目以降のPDFプレビュータブを追加します。
        /// </summary>
        /// <param name="originalKey">1つ目のプレビューフォームのキー</param>
        /// <param name="index">インデックス（1～）</param>
        /// <remarks>
        /// <br>Note        : 二つ目以降のPDFプレビュータブを追加します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void AddOtherPDFPreviewTab(
            string originalKey,
            int index
        )
        {
            string key = GetOtherPDFPreviewFormKey(originalKey, index);

            if (OtherPDFPreviewFormMap.ContainsKey(key))
            {
                OtherPDFPreviewFormMap[key].Show();
                this.Main_UTabControl.Tabs[key].Visible = true;
            }
            else
            {
                FormControlInfo originalInfo = (FormControlInfo)_formControlInfoTable[originalKey];

                string tabName = originalInfo.Name;
                switch (originalKey)
                {
                    case NO2_TOTALPREVIEW_TAB:  // 請求書
                        tabName = TOTAL_PREVIEW_TAB_NAME;
                        break;
                }
                tabName += (index + 1).ToString();

                FormControlInfo info = new FormControlInfo(
                    key,
                    originalInfo.AssemblyID,
                    originalInfo.ClassID,
                    tabName,
                    originalInfo.Icon
                );
                OtherPDFPreviewFormMap.Add(key, CreateTabForm(info));
            }

            return;
        }

        /// <summary>
        /// タブアクティブ処理
        /// </summary>
        /// <param name="key">対象キー情報</param>
        /// <param name="form">アクティブ化したフォームのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 引数のキー情報を元に、タブをアクティブ化します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void TabActive(string key, ref Form form)
        {
            if (this.Main_UTabControl.Tabs.Exists(key))
            {
                this.Main_UTabControl.Tabs[key].Visible = true;
                this.Main_UTabControl.SelectedTab = this.Main_UTabControl.Tabs[key];

                // ウィンドウステイト状態変更
                this.CreateWindowStateButtonTools();
            }
        }

        /// <summary>
        /// Tabフォーム生成処理
        /// </summary>
        /// <param name="info">フォーム情報</param>
        /// <returns>フォーム</returns>
        /// <remarks>
        /// <br>Note        : MDI子画面を生成する</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private Form CreateTabForm(FormControlInfo info)
        {
            Form form = null;

            // 各種フォームのインスタンス可
            switch (info.Key)
            {
                case NO0_DEMANDMAIN_TAB:
                    {
                        form = new Broadleaf.Windows.Forms.MAKAU03002UA();
                        ((MAKAU03002UA)form).SelectedPdfNodeEvent += new SelectedPdfNodeEventHandler(this.SelectedPdfView);
                        ((MAKAU03002UA)form).StatusBarInfoPrinted += new PrintStatusBar(this.PrintStatusBar);
                        ((MAKAU03002UA)form).ChangeTab += new ChangeStatusBar(this.ChangeStatusBar);
                        break;
                    }
                case NO1_LISTPREVIEW_TAB:
                case NO2_TOTALPREVIEW_TAB:
                    form = new Broadleaf.Windows.Forms.MAKAU03000UB();
                    break;
                default:
                    break;
            }

            // 二つ目以降のPDFプレビューフォームを生成
            if (form == null)
            {
                if (info.Key.Contains(NO2_TOTALPREVIEW_TAB))
                {
                    form = new Broadleaf.Windows.Forms.MAKAU03000UB();
                }
            }

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
                dataviewTab.Tag = info.Form;
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

                if (form is IDemandEbooksChildMain)
                {
                    ((IDemandEbooksChildMain)form).Show((Object)_startMode);
                }
                else
                {
                    form.Show();
                }

                form.Dock = System.Windows.Forms.DockStyle.Fill;
            }

            info.Form = form;
            return form;
        }
        /// <summary>
        /// ＰＤＦ履歴表示処理
        /// </summary>
        /// <param name="key"></param>
        /// <param name="printName"></param>
        /// <param name="pdfpath"></param>
        /// <remarks>
        /// <br>Note        : ＰＤＦ履歴を表示します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void SelectedPdfView(string key, string printName, string pdfpath)
        {
            try
            {
                // プレビュータブ生成
                this.TabCreate(NO1_LISTPREVIEW_TAB);
                if (this._listPreviewForm != null)
                {
                    this.TabActive(NO1_LISTPREVIEW_TAB, ref this._listPreviewForm);

                    MAKAU03000UB target = this._listPreviewForm as MAKAU03000UB;

                    if (target != null)
                    {
                        target.IsSave = false;
                        target.PrintKey = string.Empty;
                        target.PrintName = string.Empty;
                        target.PrintDetailName = string.Empty;
                        target.PrintPDFPath = string.Empty;
                        target.Navigate((Object)pdfpath);
                    }

                    // ツールバーボタン設定
                    this.ToolBarSetting(target);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// ツールバー項目状態設定
        /// </summary>
        /// <param name="key">ツールバー項目</param>
        /// <remarks>
        /// <br>Note        : ツールバー項目状態設定</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note : 2020/04/21 陳艶丹</br>
        /// <br>管理番号    : 11870080-00 電子帳簿2次対応</br> 
        /// </remarks>
        private void ToolbarConditionSetting(string key)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;

            switch (key)
            {
                case NO0_DEMANDMAIN_TAB:
                    {
                        // 抽出
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                        // 同期
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;

                        //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>>
                        // 抽出条件に戻る
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<

                        // 印刷
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                        // 印刷プレビュー
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = (_startMode != START_MODE_DEFAULT_LIST);

                        // PDF表示
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                        // PDF履歴保存
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                        break;
                    }
                default:
                    {
                        // 抽出
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // 同期
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>>
                        // 抽出条件に戻る
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<
                        // 印刷
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // 印刷プレビュー
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // PDF表示
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // PDF履歴保存
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        break;
                    }
            }
        }

        #region ◆　ＰＤＦ履歴保存
        /// <summary>
        /// ＰＤＦ履歴保存処理
        /// </summary>
        /// <param name="key">対象帳票KEY</param>
        /// <remarks>
        /// <br>Note       : 対象帳票KEYのＰＤＦファイルを履歴保存します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void SavePDF(string key)
        {
            try
            {
                FormControlInfo info = null;
                MAKAU03000UB target = null;
                if (this._formControlInfoTable.Contains(key))
                {
                    // アクティブタブから帳票コントロール情報を取得
                    info = this._formControlInfoTable[key] as FormControlInfo;

                    // PDFプレビューフォーム
                    if (info != null) target = info.Form as MAKAU03000UB;
                }
                else
                {
                    // 複数PDFプレビュー用処理
                    if (OtherPDFPreviewFormMap.ContainsKey(key))
                    {
                        target = OtherPDFPreviewFormMap[key] as MAKAU03000UB;
                    }
                }

                if (target == null) return;

                // 履歴保存は可能か？
                if (target.IsSave)
                {
                    if (this._pdfHistoryCtrl != null)
                    {
                        // 重複チェック
                        if (this._pdfHistoryCtrl.Contains(target.PrintKey, target.PrintPDFPath))
                        {
                            TMessageBox(emErrorLevel.ERR_LEVEL_INFO, MSG_PDFALREADYSAVE, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        # region [削除リストから除外する]
                        // 全てのタブについて
                        foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Main_UTabControl.Tabs)
                        {
                            FormControlInfo wkInfo = null;
                            MAKAU03000UB wkTarget = null;
                            if (this._formControlInfoTable.Contains(tab.Key))
                            {
                                wkInfo = this._formControlInfoTable[tab.Key] as FormControlInfo;
                                if (wkInfo != null) wkTarget = wkInfo.Form as MAKAU03000UB;
                            }
                            else
                            {
                                if (OtherPDFPreviewFormMap.ContainsKey(tab.Key))
                                {
                                    wkTarget = OtherPDFPreviewFormMap[tab.Key] as MAKAU03000UB;
                                }
                            }
                            if (wkTarget == null) continue;

                            // プレビュー表示タブならばPDF削除リストから除外する
                            if (wkTarget.IsSave)
                            {
                                // 出力履歴管理に追加
                                this._pdfHistoryCtrl.AddPrintHistoryList(wkTarget.PrintKey, wkTarget.PrintName, wkTarget.PrintDetailName,
                                    wkTarget.PrintPDFPath);

                                // 削除リストから除外する
                                if (this._delPDFList.Contains(wkTarget.PrintPDFPath))
                                {
                                    this._delPDFList.Remove(wkTarget.PrintPDFPath);
                                }
                            }
                        }
                        # endregion
                    }

                    TMessageBox(emErrorLevel.ERR_LEVEL_INFO, MSG_SAVESUCCESS, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, MSG_SAVEFAILE + ex.Message,
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        #endregion


        #region ◆　ツールバーの表示・有効設定
        /// <summary>
        /// ツールバーの表示・有効設定
        /// </summary>
        /// <param name="activeForm">アクティブなフォームのオブジェクト</param>
        /// <remarks>
        /// <br>Note       : ツールバーの表示・非表示、有効・無効設定を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note : 2020/04/21 陳艶丹</br>
        /// <br>管理番号    : 11870080-00 電子帳簿2次対応</br>
        /// </remarks>
        private void ToolBarSetting(object activeForm)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;

            if (activeForm != null)
            {
                if (activeForm is IDemandEbooksChildMain)
                {
                    switch (_startMode)
                    {
                        case START_MODE_DEFAULT_LIST: // 請求一覧表
                            {
                                // 抽出
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = true;
                                }
                                // 印刷
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = true;
                                }
                                // PDF表示
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = true;
                                }

                                // PDF履歴保存
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                break;
                            }
                        case START_MODE_DEFAULT_TOTAL:// 請求書
                            {
                                if (_tabKey.Equals(TABCONTROL_EXTRAINFOSCREEN_KEY))
                                {
                                    // 抽出
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = true;
                                    }

                                    // 同期
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }
                                    //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>>
                                    // 抽出条件に戻る
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }
                                    //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<
                                    // 印刷
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = true;
                                    }
                                    // 印刷プレビュー
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = true;
                                    }

                                    // PDF表示
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = true;
                                    }

                                    // PDF履歴保存
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }
                                }
                                else
                                {

                                    // 抽出
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }

                                    // 同期
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = true;
                                    }
                                    //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>>
                                    // 抽出条件に戻る
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }
                                    //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<
                                    // 印刷
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }
                                    // 印刷プレビュー
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }

                                    // PDF表示
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }

                                    // PDF履歴保存
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }
                                }
                                break;
                            }
                    }
                }
                else if (activeForm is MAKAU03000UB)
                {
                    switch (_startMode)
                    {
                        case START_MODE_DEFAULT_LIST: // 請求一覧表
                            {
                                // 抽出
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                // 印刷
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                // PDF表示
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }

                                // PDF履歴保存
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = true;
                                }
                                break;
                            }
                        case START_MODE_DEFAULT_TOTAL:// 請求書
                            {
                                // 抽出
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }

                                // 同期
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>>
                                // 抽出条件に戻る
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<
                                // 印刷
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                // 印刷プレビュー
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }

                                // PDF表示
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }

                                // PDF履歴保存
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    MAKAU03000UB target = activeForm as MAKAU03000UB;
                                    if (target != null)
                                    {
                                        buttonTool.SharedProps.Enabled = target.IsSave;
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            else
            {
                // 抽出
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // 同期
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>>
                // 抽出条件に戻る
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<
                // 印刷
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // 印刷プレビュー
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // PDF表示
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // PDF履歴保存
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
            }
        }
        #endregion

        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">ステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">デフォルトフォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note        : 出力件数の設定を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            Form form = new Form();
            form.TopMost = true;
            DialogResult result = TMsgDisp.Show(form, iLevel, CT_PGID, iMsg, iSt, iButton, iDefButton);
            form.TopMost = false;
            return result;
        }
        #endregion

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        #region control event
        /// <summary>
        /// メインフレームのLOADイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : イベントの解説を記述します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void MAKAU03000UA_Load(object sender, System.EventArgs e)
        {
            try
            {
                // 初期画面設定
                this.InitialScreenSetting();

                // タイトル設定
                this.Text = MAIN_FORM_TITLE;

                switch (_startMode)
                {
                    case START_MODE_DEFAULT_LIST:			// 請求一覧表
                        this.Text = MAIN_FORM_TITLE + DEMANDLISTMAIN_TITLE;
                        break;
                    case START_MODE_DEFAULT_TOTAL:			// 請求書
                        this.Text = MAIN_FORM_TITLE + DEMANDMAIN_TITLE;
                        break;
                }
                this.ToolbarConditionSetting(NO0_DEMANDMAIN_TAB);

                // ウインドウボタン作成処理
                this.CreateWindowStateButtonTools();

                this.Initial_Timer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 初期処理タイマーイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 初期タイマーイベントです。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // イベントフラグOFF
            this._eventDoFlag = false;
            try
            {
                // フォームクラス作成
                this.FormControlInfoCreate();

                // 初期設定データ読込
                int status = this.InitalDataRead();
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.Close();
                    return;
                }

                this.TabCreate(NO0_DEMANDMAIN_TAB);

                // タブをアクティブに！    
                // アクティブ状態のタブからフォームを取得する
                FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                System.Windows.Forms.Form form = formControlInfo.Form;


                this.TabActive(NO0_DEMANDMAIN_TAB, ref form);

                // ツールバー初期設定
                this.ToolBarSetting(form);

                // 操作権限制御
                FormControlInfo info = formControlInfo;
                if (!MyOpeCtrlMap.ContainsKey(info.AssemblyID))
                {
                    if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                        EntityUtil.CategoryCode.Report,
                        MyOpeCtrlMap.AddController(info.AssemblyID),
                        info.AssemblyID,
                        info.Name
                    ))
                    {
                        this.Close();   // 起動不可のため強制終了
                    }
                }

                BeginControllingByOperationAuthority(info.AssemblyID);
            }
            finally
            {
                // イベントフラグON
                this._eventDoFlag = true;
            }
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : ツールバークリック時に発生します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note  : 2020/04/21 陳艶丹</br>
        /// <br>管理番号     : 11870080-00 電子帳簿2次対応</br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                switch (e.Tool.Key)
                {
                    case TOOLBAR_ENDBUTTON_KEY:
                        {
                            this.Close();
                            break;
                        }

                    // 抽出
                    case TOOLBAR_EXTRACTBUTTON_KEY:
                        {
                            // アクティブ状態のタブからフォームを取得する
                            FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if (activeForm is IDemandEbooksChildMain)
                            {
                                // 画面入力チェック
                                this.Main_ToolbarsManager.Enabled = false;
                                try
                                {
                                    ((IDemandEbooksChildMain)activeForm).ExtractData();
                                }
                                finally
                                {
                                    this.Main_ToolbarsManager.Enabled = true;
                                }

                            }
                            break;
                        }
                    // 同期
                    case TOOLBAR_SYNCBUTTON_KEY:
                        {
                            // アクティブ状態のタブからフォームを取得する
                            FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if (activeForm is IDemandEbooksChildMain)
                            {
                                SFCMN06002C printInfo = new SFCMN06002C();
                                printInfo.pdfopen = false;
                                printInfo.pdftemppath = string.Empty;
                                printInfo.pdfopen = true;
                                printInfo.prevkbn = 0; // 0:プレビューなし
                                printInfo.printmode = (int)emPrintMode.emPDF;

                                // PDF出力
                                IDemandEbooksChildMain interFase = activeForm as IDemandEbooksChildMain;
                                Object parameter = (Object)printInfo;
                                int status = interFase.Print(ref parameter, true);

                                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                {
                                    break;
                                }

                                // 同期処理
                                status = interFase.SyncMain();

                                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                {
                                    break;
                                }

                                // 電帳.DX画面を起動する
                                DialogResult dialogResult = MessageBox.Show(
                                    MSG_DXSTART,
                                    this.Text,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
                                );
                                if (dialogResult.Equals(DialogResult.Yes))
                                {
                                    try
                                    {
                                        //電帳.DX画面起動
                                        string vbsFile = System.Environment.CurrentDirectory + DXSTARTFILENAME;
                                        System.Diagnostics.Process p = System.Diagnostics.Process.Start(vbsFile);
                                        p.WaitForExit();
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            break;
                        }
                    //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>>
                    // 抽出条件に戻る
                    case TOOLBAR_RETURNBUTTON_KEY:
                        {
                            // アクティブ状態のタブからフォームを取得する
                            FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if (activeForm is IDemandEbooksChildMain)
                            {
                                // 画面入力チェック
                                this.Main_ToolbarsManager.Enabled = false;
                                try
                                {
                                    ((IDemandEbooksChildMain)activeForm).ReturnToExtraCondition();
                                }
                                finally
                                {
                                    this.Main_ToolbarsManager.Enabled = true;
                                }

                            }
                            break;
                        }
                    //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<
                    case TOOLBAR_PREVIEWBUTTON_KEY: // プレビュー
                    case TOOLBAR_PRINTBUTTON_KEY: // 印刷
                    case TOOLBAR_PRINTPREVIEWBUTTON_KEY: // 印刷プレビュー
                        {
                            // アクティブ状態のタブからフォームを取得する
                            FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if ((activeForm is IDemandEbooksChildMain))
                            {
                                SFCMN06002C printInfo = new SFCMN06002C();
                                printInfo.pdfopen = false;
                                printInfo.pdftemppath = string.Empty;

                                // 請求一覧表以外はダイアログ制御が無いので、常に「0:プレビューなし」
                                if (!_startMode.Equals(START_MODE_DEFAULT_LIST))
                                {
                                    printInfo.pdfopen = true;
                                    if (e.Tool.Key != TOOLBAR_PRINTPREVIEWBUTTON_KEY)
                                    {
                                        printInfo.prevkbn = 0; // 0:プレビューなし
                                    }
                                    else
                                    {
                                        printInfo.prevkbn = 1; // 1:プレビューあり
                                    }
                                }

                                // 印刷モードの設定
                                int printMode = 0;
                                switch (e.Tool.Key)
                                {
                                    case TOOLBAR_PRINTBUTTON_KEY:
                                    case TOOLBAR_PRINTPREVIEWBUTTON_KEY:

                                        // 通常印刷
                                        printMode = (int)emPrintMode.emPrinter;
                                        break;
                                    case TOOLBAR_PREVIEWBUTTON_KEY:
                                        // ＰＤＦ出力
                                        printMode = (int)emPrintMode.emPDF;
                                        break;
                                    default:
                                        break;
                                }
                                printInfo.printmode = printMode;

                                IDemandEbooksChildMain interFase = activeForm as IDemandEbooksChildMain;

                                // TODO 印刷前チェックを行う

                                Object parameter = (Object)printInfo;
                                int status = interFase.Print(ref parameter, false);

                                switch (status)
                                {
                                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                        {
                                            // ＰＤＦ出力場合のみ
                                            if (printMode == (int)emPrintMode.emPDF)
                                            {
                                                // ＰＤＦ削除リストに追加
                                                if (printInfo.pdftemppath != string.Empty)
                                                {
                                                    if (!this._delPDFList.Contains(printInfo.pdftemppath))
                                                    {
                                                        this._delPDFList.Add(printInfo.pdftemppath, printInfo.pdftemppath);
                                                    }
                                                }
                                                else
                                                {
                                                    CurrentOutputPDF = null;
                                                    return; // PDFが生成されていない場合、強制終了
                                                }

                                                // 現在の出力PDF情報を更新
                                                if (activeForm is MAKAU03002UA)
                                                {
                                                    CurrentOutputPDF = ((MAKAU03002UA)activeForm).OutputPDF;
                                                    if (CurrentOutputPDF.ExistsOtherPDFPreview)
                                                    {
                                                        for (int i = 1; i < CurrentOutputPDF.PreviewPDFPathList.Count; i++)
                                                        {
                                                            this._delPDFList.Add(
                                                                CurrentOutputPDF.PreviewPDFPathList[i],
                                                                CurrentOutputPDF.PreviewPDFPathList[i]
                                                            );
                                                        }
                                                    }
                                                }

                                                if (printInfo.pdfopen)
                                                {
                                                    Form frm = null;
                                                    MAKAU03000UB target = null;


                                                    string key = string.Empty;

                                                    // 請求明細書
                                                    // プレビュータブ生成
                                                    this.TabCreate(NO2_TOTALPREVIEW_TAB);
                                                    if (this._totalPreviewForm != null)
                                                    {
                                                        frm = this._totalPreviewForm;
                                                        target = frm as MAKAU03000UB;
                                                        key = NO2_TOTALPREVIEW_TAB;
                                                    }
                                                    if (CurrentOutputPDF.ExistsOtherPDFPreview)
                                                    {
                                                        for (int i = 1; i < CurrentOutputPDF.PreviewPDFPathList.Count; i++)
                                                        {
                                                            AddOtherPDFPreviewTab(NO2_TOTALPREVIEW_TAB, i);
                                                        }
                                                    }

                                                    if (target != null)
                                                    {
                                                        target.IsSave = true;
                                                        target.PrintKey = printInfo.key;
                                                        target.PrintName = printInfo.prpnm;
                                                        target.PrintDetailName = printInfo.prpnm;
                                                        target.PrintPDFPath = printInfo.pdftemppath;
                                                        target.Navigate(printInfo.pdftemppath);
                                                        if (CurrentOutputPDF.ExistsOtherPDFPreview)
                                                        {
                                                            // 二つ目以降のPDFを表示
                                                            string originalKey = key;

                                                            for (int i = 1; i < CurrentOutputPDF.PreviewPDFPathList.Count; i++)
                                                            {
                                                                string otherKey = GetOtherPDFPreviewFormKey(originalKey, i);
                                                                MAKAU03000UB otherTarget = OtherPDFPreviewFormMap[otherKey] as MAKAU03000UB;
                                                                if (otherTarget == null) continue;

                                                                otherTarget.IsSave = true;
                                                                otherTarget.PrintKey = printInfo.key;
                                                                otherTarget.PrintName = printInfo.prpnm;
                                                                otherTarget.PrintDetailName = printInfo.prpnm;

                                                                otherTarget.PrintPDFPath = CurrentOutputPDF.PreviewPDFPathList[i];
                                                                otherTarget.Navigate(CurrentOutputPDF.PreviewPDFPathList[i]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            // 二つ目以降のプレビュータブを隠す
                                                            for (int i = 0; i < this.Main_UTabControl.Tabs.Count; i++)
                                                            {
                                                                if (this.Main_UTabControl.Tabs[i].Key.Contains(key))
                                                                {
                                                                    if (this.Main_UTabControl.Tabs[i].Key.Equals(key)) continue;
                                                                    TabVisibleChange(this.Main_UTabControl.Tabs[i].Key, false);
                                                                }
                                                            }
                                                        }

                                                        this.TabActive(key, ref frm);
                                                    }

                                                    // ツールバーボタン設定
                                                    this.ToolBarSetting(frm);
                                                }
                                            }
                                            break;
                                        }
                                    case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                                        {
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                            }
                            break;
                        }

                    case TOOLBAR_PDFSAVEBUTTON_KEY:
                        {
                            this.SavePDF(this.Main_UTabControl.ActiveTab.Key.ToString());
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// タブ選択後処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : タブ選択後に発生するイベントです。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void Main_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            try
            {
                // 処理中
                if (!this._eventDoFlag) return;
                if (e.Tab == null) return;

                string key = e.Tab.Key;

                if (this._formControlInfoTable.Contains(key))
                {
                    FormControlInfo info = this._formControlInfoTable[key] as FormControlInfo;
                    Form target = info.Form;
                    this.TabActive(key, ref target);
                    this.ToolBarSetting(target);
                }
                else
                {
                    if (OtherPDFPreviewFormMap.ContainsKey(key))
                    {
                        Form target = OtherPDFPreviewFormMap[key];
                        this.TabActive(key, ref target);
                        this.ToolBarSetting(target);
                    }
                }
            }
            catch(Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        ///	フォームが閉じられた後に発生するイベントです。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : フォームが閉じられた後に、発生します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void MAKAU03000UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this._eventDoFlag = false;

                // 各帳票のブラウザに空アドレスを表示させます。表示しているPDFファイルを閉じる為です。
                foreach (DictionaryEntry entry in this._formControlInfoTable)
                {
                    FormControlInfo info = entry.Value as FormControlInfo;
                    if (info != null)
                    {
                        MAKAU03000UB viewFrm = info.Form as MAKAU03000UB;
                        if (viewFrm != null)
                        {
                            viewFrm.Navigate(BLANK);
                            viewFrm.Close();
                            viewFrm.Dispose();
                        }
                    }
                }

                // 二つ目以降のPDFブラウザに空アドレスを設定（∵表示しているPDFファイルを閉じる為）
                foreach (Form otherForm in OtherPDFPreviewFormMap.Values)
                {
                    MAKAU03000UB otherPreviewForm = otherForm as MAKAU03000UB;
                    if (otherPreviewForm == null) continue;

                    otherPreviewForm.Navigate(BLANK);
                    otherPreviewForm.Close();
                    otherPreviewForm.Dispose();
                }

                foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Main_UTabControl.Tabs)
                {
                    this.Main_UTabControl.Tabs.Remove(tab);
                }

                // プレビューで生成したＰＤＦファイルを削除します。
                int tryCnt;
                foreach (DictionaryEntry wkEntry in this._delPDFList)
                {
                    if (System.IO.File.Exists(wkEntry.Value.ToString()))
                    {
                        tryCnt = 0;
                        while (tryCnt < 3)
                        {
                            try
                            {
                                System.IO.File.Delete(wkEntry.Value.ToString());
                                // 関連PDFを削除
                                CurrentOutputPDF.DeleteFiles(wkEntry.Value.ToString());
                                break;
                            }
                            catch (System.IO.IOException ex)
                            {
                                System.Threading.Thread.Sleep(1000);
                                Debug.Assert(false, ex.ToString());
                            }
                            catch (Exception ex)
                            {
                                Debug.Assert(false, ex.ToString());
                                break;
                            }

                            tryCnt++;
                        }
                    }
                }
            }
            finally
            {
                this._eventDoFlag = true;
            }
        }
        #endregion

        /// <summary>
        /// ポップメニュー「閉じる」イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 「閉じる」ボタン押下時に発生します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void Close_menuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.Main_UTabControl.ActiveTab == null) return;

                string key = this.Main_UTabControl.ActiveTab.Key;

                // タブ表示変更
                this.TabVisibleChange(key, false);

                // ウィンドウステートボタンツール構築処理
                this.CreateWindowStateButtonTools();

                if (this.Main_UTabControl.Tabs.Count == 0)
                {
                    this.ToolBarSetting(null);
                }
                else
                {
                    this.ToolBarSetting(this.Main_UTabControl.ActiveTab);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        #region ◆　ウィンドウステートボタンツール構築処理
        /// <summary>
        /// ウィンドウステートボタンツール構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ウインドウ表位置状態ボタンを作成します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void CreateWindowStateButtonTools()
        {
            if (this.Main_UTabControl.SelectedTab != null)
            {
                if (this.Main_UTabControl.SelectedTab.Key == NO0_DEMANDMAIN_TAB)
                {
                    // 条件入力
                    this.Main_UTabControl.ContextMenu = null;
                }
                else
                {
                    // プレビュ画面
                    this.Main_UTabControl.ContextMenu = this.TabControl_contextMenu;
                }
            }
        }
        #endregion

        #region ◆　タブ表示・非表示制御
        /// <summary>
        /// タブ表示／非表示化処理
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="hidden">true:表示 false:非表示</param>
        /// <remarks>
        /// <br>Note       : タブの表示／非表示を制御します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void TabVisibleChange(string key, bool visible)
        {
            for (int i = 0; i < this.Main_UTabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = this.Main_UTabControl.Tabs[i];

                if (tab.Key == key)
                {
                    tab.Visible = visible;

                    if (!visible) ClosePDF(key, false);
                }
            }
        }
        #endregion

        /// <summary>
        /// 表示しているPDFファイルを閉じます。
        /// </summary>
        /// <param name="tabKey">PDFを表示しているタブのキー</param>
        /// <param name="withDisposingPreviewForm">表示しているプレビュー用フォームを処分するフラグ</param>
        /// <remarks>
        /// <br>Note        : 表示しているPDFファイルを閉じます。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void ClosePDF(
            string tabKey,
            bool withDisposingPreviewForm
        )
        {
            const string EMPTY_URL = BLANK;

            // 各帳票のブラウザに空アドレスを表示させます。表示しているPDFファイルを閉じる為です。
            if (_formControlInfoTable.ContainsKey(tabKey))
            {
                FormControlInfo info = _formControlInfoTable[tabKey] as FormControlInfo;
                if (info != null)
                {
                    MAKAU03000UB viewFrm = info.Form as MAKAU03000UB;
                    if (viewFrm != null)
                    {
                        viewFrm.Navigate(EMPTY_URL);
                        if (withDisposingPreviewForm)
                        {
                            viewFrm.Close();
                            viewFrm.Dispose();
                        }
                    }
                }
            }

            // 二つ目以降のPDFブラウザに空アドレスを設定（∵表示しているPDFファイルを閉じる為）
            if (OtherPDFPreviewFormMap.ContainsKey(tabKey))
            {
                MAKAU03000UB otherPreviewForm = OtherPDFPreviewFormMap[tabKey] as MAKAU03000UB;
                if (otherPreviewForm != null)
                {
                    otherPreviewForm.Navigate(EMPTY_URL);
                    if (withDisposingPreviewForm)
                    {
                        otherPreviewForm.Close();
                        otherPreviewForm.Dispose();
                    }
                }
            }

        }

        #region ◎ステータスバーへ出力

        /// <summary>
        /// ステータスバーに情報を表示します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : ステータスバーに情報を表示します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void PrintStatusBar(
            object sender,
            PrintStatusBarEventArgs e
        )
        {
            try
            {
                this.Main_StatusBar.Panels[TEXT].Text = e.Message;
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// ステータスバーに情報を表示します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : ステータスバーに情報を表示します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note : 2020/04/21 陳艶丹</br>
        /// <br>管理番号    : 11870080-00 電子帳簿2次対応</br> 
        /// </remarks>
        private void ChangeStatusBar(
            object sender,
            Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e
        )
        {
            try
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;

                if (_startMode == START_MODE_DEFAULT_TOTAL)
                {
                    switch (e.Tab.Key)
                    {
                        case TABCONTROL_EXTRAINFOSCREEN_KEY:
                            {
                                _tabKey = TABCONTROL_EXTRAINFOSCREEN_KEY;

                                // 抽出
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Visible = true;
                                    buttonTool.SharedProps.Enabled = true;
                                }

                                // 同期
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Visible = false;
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>>
                                // 抽出条件に戻る
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Visible = false;
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<
                                // 印刷
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                                if (buttonTool != null) buttonTool.SharedProps.Enabled = true;

                                // 印刷プレビュー
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                                if (buttonTool != null) buttonTool.SharedProps.Enabled = true;

                                // PDF表示
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                                if (buttonTool != null) buttonTool.SharedProps.Enabled = true;

                                break;
                            }
                        case TABCONTROL_EXTRADATASCREEN_KEY:
                            {
                                _tabKey = TABCONTROL_EXTRADATASCREEN_KEY;

                                // 抽出
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Visible = false;
                                    buttonTool.SharedProps.Enabled = false;
                                }

                                // 同期
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Visible = true;
                                    buttonTool.SharedProps.Enabled = true;
                                }
                                //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>>
                                // 抽出条件に戻る
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Visible = true;
                                    buttonTool.SharedProps.Enabled = true;
                                }
                                //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<
                                // 印刷
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                                if (buttonTool != null) buttonTool.SharedProps.Enabled = false;

                                // 印刷プレビュー
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                                if (buttonTool != null) buttonTool.SharedProps.Enabled = false;

                                // PDF表示
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                                if (buttonTool != null) buttonTool.SharedProps.Enabled = false;

                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        #endregion  // ◎ステータスバーへ出力
    }
}
