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
	/// �A�h���X�K�C�h���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note: 2008.05.07 ��ؐ��b</br>
    /// <br>             �@DC.NS����NetAdvantage�o�[�W�����A�b�v�Ή�</br>
	/// </remarks>
	internal class AddressGuideWindow : System.Windows.Forms.Form
	{
		#region �R���|�[�l���g
		
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
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
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
		
		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
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
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�m��(S)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("������(X)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�ǋ�(G)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�ʂ̏Z�����(O)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�ǋ�(G)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�m��(S)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("������(X)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�ʂ̏Z�����(O)");
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
			this.ubSearch.Text = "����(&F)";
			this.toolTip1.SetToolTip(this.ubSearch, "�J�i�A���̂ŞB�������ł��܂��B");
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
			this.toolTip1.SetToolTip(this.teKeyword, "�J�i�A���̂ŞB�������ł��܂��B");
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
			buttonTool5.SharedProps.Caption = "�ǋ�(&G)";
			buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool6.SharedProps.Caption = "�m��(&S)";
			buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool7.SharedProps.Caption = "�߂�(&C)";
			buttonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool8.SharedProps.Caption = "�ʂ̏Z�����(&O)";
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
			this.ultraLabel1.Text = "�Z�����̌���";
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
			this.ubPostNoSearch.Text = "����(&Y)";
			this.toolTip1.SetToolTip(this.ubPostNoSearch, "�X�֔ԍ��Ō������܂�");
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
			this.ultraLabel2.Text = "�X�֔ԍ�����";
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
			this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddressGuideWindow";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "�Z���K�C�h";
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
		
		#region UI�̊O�ϐݒ胁�\�b�h

		/// <summary>
		/// UltraGrid�̔z�F���d�l�ʂ�ɐݒ肷��
		/// </summary>
		/// <param name="ugTarget"></param>
		private void setGridAppearance( Infragistics.Win.UltraWinGrid.UltraGrid ugTarget )
		{
			//�^�C�g���̊O��
			ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
			ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			ugTarget.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			ugTarget.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			ugTarget.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;

			//�w�i�F��ݒ�
			ugTarget.DisplayLayout.Appearance.BackColor = Color.White;
			
			//�������J�����ɓ���悤�ɐݒ肷��
			//ugTarget.DisplayLayout.AutoFitColumns = true;
            ugTarget.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

			// �I���s�̊O�ς�ݒ�
			ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
			ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
			ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			//�s�Z���N�^�̐ݒ�
			ugTarget.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.White;

			ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			
			//�s�̃T�C�Y�ύX�s��
			ugTarget.DisplayLayout.Override.RowSizing = RowSizing.Fixed;
			
			//�C���W�Q�[�^��\��
			ugTarget.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			
			//�����̈��\��
			ugTarget.DisplayLayout.MaxColScrollRegions = 1;
			ugTarget.DisplayLayout.MaxRowScrollRegions = 1;
						
			//���݂ɍs�̐F��ς���
			ugTarget.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
			
			//�O���b�h�̔w�i�F��ς���
			ugTarget.DisplayLayout.Appearance.BackColor = Color.Gray;
			
			//�����X�N���[���o�[�̂݋���
			ugTarget.DisplayLayout.Scrollbars = Scrollbars.Automatic;
			
			//�A�N�e�B�u�s�̃t�H���g�̐F��ς���
			ugTarget.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
			
			//�A�N�e�B�u�s�̃t�H���g�𑾎��ɂ���
			ugTarget.DisplayLayout.Override.ActiveRowAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			
		}
		
		/// <summary>
		/// UltraGrid�̋�����ݒ肷��
		/// </summary>
		/// <param name="ugTarget"></param>
		private void setGridBehavior( Infragistics.Win.UltraWinGrid.UltraGrid ugTarget )
		{
			//�񕝂̎��������s��
			//ugTarget.DisplayLayout.AutoFitColumns = false;
            ugTarget.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

			//�s�̒ǉ��s��
			ugTarget.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			
			//�s�̍폜�s��
			ugTarget.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			
			// ��̈ړ��s��
			ugTarget.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
			
			// ��̌����s��
			ugTarget.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
			
			// �t�B���^�̎g�p�s��
			ugTarget.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
			
			// ���[�U�[�̃f�[�^������������
			ugTarget.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
			
			//�I����@���s�I���ɐݒ�B
			ugTarget.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			
			//�w�b�_���N���b�N�����Ƃ��͗�I����Ԃɂ���B
			ugTarget.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
			//+��I��s�ɂ��邱�ƂŃw�b�_���N���b�N���Ă������N����Ȃ�
			ugTarget.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;

			//��s�̂ݑI���\�ɂ���
			ugTarget.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
			
			//�X�N���[�����ɂ����܂ǂ��������Ă����ԂȂ̂����킩��悤�ɂ���
			ugTarget.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

            ugTarget.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;

			//IME����
			ugTarget.ImeMode = ImeMode.Disable;			
		}
		
		void setTEditAppearance( TEdit teTarget )
		{
			//�I�����ꂽ�Ƃ��̔w�i�F��ς���
			teTarget.ActiveAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
			teTarget.ActiveAppearance.BackColor2 = Color.FromArgb( 247, 227, 156 );
		}
		
		void setTComboEditorAppearance( TComboEditor tceTarget )
		{
			//�I�����ꂽ�Ƃ��̔w�i�F��ς���
			tceTarget.ActiveAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
			tceTarget.ActiveAppearance.BackColor2 = Color.FromArgb( 247, 227, 156 );
		}

		private void setToolbarAppearance()
		{
			//�c�[���o�[�ɃA�C�R���ݒ�
			//using Broadleaf.Library.Resources;
			//SFCMN00008C
			ImageList imList = IconResourceManagement.ImageList16;
			this.ultraToolbarsManager1.ImageListSmall = imList;

			this.ultraToolbarsManager1.Toolbars[0].Tools[0].InstanceProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			this.ultraToolbarsManager1.Toolbars[0].Tools[1].InstanceProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;

			//�c�[���o�[���J�X�^�}�C�Y�s�ɂ���
			this.ultraToolbarsManager1.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
		}
		
		//���l�̗��ݒ肷��
		private void setNumberColumnAppearance( UltraGrid ug, string strColumn, string strFormat )
		{
			ug.DisplayLayout.Bands[0].Columns[strColumn].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			ug.DisplayLayout.Bands[0].Columns[strColumn].Format = strFormat;
		}
		
		#endregion
		
		/// <summary>
		/// �}�[�W�����Z���A�N�Z�X�N���X
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
		/// �Z���K�C�h�̃R���X�g���N�^
		/// </summary>
		/// <param name="addrConnectCd1Def">�f�t�H���g�̏Z���A���R�[�h�P�i�n��R�[�h�j</param>
		/// <param name="addrConnectCd2Def">�f�t�H���g�̏Z���A���R�[�h�Q</param>
		/// <param name="addrConnectCd3Def">�f�t�H���g�̏Z���A���R�[�h�R</param>
		/// <param name="addrConnectCd4Def">�f�t�H���g�̏Z���A���R�[�h�S</param>
		/// <param name="addrConnectCd5Def">�f�t�H���g�̏Z���A���R�[�h�T</param>
		public AddressGuideWindow( int addrConnectCd1Def, int addrConnectCd2Def, int addrConnectCd3Def, int addrConnectCd4Def, int addrConnectCd5Def )
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();
			
			//�I�t���C�����[�h�̂Ƃ��̓L�[���[�h�����͂ł��Ȃ�
			if( !LoginInfoAcquisition.OnlineFlag )
			{
				this.teKeyword.Enabled = false;
				this.ubSearch.Enabled = false;
				
				this.tePostNoKeyword.Enabled = false;
				this.ubPostNoSearch.Enabled = false;
                this.areaGroupTComboEditor.Enabled = false;
			}
			
			//�����{�^��
			this.ubSearch.Appearance.Image = IconResourceManagement.ImageList16.Images[ (int)Size16_Index.SEARCH ];
			this.ubPostNoSearch.Appearance.Image = IconResourceManagement.ImageList16.Images[ (int)Size16_Index.SEARCH ];
			
			this.setToolbarAppearance();
			
			//�ǋ�̃{�^����ݒ�
			this.ultraToolbarsManager1.Toolbars[0].Tools[2].InstanceProps.AppearancesSmall.Appearance.Image = IconResourceManagement.ImageList16.Images[ (int)Size16_Index.FOLDER ];
			
			//�ʂ̏Z�����̃{�^����ݒ�
			this.ultraToolbarsManager1.Toolbars[0].Tools[3].InstanceProps.AppearancesSmall.Appearance.Image = IconResourceManagement.ImageList16.Images[ (int)Size16_Index.RETRY ];

			//�e�L�X�g�{�b�N�X��UltraGrid���֘A�t����
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
			
			//�}�[�W�����A�N�Z�X�N���X�����[�h����
			this.addressAcs = new MergedAddressAcs();
			
			this.AddrConnectCd1Def = addrConnectCd1Def;
			this.AddrConnectCd2Def = addrConnectCd2Def;
			this.AddrConnectCd3Def = addrConnectCd3Def;
			this.AddrConnectCd4Def = addrConnectCd4Def;
			this.AddrConnectCd5Def = addrConnectCd5Def;
			
			//�Z���A���R�[�h�P����w�菉���\���ǋ���擾
			this.AreaGroupCodeSelected = AddressInfoAreaGroupCacheAcs.GetAreaGroupCodeFromAreaCode( addrConnectCd1Def );
			
			//�s���ȏ����\���ʒu�������ꍇ
			if( this.AddrConnectCd1Def == 0 
				|| this.AreaGroupCodeSelected == 0 )
			{
				List<AreaGroup> alAreaGroup;
				
				AddressInfoAreaGroupCacheAcs.GetAreaGroup( out alAreaGroup );
				
				//�ǋ悪�擾�ł����ꍇ
				if( alAreaGroup != null 
					&& alAreaGroup.Count > 0 )
				{
					AreaGroup agTop = alAreaGroup[0];
					if( agTop != null )
					{
						//�ǋ�R�[�h�擾
						this.AreaGroupCodeSelected = agTop.AreaGroupCode;
						
						List<AreaGroup> alAreaGroupPref = null;
						
						AddressInfoAreaGroupCacheAcs.GetAreaGroupPref( agTop.AreaGroupCode, out alAreaGroupPref );
						
						//�ǋ�̌��擾
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
			
			//---------------Grid������---------------
			
			dtIndex1 = new DataTable();
			dtIndex2 = new DataTable();
			dtIndex3 = new DataTable();
			dtIndex4 = new DataTable();
			dtIndex5 = new DataTable();
			
			dtIndex1.Columns.Add( "�n�於��", typeof( string ) );
			dtIndex1.Columns.Add( "�f�[�^", typeof( AreaGroup ) );
			dtIndex1.Columns.Add( "�A���R�[�h", typeof( int ) );
			
			dtIndex2.Columns.Add( "�n�於��", typeof( string ) );
			dtIndex2.Columns.Add( "�f�[�^", typeof( AddressData ) );
			dtIndex2.Columns.Add( "�A���R�[�h", typeof( int ) );
			
			dtIndex3.Columns.Add( "�n�於��", typeof( string ) );
			dtIndex3.Columns.Add( "�f�[�^", typeof( AddressData ) );
			dtIndex3.Columns.Add( "�A���R�[�h", typeof( int ) );
			
			dtIndex4.Columns.Add( "�n�於��", typeof( string ) );
			dtIndex4.Columns.Add( "�f�[�^", typeof( AddressData ) );
			dtIndex4.Columns.Add( "�A���R�[�h", typeof( int ) );
			
			dtIndex5.Columns.Add( "�n�於��", typeof( string ) );
			dtIndex5.Columns.Add( "�f�[�^", typeof( AddressData ) );
			dtIndex5.Columns.Add( "�A���R�[�h", typeof( int ) );
			
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
			
            //�O���b�h�̕\���ݒ�
            this.SetGridVisual(this.ugIndex1);
            this.SetGridVisual(this.ugIndex2);
            this.SetGridVisual(this.ugIndex3);
            this.SetGridVisual(this.ugIndex4);
            this.SetGridVisual(this.ugIndex5);

			//�ŏ��͏Z���}�X�^���[�h������Z���}�X�^��UI�̐ݒ���s��
			this.SetOfferAddressInfoAcsModeUI();

            #region �ǋ�R���{�̃f�[�^�ݒ�

            //�L�[���[�h�����i��p�ǋ��ݒ�
            List<AreaGroup> areaGroupList = null;
            AddressInfoAreaGroupCacheAcs.GetAreaGroup(out areaGroupList);

            //���ɑS�������Ă���
            this.areaGroupTComboEditor.Items.Add(0, "�S��");

            for (int i = 0; i < areaGroupList.Count; i++)
            {
                this.areaGroupTComboEditor.Items.Add(areaGroupList[i].AreaGroupCode, areaGroupList[i].AreaName);
            }

            //�擪�̑S����I��
            if (this.areaGroupTComboEditor.Items.Count > 0)
            {
                this.areaGroupTComboEditor.SelectedIndex = 0;
            }

            //�\���ǋ��I��
            for (int i = 0; i < this.areaGroupTComboEditor.Items.Count; i++)
            {
                if ((int)this.areaGroupTComboEditor.Items[i].DataValue == this.AreaGroupCodeSelected)
                {
                    this.areaGroupTComboEditor.SelectedIndex = i;
                }
            }

            #endregion


            //�ǋ惉�x���Ɋǋ於�̂�ݒ�
            this.areaGroupLabel.Text = this.areaGroupTComboEditor.SelectedItem.DisplayText;
        }
		
		#region UI�̃��[�h�ݒ�֘A�̃��\�b�h
		
		/// <summary>
		/// �Z���}�X�^�pUI�̐ݒ胁�\�b�h
		/// </summary>
		private void SetOfferAddressInfoAcsModeUI()
		{
			this.panel4.Visible = true;
			this.panel5.Visible = true;
			
			//�p�l���̕��ύX���\�b�h
			this.panel1.Width = 145;
			this.panel2.Width = 146;
			this.panel3.Width = 165;
			this.panel4.Width = 200;
			
			//Dock�̃X�^�C����ݒ肷��
			this.panel1.Dock = DockStyle.Left;
			this.panel2.Dock = DockStyle.Left;
			this.panel3.Dock = DockStyle.Left;
			this.panel4.Dock = DockStyle.Left;
			this.panel5.Dock = DockStyle.Fill;
				
			this.splitter3.Visible = true;
			this.splitter4.Visible = true;
				
			this.ulStatusBar.Height = 23 * 2 - 1;

			//�X�e�[�^�X�o�[�ɕ������ݒ肷��
			this.SetStatusBarText( this.addressAcs.StatusBarString );
		}
		
		/// <summary>
		/// �X�֔ԍ��}�X�^�p��UI�̐ݒ胁�\�b�h
		/// </summary>
		private void SetPostNumberAcsModeUI()
		{
			this.panel4.Visible = false;
			this.panel5.Visible = false;
				
			this.panel1.Width = 145;
			this.panel2.Width = 300;
				
			//Dock�̃X�^�C����ݒ肷��
			this.panel1.Dock = DockStyle.Left;
			this.panel2.Dock = DockStyle.Left;
			this.panel3.Dock = DockStyle.Fill;
			
			this.splitter3.Visible = false;
			this.splitter4.Visible = false;
			
			this.ulStatusBar.Height = 23;
			
			//�X�e�[�^�X�o�[�ɕ������ݒ肷��
			this.SetStatusBarText( this.addressAcs.StatusBarString );
			
		}

		/// <summary>
		/// �A�N�Z�X�N���X��؂�ւ���
		/// </summary>
		private void ChangeOtherAcs()
		{
			//�A�N�Z�X�N���X���Ⴄ�̂ɂ���
			this.addressAcs.SetNextAcs();
			
			if( this.addressAcs.DisplayGridCount == 3 )
			{
				this.SetPostNumberAcsModeUI();
			}
			else if( this.addressAcs.DisplayGridCount == 5 )
			{
				this.SetOfferAddressInfoAcsModeUI();
			}
			
			//�f�[�^�̃����[�h������
			if( this.ugIndex1.ActiveRow != null )
			{
				int index = this.ugIndex1.ActiveRow.Index;

				this.ugIndex1.ActiveRow = null;
				
				this.ugIndex1.Rows[index].Activate();
			}
			
		}
		
		#endregion
		
		/// <summary>
		/// �Z�����̂̌����{�^���������ꂽ�Ƃ��̏���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			//�L�[���[�h�����_�C�A���O�쐬
			KeyWordSearchWindow kwsw = new KeyWordSearchWindow( this.addressAcs, this.teKeyword.Text, (int)this.areaGroupTComboEditor.Value);

            try
            {
                this.ulStatusBar.Focus();

                //�m��ȊO�������ꂽ�Ƃ��̏���
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
			
			//�m�艟���ꂽ���I������Ă��Ȃ��ꍇ
			if( ( awSelected = kwsw.GetResult() ) == null )
			{
				return;
			}
			
			this.addressWorkResult = awSelected;
			
			//���̑��̊m��{�^�������������Ƃɂ���B
			this.PerformOkClick();
		}
		
		/// <summary>
		/// �X�֔ԍ������{�^���������ꂽ�Ƃ��̏���
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
			
			//���̑��̊m��{�^�������������Ƃɂ���
			this.PerformOkClick();
		}
		
		#region �O���b�h�̑I���A�C�e�������n�֐�
		
		/// <summary>
		/// �O���b�h�̑I������Ă���A�C�e�����擾����
		/// </summary>
		/// <param name="ugIndex"></param>
		/// <param name="awSelected"></param>
		/// <returns></returns>
		private bool GetSelectedUltraGridItem( UltraGrid ugIndex, out AddressData awSelected )
		{
			//�I������Ă���s���Ȃ����
			if( ugIndex.Selected.Rows.Count <= 0 )
			{
				awSelected = null;
				return false;
			}
			
			awSelected = (AddressData)( (AddressData)ugIndex.Selected.Rows[0].Cells["�n�於��"].OriginalValue ).Clone();
			return true;
		}
		
		/// <summary>
		/// �w��UltraGrid�̎w��s��I������
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
			
			awSelected = (AddressData)( (AddressData)ugIndex.Rows[0].Cells["�n�於��"].OriginalValue ).Clone();
			return true;
		}
		
		#endregion
		
		#region �O���b�h���I�����ꂽ�Ƃ��̏����֐�

        /// <summary>
        /// �O���b�h�̌����ڐݒ�
        /// </summary>
        /// <param name="grid"></param>
        private void SetGridVisual(UltraGrid grid)
        {
            grid.DisplayLayout.Bands[0].Columns["�f�[�^"].Hidden = true;
            grid.DisplayLayout.Bands[0].Columns["�A���R�[�h"].Hidden = true;
            grid.DisplayLayout.Bands[0].ColHeadersVisible = false;
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
        }

		/// <summary>
		/// �w��̒n��O���[�v�R�[�h����Ԃ牺����Z���C���f�b�N�X�}�X�^�P
		/// �������ăO���b�h�ɓ����B�I���ʒu�����f
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

            //�����擾
			if( AddressInfoAreaGroupCacheAcs.GetAreaGroupPref( this.AreaGroupCodeSelected, out alIndexMaster1 ) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return;
			}
			
            this.ugIndex1.DataSource = null;

			foreach( AreaGroup aw in alIndexMaster1 )
			{
				DataRow dr = dtIndex1.NewRow();
				dr["�n�於��"] = aw.AreaName;
				dr["�f�[�^"] = aw;
				dr["�A���R�[�h"] = aw.AreaCode;
				dtIndex1.Rows.Add( dr );
			}

            this.ugIndex1.DataSource = dtIndex1;
            this.ugIndex1.UpdateData();
            this.SetGridVisual(this.ugIndex1);

            //�w��ʒu��I��
			for( int i = 0 ; i < ugIndex1.Rows.Count ; i++ )
			{
				if( ((AreaGroup)ugIndex1.Rows[i].Cells["�f�[�^"].Value).AreaCode == intAddrConnectCd1 )
				{
                    ugIndex1.Rows[i].Activate();
                    this.teIndex1.Text = (string)ugIndex1.Rows[i].Cells["�n�於��"].Value;
					
					break;
				}
			}
			
		}

		/// <summary>
		/// �w��̏Z���}�X�^����Y������Z���C���f�b�N�X�}�X�^�Q�������ă��X�g�{�b�N�X�ɕ\��
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
            
            //�Z���C���f�b�N�X�}�X�^2�擾
			if( this.addressAcs.GetAddrIndexWork2( intAddrConnectCd1, out alIndexMaster2 ) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return;
			}

            //�A�N�e�B�u�ȗ񂪕\���̈���ɓ���悤�Ƀf�[�^�\�[�X��؂藣��
            this.ugIndex2.DataSource = null;

			foreach( AddressData aw in alIndexMaster2 )
			{
				DataRow dr = dtIndex2.NewRow();
				dr["�n�於��"] = aw.DivAddress2;
				dr["�f�[�^"] = aw;
				dr["�A���R�[�h"] = aw.AddrConnectCd2;
				dtIndex2.Rows.Add( dr );
			}

            this.ugIndex2.DataSource = dtIndex2;
            this.ugIndex2.UpdateData();
            this.SetGridVisual(this.ugIndex2);

			//�w��ʒu��I��
			for( int i = 0 ; i < ugIndex2.Rows.Count ; i++ )
			{
				if( ((AddressData)ugIndex2.Rows[i].Cells["�f�[�^"].Value).AddrConnectCd2 == intAddrConnectCd2 )
				{
                    //�I��
					this.ugIndex2.Rows[i].Activate();
                    this.teIndex2.Text = (string)ugIndex2.Rows[i].Cells["�n�於��"].Value;
					
					break;
				}
			}
			
		}
		
		
		/// <summary>
		/// �w��̏Z���}�X�^����Y������Z���C���f�b�N�X�}�X�^�R�������ă��X�g�{�b�N�X�ɕ\��
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

            //�Z���C���f�b�N�X�}�X�^2�擾
			if( this.addressAcs.GetAddrIndexWork3( intAddrConnectCd1, intAddrConnectCd2, out alIndexMaster3 ) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return;
			}
			
            this.ugIndex3.DataSource = null;

			foreach( AddressData aw in alIndexMaster3 )
			{
				DataRow dr = dtIndex3.NewRow();
				dr["�n�於��"] = aw.DivAddress3;
				dr["�f�[�^"] = aw;
				dr["�A���R�[�h"] = aw.AddrConnectCd3;
				dtIndex3.Rows.Add( dr );
			}

            this.ugIndex3.DataSource = dtIndex3;
            this.ugIndex3.UpdateData();
            this.SetGridVisual(this.ugIndex3);

            //�w��ʒu��I��
			for( int i = 0 ; i < ugIndex3.Rows.Count ; i++ )
			{
				if( ((AddressData)ugIndex3.Rows[i].Cells["�f�[�^"].Value).AddrConnectCd3 == intAddrConnectCd3 )
				{
                    //�I��
					this.ugIndex3.Rows[i].Activate();
                    this.teIndex3.Text = (string)ugIndex3.Rows[i].Cells["�n�於��"].Value;
					
					break;
				}
			}
			
		}
		
		/// <summary>
		/// �w��̏Z���}�X�^����Y������Z���C���f�b�N�X�}�X�^�S�������ă��X�g�{�b�N�X�ɕ\��
		/// </summary>
		private void setSelectedAddrIndexWork4( int intAddrConnectCd1, long intAddrConnectCd2, int intAddrConnectCd3, int intAddrConnectCd4 )
		{
			ArrayList alIndexMaster4;

            this.teIndex4.Text = "";
            this.teIndex5.Text = "";

            this.dtIndex4.Rows.Clear();
            this.dtIndex5.Rows.Clear();

            //�Z���C���f�b�N�X�}�X�^2�擾
			if( this.addressAcs.GetAddrIndexWork4( intAddrConnectCd1, intAddrConnectCd2, intAddrConnectCd3, out alIndexMaster4 ) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return;
			}
			
            this.ugIndex4.DataSource = null;

			foreach( AddressData aw in alIndexMaster4 )
			{
				DataRow dr = dtIndex4.NewRow();
				dr["�n�於��"] = aw.DivAddress4;
				dr["�f�[�^"] = aw;
				dr["�A���R�[�h"] = aw.AddrConnectCd4;
				dtIndex4.Rows.Add( dr );
			}

            this.ugIndex4.DataSource = dtIndex4;
            this.ugIndex4.UpdateData();
            this.SetGridVisual(this.ugIndex4);

			//�w��ʒu��I��
			for( int i = 0 ; i < ugIndex4.Rows.Count ; i++ )
			{
				if( ((AddressData)ugIndex4.Rows[i].Cells["�f�[�^"].Value).AddrConnectCd4 == intAddrConnectCd4 )
				{
                    //�I��
					this.ugIndex4.Rows[i].Activate();
                    this.teIndex4.Text = (string)ugIndex4.Rows[i].Cells["�n�於��"].Value;

					break;
				}
			}
			
		}
		
		/// <summary>
		/// �w��̏Z���}�X�^����Y������Z���C���f�b�N�X�}�X�^�T�������ă��X�g�{�b�N�X�ɕ\��
		/// </summary>
		private void setSelectedAddrIndexWork5( int intAddrConnectCd1, long intAddrConnectCd2, int intAddrConnectCd3, int intAddrConnectCd4, int intAddrConnectCd5 )
		{
			ArrayList alIndexMaster5;

            this.teIndex5.Text = "";

            this.dtIndex5.Rows.Clear();

            //�Z���C���f�b�N�X�}�X�^5�擾
			if( this.addressAcs.GetAddrIndexWork5( intAddrConnectCd1, intAddrConnectCd2, intAddrConnectCd3, intAddrConnectCd4, out alIndexMaster5 ) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return;
			}
			
            this.ugIndex5.DataSource = null;

			foreach( AddressData aw in alIndexMaster5 )
			{
				DataRow dr = dtIndex5.NewRow();
				dr["�n�於��"] = aw.DivAddress5;
				dr["�f�[�^"] = aw;
				dr["�A���R�[�h"] = aw.AddrConnectCd5;
				dtIndex5.Rows.Add( dr );
			}

            this.ugIndex5.DataSource = dtIndex5;
            this.ugIndex5.UpdateData();

            this.SetGridVisual(this.ugIndex5);

			//�w��ʒu��I��
			for( int i = 0 ; i < ugIndex5.Rows.Count ; i++ )
			{
				if( ((AddressData)ugIndex5.Rows[i].Cells["�f�[�^"].Value).AddrConnectCd5 == intAddrConnectCd5 )
				{
					//�I��
					this.ugIndex5.Rows[i].Activate();
                    this.teIndex5.Text = (string)ugIndex5.Rows[i].Cells["�n�於��"].Value;
					break;
				}
			}
			
		}
		
		/// <summary>
		/// �w��O���b�h�̒n�於�̂Ƀ}�b�`�������A�N�e�B�u�ɂ���
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
					if( ( ugIndex.Rows[i].Cells["�n�於��"].Value ).ToString().IndexOf(keyword) >= 0 )
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
		/// �G���^�[�Ńt�H�[�J�X���ς���ꂽ�Ƃ��̃C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			
			TEdit te;
			UltraButton ub;
			UltraGrid ugSender;
			
			//�G���^�[�L�[�ȊO�Ńt�H�[�J�X���ς�����Ƃ��͉������Ȃ�
			if( e.Key != System.Windows.Forms.Keys.Enter )
			{
				return;
			}
			
			if( ( te = e.PrevCtrl as TEdit ) != null )
			{
				//�L�[���[�h���͗p�e�L�X�g�{�b�N�X�ŃL�[���[�h�����͂���Ă���Ȃ�
				if( te.Name == "teKeyword" )
				{
					if( te.Text != "" )
					{
						this.ubSearch.PerformClick();
						//�t�H�[�J�X�ړ�����
						e.NextCtrl = null;
					}
				}
				else if( te.Name == "tePostNoKeyword" )
				{
					if( te.Text != "" )
					{
						this.ubPostNoSearch.PerformClick();
						//�t�H�[�J�X�ړ�����
						e.NextCtrl = null;
					}
				}
				else
				{
					//�e�L�X�g�{�b�N�X�ɕ����������Ă��Ȃ�������Ȃɂ����Ȃ�
					if( te.Text == "" )
					{
						return;
					}
				
					//�L�[���[�h�Ƀ}�b�`����A�C�e����I��������
					if( this.SelectKeyWordMatchItem( (UltraGrid)te.Tag, te.Text ) < 0 )
					{
						te.Text = "";
					}
				}

			}
				//�L�[���[�h�����{�^���̏ꍇ
				//�L�[���[�h������Ό����{�^�������������Ƃɂ���
			else if( ( ub = e.PrevCtrl as UltraButton ) != null )
			{
				if(ub.Name == "ubSearch" && this.teKeyword.Text != "")
				{
					this.ubSearch.PerformClick();
					//�t�H�[�J�X�ړ�����
					e.NextCtrl = null;
				}
			}
			
				//UltraGrid�ŃG���^�[�����ꂽ��m��{�^���������ꂽ���Ƃɂ���
			else if( ( ugSender = e.PrevCtrl as UltraGrid ) != null )
			{

				//�����_�u���N���b�N���ꂽ�O���b�h�����S�ȏZ�����������Ă����ꍇ�͂�������ʂƂ���
				if( ugSender == this.ugIndex2 
                    && ugSender.ActiveRow != null
					&& ((AddressData)ugSender.ActiveRow.Cells["�f�[�^"].Value).AddrConnectCd2 != 0 
					&& ((AddressData)ugSender.ActiveRow.Cells["�f�[�^"].Value).AddrConnectCd3 == 0 )
				{
					this.addressWorkResult = ugSender.ActiveRow.Cells["�f�[�^"].Value as AddressData;
				}
				else if( ugSender == this.ugIndex3
                    && ugSender.ActiveRow != null
                    && ((AddressData)ugSender.ActiveRow.Cells["�f�[�^"].Value).AddrConnectCd3 != 0 
					&& ((AddressData)ugSender.ActiveRow.Cells["�f�[�^"].Value).AddrConnectCd4 == 0 )
				{
					this.addressWorkResult = ugSender.ActiveRow.Cells["�f�[�^"].Value as AddressData;
				}
				else if( ugSender == this.ugIndex4
                    && ugSender.ActiveRow != null
                    && ((AddressData)ugSender.ActiveRow.Cells["�f�[�^"].Value).AddrConnectCd4 != 0 
					&& ((AddressData)ugSender.ActiveRow.Cells["�f�[�^"].Value).AddrConnectCd5 == 0 )
				{
					this.addressWorkResult = ugSender.ActiveRow.Cells["�f�[�^"].Value as AddressData;
				}
				else if( ugSender == this.ugIndex5
                    && ugSender.ActiveRow != null)
				{
					this.addressWorkResult = ugSender.ActiveRow.Cells["�f�[�^"].Value as AddressData;
				}
				
				//�����I�΂�Ă��Ȃ��Ȃ�߂�
				if( addressWorkResult == null )
				{
					return;
				}
				
				//�����X�֔ԍ����������ꍇ�I�΂���
				if( this.SelectPostNo() != DialogResult.OK )
				{
					return;
				}
				
				this.PerformOkClick();
			}
			
		}
		
		#region �c�[���o�[�̃{�^���������ꂽ�Ƃ��̃C�x���g
		
		//�c�[���o�[�̃{�^�����N���b�N���ꂽ�Ƃ��̏���
		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch( e.Tool.CaptionResolved )
			{
				
				case "�ǋ�(&G)":
					this.PerformAreaGroupClick();
					break;
					
				case "�m��(&S)":
					this.PerformOkClick();
					break;
					
				case "�߂�(&C)":
					this.PerformCancelClick();
					break;
					
				case "�ʂ̏Z�����(&O)":

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
		
		#region �{�^���������ꂽ�Ƃ��̏���
		
		AddressData addressWorkResult = null;
		
		/// <summary>
		/// ���ʂ��擾���郁�\�b�h
		/// </summary>
		/// <returns></returns>
		public AddressData GetResult()
		{
			return this.addressWorkResult;
		}
		
		/// <summary>
		/// �ǋ�{�^���������ꂽ�Ƃ��̏���
		/// </summary>
		public void PerformAreaGroupClick()
		{
			//���[�h���Ɋǋ�{�^����������Ă�������
            //if( this.addressAcs.NowLoading )
            //{
            //    return;
            //}
			
			AreaGroupWindow agDialog;

			//�f�t�H���g�I��n��O���[�v�R�[�h���w�肵�Ċǋ�I�𑋍쐬
			agDialog = new AreaGroupWindow( this.AreaGroupCodeSelected );

            try
            {
                this.ulStatusBar.Focus();

                //�ǋ�I�𑋂Ŋm��{�^���ȊO�������ꂽ�Ƃ�
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
			//�m��{�^���������ꂽ�������I������ĂȂ������ꍇ
			if( agResult == null )
			{
				return;
			}
			
			//�����ǋ悪�I������Ă�����
			if( agResult.AreaGroupCode == this.AreaGroupCodeSelected )
			{
				return;
			}

            List<AreaGroup> alTmp = null;
			
			//���擾
			AddressInfoAreaGroupCacheAcs.GetAreaGroupPref( agResult.AreaGroupCode, out alTmp );
			
			//���̏�񂪂ЂƂ��擾�ł��Ȃ������ꍇ
			if( alTmp == null || alTmp.Count <= 0 )
			{
				return;
			}
			
			//�I������Ă���n��O���[�v�R�[�h��ύX
			this.AreaGroupCodeSelected = agResult.AreaGroupCode;
			
            //Ime���[�h�ޔ�
            this.ulStatusBar.Focus();

			this.WaitWindowShow();

            try
            {
                this.setSelectedAddrIndexWork1(0);

                if (this.dtIndex1.Rows.Count > 0)
                {
                    ArrayList alTmp2;
                    this.addressAcs.GetAddrIndexWork2((int)this.dtIndex1.Rows[0]["�A���R�[�h"], out alTmp2);
                }
            }
            finally
            {
                this.WaitWindowClose();

                this.teKeyword.Focus();
            }

            //�ǋ�̃R���{�{�b�N�X�Ɍ��ݑI������Ă���ǋ�𔽉f����
            this.areaGroupTComboEditor.Value = this.AreaGroupCodeSelected;

            //�ǋ�̃��x���ɂ����f
            this.areaGroupLabel.Text = this.areaGroupTComboEditor.SelectedItem.DisplayText;
		}
		
		/// <summary>
		/// �����X�֔ԍ����������Ƃ��I�΂���
		/// </summary>
        private DialogResult SelectPostNo()
        {
            //�����ŕ����X�֔ԍ��I����������
            //�Z���}�X�^����f�[�^���擾�����ꍇ�݂̂��
            if (this.addressWorkResult != null &&
                (this.addressWorkResult.AddressCode1Lower != 0
                || this.addressWorkResult.AddressCode1Upper != 0
                || this.addressWorkResult.AddressCode2 != 0
                || this.addressWorkResult.AddressCode3 != 0))
            {
                //�Z���R�[�h������ꍇ�i�Z���}�X�^����f�[�^�擾�j
                ArrayList alTmp = new ArrayList();

                int status = this.addressAcs.GetAddressWork(
                    this.addressWorkResult.AddrConnectCd1,
                    this.addressWorkResult.AddrConnectCd2,
                    this.addressWorkResult.AddrConnectCd3,
                    this.addressWorkResult.AddrConnectCd4,
                    this.addressWorkResult.AddrConnectCd5,
                    out alTmp);

                //��������ꍇ
                if (alTmp != null && alTmp.Count > 1)
                {
                    PostNoSelectWindow posWin = new PostNoSelectWindow(alTmp);

                    try
                    {
                        this.ulStatusBar.Focus();

                        //�I�𑋂��L�����Z�����ꂽ��߂�
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

                    //�Ȃɂ��I�΂�ĂȂ��Ȃ�߂�
                    if (this.addressWorkResult == null)
                    {
                        return DialogResult.Cancel;
                    }

                }

            }

            return DialogResult.OK;
        }
		
		//�m�肪�����ꂽ���Ƃɂ���
		public void PerformOkClick()
		{
			//���ʂ��ݒ肳��Ă��Ȃ��ꍇ�͌��ʂ�ݒ�
			//���łɐݒ肳��Ă���ꍇ�͂����D�悷��
			if( this.addressWorkResult == null )
			{
				//�����ɗ���̂̓O���b�h�őI�����ꂽ�Ƃ�
				//���ʎ擾����
				if( this.ugIndex5.ActiveRow != null )
				{
					this.addressWorkResult = this.ugIndex5.ActiveRow.Cells["�f�[�^"].Value as AddressData;
				}
				else if( this.ugIndex4.ActiveRow != null )
				{
					this.addressWorkResult = this.ugIndex4.ActiveRow.Cells["�f�[�^"].Value as AddressData;
				}
				else if( this.ugIndex3.ActiveRow != null )
				{
					this.addressWorkResult = this.ugIndex3.ActiveRow.Cells["�f�[�^"].Value as AddressData;
				}
				else if( this.ugIndex2.ActiveRow != null )
				{
					this.addressWorkResult = this.ugIndex2.ActiveRow.Cells["�f�[�^"].Value as AddressData;
				}
				
				//�����X�֔ԍ����������ꍇ�I�΂���
				if( this.SelectPostNo() != DialogResult.OK )
				{
					return;
				}
			}
			
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		
		//�������������ꂽ���Ƃɂ���
		public void PerformCancelClick()
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		#endregion

        #region ���҂����������E�C���h�E���\�b�h

        private SFCMN00299CA waitWindow = null;

        /// <summary>
        /// ���҂������������\���֐�
        /// </summary>
        private void WaitWindowShow()
        {
            //���������ꍇ
            if (this.waitWindow == null)
            {
                this.waitWindow = new SFCMN00299CA();
                this.waitWindow.DispCancelButton = false;
                this.waitWindow.Message = "�Z�������擾���Ă��܂��B";
                this.waitWindow.Title = "�Z�����擾";
            }

            this.Refresh();
            waitWindow.Show(this);
            this.Refresh();
        }

        /// <summary>
        /// ���҂���������������֐�
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
		/// ���̃E�B���h�E�����[�h���ꂽ�Ƃ��̏���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddressGuideWindow_Load(object sender, System.EventArgs e)
		{
            //�E�B���h�E�̓s����Shown�Ɉړ�
            ////���҂������������쐬
            //this.WaitWindowShow();
            
            //try
            //{
            //    this.setSelectedAddrIndexWork1(this.AddrConnectCd1Def);
            //}
            //finally
            //{
            //    //���҂����������������
            //    this.WaitWindowClose();
            //}
		}
		
		#region �O���b�h�̃C�x���g

        /// <summary>
        /// �w��ʒu�̃Z�����擾����
        /// �Z���ȊO��������null��Ԃ�
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

            // �w�b�_���̏ꍇ�͈ȉ��̏������L�����Z�����܂��B
            if (objRowCellAreaUIElement == null)
            {
                return null;
            }

            UltraGridCell ugCell;

            //�N���b�N�����������񂶂�Ȃ������ꍇ
            if ((ugCell = objElement.GetContext(typeof(UltraGridCell)) as UltraGridCell) == null)
            {
                return null;
            }

            return ugCell;
        }

		//�O���b�h���_�u���N���b�N���ꂽ�Ƃ��̏���
		private void ugIndex1_DoubleClick(object sender, System.EventArgs e)
		{
			UltraGrid ugSender = sender as UltraGrid;

            if (GetCell(Cursor.Position, ugSender) == null)
            {
                return;
            }
			
			//�����_�u���N���b�N���ꂽ�O���b�h�����S�ȏZ�����������Ă����ꍇ�͂�������ʂƂ���
			if( ugSender == this.ugIndex2 
				&& ((AddressData)ugSender.ActiveRow.Cells["�f�[�^"].Value).AddrConnectCd2 != 0 
				&& ((AddressData)ugSender.ActiveRow.Cells["�f�[�^"].Value).AddrConnectCd3 == 0 )
			{
				this.addressWorkResult = ugSender.ActiveRow.Cells["�f�[�^"].Value as AddressData;
			}
			else if( ugSender == this.ugIndex3 
				&& ((AddressData)ugSender.ActiveRow.Cells["�f�[�^"].Value).AddrConnectCd3 != 0 
				&& ((AddressData)ugSender.ActiveRow.Cells["�f�[�^"].Value).AddrConnectCd4 == 0 )
			{
				this.addressWorkResult = ugSender.ActiveRow.Cells["�f�[�^"].Value as AddressData;
			}
			else if( ugSender == this.ugIndex4 
				&& ((AddressData)ugSender.ActiveRow.Cells["�f�[�^"].Value).AddrConnectCd4 != 0 
				&& ((AddressData)ugSender.ActiveRow.Cells["�f�[�^"].Value).AddrConnectCd5 == 0 )
			{
				this.addressWorkResult = ugSender.ActiveRow.Cells["�f�[�^"].Value as AddressData;
			}
			else if( ugSender == this.ugIndex5 )
			{
				this.addressWorkResult = ugSender.ActiveRow.Cells["�f�[�^"].Value as AddressData;
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
		/// ���̃O���b�h���A�N�e�B�u�ɂȂ����Ƃ��̏���
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
			this.teIndex1.Text = (string)this.ugIndex1.ActiveRow.Cells["�n�於��"].Value;
			
			AreaGroup agSelect = this.ugIndex1.ActiveRow.Cells["�f�[�^"].Value as AreaGroup;
			
			if( this.AddressIndex2Init )
			{
				this.setSelectedAddrIndexWork2( agSelect.AreaCode, 0 );
			}
			else
			{
				//�����ʒu��^����
				this.setSelectedAddrIndexWork2( agSelect.AreaCode, this.AddrConnectCd2Def );
				this.AddressIndex2Init = true;
			}
		}
		
		/// <summary>
		/// 2�Ԗڂ̃O���b�h�̗񂪃A�N�e�B�u�ɂȂ����Ƃ��̏���
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
			this.teIndex2.Text = (string)this.ugIndex2.ActiveRow.Cells["�n�於��"].Value;
			
			AddressData awSelect = this.ugIndex2.ActiveRow.Cells["�f�[�^"].Value as AddressData;
			
			if( this.AddressIndex3Init )
			{
				this.setSelectedAddrIndexWork3( awSelect.AddrConnectCd1, awSelect.AddrConnectCd2, 0 );
			}
			else
			{
				//�����ʒu��^����
				this.setSelectedAddrIndexWork3( awSelect.AddrConnectCd1, awSelect.AddrConnectCd2, this.AddrConnectCd3Def );
				this.AddressIndex3Init = true;
			}
		}
		
		/// <summary>
		/// �R�Ԗڂ̃O���b�h�̗񂪃A�N�e�B�u�ɂȂ����Ƃ��̏���
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
			this.teIndex3.Text = (string)this.ugIndex3.ActiveRow.Cells["�n�於��"].Value;
			
			AddressData awSelect = this.ugIndex3.ActiveRow.Cells["�f�[�^"].Value as AddressData;
			
			if( this.AddressIndex4Init )
			{
				this.setSelectedAddrIndexWork4( awSelect.AddrConnectCd1, awSelect.AddrConnectCd2, awSelect.AddrConnectCd3, 0 );
			}
			else
			{
				//�����ʒu��^����
				this.setSelectedAddrIndexWork4( awSelect.AddrConnectCd1, awSelect.AddrConnectCd2, awSelect.AddrConnectCd3, this.AddrConnectCd4Def );
				this.AddressIndex4Init = true;
			}
		}
		
		/// <summary>
		/// �S�Ԗڂ̃O���b�h�̗񂪃A�N�e�B�u�ɂȂ����Ƃ��̏���
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
			this.teIndex4.Text = (string)this.ugIndex4.ActiveRow.Cells["�n�於��"].Value;
			
			AddressData awSelect = this.ugIndex4.ActiveRow.Cells["�f�[�^"].Value as AddressData;
			
			if( this.AddressIndex5Init )
			{
				this.setSelectedAddrIndexWork5( awSelect.AddrConnectCd1, awSelect.AddrConnectCd2, awSelect.AddrConnectCd3, awSelect.AddrConnectCd4, 0 );
			}
			else
			{
				//�����ʒu��^����
				this.setSelectedAddrIndexWork5( awSelect.AddrConnectCd1, awSelect.AddrConnectCd2, awSelect.AddrConnectCd3, awSelect.AddrConnectCd4, this.AddrConnectCd5Def );
				this.AddressIndex5Init = true;
			}
		}
		
		/// <summary>
		/// 5�Ԗڂ̃O���b�h�̗񂪃A�N�e�B�u�ɂȂ����Ƃ��̏���
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
			this.teIndex5.Text = (string)this.ugIndex5.ActiveRow.Cells["�n�於��"].Value;
			
		}
		
		#endregion
		
		/// <summary>
		/// �X�e�[�^�X�o�[�ɕ�������Z�b�g����B
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
            //���҂������������쐬
            this.WaitWindowShow();

            try
            {
                this.setSelectedAddrIndexWork1(this.AddrConnectCd1Def);
            }
            finally
            {
                //���҂����������������
                this.WaitWindowClose();
            }
            this.ulStatusBar.Focus();
            this.teKeyword.Focus();
        }
				
	}
	
}
