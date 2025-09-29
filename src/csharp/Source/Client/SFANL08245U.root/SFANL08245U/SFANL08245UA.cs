using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinToolbars;
using System.IO;
using System.Reflection;
using DataDynamics.ActiveReports;
using Broadleaf.Application.Common;
using System.Xml;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolTip;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 自由帳票コンバートスキーマ設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票コンバートスキーマ設定クラスです。</br>
	/// <br>Programmer	: 30015 橋本　裕毅</br>
	/// <br>Date		: 2007.07.23</br>
	/// </remarks>
	public partial class SFANL08245UA : Form
	{
//****** コンストラクタ ********************************************************************************************
		#region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
		public SFANL08245UA()
		{
			InitializeComponent();

			_dataSetSchm = new DataSet(); 
			_dataSetConv = new DataSet(); 
			_dataSetItem = new DataSet(); 

			DataTable _dtSchm; 
			DataTable _dtConv;
			DataTable _dtItem;

			CreateSchemaGr( out _dtSchm );
			CreateSchemaCv( out _dtConv );
			CreateSchemaItem( out _dtItem );

			_dataSetSchm.Tables.Add(_dtSchm); 
			_dataSetConv.Tables.Add(_dtConv);
			_dataSetItem.Tables.Add(_dtItem);

			//　明細タブのツールバーのコンボボックスに値を代入
			Infragistics.Win.ValueList searchTypeList = new ValueList();
			searchTypeList.ValueListItems.Add(10, "項目名称");
			searchTypeList.ValueListItems.Add(20, "DD名称");
			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)SchmConv_tToolbarsManager.Tools["SelectSearch_Combo"]).ValueList = searchTypeList;
			((Infragistics.Win.UltraWinToolbars.ComboBoxTool)SchmConv_tToolbarsManager.Tools["SelectSearch_Combo"]).SelectedIndex = 0;

			this.SchmGroup_tToolbarsManager.Tools["Delete_Button"].SharedProps.Enabled	= false; // 自由帳票スキーマグループ削除ボタン
			this.SchmGroup_tToolbarsManager.Tools["Extend_Button"].SharedProps.Enabled	= false; // 自由帳票スキーマグループ展開ボタン
			this.SchmConv_tToolbarsManager.Tools["Delete_Button"].SharedProps.Enabled	= false; // 自由帳票スキーマコンバート削除ボタン

			// 初期起動時明細タブは非表示にしておく
			this.ultraTabPageControl2.Enabled = false;
		}
		#endregion

//****** Private Members ********************************************************************************************
		#region Private Members

		private DataSet _dataSetSchm;			// スキーマグループ用DataSet
		private DataSet _dataSetConv;			// スキーマコンバート用DataSet
		private DataSet _dataSetItem;			// 印字項目用DataSet
		private Int64 _createDateTime;			// 作成日付
		private Int64 _updateTime;				// 更新日付
		private int _freePrtPprSchmGrpCd;		// 自由帳票スキーマグループコード
		private string _outputFormFileName;		// 出力ファイル名
		private string _outputFileClassId;		// 出力ファイルクラスID
		//private string _outputFormFileNameClone;// 出力ファイル名(比較用)
		//private string _outputFileClassIdClone; // 出力ファイルクラスID(比較用)
		private int _freePrtPprItemGrpCd;		// 自由帳票項目グループコード
		private int _freePrtPprItemGrpCdClone;	// 自由帳票項目グループコード(比較用)
		private int _prevFreePrtPprSchmGrpCd;	// 自由帳票スキーマグループコード
		private int _prevFreePrtPprSchemaCd;	// 自由帳票スキーマコード
		#endregion

//****** Const *****************************************************************************************************
		#region Const

		// MessageBoxヘッダーキャプション
		private const string ctMSG_CAPTION = "自由帳票コンバートスキーマ設定";

		// グループタブ
		// 自由帳票スキーマグループマスタ
		private const string TBL_FPprSchmGr				= "FPprSchmGrRF";			// 自由帳票スキーマグループマスタ
		private const string COL_CREATEDATETIME			= "CreateDateTime";			// 作成日付   
		private const string COL_UPDATETIME				= "UpDateTime";				// 更新日付
		private const string COL_LOGICALDELETECODE		= "LogicalDeleteCode";		// 論理削除区分	
		private const string COL_FREEPRTPPRSCHMGRPCD	= "FreePrtPprSchmGrpCd";	// 自由帳票スキーマグループコード		
		private const string COL_OUTPUTFORMFILENAME		= "OutputFileName";			// 出力ファイル名
		private const string COL_OUTPUTFILECLASSID		= "OutputFileClassId";		// 出力ファイルクラスID		   
		private const string COL_FREEPRTPPRITEMGRPCD	= "FreePrtPPrItemGrpCd";	// 自由帳票印字項目グループコード	
		private const string COL_DISPLAYNAME			= "DisplayName";			// 出力名称
		private const string COL_DATAINPUTSYSTEM		= "DataInputSystem";		// データ入力システム
		private const string COL_PRINTPAPERDIVCD		= "PrintPaperDivCode";		// 帳票区分コード
		private const string COL_PRINTPAPPERUSEDIVCD	= "PrintPaperUseDivcd";		// 帳票使用区分コード
		private const string COL_SPECIALCONVTUSEDIVCD	= "SpecialConvtUseDivCd";	// 特殊コンバート使用区分
		private const string COL_OPTIONCODE				= "OptionCode";				// オプションコード
		private const string COL_FORMFEEDLINECOUNT		= "FormFeedLineCount";		// 改頁行数
		private const string COL_CRCHARCNT				= "CrCharCnt";				// 改行文字数
		private const string COL_TOPMARGIN				= "TopMargin";				// 上余白
		private const string COL_LEFTMARGIN 			= "LeftMargin";				// 左余白
		private const string COL_RIGHTMARGIN			= "RightMargin";			// 右余白
		private const string COL_BOTTOMMARGIN			= "BottomMargin";			// 下余白

		// 明細タブ
		// 自由帳票スキーマコンバートマスタ
		private const string TBL_FPprSchmCv				= "FPprSchmCvRF";			// 自由帳票スキーマコンバートマスタ
		private const string COL_FREEPRTPPRSCHEMACD		= "FreePrtPprSchemaCd";		// 自由帳票スキーマコード
		private const string COL_ACTIVEREPORTCLASSID	= "ActiveReportClassId";	// アクティブレポートクラスID
		private const string COL_ACTIVEREPORTCTRLNM		= "ActiveReportCtrlNm";		// アクティブレポートコントロール名称
		private const string COL_COMMAEDITEXISTCD		= "CommaEditExistCd";		// カンマ編集有無
		private const string COL_PRINTPAGECTRLDIVCD		= "PrintPageCtrlDivCd";		// 印字ページ制御区分
		private const string COL_INITKITFREEPPRITEMCD	= "InitKitFreePprItemCd";	// 初期値用自由帳票項目コード

		// 明細タブ
		// 印字項目設定マスタ
		private const string TBL_PrtItemSet				= "PrtItemSetRF";			// 印字項目設定マスタ
		private const string COL_FREPRTPAPERITEMNM		= "FreePrtPaperItemNm";		// 自由帳票項目名称
		private const string COL_DDNAME					= "DDName";					// DD名称
		private const string COL_FILENM					= "FileNm";					// ファイル名称
		private const string COL_FREEPRTPAPERITEMCD		= "FreePrtPaperItemCd";		// 自由帳票項目コード

		// Switch文にて使用
		private const int schm_index = 1;
		private const int conv_index = 2;
		private const int item_index = 3;

		// 実行環境
		private const string cnt_SFNETASM = "R:\\SFNETASM\\";

		#endregion
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;


		#region Delegate

		/// <summary>
		/// グリッド用非同期デリゲート
		/// </summary>
		/// <param name="rowIndex">行インデックス</param>
		/// <param name="columnName">カラム名</param>
		/// <param name="selectDeleteFlag">判断用フラグ(0:スキーマグループ,1:スキーマコンバート)</param>
		/// <remarks>
		/// <br>Note	   : グリッドにおける非同期実行に使用するデリゲートです。</br>
		/// <br>Programer  : 30015  橋本　裕毅</br>
		/// <br>Date	   : 2007.06.22</br>
		/// </remarks>
		private delegate void GridMethodInvoker(int rowIndex, string columnName, int selectDeleteFlag);

		#endregion

		#region Dispose
		/// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar( "UltraToolbar1" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Open_Button" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "New_Button" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Delete_Button" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Extend_Button" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Copy_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Save_Button" );
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SFANL08245UA ) );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Open_Button" );
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "New_Button" );
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Delete_Button" );
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Extend_Button" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Copy_ButtonTool" );
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar( "UltraToolbar1" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Open_Button" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "New_Button" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Delete_Button" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Extend_Button" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool( "Search_Label" );
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool( "SelectSearch_Combo" );
            Infragistics.Win.UltraWinToolbars.TextBoxTool textBoxTool1 = new Infragistics.Win.UltraWinToolbars.TextBoxTool( "Input_TextBox" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Save_Button" );
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Open_Button" );
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Delete_Button" );
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "New_Button" );
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool( "Search_Label" );
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool2 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool( "SelectSearch_Combo" );
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList( 0 );
            Infragistics.Win.UltraWinToolbars.TextBoxTool textBoxTool2 = new Infragistics.Win.UltraWinToolbars.TextBoxTool( "Input_TextBox" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Extend_Button" );
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar3 = new Infragistics.Win.UltraWinToolbars.UltraToolbar( "UltraToolbar1" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Cancel_Button" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Save_Button" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Cancel_Button" );
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Save_Button" );
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraTabPageControl1_Fill_Panel = new System.Windows.Forms.Panel();
            this.ultraGrid_Schm = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._ultraTabPageControl1_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.SchmGroup_tToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager( this.components );
            this._ultraTabPageControl1_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ultraTabPageControl1_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ultraTabPageControl1_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ultraGrid_Conv = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ultraGrid_Item = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Guide_Button = new Infragistics.Win.Misc.UltraButton();
            this._ultraTabPageControl2_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.SchmConv_tToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager( this.components );
            this._ultraTabPageControl2_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ultraTabPageControl2_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ultraTabPageControl2_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.SFANL08245UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.openFileDialogSchmGr = new System.Windows.Forms.OpenFileDialog();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager( this.components );
            this._SFANL08245UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.tToolbarsManager1 = new Broadleaf.Library.Windows.Forms.TToolbarsManager( this.components );
            this._SFANL08245UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFANL08245UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFANL08245UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl1_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid_Schm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchmGroup_tToolbarsManager)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid_Conv)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid_Item)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SchmConv_tToolbarsManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.SFANL08245UA_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add( this.ultraTabPageControl1_Fill_Panel );
            this.ultraTabPageControl1.Controls.Add( this._ultraTabPageControl1_Toolbars_Dock_Area_Left );
            this.ultraTabPageControl1.Controls.Add( this._ultraTabPageControl1_Toolbars_Dock_Area_Right );
            this.ultraTabPageControl1.Controls.Add( this._ultraTabPageControl1_Toolbars_Dock_Area_Top );
            this.ultraTabPageControl1.Controls.Add( this._ultraTabPageControl1_Toolbars_Dock_Area_Bottom );
            this.ultraTabPageControl1.Location = new System.Drawing.Point( 2, 25 );
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size( 1012, 681 );
            // 
            // ultraTabPageControl1_Fill_Panel
            // 
            this.ultraTabPageControl1_Fill_Panel.Controls.Add( this.ultraGrid_Schm );
            this.ultraTabPageControl1_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ultraTabPageControl1_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabPageControl1_Fill_Panel.Location = new System.Drawing.Point( 0, 26 );
            this.ultraTabPageControl1_Fill_Panel.Name = "ultraTabPageControl1_Fill_Panel";
            this.ultraTabPageControl1_Fill_Panel.Size = new System.Drawing.Size( 1012, 655 );
            this.ultraTabPageControl1_Fill_Panel.TabIndex = 0;
            // 
            // ultraGrid_Schm
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))) );
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid_Schm.DisplayLayout.Appearance = appearance1;
            this.ultraGrid_Schm.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid_Schm.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid_Schm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid_Schm.Location = new System.Drawing.Point( 0, 0 );
            this.ultraGrid_Schm.Name = "ultraGrid_Schm";
            this.ultraGrid_Schm.Size = new System.Drawing.Size( 1012, 655 );
            this.ultraGrid_Schm.TabIndex = 0;
            this.ultraGrid_Schm.BeforeCellUpdate += new Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventHandler( this.ultraGrid_Schm_BeforeCellUpdate );
            this.ultraGrid_Schm.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler( this.ultraGrid_Schm_BeforeEnterEditMode );
            this.ultraGrid_Schm.AfterCellActivate += new System.EventHandler( this.ultraGrid_Schm_AfterCellActivate );
            this.ultraGrid_Schm.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler( this.ultraGrid1_InitializeLayout );
            this.ultraGrid_Schm.BeforeRowActivate += new Infragistics.Win.UltraWinGrid.RowEventHandler( this.ultraGrid_Schm_BeforeRowActivate );
            this.ultraGrid_Schm.KeyDown += new System.Windows.Forms.KeyEventHandler( this.ultraGrid1_KeyDown );
            this.ultraGrid_Schm.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler( this.ultraGrid_Schm_AfterRowUpdate );
            this.ultraGrid_Schm.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler( this.ultraGrid_Schm_AfterCellUpdate );
            this.ultraGrid_Schm.Enter += new System.EventHandler( this.ultraGrid1_Enter );
            // 
            // _ultraTabPageControl1_Toolbars_Dock_Area_Left
            // 
            this._ultraTabPageControl1_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point( 0, 26 );
            this._ultraTabPageControl1_Toolbars_Dock_Area_Left.Name = "_ultraTabPageControl1_Toolbars_Dock_Area_Left";
            this._ultraTabPageControl1_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size( 0, 655 );
            this._ultraTabPageControl1_Toolbars_Dock_Area_Left.ToolbarsManager = this.SchmGroup_tToolbarsManager;
            // 
            // SchmGroup_tToolbarsManager
            // 
            this.SchmGroup_tToolbarsManager.DesignerFlags = 1;
            this.SchmGroup_tToolbarsManager.DockWithinContainer = this.ultraTabPageControl1;
            this.SchmGroup_tToolbarsManager.ImageTransparentColor = System.Drawing.Color.Cyan;
            this.SchmGroup_tToolbarsManager.ShowFullMenusDelay = 500;
            this.SchmGroup_tToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5} );
            ultraToolbar1.Text = "UltraToolbar1";
            this.SchmGroup_tToolbarsManager.Toolbars.AddRange( new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1} );
            appearance2.Image = ((object)(resources.GetObject( "appearance2.Image" )));
            buttonTool6.SharedProps.AppearancesSmall.Appearance = appearance2;
            buttonTool6.SharedProps.Caption = "保存(&S)";
            buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance3.Image = ((object)(resources.GetObject( "appearance3.Image" )));
            buttonTool7.SharedProps.AppearancesSmall.Appearance = appearance3;
            buttonTool7.SharedProps.Caption = "開く(&O)";
            buttonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance4.Image = ((object)(resources.GetObject( "appearance4.Image" )));
            buttonTool8.SharedProps.AppearancesSmall.Appearance = appearance4;
            buttonTool8.SharedProps.Caption = "行追加(&N)";
            buttonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance5.Image = ((object)(resources.GetObject( "appearance5.Image" )));
            buttonTool9.SharedProps.AppearancesSmall.Appearance = appearance5;
            buttonTool9.SharedProps.Caption = "行削除(&D)";
            buttonTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool10.SharedProps.Caption = "展開(&F)";
            buttonTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool11.SharedProps.Caption = "コピー（&C）";
            buttonTool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.SchmGroup_tToolbarsManager.Tools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool6,
            buttonTool7,
            buttonTool8,
            buttonTool9,
            buttonTool10,
            buttonTool11} );
            this.SchmGroup_tToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler( this.SchmGroup_tToolbarsManager_ToolClick );
            // 
            // _ultraTabPageControl1_Toolbars_Dock_Area_Right
            // 
            this._ultraTabPageControl1_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point( 1012, 26 );
            this._ultraTabPageControl1_Toolbars_Dock_Area_Right.Name = "_ultraTabPageControl1_Toolbars_Dock_Area_Right";
            this._ultraTabPageControl1_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size( 0, 655 );
            this._ultraTabPageControl1_Toolbars_Dock_Area_Right.ToolbarsManager = this.SchmGroup_tToolbarsManager;
            // 
            // _ultraTabPageControl1_Toolbars_Dock_Area_Top
            // 
            this._ultraTabPageControl1_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point( 0, 0 );
            this._ultraTabPageControl1_Toolbars_Dock_Area_Top.Name = "_ultraTabPageControl1_Toolbars_Dock_Area_Top";
            this._ultraTabPageControl1_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size( 1012, 26 );
            this._ultraTabPageControl1_Toolbars_Dock_Area_Top.ToolbarsManager = this.SchmGroup_tToolbarsManager;
            // 
            // _ultraTabPageControl1_Toolbars_Dock_Area_Bottom
            // 
            this._ultraTabPageControl1_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ultraTabPageControl1_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point( 0, 681 );
            this._ultraTabPageControl1_Toolbars_Dock_Area_Bottom.Name = "_ultraTabPageControl1_Toolbars_Dock_Area_Bottom";
            this._ultraTabPageControl1_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size( 1012, 0 );
            this._ultraTabPageControl1_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.SchmGroup_tToolbarsManager;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add( this.splitContainer1 );
            this.ultraTabPageControl2.Controls.Add( this._ultraTabPageControl2_Toolbars_Dock_Area_Left );
            this.ultraTabPageControl2.Controls.Add( this._ultraTabPageControl2_Toolbars_Dock_Area_Right );
            this.ultraTabPageControl2.Controls.Add( this._ultraTabPageControl2_Toolbars_Dock_Area_Top );
            this.ultraTabPageControl2.Controls.Add( this._ultraTabPageControl2_Toolbars_Dock_Area_Bottom );
            this.ultraTabPageControl2.Location = new System.Drawing.Point( -10000, -10000 );
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size( 1012, 681 );
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point( 0, 26 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.panel2 );
            this.splitContainer1.Panel1.Controls.Add( this.panel1 );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.panel4 );
            this.splitContainer1.Panel2.Controls.Add( this.panel3 );
            this.splitContainer1.Size = new System.Drawing.Size( 1012, 655 );
            this.splitContainer1.SplitterDistance = 712;
            this.splitContainer1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.ultraGrid_Conv );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 0, 33 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 712, 622 );
            this.panel2.TabIndex = 1;
            // 
            // ultraGrid_Conv
            // 
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))) );
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.Color.Black;
            this.ultraGrid_Conv.DisplayLayout.Appearance = appearance6;
            this.ultraGrid_Conv.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid_Conv.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid_Conv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid_Conv.Location = new System.Drawing.Point( 0, 0 );
            this.ultraGrid_Conv.Name = "ultraGrid_Conv";
            this.ultraGrid_Conv.Size = new System.Drawing.Size( 712, 622 );
            this.ultraGrid_Conv.TabIndex = 7;
            this.ultraGrid_Conv.BeforeCellUpdate += new Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventHandler( this.ultraGrid_Schm_BeforeCellUpdate );
            this.ultraGrid_Conv.AfterCellActivate += new System.EventHandler( this.ultraGrid_Schm_AfterCellActivate );
            this.ultraGrid_Conv.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler( this.ultraGrid1_InitializeLayout );
            this.ultraGrid_Conv.BeforeRowActivate += new Infragistics.Win.UltraWinGrid.RowEventHandler( this.ultraGrid_Schm_BeforeRowActivate );
            this.ultraGrid_Conv.KeyDown += new System.Windows.Forms.KeyEventHandler( this.ultraGrid1_KeyDown );
            this.ultraGrid_Conv.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler( this.ultraGrid_Schm_AfterRowUpdate );
            this.ultraGrid_Conv.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler( this.ultraGrid_Schm_AfterCellUpdate );
            this.ultraGrid_Conv.Enter += new System.EventHandler( this.ultraGrid1_Enter );
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.ultraLabel2 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 712, 33 );
            this.panel1.TabIndex = 0;
            // 
            // ultraLabel2
            // 
            appearance7.BorderColor = System.Drawing.Color.Black;
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Center";
            appearance7.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance7;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.FromArgb( ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))) );
            this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ultraLabel2.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ultraLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel2.Location = new System.Drawing.Point( 0, 0 );
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size( 712, 33 );
            this.ultraLabel2.TabIndex = 6;
            this.ultraLabel2.Text = "テーブル";
            // 
            // panel4
            // 
            this.panel4.Controls.Add( this.ultraGrid_Item );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point( 0, 33 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 296, 622 );
            this.panel4.TabIndex = 1;
            // 
            // ultraGrid_Item
            // 
            appearance8.BackColor = System.Drawing.Color.White;
            appearance8.BackColor2 = System.Drawing.Color.FromArgb( ((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))) );
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.Color.Black;
            this.ultraGrid_Item.DisplayLayout.Appearance = appearance8;
            this.ultraGrid_Item.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Dashed;
            this.ultraGrid_Item.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Dashed;
            this.ultraGrid_Item.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid_Item.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid_Item.Location = new System.Drawing.Point( 0, 0 );
            this.ultraGrid_Item.Name = "ultraGrid_Item";
            this.ultraGrid_Item.Size = new System.Drawing.Size( 296, 622 );
            this.ultraGrid_Item.TabIndex = 5;
            this.ultraGrid_Item.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler( this.ultraGrid1_InitializeLayout );
            this.ultraGrid_Item.Enter += new System.EventHandler( this.ultraGrid1_Enter );
            this.ultraGrid_Item.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler( this.ultraGrid_Item_DoubleClickRow );
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.panel6 );
            this.panel3.Controls.Add( this.panel5 );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point( 0, 0 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 296, 33 );
            this.panel3.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add( this.ultraLabel3 );
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point( 0, 0 );
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size( 248, 33 );
            this.panel6.TabIndex = 0;
            // 
            // ultraLabel3
            // 
            appearance9.BorderColor = System.Drawing.Color.Black;
            appearance9.ForeColor = System.Drawing.Color.White;
            appearance9.TextHAlignAsString = "Center";
            appearance9.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance9;
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.FromArgb( ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))) );
            this.ultraLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ultraLabel3.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ultraLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel3.Location = new System.Drawing.Point( 0, 0 );
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size( 248, 33 );
            this.ultraLabel3.TabIndex = 2;
            this.ultraLabel3.Text = "印字項目";
            // 
            // panel5
            // 
            this.panel5.Controls.Add( this.Guide_Button );
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point( 248, 0 );
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size( 48, 33 );
            this.panel5.TabIndex = 0;
            // 
            // Guide_Button
            // 
            appearance10.Image = ((object)(resources.GetObject( "appearance10.Image" )));
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance10.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.Guide_Button.Appearance = appearance10;
            this.Guide_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Guide_Button.ImageTransparentColor = System.Drawing.Color.Cyan;
            this.Guide_Button.Location = new System.Drawing.Point( 0, 0 );
            this.Guide_Button.Name = "Guide_Button";
            this.Guide_Button.Size = new System.Drawing.Size( 48, 33 );
            this.Guide_Button.TabIndex = 3;
            this.Guide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Guide_Button.Click += new System.EventHandler( this.Guide_Button_Click );
            // 
            // _ultraTabPageControl2_Toolbars_Dock_Area_Left
            // 
            this._ultraTabPageControl2_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point( 0, 26 );
            this._ultraTabPageControl2_Toolbars_Dock_Area_Left.Name = "_ultraTabPageControl2_Toolbars_Dock_Area_Left";
            this._ultraTabPageControl2_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size( 0, 655 );
            this._ultraTabPageControl2_Toolbars_Dock_Area_Left.ToolbarsManager = this.SchmConv_tToolbarsManager;
            // 
            // SchmConv_tToolbarsManager
            // 
            this.SchmConv_tToolbarsManager.DesignerFlags = 1;
            this.SchmConv_tToolbarsManager.DockWithinContainer = this.ultraTabPageControl2;
            this.SchmConv_tToolbarsManager.ImageTransparentColor = System.Drawing.Color.Cyan;
            this.SchmConv_tToolbarsManager.ShowFullMenusDelay = 500;
            this.SchmConv_tToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 0;
            ultraToolbar2.FloatingSize = new System.Drawing.Size( 645, 24 );
            labelTool1.InstanceProps.Width = 104;
            ultraToolbar2.NonInheritedTools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool12,
            buttonTool13,
            buttonTool14,
            buttonTool15,
            labelTool1,
            comboBoxTool1,
            textBoxTool1} );
            ultraToolbar2.Text = "UltraToolbar1";
            this.SchmConv_tToolbarsManager.Toolbars.AddRange( new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar2} );
            appearance11.Image = ((object)(resources.GetObject( "appearance11.Image" )));
            buttonTool16.SharedProps.AppearancesSmall.Appearance = appearance11;
            buttonTool16.SharedProps.Caption = "保存(&S)";
            buttonTool16.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance12.Image = ((object)(resources.GetObject( "appearance12.Image" )));
            buttonTool17.SharedProps.AppearancesSmall.Appearance = appearance12;
            buttonTool17.SharedProps.Caption = "開く(&O)";
            buttonTool17.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance13.Image = ((object)(resources.GetObject( "appearance13.Image" )));
            buttonTool18.SharedProps.AppearancesSmall.Appearance = appearance13;
            buttonTool18.SharedProps.Caption = "行削除(&D)";
            buttonTool18.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance14.Image = ((object)(resources.GetObject( "appearance14.Image" )));
            buttonTool19.SharedProps.AppearancesSmall.Appearance = appearance14;
            buttonTool19.SharedProps.Caption = "行追加(&N)";
            buttonTool19.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool2.SharedProps.Caption = "印字項目検索";
            comboBoxTool2.ValueList = valueList1;
            buttonTool20.SharedProps.Caption = "展開（&F）";
            buttonTool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.SchmConv_tToolbarsManager.Tools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool16,
            buttonTool17,
            buttonTool18,
            buttonTool19,
            labelTool2,
            comboBoxTool2,
            textBoxTool2,
            buttonTool20} );
            this.SchmConv_tToolbarsManager.ToolValueChanged += new Infragistics.Win.UltraWinToolbars.ToolEventHandler( this.SchmConv_tToolbarsManager_ToolValueChanged );
            this.SchmConv_tToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler( this.SchmGroup_tToolbarsManager_ToolClick );
            // 
            // _ultraTabPageControl2_Toolbars_Dock_Area_Right
            // 
            this._ultraTabPageControl2_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point( 1012, 26 );
            this._ultraTabPageControl2_Toolbars_Dock_Area_Right.Name = "_ultraTabPageControl2_Toolbars_Dock_Area_Right";
            this._ultraTabPageControl2_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size( 0, 655 );
            this._ultraTabPageControl2_Toolbars_Dock_Area_Right.ToolbarsManager = this.SchmConv_tToolbarsManager;
            // 
            // _ultraTabPageControl2_Toolbars_Dock_Area_Top
            // 
            this._ultraTabPageControl2_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point( 0, 0 );
            this._ultraTabPageControl2_Toolbars_Dock_Area_Top.Name = "_ultraTabPageControl2_Toolbars_Dock_Area_Top";
            this._ultraTabPageControl2_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size( 1012, 26 );
            this._ultraTabPageControl2_Toolbars_Dock_Area_Top.ToolbarsManager = this.SchmConv_tToolbarsManager;
            // 
            // _ultraTabPageControl2_Toolbars_Dock_Area_Bottom
            // 
            this._ultraTabPageControl2_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ultraTabPageControl2_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point( 0, 681 );
            this._ultraTabPageControl2_Toolbars_Dock_Area_Bottom.Name = "_ultraTabPageControl2_Toolbars_Dock_Area_Bottom";
            this._ultraTabPageControl2_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size( 1012, 0 );
            this._ultraTabPageControl2_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.SchmConv_tToolbarsManager;
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.BackColorInternal = System.Drawing.Color.FromArgb( ((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))) );
            this.ultraTabControl1.Controls.Add( this.ultraTabSharedControlsPage1 );
            this.ultraTabControl1.Controls.Add( this.ultraTabPageControl1 );
            this.ultraTabControl1.Controls.Add( this.ultraTabPageControl2 );
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point( 0, 0 );
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size( 1016, 708 );
            this.ultraTabControl1.TabIndex = 0;
            ultraTab1.Key = "0";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "グループ";
            ultraTab2.Key = "1";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "明細";
            this.ultraTabControl1.Tabs.AddRange( new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2} );
            this.ultraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.ultraTabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler( this.ultraTabControl1_KeyDown );
            this.ultraTabControl1.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler( this.ultraTabControl1_SelectedTabChanged );
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point( -10000, -10000 );
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size( 1012, 681 );
            // 
            // SFANL08245UA_Fill_Panel
            // 
            this.SFANL08245UA_Fill_Panel.Controls.Add( this.ultraTabControl1 );
            this.SFANL08245UA_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SFANL08245UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SFANL08245UA_Fill_Panel.Location = new System.Drawing.Point( 0, 26 );
            this.SFANL08245UA_Fill_Panel.Name = "SFANL08245UA_Fill_Panel";
            this.SFANL08245UA_Fill_Panel.Size = new System.Drawing.Size( 1016, 708 );
            this.SFANL08245UA_Fill_Panel.TabIndex = 0;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // _SFANL08245UA_Toolbars_Dock_Area_Left
            // 
            this._SFANL08245UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFANL08245UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._SFANL08245UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFANL08245UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFANL08245UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point( 0, 26 );
            this._SFANL08245UA_Toolbars_Dock_Area_Left.Name = "_SFANL08245UA_Toolbars_Dock_Area_Left";
            this._SFANL08245UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size( 0, 708 );
            this._SFANL08245UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.tToolbarsManager1;
            // 
            // tToolbarsManager1
            // 
            this.tToolbarsManager1.DesignerFlags = 1;
            this.tToolbarsManager1.DockWithinContainer = this;
            this.tToolbarsManager1.DockWithinContainerBaseType = typeof( System.Windows.Forms.Form );
            this.tToolbarsManager1.ImageTransparentColor = System.Drawing.Color.Cyan;
            this.tToolbarsManager1.ShowFullMenusDelay = 500;
            this.tToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar3.DockedColumn = 0;
            ultraToolbar3.DockedRow = 0;
            ultraToolbar3.NonInheritedTools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool21,
            buttonTool22} );
            ultraToolbar3.Text = "UltraToolbar1";
            this.tToolbarsManager1.Toolbars.AddRange( new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar3} );
            appearance15.Image = ((object)(resources.GetObject( "appearance15.Image" )));
            buttonTool23.SharedProps.AppearancesSmall.Appearance = appearance15;
            buttonTool23.SharedProps.Caption = "終了(&X)";
            buttonTool23.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance16.Image = ((object)(resources.GetObject( "appearance16.Image" )));
            buttonTool24.SharedProps.AppearancesSmall.Appearance = appearance16;
            buttonTool24.SharedProps.Caption = "保存（&S）";
            buttonTool24.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.tToolbarsManager1.Tools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool23,
            buttonTool24} );
            this.tToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler( this.tToolbarsManager1_ToolClick );
            // 
            // _SFANL08245UA_Toolbars_Dock_Area_Right
            // 
            this._SFANL08245UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFANL08245UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._SFANL08245UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFANL08245UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFANL08245UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point( 1016, 26 );
            this._SFANL08245UA_Toolbars_Dock_Area_Right.Name = "_SFANL08245UA_Toolbars_Dock_Area_Right";
            this._SFANL08245UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size( 0, 708 );
            this._SFANL08245UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.tToolbarsManager1;
            // 
            // _SFANL08245UA_Toolbars_Dock_Area_Top
            // 
            this._SFANL08245UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFANL08245UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._SFANL08245UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SFANL08245UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFANL08245UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point( 0, 0 );
            this._SFANL08245UA_Toolbars_Dock_Area_Top.Name = "_SFANL08245UA_Toolbars_Dock_Area_Top";
            this._SFANL08245UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size( 1016, 26 );
            this._SFANL08245UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.tToolbarsManager1;
            // 
            // _SFANL08245UA_Toolbars_Dock_Area_Bottom
            // 
            this._SFANL08245UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFANL08245UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._SFANL08245UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SFANL08245UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFANL08245UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point( 0, 734 );
            this._SFANL08245UA_Toolbars_Dock_Area_Bottom.Name = "_SFANL08245UA_Toolbars_Dock_Area_Bottom";
            this._SFANL08245UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size( 1016, 0 );
            this._SFANL08245UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.tToolbarsManager1;
            // 
            // SFANL08245UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 15F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 1016, 734 );
            this.Controls.Add( this.SFANL08245UA_Fill_Panel );
            this.Controls.Add( this._SFANL08245UA_Toolbars_Dock_Area_Left );
            this.Controls.Add( this._SFANL08245UA_Toolbars_Dock_Area_Right );
            this.Controls.Add( this._SFANL08245UA_Toolbars_Dock_Area_Top );
            this.Controls.Add( this._SFANL08245UA_Toolbars_Dock_Area_Bottom );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Margin = new System.Windows.Forms.Padding( 4 );
            this.Name = "SFANL08245UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自由帳票コンバートスキーマ設定";
            this.Load += new System.EventHandler( this.SFANL08245UA_Load );
            this.ultraTabPageControl1.ResumeLayout( false );
            this.ultraTabPageControl1_Fill_Panel.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid_Schm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchmGroup_tToolbarsManager)).EndInit();
            this.ultraTabPageControl2.ResumeLayout( false );
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            this.panel2.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid_Conv)).EndInit();
            this.panel1.ResumeLayout( false );
            this.panel4.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid_Item)).EndInit();
            this.panel3.ResumeLayout( false );
            this.panel6.ResumeLayout( false );
            this.panel5.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.SchmConv_tToolbarsManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout( false );
            this.SFANL08245UA_Fill_Panel.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager1)).EndInit();
            this.ResumeLayout( false );

        }

        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Broadleaf.Library.Windows.Forms.TToolbarsManager tToolbarsManager1;
        private System.Windows.Forms.Panel SFANL08245UA_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL08245UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL08245UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL08245UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL08245UA_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
		private System.Windows.Forms.Panel ultraTabPageControl1_Fill_Panel;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid_Schm;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ultraTabPageControl1_Toolbars_Dock_Area_Left;
        private Broadleaf.Library.Windows.Forms.TToolbarsManager SchmGroup_tToolbarsManager;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ultraTabPageControl1_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ultraTabPageControl1_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ultraTabPageControl1_Toolbars_Dock_Area_Bottom;
		private System.Windows.Forms.OpenFileDialog openFileDialogSchmGr;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ultraTabPageControl2_Toolbars_Dock_Area_Left;
        private Broadleaf.Library.Windows.Forms.TToolbarsManager SchmConv_tToolbarsManager;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ultraTabPageControl2_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ultraTabPageControl2_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ultraTabPageControl2_Toolbars_Dock_Area_Bottom;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraButton Guide_Button;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid_Item;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid_Conv;

        #endregion

