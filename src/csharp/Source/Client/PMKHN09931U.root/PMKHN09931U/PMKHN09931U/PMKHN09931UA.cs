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
    /// �|���ڍ׉�ʃt�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���ڍ׉�ʂ�\�����܂��B</br>
    /// <br>Programer  : 96138  ����  ����</br>
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

        #region �v���p�e�B Public Properties
        /// <summary>
        /// �|���f�[�^
        /// </summary>
        public DataSet DsCreditRateDt
        {
            get { return _dsCreditRateDt; }
        }
        #endregion

        #region private�ϐ�
        private string _sectionCode = "";
        private int _unitPriceKind = 0;
        private string _rateSettingDivide = "";

        private DataTable _resultsTbl = new DataTable();
        private DataTable dt = new DataTable();

        ArrayList userGdBdList = new ArrayList();

        private string _enterpriseCode = "";                // ��ƃR�[�h

        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;
        private Dictionary<int, BLGroupU> _blGroupUDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<int, UserGdBd> _custRateGrpDic;

        private SFCMN00299CA msgForm = null;                // ���o����ʕ��i�̃C���X�^���X���쐬
        
        private MakerAcs _makerAcs = null;					// ���[�J�[�A�N�Z�X�N���X
        private GoodsGroupUAcs _goodsGroupUAcs = null;      // ���i�|���f�A�N�Z�X�N���X
        private BLGroupUAcs _blGroupUAcs = null;            // BL�O���[�v�A�N�Z�X�N���X
        private BLGoodsCdAcs _blGoodsCdAcs = null;			// BL�R�[�h�A�N�Z�X�N���X
        private CustomerInfoAcs _customerInfoAcs = null;    // ���Ӑ�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs = null;			// ���[�U�[�K�C�h�A�N�Z�X�N���X
        private SupplierAcs _supplierAcs = null;            // �d����A�N�Z�X�N���X

        private int _goodsMakerCdCnt = 0;
        private int _goodsNoCnt = 0;
        private int _goodsRateRankCnt = 0;
        private int _goodsRateGrpCodeCnt = 0;
        private int _bLGroupCodeCnt = 0;
        private int _bLGoodsCodeCnt = 0;
        private int _customerCodeCnt = 0;
        private int _supplierCdCnt = 0;

        // �O���b�h�I��F�ݒ� 255, 255, 192
        private readonly Color _selectedBackColor = Color.FromArgb(255, 224, 192);
        private readonly Color _selectedBackColor2 = Color.FromArgb(255, 224, 192);

        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Label label1;
        private Timer timer1;
        private Infragistics.Win.Misc.UltraButton ultrBtn_AllSearch;
        private Label label2;
        private Label label3;            

        /// <summary>
        ///�f�[�^�Z�b�g
        /// </summary>
        private DataSet _dsCreditRateDt = null;
        #endregion

        //�R���X�g���N�^
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
            this.label3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(632, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(365, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "�u�S���擾�v���A�����������ꍇ�A���Ԃ�������ꍇ������܂��B";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(638, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "������N�����̌����͍ő�100�ɂȂ�܂��B";
            // 
            // ultrBtn_AllSearch
            // 
            this.ultrBtn_AllSearch.Location = new System.Drawing.Point(519, 19);
            this.ultrBtn_AllSearch.Name = "ultrBtn_AllSearch";
            this.ultrBtn_AllSearch.Size = new System.Drawing.Size(110, 25);
            this.ultrBtn_AllSearch.TabIndex = 2;
            this.ultrBtn_AllSearch.Text = "�S���擾";
            this.ultrBtn_AllSearch.Click += new System.EventHandler(this.ultrBtn_AllSearch_Click);
            // 
            // ultraLabel1
            // 
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(136, 20);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(376, 23);
            this.ultraLabel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "�|���ݒ�敪";
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
            buttonTool2.SharedProps.Caption = "�I��(&X)";
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
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09931UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�|���ڍ׉��";
            this.Shown += new System.EventHandler(this.PMKHN09931UA_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CreditRateDtGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion


        #region �p�u���b�N ���\�b�h  Public Methods
        /// <summary>
        /// �|���ڍ׉�ʕ\��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���ڍׂ��擾���A��ʂ֐ݒ肵�܂��B</br>
        /// <br>Programer  : 96138  ����  ����</br>
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

            this._makerAcs = new MakerAcs();                // ���[�J�[�A�N�Z�X�N���X
            this._goodsGroupUAcs = new GoodsGroupUAcs();    // ���i�|���f�A�N�Z�X�N���X
            this._blGroupUAcs = new BLGroupUAcs();          // BL�O���[�v�A�N�Z�X�N���X
            this._blGoodsCdAcs = new BLGoodsCdAcs();        // BL�R�[�h�A�N�Z�X�N���X
            this._customerInfoAcs = new CustomerInfoAcs();  // ���Ӑ�A�N�Z�X�N���X
            this._userGuideAcs = new UserGuideAcs();        // ���[�U�[�K�C�h�A�N�Z�X�N���X
            this._supplierAcs = new SupplierAcs();          // �d����A�N�Z�X�N���X

            //�K�C�h��\��
            this.ShowDialog();

        }
        #endregion

        #region �v���C�x�[�g ���\�b�h  Private Methods
        /// <summary>
        /// ��ʕ\���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br></br>
        /// <br>Programmer : 96138 �����@����</br>
        /// <br>Date       : 2013.11.25</br>
        /// </remarks>
        private void PMKHN09931UA_Shown(object sender, EventArgs e)
        {

            timer1.Enabled = true;

        }

        /// <summary>
        /// ��ʕ\���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br></br>
        /// <br>Programmer : 96138 �����@����</br>
        /// <br>Date       : 2013.11.25</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = false;

            // ���o����ʕ��i�̃C���X�^���X���쐬
            msgForm.Title = "���o��";
            msgForm.Message = "�|���ڍאݒ�쐬���c�B";
            msgForm.DispCancelButton = true;
            msgForm.Show();

            try
            {
                LoadMakerUMnt();        // ���[�J�[�擾
                LoadGoodsGroupU();      // ���i�|���f�擾
                LoadBLGroupU();         // BL�O���[�v�擾
                LoadBLGoodsCdUMnt();    // BL�R�[�h�擾
                LoadSupplier();         // �d����擾
                LoadCustRateGrp();      // ���Ӑ�|���f�擾

                //�e�[�u���쐬
                Create_CreditRateDtTable();

                _resultsTbl = new DataTable();
                //�f�[�^���擾���܂�                
                PMKHN09932AA _pMKHN09932A = new PMKHN09932AA();

                _pMKHN09932A.GetDetailInfo(out _resultsTbl, _sectionCode, _unitPriceKind.ToString(), _rateSettingDivide);                

                //�e�[�u���f�[�^�Z�b�g
                int status = SetTable_CreditRateDt(99); //�����100���\��

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
        /// �e�[�u�����쐬���܂�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�[�u�����쐬���܂�</br>
        /// <br>Programmer : 96138 ����  ����</br>
        /// <br>Date       : 2013.11.14</br>
        /// </remarks>
        private void Create_CreditRateDtTable()
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable(CREDITRATEDT_TBL.Name);

            //��̒�`
            dt.Columns.Add(CREDITRATEDT_TBL.CustomerCode, typeof(string));			//string ���Ӑ�R�[�h
            dt.Columns.Add(CREDITRATEDT_TBL.CustomerName, typeof(string));			//string ���Ӑ於��
            dt.Columns.Add(CREDITRATEDT_TBL.CustRateGrpCode, typeof(string));		//string ���Ӑ�|���O���[�v�R�[�h
            dt.Columns.Add(CREDITRATEDT_TBL.CustRateGrpName, typeof(string));		//string ���Ӑ�|���O���[�v����
            dt.Columns.Add(CREDITRATEDT_TBL.SupplierCd, typeof(string));			//string �d����R�[�h
            dt.Columns.Add(CREDITRATEDT_TBL.SupplierName, typeof(string));			//string �d���於��

            dt.Columns.Add(CREDITRATEDT_TBL.GoodsMakerCd, typeof(string));			//string ���i���[�J�[�R�[�h
            dt.Columns.Add(CREDITRATEDT_TBL.GoodsMakerName, typeof(string));		//string ���i���[�J�[����
            dt.Columns.Add(CREDITRATEDT_TBL.GoodsNo,       typeof(string));			//string ���i�ԍ�
            dt.Columns.Add(CREDITRATEDT_TBL.GoodsRateRank, typeof(string));			//string ���i�|�������N

            dt.Columns.Add(CREDITRATEDT_TBL.GoodsRateGrpCode, typeof(string));	    //string ���i�|���O���[�v�R�[�h
            dt.Columns.Add(CREDITRATEDT_TBL.GoodsRateGrpName, typeof(string));	    //string ���i�|���O���[�v����
            dt.Columns.Add(CREDITRATEDT_TBL.BLGroupCode, typeof(string));			//string BL�O���[�v�R�[�h
            dt.Columns.Add(CREDITRATEDT_TBL.BLGroupName, typeof(string));			//string BL�O���[�v����
            dt.Columns.Add(CREDITRATEDT_TBL.BLGoodsCode, typeof(string));			//string BL���i�R�[�h
            dt.Columns.Add(CREDITRATEDT_TBL.BLGoodsName, typeof(string));			//string BL���i����

            //�����o�ϐ��֑ޔ�
            this._dsCreditRateDt = ds;
            this._dsCreditRateDt.Tables.Add(dt);

        }

        /// <summary>
        /// �e�[�u���Ƀf�[�^���Z�b�g���܂�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�[�u���Ƀf�[�^���Z�b�g���܂�</br>
        /// <br>Programmer : 96138 ����  ����</br>
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

                //�S���擾����
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
                    // �L�����Z���{�^�������̏ꍇ
                    if (msgForm.IsCanceled == true)
                    {
                        //��ʂ��I������
                        this.Close();
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        DataRow drSrc = _resultsTbl.Rows[i];

                        if (Convert.ToInt32(drSrc[4]) != 0)
                        {
                            //string ���i���[�J�[�R�[�h
                            dr[CREDITRATEDT_TBL.GoodsMakerCd] = drSrc[4];
                            //string ���i���[�J�[����
                            dr[CREDITRATEDT_TBL.GoodsMakerName] = GetMakerName(Convert.ToInt32(drSrc[4]));
                            _goodsMakerCdCnt++;
                        }

                        if ((drSrc[5]).ToString().Trim() != "")
                        {
                            //string ���i�ԍ�
                            dr[CREDITRATEDT_TBL.GoodsNo] = drSrc[5];
                            _goodsNoCnt++;
                        }

                        if ((drSrc[6]).ToString().Trim() != "")
                        {
                            //string ���i�|�������N
                            dr[CREDITRATEDT_TBL.GoodsRateRank] = drSrc[6];
                            _goodsRateRankCnt++;
                        }

                        if (Convert.ToInt32(drSrc[7]) != 0)
                        {
                            //string ���i�|���O���[�v�R�[�h
                            dr[CREDITRATEDT_TBL.GoodsRateGrpCode] = drSrc[7];
                            //string ���i�|���O���[�v����
                            dr[CREDITRATEDT_TBL.GoodsRateGrpName] = GetGoodsMGroupName(Convert.ToInt32(drSrc[7]));
                            _goodsRateGrpCodeCnt++;
                        }

                        if (Convert.ToInt32(drSrc[8]) != 0)
                        {
                            //string BL�O���[�v�R�[�h
                            dr[CREDITRATEDT_TBL.BLGroupCode] = drSrc[8];
                            //string BL�O���[�v����
                            dr[CREDITRATEDT_TBL.BLGroupName] = GetBLGroupName(Convert.ToInt32(drSrc[8]));
                            _bLGroupCodeCnt++;
                        }

                        if (Convert.ToInt32(drSrc[9]) != 0)
                        {
                            //string BL���i�R�[�h
                            dr[CREDITRATEDT_TBL.BLGoodsCode] = drSrc[9];
                            //string BL���i����
                            dr[CREDITRATEDT_TBL.BLGoodsName] = GetBLGoodsName(Convert.ToInt32(drSrc[9]));
                            _bLGoodsCodeCnt++;
                        }

                        if (Convert.ToInt32(drSrc[10]) != 0)
                        {
                            //string ���Ӑ�R�[�h
                            dr[CREDITRATEDT_TBL.CustomerCode] = drSrc[10];
                            //string ���Ӑ於��
                            dr[CREDITRATEDT_TBL.CustomerName] = GetCustomerName(Convert.ToInt32(drSrc[10]));
                            _customerCodeCnt++;
                        }

                        //string ���Ӑ�O���[�v�R�[�h ���L�b�e�B���O�Ń[���̃f�[�^������
                        dr[CREDITRATEDT_TBL.CustRateGrpCode] = drSrc[11].ToString().PadLeft(4, '0');

                        //string ���Ӑ�O���[�v����
                        dr[CREDITRATEDT_TBL.CustRateGrpName] = GetCustRateGrp(Convert.ToInt32(drSrc[11]));


                        if (Convert.ToInt32(drSrc[12]) != 0)
                        {
                            //string �d����R�[�h
                            dr[CREDITRATEDT_TBL.SupplierCd] = drSrc[12];
                            //string �d���於��
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
                // �G���[�I
                return -1;
            }
        }

        private void ultrBtn_AllSearch_Click(object sender, EventArgs e)
        {

            timer1.Enabled = false;

            // ���o����ʕ��i�̃C���X�^���X���쐬
            msgForm.Title = "���o��";
            msgForm.Message = "�|���ڍאݒ�쐬���c�B";
            msgForm.DispCancelButton = true;
            msgForm.Show();

            try
            {
                dt.Clear();

                //�e�[�u���f�[�^�Z�b�g
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
        /// �|���ڍ׃O���b�h�̏������������܂�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���ڍ׃O���b�h�̏������������܂�</br>
        /// <br>Programmer : 96138 ����  ����</br>
        /// <br>Date       : 2013.11.14</br>
        /// </remarks>
        private void CreditRateDtGrid_InitializeLayout()
        {

            if (CreditRateDtGrid.DataSource == null)
            {
                return;
            }

            //�o���h���擾
            Infragistics.Win.UltraWinGrid.UltraGridBand band = CreditRateDtGrid.DisplayLayout.Bands[CREDITRATEDT_TBL.Name];

            CreditRateDtGrid.DisplayLayout.Override.DefaultRowHeight = 25;

            CreditRateDtGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            CreditRateDtGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

            //�����s�I��ݒ�
            CreditRateDtGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;

            // �s�̍폜��s�Ƃ���B
            CreditRateDtGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;

            // �O���b�h�S�̂̊O�ϐݒ�
            CreditRateDtGrid.DisplayLayout.Appearance.ForeColorDisabled = Color.Black;
            CreditRateDtGrid.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;
            CreditRateDtGrid.DisplayLayout.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(198)), ((System.Byte)(219)), ((System.Byte)(255)));
            CreditRateDtGrid.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // �s�̊O�ϐݒ�
            CreditRateDtGrid.DisplayLayout.Override.RowAppearance.BackColor = System.Drawing.Color.White;

            // 1�s�����̊O�ϐݒ�
            CreditRateDtGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = System.Drawing.Color.Lavender;

            // �A�N�e�B�u�Z���̊O�ϐݒ�
            // �I�����W
            CreditRateDtGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            CreditRateDtGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            CreditRateDtGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            CreditRateDtGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;

            // �w�b�_�[�̊O�ϐݒ�
            CreditRateDtGrid.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
            CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            CreditRateDtGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            //�Z���̊O�ό���
            CreditRateDtGrid.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            //�s�Z���N�^�[�\��
            CreditRateDtGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            ////�s�Z���N�^�[�̊O�ϐݒ�
            //CreditRateDtGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            //CreditRateDtGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            //CreditRateDtGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //�K�w�}�[�N�\���ݒ�
            //CreditRateDtGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;

            //������ʕ\��(�X�v���b�^�[)�̕\���ݒ�
            CreditRateDtGrid.DisplayLayout.MaxRowScrollRegions = 1;

            //�w�b�_�̃L���v�V����
            band.Columns[CREDITRATEDT_TBL.GoodsMakerCd].Header.Caption = "Ұ������";                //���[�J�[�R�[�h
            band.Columns[CREDITRATEDT_TBL.GoodsMakerName].Header.Caption = "Ұ������";              //���[�J�[�i���́j
            band.Columns[CREDITRATEDT_TBL.GoodsNo].Header.Caption = "�i��";                         //�i��
            band.Columns[CREDITRATEDT_TBL.GoodsRateRank].Header.Caption = "�w��";                   //�w��
            band.Columns[CREDITRATEDT_TBL.GoodsRateGrpCode].Header.Caption = "���i�|��G����";       //���i�|��G
            band.Columns[CREDITRATEDT_TBL.GoodsRateGrpName].Header.Caption = "���i�|��G";           //���i�|��G�i���́j
            band.Columns[CREDITRATEDT_TBL.BLGroupCode].Header.Caption = "��ٰ�ߺ���";               //�O���[�v�R�[�h
            band.Columns[CREDITRATEDT_TBL.BLGroupName].Header.Caption = "��ٰ�ߖ���";               //�O���[�v����
            band.Columns[CREDITRATEDT_TBL.BLGoodsCode].Header.Caption = "BL����";                   //BL�R�[�h
            band.Columns[CREDITRATEDT_TBL.BLGoodsName].Header.Caption = "���i����";                 //BL�R�[�h�i���́j
            band.Columns[CREDITRATEDT_TBL.CustomerCode].Header.Caption = "���Ӑ溰��";              //���Ӑ�R�[�h
            band.Columns[CREDITRATEDT_TBL.CustomerName].Header.Caption = "���Ӑ於��";              //���Ӑ於��
            band.Columns[CREDITRATEDT_TBL.CustRateGrpCode].Header.Caption = "���Ӑ�|����ٰ�ߺ���"; //���Ӑ�|���O���[�v�R�[�h
            band.Columns[CREDITRATEDT_TBL.CustRateGrpName].Header.Caption = "���Ӑ�|����ٰ�ߖ���"; //���Ӑ�|���O���[�v����
            band.Columns[CREDITRATEDT_TBL.SupplierCd].Header.Caption = "�d���溰��";                //�d����R�[�h
            band.Columns[CREDITRATEDT_TBL.SupplierName].Header.Caption = "�d���於��";              //�d���於��

            band.Columns[CREDITRATEDT_TBL.GoodsMakerCd].Hidden = false;                             //���[�J�[�R�[�h
            band.Columns[CREDITRATEDT_TBL.GoodsMakerName].Hidden = false;                           //���[�J�[�i���́j           
            band.Columns[CREDITRATEDT_TBL.GoodsNo].Hidden = false;                                  //�i��
            band.Columns[CREDITRATEDT_TBL.GoodsRateRank].Hidden = false;                            //�w��
            band.Columns[CREDITRATEDT_TBL.GoodsRateGrpCode].Hidden = false;                         //���i�|��G
            band.Columns[CREDITRATEDT_TBL.GoodsRateGrpName].Hidden = false;                         //���i�|��G�i���́j
            band.Columns[CREDITRATEDT_TBL.BLGroupCode].Hidden = false;                              //�O���[�v�R�[�h
            band.Columns[CREDITRATEDT_TBL.BLGroupName].Hidden = false;                              //�O���[�v����
            band.Columns[CREDITRATEDT_TBL.BLGoodsCode].Hidden = false;                              //BL�R�[�h
            band.Columns[CREDITRATEDT_TBL.BLGoodsName].Hidden = false;                              //BL�R�[�h�i���́j
            band.Columns[CREDITRATEDT_TBL.CustomerCode].Hidden = false;                             //���Ӑ�R�[�h
            band.Columns[CREDITRATEDT_TBL.CustomerName].Hidden = false;                             //���Ӑ於��
            band.Columns[CREDITRATEDT_TBL.CustRateGrpCode].Hidden = false;                          //���Ӑ�|���O���[�v�R�[�h
            band.Columns[CREDITRATEDT_TBL.CustRateGrpName].Hidden = false;                          //���Ӑ�|���O���[�v����
            band.Columns[CREDITRATEDT_TBL.SupplierCd].Hidden = false;                               //�d����R�[�h
            band.Columns[CREDITRATEDT_TBL.SupplierName].Hidden = false;                             //�d���於��

            if (_goodsMakerCdCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.GoodsMakerCd].Hidden = true;                          //���[�J�[�R�[�h
                band.Columns[CREDITRATEDT_TBL.GoodsMakerName].Hidden = true;                        //���[�J�[�i���́j           
            }
            if (_goodsNoCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.GoodsNo].Hidden = true;                               //�i��
            }
            if (_goodsRateRankCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.GoodsRateRank].Hidden = true;                         //�w��
            }
            if (_goodsRateGrpCodeCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.GoodsRateGrpCode].Hidden = true;                      //���i�|��G
                band.Columns[CREDITRATEDT_TBL.GoodsRateGrpName].Hidden = true;                      //���i�|��G�i���́j
            }
            if (_bLGroupCodeCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.BLGroupCode].Hidden = true;                           //�O���[�v�R�[�h
                band.Columns[CREDITRATEDT_TBL.BLGroupName].Hidden = true;                           //�O���[�v����
            }
            if (_bLGoodsCodeCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.BLGoodsCode].Hidden = true;                           //BL�R�[�h
                band.Columns[CREDITRATEDT_TBL.BLGoodsName].Hidden = true;                           //BL�R�[�h�i���́j
            }            
            if (_customerCodeCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.CustomerCode].Hidden = true;                          //���Ӑ�R�[�h
                band.Columns[CREDITRATEDT_TBL.CustomerName].Hidden = true;                          //���Ӑ於��
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
                band.Columns[CREDITRATEDT_TBL.CustRateGrpCode].Hidden = true;                       //���Ӑ�|���O���[�v�R�[�h
                band.Columns[CREDITRATEDT_TBL.CustRateGrpName].Hidden = true;                       //���Ӑ�|���O���[�v����
            }
            if (_supplierCdCnt == 0)
            {
                band.Columns[CREDITRATEDT_TBL.SupplierCd].Hidden = true;                            //�d����R�[�h
                band.Columns[CREDITRATEDT_TBL.SupplierName].Hidden = true;                          //�d���於��
            }
            
            //�l���X�g�����������A�O���b�h�֒ǉ����܂��B
            CreditRateDtGrid.DisplayLayout.ValueLists.Clear();

            //�e�J�������ʁi�w�b�_�j
            for (int i = 0; i < band.Columns.Count; i++)
            {
                band.Columns[i].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;		//������
                band.Columns[i].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            band.Columns[CREDITRATEDT_TBL.GoodsMakerCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;      //���[�J�[�R�[�h
            band.Columns[CREDITRATEDT_TBL.GoodsMakerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;     //���[�J�[�i���́j
            band.Columns[CREDITRATEDT_TBL.GoodsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;            //�i��
            band.Columns[CREDITRATEDT_TBL.GoodsRateRank].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;     //�w��
            band.Columns[CREDITRATEDT_TBL.GoodsRateGrpCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;  //���i�|��G
            band.Columns[CREDITRATEDT_TBL.GoodsRateGrpName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;   //���i�|��G�i���́j
            band.Columns[CREDITRATEDT_TBL.BLGroupCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;       //�O���[�v�R�[�h
            band.Columns[CREDITRATEDT_TBL.BLGroupName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;        //�O���[�v����
            band.Columns[CREDITRATEDT_TBL.BLGoodsCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;       //BL�R�[�h
            band.Columns[CREDITRATEDT_TBL.BLGoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;        //BL�R�[�h�i���́j
            band.Columns[CREDITRATEDT_TBL.CustomerCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;      //���Ӑ�R�[�h
            band.Columns[CREDITRATEDT_TBL.CustomerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;       //���Ӑ於��
            band.Columns[CREDITRATEDT_TBL.CustRateGrpCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;   //���Ӑ�|���O���[�v�R�[�h
            band.Columns[CREDITRATEDT_TBL.CustRateGrpName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;    //���Ӑ�|���O���[�v����
            band.Columns[CREDITRATEDT_TBL.SupplierCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;        //�d����R�[�h
            band.Columns[CREDITRATEDT_TBL.SupplierName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;       //�d���於��
        }

        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
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
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
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
        /// ���i�|���f�}�X�^�Ǎ�����
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
        /// ���i�|���f���̎擾����
        /// </summary>
        /// <param name="goodsMGroupCode">���i�|���f�R�[�h</param>
        /// <returns>���i�|���f����</returns>
        /// <remarks>
        /// <br>Note       : ���i�|���f���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
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
        /// �O���[�v�R�[�h�}�X�^�Ǎ�����
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
        /// BL�O���[�v���̎擾����
        /// </summary>
        /// <param name="blGroupCode">BL�O���[�v�R�[�h</param>
        /// <returns>BL�O���[�v����</returns>
        /// <remarks>
        /// <br>Note       : BL�O���[�v���̂��擾���܂��B</br>
        /// <br>Programmer : 96138 �����@����</br>
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
        /// BL�R�[�h�}�X�^�Ǎ�����
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
        /// BL�R�[�h���̎擾����
        /// </summary>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <returns>BL�R�[�h����</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h���̂��擾���܂��B</br>
        /// <br>Programmer : 96138 �����@����</br>
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
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於��</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer : 96138 �����@����</br>
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
        /// ���[�U�[�K�C�h�f�[�^�擾����
        /// </summary>
        /// <param name="retList">���[�U�[�K�C�h�{�f�B�f�[�^���X�g</param>
        /// <param name="userGuideDivCd">�K�C�h�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�f�[�^���擾���܂��B</br>
        /// <br>Programmer : 96138 �����@����</br>
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
        /// ���Ӑ�|���O���[�v���擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v�����擾���܂��B</br>
        /// <br>Programmer : 96138 �����@����</br>
        /// <br>Date       : 2013/11/14</br>
        /// </remarks>
        private int LoadCustRateGrp()
        {

            this._custRateGrpDic = new Dictionary<int, UserGdBd>();

            ArrayList retList;

            int status;

            // ���[�U�[�K�C�h�f�[�^�擾(���Ӑ�|���O���[�v)
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
        /// ���Ӑ�|���O���[�v���̎擾����
        /// </summary>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <returns>���Ӑ�|���O���[�v����</returns>
        /// <remarks>
        /// <br>Note       : �d���於�̂��擾���܂��B</br>
        /// <br>Programmer : 96138 �����@����</br>
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
        /// �d����}�X�^�Ǎ�����
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
        /// �d���於�̎擾����
        /// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns>�d���於��</returns>
        /// <remarks>
        /// <br>Note       : �d���於�̂��擾���܂��B</br>
        /// <br>Programmer : 96138 �����@����</br>
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
        /// ToolClick �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <br>Programmer : 96138 ����  ����</br>
        /// <br>Date       : 2013.11.14</br>
        /// </remarks>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {

            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        Close();
                        break;
                    }
            }
        }
        #endregion

        #region ******  �|���ڍ׃e�[�u��  ******
        /// <summary>
        /// �|���ڍ׃e�[�u���̃L�[���[�h���`
        /// </summary>
        public struct CREDITRATEDT_TBL
        {
            /// <summary>
            /// �|���ڍ׃e�[�u����
            /// </summary>
            public const string Name = "CreditRateDt_TBL";

            /// <summary>
            /// ���i���[�J�[�R�[�h
            /// </summary>
            public const string GoodsMakerCd = "GoodsMakerCd";

            /// <summary>
            /// ���i���[�J�[����
            /// </summary>
            public const string GoodsMakerName = "GoodsMakerName";

            /// <summary>
            /// ���i�ԍ�
            /// </summary>
            public const string GoodsNo = "GoodsNo";

            /// <summary>
            /// ���i�|�������N
            /// </summary>
            public const string GoodsRateRank = "GoodsRateRank";

            /// <summary>
            /// ���i�|���O���[�v�R�[�h
            /// </summary>
            public const string GoodsRateGrpCode = "GoodsRateGrpCode";

            /// <summary>
            /// ���i�|���O���[�v����
            /// </summary>
            public const string GoodsRateGrpName = "GoodsRateGrpName";

            /// <summary>
            /// BL�O���[�v�R�[�h
            /// </summary>
            public const string BLGroupCode = "BLGroupCode";

            /// <summary>
            /// BL�O���[�v����
            /// </summary>
            public const string BLGroupName = "BLGroupName";

            /// <summary>
            /// BL���i�R�[�h
            /// </summary>
            public const string BLGoodsCode = "BLGoodsCode";

            /// <summary>
            /// BL���i����
            /// </summary>
            public const string BLGoodsName = "BLGoodsName";

            /// <summary>
            /// ���Ӑ�R�[�h
            /// </summary>
            public const string CustomerCode = "CustomerCode";

            /// <summary>
            /// ���Ӑ於��
            /// </summary>
            public const string CustomerName = "CustomerName";

            /// <summary>
            /// ���Ӑ�|���O���[�v�R�[�h
            /// </summary>
            public const string CustRateGrpCode = "CustRateGrpCode";

            /// <summary>
            /// ���Ӑ�|���O���[�v����
            /// </summary>
            public const string CustRateGrpName = "CustRateGrpName";

            /// <summary>
            /// �d����R�[�h
            /// </summary>
            public const string SupplierCd = "SupplierCd";

            /// <summary>
            /// �d���於��
            /// </summary>
            public const string SupplierName = "SupplierName";
            

        }
        #endregion

        #region ******  �|���ڍ׉�ʋN���p�����[�^  ******
        /// <summary>
        /// �|���ڍ׉�ʋN���p�����[�^
        /// </summary>
        public class PMKHN09931U_Para
        {
            //���_�R�[�h
            private string _sectionCode = "";

            //�P�����
            private int _unitPriceKind = 0;

            //�|���ݒ�敪
            private string _rateSettingDivide = "";

            //�|���ݒ�敪����
            private string _rateSettingDivideName = "";


            //���_�R�[�h
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }

            //�P�����
            public int UnitPriceKind
            {
                get { return _unitPriceKind; }
                set { _unitPriceKind = value; }
            }

            //�|���ݒ�敪
            public string RateSettingDivide
            {
                get { return _rateSettingDivide; }
                set { _rateSettingDivide = value; }
            }

            //�|���ݒ�敪����
            public string RateSettingDivideName
            {
                get { return _rateSettingDivideName; }
                set { _rateSettingDivideName = value; }
            }

        }
        #endregion

    }
}