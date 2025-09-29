using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using System.Threading;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{

	/// <summary>
	/// アドレスガイド窓クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011　野口　暢朗</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note: 2008.05.07 鈴木正臣</br>
    /// <br>             ①DC.NS向けNetAdvantageバージョンアップ対応</br>
	/// </remarks>
	internal class AddressGuideWindow : System.Windows.Forms.Form
	{
		#region コンポーネント
		
		private System.ComponentModel.IContainer components = null;
		
		private Broadleaf.Library.Windows.Forms.TEdit teIndex1;
		private Broadleaf.Library.Windows.Forms.TEdit teIndex2;
		private Broadleaf.Library.Windows.Forms.TEdit teIndex3;
		private Broadleaf.Library.Windows.Forms.TEdit teIndex4;
		private Broadleaf.Library.Windows.Forms.TEdit teIndex5;
		
		private Broadleaf.Library.Windows.Forms.TEdit teKeyword;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.Misc.UltraButton ubSearch;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _AddressGuideWindow_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _AddressGuideWindow_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _AddressGuideWindow_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _AddressGuideWindow_Toolbars_Dock_Area_Bottom;
		
		private Infragistics.Win.UltraWinGrid.UltraGrid ugIndex1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ugIndex2;
		private Infragistics.Win.UltraWinGrid.UltraGrid ugIndex3;
		private Infragistics.Win.UltraWinGrid.UltraGrid ugIndex4;
		private Infragistics.Win.UltraWinGrid.UltraGrid ugIndex5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.Splitter splitter4;
		private System.Windows.Forms.ToolTip toolTip1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraButton ubPostNoSearch;
		private Broadleaf.Library.Windows.Forms.TEdit tePostNoKeyword;
        private Infragistics.Win.Misc.UltraLabel ulStatusBar;
        private TComboEditor areaGroupTComboEditor;
        private UltraLabel areaGroupLabel;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		
		#endregion
		
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
			Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("確定(S)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("取り消し(X)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("管区(G)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("別の住所情報(O)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("管区(G)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("確定(S)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("取り消し(X)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("別の住所情報(O)");
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddressGuideWindow));
			this.ubSearch = new Infragistics.Win.Misc.UltraButton();
			this.teIndex1 = new Broadleaf.Library.Windows.Forms.TEdit();
			this.teIndex2 = new Broadleaf.Library.Windows.Forms.TEdit();
			this.teIndex3 = new Broadleaf.Library.Windows.Forms.TEdit();
			this.teIndex4 = new Broadleaf.Library.Windows.Forms.TEdit();
			this.teIndex5 = new Broadleaf.Library.Windows.Forms.TEdit();
			this.teKeyword = new Broadleaf.Library.Windows.Forms.TEdit();
			this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
			this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
			this._AddressGuideWindow_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._AddressGuideWindow_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._AddressGuideWindow_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._AddressGuideWindow_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.ugIndex1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.ugIndex2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.ugIndex3 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.ugIndex4 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.ugIndex5 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.areaGroupLabel = new Infragistics.Win.Misc.UltraLabel();
			this.areaGroupTComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.ubPostNoSearch = new Infragistics.Win.Misc.UltraButton();
			this.tePostNoKeyword = new Broadleaf.Library.Windows.Forms.TEdit();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.splitter4 = new System.Windows.Forms.Splitter();
			this.splitter3 = new System.Windows.Forms.Splitter();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
			this.ulStatusBar = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.teIndex1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.teIndex2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.teIndex3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.teIndex4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.teIndex5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.teKeyword)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ugIndex1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ugIndex2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ugIndex3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ugIndex4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ugIndex5)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.areaGroupTComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tePostNoKeyword)).BeginInit();
			this.panel7.SuspendLayout();
			this.SuspendLayout();
			// 
			// ubSearch
			// 
			this.ubSearch.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.ubSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.ubSearch.Location = new System.Drawing.Point(590, 10);
			this.ubSearch.Name = "ubSearch";
			this.ubSearch.Size = new System.Drawing.Size(92, 25);
			this.ubSearch.TabIndex = 3;
			this.ubSearch.Text = "検索(&F)";
			this.toolTip1.SetToolTip(this.ubSearch, "カナ、名称で曖昧検索できます。");
			this.ubSearch.Click += new System.EventHandler(this.ultraButton1_Click);
			this.ubSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			// 
			// teIndex1
			// 
			this.teIndex1.ActiveAppearance = appearance1;
			this.teIndex1.AutoSelect = true;
			this.teIndex1.AutoSize = false;
			this.teIndex1.DataText = "";
			this.teIndex1.Dock = System.Windows.Forms.DockStyle.Top;
			this.teIndex1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.teIndex1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.teIndex1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.teIndex1.Location = new System.Drawing.Point(0, 0);
			this.teIndex1.MaxLength = 12;
			this.teIndex1.Name = "teIndex1";
			this.teIndex1.Size = new System.Drawing.Size(167, 24);
			this.teIndex1.TabIndex = 0;
			this.teIndex1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			// 
			// teIndex2
			// 
			this.teIndex2.ActiveAppearance = appearance2;
			this.teIndex2.AutoSelect = true;
			this.teIndex2.AutoSize = false;
			this.teIndex2.DataText = "";
			this.teIndex2.Dock = System.Windows.Forms.DockStyle.Top;
			this.teIndex2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.teIndex2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.teIndex2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.teIndex2.Location = new System.Drawing.Point(0, 0);
			this.teIndex2.MaxLength = 12;
			this.teIndex2.Name = "teIndex2";
			this.teIndex2.Size = new System.Drawing.Size(190, 24);
			this.teIndex2.TabIndex = 0;
			this.teIndex2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			// 
			// teIndex3
			// 
			this.teIndex3.ActiveAppearance = appearance3;
			this.teIndex3.AutoSelect = true;
			this.teIndex3.AutoSize = false;
			this.teIndex3.DataText = "";
			this.teIndex3.Dock = System.Windows.Forms.DockStyle.Top;
			this.teIndex3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.teIndex3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.teIndex3.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.teIndex3.Location = new System.Drawing.Point(0, 0);
			this.teIndex3.MaxLength = 12;
			this.teIndex3.Name = "teIndex3";
			this.teIndex3.Size = new System.Drawing.Size(193, 24);
			this.teIndex3.TabIndex = 0;
			this.teIndex3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			// 
			// teIndex4
			// 
			this.teIndex4.ActiveAppearance = appearance4;
			this.teIndex4.AutoSelect = true;
			this.teIndex4.AutoSize = false;
			this.teIndex4.DataText = "";
			this.teIndex4.Dock = System.Windows.Forms.DockStyle.Top;
			this.teIndex4.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.teIndex4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.teIndex4.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.teIndex4.Location = new System.Drawing.Point(0, 0);
			this.teIndex4.MaxLength = 12;
			this.teIndex4.Name = "teIndex4";
			this.teIndex4.Size = new System.Drawing.Size(200, 24);
			this.teIndex4.TabIndex = 0;
			this.teIndex4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			// 
			// teIndex5
			// 
			this.teIndex5.ActiveAppearance = appearance5;
			this.teIndex5.AutoSelect = true;
			this.teIndex5.AutoSize = false;
			this.teIndex5.DataText = "";
			this.teIndex5.Dock = System.Windows.Forms.DockStyle.Top;
			this.teIndex5.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.teIndex5.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.teIndex5.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.teIndex5.Location = new System.Drawing.Point(0, 0);
			this.teIndex5.MaxLength = 12;
			this.teIndex5.Name = "teIndex5";
			this.teIndex5.Size = new System.Drawing.Size(230, 24);
			this.teIndex5.TabIndex = 0;
			this.teIndex5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			// 
			// teKeyword
			// 
			this.teKeyword.ActiveAppearance = appearance6;
			this.teKeyword.AutoSelect = true;
			this.teKeyword.DataText = "";
			this.teKeyword.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.teKeyword.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 75, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.teKeyword.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.teKeyword.Location = new System.Drawing.Point(254, 11);
			this.teKeyword.MaxLength = 75;
			this.teKeyword.Name = "teKeyword";
			this.teKeyword.Size = new System.Drawing.Size(206, 24);
			this.teKeyword.TabIndex = 1;
			this.toolTip1.SetToolTip(this.teKeyword, "カナ、名称で曖昧検索できます。");
			this.teKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			// 
			// tRetKeyControl1
			// 
			this.tRetKeyControl1.OwnerForm = this;
			this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
			this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
			// 
			// ultraToolbarsManager1
			// 
			this.ultraToolbarsManager1.DesignerFlags = 1;
			this.ultraToolbarsManager1.DockWithinContainer = this;
			this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
			ultraToolbar1.DockedColumn = 0;
			ultraToolbar1.DockedRow = 0;
			ultraToolbar1.IsMainMenuBar = true;
			ultraToolbar1.Text = "UltraToolbar1";
			ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4});
			this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
			buttonTool5.SharedProps.Caption = "管区(&G)";
			buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool6.SharedProps.Caption = "確定(&S)";
			buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool7.SharedProps.Caption = "戻る(&C)";
			buttonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool8.SharedProps.Caption = "別の住所情報(&O)";
			buttonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8});
			this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
			// 
			// _AddressGuideWindow_Toolbars_Dock_Area_Left
			// 
			this._AddressGuideWindow_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._AddressGuideWindow_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._AddressGuideWindow_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
			this._AddressGuideWindow_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
			this._AddressGuideWindow_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 25);
			this._AddressGuideWindow_Toolbars_Dock_Area_Left.Name = "_AddressGuideWindow_Toolbars_Dock_Area_Left";
			this._AddressGuideWindow_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 384);
			this._AddressGuideWindow_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _AddressGuideWindow_Toolbars_Dock_Area_Right
			// 
			this._AddressGuideWindow_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._AddressGuideWindow_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._AddressGuideWindow_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
			this._AddressGuideWindow_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
			this._AddressGuideWindow_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(992, 25);
			this._AddressGuideWindow_Toolbars_Dock_Area_Right.Name = "_AddressGuideWindow_Toolbars_Dock_Area_Right";
			this._AddressGuideWindow_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 384);
			this._AddressGuideWindow_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _AddressGuideWindow_Toolbars_Dock_Area_Top
			// 
			this._AddressGuideWindow_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._AddressGuideWindow_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._AddressGuideWindow_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
			this._AddressGuideWindow_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
			this._AddressGuideWindow_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
			this._AddressGuideWindow_Toolbars_Dock_Area_Top.Name = "_AddressGuideWindow_Toolbars_Dock_Area_Top";
			this._AddressGuideWindow_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(992, 25);
			this._AddressGuideWindow_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _AddressGuideWindow_Toolbars_Dock_Area_Bottom
			// 
			this._AddressGuideWindow_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._AddressGuideWindow_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._AddressGuideWindow_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
			this._AddressGuideWindow_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this._AddressGuideWindow_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 409);
			this._AddressGuideWindow_Toolbars_Dock_Area_Bottom.Name = "_AddressGuideWindow_Toolbars_Dock_Area_Bottom";
			this._AddressGuideWindow_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(992, 0);
			this._AddressGuideWindow_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// ugIndex1
			// 
			this.ugIndex1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ugIndex1.Location = new System.Drawing.Point(0, 24);
			this.ugIndex1.Name = "ugIndex1";
			this.ugIndex1.Size = new System.Drawing.Size(167, 290);
			this.ugIndex1.TabIndex = 1;
			this.ugIndex1.DoubleClick += new System.EventHandler(this.ugIndex1_DoubleClick);
			this.ugIndex1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			this.ugIndex1.AfterRowActivate += new System.EventHandler(this.ugIndex1_AfterRowActivate);
			// 
			// ugIndex2
			// 
			this.ugIndex2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ugIndex2.Location = new System.Drawing.Point(0, 24);
			this.ugIndex2.Name = "ugIndex2";
			this.ugIndex2.Size = new System.Drawing.Size(190, 290);
			this.ugIndex2.TabIndex = 1;
			this.ugIndex2.DoubleClick += new System.EventHandler(this.ugIndex1_DoubleClick);
			this.ugIndex2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			this.ugIndex2.AfterRowActivate += new System.EventHandler(this.ugIndex2_AfterRowActivate);
			// 
			// ugIndex3
			// 
			this.ugIndex3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ugIndex3.Location = new System.Drawing.Point(0, 24);
			this.ugIndex3.Name = "ugIndex3";
			this.ugIndex3.Size = new System.Drawing.Size(193, 290);
			this.ugIndex3.TabIndex = 1;
			this.ugIndex3.DoubleClick += new System.EventHandler(this.ugIndex1_DoubleClick);
			this.ugIndex3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			this.ugIndex3.AfterRowActivate += new System.EventHandler(this.ugIndex3_AfterRowActivate);
			// 
			// ugIndex4
			// 
			this.ugIndex4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ugIndex4.Location = new System.Drawing.Point(0, 24);
			this.ugIndex4.Name = "ugIndex4";
			this.ugIndex4.Size = new System.Drawing.Size(200, 290);
			this.ugIndex4.TabIndex = 1;
			this.ugIndex4.DoubleClick += new System.EventHandler(this.ugIndex1_DoubleClick);
			this.ugIndex4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			this.ugIndex4.AfterRowActivate += new System.EventHandler(this.ugIndex4_AfterRowActivate);
			// 
			// ugIndex5
			// 
			this.ugIndex5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ugIndex5.Location = new System.Drawing.Point(0, 24);
			this.ugIndex5.Name = "ugIndex5";
			this.ugIndex5.Size = new System.Drawing.Size(230, 290);
			this.ugIndex5.TabIndex = 1;
			this.ugIndex5.DoubleClick += new System.EventHandler(this.ugIndex1_DoubleClick);
			this.ugIndex5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			this.ugIndex5.AfterRowActivate += new System.EventHandler(this.ugIndex5_AfterRowActivate);
			// 
			// ultraLabel1
			// 
			appearance11.BackColor = System.Drawing.Color.Black;
			appearance11.BackColor2 = System.Drawing.Color.Black;
			appearance11.BorderColor = System.Drawing.Color.Blue;
			appearance11.BorderColor3DBase = System.Drawing.Color.Blue;
			appearance11.ForeColor = System.Drawing.Color.Lime;
			appearance11.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance11.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ultraLabel1.Appearance = appearance11;
			this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
			this.ultraLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
			this.ultraLabel1.Location = new System.Drawing.Point(143, 10);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(108, 25);
			this.ultraLabel1.TabIndex = 0;
			this.ultraLabel1.Text = "住所名称検索";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ugIndex1);
			this.panel1.Controls.Add(this.teIndex1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(167, 314);
			this.panel1.TabIndex = 40;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.ugIndex2);
			this.panel2.Controls.Add(this.teIndex2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(170, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(190, 314);
			this.panel2.TabIndex = 41;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.ugIndex3);
			this.panel3.Controls.Add(this.teIndex3);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new System.Drawing.Point(363, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(193, 314);
			this.panel3.TabIndex = 42;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.ugIndex4);
			this.panel4.Controls.Add(this.teIndex4);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel4.Location = new System.Drawing.Point(559, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(200, 314);
			this.panel4.TabIndex = 43;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.ugIndex5);
			this.panel5.Controls.Add(this.teIndex5);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(762, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(230, 314);
			this.panel5.TabIndex = 44;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.areaGroupLabel);
			this.panel6.Controls.Add(this.areaGroupTComboEditor);
			this.panel6.Controls.Add(this.ubPostNoSearch);
			this.panel6.Controls.Add(this.tePostNoKeyword);
			this.panel6.Controls.Add(this.ultraLabel2);
			this.panel6.Controls.Add(this.ubSearch);
			this.panel6.Controls.Add(this.teKeyword);
			this.panel6.Controls.Add(this.ultraLabel1);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(0, 25);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(992, 47);
			this.panel6.TabIndex = 0;
			// 
			// areaGroupLabel
			// 
			appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
			appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
			appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance7.BorderColor = System.Drawing.Color.White;
			appearance7.BorderColor3DBase = System.Drawing.Color.AliceBlue;
			appearance7.ForeColor = System.Drawing.Color.White;
			appearance7.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance7.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.areaGroupLabel.Appearance = appearance7;
			this.areaGroupLabel.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
			this.areaGroupLabel.Location = new System.Drawing.Point(13, 10);
			this.areaGroupLabel.Name = "areaGroupLabel";
			this.areaGroupLabel.Size = new System.Drawing.Size(115, 28);
			this.areaGroupLabel.TabIndex = 7;
			// 
			// areaGroupTComboEditor
			// 
			this.areaGroupTComboEditor.ActiveAppearance = appearance8;
			this.areaGroupTComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.areaGroupTComboEditor.Location = new System.Drawing.Point(467, 11);
			this.areaGroupTComboEditor.Name = "areaGroupTComboEditor";
			this.areaGroupTComboEditor.Size = new System.Drawing.Size(120, 24);
			this.areaGroupTComboEditor.TabIndex = 2;
			// 
			// ubPostNoSearch
			// 
			this.ubPostNoSearch.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.ubPostNoSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.ubPostNoSearch.Location = new System.Drawing.Point(887, 10);
			this.ubPostNoSearch.Name = "ubPostNoSearch";
			this.ubPostNoSearch.Size = new System.Drawing.Size(92, 25);
			this.ubPostNoSearch.TabIndex = 6;
			this.ubPostNoSearch.Text = "検索(&Y)";
			this.toolTip1.SetToolTip(this.ubPostNoSearch, "郵便番号で検索します");
			this.ubPostNoSearch.Click += new System.EventHandler(this.ubPostNoSearch_Click);
			this.ubPostNoSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			// 
			// tePostNoKeyword
			// 
			this.tePostNoKeyword.ActiveAppearance = appearance9;
			this.tePostNoKeyword.AutoSelect = true;
			this.tePostNoKeyword.DataText = "";
			this.tePostNoKeyword.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.tePostNoKeyword.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
			this.tePostNoKeyword.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tePostNoKeyword.Location = new System.Drawing.Point(810, 11);
			this.tePostNoKeyword.MaxLength = 8;
			this.tePostNoKeyword.Name = "tePostNoKeyword";
			this.tePostNoKeyword.Size = new System.Drawing.Size(76, 24);
			this.tePostNoKeyword.TabIndex = 5;
			this.tePostNoKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			// 
			// ultraLabel2
			// 
			appearance10.BackColor = System.Drawing.Color.Black;
			appearance10.BackColor2 = System.Drawing.Color.Black;
			appearance10.BorderColor = System.Drawing.Color.Blue;
			appearance10.BorderColor3DBase = System.Drawing.Color.Blue;
			appearance10.ForeColor = System.Drawing.Color.Lime;
			appearance10.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance10.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ultraLabel2.Appearance = appearance10;
			this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
			this.ultraLabel2.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
			this.ultraLabel2.Location = new System.Drawing.Point(702, 10);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.Size = new System.Drawing.Size(106, 25);
			this.ultraLabel2.TabIndex = 4;
			this.ultraLabel2.Text = "郵便番号検索";
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.panel5);
			this.panel7.Controls.Add(this.splitter4);
			this.panel7.Controls.Add(this.panel4);
			this.panel7.Controls.Add(this.splitter3);
			this.panel7.Controls.Add(this.panel3);
			this.panel7.Controls.Add(this.splitter2);
			this.panel7.Controls.Add(this.panel2);
			this.panel7.Controls.Add(this.splitter1);
			this.panel7.Controls.Add(this.panel1);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new System.Drawing.Point(0, 72);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(992, 314);
			this.panel7.TabIndex = 46;
			// 
			// splitter4
			// 
			this.splitter4.Location = new System.Drawing.Point(759, 0);
			this.splitter4.Name = "splitter4";
			this.splitter4.Size = new System.Drawing.Size(3, 314);
			this.splitter4.TabIndex = 48;
			this.splitter4.TabStop = false;
			// 
			// splitter3
			// 
			this.splitter3.Location = new System.Drawing.Point(556, 0);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new System.Drawing.Size(3, 314);
			this.splitter3.TabIndex = 47;
			this.splitter3.TabStop = false;
			// 
			// splitter2
			// 
			this.splitter2.Location = new System.Drawing.Point(360, 0);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(3, 314);
			this.splitter2.TabIndex = 46;
			this.splitter2.TabStop = false;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(167, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 314);
			this.splitter1.TabIndex = 45;
			this.splitter1.TabStop = false;
			// 
			// tArrowKeyControl1
			// 
			this.tArrowKeyControl1.OwnerForm = this;
			// 
			// ulStatusBar
			// 
			appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(227)))), ((int)(((byte)(247)))));
			appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(174)))), ((int)(((byte)(231)))));
			appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance12.ForeColor = System.Drawing.Color.Red;
			this.ulStatusBar.Appearance = appearance12;
			this.ulStatusBar.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.ulStatusBar.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
			this.ulStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ulStatusBar.Location = new System.Drawing.Point(0, 386);
			this.ulStatusBar.Name = "ulStatusBar";
			this.ulStatusBar.Size = new System.Drawing.Size(992, 23);
			this.ulStatusBar.TabIndex = 51;
			// 
			// AddressGuideWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(992, 409);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.ulStatusBar);
			this.Controls.Add(this._AddressGuideWindow_Toolbars_Dock_Area_Left);
			this.Controls.Add(this._AddressGuideWindow_Toolbars_Dock_Area_Right);
			this.Controls.Add(this._AddressGuideWindow_Toolbars_Dock_Area_Top);
			this.Controls.Add(this._AddressGuideWindow_Toolbars_Dock_Area_Bottom);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddressGuideWindow";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "住所ガイド";
			this.Shown += new System.EventHandler(this.AddressGuideWindow_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressGuideWindow_KeyDown);
			this.Load += new System.EventHandler(this.AddressGuideWindow_Load);
			((System.ComponentModel.ISupportInitialize)(this.teIndex1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.teIndex2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.teIndex3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.teIndex4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.teIndex5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.teKeyword)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ugIndex1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ugIndex2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ugIndex3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ugIndex4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ugIndex5)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.areaGroupTComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tePostNoKeyword)).EndInit();
			this.panel7.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		#region UIの外観設定メソッド

		/// <summary>
		/// UltraGridの配色を仕様通りに設定する
		/// </summary>
		/// <param name="ugTarget"></param>
		private void setGridAppearance( Infragistics.Win.UltraWinGrid.UltraGrid ugTarget )
		{
			//タイトルの外観
			ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
			ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			ugTarget.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			ugTarget.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			ugTarget.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;

			//背景色を設定
			ugTarget.DisplayLayout.Appearance.BackColor = Color.White;
			
			//文字をカラムに入るように設定する
			//ugTarget.DisplayLayout.AutoFitColumns = true;
            ugTarget.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

			// 選択行の外観を設定
			ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
			ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
			ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			//行セレクタの設定
			ugTarget.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.White;

			ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			
			//行のサイズ変更不可
			ugTarget.DisplayLayout.Override.RowSizing = RowSizing.Fixed;
			
			//インジゲータ非表示
			ugTarget.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			
			//分割領域非表示
			ugTarget.DisplayLayout.MaxColScrollRegions = 1;
			ugTarget.DisplayLayout.MaxRowScrollRegions = 1;
						
			//交互に行の色を変える
			ugTarget.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
			
			//グリッドの背景色を変える
			ugTarget.DisplayLayout.Appearance.BackColor = Color.Gray;
			
			//垂直スクロールバーのみ許可
			ugTarget.DisplayLayout.Scrollbars = Scrollbars.Automatic;
			
			//アクティブ行のフォントの色を変える
			ugTarget.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
			
			//アクティブ行のフォントを太字にする
			ugTarget.DisplayLayout.Override.ActiveRowAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			
		}
		
		/// <summary>
		/// UltraGridの挙動を設定する
		/// </summary>
		/// <param name="ugTarget"></param>
		private void setGridBehavior( Infragistics.Win.UltraWinGrid.UltraGrid ugTarget )
		{
			//列幅の自動調整不可
			//ugTarget.DisplayLayout.AutoFitColumns = false;
            ugTarget.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

			//行の追加不可
			ugTarget.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			
			//行の削除不可
			ugTarget.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			
			// 列の移動不可
			ugTarget.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
			
			// 列の交換不可
			ugTarget.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
			
			// フィルタの使用不可
			ugTarget.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
			
			// ユーザーのデータ書き換え許可
			ugTarget.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
			
			//選択方法を行選択に設定。
			ugTarget.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			
			//ヘッダをクリックしたときは列選択状態にする。
			ugTarget.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
			//+列選択不可にすることでヘッダをクリックしても何も起こらない
			ugTarget.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;

			//一行のみ選択可能にする
			ugTarget.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
			
			//スクロール中にもいまどこが見えている状態なのかがわかるようにする
			ugTarget.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

            ugTarget.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;

			//IME無効
			ugTarget.ImeMode = ImeMode.Disable;			
		}
		
		void setTEditAppearance( TEdit teTarget )
		{
			//選択されたときの背景色を変える
			teTarget.ActiveAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
			teTarget.ActiveAppearance.BackColor2 = Color.FromArgb( 247, 227, 156 );
		}
		
		void setTComboEditorAppearance( TComboEditor tceTarget )
		{
			//選択されたときの背景色を変える
			tceTarget.ActiveAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
			tceTarget.ActiveAppearance.BackColor2 = Color.FromArgb( 247, 227, 156 );
		}

		private void setToolbarAppearance()
		{
			//ツールバーにアイコン設定
			//using Broadleaf.Library.Resources;
			//SFCMN00008C
			ImageList imList = IconResourceManagement.ImageList16;
			this.ultraToolbarsManager1.ImageListSmall = imList;

			this.ultraToolbarsManager1.Toolbars[0].Tools[0].InstanceProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			this.ultraToolbarsManager1.Toolbars[0].Tools[1].InstanceProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;

			//ツールバーをカスタマイズ不可にする
			this.ultraToolbarsManager1.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
		}
		
		//数値の列を設定する
		private void setNumberColumnAppearance( UltraGrid ug, string strColumn, string strFormat )
		{
			ug.DisplayLayout.Bands[0].Columns[strColumn].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			ug.DisplayLayout.Bands[0].Columns[strColumn].Format = strFormat;
		}
		
		#endregion
		
		/// <summary>
		/// マージした住所アクセスクラス
		/// </summary>
		private MergedAddressAcs addressAcs = null;
		
		private DataTable dtIndex1 = null;
		private DataTable dtIndex2 = null;
		private DataTable dtIndex3 = null;
		private DataTable dtIndex4 = null;
		private DataTable dtIndex5 = null;
		
		private int AreaGroupCodeSelected = 0;
		private int AddrConnectCd1Def = 0;
		private int AddrConnectCd2Def = 0;
		private int AddrConnectCd3Def = 0;
		private int AddrConnectCd4Def = 0;
		private int AddrConnectCd5Def = 0;
		
        //private bool AddressIndex1Init = false;
		private bool AddressIndex2Init = false;
		private bool AddressIndex3Init = false;
		private bool AddressIndex4Init = false;
		private bool AddressIndex5Init = false;

		/// <summary>
		/// 住所ガイドのコンストラクタ
		/// </summary>
		/// <param name="addrConnectCd1Def">デフォルトの住所連結コード１（地区コード）</param>
		/// <param name="addrConnectCd2Def">デフォルトの住所連結コード２</param>
		/// <param name="addrConnectCd3Def">デフォルトの住所連結コード３</param>
		/// <param name="addrConnectCd4Def">デフォルトの住所連結コード４</param>
		/// <param name="addrConnectCd5Def">デフォルトの住所連結コード５</param>
		public AddressGuideWindow( int addrConnectCd1Def, int addrConnectCd2Def, int addrConnectCd3Def, int addrConnectCd4Def, int addrConnectCd5Def )
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();
			
			//オフラインモードのときはキーワード検索はできない
			if( !LoginInfoAcquisition.OnlineFlag )
			{
				this.teKeyword.Enabled = false;
				this.ubSearch.Enabled = false;
				
				this.tePostNoKeyword.Enabled = false;
				this.ubPostNoSearch.Enabled = false;
                this.areaGroupTComboEditor.Enabled = false;
			}
			
			//検索ボタン
			this.ubSearch.Appearance.Image = IconResourceManagement.ImageList16.Images[ (int)Size16_Index.SEARCH ];
			this.ubPostNoSearch.Appearance.Image = IconResourceManagement.ImageList16.Images[ (int)Size16_Index.SEARCH ];
			
			this.setToolbarAppearance();
			
			//管区のボタンを設定
			this.ultraToolbarsManager1.Toolbars[0].Tools[2].InstanceProps.AppearancesSmall.Appearance.Image = IconResourceManagement.ImageList16.Images[ (int)Size16_Index.FOLDER ];
			
			//別の住所情報のボタンを設定
			this.ultraToolbarsManager1.Toolbars[0].Tools[3].InstanceProps.AppearancesSmall.Appearance.Image = IconResourceManagement.ImageList16.Images[ (int)Size16_Index.RETRY ];

			//テキストボックスとUltraGridを関連付ける
			this.ugIndex1.Tag = this.teIndex1;
			this.ugIndex2.Tag = this.teIndex2;
			this.ugIndex3.Tag = this.teIndex3;
			this.ugIndex4.Tag = this.teIndex4;
			this.ugIndex5.Tag = this.teIndex5;
			
			this.teIndex1.Tag = this.ugIndex1;
			this.teIndex2.Tag = this.ugIndex2;
			this.teIndex3.Tag = this.ugIndex3;
			this.teIndex4.Tag = this.ugIndex4;
			this.teIndex5.Tag = this.ugIndex5;
			
			//マージしたアクセスクラスをロードする
			this.addressAcs = new MergedAddressAcs();
			
			this.AddrConnectCd1Def = addrConnectCd1Def;
			this.AddrConnectCd2Def = addrConnectCd2Def;
			this.AddrConnectCd3Def = addrConnectCd3Def;
			this.AddrConnectCd4Def = addrConnectCd4Def;
			this.AddrConnectCd5Def = addrConnectCd5Def;
			
			//住所連結コード１から指定初期表示管区を取得
			this.AreaGroupCodeSelected = AddressInfoAreaGroupCacheAcs.GetAreaGroupCodeFromAreaCode( addrConnectCd1Def );
			
			//不正な初期表示位置だった場合
			if( this.AddrConnectCd1Def == 0 
				|| this.AreaGroupCodeSelected == 0 )
			{
				List<AreaGroup> alAreaGroup;
				
				AddressInfoAreaGroupCacheAcs.GetAreaGroup( out alAreaGroup );
				
				//管区が取得できた場合
				if( alAreaGroup != null 
					&& alAreaGroup.Count > 0 )
				{
					AreaGroup agTop = alAreaGroup[0];
					if( agTop != null )
					{
						//管区コード取得
						this.AreaGroupCodeSelected = agTop.AreaGroupCode;
						
						List<AreaGroup> alAreaGroupPref = null;
						
						AddressInfoAreaGroupCacheAcs.GetAreaGroupPref( agTop.AreaGroupCode, out alAreaGroupPref );
						
						//管区の県取得
						if( alAreaGroupPref != null
							&& alAreaGroupPref.Count > 0 )
						{
							AreaGroup agpTop = alAreaGroupPref[0];
							this.AddrConnectCd1Def = agpTop.AreaCode;
                            //this.AddressIndex1Init = false;
							this.AddressIndex2Init = true;
							this.AddressIndex3Init = true;
							this.AddressIndex4Init = true;
							this.AddressIndex5Init = true;
						}
						
					}
				}
				
			}
			
			//---------------Grid初期化---------------
			
			dtIndex1 = new DataTable();
			dtIndex2 = new DataTable();
			dtIndex3 = new DataTable();
			dtIndex4 = new DataTable();
			dtIndex5 = new DataTable();
			
			dtIndex1.Columns.Add( "地区名称", typeof( string ) );
			dtIndex1.Columns.Add( "データ", typeof( AreaGroup ) );
			dtIndex1.Columns.Add( "連結コード", typeof( int ) );
			
			dtIndex2.Columns.Add( "地区名称", typeof( string ) );
			dtIndex2.Columns.Add( "データ", typeof( AddressData ) );
			dtIndex2.Columns.Add( "連結コード", typeof( int ) );
			
			dtIndex3.Columns.Add( "地区名称", typeof( string ) );
			dtIndex3.Columns.Add( "データ", typeof( AddressData ) );
			dtIndex3.Columns.Add( "連結コード", typeof( int ) );
			
			dtIndex4.Columns.Add( "地区名称", typeof( string ) );
			dtIndex4.Columns.Add( "データ", typeof( AddressData ) );
			dtIndex4.Columns.Add( "連結コード", typeof( int ) );
			
			dtIndex5.Columns.Add( "地区名称", typeof( string ) );
			dtIndex5.Columns.Add( "データ", typeof( AddressData ) );
			dtIndex5.Columns.Add( "連結コード", typeof( int ) );
			
			ugIndex1.DataSource = dtIndex1;
			ugIndex2.DataSource = dtIndex2;
			ugIndex3.DataSource = dtIndex3;
			ugIndex4.DataSource = dtIndex4;
			ugIndex5.DataSource = dtIndex5;
			
			ugIndex1.DataBind();
			ugIndex2.DataBind();
			ugIndex3.DataBind();
			ugIndex4.DataBind();
			ugIndex5.DataBind();
			
			this.setGridAppearance( ugIndex1 );
			this.setGridAppearance( ugIndex2 );
			this.setGridAppearance( ugIndex3 );
			this.setGridAppearance( ugIndex4 );
			this.setGridAppearance( ugIndex5 );
			
			this.setGridBehavior( ugIndex1 );
			this.setGridBehavior( ugIndex2 );
			this.setGridBehavior( ugIndex3 );
			this.setGridBehavior( ugIndex4 );
			this.setGridBehavior( ugIndex5 );
			
			this.setTEditAppearance( this.teIndex1 );
			this.setTEditAppearance( this.teIndex2 );
			this.setTEditAppearance( this.teIndex3 );
			this.setTEditAppearance( this.teIndex4 );
			this.setTEditAppearance( this.teIndex5 );
			this.setTEditAppearance( this.teKeyword );
			this.setTEditAppearance( this.tePostNoKeyword );

            this.setTComboEditorAppearance(this.areaGroupTComboEditor);
			
            //グリッドの表示設定
            this.SetGridVisual(this.ugIndex1);
            this.SetGridVisual(this.ugIndex2);
            this.SetGridVisual(this.ugIndex3);
            this.SetGridVisual(this.ugIndex4);
            this.SetGridVisual(this.ugIndex5);

			//最初は住所マスタモードだから住所マスタのUIの設定を行う
			this.SetOfferAddressInfoAcsModeUI();

            #region 管区コンボのデータ設定

            //キーワード検索絞り用管区を設定
            List<AreaGroup> areaGroupList = null;
            AddressInfoAreaGroupCacheAcs.GetAreaGroup(out areaGroupList);

            //頭に全国を入れておく
            this.areaGroupTComboEditor.Items.Add(0, "全国");

            for (int i = 0; i < areaGroupList.Count; i++)
            {
                this.areaGroupTComboEditor.Items.Add(areaGroupList[i].AreaGroupCode, areaGroupList[i].AreaName);
            }

            //先頭の全国を選択
            if (this.areaGroupTComboEditor.Items.Count > 0)
            {
                this.areaGroupTComboEditor.SelectedIndex = 0;
            }

            //表示管区を選択
            for (int i = 0; i < this.areaGroupTComboEditor.Items.Count; i++)
            {
                if ((int)this.areaGroupTComboEditor.Items[i].DataValue == this.AreaGroupCodeSelected)
                {
                    this.areaGroupTComboEditor.SelectedIndex = i;
                }
            }

            #endregion


            //管区ラベルに管区名称を設定
            this.areaGroupLabel.Text = this.areaGroupTComboEditor.SelectedItem.DisplayText;
        }
		
		#region UIのモード設定関連のメソッド
		
		/// <summary>
		/// 住所マスタ用UIの設定メソッド
		/// </summary>
		private void SetOfferAddressInfoAcsModeUI()
		{
			this.panel4.Visible = true;
			this.panel5.Visible = true;
			
			//パネルの幅変更メソッド
			this.panel1.Width = 145;
			this.panel2.Width = 146;
			this.panel3.Width = 165;
			this.panel4.Width = 200;
			
			//Dockのスタイルを設定する
			this.panel1.Dock = DockStyle.Left;
			this.panel2.Dock = DockStyle.Left;
			this.panel3.Dock = DockStyle.Left;
			this.panel4.Dock = DockStyle.Left;
			this.panel5.Dock = DockStyle.Fill;
				
			this.splitter3.Visible = true;
			this.splitter4.Visible = true;
				
			this.ulStatusBar.Height = 23 * 2 - 1;

			//ステータスバーに文字列を設定する
			this.SetStatusBarText( this.addressAcs.StatusBarString );
		}
		
		/// <summary>
		/// 郵便番号マスタ用のUIの設定メソッド
		/// </summary>
		private void SetPostNumberAcsModeUI()
		{
			this.panel4.Visible = false;
			this.panel5.Visible = false;
				
			this.panel1.Width = 145;
			this.panel2.Width = 300;
				
			//Dockのスタイルを設定する
			this.panel1.Dock = DockStyle.Left;
			this.panel2.Dock = DockStyle.Left;
			this.panel3.Dock = DockStyle.Fill;
			
			this.splitter3.Visible = false;
			this.splitter4.Visible = false;
			
			this.ulStatusBar.Height = 23;
			
			//ステータスバーに文字列を設定する
			this.SetStatusBarText( this.addressAcs.StatusBarString );
			
		}

		/// <summary>
		/// アクセスクラスを切り替える
		/// </summary>
		private void ChangeOtherAcs()
		{
			//アクセスクラスを違うのにする
			this.addressAcs.SetNextAcs();
			
			if( this.addressAcs.DisplayGridCount == 3 )
			{
				this.SetPostNumberAcsModeUI();
			}
			else if( this.addressAcs.DisplayGridCount == 5 )
			{
				this.SetOfferAddressInfoAcsModeUI();
			}
			
			//データのリロードをする
			if( this.ugIndex1.ActiveRow != null )
			{
				int index = this.ugIndex1.ActiveRow.Index;

				this.ugIndex1.ActiveRow = null;
				
				this.ugIndex1.Rows[index].Activate();
			}
			
		}
		
		#endregion
		
		/// <summary>
		/// 住所名称の検索ボタンが押されたときの処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			//キーワード検索ダイアログ作成
			KeyWordSearchWindow kwsw = new KeyWordSearchWindow( this.addressAcs, this.teKeyword.Text, (int)this.areaGroupTComboEditor.Value);

            try
            {
                this.ulStatusBar.Focus();

                //確定以外が押されたときの処理
                if (kwsw.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            finally
            {
                this.teKeyword.Focus();
            }

			AddressData awSelected = null;
			
			//確定押されたが選択されていない場合
			if( ( awSelected = kwsw.GetResult() ) == null )
			{
				return;
			}
			
			this.addressWorkResult = awSelected;
			
			//この窓の確定ボタンを押したことにする。
			this.PerformOkClick();
		}
		
		/// <summary>
		/// 郵便番号検索ボタンが押されたときの処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ubPostNoSearch_Click(object sender, System.EventArgs e)
		{
			PostCodeSearchWindow pcsw = new PostCodeSearchWindow( this.tePostNoKeyword.Text, this.addressAcs );

            try
            {
                this.ulStatusBar.Focus();

                if (pcsw.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            finally
            {
                this.teKeyword.Focus();
            }

			AddressData awSelected = null;

			if( ( awSelected = pcsw.GetResult() ) == null )
			{
				return;
			}
			
			this.addressWorkResult = awSelected;
			
			//この窓の確定ボタンを押したことにする
			this.PerformOkClick();
		}
		
		#region グリッドの選択アイテム処理系関数
		
		/// <summary>
		/// グリッドの選択されているアイテムを取得する
		/// </summary>
		/// <param name="ugIndex"></param>
		/// <param name="awSelected"></param>
		/// <returns></returns>
		private bool GetSelectedUltraGridItem( UltraGrid ugIndex, out AddressData awSelected )
		{
			//選択されている行がなければ
			if( ugIndex.Selected.Rows.Count <= 0 )
			{
				awSelected = null;
				return false;
			}
			
			awSelected = (AddressData)( (AddressData)ugIndex.Selected.Rows[0].Cells["地区名称"].OriginalValue ).Clone();
			return true;
		}
		
		/// <summary>
		/// 指定UltraGridの指定行を選択する
		/// </summary>
		/// <param name="ugIndex"></param>
		/// <param name="dwRow"></param>
		/// <param name="awSelected"></param>
		/// <returns></returns>
		private bool GetUltraGridRow( UltraGrid ugIndex, int dwRow, out AddressData awSelected )
		{
			if( ugIndex.Rows.Count < dwRow )
			{
				awSelected = null;
				return false;
			}
			
			awSelected = (AddressData)( (AddressData)ugIndex.Rows[0].Cells["地区名称"].OriginalValue ).Clone();
			return true;
		}
		
		#endregion
		
		#region グリッドが選択されたときの処理関数

        /// <summary>
        /// グリッドの見た目設定
        /// </summary>
        /// <param name="grid"></param>
        private void SetGridVisual(UltraGrid grid)
        {
            grid.DisplayLayout.Bands[0].Columns["データ"].Hidden = true;
            grid.DisplayLayout.Bands[0].Columns["連結コード"].Hidden = true;
            grid.DisplayLayout.Bands[0].ColHeadersVisible = false;
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
        }

		/// <summary>
		/// 指定の地区グループコードからぶら下がる住所インデックスマスタ１
		/// を引いてグリッドに入れる。選択位置も反映
		/// </summary>
		private void setSelectedAddrIndexWork1( int intAddrConnectCd1 )
		{
			List<AreaGroup> alIndexMaster1;

            this.teIndex1.Text = "";
            this.teIndex2.Text = "";
            this.teIndex3.Text = "";
            this.teIndex4.Text = "";
            this.teIndex5.Text = "";

            dtIndex1.Clear();
            dtIndex2.Clear();
            dtIndex3.Clear();
            dtIndex4.Clear();
            dtIndex5.Clear();

            //県を取得
			if( AddressInfoAreaGroupCacheAcs.GetAreaGroupPref( this.AreaGroupCodeSelected, out alIndexMaster1 ) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return;
			}
			
            this.ugIndex1.DataSource = null;

			foreach( AreaGroup aw in alIndexMaster1 )
			{
				DataRow dr = dtIndex1.NewRow();
				dr["地区名称"] = aw.AreaName;
				dr["データ"] = aw;
				dr["連結コード"] = aw.AreaCode;
				dtIndex1.Rows.Add( dr );
			}

            this.ugIndex1.DataSource = dtIndex1;
            this.ugIndex1.UpdateData();
            this.SetGridVisual(this.ugIndex1);

            //指定位置を選択
			for( int i = 0 ; i < ugIndex1.Rows.Count ; i++ )
			{
				if( ((AreaGroup)ugIndex1.Rows[i].Cells["データ"].Value).AreaCode == intAddrConnectCd1 )
				{
                    ugIndex1.Rows[i].Activate();
                    this.teIndex1.Text = (string)ugIndex1.Rows[i].Cells["地区名称"].Value;
					
					break;
				}
			}
			
		}

		/// <summary>
		/// 指定の住所マスタから該当する住所インデックスマスタ２を引いてリストボックスに表示
		/// </summary>
		private void setSelectedAddrIndexWork2( int intAddrConnectCd1, int intAddrConnectCd2 )
		{
			ArrayList alIndexMaster2;

            this.teIndex2.Text = "";
            this.teIndex3.Text = "";
            this.teIndex4.Text = "";
            this.teIndex5.Text = "";

            this.dtIndex2.Rows.Clear();
            this.dtIndex3.Rows.Clear();
            this.dtIndex4.Rows.Clear();
            this.dtIndex5.Rows.Clear();
            
            //住所インデックスマスタ2取得
			if( this.addressAcs.GetAddrIndexWork2( intAddrConnectCd1, out alIndexMaster2 ) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return;
			}

            //アクティブな列が表示領域内に入るようにデータソースを切り離す
            this.ugIndex2.DataSource = null;

			foreach( AddressData aw in alIndexMaster2 )
			{
				DataRow dr = dtIndex2.NewRow();
				dr["地区名称"] = aw.DivAddress2;
				dr["データ"] = aw;
				dr["連結コード"] = aw.AddrConnectCd2;
				dtIndex2.Rows.Add( dr );
			}

            this.ugIndex2.DataSource = dtIndex2;
            this.ugIndex2.UpdateData();
            this.SetGridVisual(this.ugIndex2);

			//指定位置を選択
			for( int i = 0 ; i < ugIndex2.Rows.Count ; i++ )
			{
				if( ((AddressData)ugIndex2.Rows[i].Cells["データ"].Value).AddrConnectCd2 == intAddrConnectCd2 )
				{
                    //選択
					this.ugIndex2.Rows[i].Activate();
                    this.teIndex2.Text = (string)ugIndex2.Rows[i].Cells["地区名称"].Value;
					
					break;
				}
			}
			
		}
		
		
		/// <summary>
		/// 指定の住所マスタから該当する住所インデックスマスタ３を引いてリストボックスに表示
		/// </summary>
		private void setSelectedAddrIndexWork3( int intAddrConnectCd1, long intAddrConnectCd2, int intAddrConnectCd3 )
		{
			ArrayList alIndexMaster3;

            this.teIndex3.Text = "";
            this.teIndex4.Text = "";
            this.teIndex5.Text = "";

            this.dtIndex3.Rows.Clear();
            this.dtIndex4.Rows.Clear();
            this.dtIndex5.Rows.Clear();

            //住所インデックスマスタ2取得
			if( this.addressAcs.GetAddrIndexWork3( intAddrConnectCd1, intAddrConnectCd2, out alIndexMaster3 ) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return;
			}
			
            this.ugIndex3.DataSource = null;

			foreach( AddressData aw in alIndexMaster3 )
			{
				DataRow dr = dtIndex3.NewRow();
				dr["地区名称"] = aw.DivAddress3;
				dr["データ"] = aw;
				dr["連結コード"] = aw.AddrConnectCd3;
				dtIndex3.Rows.Add( dr );
			}

            this.ugIndex3.DataSource = dtIndex3;
            this.ugIndex3.UpdateData();
            this.SetGridVisual(this.ugIndex3);

            //指定位置を選択
			for( int i = 0 ; i < ugIndex3.Rows.Count ; i++ )
			{
				if( ((AddressData)ugIndex3.Rows[i].Cells["データ"].Value).AddrConnectCd3 == intAddrConnectCd3 )
				{
                    //選択
					this.ugIndex3.Rows[i].Activate();
                    this.teIndex3.Text = (string)ugIndex3.Rows[i].Cells["地区名称"].Value;
					
					break;
				}
			}
			
		}
		
		/// <summary>
		/// 指定の住所マスタから該当する住所インデックスマスタ４を引いてリストボックスに表示
		/// </summary>
		private void setSelectedAddrIndexWork4( int intAddrConnectCd1, long intAddrConnectCd2, int intAddrConnectCd3, int intAddrConnectCd4 )
		{
			ArrayList alIndexMaster4;

            this.teIndex4.Text = "";
            this.teIndex5.Text = "";

            this.dtIndex4.Rows.Clear();
            this.dtIndex5.Rows.Clear();

            //住所インデックスマスタ2取得
			if( this.addressAcs.GetAddrIndexWork4( intAddrConnectCd1, intAddrConnectCd2, intAddrConnectCd3, out alIndexMaster4 ) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return;
			}
			
            this.ugIndex4.DataSource = null;

			foreach( AddressData aw in alIndexMaster4 )
			{
				DataRow dr = dtIndex4.NewRow();
				dr["地区名称"] = aw.DivAddress4;
				dr["データ"] = aw;
				dr["連結コード"] = aw.AddrConnectCd4;
				dtIndex4.Rows.Add( dr );
			}

            this.ugIndex4.DataSource = dtIndex4;
            this.ugIndex4.UpdateData();
            this.SetGridVisual(this.ugIndex4);

			//指定位置を選択
			for( int i = 0 ; i < ugIndex4.Rows.Count ; i++ )
			{
				if( ((AddressData)ugIndex4.Rows[i].Cells["データ"].Value).AddrConnectCd4 == intAddrConnectCd4 )
				{
                    //選択
					this.ugIndex4.Rows[i].Activate();
                    this.teIndex4.Text = (string)ugIndex4.Rows[i].Cells["地区名称"].Value;

					break;
				}
			}
			
		}
		
		/// <summary>
		/// 指定の住所マスタから該当する住所インデックスマスタ５を引いてリストボックスに表示
		/// </summary>
		private void setSelectedAddrIndexWork5( int intAddrConnectCd1, long intAddrConnectCd2, int intAddrConnectCd3, int intAddrConnectCd4, int intAddrConnectCd5 )
		{
			ArrayList alIndexMaster5;

            this.teIndex5.Text = "";

            this.dtIndex5.Rows.Clear();

            //住所インデックスマスタ5取得
			if( this.addressAcs.GetAddrIndexWork5( intAddrConnectCd1, intAddrConnectCd2, intAddrConnectCd3, intAddrConnectCd4, out alIndexMaster5 ) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return;
			}
			
            this.ugIndex5.DataSource = null;

			foreach( AddressData aw in alIndexMaster5 )
			{
				DataRow dr = dtIndex5.NewRow();
				dr["地区名称"] = aw.DivAddress5;
				dr["データ"] = aw;
				dr["連結コード"] = aw.AddrConnectCd5;
				dtIndex5.Rows.Add( dr );
			}

            this.ugIndex5.DataSource = dtIndex5;
            this.ugIndex5.UpdateData();

            this.SetGridVisual(this.ugIndex5);

			//指定位置を選択
			for( int i = 0 ; i < ugIndex5.Rows.Count ; i++ )
			{
				if( ((AddressData)ugIndex5.Rows[i].Cells["データ"].Value).AddrConnectCd5 == intAddrConnectCd5 )
				{
					//選択
					this.ugIndex5.Rows[i].Activate();
                    this.teIndex5.Text = (string)ugIndex5.Rows[i].Cells["地区名称"].Value;
					break;
				}
			}
			
		}
		
		/// <summary>
		/// 指定グリッドの地区名称にマッチする列をアクティブにする
		/// </summary>
		/// <param name="ugIndex"></param>
		/// <param name="keyword"></param>
		/// <returns></returns>
		private int SelectKeyWordMatchItem(UltraGrid ugIndex, string keyword)
		{
			if( ugIndex == null )
			{
				return -1;
			}

			int ret = -1;
			for( int i = 0 ; i < ugIndex.Rows.Count ; i++ )
			{
				try
				{
					if( ( ugIndex.Rows[i].Cells["地区名称"].Value ).ToString().IndexOf(keyword) >= 0 )
					{
						ugIndex.Rows[i].Activate();
						//this.SelectUltraGridRow( ugIndex, i );
						ret = i;
						break;
					}
				}
				catch( Exception )
				{
					ret = -1;
					break;
				}
			}
			return ret;
		}
		
		#endregion
		
		/// <summary>
		/// エンターでフォーカスが変えられたときのイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			
			TEdit te;
			UltraButton ub;
			UltraGrid ugSender;
			
			//エンターキー以外でフォーカスが変わったときは何もしない
			if( e.Key != System.Windows.Forms.Keys.Enter )
			{
				return;
			}
			
			if( ( te = e.PrevCtrl as TEdit ) != null )
			{
				//キーワード入力用テキストボックスでキーワードが入力されているなら
				if( te.Name == "teKeyword" )
				{
					if( te.Text != "" )
					{
						this.ubSearch.PerformClick();
						//フォーカス移動無効
						e.NextCtrl = null;
					}
				}
				else if( te.Name == "tePostNoKeyword" )
				{
					if( te.Text != "" )
					{
						this.ubPostNoSearch.PerformClick();
						//フォーカス移動無効
						e.NextCtrl = null;
					}
				}
				else
				{
					//テキストボックスに文字が入っていなかったらなにもしない
					if( te.Text == "" )
					{
						return;
					}
				
					//キーワードにマッチするアイテムを選択させる
					if( this.SelectKeyWordMatchItem( (UltraGrid)te.Tag, te.Text ) < 0 )
					{
						te.Text = "";
					}
				}

			}
				//キーワード検索ボタンの場合
				//キーワードがあれば検索ボタンを押したことにする
			else if( ( ub = e.PrevCtrl as UltraButton ) != null )
			{
				if(ub.Name == "ubSearch" && this.teKeyword.Text != "")
				{
					this.ubSearch.PerformClick();
					//フォーカス移動無効
					e.NextCtrl = null;
				}
			}
			
				//UltraGridでエンターおされたら確定ボタンを押されたことにする
			else if( ( ugSender = e.PrevCtrl as UltraGrid ) != null )
			{

				//もしダブルクリックされたグリッドが完全な住所情報を持っていた場合はそれを結果とする
				if( ugSender == this.ugIndex2 
                    && ugSender.ActiveRow != null
					&& ((AddressData)ugSender.ActiveRow.Cells["データ"].Value).AddrConnectCd2 != 0 
					&& ((AddressData)ugSender.ActiveRow.Cells["データ"].Value).AddrConnectCd3 == 0 )
				{
					this.addressWorkResult = ugSender.ActiveRow.Cells["データ"].Value as AddressData;
				}
				else if( ugSender == this.ugIndex3
                    && ugSender.ActiveRow != null
                    && ((AddressData)ugSender.ActiveRow.Cells["データ"].Value).AddrConnectCd3 != 0 
					&& ((AddressData)ugSender.ActiveRow.Cells["データ"].Value).AddrConnectCd4 == 0 )
				{
					this.addressWorkResult = ugSender.ActiveRow.Cells["データ"].Value as AddressData;
				}
				else if( ugSender == this.ugIndex4
                    && ugSender.ActiveRow != null
                    && ((AddressData)ugSender.ActiveRow.Cells["データ"].Value).AddrConnectCd4 != 0 
					&& ((AddressData)ugSender.ActiveRow.Cells["データ"].Value).AddrConnectCd5 == 0 )
				{
					this.addressWorkResult = ugSender.ActiveRow.Cells["データ"].Value as AddressData;
				}
				else if( ugSender == this.ugIndex5
                    && ugSender.ActiveRow != null)
				{
					this.addressWorkResult = ugSender.ActiveRow.Cells["データ"].Value as AddressData;
				}
				
				//何も選ばれていないなら戻る
				if( addressWorkResult == null )
				{
					return;
				}
				
				//複数郵便番号があった場合選ばせる
				if( this.SelectPostNo() != DialogResult.OK )
				{
					return;
				}
				
				this.PerformOkClick();
			}
			
		}
		
		#region ツールバーのボタンが押されたときのイベント
		
		//ツールバーのボタンがクリックされたときの処理
		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch( e.Tool.CaptionResolved )
			{
				
				case "管区(&G)":
					this.PerformAreaGroupClick();
					break;
					
				case "確定(&S)":
					this.PerformOkClick();
					break;
					
				case "戻る(&C)":
					this.PerformCancelClick();
					break;
					
				case "別の住所情報(&O)":

                    this.WaitWindowShow();

                    try
                    {
                        this.ChangeOtherAcs();
                    }
                    finally
                    {
                        this.WaitWindowClose();
                    }
					break;
					
				default:
					break;
			}
		}
		
		#endregion
		
		#region ボタンが押されたときの処理
		
		AddressData addressWorkResult = null;
		
		/// <summary>
		/// 結果を取得するメソッド
		/// </summary>
		/// <returns></returns>
		public AddressData GetResult()
		{
			return this.addressWorkResult;
		}
		
		/// <summary>
		/// 管区ボタンが押されたときの処理
		/// </summary>
		public void PerformAreaGroupClick()
		{
			//ロード中に管区ボタンがおされても無反応
            //if( this.addressAcs.NowLoading )
            //{
            //    return;
            //}
			
			AreaGroupWindow agDialog;

			//デフォルト選択地区グループコードを指定して管区選択窓作成
			agDialog = new AreaGroupWindow( this.AreaGroupCodeSelected );

            try
            {
                this.ulStatusBar.Focus();

                //管区選択窓で確定ボタン以外が押されたとき
                if (agDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            finally
            {
                this.teKeyword.Focus();
            }

			AreaGroup agResult = agDialog.GetResult();
			//確定ボタンが押されたが何も選択されてなかった場合
			if( agResult == null )
			{
				return;
			}
			
			//同じ管区が選択されていたら
			if( agResult.AreaGroupCode == this.AreaGroupCodeSelected )
			{
				return;
			}

            List<AreaGroup> alTmp = null;
			
			//県取得
			AddressInfoAreaGroupCacheAcs.GetAreaGroupPref( agResult.AreaGroupCode, out alTmp );
			
			//県の情報がひとつも取得できなかった場合
			if( alTmp == null || alTmp.Count <= 0 )
			{
				return;
			}
			
			//選択されている地区グループコードを変更
			this.AreaGroupCodeSelected = agResult.AreaGroupCode;
			
            //Imeモード退避
            this.ulStatusBar.Focus();

			this.WaitWindowShow();

            try
            {
                this.setSelectedAddrIndexWork1(0);

                if (this.dtIndex1.Rows.Count > 0)
                {
                    ArrayList alTmp2;
                    this.addressAcs.GetAddrIndexWork2((int)this.dtIndex1.Rows[0]["連結コード"], out alTmp2);
                }
            }
            finally
            {
                this.WaitWindowClose();

                this.teKeyword.Focus();
            }

            //管区のコンボボックスに現在選択されている管区を反映する
            this.areaGroupTComboEditor.Value = this.AreaGroupCodeSelected;

            //管区のラベルにも反映
            this.areaGroupLabel.Text = this.areaGroupTComboEditor.SelectedItem.DisplayText;
		}
		
		/// <summary>
		/// 複数郵便番号があったとき選ばせる
		/// </summary>
        private DialogResult SelectPostNo()
        {
            //ここで複数郵便番号選択をさせる
            //住所マスタからデータを取得した場合のみやる
            if (this.addressWorkResult != null &&
                (this.addressWorkResult.AddressCode1Lower != 0
                || this.addressWorkResult.AddressCode1Upper != 0
                || this.addressWorkResult.AddressCode2 != 0
                || this.addressWorkResult.AddressCode3 != 0))
            {
                //住所コードがある場合（住所マスタからデータ取得）
                ArrayList alTmp = new ArrayList();

                int status = this.addressAcs.GetAddressWork(
                    this.addressWorkResult.AddrConnectCd1,
                    this.addressWorkResult.AddrConnectCd2,
                    this.addressWorkResult.AddrConnectCd3,
                    this.addressWorkResult.AddrConnectCd4,
                    this.addressWorkResult.AddrConnectCd5,
                    out alTmp);

                //複数ある場合
                if (alTmp != null && alTmp.Count > 1)
                {
                    PostNoSelectWindow posWin = new PostNoSelectWindow(alTmp);

                    try
                    {
                        this.ulStatusBar.Focus();

                        //選択窓がキャンセルされたら戻る
                        if (posWin.ShowDialog() != DialogResult.OK)
                        {
                            this.addressWorkResult = null;
                            return DialogResult.Cancel;
                        }
                    }
                    finally
                    {
                        this.teKeyword.Focus();
                    }

                    this.addressWorkResult = posWin.GetResult();

                    //なにも選ばれてないなら戻る
                    if (this.addressWorkResult == null)
                    {
                        return DialogResult.Cancel;
                    }

                }

            }

            return DialogResult.OK;
        }
		
		//確定が押されたことにする
		public void PerformOkClick()
		{
			//結果が設定されていない場合は結果を設定
			//すでに設定されている場合はそれを優先する
			if( this.addressWorkResult == null )
			{
				//ここに来るのはグリッドで選択されたとき
				//結果取得処理
				if( this.ugIndex5.ActiveRow != null )
				{
					this.addressWorkResult = this.ugIndex5.ActiveRow.Cells["データ"].Value as AddressData;
				}
				else if( this.ugIndex4.ActiveRow != null )
				{
					this.addressWorkResult = this.ugIndex4.ActiveRow.Cells["データ"].Value as AddressData;
				}
				else if( this.ugIndex3.ActiveRow != null )
				{
					this.addressWorkResult = this.ugIndex3.ActiveRow.Cells["データ"].Value as AddressData;
				}
				else if( this.ugIndex2.ActiveRow != null )
				{
					this.addressWorkResult = this.ugIndex2.ActiveRow.Cells["データ"].Value as AddressData;
				}
				
				//複数郵便番号があった場合選ばせる
				if( this.SelectPostNo() != DialogResult.OK )
				{
					return;
				}
			}
			
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		
		//取り消しが押されたことにする
		public void PerformCancelClick()
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		#endregion

        #region お待ちくださいウインドウメソッド

        private SFCMN00299CA waitWindow = null;

        /// <summary>
        /// お待ちください窓表示関数
        /// </summary>
        private void WaitWindowShow()
        {
            //窓が無い場合
            if (this.waitWindow == null)
            {
                this.waitWindow = new SFCMN00299CA();
                this.waitWindow.DispCancelButton = false;
                this.waitWindow.Message = "住所情報を取得しています。";
                this.waitWindow.Title = "住所情報取得";
            }

            this.Refresh();
            waitWindow.Show(this);
            this.Refresh();
        }

        /// <summary>
        /// お待ちください窓閉じる関数
        /// </summary>
        private void WaitWindowClose()
        {
            if (this.waitWindow != null)
            {
                this.waitWindow.Close();
                this.waitWindow = null;
            }
        }

        #endregion
		
		/// <summary>
		/// このウィンドウがロードされたときの処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddressGuideWindow_Load(object sender, System.EventArgs e)
		{
            //ウィンドウの都合でShownに移動
            ////お待ちください窓作成
            //this.WaitWindowShow();
            
            //try
            //{
            //    this.setSelectedAddrIndexWork1(this.AddrConnectCd1Def);
            //}
            //finally
            //{
            //    //お待ちください窓を閉じる
            //    this.WaitWindowClose();
            //}
		}
		
		#region グリッドのイベント

        /// <summary>
        /// 指定位置のセルを取得する
        /// セル以外だったらnullを返す
        /// </summary>
        /// <param name="point"></param>
        /// <param name="ugClick"></param>
        /// <returns></returns>
        private static UltraGridCell GetCell(Point point, UltraGrid ugClick)
        {
            point = ugClick.PointToClient(point);
            Infragistics.Win.UIElement objElement = null;
            Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
            objElement = ugClick.DisplayLayout.UIElement.ElementFromPoint(point);

            if (objElement == null)
            {
                return null;
            }
            objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
                (typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

            // ヘッダ部の場合は以下の処理をキャンセルします。
            if (objRowCellAreaUIElement == null)
            {
                return null;
            }

            UltraGridCell ugCell;

            //クリックした部分が列じゃなかった場合
            if ((ugCell = objElement.GetContext(typeof(UltraGridCell)) as UltraGridCell) == null)
            {
                return null;
            }

            return ugCell;
        }

		//グリッドがダブルクリックされたときの処理
		private void ugIndex1_DoubleClick(object sender, System.EventArgs e)
		{
			UltraGrid ugSender = sender as UltraGrid;

            if (GetCell(Cursor.Position, ugSender) == null)
            {
                return;
            }
			
			//もしダブルクリックされたグリッドが完全な住所情報を持っていた場合はそれを結果とする
			if( ugSender == this.ugIndex2 
				&& ((AddressData)ugSender.ActiveRow.Cells["データ"].Value).AddrConnectCd2 != 0 
				&& ((AddressData)ugSender.ActiveRow.Cells["データ"].Value).AddrConnectCd3 == 0 )
			{
				this.addressWorkResult = ugSender.ActiveRow.Cells["データ"].Value as AddressData;
			}
			else if( ugSender == this.ugIndex3 
				&& ((AddressData)ugSender.ActiveRow.Cells["データ"].Value).AddrConnectCd3 != 0 
				&& ((AddressData)ugSender.ActiveRow.Cells["データ"].Value).AddrConnectCd4 == 0 )
			{
				this.addressWorkResult = ugSender.ActiveRow.Cells["データ"].Value as AddressData;
			}
			else if( ugSender == this.ugIndex4 
				&& ((AddressData)ugSender.ActiveRow.Cells["データ"].Value).AddrConnectCd4 != 0 
				&& ((AddressData)ugSender.ActiveRow.Cells["データ"].Value).AddrConnectCd5 == 0 )
			{
				this.addressWorkResult = ugSender.ActiveRow.Cells["データ"].Value as AddressData;
			}
			else if( ugSender == this.ugIndex5 )
			{
				this.addressWorkResult = ugSender.ActiveRow.Cells["データ"].Value as AddressData;
			}
			
			if( this.addressWorkResult == null )
			{
				return;
			}
			
			if( this.SelectPostNo() != DialogResult.OK )
			{
				return;
			}
			
			this.PerformOkClick();
		}
		
		/// <summary>
		/// 県のグリッドがアクティブになったときの処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ugIndex1_AfterRowActivate(object sender, System.EventArgs e)
		{
			if( this.ugIndex1.ActiveRow == null )
			{
				return;
			}
			this.ugIndex1.ActiveRow.Selected = true;
			this.teIndex1.Text = (string)this.ugIndex1.ActiveRow.Cells["地区名称"].Value;
			
			AreaGroup agSelect = this.ugIndex1.ActiveRow.Cells["データ"].Value as AreaGroup;
			
			if( this.AddressIndex2Init )
			{
				this.setSelectedAddrIndexWork2( agSelect.AreaCode, 0 );
			}
			else
			{
				//初期位置を与える
				this.setSelectedAddrIndexWork2( agSelect.AreaCode, this.AddrConnectCd2Def );
				this.AddressIndex2Init = true;
			}
		}
		
		/// <summary>
		/// 2番目のグリッドの列がアクティブになったときの処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ugIndex2_AfterRowActivate(object sender, System.EventArgs e)
		{
			if( this.ugIndex2.ActiveRow == null )
			{
				return;
			}
			this.ugIndex2.ActiveRow.Selected = true;
			this.teIndex2.Text = (string)this.ugIndex2.ActiveRow.Cells["地区名称"].Value;
			
			AddressData awSelect = this.ugIndex2.ActiveRow.Cells["データ"].Value as AddressData;
			
			if( this.AddressIndex3Init )
			{
				this.setSelectedAddrIndexWork3( awSelect.AddrConnectCd1, awSelect.AddrConnectCd2, 0 );
			}
			else
			{
				//初期位置を与える
				this.setSelectedAddrIndexWork3( awSelect.AddrConnectCd1, awSelect.AddrConnectCd2, this.AddrConnectCd3Def );
				this.AddressIndex3Init = true;
			}
		}
		
		/// <summary>
		/// ３番目のグリッドの列がアクティブになったときの処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ugIndex3_AfterRowActivate(object sender, System.EventArgs e)
		{
			if( this.ugIndex3.ActiveRow == null )
			{
				return;
			}
			this.ugIndex3.ActiveRow.Selected = true;
			this.teIndex3.Text = (string)this.ugIndex3.ActiveRow.Cells["地区名称"].Value;
			
			AddressData awSelect = this.ugIndex3.ActiveRow.Cells["データ"].Value as AddressData;
			
			if( this.AddressIndex4Init )
			{
				this.setSelectedAddrIndexWork4( awSelect.AddrConnectCd1, awSelect.AddrConnectCd2, awSelect.AddrConnectCd3, 0 );
			}
			else
			{
				//初期位置を与える
				this.setSelectedAddrIndexWork4( awSelect.AddrConnectCd1, awSelect.AddrConnectCd2, awSelect.AddrConnectCd3, this.AddrConnectCd4Def );
				this.AddressIndex4Init = true;
			}
		}
		
		/// <summary>
		/// ４番目のグリッドの列がアクティブになったときの処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ugIndex4_AfterRowActivate(object sender, System.EventArgs e)
		{
			if( this.ugIndex4.ActiveRow == null )
			{
				return;
			}
			this.ugIndex4.ActiveRow.Selected = true;
			this.teIndex4.Text = (string)this.ugIndex4.ActiveRow.Cells["地区名称"].Value;
			
			AddressData awSelect = this.ugIndex4.ActiveRow.Cells["データ"].Value as AddressData;
			
			if( this.AddressIndex5Init )
			{
				this.setSelectedAddrIndexWork5( awSelect.AddrConnectCd1, awSelect.AddrConnectCd2, awSelect.AddrConnectCd3, awSelect.AddrConnectCd4, 0 );
			}
			else
			{
				//初期位置を与える
				this.setSelectedAddrIndexWork5( awSelect.AddrConnectCd1, awSelect.AddrConnectCd2, awSelect.AddrConnectCd3, awSelect.AddrConnectCd4, this.AddrConnectCd5Def );
				this.AddressIndex5Init = true;
			}
		}
		
		/// <summary>
		/// 5番目のグリッドの列がアクティブになったときの処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ugIndex5_AfterRowActivate(object sender, System.EventArgs e)
		{
			if( this.ugIndex5.ActiveRow == null )
			{
				return;
			}
			
			this.ugIndex5.ActiveRow.Selected = true;
			this.teIndex5.Text = (string)this.ugIndex5.ActiveRow.Cells["地区名称"].Value;
			
		}
		
		#endregion
		
		/// <summary>
		/// ステータスバーに文字列をセットする。
		/// </summary>
		/// <param name="strMsg"></param>
		private void SetStatusBarText( string strMsg )
		{
		    this.ulStatusBar.Text = strMsg;
		}

        private void AddressGuideWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.PerformCancelClick();
            }
        }

        private void AddressGuideWindow_Shown(object sender, EventArgs e)
        {
            //お待ちください窓作成
            this.WaitWindowShow();

            try
            {
                this.setSelectedAddrIndexWork1(this.AddrConnectCd1Def);
            }
            finally
            {
                //お待ちください窓を閉じる
                this.WaitWindowClose();
            }
            this.ulStatusBar.Focus();
            this.teKeyword.Focus();
        }
				
	}
	
}
