using System.Diagnostics;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
//using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 掛率マスタ一括登録 抽出結果入力画面クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 掛率マスタ一括登録 抽出結果入力画面クラス</br>
	/// <br>Programmer	: 30167 上野　弘貴</br>
	/// <br>Date		: 2007.11.08</br>
	/// <br>Update Note: 2008.02.07 30167 上野　弘貴</br>
	/// <br>			 保存完了のメッセージを保存完了ダイアログ表示に修正</br>
	/// <br>Update Note: 2008.02.18 30167 上野　弘貴</br>
	/// <br>			 ・グリッド不正データ入力時エラーメッセージ抑制処理追加
	///					 ・端数処理単位の桁数チェック追加</br>
	/// <br>Update Note: 2008.03.10 30167 上野　弘貴</br>
	/// <br>			 ・グリッドヘッダークリックソート追加（画面デザインのみ修正）</br>
	/// <br>Update Note: 2008.03.28 30167 上野　弘貴</br>
	///	<br>			 ・掛率商品区分指定無しルートの不具合修正</br>
	///	<br>			 ・商品区分詳細の同一データが複数表示される不具合修正</br>
	/// </remarks>
	public class DCKHN09180UB : Form, IInventInputMdiChild
	{
		#region Private Members (Component)

		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager utb_InventDataToolBar;
		private System.Windows.Forms.Panel DCKHN09180UB_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _DCKHN09180UB_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _DCKHN09180UB_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _DCKHN09180UB_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _DCKHN09180UB_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinGrid.UltraGrid rateBlanketResult_uGrid;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar usb_GridSettingBar;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor uce_ColSizeAutoSetting;
		private Broadleaf.Library.Windows.Forms.TComboEditor tce_FontSize;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl;
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager uttm_ViewGridInfoToolTip;
		private Panel panel1;
		private Infragistics.Win.Misc.UltraButton ub_replaceButton;
		private System.ComponentModel.IContainer components = null;

		#endregion
	
		#region Constructor
		/// <summary>
		/// 掛率マスタ一括登録 抽出結果入力画面クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 掛率マスタ一括登録 抽出結果入力画面クラスのインスタンスを作成</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.08</br>
		/// <br>Update Note: </br>
		/// </remarks>
		public DCKHN09180UB ()
		{
			InitializeComponent();
			
			this._rateBlanketAcs = new RateBlanketAcs();		// 掛率マスタ一括登録アクセスクラス

			// グリッド設定ロード
			this._gridStateController = new GridStateController();
			this._gridStateController.LoadGridState(ct_FileName_ColDisplayStatus);

			//----------------------------------
			// グリッド用ＶＡＬＵＥリスト
			//----------------------------------
			this._gVListPriceDiv = new ValueList();				// 価格区分
			this._gVListUnPrcCalcDiv = new ValueList();			// 単価算出区分
			this._gVListUnPrcCalcDivLimit = new ValueList();	// 単価算出区分限定版（1選択不可）
			this._gVListUnPrcFracProcUnit = new ValueList();	// 単価端数処理
			this._gVListBargainCd = new ValueList();			// 特売区分コード

			// 文字列結合用
			this._stringBuilder = new StringBuilder();

			this._rateAcs = new RateAcs();					// 掛率マスタアクセスクラス
		}
		#endregion Constructor

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

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
			Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("utb_InventInputMain");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool1");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool2");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_BIC_AllInput");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_BIC_NoInput");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_BIC_AllCansel");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_BID_AllInput");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_BID_NoInput");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_BID_AllCansel");
			Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("tool_Dummy1");
			Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("tool_ViewStyleLabel");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool3 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("tool_ViewStyleContainer");
			Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("tool_SortOrder");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool4 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("tool_SortOrderContainer");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool5 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool1");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool6 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("tool_InventoryDate");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool7 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("tool_InventAllInput");
			Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("tool_lb_InventoryDay");
			Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("tool_ColHidden");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool1 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("WarehouseName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool2 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("WarehouseShelfNo", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool3 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("DuplicationShelfNo1", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool4 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("DuplicationShelfNo2", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool5 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("MakerName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool6 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("CustomerName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool7 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("ShipCustomerName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool8 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("StockTrtEntDivName", "");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_Hidden_Initialize");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool9 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("WarehouseName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool10 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("MakerName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool11 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("CustomerName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool12 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("ShipCustomerName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool13 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("StockTrtEntDivName", "");
			Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("tool_Dummy2");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_Hidden_Initialize");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool8 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("tool_RowDelete");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool14 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("DuplicationShelfNo1", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool15 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("DuplicationShelfNo2", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool16 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("WarehouseShelfNo", "");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_ReplaceButton");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool9 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool2");
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel7 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel8 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel9 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel10 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			this.ub_replaceButton = new Infragistics.Win.Misc.UltraButton();
			this.uce_ColSizeAutoSetting = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.tce_FontSize = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.utb_InventDataToolBar = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
			this.DCKHN09180UB_Fill_Panel = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.rateBlanketResult_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.usb_GridSettingBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
			this._DCKHN09180UB_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._DCKHN09180UB_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._DCKHN09180UB_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.tRetKeyControl = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
			this.tArrowKeyControl = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
			this.uttm_ViewGridInfoToolTip = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
			((System.ComponentModel.ISupportInitialize)(this.tce_FontSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.utb_InventDataToolBar)).BeginInit();
			this.DCKHN09180UB_Fill_Panel.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rateBlanketResult_uGrid)).BeginInit();
			this.usb_GridSettingBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// ub_replaceButton
			// 
			this.ub_replaceButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
			this.ub_replaceButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.ub_replaceButton.Location = new System.Drawing.Point(9, 13);
			this.ub_replaceButton.Name = "ub_replaceButton";
			this.ub_replaceButton.Size = new System.Drawing.Size(75, 23);
			this.ub_replaceButton.TabIndex = 1;
			this.ub_replaceButton.Text = "置換(&R)";
			this.ub_replaceButton.Click += new System.EventHandler(this.ub_replaceButton_Click);
			// 
			// uce_ColSizeAutoSetting
			// 
			appearance1.FontData.SizeInPoints = 9F;
			this.uce_ColSizeAutoSetting.Appearance = appearance1;
			this.uce_ColSizeAutoSetting.BackColor = System.Drawing.Color.GhostWhite;
			this.uce_ColSizeAutoSetting.Location = new System.Drawing.Point(3, 4);
			this.uce_ColSizeAutoSetting.Name = "uce_ColSizeAutoSetting";
			this.uce_ColSizeAutoSetting.Size = new System.Drawing.Size(138, 16);
			this.uce_ColSizeAutoSetting.TabIndex = 3;
			this.uce_ColSizeAutoSetting.Text = "列サイズの自動調整";
			this.uce_ColSizeAutoSetting.CheckedChanged += new System.EventHandler(this.uce_ColSizeAutoSetting_CheckedChanged);
			// 
			// tce_FontSize
			// 
			appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tce_FontSize.ActiveAppearance = appearance2;
			appearance3.TextHAlign = Infragistics.Win.HAlign.Right;
			this.tce_FontSize.Appearance = appearance3;
			this.tce_FontSize.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.tce_FontSize.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tce_FontSize.ImeMode = System.Windows.Forms.ImeMode.Disable;
			appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			appearance4.TextHAlign = Infragistics.Win.HAlign.Right;
			this.tce_FontSize.ItemAppearance = appearance4;
			valueListItem1.DataValue = 6;
			valueListItem1.DisplayText = "6";
			valueListItem2.DataValue = 8;
			valueListItem2.DisplayText = "8";
			valueListItem3.DataValue = 9;
			valueListItem3.DisplayText = "9";
			valueListItem4.DataValue = 10;
			valueListItem4.DisplayText = "10";
			valueListItem5.DataValue = 11;
			valueListItem5.DisplayText = "11";
			valueListItem6.DataValue = 12;
			valueListItem6.DisplayText = "12";
			valueListItem7.DataValue = 14;
			valueListItem7.DisplayText = "14";
			this.tce_FontSize.Items.Add(valueListItem1);
			this.tce_FontSize.Items.Add(valueListItem2);
			this.tce_FontSize.Items.Add(valueListItem3);
			this.tce_FontSize.Items.Add(valueListItem4);
			this.tce_FontSize.Items.Add(valueListItem5);
			this.tce_FontSize.Items.Add(valueListItem6);
			this.tce_FontSize.Items.Add(valueListItem7);
			this.tce_FontSize.Location = new System.Drawing.Point(234, 3);
			this.tce_FontSize.Name = "tce_FontSize";
			this.tce_FontSize.Size = new System.Drawing.Size(40, 21);
			this.tce_FontSize.TabIndex = 5;
			this.tce_FontSize.ValueChanged += new System.EventHandler(this.tce_FontSize_ValueChanged);
			// 
			// utb_InventDataToolBar
			// 
			this.utb_InventDataToolBar.DesignerFlags = 1;
			this.utb_InventDataToolBar.DockWithinContainer = this;
			this.utb_InventDataToolBar.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
			this.utb_InventDataToolBar.ShowFullMenusDelay = 500;
			this.utb_InventDataToolBar.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
			ultraToolbar1.DockedColumn = 0;
			ultraToolbar1.DockedRow = 0;
			ultraToolbar1.FloatingSize = new System.Drawing.Size(146, 45);
			ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
			ultraToolbar1.Text = "新旧表示";
			controlContainerTool2.Control = this.ub_replaceButton;
			controlContainerTool2.InstanceProps.IsFirstInGroup = true;
			ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool1,
            controlContainerTool2});
			this.utb_InventDataToolBar.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
			buttonTool1.SharedProps.Caption = "全て入力";
			buttonTool2.SharedProps.Caption = "未入力のみ";
			buttonTool3.SharedProps.Caption = "全て解除";
			buttonTool4.SharedProps.Caption = "全て入力";
			buttonTool5.SharedProps.Caption = "未入力のみ";
			buttonTool6.SharedProps.Caption = "全て解除";
			labelTool1.SharedProps.Spring = true;
			labelTool2.SharedProps.Caption = "表示方法";
			labelTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType;
			labelTool2.SharedProps.MaxWidth = 30;
			labelTool2.SharedProps.MinWidth = 30;
			labelTool2.SharedProps.Width = 30;
			labelTool3.SharedProps.Caption = "表示順";
			labelTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType;
			controlContainerTool4.SharedProps.Width = 106;
			controlContainerTool5.SharedProps.Caption = "ControlContainerTool1";
			controlContainerTool5.SharedProps.Visible = false;
			controlContainerTool6.SharedProps.Caption = "新旧表示";
			appearance20.TextHAlign = Infragistics.Win.HAlign.Left;
			labelTool4.SharedProps.AppearancesSmall.Appearance = appearance20;
			labelTool4.SharedProps.Caption = "棚卸日";
			labelTool4.SharedProps.MaxWidth = 50;
			labelTool4.SharedProps.MinWidth = 50;
			labelTool4.SharedProps.Width = 50;
			popupMenuTool1.SharedProps.Caption = "列表示";
			stateButtonTool1.InstanceProps.IsFirstInGroup = true;
			stateButtonTool1.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool2.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool3.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool4.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool5.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool6.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool7.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool8.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			buttonTool7.InstanceProps.IsFirstInGroup = true;
			popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            stateButtonTool1,
            stateButtonTool2,
            stateButtonTool3,
            stateButtonTool4,
            stateButtonTool5,
            stateButtonTool6,
            stateButtonTool7,
            stateButtonTool8,
            buttonTool7});
			stateButtonTool9.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool9.SharedProps.Caption = "倉庫";
			stateButtonTool10.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool10.SharedProps.Caption = "メーカー";
			stateButtonTool11.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool11.SharedProps.Caption = "仕入先";
			stateButtonTool12.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool12.SharedProps.Caption = "委託先";
			stateButtonTool13.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool13.SharedProps.Caption = "在庫区分";
			buttonTool8.SharedProps.Caption = "初期表示状態";
			controlContainerTool8.SharedProps.Caption = "行削除";
			stateButtonTool14.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool14.SharedProps.Caption = "重複棚番１";
			stateButtonTool15.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool15.SharedProps.Caption = "重複棚番２";
			stateButtonTool16.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool16.SharedProps.Caption = "棚番";
			buttonTool9.SharedProps.Caption = "tool_ReplaceButton";
			buttonTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType;
			controlContainerTool9.Control = this.ub_replaceButton;
			controlContainerTool9.SharedProps.Caption = "置換";
			this.utb_InventDataToolBar.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            labelTool1,
            labelTool2,
            controlContainerTool3,
            labelTool3,
            controlContainerTool4,
            controlContainerTool5,
            controlContainerTool6,
            controlContainerTool7,
            labelTool4,
            popupMenuTool1,
            stateButtonTool9,
            stateButtonTool10,
            stateButtonTool11,
            stateButtonTool12,
            stateButtonTool13,
            labelTool5,
            buttonTool8,
            controlContainerTool8,
            stateButtonTool14,
            stateButtonTool15,
            stateButtonTool16,
            buttonTool9,
            controlContainerTool9});
			this.utb_InventDataToolBar.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.utb_InventDataToolBar_ToolClick);
			// 
			// DCKHN09180UB_Fill_Panel
			// 
			this.DCKHN09180UB_Fill_Panel.Controls.Add(this.panel1);
			this.DCKHN09180UB_Fill_Panel.Controls.Add(this.rateBlanketResult_uGrid);
			this.DCKHN09180UB_Fill_Panel.Controls.Add(this.usb_GridSettingBar);
			this.DCKHN09180UB_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
			this.DCKHN09180UB_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DCKHN09180UB_Fill_Panel.Location = new System.Drawing.Point(0, 29);
			this.DCKHN09180UB_Fill_Panel.Name = "DCKHN09180UB_Fill_Panel";
			this.DCKHN09180UB_Fill_Panel.Size = new System.Drawing.Size(1006, 585);
			this.DCKHN09180UB_Fill_Panel.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ub_replaceButton);
			this.panel1.Location = new System.Drawing.Point(3, 46);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(217, 184);
			this.panel1.TabIndex = 5;
			this.panel1.Visible = false;
			// 
			// rateBlanketResult_uGrid
			// 
			appearance5.BackColor = System.Drawing.Color.White;
			appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.rateBlanketResult_uGrid.DisplayLayout.Appearance = appearance5;
			this.rateBlanketResult_uGrid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.rateBlanketResult_uGrid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
			appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder;
			appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance6.BorderColor = System.Drawing.SystemColors.Window;
			this.rateBlanketResult_uGrid.DisplayLayout.GroupByBox.Appearance = appearance6;
			appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
			this.rateBlanketResult_uGrid.DisplayLayout.GroupByBox.BandLabelAppearance = appearance7;
			this.rateBlanketResult_uGrid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
			appearance8.BackColor2 = System.Drawing.SystemColors.Control;
			appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
			this.rateBlanketResult_uGrid.DisplayLayout.GroupByBox.PromptAppearance = appearance8;
			this.rateBlanketResult_uGrid.DisplayLayout.MaxColScrollRegions = 1;
			this.rateBlanketResult_uGrid.DisplayLayout.MaxRowScrollRegions = 1;
			appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
			appearance9.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			appearance9.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
			appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.ActiveCellAppearance = appearance9;
			appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
			appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
			appearance10.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
			appearance10.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
			appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.ActiveRowAppearance = appearance10;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowGroupSwapping = Infragistics.Win.UltraWinGrid.AllowGroupSwapping.NotAllowed;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.DefaultColWidth = 20;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.DefaultRowHeight = 22;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
			appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
			appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance11.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance11.ForeColor = System.Drawing.Color.White;
			appearance11.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance11.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.GroupByColumnHeaderAppearance = appearance11;
			appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
			appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
			appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance12.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance12.ForeColor = System.Drawing.Color.White;
			appearance12.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance12.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.HeaderAppearance = appearance12;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
			appearance13.BackColor = System.Drawing.Color.Lavender;
			appearance13.BackColorDisabled = System.Drawing.Color.Lavender;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.RowAlternateAppearance = appearance13;
			appearance14.BackColor = System.Drawing.Color.White;
			appearance14.BackColorDisabled = System.Drawing.Color.White;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.RowAppearance = appearance14;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
			appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
			appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
			appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance15.ForeColor = System.Drawing.Color.White;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.RowSelectorAppearance = appearance15;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.RowSelectorWidth = 12;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
			appearance16.BackColor = System.Drawing.Color.WhiteSmoke;
			appearance16.BackColor2 = System.Drawing.Color.Coral;
			appearance16.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
			appearance16.BackColorDisabled2 = System.Drawing.Color.Coral;
			appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance16.ForeColor = System.Drawing.Color.Black;
			appearance16.ForeColorDisabled = System.Drawing.Color.Black;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.SelectedRowAppearance = appearance16;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
			appearance17.BackColor = System.Drawing.SystemColors.ControlLight;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.TemplateAddRowAppearance = appearance17;
			this.rateBlanketResult_uGrid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
			this.rateBlanketResult_uGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.rateBlanketResult_uGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.rateBlanketResult_uGrid.DisplayLayout.UseFixedHeaders = true;
			this.rateBlanketResult_uGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
			this.rateBlanketResult_uGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rateBlanketResult_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
			this.rateBlanketResult_uGrid.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.rateBlanketResult_uGrid.Location = new System.Drawing.Point(0, 0);
			this.rateBlanketResult_uGrid.Name = "rateBlanketResult_uGrid";
			this.rateBlanketResult_uGrid.Size = new System.Drawing.Size(1006, 562);
			this.rateBlanketResult_uGrid.TabIndex = 0;
			this.rateBlanketResult_uGrid.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
			this.rateBlanketResult_uGrid.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.rateBlanketResult_uGrid_BeforeEnterEditMode);
			this.rateBlanketResult_uGrid.AfterExitEditMode += new System.EventHandler(this.rateBlanketResult_uGrid_AfterExitEditMode);
			this.rateBlanketResult_uGrid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.rateBlanketResult_uGrid_InitializeLayout);
			this.rateBlanketResult_uGrid.BeforeSelectChange += new Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventHandler(this.rateBlanketResult_uGrid_BeforeSelectChange);
			this.rateBlanketResult_uGrid.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.rateBlanketResult_uGrid_BeforeExitEditMode);
			this.rateBlanketResult_uGrid.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.rateBlanketResult_uGrid_CellDataError);
			this.rateBlanketResult_uGrid.AfterRowActivate += new System.EventHandler(this.rateBlanketResult_uGrid_AfterRowActivate);
			this.rateBlanketResult_uGrid.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.rateBlanketResult_uGrid_InitializeRow);
			this.rateBlanketResult_uGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rateBlanketResult_uGrid_KeyPress);
			this.rateBlanketResult_uGrid.Leave += new System.EventHandler(this.rateBlanketResult_uGrid_Leave);
			this.rateBlanketResult_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rateBlanketResult_uGrid_KeyDown);
			this.rateBlanketResult_uGrid.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.rateBlanketResult_uGrid_BeforeRowDeactivate);
			this.rateBlanketResult_uGrid.AfterCellActivate += new System.EventHandler(this.rateBlanketResult_uGrid_AfterCellActivate);
			// 
			// usb_GridSettingBar
			// 
			appearance18.FontData.SizeInPoints = 9F;
			this.usb_GridSettingBar.Appearance = appearance18;
			this.usb_GridSettingBar.Controls.Add(this.uce_ColSizeAutoSetting);
			this.usb_GridSettingBar.Controls.Add(this.tce_FontSize);
			this.usb_GridSettingBar.Location = new System.Drawing.Point(0, 562);
			this.usb_GridSettingBar.Name = "usb_GridSettingBar";
			ultraStatusPanel1.Control = this.uce_ColSizeAutoSetting;
			ultraStatusPanel1.Key = "AutoSetting";
			ultraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
			ultraStatusPanel1.Width = 140;
			ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel2.Key = "Dummy1";
			ultraStatusPanel2.Width = 1;
			ultraStatusPanel3.Key = "Line1";
			ultraStatusPanel3.Width = 1;
			ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel4.Key = "Dummy2";
			ultraStatusPanel4.Width = 5;
			appearance19.FontData.SizeInPoints = 9F;
			appearance19.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance19.TextVAlign = Infragistics.Win.VAlign.Middle;
			ultraStatusPanel5.Appearance = appearance19;
			ultraStatusPanel5.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel5.Key = "FontSizeLabel";
			ultraStatusPanel5.Text = "文字サイズ";
			ultraStatusPanel5.Width = 75;
			ultraStatusPanel6.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel6.Control = this.tce_FontSize;
			ultraStatusPanel6.Key = "FontSize";
			ultraStatusPanel6.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
			ultraStatusPanel6.Width = 40;
			ultraStatusPanel7.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel7.Key = "Dummy3";
			ultraStatusPanel7.Width = 1;
			ultraStatusPanel8.Key = "Line2";
			ultraStatusPanel8.Width = 1;
			ultraStatusPanel9.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel9.Key = "Dummy4";
			ultraStatusPanel9.Width = 1;
			ultraStatusPanel10.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel10.Key = "Dummy";
			ultraStatusPanel10.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
			this.usb_GridSettingBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5,
            ultraStatusPanel6,
            ultraStatusPanel7,
            ultraStatusPanel8,
            ultraStatusPanel9,
            ultraStatusPanel10});
			this.usb_GridSettingBar.Size = new System.Drawing.Size(1006, 23);
			this.usb_GridSettingBar.TabIndex = 4;
			this.usb_GridSettingBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
			// 
			// _DCKHN09180UB_Toolbars_Dock_Area_Left
			// 
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.Color.Black;
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 29);
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.Name = "_DCKHN09180UB_Toolbars_Dock_Area_Left";
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 585);
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.ToolbarsManager = this.utb_InventDataToolBar;
			// 
			// _DCKHN09180UB_Toolbars_Dock_Area_Right
			// 
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.Color.Black;
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1006, 29);
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.Name = "_DCKHN09180UB_Toolbars_Dock_Area_Right";
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 585);
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.ToolbarsManager = this.utb_InventDataToolBar;
			// 
			// _DCKHN09180UB_Toolbars_Dock_Area_Top
			// 
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.Color.Black;
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.Name = "_DCKHN09180UB_Toolbars_Dock_Area_Top";
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1006, 29);
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.ToolbarsManager = this.utb_InventDataToolBar;
			// 
			// _DCKHN09180UB_Toolbars_Dock_Area_Bottom
			// 
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.Color.Black;
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 614);
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.Name = "_DCKHN09180UB_Toolbars_Dock_Area_Bottom";
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1006, 0);
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.utb_InventDataToolBar;
			// 
			// tRetKeyControl
			// 
			this.tRetKeyControl.OwnerForm = this;
			this.tRetKeyControl.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
			this.tRetKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl_ChangeFocus);
			// 
			// tArrowKeyControl
			// 
			this.tArrowKeyControl.OwnerForm = this;
			this.tArrowKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl_ChangeFocus);
			// 
			// uttm_ViewGridInfoToolTip
			// 
			this.uttm_ViewGridInfoToolTip.Enabled = false;
			this.uttm_ViewGridInfoToolTip.InitialDelay = 250;
			// 
			// DCKHN09180UB
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			this.ClientSize = new System.Drawing.Size(1006, 614);
			this.Controls.Add(this.DCKHN09180UB_Fill_Panel);
			this.Controls.Add(this._DCKHN09180UB_Toolbars_Dock_Area_Left);
			this.Controls.Add(this._DCKHN09180UB_Toolbars_Dock_Area_Right);
			this.Controls.Add(this._DCKHN09180UB_Toolbars_Dock_Area_Top);
			this.Controls.Add(this._DCKHN09180UB_Toolbars_Dock_Area_Bottom);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "DCKHN09180UB";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			((System.ComponentModel.ISupportInitialize)(this.tce_FontSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.utb_InventDataToolBar)).EndInit();
			this.DCKHN09180UB_Fill_Panel.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rateBlanketResult_uGrid)).EndInit();
			this.usb_GridSettingBar.ResumeLayout(false);
			this.usb_GridSettingBar.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Member

		private RateAcs _rateAcs = null;					// 掛率アクセスクラス
		
		// IInventInputMdiChild メンバ用 変数 ---------------------------------------
		private string _enterpriseCode				= "";					// 企業コード
		private string _sectionCode					= "";					// 拠点コード
		private string _sectionName					= "";					// 拠点名称
		private bool _isCansel						= true;					// 取消ボタンEnabled
		private bool _isSave						= true;					// 保存ボタンEnabled
		private bool _isExtract						= false;				// 抽出ボタンEnabled
		private bool _isNewInvent					= false;				// 新規ボタンEnabled
		private bool _isDetail						= false;				// 詳細ボタンEnabled
		private bool _isBarcodeRead					= false;				// バーコード読込ボタンEnabled
		private bool _isDataEdit		= false;	// 編集ボタンEnabled

		// Private 変数 ---------------------------------------
		private bool _isFirstsetting				= true;					// 初期処理中フラグ
		private RateBlanketAcs _rateBlanketAcs = null;	// 掛率マスタ一括登録アクセスクラス
		private bool _isEventAutoFillColumn			= true;					// 列サイズ調整イベント可能フラグ(T:可,F:不可)
		private GridStateController _gridStateController = null;			// グリッド設定制御クラス
		private DCKHN09180UC _replaceForm = null;	// 置換画面

		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 文字列結合用
		private StringBuilder _stringBuilder = null;

		// 保存データ格納用リスト
		private ArrayList _saveRateList = null;

		//----------------
		// グリッド制御用
		//----------------
		// GridFocus遷移用
		private int _leaveRowBuf;
		private int _leaveColBuf;
		
		//----------------------------------
		// グリッド用ＶＡＬＵＥリスト
		//----------------------------------
		ValueList _gVListPriceDiv = null;			// 価格区分
		ValueList _gVListUnPrcCalcDiv = null;		// 単価算出区分
		ValueList _gVListUnPrcCalcDivLimit = null;	// 単価算出区分限定版（1選択不可）
		ValueList _gVListUnPrcFracProcUnit = null;	// 単価端数処理
		ValueList _gVListBargainCd = null;			// 特売区分コード

		#endregion Private Member

		/// <summary> 列表示状態セッティングXMLファイル名 </summary>
		private const string ct_FileName_ColDisplayStatus =  "DCKHN09180U_ColSetting.DAT";

		/// <summary> 棚卸数一括入力コンテナ </summary>
		private const string ct_tool_InventoryAllInput = "tool_InventAllInput";

		/// <summary> 表示方法ツールコンテナ </summary>
		private const string ct_tool_ViewStyleContainer = "tool_ViewStyleContainer";

		/// <summary> ソート順ツールコンテナ </summary>
		private const string ct_tool_SortOrderContainer = "tool_SortOrderContainer";

		/// <summary> ソート順ツールコンテナ </summary>
		private const string ct_tool_RowDelete = "tool_RowDelete";

		/// <summary> 初期表示状態 </summary>
		private const string ct_tool_Hidden_Initialize = "tool_Hidden_Initialize";

		/// <summary> 掛率置換コンテナ </summary>
		private const string ct_tool_ReplaceContainer = "tool_ReplaceButton";

		//-----------------
		// グリッド用定義
		//----------------
		// グリッドコンボボックス用定義
		private const string PRICEDIV = "PRICEDIV";							// 価格区分
		private const string UNITPRCCALCDIVLIST = "UNITPRCCALCDIVLIST";		// 単価算出区分
		private const string UNITPRCCALCDIVLIST_LIMIT = "UNITPRCCALCDIVLIST_LIMIT";	// 単価算出区分限定版（1選択不可）
		private const string UNPRCFRACPROCDIVLIST = "UNPRCFRACPROCDIVLIST";	// 単価端数処理区分
		private const string BARGAINCD = "BARGAINCD";						// 特売区分コード
		private const int FILTER_LENGTH = 10;	// グリッドヘッダ部のフィルタマーク分表示幅

		// メッセージ
		private const string RATE_ERR_MSG = "単価か掛率の何れかを設定してください。";
		private const string RATESTARTDATE_NOTINPUT_MSG = "掛率開始日が未入力です。";
		private const string RATESTARTDATE_NOTCORRECT_MSG = "掛率開始日が正しくありません。";
		private const string RATE_SAVE_MSG = "保存しました。";

		#region Public Property
		/// <summary> 企業コードプロパティ </summary>
		public string EnterpriseCode
		{
			set { this._enterpriseCode = value; }
		}

		/// <summary> 拠点コードプロパティ </summary>
		public string SectionCode
		{
			set { this._sectionCode = value; }
		}

		/// <summary> 拠点名称プロパティ </summary>
		public string SectionName
		{
			set { this._sectionName = value; }
		}

		/// <summary> 取消ボタンEnabledプロパティ </summary>
		public bool IsCansel
		{
			get { return this._isCansel; }
		}

		/// <summary> 保存ボタンEnabledプロパティ </summary>
		public bool IsSave
		{
			get { return this._isSave; }
		}

		/// <summary> 抽出ボタンEnabledプロパティ </summary>
		public bool IsExtract
		{
			get { return this._isExtract; }
		}

		/// <summary> 新規ボタンEnabledプロパティ </summary>
		public bool IsNewInvent
		{
			get { return this._isNewInvent; }
		}

		/// <summary> 詳細ボタンEnabledプロパティ </summary>
		public bool IsDetail
		{
			get { return this._isDetail; }
		}

		/// <summary> バーコード読込ボタンEnabledプロパティ </summary>
		public bool IsBarcodeRead
		{
			get { return this._isBarcodeRead; }
		}

		/// <summary> 詳細ボタンEnabledプロパティ </summary>
		public bool IsDataEdit
		{
			get { return this._isDataEdit; }
		}
		#endregion Public Property

		#region Public Method
		/// <summary>
		/// 画面表示処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : タブが変更される前に実行される</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		public int ShowData ( object parameter )
		{
			try
			{
				this.rateBlanketResult_uGrid.BeginUpdate();
				
				if(this._rateBlanketAcs.RateBlanketTable.Rows.Count > 0)
				{
					ShowDataProc();
				}
			}
			finally
			{
				this.rateBlanketResult_uGrid.EndUpdate();
			}
			return 0;
		}

		/// <summary>
		/// タブ変更前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : タブが変更される前に実行される</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		public int BeforeTabChange ( object parameter )
		{
			return 0;
		}

		/// <summary>
		/// 終了前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 終了前処理を行う</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		public int BeforeClose ( object parameter )
		{
			return 0;
		}

		/// <summary>
		/// 取消前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取消前処理を行う</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		public int BeforeCansel ( object parameter )
		{
			return 0;
		}

		/// <summary>
		/// 取消処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取消処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int Cansel ( object parameter )
		{
			// メッセージで取消の確認
			string strMsg = "現在編集中のデータが存在します。\n\n初期状態に戻しますか？";

			// Okなら初回抽出時、保存時のデータに戻す
			DialogResult dlgRes = TMsgDisp.Show(
				emErrorLevel.ERR_LEVEL_INFO,        //エラーレベル
				"DCKHN09180UB",                     //UNIT　ID
				this.Text,                          //プログラム名称
				"取消",		                        //プロセスID
				"",                                 //オペレーション
				strMsg,                             //メッセージ
				0,									//ステータス
				null,								//オブジェクト
				MessageBoxButtons.YesNo,            //ダイアログボタン指定
				MessageBoxDefaultButton.Button1     //ダイアログ初期ボタン指定
				);

			switch( dlgRes )
			{
				case DialogResult.Yes:
					// 現在のテーブルにバッファテーブルをコピー
					try
					{
						UltraGridRow activeRow = null;						
						
						// エディットモードになっているセルを抜けるための処理
						this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.ExitEditMode);

						this.rateBlanketResult_uGrid.BeginUpdate();	// 描画停止

						if (this.rateBlanketResult_uGrid.ActiveRow != null)
							activeRow = this.rateBlanketResult_uGrid.ActiveRow;

						this.rateBlanketResult_uGrid.ActiveRow = null;

						this.rateBlanketResult_uGrid.Selected.Rows.Clear();
						this.rateBlanketResult_uGrid.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
						this.rateBlanketResult_uGrid.DisplayLayout.Override.SelectTypeRow = SelectType.Single;

						this.rateBlanketResult_uGrid.BeginUpdate();

						// グリッドテーブルのデータ件数取得
						int rowCnt = this._rateBlanketAcs.RateBlanketTable.Rows.Count;
						
						// データ件数が一致しているとき（必ず一致していなければならない）
						if (rowCnt == this._rateBlanketAcs.RateBlanketTableBuf.Rows.Count)
						{
							for (int rc = 0; rc < rowCnt; rc++)
							{
								// グリッドテーブルのアイテム数取得
								int itemCnt = this._rateBlanketAcs.RateBlanketTable.Rows[rc].ItemArray.Length;
								
								// アイテム数が一致しているとき
								if (itemCnt == this._rateBlanketAcs.RateBlanketTableBuf.Rows[rc].ItemArray.Length)
								{
									// アイテムコピー
									for (int ic = 0; ic < itemCnt; ic++)
									{
										this._rateBlanketAcs.RateBlanketTable.Rows[rc][ic] = this._rateBlanketAcs.RateBlanketTableBuf.Rows[rc][ic];
									}
								}
							}
						}

						// アクティブ化
						if (this.rateBlanketResult_uGrid.Rows.Count > 0)
						{
							this.rateBlanketResult_uGrid.Rows[0].Cells[RateBlanketResult.RATESTARTDATE].Activate();
						}
					}
					finally
					{
						this.rateBlanketResult_uGrid.EndUpdate();
					}
					break;
				case DialogResult.No:
					// 何もしない
					break;
			}
			return 0;
		}

		/// <summary>
		/// 抽出前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 抽出前処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int BeforeExtract ( object parameter )
		{
			return 0;
		}

		/// <summary>
		/// 抽出処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 抽出処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int Extract ( object parameter )
		{
			return 0;
		}

		/// <summary>
		/// 新規処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 新規処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int NewInvent ( object parameter )
		{
			return 0;
		}

		/// <summary>
		/// 保存前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 保存前処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int BeforeSave ( object parameter )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			bool errFlag = false;
			string errMsg = "";
			
			//----------------
			// エラーチェック
			//----------------
			foreach (UltraGridRow uRow in this.rateBlanketResult_uGrid.Rows)
			{
				errFlag = InpGridDataCheck(uRow, ref errMsg);
				if (errFlag == false)
				{
					// エラーメッセージ
					this.MsgDispProc(errMsg, status, "Save", emErrorLevel.ERR_LEVEL_INFO);
					return status;
				}
			}
			
			//--------------------
			// 変更データチェック
			//--------------------
			this._saveRateList = new ArrayList(); 
			
			// 変更データがあれば保存データ格納
			if (SetSaveData(ref this._saveRateList) == false)
			{
				// 変更データ無し
				errMsg = "変更データはありません。";
				this.MsgDispProc(errMsg, status, "Save", emErrorLevel.ERR_LEVEL_INFO);
			}
			else
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			return status;
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 保存処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int Save ( object parameter )
		{
			string message = "";
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			UltraGridRow activeRow = null;

			try
			{
				// エディットモードになっているセルを抜けるための処理
				this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.ExitEditMode);

				this.rateBlanketResult_uGrid.BeginUpdate();	// 描画停止

				if ( this.rateBlanketResult_uGrid.ActiveRow != null )
					activeRow = this.rateBlanketResult_uGrid.ActiveRow;

				this.rateBlanketResult_uGrid.ActiveRow = null;

				this.rateBlanketResult_uGrid.Selected.Rows.Clear();
				this.rateBlanketResult_uGrid.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
				this.rateBlanketResult_uGrid.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
				
				emErrorLevel errLv = emErrorLevel.ERR_LEVEL_INFO;

				// 保存処理
				status = this._rateBlanketAcs.Write(ref this._saveRateList, out message);

				this.rateBlanketResult_uGrid.ActiveRow = activeRow;
				
				switch ( status )
				{
					case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
						// 正常終了
						//----- ueno upd ---------- start 2008.02.07
						this.rateBlanketResult_uGrid.Refresh();
						//errLv = emErrorLevel.ERR_LEVEL_INFO;
						//message = RATE_SAVE_MSG;

						// 保存完了ダイアログ表示
						SaveCompletionDialog dialog = new SaveCompletionDialog();
						dialog.ShowDialog(2);
						//----- ueno upd ---------- end 2008.02.07
						
						break;
					case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
						// 更新エラー発生
						errLv = emErrorLevel.ERR_LEVEL_EXCLAMATION;
						break;
					default:
						// 例外など
						errLv = emErrorLevel.ERR_LEVEL_STOPDISP;
						break;
				}

				//----- ueno upd ---------- start 2008.02.07
				// ステータスが正常以外のとき、メッセージボックス表示
				if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					// メッセージ表示
					this.MsgDispProc(message, status, "Save", errLv);
				}
				//----- ueno upd ---------- end 2008.02.07
				
				// 再検索
				RateBlanket searchRateBlanket = this._rateBlanketAcs.GetSearchRateBlanket;	// 検索条件
				int dispDiv = this._rateBlanketAcs.GetDispDiv;								// 表示区分

				status = this._rateBlanketAcs.SearchAll(ref searchRateBlanket, dispDiv, out message);
			}
			finally
			{
				this.rateBlanketResult_uGrid.EndUpdate();	// 描画再開
			}
			return status;
		}

		/// <summary>
		/// 詳細表示処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 詳細表示処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int ShowDetail ( object parameter )
		{
			return 0;
		}

		/// <summary>
		/// バーコード読込処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : バーコード読込処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int BarcodeRead(object parameter)
		{
			return 0;
		}

		/// <summary>
		/// 編集処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 編集処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		public int DataEdit ( object parameter )
		{
			return 0;
		}

		#endregion Public Method

		/// <summary>
		/// ツールバー設定
		/// </summary>
		public event ParentToolbarInventSettingEventHandler ParentToolbarInventSettingEvent;

		/// <summary>
		/// 初期化処理メイン
		/// </summary>
		/// <returns>Status(ConstantManagement.MethodResult)</returns>
		/// <remarks>
		/// <br>Note		: 画面初期化処理を実行する。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private int InitialLoadScreen ()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			try
			{
				// 置換ボタン
				this.utb_InventDataToolBar.Tools[ct_tool_ReplaceContainer].Control = this.ub_replaceButton;

				// 初回起動時のみ画面設定
				// StatusBarsSetting
				this.InitializeStatusBarSetting();

				// 画面イメージ統一
				this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
				this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更
			}
			finally
			{
			}

			return status;
		}

		/// <summary>
		/// ステータスバー初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ステータスバー初期化を行う</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void InitializeStatusBarSetting ()
		{
			// フォントサイズ変更コンボボックスの設定
			this.tce_FontSize.MaxDropDownItems = this.tce_FontSize.Items.Count;
			this.tce_FontSize.Value = 10;
		}

		/// <summary>
		/// グリッドキーマッピング作成処理
		/// </summary>
		/// <param name="grid">対象グリッド</param>
		/// <remarks>
		/// <br>Note       : グリッドに対してキーマッピングを作成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void MakeGridKeyMapping( UltraGrid grid )
		{
			GridKeyActionMapping wkKeyMapping = null;

			// Enterキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Enter, 
				UltraGridAction.NextCellByTab, 
				0, 
				UltraGridState.Cell, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// Shift + Enterキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Enter, 
				UltraGridAction.PrevCellByTab, 
				0, 
				UltraGridState.Cell, 
				SpecialKeys.AltCtrl, 
				SpecialKeys.Shift );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// ↑キー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Up, 
				UltraGridAction.AboveCell, 
				UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// ↓キー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Down, 
				UltraGridAction.BelowCell, 
				UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// PageUpキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Prior, 
				UltraGridAction.PageUpCell, 
				0, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// PageDownキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Next, 
				UltraGridAction.PageDownCell, 
				0, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// Spaceキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Space, 
				UltraGridAction.ToggleRowSel, 
				0, 
				0, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );
		}

		/// <summary>
		///	保存データ設定
		/// </summary>
		/// <returns>保存データ有無(true:有り, false:無し)</returns>
		/// <remarks>
		/// <br>Note		: 保存データを掛率クラスへ設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private bool SetSaveData(ref ArrayList rateList)
		{
			int rowCnt = this._rateBlanketAcs.RateBlanketTable.Rows.Count;
			Rate rate = null;
			bool saveFlag = false;
			
			// データ件数が一致しているとき（必ず一致していなければならない）
			if(rowCnt == this._rateBlanketAcs.RateBlanketTableBuf.Rows.Count)
			{
				for(int i = 0; i < rowCnt; i++)
				{
					// グリッド表示項目差異チェック
					DataRow wk		= this._rateBlanketAcs.RateBlanketTable.Rows[i];
					DataRow wkBuf	= this._rateBlanketAcs.RateBlanketTableBuf.Rows[i];
					int chgCnt = 0;

					chgCnt += (DateTime)wk[RateBlanketResult.RATESTARTDATE]							!= (DateTime)wkBuf[RateBlanketResult.RATESTARTDATE]							? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgInt(wk[RateBlanketResult.RATESTARTDATE])		!= RateBlanketAcs.NullChgInt(wkBuf[RateBlanketResult.RATESTARTDATE])		? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgDbl(wk[RateBlanketResult.PRICEFL])				!= RateBlanketAcs.NullChgDbl(wkBuf[RateBlanketResult.PRICEFL])				? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgInt(wk[RateBlanketResult.PRICEDIV])				!= RateBlanketAcs.NullChgInt(wkBuf[RateBlanketResult.PRICEDIV])				? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgInt(wk[RateBlanketResult.UNITPRCCALCDIV])		!= RateBlanketAcs.NullChgInt(wkBuf[RateBlanketResult.UNITPRCCALCDIV])		? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgDbl(wk[RateBlanketResult.RATEVAL])				!= RateBlanketAcs.NullChgDbl(wkBuf[RateBlanketResult.RATEVAL])				? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgDbl(wk[RateBlanketResult.UNPRCFRACPROCUNIT])	!= RateBlanketAcs.NullChgDbl(wkBuf[RateBlanketResult.UNPRCFRACPROCUNIT])	? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgInt(wk[RateBlanketResult.UNPRCFRACPROCDIV])		!= RateBlanketAcs.NullChgInt(wkBuf[RateBlanketResult.UNPRCFRACPROCDIV])		? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgInt(wk[RateBlanketResult.BARGAINCD])			!= RateBlanketAcs.NullChgInt(wkBuf[RateBlanketResult.BARGAINCD])			? 1 : 0;
					
					if(chgCnt > 0)
					{
						// 保存用掛率クラスへ格納
						rate = CopyToRateFromDataRow(ref wk);
						rateList.Add(rate);
						saveFlag = true;
					}
				}
			}
			return saveFlag;
		}

		/// <summary>
		/// グリッドデータテーブルコピー処理（グリッドデータテーブル⇒掛率クラス）
		/// </summary>
		/// <param name="dr">データロウ</param>
		/// <returns>Rate</returns>
		/// <remarks>
		/// <br>Note       : グリッドデータテーブルから掛率設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private Rate CopyToRateFromDataRow(ref DataRow dr)
		{
			Rate rate = new Rate();
			
			// 既存データのみ設定する
			if (RateBlanketAcs.NullChgInt(dr[RateBlanketResult.DIVIDE_CD]) == (int)RateBlanketAcs.DispDivList.Upd)
			{
				// 作成日時
				rate.CreateDateTime			= (DateTime)dr[RateBlanketResult.CREATEDATETIME];
				// 更新日時
				rate.UpdateDateTime			= (DateTime)dr[RateBlanketResult.UPDATEDATETIME];
				// GUID
				rate.FileHeaderGuid = (Guid)dr[RateBlanketResult.FILEHEADERGUID];
			}
			
			// 企業コード
			rate.EnterpriseCode			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.ENTERPRISECODE]);
			// 更新従業員コード
			rate.UpdEmployeeCode		= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.UPDEMPLOYEECODE]);
			// 更新アセンブリID1
			rate.UpdAssemblyId1			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.UPDASSEMBLYID1]);
			// 更新アセンブリID2
			rate.UpdAssemblyId2			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.UPDASSEMBLYID2]);
			// 論理削除区分
			rate.LogicalDeleteCode		= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.LOGICALDELETECODE]);
			// 拠点コード
			rate.SectionCode			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.SECTIONCODE]);
			// 単価掛率設定区分
			rate.UnitRateSetDivCd		= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.UNITRATESETDIVCD]);
			// 新旧区分
			rate.OldNewDivCd			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.OLDNEWDIVCD]);
			// 単価種類
			rate.UnitPriceKind			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.UNITPRICEKIND]);
			// 掛率設定区分
			rate.RateSettingDivide		= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.RATESETTINGDIVIDE]);
			// 掛率設定区分（商品）
			rate.RateMngGoodsCd			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.RATEMNGGOODSCD]);
			// 掛率設定名称（商品）
			rate.RateMngGoodsNm			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.RATEMNGGOODSNM]);
			// 掛率設定区分（得意先）
			rate.RateMngCustCd			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.RATEMNGCUSTCD]);
			// 掛率設定名称（得意先）
			rate.RateMngCustNm			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.RATEMNGCUSTNM]);
			// 商品メーカーコード
			rate.GoodsMakerCd			= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.GOODSMAKERCD]);
			// 商品番号
			rate.GoodsNo				= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.GOODSNO]);
			// 商品掛率ランク
			rate.GoodsRateRank			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.GOODSRATERANK]);
			// 商品区分グループコード
			rate.LargeGoodsGanreCode	= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.LARGEGOODSGANRECODE]);
			// 商品区分コード
			rate.MediumGoodsGanreCode	= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.MEDIUMGOODSGANRECODE]);
			// 商品区分詳細コード
			rate.DetailGoodsGanreCode	= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.DETAILGOODSGANRECODE]);
			// 自社分類コード
			rate.EnterpriseGanreCode	= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.ENTERPRISEGANRECODE]);
			// BL商品コード
			rate.BLGoodsCode			= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.BLGOODSCODE]);
			// 得意先コード
			rate.CustomerCode			= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.CUSTOMERCODE]);
			// 得意先掛率グループコード
			rate.CustRateGrpCode		= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.CUSTRATEGRPCODE]);
			// 仕入先コード
			rate.SupplierCd				= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.SUPPLIERCD]);
			// 仕入先掛率グループコード
			rate.SuppRateGrpCode		= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.SUPPRATEGRPCODE]);
			// ロット数
			rate.LotCount				= RateBlanketAcs.NullChgDbl(dr[RateBlanketResult.LOTCOUNT]);
			// 単価算出区分
			rate.UnitPrcCalcDiv			= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.UNITPRCCALCDIV]);
			// 価格区分
			rate.PriceDiv				= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.PRICEDIV]);
			// 価格
			rate.PriceFl				= RateBlanketAcs.NullChgDbl(dr[RateBlanketResult.PRICEFL]);
			// 掛率
			rate.RateVal				= RateBlanketAcs.NullChgDbl(dr[RateBlanketResult.RATEVAL]);
			// 単価端数処理単位
			rate.UnPrcFracProcUnit		= RateBlanketAcs.NullChgDbl(dr[RateBlanketResult.UNPRCFRACPROCUNIT]);
			// 単価端数処理区分
			rate.UnPrcFracProcDiv		= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.UNPRCFRACPROCDIV]);
			// 掛率開始日
			rate.RateStartDate = (DateTime)dr[RateBlanketResult.RATESTARTDATE];
			
			// 特売区分コード
			rate.BargainCd				= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.BARGAINCD]);

			//------------------------------------------------------------------
			// 単価掛率設定区分作成(単価種類＋掛率設定区分＋新旧区分)
			//   新旧区分を問わず両方取得する場合、単価種類＋掛率設定区分となる
			//------------------------------------------------------------------
			string wkStr = "";
			_stringBuilder.Remove(0, _stringBuilder.Length);
			_stringBuilder.Append(rate.UnitPriceKind);
			_stringBuilder.Append(rate.RateSettingDivide);
			_stringBuilder.Append(rate.OldNewDivCd);
			wkStr = _stringBuilder.ToString();
			
			// 単価掛率設定区分
			rate.UnitRateSetDivCd = wkStr;
			
			return rate;
		}

		/// <summary>
		///	ＶＡＬＵＥリスト作成
		/// </summary>
		/// <param name="vList">Valueリスト</param>
		/// <param name="uGrid">ロットグリッド</param>
		/// <param name="listStr">Valueリスト文字列</param>
		/// <param name="sList">ドロップダウンアイテム</param>
		/// <remarks>
		/// <br>Note		: ＶＡＬＵＥリストを作成します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2008.01.08</br>
		/// </remarks>
		private void MakeValueList(ref ValueList vList, ref UltraGrid uGrid, string listStr, ref SortedList sList)
		{
			try
			{
				vList = uGrid.DisplayLayout.ValueLists.Add(listStr);

				if (sList != null)
				{
					// アイテム追加
					foreach (DictionaryEntry de in sList)
					{
						vList.ValueListItems.Add((Int32)de.Key, de.Value.ToString());
					}
					vList.MaxDropDownItems = vList.ValueListItems.Count;
				}
			}
			catch
			{
			}
		}

		/// <summary>
		///	ＶＡＬＵＥリスト作成（単価算出区分専用）
		/// </summary>
		/// <param name="vList">Valueリスト</param>
		/// <param name="uGrid">ロットグリッド</param>
		/// <param name="listStr">Valueリスト文字列</param>
		/// <param name="sList">ドロップダウンアイテム</param>
		/// <remarks>
		/// <br>Note		: ＶＡＬＵＥリストを作成します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2008.01.08</br>
		/// </remarks>
		private void UnPrcCalcDivMakeValueList(ref ValueList vList, ref UltraGrid uGrid, string listStr, ref SortedList sList)
		{
			try
			{
				vList = uGrid.DisplayLayout.ValueLists.Add(listStr);

				if (sList != null)
				{
					// アイテム追加
					foreach (DictionaryEntry de in sList)
					{
						if ((int)de.Key != 1)
						{
							vList.ValueListItems.Add((Int32)de.Key, de.Value.ToString());
						}
					}
					vList.MaxDropDownItems = vList.ValueListItems.Count;
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// 掛率クラス格納処理（単価算出区分チェック用）
		/// </summary>
		/// <param name="rate">検索条件</param>
		/// <param name="rateBlanket">掛率一括検索条件</param>
		/// <remarks>
		/// <br>Note       : 掛率一括検索条件を掛率検索条件用クラスへ格納します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.04</br>
		/// </remarks>
		private void RateSearchUnitPrcCalcDiv(out Rate rate, ref RateBlanket rateBlanket)
		{
			rate = new Rate();
			
			rate.EnterpriseCode			= rateBlanket.EnterpriseCode;		// 企業コード
			rate.SectionCode			= rateBlanket.SectionCode;			// 拠点コード
			rate.UnitPriceKind			= "4";								// 単価種類（定価）
			rate.RateSettingDivide		= rateBlanket.RateSettingDivide;	// 掛率設定区分
			rate.RateMngGoodsCd			= rateBlanket.RateMngGoodsCd;		// 掛率設定区分（商品）
			rate.RateMngCustNm			= rateBlanket.RateMngGoodsNm;		// 掛率設定名称（商品）
			rate.RateMngCustCd			= rateBlanket.RateMngCustCd;		// 掛率設定区分（得意先）
			rate.RateMngCustNm			= rateBlanket.RateMngCustNm;		// 掛率設定名称（得意先）
			rate.GoodsMakerCd			= rateBlanket.GoodsMakerCd;			// 商品メーカーコード（商品Ｇ）
			rate.GoodsNo				= rateBlanket.GoodsNo;				// 商品番号
			rate.GoodsRateRank			= rateBlanket.GoodsRateRank;		// 商品掛率ランク
			rate.LargeGoodsGanreCode	= rateBlanket.LargeGoodsGanreCode;	// 商品区分Ｇコード
			rate.MediumGoodsGanreCode	= rateBlanket.MediumGoodsGanreCode;	// 商品区分コード
			rate.DetailGoodsGanreCode	= rateBlanket.DetailGoodsGanreCode;	// 商品区分詳細コード
			rate.EnterpriseGanreCode	= rateBlanket.EnterpriseGanreCode;	// 自社分類コード
			rate.BLGoodsCode			= rateBlanket.BLGoodsCode;			// ＢＬ商品コード
			rate.CustomerCode			= rateBlanket.CustomerCode;			// 得意先コード
			rate.CustRateGrpCode		= rateBlanket.CustRateGrpCode;		// 得意先掛率Ｇコード
			rate.SupplierCd				= rateBlanket.SupplierCd;			// 仕入先コード
			rate.SuppRateGrpCode		= rateBlanket.SuppRateGrpCode;		// 仕入先掛率Ｇコード
		}

		/// <summary>
		/// 掛率一括データと掛率データ比較処理
		/// </summary>
		/// <param name="gRow">掛率一括データロウ</param>
		/// <param name="rate">掛率データ</param>
		/// <remarks>
		/// <br>Note       : 掛率一括データと掛率データを比較します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void RateBlanketCompareToRate(UltraGridRow gRow, Rate rate)
		{
			//   0:一致, 1以上:不一致
			int chgCnt = 0;
			
			// 単価種類（4:定価）
			chgCnt += string.Equals(rate.UnitPriceKind, "4") ? 0 : 1;
			
			// 新旧区分
			chgCnt += string.Equals(RateBlanketAcs.NullChgStr(gRow.Cells[RateBlanketResult.OLDNEWDIVCD].Value).TrimEnd(),
									rate.OldNewDivCd.TrimEnd()) ? 0 : 1;
			// 掛率設定区分
			chgCnt += string.Equals(RateBlanketAcs.NullChgStr(gRow.Cells[RateBlanketResult.RATESETTINGDIVIDE].Value).TrimEnd(),
									rate.RateSettingDivide.TrimEnd()) ? 0 : 1;
			// メーカーコード
			chgCnt += RateBlanketAcs.NullChgInt(gRow.Cells[RateBlanketResult.GOODSMAKERCD].Value) ==
									rate.GoodsMakerCd ? 0 : 1;
			// 商品コード
			chgCnt += string.Equals(RateBlanketAcs.NullChgStr(gRow.Cells[RateBlanketResult.GOODSNO].Value).TrimEnd(),
									rate.GoodsNo.TrimEnd()) ? 0 : 1;
			// 商品掛率ランク
			chgCnt += string.Equals(RateBlanketAcs.NullChgStr(gRow.Cells[RateBlanketResult.GOODSRATERANK].Value).TrimEnd(),
									rate.GoodsRateRank.TrimEnd()) ? 0 : 1;
			// 商品区分Ｇコード
			chgCnt += string.Equals(RateBlanketAcs.NullChgStr(gRow.Cells[RateBlanketResult.LARGEGOODSGANRECODE].Value).TrimEnd(),
									rate.LargeGoodsGanreCode.TrimEnd()) ? 0 : 1;
			// 商品区分コード
			chgCnt += string.Equals(RateBlanketAcs.NullChgStr(gRow.Cells[RateBlanketResult.MEDIUMGOODSGANRECODE].Value).TrimEnd(),
									rate.MediumGoodsGanreCode.TrimEnd()) ? 0 : 1;
			// 商品区分詳細コード
			chgCnt += string.Equals(RateBlanketAcs.NullChgStr(gRow.Cells[RateBlanketResult.DETAILGOODSGANRECODE].Value).TrimEnd(),
									rate.DetailGoodsGanreCode.TrimEnd()) ? 0 : 1;
			// 自社分類コード
			chgCnt += RateBlanketAcs.NullChgInt(gRow.Cells[RateBlanketResult.ENTERPRISEGANRECODE].Value) ==
									rate.EnterpriseGanreCode ? 0 : 1;
			// ＢＬコード
			chgCnt += RateBlanketAcs.NullChgInt(gRow.Cells[RateBlanketResult.BLGOODSCODE].Value) ==
									rate.BLGoodsCode ? 0 : 1;
			// 得意先コード
			chgCnt += RateBlanketAcs.NullChgInt(gRow.Cells[RateBlanketResult.CUSTOMERCODE].Value) ==
									rate.CustomerCode ? 0 : 1;
			// 得意先掛率Ｇ
			chgCnt += RateBlanketAcs.NullChgInt(gRow.Cells[RateBlanketResult.CUSTRATEGRPCODE].Value) ==
									rate.CustRateGrpCode ? 0 : 1;
			// 仕入先コード
			chgCnt += RateBlanketAcs.NullChgInt(gRow.Cells[RateBlanketResult.SUPPLIERCD].Value) ==
									rate.SupplierCd ? 0 : 1;
			// 仕入先掛率Ｇ
			chgCnt += RateBlanketAcs.NullChgInt(gRow.Cells[RateBlanketResult.SUPPRATEGRPCODE].Value) ==
									rate.SuppRateGrpCode ? 0 : 1;

			// 検索条件項目が全て一致した場合、単価算出区分1を使用不可とする
			if (chgCnt == 0)
			{
				gRow.Cells[RateBlanketResult.UNITPRCCALCDIV].ValueList = this._gVListUnPrcCalcDivLimit;
				
				// 単価算出区分初期設定値を「2:原価x原価UP率」に変更する（「1:基準価格x掛率」が選択できないため）
				gRow.Cells[RateBlanketResult.UNITPRCCALCDIV].Value = 2;
			}
		}
		
		/// <summary>
		///	ＧＲＩＤ初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ＧＲＩＤの初期設定を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void GridInitialSetting()
		{
			this.rateBlanketResult_uGrid.DataSource = this._rateBlanketAcs.RateBlanketTable.DefaultView;
			
			//----------
			// 桁数
			//----------
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.NO].MaxLength					= 10;	// No
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSMAKERCD].MaxLength		= 6;	// メーカーコード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSNO].MaxLength			= 40;	// 商品コード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTOMERCODE].MaxLength		= 9;	// 得意先コード

			//----- ueno upd ---------- start 2008.02.18
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEFL].MaxLength			= 13;	// 単価 桁数12→13 整数10, ピリオド1, 小数点2
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCUNIT].MaxLength	= 10;	// 単価端数処理区分 桁数9→10  整数7,  ピリオド1, 小数点2
			//----- ueno upd ---------- end 2008.02.18

			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.RATEVAL].MaxLength			= 6;	// 掛率 整数3,  ピリオド1, 小数点2
			
			//----------
			// 未入力時
			//----------
			//----- ueno upd ---------- start 2008.02.18 "0" → "0.00" へ修正
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEFL].NullText				= "0.00";	// 単価
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.RATEVAL].NullText				= "0.00";	// 掛率
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCUNIT].NullText	= "0.00";	// 端数処理単位
			//----- ueno upd ---------- end 2008.02.18
			
			//----------
			// 入力不可
			//----------
			// No
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.NO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			// 区分
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.DIVIDE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			// 新旧名称
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.OLDNEWDIVCD_NM].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			// メーカーコード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSMAKERCD].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			// 商品コード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSNO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			// 得意先コード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTOMERCODE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			
			//--------------------
			// コンボボックス設定
			//--------------------
			// 価格区分（基準価格）
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEDIV].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEDIV].ValueList = this._gVListPriceDiv;

			// 単価算出区分
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNITPRCCALCDIV].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNITPRCCALCDIV].ValueList = this._gVListUnPrcCalcDiv;

			// 単価端数処理区分
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCDIV].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCDIV].ValueList = this._gVListUnPrcFracProcUnit;

			// 特売区分コード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BARGAINCD].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BARGAINCD].ValueList = this._gVListBargainCd;

			//------------------
			// グリッド外観設定
			//------------------
			// コンボボックス外観設定
			Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
			appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(227)), ((System.Byte)(156)));
			appearance.ForeColor = System.Drawing.Color.Black;
			appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this._gVListUnPrcCalcDiv.Appearance = appearance;
			this._gVListUnPrcFracProcUnit.Appearance = appearance;

			// 数値項目は文字位置を右寄せにする
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.NO].CellAppearance.TextHAlign = HAlign.Right;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSMAKERCD].CellAppearance.TextHAlign = HAlign.Right;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTOMERCODE].CellAppearance.TextHAlign = HAlign.Right;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEFL].CellAppearance.TextHAlign = HAlign.Right;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.RATEVAL].CellAppearance.TextHAlign = HAlign.Right;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCUNIT].CellAppearance.TextHAlign = HAlign.Right;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BARGAINCD].CellAppearance.TextHAlign = HAlign.Right;

			// 入力フォーマット
			//----- ueno upd ---------- start 2008.02.07 Nullフォーマット追加
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEFL].Format = "###,#0.00;''";
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.RATEVAL].Format = "#0.00;''";
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCUNIT].Format = "###,#0.00;''";
			//----- ueno upd ---------- end 2008.02.07

			// 境界線
			this.rateBlanketResult_uGrid.DisplayLayout.Appearance.BorderColor = Color.FromArgb(1, 68, 208);
		}

		/// <summary>
		///	ＧＲＩＤカラム幅初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ＧＲＩＤのカラム幅初期設定を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void GridInitialSettingWidth()
		{
			//--- ウィンドウ固定表示項目 ---//
			// NO
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.NO].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.NO].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// 区分
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.DIVIDE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.DIVIDE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// 新旧名称
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.OLDNEWDIVCD_NM].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.OLDNEWDIVCD_NM].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// 商品メーカーコード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSMAKERCD].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSMAKERCD].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// 商品番号
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSNO].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSNO].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// 商品掛率ランク
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSRATERANK].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSRATERANK].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// 商品区分グループコード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.LARGEGOODSGANRECODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.LARGEGOODSGANRECODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// 商品区分コード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.MEDIUMGOODSGANRECODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.MEDIUMGOODSGANRECODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// 商品区分詳細コード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.DETAILGOODSGANRECODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.DETAILGOODSGANRECODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// 自社分類コード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.ENTERPRISEGANRECODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.ENTERPRISEGANRECODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// BL商品コード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BLGOODSCODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BLGOODSCODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// 得意先コード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTOMERCODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTOMERCODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// 得意先掛率グループコード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTRATEGRPCODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTRATEGRPCODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// 仕入先コード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.SUPPLIERCD].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.SUPPLIERCD].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// 仕入先掛率グループコード
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.SUPPRATEGRPCODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.SUPPRATEGRPCODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			//--- 固定表示項目 ---//
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.NO].Width = 28 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.DIVIDE].Width = 45 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.OLDNEWDIVCD_NM].Width = 45 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSMAKERCD].Width = 75 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSNO].Width = 100 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTOMERCODE].Width = 100 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTRATEGRPCODE].Width = 140 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.SUPPLIERCD].Width = 100 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.SUPPRATEGRPCODE].Width = 140 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.RATESTARTDATE].Width = 110 + FILTER_LENGTH;

			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEFL].Width = 120 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEDIV].Width = 85 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNITPRCCALCDIV].Width = 140 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.RATEVAL].Width = 50 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCUNIT].Width = 120 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCDIV].Width = 80 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BARGAINCD].Width = 60 + FILTER_LENGTH;

			//--- 変動表示項目 ---//
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSRATERANK].Width = 100 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.LARGEGOODSGANRECODE].Width = 150 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.MEDIUMGOODSGANRECODE].Width = 110 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.DETAILGOODSGANRECODE].Width = 145 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.ENTERPRISEGANRECODE].Width = 110 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BLGOODSCODE].Width = 100 + FILTER_LENGTH;
		}

		/// <summary>
		///	ＧＲＩＤ設定変更処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ＧＲＩＤの設定を変更します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void GridSettingChange()
		{
			//------------
			// 各条件判定
			//------------
			RateBlanket searchRateBlanket = this._rateBlanketAcs.GetSearchRateBlanket;
			
			// 単価種類
			string wkUnitPriceKind = searchRateBlanket.UnitPriceKind;

			// 掛率設定区分（商品）
			string wkRateMngGoodsCd = searchRateBlanket.RateMngGoodsCd.Trim();
			
			//----------
			// 入力不可
			//----------
			if (string.Equals(wkUnitPriceKind, "1") == true)
			{
				// 編集可（全部選択可）
				this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNITPRCCALCDIV].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
				this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNITPRCCALCDIV].TabStop = true;
			}
			else
			{
				// 編集不可（1のみ選択可）
				this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNITPRCCALCDIV].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNITPRCCALCDIV].TabStop = false;
			}

			// 単価のとき表示する項目
			if (string.Equals(wkRateMngGoodsCd, "A") == true)
			{
				// 単価入力可
				this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEFL].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

			}
			// 商品Ｇのとき表示する項目
			else
			{
				// 単価入力不可
				this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEFL].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			}
			
			//----------
			// 表示制御
			//----------
			Infragistics.Win.UltraWinGrid.UltraGridBand band = this.rateBlanketResult_uGrid.DisplayLayout.Bands[0];
			
			// NO（固定表示）
			GridDispSetting(ref band, RateBlanketResult.NO, false);
			// 区分（固定表示）
			GridDispSetting(ref band, RateBlanketResult.DIVIDE, false);
			// 区分コード
			GridDispSetting(ref band, RateBlanketResult.DIVIDE_CD, true);
			// 新旧名称（固定表示）
			GridDispSetting(ref band, RateBlanketResult.OLDNEWDIVCD_NM, false);
			// 設定フラグ
			GridDispSetting(ref band, RateBlanketResult.SET_FLAG, true);
			// 作成日付
			GridDispSetting(ref band, RateBlanketResult.CREATEDATETIME, true);
			// 更新日付
			GridDispSetting(ref band, RateBlanketResult.UPDATEDATETIME, true);
			// 企業コード
			GridDispSetting(ref band, RateBlanketResult.ENTERPRISECODE, true);
			// GUID
			GridDispSetting(ref band, RateBlanketResult.FILEHEADERGUID, true);
			// 更新従業員コード
			GridDispSetting(ref band, RateBlanketResult.UPDEMPLOYEECODE, true);
			// 更新アセンブリID1
			GridDispSetting(ref band, RateBlanketResult.UPDASSEMBLYID1, true);
			// 更新アセンブリID2
			GridDispSetting(ref band, RateBlanketResult.UPDASSEMBLYID2, true);
			// 論理削除区分
			GridDispSetting(ref band, RateBlanketResult.LOGICALDELETECODE, true);
			// 拠点コード
			GridDispSetting(ref band, RateBlanketResult.SECTIONCODE, true);
			// 単価掛率設定区分
			GridDispSetting(ref band, RateBlanketResult.UNITRATESETDIVCD, true);
			// 新旧区分
			GridDispSetting(ref band, RateBlanketResult.OLDNEWDIVCD, true);
			// 単価種類
			GridDispSetting(ref band, RateBlanketResult.UNITPRICEKIND, true);
			// 掛率設定区分
			GridDispSetting(ref band, RateBlanketResult.RATESETTINGDIVIDE, true);
			// 掛率設定区分（商品）
			GridDispSetting(ref band, RateBlanketResult.RATEMNGGOODSCD, true);
			// 掛率設定名称（商品）
			GridDispSetting(ref band, RateBlanketResult.RATEMNGGOODSNM, true);
			// 掛率設定区分（得意先）
			GridDispSetting(ref band, RateBlanketResult.RATEMNGCUSTCD, true);
			// 掛率設定名称（得意先）
			GridDispSetting(ref band, RateBlanketResult.RATEMNGCUSTNM, true);

			//----- ueno upd ---------- start 2008.03.28 メーカーコード無しも有りうる
			// 商品メーカーコード（変動表示）
			GridDispSetting(ref band, RateBlanketResult.GOODSMAKERCD, RateBlanket._gridHdnGoodsMakerCd);
			//----- ueno upd ---------- end 2008.03.28

			// 商品番号（変動表示）
			GridDispSetting(ref band, RateBlanketResult.GOODSNO, RateBlanket._gridHdnGoodsNo);
			// 商品掛率ランク（変動表示）
			GridDispSetting(ref band, RateBlanketResult.GOODSRATERANK, RateBlanket._gridHdnGoodsRateRankCd);
			// 商品区分グループコード（変動表示）
			GridDispSetting(ref band, RateBlanketResult.LARGEGOODSGANRECODE, RateBlanket._gridHdnLargeGoodsGanreCode);
			// 商品区分コード（変動表示）
			GridDispSetting(ref band, RateBlanketResult.MEDIUMGOODSGANRECODE, RateBlanket._gridHdnMediumGoodsGanreCode);
			// 商品区分詳細コード（変動表示）
			GridDispSetting(ref band, RateBlanketResult.DETAILGOODSGANRECODE, RateBlanket._gridHdnDetailGoodsGanreCode);
			// 自社分類コード（変動表示）
			GridDispSetting(ref band, RateBlanketResult.ENTERPRISEGANRECODE, RateBlanket._gridHdnEnterpriseGanreCode);
			// BL商品コード（変動表示）
			GridDispSetting(ref band, RateBlanketResult.BLGOODSCODE, RateBlanket._gridHdnBLGoodsCode);
			// 得意先コード（変動表示）
			GridDispSetting(ref band, RateBlanketResult.CUSTOMERCODE, RateBlanket._gridHdnCustomerCode);
			// 得意先掛率グループコード（変動表示）
			GridDispSetting(ref band, RateBlanketResult.CUSTRATEGRPCODE, RateBlanket._gridHdnCustRateGrpCode);
			// 仕入先コード（変動表示）
			GridDispSetting(ref band, RateBlanketResult.SUPPLIERCD, RateBlanket._gridHdnSupplierCd);
			// 仕入先掛率グループコード（変動表示）
			GridDispSetting(ref band, RateBlanketResult.SUPPRATEGRPCODE, RateBlanket._gridHdnSuppRateGrpCode);

			// 掛率開始日（固定表示）
			GridDispSetting(ref band, RateBlanketResult.RATESTARTDATE, false);
			// ロット数
			GridDispSetting(ref band, RateBlanketResult.LOTCOUNT, true);
			// 単価（固定表示）
			GridDispSetting(ref band, RateBlanketResult.PRICEFL, false);
			// 基準価格（固定表示）
			GridDispSetting(ref band, RateBlanketResult.PRICEDIV, false);
			// 単価算出区分（固定表示）
			GridDispSetting(ref band, RateBlanketResult.UNITPRCCALCDIV, false);
			// 掛率（固定表示）
			GridDispSetting(ref band, RateBlanketResult.RATEVAL, false);
			// 単価端数処理単位（固定表示）
			GridDispSetting(ref band, RateBlanketResult.UNPRCFRACPROCUNIT, false);
			// 単価端数処理区分（固定表示）
			GridDispSetting(ref band, RateBlanketResult.UNPRCFRACPROCDIV, false);
			// 特売区分コード（固定表示）
			GridDispSetting(ref band, RateBlanketResult.BARGAINCD, false);
		}

		/// <summary>
		///	ＧＲＩＤ表示設定処理
		/// </summary>
		/// <param name="band">バンド</param>
		/// <param name="columnTitle">カラム名</param>
		/// <param name="hiddenFlag">非表示フラグ（false:表示, true:非表示）</param>
		/// <remarks>
		/// <br>Note		: ＧＲＩＤグループの表示設定を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2008.01.18</br>
		/// </remarks>
		private void GridDispSetting(ref Infragistics.Win.UltraWinGrid.UltraGridBand band, string columnTitle, bool hiddenFlag)
		{
			band.Columns[columnTitle].Hidden = hiddenFlag;
		}

		/// <summary>
		/// 画面表示時処理
		/// </summary>
		/// <returns>Status(ConstantManagement.MethodResult)</returns>
		/// <remarks>
		/// <br>Note		: 画面表示時処理を実行する。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private int ShowDataProc ( )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				if ( this._isFirstsetting )
				{
					// データバインド
					this._isFirstsetting = false;	// データをバインドするために一時的にoff
					this._isFirstsetting = true;	// 元に戻す
					
					// グリッドコンボボックス作成
					// 価格区分（基準価格）
					MakeValueList(ref this._gVListPriceDiv, ref this.rateBlanketResult_uGrid, PRICEDIV, ref RateBlanket._priceDivSList);
					
					// 単価算出区分
					MakeValueList(ref this._gVListUnPrcCalcDiv, ref this.rateBlanketResult_uGrid, UNITPRCCALCDIVLIST, ref RateBlanket._unPrcCalcDivTable);

					// 単価算出区分（限定版）
					UnPrcCalcDivMakeValueList(ref this._gVListUnPrcCalcDivLimit, ref this.rateBlanketResult_uGrid, UNITPRCCALCDIVLIST_LIMIT, ref RateBlanket._unPrcCalcDivTable);

					// 単価端数処理区分
					MakeValueList(ref this._gVListUnPrcFracProcUnit, ref this.rateBlanketResult_uGrid, UNPRCFRACPROCDIVLIST, ref RateBlanket._unPrcFracProcDivTable);
					
					// 特売区分コード
					MakeValueList(ref this._gVListBargainCd, ref this.rateBlanketResult_uGrid, BARGAINCD, ref RateBlanket._bargainCdSList);		

					// 初回起動時のみ画面設定
					// グリッドキーマッピング作成
					this.MakeGridKeyMapping(this.rateBlanketResult_uGrid);

					// グリッド初期設定
					GridInitialSetting();

					// グリッド幅設定
					GridInitialSettingWidth();

					// カラム幅
					// 文字サイズ
					this._isFirstsetting = false;
					this._isEventAutoFillColumn = true;
				}
				else
				{
				}
				
				//=======================================================================================
				// 単価算出区分チェック（単価種類=売上単価時）
				//   掛率設定区分が同じで単価種類=定価のレコードが既に存在している場合、
				//   単価算出区分=1:基準価格x掛率は設定不可とする。
				//   例. 商品Aの価格ﾏｽﾀの定価:\8,000
				//     ①定価     単品設定 A3 ﾒｰｶｰ+商品+得意先 商品A ﾕｰｻﾞｰ定価\10,000
				//     ②売上単価 単品設定 A3 ﾒｰｶｰ+商品+得意先 商品A 単価算出区分1:基準価格x掛率 掛率80%
				//       
				//       ②の基準価格は価格ﾏｽﾀの\8,000が適用され、\8,000 x 80% = \6,400
				//       正しくは、ﾕｰｻﾞｰ定価の\10,000を適用し、\10,000 x 80% = \8,000 となる
				//=======================================================================================
				
				// 検索条件取得
				RateBlanket searchRateBlanket = this._rateBlanketAcs.GetSearchRateBlanket;

				// 単価種類が売上単価の場合、単価算出区分チェックを行う
				if (searchRateBlanket.UnitPriceKind == "1")
				{
					// 掛率検索用条件設定
					Rate rate = null;
					RateSearchUnitPrcCalcDiv(out rate, ref searchRateBlanket);

					// 掛率検索（論理削除含む）
					ArrayList retList = null;
					string message = "";
					int ret = this._rateAcs.SearchRate(out retList, ref rate, ConstantManagement.LogicalMode.GetData01, out message);

					if (ret == 0)
					{
						// 掛率一括検索結果と比較し、一致しているレコードの単価算出区分を設定する
						foreach (UltraGridRow uRow in this.rateBlanketResult_uGrid.Rows)
						{
							foreach (Rate rateWk in (ArrayList)retList)
							{
								RateBlanketCompareToRate(uRow, rateWk);
							}
						}
					}
				}
				
				// グリッド設定変更
				GridSettingChange();
				
				// アクティブ化
				if ( this.rateBlanketResult_uGrid.Rows.Count > 0 )
				{
					this.rateBlanketResult_uGrid.Rows[0].Cells[RateBlanketResult.RATESTARTDATE].Activate();
				}
			}
			catch ( Exception ex )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				this.MsgDispProc( "掛率マスタ一括登録データの表示に失敗しました。", status, "ShowDataProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP );
			}
			finally
			{
			}

			return status;
		}

		/// <summary>
		/// グリッド項目全体チェック処理
		/// </summary>
		/// <param name="uRow">UltraGridRow</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>チェック結果(true:OK, false:NG)</returns>
		/// <remarks>
		/// <br>Note       : グリッド項目全体に対して過不足が無いがチェックします。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private bool InpGridDataCheck(UltraGridRow uRow, ref string errMsg)
		{
			//--------------------
			// 項目未入力チェック
			//--------------------
			// 未入力時（単価 == 0, 掛率 == 0, 単価端数処理単位 == 0）
			if ((RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.PRICEFL].Value) == 0)
				&& (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.RATEVAL].Value) == 0)
				&& (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value) == 0))
			{
				// 新規データ(DIVIDE_CD == 1)の場合、全て未入力は正常
				if (RateBlanketAcs.NullChgInt(uRow.Cells[RateBlanketResult.DIVIDE_CD].Value) == 1)
				{
					return true;
				}
				// 既存データの場合エラー
				else
				{
					errMsg = RATE_ERR_MSG;
					
					// エラー行にフォーカスをセット
					uRow.Cells[RateBlanketResult.PRICEFL].Activate();
					return false;
				}
			}
			
			// 単価設定の場合（単価 > 0）
			if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.PRICEFL].Value) > 0)
			{
				// 掛率 != 0
				if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.RATEVAL].Value) != 0)
				{
					errMsg = "掛率が設定されています。";

					// エラー行にフォーカスをセット
					uRow.Cells[RateBlanketResult.RATEVAL].Activate();
					return false;
				}
				// 端数処理単位 != 0
				if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value) != 0)
				{
					errMsg = "端数処理単位が設定されています。";
					
					// エラー行にフォーカスをセット
					uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Activate();
					return false;
				}
			}
			// 掛率設定の場合（単価 == 0）
			else
			{
				// 掛率 == 0
				if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.RATEVAL].Value) == 0)
				{
					errMsg = "掛率を設定してください。";

					// エラー行にフォーカスをセット
					uRow.Cells[RateBlanketResult.RATEVAL].Activate();
					return false;
				}
				// 端数処理単位 == 0.00
				if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value) == 0)
				{
					errMsg = "端数処理単位を設定してください。";

					// エラー行にフォーカスをセット
					uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Activate();
					return false;
				}
			}

			// 掛率の桁数チェック（3桁より多い場合エラー）
			if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.RATEVAL].Value) > 999.99)
			{
				errMsg = "掛率の桁数が不正です。";

				// エラー行にフォーカスをセット
				uRow.Cells[RateBlanketResult.RATEVAL].Activate();
				return false;
			}

			//----- ueno add ---------- start 2008.02.18
			// 端数処理単位の桁数チェック（整数7桁, 小数点以下2桁より多い場合エラー）
			if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value) > 9999999.99)
			{
				errMsg = "端数処理単位の桁数が不正です。";

				// エラー行にフォーカスをセット
				uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Activate();
				return false;
			}
			//----- ueno add ---------- end 2008.02.18

			//--------------------
			// 掛率開始日チェック
			//--------------------
			// ワークに格納
			string wkRateStartDateStr = uRow.Cells[RateBlanketResult.RATESTARTDATE].Text;

			// 掛率開始日未入力時
			if (wkRateStartDateStr == "")
			{
				errMsg = RATESTARTDATE_NOTINPUT_MSG;
				uRow.Cells[RateBlanketResult.RATESTARTDATE].Activate();
				return false;
			}
			// 不正データチェック			
			else
			{
				// "年"、"月"、"日"の位置及び、桁数チェック
				if((wkRateStartDateStr.IndexOf("年", 0) == 4)
					&& (wkRateStartDateStr.IndexOf("月", 0) == 7)
					&& (wkRateStartDateStr.IndexOf("日", 0) == 10)
					&& (wkRateStartDateStr.Length == 11))
				{
					// そのまま進む
				}
				else
				{
					errMsg = RATESTARTDATE_NOTCORRECT_MSG;
					
					// エラー行にフォーカスをセット
					uRow.Cells[RateBlanketResult.RATESTARTDATE].Activate();
					return false;
				}
				
				// 年月日データに"__"が入っている場合、"0"に変換する
				if (wkRateStartDateStr.Contains("_") == true)
				{
					wkRateStartDateStr = wkRateStartDateStr.Replace("_", "0");
				}
				
				// 年月日取得
				int dYear = RateBlanketAcs.NullChgInt(wkRateStartDateStr.Substring(0, 4));
				int dMonth = RateBlanketAcs.NullChgInt(wkRateStartDateStr.Substring(5, 2));
				int dDay = RateBlanketAcs.NullChgInt(wkRateStartDateStr.Substring(8, 2));

				// 年月日データがゼロの場合
				if ((dYear == 0) || (dMonth == 0) || (dDay == 0))
				{
					errMsg = RATESTARTDATE_NOTCORRECT_MSG;

					// エラー行にフォーカスをセット
					uRow.Cells[RateBlanketResult.RATESTARTDATE].Activate();
					return false;
				}

				// 入力が正しい日付か？
				int inputDate_int = (dYear * 10000) + (dMonth * 100) + dDay;
				DateTime inputDate = TDateTime.LongDateToDateTime(inputDate_int);
				
				// エラー
				if (inputDate == DateTime.MinValue)
				{
					errMsg = RATESTARTDATE_NOTCORRECT_MSG;
					
					// エラー行にフォーカスをセット
					uRow.Cells[RateBlanketResult.RATESTARTDATE].Activate();
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="message">表示メッセージ</param>
		/// <param name="iLevel">エラーレベル</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : エラーメッセージの表示を行います。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private DialogResult MsgDispProc( string message, emErrorLevel iLevel )
		{
			// メッセージ表示
			return TMsgDisp.Show( 
				this,                            // 親ウィンドウフォーム
				iLevel,                             // エラーレベル
				this.GetType().ToString(),          // アセンブリＩＤまたはクラスＩＤ
				message,                            // 表示するメッセージ
				0,                                  // ステータス値
				MessageBoxButtons.OK );             // 表示するボタン
		}

		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="msg">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <param name="proc">発生元メソッドID</param>
		/// <param name="iLevel">エラーレベル</param>
		/// <remarks>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private DialogResult MsgDispProc ( string msg, int status, string proc, emErrorLevel iLevel )
		{
			return TMsgDisp.Show(
				iLevel,						        //エラーレベル
				"DCKHN09180UB",                       //UNIT　ID
				"掛率マスタ一括登録",                            //プログラム名称
				proc,                               //プロセスID
				"",                                 //オペレーション
				msg,                                //メッセージ
				status,                             //ステータス
				null,                               //オブジェクト
				MessageBoxButtons.OK,               //ダイアログボタン指定
				MessageBoxDefaultButton.Button1     //ダイアログ初期ボタン指定
				);
		}

		/// <summary>
		/// エラーMSG表示処理(Exception)
		/// </summary>
		/// <param name="msg">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <param name="proc">発生元メソッドID</param>
		/// <param name="ex">例外情報</param>
		/// <param name="iLevel">エラーレベル</param>
		/// <remarks>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private DialogResult MsgDispProc ( string msg, int status, string proc, Exception ex, emErrorLevel iLevel )
		{
			return this.MsgDispProc(msg + "\r\n" + ex.Message, status, proc, iLevel);
		}
	
		/// <summary>
		/// カラム列幅調整
		/// </summary>
		/// <remarks>
		/// <br>Note       : カラムの列幅を調整します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.04.24</br>
		/// </remarks>
		private void ColumnPerformAutoResize()
		{
			this._isEventAutoFillColumn = false;

			try
			{
				bool isAutoCol = this.uce_ColSizeAutoSetting.Checked;

				this.uce_ColSizeAutoSetting.Checked = false;

				for (int i = 0; i < this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns.Count; i++)
				{
					this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.VisibleRows, true);
				}
			}
			finally
			{
				this._isEventAutoFillColumn = true;
			}
		}

		/// <summary>
		/// 入力不可 セル外観取得処理
		/// </summary>
		/// <returns>外観情報</returns>
		/// <remarks>
		/// <br>Note       : 入力不可セルの外観情報を取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private Infragistics.Win.Appearance GetImpossibleCellAppearance()
		{
			Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
			appearance.BackColor = Color.FromArgb(251, 230, 148);
			appearance.BackColor2 = Color.FromArgb(238, 149, 21);
			appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance.ForeColor = Color.Black;
			return appearance;
		}

		/// <summary>
		/// 入力可能/非アクティブ セル外観取得処理
		/// </summary>
		/// <returns>外観情報</returns>
		/// <remarks>
		/// <br>Note       : 入力可能非アクティブセルの外観情報を取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private Infragistics.Win.Appearance GetPossibleCellAppearance()
		{
			Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
			appearance.BackColor = Color.White;
			appearance.BackColor2 = Color.FromArgb(238, 149, 21);
			appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance.ForeColor = Color.Black;
			return appearance;
		}

		//----- ueno add ---------- start 2008.02.18
		/// <summary>
		/// 数値入力チェック処理
		/// </summary>
		/// <param name="keta">桁数(マイナス符号を含まず)</param>
		/// <param name="priod">小数点以下桁数</param>
		/// <param name="prevVal">現在の文字列</param>
		/// <param name="key">入力されたキー値</param>
		/// <param name="selstart">カーソル位置</param>
		/// <param name="sellength">選択文字長</param>
		/// <param name="minusFlg">マイナス入力可？</param>
		/// <returns>true=入力可,false=入力不可</returns>
		/// <remarks>
		/// <br>Note       : グリッド内の数値入力をチェックします。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.02.18</br>
		/// </remarks>
		private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
		{
			// 制御キーが押された？
			if (Char.IsControl(key))
			{
				return true;
			}
			// 数値以外は、ＮＧ
			if (!Char.IsDigit(key))
			{
				// 小数点または、マイナス以外
				if ((key != '.') && (key != '-'))
				{
					return false;
				}
			}

			// キーが押されたと仮定した場合の文字列を生成する。
			string _strResult = "";
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			// マイナスのチェック
			if (key == '-')
			{
				if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
				{
					return false;
				}
			}

			// 小数点のチェック
			if (key == '.')
			{
				if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
				{
					return false;
				}
			}
			// キーが押された結果の文字列を生成する。
			_strResult = prevVal.Substring(0, selstart)
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

			// 桁数チェック！
			if (_strResult.Length > keta)
			{
				if (_strResult[0] == '-')
				{
					if (_strResult.Length > (keta + 1))
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}

			// 小数点以下のチェック
			if (priod > 0)
			{
				// 小数点の位置決定
				int _pointPos = _strResult.IndexOf('.');

				// 整数部に入力可能な桁数を決定！
				int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
				// 整数部の桁数をチェック
				if (_pointPos != -1)
				{
					if (_pointPos > _Rketa)
					{
						return false;
					}
				}
				else
				{
					if (_strResult.Length > _Rketa)
					{
						return false;
					}
				}

				// 小数部の桁数をチェック
				if (_pointPos != -1)
				{
					// 小数部の桁数を計算
					int _priketa = _strResult.Length - _pointPos - 1;
					if (priod < _priketa)
					{
						return false;
					}
				}
			}
			return true;
		}
		//----- ueno add ---------- end 2008.02.18

		/// <summary>
		/// 置換画面起動処理
		/// </summary>
		/// <remarks>
		/// <return>ステータス</return>
		/// <br>Note       : 置換ボタンが押下された時に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private int ReplaceFormStart()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			try
			{
				if (this._replaceForm == null)
				{
					this._replaceForm = new DCKHN09180UC(ref this.rateBlanketResult_uGrid);
				}
				this._replaceForm.ShowDialog();
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				this.MsgDispProc("置換画面の起動に失敗しました。", status, "ub_replaceButton_Click", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
			}
			return status;
		}

		#region Control Event
		/// <summary>
		/// DCKHN09180UB_Load
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがファイルを読み込むときに発生する</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// <br>Update Note: </br>
		/// </remarks>
		private void DCKHN09180UB_Load ( object sender, EventArgs e )
		{
			// 初期設定
			InitialLoadScreen();
		}

		/// <summary>
		/// DCKHN09180UB_FormClosing
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがフォームを閉じるときに発生する</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.04.27</br>
		/// <br>Update Note: </br>
		/// </remarks>
		private void DCKHN09180UB_FormClosing ( object sender, FormClosingEventArgs e )
		{
			// グリッド設定保存
			if (this._gridStateController != null)
			{
				this._gridStateController.GetGridStateFromGrid(ref this.rateBlanketResult_uGrid);
				this._gridStateController.SaveGridState(ct_FileName_ColDisplayStatus);
			}
		}

		/// <summary>Control.ChangeFocus イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォーカス移動時に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

			switch(e.PrevCtrl.Name)
			{
				// GridにControlがある時のReturn/Tabの動き設定
				case "rateBlanketResult_uGrid":
					{
						// リターンキーの時
						if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
						{
							e.NextCtrl = null;

							if (this.rateBlanketResult_uGrid.ActiveCell != null)
							{
								// 最終セルの時
								if ((this.rateBlanketResult_uGrid.ActiveCell.Row.Index == this.rateBlanketResult_uGrid.Rows.Count - 1) &&
									(this.rateBlanketResult_uGrid.ActiveCell.Column.Index == this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BARGAINCD].Index))
								{
									// 置換ボタンへフォーカスセット
									this.ub_replaceButton.Focus();
								}
								else
								{
									// 「特売」の場合は次のRowに
									if (this.rateBlanketResult_uGrid.ActiveCell.Column.Index == this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BARGAINCD].Index)
									{
										// 次のRowにフォーカス遷移
										this.rateBlanketResult_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);
										this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.EnterEditMode);
									}
									else
									{
										// 次のCellにフォーカス遷移
										this.rateBlanketResult_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
									}
								}
							}
						}
						break;
					}
				case "ub_replaceButton":
					{
						// リターンキーの場合
						if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
						{
							// アクティブ化
							if (this.rateBlanketResult_uGrid.Rows.Count > 0)
							{
								this.rateBlanketResult_uGrid.Focus();
								this.rateBlanketResult_uGrid.Rows[0].Cells[RateBlanketResult.RATESTARTDATE].Activate();
							}
						}
						break;
					}
			}
		}

		/// <summary>置換ボタンイベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 置換ボタンが押下された時に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void ub_replaceButton_Click(object sender, EventArgs e)
		{
			ReplaceFormStart();			
		}

		#endregion Control Event

		#region Grid Event

		/// <summary>
		/// UltraGrid.KeyDownイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: グリッド上で何かキーを押下した時の制御を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_KeyDown(object sender, KeyEventArgs e)
		{
			// Grid編集中の時
			if ((this.rateBlanketResult_uGrid.ActiveCell != null) &&
				(this.rateBlanketResult_uGrid.ActiveCell.IsInEditMode == true))
			{
				int rowIndex = this.rateBlanketResult_uGrid.ActiveCell.Row.Index;

				switch (e.KeyCode)
				{
					case Keys.Up:
						{
							if (this.rateBlanketResult_uGrid.ActiveCell.Row.Index == 0)
							{
								break;
							}
							else
							{
								// コンボボックスがアクティブな場合、上のセルへは移動しない
								bool droppedDownFlag = false;
								if (this.rateBlanketResult_uGrid.ActiveCell.ValueListResolved != null)
								{
									droppedDownFlag = this.rateBlanketResult_uGrid.ActiveCell.ValueListResolved.IsDroppedDown;
								}

								if (droppedDownFlag == false)
								{
									this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.AboveCell);
									e.Handled = true;
								}
							}
							break;
						}

					case Keys.Down:
						{
							if (this.rateBlanketResult_uGrid.ActiveCell.Row.Index == (this.rateBlanketResult_uGrid.Rows.Count - 1))
							{
								this.uce_ColSizeAutoSetting.Focus();
							}
							else
							{
								// コンボボックスがアクティブな場合、下のセルへは移動しない
								bool droppedDownFlag = false;
								if (this.rateBlanketResult_uGrid.ActiveCell.ValueListResolved != null)
								{
									droppedDownFlag = this.rateBlanketResult_uGrid.ActiveCell.ValueListResolved.IsDroppedDown;
								}
								
								if (droppedDownFlag == false)
								{
									this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.BelowCell);
									e.Handled = true;
								}
							}
							break;
						}
					case Keys.Right:
						{
							// アクティブセルが「単価」、「掛率」、「単価端数処理単位」の何れかの場合
							if ((this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.PRICEFL])
								|| (this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.RATEVAL])
								|| (this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.UNPRCFRACPROCUNIT]))
							{
								if ((this.rateBlanketResult_uGrid.ActiveCell.SelLength == 0) &&
									(this.rateBlanketResult_uGrid.ActiveCell.SelStart == this.rateBlanketResult_uGrid.ActiveCell.Text.Length))
								{
									// 「特売」の場合は次のRowに
									if (this.rateBlanketResult_uGrid.ActiveCell.Column.Index == this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BARGAINCD].Index)
									{
										this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.NextRow);
										this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.EnterEditMode);
									}
									else
									{
										this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.NextCell);
									}
									e.Handled = true;
								}
							}
							else
							{
								this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.NextCell);
								e.Handled = true;
							}
							break;
						}
					case Keys.Left:
						{
							// アクティブセルが「掛率開始日」、「単価」、「掛率」、「単価端数処理単位」の何れかの場合
							if ((this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.RATESTARTDATE])
								|| (this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.PRICEFL])
								|| (this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.RATEVAL])
								|| (this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.UNPRCFRACPROCUNIT]))
							{
								// ２行目以降で「掛率開始日」の時
								if ((this.rateBlanketResult_uGrid.ActiveCell.SelLength == 0) &&
									(this.rateBlanketResult_uGrid.ActiveCell.SelStart == 0) &&
									(this.rateBlanketResult_uGrid.ActiveCell.Row.Index != 0) &&
									(this.rateBlanketResult_uGrid.ActiveCell.Column.Index == this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.RATESTARTDATE].Index))
								{
									// 上の行の「特売」に
									this.rateBlanketResult_uGrid.Rows[this.rateBlanketResult_uGrid.ActiveCell.Row.Index - 1].Cells[RateBlanketResult.BARGAINCD].Activate();
									e.Handled = true;
								}
								else if ((this.rateBlanketResult_uGrid.ActiveCell.SelLength == 0) &&
									(this.rateBlanketResult_uGrid.ActiveCell.SelStart == 0))
								{
									// 手前のCellに
									this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.PrevCell);
									e.Handled = true;
								}
							}
							else
							{
								this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.PrevCell);
								e.Handled = true;
							}
							break;
						}
				}
			}
		}

		/// <summary>
		/// UltraGrid.AfterRowActivateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 行がアクティブ化された時に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_AfterRowActivate(object sender, EventArgs e)
		{
			// RowがActive化されていて、CellがActive化されていない場合、「掛率開始日」をActiveate
			if (this.rateBlanketResult_uGrid.ActiveRow == null)
			{
				return;
			}

			if (this.rateBlanketResult_uGrid.ActiveCell == null)
			{
				this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.RATESTARTDATE].Activate();
				this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.EnterEditMode);
			}
		}

		/// <summary>
		/// UltraGrid.BeforeRowDeactivateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>						
		/// <br>Note		: 行が非アクティブ化される直前に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_BeforeRowDeactivate(object sender, CancelEventArgs e)
		{
			// アクティブだった行のセルの外観を解除
			foreach (UltraGridCell wkCell in this.rateBlanketResult_uGrid.ActiveRow.Cells)
			{
				wkCell.Appearance = null;
			}
		}

		/// <summary>
		/// UltraGrid.AfterCellActivateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: セルがアクティブ化された時に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_AfterCellActivate(object sender, EventArgs e)
		{
			// 「No」「区分」「新旧」「ﾒｰｶｰ」「商品ｺｰﾄﾞ」「商品掛率ﾗﾝｸ」「商品区分Ｇｺｰﾄﾞ」「商品区分ｺｰﾄﾞ」「商品区分詳細ｺｰﾄﾞ」
			// 「自社分類ｺｰﾄﾞ」「ＢＬ商品ｺｰﾄﾞ」「得意先ｺｰﾄﾞ」「得意先掛率Ｇ」「仕入先ｺｰﾄﾞ」「仕入先掛率Ｇ」Cellの時
			if((this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.NO])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.DIVIDE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.OLDNEWDIVCD_NM])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.GOODSMAKERCD])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.GOODSNO])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.GOODSRATERANK])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.LARGEGOODSGANRECODE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.MEDIUMGOODSGANRECODE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.DETAILGOODSGANRECODE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.ENTERPRISEGANRECODE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.BLGOODSCODE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.CUSTOMERCODE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.CUSTRATEGRPCODE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.SUPPLIERCD])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.SUPPRATEGRPCODE]))
			{
				// ActiveCellを「掛率開始日」へセットする
				this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.RATESTARTDATE].Activate();
				this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.EnterEditMode);
			}
			
			//----------
			// 入力制御
			//----------
			// 価格入力時
			if (RateBlanketAcs.NullChgDbl(this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.PRICEFL].Value) > 0)
			{
				// 掛率設定項目は入力無効
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.RATEVAL].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.RATEVAL].TabStop = DefaultableBoolean.False;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].TabStop = DefaultableBoolean.False;
			}
			else
			{
				// 掛率設定項目は入力無効解除
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.RATEVAL].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.RATEVAL].TabStop = DefaultableBoolean.True;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].TabStop = DefaultableBoolean.True;
			}

			// 掛率設定時
			if ((RateBlanketAcs.NullChgDbl(this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.RATEVAL].Value) > 0)
				|| (RateBlanketAcs.NullChgDbl(this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value) > 0))
			{
				// 価格入力無効
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.PRICEFL].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.PRICEFL].TabStop = DefaultableBoolean.False;
			}
			else
			{
				// 価格入力無効解除
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.PRICEFL].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.PRICEFL].TabStop = DefaultableBoolean.True;
			}			

			this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.EnterEditMode);

			// アクティブ行の全てのセルにおいて色分けする(入力可/不可にて)
			foreach (UltraGridCell wkCell in this.rateBlanketResult_uGrid.ActiveRow.Cells)
			{
				if ((wkCell.Column.CellActivation == Activation.NoEdit) ||
					(wkCell.Activation == Activation.NoEdit))
				{
					wkCell.Appearance = GetImpossibleCellAppearance();
				}
				else
				{
					wkCell.Appearance = GetPossibleCellAppearance();
				}
			}
		}

		/// <summary>
		/// UltraGrid.BeforeSelectChangeイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: １つ以上の行、セル、または列オブジェクトが選択または選択解除される前に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
		{
			e.Cancel = true;
		}

		/// <summary>
		/// UltraGrid.Leaveイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: アクティブコントロールでなくなった時に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_Leave(object sender, EventArgs e)
		{
			if (this.rateBlanketResult_uGrid.ActiveCell != null)
			{
				// アクティブだった行のセルの外観を解除
				foreach (UltraGridCell wkCell in this.rateBlanketResult_uGrid.ActiveRow.Cells)
				{
					wkCell.Appearance = null;
				}
				// アクティブな行、列のインデックスをバッファに確保
				this._leaveRowBuf = this.rateBlanketResult_uGrid.ActiveRow.Index;
				this._leaveColBuf = this.rateBlanketResult_uGrid.ActiveCell.Column.Index;
				this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.DeactivateCell);
			}
		}

		/// <summary>
		/// UltraGrid.InitializeRowイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 行が初期化された時に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_InitializeRow(object sender, InitializeRowEventArgs e)
		{
		}

		/// <summary>
		/// UltraGrid.InitializeLayoutイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: データソースからコントロールにデータがロードされるときなど、
		///					  表示レイアウトが初期化されるときに発生します。 </br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
		}

		/// <summary>
		/// UltraGrid.AfterExitEditModeイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: セルが編集モードを終了した後に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_AfterExitEditMode(object sender, EventArgs e)
		{
		}

		/// <summary>rateBlanketResult_uGrid_KeyPress</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : グリッド内でキーを押下すると発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_KeyPress(object sender, KeyPressEventArgs e)
		{
			//----- ueno del ---------- start 2008.02.18
			//// 制御キーが押された？
			//if (Char.IsControl(e.KeyChar))
			//{
			//    return;
			//}

			//// 数値と「.」以外はＮＧ
			//if (Char.IsNumber(e.KeyChar) || (e.KeyChar.Equals('.')))
			//{
			//    // 正常
			//}
			//else
			//{
			//    e.Handled = true;
			//}
			//----- ueno del ---------- end 2008.02.18

			//----- ueno add ---------- start 2008.02.18
			UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			if (targetGrid.ActiveCell == null) return;

			int rowIndex = targetGrid.ActiveCell.Row.Index;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = targetGrid.ActiveCell;

			// アクティブセルが「単価」の場合
			if (targetGrid.ActiveCell == targetGrid.Rows[rowIndex].Cells[RateBlanketResult.PRICEFL])
			{
				// 編集モード中？
				if (targetGrid.ActiveCell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(13, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}
			// アクティブセルが「掛率」の場合
			else if (targetGrid.ActiveCell == targetGrid.Rows[rowIndex].Cells[RateBlanketResult.RATEVAL])
			{
				// 編集モード中？
				if (targetGrid.ActiveCell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}
			// アクティブセルが「単価端数処理単位」の場合
			else if (targetGrid.ActiveCell == targetGrid.Rows[rowIndex].Cells[RateBlanketResult.UNPRCFRACPROCUNIT])
			{
				// 編集モード中？
				if (targetGrid.ActiveCell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}
			//----- ueno add ---------- end 2008.02.18
		}

		/// <summary>
		/// UltraGrid.BeforeEnterEditModeイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: グリッド上でエディットモード開始直前での制御を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_BeforeEnterEditMode(object sender, CancelEventArgs e)
		{
			int rowIndex = this.rateBlanketResult_uGrid.ActiveCell.Row.Index;
		}

		/// <summary>
		/// UltraGrid.BeforeExitEditModeイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note        : セルが編集モードを終了する前に発生します。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.10.24</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
		{
			string wkStr = this.rateBlanketResult_uGrid.ActiveCell.Text;
			int rowIndex = this.rateBlanketResult_uGrid.ActiveCell.Row.Index;

			//----- ueno del ---------- start 2008.02.18
			// 不正データのチェックはkeyPressで行う
			////--------------------
			//// 不正データチェック
			////--------------------
			//// アクティブセルが「単価」、「掛率」、「単価端数処理単位」の何れかの場合
			//if ((this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.PRICEFL])
			//    || (this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.RATEVAL])
			//    || (this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.UNPRCFRACPROCUNIT]))
			//{
			//    if (wkStr != "")
			//    {
			//        // ピリオドの個数取得
			//        int cnt = 0;
			//        for (int i = 0; i < wkStr.Length; i++)
			//        {
			//            if (wkStr[i].Equals('.') == true)
			//            {
			//                cnt++;
			//            }
			//        }

			//        if (cnt > 1)
			//        {
			//            // ピリオドが複数回あったとき初期値0を設定
			//            this.rateBlanketResult_uGrid.ActiveCell.Value = 0;
			//        }
			//        else
			//        {
			//            this.rateBlanketResult_uGrid.ActiveCell.Value = RateBlanketAcs.NullChgDbl(wkStr).ToString("#0.00");
			//        }
			//    }
			//    else
			//    {
			//        // nullのときは初期値0を設定
			//        this.rateBlanketResult_uGrid.ActiveCell.Value = 0;
			//    }
			//}
			//----- ueno del ---------- end 2008.02.18
		}

		/// <summary>
		/// uce_ColSizeAutoSetting_CheckedChanged
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uce_ColSizeAutoSetting_CheckedChanged(object sender, EventArgs e)
		{
			if (!this._isEventAutoFillColumn) return;

			this._isEventAutoFillColumn = false;

			try
			{
				if (this.uce_ColSizeAutoSetting.Checked)
				{
					// 列幅をオートに設定
					this.rateBlanketResult_uGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
				}
				else
				{
					this.rateBlanketResult_uGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
					// カラムサイズ調整
					GridInitialSettingWidth();
				}
			}
			finally
			{
				this._isEventAutoFillColumn = true;
			}
		}

		/// <summary>
		/// tce_FontSize_ValueChanged
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tce_FontSize_ValueChanged(object sender, EventArgs e)
		{
			// 文字サイズを変更
			this.rateBlanketResult_uGrid.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.tce_FontSize.Value;
		}

		/// <summary>
		/// utb_InventDataToolBar_ToolClick
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void utb_InventDataToolBar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			this.rateBlanketResult_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
		}

		//----- ueno upd ---------- start 2008.02.18
		/// <summary>
		/// rateBlanketResult_uGrid_CellDataError
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 不正な値が入力された状態でセルを更新しようとすると発生する。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2008.02.18</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_CellDataError(object sender, CellDataErrorEventArgs e)
		{
			UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			if (targetGrid.ActiveCell != null)
			{
				// 数値項目の場合
				if ((targetGrid.ActiveCell.Column.DataType == typeof(Int32)) ||
					(targetGrid.ActiveCell.Column.DataType == typeof(Int64)) ||
					(targetGrid.ActiveCell.Column.DataType == typeof(double)))
				{
					Infragistics.Win.EmbeddableEditorBase editorBase = targetGrid.ActiveCell.EditorResolved;

					// 未入力は0にする
					if (editorBase.CurrentEditText.Trim() == "")
					{
						editorBase.Value = 0;				// 0をセット
						targetGrid.ActiveCell.Value = 0;
					}
					// 数値項目に「-」or「.」だけしか入ってなかったら駄目です
					else if ((editorBase.CurrentEditText.Trim() == "-") ||
						(editorBase.CurrentEditText.Trim() == ".") ||
						(editorBase.CurrentEditText.Trim() == "-."))
					{
						editorBase.Value = 0;				// 0をセット
						targetGrid.ActiveCell.Value = 0;
					}
					// 通常入力
					else
					{
						try
						{
							editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), targetGrid.ActiveCell.Column.DataType);
							targetGrid.ActiveCell.Value = editorBase.Value;
						}
						catch
						{
							editorBase.Value = 0;
							targetGrid.ActiveCell.Value = 0;
						}
					}
					e.RaiseErrorEvent = false;			// エラーイベントは発生させない
					e.RestoreOriginalValue = false;		// セルの値を元に戻さない
					e.StayInEditMode = false;			// 編集モードは抜ける
				}
			}
		}
		//----- ueno upd ---------- end 2008.02.18

		//----- ueno del ---------- start 2008.02.18
		// 不正チェックはCellDataErrorで行っているので不要
		///// <summary>
		///// rateBlanketResult_uGrid_CellChange
		///// </summary>
		///// <param name="sender">対象オブジェクト</param>
		///// <param name="e">イベントパラメータ</param>
		///// <remarks>
		///// <br>Note		: 編集モードにあるセルの値をユーザーが変更したときに発生する。</br>
		///// <br>Programmer	: 30167 上野　弘貴</br>
		///// <br>Date		: 2007.11.08</br>
		///// </remarks>
		//private void rateBlanketResult_uGrid_CellChange(object sender, CellEventArgs e)
		//{
		//    // NetAdvantage 不具合のためのロジック

		//    // アクティブセルが有効
		//    if (this.rateBlanketResult_uGrid.ActiveCell != null)
		//    {
		//        // NetAdvantage 不具合のためのロジック
				
		//        // 現在のセルを取得
		//        UltraGridCell currentCell = this.rateBlanketResult_uGrid.ActiveCell;

		//        // 現在のアクティブセルのスタイルがEditの場合
		//        if ( currentCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit )
		//        {
		//            // 変更された結果、Textが空白となった場合
		//            if( ( currentCell.Text == null ) || ( currentCell.Text.TrimEnd() == "" ) ) 
		//            {
		//                // 現在のセルの型が、Int32、Int64、double型の場合
		//                if ((e.Cell.Column.DataType == typeof(Int32)) ||
		//                    (e.Cell.Column.DataType == typeof(Int64)) ||
		//                    (e.Cell.Column.DataType == typeof(double)))
		//                {
		//                    // 値を空白とはせずに、"0"をセットする←NULLでどうか
		//                    //	e.Cell.Value = 0;
		//                    e.Cell.Value = DBNull.Value;
		//                }
		//            }
		//        }
		//    }
		//}
		//----- ueno del ---------- end 2008.02.18

		#endregion Grid Event

	}
}