//****** Private Methods ********************************************************************************************
		#region Private Methods

		/// <summary>
		/// 自由帳票ガイドデータテーブルスキーマ作成処理(スキーマグループ)
		/// </summary>
		/// <param name="dt"></param>
		/// <remarks>
		/// <br>Note		: 自由帳票ガイドのスキーマを作成します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void CreateSchemaGr(out DataTable dt)
		{
			//列を設定
			dt = new DataTable(TBL_FPprSchmGr);
			dt.Columns.Add( COL_CREATEDATETIME		, typeof( long ) );		// 作成日付
			dt.Columns.Add( COL_UPDATETIME			, typeof( long ) );		// 更新日付
			dt.Columns.Add( COL_LOGICALDELETECODE   , typeof( int ) );		// 論理削除
			dt.Columns.Add( COL_FREEPRTPPRSCHMGRPCD	, typeof( int ) );		// 自由帳票スキーマグループコード
			dt.Columns.Add( COL_OUTPUTFORMFILENAME  , typeof( string ) );   // 出力ファイル名称
			dt.Columns.Add( COL_OUTPUTFILECLASSID   , typeof( string ) );   // 出力ファイルクラスID
			dt.Columns.Add( COL_FREEPRTPPRITEMGRPCD , typeof( int ) );		// 自由帳票項目グループコード
			dt.Columns.Add( COL_DISPLAYNAME			, typeof( string ) );   // 表示名称
			dt.Columns.Add( COL_DATAINPUTSYSTEM		, typeof( int ) );		// データ入力システム
			dt.Columns.Add( COL_PRINTPAPERDIVCD		, typeof( int ) );		// 帳票区分
			dt.Columns.Add( COL_PRINTPAPPERUSEDIVCD , typeof( int ) );		// 帳票使用区分
			dt.Columns.Add( COL_SPECIALCONVTUSEDIVCD , typeof( int ) );		// 特殊コンバート使用区分
			dt.Columns.Add( COL_OPTIONCODE			, typeof( string ) );	// オプションコード
			dt.Columns.Add( COL_FORMFEEDLINECOUNT	, typeof( int ) );		// 改頁行数
			dt.Columns.Add( COL_CRCHARCNT			, typeof( int ) );		// 改行文字数
			dt.Columns.Add( COL_TOPMARGIN			, typeof( Double ) );	// 上余白
			dt.Columns.Add( COL_LEFTMARGIN			, typeof( Double ) );	// 左余白
			dt.Columns.Add( COL_RIGHTMARGIN			, typeof( Double ) );	// 右余白
			dt.Columns.Add( COL_BOTTOMMARGIN		, typeof( Double ) );	// 下余白

		}

		/// <summary>
		/// 自由帳票ガイドデータテーブルスキーマ作成処理(コンバート)
		/// </summary>
		/// <param name="dt"></param>
		/// <remarks>
		/// <br>Note		: 自由帳票ガイド(スキーマグループ)のスキーマを作成します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void CreateSchemaCv(out DataTable dt)
		{
			//列を設定
			dt = new DataTable(TBL_FPprSchmCv);
			dt.Columns.Add( COL_CREATEDATETIME		, typeof( long ) );		// 作成日付
			dt.Columns.Add( COL_UPDATETIME			, typeof( long ) );		// 更新日付
			dt.Columns.Add( COL_LOGICALDELETECODE   , typeof( int ) );		// 論理削除
			dt.Columns.Add( COL_FREEPRTPPRSCHMGRPCD , typeof( int ) );		// 自由帳票スキーマグループコード
			dt.Columns.Add( COL_FREEPRTPPRSCHEMACD  , typeof( int ) );		// 自由帳票スキーマコード
			dt.Columns.Add( COL_FREEPRTPAPERITEMCD  , typeof( int ) );		// 自由帳票項目コード
			dt.Columns.Add( COL_ACTIVEREPORTCLASSID , typeof( string ) );	// アクティブレポートクラスID
			dt.Columns.Add( COL_ACTIVEREPORTCTRLNM  , typeof( string ) );   // アクティブレポートコントロール名称
			dt.Columns.Add( COL_COMMAEDITEXISTCD	, typeof( int ) );		// カンマ編集有無
			dt.Columns.Add( COL_PRINTPAGECTRLDIVCD  , typeof( int ) );		// 印字ページ制御区分
			dt.Columns.Add( COL_OUTPUTFORMFILENAME  , typeof( string ) );   // 出力ファイル名称
			dt.Columns.Add( COL_OUTPUTFILECLASSID   , typeof( string ) );   // 出力ファイルクラスID
			dt.Columns.Add( COL_INITKITFREEPPRITEMCD, typeof( int ) );		// 初期値用自由帳票項目コード
		}

		/// <summary>
		/// 自由帳票ガイドデータテーブルスキーマ作成処理(印字項目)
		/// </summary>
		/// <param name="dt"></param>
		/// <remarks>
		/// <br>Note		: 自由帳票ガイド(印字項目)のスキーマを作成します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void CreateSchemaItem(out DataTable dt)
		{
			//列を設定
			dt = new DataTable(TBL_PrtItemSet);
			dt.Columns.Add( COL_FREPRTPAPERITEMNM	, typeof( string ) );   // 自由帳票項目名称
			dt.Columns.Add( COL_DDNAME				, typeof( string ) );   // DD名称
			dt.Columns.Add( COL_FILENM				, typeof( string ) );   // ファイル名称
			dt.Columns.Add( COL_FREEPRTPAPERITEMCD  , typeof( int ) );		// 自由帳票項目コード
			dt.Columns.Add( COL_COMMAEDITEXISTCD	, typeof( int ) );		// カンマ編集有無
			dt.Columns.Add( COL_PRINTPAGECTRLDIVCD  , typeof( int ) );		// 印字ページ制御区分
		}

		/// <summary>
		/// Save処理
		/// </summary>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <remarks>
		/// <br>Note	   : 保存ボタンが押された時の処理です。</br>
		/// <br>Programer  : 30015  橋本　裕毅</br>
		/// <br>Date	   : 2007.06.22</br>
		/// </remarks>
		private int SaveProc(out string errMsg)
		{
			int status = 0;
			errMsg = string.Empty;

			string fileName = string.Empty;
			try
			{
				// 入力チェック
				if (!CheckInputData(out errMsg))
					return 4;

				if (_dataSetSchm.Tables[TBL_FPprSchmGr].Rows.Count != 0 ||
					_dataSetConv.Tables[TBL_FPprSchmCv].Rows.Count != 0)
				{
					Directory.SetCurrentDirectory(System.Windows.Forms.Application.StartupPath);

					// CSVファイルの保存
					// スキーマグループ
					fileName = Path.Combine(SFANL08246CA.ctCSVSavePath, TBL_FPprSchmGr + ".csv");
					status = SFANL08246CA.SaveCsv(_dataSetSchm, TBL_FPprSchmGr, SFANL08246CA.ctXSLFileName, fileName, out errMsg);
					// スキーマコンバート
					if (status == 0)
					{
						fileName = Path.Combine(SFANL08246CA.ctCSVSavePath, TBL_FPprSchmCv + ".csv");
						status = SFANL08246CA.SaveCsv(_dataSetConv, TBL_FPprSchmCv, SFANL08246CA.ctXSLFileName, fileName, out errMsg);
					}

					// XMLファイルの保存
					if (status == 0)
					{
						string filter = string.Empty;
						foreach (DataRow dr in _dataSetSchm.Tables[TBL_FPprSchmGr].Rows)
						{
							int freePrtPprSchmaGrpCd = (int)dr[COL_FREEPRTPPRSCHMGRPCD];
							filter = COL_FREEPRTPPRSCHMGRPCD + "=" + freePrtPprSchmaGrpCd;
							fileName = Path.Combine(SFANL08246CA.ctXMLSavePath, TBL_FPprSchmGr + "_" + freePrtPprSchmaGrpCd + ".xml");
							status = SFANL08246CA.SaveXml(_dataSetSchm, TBL_FPprSchmGr, filter, fileName, out errMsg);
							if (status == 0)
							{
								fileName = Path.Combine(SFANL08246CA.ctXMLSavePath, TBL_FPprSchmCv + "_" + freePrtPprSchmaGrpCd + ".xml");
								status = SFANL08246CA.SaveXml(_dataSetConv, TBL_FPprSchmCv, filter, fileName, out errMsg);
							}

							if (status != 0) break;
							else this.ultraTabPageControl2.Enabled = true;
						}
					}
				}
				else
				{
					status = 4;
					errMsg = "データが入力されていません。";
				}
			}
			catch (Exception ex)
			{
				errMsg = "保存処理にて例外が発生しました。" + ex.Message;

				status = -1;
			}

			return status;

		}

		/// <summary>
		/// Open処理
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 開くボタンが押された時の処理です。(対象はスキーマグループマスタと印字項目設定マスタ)</br>
		/// <br>Programer  : 30015  橋本　裕毅</br>
		/// <br>Date	   : 2007.06.22</br>
		/// </remarks>
		private void OpenProc()
		{
			try
			{
				// グループタブの開く
				if (ultraTabControl1.SelectedTab.Key == "0")
				{
					this.OpenFileDialogGridSet(schm_index);

					if (this.ultraGrid_Schm.Rows.Count > 0)
					{
						this.SchmGroup_tToolbarsManager.Tools["Delete_Button"].SharedProps.Enabled	= true;
						this.SchmGroup_tToolbarsManager.Tools["Extend_Button"].SharedProps.Enabled	= true;
						this.SchmConv_tToolbarsManager.Tools["Delete_Button"].SharedProps.Enabled	= true;
						this.ultraTabPageControl2.Enabled = true;
					}
				}
				else
				{
					this.OpenFileDialogGridSet(conv_index);

					if (this.ultraGrid_Conv.Rows.Count > 0)
					{
						this.SchmConv_tToolbarsManager.Tools["Extend_Button"].SharedProps.Enabled	= true;
					}
				}
			}
			catch (Exception ex)
			{
				ShowMessageDialog("ファイルのオープンに失敗しました。\r\n\r\n", ex, -1);
			}

		}

		/// <summary>
		/// 新規行追加処理(スキーマコンバート)
		/// </summary>
		/// <param name="control">コントロール</param>
		/// <param name="ar">アクティブレポートクラス</param>
		/// <remarks>
		/// <br>Note	   : 新規で行を追加した時の処理です。</br>
		/// <br>Programer  : 30015  橋本　裕毅</br>
		/// <br>Date	   : 2007.06.22</br>
		/// </remarks>
		private void AddNewRowSchmConv(ARControl control, ActiveReport3 ar)
		{
			int index;
			// 新規と判断して、行を追加する
			DataRow dataRow = this._dataSetConv.Tables[TBL_FPprSchmCv].NewRow();
			this._dataSetConv.Tables[TBL_FPprSchmCv].Rows.Add(dataRow);
							
			// indexを行の最終行番号する
			if (ultraTabControl1.SelectedTab.Key == "0")
			{
				index = this._dataSetConv.Tables[TBL_FPprSchmCv].DefaultView.Count - 1;			
			}
			else
			{
				index = this._dataSetConv.Tables[TBL_FPprSchmCv].Rows.Count - 1;
			}
			
			this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_CREATEDATETIME]	  = _createDateTime;				// 作成日付
			this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_UPDATETIME]		  = _updateTime;					// 更新日付
			this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_LOGICALDELETECODE]	  = 0;								// 論理削除区分
			this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_FREEPRTPPRSCHMGRPCD] = _freePrtPprSchmGrpCd;			// 自由帳票スキーマグループコード
			this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_FREEPRTPPRSCHEMACD]  = index + 1;						// 自由帳票スキーマコード
			this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_FREEPRTPAPERITEMCD]  = 0;								// 自由帳票項目コード(101以降でユーザーが好きに連番に出来るようにする)
			this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_ACTIVEREPORTCLASSID] = ar.GetType().Name;				// アクティブレポートクラスID
			this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_ACTIVEREPORTCTRLNM]  = control.Name;					// アクティブレポートコントロール名称
			this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_COMMAEDITEXISTCD]	  = 0;								// カンマ編集有無区分
			this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_PRINTPAGECTRLDIVCD]  = 0;								// 印字ページ制御区分
			this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_INITKITFREEPPRITEMCD]= 0;								// 初期値用自由帳票項目コード

		}

		/// <summary>
		/// コンバートマスタグリッド展開処理
		/// </summary>
		/// <param name="outputFormFileName">出力ファイル名称</param>
		/// <param name="outputFileClassId">出力ファイルクラスID</param>
		/// <remarks>
		/// <br>Note		: 出力ファイル名からアセンブリを解析し、グリッドに展開します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.22</br>
		/// </remarks>
		private void CreateGridSchmConv(string outputFormFileName, string outputFileClassId)
		{
			// ファイルパス作成処理
			string filePath = this.CreateFilePath(outputFormFileName);

			if(!string.IsNullOrEmpty(filePath))
			{
				try
				{
					Assembly targetAsm = null;
					try
					{
						// アセンブリ取得用パスよりアセンブリをロード
						targetAsm = Assembly.LoadFrom(filePath);
					}
					catch (FileNotFoundException ex)
					{
						ShowMessageDialog("アセンブリのロードに失敗しました。\r\n\r\n", ex, -1);
						return;
					}

					if (targetAsm != null)
					{
						// アクティブレポート展開処理
						ExtendActiveReport(targetAsm, outputFileClassId);
					}
					if (this.ultraGrid_Conv.Rows.Count != 0)
					{
						this.SchmConv_tToolbarsManager.Tools["Delete_Button"].SharedProps.Enabled = true;
					}
				}
				catch (Exception ex)
				{
					ShowMessageDialog(ex.Message, null, -1);
				}
			}

		}

		/// <summary>
		/// OpenFileDialog展開処理
		/// </summary>
		/// <param name="selectFlag">判断用フラグ(1:スキーマグループ,2:スキーマコンバート)</param>
		/// <remarks>
		/// <br>Note		: OpenFileDialogからXMLを選択し、グリッドに展開します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.22</br>
		/// </remarks>
		private void OpenFileDialogGridSet(int selectFlag)
		{
			string prtItemSetFilePath = string.Empty;
			openFileDialogSchmGr.InitialDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath);

			if (selectFlag == schm_index)
			{
				openFileDialogSchmGr.Title = "自由帳票スキーマグループXMLファイルを選択して下さい。";
				this.openFileDialogSchmGr.Filter = "自由帳票スキーマグループXMLファイル|FPprSchmGrRF_*.xml";
			}
			else
			{
				openFileDialogSchmGr.Title = "自由帳票スキーマコンバートXMLファイルを選択して下さい。";
				this.openFileDialogSchmGr.Filter = "自由帳票スキーマコンバートXMLファイル|FPprSchmCvRF_*.xml";
			}

			if (openFileDialogSchmGr.ShowDialog() == DialogResult.OK)
			{
				prtItemSetFilePath = openFileDialogSchmGr.FileName;
			}

			if (prtItemSetFilePath != String.Empty)
			{
				if (selectFlag == schm_index)
				{
					this._dataSetSchm.Tables[TBL_FPprSchmGr].ReadXml(prtItemSetFilePath);
					if (this.ultraGrid_Schm.Rows.Count > 0)
					{
						foreach (DataRow dr in _dataSetSchm.Tables[TBL_FPprSchmGr].Rows)
						{
							if (dr[COL_TOPMARGIN] == DBNull.Value)
								dr[COL_TOPMARGIN] = 0;
							if (dr[COL_LEFTMARGIN] == DBNull.Value)
								dr[COL_LEFTMARGIN] = 0;
							if (dr[COL_RIGHTMARGIN] == DBNull.Value)
								dr[COL_RIGHTMARGIN] = 0;
							if (dr[COL_BOTTOMMARGIN] == DBNull.Value)
								dr[COL_BOTTOMMARGIN] = 0;
						}
					}

					// グループタブの「開く」を押し、ファイルが確定したタイミングでXMLがローカルに落ちていたら、一緒に展開する。
					// もしスキーマグループコードを持つファイルがローカルに落ちているならば展開をかける
					// 拡張子無しのファイルの取得
					string fileName = Path.GetFileName(prtItemSetFilePath);
					string filePath = Path.Combine(Path.GetDirectoryName(prtItemSetFilePath), fileName.Replace(TBL_FPprSchmGr, TBL_FPprSchmCv));

					if(File.Exists(filePath))
						// コンバートマスタの展開
						this._dataSetConv.Tables[TBL_FPprSchmCv].ReadXml(filePath);

					if (this.ultraGrid_Conv.Rows.Count > 0)
					{
						foreach (DataRow dr in _dataSetConv.Tables[TBL_FPprSchmCv].Rows)
						{
							if (dr[COL_INITKITFREEPPRITEMCD] == DBNull.Value)
							{
								dr[COL_INITKITFREEPPRITEMCD] = 0;
							}
						}
					}
				}
				else if (selectFlag == conv_index)
				{
					this._dataSetConv.Tables[TBL_FPprSchmCv].ReadXml(prtItemSetFilePath);
				}
			}
		}

		/// <summary>
		/// 削除処理
		/// </summary>
		/// <param name="selectFlag">判断用フラグ(1:スキーマグループ,2:スキーマコンバート)</param>
		/// <remarks>
		/// <br>Note	   : 削除ボタンが押された時の処理です。</br>
		/// <br>Programer  : 30015  橋本　裕毅</br>
		/// <br>Date	   : 2007.06.22</br>
		/// </remarks>
		private void DeleteProc(int selectFlag)
		{
			int selIndex = 0;
			int index = 0;
			if (selectFlag == schm_index)
			{
				// 行が選択されていない場合は何もせず終了
				if (this.ultraGrid_Schm.ActiveRow == null)
				{
					return;
				}

				index = this.ultraGrid_Schm.ActiveRow.Index;

				// 行を削除
				this.DeleteUIRow(index, selectFlag);

				// まだ行が存在している
				if (this.ultraGrid_Schm.Rows.Count >= 0)
				{
					// 範囲内の時
					if (index < this.ultraGrid_Schm.Rows.Count)
					{
						// 削除した行と同じインデックスの行を選択
						selIndex = index;
					}
					else
					{
						selIndex = this.ultraGrid_Schm.Rows.Count - 1;
					}

					// 行が存在する場合
					if (this.ultraGrid_Schm.Rows.Count > 0)
					{
						this.SetActiveCell(selIndex, COL_FREEPRTPPRSCHMGRPCD, schm_index);
					}
					else
					{
						this.SchmGroup_tToolbarsManager.Tools["Extend_Button"].SharedProps.Enabled = false; 
						this.SchmGroup_tToolbarsManager.Tools["Delete_Button"].SharedProps.Enabled	= false;
						this.ultraTabPageControl2.Enabled = false;

						_dataSetConv.Clear();
						_dataSetItem.Clear();

						this.ultraTabControl1.Focus();
					}
				}
			}
			else
			{
				// 行が選択されていない場合は何もせず終了
				if (this.ultraGrid_Conv.ActiveRow == null)
				{
					return;
				}

				index = this.ultraGrid_Conv.ActiveRow.Index;

				// 行を削除
				this.DeleteUIRow(index, selectFlag);

				// まだ行が存在している
				if (this.ultraGrid_Conv.Rows.Count >= 0)
				{
					// 範囲内の時
					if (index < this.ultraGrid_Conv.Rows.Count)
					{
						// 削除した行と同じインデックスの行を選択
						selIndex = index;
					}
					else
					{
						selIndex = this.ultraGrid_Conv.Rows.Count - 1;
					}

					// 行が存在する場合
					if (this.ultraGrid_Conv.Rows.Count > 0)
					{
						this.SetActiveCell(selIndex, COL_FREEPRTPPRSCHEMACD, conv_index);
					}
					else
					{
						this.ultraTabControl1.Focus();
						this.SchmConv_tToolbarsManager.Tools["Delete_Button"].SharedProps.Enabled	= false;
					}
				}
			}

		}

		/// <summary>
		/// 削除詳細処理
		/// </summary>
		/// <param name="index">行選択用index</param>
		/// <param name="selectFlag">判断用フラグ(1:スキーマグループ,2:スキーマコンバート)</param>
		/// <remarks>
		/// <br>Note	   : 削除した時の処理です。</br>
		/// <br>Programer  : 30015  橋本　裕毅</br>
		/// <br>Date	   : 2007.06.22</br>
		/// </remarks>
		private void DeleteUIRow(int index, int selectFlag)
		{
			DataTable uiDt = null;
			DataRow delRow = null;
			if (selectFlag == schm_index)
			{
				uiDt = this._dataSetSchm.Tables[TBL_FPprSchmGr];
				int fPPSGpCd = 0; // 自由帳票スキーマグループコード
				if ((index < 0) || (index >= uiDt.Rows.Count))
				{
					// 範囲外のインデックスが指定された時は何もせず終了
					return;
				}
				delRow = uiDt.Rows[index];
				fPPSGpCd = (int)delRow[COL_FREEPRTPPRSCHMGRPCD];
				// 行を削除
				delRow.Delete();

				// グループに紐付く明細も削除
				uiDt = this._dataSetConv.Tables[TBL_FPprSchmCv];
				for (int i = 0; i < uiDt.Rows.Count; i++)
				{
					if ((int)uiDt.Rows[i][COL_FREEPRTPPRSCHMGRPCD] == fPPSGpCd)
					{
						// スキーマグループコードが等しいものだけ削除
						uiDt.Rows[i].Delete();
						i--;
					}
				}
			}
			else
			{
				uiDt = this._dataSetConv.Tables[TBL_FPprSchmCv];
				if ((index < 0) ||
					(index >= uiDt.Rows.Count))
				{
					// 範囲外のインデックスが指定された時は何もせず終了
					return;
				}
				delRow = uiDt.Rows[index];
				// 行を削除
				delRow.Delete();
			}
		}

		/// <summary>
		/// アクティブセル位置設定処理
		/// </summary>
		/// <param name="rowIndex">行インデックス</param>
		/// <param name="columnName">列名称</param>
		/// <param name="selectFlag">判断用フラグ(1:スキーマグループ,2:スキーマコンバート)</param>
		/// <remarks>
		/// <br>Note	   : 指定したセルにアクティブセルを設定します。</br>
		/// <br>Programer  : 30015  橋本　裕毅</br>
		/// <br>Date	   : 2007.06.22</br>
		/// </remarks>
		private void SetActiveCell(int rowIndex, string columnName, int selectFlag)
		{
			this.ultraGrid_Schm.BeginInvoke( new GridMethodInvoker(this.SetActiveCellProc), rowIndex, columnName, selectFlag);
		}

		/// <summary>
		/// アクティブセル位置設定処理
		/// </summary>
		/// <param name="rowIndex">行インデックス</param>
		/// <param name="columnName">列名称</param>
		/// <param name="selectFlag">判断用フラグ(1:スキーマグループ,2:スキーマコンバート)</param>
		/// <remarks>
		/// <br>Note	   : 指定したセルにアクティブセルを設定します。</br>
		/// <br>Programer  : 30015  橋本　裕毅</br>
		/// <br>Date	   : 2007.06.22</br>
		/// </remarks>
		private void SetActiveCellProc(int rowIndex, string columnName, int selectFlag)
		{
			if (selectFlag == schm_index)
			{
				if (this.ultraGrid_Schm.Rows.Count == 0)
				{
					return;
				}

				// アクティブセルを設定
				this.ultraGrid_Schm.ActiveCell = this.ultraGrid_Schm.Rows[rowIndex].Cells[columnName];

				// グリッド状態取得
				if ((this.ultraGrid_Schm.CurrentState & Infragistics.Win.UltraWinGrid.UltraGridState.InEdit) != Infragistics.Win.UltraWinGrid.UltraGridState.InEdit)
				{
					this.ultraGrid_Schm.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
				}
			}
			else
			{
				if (this.ultraGrid_Conv.Rows.Count == 0)
				{
					return;
				}

				// アクティブセルを設定
				this.ultraGrid_Conv.ActiveCell = this.ultraGrid_Conv.Rows[rowIndex].Cells[columnName];

				// グリッド状態取得
				if ((this.ultraGrid_Conv.CurrentState & Infragistics.Win.UltraWinGrid.UltraGridState.InEdit) != Infragistics.Win.UltraWinGrid.UltraGridState.InEdit)
				{
					this.ultraGrid_Conv.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
				}

			}
			// テキスト全選択
			CellTextSelectAll(selectFlag);
		}

		/// <summary>
		/// セルテキスト全選択処理
		/// </summary>
		/// <param name="selectFlag">判断用フラグ(1:スキーマグループ,2:スキーマコンバート)</param>
		/// <remarks>
		/// <br>Note	   : セルの編集中のテキストを全選択します</br>
		/// <br>Programer  : 30015  橋本　裕毅</br>
		/// <br>Date	   : 2007.06.22</br>
		/// </remarks>
		private void CellTextSelectAll(int selectFlag)
		{
			if (selectFlag == schm_index)
			{
				// アクティブセルがnull
				if (this.ultraGrid_Schm.ActiveCell == null)
				{
					return;
				}

				// 編集モードでない時は終了
				if ((this.ultraGrid_Schm.CurrentState & Infragistics.Win.UltraWinGrid.UltraGridState.InEdit) !=
				    Infragistics.Win.UltraWinGrid.UltraGridState.InEdit)
				{
					return;
				}

				// 全選択
				this.ultraGrid_Schm.ActiveCell.SelStart = 0;
				this.ultraGrid_Schm.ActiveCell.SelLength = this.ultraGrid_Schm.ActiveCell.Column.Editor.TextLength;
			}
			else
			{
				// アクティブセルがnull
				if (this.ultraGrid_Conv.ActiveCell == null)
				{
					return;
				}

				// 編集モードでない時は終了
				if ((this.ultraGrid_Conv.CurrentState & Infragistics.Win.UltraWinGrid.UltraGridState.InEdit) !=
				    Infragistics.Win.UltraWinGrid.UltraGridState.InEdit)
				{
				    return;
				}

				// 全選択
				this.ultraGrid_Conv.ActiveCell.SelStart = 0;
				this.ultraGrid_Conv.ActiveCell.SelLength = this.ultraGrid_Conv.ActiveCell.Column.Editor.TextLength;
			}
		}


		/// <summary>
		/// 新規作成処理
		/// </summary>
		/// <param name="selectFlag">判断用フラグ(1:スキーマグループ,2:スキーマコンバート)</param>
		/// <remarks>
		/// <br>Note	   : 新規ボタンが押された時の処理です。</br>
		/// <br>Programer  : 30015  橋本　裕毅</br>
		/// <br>Date	   : 2007.06.22</br>
		/// </remarks>
		private void NewProc(int selectFlag)
		{
			int index = 0;
			
			if (selectFlag == schm_index)
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this._dataSetSchm.Tables[TBL_FPprSchmGr].NewRow();
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows.Count - 1;
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_CREATEDATETIME]		= DateTime.Now.Ticks;				// 作成日付
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_UPDATETIME]			= this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_CREATEDATETIME];				// 更新日付
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_LOGICALDELETECODE]		= 0;								// 論理削除区分
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_FREEPRTPPRSCHMGRPCD]   = this.ultraGrid_Schm.Rows.Count;	// 自由帳票スキーマグループコード
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_OUTPUTFORMFILENAME]	= String.Empty;						// 出力ファイルID
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_OUTPUTFILECLASSID]		= "Broadleaf.Drawing.Printing.";	// 出力ファイルクラスID
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_DATAINPUTSYSTEM]		= 0;								// データ入力システム
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_PRINTPAPERDIVCD]		= 1;								// 帳票区分コード
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_PRINTPAPPERUSEDIVCD]	= 1;								// 帳票使用区分
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_SPECIALCONVTUSEDIVCD]	= 0;								// 特殊コンバート使用区分
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_FORMFEEDLINECOUNT]		= 0;								// 改頁行数
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_CRCHARCNT]				= 0;								// 改行文字数
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_TOPMARGIN]				= 0;								// 上余白
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_LEFTMARGIN]			= 0;								// 左余白
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_RIGHTMARGIN]			= 0;								// 右余白
				this._dataSetSchm.Tables[TBL_FPprSchmGr].Rows[index][COL_BOTTOMMARGIN]			= 0;								// 下余白

				this.SchmGroup_tToolbarsManager.Tools["Extend_Button"].SharedProps.Enabled	= true; // 自由帳票スキーマグループ展開ボタン
				this.SchmGroup_tToolbarsManager.Tools["Delete_Button"].SharedProps.Enabled	= true; // 自由帳票スキーマグループ削除ボタン
			}
			else
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this._dataSetConv.Tables[TBL_FPprSchmCv].NewRow();
				this._dataSetConv.Tables[TBL_FPprSchmCv].Rows.Add(dataRow);
				// indexを行の最終行番号する
				index = this._dataSetConv.Tables[TBL_FPprSchmCv].Rows.Count - 1;

				AddDataForConv();

				this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_CREATEDATETIME]		= _createDateTime;					// 作成日付
				this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_UPDATETIME]			= _updateTime;						// 更新日付
				this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_LOGICALDELETECODE]		= 0;								// 論理削除区分
				this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_FREEPRTPPRSCHMGRPCD]	= _freePrtPprSchmGrpCd;				// 自由帳票スキーマグループコードコード
				this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_FREEPRTPPRSCHEMACD]	= this.GetMaxFreePrtPprSchemaCd(_freePrtPprSchmGrpCd) + 1;	// 自由帳票スキーマコードコード
				this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_FREEPRTPAPERITEMCD]	= 0;								// 自由帳票項目コード
				this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_ACTIVEREPORTCLASSID]	= string.Empty;						// アクティブレポートクラスID
				this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_COMMAEDITEXISTCD]		= 0;								// カンマ編集有無
				this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_PRINTPAGECTRLDIVCD]	= 0;								// 印字ページ制御区分
				this._dataSetConv.Tables[TBL_FPprSchmCv].Rows[index][COL_INITKITFREEPPRITEMCD]	= 0;								// 初期値用自由帳票項目コード

				this.SchmConv_tToolbarsManager.Tools["Delete_Button"].SharedProps.Enabled	= true; // 自由帳票スキーマコンバート削除ボタン

			}
		}

		/// <summary>
		/// ガイドオープン処理
		/// </summary>
		/// <param name="_freePrtPprItemGrpCd">自由帳票印字項目グループコード</param>
		/// <remarks>
		/// <br>Note		: 印字項目設定にて処理です。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.22</br>
		/// </remarks>
		private void OpenGuideProc(int _freePrtPprItemGrpCd)
		{
			string targetFilePath = String.Empty;

			openFileDialogSchmGr.Title = "印字項目設定XMLファイルを選択して下さい。";
			openFileDialogSchmGr.InitialDirectory = System.Windows.Forms.Application.StartupPath + SFANL08246CA.ctXMLSavePath;

			this.openFileDialogSchmGr.Filter = "印字項目設定XMLファイル|PrtItemSetRF_*.xml"; 

			if (openFileDialogSchmGr.ShowDialog() == DialogResult.OK)
			{
				if (this.ultraGrid_Item.Rows.Count > 0)
				{
					_dataSetItem.Clear();
				}
				
				targetFilePath = openFileDialogSchmGr.FileName;
			}

			if (targetFilePath != String.Empty)
			{
				this._dataSetItem.Tables[TBL_PrtItemSet].ReadXml(targetFilePath);
			}
		}

		/// <summary>
		/// 日付コピー処理
		/// </summary>
		/// <param name="allFlag">true:全件、false:選択行</param>
		/// <remarks>
		/// <br>Note		: スキーマグループ側の作成日付、更新日付をスキーマコンバート側にコピーします。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private void CopyDate(bool allFlag)
		{
			string filter = string.Empty;
			if ((this.ultraGrid_Schm.Rows.Count > 0) && (this.ultraGrid_Conv.Rows.Count > 0))
			{
				// 全件
				if (allFlag)
				{
					foreach (UltraGridRow ugrSchm in this.ultraGrid_Schm.Rows)
					{
						filter = COL_FREEPRTPPRSCHMGRPCD + "=" + ugrSchm.Cells[COL_FREEPRTPPRSCHMGRPCD].Value;
						this.CopyProcDtl(filter, true, ugrSchm, 0, 0);
					}
				}
				// 選択行
				else
				{
					// スキーマグループコードの等しいものだけ、明細側を削除
					filter = COL_FREEPRTPPRSCHMGRPCD + "=" + this.ultraGrid_Schm.ActiveRow.Cells[COL_FREEPRTPPRSCHMGRPCD].Value;
					long create = (long)this.ultraGrid_Schm.ActiveRow.Cells[COL_CREATEDATETIME].Value;
					long update = (long)this.ultraGrid_Schm.ActiveRow.Cells[COL_UPDATETIME].Value;
					this.CopyProcDtl(filter, false, null, create, update);
				}
			}
			ShowMessageDialog("コピーしました。", null, 0);
		}

		/// <summary>
		/// 日付コピー処理詳細
		/// </summary>
		/// <param name="filter">絞込み条件</param>
		/// <param name="allFlag">true:全件、false:選択行</param>
		/// <param name="ugrSchm">対象となるUltraGridRow（全件の場合）</param>
		/// <param name="create">作成日付（選択行の場合）</param>
		/// <param name="update">更新日付（選択行の場合）</param>
		/// <remarks>
		/// <br>Note		: スキーマグループ側の作成日付、更新日付をスキーマコンバート側にコピーします。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private void CopyProcDtl(string filter, bool allFlag, UltraGridRow ugrSchm, long create, long update)
		{
			DataRow[] filterDrArray = _dataSetConv.Tables[TBL_FPprSchmCv].Select(filter);
			foreach (DataRow drConv in filterDrArray)
			{
				if (allFlag)
				{
					drConv[COL_CREATEDATETIME] = ugrSchm.Cells[COL_CREATEDATETIME].Value;
					drConv[COL_UPDATETIME] = ugrSchm.Cells[COL_UPDATETIME].Value;
				}
				else
				{
					drConv[COL_CREATEDATETIME] = create;
					drConv[COL_UPDATETIME] = update;
				}
			}
		}
		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="message">エラーメッセージ</param>
		/// <br>Note		: 入力チェックします。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.07.05</br>
		/// <remarks></remarks>
		private bool CheckInputData(out string message)
		{
		    message = String.Empty; // メッセージ
			string targetColumnName = String.Empty; // エラーが出たカラム名称

			// スキーマグループ
			foreach (UltraGridRow grpRow in this.ultraGrid_Schm.Rows)
			{
				string filter = COL_FREEPRTPPRSCHMGRPCD + "=" + grpRow.Cells[COL_FREEPRTPPRSCHMGRPCD].Value;
				DataRow[] filterDrArray = _dataSetSchm.Tables[TBL_FPprSchmGr].Select(filter);
				if (filterDrArray.Length > 1)
				{
					message = "";
					this.ultraGrid_Schm.Focus();
					this.ultraGrid_Schm.Rows[grpRow.Index].Activate();
					return false;
				}

				// スキーマコンバート
				foreach (UltraGridRow convRow in this.ultraGrid_Conv.Rows)
				{
					filter = COL_FREEPRTPPRSCHMGRPCD + "=" + grpRow.Cells[COL_FREEPRTPPRSCHMGRPCD].Value
						+ " AND " + COL_FREEPRTPPRSCHEMACD + " = " + convRow.Cells[COL_FREEPRTPPRSCHEMACD].Value
						+ " AND " + COL_FREEPRTPAPERITEMCD + " = " + convRow.Cells[COL_FREEPRTPAPERITEMCD].Value;
					filterDrArray = _dataSetConv.Tables[TBL_FPprSchmCv].Select(filter);
					if (filterDrArray.Length > 1)
					{
						message = "";
						this.ultraGrid_Conv.Focus();
						this.ultraGrid_Conv.Rows[convRow.Index].Activate();
						return false;
					}
				}
			}
			
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// <br>Note		: コンバートグリッドにて必要なデータです。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void AddDataForConv()
		{
			// 登録するスキーマグループに対してスキーマコンバートのデータを作成する。
			_createDateTime			= (Int64)this.ultraGrid_Schm.Rows[this.ultraGrid_Schm.ActiveRow.Index].Cells[COL_CREATEDATETIME].Value;			// 作成日付
			_updateTime				= (Int64)this.ultraGrid_Schm.Rows[this.ultraGrid_Schm.ActiveRow.Index].Cells[COL_UPDATETIME].Value;				// 更新日付
			_freePrtPprSchmGrpCd	= (int)this.ultraGrid_Schm.Rows[this.ultraGrid_Schm.ActiveRow.Index].Cells[COL_FREEPRTPPRSCHMGRPCD].Value;		// 自由帳票スキーマグループコード
			_outputFormFileName		= this.ultraGrid_Schm.Rows[this.ultraGrid_Schm.ActiveRow.Index].Cells[COL_OUTPUTFORMFILENAME].Value.ToString(); // 出力ファイル名称
			_outputFileClassId		= this.ultraGrid_Schm.Rows[this.ultraGrid_Schm.ActiveRow.Index].Cells[COL_OUTPUTFILECLASSID].Value.ToString();	// 出力ファイルクラスID
			_freePrtPprItemGrpCd	= (int)this.ultraGrid_Schm.Rows[this.ultraGrid_Schm.ActiveRow.Index].Cells[COL_FREEPRTPPRITEMGRPCD].Value;		// 自由帳票印字項目グループコード
		}
		/// <summary>
		/// 自由スキーマコード最大値取得処理
		/// </summary>
        /// <param name="freePrtPprSchmGrpCd">自由帳票スキーマグループコード</param>
		/// <returns>自由帳票スキーマコード</returns>
		private int GetMaxFreePrtPprSchemaCd(int freePrtPprSchmGrpCd)
		{
			int freePrtPprSchemaCd = 0;

			string filter = COL_FREEPRTPPRSCHMGRPCD + "=" + freePrtPprSchmGrpCd;
			string sort = COL_FREEPRTPPRSCHEMACD + " DESC";
			DataRow[] drArray = _dataSetConv.Tables[TBL_FPprSchmCv].Select(filter, sort);
			if (drArray != null && drArray.Length > 0)
				freePrtPprSchemaCd = Math.Max(freePrtPprSchemaCd, (int)drArray[0][COL_FREEPRTPPRSCHEMACD]);

			return freePrtPprSchemaCd;
		}

		#region ■Grid外観系
		/// <summary>
		/// UIグリッド初期設定処理
		/// </summary>
		/// <param name="grid_index">対象となるUltraGrid</param>
		/// <param name="ultraGridLayout">グリッドレイアウト</param>
		/// <remarks>
		/// <br>Note		: UIグリッドの初期設定を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void UIGridConstruction(Infragistics.Win.UltraWinGrid.UltraGridLayout ultraGridLayout, int grid_index)
		{
			// 印字項目設定グリッド
			if (grid_index == item_index)
			{
				// セルをクリックした時の動作
				ultraGridLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
				ultraGridLayout.Override.AllowRowFiltering	= Infragistics.Win.DefaultableBoolean.True;					// 行フィルター
			}
			else
			{
				// セルをクリックした時の動作
				ultraGridLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
				ultraGridLayout.Override.AllowRowFiltering	= Infragistics.Win.DefaultableBoolean.False;					// 行フィルター
			}

			// 列幅をオートに設定
			ultraGridLayout.AutoFitStyle			 = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

			// GroupByBoxを非表示にする
			ultraGridLayout.GroupByBox.Hidden			 = true;

			// ヘッダの設定
			ultraGridLayout.Override.HeaderClickAction		= Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
			ultraGridLayout.Override.HeaderStyle		    = Infragistics.Win.HeaderStyle.Standard;

			// 許可・不可設定
			ultraGridLayout.Override.AllowColMoving		= Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;		// 列の移動不可
			ultraGridLayout.Override.AllowColSizing		= Infragistics.Win.UltraWinGrid.AllowColSizing.Free;			// 列サイズの変更不可
			ultraGridLayout.Override.AllowColSwapping	= Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;	// 列の交換不可
			ultraGridLayout.Override.RowSizing			= Infragistics.Win.UltraWinGrid.RowSizing.Fixed;				// 行サイズ変更

			ultraGridLayout.Override.CardAreaAppearance.BackColor = System.Drawing.Color.Transparent;

			// 複数行選択設定
			ultraGridLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
			ultraGridLayout.Override.SelectTypeRow  = Infragistics.Win.UltraWinGrid.SelectType.None;
			ultraGridLayout.Override.SelectTypeCol  = Infragistics.Win.UltraWinGrid.SelectType.None;

			// グリッド全体の外観設定
			ultraGridLayout.Appearance.BackColor			= System.Drawing.Color.White;
			ultraGridLayout.Appearance.BackColor2			= System.Drawing.Color.FromArgb( 198, 219, 255 );
			ultraGridLayout.Appearance.BackGradientStyle	= Infragistics.Win.GradientStyle.Vertical;
			ultraGridLayout.Appearance.ForeColorDisabled	= System.Drawing.Color.Black;

			// 行の外観設定
			ultraGridLayout.Override.RowAppearance.BackColor					= System.Drawing.Color.White;
			ultraGridLayout.Override.RowAppearance.BackColorDisabled			= System.Drawing.SystemColors.Control;
			// 1行おきの外観設定
			ultraGridLayout.Override.RowAlternateAppearance.BackColor		    = System.Drawing.Color.Lavender;
			ultraGridLayout.Override.RowAlternateAppearance.BackColorDisabled   = System.Drawing.SystemColors.Control;

			// アクティブセルの外観設定
			ultraGridLayout.Override.ActiveCellAppearance.BackColor				= System.Drawing.Color.White;
			ultraGridLayout.Override.ActiveCellAppearance.BackColor2			= System.Drawing.Color.FromArgb( 251, 230, 148 );
			ultraGridLayout.Override.ActiveCellAppearance.BackGradientStyle		= Infragistics.Win.GradientStyle.Vertical;
			ultraGridLayout.Override.ActiveCellAppearance.ForeColor				= System.Drawing.Color.Black;
			// 編集中のセルの外観設定
			ultraGridLayout.Override.EditCellAppearance.BackColor				= System.Drawing.Color.FromArgb( 247, 227, 156 );

			// 選択行の外観設定
			ultraGridLayout.Override.SelectedRowAppearance.BackColor			= System.Drawing.Color.FromArgb( 251, 230, 148 );
			ultraGridLayout.Override.SelectedRowAppearance.BackColor2			= System.Drawing.Color.FromArgb( 238, 149, 21 );
			ultraGridLayout.Override.SelectedRowAppearance.BackGradientStyle	= Infragistics.Win.GradientStyle.Vertical;
			ultraGridLayout.Override.SelectedRowAppearance.ForeColor			= System.Drawing.Color.Black;
			// 選択行の外観設定
			ultraGridLayout.Override.SelectedRowAppearance.BackColor			= System.Drawing.Color.FromArgb( 251, 230, 148 );
			ultraGridLayout.Override.SelectedRowAppearance.BackColor2			= System.Drawing.Color.FromArgb( 238, 149, 21 );
			ultraGridLayout.Override.SelectedRowAppearance.BackGradientStyle	= Infragistics.Win.GradientStyle.Vertical;
			ultraGridLayout.Override.SelectedRowAppearance.ForeColor			= System.Drawing.Color.Black;
			ultraGridLayout.Override.SelectedRowAppearance.BackColorDisabled	= System.Drawing.Color.FromArgb( 251, 230, 148 );
			ultraGridLayout.Override.SelectedRowAppearance.BackColorDisabled2   = System.Drawing.Color.FromArgb( 238, 149, 21 );
			// アクティブ行の外観設定
			ultraGridLayout.Override.ActiveRowAppearance.BackColor				= System.Drawing.Color.FromArgb( 251, 230, 148 );
			ultraGridLayout.Override.ActiveRowAppearance.BackColor2				= System.Drawing.Color.FromArgb( 238, 149, 21 );
			ultraGridLayout.Override.ActiveRowAppearance.BackGradientStyle		= Infragistics.Win.GradientStyle.Vertical;
			ultraGridLayout.Override.ActiveRowAppearance.ForeColor				= System.Drawing.Color.Black;
			ultraGridLayout.Override.ActiveRowAppearance.BackColorDisabled		= System.Drawing.Color.FromArgb( 251, 230, 148 );
			ultraGridLayout.Override.ActiveRowAppearance.BackColorDisabled2		= System.Drawing.Color.FromArgb( 238, 149, 21 );
			
			// ヘッダーの外観設定
			ultraGridLayout.Override.HeaderAppearance.BackColor					= System.Drawing.Color.FromArgb( 89, 135, 214 );
			ultraGridLayout.Override.HeaderAppearance.BackColor2				= System.Drawing.Color.FromArgb( 7, 59, 150 );
			ultraGridLayout.Override.HeaderAppearance.BackGradientStyle			= Infragistics.Win.GradientStyle.Vertical;
			ultraGridLayout.Override.HeaderAppearance.ForeColor					= System.Drawing.Color.White;
			ultraGridLayout.Override.HeaderAppearance.ForeColorDisabled			= System.Drawing.Color.White;
			ultraGridLayout.Override.HeaderAppearance.TextHAlign				= Infragistics.Win.HAlign.Left;
			ultraGridLayout.Override.HeaderAppearance.ThemedElementAlpha		= Infragistics.Win.Alpha.Transparent;

			// 行セレクターの外観設定
			ultraGridLayout.Override.RowSelectors								= Infragistics.Win.DefaultableBoolean.True;
			ultraGridLayout.Override.RowSelectorAppearance.BackColor			= System.Drawing.Color.FromArgb( 89, 135, 214 );
			ultraGridLayout.Override.RowSelectorAppearance.BackColor2			= System.Drawing.Color.FromArgb( 7, 59, 150 );
			ultraGridLayout.Override.RowSelectorAppearance.BackGradientStyle	= Infragistics.Win.GradientStyle.Vertical;
			ultraGridLayout.Override.RowSelectorAppearance.ForeColor			= System.Drawing.Color.White;
			ultraGridLayout.Override.RowSelectorAppearance.ForeColorDisabled	= System.Drawing.Color.White;

			// セル内テキストの縦位置設定
			ultraGridLayout.Override.ActiveCellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			ultraGridLayout.Override.CellAppearance.TextVAlign			= Infragistics.Win.VAlign.Middle;

			// 行間の罫線色の設定
			ultraGridLayout.BorderStyle								= Infragistics.Win.UIElementBorderStyle.Default;
			ultraGridLayout.Override.BorderStyleCell				= Infragistics.Win.UIElementBorderStyle.Solid;
			ultraGridLayout.Override.BorderStyleRow					= Infragistics.Win.UIElementBorderStyle.Solid;
			ultraGridLayout.Override.CellAppearance.BorderColor		= Color.FromArgb( 1, 68, 208 );
			ultraGridLayout.Override.RowAppearance.BorderColor		= Color.FromArgb( 1, 68, 208 );

			// IMEモードを無効にする
			this.ultraGrid_Schm.ImeMode = ImeMode.Disable;
			this.ultraGrid_Conv.ImeMode = ImeMode.Disable;
			this.ultraGrid_Item.ImeMode = ImeMode.Disable;
		}

		/// <summary>
		/// 表示グリッドのカラム情報を設定します。(スキーマグループ)
		/// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
		/// <remarks>
		/// <br>Note	   : グリッドに表示するカラム情報を設定します。(スキーマグループ)</br>
		/// <br>Programer  : 30015  橋本　裕毅</br>
		/// <br>Date	   : 2007.06.21</br>
		/// </remarks>
		private void SettingGridColumnSchm(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
		{
			//--------------------------------------------------------------------------------
			//  表示するカラム情報
			//--------------------------------------------------------------------------------
			// 作成日付
			columns[COL_CREATEDATETIME].Header.Caption						= "作成日付";
			columns[COL_CREATEDATETIME].CellAppearance.ForeColorDisabled	= Color.Black;
			columns[COL_CREATEDATETIME].CellAppearance.TextVAlign			= Infragistics.Win.VAlign.Middle;
			columns[COL_CREATEDATETIME].MaxLength							= 19;

			// 更新日付
			columns[COL_UPDATETIME].Header.Caption						= "更新日付";
			columns[COL_UPDATETIME].CellAppearance.TextVAlign			= Infragistics.Win.VAlign.Middle;
			columns[COL_UPDATETIME].MaxLength							= 19;

			// 論理削除コード
			columns[COL_LOGICALDELETECODE].Header.Caption				= "論理削除区分";
			columns[COL_LOGICALDELETECODE].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_LOGICALDELETECODE].MaxLength					= 2;

			// 自由帳票スキーマグループコード
			columns[COL_FREEPRTPPRSCHMGRPCD].Header.Caption				= "自由帳票スキーマグループコード";
			columns[COL_FREEPRTPPRSCHMGRPCD].CellAppearance.TextHAlign  = Infragistics.Win.HAlign.Right;
			columns[COL_FREEPRTPPRSCHMGRPCD].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_FREEPRTPPRSCHMGRPCD].MaxLength					= 4;

			// 出力ファイル名称
			columns[COL_OUTPUTFORMFILENAME].Header.Caption			    = "出力ファイル名称";
			columns[COL_OUTPUTFORMFILENAME].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
			columns[COL_OUTPUTFORMFILENAME].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_OUTPUTFORMFILENAME].Nullable					= Infragistics.Win.UltraWinGrid.Nullable.EmptyString;
			columns[COL_OUTPUTFORMFILENAME].MaxLength					= 30;

			// 出力ファイルクラスID
			columns[COL_OUTPUTFILECLASSID].Header.Caption				= "出力ファイルクラスID";
			columns[COL_OUTPUTFILECLASSID].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
			columns[COL_OUTPUTFILECLASSID].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_OUTPUTFILECLASSID].Nullable						= Infragistics.Win.UltraWinGrid.Nullable.EmptyString;
			columns[COL_OUTPUTFILECLASSID].MaxLength					= 80;

			// 自由帳票項目グループコード
			columns[COL_FREEPRTPPRITEMGRPCD].Header.Caption				= "自由帳票項目グループコード";
			columns[COL_FREEPRTPPRITEMGRPCD].CellAppearance.TextHAlign  = Infragistics.Win.HAlign.Right;
			columns[COL_FREEPRTPPRITEMGRPCD].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_FREEPRTPPRITEMGRPCD].Nullable					= Infragistics.Win.UltraWinGrid.Nullable.EmptyString;
			columns[COL_FREEPRTPPRITEMGRPCD].MaxLength					= 4;

			// 出力名称
			columns[COL_DISPLAYNAME].Header.Caption						= "出力名称";
			columns[COL_DISPLAYNAME].CellAppearance.TextHAlign			= Infragistics.Win.HAlign.Left;
			columns[COL_DISPLAYNAME].CellAppearance.TextVAlign			= Infragistics.Win.VAlign.Middle;
			columns[COL_DISPLAYNAME].MaxLength							= 15;

			// データ入力システム
			columns[COL_DATAINPUTSYSTEM].Header.Caption						= "データ入力システム";
			columns[COL_DATAINPUTSYSTEM].CellAppearance.TextHAlign			= Infragistics.Win.HAlign.Left;
			columns[COL_DATAINPUTSYSTEM].CellAppearance.TextVAlign			= Infragistics.Win.VAlign.Middle;
			columns[COL_DATAINPUTSYSTEM].Style								= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			ValueList valueListSystemDiv = new ValueList();
			valueListSystemDiv.ValueListItems.Add(0, "共通");
			valueListSystemDiv.ValueListItems.Add(1, "整備");
			valueListSystemDiv.ValueListItems.Add(2, "鈑金");
			valueListSystemDiv.ValueListItems.Add(3, "車販");
			columns[COL_DATAINPUTSYSTEM].ValueList = valueListSystemDiv;

			// 帳票区分コード
			columns[COL_PRINTPAPERDIVCD].Header.Caption					= "帳票区分コード";
			columns[COL_PRINTPAPERDIVCD].CellAppearance.TextHAlign		= Infragistics.Win.HAlign.Left;
			columns[COL_PRINTPAPERDIVCD].CellAppearance.TextVAlign		= Infragistics.Win.VAlign.Middle;
			columns[COL_PRINTPAPERDIVCD].Style							= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			ValueList valueListPrintPaperDiv = new ValueList();
			valueListPrintPaperDiv.ValueListItems.Add(0, "該当なし");
			valueListPrintPaperDiv.ValueListItems.Add(1, "日次帳票");
			valueListPrintPaperDiv.ValueListItems.Add(2, "月次帳票");
			valueListPrintPaperDiv.ValueListItems.Add(3, "年次帳票");
			valueListPrintPaperDiv.ValueListItems.Add(4, "随時帳票");
			columns[COL_PRINTPAPERDIVCD].ValueList = valueListPrintPaperDiv;

			// 帳票使用区分
			columns[COL_PRINTPAPPERUSEDIVCD].Header.Caption				= "帳票使用区分";
			columns[COL_PRINTPAPPERUSEDIVCD].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
			columns[COL_PRINTPAPPERUSEDIVCD].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_PRINTPAPPERUSEDIVCD].Style						= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			ValueList valueListPrintPapperUseDivCd = new ValueList();
			valueListPrintPapperUseDivCd.ValueListItems.Add(1, "帳票");
			valueListPrintPapperUseDivCd.ValueListItems.Add(2, "伝票");
			valueListPrintPapperUseDivCd.ValueListItems.Add(3, "DM一覧表");
			valueListPrintPapperUseDivCd.ValueListItems.Add(4, "DMはがき");
			columns[COL_PRINTPAPPERUSEDIVCD].ValueList = valueListPrintPapperUseDivCd;

			// 特殊コンバート区分
			columns[COL_SPECIALCONVTUSEDIVCD].Header.Caption						= "特殊コンバート区分";
			columns[COL_SPECIALCONVTUSEDIVCD].CellAppearance.TextHAlign			= Infragistics.Win.HAlign.Left;
			columns[COL_SPECIALCONVTUSEDIVCD].CellAppearance.TextVAlign			= Infragistics.Win.VAlign.Middle;
			columns[COL_SPECIALCONVTUSEDIVCD].Style								= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			ValueList valueListSpecialConvtUsedDivCd = new ValueList();
			valueListSpecialConvtUsedDivCd.ValueListItems.Add(0, "無");
			valueListSpecialConvtUsedDivCd.ValueListItems.Add(1, "特種マクロコンバート有");
			valueListSpecialConvtUsedDivCd.ValueListItems.Add(2, "フォントのみ");
			columns[COL_SPECIALCONVTUSEDIVCD].ValueList = valueListSpecialConvtUsedDivCd;

			// オプションコード
			columns[COL_OPTIONCODE].Header.Caption			    = "オプションコード";
			columns[COL_OPTIONCODE].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
			columns[COL_OPTIONCODE].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_OPTIONCODE].Nullable					= Infragistics.Win.UltraWinGrid.Nullable.EmptyString;
			columns[COL_OPTIONCODE].MaxLength					= 16;

			// 改頁行数
			columns[COL_FORMFEEDLINECOUNT].Header.Caption				= "改頁行数";
			columns[COL_FORMFEEDLINECOUNT].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Right;
			columns[COL_FORMFEEDLINECOUNT].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_FORMFEEDLINECOUNT].MaxLength					= 4;

			// 改行文字数
			columns[COL_CRCHARCNT].Header.Caption				= "改行文字数";
			columns[COL_CRCHARCNT].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Right;
			columns[COL_CRCHARCNT].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_CRCHARCNT].MaxLength					= 4;

			// 上余白
			columns[COL_TOPMARGIN].Header.Caption				= "上余白";
			columns[COL_TOPMARGIN].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Right;
			columns[COL_TOPMARGIN].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_CRCHARCNT].MaxLength					= 5;

			// 左余白
			columns[COL_LEFTMARGIN].Header.Caption				= "左余白";
			columns[COL_LEFTMARGIN].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Right;
			columns[COL_LEFTMARGIN].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_CRCHARCNT].MaxLength					= 5;

			// 右余白
			columns[COL_RIGHTMARGIN].Header.Caption				= "右余白";
			columns[COL_RIGHTMARGIN].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Right;
			columns[COL_RIGHTMARGIN].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_CRCHARCNT].MaxLength					= 5;

			// 下余白
			columns[COL_BOTTOMMARGIN].Header.Caption			= "下余白";
			columns[COL_BOTTOMMARGIN].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Right;
			columns[COL_BOTTOMMARGIN].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_CRCHARCNT].MaxLength					= 5;		
		}

		/// <summary>
		/// 表示グリッドのカラム情報を設定します。(スキーマコンバート)
		/// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
		/// <remarks>
		/// <br>Note	   : グリッドに表示するカラム情報を設定します。(スキーマコンバート)</br>
		/// <br>Programer  : 30015  橋本　裕毅</br>
		/// <br>Date	   : 2007.06.21</br>
		/// </remarks>
		private void SettingGridColumnConv(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
		{
			//--------------------------------------------------------------------------------
			//  表示するカラム情報
			//--------------------------------------------------------------------------------
			// 作成日付
			columns[COL_CREATEDATETIME].Header.Caption						= "作成日付";
			columns[COL_CREATEDATETIME].CellAppearance.ForeColorDisabled	= Color.Black;
			columns[COL_CREATEDATETIME].CellAppearance.TextVAlign			= Infragistics.Win.VAlign.Middle;
			columns[COL_CREATEDATETIME].MaxLength							= 19;

			// 更新日付
			columns[COL_UPDATETIME].Header.Caption						= "更新日付";
			columns[COL_UPDATETIME].CellAppearance.TextVAlign			= Infragistics.Win.VAlign.Middle;
			columns[COL_UPDATETIME].MaxLength							= 19;

			// 論理削除コード
			columns[COL_LOGICALDELETECODE].Header.Caption				= "論理削除区分";
			columns[COL_LOGICALDELETECODE].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_LOGICALDELETECODE].MaxLength					= 2;

			// 自由帳票スキーマグループコード
			columns[COL_FREEPRTPPRSCHMGRPCD].Header.Caption				= "自由帳票スキーマグループコード";
			columns[COL_FREEPRTPPRSCHMGRPCD].CellAppearance.TextHAlign  = Infragistics.Win.HAlign.Right;
			columns[COL_FREEPRTPPRSCHMGRPCD].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_FREEPRTPPRSCHMGRPCD].MaxLength					= 4;

			// 自由帳票スキーマコード
			columns[COL_FREEPRTPPRSCHEMACD].Header.Caption			    = "自由帳票スキーマコード";
			columns[COL_FREEPRTPPRSCHEMACD].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Right;
			columns[COL_FREEPRTPPRSCHEMACD].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_FREEPRTPPRSCHEMACD].MaxLength					= 4;

			// 自由帳票項目コード
			columns[COL_FREEPRTPAPERITEMCD].Header.Caption				= "自由帳票項目コード";
			columns[COL_FREEPRTPAPERITEMCD].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Right;
			columns[COL_FREEPRTPAPERITEMCD].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_FREEPRTPAPERITEMCD].MaxLength					= 4;

			// アクティブレポートクラスID
			columns[COL_ACTIVEREPORTCLASSID].Header.Caption				= "アクティブレポートクラスID";
			columns[COL_ACTIVEREPORTCLASSID].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
			columns[COL_ACTIVEREPORTCLASSID].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_ACTIVEREPORTCLASSID].MaxLength					= 30;

			// アクティブレポートコントロール名称
			columns[COL_ACTIVEREPORTCTRLNM].Header.Caption				= "アクティブレポートコントロール名称";
			columns[COL_ACTIVEREPORTCTRLNM].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
			columns[COL_ACTIVEREPORTCTRLNM].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_ACTIVEREPORTCTRLNM].MaxLength					= 30;

			// カンマ編集有無
			columns[COL_COMMAEDITEXISTCD].Header.Caption			  = "カンマ編集有無";
			columns[COL_COMMAEDITEXISTCD].CellAppearance.TextHAlign	  = Infragistics.Win.HAlign.Left;
			columns[COL_COMMAEDITEXISTCD].CellAppearance.TextVAlign	  = Infragistics.Win.VAlign.Middle;
			columns[COL_COMMAEDITEXISTCD].Style						  = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			ValueList valueListCommaEditExistCd = new ValueList();
			valueListCommaEditExistCd.ValueListItems.Add(0, "なし");
			valueListCommaEditExistCd.ValueListItems.Add(1, "#,###");
			valueListCommaEditExistCd.ValueListItems.Add(2, "#,##0");
			valueListCommaEditExistCd.ValueListItems.Add(3, "0.0");
			valueListCommaEditExistCd.ValueListItems.Add(4, "0.00");
			valueListCommaEditExistCd.ValueListItems.Add(5, "\\#,##0");
			valueListCommaEditExistCd.ValueListItems.Add(6, "\\#,##0-");
			columns[COL_COMMAEDITEXISTCD].ValueList = valueListCommaEditExistCd;

			// 印字ページ制御区分
			columns[COL_PRINTPAGECTRLDIVCD].Header.Caption			    = "印字ページ制御区分";
			columns[COL_PRINTPAGECTRLDIVCD].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
			columns[COL_PRINTPAGECTRLDIVCD].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_PRINTPAGECTRLDIVCD].Style						= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			ValueList valueListPrintPageCtrlDivCd = new ValueList();
			valueListPrintPageCtrlDivCd.ValueListItems.Add(0, "全ページ");
			valueListPrintPageCtrlDivCd.ValueListItems.Add(1, "1ページ目のみ");
			valueListPrintPageCtrlDivCd.ValueListItems.Add(2, "最終ページのみ");
			columns[COL_PRINTPAGECTRLDIVCD].ValueList = valueListPrintPageCtrlDivCd;

			// 出力ファイル名称
			columns[COL_OUTPUTFORMFILENAME].Header.Caption			    = "出力ファイル名称";
			columns[COL_OUTPUTFORMFILENAME].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
			columns[COL_OUTPUTFORMFILENAME].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_OUTPUTFORMFILENAME].Nullable					= Infragistics.Win.UltraWinGrid.Nullable.EmptyString;
			columns[COL_OUTPUTFORMFILENAME].MaxLength					= 30;

			// 出力ファイルクラスID
			columns[COL_OUTPUTFILECLASSID].Header.Caption				= "出力ファイルクラスID";
			columns[COL_OUTPUTFILECLASSID].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
			columns[COL_OUTPUTFILECLASSID].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_OUTPUTFILECLASSID].Nullable						= Infragistics.Win.UltraWinGrid.Nullable.EmptyString;
			columns[COL_OUTPUTFILECLASSID].MaxLength					= 80;

			// 自由帳票項目コード
			columns[COL_INITKITFREEPPRITEMCD].Header.Caption			= "初期値用自由帳票項目コード";
			columns[COL_INITKITFREEPPRITEMCD].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Right;
			columns[COL_INITKITFREEPPRITEMCD].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_INITKITFREEPPRITEMCD].MaxLength					= 4;

			columns[COL_FREEPRTPPRSCHMGRPCD].CellActivation				= Activation.NoEdit;
			columns[COL_FREEPRTPPRSCHMGRPCD].CellAppearance.BackColor	= SystemColors.Control;
		}

		/// <summary>
		/// 表示グリッドのカラム情報を設定します。(印字項目)
		/// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
		/// <remarks>
		/// <br>Note	   : グリッドに表示するカラム情報を設定します。(印字項目)</br>
		/// <br>Programer  : 30015  橋本　裕毅</br>
		/// <br>Date	   : 2007.06.21</br>
		/// </remarks>
		private void SettingGridColumnItem(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
		{
			//--------------------------------------------------------------------------------
			//  表示するカラム情報
			//--------------------------------------------------------------------------------
			// 自由帳票項目名称
			columns[COL_FREPRTPAPERITEMNM].Header.Caption				= "自由帳票項目名称";
			columns[COL_FREPRTPAPERITEMNM].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
			columns[COL_FREPRTPAPERITEMNM].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_FREPRTPAPERITEMNM].MaxLength					= 32;

			// ファイル名称
			columns[COL_FILENM].Header.Caption							= "ファイル名称";
			columns[COL_FILENM].CellAppearance.TextHAlign				= Infragistics.Win.HAlign.Left;
			columns[COL_FILENM].CellAppearance.TextVAlign				= Infragistics.Win.VAlign.Middle;
			columns[COL_FILENM].MaxLength								= 32;

			// DD名称
			columns[COL_DDNAME].Header.Caption							= "DD名称";
			columns[COL_DDNAME].CellAppearance.TextHAlign				= Infragistics.Win.HAlign.Left;
			columns[COL_DDNAME].CellAppearance.TextVAlign				= Infragistics.Win.VAlign.Middle;
			columns[COL_DDNAME].MaxLength								= 30;

			// 自由帳票項目コード
			columns[COL_FREEPRTPAPERITEMCD].Header.Caption				= "自由帳票項目コード";
			columns[COL_FREEPRTPAPERITEMCD].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Right;
			columns[COL_FREEPRTPAPERITEMCD].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_FREEPRTPAPERITEMCD].MaxLength					= 4;

			// カンマ編集有無
			columns[COL_COMMAEDITEXISTCD].Header.Caption			  = "カンマ編集有無";
			columns[COL_COMMAEDITEXISTCD].CellAppearance.TextHAlign	  = Infragistics.Win.HAlign.Left;
			columns[COL_COMMAEDITEXISTCD].CellAppearance.TextVAlign	  = Infragistics.Win.VAlign.Middle;
			columns[COL_COMMAEDITEXISTCD].Style						  = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			ValueList valueListCommaEditExistCd = new ValueList();
			valueListCommaEditExistCd.ValueListItems.Add(0, "なし");
			valueListCommaEditExistCd.ValueListItems.Add(1, "#,###");
			valueListCommaEditExistCd.ValueListItems.Add(2, "#,##0");
			valueListCommaEditExistCd.ValueListItems.Add(3, "0.0");
			valueListCommaEditExistCd.ValueListItems.Add(4, "0.00");
			valueListCommaEditExistCd.ValueListItems.Add(5, "\\#,##0");
			valueListCommaEditExistCd.ValueListItems.Add(6, "\\#,##0-");
			columns[COL_COMMAEDITEXISTCD].ValueList = valueListCommaEditExistCd;
			columns[COL_COMMAEDITEXISTCD].Hidden			  = true;

			// 印字ページ制御区分
			columns[COL_PRINTPAGECTRLDIVCD].Header.Caption			    = "印字ページ制御区分";
			columns[COL_PRINTPAGECTRLDIVCD].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
			columns[COL_PRINTPAGECTRLDIVCD].CellAppearance.TextVAlign	= Infragistics.Win.VAlign.Middle;
			columns[COL_PRINTPAGECTRLDIVCD].Style						= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			ValueList valueListPrintPageCtrlDivCd = new ValueList();
			valueListPrintPageCtrlDivCd.ValueListItems.Add(0, "全ページ");
			valueListPrintPageCtrlDivCd.ValueListItems.Add(1, "1ページ目のみ");
			valueListPrintPageCtrlDivCd.ValueListItems.Add(2, "最終ページのみ");
			columns[COL_PRINTPAGECTRLDIVCD].ValueList = valueListPrintPageCtrlDivCd;
			columns[COL_PRINTPAGECTRLDIVCD].Hidden			  = true;

		}
		#endregion

		#endregion

