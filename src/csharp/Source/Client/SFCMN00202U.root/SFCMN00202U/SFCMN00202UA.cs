using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Runtime.Remoting;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.ComponentModel;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;
using System.Diagnostics;


namespace Broadleaf.Windows.Forms
{ 
	
	/// <summary>
	/// 一覧表ガイド(子ガイド)
	/// </summary>
    /// <remarks>
    /// <br>Update Note: 2011/07/11 wangf </br>
    /// <br>             NSユーザー改良要望一覧_20110629_1.優先案件_連番9によって改修お行う</br>
    /// <br>Update Note: 2011/08/11 李占川 </br>
    /// <br>             NSユーザー改良要望一覧_20110629_1.優先案件_連番9（redmine#23479）によって改修お行う</br>
    /// <br>Update Note: 2011/08/18 李占川 </br>
    /// <br>             NSユーザー改良要望一覧_20110629_1.優先案件_連番9によって改修お行う</br>
    /// <br>             ①redmine#23479のNo28</br>
    /// <br>             ②redmine#23479のNo30</br>
    /// <br>Update Note: 2011/08/31 wangf </br>
    /// <br>             ①redmine#24253を対応</br>
    /// <br>Update Note: 2011/09/02 wangf </br>
    /// <br>             ①redmine#24253のNo5を対応</br>
    /// <br>Update Note: 2012/10/22  王君</br>
    /// <br>管理番号   : 2012/11/14配信分</br>
    /// <br>             Redmine#32861 仕入先ガイドに「電話番号」「ＦＡＸ番号」を追加する対応</br>
    /// </remarks>
    public class TableGuide : System.Windows.Forms.Form, IGeneralChildGuide, IGeneralGuideOperable, IGeneralGuideFocusOperable
	{
		#region Windowsフォーム コンポーネント 
		private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ImageList imageList1;
		private Infragistics.Win.Misc.UltraButton SelectButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ImageList imageList2;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Panel MsgPanel;
		private Infragistics.Win.Misc.UltraLabel MsgLabel1;
		private Infragistics.Win.Misc.UltraButton CancelButton;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _TableGuide_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _TableGuide_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _TableGuide_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _TableGuide_Toolbars_Dock_Area_Right;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;

		#endregion Windowsフォーム コンポーネント 

		private bool _ResultStatus = false;
		private ArrayList _SelectedDataArray;
		private Hashtable _SelectedDataHash;
		private ArrayList _MultiSelectedArray;     // グリッド行複数選択時の選択結果を保持する
		private int _StyleMode = 0;
		private object _ParentSerchInfo = null;
		private string _SerchAssemblyName  = "";
		private string _SerchClassName     = "";
		private int _ExecMode = 0;
		//		private TableGuide _ChildGuide = null;
		private object _ChildGuide = null;

		private XmlDocument _xmlDoc;
		//		private XPathDocument  _xPathDoc;
		//		private XPathNavigator _xPathNavi;
		private DataSet _DataSet;

		private Hashtable _NameToKey;		// 列名-->キー情報のインデックス
		private Hashtable _KeyToName;		// キー情報-->列名のインデックス
		private Hashtable _KeyToType;		// キー情報-->列タイプのインデックス
		private Hashtable _KeyToWidth;		// キー情報-->列幅のインデックス
		private Hashtable _KeyToDspFormat;  // キー情報-->表示時の編集方式インデックス
		private Hashtable _KeyToHAlign;     // キー情報-->表示時の水平方向アライメント
        private Hashtable _KeyToDetail;     // キー情報-->項目詳細情報(クラス)
        private Hashtable _KeyToDetail_SW1;     // キー情報-->項目詳細情報(クラス) 表示切替1用

		private Hashtable _Resultinfo;		// 選択結果を返すキー情報のリスト
		private Hashtable _Searchinfo;		// 検索条件を生成するキー情報のリスト
		private Hashtable _ThroughSearchInfo; // 親コントロールの検索条件をスルーするキー情報のリスト
		private ArrayList _SearchKey;		// 検索条件を生成するキー情報

		private ArrayList _ChildSearchKey;	// 子ガイドの検索条件を生成するキー情報
		private ArrayList _ChildResultinfo;	// 子ガイドの検索条件を生成するキー情報

		private string _xPathDocPath = "";
		private bool _xPathDocEnable = false;
		private ControlScreenSkin _controlScreenSkin;

		private int _ParentAddHeight = 0;
		private int _ParentAddWidth = 0;
		private int _ViewerMode = 0;        // 一覧データの表示切替
        private int _ViewerSWIndex = 0;     // 一覧データの表示切替インデックス
       
		private bool MultiSelect = false;   // 複数行選択フラグ
        // 2011/07/11 wangf add start
        private Panel Searchpanel;   // サーチPANEL
        // 特別処理コンポーネント
        private string[] _specialNames = { "sectioncode_textbox" };
        private TRetKeyControl tRetKeyControl1;
        private TArrowKeyControl tArrowKeyControl1;
        private TComboEditor tComboEditor;
        // 2011/07/11 wangf add end
        private Timer timer_initFocus;　// ADD 2011/08/11
        private bool _isHaveDefaultData = false;　// ADD 2011/08/18

		/// <summary>
		/// デフォルト コンストタクタ
		/// </summary>
		//		private TableGuide ChildGuide
		private object ChildGuide
		{
			get{return _ChildGuide;}
			set{_ChildGuide = value;}		
		}

		private object _TopParentGuide = null;
		/// <summary>
		/// 親ガイドコントロール
		/// </summary>
		private object TopParentGuide
		{
			get{return _TopParentGuide;}
			set{_TopParentGuide = value;}		
		}

		/// <summary>
		/// デフォルト コンストタクタ
		/// </summary>
		public TableGuide()
		{
			// Windows フォーム デザイナ サポートに必要です。
			InitializeComponent();

			InitForm();
		}

		/// <summary>
		/// コンストラクタ(定義ファイル指定)
		/// </summary>
		public TableGuide(string definitionFile, int execMode)
		{
			// Windows フォーム デザイナ サポートに必要です。
			InitializeComponent();
			_ExecMode = execMode;
			_xPathDocPath = definitionFile;

			InitForm();
		}

		/// <summary>
		/// コンストラクタ(定義ファイル指定)
		/// </summary>
		public TableGuide(string definitionFile)
		{
			// Windows フォーム デザイナ サポートに必要です。
			// Windows フォーム デザイナ サポートに必要です。
			InitializeComponent();
			_ExecMode = 0;
			_xPathDocPath = definitionFile;

			InitForm();
		}

