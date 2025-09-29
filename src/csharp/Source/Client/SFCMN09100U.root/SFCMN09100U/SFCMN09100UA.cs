# region ※using
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 番号管理設定入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 番号管理設定を行います。
	///					  IMasterMaintenanceArrayTypeを実装しています。</br>
	/// <br>Programmer	: 22033 三崎  貴史</br>
	/// <br>Date		: 2005.09.09</br>
	/// <br>Update Note	: 2006.09.01 22033 三崎 貴史</br>
	/// <br>			: ・セルの値をnullにして抜けた時のエラー対応（UltraGridバグ対応）</br>
	/// <br>			: ・GridのKeyPressイベントのロジック修正（制御キーショートカットが出来なかった為）</br>
	/// <br>Update Note	: 2006.09.07 22033 三崎 貴史</br>
	/// <br>			: ・保存チェックNGでWriteを行っていない時に、フレームグリッドと同期させているHashtableが書き換えられていた為に、</br>
	/// <br>			:   フレームグリッドのデータが更新されていたエラー修正</br>
	/// <br></br>
	/// <br>			: 2007.02.06 18322 T.Kimura MA.NS用に変更</br>
	/// <br>			:                           ・画面スキン変更対応</br>
    /// <br>Update Note : 2007.05.23 980023 飯谷 耕平</br>
    /// <br>            : ・拠点情報の取得先をリモートに修正</br>
    /// <br>Update Note : 2008.09.25 30413 犬飼</br>
    /// <br>            : ・PM.NS対応</br>
    /// </remarks>
	public class SFCMN09100UA : System.Windows.Forms.Form, IMasterMaintenanceArrayType
	{
		# region ※Private Members (Component)

		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
		private Infragistics.Win.UltraWinGrid.UltraGrid NoMngSet_uGrid;
		private Broadleaf.Library.Windows.Forms.TEdit SectionNm_tEdit;
        private Infragistics.Win.Misc.UltraButton InitSet_Button;
		private System.ComponentModel.IContainer components;

		# endregion

		# region ■Constructor
		/// <summary>
		/// 番号管理設定入力フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 番号管理設定入力フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public SFCMN09100UA()
		{
			InitializeComponent();
			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint					= false;
			this._canClose					= true;
			this._canNew					= false;
			this._canDelete					= false;
			this._mainGridTitle				= "拠点";
			this._detailsGridTitle			= "番号設定";
			this._defaultGridDisplayLayout	= MGridDisplayLayout.Vertical;

			// 企業コードを取得
			this._enterpriseCode			= LoginInfoAcquisition.EnterpriseCode;

			// 変数初期化
			this._targetTableName			= "";
			this._mainDataIndex				= -1;
			this._detailsDataIndex			= -1;
			this._noMngSetAcs				= new NoMngSetAcs();
            // ----- iitani c ----- start 2007.05.23
            //this._secInfoAcs = new SecInfoAcs();
            this._secInfoAcs = new SecInfoAcs(1);   // searchMode(0:ローカル 1:リモート)
            // ----- iitani c ----- end 2007.05.23
			this._secInfoSetTable			= new Hashtable();
			this._noTypeMngTable			= new Hashtable();
			this._noMngSetTable				= new Hashtable();
			//GridIndexバッファ（メインフレーム最小化対応）
			this._detailsIndexBuf			= -2;
			this._mainIndexBuf				= -2;
			// 編集Check用List
			this._noMngSetClone				= new ArrayList();
		}
		# endregion

		# region ※Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion

		#region ※Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN09100UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.NoMngSet_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.SectionNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.InitSet_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoMngSet_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(788, 416);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(664, 416);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 2;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(812, 8);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 160;
            this.Mode_Label.Text = "更新モード";
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 463);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(920, 23);
            this.ultraStatusBar1.TabIndex = 163;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // NoMngSet_uGrid
            // 
            this.NoMngSet_uGrid.Cursor = System.Windows.Forms.Cursors.Arrow;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance4.BackColor2 = System.Drawing.Color.White;
            this.NoMngSet_uGrid.DisplayLayout.Appearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.NoMngSet_uGrid.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            this.NoMngSet_uGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.NoMngSet_uGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.NoMngSet_uGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.NoMngSet_uGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.NoMngSet_uGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.NoMngSet_uGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NoMngSet_uGrid.DisplayLayout.Override.EditCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.FontData.BoldAsString = "False";
            appearance7.FontData.Name = "Arial";
            appearance7.FontData.SizeInPoints = 10F;
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.NoMngSet_uGrid.DisplayLayout.Override.HeaderAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.Lavender;
            this.NoMngSet_uGrid.DisplayLayout.Override.RowAlternateAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.NoMngSet_uGrid.DisplayLayout.Override.RowAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.ForeColor = System.Drawing.Color.White;
            this.NoMngSet_uGrid.DisplayLayout.Override.RowSelectorAppearance = appearance10;
            this.NoMngSet_uGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.NoMngSet_uGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.ForeColor = System.Drawing.Color.Black;
            this.NoMngSet_uGrid.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.NoMngSet_uGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.NoMngSet_uGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.NoMngSet_uGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.NoMngSet_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Vertical;
            this.NoMngSet_uGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            appearance12.BackColor = System.Drawing.Color.White;
            this.NoMngSet_uGrid.DisplayLayout.SplitterBarHorizontalAppearance = appearance12;
            this.NoMngSet_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NoMngSet_uGrid.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.NoMngSet_uGrid.Location = new System.Drawing.Point(12, 44);
            this.NoMngSet_uGrid.Name = "NoMngSet_uGrid";
            this.NoMngSet_uGrid.Size = new System.Drawing.Size(900, 358);
            this.NoMngSet_uGrid.TabIndex = 1;
            this.NoMngSet_uGrid.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.NoMngSet_uGrid_BeforeEnterEditMode);
            this.NoMngSet_uGrid.AfterExitEditMode += new System.EventHandler(this.NoMngSet_uGrid_AfterExitEditMode);
            this.NoMngSet_uGrid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.NoMngSet_uGrid_InitializeLayout);
            this.NoMngSet_uGrid.BeforeSelectChange += new Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventHandler(this.NoMngSet_uGrid_BeforeSelectChange);
            this.NoMngSet_uGrid.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.NoMngSet_uGrid_BeforeExitEditMode);
            this.NoMngSet_uGrid.AfterRowActivate += new System.EventHandler(this.NoMngSet_uGrid_AfterRowActivate);
            this.NoMngSet_uGrid.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.NoMngSet_uGrid_InitializeRow);
            this.NoMngSet_uGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoMngSet_uGrid_KeyPress);
            this.NoMngSet_uGrid.Leave += new System.EventHandler(this.NoMngSet_uGrid_Leave);
            this.NoMngSet_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoMngSet_uGrid_KeyDown);
            this.NoMngSet_uGrid.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.NoMngSet_uGrid_BeforeRowDeactivate);
            this.NoMngSet_uGrid.AfterCellActivate += new System.EventHandler(this.NoMngSet_uGrid_AfterCellActivate);
            // 
            // SectionNm_tEdit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SectionNm_tEdit.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionNm_tEdit.Appearance = appearance3;
            this.SectionNm_tEdit.AutoSelect = true;
            this.SectionNm_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SectionNm_tEdit.DataText = "";
            this.SectionNm_tEdit.Enabled = false;
            this.SectionNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, true, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionNm_tEdit.Location = new System.Drawing.Point(12, 8);
            this.SectionNm_tEdit.MaxLength = 6;
            this.SectionNm_tEdit.Name = "SectionNm_tEdit";
            this.SectionNm_tEdit.Size = new System.Drawing.Size(115, 24);
            this.SectionNm_tEdit.TabIndex = 0;
            // 
            // InitSet_Button
            // 
            this.InitSet_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.InitSet_Button.Location = new System.Drawing.Point(455, 416);
            this.InitSet_Button.Name = "InitSet_Button";
            this.InitSet_Button.Size = new System.Drawing.Size(161, 34);
            this.InitSet_Button.TabIndex = 2;
            this.InitSet_Button.Text = "初期値セット(&D)";
            this.InitSet_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.InitSet_Button.Click += new System.EventHandler(this.InitSet_Button_Click);
            // 
            // SFCMN09100UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(920, 486);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.SectionNm_tEdit);
            this.Controls.Add(this.NoMngSet_uGrid);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.InitSet_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Mode_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFCMN09100UA";
            this.Text = "番号管理設定";
            this.Load += new System.EventHandler(this.SFCMN09100UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFCMN09100UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFCMN09100UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoMngSet_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region ■IMasterMaintenanceArrayTypeメンバー

		# region ▼Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region ▼Properties
		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get
			{
				return this._canPrint;
			}
		}

		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
		public bool CanClose
		{
			get
			{
				return this._canClose;
			}
			set
			{
				this._canClose = value;
			}
		}

		/// <summary>新規登録可能設定プロパティ</summary>
		/// <value>新規登録が可能かどうかの設定を取得します。</value>
		public bool CanNew
		{
			get
			{
				return this._canNew;
			}
		}

		/// <summary>削除可能設定プロパティ</summary>
		/// <value>削除が可能かどうかの設定を取得します。</value>
		public bool CanDelete
		{
			get
			{
				return this._canDelete;
			}
		}

		/// <summary>グリッドのデフォルト表示位置プロパティ</summary>
		/// <value>グリッドのデフォルト表示位置を取得します。</value>
		public MGridDisplayLayout DefaultGridDisplayLayout
		{
			get
			{
				return this._defaultGridDisplayLayout;
			}
		}

		/// <summary>操作対象データテーブル名称プロパティ</summary>
		/// <value>捜査対象データのテーブル名称を取得または設定します。</value>
		public string TargetTableName
		{
			get
			{
				return this._targetTableName;
			}
			set
			{
				this._targetTableName = value;
			}
		}
		# endregion

		# region ▼Public Methods
		/// <summary>
		/// 論理削除データ抽出可能設定リスト取得処理
		/// </summary>
		/// <returns>論理削除データ抽出可能設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public bool[] GetCanLogicalDeleteDataExtractionList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= false;
			return blRet;
		}

		/// <summary>
		/// グリッドタイトルリスト取得処理
		/// </summary>
		/// <returns>グリッドタイトルリスト</returns>
		/// <remarks>
		/// <br>Note       : グリッドのタイトルを配列で取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public string[] GetGridTitleList()
		{
			string[] strRet	= new string[2];
			strRet[0]		= this._mainGridTitle;
			strRet[1]		= this._detailsGridTitle;
			return strRet;
		}

		/// <summary>
		/// グリッドアイコンリスト取得処理
		/// </summary>
		/// <returns>グリッドアイコンリスト</returns>
		/// <remarks>
		/// <br>Note       : グリッドのアイコンを配列で取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public Image[] GetGridIconList()
		{
			Image[] objRet	= new Image[2];
			objRet[0]		= null;
			objRet[1]		= null;
			return objRet;
		}

		/// <summary>
		/// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
		/// </summary>
		/// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
		/// <remarks>
		/// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public bool[] GetDefaultAutoFillToGridColumnList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= false;
			return blRet;
		}

		/// <summary>
		/// データテーブルの選択データインデックスリスト設定処理
		/// </summary>
		/// <param name="indexList">データテーブルの選択データインデックスリスト</param>
		/// <remarks>
		/// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public void SetDataIndexList(int[] indexList)
		{
			int[] intVal			= indexList;
			this._mainDataIndex		= intVal[0];
			this._detailsDataIndex	= intVal[1];
		}

		/// <summary>
		/// 新規ボタンの有効設定リスト取得処理
		/// </summary>
		/// <returns>新規ボタンの有効設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public bool[] GetNewButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= false;

			return blRet;
		}

		/// <summary>
		/// 修正ボタンの有効設定リスト取得処理
		/// </summary>
		/// <returns>修正ボタンの有効設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public bool[] GetModifyButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
            // 2008.09.23 30413 犬飼 拠点側で修正ボタンを有効 >>>>>>START
            //blRet[0]		= false;
            //blRet[1]		= true;
            blRet[0] = true;
            blRet[1] = false;
            // 2008.09.23 30413 犬飼 拠点側で修正ボタンを有効 <<<<<<END
            return blRet;
		}

		/// <summary>
		/// 削除ボタンの有効設定リスト取得処理
		/// </summary>
		/// <returns>削除ボタンの有効設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public bool[] GetDeleteButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= false;

			return blRet;
		}

		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet"></param>
		/// <param name="tableName"></param>
		/// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		/// 
		public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
		{
			bindDataSet = this.Bind_DataSet;

			string[] strRet	= new string[3];
			strRet[0]		= SECTION_TABLE;
			strRet[1]		= NOMNGSET_TABLE;
			// UI_Grid用
			strRet[2]		= UIGRID_TABLE;
			tableName		= strRet;
		}

		/// <summary>
		/// 拠点情報設定検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 先頭から拠点情報設定マスタを検索し、
		///					 抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			int index = 0;
			SecInfoSet dummy = new SecInfoSet();

			// 全社共通分セット
			SecInfoSetToDataSet(dummy, index);
			index++;

			foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
			{
				// 拠点Table展開処理
				SecInfoSetToDataSet(secInfoSet.Clone(), index);
				++index;
			}

			totalCount = 0;
			return status;
		}

		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			// 実装なし
			return 9;
		}

		/// <summary>
		/// 番号管理設定検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 先頭から番号管理設定マスタを検索し、
		///					 抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int DetailsDataSearch(ref int totalCount, int readCount)
		{
			int status = 0;
			int index = 0;
			string hashKey;
			ArrayList noMngSetList = null;
			ArrayList noTypeMngList = null;

			// メインフレーム側からのUI画面終了処理用Clear処理
			this._detailsIndexBuf = -2;

			// Bufferが無い場合のみリモーティング
			if ((this._noMngSetTable.Count == 0) &&
				(this._noTypeMngTable.Count == 0))
			{
				status = this._noMngSetAcs.Search(out noMngSetList, out noTypeMngList, this._enterpriseCode);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// 番号設定検索結果
						foreach (NoMngSet noMngSet in noMngSetList)
						{
							// HashKeyはPrimary Key
							hashKey = noMngSet.SectionCode.TrimEnd() + "_" + noMngSet.NoCode.ToString();

                            if (_noMngSetTable.ContainsKey(hashKey) != true)
                            {
							    // Bufferに格納
							    this._noMngSetTable.Add(hashKey, noMngSet);
                            }
						}

						// 番号タイプ管理検索結果
						foreach (NoTypeMng noTypeMng in noTypeMngList)
						{
							// HashKeyはPrimary Key
							hashKey = noTypeMng.NoCode.ToString();
							
                            if (_noTypeMngTable.ContainsKey(hashKey) != true)
                            {
                                // Bufferに格納
                                this._noTypeMngTable.Add(hashKey, noTypeMng);
                            }
						}

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						return status;
					}
					default:
					{
						TMsgDisp.Show(
							this,								  // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
							ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
							this.Text,							  // プログラム名称
							"DetailsDataSearch",				  // 処理名称
							TMsgDisp.OPE_GET,					  // オペレーション
							ERR_READ_MSG,						  // 表示するメッセージ 
							status,								  // ステータス値
							this._noMngSetAcs,					  // エラーが発生したオブジェクト
							MessageBoxButtons.OK,				  // 表示するボタン
							MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

						return status;
					}
				}
			}

			// 選択されている拠点情報を取得する
			string sectionCode = this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE].ToString();
			SecInfoSet secInfoSet = (SecInfoSet)this._secInfoSetTable[sectionCode];

			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows.Clear();

			SortedList sortList = new SortedList();

			// 各拠点毎
			if (secInfoSet != null)
			{
				// Sort
				foreach (NoMngSet noMngSet in this._noMngSetTable.Values)
				{
					if (noMngSet.SectionCode.TrimEnd() == secInfoSet.SectionCode.TrimEnd())
					{
						sortList.Add(noMngSet.NoCode, noMngSet);
					}
				}
			}
			// 全社共通
			else
			{
				// Sort
				foreach (NoMngSet noMngSet in this._noMngSetTable.Values)
				{
					if (noMngSet.SectionCode == DUMMYSECCD)
					{
						sortList.Add(noMngSet.NoCode, noMngSet);
					}
				}
			}

			foreach (NoMngSet noMngSet in sortList.Values)
			{
				// 番号設定Table展開処理
				NoMngSetToDataSet(noMngSet.Clone(), (NoTypeMng)this._noTypeMngTable[noMngSet.NoCode.ToString()], index);
				++index;
			}

			totalCount = 0;
			return status;
		}

		/// <summary>
		/// 明細ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int DetailsDataSearchNext(int readCount)
		{
			// 未実装
			return 9;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。(未実装)</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Delete()
		{
			// 未実装
			return 0;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。(未実装)</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Print()
		{
			// 印刷機能無しの為未実装
			return 0;
		}

		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public void GetAppearanceTable(out Hashtable[] appearanceTable)
		{
			// MainGrid
			Hashtable main = new Hashtable();
			main.Add(SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			main.Add(SECTIONNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

			// DetailsGrid
			Hashtable details = new Hashtable();
			details.Add(NOCODE_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleRight, "", Color.Black));
			details.Add(NONAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(NOITEMPATTERNCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(NOCHARCTERCOUNT_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			details.Add(CONSNOCHRCTERCOUNT_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			details.Add(NODISPPOSITIONDIVCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(NUMBERINGTYPE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(NUMBERINGAMBITDIVCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(NOPRESENTVAL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
			details.Add(SETTINGSTARTNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
			details.Add(SETTINGENDNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
			details.Add(NOINCDECWIDTH_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

			appearanceTable = new Hashtable[2];
			appearanceTable[0] = main;
			appearanceTable[1] = details;
		}
		# endregion

		# endregion

		# region ■Private Members
		private NoMngSetAcs _noMngSetAcs;
		private SecInfoAcs _secInfoAcs;
		private string _enterpriseCode;
		private Hashtable _secInfoSetTable;
		private Hashtable _noMngSetTable;
		private Hashtable _noTypeMngTable;
		//_GridIndexバッファ（メインフレーム最小化対応）
		private int _detailsIndexBuf;
		private int _mainIndexBuf;
		// GridFocus遷移用
		private int _leaveRowBuf;
		private int _leaveColBuf;
		// 編集Check用List
		private ArrayList _noMngSetClone;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		# region ▼IMasterMaintenanceArrayType用

		# region ●プロパティ用
		/// <summary>印刷ボタンVisible</summary>
		private bool _canPrint;
		/// <summary>閉じるボタンVisible</summary>
		private bool _canClose;
		/// <summary>新規ボタンVisible</summary>
		private bool _canNew;
		/// <summary>削除ボタンVisible</summary>
		private bool _canDelete;
		/// <summary>フレームMainGridタイトル</summary>
		private string _mainGridTitle;
		/// <summary>フレームDetailGridタイトル</summary>
		private string _detailsGridTitle;
		/// <summary>フレーム選択DataTable名</summary>
		private string _targetTableName;
		# endregion

		# region ●メソッド用
		/// <summary>フレームMainGrid_Index</summary>
		private int _mainDataIndex;
		/// <summary>フレームDetailGrid_Index</summary>
		private int _detailsDataIndex;
		/// <summary>フレームGrid_DisplayLayout</summary>
		private MGridDisplayLayout _defaultGridDisplayLayout;
		# endregion
	
		# endregion

		# endregion

		# region ■Consts
		// FrameのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string SECTIONCODE_TITLE		   = "拠点コード";
		private const string SECTIONNAME_TITLE		   = "拠点名";
		private const string SECTION_TABLE			   = "SECTION_TABLE";

		private const string NOCODE_TITLE			   = "番号コード";
		private const string NONAME_TITLE			   = "番号名";
		private const string NOITEMPATTERNCD_TITLE	   = "番号項目型";
		private const string NOCHARCTERCOUNT_TITLE	   = "番号桁数";	   
		private const string CONSNOCHRCTERCOUNT_TITLE  = "番号連番桁数";	   
		private const string NODISPPOSITIONDIVCD_TITLE = "番号表示位置区分";	   
		private const string NUMBERINGTYPE_TITLE       = "番号採番タイプ";	   
		private const string NUMBERINGAMBITDIVCD_TITLE = "番号採番範囲";	   
		private const string NOPRESENTVAL_TITLE		   = "番号現在値";	   
		private const string SETTINGSTARTNO_TITLE	   = "設定開始番号";	   
		private const string SETTINGENDNO_TITLE		   = "設定終了番号";	   
		private const string NOINCDECWIDTH_TITLE	   = "番号増減幅";	   
		private const string NOMNGSET_TABLE			   = "NOMNGSET_TABLE";
		private const string UIGRID_TABLE			   = "UIGRID_TABLE";

		// 編集モード（更新のみ）
		private const string UPDATE_MODE			   = "更新モード";
		// 企業通番は拠点コード"000000"
        // 2008.09.23 30413 犬飼 拠点コードは2桁に修正 >>>>>>START
        private const string DUMMYSECCD = "000000";
        //private const string DUMMYSECCD = "00";
        // 2008.09.23 30413 犬飼 拠点コードは2桁に修正 <<<<<<END
        // 番号現在値用"初期値"
		private const string NOPRESENTVAL_NULL		   = "初期値";
		// Message関連定義
		private const string ASSEMBLY_ID	= "SFCMN09100U";
		private const string ERR_READ_MSG	= "読み込みに失敗しました。";
		private const string ERR_DPR_MSG	= "このコードは既に使用されています。";
		private const string ERR_RDEL_MSG	= "削除に失敗しました。";
		private const string ERR_UPDT_MSG	= "登録に失敗しました。";
		private const string ERR_RVV_MSG	= "復活に失敗しました。";
		private const string ERR_800_MSG	= "既に他端末より更新されています";
		private const string ERR_801_MSG	= "既に他端末より削除されています";
		# endregion

		# region ※Main
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFCMN09100UA());
		}
		# endregion

		# region ■Private Methods
		/// <summary>
		/// 拠点情報マスタオブジェクトデータセットデータセット展開処理
		/// </summary>
		/// <param name="secInfoSet">拠点情報設定マスタオブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : 番号管理設定マスタデータクラスをデータセットに格納します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void SecInfoSetToDataSet(SecInfoSet secInfoSet, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[SECTION_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[SECTION_TABLE].NewRow();
				this.Bind_DataSet.Tables[SECTION_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[SECTION_TABLE].Rows.Count - 1;
			}

			// 全社共通分の時
			if (index == 0)
			{
				// DataTableにデータをセット
                // 2008.10.02 30413 犬飼 全社共通の拠点コードを設定 >>>>>>START
                this.Bind_DataSet.Tables[SECTION_TABLE].Rows[index][SECTIONCODE_TITLE] = "00";
                // 2008.10.02 30413 犬飼 全社共通の拠点コードを設定 <<<<<<END
                this.Bind_DataSet.Tables[SECTION_TABLE].Rows[index][SECTIONNAME_TITLE] = "全社共通";
			}
			else
			{
				// DataTableにデータをセット
				this.Bind_DataSet.Tables[SECTION_TABLE].Rows[index][SECTIONCODE_TITLE]	= secInfoSet.SectionCode;
				this.Bind_DataSet.Tables[SECTION_TABLE].Rows[index][SECTIONNAME_TITLE]	= secInfoSet.SectionGuideNm;
				// HashKeyは拠点コード
				string hashKey = secInfoSet.SectionCode.ToString();
				// 拠点Tableにデータをセット
				if (this._secInfoSetTable.ContainsKey(hashKey))
				{
					this._secInfoSetTable.Remove(hashKey);
				}
				this._secInfoSetTable.Add(hashKey, secInfoSet);
			}
		}

		/// <summary>
		/// 番号管理設定マスタオブジェクトデータセット展開処理
		/// </summary>
		/// <param name="noMngSet">番号管理設定マスタオブジェクト</param>
		/// <param name="noTypeMng">番号タイプ管理マスタオブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : 番号管理設定マスタデータクラスをデータセットに格納します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void NoMngSetToDataSet(NoMngSet noMngSet, NoTypeMng noTypeMng, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[NOMNGSET_TABLE].NewRow();
				this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows.Add( dataRow );

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows.Count - 1;
			}

			// DataTableにデータをセット
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NOCODE_TITLE]			    = noMngSet.NoCode;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NONAME_TITLE]				= noTypeMng.NoName;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NOITEMPATTERNCD_TITLE]		= noTypeMng.NoItemPatternCd;
			if (noMngSet.NoPresentVal == 0)
			{
				this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NOPRESENTVAL_TITLE]	= NOPRESENTVAL_NULL;
			}
			else
			{
				this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NOPRESENTVAL_TITLE]	= noMngSet.NoPresentVal;
			}
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NOCHARCTERCOUNT_TITLE]		= noTypeMng.NoCharcterCount;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][CONSNOCHRCTERCOUNT_TITLE]	= noTypeMng.ConsNoCharcterCount;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NODISPPOSITIONDIVCD_TITLE]	= noTypeMng.NoDispPositionDivCd;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NUMBERINGTYPE_TITLE]		= noTypeMng.NumberingTypeDivCd;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NUMBERINGAMBITDIVCD_TITLE]	= noTypeMng.NumberingAmbitDivCd;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][SETTINGSTARTNO_TITLE]		= noMngSet.SettingStartNo;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][SETTINGENDNO_TITLE]		= noMngSet.SettingEndNo;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NOINCDECWIDTH_TITLE]		= noMngSet.NoIncDecWidth;
		}

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			// 拠点レコード用テーブル
			DataTable secInfoSetTable = new DataTable(SECTION_TABLE);
			// Addを行う順番が、列の表示順位となります。
			secInfoSetTable.Columns.Add(SECTIONCODE_TITLE,	typeof(string));
			secInfoSetTable.Columns.Add(SECTIONNAME_TITLE,	typeof(string));

			this.Bind_DataSet.Tables.Add(secInfoSetTable);

			// コードレコード用テーブル
			DataTable noMngSetTable = new DataTable(NOMNGSET_TABLE);
			// Addを行う順番が、列の表示順位となります。
			noMngSetTable.Columns.Add(NOCODE_TITLE,			     typeof(int));
			noMngSetTable.Columns.Add(NONAME_TITLE,				 typeof(string));
			noMngSetTable.Columns.Add(NOITEMPATTERNCD_TITLE,	 typeof(string));
			noMngSetTable.Columns.Add(NOCHARCTERCOUNT_TITLE,	 typeof(int));
			noMngSetTable.Columns.Add(CONSNOCHRCTERCOUNT_TITLE,	 typeof(int));
			noMngSetTable.Columns.Add(NODISPPOSITIONDIVCD_TITLE, typeof(string));
			noMngSetTable.Columns.Add(NUMBERINGTYPE_TITLE,	 	 typeof(string));
			noMngSetTable.Columns.Add(NUMBERINGAMBITDIVCD_TITLE, typeof(string));
			noMngSetTable.Columns.Add(NOPRESENTVAL_TITLE,		 typeof(string));
			noMngSetTable.Columns.Add(SETTINGSTARTNO_TITLE,		 typeof(int));
			noMngSetTable.Columns.Add(SETTINGENDNO_TITLE,		 typeof(int));
			noMngSetTable.Columns.Add(NOINCDECWIDTH_TITLE,		 typeof(int));

			this.Bind_DataSet.Tables.Add(noMngSetTable);

			// UI_Grid用テーブル
			DataTable uiGridTable = new DataTable(UIGRID_TABLE);
			// Addを行う順番が、列の表示順位となります。
			uiGridTable.Columns.Add(NOCODE_TITLE,			    typeof(int));
			uiGridTable.Columns.Add(NONAME_TITLE,				typeof(string));
			uiGridTable.Columns.Add(NOPRESENTVAL_TITLE,			typeof(string));
			uiGridTable.Columns.Add(SETTINGSTARTNO_TITLE,		typeof(long));
			uiGridTable.Columns.Add(SETTINGENDNO_TITLE,			typeof(long));
			uiGridTable.Columns.Add(NOINCDECWIDTH_TITLE,		typeof(int));
			uiGridTable.Columns.Add(CONSNOCHRCTERCOUNT_TITLE, 	typeof(int));

			this.Bind_DataSet.Tables.Add(uiGridTable);
		}

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			// 未実装
			return;
		}

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void ScreenClear()
		{
			this.SectionNm_tEdit.Clear();
			this.Bind_DataSet.Tables[UIGRID_TABLE].Rows.Clear();
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			// 画面クリア
			ScreenClear();
			// 編集チェック用Bufferクリア
			this._noMngSetClone.Clear();

			// 拠点名称セット
			this.SectionNm_tEdit.Text = this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONNAME_TITLE].ToString();

			int index = 0;
			SortedList sortList = new SortedList();
			
			// 「全社共通」の場合
            // 2008.10.02 30413 犬飼 全社共通の拠点コードを設定 >>>>>>START
            //if (this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE].ToString() == "")
            if (this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE].ToString() == "00")
            // 2008.10.02 30413 犬飼 全社共通の拠点コードを設定 <<<<<<END
            {
				// Sort
				foreach(NoMngSet noMngSet in this._noMngSetTable.Values)
				{
					if (noMngSet.SectionCode == DUMMYSECCD)
					{
						sortList.Add(noMngSet.NoCode, noMngSet);
					}
				}
			}
				// 拠点毎の場合
			else
			{
				// Sort
				foreach(NoMngSet noMngSet in this._noMngSetTable.Values)
				{
					if (noMngSet.SectionCode.TrimEnd() == this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE].ToString().TrimEnd())
					{
						sortList.Add(noMngSet.NoCode, noMngSet);
					}
				}
			}

			foreach (NoMngSet noMngSet in sortList.Values)
			{
				// 番号管理設定画面展開処理
				NoMngSetToScreen(noMngSet, (NoTypeMng)this._noTypeMngTable[noMngSet.NoCode.ToString()], index);
				index++;
			}

			this.NoMngSet_uGrid.Focus();
			this.NoMngSet_uGrid.Rows[0].Activate();

			//_GridIndexバッファ保持
			this._detailsIndexBuf	= this._detailsDataIndex;
			this._mainIndexBuf		= this._mainDataIndex;
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{
			// 未実装
			return;
		}

		/// <summary>
		/// 番号管理設定マスタクラス画面展開処理
		/// </summary>
		/// <param name="noMngSet">番号管理設定マスタオブジェクト</param>
		/// <param name="noTypeMng">番号タイプ管理マスタオブジェクト</param>
		/// <param name="index">インデックス</param>
		/// <remarks>
		/// <br>Note       : 番号管理設定マスタオブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void NoMngSetToScreen(NoMngSet noMngSet, NoTypeMng noTypeMng, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[UIGRID_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[UIGRID_TABLE].NewRow();
				this.Bind_DataSet.Tables[UIGRID_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号とする
				index = this.Bind_DataSet.Tables[UIGRID_TABLE].Rows.Count - 1;
			}
			
			this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][NOCODE_TITLE]			 = noMngSet.NoCode;
			this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][NONAME_TITLE]			 = noTypeMng.NoName;
			// 「番号現在値」が０の場合
			if (noMngSet.NoPresentVal == 0)
			{
				this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][NOPRESENTVAL_TITLE]	 = NOPRESENTVAL_NULL;
			}
			else
			{
				this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][NOPRESENTVAL_TITLE]	 = noMngSet.NoPresentVal;
			}
			this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][SETTINGSTARTNO_TITLE]	 = noMngSet.SettingStartNo;
			this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][SETTINGENDNO_TITLE]		 = noMngSet.SettingEndNo;
			this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][NOINCDECWIDTH_TITLE]		 = noMngSet.NoIncDecWidth;
			this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][CONSNOCHRCTERCOUNT_TITLE] = noTypeMng.ConsNoCharcterCount;
			
			// データソースへ追加
			this.NoMngSet_uGrid.DataSource = this.Bind_DataSet.Tables[UIGRID_TABLE];

			// 最小化対応用Clone作成
			this._noMngSetClone.Add(noMngSet.Clone());
		}									

		/// <summary>
		/// Valueチェック処理（int）
		/// </summary>
		/// <param name="sorce">CellのValue</param>
		/// <returns>チェック後の値</returns>
		/// <remarks>
		/// <br>Note		: Cellの値をClassに入れる時のDBNULLチェックを行います。</br>
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.12.01</br>
		/// </remarks>
		private int ValueToInt(object sorce)
		{
			int dest = 0;
			try
			{
				dest = Convert.ToInt32(sorce);
			}
			catch
			{
				return dest;
			}
			return dest;
		}

		/// <summary>
		/// 画面情報番号管理設定マスタクラス格納処理
		/// </summary>
		/// <param name="noMngSet">番号管理設定マスタオブジェクト</param>
		/// <param name="index">インデックス</param>
		/// <returns>番号管理設定マスタオブジェクト</returns>
		/// <remarks>
		/// <br>Note       : 画面情報から番号管理設定マスタオブジェクトにデータを格納します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private NoMngSet DispToNoMngSet(NoMngSet noMngSet, int index)
		{
			for (int ix = 0; ix != this.NoMngSet_uGrid.Rows.Count; ix++)
			{
				if (noMngSet.NoCode == (int)this.NoMngSet_uGrid.Rows[ix].Cells[NOCODE_TITLE].Value)
				{
					if (this.NoMngSet_uGrid.Rows[ix].Cells[NOPRESENTVAL_TITLE].Value.ToString() == NOPRESENTVAL_NULL)
					{
						noMngSet.NoPresentVal = 0;
					}
					else
					{
						noMngSet.NoPresentVal	= TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[NOPRESENTVAL_TITLE].Value.ToString(), 0);
					}
					noMngSet.SettingStartNo = TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[SETTINGSTARTNO_TITLE].Value.ToString(), 0);
					noMngSet.SettingEndNo	= TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[SETTINGENDNO_TITLE].Value.ToString(), 0);
					noMngSet.NoIncDecWidth	= ValueToInt(this.NoMngSet_uGrid.Rows[ix].Cells[NOINCDECWIDTH_TITLE].Value);
				
					break;
				}
			}

			return noMngSet;
		}

		/// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="message">メッセージ</param>
		/// <param name="index">フォーカスを戻すRow</param>
		/// <param name="column">フォーカスを戻すcolumn</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private bool ScreenDataCheck(ref string message, out int index, out string column)
		{
			bool result = true;
			index = 0;
			column = null;

			for (int ix = 0 ; ix != this.NoMngSet_uGrid.Rows.Count ; ix++)
			{
                // 2009.02.23 30413 犬飼 UOE発注番号の6桁化により、エラーチェックを修正 >>>>>>START
                int noCode = TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[NOCODE_TITLE].Text, 0);
				
                // 番号現在値
                int noPreset = TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[NOPRESENTVAL_TITLE].Text, 0);
                if ((noCode == 3300) && (noPreset > 999999))
                {
                    message = "番号現在値が不正です。";
                    index = ix;
                    column = NOPRESENTVAL_TITLE;
                    return false;
                }

				// 「設定開始番号」が０の時
                int setting = TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[SETTINGSTARTNO_TITLE].Text, 0);
                //if (TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[SETTINGSTARTNO_TITLE].Text, 0) == 0)
                if (setting == 0)
				{
					message = "設定開始番号を設定して下さい。";
					index = ix;
					column = SETTINGSTARTNO_TITLE;
					return false;
				}
                else if ((noCode == 3300) && (setting > 999999))
                {
                    // UOE発注番号の場合
                    message = "設定開始番号が不正です。";
                    index = ix;
                    column = SETTINGSTARTNO_TITLE;
                    return false;
                }

				// 開始番号と終了番号の大小が逆の時
				int startNo	= TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[SETTINGSTARTNO_TITLE].Text, 0);
				int endNo	= TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[SETTINGENDNO_TITLE].Text, 0);
                if (startNo > endNo)
				{
					message = "開始・終了番号が不正です。";
					index = ix;
					column = SETTINGSTARTNO_TITLE;
					return false;
				}
                else if ((noCode == 3300) && (endNo > 999999))
                {
                    // UOE発注番号の場合
                    message = "設定終了番号が不正です。";
                    index = ix;
                    column = SETTINGENDNO_TITLE;
                    return false;
                }
                // 2009.02.23 30413 犬飼 UOE発注番号の6桁化により、エラーチェックを修正 <<<<<<END
                
				// 増減幅が開始番号と終了番号の差より大きい時
				int lengthNo = TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[NOINCDECWIDTH_TITLE].Text, 0);
				if (lengthNo > endNo - startNo)
				{
					message = "開始・終了番号・増減幅が不正です。";
					index = ix;
					column = NOINCDECWIDTH_TITLE;
					return false;
				}

				if (lengthNo == 0)
				{
					message = "番号増減幅を設定して下さい。";
					index = ix;
					column = NOINCDECWIDTH_TITLE;
					return false;
				}
			}

			return result;
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note　　　  : 番号管理設定マスタオブジェクトの保存処理を行います。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.09.09</br>
		/// </remarks>
		private bool SaveProc()
		{
			int index = 0;
			int status = 0;
			string message = null;	
			string column = null;	
			NoTypeMng noTypeMng = new NoTypeMng();
			ArrayList noMngSetList = new ArrayList();

			if (!ScreenDataCheck(ref message, out index, out column))
			{
				TMsgDisp.Show( 
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
					ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
					message,							// 表示するメッセージ 
					0,									// ステータス値
					MessageBoxButtons.OK);				// 表示するボタン

				this.NoMngSet_uGrid.Rows[index].Cells[column].Activate();
				return false;
			}

			// 変更があったレコードのみ保存にいく（エントリー側で先に更新された場合の排他エラーを減らす為）
			index = 0;
			// 「全社共通」の場合
            // 2008.10.02 30413 犬飼 全社共通の拠点コードを設定 >>>>>>START
            //if (this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE].ToString() == "")
            if (this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE].ToString() == "00")
            // 2008.10.02 30413 犬飼 全社共通の拠点コードを設定 <<<<<<END
            {
				foreach (NoMngSet noMngSetWk in _noMngSetTable.Values)
				{
					// 「全社共通」分
					if (noMngSetWk.SectionCode == DUMMYSECCD)
					{
						foreach (NoMngSet noMngSetWk2 in this._noMngSetClone) 
						{
							// 編集チェック用Bufferから同じものを検索
							if (noMngSetWk2.NoCode == noMngSetWk.NoCode)
							{
								NoMngSet noMngSetWkClone = (NoMngSet)noMngSetWk.Clone();

								// 変更されていた場合のみWrite用ListにSet
								if (!(noMngSetWk2.Equals(DispToNoMngSet(noMngSetWkClone, index))))
								{
									// 画面情報マスタオブジェクト格納処理→Write用ArrayListにAdd
									noMngSetList.Add(DispToNoMngSet(noMngSetWkClone, index));
									index++;
								}
							}
						}
					}
				}
			}
			// 拠点毎の場合
			else
			{
				foreach (NoMngSet noMngSetWk in _noMngSetTable.Values)
				{
					if (noMngSetWk.SectionCode.TrimEnd() == this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE].ToString().TrimEnd())
					{
						foreach (NoMngSet noMngSetWk2 in this._noMngSetClone) 
						{
							// 編集チェック用Bufferから同じものを検索
							if (noMngSetWk2.NoCode == noMngSetWk.NoCode)
							{
								NoMngSet noMngSetWkClone = (NoMngSet)noMngSetWk.Clone();
								
								// 変更されていた場合のみWrite用ListにSet
								if (!(noMngSetWk2.Equals(DispToNoMngSet(noMngSetWkClone, index))))
								{
									// 画面情報マスタオブジェクト格納処理→Write用ArrayListにAdd
									noMngSetList.Add(DispToNoMngSet(noMngSetWkClone, index));
									index++;
								}
							}
						}
					}
				}
			}

			// 変更があった場合のみリモート
			if (noMngSetList.Count != 0)
			{
				status = this._noMngSetAcs.Write(ref noMngSetList);
			}

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					foreach (NoMngSet noMngSet in noMngSetList)
					{
						noTypeMng = ((NoTypeMng)this._noTypeMngTable[noMngSet.NoCode.ToString()]).Clone();
						
						// 「番号コード」が同じRowのIndex取得
						for (int ix = 0; ix != this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows.Count; ix++)
						{
							if (noTypeMng.NoCode == (int)this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[ix][NOCODE_TITLE])
							{
								NoMngSetToDataSet(noMngSet, noTypeMng, ix);
							}
						}
			
						// HashKeyはPrimaryKey
						string hashKey = noMngSet.SectionCode.TrimEnd() + "_" + noMngSet.NoCode;
						// 番号設定Tableにデータをセット
						if (this._noMngSetTable.ContainsKey(hashKey))
						{
							this._noMngSetTable.Remove(hashKey);
						}
						this._noMngSetTable.Add(hashKey, noMngSet);
				
						// HashKeyはPrimaryKey
						hashKey = noTypeMng.NoCode.ToString();
						// 番号設定Tableにデータをセット
						if (this._noTypeMngTable.ContainsKey(hashKey))
						{
							this._noTypeMngTable.Remove(hashKey);
						}
						this._noTypeMngTable.Add(hashKey, noTypeMng);
					}

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					TMsgDisp.Show( 
						this,											// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,				// エラーレベル
						ASSEMBLY_ID,									// アセンブリＩＤまたはクラスＩＤ
						"番号の設定範囲が他の拠点と重複しています。",	// 表示するメッセージ 
						0,												// ステータス値
						MessageBoxButtons.OK);							// 表示するボタン

					this.NoMngSet_uGrid.Rows[0].Cells[2].Activate();
					return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 排他処理
					ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._noMngSetAcs);
					
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._detailsIndexBuf	= -2;
					this._mainIndexBuf		= -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					
					return false;
				}
				default:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"SaveProc",							// 処理名称
						TMsgDisp.OPE_UPDATE,				// オペレーション
						ERR_UPDT_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						this._noMngSetAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._detailsIndexBuf	= -2;
					this._mainIndexBuf		= -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					
					return false;
				}
			}
			
			return true;
		}

		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="operation">オペレーション</param>
		/// <param name="erObject">エラーオブジェクト</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新時の排他処理を行います。</br>
		/// <br>Programmer : 22033  三崎 貴史</br>
		/// <br>Date       : 2005.09.21</br>
		/// </remarks>
		private void ExclusiveTransaction(int status, string operation, object erObject)
		{				   
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"ExclusiveTransaction",				// 処理名称
						operation,							// オペレーション
						ERR_800_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						erObject,							// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"ExclusiveTransaction",				// 処理名称
						operation,							// オペレーション
						ERR_801_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						erObject,							// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					break;
				}
			}
		}

		/// <summary>
		/// 入力不可 セル外観取得処理
		/// </summary>
		/// <returns>外観情報</returns>
		/// <remarks>
		/// <br>Note       : 入力不可セルの外観情報を取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.12</br>
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
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.12</br>
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
		# endregion

		# region ■Control Events
		/// <summary>
		/// Form.Load イベント(SFCMN09100UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.09.09</br>
		/// </remarks>
		private void SFCMN09100UA_Load(object sender, System.EventArgs e)
		{
            // ↓ 20070206 18322 a MA.NS用に変更
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();
            
            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            // ↑ 20070206 18322 a

            // アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList = imageList24;
			this.Cancel_Button.ImageList = imageList24;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            // 2008.09.25 30413 犬飼 初期値セットボタン追加 >>>>>>START
            this.InitSet_Button.ImageList = imageList24;
            this.InitSet_Button.Appearance.Image = Size24_Index.MODIFY;
            // 2008.09.25 30413 犬飼 初期値セットボタン追加 <<<<<<END
            
			// 画面初期設定処理
			ScreenInitialSetting();
		}

		/// <summary>
		/// Form.Closing イベント(SFCMN09100UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note　　　  : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.09.09</br>
		/// </remarks>
		private void SFCMN09100UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._detailsIndexBuf	= -2;
			this._mainIndexBuf		= -2;

			// フォームの「×」をクリックされた場合の対応です。
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}	
		}

		/// <summary>
		/// Control.VisibleChanged イベント(SFCMN09100UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.09.09</br>
		/// </remarks>
		private void SFCMN09100UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				this.Owner.Activate();
				return;
			}
			
			if ((this._detailsIndexBuf == this._detailsDataIndex) &&
				(this._mainIndexBuf == this._mainDataIndex))
			{
				return;
			}

			Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.09.09</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// 登録処理
			if (SaveProc() == false)
			{
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;
			this._detailsIndexBuf = -2;
			this._mainIndexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.09.09</br>
		/// </remarks>		
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// ショートカットーKey対応
			this.Cancel_Button.Focus();
			
			// 変更フラグ
			bool check = true;
			NoMngSet compareNoMngSet = new NoMngSet();
			NoMngSet cloneNoMngSet = new NoMngSet();
			
			for (int ix = 0; ix != this._noMngSetClone.Count; ix++)
			{
				cloneNoMngSet = (NoMngSet)this._noMngSetClone[ix];
				compareNoMngSet = cloneNoMngSet.Clone();
				DispToNoMngSet(compareNoMngSet, ix);
				if (!(cloneNoMngSet.Equals(compareNoMngSet)))
				{
					check = false;
					break;
				}
			}

			if (!check)
			{
				// 画面情報が変更されていた場合は、保存確認メッセージを表示する
				DialogResult res = TMsgDisp.Show( 
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
					ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
					"",									// 表示するメッセージ 
					0,									// ステータス値
					MessageBoxButtons.YesNoCancel);		// 表示するボタン
				
				switch (res)
				{
					case DialogResult.Yes:
					{
						if (!SaveProc())
						{
							return;
						}
						if (UnDisplaying != null)
						{
							this.DialogResult = DialogResult.OK;
						}
						break;
					}
					case DialogResult.No:
					{
						if (UnDisplaying != null)
						{
							this.DialogResult = DialogResult.Cancel;
						}
						break;
					}
					default:
					{
						this.Cancel_Button.Focus();
						return;
					}
				}
			}

			MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
			UnDisplaying(this, me);

			this.DialogResult = DialogResult.Cancel;

			this._detailsIndexBuf = -2;
			this._mainIndexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}
		
		/// <summary>
		/// Timer.Tick イベント イベント(Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
		///					  この処理は、システムが提供するスレッド プール
		///					  スレッドで実行されます。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.09.09</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();		
		}

		/// <summary>
		/// リターンキー移動イベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: リターンキー押下時の制御を行います。</br>
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			// GridにControlがある時のReturn/Tabの動き設定
			if (e.PrevCtrl == this.NoMngSet_uGrid)
			{
				// リターンキーの時
				if ((e.Key == Keys.Return) ||
					(e.Key == Keys.Tab))
				{
					e.NextCtrl = null;

					if (this.NoMngSet_uGrid.ActiveCell != null)
					{
						// 最終セルの時
						if ((this.NoMngSet_uGrid.ActiveCell.Row.Index == this.NoMngSet_uGrid.Rows.Count - 1) &&
							(this.NoMngSet_uGrid.ActiveCell.Column.Index == this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOINCDECWIDTH_TITLE].Index))
						{
							// 保存ボタンにフォーカス遷移
							e.NextCtrl = this.Ok_Button;
						}
						else
						{
							// 「番号増減幅」の場合は次のRowに
							if (this.NoMngSet_uGrid.ActiveCell.Column.Index == this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOINCDECWIDTH_TITLE].Index)
							{
								// 次のRowにフォーカス遷移
								this.NoMngSet_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);
								this.NoMngSet_uGrid.PerformAction(UltraGridAction.EnterEditMode);

							}
							else
							{
								// 次のCellにフォーカス遷移
								this.NoMngSet_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
							}
						}
					}
				}
			}
			else if ((e.PrevCtrl == this.Cancel_Button) ||
				(e.PrevCtrl == this.Ok_Button))
			{
				if (e.NextCtrl == this.NoMngSet_uGrid)
				{
					e.NextCtrl = null;
					switch (e.Key)
					{
						case Keys.Return:
						{
							this.NoMngSet_uGrid.Rows[0].Cells[NOPRESENTVAL_TITLE].Activate();
							break;
						}
						case Keys.Tab:
						{
							this.NoMngSet_uGrid.Rows[0].Cells[NOPRESENTVAL_TITLE].Activate();
							break;
						}
						case Keys.Up:
						{
							this.NoMngSet_uGrid.Rows[this._leaveRowBuf].Cells[this._leaveColBuf].Activate();
							break;
						}
					}
				}
			}
		}
		# endregion

		# region ■Grid Control
		/// <summary>
		/// UltraGrid.KeyDownイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: グリッド上で何かキーを押下した時の制御を行います。</br>
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// Grid編集中の時
			if ((this.NoMngSet_uGrid.ActiveCell != null) &&
				(this.NoMngSet_uGrid.ActiveCell.IsInEditMode == true))
			{
				switch (e.KeyCode)
				{
					case Keys.Up:
					{
						if (this.NoMngSet_uGrid.ActiveCell.Row.Index == 0)
						{
							break;
						}
						else
						{
							this.NoMngSet_uGrid.PerformAction(UltraGridAction.AboveCell);
							e.Handled = true;
						}
						break;
					}

					case Keys.Down:
					{
						if (this.NoMngSet_uGrid.ActiveCell.Row.Index == (this.NoMngSet_uGrid.Rows.Count - 1))
						{
							this.Ok_Button.Focus();
						}
						else
						{
							this.NoMngSet_uGrid.PerformAction(UltraGridAction.BelowCell);
							e.Handled = true;
						}
						break;
					}
					case Keys.Right:
					{
						if ((this.NoMngSet_uGrid.ActiveCell.SelLength == 0) &&
							(this.NoMngSet_uGrid.ActiveCell.SelStart == this.NoMngSet_uGrid.ActiveCell.Text.Length))
						{
							// 「番号増減幅」の場合は次のRowに
							if (this.NoMngSet_uGrid.ActiveCell.Column.Index == this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOINCDECWIDTH_TITLE].Index)
							{
								this.NoMngSet_uGrid.PerformAction(UltraGridAction.NextRow);
								this.NoMngSet_uGrid.PerformAction(UltraGridAction.EnterEditMode);
							}
							else
							{
								this.NoMngSet_uGrid.PerformAction(UltraGridAction.NextCell);
							}
							e.Handled = true;
						}	
						break;
					}
					case Keys.Left:
					{
						// ２行目以降で「番号現在値」の時
						if ((this.NoMngSet_uGrid.ActiveCell.SelLength == 0) &&
							(this.NoMngSet_uGrid.ActiveCell.SelStart == 0) &&
							(this.NoMngSet_uGrid.ActiveCell.Row.Index != 0) &&
							(this.NoMngSet_uGrid.ActiveCell.Column.Index == this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOPRESENTVAL_TITLE].Index))
						{
							// 上の行の「番号増減幅」に
							this.NoMngSet_uGrid.Rows[this.NoMngSet_uGrid.ActiveCell.Row.Index - 1].Cells[NOINCDECWIDTH_TITLE].Activate();
							e.Handled = true;
						}
						else if ((this.NoMngSet_uGrid.ActiveCell.SelLength == 0) &&
							(this.NoMngSet_uGrid.ActiveCell.SelStart == 0))
						{
							// 手前のCellに
							this.NoMngSet_uGrid.PerformAction(UltraGridAction.PrevCell);
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
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_AfterRowActivate(object sender, System.EventArgs e)
		{
			// RowがActive化されていて、CellがActive化されていない場合、「番号現在値」をActiveate
			if (this.NoMngSet_uGrid.ActiveRow == null) 
			{
				return;
			}

			if (this.NoMngSet_uGrid.ActiveCell == null)
			{
				this.NoMngSet_uGrid.ActiveRow.Cells[NOPRESENTVAL_TITLE].Activate();
			}
		}

		/// <summary>
		/// UltraGrid.BeforeRowDeactivateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>						
		/// <br>Note		: 行が非アクティブ化される直前に発生します。</br>
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_BeforeRowDeactivate(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// アクティブだった行のセルの外観を解除
			foreach (UltraGridCell wkCell in this.NoMngSet_uGrid.ActiveRow.Cells)
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
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_AfterCellActivate(object sender, System.EventArgs e)
		{
			// 「番号名称」Cellの時
			if (this.NoMngSet_uGrid.ActiveCell == this.NoMngSet_uGrid.ActiveRow.Cells[NONAME_TITLE])
			{
				// ActiveCellを「番号名称」へセットする
				this.NoMngSet_uGrid.ActiveCell = this.NoMngSet_uGrid.ActiveRow.Cells[NOPRESENTVAL_TITLE];
			}

			this.NoMngSet_uGrid.PerformAction(UltraGridAction.EnterEditMode);
			
			// アクティブ行の全てのセルにおいて色分けする(入力可/不可にて)
			foreach (UltraGridCell wkCell in this.NoMngSet_uGrid.ActiveRow.Cells)
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
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_BeforeSelectChange(object sender, Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs e)
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
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_Leave(object sender, System.EventArgs e)
		{
			if (this.NoMngSet_uGrid.ActiveCell != null)
			{
				// アクティブだった行のセルの外観を解除
				foreach (UltraGridCell wkCell in this.NoMngSet_uGrid.ActiveRow.Cells)
				{
					wkCell.Appearance = null;
				}
				// アクティブな行、列のインデックスをバッファに確保
				this._leaveRowBuf = this.NoMngSet_uGrid.ActiveRow.Index;
				this._leaveColBuf = this.NoMngSet_uGrid.ActiveCell.Column.Index;
				this.NoMngSet_uGrid.PerformAction(UltraGridAction.DeactivateCell);
			}
		}

		/// <summary>
		/// UltraGrid.InitializeRowイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 行が初期化された時に発生します。</br>
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
		{
			// 2008.09.25 30413 犬飼 番号現在値、設定開始番号、設定終了番号の桁数を9桁固定 >>>>>>START
            // 「連番桁数」に合わせて入力桁数を設定
            //e.Row.Cells[NOPRESENTVAL_TITLE].Column.MaxLength   = TStrConv.StrToIntDef(e.Row.Cells[CONSNOCHRCTERCOUNT_TITLE].Value.ToString(), 0);
            //e.Row.Cells[SETTINGSTARTNO_TITLE].Column.MaxLength = TStrConv.StrToIntDef(e.Row.Cells[CONSNOCHRCTERCOUNT_TITLE].Value.ToString(), 0);
            //e.Row.Cells[SETTINGENDNO_TITLE].Column.MaxLength   = TStrConv.StrToIntDef(e.Row.Cells[CONSNOCHRCTERCOUNT_TITLE].Value.ToString(), 0);
            e.Row.Cells[NOPRESENTVAL_TITLE].Column.MaxLength = 9;       // 番号現在値
            e.Row.Cells[SETTINGSTARTNO_TITLE].Column.MaxLength = 9;     // 設定開始番号
            e.Row.Cells[SETTINGENDNO_TITLE].Column.MaxLength = 9;       // 設定終了番号
            // 2008.09.25 30413 犬飼 番号現在値、設定開始番号、設定終了番号の桁数を9桁固定 <<<<<<END
        }

		/// <summary>
		/// UltraGrid.InitializeLayoutイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: データソースからコントロールにデータがロードされるときなど、
		///					  表示レイアウトが初期化されるときに発生します。 </br>
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			// 「番号名称」は編集不可（固定項目として設定）
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NONAME_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			// 非表示項目
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOCODE_TITLE].Hidden = true;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[CONSNOCHRCTERCOUNT_TITLE].Hidden = true;

			// 数値項目は文字位置を右寄せにする
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOCODE_TITLE].CellAppearance.TextHAlign = HAlign.Right;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOPRESENTVAL_TITLE].CellAppearance.TextHAlign = HAlign.Right;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[SETTINGSTARTNO_TITLE].CellAppearance.TextHAlign = HAlign.Right;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[SETTINGENDNO_TITLE].CellAppearance.TextHAlign = HAlign.Right;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOINCDECWIDTH_TITLE].CellAppearance.TextHAlign = HAlign.Right;

			// セルの入力桁数設定する
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOINCDECWIDTH_TITLE].MaxLength = 2;

			// CellのSizeを設定
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NONAME_TITLE].Width		   = 460;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOPRESENTVAL_TITLE].Width   = 100;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[SETTINGSTARTNO_TITLE].Width = 100;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[SETTINGENDNO_TITLE].Width   = 100;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOINCDECWIDTH_TITLE].Width  = 100;
		}

		/// <summary>
		/// UltraGrid.AfterExitEditModeイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: セルが編集モードを終了した後に発生します。</br>
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.09.13</br>
		/// </remarks>
		private void NoMngSet_uGrid_AfterExitEditMode(object sender, System.EventArgs e)
		{
			// 「番号現在値」の場合
			if (this.NoMngSet_uGrid.ActiveCell.Column == this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOPRESENTVAL_TITLE])
			{
				// nullか０の場合
				if ((this.NoMngSet_uGrid.ActiveCell.Text == "") ||
					(this.NoMngSet_uGrid.ActiveCell.Text == "0"))
				{
					this.NoMngSet_uGrid.ActiveCell.Value = NOPRESENTVAL_NULL;
				}
			}
		}
		
		/// <summary>
		/// UltraGrid.KeyPressイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: グリッド上で何かキーを押し終えた時の制御を行います。</br>
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.09.13</br>
		/// </remarks>
		private void NoMngSet_uGrid_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// 制御キーが押された？
			if (Char.IsControl(e.KeyChar))
			{
				return;
			}

			// 数値以外は、ＮＧ
            if (!Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            // 2009.02.23 30413 犬飼 UOE発注番号の6桁化による入力制限 >>>>>>START
            else
            {
                UltraGridCell cell = this.NoMngSet_uGrid.ActiveCell;
                if ((int)cell.Row.Cells[NOCODE_TITLE].Value == 3300)
                {
                    switch (cell.Column.Key)
                    {
                        case NOPRESENTVAL_TITLE:
                        case SETTINGSTARTNO_TITLE:
                        case SETTINGENDNO_TITLE:
                            {
                                if ((cell.SelText.Length == 0) && (cell.Text.Length >= 6))
                                {
                                    e.Handled = true;
                                }
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
            // 2009.02.23 30413 犬飼 UOE発注番号の6桁化による入力制限 >>>>>>START
        }

		/// <summary>
		/// UltraGrid.BeforeEnterEditModeイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: グリッド上でエディットモード開始直前での制御を行います。</br>
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.09.13</br>
		/// </remarks>
		private void NoMngSet_uGrid_BeforeEnterEditMode(object sender, System.ComponentModel.CancelEventArgs e)
		{
			int rowIndex = this.NoMngSet_uGrid.ActiveCell.Row.Index;

			// アクティブセルが「番号現在値」の場合
			if ((this.NoMngSet_uGrid.ActiveCell == this.NoMngSet_uGrid.Rows[rowIndex].Cells[NOPRESENTVAL_TITLE]) &&
				(this.NoMngSet_uGrid.ActiveCell.Text.Trim() == NOPRESENTVAL_NULL))
			{
				this.NoMngSet_uGrid.Rows[rowIndex].Cells[NOPRESENTVAL_TITLE].Value = 0;
			}
		}

		/// <summary>
		/// グリッド BeforeExitEditModeイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>セルの値をnullにして抜けた時のエラー対応用</remarks>
		private void NoMngSet_uGrid_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
		{
			if (((UltraGrid)sender).ActiveCell.Text == "")
			{
				((UltraGrid)sender).ActiveCell.Value = 0;
			}
		}
		#endregion

        /// <summary>
        /// ボタン InitSet_Button_Clickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 初期値ボタンのクリックイベントの制御を行います</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.09.25</br>
		/// </remarks>
        private void InitSet_Button_Click(object sender, EventArgs e)
        {
            // グリッドの行数を取得
            int maxRowCnt = this.NoMngSet_uGrid.Rows.Count;

            for (int i = 0; i < maxRowCnt; i++)
            {
                // 番号現在値のチェック
                if ((this.NoMngSet_uGrid.Rows[i].Cells[NOPRESENTVAL_TITLE].Text.Trim() == NOPRESENTVAL_NULL)
                    || (this.NoMngSet_uGrid.Rows[i].Cells[NOPRESENTVAL_TITLE].Text.Trim() == "")
                    || (this.NoMngSet_uGrid.Rows[i].Cells[NOPRESENTVAL_TITLE].Text.Trim() == "0"))
                {
                    // 2009.02.23 30413 犬飼 UOE発注番号の6桁化による初期値設定を修正 >>>>>>START
                    // 番号現在値が初期値
                    // 設定開始番号、設定終了番号、番号増減幅をチェック
                    if ((this.NoMngSet_uGrid.Rows[i].Cells[SETTINGSTARTNO_TITLE].Text.Trim() == "0")
                        && (this.NoMngSet_uGrid.Rows[i].Cells[SETTINGENDNO_TITLE].Text.Trim() == "0")
                        && (this.NoMngSet_uGrid.Rows[i].Cells[NOINCDECWIDTH_TITLE].Text.Trim() == "0"))
                    {
                        // 設定開始番号、設定終了番号、番号増減幅が全てゼロ
                        this.NoMngSet_uGrid.Rows[i].Cells[SETTINGSTARTNO_TITLE].Value = 1;          // 設定開始番号
                        this.NoMngSet_uGrid.Rows[i].Cells[SETTINGENDNO_TITLE].Value = 999999999;    // 設定終了番号
                        if ((int)this.NoMngSet_uGrid.Rows[i].Cells[NOCODE_TITLE].Value != 3300)
                        {
                            // UOE発注番号以外
                            this.NoMngSet_uGrid.Rows[i].Cells[SETTINGENDNO_TITLE].Value = 999999999;    // 設定終了番号
                        }
                        else
                        {
                            // UOE発注番号
                            this.NoMngSet_uGrid.Rows[i].Cells[SETTINGENDNO_TITLE].Value = 999999;       // 設定終了番号
                        }
                        this.NoMngSet_uGrid.Rows[i].Cells[NOINCDECWIDTH_TITLE].Value = 1;           // 番号増減幅
                    }
                    // 2009.02.23 30413 犬飼 UOE発注番号の6桁化による初期値設定を修正 <<<<<<END
                }
            }
            
        }
    }
}