//****** Control Methods ********************************************************************************************
		#region Control Methods
		private void SFANL08245UA_Load(object sender, EventArgs e)
		{
			// 自由帳票スキーマグループ
			this.ultraGrid_Schm.DataSource = _dataSetSchm.Tables[TBL_FPprSchmGr];
			// 自由帳票スキーマコンバート
			this.ultraGrid_Conv.DataSource = _dataSetConv.Tables[TBL_FPprSchmCv];
			// 印字項目設定
			this.ultraGrid_Item.DataSource = _dataSetItem.Tables[TBL_PrtItemSet];
		}

		/// <summary>
		/// tToolbarsManager1_ToolClick(終了)イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ツールバーのボタンをクリックした時のイベントです。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				// 終了ボタン
				case "Cancel_Button":
					this.Close();
					break;
				// 保存ボタン
				case "Save_Button":
					{
						string errMsg;
						int status = SaveProc(out errMsg);
						switch (status)
						{
							case 0:
							{
								ShowMessageDialog("保存しました。", null, 0);
								break;
							}
							case 4:
							{
								ShowMessageDialog(errMsg, null, 4);
								break;
							}
							default:
							{
								ShowMessageDialog(errMsg, null, -1);
								break;
							}
						}
						break;
					}
			}
			
		}

		/// <summary>
		/// tToolbarsManager2_ToolClick(グループタブ側)イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ツールバーのボタンをクリックした時のイベントです。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void SchmGroup_tToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
		{
			if (ultraTabControl1.SelectedTab.Key == "0")
			{
				switch (e.Tool.Key)
				{
					case "Open_Button": // 開く
					{
						// Open処理
						this.OpenProc();
						break;
					}
					case "New_Button": // 行追加
					{
						// 新規作成処理
						//this.ultraTabPageControl2.Enabled = true;
						this.NewProc(schm_index);
						break;
					}
					case "Delete_Button": // 行削除
					{
						// 削除処理
						this.DeleteProc(schm_index);
						break;
					}
					case "Extend_Button": // 展開
					{
						// 同一グループ内明細は作成日付と更新日付を統一させる
						// このボタンでスキーマコンバートのグリッドに展開
						if (this.ultraGrid_Schm.ActiveRow != null)
						{
							string prtItemSetFilePath = String.Empty;
							prtItemSetFilePath = Path.Combine(System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath); // XML取得ディレクトリ

							if (string.IsNullOrEmpty(this.ultraGrid_Schm.Rows[this.ultraGrid_Schm.ActiveRow.Index].Cells[COL_OUTPUTFORMFILENAME].Value.ToString()))
							{
								ShowMessageDialog("出力ファイル名を入力してください。", null, 4);

								this.ultraGrid_Schm.Rows[this.ultraGrid_Schm.ActiveRow.Index].Cells[COL_OUTPUTFORMFILENAME].Activate();
								return;
							}

							if (string.IsNullOrEmpty(this.ultraGrid_Schm.Rows[this.ultraGrid_Schm.ActiveRow.Index].Cells[COL_OUTPUTFILECLASSID].Value.ToString()))
							{
								ShowMessageDialog("出力ファイルクラスIDを入力してください。", null, 4);

								this.ultraGrid_Schm.Rows[this.ultraGrid_Schm.ActiveRow.Index].Cells[COL_OUTPUTFILECLASSID].Activate();
								return;
							}

							if (this.ultraGrid_Schm.Rows[this.ultraGrid_Schm.ActiveRow.Index].Cells[COL_FREEPRTPPRITEMGRPCD].Value == DBNull.Value)
							{
								ShowMessageDialog("自由帳票印字項目グループコードはnullに出来ません", null, 4);
								return;
							}

							AddDataForConv();

							Assembly asm = null;
							try
							{
								// ファイルパス作成処理
								string filePath = this.CreateFilePath(_outputFormFileName);

								if(!string.IsNullOrEmpty(filePath))
								asm = Assembly.LoadFrom(filePath);
							}
							catch (FileNotFoundException ex)
							{
								ShowMessageDialog("アセンブリのロードに失敗しました。\r\n\r\n", ex, -1);
								return;
							}

							// 出力ファイルクラスIDのチェック
							if (asm != null)
							{
								object obj = asm.CreateInstance(_outputFileClassId);
								if (obj == null)
								{
									ShowMessageDialog("出力ファイルクラスIDを確認してください。", null, 4);
									return;
								}
							}

							this.CreateGridSchmConv(_outputFormFileName, _outputFileClassId);

							if ((this.ultraGrid_Item.Rows.Count == 0) || (_freePrtPprItemGrpCd != _freePrtPprItemGrpCdClone))
							{
								// 印字項目設定グリッド展開処理(StartupPath内のファイルを全検索)
								string wkFile = TBL_PrtItemSet + "_" + _freePrtPprItemGrpCd + ".xml";
								string itemFile = Path.Combine(prtItemSetFilePath, wkFile);
								if (File.Exists(itemFile))
								{
									this._dataSetItem.Tables[TBL_PrtItemSet].ReadXml(itemFile);
								}
								// 印字項目設定マスタがStartupPath内に無い場合、openFileDialogを開き印字項目設定を展開かけてもらう
								else
								{
									this.OpenGuideProc(_freePrtPprItemGrpCd);
								}
							}

							this.SchmConv_tToolbarsManager.Tools["Delete_Button"].SharedProps.Enabled = true; // 自由帳票スキーマコンバート削除ボタン
						}
						break;
					}
					case "Copy_ButtonTool":
					{
						bool allFlag = true; // 全件用フラグ

						DialogResult dialogResult = MessageBox.Show("全ての行に対してコピーを行いますか？\r\n「いいえ」の場合、選択したグループに対してのみコピーを行います。",
											"コピー処理",
											MessageBoxButtons.YesNoCancel,
											MessageBoxIcon.Information);

						switch (dialogResult)
						{
							case DialogResult.Yes:
								this.CopyDate(allFlag);
								break;
							case DialogResult.No:
								allFlag = false;
								this.CopyDate(allFlag);
								break;
							default: break;
						}
						break;
					}
				}
			}
			else
			{
				switch (e.Tool.Key)
				{
					case "Open_Button": // 開く
					{
						// Open処理
						this.OpenProc();
						break;
					}
					case "New_Button": // 行追加
					{
						// 新規作成処理
						this.NewProc(conv_index);
						break;
					}
					case "Delete_Button": // 行削除
					{
						// 削除処理
						this.DeleteProc(conv_index);
						break;
					}
				case "Extend_Button":
					{
						if(this.ultraGrid_Conv.Rows.Count > 0)
						{
							// 明細タブのサブレポートの展開を行う
							if (this.ultraGrid_Conv.ActiveRow != null)
							{
								string outputFormFileName = this.ultraGrid_Conv.ActiveRow.Cells[COL_OUTPUTFORMFILENAME].Value.ToString();
								string outputFormatClassId = this.ultraGrid_Conv.ActiveRow.Cells[COL_OUTPUTFILECLASSID].Value.ToString();

								if (!string.IsNullOrEmpty(outputFormFileName) &&
									!string.IsNullOrEmpty(outputFormatClassId))
								{
									Assembly asm = null;
									try
									{
										// ファイルパス作成処理
										string filePath = this.CreateFilePath(outputFormFileName);

										if(!string.IsNullOrEmpty(filePath))
										asm = Assembly.LoadFrom(filePath);
									}
									catch (FileNotFoundException ex)
									{
										ShowMessageDialog("アセンブリのロードに失敗しました。\r\n\r\n", ex, -1);
										return;
									}

									// 出力ファイルクラスIDのチェック
									if (asm != null)
									{
										object obj = asm.CreateInstance(outputFormatClassId);
										if (obj == null)
										{
											ShowMessageDialog("出力ファイルクラスIDを確認してください。", null, 4);
											return;
										}
									}

									// コンバートマスタグリッド展開処理
									this.CreateGridSchmConv(outputFormFileName, outputFormatClassId);
								}
							}
						}
						break;
					}
				}
			}
		}

		/// <summary>
		/// Guide_Button_Clickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 印字項目設定のガイドボタンをクリックしたときの処理です。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.22</br>
		/// </remarks>
		private void Guide_Button_Click(object sender, EventArgs e)
		{
			this.OpenGuideProc(_freePrtPprItemGrpCd);
		}

		#endregion

