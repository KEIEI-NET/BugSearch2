using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

using Infragistics.Win;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 印字位置ダウンロード画面ＵＩクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		:</br>
	/// <br>Programmer	: 22011 柏原　頼人</br>
	/// <br>Date		: 2007.05.14</br>
	/// </remarks>
	public class SFANL08200UA : System.Windows.Forms.Form, IFreeSheetMainFrame
	{
		#region Private Controls
        private System.Windows.Forms.Panel SFANL08200UA_Fill_Panel;
		private Infragistics.Win.UltraWinGrid.UltraGrid offerInfo_ultraGrid;
        private Infragistics.Win.UltraWinGrid.UltraGrid userInfo_ultraGrid;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager user_ultraToolbarsManager;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager offer_ultraToolbarsManager;
		private System.Windows.Forms.Panel userInfo_panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _userInfo_panel_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _userInfo_panel_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _userInfo_panel_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _userInfo_panel_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.Misc.UltraLabel userTitle_ultraLabel;
		private System.Windows.Forms.Panel userBack_panel;
		private System.Windows.Forms.Panel offerInfo_panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _offerInfo_panel_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _offerInfo_panel_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _offerInfo_panel_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _offerInfo_panel_Toolbars_Dock_Area_Bottom;
        private System.Windows.Forms.Panel userHeader_panel;
		private System.Windows.Forms.Panel offerBack_panel;
		private System.Windows.Forms.Panel offerHeader_panel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private System.Windows.Forms.Panel panel1;
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.UltraWinDock.AutoHideControl _SFANL08200UAAutoHideControl;
        private Infragistics.Win.UltraWinDock.UltraDockManager ultraDockManager1;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFANL08200UAUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFANL08200UAUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFANL08200UAUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFANL08200UAUnpinnedTabAreaRight;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow2;
        private WindowDockingArea windowDockingArea3;
        private WindowDockingArea windowDockingArea2;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Constructor
		/// <summary>
		/// 印字位置ダウンロード画面ＵＩクラスコンストラクタ
		/// </summary>
		public SFANL08200UA()
		{
			// Windows フォーム デザイナ サポートに必要です。
			InitializeComponent();

			this._downLoadPrtPosAcs = new DownLoadPrtPosAcs();             // 印字位置DL画面アクセスクラス
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;    // 企業コード取得
		}
		#endregion

		#region Dispose
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
		#endregion

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
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Offer_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OfferAllSelect_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OfferAllCancel_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OfferDel_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OfferAllSelect_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OfferAllCancel_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OfferDel_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("OfferDetail_ControlContainerTool");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("User_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserAllUpdate_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserAllCancel_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserAddCancel_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserAllUpdate_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserAllCancel_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserAllMerge_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserAddCancel_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("UserDetail_ControlContainerTool");
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFANL08200UA));
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, new System.Guid("f9d2737a-ac88-4c9b-be32-b369edcd3a4f"));
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("7605e019-0d99-4029-9ce4-59e6c239ddfd"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("cc891010-95ea-4dd9-b187-48cf5745b242"), new System.Guid("f9d2737a-ac88-4c9b-be32-b369edcd3a4f"), -1, new System.Guid("7605e019-0d99-4029-9ce4-59e6c239ddfd"), 0);
            this.offerBack_panel = new System.Windows.Forms.Panel();
            this.offerInfo_panel = new System.Windows.Forms.Panel();
            this.offerInfo_ultraGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._offerInfo_panel_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.offer_ultraToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._offerInfo_panel_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._offerInfo_panel_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._offerInfo_panel_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.offerHeader_panel = new System.Windows.Forms.Panel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.userInfo_ultraGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.user_ultraToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.userInfo_panel = new System.Windows.Forms.Panel();
            this._userInfo_panel_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._userInfo_panel_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._userInfo_panel_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._userInfo_panel_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.SFANL08200UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.userBack_panel = new System.Windows.Forms.Panel();
            this.userHeader_panel = new System.Windows.Forms.Panel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.userTitle_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._SFANL08200UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL08200UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL08200UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL08200UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL08200UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.windowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.windowDockingArea3 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.offerBack_panel.SuspendLayout();
            this.offerInfo_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offerInfo_ultraGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offer_ultraToolbarsManager)).BeginInit();
            this.offerHeader_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfo_ultraGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_ultraToolbarsManager)).BeginInit();
            this.userInfo_panel.SuspendLayout();
            this.SFANL08200UA_Fill_Panel.SuspendLayout();
            this.userBack_panel.SuspendLayout();
            this.userHeader_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).BeginInit();
            this.dockableWindow2.SuspendLayout();
            this.windowDockingArea3.SuspendLayout();
            this.SuspendLayout();
            // 
            // offerBack_panel
            // 
            this.offerBack_panel.Controls.Add(this.offerInfo_panel);
            this.offerBack_panel.Controls.Add(this.offerHeader_panel);
            this.offerBack_panel.Location = new System.Drawing.Point(0, 29);
            this.offerBack_panel.Name = "offerBack_panel";
            this.offerBack_panel.Size = new System.Drawing.Size(482, 705);
            this.offerBack_panel.TabIndex = 5;
            // 
            // offerInfo_panel
            // 
            this.offerInfo_panel.Controls.Add(this.offerInfo_ultraGrid);
            this.offerInfo_panel.Controls.Add(this._offerInfo_panel_Toolbars_Dock_Area_Left);
            this.offerInfo_panel.Controls.Add(this._offerInfo_panel_Toolbars_Dock_Area_Right);
            this.offerInfo_panel.Controls.Add(this._offerInfo_panel_Toolbars_Dock_Area_Top);
            this.offerInfo_panel.Controls.Add(this._offerInfo_panel_Toolbars_Dock_Area_Bottom);
            this.offerInfo_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.offerInfo_panel.Location = new System.Drawing.Point(0, 32);
            this.offerInfo_panel.Name = "offerInfo_panel";
            this.offerInfo_panel.Size = new System.Drawing.Size(482, 673);
            this.offerInfo_panel.TabIndex = 3;
            // 
            // offerInfo_ultraGrid
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.offerInfo_ultraGrid.DisplayLayout.Appearance = appearance1;
            this.offerInfo_ultraGrid.DisplayLayout.MaxColScrollRegions = 1;
            this.offerInfo_ultraGrid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.offerInfo_ultraGrid.DisplayLayout.Override.ActiveRowAppearance = appearance2;
            this.offerInfo_ultraGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.offerInfo_ultraGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.offerInfo_ultraGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.offerInfo_ultraGrid.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.offerInfo_ultraGrid.DisplayLayout.Override.HeaderAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.Lavender;
            this.offerInfo_ultraGrid.DisplayLayout.Override.RowAlternateAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.offerInfo_ultraGrid.DisplayLayout.Override.RowAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.White;
            this.offerInfo_ultraGrid.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.offerInfo_ultraGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.offerInfo_ultraGrid.DisplayLayout.Override.RowSelectorWidth = 12;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.offerInfo_ultraGrid.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.offerInfo_ultraGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.offerInfo_ultraGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.offerInfo_ultraGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.offerInfo_ultraGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.offerInfo_ultraGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.offerInfo_ultraGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.offerInfo_ultraGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.offerInfo_ultraGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.offerInfo_ultraGrid.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.offerInfo_ultraGrid.Location = new System.Drawing.Point(0, 27);
            this.offerInfo_ultraGrid.Name = "offerInfo_ultraGrid";
            this.offerInfo_ultraGrid.Size = new System.Drawing.Size(482, 646);
            this.offerInfo_ultraGrid.TabIndex = 1;
            this.offerInfo_ultraGrid.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.offerInfo_ultraGrid_InitializeRow);
            this.offerInfo_ultraGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.offerInfo_ultraGrid_Paint);
            this.offerInfo_ultraGrid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.offerInfo_ultraGrid_InitializeLayout);
            this.offerInfo_ultraGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.offerInfo_ultraGrid_KeyDown);
            this.offerInfo_ultraGrid.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.offerInfo_ultraGrid_CellChange);
            this.offerInfo_ultraGrid.AfterRowActivate += new System.EventHandler(this.ultraGrid_AfterRowActivate);
            // 
            // _offerInfo_panel_Toolbars_Dock_Area_Left
            // 
            this._offerInfo_panel_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._offerInfo_panel_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._offerInfo_panel_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._offerInfo_panel_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._offerInfo_panel_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 27);
            this._offerInfo_panel_Toolbars_Dock_Area_Left.Name = "_offerInfo_panel_Toolbars_Dock_Area_Left";
            this._offerInfo_panel_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 646);
            this._offerInfo_panel_Toolbars_Dock_Area_Left.ToolbarsManager = this.offer_ultraToolbarsManager;
            // 
            // offer_ultraToolbarsManager
            // 
            this.offer_ultraToolbarsManager.DesignerFlags = 1;
            this.offer_ultraToolbarsManager.DockWithinContainer = this.offerInfo_panel;
            this.offer_ultraToolbarsManager.RuntimeCustomizationOptions = ((Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions)(((Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.AllowAltClickToolDragging | Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.AllowToolbarLocking)
                        | Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.AllowImageEditing)));
            this.offer_ultraToolbarsManager.ShowFullMenusDelay = 500;
            this.offer_ultraToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.Text = "提供メニュー";
            ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3});
            this.offer_ultraToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.offer_ultraToolbarsManager.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            this.offer_ultraToolbarsManager.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            this.offer_ultraToolbarsManager.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            buttonTool4.SharedProps.Caption = "全て選択(&A)";
            buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool5.SharedProps.Caption = "全て取消(&E)";
            buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool6.SharedProps.Caption = "削除(&D)";
            buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            controlContainerTool1.SharedProps.Caption = "詳細";
            controlContainerTool1.SharedProps.Width = 140;
            this.offer_ultraToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5,
            buttonTool6,
            controlContainerTool1});
            this.offer_ultraToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.offer_ultraToolbarsManager_ToolClick);
            // 
            // _offerInfo_panel_Toolbars_Dock_Area_Right
            // 
            this._offerInfo_panel_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._offerInfo_panel_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._offerInfo_panel_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._offerInfo_panel_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._offerInfo_panel_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(482, 27);
            this._offerInfo_panel_Toolbars_Dock_Area_Right.Name = "_offerInfo_panel_Toolbars_Dock_Area_Right";
            this._offerInfo_panel_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 646);
            this._offerInfo_panel_Toolbars_Dock_Area_Right.ToolbarsManager = this.offer_ultraToolbarsManager;
            // 
            // _offerInfo_panel_Toolbars_Dock_Area_Top
            // 
            this._offerInfo_panel_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._offerInfo_panel_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._offerInfo_panel_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._offerInfo_panel_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._offerInfo_panel_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._offerInfo_panel_Toolbars_Dock_Area_Top.Name = "_offerInfo_panel_Toolbars_Dock_Area_Top";
            this._offerInfo_panel_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(482, 27);
            this._offerInfo_panel_Toolbars_Dock_Area_Top.ToolbarsManager = this.offer_ultraToolbarsManager;
            // 
            // _offerInfo_panel_Toolbars_Dock_Area_Bottom
            // 
            this._offerInfo_panel_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._offerInfo_panel_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._offerInfo_panel_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._offerInfo_panel_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._offerInfo_panel_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 673);
            this._offerInfo_panel_Toolbars_Dock_Area_Bottom.Name = "_offerInfo_panel_Toolbars_Dock_Area_Bottom";
            this._offerInfo_panel_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(482, 0);
            this._offerInfo_panel_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.offer_ultraToolbarsManager;
            // 
            // offerHeader_panel
            // 
            this.offerHeader_panel.Controls.Add(this.ultraLabel2);
            this.offerHeader_panel.Controls.Add(this.panel1);
            this.offerHeader_panel.Controls.Add(this.ultraLabel4);
            this.offerHeader_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.offerHeader_panel.Location = new System.Drawing.Point(0, 0);
            this.offerHeader_panel.Name = "offerHeader_panel";
            this.offerHeader_panel.Size = new System.Drawing.Size(482, 32);
            this.offerHeader_panel.TabIndex = 7;
            // 
            // ultraLabel2
            // 
            appearance8.ForeColor = System.Drawing.Color.Blue;
            this.ultraLabel2.Appearance = appearance8;
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(174, 8);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(197, 15);
            this.ultraLabel2.TabIndex = 8;
            this.ultraLabel2.Text = "青文字：更新されています";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(320, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 24);
            this.panel1.TabIndex = 9;
            this.panel1.Visible = false;
            // 
            // ultraLabel4
            // 
            appearance9.ForeColor = System.Drawing.Color.Red;
            this.ultraLabel4.Appearance = appearance9;
            this.ultraLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel4.Location = new System.Drawing.Point(12, 8);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(156, 15);
            this.ultraLabel4.TabIndex = 7;
            this.ultraLabel4.Text = "赤文字：未ダウンロード";
            // 
            // userInfo_ultraGrid
            // 
            appearance10.BackColor = System.Drawing.Color.White;
            appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.userInfo_ultraGrid.DisplayLayout.Appearance = appearance10;
            this.userInfo_ultraGrid.DisplayLayout.MaxColScrollRegions = 1;
            this.userInfo_ultraGrid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.userInfo_ultraGrid.DisplayLayout.Override.ActiveRowAppearance = appearance11;
            this.userInfo_ultraGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.userInfo_ultraGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.userInfo_ultraGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.userInfo_ultraGrid.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance12.ForeColor = System.Drawing.Color.White;
            appearance12.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.userInfo_ultraGrid.DisplayLayout.Override.HeaderAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.Lavender;
            this.userInfo_ultraGrid.DisplayLayout.Override.RowAlternateAppearance = appearance13;
            appearance14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.userInfo_ultraGrid.DisplayLayout.Override.RowAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.ForeColor = System.Drawing.Color.White;
            this.userInfo_ultraGrid.DisplayLayout.Override.RowSelectorAppearance = appearance15;
            this.userInfo_ultraGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.userInfo_ultraGrid.DisplayLayout.Override.RowSelectorWidth = 12;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance16.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance16.ForeColor = System.Drawing.Color.Black;
            this.userInfo_ultraGrid.DisplayLayout.Override.SelectedRowAppearance = appearance16;
            this.userInfo_ultraGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.userInfo_ultraGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.userInfo_ultraGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.userInfo_ultraGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.userInfo_ultraGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.userInfo_ultraGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.userInfo_ultraGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userInfo_ultraGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.userInfo_ultraGrid.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.userInfo_ultraGrid.Location = new System.Drawing.Point(0, 27);
            this.userInfo_ultraGrid.Name = "userInfo_ultraGrid";
            this.userInfo_ultraGrid.Size = new System.Drawing.Size(529, 646);
            this.userInfo_ultraGrid.TabIndex = 0;
            this.userInfo_ultraGrid.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.userInfo_ultraGrid_InitializeRow);
            this.userInfo_ultraGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.userInfo_ultraGrid_Paint);
            this.userInfo_ultraGrid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.userInfo_ultraGrid_InitializeLayout);
            this.userInfo_ultraGrid.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.userInfo_ultraGrid_CellChange);
            this.userInfo_ultraGrid.AfterRowActivate += new System.EventHandler(this.ultraGrid_AfterRowActivate);
            // 
            // user_ultraToolbarsManager
            // 
            this.user_ultraToolbarsManager.DesignerFlags = 1;
            this.user_ultraToolbarsManager.DockWithinContainer = this.userInfo_panel;
            this.user_ultraToolbarsManager.RuntimeCustomizationOptions = ((Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions)(((Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.AllowAltClickToolDragging | Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.AllowToolbarLocking)
                        | Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.AllowImageEditing)));
            this.user_ultraToolbarsManager.ShowFullMenusDelay = 500;
            this.user_ultraToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 0;
            ultraToolbar2.Text = "ユーザーメニュー";
            ultraToolbar2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool7,
            buttonTool8,
            buttonTool9});
            this.user_ultraToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar2});
            this.user_ultraToolbarsManager.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            this.user_ultraToolbarsManager.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            this.user_ultraToolbarsManager.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            buttonTool10.SharedProps.Caption = "全て上書き(&U)";
            buttonTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool11.SharedProps.Caption = "全て取消(&C)";
            buttonTool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool13.SharedProps.Caption = "取消(&W)";
            buttonTool13.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            controlContainerTool2.SharedProps.Caption = "詳細";
            this.user_ultraToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            controlContainerTool2});
            this.user_ultraToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.user_ultraToolbarsManager_ToolClick);
            // 
            // userInfo_panel
            // 
            this.userInfo_panel.Controls.Add(this.userInfo_ultraGrid);
            this.userInfo_panel.Controls.Add(this._userInfo_panel_Toolbars_Dock_Area_Left);
            this.userInfo_panel.Controls.Add(this._userInfo_panel_Toolbars_Dock_Area_Right);
            this.userInfo_panel.Controls.Add(this._userInfo_panel_Toolbars_Dock_Area_Top);
            this.userInfo_panel.Controls.Add(this._userInfo_panel_Toolbars_Dock_Area_Bottom);
            this.userInfo_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userInfo_panel.Location = new System.Drawing.Point(0, 61);
            this.userInfo_panel.Name = "userInfo_panel";
            this.userInfo_panel.Size = new System.Drawing.Size(529, 673);
            this.userInfo_panel.TabIndex = 4;
            // 
            // _userInfo_panel_Toolbars_Dock_Area_Left
            // 
            this._userInfo_panel_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._userInfo_panel_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._userInfo_panel_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._userInfo_panel_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._userInfo_panel_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 27);
            this._userInfo_panel_Toolbars_Dock_Area_Left.Name = "_userInfo_panel_Toolbars_Dock_Area_Left";
            this._userInfo_panel_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 646);
            this._userInfo_panel_Toolbars_Dock_Area_Left.ToolbarsManager = this.user_ultraToolbarsManager;
            // 
            // _userInfo_panel_Toolbars_Dock_Area_Right
            // 
            this._userInfo_panel_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._userInfo_panel_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._userInfo_panel_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._userInfo_panel_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._userInfo_panel_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(529, 27);
            this._userInfo_panel_Toolbars_Dock_Area_Right.Name = "_userInfo_panel_Toolbars_Dock_Area_Right";
            this._userInfo_panel_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 646);
            this._userInfo_panel_Toolbars_Dock_Area_Right.ToolbarsManager = this.user_ultraToolbarsManager;
            // 
            // _userInfo_panel_Toolbars_Dock_Area_Top
            // 
            this._userInfo_panel_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._userInfo_panel_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._userInfo_panel_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._userInfo_panel_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._userInfo_panel_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._userInfo_panel_Toolbars_Dock_Area_Top.Name = "_userInfo_panel_Toolbars_Dock_Area_Top";
            this._userInfo_panel_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(529, 27);
            this._userInfo_panel_Toolbars_Dock_Area_Top.ToolbarsManager = this.user_ultraToolbarsManager;
            // 
            // _userInfo_panel_Toolbars_Dock_Area_Bottom
            // 
            this._userInfo_panel_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._userInfo_panel_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._userInfo_panel_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._userInfo_panel_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._userInfo_panel_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 673);
            this._userInfo_panel_Toolbars_Dock_Area_Bottom.Name = "_userInfo_panel_Toolbars_Dock_Area_Bottom";
            this._userInfo_panel_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(529, 0);
            this._userInfo_panel_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.user_ultraToolbarsManager;
            // 
            // SFANL08200UA_Fill_Panel
            // 
            this.SFANL08200UA_Fill_Panel.Controls.Add(this.userBack_panel);
            this.SFANL08200UA_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SFANL08200UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SFANL08200UA_Fill_Panel.Location = new System.Drawing.Point(487, 0);
            this.SFANL08200UA_Fill_Panel.Name = "SFANL08200UA_Fill_Panel";
            this.SFANL08200UA_Fill_Panel.Size = new System.Drawing.Size(529, 734);
            this.SFANL08200UA_Fill_Panel.TabIndex = 0;
            // 
            // userBack_panel
            // 
            this.userBack_panel.Controls.Add(this.userInfo_panel);
            this.userBack_panel.Controls.Add(this.userHeader_panel);
            this.userBack_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userBack_panel.Location = new System.Drawing.Point(0, 0);
            this.userBack_panel.Name = "userBack_panel";
            this.userBack_panel.Size = new System.Drawing.Size(529, 734);
            this.userBack_panel.TabIndex = 6;
            // 
            // userHeader_panel
            // 
            this.userHeader_panel.Controls.Add(this.ultraLabel3);
            this.userHeader_panel.Controls.Add(this.userTitle_ultraLabel);
            this.userHeader_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.userHeader_panel.Location = new System.Drawing.Point(0, 0);
            this.userHeader_panel.Name = "userHeader_panel";
            this.userHeader_panel.Size = new System.Drawing.Size(529, 61);
            this.userHeader_panel.TabIndex = 6;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel3.Location = new System.Drawing.Point(12, 36);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(417, 15);
            this.ultraLabel3.TabIndex = 7;
            this.ultraLabel3.Text = "提供情報のまま更新したい場合は「上書き」にチェックして下さい";
            // 
            // userTitle_ultraLabel
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance17.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance17.BorderColor = System.Drawing.Color.Blue;
            appearance17.FontData.BoldAsString = "True";
            appearance17.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance17.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.userTitle_ultraLabel.Appearance = appearance17;
            this.userTitle_ultraLabel.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.userTitle_ultraLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.userTitle_ultraLabel.Location = new System.Drawing.Point(0, 0);
            this.userTitle_ultraLabel.Name = "userTitle_ultraLabel";
            this.userTitle_ultraLabel.Size = new System.Drawing.Size(529, 28);
            this.userTitle_ultraLabel.TabIndex = 5;
            this.userTitle_ultraLabel.Text = "ダウンロード済みの印字位置情報";
            this.userTitle_ultraLabel.WrapText = false;
            // 
            // ultraToolTipManager1
            // 
            appearance18.FontData.Name = "ＭＳ ゴシック";
            this.ultraToolTipManager1.Appearance = appearance18;
            appearance19.FontData.Name = "ＭＳ ゴシック";
            this.ultraToolTipManager1.ToolTipTitleAppearance = appearance19;
            // 
            // ultraDockManager1
            // 
            this.ultraDockManager1.AnimationSpeed = Infragistics.Win.UltraWinDock.AnimationSpeed.StandardSpeedPlus5;
            this.ultraDockManager1.AutoHideDelay = 0;
            dockAreaPane1.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit;
            dockAreaPane1.DockedBefore = new System.Guid("7605e019-0d99-4029-9ce4-59e6c239ddfd");
            dockAreaPane1.FloatingLocation = new System.Drawing.Point(78, 252);
            dockAreaPane1.Size = new System.Drawing.Size(482, 734);
            dockAreaPane2.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit;
            dockAreaPane2.FloatingLocation = new System.Drawing.Point(78, 252);
            dockableControlPane1.Control = this.offerBack_panel;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(93, -1);
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(12, 32, 328, 460);
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Settings.AllowPin = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Size = new System.Drawing.Size(336, 661);
            dockableControlPane1.Text = "現在提供されている印字位置情報";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane2.Size = new System.Drawing.Size(482, 734);
            this.ultraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2});
            this.ultraDockManager1.HostControl = this;
            this.ultraDockManager1.ShowCloseButton = false;
            this.ultraDockManager1.ShowDisabledButtons = false;
            this.ultraDockManager1.UnpinnedTabStyle = Infragistics.Win.UltraWinTabs.TabStyle.PropertyPage2003;
            this.ultraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _SFANL08200UAUnpinnedTabAreaLeft
            // 
            this._SFANL08200UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._SFANL08200UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08200UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._SFANL08200UAUnpinnedTabAreaLeft.Name = "_SFANL08200UAUnpinnedTabAreaLeft";
            this._SFANL08200UAUnpinnedTabAreaLeft.Owner = this.ultraDockManager1;
            this._SFANL08200UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 734);
            this._SFANL08200UAUnpinnedTabAreaLeft.TabIndex = 29;
            // 
            // _SFANL08200UAUnpinnedTabAreaRight
            // 
            this._SFANL08200UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._SFANL08200UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08200UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(1016, 0);
            this._SFANL08200UAUnpinnedTabAreaRight.Name = "_SFANL08200UAUnpinnedTabAreaRight";
            this._SFANL08200UAUnpinnedTabAreaRight.Owner = this.ultraDockManager1;
            this._SFANL08200UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 734);
            this._SFANL08200UAUnpinnedTabAreaRight.TabIndex = 30;
            // 
            // _SFANL08200UAUnpinnedTabAreaTop
            // 
            this._SFANL08200UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._SFANL08200UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08200UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._SFANL08200UAUnpinnedTabAreaTop.Name = "_SFANL08200UAUnpinnedTabAreaTop";
            this._SFANL08200UAUnpinnedTabAreaTop.Owner = this.ultraDockManager1;
            this._SFANL08200UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(1016, 0);
            this._SFANL08200UAUnpinnedTabAreaTop.TabIndex = 31;
            // 
            // _SFANL08200UAUnpinnedTabAreaBottom
            // 
            this._SFANL08200UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._SFANL08200UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08200UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 734);
            this._SFANL08200UAUnpinnedTabAreaBottom.Name = "_SFANL08200UAUnpinnedTabAreaBottom";
            this._SFANL08200UAUnpinnedTabAreaBottom.Owner = this.ultraDockManager1;
            this._SFANL08200UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1016, 0);
            this._SFANL08200UAUnpinnedTabAreaBottom.TabIndex = 32;
            // 
            // _SFANL08200UAAutoHideControl
            // 
            this._SFANL08200UAAutoHideControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08200UAAutoHideControl.Location = new System.Drawing.Point(23, 65);
            this._SFANL08200UAAutoHideControl.Name = "_SFANL08200UAAutoHideControl";
            this._SFANL08200UAAutoHideControl.Owner = this.ultraDockManager1;
            this._SFANL08200UAAutoHideControl.Size = new System.Drawing.Size(165, 646);
            this._SFANL08200UAAutoHideControl.TabIndex = 33;
            // 
            // dockableWindow2
            // 
            this.dockableWindow2.Controls.Add(this.offerBack_panel);
            this.dockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow2.Name = "dockableWindow2";
            this.dockableWindow2.Owner = this.ultraDockManager1;
            this.dockableWindow2.Size = new System.Drawing.Size(482, 734);
            this.dockableWindow2.TabIndex = 0;
            // 
            // windowDockingArea2
            // 
            this.windowDockingArea2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowDockingArea2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea2.Location = new System.Drawing.Point(4, 4);
            this.windowDockingArea2.Name = "windowDockingArea2";
            this.windowDockingArea2.Owner = this.ultraDockManager1;
            this.windowDockingArea2.Size = new System.Drawing.Size(482, 734);
            this.windowDockingArea2.TabIndex = 0;
            // 
            // windowDockingArea3
            // 
            this.windowDockingArea3.Controls.Add(this.dockableWindow2);
            this.windowDockingArea3.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea3.Location = new System.Drawing.Point(0, 0);
            this.windowDockingArea3.Name = "windowDockingArea3";
            this.windowDockingArea3.Owner = this.ultraDockManager1;
            this.windowDockingArea3.Size = new System.Drawing.Size(487, 734);
            this.windowDockingArea3.TabIndex = 35;
            // 
            // SFANL08200UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this._SFANL08200UAAutoHideControl);
            this.Controls.Add(this.SFANL08200UA_Fill_Panel);
            this.Controls.Add(this.windowDockingArea3);
            this.Controls.Add(this._SFANL08200UAUnpinnedTabAreaTop);
            this.Controls.Add(this._SFANL08200UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._SFANL08200UAUnpinnedTabAreaLeft);
            this.Controls.Add(this._SFANL08200UAUnpinnedTabAreaRight);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFANL08200UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "帳票印字位置ダウンロード";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SFANL08200UA_Paint);
            this.Load += new System.EventHandler(this.SFANL08200UA_Load);
            this.offerBack_panel.ResumeLayout(false);
            this.offerInfo_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.offerInfo_ultraGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offer_ultraToolbarsManager)).EndInit();
            this.offerHeader_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userInfo_ultraGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_ultraToolbarsManager)).EndInit();
            this.userInfo_panel.ResumeLayout(false);
            this.SFANL08200UA_Fill_Panel.ResumeLayout(false);
            this.userBack_panel.ResumeLayout(false);
            this.userHeader_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).EndInit();
            this.dockableWindow2.ResumeLayout(false);
            this.windowDockingArea3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Entry Point
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
            System.Windows.Forms.Application.Run(new SFANL08200UA());
        }
		#endregion
		
		#region Private Member
		/// <summary>印字位置ダウンロード画面アクセスクラス</summary>
		private DownLoadPrtPosAcs _downLoadPrtPosAcs = null;

		/// <summary>表示用データセット</summary>
		private DataSet _dataSet = null;

		/// <summary>データビュー(提供)</summary>
		private DataView _offerDataView = null;

		/// <summary>データビュー(ユーザー)</summary>
		private DataView _userDataView = null;
       
        /// <summary>企業コード</summary>
        private string _enterpriseCode = null;

        /// <summary>印字位置削除用アクセスクラス</summary>
        private SFANL08230AE _sfanl08230ae = new SFANL08230AE();

        ///// <summary>自由帳票メンテナンスオプションフラグ</summary>
        //private bool _optFreeSheetgMng = false;			
    	#endregion

		#region Private Const Member
		/// <summary>グリッド設定ファイル名</summary>
		private const string FILENAME_GRIDSTATE	= "SFANL08200UA.DAT";
        /// <summary>ダウンロード開始ボタン</summary>
        private const string CT_DOWNLOAD_BUTTONTOOL = "DownLoad_ButtonTool";
        /// <summary>最新の情報に更新ボタン</summary>
        private const string CT_RELOAD_BUTTONTOOL = "Reload_ButtonTool";

        //--- メッセージ系 ------------------------------------------
        /// <summary>起動中ダイアログのタイトル</summary>
        private const string ctInitializeDL_TITLE = "データ読込み処理";
        /// <summary>起動中ダイアログのメッセージ</summary>
        private const string ctInitializeDL_MESSAGE = "データを取得中です・・・";                        

        /// <summary>ダウンロード中ダイアログのタイトル</summary>
        private const string ctDownLoad_TITLE = "印字位置ダウンロード処理";
        /// <summary>ダウンロード中ダイアログのメッセージ</summary>
        private const string ctDownLoad_MESSAGE = "印字位置情報をダウンロード中です・・・";

        /// <summary>情報更新中ダイアログのタイトル</summary>
        private const string ctReLoad_TITLE = "情報更新処理";
        /// <summary>情報更新中ダイアログのメッセージ</summary>
        private const string ctReLoad_MESSAGE = "最新情報を取得中です・・・";

        /// <summary>情報更新中ダイアログのタイトル</summary>
        private const string ctDelete_TITLE = "印字位置削除処理";
        /// <summary>情報更新中ダイアログのメッセージ</summary>
        private const string ctDelete_MESSAGE = "印字位置情報を削除中です・・・";

        #endregion

        # region Public Method
        # endregion

        #region Private Method

        #region 初期画面設定
        /// <summary>
        /// 初期画面設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期画面設定を行います。</br>
        /// <br>Programmer : 22011 柏原　頼人</br>
        /// <br>Date       : 2007.05.14</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki　保留
            //// 自由帳票メンテナンスオプション有無取得
            //PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_FreeSheetgMng);
            PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB( ConstantManagement_SF_PRO.SoftwareCode_PAC_PM );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki　保留

            if (status < PurchaseStatus.Contract)
            {
                //_optFreeSheetgMng = false;
                this.offer_ultraToolbarsManager.Tools["OfferDel_ButtonTool"].SharedProps.Visible = false;
            }
            else
            {
                //_optFreeSheetgMng = true;
                this.offer_ultraToolbarsManager.Tools["OfferDel_ButtonTool"].SharedProps.Visible = true;
            }

            // ツールバー設定
            this.offer_ultraToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            this.offer_ultraToolbarsManager.Tools["OfferAllSelect_ButtonTool"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLSELECT;
            this.offer_ultraToolbarsManager.Tools["OfferAllCancel_ButtonTool"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this.offer_ultraToolbarsManager.Tools["OfferDel_ButtonTool"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;            

            this.user_ultraToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            this.user_ultraToolbarsManager.Tools["UserAllUpdate_ButtonTool"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLSELECT;
            this.user_ultraToolbarsManager.Tools["UserAllCancel_ButtonTool"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this.user_ultraToolbarsManager.Tools["UserAddCancel_ButtonTool"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWCUT;
            this.MakeKeyMappingForGrid(this.userInfo_ultraGrid);
            this.MakeKeyMappingForGrid(this.offerInfo_ultraGrid);

            //メインツールバー設定
            List<string> editMenuKeyLs = new List<string>();
            editMenuKeyLs.Add(FreeSheetConst.ctToolBase_Save);
            editMenuKeyLs.Add(FreeSheetConst.ctToolBase_New);
            editMenuKeyLs.Add(FreeSheetConst.ctToolBase_Open);
            editMenuKeyLs.Add(FreeSheetConst.ctToolBase_Print);
            editMenuKeyLs.Add(FreeSheetConst.ctPopupMenu_Help);
            editMenuKeyLs.Add(FreeSheetConst.ctPopupMenu_Edit);
            editMenuKeyLs.Add(FreeSheetConst.ctPopupMenu_Window);

            //表示変更のイベントをキック
            ToolButtonVisibleChanged(editMenuKeyLs, false);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ToolButtonEnableChanged( editMenuKeyLs, false );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        #endregion 初期画面設定

        /// <summary>
		/// ＤＢ情報表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面の初期設定を行います。</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private void ShowDBData()
        {
            string errmsg;
            //DBの読込
            int status = this._downLoadPrtPosAcs.ReadDBData(out errmsg);
            if (status != 0)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFANL08200U", errmsg, status, MessageBoxButtons.OK);
                return;
            }

            //データソースの設定
            this._downLoadPrtPosAcs.ReadStaticData(out this._dataSet);
        }

		/// <summary>
		/// データビューフィルタ処理
		/// </summary>
		private void FilterDataView()
        {
            // 印字位置（ユーザー）
            if (this._userDataView != null)
                this._userDataView.Sort = DownLoadPrtPosAcs.COL_USER_OUTPUTFORMFILENAME + " ASC, " +
                    DownLoadPrtPosAcs.COL_USER_USERPRTPPRIDDERIVNO + " ASC ";
            // 印字位置（提供）
            if (this._offerDataView != null)
                this._offerDataView.Sort = DownLoadPrtPosAcs.COL_OFFER_OUTPUTFORMFILENAME + " ASC, " +
                    DownLoadPrtPosAcs.COL_OFFER_USERPRTPPRIDDERIVNO + " ASC ";
        }

		/// <summary>
		/// グリッドのキーマッピングを設定します。
		/// </summary>
		/// <param name="grid">設定対象のグリッド</param>
		/// <remarks>
		/// <br>Note		: 画面の初期設定を行います。</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
		{
			GridKeyActionMapping enterMap;
			
			// Enterキー
			enterMap = new GridKeyActionMapping(Keys.Enter,
				UltraGridAction.NextCellByTab,
				0,
				UltraGridState.Cell,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			// Shift + Enterキー
			enterMap = new GridKeyActionMapping(Keys.Enter,
				UltraGridAction.PrevCellByTab,
				0,
				UltraGridState.Cell,
				SpecialKeys.AltCtrl,
				SpecialKeys.Shift);
			grid.KeyActionMappings.Add(enterMap);

			// ↑キー
			enterMap = new GridKeyActionMapping(Keys.Up,
				UltraGridAction.AboveCell,
				UltraGridState.IsCheckbox,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			// ↓キー
			enterMap  = new GridKeyActionMapping(Keys.Down,
				UltraGridAction.BelowCell,
				UltraGridState.IsCheckbox,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			// 前頁キー
			enterMap  = new GridKeyActionMapping(Keys.Prior,
				UltraGridAction.PageUpCell,
				0,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			// 次頁キー
			enterMap  = new GridKeyActionMapping(Keys.Next,
				UltraGridAction.PageDownCell,
				0,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);
		}

        /// <summary>
        /// アクティブセルの非アクティブ化
        /// </summary>
        /// <param name="grid"></param>
        private void DeactiveActiveCell(UltraGrid grid)
		{
			UltraGridCell activeCell = grid.ActiveCell;
			if (activeCell != null)
			{
				if (activeCell.IsInEditMode)
				{
					grid.PerformAction(UltraGridAction.DeactivateCell);
				}
			}
        }

        /// <summary>
		/// グリッド(提供) 全て選択・全て取消処理
		/// </summary>
		/// <param name="isSelect">true:選択,false:取消</param>
		private void SelectGridAll_Offer(bool isSelect)
		{
			this.DeactiveActiveCell(this.userInfo_ultraGrid);
			this.DeactiveActiveCell(this.offerInfo_ultraGrid);

			UltraGrid grid = this.offerInfo_ultraGrid;
			ArrayList keyList = new ArrayList();

			foreach (UltraGridRow row in grid.Rows)
			{
				if (row.IsFilteredOut) continue;
				keyList.Add(row.Cells[DownLoadPrtPosAcs.COL_OFFER_KEY].Text);
			}

			string[] keys = (string[])keyList.ToArray(typeof(string));
			this._downLoadPrtPosAcs.ChangeSelect_Offer(keys, isSelect);
		}

		/// <summary>
		/// グリッド(ユーザー) 全て更新
		/// </summary>
		/// <param name="update">1:全て更新</param>
		/// <remarks>
		/// <br>Note		: 引数が0の場合は全て取消</br>
		/// </remarks>
		private void SelectGridAll_User(int update)
		{
			this.DeactiveActiveCell(this.userInfo_ultraGrid);
			this.DeactiveActiveCell(this.offerInfo_ultraGrid);

			UltraGrid grid = this.userInfo_ultraGrid;
			ArrayList keyList = new ArrayList();

			foreach (UltraGridRow row in grid.Rows)
			{
				if (row.IsFilteredOut) continue;
				keyList.Add(row.Cells[DownLoadPrtPosAcs.COL_USER_KEY].Text);
			}

			string[] keys = (string[])keyList.ToArray(typeof(string));
			this._downLoadPrtPosAcs.ChangeSelect_User(keys, update);
		}

		/// <summary>
		/// グリッド（ユーザー）取消
		/// </summary>
		private void CancelGrid_User()
		{
            this.DeactiveActiveCell(this.userInfo_ultraGrid);
            this.DeactiveActiveCell(this.offerInfo_ultraGrid);

            UltraGridRow row = this.userInfo_ultraGrid.ActiveRow;
            if (row != null)
            {
                string[] keys = new string[1];
                keys[0] = row.Cells[DownLoadPrtPosAcs.COL_USER_KEY].Text;
                this._downLoadPrtPosAcs.ChangeSelect_User(keys, 0);
            }
		}

		/// <summary>
		/// 上書き選択件数取得
		/// </summary>
		/// <param name="updateCount">上書き件数</param>
		private void GetSelectCount(out int updateCount)
		{
			updateCount = 0;
			foreach (DataRow row in this._dataSet.Tables[DownLoadPrtPosAcs.TABLE_USER].Rows)
			{
				if (DownLoadPrtPosAcs.ConvertToInt32(row[DownLoadPrtPosAcs.COL_USER_SELECT_UPDATE]) != 0)
				{
					updateCount++;
				}
			}
        }

        /// <summary>
		/// 印字位置情報グリッド ツールチップ表示
		/// </summary>
		private void ShowToolTip(UltraGrid grid)
		{
            if (grid == null) return;
			string tableName = string.Empty;
			if (grid == this.userInfo_ultraGrid)
			{
				tableName = DownLoadPrtPosAcs.TABLE_USER;
			}
			else
			if (grid == this.offerInfo_ultraGrid)
			{
				tableName = DownLoadPrtPosAcs.TABLE_OFFER;
			}
			else
			{
				return;
			}

			this.ultraToolTipManager1.HideToolTip();

			Point point = grid.PointToClient(Cursor.Position);
            UIElement uiElement = grid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (uiElement == null) return;
            UltraGridRow row = (UltraGridRow)uiElement.GetContext(typeof(UltraGridRow));

			if ((row != null) && (row.Index >= 0))
			{
				string tipCaption = string.Empty;
				if ((grid == this.userInfo_ultraGrid) && (row.Band.Key == tableName))
				{
					UltraGridBand band = grid.DisplayLayout.Bands[tableName];
	                tipCaption += string.Format("\n{0,-25}：{1}", band.Columns[DownLoadPrtPosAcs.COL_USER_DISPLAYNAME].Header.Caption, row.Cells[DownLoadPrtPosAcs.COL_USER_DISPLAYNAME].Text);
                    tipCaption += string.Format("\n{0,-25}：{1}", band.Columns[DownLoadPrtPosAcs.COL_USER_PRTPPRUSERDERIVNOCMT].Header.Caption, row.Cells[DownLoadPrtPosAcs.COL_USER_PRTPPRUSERDERIVNOCMT].Text);
                    tipCaption += string.Format("\n{0,-22}：{1}", band.Columns[DownLoadPrtPosAcs.COL_USER_OUTPUTFORMFILENAME].Header.Caption, row.Cells[DownLoadPrtPosAcs.COL_USER_PRINTPAPERUSEDIVCDNM].Text);
                    tipCaption += string.Format("\n{0,-21}：{1}", band.Columns[DownLoadPrtPosAcs.COL_USER_UPDATETIME].Header.Caption, row.Cells[DownLoadPrtPosAcs.COL_USER_UPDATETIME].Text);
                    tipCaption += string.Format("\n{0,-25}：{1}", band.Columns[DownLoadPrtPosAcs.COL_USER_SYSTEMDIVNAME].Header.Caption, row.Cells[DownLoadPrtPosAcs.COL_USER_SYSTEMDIVNAME].Text);
                }
				else
				if ((grid == this.offerInfo_ultraGrid) && (row.Band.Key == tableName))
				{
					UltraGridBand band = grid.DisplayLayout.Bands[tableName];
                    tipCaption += string.Format("\n{0,-25}：{1}", band.Columns[DownLoadPrtPosAcs.COL_OFFER_DISPLAYNAME].Header.Caption, row.Cells[DownLoadPrtPosAcs.COL_OFFER_DISPLAYNAME].Text);
                    tipCaption += string.Format("\n{0,-25}：{1}", band.Columns[DownLoadPrtPosAcs.COL_OFFER_PRTPPRUSERDERIVNOCMT].Header.Caption, row.Cells[DownLoadPrtPosAcs.COL_OFFER_PRTPPRUSERDERIVNOCMT].Text);
                    tipCaption += string.Format("\n{0,-22}：{1}", band.Columns[DownLoadPrtPosAcs.COL_OFFER_OUTPUTFORMFILENAME].Header.Caption, row.Cells[DownLoadPrtPosAcs.COL_OFFER_PRINTPAPERUSEDIVCDNM].Text);
                    tipCaption += string.Format("\n{0,-21}：{1}", band.Columns[DownLoadPrtPosAcs.COL_OFFER_UPDATETIMESTR].Header.Caption, row.Cells[DownLoadPrtPosAcs.COL_OFFER_UPDATETIMESTR].Text);
                    tipCaption += string.Format("\n{0,-25}：{1}", band.Columns[DownLoadPrtPosAcs.COL_OFFER_SYSTEMDIVNAME].Header.Caption, row.Cells[DownLoadPrtPosAcs.COL_OFFER_SYSTEMDIVNAME].Text);
                }
				if (tipCaption != string.Empty)
				{
					this.ultraToolTipManager1.SetUltraToolTip(grid, 
						new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo(tipCaption, ToolTipImage.Info, "印字位置情報", DefaultableBoolean.True));
					this.ultraToolTipManager1.ShowToolTip(grid);
				}
			}
		}
		#endregion

		#region Control Event
		/// <summary>
		/// フォームロード
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void SFANL08200UA_Load(object sender, System.EventArgs e)
        {
            // 初期画面設定
            InitialScreenSetting();
            //イベント追加
            this.offerInfo_ultraGrid.MouseLeaveElement += new Infragistics.Win.UIElementEventHandler(this.grids_MouseLeaveElement);
            this.userInfo_ultraGrid.MouseLeaveElement += new Infragistics.Win.UIElementEventHandler(this.grids_MouseLeaveElement);
            this.offerInfo_ultraGrid.Click += new System.EventHandler(this.offerInfo_ultraGrid_Click);
            this.userInfo_ultraGrid.Click += new System.EventHandler(this.userInfo_ultraGrid_Click);
        }

		/// <summary>
		/// フォームペイント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void SFANL08200UA_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            string errmsg;
            // 共通処理中画面生成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();

            try
            {
                // 共通処理中画面プロパティ設定
                form.Title = ctInitializeDL_TITLE;           // 画面のタイトル部分に表示する文字列
                form.Message = ctInitializeDL_MESSAGE;       // 画面のプログレスバーの上に表示する文字列
                form.DispCancelButton = false;              // キャンセルボタン押下による中断機能（デフォルトはＯＦＦ）
                form.Show(Owner);                           // 共通処理中画面表示

                int status = this._downLoadPrtPosAcs.ReadDBData(out errmsg);
                if (status != 0)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFANL08200U", errmsg, status, MessageBoxButtons.OK);
                    return;
                }

                //不要データ削除処理
                bool msgDiv;
                status = _downLoadPrtPosAcs.DeleteLonelyLocalData(out msgDiv, out errmsg);
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFANL08200U", errmsg, status, MessageBoxButtons.OK);
                }

                this._downLoadPrtPosAcs.ReadStaticData(out this._dataSet);

                if (this._dataSet.Tables[DownLoadPrtPosAcs.TABLE_USER] != null)
                {
                    this._userDataView = new DataView(this._dataSet.Tables[DownLoadPrtPosAcs.TABLE_USER]);
                    this.userInfo_ultraGrid.DataSource = this._userDataView;
                    UltraGridBand userBand = this.userInfo_ultraGrid.DisplayLayout.Bands[DownLoadPrtPosAcs.TABLE_USER];
                }
                if (this._dataSet.Tables[DownLoadPrtPosAcs.TABLE_OFFER] != null)
                {
                    this._offerDataView = new DataView(this._dataSet.Tables[DownLoadPrtPosAcs.TABLE_OFFER]);
                    this.offerInfo_ultraGrid.DataSource = this._offerDataView;
                    UltraGridBand offerBand = this.offerInfo_ultraGrid.DisplayLayout.Bands[DownLoadPrtPosAcs.TABLE_OFFER];
                }
                this.FilterDataView();
            }
            finally
            {
                form.Close();
                //イベント削除
                this.Paint -= new System.Windows.Forms.PaintEventHandler(this.SFANL08200UA_Paint);
            }
        }

		/// <summary>
		/// 提供ツールボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void offer_ultraToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			if (e.Tool.Key == "OfferAllSelect_ButtonTool")
			{
				this.SelectGridAll_Offer(true);
			}
			else if (e.Tool.Key == "OfferAllCancel_ButtonTool")
			{
				this.SelectGridAll_Offer(false);
            }
            else if (e.Tool.Key == "OfferDel_ButtonTool")
            {
                FrePrtPSetWork psetwk = new FrePrtPSetWork();
                string errmsg;
                bool msgdiv;
                int status = 0;

                if (offerInfo_ultraGrid.Rows.Count == 0) return;
                if (offerInfo_ultraGrid.ActiveRow == null) return;
                int index = offerInfo_ultraGrid.ActiveRow.Index;
                DataRow newDr = _offerDataView[index].Row;

                string msg = ((string)newDr[DownLoadPrtPosAcs.COL_OFFER_DISPLAYNAME]) + "\n\r\n\rデータベースから印字位置データを削除します\n\r削除すると元に戻すことはできません\n\r実行しますか？";
                DialogResult dialogResult = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFANL08200U", msg, 0, MessageBoxButtons.OKCancel);
                
                if (dialogResult == DialogResult.OK)
                {
                    // 共通処理中画面生成
                    Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                    try
                    {
                        bool msgDiv = false;
                        // 共通処理中画面プロパティ設定
                        form.Title = ctDelete_TITLE;            // 画面のタイトル部分に表示する文字列
                        form.Message = ctDelete_MESSAGE;        // 画面のプログレスバーの上に表示する文字列
                        form.DispCancelButton = false;         // キャンセルボタン押下による中断機能（デフォルトはＯＦＦ）
                        form.Show(Owner);                       // 共通処理中画面表示

                        //key情報セット
                        psetwk.EnterpriseCode = this._enterpriseCode;
                        psetwk.OutputFormFileName = (string)newDr[DownLoadPrtPosAcs.COL_OFFER_OUTPUTFORMFILENAME];
                        psetwk.UserPrtPprIdDerivNo = (int)newDr[DownLoadPrtPosAcs.COL_OFFER_USERPRTPPRIDDERIVNO];
                        psetwk.UpdateDateTime = (DateTime)newDr[DownLoadPrtPosAcs.COL_OFFER_UPDATETIME];
                        psetwk.DataInputSystem = (int)newDr[DownLoadPrtPosAcs.COL_OFFER_SYSTEMDIVCD];
                        psetwk.PrintPaperUseDivcd = (int)newDr[DownLoadPrtPosAcs.COL_OFFER_PRINTPAPERUSEDIVCD];
                        psetwk.FreePrtPprItemGrpCd = (int)newDr[DownLoadPrtPosAcs.COL_OFFER_FREEPRTPPRITEMGRPCD];
                        psetwk.TakeInImageGroupCd = (Guid)newDr[DownLoadPrtPosAcs.COL_OFFER_TAKEINIMAGEGROUPCD];

                        //削除
                        status = _sfanl08230ae.Delete(psetwk, out msgdiv, out errmsg);
                        
                        // 既に更新が掛かっていたとき
                        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                        {
                            TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "SFANL08200U", "既に他端末より更新されています", 0, MessageBoxButtons.OK);
                            return;
                        }
                        // 既に削除されていたとき
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                        {
                            TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "SFANL08200U", "既に他端末で削除されています", 0, MessageBoxButtons.OK);
                            return;
                        }
                        else if (status != 0)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFANL08200U", errmsg, status, MessageBoxButtons.OK);
                            return;
                        }
                        //データソースの設定
                        _downLoadPrtPosAcs.DeleteOfferCash((string)newDr[DownLoadPrtPosAcs.COL_OFFER_KEY]);
                        status = _downLoadPrtPosAcs.DeleteLonelyLocalData(out msgDiv, out errmsg);
                        if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFANL08200U", errmsg, status, MessageBoxButtons.OK);
                        }
                        this._downLoadPrtPosAcs.ReadStaticData(out this._dataSet);
                    }
                    finally
                    {
                        form.Close();
                    }
                }
            }
        }
		
		/// <summary>
		/// ユーザーツールボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void user_ultraToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			if (e.Tool.Key == "UserAllUpdate_ButtonTool")
			{
				this.SelectGridAll_User(1);
            }
            else
				if (e.Tool.Key == "UserAllCancel_ButtonTool")
			{
				this.SelectGridAll_User(0);
			}
			else
				if (e.Tool.Key == "UserAddCancel_ButtonTool")
			{
				this.CancelGrid_User();
			}
        }

        /// <summary>
        /// ダウンロード済み印字位置情報表示内容切り替え処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userDetail_ultraCheckEditor_CheckedChanged(object sender, System.EventArgs e)
		{
			UltraGridBand band = this.userInfo_ultraGrid.DisplayLayout.Bands[DownLoadPrtPosAcs.TABLE_USER];
			this.ChangeHidden_userInfo_ultraGrid(band);
		}

        /// <summary>
        /// 未ダウンロード印字位置情報表示内容切り替え処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void offerDetail_ultraCheckEditor_CheckedChanged(object sender, System.EventArgs e)
		{
			UltraGridBand band = this.offerInfo_ultraGrid.DisplayLayout.Bands[DownLoadPrtPosAcs.TABLE_OFFER];
			this.ChangeHidden_offerInfo_ultraGrid(band);
		}
		#endregion

		#region UserGrid Event
        /// <summary>
        /// グリッド概観設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void userInfo_ultraGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			UltraGridBand band = e.Layout.Bands[DownLoadPrtPosAcs.TABLE_USER];
			band.Columns[DownLoadPrtPosAcs.COL_USER_SELECT_UPDATE		].CellActivation	= Activation.AllowEdit;
            band.Columns[DownLoadPrtPosAcs.COL_USER_EXISTFLG			].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_USER_UPDATEFLG			].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_USER_STATUS				].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_USER_KEY					].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_USER_DISPLAYNAME			].CellActivation	= Activation.NoEdit;
            band.Columns[DownLoadPrtPosAcs.COL_USER_USERPRTPPRIDDERIVNO	].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_USER_PRTPPRUSERDERIVNOCMT].CellActivation	= Activation.NoEdit;
            band.Columns[DownLoadPrtPosAcs.COL_USER_FREEPRTPPRITEMGRPCD ].CellActivation    = Activation.NoEdit;
            band.Columns[DownLoadPrtPosAcs.COL_USER_UPDATETIME			].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_USER_SYSTEMDIVCD			].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_USER_SYSTEMDIVNAME		].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_USER_OPTIONCODE			].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_USER_OPTIONNAME			].CellActivation	= Activation.NoEdit;
            band.Columns[DownLoadPrtPosAcs.COL_USER_PRINTPAPERUSEDIVCD  ].CellActivation    = Activation.NoEdit;
            band.Columns[DownLoadPrtPosAcs.COL_USER_PRINTPAPERUSEDIVCDNM].CellActivation    = Activation.NoEdit;
			
			// カラム表示状態
			ChangeHidden_userInfo_ultraGrid(band);
			band.Columns[DownLoadPrtPosAcs.COL_USER_SELECT_UPDATE		].Style				= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
    
			e.Layout.UseFixedHeaders = true;
			e.Layout.Override.FixedCellSeparatorColor = Color.Red;

			band.Columns[DownLoadPrtPosAcs.COL_USER_SELECT_UPDATE		].Header.Fixed		= true;
			band.Columns[DownLoadPrtPosAcs.COL_USER_SELECT_UPDATE		].MinWidth			= 40;
            band.Columns[DownLoadPrtPosAcs.COL_USER_SELECT_UPDATE].Width                    = 50;
            band.Columns[DownLoadPrtPosAcs.COL_USER_STATUS].Width                           = 50;
            band.Columns[DownLoadPrtPosAcs.COL_USER_PRINTPAPERUSEDIVCDNM].Width             = 80;

			band.Columns[DownLoadPrtPosAcs.COL_USER_USERPRTPPRIDDERIVNO	].CellAppearance.TextHAlign			= HAlign.Right;
            band.Columns[DownLoadPrtPosAcs.COL_USER_FREEPRTPPRITEMGRPCD ].CellAppearance.TextHAlign         = HAlign.Right;
            band.Columns[DownLoadPrtPosAcs.COL_USER_PRINTPAPERUSEDIVCDNM].CellAppearance.TextHAlign         = HAlign.Left;
        }

        /// <summary>
        /// ダウンロード済み印字位置情報表示切替処理
        /// </summary>
        /// <param name="band"></param>
        private void ChangeHidden_userInfo_ultraGrid(UltraGridBand band)
        {
            band.Columns[DownLoadPrtPosAcs.COL_USER_SELECT_UPDATE].Hidden           = false;
            band.Columns[DownLoadPrtPosAcs.COL_USER_EXISTFLG].Hidden                = true;
            band.Columns[DownLoadPrtPosAcs.COL_USER_UPDATEFLG].Hidden               = true;
            band.Columns[DownLoadPrtPosAcs.COL_USER_STATUS].Hidden                  = false;
            band.Columns[DownLoadPrtPosAcs.COL_USER_KEY].Hidden                     = true;
            band.Columns[DownLoadPrtPosAcs.COL_USER_OUTPUTFORMFILENAME].Hidden      = true;
            band.Columns[DownLoadPrtPosAcs.COL_USER_DISPLAYNAME].Hidden             = false;
            band.Columns[DownLoadPrtPosAcs.COL_USER_USERPRTPPRIDDERIVNO].Hidden     = true;
            band.Columns[DownLoadPrtPosAcs.COL_USER_PRTPPRUSERDERIVNOCMT].Hidden    = false;
            band.Columns[DownLoadPrtPosAcs.COL_USER_FREEPRTPPRITEMGRPCD].Hidden     = true;
            band.Columns[DownLoadPrtPosAcs.COL_USER_UPDATETIME].Hidden              = false;
            band.Columns[DownLoadPrtPosAcs.COL_USER_SYSTEMDIVCD].Hidden             = true;
            band.Columns[DownLoadPrtPosAcs.COL_USER_SYSTEMDIVNAME].Hidden           = false;
            band.Columns[DownLoadPrtPosAcs.COL_USER_OPTIONCODE].Hidden              = true;
            band.Columns[DownLoadPrtPosAcs.COL_USER_OPTIONNAME].Hidden              = true;
            band.Columns[DownLoadPrtPosAcs.COL_USER_PRINTPAPERUSEDIVCD].Hidden      = true;
            band.Columns[DownLoadPrtPosAcs.COL_USER_PRINTPAPERUSEDIVCDNM].Hidden    = false;
        }

		/// <summary>
		/// 行が初期化されたときに発生します
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void userInfo_ultraGrid_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
		{
			int exist		= Convert.ToInt32(e.Row.Cells[DownLoadPrtPosAcs.COL_USER_EXISTFLG		].Text);
			int update		= Convert.ToInt32(e.Row.Cells[DownLoadPrtPosAcs.COL_USER_SELECT_UPDATE	].Text);
            // 既存フラグ
			if (exist == 1)
			{
                // 上書き
				if (update == 1)
				{
					e.Row.CellAppearance.ForeColor = Color.Red;
				}
               	else
				{
					e.Row.CellAppearance.ForeColor = Color.Black;
				}
			}
			else
			{
                // 新規
				e.Row.Cells[DownLoadPrtPosAcs.COL_USER_SELECT_UPDATE].Activation = Activation.NoEdit;
				e.Row.Cells[DownLoadPrtPosAcs.COL_USER_SELECT_UPDATE].Appearance.BackColor = Color.Silver;
				e.Row.CellAppearance.ForeColor = Color.Red;
			}
		}

        /// <summary>
        /// ローカルデータグリッドセル変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void userInfo_ultraGrid_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			if (e.Cell.Column.Key == DownLoadPrtPosAcs.COL_USER_SELECT_UPDATE)
			{
				string[] keys = new string[1];
				keys[0] = e.Cell.Row.Cells[DownLoadPrtPosAcs.COL_USER_KEY].Text;
				int update = DownLoadPrtPosAcs.ConvertToInt32(e.Cell.Row.Cells[DownLoadPrtPosAcs.COL_USER_SELECT_UPDATE].Text);
				this._downLoadPrtPosAcs.ChangeSelect_User(keys, update);
            }
		}

        /// <summary>
        /// ローカル印字位置情報のグリッドクリック時に発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void userInfo_ultraGrid_Click(object sender, System.EventArgs e)
		{
			this.ShowToolTip(this.userInfo_ultraGrid);
		}

		#endregion

		#region OfferGrid Event
		private void offerInfo_ultraGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			UltraGridBand band = e.Layout.Bands[DownLoadPrtPosAcs.TABLE_OFFER];
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_SELECT					].CellActivation	= Activation.AllowEdit;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_KEY					].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_DISPLAYNAME			].CellActivation	= Activation.NoEdit;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_PRTPPRUSERDERIVNOCMT	].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_USERPRTPPRIDDERIVNO	].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_PRTPPRUSERDERIVNOCMT	].CellActivation	= Activation.NoEdit;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_FREEPRTPPRITEMGRPCD    ].CellActivation    = Activation.NoEdit;
           	band.Columns[DownLoadPrtPosAcs.COL_OFFER_UPDATETIMESTR			].CellActivation	= Activation.NoEdit;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_UPDATETIME             ].CellActivation    = Activation.NoEdit;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_SYSTEMDIVCD            ].CellActivation    = Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_SYSTEMDIVNAME			].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_OPTIONCODE				].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_OPTIONNAME				].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_NO_DOWNLOAD			].CellActivation	= Activation.NoEdit;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_NEW_VERSION			].CellActivation	= Activation.NoEdit;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_PRINTPAPERUSEDIVCD     ].CellActivation    = Activation.NoEdit;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_PRINTPAPERUSEDIVCDNM   ].CellActivation    = Activation.NoEdit;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_TAKEINIMAGEGROUPCD     ].CellActivation    = Activation.NoEdit;
			
			// カラム表示状態
			ChangeHidden_offerInfo_ultraGrid(band);
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_SELECT					].Style				= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
			e.Layout.UseFixedHeaders = true;
			e.Layout.Override.FixedCellSeparatorColor = Color.Red;

            band.Columns[DownLoadPrtPosAcs.COL_OFFER_SELECT					].Header.Fixed		= true;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_SELECT					].MinWidth			= 40;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_SELECT].Width                              = 40;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_PRINTPAPERUSEDIVCDNM].Width                = 80;
			
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_USERPRTPPRIDDERIVNO	].CellAppearance.TextHAlign			= HAlign.Right;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_FREEPRTPPRITEMGRPCD    ].CellAppearance.TextHAlign         = HAlign.Right;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_SYSTEMDIVCD			].CellAppearance.TextHAlign			= HAlign.Right;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_OPTIONCODE				].CellAppearance.TextHAlign			= HAlign.Right;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_PRINTPAPERUSEDIVCDNM   ].CellAppearance.TextHAlign         = HAlign.Left;
        }

		private void ChangeHidden_offerInfo_ultraGrid(UltraGridBand band)
		{
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_SELECT					].Hidden			= false;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_KEY					].Hidden			= true;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_OUTPUTFORMFILENAME		].Hidden			= true;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_DISPLAYNAME			].Hidden			= false;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_USERPRTPPRIDDERIVNO	].Hidden			= true;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_PRTPPRUSERDERIVNOCMT	].Hidden			= false;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_FREEPRTPPRITEMGRPCD    ].Hidden            = true;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_UPDATETIMESTR			].Hidden			= false;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_UPDATETIME             ].Hidden            = true ;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_SYSTEMDIVCD            ].Hidden            = true;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_SYSTEMDIVNAME			].Hidden			= false;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_OPTIONCODE				].Hidden			= true;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_OPTIONNAME				].Hidden			= true;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_NO_DOWNLOAD			].Hidden			= true;
			band.Columns[DownLoadPrtPosAcs.COL_OFFER_NEW_VERSION			].Hidden			= true;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_PRINTPAPERUSEDIVCD     ].Hidden            = true;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_PRINTPAPERUSEDIVCDNM   ].Hidden            = false;
            band.Columns[DownLoadPrtPosAcs.COL_OFFER_TAKEINIMAGEGROUPCD     ].Hidden            = true;
		}

        /// <summary>
        /// 行が初期化されたときに発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void offerInfo_ultraGrid_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
		{
			int noDownLoad	= Convert.ToInt32(e.Row.Cells[DownLoadPrtPosAcs.COL_OFFER_NO_DOWNLOAD].Text);
			int newVersion	= Convert.ToInt32(e.Row.Cells[DownLoadPrtPosAcs.COL_OFFER_NEW_VERSION].Text);
            


			if (noDownLoad == 1)
			{   // 未ダウンロード
				e.Row.CellAppearance.ForeColor = Color.Red;
			}
			else if (newVersion == 1)
			{   // サーバー更新済み
				e.Row.CellAppearance.ForeColor = Color.Blue;
			}
			else
			{   // 通常
				e.Row.CellAppearance.ForeColor = Color.Black;
			}
		}

		private void offerInfo_ultraGrid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode.Equals(Keys.Space))
			{
				if ((this.offerInfo_ultraGrid.Selected.Rows != null) && (this.offerInfo_ultraGrid.Selected.Rows.Count > 0))
				{
					string[] keys = new string[this.offerInfo_ultraGrid.Selected.Rows.Count];
					for (int ix = 0; ix < this.offerInfo_ultraGrid.Selected.Rows.Count; ix++)
					{
						keys[ix] = this.offerInfo_ultraGrid.Selected.Rows[ix].Cells[DownLoadPrtPosAcs.COL_OFFER_KEY].Text;
					}

					this.offerInfo_ultraGrid.PerformAction(UltraGridAction.NextRow);
					this.offerInfo_ultraGrid.PerformAction(UltraGridAction.ActivateCell);
				}
			}
		}

        /// <summary>
        /// DBデータグリッドセル変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void offerInfo_ultraGrid_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			if (e.Cell.Column.Key == DownLoadPrtPosAcs.COL_OFFER_SELECT)
			{
				bool isSelect = false;

				if (DownLoadPrtPosAcs.ConvertToInt32(e.Cell.Row.Cells[DownLoadPrtPosAcs.COL_OFFER_SELECT].Text) == 1)
				{
					isSelect = true;
				}

				string[] keys = new string[1];
				keys[0] = e.Cell.Row.Cells[DownLoadPrtPosAcs.COL_OFFER_KEY].Text;

				this._downLoadPrtPosAcs.ChangeSelect_Offer(keys, isSelect);
          	}
		}

	
		/// <summary>
		/// サーバー印字位置情報のグリッドクリック時に発生します
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void offerInfo_ultraGrid_Click(object sender, System.EventArgs e)
		{
			this.ShowToolTip(this.offerInfo_ultraGrid);
        }

        /// <summary>
        /// グリッドセルマウスLeave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void grids_MouseLeaveElement(object sender, UIElementEventArgs e)
        {
            // 該当のグリッドコントロール取得
            Infragistics.Win.UltraWinGrid.UltraGrid grids = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
            // ToolTipを消す
            ultraToolTipManager1.Enabled = false;
            ultraToolTipManager1.SetUltraToolTip(grids, null);
        }

        /// <summary>
        /// ロウがアクティブ状態になったときに発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid_AfterRowActivate(object sender, EventArgs e)
        {
            // 該当のグリッドコントロール取得
            Infragistics.Win.UltraWinGrid.UltraGrid grid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
            grid.ActiveRow.Selected = true;
        }

        /// <summary>
        /// 再描画が行われたときにに発生します(サーバー情報グリッド)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void offerInfo_ultraGrid_Paint(object sender, PaintEventArgs e)
        {
            // アクティブロウの色を変更
            Infragistics.Win.UltraWinGrid.UltraGrid grid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
            if (grid.ActiveRow == null) return;

            int noDownLoad = Convert.ToInt32(grid.ActiveRow.Cells[DownLoadPrtPosAcs.COL_OFFER_NO_DOWNLOAD].Value);
            int newVersion = Convert.ToInt32(grid.ActiveRow.Cells[DownLoadPrtPosAcs.COL_OFFER_NEW_VERSION].Value);
            if (noDownLoad == 1)
            {   // 未ダウンロード
                grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Red;
            }
            else if (newVersion == 1)
            {   // サーバー更新済み
                grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Blue;
            }
            else
            {   // 通常
                grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
            }    
        }

        /// <summary>
        /// 再描画が行われたときにに発生します(ローカル情報グリッド)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userInfo_ultraGrid_Paint(object sender, PaintEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
            if (grid.ActiveRow == null) return;

            if (grid == userInfo_ultraGrid)
            {
                int exist = Convert.ToInt32(grid.ActiveRow.Cells[DownLoadPrtPosAcs.COL_USER_EXISTFLG].Value);
                int update = Convert.ToInt32(grid.ActiveRow.Cells[DownLoadPrtPosAcs.COL_USER_SELECT_UPDATE].Value);
                // 既存フラグ
                if (exist == 1)
                {
                    // 上書き
                    if (update == 1)
                    {
                        grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Red;
                    }
                    else
                    {
                        grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
                    }
                }
                else
                {
                    // 新規
                    grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Red;
                }
            }
        }
		#endregion

        #region IFreeSheetMainFrame メンバ

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
        public void FrameToolbars_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (e.Tool.Key == CT_DOWNLOAD_BUTTONTOOL)
            {
                DialogResult dialogResult;
                string warningMsg;

                int updateSelectCount = 0;
                this.GetSelectCount(out updateSelectCount);

                if (updateSelectCount <= 0)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFANL08200U", "ダウンロードの対象となるデータがありません", 9, MessageBoxButtons.OK);
                    return;
                }

                string countMsg = string.Format("\n\r\n\rダウンロード ＝ {0}件", updateSelectCount);

                // 警告データ存在確認
                if (this._downLoadPrtPosAcs.ExistsWarningData(out warningMsg))
                {
                    dialogResult = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, "SFANL08200U", warningMsg + countMsg, 0, MessageBoxButtons.YesNo);
                }
                else
                {
                    string msg = "ダウンロードを開始します\n\rよろしいですか？";
                    dialogResult = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, "SFANL08200U", msg + countMsg, 0, MessageBoxButtons.YesNo);
                }

                if (dialogResult == DialogResult.Yes)
                {
                    // 共通処理中画面生成
                    Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        string errmsg;
                        int downLoadCount;
                        int updateCount;

                        // 共通処理中画面プロパティ設定
                        form.Title = ctDownLoad_TITLE;           // 画面のタイトル部分に表示する文字列
                        form.Message = ctDownLoad_MESSAGE;       // 画面のプログレスバーの上に表示する文字列
                        form.DispCancelButton = false;       // キャンセルボタン押下による中断機能（デフォルトはＯＦＦ）

                        // 共通処理中画面表示
                        form.Show(Owner);

                        int status = this._downLoadPrtPosAcs.WriteDBData(out errmsg, out downLoadCount, out updateCount);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            form.Close();
                            string msg = string.Format("ダウンロード処理が正常に終了しました" +
                                "\n\rダウンロード件数 ＝ {0}件" 
                                //+ "\n\r更新件数 ＝ {1}件"
                                ,downLoadCount
                            //    ,updateCount
                            );
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFANL08200U", msg, 0, MessageBoxButtons.OK);
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFANL08200U", errmsg, status, MessageBoxButtons.OK);
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFANL08200U", "ダウンロードの対象となるデータがありません", status, MessageBoxButtons.OK);
                        }
                        else
                        {
                            if (errmsg.Trim() != "")
                            {
                                errmsg = "ダウンロード失敗\n\r" + errmsg + "";
                            }
                            else
                            {
                                errmsg = "ダウンロードに失敗しました";
                            }
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFANL08200U", errmsg, status, MessageBoxButtons.OK);
                        }
                    }
                    finally
                    {
                        if(form != null) form.Close();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            else if (e.Tool.Key == CT_RELOAD_BUTTONTOOL)
            {
                // 共通処理中画面生成
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();

                try
                {
                    // 共通処理中画面プロパティ設定
                    form.Title = ctReLoad_TITLE;            // 画面のタイトル部分に表示する文字列
                    form.Message = ctReLoad_MESSAGE;        // 画面のプログレスバーの上に表示する文字列
                    form.DispCancelButton = false;         // キャンセルボタン押下による中断機能（デフォルトはＯＦＦ）
                    form.Show(Owner);                       // 共通処理中画面表示

                    this.ShowDBData();                     // 最新情報取得処理
                }
                finally
                {
                    form.Close();
                }
            }
        }

        /// <summary>
        /// ドック情報取得処理
        /// </summary>
        /// <param name="dockAreaPaneArray">ドック情報のコレクション</param>
        /// <returns>ステータス</returns>
        public int GetDockAreaInfo(out DockAreaPane[] dockAreaPaneArray)
        {
            dockAreaPaneArray = null;
            return 4;
        }

        /// <summary>
        /// ツールバー情報取得処理
        /// </summary>
        /// <param name="ultraToolbarArray">ツールバーの配列</param>
        /// <returns>ステータス</returns>
        public int GetToolBarInfo(out UltraToolbar[] ultraToolbarArray)
        {
            ultraToolbarArray = null;
            return 4;
        }

        /// <summary>
        /// ツールバー情報取得処理
        /// </summary>
        /// <param name="rootToolsCollection"></param>
        /// <param name="toolbarsCollection">ツールバーコレクション</param>
        /// <returns>ステータス</returns>
        public int SetToolBarInfo(ref RootToolsCollection rootToolsCollection, ref ToolbarsCollection toolbarsCollection)
        {
            // ダウンロード開始ボタンの追加
            ButtonTool downLoadButtonTool = new ButtonTool(CT_DOWNLOAD_BUTTONTOOL);
            downLoadButtonTool.SharedProps.Caption = "ダウンロード開始(&S)";
            downLoadButtonTool.SharedProps.AppearancesSmall.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.DOWNLOAD];
            rootToolsCollection.Add(downLoadButtonTool);
            toolbarsCollection[FreeSheetConst.ctToolBar_Main].Tools.AddTool(CT_DOWNLOAD_BUTTONTOOL);
            toolbarsCollection[FreeSheetConst.ctToolBar_Main].Tools[CT_DOWNLOAD_BUTTONTOOL].InstanceProps.IsFirstInGroup = true;
            PopupMenuTool fileMenuTool = (PopupMenuTool)rootToolsCollection[FreeSheetConst.ctPopupMenu_File];
            fileMenuTool.Tools.AddTool(CT_DOWNLOAD_BUTTONTOOL);

            // 最新の情報に更新ボタンの追加
            ButtonTool reloadButtonTool = new ButtonTool(CT_RELOAD_BUTTONTOOL);
            reloadButtonTool.SharedProps.Caption = "最新の情報に更新(&R)";
            reloadButtonTool.SharedProps.AppearancesSmall.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.RETRY];
            rootToolsCollection.Add(reloadButtonTool);
            toolbarsCollection[FreeSheetConst.ctToolBar_Main].Tools.AddTool(CT_RELOAD_BUTTONTOOL);
            toolbarsCollection[FreeSheetConst.ctToolBar_Main].Tools[CT_RELOAD_BUTTONTOOL].InstanceProps.IsFirstInGroup = true;
            PopupMenuTool editMenuTool = (PopupMenuTool)rootToolsCollection[FreeSheetConst.ctPopupMenu_Display];
            editMenuTool.Tools.AddTool(CT_RELOAD_BUTTONTOOL);
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
	}
}