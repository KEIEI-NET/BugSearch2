//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタインポート・エクスポートフレームクラス
// プログラム概要   : インポート・エクスポートを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  ********-** 作成担当 : FSI菅原 庸平
// 作 成 日  2013/06/12  修正内容 : サポートツール対応、新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : UT鹿庭 一郎
// 修 正 日  2018/09/11  修正内容 : ワンタイムパスワード対応
//----------------------------------------------------------------------------//
#define CHG20060417
#define CLR2
#define REP20060427
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller.Facade;
using Broadleaf.Application.Controller.Util;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 掛率マスタインポート・エクスポートフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : インポート・エクスポートのフレームクラスです。</br>
    /// <br>Programmer : FSI菅原 庸平</br>
    /// <br>Date       : 2013/06/12</br>
    /// </remarks>
    public class PMKHN09810UA : System.Windows.Forms.Form
    {
        # region Private Members (Component)
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09810UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09810UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09810UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09810UA_Toolbars_Dock_Area_Bottom;
        private TMemPos tMemPos1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl Main_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl Sub_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage DataViewTabSharedControlsPage;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private DataSet BindDataSet;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.UltraWinGrid.UltraGrid DataViewGrid;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.MenuItem Close_menuItem;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar2;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl2;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage3;
        private Infragistics.Win.UltraWinTree.UltraTree ultraTree1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage4;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl5;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid2;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar3;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl3;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage5;
        private Infragistics.Win.UltraWinTree.UltraTree ultraTree2;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage6;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl6;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid3;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar4;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl4;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage7;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid4;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar5;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl5;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage8;
        private Infragistics.Win.UltraWinTree.UltraTree ultraTree3;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl8;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl SubImp_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage10;
        private Infragistics.Win.UltraWinTree.UltraTree StartNavigatorINPTree;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl7;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl SubExp_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage9;
        private Infragistics.Win.UltraWinTree.UltraTree StartNavigatorEXPTree;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl9;
        private System.Windows.Forms.ContextMenu TabControl_contextMenu;
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>S
        public PMKHN09810UA()
        {
            InitializeComponent();

            // RemotingConfigurationの読み込み
#if !CLR2
			System.Runtime.Remoting.RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
#endif
            
            this._formattedTextWriter = new FormattedTextWriter();

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
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab6 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab7 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("STOP_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Import_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Import_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserSetUp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool8 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool9 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Forms_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserSetUp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("PrintKindTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("PrintKind_ComboBoxTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool("STOP_LabelTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("PrtSuspendCnt_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool10 = new Infragistics.Win.UltraWinToolbars.LabelTool("Number_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Import_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("SetUp_ButtonTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09810UA));
            this.ultraTabPageControl7 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubExp_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage9 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.StartNavigatorEXPTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTabPageControl8 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubImp_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage10 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.StartNavigatorINPTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.DataViewGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Sub_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.DataViewTabSharedControlsPage = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.Main_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.BindDataSet = new System.Data.DataSet();
            this.Close_menuItem = new System.Windows.Forms.MenuItem();
            this.TabControl_contextMenu = new System.Windows.Forms.ContextMenu();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraStatusBar2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraTabControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage3 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTree1 = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTabSharedControlsPage4 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraStatusBar3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraTabControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage5 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTree2 = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage6 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl6 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGrid3 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraStatusBar4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraTabControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage7 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraGrid4 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraStatusBar5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraTabControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage8 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTree3 = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTabPageControl9 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this._PMKHN09810UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._PMKHN09810UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09810UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraTabPageControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubExp_UTabControl)).BeginInit();
            this.SubExp_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorEXPTree)).BeginInit();
            this.ultraTabPageControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubImp_UTabControl)).BeginInit();
            this.SubImp_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorINPTree)).BeginInit();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_UTabControl)).BeginInit();
            this.Sub_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).BeginInit();
            this.Main_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindDataSet)).BeginInit();
            this.ultraTabPageControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl2)).BeginInit();
            this.ultraTabControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree1)).BeginInit();
            this.ultraTabPageControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl3)).BeginInit();
            this.ultraTabControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.ultraTabPageControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl5)).BeginInit();
            this.ultraTabControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl7
            // 
            this.ultraTabPageControl7.Controls.Add(this.SubExp_UTabControl);
            this.ultraTabPageControl7.Controls.Add(this.StartNavigatorEXPTree);
            this.ultraTabPageControl7.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl7.Name = "ultraTabPageControl7";
            this.ultraTabPageControl7.Size = new System.Drawing.Size(1014, 595);
            // 
            // SubExp_UTabControl
            // 
            appearance68.BackColor = System.Drawing.Color.White;
            appearance68.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance68.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.SubExp_UTabControl.Appearance = appearance68;
            this.SubExp_UTabControl.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.SubExp_UTabControl.Controls.Add(this.ultraTabSharedControlsPage9);
            this.SubExp_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubExp_UTabControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SubExp_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.SubExp_UTabControl.Location = new System.Drawing.Point(201, 0);
            this.SubExp_UTabControl.Name = "SubExp_UTabControl";
            this.SubExp_UTabControl.SharedControlsPage = this.ultraTabSharedControlsPage9;
            this.SubExp_UTabControl.Size = new System.Drawing.Size(813, 595);
            this.SubExp_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.SubExp_UTabControl.TabIndex = 38;
            this.SubExp_UTabControl.TabPadding = new System.Drawing.Size(3, 3);
            this.SubExp_UTabControl.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SubExp_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.SubExp_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.SubExp_UTabControl_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage9
            // 
            this.ultraTabSharedControlsPage9.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage9.Name = "ultraTabSharedControlsPage9";
            this.ultraTabSharedControlsPage9.Size = new System.Drawing.Size(811, 574);
            // 
            // StartNavigatorEXPTree
            // 
            this.StartNavigatorEXPTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.StartNavigatorEXPTree.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.StartNavigatorEXPTree.Location = new System.Drawing.Point(0, 0);
            this.StartNavigatorEXPTree.Name = "StartNavigatorEXPTree";
            this.StartNavigatorEXPTree.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.StartNavigatorEXPTree.SettingsKey = "PMKHN09810UA.StartNavigatorEXPTree";
            this.StartNavigatorEXPTree.Size = new System.Drawing.Size(201, 595);
            this.StartNavigatorEXPTree.TabIndex = 35;
            this.StartNavigatorEXPTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartNavigatorEXPTree_MouseDown);
            this.StartNavigatorEXPTree.DoubleClick += new System.EventHandler(this.StartNavigatorEXPTree_DoubleClick);
            // 
            // ultraTabPageControl8
            // 
            this.ultraTabPageControl8.Controls.Add(this.SubImp_UTabControl);
            this.ultraTabPageControl8.Controls.Add(this.StartNavigatorINPTree);
            this.ultraTabPageControl8.Location = new System.Drawing.Point(1, 25);
            this.ultraTabPageControl8.Name = "ultraTabPageControl8";
            this.ultraTabPageControl8.Size = new System.Drawing.Size(1014, 595);
            // 
            // SubImp_UTabControl
            // 
            appearance37.BackColor = System.Drawing.Color.White;
            appearance37.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.SubImp_UTabControl.Appearance = appearance37;
            this.SubImp_UTabControl.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.SubImp_UTabControl.Controls.Add(this.ultraTabSharedControlsPage10);
            this.SubImp_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubImp_UTabControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SubImp_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.SubImp_UTabControl.Location = new System.Drawing.Point(201, 0);
            this.SubImp_UTabControl.Name = "SubImp_UTabControl";
            this.SubImp_UTabControl.SharedControlsPage = this.ultraTabSharedControlsPage10;
            this.SubImp_UTabControl.Size = new System.Drawing.Size(813, 595);
            this.SubImp_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.SubImp_UTabControl.TabIndex = 38;
            this.SubImp_UTabControl.TabPadding = new System.Drawing.Size(3, 3);
            this.SubImp_UTabControl.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SubImp_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.SubImp_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.SubImp_UTabControl_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage10
            // 
            this.ultraTabSharedControlsPage10.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage10.Name = "ultraTabSharedControlsPage10";
            this.ultraTabSharedControlsPage10.Size = new System.Drawing.Size(811, 574);
            // 
            // StartNavigatorINPTree
            // 
            this.StartNavigatorINPTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.StartNavigatorINPTree.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.StartNavigatorINPTree.Location = new System.Drawing.Point(0, 0);
            this.StartNavigatorINPTree.Name = "StartNavigatorINPTree";
            this.StartNavigatorINPTree.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.StartNavigatorINPTree.SettingsKey = "PMKHN09810UA.StartNavigatorINPTree";
            this.StartNavigatorINPTree.Size = new System.Drawing.Size(201, 595);
            this.StartNavigatorINPTree.TabIndex = 35;
            this.StartNavigatorINPTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartNavigatorINPTree_MouseDown);
            this.StartNavigatorINPTree.DoubleClick += new System.EventHandler(this.StartNavigatorINPTree_DoubleClick);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.DataViewGrid);
            this.ultraTabPageControl1.Controls.Add(this.ultraStatusBar1);
            this.ultraTabPageControl1.Controls.Add(this.Sub_UTabControl);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(992, 591);
            // 
            // DataViewGrid
            // 
            appearance47.BackColor = System.Drawing.Color.White;
            appearance47.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.DataViewGrid.DisplayLayout.Appearance = appearance47;
            this.DataViewGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.DataViewGrid.DisplayLayout.InterBandSpacing = 10;
            this.DataViewGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.DataViewGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.DataViewGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.DataViewGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.DataViewGrid.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.DataViewGrid.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.DataViewGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.DataViewGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.Color.Transparent;
            this.DataViewGrid.DisplayLayout.Override.CardAreaAppearance = appearance48;
            this.DataViewGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance65.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance65.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance65.ForeColor = System.Drawing.Color.White;
            appearance65.TextHAlignAsString = "Left";
            appearance65.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.DataViewGrid.DisplayLayout.Override.HeaderAppearance = appearance65;
            this.DataViewGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.DataViewGrid.DisplayLayout.Override.MaxSelectedRows = 100;
            appearance50.BackColor = System.Drawing.Color.Lavender;
            this.DataViewGrid.DisplayLayout.Override.RowAlternateAppearance = appearance50;
            appearance51.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.DataViewGrid.DisplayLayout.Override.RowAppearance = appearance51;
            this.DataViewGrid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.DataViewGrid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance52.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance52.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance52.ForeColor = System.Drawing.Color.White;
            this.DataViewGrid.DisplayLayout.Override.RowSelectorAppearance = appearance52;
            this.DataViewGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.DataViewGrid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.DataViewGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance53.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance53.ForeColor = System.Drawing.Color.Black;
            this.DataViewGrid.DisplayLayout.Override.SelectedRowAppearance = appearance53;
            this.DataViewGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.DataViewGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.DataViewGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.DataViewGrid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.DataViewGrid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.DataViewGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.DataViewGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.DataViewGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.DataViewGrid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.DataViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataViewGrid.Location = new System.Drawing.Point(0, 360);
            this.DataViewGrid.Name = "DataViewGrid";
            this.DataViewGrid.Size = new System.Drawing.Size(992, 231);
            this.DataViewGrid.TabIndex = 41;
            // 
            // ultraStatusBar1
            // 
            appearance54.FontData.BoldAsString = "True";
            appearance54.FontData.Name = "ＭＳ ゴシック";
            appearance54.FontData.SizeInPoints = 11F;
            this.ultraStatusBar1.Appearance = appearance54;
            this.ultraStatusBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 332);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Padding = new Infragistics.Win.UltraWinStatusBar.UIElementMargins(20, 2, 0, 0);
            this.ultraStatusBar1.Size = new System.Drawing.Size(992, 28);
            this.ultraStatusBar1.TabIndex = 40;
            this.ultraStatusBar1.Text = "出力結果イメージ";
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Sub_UTabControl
            // 
            appearance55.BackColor = System.Drawing.Color.White;
            appearance55.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Sub_UTabControl.Appearance = appearance55;
            this.Sub_UTabControl.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.Sub_UTabControl.Controls.Add(this.DataViewTabSharedControlsPage);
            this.Sub_UTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Sub_UTabControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Sub_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.Sub_UTabControl.Location = new System.Drawing.Point(0, 0);
            this.Sub_UTabControl.Name = "Sub_UTabControl";
            this.Sub_UTabControl.SharedControlsPage = this.DataViewTabSharedControlsPage;
            this.Sub_UTabControl.Size = new System.Drawing.Size(992, 332);
            this.Sub_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Sub_UTabControl.TabIndex = 38;
            this.Sub_UTabControl.TabPadding = new System.Drawing.Size(3, 3);
            this.Sub_UTabControl.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Sub_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Sub_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.Sub_UTabControl_SelectedTabChanged);
            // 
            // DataViewTabSharedControlsPage
            // 
            this.DataViewTabSharedControlsPage.Location = new System.Drawing.Point(1, 20);
            this.DataViewTabSharedControlsPage.Name = "DataViewTabSharedControlsPage";
            this.DataViewTabSharedControlsPage.Size = new System.Drawing.Size(990, 311);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point(0, 690);
            this.Main_StatusBar.Name = "Main_StatusBar";
            appearance2.TextHAlignAsString = "Center";
            this.Main_StatusBar.PanelAppearance = appearance2;
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
            // Main_UTabControl
            // 
            appearance10.BackColor = System.Drawing.Color.White;
            appearance10.BackColor2 = System.Drawing.Color.LightPink;
            this.Main_UTabControl.ActiveTabAppearance = appearance10;
            appearance19.BackColor = System.Drawing.Color.White;
            appearance19.BackColor2 = System.Drawing.Color.Lavender;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Main_UTabControl.Appearance = appearance19;
            this.Main_UTabControl.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.Main_UTabControl.Controls.Add(this.ultraTabPageControl8);
            this.Main_UTabControl.Controls.Add(this.ultraTabPageControl7);
            this.Main_UTabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.Main_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_UTabControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Main_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.Main_UTabControl.Location = new System.Drawing.Point(0, 69);
            this.Main_UTabControl.Name = "Main_UTabControl";
            this.Main_UTabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.Main_UTabControl.Size = new System.Drawing.Size(1016, 621);
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.TabIndex = 34;
            this.Main_UTabControl.TabPadding = new System.Drawing.Size(80, 3);
            ultraTab6.TabPage = this.ultraTabPageControl7;
            ultraTab6.Tag = "export";
            ultraTab6.Text = "ｴｸｽﾎﾟｰﾄ";
            ultraTab7.TabPage = this.ultraTabPageControl8;
            ultraTab7.Tag = "import";
            ultraTab7.Text = "ｲﾝﾎﾟｰﾄ";
            this.Main_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab6,
            ultraTab7});
            this.Main_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Main_UTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.Main_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.Main_UTabControl_SelectedTabChanged);
            this.Main_UTabControl.Click += new System.EventHandler(this.Main_UTabControl_Click);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(1014, 595);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(1014, 623);
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(1014, 623);
            // 
            // BindDataSet
            // 
            this.BindDataSet.DataSetName = "NewDataSet";
            this.BindDataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Close_menuItem
            // 
            this.Close_menuItem.Index = 0;
            this.Close_menuItem.Text = "閉じる(&C)";
            this.Close_menuItem.Click += new System.EventHandler(this.Close_menuItem_Click);
            // 
            // TabControl_contextMenu
            // 
            this.TabControl_contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Close_menuItem});
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(1, 25);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(992, 622);
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.ultraGrid1);
            this.ultraTabPageControl4.Controls.Add(this.ultraStatusBar2);
            this.ultraTabPageControl4.Controls.Add(this.ultraTabControl2);
            this.ultraTabPageControl4.Controls.Add(this.ultraTree1);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(1, 25);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(992, 622);
            // 
            // ultraGrid1
            // 
            appearance59.BackColor = System.Drawing.Color.White;
            appearance59.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid1.DisplayLayout.Appearance = appearance59;
            this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid1.DisplayLayout.InterBandSpacing = 10;
            this.ultraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ultraGrid1.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.ultraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid1.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.ultraGrid1.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.ultraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance60.BackColor = System.Drawing.Color.Transparent;
            this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance60;
            this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.ForeColor = System.Drawing.Color.White;
            appearance8.TextHAlignAsString = "Left";
            appearance8.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance8;
            this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid1.DisplayLayout.Override.MaxSelectedRows = 100;
            appearance9.BackColor = System.Drawing.Color.Lavender;
            this.ultraGrid1.DisplayLayout.Override.RowAlternateAppearance = appearance9;
            appearance6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance6;
            this.ultraGrid1.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.ultraGrid1.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance61.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance61.ForeColor = System.Drawing.Color.White;
            this.ultraGrid1.DisplayLayout.Override.RowSelectorAppearance = appearance61;
            this.ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid1.DisplayLayout.Override.RowSelectorWidth = 12;
            this.ultraGrid1.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance64.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance64.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance64;
            this.ultraGrid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ultraGrid1.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.ultraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Location = new System.Drawing.Point(201, 360);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(791, 262);
            this.ultraGrid1.TabIndex = 41;
            // 
            // ultraStatusBar2
            // 
            appearance94.FontData.BoldAsString = "True";
            appearance94.FontData.Name = "ＭＳ ゴシック";
            appearance94.FontData.SizeInPoints = 11F;
            this.ultraStatusBar2.Appearance = appearance94;
            this.ultraStatusBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraStatusBar2.Location = new System.Drawing.Point(201, 332);
            this.ultraStatusBar2.Name = "ultraStatusBar2";
            this.ultraStatusBar2.Padding = new Infragistics.Win.UltraWinStatusBar.UIElementMargins(20, 2, 0, 0);
            this.ultraStatusBar2.Size = new System.Drawing.Size(791, 28);
            this.ultraStatusBar2.TabIndex = 40;
            this.ultraStatusBar2.Text = "出力結果イメージ";
            this.ultraStatusBar2.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // ultraTabControl2
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraTabControl2.Appearance = appearance1;
            this.ultraTabControl2.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraTabControl2.Controls.Add(this.ultraTabSharedControlsPage3);
            this.ultraTabControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraTabControl2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraTabControl2.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.ultraTabControl2.Location = new System.Drawing.Point(201, 0);
            this.ultraTabControl2.Name = "ultraTabControl2";
            this.ultraTabControl2.SharedControlsPage = this.ultraTabSharedControlsPage3;
            this.ultraTabControl2.Size = new System.Drawing.Size(791, 332);
            this.ultraTabControl2.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.ultraTabControl2.TabIndex = 38;
            this.ultraTabControl2.TabPadding = new System.Drawing.Size(3, 3);
            this.ultraTabControl2.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraTabControl2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabSharedControlsPage3
            // 
            this.ultraTabSharedControlsPage3.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage3.Name = "ultraTabSharedControlsPage3";
            this.ultraTabSharedControlsPage3.Size = new System.Drawing.Size(789, 311);
            // 
            // ultraTree1
            // 
            this.ultraTree1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraTree1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraTree1.Location = new System.Drawing.Point(0, 0);
            this.ultraTree1.Name = "ultraTree1";
            this.ultraTree1.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.ultraTree1.SettingsKey = "PMKHN09810UA.ultraTree1";
            this.ultraTree1.Size = new System.Drawing.Size(201, 622);
            this.ultraTree1.TabIndex = 35;
            // 
            // ultraTabSharedControlsPage4
            // 
            this.ultraTabSharedControlsPage4.Location = new System.Drawing.Point(1, 25);
            this.ultraTabSharedControlsPage4.Name = "ultraTabSharedControlsPage4";
            this.ultraTabSharedControlsPage4.Size = new System.Drawing.Size(992, 622);
            // 
            // ultraTabPageControl5
            // 
            this.ultraTabPageControl5.Controls.Add(this.ultraGrid2);
            this.ultraTabPageControl5.Controls.Add(this.ultraStatusBar3);
            this.ultraTabPageControl5.Controls.Add(this.ultraTabControl3);
            this.ultraTabPageControl5.Controls.Add(this.ultraTree2);
            this.ultraTabPageControl5.Location = new System.Drawing.Point(1, 25);
            this.ultraTabPageControl5.Name = "ultraTabPageControl5";
            this.ultraTabPageControl5.Size = new System.Drawing.Size(992, 622);
            // 
            // ultraGrid2
            // 
            appearance38.BackColor = System.Drawing.Color.White;
            appearance38.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid2.DisplayLayout.Appearance = appearance38;
            this.ultraGrid2.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid2.DisplayLayout.InterBandSpacing = 10;
            this.ultraGrid2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ultraGrid2.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.ultraGrid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid2.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid2.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.ultraGrid2.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.ultraGrid2.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.ultraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance39.BackColor = System.Drawing.Color.Transparent;
            this.ultraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance39;
            this.ultraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance40.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance40.ForeColor = System.Drawing.Color.White;
            appearance40.TextHAlignAsString = "Left";
            appearance40.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid2.DisplayLayout.Override.HeaderAppearance = appearance40;
            this.ultraGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid2.DisplayLayout.Override.MaxSelectedRows = 100;
            appearance41.BackColor = System.Drawing.Color.Lavender;
            this.ultraGrid2.DisplayLayout.Override.RowAlternateAppearance = appearance41;
            appearance42.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.ultraGrid2.DisplayLayout.Override.RowAppearance = appearance42;
            this.ultraGrid2.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.ultraGrid2.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance43.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance43.ForeColor = System.Drawing.Color.White;
            this.ultraGrid2.DisplayLayout.Override.RowSelectorAppearance = appearance43;
            this.ultraGrid2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid2.DisplayLayout.Override.RowSelectorWidth = 12;
            this.ultraGrid2.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance44.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance44.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance44;
            this.ultraGrid2.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid2.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid2.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ultraGrid2.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.ultraGrid2.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.ultraGrid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ultraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid2.Location = new System.Drawing.Point(201, 360);
            this.ultraGrid2.Name = "ultraGrid2";
            this.ultraGrid2.Size = new System.Drawing.Size(791, 262);
            this.ultraGrid2.TabIndex = 41;
            // 
            // ultraStatusBar3
            // 
            appearance45.FontData.BoldAsString = "True";
            appearance45.FontData.Name = "ＭＳ ゴシック";
            appearance45.FontData.SizeInPoints = 11F;
            this.ultraStatusBar3.Appearance = appearance45;
            this.ultraStatusBar3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraStatusBar3.Location = new System.Drawing.Point(201, 332);
            this.ultraStatusBar3.Name = "ultraStatusBar3";
            this.ultraStatusBar3.Padding = new Infragistics.Win.UltraWinStatusBar.UIElementMargins(20, 2, 0, 0);
            this.ultraStatusBar3.Size = new System.Drawing.Size(791, 28);
            this.ultraStatusBar3.TabIndex = 40;
            this.ultraStatusBar3.Text = "出力結果イメージ";
            this.ultraStatusBar3.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // ultraTabControl3
            // 
            appearance46.BackColor = System.Drawing.Color.White;
            appearance46.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraTabControl3.Appearance = appearance46;
            this.ultraTabControl3.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraTabControl3.Controls.Add(this.ultraTabSharedControlsPage5);
            this.ultraTabControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraTabControl3.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraTabControl3.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.ultraTabControl3.Location = new System.Drawing.Point(201, 0);
            this.ultraTabControl3.Name = "ultraTabControl3";
            this.ultraTabControl3.SharedControlsPage = this.ultraTabSharedControlsPage5;
            this.ultraTabControl3.Size = new System.Drawing.Size(791, 332);
            this.ultraTabControl3.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.ultraTabControl3.TabIndex = 38;
            this.ultraTabControl3.TabPadding = new System.Drawing.Size(3, 3);
            this.ultraTabControl3.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraTabControl3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabSharedControlsPage5
            // 
            this.ultraTabSharedControlsPage5.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage5.Name = "ultraTabSharedControlsPage5";
            this.ultraTabSharedControlsPage5.Size = new System.Drawing.Size(789, 311);
            // 
            // ultraTree2
            // 
            this.ultraTree2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraTree2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraTree2.Location = new System.Drawing.Point(0, 0);
            this.ultraTree2.Name = "ultraTree2";
            this.ultraTree2.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.ultraTree2.SettingsKey = "PMKHN09810UA.ultraTree2";
            this.ultraTree2.Size = new System.Drawing.Size(201, 622);
            this.ultraTree2.TabIndex = 35;
            // 
            // ultraTabControl1
            // 
            appearance18.BackColor = System.Drawing.Color.White;
            appearance18.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraTabControl1.Appearance = appearance18;
            this.ultraTabControl1.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage6);
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage6;
            this.ultraTabControl1.Size = new System.Drawing.Size(200, 100);
            this.ultraTabControl1.TabIndex = 0;
            // 
            // ultraTabSharedControlsPage6
            // 
            this.ultraTabSharedControlsPage6.Location = new System.Drawing.Point(2, 21);
            this.ultraTabSharedControlsPage6.Name = "ultraTabSharedControlsPage6";
            this.ultraTabSharedControlsPage6.Size = new System.Drawing.Size(196, 77);
            // 
            // ultraTabPageControl6
            // 
            this.ultraTabPageControl6.Controls.Add(this.ultraGrid3);
            this.ultraTabPageControl6.Controls.Add(this.ultraStatusBar4);
            this.ultraTabPageControl6.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl6.Name = "ultraTabPageControl6";
            this.ultraTabPageControl6.Size = new System.Drawing.Size(196, 77);
            // 
            // ultraGrid3
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid3.DisplayLayout.Appearance = appearance3;
            this.ultraGrid3.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid3.DisplayLayout.InterBandSpacing = 10;
            this.ultraGrid3.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ultraGrid3.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.ultraGrid3.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid3.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid3.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.ultraGrid3.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.ultraGrid3.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.ultraGrid3.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.ultraGrid3.DisplayLayout.Override.CardAreaAppearance = appearance4;
            this.ultraGrid3.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.TextHAlignAsString = "Left";
            appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid3.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.ultraGrid3.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid3.DisplayLayout.Override.MaxSelectedRows = 100;
            appearance63.BackColor = System.Drawing.Color.Lavender;
            this.ultraGrid3.DisplayLayout.Override.RowAlternateAppearance = appearance63;
            appearance13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.ultraGrid3.DisplayLayout.Override.RowAppearance = appearance13;
            this.ultraGrid3.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.ultraGrid3.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.ForeColor = System.Drawing.Color.White;
            this.ultraGrid3.DisplayLayout.Override.RowSelectorAppearance = appearance14;
            this.ultraGrid3.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid3.DisplayLayout.Override.RowSelectorWidth = 12;
            this.ultraGrid3.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid3.DisplayLayout.Override.SelectedRowAppearance = appearance15;
            this.ultraGrid3.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid3.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid3.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ultraGrid3.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.ultraGrid3.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.ultraGrid3.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid3.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid3.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ultraGrid3.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid3.Location = new System.Drawing.Point(0, 28);
            this.ultraGrid3.Name = "ultraGrid3";
            this.ultraGrid3.Size = new System.Drawing.Size(196, 49);
            this.ultraGrid3.TabIndex = 41;
            // 
            // ultraStatusBar4
            // 
            appearance17.FontData.BoldAsString = "True";
            appearance17.FontData.Name = "ＭＳ ゴシック";
            appearance17.FontData.SizeInPoints = 11F;
            this.ultraStatusBar4.Appearance = appearance17;
            this.ultraStatusBar4.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraStatusBar4.Location = new System.Drawing.Point(0, 0);
            this.ultraStatusBar4.Name = "ultraStatusBar4";
            this.ultraStatusBar4.Padding = new Infragistics.Win.UltraWinStatusBar.UIElementMargins(20, 2, 0, 0);
            this.ultraStatusBar4.Size = new System.Drawing.Size(196, 28);
            this.ultraStatusBar4.TabIndex = 40;
            this.ultraStatusBar4.Text = "出力結果イメージ";
            this.ultraStatusBar4.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // ultraTabControl4
            // 
            appearance16.BackColor = System.Drawing.Color.White;
            appearance16.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraTabControl4.Appearance = appearance16;
            this.ultraTabControl4.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraTabControl4.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl4.Name = "ultraTabControl4";
            this.ultraTabControl4.SharedControlsPage = this.ultraTabSharedControlsPage7;
            this.ultraTabControl4.Size = new System.Drawing.Size(200, 100);
            this.ultraTabControl4.TabIndex = 0;
            // 
            // ultraTabSharedControlsPage7
            // 
            this.ultraTabSharedControlsPage7.Location = new System.Drawing.Point(2, 21);
            this.ultraTabSharedControlsPage7.Name = "ultraTabSharedControlsPage7";
            this.ultraTabSharedControlsPage7.Size = new System.Drawing.Size(196, 77);
            // 
            // ultraGrid4
            // 
            appearance20.BackColor = System.Drawing.Color.White;
            appearance20.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid4.DisplayLayout.Appearance = appearance20;
            this.ultraGrid4.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid4.DisplayLayout.InterBandSpacing = 10;
            this.ultraGrid4.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ultraGrid4.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.ultraGrid4.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid4.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid4.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.ultraGrid4.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.ultraGrid4.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.ultraGrid4.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance21.BackColor = System.Drawing.Color.Transparent;
            this.ultraGrid4.DisplayLayout.Override.CardAreaAppearance = appearance21;
            this.ultraGrid4.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance22.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance22.ForeColor = System.Drawing.Color.White;
            appearance22.TextHAlignAsString = "Left";
            appearance22.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid4.DisplayLayout.Override.HeaderAppearance = appearance22;
            this.ultraGrid4.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid4.DisplayLayout.Override.MaxSelectedRows = 100;
            appearance23.BackColor = System.Drawing.Color.Lavender;
            this.ultraGrid4.DisplayLayout.Override.RowAlternateAppearance = appearance23;
            appearance24.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.ultraGrid4.DisplayLayout.Override.RowAppearance = appearance24;
            this.ultraGrid4.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.ultraGrid4.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance25.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance25.ForeColor = System.Drawing.Color.White;
            this.ultraGrid4.DisplayLayout.Override.RowSelectorAppearance = appearance25;
            this.ultraGrid4.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid4.DisplayLayout.Override.RowSelectorWidth = 12;
            this.ultraGrid4.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance26.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance26.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid4.DisplayLayout.Override.SelectedRowAppearance = appearance26;
            this.ultraGrid4.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid4.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid4.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ultraGrid4.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.ultraGrid4.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.ultraGrid4.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid4.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid4.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ultraGrid4.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid4.Location = new System.Drawing.Point(201, 360);
            this.ultraGrid4.Name = "ultraGrid4";
            this.ultraGrid4.Size = new System.Drawing.Size(791, 262);
            this.ultraGrid4.TabIndex = 41;
            // 
            // ultraStatusBar5
            // 
            appearance27.FontData.BoldAsString = "True";
            appearance27.FontData.Name = "ＭＳ ゴシック";
            appearance27.FontData.SizeInPoints = 11F;
            this.ultraStatusBar5.Appearance = appearance27;
            this.ultraStatusBar5.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraStatusBar5.Location = new System.Drawing.Point(201, 332);
            this.ultraStatusBar5.Name = "ultraStatusBar5";
            this.ultraStatusBar5.Padding = new Infragistics.Win.UltraWinStatusBar.UIElementMargins(20, 2, 0, 0);
            this.ultraStatusBar5.Size = new System.Drawing.Size(791, 28);
            this.ultraStatusBar5.TabIndex = 40;
            this.ultraStatusBar5.Text = "出力結果イメージ";
            this.ultraStatusBar5.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // ultraTabControl5
            // 
            appearance28.BackColor = System.Drawing.Color.White;
            appearance28.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraTabControl5.Appearance = appearance28;
            this.ultraTabControl5.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraTabControl5.Controls.Add(this.ultraTabSharedControlsPage8);
            this.ultraTabControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraTabControl5.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraTabControl5.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.ultraTabControl5.Location = new System.Drawing.Point(201, 0);
            this.ultraTabControl5.Name = "ultraTabControl5";
            this.ultraTabControl5.SharedControlsPage = this.ultraTabSharedControlsPage8;
            this.ultraTabControl5.Size = new System.Drawing.Size(791, 332);
            this.ultraTabControl5.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.ultraTabControl5.TabIndex = 38;
            this.ultraTabControl5.TabPadding = new System.Drawing.Size(3, 3);
            this.ultraTabControl5.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraTabControl5.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabSharedControlsPage8
            // 
            this.ultraTabSharedControlsPage8.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage8.Name = "ultraTabSharedControlsPage8";
            this.ultraTabSharedControlsPage8.Size = new System.Drawing.Size(789, 311);
            // 
            // ultraTree3
            // 
            this.ultraTree3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraTree3.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraTree3.Location = new System.Drawing.Point(0, 0);
            this.ultraTree3.Name = "ultraTree3";
            this.ultraTree3.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.ultraTree3.SettingsKey = "PMKHN09810UA.ultraTree3";
            this.ultraTree3.Size = new System.Drawing.Size(201, 622);
            this.ultraTree3.TabIndex = 35;
            // 
            // ultraTabPageControl9
            // 
            this.ultraTabPageControl9.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl9.Name = "ultraTabPageControl9";
            this.ultraTabPageControl9.Size = new System.Drawing.Size(1014, 591);
            // 
            // _PMKHN09810UA_Toolbars_Dock_Area_Left
            // 
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 69);
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.Name = "_PMKHN09810UA_Toolbars_Dock_Area_Left";
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 621);
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Main_ToolbarsManager
            // 
            this.Main_ToolbarsManager.DesignerFlags = 1;
            this.Main_ToolbarsManager.DockWithinContainer = this;
            this.Main_ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.Main_ToolbarsManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.Main_ToolbarsManager.SettingsKey = "PMKHN09810UA.Main_ToolbarsManager";
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
            popupMenuTool4,
            popupMenuTool5,
            labelTool1,
            labelTool2,
            labelTool3});
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            labelTool4,
            buttonTool2,
            buttonTool3,
            buttonTool4});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "標準";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            popupMenuTool6.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool8.InstanceProps.IsFirstInGroup = true;
            popupMenuTool6.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8});
            popupMenuTool7.SharedProps.Caption = "ツール(&T)";
            popupMenuTool7.SharedProps.Visible = false;
            popupMenuTool7.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9});
            popupMenuTool8.SharedProps.Caption = "ウィンドウ(&W)";
            labelTool6.SharedProps.Caption = "ログイン担当者";
            labelTool6.SharedProps.ShowInCustomizer = false;
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Bottom";
            labelTool7.SharedProps.AppearancesSmall.Appearance = appearance7;
            labelTool7.SharedProps.ShowInCustomizer = false;
            labelTool7.SharedProps.Width = 150;
            buttonTool10.SharedProps.Caption = "終了(&X)";
            buttonTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool10.SharedProps.ShowInCustomizer = false;
            buttonTool11.SharedProps.Caption = "ユーザー設定(&C)";
            buttonTool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool11.SharedProps.ShowInCustomizer = false;
            labelTool8.SharedProps.Caption = "書類選択";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            comboBoxTool1.SharedProps.Caption = "書類選択";
            buttonTool12.SharedProps.Caption = "抽出(&E)";
            buttonTool12.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool13.SharedProps.Caption = "PDF表示(&V)";
            buttonTool13.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool14.SharedProps.Caption = "印刷(&P)";
            buttonTool14.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            controlContainerTool1.SharedProps.MaxWidth = 40;
            controlContainerTool1.SharedProps.MinWidth = 40;
            controlContainerTool1.SharedProps.Width = 41;
            labelTool10.SharedProps.Caption = "枚";
            labelTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool15.SharedProps.Caption = "PDF履歴保存(&S)";
            buttonTool15.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool15.SharedProps.Enabled = false;
            buttonTool16.SharedProps.Caption = "テキスト出力(&O)";
            buttonTool16.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool16.SharedProps.Visible = false;
            buttonTool17.SharedProps.Caption = "ｴｸｽﾎﾟｰﾄ(&O)";
            buttonTool17.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool18.SharedProps.Caption = "ｲﾝﾎﾟｰﾄ(&I)";
            buttonTool18.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool19.SharedProps.Caption = "設定(&M)";
            buttonTool19.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool6,
            popupMenuTool7,
            popupMenuTool8,
            popupMenuTool9,
            labelTool5,
            labelTool6,
            labelTool7,
            buttonTool10,
            buttonTool11,
            labelTool8,
            comboBoxTool1,
            buttonTool12,
            buttonTool13,
            buttonTool14,
            labelTool9,
            controlContainerTool1,
            labelTool10,
            buttonTool15,
            buttonTool16,
            buttonTool17,
            buttonTool18,
            buttonTool19});
            this.Main_ToolbarsManager.ToolTipDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolTipDisplayStyle.Standard;
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            this.Main_ToolbarsManager.ToolValueChanged += new Infragistics.Win.UltraWinToolbars.ToolEventHandler(this.Main_ToolbarsManager_ToolValueChanged);
            // 
            // _PMKHN09810UA_Toolbars_Dock_Area_Right
            // 
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 69);
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.Name = "_PMKHN09810UA_Toolbars_Dock_Area_Right";
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 621);
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN09810UA_Toolbars_Dock_Area_Top
            // 
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.Name = "_PMKHN09810UA_Toolbars_Dock_Area_Top";
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 69);
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN09810UA_Toolbars_Dock_Area_Bottom
            // 
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 690);
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.Name = "_PMKHN09810UA_Toolbars_Dock_Area_Bottom";
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // PMKHN09810UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.ClientSize = new System.Drawing.Size(1016, 713);
            this.Controls.Add(this.Main_UTabControl);
            this.Controls.Add(this._PMKHN09810UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMKHN09810UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._PMKHN09810UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._PMKHN09810UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.Main_StatusBar);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09810UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "掛率設定エクスポート・インポート";
            this.Load += new System.EventHandler(this.PMKHN09810UA_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PMKHN09810UA_FormClosed);
            this.ultraTabPageControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SubExp_UTabControl)).EndInit();
            this.SubExp_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorEXPTree)).EndInit();
            this.ultraTabPageControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SubImp_UTabControl)).EndInit();
            this.SubImp_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorINPTree)).EndInit();
            this.ultraTabPageControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataViewGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_UTabControl)).EndInit();
            this.Sub_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).EndInit();
            this.Main_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BindDataSet)).EndInit();
            this.ultraTabPageControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl2)).EndInit();
            this.ultraTabControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree1)).EndInit();
            this.ultraTabPageControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl3)).EndInit();
            this.ultraTabControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.ultraTabPageControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl5)).EndInit();
            this.ultraTabControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree3)).EndInit();
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
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string msg = "";
                _parameter = args;
                //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                //int status = 0;

                if (status == 0)
                {

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

                        // UPD 2018/09/11 ワンタイムパスワード対応 ----------->>>>>
                        //_form = new PMKHN09810UA();
                        //System.Windows.Forms.Application.Run(_form);

                        // ワンタイムパスワード判定
                        SFCMN00660UA passWordGuide = new SFCMN00660UA();
                        string returnCode;
                        string returnMessage;

                        SFCMN00660UA.CheckPasswordResult result =
                            passWordGuide.ShowPassConfirmDialog(SFCMN00660UA.PassWordTypes.OneTimePassOKNG, string.Empty, string.Empty, out returnCode, out returnMessage);
#if DEBUG
                        result = SFCMN00660UA.CheckPasswordResult.Return_OK;
#endif
                        if (result.Equals(SFCMN00660UA.CheckPasswordResult.Return_OK))
                        {
                            _form = new PMKHN09810UA();
                            System.Windows.Forms.Application.Run(_form);
                        }
                        // UPD 2018/09/11 ワンタイムパスワード対応 -----------<<<<<                        
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
        #endregion //Private Enum

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        #region Private Constant
        /// <summary>
        /// 本モジュールのプログラムID
        /// </summary>
        private const string CT_PGID = "PMKHN09810U";

        #region Del 2013.10.28 T.MOTOYAMA
        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
        // private const string CT_PGNAME = "帳票";
        // private const string MAIN_FORM_TITLE = "帳票"; 
        // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////
        #endregion

        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //        
        private const string CT_PGNAME = "掛率設定エクスポート・インポート";
        private const string MAIN_FORM_TITLE = "掛率設定エクスポート・インポート";
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
                
        private const string NAVIGATOREXPTREE_XML = "PMKHN09810U_Navigator_EXP.DAT";
        private const string NAVIGATORINPTREE_XML = "PMKHN09810U_Navigator_INP.DAT";
        private Hashtable _expFormControlInfoTable = new Hashtable();
        private Hashtable _impFormControlInfoTable = new Hashtable();

        // 起動モード定数   

        private Hashtable _formControlInfoTable = new Hashtable();
        private const string NO0_DEMANDMAIN_TAB = "DEMAND_MAIN_TAB";

        // ツールバーツールキー設定
        private const string TOOLBAR_LOGINLABEL_TITLE = "LoginTitle_LabelTool";
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LoginName_LabelTool";
        private const string TOOLBAR_ENDBUTTON_KEY = "End_ButtonTool";

        private const string TOOLBAR_USERSETUP_KEY = "UserSetUp_ButtonTool";

        private const string TOOLBAR_TEXTOUTPUT_KEY = "TextOutPut_ButtonTool";

        private const string TOOLBAR_WINDOW_KEY = "Window_PopupMenuTool";
        private const string TOOLBAR_FORMS_KEY = "Forms_PopupMenuTool";
        private const string TOOLBAR_RESETBUTTON_KEY = "Reset_ButtonTool";

        private const string TOOLBAR_EXPORTBUTTON_KEY = "Export_ButtonTool";
        private const string TOOLBAR_IMPORTBUTTON_KEY = "Import_ButtonTool";

        private const string TOOLBAR_SETUPBUTTON_KEY = "SetUp_ButtonTool";

        // ビューフォーム用追加キー情報(対象アセンブリ_VIEWR)
        private const string TAB_VIEWFORM_ADDKEY = "_VIWER";
        #endregion //Private Constant

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region Private Members
        private static string[] _parameter;
        private static System.Windows.Forms.Form _form = null;

        private Point _lastMouseDown;
        private string _tableName;
        private string _employeeName;
        private bool _buttonEnable = true;

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
        /// ﾃｷｽﾄ出力共通処理オブジェクト
        /// </summary>
        private FormattedTextWriter _formattedTextWriter;

        #endregion //Private Members

        // ===============================================================================
        // デリゲートイベント
        // ===============================================================================
        #region delegateEvent
        /// <summary>
        /// デリゲート
        /// </summary>
        private void ParentToolbarSettingEvent(object sender)
        {
            this.ToolBarSetting(sender);
        }
        #endregion //delegateEvent

        // ===================================================================================== //
        // 内部メソッド
        // ===================================================================================== //
        #region private method

        /// <summary>
        /// 初期画面設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期画面設定を行います。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
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

            // 掛率マスタエクスポートのアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool exportButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
            if (exportButton != null)
            {
                exportButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
                exportButton.SharedProps.Enabled = false;
            }

            // 掛率マスタインポートのアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool importButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
            if (importButton != null)
            {
                importButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVTAKING;
                importButton.SharedProps.Enabled = false;
            }

            Infragistics.Win.UltraWinToolbars.ButtonTool setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
            if (setupButton != null)
            {
                setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
                setupButton.SharedProps.Enabled = false;
            }

            // ユーザー設定のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool setUpButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_USERSETUP_KEY];
            if (setUpButton != null) setUpButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

            // ログイン名
            Infragistics.Win.UltraWinToolbars.LabelTool LoginName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_LOGINNAMELABEL_KEY];
            if (LoginName != null && LoginInfoAcquisition.Employee != null)
            {
                Employee employee = new Employee();
                employee = LoginInfoAcquisition.Employee;
                LoginName.SharedProps.Caption = employee.Name;
                this._employeeName = employee.Name;
            }

            // タブコントロールの設定
            this.Sub_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Sub_UTabControl.InterTabSpacing = 2;
            this.Sub_UTabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopLeft;
            this.Sub_UTabControl.Appearance.FontData.SizeInPoints = 11;

            // タブコントロールの設定
            this.SubExp_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.SubExp_UTabControl.InterTabSpacing = 2;
            this.SubExp_UTabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopLeft;
            this.SubExp_UTabControl.Appearance.FontData.SizeInPoints = 11;
        }



        /// <summary>
        /// タブクリエイト処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : タブフォームを生成します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void TabCreate(string key)
        {
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];

            if (info == null) return;

            // 既にロード済み！
            if (info.Form != null) return;

            this.CreateTabForm(info);
        }

        /// <summary>
        /// タブアクティブ処理
        /// </summary>
        /// <param name="key">対象キー情報</param>
        /// <param name="form">アクティブ化したフォームのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 引数のキー情報を元に、タブをアクティブ化します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void TabActive(string key, ref Form form)
        {
            if (this.Sub_UTabControl.Tabs.Exists(key))
            {
                this.Sub_UTabControl.Tabs[key].Visible = true;
                this.Sub_UTabControl.SelectedTab = this.Sub_UTabControl.Tabs[key];

                form = this.Sub_UTabControl.Tabs[key].Tag as System.Windows.Forms.Form;

                // ウィンドウステイト状態変更
                this.CreateWindowStateButtonTools();

                // WindowStateボタンを選択状態にする
                Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];

                for (int i = 0; i < windowPopupMenuTool.Tools.Count; i++)
                {
                    if (!(windowPopupMenuTool.Tools[i] is Infragistics.Win.UltraWinToolbars.StateButtonTool)) continue;

                    Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[i];

                    if ((this.Sub_UTabControl.SelectedTab != null) && (key == stateButtonTool.Key))
                    {
                        stateButtonTool.Checked = true;
                    }
                    else
                    {
                        stateButtonTool.Checked = false;
                    }
                }
            }
        }

        /// <summary>
        /// Tabフォーム生成処理
        /// </summary>
        /// <param>none</param>
        /// <returns>none</returns>
        /// <remarks>
        /// <br>Note       : MDI子画面を生成する</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private Form CreateTabForm(FormControlInfo info)
        {
            Form form = null;

            form = (System.Windows.Forms.Form)this.LoadAssemblyFrom(info.AssemblyID, info.ClassID, typeof(System.Windows.Forms.Form));

            if (form == null)
            {
                form = new Form();
            }

            if (form != null)
            {
                info.Form = form;

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

#if false
				// システム選択イベント
				if (form is IPrintConditionInpTypeSelectedSystem)
				{
					this._checkedSystemEvent  += new CheckedSystemEventHandler(((IPrintConditionInpTypeSelectedSystem)form).CheckedSystem);
				}
#endif

                this.Sub_UTabControl.Controls.Add(dataviewTabPageControl);
                this.Sub_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
                this.Sub_UTabControl.SelectedTab = dataviewTab;

                // フォームプロパティ変更
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                dataviewTabPageControl.Controls.Add(form);

                // 抽出画面出力
                form.Show();
                form.Dock = System.Windows.Forms.DockStyle.Fill;
            }

            return form;
        }

        /// <summary>
        /// ツールバー項目状態設定
        /// </summary>
        /// <param name="key"></param>
        /// <remarks>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void ToolbarConditionSetting(string key)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;

            // 掛率マスタエクスポート
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = true;
            // 掛率マスタインポート
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = true;

            // 設定
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = true;
        }

        /// <summary>
        /// ビューフォームタブクリエイト処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ビュータブフォームを生成します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void ViewFormTabCreate(string key)
        {
            // ビュー表示元アセンブリ情報取得
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];

            if (info == null) return;

            // 既にロード済み！
            if (info.ViewForm != null) return;

            this.CreateTabForm(info);
        }

        #region ◆　ツールバーの表示・有効設定
        /// <summary>
        /// ツールバーの表示・有効設定
        /// </summary>
        /// <param name="activeForm">アクティブなフォームのオブジェクト</param>
        /// <remarks>
        /// <br>Note       : ツールバーの表示・非表示、有効・無効設定を行います。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void ToolBarSetting(object activeForm)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;

            if (activeForm != null)
            {
                if (activeForm is ICSVExportConditionInpType)
                {
                    // 掛率マスタエクスポートボタン
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = true;
                    }
                    // 掛率マスタインポートボタン
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                }
                else if (activeForm is ICSVImportConditionInpType)
                {
                    // 掛率マスタエクスポートボタン
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // 掛率マスタインポートボタン
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = true;
                    }
                }
            }
            else
            {
                // 掛率マスタエクスポート
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
            if (buttonTool != null)
            {
                    buttonTool.SharedProps.Enabled = false;
            }
            // 掛率マスタインポート
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
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
        /// <br>Note       : 出力件数の設定を行います。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, CT_PGID, iMsg, iSt, iButton, iDefButton);
        }

        /// <summary>
        /// ツリービュー表示
        /// </summary>
        private void ConstructionTreeNode()
        {
            // 起動ナビゲータ情報が格納されたバイナリファイルのロード
            if (System.IO.File.Exists(NAVIGATOREXPTREE_XML))
            {
                this.StartNavigatorEXPTree.LoadFromBinary(NAVIGATOREXPTREE_XML);
            }

            // ツリーの構築処理
            ConstructTreeNode(StartNavigatorEXPTree);

            // 起動ナビゲータ情報が格納されたバイナリファイルのロード
            if (System.IO.File.Exists(NAVIGATORINPTREE_XML))
            {
                this.StartNavigatorINPTree.LoadFromBinary(NAVIGATORINPTREE_XML);
            }

            // ツリーの構築処理
            ConstructTreeNode(StartNavigatorINPTree);

        }

        /// <summary>
        /// 操作権限の制御を開始します。
        /// </summary>
        /// <param name="assemblyId">アセンブリID</param>
        /// <remarks>
        /// <br>Note　　　 : 操作権限に応じたボタン制御の対応</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void BeginControllingByOperationAuthority(string assemblyId)
        {
            #region <Guard Phrase/>

            if (!MyOpeCtrlMap.ContainsKey(assemblyId)) return;

            #endregion  // <Guard Phrase/>

            // ツールボタンの操作権限の制御設定
            List<ToolButtonInfo> toolButtonInfoList = new List<ToolButtonInfo>();

            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_TEXTOUTPUT_KEY, ReportFrameOpeCode.OutputText, false));

            MyOpeCtrlMap[assemblyId].MyOpeCtrl.AddControlItem(this.Main_ToolbarsManager, toolButtonInfoList);

            // 操作権限の制御を開始
            MyOpeCtrlMap[assemblyId].MyOpeCtrl.BeginControl();
        }


        #region ◆　処理条件UI画面個別画面設定処理
        /// <summary>
        /// 処理条件UI画面個別画面設定処理
        /// </summary>
        /// <param name="key">対象キー情報</param>
        /// <param name="activeForm">アクティブ対象となるForm</param>
        /// <remarks>
        /// <br>Note       : 各条件画面個別のフレーム画面を設定します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void ScreenPrivateSetting(string key, System.Windows.Forms.Form activeForm)
        {
            if (activeForm == null) return;

            // コントロール情報取得
            FormControlInfo info = null;
            if (this._formControlInfoTable.ContainsKey(key))
            {
                info = this._formControlInfoTable[key] as FormControlInfo;
            }
            else
            {
                return;
            }

            // 初回起動時はそれぞれの初期値を帳票共通用フォームコントロールクラスに設定
            if (!info.IsInit)
            {
                info.SelSectionKindIndex = 0;												// 拠点種類

                info.SelSystems = info.SoftWareCode;										// システム選択                
            }

            //----------------------------------------------------------------------------//
            // 画面情報更新処理                                                           //
            //----------------------------------------------------------------------------//


            // 初期設定済み
            info.IsInit = true;
        }
        #endregion

        #region ◆　画面コントロールクラス作成処理
        /// <summary>
        /// 画面コントロールクラス作成処理
        /// </summary>
        /// <returns> </returns>
        /// <remarks>
        /// <br>Note       : 各種条件画面のアセンブリ情報を作成します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private int CreateFormControlInfo()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 掛率マスタエクスポート
            status = this.CreateFormControlInfo2(this.StartNavigatorEXPTree, ref this._expFormControlInfoTable);
            // 掛率マスタインポート
            status = this.CreateFormControlInfo2(this.StartNavigatorINPTree, ref this._impFormControlInfoTable);

            return status;

        }
        #endregion

        #region ◆　文字列分割処理
        /// <summary>
        /// 文字列分割処理
        /// </summary>
        /// <param name="target">対象文字列</param>
        /// <param name="id">分割文字１</param>
        /// <param name="prm">分割文字２</param>
        /// <remarks>
        /// <br>Note       : 対象文字列をスペースで２分割します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void SplitTargetAssemblyID(string target, out string id, out string prm)
        {
            id = "";
            prm = "";

            string[] split = target.Split(new Char[] { ' ' });
            if (split != null)
            {
                int i = 0;
                foreach (string wk in split)
                {
                    switch (i)
                    {
                        case 0:		// アセンブリID
                            {
                                id = wk;
                                break;
                            }
                        default:	// 呼出パラメータ
                            {
                                if (prm != "")
                                {
                                    prm += " " + wk;
                                }
                                else
                                {
                                    prm = wk;
                                }
                                break;
                            }
                    }
                    i++;
                }
            }
        }
        #endregion

        #region ◆　指定されたアセンブリ及びクラス名より、クラスをインスタンス化する
        /// <summary>
        /// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化する
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <param name="type">実装するクラス型</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note       : MDI子画面を生成する</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private object LoadAssemblyFrom(string asmname, string classname, Type type)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFrom(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
                    {
                        obj = Activator.CreateInstance(objType);
                    }
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            catch (System.Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    "Message=" + ex.Message + "\r\n" + "Trace  =" + ex.StackTrace + "\r\n" + "Source =" + ex.Source,
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            return obj;
        }
        #endregion

        #region ◆　ウィンドウステートボタンツール構築処理
        /// <summary>
        /// ウィンドウステートボタンツール構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ウインドウ表位置状態ボタンを作成します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void CreateWindowStateButtonTools()
        {
            Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];
            Infragistics.Win.UltraWinToolbars.PopupMenuTool formsPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_FORMS_KEY];

            windowPopupMenuTool.ResetTools();
            formsPopupMenuTool.ResetTools();

            // 「ウィンドウを初期状態に戻す」　ボタンツール追加
            if (!this.Main_ToolbarsManager.Tools.Exists(TOOLBAR_RESETBUTTON_KEY))
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool resetButtonTool = new Infragistics.Win.UltraWinToolbars.ButtonTool(TOOLBAR_RESETBUTTON_KEY);
                resetButtonTool.SharedProps.Caption = "ウィンドウを初期状態に戻す(&R)";
                resetButtonTool.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.WindowResetButtonTool_ToolClick);
                this.Main_ToolbarsManager.Tools.Add(resetButtonTool);
            }
            windowPopupMenuTool.Tools.AddTool(TOOLBAR_RESETBUTTON_KEY);

            Infragistics.Win.UltraWinTabControl.UltraTabControl uTabControl = null;
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                uTabControl = this.SubExp_UTabControl;
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                uTabControl = this.SubImp_UTabControl;
            }

            for (int i = 0; i < uTabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = uTabControl.Tabs[i];

                if (!tab.Visible) continue;

                string key = tab.Key;

                if (this.Main_ToolbarsManager.Tools.Exists(key))
                {
                    windowPopupMenuTool.Tools.AddTool(key);
                    formsPopupMenuTool.Tools.AddTool(key);
                }
                else
                {
                    Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = new Infragistics.Win.UltraWinToolbars.StateButtonTool(key, "TabWindow");
                    stateButtonTool.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
                    stateButtonTool.SharedProps.Caption = tab.Text;
                    stateButtonTool.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.WindowStateButtonTool_ToolClick);
                    stateButtonTool.Tag = true;
                    this.Main_ToolbarsManager.Tools.Add(stateButtonTool);

                    windowPopupMenuTool.Tools.AddTool(key);
                    formsPopupMenuTool.Tools.AddTool(key);
                }

                if ((i == 0) && (windowPopupMenuTool.Tools.Exists(key)))
                {
                    Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[key];
                    stateButtonTool.InstanceProps.IsFirstInGroup = true;
                }
            }
        }
        #endregion

        #region ◆　「ウィンドウを初期値に戻す」ボタンクリック時イベント
        /// <summary>
        /// ウィンドウステートボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ウィンドウステートボタンクリック時に発生します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void WindowResetButtonTool_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {

        }
        #endregion

        #region ◆　ウィンドウステートボタンクリックイベント
        /// <summary>
        /// ウィンドウステートボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ウィンドウステートボタンクリック時に発生します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void WindowStateButtonTool_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (this.SubExp_UTabControl.Tabs.Exists(e.Tool.Key))
            {
                if (!(e.Tool is Infragistics.Win.UltraWinToolbars.StateButtonTool)) return;

                Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)e.Tool;
                if (stateButtonTool.Checked)
                {
                    this.SubExp_UTabControl.SelectedTab = this.SubExp_UTabControl.Tabs[e.Tool.Key];

                    this.SubExp_UTabControl.ContextMenu = this.TabControl_contextMenu;
                    Form selectedForm = this._expFormControlInfoTable[this.SubExp_UTabControl.SelectedTab.Key] as Form;


                    if (selectedForm == null)
                    {
                        if (this._expFormControlInfoTable.Contains(this.SubExp_UTabControl.SelectedTab.Key))
                        {
                            FormControlInfo formInfo = this._expFormControlInfoTable[this.SubExp_UTabControl.SelectedTab.Key] as FormControlInfo;
                            if (formInfo != null) selectedForm = formInfo.Form;
                        }
                    }

                }
            }
            else if (this.SubImp_UTabControl.Tabs.Exists(e.Tool.Key))
            {
                if (!(e.Tool is Infragistics.Win.UltraWinToolbars.StateButtonTool)) return;

                Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)e.Tool;
                if (stateButtonTool.Checked)
                {
                    this.SubImp_UTabControl.SelectedTab = this.SubImp_UTabControl.Tabs[e.Tool.Key];

                    this.SubImp_UTabControl.ContextMenu = this.TabControl_contextMenu;
                    Form selectedForm = this._impFormControlInfoTable[this.SubImp_UTabControl.SelectedTab.Key] as Form;


                    if (selectedForm == null)
                    {
                        if (this._impFormControlInfoTable.Contains(this.SubImp_UTabControl.SelectedTab.Key))
                        {
                            FormControlInfo formInfo = this._impFormControlInfoTable[this.SubImp_UTabControl.SelectedTab.Key] as FormControlInfo;
                            if (formInfo != null) selectedForm = formInfo.Form;
                        }
                    }

                }
            }
        }
        #endregion // ◆　ウィンドウステートボタンクリックイベント

        #region ◆　タブ表示・非表示制御
        /// <summary>
        /// タブ表示／非表示化処理
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="hidden">true:表示 false:非表示</param>
        /// <remarks>
        /// <br>Note       : タブの表示／非表示を制御します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void TabVisibleChange(string key, bool visible)
        {
            for (int i = 0; i < this.Sub_UTabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = this.Sub_UTabControl.Tabs[i];

                if (tab.Key == key)
                {
                    tab.Visible = visible;
                    this.NodeSelectChaneg(key, visible);
                }
            }

            for (int i = 0; i < this.SubExp_UTabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = this.SubExp_UTabControl.Tabs[i];

                if (tab.Key == key)
                {
                    tab.Visible = visible;
                    this.NodeSelectChaneg(key, visible);
                }
            }

            for (int i = 0; i < this.SubImp_UTabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = this.SubImp_UTabControl.Tabs[i];

                if (tab.Key == key)
                {
                    tab.Visible = visible;
                    this.NodeSelectChaneg(key, visible);
                }
            }
        }
        #endregion

        #region ◆　ナビゲーションの該当キーノード選択状態変更
        /// <summary>
        /// ナビゲーションの該当キーノード選択状態変更
        /// </summary>
        /// <param name="key">キー</param>
        /// <remarks>
        /// <br>Note       : ナビゲーションの該当キーノード選択状態を制御します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void NodeSelectChaneg(string key, bool isSelected)
        {
            // 該当キーのノードを取得
            Infragistics.Win.UltraWinTree.UltraTreeNode node = null;
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                node = this.StartNavigatorEXPTree.GetNodeByKey(key);
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                node = this.StartNavigatorINPTree.GetNodeByKey(key);
            }

            if (node != null)
            {
                if (isSelected)
                {
                    node.Override.NodeAppearance.ForeColor = Color.Red;
                }
                else
                {
                    node.Override.NodeAppearance.ForeColor = Color.Black;
                }
            }
        }
        #endregion

        /// <summary>
        /// 初期設定データ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期設定データの読込を行います。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private int InitalDataRead()
        {

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
        /// <br>Note       : メインフレームのLOAD時処理</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void PMKHN09810UA_Load(object sender, System.EventArgs e)
        {
            // 初期画面設定
            this.InitialScreenSetting();

            // タイトル設定
            this.Text = MAIN_FORM_TITLE;

            // 起動ナビゲーター構築
            this.ConstructionTreeNode();

            // ウインドウボタン作成処理
            this.CreateWindowStateButtonTools();

            int status;
            // プログラム情報テーブル構築
            status = this.CreateFormControlInfo();

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    "起動パラメータが不正です。!!",//ahn
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                this.Close();
                return;
            }

            this.ToolbarConditionSetting(NO0_DEMANDMAIN_TAB);

            // 操作権限制御
            if (!MyOpeCtrlMap.ContainsKey(CT_PGID))
            {
                if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                    EntityUtil.CategoryCode.Report,
                    MyOpeCtrlMap.AddController(CT_PGID),
                    CT_PGID,
                    CT_PGNAME
                ))
                {
                    this.Close();   // 起動不可のため強制終了
                }
            }

            BeginControllingByOperationAuthority(CT_PGID);
        }

        /// <summary>
        /// 初期処理タイマーイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 初期タイマーイベントです。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            try
            {

                // 初期設定データ読込
                int status = this.InitalDataRead();
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.Close();
                    return;
                }

                this.TabCreate(NO0_DEMANDMAIN_TAB);

            }
            finally
            {

            }
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : ツールバークリック時に発生します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (_buttonEnable)
            {
                switch (e.Tool.Key)
                {
                    case TOOLBAR_ENDBUTTON_KEY:
                        {
                            this.Close();
                            break;
                        }

                    // テキスト変換
                    case TOOLBAR_EXPORTBUTTON_KEY:
                        {
                            _buttonEnable = false;
                            

                            // アクティブ状態のタブからフォームを取得する
                            FormControlInfo formControlInfo = (FormControlInfo)this._expFormControlInfoTable[this.SubExp_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if (activeForm is ICSVExportConditionInpType)
                            {
                                ICSVExportConditionInpType childObj = activeForm as ICSVExportConditionInpType;

                                // グリッドにバインドさせるデータセットを取得する			
                                DataSet bindDataSet = new DataSet();
                                childObj.GetBindDataSet(ref bindDataSet, ref this._tableName);
                                this.BindDataSet = bindDataSet;

                                //// 抽出データ取得
                                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                Dictionary<string, object> dParam = new Dictionary<string, object>();
                                dParam.Add("LoginSectionCode", LoginInfoAcquisition.Employee.BelongSectionCode.ToString());
                                DateTime systemDate = Convert.ToDateTime(this.Main_StatusBar.Panels["Date"].DisplayText);
                                dParam.Add("SystemDate", systemDate);
                                dParam.Add("SystemYearMonth", systemDate.Year * 100 + systemDate.Month);
                                dParam.Add("SystemYear", systemDate.Year);
                                dParam.Add("SystemMonth", systemDate.Month);
                                dParam.Add("SystemDay", systemDate.Day);
                                Object parameter = dParam;
                                
                                // 抽出前チェック
                                if (!childObj.ExportBeforeCheck())
                                {
                                    _buttonEnable = true;
                                    return;
                                }
                                SFCMN00299CA formexport = new Broadleaf.Windows.Forms.SFCMN00299CA();
                                dParam.Add("formexport", formexport);
                                // 表示文字を設定
                                formexport.Title = "テキスト変換中";
                                formexport.Message = "現在、データをテキスト変換中です。";

                                // ダイアログ表示
                                formexport.Show();
                                this.Cursor = Cursors.WaitCursor;

                                status = childObj.Extract(ref parameter);

                                switch (status)
                                {
                                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                        {
                                            if (this.BindDataSet.Tables[this._tableName].DefaultView.Count <= 0)
                                            {
                                                // ダイアログを閉じる
                                                this.Cursor = Cursors.Default;
                                                formexport.Close();
                                                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                                break;
                                            }

                                            ArrayList paramList = new ArrayList();
                                            object csvParam = paramList;

                                            // CSV出力情報処理
                                            status = childObj.GetCSVInfo(ref csvParam);

                                            // 出力完了場合
                                            if (status == 0)
                                            {
                                                childObj.AfterExportSuccess();
                                            }

                                            // CSV出力処理
                                            status = this.DoOutPut(ref csvParam);

                                            // ダイアログを閉じる
                                            this.Cursor = Cursors.Default;
                                            formexport.Close();

                                            string resultMessage = string.Empty;

                                            switch (status)
                                            {
                                                case 0:    // 処理成功
                                                    resultMessage = "CSVデータを作成しました。";
                                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, resultMessage, status, MessageBoxButtons.OK);
                                                    break;
                                                default:    // その他エラー
                                                    resultMessage = "テキストファイルの書き込みに失敗しました。";
                                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, CT_PGID, resultMessage, 9, MessageBoxButtons.OK);
                                                    break;
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
                            _buttonEnable = true;
                            //_reLoad = true;
                            break;
                        }
                    // テキスト取得
                    case TOOLBAR_IMPORTBUTTON_KEY:
                        {
                            _buttonEnable = false;
                            // アクティブ状態のタブからフォームを取得する
                            FormControlInfo formControlInfo = (FormControlInfo)this._impFormControlInfoTable[this.SubImp_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if (activeForm is ICSVImportConditionInpType)
                            {
                                ICSVImportConditionInpType childObj = activeForm as ICSVImportConditionInpType;

                                // CSVファイルリスト
                                List<string[]> csvDataList = new List<string[]>();

                                // CSVファイル名
                                string csvFileName = childObj.ImportFileName();

                                // インポート前のチェック処理
                                if (childObj.IsUseBaseCheck())
                                {
                                    // エラーメッセージ
                                    string errMsg = string.Empty;

                                    if (!CheckInputFileName(csvFileName, out errMsg) ||
                                        !CheckInputFileExists(csvFileName, out errMsg))
                                    {
                                        // フォーカスの設定
                                        childObj.CheckErrEvent();
                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, errMsg, 0, MessageBoxButtons.OK);
                                        _buttonEnable = true;
                                        return;
                                    }
                                    bool isReadErr = false;
                                    if (!CheckInputFileDataExists(csvFileName, out errMsg, out csvDataList, out isReadErr))
                                    {
                                        // フォーカスの設定
                                        childObj.CheckErrEvent();
                                        if (isReadErr)
                                        {
                                            // 読込エラー
                                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, errMsg, 0, MessageBoxButtons.OK);
                                            
                                        }
                                        else
                                        {
                                            if (csvDataList.Count == 0)
                                            {
                                                // レコードがない
                                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, errMsg, 0, MessageBoxButtons.OK);
                                            }
                                        }
                                        _buttonEnable = true;
                                        return;
                                    }                                    
                                    // CSV先頭行項目数チェック
                                    if (csvDataList.Count > 0)
                                    {

                                        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                                        if (!CheckCSVextension(csvFileName, out errMsg))
                                        {
                                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, errMsg, 0, MessageBoxButtons.OK);
                                            _buttonEnable = true;
                                            return;
                                        }
                                        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
                                        
                                        if (!childObj.ItemCntCheck(csvDataList[0].Length))
                                        {
                                            errMsg = "取込対象外のファイルです。";
                                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, errMsg, 0, MessageBoxButtons.OK);
                                            _buttonEnable = true;
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    // 子画面のチェック処理
                                    if (!childObj.ImportBeforeCheck())
                                    {
                                        _buttonEnable = true;
                                        return;
                                    }
                                }

                                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                                try
                                {
                                    // 子画面のインポート処理
                                    status = childObj.Import(csvDataList);
                                }
                                catch (Exception ex)
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, ex.Message, status, MessageBoxButtons.OK);
                                }
                                finally
                                {
                                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                    {
                                        if (System.IO.File.Exists(csvFileName) == true)
                                        {
                                            // 登録が正常に完了した場合は取込したCSVファイルを削除する
                                            try
                                            {
                                                //System.IO.File.Delete(csvFileName);
                                            }
                                            catch
                                            {
                                            }
                                        }

                                        // 登録完了ダイアログ
                                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                                        dialog.ShowDialog(2);
                                    }
                                }
                            }
                            _buttonEnable = true;
                            break;
                        }
                }
            }
        }


        /// <summary>
        /// ツールバーの項目値変更イベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : ツールバー項目の値が変更された際に発生します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
        {

        }

        /// <summary>
        /// タブ選択後処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : タブ選択後に発生するイベントです。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void Sub_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

            this.DataViewGrid.DataSource = null;