//****** Gridイベント **********************************************************************************************
		#region Gridイベント

		/// <summary>
		/// ultraGrid1_InitializeLayout イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レイアウトが初期化されたときに発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			// グリッドのカラム情報を設定します。
			UltraGrid ug = (UltraGrid)sender;
			if (ug == this.ultraGrid_Schm)
			{
				// UIグリッド初期設定処理
				this.UIGridConstruction(e.Layout, schm_index);
				SettingGridColumnSchm(ultraGrid_Schm.DisplayLayout.Bands[TBL_FPprSchmGr].Columns);
			}
			else if (ug == this.ultraGrid_Conv)
			{
				// UIグリッド初期設定処理
				this.UIGridConstruction(e.Layout, conv_index);
				SettingGridColumnConv(ultraGrid_Conv.DisplayLayout.Bands[TBL_FPprSchmCv].Columns);
			}
			else if (ug == this.ultraGrid_Item)
			{
				// UIグリッド初期設定処理
				this.UIGridConstruction(e.Layout, item_index);
				SettingGridColumnItem(ultraGrid_Item.DisplayLayout.Bands[TBL_PrtItemSet].Columns);
			}

			foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
			{
				if (ug == this.ultraGrid_Schm)
				{
					switch (col.Key)
					{
						case COL_LOGICALDELETECODE:
							{
								col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
								col.CellAppearance.BackColor = SystemColors.Control;
								break;
							}
					}
				}
				else if(ug == this.ultraGrid_Conv)
				{
					switch (col.Key)
					{
						case COL_CREATEDATETIME:
						case COL_UPDATETIME:
						case COL_LOGICALDELETECODE:
							{
								col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
								col.CellAppearance.BackColor = SystemColors.Control;
								break;
							}
					}				
				}
			}
		}


		/// <summary>
		/// UltraGrid.Enterイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: カーソルがグリッドに入ったときに発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.22</br>
		/// </remarks>
		private void ultraGrid1_Enter(object sender, EventArgs e)
		{
			UltraGrid wkGrid = (UltraGrid)sender;
			if (wkGrid != null)
			{
				if (wkGrid.ActiveCell != null)
				{
					wkGrid.PerformAction(UltraGridAction.EnterEditMode);
				}
				else
				{
					if (wkGrid == this.ultraGrid_Schm)
					{
						if (this.ultraGrid_Schm.Rows.Count > 0)
						{
							wkGrid.Rows[0].Cells[COL_FREEPRTPPRSCHMGRPCD].Activate();
						}
					}
					else if (wkGrid == this.ultraGrid_Conv)
					{
						if (this.ultraGrid_Conv.Rows.Count > 0)
						{
							wkGrid.Rows[0].Cells[COL_FREEPRTPPRSCHEMACD].Activate();
						}
					}
				}
			}
		}

		/// <summary>
		/// ultraGrid1_KeyDownイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: グリッドのフォーカス移動時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.25</br>
		/// </remarks>
		private void ultraGrid1_KeyDown(object sender, KeyEventArgs e)
		{
			int selectFlag = 0; // 判断用フラグ(1:スキーマグループ,2:スキーマコンバート,3:印字項目設定)

			UltraGrid ultraGrid = (UltraGrid)sender;
			// アクティブセルがnullの時は処理を行わず終了
			if(ultraGrid == null)
			{
				return;
			}

			Control nextControl = null;

			// 特殊キーが押されておらず、ドロップダウン可能なセルでもない時のみ、方向キーでの動作を制御
			if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
				((ultraGrid.CurrentState & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) !=
					Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
			{
				switch (e.KeyCode)
				{
					case Keys.Up:
						{
							e.Handled = true;
							// 選択がグループタブの時
							if (this.ultraTabControl1.SelectedTab.Key == "0")
							{
								// スキーマグループ
								selectFlag = schm_index;
							}
							else
							{
								// スキーマコンバート
								selectFlag = conv_index;
							}
							// セル移動処理(上)
							nextControl = this.MoveAboveCell(selectFlag);
							break;
						}
					case Keys.Down:
						{
							e.Handled = true;
							// 選択がグループタブの時
							if (this.ultraTabControl1.SelectedTab.Key == "0")
							{
								// スキーマグループ
								selectFlag = schm_index;
							}
							else
							{
								// スキーマコンバート
								selectFlag = conv_index;
							}
							// セル移動処理(下)
							nextControl = this.MoveBelowCell(selectFlag);
							break;
						}
					case Keys.Left:
						{
							// 選択がグループタブの時
							if (this.ultraTabControl1.SelectedTab.Key == "0")
							{
								// スキーマグループ
								selectFlag = schm_index;
							}
							else
							{
								// スキーマコンバート
								selectFlag = conv_index;
							}

							if (IsCellTextCursorAtFirst(selectFlag) == true)
							{
								e.Handled = true;
								// セル移動処理(左)
								nextControl = this.MoveLeftCell(selectFlag);
							}
							break;
						}
					case Keys.Right:
					case Keys.Enter:
						{
							// 選択がグループタブの時
							if (this.ultraTabControl1.SelectedTab.Key == "0")
							{
								// スキーマグループ
								selectFlag = schm_index;
							}
							else
							{
								// スキーマコンバート
								selectFlag = conv_index;
							}

							if (IsCellTextCursorAtLast(selectFlag) == true)
							{
								e.Handled = true;
								nextControl = this.MoveRightCell(selectFlag);
							}
							break;
						}
				}
				if (nextControl != null)
				{
					nextControl.Focus();
				}
			}

		}

		/// <summary>
		/// セル移動処理(上)
		/// </summary>
		/// <param name="selectFlag">判断用フラグ(1:スキーマグループ,2:スキーマコンバート,3:印字項目設定)</param>
		/// <returns>移動先コントロール</returns>
		/// <remarks>
		/// <br>Note		: セルの移動を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.25</br>
		/// </remarks>
		private Control MoveAboveCell(int selectFlag)
		{
			Control nextControl = null;

			switch(selectFlag)
			{
				case schm_index:
				{
					// 移動前のインデックスを取得
					int defRowIndex = ultraGrid_Schm.ActiveCell.Row.Index;
					int defColIndex = ultraGrid_Schm.ActiveCell.Column.Index;
					//アクティブセルが存在しない時は何も処理を行わずに終了
					if( this.ultraGrid_Schm.ActiveCell == null ) 
					{
						return nextControl;
					}

					// 上のセルへ移動
					this.ultraGrid_Schm.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);

					// セルが移動していない時は、上のコントロールにフォーカスを移動
					if((this.ultraGrid_Schm.ActiveCell.Row.Index	== defRowIndex) && 
						(this.ultraGrid_Schm.ActiveCell.Column.Index == defColIndex))
					{
						nextControl = this.ultraTabControl1;
					}
					break;
				}
				case conv_index:
				{
					// 移動前のインデックスを取得
					int defRowIndex = ultraGrid_Conv.ActiveCell.Row.Index;
					int defColIndex = ultraGrid_Conv.ActiveCell.Column.Index;
					// アクティブセルが存在しない時は何も処理を行わずに終了
					if( this.ultraGrid_Conv.ActiveCell == null ) 
					{
						return nextControl;
					}

					// 上のセルへ移動
					this.ultraGrid_Conv.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);

					// セルが移動していない時は、上のコントロールにフォーカスを移動
					if((this.ultraGrid_Conv.ActiveCell.Row.Index	== defRowIndex) && 
						(this.ultraGrid_Conv.ActiveCell.Column.Index == defColIndex))
					{
						nextControl = this.ultraTabControl1;
					}

					break;
				}
				case item_index:
				{
					// 移動前のインデックスを取得
					int defRowIndex = ultraGrid_Item.ActiveCell.Row.Index;
					int defColIndex = ultraGrid_Item.ActiveCell.Column.Index;
					// 上のセルへ移動
					this.ultraGrid_Item.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);

					// セルが移動していない時は、上のコントロールにフォーカスを移動
					if((this.ultraGrid_Item.ActiveCell.Row.Index	== defRowIndex) && 
						(this.ultraGrid_Item.ActiveCell.Column.Index == defColIndex))
					{
						nextControl = this.ultraTabControl1;
					}

					break;
				}
			}

			return nextControl;
		}

		/// <summary>
		/// セル移動処理(下)
		/// </summary>
		/// <param name="selectFlag">判断用フラグ(1:スキーマグループ,2:スキーマコンバート,3:印字項目設定)</param>
		/// <returns>移動先コントロール</returns>
		/// <remarks>
		/// <br>Note		: セルの移動を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.25</br>
		/// </remarks>
		private Control MoveBelowCell(int selectFlag)
		{
			Control nextControl = null;

			switch (selectFlag)
			{
				case schm_index:
				{
					// アクティブセルが存在しない時は何も処理を行わずに終了
					if(ultraGrid_Schm.ActiveCell == null)
					{
						return nextControl;
					}

					// 移動前のインデックスを取得
					int defRowIndex = ultraGrid_Schm.ActiveCell.Row.Index;
					int defColIndex = ultraGrid_Schm.ActiveCell.Column.Index;

					// 編集モードかどうかチェック
					if((ultraGrid_Schm.CurrentState & Infragistics.Win.UltraWinGrid.UltraGridState.InEdit) == 
						Infragistics.Win.UltraWinGrid.UltraGridState.InEdit)
					{
						// 編集モードの時は編集モードを終了
						this.ultraGrid_Schm.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
					}

					// 下のセルへ移動
					this.ultraGrid_Schm.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);

					// セルが移動していない時は、下のコントロールにフォーカスを移動
					if((this.ultraGrid_Schm.ActiveCell.Row.Index	== defRowIndex) && 
						(this.ultraGrid_Schm.ActiveCell.Column.Index == defColIndex))
					{
						// 下への移動は出来ない
						nextControl = null;
					}
					break;
				}
				case conv_index:
				{
					// アクティブセルが存在しない時は何も処理を行わずに終了
					if(ultraGrid_Conv.ActiveCell == null)
					{
						return nextControl;
					}

					// 移動前のインデックスを取得
					int defRowIndex = ultraGrid_Conv.ActiveCell.Row.Index;
					int defColIndex = ultraGrid_Conv.ActiveCell.Column.Index;

					// 編集モードかどうかチェック
					if((ultraGrid_Conv.CurrentState & Infragistics.Win.UltraWinGrid.UltraGridState.InEdit) == 
						Infragistics.Win.UltraWinGrid.UltraGridState.InEdit)
					{
						// 編集モードの時は編集モードを終了
						this.ultraGrid_Conv.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
					}

					// 下のセルへ移動
					this.ultraGrid_Conv.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);

					// セルが移動していない時は、下のコントロールにフォーカスを移動
					if((this.ultraGrid_Conv.ActiveCell.Row.Index	== defRowIndex) && 
						(this.ultraGrid_Conv.ActiveCell.Column.Index == defColIndex))
					{
						// 下への移動は出来ない
						nextControl = null;
					}
					break;
				}
				case item_index:
				{
					// 下のセルへ移動
					this.ultraGrid_Item.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
					
					break;
				}

			}
			return nextControl;
		}

		/// <summary>
		/// セル移動処理(左)
		/// </summary>
		/// <param name="selectFlag">判断用フラグ(1:スキーマグループ,2:スキーマコンバート,3:印字項目設定)</param>
		/// <returns>移動先コントロール</returns>
		/// <remarks>
		/// <br>Note		: セルの移動を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.25</br>
		/// </remarks>
		private Control MoveLeftCell(int selectFlag)
		{
			Control nextControl = null;

			switch (selectFlag)
			{
				case schm_index:
				{
					// 移動前のインデックスを取得
					int defRowIndex = ultraGrid_Schm.ActiveCell.Row.Index;
					int defColIndex = ultraGrid_Schm.ActiveCell.Column.Index;

					// アクティブセルが存在しない時は何も処理を行わずに終了
					if(this.ultraGrid_Schm.ActiveCell == null)
					{
						return nextControl;
					}

					// 左のセルへ移動
					this.ultraGrid_Schm.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);
					
					// セルが移動していない時は、グループタブにフォーカスを移動
					if((this.ultraGrid_Schm.ActiveCell.Row.Index	== defRowIndex) && 
						(this.ultraGrid_Schm.ActiveCell.Column.Index == defColIndex)) 
					{
						nextControl = this.ultraTabPageControl1;
					}

					break;
				}
				case conv_index:
				{
					// 移動前のインデックスを取得
					int defRowIndex = ultraGrid_Conv.ActiveCell.Row.Index;
					int defColIndex = ultraGrid_Conv.ActiveCell.Column.Index;
					
					// アクティブセルが存在しない時は何も処理を行わずに終了
					if(this.ultraGrid_Conv.ActiveCell == null)
					{
						return nextControl;
					}

					// 左のセルへ移動
					this.ultraGrid_Conv.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

					// セルが移動していない時は、グループタブにフォーカスを移動
					if((this.ultraGrid_Conv.ActiveCell.Row.Index	== defRowIndex) && 
						(this.ultraGrid_Conv.ActiveCell.Column.Index == defColIndex)) 
					{
						nextControl = this.ultraTabPageControl1;
					}

					break;
				}
				case item_index:
				{
					// 左のセルへ移動
					this.ultraGrid_Item.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

					break;
				}
			}

			return nextControl;
		}

		/// <summary>
		/// セル移動処理(右)
		/// </summary>
		/// <param name="selectFlag">判断用フラグ(1:スキーマグループ,2:スキーマコンバート,3:印字項目設定)</param>
		/// <returns>移動先コントロール</returns>
		/// <remarks>
		/// <br>Note		: セルの移動を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.25</br>
		/// </remarks>
		private Control MoveRightCell(int selectFlag)
		{
			Control nextControl = null;

			switch (selectFlag)
			{
				case schm_index:
				{
					// 移動前のインデックスを取得
					int defRowIndex = ultraGrid_Schm.ActiveCell.Row.Index;
					int defColIndex = ultraGrid_Schm.ActiveCell.Column.Index;

					// アクティブセルが存在しない時は何も処理を行わずに終了
					if(this.ultraGrid_Schm.ActiveCell == null)
					{
						return nextControl;
					}

					// 右のセルへ移動
					this.ultraGrid_Schm.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
					
					// セルが移動していない時は、グループタブにフォーカスを移動
					if((this.ultraGrid_Schm.ActiveCell.Row.Index	== defRowIndex) && 
						(this.ultraGrid_Schm.ActiveCell.Column.Index == defColIndex)) 
					{
						nextControl = null;
					}

					break;

				}
				case conv_index:
				{
					// 移動前のインデックスを取得
					int defRowIndex = ultraGrid_Conv.ActiveCell.Row.Index;
					int defColIndex = ultraGrid_Conv.ActiveCell.Column.Index;
					
					// アクティブセルが存在しない時は何も処理を行わずに終了
					if(this.ultraGrid_Conv.ActiveCell == null)
					{
						return nextControl;
					}

					// 左のセルへ移動
					this.ultraGrid_Conv.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

					// セルが移動していない時は、グループタブにフォーカスを移動
					if((this.ultraGrid_Conv.ActiveCell.Row.Index	== defRowIndex) && 
						(this.ultraGrid_Conv.ActiveCell.Column.Index == defColIndex)) 
					{
						nextControl = null;
					}

					break;

				}
				case item_index:
				{
					// 左のセルへ移動
					this.ultraGrid_Item.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

					break;
				}

			}

			return nextControl;
		}

		/// <summary>
		/// セル内テキストカーソル先頭判定処理
		/// </summary>
		/// <param name="selectFlag">判断用フラグ(1:スキーマグループ,2:スキーマコンバート)</param>
		/// <returns>チェック結果(true: 先頭)</returns>
		/// <remarks>
		/// <br>Note		: セルの編集中のカーソルが先頭にあるかどうかチェックします。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.25</br>
		/// </remarks>
		private bool IsCellTextCursorAtFirst(int selectFlag)
		{
			if (selectFlag == schm_index)
			{
				// アクティブセルがnull
				if(ultraGrid_Schm.ActiveCell == null)
				{
					return false;
				}

				// 編集モードでない時は終了
				if((this.ultraGrid_Schm.CurrentState & Infragistics.Win.UltraWinGrid.UltraGridState.InEdit) != 
					Infragistics.Win.UltraWinGrid.UltraGridState.InEdit) 
				{
					return false;
				}

				// 編集用エディットがテキストの選択をサポートしていない(コンボボックス)時はセル移動を許可
				if(this.ultraGrid_Schm.ActiveCell.Column.Editor.SupportsSelectableText == false)
				{
					return true;
				}

				// カーソルは先頭？ & 非選択？
				if((this.ultraGrid_Schm.ActiveCell.SelStart == 0) && 
					(this.ultraGrid_Schm.ActiveCell.SelLength == 0))
				{
					return true;
				}
				else
				{
					return false;
				}

			}

			if (selectFlag == conv_index)
			{
				// アクティブセルがnull
				if(ultraGrid_Conv.ActiveCell == null)
				{
					return false;
				}

				// 編集モードでない時は終了
				if((this.ultraGrid_Conv.CurrentState & Infragistics.Win.UltraWinGrid.UltraGridState.InEdit) != 
					Infragistics.Win.UltraWinGrid.UltraGridState.InEdit) 
				{
					return false;
				}

				// 編集用エディットがテキストの選択をサポートしていない(コンボボックス)時はセル移動を許可
				if(this.ultraGrid_Conv.ActiveCell.Column.Editor.SupportsSelectableText == false)
				{
					return true;
				}

				// カーソルは先頭？ & 非選択？
				if((this.ultraGrid_Conv.ActiveCell.SelStart == 0) && 
					(this.ultraGrid_Conv.ActiveCell.SelLength == 0))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			
			return false;
		}

		/// <summary>
		/// セル内テキストカーソル最後尾判定処理
		/// </summary>
		/// <param name="selectFlag">判断用フラグ(1:スキーマグループ,2:スキーマコンバート)</param>
		/// <returns>チェック結果(true: 最後尾)</returns>
		/// <remarks>
		/// <br>Note		: セルの編集中のカーソルが最後尾にあるかどうかチェックします。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.25</br>
		/// </remarks>
		private bool IsCellTextCursorAtLast(int selectFlag)
		{
			if (selectFlag == schm_index)
			{
				// アクティブセルがnull
				if(this.ultraGrid_Schm.ActiveCell == null)
				{
					return false;
				}

				// 編集モードでない時は終了
				if((this.ultraGrid_Schm.CurrentState & Infragistics.Win.UltraWinGrid.UltraGridState.InEdit) != 
					Infragistics.Win.UltraWinGrid.UltraGridState.InEdit)
				{
					return false;
				}

				// 編集用エディットがテキストの選択をサポートしていない時(コンボボックス)はセル移動を許可
				if(this.ultraGrid_Schm.ActiveCell.Column.Editor.SupportsSelectableText == false)
				{
					return true;
				}

				// カーソルは最後尾？ & 非選択？
				if((this.ultraGrid_Schm.ActiveCell.SelStart == this.ultraGrid_Schm.ActiveCell.Column.Editor.TextLength) && 
					( this.ultraGrid_Schm.ActiveCell.SelLength == 0))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}

			if (selectFlag == conv_index)
			{
				// アクティブセルがnull
				if(this.ultraGrid_Conv.ActiveCell == null)
				{
					return false;
				}

				// 編集モードでない時は終了
				if((this.ultraGrid_Conv.CurrentState & Infragistics.Win.UltraWinGrid.UltraGridState.InEdit) != 
					Infragistics.Win.UltraWinGrid.UltraGridState.InEdit)
				{
					return false;
				}

				// 編集用エディットがテキストの選択をサポートしていない時(コンボボックス)はセル移動を許可
				if(this.ultraGrid_Conv.ActiveCell.Column.Editor.SupportsSelectableText == false)
				{
					return true;
				}

				// カーソルは最後尾？ & 非選択？
				if((this.ultraGrid_Conv.ActiveCell.SelStart == this.ultraGrid_Conv.ActiveCell.Column.Editor.TextLength) && 
					( this.ultraGrid_Conv.ActiveCell.SelLength == 0))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			
			return false;
		}

		/// <summary>
		/// ultraGrid_Schm_BeforeCellUpdateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: セルが新しい値を受け入れる前の処理です。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.22</br>
		/// </remarks>
		private void ultraGrid_Schm_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
		{
			UltraGrid ultraGrid = (UltraGrid)sender;
		    string message = String.Empty;
		    switch(e.Cell.Column.Key)
		    {
		        // 自由帳票スキーマグループコード
		        case COL_FREEPRTPPRSCHMGRPCD:
		        {
					if (e.NewValue == DBNull.Value)
					{
						message = e.Cell.Column.Header.Caption + "はnullに設定できません。";
						break;
					}

		            int wkFreePrtPprSchmGrpCd = (int)e.NewValue;

		            if (wkFreePrtPprSchmGrpCd == 0)
		            {
		                message = e.Cell.Column.Header.Caption + "に0は設定できません。";
		            }
		            else
		            {
		                DataRow[] rowArray = this._dataSetSchm.Tables["FPprSchmGrRF"].Select(COL_FREEPRTPPRSCHMGRPCD + "=" + wkFreePrtPprSchmGrpCd);
		                if (rowArray == null || rowArray.Length == 0)
		                    _prevFreePrtPprSchmGrpCd = (int)e.Cell.Value;
		                else
		                    message = e.Cell.Column.Header.Caption + "の重複は許可されていません。";
		            }

		            break;
		        }
		        // 出力ファイル名称
		        case COL_OUTPUTFORMFILENAME:
		        // 出力ファイルクラスID
		        case COL_OUTPUTFILECLASSID:
		        {
					if (ultraGrid == ultraGrid_Schm)
					{
						string wkOutputFormFileName = String.Empty;
						string wkOutputFileClassId = String.Empty;

						if (e.NewValue == DBNull.Value)
						{
							message = e.Cell.Column.Header.Caption + "はnullに出来ません。";
							break;
						}

						if (e.Cell.Column.Key == COL_OUTPUTFORMFILENAME)
						{
							wkOutputFormFileName = e.NewValue.ToString();
							// ファイルパス作成処理
							if (!string.IsNullOrEmpty(wkOutputFormFileName))
							{
								string filePath = this.CreateFilePath(wkOutputFormFileName);
								if (!string.IsNullOrEmpty(filePath))
								{
									try
									{
										Assembly asm = Assembly.LoadFrom(filePath);
									}
									catch (FileNotFoundException ex)
									{
										message = ex.Message;
										break;
									}
								}
							}
						}
						else
						{
							Assembly asm = null;
							wkOutputFormFileName = ultraGrid.ActiveRow.Cells[COL_OUTPUTFORMFILENAME].Value.ToString();
							wkOutputFileClassId = e.NewValue.ToString();

							if (!string.IsNullOrEmpty(wkOutputFormFileName) &&
								(!string.IsNullOrEmpty(wkOutputFileClassId)))
							{
								// ファイルパス作成処理
								string filePath = this.CreateFilePath(wkOutputFormFileName);
								if (!string.IsNullOrEmpty(filePath))
								{
									try
									{
										asm = Assembly.LoadFrom(filePath);
									}
									catch (FileNotFoundException ex)
									{
										message = ex.Message;
										break;
									}
									if (asm != null)
									{
										try
										{
											Object obj = asm.CreateInstance(wkOutputFileClassId);
											if (obj == null)
											{
												message = e.Cell.Column.Header.Caption + "を確認してください。";
												break;
											}
										}
										catch (Exception ex)
										{
											MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace.ToString());
										}
									}
								}
							}
							break;
						}
						
					}
                    break;
		        }
		        // 自由帳票スキーマコード
		        case COL_FREEPRTPPRSCHEMACD:
		        {
					if (e.NewValue == DBNull.Value)
					{
						message = e.Cell.Column.Header.Caption + "はnullに設定できません。";
						break;
					}
		            int wkFreePrtPprSchemaCd = (int)e.NewValue;

		            if (wkFreePrtPprSchemaCd == 0)
		            {
		                message = e.Cell.Column.Header.Caption + "に0は設定できません。";
		            }
		            else
		            {
		                DataRow[] rowArray = this._dataSetConv.Tables["FPprSchmCvRF"].Select("FreePrtPprSchemaCd =" + wkFreePrtPprSchemaCd);
		                if (rowArray == null || rowArray.Length == 0)
		                    _prevFreePrtPprSchemaCd = (int)e.Cell.Value;
		                else
		                    message = e.Cell.Column.Header.Caption + "の重複は許可されていません。";
		            }
		            break;
		        }
		    }

		    if (!string.IsNullOrEmpty(message))
		    {
				ShowMessageDialog(message, null, 4);
		        e.Cancel = true;
		    }

		}
		
		/// <summary>
		/// ultraGrid_Schm_BeforeEnterEditModeイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: セルが編集モードに入る前に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.22</br>
		/// </remarks>
		private void ultraGrid_Schm_BeforeEnterEditMode(object sender, CancelEventArgs e)
		{
			UltraGrid wkGrid = sender as UltraGrid;
			if (wkGrid != null)
			{
				if (wkGrid.ActiveCell == null) return;

				if (wkGrid.ActiveCell.Column.Key == COL_DISPLAYNAME)
				{
					wkGrid.ImeMode = ImeMode.Hiragana;
				}
				else
				{
					wkGrid.ImeMode = ImeMode.Off;
				}
			}		
		}

		/// <summary>
		/// ultraGrid_Schm_AfterCellActivateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: セルがアクティブ化された時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.22</br>
		/// </remarks>
		private void ultraGrid_Schm_AfterCellActivate(object sender, EventArgs e)
		{
			UltraGrid wkGrid = (UltraGrid)sender;

			if (wkGrid.ActiveCell.CanEnterEditMode)
				wkGrid.PerformAction(UltraGridAction.EnterEditMode);
		}

		/// <summary>
		/// ultraGrid_Item_DoubleClickRowイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 印字項目設定グリッドをダブルクリックした時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void ultraGrid_Item_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
		{
			if (this.ultraGrid_Item.Rows.Count > 0)
			{
				// 選択されている行のindexを取得します。
				int indexItem = e.Row.Index;

				// 選択されている印字項目設定マスタの行データを取得します。
				int itemFreePrtPaperItemCd  = (int)this.ultraGrid_Item.Rows[indexItem].Cells[COL_FREEPRTPAPERITEMCD].Value;  // 自由帳票項目コード
				int itemCommaEditExistCd	= (int)this.ultraGrid_Item.Rows[indexItem].Cells[COL_COMMAEDITEXISTCD].Value;	// カンマ編集有無
				int itemPrintPageCtrlDivCd  = (int)this.ultraGrid_Item.Rows[indexItem].Cells[COL_PRINTPAGECTRLDIVCD].Value;  // 印字ページ制御区分

				if (this.ultraGrid_Conv.Rows.Count != 0)
				{
					int indexConv = this.ultraGrid_Conv.ActiveRow.Index;
					this.ultraGrid_Conv.Rows[indexConv].Cells[COL_FREEPRTPAPERITEMCD].Value   = itemFreePrtPaperItemCd;
					this.ultraGrid_Conv.Rows[indexConv].Cells[COL_COMMAEDITEXISTCD].Value	  = itemCommaEditExistCd;
					this.ultraGrid_Conv.Rows[indexConv].Cells[COL_PRINTPAGECTRLDIVCD].Value   = itemPrintPageCtrlDivCd;
				}
			}

		}

		#endregion

		/// <summary>
		/// ultraTabControl1_KeyDownイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: TabControlからフォーカスが抜ける時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.09.05</br>
		/// </remarks>
		private void ultraTabControl1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if ((this.ultraGrid_Schm.Rows.Count > 0) && (this.ultraTabControl1.ActiveTab.Key == "0"))
				{
					this.ultraGrid_Schm.Focus();
				}
				else if ((this.ultraGrid_Conv.Rows.Count > 0) && (this.ultraTabControl1.ActiveTab.Key == "1"))
				{
					this.ultraGrid_Conv.Focus();
				}
			}
		}

		/// <summary>
		/// メッセージダイアログ表示処理
		/// </summary>
		/// <param name="msg">表示メッセージ</param>
		/// <param name="ex">例外オブジェクト</param>
		/// <param name="status">エラーステータス</param>
		private static void ShowMessageDialog(string msg, Exception ex, int status)
		{
			if (ex != null)
			{
				MessageBox.Show(
					msg + ex.Message,
					ctMSG_CAPTION,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information,
					MessageBoxDefaultButton.Button1);
			}
			else
			{
				switch (status)
				{
					case 0:
					case 4:
						{
							MessageBox.Show(
								msg,
								ctMSG_CAPTION,
								MessageBoxButtons.OK,
								MessageBoxIcon.Information,
								MessageBoxDefaultButton.Button1);
							break;
						}
					default:
						{
							MessageBox.Show(
								msg,
								ctMSG_CAPTION,
								MessageBoxButtons.OK,
								MessageBoxIcon.Error,
								MessageBoxDefaultButton.Button1);
							break;
						}
				}
			}
		}

		/// <summary>
		/// アクティブレポート展開処理
		/// </summary>
		/// <param name="asm">アセンブリ</param>
		/// <param name="classID">出力ファイルクラスID</param>
		private void ExtendActiveReport(Assembly asm, string classID)
		{
			// インスタンスを作成します。
			Object wkObj = asm.CreateInstance(classID);

			// 紐づくActiveReportをインスタンス化します。
			ActiveReport3 wkrpt = wkObj as ActiveReport3;

			if (wkrpt != null)
			{
				for (int ix = 0; ix != wkrpt.Sections.Count; ix++)
				{
					Section section = wkrpt.Sections[ix];

					for (int iy = 0; iy != section.Controls.Count; iy++)
					{
						ARControl control = section.Controls[iy];

						// 新規作成処理(コンバート)
						this.AddNewRowSchmConv(control, wkrpt);
					}
				}
			}
		}

		/// <summary>
		/// ultraTabControl1_SelectedTabChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: タブ切替時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.09.06</br>
		/// </remarks>
		private void ultraTabControl1_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
		{
			if((this.ultraGrid_Schm.Rows.Count > 0) && (this._dataSetConv.Tables[TBL_FPprSchmCv].Rows.Count > 0))
			{
				// スキーマグループコードに紐づくデータをfilterで絞って表示かける
				string filter = string.Empty;
				// 自由帳票スキーマグループコード
				int frePrtPprSchmaGrpCd = (int)this.ultraGrid_Schm.ActiveRow.Cells[COL_FREEPRTPPRSCHMGRPCD].Value;
				filter = COL_FREEPRTPPRSCHMGRPCD + "=" + frePrtPprSchmaGrpCd;

				this._dataSetConv.Tables[TBL_FPprSchmCv].DefaultView.RowFilter = filter;

				// 作成日付、更新日付を取得
				if (e.PreviousSelectedTab.Key == "0")
				{
					_createDateTime = (long)this.ultraGrid_Schm.ActiveRow.Cells[COL_CREATEDATETIME].Value;
					_updateTime = (long)this.ultraGrid_Schm.ActiveRow.Cells[COL_UPDATETIME].Value;
				}
				
			}

		}

		#region 2007.09.07 DEL (コンボボックスを選択した瞬間にエラー落ちするため)
		///// <summary>
		///// ultraGrid_Conv_MouseEnterElementイベント
		///// </summary>
		///// <param name="sender">対象オブジェクト</param>
		///// <param name="e">イベントパラメータ</param>
		///// <remarks>
		///// <br>Note		: マウスがコンバートグリッドの行を選択した時に発生します。</br>
		///// <br>Programmer	: 30015 橋本　裕毅</br>
		///// <br>Date		: 2007.09.06</br>
		///// </remarks>
		//private void ultraGrid_Conv_MouseEnterElement(object sender, UIElementEventArgs e)
		//{
		//    // 現在選択している行を取得
		//    object contextRow	= e.Element.GetContext(typeof(UltraGridRow));
		//    UltraGrid ultraGrid = (UltraGrid)sender;

		//    if (ultraGrid.ActiveCell != null)
		//    {
		//        int wkFreePrtPaperItemCd = (int)ultraGrid.ActiveRow.Cells[COL_FREEPRTPAPERITEMCD].Value; // 自由帳票項目コード
				
		//        // 自由帳票項目コードに紐付く行を取得します。
		//        string filter = COL_FREEPRTPAPERITEMCD + "=" + wkFreePrtPaperItemCd;
		//        DataRow[] drArray = _dataSetItem.Tables[TBL_PrtItemSet].Select(filter);
				
		//        if (drArray.Length > 0)
		//        {
		//            try
		//            {
		//                UltraGridRow row = contextRow as UltraGridRow;
		//                StringBuilder sb = new StringBuilder(string.Empty);

		//                // 印字項目設定側の情報をStringBuilderに追加
		//                // 自由帳票項目名称
		//                sb.Append(this.ultraGrid_Item.DisplayLayout.Bands[0].Columns[COL_FREPRTPAPERITEMNM].Header.Caption.PadRight(10, '　') + "：" + drArray[0][COL_FREPRTPAPERITEMNM].ToString());

		//                // ファイル名称
		//                if (sb.Length > 0)
		//                {
		//                    sb.Append("\r\n");
		//                }
		//                sb.Append(this.ultraGrid_Item.DisplayLayout.Bands[0].Columns[COL_FILENM].Header.Caption.PadRight(10, '　') + "：" + drArray[0][COL_FILENM].ToString());

		//                // DD名称
		//                if (sb.Length > 0)
		//                {
		//                    sb.Append("\r\n");
		//                }
		//                sb.Append(this.ultraGrid_Item.DisplayLayout.Bands[0].Columns[COL_DDNAME].Header.Caption.PadRight(11, '　') + "：" + drArray[0][COL_DDNAME].ToString());

		//                // 自由帳票印字項目コード
		//                if (sb.Length > 0)
		//                {
		//                    sb.Append("\r\n");
		//                }
		//                sb.Append(this.ultraGrid_Item.DisplayLayout.Bands[0].Columns[COL_FREEPRTPAPERITEMCD].Header.Caption.PadRight(10, '　') + "：" + drArray[0][COL_FREEPRTPAPERITEMCD].ToString());

		//                UltraToolTipInfo ultraToolTipInfo = new UltraToolTipInfo();
		//                ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
		//                ultraToolTipInfo.ToolTipTitle = "印字項目設定";
		//                ultraToolTipInfo.ToolTipText = sb.ToString();

		//                // ツールチップを表示
		//                this.ultraToolTipManager1.Appearance.FontData.Name = "ＭＳ ゴシック";
		//                this.ultraToolTipManager1.SetUltraToolTip(this.ultraGrid_Conv, ultraToolTipInfo);
		//                this.ultraToolTipManager1.Enabled = true;
		//            }
		//            catch (Exception ex)
		//            {
		//                MessageBox.Show(ex.StackTrace + "\r\n" + ex.Source);
		//            }
		//            //catch (NullReferenceException ex)
		//            //{
		//            //    ShowMessageDialog(ex.Message, null, -1);
		//            //}
		//        }
		//    }
		//}

		//private void ultraGrid_Conv_BeforeCellListDropDown(object sender, CancelableCellEventArgs e)
		//{
		//    this.ultraToolTipManager1.HideToolTip();
		//    this.ultraToolTipManager1.Enabled	= false;
		//}

		///// <summary>
		///// ultraGrid_Conv_MouseLeaveElementイベント
		///// </summary>
		///// <param name="sender">対象オブジェクト</param>
		///// <param name="e">イベントパラメータ</param>
		///// <remarks>
		///// <br>Note		: マウスがコンバートグリッドの行から離れた時に発生します。</br>
		///// <br>Programmer	: 30015 橋本　裕毅</br>
		///// <br>Date		: 2007.09.06</br>
		///// </remarks>
		//private void ultraGrid_Conv_MouseLeaveElement(object sender, UIElementEventArgs e)
		//{
		//    // ツールツップを非表示
		//    this.ultraToolTipManager1.HideToolTip();
		//    this.ultraToolTipManager1.Enabled	= false;
		//}
		#endregion

		/// <summary>
        /// LIKE用比較文字列作成処理
        /// </summary>
        /// <param name="extrString">置換対象文字列</param>
        /// <returns>置換後文字列</returns>
        /// <remarks>
        /// <br>Note       : LIKE用に文字列内の*,%,[,]を[]で囲みます</br>
        /// <br>Programmer : 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.09.06</br>
        /// </remarks>
        private string CreatLikeExpression(string extrString)
        {
            string pattern = "[*,%,\\[,\\]]";					// 被置換文字列
            string evaluator = "[$&]";							// 置換文字列（前後に"[", "]"を挿入）
            return Regex.Replace(extrString, pattern, evaluator);
        }

		/// <summary>
		/// SchmConv_tToolbarsManager_ToolValueChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ツールバーの値が変更した時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.09.06</br>
		/// </remarks>
		private void SchmConv_tToolbarsManager_ToolValueChanged(object sender, ToolEventArgs e)
		{
			if (e.Tool.Key == "SelectSearch_Combo")
			{
				int wkToolBarValue = (int)((Infragistics.Win.UltraWinToolbars.ComboBoxTool)SchmConv_tToolbarsManager.Tools["SelectSearch_Combo"]).Value;
				if (wkToolBarValue == 10)
				{
					// 項目名称の時だけ、平仮名入力に返る
					this.ultraTabPageControl2.ImeMode = ImeMode.Hiragana;
				}
				else
				{
					this.ultraTabPageControl2.ImeMode = ImeMode.NoControl;
				}
			}
			else if(e.Tool.Key == "Input_TextBox")
			{
				TToolbarsManager toolbarsManager = (TToolbarsManager)sender;
				if (toolbarsManager.ActiveTool.Key == "Input_TextBox")
				{
					if (_dataSetItem.Tables[TBL_PrtItemSet].Rows.Count > 0)
					{
						string text = ((TextBoxTool)toolbarsManager.ActiveTool).Text;
						string filter =string.Empty;

						if (!string.IsNullOrEmpty(text))
						{
							int wkToolBarValue = (int)((Infragistics.Win.UltraWinToolbars.ComboBoxTool)SchmConv_tToolbarsManager.Tools["SelectSearch_Combo"]).Value;
							// 選択検索区分が項目名称の場合
							if (wkToolBarValue == 10)
							{
								filter = COL_FREPRTPAPERITEMNM + " LIKE '*" + this.CreatLikeExpression(text) + "*'";
							}
							// 選択検索区分がDD名称の場合
							else
							{
								filter = COL_DDNAME + " LIKE '*" + this.CreatLikeExpression(text) + "*'";
							}
						}
						else
						{
							filter = string.Empty;
						}
						this._dataSetItem.Tables[TBL_PrtItemSet].DefaultView.RowFilter = filter;
					}
				}			
			}
		}

		/// <summary>
		/// ファイルパス作成処理
		/// </summary>
		/// <param name="outputFormFileName">出力ファイル名称</param>
		/// <returns>ファイルパス</returns>
		/// <remarks>
		/// <br>Note		: 拡張子が付いているものと付いていないものでファイルパスを分けます。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.09.06</br>
		/// </remarks>
		private string CreateFilePath(string outputFormFileName)
		{
			string filePath = string.Empty;

			FileInfo fi = new FileInfo(outputFormFileName);
			if (string.IsNullOrEmpty(fi.Extension))
			{
				filePath = cnt_SFNETASM + outputFormFileName + ".dll";
			}
			else
			{
				filePath = cnt_SFNETASM + outputFormFileName;
			}
			return filePath;
		}

		/// <summary>
		/// ultraGrid_Schm_BeforeRowActivateイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: RowがActiveになる前に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void ultraGrid_Schm_BeforeRowActivate(object sender, RowEventArgs e)
		{
			UltraGrid ultraGrid = (UltraGrid)sender;
			
			if (ultraGrid.Rows.Count > 0)
			{
				string outputFileName = e.Row.Cells[COL_OUTPUTFORMFILENAME].Value.ToString();
				string outputFormClassId = e.Row.Cells[COL_OUTPUTFILECLASSID].Value.ToString();
				object ob = null;
				if (ultraGrid == this.ultraGrid_Schm)
				{
					ob = e.Row.Cells[COL_FREEPRTPPRITEMGRPCD].Value;
				}

				JudgeEnable(ultraGrid, outputFileName, outputFormClassId, ob);
			}
		}

		/// <summary>
		/// ultraGrid_Schm_AfterRowUpdateイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: Rowが更新された後に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void ultraGrid_Schm_AfterRowUpdate(object sender, RowEventArgs e)
		{
		    UltraGrid ultraGrid = (UltraGrid)sender;

		    if (ultraGrid.Rows.Count > 0)
		    {
		        string outputFileName = e.Row.Cells[COL_OUTPUTFORMFILENAME].Value.ToString();
		        string outputFormClassId = e.Row.Cells[COL_OUTPUTFILECLASSID].Value.ToString();
				object ob = null;
				if (ultraGrid == this.ultraGrid_Schm)
				{
					ob = e.Row.Cells[COL_FREEPRTPPRITEMGRPCD].Value;
				}

		        JudgeEnable(ultraGrid, outputFileName, outputFormClassId, ob);
		    }
		}

		/// <summary>
		/// ultraGrid_Schm_AfterCellUpdateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: フォーカスがセルを抜けた時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void ultraGrid_Schm_AfterCellUpdate(object sender, CellEventArgs e)
		{
			UltraGrid ultraGrid = (UltraGrid)sender;
			string outputFileName = string.Empty;
			string outputFormClassId = string.Empty;
			object ob = null;

			if (ultraGrid.Rows.Count > 0)
			{
				if (e.Cell.Column.Key == COL_OUTPUTFORMFILENAME)
				{
					outputFileName = e.Cell.Value.ToString();
					outputFormClassId = ultraGrid.ActiveRow.Cells[COL_OUTPUTFILECLASSID].Value.ToString();
					if (ultraGrid == this.ultraGrid_Schm)
					{
						ob = ultraGrid.ActiveRow.Cells[COL_FREEPRTPPRITEMGRPCD].Value;
					}
					JudgeEnable(ultraGrid, outputFileName, outputFormClassId, ob);
				}
				else if (e.Cell.Column.Key == COL_OUTPUTFILECLASSID)
				{
					outputFileName = ultraGrid.ActiveRow.Cells[COL_OUTPUTFORMFILENAME].Value.ToString();
					outputFormClassId = e.Cell.Value.ToString();
					if (ultraGrid == this.ultraGrid_Schm)
					{
						ob = ultraGrid.ActiveRow.Cells[COL_FREEPRTPPRITEMGRPCD].Value;
					}
					JudgeEnable(ultraGrid, outputFileName, outputFormClassId, ob);
				}
				else if (e.Cell.Column.Key == COL_FREEPRTPPRITEMGRPCD)
				{
					outputFileName = ultraGrid.ActiveRow.Cells[COL_OUTPUTFORMFILENAME].Value.ToString();
					outputFormClassId = ultraGrid.ActiveRow.Cells[COL_OUTPUTFILECLASSID].Value.ToString();
					ob = e.Cell.Value;
					JudgeEnable(ultraGrid, outputFileName, outputFormClassId, ob);
				}
				
			}
		}


		/// <summary>
		/// Enable判断処理
		/// </summary>
		/// <param name="ultraGrid">対象となるultraGrid</param>
		/// <param name="outputFileName">出力ファイル名称</param>
		/// <param name="outputFormClassId">出力ファイルクラスID</param>
		/// <param name="ob">印字項目グループオブジェクト</param>
		/// <remarks>
		/// <br>Note		: 展開ボタンの判断をします。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void JudgeEnable(UltraGrid ultraGrid, string outputFileName, string outputFormClassId, object ob)
		{
			if ((!string.IsNullOrEmpty(outputFileName)) &&
				(!string.IsNullOrEmpty(outputFormClassId)))
			{
				if (ultraGrid == this.ultraGrid_Schm)
				{
					this.SchmGroup_tToolbarsManager.Tools["Extend_Button"].SharedProps.Enabled = true;
					if (ob != DBNull.Value)
					{
						this.ultraTabPageControl2.Enabled = true;
					}
				}
				else if (ultraGrid == this.ultraGrid_Conv)
				{
					this.SchmConv_tToolbarsManager.Tools["Extend_Button"].SharedProps.Enabled = true;
				}
			}
			else
			{
				if (ultraGrid == ultraGrid_Schm)
				{
					this.SchmGroup_tToolbarsManager.Tools["Extend_Button"].SharedProps.Enabled = false;
					this.ultraTabPageControl2.Enabled = false;
				}
				else if (ultraGrid == ultraGrid_Conv)
				{
					this.SchmConv_tToolbarsManager.Tools["Extend_Button"].SharedProps.Enabled = false;
				}
			}
		}
	
	}

}