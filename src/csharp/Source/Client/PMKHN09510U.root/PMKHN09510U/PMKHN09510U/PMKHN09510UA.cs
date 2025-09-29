//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＴＢＯ情報出力
// プログラム概要   : ＴＢＯ情報出力
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270029-00  作成担当 : 黄亜光
// 作 成 日 : 2016/05/20   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Xml;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.Misc;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ＴＢＯ情報出力フレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＴＢＯ情報出力のフレームクラスです。</br>
    /// <br>Programmer : 黄亜光</br>
    /// <br>Date       : 2016/05/20</br>
    /// </remarks>
    public class PMKHN09510UA : System.Windows.Forms.Form
    {
        # region Private Members (Component)
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinDock.UltraDockManager Main_DockManager;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN09510UAUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN09510UAUnpinnedTabAreaRight;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN09510UAUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN09510UAUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.AutoHideControl _PMKHN09510UAAutoHideControl;
        private TMemPos tMemPos1;
        private DataSet BindDataSet;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.MenuItem Close_menuItem;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09510UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09510UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09510UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09510UA_Toolbars_Dock_Area_Bottom;
        private UltraTabControl utc_InventTab;
        private UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Panel PMKHN09510UA_Fill_Panel;
        private TRetKeyControl tRetKeyControl1;
        private TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private UiSetControl uiSetControl1;
        private UiMemInput uiMemInput1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar ultraExplorerBar1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private TDateEdit TDateEdit_PriceStartDate;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_PriceStartDate;
        private TEdit tEdit_GoodsNo;
        private Infragistics.Win.Misc.UltraButton btn_MakerGuid_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_Maker;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_GoodsNo;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_TBOClass;
        private TEdit tEdit_Category;
        private UltraButton btn_MakerGuid_Ed;
        private TEdit tEdit_MakerName_Ed;
        private TEdit tEdit_MakerName_St;
        private UltraLabel ultraLabel2;
        private TNedit tNedit_MakerCode_Ed;
        private TNedit tNedit_MakerCode_St;
        private UltraLabel ultraLabel_Customer;
        private UltraButton btn_CustomerGuid;
        private TEdit tEdit_CustomerName;
        private TNedit tNedit_CustomerCode;
        private System.Windows.Forms.ContextMenu TabControl_contextMenu;
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// ＴＢＯ情報出力フレームクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : ＴＢＯ情報出力のフレームクラスです。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        public PMKHN09510UA()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
        }

        /// <summary>
        /// コンストラクタ　Nunit用
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <remarks>
        /// <br>Note       : ＴＢＯ情報出力フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        public PMKHN09510UA(string param)
        {
            if (("NUnit").Equals(param))
            {
                // 初期化
                InitializeComponent();
            }
            else
            {
                throw new Exception();
            }
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
        /// <br>Note       : 使用されているリソースに後処理を実行します。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
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
        /// <remarks>
        /// <br>Note       : フォーム デザイナで生成されたコード</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Edit_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guide_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guide_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Edit_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guide_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09510UA));
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.btn_CustomerGuid = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_CustomerName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel_Customer = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_MakerCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_MakerCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.btn_MakerGuid_Ed = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_MakerName_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TDateEdit_PriceStartDate = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel_PriceStartDate = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_MakerName_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_Category = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_GoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.btn_MakerGuid_St = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel_Maker = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_GoodsNo = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_TBOClass = new Infragistics.Win.Misc.UltraLabel();
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._PMKHN09510UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN09510UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN09510UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN09510UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN09510UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.BindDataSet = new System.Data.DataSet();
            this.Close_menuItem = new System.Windows.Forms.MenuItem();
            this.TabControl_contextMenu = new System.Windows.Forms.ContextMenu();
            this.utc_InventTab = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.PMKHN09510UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.ultraExplorerBar1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.uiMemInput1 = new Broadleaf.Library.Windows.Forms.UiMemInput(this.components);
            this._PMKHN09510UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._PMKHN09510UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09510UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MakerCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MakerCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MakerName_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MakerName_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utc_InventTab)).BeginInit();
            this.utc_InventTab.SuspendLayout();
            this.ultraTabSharedControlsPage1.SuspendLayout();
            this.PMKHN09510UA_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExplorerBar1)).BeginInit();
            this.ultraExplorerBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.btn_CustomerGuid);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_CustomerName);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_CustomerCode);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_Customer);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_MakerCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_MakerCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel2);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.btn_MakerGuid_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_MakerName_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.TDateEdit_PriceStartDate);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_PriceStartDate);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_MakerName_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_Category);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_GoodsNo);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.btn_MakerGuid_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_Maker);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_GoodsNo);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_TBOClass);
            this.ultraExplorerBarContainerControl1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(19, 48);
            this.ultraExplorerBarContainerControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(976, 280);
            this.ultraExplorerBarContainerControl1.TabIndex = 0;
            // 
            // btn_CustomerGuid
            // 
            appearance17.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance17.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btn_CustomerGuid.Appearance = appearance17;
            this.btn_CustomerGuid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_CustomerGuid.Location = new System.Drawing.Point(589, 199);
            this.btn_CustomerGuid.Name = "btn_CustomerGuid";
            this.btn_CustomerGuid.Size = new System.Drawing.Size(24, 24);
            this.btn_CustomerGuid.TabIndex = 8;
            this.btn_CustomerGuid.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btn_CustomerGuid.Click += new System.EventHandler(this.btn_CustomerGuid_Click);
            // 
            // tEdit_CustomerName
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance15.TextHAlignAsString = "Left";
            this.tEdit_CustomerName.ActiveAppearance = appearance15;
            appearance16.TextHAlignAsString = "Left";
            this.tEdit_CustomerName.Appearance = appearance16;
            this.tEdit_CustomerName.AutoSelect = true;
            this.tEdit_CustomerName.AutoSize = false;
            this.tEdit_CustomerName.DataText = "";
            this.tEdit_CustomerName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CustomerName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_CustomerName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_CustomerName.Location = new System.Drawing.Point(364, 199);
            this.tEdit_CustomerName.MaxLength = 24;
            this.tEdit_CustomerName.Name = "tEdit_CustomerName";
            this.tEdit_CustomerName.ReadOnly = true;
            this.tEdit_CustomerName.Size = new System.Drawing.Size(219, 24);
            this.tEdit_CustomerName.TabIndex = 1007;
            // 
            // tNedit_CustomerCode
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextHAlignAsString = "Left";
            this.tNedit_CustomerCode.ActiveAppearance = appearance12;
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.Appearance = appearance13;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(282, 199);
            this.tNedit_CustomerCode.MaxLength = 8;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(76, 24);
            this.tNedit_CustomerCode.TabIndex = 6;
            this.tNedit_CustomerCode.Leave += new System.EventHandler(this.tNedit_MakerCode_St_Leave);
            // 
            // ultraLabel_Customer
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Left";
            appearance9.TextVAlignAsString = "Middle";
            this.ultraLabel_Customer.Appearance = appearance9;
            this.ultraLabel_Customer.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_Customer.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_Customer.Location = new System.Drawing.Point(45, 199);
            this.ultraLabel_Customer.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel_Customer.Name = "ultraLabel_Customer";
            this.ultraLabel_Customer.Size = new System.Drawing.Size(100, 24);
            this.ultraLabel_Customer.TabIndex = 1006;
            this.ultraLabel_Customer.Text = "得意先";
            // 
            // tNedit_MakerCode_Ed
            // 
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance94.ForeColor = System.Drawing.Color.Black;
            appearance94.TextHAlignAsString = "Left";
            this.tNedit_MakerCode_Ed.ActiveAppearance = appearance94;
            appearance95.ForeColor = System.Drawing.Color.Black;
            appearance95.ForeColorDisabled = System.Drawing.Color.Black;
            appearance95.TextHAlignAsString = "Right";
            this.tNedit_MakerCode_Ed.Appearance = appearance95;
            this.tNedit_MakerCode_Ed.AutoSelect = true;
            this.tNedit_MakerCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MakerCode_Ed.DataText = "";
            this.tNedit_MakerCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MakerCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_MakerCode_Ed.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_MakerCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_MakerCode_Ed.Location = new System.Drawing.Point(557, 153);
            this.tNedit_MakerCode_Ed.MaxLength = 4;
            this.tNedit_MakerCode_Ed.Name = "tNedit_MakerCode_Ed";
            this.tNedit_MakerCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_MakerCode_Ed.Size = new System.Drawing.Size(44, 24);
            this.tNedit_MakerCode_Ed.TabIndex = 4;
            this.tNedit_MakerCode_Ed.Leave += new System.EventHandler(this.tNedit_MakerCode_St_Leave);
            // 
            // tNedit_MakerCode_St
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Left";
            this.tNedit_MakerCode_St.ActiveAppearance = appearance21;
            appearance22.ForeColor = System.Drawing.Color.Black;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            appearance22.TextHAlignAsString = "Right";
            this.tNedit_MakerCode_St.Appearance = appearance22;
            this.tNedit_MakerCode_St.AutoSelect = true;
            this.tNedit_MakerCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MakerCode_St.DataText = "";
            this.tNedit_MakerCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MakerCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_MakerCode_St.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_MakerCode_St.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_MakerCode_St.Location = new System.Drawing.Point(282, 153);
            this.tNedit_MakerCode_St.MaxLength = 4;
            this.tNedit_MakerCode_St.Name = "tNedit_MakerCode_St";
            this.tNedit_MakerCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_MakerCode_St.Size = new System.Drawing.Size(44, 24);
            this.tNedit_MakerCode_St.TabIndex = 2;
            this.tNedit_MakerCode_St.Leave += new System.EventHandler(this.tNedit_MakerCode_St_Leave);
            // 
            // ultraLabel2
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance5;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(529, 153);
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(24, 24);
            this.ultraLabel2.TabIndex = 1002;
            this.ultraLabel2.Text = "～";
            // 
            // btn_MakerGuid_Ed
            // 
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btn_MakerGuid_Ed.Appearance = appearance4;
            this.btn_MakerGuid_Ed.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_MakerGuid_Ed.Location = new System.Drawing.Point(776, 153);
            this.btn_MakerGuid_Ed.Name = "btn_MakerGuid_Ed";
            this.btn_MakerGuid_Ed.Size = new System.Drawing.Size(24, 24);
            this.btn_MakerGuid_Ed.TabIndex = 5;
            this.btn_MakerGuid_Ed.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btn_MakerGuid_Ed.Click += new System.EventHandler(this.btn_MakerGuid_Click);
            // 
            // tEdit_MakerName_Ed
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.TextHAlignAsString = "Left";
            this.tEdit_MakerName_Ed.ActiveAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.tEdit_MakerName_Ed.Appearance = appearance11;
            this.tEdit_MakerName_Ed.AutoSelect = true;
            this.tEdit_MakerName_Ed.AutoSize = false;
            this.tEdit_MakerName_Ed.DataText = "";
            this.tEdit_MakerName_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MakerName_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_MakerName_Ed.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_MakerName_Ed.Location = new System.Drawing.Point(607, 153);
            this.tEdit_MakerName_Ed.MaxLength = 24;
            this.tEdit_MakerName_Ed.Name = "tEdit_MakerName_Ed";
            this.tEdit_MakerName_Ed.ReadOnly = true;
            this.tEdit_MakerName_Ed.Size = new System.Drawing.Size(163, 24);
            this.tEdit_MakerName_Ed.TabIndex = 1004;
            // 
            // TDateEdit_PriceStartDate
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TDateEdit_PriceStartDate.ActiveEditAppearance = appearance78;
            this.TDateEdit_PriceStartDate.BackColor = System.Drawing.Color.Transparent;
            this.TDateEdit_PriceStartDate.CalendarDisp = true;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance79.ForeColorDisabled = System.Drawing.Color.Black;
            this.TDateEdit_PriceStartDate.EditAppearance = appearance79;
            this.TDateEdit_PriceStartDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TDateEdit_PriceStartDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TDateEdit_PriceStartDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TDateEdit_PriceStartDate.ImeMode = System.Windows.Forms.ImeMode.Off;
            appearance80.TextHAlignAsString = "Left";
            appearance80.TextVAlignAsString = "Middle";
            this.TDateEdit_PriceStartDate.LabelAppearance = appearance80;
            this.TDateEdit_PriceStartDate.Location = new System.Drawing.Point(282, 59);
            this.TDateEdit_PriceStartDate.Name = "TDateEdit_PriceStartDate";
            this.TDateEdit_PriceStartDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TDateEdit_PriceStartDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TDateEdit_PriceStartDate.Size = new System.Drawing.Size(176, 24);
            this.TDateEdit_PriceStartDate.TabIndex = 0;
            this.TDateEdit_PriceStartDate.TabStop = true;
            // 
            // ultraLabel_PriceStartDate
            // 
            appearance82.BackColor = System.Drawing.Color.Transparent;
            appearance82.ForeColorDisabled = System.Drawing.Color.Black;
            appearance82.TextHAlignAsString = "Left";
            appearance82.TextVAlignAsString = "Middle";
            this.ultraLabel_PriceStartDate.Appearance = appearance82;
            this.ultraLabel_PriceStartDate.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_PriceStartDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_PriceStartDate.Location = new System.Drawing.Point(45, 59);
            this.ultraLabel_PriceStartDate.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel_PriceStartDate.Name = "ultraLabel_PriceStartDate";
            this.ultraLabel_PriceStartDate.Size = new System.Drawing.Size(100, 24);
            this.ultraLabel_PriceStartDate.TabIndex = 1001;
            this.ultraLabel_PriceStartDate.Text = "価格適用日";
            // 
            // tEdit_MakerName_St
            // 
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance25.TextHAlignAsString = "Left";
            this.tEdit_MakerName_St.ActiveAppearance = appearance25;
            appearance26.TextHAlignAsString = "Left";
            this.tEdit_MakerName_St.Appearance = appearance26;
            this.tEdit_MakerName_St.AutoSelect = true;
            this.tEdit_MakerName_St.AutoSize = false;
            this.tEdit_MakerName_St.DataText = "";
            this.tEdit_MakerName_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MakerName_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_MakerName_St.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_MakerName_St.Location = new System.Drawing.Point(332, 153);
            this.tEdit_MakerName_St.MaxLength = 24;
            this.tEdit_MakerName_St.Name = "tEdit_MakerName_St";
            this.tEdit_MakerName_St.ReadOnly = true;
            this.tEdit_MakerName_St.Size = new System.Drawing.Size(163, 24);
            this.tEdit_MakerName_St.TabIndex = 1003;
            // 
            // tEdit_Category
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance18.TextHAlignAsString = "Left";
            this.tEdit_Category.ActiveAppearance = appearance18;
            appearance19.TextHAlignAsString = "Left";
            this.tEdit_Category.Appearance = appearance19;
            this.tEdit_Category.AutoSelect = true;
            this.tEdit_Category.AutoSize = false;
            this.tEdit_Category.DataText = "";
            this.tEdit_Category.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Category.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_Category.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Category.Location = new System.Drawing.Point(282, 15);
            this.tEdit_Category.MaxLength = 24;
            this.tEdit_Category.Name = "tEdit_Category";
            this.tEdit_Category.ReadOnly = true;
            this.tEdit_Category.Size = new System.Drawing.Size(147, 24);
            this.tEdit_Category.TabIndex = 1005;
            // 
            // tEdit_GoodsNo
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance23.TextHAlignAsString = "Left";
            this.tEdit_GoodsNo.ActiveAppearance = appearance23;
            appearance24.TextHAlignAsString = "Left";
            this.tEdit_GoodsNo.Appearance = appearance24;
            this.tEdit_GoodsNo.AutoSelect = true;
            this.tEdit_GoodsNo.AutoSize = false;
            this.tEdit_GoodsNo.DataText = "";
            this.tEdit_GoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_GoodsNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_GoodsNo.Location = new System.Drawing.Point(282, 107);
            this.tEdit_GoodsNo.MaxLength = 24;
            this.tEdit_GoodsNo.Name = "tEdit_GoodsNo";
            this.tEdit_GoodsNo.Size = new System.Drawing.Size(203, 24);
            this.tEdit_GoodsNo.TabIndex = 1;
            // 
            // btn_MakerGuid_St
            // 
            appearance27.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance27.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btn_MakerGuid_St.Appearance = appearance27;
            this.btn_MakerGuid_St.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_MakerGuid_St.Location = new System.Drawing.Point(501, 153);
            this.btn_MakerGuid_St.Name = "btn_MakerGuid_St";
            this.btn_MakerGuid_St.Size = new System.Drawing.Size(24, 24);
            this.btn_MakerGuid_St.TabIndex = 3;
            this.btn_MakerGuid_St.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btn_MakerGuid_St.Click += new System.EventHandler(this.btn_MakerGuid_Click);
            // 
            // ultraLabel_Maker
            // 
            appearance14.BackColor = System.Drawing.Color.Transparent;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Left";
            appearance14.TextVAlignAsString = "Middle";
            this.ultraLabel_Maker.Appearance = appearance14;
            this.ultraLabel_Maker.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_Maker.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_Maker.Location = new System.Drawing.Point(45, 153);
            this.ultraLabel_Maker.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel_Maker.Name = "ultraLabel_Maker";
            this.ultraLabel_Maker.Size = new System.Drawing.Size(100, 24);
            this.ultraLabel_Maker.TabIndex = 998;
            this.ultraLabel_Maker.Text = "メーカー";
            // 
            // ultraLabel_GoodsNo
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel_GoodsNo.Appearance = appearance2;
            this.ultraLabel_GoodsNo.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_GoodsNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_GoodsNo.Location = new System.Drawing.Point(45, 107);
            this.ultraLabel_GoodsNo.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel_GoodsNo.Name = "ultraLabel_GoodsNo";
            this.ultraLabel_GoodsNo.Size = new System.Drawing.Size(100, 24);
            this.ultraLabel_GoodsNo.TabIndex = 999;
            this.ultraLabel_GoodsNo.Text = "親品番";
            // 
            // ultraLabel_TBOClass
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel_TBOClass.Appearance = appearance3;
            this.ultraLabel_TBOClass.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_TBOClass.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_TBOClass.Location = new System.Drawing.Point(45, 15);
            this.ultraLabel_TBOClass.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel_TBOClass.Name = "ultraLabel_TBOClass";
            this.ultraLabel_TBOClass.Size = new System.Drawing.Size(100, 24);
            this.ultraLabel_TBOClass.TabIndex = 1000;
            this.ultraLabel_TBOClass.Text = "カテゴリ";
            // 
            // Main_DockManager
            // 
            this.Main_DockManager.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            this.Main_DockManager.HostControl = this;
            this.Main_DockManager.LayoutStyle = Infragistics.Win.UltraWinDock.DockAreaLayoutStyle.FillContainer;
            this.Main_DockManager.ShowCloseButton = false;
            this.Main_DockManager.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _PMKHN09510UAUnpinnedTabAreaLeft
            // 
            this._PMKHN09510UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._PMKHN09510UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09510UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 73);
            this._PMKHN09510UAUnpinnedTabAreaLeft.Name = "_PMKHN09510UAUnpinnedTabAreaLeft";
            this._PMKHN09510UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._PMKHN09510UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 638);
            this._PMKHN09510UAUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _PMKHN09510UAUnpinnedTabAreaRight
            // 
            this._PMKHN09510UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._PMKHN09510UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09510UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(1016, 73);
            this._PMKHN09510UAUnpinnedTabAreaRight.Name = "_PMKHN09510UAUnpinnedTabAreaRight";
            this._PMKHN09510UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._PMKHN09510UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 638);
            this._PMKHN09510UAUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _PMKHN09510UAUnpinnedTabAreaTop
            // 
            this._PMKHN09510UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._PMKHN09510UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09510UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 73);
            this._PMKHN09510UAUnpinnedTabAreaTop.Name = "_PMKHN09510UAUnpinnedTabAreaTop";
            this._PMKHN09510UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._PMKHN09510UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(1016, 0);
            this._PMKHN09510UAUnpinnedTabAreaTop.TabIndex = 7;
            // 
            // _PMKHN09510UAUnpinnedTabAreaBottom
            // 
            this._PMKHN09510UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._PMKHN09510UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09510UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 711);
            this._PMKHN09510UAUnpinnedTabAreaBottom.Name = "_PMKHN09510UAUnpinnedTabAreaBottom";
            this._PMKHN09510UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._PMKHN09510UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1016, 0);
            this._PMKHN09510UAUnpinnedTabAreaBottom.TabIndex = 8;
            // 
            // _PMKHN09510UAAutoHideControl
            // 
            this._PMKHN09510UAAutoHideControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09510UAAutoHideControl.Location = new System.Drawing.Point(22, 63);
            this._PMKHN09510UAAutoHideControl.Name = "_PMKHN09510UAAutoHideControl";
            this._PMKHN09510UAAutoHideControl.Owner = this.Main_DockManager;
            this._PMKHN09510UAAutoHideControl.Size = new System.Drawing.Size(203, 627);
            this._PMKHN09510UAAutoHideControl.TabIndex = 9;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point(0, 711);
            this.Main_StatusBar.Name = "Main_StatusBar";
            appearance8.TextHAlignAsString = "Center";
            this.Main_StatusBar.PanelAppearance = appearance8;
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
            // BindDataSet
            // 
            this.BindDataSet.DataSetName = "NewDataSet";
            this.BindDataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Close_menuItem
            // 
            this.Close_menuItem.Index = 0;
            this.Close_menuItem.Text = "閉じる(&C)";
            // 
            // TabControl_contextMenu
            // 
            this.TabControl_contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Close_menuItem});
            // 
            // utc_InventTab
            // 
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.BackColor2 = System.Drawing.Color.LightPink;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.utc_InventTab.ActiveTabAppearance = appearance6;
            this.utc_InventTab.Controls.Add(this.ultraTabSharedControlsPage1);
            this.utc_InventTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.utc_InventTab.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.utc_InventTab.Location = new System.Drawing.Point(0, 73);
            this.utc_InventTab.Name = "utc_InventTab";
            this.utc_InventTab.SharedControls.AddRange(new System.Windows.Forms.Control[] {
            this.PMKHN09510UA_Fill_Panel});
            this.utc_InventTab.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.utc_InventTab.Size = new System.Drawing.Size(1016, 638);
            this.utc_InventTab.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.utc_InventTab.TabIndex = 46;
            this.utc_InventTab.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Controls.Add(this.PMKHN09510UA_Fill_Panel);
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(1014, 617);
            // 
            // PMKHN09510UA_Fill_Panel
            // 
            this.PMKHN09510UA_Fill_Panel.Controls.Add(this.ultraExplorerBar1);
            this.PMKHN09510UA_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.PMKHN09510UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PMKHN09510UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.PMKHN09510UA_Fill_Panel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PMKHN09510UA_Fill_Panel.Name = "PMKHN09510UA_Fill_Panel";
            this.PMKHN09510UA_Fill_Panel.Size = new System.Drawing.Size(1014, 617);
            this.PMKHN09510UA_Fill_Panel.TabIndex = 2;
            // 
            // ultraExplorerBar1
            // 
            this.ultraExplorerBar1.AcceptsFocus = Infragistics.Win.DefaultableBoolean.False;
            this.ultraExplorerBar1.AnimationSpeed = Infragistics.Win.UltraWinExplorerBar.AnimationSpeed.Fast;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            appearance20.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance20.FontData.SizeInPoints = 10F;
            appearance20.TextHAlignAsString = "Left";
            appearance20.TextVAlignAsString = "Middle";
            this.ultraExplorerBar1.Appearance = appearance20;
            this.ultraExplorerBar1.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.ultraExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExplorerBar1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup1.Key = "SearchCond";
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            ultraExplorerBarGroup1.Settings.AppearancesSmall.ActiveAppearance = appearance1;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 282;
            ultraExplorerBarGroup1.Text = "抽出条件";
            this.ultraExplorerBar1.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
            this.ultraExplorerBar1.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.ultraExplorerBar1.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance48.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance48.Cursor = System.Windows.Forms.Cursors.Default;
            this.ultraExplorerBar1.GroupSettings.AppearancesSmall.HeaderAppearance = appearance48;
            this.ultraExplorerBar1.GroupSettings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            this.ultraExplorerBar1.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.ultraExplorerBar1.GroupSpacing = 8;
            this.ultraExplorerBar1.Location = new System.Drawing.Point(0, 0);
            this.ultraExplorerBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ultraExplorerBar1.Name = "ultraExplorerBar1";
            this.ultraExplorerBar1.Scrollbars = Infragistics.Win.UltraWinExplorerBar.ScrollbarStyle.Never;
            this.ultraExplorerBar1.ShowDefaultContextMenu = false;
            this.ultraExplorerBar1.Size = new System.Drawing.Size(1014, 617);
            this.ultraExplorerBar1.TabIndex = 3;
            this.ultraExplorerBar1.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.ultraExplorerBar1.GroupCollapsing += new Infragistics.Win.UltraWinExplorerBar.GroupCollapsingEventHandler(this.ultraExplorerBar1_GroupCollapsing);
            this.ultraExplorerBar1.GroupExpanding += new Infragistics.Win.UltraWinExplorerBar.GroupExpandingEventHandler(this.ultraExplorerBar1_GroupExpanding);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
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
            // 
            // uiMemInput1
            // 
            this.uiMemInput1.OwnerForm = this;
            this.uiMemInput1.ReadOnLoad = false;
            // 
            // _PMKHN09510UA_Toolbars_Dock_Area_Left
            // 
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 73);
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.Name = "_PMKHN09510UA_Toolbars_Dock_Area_Left";
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 638);
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
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
            ultraToolbar1.FloatingLocation = new System.Drawing.Point(466, 462);
            ultraToolbar1.FloatingSize = new System.Drawing.Size(425, 48);
            ultraToolbar1.IsMainMenuBar = true;
            labelTool1.InstanceProps.Spring = Infragistics.Win.DefaultableBoolean.True;
            labelTool1.InstanceProps.Width = 25;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            labelTool1,
            labelTool2,
            labelTool3});
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "標準";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            popupMenuTool3.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool5.InstanceProps.IsFirstInGroup = true;
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5});
            labelTool4.SharedProps.Spring = true;
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Left";
            labelTool5.SharedProps.AppearancesSmall.Appearance = appearance7;
            labelTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool5.SharedProps.Width = 150;
            buttonTool6.SharedProps.Caption = "終了(F1)";
            buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool6.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;
            buttonTool6.SharedProps.ShowInCustomizer = false;
            buttonTool7.SharedProps.Caption = "出力(F10)";
            buttonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool7.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            buttonTool8.SharedProps.Caption = "ガイド(F5)";
            buttonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool8.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F5;
            popupMenuTool4.SharedProps.Caption = "編集(&E)";
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9});
            labelTool6.SharedProps.Caption = "ログイン担当者";
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool3,
            labelTool4,
            labelTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8,
            popupMenuTool4,
            labelTool6});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            // 
            // _PMKHN09510UA_Toolbars_Dock_Area_Right
            // 
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 73);
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.Name = "_PMKHN09510UA_Toolbars_Dock_Area_Right";
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 638);
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN09510UA_Toolbars_Dock_Area_Top
            // 
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.Name = "_PMKHN09510UA_Toolbars_Dock_Area_Top";
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 73);
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN09510UA_Toolbars_Dock_Area_Bottom
            // 
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 711);
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.Name = "_PMKHN09510UA_Toolbars_Dock_Area_Bottom";
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // PMKHN09510UA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this._PMKHN09510UAAutoHideControl);
            this.Controls.Add(this.utc_InventTab);
            this.Controls.Add(this._PMKHN09510UAUnpinnedTabAreaTop);
            this.Controls.Add(this._PMKHN09510UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._PMKHN09510UAUnpinnedTabAreaLeft);
            this.Controls.Add(this._PMKHN09510UAUnpinnedTabAreaRight);
            this.Controls.Add(this._PMKHN09510UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMKHN09510UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._PMKHN09510UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._PMKHN09510UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.Main_StatusBar);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09510UA";
            this.Opacity = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ＴＢＯ情報出力";
            this.Load += new System.EventHandler(this.PMKHN09510UA_Load);
            this.Shown += new System.EventHandler(this.PMKHN09510UA_Shown);
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.ultraExplorerBarContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MakerCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MakerCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MakerName_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MakerName_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utc_InventTab)).EndInit();
            this.utc_InventTab.ResumeLayout(false);
            this.ultraTabSharedControlsPage1.ResumeLayout(false);
            this.PMKHN09510UA_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraExplorerBar1)).EndInit();
            this.ultraExplorerBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        #region Private Constant
        private const string CT_PGID = "PMKHN09510U";
        private const string CT_PRINTNAME = "ＴＢＯ情報出力";
        
        // ツールバーツールキー設定
        private const string TOOLBAR_LOGINLABEL_TITLE = "LoginTitle_LabelTool";
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LoginName_LabelTool";
        private const string TOOLBAR_ENDBUTTON_KEY = "End_ButtonTool";
        private const string TOOLBAR_EXPORTBUTTON_KEY = "Export_ButtonTool";
        private const string TOOLBAR_GUIDEBUTTON_KEY = "Guide_ButtonTool";
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region Private Members
        private bool _buttonEnable = true;
        private ImageList _imageList16 = null;
        private Control _prevControl = null;
        private List<Propose_Goods> _retTBODataList;       // TBOデータ
        private MakerAcs _makerAcs;                        // メーカー
        private DateGetAcs _dateGetAcs;                    // 日付取得部品
        private CustomerInfoAcs _customerInfoAcs;          // 得意先
        private TBODataExportCond _searchCond;             // 出力条件
        private TBODataExportAcs _TBODataExportAcs;        // 検索部品アクセス
        private string _enterpriseCode;                    // 企業コード
        private string _sectionCode;                       // 拠点コード
        private string _loginName;                         // ログイン名
        private int _categoryID;                           // 商品カテゴリ
        private int _customerCodePre;                      // 前得意先コード
        private Dictionary<int, MakerUMnt> _makerUMntDic;


        /// <summary>TBOデータ</summary>
        public List<Propose_Goods> TBODataList
        {
            get { return _retTBODataList; }
        }
        #endregion

        // ===============================================================================
        // デリゲートイベント
        // ===============================================================================
        #region delegateEvent
        /// <summary>
        /// ツールバーのガイドボタン設定イベント
        /// </summary>
        /// <param name="enabled">操作可能区分</param>
        /// <remarks>
        /// <br>Note        : ツールバーのガイドボタン設定イベント。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void ParentToolbarGuideSettingEvent(bool enabled)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool =
                        (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];
            if (buttonTool != null)
            {
                buttonTool.SharedProps.Enabled = enabled;
            }
        }

        /// <summary>
        /// 実行F10
        /// </summary>
        /// <param name="sender"></param>
        private void ParentToolbarExtractEvent(object sender)
        {
            this.DoExtract();
        }
        #endregion

        // ===================================================================================== //
        // 公開メソッド
        // ===================================================================================== //
        #region public method
        /// <summary>
        /// ガイドフォーム起動
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="loginName">ログイン名</param>
        /// <param name="categoryID">商品カテゴリ(1:タイヤ、2:バッテリー、3:オイル)</param>
        /// <returns>DialogResult（YES：成功）</returns>
        /// <remarks>
        /// <br>Note       : ガイドフォーム起動する。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        public DialogResult ShowDialog(string enterpriseCode, string sectionCode, string loginName, int categoryID)
        {
            // 企業コード
            this._enterpriseCode = enterpriseCode;
            // 拠点コード
            this._sectionCode = sectionCode;
            // ログイン名
            this._loginName = loginName;
            // 商品カテゴリ
            this._categoryID = categoryID;

            // FORMを表示する
            return this.ShowDialog();
        }
        #endregion

        // ===================================================================================== //
        // 内部メソッド
        // ===================================================================================== //
        #region private method
        /// <summary>
        /// 初期画面設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期画面設定を行います。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
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

            // テキスト出力のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool exportButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
            if (exportButton != null)
            {
                exportButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            }

            // ガイドのアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];
            if (setupButton != null)
            {
                setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
                setupButton.SharedProps.Enabled = false;
            }

            // ログイン名
            Infragistics.Win.UltraWinToolbars.LabelTool LoginName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_LOGINNAMELABEL_KEY];
            if (LoginName != null)
            {
                LoginName.SharedProps.Caption = this._loginName;
            }

            this.SetGuidButtonIcon();          // ボタンアイコン設定
            this.InitialScreenData();          // 初期画面データ設定
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化を行う。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void InitialScreenData()
        {
            switch (this._categoryID)
            {
                case 1:
                    this.tEdit_Category.Text = "タイヤ";
                    break;
                case 2:
                    this.tEdit_Category.Text = "バッテリー";
                    break;
                case 3:
                    this.tEdit_Category.Text = "オイル";
                    break;
            }
            this.tEdit_GoodsNo.Clear();                                  // 品番
            this.TDateEdit_PriceStartDate.SetDateTime(DateTime.Now);     // 価格適用日
            this.tNedit_MakerCode_St.Clear();
            this.tEdit_MakerName_St.Text = string.Empty;
            this.tNedit_MakerCode_Ed.Clear();
            this.tEdit_MakerName_Ed.Text = string.Empty;
            this.tNedit_CustomerCode.Clear();
            this.tEdit_CustomerName.Text = string.Empty;
        }

        /// <summary>
        /// ガイドボタンのアイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ガイドボタンのアイコンを設定します。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            //メーカーガイド
            this.btn_MakerGuid_St.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.btn_MakerGuid_Ed.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.btn_CustomerGuid.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// 「F5：ガイド」の実行
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        :「ガイド」処理</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void ExecuteGuide(object sender, EventArgs e)
        {
            if (this.tNedit_MakerCode_St.Focused)
            {
                this.btn_MakerGuid_Click(this.btn_MakerGuid_St, e);
            }
            else if (this.tNedit_MakerCode_Ed.Focused)
            {
                this.btn_MakerGuid_Click(this.btn_MakerGuid_Ed, e);
            }
            else if (this.tNedit_CustomerCode.Focused)
            {
                this.btn_CustomerGuid_Click(this.btn_CustomerGuid, e);
            }
        }

        /// <summary>
        /// ＴＢＯ情報出力前にチェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errControl">エラーコントロール</param>
        /// <returns>エラー有無フラグ</returns>
        /// <remarks>
        /// <br>Note       : ＴＢＯ情報出力前にチェック処理を行います。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private bool BeforeSearchCheck(out string errMessage, out Control errControl)
        {
            DateGetAcs.CheckDateResult cdrResult;
            bool result = true;
            errMessage = string.Empty;
            errControl = null;

            // 価格適用日
            if (!CallCheckDate(out cdrResult, ref TDateEdit_PriceStartDate))
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = "価格適用日を入力してください。";
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = "価格適用日の入力が不正です。";
                        }
                        break;
                }

                errControl = this.TDateEdit_PriceStartDate;
                result = false;
                return result;
            }

            // メーカー
            if (!string.IsNullOrEmpty(this.tNedit_MakerCode_St.DataText.Trim()) && 
                !string.IsNullOrEmpty(this.tNedit_MakerCode_Ed.DataText.Trim()))
            {
                if (this.tNedit_MakerCode_St.GetInt() > this.tNedit_MakerCode_Ed.GetInt())
                {
                    errMessage = "メーカーコードの範囲指定に誤りがあります。";
                    errControl = this.tEdit_MakerName_St;
                    result = false;
                    return result;
                }
            }

            return result;
        }

        /// <summary>
        /// 日付チェック呼び出し
        /// </summary>
        /// <param name="cdrResult">チェック結果</param>
        /// <param name="priceStartDate">価格適用日</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : 日付チェック呼び出し</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdrResult, ref TDateEdit priceStartDate)
        {
            // 日付チェック
            cdrResult = _dateGetAcs.CheckDate(ref priceStartDate);
            return (cdrResult == DateGetAcs.CheckDateResult.OK);
        }

        /// <summary>
        /// ＴＢＯ情報出力(F10)
        /// </summary>
        /// <remarks>
        /// <br>Note       : ＴＢＯ情報出力を実行する。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void DoExtract()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
            }

            // 出力前チェック
            string message = string.Empty;
            Control errControl = null;
            bool canExport = this.BeforeSearchCheck(out message, out errControl);

            if (!canExport)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, CT_PRINTNAME, "", "", message, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                errControl.Focus();
                return;
            }

            // 確認メッセージを表示する。
            DialogResult result = TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_QUESTION,                // エラーレベル
                        CT_PGID,                                        // アセンブリＩＤまたはクラスＩＤ
                        CT_PRINTNAME,                                   // プログラム名称
                        "",                                             // 処理名称
                        "",                                             // オペレーション
                        "出力処理を行います。" + Environment.NewLine + "実行してもよろしいですか？", // 表示するメッセージ
                        -1,                                             // ステータス値
                        null,                                           // エラーが発生したオブジェクト
                        MessageBoxButtons.YesNo,                        // 表示するボタン
                        MessageBoxDefaultButton.Button1);               // 初期表示ボタン

            // 画面へ戻る。
            if (result == DialogResult.No)
            {
                return;
            }

            SFCMN00299CA msgForm = new SFCMN00299CA();
            // 表示文字を設定
            msgForm.Title = "出力中";
            msgForm.Message = "現在、データを出力中です。";
            
            try
            {
                msgForm.Show();

                // 画面→抽出条件クラス
                this.SetExtraInfoFromScreen();

                // 検索
                string errMessage = String.Empty;
                status = this._TBODataExportAcs.SearchTBODataExportMain(this._searchCond, out this._retTBODataList, out errMessage);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        if (msgForm != null)
                        {
                            msgForm.Close();
                        }

                        this.Activate();

                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, CT_PRINTNAME, "", "", "データを出力しました。", status, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);

                        this.DialogResult = DialogResult.Yes;
                        this.Close();
                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        if (msgForm != null)
                        {
                            msgForm.Close();
                        }
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, CT_PRINTNAME, "", "", "該当するデータがありません。", status, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        break;

                    default:
                        if (msgForm != null)
                        {
                            msgForm.Close();
                        }
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, CT_PRINTNAME, "", "", "データの出力が失敗しました。", status, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        break;
                }
            }
            finally
            {
                // 出力後、ガイドボタンを再設定
                if (this.tNedit_MakerCode_St.Focused || this.tNedit_MakerCode_Ed.Focused)
                {
                    ParentToolbarGuideSettingEvent(true);
                }
                else
                {
                    ParentToolbarGuideSettingEvent(false);
                }
            }
        }

        /// <summary>
        /// 出力条件設定処理(画面→出力条件)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出力条件設定処理(画面→出力条件)を行う。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void SetExtraInfoFromScreen()
        {
            // 企業コード
            this._searchCond.EnterpriseCode = this._enterpriseCode;
            // 商品カテゴリ
            this._searchCond.CategoryID = this._categoryID;
            // 品番
            this._searchCond.GoodsNo = this.tEdit_GoodsNo.Text.Trim();
            // 価格開始日
            this._searchCond.PriceStartDate = Convert.ToInt32(this.TDateEdit_PriceStartDate.GetDateTime().ToString("yyyyMMdd"));
            // メーカーコード(Start)
            this._searchCond.GoodsMakerCd_ST = this.tNedit_MakerCode_St.GetInt();
            // メーカーコード(End)
            if (this.tNedit_MakerCode_Ed.GetInt() == 0)
            {
                this._searchCond.GoodsMakerCd_ED = 9999;
            }
            else
            {
                this._searchCond.GoodsMakerCd_ED = this.tNedit_MakerCode_Ed.GetInt();
            }
            // 拠点コード
            this._searchCond.SectionCodeRF = this._sectionCode;
            // 得意先コード
            this._searchCond.CustomerCode = this.tNedit_CustomerCode.GetInt();
        }

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカーマスタ読込処理を行う。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void LoadMakerUMnt()
        {
            int status = 0;

            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            if (_makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            try
            {
                ArrayList retList;
                status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);

                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称取得処理を行う。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                makerName = this._makerUMntDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時発生します。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // イベントハンドラを渡した相手から戻り値クラスを受け取れなければ終了
            if (customerSearchRet == null) return;

            // DBデータを読み出す(キャッシュを使用)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (customerInfo == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "選択した得意先は得意先情報入力が行われていない為、使用出来ません。",
                        status, MessageBoxButtons.OK);
                    return;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "選択した得意先は既に削除されています。",
                    status, MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                    "得意先情報の取得に失敗しました。",
                    status, MessageBoxButtons.OK);
                return;
            }


            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
            this.tEdit_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
            this._customerCodePre = customerInfo.CustomerCode;
            this.btn_CustomerGuid.Focus();
        }

        /// <summary>
        /// 得意先名称取得
        /// </summary>
        /// <param name="code">得意先コード</param>
        /// <param name="name">得意先名称</param>
        /// <remarks>
        /// <br>Note       : 得意先名称取得処理を行う。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private bool ReadCustomerName(out int code, out string name)
        {
            code = this.tNedit_CustomerCode.GetInt();
            name = tEdit_CustomerName.Text;

            if (_customerCodePre == code) return true;

            if (code > 0)
            {
                CustomerInfo customerInfo;
                int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, code, out customerInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer)
                {
                    name = customerInfo.CustomerSnm.TrimEnd();
                    return true;
                }
                else
                {
                    code = _customerCodePre;
                    return false;
                }
            }
            else
            {
                code = 0;
                name = string.Empty;
                return true;
            }
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
        /// <br>Note        : メインフレームのLOADイベント。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void PMKHN09510UA_Load(object sender, System.EventArgs e)
        {
            // 初期画面設定
            InitialScreenSetting();

            // マスタ読込
            this.LoadMakerUMnt();
            this._dateGetAcs = DateGetAcs.GetInstance();                // 日付取得部品
            this._customerInfoAcs = new CustomerInfoAcs();              // 得意先
            this._searchCond = new TBODataExportCond();                 // 出力条件
            this._TBODataExportAcs = new TBODataExportAcs();            // 検索部品アクセス
            this._retTBODataList = new List<Propose_Goods>();
            this._customerCodePre = 0;

            this.PMKHN09510UA_Fill_Panel.Dock = DockStyle.Fill;

            UltraTab targetTab = new UltraTab();
            targetTab.Text = this.Text;

            targetTab.Appearance.Image = this.Icon;
            targetTab.Appearance.BackColor = Color.White;
            targetTab.Appearance.BackColor2 = Color.Lavender;

            targetTab.ActiveAppearance.BackColor = Color.White;
            targetTab.ActiveAppearance.BackColor2 = Color.LightPink;

            // タブコントロールに追加するタブページをインスタンス化する
            targetTab.TabPage = new UltraTabPageControl();
            // タブページにフォームをバインド
            targetTab.TabPage.Controls.Add(this.PMKHN09510UA_Fill_Panel);

            // タブコントロールにタブを追加する
            this.utc_InventTab.Controls.Add(targetTab.TabPage);
            this.utc_InventTab.Tabs.Add(targetTab);
            this.utc_InventTab.SelectedTab = targetTab;
            this.utc_InventTab.TabStop = false;
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : ツールバークリック時に発生します。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (_buttonEnable)
            {
                switch (e.Tool.Key)
                {
                    // 終了
                    case TOOLBAR_ENDBUTTON_KEY:
                        {
                            this.Close();
                            break;
                        }
                    // 出力
                    case TOOLBAR_EXPORTBUTTON_KEY:
                        {
                            this.DoExtract();
                            break;
                        }
                    // F5:ガイド
                    case TOOLBAR_GUIDEBUTTON_KEY:
                        {
                            _buttonEnable = false;
                            this.ExecuteGuide(sender, e);
                            
                            _buttonEnable = true;
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }

            this._prevControl = e.NextCtrl;

            switch (e.PrevCtrl.Name)
            {
                // メーカー(Start)
                case "tNedit_MakerCode_St":
                    {
                        // メーカーコード取得
                        int makerCode = this.tNedit_MakerCode_St.GetInt();

                        // メーカー名称取得
                        this.tEdit_MakerName_St.DataText = GetMakerName(makerCode);

                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_MakerName_St.DataText.Trim()))
                                        {
                                            e.NextCtrl = this.tNedit_MakerCode_Ed;
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                // メーカー(End)
                case "tNedit_MakerCode_Ed":
                    {
                        // メーカーコード
                        int makerCode = this.tNedit_MakerCode_Ed.GetInt();

                        // メーカー名称
                        this.tEdit_MakerName_Ed.DataText = GetMakerName(makerCode);

                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_MakerName_Ed.DataText.Trim()))
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode; // 得意先コード
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                // 得意先コード
                case "tNedit_CustomerCode":
                    {
                        int inputValue = tNedit_CustomerCode.GetInt();

                        int code;
                        string name;
                        if (ReadCustomerName(out code, out name))
                        {
                            this.tNedit_CustomerCode.SetInt(code);
                            this.tEdit_CustomerName.Text = name;
                            _customerCodePre = code;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Enter:
                                        {
                                            if (!string.IsNullOrEmpty(this.tNedit_CustomerCode.Text))
                                            {
                                                e.NextCtrl = this.btn_CustomerGuid;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "得意先コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            // コード戻す
                            this.tNedit_CustomerCode.SetInt(code);
                            this.tNedit_CustomerCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 品番
                case "tEdit_GoodsNo":
                    {
                        switch (e.Key)
                        {
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tNedit_MakerCode_St; // メーカー(Start)
                                    break;
                                }
                        }
                        break;
                    }
            }

            // ガイド制御
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tNedit_MakerCode_St":
                    case "tNedit_MakerCode_Ed":
                    case "tNedit_CustomerCode":
                        {
                            ParentToolbarGuideSettingEvent(true);
                            break;
                        }
                    default:
                        {
                            if (e.NextCtrl.CanSelect || e.NextCtrl is TEdit || e.NextCtrl is TNedit || e.NextCtrl is TComboEditor
                                || e.NextCtrl is TDateEdit || e.NextCtrl is UltraButton)
                            {
                                ParentToolbarGuideSettingEvent(false);
                            }
                            break;
                        }
                }
            }

            this._prevControl = e.NextCtrl;
        }

        /// <summary>
        /// GroupCollapsing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : UltraExplorerBarGroup が縮小される前に発生します。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ExportFile") ||
                (e.Group.Key == "SearchCond"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// GroupExpanding イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : UltraExplorerBarGroup が展開される前に発生します。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ExportFile") ||
                (e.Group.Key == "SearchCond"))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// メーカーガイド
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : メーカーガイドをクリックします。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void btn_MakerGuid_Click(object sender, EventArgs e)
        {
            if (this._makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            MakerUMnt maker;

            // ガイド起動
            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out maker);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                //開始、終了どちらのボタンが押されたか？
                if ((Infragistics.Win.Misc.UltraButton)sender == this.btn_MakerGuid_St)
                {
                    //開始
                    this.tNedit_MakerCode_St.SetInt(maker.GoodsMakerCd);
                    this.tEdit_MakerName_St.DataText = maker.MakerName.Trim();

                    // フォーカス設定
                    this.tNedit_MakerCode_Ed.Focus();
                }
                else
                {
                    //終了
                    this.tNedit_MakerCode_Ed.SetInt(maker.GoodsMakerCd);
                    this.tEdit_MakerName_Ed.DataText = maker.MakerName.Trim();

                    // フォーカス設定
                    this.btn_MakerGuid_Ed.Focus();
                }
            }
        }

        /// <summary>
        /// 得意先ガイド
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 得意先ガイドをクリックします。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void btn_CustomerGuid_Click(object sender, EventArgs e)
        {
            // 得意先ガイド表示
            PMKHN04001UA customerSearchForm = new PMKHN04001UA(PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04001UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ForcedAutoSearch = true;

            DialogResult result = customerSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">メッセージ</param>
        /// <remarks>
        /// <br>Note	   : 画面表示処理</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void PMKHN09510UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;

            // 初期フォーカス設定
            this.TDateEdit_PriceStartDate.Focus();
        }

        /// <summary>
        /// Control.Leave イベント (tNedit_MakerCode_St)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 入力フォーカスがコントロールを離れると発生します。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void tNedit_MakerCode_St_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;
            if (tNedit == null)
            {
                return;
            }

            // 空欄か0の時初期値をセット
            if ((tNedit.DataText == "") || (tNedit.GetInt() == 0))
            {
                tNedit.DataText = string.Empty;
            }
        }

        # endregion control event
    }
}
