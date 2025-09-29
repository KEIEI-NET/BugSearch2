using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

using System.Collections;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 掛率詳細画面フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率詳細画面を表示します。</br>
    /// <br>Programer  : 96138  佐藤  健治</br>
    /// <br>Date       : 2013.11.14</br>
    public class PMKHN09931UA : System.Windows.Forms.Form
    {
        
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Panel panel5;
        private Infragistics.Win.UltraWinGrid.UltraGrid CreditRateDtGrid;
        private IContainer components;
        private Broadleaf.Library.Windows.Forms.TToolbarsManager tToolbarsManager1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _CreditRateDtGuidUA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _CreditRateDtGuidUA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _CreditRateDtGuidUA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _CreditRateDtGuidUA_Toolbars_Dock_Area_Bottom;

        #region プロパティ Public Properties
        /// <summary>
        /// 掛率データ
        /// </summary>
        public DataSet DsCreditRateDt
        {
            get { return _dsCreditRateDt; }
        }
        #endregion

        #region private変数
        private string _sectionCode = "";
        private int _unitPriceKind = 0;
        private string _rateSettingDivide = "";

        private DataTable _resultsTbl = new DataTable();
        private DataTable dt = new DataTable();

        ArrayList userGdBdList = new ArrayList();

        private string _enterpriseCode = "";                // 企業コード

        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;
        private Dictionary<int, BLGroupU> _blGroupUDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<int, UserGdBd> _custRateGrpDic;

        private SFCMN00299CA msgForm = null;                // 抽出中画面部品のインスタンスを作成
        
        private MakerAcs _makerAcs = null;					// メーカーアクセスクラス
        private GoodsGroupUAcs _goodsGroupUAcs = null;      // 商品掛率Ｇアクセスクラス
        private BLGroupUAcs _blGroupUAcs = null;            // BLグループアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs = null;			// BLコードアクセスクラス
        private CustomerInfoAcs _customerInfoAcs = null;    // 得意先アクセスクラス
        private UserGuideAcs _userGuideAcs = null;			// ユーザーガイドアクセスクラス
        private SupplierAcs _supplierAcs = null;            // 仕入先アクセスクラス

        private int _goodsMakerCdCnt = 0;
        private int _goodsNoCnt = 0;
        private int _goodsRateRankCnt = 0;
        private int _goodsRateGrpCodeCnt = 0;
        private int _bLGroupCodeCnt = 0;
        private int _bLGoodsCodeCnt = 0;
        private int _customerCodeCnt = 0;
        private int _supplierCdCnt = 0;

        // グリッド選択色設定 255, 255, 192
        private readonly Color _selectedBackColor = Color.FromArgb(255, 224, 192);
        private readonly Color _selectedBackColor2 = Color.FromArgb(255, 224, 192);

        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Label label1;
        private Timer timer1;
        private Infragistics.Win.Misc.UltraButton ultrBtn_AllSearch;
        private Label label2;
        private Label label3;            

        /// <summary>
        ///データセット
        /// </summary>
        private DataSet _dsCreditRateDt = null;
        #endregion

        //コンストラクタ
        public PMKHN09931UA(PMKHN09931U_Para pMKHN09931U_Para)
        {
            InitializeComponent();

            ImageList imageList16 = IconResourceManagement.ImageList16;
            tToolbarsManager1.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.CLOSE];

        }

        #region InitializeComponent
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Close");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Close");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09931UA));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ultrBtn_AllSearch = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.CreditRateDtGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.tToolbarsManager1 = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CreditRateDtGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ultrBtn_AllSearch);
            this.panel2.Controls.Add(this.ultraLabel1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 61);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(632, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(365, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "「全件取得」時、件数が多い場合、時間がかかる場合があります。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(638, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "※初回起動時の件数は最大100になります。";
            // 
            // ultrBtn_AllSearch
            // 
            this.ultrBtn_AllSearch.Location = new System.Drawing.Point(519, 19);
            this.ultrBtn_AllSearch.Name = "ultrBtn_AllSearch";
            this.ultrBtn_AllSearch.Size = new System.Drawing.Size(110, 25);
            this.ultrBtn_AllSearch.TabIndex = 2;
            this.ultrBtn_AllSearch.Text = "全件取得";
            this.ultrBtn_AllSearch.Click += new System.EventHandler(this.ultrBtn_AllSearch_Click);
            // 
            // ultraLabel1
            // 
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(136, 20);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(376, 23);
            this.ultraLabel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "掛率設定区分";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ultraStatusBar1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 688);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 42);
            this.panel3.TabIndex = 3;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 19);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(1008, 23);
            this.ultraStatusBar1.TabIndex = 0;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(984, 108);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(24, 580);
            this.panel4.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 108);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(29, 580);
            this.panel5.TabIndex = 6;
            // 
            // CreditRateDtGrid
            // 
            appearance16.BackColor = System.Drawing.SystemColors.Window;
            appearance16.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.CreditRateDtGrid.DisplayLayout.Appearance = appearance16;
            this.CreditRateDtGrid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CreditRateDtGrid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.BorderColor = System.Drawing.SystemColors.Window;
            this.CreditRateDtGrid.DisplayLayout.GroupByBox.Appearance = appearance13;
            appearance14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CreditRateDtGrid.DisplayLayout.GroupByBox.BandLabelAppearance = appearance14;
            this.CreditRateDtGrid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance15.BackColor2 = System.Drawing.SystemColors.Control;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CreditRateDtGrid.DisplayLayout.GroupByBox.PromptAppearance = appearance15;
            this.CreditRateDtGrid.DisplayLayout.MaxColScrollRegions = 1;
            this.CreditRateDtGrid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance24.BackColor = System.Drawing.SystemColors.Window;
            appearance24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CreditRateDtGrid.DisplayLayout.Override.ActiveCellAppearance = appearance24;
            appearance19.BackColor = System.Drawing.SystemColors.Highlight;
            appearance19.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CreditRateDtGrid.DisplayLayout.Override.ActiveRowAppearance = appearance19;
            this.CreditRateDtGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.CreditRateDtGrid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.CreditRateDtGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            this.CreditRateDtGrid.DisplayLayout.Override.CardAreaAppearance = appearance18;
            appearance17.BorderColor = System.Drawing.Color.Silver;
            appearance17.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.CreditRateDtGrid.DisplayLayout.Override.CellAppearance = appearance17;
            this.CreditRateDtGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.CreditRateDtGrid.DisplayLayout.Override.CellPadding = 0;
            appearance21.BackColor = System.Drawing.SystemColors.Control;
            appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.BorderColor = System.Drawing.SystemColors.Window;
            this.CreditRateDtGrid.DisplayLayout.Override.GroupByRowAppearance = appearance21;
            appearance23.TextHAlignAsString = "Left";
            this.CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance = appearance23;
            this.CreditRateDtGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.CreditRateDtGrid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.BorderColor = System.Drawing.Color.Silver;
            this.CreditRateDtGrid.DisplayLayout.Override.RowAppearance = appearance22;
            this.CreditRateDtGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CreditRateDtGrid.DisplayLayout.Override.TemplateAddRowAppearance = appearance20;
            this.CreditRateDtGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.CreditRateDtGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.CreditRateDtGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreditRateDtGrid.Location = new System.Drawing.Point(29, 108);
            this.CreditRateDtGrid.Name = "CreditRateDtGrid";
            this.CreditRateDtGrid.Size = new System.Drawing.Size(955, 580);
            this.CreditRateDtGrid.TabIndex = 7;
            this.CreditRateDtGrid.Text = "ultraGrid1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // _CreditRateDtGuidUA_Toolbars_Dock_Area_Left
            // 
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 47);
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Left.Name = "_CreditRateDtGuidUA_Toolbars_Dock_Area_Left";
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 683);
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Left.ToolbarsManager = this.tToolbarsManager1;
            // 
            // tToolbarsManager1
            // 
            this.tToolbarsManager1.DesignerFlags = 1;
            this.tToolbarsManager1.DockWithinContainer = this;
            this.tToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.tToolbarsManager1.FloatingToolbarFadeDelay = 100;
            this.tToolbarsManager1.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.tToolbarsManager1.ShowFontNamesInFont = false;
            this.tToolbarsManager1.ShowFullMenusDelay = 500;
            this.tToolbarsManager1.ShowQuickCustomizeButton = false;
            this.tToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1});
            ultraToolbar1.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar1.Text = "UltraToolbar1";
            this.tToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool2.SharedProps.Caption = "終了(&X)";
            buttonTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.tToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2});
            this.tToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.tToolbarsManager1_ToolClick);
            // 
            // _CreditRateDtGuidUA_Toolbars_Dock_Area_Right
            // 
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1008, 47);
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Right.Name = "_CreditRateDtGuidUA_Toolbars_Dock_Area_Right";
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 683);
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Right.ToolbarsManager = this.tToolbarsManager1;
            // 
            // _CreditRateDtGuidUA_Toolbars_Dock_Area_Top
            // 
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Top.Name = "_CreditRateDtGuidUA_Toolbars_Dock_Area_Top";
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1008, 47);
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Top.ToolbarsManager = this.tToolbarsManager1;
            // 
            // _CreditRateDtGuidUA_Toolbars_Dock_Area_Bottom
            // 
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 730);
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Bottom.Name = "_CreditRateDtGuidUA_Toolbars_Dock_Area_Bottom";
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1008, 0);
            this._CreditRateDtGuidUA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.tToolbarsManager1;
            // 
            // PMKHN09931UA
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.CreditRateDtGrid);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this._CreditRateDtGuidUA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._CreditRateDtGuidUA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._CreditRateDtGuidUA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._CreditRateDtGuidUA_Toolbars_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09931UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "掛率詳細画面";
            this.Shown += new System.EventHandler(this.PMKHN09931UA_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CreditRateDtGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion


        #region パブリック メソッド  Public Methods
        /// <summary>
        /// 掛率詳細画面表示
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率詳細を取得し、画面へ設定します。</br>
        /// <br>Programer  : 96138  佐藤  健治</br>
        /// <br>Date       : 2013.11.14</br>
        /// </remarks>
        public void Disp_CreditRateDtGuid(PMKHN09931U_Para pMKHN09931U_Para)
        {

            _sectionCode = pMKHN09931U_Para.SectionCode;
            _unitPriceKind = pMKHN09931U_Para.UnitPriceKind;
            _rateSettingDivide = pMKHN09931U_Para.RateSettingDivide;
            ultraLabel1.Text = pMKHN09931U_Para.RateSettingDivideName;

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            msgForm = new SFCMN00299CA();

            this._makerAcs = new MakerAcs();                // メーカーアクセスクラス
            this._goodsGroupUAcs = new GoodsGroupUAcs();    // 商品掛率Ｇアクセスクラス
            this._blGroupUAcs = new BLGroupUAcs();          // BLグループアクセスクラス
            this._blGoodsCdAcs = new BLGoodsCdAcs();        // BLコードアクセスクラス
            this._customerInfoAcs = new CustomerInfoAcs();  // 得意先アクセスクラス
            this._userGuideAcs = new UserGuideAcs();        // ユーザーガイドアクセスクラス
            this._supplierAcs = new SupplierAcs();          // 仕入先アクセスクラス

            //ガイドを表示
            this.ShowDialog();

        }
        #endregion

        #region プライベート メソッド  Private Methods
        /// <summary>
        /// 画面表示イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br></br>
        /// <br>Programmer : 96138 佐藤　健治</br>
        /// <br>Date       : 2013.11.25</br>
        /// </remarks>
        private void PMKHN09931UA_Shown(object sender, EventArgs e)
        {

            timer1.Enabled = true;

        }

        /// <summary>
        /// 画面表示イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br></br>
        /// <br>Programmer : 96138 佐藤　健治</br>
        /// <br>Date       : 2013.11.25</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = false;

            // 抽出中画面部品のインスタンスを作成
            msgForm.Title = "抽出中";
            msgForm.Message = "掛率詳細設定作成中…。";
            msgForm.DispCancelButton = true;
            msgForm.Show();

            try
            {
                LoadMakerUMnt();        // メーカー取得
                LoadGoodsGroupU();      // 商品掛率Ｇ取得
                LoadBLGroupU();         // BLグループ取得
                LoadBLGoodsCdUMnt();    // BLコード取得
                LoadSupplier();         // 仕入先取得
                LoadCustRateGrp();      // 得意先掛率Ｇ取得

                //テーブル作成
                Create_CreditRateDtTable();

                _resultsTbl = new DataTable();
                //データを取得します                
                PMKHN09932AA _pMKHN09932A = new PMKHN09932AA();

                _pMKHN09932A.GetDetailInfo(out _resultsTbl, _sectionCode, _unitPriceKind.ToString(), _rateSettingDivide);                

                //テーブルデータセット
                int status = SetTable_CreditRateDt(99); //初回は100件表示

                CreditRateDtGrid.DataSource = DsCreditRateDt.Tables[CREDITRATEDT_TBL.Name].DefaultView;

                CreditRateDtGrid.DataBind();
                CreditRateDtGrid_InitializeLayout();

            }
            finally
            {
                msgForm.Close();
            }

        }

        /// <summary>
        /// テーブルを作成します
        /// </summary>
        /// <remarks>
        /// <br>Note       : テーブルを作成します</br>
        /// <br>Programmer : 96138 佐藤  健治</br>
        /// <br>Date       : 2013.11.14</br>
        /// </remarks>
        private void Create_CreditRateDtTable()
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable(CREDITRATEDT_TBL.Name);

            //列の定義
            dt.Columns.Add(CREDITRATEDT_TBL.CustomerCode, typeof(string));			//string 得意先コード
            dt.Columns.Add(CREDITRATEDT_TBL.CustomerName, typeof(string));			//string 得意先名称
            dt.Columns.Add(CREDITRATEDT_TBL.CustRateGrpCode, typeof(string));		//string 得意先掛率グループコード
            dt.Columns.Add(CREDITRATEDT_TBL.CustRateGrpName, typeof(string));		//string 得意先掛率グループ名称
            dt.Columns.Add(CREDITRATEDT_TBL.SupplierCd, typeof(string));			//string 仕入先コード
            dt.Columns.Add(CREDITRATEDT_TBL.SupplierName, typeof(string));			//string 仕入先名称

            dt.Columns.Add(CREDITRATEDT_TBL.GoodsMakerCd, typeof(string));			//string 商品メーカーコード
            dt.Columns.Add(CREDITRATEDT_TBL.GoodsMakerName, typeof(string));		//string 商品メーカー名称
            dt.Columns.Add(CREDITRATEDT_TBL.GoodsNo,       typeof(string));			//string 商品番号
            dt.Columns.Add(CREDITRATEDT_TBL.GoodsRateRank, typeof(string));			//string 商品掛率ランク

            dt.Columns.Add(CREDITRATEDT_TBL.GoodsRateGrpCode, typeof(string));	    //string 商品掛率グループコード
            dt.Columns.Add(CREDITRATEDT_TBL.GoodsRateGrpName, typeof(string));	    //string 商品掛率グループ名称
            dt.Columns.Add(CREDITRATEDT_TBL.BLGroupCode, typeof(string));			//string BLグループコード
            dt.Columns.Add(CREDITRATEDT_TBL.BLGroupName, typeof(string));			//string BLグループ名称
            dt.Columns.Add(CREDITRATEDT_TBL.BLGoodsCode, typeof(string));			//string BL商品コード
            dt.Columns.Add(CREDITRATEDT_TBL.BLGoodsName, typeof(string));			//string BL商品名称

            //メンバ変数へ退避
            this._dsCreditRateDt = ds;
            this._dsCreditRateDt.Tables.Add(dt);

        }

        /// <summary>
        /// テーブルにデータをセットします
        /// </summary>
        /// <remarks>
        /// <br>Note       : テーブルにデータをセットします</br>
        /// <br>Programmer : 96138 佐藤  健治</br>
        /// <br>Date       : 2013.11.14</br>
        /// </remarks>
        private int SetTable_CreditRateDt(int cnt)
        {

            try
            {
                int status = 0;

                _goodsMakerCdCnt = 0;
                _goodsNoCnt = 0;
                _goodsRateRankCnt = 0;
                _goodsRateGrpCodeCnt = 0;                
                _bLGroupCodeCnt = 0;
                _bLGoodsCodeCnt = 0;
                _customerCodeCnt = 0;
                _supplierCdCnt = 0;

                dt = new DataTable();                
                dt = this._dsCreditRateDt.Tables[CREDITRATEDT_TBL.Name];

                //全件取得する
                if ((cnt == 99) && (_resultsTbl.Rows.Count < 99))
                {
                    cnt = _resultsTbl.Rows.Count;
                }
                else if (cnt == 0)
                {
                    cnt = _resultsTbl.Rows.Count;
                }

                for (int i = 0; i < cnt; i++)
                {
                    // キャンセルボタン押下の場合
                    if (msgForm.IsCanceled == true)
                    {
                        //画面を終了する
                        this.Close();
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        DataRow drSrc = _resultsTbl.Rows[i];

                        if (Convert.ToInt32(drSrc[4]) != 0)
                        {
                            //string 商品メーカーコード
                            dr[CREDITRATEDT_TBL.GoodsMakerCd] = drSrc[4];
                            //string 商品メーカー名称
                            dr[CREDITRATEDT_TBL.GoodsMakerName] = GetMakerName(Convert.ToInt32(drSrc[4]));
                            _goodsMakerCdCnt++;
                        }

                        if ((drSrc[5]).ToString().Trim() != "")
                        {
                            //string 商品番号
                            dr[CREDITRATEDT_TBL.GoodsNo] = drSrc[5];
                            _goodsNoCnt++;
                        }

                        if ((drSrc[6]).ToString().Trim() != "")
                        {
                            //string 商品掛率ランク
                            dr[CREDITRATEDT_TBL.GoodsRateRank] = drSrc[6];
                            _goodsRateRankCnt++;
                        }

                        if (Convert.ToInt32(drSrc[7]) != 0)
                        {
                            //string 商品掛率グループコード
                            dr[CREDITRATEDT_TBL.GoodsRateGrpCode] = drSrc[7];
                            //string 商品掛率グループ名称
                            dr[CREDITRATEDT_TBL.GoodsRateGrpName] = GetGoodsMGroupName(Convert.ToInt32(drSrc[7]));
                            _goodsRateGrpCodeCnt++;
                        }

                        if (Convert.ToInt32(drSrc[8]) != 0)
                        {
                            //string BLグループコード
                            dr[CREDITRATEDT_TBL.BLGroupCode] = drSrc[8];
                            //string BLグループ名称
                            dr[CREDITRATEDT_TBL.BLGroupName] = GetBLGroupName(Convert.ToInt32(drSrc[8]));
                            _bLGroupCodeCnt++;
                        }

                        if (Convert.ToInt32(drSrc[9]) != 0)
                        {
                            //string BL商品コード
                            dr[CREDITRATEDT_TBL.BLGoodsCode] = drSrc[9];
                            //string BL商品名称
                            dr[CREDITRATEDT_TBL.BLGoodsName] = GetBLGoodsName(Convert.ToInt32(drSrc[9]));
                            _bLGoodsCodeCnt++;
                        }

                        if (Convert.ToInt32(drSrc[10]) != 0)
                        {
                            //string 得意先コード
                            dr[CREDITRATEDT_TBL.CustomerCode] = drSrc[10];
                            //string 得意先名称
                            dr[CREDITRATEDT_TBL.CustomerName] = GetCustomerName(Convert.ToInt32(drSrc[10]));
                            _customerCodeCnt++;
                        }

                        //string 得意先グループコード ※キッティングでゼロのデータもある
                        dr[CREDITRATEDT_TBL.CustRateGrpCode] = drSrc[11].ToString().PadLeft(4, '0');

                        //string 得意先グループ名称
                        dr[CREDITRATEDT_TBL.CustRateGrpName] = GetCustRateGrp(Convert.ToInt32(drSrc[11]));


                        if (Convert.ToInt32(drSrc[12]) != 0)
                        {
                            //string 仕入先コード
                            dr[CREDITRATEDT_TBL.SupplierCd] = drSrc[12];
                            //string 仕入先名称
                            dr[CREDITRATEDT_TBL.SupplierName] = GetSupplierName(Convert.ToInt32(drSrc[12]));
                            _supplierCdCnt++;
                        }

                        dt.Rows.Add(dr);

                    }
                }

                return status;
            }
            catch (Exception)
            {
                // エラー！
                return -1;
            }
        }

        private void ultrBtn_AllSearch_Click(object sender, EventArgs e)
        {

            timer1.Enabled = false;

            // 抽出中画面部品のインスタンスを作成
            msgForm.Title = "抽出中";
            msgForm.Message = "掛率詳細設定作成中…。";
            msgForm.DispCancelButton = true;
            msgForm.Show();

            try
            {
                dt.Clear();

                //テーブルデータセット
                int status = SetTable_CreditRateDt(0);

                CreditRateDtGrid.DataSource = DsCreditRateDt.Tables[CREDITRATEDT_TBL.Name].DefaultView;

                CreditRateDtGrid.DataBind();
                CreditRateDtGrid_InitializeLayout();
            }
            finally
            {
                msgForm.Close();
            }

        }

        /// <summary>
        /// 掛率詳細グリッドの初期処理をします
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率詳細グリッドの初期処理をします</br>
        /// <br>Programmer : 96138 佐藤  健治</br>
        /// <br>Date       : 2013.11.14</br>
        /// </remarks>
        private void CreditRateDtGrid_InitializeLayout()
        {

            if (CreditRateDtGrid.DataSource == null)
            {
                return;
            }

            //バンドを取得
            Infragistics.Win.UltraWinGrid.UltraGridBand band = CreditRateDtGrid.DisplayLayout.Bands[CREDITRATEDT_TBL.Name];

            CreditRateDtGrid.DisplayLayout.Override.DefaultRowHeight = 25;

            CreditRateDtGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            CreditRateDtGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

            //複数行選択設定
            CreditRateDtGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;

            // 行の削除を不可とする。
            CreditRateDtGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;

            // グリッド全体の外観設定
            CreditRateDtGrid.DisplayLayout.Appearance.ForeColorDisabled = Color.Black;
            CreditRateDtGrid.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;
            CreditRateDtGrid.DisplayLayout.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(198)), ((System.Byte)(219)), ((System.Byte)(255)));
            CreditRateDtGrid.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // 行の外観設定
            CreditRateDtGrid.DisplayLayout.Override.RowAppearance.BackColor = System.Drawing.Color.White;

            // 1行おきの外観設定
            CreditRateDtGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = System.Drawing.Color.Lavender;

            // アクティブセルの外観設定
            // オレンジ
            CreditRateDtGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            CreditRateDtGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            CreditRateDtGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            CreditRateDtGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;

            // ヘッダーの外観設定
            CreditRateDtGrid.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
            CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            //セルの外観決定
            CreditRateDtGrid.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            //行セレクター表示
            CreditRateDtGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            ////行セレクターの外観設定
            //CreditRateDtGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            //CreditRateDtGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            //CreditRateDtGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //階層マーク表示設定
            //CreditRateDtGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;

            //複数画面表示(スプリッター)の表示設定
            CreditRateDtGrid.DisplayLayout.MaxRowScrollRegions = 1;

            //ヘッダのキャプション
            band.Columns[CREDITRATEDT_TBL.GoodsMakerCd].Header.Caption = "ﾒｰｶｰｺｰﾄﾞ";                //メーカーコード
            band.Columns[CREDITRATEDT_TBL.GoodsMakerName].Header.Caption = "ﾒｰｶｰ名称";              //メーカー（名称）
            band.Columns[CREDITRATEDT_TBL.GoodsNo].Header.Caption = "品番";                         //品番
            band.Columns[CREDITRATEDT_TBL.GoodsRateRank].Header.Caption = "層別";                   //層別
            band.Columns[CREDITRATEDT_TBL.GoodsRateGrpCode].Header.Caption = "商品掛率Gｺｰﾄﾞ";       //商品掛率G
            band.Columns[CREDITRATEDT_TBL.GoodsRateGrpName].Header.Caption = "商品掛率G";           //商品掛率G（名称）
            band.Columns[CREDITRATEDT_TBL.BLGroupCode].Header.Caption = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";               //グループコード
            band.Columns[CREDITRATEDT_TBL.BLGroupName].Header.Caption = "ｸﾞﾙｰﾌﾟ名称";               //グループ名称
            band.Columns[CREDITRATEDT_TBL.BLGoodsCode].Header.Caption = "BLｺｰﾄﾞ";                   //BLコード
            band.Columns[CREDITRATEDT_TBL.BLGoodsName].Header.Caption = "商品名称";                 //BLコード（名称）
            band.Columns[CREDITRATEDT_TBL.CustomerCode].Header.Caption = "得意先ｺｰﾄﾞ";              //得意先コード
            band.Columns[CREDITRATEDT_TBL.CustomerName].Header.Caption = "得意先名称";              //得意先名称
            band.Columns[CREDITRATEDT_TBL.CustRateGrpCode].Header.Caption = "得意先掛率ｸﾞﾙｰﾌﾟｺｰﾄﾞ"; //得意先掛率グループコード
            band.Columns[CREDITRATEDT_TBL.CustRateGrpName].Header.Caption = "得意先掛率ｸﾞﾙｰﾌﾟ名称"; //得意先掛率グループ名称
            band.Columns[CREDITRATEDT_TBL.SupplierCd].Header.Caption = "仕入先ｺｰﾄﾞ";                //仕入先コード
            band.Columns[CREDITRATEDT_TBL.SupplierName].Header.Caption = "仕入先名称";              //仕入先名称

            band.Columns[CREDITRATEDT_TBL.GoodsMakerCd].Hidden = false;                             //メーカーコード
            band.Columns[CREDITRATEDT_TBL.GoodsMakerName].Hidden = false;                           //メーカー（名称）           
            band.Columns[CREDITRATEDT_TBL.GoodsNo].Hidden = false;                                  //品番
            band.Columns[CREDITRATEDT_TBL.GoodsRateRank].Hidden = false;                            //層別
            band.Columns[CREDITRATEDT_TBL.GoodsRateGrpCode].Hidden = false;                         //商品掛率G
            band.Columns[CREDITRATEDT_TBL.GoodsRateGrpName].Hidden = false;                         //商品掛率G（名称）
            band.Columns[CREDITRATEDT_TBL.BLGroupCode].Hidden = false;                              //グループコード
            band.Columns[CREDITRATEDT_TBL.BLGroupName].Hidden = false;                              //グループ名称
            band.Columns[CREDITRATEDT_TBL.BLGoodsCode].Hidden = false;                              //BLコード
            band.Columns[CREDITRATEDT_TBL.BLGoodsName].Hidden = false;                              //BLコード（名称）
            band.Columns[CREDITRATEDT_TBL.CustomerCode].Hidden = false;                             //得意先コード
            band.Columns[CREDITRATEDT_TBL.CustomerName].Hidden = false;                             //得意先名称
            band.Columns[CREDITRATEDT_TBL.CustRateGrpCode].Hidden = false;                          //得意先掛率グループコード
            band.Columns[CREDITRATEDT_TBL.CustRateGrpName].Hidden = false;                          //得意先掛率グループ名称
            band.Columns[CREDITRATEDT_TBL.SupplierCd].Hidden = false;                               //仕入先コード
            band.Columns[CREDITRATEDT_TBL.SupplierName].Hidden = false;                             //仕入先名称

            if (_goodsMakerCdCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.GoodsMakerCd].Hidden = true;                          //メーカーコード
                band.Columns[CREDITRATEDT_TBL.GoodsMakerName].Hidden = true;                        //メーカー（名称）           
            }
            if (_goodsNoCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.GoodsNo].Hidden = true;                               //品番
            }
            if (_goodsRateRankCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.GoodsRateRank].Hidden = true;                         //層別
            }
            if (_goodsRateGrpCodeCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.GoodsRateGrpCode].Hidden = true;                      //商品掛率G
                band.Columns[CREDITRATEDT_TBL.GoodsRateGrpName].Hidden = true;                      //商品掛率G（名称）
            }
            if (_bLGroupCodeCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.BLGroupCode].Hidden = true;                           //グループコード
                band.Columns[CREDITRATEDT_TBL.BLGroupName].Hidden = true;                           //グループ名称
            }
            if (_bLGoodsCodeCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.BLGoodsCode].Hidden = true;                           //BLコード
                band.Columns[CREDITRATEDT_TBL.BLGoodsName].Hidden = true;                           //BLコード（名称）
            }            
            if (_customerCodeCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.CustomerCode].Hidden = true;                          //得意先コード
                band.Columns[CREDITRATEDT_TBL.CustomerName].Hidden = true;                          //得意先名称
            }            
            if ((_rateSettingDivide == "3A") || (_rateSettingDivide == "4A") || (_rateSettingDivide == "3B") ||
                (_rateSettingDivide == "3C") || (_rateSettingDivide == "3D") || (_rateSettingDivide == "3E") ||
                (_rateSettingDivide == "3F") || (_rateSettingDivide == "3G") || (_rateSettingDivide == "3H") ||
                (_rateSettingDivide == "3I") || (_rateSettingDivide == "3J") || (_rateSettingDivide == "3K") ||
                (_rateSettingDivide == "3L") || (_rateSettingDivide == "4B") || (_rateSettingDivide == "4C") ||
                (_rateSettingDivide == "4D") || (_rateSettingDivide == "4E") || (_rateSettingDivide == "4F") ||
                (_rateSettingDivide == "4G") || (_rateSettingDivide == "4H") || (_rateSettingDivide == "4I") ||
                (_rateSettingDivide == "4J") || (_rateSettingDivide == "4K") || (_rateSettingDivide == "4L"))
            {
            }
            else
            {
                band.Columns[CREDITRATEDT_TBL.CustRateGrpCode].Hidden = true;                       //得意先掛率グループコード
                band.Columns[CREDITRATEDT_TBL.CustRateGrpName].Hidden = true;                       //得意先掛率グループ名称
            }
            if (_supplierCdCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.SupplierCd].Hidden = true;                            //仕入先コード
                band.Columns[CREDITRATEDT_TBL.SupplierName].Hidden = true;                          //仕入先名称
            }
            
            //値リストを初期化し、グリッドへ追加します。
            CreditRateDtGrid.DisplayLayout.ValueLists.Clear();

            //各カラム共通（ヘッダ）
            for (int i = 0; i < band.Columns.Count; i++)
            {
                band.Columns[i].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;		//中央寄せ
                band.Columns[i].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            band.Columns[CREDITRATEDT_TBL.GoodsMakerCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;      //メーカーコード
            band.Columns[CREDITRATEDT_TBL.GoodsMakerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;     //メーカー（名称）
            band.Columns[CREDITRATEDT_TBL.GoodsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;            //品番
            band.Columns[CREDITRATEDT_TBL.GoodsRateRank].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;     //層別
            band.Columns[CREDITRATEDT_TBL.GoodsRateGrpCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;  //商品掛率G
            band.Columns[CREDITRATEDT_TBL.GoodsRateGrpName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;   //商品掛率G（名称）
            band.Columns[CREDITRATEDT_TBL.BLGroupCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;       //グループコード
            band.Columns[CREDITRATEDT_TBL.BLGroupName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;        //グループ名称
            band.Columns[CREDITRATEDT_TBL.BLGoodsCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;       //BLコード
            band.Columns[CREDITRATEDT_TBL.BLGoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;        //BLコード（名称）
            band.Columns[CREDITRATEDT_TBL.CustomerCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;      //得意先コード
            band.Columns[CREDITRATEDT_TBL.CustomerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;       //得意先名称
            band.Columns[CREDITRATEDT_TBL.CustRateGrpCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;   //得意先掛率グループコード
            band.Columns[CREDITRATEDT_TBL.CustRateGrpName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;    //得意先掛率グループ名称
            band.Columns[CREDITRATEDT_TBL.SupplierCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;        //仕入先コード
            band.Columns[CREDITRATEDT_TBL.SupplierName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;       //仕入先名称
        }

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        private void LoadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
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
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            try
            {
                if (this._makerUMntDic.ContainsKey(makerCode))
                {
                    makerName = this._makerUMntDic[makerCode].MakerName.Trim();
                }
            }
            catch
            {
                makerName = "";
            }

            return makerName;
        }

        /// <summary>
        /// 商品掛率Ｇマスタ読込処理
        /// </summary>
        private void LoadGoodsGroupU()
        {
            this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();

            try
            {
                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                    }
                }
            }
            catch
            {
                this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();
            }
        }

        /// <summary>
        /// 商品掛率Ｇ名称取得処理
        /// </summary>
        /// <param name="goodsMGroupCode">商品掛率Ｇコード</param>
        /// <returns>商品掛率Ｇ名称</returns>
        /// <remarks>
        /// <br>Note       : 商品掛率Ｇ名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private string GetGoodsMGroupName(int goodsMGroupCode)
        {
            string goodsMGroupName = "";

            try
            {
                if (this._goodsGroupUDic.ContainsKey(goodsMGroupCode))
                {
                    goodsMGroupName = this._goodsGroupUDic[goodsMGroupCode].GoodsMGroupName.Trim();
                }
            }
            catch
            {
                goodsMGroupName = "";
            }

            return goodsMGroupName;
        }

        /// <summary>
        /// グループコードマスタ読込処理
        /// </summary>
        private void LoadBLGroupU()
        {
            this._blGroupUDic = new Dictionary<int, BLGroupU>();

            try
            {
                ArrayList retList;

                int status = this._blGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU blGroupU in retList)
                    {
                        this._blGroupUDic.Add(blGroupU.BLGroupCode, blGroupU);
                    }
                }
            }
            catch
            {
                this._blGroupUDic = new Dictionary<int, BLGroupU>();
            }
        }

        /// <summary>
        /// BLグループ名称取得処理
        /// </summary>
        /// <param name="blGroupCode">BLグループコード</param>
        /// <returns>BLグループ名称</returns>
        /// <remarks>
        /// <br>Note       : BLグループ名称を取得します。</br>
        /// <br>Programmer : 96138 佐藤　健治</br>
        /// <br>Date       : 2014/11/14</br>
        /// </remarks>
        private string GetBLGroupName(int blGroupCode)
        {
            string blGroupName = "";

            try
            {
                if (this._blGroupUDic.ContainsKey(blGroupCode))
                {
                    blGroupName = this._blGroupUDic[blGroupCode].BLGroupName.Trim();
                }
            }
            catch
            {
                blGroupName = "";
            }

            return blGroupName;
        }

        /// <summary>
        /// BLコードマスタ読込処理
        /// </summary>
        private void LoadBLGoodsCdUMnt()
        {
            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// BLコード名称取得処理
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <returns>BLコード名称</returns>
        /// <remarks>
        /// <br>Note       : BLコード名称を取得します。</br>
        /// <br>Programmer : 96138 佐藤　健治</br>
        /// <br>Date       : 2013/11/14</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode)
        {
            string blGoodsName = "";

            try
            {
                if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
                {
                    blGoodsName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsHalfName.Trim();
                }
            }
            catch
            {
                blGoodsName = "";
            }

            return blGoodsName;
        }

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note       : 得意先名称を取得します。</br>
        /// <br>Programmer : 96138 佐藤　健治</br>
        /// <br>Date       : 2013/11/14</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            try
            {
                CustomerInfo customerInfo;

                int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                if (status == 0)
                {
                    customerName = customerInfo.CustomerSnm.Trim();
                }
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }

        /// <summary>
        /// ユーザーガイドデータ取得処理
        /// </summary>
        /// <param name="retList">ユーザーガイドボディデータリスト</param>
        /// <param name="userGuideDivCd">ガイド区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイドデータを取得します。</br>
        /// <br>Programmer : 96138 佐藤　健治</br>
        /// <br>Date       : 2013/11/14</br>
        /// </remarks>
        private int GetUserGuideBd(out ArrayList retList, int userGuideDivCd)
        {
            int status;
            retList = new ArrayList();

            status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                             userGuideDivCd, UserGuideAcsData.UserBodyData);

            return status;
        }

        /// <summary>
        /// 得意先掛率グループ情報取得処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループ情報を取得します。</br>
        /// <br>Programmer : 96138 佐藤　健治</br>
        /// <br>Date       : 2013/11/14</br>
        /// </remarks>
        private int LoadCustRateGrp()
        {

            this._custRateGrpDic = new Dictionary<int, UserGdBd>();

            ArrayList retList;

            int status;

            // ユーザーガイドデータ取得(得意先掛率グループ)
            status = GetUserGuideBd(out retList, 43);
            if (status == 0)
            {
                foreach (UserGdBd userGdBd in retList)
                {
                    this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd);
                }
            }

            return status;
        }

        /// <summary>
        /// 得意先掛率グループ名称取得処理
        /// </summary>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <returns>得意先掛率グループ名称</returns>
        /// <remarks>
        /// <br>Note       : 仕入先名称を取得します。</br>
        /// <br>Programmer : 96138 佐藤　健治</br>
        /// <br>Date       : 2013/11/14</br>
        /// </remarks>
        private string GetCustRateGrp(int custRateGrpCode)
        {
            string custRateGrpName = "";

            try
            {
                if (this._custRateGrpDic.ContainsKey(custRateGrpCode))
                {
                    custRateGrpName = this._custRateGrpDic[custRateGrpCode].GuideName.Trim();
                }
            }
            catch
            {
                custRateGrpName = "";
            }

            return custRateGrpName;
        }

        /// <summary>
        /// 仕入先マスタ読込処理
        /// </summary>
        private void LoadSupplier()
        {
            this._supplierDic = new Dictionary<int, Supplier>();

            try
            {
                ArrayList retList;

                int status = this._supplierAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier supplier in retList)
                    {
                        this._supplierDic.Add(supplier.SupplierCd, supplier);
                    }
                }
            }
            catch
            {
                this._supplierDic = new Dictionary<int, Supplier>();
            }
        }

        /// <summary>
        /// 仕入先名称取得処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>仕入先名称</returns>
        /// <remarks>
        /// <br>Note       : 仕入先名称を取得します。</br>
        /// <br>Programmer : 96138 佐藤　健治</br>
        /// <br>Date       : 2013/11/14</br>
        /// </remarks>
        private string GetSupplierName(int supplierCode)
        {
            string supplierName = "";

            try
            {
                if (this._supplierDic.ContainsKey(supplierCode))
                {
                    supplierName = this._supplierDic[supplierCode].SupplierSnm.Trim();
                }
            }
            catch
            {
                supplierName = "";
            }

            return supplierName;
        }

        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバーがクリックされた時に発生します。</br>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <br>Programmer : 96138 佐藤  健治</br>
        /// <br>Date       : 2013.11.14</br>
        /// </remarks>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {

            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        Close();
                        break;
                    }
            }
        }
        #endregion

        #region ******  掛率詳細テーブル  ******
        /// <summary>
        /// 掛率詳細テーブルのキーワードを定義
        /// </summary>
        public struct CREDITRATEDT_TBL
        {
            /// <summary>
            /// 掛率詳細テーブル名
            /// </summary>
            public const string Name = "CreditRateDt_TBL";

            /// <summary>
            /// 商品メーカーコード
            /// </summary>
            public const string GoodsMakerCd = "GoodsMakerCd";

            /// <summary>
            /// 商品メーカー名称
            /// </summary>
            public const string GoodsMakerName = "GoodsMakerName";

            /// <summary>
            /// 商品番号
            /// </summary>
            public const string GoodsNo = "GoodsNo";

            /// <summary>
            /// 商品掛率ランク
            /// </summary>
            public const string GoodsRateRank = "GoodsRateRank";

            /// <summary>
            /// 商品掛率グループコード
            /// </summary>
            public const string GoodsRateGrpCode = "GoodsRateGrpCode";

            /// <summary>
            /// 商品掛率グループ名称
            /// </summary>
            public const string GoodsRateGrpName = "GoodsRateGrpName";

            /// <summary>
            /// BLグループコード
            /// </summary>
            public const string BLGroupCode = "BLGroupCode";

            /// <summary>
            /// BLグループ名称
            /// </summary>
            public const string BLGroupName = "BLGroupName";

            /// <summary>
            /// BL商品コード
            /// </summary>
            public const string BLGoodsCode = "BLGoodsCode";

            /// <summary>
            /// BL商品名称
            /// </summary>
            public const string BLGoodsName = "BLGoodsName";

            /// <summary>
            /// 得意先コード
            /// </summary>
            public const string CustomerCode = "CustomerCode";

            /// <summary>
            /// 得意先名称
            /// </summary>
            public const string CustomerName = "CustomerName";

            /// <summary>
            /// 得意先掛率グループコード
            /// </summary>
            public const string CustRateGrpCode = "CustRateGrpCode";

            /// <summary>
            /// 得意先掛率グループ名称
            /// </summary>
            public const string CustRateGrpName = "CustRateGrpName";

            /// <summary>
            /// 仕入先コード
            /// </summary>
            public const string SupplierCd = "SupplierCd";

            /// <summary>
            /// 仕入先名称
            /// </summary>
            public const string SupplierName = "SupplierName";
            

        }
        #endregion

        #region ******  掛率詳細画面起動パラメータ  ******
        /// <summary>
        /// 掛率詳細画面起動パラメータ
        /// </summary>
        public class PMKHN09931U_Para
        {
            //拠点コード
            private string _sectionCode = "";

            //単価種類
            private int _unitPriceKind = 0;

            //掛率設定区分
            private string _rateSettingDivide = "";

            //掛率設定区分名称
            private string _rateSettingDivideName = "";


            //拠点コード
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }

            //単価種類
            public int UnitPriceKind
            {
                get { return _unitPriceKind; }
                set { _unitPriceKind = value; }
            }

            //掛率設定区分
            public string RateSettingDivide
            {
                get { return _rateSettingDivide; }
                set { _rateSettingDivide = value; }
            }

            //掛率設定区分名称
            public string RateSettingDivideName
            {
                get { return _rateSettingDivideName; }
                set { _rateSettingDivideName = value; }
            }

        }
        #endregion

    }
}