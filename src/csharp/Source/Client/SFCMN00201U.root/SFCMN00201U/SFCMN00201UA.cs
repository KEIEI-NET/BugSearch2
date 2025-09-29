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
	/// Form1 の概要の説明です。
	/// </summary>
    /// <remarks>
    /// <br>Update Note: 2011/08/11 李占川 </br>
    /// <br>             NSユーザー改良要望一覧_20110629_1.優先案件_連番9（redmine#23479）によって改修お行う</br>
    /// </remarks>
	public class TableGuideParent : System.Windows.Forms.Form, IGeneralGuideOperable, IGeneralGuideFocusOperable
	{

		#region Windows フォーム デザイナで生成されたコード 
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
		#endregion Windows フォーム デザイナで生成されたコード 

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
		private ArrayList _InnerGuideType;  // 子ガイドのタイプ
		
		private ArrayList FormArray = null;
		private ArrayList InterFaceArray = null;
		private ArrayList GuideArray = null;
		private ArrayList SplitArray = null;

		private bool _MultiSelect = false;
		private Hashtable _DefaultSetData;  // ガイド表示時の初期選択データを保持
		private ControlScreenSkin _controlScreenSkin;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main; // ADD 2011/08/11

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public TableGuideParent()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

		}
		
		/// <summary>
		/// コンストラクタ(定義ファイル指定)
		/// </summary>
		public TableGuideParent(string definitionFile)
		{
			InitializeComponent();
			_xPathDocPath = definitionFile;
			
			InitForm();
		}

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
			popupMenuTool1.InstanceProps.Caption = "表示切替(&Ｖ)";
			popupMenuTool1.InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False;
			ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            popupMenuTool1});
			this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
			buttonTool4.SharedProps.Caption = "選択(&S)";
			buttonTool4.SharedProps.CustomizerCaption = "選択(&S)";
			buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool5.SharedProps.Caption = "検索(&F)";
			buttonTool5.SharedProps.CustomizerCaption = "検索(&F)";
			buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool5.SharedProps.Visible = false;
			buttonTool6.SharedProps.Caption = "戻る(&X)";
			buttonTool6.SharedProps.CustomizerCaption = "戻る(&X)";
			buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			popupMenuTool2.SharedProps.Caption = "viewerSwMenu";
			popupMenuTool2.SharedProps.CustomizerCaption = "表示切替(&V)";
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
            appearance37.FontData.Name = "ＭＳ ゴシック";
            ultraStatusPanel1.Appearance = appearance37;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "StatusBarPanel_Text";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel1.Text = "F3：条件設定  F6：絞込  ESC：終了";
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
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new TableGuideParent());
		}

		/// <summary>
		/// フォーム初期化処理
		/// </summary>
		/// <returns>無し</returns>
		/// <remarks>
		/// <br>Note       : ガイド処理に必要な初期処理を行います</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.03.19</br>
        /// <br>Update Note: 2011/08/11 李占川</br>
        /// <br>             NSユーザー改良要望一覧_20110629_1.優先案件_連番9（redmine#23479）によって改修お行う</br>
		/// </remarks>
		private void InitForm()
		{

            ultraToolbarsManager1.Toolbars[0].Tools[0].InstanceProps.AppearancesSmall.Appearance.Image = Broadleaf.Library.Resources.IconResourceManagement.ImageList16.Images[12];
            ultraToolbarsManager1.Toolbars[0].Tools[1].InstanceProps.AppearancesSmall.Appearance.Image = Broadleaf.Library.Resources.IconResourceManagement.ImageList16.Images[2];
            ultraToolbarsManager1.Toolbars[0].Tools[2].InstanceProps.AppearancesSmall.Appearance.Image = Broadleaf.Library.Resources.IconResourceManagement.ImageList16.Images[17];

			_SelectedDataArray	= new ArrayList();
			_SelectedDataHash	= new Hashtable();
			_InnerGuideDef		= new ArrayList();
			_InnerGuideType     = new ArrayList();  // 子ガイドのタイプ
			FormArray           = new ArrayList();
			GuideArray			= new ArrayList();
			SplitArray			= new ArrayList();
			InterFaceArray		= new ArrayList();
			_DefaultSetData     = new Hashtable(); // ガイド表示時の初期選択データ設定

			if((!(_xPathDocPath == "")) && (!(_xPathDocPath == null))) 

			// ガイド設定ファイルが指定されている場合
			{
				// ガイド設定ファイルの読込
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
			
				// ガイド設定ファイルの読込
				if(_xPathDocEnable)
				{
					#region フォーム全体の設定 

					XmlElement xmlElem  = _xmlDoc.DocumentElement;
					XmlElement xmlElem2;
					int numTmp = 0;
					
					// フォームタイトル
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/FormTitle"); 
					if(!(xmlElem2 == null))
					{
						this.Text = xmlElem2.InnerText;
					}

					// フォームスタイル
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/StyleMode"); 
					if(!(xmlElem2 == null))
					{
						if(xmlElem2.InnerText == "oldpeg") _StyleMode = 1;
					}

					// フォーム表示位置
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/StartPosition"); 
					if(!(xmlElem2 == null))
					{
						if(xmlElem2.InnerText == "CenterParent") this.StartPosition = FormStartPosition.CenterParent;
						else if(xmlElem2.InnerText == "Manual") this.StartPosition = FormStartPosition.Manual;
					}

					// フォーム表示位置TOP
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/StartPositionTop"); 
					if(!(xmlElem2 == null))
					{
						numTmp = Convert.ToInt32(xmlElem2.InnerText);
						if(numTmp >= 0)
						{
							this.Top   = numTmp;
						}
					}

					// フォーム表示位置LEFT
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/StartPositionLeft"); 
					if(!(xmlElem2 == null))
					{
						numTmp = Convert.ToInt32(xmlElem2.InnerText);
						if(numTmp >= 0)
						{
							this.Top	= numTmp;
						}
					}

					#endregion フォーム全体の設定 
				
					#region 子ガイドの設定 
					XmlNodeList nodeList;

					nodeList = xmlElem.SelectNodes("/definfo/InnerFormDef/InnerGuide");
					if(nodeList[0] != null)
					{
						_InnerGuide = Convert.ToInt32(((XmlNode)nodeList[0]).InnerText); // 子ガイドの数 
					}

					nodeList = xmlElem.SelectNodes("/definfo/InnerFormDef/InnerGuideWithSettings");
					if(nodeList[0] != null)
					{
						_InnerGuideWithSetteings = Convert.ToInt32(((XmlNode)nodeList[0]).InnerText) - 1; // ガイド設定情報を保持する子ガイドの番号 
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


						_InnerGuideDef.Add(isbn.InnerText); //InnerText);  // 子ガイドの定義ファイルパス
					}

					#endregion 子ガイドの設定 

					#region 子ガイドの初期セットデータ設定(ガイド起動時にデフォルトで選択するデータの定義) 
				
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
								// 初期値として選択する全ての項目と初期値の取得先IDを取得する
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
								// 初期値をセットするガイド名を取得する
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

					#endregion 子ガイドの初期セットデータ設定
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

                // 子ガイド番号の付与
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
				// 子ガイドのサイズ変更
				((Panel)GuideArray[idx]).Height = ((IGeneralChildGuide)InterFaceArray[idx]).ParentAddHeight; 
				// ((TableGuide)FormArray[idx]).ParentSizeH;
				((Panel)GuideArray[idx]).Width  = ((IGeneralChildGuide)InterFaceArray[idx]).ParentAddWidth; 
				//((TableGuide)FormArray[idx]).ParentSizeW;

				// 子ガイドに最上位親ガイドの初期化処理終了を通知
				((IGeneralChildGuide)InterFaceArray[idx]).OnEndTopParentInitProc(0, null); 
		
			}

            // --- ADD 2011/08/11---------->>>>>
            // 絞込機能があるガイドのみステータスバーを表示する。
            foreach (string xmlName in this._InnerGuideDef)
            {
                XmlDocument xmlDoc = new XmlDocument();
                // ガイド設定ファイルの読込
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
		/// ガイドフォーム起動
		/// </summary>
		public bool Execute(int mode, object serchInfo, ref ArrayList returnInfo)
		{

			MessageBox.Show("この機能は拡張用に準備されているもので、現在使用できません");
/*
			_ParentSerchInfo = serchInfo;

//			((IGeneralChildGuide)InterFaceArray[0]).LoadChildGuideData(0, _ParentSerchInfo); 
			// 親フォーム起動
			this.ShowDialog();  	
			returnInfo = _SelectedDataArray; */
			return _ResultStatus;
		}


		/// <summary>
		/// ガイドフォーム起動(複数選択ガイド)
		/// </summary>
		public bool ExecuteMultiSelector(int mode, object serchInfo, ref ArrayList returnInfo)
		{
			_ParentSerchInfo = serchInfo;
			
			this.IsMultiSelector = true;

			// 先頭の子ガイドからデータを取得する
			((IGeneralChildGuide)InterFaceArray[0]).LoadChildGuideData(0, (Hashtable)_ParentSerchInfo); 

			// 親フォーム起動
			this.ShowDialog();  	
//			returnInfo = _SelectedDataHash;
			return _ResultStatus;

		}

		/// <summary>
		/// ガイドフォーム起動
		/// </summary>
		public bool Execute(int mode, object serchInfo, ref Hashtable returnInfo)
		{
			_ParentSerchInfo = serchInfo;

            // 先頭の子ガイドからデータを取得する
			((IGeneralChildGuide)InterFaceArray[0]).LoadChildGuideData(0, (Hashtable)_ParentSerchInfo);


			if(_DefaultSetData.Contains((string)_InnerGuideDef[0]))
			{
                ArrayList alTmp = (ArrayList)_DefaultSetData[(string)_InnerGuideDef[0]];
                SetDefData(ref alTmp);
                ((IGeneralChildGuide)InterFaceArray[0]).SelectMyGuideData(0, _DefaultSetData[(string)_InnerGuideDef[0]]);
            }

			// 親フォーム起動
			this.ShowDialog();

			returnInfo = _SelectedDataHash;
			return _ResultStatus;

		}


        /// <summary>
        /// ガイドフォーム起動
        /// </summary>
        public bool ExecuteWithDefaultDataSelect(int mode, object serchInfo, ref Hashtable returnInfo, Hashtable defaultDataInfo)
        {
            _ParentSerchInfo = serchInfo;

            // 先頭の子ガイドからデータを取得する
            ((IGeneralChildGuide)InterFaceArray[0]).LoadChildGuideData(0, (Hashtable)_ParentSerchInfo);


            if (defaultDataInfo != null)
            {
                ArrayList defDataArray;
                // デフォルト選択データを生成する
                if (_DefaultSetData.Contains((string)_InnerGuideDef[0]))
                {
                    defDataArray = (ArrayList)_DefaultSetData[(string)_InnerGuideDef[0]];
                    // 先に提供分のデフォルト値セットを実行する
                    SetDefData(ref defDataArray);


                }
                else
                {
                    defDataArray = new ArrayList();
                    _DefaultSetData.Add((string)_InnerGuideDef[0], defDataArray);
                }

                // 起動元PGから指定された defaultDataInfo (KeyとValueの組合せ)をセットする
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

            // 親フォーム起動
            this.ShowDialog();

            returnInfo = _SelectedDataHash;
            return _ResultStatus;

        }



		/// <summary>
		/// ガイドフォーム起動
		/// </summary>
		public bool Execute(int mode, object serchInfo, ref DataSet returnInfo)
		{
			MessageBox.Show("この機能は拡張用に準備されているもので、現在使用できません");
/*			_ParentSerchInfo = serchInfo;
			this.ShowDialog();  	
			returnInfo = null; */
			return _ResultStatus;
		}

		/// <summary>
		/// デフォルト コンストタクタ
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
				case 0:   // 選択
					SelectButton_Click(sender, e);
					break;
				case 1:   // 検索
					break;
				case 2:	  // キャンセル
					CancelButton_Click(sender, e);
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// キャンセルボタン選択イベント
		/// </summary>
		private void CancelButton_Click(object sender, System.EventArgs e)
		{
			_ResultStatus = false;
			this.Close();
		}

		/// <summary>
		/// 選択ボタン選択イベント
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
				// デフォルトセットデータ取得先毎に初期値を取得する
                switch (guideDefaultDataInfo.TargetDataSource)
                {
                    case "InitDefAreaGroupCode":
                        {
                            // 初期表示管区
                            GuideInitDataServer guideInitDataServer = new GuideInitDataServer();
                            guideDefaultDataInfo.DefaultValue = guideInitDataServer.GetDefaultDistrictCode();
                            break;
                        }
                    case "InitDefSectionCode":
                        {
                            // 初期表示拠点
                            GuideInitDataServer guideInitDataServer = new GuideInitDataServer();
                            guideDefaultDataInfo.DefaultValue = guideInitDataServer.GetMySectionCode();
                            break;
                        }

                }
			
			}
		
		}


		/// <summary>
		/// HashTable-->Classプロパティ転記処理                                                  
		/// </summary>
		/// <param name="inData">転記元のHashTable</param>                        
		/// <param name="retClass">転記先のClass</param>                        
		/// <returns>処理結果文字列</returns>                           
		/// <remarks>
		/// <br>Note       : HashTableのキーと一致するクラスプロパティへ値を転記します</br>                    
		/// <br>Programmer : 980056 R.Sokei</br>                                
		/// <br>Date       : 2005.04.26</br>                                    
		/// </remarks>
		static public int HashTableToClassProperty(Hashtable inData, ref object retClass)
		{
			if(retClass != null)
			{

				// クラスタイプを取得
				Type workClassType = retClass.GetType() ;

				// プロパティを取得
				PropertyInfo[] propInfo = workClassType.GetProperties();

				foreach(PropertyInfo prop in propInfo)
				{

					// ハッシュテーブルの全要素に対して操作？？？
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

				// HashTableと同一DDを持つプロパティがあれば代入する
				return 0;

			}
			else
			{
				return -1;
			}
		}

		
		#region IGeneralGuidOperable メンバ

		private bool _IsTopLevelGuide = true;
		

		/// <summary>最上位ガイド判定プロパティ</summary>                                
		/// <value>true:最上位ガイド， false:子ガイド</value>        
		/// <remarks>コントロールが最上位のガイドかどうか判断します</remarks>     
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

		/// <summary>複数行選択プロパティ</summary>                                
		/// <value>true:複数行選択， false:単一行選択</value>        
		/// <remarks>ガイド情報を複数選択できるかどうか判断します</remarks>     
		public bool IsMultiSelector
		{
			get{return _MultiSelect;} 
			
			set{_MultiSelect = value;}
		}		

		private int _ChildGuideIndex = 0;


		/// <summary>子ガイドインデックス番号プロパティ</summary>                                
		/// <value>子ガイドのインデックス番号</value>        
		/// <remarks>コントロールが子ガイド場合に割り当てられるインデックス番号</remarks>     
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
		/// 一覧表ガイドデータ選択処理
		/// </summary>
		/// <param name="mode">ガイド表示データ取得モード</param>
		/// <param name="childGuideIndex">ガイド表示データ取得条件</param>
		/// <returns>STATUS 0:成功, -1:失敗, 9:該当データ無し</returns>
		/// <remarks>
		/// <br>Note       : 現在選択されているデータを取得します</br>
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
                    // 返却すべきキーセットと実際の選択情報の数が一致していればOK
                    if (_SelectedDataHash.Contains("_SELECT_ERROR"))
                    {
                        // 選択先でエラーがある場合はガイドの実行結果を false へ
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


        #region IGeneralGuideFocusOperable メンバ




        public void ChangeFocus(EnumGeneralGuideFocusDirection direction, int childGuideIndex)
        {

            // フォーカスが子ガイドにある場合、カーソルキーの左･右で複数ガイド間をフォーカス移動する

            if(FormArray.Count > 1)
            {

                if(direction.Equals(EnumGeneralGuideFocusDirection.Left))
                {
                    if ((childGuideIndex - 1) >= 0)
                    { 
                      // ひとつ左のガイドにフォーカスをセットする
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
                        // ひとつ左のガイドにフォーカスをセットする
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
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面を終了します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/08/11</br>
        /// </remarks>
        private void Guid_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        // --- ADD 2011/08/11----------<<<<<
    }


	

}
