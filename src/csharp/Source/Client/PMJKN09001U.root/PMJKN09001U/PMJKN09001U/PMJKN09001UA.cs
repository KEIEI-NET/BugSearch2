//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索型式マスタフォームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10602352-00 作成担当 : 肖緒徳
// 作 成 日  2010/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
// 作 成 日  2010/05/16  修正内容 : #7517 諸元情報の取得、#7604 各種仕様変更／障害対応、#7635 各種仕様変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
// 作 成 日  2010/05/20  修正内容 : 更新モードの初期化、生産車台番号チックの修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
// 作 成 日  2010/06/22  修正内容 : #10097 自由検索型式マスタ　各種仕様変更／障害対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Globarization;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 自由検索型式マスタフォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自由検索型式マスタのフォームクラスです。</br>
	/// <br>Programmer : 肖緒徳</br>
	/// <br>Date       : 2010.04.26</br>
	/// <br>UpdateNote : 2010/05/16 姜凱 redmine#7517、7604、7635の対応</br>
	/// <br></br>
	public partial class PMJKN09001UA : Form
	{

		# region Private Members
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		// 現在のコントロール
		private Control _prevControl = null;
		// 諸元情報グリッド
		private DataSet _carSpecDataSet;
		//グレードリスト
		private ValueList _modelGradeValueList;
		//ボディリスト
		private ValueList _bodyNameValueList;
		//ドアリスト
		private ValueList _doorCountValueList;
		//エンジンリスト
		private ValueList _engineModelValueList;
		//排気量リスト
		private ValueList _engineDisplaceValueList;
		//E区分リスト
		private ValueList _eDivValueList;
		//ミッションリスト
		private ValueList _transmissionValueList;
		//駆動形式リスト
		private ValueList _wheelDriveMethodValueList;
		//シフトリスト
		private ValueList _shiftValueList;
		// 売上入力アクセスクラス
		private PMKEN01010E.CarModelInfoDataTable _carModelInfoDataTable;
		// 自由検索型式マスタテーブルアクセスクラス
		private FreeSearchModelAcs _freeSearchModelAcs;
		// 自由検索型式固定番号
		private string _freeSrchMdlFxdNo;
		// 更新日時
		private DateTime _updateTime;
		// ImageList
		private ImageList _imageList16 = null;
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin;
		// 排ガス記号
		private string _exhaustGasSign;
		// シリーズ型式
		private string _seriesModel;
		// 型式（類別記号）
		private string _categorySignModel;
		// ----- ADD 2010/05/16 ------------------->>>>>
		// 画面項目再設定フラグ
		private bool _valueChageFlg = false;
		// 新規モード画面項目再設定フラグ
		private bool _clearChangeFlg = false;
		// ----- ADD 2010/05/16 -------------------<<<<<
		// ----- ADD 2010/05/20 ------------------->>>>>
		// 更新モード画面項目再設定フラグ
		private bool _clearUpdateFlg = false;
		// ----- ADD 2010/05/20 -------------------<<<<<
		# endregion


		# region Private Fields
		// ===================================================================================== //
		// プライベート定数
		// ===================================================================================== //
		// 企業コード
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		// 拠点コード
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
		// クラス名
		private string ct_PRINTNAME = "自由検索型式マスタ";
		// ドアフォーマット
		private const string FORMAT_DOORNO = "nn";
		// 未登録
		private const string un_INSERT = "未登録";
		# endregion


		# region Constructors
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		/// <summary>
		/// 自由検索型式マスタフォームクラス デフォルトコンストラクタ
		/// </summary>
		public PMJKN09001UA()
		{
			InitializeComponent();

			_carSpecDataSet = new DataSet();

			_carModelInfoDataTable = new PMKEN01010E.CarModelInfoDataTable();
			_controlScreenSkin = new ControlScreenSkin();

			this.ClearValueList();

			this._imageList16 = IconResourceManagement.ImageList16;

			this._freeSearchModelAcs = new FreeSearchModelAcs();
			this._freeSrchMdlFxdNo = string.Empty;
			this._updateTime = new DateTime();
		}
		#endregion


		# region  フォームロード
		/// <summary>
		/// 画面の処理化処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>   
		/// <param name="e">イベントパラメータクラス</param>
		/// <remarks>  
		/// <br>Note  : 画面の処理化を行う。</br>
		/// <br>Programmer : 肖緒徳</br> 
		/// <br>Date  : 2010/04/26</br>
		/// </remarks>
		private void PMJKN09000UA_Load(object sender, EventArgs e)
		{
			// 画面イメージ統一 
			// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.LoadSkin();

			// 画面スキン変更
			this._controlScreenSkin.SettingScreenSkin(this);

			// 諸元情報データソース追加
			PMJKN09001UB.DataSetColumnConstruction(ref this._carSpecDataSet);
			DataRow row = this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].NewRow();
			this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].Rows.Add(row);
			this.ultraGrid_CarSpec.DataSource = this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].DefaultView;

			//ツールバー初期設定処理
			this.ToolBarInitilSetting();

			// ボタン初期設定処理
			this.ButtonInitialSetting();

			// 型式グリッド表示設定処理
			this.SettingCarSpecGrid();

			// モード選択
			this.tComboEditor_Model.SelectedIndex = 0;
			this.tComboEditor_Model.Focus();
			this.Mode_Label.Text = "新規モード";

			// ボタンツール有効無効設定処理
			this.SettingToolBarButtonEnabled();

			// ----- ADD 2010/05/16 ------------------->>>>>
			// ボタン有効無効設定処理
			this.InitialSettingButtonEnabled();
			this._clearChangeFlg = false;
			// ----- ADD 2010/05/16 -------------------<<<<<
			this._clearUpdateFlg = false;　// ADD 2010/05/20

			// 画面項目の設定
			this.tNedit_ModelDesignationNo.Clear();
			this.tNedit_CategoryNo.Clear();

			this.tEdit_FullModel.Clear();

			this.tDateEdit_StartEntryYearDate.Clear();
			this.tDateEdit_StartEntryMonthDate.Clear();
			this.tDateEdit_EndEntryYearDate.Clear();
			this.tDateEdit_EndEntryMonthDate.Clear();

			this.tEdit_StartProduceFrameNo.Clear();
			this.tEdit_EndProduceFrameNo.Clear();

		}
		# endregion


		# region Private Methods
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //

		/// <summary>
		/// ValueListのクリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ValueListのクリア処理を行います。</br>
		/// <br>Programmer : 肖緒徳</br> 
		/// <br>Date  : 2010/04/26</br>
		/// </remarks>
		private void ClearValueList()
		{
			this._modelGradeValueList = new ValueList();
			this._modelGradeValueList.ValueListItems.Clear();
			this._modelGradeValueList.ValueListItems.Add("", "");
			this._modelGradeValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._bodyNameValueList = new ValueList();
			this._bodyNameValueList.ValueListItems.Clear();
			this._bodyNameValueList.ValueListItems.Add("", "");
			this._bodyNameValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._doorCountValueList = new ValueList();
			this._doorCountValueList.ValueListItems.Clear();
			this._doorCountValueList.ValueListItems.Add("", "");
			this._doorCountValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._engineModelValueList = new ValueList();
			this._engineModelValueList.ValueListItems.Clear();
			this._engineModelValueList.ValueListItems.Add("", "");
			this._engineModelValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._engineDisplaceValueList = new ValueList();
			this._engineDisplaceValueList.ValueListItems.Clear();
			this._engineDisplaceValueList.ValueListItems.Add("", "");
			this._engineDisplaceValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._eDivValueList = new ValueList();
			this._eDivValueList.ValueListItems.Clear();
			this._eDivValueList.ValueListItems.Add("", "");
			this._eDivValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._transmissionValueList = new ValueList();
			this._transmissionValueList.ValueListItems.Clear();
			this._transmissionValueList.ValueListItems.Add("", "");
			this._transmissionValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._wheelDriveMethodValueList = new ValueList();
			this._wheelDriveMethodValueList.ValueListItems.Clear();
			this._wheelDriveMethodValueList.ValueListItems.Add("", "");
			this._wheelDriveMethodValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._shiftValueList = new ValueList();
			this._shiftValueList.ValueListItems.Clear();
			this._shiftValueList.ValueListItems.Add("", "");
			this._shiftValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			// --- ADD m.suzuki 2010/06/22 ---------->>>>>
			// ソート指定
			this._modelGradeValueList.SortStyle = ValueListSortStyle.Ascending;
			this._bodyNameValueList.SortStyle = ValueListSortStyle.Ascending;
			this._doorCountValueList.SortStyle = ValueListSortStyle.Ascending;
			this._engineModelValueList.SortStyle = ValueListSortStyle.Ascending;
			this._engineDisplaceValueList.SortStyle = ValueListSortStyle.Ascending;
			this._eDivValueList.SortStyle = ValueListSortStyle.Ascending;
			this._transmissionValueList.SortStyle = ValueListSortStyle.Ascending;
			this._wheelDriveMethodValueList.SortStyle = ValueListSortStyle.Ascending;
			this._shiftValueList.SortStyle = ValueListSortStyle.Ascending;
			// --- ADD m.suzuki 2010/06/22 ----------<<<<<
		}

		/// <summary>
		/// 型式グリッド表示設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金グリッドの表示設定を行います。</br>
		/// <br>Programmer : 肖緒徳</br> 
		/// <br>Date  : 2010/04/26</br>
		/// </remarks>
		private void SettingCarSpecGrid()
		{
			// --- 型式一覧バンド --- //
			ColumnsCollection pareColumns = ultraGrid_CarSpec.DisplayLayout.Bands[PMJKN09001UB.TBL_CARSPECVIEW].Columns;
			//グレード
			pareColumns[PMJKN09001UB.COL_MODELGRADENM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_MODELGRADENM_TITLE].ValueList = this._modelGradeValueList;
			// ----- UPD 2010/05/16 ------------------->>>>>
			//pareColumns[PMJKN09001UB.COL_MODELGRADENM_TITLE].Width = 130;
			pareColumns[PMJKN09001UB.COL_MODELGRADENM_TITLE].Width = 100;
			// ----- UPD 2010/05/16 -------------------<<<<<
			pareColumns[PMJKN09001UB.COL_MODELGRADENM_TITLE].MaxLength = 20;
			//ボディ
			pareColumns[PMJKN09001UB.COL_BODYNAME_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_BODYNAME_TITLE].ValueList = this._bodyNameValueList;
			pareColumns[PMJKN09001UB.COL_BODYNAME_TITLE].Width = 80;
			pareColumns[PMJKN09001UB.COL_BODYNAME_TITLE].MaxLength = 10;
			//ドア
			pareColumns[PMJKN09001UB.COL_DOORCOUNT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_DOORCOUNT_TITLE].ValueList = this._doorCountValueList;
			pareColumns[PMJKN09001UB.COL_DOORCOUNT_TITLE].Width = 60;
			pareColumns[PMJKN09001UB.COL_DOORCOUNT_TITLE].MaxLength = 2;
			//エンジン
			pareColumns[PMJKN09001UB.COL_ENGINEMODELNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_ENGINEMODELNM_TITLE].ValueList = this._engineModelValueList;
			pareColumns[PMJKN09001UB.COL_ENGINEMODELNM_TITLE].Width = 110;
			pareColumns[PMJKN09001UB.COL_ENGINEMODELNM_TITLE].MaxLength = 12;
			//排気量
			pareColumns[PMJKN09001UB.COL_ENGINEDISPLACENM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_ENGINEDISPLACENM_TITLE].ValueList = this._engineDisplaceValueList;
			pareColumns[PMJKN09001UB.COL_ENGINEDISPLACENM_TITLE].Width = 95;
			pareColumns[PMJKN09001UB.COL_ENGINEDISPLACENM_TITLE].MaxLength = 8;
			//E区分
			pareColumns[PMJKN09001UB.COL_EDIVNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_EDIVNM_TITLE].ValueList = this._eDivValueList;
			pareColumns[PMJKN09001UB.COL_EDIVNM_TITLE].Width = 95;
			pareColumns[PMJKN09001UB.COL_EDIVNM_TITLE].MaxLength = 8;
			//ミッション
			pareColumns[PMJKN09001UB.COL_TRANSMISSIONNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_TRANSMISSIONNM_TITLE].ValueList = this._transmissionValueList;
			pareColumns[PMJKN09001UB.COL_TRANSMISSIONNM_TITLE].Width = 95;
			pareColumns[PMJKN09001UB.COL_TRANSMISSIONNM_TITLE].MaxLength = 8;
			//駆動形式
			pareColumns[PMJKN09001UB.COL_WHEELDRIVEMETHODNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_WHEELDRIVEMETHODNM_TITLE].ValueList = this._wheelDriveMethodValueList;
			pareColumns[PMJKN09001UB.COL_WHEELDRIVEMETHODNM_TITLE].Width = 120;
			pareColumns[PMJKN09001UB.COL_WHEELDRIVEMETHODNM_TITLE].MaxLength = 15;
			//シフト
			pareColumns[PMJKN09001UB.COL_SHIFTNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09001UB.COL_SHIFTNM_TITLE].ValueList = this._shiftValueList;
			pareColumns[PMJKN09001UB.COL_SHIFTNM_TITLE].Width = 95;
			pareColumns[PMJKN09001UB.COL_SHIFTNM_TITLE].MaxLength = 8;
		}

		/// <summary>
		/// エディタを取得します。
		/// </summary>
		/// <param name="format">フォーマット</param>
		/// <returns>エディタ</returns>
		private EmbeddableEditorBase getEditor(string format)
		{
			EmbeddableEditorBase editor = null;
			DefaultEditorOwnerSettings editorSettings = null;
			editorSettings = new DefaultEditorOwnerSettings();
			editorSettings.DataType = typeof(string);
			editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
			editorSettings.MaskInput = format;
			return editor;
		}

		/// <summary>
		/// 自拠点名称取得得処理
		/// </summary>
		/// <param name="belongSectionCode">自拠点コード</param>
		/// <returns>自拠点名称</returns>
		private string GetOwnSectionName(string belongSectionCode)
		{
			// 自拠点の取得
			string ownSectionName = string.Empty;
			SecInfoSet secInfoSet;
			SecInfoAcs secInfoAcs = new SecInfoAcs();
			secInfoAcs.GetSecInfo(belongSectionCode, out secInfoSet);
			if (secInfoSet != null)
			{
				// 自拠点名称の保存
				ownSectionName = secInfoSet.SectionGuideNm;
			}

			return ownSectionName;
		}
		#endregion


		#region ツールバー初期設定処理
		/// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		private void ToolBarInitilSetting()
		{
			// ログイン拠点名称
			this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginSectionName"].SharedProps.Caption = GetOwnSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
			// ログイン担当者名称
			this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
		}
		#endregion


		#region  ボタン初期設定処理
		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : なし</br>
		/// <br>Programmer : 張義</br>
		/// <br>Date  : 2010/04/22</br>
		/// </remarks>
		private void ButtonInitialSetting()
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this.uButton_ModelFullGuide.ImageList = this._imageList16;
			this.uButton_ModelFullGuide.Appearance.Image = (int)Size16_Index.STAR1;

			Infragistics.Win.UltraWinToolbars.LabelTool loginTitleLabel;
			Infragistics.Win.UltraWinToolbars.LabelTool loginSectionTitle;

			loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
			loginSectionTitle = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginSectionTitle"];

			Infragistics.Win.UltraWinToolbars.ButtonTool closeButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool saveButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool clearButton;

			Infragistics.Win.UltraWinToolbars.ButtonTool modelAddButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool deleteButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool addButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool newInfoButton;

			closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
			clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];

			modelAddButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"];
			deleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"];
			addButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Add"];
			newInfoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_NewInfo"];

			loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			loginSectionTitle.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;

			closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;

			modelAddButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CAR;
			deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
			addButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			newInfoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
		}
		# endregion

		/// <summary>
		/// 車種ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_ModelFullGuide_Click(object sender, EventArgs e)
		{
			ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
			ModelNameU modelNameU;
			int makerCode = this.tNedit_MakerCode.GetInt();

			int status = modelNameUAcs.ExecuteGuid2(makerCode, this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt(),
				this._enterpriseCode, out modelNameU);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.tNedit_MakerCode.SetInt(modelNameU.MakerCode);
				this.tNedit_ModelCode.SetInt(modelNameU.ModelCode);
				this.tNedit_ModelSubCode.SetInt(modelNameU.ModelSubCode);
				this.tEdit_ModelFullName.Text = modelNameU.ModelFullName;

				// 次の項目へフォーカス移動
				ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_ModelFullGuide, this.uButton_ModelFullGuide);
				//this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);
				if (changeFocusEventArgs.NextCtrl != null)
				{
					changeFocusEventArgs.NextCtrl.Focus();
				}
			}
		}

		/// <summary>
		/// tNedit_ModelDesignationNo_ValueChangedイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_ModelDesignationNo_ValueChanged(object sender, EventArgs e)
		{
			string modelDesignationNo = this.tNedit_ModelDesignationNo.Text;

			if (this.tNedit_ModelDesignationNo.ExtEdit.Column <= modelDesignationNo.Length)
			{
				this.tNedit_CategoryNo.Enabled = true;
				this.tNedit_CategoryNo.Focus();
			}
			if (string.IsNullOrEmpty(modelDesignationNo))
			{
				this.tNedit_CategoryNo.Enabled = false;
				this.tNedit_CategoryNo.Clear();
			}
		}

		/// <summary>
		/// フォーカスコントロールイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;
			this._prevControl = e.NextCtrl;

			// PrevCtrl設定
			Control prevCtrl = new Control();
			if (e.PrevCtrl is Control) prevCtrl = (Control)e.PrevCtrl;

			// 各種変数初期化
			Control nextCtrl = null;
			// ----- ADD 2010/05/16 ------------------->>>>>
			if (e.NextCtrl is Control) nextCtrl = (Control)e.NextCtrl;

			if (e.NextCtrl == tEdit_FullModel)
			{
				tDateEdit_StartEntryYearDate.Enabled = true;
				tDateEdit_StartEntryYearDate.Appearance.BackColor = Color.Gainsboro;
			}
			// ----- ADD 2010/05/16 -------------------<<<<<

			switch (prevCtrl.Name)
			{
				#region 型式指定番号
				//---------------------------------------------------------------
				// 型式指定番号
				//---------------------------------------------------------------
				case "tNedit_ModelDesignationNo":
					{
						if ((this.tNedit_ModelDesignationNo.GetInt() != 0)
							&& (this.tNedit_CategoryNo.GetInt() == 0))
						{
							DialogResult dialogResult = TMsgDisp.Show(
							   this,
							   emErrorLevel.ERR_LEVEL_EXCLAMATION,
							   this.Name,
							   "型式指定入力時は、類別区分は必須入力です。",
							   0,
							   MessageBoxButtons.OK,
							   MessageBoxDefaultButton.Button1);
							e.NextCtrl = this.tNedit_CategoryNo;
							this.tNedit_CategoryNo.Enabled = true;
							this._prevControl = e.NextCtrl;
						}
						break;
					}
				#endregion

				#region 類別区分番号
				//---------------------------------------------------------------
				// 類別区分番号
				//---------------------------------------------------------------
				case "tNedit_CategoryNo":
					{
						if (this.tComboEditor_Model.SelectedIndex != 0)
						{
							if ((this.tNedit_ModelDesignationNo.GetInt() != 0) &&
								(this.tNedit_CategoryNo.GetInt() != 0))
							{
								if (String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
								{
									CarSearchCondition con = new CarSearchCondition();
									con.ModelDesignationNo = this.tNedit_ModelDesignationNo.GetInt();
									con.CategoryNo = this.tNedit_CategoryNo.GetInt();
									con.Type = CarSearchType.csCategory;
									con.FreeSearchModelOnly = true;

									int result = this.CarSearch(con);

									switch ((ConstantManagement.MethodResult)result)
									{
										case ConstantManagement.MethodResult.ctFNC_CANCEL:
											e.NextCtrl = this.tNedit_ModelDesignationNo;
											this._prevControl = e.NextCtrl;
											this.tNedit_ModelDesignationNo.Clear();
											this.tNedit_CategoryNo.Clear();
											break;
										case ConstantManagement.MethodResult.ctFNC_NORMAL:
											nextCtrl = this.tDateEdit_StartEntryYearDate;
											e.NextCtrl = nextCtrl;
											this.tDateEdit_StartEntryYearDate.Focus();
											this._prevControl = this.tDateEdit_StartEntryYearDate;
											// ----- ADD 2010/05/16 ------------------->>>>>
											this.SettingButtonEnabled();
											this.tNedit_ModelDesignationNo.Enabled = false;
											this.tNedit_CategoryNo.Enabled = false;
											// this.tEdit_EndProduceFrameNo.Enabled = true; // DEL 2010/05/20
											//this._clearUpdateFlg = true; // ADD 2010/05/20 DEL 2010/05/25
											// ----- ADD 2010/05/16 -------------------<<<<<
											break;
										case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
											if (String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
											{
												DialogResult dialogResult = TMsgDisp.Show(
													this,
													emErrorLevel.ERR_LEVEL_EXCLAMATION,
													this.Name,
													"該当データがありません。",
													0,
													MessageBoxButtons.OK,
													MessageBoxDefaultButton.Button1);
												if (dialogResult == DialogResult.OK)
												{
													e.NextCtrl = this.tNedit_ModelDesignationNo;
													this.tNedit_ModelDesignationNo.Clear();
													this.tNedit_CategoryNo.Clear();
												}
											}
											break;
										default:
											break;
									}
								}
							}
							else if ((this.tNedit_ModelDesignationNo.GetInt() != 0) && (this.tNedit_CategoryNo.GetInt() == 0))
							{
								if (this._prevControl.Name != "tNedit_ModelDesignationNo")
								{
									DialogResult dialogResult = TMsgDisp.Show(
									   this,
									   emErrorLevel.ERR_LEVEL_EXCLAMATION,
									   this.Name,
									   "型式指定入力時は、類別区分は必須入力です。",
									   0,
									   MessageBoxButtons.OK,
									   MessageBoxDefaultButton.Button1);
									e.NextCtrl = this.tNedit_CategoryNo;
									this._prevControl = e.NextCtrl;
								}
							}
							else
							{
								prevCtrl = this.tNedit_ModelDesignationNo;
								break;
							}
							prevCtrl = this.tNedit_ModelDesignationNo;
							this._prevControl = prevCtrl;
						}
						else
						{
							if ((this.tNedit_ModelDesignationNo.GetInt() != 0) && (this.tNedit_CategoryNo.GetInt() == 0))
							{
								if (this._prevControl.Name != "tNedit_ModelDesignationNo")
								{
									DialogResult dialogResult = TMsgDisp.Show(
									   this,
									   emErrorLevel.ERR_LEVEL_EXCLAMATION,
									   this.Name,
									   "型式指定入力時は、類別区分は必須入力です。",
									   0,
									   MessageBoxButtons.OK,
									   MessageBoxDefaultButton.Button1);
									e.NextCtrl = this.tNedit_CategoryNo;
									this._prevControl = e.NextCtrl;
								}
							}
						}
						break;
					}
				#endregion

				#region 型式／モデルプレート
				//---------------------------------------------------------------
				// 型式／モデルプレート
				//---------------------------------------------------------------
				case "tEdit_FullModel":
					{
						//---------------------------------------------------------------
						// 型式検索
						//---------------------------------------------------------------
						if (this.tComboEditor_Model.SelectedIndex != 0)
						{
							if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim()))
							{
								this.tEdit_FullModel.Text = this.tEdit_FullModel.Text.ToUpper();

								CarSearchCondition con = new CarSearchCondition();
								con.CarModel.FullModel = this.tEdit_FullModel.Text;
								con.Type = CarSearchType.csModel;
								con.FreeSearchModelOnly = true;

								int result = this.CarSearch(con);

								switch ((ConstantManagement.MethodResult)result)
								{
									case ConstantManagement.MethodResult.ctFNC_CANCEL:
										e.NextCtrl = e.PrevCtrl;
										this.tEdit_FullModel.Clear();
										break;
									case ConstantManagement.MethodResult.ctFNC_NORMAL:
										nextCtrl = this.tDateEdit_StartEntryYearDate;
										e.NextCtrl = nextCtrl;
										this.tDateEdit_StartEntryYearDate.Focus();
										this._prevControl = this.tDateEdit_StartEntryYearDate;
										// ----- ADD 2010/05/16 ------------------->>>>>
										this.SettingButtonEnabled();
										this.tNedit_ModelDesignationNo.Enabled = false;
										this.tNedit_CategoryNo.Enabled = false;
										// this.tEdit_EndProduceFrameNo.Enabled = true;  // DEL 2010/05/20
										//this._clearUpdateFlg = true; // ADD 2010/05/20 DEL 2010/05/25
										// ----- ADD 2010/05/16 -------------------<<<<<
										break;
									case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
										if (String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
										{
											DialogResult dialogResult = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_EXCLAMATION,
												this.Name,
												"該当データがありません。",
												0,
												MessageBoxButtons.OK,
												MessageBoxDefaultButton.Button1);
											if (dialogResult == DialogResult.OK)
											{
												e.NextCtrl = this.tEdit_FullModel;
												this.tEdit_FullModel.Clear();
											}
										}
										break;
									default:
										break;
								}
							}
						}
						// ----- ADD 2010/05/16 ------------------->>>>>
						else if (this.tComboEditor_Model.SelectedIndex == 0)
						{
							if (nextCtrl.Name.Equals("tDateEdit_StartEntryYearDate") || e.Key == Keys.Right || e.Key == Keys.Down)
							{
								// 車種
								if (String.IsNullOrEmpty(this.tEdit_ModelFullName.Text) || un_INSERT.Equals(this.tEdit_ModelFullName.Text))
								{
									if (this.tNedit_MakerCode.GetInt() == 0
										&& this.tNedit_ModelCode.GetInt() == 0
										&& this.tNedit_ModelSubCode.GetInt() == 0)
									{
										DialogResult dialogResult = TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_EXCLAMATION,
											this.Name,
											"車種を入力して下さい。",
											0,
											MessageBoxButtons.OK,
											MessageBoxDefaultButton.Button1);
									}
									else
									{
										DialogResult dialogResult = TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_EXCLAMATION,
											this.Name,
											"車種が入力不正です。",
											0,
											MessageBoxButtons.OK,
											MessageBoxDefaultButton.Button1);
									}
									// 指定フォーカス設定処理
									this.tNedit_MakerCode.Focus();
									e.NextCtrl = this.tNedit_MakerCode;
									break;

								}
								// 型式
								if (String.IsNullOrEmpty(this.tEdit_FullModel.Text))
								{
									DialogResult dialogResult = TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
										"型式を入力して下さい。",
										0,
										MessageBoxButtons.OK,
										MessageBoxDefaultButton.Button1);

									// 指定フォーカス設定処理
									this.tEdit_FullModel.Focus();
									e.NextCtrl = this.tEdit_FullModel;
									break;

								}

								if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text))
								{
									bool errorFlag = false;
									char[] chs = this.tEdit_FullModel.Text.ToCharArray();
									foreach (char ch in chs)
									{
										if (!(this.IsNum(ch) || this.IsNumSign(ch) || this.IsAlpha(ch)))
										{
											DialogResult dialogResult = TMsgDisp.Show(
																	this,
																	emErrorLevel.ERR_LEVEL_EXCLAMATION,
																	this.Name,
																	"英数字を入力して下さい。",
																	0,
																	MessageBoxButtons.OK,
																	MessageBoxDefaultButton.Button1);
											// 指定フォーカス設定処理
											this.tEdit_FullModel.Focus();
											e.NextCtrl = this.tEdit_FullModel;
											errorFlag = true;
											break;
										}
									}

									if (errorFlag)
										break;
								}

								// 型式の判断
								if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text))
								{
									string fullModel = this.tEdit_FullModel.Text;

									bool flag = false;
									flag = this.CheckModelName(fullModel);

									if (!flag)
									{
										this.tEdit_FullModel.Focus();
										e.NextCtrl = this.tEdit_FullModel;
										break;
									}
								}

								CarSearchCondition con = new CarSearchCondition();
								con.CarModel.FullModel = this.tEdit_FullModel.Text;
								con.Type = CarSearchType.csModel;
								// --- UPD m.suzuki 2010/06/22 ---------->>>>>
								//con.FreeSearchModelOnly = true;
								con.FreeSearchModelOnly = false;
								// --- UPD m.suzuki 2010/06/22 ----------<<<<<

								int result = this.CarSearchNew(con);
								switch ((ConstantManagement.MethodResult)result)
								{
									case ConstantManagement.MethodResult.ctFNC_CANCEL:
										e.NextCtrl = e.PrevCtrl;
										this.tEdit_FullModel.Clear();
										break;
									case ConstantManagement.MethodResult.ctFNC_NORMAL:
										SettingButtonEnabled();
										nextCtrl = this.tDateEdit_StartEntryYearDate;
										e.NextCtrl = nextCtrl;
										this.tDateEdit_StartEntryYearDate.Focus();
										this._prevControl = this.tDateEdit_StartEntryYearDate;
										this._clearChangeFlg = true;
										break;
									case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
										if (String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
										{
											DialogResult dialogResult = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_EXCLAMATION,
												this.Name,
												"該当データがありません。",
												0,
												MessageBoxButtons.OK,
												MessageBoxDefaultButton.Button1);
											if (dialogResult == DialogResult.OK)
											{
												e.NextCtrl = this.tEdit_FullModel;
												this.tEdit_FullModel.Clear();
											}
										}
										break;
									default:
										break;
								}
							}
						}
						// ----- ADD 2010/05/16 -------------------<<<<<

						switch (e.Key)
						{
							case Keys.Down:
								e.NextCtrl = this.tDateEdit_StartEntryYearDate;
								break;
							case Keys.Up:
								e.NextCtrl = this.tNedit_MakerCode;
								break;
							default:
								break;
						}
						break;
					}
				#endregion

				#region 車台番号
				//車台番号
				case "tEdit_StartProduceFrameNo":
					{
						switch (e.Key)
						{
							case Keys.Down:
								e.NextCtrl = this.ultraGrid_CarSpec;
								this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_MODELGRADENM_TITLE].Activate();
								this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
								break;
							case Keys.Up:
								e.NextCtrl = this.tDateEdit_StartEntryYearDate;
								break;
							default:
								break;
						}
						break;
					}

				case "tEdit_EndProduceFrameNo":
					{
						switch (e.Key)
						{
							case Keys.Down:
								e.NextCtrl = this.ultraGrid_CarSpec;
								this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_MODELGRADENM_TITLE].Activate();
								this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
								break;
							case Keys.Up:
								e.NextCtrl = this.tDateEdit_EndEntryMonthDate;
								break;
							default:
								break;
						}
						break;
					}
				#endregion
				// ----- ADD 2010/05/16 ------------------->>>>>
				//年式終了(年)
				case "tDateEdit_EndEntryYearDate":
					{
						if (e.NextCtrl != this.tDateEdit_EndEntryMonthDate)
						{
							if ((!string.IsNullOrEmpty(tDateEdit_StartEntryYearDate.Text)) && (!string.IsNullOrEmpty(tDateEdit_StartEntryMonthDate.Text))
								&& (string.IsNullOrEmpty(tDateEdit_EndEntryYearDate.Text)) && (string.IsNullOrEmpty(tDateEdit_EndEntryMonthDate.Text)))
							{
								this.tDateEdit_EndEntryYearDate.Text = this.tDateEdit_StartEntryYearDate.Text;
								this.tDateEdit_EndEntryMonthDate.Text = this.tDateEdit_StartEntryMonthDate.Text;
							}
						}
						break;
					}
				//年式終了(月)
				case "tDateEdit_EndEntryMonthDate":
					{
						if (e.NextCtrl != this.tDateEdit_EndEntryYearDate)
						{
							if ((!string.IsNullOrEmpty(tDateEdit_StartEntryYearDate.Text)) && (!string.IsNullOrEmpty(tDateEdit_StartEntryMonthDate.Text))
								&& (string.IsNullOrEmpty(tDateEdit_EndEntryYearDate.Text)) && (string.IsNullOrEmpty(tDateEdit_EndEntryMonthDate.Text)))
							{
								this.tDateEdit_EndEntryYearDate.Text = this.tDateEdit_StartEntryYearDate.Text;
								this.tDateEdit_EndEntryMonthDate.Text = this.tDateEdit_StartEntryMonthDate.Text;
							}
						}
						break;
					}
				// ----- ADD 2010/05/16 -------------------<<<<<
			}

			//---------------------------------------------------------------
			// ボタンツール有効無効設定処理
			//---------------------------------------------------------------
			if (e.NextCtrl != null && e.NextCtrl.Name != "_Form1_Toolbars_Dock_Area_Top")
			{
				this.SettingToolBarButtonEnabled();
			}

		}

		/// <summary>
		/// フォーカスコントロールイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			// ----- ADD 2010/05/16 ------------------->>>>>
			if (e.NextCtrl == tEdit_FullModel)
			{
				tDateEdit_StartEntryYearDate.Enabled = true;
				tDateEdit_StartEntryYearDate.Appearance.BackColor = Color.Gainsboro;
			}
			// ----- ADD 2010/05/16 -------------------<<<<<

			// GridにControlがある時のReturn/Tabの動き設定
			if (e.PrevCtrl != null)
			{
				if (e.PrevCtrl.Name == "ultraGrid_CarSpec")
				{
					// リターンキーの時
					if ((e.Key == Keys.Return) ||
						(e.Key == Keys.Tab))
					{
						e.NextCtrl = null;

						if (this.ultraGrid_CarSpec.ActiveCell != null)
						{
							// ----- UPD 2010/05/16 ------------------->>>>>
							if (!e.ShiftKey)
							{
								// 最終セルの時
								if ((this.ultraGrid_CarSpec.ActiveCell.Row.Index == this.ultraGrid_CarSpec.Rows.Count - 1)
									  && (this.ultraGrid_CarSpec.ActiveCell.Column.Index == this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[PMJKN09001UB.COL_SHIFTNM_TITLE].Index))
								{
									if (e.Key == Keys.Tab)
									{
										// モードにフォーカス遷移
										e.NextCtrl = this.tDateEdit_StartEntryYearDate;
									}

									if (e.Key == Keys.Return)
									{
										this.Save(); // 保存処理
									}
								}
								else
								{
									// 次のCellにフォーカス遷移
									this.ultraGrid_CarSpec.PerformAction(UltraGridAction.NextCell);
									this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
								}
							}
							else
							{
								// 最初セルの時
								if ((this.ultraGrid_CarSpec.ActiveCell.Row.Index == 0)
									  && (this.ultraGrid_CarSpec.ActiveCell.Column.Index == this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[PMJKN09001UB.COL_MODELGRADENM_TITLE].Index))
								{
									if (e.Key == Keys.Tab)
									{
										if (this.tEdit_EndProduceFrameNo.Enabled == true)
										{
											// モードにフォーカス遷移
											e.NextCtrl = this.tEdit_EndProduceFrameNo;
										}
										else
										{
											// モードにフォーカス遷移
											e.NextCtrl = this.tEdit_StartProduceFrameNo;
										}
									}
								}
								else
								{
									// 次のCellにフォーカス遷移
									this.ultraGrid_CarSpec.PerformAction(UltraGridAction.PrevCell);
									this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
								}
							}
						}
						// ----- UPD 2010/05/16 -------------------<<<<<
					}
				}
				//車台番号からグリッドへ遷移
				else if (e.PrevCtrl.Name == "tEdit_EndProduceFrameNo")
				{
					if (e.NextCtrl.Name == "ultraGrid_CarSpec")
					{
						if (this.ultraGrid_CarSpec.Rows.Count != 0)
						{
							e.NextCtrl = null;
							switch (e.Key)
							{
								case Keys.Return:
									{
										this.ultraGrid_CarSpec.Focus();
										this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_MODELGRADENM_TITLE].Activate();
										this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
										break;
									}
								case Keys.Tab:
									{
										this.ultraGrid_CarSpec.Focus();
										this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_MODELGRADENM_TITLE].Activate();
										this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
										break;
									}
								case Keys.Up:
									{
										this.tEdit_StartProduceFrameNo.Focus();
										break;
									}
							}
						}
					}
				}
				else if (e.PrevCtrl.Name == "tEdit_EndProduceFrameNo")
				{
					//SHIFT+TABの場合
					if (e.NextCtrl == this.ultraGrid_CarSpec)
					{
						e.NextCtrl = null;
						this.ultraGrid_CarSpec.PerformAction(UltraGridAction.ActivateCell);
						this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
					}
				}
				else if (e.PrevCtrl.Name == "tNedit_CategoryNo")
				{
					int model = this.tComboEditor_Model.SelectedIndex;
					if ((this.tNedit_ModelDesignationNo.GetInt() != 0) && (this.tNedit_CategoryNo.GetInt() == 0))
					{

						DialogResult dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							"型式指定入力時は、類別区分は必須入力です。",
							0,
							MessageBoxButtons.OK,
							MessageBoxDefaultButton.Button1);

						e.NextCtrl = this.tNedit_CategoryNo;
						this._prevControl = e.NextCtrl;
					}
					if (model == 1) // 更新場合
					{
						if ((this.tNedit_ModelDesignationNo.GetInt() != 0) && (this.tNedit_CategoryNo.GetInt() != 0))
						{
							if (String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
							{
								CarSearchCondition con = new CarSearchCondition();
								con.ModelDesignationNo = this.tNedit_ModelDesignationNo.GetInt();
								con.CategoryNo = this.tNedit_CategoryNo.GetInt();
								con.Type = CarSearchType.csCategory;
								con.FreeSearchModelOnly = true;

								int result = this.CarSearch(con);

								switch ((ConstantManagement.MethodResult)result)
								{
									case ConstantManagement.MethodResult.ctFNC_CANCEL:
										e.NextCtrl = this.tNedit_ModelDesignationNo;
										this._prevControl = e.NextCtrl;
										this.tNedit_ModelDesignationNo.Clear();
										this.tNedit_CategoryNo.Clear();
										break;
									case ConstantManagement.MethodResult.ctFNC_NORMAL:
										this.tDateEdit_StartEntryYearDate.Focus();
										this._prevControl = this.tDateEdit_StartEntryYearDate;
										e.NextCtrl = this.tDateEdit_StartEntryYearDate;
										// ----- ADD 2010/05/16 ------------------->>>>>
										this.SettingButtonEnabled();
										this.tNedit_ModelDesignationNo.Enabled = false;
										this.tNedit_CategoryNo.Enabled = false;
										// this.tEdit_EndProduceFrameNo.Enabled = true; // DEL 2010/05/20
										//this._clearUpdateFlg = true; // ADD 2010/05/20 DEL 2010/05/25
										// ----- ADD 2010/05/16 -------------------<<<<<
										break;
									case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
										if (String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
										{
											DialogResult dialogResult = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_EXCLAMATION,
												this.Name,
												"該当データがありません。",
												0,
												MessageBoxButtons.OK,
												MessageBoxDefaultButton.Button1);
											if (dialogResult == DialogResult.OK)
											{
												e.NextCtrl = this.tNedit_ModelDesignationNo;
												this.tNedit_ModelDesignationNo.Clear();
												this.tNedit_CategoryNo.Clear();
											}
										}

										break;
									default:
										break;
								}
							}
						}
					}
				}
				else if (e.PrevCtrl.Name == "tEdit_FullModel")
				{

					// ----- ADD 2010/05/16 ------------------->>>>>
					//TABの場合
					if (e.NextCtrl != this.uButton_ModelFullGuide)
					{
						// ----- ADD 2010/05/16 -------------------<<<<<
						if (this.tComboEditor_Model.SelectedIndex != 0)
						{
							if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim()))
							{
								this.tEdit_FullModel.Text = this.tEdit_FullModel.Text.ToUpper();

								CarSearchCondition con = new CarSearchCondition();
								con.CarModel.FullModel = this.tEdit_FullModel.Text;
								con.Type = CarSearchType.csModel;
								con.FreeSearchModelOnly = true;

								int result = this.CarSearch(con);

								switch ((ConstantManagement.MethodResult)result)
								{
									case ConstantManagement.MethodResult.ctFNC_CANCEL:
										e.NextCtrl = e.PrevCtrl;
										this.tEdit_FullModel.Clear();
										break;
									case ConstantManagement.MethodResult.ctFNC_NORMAL:
										this.tDateEdit_StartEntryYearDate.Focus();
										e.NextCtrl = this.tDateEdit_StartEntryYearDate;
										// ----- ADD 2010/05/16 ------------------->>>>>
										this.SettingButtonEnabled();
										this.tNedit_ModelDesignationNo.Enabled = false;
										this.tNedit_CategoryNo.Enabled = false;
										// this.tEdit_EndProduceFrameNo.Enabled = true; // DEL 2010/05/20
										//this._clearUpdateFlg = true;  // ADD 2010/05/20
										// ----- ADD 2010/05/16 -------------------<<<<<
										break;
									case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
										if (String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
										{
											DialogResult dialogResult = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_EXCLAMATION,
												this.Name,
												"該当データがありません。",
												0,
												MessageBoxButtons.OK,
												MessageBoxDefaultButton.Button1);
											if (dialogResult == DialogResult.OK)
											{
												e.NextCtrl = this.tEdit_FullModel;
												this.tEdit_FullModel.Clear();
											}
										}
										break;
									default:
										break;
								}
							}
						}
						// ----- ADD 2010/05/16 ------------------->>>>>
						else if (this.tComboEditor_Model.SelectedIndex == 0) // 新規場合
						{
							// 車種
							if (String.IsNullOrEmpty(this.tEdit_ModelFullName.Text) || un_INSERT.Equals(this.tEdit_ModelFullName.Text))
							{
								if (this.tNedit_MakerCode.GetInt() == 0
									&& this.tNedit_ModelCode.GetInt() == 0
									&& this.tNedit_ModelSubCode.GetInt() == 0)
								{
									DialogResult dialogResult = TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
										"車種を入力して下さい。",
										0,
										MessageBoxButtons.OK,
										MessageBoxDefaultButton.Button1);
								}
								else
								{
									DialogResult dialogResult = TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
										"車種が入力不正です。",
										0,
										MessageBoxButtons.OK,
										MessageBoxDefaultButton.Button1);
								}
								// 指定フォーカス設定処理
								this.tNedit_MakerCode.Focus();
								e.NextCtrl = this.tNedit_MakerCode;
								return;

							}
							// 型式
							if (String.IsNullOrEmpty(this.tEdit_FullModel.Text))
							{
								DialogResult dialogResult = TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_EXCLAMATION,
									this.Name,
									"型式を入力して下さい。",
									0,
									MessageBoxButtons.OK,
									MessageBoxDefaultButton.Button1);

								// 指定フォーカス設定処理
								this.tEdit_FullModel.Focus();
								e.NextCtrl = this.tEdit_FullModel;
								return;

							}

							if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text))
							{
								bool errorFlag = false;
								char[] chs = this.tEdit_FullModel.Text.ToCharArray();
								foreach (char ch in chs)
								{
									if (!(this.IsNum(ch) || this.IsNumSign(ch) || this.IsAlpha(ch)))
									{
										DialogResult dialogResult = TMsgDisp.Show(
																this,
																emErrorLevel.ERR_LEVEL_EXCLAMATION,
																this.Name,
																"英数字を入力して下さい。",
																0,
																MessageBoxButtons.OK,
																MessageBoxDefaultButton.Button1);
										// 指定フォーカス設定処理
										this.tEdit_FullModel.Focus();
										e.NextCtrl = this.tEdit_FullModel;
										errorFlag = true;
										break;
									}
								}

								if (errorFlag)
									return;
							}

							// 型式の判断
							if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text))
							{
								string fullModel = this.tEdit_FullModel.Text;

								bool flag = false;
								flag = this.CheckModelName(fullModel);

								if (!flag)
								{
									this.tEdit_FullModel.Focus();
									e.NextCtrl = this.tEdit_FullModel;
									return;
								}
							}

							CarSearchCondition con = new CarSearchCondition();
							con.CarModel.FullModel = this.tEdit_FullModel.Text;
							con.Type = CarSearchType.csModel;
							// --- UPD m.suzuki 2010/06/22 ---------->>>>>
							//con.FreeSearchModelOnly = true;
							con.FreeSearchModelOnly = false;
							// --- UPD m.suzuki 2010/06/22 ----------<<<<<

							int result = this.CarSearchNew(con);
							SettingButtonEnabled();
							e.NextCtrl = this.tDateEdit_StartEntryYearDate;
							this.tDateEdit_StartEntryYearDate.Focus();
							this._prevControl = this.tDateEdit_StartEntryYearDate;
							this._clearChangeFlg = true;
						}
					}
				}
				//年式終了(年)
				else if (e.PrevCtrl.Name == "tDateEdit_EndEntryYearDate")
				{
					if (e.NextCtrl == this.tDateEdit_StartEntryMonthDate)
					{
						if ((!string.IsNullOrEmpty(tDateEdit_StartEntryYearDate.Text)) && (!string.IsNullOrEmpty(tDateEdit_StartEntryMonthDate.Text))
							&& (string.IsNullOrEmpty(tDateEdit_EndEntryYearDate.Text)) && (string.IsNullOrEmpty(tDateEdit_EndEntryMonthDate.Text)))
						{
							this.tDateEdit_EndEntryYearDate.Text = this.tDateEdit_StartEntryYearDate.Text;
							this.tDateEdit_EndEntryMonthDate.Text = this.tDateEdit_StartEntryMonthDate.Text;
						}
					}
				}
				//年式終了(月)
				else if (e.PrevCtrl.Name == "tDateEdit_EndEntryMonthDate")
				{
					if (e.NextCtrl == this.tEdit_StartProduceFrameNo)
					{
						if ((!string.IsNullOrEmpty(tDateEdit_StartEntryYearDate.Text)) && (!string.IsNullOrEmpty(tDateEdit_StartEntryMonthDate.Text))
							&& (string.IsNullOrEmpty(tDateEdit_EndEntryYearDate.Text)) && (string.IsNullOrEmpty(tDateEdit_EndEntryMonthDate.Text)))
						{
							this.tDateEdit_EndEntryYearDate.Text = this.tDateEdit_StartEntryYearDate.Text;
							this.tDateEdit_EndEntryMonthDate.Text = this.tDateEdit_StartEntryMonthDate.Text;
						}
					}
					// ----- ADD 2010/05/16 -------------------<<<<<
				}
				else if (e.PrevCtrl.Name == "tNedit_ModelDesignationNo")
				{
					// リターンキーの時
					if ((e.Key == Keys.Return) ||
						(e.Key == Keys.Tab))
					{
						// ----- UPD 2010/05/16 ------------------->>>>>
						if (!e.ShiftKey)
						{
							if (!String.IsNullOrEmpty(this.tNedit_ModelDesignationNo.Text))
							{
								e.NextCtrl = this.tNedit_CategoryNo;
								this.tNedit_CategoryNo.Enabled = true;
								this.tNedit_CategoryNo.Focus();
							}
						}
						else
						{
							e.NextCtrl = this.tComboEditor_Model;

						}
						// ----- UPD 2010/05/16 -------------------<<<<<

					}
				}
			}

			if (e.NextCtrl != null)
			{
				// [車種追加(A)]ボタンは押下不可
				if (e.NextCtrl.Name == "tNedit_MakerCode"
					 || e.NextCtrl.Name == "tNedit_ModelCode"
								|| e.NextCtrl.Name == "tNedit_ModelSubCode")
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = true;
				}
				else
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = false;
				}

				// 削除ボタンは押下可
				if (this.tComboEditor_Model.SelectedIndex == 1)
				{
					if (!String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
					{
						this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;
					}
					else
					{
						this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
					}
				}
				else
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
				}

				// 追加ボタンは押下可
				if (this.tComboEditor_Model.SelectedIndex == 1)
				{
					if (e.NextCtrl.TabIndex > 7 || e.NextCtrl.Name == "ultraGrid_CarSpec")
					{
						this.tToolbarsManager_MainMenu.Tools["ButtonTool_Add"].SharedProps.Enabled = true;
					}
					else
					{
						this.tToolbarsManager_MainMenu.Tools["ButtonTool_Add"].SharedProps.Enabled = false;
					}
				}
				else
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_Add"].SharedProps.Enabled = false;
				}
			}
		}

		// ----- ADD 2010/05/16 ------------------->>>>>
		/// <summary>
		/// ボタン有効無効設定処理
		/// </summary>
		private void InitialSettingButtonEnabled()
		{
			tComboEditor_Model.Enabled = true;
			tNedit_ModelDesignationNo.Enabled = true;
			tNedit_CategoryNo.Enabled = false;
			tNedit_MakerCode.Enabled = true;
			tNedit_ModelCode.Enabled = false;
			tNedit_ModelSubCode.Enabled = false;
			tEdit_FullModel.Enabled = true;
			uButton_ModelFullGuide.Enabled = true;

			tDateEdit_StartEntryYearDate.Enabled = false;
			tDateEdit_StartEntryMonthDate.Enabled = false;
			tDateEdit_EndEntryYearDate.Enabled = false;
			tDateEdit_EndEntryMonthDate.Enabled = false;
			tEdit_StartProduceFrameNo.Enabled = false;
			tEdit_EndProduceFrameNo.Enabled = false;
			ultraGrid_CarSpec.Enabled = false;
		}

		/// <summary>
		/// ボタン有効無効設定処理
		/// </summary>
		private void SettingButtonEnabled()
		{

			// 更新モード
			tComboEditor_Model.Enabled = false;
			tNedit_ModelDesignationNo.Enabled = false;
			tNedit_CategoryNo.Enabled = false;
			tNedit_MakerCode.Enabled = false;
			tNedit_ModelCode.Enabled = false;
			tNedit_ModelSubCode.Enabled = false;
			tEdit_FullModel.Enabled = false;
			uButton_ModelFullGuide.Enabled = false;

			tDateEdit_StartEntryYearDate.Enabled = true;
			tDateEdit_StartEntryMonthDate.Enabled = true;
			tDateEdit_EndEntryYearDate.Enabled = true;
			tDateEdit_EndEntryMonthDate.Enabled = true;
			tEdit_StartProduceFrameNo.Enabled = true;
			// ----- UPD 2010/05/20 ------------------->>>>>
			if ((!string.IsNullOrEmpty(tEdit_EndProduceFrameNo.Text)) ||
				(!string.IsNullOrEmpty(tEdit_StartProduceFrameNo.Text)))
			{
				tEdit_EndProduceFrameNo.Enabled = true;
			}
			else
			{
				tEdit_EndProduceFrameNo.Enabled = false;
			}
			// ----- UPD 2010/05/20 -------------------<<<<<
			ultraGrid_CarSpec.Enabled = true;
		}
		// ----- ADD 2010/05/16 -------------------<<<<<

		/// <summary>
		/// ツールバーボタン有効無効設定処理
		/// </summary>
		private void SettingToolBarButtonEnabled()
		{
			int modelFlg = 0;
			modelFlg = this.tComboEditor_Model.SelectedIndex; // 画面モードの取得

			if (modelFlg == 0) // 新規場合  
			{
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;

				if (this._prevControl != null)
				{
					if (this._prevControl.TabStop == true)
					{
						if (this._prevControl.Name == "tNedit_MakerCode"
							|| this._prevControl.Name == "tNedit_ModelCode"
							|| this._prevControl.Name == "tNedit_ModelSubCode") // カーソルが車種に存在時のみ実行可能
						{
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = true;
						}
						else
						{
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = false;
						}
					}
				}
				else
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = false;
				}

				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Add"].SharedProps.Enabled = false;
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_NewInfo"].SharedProps.Enabled = true;
			}
			else
			{
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;

				if (this._prevControl != null)
				{
					if (this._prevControl.TabStop == true)
					{
						if (this._prevControl.Name == "tNedit_MakerCode"
							|| this._prevControl.Name == "tNedit_ModelCode"
							|| this._prevControl.Name == "tNedit_ModelSubCode") // カーソルが車種に存在時のみ実行可能
						{
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = true;
						}
						else
						{
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = false;
						}
					}
				}
				else
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = false;
				}

				if (!String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;
				}
				else
				{
					this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
				}

				this.tToolbarsManager_MainMenu.Tools["ButtonTool_Add"].SharedProps.Enabled = false;
				// 更新モードで、カーソルが年式以降に存在時のみ実行可能
				if (this._prevControl != null)
				{
					if (this._prevControl.TabIndex > 7 || this._prevControl.Name == "ultraGrid_CarSpec")
					{
						this.tToolbarsManager_MainMenu.Tools["ButtonTool_Add"].SharedProps.Enabled = true;
					}
				}

				this.tToolbarsManager_MainMenu.Tools["ButtonTool_NewInfo"].SharedProps.Enabled = true;
			}
		}

		/// <summary>
		/// 車両検索処理
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		private int CarSearch(CarSearchCondition condition)
		{
			//------------------------------------------------------
			// 初期処理
			//------------------------------------------------------
			int retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			this._freeSrchMdlFxdNo = String.Empty;
			this._updateTime = new DateTime();

			//------------------------------------------------------
			// カーメーカーコード、車種コード、車種呼称コード設定
			//------------------------------------------------------
			if (condition.Type != CarSearchType.csCategory)
			{
				int makerCd, modelCd, modelSubCd;
				if (int.TryParse(this.tNedit_MakerCode.Text, out makerCd))
				{
					condition.MakerCode = makerCd;
				}
				if (int.TryParse(this.tNedit_ModelCode.Text, out modelCd))
				{
					condition.ModelCode = modelCd;
				}
				if (int.TryParse(this.tNedit_ModelSubCode.Text, out modelSubCd))
				{
					condition.ModelSubCode = modelSubCd;
				}
			}
			//------------------------------------------------------
			// 各種検索処理
			//------------------------------------------------------
			//  CarSearchCondition の検索タイプにより指定
			//------------------------------------------------------
			CarSearchResultReport ret = new CarSearchResultReport();
			PMKEN01010E dat = new PMKEN01010E();
			CarSearchController carSearchController = new CarSearchController();
			ret = carSearchController.Search(condition, ref dat);

			if (ret == CarSearchResultReport.retFailed)
			{
				return retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			}
			else if (ret == CarSearchResultReport.retError)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"検索中にエラーが発生しました。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				return retStatus = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			if (ret == CarSearchResultReport.retMultipleCarKind)
			{
				//------------------------------------------------------
				// 車種選択画面起動
				//------------------------------------------------------
				if (SelectionCarKind.ShowDialog(dat.CarKindInfo, condition) == DialogResult.OK)
				{
					ret = carSearchController.Search(condition, ref dat);
				}
				else
				{
					return retStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				}
			}
			if (ret == CarSearchResultReport.retMultipleCarModel)
			{
				//------------------------------------------------------
				// 型式選択画面起動
				//------------------------------------------------------
				if (SelectionCarModel.ShowDialog(dat) == DialogResult.OK)
				{
					SetCarInfo(dat);
				}
				else
				{
					return retStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				}
			}

			if ((ret == CarSearchResultReport.retSingleCarModel) || (ret == CarSearchResultReport.retMultipleCarModel))
			{
				SetCarInfo(dat);

				return retStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}

			return retStatus;
		}

		/// <summary>
		/// 車両情報キャッシュ（車両検索情報からキャッシュ）
		/// </summary>
		/// <param name="dat">車種型式情報</param>
		private void SetCarInfo(PMKEN01010E dat)
		{
			//車種型式情報
			_carModelInfoDataTable = dat.CarModelInfo;

			this.ClearValueList();

			if (_carModelInfoDataTable != null && _carModelInfoDataTable.Rows.Count > 0)
			{
				//グレード
				ArrayList modelGradeNmList = new ArrayList();
				//ボディ
				ArrayList bodyNameList = new ArrayList();
				//ドア
				ArrayList doorCoutList = new ArrayList();
				//エンジン
				ArrayList engineModelList = new ArrayList();
				//排気量
				ArrayList engineDisplaceList = new ArrayList();
				//E区分
				ArrayList eDivList = new ArrayList();
				//ミッション
				ArrayList transmissionList = new ArrayList();
				//駆動形式
				ArrayList wheelDriveMethodList = new ArrayList();
				//シフト
				ArrayList shiftList = new ArrayList();
				for (int i = 0; i < _carModelInfoDataTable.Rows.Count; i++)
				{
					PMKEN01010E.CarModelInfoRow carModelInfoRow = (PMKEN01010E.CarModelInfoRow)_carModelInfoDataTable.Rows[i];

					//グレード
					if (!modelGradeNmList.Contains((string)carModelInfoRow["ModelGradeNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["ModelGradeNm"]))
					{
						this._modelGradeValueList.ValueListItems.Add(i, (string)carModelInfoRow["ModelGradeNm"]);
						modelGradeNmList.Add((string)carModelInfoRow["ModelGradeNm"]);
					}
					//ボディ
					if (!bodyNameList.Contains((string)carModelInfoRow["BodyName"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["BodyName"]))
					{
						this._bodyNameValueList.ValueListItems.Add(i, (string)carModelInfoRow["BodyName"]);
						bodyNameList.Add((string)carModelInfoRow["BodyName"]);
					}
					//ドア
					int doorCout = (int)carModelInfoRow["DoorCount"];
					if (!doorCoutList.Contains(doorCout.ToString())
						&& ((int)carModelInfoRow["DoorCount"] != 0))
					{
						this._doorCountValueList.ValueListItems.Add(i, doorCout.ToString());
						doorCoutList.Add(doorCout.ToString());
					}
					//エンジン
					if (!engineModelList.Contains((string)carModelInfoRow["EngineModelNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EngineModelNm"]))
					{
						this._engineModelValueList.ValueListItems.Add(i, (string)carModelInfoRow["EngineModelNm"]);
						engineModelList.Add((string)carModelInfoRow["EngineModelNm"]);
					}
					//排気量
					if (!engineDisplaceList.Contains((string)carModelInfoRow["EngineDisplaceNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EngineDisplaceNm"]))
					{
						this._engineDisplaceValueList.ValueListItems.Add(i, (string)carModelInfoRow["EngineDisplaceNm"]);
						engineDisplaceList.Add((string)carModelInfoRow["EngineDisplaceNm"]);
					}
					//E区分
					if (!eDivList.Contains((string)carModelInfoRow["EDivNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EDivNm"]))
					{
						this._eDivValueList.ValueListItems.Add(i, (string)carModelInfoRow["EDivNm"]);
						eDivList.Add((string)carModelInfoRow["EDivNm"]);
					}
					//ミッション
					if (!transmissionList.Contains((string)carModelInfoRow["TransmissionNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["TransmissionNm"]))
					{
						this._transmissionValueList.ValueListItems.Add(i, (string)carModelInfoRow["TransmissionNm"]);
						transmissionList.Add((string)carModelInfoRow["TransmissionNm"]);
					}
					//駆動形式
					if (!wheelDriveMethodList.Contains((string)carModelInfoRow["WheelDriveMethodNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["WheelDriveMethodNm"]))
					{
						this._wheelDriveMethodValueList.ValueListItems.Add(i, (string)carModelInfoRow["WheelDriveMethodNm"]);
						wheelDriveMethodList.Add((string)carModelInfoRow["WheelDriveMethodNm"]);
					}
					//シフト
					if (!shiftList.Contains((string)carModelInfoRow["ShiftNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["ShiftNm"]))
					{
						this._shiftValueList.ValueListItems.Add(i, (string)carModelInfoRow["ShiftNm"]);
						shiftList.Add((string)carModelInfoRow["ShiftNm"]);
					}
				}
				// 型式グリッド表示設定処理
				this.SettingCarSpecGrid();
				for (int i = 0; i < _carModelInfoDataTable.Rows.Count; i++)
				{
					PMKEN01010E.CarModelInfoRow carModelInfoRow = (PMKEN01010E.CarModelInfoRow)_carModelInfoDataTable.Rows[i];
					if ((bool)carModelInfoRow["SelectionState"] == true)
					{
						// 自由検索型式固定番号
						this._freeSrchMdlFxdNo = (string)carModelInfoRow["FreeSrchMdlFxdNo"];
						this.tNedit_MakerCode.SetInt((int)carModelInfoRow["MakerCode"]);
						this.tNedit_ModelCode.SetInt((int)carModelInfoRow["ModelCode"]);
						this.tNedit_ModelSubCode.SetInt((int)carModelInfoRow["ModelSubCode"]);

						// 更新日時の取得
						ArrayList retList = new ArrayList();
						FreeSearchModel freeSearchModel = new FreeSearchModel();
						freeSearchModel.EnterpriseCode = this._enterpriseCode;
						freeSearchModel.FreeSrchMdlFxdNo = this._freeSrchMdlFxdNo;

						int status = this._freeSearchModelAcs.Search(out retList, freeSearchModel);
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							FreeSearchModel freeSearchModel1 = (FreeSearchModel)retList[0];
							this._updateTime = freeSearchModel1.UpdateDateTime;
							// 類別
							this.tNedit_ModelDesignationNo.SetInt(freeSearchModel1.ModelDesignationNo);
							this.tNedit_CategoryNo.SetInt(freeSearchModel1.CategoryNo);
						}

						this.tEdit_ModelFullName.Text = (string)carModelInfoRow["ModelFullName"];
						//型式
						this.tEdit_FullModel.Text = (string)carModelInfoRow["FullModel"];

						// 車種と型式は入力不可
						this.tNedit_MakerCode.Enabled = false;
						this.tNedit_ModelCode.Enabled = false;
						this.tNedit_ModelSubCode.Enabled = false;
						this.uButton_ModelFullGuide.Enabled = false;
						this.tEdit_FullModel.Enabled = false;

						//年式from
						if ((int)carModelInfoRow["StProduceTypeOfYear"] > 0)
						{
							DateTime startEntryDate = TDateTime.LongDateToDateTime("yyyymm", (int)carModelInfoRow["StProduceTypeOfYear"]);
							this.tDateEdit_StartEntryYearDate.Text = startEntryDate.Year.ToString("0000");
							this.tDateEdit_StartEntryMonthDate.Text = startEntryDate.Month.ToString("00");
						}
						//年式to
						if ((int)carModelInfoRow["EdProduceTypeOfYear"] > 0)
						{
							DateTime edEntryDate = TDateTime.LongDateToDateTime("yyyymm", (int)carModelInfoRow["EdProduceTypeOfYear"]);
							this.tDateEdit_EndEntryYearDate.Text = edEntryDate.Year.ToString("0000");
							this.tDateEdit_EndEntryMonthDate.Text = edEntryDate.Month.ToString("00");
						}
						//車台番号
						if ((int)carModelInfoRow["StProduceFrameNo"] > 0)
						{
							this.tEdit_StartProduceFrameNo.Text = ((int)carModelInfoRow["StProduceFrameNo"]).ToString();
						}
						if ((int)carModelInfoRow["EdProduceFrameNo"] > 0)
						{
							this.tEdit_EndProduceFrameNo.Text = ((int)carModelInfoRow["EdProduceFrameNo"]).ToString();
						}
						this._carSpecDataSet = new DataSet();
						PMJKN09001UB.DataSetColumnConstruction(ref this._carSpecDataSet);
						DataRow row = this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].NewRow();
						//諸元情報
						//グレード
						if (!String.IsNullOrEmpty((string)carModelInfoRow["ModelGradeNm"]))
						{
							row[PMJKN09001UB.COL_MODELGRADENM_TITLE] = i;
						}
						//ボディ
						if (!String.IsNullOrEmpty((string)carModelInfoRow["BodyName"]))
						{
							row[PMJKN09001UB.COL_BODYNAME_TITLE] = i;
						}
						//ドア
						if ((int)carModelInfoRow["DoorCount"] != 0)
						{
							row[PMJKN09001UB.COL_DOORCOUNT_TITLE] = i;
						}
						//エンジン
						if (!String.IsNullOrEmpty((string)carModelInfoRow["EngineModelNm"]))
						{
							row[PMJKN09001UB.COL_ENGINEMODELNM_TITLE] = i;
						}
						//排気量
						if (!String.IsNullOrEmpty((string)carModelInfoRow["EngineDisplaceNm"]))
						{
							row[PMJKN09001UB.COL_ENGINEDISPLACENM_TITLE] = i;
						}
						//E区分
						if (!String.IsNullOrEmpty((string)carModelInfoRow["EDivNm"]))
						{
							row[PMJKN09001UB.COL_EDIVNM_TITLE] = i;
						}
						//ミッション
						if (!String.IsNullOrEmpty((string)carModelInfoRow["TransmissionNm"]))
						{
							row[PMJKN09001UB.COL_TRANSMISSIONNM_TITLE] = i;
						}
						//駆動形式
						if (!String.IsNullOrEmpty((string)carModelInfoRow["WheelDriveMethodNm"]))
						{
							row[PMJKN09001UB.COL_WHEELDRIVEMETHODNM_TITLE] = i;
						}
						//シフト
						if (!String.IsNullOrEmpty((string)carModelInfoRow["ShiftNm"]))
						{
							row[PMJKN09001UB.COL_SHIFTNM_TITLE] = i;
						}

						this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].Rows.Add(row);
						this.ultraGrid_CarSpec.DataSource = this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].DefaultView;
						break;
					}
				}
			}
		}

		// ----- ADD 2010/05/16 ------------------->>>>>
		/// <summary>
		/// 車両検索処理
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		private int CarSearchNew(CarSearchCondition condition)
		{
			//------------------------------------------------------
			// 初期処理
			//------------------------------------------------------
			int retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			this._freeSrchMdlFxdNo = String.Empty;
			this._updateTime = new DateTime();

			//------------------------------------------------------
			// カーメーカーコード、車種コード、車種呼称コード設定
			//------------------------------------------------------
			if (condition.Type != CarSearchType.csCategory)
			{
				int makerCd, modelCd, modelSubCd;
				if (int.TryParse(this.tNedit_MakerCode.Text, out makerCd))
				{
					condition.MakerCode = makerCd;
				}
				if (int.TryParse(this.tNedit_ModelCode.Text, out modelCd))
				{
					condition.ModelCode = modelCd;
				}
				if (int.TryParse(this.tNedit_ModelSubCode.Text, out modelSubCd))
				{
					condition.ModelSubCode = modelSubCd;
				}
			}
			//------------------------------------------------------
			// 各種検索処理
			//------------------------------------------------------
			//  CarSearchCondition の検索タイプにより指定
			//------------------------------------------------------
			CarSearchResultReport ret = new CarSearchResultReport();
			PMKEN01010E dat = new PMKEN01010E();
			CarSearchController carSearchController = new CarSearchController();
			ret = carSearchController.Search(condition, ref dat);

			if (ret == CarSearchResultReport.retFailed)
			{
				return retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			}
			else if (ret == CarSearchResultReport.retError)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"検索中にエラーが発生しました。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				return retStatus = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			if ((ret == CarSearchResultReport.retSingleCarModel) || (ret == CarSearchResultReport.retMultipleCarModel))
			{
				SetCarInfoNew(dat);

				return retStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			// --- ADD m.suzuki 2010/06/22 ---------->>>>>
			else if (ret == CarSearchResultReport.retMultipleCarKind)
			{
				MultipleCarSearch(carSearchController, condition, dat);
			}
			// --- ADD m.suzuki 2010/06/22 ----------<<<<<

			return retStatus;
		}

		// --- ADD m.suzuki 2010/06/22 ---------->>>>>
		/// <summary>
		/// 複数車種該当時の諸元情報展開
		/// </summary>
		/// <param name="condition"></param>
		private void MultipleCarSearch(CarSearchController carSearchController, CarSearchCondition condition, PMKEN01010E dat)
		{
			CarSearchResultReport ret = new CarSearchResultReport();

			// 重複チェック用リスト初期化(ｸﾞﾚｰﾄﾞ～ｼﾌﾄで9個)
			ArrayList itemLists = new ArrayList();
			for (int i = 0; i < 9; i++)
			{
				itemLists.Add(new ArrayList());
			}

			// 初期化
			this.ClearValueList();

			// 該当の車種分繰り返す
			foreach (PMKEN01010E.CarKindInfoRow row in dat.CarKindInfo)
			{
				PMKEN01010E retDat = new PMKEN01010E();

				condition.MakerCode = row.MakerCode;
				condition.ModelCode = row.ModelCode;
				condition.ModelSubCode = row.ModelSubCode;

				ret = carSearchController.Search(condition, ref retDat);
				SetCarInfoAppend(retDat, ref itemLists);
			}
		}
		/// <summary>
		/// 諸元情報展開処理（追加型）
		/// </summary>
		/// <param name="dat"></param>
		/// <param name="itemLists"></param>
		private void SetCarInfoAppend(PMKEN01010E dat, ref ArrayList itemLists)
		{
			//車種型式情報
			_carModelInfoDataTable = dat.CarModelInfo;

			if (_carModelInfoDataTable != null && _carModelInfoDataTable.Rows.Count > 0)
			{
				//グレード
				ArrayList modelGradeNmList = (ArrayList)itemLists[0];
				//ボディ
				ArrayList bodyNameList = (ArrayList)itemLists[1];
				//ドア
				ArrayList doorCoutList = (ArrayList)itemLists[2];
				//エンジン
				ArrayList engineModelList = (ArrayList)itemLists[3];
				//排気量
				ArrayList engineDisplaceList = (ArrayList)itemLists[4];
				//E区分
				ArrayList eDivList = (ArrayList)itemLists[5];
				//ミッション
				ArrayList transmissionList = (ArrayList)itemLists[6];
				//駆動形式
				ArrayList wheelDriveMethodList = (ArrayList)itemLists[7];
				//シフト
				ArrayList shiftList = (ArrayList)itemLists[8];
				for (int i = 0; i < _carModelInfoDataTable.Rows.Count; i++)
				{
					PMKEN01010E.CarModelInfoRow carModelInfoRow = (PMKEN01010E.CarModelInfoRow)_carModelInfoDataTable.Rows[i];

					//グレード
					if (!modelGradeNmList.Contains((string)carModelInfoRow["ModelGradeNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["ModelGradeNm"]))
					{
						this._modelGradeValueList.ValueListItems.Add(i, (string)carModelInfoRow["ModelGradeNm"]);
						modelGradeNmList.Add((string)carModelInfoRow["ModelGradeNm"]);
					}
					//ボディ
					if (!bodyNameList.Contains((string)carModelInfoRow["BodyName"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["BodyName"]))
					{
						this._bodyNameValueList.ValueListItems.Add(i, (string)carModelInfoRow["BodyName"]);
						bodyNameList.Add((string)carModelInfoRow["BodyName"]);
					}
					//ドア
					int doorCout = (int)carModelInfoRow["DoorCount"];
					if (!doorCoutList.Contains(doorCout.ToString())
						&& ((int)carModelInfoRow["DoorCount"] != 0))
					{
						this._doorCountValueList.ValueListItems.Add(i, doorCout.ToString());
						doorCoutList.Add(doorCout.ToString());
					}
					//エンジン
					if (!engineModelList.Contains((string)carModelInfoRow["EngineModelNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EngineModelNm"]))
					{
						this._engineModelValueList.ValueListItems.Add(i, (string)carModelInfoRow["EngineModelNm"]);
						engineModelList.Add((string)carModelInfoRow["EngineModelNm"]);
					}
					//排気量
					if (!engineDisplaceList.Contains((string)carModelInfoRow["EngineDisplaceNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EngineDisplaceNm"]))
					{
						this._engineDisplaceValueList.ValueListItems.Add(i, (string)carModelInfoRow["EngineDisplaceNm"]);
						engineDisplaceList.Add((string)carModelInfoRow["EngineDisplaceNm"]);
					}
					//E区分
					if (!eDivList.Contains((string)carModelInfoRow["EDivNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EDivNm"]))
					{
						this._eDivValueList.ValueListItems.Add(i, (string)carModelInfoRow["EDivNm"]);
						eDivList.Add((string)carModelInfoRow["EDivNm"]);
					}
					//ミッション
					if (!transmissionList.Contains((string)carModelInfoRow["TransmissionNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["TransmissionNm"]))
					{
						this._transmissionValueList.ValueListItems.Add(i, (string)carModelInfoRow["TransmissionNm"]);
						transmissionList.Add((string)carModelInfoRow["TransmissionNm"]);
					}
					//駆動形式
					if (!wheelDriveMethodList.Contains((string)carModelInfoRow["WheelDriveMethodNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["WheelDriveMethodNm"]))
					{
						this._wheelDriveMethodValueList.ValueListItems.Add(i, (string)carModelInfoRow["WheelDriveMethodNm"]);
						wheelDriveMethodList.Add((string)carModelInfoRow["WheelDriveMethodNm"]);
					}
					//シフト
					if (!shiftList.Contains((string)carModelInfoRow["ShiftNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["ShiftNm"]))
					{
						this._shiftValueList.ValueListItems.Add(i, (string)carModelInfoRow["ShiftNm"]);
						shiftList.Add((string)carModelInfoRow["ShiftNm"]);
					}
				}
				// 型式グリッド表示設定処理
				this.SettingCarSpecGrid();
			}
		}
		// --- ADD m.suzuki 2010/06/22 ----------<<<<<

		/// <summary>
		/// 車両情報キャッシュ（車両検索情報からキャッシュ）
		/// </summary>
		/// <param name="dat">車種型式情報</param>
		private void SetCarInfoNew(PMKEN01010E dat)
		{
			//車種型式情報
			_carModelInfoDataTable = dat.CarModelInfo;

			this.ClearValueList();

			if (_carModelInfoDataTable != null && _carModelInfoDataTable.Rows.Count > 0)
			{
				//グレード
				ArrayList modelGradeNmList = new ArrayList();
				//ボディ
				ArrayList bodyNameList = new ArrayList();
				//ドア
				ArrayList doorCoutList = new ArrayList();
				//エンジン
				ArrayList engineModelList = new ArrayList();
				//排気量
				ArrayList engineDisplaceList = new ArrayList();
				//E区分
				ArrayList eDivList = new ArrayList();
				//ミッション
				ArrayList transmissionList = new ArrayList();
				//駆動形式
				ArrayList wheelDriveMethodList = new ArrayList();
				//シフト
				ArrayList shiftList = new ArrayList();
				for (int i = 0; i < _carModelInfoDataTable.Rows.Count; i++)
				{
					PMKEN01010E.CarModelInfoRow carModelInfoRow = (PMKEN01010E.CarModelInfoRow)_carModelInfoDataTable.Rows[i];

					//グレード
					if (!modelGradeNmList.Contains((string)carModelInfoRow["ModelGradeNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["ModelGradeNm"]))
					{
						this._modelGradeValueList.ValueListItems.Add(i, (string)carModelInfoRow["ModelGradeNm"]);
						modelGradeNmList.Add((string)carModelInfoRow["ModelGradeNm"]);
					}
					//ボディ
					if (!bodyNameList.Contains((string)carModelInfoRow["BodyName"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["BodyName"]))
					{
						this._bodyNameValueList.ValueListItems.Add(i, (string)carModelInfoRow["BodyName"]);
						bodyNameList.Add((string)carModelInfoRow["BodyName"]);
					}
					//ドア
					int doorCout = (int)carModelInfoRow["DoorCount"];
					if (!doorCoutList.Contains(doorCout.ToString())
						&& ((int)carModelInfoRow["DoorCount"] != 0))
					{
						this._doorCountValueList.ValueListItems.Add(i, doorCout.ToString());
						doorCoutList.Add(doorCout.ToString());
					}
					//エンジン
					if (!engineModelList.Contains((string)carModelInfoRow["EngineModelNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EngineModelNm"]))
					{
						this._engineModelValueList.ValueListItems.Add(i, (string)carModelInfoRow["EngineModelNm"]);
						engineModelList.Add((string)carModelInfoRow["EngineModelNm"]);
					}
					//排気量
					if (!engineDisplaceList.Contains((string)carModelInfoRow["EngineDisplaceNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EngineDisplaceNm"]))
					{
						this._engineDisplaceValueList.ValueListItems.Add(i, (string)carModelInfoRow["EngineDisplaceNm"]);
						engineDisplaceList.Add((string)carModelInfoRow["EngineDisplaceNm"]);
					}
					//E区分
					if (!eDivList.Contains((string)carModelInfoRow["EDivNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["EDivNm"]))
					{
						this._eDivValueList.ValueListItems.Add(i, (string)carModelInfoRow["EDivNm"]);
						eDivList.Add((string)carModelInfoRow["EDivNm"]);
					}
					//ミッション
					if (!transmissionList.Contains((string)carModelInfoRow["TransmissionNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["TransmissionNm"]))
					{
						this._transmissionValueList.ValueListItems.Add(i, (string)carModelInfoRow["TransmissionNm"]);
						transmissionList.Add((string)carModelInfoRow["TransmissionNm"]);
					}
					//駆動形式
					if (!wheelDriveMethodList.Contains((string)carModelInfoRow["WheelDriveMethodNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["WheelDriveMethodNm"]))
					{
						this._wheelDriveMethodValueList.ValueListItems.Add(i, (string)carModelInfoRow["WheelDriveMethodNm"]);
						wheelDriveMethodList.Add((string)carModelInfoRow["WheelDriveMethodNm"]);
					}
					//シフト
					if (!shiftList.Contains((string)carModelInfoRow["ShiftNm"])
						&& !String.IsNullOrEmpty((string)carModelInfoRow["ShiftNm"]))
					{
						this._shiftValueList.ValueListItems.Add(i, (string)carModelInfoRow["ShiftNm"]);
						shiftList.Add((string)carModelInfoRow["ShiftNm"]);
					}
				}
				// 型式グリッド表示設定処理
				this.SettingCarSpecGrid();
			}
		}
		// ----- ADD 2010/05/16 -------------------<<<<<

		# region [車輌情報保持用]
		/// <summary>
		/// 車輌情報保持用
		/// </summary>
		private struct BeforeCarSearchBuffer
		{
			/// <summary>車台番号(開始)</summary>
			private string _startProduceFrameNo;
			/// <summary>車台番号(終了)</summary>
			private string _endProduceFrameNo;
			/// <summary>生産年式(開始)</summary>
			private int _startEntryDate;
			/// <summary>生産年式(終了)</summary>
			private int _endEntryDate;
			/// <summary>
			/// 車台番号(開始)
			/// </summary>
			public string StartProduceFrameNo
			{
				get { return _startProduceFrameNo; }
				set { _startProduceFrameNo = value; }
			}
			/// <summary>
			/// 車台番号(終了)
			/// </summary>
			public string EndProduceFrameNo
			{
				get { return _endProduceFrameNo; }
				set { _endProduceFrameNo = value; }
			}
			/// <summary>
			/// 生産年式(開始)
			/// </summary>
			public int StartEntryDate
			{
				get { return _startEntryDate; }
				set { _startEntryDate = value; }
			}
			/// <summary>
			/// 生産年式(終了)
			/// </summary>
			public int EndEntryDate
			{
				get { return _endEntryDate; }
				set { _endEntryDate = value; }
			}
			/// <summary>
			/// 初期化
			/// </summary>
			public void Clear()
			{
				_startProduceFrameNo = string.Empty;
				_endProduceFrameNo = string.Empty;
				_startEntryDate = 0;
				_endEntryDate = 0;
			}
		}
		# endregion

		/// <summary>
		/// ツールバーボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				#region 終了処理
				//--------------------------------------------------
				// 終了処理
				//--------------------------------------------------
				case "ButtonTool_Close":
					{
						this.Close(true);
						break;
					}
				#endregion

				#region 保存処理
				//--------------------------------------------------
				// 保存処理
				//--------------------------------------------------
				case "ButtonTool_Save":
					{
						this.Save();
						break;
					}
				#endregion

				#region 車種追加処理
				//--------------------------------------------------
				// 車種追加処理
				//--------------------------------------------------
				case "ButtonTool_ModelAdd":
					{
						this.ModelAdd();
						break;
					}
				#endregion

				#region クリア処理
				//--------------------------------------------------
				// クリア処理
				//--------------------------------------------------
				case "ButtonTool_Clear":
					{
						this.Clear(true);
						break;
					}
				#endregion

				#region 削除処理
				//--------------------------------------------------
				// 削除処理
				//--------------------------------------------------
				case "ButtonTool_Delete":
					{
						this.Delete();
						break;
					}
				#endregion

				#region 追加処理
				//--------------------------------------------------
				// 追加処理
				//--------------------------------------------------
				case "ButtonTool_Add":
					{
						this.Add();
						break;
					}
				#endregion

				#region 最新情報処理
				//--------------------------------------------------
				// 最新情報処理
				//--------------------------------------------------
				case "ButtonTool_NewInfo":
					{
						this.Renewal();
						break;
					}
				#endregion
			}

			this.SettingToolBarButtonEnabled();
		}

		/// <summary>
		/// 終了処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		private void Close(bool isConfirm)
		{
			if ((isConfirm) && (this.CheckChangedData()))
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					"現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
					"登録してもよろしいですか？",
					0,
					MessageBoxButtons.YesNoCancel,
					MessageBoxDefaultButton.Button1);

				if (dialogResult == DialogResult.Yes)
				{
					int status = this.Save();
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						this.Close();
					}
				}
				else if (dialogResult == DialogResult.No)
				{
					this.Close();
				}
				else
				{
					return;
				}
			}
			// ----- ADD 2010/05/16 ------------------->>>>>
			else
			{
				this.Close();
			}
			// ----- ADD 2010/05/16 -------------------<<<<<
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		private int Save()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			#region 保存チェック
			//---------------------------------------------------------------
			// 保存データチェック処理
			//---------------------------------------------------------------
			bool check = this.CheckSaveData();

			#endregion

			if (check)
			{
				int model = this.tComboEditor_Model.SelectedIndex;

				FreeSearchModel freeSearchModel = new FreeSearchModel();
				this.DispToFreeSearchModel(ref freeSearchModel, model);

				status = this._freeSearchModelAcs.Write(ref freeSearchModel);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // 保存が成功場合
				{
					// 入力画面を新規モードの初期化処理を行う
					this.Clear(false);

					// ----- ADD 2010/05/16 ------------------->>>>>
					// 類別
					this.tNedit_ModelDesignationNo.Clear();
					this.tNedit_CategoryNo.Clear();

					// 車種（ｶｰﾒｰｶｰｺｰﾄﾞ･車種ｺｰﾄﾞ･車種呼称ｺｰﾄﾞ）
					this.tNedit_MakerCode.Clear();
					this.tNedit_ModelCode.Clear();
					this.tNedit_ModelSubCode.Clear();

					// 型式
					this.tEdit_FullModel.Clear();
					// ----- ADD 2010/05/16 -------------------<<<<<

					this.tComboEditor_Model.SelectedIndex = 0; // 新規
					this.tComboEditor_Model.Focus();

					// ボタンツール有効無効設定処理
					this.SettingToolBarButtonEnabled();

					// ----- ADD 2010/05/16 ------------------->>>>>
					// 登録完了ダイアログ表示
					SaveCompletionDialog dialog = new SaveCompletionDialog();
					dialog.ShowDialog(2);
					// ----- ADD 2010/05/16 -------------------<<<<<
				}
				else
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
						"保存に失敗しました。",
						status,
						MessageBoxButtons.OK);
				}
			}

			return status;
		}

		/// <summary>
		/// 画面情報自由検索型式マスタ クラス格納処理
		/// </summary>
		/// <param name="freeSearchModel">自由検索型式マスタ オブジェクト</param>
		/// <param name="model">モード</param>
		/// <remarks>
		/// <br>Note       : 画面情報から自由検索型式マスタ オブジェクトにデータを格納します。</br>
		/// <br>Programmer : 肖緒徳</br>
		/// <br>Date       : 2010.04.26</br>
		/// </remarks>
		private void DispToFreeSearchModel(ref FreeSearchModel freeSearchModel, int model)
		{
			freeSearchModel.LogicalDeleteCode = 0;

			freeSearchModel.EnterpriseCode = this._enterpriseCode;

			string freeSrchMdlFxdNo = string.Empty;
			if (model == 0)
			{
				freeSrchMdlFxdNo = Guid.NewGuid().ToString().Replace("-", "");
			}
			else
			{
				freeSrchMdlFxdNo = this._freeSrchMdlFxdNo;
				freeSearchModel.UpdateDateTime = this._updateTime;
			}
			freeSearchModel.FreeSrchMdlFxdNo = freeSrchMdlFxdNo; // 自由検索型式固定番号

			freeSearchModel.MakerCode = this.tNedit_MakerCode.GetInt(); //メーカーコード
			freeSearchModel.ModelCode = this.tNedit_ModelCode.GetInt(); // 車種コード
			freeSearchModel.ModelSubCode = this.tNedit_ModelSubCode.GetInt(); // 車種サブコード

			freeSearchModel.FullModel = this.tEdit_FullModel.Text.ToUpper(); // 型式（フル型）

			freeSearchModel.ExhaustGasSign = this._exhaustGasSign;
			freeSearchModel.SeriesModel = this._seriesModel;
			freeSearchModel.CategorySignModel = this._categorySignModel;

			freeSearchModel.ModelDesignationNo = this.tNedit_ModelDesignationNo.GetInt(); // 型式指定番号
			freeSearchModel.CategoryNo = this.tNedit_CategoryNo.GetInt(); // 類別番号

			string stDate = string.Empty;
			if (!String.IsNullOrEmpty(this.tDateEdit_StartEntryYearDate.Text))
			{
				stDate = this.tDateEdit_StartEntryYearDate.Text;
			}
			if (!String.IsNullOrEmpty(this.tDateEdit_StartEntryMonthDate.Text))
			{
				stDate += this.tDateEdit_StartEntryMonthDate.Text;
			}
			if (!string.IsNullOrEmpty(stDate))
			{
				freeSearchModel.StProduceTypeOfYear = TDateTime.LongDateToDateTime("YYYYMM", Convert.ToInt32(stDate)); // 開始生産年式
			}

			string edDate = string.Empty;
			if (!String.IsNullOrEmpty(this.tDateEdit_EndEntryYearDate.Text))
			{
				edDate = this.tDateEdit_EndEntryYearDate.Text;
			}
			if (!String.IsNullOrEmpty(this.tDateEdit_EndEntryMonthDate.Text))
			{
				edDate += this.tDateEdit_EndEntryMonthDate.Text;
			}
			if (!string.IsNullOrEmpty(edDate))
			{
				freeSearchModel.EdProduceTypeOfYear = TDateTime.LongDateToDateTime("YYYYMM", Convert.ToInt32(edDate)); // 終了生産年式
			}

			if (!string.IsNullOrEmpty(this.tEdit_StartProduceFrameNo.Text))
			{
				freeSearchModel.StProduceFrameNo = Convert.ToInt32(this.tEdit_StartProduceFrameNo.Text); // 生産車台番号開始
			}

			if (!string.IsNullOrEmpty(this.tEdit_EndProduceFrameNo.Text))
			{
				freeSearchModel.EdProduceFrameNo = Convert.ToInt32(this.tEdit_EndProduceFrameNo.Text); //生産車台番号終了
			}

			// 諸元情報
			// 型式グレード名称
			string modelGradeNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_MODELGRADENM_TITLE].Text.ToString();
			freeSearchModel.ModelGradeNm = modelGradeNm;

			// ボディー名称
			string bodyName = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_BODYNAME_TITLE].Text.ToString();
			freeSearchModel.BodyName = bodyName;

			// ドア数
			string doorCount = (string)this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_DOORCOUNT_TITLE].Text.ToString();
			freeSearchModel.DoorCount = String.IsNullOrEmpty(doorCount) ? 0 : Convert.ToInt32(doorCount);

			// エンジン型式名称
			string engineModelNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_ENGINEMODELNM_TITLE].Text.ToString();
			freeSearchModel.EngineModelNm = engineModelNm;

			// 排気量名称
			string engineDisplaceNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_ENGINEDISPLACENM_TITLE].Text.ToString();
			freeSearchModel.EngineDisplaceNm = engineDisplaceNm;

			// E区分名称
			string eDivNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_EDIVNM_TITLE].Text.ToString();
			freeSearchModel.EDivNm = eDivNm;

			// ミッション名称
			string transmissionNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_TRANSMISSIONNM_TITLE].Text.ToString();
			freeSearchModel.TransmissionNm = transmissionNm;

			// 駆動方式名称
			string wheelDriveMethodNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_WHEELDRIVEMETHODNM_TITLE].Text.ToString();
			freeSearchModel.WheelDriveMethodNm = wheelDriveMethodNm;

			// シフト名称
			string shiftNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_SHIFTNM_TITLE].Text.ToString();
			freeSearchModel.ShiftNm = shiftNm;

			if (model == 0)
			{
				// 作成日付
				int createDate = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.Now);
				freeSearchModel.CreateDate = createDate;

				// 更新年月日
				freeSearchModel.UpdateDate = createDate;
			}
			else
			{
				// 更新日付
				int updateDate = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.Now);

				// 更新年月日
				freeSearchModel.UpdateDate = updateDate;
			}
		}

		#region [型式（フル型）の判断]
		/// <summary>
		/// 型式（フル型）の判断処理
		/// </summary>
		/// <param name="fullModels">型式結果</param>
		/// <param name="modelName">型式（フル型）</param>
		/// <returns>処理結果</returns>
		/// <remarks>
		/// <br>Programmer : 肖緒徳</br>
		/// <br>Date       : 2010/04/30</br>
		/// </remarks>
		private bool CheckModelName(string modelName)
		{
			string msg = string.Empty;

			if (string.IsNullOrEmpty(modelName))
			{
				msg = "型式を入力して下さい。";
				// メッセージを表示
				this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
				return false;
			}

			//型式（フル型）
			string[] fullModels = modelName.Split('-');

			string zrModel = string.Empty;
			string frModel = string.Empty;
			string sdModel = string.Empty;

			//先頭の要素が４桁以上のため、第１要素が存在しない
			if (fullModels[0].Length >= 4)
			{
				frModel = fullModels[0]; // 型式１にする
				for (int i = 1; i < fullModels.Length; i++)
				{
					sdModel += fullModels[i];
					if (i != fullModels.Length - 1)
					{
						sdModel += "-";
					}
				} // 型式２
			}
			else
			{
				zrModel = fullModels[0]; // 型式０
				if (fullModels.Length > 1)
				{
					frModel = fullModels[1]; // 型式１
					for (int i = 2; i < fullModels.Length; i++)
					{
						sdModel += fullModels[i];
						if (i != fullModels.Length - 1)
						{
							sdModel += "-";
						}
					} // 型式２
				}
			}

			if (zrModel.Length >= 5)
			{
				msg = "型式０を４文字以下にして下さい。";
				// メッセージを表示
				this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
				return false;
			}
			if (frModel.Length >= 16)
			{
				msg = "型式１を１５文字以下にして下さい。";
				// メッセージを表示
				this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
				return false;
			}
			if (sdModel.Length >= 16)
			{
				msg = "型式２を１５文字以下にして下さい。";
				// メッセージを表示
				this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
				return false;
			}

			// 分解した結果、型式２が0桁の場合
			if (String.IsNullOrEmpty(sdModel))
			{
				// 型式１の桁数が0桁の場合は、型式０を型式１とする
				if (String.IsNullOrEmpty(frModel))
				{
					frModel = zrModel;
					zrModel = string.Empty;
				}
				// 型式０が存在し、型式１が数字で始まる場合は、型式０を型式１、型式１を型式２とする
				if (!String.IsNullOrEmpty(zrModel)
					&& (!String.IsNullOrEmpty(frModel) && frModel.ToCharArray()[0] <= '9' && frModel.ToCharArray()[0] >= '0'))
				{
					sdModel = frModel;
					frModel = zrModel;
					zrModel = string.Empty;
				}
			}

			this._exhaustGasSign = zrModel;
			this._seriesModel = frModel;
			this._categorySignModel = sdModel;

			return true;
		}
		#endregion

		/// <summary>
		/// 保存データチェック処理
		/// </summary>
		/// <returns></returns>
		private bool CheckSaveData()
		{
			bool flg = true;

			#region 画面入力値チェック
			// 類別(型式指定)
			if (!String.IsNullOrEmpty(this.tNedit_ModelDesignationNo.Text))
			{
				char[] chs = this.tNedit_ModelDesignationNo.Text.ToCharArray();
				foreach (char ch in chs)
				{
					if (!this.IsNum(ch))
					{
						DialogResult dialogResult = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_EXCLAMATION,
												this.Name,
												"数値を入力して下さい。",
												0,
												MessageBoxButtons.OK,
												MessageBoxDefaultButton.Button1);

						this.tNedit_ModelDesignationNo.Focus();
						this._prevControl = this.tNedit_ModelDesignationNo;
						return false;
					}
				}
			}

			// 類別(類別区分) 
			if (!String.IsNullOrEmpty(this.tNedit_CategoryNo.Text))
			{
				char[] chs = this.tNedit_CategoryNo.Text.ToCharArray();
				foreach (char ch in chs)
				{
					if (!this.IsNum(ch))
					{
						DialogResult dialogResult = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_EXCLAMATION,
												this.Name,
												"数値を入力して下さい。",
												0,
												MessageBoxButtons.OK,
												MessageBoxDefaultButton.Button1);

						this.tNedit_CategoryNo.Focus();
						this._prevControl = this.tNedit_CategoryNo;
						return false;
					}
				}
			}

			// 車種
			if (String.IsNullOrEmpty(this.tEdit_ModelFullName.Text) || un_INSERT.Equals(this.tEdit_ModelFullName.Text))
			{
				if (this.tNedit_MakerCode.GetInt() == 0
					&& this.tNedit_ModelCode.GetInt() == 0
					&& this.tNedit_ModelSubCode.GetInt() == 0)
				{
					DialogResult dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"車種を入力して下さい。",
						0,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
				}
				else
				{
					DialogResult dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"車種が入力不正です。",
						0,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
				}

				// 指定フォーカス設定処理
				this.tNedit_MakerCode.Focus();
				this._prevControl = this.tNedit_MakerCode;
				return false;
			}

			// 型式
			if (String.IsNullOrEmpty(this.tEdit_FullModel.Text))
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"型式を入力して下さい。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				// 指定フォーカス設定処理
				this.tEdit_FullModel.Focus();
				this._prevControl = this.tEdit_FullModel;

				return false;
			}

			if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text))
			{
				char[] chs = this.tEdit_FullModel.Text.ToCharArray();
				foreach (char ch in chs)
				{
					if (!(this.IsNum(ch) || this.IsNumSign(ch) || this.IsAlpha(ch)))
					{
						DialogResult dialogResult = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_EXCLAMATION,
												this.Name,
												"英数字を入力して下さい。",
												0,
												MessageBoxButtons.OK,
												MessageBoxDefaultButton.Button1);
						// 指定フォーカス設定処理
						this.tEdit_FullModel.Focus();
						this._prevControl = this.tEdit_FullModel;

						return false;
					}
				}
			}

			// 型式の判断
			if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text))
			{
				string fullModel = this.tEdit_FullModel.Text;

				bool flag = false;
				flag = this.CheckModelName(fullModel);

				if (!flag)
				{
					this.tEdit_FullModel.Focus();
					this._prevControl = this.tEdit_FullModel;
					return false;
				}
			}
			// ----- UPD 2010/05/16 ------------------->>>>>
			string stYM = this.tDateEdit_StartEntryYearDate.Text + "." + this.tDateEdit_StartEntryMonthDate.Text;
			// 開始年式
			if ((!String.IsNullOrEmpty(this.tDateEdit_StartEntryYearDate.Text) && String.IsNullOrEmpty(this.tDateEdit_StartEntryMonthDate.Text)) ||
				(String.IsNullOrEmpty(this.tDateEdit_StartEntryYearDate.Text) && !String.IsNullOrEmpty(this.tDateEdit_StartEntryMonthDate.Text)) ||
				("0001.01".Equals(stYM)) || ("0001.1".Equals(stYM)) || ("1.01".Equals(stYM)))
			// ----- UPD 2010/05/16 -------------------<<<<<
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"開始年式が入力不正です。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				// 指定フォーカス設定処理
				this.tDateEdit_StartEntryYearDate.Focus();
				this._prevControl = this.tDateEdit_StartEntryYearDate;

				return false;
			}

			if (!String.IsNullOrEmpty(this.tDateEdit_StartEntryMonthDate.Text)
				&& this.tDateEdit_StartEntryMonthDate.Text.CompareTo("12") > 0)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"開始年式が入力不正です。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				// 指定フォーカス設定処理
				this.tDateEdit_StartEntryMonthDate.Focus();
				this._prevControl = this.tDateEdit_StartEntryMonthDate;

				return false;
			}
			// ----- UPD 2010/05/16 ------------------->>>>>
			string endYM = this.tDateEdit_EndEntryYearDate.Text + "." + this.tDateEdit_EndEntryMonthDate.Text;

			// 終了年式
			if ((!String.IsNullOrEmpty(this.tDateEdit_EndEntryYearDate.Text) && String.IsNullOrEmpty(this.tDateEdit_EndEntryMonthDate.Text)) ||
				(String.IsNullOrEmpty(this.tDateEdit_EndEntryYearDate.Text) && !String.IsNullOrEmpty(this.tDateEdit_EndEntryMonthDate.Text)) ||
				("0001.01".Equals(endYM)) || ("0001.1".Equals(endYM)) || ("1.01".Equals(endYM)))
			// ----- UPD 2010/05/16 -------------------<<<<<
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"終了年式が入力不正です。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				// 指定フォーカス設定処理
				this.tDateEdit_EndEntryYearDate.Focus();
				this._prevControl = this.tDateEdit_EndEntryYearDate;

				return false;
			}

			if (!String.IsNullOrEmpty(this.tDateEdit_EndEntryMonthDate.Text)
				&& this.tDateEdit_EndEntryMonthDate.Text.CompareTo("12") > 0)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"終了年式が入力不正です。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				// 指定フォーカス設定処理
				this.tDateEdit_EndEntryMonthDate.Focus();
				this._prevControl = this.tDateEdit_EndEntryMonthDate;

				return false;
			}


			string stDate = string.Empty;
			if (!String.IsNullOrEmpty(this.tDateEdit_StartEntryYearDate.Text))
			{
				stDate = this.tDateEdit_StartEntryYearDate.Text;
			}
			if (!String.IsNullOrEmpty(this.tDateEdit_StartEntryMonthDate.Text))
			{
				stDate += this.tDateEdit_StartEntryMonthDate.Text;
			}

			string edDate = string.Empty;
			if (!String.IsNullOrEmpty(this.tDateEdit_EndEntryYearDate.Text))
			{
				edDate = this.tDateEdit_EndEntryYearDate.Text;
			}
			if (!String.IsNullOrEmpty(this.tDateEdit_EndEntryMonthDate.Text))
			{
				edDate += this.tDateEdit_EndEntryMonthDate.Text;
			}
			if (!string.IsNullOrEmpty(edDate) && !string.IsNullOrEmpty(stDate))
			{
				// 開始日付＞終了日付となる日付が入力
				if (stDate.CompareTo(edDate) > 0)
				{
					DialogResult dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"開始日付以上の日付を入力して下さい。",
						0,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);

					// 指定フォーカス設定処理
					this.tDateEdit_EndEntryYearDate.Focus();
					this._prevControl = this.tDateEdit_EndEntryYearDate;
					return false;
				}
			}

			// 生産車台番号
			int stProduceFrameNo = 0;
			if (!string.IsNullOrEmpty(this.tEdit_StartProduceFrameNo.Text))
			{
				stProduceFrameNo = Convert.ToInt32(this.tEdit_StartProduceFrameNo.Text); // 生産車台番号開始
			}

			// int edProduceFrameNo = 0; // DEL 2010/05/20
			int edProduceFrameNo = 99999999; // ADD 2010/05/20
			if (!string.IsNullOrEmpty(this.tEdit_EndProduceFrameNo.Text))
			{
				edProduceFrameNo = Convert.ToInt32(this.tEdit_EndProduceFrameNo.Text); //生産車台番号終了
			}
			if (stProduceFrameNo > edProduceFrameNo)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"開始番号以上の番号を入力して下さい。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				// 指定フォーカス設定処理
				this.tEdit_EndProduceFrameNo.Focus();

				this._prevControl = this.tEdit_EndProduceFrameNo;

				return false;
			}

			// ドア
			string dorCnt = this.ultraGrid_CarSpec.Rows[0].Cells[2].Text.ToString();

			if (!String.IsNullOrEmpty(dorCnt))
			{
				char[] chars = dorCnt.ToCharArray();
				foreach (char ch in chars)
				{
					if (ch.CompareTo('0') < 0 || ch.CompareTo('9') > 0)
					{
						DialogResult dialogResult = TMsgDisp.Show(
							 this,
							 emErrorLevel.ERR_LEVEL_EXCLAMATION,
							 this.Name,
							 "数字を入力して下さい。",
							 0,
							 MessageBoxButtons.OK,
							 MessageBoxDefaultButton.Button1);

						this.ultraGrid_CarSpec.Focus();
						this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_DOORCOUNT_TITLE].Activate();
						this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);

						return false;
					}
				}
			}
			#endregion

			return flg;
		}

		/// <summary>
		/// 編集中データチェック処理
		/// </summary>
		/// <returns></returns>
		private bool CheckChangedData()
		{
			bool flg = false;

			#region 画面入力値チェック
			if (this.tNedit_MakerCode.GetInt() != 0)//メーカーコード
			{
				return true;
			}

			if (this.tNedit_ModelCode.GetInt() != 0) // 車種コード
			{
				return true;
			}

			if (this.tNedit_ModelSubCode.GetInt() != 0) // 車種サブコード
			{
				return true;
			}

			if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text)) // 型式（フル型）
			{
				return true;
			}

			if (this.tNedit_ModelDesignationNo.GetInt() != 0)// 型式指定番号
			{
				return true;
			}

			if (this.tNedit_CategoryNo.GetInt() != 0) // 類別番号
			{
				return true;
			}

			if (!String.IsNullOrEmpty(this.tDateEdit_StartEntryYearDate.Text))
			{
				return true;
			}

			if (!String.IsNullOrEmpty(this.tDateEdit_StartEntryMonthDate.Text))
			{
				return true;
			}

			if (!String.IsNullOrEmpty(this.tDateEdit_EndEntryYearDate.Text))
			{
				return true;
			}

			if (!String.IsNullOrEmpty(this.tDateEdit_EndEntryMonthDate.Text))
			{
				return true;
			}

			if (!String.IsNullOrEmpty(this.tEdit_StartProduceFrameNo.Text))
			{
				return true;
			}

			if (!String.IsNullOrEmpty(this.tEdit_EndProduceFrameNo.Text))
			{
				return true;
			}

			if (this.ultraGrid_CarSpec.Rows.Count > 1 && !this.ultraGrid_CarSpec.Rows[1].IsEmptyRow)
			{
				return true;
			}
			#endregion

			return flg;
		}

		/// <summary>
		/// 保存確認ダイアログ表示処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <returns>確認後OK 確認後NG</returns>
		private bool ShowSaveCheckDialog(bool isConfirm)
		{
			bool checkedValue = false;

			if ((isConfirm) && (this.CheckChangedData()))
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					"現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
					"登録してもよろしいですか？",
					0,
					MessageBoxButtons.YesNoCancel,
					MessageBoxDefaultButton.Button1);

				if (dialogResult == DialogResult.Yes)
				{
					this.Save();
				}
				else if (dialogResult == DialogResult.No)
				{
					// 入力画面を新規モードの初期化処理を行う
					this.Clear(false);

					// ----- UPD 2010/05/16 ------------------->>>>>
					//　画面値再設定フラグ
					this._valueChageFlg = true;
					this.tComboEditor_Model.SelectedIndex = 0; // 新規
					this.tComboEditor_Model.Focus();
					//　画面値再設定フラグ
					this._valueChageFlg = false;
					if (this._clearChangeFlg == true)
					{
						// ----- UPD 2010/05/20 ------------------->>>>>
						if (!string.IsNullOrEmpty(tNedit_ModelCode.Text))
						{
							this.tNedit_ModelCode.Enabled = true;
							this.tNedit_ModelSubCode.Enabled = true;
						}
						else
						{
							this.tNedit_ModelCode.Enabled = true;
						}
						// ----- UPD 2010/05/20 -------------------<<<<<
						//this.tEdit_FullModel.Focus(); // DEL 2010/06/22
					}
					this._clearChangeFlg = false;
					// ----- ADD 2010/05/20 ------------------->>>>>
					if (this._clearUpdateFlg == true)
					{
						this.tComboEditor_Model.SelectedIndex = 1;//更新
					}
					this._clearUpdateFlg = false;
					// ----- ADD 2010/05/20 -------------------<<<<<
					// ----- UPD 2010/05/16 -------------------<<<<<

					// ボタンツール有効無効設定処理
					this.SettingToolBarButtonEnabled();
				}
				else
				{
					return false;
				}
			}
			else
			{
				checkedValue = true;
			}

			return checkedValue;
		}

		/// <summary>
		/// クリア処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <remarks>
		/// <br>Note        : クリアをクリック時に発生します。</br>      
		/// <br>Programmer  : 肖緒徳</br>
		/// <br>Date        : 2010.04.26</br>
		/// </remarks> 
		private void Clear(bool isConfirm)
		{
			bool canClear = this.ShowSaveCheckDialog(isConfirm);
			if (canClear)
			{
				// ----- UPD 2010/05/16 ------------------->>>>>
				//if ((this.tEdit_FullModel.Enabled == true) || (this.tComboEditor_Model.SelectedIndex == 1)) // DEL 2010/06/22
				//{ // DEL 2010/06/22
				// 類別
				this.tNedit_ModelDesignationNo.Clear();
				this.tNedit_CategoryNo.Clear();

				// 車種（ｶｰﾒｰｶｰｺｰﾄﾞ･車種ｺｰﾄﾞ･車種呼称ｺｰﾄﾞ）
				this.tNedit_MakerCode.Clear();
				this.tNedit_ModelCode.Clear();
				this.tNedit_ModelSubCode.Clear();

				// 型式
				this.tEdit_FullModel.Clear();
				//} // DEL 2010/06/22
				// ----- UPD 2010/05/16 -------------------<<<<<
				if (this.tComboEditor_Model.SelectedIndex == 1)
				{
					this._clearUpdateFlg = true;
				}

				// 生産年式
				this.tDateEdit_StartEntryYearDate.Clear();
				this.tDateEdit_StartEntryMonthDate.Clear();
				this.tDateEdit_EndEntryYearDate.Clear();
				this.tDateEdit_EndEntryMonthDate.Clear();

				// 車台番号
				this.tEdit_StartProduceFrameNo.Clear();
				this.tEdit_EndProduceFrameNo.Clear();

				this._carSpecDataSet.Clear();
				this.ClearValueList();

				PMJKN09001UB.DataSetColumnConstruction(ref this._carSpecDataSet);
				DataRow row = this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].NewRow();
				this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].Rows.Add(row);
				this.ultraGrid_CarSpec.DataSource = this._carSpecDataSet.Tables[PMJKN09001UB.TBL_CARSPECVIEW].DefaultView;
				// 型式グリッド表示設定処理
				this.SettingCarSpecGrid();

				this._updateTime = new DateTime();
				this._freeSrchMdlFxdNo = string.Empty;

				this.SettingToolBarButtonEnabled();
				// ----- ADD 2010/05/16 ------------------->>>>>
				// ボタン有効無効設定処理
				this.InitialSettingButtonEnabled();
				this.tToolbarsManager_MainMenu.Tools["ButtonTool_ModelAdd"].SharedProps.Enabled = false;
				this.tComboEditor_Model.Focus();
				// ----- ADD 2010/05/16 -------------------<<<<<
			}
		}

		/// <summary>
		/// 車種追加処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 車種追加をクリック時に発生します。</br>      
		/// <br>Programmer  : 肖緒徳</br>
		/// <br>Date        : 2010.04.26</br>
		/// </remarks> 
		private void ModelAdd()
		{
			// メーカー、車種コード、呼称コード
			string maker = this.tNedit_MakerCode.Text;
			string modelCode = this.tNedit_ModelCode.Text;
			string modelSubCode = this.tNedit_ModelSubCode.Text;

			// flg(true:他の画面から、false:自身)
			bool flg = true;
			PMKHN09030UA pMKHN09030UA = new PMKHN09030UA(maker, modelCode, modelSubCode, flg);
			pMKHN09030UA.Show();
		}

		/// <summary>
		/// 削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 削除をクリック時に発生します。</br>      
		/// <br>Programmer  : 肖緒徳</br>
		/// <br>Date        : 2010.04.26</br>
		/// </remarks> 
		private void Delete()
		{
			if (true)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					"データを物理削除します。" + "\r\n" + "\r\n" +
					"よろしいですか？",
					0,
					MessageBoxButtons.OKCancel,
					MessageBoxDefaultButton.Button2);

				if (dialogResult == DialogResult.OK)
				{
					int isDelete = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

					FreeSearchModel freeSearchModel = new FreeSearchModel();

					if (!String.IsNullOrEmpty(this._freeSrchMdlFxdNo))
					{
						freeSearchModel.FreeSrchMdlFxdNo = this._freeSrchMdlFxdNo;
						freeSearchModel.UpdateDateTime = this._updateTime;
					}
					else
					{

					}

					freeSearchModel.EnterpriseCode = this._enterpriseCode;

					isDelete = this._freeSearchModelAcs.Delete(freeSearchModel);
					// アクセスクラスの物理削除処理
					if (isDelete == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						//入力画面を新規モードの初期化処理を行う
						// クリア処理
						this.Clear(false);
						this.tComboEditor_Model.SelectedIndex = 0;
						this.tComboEditor_Model.Focus();
					}
				}
				else if (dialogResult == DialogResult.Cancel)
				{
					this._prevControl = this.tDateEdit_StartEntryYearDate;//ADD 2010/05/16
					return;
				}
			}

		}

		/// <summary>
		/// 追加処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 追加をクリック時に発生します。</br>      
		/// <br>Programmer  : 肖緒徳</br>
		/// <br>Date        : 2010.04.26</br>
		/// </remarks> 
		private void Add()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			#region 保存チェック
			//---------------------------------------------------------------
			// 保存データチェック処理
			//---------------------------------------------------------------
			bool check = this.CheckSaveData();

			if (check)
			{
				if (check)
				{
					int model = 0; // 追加(新規)

					FreeSearchModel freeSearchModel = new FreeSearchModel();
					this.DispToFreeSearchModel(ref freeSearchModel, model);

					status = this._freeSearchModelAcs.Write(ref freeSearchModel);

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // 保存が成功場合
					{
						// 入力画面を新規モードの初期化処理を行う
						this.Clear(false);

						this.tComboEditor_Model.SelectedIndex = 0; // 新規
						this.tComboEditor_Model.Focus();

						// ボタンツール有効無効設定処理
						this.SettingToolBarButtonEnabled();

						// ----- ADD 2010/05/16 ------------------->>>>>
						// 登録完了ダイアログ表示
						SaveCompletionDialog dialog = new SaveCompletionDialog();
						dialog.ShowDialog(2);
						// ----- ADD 2010/05/16 -------------------<<<<<
					}
					else
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							this.Name,
							"保存に失敗しました。",
							status,
							MessageBoxButtons.OK);
					}
				}

			}
			#endregion
		}

		# region ■ 最新情報処理 ■
		/// <summary>
		/// 画面最新情報処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 最新情報をクリック時に発生します。</br>      
		/// <br>Programmer  : 肖緒徳</br>
		/// <br>Date        : 2010.04.26</br>
		/// </remarks> 
		private void Renewal()
		{
			this.RenewalProc();
		}

		/// <summary>
		/// 画面最新情報処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 最新情報をクリック時に発生します。</br>      
		/// <br>Programmer  : 肖緒徳</br>
		/// <br>Date        : 2010.04.26</br>
		/// </remarks> 
		private void RenewalProc()
		{
			// メーカーマスタ
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			ModelNameU modelNameU = new ModelNameU();
			ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
			if (this.tNedit_MakerCode.GetInt() != 0)
			{
				status = modelNameUAcs.Read(out modelNameU, this._enterpriseCode, this.tNedit_MakerCode.GetInt(), this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt()); ;
			}
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.tNedit_MakerCode.SetInt(modelNameU.MakerCode);
				this.tNedit_ModelCode.SetInt(modelNameU.ModelCode);
				this.tNedit_ModelSubCode.SetInt(modelNameU.ModelSubCode);
				this.tEdit_ModelFullName.Text = modelNameU.ModelFullName;
			}

			string msg = "最新情報を取得しました。";
			// メッセージを表示
			this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, msg, 0);
		}
		# endregion

		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note        : エラーメッセージ表示処理</br>
		/// <br>Programmer  : 肖緒徳</br>
		/// <br>Date        : 2010.04.26</br>
		/// </remarks>
		private void MsgDispProc(emErrorLevel iLevel, string message, int status)
		{
			TMsgDisp.Show(
				iLevel,        // エラーレベル
				"PMJKN09000UA",      // アセンブリＩＤまたはクラスＩＤ
				ct_PRINTNAME,            // プログラム名称
				"",         // 処理名称
				"",         // オペレーション
				message,       // 表示するメッセージ
				status,        // ステータス値
				null,         // エラーが発生したオブジェクト
				MessageBoxButtons.OK,     // 表示するボタン
				MessageBoxDefaultButton.Button1); // 初期表示ボタン
		}

		/// <summary>
		/// モードドロップダウン変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_Model_ValueChanged(object sender, EventArgs e)
		{
			// ----- ADD 2010/05/16 ------------------->>>>>
			// 画面値再設定を実行中ですか判断
			if (true == _valueChageFlg)
				return;
			// ----- ADD 2010/05/16 -------------------<<<<<

			bool isChanged = false;

			isChanged = this.CheckChangedData();

			if (isChanged)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					"現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
					"登録してもよいですか？",
					0,
					MessageBoxButtons.YesNoCancel);

				if (dialogResult == DialogResult.Yes)
				{
					// 保存処理
					this.CheckSaveData();

					FreeSearchModel freeSearchModel = new FreeSearchModel();
					this.DispToFreeSearchModel(ref freeSearchModel, 1 - this.tComboEditor_Model.SelectedIndex);

					int status = this._freeSearchModelAcs.Write(ref freeSearchModel);

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // 保存が成功場合
					{
						// 入力画面を新規モードの初期化処理を行う
						this.Clear(false);

						this.tComboEditor_Model.SelectedIndex = 0; // 新規
						this.tComboEditor_Model.Focus();

						// ボタンツール有効無効設定処理
						this.SettingToolBarButtonEnabled();
						// ----- ADD 2010/05/16 ------------------->>>>>
						// ボタン有効無効設定処理
						this.InitialSettingButtonEnabled();
						// 登録完了ダイアログ表示
						SaveCompletionDialog dialog = new SaveCompletionDialog();
						dialog.ShowDialog(2);
						// ----- ADD 2010/05/16 -------------------<<<<<
					}
					else
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							this.Name,
							"保存に失敗しました。",
							status,
							MessageBoxButtons.OK);
					}
				}
				else if (dialogResult == DialogResult.No)
				{
					// 保存処理は行わず、入力画面を新規モードの初期化処理を行う
					this.Clear(false);

					this.tComboEditor_Model.Focus();

					// ボタンツール有効無効設定処理
					this.SettingToolBarButtonEnabled();
					// ----- ADD 2010/05/16 ------------------->>>>>
					// ボタン有効無効設定処理
					this.InitialSettingButtonEnabled();
					// ----- ADD 2010/05/16 -------------------<<<<<
				}
				else
				{
					this.tComboEditor_Model.ValueChanged -= new EventHandler(tComboEditor_Model_ValueChanged);
					if (this.tComboEditor_Model.SelectedIndex == 0)
					{
						this.tComboEditor_Model.SelectedIndex = 1;
					}
					else
					{
						this.tComboEditor_Model.SelectedIndex = 0;
					}
					this.tComboEditor_Model.ValueChanged += new EventHandler(tComboEditor_Model_ValueChanged);

					// 保存処理は行わず、データ入力画面に戻る
					return;
				}
			}

			if (this.tComboEditor_Model.SelectedIndex == 0)
			{
				this.Mode_Label.Text = "新規モード";
			}
			else
			{
				this.Mode_Label.Text = "更新モード";
			}
			this.SettingToolBarButtonEnabled();
		}

		/// <summary>
		/// tNedit_MakerCode_ValueChangedイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_MakerCode_ValueChanged(object sender, EventArgs e)
		{
			string makerCode = this.tNedit_MakerCode.Text;
			if (string.IsNullOrEmpty(makerCode))
			{
				//車種ｺｰﾄ
				this.tNedit_ModelCode.Clear();
				this.tNedit_ModelCode.Enabled = false;
				//車種呼称ｺｰﾄ
				this.tNedit_ModelSubCode.Clear();
				this.tNedit_ModelSubCode.Enabled = false;
				//車種名称
				this.tEdit_ModelFullName.Clear();
			}
			else
			{
				//車種ｺｰﾄ
				this.tNedit_ModelCode.Enabled = true;
			}
		}

		/// <summary>
		/// tNedit_ModelCode_ValueChangedイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_ModelCode_ValueChanged(object sender, EventArgs e)
		{
			string modelCode = this.tNedit_ModelCode.Text;
			if (string.IsNullOrEmpty(modelCode))
			{
				//車種呼称ｺｰﾄ
				this.tNedit_ModelSubCode.Clear();
				this.tNedit_ModelSubCode.Enabled = false;
				//車種名称
				this.tEdit_ModelFullName.Clear();
			}
			else
			{
				//車種呼称ｺｰﾄ
				this.tNedit_ModelSubCode.Enabled = true;
			}
		}

		/// <summary>
		/// tNedit_ModelSubCode_ValueChangedイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_ModelSubCode_ValueChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.tNedit_ModelSubCode.Text))
			{
				//車種名称
				this.tEdit_ModelFullName.Clear();
			}
		}

		// ----- ADD 2010/05/16 ------------------->>>>>
		/// <summary>
		/// tEdit_StartProduceFrameNo_ValueChangedイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tEdit_StartProduceFrameNo_ValueChanged(object sender, EventArgs e)
		{
			string produceFrameNo = this.tEdit_StartProduceFrameNo.Text;
			if (string.IsNullOrEmpty(produceFrameNo))
			{
				this.tEdit_EndProduceFrameNo.Enabled = false;
			}
			else
			{
				this.tEdit_EndProduceFrameNo.Enabled = true;
			}
		}
		// ----- ADD 2010/05/16 -------------------<<<<<

		// ----- ADD 2010/06/22 ------------------->>>>>
		/// <summary>
		/// tEdit_EndProduceFrameNo_ValueChangedイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tEdit_EndProduceFrameNo_ValueChanged(object sender, EventArgs e)
		{
			string endProduceFrameNo = this.tEdit_EndProduceFrameNo.Text;
			if (string.IsNullOrEmpty(endProduceFrameNo))
			{
				this.tEdit_EndProduceFrameNo.Enabled = false;
			}
			else
			{
				this.tEdit_EndProduceFrameNo.Enabled = true;
			}
		}

		/// <summary>
		/// tDateEdit_StartEntryYearDate_ValueChangedイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tDateEdit_StartEntryYearDate_ValueChanged(object sender, EventArgs e)
		{
			if (("0001".Equals(tDateEdit_StartEntryYearDate.Text)) && ("01".Equals(tDateEdit_StartEntryMonthDate.Text)))
			{
				tDateEdit_StartEntryYearDate.Clear();
				tDateEdit_StartEntryMonthDate.Clear();
			}
		}

		/// <summary>
		/// tDateEdit_StartEntryMonthDate_ValueChangedイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tDateEdit_StartEntryMonthDate_ValueChanged(object sender, EventArgs e)
		{
			if (("0001".Equals(tDateEdit_StartEntryYearDate.Text)) && ("01".Equals(tDateEdit_StartEntryMonthDate.Text)))
			{
				tDateEdit_StartEntryYearDate.Clear();
				tDateEdit_StartEntryMonthDate.Clear();
			}
		}

		/// <summary>
		/// tDateEdit_EndEntryYearDate_ValueChangedイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tDateEdit_EndEntryYearDate_ValueChanged(object sender, EventArgs e)
		{
			if (("0001".Equals(tDateEdit_EndEntryYearDate.Text)) && ("01".Equals(tDateEdit_EndEntryMonthDate.Text)))
			{
				tDateEdit_EndEntryYearDate.Clear();
				tDateEdit_EndEntryMonthDate.Clear();
			}
		}

		/// <summary>
		/// tDateEdit_EndEntryMonthDate_ValueChangedイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tDateEdit_EndEntryMonthDate_ValueChanged(object sender, EventArgs e)
		{
			if (("0001".Equals(tDateEdit_EndEntryYearDate.Text)) && ("01".Equals(tDateEdit_EndEntryMonthDate.Text)))
			{
				tDateEdit_EndEntryYearDate.Clear();
				tDateEdit_EndEntryMonthDate.Clear();
			}
		}
		// ----- ADD 2010/06/22 -------------------<<<<<

		/// <summary>
		/// tNedit_ModelSubCode_AfterExitEditModeイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_ModelSubCode_AfterExitEditMode(object sender, EventArgs e)
		{
			//ｶｰﾒｰｶｰｺｰﾄ
			string makerCode = this.tNedit_MakerCode.Text;
			//車種ｺｰﾄ
			string modelCode = this.tNedit_ModelCode.Text;
			//車種呼称ｺｰﾄ
			string modelSubCode = this.tNedit_ModelSubCode.Text;
			// ----- ADD 2010/05/16 ------------------->>>>>
			MakerAcs makerAcs = new MakerAcs();
			MakerUMnt makerUMnt;
			// ----- ADD 2010/05/16 -------------------<<<<<
			ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
			ModelNameU modelNameU;
			if (!string.IsNullOrEmpty(makerCode))
			{

				// ----- UPD 2010/05/16 ------------------->>>>>
				if ((this.tNedit_MakerCode.GetInt() != 0) && (this.tNedit_ModelCode.GetInt() == 0))
				{
					//メーカーデータの取得
					int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_MakerCode.GetInt());
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						//メーカー
						this.tNedit_MakerCode.SetInt(makerUMnt.GoodsMakerCd);
						this.tEdit_ModelFullName.Text = makerUMnt.MakerName;
					}
					else
					{
						this.tEdit_ModelFullName.Text = un_INSERT;
					}
				}
				else if (this.tNedit_ModelCode.GetInt() != 0)
				{
					int status = modelNameUAcs.Read(out modelNameU, this._enterpriseCode, this.tNedit_MakerCode.GetInt(), this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt());
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						this.tEdit_ModelFullName.Text = modelNameU.ModelFullName;
						if (modelNameU.ModelCode != 0)
						{
							this.tNedit_ModelCode.Text = modelNameU.ModelCode.ToString("000");
						}
						if (modelNameU.ModelSubCode != 0)
						{
							this.tNedit_ModelSubCode.Text = modelNameU.ModelSubCode.ToString("000");
						}
					}
					else
					{
						this.tEdit_ModelFullName.Text = un_INSERT;
					}
				}
				// ----- UPD 2010/05/16 -------------------<<<<<
			}
		}

		/// <summary>
		/// tEdit_FullModel_Leaveイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tEdit_FullModel_Leave(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.tEdit_FullModel.Text))
			{
				this.tEdit_FullModel.Text = this.tEdit_FullModel.Text.ToUpper();
			}

			// ----- ADD 2010/05/16 ------------------->>>>>
			if (tEdit_FullModel.Enabled == true)
			{
				this.tDateEdit_StartEntryYearDate.Enabled = false;
			}
			this.tDateEdit_StartEntryYearDate.Appearance.BackColor = Color.White;
			// ----- ADD 2010/05/16 -------------------<<<<<
		}

		/// <summary>
		/// ultraGrid_CarSpec_KeyDownイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraGrid_CarSpec_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Right)
			{
				// ----- ADD 2010/06/22 ------------------->>>>>
				if (this.ultraGrid_CarSpec.ActiveCell.IsInEditMode)
				{
					if (this.ultraGrid_CarSpec.ActiveCell.SelStart >= this.ultraGrid_CarSpec.ActiveCell.Text.Length)
					{
						// ----- ADD 2010/06/22 -------------------<<<<<
						// 最終セルの時
						if ((this.ultraGrid_CarSpec.ActiveCell.Row.Index == this.ultraGrid_CarSpec.Rows.Count - 1)
							  && (this.ultraGrid_CarSpec.ActiveCell.Column.Index == this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[PMJKN09001UB.COL_SHIFTNM_TITLE].Index))
						{
							this.ultraGrid_CarSpec.Focus();
							this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_MODELGRADENM_TITLE].Activate();
							this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
						}
						else
						{
							// 次のCellにフォーカス遷移
							this.ultraGrid_CarSpec.PerformAction(UltraGridAction.NextCell);
							this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
						}
					}
					// ----- ADD 2010/06/22 ------------------->>>>>
				}
			}
			// ----- ADD 2010/06/22 -------------------<<<<<

			if (e.KeyCode == Keys.Left)
			{
				// ----- ADD 2010/06/22 ------------------->>>>>
				if (this.ultraGrid_CarSpec.ActiveCell.IsInEditMode)
				{
					if (this.ultraGrid_CarSpec.ActiveCell.SelStart <= 0)
					{
						// ----- ADD 2010/06/22 -------------------<<<<<
						// 第一セルの時
						if ((this.ultraGrid_CarSpec.ActiveCell.Row.Index == 0)
							  && (this.ultraGrid_CarSpec.ActiveCell.Column.Index == this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[PMJKN09001UB.COL_MODELGRADENM_TITLE].Index))
						{
							this.ultraGrid_CarSpec.Focus();
							this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09001UB.COL_SHIFTNM_TITLE].Activate();
							this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
						}
						else
						{
							// 次のCellにフォーカス遷移
							this.ultraGrid_CarSpec.PerformAction(UltraGridAction.PrevCell);
							this.ultraGrid_CarSpec.PerformAction(UltraGridAction.EnterEditMode);
						}
					}
					// ----- ADD 2010/06/22 ------------------->>>>>
				}
			}
			// ----- ADD 2010/06/22 -------------------<<<<<
			if (e.KeyCode == Keys.Up)
			{
				// this.tEdit_EndProduceFrameNo.Focus(); // DEL 2010/06/22
				this.tEdit_StartProduceFrameNo.Focus();  // ADD 2010/06/22
				e.Handled = true; // ADD 2010/06/22
			}
			// ----- UPD 2010/06/22 ------------------->>>>>
			// ----- DEL 2010/06/22 ------------------->>>>>
			if (e.KeyCode == Keys.Down)
			{
				e.Handled = true; // ADD 2010/06/22
			}
			if (e.KeyCode == Keys.F2)
			{
				if (this.ultraGrid_CarSpec.ActiveCell.IsInEditMode)
				{
					this.ultraGrid_CarSpec.ActiveCell.SelStart = this.ultraGrid_CarSpec.ActiveCell.Text.Length;
				}
			}
			// ----- DEL 2010/06/22 -------------------<<<<<
			// ----- UPD 2010/06/22 -------------------<<<<<
		}

		#region チェックメソッド
		/// <summary>
		/// 文字判定
		/// </summary>
		/// <param name="key">文字</param>
		/// <param name="arChk">判定OK文字配列</param>
		/// <returns>bool(true=OK,false=NG)</returns>
		/// <remarks>
		/// <br>Note       : 文字判定</br>
		/// <br>Programmer : zhshh</br>
		/// <br>Date       : 2010.03.17</br>
		/// </remarks>
		private bool IsCharCheck(char key, char[] arChk)
		{
			if (arChk != null)
			{
				for (int widx = 0; widx < arChk.Length; widx++)
				{
					if (arChk[widx] == key) return true;
				}
			}
			return false;
		}

		/// <summary>
		/// 数値記号判定
		/// </summary>
		/// <param name="key">文字</param>
		/// <returns>bool(true=数値記号,false=数値記号以外)</returns>
		/// <remarks>
		/// <br>Note       : 数値記号判定</br>
		/// <br>Programmer : xiaoxd</br>
		/// <br>Date       : 2010.03.23</br>
		/// </remarks>
		private bool IsNumSign(char key)
		{
			char[] arnumsign = { '-' };
			return IsCharCheck(key, arnumsign);
		}

		/// <summary>
		/// 制御文字判定
		/// </summary>
		/// <param name="key">文字</param>
		/// <returns>bool(true=制御文字,false=制御文字以外)</returns>
		/// <remarks>
		/// <br>Note       : 制御文字判定</br>
		/// <br>Programmer : xiaoxd</br>
		/// <br>Date       : 2010.03.23</br>
		/// </remarks>
		private bool IsCtrl(char key)
		{
			return Char.IsControl(key);
		}


		// ADD 2010.03.23 xiaoxd for Redmine#4072>>>>>>
		/// <summary>
		/// 英字判定
		/// </summary>
		/// <param name="key">文字</param>
		/// <returns>bool(true=英字,false=英字以外)</returns>
		/// <remarks>
		/// <br>Note       : 英字判定</br>
		/// <br>Programmer : xiaoxd</br>
		/// <br>Date       : 2010.03.23</br>
		/// </remarks>
		private bool IsAlpha(char key)
		{
			char[] arAlpha = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
								'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
								'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
								'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
			return IsCharCheck(key, arAlpha);
		}

		/// <summary>
		/// 数値判定
		/// </summary>
		/// <param name="key">文字</param>
		/// <returns>bool(true=数値,false=数値以外)</returns>
		/// <remarks>
		/// <br>Note       : 数値判定</br>
		/// <br>Programmer : xiaoxd</br>
		/// <br>Date       : 2010.03.23</br>
		/// </remarks>
		private bool IsNum(char key)
		{
			char[] arnum = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
			return IsCharCheck(key, arnum);
		}
		#endregion

		// ----- ADD 2010/06/22 ------------------->>>>>
		private void ultraGrid_CarSpec_Layout(object sender, LayoutEventArgs e)
		{
			for (int index = 0; index < this.ultraGrid_CarSpec.KeyActionMappings.Count; index++)
			{
				GridKeyActionMapping keyActionMap = this.ultraGrid_CarSpec.KeyActionMappings[index];
				if (keyActionMap != null && keyActionMap.KeyCode == Keys.F2)
				{
					this.ultraGrid_CarSpec.KeyActionMappings.Remove(index);
				}
			}
		}
		// ----- ADD 2010/06/22 -------------------<<<<<

	}
}