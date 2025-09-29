using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.IO;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 仕入伝票検索ユーザーコントロールクラス
	/// </summary>
    /// <remarks>
    /// <br>Update Note: 2015/02/04 譚洪</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : 仕掛一覧№2200 redmine #43864 追加対応</br>
    /// <br>           : ハンドルエラーが出る障害の再修正</br>
    /// <br></br>
    /// <br>Update Note: 2015/02/12 30757 佐々木 貴英</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : 仕掛一覧№2200 redmine #43864 追加対応</br>
    /// <br>           : システムテスト障害対応：新規ボタン押下時に仕入伝票検索結果がクリアされる障害対応</br>
    /// <br></br>
    /// </remarks>
    internal partial class SFCMN00221UI : System.Windows.Forms.UserControl
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// 仕入伝票検索フォームクラスのデフォルトコンストラクタ
		/// </summary>
		public SFCMN00221UI(ControlScreenSkin controlScreenSkin)
		{
			// Windows フォーム デザイナ サポートに必要です。
			InitializeComponent();

			// 変数初期化
			this._searchSlipAcs = new SearchSlipAcs();
			this._customerSearchAcs = new CustomerSearchAcs();
			this._searchParaStockSlip = new SearchParaStockSlip();
			this._employeeAcs = new EmployeeAcs();
			this._warehouseAcs = new WarehouseAcs();
			this._goodsAcs = new GoodsAcs();
            this._supplierAcs = new SupplierAcs();

			// スキン設定
			List<string> ctrlNameList = new List<string>();
			ctrlNameList.Add(this.uExplorerBar_Condition.Name);
			controlScreenSkin.SetExceptionCtrl(ctrlNameList);
			controlScreenSkin.SettingScreenSkin(this);

			try
			{
				this.uExplorerBar_Condition.Appearance.BackColor = controlScreenSkin.GetControlAppearance().BackColor;
			}
			catch (NullReferenceException) { }

            uiSetControl1.SettingFormBeforeLoad();
		}

        // --- ADD 譚洪 2015/02/04 ------ >>>
        /// <summary>
        /// 初期化メッソド（コンポ－ネント除く）
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕掛一覧№2200 redmine #43864 追加対応</br>
        /// <br>             コンポーネントハンドル生成エラー対応（再）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2015/02/04 </br>
        /// <br></br>
        /// <br>Update Note: 2015/02/12 30757 佐々木 貴英</br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br>           : 仕掛一覧№2200 redmine #43864 追加対応</br>
        /// <br>           : システムテスト障害対応：新規ボタン押下時に仕入伝票検索結果がクリアされる障害対応</br>
        /// <br></br>
        /// </remarks>
        public void InitForNoComponent()
        {
            // 変数初期化
            // --- DEL 30757 佐々木 貴英 2015/02/12 システムテスト障害対応：新規ボタン押下時に仕入伝票検索結果がクリアされる障害対応------ >>>
            //this._searchSlipAcs = new SearchSlipAcs();
            // --- DEL 30757 佐々木 貴英 2015/02/12 システムテスト障害対応：新規ボタン押下時に仕入伝票検索結果がクリアされる障害対応------ <<<
            // --- ADD 30757 佐々木 貴英 2015/02/12 システムテスト障害対応：新規ボタン押下時に仕入伝票検索結果がクリアされる障害対応------ >>>
            if (null == this._searchSlipAcs)
            {
                this._searchSlipAcs = new SearchSlipAcs();
            }
            // --- ADD 30757 佐々木 貴英 2015/02/12 システムテスト障害対応：新規ボタン押下時に仕入伝票検索結果がクリアされる障害対応------ <<<
            this._customerSearchAcs = new CustomerSearchAcs();
            this._searchParaStockSlip = new SearchParaStockSlip();
            this._employeeAcs = new EmployeeAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._goodsAcs = new GoodsAcs();
            this._supplierAcs = new SupplierAcs();

            // 変数初期化
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;		// 企業コードを取得
            this._secInfoAcs = new SecInfoAcs();

             //グリッドにデータセットをバインド
            this.uGrid_Search.DataSource = this._searchSlipAcs.DataSet.StockSlip.DefaultView;
        }
        // --- ADD 譚洪 2015/02/04 ------ <<<

        // --- DEL 譚洪 2015/02/04 ------ >>>
        // --- ADD 譚洪 2014/11/01 ------ >>>
        /// <summary>
        /// リリース処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : リリース処理を行います</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/11/01</br>
        /// </remarks>
        //public void DisposeForm()
        //{
        //    this._searchSlipAcs = null;
        //    this._customerSearchAcs = null;
        //    this._searchParaStockSlip = null;
        //    this._employeeAcs = null;
        //    this._warehouseAcs = null;
        //    this._goodsAcs = null;
        //    this._supplierAcs = null;

        //    GC.Collect();
        //}
        // --- ADD 譚洪 2014/11/01 ------ <<<
        // --- DEL 譚洪 2015/02/04 ------ <<<
		# endregion

		// ===================================================================================== //
		// 外部に提供する定数群
		// ===================================================================================== //
		# region public static readonly
		public static readonly int EDIT_TYPE_StockDate = 1;									// 仕入日
		public static readonly int EDIT_TYPE_InputDay = 2;									// 入力日
		public static readonly int EDIT_TYPE_SupplierSlipNo = 3;							// 伝票番号
		public static readonly int EDIT_TYPE_StockAgentCode = 4;							// 仕入担当
		public static readonly int EDIT_TYPE_CustomerCode = 5;								// 仕入先コード
		//public static readonly int EDIT_TYPE_CarrierEpCode = 6;								// 事業者コード
		public static readonly int EDIT_TYPE_WarehouseCode = 7;								// 倉庫コード
		public static readonly int EDIT_TYPE_PartySaleSlipNum = 8;							// 相手先伝番
		public static readonly int EDIT_TYPE_GoodsCode = 21;								// 商品コード
		public static readonly int EDIT_TYPE_StockTelNo1 = 22;								// 商品電話番号
		//public static readonly int EDIT_TYPE_ProductNumber1 = 23;							// 製造番号
		# endregion

		// ===================================================================================== //
		// 内部で使用する定数群
		// ===================================================================================== //
		# region Const
		private const int DEFAULT_EDIT_WIDTH = 224;
		private const int GUIDE_WIDTH_DIFFERENCE = 26;
		private const int CONDITION_PANEL_SECTION_ON = 32;
		private const int CONDITION_PANEL_HEIGHT_DEFAULT = 177;
		private const int CONDITION_PANEL_HEIGHT_SLIPDATE = 195;

		private const int INDEX_MakerCode = 0;
		private const int INDEX_AiraMakerCode = 1;
		private const int INDEX_ModelCode = 2;
		private const int INDEX_ModelSubCode = 3;
		
		private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってください。";

		private readonly Color COLOR_REDSLIP = Color.Red;					// 赤伝種別色
		private readonly Color COLOR_OFFSETBLACKSLIP = Color.DarkOrchid;	// 相殺済み黒伝種別色

		private const string FILENAME_COLDISPLAYSTATUS = "SFCMN00221U_ColSetting2.DAT";				// 列表示状態セッティングXMLファイル名
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private string _enterpriseCode = "";								// 企業コード
		private int _xmlNo = 0;
		private NoMngSetAcs _noMngSetAcs;
		private SFCMN00221UL customControl_ExtractWait;
		private SecInfoAcs _secInfoAcs;
		private string _ownSectionCode = "";
		private bool _sectionOption	= false;
		private Color _enabledColor = Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
		private ColDisplayStatusList _colDisplayStatusList;					// 列表示状態コレクションクラス
		private bool _isInitial = true;										// 初期フラグ
		private SearchSlipAcs _searchSlipAcs;
		private CustomerSearchAcs _customerSearchAcs;
		private SearchParaStockSlip _searchParaStockSlip;
		private EmployeeAcs _employeeAcs;
		private WarehouseAcs _warehouseAcs;
		private GoodsAcs _goodsAcs;
        private SupplierAcs _supplierAcs;
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		/// <summary>パネル変更イベント</summary>
		internal event PanelChangeEventHandler PanelChange;

		/// <summary>仕入伝票選択イベント</summary>
		internal event SearchRetStockSlipSelectedHandler SearchRetStockSlipSelected;
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// 初期設定処理
		/// </summary>
		/// <param name="param">起動パラメータ</param>
		internal void InitialSetting(SFCMN00221UAParam param)
		{
			if (this._isInitial)
			{
				// 抽出中コントロールインスタンス化
				this.customControl_ExtractWait = new Broadleaf.Windows.Forms.SFCMN00221UL();
				this.panel_Main.Controls.Add(this.customControl_ExtractWait);
				this.customControl_ExtractWait.BringToFront();
				this.customControl_ExtractWait.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(252)), ((System.Byte)(248)));
				this.customControl_ExtractWait.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
				this.customControl_ExtractWait.Location = new System.Drawing.Point(50, 300);
				this.customControl_ExtractWait.Name = "customControl_ExtractWait";
				this.customControl_ExtractWait.Size = new System.Drawing.Size(250, 40);
				this.customControl_ExtractWait.TabIndex = 22;
				this.customControl_ExtractWait.Visible = false;
				this.customControl_ExtractWait.DataType = "仕入伝票";
				this.customControl_ExtractWait.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));

				// 変数初期化
				this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;		// 企業コードを取得
				this._secInfoAcs = new SecInfoAcs();

				// グリッドにデータセットをバインド
				this.uGrid_Search.DataSource = this._searchSlipAcs.DataSet.StockSlip.DefaultView;

				// コンポーネント初期設定
				this.tEdit_FindCondition.Top = 90;
				this.tEdit_FindCondition.Left = 10;
				this.tEdit_FindConditionCodeType.Top = 89;
                this.tEdit_FindConditionCodeType.Left = 10;
				this.tNedit_FindCondition.Top = 90;
                this.tNedit_FindCondition.Left = 10;
				this.tNedit_FindConditionCodeType.Top = 89;
                this.tNedit_FindConditionCodeType.Left = 10;
				this.tDateEdit_DateSta.Top = 90;
                this.tDateEdit_DateSta.Left = 10;
				this.tDateEdit_DateEnd.Top = 132;
				this.tDateEdit_DateEnd.Left = 10;
				this.uLabel_SlipDate.Top = 115;
				this.uLabel_SlipDate.Left = 95;
				this.uLabel_FindCondition.Top = 89;
				this.uLabel_FindCondition.Left = 10;

                this.tEdit_PartySaleSlipNum.Top = 89;
                this.tEdit_PartySaleSlipNum.Left = 10;
                this.tEdit_EmployeeCode.Top = 89;
                this.tEdit_EmployeeCode.Left = 10;
                this.tNedit_SupplierCd.Top = 89;
                this.tNedit_SupplierCd.Left = 10;
                this.tNedit_SupplierSlipNo_St.Top = 89;
                this.tNedit_SupplierSlipNo_Ed.Top = 89;
                this.ulabel_SupplierSlipNoCndtn.Top = 89;

                this.uLabel_EmployeeName.Top = 89;
                this.uLabel_EmployeeName.Left = 10;

                this.uLabel_SupplierName.Top = 89;
                this.uLabel_SupplierName.Left = 10;

				this.uButton_Guide.Top = 88;
				// 2007.10.12 sasaki >>
				//this.uButton_Guide.Left = 302;
				this.uButton_Guide.Left = 308;
				// 2007.10.12 sasaki <<

				this.tComboEditor_StockSectionCd.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.tLine_SectionPanel.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.tLine_ConditionPanel.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.tComboEditor_SupplierSlipCd.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.tComboEditor_FindCondition.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.uButton_Guide.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
				this.uButton_Find.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
				this.uLabel_FindCondition.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));

				this.tComboEditor_SupplierFormal.Value = 0;
				this.tComboEditor_SupplierSlipCd.Value = 99;
				this.tComboEditor_StockGoodsCd.Value = 99;

				if (param.StockSlipDefaultEditType == 0)
				{
					param.StockSlipDefaultEditType = 1;
					this.tDateEdit_DateSta.SetDateTime(DateTime.Today.AddDays(-7));
					this.tDateEdit_DateEnd.SetDateTime(DateTime.Today);
				}
				this.tComboEditor_FindCondition.Value = param.StockSlipDefaultEditType;
				this.tComboEditor_FindCondition_ValueChanged(this.tComboEditor_FindCondition, EventArgs.Empty);
				this._isInitial = false;
			}

			this._xmlNo = param.XmlNo;

			// 番号編集情報取得処理
			if (this._noMngSetAcs == null)
			{
				this.GetNoMng();
			}

			// 拠点オプションチェック
			if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
			{
				// 拠点オプション有
				this._sectionOption	= true;
			}

			// 画面初期表示設定処理
			this.DisplayInitialSetting();

			// グリッド列初期設定処理
			//this.GridColInitialSetting();
		}

		/// <summary>
		/// 自動検索処理
		/// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierNm">仕入先名称</param>
        // 2008.09.05 Update >>>
		//internal void AutoSearch(int customerCode)
        internal void AutoSearch( int supplierCd,string supplierNm )
        // 2008.09.05 Update <<<
        {
			this.tComboEditor_FindCondition.Value = EDIT_TYPE_CustomerCode;
            // 2008.09.05 Update >>>
            //this.tNedit_FindConditionCodeType.SetInt(customerCode);

            this.tNedit_SupplierCd.SetInt(supplierCd);
            this.uLabel_SupplierName.Text = supplierNm;
            // 2008.09.05 Update <<<
			this.tNedit_FindConditionCodeType.Focus();

			this.uButton_Find_Click(this.uButton_Find, new EventArgs());
		}

		/// <summary>
		/// パネルアクティブメソッド
		/// </summary>
		internal void PanelActivated()
		{
			this.timer_Activated.Enabled = true;
		}

		/// <summary>
		/// 仕入伝票検索処理
		/// </summary>
		/// <param name="para">仕入伝票検索パラメータ</param>
		/// <param name="retList">仕入伝票検索結果クラス配列</param>
		/// <returns>STATUS</returns>
		internal int Search(SearchParaStockSlip para, out List<StockSlip> retList)
		{
			retList = null;
			
			// 検索処理実行
			return this._searchSlipAcs.SetSearchData(para);
		}

		/// <summary>
		/// 列表示状態クラス保存処理
		/// </summary>
		internal void SaveColDisplayStatus()
		{
            if (this.uGrid_Search.DataSource != null)
            {
                // 列表示状態クラスリスト構築処理
                List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Search.DisplayLayout.Bands[0].Columns);
                this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

                // 列表示状態クラスリストをXMLにシリアライズする
                ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), FILENAME_COLDISPLAYSTATUS);
            }
		}
		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
		/// <summary>
		/// 仕入伝票検索結果グリッドカラム情報設定処理
		/// </summary>
		/// <param name="columns">グリッドのカラムコレクション</param>
		private void SettingGridColumns()
		{
			Infragistics.Win.UltraWinGrid.ColumnsCollection columns = this.uGrid_Search.DisplayLayout.Bands[0].Columns;

			// 一旦、全ての列を非表示に設定し、表示位置を統一させる
			foreach(Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
			{
				column.Hidden = true;
				column.CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
				column.CellAppearance.ImageHAlign	= Infragistics.Win.HAlign.Left;
				column.CellAppearance.ImageVAlign	= Infragistics.Win.VAlign.Middle;
				column.CellAppearance.Cursor = Cursors.Hand;
			}

			// 表示非表示設定
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAgentNameColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CustomerNameColumn.ColumnName].Hidden = false;
			// 2007.10.12 sasaki >>
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.WarehouseNameColumn.ColumnName].Hidden = false;
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CarrierNameColumn.ColumnName].Hidden = false;
			// 2007.10.12 sasaki <<
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Hidden = false;
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Hidden = false;
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.AccPayDivCdNameColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockTotalPriceColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote1Column.ColumnName].Hidden = false;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote2Column.ColumnName].Hidden = false;

			// 表示位置設定
			int visiblePosition = 0;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			// 2007.10.12 sasaki >>
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAgentNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			// 2007.10.12 sasaki <<
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CustomerNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			// 2007.10.12 sasaki >>
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.WarehouseNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CarrierNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			// 2007.10.12 sasaki <<
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.AccPayDivCdNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockTotalPriceColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = ++visiblePosition;

			// 表示幅設定
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].Width = 35;			// №
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Width = 80;		// 伝票番号
			// 2007.10.12 sasaki >>
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName].Width = 90; 	// 計上日
			// 2007.10.12 sasaki <<
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName].Width = 90;    		// 仕入日
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAgentNameColumn.ColumnName].Width = 90;  	// 担当者名
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CustomerNameColumn.ColumnName].Width = 120;  	// 仕入先名
			// 2007.10.12 sasaki >>
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.WarehouseNameColumn.ColumnName].Width = 90;  	// 倉庫名
			// 2007.10.12 sasaki <<
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierFomalNameColumn.ColumnName].Width = 70;	// 伝票種別名
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Width = 70;	// 伝票区分名
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Width = 70;	// 赤伝区分名
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Width = 90;	// 商品区分名
			// 2007.10.12 sasaki >>
			//this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CarrierNameColumn.ColumnName].Width = 80;		// キャリア名
			// 2007.10.12 sasaki <<
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockTotalPriceColumn.ColumnName].Width = 100;	// 金額合計
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Width = 90;	// 相手先伝番
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote1Column.ColumnName].Width = 120;	// 伝票備考1
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote2Column.ColumnName].Width = 120;	// 伝票備考2

			// CellAppearance設定
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierFomalNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockGoodsCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.InputDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockTotalPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockSubttlPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Search.DisplayLayout.Override.HeaderAppearance.BackColor;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Search.DisplayLayout.Override.HeaderAppearance.BackColor2;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Search.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.ForeColor = Color.White;

			// フォーマット設定
			string dateFormat = "yyyy/MM/dd";
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName].Format = dateFormat;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName].Format = dateFormat;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.InputDayColumn.ColumnName].Format = dateFormat;
			string moneyFormat = "#,##0;-#,##0;''";
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockTotalPriceColumn.ColumnName].Format = moneyFormat;
			this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockSubttlPriceColumn.ColumnName].Format = moneyFormat;

			// 列表示状態クラスリストXMLファイルをデシリアライズ
			List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(FILENAME_COLDISPLAYSTATUS);

			// 列表示状態コレクションクラスをインスタンス化
			this._colDisplayStatusList = new ColDisplayStatusList(this, colDisplayStatusList);

			foreach (ColDisplayStatus colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
			{
				if (colDisplayStatus.Key == this.tComboEditor_GridFontSize.Name)
				{
					this.tComboEditor_GridFontSize.Value = colDisplayStatus.Width;
				}
				else if (columns.Exists(colDisplayStatus.Key))
				{
					columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
					columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;
					columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
				}
			}
		}

		/// <summary>
		/// 列表示状態クラスリスト構築処理
		/// </summary>
		/// <param name="columns">グリッドのカラムコレクション</param>
		/// <returns>列表示状態クラスリスト</returns>
		/// <remarks>
		/// <br>Note       : グリッドのカラムコレクションを元に、列表示状態クラスリストを構築します。</br>
		/// <br>Programmer : 22014 熊谷　友孝</br>
		/// <br>Date       : 2006.05.31</br>
		/// </remarks>
		private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
		{
			List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

			// フォントサイズを格納
			ColDisplayStatus fontStatus = new ColDisplayStatus();
			fontStatus.Key = this.tComboEditor_GridFontSize.Name;
			fontStatus.VisiblePosition = -1;
			fontStatus.Width = (int)this.tComboEditor_GridFontSize.Value;
			colDisplayStatusList.Add(fontStatus);

			// グリッドから列表示状態クラスリストを構築
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
			{
				ColDisplayStatus colDisplayStatus = new ColDisplayStatus();

				colDisplayStatus.Key = column.Key;
				colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
				colDisplayStatus.HeaderFixed = column.Header.Fixed;
				colDisplayStatus.Width = column.Width;

				colDisplayStatusList.Add(colDisplayStatus);
			}

			return colDisplayStatusList;
		}

		/// <summary>
		/// 画面初期表示設定処理
		/// </summary>
		private void DisplayInitialSetting()
		{
			// システムコンボエディタアイテム設定
			Infragistics.Win.ValueListItem valueListItem0 = new Infragistics.Win.ValueListItem();
			valueListItem0.DataValue = 0;
			valueListItem0.DisplayText = "仕入";

			Infragistics.Win.ValueListItem alueListItem1 = new Infragistics.Win.ValueListItem();
			alueListItem1.DataValue = 1;
			alueListItem1.DisplayText = "入荷";

			this.tComboEditor_SupplierFormal.Items.Clear();
			this.tComboEditor_SupplierFormal.Items.Add(valueListItem0);
			this.tComboEditor_SupplierFormal.Items.Add(alueListItem1);

			// イメージアイコン設定処理
			ImageList imglist = IconResourceManagement.ImageList16;

			this.uButton_Guide.Appearance.Image = imglist.Images[(int)Size16_Index.STAR1];

			// グリッドのフォントサイズを設定
			this.tComboEditor_GridFontSize.Value = 11;

			// 仕入伝票検索結果グリッドカラム情報設定処理
			this.SettingGridColumns();

			// 請求計上拠点リスト設定処理
			this.SetDemandAddUpSecList();
	
			// 請求計上拠点コンボボックス取得
			if (this.panel_ConditionSection.Visible)
			{
				if (this.tComboEditor_StockSectionCd.Items.Count > 0)
				{
					this.tComboEditor_StockSectionCd.MaxDropDownItems = this.tComboEditor_StockSectionCd.Items.Count;

					// 1つの拠点しかない場合は先頭を選択
					if (this.tComboEditor_StockSectionCd.Items.Count == 1)
					{
						this.tComboEditor_StockSectionCd.SelectedIndex = 0;
					}
					else
					{
						// 自拠点の請求計上拠点を選択
						SecInfoSet secInfoSet;
                        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //this._secInfoAcs.GetSecInfo(SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd, out secInfoSet);
                        this._secInfoAcs.GetSecInfo(out secInfoSet);
                        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
						if ((secInfoSet != null) && (secInfoSet.SectionCode != ""))
						{
							this.tComboEditor_StockSectionCd.Value = secInfoSet.SectionCode;
						}
						else
						{
							// 請求計上拠点が設定されていない場合は自拠点を選択
							if (this._ownSectionCode != "")
							{
								this.tComboEditor_StockSectionCd.Value = this._ownSectionCode;
							}
							else
							{
								// 請求計上拠点・自拠点がなければ先頭を選択（※通常はエラー）
								this.tComboEditor_StockSectionCd.SelectedIndex = 0;
							}
						}
					}
				}
			}

			// オフライン制御
			if (!LoginInfoAcquisition.OnlineFlag)
			{
				this.panel_ConditionSection.Enabled = false;
				this.tComboEditor_SupplierFormal.Enabled = false;
				this.tComboEditor_FindCondition.Enabled = false;
				this.tNedit_FindCondition.Enabled = false;
				this.tNedit_FindConditionCodeType.Enabled = false;
				this.tEdit_FindCondition.Enabled = false;
				this.tEdit_FindConditionCodeType.Enabled = false;
				this.uLabel_FindCondition.Enabled = false;
				this.tDateEdit_DateSta.Enabled = false;
				this.tDateEdit_DateEnd.Enabled = false;
				this.uButton_Guide.Enabled = false;

				this.uLabel_FindCondition.Appearance.BackColor = this._enabledColor;
			}
		}

		/// <summary>
		/// 仕入伝票検索パラメータクラス取得処理
		/// </summary>
		/// <returns>仕入伝票検索パラメータクラス</returns>
		private SearchParaStockSlip GetSearchParaStockSlip()
		{
			SearchParaStockSlip para = new SearchParaStockSlip();
			
			para.EnterpriseCode = this._enterpriseCode;
			
			// 仕入拠点コンボボックス取得
			if (this.panel_ConditionSection.Visible)
			{
				para.StockSectionCd = "";

				// 仕入拠点をセット
				if (this.tComboEditor_StockSectionCd.SelectedItem != null)
				{
					para.StockSectionCd = (string)this.tComboEditor_StockSectionCd.SelectedItem.DataValue;
				}
				else
				{
					para.StockSectionCd = "";
				}
			}
			else
			{
				// 仕入拠点に自拠点をセット
				para.StockSectionCd = this._ownSectionCode;
			}

			// 仕入形式
			para.SupplierFormal = this.GetSelectedValue(this.tComboEditor_SupplierFormal);

			// 2007.10.12 sasaki >>
			//// 仕入伝票区分
			//para.SupplierSlipCd = this.GetSelectedValue(this.tComboEditor_SupplierSlipCd);

			// 画面の仕入伝票区分から、抽出用の仕入伝票区分と買掛区分を設定する
			int supplierSlipCd = this.GetSelectedValue(this.tComboEditor_SupplierSlipCd);
			if ((supplierSlipCd == 99) || (supplierSlipCd == 0))
			{
				para.SupplierSlipCd = 99;
				para.AccPayDivCd = 99;
			}
			else
			{
				para.SupplierSlipCd = (supplierSlipCd / 10) * 10;
				para.AccPayDivCd = supplierSlipCd % 10;
			}
			// 2007.10.12 sasaki <<

			// 赤伝区分
			para.DebitNoteDiv = 99;

			// 仕入商品区分
			para.StockGoodsCd = this.GetSelectedValue(this.tComboEditor_StockGoodsCd);

			// 2007.10.12 sasaki >>
			//// 買掛区分
			//para.AccPayDivCd = this.GetSelectedValue(this.tComboEditor_AccPayDivCd);
			// 2007.10.12 sasaki <<

			// コンボエディタ選択値取得処理(抽出条件区分)
			int findConditionCode = this.GetSelectedValue(this.tComboEditor_FindCondition);

			// 仕入日・入荷日
			if (findConditionCode == EDIT_TYPE_StockDate)
			{
				// 2007.10.12 sasaki >>
				//para.ArrivalGoodsDayStart = this.tDateEdit_DateSta.GetDateTime();
				//para.ArrivalGoodsDayEnd = this.tDateEdit_DateEnd.GetDateTime();

				// 仕入の場合は仕入日、入荷の場合は入荷日を指定
				para.StockDateSt = TDateTime.DateTimeToLongDate(this.tDateEdit_DateSta.GetDateTime());
				para.StockDateEd = TDateTime.DateTimeToLongDate(this.tDateEdit_DateEnd.GetDateTime());
				// 2007.10.12 sasaki <<
			}
			// 計上日
			else if (findConditionCode == EDIT_TYPE_InputDay)
			{
				// 2007.10.12 sasaki >>
				//para.StockAddUpADateStart = this.tDateEdit_DateSta.GetDateTime();
				//para.StockAddUpADateEnd = this.tDateEdit_DateEnd.GetDateTime();
				para.InputDaySt = TDateTime.DateTimeToLongDate(this.tDateEdit_DateSta.GetDateTime());
				para.InputDayEd = TDateTime.DateTimeToLongDate(this.tDateEdit_DateEnd.GetDateTime());
				// 2007.10.12 sasaki <<
			}
			// 仕入伝票番号
			else if (findConditionCode == EDIT_TYPE_SupplierSlipNo)
			{
                para.SupplierSlipNoSt = this.tNedit_SupplierSlipNo_St.GetInt();
                para.SupplierSlipNoEd= this.tNedit_SupplierSlipNo_Ed.GetInt();
            }
			// 仕入担当
			else if (findConditionCode == EDIT_TYPE_StockAgentCode)
			{
                para.StockAgentCode = this.tEdit_EmployeeCode.Text;
			}
			// 仕入先コード
			else if (findConditionCode == EDIT_TYPE_CustomerCode)
			{
                para.SupplierCd = this.tNedit_SupplierCd.GetInt();
			}
			// 2007.10.12 sasaki >>
			//// 事業者コード
			//else if (findConditionCode == EDIT_TYPE_CarrierEpCode)
			//{
			//    para.CarrierEpCode = this.tNedit_FindConditionCodeType.GetInt();
			//}
			//// 倉庫コード
			//else if (findConditionCode == EDIT_TYPE_WarehouseCode)
			//{
			//    para.WarehouseCode = this.tEdit_FindConditionCodeType.Text.ToString();
			//}
			// 2007.10.12 sasaki <<
			// 相手先伝番
			else if (findConditionCode == EDIT_TYPE_PartySaleSlipNum)
			{
                para.PartySaleSlipNum = this.tEdit_PartySaleSlipNum.Text;
			}
			// 商品コード
			else if (findConditionCode == EDIT_TYPE_GoodsCode)
			{
				para.GoodsNo = this.tEdit_FindConditionCodeType.Text.ToString();
			}
			// 2007.10.12 sasaki >>
			//// 商品電話番号
			//else if (findConditionCode == EDIT_TYPE_StockTelNo1)
			//{
			//    para.StockTelNo1Start = this.tEdit_FindCondition.Text.ToString();
			//    para.StockTelNo1End = this.tEdit_FindCondition.Text.ToString();
			//}
			//// 製造番号
			//else if (findConditionCode == EDIT_TYPE_ProductNumber1)
			//{
			//    para.ProductNumber1Start = this.tEdit_FindCondition.Text.ToString();
			//    para.ProductNumber1End = this.tEdit_FindCondition.Text.ToString();
			//}
			// 2007.10.12 sasaki <<

			return para;
		}

		/// <summary>
		/// 仕入伝票検索パラメータクラスチェック処理
		/// </summary>
		/// <param name="para">仕入伝票検索パラメータクラス</param>
		/// <returns>true:チェックＯＫ false:チェックＮＧ</returns>
		private bool CheckSearchParaStockSlip(SearchParaStockSlip para)
		{
			// コンボエディタ選択値取得処理(抽出条件区分)
			int findConditionCode = this.GetSelectedValue(this.tComboEditor_FindCondition);
			/*
			if (para.AcptAnOdrStatus10 == 0 &&
				para.AcptAnOdrStatus20 == 0 &&
				para.AcptAnOdrStatus30 == 0 )
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"伝票種別が選択されていません",
					0,
					MessageBoxButtons.OK);
				
				this.uCheckBox_OrderStatus1.Focus();
				return false;
			}

			// 伝票番号
			if (findConditionCode == EDIT_TYPE_SlipNo)
			{
				if (para.SlipNo == "")
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"伝票番号を入力してください。",
						-1,
						MessageBoxButtons.OK);

					this.tEdit_FindCondition.Focus();

					return false;
				}
			}
			// 伝票日付
			else if (findConditionCode == EDIT_TYPE_SlipDate)
			{
				if ((para.StSearchSlipDate == DateTime.MinValue) && (para.EdSearchSlipDate == DateTime.MinValue))
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"伝票日付を入力してください。",
						-1,
						MessageBoxButtons.OK);

					this.tDateEdit_StockDateSta.Focus();

					return false;
				}
				else if ((para.StSearchSlipDate != DateTime.MinValue) && (para.EdSearchSlipDate != DateTime.MinValue) && (para.StSearchSlipDate > para.EdSearchSlipDate))
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"伝票日付の範囲指定が不正です。",
						-1,
						MessageBoxButtons.OK);

					this.tDateEdit_StockDateEnd.Focus();

					return false;
				}
			}
			// 仕入伝票番号
			else if (findConditionCode == EDIT_TYPE_AcceptAnOrderNo)
			{
				if (para.AcceptAnOrderNo == 0)
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"仕入伝票番号を入力してください。",
						-1,
						MessageBoxButtons.OK);

					this.tNedit_FindCondition.Focus();

					return false;
				}
			}
			// 得意先カナ
			else if (findConditionCode == EDIT_TYPE_Kana)
			{
				if (para.Kana == "")
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"得意先カナを入力してください。",
						-1,
						MessageBoxButtons.OK);

					this.tEdit_FindCondition.Focus();

					return false;
				}
			}
			// 得意先コード
			else if (findConditionCode == EDIT_TYPE_CustomerCode)
			{
				if (para.CustomerCode == 0)
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"得意先コードを入力してください。",
						-1,
						MessageBoxButtons.OK);

					this.tNedit_FindCondition.Focus();

					return false;
				}
			}
			// プレート番号４
			else if (findConditionCode == EDIT_TYPE_NumberPlate4)
			{
				if (para.NumberPlate4 == 0)
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"プレート番号を入力してください。",
						-1,
						MessageBoxButtons.OK);

					this.tNedit_FindCondition.Focus();

					return false;
				}
			}
			// 得意先サブコード
			else if (findConditionCode == EDIT_TYPE_CustomerSubCode)
			{
				if (para.CustomerSubCode == "")
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"得意先サブコードを入力してください。",
						-1,
						MessageBoxButtons.OK);

					this.tEdit_FindCondition.Focus();

					return false;
				}
			}
			// 電話番号
			else if (findConditionCode == EDIT_TYPE_SearchTelNo)
			{
				if (para.SearchTelNo == "")
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"電話番号を入力してください。",
						-1,
						MessageBoxButtons.OK);

					this.tEdit_FindCondition.Focus();

					return false;
				}
			}
			// 型式
			else if (findConditionCode == EDIT_TYPE_CarInspectCertModel)
			{
				if (para.CarInspectCertModel == "")
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"型式を入力してください。",
						-1,
						MessageBoxButtons.OK);

					this.tEdit_FindCondition.Focus();

					return false;
				}
			}
			// 車台番号
			else if (findConditionCode == EDIT_TYPE_FrameNo)
			{
				if (para.FrameNo == "")
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"車台番号を入力してください。",
						-1,
						MessageBoxButtons.OK);

					this.tEdit_FindCondition.Focus();

					return false;
				}
			}
			// 在庫車両管理番号
			else if (findConditionCode == EDIT_TYPE_StockCarMngNo)
			{
				if (para.StockCarMngNo == "")
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"在庫車両管理番号を入力してください。",
						-1,
						MessageBoxButtons.OK);

					this.tEdit_FindCondition.Focus();

					return false;
				}
			}
			// メーカーコード
			else if (findConditionCode == EDIT_TYPE_MakerCode)
			{
				if (para.MakerCode == 0)
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"メーカーを指定してください。",
						-1,
						MessageBoxButtons.OK);

					this.uButton_Guide.Focus();

					return false;
				}
			}
			// 車種コード
			else if (findConditionCode == EDIT_TYPE_ModelCode)
			{
				if (para.ModelCode == 0)
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"車種を指定してください。",
						-1,
						MessageBoxButtons.OK);

					this.uButton_Guide.Focus();

					return false;
				}
			}
			*/

			return true;
		}

		/// <summary>
		/// 仕入伝票検索処理
		/// </summary>
		/// <param name="para">仕入伝票検索パラメータクラス</param>
		private void Search(SearchParaStockSlip para)
		{
			// グリッドのフィルタを解除
			this.uGrid_Search.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();

			// 検索処理実行
			int status = this._searchSlipAcs.SetSearchData(para);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// データビューソート設定処理
				this.DataViewSortSetting();

				if (this.uGrid_Search.Rows.Count == 0)
				{
					this.customControl_ExtractWait.Visible = true;
					this.customControl_ExtractWait.mode = 1;
					this.customControl_ExtractWait.Top = this.uGrid_Search.Top + 25;
					this.customControl_ExtractWait.Refresh();

					this.timer_MessageUnDisp.Enabled = true;

					if (this.tEdit_FindCondition.Visible)
					{
						this.tEdit_FindCondition.Focus();
					}
					else if (this.tEdit_FindConditionCodeType.Visible)
					{
						this.tEdit_FindConditionCodeType.Focus();
					}
					else if (this.tNedit_FindCondition.Visible)
					{
						this.tNedit_FindCondition.Focus();
					}
					else if (this.tNedit_FindConditionCodeType.Visible)
					{
						this.tNedit_FindConditionCodeType.Focus();
					}
				}
			}
			else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
				(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
			{
				this.customControl_ExtractWait.Visible = true;
				this.customControl_ExtractWait.mode = 1;
				this.customControl_ExtractWait.Top = this.uGrid_Search.Top + 60;
				this.customControl_ExtractWait.Refresh();

				this.timer_MessageUnDisp.Enabled = true;

				if (this.tEdit_FindCondition.Visible)
				{
					this.tEdit_FindCondition.Focus();
				}
				else if (this.tEdit_FindConditionCodeType.Visible)
				{
					this.tEdit_FindConditionCodeType.Focus();
				}
				else if (this.tNedit_FindCondition.Visible)
				{
					this.tNedit_FindCondition.Focus();
				}
				else if (this.tNedit_FindConditionCodeType.Visible)
				{
					this.tNedit_FindConditionCodeType.Focus();
				}
			}
			else
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"仕入伝票データの検索に失敗しました。",
					status,
					MessageBoxButtons.OK);
			}

			this._searchParaStockSlip = para;
		}

		/// <summary>
		/// パネル変更イベントコール処理
		/// </summary>
		/// <param name="mode">モード</param>
		private void PanelChangeEventCall(int dispNo)
		{
			if (this.PanelChange != null)
			{
				PanelChangeEventArgs e = new PanelChangeEventArgs(PanelChangeEventArgs.MODE_UPDATE, dispNo);
				this.PanelChange(this, e);
			}
		}

		/// <summary>
		/// TEdit入力プロパティド変換処理
		/// </summary>
		/// <param name="edit">変更するEditコンポーネント</param>
		/// <param name="findConditionCode">抽出条件区分</param>
		private void TEditChangeEdit(Broadleaf.Library.Windows.Forms.TEdit tEdit, int findConditionCode)
		{
			if (findConditionCode == EDIT_TYPE_PartySaleSlipNum)				// 相手先伝番
			{
				tEdit.CharacterCasing = CharacterCasing.Normal;
				tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 19, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
				tEdit.ImeMode = System.Windows.Forms.ImeMode.Close;
			}
			else if (findConditionCode == EDIT_TYPE_GoodsCode)					// 商品コード
			{
				tEdit.CharacterCasing = CharacterCasing.Upper;
				tEdit.ImeMode = ImeMode.Off;
				tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 15, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
			}
			else if (findConditionCode == EDIT_TYPE_StockTelNo1)				// 商品電話番号
			{
				tEdit.CharacterCasing = CharacterCasing.Upper;
				tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
				tEdit.ImeMode = ImeMode.Off;
			}
            //else if (findConditionCode == EDIT_TYPE_ProductNumber1)				// 製造番号
            //{
            //    tEdit.CharacterCasing = CharacterCasing.Upper;
            //    tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            //    tEdit.ImeMode = ImeMode.Off;
            //}
			else if (findConditionCode == EDIT_TYPE_StockAgentCode)				// 仕入担当
			{
				tEdit.CharacterCasing = CharacterCasing.Upper;
				tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
				tEdit.ImeMode = ImeMode.Off;
			}
			else if (findConditionCode == EDIT_TYPE_WarehouseCode)				// 倉庫
			{
				tEdit.CharacterCasing = CharacterCasing.Upper;
				tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
				tEdit.ImeMode = ImeMode.Off;
			}
		}

		/// <summary>
		/// TNedit入力モード変換処理
		/// </summary>
		/// <param name="edit">変更するEditコンポーネント</param>
		/// <param name="mode">モード</param>
		private void TNeditChangeEdit(Broadleaf.Library.Windows.Forms.TNedit nEdit, int mode)
		{
			if ((mode == EDIT_TYPE_SupplierSlipNo) ||		// 仕入伝票番号
				(mode == EDIT_TYPE_CustomerCode))			// 得意先コード
			{
				nEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
				nEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
			}
            //else if (mode == EDIT_TYPE_CarrierEpCode)		// 事業者コード
            //{
            //    nEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            //    nEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            //}
		}

		/// <summary>
		/// 番号編集情報取得処理
		/// </summary>
		private void GetNoMng()
		{
			if (!LoginInfoAcquisition.OnlineFlag)
			{
				return;
			}

			//番号タイプ管理マスタを取得し部品のStaticバッファへセット
			this._noMngSetAcs = new NoMngSetAcs();
			ArrayList retNoTypMngList;
			int status = this._noMngSetAcs.Search(out retNoTypMngList,LoginInfoAcquisition.EnterpriseCode);
			if (status == 0)
			{
				NumberControl.NoTypeMngList = retNoTypMngList.ToArray(typeof(NoTypeMng)) as NoTypeMng[];
			}
			else
			{
				//
			}
		}

		/// <summary>
		/// コンボエディタ選択値取得処理
		/// </summary>
		/// <param name="sender">対象コンボエディタ</param>
		/// <returns>選択値</returns>
		private int GetSelectedValue(TComboEditor sender)
		{
			int findConditionCode = 0;
			if ((sender.SelectedItem != null) && (sender.SelectedItem.DataValue is Int32))
			{
				findConditionCode = (int)sender.SelectedItem.DataValue;
			}

			return findConditionCode;
		}

		/// <summary>
		/// 伝票番号コンバート処理
		/// </summary>
		private void NumberConvertProc()
		{
			/*
			// コンボエディタ選択値取得処理(データ入力システム／抽出条件区分)
			int dataInputSystem = this.GetSelectedValue(this.tComboEditor_SupplierFormal);
			int findConditionCode = this.GetSelectedValue(this.tComboEditor_FindCondition);

			// 伝票番号の場合
			if (findConditionCode == (int)EDIT_TYPE_SlipNo)
			{
				string before = this.tEdit_FindCondition.DataText;
				int acptAnOdrStatus10 = 0;
				int acptAnOdrStatus20 = 0;
				int acptAnOdrStatus30 = 0;
				if (this.uCheckBox_OrderStatus1.Checked == true) acptAnOdrStatus10 = 1;
				if (this.uCheckBox_OrderStatus2.Checked == true) acptAnOdrStatus20 = 1;
				if (this.uCheckBox_OrderStatus3.Checked == true) acptAnOdrStatus30 = 1;
				string after = before;

				if (dataInputSystem == 0)
				{
					string after1 = this.SlipNoNumberConvert(before, 1, acptAnOdrStatus10, acptAnOdrStatus20, acptAnOdrStatus30);
					string after2 = this.SlipNoNumberConvert(before, 2, acptAnOdrStatus10, acptAnOdrStatus20, acptAnOdrStatus30);
					string after3 = this.SlipNoNumberConvert(before, 3, acptAnOdrStatus10, acptAnOdrStatus20, acptAnOdrStatus30);

					if ((after1 == after2) && (after2 == after3))
					{
						after = after1;
					}
				}
				else
				{
					after = this.SlipNoNumberConvert(before, dataInputSystem, acptAnOdrStatus10, acptAnOdrStatus20, acptAnOdrStatus30);
				}
				this.tEdit_FindCondition.DataText = after;
			}
			*/
		}

		/// <summary>
		/// データビューソート設定処理
		/// </summary>
		private void DataViewSortSetting()
		{
			// コンボエディタ選択値取得処理(抽出条件区分)
			int findConditionCode = this.GetSelectedValue(this.tComboEditor_FindCondition);

			// 入荷日
			if (findConditionCode == EDIT_TYPE_StockDate)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort = 
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC" + " , " +
					this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName + " DESC";
			}
			// 計上日
			else if (findConditionCode == EDIT_TYPE_InputDay)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort =
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC" + " , " +
					this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName + " DESC";
			}
			// 仕入伝票番号
			else if (findConditionCode == EDIT_TYPE_SupplierSlipNo)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort = 
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC";
			}
			// 仕入担当
			else if (findConditionCode == EDIT_TYPE_StockAgentCode)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort = 
					this._searchSlipAcs.DataSet.StockSlip.StockAgentNameColumn.ColumnName + " ASC" + " , " +
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC";
			}
			// 仕入先
			else if (findConditionCode == EDIT_TYPE_CustomerCode)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort =
					this._searchSlipAcs.DataSet.StockSlip.CustomerNameColumn.ColumnName + " ASC" + " , " +
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC";
			}
			// 2007.10.12 sasaki >>
			//// 事業者
			//else if (findConditionCode == EDIT_TYPE_CarrierEpCode)
			//{
			//    this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort =
			//        this._searchSlipAcs.DataSet.StockSlip.CarrierNameColumn.ColumnName + " ASC" + " , " +
			//        this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC";
			//}
			// 2007.10.12 sasaki <<
			// 相手先伝番
			else if (findConditionCode == EDIT_TYPE_PartySaleSlipNum)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort =
					this._searchSlipAcs.DataSet.StockSlip.PartySaleSlipNumColumn.ColumnName + " ASC" + " , " +
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC";
			}
			// 商品コード
			else if (findConditionCode == EDIT_TYPE_GoodsCode)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort =
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC" + " , " +
					this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName + " DESC";
			}
			// 商品電話番号
			else if (findConditionCode == EDIT_TYPE_StockTelNo1)
			{
				this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort =
					this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC" + " , " +
					this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName + " DESC";
			}
            //// 製造番号
            //else if (findConditionCode == EDIT_TYPE_ProductNumber1)
            //{
            //    this._searchSlipAcs.DataSet.StockSlip.DefaultView.Sort =
            //        this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName + " DESC" + " , " +
            //        this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName + " DESC";
            //}
		}

		/// <summary>
		/// 請求計上拠点リスト設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 請求計上拠点リストの設定を行います。</br>
		/// <br>Programmer : 980076 妻鳥　謙一郎</br>
		/// <br>Date       : 2006.04.11</br>
		/// </remarks>
		private void SetDemandAddUpSecList()
		{
			// 一旦すべての拠点をクリア
			this.tComboEditor_StockSectionCd.Items.Clear();

			// デフォルトは非表示にする
			this.panel_ConditionSection.Visible = false;

			// 自拠点の取得
			SecInfoSet secInfoSet;
            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //this._secInfoAcs.GetSecInfo(SecInfoAcs.CtrlFuncCode.OwnSecSetting, out secInfoSet);
            this._secInfoAcs.GetSecInfo(out secInfoSet);
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			if (secInfoSet != null)
			{
				// 自拠点コードの保存
				this._ownSectionCode = secInfoSet.SectionCode;

				// 拠点オプション有？
				if (!this._sectionOption)
				{
					return;
				}

				// 本社機能か？
				if (secInfoSet.MainOfficeFuncFlag == 1)
				{
					this.panel_ConditionSection.Visible = true;
				}
				// 拠点機能か？
				else
				{
					return;
				}
			}
			else
			{
				// 自拠点が設定されていない場合はログイン従業員の拠点情報を取得
				if (this._secInfoAcs.SecInfoSet != null)
				{
					// 自拠点コードの保存
					this._ownSectionCode = this._secInfoAcs.SecInfoSet.SectionCode;

					// 拠点オプション有？
					if (!this._sectionOption)
					{
						return;
					}

					// 本社機能か？
					if (this._secInfoAcs.SecInfoSet.MainOfficeFuncFlag == 1)
					{
						this.panel_ConditionSection.Visible = true;
					}
					// 拠点機能か？
					else
					{
						return;
					}
				}
				else
				{
					// 警告メッセージを表示する（自拠点情報なし）
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						MESSAGE_NONOWNSECTION,
						0,
						MessageBoxButtons.OK);
				}
			}

			// TODO: 全社をセットする場合は以下復活
			// this.tComboEditor_DemandAddUpSecCd.Items.Add("", "全社");

			// 拠点情報リストの取得
			if ((this._secInfoAcs.SecInfoSetList != null) && (this._secInfoAcs.SecInfoSetList.Length > 0))
			{
				foreach (SecInfoSet setSecInfoSet in this._secInfoAcs.SecInfoSetList)
				{
					this.tComboEditor_StockSectionCd.Items.Add(setSecInfoSet.SectionCode, setSecInfoSet.SectionGuideNm);
				}
			}
			else
			{
				// TODO: 全社をセットする場合は以下削除
				this.tComboEditor_StockSectionCd.Items.Add("", "全社");
			}

			tComboEditor_FindCondition_ValueChanged(this.tComboEditor_FindCondition, new EventArgs());
		}

		/// <summary>
		/// 種別セルフォントカラー取得処理
		/// </summary>
		/// <param name="row">グリッドRow</param>
		/// <returns>種別セルフォントカラー</returns>
		private Color GetKindCellForeColor(Infragistics.Win.UltraWinGrid.UltraGridRow row)
		{
			Color cellForeColor = this.uGrid_Search.DisplayLayout.Override.CellAppearance.ForeColor;

			/*
			// 赤伝
			if ((int)row.Cells[SEARCH_COL_DebitNoteDiv].Value == 1)
			{
				cellForeColor = COLOR_REDSLIP;
				return cellForeColor;
			}

			// 相殺済み黒伝
			if (((int)row.Cells[SEARCH_COL_DebitNoteDiv].Value == 0) &&
				((int)row.Cells[SEARCH_COL_DebitNLnkAcptAnOdr].Value != 0))
			{
				cellForeColor = COLOR_OFFSETBLACKSLIP;
				return cellForeColor;
			}

			// 加修伝票
			if ((int)row.Cells[SEARCH_COL_StockRepairCd].Value == 1)
			{
				cellForeColor = COLOR_STOCKREPAIR;
				return cellForeColor;
			}

			// 仕入伝票ステータスに応じた色の設定
			switch ((int)row.Cells[SEARCH_COL_AcptAnOdrStatus].Value)
			{
				case 10:
				{
					cellForeColor = COLOR_ESTIMATE;
					return cellForeColor;
				}
				case 20:
				{
					cellForeColor = COLOR_ACPTANODR;
					return cellForeColor;
				}
				case 30:
				{
					cellForeColor = COLOR_SETTLEMENT;
					return cellForeColor;
				}
			}
			*/
			return cellForeColor;
		}

		/// <summary>
		/// 在庫車両管理番号入力エディットプロパティ変更処理
		/// </summary>
		private void StockCarMngNoEditPropatyChange(Broadleaf.Library.Windows.Forms.TEdit tEdit)
		{
			// デフォルト設定
			tEdit.ExtEdit = new TExtEdit(emCursorPosition.Prev, false, true, 9, new TEnableChars(false, false, false, false, true, true, true));

			if (NumberControl.NoTypeMngList != null)
			{
				NumberControl numberControl = new NumberControl();

				Int32 maxLength = numberControl.GetLength((int)ConstantManagement_SF_AP.NoCode.StockCarMngNo);
				Int32 inputType = numberControl.GetInputType((int)ConstantManagement_SF_AP.NoCode.StockCarMngNo);

				if (maxLength > 0)
				{
					// 数値の場合
					if (inputType == 0)
					{
						tEdit.ExtEdit = new TExtEdit(emCursorPosition.Prev, false, true, maxLength, new TEnableChars(false, false, false, false, false, false, true));
					}
					// 文字の場合
					else
					{
						tEdit.ExtEdit = new TExtEdit(emCursorPosition.Prev, false, true, maxLength, new TEnableChars(false, false, true, false, true, true, true));
					}
				}

				tEdit.MaxLength = maxLength;

				Int32 posi = numberControl.GetDispPosition((int)ConstantManagement_SF_AP.NoCode.StockCarMngNo);

				if (posi == 0)
				{
					tEdit.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
				}
				else
				{
					tEdit.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
				}
			}
		}

        // DEL 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 得意先選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        //private void CustomerSearchGuide_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    this.tNedit_FindConditionCodeType.SetInt(customerSearchRet.CustomerCode);
        //    this.uLabel_FindCondition.Text = customerSearchRet.Name + " " + customerSearchRet.Name2;

        //    this.uButton_Find.Focus();
        //    this.uButton_Find_Click(this.uButton_Find, new EventArgs());
        //}
        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void SupplierSearchGuide_SupplierSelect(Supplier supplier)
        {
            if (supplier == null) return;

            this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);
            this.uLabel_SupplierName.Text = supplier.SupplierNm1 + " " + supplier.SupplierNm2;

            this.tNedit_FindConditionCodeType.SetInt(supplier.SupplierCd);
            this.uLabel_FindCondition.Text = supplier.SupplierNm1 + " " + supplier.SupplierNm2;

            this.uButton_Find.Focus();
            this.uButton_Find_Click(this.uButton_Find, new EventArgs());
        }
        // DEL 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		# endregion

		// ===================================================================================== //
		// コントロールイベント処理
		// ===================================================================================== //
		# region Control Event Methods
		/// <summary>
		/// 抽出条件コンボエディタ値変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_FindCondition_ValueChanged(object sender, System.EventArgs e)
		{
			if (!(sender is TComboEditor)) return;

			TComboEditor tComboEditor = (TComboEditor)sender;
			if (tComboEditor.SelectedItem == null) return;

            this.tEdit_FindCondition.BeginUpdate();
            this.tEdit_FindConditionCodeType.BeginUpdate();
            this.tNedit_FindCondition.BeginUpdate();
            this.tNedit_FindConditionCodeType.BeginUpdate();
            this.uLabel_SlipDate.BeginUpdate();
            this.uButton_Guide.BeginUpdate();
            this.uLabel_FindCondition.BeginUpdate();
            this.tNedit_SupplierCd.BeginUpdate();
            this.uLabel_SupplierName.BeginUpdate();
            this.tEdit_EmployeeCode.BeginUpdate();
            this.uLabel_EmployeeName.BeginUpdate();
            this.tEdit_PartySaleSlipNum.BeginUpdate();
            this.tNedit_SupplierSlipNo_St.BeginUpdate();
            this.tNedit_SupplierSlipNo_Ed.BeginUpdate();
            this.ulabel_SupplierSlipNoCndtn.BeginUpdate();

            bool tEdit_FindConditionVisible = false;
            bool tEdit_FindConditionCodeTypeVisible = false;
            bool tNedit_FindConditionVisible = false;
            bool tNedit_FindConditionCodeTypeVisible = false;
            bool tDateEdit_DateStaVisible = false;
            bool tDateEdit_DateEndVisible = false;
            bool uLabel_SlipDateVisible = false;
            bool uButton_GuideVisible = false;
            bool uLabel_FindConditionVisible = false;
            bool tNedit_SupplierCdVisible = false;
            bool uLabel_SupplierNameVisible = false;
            bool tEdit_EmployeeCdVisible = false;
            bool uLabel_EmployeeNameVisible = false;
            bool tEdit_PartySaleSlipNumVisible = false;
            bool tNedit_SupplierSlipNoVisible = false;

            try
            {

                // 抽出条件値をクリア
                this.uLabel_FindCondition.Text = "";
                this.tEdit_FindCondition.Clear();
                this.tEdit_FindConditionCodeType.Clear();
                this.tNedit_FindCondition.Clear();
                this.tNedit_FindConditionCodeType.Clear();
                this.tNedit_SupplierCd.Clear();
                this.uLabel_SupplierName.Text = "";
                this.tEdit_EmployeeCode.Clear();
                this.uLabel_EmployeeName.Text = "";
                this.tEdit_PartySaleSlipNum.Clear();
                this.tNedit_SupplierSlipNo_Ed.Clear();
                this.tNedit_SupplierSlipNo_St.Clear();

                int mode = 0;
                if (tComboEditor.SelectedItem.DataValue is Int32)
                {
                    mode = Convert.ToInt32(tComboEditor.SelectedItem.DataValue);
                }

                SecInfoSet secInfoSet;
                // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //this._secInfoAcs.GetSecInfo(SecInfoAcs.CtrlFuncCode.OwnSecSetting, out secInfoSet);
                this._secInfoAcs.GetSecInfo(out secInfoSet);
                // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                //// 伝票番号
                //if (mode == EDIT_TYPE_SupplierSlipNo)
                //{
                //    this.tNedit_FindCondition.Visible = true;
                //    this.uLabel_FindCondition.Visible = true;
                //    this.uLabel_FindCondition.ContextMenu = null;
                //    this.uLabel_FindCondition.Cursor = Cursors.Default;
                //    this.toolTip_Hint.SetToolTip(this.uLabel_FindCondition, "");

                //    this.uLabel_FindCondition.Appearance.BackColor = Color.White;
                //    this.uLabel_FindCondition.Left = 10;

                //    this.tNedit_FindCondition.Width = DEFAULT_EDIT_WIDTH;
                //    this.uLabel_FindCondition.Width = this.tComboEditor_FindCondition.Width;

                //    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                //    {
                //        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT + CONDITION_PANEL_SECTION_ON;
                //    }
                //    else
                //    {
                //        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT;
                //    }

                //    // TNedit入力プロパティド変換処理
                //    this.TNeditChangeEdit(this.tNedit_FindCondition, mode);
                //}
                // 伝票番号
                if (mode == EDIT_TYPE_SupplierSlipNo)
                {
                    tNedit_SupplierSlipNoVisible = true;
                    
                    this.tNedit_SupplierSlipNo_St.Left = this.tComboEditor_FindCondition.Left;

                    this.tNedit_SupplierSlipNo_Ed.Left = this.tComboEditor_FindCondition.Left + this.tComboEditor_FindCondition.Width - this.tNedit_SupplierSlipNo_Ed.Width;

                    this.ulabel_SupplierSlipNoCndtn.Left = this.tNedit_SupplierSlipNo_St.Left + this.tNedit_SupplierSlipNo_St.Width + ( ( this.tComboEditor_FindCondition.Width - this.tNedit_SupplierSlipNo_Ed.Width - this.tNedit_SupplierSlipNo_St.Width - this.ulabel_SupplierSlipNoCndtn.Width ) / 2 );

                    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_SLIPDATE + CONDITION_PANEL_SECTION_ON;
                    }
                    else
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_SLIPDATE;
                    }

                    //// TNedit入力プロパティド変換処理
                    //this.TNeditChangeEdit(this.tNedit_FindCondition, mode);
                }
                // 相手先伝番
                else if ( mode == EDIT_TYPE_PartySaleSlipNum )
                {
                    tEdit_PartySaleSlipNumVisible = true;
                    this.tEdit_PartySaleSlipNum.ContextMenu = null;
                    this.tEdit_PartySaleSlipNum.Width = this.tComboEditor_FindCondition.Width;
                    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT + CONDITION_PANEL_SECTION_ON;
                    }
                    else
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT;
                    }

                }
                //// 相手先伝番
                //// 商品電話番号
                //else if (( mode == EDIT_TYPE_PartySaleSlipNum ) ||
                //    ( mode == EDIT_TYPE_StockTelNo1 ) ||
                //    ( mode == EDIT_TYPE_ProductNumber1 ))
                //{
                //    this.tEdit_FindCondition.Visible = true;
                //    this.tEdit_FindConditionCodeType.Visible = false;
                //    this.tNedit_FindCondition.Visible = false;
                //    this.tNedit_FindConditionCodeType.Visible = false;
                //    this.tDateEdit_DateSta.Visible = false;
                //    this.tDateEdit_DateEnd.Visible = false;
                //    this.uLabel_SlipDate.Visible = false;
                //    this.uButton_Guide.Visible = false;
                //    this.uLabel_FindCondition.Visible = true;
                //    this.uLabel_FindCondition.ContextMenu = null;
                //    this.uLabel_FindCondition.Cursor = Cursors.Default;
                //    this.toolTip_Hint.SetToolTip(this.uLabel_FindCondition, "");

                //    this.uLabel_FindCondition.Appearance.BackColor = Color.White;
                //    this.uLabel_FindCondition.Left = 10;

                //    this.tEdit_FindCondition.Width = DEFAULT_EDIT_WIDTH;
                //    this.uLabel_FindCondition.Width = this.tComboEditor_FindCondition.Width;

                //    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                //    {
                //        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT + CONDITION_PANEL_SECTION_ON;
                //    }
                //    else
                //    {
                //        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT;
                //    }

                //    // TEdit入力プロパティド変換処理
                //    this.TEditChangeEdit(this.tEdit_FindCondition, mode);
                //}
                // 仕入先
                else if (mode == EDIT_TYPE_CustomerCode)
                {
                    uButton_GuideVisible = true;
                    tNedit_SupplierCdVisible = true;
                    uLabel_SupplierNameVisible = true;
                    this.uLabel_SupplierName.Visible = true;

                    this.toolTip_Hint.SetToolTip(this.uLabel_SupplierName, "");

                    if (mode == EDIT_TYPE_CustomerCode)
                    {
                        this.toolTip_Hint.SetToolTip(this.uButton_Guide, "仕入先検索");
                        this.tNedit_FindConditionCodeType.Size = new Size(84, 22);
                    }

                    this.uLabel_SupplierName.Appearance.BackColor = SystemColors.ControlLight;
                    this.uLabel_SupplierName.Left = this.tNedit_SupplierCd.Left + this.tNedit_SupplierCd.Width + 3;
                    this.uLabel_SupplierName.Width = this.tComboEditor_FindCondition.Width - GUIDE_WIDTH_DIFFERENCE - this.tNedit_SupplierCd.Width - 3;

                    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT + CONDITION_PANEL_SECTION_ON;
                    }
                    else
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT;
                    }
                }
                // 担当者
                else if (mode == EDIT_TYPE_StockAgentCode)
                {
                    tEdit_EmployeeCdVisible = true;
                    uLabel_EmployeeNameVisible = true;
                    uButton_GuideVisible = true;
                    this.uLabel_EmployeeName.Cursor = Cursors.Default;
                    //this.toolTip_Hint.SetToolTip(this.uLabel_FindCondition, "");

                    this.toolTip_Hint.SetToolTip(this.uButton_Guide, "担当者ガイド");
                    //this.tEdit_FindConditionCodeType.Size = new Size(84, 22);

                    this.uLabel_EmployeeName.Appearance.BackColor = SystemColors.ControlLight;

                    this.uLabel_EmployeeName.Appearance.BackColor = SystemColors.ControlLight;
                    this.uLabel_EmployeeName.Left = this.tEdit_EmployeeCode.Left + this.tEdit_EmployeeCode.Width + 3;
                    this.uLabel_EmployeeName.Width = this.tComboEditor_FindCondition.Width - GUIDE_WIDTH_DIFFERENCE - this.tEdit_EmployeeCode.Width - 3;

                    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT + CONDITION_PANEL_SECTION_ON;
                    }
                    else
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT;
                    }

                    //// TEdit入力プロパティド変換処理
                    //this.TEditChangeEdit(this.tEdit_FindConditionCodeType, mode);
                }

                // 倉庫
                // 商品
                else if (( mode == EDIT_TYPE_WarehouseCode ) ||
                         ( mode == EDIT_TYPE_GoodsCode ))
                {
                    this.tEdit_FindCondition.Visible = false;
                    this.tEdit_FindConditionCodeType.Visible = true;
                    this.tNedit_FindCondition.Visible = false;
                    this.tNedit_FindConditionCodeType.Visible = false;
                    this.tDateEdit_DateSta.Visible = false;
                    this.tDateEdit_DateEnd.Visible = false;
                    this.uLabel_SlipDate.Visible = false;
                    this.uButton_Guide.Visible = true;
                    this.uLabel_FindCondition.Visible = true;
                    //this.uLabel_FindCondition.ContextMenu = this.contextMenu_Condition;
                    this.uLabel_FindCondition.Cursor = Cursors.Default;
                    //this.toolTip_Hint.SetToolTip(this.uLabel_FindCondition, SFCMN00221UA.MESSAGE_CONDITION_CLEAR);
                    this.toolTip_Hint.SetToolTip(this.uLabel_FindCondition, "");

                    if (mode == EDIT_TYPE_StockAgentCode)
                    {
                        this.toolTip_Hint.SetToolTip(this.uButton_Guide, "担当者ガイド");
                        this.tEdit_FindConditionCodeType.Size = new Size(84, 22);
                    }
                    else if (mode == EDIT_TYPE_WarehouseCode)
                    {
                        this.toolTip_Hint.SetToolTip(this.uButton_Guide, "倉庫ガイド");
                        this.tEdit_FindConditionCodeType.Size = new Size(68, 22);
                    }
                    else if (mode == EDIT_TYPE_GoodsCode)
                    {
                        this.toolTip_Hint.SetToolTip(this.uButton_Guide, "商品検索");
                        this.tEdit_FindConditionCodeType.Size = new Size(147, 22);
                    }

                    this.uLabel_FindCondition.Appearance.BackColor = SystemColors.ControlLight;
                    this.uLabel_FindCondition.Left = this.tEdit_FindConditionCodeType.Left + this.tEdit_FindConditionCodeType.Width + 3;
                    this.uLabel_FindCondition.Width = this.tComboEditor_FindCondition.Width - GUIDE_WIDTH_DIFFERENCE - this.tEdit_FindConditionCodeType.Width - 3;

                    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT + CONDITION_PANEL_SECTION_ON;
                    }
                    else
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_DEFAULT;
                    }

                    // TEdit入力プロパティド変換処理
                    this.TEditChangeEdit(this.tEdit_FindConditionCodeType, mode);
                }
                // 仕入日
                // 計上日
                else if (( mode == EDIT_TYPE_InputDay ) ||
                        ( mode == EDIT_TYPE_StockDate ))
                {
                    tDateEdit_DateStaVisible = true;
                    tDateEdit_DateEndVisible = true;

                    this.uLabel_FindCondition.ContextMenu = null;
                    this.uLabel_FindCondition.Cursor = Cursors.Default;
                    this.toolTip_Hint.SetToolTip(this.uLabel_FindCondition, "");

                    this.uLabel_FindCondition.Appearance.BackColor = Color.White;
                    this.uLabel_FindCondition.Left = 10;

                    if (( secInfoSet != null ) && ( secInfoSet.MainOfficeFuncFlag == 1 ))
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_SLIPDATE + CONDITION_PANEL_SECTION_ON;
                    }
                    else
                    {
                        this.panel_Condition.Height = CONDITION_PANEL_HEIGHT_SLIPDATE;
                    }

                    this.tDateEdit_DateSta.Refresh();
                    this.tDateEdit_DateEnd.Refresh();
                }
            }
            finally
            {
                this.tEdit_FindCondition.Visible = tEdit_FindConditionVisible;
                this.tEdit_FindConditionCodeType.Visible = tEdit_FindConditionCodeTypeVisible;
                this.tNedit_FindCondition.Visible = tNedit_FindConditionVisible;
                this.tNedit_FindConditionCodeType.Visible = tNedit_FindConditionCodeTypeVisible;
                this.tDateEdit_DateSta.Visible = tDateEdit_DateStaVisible;
                this.tDateEdit_DateEnd.Visible = tDateEdit_DateEndVisible;
                this.uLabel_SlipDate.Visible = uLabel_SlipDateVisible;
                this.uButton_Guide.Visible = uButton_GuideVisible;
                this.uLabel_FindCondition.Visible = uLabel_FindConditionVisible;
                this.tNedit_SupplierCd.Visible = tNedit_SupplierCdVisible;
                this.uLabel_SupplierName.Visible = uLabel_SupplierNameVisible;
                this.tEdit_EmployeeCode.Visible = tEdit_EmployeeCdVisible;
                this.uLabel_EmployeeName.Visible = uLabel_EmployeeNameVisible;
                this.tEdit_PartySaleSlipNum.Visible = tEdit_PartySaleSlipNumVisible;
                this.tNedit_SupplierSlipNo_St.Visible = tNedit_SupplierSlipNoVisible;
                this.tNedit_SupplierSlipNo_Ed.Visible = tNedit_SupplierSlipNoVisible;
                this.ulabel_SupplierSlipNoCndtn.Visible = tNedit_SupplierSlipNoVisible;

                this.tEdit_FindCondition.EndUpdate();
                this.tEdit_FindConditionCodeType.EndUpdate();
                this.tNedit_FindCondition.EndUpdate();
                this.tNedit_FindConditionCodeType.EndUpdate();
                this.uLabel_SlipDate.EndUpdate();
                this.uButton_Guide.EndUpdate();
                this.uLabel_FindCondition.EndUpdate();
                this.tNedit_SupplierCd.EndUpdate();
                this.uLabel_SupplierName.EndUpdate();
                this.tEdit_EmployeeCode.EndUpdate();
                this.uLabel_EmployeeName.EndUpdate();
                this.tEdit_PartySaleSlipNum.EndUpdate();
                this.tNedit_SupplierSlipNo_St.EndUpdate();
                this.tNedit_SupplierSlipNo_Ed.EndUpdate();
                this.ulabel_SupplierSlipNoCndtn.EndUpdate();
            }
		}

		/// <summary>
		/// 検索タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_Search_Tick(object sender, System.EventArgs e)
		{
			this.timer_Search.Enabled = false;

			try
			{
				this.Cursor = Cursors.WaitCursor;

				// 仕入伝票検索パラメータクラス取得処理
				SearchParaStockSlip para = this.GetSearchParaStockSlip();

				// 仕入伝票検索パラメータクラスチェック処理
				if (!this.CheckSearchParaStockSlip(para)) return;
			
				this.customControl_ExtractWait.Visible = true;
				this.customControl_ExtractWait.mode = 0;
				this.customControl_ExtractWait.Top = this.uGrid_Search.Top + 60;
				this.customControl_ExtractWait.Refresh();

				// 仕入伝票検索処理
				this.Search(para);
			}
			finally
			{
				if (this.customControl_ExtractWait.mode == 0)
				{
					this.customControl_ExtractWait.Visible = false;
					this.Cursor = Cursors.Default;
				}
			}
		}

		/// <summary>
		/// 抽出ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_Find_Click(object sender, System.EventArgs e)
		{
			this.timer_Search.Enabled = true;
		}

		/// <summary>
		/// 検索結果グリッドエレメントマウスエンターイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Search_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			if ((this.ActiveControl != this.uGrid_Search) && (this.uGrid_Search.Rows.Count > 0))
			{
				this.uGrid_Search.Focus();
			}

			// 仕入伝票情報をポップアップ表示
			Infragistics.Win.UIElement element = e.Element;
			object oContextRow = null;
			object oContextCell = null;

			oContextRow = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));
			oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

			if (oContextCell != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;
				cell.Appearance.ForeColor = Color.Blue;
				cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True;
			}

			if (oContextRow != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridRow row =(Infragistics.Win.UltraWinGrid.UltraGridRow)oContextRow;

				this.uGrid_Search.ActiveRow = row;
				this.uGrid_Search.ActiveRow.Selected = true;

				string tipString = "";

				if (row.Cells[0] != null )
				{
					int totalLength = 16;

					// ブランク
					tipString += "　\r\n";
					// 仕入伝票番号
					tipString += SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Header.Caption, ' ') + "：" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Value.ToString();

                    // 仕入日
                    tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockDateColumn.ColumnName].Header.Caption, ' ') + "：" + string.Format("{0:yyyy/MM/dd}", (DateTime)row.Cells[this._searchSlipAcs.DataSet.StockSlip.StockDateColumn.ColumnName].Value);

					// 入荷日
                    tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName].Header.Caption, ' ') + "：" + string.Format("{0:yyyy/MM/dd}", (DateTime)row.Cells[this._searchSlipAcs.DataSet.StockSlip.ArrivalGoodsDayColumn.ColumnName].Value);

					// 計上日
                    tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName].Header.Caption, ' ') + "：" + string.Format("{0:yyyy/MM/dd}", (DateTime)row.Cells[this._searchSlipAcs.DataSet.StockSlip.StockAddUpADateColumn.ColumnName].Value);

					// 仕入担当
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockAgentNameColumn.ColumnName].Header.Caption, ' ') + "：" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.StockAgentNameColumn.ColumnName].Value.ToString();

					// 仕入先
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CustomerNameColumn.ColumnName].Header.Caption, ' ') + "：" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.CustomerNameColumn.ColumnName].Value.ToString();

					// 2007.10.12 sasaki >>
					//// 倉庫
					//tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.WarehouseNameColumn.ColumnName].Header.Caption, ' ') + "：" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.WarehouseNameColumn.ColumnName].Value.ToString();

					//// 事業者
					//tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.CarrierNameColumn.ColumnName].Header.Caption, ' ') + "：" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.CarrierNameColumn.ColumnName].Value.ToString();
					// 2007.10.12 sasaki <<

					// 相手先伝番
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Header.Caption, ' ') + "：" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Value.ToString();

					// セパレータ
					tipString += "\r\n";

					// 仕入形式
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierFomalNameColumn.ColumnName].Header.Caption, ' ') + "：" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.SupplierFomalNameColumn.ColumnName].Value.ToString();

					// 伝票区分
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Header.Caption, ' ') + "：" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Value.ToString();

					// 赤伝区分
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Header.Caption, ' ') + "：" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Value.ToString();

                    //// 商品区分
                    //tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Header.Caption, ' ') + "：" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Value.ToString();

                    //// 買掛区分
                    //tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.AccPayDivCdNameColumn.ColumnName].Header.Caption, ' ') + "：" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.AccPayDivCdNameColumn.ColumnName].Value.ToString();

					// セパレータ
					tipString += "\r\n";

					// 仕入金額
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.StockTotalPriceColumn.ColumnName].Header.Caption, ' ') + "：" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.StockTotalPriceColumn.ColumnName].Value.ToString() + "円";

					// セパレータ
					tipString += "\r\n";

					// 備考１
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote1Column.ColumnName].Header.Caption, ' ') + "：" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote1Column.ColumnName].Value.ToString();

					// 備考２
					tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, this.uGrid_Search.DisplayLayout.Bands[0].Columns[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote2Column.ColumnName].Header.Caption, ' ') + "：" + row.Cells[this._searchSlipAcs.DataSet.StockSlip.SupplierSlipNote2Column.ColumnName].Value.ToString();
				}

				Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
				ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
				ultraToolTipInfo.ToolTipTitle = "仕入伝票情報";
				ultraToolTipInfo.ToolTipText = tipString;

				this.uToolTipManager_Information.Appearance.FontData.Name = "ＭＳ ゴシック";
				this.uToolTipManager_Information.SetUltraToolTip(this.uGrid_Search, ultraToolTipInfo);
				this.uToolTipManager_Information.Enabled = true;

				return;
			}
		}

		/// <summary>
		/// 仕入伝票検索結果グリッドエレメントマウスリーヴイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Search_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			Infragistics.Win.UIElement element = e.Element;
			object oContextCell = null;

			oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

			if (oContextCell != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;
				cell.Appearance.ForeColor = this.uGrid_Search.DisplayLayout.Override.CellAppearance.ForeColor;
				cell.Appearance.FontData.Underline = this.uGrid_Search.DisplayLayout.Override.CellAppearance.FontData.Underline;
			}
		}

		/// <summary>
		/// 仕入伝票検索結果グリッドクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Search_Click(object sender, System.EventArgs e)
		{
		}

		/// <summary>
		/// アクティブタイマー起動処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_Activated_Tick(object sender, System.EventArgs e)
		{
			this.timer_Activated.Enabled = false;
			this.tComboEditor_SupplierFormal.Focus();
		}

		/// <summary>
		/// ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_Guide_Click(object sender, System.EventArgs e)
		{
			// コンボエディタ選択値取得処理(抽出条件区分)
			int findConditionCode = this.GetSelectedValue(this.tComboEditor_FindCondition);

			if (findConditionCode == EDIT_TYPE_StockAgentCode)				// 仕入担当
			{
				EmployeeAcs employeeAcs = new EmployeeAcs();
				Employee employee;
				int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    this.tEdit_EmployeeCode.Text = employee.EmployeeCode.Trim();
                    this.uLabel_EmployeeName.Text = employee.Name;
					this.uButton_Find_Click(this.uButton_Find, new EventArgs());
				}
			}
			else if (findConditionCode == EDIT_TYPE_GoodsCode)				// 商品コード
			{
				MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

				GoodsUnitData goodsUnitData;
				DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);

				if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
				{
					this.uLabel_FindCondition.Text = goodsUnitData.GoodsName;
					// 2007.10.12 sasaki >>
					//this.uLabel_FindCondition.Tag = goodsUnitData.MakerCode;
					//this.tEdit_FindConditionCodeType.Text = goodsUnitData.GoodsCode;
					this.uLabel_FindCondition.Tag = goodsUnitData.GoodsMakerCd;
					this.tEdit_FindConditionCodeType.Text = goodsUnitData.GoodsNo;					
					// 2007.10.12 sasaki <<
					this.uButton_Find_Click(this.uButton_Find, new EventArgs());
				}
			}
			else if (findConditionCode == EDIT_TYPE_CustomerCode)
			{
                // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //SFTOK01370UA customerSearchGuide = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
                //customerSearchGuide.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchGuide_CustomerSelect);
                //customerSearchGuide.ShowDialog(this);
                Supplier supplier;
                SupplierAcs supplierAcs = new SupplierAcs();
                int status = supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.SupplierSearchGuide_SupplierSelect(supplier);
                }
                // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			}
			else if (findConditionCode == EDIT_TYPE_WarehouseCode)
			{
				string sectionCode = this._ownSectionCode;

				if (this.tComboEditor_StockSectionCd.SelectedItem != null)
				{
					sectionCode = (string)this.tComboEditor_StockSectionCd.SelectedItem.DataValue;
				}

				Warehouse warehouse;
				int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode, sectionCode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					this.uLabel_FindCondition.Text = warehouse.WarehouseName;
					this.tEdit_FindConditionCodeType.Text = warehouse.WarehouseCode.Trim();
					this.uButton_Find_Click(this.uButton_Find, new EventArgs());
				}
			}
		}

		/// <summary>
		/// フォーカスコントロールイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

			switch (e.PrevCtrl.Name)
			{
				case "uButton_Find":
				{
					switch (e.Key)
					{
						case Keys.Return:
						{
							e.NextCtrl = e.PrevCtrl;

							this.uButton_Find_Click(this.uButton_Find, new EventArgs());

							break;
						}
						case Keys.Tab:
						{
							if (this.uGrid_Search.Rows.Count > 0)
							{
								e.NextCtrl = this.uGrid_Search;
							}
							else
							{
								e.NextCtrl = this.tComboEditor_FindCondition;
							}
							break;
						}
					}

					break;
				}
				case "tNedit_FindCondition":
				{
					if (e.Key == Keys.Return)
					{
						if (this.tNedit_FindCondition.GetInt() != 0)
						{
							this.uButton_Find_Click(this.uButton_Find, new EventArgs());
						}
					}

					break;
				}
                case "tEdit_EmployeeCode":
                {
                    
                    string employeeCode = this.tEdit_EmployeeCode.Text;
                    if (string.IsNullOrEmpty(employeeCode))
                    {
                        this.uLabel_EmployeeName.Text = "";
                    }
                    else
                    {
                        Employee employee;
                        int status = this._employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this.tEdit_EmployeeCode.Text = employee.EmployeeCode.Trim();
                            this.uLabel_EmployeeName.Text = employee.Name;
                            //if (this.uLabel_EmployeeName.Text.Length > 10) this.uLabel_EmployeeName.Text = this.uLabel_EmployeeName.Text.Substring(0, 10);

                            this.uButton_Find_Click(this.uButton_Find, new EventArgs());
                        }
                        else if (( status == (int)ConstantManagement.DB_Status.ctDB_EOF ) ||
                            ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ))
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "該当する担当者が存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            this.tEdit_EmployeeCode.Text = string.Empty;
                            this.tEdit_EmployeeCode.Select(0, this.tEdit_EmployeeCode.DataText.Length);
                            this.uLabel_EmployeeName.Text = "";
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "担当者情報の取得に失敗しました。",
                                status,
                                MessageBoxButtons.OK);

                            this.tEdit_EmployeeCode.Text = employeeCode;
                            this.tEdit_EmployeeCode.Select(0, this.tEdit_EmployeeCode.DataText.Length);
                            this.uLabel_EmployeeName.Text = "";
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                }
                case "tNedit_SupplierCd":
                {
                    int newCode = this.tNedit_SupplierCd.GetInt();
                    if (newCode == 0)
                    {
                        this.uLabel_SupplierName.Text = "";
                    }
                    else 
                    {
                        Supplier supplier;

                        int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, newCode);

                        if (( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ) && ( supplier != null ))
                        {
                            this.uLabel_SupplierName.Text = supplier.SupplierNm1 + "" + supplier.SupplierNm2;

                            if (this._searchParaStockSlip.SupplierCd != newCode)
                            {
                                this.uButton_Find_Click(this.uButton_Find, new EventArgs());
                            }
                        }
                        else if (( status == (int)ConstantManagement.DB_Status.ctDB_EOF ) ||
                            ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ))
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "該当する仕入先が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            this.tNedit_SupplierCd.SetInt(0);
                            this.tNedit_SupplierCd.Select(0, this.tNedit_SupplierCd.DataText.Length);
                            this.uLabel_SupplierName.Text = "";
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "仕入先情報の取得に失敗しました。",
                                status,
                                MessageBoxButtons.OK);

                            this.tNedit_SupplierCd.Select(0, this.tNedit_SupplierCd.DataText.Length);
                            this.uLabel_SupplierName.Text = "";

                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                }
				case "tNedit_FindConditionCodeType":
				{
					int mode = 0;
					if (this.tComboEditor_FindCondition.SelectedItem.DataValue is Int32)
					{
						mode = Convert.ToInt32(this.tComboEditor_FindCondition.SelectedItem.DataValue);
					}

					if (mode == EDIT_TYPE_CustomerCode)
					{
						if (this.tNedit_FindConditionCodeType.GetInt() == 0)
						{
							this.uLabel_FindCondition.Text = "";
						}
                        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //else if (this._searchParaStockSlip.CustomerCode != this.tNedit_FindConditionCodeType.GetInt())
                        else if (this._searchParaStockSlip.SupplierCd != this.tNedit_FindConditionCodeType.GetInt())
                        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
						{
							CustomerSearchPara customerSearchPara = new CustomerSearchPara();
							// 2008.05.22 Del >>>
							//customerSearchPara.SupplierDiv = 1;
							// 2008.05.22 Del <<<
							customerSearchPara.EnterpriseCode = this._enterpriseCode;
							customerSearchPara.CustomerCode = this.tNedit_FindConditionCodeType.GetInt();

							CustomerSearchRet[] customerSearchRetArray;
							int status = this._customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);

							if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (customerSearchRetArray.Length > 0))
							{
								this.uLabel_FindCondition.Text = customerSearchRetArray[0].Name + " " + customerSearchRetArray[0].Name2;
								this.uButton_Find_Click(this.uButton_Find, new EventArgs());
							}
							else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
								(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_INFO,
									this.Name,
									"該当する仕入先が存在しません。",
									-1,
									MessageBoxButtons.OK);

								this.tNedit_FindConditionCodeType.Select(0, this.tNedit_FindConditionCodeType.DataText.Length);
								this.uLabel_FindCondition.Text = "";
								e.NextCtrl = e.PrevCtrl;
							}
							else
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_STOPDISP,
									this.Name,
									"仕入先情報の取得に失敗しました。",
									status,
									MessageBoxButtons.OK);

								this.tNedit_FindConditionCodeType.Select(0, this.tNedit_FindConditionCodeType.DataText.Length);
								this.uLabel_FindCondition.Text = "";
								e.NextCtrl = e.PrevCtrl;
							}
						}
					}
                    //else if (mode == EDIT_TYPE_CarrierEpCode)
                    //{
                    //    // 仮・・・ガイドが完成次第組み込み
                    //}
					break;
				}
				case "tEdit_FindCondition":
				{
					if (e.Key == Keys.Return)
					{
						if (this.tEdit_FindCondition.Text != "")
						{
							this.uButton_Find_Click(this.uButton_Find, new EventArgs());
						}
					}

					break;
				}
				case "tEdit_FindConditionCodeType":
				{
					int mode = 0;
					if (this.tComboEditor_FindCondition.SelectedItem.DataValue is Int32)
					{
						mode = Convert.ToInt32(this.tComboEditor_FindCondition.SelectedItem.DataValue);

					}
					else if (mode == EDIT_TYPE_GoodsCode)
					{
						if (this.tEdit_FindConditionCodeType.Text == "")
						{
							this.uLabel_FindCondition.Text = "";
						}
						else if (this._searchParaStockSlip.GoodsNo != this.tEdit_FindConditionCodeType.Text)
						{
							List<GoodsUnitData> goodsUnitDataList;
							int status = this._goodsAcs.Read(this._enterpriseCode, this.tEdit_FindConditionCodeType.Text, out goodsUnitDataList);

							if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
							{
								string goodsName = goodsUnitDataList[0].GoodsName;
								
								if (goodsUnitDataList.Count > 1)
								{
									goodsName += " 他";
								}

								this.uLabel_FindCondition.Text = goodsName;
								this.uLabel_FindCondition.Tag = 0;

								this.uButton_Find_Click(this.uButton_Find, new EventArgs());
							}
							else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
								(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_INFO,
									this.Name,
									"該当する商品が存在しません。",
									-1,
									MessageBoxButtons.OK);

								this.tEdit_FindConditionCodeType.Select(0, this.tEdit_FindConditionCodeType.DataText.Length);
								this.uLabel_FindCondition.Text = "";
								e.NextCtrl = e.PrevCtrl;
							}
							else
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_STOPDISP,
									this.Name,
									"商品情報の取得に失敗しました。",
									status,
									MessageBoxButtons.OK);

								this.tEdit_FindConditionCodeType.Select(0, this.tEdit_FindConditionCodeType.DataText.Length);
								this.uLabel_FindCondition.Text = "";
								e.NextCtrl = e.PrevCtrl;
							}
						}
					}
					else if (mode == EDIT_TYPE_WarehouseCode)
					{
						if (this.tEdit_FindConditionCodeType.Text == "")
						{
							this.uLabel_FindCondition.Text = "";
						}
						else
						{
							string sectionCode = this._ownSectionCode;

							if (this.tComboEditor_StockSectionCd.SelectedItem != null)
							{
								sectionCode = (string)this.tComboEditor_StockSectionCd.SelectedItem.DataValue;
							}

							Warehouse warehouse;
							int status = this._warehouseAcs.Read(out warehouse, this._enterpriseCode, sectionCode, this.tEdit_FindConditionCodeType.Text);

							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							{
								this.uLabel_FindCondition.Text = warehouse.WarehouseName;
								this.uLabel_FindCondition.Tag = 0;

								this.uButton_Find_Click(this.uButton_Find, new EventArgs());
							}
							else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
								(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_INFO,
									this.Name,
									"該当する倉庫が存在しません。",
									-1,
									MessageBoxButtons.OK);

								this.tEdit_FindConditionCodeType.Select(0, this.tEdit_FindConditionCodeType.DataText.Length);
								this.uLabel_FindCondition.Text = "";
								e.NextCtrl = e.PrevCtrl;
							}
							else
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_STOPDISP,
									this.Name,
									"倉庫情報の取得に失敗しました。",
									status,
									MessageBoxButtons.OK);

								this.tEdit_FindConditionCodeType.Select(0, this.tEdit_FindConditionCodeType.DataText.Length);
								this.uLabel_FindCondition.Text = "";
								e.NextCtrl = e.PrevCtrl;
							}
						}
					}

					break;
				}
                case "tNedit_SupplierSlipNo_Ed":
                {
                    if (e.Key == Keys.Return)
                    {
                        if (this.tNedit_SupplierSlipNo_Ed.GetInt() != 0)
                        {
                            this.uButton_Find_Click(this.uButton_Find, new EventArgs());
                        }
                    }
                    break;
                }
				case "tDateEdit_DateEnd":
				{
					if (e.Key == Keys.Return)
					{
						if (this.tDateEdit_DateEnd.GetDateTime() != DateTime.MinValue)
						{
							this.uButton_Find_Click(this.uButton_Find, new EventArgs());
						}
					}

					break;
				}
				case "tComboEditor_FindCondition":
				{
					if (e.Key == Keys.Down)
					{
						if (this.tEdit_FindCondition.Visible)
						{
							e.NextCtrl = this.tEdit_FindCondition;
						}
						else if (this.tNedit_FindCondition.Visible)
						{
							e.NextCtrl = this.tNedit_FindCondition;
						}
						else if (this.tNedit_FindConditionCodeType.Visible)
						{
							e.NextCtrl = this.tNedit_FindConditionCodeType;
						}
					}

					break;
				}
                case "tEdit_PartySaleSlipNum":
                {
                    break;
                }
			}
		}

		/// <summary>
		/// 抽出条件数値入力エディタエンターイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tNedit_FindCondition_Enter(object sender, System.EventArgs e)
		{
			this.uLabel_FindCondition.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(227)), ((System.Byte)(156)));
			this.tNedit_FindCondition.Left = this.uLabel_FindCondition.Left + 1;
		}

		/// <summary>
		/// 抽出条件文字列入力エディタエンターイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tEdit_FindCondition_Enter(object sender, System.EventArgs e)
		{
			this.uLabel_FindCondition.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(227)), ((System.Byte)(156)));
			this.tEdit_FindCondition.Left = this.uLabel_FindCondition.Left + 1;
		}

		/// <summary>
		/// 抽出条件数値入力エディタリーヴイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tNedit_FindCondition_Leave(object sender, System.EventArgs e)
		{
			this.uLabel_FindCondition.Appearance.BackColor = Color.White;

			if (this.tNedit_FindCondition.NormalAppearance.TextHAlign == Infragistics.Win.HAlign.Right)
			{
				int left = this.uLabel_FindCondition.Width - this.tNedit_FindCondition.Width;
				if (left > this.uLabel_FindCondition.Left)
				{
					this.tNedit_FindCondition.Left = left;
				}
			}
			else
			{
				this.tNedit_FindCondition.Left = this.uLabel_FindCondition.Left + 1;
			}
		}

		/// <summary>
		/// 抽出条件文字列入力エディタリーヴイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tEdit_FindCondition_Leave(object sender, System.EventArgs e)
		{
			this.uLabel_FindCondition.Appearance.BackColor = Color.White;

			if (this.tEdit_FindCondition.NormalAppearance.TextHAlign == Infragistics.Win.HAlign.Right)
			{
				int left = this.uLabel_FindCondition.Width - this.tEdit_FindCondition.Width;
				if (left > this.uLabel_FindCondition.Left)
				{
					this.tEdit_FindCondition.Left = left;
				}
			}
			else
			{
				this.tEdit_FindCondition.Left = this.uLabel_FindCondition.Left + 1;
			}
		}

		/// <summary>
		/// 抽出条件ラベルクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uLabel_FindCondition_Click(object sender, System.EventArgs e)
		{
			if (this.tEdit_FindCondition.Visible)
			{
				this.tEdit_FindCondition.Focus();
			}
			else if (this.tNedit_FindCondition.Visible)
			{
				this.tNedit_FindCondition.Focus();
			}
			else if (this.tNedit_FindConditionCodeType.Visible)
			{
				this.tNedit_FindConditionCodeType.Focus();
			}
		}

		/// <summary>
		/// 検索結果グリッドマウスダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Search_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;

			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
			
			// マウスポインタがグリッドのどの位置にあるかを判定する
			Point point = System.Windows.Forms.Cursor.Position;
			point = targetGrid.PointToClient(point);
			Infragistics.Win.UIElement objElement = null;
			Infragistics.Win.UltraWinGrid.RowCellAreaUIElement element = null;

			objElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);

			element = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
				(typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

			// セル以外の場合は以下の処理をキャンセルする
			if(element == null)
			{
				return;
			}
			
			object oContextRow = null;

			oContextRow = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

			if (oContextRow == null)
			{
				return;
			}

			Infragistics.Win.UltraWinGrid.UltraGridRow row =(Infragistics.Win.UltraWinGrid.UltraGridRow)oContextRow;

			StockDataSet.StockSlipRow stockSlipRow = this._searchSlipAcs.DataSet.StockSlip.FindByStockRowNo(Convert.ToInt32(row.Cells[this._searchSlipAcs.DataSet.StockSlip.StockRowNoColumn.ColumnName].Value));

			SearchRetStockSlip searchRetStockSlip = this.CreateSearchRetStockSlip(stockSlipRow);

			if (this.SearchRetStockSlipSelected != null)
			{
				this.SearchRetStockSlipSelected(this, searchRetStockSlip);

				// パネル変更イベントコール処理
				this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_StockSlipLuncher);
			}
		}

		/// <summary>
		/// 仕入データクラス生成処理
		/// </summary>
		/// <param name="row">仕入データ行クラス</param>
		/// <returns>仕入データクラス</returns>
		private SearchRetStockSlip CreateSearchRetStockSlip(StockDataSet.StockSlipRow row)
		{
			SearchRetStockSlip searchRetStockSlip = new SearchRetStockSlip();
			//searchRetStockSlip.StockRowNo = row.StockRowNo;
			searchRetStockSlip.EnterpriseCode = row.EnterpriseCode;
			searchRetStockSlip.SectionCode = row.SectionCode;
			//searchRetStockSlip.SectionName = row.SectionName;
			searchRetStockSlip.SupplierSlipNo = row.SupplierSlipNo;
			searchRetStockSlip.StockAddUpADate = row.StockAddUpADate;
			searchRetStockSlip.ArrivalGoodsDay = row.ArrivalGoodsDay;
			searchRetStockSlip.StockAgentCode = row.StockAgentCode;
            searchRetStockSlip.StockDate = row.StockDate;
			searchRetStockSlip.StockAgentName = row.StockAgentName;
            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //searchRetStockSlip.CustomerCode = row.CustomerCode;
            //searchRetStockSlip.CustomerName = row.CustomerName;
            searchRetStockSlip.SupplierCd = row.CustomerCode;
            searchRetStockSlip.SupplierNm1 = row.CustomerName;
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			// 2007.10.12 sasaki >>
			//searchRetStockSlip.WarehouseCode = row.WarehouseCode;
			//searchRetStockSlip.WarehouseName = row.WarehouseName;
			// 2007.10.12 sasaki <<
			searchRetStockSlip.SupplierFormal = row.SupplierFomal;
			//searchRetStockSlip.SupplierFomalName = row.SupplierFomalName;
			searchRetStockSlip.SupplierSlipCd = row.SupplierSlipCd;
			//searchRetStockSlip.SupplierSlipCdName = row.SupplierSlipCdName;
			searchRetStockSlip.DebitNoteDiv = row.DebitNoteDiv;
			//searchRetStockSlip.DebitNoteDivName = row.DebitNoteDivName;
			searchRetStockSlip.StockGoodsCd = row.StockGoodsCd;
			//searchRetStockSlip.StockGoodsCdName = row.StockGoodsCdName;
			searchRetStockSlip.AccPayDivCd = row.AccPayDivCd;
			//searchRetStockSlip.AccPayDivCdName = row.AccPayDivCdName;
			// 2007.10.12 sasaki >>
			//searchRetStockSlip.CarrierEpCode = row.CarrierCode;
			//searchRetStockSlip.CarrierEpName = row.CarrierName;
			// 2007.10.12 sasaki <<
			searchRetStockSlip.InputDay = row.InputDay;
			searchRetStockSlip.StockTotalPrice = row.StockTotalPrice;
			searchRetStockSlip.StockSubttlPrice = row.StockSubttlPrice;
			searchRetStockSlip.PartySaleSlipNum = row.PartySaleSlipNum;
			searchRetStockSlip.SupplierSlipNote1 = row.SupplierSlipNote1;
			searchRetStockSlip.SupplierSlipNote2 = row.SupplierSlipNote2;
			return searchRetStockSlip;
		}

		/// <summary>
		/// グリッドフォントサイズコンボボックス選択値変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_GridFontSize_ValueChanged(object sender, System.EventArgs e)
		{
			if (this.tComboEditor_GridFontSize.Value is int)
			{
				int fontSize = (int)this.tComboEditor_GridFontSize.Value;

				if (fontSize != 0)
				{
					this.uGrid_Search.Font = new System.Drawing.Font("ＭＳ ゴシック", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
				}
			}
		}

		/// <summary>
		/// 数値入力エディタ入力値変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tNedit_FindCondition_ValueChanged(object sender, System.EventArgs e)
		{
			/*
			if (!this.tNedit_FindCondition.Modified)
			{
				return;
			}

			// コンボエディタ選択値取得処理(抽出条件区分)
			int findConditionCode = this.GetSelectedValue(this.tComboEditor_FindCondition);

			if (findConditionCode ==EDIT_TYPE_NumberPlate4)
			{
				if (this.tNedit_FindCondition.GetInt() != 0)
				{
					this.uCheckEditor_NumberPlate4.Checked = false;
				}
			}
			*/
		}

		/// <summary>
		/// メッセージ非表示タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_MessageUnDisp_Tick(object sender, System.EventArgs e)
		{
			this.timer_MessageUnDisp.Enabled = false;
			
			this.customControl_ExtractWait.Visible = false;
		}

		/// <summary>
		/// 検索結果グリッド行初期化イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Search_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
		{
			//e.Row.Cells[SEARCH_COL_AcptAnOdrStatusName].Appearance.ForeColor = this.GetKindCellForeColor(e.Row);
		}

		/// <summary>
		/// コンボエディタ選択確定後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_FindCondition_SelectionChangeCommitted(object sender, EventArgs e)
		{
			//
		}

        /// <summary>
        /// 伝票種別コンボエディタ変更時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SupplierFormal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int supplierFormal = this.GetSelectedValue(this.tComboEditor_SupplierFormal);
            this.SetItemtStockGoodsCd(supplierFormal);
            this.SetItemtSupplierSlipCd(supplierFormal);
        }


        /// <summary>
        /// 計上区分コンボエディタアイテム設定処理
        /// </summary>
        /// <param name="supplierFormal">仕入形式</param>
        private void SetItemtStockGoodsCd(int supplierFormal)
        {
            switch (supplierFormal)
            {
                case 0:
                    {
                        this.tComboEditor_StockGoodsCd.Items.Clear();

                        Infragistics.Win.ValueListItem item99 = new Infragistics.Win.ValueListItem();
                        item99.Tag = 1;
                        item99.DataValue = 99;
                        item99.DisplayText = "全て";
                        this.tComboEditor_StockGoodsCd.Items.Add(item99);

                        Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                        item0.Tag = 2;
                        item0.DataValue = 0;
                        item0.DisplayText = "明細";
                        this.tComboEditor_StockGoodsCd.Items.Add(item0);

                        //Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
                        //item2.Tag = 3;
                        //item2.DataValue = 2;
                        //item2.DisplayText = "消費税調整";
                        //this.tComboEditor_StockGoodsCd.Items.Add(item2);

                        //Infragistics.Win.ValueListItem item3 = new Infragistics.Win.ValueListItem();
                        //item3.Tag = 4;
                        //item3.DataValue = 3;
                        //item3.DisplayText = "残高調整";
                        //this.tComboEditor_StockGoodsCd.Items.Add(item3);

                        //Infragistics.Win.ValueListItem item4 = new Infragistics.Win.ValueListItem();
                        //item4.Tag = 5;
                        //item4.DataValue = 4;
                        //item4.DisplayText = "消費税調整(買掛用)";
                        //this.tComboEditor_StockGoodsCd.Items.Add(item4);

                        //Infragistics.Win.ValueListItem item5 = new Infragistics.Win.ValueListItem();
                        //item5.Tag = 6;
                        //item5.DataValue = 5;
                        //item5.DisplayText = "残高調整(買掛用)";
                        //this.tComboEditor_StockGoodsCd.Items.Add(item5);

                        Infragistics.Win.ValueListItem item6 = new Infragistics.Win.ValueListItem();
                        item6.Tag = 3;
                        item6.DataValue = 6;
                        item6.DisplayText = "合計";
                        this.tComboEditor_StockGoodsCd.Items.Add(item6);

                        this.tComboEditor_StockGoodsCd.Value = 99;

                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_StockGoodsCd.Items.Clear();

                        Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
                        item0.Tag = 1;
                        item0.DataValue = 0;
                        item0.DisplayText = "明細";
                        this.tComboEditor_StockGoodsCd.Items.Add(item0);

                        this.tComboEditor_StockGoodsCd.Value = 0;

                        break;
                    }
            }
        }

        /// <summary>
        /// 計上区分コンボエディタアイテム設定処理
        /// </summary>
        /// <param name="supplierFormal">仕入形式</param>
        private void SetItemtSupplierSlipCd(int supplierFormal)
        {
            //switch (supplierFormal)
            //{
            //    case 0:
            //        {
            //            this.tComboEditor_SupplierSlipCd.Items.Clear();

            //            Infragistics.Win.ValueListItem item99 = new Infragistics.Win.ValueListItem();
            //            item99.Tag = 1;
            //            item99.DataValue = 99;
            //            item99.DisplayText = "全て";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item99);

            //            Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
            //            item0.Tag = 2;
            //            item0.DataValue = 11;
            //            item0.DisplayText = "掛仕入";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item0);

            //            Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
            //            item2.Tag = 3;
            //            item2.DataValue = 21;
            //            item2.DisplayText = "掛返品";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item2);

            //            Infragistics.Win.ValueListItem item3 = new Infragistics.Win.ValueListItem();
            //            item3.Tag = 4;
            //            item3.DataValue = 10;
            //            item3.DisplayText = "現金仕入";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item3);

            //            Infragistics.Win.ValueListItem item4 = new Infragistics.Win.ValueListItem();
            //            item4.Tag = 5;
            //            item4.DataValue = 20;
            //            item4.DisplayText = "現金返品";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item4);

            //            this.tComboEditor_SupplierSlipCd.Value = 99;

            //            break;
            //        }
            //    case 1:
            //        {
            //            this.tComboEditor_SupplierSlipCd.Items.Clear();

            //            Infragistics.Win.ValueListItem item99 = new Infragistics.Win.ValueListItem();
            //            item99.Tag = 1;
            //            item99.DataValue = 99;
            //            item99.DisplayText = "全て";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item99);

            //            Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
            //            item0.Tag = 2;
            //            item0.DataValue = 11;
            //            item0.DisplayText = "掛仕入";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item0);

            //            Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
            //            item1.Tag = 3;
            //            item1.DataValue = 21;
            //            item1.DisplayText = "掛返品";
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item1);

            //            this.tComboEditor_SupplierSlipCd.Value = 99;

            //            break;
            //        }
            //}
        }

		# endregion
	}
}