#if CHG20060417
            if (e.Tab == null) return;

            if (!this._formControlInfoTable.Contains(e.Tab.Key))
            {
                return;
            }

            string key = e.Tab.Key;
            FormControlInfo info = this._formControlInfoTable[key] as FormControlInfo;
            Form target = info.Form;

            this.TabActive(key, ref target);

            this.ToolBarSetting(target);
#else
			ToolbarConditionSetting(e.Tab.Key.ToString());
#endif
        }

        /// <summary>
        ///	フォームが閉じられた後に発生するイベントです。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : フォームが閉じられた後に、発生します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void PMKHN09810UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //this._eventDoFlag = false;

                foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Sub_UTabControl.Tabs)
                {
                    this.Sub_UTabControl.Tabs.Remove(tab);
                }

                foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.SubExp_UTabControl.Tabs)
                {
                    this.SubExp_UTabControl.Tabs.Remove(tab);
                }

                foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.SubImp_UTabControl.Tabs)
                {
                    this.SubImp_UTabControl.Tabs.Remove(tab);
                }

            }
            finally
            {
                
            }
        }

        /// <summary>
        /// ポップメニュー「閉じる」イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 「閉じる」ボタン押下時に発生します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void Close_menuItem_Click(object sender, System.EventArgs e)
        {
            Infragistics.Win.UltraWinTabControl.UltraTabControl uTabControl = null;

            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                uTabControl = this.SubExp_UTabControl;
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                uTabControl = this.SubImp_UTabControl;
            }

            if (uTabControl.ActiveTab == null) return;

            string key = uTabControl.ActiveTab.Key;

            // タブ表示変更
            this.TabVisibleChange(key, false);

            // ウィンドウステートボタンツール構築処理
            this.CreateWindowStateButtonTools();


            if (uTabControl.Tabs.Count == 0)
            {
                this.ToolBarSetting(null);
            }
            else
            {
                this.ToolBarSetting(uTabControl.ActiveTab);
            }
        }


        /// <summary>
        /// メインタグ選択時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_UTabControl_Click(object sender, System.EventArgs e)
        {
            
        }
        #endregion // control event

        #region private method
        /// <summary>
        /// ツリーの構築処理
        /// </summary>
        /// <param name="tree">ツリー</param>
        /// <remarks>
        /// <br>Note       : ツリーの構築処理を行います。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void ConstructTreeNode(Infragistics.Win.UltraWinTree.UltraTree tree)
        {
            tree.Appearance.BackColor = Color.White;
            tree.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(222)), ((System.Byte)(239)), ((System.Byte)(255)));
            tree.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            tree.HideSelection = false;
            bool firstNode = true;

            Hashtable delNode2KeyLst = new Hashtable();
            Hashtable delNode3KeyLst = new Hashtable();

            // ノードの表示非表示を制御する
            if (_parameter.Length != 0)
            {
                // 選択ノードを先頭に移動させる
                firstNode = tree.PerformAction(
                    Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode,
                    false,
                    false);

                if (!firstNode)
                {
                    return;
                }

                //----------------------------------------------------------------------------//
                // 導入システムのチェック                                                     //
                //----------------------------------------------------------------------------//
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in tree.Nodes)
                {
                    if (utn1.Nodes.Count != 0)
                    {
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                        {
                            if (utn2.Nodes.Count != 0)
                            {
                                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
                                {
                                    utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;
                                    bool nodeVisible = false;
                                    string productCodes = "";
                                    if (utn3.Override.NodeAppearance.Tag != null)
                                    {
                                        productCodes = utn3.Override.NodeAppearance.Tag.ToString();
                                    }

                                    string[] split = productCodes.Split(new Char[] { ' ' });

                                    foreach (string productCode in split)
                                    {
                                        if ((productCode != null) && (productCode.Trim() != ""))
                                        {
                                            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(productCode) > 0)
                                            {
                                                nodeVisible = true;
                                                break;
                                            }
                                        }
                                    }
                                    if (!nodeVisible)
                                    {
                                        if (!delNode3KeyLst.ContainsKey(utn3.Key))
                                        {
                                            delNode3KeyLst.Add(utn3.Key, utn3);
                                        }
                                    }
                                }

                                if (utn2.Nodes.Count == 0)
                                {
                                    if (!delNode2KeyLst.ContainsKey(utn2.Key))
                                    {
                                        delNode2KeyLst.Add(utn2.Key, utn2);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //----------------------------------------------------------------------------//
            // グループの表示非表示を制御する                                             //
            //----------------------------------------------------------------------------//
            // 選択ノードを先頭に移動させる
            firstNode = tree.PerformAction(
                Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode,
                false,
                false);

            if (!firstNode)
            {
                return;
            }


            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in tree.Nodes)
            {
                if (utn1.Nodes.Count != 0)
                {
                    utn1.Expanded = true;

                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
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
                                    //----------------------------------------------------------------------------//
                                    // パラメータを100で割った余りにより、グループ起動か単体起動か判定            //
                                    // 端数なし：グループ                                                         //
                                    // 端数あり：単体(※複数存在する場合は親グループも表示)                       //
                                    //----------------------------------------------------------------------------//
                                    string strPara = PMKHN09810UA._parameter[i];
                                    int intPara = TStrConv.StrToIntDef(PMKHN09810UA._parameter[i], -1);

                                    if ((intPara % 100) != 0)
                                    {
                                        intPara = (intPara / 100) * 100;
                                        strPara = intPara.ToString();
                                    }
                                    if (utn2.Key.ToString() == strPara)
                                    {
                                        utn2DeleteFlg = false;
                                        break;
                                    }
                                }
                            }
                        }

                        if (utn2DeleteFlg == true)
                        {
                            if (!delNode2KeyLst.ContainsKey(utn2.Key))
                            {
                                delNode2KeyLst.Add(utn2.Key, utn2);
                            }
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

                                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
                                {
                                    utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;
                                    bool utn3DeleteFlg = true;

                                    // パラメータが空白の場合は全ノードを表示する（デリバリ時には非表示とする）
                                    if (_parameter.Length == 0)
                                    {
                                        utn3DeleteFlg = false;
                                    }

                                    // Key値がnullの場合は非表示とする
                                    if (utn3.Key != null)
                                    {
                                        for (int i = 0; i < _parameter.Length; i++)
                                        {

                                            //----------------------------------------------------------------------------//
                                            // パラメータを100で割った余りにより、グループ起動か単体起動か判定            //
                                            // 端数なし：グループ                                                         //
                                            // 端数あり：単体(※複数存在する場合は親グループも表示)                       //
                                            //----------------------------------------------------------------------------//
                                            string strPara = PMKHN09810UA._parameter[i];
                                            int intPara = TStrConv.StrToIntDef(PMKHN09810UA._parameter[i], -1);

                                            if ((intPara % 100) != 0)
                                            {
                                                if (utn3.Key.ToString() == strPara)
                                                {
                                                    utn3DeleteFlg = false;
                                                    utn3.Override.NodeAppearance.ForeColor = Color.Blue;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                utn3DeleteFlg = false;
                                                utn3.Override.NodeAppearance.ForeColor = Color.Blue;
                                                break;
                                            }
                                        }
                                    }

                                    if (utn3.Override.NodeAppearance.Tag != null)
                                    {
                                        string productCodes = utn3.Override.NodeAppearance.Tag.ToString();
                                        string[] split = productCodes.Split(new Char[] { ' ' });

                                        foreach (string productCode in split)
                                        {
                                            if (( productCode != null ) && ( productCode.Trim() != "" ))
                                            {
                                                // USBチェック
                                                if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(productCode) > 0)
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    utn3DeleteFlg = true;
                                                }
                                            }
                                        }
                                    }

                                    if (utn3DeleteFlg == true)
                                    {
                                        if (!delNode3KeyLst.ContainsKey(utn3.Key))
                                        {
                                            delNode3KeyLst.Add(utn3.Key, utn3);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // 第三階層を削除
            foreach (DictionaryEntry entry in delNode3KeyLst)
            {
                // 削除対象ノード
                Infragistics.Win.UltraWinTree.UltraTreeNode utn = (Infragistics.Win.UltraWinTree.UltraTreeNode)entry.Value;

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in tree.Nodes)
                {
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                    {
                        if (utn.Parent.Key == utn2.Key)
                        {
                            utn2.Nodes.Remove(utn);
                            break;
                        }
                    }
                }
            }

            // 第二階層を削除
            foreach (DictionaryEntry entry in delNode2KeyLst)
            {
                // 削除対象ノード
                Infragistics.Win.UltraWinTree.UltraTreeNode utn = (Infragistics.Win.UltraWinTree.UltraTreeNode)entry.Value;

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in tree.Nodes)
                {
                    utn1.Nodes.Remove(utn);
                }
            }

            tree.ExpandAll();
        }

        /// <summary>
        /// 設定ボタンを操作可能にするかどうか判断します。
        /// </summary>
        /// <param name="fileName"></param>
        private void SetUpButtonToolEnable(string fileName)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
            if (setupButton != null)
            {

                setupButton.SharedProps.Enabled = false;
                if (fileName.Contains("PMKHN07630U"))
                {
                    setupButton.SharedProps.Enabled = true;
                }
            }
        }

        # region ◆　画面コントロールクラス作成処理
        /// <summary>
        /// 画面コントロールクラス作成処理
        /// </summary>
        /// <param name="tree">ツリー</param>
        /// <param name="hashTable">テーブル</param>
        /// <returns> </returns>
        /// <remarks>
        /// <br>Note       : 各種条件画面のアセンブリ情報を作成します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private int CreateFormControlInfo2(Infragistics.Win.UltraWinTree.UltraTree tree, ref Hashtable hashTable)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            if (tree.Nodes.Count == 0) return status;

            hashTable.Clear();

            FormControlInfo info = null;

            // 選択ノードを先頭に移動させる
            bool result = tree.PerformAction(
                Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode,
                false,
                false);
            if (!result)
            {
                return status;
            }

            // ツリーのノード情報を元に、プログラム情報コレクションクラスを構築する

            // ツリーのノードより取得する情報は以下の通り
            // [DataKey:アセンブリ名称]
            // [Override.Tag:クラス厳密名]
            // [Text:プログラム名称]
            // [Tag:制御拠点コード]
            // [Tag:制御拠点コード]

            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in tree.Nodes)
            {
                if (utn1.Nodes.Count != 0)
                {
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                    {
                        if (utn2.Nodes.Count != 0)
                        {
                            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
                            {
                                utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;
                                if (utn3.DataKey != null && utn3.DataKey.ToString().Trim() != "")
                                {
                                    // アセンブリID,パラメータ
                                    string target = utn3.DataKey.ToString();
                                    string assemblyID;
                                    string param;

                                    this.SplitTargetAssemblyID(target, out assemblyID, out param);
                                    // 制御コード
                                    int ctrlFuncCode = 0;
                                    if (utn3.Tag != null)
                                    {
                                        ctrlFuncCode = TStrConv.StrToIntDef(utn3.Tag.ToString(), 0);
                                    }

                                    // 選択可能システム情報の取得
                                    string productCodes = "";
                                    if (utn3.Override.NodeAppearance.Tag != null)
                                    {
                                        productCodes = utn3.Override.NodeAppearance.Tag.ToString();
                                    }

                                    string[] split = productCodes.Split(new Char[] { ' ' });
                                    List<int> softWareCodeList = new List<int>(split.Length);

                                    foreach (string productCode in split)
                                    {
                                        if ((productCode != null) && (productCode.Trim() != ""))
                                        {
                                            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(productCode) > 0)
                                            {
                                                switch (productCode)
                                                {
                                                    case ConstantManagement_SF_PRO.SoftwareCode_PAC_SF:
                                                        softWareCodeList.Add(1);
                                                        break;
                                                    case ConstantManagement_SF_PRO.SoftwareCode_PAC_BK:
                                                        softWareCodeList.Add(2);
                                                        break;
                                                    case ConstantManagement_SF_PRO.SoftwareCode_PAC_CS:
                                                        softWareCodeList.Add(3);
                                                        break;
                                                }
                                            }
                                        }
                                    }

                                    // タブに表示するフォームクラスの情報を構築する
                                    info = new FormControlInfo(utn3.DataKey.ToString(),
                                        assemblyID,
                                        utn3.Override.Tag.ToString(),
                                        utn3.Text,
                                        utn3.Override.NodeAppearance.Image,
                                        ctrlFuncCode,
                                        param,
                                        softWareCodeList.ToArray());

                                    hashTable.Add(utn3.DataKey.ToString(), info);

                                    info = new FormControlInfo(utn3.DataKey.ToString() + "PREVIEW",
                                        assemblyID,
                                        utn3.Override.Tag.ToString(),
                                        utn3.Text + "プレビュー",
                                        utn3.Override.NodeAppearance.Image,
                                        ctrlFuncCode,
                                        param,
                                        softWareCodeList.ToArray());

                                    hashTable.Add(utn3.DataKey.ToString() + "PREVIEW", info);

                                    utn3.Key = utn3.DataKey.ToString();
                                }
                            }
                        }
                    }
                }
            }

            // プログラム情報は設定されているか
            status = (hashTable.Count == 0 ? (int)ConstantManagement.MethodResult.ctFNC_ERROR : (int)ConstantManagement.MethodResult.ctFNC_NORMAL);
            return status;
        }
        # endregion

        #region ◆　各処理条件ＵＩクラス起動処理
        /// <summary>
        /// 各UI画面起動処理
        /// </summary>
        /// <param name="key">対象キー情報</param>
        /// <remarks>
        /// <br>Note       : 引数のキー情報を元に、タブをアクティブ化します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void ShowChildExpInputForm(string key)
        {
            Cursor nowCursor = this.Cursor;
            System.Windows.Forms.Form childForm = null;


            try
            {
                // 起動子画面作成処理
                this.TabCreate2(key);

                // 起動子画面アクティブ化処理		
                this.TabActive2(key, ref childForm);

                // ツールバーセッティング
                this.ToolBarSetting(childForm);

                // メインフレームの個別画面設定
                this.ScreenPrivateSetting(key, childForm);
            }
            finally
            {
                this.Cursor = nowCursor;
            }
        }

        /// <summary>
        /// タブクリエイト処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : タブフォームを生成します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void TabCreate2(string key)
        {
            FormControlInfo info = null;
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                info = (FormControlInfo)this._expFormControlInfoTable[key];
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                info = (FormControlInfo)this._impFormControlInfoTable[key];
            }

            if (info == null) return;

            // 既にロード済み！
            if (info.Form != null) return;

            this.CreateTabForm2(info);
        }

        /// <summary>
        /// タブアクティブ処理
        /// </summary>
        /// <param name="key">対象キー情報</param>
        /// <param name="form">アクティブ化したフォームのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 引数のキー情報を元に、タブをアクティブ化します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void TabActive2(string key, ref Form form)
        {
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                if (this.SubExp_UTabControl.Tabs.Exists(key))
                {
                    this.SubExp_UTabControl.Tabs[key].Visible = true;
                    this.SubExp_UTabControl.SelectedTab = this.SubExp_UTabControl.Tabs[key];

                    form = this.SubExp_UTabControl.Tabs[key].Tag as System.Windows.Forms.Form;

                    // ウィンドウステイト状態変更
                    this.CreateWindowStateButtonTools();

                    // WindowStateボタンを選択状態にする
                    Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];

                    for (int i = 0; i < windowPopupMenuTool.Tools.Count; i++)
                    {
                        if (!(windowPopupMenuTool.Tools[i] is Infragistics.Win.UltraWinToolbars.StateButtonTool)) continue;

                        Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[i];

                        if ((this.SubExp_UTabControl.SelectedTab != null) && (key == stateButtonTool.Key))
                        {
                            stateButtonTool.Checked = true;
                        }
                        else
                        {
                            stateButtonTool.Checked = false;
                        }
                    }
                }
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                if (this.SubImp_UTabControl.Tabs.Exists(key))
                {
                    this.SubImp_UTabControl.Tabs[key].Visible = true;
                    this.SubImp_UTabControl.SelectedTab = this.SubImp_UTabControl.Tabs[key];

                    form = this.SubImp_UTabControl.Tabs[key].Tag as System.Windows.Forms.Form;

                    // ウィンドウステイト状態変更
                    this.CreateWindowStateButtonTools();

                    // WindowStateボタンを選択状態にする
                    Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];

                    for (int i = 0; i < windowPopupMenuTool.Tools.Count; i++)
                    {
                        if (!(windowPopupMenuTool.Tools[i] is Infragistics.Win.UltraWinToolbars.StateButtonTool)) continue;

                        Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[i];

                        if ((this.SubImp_UTabControl.SelectedTab != null) && (key == stateButtonTool.Key))
                        {
                            stateButtonTool.Checked = true;
                        }
                        else
                        {
                            stateButtonTool.Checked = false;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Tabフォーム生成処理
        /// </summary>
        /// <param>none</param>
        /// <returns>none</returns>
        /// <remarks>
        /// <br>Note       : MDI子画面を生成する</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private Form CreateTabForm2(FormControlInfo info)
        {
            Form form = null;

            form = (System.Windows.Forms.Form)this.LoadAssemblyFrom(info.AssemblyID, info.ClassID, typeof(System.Windows.Forms.Form));

            if (form == null)
            {
                form = new Form();
            }

            if (form != null)
            {
                info.Form = form;

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

                //----------------------------------------------------------------------------//
                // 各種デリゲートイベント登録                                                 //
                //----------------------------------------------------------------------------//
                if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
                {
                    // ツールバーボタン制御イベント 
                    if (form is ICSVExportConditionInpType)
                    {
                        ((ICSVExportConditionInpType)form).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
                    }

                    this.SubExp_UTabControl.Controls.Add(dataviewTabPageControl);
                    this.SubExp_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
                    this.SubExp_UTabControl.SelectedTab = dataviewTab;
                }
                else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
                {
                    // ツールバーボタン制御イベント 
                    if (form is ICSVImportConditionInpType)
                    {
                        ((ICSVImportConditionInpType)form).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
                    }

                    this.SubImp_UTabControl.Controls.Add(dataviewTabPageControl);
                    this.SubImp_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
                    this.SubImp_UTabControl.SelectedTab = dataviewTab;
                }

                // フォームプロパティ変更
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                dataviewTabPageControl.Controls.Add(form);

                if (form is ICSVExportConditionInpType)
                {
                    ((ICSVExportConditionInpType)form).Show(info.Param);
                }
                else if (form is ICSVImportConditionInpType)
                {
                    ((ICSVImportConditionInpType)form).Show(info.Param);
                }
                else
                {
                    form.Show();
                }
                form.Dock = System.Windows.Forms.DockStyle.Fill;
            }

            return form;
        }
        # endregion

        /// <summary>
        /// ﾃｷｽﾄﾌｧｲﾙ名チェック処理
        /// </summary>
        /// <param name="fileName">ファイル名前</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ﾃｷｽﾄﾌｧｲﾙ名チェック処理を行う。(入力チェックなど)</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private bool CheckInputFileName(string filePath, out string errMsg)
        {
            errMsg = string.Empty;
            bool bStatus = true;
            if (filePath == string.Empty)
            {
                errMsg = "テキストファイル名を入力してください。";
                bStatus = false;
            }
            else
            {
                // ファイル名を取得
                string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);

                if (fileName.IndexOf("/") >= 0  ||
                    fileName.IndexOf(":") >= 0  ||
                    fileName.IndexOf(";") >= 0  ||
                    fileName.IndexOf("*") >= 0  ||
                    fileName.IndexOf("?") >= 0  ||
                    fileName.IndexOf("\"") >= 0 ||
                    fileName.IndexOf("<") >= 0  ||
                    fileName.IndexOf(">") >= 0  ||
                    fileName.IndexOf("|") >= 0  ||
                    Path.GetFileNameWithoutExtension(fileName).IndexOf(".") >= 0)
                {
                    errMsg = "CSVファイルパスが不正です。";
                    bStatus = false;
                }
            }
            return bStatus;
        }

        /// <summary>
        /// ﾃｷｽﾄﾌｧｲﾙ名の存在チェック処理
        /// </summary>
        /// <param name="fileName">ファイル名前</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ﾃｷｽﾄﾌｧｲﾙ名の存在チェック処理を行う。(入力チェックなど)</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private bool CheckInputFileExists(string fileName, out string errMsg)
        {
            errMsg = string.Empty;
            bool bStatus = true;

            try
            {
                if (!File.Exists(fileName))
                {
                    errMsg = "テキストファイルが存在しません。";
                    bStatus = false;
                }
            }
            catch
            {
                errMsg = "テキストファイルが存在しません。";
                bStatus = false;
            }
            return bStatus;
        }

        /// <summary>
        /// ﾃｷｽﾄﾌｧｲﾙ名のレコード存在チェック処理
        /// </summary>
        /// <param name="fileName">ファイル名前</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="dataList">データリスト</param>
        /// <param name="isReadErr">読込エラーかどうか</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ﾃｷｽﾄﾌｧｲﾙ名のレコード存在チェック処理を行う。(入力チェックなど)</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private bool CheckInputFileDataExists(string fileName, out string errMsg, out List<string[]> dataList, out bool isReadErr)
        {
            errMsg = string.Empty;
            isReadErr = false;
            bool bStatus = true;
            dataList = GetCsvData(fileName, out errMsg);
            // 読込時にエラーが発生した場合
            if (!string.IsNullOrEmpty(errMsg))
            {
                isReadErr = true;
                bStatus = false;
            }
            else
            {
                // レコードがない場合
                if (dataList.Count == 0)
                {
                    errMsg = "該当するデータがありません。";
                    bStatus = false;
                }
            }
            return bStatus;
        }

        /// <summary>
        /// CSV情報取得処理
        /// </summary>
        /// <param name="fileName">ファイル名前</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>CSV情報</returns>
        /// <remarks>
        /// <br>Note       : CSV情報を取得処理する。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private List<String[]> GetCsvData(String fileName, out string errMsg)
        {
            errMsg = string.Empty;
            List<string[]> csvDataList = new List<string[]>();
            TextFieldParser parser = new TextFieldParser(fileName, System.Text.Encoding.GetEncoding("Shift_JIS"));
            try
            {
                using (parser)
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(","); // 区切り文字はコンマ
                    while (!parser.EndOfData)
                    {
                        string[] row = parser.ReadFields(); // 1行読み込み
                        csvDataList.Add(row);
                    }
                }
            }
            catch
            {
                errMsg = "取込対象外のファイルです。";
            }

            return csvDataList;

        }

        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
        /// <summary>
        /// CSV拡張子チェック
        /// </summary>
        /// <param name="filepass">ファイルパス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>チェック結果(true:問題無し、false:問題あり)</returns>
        /// <remarks>
        /// <br>Note       : CSVの拡張子をチェックします</br>
        /// <br>Programmer : 30521 T.MOTOYAMA</br>
        /// <br>Date       : 2013.10.28</br>
        /// </remarks>
        private bool CheckCSVextension(string filepass, out string errMsg)
        {
            errMsg = "";

            // ファイルの拡張子チェック
            string stExtension = System.IO.Path.GetExtension(filepass);

            if (stExtension == ".CSV" ||
                stExtension == ".csv")
            {
                return true;
            }
            else
            {
                errMsg = "拡張子が不正です。";
                return false;
            }        
        }
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// CSV出力処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV出力処理を行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private int DoOutPut(ref object parameter)
        {
            int status = 0;
            int totalCount;

            try
            {
                ArrayList paramList = parameter as ArrayList;

                // 出力スキーマリスト
                List<string> schemeList = paramList[0] as List<string>;
                // クロスタイプリスト
                List<Type> enclosingTypeList = new List<Type>();
                enclosingTypeList.Add("".GetType());

                // 出力項目最大長さ
                Dictionary<string, int> maxLengthList = paramList[1] as Dictionary<string, int>;

                _formattedTextWriter.DataSource = this.BindDataSet.Tables[this._tableName].DefaultView;
                _formattedTextWriter.DataMember = String.Empty;
                _formattedTextWriter.OutputFileName = paramList[2] as string;
                // テキスト出力する項目名のリスト
                _formattedTextWriter.SchemeList = schemeList;
                _formattedTextWriter.Splitter = ",";
                _formattedTextWriter.Encloser = "\"";
                _formattedTextWriter.EnclosingTypeList = enclosingTypeList;
                _formattedTextWriter.FormatList = null;
                _formattedTextWriter.CaptionOutput = true;
                _formattedTextWriter.FixedLength = false;
                _formattedTextWriter.ReplaceList = null;
                _formattedTextWriter.MaxLengthList = null;

                status = this._formattedTextWriter.TextOut(out totalCount);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        # endregion private method

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        # region control event
        /// <summary>
        /// Control.MouseDown イベント(StartNavigatorEXPTree)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ツリーコントロールにてマウスボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void StartNavigatorEXPTree_MouseDown(object sender, MouseEventArgs e)
        {
            this._lastMouseDown = new Point(e.X, e.Y);
        }

        /// <summary>
        /// Control.MouseDown イベント(StartNavigatorINPTree)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ツリーコントロールにてマウスボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void StartNavigatorINPTree_MouseDown(object sender, MouseEventArgs e)
        {
            this._lastMouseDown = new Point(e.X, e.Y);
        }

        /// <summary>
        /// ツリーノードダブルクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 起動ナビゲーターのダブルクリックイベントです。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void StartNavigatorEXPTree_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinTree.UltraTreeNode doubleClickedNode =
                    this.StartNavigatorEXPTree.GetNodeFromPoint(this._lastMouseDown);

            if (doubleClickedNode == null) return;

            FormControlInfo info = this._expFormControlInfoTable[doubleClickedNode.Key.ToString()] as FormControlInfo;
            if (info == null) return;

            if (doubleClickedNode.Level == 2)
            {
                if (!MyOpeCtrlMap.ContainsKey(info.AssemblyID))
                {
                    if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                        EntityUtil.CategoryCode.Report,
                        MyOpeCtrlMap.AddController(info.AssemblyID),
                        info.AssemblyID,
                        info.Name
                    ))
                    {
                        return; // 起動不可のため強制終了
                    }
                }

                Infragistics.Win.UltraWinTree.UltraTreeNode node = doubleClickedNode;

                // 条件入力画面UI起動処理
                ShowChildExpInputForm(node.Key.ToString());

                doubleClickedNode.Override.NodeAppearance.ForeColor = Color.Red;

                BeginControllingByOperationAuthority(info.AssemblyID);
            }
        }


        /// <summary>
        /// ツリーノードダブルクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 起動ナビゲーターのダブルクリックイベントです。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void StartNavigatorINPTree_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinTree.UltraTreeNode doubleClickedNode =
                    this.StartNavigatorINPTree.GetNodeFromPoint(this._lastMouseDown);

            if (doubleClickedNode == null) return;

            FormControlInfo info = this._impFormControlInfoTable[doubleClickedNode.Key.ToString()] as FormControlInfo;
            if (info == null) return;

            if (doubleClickedNode.Level == 2)
            {
                if (!MyOpeCtrlMap.ContainsKey(info.AssemblyID))
                {
                    if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                        EntityUtil.CategoryCode.Report,
                        MyOpeCtrlMap.AddController(info.AssemblyID),
                        info.AssemblyID,
                        info.Name
                    ))
                    {
                        return; // 起動不可のため強制終了
                    }
                }

                Infragistics.Win.UltraWinTree.UltraTreeNode node = doubleClickedNode;

                // 条件入力画面UI起動処理
                ShowChildExpInputForm(node.Key.ToString());

                SetUpButtonToolEnable(node.Key.ToString());

                doubleClickedNode.Override.NodeAppearance.ForeColor = Color.Red;

                BeginControllingByOperationAuthority(info.AssemblyID);
            }
        }

        /// <summary>
        /// タブ選択後処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : タブ選択後に発生するイベントです。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void SubExp_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (e.Tab == null) return;

            if (!this._expFormControlInfoTable.Contains(e.Tab.Key))
            {
                return;
            }

            string key = e.Tab.Key;
            FormControlInfo info = this._expFormControlInfoTable[key] as FormControlInfo;
            Form target = info.Form;

            // タブアクティブ処理
            this.TabActive2(key, ref target);

            // ツールバーの表示・有効設定
            this.ToolBarSetting(target);
        }

        /// <summary>
        /// タブ選択後処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : タブ選択後に発生するイベントです。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void SubImp_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (e.Tab == null) return;

            if (!this._impFormControlInfoTable.Contains(e.Tab.Key))
            {
                return;
            }

            string key = e.Tab.Key;
            FormControlInfo info = this._impFormControlInfoTable[key] as FormControlInfo;
            Form target = info.Form;

            // タブアクティブ処理
            this.TabActive2(key, ref target);

            // ツールバーの表示・有効設定
            this.ToolBarSetting(target);

            SetUpButtonToolEnable(target.ToString());
        }

        /// <summary>
        /// タブ選択後処理(Main_UTabControl)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : タブ選択後に発生するイベントです。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void Main_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            Infragistics.Win.UltraWinTabControl.UltraTabControl uTabControl = null;
            System.Windows.Forms.Form frm = null;

            // 掛率マスタエクスポート
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                uTabControl = this.SubExp_UTabControl;

                if (uTabControl.ActiveTab != null)
                {
                    FormControlInfo formInfo = (FormControlInfo)this._expFormControlInfoTable[uTabControl.SelectedTab.Key];
                    ToolBarSetting(formInfo.Form);
                    SetUpButtonToolEnable(uTabControl.ActiveTab.Key.ToString());
                }
                else
                {
                    ToolBarSetting(frm);
                }
            }
            // 掛率マスタインポート
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                uTabControl = this.SubImp_UTabControl;

                if (uTabControl.ActiveTab != null)
                {
                    FormControlInfo formInfo = (FormControlInfo)this._impFormControlInfoTable[uTabControl.SelectedTab.Key];
                    ToolBarSetting(formInfo.Form);
                    SetUpButtonToolEnable(uTabControl.ActiveTab.Key.ToString());
                }
                else
                {
                    ToolBarSetting(frm);
                }
            }

            // ウィンドウステイト状態変更
            this.CreateWindowStateButtonTools();
        }
        # endregion control event
    }
}
