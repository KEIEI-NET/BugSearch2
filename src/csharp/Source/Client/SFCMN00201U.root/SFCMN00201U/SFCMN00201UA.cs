using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Broadleaf.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using System.Reflection;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// Form1 �̊T�v�̐����ł��B
	/// </summary>
    /// <remarks>
    /// <br>Update Note: 2011/08/11 ����� </br>
    /// <br>             NS���[�U�[���Ǘv�]�ꗗ_20110629_1.�D��Č�_�A��9�iredmine#23479�j�ɂ���ĉ��C���s��</br>
    /// </remarks>
	public class TableGuideParent : System.Windows.Forms.Form, IGeneralGuideOperable, IGeneralGuideFocusOperable
	{

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		private System.Windows.Forms.Panel TopPanel;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.Splitter splitter4;
		private System.Windows.Forms.Panel GuidePanel1;
		private System.Windows.Forms.Panel GuidePanel2;
		private System.Windows.Forms.Panel GuidePanel3;
		private System.Windows.Forms.Panel GuidePanel4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ImageList imageList2;
		private System.Windows.Forms.ImageList imageList1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _TableGuideParent_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _TableGuideParent_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _TableGuideParent_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _TableGuideParent_Toolbars_Dock_Area_Bottom;
		private System.ComponentModel.IContainer components;
		#endregion Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 

		private ArrayList _SelectedDataArray;
		private Hashtable _SelectedDataHash;
		private object _ParentSerchInfo = null;
		private bool _ResultStatus = false;
		private string _xPathDocPath = ""; 
		private bool _xPathDocEnable = false;
		private XmlDocument _xmlDoc;
		private int _StyleMode = 0;
		private int _InnerGuide = 0;
		private int _InnerGuideWithSetteings = 0;

		private ArrayList _InnerGuideDef;
		private ArrayList _InnerGuideType;  // �q�K�C�h�̃^�C�v
		
		private ArrayList FormArray = null;
		private ArrayList InterFaceArray = null;
		private ArrayList GuideArray = null;
		private ArrayList SplitArray = null;

		private bool _MultiSelect = false;
		private Hashtable _DefaultSetData;  // �K�C�h�\�����̏����I���f�[�^��ێ�
		private ControlScreenSkin _controlScreenSkin;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main; // ADD 2011/08/11

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public TableGuideParent()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

		}
		
		/// <summary>
		/// �R���X�g���N�^(��`�t�@�C���w��)
		/// </summary>
		public TableGuideParent(string definitionFile)
		{
			InitializeComponent();
			_xPathDocPath = definitionFile;
			
			InitForm();
		}

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableGuideParent));
			Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("SelectToolBt");
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("FindToolBt");
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CancelToolBt");
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("ViewerSwMenu");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("SelectToolBt");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("FindToolBt");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CancelToolBt");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("ViewerSwMenu");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool1 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("StateButtonTool1", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool2 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("StateButtonTool1", "");
			this.TopPanel = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.GuidePanel1 = new System.Windows.Forms.Panel();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.GuidePanel2 = new System.Windows.Forms.Panel();
			this.splitter3 = new System.Windows.Forms.Splitter();
			this.GuidePanel3 = new System.Windows.Forms.Panel();
			this.splitter4 = new System.Windows.Forms.Splitter();
			this.GuidePanel4 = new System.Windows.Forms.Panel();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
			this._TableGuideParent_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._TableGuideParent_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._TableGuideParent_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._TableGuideParent_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            // --- ADD 2011/08/11---------->>>>>
            this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar(); 
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance(); 
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            // --- ADD 2011/08/11----------<<<<<
            this.TopPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
			this.SuspendLayout();
			// 
			// TopPanel
			// 
			this.TopPanel.Controls.Add(this.button1);
			this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPanel.Location = new System.Drawing.Point(0, 27);
			this.TopPanel.Name = "TopPanel";
			this.TopPanel.Size = new System.Drawing.Size(848, 20);
			this.TopPanel.TabIndex = 0;
			this.TopPanel.Visible = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 47);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(848, 3);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// GuidePanel1
			// 
			this.GuidePanel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.GuidePanel1.Location = new System.Drawing.Point(0, 50);
			this.GuidePanel1.Name = "GuidePanel1";
			this.GuidePanel1.Size = new System.Drawing.Size(200, 543);
			this.GuidePanel1.TabIndex = 2;
			// 
			// splitter2
			// 
			this.splitter2.Location = new System.Drawing.Point(200, 50);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(3, 543);
			this.splitter2.TabIndex = 3;
			this.splitter2.TabStop = false;
			// 
			// GuidePanel2
			// 
			this.GuidePanel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.GuidePanel2.Location = new System.Drawing.Point(203, 50);
			this.GuidePanel2.Name = "GuidePanel2";
			this.GuidePanel2.Size = new System.Drawing.Size(200, 543);
			this.GuidePanel2.TabIndex = 4;
			// 
			// splitter3
			// 
			this.splitter3.Location = new System.Drawing.Point(403, 50);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new System.Drawing.Size(3, 543);
			this.splitter3.TabIndex = 5;
			this.splitter3.TabStop = false;
			// 
			// GuidePanel3
			// 
			this.GuidePanel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.GuidePanel3.Location = new System.Drawing.Point(406, 50);
			this.GuidePanel3.Name = "GuidePanel3";
			this.GuidePanel3.Size = new System.Drawing.Size(200, 543);
			this.GuidePanel3.TabIndex = 6;
			// 
			// splitter4
			// 
			this.splitter4.Location = new System.Drawing.Point(606, 50);
			this.splitter4.Name = "splitter4";
			this.splitter4.Size = new System.Drawing.Size(3, 543);
			this.splitter4.TabIndex = 7;
			this.splitter4.TabStop = false;
			// 
			// GuidePanel4
			// 
			this.GuidePanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GuidePanel4.Location = new System.Drawing.Point(609, 50);
			this.GuidePanel4.Name = "GuidePanel4";
			this.GuidePanel4.Size = new System.Drawing.Size(239, 543);
			this.GuidePanel4.TabIndex = 8;
			// 
			// imageList2
			// 
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList2.Images.SetKeyName(0, "");
			this.imageList2.Images.SetKeyName(1, "");
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			this.imageList1.Images.SetKeyName(1, "");
			this.imageList1.Images.SetKeyName(2, "");
			// 
			// ultraToolbarsManager1
			// 
			this.ultraToolbarsManager1.DesignerFlags = 1;
			this.ultraToolbarsManager1.DockWithinContainer = this;
			this.ultraToolbarsManager1.ImageTransparentColor = System.Drawing.Color.White;
			this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
			ultraToolbar1.DockedColumn = 0;
			ultraToolbar1.DockedRow = 0;
			ultraToolbar1.Settings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
			appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
			buttonTool1.InstanceProps.AppearancesSmall.Appearance = appearance1;
			appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
			buttonTool2.InstanceProps.AppearancesSmall.Appearance = appearance2;
			appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
			buttonTool3.InstanceProps.AppearancesSmall.Appearance = appearance3;
			popupMenuTool1.InstanceProps.Caption = "�\���ؑ�(&�u)";
			popupMenuTool1.InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False;
			ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            popupMenuTool1});
			this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
			buttonTool4.SharedProps.Caption = "�I��(&S)";
			buttonTool4.SharedProps.CustomizerCaption = "�I��(&S)";
			buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool5.SharedProps.Caption = "����(&F)";
			buttonTool5.SharedProps.CustomizerCaption = "����(&F)";
			buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool5.SharedProps.Visible = false;
			buttonTool6.SharedProps.Caption = "�߂�(&X)";
			buttonTool6.SharedProps.CustomizerCaption = "�߂�(&X)";
			buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			popupMenuTool2.SharedProps.Caption = "viewerSwMenu";
			popupMenuTool2.SharedProps.CustomizerCaption = "�\���ؑ�(&V)";
			popupMenuTool2.SharedProps.Enabled = false;
			popupMenuTool2.SharedProps.Visible = false;
			popupMenuTool2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            stateButtonTool1});
			stateButtonTool2.SharedProps.Caption = "StateButtonTool1";
			this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5,
            buttonTool6,
            popupMenuTool2,
            stateButtonTool2});
			this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
			// 
			// _TableGuideParent_Toolbars_Dock_Area_Left
			// 
			this._TableGuideParent_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._TableGuideParent_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._TableGuideParent_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
			this._TableGuideParent_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
			this._TableGuideParent_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 27);
			this._TableGuideParent_Toolbars_Dock_Area_Left.Name = "_TableGuideParent_Toolbars_Dock_Area_Left";
			this._TableGuideParent_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 566);
			this._TableGuideParent_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _TableGuideParent_Toolbars_Dock_Area_Right
			// 
			this._TableGuideParent_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._TableGuideParent_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._TableGuideParent_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
			this._TableGuideParent_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
			this._TableGuideParent_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(848, 27);
			this._TableGuideParent_Toolbars_Dock_Area_Right.Name = "_TableGuideParent_Toolbars_Dock_Area_Right";
			this._TableGuideParent_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 566);
			this._TableGuideParent_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _TableGuideParent_Toolbars_Dock_Area_Top
			// 
			this._TableGuideParent_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._TableGuideParent_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._TableGuideParent_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
			this._TableGuideParent_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
			this._TableGuideParent_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
			this._TableGuideParent_Toolbars_Dock_Area_Top.Name = "_TableGuideParent_Toolbars_Dock_Area_Top";
			this._TableGuideParent_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(848, 27);
			this._TableGuideParent_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _TableGuideParent_Toolbars_Dock_Area_Bottom
			// 
			this._TableGuideParent_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._TableGuideParent_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._TableGuideParent_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
			this._TableGuideParent_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this._TableGuideParent_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 593);
			this._TableGuideParent_Toolbars_Dock_Area_Bottom.Name = "_TableGuideParent_Toolbars_Dock_Area_Bottom";
			this._TableGuideParent_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(848, 0);
			this._TableGuideParent_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // --- ADD 2011/08/11---------->>>>>
            // 
            // uStatusBar_Main
            // 
            this.uStatusBar_Main.Location = new System.Drawing.Point(0, 567);
            this.uStatusBar_Main.Name = "uStatusBar_Main";
            appearance37.FontData.SizeInPoints = 10F;
            appearance37.FontData.Name = "�l�r �S�V�b�N";
            ultraStatusPanel1.Appearance = appearance37;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "StatusBarPanel_Text";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel1.Text = "F3�F�����ݒ�  F6�F�i��  ESC�F�I��";
            this.uStatusBar_Main.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1});
            this.uStatusBar_Main.Size = new System.Drawing.Size(848, 26);
            this.uStatusBar_Main.TabIndex = 54;
            this.uStatusBar_Main.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // --- ADD 2011/08/11----------<<<<<
            // 
            // TableGuideParent
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(848, 593);
            this.Controls.Add(this.GuidePanel4);
            this.Controls.Add(this.splitter4);
            this.Controls.Add(this.GuidePanel3);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.GuidePanel2);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.GuidePanel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this._TableGuideParent_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._TableGuideParent_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._TableGuideParent_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._TableGuideParent_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.uStatusBar_Main);  // ADD 2011/08/11
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Name = "TableGuideParent";
			this.Text = "Form1";
			this.SizeChanged += new System.EventHandler(this.TableGuideParent_SizeChanged);
			this.Enter += new System.EventHandler(this.TableGuideParent_Enter);
			this.Activated += new System.EventHandler(this.TableGuideParent_Activated);
			this.Load += new System.EventHandler(this.Form1_Load);
            this.uStatusBar_Main.ResumeLayout(false); // ADD 2011/08/11
			this.TopPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new TableGuideParent());
		}

		/// <summary>
		/// �t�H�[������������
		/// </summary>
		/// <returns>����</returns>
		/// <remarks>
		/// <br>Note       : �K�C�h�����ɕK�v�ȏ����������s���܂�</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.03.19</br>
        /// <br>Update Note: 2011/08/11 �����</br>
        /// <br>             NS���[�U�[���Ǘv�]�ꗗ_20110629_1.�D��Č�_�A��9�iredmine#23479�j�ɂ���ĉ��C���s��</br>
		/// </remarks>
		private void InitForm()
		{

            ultraToolbarsManager1.Toolbars[0].Tools[0].InstanceProps.AppearancesSmall.Appearance.Image = Broadleaf.Library.Resources.IconResourceManagement.ImageList16.Images[12];
            ultraToolbarsManager1.Toolbars[0].Tools[1].InstanceProps.AppearancesSmall.Appearance.Image = Broadleaf.Library.Resources.IconResourceManagement.ImageList16.Images[2];
            ultraToolbarsManager1.Toolbars[0].Tools[2].InstanceProps.AppearancesSmall.Appearance.Image = Broadleaf.Library.Resources.IconResourceManagement.ImageList16.Images[17];

			_SelectedDataArray	= new ArrayList();
			_SelectedDataHash	= new Hashtable();
			_InnerGuideDef		= new ArrayList();
			_InnerGuideType     = new ArrayList();  // �q�K�C�h�̃^�C�v
			FormArray           = new ArrayList();
			GuideArray			= new ArrayList();
			SplitArray			= new ArrayList();
			InterFaceArray		= new ArrayList();
			_DefaultSetData     = new Hashtable(); // �K�C�h�\�����̏����I���f�[�^�ݒ�

			if((!(_xPathDocPath == "")) && (!(_xPathDocPath == null))) 

			// �K�C�h�ݒ�t�@�C�����w�肳��Ă���ꍇ
			{
				// �K�C�h�ݒ�t�@�C���̓Ǎ�
				try
				{
					_xmlDoc         = new XmlDocument();
					_xmlDoc.Load(_xPathDocPath);
//					MessageBox.Show(_xPathDocPath);
					_xPathDocEnable = true;
				}
				catch (FileNotFoundException e)
				{
					MessageBox.Show(e.StackTrace);
				}
				catch (XmlException e)
				{
					MessageBox.Show(e.StackTrace);
				}
			
				// �K�C�h�ݒ�t�@�C���̓Ǎ�
				if(_xPathDocEnable)
				{
					#region �t�H�[���S�̂̐ݒ� 

					XmlElement xmlElem  = _xmlDoc.DocumentElement;
					XmlElement xmlElem2;
					int numTmp = 0;
					
					// �t�H�[���^�C�g��
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/FormTitle"); 
					if(!(xmlElem2 == null))
					{
						this.Text = xmlElem2.InnerText;
					}

					// �t�H�[���X�^�C��
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/StyleMode"); 
					if(!(xmlElem2 == null))
					{
						if(xmlElem2.InnerText == "oldpeg") _StyleMode = 1;
					}

					// �t�H�[���\���ʒu
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/StartPosition"); 
					if(!(xmlElem2 == null))
					{
						if(xmlElem2.InnerText == "CenterParent") this.StartPosition = FormStartPosition.CenterParent;
						else if(xmlElem2.InnerText == "Manual") this.StartPosition = FormStartPosition.Manual;
					}

					// �t�H�[���\���ʒuTOP
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/StartPositionTop"); 
					if(!(xmlElem2 == null))
					{
						numTmp = Convert.ToInt32(xmlElem2.InnerText);
						if(numTmp >= 0)
						{
							this.Top   = numTmp;
						}
					}

					// �t�H�[���\���ʒuLEFT
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/StartPositionLeft"); 
					if(!(xmlElem2 == null))
					{
						numTmp = Convert.ToInt32(xmlElem2.InnerText);
						if(numTmp >= 0)
						{
							this.Top	= numTmp;
						}
					}

					#endregion �t�H�[���S�̂̐ݒ� 
				
					#region �q�K�C�h�̐ݒ� 
					XmlNodeList nodeList;

					nodeList = xmlElem.SelectNodes("/definfo/InnerFormDef/InnerGuide");
					if(nodeList[0] != null)
					{
						_InnerGuide = Convert.ToInt32(((XmlNode)nodeList[0]).InnerText); // �q�K�C�h�̐� 
					}

					nodeList = xmlElem.SelectNodes("/definfo/InnerFormDef/InnerGuideWithSettings");
					if(nodeList[0] != null)
					{
						_InnerGuideWithSetteings = Convert.ToInt32(((XmlNode)nodeList[0]).InnerText) - 1; // �K�C�h�ݒ����ێ�����q�K�C�h�̔ԍ� 
					}
					else
					{
						_InnerGuideWithSetteings = -1;
					}

					nodeList = xmlElem.SelectNodes("/definfo/InnerFormDef/InnerGuideDefRoot/InnerGuideDef");
					foreach (XmlNode isbn in nodeList)
					{
						_InnerGuideType.Add(isbn.Attributes["GType"].Value.ToString());

//						if(isbn.Attributes["GSettings"].Value.ToString() != "")
//						{
//							MessageBox.Show(isbn.Attributes["GSettings"].Value.ToString());
//						}
//						MessageBox.Show(isbn.InnerText);
//						MessageBox.Show(isbn.Value.ToString());


						_InnerGuideDef.Add(isbn.InnerText); //InnerText);  // �q�K�C�h�̒�`�t�@�C���p�X
					}

					#endregion �q�K�C�h�̐ݒ� 

					#region �q�K�C�h�̏����Z�b�g�f�[�^�ݒ�(�K�C�h�N�����Ƀf�t�H���g�őI������f�[�^�̒�`) 
				
					XmlNodeList nodeList_Inner;

					nodeList = xmlElem.SelectNodes("/definfo/DefaultSetDataDef/DefaultSetDataRoot/DefaultSetDataTarget");
					int cnt = 0;
					foreach (XmlNode isbn in nodeList)
					{
						
						nodeList_Inner = isbn.ChildNodes;
						string targetGuide = "";
						foreach (XmlNode isbn_Inner in nodeList_Inner)
						{
							if((isbn_Inner.Name.Equals("DefaultData")) && (isbn_Inner.Attributes.Count != 0))
							{
								// �����l�Ƃ��đI������S�Ă̍��ڂƏ����l�̎擾��ID���擾����
								//								MessageBox.Show(isbn_Inner.Attributes["DataSource"].Value.ToString()+"\n"+isbn_Inner.InnerText);
								//								Hashtable ht = new Hashtable();
								//								ht.Add(isbn_Inner.Attributes["DataSource"].Value.ToString(), isbn_Inner.InnerText);
								//								GuideDefaultDataInfo di = new GuideDefaultDataInfo();
								
								if(_DefaultSetData.Contains(targetGuide))
								{
									((ArrayList)_DefaultSetData[targetGuide]).Add(new GuideDefaultDataInfo(isbn_Inner.InnerText, isbn_Inner.Attributes["DataSource"].Value.ToString(), null));
								}
							}
							else
							{
								// �����l���Z�b�g����K�C�h�����擾����
								if(isbn_Inner.Name.Equals("TargetGuide"))
								{
									targetGuide = isbn_Inner.InnerText;
									if(!_DefaultSetData.Contains(targetGuide))
									{
										_DefaultSetData.Add(targetGuide, new ArrayList());
									}
								}
							}
						}

					}

					#endregion �q�K�C�h�̏����Z�b�g�f�[�^�ݒ�
				}
			}

			GuideArray.Add(GuidePanel1);
			GuideArray.Add(GuidePanel2);
			GuideArray.Add(GuidePanel3);
			GuideArray.Add(GuidePanel4);
			
			SplitArray.Add(splitter1);
			SplitArray.Add(splitter2);
			SplitArray.Add(splitter3);
			SplitArray.Add(splitter4);

			for(int idx=0; idx < _InnerGuide; idx++)
			{
				string gType = _InnerGuideType[idx].ToString().Trim();		
				if(gType.Equals("TableGuide"))
				{
					FormArray.Add(new TableGuide((string)_InnerGuideDef[idx],0,5));
					InterFaceArray.Add(((TableGuide)FormArray[idx]) as IGeneralChildGuide);
				}
				else if(gType.Equals("ViewerGuide"))
				{
					FormArray.Add(new ViewerGuide((string)_InnerGuideDef[idx],0,5));
					InterFaceArray.Add(((ViewerGuide)FormArray[idx]) as IGeneralChildGuide);
				}
				else
				{
					FormArray.Add(new TableGuide((string)_InnerGuideDef[idx],0,5));
					InterFaceArray.Add(((TableGuide)FormArray[idx]) as IGeneralChildGuide);
				}

				Hashtable inObj = new Hashtable();
				Hashtable retObj = new Hashtable();
				object objectTmp = retObj; 

				((Form)FormArray[idx]).TopLevel = false;
//				((Form)FormArray[idx]).MdiParent = this;
				((Panel)GuideArray[idx]).Controls.Add((Form)FormArray[idx]);
				((Form)FormArray[idx]).Dock = DockStyle.Fill;

                ((Form)FormArray[idx]).FormClosed += new FormClosedEventHandler(this.Guid_FormClosed);   // ADD 2011/08/11

				if ((IGeneralChildGuide)InterFaceArray[idx] != null)
				{
					((IGeneralChildGuide)InterFaceArray[idx]).ExecuteChildGuide(999, (object)inObj, ref objectTmp); // retObj);
					((IGeneralChildGuide)InterFaceArray[idx]).TopParentGuideObj = (object)this;
				}

                // �q�K�C�h�ԍ��̕t�^
                IGeneralGuideOperable iGTmp = (TableGuide)FormArray[idx] as IGeneralGuideOperable;
//                MessageBox.Show("1 "+idx.ToString());
                if (iGTmp != null)
                {
//                    MessageBox.Show("2 " + idx.ToString());
                    iGTmp.ChildGuideIndex = idx;
                }
			}

			for(int idx=0; idx < _InnerGuide-1; idx++)
			{
				((IGeneralChildGuide)InterFaceArray[idx]).ChildGuideObj = (object)FormArray[idx+1]; 
			}

			TopPanel.Visible = false;
			splitter1.Visible = false;

			GuidePanel1.Visible = false;
			splitter2.Visible = false;

			GuidePanel2.Visible = false;
			splitter3.Visible = false;

			GuidePanel3.Visible = false;
			splitter4.Visible = false;

			GuidePanel4.Visible = false;

			int ParentSizeWTmp = 0;
			
			for(int idx=0; idx < _InnerGuide; idx++)
			{
				if((idx > 0) && (idx < _InnerGuide))
				{
					((Splitter)SplitArray[idx]).Visible = true;
				}
				((Panel)GuideArray[idx]).Visible = true;
				((Panel)GuideArray[idx]).Dock = DockStyle.Left;

				
				ParentSizeWTmp = ParentSizeWTmp+((IGeneralChildGuide)InterFaceArray[idx]).ParentAddWidth;
			}

			if(_InnerGuide > 0)
			{
				((Panel)GuideArray[_InnerGuide-1]).Dock = DockStyle.Fill;
			}

			if(ParentSizeWTmp < 50) 
			{
				ParentSizeWTmp = 50;
			}

			this.SetClientSizeCore(ParentSizeWTmp, ((IGeneralChildGuide)InterFaceArray[0]).ParentAddHeight); 

			for(int idx=0; idx < _InnerGuide; idx++)
			{
				// �q�K�C�h�̃T�C�Y�ύX
				((Panel)GuideArray[idx]).Height = ((IGeneralChildGuide)InterFaceArray[idx]).ParentAddHeight; 
				// ((TableGuide)FormArray[idx]).ParentSizeH;
				((Panel)GuideArray[idx]).Width  = ((IGeneralChildGuide)InterFaceArray[idx]).ParentAddWidth; 
				//((TableGuide)FormArray[idx]).ParentSizeW;

				// �q�K�C�h�ɍŏ�ʐe�K�C�h�̏����������I����ʒm
				((IGeneralChildGuide)InterFaceArray[idx]).OnEndTopParentInitProc(0, null); 
		
			}

            // --- ADD 2011/08/11---------->>>>>
            // �i���@�\������K�C�h�̂݃X�e�[�^�X�o�[��\������B
            foreach (string xmlName in this._InnerGuideDef)
            {
                XmlDocument xmlDoc = new XmlDocument();
                // �K�C�h�ݒ�t�@�C���̓Ǎ�
                try
                {
                    xmlDoc.Load(xmlName);
                }
                catch (FileNotFoundException e)
                {
                    MessageBox.Show(e.StackTrace);
                }
                catch (XmlException e)
                {
                    MessageBox.Show(e.StackTrace);
                }


                XmlElement xmlElem = xmlDoc.DocumentElement;
                XmlNodeList nodeSearchConditionList = xmlElem.SelectNodes("/definfo/GuideDef/SearchCondition");

                if (nodeSearchConditionList.Count > 0)
                {
                    this.uStatusBar_Main.Visible = true;
                    break;
                }
                else
                {
                    this.uStatusBar_Main.Visible = false;
                }
            }
            // --- ADD 2011/08/11----------<<<<<
		}
		
		private void Form1_Load(object sender, System.EventArgs e)
		{
			this._controlScreenSkin = new ControlScreenSkin();
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);

			this.IsMdiContainer = true;
		}
		
		/// <summary>
		/// �K�C�h�t�H�[���N��
		/// </summary>
		public bool Execute(int mode, object serchInfo, ref ArrayList returnInfo)
		{

			MessageBox.Show("���̋@�\�͊g���p�ɏ�������Ă�����̂ŁA���ݎg�p�ł��܂���");
/*
			_ParentSerchInfo = serchInfo;

//			((IGeneralChildGuide)InterFaceArray[0]).LoadChildGuideData(0, _ParentSerchInfo); 
			// �e�t�H�[���N��
			this.ShowDialog();  	
			returnInfo = _SelectedDataArray; */
			return _ResultStatus;
		}


		/// <summary>
		/// �K�C�h�t�H�[���N��(�����I���K�C�h)
		/// </summary>
		public bool ExecuteMultiSelector(int mode, object serchInfo, ref ArrayList returnInfo)
		{
			_ParentSerchInfo = serchInfo;
			
			this.IsMultiSelector = true;

			// �擪�̎q�K�C�h����f�[�^���擾����
			((IGeneralChildGuide)InterFaceArray[0]).LoadChildGuideData(0, (Hashtable)_ParentSerchInfo); 

			// �e�t�H�[���N��
			this.ShowDialog();  	
//			returnInfo = _SelectedDataHash;
			return _ResultStatus;

		}

		/// <summary>
		/// �K�C�h�t�H�[���N��
		/// </summary>
		public bool Execute(int mode, object serchInfo, ref Hashtable returnInfo)
		{
			_ParentSerchInfo = serchInfo;

            // �擪�̎q�K�C�h����f�[�^���擾����
			((IGeneralChildGuide)InterFaceArray[0]).LoadChildGuideData(0, (Hashtable)_ParentSerchInfo);


			if(_DefaultSetData.Contains((string)_InnerGuideDef[0]))
			{
                ArrayList alTmp = (ArrayList)_DefaultSetData[(string)_InnerGuideDef[0]];
                SetDefData(ref alTmp);
                ((IGeneralChildGuide)InterFaceArray[0]).SelectMyGuideData(0, _DefaultSetData[(string)_InnerGuideDef[0]]);
            }

			// �e�t�H�[���N��
			this.ShowDialog();

			returnInfo = _SelectedDataHash;
			return _ResultStatus;

		}


        /// <summary>
        /// �K�C�h�t�H�[���N��
        /// </summary>
        public bool ExecuteWithDefaultDataSelect(int mode, object serchInfo, ref Hashtable returnInfo, Hashtable defaultDataInfo)
        {
            _ParentSerchInfo = serchInfo;

            // �擪�̎q�K�C�h����f�[�^���擾����
            ((IGeneralChildGuide)InterFaceArray[0]).LoadChildGuideData(0, (Hashtable)_ParentSerchInfo);


            if (defaultDataInfo != null)
            {
                ArrayList defDataArray;
                // �f�t�H���g�I���f�[�^�𐶐�����
                if (_DefaultSetData.Contains((string)_InnerGuideDef[0]))
                {
                    defDataArray = (ArrayList)_DefaultSetData[(string)_InnerGuideDef[0]];
                    // ��ɒ񋟕��̃f�t�H���g�l�Z�b�g�����s����
                    SetDefData(ref defDataArray);


                }
                else
                {
                    defDataArray = new ArrayList();
                    _DefaultSetData.Add((string)_InnerGuideDef[0], defDataArray);
                }

                // �N����PG����w�肳�ꂽ defaultDataInfo (Key��Value�̑g����)���Z�b�g����
                foreach (object keyInf in defaultDataInfo.Keys)
                {
                    if (defaultDataInfo[keyInf] != null)
                    {
                        GuideDefaultDataInfo defInfo = new GuideDefaultDataInfo(keyInf.ToString(), "", defaultDataInfo[keyInf]);
                        defDataArray.Add(defInfo);
                    }
                }
            }

            if (_DefaultSetData.Contains((string)_InnerGuideDef[0]))
            {
//                ArrayList alTmp = (ArrayList)_DefaultSetData[(string)_InnerGuideDef[0]];
//                SetDefData(ref alTmp);
                ((IGeneralChildGuide)InterFaceArray[0]).SelectMyGuideData(0, _DefaultSetData[(string)_InnerGuideDef[0]]);
            }

            // �e�t�H�[���N��
            this.ShowDialog();

            returnInfo = _SelectedDataHash;
            return _ResultStatus;

        }



		/// <summary>
		/// �K�C�h�t�H�[���N��
		/// </summary>
		public bool Execute(int mode, object serchInfo, ref DataSet returnInfo)
		{
			MessageBox.Show("���̋@�\�͊g���p�ɏ�������Ă�����̂ŁA���ݎg�p�ł��܂���");
/*			_ParentSerchInfo = serchInfo;
			this.ShowDialog();  	
			returnInfo = null; */
			return _ResultStatus;
		}

		/// <summary>
		/// �f�t�H���g �R���X�g�^�N�^
		/// </summary>
		public void ParentClose()
		{
			this.Close();
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
		}

		private void TableGuideParent_SizeChanged(object sender, System.EventArgs e)
		{

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
/*			ArrayList arrayTmp = new ArrayList();
//			int st = myForm1.SelectData(ref arrayTmp); 
			int st = ((IGeneralChildGuide)InterFaceArray[0]).SelectChildGuideData(0, ref arrayTmp); 

			_SelectedDataArray = arrayTmp;
			if((_SelectedDataArray != null) && (_SelectedDataArray.Count > 0))
			{
				_ResultStatus = true;
			}
*/
			this.Close();			
		}

		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch(e.Tool.Index)
			{
				case 0:   // �I��
					SelectButton_Click(sender, e);
					break;
				case 1:   // ����
					break;
				case 2:	  // �L�����Z��
					CancelButton_Click(sender, e);
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// �L�����Z���{�^���I���C�x���g
		/// </summary>
		private void CancelButton_Click(object sender, System.EventArgs e)
		{
			_ResultStatus = false;
			this.Close();
		}

		/// <summary>
		/// �I���{�^���I���C�x���g
		/// </summary>
        private void SelectButton_Click(object sender, System.EventArgs e)
        {


            SelectGuideData(0, 0);
            //if(((IGeneralChildGuide)InterFaceArray[0]) != null)
            //{
            //    Hashtable hashTmp = new Hashtable();
            //    object objectTmp  = (object)hashTmp;
            //    int st = ((IGeneralChildGuide)InterFaceArray[0]).SelectChildGuideData(0, ref objectTmp); //hashTmp); 
            //    hashTmp = (Hashtable)objectTmp;	
            //    _SelectedDataHash  = hashTmp;

            //    if((_SelectedDataHash != null) && (_SelectedDataHash.Count > 0))
            //    {
            //        _ResultStatus = true;
            //    }
            //}
            //else
            //{
            //    _ResultStatus = false;
            //}

            //this.Close();
        }


		private void SetDefData(ref ArrayList innerGuideDef)
		{

			foreach(GuideDefaultDataInfo guideDefaultDataInfo in innerGuideDef)
			{
				// �f�t�H���g�Z�b�g�f�[�^�擾�斈�ɏ����l���擾����
                switch (guideDefaultDataInfo.TargetDataSource)
                {
                    case "InitDefAreaGroupCode":
                        {
                            // �����\���ǋ�
                            GuideInitDataServer guideInitDataServer = new GuideInitDataServer();
                            guideDefaultDataInfo.DefaultValue = guideInitDataServer.GetDefaultDistrictCode();
                            break;
                        }
                    case "InitDefSectionCode":
                        {
                            // �����\�����_
                            GuideInitDataServer guideInitDataServer = new GuideInitDataServer();
                            guideDefaultDataInfo.DefaultValue = guideInitDataServer.GetMySectionCode();
                            break;
                        }

                }
			
			}
		
		}


		/// <summary>
		/// HashTable-->Class�v���p�e�B�]�L����                                                  
		/// </summary>
		/// <param name="inData">�]�L����HashTable</param>                        
		/// <param name="retClass">�]�L���Class</param>                        
		/// <returns>�������ʕ�����</returns>                           
		/// <remarks>
		/// <br>Note       : HashTable�̃L�[�ƈ�v����N���X�v���p�e�B�֒l��]�L���܂�</br>                    
		/// <br>Programmer : 980056 R.Sokei</br>                                
		/// <br>Date       : 2005.04.26</br>                                    
		/// </remarks>
		static public int HashTableToClassProperty(Hashtable inData, ref object retClass)
		{
			if(retClass != null)
			{

				// �N���X�^�C�v���擾
				Type workClassType = retClass.GetType() ;

				// �v���p�e�B���擾
				PropertyInfo[] propInfo = workClassType.GetProperties();

				foreach(PropertyInfo prop in propInfo)
				{

					// �n�b�V���e�[�u���̑S�v�f�ɑ΂��đ���H�H�H
					if(inData.ContainsKey(prop.Name))
					{

						switch(prop.PropertyType.ToString())
						{
							case "System.Int32":
							{
								prop.SetValue(retClass, Convert.ToInt32(inData[prop.Name].ToString()) , null);
								break;
							}
							case "System.String":
							{
								prop.SetValue(retClass, inData[prop.Name].ToString(), null);
								break;
							}
							case "System.Guid":
							{
								if(inData[prop.Name].GetType().ToString() == "System.Guid")
								{
									prop.SetValue(retClass, (Guid)inData[prop.Name], null);
								}
								else if(inData[prop.Name].GetType().ToString() == "System.String")
								{
									prop.SetValue(retClass, new Guid(inData[prop.Name].ToString()), null);
								}
								break;
							}
							case "System.DateTime":
							{
								if(inData[prop.Name].GetType().ToString() == "System.DateTime")
								{
									prop.SetValue(retClass, (DateTime)inData[prop.Name], null);
								}
								else if(inData[prop.Name].GetType().ToString() == "System.Int64")
								{
									prop.SetValue(retClass, new DateTime((long)inData[prop.Name]), null);
								}
								break;

							}
							case "System.Int64":
							{
								prop.SetValue(retClass, Convert.ToInt64(inData[prop.Name].ToString()) , null);
								break;
							}
							case "System.Double":
							{   
								if(inData[prop.Name].GetType().ToString() == "System.Double")
								{
									prop.SetValue(retClass, (double)inData[prop.Name] , null);
								}
								else if(inData[prop.Name].GetType().ToString() == "System.String")
								{
									prop.SetValue(retClass, Convert.ToDouble(inData[prop.Name].ToString()) , null);
								}
								break;
									
							}
						}
					}
				}

				// HashTable�Ɠ���DD�����v���p�e�B������Α������
				return 0;

			}
			else
			{
				return -1;
			}
		}

		
		#region IGeneralGuidOperable �����o

		private bool _IsTopLevelGuide = true;
		

		/// <summary>�ŏ�ʃK�C�h����v���p�e�B</summary>                                
		/// <value>true:�ŏ�ʃK�C�h�C false:�q�K�C�h</value>        
		/// <remarks>�R���g���[�����ŏ�ʂ̃K�C�h���ǂ������f���܂�</remarks>     
		public bool IsTopLevelGuide
		{
			get
			{
				return _IsTopLevelGuide;
			}
			set
			{
				_IsTopLevelGuide = value;
			}
		}

		/// <summary>�����s�I���v���p�e�B</summary>                                
		/// <value>true:�����s�I���C false:�P��s�I��</value>        
		/// <remarks>�K�C�h���𕡐��I���ł��邩�ǂ������f���܂�</remarks>     
		public bool IsMultiSelector
		{
			get{return _MultiSelect;} 
			
			set{_MultiSelect = value;}
		}		

		private int _ChildGuideIndex = 0;


		/// <summary>�q�K�C�h�C���f�b�N�X�ԍ��v���p�e�B</summary>                                
		/// <value>�q�K�C�h�̃C���f�b�N�X�ԍ�</value>        
		/// <remarks>�R���g���[�����q�K�C�h�ꍇ�Ɋ��蓖�Ă���C���f�b�N�X�ԍ�</remarks>     
		public int ChildGuideIndex
		{
			get
			{
				return _ChildGuideIndex;
			}
			set
			{
				_ChildGuideIndex = value;
			}
		}


		/// <summary>
		/// �ꗗ�\�K�C�h�f�[�^�I������
		/// </summary>
		/// <param name="mode">�K�C�h�\���f�[�^�擾���[�h</param>
		/// <param name="childGuideIndex">�K�C�h�\���f�[�^�擾����</param>
		/// <returns>STATUS 0:����, -1:���s, 9:�Y���f�[�^����</returns>
		/// <remarks>
		/// <br>Note       : ���ݑI������Ă���f�[�^���擾���܂�</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int SelectGuideData(int mode, int childGuideIndex)
		{

			if(((IGeneralChildGuide)InterFaceArray[0]) != null)
			{
				Hashtable hashTmp = new Hashtable();
				object objectTmp  = (object)hashTmp;

				int st = ((IGeneralChildGuide)InterFaceArray[0]).SelectChildGuideData(0, ref objectTmp);// hashTmp); 

				hashTmp = (Hashtable)objectTmp;	
				_SelectedDataHash  = hashTmp;

				if((_SelectedDataHash != null) && (_SelectedDataHash.Count > 0))
				{
                    // �ԋp���ׂ��L�[�Z�b�g�Ǝ��ۂ̑I�����̐�����v���Ă����OK
                    if (_SelectedDataHash.Contains("_SELECT_ERROR"))
                    {
                        // �I���ŃG���[������ꍇ�̓K�C�h�̎��s���ʂ� false ��
                        _ResultStatus = false;

                    }
                    else
                    {
                        _ResultStatus = true;
                    
                    }
				}
			}
			else
			{
				_ResultStatus = false;
			
			}

			this.Close();
			return 0;
		}

		#endregion

		private void TableGuideParent_Enter(object sender, System.EventArgs e)
		{


		}

		private void TableGuideParent_Activated(object sender, System.EventArgs e)
		{


		}


        #region IGeneralGuideFocusOperable �����o




        public void ChangeFocus(EnumGeneralGuideFocusDirection direction, int childGuideIndex)
        {

            // �t�H�[�J�X���q�K�C�h�ɂ���ꍇ�A�J�[�\���L�[�̍���E�ŕ����K�C�h�Ԃ��t�H�[�J�X�ړ�����

            if(FormArray.Count > 1)
            {

                if(direction.Equals(EnumGeneralGuideFocusDirection.Left))
                {
                    if ((childGuideIndex - 1) >= 0)
                    { 
                      // �ЂƂ��̃K�C�h�Ƀt�H�[�J�X���Z�b�g����
                        IGeneralGuideFocusOperable plugIn = FormArray[childGuideIndex - 1] as IGeneralGuideFocusOperable;
                        
                        if (plugIn != null)
                        {
                            ((Panel)GuideArray[childGuideIndex - 1]).Focus();
                            ((Form)FormArray[childGuideIndex - 1]).Focus();
                            plugIn.ChangeFocus(EnumGeneralGuideFocusDirection.MainGrid, -1);
                        }
                    
                    }
                }
                else if (direction.Equals(EnumGeneralGuideFocusDirection.Right))
                {
                    if ((childGuideIndex + 1) < FormArray.Count)
                    {
                        // �ЂƂ��̃K�C�h�Ƀt�H�[�J�X���Z�b�g����
                        IGeneralGuideFocusOperable plugIn = FormArray[childGuideIndex + 1] as IGeneralGuideFocusOperable;

                        if (plugIn != null)
                        {
                            ((Panel)GuideArray[childGuideIndex + 1]).Focus();
                            ((Form)FormArray[childGuideIndex + 1]).Focus();
                            plugIn.ChangeFocus(EnumGeneralGuideFocusDirection.MainGrid, -1);
                        }

                    }

                }

            }



            return;
        }

        #endregion

        // --- ADD 2011/08/11---------->>>>>
        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʂ��I�����܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/08/11</br>
        /// </remarks>
        private void Guid_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        // --- ADD 2011/08/11----------<<<<<
    }


	

}
