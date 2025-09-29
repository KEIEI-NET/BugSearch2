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
using Broadleaf.Library.Text;


namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 自由検索部品マスタフォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自由検索部品マスタのフォームクラスです。</br>
	/// <br>Programmer : 肖緒徳</br>
	/// <br>Date       : 2010.04.26</br>
    /// <br>UpDate Note: 2010.05.24 葛軍 </br>
    /// <br>RedMine#8049</br>
    /// <br>Update Note: 2010/06/01  22018 鈴木 正臣</br>
    /// <br>RedMine#8016 型式検索結果のソート順修正 </br>
    /// <br>Update Note: 2010/07/02 葛軍</br>
    /// <br>RedMine#10103 各種仕様変更／障害対応</br>
    /// </remarks>
	public partial class PMJKN09011UA : Form
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
		private Control _prevControl = null;									// 現在のコントロール
		private Control _lastControl = null;									// 以前のコントロール
		private BeforeCarSearchBuffer _beforeCarSearchBuffer;
		private ColDisplayStatusList _colDisplayStatusList;	// 列表示状態コレクションクラス
		private DataSet _carSpecDataSet;

		private DataSet _detailDataSet;                     // 明細行データセット
		private DataTable _detailDataTable;                 // 明細行データテーブル

		private Dictionary<string, FreeSearchParts> _freeSearchPartsDty = null;       // 明細データバッファ
        private Dictionary<string, int> _newLineRowIndexDic = null;          // 明細新規行バッファ
		private Hashtable _upperBerth; // 上段項目テーブル
		private Hashtable _lowerBerth; // 下段項目テーブル

		private FreeSearchPartsAcs _freeSearchPartsAcs;                                 // 自由検索部品マスタ アクセスクラス
		private PMKEN01010E.CarModelInfoDataTable _carModelInfoDataTable;               // 型式データ
        private PMKEN01010E.CarModelInfoDataTable _selectCarModelInfoDataTable;         // 選択されたの型式データ
		private PMKEN01010E _carInfo;                                                   // 車両情報

		private MakerAcs _makerAcs;
		private BLGoodsCdAcs _bLGoodsCdAcs;

        // 比較用類別
        private string _categoryNo = "";
        // 比較用車種
        private string _fullCarType = "";
        // 比較用型式
        private string _designationNo = "";
        // 比較用検索番号
        private int _searchNo = 0;
		// グレードリスト
		private ValueList _modelGradeValueList;
		// ボディリスト
		private ValueList _bodyNameValueList;
		// ドアリスト
		private ValueList _doorCountValueList;
		// エンジンリスト
		private ValueList _engineModelValueList;
		// 排気量リスト
		private ValueList _engineDisplaceValueList;
		// E区分リスト
		private ValueList _eDivValueList;
		// ミッションリスト
		private ValueList _transmissionValueList;
		// 駆動形式リスト
		private ValueList _wheelDriveMethodValueList;
		// シフトリスト
		private ValueList _shiftValueList;

		// メーカーコード
		private int _makerCode = 0;
		// 車種コード
		private int _modelCode = 0;
		// 車種サブコード
		private int _modelSubCode = 0;
		// 型式（フル型）
		private string _fullModel = String.Empty;
        private int _activeRowIndex = 0;
        private int _endSearchGoodsNo = 0;
        private int _beforeRecordNum = 0;
        private int _singleIndex = 0;

        private bool goodsSearchFlg = false; //add 2010/06/21 by gejun for RedMine #10103
        private int focusMoveType = 0; //add 2010/06/22 by gejun for RedMine #10103
        private bool existCheckFlg = false; //add 2010/06/24 by gejun for RedMine #10103
        private Hashtable goodsNoComp = new Hashtable();    //add 2010/06/24 by gejun for RedMine #10103
        private bool updateModeFlg = false; // ADD 2010/07/01 -------->>>                    
    	# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members

		private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
		private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;

		// 生産年式フォーマット
		private const string FORMAT_CREATEYEAR = "####.## - ####.##";
		// 生産車台番号フォーマット
		private const string FORMAT_CREATECARNO = "nnnnnnnn - nnnnnnnn";
		// デフォルト行数
		private const int DEFAULT_ROW_COUNT = 1;
		// Max行数
		private const int MAX_ROW_COUNT = 9999;
		// 車種ガイド
		private const string ctGUIDE_NAME_ModelFullGuide = "ModelFullGuide";
		// メーカーガイド
		private const string ctGUIDE_NAME_MakerGuide = "MakerGuide";
		// BLコードガイド
		private const string ctGUIDE_NAME_BlCodeGuide = "BlCodeGuide";
		// 未登録
		private const string un_INSERT = "未登録";

		// データステータス:　0 未改修
		private const int DATASTATUSCODE_0 = 0;
		// データステータス:　1 改修
		private const int DATASTATUSCODE_1 = 1;
		// データステータス:　2 新規追加データ
		private const int DATASTATUSCODE_2 = 2;
		// データステータス:　3 削除するデータ
		private const int DATASTATUSCODE_3 = 3;
		// データステータス:　4 DB存在しない、且つ削除するデータ
		private const int DATASTATUSCODE_4 = 4;
		# endregion
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// 自由検索部品マスタフォームクラス デフォルトコンストラクタ
		/// </summary>
		public PMJKN09011UA()
		{
			InitializeComponent();
			this._carSpecDataSet = new DataSet();
			this._detailDataSet = new DataSet();
			this._upperBerth = new Hashtable();
			this._lowerBerth = new Hashtable();
			this._controlScreenSkin = new ControlScreenSkin();
			this._carModelInfoDataTable = new PMKEN01010E.CarModelInfoDataTable();
            this._selectCarModelInfoDataTable = new PMKEN01010E.CarModelInfoDataTable();
			this._imageList16 = IconResourceManagement.ImageList16;
			this._freeSearchPartsAcs = new FreeSearchPartsAcs();
			this._freeSearchPartsDty = new Dictionary<string, FreeSearchParts>();
            this._newLineRowIndexDic = new Dictionary<string, int>();
			this._makerAcs = new MakerAcs();
			this._bLGoodsCdAcs = new BLGoodsCdAcs();
			this._freeSearchPartsAcs.Owner = this;
			this._modelGradeValueList = new ValueList();
			this._bodyNameValueList = new ValueList();
			this._doorCountValueList = new ValueList();
			this._engineModelValueList = new ValueList();
			this._engineDisplaceValueList = new ValueList();
			this._eDivValueList = new ValueList();
			this._transmissionValueList = new ValueList();
			this._wheelDriveMethodValueList = new ValueList();
			this._shiftValueList = new ValueList();
		}
		#endregion

		# region private field
		private ImageList _imageList16 = null;
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin;
		# endregion

		# region  フォームロード
		/// <summary>
		/// 画面の処理化処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>   
		/// <param name="e">イベントパラメータクラス</param>
		/// <remarks>		
		/// <br>Note		: 画面の処理化を行う。</br>
		/// <br>Programmer	: 肖緒徳</br>	
		/// <br>Date		: 2010/04/26</br>
		/// </remarks>
		private void PMJKN09011UA_Load(object sender, EventArgs e)
		{
			// 画面イメージ統一 
			// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.LoadSkin();

			// 画面スキン変更
			this._controlScreenSkin.SettingScreenSkin(this);

			// 諸元情報データソース追加
			PMJKN09011UB.DataSetColumnConstruction(ref this._carSpecDataSet);
            DataRow row = this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].NewRow();
            this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].Rows.Add(row);
			this.ultraGrid_CarSpec.DataSource = this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].DefaultView;
            this.SetCarSpecGridColWidth(this.ultraGrid_CarSpec.Rows[0].Band); //ADD 2009/05/20 GEJUN FOR REDMINE#8049
            this.ultraGrid_CarSpec.Rows[0].Activation = Activation.Disabled;

			//ツールバー初期設定処理
			this.ToolBarInitilSetting();

			// ボタン初期設定処理
			this.ButtonInitialSetting();

			this.tComboEditor_GoodsNoFuzzy.SelectedIndex = 0;

			// 明細データテーブルの初期設定を行います。
			PMJKN09011UC detail = new PMJKN09011UC();
			detail.DataSetColumnConstruction(ref this._detailDataSet);
			this.DetailRowInitialSetting(DEFAULT_ROW_COUNT);

			// グリッド列初期設定処理
			this.InitialSettingGridCol();

			// 終了
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
			// クリア
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
			// 最新情報
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
			// 保存
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
			// 検索
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
			// 行削除
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
            // 全削除
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
			// ガイド
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
			// 引用登録
			this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
		}
		# endregion

		#region ツールバー初期設定処理
		/// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		private void ToolBarInitilSetting()
		{
			// ログイン拠点名称
			this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginSectionName"].SharedProps.Caption = GetOwnSectionName(LoginInfoAcquisition.Employee.BelongSectionCode); ;
			// ログイン担当者名称
			this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
		}
		#endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		#region Public Methods

		/// <summary>
		/// 自拠点名称取得得処理
		/// </summary>
		/// <param name="belongSectionCode">自拠点コード</param>
		/// <returns>自拠点名称</returns>
		public string GetOwnSectionName(string belongSectionCode)
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

		/// <summary>
		/// 明細データテーブルの初期設定を行います。
		/// </summary>
		/// <param name="defaultRowCount">初期行数</param>
		public void DetailRowInitialSetting(int defaultRowCount)
		{
			if (this._detailDataTable != null)
				this._detailDataTable.Clear();
			if (this._freeSearchPartsDty != null)
				this._freeSearchPartsDty.Clear();

            //ADD START 2009/05/24 GEJUN FOR REDMINE#8049
            if(this._newLineRowIndexDic != null)
                this._newLineRowIndexDic.Clear();
            //ADD END 2009/05/24 GEJUN FOR REDMINE#8049

			this._detailDataTable = this._detailDataSet.Tables[PMJKN09011UC.TBL_DETAILVIEW];

			for (int i = 1; i <= defaultRowCount; i++)
			{
				string guidStr = Guid.NewGuid().ToString().Replace("-", "");

				DataRow row = this._detailDataTable.NewRow();
				row[PMJKN09011UC.COL_NO_TITLE] = i;
				row[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE] = guidStr;

				this._detailDataTable.Rows.Add(row);
                //ADD START 2009/05/24 GEJUN FOR REDMINE#8049
                FreeSearchParts freeSearchParts = new FreeSearchParts();
                // 自由検索部品固有番号
                freeSearchParts.FreSrchPrtPropNo = guidStr;
                // 企業コード
                freeSearchParts.EnterpriseCode = this._enterpriseCode;
                // メーカーコード
                freeSearchParts.MakerCode = this._makerCode;
                // 車種コード
                freeSearchParts.ModelCode = this._modelCode;
                // 車種サブコード
                freeSearchParts.ModelSubCode = this._modelSubCode;
                // 型式（フル型）
                freeSearchParts.FullModel = this._fullModel;
                // データステータス:　2 新規追加データ
                freeSearchParts.DataStatus = DATASTATUSCODE_2;
                if (!_freeSearchPartsDty.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                    this._freeSearchPartsDty.Add(freeSearchParts.FreSrchPrtPropNo, freeSearchParts);

                if(!this._newLineRowIndexDic.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                    this._newLineRowIndexDic.Add(freeSearchParts.FreSrchPrtPropNo, 0);
                //ADD END 2009/05/24 GEJUN FOR REDMINE#8049
			}
		}
		#endregion

		// ===================================================================================== //
		// 各コントロールイベント処理
		// ===================================================================================== //
		#region Control Event Methods
        //ADD START 2009/05/20 GEJUN FOR REDMINE#8049----->>>
        /// <summary>
        /// 諸元情報グリッド列初期設定処理
        /// </summary>
        /// <param name="band">諸元情報グリッドバンド</param>
        private void SetCarSpecGridColWidth(UltraGridBand band)
        {
            // グレード 20桁数
            band.Columns[0].Width = 170;
            // ボディ 10桁数
            band.Columns[1].Width = 90;
            // ドア 2桁数
            band.Columns[2].Width = 40;
            // エンジン 12桁数
            band.Columns[3].Width = 104;
            // 排気量 8桁数
            band.Columns[4].Width = 76;
            // E区分 8桁数
            band.Columns[5].Width = 76;
            // ミッション 8桁数
            band.Columns[6].Width = 76;
            // 駆動形式 15桁数
            band.Columns[7].Width = 130;
            // シフト 8桁数
            band.Columns[8].Width = 76;
        }
        //ADD END  2009/05/20 GEJUN FOR REDMINE#8049----<<<
		/// <summary>
		/// グリッド列初期設定処理tptp
		/// </summary>
		private void InitialSettingGridCol()
		{
            // add start 2010/06/21 by gejun for RedMine #10103
            // 列幅の自動調整方法(諸元情報データ)
            this.ultraGrid_CarSpec.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.ultraGrid_CarSpec.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.ultraGrid_CarSpec.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid_CarSpec.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // add end 2010/06/21 by gejun for RedMine #10103   

			this.uGrid_Details.DataSource = this._detailDataTable.DefaultView;

			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
			if (editBand == null) return;

			editBand.UseRowLayout = true;
			// 生産年式
			EmbeddableEditorBase editorPty = getEditor(FORMAT_CREATEYEAR);
			// 生産車台番号
			EmbeddableEditorBase editorPfn = getEditor(FORMAT_CREATECARNO);

            // 列幅の自動調整方法
            this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.uGrid_Details.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Details.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.uGrid_Details.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            this.uGrid_Details.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
          
            // 生産年式
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATEYEAR_TITLE].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATEYEAR_TITLE].MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            // 生産車台番号
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATECARNO_TITLE].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATECARNO_TITLE].MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

			// 列表示状態コレクションクラスをインスタンス化
			this._colDisplayStatusList = new ColDisplayStatusList();

			foreach (ColDisplayStatusExp colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
			{
				if (this.uGrid_Details.DisplayLayout.Bands[0].Columns.Exists(colDisplayStatus.Key))
				{
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.Reset();

					System.Drawing.Size sizeHeader = new Size();
					System.Drawing.Size sizeCell = new Size();
					this.uGrid_Details.DisplayLayout.Bands[0].RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
					this.uGrid_Details.DisplayLayout.Bands[0].RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

					sizeCell.Height = 22;
					sizeCell.Width = colDisplayStatus.Width;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
					sizeHeader.Height = 20;
					sizeHeader.Width = colDisplayStatus.Width;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.LabelSpan = colDisplayStatus.LabelSpan;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.OriginX = colDisplayStatus.OriginX;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.OriginY = colDisplayStatus.OriginY;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.SpanX = colDisplayStatus.SpanX;
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].RowLayoutColumnInfo.SpanY = colDisplayStatus.SpanY;

					if (colDisplayStatus.OriginY == 0)
					{
						// 上段テーブル
						this._upperBerth[colDisplayStatus.Key] = colDisplayStatus.MoveLineKeyName;
					}
					else
					{
						// 下段テーブル
						this._lowerBerth[colDisplayStatus.Key] = colDisplayStatus.MoveLineKeyName;
					}
				}
			}
			//---------------------------------------------------------------------
			// CellAppearance設定
			//---------------------------------------------------------------------
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_NO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;            // No.
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_GOODSNO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;        // 品番
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_MAKER_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;         // メーカーコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_BLCODE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;        // BLコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_GOODSNM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;        // 品名
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_PARTSQTY_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;      // QTY
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_COSTRATE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;      // 標準価格
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATEYEAR_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;   // 生産年式
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATECARNO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;  // 生産車台番号

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_MODELGRADENM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;     // グレード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_BODYNAME_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;         // ボディ
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_DOORCOUNT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;       // ドア
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;    // エンジン
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left; // 排気量
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_EDIVNM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;           // E区分
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;   // ミッション
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;// 駆動形式
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_SHIFTNM_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;          // シフト
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ADDICARSPEC_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;      // 摘要

			//---------------------------------------------------------------------
			// Color設定
			//---------------------------------------------------------------------
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_NO_TITLE].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_NO_TITLE].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_NO_TITLE].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_NO_TITLE].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_NO_TITLE].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;

			//---------------------------------------------------------------------
			// Editor設定
			//---------------------------------------------------------------------
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATEYEAR_TITLE].Editor = editorPty;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_CREATECARNO_TITLE].Editor = editorPfn;

			//---------------------------------------------------------------------
			// 入力許可設定
			//---------------------------------------------------------------------
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_NO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;              // No
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_GOODSNM_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;         // 品名
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_COSTRATE_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;        // 標準価格
           
            //---------------------------------------------------------------------
			// Style設定
			//---------------------------------------------------------------------
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_GOODSNO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;       // 品番
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_MAKER_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;          // メーカーコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_BLCODE_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // BLコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_PARTSQTY_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;       // QTY
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_COSTRATE_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;       // 標準価格

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_MODELGRADENM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;     // グレード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_BODYNAME_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // ボディ
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_DOORCOUNT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;        // ドア
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // エンジン
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; // 排気量
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_EDIVNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;           // E区分
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;   // ミッション
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;// 駆動形式
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_SHIFTNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;          // シフト
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ADDICARSPEC_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 摘要


			//---------------------------------------------------------------------
			// フォーマット設定
			//---------------------------------------------------------------------        
			string moneyFormat = "#,##0;-#,##0;''";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_MAKER_TITLE].Format = "0##0;-0##0;''";       // メーカーコード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_BLCODE_TITLE].Format = "0###0;-0###0;''";      // BLコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_COSTRATE_TITLE].Format = moneyFormat;   // 標準価格

			//---------------------------------------------------------------------
			// MaxLength設定
			//---------------------------------------------------------------------
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_GOODSNO_TITLE].MaxLength = 24;       // 品番
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_MAKER_TITLE].MaxLength = 4;          // メーカーコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_BLCODE_TITLE].MaxLength = 5;         // BLコード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_GOODSNM_TITLE].MaxLength = 40;       // 品名
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_PARTSQTY_TITLE].MaxLength = 2;       // QTY
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_COSTRATE_TITLE].MaxLength = 9;       // 標準価格

			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_MODELGRADENM_TITLE].MaxLength = 20;    // グレード
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_BODYNAME_TITLE].MaxLength = 10;        // ボディ
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_DOORCOUNT_TITLE].MaxLength = 2;        // ドア
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].MaxLength = 12;   // エンジン
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].MaxLength = 8; // 排気量
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_EDIVNM_TITLE].MaxLength = 8;           // E区分
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].MaxLength = 8;   // ミッション
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].MaxLength = 15;// 駆動形式
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_SHIFTNM_TITLE].MaxLength = 8;          // シフト
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_ADDICARSPEC_TITLE].MaxLength = 60;     // 摘要

			//---------------------------------------------------------------------
			// Hidden設定
			//---------------------------------------------------------------------
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].Hidden = true;  // 自由検索部品固有番号
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[PMJKN09011UC.COL_FULLMODELGROUP_TITLE].Hidden = true;    // 型式グループ区分

			// 明細グリッド表示設定処理
			SettingDetailsGridCol();

		}

		/// <summary>
		/// 車種ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_ModelFullGuide_Click(object sender, EventArgs e)
		{
			ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
            MakerAcs makerAcs = new MakerAcs();
			ModelNameU modelNameU;
            ModelNameU modelNameU2;
            MakerUMnt makerUMnt;
			int makerCode = this.tNedit_MakerCode.GetInt();

			int status = modelNameUAcs.ExecuteGuid2(makerCode, this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt(),
				this._enterpriseCode, out modelNameU);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.tNedit_MakerCode.SetInt(modelNameU.MakerCode);
				this.tNedit_ModelCode.SetInt(modelNameU.ModelCode);
				this.tNedit_ModelSubCode.SetInt(modelNameU.ModelSubCode);
                // modify start 2010/06/24 by gejun for RedMine #10103
                if ("".Equals(modelNameU.ModelFullName.Trim()))
                {
                    if (modelNameU.ModelCode != 0)
                    {
                        status = modelNameUAcs.Read(out modelNameU2, this._enterpriseCode, modelNameU.MakerCode, modelNameU.ModelCode, modelNameU.ModelSubCode);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            this.tEdit_ModelFullName.Text = modelNameU2.ModelFullName;
                    }
                    else
                    {
                        status = makerAcs.Read(out makerUMnt, this._enterpriseCode, modelNameU.MakerCode);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            this.tEdit_ModelFullName.Text = makerUMnt.MakerName;
                    }
                }
                else
				    this.tEdit_ModelFullName.Text = modelNameU.ModelFullName;
                // modify end 2010/06/24 by gejun for RedMine #10103
				// 次の項目へフォーカス移動
                ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_ModelFullGuide, this.tEdit_FullModel);
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

            if (string.IsNullOrEmpty(modelDesignationNo))
            {
                this.tNedit_CategoryNo.Enabled = false;
                this.tNedit_CategoryNo.Clear();
            }
            else
            {
                this.tNedit_CategoryNo.Enabled = true;
                if (this.tNedit_ModelDesignationNo.ExtEdit.Column <= modelDesignationNo.Length)
                {
                    this.tNedit_CategoryNo.Focus();
                }
            }
		}

        // ADD 2010/07/01------------>>>
        /// <summary>						
        /// 型式キーダウンイベント						
        /// </summary>						
        /// <param name="sender">対象オブジェクト</param>						
        /// <param name="e">イベントパラメータクラス</param>						
        /// <remarks>						
        /// <br>Note		: 型式キーダウン時、処理を行います。</br>				
        /// <br>Programmer	: gejun</br>					
        /// <br>Date		: 2010.07.01</br>				
        /// </remarks>	
        private void tNedit_ModelDesignationNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.tNedit_MakerCode.Focus();
            }
        }
        // ADD 2010/07/01------------>>>

        /// <summary>						
        /// グリッドキーダウンイベント						
        /// </summary>						
        /// <param name="sender">対象オブジェクト</param>						
        /// <param name="e">イベントパラメータクラス</param>						
        /// <remarks>						
        /// <br>Note		: グリッドキーダウン時、処理を行います。</br>				
        /// <br>Programmer	: gejun</br>					
        /// <br>Date		: 2010.05.19</br>				
        /// </remarks>	
        private void ultraGrid_CarSpec_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    // 検索番号にフォーカスに移動
                    tNedit_SearchGoodsNo.Focus();
                    break;
                case Keys.Up:
                    // 型式にフォーカスに移動
                    tEdit_FullModel.Focus();
                    break;
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
			this._prevControl = e.PrevCtrl;
            this._lastControl = e.NextCtrl;

			// PrevCtrl設定
			Control prevCtrl = new Control();
			if (e.PrevCtrl is Control) prevCtrl = (Control)e.PrevCtrl;

			Control nextCtrl = new Control();
			if (e.NextCtrl is Control) nextCtrl = (Control)e.NextCtrl;

            // チェック用結果
            int checkRst = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; // add 2010/06/24 by gejun for RedMine #10103

			#region prevCtrl
			switch (prevCtrl.Name)
			{
				#region 型式指定
				//型式指定
				case "tNedit_ModelDesignationNo":
					{
						if (!string.IsNullOrEmpty(this.tNedit_ModelDesignationNo.Text)
                            && string.IsNullOrEmpty(this.tNedit_CategoryNo.Text))
						{
                            if (!nextCtrl.Name.Equals("tNedit_CategoryNo") && !"_Form1_Toolbars_Dock_Area_Top".Equals(nextCtrl.Name))
                            {
                                DialogResult dialogResult = TMsgDisp.Show(
                                                   this,
                                                   emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                   this.Name,
                                                   "類別区分を入力してください。",
                                                   0,
                                                   MessageBoxButtons.OK,
                                                   MessageBoxDefaultButton.Button1);
                                nextCtrl = e.NextCtrl = this.tNedit_CategoryNo;
                            }
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

						if ((this.tNedit_ModelDesignationNo.GetInt() != 0) &&
							(this.tNedit_CategoryNo.GetInt() != 0))
						{
							CarSearchCondition con = new CarSearchCondition();
							con.ModelDesignationNo = this.tNedit_ModelDesignationNo.GetInt();
							con.CategoryNo = this.tNedit_CategoryNo.GetInt();
							con.Type = CarSearchType.csCategory;
                            con.FreeSearchModelOnly = false;
                            //int result = this.CarSearch(con); // del 2010/06/24 by gejun for RedMine #10103
                            checkRst = this.CarSearch(con); // add 2010/06/24 by gejun for RedMine #10103
							//switch ((ConstantManagement.MethodResult)result)// del 2010/06/24 by gejun for RedMine #10103
							switch ((ConstantManagement.MethodResult)checkRst)// add 2010/06/24 by gejun for RedMine #10103
							{
								case ConstantManagement.MethodResult.ctFNC_CANCEL:
									e.NextCtrl = this.tNedit_ModelDesignationNo;
									this.tNedit_ModelDesignationNo.Clear();
									this.tNedit_CategoryNo.Clear();
                                    this._beforeRecordNum = 0;
									break;
								case ConstantManagement.MethodResult.ctFNC_NORMAL:
                                    nextCtrl = tNedit_SearchGoodsNo;
                                    e.NextCtrl = null;
                                    this.tNedit_SearchGoodsNo.Focus();
                                    this._beforeRecordNum = 1;
                                    this.SettingDetailsGridCol();
									break;
								case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
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
                                        this.tNedit_ModelDesignationNo.Focus();
										this.tNedit_ModelDesignationNo.Clear();
										this.tNedit_CategoryNo.Clear();
                                        nextCtrl = e.NextCtrl = null;
									}
                                    this._beforeRecordNum = 0;
									break;
								default:
									break;
							}
						}
						else if ((this.tNedit_ModelDesignationNo.GetInt() != 0) && (this.tNedit_CategoryNo.GetInt() == 0))
						{
                            if(!"_Form1_Toolbars_Dock_Area_Top".Equals(nextCtrl.Name))
                            {
							    DialogResult dialogResult = TMsgDisp.Show(
									       this,
									       emErrorLevel.ERR_LEVEL_EXCLAMATION,
									       this.Name,
									       "型式指定入力時は、類別区分は必須入力です。",
									       0,
                                           MessageBoxButtons.OK,
									       MessageBoxDefaultButton.Button1);
                                nextCtrl = e.NextCtrl = this.tNedit_CategoryNo;
                            }
						}
						else
						{
							prevCtrl = this.tNedit_ModelDesignationNo;
							break;
						}
                        // 比較用情報保存

                        // 比較用類別
                        this._categoryNo = this.tNedit_ModelDesignationNo.Text + this.tNedit_CategoryNo.Text;
                        // 比較用車種
                        this._fullCarType = this.tNedit_MakerCode.Text + this.tNedit_ModelCode.Text + this.tNedit_ModelSubCode.Text;
                        // 比較用型式
                        this. _designationNo = this.tEdit_FullModel.Text;
                        // 比較用検索番号
                        this._searchNo = this.tNedit_SearchGoodsNo.GetInt();
						prevCtrl = this.tNedit_ModelDesignationNo;
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
						if ((!string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim())))
						{
							this.tEdit_FullModel.Text = this.tEdit_FullModel.Text.ToUpper();
							CarSearchCondition con = new CarSearchCondition();
							con.CarModel.FullModel = this.tEdit_FullModel.Text;
							con.Type = CarSearchType.csModel;
                            con.FreeSearchModelOnly = false;
                            //int result = this.CarSearch(con); // del 2010/06/24 by gejun for RedMine #10103
                            checkRst = this.CarSearch(con); // add 2010/06/24 by gejun for RedMine #10103
							//switch ((ConstantManagement.MethodResult)result)// del 2010/06/24 by gejun for RedMine #10103
							switch ((ConstantManagement.MethodResult)checkRst)// add 2010/06/24 by gejun for RedMine #10103
							{
								case ConstantManagement.MethodResult.ctFNC_CANCEL:
									e.NextCtrl = e.PrevCtrl;
                                    //this.tEdit_FullModel.Clear();// del 2010/06/24 by gejun for RedMine #10103
                                    this.tEdit_FullModel.Text = this._designationNo;// add 2010/06/24 by gejun for RedMine #10103
									break;
								case ConstantManagement.MethodResult.ctFNC_NORMAL:
									nextCtrl = tNedit_SearchGoodsNo;
									e.NextCtrl = null;
									this.tNedit_SearchGoodsNo.Focus();
									break;
								case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                    TMsgDisp.Show(this,
                                       emErrorLevel.ERR_LEVEL_INFO,
                                       this.Name,
                                       "該当データがありません。",
                                       -1,
                                       MessageBoxButtons.OK);
                                    this.tEdit_FullModel.Text = this._designationNo;
                                    e.NextCtrl = tEdit_FullModel;
									
									break;
                                case ConstantManagement.MethodResult.ctFNC_DO_END:
                                    //DEL 2010/07/01
                                    //if (Keys.Enter == e.Key || Keys.Tab == e.Key)
                                    //{
                                    //    nextCtrl = tNedit_SearchGoodsNo;
                                    //    e.NextCtrl = null;
                                    //    this.tNedit_SearchGoodsNo.Focus();
                                    //}
                                    //DEL 2010/07/01
                                    //　フォーカス設定のため
                                    checkRst = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; //ADD 2010/07/01
                                    break;
								default:
									break;
							}
						}
                        // add start 2010/06/24 by gejun for RedMine #10103
                        if ((ConstantManagement.MethodResult)checkRst == ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                        // end add 2010/06/24 by gejun for RedMine #10103
					        switch (e.Key)
					        {
						        case Keys.Down:
                                case Keys.Right:
                                case Keys.Enter:
                                    e.NextCtrl = this.tNedit_SearchGoodsNo;
							        break;
						        case Keys.Up:
                                    e.NextCtrl = this.tNedit_MakerCode;
							        break;
                                case Keys.Tab:
                                    if (e.ShiftKey)
                                        e.NextCtrl = this.uButton_ModelFullGuide;
                                    else
                                        e.NextCtrl = this.tNedit_SearchGoodsNo;
                                    break;
						        default:
							        break;
					        }
                        }// add 2010/06/24 by gejun for RedMine #10103
                        // 比較用情報保存

                        // 比較用類別
                        this._categoryNo = this.tNedit_ModelDesignationNo.Text + this.tNedit_CategoryNo.Text;
                        // 比較用車種
                        this._fullCarType = this.tNedit_MakerCode.Text + this.tNedit_ModelCode.Text + this.tNedit_ModelSubCode.Text;
                        // 比較用型式
                        this._designationNo = this.tEdit_FullModel.Text;
                        // 比較用検索番号
                        this._searchNo = this.tNedit_SearchGoodsNo.GetInt();
						break;
					}
				#endregion
                // ADD 2010/07/01------------------------>>>
                #region 車種コード
                case "tNedit_ModelCode":
                    {
                        if(e.Key == Keys.Up)
                            e.NextCtrl = nextCtrl = this.tNedit_ModelDesignationNo;
                        break;
                    }
                #endregion  
                case "uButton_CmpltGoodsMakerGuide":
                case "tNedit_BlCd":
                case "BlCdGuide":
                    {
                        if (e.Key == Keys.Up)
                            e.NextCtrl = nextCtrl = this.tNedit_SearchGoodsNo;
                        // ADD 2010/07/02------------------------>>>
                        if ("BlCdGuide".Equals(prevCtrl.Name) && e.Key == Keys.Down)
                            e.NextCtrl = nextCtrl = this.tComboEditor_GoodsNoFuzzy;
                        // ADD 2010/07/02------------------------>>>
                        break;
                    }
                // ADD 2010/07/01------------------------>>>
                #region 品番条件
                case "tComboEditor_GoodsNoFuzzy":
                    {
                        //if (e.Key == Keys.Enter || e.Key == Keys.Tab) //del 2010/06/29 by gejun for RedMine #10103
                        if (e.Key == Keys.Enter || e.Key == Keys.Tab || e.Key == Keys.Down) //add 2010/06/29 by gejun for RedMine #10103
                        {
                            // 検索（R)の実行
                            //this.Search();// del 2010/06/24 by gejun for RedMine #10103
                            // add start 2010/06/24 by gejun for RedMine #10103
                            if ((int)ConstantManagement.MethodResult.ctFNC_NORMAL != this.Search())
                            {
                                 if (string.IsNullOrEmpty(tEdit_FullModel.Text.Trim()))
                                     nextCtrl = e.NextCtrl = tEdit_FullModel;
                                 else if (string.IsNullOrEmpty(tNedit_MakerCode.Text.Trim()))
                                     nextCtrl = e.NextCtrl = tNedit_MakerCode;
                            }
                            // add end  2010/06/24 by gejun for RedMine #10103
                        }
                        break;
                    }
                #endregion
                // Add 2010/06/30------------------------>>>
                #region 品番
                case "tEdit_GoodsNo":
                    {
                        if (e.Key == Keys.Down)
                        {
                            // 検索（R)の実行
                            if ((int)ConstantManagement.MethodResult.ctFNC_NORMAL != this.Search())
                            {
                                if (string.IsNullOrEmpty(tEdit_FullModel.Text.Trim()))
                                    nextCtrl = e.NextCtrl = tEdit_FullModel;
                                else if (string.IsNullOrEmpty(tNedit_MakerCode.Text.Trim()))
                                    nextCtrl = e.NextCtrl = tNedit_MakerCode;
                            }
                        }
                        break;
                    }
                #endregion
                // Add 2010/06/30------------------------>>>
                #region 検索番号
                case "tNedit_SearchGoodsNo":
                    {
                        if (e.ShiftKey || e.Key == Keys.Up)
                            e.NextCtrl = this.tEdit_FullModel;

                        if (this._searchNo == this.tNedit_SearchGoodsNo.GetInt())
                            break;

                        if (!this.tNedit_SearchGoodsNo_TextChanged())
                        {
                            e.NextCtrl = null;
                        }

                        this._searchNo = this.tNedit_SearchGoodsNo.GetInt();
                        break;
                    }
                #endregion
                #region uGrid_Details
                case "uGrid_Details":
					{
						if (!e.NextCtrl.Name.Equals("_Form1_Toolbars_Dock_Area_Top"))
						{
							e.NextCtrl = null;
						}

                        this._activeRowIndex = this.GetActiveRowIndex();

						// 明細部にフォーカス有り(GridActive)
						if (this.uGrid_Details.ActiveCell != null)
						{
							int rowIndex = uGrid_Details.ActiveCell.Row.Index;
							int colIndex = uGrid_Details.ActiveCell.Column.Index;
							string colKey = uGrid_Details.ActiveCell.Column.Key;
                            string colKeyNext = uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Column.Key;

							if (e.Key == Keys.Return || e.Key == Keys.Tab)
							{
								// 品番
								if (uGrid_Details.ActiveCell.Column.Key == PMJKN09011UC.COL_GOODSNO_TITLE && String.IsNullOrEmpty(uGrid_Details.ActiveCell.Text))
								{
                                    nextCtrl = e.NextCtrl = null;            //ADD 2009/05/24 GEJUN FOR REDMINE#8049
									break;
								}
                                //del start 2010/06/21 by gejun for RedMine #10103
                                //// メーカー
                                //if (uGrid_Details.ActiveCell.Column.Key == PMJKN09011UC.COL_MAKER_TITLE && String.IsNullOrEmpty(uGrid_Details.ActiveCell.Text))
                                //{
                                //    break;
                                //}
                                //// BLコード
                                //if (uGrid_Details.ActiveCell.Column.Key == PMJKN09011UC.COL_BLCODE_TITLE && String.IsNullOrEmpty(uGrid_Details.ActiveCell.Text))
                                //{
                                //    break;
                                //}
                                //del end 2010/06/21 by gejun for RedMine #10103
							}

							switch (e.Key)
							{
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (!e.ShiftKey)
                                        {
                                            if (colIndex < 18)
                                            {
                                                if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_CREATEYEAR_TITLE))
                                                {
                                                    string yearDiv = this.uGrid_Details.ActiveCell.Text;
                                                    if (CheckYearDiv(yearDiv))
                                                    {
                                                        this.uGrid_Details.ActiveCell.Value = yearDiv;
                                                        uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                    }
                                                    else
                                                    {
                                                        SetCellBeforeValue(colKey, rowIndex, colIndex);
                                                        return;
                                                    }
                                                }
                                                //add start 2010/06/25 by gejun for RedMine #10103
                                                else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_CREATECARNO_TITLE))
                                                {
                                                    if (CheckCarNoWithErrorHandle(this.uGrid_Details.ActiveCell.Text, rowIndex, colIndex))
                                                    {
                                                        uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                    }
                                                    else
                                                    {
                                                        return;
                                                    }
                                                }
                                                //add end 2010/06/25 by gejun for RedMine #10103
                                                else
                                                {
                                                    if (CheckNumber(uGrid_Details.Rows[rowIndex].Cells[colIndex].Text, rowIndex, uGrid_Details.Rows[rowIndex].Cells[colIndex].Column.Key))
                                                    {
                                                        // 品名、標準価格の場合、次のグラムに移動
                                                        if (colKeyNext == PMJKN09011UC.COL_GOODSNM_TITLE || colKeyNext == PMJKN09011UC.COL_COSTRATE_TITLE)
                                                        {
                                                            if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                                                                uGrid_Details.Rows[rowIndex].Cells[colIndex + 2].Activate();
                                                                uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                        }
                                                        else
                                                        {
                                                            //add start 2010/06/21 by gejun for RedMine #10103
                                                            if (colKey == PMJKN09011UC.COL_GOODSNO_TITLE)
                                                            {
                                                                UltraGridCell cell = this.uGrid_Details.ActiveCell;
                                                                CellEventArgs cellEventArgs = new CellEventArgs(cell);
                                                                this.uGrid_Details.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                                                                uGrid_Details_AfterCellUpdate(this, cellEventArgs);
                                                                if (goodsSearchFlg)
                                                                {
                                                                    uGrid_Details.Rows[rowIndex].Cells[colIndex + 2].Activate();
                                                                    goodsSearchFlg = false;
                                                                }
                                                                else
                                                                    uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                                                this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                                                                uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                            }
                                                            else
                                                            {
                                                                //add end 2010/06/21 by gejun for RedMine #10103
                                                                if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                                                                    uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                                                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                            }//add 2010/06/21 by gejun for RedMine #10103
                                                        }
                                                    }
                                                    else
                                                    {
                                                        SetCellBeforeValue(colKey, rowIndex, colIndex);
                                                    }
                                                    
                                                }
                                                nextCtrl = e.NextCtrl = null; //ADD 2009/05/21 GEJUN FOR REDMINE#8049
                                            }
                                            else if (rowIndex < uGrid_Details.Rows.Count - 1)
                                            {
                                                uGrid_Details.Rows[rowIndex + 1].Cells[1].Activate();
                                                uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                nextCtrl = e.NextCtrl = null;//ADD 2009/05/21 GEJUN FOR REDMINE#8049
                                            }
                                            else if (rowIndex == uGrid_Details.Rows.Count - 1 && this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_ADDICARSPEC_TITLE))
                                            {
                                                //ADD START 2009/05/21 GEJUN FOR REDMINE#8049
                                                if (e.Key == Keys.Return)
                                                {
                                                    nextCtrl = e.NextCtrl = null;//ADD 2009/05/24 GEJUN FOR REDMINE#8049
                                                    AddNewDetailRow();
                                                    SettingGrid();
                                                    uGrid_Details.Rows[rowIndex + 1].Cells[1].Activate();
                                                    uGrid_Details.Rows[rowIndex + 1].Cells[1].Activate();
                                                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                else
                                                {
                                                    //ADD END 2009/05/21 GEJUN FOR REDMINE#8049
                                                    this.tNedit_ModelDesignationNo.Focus();
                                                    nextCtrl = e.NextCtrl = this.tNedit_ModelDesignationNo;//ADD 2009/05/21 GEJUN FOR REDMINE#8049
                                                }//ADD 2009/05/21 GEJUN FOR REDMINE#8049
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            if (rowIndex == 0 && colIndex == 1)
                                            {
                                                this.tComboEditor_GoodsNoFuzzy.Focus();
                                                nextCtrl = e.NextCtrl = this.tComboEditor_GoodsNoFuzzy;
                                            }
                                            else if(colIndex == 1)
                                            {
                                                uGrid_Details.Rows[rowIndex - 1].Cells[PMJKN09011UC.COL_ADDICARSPEC_TITLE].Activate();
                                                uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                            }
                                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_CREATEYEAR_TITLE))
                                            {
                                                string yearDiv = this.uGrid_Details.ActiveCell.Text;
                                                if (CheckYearDiv(yearDiv))
                                                {
                                                    this.uGrid_Details.ActiveCell.Value = yearDiv;
                                                    uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                else
                                                {
                                                    SetCellBeforeValue(colKey, rowIndex, colIndex);
                                                    return;
                                                }
                                            }
                                            //add start 2010/06/25 by gejun for RedMine #10103
                                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_CREATECARNO_TITLE))
                                            {
                                                if (CheckCarNoWithErrorHandle(this.uGrid_Details.ActiveCell.Text, rowIndex, colIndex))
                                                {
                                                    uGrid_Details.Rows[rowIndex].Cells[colIndex - 1].Activate();
                                                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            //add end 2010/06/25 by gejun for RedMine #10103
                                            else if (this.uGrid_Details.ActiveCell.Column.Key == PMJKN09011UC.COL_CREATEYEAR_TITLE 
                                                || this.uGrid_Details.ActiveCell.Column.Key == PMJKN09011UC.COL_PARTSQTY_TITLE)
                                            {
                                                if (CheckNumber(uGrid_Details.Rows[rowIndex].Cells[colIndex].Text, rowIndex, uGrid_Details.Rows[rowIndex].Cells[colIndex].Column.Key))
                                                {
                                                    uGrid_Details.Rows[rowIndex].Cells[colIndex - 2].Activate();
                                                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                else
                                                {
                                                    SetCellBeforeValue(colKey, rowIndex, colIndex);
                                                }
                                            }
                                            else
                                            {
                                                if (CheckNumber(uGrid_Details.Rows[rowIndex].Cells[colIndex].Text, rowIndex, uGrid_Details.Rows[rowIndex].Cells[colIndex].Column.Key))
                                                {
                                                    if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                                                        uGrid_Details.Rows[rowIndex].Cells[colIndex - 1].Activate();
                                                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                else
                                                {
                                                    SetCellBeforeValue(colKey, rowIndex, colIndex);
                                                }
                                            }
                                            break;
                                        }
                                    }
                                case Keys.LButton:
                                case Keys.RButton:
                                    {
                                        if (this.uGrid_Details.ActiveCell.Column.Key == PMJKN09011UC.COL_CREATEYEAR_TITLE)
                                        {
                                            if (!CheckYearDiv(this.uGrid_Details.ActiveCell.Text))
                                                SetCellBeforeValue(colKey, rowIndex, colIndex);
                                        }
                                        break;
                                    }
                            }

                            // 明細部にフォーカス有り(GridActive)
                            // 終了
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
                            // クリア
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
                            // 最新情報
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
                            // 保存
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                            // 行削除
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = true;
                            // ADD 2010/07/01----->>>
                            // 全削除
                            if (updateModeFlg)
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = true;
                            // ADD 2010/07/01----->>>

                            // 明細のメーカー、BLコード
                            if ((uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_MAKER_TITLE)) ||
                                (uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_BLCODE_TITLE)))
                            {
                                // ガイド
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = true;
                            }
                            else
                            {
                                // ガイド
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;

                            }
                            //MODIFY START 2009/05/24 GEJUN FOR REDMINE#8049
                            // 明細の品番
                            //if (!string.IsNullOrEmpty(uGrid_Details.ActiveCell.Row.Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Text))
                            //{
                            // 引用登録
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = true;
                            //}
                            //else
                            //{
                            //    // 引用登録
                            //    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
                            //}
                            //MODIFY END  2009/05/24 GEJUN FOR REDMINE#8049
						}                        
						break;
                    }
                #endregion
            }
			#endregion

			#region nextCtrl
			if (nextCtrl != null)
			{
				switch (nextCtrl.Name)
				{
					// 類別
					case "tNedit_ModelDesignationNo":
					case "tNedit_CategoryNo":
					// 型式
					case "tEdit_FullModel":
						{
							// 終了
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
							// クリア
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
							// 最新情報
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
							// 保存
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
							// 検索
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
							// 行削除
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                            // 全削除
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
							// ガイド
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
							// 引用登録
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
							break;
						}
					case "tNedit_MakerCode":
					case "tNedit_ModelCode":
					case "tNedit_ModelSubCode":
						{
							// 終了
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
							// クリア
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
							// 最新情報
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
							// ガイド
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = true;
							// 検索
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
							// 保存
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
							// 行削除
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                            // 全削除
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
							// 引用登録
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
							break;
						}
					// メーカー
					case "tNedit_CmpltGoodsMakerCd":
					// ＢＬコード
					case "tNedit_BlCd":
						{
							// 終了
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
							// クリア
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
							// 最新情報
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
							// 検索
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = true;
							// ガイド
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = true;
							// 保存
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
							// 行削除
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                            // 全削除
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
							// 引用登録
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
							break;
						}
                    case "uButton_CmpltGoodsMakerGuide":
                    case "BlCdGuide":
					case "tEdit_GoodsNo":
						{
							// 終了
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
							// クリア
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
							// 最新情報
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
							// 検索
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = true;
							// ガイド
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
							// 保存
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
							// 行削除
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                            // 全削除
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
							// 引用登録
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
							break;
						}
                    case "tNedit_SearchGoodsNo":
                    case "uButton_ModelFullGuide":
						{
							// 終了
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
							// クリア
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
							// 最新情報
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
							// 保存
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
							// 検索
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
							// 行削除
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                            // 全削除
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
							// ガイド
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
							// 引用登録
							this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
							break;
						}
                    case "uGrid_Details":
                        {
                            // 検索
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
                            // add start 2009/06/25 by gejun for RedMine #10103
                            // 保存
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                            // 行削除
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = true;
                            // ADD 2010/07/01----->>>
                            // 全削除
                            if (updateModeFlg)
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = true;
                            // ADD 2010/07/01----->>>                            // 引用登録
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = true;
                            // add end 2009/06/25 by gejun for RedMine #10103

                            e.NextCtrl = null;
                            uGrid_Details.Rows[0].Cells[1].Activate();
                            uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            break;
                        }
                    case "tComboEditor_GoodsNoFuzzy":
                        {
                            // 検索
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = true;

                            // add start 2009/06/25 by gejun for RedMine #10103
                            // 終了
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
                            // クリア
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
                            // 最新情報
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
                            // ガイド
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
                            // 保存
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
                            // 行削除
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                            // 全削除
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
                            // 引用登録
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
                            // add end 2009/06/25 by gejun for RedMine #10103
                            break;
                        }
                    case "ultraGrid_CarSpec":
                        {
                            // ガイド
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
                            // 検索
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
                            break;
                        }
      				}
			}
			#endregion
		}

        /// <summary>
        /// メーカー、BLコードのチェック。
        /// </summary>
        /// <param name="seisanYearDiv">生産年式</param>
        /// <returns>チェック結果</returns>
        private bool CheckMakeBlCode(UltraGridCell activeCell)
        {
            int rowIndex, colIndex = 0;
            FreeSearchParts freeSearchParts = null;
	        // 更新するのDataRow
			DataRow dr = null;

            UltraGridCell cell = activeCell;

            if (activeCell == null)
                return false;

            if (!PMJKN09011UC.COL_BLCODE_TITLE.Equals(cell.Column.Key) 
                    && !PMJKN09011UC.COL_MAKER_TITLE.Equals(cell.Column.Key))
                return true;

            rowIndex = cell.Row.Index;
            colIndex = cell.Column.Index;//del 2010/06/29 by gejun for RedMine #10103
            dr = this._detailDataTable.Rows[rowIndex];

            if (this._freeSearchPartsDty.ContainsKey(dr[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].ToString()))
                freeSearchParts = this._freeSearchPartsDty[dr[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].ToString()];
            else
                return false;

            #region BLコード
            //------------------------------------------------------------
            // ActiveCellが「BLコード」の場合
            //------------------------------------------------------------
            if (cell.Column.Key == PMJKN09011UC.COL_BLCODE_TITLE)
            {
                int blCode = TStrConv.StrToIntDef(cell.Text, 0);

                //>>>2010/07/02
                //if (blCode != 0)
                if ((blCode != 0) && (blCode.ToString().PadLeft(5, '0') != this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_BLCODE_TITLE].ToString().Trim()))
                //<<<2010/07/02
                {
                    //-----------------------------------------------------------------------------
                    // BLコード検索
                    //-----------------------------------------------------------------------------
                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    List<Stock> stockList = new List<Stock>();

                    //del  start  2010/06/29 by gejun for RedMine #10103
                    //// BLコードの設定
                    //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_BLCODE_TITLE] = blCode.ToString().PadLeft(5, '0');
                    //freeSearchParts.TbsPartsCode = blCode;
                    //del  end  2010/06/29 by gejun for RedMine #10103
                    BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
                    BLGoodsCdUMnt bLGoodsCdUMnt;

                    int status = bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, blCode);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //add  start  2010/06/29 by gejun for RedMine #10103
                        // BLコードの設定
                        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_BLCODE_TITLE] = blCode.ToString().PadLeft(5, '0');
                        freeSearchParts.TbsPartsCode = blCode;
                        //add  end  2010/06/29 by gejun for RedMine #10103
                        //>>>2010/07/02
                        //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNM_TITLE] = bLGoodsCdUMnt.BLGoodsFullName;
                        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNM_TITLE] = bLGoodsCdUMnt.BLGoodsHalfName;
                        //<<<2010/07/02
                    }
                    else
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "BLコード [" + blCode.ToString() + "] に該当するデータが存在しません。",
                           -1,
                           MessageBoxButtons.OK);

                        SetCellBeforeValue(cell.Column.Key, rowIndex, colIndex);//add 2010/06/29 by gejun for RedMine #10103

                        return false;
                    }
                }
            }
            # endregion

            #region メーカー
            //------------------------------------------------------------
            // ActiveCellが「メーカー」の場合
            //------------------------------------------------------------
            if (cell.Column.Key == PMJKN09011UC.COL_MAKER_TITLE)
            {
                if (TStrConv.StrToIntDef(cell.Text.ToString(), 0) != 0)
                {
                    if (!String.IsNullOrEmpty(cell.Text))
                    {
                        MakerAcs makerAcs = new MakerAcs();
                        MakerUMnt makerUMnt;
                        //メーカーデータの取得
                        int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, TStrConv.StrToIntDef(cell.Text, 0));
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_INFO,
                               this.Name,
                               "メーカーコード [" + cell.Text + "] に該当するデータが存在しません。",
                               -1,
                               MessageBoxButtons.OK);

                            SetCellBeforeValue(cell.Column.Key, rowIndex, colIndex);//add 2010/06/29 by gejun for RedMine #10103

                            return false;
                        }
                        dr[PMJKN09011UC.COL_MAKER_TITLE] = cell.Text.PadLeft(4, '0');
                        freeSearchParts.GoodsMakerCd = Convert.ToInt32(cell.Text);

                    }
                    else
                    {
                        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_MAKER_TITLE] = 0;
                        freeSearchParts.GoodsMakerCd = 0;
                    }
                }
            }

            return true;
            # endregion
        }

		/// <summary>
		/// 生産年式のチェック。
		/// </summary>
		/// <param name="seisanYearDiv">生産年式</param>
		/// <returns>チェック結果</returns>
		private bool CheckYearDiv(string seisanYearDiv)
		{
			bool bNext = true;
			String[] createYear = seisanYearDiv.Split('-');
			createYear[0] = createYear[0].Trim();
			createYear[1] = createYear[1].Trim();

			if (!createYear[0].Equals("____.__") && !IsDate(createYear[0]))
			{
			    TMsgDisp.Show(this,
						       emErrorLevel.ERR_LEVEL_INFO,
						       this.Name,
						       "開始日付の入力が不正です。",
						       -1,
						       MessageBoxButtons.OK);
				bNext = false;
			}
			if (bNext && !createYear[1].Equals("____.__") && !IsDate(createYear[1]))
			{
			    TMsgDisp.Show(this,
						       emErrorLevel.ERR_LEVEL_INFO,
						       this.Name,
						       "終了日付の入力が不正です。",
						       -1,
						       MessageBoxButtons.OK);
				bNext = false;
			}
			if (bNext && (!createYear[0].Equals("____.__") || !createYear[1].Equals("____.__")))
			{
                DateTime stCreateYear = DateTime.MinValue;
                DateTime edCreateYear = DateTime.MinValue;
                if (!createYear[0].Equals("____.__"))
                    stCreateYear = DateTime.Parse(createYear[0]);
                if (!createYear[1].Equals("____.__"))
				    edCreateYear = DateTime.Parse(createYear[1]);

				if (stCreateYear.CompareTo(edCreateYear) > 0)
				{
				    TMsgDisp.Show(this,
							       emErrorLevel.ERR_LEVEL_INFO,
							       this.Name,
							       "開始日付以上の日付を入力して下さい。",
							       -1,
							       MessageBoxButtons.OK);
					bNext = false;
				}
                else if (stCreateYear == DateTime.MinValue)
                {
                    TMsgDisp.Show(this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   "開始日付を入力して下さい。",
                                   -1,
                                   MessageBoxButtons.OK);
                    bNext = false;
                }

			}

			return bNext;
		}

		/// <summary>
        /// 車台番号のチェック。
        /// </summary>
        /// <param name="createNo">車台番号</param>
        /// <returns>チェック結果</returns>
        private bool CheckCarNo(string createNo)
        {
            bool retFlg = true;

            // ADD 2010/07/02 ------>>>
            if(string.IsNullOrEmpty(createNo.Trim()))
                return retFlg;
            // ADD 2010/07/02 ------>>>

            String[] createCarNo = createNo.Trim().Split('-');
            int stCreateCarNo = 0;
            int EdCreateCarNo = 0;
            if (!string.IsNullOrEmpty(createCarNo[0].Trim()) && !createCarNo[0].Trim().Equals("________"))
            {
                stCreateCarNo = Convert.ToInt32(createCarNo[0].Trim().Replace("_", string.Empty));

                if (stCreateCarNo == 0)
                {
                    TMsgDisp.Show(this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "開始番号を入力して下さい。",
                       -1,
                       MessageBoxButtons.OK);

                    retFlg = false;
                }
            }

            if (!string.IsNullOrEmpty(createCarNo[1].Trim()) && !createCarNo[1].Trim().Equals("________"))
            {
                EdCreateCarNo = Convert.ToInt32(createCarNo[1].Trim().Replace("_", string.Empty));

                if (EdCreateCarNo == 0)
                {
                    TMsgDisp.Show(this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "終了番号を入力して下さい。",
                       -1,
                       MessageBoxButtons.OK);
                    retFlg = false;
                }
            }

            if ((!String.IsNullOrEmpty(createCarNo[0].Trim()) && !createCarNo[0].Trim().Equals("________"))
                && (!string.IsNullOrEmpty(createCarNo[1].Trim()) && !createCarNo[1].Trim().Equals("________")))
            {
                if (stCreateCarNo > EdCreateCarNo)
                {
                    TMsgDisp.Show(this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   "開始番号以上の番号を入力して下さい。",
                                   -1,
                                   MessageBoxButtons.OK);
                    retFlg = false;
                }
            }
            return retFlg;
        }

        /// <summary>
        /// 車台番号のチェック。
        /// </summary>
        /// <param name="createNo">車台番号</param>
        /// <param name="rowIndex">行番号/param>
        /// <param name="colIndex">列番号/param>
        /// <returns>チェック結果</returns>
        private bool CheckCarNoWithErrorHandle(string createNo, int rowIndex, int colIndex)
        {
            string createcarNo = "";
            bool retFlg = true;
            String[] createCarNo = createNo.Trim().Split('-');
            int stCreateCarNo = 0;
            int EdCreateCarNo = 0;
            if (!string.IsNullOrEmpty(createCarNo[0].Trim()) && !createCarNo[0].Trim().Equals("________"))
            {
                stCreateCarNo = Convert.ToInt32(createCarNo[0].Trim().Replace("_", string.Empty));

                if (stCreateCarNo == 0)
                {
                    TMsgDisp.Show(this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "開始番号を入力して下さい。",
                       -1,
                       MessageBoxButtons.OK);

                    retFlg = false;
                }
            }

            if (!string.IsNullOrEmpty(createCarNo[1].Trim()) && !createCarNo[1].Trim().Equals("________"))
            {
                EdCreateCarNo = Convert.ToInt32(createCarNo[1].Trim().Replace("_", string.Empty));

                if (EdCreateCarNo == 0)
                {
                    TMsgDisp.Show(this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "終了番号を入力して下さい。",
                       -1,
                       MessageBoxButtons.OK);
                    retFlg = false;
                }
            }

            if ((!String.IsNullOrEmpty(createCarNo[0].Trim()) && !createCarNo[0].Trim().Equals("________"))
                && (!string.IsNullOrEmpty(createCarNo[1].Trim()) && !createCarNo[1].Trim().Equals("________")))
            {
                if (stCreateCarNo > EdCreateCarNo)
                {
                    TMsgDisp.Show(this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   "開始番号以上の番号を入力して下さい。",
                                   -1,
                                   MessageBoxButtons.OK);
                    retFlg = false;
                }
            }

            if (retFlg)
            {
                if (stCreateCarNo != 0)
                {
                    createcarNo = createcarNo + stCreateCarNo.ToString().PadLeft(8, '_');
                }
                else
                {
                    createcarNo = createcarNo + "________";
                }
                createcarNo = createcarNo + " - ";
                if (EdCreateCarNo != 0)
                {
                    createcarNo = createcarNo + EdCreateCarNo.ToString().PadLeft(8, '_');
                }
                else
                {
                    createcarNo = createcarNo + "________";
                }
                uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = createcarNo;
            }
            return retFlg;
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
            // add start 2009/06/22 by gejun for RedMine #10103
            if (this._categoryNo.Equals(this.tNedit_ModelDesignationNo.Text + this.tNedit_CategoryNo.Text)
                && this._fullCarType.Equals(this.tNedit_MakerCode.Text + this.tNedit_ModelCode.Text + this.tNedit_ModelSubCode.Text)
                && this._designationNo.Equals(this.tEdit_FullModel.Text) && this.tEdit_FullModel.Text.Trim() != "")
            {
                return retStatus = (int)ConstantManagement.MethodResult.ctFNC_DO_END;
            }
            // add end 2009/06/22 by gejun for RedMine #10103 

			this._beforeCarSearchBuffer.StartProduceFrameNo = tEdit_StartProduceFrameNo.Text.Trim();
			this._beforeCarSearchBuffer.EndProduceFrameNo = tEdit_EndProduceFrameNo.Text.Trim();
			string startDate = string.Empty;
			if (!string.IsNullOrEmpty(this.tDateEdit_StartEntryYearDate.Text))
			{
				startDate += this.tDateEdit_StartEntryYearDate.Text;
			}
			if (!string.IsNullOrEmpty(this.tDateEdit_StartEntryMonthDate.Text))
			{
				startDate += this.tDateEdit_StartEntryMonthDate.Text;
			}
			if (!string.IsNullOrEmpty(startDate))
			{
				this._beforeCarSearchBuffer.StartEntryDate = Convert.ToInt32(startDate);
			}

			string endDate = string.Empty;
			if (!string.IsNullOrEmpty(this.tDateEdit_EndEntryYearDate.Text))
			{
				endDate += this.tDateEdit_EndEntryYearDate.Text;
			}
			if (!string.IsNullOrEmpty(this.tDateEdit_EndEntryMonthDate.Text))
			{
				endDate += this.tDateEdit_EndEntryMonthDate.Text;
			}
			if (!string.IsNullOrEmpty(endDate))
			{
				this._beforeCarSearchBuffer.EndEntryDate = Convert.ToInt32(endDate);
			}

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
			this._carInfo = dat;
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
                // add start 2009/06/22 by gejun for RedMine #10103
                //if(this._categoryNo.Equals(this.tNedit_ModelDesignationNo.Text + this.tNedit_CategoryNo.Text)
                //    && this._fullCarType.Equals(this.tNedit_MakerCode.Text + this.tNedit_ModelCode.Text + this.tNedit_ModelSubCode.Text)
                //    && this._designationNo.Equals(this.tEdit_FullModel.Text) && this.tEdit_FullModel.Text.Trim() != "")
                //{
                //   return retStatus = (int)ConstantManagement.MethodResult.ctFNC_DO_END;
                //}
                // add end 2009/06/22 by gejun for RedMine #10103
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

		/// <summary>
		/// tNedit_ModelSubCode_AfterExitEditModeイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void tNedit_ModelSubCode_AfterExitEditMode(object sender, EventArgs e)
		{
            TNedit tNedit = (TNedit)sender;
			//ｶｰﾒｰｶｰｺｰﾄ
			string makerCode = this.tNedit_MakerCode.Text;
			//車種ｺｰﾄ
			string modelCode = this.tNedit_ModelCode.Text;
			//車種呼称ｺｰﾄ
			string modelSubCode = this.tNedit_ModelSubCode.Text;
			MakerAcs makerAcs = new MakerAcs();
			MakerUMnt makerUMnt;
			ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
			ModelNameU modelNameU;
			if (!string.IsNullOrEmpty(makerCode))
			{
				if ((this.tNedit_MakerCode.GetInt() != 0)&&(this.tNedit_ModelCode.GetInt() == 0))
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
                        TMsgDisp.Show(this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "該当データがありません。",
                           -1,
                           MessageBoxButtons.OK);
                        tNedit.Clear();
                        tNedit.Focus();
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
                        TMsgDisp.Show(this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "該当データがありません。",
                           -1,
                           MessageBoxButtons.OK);
                        tNedit.Clear();
                        tNedit.Focus();
					}
				}
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
		}

		/// <summary>
		/// tNedit_SearchGoodsNo_TextChangedイベント
		/// </summary>
        private bool tNedit_SearchGoodsNo_TextChanged()
		{
			if (!string.IsNullOrEmpty(this.tNedit_SearchGoodsNo.Text) && !string.IsNullOrEmpty(this.EndSearchGoodsNo.Text))
			{
				if (this.tNedit_SearchGoodsNo.GetInt() > Convert.ToInt32(this.EndSearchGoodsNo.Text)
                    || this.tNedit_SearchGoodsNo.GetInt() < Convert.ToInt32(this.StartSearchGoodsNo.Text))
				{
					TMsgDisp.Show(this,
								   emErrorLevel.ERR_LEVEL_INFO,
								   this.Name,
								   "範囲内の番号を入力して下さい。",
								   -1,
								   MessageBoxButtons.OK);
                    if (_beforeRecordNum == 0)
                    {
                        this.tNedit_SearchGoodsNo.SetInt(1);
                    }
                    else
                    {
                        this.tNedit_SearchGoodsNo.SetInt(_beforeRecordNum);
                    }

                    tNedit_SearchGoodsNo.Focus();
                    return false;
				}
				else
				{
                    // --- UPD m.suzuki 2010/06/01 ---------->>>>>
                    //if (this.tNedit_SearchGoodsNo.GetInt() <= this._carModelInfoDataTable.Rows.Count)
                    if ( this.tNedit_SearchGoodsNo.GetInt() <= this._selectCarModelInfoDataTable.Rows.Count )
                    // --- UPD m.suzuki 2010/06/01 ----------<<<<<
					{
                        this._beforeRecordNum = this.tNedit_SearchGoodsNo.GetInt();
                        DataRow carModelInfoRow = null;

                        // --- UPD m.suzuki 2010/06/01 ---------->>>>>
                        //if (_singleIndex == 0)
                        //{
                        //    carModelInfoRow = this._carModelInfoDataTable.Rows[this.tNedit_SearchGoodsNo.GetInt() - 1];
                        //}
                        //else
                        //{
                        //    carModelInfoRow = this._carModelInfoDataTable.Rows[_singleIndex - 1];
                        //}
                        //_singleIndex = 0;
                        carModelInfoRow = this._selectCarModelInfoDataTable.Rows[this.tNedit_SearchGoodsNo.GetInt() - 1];
                        // --- UPD m.suzuki 2010/06/01 ----------<<<<<

						this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].Clear();
						DataRow carSpecDr = this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].NewRow();
                        this.tEdit_FullModel.Text = carModelInfoRow["FullModel"].ToString();
                        this._fullModel = carModelInfoRow["FullModel"].ToString();
                        //グレード
						carSpecDr[PMJKN09011UB.COL_MODELGRADENM_TITLE] = carModelInfoRow["ModelGradeNm"].ToString();
						//ボディ
						carSpecDr[PMJKN09011UB.COL_BODYNAME_TITLE] = carModelInfoRow["BodyName"].ToString();
						//ドア
                        carSpecDr[PMJKN09011UB.COL_DOORCOUNT_TITLE] = carModelInfoRow["DoorCount"].ToString();
						//エンジン
						carSpecDr[PMJKN09011UB.COL_ENGINEMODELNM_TITLE] = carModelInfoRow["EngineModelNm"].ToString();
						//排気量
						carSpecDr[PMJKN09011UB.COL_ENGINEDISPLACENM_TITLE] = carModelInfoRow["EngineDisplaceNm"].ToString();
						//E区分
						carSpecDr[PMJKN09011UB.COL_EDIVNM_TITLE] = carModelInfoRow["EDivNm"].ToString();
						//ミッション
						carSpecDr[PMJKN09011UB.COL_TRANSMISSIONNM_TITLE] = carModelInfoRow["TransmissionNm"].ToString();
						//駆動形式
						carSpecDr[PMJKN09011UB.COL_WHEELDRIVEMETHODNM_TITLE] = carModelInfoRow["WheelDriveMethodNm"].ToString();
						//シフト
						carSpecDr[PMJKN09011UB.COL_SHIFTNM_TITLE] = carModelInfoRow["ShiftNm"].ToString();

						this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].Rows.Add(carSpecDr);

						this.ultraGrid_CarSpec.DataSource = this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].DefaultView;

                        this.ultraGrid_CarSpec.Rows[0].Activation = Activation.Disabled;
      
                        tNedit_SearchGoodsNo.Focus();
					}

				}
    		}
			else
			{
                this.tNedit_SearchGoodsNo.Clear();
				this.tNedit_SearchGoodsNo.Focus();
			}

            return true;
		}


        // ADD START 2010/05/21 GEJUN FOR REDMINE#8049
        /// <summary>
		/// グリッドキーダウン、キーアップ処理
		/// </summary>
        /// <param name="activeCellKey">対象オブジェクトのキー</param>
        /// <param name="rowIndex">行番号</param>
        /// <param name="eventType">イベントタイプ</param>
        /// <param name="wrapFlg">換行フラグ</param>
        private void GridDownUpControl(String activeCellKey, int rowIndex, int eventType, bool wrapFlg)
        {
            int rowInx = rowIndex;
            if (wrapFlg)
            {
                // ↑Keyを実行
                if (eventType == 0)
                    rowInx--;
                // ↓Keyを実行
                else
                    rowInx++;
            }
            switch (activeCellKey)
            {
                // ｸﾞﾚｰﾄﾞ、ﾎﾞﾃﾞｨ、ﾄﾞｱ
                case PMJKN09011UC.COL_MODELGRADENM_TITLE:
                case PMJKN09011UC.COL_BODYNAME_TITLE:
                case PMJKN09011UC.COL_DOORCOUNT_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // ｴﾝｼﾞﾝ
                case PMJKN09011UC.COL_ENGINEMODELNM_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_MAKER_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // 排気量
                case PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // E区分、ﾐｯｼｮﾝ、駆動方式
                case PMJKN09011UC.COL_EDIVNM_TITLE:
                case PMJKN09011UC.COL_TRANSMISSIONNM_TITLE:
                case PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_PARTSQTY_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // ｼﾌﾄ
                case PMJKN09011UC.COL_SHIFTNM_TITLE:
                    {

                        // uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_COSTRATE_TITLE].Activate(); del 2010/06/21 by gejun for RedMine #10103
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_PARTSQTY_TITLE].Activate();//add 2010/06/21 by gejun for RedMine #10103
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // 摘要
                case PMJKN09011UC.COL_ADDICARSPEC_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_CREATEYEAR_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // 品番
                case PMJKN09011UC.COL_GOODSNO_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_MODELGRADENM_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // ﾒｰｶｰ
                case PMJKN09011UC.COL_MAKER_TITLE:
                    {
                        if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                        {
                            uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].Activate();
                            uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                // BLｺｰﾄﾞ
                case PMJKN09011UC.COL_BLCODE_TITLE:
                    {
                        if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                        {
                            uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].Activate();
                            uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;

                    }
                // QTY
                case PMJKN09011UC.COL_PARTSQTY_TITLE:
                    {
                        //uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_EDIVNM_TITLE].Activate();del 2010/06/21 by gejun for RedMine #10103
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].Activate();//add 2010/06/21 by gejun for RedMine #10103
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // 標準価格
                case PMJKN09011UC.COL_COSTRATE_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_SHIFTNM_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                // 生産年式、生産車台番号
                case PMJKN09011UC.COL_CREATEYEAR_TITLE:
                case PMJKN09011UC.COL_CREATECARNO_TITLE:
                    {
                        uGrid_Details.Rows[rowInx].Cells[PMJKN09011UC.COL_ADDICARSPEC_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                default:
                    break;
            }
        }


        //add start 2010/06/25 by gejun for RedMine #10103
        /// <summary>
        /// グリッド右キー、左キー処理
        /// </summary>
        /// <param name="keyDiv">キー区分/param>
        /// <param name="activeCell">対象セル</param>
        /// <param name="rowIndex">対象行番号</param>
        /// <param name="columnIndex">対象列番号</param>
        /// <param name="performActionFlg">アクション実行区分</param>
        private void GridRightLeftControl(int keyDiv, UltraGridCell activeCell, int rowIndex, int columnIndex, bool performActionFlg)
        {
            // 右キー
            if (keyDiv == 0)
            {
                if (activeCell.SelStart < activeCell.Text.Length)
                {
                    if (activeCell.SelText.Length > 0)
                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = activeCell.SelStart +
                            activeCell.SelLength;
                    else
                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart++;
                    uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelLength = 0;
                }
                else
                {
                    if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                    {
                        uGrid_Details.Rows[rowIndex].Cells[columnIndex].Activate();
                        if (performActionFlg)
                            uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
            else
            {
                if (activeCell.SelStart > 0 )
                {
                    if (activeCell.SelLength == 0)
                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart--; 
                    uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelLength = 0;
                }
                else
                {
                    if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                    {
                        uGrid_Details.Rows[rowIndex].Cells[columnIndex].Activate();
                        if (performActionFlg)
                            uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
        }
        //add end 2010/06/25 by gejun for RedMine #10103

        /// <summary>
        /// 編集モードから外すイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }
            int rowIndex = uGrid.ActiveCell.Row.Index;
            int colIndex = uGrid.ActiveCell.Column.Index;
            string colKey = uGrid.ActiveCell.Column.Key;

            if (PMJKN09011UC.COL_CREATEYEAR_TITLE.Equals(colKey))
            {
                if (!CheckYearDiv(this.uGrid_Details.ActiveCell.Text))
                {
                    SetCellBeforeValue(colKey, rowIndex, colIndex);
                    return;
                }
            }
        }

		/// <summary>
		/// グリッドキーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
		{
            // 上段判断フラグ
            bool upperFlg = false;// ADD 2010/05/21 GEJUN FOR REDMINE#8049
            // 活性セルのキー
            string activeCellKey;// ADD 2010/05/21 GEJUN FOR REDMINE#8049
			UltraGrid uGrid = (UltraGrid)sender;

			if (uGrid.ActiveCell == null)
			{
				return;
			}

			int rowIndex = uGrid.ActiveCell.Row.Index;
			int colIndex = uGrid.ActiveCell.Column.Index;
			string colKey = uGrid.ActiveCell.Column.Key;

            // ADD START 2010/05/21 GEJUN FOR REDMINE#8049
            // グリッド上段、下段の判断
            activeCellKey = uGrid.ActiveCell.Column.Key;
            UltraGridCell activeCell = this.uGrid_Details.ActiveCell;

            switch (activeCellKey)
            {
                case PMJKN09011UC.COL_GOODSNO_TITLE:
                case PMJKN09011UC.COL_MAKER_TITLE:
                case PMJKN09011UC.COL_BLCODE_TITLE:
                case PMJKN09011UC.COL_GOODSNM_TITLE:
                case PMJKN09011UC.COL_PARTSQTY_TITLE:
                case PMJKN09011UC.COL_COSTRATE_TITLE:
                case PMJKN09011UC.COL_CREATEYEAR_TITLE:
                case PMJKN09011UC.COL_CREATECARNO_TITLE:
                    {
                        upperFlg = true;
                        break;
                    }
                default:
                    {
                        upperFlg = false;
                        break;
                    }
            }
            // ADD END 2010/05/21 GEJUN FOR REDMINE#8049

			if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
			{
				// 品番
				if (uGrid.ActiveCell.Column.Key == PMJKN09011UC.COL_GOODSNO_TITLE && String.IsNullOrEmpty(uGrid.ActiveCell.Text))
				{
					return;
				}
                //del start 2010/06/21 by gejun for RedMine #10103
                //// メーカー
                //if (uGrid.ActiveCell.Column.Key == PMJKN09011UC.COL_MAKER_TITLE && String.IsNullOrEmpty(uGrid.ActiveCell.Text))
                //{
                //    return;
                //}
                //// BLコード
                //if (uGrid.ActiveCell.Column.Key == PMJKN09011UC.COL_BLCODE_TITLE && String.IsNullOrEmpty(uGrid.ActiveCell.Text))
                //{
                //    return;
                //}
                //del end 2010/06/21 by gejun for RedMine #10103
			}
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                if (!CheckNumber(uGrid_Details.Rows[rowIndex].Cells[colIndex].Text, rowIndex, activeCellKey))
                {
                    SetCellBeforeValue(activeCellKey, rowIndex, colIndex);
                    return;
                }
                // ADD 2010/07/01----->>>>
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                // ADD 2010/07/01----->>>>
                    if (PMJKN09011UC.COL_CREATEYEAR_TITLE.Equals(activeCellKey))
                    {
                        if (!CheckYearDiv(this.uGrid_Details.ActiveCell.Text))
                        {
                            SetCellBeforeValue(activeCellKey, rowIndex, colIndex);
                            return;
                        }
                    }
                }  // ADD 2010/07/01----->>>>
            }


			switch (e.KeyCode)
			{
            	case Keys.Up:
					{
						if (rowIndex == 0)
						{
                            // ADD START 2010/05/21 GEJUN FOR REDMINE#8049
							// 明細部の品番情報にフォーカスがある
                            if (upperFlg)
                            {
                                if (CheckMakeBlCode(this.uGrid_Details.ActiveCell))
                                {        
                                    // add start 2009/06/25 by gejun for RedMine #10103
                                    // 保存
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
                                    // 検索
                                    //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false; //DEL 2010/07/01 ----->>>
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = true;//ADD 2010/07/01 ----->>>
                                    // 行削除
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                                    // 全削除
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
                                    // ガイド
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
                                    // 引用登録
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
                                     // add end 2009/06/25 by gejun for RedMine #10103
                                    // 「検索条件－品番」へ移動
                                    this.tComboEditor_GoodsNoFuzzy.Focus();
                                }
                            }
                            else
                            {
                                this.GridDownUpControl(activeCellKey, rowIndex, 0, false);
                            }
                            // ADD END 2010/05/21 GEJUN FOR REDMINE#8049
						}
						else
						{
							e.Handled = true;
                            // 明細部の品番情報にフォーカスがある
                            // MODIFY START 2010/05/21 GEJUN FOR REDMINE#8049
                            if (upperFlg)
                            {
                                //uGrid.Rows[rowIndex - 1].Cells[colIndex].Activate();
                                //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                this.GridDownUpControl(activeCellKey, rowIndex, 0, true);
                            } 
                            else
                            {
                                this.GridDownUpControl(activeCellKey, rowIndex, 0, false);
                            }
                            // MODIFY END 2010/05/21 GEJUN FOR REDMINE#8049
						}
						break;
					}
				case Keys.Down:
					{
						e.Handled = true;
                        // MODIFY START 2010/05/21 GEJUN FOR REDMINE#8049
                        if (upperFlg)
                        {
                           this.GridDownUpControl(activeCellKey, rowIndex, 1, false);
                        }
                        else
                        {
                            if (rowIndex != uGrid.Rows.Count - 1)
                            {
                                //uGrid.Rows[rowIndex + 1].Cells[colIndex].Activate();
                                //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                this.GridDownUpControl(activeCellKey, rowIndex, 1, true);
                            }
                        }
                        // MODIFY END 2010/05/21 GEJUN FOR REDMINE#8049
						break;
					}
				case Keys.Left:
					{
						if (colIndex == 1)
						{
							if (rowIndex == 0)
							{
                                //tEdit_GoodsNo.Focus();//DEL 2010/05/21 GEJUN FOR REDMINE#8049
                                if (activeCell.SelStart <= 0)
                                {
                                    // add start 2009/06/25 by gejun for RedMine #10103
                                    // 保存
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
                                    // 検索
                                    //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;//DEL 2010/07/01 ----->>>
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = true;//ADD 2010/07/01 ----->>>
                                    // 行削除
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                                    // 全削除
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
                                    // ガイド
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
                                    // 引用登録
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
                                    // add end 2009/06/25 by gejun for RedMine #10103
                                    tComboEditor_GoodsNoFuzzy.Focus();//ADD 2010/05/21 GEJUN FOR REDMINE#8049
                                }    
							}
                            //ADD START 2010/05/21 GEJUN FOR REDMINE#8049
                            else
                            {

                                GridRightLeftControl(1, this.uGrid_Details.ActiveCell, rowIndex - 1, 
                                    uGrid_Details.Rows[rowIndex - 1].Cells[PMJKN09011UC.COL_ADDICARSPEC_TITLE].Column.Index, true);
                                //uGrid_Details.Rows[rowIndex - 1].Cells[PMJKN09011UC.COL_ADDICARSPEC_TITLE].Activate();
                                //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            //ADD END 2010/05/21 GEJUN FOR REDMINE#8049
						}
						else
						{
							e.Handled = true;
                            if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_CREATEYEAR_TITLE))
                            {
                                
                                // add start 2009/06/22 by gejun for RedMine #10103
                                if (activeCell.SelStart > 0)
                                {
                                    if (this.uGrid_Details.ActiveCell.SelStart == 10)
                                        //uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = activeCell.SelStart - 3; //DEL 2010/07/01
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = 0; //ADD 2010/07/01
                                    else if (this.uGrid_Details.ActiveCell.SelStart == 9)
                                        //uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = activeCell.SelStart - 2; //DEL 2010/07/01
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = 0; //ADD 2010/07/01
                                    else
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart--;
                                    uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelLength = 0;
                                }
                                else
                                {
                                    // add end 2009/06/22 by gejun for RedMine #10103
                                    GridRightLeftControl(1, this.uGrid_Details.ActiveCell, rowIndex, colIndex - 2, true);
                                    //uGrid_Details.Rows[rowIndex].Cells[colIndex - 2].Activate();
                                    //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }// add 2009/06/22 by gejun for RedMine #10103
                            }
                            // del start 2009/06/23 by gejun for RedMine #10103
                            ///else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_PARTSQTY_TITLE)
                            //    || PMJKN09011UC.COL_MODELGRADENM_TITLE.Equals(activeCellKey)) //ADD 2010/05/21 GEJUN FOR REDMINE#8049
                            // add end 2009/06/23 by gejun for RedMine #10103
                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_PARTSQTY_TITLE)) // add 2009/06/23 by gejun for RedMine #10103
                            {
                                // del start 2009/06/23 by gejun for RedMine #10103
                                // add start 2009/06/22 by gejun for RedMine #10103
                                //if (PMJKN09011UC.COL_MODELGRADENM_TITLE.Equals(activeCellKey))
                                //   this.focusMoveType = 2;
                                // add end 2009/06/22 by gejun for RedMine #10103
                                // del end 2009/06/23 by gejun for RedMine #10103
                                GridRightLeftControl(1, this.uGrid_Details.ActiveCell, rowIndex, colIndex - 2, true);
                                //uGrid_Details.Rows[rowIndex].Cells[colIndex - 2].Activate();
                                //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            // add start 2009/06/22 by gejun for RedMine #10103
                            // グレード
                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_MODELGRADENM_TITLE))
                            {
                                this.focusMoveType = 2;
                                //uGrid_Details.Rows[rowIndex].Cells[colIndex - 1].Activate();
                                //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                GridRightLeftControl(1, this.uGrid_Details.ActiveCell, rowIndex, colIndex - 1, true);
                            }
                            // 生産車台番号
                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_CREATECARNO_TITLE))
                            {

                                if (activeCell.SelStart > 0)
                                {
                                    if (this.uGrid_Details.ActiveCell.SelStart == 11)
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = activeCell.SelStart - 3;
                                    else if (this.uGrid_Details.ActiveCell.SelStart == 10)
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = activeCell.SelStart - 2;
                                    else
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart--;
                                    uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelLength = 0;
                                }
                                else
                                {
                                    this.focusMoveType = 2;
                                    GridRightLeftControl(1, this.uGrid_Details.ActiveCell, rowIndex, colIndex - 1, true);
                                }
                                
                            }
                            // add end 2009/06/22 by gejun for RedMine #10103
                            else
                            {
                                GridRightLeftControl(1, this.uGrid_Details.ActiveCell, rowIndex, colIndex - 1, true);
                                //uGrid.Rows[rowIndex].Cells[colIndex - 1].Activate();
                                //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
						}
						break;
					}
                case Keys.F2:
				case Keys.Right:
					{
						e.Handled = true;
						if (colIndex < 18)
						{
                            if (this.uGrid_Details.ActiveCell.Column.Key.Equals("品番"))
                            {
                                //add start 2010/06/21 by gejun for RedMine #10103
                                UltraGridCell cell = this.uGrid_Details.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(cell);
                                this.uGrid_Details.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                                if (cell.SelStart + cell.SelLength >= cell.Value.ToString().Length)
                                {
                                    uGrid_Details_AfterCellUpdate(this, cellEventArgs);
                                    if (goodsSearchFlg)
                                    {
                                        GridRightLeftControl(0, cell, rowIndex, colIndex + 2, false);
                                        //uGrid_Details.Rows[rowIndex].Cells[colIndex + 2].Activate();
                                        goodsSearchFlg = false;
                                    }
                                    else
                                        GridRightLeftControl(0, cell, rowIndex, colIndex + 1, false);
                                    //uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                    this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                    GridRightLeftControl(0, cell, rowIndex, colIndex, false);

                                //add end 2010/06/21 by gejun for RedMine #10103
                            }
                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals("生産年式"))
                            {
                                int selEnd = activeCell.SelStart + activeCell.SelLength;
                                // add start 2009/06/22 by gejun for RedMine #10103
                                if (selEnd < 17)
                                {
                                    if (selEnd == 7)
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = selEnd + 3;
                                    else if (selEnd == 8)
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = selEnd + 2;
                                    else
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart++;
                                    uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelLength = 0;
                                }
                                else
                                {
                                    // add end 2009/06/22 by gejun for RedMine #10103
                                    string yearDiv = this.uGrid_Details.ActiveCell.Text;
                                    if (CheckYearDiv(yearDiv))
                                    {
                                        this.uGrid_Details.ActiveCell.Value = yearDiv;
                                        this.focusMoveType = 1; // add 2009/06/23 by gejun for RedMine #10103
                                        //uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();  //DEL 2010/05/21 GEJUN FOR REDMINE#8049
                                        //uGrid_Details.Rows[rowIndex].Cells[colIndex + 2].Activate(); //ADD 2010/05/21 GEJUN FOR REDMINE#8049 DEL 2010/06/23 GEJUN FOR REDMINE#10103
                                        //uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate(); // ADD 2010/06/23 GEJUN FOR REDMINE#10103
                                        //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        GridRightLeftControl(0, this.uGrid_Details.ActiveCell, rowIndex, colIndex + 1, true);
                                    }
                                    // ADD 2010/07/01------>>>
                                    else
                                    {
                                        SetCellBeforeValue(colKey, rowIndex, colIndex);
                                        return;
                                    }
                                    // ADD 2010/07/01------>>>
                                }// add 2009/06/22 by gejun for RedMine #10103
                            }
                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals("生産車台番号"))
                            {
                                // add start 2009/06/23 by gejun for RedMine #10103
                                int selEnd = activeCell.SelStart + activeCell.SelLength;
                                if (selEnd < 19)
                                {
                                    if (selEnd == 8)
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = selEnd + 3;
                                    else if (selEnd == 9)
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart = selEnd + 2;
                                    else
                                        uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelStart++;
                                    uGrid_Details.Rows[activeCell.Row.Index].Cells[activeCell.Column.Index].SelLength = 0;
                                }
                                else
                                {
                                    // add end 2009/06/23 by gejun for RedMine #10103
                                    //uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                    //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    GridRightLeftControl(0, this.uGrid_Details.ActiveCell, rowIndex, colIndex + 1, true);
                                } // add 2009/06/23 by gejun for RedMine #10103
                            }
                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_BLCODE_TITLE))
                            {
                                //uGrid_Details.Rows[rowIndex].Cells[colIndex + 2].Activate();
                                //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                GridRightLeftControl(0, this.uGrid_Details.ActiveCell, rowIndex, colIndex + 2, true);
                            }
                            else if (this.uGrid_Details.ActiveCell.Column.Key.Equals(PMJKN09011UC.COL_PARTSQTY_TITLE))
                            {
                                this.focusMoveType = 1;// add 2009/06/22 by gejun for RedMine #10103
                                //uGrid_Details.Rows[rowIndex].Cells[colIndex + 2].Activate();
                                //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                GridRightLeftControl(0, this.uGrid_Details.ActiveCell, rowIndex, colIndex + 2, true);
                            }
                            else
                            {
                                GridRightLeftControl(0, this.uGrid_Details.ActiveCell, rowIndex, colIndex + 1, true);
                                //uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
						}
						else
						{
                            if (this.uGrid_Details.Rows.Count < MAX_ROW_COUNT
                                && rowIndex == (this.uGrid_Details.Rows.Count - 1))//ADD 2010/05/21 GEJUN FOR REDMINE#8049
							{
                                if (activeCell.SelStart < activeCell.Value.ToString().Length)
                                {
                                    if (activeCell.SelText.Length > 0)
                                        uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[activeCell.Column.Index].SelStart = activeCell.SelLength + activeCell.SelStart;
                                    else
                                        uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[activeCell.Column.Index].SelStart++;
                                    uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[activeCell.Column.Index].SelLength = 0;
                                }
                                else
                                {
                                    AddNewDetailRow();
                                    SettingGrid();
                                    uGrid.Rows[rowIndex + 1].Cells[1].Activate();
                                    uGrid_Details.Rows[rowIndex + 1].Cells[1].Activate();
                                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
							}
                            //ADD START 2010/05/21 GEJUN FOR REDMINE#8049
                            else if(rowIndex < (this.uGrid_Details.Rows.Count - 1))
                            {
                                //uGrid.Rows[rowIndex + 1].Cells[1].Activate();
                                //uGrid_Details.Rows[rowIndex + 1].Cells[1].Activate();
                                //uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                                GridRightLeftControl(0, this.uGrid_Details.ActiveCell, rowIndex + 1, 1, true);
                            }
                            //ADD END 2010/05/21 GEJUN FOR REDMINE#8049
						}
						break;
					}
               }
		}

		/// <summary>
		/// グリッドキープレスイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (this.uGrid_Details.ActiveCell == null) return;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

			//----------------------------------------------
			// コード関係はUI設定でチェック
			//----------------------------------------------
			if (cell.IsInEditMode)
			{
				// ＵＩ設定を参照
				if (uiSetControl1.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
				{
					e.Handled = true;
					return;
				}
			}

			//----------------------------------------------
			// ActiveCellがメーカーの場合
			//----------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_MAKER_TITLE)
			{
				// 編集モード中？
				if (cell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}

			//----------------------------------------------
			// ActiveCellがBLコードの場合
			//----------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_BLCODE_TITLE)
			{
				// 編集モード中？
				if (cell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(5, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}

			//----------------------------------------------
			// ActiveCellがQTYの場合
			//----------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_PARTSQTY_TITLE)
			{
				// 編集モード中？
				if (cell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}

			//----------------------------------------------
			// ActiveCellが標準価格の場合
			//----------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_COSTRATE_TITLE)
			{
				// 編集モード中？
				if (cell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(7, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}

			//----------------------------------------------
			// ActiveCellがﾄﾞｱの場合
			//----------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_DOORCOUNT_TITLE)
			{
				// 編集モード中？
				if (cell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}
		}
        // add start 2009/06/22 by gejun for RedMine #10103
        /// <summary>
        /// グリッドセル編集モード入れる後イベント
        /// </summar>y
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterEnterEditMode(object sender, EventArgs e)
        {
            UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int rowIndex = 0;
            if (cell == null) return;
            rowIndex = cell.Row.Index;
            if (focusMoveType != 0)
            {
                // 生産年式
                if (uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_CREATEYEAR_TITLE].IsInEditMode)
                {
                    if (focusMoveType == 1)
                        cell.SelStart = 0;
                    else
                        cell.SelStart = 10;
                    cell.SelLength = 7;
                }
                // 生産車台番号
                if (uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_CREATECARNO_TITLE].IsInEditMode)
                {
                    if (focusMoveType == 1)
                        cell.SelStart = 0;
                    else
                        cell.SelStart = 11;
                    cell.SelLength = 8;
                }
                focusMoveType = 0;
            }
        }

        // add end 2009/06/22 by gejun for RedMine #10103
		/// <summary>
		/// グリッドセルアップデート後イベント
		/// </summar>y
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

			// 行インデックス
			int rowIndex = GetActiveRowIndex();
            // グループのデータを更新する
            string fullModelGroup = this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_FULLMODELGROUP_TITLE].Text;
			// 更新するのDataRow
			DataRow dr = this._detailDataTable.Rows[rowIndex];
			FreeSearchParts freeSearchParts = null;
			if (this._freeSearchPartsDty.ContainsKey(dr[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].ToString()))
			{

				freeSearchParts = this._freeSearchPartsDty[dr[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].ToString()];
				if (freeSearchParts.DataStatus == DATASTATUSCODE_0)
				{
					// データステータス:　1 改修
					freeSearchParts.DataStatus = DATASTATUSCODE_1;
				}

				// メーカーコード
				if (freeSearchParts.MakerCode == 0)
				{
					freeSearchParts.MakerCode = this._makerCode;
				}
				// 車種コード
				if (freeSearchParts.ModelCode == 0)
				{
					freeSearchParts.ModelCode = this._modelCode;
				}
				// 車種サブコード
				if (freeSearchParts.ModelSubCode == 0)
				{
					freeSearchParts.ModelSubCode = this._modelSubCode;
				}
				// 型式（フル型）
				if (string.IsNullOrEmpty(freeSearchParts.FullModel))
				{
					freeSearchParts.FullModel = this._fullModel;
				}
			}
			else
			{
				freeSearchParts = new FreeSearchParts();
				// 自由検索部品固有番号
				freeSearchParts.FreSrchPrtPropNo = Guid.NewGuid().ToString().Replace("-", "");
				dr[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE] = freeSearchParts.FreSrchPrtPropNo;
				// 企業コード
				freeSearchParts.EnterpriseCode = this._enterpriseCode;
				// メーカーコード
				freeSearchParts.MakerCode = this._makerCode;
				// 車種コード
				freeSearchParts.ModelCode = this._modelCode;
				// 車種サブコード
				freeSearchParts.ModelSubCode = this._modelSubCode;
				// 型式（フル型）
				freeSearchParts.FullModel = this._fullModel;
				// データステータス:　2 新規追加データ
				freeSearchParts.DataStatus = DATASTATUSCODE_2;
				this._freeSearchPartsDty.Add(freeSearchParts.FreSrchPrtPropNo, freeSearchParts);

                //ADD START 2009/05/24 GEJUN FOR REDMINE#8049
                if (!_newLineRowIndexDic.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                    this._newLineRowIndexDic.Add(freeSearchParts.FreSrchPrtPropNo, this._detailDataTable.Rows.Count);
                //ADD END 2009/05/24 GEJUN FOR REDMINE#8049
			}

			#region 品番
			//------------------------------------------------------------
			// ActiveCellが品番の場合
			//------------------------------------------------------------
            if (cell.Column.Key == PMJKN09011UC.COL_GOODSNO_TITLE  && !existCheckFlg)
            {
                //add start 2010/06/24 by gejun for RedMine #10103
                string blCode, makeCode;
                string goodsNoCompStr = "";
                blCode= this.uGrid_Details.Rows[cell.Row.Index].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Value.ToString();
                makeCode = this.uGrid_Details.Rows[cell.Row.Index].Cells[PMJKN09011UC.COL_MAKER_TITLE].Value.ToString();
                if (goodsNoComp.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                    goodsNoCompStr = (string)goodsNoComp[freeSearchParts.FreSrchPrtPropNo];
                //if (!goodsNoCompStr.Equals(cell.Text + makeCode + blCode)) // del 2010/06/29 by gejun for RedMine #10103
                if (!goodsNoCompStr.Equals(cell.Text.Replace("-", string.Empty) + makeCode + blCode)) // add 2010/06/29 by gejun for RedMine #10103
                {
                    //add end 2010/06/24 by gejun for RedMine #10103
                    //string goodsNo = cell.Value.ToString(); del 2010/06/21 by gejun for RedMine #10103
                    string goodsNo = cell.Text; //add 2010/06/21 by gejun for RedMine #10103

                    if (!String.IsNullOrEmpty(goodsNo))
                    {
                        // 商品番号の設定
                        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNO_TITLE] = e.Cell.Text;
                        freeSearchParts.GoodsNo = e.Cell.Text;
                        freeSearchParts.GoodsNoNoneHyphen = e.Cell.Text.Replace("-", string.Empty);
                        // 商品メーカーコード
                        //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_MAKER_TITLE] = 0; //del  2010/06/21 by gejun for RedMine #10103 start
                        //freeSearchParts.GoodsMakerCd = 0;
                        // BLコード
                        //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_BLCODE_TITLE] = 0; //del  2010/06/21 by gejun for RedMine #10103 start
                        //freeSearchParts.TbsPartsCode = 0;
                        // add start 2010/06/24 by gejun for RedMine #10103
                        // 品名
                        //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNM_TITLE] = string.Empty;
                        // add end 2010/06/24 by gejun for RedMine #10103
                        // 部品QTY
                        //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_PARTSQTY_TITLE] = string.Empty;
                        //freeSearchParts.PartsQty = 0;
                        // 標準価格
                        //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_COSTRATE_TITLE] = "0";

                        object retObj;

                        switch (this.SearchGoodsAndRemain(goodsNo, out retObj))
                        {
                            case 0:
                                {
                                    if (retObj != null)
                                    {
                                        // 商品検索
                                        if (retObj is List<GoodsUnitData>)
                                        {
                                            List<GoodsUnitData> goodsUnitDataList = (List<GoodsUnitData>)retObj;
                                            //商品番号
                                            this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNO_TITLE] = ((GoodsUnitData)goodsUnitDataList[0]).GoodsNo;
                                            freeSearchParts.GoodsNo = ((GoodsUnitData)goodsUnitDataList[0]).GoodsNo;
                                            this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Value = ((GoodsUnitData)goodsUnitDataList[0]).GoodsNo;// add 2010/06/24 by gejun for RedMine #10103

                                            // 商品メーカーコード
                                            this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_MAKER_TITLE] = ((GoodsUnitData)goodsUnitDataList[0]).GoodsMakerCd.ToString().PadLeft(4, '0');
                                            freeSearchParts.GoodsMakerCd = ((GoodsUnitData)goodsUnitDataList[0]).GoodsMakerCd;
                                            // BLコード
                                            this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_BLCODE_TITLE] = ((GoodsUnitData)goodsUnitDataList[0]).BLGoodsCode.ToString().PadLeft(5, '0');
                                            freeSearchParts.TbsPartsCode = ((GoodsUnitData)goodsUnitDataList[0]).BLGoodsCode;
                                            // 品名
                                            //>>>2010/07/02
                                            //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNM_TITLE] = this.GetBLGoodsFullName(Convert.ToInt32(((GoodsUnitData)goodsUnitDataList[0]).BLGoodsCode));
                                            this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNM_TITLE] = ((GoodsUnitData)goodsUnitDataList[0]).GoodsName;
                                            //<<<2010/07/02
                                            // 部品QTY
                                            this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_PARTSQTY_TITLE] = 1;
                                            freeSearchParts.PartsQty = 1;

                                            if (((GoodsUnitData)goodsUnitDataList[0]).GoodsPriceList != null && ((GoodsUnitData)goodsUnitDataList[0]).GoodsPriceList.Count > 0)
                                            {

                                                // 標準価格
                                                GoodsPrice gp = ((GoodsUnitData)goodsUnitDataList[0]).GoodsPriceList[0];
                                                if (gp.ListPrice > 999)
                                                    this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_COSTRATE_TITLE] = String.Format("{0:0,0}", gp.ListPrice);
                                                else
                                                    this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_COSTRATE_TITLE] = gp.ListPrice.ToString();
                                            }

                                            this.goodsSearchFlg = true; //add 2010/06/21 by gejun for RedMine #10103
                                            //add 2010/06/25 by gejun for RedMine #10103
                                            //add 2010/06/24 by gejun for RedMine #10103
                                            if (goodsNoComp.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                                                goodsNoComp.Remove(freeSearchParts.FreSrchPrtPropNo);
                                            //goodsNoComp.Add(freeSearchParts.FreSrchPrtPropNo, goodsNo + freeSearchParts.GoodsMakerCd.ToString().PadLeft(4, '0') + freeSearchParts.TbsPartsCode.ToString().PadLeft(5, '0')); // del 2010/06/29 by gejun for RedMine #10103
                                            goodsNoComp.Add(freeSearchParts.FreSrchPrtPropNo, goodsNo.Replace("-", string.Empty) + freeSearchParts.GoodsMakerCd.ToString().PadLeft(4, '0') + freeSearchParts.TbsPartsCode.ToString().PadLeft(5, '0')); // add 2010/06/29 by gejun for RedMine #10103
                                        }
                                    }
                                    break;

                                }
                                // ADD 2010/07/01-------------------->>>
                            case -2:
                                {
                                    if (goodsNoComp.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                                        goodsNoComp.Remove(freeSearchParts.FreSrchPrtPropNo);
                                    goodsNoComp.Add(freeSearchParts.FreSrchPrtPropNo, goodsNo.Replace("-", string.Empty) + freeSearchParts.GoodsMakerCd.ToString().PadLeft(4, '0') + freeSearchParts.TbsPartsCode.ToString().PadLeft(5, '0'));
                                    break;
                                }
                                // ADD 2010/07/01-------------------->>>
                            //case -1:
                            //    {
                            //        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_COSTRATE_TITLE] = String.Empty;　//ADD 2009/05/20 GEJUN FOR REDMINE#8049
                            //        break;
                            //    }

                        }

                    }

                }//add 2010/06/24 by gejun for RedMine #10103
            }
			#endregion

            #region セルの内容チェック
            if (!CheckNumber(cell.Value.ToString(), rowIndex, cell.Column.Key))
            {
                SetCellBeforeValue(cell.Column.Key, rowIndex, uGrid_Details.ActiveCell.Column.Index);
                return;
            }
            if (PMJKN09011UC.COL_CREATEYEAR_TITLE.Equals(cell.Column.Key))
            {

                // if (!CheckYearDiv(this.uGrid_Details.ActiveCell.Text))// del 2009/06/22 by gejun for RedMine #10103
                if (!CheckYearDiv(cell.Text))// add 2009/06/22 by gejun for RedMine #10103
                {
                    //SetCellBeforeValue(cell.Column.Key, rowIndex, uGrid_Details.ActiveCell.Column.Index);// del 2009/06/22 by gejun for RedMine #10103
                    SetCellBeforeValue(cell.Column.Key, rowIndex, cell.Column.Index);// add 2009/06/22 by gejun for RedMine #10103
                    return;
                }
            }
            #endregion

            #region BLコード
            //------------------------------------------------------------
            // ActiveCellが「BLコード」の場合
            //------------------------------------------------------------
            else if (cell.Column.Key == PMJKN09011UC.COL_BLCODE_TITLE && !existCheckFlg)
            {
                int blCode = TStrConv.StrToIntDef(cell.Value.ToString(), 0);

                if (blCode != 0)
                {
                    //-----------------------------------------------------------------------------
                    // BLコード検索
                    //-----------------------------------------------------------------------------
                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                    List<Stock> stockList = new List<Stock>();
                    // del start 2010/06/29 by gejun for RedMine #10103
                    //// BLコードの設定
                    //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_BLCODE_TITLE] = blCode.ToString().PadLeft(5, '0');
                    //freeSearchParts.TbsPartsCode = blCode;
                    // del end 2010/06/29 by gejun for RedMine #10103
                    BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
                    BLGoodsCdUMnt bLGoodsCdUMnt;

                    int status = bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, blCode);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //>>>2010/07/02
                        //this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNM_TITLE] = bLGoodsCdUMnt.BLGoodsFullName;
                        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_GOODSNM_TITLE] = bLGoodsCdUMnt.BLGoodsHalfName;
                        //<<<2010/07/02
                        // add start 2010/06/29 by gejun for RedMine #10103
                        // BLコードの設定
                        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_BLCODE_TITLE] = blCode.ToString().PadLeft(5, '0');
                        freeSearchParts.TbsPartsCode = blCode;
                        // add end 2010/06/29 by gejun for RedMine #10103
                    }
                    else
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "BLコード [" + blCode.ToString() + "] に該当するデータが存在しません。",
                           -1,
                           MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
            #endregion

            #region メーカー
            //------------------------------------------------------------
            // ActiveCellが「メーカー」の場合
            //------------------------------------------------------------
            if (cell.Column.Key == PMJKN09011UC.COL_MAKER_TITLE && !existCheckFlg)
            {
                //add start 2010/06/21 by gejun for RedMine #10103
                if (TStrConv.StrToIntDef(cell.Value.ToString(), 0) != 0)
                {
                    //add end 2010/06/21 by gejun for RedMine #10103
                    if (!String.IsNullOrEmpty(e.Cell.Text))
                    {
                        // add start 2010/06/24 by gejun for RedMine #10103
                        MakerAcs makerAcs = new MakerAcs();
                        MakerUMnt makerUMnt;
                        //メーカーデータの取得
                        int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, TStrConv.StrToIntDef(e.Cell.Text, 0));
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_INFO,
                               this.Name,
                               "メーカーコード [" + e.Cell.Text + "] に該当するデータが存在しません。",
                               -1,
                               MessageBoxButtons.OK);
                        }
                        // add　end 2010/06/24 by gejun for RedMine #10103
                        dr[PMJKN09011UC.COL_MAKER_TITLE] = e.Cell.Text.PadLeft(4, '0');
                        freeSearchParts.GoodsMakerCd = Convert.ToInt32(e.Cell.Text);
                    }
                    else
                    {
                        this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_MAKER_TITLE] = 0;
                        freeSearchParts.GoodsMakerCd = 0;
                    }
                }//add  2010/06/21 by gejun for RedMine #10103
            }
            #endregion

			#region QTY
			//------------------------------------------------------------
			// ActiveCellが「QTY」の場合
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_PARTSQTY_TITLE)
			{
                if (!String.IsNullOrEmpty(e.Cell.Text))
                {
                    dr[PMJKN09011UC.COL_PARTSQTY_TITLE] = Convert.ToInt32(e.Cell.Text);
                    freeSearchParts.PartsQty = Convert.ToInt32(e.Cell.Text);
                }
                else
                {
                    dr[PMJKN09011UC.COL_PARTSQTY_TITLE] = 0;
                    freeSearchParts.PartsQty = 0;
                }
			}
			#endregion

			#region 生産年式
			//------------------------------------------------------------
			// ActiveCellが「生産年式」の場合
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_CREATEYEAR_TITLE)
			{

				if (!String.IsNullOrEmpty(e.Cell.Text))
				{

                    // string yearDiv = this.uGrid_Details.ActiveCell.Text;// del 2009/06/22 by gejun for RedMine #10103
                    string yearDiv = cell.Text;// add 2009/06/22 by gejun for RedMine #10103
					String[] createYear = e.Cell.Text.Split('-');
					createYear[0] = createYear[0].Trim();
					createYear[1] = createYear[1].Trim();
                    // チェック
                    if (!CheckYearDiv(yearDiv))
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_CREATEYEAR_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }

                    if (!createYear[0].Equals("____.__") && !createYear[1].Equals("____.__"))
                    {
                        DateTime stCreateYear = DateTime.Parse(createYear[0]);
                        DateTime edCreateYear = DateTime.Parse(createYear[1]);
                        dr[PMJKN09011UC.COL_CREATEYEAR_TITLE] = e.Cell.Text;
                        // 型式別部品採用年月
                        freeSearchParts.ModelPrtsAdptYm = stCreateYear;
                        // 型式別部品廃止年月
                        freeSearchParts.ModelPrtsAblsYm = edCreateYear;
                    }
                    // ADD 2010/07/02 ------>>>
                    else
                    {
                        // 型式別部品採用年月
                        freeSearchParts.ModelPrtsAdptYm = DateTime.MinValue;
                        // 型式別部品廃止年月
                        freeSearchParts.ModelPrtsAblsYm = DateTime.MinValue;
                    }
                    // ADD 2010/07/02 ------>>>    
                    return;
				}
			}
			#endregion

			#region 生産車台番号
			//------------------------------------------------------------
			// ActiveCellが「生産車台番号」の場合
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_CREATECARNO_TITLE)
			{

				if (!String.IsNullOrEmpty(e.Cell.Value.ToString()))
                {
                    String[] createCarNo = e.Cell.Value.ToString().Trim().Split('-');
					int stCreateCarNo = 0;
                    int EdCreateCarNo = 0;
                    if (!CheckCarNo(e.Cell.Value.ToString()))
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_CREATECARNO_TITLE].Activate();
                        uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }

                    // ADD 2010/07/02 ------>>>
                    if (!string.IsNullOrEmpty(e.Cell.Value.ToString().Trim()))
                    {
                    // ADD 2010/07/02 ------>>>
                        if (!string.IsNullOrEmpty(createCarNo[0].Trim()) && !createCarNo[0].Trim().Equals("________"))
                        {
                            stCreateCarNo = Convert.ToInt32(createCarNo[0].Trim().Replace("_", string.Empty));
                        }

                        if (!string.IsNullOrEmpty(createCarNo[1].Trim()) && !createCarNo[1].Trim().Equals("________"))
                        {
                            EdCreateCarNo = Convert.ToInt32(createCarNo[1].Trim().Replace("_", string.Empty));
                        }
                    } // ADD 2010/07/02 ------>>>

                    string createcarNo = "";
                    if (stCreateCarNo != 0)
                    {
                        createcarNo = createcarNo + stCreateCarNo.ToString().PadLeft(8, '_');
                    }
                    else
                    {
                        createcarNo = createcarNo + "________";
                    }
                    createcarNo = createcarNo + " - ";
                    if (EdCreateCarNo != 0)
                    {
                        createcarNo = createcarNo + EdCreateCarNo.ToString().PadLeft(8, '_');
                    }
                    else
                    {
                        createcarNo = createcarNo + "________";
                    }

                    //dr[PMJKN09011UC.COL_CREATECARNO_TITLE] = e.Cell.Text;
                    dr[PMJKN09011UC.COL_CREATECARNO_TITLE] = createcarNo;
					// 型式別部品採用車台番号
					freeSearchParts.ModelPrtsAdptFrameNo = stCreateCarNo;
					// 型式別部品廃止車台番号
					freeSearchParts.ModelPrtsAblsFrameNo = EdCreateCarNo;
				}
			}
			#endregion

			#region グレード
			//------------------------------------------------------------
			// ActiveCellが「グレード」の場合
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_MODELGRADENM_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_MODELGRADENM_TITLE] = e.Cell.Text;
					freeSearchParts.ModelGradeNm = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_MODELGRADENM_TITLE] = string.Empty;
					freeSearchParts.ModelGradeNm = string.Empty;
				}
			}
			#endregion

			#region ボディ
			//------------------------------------------------------------
			// ActiveCellが「ボディ」の場合
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_BODYNAME_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_BODYNAME_TITLE] = e.Cell.Text;
					freeSearchParts.BodyName = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_BODYNAME_TITLE] = string.Empty;
					freeSearchParts.BodyName = string.Empty;
				}
			}
			#endregion

			#region ドア
			//------------------------------------------------------------
			// ActiveCellが「ドア」の場合
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_DOORCOUNT_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text) && e.Cell.Text != "0")
				{
					dr[PMJKN09011UC.COL_DOORCOUNT_TITLE] = Convert.ToInt32(e.Cell.Text);
					freeSearchParts.DoorCount = Convert.ToInt32(e.Cell.Text);
				}
				else
				{
					dr[PMJKN09011UC.COL_DOORCOUNT_TITLE] = string.Empty;
					freeSearchParts.DoorCount = 0;
				}
			}
			#endregion

			#region エンジン
			//------------------------------------------------------------
			// ActiveCellが「エンジン」の場合
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_ENGINEMODELNM_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_ENGINEMODELNM_TITLE] = e.Cell.Text;
					freeSearchParts.EngineModelNm = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_ENGINEMODELNM_TITLE] = string.Empty;
					freeSearchParts.EngineModelNm = string.Empty;
				}
			}
			#endregion

			#region 排気量
			//------------------------------------------------------------
			// ActiveCellが「排気量」の場合
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE] = e.Cell.Text;
					freeSearchParts.EngineDisplaceNm = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE] = string.Empty;
					freeSearchParts.EngineDisplaceNm = string.Empty;
				}
			}
			#endregion

			#region E区分
			//------------------------------------------------------------
			// ActiveCellが「E区分」の場合
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_EDIVNM_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_EDIVNM_TITLE] = e.Cell.Text;
					freeSearchParts.EDivNm = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_EDIVNM_TITLE] = string.Empty;
					freeSearchParts.EDivNm = string.Empty;
				}
			}
			#endregion

			#region ミッション
			//------------------------------------------------------------
			// ActiveCellが「ミッション」の場合
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_TRANSMISSIONNM_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE] = e.Cell.Text;
					freeSearchParts.TransmissionNm = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE] = string.Empty;
					freeSearchParts.TransmissionNm = string.Empty;
				}
			}
			#endregion

			#region 駆動形式
			//------------------------------------------------------------
			// ActiveCellが「駆動形式」の場合
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE] = e.Cell.Text;
					freeSearchParts.WheelDriveMethodNm = e.Cell.Text;

				}
				else
				{
					dr[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE] = string.Empty;
					freeSearchParts.WheelDriveMethodNm = string.Empty;
				}
			}
			#endregion

			#region シフト
			//------------------------------------------------------------
			// ActiveCellが「シフト」の場合
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_SHIFTNM_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_SHIFTNM_TITLE] = e.Cell.Text;
					freeSearchParts.ShiftNm = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_SHIFTNM_TITLE] = string.Empty;
					freeSearchParts.ShiftNm = string.Empty;
				}
			}
			#endregion

			#region 摘要
			//------------------------------------------------------------
			// ActiveCellが「摘要」の場合
			//------------------------------------------------------------
			if (cell.Column.Key == PMJKN09011UC.COL_ADDICARSPEC_TITLE)
			{
				if (!String.IsNullOrEmpty(e.Cell.Text))
				{
					dr[PMJKN09011UC.COL_ADDICARSPEC_TITLE] = e.Cell.Text;
					freeSearchParts.PartsOpNm = e.Cell.Text;
				}
				else
				{
					dr[PMJKN09011UC.COL_ADDICARSPEC_TITLE] = string.Empty;
					freeSearchParts.PartsOpNm = string.Empty;
				}
			}
			#endregion

			if (!string.IsNullOrEmpty(fullModelGroup))
			{
				foreach (FreeSearchParts fsp in this._freeSearchPartsDty.Values)
				{
					if (fullModelGroup == fsp.FullModelGroup)
					{
						// 品番
						fsp.GoodsNo = freeSearchParts.GoodsNo;
						// メーカー
						fsp.GoodsMakerCd = freeSearchParts.GoodsMakerCd;
						// BLコード
						fsp.TbsPartsCode = freeSearchParts.TbsPartsCode;
						// QTY
						fsp.PartsQty = freeSearchParts.PartsQty;
						// 生産年式
						fsp.ModelPrtsAdptYm = freeSearchParts.ModelPrtsAdptYm;
						fsp.ModelPrtsAblsYm = freeSearchParts.ModelPrtsAblsYm;
						// 生産車台番号
						fsp.ModelPrtsAdptFrameNo = freeSearchParts.ModelPrtsAdptFrameNo;
						fsp.ModelPrtsAblsFrameNo = freeSearchParts.ModelPrtsAblsFrameNo;
						// ｸﾞﾚｰﾄﾞ
						fsp.ModelGradeNm = freeSearchParts.ModelGradeNm;
						// ﾎﾞﾃﾞｨ
						fsp.BodyName = freeSearchParts.BodyName;
						// ﾄﾞｱ
						fsp.DoorCount = freeSearchParts.DoorCount;
						// ｴﾝｼﾞﾝ
						fsp.EngineModelNm = freeSearchParts.EngineModelNm;
						// 排気量
						fsp.EngineDisplaceNm = freeSearchParts.EngineDisplaceNm;
						// E区分
						fsp.EDivNm = freeSearchParts.EDivNm;
						// ﾐｯｼｮﾝ
						fsp.TransmissionNm = freeSearchParts.TransmissionNm;
						// 駆動形式
						fsp.WheelDriveMethodNm = freeSearchParts.WheelDriveMethodNm;
						// ｼﾌﾄ
						fsp.ShiftNm = freeSearchParts.ShiftNm;
						// 摘要
						fsp.PartsOpNm = freeSearchParts.PartsOpNm;

						if (fsp.DataStatus == DATASTATUSCODE_0)
						{
							// データステータス:　1 改修
							fsp.DataStatus = DATASTATUSCODE_1;
						}
					}
				}
			}


			// 明細グリッド設定処理
			this.SettingGrid();
		}

		/// <summary>
		/// ツールバーボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
            if (!("ButtonTool_Guid".Equals(e.Tool.Key) || "ButtonTool_RowDelete".Equals(e.Tool.Key)
                || "ButtonTool_AllDelete".Equals(e.Tool.Key) // ADD 2010/07/01
                || "ButtonTool_Insert".Equals(e.Tool.Key) || "ButtonTool_Save".Equals(e.Tool.Key))) // ADD 2009/05/21 GEJUN FOR REDMINE#8049
            {
                //ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(true, true, true, Keys.Enter, _prevControl, _lastControl); //DEL 2010/07/01 -------------->>
                ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(true, true, true, Keys.None, _prevControl, _lastControl); //ADD 2010/07/01 -------------->>
                this.tArrowKeyControl1_ChangeFocus(sender, changeFocusEventArgs);
            }// ADD 2009/05/21 GEJUN FOR REDMINE#8049

            // add start 2009/06/24 by gejun for RedMine #10103
            if ("ButtonTool_Save".Equals(e.Tool.Key))
            {
                if (this.uGrid_Details.ActiveCell != null)
                {
                    UltraGridCell cell = this.uGrid_Details.ActiveCell;
                    CellEventArgs cellEventArgs = new CellEventArgs(cell);
                    existCheckFlg = true;
                    uGrid_Details_AfterCellUpdate(this, cellEventArgs);
                }
            }
            // add end 2009/06/24 by gejun for RedMine #10103
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

                        //this.Save(); // DEL 2010/07/01------------>>>
                        this.Save(true); // ADD 2010/07/01------------>>>
						break;
					}
				#endregion

				#region 検索処理
				//--------------------------------------------------
				// 検索処理
				//--------------------------------------------------
				case "ButtonTool_Search":
					{
						this.Search();
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

				#region 行削除処理
				//--------------------------------------------------
				// 行削除処理
				//--------------------------------------------------
				case "ButtonTool_RowDelete":
					{
						this.DeleteDetailRow();
						break;
					}
				#endregion
                // ADD 2010/07/01------------>>>
                #region 全削除処理
                //--------------------------------------------------
                // 全削除処理
                //--------------------------------------------------
                case "ButtonTool_AllDelete":
                    {
                        this.DeleteAllDetailRow();
                        break;
                    }
                #endregion
                // ADD 2010/07/01------------>>>
				#region ガイド
				//--------------------------------------------------
				// ガイド
				//--------------------------------------------------
				case "ButtonTool_Guid":
					{
						// ガイド起動処理
						this.ExecuteGuide();
						break;
					}
				#endregion

				#region 引用登録処理
				//--------------------------------------------------
				// 引用登録処理
				//--------------------------------------------------
				case "ButtonTool_Insert":
					{
						this.QuoteWrite();
						break;
					}
				#endregion


				#region 最新情報処理
				//--------------------------------------------------
				// 最新情報処理
				//--------------------------------------------------
				case "ButtonTool_LoadData":
					{
						this.Renewal();
						break;
					}
				#endregion
			}
		}

		#region ●ガイドボタンクリックイベント
		/// <summary>
		/// メーカーガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_CmpltGoodsMakerGuide_Click(object sender, EventArgs e)
		{
			MakerAcs makerAcs = new MakerAcs();
			MakerUMnt makerUMnt;

			//メーカーデータの取得
			int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //メーカー
                this.tNedit_CmpltGoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                this.tEdit_CmpltMakerName.Text = makerUMnt.MakerName;
				// 次の項目へフォーカス移動
			}
		}

		/// <summary>
		/// BLコードガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_BlCodeGuide_Click(object sender, EventArgs e)
		{
			BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
			BLGoodsCdUMnt bLGoodsCdUMnt;
			//BLコードデータの取得
			int status = bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //BLコード
                this.tNedit_BlCd.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                //>>>2010/07/02
                //this.tEdit_BlName.Text = bLGoodsCdUMnt.BLGoodsFullName;
                this.tEdit_BlName.Text = bLGoodsCdUMnt.BLGoodsHalfName;
                //<<<<2010/07/02
                // 次の項目へフォーカス移動
			}
		}

		/// <summary>
		/// tNedit_CmpltGoodsMakerCd_AfterExitEditModeイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_CmpltGoodsMakerCd_AfterExitEditMode(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.tNedit_CmpltGoodsMakerCd.Text))
			{
				MakerAcs makerAcs = new MakerAcs();
				MakerUMnt makerUMnt;
				int makerCode = this.tNedit_CmpltGoodsMakerCd.GetInt();
				//メーカーデータの取得
				int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, makerCode);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					//メーカー
					this.tNedit_CmpltGoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
					this.tEdit_CmpltMakerName.Text = makerUMnt.MakerName;
				}
				else
				{
                    DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "該当データがありません。",
                                0,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);
                    this.tEdit_CmpltMakerName.Clear();
                    this.tNedit_CmpltGoodsMakerCd.Clear();
					this.tNedit_CmpltGoodsMakerCd.Focus();
                    // ガイド
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = true;
				}
			}
			else
			{
				this.tEdit_CmpltMakerName.Clear();
			}

		}

		/// <summary>
		/// tNedit_BlCd_AfterExitEditModeイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_BlCd_AfterExitEditMode(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.tNedit_BlCd.Text))
			{
				BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
				BLGoodsCdUMnt bLGoodsCdUMnt;
				int blcd = this.tNedit_BlCd.GetInt();
				//BLコードデータの取得
				int status = bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, blcd);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					//BLコード
					this.tNedit_BlCd.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                    //>>>2010/07/02
                    //this.tEdit_BlName.Text = bLGoodsCdUMnt.BLGoodsFullName;
                    this.tEdit_BlName.Text = bLGoodsCdUMnt.BLGoodsHalfName;
                    //<<<2010/07/02
                }
				else
				{
                    DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "該当データがありません。",
                                0,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);
                    this.tEdit_BlName.Clear();
                    this.tNedit_BlCd.Clear();
					this.tNedit_BlCd.Focus();
                    // ガイド
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = true;
				}
			}
			else
			{
				this.tEdit_BlName.Clear();
			}
		}

		/// <summary>
		/// グリッド初期レイアウト設定イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			// グリッド列初期設定処理
			this.InitialSettingGridCol();
		}
		#endregion

		# endregion

		// ===================================================================================== //
		// プライベート・インターナルメソッド
		// ===================================================================================== //
		# region Private Methods and Internal Methods

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
			// 車種名称マスタ
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

			// メーカーマスタ
			int status1 = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			MakerUMnt makerUMnt = new MakerUMnt();
			if (this.tNedit_CmpltGoodsMakerCd.GetInt() != 0)
			{
				status1 = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_CmpltGoodsMakerCd.GetInt());
			}
			if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.tEdit_CmpltMakerName.Text = makerUMnt.MakerName;
			}

			// BLコードマスタ
			int status2 = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
			if (this.tNedit_BlCd.GetInt() != 0)
			{
				status2 = this._bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, this.tNedit_BlCd.GetInt());
			}
			if (status2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //>>>2010/07/02
                //this.tEdit_BlName.Text = bLGoodsCdUMnt.BLGoodsFullName;
                this.tEdit_BlName.Text = bLGoodsCdUMnt.BLGoodsHalfName;
                //<<<2010/07/02
            }

			string msg = "最新情報を取得しました。";
			// メッセージを表示
			DialogResult dialogResult = TMsgDisp.Show(
				this,
				emErrorLevel.ERR_LEVEL_INFO,
				this.Name,
				msg,
				0,
				MessageBoxButtons.OK,
				MessageBoxDefaultButton.Button1);
			if (dialogResult == DialogResult.Yes)
			{
				return;
			}
		}
		# endregion

		# region ▼画面情報取得

		/// <summary>
		/// 画面検索条件情報自由検索部品クラス格納処理
		/// </summary>
		/// <returns>自由検索部品クラス（検索条件）</returns>
		/// <remarks>
		/// <br>Note       : 画面検索条件情報から自由検索部品オブジェクトにデータを格納します。</br>
		/// <br>Programmer	: 肖緒徳</br>	
		/// <br>Date		: 2010/04/26</br>
		/// </remarks>
		private FreeSearchParts DispCondToFreeSearchParts()
		{
			FreeSearchParts freeSearchParts = new FreeSearchParts();
			freeSearchParts.EnterpriseCode = _enterpriseCode;
			//車種コード
			freeSearchParts.ModelCode = this.tNedit_ModelCode.GetInt();
			//車種サブコード
			freeSearchParts.ModelSubCode = this.tNedit_ModelSubCode.GetInt();
			//メーカーコード
			freeSearchParts.MakerCode = this.tNedit_MakerCode.GetInt();
            //型式配列（フル型）
            List<string> fullModelList = new List<string>();
            string fullModel;
            StringBuilder fullModelSb = new StringBuilder();
            foreach (DataRow carModelInfoRow in this._selectCarModelInfoDataTable.Rows)
            {
                fullModel = carModelInfoRow["FullModel"].ToString();
                if (!string.IsNullOrEmpty(fullModel))
                {
                    if (!fullModelList.Contains(fullModel))
                    {
                        fullModelList.Add(fullModel);
                    }
                }
            }
            for(int i = 0; i < fullModelList.Count; i++)
            {
                if (i != 0)
                {
                    fullModelSb.Append('\t');
                }
                fullModelSb.Append(fullModelList[i]);
            }
            freeSearchParts.FullModel = fullModelSb.ToString();
			// 商品メーカーコード
			freeSearchParts.GoodsMakerCd = this.tNedit_CmpltGoodsMakerCd.GetInt();
			//BLコード
			freeSearchParts.TbsPartsCode = this.tNedit_BlCd.GetInt();
			//商品番号
			freeSearchParts.GoodsNo = this.tEdit_GoodsNo.Text.ToString();
			//品番条件
			freeSearchParts.GoodsNoFuzzy = Convert.ToInt32(this.tComboEditor_GoodsNoFuzzy.SelectedIndex);

			return freeSearchParts;
		}
		#endregion

		/// <summary>
		/// 保存データチェック処理
		/// </summary>
		/// <returns></returns>
		private bool CheckSaveData()
		{
			bool flg = true;
            bool checkFlg = false;
            bool checkFlgTemp = false;
            int lastRowIndex = 0;

			#region 画面入力値チェック

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
                this.tNedit_CategoryNo.Focus();
                return false;
            }
            // add start 2009/06/24 by gejun for RedMine #10103
            for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
            {
                UltraGridRow row = this.uGrid_Details.Rows[i];
                for(int j = 1; j < row.Cells.Count; j++)
                {
                    if (PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE.Equals(row.Cells[j].Column.Key) ||
                       PMJKN09011UC.COL_FULLMODELGROUP_TITLE.Equals(row.Cells[j].Column.Key))
                        continue;

                    if (PMJKN09011UC.COL_CREATEYEAR_TITLE.Equals(row.Cells[j].Column.Key))
                    {
                        if (!"____.__ - ____.__".Equals(row.Cells[j].Text.Trim()))
                        {
                            checkFlgTemp = true;
                            break;
                        }
                    }
                    else if (PMJKN09011UC.COL_CREATECARNO_TITLE.Equals(row.Cells[j].Column.Key))
                    {
                        if (!"________ - ________".Equals(row.Cells[j].Text.Trim()))
                        {
                            checkFlgTemp = true;
                            break;
                        }
                    }
                    else if (!"".Equals(row.Cells[j].Text.Trim()))
                    {
                        checkFlgTemp = true;
                        break;
                    }
                }
                // 該当レコードが入力した
                if (checkFlgTemp)
                {
                    checkFlg = true;
                    lastRowIndex = -1;
                    checkFlgTemp = false;
                }
                // 該当レコード空白
                else
                {
                    if(lastRowIndex < 0)
                        lastRowIndex = i; 
                }

            }

            if (!checkFlg)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                  this,
                  emErrorLevel.ERR_LEVEL_EXCLAMATION,
                  this.Name,
                  "明細が入力されていません。",
                  0,
                  MessageBoxButtons.OK,
                  MessageBoxDefaultButton.Button1);

                // 指定フォーカス設定処理
                this.uGrid_Details.Rows[0].Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Activate();
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return false;
            }
            // add end 2009/06/24 by gejun for RedMine #10103


			for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
			{
                if (lastRowIndex >= 0 && i >= lastRowIndex )
                    continue;
                // del start 2010/06/24 by gejun for RedMine #10103
                //checkFlg = false;
                //if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Text) ||
                //           !string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Text) ||
                //           !string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_PARTSQTY_TITLE].Text) ||
                //           !string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Text))
                // del end 2010/06/24 by gejun for RedMine #10103

                // 自由検索部品固有番号
                string freeSearchParts = this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].Text;

                if (_freeSearchPartsDty.Keys.Count == 0 || this._freeSearchPartsDty.ContainsKey(freeSearchParts))
                {
                    //品番
                    if (string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Text))
                    {
                        // del start 2010/06/24 by gejun for RedMine #10103
                        //if ((this._newLineRowIndexDic.ContainsKey(freeSearchParts) && checkFlg) || !this._newLineRowIndexDic.ContainsKey(freeSearchParts))
                        //{
                        // del end 2010/06/24 by gejun for RedMine #10103
                       
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "品番を入力して下さい。",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);

                            // 指定フォーカス設定処理
                            this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Activate();
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            return false;
                     //} del 2010/06/24 by gejun for RedMine #10103
                    }
                    //メーカー
                    if (string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Text)
                        || (this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Text != null
                        && Convert.ToInt32(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Text) == 0))
                    {
                        // del start 2010/06/24 by gejun for RedMine #10103
                        //if ((this._newLineRowIndexDic.ContainsKey(freeSearchParts) && checkFlg) || !this._newLineRowIndexDic.ContainsKey(freeSearchParts))
                        //{
                        // del end 2010/06/24 by gejun for RedMine #10103
                        DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "メーカーを入力して下さい。",
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);

                        // 指定フォーカス設定処理
                        this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Activate();
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        return false;
                        //} del 2010/06/24 by gejun for RedMine #10103
                    }
                    // add start 2010/06/24 by gejun for RedMine #10103
                    else
                    {
                        MakerAcs makerAcs = new MakerAcs();
                        MakerUMnt makerUMnt;
                        int makeCd = TStrConv.StrToIntDef(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Text, 0);
                        int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, makeCd);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                         
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "メーカーコード [" + makeCd.ToString() + "] に該当するデータが存在しません。",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                            // 指定フォーカス設定処理
                            this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Activate();
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                            SetCellBeforeValue(PMJKN09011UC.COL_MAKER_TITLE, i, this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_MAKER_TITLE].Column.Index); // add  2010/06/29 by gejun for RedMine #10103

                            return false;
                        }
                    }
                    // add end 2010/06/24 by gejun for RedMine #10103
                    //BLコード
                    if (string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Text)
                        || (this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Text != null
                        && Convert.ToInt32(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Text) == 0))
                    {
                        // del start 2010/06/24 by gejun for RedMine #10103
                        //if ((this._newLineRowIndexDic.ContainsKey(freeSearchParts) && checkFlg) || !this._newLineRowIndexDic.ContainsKey(freeSearchParts))
                        //{
                        // del end 2010/06/24 by gejun for RedMine #10103
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "BLコードを入力して下さい。",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);

                            // 指定フォーカス設定処理
                            this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Activate();
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            return false;
                        //} del 2010/06/24 by gejun for RedMine #10103
                    }
                    // add start 2010/06/24 by gejun for RedMine #10103
                    else
                    {
                        BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
                        BLGoodsCdUMnt bLGoodsCdUMnt;
                        int blCode = TStrConv.StrToIntDef(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Text, 0);
                        int status = bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, blCode);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "BLコード [" + blCode.ToString() + "] に該当するデータが存在しません。",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);

                            // 指定フォーカス設定処理
                            this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Activate();
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                            SetCellBeforeValue(PMJKN09011UC.COL_BLCODE_TITLE, i, this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_BLCODE_TITLE].Column.Index);// add  2010/06/29 by gejun for RedMine #10103
                            return false;
                        }
                    }
                    //QTY
                    if (string.IsNullOrEmpty(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_PARTSQTY_TITLE].Text)
                        || (this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_PARTSQTY_TITLE].Text != null
                        && Convert.ToInt32(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_PARTSQTY_TITLE].Text) == 0))
                    {
                        // del start 2010/06/24 by gejun for RedMine #10103
                        //if ((this._newLineRowIndexDic.ContainsKey(freeSearchParts) && checkFlg) || !this._newLineRowIndexDic.ContainsKey(freeSearchParts))
                        //{
                        // del end 2010/06/24 by gejun for RedMine #10103
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "QTYを入力して下さい。",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);

                            // 指定フォーカス設定処理
                            this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_PARTSQTY_TITLE].Activate();
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            return false;
                        //} del 2010/06/24 by gejun for RedMine #10103
                    }


                    //生産年式（開始日付－終了日付）
                    if (!CheckYearDiv(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_CREATEYEAR_TITLE].Text))
                    {
                        //ADD START 2009/05/21 GEJUN FOR REDMINE#8049
                        this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_CREATEYEAR_TITLE].Activate();
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        //ADD END 2009/05/21 GEJUN FOR REDMINE#8049
                        return false;
                    }
                    //車台番号
                    if (!CheckCarNo(this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_CREATECARNO_TITLE].Text))
                    {
                        //ADD START 2009/05/21 GEJUN FOR REDMINE#8049t
                        this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_CREATECARNO_TITLE].Activate();
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        //ADD END 2009/05/21 GEJUN FOR REDMINE#8049
                        return false;
                    }
                }
			}
			#endregion

			return flg;
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		private bool Save(bool checkFlg)
		{
			#region 保存チェック
			//---------------------------------------------------------------
			// 保存データチェック処理
			//---------------------------------------------------------------

            //bool check = this.CheckSaveData();  // DEL 2010/07/01------------>>>

            // ADD 2010/07/01------------>>>
            bool check = true;
            if (checkFlg)
                check = this.CheckSaveData();
            // ADD 2010/07/01------------>>>

            existCheckFlg = false;
			if (check)
			{
                // 更新用リスト
				ArrayList freeSearchPartsList = new ArrayList();
				// 削除用リスト
				ArrayList freeSearchPartsDeleteList = new ArrayList();
				foreach (FreeSearchParts freeSearchParts in _freeSearchPartsDty.Values)
				{
                    if (string.IsNullOrEmpty(freeSearchParts.GoodsNo) || (freeSearchParts.MakerCode == 0)
                        || (freeSearchParts.ModelCode == 0) || (freeSearchParts.PartsQty == 0))
                        continue;
					
                    
                    if (freeSearchParts.DataStatus == DATASTATUSCODE_1)
					{
						freeSearchPartsList.Add(freeSearchParts);
					}
					else if (freeSearchParts.DataStatus == DATASTATUSCODE_2)
					{
						// 型式（フル型）が入力した場合
						if (!string.IsNullOrEmpty(freeSearchParts.FullModel)
							&& !string.IsNullOrEmpty(freeSearchParts.GoodsNo))     // 商品番号
							//&& freeSearchParts.TbsPartsCode != 0                 // BLコード
							//&& freeSearchParts.GoodsMakerCd != 0)                // 商品メーカーコード
							//&& freeSearchParts.PartsQty != 0)                    // 部品QTY
						{
							string fullModel = string.Empty;
                            foreach (DataRow carModelInfoRow in this._selectCarModelInfoDataTable.Rows)
							{
								if (!string.IsNullOrEmpty(carModelInfoRow["FullModel"].ToString()))
								{
									if (fullModel == string.Empty && fullModel != carModelInfoRow["FullModel"].ToString())
									{
										freeSearchParts.FullModel = carModelInfoRow["FullModel"].ToString();
										freeSearchPartsList.Add(freeSearchParts);
										fullModel = carModelInfoRow["FullModel"].ToString();
									}
									else if (fullModel != carModelInfoRow["FullModel"].ToString())
									{
										FreeSearchParts fSPCopy = freeSearchParts.Clone();
										fSPCopy.FullModel = carModelInfoRow["FullModel"].ToString();
										fSPCopy.FreSrchPrtPropNo = Guid.NewGuid().ToString().Replace("-", "");
                                        freeSearchPartsList.Add(fSPCopy);
										fullModel = carModelInfoRow["FullModel"].ToString();
									}
								}
							}
						}
					}
					else if (freeSearchParts.DataStatus == DATASTATUSCODE_3)
					{
						freeSearchPartsDeleteList.Add(freeSearchParts);
					}
				}

				int status = this._freeSearchPartsAcs.WriteAndDelete(ref freeSearchPartsList, freeSearchPartsDeleteList);

				if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					foreach (FreeSearchParts updateFSParts in freeSearchPartsList)
					{
						updateFSParts.DataStatus = DATASTATUSCODE_0;
						((FreeSearchParts)this._freeSearchPartsDty[updateFSParts.FreSrchPrtPropNo]) = updateFSParts;
					}
					foreach (FreeSearchParts deletefSParts in freeSearchPartsDeleteList)
					{
						this._freeSearchPartsDty.Remove(deletefSParts.FreSrchPrtPropNo);
					}

                    this.Clear(false);
                    //ADD START 2009/05/21 GEJUN FOR REDMINE#8049
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);

                    updateModeFlg = false; // ADD 2010/07/01----->>>>
                    //ADD END 2009/05/21 GEJUN FOR REDMINE#8049
				}

                //add start 2009/06/22 by gejun for RedMine #10103
                // 比較用類別
                this._categoryNo = "";
                // 比較用車種
                this._fullCarType = "";
                // 比較用型式
                this._designationNo = "";
                // 比較用検索番号
                this._searchNo = 0;
                //add end 2009/06/22 by gejun for RedMine #10103
			}
			#endregion

            return check;
		}

		#region  ボタン初期設定処理
		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : なし</br>
		/// <br>Programmer : 張義</br>
		/// <br>Date		: 2010/04/22</br>
		/// </remarks>
		private void ButtonInitialSetting()
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this.uButton_ModelFullGuide.ImageList = this._imageList16;
			this.uButton_ModelFullGuide.Appearance.Image = (int)Size16_Index.STAR1;

			this.uButton_CmpltGoodsMakerGuide.ImageList = this._imageList16;
			this.uButton_CmpltGoodsMakerGuide.Appearance.Image = (int)Size16_Index.STAR1;

			this.BlCdGuide.ImageList = this._imageList16;
			this.BlCdGuide.Appearance.Image = (int)Size16_Index.STAR1;
			Infragistics.Win.UltraWinToolbars.ButtonTool closeButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool saveButton;
			Infragistics.Win.UltraWinToolbars.LabelTool loginTitleLabel;
			Infragistics.Win.UltraWinToolbars.LabelTool loginSectionTitle;
			Infragistics.Win.UltraWinToolbars.ButtonTool searchButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool clearButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool rowDeleteButton;
            Infragistics.Win.UltraWinToolbars.ButtonTool allDeleteButton; // ADD 2010/07/01----->>>
			Infragistics.Win.UltraWinToolbars.ButtonTool guidButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool insertButton;
			Infragistics.Win.UltraWinToolbars.ButtonTool newDatatButton;
			closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
			loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
			loginSectionTitle = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginSectionTitle"];

			searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
			clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
			rowDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"];
            allDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"];// ADD 2010/07/01------>>>
            guidButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"];
			insertButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"];
			newDatatButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"];

			closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			loginSectionTitle.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;

			searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
			clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
			rowDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            allDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;  // ADD 2010/07/01----->>>
			guidButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
			insertButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			newDatatButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
		}
		# endregion


		/// <summary>
		/// 明細グリッド表示設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : グリッドの表示設定を行います。</br>
		/// <br>Programmer	: 肖緒徳</br>	
		/// <br>Date		: 2010/04/26</br>
		/// </remarks>
		private void SettingDetailsGridCol()
		{
			// --- 型式一覧バンド --- //
			ColumnsCollection pareColumns = this.uGrid_Details.DisplayLayout.Bands[PMJKN09011UC.TBL_DETAILVIEW].Columns;

			// グレード
			pareColumns[PMJKN09011UC.COL_MODELGRADENM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_MODELGRADENM_TITLE].ValueList = this._modelGradeValueList;
			pareColumns[PMJKN09011UC.COL_MODELGRADENM_TITLE].MaxLength = 20;
			pareColumns[PMJKN09011UC.COL_MODELGRADENM_TITLE].Width = 130;

			// ボディ
			pareColumns[PMJKN09011UC.COL_BODYNAME_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_BODYNAME_TITLE].ValueList = this._bodyNameValueList;
			pareColumns[PMJKN09011UC.COL_BODYNAME_TITLE].MaxLength = 10;
			pareColumns[PMJKN09011UC.COL_BODYNAME_TITLE].Width = 80;

			// ドア
			pareColumns[PMJKN09011UC.COL_DOORCOUNT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_DOORCOUNT_TITLE].ValueList = this._doorCountValueList;
			pareColumns[PMJKN09011UC.COL_DOORCOUNT_TITLE].MaxLength = 2;
			pareColumns[PMJKN09011UC.COL_DOORCOUNT_TITLE].Width = 60;

			// エンジン
			pareColumns[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].ValueList = this._engineModelValueList;
			pareColumns[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].Width = 110;
			pareColumns[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].MaxLength = 12;

			// 排気量
			pareColumns[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].ValueList = this._engineDisplaceValueList;
			pareColumns[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].Width = 95;
			pareColumns[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].MaxLength = 8;

			// E区分
			pareColumns[PMJKN09011UC.COL_EDIVNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_EDIVNM_TITLE].ValueList = this._eDivValueList;
			pareColumns[PMJKN09011UC.COL_EDIVNM_TITLE].Width = 95;
			pareColumns[PMJKN09011UC.COL_EDIVNM_TITLE].MaxLength = 8;

			// ミッション
			pareColumns[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].ValueList = this._transmissionValueList;
			pareColumns[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].Width = 95;
			pareColumns[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].MaxLength = 8;

			// 駆動形式
			pareColumns[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].ValueList = this._wheelDriveMethodValueList;
			pareColumns[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].Width = 120;
			pareColumns[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].MaxLength = 15;

			// シフト
			pareColumns[PMJKN09011UC.COL_SHIFTNM_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
			pareColumns[PMJKN09011UC.COL_SHIFTNM_TITLE].ValueList = this._shiftValueList;
			pareColumns[PMJKN09011UC.COL_SHIFTNM_TITLE].Width = 95;
			pareColumns[PMJKN09011UC.COL_SHIFTNM_TITLE].MaxLength = 8;
		}

		/// <summary>
		/// 明細グリッドのDropDownValue追加処理
		/// </summary>
		private void AddDetailsGridValueList()
		{
			bool addFlg = true;
			foreach (DataRow dr in this._detailDataTable.Rows)
			{
				// グレード
				string modelGrade = dr[PMJKN09011UC.COL_MODELGRADENM_TITLE].ToString();
				foreach (ValueListItem vItem in this._modelGradeValueList.ValueListItems)
				{
					if (vItem.DisplayText == modelGrade)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// グレードリスト
					if (!string.IsNullOrEmpty(modelGrade))
					{
						this._modelGradeValueList.ValueListItems.Add(modelGrade, modelGrade);
					}
				}
				addFlg = true;

				// ボディ
				string bodyName = dr[PMJKN09011UC.COL_BODYNAME_TITLE].ToString();
				foreach (ValueListItem vItem in this._bodyNameValueList.ValueListItems)
				{
					if (vItem.DisplayText == bodyName)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// ボディリスト
					if (!string.IsNullOrEmpty(bodyName))
					{
						this._bodyNameValueList.ValueListItems.Add(bodyName, bodyName);
					}
				}
				addFlg = true;

				// ドア
				string doorCount = dr[PMJKN09011UC.COL_DOORCOUNT_TITLE].ToString();
				foreach (ValueListItem vItem in this._doorCountValueList.ValueListItems)
				{
					if (vItem.DisplayText == doorCount)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// ドアリスト
					if (!string.IsNullOrEmpty(doorCount))
					{
						this._doorCountValueList.ValueListItems.Add(doorCount, doorCount);
					}
				}
				addFlg = true;

				// エンジン
				string engineModel = dr[PMJKN09011UC.COL_ENGINEMODELNM_TITLE].ToString();
				foreach (ValueListItem vItem in this._engineModelValueList.ValueListItems)
				{
					if (vItem.DisplayText == engineModel)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// エンジンリスト
					if (!string.IsNullOrEmpty(engineModel))
					{
						this._engineModelValueList.ValueListItems.Add(engineModel, engineModel);
					}
				}
				addFlg = true;

				// 排気量
				string engineDisplace = dr[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE].ToString();
				foreach (ValueListItem vItem in this._engineDisplaceValueList.ValueListItems)
				{
					if (vItem.DisplayText == engineDisplace)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// 排気量リスト
					if (!string.IsNullOrEmpty(engineDisplace))
					{
						this._engineDisplaceValueList.ValueListItems.Add(engineDisplace, engineDisplace);
					}
				}
				addFlg = true;


				// E区分
				string eDiv = dr[PMJKN09011UC.COL_EDIVNM_TITLE].ToString();
				foreach (ValueListItem vItem in this._eDivValueList.ValueListItems)
				{
					if (vItem.DisplayText == eDiv)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// E区分リスト
					if (!string.IsNullOrEmpty(eDiv))
					{
						this._eDivValueList.ValueListItems.Add(eDiv, eDiv);
					}
				}
				addFlg = true;

				// ミッション
				string transmission = dr[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE].ToString();
				foreach (ValueListItem vItem in this._transmissionValueList.ValueListItems)
				{
					if (vItem.DisplayText == transmission)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// ミッションリスト
					if (!string.IsNullOrEmpty(transmission))
					{
						this._transmissionValueList.ValueListItems.Add(transmission, transmission);
					}
				}
				addFlg = true;

				// 駆動形式
				string wheelDriveMethod = dr[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE].ToString();
				foreach (ValueListItem vItem in this._wheelDriveMethodValueList.ValueListItems)
				{
					if (vItem.DisplayText == wheelDriveMethod)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// 駆動形式リスト
					if (!string.IsNullOrEmpty(wheelDriveMethod))
					{
						this._wheelDriveMethodValueList.ValueListItems.Add(wheelDriveMethod, wheelDriveMethod);
					}
				}
				addFlg = true;

				// シフト
				string shift = dr[PMJKN09011UC.COL_SHIFTNM_TITLE].ToString();
				foreach (ValueListItem vItem in this._shiftValueList.ValueListItems)
				{
					if (vItem.DisplayText == shift)
					{
						addFlg = false;
					}
				}
				if (addFlg)
				{
					// シフトリスト
					if (!string.IsNullOrEmpty(shift))
					{
						this._shiftValueList.ValueListItems.Add(shift, shift);
					}
				}
				addFlg = true;
			}
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
		/// 次入力可能セル移動処理
		/// </summary>
		/// <param name="currentCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
		/// <returns>true:セル移動完了 false:セル移動失敗</returns>
		private bool MoveNextAllowEditCell(bool activeCellCheck)
		{

			this.uGrid_Details.BeginUpdate();
			this.uGrid_Details.SuspendLayout();
			bool moved = false;
			bool performActionResult = false;

			// ActiveCellが入力可能の場合、Next処理しない
			if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
			{
				if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
					(this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
					(this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
				{
					moved = true;
				}
			}

			while (!moved)
			{
				// ActiveCellあり
				if (this.uGrid_Details.ActiveCell != null)
				{
					performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

					if (performActionResult)
					{
						if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
							(this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
						{
							moved = true;
						}
						else
						{
							moved = false;
						}
					}
					else
					{
						break;
					}
				}

				if (moved)
				{
					this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
				}
			}
			this.uGrid_Details.ResumeLayout();
			this.uGrid_Details.EndUpdate();
			return performActionResult;

		}

		/// <summary>
		/// 数値入力チェック処理
		/// </summary>
		/// <param name="keta">桁数(マイナス符号を含まず)</param>
		/// <param name="priod">小数点以下桁数</param>
		/// <param name="prevVal">現在の文字列</param>
		/// <param name="key">入力されたキー値</param>
		/// <param name="selstart">カーソル位置</param>
		/// <param name="sellength">選択文字長</param>
		/// <param name="minusFlg">マイナス入力可？</param>
		/// <returns>true=入力可,false=入力不可</returns>
		private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
		{
			// 制御キーが押された？
			if (Char.IsControl(key))
			{
				return true;
			}
			// 数値以外は、ＮＧ
			if (!Char.IsDigit(key))
			{
				// 小数点または、マイナス以外
				if ((key != '.') && (key != '-'))
				{
					return false;
				}
			}

            if (key > '9' || key < '0')
            {
                return false;
            }

			// キーが押されたと仮定した場合の文字列を生成する。
			string _strResult = string.Empty;
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			// マイナスのチェック
			if (key == '-')
			{
				if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
				{
					return false;
				}
			}

			// 小数点のチェック
			if (key == '.')
			{
				if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
				{
					return false;
				}
			}
			// キーが押された結果の文字列を生成する。
			_strResult = prevVal.Substring(0, selstart)
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

			// 桁数チェック！
			if (_strResult.Length > keta)
			{
				if (_strResult[0] == '-')
				{
					if (_strResult.Length > (keta + 1))
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}

			// 小数点以下のチェック
			if (priod > 0)
			{
				// 小数点の位置決定
				int _pointPos = _strResult.IndexOf('.');

				// 整数部に入力可能な桁数を決定！
				//int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
				int _Rketa = SalesSlipInputAcs.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
				// 整数部の桁数をチェック
				if (_pointPos != -1)
				{
					if (_pointPos > _Rketa)
					{
						return false;
					}
				}
				else
				{
					if (_strResult.Length > _Rketa)
					{
						return false;
					}
				}

				// 小数部の桁数をチェック
				if (_pointPos != -1)
				{
					// 小数部の桁数を計算
					int _priketa = _strResult.Length - _pointPos - 1;
					if (priod < _priketa)
					{
						return false;
					}
				}
			}
			return true;
		}

        /// <summary>
        /// 商品、入荷・発注残検索処理（オーバーロード）
        /// </summary>
        /// <param name="goodsNo">商品コード</param>
        /// <param name="searchResult">検索結果</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 商品検索後、残数自動表示区分に従って発注残照会、入荷残照会を起動します。</br>
        /// <br>             検索結果については、ヒットした処理（商品or入荷残or発注残）によってクラスが異なります。</br>
        /// </remarks>
        private int SearchGoodsAndRemain(string goodsNo, out object searchResult)
        {
            return this.SearchGoodsAndRemain(goodsNo, string.Empty, 0, out searchResult);
        }

        /// <summary>
        /// 商品、入荷・発注残検索処理（オーバーロード）
        /// </summary>
        /// <param name="goodsNo">商品コード</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="searchResult">検索結果</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 商品検索後、残数自動表示区分に従って発注残照会、入荷残照会を起動します。</br>
        /// <br>             検索結果については、ヒットした処理（商品or入荷残or発注残）によってクラスが異なります。</br>
        /// </remarks>
        private int SearchGoodsAndRemain(string goodsNo, string goodsName, int makerCode, out object searchResult)
        {
            searchResult = null;

            List<GoodsUnitData> goodsUnitDataList;
            int searchStatus;
            int retStasus = -1;

            // 商品検索
            if (makerCode == 0)
            {
                searchStatus = this.SearchGoods(goodsNo, out goodsUnitDataList);
            }
            else
            {
                searchStatus = this.SearchGoods(goodsNo, goodsName, makerCode, out goodsUnitDataList);
            }

            // 商品検索でヒットした場合
            if ((searchStatus == 0) && (goodsUnitDataList.Count > 0))
            {
                retStasus = 0;
                searchResult = goodsUnitDataList;
            }
            // 商品検索でヒットしなかった場合（空商品を返す）
            else if ((searchStatus == -2) && (goodsUnitDataList.Count > 0))
            {
                retStasus = 0;
                searchResult = goodsUnitDataList;
            }
            // ADD 2010/07/01 ------>>
            else
            {
                retStasus = searchStatus;
            }
            // ADD 2010/07/01 ------>>
            return retStasus;
        }

        /// <summary>
        /// 商品検索処理（オーバーロード）
        /// </summary>
        /// <param name="goodsNo">商品コード</param>
        /// <param name="goodsUnitDataList">商品情報リスト</param>
        /// <param name="stockList">在庫情報リスト</param>
        /// <returns>0:検索OK、-1:キャンセル,-2:検索データ無し</returns>
        private int SearchGoods(string goodsNo, out List<GoodsUnitData> goodsUnitDataList)
        {
            return this.SearchGoods(goodsNo, string.Empty, 0, out goodsUnitDataList);
        }

        /// <summary>
        /// 商品検索処理（商品コード＋メーカー）（オーバーロード）
        /// </summary>
        /// <param name="goodsNo">商品コード</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsUnitDataList">商品情報リスト</param>
        /// <returns>0:検索OK、-1:キャンセル,-2:検索データ無し</returns>
        private int SearchGoods(string goodsNo, string goodsName, int goodsMakerCd, out List<GoodsUnitData> goodsUnitDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            goodsUnitDataList = new List<GoodsUnitData>();

            GoodsUnitData goodsUnitData = new GoodsUnitData();
            string message;

            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterpriseCode;                   // 企業コード
            goodsCndtn.SectionCode = this._loginSectionCode;                    // 拠点コード
            goodsCndtn.GoodsNo = goodsNo;                                       // 商品コード
            goodsCndtn.GoodsMakerCd = goodsMakerCd;                             // 商品メーカーコード
            goodsCndtn.PriceApplyDate = DateTime.Now;                           // ADD 2009/05/22 GEJUN FOR REDMINE#8049
            status = this._freeSearchPartsAcs.GetGoodsUnitData(goodsCndtn, out goodsUnitData, out message);

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        goodsUnitDataList.Add(goodsUnitData);
                        return 0;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                    {
                        return -1;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        return -2;
                    }
            }
            return 0;
        }

		/// <summary>
		/// ActiveRowインデックス取得処理
		/// </summary>
		/// <returns>ActiveRowインデックス</returns>
		private int GetActiveRowIndex()
		{
			if (this.uGrid_Details.ActiveCell != null)
			{
				return this.uGrid_Details.ActiveCell.Row.Index;
			}
			else if (this.uGrid_Details.ActiveRow != null)
			{
				return this.uGrid_Details.ActiveRow.Index;
			}
			else
			{
				return -1;
			}
		}
        // add start 2010/06/24 by gejun for RedMine #10103
		/// <summary>
		/// 選択した行インデックスリスト取得処理
		/// </summary>
        /// <returns>選択した行インデックス</returns>
        private List<int> GetSelectRowIndex()
        {
            List<int> SelRowInxList = new List<int>();
            for (int i = this.uGrid_Details.Rows.Count - 1; i > -1; i--)
            {
                if(this.uGrid_Details.Rows[i].Selected)
                    SelRowInxList.Add(i);
            }
            if ( SelRowInxList.Count == 0 && this.uGrid_Details.ActiveCell != null)
                SelRowInxList.Add(this.uGrid_Details.ActiveCell.Row.Index);

            return SelRowInxList;
        }
        // add end 2010/06/24 by gejun for RedMine #10103
		/// DetailDataTableインデックス取得処理
		/// </summary>
		/// <returns>DetailDataTableインデックス</returns>
		private int GetDetailDataTableRowIndex(string colTitle, string colValue)
		{
			int dataTableIndex = -1;
			for (int i = 0; i < this._detailDataTable.Rows.Count; i++)
			{
				if (colValue == this._detailDataTable.Rows[i][colTitle].ToString())
				{
					dataTableIndex = i;
					break;
				}
			}
			return dataTableIndex;
		}

		/// <summary>
		/// BLコード検索
		/// </summary>
		/// <param name="salesRowNo">売上行番号</param>
		/// <param name="bLGoodsCode">BLコード</param>
		/// <param name="searchResult">検索結果</param>
		/// <returns></returns>
		private int SearchPartsFromBLCode(int salesRowNo, int bLGoodsCode, out object searchResult)
		{
			//-----------------------------------------------------------------------------
			// 初期処理
			//-----------------------------------------------------------------------------
			searchResult = null;
			List<GoodsUnitData> goodsUnitDataList;
			List<Stock> stockList;
			int searchStatus;
			int retStasus = -1;

			//-----------------------------------------------------------------------------
			// BLコード検索
			//-----------------------------------------------------------------------------
			searchStatus = this.SearchPartsFromBLCodeProc(salesRowNo, bLGoodsCode, out goodsUnitDataList, out stockList);

			//-----------------------------------------------------------------------------
			// BLコード検索でヒットした場合
			//-----------------------------------------------------------------------------
			if ((searchStatus == 0) && (goodsUnitDataList.Count > 0))
			{
				ArrayList retList = new ArrayList();
				foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
				{
					retList.Add(goodsUnitData);
				}
				searchResult = retList;
			}
			//-----------------------------------------------------------------------------
			// BLコード検索でヒットしなかった場合（空商品を返す）
			//-----------------------------------------------------------------------------
			else if ((searchStatus == -2) && (goodsUnitDataList.Count <= 0))
			{
				retStasus = -2;

				ArrayList retList = new ArrayList();
				searchResult = retList;
			}
			//-----------------------------------------------------------------------------
			// 車両情報無し
			//-----------------------------------------------------------------------------
			else if (searchStatus == -3)
			{
				retStasus = -3;
				ArrayList retList = new ArrayList();
				searchResult = retList;
			}

			return retStasus;
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
				this.StartSearchGoodsNo.Text = "1";

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

                _endSearchGoodsNo = 0;
                this._selectCarModelInfoDataTable.Rows.Clear();
                _singleIndex = 0;
                this._modelGradeValueList.ValueListItems.Add("", "");
                this._bodyNameValueList.ValueListItems.Add("", "");
                this._doorCountValueList.ValueListItems.Add("", "");
                this._engineModelValueList.ValueListItems.Add("", "");
                this._engineDisplaceValueList.ValueListItems.Add("", "");
                this._eDivValueList.ValueListItems.Add("", "");
                this._transmissionValueList.ValueListItems.Add("", "");
                this._wheelDriveMethodValueList.ValueListItems.Add("", "");
                this._shiftValueList.ValueListItems.Add("", "");

                // --- UPD m.suzuki 2010/06/01 ---------->>>>>
                //for (int i = 0; i < _carModelInfoDataTable.Rows.Count; i++)
                for ( int i = 0; i < _carModelInfoDataTable.DefaultView.Count; i++ )
                // --- UPD m.suzuki 2010/06/01 ----------<<<<<
				{
                    // --- UPD m.suzuki 2010/06/01 ---------->>>>>
                    //PMKEN01010E.CarModelInfoRow carModelInfoRow = (PMKEN01010E.CarModelInfoRow)_carModelInfoDataTable.Rows[i];
                    PMKEN01010E.CarModelInfoRow carModelInfoRow = (PMKEN01010E.CarModelInfoRow)_carModelInfoDataTable.DefaultView[i].Row;
                    // --- UPD m.suzuki 2010/06/01 ----------<<<<<

					if ((bool)carModelInfoRow["SelectionState"] == true)
					{
                        this._selectCarModelInfoDataTable.ImportRow(carModelInfoRow);
 						//グレード
						if (!modelGradeNmList.Contains((string)carModelInfoRow["ModelGradeNm"]))
						{
                            this._modelGradeValueList.ValueListItems.Add((string)carModelInfoRow["ModelGradeNm"], (string)carModelInfoRow["ModelGradeNm"]);
							modelGradeNmList.Add((string)carModelInfoRow["ModelGradeNm"]);
						}
						//ボディ
						if (!bodyNameList.Contains((string)carModelInfoRow["BodyName"]))
						{
                            this._bodyNameValueList.ValueListItems.Add((string)carModelInfoRow["BodyName"], (string)carModelInfoRow["BodyName"]);
							bodyNameList.Add((string)carModelInfoRow["BodyName"]);
						}
						//ドア
						int doorCout = (int)carModelInfoRow["DoorCount"];
						if (!doorCoutList.Contains(doorCout.ToString()))
						{
                            this._doorCountValueList.ValueListItems.Add(doorCout.ToString(), doorCout.ToString());
							doorCoutList.Add(doorCout.ToString());
						}
						//エンジン
						if (!engineModelList.Contains((string)carModelInfoRow["EngineModelNm"]))
						{
                            this._engineModelValueList.ValueListItems.Add((string)carModelInfoRow["EngineModelNm"], (string)carModelInfoRow["EngineModelNm"]);
							engineModelList.Add((string)carModelInfoRow["EngineModelNm"]);
						}
						//排気量
						if (!engineDisplaceList.Contains((string)carModelInfoRow["EngineDisplaceNm"]))
						{
                            this._engineDisplaceValueList.ValueListItems.Add((string)carModelInfoRow["EngineDisplaceNm"], (string)carModelInfoRow["EngineDisplaceNm"]);
							engineDisplaceList.Add((string)carModelInfoRow["EngineDisplaceNm"]);
						}
						//E区分
						if (!eDivList.Contains((string)carModelInfoRow["EDivNm"]))
						{
                            this._eDivValueList.ValueListItems.Add((string)carModelInfoRow["EDivNm"], (string)carModelInfoRow["EDivNm"]);
							eDivList.Add((string)carModelInfoRow["EDivNm"]);
						}
						//ミッション
						if (!transmissionList.Contains((string)carModelInfoRow["TransmissionNm"]))
						{
                            this._transmissionValueList.ValueListItems.Add((string)carModelInfoRow["TransmissionNm"], (string)carModelInfoRow["TransmissionNm"]);
							transmissionList.Add((string)carModelInfoRow["TransmissionNm"]);
						}
						//駆動形式
						if (!wheelDriveMethodList.Contains((string)carModelInfoRow["WheelDriveMethodNm"]))
						{
                            this._wheelDriveMethodValueList.ValueListItems.Add((string)carModelInfoRow["WheelDriveMethodNm"], (string)carModelInfoRow["WheelDriveMethodNm"]);
							wheelDriveMethodList.Add((string)carModelInfoRow["WheelDriveMethodNm"]);
						}
						//シフト
						if (!shiftList.Contains((string)carModelInfoRow["ShiftNm"]))
						{
                            this._shiftValueList.ValueListItems.Add((string)carModelInfoRow["ShiftNm"], (string)carModelInfoRow["ShiftNm"]);
							shiftList.Add((string)carModelInfoRow["ShiftNm"]);
						}

                        if (_endSearchGoodsNo == 0)
                        {
                            this.tNedit_MakerCode.SetInt((int)carModelInfoRow["MakerCode"]);
                            this._makerCode = (int)carModelInfoRow["MakerCode"];
                            this.tNedit_ModelCode.SetInt((int)carModelInfoRow["ModelCode"]);
                            this._modelCode = (int)carModelInfoRow["ModelCode"];
                            this.tNedit_ModelSubCode.SetInt((int)carModelInfoRow["ModelSubCode"]);
                            this._modelSubCode = (int)carModelInfoRow["ModelSubCode"];
                            this.tEdit_ModelFullName.Text = (string)carModelInfoRow["ModelFullName"];
                            //型式
                            this.tEdit_FullModel.Text = (string)carModelInfoRow["FullModel"];
                            this._fullModel = (string)carModelInfoRow["FullModel"];
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
                            PMJKN09011UB.DataSetColumnConstruction(ref this._carSpecDataSet);
                            DataRow row = this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].NewRow();
                            //諸元情報
                            //グレード
                            row[PMJKN09011UB.COL_MODELGRADENM_TITLE] = carModelInfoRow["ModelGradeNm"].ToString();
                            //ボディ
                            row[PMJKN09011UB.COL_BODYNAME_TITLE] = carModelInfoRow["BodyName"].ToString();
                            //ドア
                            if ((int)carModelInfoRow["DoorCount"] == 0)
                            {
                                // row[PMJKN09011UB.COL_DOORCOUNT_TITLE] = "0";  del by gejun for RedMine #10103
                                row[PMJKN09011UB.COL_DOORCOUNT_TITLE] = "";  // add by gejun for RedMine #10103
                            }
                            else
                            {
                                row[PMJKN09011UB.COL_DOORCOUNT_TITLE] = carModelInfoRow["DoorCount"].ToString();
                            }
                            //エンジン
                            row[PMJKN09011UB.COL_ENGINEMODELNM_TITLE] = carModelInfoRow["EngineModelNm"].ToString();
                            //排気量
                            row[PMJKN09011UB.COL_ENGINEDISPLACENM_TITLE] = carModelInfoRow["EngineDisplaceNm"].ToString();
                            //E区分
                            row[PMJKN09011UB.COL_EDIVNM_TITLE] = carModelInfoRow["EDivNm"].ToString();
                            //ミッション
                            row[PMJKN09011UB.COL_TRANSMISSIONNM_TITLE] = carModelInfoRow["TransmissionNm"].ToString();
                            //駆動形式
                            row[PMJKN09011UB.COL_WHEELDRIVEMETHODNM_TITLE] = carModelInfoRow["WheelDriveMethodNm"].ToString();
                            //シフト
                            row[PMJKN09011UB.COL_SHIFTNM_TITLE] = carModelInfoRow["ShiftNm"].ToString();                       
                            this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].Rows.Add(row);
                            this.ultraGrid_CarSpec.DataSource = this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].DefaultView;
                            this.ultraGrid_CarSpec.Rows[0].Activation = Activation.Disabled;
                        
                        }
                        _endSearchGoodsNo++;
                    }

                    _singleIndex++; 
                    
				}

                if (_endSearchGoodsNo > 1)
                {
                    _singleIndex = 0;
                }

                this.tNedit_SearchGoodsNo.SetInt(1);
                this.EndSearchGoodsNo.Text = _endSearchGoodsNo.ToString();
			}

		}


		/// <summary>
		/// BLコード検索
		/// </summary>
		/// <param name="salesRowNo">売上行番号</param>
		/// <param name="bLGoodsCode">BLコード</param>
		/// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
		/// <param name="stockList">在庫データオブジェクトリスト</param>
		/// <returns></returns>
		private int SearchPartsFromBLCodeProc(int salesRowNo, int bLGoodsCode, out List<GoodsUnitData> goodsUnitDataList, out List<Stock> stockList)
		{
			//-------------------------------------------------------------
			// 初期処理
			//-------------------------------------------------------------
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			goodsUnitDataList = new List<GoodsUnitData>();
			stockList = new List<Stock>();

			#region ●BLコード検索
			//-------------------------------------------------------------
			// BLコード検索
			//-------------------------------------------------------------
			//status = this._freeSearchPartsAcs.SearchPartsFromBLCode(salesRowNo, this._enterpriseCode, this._loginSectionCode, bLGoodsCode, out goodsUnitDataList, this._carInfo);
			#endregion

			//-------------------------------------------------------------
			// 部品検索後処理
			//-------------------------------------------------------------
			if ((status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
			{
			}
			else if (status == -3)
			{
				// 車両情報無し
				return -3;
			}
			else if (status == -1)
			{
				// キャンセル
				return -1;
			}
			else
			{
				// 該当なし
				return -2;
			}

			return 0;
		}
        // ADD 2010/07/01----->>>>>
        /// <summary>
		/// 明細グリッド全削除処理
		/// </summary>
        private void DeleteAllDetailRow()
        {
            if (this.CheckChangedData())
            {
                DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
                    "全明細削除してもよいですか？",
					0,
					MessageBoxButtons.YesNo,
					MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (FreeSearchParts freeSearchParts in _freeSearchPartsDty.Values)
                    {
                        if (string.IsNullOrEmpty(freeSearchParts.GoodsNo) || (freeSearchParts.MakerCode == 0)
                                || (freeSearchParts.ModelCode == 0) || (freeSearchParts.PartsQty == 0))
                            continue;

                        if (freeSearchParts.DataStatus == DATASTATUSCODE_1 || freeSearchParts.DataStatus == DATASTATUSCODE_0)
                        {
                            freeSearchParts.DataStatus = DATASTATUSCODE_3;
                        }
                        else if (freeSearchParts.DataStatus == DATASTATUSCODE_2)
                            _freeSearchPartsDty.Remove(freeSearchParts.FreSrchPrtPropNo);
                    }
                    // DB処理
                    this.Save(false);
                }
                else
                    return;
                
            }
        }
        // ADD 2010/07/01----->>>>>
		/// <summary>
		/// 明細グリッド削除処理
		/// </summary>
		private void DeleteDetailRow()
		{
            List<int> selRowInxList = GetSelectRowIndex(); // add 2010/06/24 by gejun for RedMine #10103
            
            //if (GetActiveRowIndex() != -1) // del start 2010/06/24 by gejun for RedMine #10103
            if (selRowInxList.Count != 0)  // add start 2010/06/24 by gejun for RedMine #10103
			{
                // modify start 2010/06/24 by gejun for RedMine #10103
                foreach(int rowIndex in selRowInxList)
                {
				    //string fullModelGroup = this.uGrid_Details.Rows[GetActiveRowIndex()].Cells[PMJKN09011UC.COL_FULLMODELGROUP_TITLE].Text;
                    string fullModelGroup = this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_FULLMODELGROUP_TITLE].Text;
                    if (string.IsNullOrEmpty(fullModelGroup))
				    {
                        //string freSrchPrtPropNo = this.uGrid_Details.Rows[GetActiveRowIndex()].Cells[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].Text;
                        string freSrchPrtPropNo = this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].Text;
                        // modify end 2010/06/24 by gejun for RedMine #10103
                        FreeSearchParts freeSearchParts = null;
					    if (this._freeSearchPartsDty.ContainsKey(freSrchPrtPropNo))
					    {
						    freeSearchParts = (FreeSearchParts)this._freeSearchPartsDty[freSrchPrtPropNo];
						    if (freeSearchParts.DataStatus == DATASTATUSCODE_0 || freeSearchParts.DataStatus == DATASTATUSCODE_1)
						    {
							    // 削除するデータ
							    freeSearchParts.DataStatus = DATASTATUSCODE_3;
						    }
						    else if (freeSearchParts.DataStatus == DATASTATUSCODE_2)
						    {
							    // DB存在しない、且つ削除するデータ
							    freeSearchParts.DataStatus = DATASTATUSCODE_4;
						    }
						    // 明細テーブルのデータを削除する。
						    this._detailDataTable.Rows.RemoveAt(GetDetailDataTableRowIndex(PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE, freSrchPrtPropNo));


                            if (goodsNoComp.ContainsKey(freSrchPrtPropNo))
                                goodsNoComp.Remove(freSrchPrtPropNo);
					    }
                        //ADD START 2009/05/24 GEJUN FOR REDMINE#8049
                        if (_newLineRowIndexDic.ContainsKey(freSrchPrtPropNo))
                            this._newLineRowIndexDic.Remove(freSrchPrtPropNo);
                        //ADD END 2009/05/24 GEJUN FOR REDMINE#8049
				    }
				    else
				    {
					    foreach (FreeSearchParts fsp in _freeSearchPartsDty.Values)
					    {
						    if (fullModelGroup == fsp.FullModelGroup)
						    {
							    if (fsp.DataStatus == DATASTATUSCODE_0 || fsp.DataStatus == DATASTATUSCODE_1)
							    {
								    // 削除するデータ
								    fsp.DataStatus = DATASTATUSCODE_3;
							    }
							    else if (fsp.DataStatus == DATASTATUSCODE_2)
							    {
								    // DB存在しない、且つ削除するデータ
								    fsp.DataStatus = DATASTATUSCODE_4;
							    }
						    }
					    }
					    // 明細テーブルのデータを削除する。
					    this._detailDataTable.Rows.RemoveAt(GetDetailDataTableRowIndex(PMJKN09011UC.COL_FULLMODELGROUP_TITLE, fullModelGroup));

                        if (goodsNoComp.ContainsKey(fullModelGroup))
                            goodsNoComp.Remove(fullModelGroup);
				    }
				    if (this._detailDataTable.Rows.Count == 0)
				    {
                        DataRow row = this._detailDataTable.NewRow();
                        row[PMJKN09011UC.COL_NO_TITLE] = 1;
                        row[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE] = Guid.NewGuid().ToString().Replace("-", "");
                        this._detailDataTable.Rows.Add(row);
				    }
				    // 明細グリッド設定処理
				    this.SettingGrid();
			    }

            }// add 2010/06/24 by gejun for RedMine #10103

		}

		/// <summary>
		/// 引用登録処理
		/// </summary>
		private void QuoteWrite()
		{
			//---------------------------------------------------------------
			// 保存データチェック処理
			//---------------------------------------------------------------
			bool check = this.CheckSaveData();
			if (!check)
			{
				return;
			}
            // カーソル行のみのデータ
			ArrayList fspOneRowRestList = new ArrayList();
            // 明細行全てのデータ
            ArrayList fspFullRowRestList = new ArrayList();
            // 自由検索部品固有番号
            string freSrchPrtPropNo = this.uGrid_Details.Rows[GetActiveRowIndex()].Cells[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].Text;
            if (!string.IsNullOrEmpty(freSrchPrtPropNo))
            {
                if (this._freeSearchPartsDty.ContainsKey(freSrchPrtPropNo))
                {
                    FreeSearchParts freeSearchParts = this._freeSearchPartsDty[freSrchPrtPropNo];
                    fspOneRowRestList.Add(freeSearchParts);
                }
            }
            for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty((string)this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Value) || this.uGrid_Details.Rows.Count == 1)
                {
                    freSrchPrtPropNo = this.uGrid_Details.Rows[i].Cells[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].Text;
                    if (!string.IsNullOrEmpty(freSrchPrtPropNo) && this._freeSearchPartsDty.ContainsKey(freSrchPrtPropNo))
                    {
                        FreeSearchParts freeSearchParts = this._freeSearchPartsDty[freSrchPrtPropNo];
                        fspFullRowRestList.Add(this._freeSearchPartsDty[freSrchPrtPropNo]);
                    }
                }
            }
			//画面明細部はデータある
            if (fspFullRowRestList.Count > 0 && fspOneRowRestList.Count > 0)
			{
                //ADD START 2009/05/22 GEJUN FOR REDMINE#8049
                // 自由検索型式マスタ更新用データの準備
                FreeSearchModel freeSearchModel = new FreeSearchModel();

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
                freeSearchModel.ModelGradeNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_MODELGRADENM_TITLE].Text.ToString();

                // ボディー名称
                freeSearchModel.BodyName = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_BODYNAME_TITLE].Text.ToString();

                // ドア数
                string doorCount = (string)this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_DOORCOUNT_TITLE].Text.ToString();
                freeSearchModel.DoorCount = String.IsNullOrEmpty(doorCount) ? 0 : Convert.ToInt32(doorCount);

                // エンジン型式名称
                freeSearchModel.EngineModelNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_ENGINEMODELNM_TITLE].Text.ToString();

                // 排気量名称
                freeSearchModel.EngineDisplaceNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_ENGINEDISPLACENM_TITLE].Text.ToString();

                // E区分名称
                freeSearchModel.EDivNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_EDIVNM_TITLE].Text.ToString();

                // ミッション名称
                freeSearchModel.TransmissionNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_TRANSMISSIONNM_TITLE].Text.ToString();

                // 駆動方式名称
                freeSearchModel.WheelDriveMethodNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_WHEELDRIVEMETHODNM_TITLE].Text.ToString();

                // シフト名称
                freeSearchModel.ShiftNm = this.ultraGrid_CarSpec.Rows[0].Cells[PMJKN09011UB.COL_SHIFTNM_TITLE].Text.ToString();
                //ADD END 2009/05/22 GEJUN FOR REDMINE#8049

                //PMJKN09011UF PMJKN09011UF = new PMJKN09011UF(fspFullRowRestList, fspOneRowRestList);//DEL 2009/05/22 GEJUN FOR REDMINE#8049
                PMJKN09011UF PMJKN09011UF = new PMJKN09011UF(fspFullRowRestList, fspOneRowRestList, freeSearchModel);//ADD 2009/05/22 GEJUN FOR REDMINE#8049
				PMJKN09011UF.ShowDialog();

			}
		}

		/// <summary>
		/// 検索処理
		/// </summary>
        //private void Search()// del 2010/06/24 by gejun for RedMine #10103
        private int Search()// add 2010/06/24 by gejun for RedMine #10103
		{
            int result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;// add 2010/06/24 by gejun for RedMine #10103

            if (this.CheckSearchParam())
            {

                this._detailDataTable.Clear();
                FreeSearchParts rowInfo = null;
                // 画面情報取得
                FreeSearchParts cond = DispCondToFreeSearchParts();
                // 検索実施
                ArrayList retList = null;
                int status = this._freeSearchPartsAcs.Search(out retList, cond);
                this._newLineRowIndexDic.Clear();                //ADD 2009/05/24 GEJUN FOR REDMINE#8049
                this._freeSearchPartsDty.Clear();
                this._detailDataTable.Rows.Clear();
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // メーカーコード
                    this._makerCode = this.tNedit_MakerCode.GetInt();
                    // 車種コード
                    this._modelCode = this.tNedit_ModelCode.GetInt();
                    // 車種サブコード
                    this._modelSubCode = this.tNedit_ModelSubCode.GetInt();
                    // 型式（フル型）
                    this._fullModel = this.tEdit_FullModel.Text;

                    if (retList != null && retList.Count > 0)
                    {

                        goodsNoComp.Clear(); //ADD 2010/07/01 ------------------>>>

                        Dictionary<string, List<FreeSearchParts>> checkGroupDty = new Dictionary<string, List<FreeSearchParts>>();
                        List<FreeSearchParts> list = null;
                        foreach (object obj in retList)
                        {
                            rowInfo = (FreeSearchParts)obj;
                            StringBuilder keySBuilder = new StringBuilder();
                            // 品番
                            keySBuilder.Append(rowInfo.GoodsNo);
                            // メーカー
                            keySBuilder.Append(rowInfo.GoodsMakerCd);
                            // BLコード
                            keySBuilder.Append(rowInfo.TbsPartsCode);
                            // QTY
                            keySBuilder.Append(rowInfo.PartsQty);
                            // 生産年式
                            keySBuilder.Append(rowInfo.ModelPrtsAdptYm);
                            keySBuilder.Append(rowInfo.ModelPrtsAblsYm);
                            // 生産車台番号
                            keySBuilder.Append(rowInfo.ModelPrtsAdptFrameNo);
                            keySBuilder.Append(rowInfo.ModelPrtsAblsFrameNo);
                            // ｸﾞﾚｰﾄﾞ
                            keySBuilder.Append(rowInfo.ModelGradeNm);
                            // ﾎﾞﾃﾞｨ
                            keySBuilder.Append(rowInfo.BodyName);
                            // ﾄﾞｱ
                            keySBuilder.Append(rowInfo.DoorCount);
                            // ｴﾝｼﾞﾝ
                            keySBuilder.Append(rowInfo.EngineModelNm);
                            // 排気量
                            keySBuilder.Append(rowInfo.EngineDisplaceNm);
                            // E区分
                            keySBuilder.Append(rowInfo.EDivNm);
                            // ﾐｯｼｮﾝ
                            keySBuilder.Append(rowInfo.TransmissionNm);
                            // 駆動形式
                            keySBuilder.Append(rowInfo.WheelDriveMethodNm);
                            // ｼﾌﾄ
                            keySBuilder.Append(rowInfo.ShiftNm);
                            // 摘要
                            keySBuilder.Append(rowInfo.PartsOpNm);

                            if (!checkGroupDty.ContainsKey(keySBuilder.ToString()))
                            {
                                list = new List<FreeSearchParts>();
                                list.Add(rowInfo);
                                checkGroupDty.Add(keySBuilder.ToString(), list);
                            }
                            else
                            {
                                list = checkGroupDty[keySBuilder.ToString()];
                                list.Add(rowInfo);
                            }
                        }
                        foreach (List<FreeSearchParts> lst in checkGroupDty.Values)
                        {
                            if (lst.Count == 1)
                            {
                                this._freeSearchPartsDty.Add(lst[0].FreSrchPrtPropNo, lst[0]);
                                FreeSearchPartsToDataSet(lst[0]);
                                //ADD 2010/07/01 ------------------>>>
                                if (goodsNoComp.ContainsKey(lst[0].FreSrchPrtPropNo))
                                    goodsNoComp.Remove(lst[0].FreSrchPrtPropNo);

                                goodsNoComp.Add(lst[0].FreSrchPrtPropNo, lst[0].GoodsNo.Replace("-", string.Empty) + lst[0].GoodsMakerCd.ToString().PadLeft(4, '0') + lst[0].TbsPartsCode.ToString().PadLeft(5, '0'));
                                //ADD 2010/07/01 ------------------>>>
                            }
                            else
                            {
                                // 型式グループ区分
                                string fullModelGroup = Guid.NewGuid().ToString();
                                bool addFlg = true;
                                foreach (FreeSearchParts fsp in lst)
                                {
                                    fsp.FullModelGroup = fullModelGroup;
                                    this._freeSearchPartsDty.Add(fsp.FreSrchPrtPropNo, fsp);
                                    if (addFlg)
                                    {
                                        FreeSearchPartsToDataSet(fsp);

                                        //ADD 2010/07/01 ------------------>>>
                                        if(goodsNoComp.ContainsKey(fsp.FreSrchPrtPropNo))
                                            goodsNoComp.Remove(fsp.FreSrchPrtPropNo);

                                        goodsNoComp.Add(fsp.FreSrchPrtPropNo, fsp.GoodsNo.Replace("-", string.Empty) + fsp.GoodsMakerCd.ToString().PadLeft(4, '0') + fsp.TbsPartsCode.ToString().PadLeft(5, '0'));
                                        //ADD 2010/07/01 ------------------>>>
                                        addFlg = false;
                                    }
                                }
                            }
                        }
                        updateModeFlg = true; // ADD 2010/07/01----->>>>
                    }
                }
                // 
                if (this._detailDataTable.Rows.Count == 0)
                {
                    this.DetailRowInitialSetting(1);
                }
                else
                {
                    string guidStr = Guid.NewGuid().ToString().Replace("-", "");

                    DataRow row = this._detailDataTable.NewRow();
                    row[PMJKN09011UC.COL_NO_TITLE] = this._detailDataTable.Rows.Count + 1;
                    row[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE] = guidStr;

                    //ADD START 2009/05/24 GEJUN FOR REDMINE#8049
                    FreeSearchParts freeSearchParts = new FreeSearchParts();
                    // 自由検索部品固有番号
                    freeSearchParts.FreSrchPrtPropNo = guidStr;
                    // 企業コード
                    freeSearchParts.EnterpriseCode = this._enterpriseCode;
                    // メーカーコード
                    freeSearchParts.MakerCode = this._makerCode;
                    // 車種コード
                    freeSearchParts.ModelCode = this._modelCode;
                    // 車種サブコード
                    freeSearchParts.ModelSubCode = this._modelSubCode;
                    // 型式（フル型）
                    freeSearchParts.FullModel = this._fullModel;
                    // データステータス:　2 新規追加データ
                    freeSearchParts.DataStatus = DATASTATUSCODE_2;
                    if (!this._freeSearchPartsDty.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                        this._freeSearchPartsDty.Add(freeSearchParts.FreSrchPrtPropNo, freeSearchParts);

                    if (!_newLineRowIndexDic.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                        this._newLineRowIndexDic.Add(freeSearchParts.FreSrchPrtPropNo, this._detailDataTable.Rows.Count);
                    //ADD END 2009/05/24 GEJUN FOR REDMINE#8049

                    this._detailDataTable.Rows.Add(row);
                }
                // 明細グリッドのDropDownValue追加処理
                this.AddDetailsGridValueList();
                // 明細グリッドのDropDown表示設定処理
                this.SettingDetailsGridCol();
                // 明細グリッド設定処理
                this.SettingGrid();

                this.uGrid_Details.Rows[0].Cells[1].Activate();
                uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            }
            // add start 2010/06/24 by gejun for RedMine #10103
            else
                result = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            return result;
            // add end 2010/06/24 by gejun for RedMine #10103
		}

		/// <summary>
		/// 自由検索部品オブジェクト展開処理
		/// </summary>
		/// <param name="rowInfo">自由検索部品オブジェクト</param>
		private void FreeSearchPartsToDataSet(FreeSearchParts rowInfo)
		{
			DataRow dataRow = this._detailDataTable.NewRow();
			this._detailDataTable.Rows.Add(dataRow);

			//品番
			dataRow[PMJKN09011UC.COL_GOODSNO_TITLE] = rowInfo.GoodsNo;
			//メーカー
			dataRow[PMJKN09011UC.COL_MAKER_TITLE] = rowInfo.GoodsMakerCd.ToString().PadLeft(4, '0');
			//BLコード
            dataRow[PMJKN09011UC.COL_BLCODE_TITLE] = rowInfo.TbsPartsCode.ToString().PadLeft(5, '0');

            object retObj;
            switch (this.SearchGoodsAndRemain(rowInfo.GoodsNo, string.Empty, rowInfo.GoodsMakerCd, out retObj))
            {
                case 0:
                    {
                        if (retObj != null)
                        {
                            // 商品検索
                            if (retObj is List<GoodsUnitData>)
                            {
                                List<GoodsUnitData> goodsUnitDataList = (List<GoodsUnitData>)retObj;

                                if (((GoodsUnitData)goodsUnitDataList[0]).GoodsPriceList != null && ((GoodsUnitData)goodsUnitDataList[0]).GoodsPriceList.Count > 0)
                                {
                                    GoodsPrice gp = ((GoodsUnitData)goodsUnitDataList[0]).GoodsPriceList[0];

                                    // 標準価格
                                    if (gp.ListPrice > 999)
                                        dataRow[PMJKN09011UC.COL_COSTRATE_TITLE] = String.Format("{0:0,0}", gp.ListPrice);
                                    else
                                        dataRow[PMJKN09011UC.COL_COSTRATE_TITLE] = gp.ListPrice.ToString();
                                }
                                else
                                {
                                    // 標準価格
                                    dataRow[PMJKN09011UC.COL_COSTRATE_TITLE] = "0";
                                }
                            }
                        }
                        break;
                    }
                case -1:
                    {
                        //標準価格
                        dataRow[PMJKN09011UC.COL_COSTRATE_TITLE] = string.Empty;
                        break;
                    }
            }

            //品名
            dataRow[PMJKN09011UC.COL_GOODSNM_TITLE] = this.GetBLGoodsFullName(Convert.ToInt32(rowInfo.TbsPartsCode)); 

			//QTY
			dataRow[PMJKN09011UC.COL_PARTSQTY_TITLE] = rowInfo.PartsQty;
            //生産年式（開始日付－終了日付）
            string strModelPrts = "";
            string endModelPrts = "";
            if (rowInfo.ModelPrtsAdptYm != DateTime.MinValue)
            {
                strModelPrts = String.Format("{0:yyyyMM}", rowInfo.ModelPrtsAdptYm);
            }
            else
            {
                strModelPrts = "      ";
            }
            if (rowInfo.ModelPrtsAblsYm != DateTime.MinValue)
            {
                endModelPrts = String.Format("{0:yyyyMM}", rowInfo.ModelPrtsAblsYm);
            }
            else
            {
                endModelPrts = "      ";
            }
            //生産年式（開始日付－終了日付）
            dataRow[PMJKN09011UC.COL_CREATEYEAR_TITLE] = strModelPrts + endModelPrts;

            //生産車台番号（開始番号－終了番号）
            StringBuilder strModelPrtsAdpt = new StringBuilder();
            StringBuilder strModelPrtsAbls = new StringBuilder();
            if (rowInfo.ModelPrtsAdptFrameNo == 0)
            {
                strModelPrtsAdpt.Append("        ");
            }
            else if (rowInfo.ModelPrtsAdptFrameNo.ToString().Length < 8)
            {
                strModelPrtsAdpt.Append(rowInfo.ModelPrtsAdptFrameNo.ToString());
                for (int i = rowInfo.ModelPrtsAdptFrameNo.ToString().Length; i < 8; i++)
                {
                    strModelPrtsAdpt.Append(" ");
                }
            }
            else
            {
                strModelPrtsAdpt.Append(rowInfo.ModelPrtsAdptFrameNo.ToString());
            }
            if (rowInfo.ModelPrtsAblsFrameNo == 0)
            {
                strModelPrtsAbls.Append("        ");
            }
            else if (rowInfo.ModelPrtsAblsFrameNo.ToString().Length < 8)
            {
                strModelPrtsAbls.Append(rowInfo.ModelPrtsAblsFrameNo.ToString());
                for (int i = rowInfo.ModelPrtsAdptFrameNo.ToString().Length; i < 8; i++)
                {
                    strModelPrtsAbls.Append(" ");
                }
            }
            else
            {
                strModelPrtsAbls.Append(rowInfo.ModelPrtsAblsFrameNo.ToString());
            }
            dataRow[PMJKN09011UC.COL_CREATECARNO_TITLE] = strModelPrtsAdpt.ToString() + strModelPrtsAbls.ToString();

			//グレード
			dataRow[PMJKN09011UC.COL_MODELGRADENM_TITLE] = rowInfo.ModelGradeNm;
			//ボディ
			dataRow[PMJKN09011UC.COL_BODYNAME_TITLE] = rowInfo.BodyName;
			//ドア
            if (rowInfo.DoorCount == 0)
            {
                dataRow[PMJKN09011UC.COL_DOORCOUNT_TITLE] = string.Empty;
            }
            else
            {
                dataRow[PMJKN09011UC.COL_DOORCOUNT_TITLE] = rowInfo.DoorCount;
            }
			//エンジン
			dataRow[PMJKN09011UC.COL_ENGINEMODELNM_TITLE] = rowInfo.EngineModelNm;
			//排気量
			dataRow[PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE] = rowInfo.EngineDisplaceNm;
			//E区分
			dataRow[PMJKN09011UC.COL_EDIVNM_TITLE] = rowInfo.EDivNm;
			//ミッション
			dataRow[PMJKN09011UC.COL_TRANSMISSIONNM_TITLE] = rowInfo.TransmissionNm;
			//駆動形式
			dataRow[PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE] = rowInfo.WheelDriveMethodNm;
			//シフト
			dataRow[PMJKN09011UC.COL_SHIFTNM_TITLE] = rowInfo.ShiftNm;
			//摘要
			dataRow[PMJKN09011UC.COL_ADDICARSPEC_TITLE] = rowInfo.PartsOpNm;
			//自由検索部品固有番号
			dataRow[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE] = rowInfo.FreSrchPrtPropNo;
			//型式グループ区分
			dataRow[PMJKN09011UC.COL_FULLMODELGROUP_TITLE] = rowInfo.FullModelGroup;
		}

		/// <summary>
		/// 終了処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		private void Close(bool isConfirm)
		{
			bool canClose = this.ShowSaveCheckDialog(isConfirm);

			if (canClose)
			{
				this.Close();
			}
		}

		/// <summary>
		/// 保存確認ダイアログ表示処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <returns>確認後OK 確認後NG</returns>
		private bool ShowSaveCheckDialog(bool isConfirm)
		{
			bool checkedValue = false;

            if (this.CheckChangedData())
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
					"登録してもよろしいですか？",
					0,
					MessageBoxButtons.YesNoCancel,
					MessageBoxDefaultButton.Button2);

				if (dialogResult == DialogResult.Yes)
				{
                    //checkedValue = this.Save(); // DEL 2010/07/01------------>>>
                    checkedValue = this.Save(true); // ADD 2010/07/01------------>>>
				}
				else if (dialogResult == DialogResult.No)
				{
                    if (isConfirm)
				    {
                        this.Close();
                    }
                    checkedValue = true;
				}
			}
			else
			{
				checkedValue = true;
			}

			return checkedValue;
		}


        /// <summary>
        /// 数字入力のみセルのチェック処理
        /// </summary>
        /// <param name="numStr">セル内容</param>
        /// <param name="rowIndex">行番号</param>
        /// <param name="columnKey">列キー</param>
        private bool CheckNumber(String numStr, int rowIndex, string columnKey)
        {
            char[] numChar = null;

            if (!PMJKN09011UC.COL_MAKER_TITLE.Equals(columnKey) && !PMJKN09011UC.COL_BLCODE_TITLE.Equals(columnKey)
                && !PMJKN09011UC.COL_PARTSQTY_TITLE.Equals(columnKey)
                && !PMJKN09011UC.COL_DOORCOUNT_TITLE.Equals(columnKey))
                return true;

            if (numStr != null)
                numChar = numStr.ToCharArray();
     
            if(numChar != null)
            {
                foreach (char obj in numChar)
                {
                    if (obj > '9' || obj < '0')
                    {
                        TMsgDisp.Show(this,
                                       emErrorLevel.ERR_LEVEL_INFO,
                                       this.Name,
                                       columnKey　+ "の入力が不正です。",
                                       -1,
                                       MessageBoxButtons.OK);

                        return false;

                    }
                }

            }
            return true;
        }

        /// <summary>
        /// セルの前回内容設定処理
        /// </summary>
        /// <param name="columnKey">グラムキー</param>
        /// <param name="rowIndex">行番号</param>
        /// <param name="colIndex">列番号</param>
        private void SetCellBeforeValue(string columnKey, int rowIndex, int colIndex)
        {
            string freSrchPrtPropNo = this.uGrid_Details.Rows[rowIndex].Cells[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE].Text;
            this.uGrid_Details.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
            if (this._freeSearchPartsDty != null)
            {
                if (this._freeSearchPartsDty.ContainsKey(freSrchPrtPropNo))
                {
                    FreeSearchParts freeSearchParts = (FreeSearchParts)this._freeSearchPartsDty[freSrchPrtPropNo];
                    if (PMJKN09011UC.COL_MAKER_TITLE.Equals(columnKey))
                    {
                        if (freeSearchParts.GoodsMakerCd == 0)
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "";
                        else
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = freeSearchParts.GoodsMakerCd.ToString().PadLeft(4, '0');
                    }
                    else if (PMJKN09011UC.COL_BLCODE_TITLE.Equals(columnKey))
                    {
                        if (freeSearchParts.TbsPartsCode == 0)
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "";
                        else
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = freeSearchParts.TbsPartsCode.ToString().PadLeft(5, '0');
                    }
                    else if (PMJKN09011UC.COL_PARTSQTY_TITLE.Equals(columnKey))
                    {
                        if (freeSearchParts.PartsQty == 0)
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "";
                        else
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = freeSearchParts.PartsQty.ToString();
                    }
                    else if (PMJKN09011UC.COL_DOORCOUNT_TITLE.Equals(columnKey))
                    {
                        if (freeSearchParts.DoorCount == 0)
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "";
                        else
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = freeSearchParts.DoorCount.ToString();
                    }
                    else if (PMJKN09011UC.COL_CREATEYEAR_TITLE.Equals(columnKey))
                    {
                        if (this._freeSearchPartsDty[freSrchPrtPropNo].ModelPrtsAblsYm == DateTime.MinValue
                                            && this._freeSearchPartsDty[freSrchPrtPropNo].ModelPrtsAdptYm == DateTime.MinValue)
                        {
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "____.__ - ____.__";
                        }
                        else
                        {
                            string modelPrtsAdptYm = String.Format("{0:yyyyMM}", this._freeSearchPartsDty[freSrchPrtPropNo].ModelPrtsAdptYm);
                            string modelPrtsAblsYm = String.Format("{0:yyyyMM}", this._freeSearchPartsDty[freSrchPrtPropNo].ModelPrtsAblsYm);
                            uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = modelPrtsAdptYm + " - " + modelPrtsAblsYm;
                        }
                    }
                    else
                        uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "";
                }
                else
                {
                    if (PMJKN09011UC.COL_CREATEYEAR_TITLE.Equals(columnKey))
                        uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "____.__ - ____.__";
                    else
                        uGrid_Details.Rows[rowIndex].Cells[colIndex].Value = "";
                }
                this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
            }
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

            if (this.tNedit_SearchGoodsNo.GetInt() != 0)
            {
                return true;
            }

            if (tNedit_CmpltGoodsMakerCd.GetInt() != 0)
            {
                return true;
            }

            if (this.tNedit_BlCd.GetInt() != 0)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.Text.Trim()))
            {
                return true;
            }

            if (this.tNedit_CmpltGoodsMakerCd.GetInt() != 0)
            {
                return true;
            }

            if (this.tNedit_BlCd.GetInt() != 0)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.Text))
            {
                return true;
            }

            if (this.tComboEditor_GoodsNoFuzzy.SelectedIndex != 0)
            {
                return true;
            }

            if (this.uGrid_Details.Rows.Count > 1)
            {
                return true;
            }
            else
            {
                foreach (UltraGridCell cell in this.uGrid_Details.Rows[0].Cells)
                {
                    if (!cell.Column.Key.Equals("No.")
                        && !cell.Column.Hidden)
                    {
                        if (!cell.Column.Key.Equals(PMJKN09011UC.COL_CREATEYEAR_TITLE)
                            && !cell.Column.Key.Equals(PMJKN09011UC.COL_CREATECARNO_TITLE))
                        {
                            if (!string.IsNullOrEmpty(cell.Text))
                            {
                                return true;
                            }
                        }
                        else if (cell.Column.Key.Equals(PMJKN09011UC.COL_CREATEYEAR_TITLE))
                        {
                            if (!cell.Text.Equals("____.__ - ____.__"))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (!cell.Text.Equals("________ - ________"))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            #endregion

            return flg;
        }

		/// <summary>
		/// ガイド起動処理
		/// </summary>
		private void ExecuteGuide()
		{
			if (this._lastControl == null) return;

            string key = this._lastControl.Name;
            if (_lastControl.Name.Equals("_Form1_Toolbars_Dock_Area_Top"))
            {
                key = this._prevControl.Name;
            }
            //ADD START 2009/05/21 GEJUN FOR REDMINE#8049
            int columnIndex = 0;
            if(uGrid_Details.ActiveCell != null)
                columnIndex = uGrid_Details.ActiveCell.Column.Index;
            
            // ﾒｰｶｰにフォーカスがあり
            if(tNedit_CmpltGoodsMakerCd.Focused)
                key = "tNedit_CmpltGoodsMakerCd";
            else if (tNedit_BlCd.Focused)
                key = "tNedit_BlCd";
            else if (columnIndex == 2 || columnIndex == 3)
                key = "uGrid_Details";
            // BLｺｰﾄにフォーカスがあり
            //ADD END 2009/05/21 GEJUN FOR REDMINE#8049
                switch (key)
                {
                    // 車種ガイド起動
                    case "tNedit_MakerCode":
                    case "tNedit_ModelCode":
                    case "tNedit_ModelSubCode":
                        {
                            this.uButton_ModelFullGuide_Click(this, new EventArgs());
                            break;
                        }
                    // メーカーガイド起動
                    case "tNedit_CmpltGoodsMakerCd":
                        {
                            this.uButton_CmpltGoodsMakerGuide_Click(this, new EventArgs());
                            break;
                        }
                    // BLコードガイド起動
                    case "tNedit_BlCd":
                        {
                            this.uButton_BlCodeGuide_Click(this, new EventArgs());
                            break;
                        }
                    case "uGrid_Details":
                        {
                            ExecuteGridGuide();
                            break;
                        }
                }

		}

		/// <summary>
		/// グッレドガイド起動処理
		/// </summary>
		private void ExecuteGridGuide()
		{
			UltraGridCell cell = this.uGrid_Details.ActiveCell;

			if (cell == null) return;

			// マーカーの場合
			if (cell.Column.Key.Equals(PMJKN09011UC.COL_MAKER_TITLE))
			{
				MakerAcs makerAcs = new MakerAcs();
				MakerUMnt makerUMnt;

				//メーカーデータの取得
				int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					//メーカー
					cell.Value = makerUMnt.GoodsMakerCd;

                    // add start 2010/06/21 by gejun for RedMine #10103
                    uGrid_Details.Rows[cell.Row.Index].Cells[cell.Column.Index + 1].Activate();
                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    // add end 2010/06/21 by gejun for RedMine #10103
				}
			}
			// BLコードの場合
			else if (cell.Column.Key.Equals(PMJKN09011UC.COL_BLCODE_TITLE))
			{
				BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
				BLGoodsCdUMnt bLGoodsCdUMnt;
				//BLコードデータの取得
				int status = bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					//BLコード
					cell.Value = bLGoodsCdUMnt.BLGoodsCode;

                    // add start 2010/06/21 by gejun for RedMine #10103
                    uGrid_Details.Rows[cell.Row.Index].Cells[cell.Column.Index + 2].Activate(); 
                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    // add end 2010/06/21 by gejun for RedMine #10103
				}
			}
		}


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
			this._modelGradeValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._bodyNameValueList = new ValueList();
			this._bodyNameValueList.ValueListItems.Clear();
			this._bodyNameValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._doorCountValueList = new ValueList();
			this._doorCountValueList.ValueListItems.Clear();
			this._doorCountValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._engineModelValueList = new ValueList();
			this._engineModelValueList.ValueListItems.Clear();
			this._engineModelValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._engineDisplaceValueList = new ValueList();
			this._engineDisplaceValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._eDivValueList = new ValueList();
			this._eDivValueList.ValueListItems.Clear();
			this._eDivValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._transmissionValueList = new ValueList();
			this._transmissionValueList.ValueListItems.Clear();
			this._transmissionValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._wheelDriveMethodValueList = new ValueList();
			this._wheelDriveMethodValueList.ValueListItems.Clear();
			this._wheelDriveMethodValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			this._shiftValueList = new ValueList();
			this._shiftValueList.ValueListItems.Clear();
			this._shiftValueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);
		}

		/// <summary>
		/// クリア処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		private void Clear(bool isConfirm)
		{
            bool canClear = false;

            if (isConfirm)
            {
                canClear = this.ShowSaveCheckDialog(false);
            }
            else
            {
                canClear = true;
            }

			if (canClear)
			{
				// 類別
				this.tNedit_ModelDesignationNo.Clear();
				this.tNedit_CategoryNo.Clear();

				this.tNedit_MakerCode.Clear();
				this.tNedit_ModelCode.Clear();
				this.tNedit_ModelSubCode.Clear();
				this.tEdit_ModelFullName.Clear();

				this.tEdit_FullModel.Clear();


				this.tDateEdit_StartEntryYearDate.Clear();
				this.tDateEdit_StartEntryMonthDate.Clear();
				this.tDateEdit_EndEntryYearDate.Clear();
				this.tDateEdit_EndEntryMonthDate.Clear();

				this.tEdit_StartProduceFrameNo.Clear();
				this.tEdit_EndProduceFrameNo.Clear();

				this._carSpecDataSet.Clear();

				this.tNedit_SearchGoodsNo.Clear();
				this.StartSearchGoodsNo.Clear();
				this.EndSearchGoodsNo.Clear();

                this.tNedit_CmpltGoodsMakerCd.Clear();
                this.tEdit_CmpltMakerName.Clear();
                this.tNedit_BlCd.Clear();
                this.tEdit_BlName.Clear();
                this.tEdit_GoodsNo.Clear();
                this.tComboEditor_GoodsNoFuzzy.SelectedIndex = 0;

				// ValueListのクリア処理
				this.ClearValueList();
				this.SettingDetailsGridCol();
				// 明細データテーブルの初期設定を行います。
				this.DetailRowInitialSetting(DEFAULT_ROW_COUNT);

                this.SettingGrid();
                this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].Rows.Clear();
                DataRow row = this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].NewRow();
                this._carSpecDataSet.Tables[PMJKN09011UB.TBL_CARSPECVIEW].Rows.Add(row);
                this._selectCarModelInfoDataTable.Rows.Clear();
                this.ultraGrid_CarSpec.Rows[0].Activation = Activation.Disabled;

                // 終了
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
                // クリア
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
                // 最新情報
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
                // 保存
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
                // 検索
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
                // 行削除
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                // 全削除
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = false; // ADD 2010/07/01----->>>
                // ガイド
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
                // 引用登録
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
                this.tNedit_ModelDesignationNo.Focus();

                //add start 2009/06/22 by gejun for RedMine #10103
                // 比較用類別
                this._categoryNo = "";
                // 比較用車種
                this._fullCarType = "";
                // 比較用型式
                this._designationNo = "";
                // 比較用検索番号
                this._searchNo = 0;

                updateModeFlg = false; // ADD 2010/07/01----->>>>
                //add end 2009/06/22 by gejun for RedMine #10103
			}
		}

		/// <summary>
		/// IsDate
		/// </summary>
		/// <param name="date">date</param>
		/// <returns>bool</returns>
		public bool IsDate(string date)
		{
			DateTime dt;
			bool isDate = true;
			try
			{
				dt = DateTime.Parse(date);
			}
			catch (FormatException)
			{
				isDate = false;
			}

			return isDate;
		}

		/// <summary>
		/// 明細行追加処理
		/// </summary>
		internal void AddNewDetailRow()
		{
			// 自由検索部品固有番号
			string freSrchPrtPropNo = Guid.NewGuid().ToString().Replace("-", "");

			DataRow dr = this._detailDataTable.NewRow();
			dr[PMJKN09011UC.COL_FRESRCHPRTPROPNO_TITLE] = freSrchPrtPropNo;

            //ADD START 2009/05/24 GEJUN FOR REDMINE#8049
            FreeSearchParts freeSearchParts = new FreeSearchParts();
            // 自由検索部品固有番号
            freeSearchParts.FreSrchPrtPropNo = freSrchPrtPropNo;
            // 企業コード
            freeSearchParts.EnterpriseCode = this._enterpriseCode;
            // メーカーコード
            freeSearchParts.MakerCode = this._makerCode;
            // 車種コード
            freeSearchParts.ModelCode = this._modelCode;
            // 車種サブコード
            freeSearchParts.ModelSubCode = this._modelSubCode;
            // 型式（フル型）
            freeSearchParts.FullModel = this._fullModel;
            // データステータス:　2 新規追加データ
            freeSearchParts.DataStatus = DATASTATUSCODE_2;
            if(!_freeSearchPartsDty.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                this._freeSearchPartsDty.Add(freeSearchParts.FreSrchPrtPropNo, freeSearchParts);

            if (!_newLineRowIndexDic.ContainsKey(freeSearchParts.FreSrchPrtPropNo))
                this._newLineRowIndexDic.Add(freeSearchParts.FreSrchPrtPropNo, this._detailDataTable.Rows.Count);
            //ADD END 2009/05/24 GEJUN FOR REDMINE#8049

			this._detailDataTable.Rows.Add(dr);
		}

		/// <summary>
		/// ActiveRowの行番号取得処理
		/// </summary>
		/// <returns>行番号</returns>
		internal int GetActiveDetailRowNo()
		{
			int rowIndex = this.GetActiveRowIndex();
			if (rowIndex < 0) return -1;

			return Convert.ToInt32(this._detailDataTable.Rows[rowIndex][PMJKN09011UC.COL_NO_TITLE]);
		}

		/// <summary>
		/// 明細グリッド設定処理
		/// </summary>
		internal void SettingGrid()
		{
			try
			{
				this.uGrid_Details.InitializeLayout -= new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_Details_InitializeLayout);
				// 行数の再設定
				DataRow dr = null;
				for (int rowNum = 0; rowNum < this._detailDataTable.Rows.Count; rowNum++)
				{
					dr = this._detailDataTable.Rows[rowNum];
					dr[PMJKN09011UC.COL_NO_TITLE] = rowNum + 1;
				}
				foreach (DataRow row in _detailDataTable.Rows)
				{
					if (string.IsNullOrEmpty(row[PMJKN09011UC.COL_CREATEYEAR_TITLE].ToString()))
					{
						row[PMJKN09011UC.COL_CREATEYEAR_TITLE] = "____.__-____.__";
					}
                    else if (string.IsNullOrEmpty(row[PMJKN09011UC.COL_CREATECARNO_TITLE].ToString()))
                    {
                        row[PMJKN09011UC.COL_CREATECARNO_TITLE] = "________ - ________";
                    }
				}

                this.uGrid_Details.DataSource = this._detailDataTable;
				this.uGrid_Details.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_Details_InitializeLayout);
                //del start  START 2010/06/24 GEJUN FOR REDMINE #10103
                //if (this.uGrid_Details.Rows.Count >= 0)
                //{
                //    this.uGrid_Details.Rows[0].Cells[1].Activate();
                //    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                //}
                //del end  START 2010/06/24 GEJUN FOR REDMINE #10103
			}
			finally
			{
			}
		}
		# endregion

		/// <summary>
		/// Gridクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
		{
            // 明細部にフォーカス有り(GridActive)
            // 終了
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
            // クリア
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
            // 最新情報
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_LoadData"].SharedProps.Enabled = true;
            // 保存
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
            // 行削除
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = true;
            // ADD 2010/07/01----->>>
            // 全削除
            if(updateModeFlg)
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"].SharedProps.Enabled = true;
            // ADD 2010/07/01----->>>

            //ADD START 2009/05/21 GEJUN FOR REDMINE#8049
            //IMEのチェンジ
            if ((e.Cell.Column.Key.Equals(PMJKN09011UC.COL_ADDICARSPEC_TITLE)))
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            else
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Close;
            //ADD END 2009/05/21 GEJUN FOR REDMINE#8049

            // 明細のメーカー、BLコード
            if ((e.Cell.Column.Key.Equals(PMJKN09011UC.COL_MAKER_TITLE)) ||
                (e.Cell.Column.Key.Equals(PMJKN09011UC.COL_BLCODE_TITLE)))
            {
                // ガイド
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = true;
            }
            else
            {
                // ガイド
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;

            }
            //MODIFY START 2009/05/24 GEJUN FOR REDMINE#8049
            // 明細の品番
            //if (!string.IsNullOrEmpty(e.Cell.Row.Cells[PMJKN09011UC.COL_GOODSNO_TITLE].Text))
            //{
            // 引用登録
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = true;
            //}
            //else
            //{
            //    // 引用登録
            //    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"].SharedProps.Enabled = false;
            //}
            //MODIFY START 2009/05/24 GEJUN FOR REDMINE#8049
            // add start 2009/06/22 by gejun for RedMine #10103
            if ("".Equals(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[PMJKN09011UC.COL_CREATEYEAR_TITLE].Text))
            {
                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[PMJKN09011UC.COL_CREATEYEAR_TITLE].Value = "____.__ - ____.__";
            }
            // add end 2009/06/22 by gejun for RedMine #10103
		}

        /// <summary>
        /// BeforeEnterEditMode
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // 検索
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
        }

        /// <summary>
        /// BLGoodsFullNameの取得
        /// </summary>
        /// <param name="blCode">BLコード</param>
        /// <returns>BLGoodsFullName</returns>
        private string GetBLGoodsFullName(int blCode)
        {
            //-----------------------------------------------------------------------------
            // BLコード検索
            //-----------------------------------------------------------------------------
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            List<Stock> stockList = new List<Stock>();

            // BLコードの設定

            BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
            BLGoodsCdUMnt bLGoodsCdUMnt;

            int status = bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, blCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //>>>2010/07/02
                //return bLGoodsCdUMnt.BLGoodsFullName;
                return bLGoodsCdUMnt.BLGoodsHalfName;
                //<<<2010/07/02
            }

            return "";
        }

        /// <summary>
        /// パラメータのチェック
        /// </summary>
        /// <returns>チェック結果</returns>
        private bool CheckSearchParam()
        {

            if (string.IsNullOrEmpty(tEdit_FullModel.Text.Trim()))
            {
                DialogResult dialogResult = TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "型式を入力して下さい。",
                           0,
                           MessageBoxButtons.OK,
                          MessageBoxDefaultButton.Button1);
                this.tEdit_FullModel.Focus();
                // 検索
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
                // ガイド
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guid"].SharedProps.Enabled = false;
                return false;
            }


            if (string.IsNullOrEmpty(tNedit_MakerCode.Text.Trim()))
            {
                DialogResult dialogResult = TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "車種を入力して下さい。",
                           0,
                           MessageBoxButtons.OK,
                          MessageBoxDefaultButton.Button1);
                this.tNedit_MakerCode.Focus();
                // 検索
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.Enabled = false;
                return false;
            }

            return true;
        }
	}
}