		/// <summary>
		/// コンストラクタ(定義ファイル指定)
		/// </summary>
		public TableGuide(string definitionFile, int styleMode, int execMode)
		{
			// Windows フォーム デザイナ サポートに必要です。
			InitializeComponent();
			_ExecMode = execMode;
			_xPathDocPath = definitionFile;
			_StyleMode    = styleMode;

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
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn1 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 0");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn2 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 1");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn3 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 2");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableGuide));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("", -1);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("SelectToolBt");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("FindToolBt");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CancelToolBt");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("ViewerSwMenu");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("ToolBarLabel1");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar2");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("SelectToolBt");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("FindToolBt");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CancelToolBt");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("ToolBarLabel1");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelBarLabel2");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("ViewerSwMenu");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool1 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("StateButtonTool1", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool2 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("StateButtonTool3", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool3 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("StateButtonTool1", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool4 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("StateButtonTool2", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool5 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("StateButtonTool3", "");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.ultraDataSource1 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SelectButton = new Infragistics.Win.Misc.UltraButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.CancelButton = new Infragistics.Win.Misc.UltraButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Searchpanel = new System.Windows.Forms.Panel();
            this.MsgPanel = new System.Windows.Forms.Panel();
            this.MsgLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this._TableGuide_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._TableGuide_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._TableGuide_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._TableGuide_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.timer_initFocus = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Searchpanel.SuspendLayout();
            this.MsgPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraDataSource1
            // 
            ultraDataColumn1.DefaultValue = "0";
            ultraDataColumn2.DefaultValue = "a";
            ultraDataColumn3.DefaultValue = "a";
            this.ultraDataSource1.Band.Columns.AddRange(new object[] {
            ultraDataColumn1,
            ultraDataColumn2,
            ultraDataColumn3});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.panel1.Location = new System.Drawing.Point(0, 574);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 45);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(136, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 38);
            this.label1.TabIndex = 8;
            this.label1.Text = "デバッグ1";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(76, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 40);
            this.label2.TabIndex = 7;
            this.label2.Text = "デバッグ2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.SelectButton);
            this.panel4.Controls.Add(this.CancelButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(208, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(234, 45);
            this.panel4.TabIndex = 5;
            // 
            // SelectButton
            // 
            appearance1.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance1.Image = 0;
            this.SelectButton.Appearance = appearance1;
            this.SelectButton.ImageList = this.imageList1;
            this.SelectButton.ImageSize = new System.Drawing.Size(23, 23);
            this.SelectButton.ImageTransparentColor = System.Drawing.Color.White;
            this.SelectButton.Location = new System.Drawing.Point(15, 7);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(95, 30);
            this.SelectButton.TabIndex = 3;
            this.SelectButton.Text = "選択(&S) ";
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // CancelButton
            // 
            appearance2.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance2.Image = 1;
            this.CancelButton.Appearance = appearance2;
            this.CancelButton.ImageList = this.imageList1;
            this.CancelButton.ImageSize = new System.Drawing.Size(21, 21);
            this.CancelButton.ImageTransparentColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(114, 7);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(107, 30);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "キャンセル(&C)";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Searchpanel);
            this.panel2.Controls.Add(this.MsgPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 64);
            this.panel2.TabIndex = 4;
            // 
            // Searchpanel
            // 
            this.Searchpanel.Controls.Add(this.tComboEditor);
            this.Searchpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Searchpanel.Location = new System.Drawing.Point(0, 0);
            this.Searchpanel.Name = "Searchpanel";
            this.Searchpanel.Size = new System.Drawing.Size(442, 38);
            this.Searchpanel.TabIndex = 1;
            // 
            // MsgPanel
            // 
            this.MsgPanel.Controls.Add(this.MsgLabel1);
            this.MsgPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MsgPanel.Location = new System.Drawing.Point(0, 39);
            this.MsgPanel.Name = "MsgPanel";
            this.MsgPanel.Size = new System.Drawing.Size(442, 25);
            this.MsgPanel.TabIndex = 0;
            this.MsgPanel.Resize += new System.EventHandler(this.MsgPanel_Resize);
            // 
            // MsgLabel1
            // 
            appearance16.BackColor = System.Drawing.Color.Black;
            appearance16.BorderColor3DBase = System.Drawing.Color.Blue;
            appearance16.ForeColor = System.Drawing.Color.MediumSpringGreen;
            appearance16.TextVAlignAsString = "Middle";
            this.MsgLabel1.Appearance = appearance16;
            this.MsgLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.InsetSoft;
            this.MsgLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Raised;
            this.MsgLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MsgLabel1.Location = new System.Drawing.Point(8, 1);
            this.MsgLabel1.Name = "MsgLabel1";
            this.MsgLabel1.Size = new System.Drawing.Size(458, 22);
            this.MsgLabel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ultraGrid1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(8, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(426, 484);
            this.panel3.TabIndex = 5;
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Cursor = System.Windows.Forms.Cursors.Default;
            appearance4.BackColor = System.Drawing.Color.Gray;
            this.ultraGrid1.DisplayLayout.Appearance = appearance4;
            this.ultraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridBand1.AddButtonCaption = "DummyBand 1";
            this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.ultraGrid1.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.ultraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ultraGrid1.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.WithinGroup;
            this.ultraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance6;
            appearance7.TextVAlignAsString = "Middle";
            this.ultraGrid1.DisplayLayout.Override.CellAppearance = appearance7;
            this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.ultraGrid1.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance8.TextHAlignAsString = "Center";
            this.ultraGrid1.DisplayLayout.Override.FixedHeaderAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.FontData.BoldAsString = "True";
            appearance9.FontData.Name = "Arial";
            appearance9.FontData.SizeInPoints = 10F;
            appearance9.ForeColor = System.Drawing.Color.White;
            appearance9.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance9;
            this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            appearance10.BackColor2 = System.Drawing.Color.White;
            this.ultraGrid1.DisplayLayout.Override.RowAlternateAppearance = appearance10;
            this.ultraGrid1.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid1.DisplayLayout.Override.RowSelectorAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance12.FontData.BoldAsString = "True";
            appearance12.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance12;
            this.ultraGrid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.ultraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraGrid1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ultraGrid1.Location = new System.Drawing.Point(0, 0);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(426, 484);
            this.ultraGrid1.TabIndex = 2;
            this.ultraGrid1.Click += new System.EventHandler(this.ultraGrid1_Click);
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            this.ultraGrid1.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.ultraGrid1_AfterSelectChange);
            this.ultraGrid1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ultraGrid1_KeyPress);
            this.ultraGrid1.DoubleClick += new System.EventHandler(this.ultraGrid1_DoubleClick);
            this.ultraGrid1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ultraGrid1_KeyDown);
            // 
            // splitter1
            // 
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 90);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 484);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(434, 90);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(8, 484);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            // 
            // _TableGuide_Toolbars_Dock_Area_Top
            // 
            this._TableGuide_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._TableGuide_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._TableGuide_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._TableGuide_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._TableGuide_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._TableGuide_Toolbars_Dock_Area_Top.Name = "_TableGuide_Toolbars_Dock_Area_Top";
            this._TableGuide_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(442, 26);
            this._TableGuide_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            appearance13.FontData.BoldAsString = "False";
            appearance13.FontData.SizeInPoints = 10F;
            this.ultraToolbarsManager1.Appearance = appearance13;
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.ImageTransparentColor = System.Drawing.Color.White;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingLocation = new System.Drawing.Point(124, 236);
            ultraToolbar1.FloatingSize = new System.Drawing.Size(259, 26);
            labelTool1.InstanceProps.Spring = Infragistics.Win.DefaultableBoolean.True;
            labelTool1.InstanceProps.Width = 25;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            popupMenuTool1,
            labelTool1});
            appearance14.FontData.SizeInPoints = 10F;
            ultraToolbar1.Settings.Appearance = appearance14;
            ultraToolbar1.Text = "UltraToolbar1";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.Text = "UltraToolbar2";
            ultraToolbar2.Visible = false;
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            this.ultraToolbarsManager1.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            buttonTool4.SharedProps.Caption = "選択(&S)";
            buttonTool4.SharedProps.CustomizerCaption = "選択(&S)";
            buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance15.Image = ((object)(resources.GetObject("appearance15.Image")));
            buttonTool5.SharedProps.AppearancesSmall.Appearance = appearance15;
            buttonTool5.SharedProps.Caption = "検索(&F)";
            buttonTool5.SharedProps.CustomizerCaption = "検索(&F)";
            buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool5.SharedProps.Visible = false;
            buttonTool6.SharedProps.Caption = "戻る(&X)";
            buttonTool6.SharedProps.CustomizerCaption = "戻る(&X)";
            buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool2.SharedProps.Spring = true;
            labelTool3.SharedProps.Caption = "LabelBarLabel2";
            popupMenuTool2.InstanceProps.Caption = "表示切替(&V)";
            popupMenuTool2.InstanceProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            popupMenuTool2.SharedProps.Caption = "表示切替(&V)";
            popupMenuTool2.SharedProps.CustomizerCaption = "表示切替(&V)";
            popupMenuTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            popupMenuTool2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            stateButtonTool1,
            stateButtonTool2});
            stateButtonTool3.SharedProps.Caption = "通常表示";
            stateButtonTool4.SharedProps.Caption = "StateButtonTool2";
            stateButtonTool5.SharedProps.Caption = "全メーカー表示";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5,
            buttonTool6,
            labelTool2,
            labelTool3,
            popupMenuTool2,
            stateButtonTool3,
            stateButtonTool4,
            stateButtonTool5});
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // _TableGuide_Toolbars_Dock_Area_Bottom
            // 
            this._TableGuide_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._TableGuide_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._TableGuide_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._TableGuide_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._TableGuide_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 619);
            this._TableGuide_Toolbars_Dock_Area_Bottom.Name = "_TableGuide_Toolbars_Dock_Area_Bottom";
            this._TableGuide_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(442, 0);
            this._TableGuide_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _TableGuide_Toolbars_Dock_Area_Left
            // 
            this._TableGuide_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._TableGuide_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._TableGuide_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._TableGuide_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._TableGuide_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 26);
            this._TableGuide_Toolbars_Dock_Area_Left.Name = "_TableGuide_Toolbars_Dock_Area_Left";
            this._TableGuide_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 593);
            this._TableGuide_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _TableGuide_Toolbars_Dock_Area_Right
            // 
            this._TableGuide_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._TableGuide_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._TableGuide_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._TableGuide_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._TableGuide_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(442, 26);
            this._TableGuide_Toolbars_Dock_Area_Right.Name = "_TableGuide_Toolbars_Dock_Area_Right";
            this._TableGuide_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 593);
            this._TableGuide_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this.Searchpanel;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tComboEditor
            // 
            this.tComboEditor.ActiveAppearance = appearance3;
            this.tComboEditor.Location = new System.Drawing.Point(192, 12);
            this.tComboEditor.Name = "tComboEditor";
            this.tComboEditor.Size = new System.Drawing.Size(144, 22);
            this.tComboEditor.TabIndex = 0;
            this.tComboEditor.Text = "tComboEditor1";
            this.tComboEditor.Visible = false;
            // 
            // timer_initFocus
            // 
            this.timer_initFocus.Tick += new System.EventHandler(this.timer_initFocus_Tick);
            // 
            // TableGuide
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(442, 619);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._TableGuide_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._TableGuide_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._TableGuide_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._TableGuide_Toolbars_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.KeyPreview = true;
            this.Name = "TableGuide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "選択ガイド-()";
            this.Closed += new System.EventHandler(this.TableGuide_Closed);
            this.Activated += new System.EventHandler(this.TableGuide_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TableGuide_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.MsgPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new TableGuide());
		}

		private void InitForm()
		{
			this._controlScreenSkin = new ControlScreenSkin();
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);

            ultraToolbarsManager1.Toolbars[0].Tools[0].InstanceProps.AppearancesSmall.Appearance.Image = Broadleaf.Library.Resources.IconResourceManagement.ImageList16.Images[12];
            ultraToolbarsManager1.Toolbars[0].Tools[1].InstanceProps.AppearancesSmall.Appearance.Image = Broadleaf.Library.Resources.IconResourceManagement.ImageList16.Images[2];
            ultraToolbarsManager1.Toolbars[0].Tools[2].InstanceProps.AppearancesSmall.Appearance.Image = Broadleaf.Library.Resources.IconResourceManagement.ImageList16.Images[17];
            ultraToolbarsManager1.Toolbars[0].Tools["ViewerSwMenu"].InstanceProps.AppearancesSmall.Appearance.Image = Broadleaf.Library.Resources.IconResourceManagement.ImageList16.Images[87];

			_SelectedDataArray	= new ArrayList();
			_SelectedDataHash	= new Hashtable();
			_MultiSelectedArray = new ArrayList();

			_DataSet			= new DataSet();	

			_NameToKey			= new Hashtable();
			_KeyToName			= new Hashtable();

			// 以下のHashTableは、1つの HashTable + グリッドCol設定クラス にまとめる
			_KeyToType			= new Hashtable();
			_KeyToWidth			= new Hashtable();
			_ThroughSearchInfo  = new Hashtable();
			_KeyToDspFormat     = new Hashtable();
			_KeyToHAlign		= new Hashtable();
            _KeyToDetail        = new Hashtable();
            _KeyToDetail_SW1    = new Hashtable();    
          
			_Resultinfo			= new Hashtable();
			_Searchinfo			= new Hashtable();
			_SearchKey			= new ArrayList();			// 検索条件を生成するキー情報
			_ChildSearchKey		= new ArrayList();			// 子ガイドの検索条件を生成するキー情報
			_ChildResultinfo	= new ArrayList();			// 子ガイドの検索条件を生成するキー情報

			// 起動モードがガイド子画面の場合
			if(_ExecMode == 5) 
			{
                this.FormBorderStyle = FormBorderStyle.None;
				//				panel2.Height     = panel2.Height + ultraToolbarsManager1.Toolbars[0].Height;
				//				MsgLabel1.Left    = MsgLabel1.Left- splitter1.Width;
				splitter1.Width = 3;
				splitter2.Width = 3;
				if(_xPathDocPath == "MAKERNAMEGUIDE.XML")
				{
					ultraToolbarsManager1.Visible = true;
					ultraToolbarsManager1.Enabled = true;
                    ultraToolbarsManager1.Tools["SelectToolBt"].SharedProps.Visible = false;
                    ultraToolbarsManager1.Tools["SelectToolBt"].SharedProps.Enabled = false;
                    ultraToolbarsManager1.Tools["CancelToolBt"].SharedProps.Visible = false;
                    ultraToolbarsManager1.Tools["CancelToolBt"].SharedProps.Enabled = false;
                }
				else
				{
					ultraToolbarsManager1.Visible = false;
					ultraToolbarsManager1.Enabled = false;
				}

				this.ControlBox = false;
			}
            else if (_ExecMode != 0)
            {

                this.FormBorderStyle = FormBorderStyle.None;
                //				panel2.Height     = panel2.Height + ultraToolbarsManager1.Toolbars[0].Height;
                MsgLabel1.Left = MsgLabel1.Left - splitter1.Width;
                splitter1.Visible = false;


                // 各ツールバーボタンの調整
                if (_xPathDocPath == "MAKERNAMEGUIDE.XML")
                {
                    ultraToolbarsManager1.Visible = true;
                    ultraToolbarsManager1.Enabled = true;
                    ultraToolbarsManager1.Tools["ViewerSwMenu"].SharedProps.Visible = true;
                    ultraToolbarsManager1.Tools["ViewerSwMenu"].SharedProps.Enabled = true;
                }
                else
                {
                    ultraToolbarsManager1.Visible = false;
                    ultraToolbarsManager1.Enabled = false;
                    ultraToolbarsManager1.Tools["ViewerSwMenu"].SharedProps.Visible = false;
                    ultraToolbarsManager1.Tools["ViewerSwMenu"].SharedProps.Enabled = false;
                }

                this.ControlBox = false;
            }
            else 
            {
                ultraToolbarsManager1.Visible = true;
                ultraToolbarsManager1.Enabled = true;

                // 各ツールバーボタンの調整
                if (_xPathDocPath == "MAKERNAMEGUIDE.XML")
                {
                    ultraToolbarsManager1.Tools["ViewerSwMenu"].SharedProps.Visible = true;
                    ultraToolbarsManager1.Tools["ViewerSwMenu"].SharedProps.Enabled = true;
                }
                else
                {
                    ultraToolbarsManager1.Tools["ViewerSwMenu"].SharedProps.Visible = false;
                    ultraToolbarsManager1.Tools["ViewerSwMenu"].SharedProps.Enabled = false;
                }
            }

			// ガイド設定ファイルが指定されている場合
			if((!(_xPathDocPath == "")) && (!(_xPathDocPath == null))) 
			{
				// ガイド設定ファイルの読込
				try
				{
					_xmlDoc         = new XmlDocument();
					_xmlDoc.Load(_xPathDocPath);
					//					_xPathDoc       = new XPathDocument(_xPathDocPath);
					//					_xPathNavi      = _xPathDoc.CreateNavigator();
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
					// フォーム全体の設定
					//					_xPathNavi.MoveToRoot();
					//					XPathNodeIterator naviIt = _xPathNavi.Select("//GuideDef/FormTitle");
					//					MessageBox.Show(naviIt.Count.ToString());

					//					if(naviIt.Count > 0)
					//					{
					//						naviIt.MoveNext();
					//						XmlElement naviElem = (XmlElement)((IHasXmlNode)naviIt.Current).GetNode();

					//						MessageBox.Show(naviIt.Current get Value);
					//					}
					XmlElement xmlElem  = _xmlDoc.DocumentElement;
					XmlElement xmlElem2;
					int numTmp = 0;
					// フォームタイトル
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/FormTitle"); 
					if(!(xmlElem2 == null))
					{
						if(xmlElem2.InnerText != "")
						{
							if((_ExecMode == 0) || (_ExecMode == 5))
							{
								this.Text = "選択ガイド - ("+xmlElem2.InnerText+")";
							}
							else
							{
								this.Text = xmlElem2.InnerText;
							}
						}
                    }

                    // 2011/07/11 wangf add start
                    // フォームサーチタイプ
                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/SearchType");
                    int index = 0;
                    XmlNodeList nodeSearchConditionList;
                    XmlNodeList nodeSearchConditionListChild;
                    if (!(xmlElem2 == null))
                    {
                        numTmp = Convert.ToInt32(xmlElem2.InnerText);
                        // -------------ADD 王君 2012/10/22　Redmine#32861--------->>>>>
                        if ("SUPPLIERGUIDE.XML".Equals(_xPathDocPath))
                        {
                            numTmp = 3;
                        }
                        // -------------ADD 王君 2012/10/22　Redmine#32861---------<<<<<
                        if (numTmp == 0)
                        {
                            // サーチ条件ないタイプ
                            // Panel2
                            this.panel2.Size = new Size(442, 25);
                            this.panel2.Location = new Point(0, 26);
                            // SearchPanel
                            this.Searchpanel.Size = new Size(0, 0);
                            this.Searchpanel.Dock = DockStyle.None;
                            this.Searchpanel.Visible = false;
                            // MsgPanel
                            this.MsgPanel.Size = new Size(442, 25);
                            this.MsgPanel.Location = new Point(0, 0);
                            // MsgLabel
                            this.MsgLabel1.Size = new Size(458, 22);
                            this.MsgLabel1.Location = new Point(7, 2);
                            foreach (Control control in this.Searchpanel.Controls)
                            {
                                control.Visible = false;
                            }
                        }
                        else
                        {
                            // サーチ条件ないタイプ
                            // Panel2
                            this.panel2.Size = new Size(442, 51 + 24 * numTmp);
                            this.panel2.Location = new Point(0, 26);
                            // SearchPanel
                            this.Searchpanel.Size = new Size(442, 27 + 24 * numTmp);
                            this.Searchpanel.Location = new Point(0, 0);
                            this.Searchpanel.Dock = DockStyle.Top;
                            this.Searchpanel.Visible = true;
                            // MsgPanel
                            this.MsgPanel.Size = new Size(442, 25);
                            this.MsgPanel.Location = new Point(8, 36 * numTmp);
                            // MsgLabel
                            this.MsgLabel1.Location = new Point(7, 2);

                            nodeSearchConditionList = xmlElem.SelectNodes("/definfo/GuideDef/SearchCondition");
                            int count = 0;    // ADD 王君 2012/10/22 Redmine#32861
                            foreach (XmlNode isbn in nodeSearchConditionList)
                            {
                                string lColName = "";
                                string lColType = "";
                                string lColKey = "";
                                int lColLength = 0;
                                int lColImeMode = 0;
                                nodeSearchConditionListChild = isbn.ChildNodes;
                                foreach (XmlElement iElem in nodeSearchConditionListChild)
                                {
                                    if (!(iElem == null))
                                    {
                                        switch (iElem.Name)
                                        {
                                            case "ColName":
                                                lColName = iElem.InnerText;
                                                break;
                                            case "ColKey":
                                                lColKey = iElem.InnerText;
                                                break;
                                            case "ColLength":
                                                lColLength = Convert.ToInt32(iElem.InnerText);
                                                break;
                                            case "ColImeMode":
                                                lColImeMode = Convert.ToInt32(iElem.InnerText);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                // --------- ADD 王君 2012/10/22 Redmine#32861--------------------->>>>>
                                if ("SUPPLIERGUIDE.XML".Equals(_xPathDocPath))
                                {
                                    if (count < 3)
                                    {
                                        SearchConditionLabelMaker(8, index == 0 ? 20 : 20 + 27 * index, 130, 24, lColKey + "_label", lColName);
                                        if (lColImeMode != 3)
                                        {
                                            SearchConditionTextBoxMaker(140, index == 0 ? 15 : 15 + 27 * index, 113, 24, lColKey + "_textbox", lColLength, index + 1, lColImeMode);
                                        }
                                        else
                                        {
                                            SearchConditionDropMaker(140, index == 0 ? 15 : 15 + 27 * index, 113, 26, lColKey, lColLength, index + 1);
                                        }

                                    }
                                    else
                                    {
                                        SearchConditionLabelMaker(320, 20 + 27 * (count - 3), 80, 24, lColKey + "_label", lColName);
                                        if (lColImeMode != 3)
                                        {
                                            SearchConditionTextBoxMaker(420, 15 + 27 * (count - 3), 140, 24, lColKey + "_textbox", lColLength, index + 1, lColImeMode);
                                        }
                                        else
                                        {
                                            SearchConditionDropMaker(420, 15 + 27 * (count - 3), 140, 26, lColKey, lColLength, index + 1);
                                        }
                                    }
                                    count++;
                                }
                                else
                                {
                                    // --------- ADD 王君 2012/10/22 Redmine#32861---------------------<<<<<
                                    // --- UPD 2011/08/11---------->>>>>
                                    //SearchConditionLabelMaker(8, index == 0 ? 20 : 20 + 27 * index, 113, 24, lColKey + "_label", lColName);
                                    SearchConditionLabelMaker(8, index == 0 ? 20 : 20 + 27 * index, 130, 24, lColKey + "_label", lColName);
                                    //SearchConditionTextBoxMaker(127, index == 0 ? 15 : 15 + 27 * index, 113, 24, lColKey + "_textbox", lColLength, index + 1, lColImeMode);
                                    //SearchConditionTextBoxMaker(140, index == 0 ? 15 : 15 + 27 * index, 113, 24, lColKey + "_textbox", lColLength, index + 1, lColImeMode); // del wangf 2011/08/31
                                    // -- add wangf 2011/08/31 ---------->>>>>
                                    if (lColImeMode != 3)
                                    {
                                        SearchConditionTextBoxMaker(140, index == 0 ? 15 : 15 + 27 * index, 113, 24, lColKey + "_textbox", lColLength, index + 1, lColImeMode);
                                    }
                                    else
                                    {
                                        //SearchConditionDropMaker(140, index == 0 ? 15 : 15 + 27 * index, 113, 24, lColKey, lColLength, index + 1); //del wangf 2011/08/31
                                        SearchConditionDropMaker(140, index == 0 ? 15 : 15 + 27 * index, 113, 26, lColKey, lColLength, index + 1); //add wangf 2011/08/31
                                    }
                                    // -- add wangf 2011/08/31 ----------<<<<<
                                    // --- UPD 2011/08/11----------<<<<<
                                }   // ADD 王君 2012/10/22　Redmine#32861
                                index++;
                            }
                        }
                    }
                    else
                    {
                        // XMLファイル中で、<SearchType>がない時,SearchTypePanelが見えない
                        // Panel2
                        this.panel2.Size = new Size(442, 25);
                        this.panel2.Location = new Point(0, 26);
                        // SearchPanel
                        this.Searchpanel.Size = new Size(0, 0);
                        this.Searchpanel.Dock = DockStyle.None;
                        this.Searchpanel.Visible = false;
                        // MsgPanel
                        this.MsgPanel.Size = new Size(442, 25);
                        this.MsgPanel.Location = new Point(0, 0);
                        // MsgLabel
                        this.MsgLabel1.Size = new Size(458, 22);
                        this.MsgLabel1.Location = new Point(7, 2);
                    }
                    // 2011/07/11 wangf add end
					
					// フォームメッセージ
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/FormMassge"); 
					if(!(xmlElem2 == null))
					{
						MsgLabel1.Text = xmlElem2.InnerText;
					}

					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/FormMessage"); 
					if(!(xmlElem2 == null))
					{
						MsgLabel1.Text = xmlElem2.InnerText;
					}

					// フォームメッセージフォントカラー
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/FormMassgeFontColor"); 
					if(!(xmlElem2 == null))
					{
						MsgLabel1.Appearance.ForeColor =  Color.FromName(xmlElem2.InnerText);
					}

					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/FormMessageFontColor"); 
					if(!(xmlElem2 == null))
					{
						MsgLabel1.Appearance.ForeColor =  Color.FromName(xmlElem2.InnerText);
					}

					// フォームサイズ高さ
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/FormHeight");
					if(!(xmlElem2 == null))
					{
						numTmp = Convert.ToInt32(xmlElem2.InnerText);
						if(numTmp > 20)
						{
							ParentAddHeight = numTmp;
							this.Height = numTmp;
						}
					}

					// フォームサイズ幅
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//GuideDef/FormWidth"); 
					if(!(xmlElem2 == null))
					{
						numTmp = Convert.ToInt32(xmlElem2.InnerText);
						if(numTmp > 20) 
						{	
							this.Width = numTmp;
							ParentAddWidth = numTmp;
						}
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

					#region グリッドの設定 
			
					// マルチセレクタ設定
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//ViewerDef/MultiSelector"); 
					if(!(xmlElem2 == null))
					{
						if(xmlElem2.InnerText.ToUpper() == "TRUE" )
						{
							this.ultraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
							this.MultiSelect = true;
						}
					}

					
					// グリッドフォント
					string fontKind = "ＭＳ ゴシック";
					int    fontSize = 11;	

					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//ViewerDef/Font"); 
					if(!(xmlElem2 == null))
					{
						fontKind	= xmlElem2.InnerText;
					}

					// グリッドフォント
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//ViewerDef/FontSize"); 
					if(!(xmlElem2 == null))
					{
						numTmp = Convert.ToInt32(xmlElem2.InnerText);
						if(numTmp >= 0)
						{
							fontSize	= numTmp;
						}
					}
					
					this.ultraGrid1.Font = new Font(fontKind, fontSize, FontStyle.Regular);  
					//					this.ultraGrid1.Font = new Font("ＭＳ 明朝",11,FontStyle.Regular);  


					// グリッドの設定
					//					ultraGrid1.DisplayLayout.AutoFitColumns = false;
					//					ultraGrid1.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free;
					ultraDataSource1.Band.Columns.Clear();
					//					ultraGrid1.DisplayLayout.Bands[0].Columns[0].AutoSizeMode = ColumnAutoSizeMode.None;
					
					XmlNodeList nodeList;
					XmlNodeList nodeListChild;

					nodeList = xmlElem.SelectNodes("/definfo/ViewerDef/ViewerInfo");
					foreach (XmlNode isbn in nodeList)
					{
						string lColName = "";
						string lColType = "";
						string lColKey = "";
						int    lColWidth = 0;
						string lColDspFormat = "";
						string lColHAlign    = "";
						//xmlElem2 = (XmlElement)isbn.FirstChild; // SelectSingleNode("//ColName");
						nodeListChild = isbn.ChildNodes;

						int idx = 0;				
						foreach (XmlElement iElem in nodeListChild)
						{
							if(!(iElem == null))
							{

								switch(iElem.Name)
								{
									case "ColName":   
										lColName = iElem.InnerText;
										break;
									case "ColKey":   
										lColKey = iElem.InnerText;
										break;
									case "ColWith":   
										lColWidth = Convert.ToInt32(iElem.InnerText);
										break;
									case "ColDataType":   
										lColType = iElem.InnerText;
										break;
									case "ColDspFormat":   
										lColDspFormat = iElem.InnerText;
										break;
									case "ColHAlign":   
										lColHAlign = iElem.InnerText;
										break;

									default:
										break;
								}
							}
						}

						// 列情報設定
						if ((!(lColName == "")) &&  (!(lColType == "")))
						{
							//							ultraDataSource1.Band.Columns.Add(lColName, typeof(string));
						
							switch(lColType)
							{
								case "string":   // 文字
									ultraDataSource1.Band.Columns.Add(lColName, typeof(string));
									break;
								case "int":   // 数字
									ultraDataSource1.Band.Columns.Add(lColName, typeof(int));
									break;
								case "double":   // 数字
									ultraDataSource1.Band.Columns.Add(lColName, typeof(double));
									break;
								case "Int32":   // 数字
									ultraDataSource1.Band.Columns.Add(lColName, typeof(int));
									break;
								case "Int64":   // 数字
									ultraDataSource1.Band.Columns.Add(lColName, typeof(Int64));
									break;
								case "DateTime":   // 日付
									ultraDataSource1.Band.Columns.Add(lColName, typeof(DateTime));
									break;
								case "String":   // 文字
									ultraDataSource1.Band.Columns.Add(lColName, typeof(string));
									break;
								case "Double":   // 数字
									ultraDataSource1.Band.Columns.Add(lColName, typeof(double));
									break;
								case "Int":   // 数字
									ultraDataSource1.Band.Columns.Add(lColName, typeof(int));
									break;

								default:
									ultraDataSource1.Band.Columns.Add(lColName, typeof(string));
									break;
							}
							
							ultraGrid1.DataSource = ultraDataSource1;
						}

						if ((!(lColKey == "")) &&  (!(lColName == "")))
						{
							_NameToKey.Add(lColName, lColKey);
							_KeyToName.Add(lColKey, lColName);
							_KeyToType.Add(lColKey, lColType);
							_KeyToWidth.Add(lColName, lColWidth);
							//							MessageBox.Show(lColKey+","+lColDspFormat+","+lColHAlign);
							_KeyToDspFormat.Add(lColKey, lColDspFormat);
							_KeyToHAlign.Add(lColKey, lColHAlign);


                            GuideTermInfo objTmp = new GuideTermInfo(lColKey, idx, lColName, lColType, lColWidth, lColHAlign);
                            _KeyToDetail.Add(lColKey, objTmp);
                        
                        }

						if (lColWidth >= 10) 
						{
							ultraGrid1.DisplayLayout.Bands[0].Columns[lColName].Width = lColWidth;
						}

						/*						_SelectedData = new ArrayList();
												_DataSet	  = new DataSet();	
												_Resultinfo   = new ArrayList();
												_Searchinfo   = new ArrayList(); */
						idx++;
					}

                    nodeList = xmlElem.SelectNodes("/definfo/ViewerDef_SW1/ViewerInfo");
                    foreach (XmlNode isbn in nodeList)
                    {
                        string lColName = "";
                        string lColType = "";
                        string lColKey = "";
                        int lColWidth = 0;
                        string lColDspFormat = "";
                        string lColHAlign = "";
                        //xmlElem2 = (XmlElement)isbn.FirstChild; // SelectSingleNode("//ColName");
                        nodeListChild = isbn.ChildNodes;

                        int idx = 0;
                        foreach (XmlElement iElem in nodeListChild)
                        {
                            if (!(iElem == null))
                            {

                                switch (iElem.Name)
                                {
                                    case "ColName":
                                        lColName = iElem.InnerText;
                                        break;
                                    case "ColKey":
                                        lColKey = iElem.InnerText;
                                        break;
                                    case "ColWith":
                                        lColWidth = Convert.ToInt32(iElem.InnerText);
                                        break;
                                    case "ColDataType":
                                        lColType = iElem.InnerText;
                                        break;
                                    case "ColDspFormat":
                                        lColDspFormat = iElem.InnerText;
                                        break;
                                    case "ColHAlign":
                                        lColHAlign = iElem.InnerText;
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }


                        if ((!(lColKey == "")) && (!(lColName == "")))
                        {
                            GuideTermInfo objTmp = new GuideTermInfo(lColKey, idx, lColName, lColType, lColWidth, lColHAlign);
                            _KeyToDetail_SW1.Add(lColKey, objTmp);
                        }

                        idx++;
                    }


					
					// Grid固定行のカラー設定
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//ViewerDef/ViewerFixdRowBackColor1"); 
					if(!(xmlElem2 == null))
					{
						ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromName(xmlElem2.InnerText);
					}

					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//ViewerDef/ViewerFixdRowBackColor2"); 
					if(!(xmlElem2 == null))
					{
						ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromName(xmlElem2.InnerText);
					}

					// Grid固定行フォントのカラー設定
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//ViewerDef/ViewerFixdRowFontColor"); 
					if(!(xmlElem2 == null))
					{
						ultraGrid1.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.FromName(xmlElem2.InnerText);
					}

					// Grid選択行のカラー設定
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//ViewerDef/SelectedRowBackColor1"); 
					if(!(xmlElem2 == null))
					{
						ultraGrid1.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromName(xmlElem2.InnerText);
					}

					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//ViewerDef/SelectedRowBackColor2"); 
					if(!(xmlElem2 == null))
					{
						ultraGrid1.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.FromName(xmlElem2.InnerText);
					}

					// Grid選択行フォントのカラー設定
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//ViewerDef/SelectedRowFontColor"); 
					if(!(xmlElem2 == null))
					{
						ultraGrid1.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.FromName(xmlElem2.InnerText);
					}

					// Grid偶数行のカラー設定
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//ViewerDef/ViewerRowAlternateColor"); 
					if(!(xmlElem2 == null))
					{
						ultraGrid1.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.FromName(xmlElem2.InnerText);
					}
					
					// Grid固定列のカラー設定
					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//ViewerDef/ViewerFixdColBackColor1"); 
					if(!(xmlElem2 == null))
					{
						ultraGrid1.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromName(xmlElem2.InnerText);
					}

					xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//ViewerDef/ViewerFixdColBackColor2"); 
					if(!(xmlElem2 == null))
					{
						ultraGrid1.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromName(xmlElem2.InnerText);
					}

					#endregion グリッドの設定 
							
					#region 検索条件の設定 

					// 検索条件の設定
					nodeList = xmlElem.SelectNodes("/definfo/SearchDef/SerchName");
					if(nodeList[0] != null)
					{
						_SerchClassName = ((XmlNode)nodeList[0]).InnerText; // 一覧表データ生成対象のクラス名称 
					}

					// 検索メソッドを実装するクラスのアセンブリ設定
					nodeList = xmlElem.SelectNodes("/definfo/SearchDef/SerchAssm");
					if(nodeList[0] != null)
					{
						_SerchAssemblyName = ((XmlNode)nodeList[0]).InnerText; // 一覧表データ生成対象のクラスを実装するアセンブリ 
					}

					nodeList = xmlElem.SelectNodes("/definfo/SearchDef/SerchInfoRoot/SerchInfo");
					foreach (XmlNode isbn in nodeList)
					{
						_Searchinfo.Add(isbn.InnerText, "");  // 検索条件を生成するキー情報のリスト
						_SearchKey.Add(isbn.InnerText);
					}

					#endregion 検索条件の設定 

					#region 選択結果の設定 
					// 選択結果の設定(選択結果を返す項目設定)
					nodeList = xmlElem.SelectNodes("/definfo/SelectedInfoDef/SelectedInfo");
					int iCnt = 0;
					foreach (XmlNode isbn in nodeList)
					{
						//						MessageBox.Show(isbn.InnerText);
						_Resultinfo.Add(isbn.InnerText, iCnt);
						iCnt++;
					}

					#endregion 選択結果の設定 
				
					#region 親コントロールの検索条件をスルーする項目の設定 
					// 親コントロールの検索条件をスルーする項目の設定
					nodeList = xmlElem.SelectNodes("/definfo/ThroughSearchInfoDef/ThroughSearchInfo");
					iCnt = 0;
					foreach (XmlNode isbn in nodeList)
					{
						_ThroughSearchInfo.Add(isbn.InnerText, iCnt);
						iCnt++;
					}

					#endregion 親コントロールの検索条件をスルーする項目の設定 
				}

			}

			if (!(_StyleMode == 1))
			{
				panel4.Visible = false;
				panel1.Height  = 8;
			}
			else
			{
				panel2.Height  = 2;
			}

			ParentAddHeight = this.Height;
			ParentAddWidth = this.Width;
		}
		
		/// <summary>
		/// ガイドフォーム起動
		/// </summary>
		/*		public bool Execute(object serchInfo, ref object returnInfo)
				{
					_ParentSerchInfo = serchInfo;
					// 一覧情報をグリッドへ表示
					if(_ExecMode == 0)
					{
						this.ShowDialog();  	
						returnInfo = null;
						return _ResultStatus;
					}
					else
					{
						this.Show(); 
						//				ParentAddHeight = this.Height;
						//				ParentAddWidth = this.Width;
						return _ResultStatus;
					}
				} */

		/// <summary>
		/// ガイドフォーム起動
		/// </summary>
		public bool Execute(int mode, object serchInfo, ref ArrayList returnInfo)
		{
			_ParentSerchInfo = serchInfo;

			// 一覧情報の呼び出し
			//			MessageBox.Show("IN Array !!");
			if(mode != 999)
			{
				GetGuideData(serchInfo);
			}
			// 一覧情報をグリッドへ表示
			if(_ExecMode == 0)
			{
				this.ShowDialog();  	
				returnInfo = _SelectedDataArray;
				return _ResultStatus;
			}
			else
			{
				this.Show();
                this.timer_initFocus.Enabled = true;　// ADD 2011/08/11
				return _ResultStatus;
			}
		}

		/// <summary>
		/// ガイドフォーム起動
		/// </summary>
		public bool Execute(int mode, object serchInfo, ref Hashtable returnInfo)
		{
			_ParentSerchInfo = serchInfo;

			//			MessageBox.Show("IN Hash !!");
			// 一覧情報の呼び出し
			if(mode != 999)
			{
                GetGuideData(serchInfo);
            }

			// 一覧情報をグリッドへ表示
			if(_ExecMode == 0)
			{
                this.ShowDialog();
                returnInfo = _SelectedDataHash;
                return _ResultStatus;
			}
			else
			{
				this.Show();
                this.timer_initFocus.Enabled = true;　// ADD 2011/08/11
				return _ResultStatus;
			}

		}

		/// <summary>
		/// ガイドフォーム起動
		/// </summary>
		public bool Execute(int mode, object serchInfo, ref DataSet returnInfo)
		{
			_ParentSerchInfo = serchInfo;

			if(_ExecMode == 0)
			{
				this.ShowDialog();  	
				returnInfo = null; //_SelectedDataArray;
				return _ResultStatus;
			}
			else
			{
				this.Show();
                this.timer_initFocus.Enabled = true;　// ADD 2011/08/11
				//				ParentAddHeight = this.Height;
				//				ParentAddWidth = this.Width;
				return _ResultStatus;
			}
		}

		/// <summary>
		/// ガイドフォーム起動(複数選択ガイド)
		/// </summary>
		public bool ExecuteMultiSelector(int mode, object serchInfo, ref ArrayList returnInfo)
		{
			_ParentSerchInfo = serchInfo;

			//			MessageBox.Show("IN Hash !!");
			// 一覧情報の呼び出し
			if(mode != 999)
			{
				GetGuideData(serchInfo);
			}

			// 一覧情報をグリッドへ表示
			if(_ExecMode == 0)
			{
				this.ShowDialog();  	
				returnInfo = _MultiSelectedArray;
				return _ResultStatus;
			}
			else
			{
				this.Show();
                this.timer_initFocus.Enabled = true;　// ADD 2011/08/11
				return _ResultStatus;
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
			if(_ExecMode == 0)
			{
				// 現在選択されている行のリストを作成する
				if (!(ultraGrid1.Selected.Rows.Count <= 0))
				{
					SelectGuideDataToList();
					_ResultStatus = true;
					this.Close();
				}
				else
				{
					_ResultStatus = false;
					this.Close();
				}
			}
			else
			{
				// 子ガイドモードの場合は、最上位ガイドの選択処理を実行
				if(_TopParentGuide != null)
				{
					// 最上位ガイド操作インタフェースを取得
					//				IGeneralGuidOperable plugIn = (TableGuideParent)_TopParentGuide as IGeneralGuidOperable;
					IGeneralGuideOperable plugIn = _TopParentGuide as IGeneralGuideOperable;
					if (plugIn != null)
					{
						plugIn.SelectGuideData(0, 0);
					}
				}
			}
		}


		/// <summary>
		/// グリッドダブルクリック-->選択処理イベント
		/// </summary>
		private void ultraGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			// マウスポインタがグリッドのどの位置にあるかを判定する
			Point point = System.Windows.Forms.Cursor.Position;
			point = this.ultraGrid1.PointToClient(point);
			Infragistics.Win.UIElement objElement = null;
			Infragistics.Win.UltraWinGrid.RowCellAreaUIElement	objRowCellAreaUIElement = null;
			objElement = this.ultraGrid1.DisplayLayout.UIElement.ElementFromPoint(point);

			objRowCellAreaUIElement= (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
				(typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

			// ヘッダ部の場合は以下の処理をキャンセルします。
			if(objRowCellAreaUIElement != null)
			{
				if(_ExecMode == 0)
				{
					// 現在選択されている行のリストを作成する
					if (!(ultraGrid1.Selected.Rows.Count <= 0))
					{
						SelectGuideDataToList();
						_ResultStatus = true;
						this.Close();
					}
				}
				else
				{
					// 子ガイドモードの場合は、最上位ガイドの選択処理を実行
					if(_TopParentGuide != null)
					{
						// 最上位ガイド操作インタフェースを取得
						//				IGeneralGuidOperable plugIn = (TableGuideParent)_TopParentGuide as IGeneralGuidOperable;
						IGeneralGuideOperable plugIn = _TopParentGuide as IGeneralGuideOperable;
						if (plugIn != null)
						{
							plugIn.SelectGuideData(0, 0);
						}
					}
				}
			}
		}
	

		/// <summary>
		/// 選択された行の要素をリスト化する
		/// </summary>
		private void SelectGuideDataToList()
		{
			// 現在保持している選択情報を削除する
			_SelectedDataArray.Clear();
			_SelectedDataHash.Clear();
			_MultiSelectedArray.Clear();

            if (ultraGrid1.Selected.Rows.Count > 0)
            {
                if (ultraGrid1.Selected.Rows[0].Cells.Count > 0)
                {

                    // 選択行数分ループする
                    for (int jdx = 0; jdx < ultraGrid1.Selected.Rows.Count; jdx++)
                    {
                        ArrayList alTmp;
                        Hashtable htTmp;

                        alTmp = new ArrayList();
                        htTmp = new Hashtable();

                        for (int idx = 0; idx < ultraGrid1.Selected.Rows[0].Cells.Count; idx++)
                        {
                            // 選択結果設定情報を基に返す項目を選別する
                            if (jdx.Equals(0))
                            {
                                // 0番目の選択行はシングルセレクタ用に別に保持する	
                                if (_Resultinfo[ultraGrid1.Selected.Rows[0].Cells[idx].Column.Key] != null)
                                {
                                    _SelectedDataArray.Add(ultraGrid1.Selected.Rows[0].Cells[idx].Value);
                                    _SelectedDataHash.Add(ultraGrid1.Selected.Rows[0].Cells[idx].Column.Key, ultraGrid1.Selected.Rows[0].Cells[idx].Value);
                                    alTmp.Add(ultraGrid1.Selected.Rows[0].Cells[idx].Value);
                                    htTmp.Add(ultraGrid1.Selected.Rows[0].Cells[idx].Column.Key, ultraGrid1.Selected.Rows[0].Cells[idx].Value);
                                }
                            }
                            else
                            {
                                // 0番目の選択行はシングルセレクタ用に別に保持する	
                                if (_Resultinfo[ultraGrid1.Selected.Rows[0].Cells[idx].Column.Key] != null)
                                {
                                    alTmp.Add(ultraGrid1.Selected.Rows[jdx].Cells[idx].Value);
                                    htTmp.Add(ultraGrid1.Selected.Rows[jdx].Cells[idx].Column.Key, ultraGrid1.Selected.Rows[jdx].Cells[idx].Value);
                                }
                            }
                        }

                        if (htTmp.Count > 0)
                        {
                            _MultiSelectedArray.Add(htTmp);
                        }
                    }
                }
            }
            else
            {
                // 選択データを返す設定で、データが選択されていない場合はエラーを返す
                if (_Resultinfo.Count > 0)
                {
                    _SelectedDataHash.Add("_SELECT_ERROR", "SELECT_NON");
                }
            }
		}

		/// <summary>
		/// ツールバー ボタンクリック
		/// </summary>
		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
//			if(sender == ultraToolbarsManager1.Tools stateButtonTool1)
//				MessageBox.Show(e.Tool.Key);

			switch(e.Tool.Key) // Tool.Index)
			{
				case "SelectToolBt"://0:   // 選択
					SelectButton_Click(sender, e);
					break;
				case "FindToolBt"://1:   // 検索
					break;
				case "CancelToolBt"://2:	  // キャンセル
					CancelButton_Click(sender, e);
					break;
				case "StateButtonTool1":  // 表示切替1
					_ViewerMode = 0;
                    _ViewerSWIndex = 0;
                    GetGuideData(_ParentSerchInfo);
					break;
				case "StateButtonTool3":  // 表示切替2
					_ViewerMode = 5;
                    _ViewerSWIndex = 1;
                    GetGuideData(_ParentSerchInfo);
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// メッセージパネルのりサイズ
		/// </summary>
		private void MsgPanel_Resize(object sender, System.EventArgs e)
		{
			MsgLabel1.Width = MsgPanel.Width - 15; 
		}

		private void ultraGrid1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			switch(e.KeyChar)
			{
                //case (char)13:							// Enterキー        // 2011/07/11 del wangf
                //    SelectButton_Click(sender, e);		// 選択ボタンを実行	// 2011/07/11 del wangf
                //    break;                                                  // 2011/07/11 del wangf
                // --- ADD 2011/08/11---------->>>>>
                case (char)13:
                    SelectButton_Click(sender, e);		// 選択ボタンを実行
                    break;
                // --- ADD 2011/08/11----------<<<<<

                //case (char)37:							// 左矢印キー
                //    ChangeFocus(EnumGeneralGuideFocusDirection.Left, this.ChildGuideIndex);	
                //    break;
                //case (char)39:							// 右矢印キー
                //    ChangeFocus(EnumGeneralGuideFocusDirection.Right, this.ChildGuideIndex);
                //    break;

                default:
					break;
			}
		}


        private void ultraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:     // 左矢印キー
                    ChangeFocus(EnumGeneralGuideFocusDirection.Left, this.ChildGuideIndex);
                    e.Handled = true;
                    break;
                case Keys.Right:     // 右矢印キー
                    ChangeFocus(EnumGeneralGuideFocusDirection.Right, this.ChildGuideIndex);
                    e.Handled = true;
                    break;

                default:
                    break;
            }
        }


		/// <summary>
		/// ガイド表示リスト取得
		/// </summary>
		public int GetGuideData()
		{
			return GetGuideData(null);
		}

		/// <summary>
		/// ガイドリスト表示
		/// </summary>
		public int GetGuideData(object parentSerchInfo)
		{
			_ParentSerchInfo = parentSerchInfo;
			// 一覧抽出条件の生成
			if(_ParentSerchInfo != null) 
			{
				if((_ParentSerchInfo is ArrayList) && ((ArrayList)_ParentSerchInfo).Count > 0)
				{
					ArrayList ArrayTmp = (ArrayList)_ParentSerchInfo;
					// キー情報の転記
					for(int idx=0; idx <= ArrayTmp.Count-1; idx++)
					{
						_Searchinfo[_SearchKey[idx]] = ArrayTmp[idx];
					}
				}
				else if((_ParentSerchInfo is Hashtable)  && ((Hashtable)_ParentSerchInfo).Count > 0)
				{
					Hashtable HashTmp = (Hashtable)_ParentSerchInfo;
					// キー情報の転記
					for(int idx=0; idx <= _SearchKey.Count-1; idx++)
					{
						if(HashTmp.ContainsKey(_SearchKey[idx]) &&  _Searchinfo.ContainsKey(_SearchKey[idx]))
						{
							_Searchinfo[_SearchKey[idx]] = HashTmp[_SearchKey[idx]];
						}
					}
				}
				else if(_ParentSerchInfo is DataSet)
				{

				}
				else
				{

				}
			}
			else 
			{
				//				_Searchinfo
			}
 
			// 検索条件ハッシュテーブルを生成して、検索クラス名称と一緒に送信

			// 一覧ガイドリスト取得クラス生成&リスト取得
			TableListServer tableListServer = new TableListServer();
			_DataSet.Clear();

			// 検索情報にガイド制御用の情報を付加する
			if(_Searchinfo.ContainsKey("CMN00202_GETMODE"))
			{
				_Searchinfo["CMN00202_GETMODE"] = _ViewerMode;
			}
			else
			{
				_Searchinfo.Add("CMN00202_GETMODE", _ViewerMode);
			}

			int status = 0;
			if(_SerchAssemblyName != "")
			{
                status = tableListServer.GetTableList(_SerchAssemblyName, _SerchClassName, _Searchinfo, ref _DataSet);
			}
			else
			{
                status = tableListServer.GetTableList(_SerchClassName, _Searchinfo, ref _DataSet);
			}

            // 受取ったリストを表示
			if (status == 0)
			{
                ToViewerGrid(0, _DataSet);
            }
			else if (status == 4)
			{
				MessageBox.Show("選択対象データがありません");
			}

			return 0;
		}
		
		/// <summary>
		/// グリッド表示処理
		/// </summary>
		private void ToViewerGrid(DataSet dataSet, object parentSerchInfo)
		{
			ToViewerGrid(5, dataSet);

			// 表示内容に指定データが含まれている場合は該当行を選択する
			if(ultraGrid1.Rows.Count > 0)
			{
				ultraGrid1.Rows[0].Selected = true;
			}
		}
		
		/// <summary>
		/// グリッド表示処理
		/// </summary>
		private void ToViewerGrid(int mode, DataSet dataSet)
		{
			//			DataSet ds = new DataSet();
			ultraGrid1.DataSource = null;
			ultraGrid1.Refresh();
            ultraGrid1.DataSource = dataSet;
			ultraGrid1.Refresh();

			// 列情報の変更(列名、表示・非表示、編集式等の変更)
			/*			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in ultraGrid1.DisplayLayout.Bands[0].Columns) 
						{
							if(_KeyToName[column.Key] != null)
							{
								column.Header.Caption = _KeyToName[column.Key].ToString();
								string lColType = _KeyToType[column.Key].ToString();
					

			//					if(_KeyToWidth.ContainsKey(column.Key))
			//					{
									column.Width    = (int)_KeyToWidth[_KeyToName[column.Key].ToString()];
			//					}
								if(_KeyToDspFormat.ContainsKey(column.Key))
								{
			//						MessageBox.Show(_KeyToDspFormat[column.Key].ToString());
									column.Format   = _KeyToDspFormat[column.Key].ToString(); 
								}

				
								if(_KeyToHAlign.ContainsKey(column.Key))
								{

						
									switch(_KeyToHAlign[column.Key].ToString())
									{
										case "Right": 
											column.CellAppearance.TextHAlign  =  Infragistics.Win.HAlign.Right; 
											break;
										case "Left":  
											column.CellAppearance.TextHAlign  =  Infragistics.Win.HAlign.Left; 
											break;
										case "Center":  
											column.CellAppearance.TextHAlign  =  Infragistics.Win.HAlign.Center; 
											break;
										default:
											column.CellAppearance.TextHAlign  =  Infragistics.Win.HAlign.Default; 
											break;
									}

								}


							}
							else
							{
								column.Hidden = true;
							}
						} */

			if((mode == 0) && (ultraGrid1.Rows.Count > 0))
			{
				ultraGrid1.Rows[0].Selected = true;
			}
			ultraGrid1.Refresh();

		}

		#region デバッグ1 
		private void label1_Click_1(object sender, System.EventArgs e)
		{
			// 子画面を連結して表示
			
			//			_ChildGuide = new TableGuide("WORKERGUIDE.XML", 10);
			//			_ChildGuide.MdiParent = this.MdiParent;
			//			_ChildGuide.Dock   = DockStyle.Left;
			//			_ChildGuide.Execute(_ChildSearchKey, ref _ChildResultinfo);

			//			MessageBox.Show("Load!");
			/*			Guid guid = new Guid("936da01f-9abd-4d9d-80c7-02af85c822b0");
						ArrayList al = new ArrayList();
						WorkerAcs workerAcs = new WorkerAcs();


			//			int status = workerAcs.SearchWorkerDS(ref _DataSet, guid);

						bool nextData;

						int retTotalCnt;
						int status = workerAcs.SearchSpecificationWorkerDS(ref _DataSet,out retTotalCnt,out nextData,guid,100, null);
			//			MessageBox.Show("Load end");

						if (status == 0)
						{
							ultraGrid1.DataSource = _DataSet ;

							// 列情報の変更(列名、表示・非表示、編集式等の変更)
							foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in ultraGrid1.DisplayLayout.Bands[0].Columns) 
							{
			//					_NameToKey;
			//					_KeyToName;

								if(_KeyToName[column.Key] != null)
								{
									column.Header.Caption = _KeyToName[column.Key].ToString();
								}
								else
								{
			//						column.Hidden = true;
								}
							}
						}
			*/
		}
		#endregion デバッグ1 

		#region デバッグ2 
		private void label2_Click(object sender, System.EventArgs e)
		{
			// デバッグ用
			string[] str = {"", "", ""};
			object[] obj = {0, "", ""};

			str[0] = "10";
			str[1] = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
			str[2] = "bbb";

			obj[0] = 10;
			obj[1] = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
			obj[2] = "bbb";

			ultraDataSource1.Rows.Add(obj);

			str[0] = "05";
			str[1] = "cccc";
			str[2] = "mmm";
			
			obj[0] = 5;
			obj[1] = "cccc";
			obj[2] = "mmm";

			ultraDataSource1.Rows.Add(obj);

			str[0] = "99";
			str[1] = "bbb";
			str[2] = "abb";
			
			obj[0] = 99;
			obj[1] = "bbb";
			obj[2] = "abb";

			ultraDataSource1.Rows.Add(obj);
			//			ultraGrid1.DisplayLayout.AutoFitColumns = false;
			//			ultraGrid1.DisplayLayout.AutoFitColumns = true;
			//			ultraGrid1.DataSource = ultraDataSource1;
			ultraGrid1.Refresh();
		}
		#endregion デバッグ2

		#region デバッグ3 
		private void label3_Click(object sender, System.EventArgs e)
		{
			//			if(_ChildGuide != null)
			//				_ChildGuide.BringToFront(); // UpdateZOrder();

			//			this
		}
		#endregion デバッグ3 

		private void TableGuide_Activated(object sender, System.EventArgs e)
		{
		}

		private void TableGuide_Closed(object sender, System.EventArgs e)
		{
		}

		/// <summary>
		/// デフォルト コンストタクタ
		/// </summary>
		public int SelectData(ref ArrayList returnInfo)
		{
			SelectGuideDataToList();
			//			returnInfo = _SelectedDataArray;
			// 子ガイドをもっている場合は、子ガイドのSelectDataを呼び出して結果を連結する
			//			if(_ChildGuide != null)
			if((IGeneralChildGuide)_ChildGuide != null)
			{
				ArrayList returnInfoTmp = new ArrayList();
				object returnInfoTmpObj = (object)returnInfoTmp;
				//				int st = _ChildGuide.SelectData(ref returnInfoTmp);
				int st = ((IGeneralChildGuide)_ChildGuide).SelectChildGuideData(0, ref returnInfoTmpObj);

				if(st == 0)
				{
					returnInfoTmp = (ArrayList)returnInfoTmpObj;
					for(int idx=0; idx < returnInfoTmp.Count; idx++) 
					{				
						_SelectedDataArray.Add(returnInfoTmp[idx]);
					}
				}
			}		
			returnInfo = _SelectedDataArray;

			// ガイドをクローズする
			this.Close();
			return 0;	
		}

		/// <summary>
		/// デフォルト コンストタクタ
		/// </summary>
		public int SelectData(ref Hashtable returnInfo)
		{
			SelectGuideDataToList();
			// 子ガイドをもっている場合は、子ガイドのSelectDataを呼び出して結果を連結する
			//			if(_ChildGuide != null)
			if((IGeneralChildGuide)_ChildGuide != null)
			{
				Hashtable returnInfoTmp = new Hashtable();
				//				int st = _ChildGuide.SelectData(ref returnInfoTmp);
				object returnInfoObj = (object)returnInfoTmp;
				int st = ((IGeneralChildGuide)_ChildGuide).SelectChildGuideData(0, ref returnInfoObj);

				if(st == 0)
				{
					returnInfoTmp = (Hashtable)returnInfoObj;

					// エントリ（キーと値）の列挙
					foreach (DictionaryEntry retData in returnInfoTmp) 
					{
						// キーの存在チェック
						if (!_SelectedDataHash.ContainsKey(retData.Key)) 
						{
							_SelectedDataHash.Add(retData.Key, retData.Value);
						}
						else
						{
							_SelectedDataHash[retData.Key] = retData.Value;
						}
					}
				}
			}		
			returnInfo = _SelectedDataHash;

			// ガイドをクローズする
			this.Close();
			return 0;	
		}

		/// <summary>
		/// 一覧グリッドクリックイベント                               
		/// </summary>
		/// <param name="sender">イベントソース</param>              
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : 一覧表示グリッドクリック時に発生します</br>  
		/// <br>Programmer  : 980056 R.Sokei</br>    
		/// <br>Date        : 2005.03.20</br>           
		/// </remarks>		
		private void ultraGrid1_Click(object sender, System.EventArgs e)
		{

		}

		/// <summary>
		/// 一覧グリッド選択行変更イベント                               
		/// </summary>
		/// <param name="sender">イベントソース</param>              
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : 一覧グリッドの選択行変更時に発生します</br>  
		/// <br>Programmer  : 980056 R.Sokei</br>    
		/// <br>Date        : 2005.03.20</br>           
		/// </remarks>		
		private void ultraGrid1_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			// 子ガイドがある場合は子ガイドのリストを再取得する
			// 子ガイドをもっている場合は、子ガイドのSelectDataを呼び出して結果を連結する
			//			if(_ChildGuide != null)
			if((IGeneralChildGuide)_ChildGuide != null)
			{
				// 現在選択情報を作成
				SelectGuideDataToList();

				// 現在選択情報に親ガイドの選択情報をADD
				AddThroughSearchInfoToSelectDataList();

				// 上記情報をキーに子ガイドを呼び出し
				//				_ChildGuide.GetGuideData(_SelectedDataHash);
				((IGeneralChildGuide)_ChildGuide).LoadChildGuideData(0, _SelectedDataHash);
			}
		
		}

		#region IGeneralChildGuide メンバ

		private void AddThroughSearchInfoToSelectDataList()
		{
			//		_SelectedDataHash
			//		_ParentSerchInfo
			//		_ThroughSearchInfo
						
			//			foreach lkey 
			//			HashTable		
			if(_ParentSerchInfo is Hashtable)
			{
				Hashtable HashTmp = (Hashtable)_ParentSerchInfo;
				// キーと値の一覧を出力
				foreach(object key in _ThroughSearchInfo.Keys)
				{

					// 既に選択条件として選択されていない場合
					if(!_SelectedDataHash.ContainsKey(key.ToString()))
					{
					
						if(HashTmp.ContainsKey(key.ToString()))
						{
							_SelectedDataHash.Add(key.ToString(), HashTmp[key.ToString()]);
							//							MessageBox.Show(key.ToString()+","+((string)HashTmp[key.ToString()]));
						}
					}
				}
			}
		
		}

		
		public object ChildGuideObj
		{
			// TODO:  TableGuide.ChildGuideObj getter 実装を追加します。
			get
			{
				return (object)_ChildGuide;
			}

			// TODO:  TableGuide.ChildGuideObj setter 実装を追加します。
			set
			{
				_ChildGuide = (object)value;
			}
		}

		public object TopParentGuideObj
		{
			get
			{
				return (object)_TopParentGuide;
				// TODO:  TableGuide.TopParentGuideObj getter 実装を追加します。
			}
			set
			{
				// TODO:  TableGuide.TopParentGuideObj setter 実装を追加します。
				_TopParentGuide = value;
			}
		}

		public int ParentAddWidth
		{
			// TODO:  TableGuide.ParentAddSizeWidth getter 実装を追加します。
			get{return _ParentAddWidth;}
			// TODO:  TableGuide.ParentAddSizeWidth setter 実装を追加します。
			set{_ParentAddWidth = value;}		
		}

		public int ParentAddHeight
		{
			// TODO:  TableGuide.ParentAddHeight getter 実装を追加します。
			get{return _ParentAddHeight;}
			// TODO:  TableGuide.ParentAddHeight setter 実装を追加します。
			set{_ParentAddHeight = value;}		
		}
		
		private bool _HasGuidePropartyInfo = false;
		public bool HasGuidePropartyInfo
		{
			// TODO:  TableGuide.ParentAddHeight getter 実装を追加します。
			get{return _HasGuidePropartyInfo;}
			// TODO:  TableGuide.ParentAddHeight setter 実装を追加します。
			set{_HasGuidePropartyInfo = value;}		
		}

		public int LoadChildGuideData(int mode, object parentSerchInfo)
		{
            // --- ADD 2011/08/11---------->>>>>
            //  子ガイド検索前時にフィルター条件空白にセットしました
            foreach (Control ctrl in this.Searchpanel.Controls)
            {
                if (ctrl.GetType().ToString().Equals("Infragistics.Win.Misc.UltraLabel"))
                {
                    continue;
                }
                // -- add wangf 2011/08/03 ---------->>>>>
                else if (ctrl.GetType().ToString().Equals("Broadleaf.Library.Windows.Forms.TComboEditor"))
                {
                    //((TComboEditor)ctrl).SelectedIndex = 3; // del wangf 2011/09/02
                    ((TComboEditor)ctrl).SelectedIndex = 0; // add wangf 2011/09/02
                    continue;
                }
                // -- add wangf 2011/08/03 ----------<<<<<
                ctrl.Text = string.Empty;
            }
            // --- ADD 2011/08/11----------<<<<<
			// TODO:  TableGuide.LoadChildGuideData 実装を追加します。
			return GetGuideData(parentSerchInfo);
		}


		public bool ExecuteChildGuide(int mode, object serchInfo, ref object returnInfo)
		{
			// TODO:  TableGuide.ExecuteChildGuide 実装を追加します。
			if(returnInfo is Hashtable)
			{
				Hashtable returnInfoHash = new Hashtable();
				bool st = Execute(mode, serchInfo, ref returnInfoHash);
				if(st)
				{ 
					returnInfo = (object)returnInfoHash;
				}
				return st;
			}
			else if(returnInfo is ArrayList)
			{
				ArrayList returnInfoArray = new ArrayList();
				bool st = Execute(mode, serchInfo, ref returnInfoArray);
				if(st)
				{
					returnInfo = (object)returnInfoArray;
				}
				return st;
			}
			else
			{
				return false;
			
			}
		}


		public int SelectChildGuideData(int mode, ref object returnInfo)
		{
			// TODO:  TableGuide.SelectChildGuideData 実装を追加します。

			bool multiSelector = false;

			// 複数行選択タイプの判定
			if(_TopParentGuide != null)
			{
				// 最上位ガイド操作インタフェースを取得
				IGeneralGuideOperable plugIn = _TopParentGuide as IGeneralGuideOperable;
				if (plugIn != null)
				{
					multiSelector = plugIn.IsMultiSelector; 
				}
			}

			if(multiSelector)
			{
				Hashtable returnInfoHash = new Hashtable();

				//				returnInfo = _SelectedDataHash;
				int st = SelectData(ref returnInfoHash);
				if(st >= 0)
				{
					returnInfo = (object)returnInfoHash;
				}
				
				return st;
			}
			else if(returnInfo is Hashtable)
			{
				Hashtable returnInfoHash = new Hashtable();

				//				returnInfo = _SelectedDataHash;
				int st = SelectData(ref returnInfoHash);
				if(st >= 0)
				{
					returnInfo = (object)returnInfoHash;
				}
				
				return st;
			}												
			else
			{
				Hashtable returnInfoHash = new Hashtable();
				returnInfo = (object)returnInfoHash;
				return 0;
			}
		}


		/// <summary>
		/// x7 最上位親ガイドのイニシャライズ終了時に実行される
		/// </summary>
		public int OnEndTopParentInitProc(int mode, object topParentInfo)
		{

			// グリッド列の再定義
			for(int idx = 0; idx < ultraGrid1.DisplayLayout.Bands[0].Columns.Count; idx++)
			{
				//				MessageBox.Show(ultraGrid1.DisplayLayout.Bands[0].Columns[idx].Key);
				if(_KeyToWidth.ContainsKey(ultraGrid1.DisplayLayout.Bands[0].Columns[idx].Key))
				{
					//					MessageBox.Show(((int)_KeyToWidth[ultraGrid1.DisplayLayout.Bands[0].Columns[idx].Key]).ToString()+", "+ultraGrid1.DisplayLayout.Bands[0].Columns[idx].Width.ToString());
					ultraGrid1.DisplayLayout.Bands[0].Columns[idx].Width = (int)_KeyToWidth[ultraGrid1.DisplayLayout.Bands[0].Columns[idx].Key];
				}
			}

            ultraGrid1.ResumeLayout();
			return 0;
		}


		/// <summary>
		/// 指定されたデータを選択する
		/// </summary>
		public int SelectMyGuideData(int mode, object selectInfo)
		{
            _isHaveDefaultData = true;　　// ADD 2011/08/18
			// ArrayListの先頭から選択対象DDと値を取り出して、現在表示中のグリッドデータを選択する
			if((selectInfo != null) && (selectInfo is ArrayList))
			{
//				DataRow foundRow = null;
				int foundRow = 0;

				// 作成されたキー配列を使用してグリッドを検索
//				foundRow = _DataSet.Tables[0].Rows.Find(findTheseVals);
				foundRow = SearchGridData(mode, selectInfo);
				if(foundRow > 0)
				{
					// 見つかった行を選択してグリッドの選択行変更イベントを実行する
					ultraGrid1.Selected.Rows.Clear();
					ultraGrid1.Rows[foundRow].Selected = true;
                    ultraGrid1.ActiveRow = ultraGrid1.Rows[foundRow];

					ultraGrid1_AfterSelectChange(null, null);					
				}

			}
		
			return 0;
		}

		#endregion

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			// 列情報の変更(列名、表示・非表示、編集式等の変更)
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in ultraGrid1.DisplayLayout.Bands[0].Columns) 
			{
                if (_ViewerSWIndex.Equals(0))
                {

                    // デフォルト表示
                    if (_KeyToName[column.Key] != null)
                    {
                        column.Header.Caption = _KeyToName[column.Key].ToString();
                        string lColType = _KeyToType[column.Key].ToString();

                        // 数値型の項目の場合はソート方法を変更する
                        if (lColType != null)
                        {
                            switch (lColType.ToUpper())
                            {
                                case "INT":
                                    column.SortComparer = new MySortComparerNumber();
                                    break;
                                case "LONG":
                                    column.SortComparer = new MySortComparerNumber();
                                    break;
                                case "INT32":
                                    column.SortComparer = new MySortComparerNumber();
                                    break;
                                case "INT64":
                                    column.SortComparer = new MySortComparerNumber();
                                    break;
                                default:
                                    break;
                            }
                        }
                        //					if(_KeyToWidth.ContainsKey(column.Key))
                        //					{
                        column.Width = (int)_KeyToWidth[_KeyToName[column.Key].ToString()];
                        //					}
                        if (_KeyToDspFormat.ContainsKey(column.Key))
                        {
                            //						MessageBox.Show(_KeyToDspFormat[column.Key].ToString());
                            column.Format = _KeyToDspFormat[column.Key].ToString();
                        }


                        if (_KeyToHAlign.ContainsKey(column.Key))
                        {


                            switch (_KeyToHAlign[column.Key].ToString())
                            {
                                case "Right":
                                    column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                                    break;
                                case "Left":
                                    column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                                    break;
                                case "Center":
                                    column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                                    break;
                                default:
                                    column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
                                    break;
                            }

                        }


                    }
                    else
                    {
                        column.Hidden = true;
                    }

                }
                else if (_ViewerSWIndex.Equals(1))
                {

                    if (_KeyToDetail_SW1[column.Key] != null)
                    {
                        column.Header.Caption = ((GuideTermInfo)_KeyToDetail_SW1[column.Key]).DataName; // _KeyToName[column.Key].ToString();
                        string lColType = ((GuideTermInfo)_KeyToDetail_SW1[column.Key]).DataType; // _KeyToType[column.Key].ToString();

                        // 数値型の項目の場合はソート方法を変更する
                        if ((lColType != null) && ((lColType != "")))
                        {
                            switch (lColType.ToUpper())
                            {
                                case "INT":
                                    column.SortComparer = new MySortComparerNumber();
                                    break;
                                case "LONG":
                                    column.SortComparer = new MySortComparerNumber();
                                    break;
                                case "INT32":
                                    column.SortComparer = new MySortComparerNumber();
                                    break;
                                case "INT64":
                                    column.SortComparer = new MySortComparerNumber();
                                    break;
                                default:
                                    break;
                            }
                        }
                        //					if(_KeyToWidth.ContainsKey(column.Key))
                        //					{
                        column.Width = ((GuideTermInfo)_KeyToDetail_SW1[column.Key]).ViewWidth;
                        //					}
                        //if (_KeyToDspFormat.ContainsKey(column.Key))
                        //{
                        //    //						MessageBox.Show(_KeyToDspFormat[column.Key].ToString());
                        //    column.Format = _KeyToDspFormat[column.Key].ToString();
                        //}


                        if (((GuideTermInfo)_KeyToDetail_SW1[column.Key]).DataHAlign != "") // _KeyToHAlign.ContainsKey(column.Key))
                        {


                            switch (((GuideTermInfo)_KeyToDetail_SW1[column.Key]).DataHAlign)
                            {
                                case "Right":
                                    column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                                    break;
                                case "Left":
                                    column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                                    break;
                                case "Center":
                                    column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                                    break;
                                default:
                                    column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
                                    break;
                            }

                        }

                    }
                    else
                    {
                        column.Hidden = true;
                    }

                
                }

			}
		
            // グリッド列の並び換え


		}

		/// <summary>
		/// グリッド内のデータ検索	
		/// </summary>
		private int SearchGridData(int mode, object searchInfo)
		{
			int  retIndex	= 0;
			bool hitFg		= false;
			ArrayList al	= (ArrayList)searchInfo;
			int  dCnt		= al.Count;


			// 検索するキー値の配列を作成
			ArrayList targetAl = new ArrayList();
			for(int idx=0; idx < ultraGrid1.Rows.Count; idx++)
			{
				targetAl.Add(idx);
			}
			
			// データ検索
			for(int idx=0; idx < dCnt; idx++)
			{
				GuideDefaultDataInfo tmp = (GuideDefaultDataInfo)al[idx]; 

				// 全データに対しての検索処理を行う
				// (とりあえず前方検索で実装)
				// ↑この機能を使用する場合はおそらく特定のキー項目データのみが指定されているため、
				//   高速な検索方法を用いなくても良いと思われるため
				//   パフォーマンスに影響がある場合は、高速な検索方法への変更を考えてください
				for(int jdx=0; jdx < ultraGrid1.Rows.Count; jdx++)
				{
					if(ultraGrid1.Rows[jdx].Cells[tmp.TargetDD].Value.ToString() 
						== tmp.DefaultValue.ToString())
					{
						hitFg = true;	
					}
					else
					{
						targetAl.Remove(jdx);   // 検索対象から除去する
					}

					if((hitFg) && (dCnt.Equals(1)))
					{
						// 検索条件が１個しかない場合は、最初にデータヒットすれば終了とする	
						break;					
					}
				}

				if((hitFg) && (dCnt.Equals(1)))
				{
					// 検索条件が１個しかない場合は、最初にデータヒットすれば終了とする	
					break;					
				}
			}

			// 検索結果の最初のインデックスを返す
			if(targetAl.Count > 0)
			{
				retIndex = (int)targetAl[0];	
			}
		
			return retIndex;
        }

        // 2011/07/11 add wangf start
        /// <summary>
        /// ラベル項目コンポーネント構築
        /// </summary>
        /// <param name="LocationX">コンポーネントのLocation-X</param>
        /// <param name="LocationY">コンポーネントのLocation-Y</param>
        /// <param name="SizeX">コンポーネントのSize-X</param>
        /// <param name="SizeY">コンポーネントのSize-Y</param>
        /// <param name="componengName">名前</param>
        /// <param name="innerText">表示名前</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: ラベル項目コンポーネント構築を行う</br>
        /// <br>連番No.9</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: 2011/07/11</br>
        /// <br>Update Note : 2011/08/11 李占川 連番No.9</br>
        /// <br>              Redmine#23479の対応</br>
        /// </remarks>
        private void SearchConditionLabelMaker(int LocationX, int LocationY, int SizeX, int SizeY, string componengName, string innerText)
        {
            Infragistics.Win.Misc.UltraLabel component = new Infragistics.Win.Misc.UltraLabel();
            Searchpanel.Controls.Add(component);
            component.Location = new System.Drawing.Point(LocationX, LocationY);
            component.Name = componengName;
            component.Size = new System.Drawing.Size(SizeX, SizeY);
            component.Text = innerText;
            component.Visible = true;
            component.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);  // ADD 2011/08/11
        }

        /// <summary>
        /// テキストボックス項目コンポーネント構築
        /// </summary>
        /// <param name="LocationX">コンポーネントのLocation-X</param>
        /// <param name="LocationY">コンポーネントのLocation-Y</param>
        /// <param name="SizeX">コンポーネントのSize-X</param>
        /// <param name="SizeY">コンポーネントのSize-Y</param>
        /// <param name="componengName">名前</param>
        /// <param name="length">length</param>
        /// <param name="index">index</param>
        /// <param name="imeMode">imeMode</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: テキストボックス項目コンポーネント構築を行う</br>
        /// <br>Programmer	: wangf</br>
        /// <br>連番No.9</br>
        /// <br>Date		: 2011/07/11</br>
        /// <br>Update Note : 2011/08/11 李占川 連番No.9</br>
        /// <br>              Redmine#23479の対応</br>
        /// </remarks>
        private void SearchConditionTextBoxMaker(int LocationX, int LocationY, int SizeX, int SizeY, string componengName, int length, int index, int imeMode)
        {
            string specialNms = string.Join("", _specialNames);
            if (imeMode == 0)
            {
                TNedit tNeditComponent;
                tNeditComponent = new Broadleaf.Library.Windows.Forms.TNedit();
                ((System.ComponentModel.ISupportInitialize)(tNeditComponent)).BeginInit();
                Searchpanel.Controls.Add(tNeditComponent);
                tNeditComponent.Visible = true;
                tNeditComponent.AutoSelect = true;
                tNeditComponent.AutoSize = false;
                tNeditComponent.TabIndex = index;
                tNeditComponent.CalcSize = new System.Drawing.Size(SizeX, SizeY);
                tNeditComponent.DataText = "";
                tNeditComponent.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
                tNeditComponent.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, length, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
                tNeditComponent.ImeMode = System.Windows.Forms.ImeMode.Off;
                tNeditComponent.Location = new System.Drawing.Point(LocationX, LocationY);
                tNeditComponent.MaxLength = length;
                tNeditComponent.Name = componengName;
                tNeditComponent.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
                tNeditComponent.Size = new System.Drawing.Size(SizeX, SizeY);
                ((System.ComponentModel.ISupportInitialize)(tNeditComponent)).EndInit();
                //tNeditComponent.ValueChanged += new System.EventHandler(this.GridFilter); // DEL 2011/08/11
                tNeditComponent.Appearance.TextHAlign = HAlign.Right;
                tNeditComponent.ActiveAppearance.TextHAlign = HAlign.Right;
                // --- ADD 2011/08/11---------->>>>>
                tNeditComponent.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
                tNeditComponent.ActiveAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156))))); ;
                tNeditComponent.AutoSelect = true;
                // --- ADD 2011/08/11----------<<<<<
            }
            else
            {
                TEdit teditComponent = new Broadleaf.Library.Windows.Forms.TEdit();
                ((System.ComponentModel.ISupportInitialize)(teditComponent)).BeginInit();
                Searchpanel.Controls.Add(teditComponent);
                teditComponent.AutoSelect = false;
                teditComponent.AutoSize = false;
                teditComponent.DataText = "";
                teditComponent.TabIndex = index;
                teditComponent.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
                teditComponent.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, length, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
                if (imeMode == 1)
                {
                    if (specialNms.IndexOf(componengName.ToLower()) > -1)
                    {
                        // 検索条件は拠点コード処理
                        teditComponent.ImeMode = System.Windows.Forms.ImeMode.Off;
                        teditComponent.ValueChanged += new System.EventHandler(this.GridFilter);
                    }
                    else
                    {
                        // 平仮名
                        teditComponent.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
                    }
                }
                else if (imeMode == 2)
                {
                    // 片仮名
                    teditComponent.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
                }
                teditComponent.Location = new System.Drawing.Point(LocationX, LocationY);
                teditComponent.MaxLength = length;
                teditComponent.Name = componengName;
                teditComponent.Size = new System.Drawing.Size(SizeX, SizeY);
                // --- ADD 2011/08/11---------->>>>>
                teditComponent.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
                teditComponent.ActiveAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
                teditComponent.AutoSelect = true;
                // --- ADD 2011/08/11----------<<<<<
                ((System.ComponentModel.ISupportInitialize)(teditComponent)).EndInit();
            }
        }

        // -- add wangf 2011/08/31 ---------->>>>>
        /// <summary>
        /// ガイド項目コンポーネント構築
        /// </summary>
        /// <param name="LocationX">コンポーネントのLocation-X</param>
        /// <param name="LocationY">コンポーネントのLocation-Y</param>
        /// <param name="SizeX">コンポーネントのSize-X</param>
        /// <param name="SizeY">コンポーネントのSize-Y</param>
        /// <param name="componengName">名前</param>
        /// <param name="length">length</param>
        /// <param name="index">index</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: ガイド項目コンポーネント構築を行う</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: 2011/08/31</br>
        /// </remarks>
        private void SearchConditionDropMaker(int LocationX, int LocationY, int SizeX, int SizeY, string componengName, int length, int index)
        {
            TEdit teditComponent = new Broadleaf.Library.Windows.Forms.TEdit();
            ((System.ComponentModel.ISupportInitialize)(teditComponent)).BeginInit();
            Searchpanel.Controls.Add(teditComponent);
            teditComponent.AutoSelect = false;
            teditComponent.AutoSize = false;
            teditComponent.DataText = "";
            teditComponent.TabIndex = index;
            teditComponent.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            teditComponent.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, length, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            teditComponent.Location = new System.Drawing.Point(LocationX, LocationY);
            teditComponent.MaxLength = length;
            teditComponent.Name = componengName + "_textbox";
            teditComponent.Size = new System.Drawing.Size(SizeX, SizeY - 2);
            teditComponent.Enter += new EventHandler(this.ComboValueChange);
            ((System.ComponentModel.ISupportInitialize)(teditComponent)).EndInit();
            teditComponent.TabIndex = index;
            teditComponent.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            teditComponent.ActiveAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            teditComponent.AutoSelect = true;

            // DropdownList
            this.tComboEditor.Visible = true;
            this.tComboEditor.DropDownStyle = DropDownStyle.DropDownList;
            this.tComboEditor.Location = new System.Drawing.Point(LocationX + 120, LocationY);
            this.tComboEditor.Size = new System.Drawing.Size(76, 24);
            /* -- del wangf 2011/09/02 ---------->>>>>
            this.tComboEditor.Items.Add(0, "で始る");
            this.tComboEditor.Items.Add(1, "で終る");
            this.tComboEditor.Items.Add(2, "を含む");
            this.tComboEditor.Items.Add(3, "と一致");
            // -- del wangf 2011/09/02 ----------<<<<<*/
            // -- add wangf 2011/09/02 ---------->>>>>
            this.tComboEditor.Items.Add(0, "と一致");
            this.tComboEditor.Items.Add(1, "で始る");
            this.tComboEditor.Items.Add(2, "を含む");
            this.tComboEditor.Items.Add(3, "で終る");
            this.tComboEditor.ItemAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            // -- add wangf 2011/09/02 ----------<<<<<
            this.tComboEditor.ActiveAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            //this.tComboEditor.ValueChanged += new EventHandler(this.ComboValueChange); // del wangf 2011/09/02
            //this.tComboEditor.SelectedIndex = 3; // del wangf 2011/09/02
            this.tComboEditor.SelectedIndex = 0; // add wangf 2011/09/02
            this.tComboEditor.TabIndex = index + 1;
        }

        /// <summary>
        /// テキストボックス項目コンポーネントイベント追加
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: テキストボックス項目コンポーネントイベント追加する</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date	    : 2011/08/31</br>
        /// </remarks>
        private void GridFilterComboEdit(object sender, EventArgs e)
        {
            string filterString = string.Empty;
            string filterSt = string.Empty;
            int searchType = 0;
            string textComponent = string.Empty;
            foreach (Control ctrl in this.Searchpanel.Controls)
            {
                if (ctrl.GetType().ToString().Equals("Broadleaf.Library.Windows.Forms.TEdit"))
                {
                    // 管理番号絞り込み有り
                    filterSt = ctrl.Text.Trim();
                    textComponent = ctrl.Name.Substring(0, ctrl.Name.IndexOf("_"));
                }
                if (ctrl.GetType().ToString().Equals("Broadleaf.Library.Windows.Forms.TComboEditor"))
                {
                    searchType = ((TComboEditor)ctrl).SelectedIndex;
                }
            }
            if (!string.IsNullOrEmpty(filterSt))
            {
                /* -- del wangf 2011/09/02 ---------->>>>>
                if (searchType == 0)
                {
                    filterString += string.Format("{0} LIKE '{1}%'", this._DataSet.Tables[0].Columns[textComponent], filterSt);
                }
                else if (searchType == 1)
                {
                    filterString += string.Format("{0} LIKE '%{1}'", this._DataSet.Tables[0].Columns[textComponent], filterSt);
                }
                else if (searchType == 2)
                {
                    filterString += string.Format("{0} LIKE '%{1}%'", this._DataSet.Tables[0].Columns[textComponent], filterSt);
                }
                else
                {
                    filterString += string.Format("{0} = '{1}'", this._DataSet.Tables[0].Columns[textComponent], filterSt);
                }
                // -- del wangf 2011/09/02 ----------<<<<<*/
                // -- add wangf 2011/09/02 ---------->>>>>
                if (searchType == 1)
                {
                    filterString += string.Format("{0} LIKE '{1}%'", this._DataSet.Tables[0].Columns[textComponent], filterSt);
                }
                else if (searchType == 2)
                {
                    filterString += string.Format("{0} LIKE '%{1}%'", this._DataSet.Tables[0].Columns[textComponent], filterSt);
                }
                else if (searchType == 3)
                {
                    filterString += string.Format("{0} LIKE '%{1}'", this._DataSet.Tables[0].Columns[textComponent], filterSt);
                }
                else
                {
                    filterString += string.Format("{0} = '{1}'", this._DataSet.Tables[0].Columns[textComponent], filterSt);
                }
                // -- add wangf 2011/09/02 ----------<<<<<

            }
            this._DataSet.CaseSensitive = true;
            this._DataSet.Tables[0].DefaultView.RowFilter = filterString;
            ultraGrid1.BeginUpdate();
            ultraGrid1.DataSource = null;
            ultraGrid1.DataSource = this._DataSet.Tables[0];
            ultraGrid1.DataBind();
            ultraGrid1.EndUpdate();
            if (this.ultraGrid1.Rows.Count > 0)
            {
                this.ultraGrid1.Rows[0].Activate();
                this.ultraGrid1.Rows[0].Selected = true;
            }
            else
            {
                if (ChildGuide != null)
                {
                    if (((TableGuide)ChildGuide)._DataSet != null)
                    {
                        ((TableGuide)ChildGuide)._DataSet.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// 画面の番号管理検索モードの処理
        /// </summary>
        /// <param name="carMngCd">管理コード</param>
        /// <returns>1:前方一致　2:含み　3:後方一致</returns>
        /// <remarks>
        /// <br>Note       :画面の番号管理検索モードの処理を行う。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2011/08/31</br>
        /// </remarks>
        private int CarMngSearchModeCheck(string carMngCd)
        {
            //int res = 3; // del wangf 2011/09/02
            int res = 0; // add wangf 2011/09/02
            // 前方一致の場合
            string regexStringFront = "^[^*].*\\*$";
            // 含みの場合
            string regexStringContain = "^\\*.*\\*$";
            // 後方一致の場合
            string regexStringBack = "^\\*.*";
            if (System.Text.RegularExpressions.Regex.IsMatch(carMngCd, regexStringFront))
            {
                //res = 0; // del wangf 2011/09/02
                res = 1; // add wangf 2011/09/02
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(carMngCd, regexStringContain))
            {
                res = 2;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(carMngCd, regexStringBack))
            {
                //res = 1; // del wangf 2011/09/02
                res = 3; // add wangf 2011/09/02
            }
            return res;
        }

        /// <summary>
        /// コンボボックス項目コンポーネントイベント追加
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: コンボボックス項目コンポーネントイベント追加する</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date	    : 2011/08/31</br>
        /// </remarks>
        private void ComboValueChange(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Searchpanel.Controls)
            {
                if (ctrl.GetType().ToString().Equals("Broadleaf.Library.Windows.Forms.TEdit"))
                {
                    if (this.tComboEditor != null)
                    {
                        ctrl.Text = ctrl.Text.Trim('*');
                        /* -- del wangf 2011/09/02 ---------->>>>>
                        if (string.IsNullOrEmpty(ctrl.Text))
                        {
                            return;
                        }
                        if (this.tComboEditor.SelectedIndex == 0)
                        {
                            ctrl.Text = ctrl.Text + "*";
                        }
                        else if (this.tComboEditor.SelectedIndex == 1)
                        {
                            ctrl.Text = "*" + ctrl.Text;
                        }
                        else if (this.tComboEditor.SelectedIndex == 2)
                        {
                            ctrl.Text = "*" + ctrl.Text + "*";
                        }
                        // -- del wangf 2011/09/02 ----------<<<<<*/
                        // -- add wangf 2011/09/02 ---------->>>>>
                        if (this.tComboEditor.SelectedIndex == 1)
                        {
                            ctrl.Text = ctrl.Text + "*";
                        }
                        else if (this.tComboEditor.SelectedIndex == 2)
                        {
                            ctrl.Text = "*" + ctrl.Text + "*";
                        }
                        else if (this.tComboEditor.SelectedIndex == 3)
                        {
                            ctrl.Text = "*" + ctrl.Text;
                        }
                        // -- add wangf 2011/09/02 ----------<<<<<
                    }
                }
            }
        }
        // -- add wangf 2011/08/31 ----------<<<<<

        /// <summary>
        /// テキストボックス項目コンポーネントイベント追加
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: テキストボックス項目コンポーネントイベント追加する</br>
        /// <br>Programmer	: wangf</br>
        /// <br>連番No.9</br>
        /// <br>Date	    : 2011/07/11</br>
        /// <br>Update Note : 2012/10/22  王君</br>
        /// <br>管理番号    : 2012/11/14配信分</br>
        /// <br>              Redmine#32861 仕入先ガイドに「電話番号」「ＦＡＸ番号」を追加する対応</br>
        /// </remarks>
        private void GridFilter(object sender, EventArgs e)
        {
            if (this._DataSet.Tables.Count == 0) return;  // ADD 2011/08/11
            string filterString = string.Empty;
            string specialNms = string.Join("", _specialNames);
            bool flg = false;
            foreach (Control ctrl in this.Searchpanel.Controls)
            {
                // 作成コンポーネントのタイプによって、検索条件を作成
                if (ctrl.GetType().ToString().Equals("Infragistics.Win.Misc.UltraLabel") || ctrl.GetType().ToString().Equals("Broadleaf.Library.Windows.Forms.TComboEditor"))
                {
                    continue;
                }
                if (!string.Empty.Equals(ctrl.Text.Trim()))
                {
                    if (flg)
                    {
                        filterString += " and ";
                    }
                    // 名前コンポーネント完全合わせて
                    if (ctrl.GetType().ToString().Equals("Broadleaf.Library.Windows.Forms.TNedit") || specialNms.IndexOf(ctrl.Name.ToLower()) > -1)
                    {
                        try
                        {
                            int var = Convert.ToInt32(ctrl.Text);
                        }
                        catch (Exception)
                        {
                            ctrl.Text = string.Empty;
                            return;
                        }
                        // ---------DEL 王君 2012/10/22 Redmine#32861----------->>>>>>
                        //if (specialNms.IndexOf(ctrl.Name.ToLower()) > -1)
                        //{
                        //    filterString += string.Format("{0} >= {1}", this._DataSet.Tables[0].Columns[ctrl.Name.Substring(0, ctrl.Name.IndexOf("_"))], ToDBC(ctrl.Text.Trim()));
                        //}
                        //else
                        //{
                        //    filterString += string.Format("{0} >= {1}", this._DataSet.Tables[0].Columns[ctrl.Name.Substring(0, ctrl.Name.IndexOf("_"))], ctrl.Text);
                        //}
                        // ---------DEL 王君 2012/10/22 Redmine#32861-----------<<<<<
                        // ---------ADD 王君 2012/10/22 Redmine#32861------------>>>>>
                        string sPaymentTotalDay = this._DataSet.Tables[0].Columns[ctrl.Name.Substring(0, ctrl.Name.IndexOf("_"))].ToString(); //締日
                        string sMngSectionCode = this._DataSet.Tables[0].Columns[ctrl.Name.Substring(0, ctrl.Name.IndexOf("_"))].ToString();  //管理拠点
                        if (specialNms.IndexOf(ctrl.Name.ToLower()) > -1)
                        {
                            if ("SUPPLIERGUIDE.XML".Equals(this._xPathDocPath) && ("PaymentTotalDay".Equals(sPaymentTotalDay) || "MngSectionCode".Equals(sMngSectionCode)))
                            {
                                filterString += string.Format("{0} = {1}", this._DataSet.Tables[0].Columns[ctrl.Name.Substring(0, ctrl.Name.IndexOf("_"))], ToDBC(ctrl.Text.Trim()));
                            }
                            else
                            {
                                filterString += string.Format("{0} >= {1}", this._DataSet.Tables[0].Columns[ctrl.Name.Substring(0, ctrl.Name.IndexOf("_"))], ToDBC(ctrl.Text.Trim()));
                            }
                        }
                        else
                        {
                            if ("SUPPLIERGUIDE.XML".Equals(this._xPathDocPath) && ("PaymentTotalDay".Equals(sPaymentTotalDay) || "MngSectionCode".Equals(sMngSectionCode)))
                            {
                                filterString += string.Format("{0} = {1}", this._DataSet.Tables[0].Columns[ctrl.Name.Substring(0, ctrl.Name.IndexOf("_"))], ToDBC(ctrl.Text.Trim()));
                            }
                            else
                            {
                                filterString += string.Format("{0} >= {1}", this._DataSet.Tables[0].Columns[ctrl.Name.Substring(0, ctrl.Name.IndexOf("_"))], ctrl.Text);
                            }
                        }
                        // ---------ADD 王君 2012/10/22 Redmine#32861------------<<<<<
                    } 
                    // 開始コード時
                    else if (ctrl.GetType().ToString().Equals("Broadleaf.Library.Windows.Forms.TEdit"))
                    {
                        filterString += string.Format("{0} LIKE '%{1}%'", this._DataSet.Tables[0].Columns[ctrl.Name.Substring(0, ctrl.Name.IndexOf("_"))], ctrl.Text);
                    }
                    flg = true;
                }
            }
            this._DataSet.CaseSensitive = true;
            this._DataSet.Tables[0].DefaultView.RowFilter = filterString;
            ultraGrid1.BeginUpdate();
            ultraGrid1.DataSource = null;
            ultraGrid1.DataSource = this._DataSet.Tables[0];
            ultraGrid1.DataBind();
            ultraGrid1.EndUpdate();
            if (this.ultraGrid1.Rows.Count > 0)
            {
                this.ultraGrid1.Rows[0].Activate();
                this.ultraGrid1.Rows[0].Selected = true;
            }
            else
            {
                if (ChildGuide != null)
                {
                    if (((TableGuide)ChildGuide)._DataSet != null)
                    {
                        ((TableGuide)ChildGuide)._DataSet.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// 全角->半角変更
        /// </summary>
        /// <param name="input">全角パラメータ</param>
        /// <returns>半角パラメータ</returns>
        /// <remarks>
        /// <br>Note		: 全角->半角変更を行う</br>
        /// <br>Programmer	: wangf</br>
        /// <br>連番No.9</br>
        /// <br>Date	    : 2011/07/11</br>
        /// </remarks>
        private string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        // 2011/07/11 add wangf end



		// 数値項目比較用のソートクラス	
		private class MySortComparerNumber : IComparer 
		{
			internal MySortComparerNumber( )
			{
			}

			int IComparer.Compare( object x, object y )
			{

				//0 より小さい値 strA が strB より小さい。 
				//0 strA と strB は等しい。 
				//0 より大きい値 strA が strB より大きい。 
				// 関数に渡されるオブジェクトはセルです。最初に、UltraGridCell 型にキャストします。 
				UltraGridCell xCell = (UltraGridCell)x;
				UltraGridCell yCell = (UltraGridCell)y;
	
				// xCell および yCell 間で独自の比較ロジックを実行し、xCell が yCell よりも
				// 小さい場合は負の値を返し、大きい場合は正の値を返します。同じ値の場合は 0
				// を返します。

				// 文字列を数値に変換して比較します。
				long num1 = 0;
				long num2 = 0;

				try
				{
					num1 = Convert.ToInt64(xCell.Value.ToString().Trim());
				}
				catch(Exception e)
				{
					num1 = 0;
				}

				try
				{
					num2 = Convert.ToInt64(yCell.Value.ToString().Trim());
				}
				catch(Exception e)
				{
					num2 = 0;
				}

				return Convert.ToInt32(num1 - num2);

			}
		}

        /// <summary>
        /// ガイド項目情報クラス(グリッド列と対応)
        /// </summary>
        private class GuideTermInfo
        {
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public GuideTermInfo(string dataKey, int viewOrder, string dataName, string dataType, int viewWidth, string dataHAlign)
            {
                DataKey = dataKey;
                ViewOrder = viewOrder;
                ViewWidth = viewWidth;
                DataName = dataName;
                DataType = dataType;
                DataHAlign = dataHAlign;
            }

            /// <summary>
            /// 表示順位
            /// </summary>
            public string DataKey = "";

            /// <summary>
            /// 表示順位 
            /// </summary>
            public int ViewOrder = 0;

            /// <summary>
            /// 項目表示幅
            /// </summary>
            public int ViewWidth = 0;

            /// <summary>
            /// 項目名
            /// </summary>
            public string DataName = "";

            /// <summary>
            /// 項目型
            /// </summary>
            public string DataType = "";

            /// <summary>
            /// 項目表示位置
            /// </summary>
            public string DataHAlign = "";


        }


        #region IGeneralGuideFocusOperable メンバ

        public void ChangeFocus(EnumGeneralGuideFocusDirection direction, int childGuideIndex)
        {

            if (childGuideIndex.Equals(ChildGuideIndex))
            {
                // 親ガイドにフォーカス移動を通知
                IGeneralGuideFocusOperable plugIn = _TopParentGuide as IGeneralGuideFocusOperable;
                if (plugIn != null)
                {
                    plugIn.ChangeFocus(direction, childGuideIndex);
                }
            }
            else if (direction.Equals(EnumGeneralGuideFocusDirection.MainGrid))
            {
                ultraGrid1.Focus();
            }

            return;
        }
         
        #endregion

        #region IGeneralGuideOperable メンバ

        private int _ChildGuideIndex = 0;
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

        private bool _IsMultiSelector = false;
        public bool IsMultiSelector
        {
            get
            {
                return _IsMultiSelector;
            }
            set
            {
                _IsMultiSelector = value;
            }
        }

        private bool _IsTopLevelGuide = false;
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

        public int SelectGuideData(int mode, int childGuideIndex)
        {
            return 0;
        }

        #endregion

        // 2011/07/11 wangf add start 
        /// <summary>
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// <br>Programmer : wangf</br>
        /// <br>連番No.9</br>
        /// <br>Date       : 2011/07/11</br>
        /// <br>Update Note: 2011/08/18 李占川 連番9、Redmine#23479のNo30対応</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }
            switch (e.PrevCtrl.Name)
            {
                // --- DEL 2011/08/18---------->>>>>
                //case "SectionCode_textbox":
                //    {
                //        switch (e.Key)
                //        {
                //            case Keys.Return:
                //            case Keys.Tab:
                //                if (!e.ShiftKey)
                //                {
                //                    foreach (Control ctrl in this.Searchpanel.Controls)
                //                    {
                //                        if (ctrl.Name.Equals("SectionCode_textbox") && !string.Empty.Equals(ctrl.Text))
                //                        {
                //                            ctrl.Text = ctrl.Text.PadLeft(2, '0');
                //                            break;
                //                        }
                //                    }
                //                }
                //                break;
                //        }
                //        break;
                //    }
                //case "ultraGrid1":
                //    {
                //        switch (e.Key)
                //        {
                //            case Keys.Return:
                //            case Keys.Tab:
                //                if (!e.ShiftKey)
                //                {
                //                    if (this.ultraGrid1.Rows.Count > 0 && this.ultraGrid1.ActiveRow.Index < this.ultraGrid1.Rows.Count - 1)
                //                    {
                //                        this.ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);
                //                    }
                //                    else if (this.ultraGrid1.Rows.Count > 0 && this.ultraGrid1.ActiveRow.Index == this.ultraGrid1.Rows.Count - 1)
                //                    {
                //                        this.ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                //                    }
                //                }
                //                else
                //                {
                //                    if (this.ultraGrid1.Rows.Count > 0 && this.ultraGrid1.ActiveRow.Index > 0)
                //                    {
                //                        this.ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevRow);
                //                    }
                //                    else if (this.ultraGrid1.Rows.Count > 0 && this.ultraGrid1.ActiveRow.Index == 0)
                //                    {
                //                        this.ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                //                    }
                //                }
                //                e.NextCtrl = this.ultraGrid1;
                //                break;
                //        }
                //        break;
                //    }
                // --- DEL 2011/08/18----------<<<<<
                // -- add wangf 2011/08/31 ---------->>>>>
                case "tComboEditor":
                    {
                        this.GridFilterComboEdit(sender, e);
                        foreach (Control ctrl in this.Searchpanel.Controls)
                        {
                            if (!string.IsNullOrEmpty(ctrl.Text.Trim()) && ctrl.GetType().ToString().Equals("Broadleaf.Library.Windows.Forms.TEdit"))
                            {
                                ctrl.Text = ctrl.Text.Trim('*');
                                break;
                            }
                        }
                        break;
                    }
                // -- add wangf 2011/08/31 ----------<<<<<
                default:
                    //this.GridFilter(sender, e); // del wangf 2011/08/31
                    // -- add wangf 2011/08/31 ---------->>>>>
                    if ("CarMngCode_textbox".Equals(e.PrevCtrl.Name))
                    {
                        foreach (Control ctrl in this.Searchpanel.Controls)
                        {
                            if (!string.IsNullOrEmpty(ctrl.Text.Trim()) && ctrl.GetType().ToString().Equals("Broadleaf.Library.Windows.Forms.TComboEditor"))
                            {
                                ((TComboEditor)ctrl).SelectedIndex = this.CarMngSearchModeCheck(e.PrevCtrl.Text);
                                break;
                            }
                        }
                        this.GridFilterComboEdit(sender, e);
                        e.PrevCtrl.Text = e.PrevCtrl.Text.Trim('*');
                    }
                    else if (!"ultraGrid1".Equals(e.PrevCtrl.Name))
                    {
                        this.GridFilter(sender, e);
                    }
                    // -- add wangf 2011/08/31 ----------<<<<<

                    if ("ultraGrid1".Equals(e.NextCtrl.Name))
                    {
                        if (this.ultraGrid1.Rows.Count > 0)
                        {
                            if (this.ultraGrid1.ActiveRow != null)
                            {
                                this.ultraGrid1.ActiveRow.Selected = true;
                            }
                            else
                            {
                                this.ultraGrid1.Rows[0].Selected = true;
                            }
                        }
                        // --- ADD 2011/08/18---------->>>>>
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        // --- ADD 2011/08/18----------<<<<<
                    }
                    else
                    {
                        if (this.ultraGrid1.Rows.Count > 0)
                        {
                            if (this.ultraGrid1.ActiveRow != null)
                            {
                                this.ultraGrid1.ActiveRow.Selected = true;
                            }
                            else
                            {
                                this.ultraGrid1.Rows[0].Selected = true;
                            }
                        }
                    }

                    break;
            }
        }
        // 2011/07/11 wangf add end

        // --- ADD 2011/08/11---------->>>>>
        /// <summary>
        /// グリッドフォーカスタイマーイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 初期起動時、グリッドにフォーカスを設定する</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/08/11</br>
        /// <br>Update Note : 2011/08/18 李占川 連番9、Redmine#23479のNo28対応</br>
        /// <br>              初期フォーカスを変更する。</br>
        /// </remarks>
        private void timer_initFocus_Tick(object sender, EventArgs e)
        {
            this.ultraGrid1.Focus();
            // --- ADD 2011/08/18---------->>>>>
            if (_ChildGuide == null)
            {
                ChangeFocus(EnumGeneralGuideFocusDirection.Left, this.ChildGuideIndex);
            }
            // 子ガイドモードと初期値設定あるの場合は、子ガイドの選択処理を実行
            if (_ChildGuide != null && this._isHaveDefaultData)
            {
                ChangeFocus(EnumGeneralGuideFocusDirection.Right, this.ChildGuideIndex);
            }
            // --- ADD 2011/08/18----------<<<<<
            this.timer_initFocus.Enabled = false;
        }

        /// <summary>
        /// キー押下イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : キー押下イベント処理</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/08/11</br>
        /// </remarks>
        private void TableGuide_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // ESCキー押下による画面閉じる処理
                case Keys.Escape:
                    {
                        CancelButton_Click(sender, e);
                    }
                    break;
                // F3キー押下による画面検索条件戻る処理
                case Keys.F3:
                    BackToSearchPanel(sender, e);
                    break;
                // F6キー押下による画面検索処理を行う
                case Keys.F6:
                    //this.GridFilter(sender, e); // del wangf 2011/08/31
                    // -- add wangf 2011/08/31 ---------->>>>>
                    if (!"CarMngCode_textbox".Equals(this.Searchpanel.Controls[2].Name))
                    {
                        this.GridFilter(sender, e);
                    }
                    else
                    {
                        foreach (Control ctrl in this.Searchpanel.Controls)
                        {
                            if (!string.IsNullOrEmpty(ctrl.Text.Trim()) && ctrl.GetType().ToString().Equals("Broadleaf.Library.Windows.Forms.TComboEditor"))
                            {
                                ((TComboEditor)ctrl).SelectedIndex = this.CarMngSearchModeCheck(this.Searchpanel.Controls[2].Text);
                                break;
                            }
                        }
                        this.GridFilterComboEdit(sender, e);
                        this.Searchpanel.Controls[2].Text = this.Searchpanel.Controls[2].Text.Trim('*');
                    }
                    // -- add wangf 2011/08/31 ----------<<<<<
                    if (this.ultraGrid1.Rows.Count > 0)
                    {
                        this.ultraGrid1.Focus();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// F3キー押下イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : F3キー押下イベント処理</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/08/11</br>
        /// <br>Update Note: 2011/08/31 wangf </br>
        /// <br>             ①redmine#24253を対応</br>
        /// </remarks>
        private void BackToSearchPanel(object sender, EventArgs e)
        {
            if (!this.ultraGrid1.Focused)
            {
                return;
            }
            if (this.Searchpanel.Controls != null && this.Searchpanel.Controls.Count > 0)
            {
                //this.Searchpanel.Controls[1].Focus(); // del wangf 2011/08/31
                this.Searchpanel.Controls[2].Focus(); // add wangf 2011/08/31
            }
        }
        // --- ADD 2011/08/11----------<<<<<
    }

	/// <summary>
	/// 初期値設定データクラス
	/// </summary>
	public class GuideDefaultDataInfo
	{

		public string TargetDD;
		public string TargetDataSource;
		public object DefaultValue;

		/// <summary>
		/// 初期値設定データクラス コンストラスタ
		/// </summary>
		public GuideDefaultDataInfo()
		{


		}

		/// <summary>
		/// 初期値設定データクラス コンストラスタ
		/// </summary>
		public GuideDefaultDataInfo(string targetDD, string targetDataSource, object defaultValue)
		{
			TargetDD			= targetDD;
			TargetDataSource	= targetDataSource;
			DefaultValue		= defaultValue;
		
		}

	}






}
