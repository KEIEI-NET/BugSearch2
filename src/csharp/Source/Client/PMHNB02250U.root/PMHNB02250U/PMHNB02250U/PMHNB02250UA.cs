//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 請求書発行(総括)
// プログラム概要   : 請求書発行(総括)の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30531 大矢 睦美
// 作 成 日  2010/02/01  修正内容 : 請求書タイプ毎に印刷制御を行うように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/06/23  修正内容 : 請求書印刷ページ指定対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/07/28  修正内容 : アウトオブメモリエラー対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/11/02  修正内容 : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gezh
// 作 成 日  2011/12/16  修正内容 : redmine#26635の対応。
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Data;
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
    /// 請求書発行(総括)フレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求書発行(総括)のフレームクラスです。</br>
    /// <br></br>
    /// <br>Update Note: 2010/11/02  22018 鈴木 正臣</br>
    /// <br>           : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)</br>
    /// </remarks>
    public class PMHNB02250UA : System.Windows.Forms.Form
    {
        # region Private Members (Component)
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinDock.UltraDockManager Main_DockManager;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU02010UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU02010UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU02010UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU02010UA_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU02010UAUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU02010UAUnpinnedTabAreaRight;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU02010UAUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU02010UAUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.AutoHideControl _MAKAU02010UAAutoHideControl;
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
        public PMHNB02250UA()
        {
            InitializeComponent();

            // 請求書データアクセスクラスインスタンス化
            this._demandPrintAcs = new SumDemandPrintAcs();

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
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar( "MainMenu_UltraToolbar" );
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool( "File_PopupMenuTool" );
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool( "Tool_PopupMenuTool" );
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool( "Window_PopupMenuTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool( "Dummy_LabelTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool( "LoginTitle_LabelTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool( "LoginName_LabelTool" );
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar( "Button_UltraToolbar" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "End_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Extract_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Print_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "PrintPreview_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Preview_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "PDFSave_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "UserSetUp_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "TextOutPut_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool( "File_PopupMenuTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Extract_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Print_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Preview_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "PDFSave_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "TextOutPut_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "End_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool( "Tool_PopupMenuTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "UserSetUp_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool( "Window_PopupMenuTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool( "Dummy_LabelTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool( "LoginTitle_LabelTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool( "LoginName_LabelTool" );
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "End_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "UserSetUp_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool( "PrintKindTitle_LabelTool" );
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool( "PrintKind_ComboBoxTool" );
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList( 0 );
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Extract_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Preview_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Print_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool( "STOP_LabelTool" );
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool( "PrtSuspendCnt_ControlContainerTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool( "Number_LabelTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "PDFSave_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "TextOutPut_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool( "Forms_PopupMenuTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "PrintPreview_ButtonTool" );
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PMHNB02250UA ) );
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager( this.components );
            this._MAKAU02010UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU02010UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU02010UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU02010UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU02010UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.Initial_Timer = new System.Windows.Forms.Timer( this.components );
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos( this.components );
            this.TabControl_contextMenu = new System.Windows.Forms.ContextMenu();
            this.Close_menuItem = new System.Windows.Forms.MenuItem();
            this.DataViewTabSharedControlsPage = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.Main_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this._MAKAU02010UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager( this.components );
            this._MAKAU02010UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU02010UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
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
            // _MAKAU02010UAUnpinnedTabAreaLeft
            // 
            this._MAKAU02010UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._MAKAU02010UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this._MAKAU02010UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point( 0, 63 );
            this._MAKAU02010UAUnpinnedTabAreaLeft.Name = "_MAKAU02010UAUnpinnedTabAreaLeft";
            this._MAKAU02010UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._MAKAU02010UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size( 0, 648 );
            this._MAKAU02010UAUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _MAKAU02010UAUnpinnedTabAreaRight
            // 
            this._MAKAU02010UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._MAKAU02010UAUnpinnedTabAreaRight.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this._MAKAU02010UAUnpinnedTabAreaRight.Location = new System.Drawing.Point( 1016, 63 );
            this._MAKAU02010UAUnpinnedTabAreaRight.Name = "_MAKAU02010UAUnpinnedTabAreaRight";
            this._MAKAU02010UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._MAKAU02010UAUnpinnedTabAreaRight.Size = new System.Drawing.Size( 0, 648 );
            this._MAKAU02010UAUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _MAKAU02010UAUnpinnedTabAreaTop
            // 
            this._MAKAU02010UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._MAKAU02010UAUnpinnedTabAreaTop.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this._MAKAU02010UAUnpinnedTabAreaTop.Location = new System.Drawing.Point( 0, 63 );
            this._MAKAU02010UAUnpinnedTabAreaTop.Name = "_MAKAU02010UAUnpinnedTabAreaTop";
            this._MAKAU02010UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._MAKAU02010UAUnpinnedTabAreaTop.Size = new System.Drawing.Size( 1016, 0 );
            this._MAKAU02010UAUnpinnedTabAreaTop.TabIndex = 7;
            // 
            // _MAKAU02010UAUnpinnedTabAreaBottom
            // 
            this._MAKAU02010UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._MAKAU02010UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this._MAKAU02010UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point( 0, 711 );
            this._MAKAU02010UAUnpinnedTabAreaBottom.Name = "_MAKAU02010UAUnpinnedTabAreaBottom";
            this._MAKAU02010UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._MAKAU02010UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size( 1016, 0 );
            this._MAKAU02010UAUnpinnedTabAreaBottom.TabIndex = 8;
            // 
            // _MAKAU02010UAAutoHideControl
            // 
            this._MAKAU02010UAAutoHideControl.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this._MAKAU02010UAAutoHideControl.Location = new System.Drawing.Point( 22, 50 );
            this._MAKAU02010UAAutoHideControl.Name = "_MAKAU02010UAAutoHideControl";
            this._MAKAU02010UAAutoHideControl.Owner = this.Main_DockManager;
            this._MAKAU02010UAAutoHideControl.Size = new System.Drawing.Size( 233, 661 );
            this._MAKAU02010UAAutoHideControl.TabIndex = 9;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler( this.Initial_Timer_Tick );
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point( 0, 711 );
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
            this.Main_StatusBar.Panels.AddRange( new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3} );
            this.Main_StatusBar.Size = new System.Drawing.Size( 1016, 23 );
            this.Main_StatusBar.TabIndex = 28;
            this.Main_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // TabControl_contextMenu
            // 
            this.TabControl_contextMenu.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.Close_menuItem} );
            // 
            // Close_menuItem
            // 
            this.Close_menuItem.Index = 0;
            this.Close_menuItem.Text = "閉じる(&C)";
            this.Close_menuItem.Click += new System.EventHandler( this.Close_menuItem_Click );
            // 
            // DataViewTabSharedControlsPage
            // 
            this.DataViewTabSharedControlsPage.Location = new System.Drawing.Point( 1, 20 );
            this.DataViewTabSharedControlsPage.Name = "DataViewTabSharedControlsPage";
            this.DataViewTabSharedControlsPage.Size = new System.Drawing.Size( 1014, 627 );
            // 
            // Main_UTabControl
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Main_UTabControl.Appearance = appearance3;
            this.Main_UTabControl.BackColorInternal = System.Drawing.Color.FromArgb( ((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))) );
            this.Main_UTabControl.Controls.Add( this.DataViewTabSharedControlsPage );
            this.Main_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_UTabControl.Font = new System.Drawing.Font( "ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Main_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger( 1 );
            this.Main_UTabControl.Location = new System.Drawing.Point( 0, 63 );
            this.Main_UTabControl.Name = "Main_UTabControl";
            this.Main_UTabControl.SharedControlsPage = this.DataViewTabSharedControlsPage;
            this.Main_UTabControl.Size = new System.Drawing.Size( 1016, 648 );
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.TabIndex = 29;
            this.Main_UTabControl.TabPadding = new System.Drawing.Size( 3, 3 );
            this.Main_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Main_UTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.Main_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler( this.Main_UTabControl_SelectedTabChanged );
            // 
            // _MAKAU02010UA_Toolbars_Dock_Area_Left
            // 
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))) );
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point( 0, 63 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.Name = "_MAKAU02010UA_Toolbars_Dock_Area_Left";
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size( 0, 648 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Main_ToolbarsManager
            // 
            this.Main_ToolbarsManager.DesignerFlags = 1;
            this.Main_ToolbarsManager.DockWithinContainer = this;
            this.Main_ToolbarsManager.DockWithinContainerBaseType = typeof( System.Windows.Forms.Form );
            this.Main_ToolbarsManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.Main_ToolbarsManager.ShowFullMenusDelay = 500;
            this.Main_ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            labelTool1.InstanceProps.Spring = Infragistics.Win.DefaultableBoolean.True;
            ultraToolbar1.NonInheritedTools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            popupMenuTool3,
            labelTool1,
            labelTool2,
            labelTool3} );
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            ultraToolbar2.NonInheritedTools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8} );
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "標準";
            this.Main_ToolbarsManager.Toolbars.AddRange( new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2} );
            popupMenuTool4.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool14.InstanceProps.IsFirstInGroup = true;
            popupMenuTool4.Tools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            buttonTool14} );
            popupMenuTool5.SharedProps.Caption = "ツール(&T)";
            popupMenuTool5.SharedProps.Visible = false;
            popupMenuTool5.Tools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool15} );
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
            //buttonTool16.SharedProps.Caption = "終了(&X)";  // DEL 2011/12/16 gezh redmine#26635 
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool16.SharedProps.Caption = "終了(F1)";
            buttonTool16.SharedProps.Shortcut = Shortcut.F1;
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool16.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool16.SharedProps.ShowInCustomizer = false;
            buttonTool17.SharedProps.Caption = "ユーザー設定(&C)";
            buttonTool17.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool17.SharedProps.ShowInCustomizer = false;
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
            valueList1.ValueListItems.AddRange( new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5} );
            comboBoxTool1.ValueList = valueList1;
            buttonTool18.SharedProps.Caption = "抽出(&E)";
            buttonTool18.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            //buttonTool19.SharedProps.Caption = "PDF表示(&V)";  // DEL 2011/12/16 gezh redmine#26635
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool19.SharedProps.Caption = "PDF表示(F11)";
            buttonTool19.SharedProps.Shortcut = Shortcut.F11;
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool19.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            //buttonTool20.SharedProps.Caption = "印刷(&P)";  // DEL 2011/12/16 gezh redmine#26635
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool20.SharedProps.Caption = "印刷(F10)";
            buttonTool20.SharedProps.Shortcut = Shortcut.F10;
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool8.SharedProps.Caption = "印刷一時中断枚数";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            controlContainerTool1.SharedProps.MaxWidth = 40;
            controlContainerTool1.SharedProps.MinWidth = 40;
            controlContainerTool1.SharedProps.Width = 41;
            labelTool9.SharedProps.Caption = "枚";
            labelTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            //buttonTool21.SharedProps.Caption = "PDF履歴保存(&S)";  // DEL 2011/12/16 gezh redmine#26635
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool21.SharedProps.Caption = "PDF履歴保存(F12)";
            buttonTool21.SharedProps.Shortcut = Shortcut.F12;
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool21.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool21.SharedProps.Enabled = false;
            buttonTool22.SharedProps.Caption = "テキスト出力(&O)";
            buttonTool22.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool22.SharedProps.Visible = false;
            popupMenuTool7.SharedProps.Caption = "タブ切替(&J)";
            popupMenuTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool7.SharedProps.ToolTipText = "画面を切り替えます。";
            buttonTool23.SharedProps.Caption = "印刷プレビュー(&W)";
            buttonTool23.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.Main_ToolbarsManager.Tools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool4,
            popupMenuTool5,
            popupMenuTool6,
            labelTool4,
            labelTool5,
            labelTool6,
            buttonTool16,
            buttonTool17,
            labelTool7,
            comboBoxTool1,
            buttonTool18,
            buttonTool19,
            buttonTool20,
            labelTool8,
            controlContainerTool1,
            labelTool9,
            buttonTool21,
            buttonTool22,
            popupMenuTool7,
            buttonTool23} );
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler( this.Main_ToolbarsManager_ToolClick );
            this.Main_ToolbarsManager.ToolValueChanged += new Infragistics.Win.UltraWinToolbars.ToolEventHandler( this.Main_ToolbarsManager_ToolValueChanged );
            // 
            // _MAKAU02010UA_Toolbars_Dock_Area_Right
            // 
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))) );
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point( 1016, 63 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.Name = "_MAKAU02010UA_Toolbars_Dock_Area_Right";
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size( 0, 648 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _MAKAU02010UA_Toolbars_Dock_Area_Top
            // 
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))) );
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point( 0, 0 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.Name = "_MAKAU02010UA_Toolbars_Dock_Area_Top";
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size( 1016, 63 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _MAKAU02010UA_Toolbars_Dock_Area_Bottom
            // 
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))) );
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point( 0, 711 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.Name = "_MAKAU02010UA_Toolbars_Dock_Area_Bottom";
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size( 1016, 0 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // PMHNB02250UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 8, 15 );
            this.ClientSize = new System.Drawing.Size( 1016, 734 );
            this.Controls.Add( this._MAKAU02010UAAutoHideControl );
            this.Controls.Add( this.Main_UTabControl );
            this.Controls.Add( this._MAKAU02010UAUnpinnedTabAreaTop );
            this.Controls.Add( this._MAKAU02010UAUnpinnedTabAreaBottom );
            this.Controls.Add( this._MAKAU02010UAUnpinnedTabAreaLeft );
            this.Controls.Add( this._MAKAU02010UAUnpinnedTabAreaRight );
            this.Controls.Add( this._MAKAU02010UA_Toolbars_Dock_Area_Left );
            this.Controls.Add( this._MAKAU02010UA_Toolbars_Dock_Area_Right );
            this.Controls.Add( this._MAKAU02010UA_Toolbars_Dock_Area_Top );
            this.Controls.Add( this._MAKAU02010UA_Toolbars_Dock_Area_Bottom );
            this.Controls.Add( this.Main_StatusBar );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Name = "PMHNB02250UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "請求書系フレーム";
            this.Load += new System.EventHandler( this.PMHNB02250UA_Load );
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.PMHNB02250UA_FormClosed );
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).EndInit();
            this.Main_UTabControl.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout( false );

        }
        #endregion

        // ===================================================================================== //
        // メイン
        // ===================================================================================== //
        #region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string msg = "";
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
                #if DEBUG
                    // デバッグ時は任意に設定できるようにする
                #else
                    else
                    {
                        _startMode = 0;
                    }
                #endif

                    // オンライン状態判定
                    if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
                    {
                        // オフライン情報
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID,
                            "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        System.Windows.Forms.Application.EnableVisualStyles();
                        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                        _form = new PMHNB02250UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                }
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, ex.Message, 0, MessageBoxButtons.OK);
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
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, e.ToString(), 0, MessageBoxButtons.OK);
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
        private const string CT_PGID = "PMHNB02250U";
        private const string MAIN_FORM_TITLE = "請求管理（総括）";
        
        // 起動モード定数
        private const int START_MODE_DEFAULT_LIST = 1;		 // 請求一覧表（総括）
        private const int START_MODE_DEFAULT_TOTAL = 2;		 // 請求書（総括）
        
        private Hashtable _formControlInfoTable = new Hashtable();
        private const string DOCK_NAVIGATOR = "Navigator_Tree";
        private const string DOCK_EXPLORERBAR = "Main_ExplorerBar";
        private const string NO0_DEMANDMAIN_TAB = "DEMAND_MAIN_TAB";
        private const string NO1_LISTPREVIEW_TAB = "LISTPREVIEW_TAB";
        private const string NO2_TOTALPREVIEW_TAB = "TOTALPREVIEW_TAB";
        
        /// <summary>請求書PDFプレビューのタブ名称</summary>
        private const string TOTAL_PREVIEW_TAB_NAME     = "請求書（総括）プレビュー";
        
        // ツールバーツールキー設定
        private const string TOOLBAR_LOGINLABEL_TITLE = "LoginTitle_LabelTool";
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LoginName_LabelTool";
        private const string TOOLBAR_ENDBUTTON_KEY = "End_ButtonTool";
        private const string TOOLBAR_EXTRACTBUTTON_KEY = "Extract_ButtonTool";
        private const string TOOLBAR_PREVIEWBUTTON_KEY = "Preview_ButtonTool";
        private const string TOOLBAR_PRINTBUTTON_KEY = "Print_ButtonTool";
        private const string TOOLBAR_PRINTKINDTITLE_KEY = "PrintKindTitle_LabelTool";
        private const string TOOLBAR_PRINTKINDCOMB_KEY = "PrintKind_ComboBoxTool";
        private const string TOOLBAR_EDITTOTAL_KEY = "EditTotal_ButtonTool";
        private const string TOOLBAR_EDITNEW_KEY = "EditNew_ButtonTool";
        private const string TOOLBAR_USERSETUP_KEY = "UserSetUp_ButtonTool";

        private const string TOOLBAR_STOPLABEL_KEY = "STOP_LabelTool";
        private const string TOOLBAR_PRTSUSPENDCNT_KEY = "PrtSuspendCnt_ControlContainerTool";
        private const string TOOLBAR_NUMBERLABEL_KEY = "Number_LabelTool";
        private const string TOOLBAR_PDFSAVEBUTTON_KEY = "PDFSave_ButtonTool";

        private const string TOOLBAR_TEXTOUTPUT_KEY = "TextOutPut_ButtonTool";
        // --- ADD m.suzuki 2010/06/23 ---------->>>>>
        private const string TOOLBAR_PRINTPREVIEWBUTTON_KEY = "PrintPreview_ButtonTool";
        // --- ADD m.suzuki 2010/06/23 ----------<<<<<
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region Private Members
        // 起動モード[1:請求一覧表（総括）,2:請求書（総括）]

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
        private void BeginControllingByOperationAuthority(string assemblyId)
        {
            #region <Guard Phrase/>

            if (!MyOpeCtrlMap.ContainsKey(assemblyId)) return;

            #endregion  // <Guard Phrase/>

            // ツールボタンの操作権限の制御設定
            List<ToolButtonInfo> toolButtonInfoList = new List<ToolButtonInfo>();

            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PRINTBUTTON_KEY, ReportFrameOpeCode.Print, false));
            // --- ADD m.suzuki 2010/06/23 ---------->>>>>
            toolButtonInfoList.Add( new ReportToolButtonInfo( TOOLBAR_PRINTPREVIEWBUTTON_KEY, ReportFrameOpeCode.Print, false ) ); // 印刷プレビュー(印刷と同制御)
            // --- ADD m.suzuki 2010/06/23 ----------<<<<<
            toolButtonInfoList.Add( new ReportToolButtonInfo( TOOLBAR_EXTRACTBUTTON_KEY, ReportFrameOpeCode.Extract, false ) );
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PREVIEWBUTTON_KEY, ReportFrameOpeCode.OutputPDF, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PDFSAVEBUTTON_KEY, ReportFrameOpeCode.SavePDF, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_TEXTOUTPUT_KEY, ReportFrameOpeCode.OutputText, false));

            MyOpeCtrlMap[assemblyId].MyOpeCtrl.AddControlItem(this.Main_ToolbarsManager, toolButtonInfoList);
            // 操作権限の制御を開始
            MyOpeCtrlMap[assemblyId].MyOpeCtrl.BeginControl();
        }

        #endregion  // <操作権限制御/>

        private static string[] _parameter;
        private static System.Windows.Forms.Form _form = null;

        private SumDemandPrintAcs _demandPrintAcs = null;

        // イベントフラグ
        private bool _eventDoFlag = false;
        private Hashtable _delPDFList = null;							// 削除PDF格納リスト

        private PdfHistoryControl _pdfHistoryCtrl = null;				// PDF履歴管理部品

        private bool _isOptCmnTextOutPut = false;						// テキスト出力オプション
        
        #endregion

        // ===================================================================================== //
        // 内部メソッド
        // ===================================================================================== //
        #region private method
        /// <summary>
        /// 初期設定データ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期設定データの読込を行います。</br>
        /// <br></br>
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
        /// <br>Note       : 初期画面設定を行います。</br>
        /// <br></br>
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

            // 抽出のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool extractButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
            if (extractButton != null) extractButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;

            // プレビューのアイコン設定            
            Infragistics.Win.UltraWinToolbars.ButtonTool previewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
            if (previewButton != null) previewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;

            // 印刷のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
            if (printButton != null) printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;

            // --- ADD m.suzuki 2010/06/23 ---------->>>>>
            // 印刷プレビューのアイコン設定(PDF出力と同じ)
            Infragistics.Win.UltraWinToolbars.ButtonTool printPreviewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
            if ( printPreviewButton != null ) printPreviewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;
            // --- ADD m.suzuki 2010/06/23 ----------<<<<<

            // ユーザー設定のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool setUpButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_USERSETUP_KEY];
            if (setUpButton != null) setUpButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

            // 書類選択
            Infragistics.Win.UltraWinToolbars.ComboBoxTool printKindComb = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
            if (printKindComb != null)
            {
                printKindComb.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
            }

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

            // テキスト出力
            Infragistics.Win.UltraWinToolbars.ButtonTool textOputPutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
            if (textOputPutButton != null) textOputPutButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;

            PurchaseStatus purchaseStatus =
                LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (purchaseStatus == PurchaseStatus.Contract ||			// 契約済
                    purchaseStatus == PurchaseStatus.Trial_Contract)	// 体験版契約済
            {
                this._isOptCmnTextOutPut = true;
            }
            else
            {
                this._isOptCmnTextOutPut = false;
            }
            
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
        /// <br>Note       : フォームコントロールクラスをクリエイトし、データを格納します。</br>
        /// <br></br>
        /// </remarks>
        private void FormControlInfoCreate()
        {
            this._formControlInfoTable.Clear();
            FormControlInfo info0 = null;
            FormControlInfo info1 = null;
            FormControlInfo info2 = null;
            
            switch (_startMode)
            {
                case START_MODE_DEFAULT_LIST:			// 請求一覧表（総括）
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "PMHNB02252U", "Broadleaf.Windows.Forms.PMHNB02252UA", "請求一覧表（統括）", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
                case START_MODE_DEFAULT_TOTAL:			// 請求書（総括）
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "PMHNB02252U", "Broadleaf.Windows.Forms.PMHNB02252UA", "請求書（統括）", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
                default:
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "PMHNB02250U", "Broadleaf.Windows.Forms.PMHNB02252UA", "請求書（統括）メイン", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
            }

            info1 = new FormControlInfo(NO1_LISTPREVIEW_TAB, "PMHNB02250U", "Broadleaf.Windows.Forms.PMHNB02250UB", "請求一覧表（総括）プレビュー", IconResourceManagement.ImageList16.Images[(int)Size16_Index.PREVIEW]);
            this._formControlInfoTable.Add(NO1_LISTPREVIEW_TAB, info1);

            info2 = new FormControlInfo(NO2_TOTALPREVIEW_TAB, "PMHNB02250U", "Broadleaf.Windows.Forms.PMHNB02250UB", TOTAL_PREVIEW_TAB_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.PREVIEW]);
            this._formControlInfoTable.Add(NO2_TOTALPREVIEW_TAB, info2);
        }

        /// <summary>
        /// タブクリエイト処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : タブフォームを生成します。</br>
        /// <br></br>
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
                        if (this._extractionInfoForm is ISumDemandTbsMDIChildMain)
                        {
                            ((ISumDemandTbsMDIChildMain)this._extractionInfoForm).Show((Object)_startMode);
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

                        // 請求書系フレーム対応：PDFを一括表示
                        if (_startMode.Equals(START_MODE_DEFAULT_TOTAL))
                        {
                            // TODO:最近出力した一覧表のPDF表示タブの名称変更はここで
                        }

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

                        // 請求書系フレーム対応：PDFを一括表示
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
                    case NO2_TOTALPREVIEW_TAB:  // 請求書（総括）
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
        /// <br></br>
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
        /// <param>none</param>
        /// <returns>none</returns>
        /// <remarks>
        /// <br>Note       : MDI子画面を生成する</br>
        /// <br></br>
        /// </remarks>
        private Form CreateTabForm(FormControlInfo info)
        {
            Form form = null;

            // 各種フォームのインスタンス可
            switch (info.Key)
            {
                case NO0_DEMANDMAIN_TAB:
                {
                    form = new Broadleaf.Windows.Forms.PMHNB02252UA();
                    ((PMHNB02252UA)form).SelectedPdfNodeEvent += new SelectedPdfNodeEventHandler(this.SelectedPdfView);
                    ((PMHNB02252UA)form).StatusBarInfoPrinted += new PrintStatusBar(this.PrintStatusBar);
                    break;
                }
                case NO1_LISTPREVIEW_TAB:
                case NO2_TOTALPREVIEW_TAB:
                    form = new Broadleaf.Windows.Forms.PMHNB02250UB();
                    break;
                default:
                    break;
            }

            // 請求書系フレーム対応：PDFを一括表示
            // 二つ目以降のPDFプレビューフォームを生成
            if (form == null)
            {
                if (info.Key.Contains(NO2_TOTALPREVIEW_TAB))
                {
                    form = new Broadleaf.Windows.Forms.PMHNB02250UB();
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

                if (form is ISumDemandTbsMDIChildMain)
                {
                    ((ISumDemandTbsMDIChildMain)form).Show((Object)_startMode);
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
        /// <br>Note       : ＰＤＦ履歴を表示します。</br>
        /// <br></br>
        /// </remarks>
        private void SelectedPdfView(string key, string printName, string pdfpath)
        {

            // プレビュータブ生成　★請求一覧タブが固定
            this.TabCreate(NO1_LISTPREVIEW_TAB);
            if (this._listPreviewForm != null)
            {
                this.TabActive(NO1_LISTPREVIEW_TAB, ref this._listPreviewForm);

                PMHNB02250UB target = this._listPreviewForm as PMHNB02250UB;

                if (target != null)
                {
                    target.IsSave = false;
                    target.PrintKey = "";
                    target.PrintName = "";
                    target.PrintDetailName = "";
                    target.PrintPDFPath = "";
                    target.Navigate((Object)pdfpath);
                }

                // ツールバーボタン設定
                this.ToolBarSetting(target);
            }
        }

        /// <summary>
        /// ツールバー項目状態設定
        /// </summary>
        /// <param name="key"></param>
        private void ToolbarConditionSetting(string key)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;
            Infragistics.Win.UltraWinToolbars.LabelTool lblTool;
            Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool;
            Infragistics.Win.UltraWinToolbars.ControlContainerTool containerTool;

            // 書類選択表示フラグ
            bool isPrintKindComb = false;

            // 印刷一時中断ラベル
            lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_STOPLABEL_KEY];
            if (lblTool != null) lblTool.SharedProps.Visible = false;

            // 印刷一時中断枚数
            containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
            if (containerTool != null) containerTool.SharedProps.Visible = false;

            // 印刷枚数ラベル
            lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_NUMBERLABEL_KEY];
            if (lblTool != null) lblTool.SharedProps.Visible = false;

            switch (key)
            {
                case NO0_DEMANDMAIN_TAB:
                    {
                        // 抽出
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                        // 書類選択ラベル
                        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDTITLE_KEY];

                        // 書類選択コンボ
                        combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];

                        switch (_startMode)
                        {
                            case START_MODE_DEFAULT_LIST:			// 請求一覧表（総括）
                            case START_MODE_DEFAULT_TOTAL:			// 請求書（総括）
                                {
                                    isPrintKindComb = true;

                                    switch (_startMode)
                                    {

                                        case START_MODE_DEFAULT_LIST:			// 請求一覧表（総括）
                                            {
                                                combboxTool.SelectedIndex = 0;
                                                break;
                                            }
                                        case START_MODE_DEFAULT_TOTAL:			// 請求書（総括）
                                            {
                                                combboxTool.SelectedIndex = 1;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            default:
                                {
                                    isPrintKindComb = true;
                                    break;
                                }
                        }
                        if (lblTool != null) lblTool.SharedProps.Visible = isPrintKindComb;
                        if (combboxTool != null) combboxTool.SharedProps.Visible = isPrintKindComb;

                        // 印刷
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                        // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                        // 印刷プレビュー
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                        if ( buttonTool != null ) buttonTool.SharedProps.Visible = (_startMode != START_MODE_DEFAULT_LIST);
                        // --- ADD m.suzuki 2010/06/23 ----------<<<<<

                        // PDF表示
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                        // テキスト出力
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                        // 現状はテキスト出力機能はなし
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        
                        // 現在選択中の書類により一時中断ボタンの表示を切替える
                        if (combboxTool != null && combboxTool.SelectedItem is Infragistics.Win.ValueListItem)
                        {
                            Infragistics.Win.ValueListItem item = combboxTool.SelectedItem as Infragistics.Win.ValueListItem;

                            int selectPrint = Convert.ToInt32(item.DataValue);

                            // 請求書（総括）？
                            if (selectPrint == 2)
                            {
                                // 印刷一時中断ラベル
                                lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_STOPLABEL_KEY];
                                if (lblTool != null) lblTool.SharedProps.Visible = true;

                                // 印刷一時中断枚数
                                containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                                if (containerTool != null) containerTool.SharedProps.Visible = true;

                                // 印刷枚数ラベル
                                lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_NUMBERLABEL_KEY];
                                if (lblTool != null) lblTool.SharedProps.Visible = true;
                            }
                            else
                            {
                                // 印刷一時中断ラベル
                                lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_STOPLABEL_KEY];
                                if (lblTool != null) lblTool.SharedProps.Visible = false;

                                // 印刷一時中断枚数
                                containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                                if (containerTool != null) containerTool.SharedProps.Visible = false;

                                // 印刷枚数ラベル
                                lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_NUMBERLABEL_KEY];
                                if (lblTool != null) lblTool.SharedProps.Visible = false;
                            }

                        }

                        // ユーザー設定
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_USERSETUP_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;

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
                        // 書類選択ラベル
                        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDTITLE_KEY];
                        if (lblTool != null) lblTool.SharedProps.Visible = false;
                        // 書類選択コンボ
                        combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
                        if (combboxTool != null) combboxTool.SharedProps.Visible = false;
                        // プレビュー
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // 印刷
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                        // 印刷プレビュー
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                        if ( buttonTool != null ) buttonTool.SharedProps.Visible = false;
                        // --- ADD m.suzuki 2010/06/23 ----------<<<<<
                        // ユーザー設定
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_USERSETUP_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // PDF履歴保存
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // テキスト出力
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
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
        /// <br></br>
        /// </remarks>
        private void SavePDF( string key )
        {
            try
            {
                // 請求書系フレーム対応：PDFを一括表示
                FormControlInfo info= null;
                PMHNB02250UB target = null;
                if (this._formControlInfoTable.Contains(key))
                {
                    // アクティブタブから帳票コントロール情報を取得
                    info = this._formControlInfoTable[key] as FormControlInfo;

                    // PDFプレビューフォーム
                    if (info != null) target = info.Form as PMHNB02250UB;
                }
                else
                {
                    // 複数PDFプレビュー用処理
                    if (OtherPDFPreviewFormMap.ContainsKey(key))
                    {
                        target = OtherPDFPreviewFormMap[key] as PMHNB02250UB;
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
                            TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "該当のＰＤＦは既に履歴登録されています。", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        // --- UPD m.suzuki 2010/07/28 ---------->>>>>
                        //// 出力履歴管理に追加
                        //this._pdfHistoryCtrl.AddPrintHistoryList(target.PrintKey, target.PrintName, target.PrintDetailName,
                        //    target.PrintPDFPath);

                        //// 削除リストから除外する
                        //if (this._delPDFList.Contains(target.PrintPDFPath))
                        //{
                        //    this._delPDFList.Remove(target.PrintPDFPath);
                        //}

                        # region [削除リストから除外する]
                        // 全てのタブについて
                        foreach ( Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Main_UTabControl.Tabs )
                        {
                            FormControlInfo wkInfo = null;
                            PMHNB02250UB wkTarget = null;
                            if ( this._formControlInfoTable.Contains( tab.Key ) )
                            {
                                wkInfo = this._formControlInfoTable[tab.Key] as FormControlInfo;
                                if ( wkInfo != null ) wkTarget = wkInfo.Form as PMHNB02250UB;
                            }
                            else
                            {
                                if ( OtherPDFPreviewFormMap.ContainsKey( tab.Key ) )
                                {
                                    wkTarget = OtherPDFPreviewFormMap[tab.Key] as PMHNB02250UB;
                                }
                            }
                            if ( wkTarget == null ) continue;

                            // プレビュー表示タブならばPDF削除リストから除外する
                            if ( wkTarget.IsSave )
                            {
                                // 出力履歴管理に追加
                                this._pdfHistoryCtrl.AddPrintHistoryList( wkTarget.PrintKey, wkTarget.PrintName, wkTarget.PrintDetailName,
                                    wkTarget.PrintPDFPath );

                                // 削除リストから除外する
                                if ( this._delPDFList.Contains( wkTarget.PrintPDFPath ) )
                                {
                                    this._delPDFList.Remove( wkTarget.PrintPDFPath );
                                }
                            }
                        }
                        # endregion
                        // --- UPD m.suzuki 2010/07/28 ----------<<<<<
                    }

                    TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "保存しました。", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "ＰＤＦの履歴保存に失敗しました。" + "\n\r" + ex.Message,
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
        /// <br></br>
        /// </remarks>
        private void ToolBarSetting(object activeForm)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;
            Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool;
            Infragistics.Win.UltraWinToolbars.ControlContainerTool containerTool;

            if (activeForm != null)
            {
                if (activeForm is ISumDemandTbsMDIChildMain)
                {
                    // 抽出
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = true;
                    }

                    // 書類選択コンボ
                    bool isEnbled = false;
                    combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
                    if (combboxTool != null)
                    {
                        switch (_startMode)
                        {
                            case START_MODE_DEFAULT_LIST:			// 請求一覧表（総括）
                            case START_MODE_DEFAULT_TOTAL:			// 請求書（総括）
                                {
                                    isEnbled = true;
                                    break;
                                }
                        }
                        combboxTool.SharedProps.Enabled = isEnbled;
                    }

                    // 現在選択中の書類により一時中断ボタンの表示を切替える
                    if (combboxTool != null && combboxTool.SelectedItem is Infragistics.Win.ValueListItem)
                    {
                        Infragistics.Win.ValueListItem item = combboxTool.SelectedItem as Infragistics.Win.ValueListItem;

                        int selectPrint = Convert.ToInt32(item.DataValue);

                        // 請求書（総括）？
                        if (selectPrint == 2)
                        {
                            // 印刷一時中断枚数
                            containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                            if (containerTool != null)
                            {
                                containerTool.SharedProps.Enabled = true;
                            }

                        }
                        else
                        {
                            // 印刷一時中断枚数
                            containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                            if (containerTool != null)
                            {
                                containerTool.SharedProps.Enabled = false;
                            }
                        }

                        // 請求一覧表（総括）
                        if (selectPrint == 1)
                        {
                            // PDF表示
                            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                            if (buttonTool != null)
                            {
                                buttonTool.SharedProps.Enabled = true;
                            }

                            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                            if (buttonTool != null) buttonTool.SharedProps.Enabled = true;
                        }
                        // 請求書（総括）
                        else
                        {
                            // PDF表示
                            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                            if (buttonTool != null)
                            {
                                // PDF表示ボタンを有効
                                buttonTool.SharedProps.Enabled = true;
                            }

                            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                            if (buttonTool != null) buttonTool.SharedProps.Enabled = false;
                        }
                    }

                    // 印刷
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = true;
                    }
                    // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                    // 印刷プレビュー
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                    if ( buttonTool != null )
                    {
                        buttonTool.SharedProps.Enabled = (_startMode != START_MODE_DEFAULT_LIST);
                    }
                    // --- ADD m.suzuki 2010/06/23 ----------<<<<<

                    // PDF履歴保存
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                }
                else if (activeForm is PMHNB02250UB)
                {
                    // 抽出
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
                    if (combboxTool != null)
                    {
                        combboxTool.SharedProps.Enabled = false;
                    }

                    // 印刷一時中断枚数
                    containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                    if (containerTool != null)
                    {
                        containerTool.SharedProps.Enabled = false;
                    }

                    // 印刷
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                    // 印刷プレビュー
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                    if ( buttonTool != null )
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // --- ADD m.suzuki 2010/06/23 ----------<<<<<

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
                        PMHNB02250UB target = activeForm as PMHNB02250UB;
                        if (target != null)
                        {
                            buttonTool.SharedProps.Enabled = target.IsSave;
                        }
                    }

                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                    if (buttonTool != null) buttonTool.SharedProps.Enabled = false;
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

                combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
                if (combboxTool != null)
                {
                    combboxTool.SharedProps.Enabled = false;
                }

                // 印刷一時中断枚数
                containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                if (containerTool != null)
                {
                    containerTool.SharedProps.Enabled = false;
                }

                // 印刷
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                // 印刷プレビュー
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                if ( buttonTool != null )
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                // --- ADD m.suzuki 2010/06/23 ----------<<<<<

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

                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                if (buttonTool != null) buttonTool.SharedProps.Enabled = false;
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
        /// <br>Note       : 出力件数の設定を行います。</br>
        /// <br></br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, CT_PGID, iMsg, iSt, iButton, iDefButton);
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
        /// </remarks>
        private void PMHNB02250UA_Load(object sender, System.EventArgs e)
        {
            // 初期画面設定
            this.InitialScreenSetting();

            // タイトル設定
            this.Text = MAIN_FORM_TITLE;

            switch (_startMode)
            {
                case START_MODE_DEFAULT_LIST:			// 請求一覧表（総括）
                    this.Text = MAIN_FORM_TITLE + " - " + "請求一覧表（総括）";
                    break;
                case START_MODE_DEFAULT_TOTAL:			// 請求書（総括）
                    this.Text = MAIN_FORM_TITLE + " - " + "請求書（総括）";
                    break;
                default:
                    this.Text = MAIN_FORM_TITLE;
                    break;
            }

            // ツールバーの初期設定
            this.ToolbarConditionSetting(NO0_DEMANDMAIN_TAB);
            
            // ウインドウボタン作成処理
            this.CreateWindowStateButtonTools();

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// 初期処理タイマーイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 初期タイマーイベントです。</br>
        /// <br></br>
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

                // メイン画面起動
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
        /// <br></br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
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

                        if (activeForm is ISumDemandTbsMDIChildMain)
                        {
                            int printType = 0;

                            // 抽出する帳票種類取得
                            Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool =
                              Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
                            if (combboxTool != null)
                            {
                                Infragistics.Win.ValueListItem item = combboxTool.SelectedItem as Infragistics.Win.ValueListItem;
                                printType = Convert.ToInt32(item.DataValue);
                            }
                            else
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, "印刷する帳票を選択して下さい。", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                return;
                            }

                            // 画面入力チェック
                            this.Main_ToolbarsManager.Enabled = false;
                            try
                            {
                                // --- DEL  大矢睦美  2010/02/01 ---------->>>>>
                                //if (((ISumDemandTbsMDIChildMain)activeForm).ScreenInputCheck())
                                // --- DEL  大矢睦美  2010/02/01 ----------<<<<<
                                {
                                    ((ISumDemandTbsMDIChildMain)activeForm).ExtractData(printType);
                                }
                            }
                            finally
                            {
                                this.Main_ToolbarsManager.Enabled = true;
                            }
                        }
                        break;
                    }

                case TOOLBAR_PREVIEWBUTTON_KEY: // プレビュー
                case TOOLBAR_PRINTBUTTON_KEY: // 印刷
                // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                case TOOLBAR_PRINTPREVIEWBUTTON_KEY: // 印刷プレビュー
                // --- ADD m.suzuki 2010/06/23 ----------<<<<<
                    {
                        // 請求一覧以外は確認ダイアログを表示
                        if (!_startMode.Equals(START_MODE_DEFAULT_LIST) && e.Tool.Key.Equals(TOOLBAR_PRINTBUTTON_KEY))
                        {
                            DialogResult dialogResult = MessageBox.Show(
                                "印刷しますか？",   // LITERAL:
                                this.Text,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );
                            if (dialogResult.Equals(DialogResult.No)) return;
                        }
                        
                        // アクティブ状態のタブからフォームを取得する
                        FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                        System.Windows.Forms.Form activeForm = formControlInfo.Form;

                        if ((activeForm is ISumDemandTbsMDIChildMain))
                        {
                            SFCMN06002C printInfo = new SFCMN06002C();
                            printInfo.pdfopen = false;
                            printInfo.pdftemppath = "";

                            // 請求一覧表以外はダイアログ制御が無いので、常に「0:プレビューなし」
                            if (!_startMode.Equals(START_MODE_DEFAULT_LIST))
                            {
                                printInfo.pdfopen = true;
                                // --- UPD m.suzuki 2010/06/23 ---------->>>>>
                                //printInfo.prevkbn = 0;
                                if ( e.Tool.Key != TOOLBAR_PRINTPREVIEWBUTTON_KEY )
                                {
                                    printInfo.prevkbn = 0; // 0:プレビューなし
                                }
                                else
                                {
                                    printInfo.prevkbn = 1; // 1:プレビューあり
                                }
                                // --- UPD m.suzuki 2010/06/23 ----------<<<<<
                            }
                            
                            // 印刷する帳票種類取得
                            Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool =
                                Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
                            if (combboxTool != null)
                            {
                                Infragistics.Win.ValueListItem item = combboxTool.SelectedItem as Infragistics.Win.ValueListItem;
                                printInfo.PrintPaperSetCd = Convert.ToInt32(item.DataValue);

                                // 請求書（総括）か
                                if (printInfo.PrintPaperSetCd == 2)
                                {
                                    ;
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, "印刷する帳票を選択して下さい。", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                return;
                            }

                            // 印刷モードの設定
                            int printMode = 0;
                            switch (e.Tool.Key)
                            {
                                case TOOLBAR_PRINTBUTTON_KEY:
                                // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                                case TOOLBAR_PRINTPREVIEWBUTTON_KEY:
                                // --- ADD m.suzuki 2010/06/23 ----------<<<<<

                                    if ((printInfo.PrintPaperSetCd == 1) || (printInfo.PrintPaperSetCd == 3))	// 請求一覧表（総括）
                                    {
                                        // 両方印刷
                                        printMode = (int)emPrintMode.emPrinterAndPDF;
                                    }
                                    else																	    // 請求書（総括）
                                    {
                                        // 通常印刷
                                        printMode = (int)emPrintMode.emPrinter;
                                    }
                                    break;
                                case TOOLBAR_PREVIEWBUTTON_KEY:
                                    // ＰＤＦ出力
                                    printMode = (int)emPrintMode.emPDF;
                                    break;
                                default:
                                    break;
                            }
                            printInfo.printmode = printMode;

                            ISumDemandTbsMDIChildMain interFase = activeForm as ISumDemandTbsMDIChildMain;

                            Object parameter = (Object)printInfo;
                            int status = interFase.Print(ref parameter);

                            switch (status)
                            {
                                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                    {
                                        // ＰＤＦ出力場合のみ
                                        if (printMode == (int)emPrintMode.emPDF)
                                        {
                                            // ＰＤＦ削除リストに追加
                                            if (printInfo.pdftemppath != "")
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
                                            if (activeForm is PMHNB02252UA)
                                            {
                                                CurrentOutputPDF = ((PMHNB02252UA)activeForm).OutputPDF;
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
                                                PMHNB02250UB target = null;
                                                string key = "";

                                                switch (printInfo.PrintPaperSetCd)
                                                {
                                                    case 1: // 請求一覧表（総括）
                                                    case 3: // 請求一覧表(総括)総括得意先内訳：印字する
                                                        // プレビュータブ生成
                                                        this.TabCreate(NO1_LISTPREVIEW_TAB);
                                                        if (this._listPreviewForm != null)
                                                        {
                                                            frm = this._listPreviewForm;
                                                            target = frm as PMHNB02250UB;
                                                            key = NO1_LISTPREVIEW_TAB;

                                                            // ウインドウボタン作成処理
                                                            this.CreateWindowStateButtonTools();
                                                        }
                                                        break;
                                                    case 2: // 請求書（総括）
                                                        // プレビュータブ生成
                                                        this.TabCreate(NO2_TOTALPREVIEW_TAB);
                                                        if (this._totalPreviewForm != null)
                                                        {
                                                            frm = this._totalPreviewForm;
                                                            target = frm as PMHNB02250UB;
                                                            key = NO2_TOTALPREVIEW_TAB;
                                                        }

                                                        // 請求書系フレーム対応：PDFを一括表示
                                                        if (activeForm is PMHNB02252UA)
                                                        {
                                                            if (CurrentOutputPDF.ExistsOtherPDFPreview)
                                                            {
                                                                for (int i = 1; i < CurrentOutputPDF.PreviewPDFPathList.Count; i++)
                                                                {
                                                                    AddOtherPDFPreviewTab(NO2_TOTALPREVIEW_TAB, i);
                                                                }
                                                            }
                                                        }                                                        
                                                        break;
                                                    default:
                                                        break;
                                                }

                                                if (target != null)
                                                {
                                                    target.IsSave = true;
                                                    target.PrintKey = printInfo.key;
                                                    target.PrintName = printInfo.prpnm;
                                                    target.PrintDetailName = printInfo.prpnm;
                                                    target.PrintPDFPath = printInfo.pdftemppath;
                                                    target.Navigate(printInfo.pdftemppath);
                                                    // 請求書系フレーム対応：PDFを一括表示
                                                    if (CurrentOutputPDF.ExistsOtherPDFPreview)
                                                    {
                                                        // 二つ目以降のPDFを表示
                                                        string originalKey = key;

                                                        for (int i = 1; i < CurrentOutputPDF.PreviewPDFPathList.Count; i++)
                                                        {
                                                            string otherKey = GetOtherPDFPreviewFormKey(originalKey, i);
                                                            PMHNB02250UB otherTarget = OtherPDFPreviewFormMap[otherKey] as PMHNB02250UB;
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

                case TOOLBAR_USERSETUP_KEY:
                    {
                        break;
                    }

                case TOOLBAR_PDFSAVEBUTTON_KEY:
                    {
                        this.SavePDF(this.Main_UTabControl.ActiveTab.Key.ToString());
                        break;
                    }

                case TOOLBAR_TEXTOUTPUT_KEY:
                    {
                        // アクティブ状態のタブからフォームを取得する
                        FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                        System.Windows.Forms.Form activeForm = formControlInfo.Form;

                        if ((activeForm is ICustomTextSelectAndWriter))
                        {
                            ICustomTextSelectAndWriter interFase = activeForm as ICustomTextSelectAndWriter;

                            if (interFase == null) return;

                            // テキスト出力
                            CustomTextProviderInfo customTextProviderInfo = new CustomTextProviderInfo();
                            interFase.SelectInfoAndMakeCustomText(null, "", "", ref customTextProviderInfo);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ツールバーの項目値変更イベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : ツールバー項目の値が変更された際に発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
        {
            Infragistics.Win.UltraWinToolbars.LabelTool lblTool;
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainer;
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;


            if (e.Tool.Key == TOOLBAR_PRINTKINDCOMB_KEY)
            {
                Infragistics.Win.UltraWinToolbars.ComboBoxTool comboTool =
                  e.Tool as Infragistics.Win.UltraWinToolbars.ComboBoxTool;

                if (comboTool != null && comboTool.SelectedItem is Infragistics.Win.ValueListItem)
                {
                    Infragistics.Win.ValueListItem item = comboTool.SelectedItem as Infragistics.Win.ValueListItem;

                    int selectPrint = Convert.ToInt32(item.DataValue);

                    // 請求書（総括）？
                    if (selectPrint == 2)
                    {
                        controlContainer = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                        if (controlContainer != null) controlContainer.SharedProps.Visible = true;

                        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_STOPLABEL_KEY];
                        if (lblTool != null) lblTool.SharedProps.Visible = true;

                        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_NUMBERLABEL_KEY];
                        if (lblTool != null) lblTool.SharedProps.Visible = true;
                    }
                    else
                    {
                        controlContainer = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                        if (controlContainer != null) controlContainer.SharedProps.Visible = false;
                        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_STOPLABEL_KEY];
                        if (lblTool != null) lblTool.SharedProps.Visible = false;

                        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_NUMBERLABEL_KEY];
                        if (lblTool != null) lblTool.SharedProps.Visible = false;
                    }

                    // 請求一覧表（総括）
                    if (selectPrint == 1)
                    {
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Enabled = true;

                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Enabled = true;
                    }
                    else
                    {
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Enabled = false;

                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Enabled = false;
                    }
                }

                // 帳票種類変更処理
                if (this._eventDoFlag)
                {
                    // アクティブ状態のタブからフォームを取得する
                    FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                    System.Windows.Forms.Form activeForm = formControlInfo.Form;

                    if (activeForm is ISumDemandTbsMDIChildMain)
                    {
                        int printType = 0;

                        // 抽出する帳票種類取得
                        Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool =
                            Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
                        if (combboxTool != null)
                        {
                            Infragistics.Win.ValueListItem item = combboxTool.SelectedItem as Infragistics.Win.ValueListItem;
                            printType = Convert.ToInt32(item.DataValue);
                        }
                        else
                        {
                            return;
                        }

                        ((ISumDemandTbsMDIChildMain)activeForm).ChangePrintType(printType);
                    }
                }
            }
        }

        /// <summary>
        /// タブ選択後処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : タブ選択後に発生するイベントです。</br>
        /// <br></br>
        /// </remarks>
        private void Main_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            // 処理中？
            if (!this._eventDoFlag) return;
            if (e.Tab == null) return;

            string key = e.Tab.Key;

            // 請求書系フレーム対応：PDFを一括表示
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

        /// <summary>
        ///	フォームが閉じられた後に発生するイベントです。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : フォームが閉じられた後に、発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMHNB02250UA_FormClosed(object sender, FormClosedEventArgs e)
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
                        PMHNB02250UB viewFrm = info.Form as PMHNB02250UB;
                        if (viewFrm != null)
                        {
                            viewFrm.Navigate("about:blank");
                            // --- ADD m.suzuki 2010/11/02 ---------->>>>>
                            viewFrm.Close();
                            // --- ADD m.suzuki 2010/11/02 ----------<<<<<
                            viewFrm.Dispose();
                        }
                    }
                }

                // 請求書系フレーム対応：PDFを一括表示
                // 二つ目以降のPDFブラウザに空アドレスを設定（∵表示しているPDFファイルを閉じる為）
                foreach (Form otherForm in OtherPDFPreviewFormMap.Values)
                {
                    PMHNB02250UB otherPreviewForm = otherForm as PMHNB02250UB;
                    if (otherPreviewForm == null) continue;

                    otherPreviewForm.Navigate("about:blank");
                    // --- ADD m.suzuki 2010/11/02 ---------->>>>>
                    otherPreviewForm.Close();
                    // --- ADD m.suzuki 2010/11/02 ----------<<<<<
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
        /// <br></br>
        /// </remarks>
        private void Close_menuItem_Click(object sender, System.EventArgs e)
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

        #region ◆　ウィンドウステートボタンツール構築処理
        /// <summary>
        /// ウィンドウステートボタンツール構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ウインドウ表位置状態ボタンを作成します。</br>
        /// <br></br>
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
        /// <br></br>
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
        private void ClosePDF(
            string tabKey,
            bool withDisposingPreviewForm
        )
        {
            const string EMPTY_URL = "about:blank";

            // 各帳票のブラウザに空アドレスを表示させます。表示しているPDFファイルを閉じる為です。
            if (_formControlInfoTable.ContainsKey(tabKey))
            {
                FormControlInfo info = _formControlInfoTable[tabKey] as FormControlInfo;
                if (info != null)
                {
                    PMHNB02250UB viewFrm = info.Form as PMHNB02250UB;
                    if (viewFrm != null)
                    {
                        viewFrm.Navigate(EMPTY_URL);
                        // --- UPD m.suzuki 2010/11/02 ---------->>>>>
                        //if (withDisposingPreviewForm) viewFrm.Dispose();
                        if ( withDisposingPreviewForm )
                        {
                            viewFrm.Close();
                            viewFrm.Dispose();
                        }
                        // --- UPD m.suzuki 2010/11/02 ----------<<<<<
                    }
                }
            }

            // 二つ目以降のPDFブラウザに空アドレスを設定（∵表示しているPDFファイルを閉じる為）
            if (OtherPDFPreviewFormMap.ContainsKey(tabKey))
            {
                PMHNB02250UB otherPreviewForm = OtherPDFPreviewFormMap[tabKey] as PMHNB02250UB;
                if (otherPreviewForm != null)
                {
                    otherPreviewForm.Navigate(EMPTY_URL);
                    // --- UPD m.suzuki 2010/11/02 ---------->>>>>
                    //if (withDisposingPreviewForm)  otherPreviewForm.Dispose();
                    if ( withDisposingPreviewForm )
                    {
                        otherPreviewForm.Close();
                        otherPreviewForm.Dispose();
                    }
                    // --- UPD m.suzuki 2010/11/02 ----------<<<<<
                }
            }
        }
        
        #region ◎ステータスバーへ出力
        /// <summary>
        /// ステータスバーに情報を表示します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PrintStatusBar(
            object sender,
            PrintStatusBarEventArgs e
        )
        {
            this.Main_StatusBar.Panels["Text"].Text = e.Message;
        }

        #endregion  // ◎ステータスバーへ出力
    }
}
