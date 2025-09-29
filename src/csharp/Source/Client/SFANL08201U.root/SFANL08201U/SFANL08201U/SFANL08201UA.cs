using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller;  // for debug
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;

using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 自由帳票印刷フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由帳票印刷フォームクラスです。</br>
    /// <br>Programmer : 22011 Kashihara</br>
    /// <br>Date       : 2006.01.19</br>
    /// <br>Update Note: 2008.03.18</br>
    /// <br>           : 22011 柏原 頼人 日次帳票の時日付を最低一つは入力しないと抽出しないよう修正</br>
    /// <br>           : 現状日付の入力ﾁｪｯｸは無条件で行うが、行ってはまずいｸﾞﾙｰﾌﾟが出てきたら個別ではじく</br>
    /// <br>           : ロジックの追加が必要。(岩本SL確認済み)</br>
    /// </remarks>
    public class SFANL08201UA : GridFormBase, IFreeSheetMainFrame
    {
        # region Private Members (Component)
        private System.Windows.Forms.Panel Centering_Panel;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.Panel SFANL08201U_Fill_Panel;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private UltraLabel GridTitleSub_ultraLabel;
        private UltraButton Print_Button;
        private UltraLabel ultraLabel1;
        private Panel Panel_Fill_Panel;
        private Panel GroupPanel;
        private Panel ExtractPanel;
        private Panel PrintBtnPanel;
        private Panel DetailPanel;
        private UltraButton OrderCng_Button;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar SelectExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl2;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet AddUpCd_UOptionSet;
        private AutoHideControl _SFANL08201UAAutoHideControl;
        private UltraDockManager Main_DockManager;
        private UnpinnedTabArea _SFANL08201UAUnpinnedTabAreaTop;
        private UnpinnedTabArea _SFANL08201UAUnpinnedTabAreaBottom;
        private UnpinnedTabArea _SFANL08201UAUnpinnedTabAreaLeft;
        private UnpinnedTabArea _SFANL08201UAUnpinnedTabAreaRight;
        private WindowDockingArea windowDockingArea1;
        private DockableWindow dockableWindow1;
        private Infragistics.Win.UltraWinTree.UltraTree Section_UTree;
        private Panel GroupPanel_Fill_Panel;
        private UltraToolbarsDockArea _GroupPanel_Toolbars_Dock_Area_Left;
        private UltraToolbarsManager GroupToolbarsManager;
        private UltraToolbarsDockArea _GroupPanel_Toolbars_Dock_Area_Right;
        private UltraToolbarsDockArea _GroupPanel_Toolbars_Dock_Area_Top;
        private UltraToolbarsDockArea _GroupPanel_Toolbars_Dock_Area_Bottom;
        private Panel DetailPanel_Fill_Panel;
        private UltraToolbarsDockArea _DetailPanel_Toolbars_Dock_Area_Left;
        private UltraToolbarsManager DetailToolbarsManager;
        private UltraToolbarsDockArea _DetailPanel_Toolbars_Dock_Area_Right;
        private UltraToolbarsDockArea _DetailPanel_Toolbars_Dock_Area_Top;
        private UltraToolbarsDockArea _DetailPanel_Toolbars_Dock_Area_Bottom;
        private UltraGrid FreePprGr_Grid;
        private UltraGrid FreePprPrt_Grid;
        private Panel Splitter2_panel;
        private Panel Splitter1_panel;
        private Panel Sqlitter1_panel1;
        private Splitter splitter1;
        private Panel Splitter2_panel2;
        private Splitter splitter2;
        private System.ComponentModel.IContainer components;
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SFANL08201UA()
        {
            InitializeComponent();
            //企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //ログイン拠点取得
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            //保存Dlg押下時のデリゲート設定
            _maintenanceDlg.SaveNewGroup += RegistFreePprGr;           //データセットへの追加処理(グループ)
            _maintenanceDlg.SaveNewFrePpr += RegistFreeShetGrTr;       //データセットへの追加処理(振替)
            _maintenanceDlg.Owner = this;                             //オーナーを設定

            // 最終印刷日次を確保
            int status = _lastPrtTimeAcs.SearchAll( out _lastTimes );
            if ( status != 0 )
            {
                _lastTimes = new List<LastPrtTime>();
            }
            //初期データセット設定
            CreateInitialDataSet();
            //拠点情報をキャッシュ
            GetSecInfoSetCash();


            /*  拠点スライダーを構築
             *  今は日次帳票しかないのでタイミングはこれで良いが印字項目グループが増えたら
             *  自由帳票グループごとの管理が必要になってくる。そのタイミングで改良。
             */
            InitSettingSectionTree( 1 );
            InitialSettingSectionKind( 1 );

        }
        #endregion

        // ===================================================================================== //
        // 破棄
        // ===================================================================================== //
        #region Dispose
        /// <summary>
        /// 破棄
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                _lastPrtTimeAcs.Write( _lastTimes );

                if ( components != null )
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowADD");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowDelete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowADD");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowDelete");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowADD");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowDelete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowADD");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowDelete");
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("cc6aa7d9-0768-4432-a5c4-d7db122dc0b2"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("c6d77efb-ad85-43d9-bca9-cb2c80cf2b8b"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("cc6aa7d9-0768-4432-a5c4-d7db122dc0b2"), -1);
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.AddUpCd_UOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraExplorerBarContainerControl2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.Section_UTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.SelectExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.SFANL08201U_Fill_Panel = new System.Windows.Forms.Panel();
            this.Centering_Panel = new System.Windows.Forms.Panel();
            this.Splitter1_panel = new System.Windows.Forms.Panel();
            this.Sqlitter1_panel1 = new System.Windows.Forms.Panel();
            this.DetailPanel = new System.Windows.Forms.Panel();
            this.DetailPanel_Fill_Panel = new System.Windows.Forms.Panel();
            this.FreePprPrt_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._DetailPanel_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.DetailToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._DetailPanel_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._DetailPanel_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._DetailPanel_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.GridTitleSub_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.Splitter2_panel = new System.Windows.Forms.Panel();
            this.Splitter2_panel2 = new System.Windows.Forms.Panel();
            this.ExtractPanel = new System.Windows.Forms.Panel();
            this.PrintBtnPanel = new System.Windows.Forms.Panel();
            this.OrderCng_Button = new Infragistics.Win.Misc.UltraButton();
            this.Print_Button = new Infragistics.Win.Misc.UltraButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.Panel_Fill_Panel = new System.Windows.Forms.Panel();
            this.GroupPanel = new System.Windows.Forms.Panel();
            this.GroupPanel_Fill_Panel = new System.Windows.Forms.Panel();
            this.FreePprGr_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._GroupPanel_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.GroupToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._GroupPanel_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._GroupPanel_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._GroupPanel_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._SFANL08201UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL08201UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL08201UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL08201UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL08201UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpCd_UOptionSet)).BeginInit();
            this.ultraExplorerBarContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Section_UTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectExplorerBar)).BeginInit();
            this.SelectExplorerBar.SuspendLayout();
            this.SFANL08201U_Fill_Panel.SuspendLayout();
            this.Centering_Panel.SuspendLayout();
            this.Splitter1_panel.SuspendLayout();
            this.Sqlitter1_panel1.SuspendLayout();
            this.DetailPanel.SuspendLayout();
            this.DetailPanel_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FreePprPrt_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailToolbarsManager)).BeginInit();
            this.Splitter2_panel.SuspendLayout();
            this.Splitter2_panel2.SuspendLayout();
            this.PrintBtnPanel.SuspendLayout();
            this.Panel_Fill_Panel.SuspendLayout();
            this.GroupPanel.SuspendLayout();
            this.GroupPanel_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FreePprGr_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupToolbarsManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).BeginInit();
            this._SFANL08201UAAutoHideControl.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.AddUpCd_UOptionSet);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(28, 49);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(177, 44);
            this.ultraExplorerBarContainerControl1.TabIndex = 0;
            // 
            // AddUpCd_UOptionSet
            // 
            this.AddUpCd_UOptionSet.BackColor = System.Drawing.Color.Transparent;
            this.AddUpCd_UOptionSet.BackColorInternal = System.Drawing.Color.Transparent;
            this.AddUpCd_UOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.AddUpCd_UOptionSet.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.AddUpCd_UOptionSet.Location = new System.Drawing.Point(2, 4);
            this.AddUpCd_UOptionSet.Name = "AddUpCd_UOptionSet";
            this.AddUpCd_UOptionSet.Size = new System.Drawing.Size(224, 35);
            this.AddUpCd_UOptionSet.TabIndex = 0;
            this.AddUpCd_UOptionSet.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.AddUpCd_UOptionSet.ValueChanged += new System.EventHandler(this.AddUpCd_UOptionSet_ValueChanged);
            // 
            // ultraExplorerBarContainerControl2
            // 
            this.ultraExplorerBarContainerControl2.Controls.Add(this.Section_UTree);
            this.ultraExplorerBarContainerControl2.Location = new System.Drawing.Point(28, 146);
            this.ultraExplorerBarContainerControl2.Name = "ultraExplorerBarContainerControl2";
            this.ultraExplorerBarContainerControl2.Size = new System.Drawing.Size(177, 343);
            this.ultraExplorerBarContainerControl2.TabIndex = 1;
            // 
            // Section_UTree
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.Section_UTree.Appearance = appearance2;
            this.Section_UTree.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Section_UTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Section_UTree.Location = new System.Drawing.Point(0, 0);
            this.Section_UTree.Name = "Section_UTree";
            this.Section_UTree.ShowLines = false;
            this.Section_UTree.Size = new System.Drawing.Size(177, 343);
            this.Section_UTree.TabIndex = 0;
            this.Section_UTree.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.Section_UTree_AfterCheck);
            // 
            // SelectExplorerBar
            // 
            this.SelectExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl2);
            this.SelectExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.SelectExplorerBar.Dock = System.Windows.Forms.DockStyle.Fill;
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup1.Key = "AddUpCdList";
            ultraExplorerBarGroup1.Settings.ContainerHeight = 44;
            ultraExplorerBarGroup1.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup1.Text = "計上拠点を選択します";
            ultraExplorerBarGroup1.Visible = false;
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl2;
            ultraExplorerBarGroup2.Key = "SectionList";
            ultraExplorerBarGroup2.Settings.ContainerHeight = 343;
            ultraExplorerBarGroup2.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup2.Text = "出力対象拠点を選択します";
            ultraExplorerBarGroup2.Visible = false;
            this.SelectExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2});
            this.SelectExplorerBar.GroupSpacing = 5;
            this.SelectExplorerBar.Location = new System.Drawing.Point(0, 29);
            this.SelectExplorerBar.Name = "SelectExplorerBar";
            this.SelectExplorerBar.ShowDefaultContextMenu = false;
            this.SelectExplorerBar.Size = new System.Drawing.Size(226, 741);
            this.SelectExplorerBar.TabIndex = 6;
            this.SelectExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.XPExplorerBar;
            // 
            // SFANL08201U_Fill_Panel
            // 
            this.SFANL08201U_Fill_Panel.Controls.Add(this.Centering_Panel);
            this.SFANL08201U_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SFANL08201U_Fill_Panel.Location = new System.Drawing.Point(22, 0);
            this.SFANL08201U_Fill_Panel.Name = "SFANL08201U_Fill_Panel";
            this.SFANL08201U_Fill_Panel.Size = new System.Drawing.Size(902, 770);
            this.SFANL08201U_Fill_Panel.TabIndex = 0;
            // 
            // Centering_Panel
            // 
            this.Centering_Panel.Controls.Add(this.Splitter1_panel);
            this.Centering_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Centering_Panel.Location = new System.Drawing.Point(0, 0);
            this.Centering_Panel.Name = "Centering_Panel";
            this.Centering_Panel.Size = new System.Drawing.Size(902, 770);
            this.Centering_Panel.TabIndex = 0;
            // 
            // Splitter1_panel
            // 
            this.Splitter1_panel.Controls.Add(this.Sqlitter1_panel1);
            this.Splitter1_panel.Controls.Add(this.splitter1);
            this.Splitter1_panel.Controls.Add(this.Splitter2_panel);
            this.Splitter1_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Splitter1_panel.Location = new System.Drawing.Point(0, 0);
            this.Splitter1_panel.Name = "Splitter1_panel";
            this.Splitter1_panel.Size = new System.Drawing.Size(902, 770);
            this.Splitter1_panel.TabIndex = 7;
            // 
            // Sqlitter1_panel1
            // 
            this.Sqlitter1_panel1.Controls.Add(this.DetailPanel);
            this.Sqlitter1_panel1.Controls.Add(this.GridTitleSub_ultraLabel);
            this.Sqlitter1_panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sqlitter1_panel1.Location = new System.Drawing.Point(292, 0);
            this.Sqlitter1_panel1.Name = "Sqlitter1_panel1";
            this.Sqlitter1_panel1.Size = new System.Drawing.Size(610, 770);
            this.Sqlitter1_panel1.TabIndex = 8;
            // 
            // DetailPanel
            // 
            this.DetailPanel.Controls.Add(this.DetailPanel_Fill_Panel);
            this.DetailPanel.Controls.Add(this._DetailPanel_Toolbars_Dock_Area_Left);
            this.DetailPanel.Controls.Add(this._DetailPanel_Toolbars_Dock_Area_Right);
            this.DetailPanel.Controls.Add(this._DetailPanel_Toolbars_Dock_Area_Top);
            this.DetailPanel.Controls.Add(this._DetailPanel_Toolbars_Dock_Area_Bottom);
            this.DetailPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailPanel.Location = new System.Drawing.Point(0, 26);
            this.DetailPanel.Name = "DetailPanel";
            this.DetailPanel.Size = new System.Drawing.Size(610, 744);
            this.DetailPanel.TabIndex = 0;
            // 
            // DetailPanel_Fill_Panel
            // 
            this.DetailPanel_Fill_Panel.Controls.Add(this.FreePprPrt_Grid);
            this.DetailPanel_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.DetailPanel_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailPanel_Fill_Panel.Location = new System.Drawing.Point(0, 26);
            this.DetailPanel_Fill_Panel.Name = "DetailPanel_Fill_Panel";
            this.DetailPanel_Fill_Panel.Size = new System.Drawing.Size(610, 718);
            this.DetailPanel_Fill_Panel.TabIndex = 0;
            // 
            // FreePprPrt_Grid
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.FreePprPrt_Grid.DisplayLayout.Appearance = appearance3;
            this.FreePprPrt_Grid.DisplayLayout.InterBandSpacing = 10;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.FreePprPrt_Grid.DisplayLayout.Override.ActiveCellAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.FreePprPrt_Grid.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.FreePprPrt_Grid.DisplayLayout.Override.CellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Left";
            appearance7.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.FreePprPrt_Grid.DisplayLayout.Override.HeaderAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.Lavender;
            this.FreePprPrt_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance8;
            appearance9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FreePprPrt_Grid.DisplayLayout.Override.RowAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.ForeColor = System.Drawing.Color.White;
            this.FreePprPrt_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance10;
            this.FreePprPrt_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.FreePprPrt_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.FreePprPrt_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.FreePprPrt_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.FreePprPrt_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.FreePprPrt_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.FreePprPrt_Grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.FreePprPrt_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FreePprPrt_Grid.Location = new System.Drawing.Point(0, 0);
            this.FreePprPrt_Grid.Name = "FreePprPrt_Grid";
            this.FreePprPrt_Grid.Size = new System.Drawing.Size(610, 718);
            this.FreePprPrt_Grid.TabIndex = 0;
            this.FreePprPrt_Grid.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.FreePprPrt_Grid_InitializeRow);
            this.FreePprPrt_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FreePprPrt_Grid_KeyDown);
            this.FreePprPrt_Grid.AfterRowActivate += new System.EventHandler(this.FreePprPrt_Grid_AfterRowActivate);
            this.FreePprPrt_Grid.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.FreePprPrt_Grid_BeforeRowDeactivate);
            this.FreePprPrt_Grid.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.FreePprPrt_Grid_DoubleClickRow);
            // 
            // _DetailPanel_Toolbars_Dock_Area_Left
            // 
            this._DetailPanel_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._DetailPanel_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._DetailPanel_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._DetailPanel_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._DetailPanel_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 26);
            this._DetailPanel_Toolbars_Dock_Area_Left.Name = "_DetailPanel_Toolbars_Dock_Area_Left";
            this._DetailPanel_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 718);
            this._DetailPanel_Toolbars_Dock_Area_Left.ToolbarsManager = this.DetailToolbarsManager;
            // 
            // DetailToolbarsManager
            // 
            this.DetailToolbarsManager.DesignerFlags = 1;
            this.DetailToolbarsManager.DockWithinContainer = this.DetailPanel;
            this.DetailToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2});
            ultraToolbar1.Text = "UltraToolbar1";
            this.DetailToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool3.SharedProps.Caption = "新規追加";
            buttonTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool4.SharedProps.Caption = "行削除";
            buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.DetailToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4});
            this.DetailToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.DetailToolbarsManager_ToolClick);
            // 
            // _DetailPanel_Toolbars_Dock_Area_Right
            // 
            this._DetailPanel_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._DetailPanel_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._DetailPanel_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._DetailPanel_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._DetailPanel_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(610, 26);
            this._DetailPanel_Toolbars_Dock_Area_Right.Name = "_DetailPanel_Toolbars_Dock_Area_Right";
            this._DetailPanel_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 718);
            this._DetailPanel_Toolbars_Dock_Area_Right.ToolbarsManager = this.DetailToolbarsManager;
            // 
            // _DetailPanel_Toolbars_Dock_Area_Top
            // 
            this._DetailPanel_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._DetailPanel_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._DetailPanel_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._DetailPanel_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._DetailPanel_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._DetailPanel_Toolbars_Dock_Area_Top.Name = "_DetailPanel_Toolbars_Dock_Area_Top";
            this._DetailPanel_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(610, 26);
            this._DetailPanel_Toolbars_Dock_Area_Top.ToolbarsManager = this.DetailToolbarsManager;
            // 
            // _DetailPanel_Toolbars_Dock_Area_Bottom
            // 
            this._DetailPanel_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._DetailPanel_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._DetailPanel_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._DetailPanel_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._DetailPanel_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 744);
            this._DetailPanel_Toolbars_Dock_Area_Bottom.Name = "_DetailPanel_Toolbars_Dock_Area_Bottom";
            this._DetailPanel_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(610, 0);
            this._DetailPanel_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.DetailToolbarsManager;
            // 
            // GridTitleSub_ultraLabel
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance11.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.GridTitleSub_ultraLabel.Appearance = appearance11;
            this.GridTitleSub_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.GridTitleSub_ultraLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.GridTitleSub_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.5F, System.Drawing.FontStyle.Bold);
            this.GridTitleSub_ultraLabel.Location = new System.Drawing.Point(0, 0);
            this.GridTitleSub_ultraLabel.Name = "GridTitleSub_ultraLabel";
            this.GridTitleSub_ultraLabel.Size = new System.Drawing.Size(610, 26);
            this.GridTitleSub_ultraLabel.TabIndex = 6;
            this.GridTitleSub_ultraLabel.Text = "印刷対象";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(289, 0);
            this.splitter1.MinExtra = 3;
            this.splitter1.MinSize = 3;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 770);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // Splitter2_panel
            // 
            this.Splitter2_panel.Controls.Add(this.Splitter2_panel2);
            this.Splitter2_panel.Controls.Add(this.splitter2);
            this.Splitter2_panel.Controls.Add(this.Panel_Fill_Panel);
            this.Splitter2_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Splitter2_panel.Location = new System.Drawing.Point(0, 0);
            this.Splitter2_panel.Name = "Splitter2_panel";
            this.Splitter2_panel.Size = new System.Drawing.Size(289, 770);
            this.Splitter2_panel.TabIndex = 8;
            // 
            // Splitter2_panel2
            // 
            this.Splitter2_panel2.Controls.Add(this.ExtractPanel);
            this.Splitter2_panel2.Controls.Add(this.PrintBtnPanel);
            this.Splitter2_panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Splitter2_panel2.Location = new System.Drawing.Point(0, 237);
            this.Splitter2_panel2.Name = "Splitter2_panel2";
            this.Splitter2_panel2.Size = new System.Drawing.Size(289, 533);
            this.Splitter2_panel2.TabIndex = 8;
            // 
            // ExtractPanel
            // 
            this.ExtractPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExtractPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtractPanel.Location = new System.Drawing.Point(0, 35);
            this.ExtractPanel.Name = "ExtractPanel";
            this.ExtractPanel.Size = new System.Drawing.Size(289, 498);
            this.ExtractPanel.TabIndex = 0;
            // 
            // PrintBtnPanel
            // 
            this.PrintBtnPanel.Controls.Add(this.OrderCng_Button);
            this.PrintBtnPanel.Controls.Add(this.Print_Button);
            this.PrintBtnPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PrintBtnPanel.Location = new System.Drawing.Point(0, 0);
            this.PrintBtnPanel.Name = "PrintBtnPanel";
            this.PrintBtnPanel.Size = new System.Drawing.Size(289, 35);
            this.PrintBtnPanel.TabIndex = 6;
            // 
            // OrderCng_Button
            // 
            this.OrderCng_Button.Location = new System.Drawing.Point(113, 3);
            this.OrderCng_Button.Name = "OrderCng_Button";
            this.OrderCng_Button.Size = new System.Drawing.Size(134, 29);
            this.OrderCng_Button.TabIndex = 1;
            this.OrderCng_Button.Text = "ソート順変更(&O)";
            this.OrderCng_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.OrderCng_Button.Click += new System.EventHandler(this.OrderCng_Button_Click);
            // 
            // Print_Button
            // 
            this.Print_Button.Location = new System.Drawing.Point(3, 3);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.Size = new System.Drawing.Size(104, 29);
            this.Print_Button.TabIndex = 0;
            this.Print_Button.Text = "印刷(&P)";
            this.Print_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 234);
            this.splitter2.MinExtra = 3;
            this.splitter2.MinSize = 3;
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(289, 3);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // Panel_Fill_Panel
            // 
            this.Panel_Fill_Panel.Controls.Add(this.GroupPanel);
            this.Panel_Fill_Panel.Controls.Add(this.ultraLabel1);
            this.Panel_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Panel_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel_Fill_Panel.Name = "Panel_Fill_Panel";
            this.Panel_Fill_Panel.Size = new System.Drawing.Size(289, 234);
            this.Panel_Fill_Panel.TabIndex = 0;
            // 
            // GroupPanel
            // 
            this.GroupPanel.Controls.Add(this.GroupPanel_Fill_Panel);
            this.GroupPanel.Controls.Add(this._GroupPanel_Toolbars_Dock_Area_Left);
            this.GroupPanel.Controls.Add(this._GroupPanel_Toolbars_Dock_Area_Right);
            this.GroupPanel.Controls.Add(this._GroupPanel_Toolbars_Dock_Area_Top);
            this.GroupPanel.Controls.Add(this._GroupPanel_Toolbars_Dock_Area_Bottom);
            this.GroupPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupPanel.Location = new System.Drawing.Point(0, 26);
            this.GroupPanel.Name = "GroupPanel";
            this.GroupPanel.Size = new System.Drawing.Size(289, 208);
            this.GroupPanel.TabIndex = 0;
            // 
            // GroupPanel_Fill_Panel
            // 
            this.GroupPanel_Fill_Panel.Controls.Add(this.FreePprGr_Grid);
            this.GroupPanel_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.GroupPanel_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupPanel_Fill_Panel.Location = new System.Drawing.Point(0, 26);
            this.GroupPanel_Fill_Panel.Name = "GroupPanel_Fill_Panel";
            this.GroupPanel_Fill_Panel.Size = new System.Drawing.Size(289, 182);
            this.GroupPanel_Fill_Panel.TabIndex = 0;
            // 
            // FreePprGr_Grid
            // 
            appearance12.BackColor = System.Drawing.Color.White;
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.FreePprGr_Grid.DisplayLayout.Appearance = appearance12;
            this.FreePprGr_Grid.DisplayLayout.InterBandSpacing = 10;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance13.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.ForeColor = System.Drawing.Color.Black;
            this.FreePprGr_Grid.DisplayLayout.Override.ActiveCellAppearance = appearance13;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.FreePprGr_Grid.DisplayLayout.Override.CellAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.ForeColor = System.Drawing.Color.White;
            appearance15.TextHAlignAsString = "Left";
            appearance15.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.FreePprGr_Grid.DisplayLayout.Override.HeaderAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.Lavender;
            this.FreePprGr_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance16;
            appearance17.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FreePprGr_Grid.DisplayLayout.Override.RowAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance18.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance18.ForeColor = System.Drawing.Color.White;
            this.FreePprGr_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance18;
            this.FreePprGr_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.FreePprGr_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.FreePprGr_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.FreePprGr_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.FreePprGr_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.FreePprGr_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.FreePprGr_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.FreePprGr_Grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.FreePprGr_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FreePprGr_Grid.Location = new System.Drawing.Point(0, 0);
            this.FreePprGr_Grid.Name = "FreePprGr_Grid";
            this.FreePprGr_Grid.Size = new System.Drawing.Size(289, 182);
            this.FreePprGr_Grid.TabIndex = 0;
            this.FreePprGr_Grid.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.FreePprGr_Grid_AfterSelectChange);
            this.FreePprGr_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FreePprGr_Grid_KeyDown);
            this.FreePprGr_Grid.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.FreePprGr_Grid_BeforeRowDeactivate);
            this.FreePprGr_Grid.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.FreePprGr_Grid_DoubleClickRow);
            // 
            // _GroupPanel_Toolbars_Dock_Area_Left
            // 
            this._GroupPanel_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._GroupPanel_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._GroupPanel_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._GroupPanel_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._GroupPanel_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 26);
            this._GroupPanel_Toolbars_Dock_Area_Left.Name = "_GroupPanel_Toolbars_Dock_Area_Left";
            this._GroupPanel_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 182);
            this._GroupPanel_Toolbars_Dock_Area_Left.ToolbarsManager = this.GroupToolbarsManager;
            // 
            // GroupToolbarsManager
            // 
            this.GroupToolbarsManager.DesignerFlags = 1;
            this.GroupToolbarsManager.DockWithinContainer = this.GroupPanel;
            this.GroupToolbarsManager.ShowFullMenusDelay = 500;
            this.GroupToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 0;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5,
            buttonTool6});
            ultraToolbar2.Text = "UltraToolbar1";
            this.GroupToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar2});
            buttonTool7.SharedProps.Caption = "グループ追加";
            buttonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool8.SharedProps.Caption = "グループ削除";
            buttonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.GroupToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool7,
            buttonTool8});
            this.GroupToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.GroupToolbarsManager_ToolClick);
            // 
            // _GroupPanel_Toolbars_Dock_Area_Right
            // 
            this._GroupPanel_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._GroupPanel_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._GroupPanel_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._GroupPanel_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._GroupPanel_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(289, 26);
            this._GroupPanel_Toolbars_Dock_Area_Right.Name = "_GroupPanel_Toolbars_Dock_Area_Right";
            this._GroupPanel_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 182);
            this._GroupPanel_Toolbars_Dock_Area_Right.ToolbarsManager = this.GroupToolbarsManager;
            // 
            // _GroupPanel_Toolbars_Dock_Area_Top
            // 
            this._GroupPanel_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._GroupPanel_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._GroupPanel_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._GroupPanel_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._GroupPanel_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._GroupPanel_Toolbars_Dock_Area_Top.Name = "_GroupPanel_Toolbars_Dock_Area_Top";
            this._GroupPanel_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(289, 26);
            this._GroupPanel_Toolbars_Dock_Area_Top.ToolbarsManager = this.GroupToolbarsManager;
            // 
            // _GroupPanel_Toolbars_Dock_Area_Bottom
            // 
            this._GroupPanel_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._GroupPanel_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._GroupPanel_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._GroupPanel_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._GroupPanel_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 208);
            this._GroupPanel_Toolbars_Dock_Area_Bottom.Name = "_GroupPanel_Toolbars_Dock_Area_Bottom";
            this._GroupPanel_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(289, 0);
            this._GroupPanel_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.GroupToolbarsManager;
            // 
            // ultraLabel1
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance19.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance19.ForeColor = System.Drawing.Color.White;
            appearance19.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance19.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance19.TextHAlignAsString = "Left";
            appearance19.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance19;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.5F, System.Drawing.FontStyle.Bold);
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(289, 26);
            this.ultraLabel1.TabIndex = 7;
            this.ultraLabel1.Text = "印刷グループ";
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.AlwaysEvent = true;
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // Main_DockManager
            // 
            this.Main_DockManager.AnimationSpeed = Infragistics.Win.UltraWinDock.AnimationSpeed.StandardSpeedPlus5;
            this.Main_DockManager.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            dockAreaPane1.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit;
            dockableControlPane1.Control = this.SelectExplorerBar;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(226, -1);
            dockableControlPane1.Key = "SelectCondition";
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(0, 3, 250, 619);
            dockableControlPane1.Pinned = false;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "拠点選択";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(226, 630);
            this.Main_DockManager.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.Main_DockManager.HostControl = this;
            this.Main_DockManager.ShowCloseButton = false;
            this.Main_DockManager.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _SFANL08201UAUnpinnedTabAreaLeft
            // 
            this._SFANL08201UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._SFANL08201UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08201UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._SFANL08201UAUnpinnedTabAreaLeft.Name = "_SFANL08201UAUnpinnedTabAreaLeft";
            this._SFANL08201UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._SFANL08201UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(22, 770);
            this._SFANL08201UAUnpinnedTabAreaLeft.TabIndex = 1;
            // 
            // _SFANL08201UAUnpinnedTabAreaRight
            // 
            this._SFANL08201UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._SFANL08201UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08201UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(924, 0);
            this._SFANL08201UAUnpinnedTabAreaRight.Name = "_SFANL08201UAUnpinnedTabAreaRight";
            this._SFANL08201UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._SFANL08201UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 770);
            this._SFANL08201UAUnpinnedTabAreaRight.TabIndex = 2;
            // 
            // _SFANL08201UAUnpinnedTabAreaTop
            // 
            this._SFANL08201UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._SFANL08201UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08201UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(22, 0);
            this._SFANL08201UAUnpinnedTabAreaTop.Name = "_SFANL08201UAUnpinnedTabAreaTop";
            this._SFANL08201UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._SFANL08201UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(902, 0);
            this._SFANL08201UAUnpinnedTabAreaTop.TabIndex = 3;
            // 
            // _SFANL08201UAUnpinnedTabAreaBottom
            // 
            this._SFANL08201UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._SFANL08201UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08201UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(22, 770);
            this._SFANL08201UAUnpinnedTabAreaBottom.Name = "_SFANL08201UAUnpinnedTabAreaBottom";
            this._SFANL08201UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._SFANL08201UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(902, 0);
            this._SFANL08201UAUnpinnedTabAreaBottom.TabIndex = 4;
            // 
            // _SFANL08201UAAutoHideControl
            // 
            this._SFANL08201UAAutoHideControl.Controls.Add(this.dockableWindow1);
            this._SFANL08201UAAutoHideControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08201UAAutoHideControl.Location = new System.Drawing.Point(22, 0);
            this._SFANL08201UAAutoHideControl.Name = "_SFANL08201UAAutoHideControl";
            this._SFANL08201UAAutoHideControl.Owner = this.Main_DockManager;
            this._SFANL08201UAAutoHideControl.Size = new System.Drawing.Size(71, 770);
            this._SFANL08201UAAutoHideControl.TabIndex = 5;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.SelectExplorerBar);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.Main_DockManager;
            this.dockableWindow1.Size = new System.Drawing.Size(226, 770);
            this.dockableWindow1.TabIndex = 7;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea1.Location = new System.Drawing.Point(22, 0);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.Main_DockManager;
            this.windowDockingArea1.Size = new System.Drawing.Size(231, 630);
            this.windowDockingArea1.TabIndex = 6;
            // 
            // SFANL08201UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(924, 770);
            this.Controls.Add(this._SFANL08201UAAutoHideControl);
            this.Controls.Add(this.SFANL08201U_Fill_Panel);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this._SFANL08201UAUnpinnedTabAreaTop);
            this.Controls.Add(this._SFANL08201UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._SFANL08201UAUnpinnedTabAreaRight);
            this.Controls.Add(this._SFANL08201UAUnpinnedTabAreaLeft);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SFANL08201UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SFANL08201UA_FormClosing);
            this.Load += new System.EventHandler(this.SFANL08201UA_Load);
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddUpCd_UOptionSet)).EndInit();
            this.ultraExplorerBarContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Section_UTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectExplorerBar)).EndInit();
            this.SelectExplorerBar.ResumeLayout(false);
            this.SFANL08201U_Fill_Panel.ResumeLayout(false);
            this.Centering_Panel.ResumeLayout(false);
            this.Splitter1_panel.ResumeLayout(false);
            this.Sqlitter1_panel1.ResumeLayout(false);
            this.DetailPanel.ResumeLayout(false);
            this.DetailPanel_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FreePprPrt_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailToolbarsManager)).EndInit();
            this.Splitter2_panel.ResumeLayout(false);
            this.Splitter2_panel2.ResumeLayout(false);
            this.PrintBtnPanel.ResumeLayout(false);
            this.Panel_Fill_Panel.ResumeLayout(false);
            this.GroupPanel.ResumeLayout(false);
            this.GroupPanel_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FreePprGr_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupToolbarsManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            this._SFANL08201UAAutoHideControl.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region private member
        private string _enterpriseCode = "";
        private SFANL08131UA _extCdtForm = new SFANL08131UA();         //抽出条件用画面作成部品
        private SFANL08131UB _sortCngFrom = new SFANL08131UB();        //ソート順変更部品
        private bool _isOptSection = false;                           //拠点オプション有無
        private bool _isMainOfficeFunc = false;                       //本社機能
        private string _loginSectionCode = "";						    //ログイン拠点コード

        static private List<FrePrtPSet> _frePrtPSetLs = new List<FrePrtPSet>();   //自由帳票印字位置設定キャッシュ
        static private List<FrePprGrTr> _freePprGrpTrLs = new List<FrePprGrTr>(); //自由帳票グループ振替キャッシュ
        private Dictionary<string, List<FrePprECnd>> _frePprECndLsHt = new Dictionary<string, List<FrePprECnd>>(); //抽出条件リストキャッシュ(key:FreePrtPprGroupCd.ToString() + "," + OutputFormFileName+","+ UserPrtPprIdDerivNo.ToString())
        private Dictionary<string, List<FrePprSrtO>> _frePprSrtOLsHT = new Dictionary<string, List<FrePprSrtO>>(); //自由帳票ソート順位リストキャッシュ(key:FreePrtPprGroupCd.ToString() + "," + OutputFormFileName+","+ UserPrtPprIdDerivNo.ToString())
        private List<FrePExCndD> _frePprECndDLs = null;                            //抽出条件明細リストキャッシュ

        private SFANL08203U _printDialog = new SFANL08203U();              //印刷ダイアログ
        private SFANL08205C _printInfo = new SFANL08205C();                //印刷情報パラメータ
        private SecInfoAcs _secInfoAcs = new SecInfoAcs();                 //拠点情報アクセスクラス
        private List<SecInfoSet> _secInfoLs = new List<SecInfoSet>();      //拠点情報キャッシュ
        private List<string> _selectSecCds = new List<string>();         //選択拠点コードリスト

        private bool _secNodeCheckEvent = false;					        //拠点選択イベント処理フラグ
        private List<FrePprECnd> _frePprECndLs = new List<FrePprECnd>();   //検索条件
        private LastPrtTimeAcs _lastPrtTimeAcs = new LastPrtTimeAcs();     //最終印刷日時アクセスクラス
        private List<LastPrtTime> _lastTimes = null;                      //最終印刷日時キャッシュ

        private bool _allSectionDiv = false;                               //全社区分


        // --- グループ制御 -------------------------
        private DataSet _freeSheetGrDS = new DataSet();                    //自由帳票グループデータセット
        private MaintenanceDlg _maintenanceDlg = new MaintenanceDlg();     //自由帳票グループ/振替追加変更ダイアログ
        private FreePprGrpAcs _frePprGrAcs = new FreePprGrpAcs();          //自由帳票グループアクセスクラス

        // --- 明細制御 -------------------------
        private DataSet _freeSheetPrtDS = new DataSet();                   //自由帳票印刷対象データセット
        private DataView _freeSheetPrtDV;                                  //自由帳票印刷対象データビュー

        #endregion

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        #region private constant
        // ツールバー関連
        private const string CT_PRINT_BUTTONTOOL = "PrintButtonTool";

        // Message関連
        private const string ctPRINT_TITLE = "自由帳票一括印刷";
        private const string ctPRINT_MESSAGE = "自由帳票一括印刷中です．．．";

        // 全社拠点コード
        private const string CT_AllSectionCode = "0";
        // 全拠点コード
        private const string CT_AllCtrlFuncSecCode = "000000";

        // エクスプローラーバーキー設定
        private const string EXPLORERBAR_ADDUPCDLIST = "AddUpCdList";
        private const string EXPLORERBAR_SECTIONLIST = "SectionList";

        // ドックマネージャーキー設定
        private const string DOCKMANAGER_SELECTCONDITION_KEY = "SelectCondition";

        #endregion

        // ===================================================================================== //
        // メイン
        // ===================================================================================== //
        #region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run( new SFANL08201UA() );
        }
        #endregion

        // ===================================================================================== //
        // public Methods
        // ===================================================================================== //
        #region public Methods
        /// <summary>
        /// 印字位置キャッシュ取得処理
        /// </summary>
        /// <param name="frePprPSetLs">自由帳票印字位置キャッシュ(key:OutputFormFileName+","+ UserPrtPprIdDerivNo.ToString())</param>
        /// <returns>ステータス:正常取得0 キャッシュなし：4</returns>
        static public int GetFrePrtPSetLsCash( ref List<FrePrtPSet> frePprPSetLs )
        {
            if ( (_frePrtPSetLs == null) || (_frePrtPSetLs.Count == 0) )
                return 4;
            else
            {
                frePprPSetLs = _frePrtPSetLs;
                return 0;
            }
        }

        /// <summary>
        /// 自由帳票印字位置取得
        /// </summary>
        /// <param name="groupCd"></param>
        /// <param name="outputFormFileName">出力フォーマット</param>
        /// <param name="userPrtPprIdDerivNo">枝番</param>
        /// <returns></returns>
        static public FrePprGrTr GetFrePprGrTrCash( int groupCd, string outputFormFileName, int userPrtPprIdDerivNo )
        {
            return _freePprGrpTrLs.Find( delegate( FrePprGrTr grtr )
            {
                if ( (grtr.FreePrtPprGroupCd == groupCd) && (grtr.OutputFormFileName == outputFormFileName) && (grtr.UserPrtPprIdDerivNo == userPrtPprIdDerivNo) )
                    return true;
                else
                    return false;
            } );
        }

        #endregion

        // ===================================================================================== //
        // private methods
        // ===================================================================================== //
        #region private methods
        #region 拠点情報キャッシュ
        /// <summary>
        /// 拠点情報を取得しバッファ変数にキャッシュします
        /// </summary>
        /// <returns>ステータス</returns>
        private int GetSecInfoSetCash()
        {
            _secInfoLs.Clear();
            for ( int i = 0; i < this._secInfoAcs.SecInfoSetList.Length; i++ )
            {
                this._secInfoLs.Add( this._secInfoAcs.SecInfoSetList[i].Clone() );
            }
            if ( this._secInfoLs.Count == 0 ) return (int)ConstantManagement.DB_Status.ctDB_EOF;
            return 0;
        }
        #endregion

        #region 拠点選択UI設定処理
        /// <summary>
        /// 拠点選択ツリー構築処理
        /// </summary>
        /// <param name="extraSectionSelExist"></param>
        /// <returns></returns>
        private int InitSettingSectionTree( int extraSectionSelExist )
        {
            // 拠点オプション有無チェック
            if ( (int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION ) > 0 )
            {
                this._isOptSection = true;
            }
            else
            {
                this._isOptSection = false;
                SelectExplorerBar.Visible = false;
            }
            // 本社機能判定
            // 2008.12.25 Modify Start [9575]
            //this._isMainOfficeFunc = (this._secInfoAcs.GetMainOfficeFuncFlag( this._loginSectionCode ) == 1);
            this._isMainOfficeFunc = true;  // 本社機能限定
            // 2008.12.25 Modify End [9575]

            // 拠点オプション有り
            if ( this._isOptSection )
            {
                this.Section_UTree.Nodes.Clear();
                if ( extraSectionSelExist == 1 )
                {
                    if ( this._secInfoLs != null )
                    {
                        // 複数拠点存在する場合、全社を設定
                        if ( this._secInfoLs.Count > 1 )
                        {
                            this.Section_UTree.Nodes.Add( CT_AllSectionCode, "全社" );
                            this.Section_UTree.Nodes[CT_AllSectionCode].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                            this.Section_UTree.Nodes[CT_AllSectionCode].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                        }
                        foreach ( SecInfoSet secInfoSet in _secInfoLs )
                        {
                            this.Section_UTree.Nodes.Add( secInfoSet.SectionCode.TrimEnd(), secInfoSet.SectionGuideNm );
                            this.Section_UTree.Nodes[secInfoSet.SectionCode.TrimEnd()].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                            this.Section_UTree.Nodes[secInfoSet.SectionCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                        }
                    }
                    // デフォルトチェックはログイン拠点
                    this.Section_UTree.Nodes[this._loginSectionCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Checked;
                }
                else if ( extraSectionSelExist == 2 )
                {
                    foreach ( SecInfoSet secInfoSet in _secInfoLs )
                    {
                        this.Section_UTree.Nodes.Add( secInfoSet.SectionCode.TrimEnd(), secInfoSet.SectionGuideNm );
                        this.Section_UTree.Nodes[secInfoSet.SectionCode.TrimEnd()].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.OptionButton;
                    }
                    // デフォルトチェックはログイン拠点
                    this.Section_UTree.Nodes[this._loginSectionCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Checked;
                }
                else
                {
                    SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = false;
                }
            }
            else Main_DockManager.Visible = false;
            return 0;
        }

        /// <summary>
        /// 拠点選択ツリーのビュー状態を設定します
        /// </summary>
        /// <param name="extraSectionSelExist"></param>
        private void ViewSettingSectionTree( int extraSectionSelExist )
        {
            // 拠点選択・計上拠点選択表示設定
            if ( _isMainOfficeFunc )
            {
                if ( extraSectionSelExist != 0 )
                    SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = true;
            }
            else
            {
                SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = false;
            }

        }
        #endregion

        #region 拠点種類リスト画面レイアウト設定
        /// <summary>
        /// 拠点種類リスト画面レイアウト設定
        /// </summary>
        /// <param name="extraSectionKindCd">拠点種別区分</param>
        private void InitialSettingSectionKind( int extraSectionKindCd )
        {
            // 計上種類オプションセット初期化
            if ( this.AddUpCd_UOptionSet.Items != null )
            {
                this.AddUpCd_UOptionSet.Items.Clear();
            }

            switch ( extraSectionKindCd )
            {
                case 1:
                    {
                        // タイトル設定
                        Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                        item.DataValue = 1;
                        item.DisplayText = "実績計上拠点";
                        item.Tag = 10;
                        this.AddUpCd_UOptionSet.Items.Add( item );

                        item = new Infragistics.Win.ValueListItem();
                        item.DataValue = 2;
                        item.DisplayText = "請求計上拠点";
                        item.Tag = 20;
                        this.AddUpCd_UOptionSet.Items.Add( item );
                        break;
                    }
                case 2:
                    {
                        // タイトル設定
                        Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                        item.DataValue = 1;
                        item.DisplayText = "仕入計上拠点";
                        item.Tag = 30;
                        this.AddUpCd_UOptionSet.Items.Add( item );

                        item = new Infragistics.Win.ValueListItem();
                        item.DataValue = 2;
                        item.DisplayText = "販売計上拠点";
                        item.Tag = 40;
                        this.AddUpCd_UOptionSet.Items.Add( item );
                        break;
                    }
            }
            // 初期値設定
            if ( this.AddUpCd_UOptionSet.Items != null )
            {
                if ( this.AddUpCd_UOptionSet.Items.Count > 0 )
                {
                    this.AddUpCd_UOptionSet.CheckedIndex = 0;
                }
            }
            _printInfo.sectionKindCd = 1;
        }

        /// <summary>
        /// 計上拠点種別の表示状態を制御
        /// </summary>
        /// <param name="extraSectionKindCd"></param>
        private void ViewSettingSectionKind( int extraSectionKindCd )
        {
            if ( this.AddUpCd_UOptionSet.Items != null )
            {
                SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = true;
            }

            if ( extraSectionKindCd == 0 )
            {
                if ( SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST] != null )
                    SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = false;
            }
        }

        #endregion

        #region 制御機能拠点取得
        /// <summary>
        /// 制御機能拠点取得
        /// </summary>
        /// <param name="sectionCode">対象拠点コード</param>
        /// <param name="ctrlFuncCode">取得する制御機能コード</param>
        /// <param name="ctrlSectionCode">対象制御拠点コード</param>
        /// <returns>status</returns>
        private int GetOwnSeCtrlCode( string sectionCode, int ctrlFuncCode, out string ctrlSectionCode )
        {
            // 対象制御拠点の初期値は自拠点
            ctrlSectionCode = sectionCode;

            SecInfoSet secInfoSet;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //SecInfoAcs.CtrlFuncCode ctrlFunc;
            //switch (ctrlFuncCode)
            //{
            //    case 10:		// 自拠点設定
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.OwnSecSetting;
            //        break;
            //    case 20:		// 請求計上拠点
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd;
            //        break;
            //    case 30:		// 実績計上拠点
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.ResultsAddUpSecCd;
            //        break;
            //    case 40:		// 請求設定拠点
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.BillSettingSecCd;
            //        break;
            //    case 50:		// 残高表示拠点
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.BalanceDispSecCd;
            //        break;
            //    case 60:		// 支払計上拠点
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.PayAddUpSecCd;
            //        break;
            //    case 70:		// 支払設定拠点
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.PayAddUpSetSecCd;
            //        break;
            //    case 80:		// 支払残高表示拠点
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.PayBlcDispSecCd;
            //        break;
            //    case 90:		// 在庫更新拠点
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.StockUpdateSecCd;
            //        break;
            //    default:
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.OwnSecSetting;
            //        break;
            //}
            //int status = this._secInfoAcs.GetSecInfo(sectionCode, ctrlFunc, out secInfoSet);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 ADD
            int status = this._secInfoAcs.GetSecInfo( sectionCode, out secInfoSet );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 ADD
            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    if ( secInfoSet != null )
                    {
                        ctrlSectionCode = secInfoSet.SectionCode.TrimEnd();

                        //「全拠点: 000000」だったら「全社: 0」に置き換える
                        if ( ctrlSectionCode.Equals( CT_AllCtrlFuncSecCode ) )
                        {
                            ctrlSectionCode = CT_AllSectionCode;

                        }
                    }
                    break;
                default:
                    break;
            }

            return status;
        }
        #endregion

        #region 初期画面設定
        /// <summary>
        /// 初期画面設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期画面設定を行います。</br>
        /// <br>Programmer : 22011 Kashihara</br>
        /// <br>Date       : 2005.09.09</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            //-- グループ ---------------------
            DataSetColumnConstruction();        //データセット作成
            FreePprGr_Grid.DataSource = _freeSheetGrDS.Tables[CT_FREE_PPR_GR];
            _freeSheetGrDS.Tables[CT_FREE_PPR_GR].DefaultView.Sort = CT_FREE_PPR_GrCd;
            //自由帳票グループのグリッド設定
            setGridAppearance( FreePprGr_Grid );        // 配色設定
            setGridBehavior( FreePprGr_Grid );          // 動作設定
            // ツールバーの設定
            SetToolbarAppearance( GroupToolbarsManager );

            //-- 明細 -------------------------
            //データセット作成
            _freeSheetPrtDV = new DataView( _freeSheetPrtDS.Tables[CT_FREE_PPR_PRT] );
            _freeSheetPrtDV.Sort = CT_FREE_PPR_DspOdr;                      //表示順位順にソート
            FreePprPrt_Grid.DataSource = this._freeSheetPrtDV;             //グリッドにバインド
            //自由帳票印刷対象のグリッド設定
            setGridAppearance( FreePprPrt_Grid );        // 配色設定
            setGridBehavior( FreePprPrt_Grid );          // 動作設定
            SetGridColAppearance();                   // 列概観設定(グループ・振替)

            // ツールバーの設定
            SetToolbarAppearance( DetailToolbarsManager );


            //アイコンの設定
            ImageList imageList16 = IconResourceManagement.ImageList16;
            //印刷ボタン
            this.Print_Button.ImageList = imageList16;
            this.Print_Button.Appearance.Image = Size16_Index.PRINT;
            // 出力条件選択
            this.Main_DockManager.ImageList = IconResourceManagement.ImageList16;
            this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Settings.Appearance.Image = Size16_Index.TREE;

            //ツールバー設定
            List<string> editMenuKeyLs = new List<string>();
            editMenuKeyLs.Add( FreeSheetConst.ctToolBase_Save );
            editMenuKeyLs.Add( FreeSheetConst.ctToolBase_New );
            editMenuKeyLs.Add( FreeSheetConst.ctToolBase_Print );
            editMenuKeyLs.Add( FreeSheetConst.ctToolBase_Open );
            editMenuKeyLs.Add( FreeSheetConst.ctPopupMenu_Help );
            editMenuKeyLs.Add( FreeSheetConst.ctPopupMenu_Display );
            editMenuKeyLs.Add( FreeSheetConst.ctPopupMenu_Window );
            editMenuKeyLs.Add( FreeSheetConst.ctPopupMenu_Edit );

            //抽出条件画面をセット
            _extCdtForm.Dock = DockStyle.Fill;
            _extCdtForm.BackColor = ExtractPanel.BackColor;
            this.ExtractPanel.Controls.Add( _extCdtForm );

            //イベントをキック
            ToolButtonVisibleChanged( editMenuKeyLs, false );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 ADD
            ToolButtonEnableChanged( editMenuKeyLs, false );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 ADD

            //自由帳票グループ、自由帳票グループ振替をキャッシュ
            SetDataSource( 0 );

            //全グループ行をアクティベート
            AllFreePprGroupActivated();
            GroupFiltering( 0 );
            FirstRowActivated();
        }
        #endregion 初期画面設定

        #region メッセージ表示
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
        /// <br>Programmer : 22011 Kashihara</br>
        /// <br>Date       : 2006.01.20</br>
        /// </remarks>
        private DialogResult TMessageBox( emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton )
        {
            return TMsgDisp.Show( iLevel, this.Name, iMsg, iSt, iButton, iDefButton );
        }
        #endregion

        #region キャッシュからデータを取得します
        /// <summary>
        /// 自由帳票印字位置取得
        /// </summary>
        /// <param name="outputFormFileName">出力フォーマット</param>
        /// <param name="userPrtPprIdDerivNo">枝番</param>
        /// <returns></returns>
        private FrePrtPSet GetFrePrtPSetCash( string outputFormFileName, int userPrtPprIdDerivNo )
        {
            return _frePrtPSetLs.Find( delegate( FrePrtPSet pset )
            {
                if ( (pset.OutputFormFileName == outputFormFileName) && (pset.UserPrtPprIdDerivNo == userPrtPprIdDerivNo) )
                    return true;
                else
                    return false;
            } );
        }

        /// <summary>
        /// グループ振替からグループを区別したキーを作成します(条件、ソート順用)
        /// </summary>
        /// <param name="frePprGrTr"></param>
        /// <returns></returns>
        private string Generate_FrePprGrTr_Key( FrePprGrTr frePprGrTr )
        {
            return frePprGrTr.FreePrtPprGroupCd.ToString() + "," + frePprGrTr.TransferCode.ToString() + "," + frePprGrTr.OutputFormFileName + "," + frePprGrTr.UserPrtPprIdDerivNo.ToString();
        }

        /// <summary>
        /// 印字位置設定からグループを区別しない(初期値の)キーを作成します(条件、ソート順　初期値用用)
        /// </summary>
        /// <param name="frePrtPSet"></param>
        /// <returns></returns>
        private string Generate_FrePprGrTr_Key( FrePrtPSet frePrtPSet )
        {
            return "-1,0," + frePrtPSet.OutputFormFileName + "," + frePrtPSet.UserPrtPprIdDerivNo.ToString();
        }

        /// <summary>
        /// グループ振替からグループを区別しない(初期値の)キーを作成します(条件、ソート順　初期値用用)
        /// </summary>
        /// <param name="frePprGrTr"></param>
        /// <returns></returns>
        private string Generate_FrePprGrTr_Init_Key( FrePprGrTr frePprGrTr )
        {
            return "-1,0," + frePprGrTr.OutputFormFileName + "," + frePprGrTr.UserPrtPprIdDerivNo.ToString();
        }

        /// <summary>
        /// 印字位置設定から各印字位置設定を区別するキーを作成します
        /// </summary>
        /// <param name="frePrtPSet"></param>
        /// <returns></returns>
        private string Generate_FrePrtPSet_Key( FrePrtPSet frePrtPSet )
        {
            return frePrtPSet.OutputFormFileName + "," + frePrtPSet.UserPrtPprIdDerivNo.ToString();
        }

        /// <summary>
        /// グループ振替から各印字位置設定を区別するキーを作成します
        /// </summary>
        /// <param name="frePprGrTr"></param>
        /// <returns></returns>
        private string Generate_FrePrtPSet_Key( FrePprGrTr frePprGrTr )
        {
            return frePprGrTr.OutputFormFileName + "," + frePprGrTr.UserPrtPprIdDerivNo.ToString();
        }
        #endregion

        #region 抽出条件画面構築処理
        private int SetExtraCnditionFrom()
        {
            int status = 0;
            FrePprGrTr frePprGrTr;    //印刷時用振替マスタ
            _frePprECndLs = new List<FrePprECnd>();

            //振替情報取得
            status = this.GetActiveFrePprGrTr( out frePprGrTr );
            if ( (status != 0) || (frePprGrTr.FileHeaderGuid == Guid.Empty) )
            {
                if ( frePprGrTr.FileHeaderGuid == Guid.Empty ) status = (Int32)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                _extCdtForm.Hide();
                ViewSettingSectionTree( 0 );

                SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = false;
                SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = false;
                return status;
            }
            //else
            //{
            //    SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = true;
            //    SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = true;
            //}

            //抽出条件を取得
            if ( _frePprECndLsHt.ContainsKey( Generate_FrePprGrTr_Key( frePprGrTr ) ) )
            {
                _frePprECndLs = (List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Key( frePprGrTr )];
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            //抽出条件明細を取得
            if ( _frePprECndDLs == null )
            {
                FrePrtPSetAcs frePExCndDAcs = new FrePrtPSetAcs();
                frePExCndDAcs.SearchFrePExCndDList( _enterpriseCode, out _frePprECndDLs );
            }

            //抽出条件を画面に設定
            status = _extCdtForm.FreePrintExtrUIShow( _frePprECndLs, _frePprECndDLs );

            if ( status != 0 )
            {
                TMessageBox( emErrorLevel.ERR_LEVEL_STOP, _extCdtForm.GetErrorMessage, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
            }

            //印字位置設定を取得
            FrePrtPSet frePrtPSetBuff = GetFrePrtPSetCash( frePprGrTr.OutputFormFileName, frePprGrTr.UserPrtPprIdDerivNo );
            if ( frePrtPSetBuff != null )
            {
                FrePrtPSet pset = frePrtPSetBuff;
                //拠点種別を設定
                ViewSettingSectionKind( pset.ExtraSectionKindCd );
                //拠点選択ツリー作成
                ViewSettingSectionTree( pset.ExtraSectionSelExist );
            }
            else
            {
                ViewSettingSectionKind( 0 );
                ViewSettingSectionTree( 0 );
            }
            return status;
        }
        #endregion

        #region ソート順位変更画面構築処理
        private int SetSortOrderForm()
        {
            int status = 0;
            List<FrePprSrtO> frePprSrtOLs = new List<FrePprSrtO>();     //ソート順位
            FrePprGrTr frePprGrTr;                                      //印刷時用振替マスタ

            //振替情報取得
            status = this.GetActiveFrePprGrTr( out frePprGrTr );
            if ( status != 0 )
            {
                return status;
            }

            //ソート順位取得
            if ( _frePprSrtOLsHT.ContainsKey( Generate_FrePprGrTr_Key( frePprGrTr ) ) )
            {
                frePprSrtOLs = (List<FrePprSrtO>)_frePprSrtOLsHT[Generate_FrePprGrTr_Key( frePprGrTr )];
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            _sortCngFrom.ShowSortOderSetting( frePprSrtOLs );

            return status;
        }
        #endregion

        #region 自由帳票グループ変更イベント
        /// <summary>
        /// 自由帳票グループ変更時のイベントです
        /// </summary>
        /// <param name="groupCd"></param>
        private void FrePPrGroupChange( Int32 groupCd )
        {
            // 明細行をグループコードでフィルタリング
            GroupFiltering( groupCd );
            FirstRowActivated();
            // 明細行がなかったら条件画面をここで再構築
            if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
                SetExtraCnditionFrom();
        }
        #endregion

        #region 初期データセット構築処理
        private void CreateInitialDataSet()
        {
            FrePrtPosLocalAcs frePrtPSetAcs = new FrePrtPosLocalAcs();  //印字位置設定アクセス(ローカル)
            List<FrePrtPSet> frePrtPSetLsts = new List<FrePrtPSet>();   //自由帳票印字位置設定
            List<FrePprECnd> frePprECndLsts = new List<FrePprECnd>();   //自由帳票抽出条件検索結果
            List<FrePprSrtO> frePprSrtLsts = new List<FrePprSrtO>();    //自由帳票ソート順
            List<FrePprECnd> frePprECndLstsBuf = null;                  //自由帳票抽出条件バッファ
            List<FrePprSrtO> frePprSrtOLstsBuf = null;                  //自由帳票ソート順バッファ

            //自由帳票印字位置取得
            frePrtPSetAcs.SearchLocalFrePrtPSet( _enterpriseCode, 1, out frePrtPSetLsts, out frePprECndLsts, out frePprSrtLsts );

            //自由帳票印字位置,抽出条件,ソート順をキャッシュ
            foreach ( FrePrtPSet frePrtPSet in frePrtPSetLsts )
            {
                frePprECndLstsBuf = new List<FrePprECnd>();
                frePprSrtOLstsBuf = new List<FrePprSrtO>();

                //自由帳票印字位置をキャッシュ
                _frePrtPSetLs.Add( frePrtPSet );

                //抽出条件(初期値)をキャッシュ
                frePprECndLstsBuf = frePprECndLsts.FindAll( delegate( FrePprECnd frePprECnd )
                {
                    if ( (frePprECnd.OutputFormFileName == frePrtPSet.OutputFormFileName) &&
                       (frePprECnd.UserPrtPprIdDerivNo == frePrtPSet.UserPrtPprIdDerivNo) &&
                           (frePprECnd.UsedFlg == 1) ) return true;
                    else return false;
                } );
                if ( (frePprECndLstsBuf != null) && (frePprECndLstsBuf.Count > 0) )
                {
                    _frePprECndLsHt[Generate_FrePprGrTr_Key( frePrtPSet )] = frePprECndLstsBuf;
                }

                //自由帳票ソート順位をキャッシュ
                frePprSrtOLstsBuf = frePprSrtLsts.FindAll( delegate( FrePprSrtO frePprSrtO )
                {
                    if ( (frePprSrtO.OutputFormFileName == frePrtPSet.OutputFormFileName) &&
                        (frePprSrtO.UserPrtPprIdDerivNo == frePrtPSet.UserPrtPprIdDerivNo) ) return true;
                    else return false;
                } );
                if ( (frePprSrtOLstsBuf != null) && (frePprSrtOLstsBuf.Count > 0) )
                {
                    frePprSrtOLstsBuf.Sort( new FrePprSrtOSortingOrderComparer() );
                    _frePprSrtOLsHT[Generate_FrePprGrTr_Key( frePrtPSet )] = frePprSrtOLstsBuf;
                }
            }
        }

        /// <summary>
        /// 自由帳票グループ、自由帳票グループ振替をデータセットに設定します
        /// </summary>
        /// <param name="mode">0:両方,1:グループのみ,2:振替のみ</param>
        /// <returns></returns>
        private int SetDataSource( int mode )
        {
            ArrayList freePprGrpAL = new ArrayList();                   //自由帳票グループ抽出結果
            ArrayList frePprGrTrAL = new ArrayList();                   //自由帳票グループ振替
            int status = 0;

            if ( mode != 2 )
            {
                //自由帳票グループ取得
                status = _frePprGrAcs.SearchAllFreePprGrp( out freePprGrpAL, _enterpriseCode );
                if ( status != 0 ) return status;
                ClearGroupDataTable();    //グループ情報のDataTable初期化

                //グループをデータセットに登録
                foreach ( FreePprGrp freePprGrp in freePprGrpAL )
                {
                    //グループをDSに登録
                    FreePprGrToDataSet( freePprGrp );
                }
            }

            if ( mode != 1 )
            {
                //自由帳票グループ振替取得
                status = _frePprGrAcs.SearchAllFreePprGrTr( out frePprGrTrAL, LoginInfoAcquisition.EnterpriseCode );
                if ( status != 0 ) return status;
                ClearDataTable();   //DataTable初期化

                //自由帳票グループ振替をデータセットに登録
                foreach ( FrePprGrTr fpgrtr in frePprGrTrAL )
                {
                    FrePrtPSet fppset = GetFrePrtPSetCash( fpgrtr.OutputFormFileName, fpgrtr.UserPrtPprIdDerivNo );
                    if ( fppset != null )
                    {
                        //コメント追加
                        fpgrtr.PrtPprUserDerivNoCmt = fppset.PrtPprUserDerivNoCmt;
                        //最終印刷日時追加
                        LastPrtTime lastTime = _lastPrtTimeAcs.FindLastPrtTime( _lastTimes, fpgrtr );
                        if ( lastTime != null )
                        {
                            FreeSeetPrtToDataSet( fpgrtr, lastTime.lastPrtTime );
                        }
                        else
                        {
                            FreeSeetPrtToDataSet( fpgrtr );
                        }
                        _freePprGrpTrLs.Add( fpgrtr );

                        //条件、ソート順を初期値から複製
                        if ( mode == 0 )
                        {
                            //-- 新しいインスタンスを作って、内容をコピー ------------------
                            List<FrePprECnd> frePprECndLs = new List<FrePprECnd>();
                            List<FrePprSrtO> frePprSrtOLs = new List<FrePprSrtO>();

                            FrePprECnd[] frePprECnds = new FrePprECnd[((List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Key( fppset )]).Count];
                            FrePprSrtO[] frePprSrtOs = new FrePprSrtO[((List<FrePprSrtO>)_frePprSrtOLsHT[Generate_FrePprGrTr_Key( fppset )]).Count];

                            ((List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Key( fppset )]).CopyTo( frePprECnds );
                            ((List<FrePprSrtO>)_frePprSrtOLsHT[Generate_FrePprGrTr_Key( fppset )]).CopyTo( frePprSrtOs );
                            foreach ( FrePprECnd frePprECnd in frePprECnds )
                            {
                                FrePprECnd ecnd = (FrePprECnd)DBAndXMLDataMergeParts.CopyPropertyInClass( frePprECnd, typeof( FrePprECnd ) );
                                frePprECndLs.Add( ecnd );
                            }
                            foreach ( FrePprSrtO frePprSrtO in frePprSrtOs )
                            {
                                FrePprSrtO srtO = (FrePprSrtO)DBAndXMLDataMergeParts.CopyPropertyInClass( frePprSrtO, typeof( FrePprSrtO ) );
                                frePprSrtOLs.Add( srtO );
                            }
                            _frePprECndLsHt[Generate_FrePprGrTr_Key( fpgrtr )] = frePprECndLs;
                            _frePprSrtOLsHT[Generate_FrePprGrTr_Key( fpgrtr )] = frePprSrtOLs;
                        }
                    }
                    else
                    {
                        fpgrtr.PrtPprUserDerivNoCmt = "未ダウンロード";
                        fpgrtr.FileHeaderGuid = Guid.Empty;
                        FreeSeetPrtToDataSet( fpgrtr );
                    }
                }
            }
            return status;
        }
        #endregion

        #region 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="frePprGrTr">自由帳票グループ振替</param>
        /// <param name="printmode">1：通常印刷、3：バッチ印刷</param>
        /// <returns>ステータス</returns>
        private int PrintProc( FrePprGrTr frePprGrTr, int printmode )
        {
            _printInfo = new SFANL08205C();                         //印刷情報パラメータ
            FrePrtPSet frePrtPSet = null;                           //印刷用印字位置情報クラス
            List<FrePprECnd> frePprECndLs = new List<FrePprECnd>(); //検索条件
            string errMsg;      //条件入力用エラーメッセージ
            Control errCtl;      //条件入力用エラーコントロール

            if ( frePprGrTr == null )
            {
                if ( printmode == 1 )
                {
                    TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, "印刷対象がありません", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                }
                return -1;
            }

            //抽出条件をキャッシュから戻す
            if ( _frePprECndLsHt.ContainsKey( Generate_FrePprGrTr_Key( frePprGrTr ) ) )
            {
                frePprECndLs = (List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Key( frePprGrTr )];
            }

            //印字位置クラス取得
            frePrtPSet = GetFrePrtPSetCash( frePprGrTr.OutputFormFileName, frePprGrTr.UserPrtPprIdDerivNo );

            //通常印刷の時 {バッチ印刷の時は事前に行っている}
            if ( (printmode == 1) && (frePrtPSet != null) )
            {
                //抽出条件取得
                _extCdtForm.GetFrePprECndList( ref frePprECndLs );

                //条件の入力チェック
                if ( !_extCdtForm.InputCheck( frePprECndLs, out errMsg, out errCtl, true ) )
                {
                    TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                    errCtl.Focus();
                    return -1;
                }
                //ｸﾞﾙｰﾌﾟ毎の個別ﾁｪｯｸ 2008.03.18 ADD ======================== START
                //switch (frePrtPSet.PrintPaperDivCd)
                //{
                //    case 1: //日次帳票
                //        {
                if ( SFANL08235CH.Check_ECnd_DaillyReport( frePprECndLs, out errMsg ) != 0 )
                {
                    TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                    return -1;
                }
                //            break;
                //        }
                //}
                //ｸﾞﾙｰﾌﾟ毎の個別ﾁｪｯｸ 2008.03.18 ADD ======================== END
            }



            //位置情報がなかったら
            if ( frePrtPSet == null )
            {
                // 通常印刷のときだけメッセージ表示
                if ( printmode == 1 )
                {
                    if ( string.IsNullOrEmpty( frePprGrTr.DisplayName ) )
                    {
                        TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, "印刷対象がありません", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                    }
                    else
                    {
                        TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, frePprGrTr.DisplayName + "の印字位置データがありません", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                    }
                }
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            //印刷パラメータをセット
            _printInfo.InportFrePrtPSet( frePrtPSet, _enterpriseCode, "SFANL08201U", frePprECndLs, _frePprECndDLs, false );

            //ソート順位取得
            if ( _frePprSrtOLsHT.ContainsKey( Generate_FrePprGrTr_Key( frePprGrTr ) ) )
            {
                _printInfo.sortOdrLs = (List<FrePprSrtO>)_frePprSrtOLsHT[Generate_FrePprGrTr_Key( frePprGrTr )];
            }

            //拠点情報セット
            if ( _isOptSection )
            {
                if ( _printInfo.sectionNameLs == null ) _printInfo.sectionNameLs = new Dictionary<string, string>();
                for ( int i = 0; i < this._secInfoAcs.SecInfoSetList.Length; i++ )
                {
                    _printInfo.sectionNameLs[this._secInfoAcs.SecInfoSetList[i].SectionCode.Trim()] = this._secInfoAcs.SecInfoSetList[i].SectionGuideNm.Trim();
                }

                _printInfo.selectSecCds = _selectSecCds;
                _printInfo.sectionOptionDiv = true;
            }
            else
            {
                _printInfo.sectionOptionDiv = false;
            }
            // 拠点種別コード
            _printInfo.sectionKindCd = AddUpCd_UOptionSet.CheckedIndex + 1;
            // 全社区分
            _printInfo.AllSectionCodeDiv = _allSectionDiv;
            // プロパティセット
            _printDialog.PrintInfo = _printInfo;

            // 帳票選択ガイド
            if ( printmode == 1 )
            {
                if ( _printDialog.PinrtDlgShow( this ) == DialogResult.OK )
                {
                    //最終印刷日時を記録
                    LastPrtTime lastTime = _lastPrtTimeAcs.FindLastPrtTime( _lastTimes, frePprGrTr );
                    if ( lastTime != null )
                    {
                        _lastTimes.Remove( lastTime );
                    }
                    _lastPrtTimeAcs.SetLastPrtTime( out lastTime, frePprGrTr );
                    _lastTimes.Add( lastTime );
                    SetPrtTime( frePprGrTr.FreePrtPprGroupCd, frePprGrTr.TransferCode, lastTime.lastPrtTime );
                    FreePprPrt_Grid.Refresh();
                }
            }
            else if ( printmode == 3 )
            {
                if ( _printDialog.BatchPrint() == 0 )
                {
                    //最終印刷日時を記録
                    LastPrtTime lastTime = _lastPrtTimeAcs.FindLastPrtTime( _lastTimes, frePprGrTr );
                    if ( lastTime != null )
                    {
                        _lastTimes.Remove( lastTime );
                    }
                    _lastPrtTimeAcs.SetLastPrtTime( out lastTime, frePprGrTr );
                    _lastTimes.Add( lastTime );
                    SetPrtTime( frePprGrTr.FreePrtPprGroupCd, frePprGrTr.TransferCode, lastTime.lastPrtTime );
                    FreePprPrt_Grid.Refresh();
                }
            }

            // 印刷ダイアログ起動
            if ( _printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN || _printInfo.status == (int)ConstantManagement.DB_Status.ctDB_EOF )
            {
                // 通常印刷のときだけメッセージ
                if ( printmode == 1 )
                {
                    TMessageBox( emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                }
            }
            return _printInfo.status;
        }
        #endregion

        #region 1件印刷
        /// <summary>
        /// ダイアログ表示1件印刷
        /// </summary>
        /// <returns></returns>
        private int Print( FrePprGrTr frePprGrTr )
        {
            return PrintProc( frePprGrTr, 1 );
        }
        #endregion

        #region バッチ印刷処理
        /// <summary>
        /// ダイアログ非表示バッチ印刷
        /// </summary>
        /// <returns></returns>
        private int BatchPrint( FrePprGrTr frePprGrTr )
        {
            return PrintProc( frePprGrTr, 3 );
        }
        #endregion

        #region 抽出条件キャッシュ更新処理
        /// <summary>
        /// 抽出条件のキャッシュ更新処理
        /// </summary>
        /// <returns></returns>
        private int UpdateFrePprECndLsCash()
        {
            FrePprGrTr frePprGrTr;
            List<FrePprECnd> frePprECndLs = new List<FrePprECnd>(); //検索条件

            try
            {
                //選択されている振替情報を取得
                if ( GetActiveFrePprGrTr( out frePprGrTr ) != 0 )
                {
                    return -1;
                }
                //未ダウンロードデータ
                if ( frePprGrTr.FileHeaderGuid == Guid.Empty )
                {
                    return -1;
                }

                //キャッシュからデータを戻す
                if ( _frePprECndLsHt.ContainsKey( Generate_FrePprGrTr_Key( frePprGrTr ) ) )
                {
                    frePprECndLs = (List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Key( frePprGrTr )];
                    //抽出条件取得(画面情報で上書き)
                    _extCdtForm.GetFrePprECndList( ref frePprECndLs );
                    //抽出条件をキャッシュに戻す
                    _frePprECndLsHt[Generate_FrePprGrTr_Key( frePprGrTr )] = frePprECndLs;
                }
                else
                {
                    return 4;
                }
            }
            catch ( Exception ex )
            {
                TMessageBox( emErrorLevel.ERR_LEVEL_STOP, ex.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                return -1;
            }
            return 0;

        }
        #endregion

        #region Name指定コントロール取得処理
        /// <summary>
        /// Name指定でコントロールを取得
        /// </summary>
        /// <param name="hParent"></param>
        /// <param name="stName"></param>
        /// <param name="findControl"></param>
        private void FindControl( Control hParent, string stName, ref Control findControl )
        {
            // hParent 内のすべてのコントロールを列挙する
            foreach ( Control hControl in hParent.Controls )
            {
                // 列挙したコントロールにコントロールが含まれている場合は再帰呼び出しする
                if ( hControl.HasChildren )
                {
                    Control hFindControl = null;
                    FindControl( hControl, stName, ref hFindControl );
                    // 再帰呼び出し先でコントロールが見つかった場合はそのまま返す
                    if ( hFindControl != null )
                    {
                        findControl = hFindControl;
                    }
                }

                // コントロール名が合致した場合はそのコントロールのインスタンスを返す
                if ( hControl.Name == stName )
                {
                    findControl = hControl;
                }
            }
            findControl = null;
        }
        #endregion

        // -- グループ制御系 ---------------------------

        #region DataSet構築処理
        private void DataSetColumnConstruction()
        {
            //-- 自由帳票グループ -------------------------------------
            DataTable freeStGrTable = new DataTable( CT_FREE_PPR_GR );
            // グループコード
            freeStGrTable.Columns.Add( CT_FREE_PPR_GrCd, typeof( Int32 ) );
            // グループ名称
            freeStGrTable.Columns.Add( CT_FREE_PPR_GrNm, typeof( string ) );
            // GUID
            freeStGrTable.Columns.Add( CT_FREE_PPR_GUID, typeof( Guid ) );
            // 更新日付
            freeStGrTable.Columns.Add( CT_FREE_PPR_UPDT, typeof( DateTime ) );
            // 作成日付
            freeStGrTable.Columns.Add( CT_FREE_PPR_CRDT, typeof( DateTime ) );
            //DataSetにAdd
            this._freeSheetGrDS.Tables.Add( freeStGrTable );

            //-- 自由帳票印刷対象(振替) ------------------------------------
            DataTable freeStPrtTable = new DataTable( CT_FREE_PPR_PRT );
            //グループコード
            freeStPrtTable.Columns.Add( CT_FREE_PPR_GrCd, typeof( Int32 ) );
            //表示順位 
            freeStPrtTable.Columns.Add( CT_FREE_PPR_DspOdr, typeof( Int32 ) );
            //振替コード
            freeStPrtTable.Columns.Add( CT_FREE_PPR_TrsCd, typeof( Int32 ) );
            //出力名称
            freeStPrtTable.Columns.Add( CT_FREE_PPR_PrtNm, typeof( string ) );
            //コメント
            freeStPrtTable.Columns.Add( CT_FREE_PPR_USRComment, typeof( string ) );
            //最終印刷日時
            freeStPrtTable.Columns.Add( CT_FREE_PPR_LstPrtDt, typeof( string ) );
            //ユーザー帳票ID枝番号 
            freeStPrtTable.Columns.Add( CT_FREE_PPR_DerivNo, typeof( Int32 ) );
            //出力ファイル名
            freeStPrtTable.Columns.Add( CT_FREE_PPR_OFrmFilNm, typeof( string ) );
            // GUID
            freeStPrtTable.Columns.Add( CT_FREE_PPR_GUID, typeof( Guid ) );
            // 更新日付
            freeStPrtTable.Columns.Add( CT_FREE_PPR_UPDT, typeof( DateTime ) );
            // 作成日付
            freeStPrtTable.Columns.Add( CT_FREE_PPR_CRDT, typeof( DateTime ) );
            //DataSetにAdd
            this._freeSheetPrtDS.Tables.Add( freeStPrtTable );
        }
        #endregion

        #region 自由帳票グループ登録処理
        private bool RegistFreePprGr( FreePprGrp frePprGrp )
        {
            string errMsg;

            // -- Aクラスを使って登録結果がOKならUI更新 ------------------------------ 
            int status = 0;
            status = this._frePprGrAcs.WriteFreePprGrp( ref frePprGrp, out errMsg );
            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int indexBuf = FreePprGr_Grid.ActiveRow.Index;
                        SetDataSource( 0 );
                        FreePprGr_Grid.Rows[indexBuf].Activate();
                        GroupFiltering( frePprGrp.FreePrtPprGroupCd );
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show( Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_INFO,
                            PGID, "このグループコードはすでに登録されています", status, MessageBoxButtons.OK );
                        return false;
                    }
                default:
                    {
                        if ( ExclusiveControl( status ) == false )
                        {
                            return false;
                        }
                        TMsgDisp.Show( this, Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
                            PGID, "自由帳票グループ登録", "RegistFreePprGr", TMsgDisp.OPE_UPDATE,
                            "登録に失敗しました。" + errMsg, status,
                            "SFANL08221A", MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                        return false;
                    }
            }
            return true;
        }
        #endregion

        #region 自由帳票グループ → DataSet
        /// <summary>
        /// 自由帳票グループ → データセット展開
        /// </summary>
        /// <param name="freePprGrp">自由帳票グループクラス</param>
        /// <param name="index">データセットインデックス</param>
        /// <remarks>
        /// <br>Note       : 自由帳票グループをデータセットへ展開します</br>
        /// <br>Programmer : 22011 柏原　頼人</br>
        /// <br>Date       : 2007.03.28</br>
        /// </remarks>
        private int FreePprGrToDataSet( FreePprGrp freePprGrp, int index )
        {
            DataTable freeShGrTable = this._freeSheetGrDS.Tables[CT_FREE_PPR_GR];

            // 新規として行追加する
            if ( (index < 0) || (freeShGrTable.Rows.Count <= index) )
            {
                // 新規として行追加する
                DataRow dataRow = freeShGrTable.NewRow();
                freeShGrTable.Rows.Add( dataRow );
                index = freeShGrTable.Rows.Count - 1;
            }
            freeShGrTable.Rows[index][CT_FREE_PPR_GrCd] = freePprGrp.FreePrtPprGroupCd;
            freeShGrTable.Rows[index][CT_FREE_PPR_GrNm] = freePprGrp.FreePrtPprGroupNm;
            freeShGrTable.Rows[index][CT_FREE_PPR_GUID] = freePprGrp.FileHeaderGuid;
            freeShGrTable.Rows[index][CT_FREE_PPR_UPDT] = freePprGrp.UpdateDateTime;
            freeShGrTable.Rows[index][CT_FREE_PPR_CRDT] = freePprGrp.CreateDateTime;
            return 0;
        }
        #endregion

        #region 自由帳票グループ削除処理
        private int DeleteFrePprGrp()
        {
            string errMsg;
            int index = 0;
            int status = 0;
            FreePprGrp frePprGrp = null;
            ArrayList frePprGrTrList;

            // アクティブ行のデータを取得
            status = GetActiveFrePprGrp( out frePprGrp, out index );
            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                return status;

            // 全グループだったらキャンセル
            if ( frePprGrp.FreePrtPprGroupCd == 0 )
            {
                TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_INFO,        // エラーレベル
                "SFANL08201UA", 						    // アセンブリＩＤまたはクラスＩＤ
                "全グループは削除できません", 		// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1 );   // 表示するボタン
                return status;
            }

            // 未ダウンロードの明細がないかチェック
            string msgPlus = string.Empty;
            foreach ( DataRowView dr in _freeSheetPrtDV )
            {
                if ( frePprGrp.FreePrtPprGroupCd == (int)dr[CT_FREE_PPR_GrCd] )
                    if ( (Guid)dr[CT_FREE_PPR_GUID] == Guid.Empty )
                    {
                        msgPlus = "未ダウンロードの印刷対象を含むグループを\n" + "削除しようとしています。\n\n";
                        break;
                    }
            }

            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								        // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION,         // エラーレベル
                "SFANL08201UA", 						    // アセンブリＩＤまたはクラスＩＤ
                msgPlus + "[" + frePprGrp.FreePrtPprGroupNm + "]を削除します。" + "\r\n" +
                "よろしいですか？", 				        // 表示するメッセージ
                0, 									        // ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2 );           // 表示するボタン

            if ( result == DialogResult.OK )
            {
                // 明細取得
                this._frePprGrAcs.SearchAllFreePprGrTr( out frePprGrTrList, LoginInfoAcquisition.EnterpriseCode, frePprGrp.FreePrtPprGroupCd );

                //自由帳票グループと関連するグループ振替を完全削除
                status = this._frePprGrAcs.DeleteFreePprGrpAndGrTr( frePprGrp, frePprGrTrList, out errMsg );
                switch ( status )
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            //最終印刷時間削除
                            _lastTimes.RemoveAll( delegate( LastPrtTime ptm ) { return (ptm.freePrtPprGroupCd == frePprGrp.FreePrtPprGroupCd); } );
                            //振替キャッシュ削除
                            _freePprGrpTrLs.RemoveAll( delegate( FrePprGrTr grtr )
                            {
                                if ( (grtr.FreePrtPprGroupCd == frePprGrp.FreePrtPprGroupCd) )
                                    return true;
                                else
                                    return false;
                            } );


                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveControl( status );
                            return status;
                        }
                    default:
                        {
                            // 物理削除
                            TMsgDisp.Show(
                                this, 								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                                "SFANL08201UA", 						    // アセンブリＩＤまたはクラスＩＤ
                                "自由帳票グループ設定", 			// プログラム名称
                                "DeleteFrePprGrp", 				    // 処理名称
                                TMsgDisp.OPE_DELETE, 				// オペレーション
                                "削除に失敗しました。" + errMsg, 		// 表示するメッセージ
                                status, 							// ステータス値
                                this._frePprGrAcs, 					// エラーが発生したオブジェクト
                                MessageBoxButtons.OK, 				// 表示するボタン
                                MessageBoxDefaultButton.Button1 );	// 初期表示ボタン

                            return status;
                        }
                }

                //データテーブルの更新
                this._freeSheetGrDS.Tables[CT_FREE_PPR_GR].DefaultView[index].Delete();

                //１行上のグループで再描画
                FreePprGr_Grid.Rows[index - 1].Activate();
                FrePPrGroupChange( (int)(this._freeSheetGrDS.Tables[CT_FREE_PPR_GR].DefaultView[index - 1].Row[CT_FREE_PPR_GrCd]) );
            }
            else
            {
                //削除ボタンにフォーカスすべき？
            }
            return (Int32)ConstantManagement.DB_Status.ctDB_NORMAL;

        }

        #endregion

        #region グリッド列概観設定
        private void SetGridColAppearance()
        {
            // 表示設定
            FreePprGr_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_GrCd].Hidden = false;
            FreePprGr_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_GrNm].Hidden = false;
            FreePprGr_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_GUID].Hidden = true;
            FreePprGr_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_UPDT].Hidden = true;
            FreePprGr_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_CRDT].Hidden = true;

            // 表示設定
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_GrCd].Hidden = true;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_DspOdr].Hidden = false;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_TrsCd].Hidden = true;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_PrtNm].Hidden = false;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_LstPrtDt].Hidden = false;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_USRComment].Hidden = false;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_DerivNo].Hidden = true;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_OFrmFilNm].Hidden = true;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_GUID].Hidden = true;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_UPDT].Hidden = true;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_CRDT].Hidden = true;
        }
        #endregion

        #region 選択中自由帳票グループの情報取得
        /// <summary>
        /// 選択されている自由帳票のグループコードを返します
        /// </summary>
        /// <returns>グループコード(未選択時は0を返す)</returns>
        private Int32 GetSelectedGrCode()
        {
            if ( FreePprGr_Grid.ActiveRow != null && FreePprGr_Grid.ActiveRow.Index >= 0 )
            {
                if ( _freeSheetGrDS.Tables[CT_FREE_PPR_GR].DefaultView[FreePprGr_Grid.ActiveRow.Index][CT_FREE_PPR_GrCd] != null )
                {
                    return (int)_freeSheetGrDS.Tables[CT_FREE_PPR_GR].DefaultView[FreePprGr_Grid.ActiveRow.ListIndex][CT_FREE_PPR_GrCd];
                }

            }
            return 0;
        }

        /// <summary>
        /// 現在選択されているグループの情報を取得します
        /// </summary>
        /// <param name="frePprGrp">自由帳票グループクラス</param>
        /// <param name="index">データセットのインデックス</param>
        /// <returns>ステータス</returns>
        private int GetActiveFrePprGrp( out FreePprGrp frePprGrp, out int index )
        {
            // 件数がゼロ件
            if ( FreePprGr_Grid.Rows.Count <= 0 )
            {
                frePprGrp = new FreePprGrp();
                index = -1;
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            frePprGrp = new FreePprGrp();

            //現在アクティブな行を取得
            index = FreePprGr_Grid.ActiveRow.Index;
            if ( index < 0 ) return -1;

            DataRowView newDr = _freeSheetGrDS.Tables[CT_FREE_PPR_GR].DefaultView[index];
            frePprGrp.FreePrtPprGroupCd = (Int32)newDr[CT_FREE_PPR_GrCd];
            frePprGrp.FreePrtPprGroupNm = (string)newDr[CT_FREE_PPR_GrNm];
            frePprGrp.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            frePprGrp.FileHeaderGuid = (Guid)newDr[CT_FREE_PPR_GUID];
            frePprGrp.UpdateDateTime = (DateTime)newDr[CT_FREE_PPR_UPDT];
            frePprGrp.CreateDateTime = (DateTime)newDr[CT_FREE_PPR_CRDT];
            return 0;
        }
        #endregion

        #region 自由帳票グループ → データセット展開
        /// <summary>
        /// 自由帳票グループ → データセット展開(新規登録専用)
        /// </summary>
        /// <param name="freePprGrp">自由帳票グループ</param>
        private int FreePprGrToDataSet( FreePprGrp freePprGrp )
        {
            return FreePprGrToDataSet( freePprGrp, -1 );
        }
        #endregion

        #region 全グループアクティベーティッド
        /// <summary>
        /// 自由帳票グループグリッドの全グループ行をアクティブ化
        /// </summary>
        private void AllFreePprGroupActivated()
        {
            if ( FreePprGr_Grid.Rows.Count > 0 )
            {
                FreePprGr_Grid.Rows[0].Activate();
            }
        }
        #endregion

        #region DataTableClear処理
        /// <summary>
        /// グリッド用データテーブルクリア
        /// </summary>
        private void ClearGroupDataTable()
        {
            this._freeSheetGrDS.Tables[CT_FREE_PPR_GR].Clear();
        }
        #endregion

        // -- 明細制御 ---------------------------------

        #region DataTableClear処理
        /// <summary>
        /// グリッド用DataTableクリア処理
        /// </summary>
        /// <returns></returns>
        public void ClearDataTable()
        {
            this._freeSheetPrtDS.Tables[CT_FREE_PPR_PRT].Clear();
        }
        #endregion

        #region 自由帳票グループ振替登録処理
        private bool RegistFreeShetGrTr( FrePprGrTr trgFrePprGrTr )
        {
            int status = 0;
            string errMsg;
            int indexBuf;

            // グループ内での重複チェック
            if ( trgFrePprGrTr.FreePrtPprGroupCd != 0 )
            {
                if ( trgFrePprGrTr.UpdateDateTime == DateTime.MinValue )  //新規の時のみ
                {
                    foreach ( FrePprGrTr grtr in _freePprGrpTrLs )
                    {
                        if ( grtr.FreePrtPprGroupCd == trgFrePprGrTr.FreePrtPprGroupCd )
                        {
                            if ( grtr.OutputFormFileName == trgFrePprGrTr.OutputFormFileName )
                            {
                                if ( grtr.UserPrtPprIdDerivNo == trgFrePprGrTr.UserPrtPprIdDerivNo )
                                {
                                    TMsgDisp.Show( Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_INFO,
                                    PGID, "[" + trgFrePprGrTr.DisplayName + "]はすでにグループ内に登録されています", status, MessageBoxButtons.OK );
                                    _maintenanceDlg.FrePprSelect_Grid.Focus();
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            status = this._frePprGrAcs.WriteFrePprGrTr( ref trgFrePprGrTr, out errMsg );
            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if ( FreePprPrt_Grid.Rows.Count > 0 )
                            indexBuf = FreePprPrt_Grid.ActiveRow.Index;
                        else
                            indexBuf = 0;
                        SetDataSource( 2 );

                        //抽出条件、ソート順のキャッシュを作成
                        List<FrePprECnd> frePprECndLs = new List<FrePprECnd>();
                        List<FrePprSrtO> frePprSrtOLs = new List<FrePprSrtO>();
                        FrePprECnd[] frePprECnds = new FrePprECnd[((List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Init_Key( trgFrePprGrTr )]).Count];
                        FrePprSrtO[] frePprSrtOs = new FrePprSrtO[((List<FrePprSrtO>)_frePprSrtOLsHT[Generate_FrePprGrTr_Init_Key( trgFrePprGrTr )]).Count];

                        ((List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Init_Key( trgFrePprGrTr )]).CopyTo( frePprECnds );
                        ((List<FrePprSrtO>)_frePprSrtOLsHT[Generate_FrePprGrTr_Init_Key( trgFrePprGrTr )]).CopyTo( frePprSrtOs );
                        foreach ( FrePprECnd frePprECnd in frePprECnds )
                        {
                            FrePprECnd ecnd = (FrePprECnd)DBAndXMLDataMergeParts.CopyPropertyInClass( frePprECnd, typeof( FrePprECnd ) );
                            frePprECndLs.Add( ecnd );
                        }
                        foreach ( FrePprSrtO frePprSrtO in frePprSrtOs )
                        {
                            FrePprSrtO srtO = (FrePprSrtO)DBAndXMLDataMergeParts.CopyPropertyInClass( frePprSrtO, typeof( FrePprSrtO ) );
                            frePprSrtOLs.Add( srtO );
                        }
                        _frePprECndLsHt[Generate_FrePprGrTr_Key( trgFrePprGrTr )] = frePprECndLs;
                        _frePprSrtOLsHT[Generate_FrePprGrTr_Key( trgFrePprGrTr )] = frePprSrtOLs;

                        FreePprPrt_Grid.Rows[indexBuf].Activate();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show( Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_INFO,
                            PGID, "[" + trgFrePprGrTr.DisplayName + "]はすでに登録されています", status, MessageBoxButtons.OK );
                        return false;
                    }
                default:
                    {
                        if ( ExclusiveControl( status ) == false )
                        {
                            return false;
                        }
                        TMsgDisp.Show( this, Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
                            PGID, "自由帳票グループ振替登録", "RegistFreeShetGrTr", TMsgDisp.OPE_UPDATE,
                            "登録に失敗しました。" + errMsg, status,
                            "SFANL08221A", MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                        return false;
                    }
            }
            return true;
        }
        #endregion

        #region 自由帳票グループ振替情報削除処理
        private void DeleteFrePprGrTrData()
        {
            int status = 0;
            int index = 0;
            FrePprGrTr frePprGrTr = null;
            string errMsg;

            status = GetActiveFrePprGrTr( out frePprGrTr, out index );
            if ( status != 0 ) return;

            // 全グループだったらキャンセル
            if ( frePprGrTr.FreePrtPprGroupCd == 0 )
            {
                TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_INFO,        // エラーレベル
                "SFANL08201U", 						    // アセンブリＩＤまたはクラスＩＤ
                "全グループの印刷対象は削除できません", // 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1 );   // 表示するボタン
                return;
            }
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								    // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                "SFANL08201U", 						        // アセンブリＩＤまたはクラスＩＤ
                "[" + frePprGrTr.DisplayName + "]を印刷対象から削除します。" + "\r\n" +
                "よろしいですか？", 				    // 表示するメッセージ
                0, 									    // ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2 );		// 表示するボタン

            if ( result == DialogResult.OK )
            {
                status = this._frePprGrAcs.DeleteFrePprGrTr( ref frePprGrTr, out errMsg );
                switch ( status )
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            //最終印刷日時も削除
                            LastPrtTime lastTime = _lastPrtTimeAcs.FindLastPrtTime( _lastTimes, frePprGrTr );
                            if ( lastTime != null )
                            {
                                _lastTimes.Remove( lastTime );
                            }
                            //振替キャッシュ削除
                            _freePprGrpTrLs.RemoveAll( delegate( FrePprGrTr grtr )
                            {
                                if ( (grtr.FreePrtPprGroupCd == frePprGrTr.FreePrtPprGroupCd) && (grtr.TransferCode == frePprGrTr.TransferCode) )
                                    return true;
                                else
                                    return false;
                            } );

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveControl( status );
                            return;
                        }
                    default:
                        {
                            // 物理削除
                            TMsgDisp.Show(
                                this, 								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                                "SFTKD09060U", 						// アセンブリＩＤまたはクラスＩＤ
                                "自由帳票グループ振替設定", 		// プログラム名称
                                "DeleteFrePprGrTrData", 		    // 処理名称
                                TMsgDisp.OPE_DELETE, 				// オペレーション
                                "削除に失敗しました。" + errMsg, 		// 表示するメッセージ
                                status, 							// ステータス値
                                this._frePprGrAcs, 					// エラーが発生したオブジェクト
                                MessageBoxButtons.OK, 				// 表示するボタン
                                MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
                            return;
                        }
                }
                // （明細）削除後は、フレームにデータを反映させる
                _freeSheetPrtDV.Delete( index );
                //削除により、行が全てなくなったら条件画面再構築
                if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
                {
                    SetExtraCnditionFrom();
                }
                else
                {
                    FreePprPrt_Grid.Rows[0].Activate();
                }
            }
            else
            {
                //削除ボタンにフォーカスすべき？
            }
        }
        #endregion

        #region グリッドフィルタリング
        /// <summary>
        /// 明細グリッドを引数のグループコードでフィルタリングします
        /// </summary>
        /// <param name="groupCD">グループコード</param>
        private void GroupFiltering( int groupCD )
        {
            string filter;
            filter = CT_FREE_PPR_GrCd + " = " + groupCD.ToString();
            this._freeSheetPrtDV.RowFilter = filter;

            //ダイアログのグループコードも更新
            _maintenanceDlg.GroupCode = groupCD;
        }
        #endregion

        #region 明細グリッドアクティベート
        /// <summary>
        /// 明細グリッドにアクティブ行を設定します
        /// </summary>
        /// <returns>status</returns>
        private int GridActivate()
        {
            if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
            {
                return -1;
            }
            else
                FreePprPrt_Grid.Rows.FirstVisibleCardRow.Activate();
            return 0;
        }

        /// <summary>
        /// 明細グリッドにアクティブ行を設定します(グループコード、振替コード指定)
        /// </summary>
        /// <param name="groupCd">自由帳票グループコード</param>
        /// <param name="tranceCd">自由帳票グループ振替コード</param>
        /// <returns>status</returns>
        private int GridActivate( int groupCd, int tranceCd )
        {
            int index = 0;

            if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
            {
                return -1;
            }

            foreach ( DataRowView dr in _freeSheetPrtDV )
            {
                if ( groupCd == (int)dr[CT_FREE_PPR_GrCd] )
                    if ( tranceCd == (int)dr[CT_FREE_PPR_TrsCd] )
                    {
                        //選択行を解除
                        //foreach (UltraGridRow ugRow in FreePprPrt_Grid.Selected.Rows)
                        //{
                        //    ugRow.Selected = false;
                        //}
                        //指定された行をアクティベート
                        FreePprPrt_Grid.Rows[index].Activate();
                        return 0;
                    }
                index++;
            }
            return 0;
        }
        #endregion

        #region 振替情報取得
        /// <summary>
        /// 現在選択されている明細の情報を取得します
        /// </summary>
        /// <param name="frePprGrTr">自由帳票グループ振替クラス</param>
        /// <param name="index">データセットのインデックス</param>
        /// <returns>ステータス(0:正常取得 その他:失敗)</returns>
        private int GetActiveFrePprGrTr( out FrePprGrTr frePprGrTr, out int index )
        {
            // 件数がゼロ件
            if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
            {
                frePprGrTr = new FrePprGrTr();
                index = -1;
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            frePprGrTr = new FrePprGrTr();

            try
            {
                //現在アクティブな行を取得
                index = FreePprPrt_Grid.ActiveRow.Index;
                DataRow newDr = _freeSheetPrtDV[index].Row;
                if ( newDr == null ) return -1;

                frePprGrTr.FreePrtPprGroupCd = (Int32)newDr[CT_FREE_PPR_GrCd];
                frePprGrTr.DisplayOrder = (Int32)newDr[CT_FREE_PPR_DspOdr];
                frePprGrTr.TransferCode = (Int32)newDr[CT_FREE_PPR_TrsCd];
                if ( newDr[CT_FREE_PPR_PrtNm] != DBNull.Value )
                    frePprGrTr.DisplayName = (string)newDr[CT_FREE_PPR_PrtNm];
                else
                    frePprGrTr.DisplayName = "";
                if ( newDr[CT_FREE_PPR_USRComment] != DBNull.Value )
                    frePprGrTr.PrtPprUserDerivNoCmt = (string)newDr[CT_FREE_PPR_USRComment];
                else
                    frePprGrTr.PrtPprUserDerivNoCmt = "";
                frePprGrTr.UserPrtPprIdDerivNo = (Int32)newDr[CT_FREE_PPR_DerivNo];
                if ( newDr[CT_FREE_PPR_OFrmFilNm] != DBNull.Value )
                    frePprGrTr.OutputFormFileName = (string)newDr[CT_FREE_PPR_OFrmFilNm];
                else
                    frePprGrTr.OutputFormFileName = "";
                frePprGrTr.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                frePprGrTr.FileHeaderGuid = (Guid)newDr[CT_FREE_PPR_GUID];
                frePprGrTr.UpdateDateTime = (DateTime)newDr[CT_FREE_PPR_UPDT];
                frePprGrTr.CreateDateTime = (DateTime)newDr[CT_FREE_PPR_CRDT];
            }
            catch
            {
                index = -1;
                return -1;
            }
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// 現在選択されている明細の情報を取得します
        /// </summary>
        /// <param name="frePprGrTr">自由帳票グループ振替クラス</param>
        /// <returns>ステータス</returns>
        private int GetActiveFrePprGrTr( out FrePprGrTr frePprGrTr )
        {
            int indexdmy = 0;
            return GetActiveFrePprGrTr( out frePprGrTr, out indexdmy );
        }

        /// <summary>
        /// 現在選択されているグループの全明細情報を取得します
        /// </summary>
        /// <param name="frePprGrTr">自由帳票グループ振替クラスの配列</param>
        /// <param name="groupCD">自由帳票グループコード</param>
        /// <returns>ステータス</returns>
        private int GetGroupFrePprGrTr( out FrePprGrTr[] frePprGrTr, Int32 groupCD )
        {
            // 件数がゼロ件
            if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
            {
                frePprGrTr = null;
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            frePprGrTr = new FrePprGrTr[FreePprPrt_Grid.Rows.FilteredInRowCount];
            Int32 index = 0;

            //現在アクティブな行を取得
            foreach ( DataRowView newDrV in _freeSheetPrtDV )
            {
                if ( (Int32)newDrV.Row[CT_FREE_PPR_GrCd] == groupCD )
                {
                    frePprGrTr[index] = new FrePprGrTr();
                    frePprGrTr[index].FreePrtPprGroupCd = (Int32)newDrV.Row[CT_FREE_PPR_GrCd];
                    frePprGrTr[index].DisplayOrder = (Int32)newDrV.Row[CT_FREE_PPR_DspOdr];
                    frePprGrTr[index].TransferCode = (Int32)newDrV.Row[CT_FREE_PPR_TrsCd];
                    frePprGrTr[index].DisplayName = (string)newDrV.Row[CT_FREE_PPR_PrtNm];
                    frePprGrTr[index].PrtPprUserDerivNoCmt = (string)newDrV.Row[CT_FREE_PPR_USRComment];
                    frePprGrTr[index].UserPrtPprIdDerivNo = (Int32)newDrV.Row[CT_FREE_PPR_DerivNo];
                    frePprGrTr[index].OutputFormFileName = (string)newDrV.Row[CT_FREE_PPR_OFrmFilNm];
                    frePprGrTr[index].EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    frePprGrTr[index].FileHeaderGuid = (Guid)newDrV.Row[CT_FREE_PPR_GUID];
                    frePprGrTr[index].UpdateDateTime = (DateTime)newDrV.Row[CT_FREE_PPR_UPDT];
                    frePprGrTr[index].CreateDateTime = (DateTime)newDrV.Row[CT_FREE_PPR_CRDT];
                    index++;
                }
            }
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        #endregion

        #region 自由帳票グループ → データセット展開処理
        #region 自由帳票印刷対象 → DataSet
        /// <summary>
        /// 自由帳票グループ振替 → データセット展開
        /// </summary>
        /// <param name="frePprGrTr">自由帳票グループ振替クラス</param>
        /// <param name="index">データセットインデックス</param>
        /// <param name="lastPrtDate">最終印刷日時</param>
        /// <remarks>
        /// <br>Note       : 自由帳票グループ振替をデータセットへ展開します</br>
        /// <br>Programmer : 22011 柏原　頼人</br>
        /// <br>Date       : 2007.03.28</br>
        /// </remarks>
        private int FreeSeetPrtToDataSet( FrePprGrTr frePprGrTr, Int32 index, DateTime lastPrtDate )
        {
            DataTable freeShPrtTable = this._freeSheetPrtDS.Tables[CT_FREE_PPR_PRT];

            // 新規として行追加する
            if ( (index < 0) || (freeShPrtTable.Rows.Count <= index) )
            {
                // 新規として行追加する
                DataRow dataRow = freeShPrtTable.NewRow();
                freeShPrtTable.Rows.Add( dataRow );
                index = freeShPrtTable.Rows.Count - 1;
            }

            freeShPrtTable.Rows[index][CT_FREE_PPR_GrCd] = frePprGrTr.FreePrtPprGroupCd;
            freeShPrtTable.Rows[index][CT_FREE_PPR_DspOdr] = frePprGrTr.DisplayOrder;
            freeShPrtTable.Rows[index][CT_FREE_PPR_TrsCd] = frePprGrTr.TransferCode;
            freeShPrtTable.Rows[index][CT_FREE_PPR_PrtNm] = frePprGrTr.DisplayName;
            if ( lastPrtDate != DateTime.MinValue )
                freeShPrtTable.Rows[index][CT_FREE_PPR_LstPrtDt] = lastPrtDate.ToString();
            freeShPrtTable.Rows[index][CT_FREE_PPR_USRComment] = frePprGrTr.PrtPprUserDerivNoCmt;
            freeShPrtTable.Rows[index][CT_FREE_PPR_DerivNo] = frePprGrTr.UserPrtPprIdDerivNo;
            freeShPrtTable.Rows[index][CT_FREE_PPR_OFrmFilNm] = frePprGrTr.OutputFormFileName;
            freeShPrtTable.Rows[index][CT_FREE_PPR_GUID] = frePprGrTr.FileHeaderGuid;
            freeShPrtTable.Rows[index][CT_FREE_PPR_UPDT] = frePprGrTr.UpdateDateTime;
            freeShPrtTable.Rows[index][CT_FREE_PPR_CRDT] = frePprGrTr.CreateDateTime;

            return 0;
        }
        #endregion


        /// <summary>
        /// 明細グリッドにアクティブ行を設定します(グループコード、振替コード指定)
        /// </summary>
        /// <param name="groupCd">自由帳票グループコード</param>
        /// <param name="tranceCd">自由帳票グループ振替コード</param>
        /// <param name="prtDate">自由帳票</param>
        /// <returns>status</returns>
        private int SetPrtTime( int groupCd, int tranceCd, DateTime prtDate )
        {
            if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
            {
                return -1;
            }


            foreach ( DataRowView dr in _freeSheetPrtDV )
            {
                if ( groupCd == (int)dr[CT_FREE_PPR_GrCd] )
                    if ( tranceCd == (int)dr[CT_FREE_PPR_TrsCd] )
                    {
                        //指定された行をアクティベート
                        dr[CT_FREE_PPR_LstPrtDt] = prtDate.ToString();
                        return 0;
                    }
            }
            return 0;
        }


        /// <summary>
        /// 自由帳票グループ振替 → データセット展開(新規登録用)
        /// </summary>
        /// <param name="frePprGrTr">自由帳票グループ振替クラス</param>
        /// <param name="lastPrtDate">最終印刷日時</param>
        private int FreeSeetPrtToDataSet( FrePprGrTr frePprGrTr, DateTime lastPrtDate )
        {
            return FreeSeetPrtToDataSet( frePprGrTr, -1, lastPrtDate );
        }

        /// <summary>
        /// 自由帳票グループ振替 → データセット展開(新規登録用)
        /// </summary>
        /// <param name="frePprGrTr">自由帳票グループ振替クラス</param>
        private int FreeSeetPrtToDataSet( FrePprGrTr frePprGrTr )
        {
            return FreeSeetPrtToDataSet( frePprGrTr, -1, new DateTime() );
        }


        #region 1行目をアクティブにします
        /// <summary>
        /// 1行目をアクティブ化
        /// </summary>
        public void FirstRowActivated()
        {
            if ( FreePprPrt_Grid.Rows.Count > 0 )
            {
                FreePprPrt_Grid.Rows[0].Activate();
            }
        }
        #endregion

        #endregion

        #endregion

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        #region Control Event
        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 画面がロードされた際、発生するイベントです。</br>
        /// <br>Programmer  : 22011 Kashihara</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void SFANL08201UA_Load( object sender, System.EventArgs e )
        {
            // 画面初期表示
            this.InitialScreenSetting();

            //印字位置データがないとき:メッセージ表示後終了
            if ( _frePrtPSetLs.Count <= 0 )
            {
                this.Visible = false;
                throw new FreeSheetStartCancelException( "この端末に帳票の印字位置情報がありません\n印字位置情報のダウンロードが必要です" );
            }
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Print_Button_Click( object sender, EventArgs e )
        {
            FrePprGrTr frePprGrTr = null;
            GetActiveFrePprGrTr( out frePprGrTr );
            Print( frePprGrTr );　// 印刷
        }

        /// <summary>
        /// ソート順変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderCng_Button_Click( object sender, EventArgs e )
        {
            //ソート順位設定フォーム起動
            SetSortOrderForm();
        }



        /// <summary>
        /// フォーム終了時に発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFANL08201UA_FormClosing( object sender, FormClosingEventArgs e )
        {
            //最終印刷日時を書き出す
            _lastPrtTimeAcs.Write( _lastTimes );

            if ( _maintenanceDlg != null )
            {
                _maintenanceDlg.CanClose = true;
                _maintenanceDlg.Dispose();
            }
        }

        /// <summary>
        /// グループのツールバークリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupToolbarsManager_ToolClick( object sender, ToolClickEventArgs e )
        {
            if ( e.Tool.Key == CT_ROW_ADD )
            {
                _maintenanceDlg.ShowGroupDlg();
            }
            else if ( e.Tool.Key == CT_ROW_DELETE )
            {
                DeleteFrePprGrp();
            }
        }

        /// <summary>
        /// グループグリッドのロウをダブルクリックしたときに発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePprGr_Grid_DoubleClickRow( object sender, DoubleClickRowEventArgs e )
        {
            if ( Convert.ToInt32( e.Row.Cells[CT_FREE_PPR_GrCd].Value ) == 0 )
            {   //全グループなら
                TMsgDisp.Show( Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_INFO,
                PGID, "全グループは変更できません", 0, MessageBoxButtons.OK );
            }
            else
            {
                int index;
                FreePprGrp frepprgr = new FreePprGrp();
                GetActiveFrePprGrp( out frepprgr, out index );
                _maintenanceDlg.ShowGroupDlg( frepprgr.FreePrtPprGroupCd, frepprgr.FreePrtPprGroupNm, frepprgr.UpdateDateTime, frepprgr.CreateDateTime, frepprgr.FileHeaderGuid );
            }
        }

        /// <summary>
        /// 自由帳票グループグリッド選択変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePprGr_Grid_AfterSelectChange( object sender, AfterSelectChangeEventArgs e )
        {
            FrePPrGroupChange( GetSelectedGrCode() );
        }

        /// <summary>
        /// 明細アクティベート時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePprPrt_Grid_AfterRowActivate( object sender, EventArgs e )
        {
            SetExtraCnditionFrom();

            //アクティブカラーの変更
            UltraGrid grid = (UltraGrid)sender;
            if ( (Guid)(grid.ActiveRow.Cells[CT_FREE_PPR_GUID].Value) == Guid.Empty )
            {   // 未ダウンロード
                grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Red;
            }
            else
            {   // 通常
                grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
            }
            grid.ActiveRow.Selected = true;
        }

        /// <summary>
        /// 明細行が非アクティブになる前に発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePprPrt_Grid_BeforeRowDeactivate( object sender, CancelEventArgs e )
        {
            UpdateFrePprECndLsCash();
        }

        /// <summary>
        /// グループ行が非アクティブになる前に発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePprGr_Grid_BeforeRowDeactivate( object sender, CancelEventArgs e )
        {
            UpdateFrePprECndLsCash();
        }

        /// <summary>
        /// 明細のロウをダブルクリックしたときに発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePprPrt_Grid_DoubleClickRow( object sender, DoubleClickRowEventArgs e )
        {
            if ( (Guid)(e.Row.Cells[CT_FREE_PPR_GUID].Value) != Guid.Empty )
            {   // 未ダウンロードでなければ
                FrePprGrTr wk = new FrePprGrTr();
                if ( GetActiveFrePprGrTr( out wk ) != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                {
                    _maintenanceDlg.ShowTranceDlg( wk.FreePrtPprGroupCd, wk.TransferCode, wk.DisplayOrder, wk.OutputFormFileName, wk.UserPrtPprIdDerivNo, wk.UpdateDateTime, wk.CreateDateTime, wk.FileHeaderGuid );
                }
            }
            else
            {
                TMsgDisp.Show( Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_INFO,
                PGID, "未ダウンロードの印刷対象は変更できません", 0, MessageBoxButtons.OK );
            }
        }

        /// <summary>
        /// 行が初期化されたときに発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePprPrt_Grid_InitializeRow( object sender, InitializeRowEventArgs e )
        {
            if ( (Guid)(e.Row.Cells[CT_FREE_PPR_GUID].Value) == Guid.Empty )
            {   // 未ダウンロード
                e.Row.CellAppearance.ForeColor = Color.Red;
            }
            else
            {   // 通常
                e.Row.CellAppearance.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailToolbarsManager_ToolClick( object sender, ToolClickEventArgs e )
        {
            if ( e.Tool.Key == CT_ROW_ADD )
            {
                _maintenanceDlg.ShowTranceDlg();
            }
            if ( e.Tool.Key == CT_ROW_DELETE )
            {
                DeleteFrePprGrTrData();
            }
        }
        #endregion

        //=========================================================================================
        #region IFreePprMainFrame メンバ

        /// <summary>クローズ許可プロパティ</summary>
        /// <value>画面を終了してよい場合はTrue、問題がある場合はFalseを返します</value>
        public bool CanClose
        {
            get { return true; }
        }

        /// <summary>
        /// ツールバークリックイベント（メインフレーム）
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        public void FrameToolbars_ToolClick( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
        {
            if ( e.Tool.Key == CT_PRINT_BUTTONTOOL )
            {
                // メンテナンス中は印刷をキャンセル
                if ( _maintenanceDlg.Visible == true ) return;

                int status = 0;
                FrePprGrTr[] frePprGrTrs;    //印刷時用振替マスタ

                // 印刷対象がなければメッセージを表示して終了
                if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
                {
                    TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, "印刷対象がありません", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                    return;
                }

                //プリンタ選択
                string groupNm = (string)_freeSheetGrDS.Tables[CT_FREE_PPR_GR].Rows[FreePprGr_Grid.ActiveRow.Index][CT_FREE_PPR_GrNm];
                if ( DialogResult.Cancel == _printDialog.PinrterSelectDlgShow( this, groupNm ) ) return;

                // 2008.03.18 ADD ====================================== START
                //抽出条件明細を取得
                if ( _frePprECndDLs == null )
                {
                    FrePrtPSetAcs frePExCndDAcs = new FrePrtPSetAcs();
                    frePExCndDAcs.SearchFrePExCndDList( _enterpriseCode, out _frePprECndDLs );
                }
                // 2008.03.18 ADD ====================================== END

                status = GetGroupFrePprGrTr( out frePprGrTrs, GetSelectedGrCode() );
                if ( status == (Int32)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // 共通処理中画面生成
                    Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();

                    // 共通処理中画面プロパティ設定
                    form.Title = ctPRINT_TITLE;           // 画面のタイトル部分に表示する文字列
                    form.Message = ctPRINT_MESSAGE;       // 画面のプログレスバーの上に表示する文字列
                    form.DispCancelButton = true;        // キャンセルボタン押下による中断機能ＯＮ（デフォルトはＯＦＦ）

                    // 共通処理中画面表示
                    form.Show( this );
                    StringBuilder messageSb = new StringBuilder();
                    bool msgDiv = true;

                    try
                    {
                        List<FrePprECnd> frePprECndLs;          //抽出条件リスト
                        int errIndex;                           //抽出条件チェックでエラーが発生した条件のインデックス
                        string errMsg;                         //エラーメッセージ
                        Control errCtl = null;                 //エラーコントロール

                        //抽出条件キャッシュ更新
                        UpdateFrePprECndLsCash();

                        //抽出条件一括チェック
                        foreach ( FrePprGrTr frePprGrTr in frePprGrTrs )
                        {
                            // 未ダウンロード
                            if ( frePprGrTr.FileHeaderGuid == Guid.Empty )
                                continue;

                            frePprECndLs = new List<FrePprECnd>();
                            if ( _frePprECndLsHt.ContainsKey( Generate_FrePprGrTr_Key( frePprGrTr ) ) )
                            {
                                frePprECndLs = (List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Key( frePprGrTr )];
                            }

                            //条件の入力チェック
                            if ( !SFANL08132CA.InputCheck( frePprECndLs, true, out errMsg, out errIndex ) )
                            {
                                GridActivate( frePprGrTr.FreePrtPprGroupCd, frePprGrTr.TransferCode );    //明細行をエラー行に変更

                                //条件の入力チェック
                                if ( !_extCdtForm.InputCheck( frePprECndLs, out errMsg, out errCtl, true ) )
                                {
                                    TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                                    msgDiv = false;
                                    errCtl.Focus();
                                    return;
                                }
                            }
                            //ｸﾞﾙｰﾌﾟ毎の個別ﾁｪｯｸ 2008.03.18 ADD ======================== START
                            //FrePrtPSet frePrtPSet = null;                           //印刷用印字位置情報クラス
                            ////印字位置クラス取得
                            //frePrtPSet = GetFrePrtPSetCash(frePprGrTr.OutputFormFileName, frePprGrTr.UserPrtPprIdDerivNo);
                            //switch (frePrtPSet.PrintPaperDivCd)
                            //{
                            //    case 1: //日次帳票
                            //        {
                            if ( SFANL08235CH.Check_ECnd_DaillyReport( frePprECndLs, out errMsg ) != 0 )
                            {
                                GridActivate( frePprGrTr.FreePrtPprGroupCd, frePprGrTr.TransferCode );    //明細行をエラー行に変更
                                TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, "[ " + frePprGrTr.DisplayName + " ]\n" + errMsg, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                                msgDiv = false;
                                return;
                            }
                            //           break;
                            //        }
                            //}
                            //ｸﾞﾙｰﾌﾟ毎の個別ﾁｪｯｸ 2008.03.18 ADD ======================== END
                        }

                        //バッチ印刷
                        int prtCnt = 0;
                        foreach ( FrePprGrTr frePprGrTr in frePprGrTrs )
                        {
                            prtCnt++;
                            form.Message = ctPRINT_MESSAGE + "(" + prtCnt.ToString() + " / " + frePprGrTrs.Length.ToString() + ")";
                            try
                            {
                                // 未ダウンロード
                                if ( frePprGrTr.FileHeaderGuid == Guid.Empty )
                                {
                                    continue;
                                }
                                // キャンセルボタンが押下された場合の処理（form.DispCancelButtonプロパティがtrueの時のみ）
                                if ( form.IsCanceled )
                                {
                                    messageSb.Append( "一括印刷がユーザー割込みにより中断されました\n" );
                                    break;
                                }
                                status = BatchPrint( frePprGrTr );
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                                {
                                    messageSb.Append( frePprGrTr.DisplayName + "の印字位置データがありません\n" );
                                }
                                else if ( status == (int)ConstantManagement.DB_Status.ctDB_EOF )
                                {
                                    messageSb.Append( frePprGrTr.DisplayName + "は該当データがありませんでした\n" );
                                }
                            }
                            catch ( Exception ex )
                            {
                                messageSb.Append( frePprGrTr.DisplayName + "の印刷に失敗しました\n" );
                                messageSb.Append( "詳細:" + ex.Message );
                            }
                        }
                    }
                    finally
                    {
                        form.Close();
                        if ( msgDiv )
                        {
                            if ( messageSb.Length != 0 )
                            {
                                TMessageBox( emErrorLevel.ERR_LEVEL_INFO, messageSb.ToString(), 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                            }
                            else
                            {
                                TMessageBox( emErrorLevel.ERR_LEVEL_INFO, "一括印刷処理が正常に終了しました", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ドック情報取得処理
        /// </summary>
        /// <param name="dockAreaPaneArray">ドック情報のコレクション</param>
        /// <returns>ステータス</returns>
        public int GetDockAreaInfo( out DockAreaPane[] dockAreaPaneArray )
        {
            dockAreaPaneArray = null;
            return 4;
        }

        /// <summary>
        /// ツールバー情報取得処理
        /// </summary>
        /// <param name="ultraToolbarArray">ツールバーの配列</param>
        /// <returns>ステータス</returns>
        public int GetToolBarInfo( out UltraToolbar[] ultraToolbarArray )
        {
            ultraToolbarArray = null;
            return 4;
        }

        /// <summary>
        /// ツールバー情報取得処理
        /// </summary>
        /// <param name="rootToolsCollection">ツールバーコレクション</param>
        /// <param name="toolbarsCollection"></param>
        /// <returns>ステータス</returns>
        public int SetToolBarInfo( ref RootToolsCollection rootToolsCollection, ref ToolbarsCollection toolbarsCollection )
        {
            // ダウンロード開始ボタンの追加
            ButtonTool printButtonTool = new ButtonTool( CT_PRINT_BUTTONTOOL );
            printButtonTool.SharedProps.Caption = "一括印刷(&A)";
            printButtonTool.SharedProps.AppearancesSmall.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.PRINT];
            rootToolsCollection.Add( printButtonTool );
            toolbarsCollection[FreeSheetConst.ctToolBar_Main].Tools.AddTool( CT_PRINT_BUTTONTOOL );
            toolbarsCollection[FreeSheetConst.ctToolBar_Main].Tools[CT_PRINT_BUTTONTOOL].InstanceProps.IsFirstInGroup = true;
            PopupMenuTool fileMenuTool = (PopupMenuTool)rootToolsCollection[FreeSheetConst.ctPopupMenu_File];
            fileMenuTool.Tools.AddTool( CT_PRINT_BUTTONTOOL );

            return 0;
        }

        /// <summary>
        /// ツールボタン表示制御通知イベント
        /// </summary>
        public event ToolButtonDisplayControlEventHandler ToolButtonVisibleChanged;

        /// <summary>
        /// ツールボタン入力制御通知イベント
        /// </summary>
        public event ToolButtonDisplayControlEventHandler ToolButtonEnableChanged;

        #endregion

        #region 拠点制御
        /// <summary>
        /// 拠点変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Section_UTree_AfterCheck( object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e )
        {

            if ( this._secNodeCheckEvent ) return;

            // イベント中フラグON
            this._secNodeCheckEvent = true;

            try
            {
                Infragistics.Win.UltraWinTree.UltraTreeNode utnAll =
                    this.Section_UTree.GetNodeByKey( CT_AllSectionCode );

                _selectSecCds.Clear();

                // ”全社”指定された
                if ( e.TreeNode.Key.ToString().Equals( CT_AllSectionCode ) )
                {
                    // 選択
                    if ( utnAll != null )
                    {
                        if ( utnAll.CheckedState == CheckState.Checked )
                        {
                            // その他の項目のチェックをはずす
                            foreach ( Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes )
                            {
                                if ( !utn.Key.Equals( CT_AllSectionCode ) )
                                {
                                    utn.CheckedState = CheckState.Unchecked;
                                }
                            }
                        }
                        _allSectionDiv = true;
                    }
                }
                else
                {
                    // その他拠点
                    if ( utnAll != null )
                    {
                        if ( utnAll.CheckedState == CheckState.Checked )
                        {
                            utnAll.CheckedState = CheckState.Unchecked;

                            //if (target != null)
                            //{
                            //    target.CheckedSection(utnAll.Key.ToString(), CheckState.Unchecked);
                            //}

                        }
                    }
                    foreach ( Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes )
                    {
                        if ( utn.CheckedState == CheckState.Checked )
                        {
                            _selectSecCds.Add( utn.Key.ToString() );
                        }
                    }
                    _allSectionDiv = false;
                }
                //if (target != null)
                //{
                //    target.CheckedSection(e.TreeNode.Key.ToString(), e.TreeNode.CheckedState);
                //}
                // 選択されている拠点情報を保存

                //全てのチェックが外されたらメッセージをだしてデフォルト値をセット
                int cnt = 0;
                foreach ( Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes )
                {
                    if ( utn.CheckedState == CheckState.Checked )
                    {
                        cnt++;
                    }
                }
                if ( cnt < 1 )
                {
                    TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, "出力対象拠点は必ず一つはチェックしてください", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                    // デフォルトチェックはログイン拠点
                    this.Section_UTree.Nodes[this._loginSectionCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Checked;
                }
            }
            finally
            {
                e.TreeNode.Selected = true;
                this._secNodeCheckEvent = false;
            }
        }

        /// <summary>
        /// 計上拠点種別変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUpCd_UOptionSet_ValueChanged( object sender, EventArgs e )
        {
            _printInfo.sectionKindCd = ((Infragistics.Win.UltraWinEditors.UltraOptionSet)sender).CheckedIndex + 1;

            // デフォルトチェックはログイン拠点
            if ( this.Section_UTree.Nodes.Count > 0 )
                this.Section_UTree.Nodes[this._loginSectionCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Checked;

            //ログイン拠点以外はチェックを外す
            foreach ( Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes )
            {
                if ( utn.Key != this._loginSectionCode.TrimEnd() )
                {
                    utn.CheckedState = CheckState.Unchecked;
                }
            }


        }

        private void tArrowKeyControl1_ChangeFocus( object sender, ChangeFocusEventArgs e )
        {
            //Control senderCtl;

            if ( e.Key == Keys.Enter )
            {
            }
            if ( e.Key == Keys.Up )
            {
                //　印刷ボタン　→　グループ
                if ( e.PrevCtrl == Print_Button )
                {
                    e.NextCtrl = null;
                    this.FreePprGr_Grid.Focus();
                    return;
                }
                //　ソートボタン　→　グループ
                if ( e.PrevCtrl == OrderCng_Button )
                {
                    e.NextCtrl = null;
                    this.FreePprGr_Grid.Focus();
                    return;
                }
            }
            if ( e.Key == Keys.Down )
            {
            }
            if ( e.Key == Keys.Right )
            {
                //　ソートボタン　→　明細
                if ( e.PrevCtrl == OrderCng_Button )
                {
                    e.NextCtrl = null;
                    if ( FreePprPrt_Grid.ActiveRow != null )
                        this.FreePprPrt_Grid.Focus();
                    return;
                }
            }
        }

        private void FreePprPrt_Grid_KeyDown( object sender, KeyEventArgs e )
        {
            //　明細　→　グループ
            if ( e.KeyCode == Keys.Left )
            {
                if ( (this.FreePprPrt_Grid.ActiveRow != null) && (this.FreePprPrt_Grid.ActiveRow.Index == 0) )
                {
                    FreePprGr_Grid.Focus();
                }
            }
        }

        private void FreePprGr_Grid_KeyDown( object sender, KeyEventArgs e )
        {
            // グループ　→　明細
            if ( e.KeyCode == Keys.Right )
            {
                if ( (this.FreePprGr_Grid.ActiveRow != null) && (this.FreePprGr_Grid.ActiveRow.Index == 0) )
                {
                    FreePprPrt_Grid.Focus();
                }
            }
            // グループ　→　印刷ボタン
            else if ( e.KeyCode == Keys.Down )
            {
                if ( (this.FreePprGr_Grid.ActiveRow != null) && (this.FreePprGr_Grid.ActiveRow.Index == (this.FreePprGr_Grid.Rows.Count - 1)) )
                {
                    Print_Button.Focus();
                }
            }
        }


        #endregion



    }

    #region ソートクラス
    /// <summary>
    /// 自由帳票ソート順位比較用クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : IComparable インターフェイスの実装。</br>
    /// <br>Programmer : 22011 柏原 頼人</br>
    /// <br>Date       : 2007.11.06</br>
    /// </remarks>
    public class FrePprSrtOSortingOrderComparer : IComparer<FrePprSrtO>
    {
        /// <summary>
        /// 自由帳票ソート順位比較用メソッド
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public int Compare( FrePprSrtO x, FrePprSrtO y )
        {
            return (x.SortingOrder - y.SortingOrder);
        }
    }
    #endregion
}