using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 在庫簡易検索フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 対象商品の在庫の検索行うＵＩフォームクラスです。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.09.29</br>
    /// <br>UpdateNote : 2016/06/02 3H 石雨静</br>
    /// <br>管理番号   : 11201042-00 中村オートパーツ㈱</br>
    /// <br>           : 拠点切替追加</br>
    /// </remarks>
	public partial class MAZAI04117U : Form
	{
		//================================================================================
		//  コンストラクタ
		//================================================================================
		#region Constructor
		/// <summary>
        /// 在庫簡易検索フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.09.29</br>
        /// <br>UpdateNote : 2016/06/02 3H 石雨静</br>
        /// <br>管理番号   : 11201042-00 中村オートパーツ㈱</br>
        /// <br>           : 拠点切替追加</br>
        /// </remarks>
		public MAZAI04117U()
		{
			InitializeComponent();

			if (LoginInfoAcquisition.Employee != null)
			{
				this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
				this._loginSectionCode = this._loginEmployee.BelongSectionCode.Trim();
			}
			
			// 各アクセスクラスのインスタンス化
            this._searchStockAcs = new SearchStockAcs(LoginInfoAcquisition.EnterpriseCode, this._loginSectionCode);

			this._gridStateController = new GridStateController();
			this._controlScreenSkin = new ControlScreenSkin();
            // --- ADD 3H 石雨静 2016/06/02 ---------->>>>>
            // 初期設定
            ultraLabel2.Text = "0";
            List<Control> ctrlList = new List<Control>();
            // 拠点切替区分
            ctrlList.Add(this.ultraLabel2);
            uiMemInput1.TargetControls = ctrlList;
            // --- ADD 3H 石雨静 2016/06/02 ----------<<<<<

		}
		#endregion

		// ===============================================================================
		// プライベートメンバー
		// ===============================================================================
		#region Private member

		// -------------------------------------------------------------------------------
		#region < 画面表示用 >
		/// <summary>イベントフラグ</summary>
		private bool _isEvent = false;
		private ImageList _imageList16;
		/// <summary>企業コード</summary>
		private string _enterpriseCode;
		/// <summary>ログイン従業員</summary>
		private Employee _loginEmployee;
		/// <summary>ログイン拠点コード</summary>
		private string _loginSectionCode = string.Empty;
        /// <summary>品番</summary>
        private string _goodsNo = string.Empty;
        /// <summary>メーカーコード</summary>
        private int _goodsMakerCd = 0;
		/// <summary>起動回数</summary>
		private int _initialCounter;
		/// <summary>スキン変更部品</summary>
		private ControlScreenSkin _controlScreenSkin;

		private delegate void settingHandler(int row);

		#endregion

		// -------------------------------------------------------------------------------
		#region < 抽出条件格納用 >

		/// <summary>指定された抽出条件</summary>
		private StockSearchPara _setSearchParam;

		#endregion

		// -------------------------------------------------------------------------------
		#region < アクセスクラス >

		/// <summary>在庫検索アクセスクラス</summary>
		private SearchStockAcs _searchStockAcs;

		#endregion

		// -------------------------------------------------------------------------------
		#region < グリッド関連用 >

		/// <summary>グリッド設定制御クラス</summary>
		private GridStateController _gridStateController;

		private DataSet _stockDataSet;

		private DataTable _stockDataTable;
		private DataView _stockDataView;

		private DataView _gridBindDataView;
        // --- ADD 3H 石雨静 2016/06/02 ---------->>>>>
        private List<String> _sectionCodeList;
        // --- ADD 3H 石雨静 2016/06/02 ----------<<<<<

		/// <summary>
		/// 選択グリッド行BackColor
		/// </summary>
		private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
		private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);

		#endregion

		// -------------------------------------------------------------------------------
		#region < 選択結果格納用バッファ >

		/// <summary>選択された在庫情報</summary>
		private List<Stock> _selStock;

		#endregion

		#endregion

		// ===============================================================================
		// プライベート定数
		// ===============================================================================
		#region Private Constant
		private const string CT_PGID = "MAZAI04110U";
		
		// グリッド初期フォントサイズ
		private const int CT_Default_FontSize = 11;

		// 最大表示行数
		private const int CT_MaxRowCount = 10000;


		// -------------------------------------------------------------------------------
		#region < ツールーバーボタン用 >
		/// <summary>選択</summary>
		private const string CT_BUTTONTOOL_Decision = "ButtonTool_Select";
		/// <summary>戻る</summary>
        private const string CT_BUTTONTOOL_Back = "ButtonTool_Back";
        // --- ADD 3H 石雨静 2016/06/02 ---------->>>>>
        /// <summary>拠点切替</summary>
        private const string CT_BUTTONTOOL_Search = "ButtonTool_SearchChange";
        // --- ADD 3H 石雨静 2016/06/02 ----------<<<<<

		#endregion

		#region < グリッド系関連の定数定義 >
		// -------------------------------------------------------------------------------
		#region < テーブル共通列定義 >

        private const string CT_Select              = "Select";                 // 選択用セル
        private const string CT_WarehouseCode = "WarehouseCode";                // 倉庫コード
        private const string CT_WarehouseName = "WarehouseName";                // 倉庫名称
        private const string CT_WarehouseShelfNo = "WarehouseShelfNo";          // 棚番
        private const string CT_ShipmentPosCnt = "ShipmentPosCnt";              // 現在庫数
        private const string CT_DuplicationShelfNo1 = "DuplicationShelfNo1";    // 重複棚番1
        private const string CT_DuplicationShelfNo2 = "DuplicationShelfNo2";    // 重複棚番2
        private const string CT_StockSearchRet = "Stock";                       // 選択用データ格納用
	
		#endregion

		#endregion

		#endregion

        // ===============================================================================
        // プライベートstruct
        // ===============================================================================
        # region Private Struct
        /// <summary>
        /// ヘッダ情報　構造体
        /// </summary>
        private struct HeaderInfo
        {
            # region [private fields]

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            private string _sectionCode;
            private string _sectionName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            private int _goodsMakerCd;
            private string _goodsNo;
            private string _goodsName;
            private string _goodsNameKana;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            private Int32 _goodsNoSrchTyp;
            private Int32 _goodsNameSrchTyp;
            private Int32 _goodsNameKanaSrchTyp;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            private int _bLGoodsCode;
            private string _bLGoodsCodeName;
            private string _warehouseCode;
            private string _warehouseName;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            private int _zeroStockDsp;
            private string _warehouseShelfNo;
            private Int32 _warehouseShelfNoSrchTyp;
            private Int32 _dateDiv;
            private int _stDate;
            private int _edDate;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            private string _makerName;
            private int _supplierCode;
            private string _supplierName;
            private int _enterpriseGanreCode;

            //  ** support for interchangeability ** 
            // 以下は画面上存在しないが、他アプリケーションからセットされるかもしれないので残しておく
            // 使用されないことが判明したら削除してください
            // 「** support for interchangeability **」タグで検索して削除できます

            //private string _enterpriseGanreName;
            //private string _largeGoodsGanreCode;
            //private string _largeGoodsGanreName;
            //private string _mediumGoodsGanreCode;
            //private string _mediumGoodsGanreName;
            //private string _detailGoodsGanreCode;
            //private string _detailGoodsGanreName;

            # endregion

            # region [public propaties]
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            /// <summary>拠点コード</summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>拠点名称</summary>
            public string SectionName
            {
                get { return _sectionName; }
                set { _sectionName = value; }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            /// <summary>メーカーコード</summary>
            public int GoodsMakerCd
            {
                get { return _goodsMakerCd; }
                set { _goodsMakerCd = value; }
            }
            /// <summary>品番</summary>
            public string GoodsNo
            {
                get { return _goodsNo; }
                set { _goodsNo = value; }
            }
            /// <summary>品名</summary>
            public string GoodsName
            {
                get { return _goodsName; }
                set { _goodsName = value; }
            }
            /// <summary>品名カナ</summary>
            public string GoodsNameKana
            {
                get { return _goodsNameKana; }
                set { _goodsNameKana = value; }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            /// <summary>品番検索タイプ</summary>
            public Int32 GoodsNoSrchTyp
            {
                get { return _goodsNoSrchTyp; }
                set { _goodsNoSrchTyp = value; }
            }
            /// <summary>品名検索タイプ</summary>
            public Int32 GoodsNameSrchTyp
            {
                get { return _goodsNameSrchTyp; }
                set { _goodsNameSrchTyp = value; }
            }
            /// <summary>品名カナ検索タイプ</summary>
            public Int32 GoodsNameKanaSrchTyp
            {
                get { return _goodsNameKanaSrchTyp; }
                set { _goodsNameKanaSrchTyp = value; }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            /// <summary>BLコード</summary>
            public int BLGoodsCode
            {
                get { return _bLGoodsCode; }
                set { _bLGoodsCode = value; }
            }
            /// <summary>BLコード名称</summary>
            public string BLGoodsCodeName
            {
                get { return _bLGoodsCodeName; }
                set { _bLGoodsCodeName = value; }
            }
            /// <summary>倉庫コード</summary>
            public string WarehouseCode
            {
                get { return _warehouseCode; }
                set { _warehouseCode = value; }
            }
            /// <summary>倉庫名称</summary>
            public string WarehouseName
            {
                get { return _warehouseName; }
                set { _warehouseName = value; }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            /// <summary>ゼロ在庫表示区分</summary>
            public Int32 ZeroStockDsp
            {
                get { return _zeroStockDsp; }
                set { _zeroStockDsp = value; }
            }
            /// <summary>棚番</summary>
            public string WarehouseShelfNo
            {
                get { return _warehouseShelfNo; }
                set { _warehouseShelfNo = value; }
            }
            /// <summary>棚番検索タイプ</summary>
            public Int32 WarehouseShelfNoSrchTyp
            {
                get { return _warehouseShelfNoSrchTyp; }
                set { _warehouseShelfNoSrchTyp = value; }
            }
            /// <summary>対象日付区分</summary>
            public Int32 DateDiv
            {
                get { return _dateDiv; }
                set { _dateDiv = value; }
            }
            /// <summary>開始対象日付</summary>
            public Int32 St_Date
            {
                get { return _stDate; }
                set { _stDate = value; }
            }
            /// <summary>終了対象日付</summary>
            public Int32 Ed_Date
            {
                get { return _edDate; }
                set { _edDate = value; }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // 以下はパラメータにはないが、前回使用情報ということでプロパティに持っておく

            /// <summary>メーカー名称</summary>
            public string MakerName
            {
                get { return _makerName; }
                set { _makerName = value; }
            }
            /// <summary>仕入先コード</summary>
            public int SupplierCode
            {
                get { return _supplierCode; }
                set { _supplierCode = value; }
            }
            /// <summary>仕入先名称</summary>
            public string SupplierName
            {
                get { return _supplierName; }
                set { _supplierName = value; }
            }
            /// <summary>自社分類コード</summary>
            public int EnterpriseGanreCode
            {
                get { return _enterpriseGanreCode; }
                set { _enterpriseGanreCode = value; }
            }

            // ** support for interchangeability **
            // 以下は互換性確保のために残しておく


            ///// <summary>自社分類名称</summary>
            //public string EnterpriseGanreName
            //{
            //    get { return _enterpriseGanreName; }
            //    set { _enterpriseGanreName = value; }
            //}
            ///// <summary>商品区分グループコード</summary>
            //public string LargeGoodsGanreCode
            //{
            //    get { return _largeGoodsGanreCode; }
            //    set { _largeGoodsGanreCode = value; }
            //}
            ///// <summary>商品区分グループ名称</summary>
            //public string LargeGoodsGanreName
            //{
            //    get { return _largeGoodsGanreName; }
            //    set { _largeGoodsGanreName = value; }
            //}
            ///// <summary>商品区分コード</summary>
            //public string MediumGoodsGanreCode
            //{
            //    get { return _mediumGoodsGanreCode; }
            //    set { _mediumGoodsGanreCode = value; }
            //}
            ///// <summary>商品区分名称</summary>
            //public string MediumGoodsGanreName
            //{
            //    get { return _mediumGoodsGanreName; }
            //    set { _mediumGoodsGanreName = value; }
            //}
            ///// <summary>商品区分詳細コード</summary>
            //public string DetailGoodsGanreCode
            //{
            //    get { return _detailGoodsGanreCode; }
            //    set { _detailGoodsGanreCode = value; }
            //}
            ///// <summary>商品区分詳細名称</summary>
            //public string DetailGoodsGanreName
            //{
            //    get { return _detailGoodsGanreName; }
            //    set { _detailGoodsGanreName = value; }
            //}
            # endregion
        }
        # endregion

        // ===============================================================================
		// 外部列挙型
		// ===============================================================================
		#region Public Enum


		#endregion

		// ===============================================================================
		// 外部プロパティ
		// ===============================================================================
		#region Public Property

		#endregion

		// ===============================================================================
		// 外部提供関数
		// ===============================================================================
		#region Public Method

		#region <  在庫検索ガイド >

		/// <summary>
		/// 在庫検索ガイド
		/// </summary>
		/// <param name="owner">オーナーフォーム</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsNo">商品コード</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="stock">在庫オブジェクト</param>
		/// <returns>DialogResult</returns>
        /// <remarks> 
        /// <br>UpdateNote : 2016/06/02 3H 石雨静</br>
        /// <br>管理番号   : 11201042-00 中村オートパーツ㈱</br>
        /// <br>           : 拠点切替追加</br>
        /// </remarks>
        public DialogResult ShowGuide( IWin32Window owner, string enterpriseCode, string goodsNo, int goodsMakerCd, out Stock stock )
		{
            stock = null;

            this._enterpriseCode = enterpriseCode;
            this._goodsNo = goodsNo;
            this._goodsMakerCd = goodsMakerCd;

			// 選択結果リスト初期化
            if (this._selStock == null)
                this._selStock = new List<Stock>();
            else
                this._selStock.Clear();
			
			// 抽出条件パラメータを設定する
            this._setSearchParam = this.GetSearchParameter();

            Infragistics.Win.UltraWinToolbars.ButtonTool decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Decision];
            Infragistics.Win.UltraWinToolbars.ButtonTool backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Back];
            // ADD 3H 石雨静 2016/06/02 ---------->>>>>
            // 拠点切替
            Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Search];
            searchButton.SharedProps.Visible = true;
            // ADD 3H 石雨静 2016/06/02 ----------<<<<<

            decisionButton.SharedProps.Visible = true;
            backButton.SharedProps.Visible = true;

			DialogResult dr = DialogResult.Cancel;

			dr = base.ShowDialog(owner);
            if (dr == DialogResult.OK)
            {
                if (this._selStock.Count > 0)
                {
                    stock = this._selStock[0];
                }
            }

			return dr;
		}
		
		#endregion

		#endregion

		//================================================================================
		//  内部関数
		//================================================================================
		#region Private Methods

		// --------------------------------------------------
		#region < 画面表示設定等 >

		/// <summary>
		/// コントロール表示制御
		/// </summary>
		/// <param name="visibled"></param>
		/// <param name="owner"></param>
		private void UnDisplayControl(bool visibled, Control owner)
		{

			for (int i = 0; i < owner.Controls.Count; i++)
			{
				// TEdit
				if (owner.Controls[i] is Broadleaf.Library.Windows.Forms.TEdit)
				{
					if (((Broadleaf.Library.Windows.Forms.TEdit)owner.Controls[i]).Tag != null)
					{
						if (((Broadleaf.Library.Windows.Forms.TEdit)owner.Controls[i]).Tag.ToString().Equals("False"))
						{
							continue;
						}
					}
					((Broadleaf.Library.Windows.Forms.TEdit)owner.Controls[i]).Visible = visibled;
				}
				// TDateEdit
				if (owner.Controls[i] is Broadleaf.Library.Windows.Forms.TDateEdit)
				{
					if (((Broadleaf.Library.Windows.Forms.TDateEdit)owner.Controls[i]).Tag != null)
					{
						if (((Broadleaf.Library.Windows.Forms.TDateEdit)owner.Controls[i]).Tag.ToString().Equals("False"))
						{
							continue;
						}
					}
					((Broadleaf.Library.Windows.Forms.TDateEdit)owner.Controls[i]).Visible = visibled;
				}
				// TComboEditor
				if (owner.Controls[i] is Broadleaf.Library.Windows.Forms.TComboEditor)
				{
					if (((Broadleaf.Library.Windows.Forms.TComboEditor)owner.Controls[i]).Tag != null)
					{
						if (((Broadleaf.Library.Windows.Forms.TComboEditor)owner.Controls[i]).Tag.ToString().Equals("False"))
						{
							continue;
						}
					}
					((Broadleaf.Library.Windows.Forms.TComboEditor)owner.Controls[i]).Visible = visibled;
				}
				// UltraOptionSet
				if (owner.Controls[i] is Infragistics.Win.UltraWinEditors.UltraOptionSet)
				{
					if (((Infragistics.Win.UltraWinEditors.UltraOptionSet)owner.Controls[i]).Tag != null)
					{
						if (((Infragistics.Win.UltraWinEditors.UltraOptionSet)owner.Controls[i]).Tag.ToString().Equals("False"))
						{
							continue;
						}
					}
					((Infragistics.Win.UltraWinEditors.UltraOptionSet)owner.Controls[i]).Visible = visibled;
				}
				// ListBox
				if (owner.Controls[i] is System.Windows.Forms.ListBox)
				{
					if (((System.Windows.Forms.ListBox)owner.Controls[i]).Tag != null)
					{
						if (((System.Windows.Forms.ListBox)owner.Controls[i]).Tag.ToString().Equals("False"))
						{
							continue;
						}
					}
					((System.Windows.Forms.ListBox)owner.Controls[i]).Visible = visibled;
				}
				// UltraButton
				if (owner.Controls[i] is Infragistics.Win.Misc.UltraButton)
				{
					if (((Infragistics.Win.Misc.UltraButton)owner.Controls[i]).Tag != null)
					{
						if (((Infragistics.Win.Misc.UltraButton)owner.Controls[i]).Tag.ToString().Equals("False"))
						{
							continue;
						}
					}
					((Infragistics.Win.Misc.UltraButton)owner.Controls[i]).Visible = visibled;
				}
				// UltraButton
				if (owner.Controls[i] is Infragistics.Win.Misc.UltraLabel)
				{
					if (((Infragistics.Win.Misc.UltraLabel)owner.Controls[i]).Tag != null)
					{
						if (((Infragistics.Win.Misc.UltraLabel)owner.Controls[i]).Tag.ToString().Equals("False"))
						{
							continue;
						}
					}
					((Infragistics.Win.Misc.UltraLabel)owner.Controls[i]).Visible = visibled;
				}
				// Form以外のコンテナ（Tab,Panel等）がある場合はその内部のコントロールも対象とする
				if (!(owner.Controls[i] is System.Windows.Forms.Form))
				{
					UnDisplayControl(visibled, owner.Controls[i]);
				}
			}
		}

		/// <summary>
		/// 画面初期化
		/// </summary>
		/// <param name="initMode">初期化モード[0:初回,1:取消,3:結果表示]</param>
		private void InitialDisplay(int initMode)
		{
            // 在庫テーブル
            if (this._stockDataTable != null)
                this._stockDataTable.Rows.Clear();
		}

		/// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールバーの初期設定を行います。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.09.29</br>
        /// <br>UpdateNote : 2016/06/02 3H 石雨静</br>
        /// <br>管理番号   : 11201042-00 中村オートパーツ㈱</br>
        /// <br>           : 拠点切替追加</br>
        /// </remarks>
		private void InitSettingToolBar()
		{

			this.Main_UToolbarsManager.ImageListSmall = this._imageList16;

			Infragistics.Win.UltraWinToolbars.ButtonTool decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Decision];
			if (decisionButton != null)
			{
				decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			}

			Infragistics.Win.UltraWinToolbars.ButtonTool backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Back];
			if (backButton != null)
			{
				backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
			}
            // --- ADD 3H 石雨静 2016/06/02 ---------->>>>>
            Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Search];
            if (searchButton != null)
            {
                searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            }
            // --- ADD 3H 石雨静 2016/06/02 ----------<<<<<
		}

		#endregion

		// --------------------------------------------------
		#region < DataSet, DataTable 作成 >

		/// <summary>
		/// データセット、データテーブル設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面用のデータセット、テーブルを作成します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.09.29</br>
        /// </remarks>
		private void SettingDataSet()
		{
			try
			{
				if (this._stockDataSet == null)
				{
					this._stockDataSet = new DataSet("StockDataSet");

					// 在庫テーブル作成
					CreateStockTable();

				}
				else
				{
                    if (this._stockDataTable != null)
                        this._stockDataTable.Rows.Clear();

				}
			}
			catch (Exception ex)
			{
				string errorMsg = (ex.InnerException == null) ? ex.Message : String.Format("{0}[{1}]", ex.Message, ex.InnerException.Message);
				TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, errorMsg, -1, MessageBoxButtons.OK);
			}
		}

		#region ●　在庫テーブル作成処理
		/// <summary>
		/// 在庫テーブル作成処理
		/// </summary>
        /// <remarks> 
        /// <br>UpdateNote : 2016/06/02 3H 石雨静</br>
        /// <br>管理番号   : 11201042-00 中村オートパーツ㈱</br>
        /// <br>           : 拠点切替追加</br>
        /// </remarks>
		private void CreateStockTable()
		{
			this._stockDataTable = new DataTable("StockDataTable");
			this._stockDataView = new DataView(this._stockDataTable);
            this._gridBindDataView = new DataView(this._stockDataTable);
            // --- ADD 3H 石雨静 2016/06/02 ---------->>>>>
            // 全社拠点
            this._sectionCodeList = new List<string>();
            // --- ADD 3H 石雨静 2016/06/02 ----------<<<<<

            // 選択用のセル
            DataColumn Select = new DataColumn(CT_Select, typeof(bool), "", MappingType.Element);
            Select.Caption = "";

            // 列設定を追加

            // 倉庫コード
            DataColumn WarehouseCode = new DataColumn(CT_WarehouseCode, typeof(string), "", MappingType.Element);
            WarehouseCode.Caption = "コード";

            // 倉庫名称
            DataColumn WarehouseName = new DataColumn(CT_WarehouseName, typeof(string), "", MappingType.Element);
            WarehouseName.Caption = "倉庫名";

            // 棚番
            DataColumn WarehouseShelfNo = new DataColumn(CT_WarehouseShelfNo, typeof(string), "", MappingType.Element);
            WarehouseShelfNo.Caption = "棚番";

            // 現在庫数(出荷可能数)
            DataColumn ShipmentPosCnt = new DataColumn(CT_ShipmentPosCnt, typeof(Double), "", MappingType.Element);
            ShipmentPosCnt.Caption = "現在庫数";

            // 重複棚番1
            DataColumn DuplicationShelfNo1 = new DataColumn(CT_DuplicationShelfNo1, typeof(string), "", MappingType.Element);
            DuplicationShelfNo1.Caption = "重複棚番1";

            // 重複棚番2
            DataColumn DuplicationShelfNo2 = new DataColumn(CT_DuplicationShelfNo2, typeof(string), "", MappingType.Element);
            DuplicationShelfNo2.Caption = "重複棚番2";

            // 選択用データ格納
            DataColumn Stock = new DataColumn(CT_StockSearchRet, typeof(Stock), "", MappingType.Element);

			this._stockDataTable.Columns.AddRange(new DataColumn[]{
                Select,
                WarehouseCode,
                WarehouseName,
                WarehouseShelfNo,
                ShipmentPosCnt,
                DuplicationShelfNo1,
                DuplicationShelfNo2,
                Stock
		  });
			this._stockDataSet.Tables.Add(this._stockDataTable);

			// 在庫データ表示順を設定する
            this._stockDataView.Sort = CT_WarehouseCode;


		}

		#endregion

        #endregion

        // --------------------------------------------------
		#region < UltraGrid関連の処理 >

		#region ◆　グリッド共通レイアウト設定
		/// <summary>
		/// グリッド共通レイアウト設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : グリッド共通のレイアウト設定を行います。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.09.29</br>
        /// </remarks>
		private void InitializeLayoutGridCommon(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid grid = sender as Infragistics.Win.UltraWinGrid.UltraGrid;
			if (grid == null) return;
            
			// スクロールバースタイル
			e.Layout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			e.Layout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;

			// 列ヘッダの表示スタイル
			e.Layout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Default;

			// セルの境界線スタイルの設定 
			e.Layout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Default;

			// 行の境界線スタイルの設定 
			e.Layout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Default;

            // 列の自動サイ調整
            e.Layout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

			// データ行の追加許可
			e.Layout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			// データ行の削除許可
			e.Layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			// データ行の更新許可
			e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;

			// 列移動の変更
			e.Layout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.Default;
			
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 固定列ヘッダ
            //e.Layout.UseFixedHeaders = false;
            e.Layout.UseFixedHeaders = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// セルクリック時実行アクション
			e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Default;

			//// ActiveCellの外観設定
			//e.Layout.Override.ActiveCellAppearance.BackColor = Color.FromArgb(247, 227, 156);

			//// ヘッダーの外観設定
			//e.Layout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
			//e.Layout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			//e.Layout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			//e.Layout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
			//e.Layout.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
			//e.Layout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

			//if (e.Layout.Bands.Count > 1)
			//{
			//  e.Layout.Bands[1].Override.HeaderAppearance.BackColor = Color.FromArgb(247, 247, 249);
			//  e.Layout.Bands[1].Override.HeaderAppearance.BackColor2 = Color.FromArgb(168, 167, 191);
			//  e.Layout.Bands[1].Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			//  e.Layout.Bands[1].Override.HeaderAppearance.ForeColor = System.Drawing.Color.Black;
			//  e.Layout.Bands[1].Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
			//  e.Layout.Bands[1].Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			//}

			// ヘッダクリックアクションの設定
			e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;

			//// 行の外観設定
			//e.Layout.Override.RowAppearance.BackColor = Color.White;
			//e.Layout.Override.RowAppearance.BorderColor = Color.FromArgb(1, 68, 208);

			//// セルの外観設定
			//e.Layout.Override.CellAppearance.ForeColorDisabled = Color.Black;

			// 1行おきの外観設定
			e.Layout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

			// 行セレクターの表示非表示
			e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

			//// 行セレクターの外観設定
			//e.Layout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
			//e.Layout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			//e.Layout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			//e.Layout.Override.RowSelectorAppearance.ForeColor = System.Drawing.Color.White;

			//if (e.Layout.Bands.Count > 1)
			//{
			//  e.Layout.Bands[1].Override.RowSelectorAppearance.BackColor = Color.FromArgb(247, 247, 249);
			//  e.Layout.Bands[1].Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(168, 167, 191);
			//  e.Layout.Bands[1].Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			//  e.Layout.Bands[1].Override.RowSelectorAppearance.ForeColor = System.Drawing.Color.Black;
			//}


			// 行選択設定 行選択無しモード(アクティブのみ)
			e.Layout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
			e.Layout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
			e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
			
			//// 選択行の外観設定
			//e.Layout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
			//e.Layout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
			//e.Layout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			//// 行選択時は、全ての列の文字色は黒とする(この記述ないと白色になって見難いとの批判があったため。)
			//e.Layout.Override.SelectedRowAppearance.ForeColor = Color.Black;

			// 行フィルターの設定
			//e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
			e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

			// テキストのレンタリング設定
			e.Layout.Override.CellAppearance.TextTrimming = Infragistics.Win.TextTrimming.Character;

		}

		#endregion

		#region ◆　グリッドの列設定
		/// <summary>
		/// 在庫グリッドの列設定
		/// </summary>
		/// <remarks>
		/// <br>Note      : グリッドの列設定を行います。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.09.29</br>
        /// </remarks>
		private void SettingStockGridColumns()
		{
			// バンドを取得
            Infragistics.Win.UltraWinGrid.UltraGridBand band0 = this.uGrid_SearchResult.DisplayLayout.Bands[0];
			Infragistics.Win.UltraWinGrid.ColumnsCollection clmns0 = band0.Columns;

			// 列の表示・非表示制御
			for (int i = 0; i < band0.Columns.Count; i++)
			{
				// アクティブ時動作 
				band0.Columns[i].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
				// セルクリック時のアクション
				band0.Columns[i].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
				band0.Columns[i].Hidden = true;
                // 固定列クリップボタンを表示しない
                band0.Columns[i].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;


				switch (band0.Columns[i].Key)
				{
                    case CT_WarehouseCode:              // 倉庫コード
                    case CT_WarehouseName:              // 倉庫名称
                    case CT_WarehouseShelfNo:           // 棚番
                    case CT_ShipmentPosCnt:             // 現在庫数
                    case CT_DuplicationShelfNo1:        // 重複棚番1
                    case CT_DuplicationShelfNo2:        // 重複棚番2
                        {
                            band0.Columns[i].Hidden = false;
                            break;
                        }
                    default:
                        // セル非表示
                        band0.Columns[i].Hidden = true;
                        break;
				}
			}

            //---------------------------------------------------------------------
            //  固定列
            //---------------------------------------------------------------------
            // 固定列区切り線設定
            this.uGrid_SearchResult.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_SearchResult.DisplayLayout.Override.HeaderAppearance.BackColor2;

			//---------------------------------------------------------------------
			//　列幅
			//---------------------------------------------------------------------
            // 列幅は仕様書のイメージより
            clmns0[CT_WarehouseCode].Width = 75;        //
            clmns0[CT_WarehouseName].Width = 180;       //
            clmns0[CT_WarehouseShelfNo].Width = 95;     //
            clmns0[CT_ShipmentPosCnt].Width = 110;       //
            clmns0[CT_DuplicationShelfNo1].Width = 115;  //
            clmns0[CT_DuplicationShelfNo2].Width = 115;  //


			////---------------------------------------------------------------------
			////　列幅の固定
			////---------------------------------------------------------------------
			//clmns0[CT_ProductButton].LockedWidth = true;
			//clmns0[CT_SelectButton].LockedWidth = true;

			//---------------------------------------------------------------------
			//　テキストの表示位置
			//---------------------------------------------------------------------
            clmns0[CT_WarehouseCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_WarehouseName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_WarehouseShelfNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_ShipmentPosCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_DuplicationShelfNo1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_DuplicationShelfNo2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            //---------------------------------------------------------------------
            //　フォーマットの設定
            //---------------------------------------------------------------------
            string decimalFormat = "#,##0.00;-#,##0.00;'0.00'";
            string longformat = "#,##0;";

            clmns0[CT_ShipmentPosCnt].Format = decimalFormat;
        }

        #endregion

		#region ◆　選択・非選択変更処理

		/// <summary>
		/// 選択・非選択変更処理
		/// </summary>
		/// <param name="isSelected">[T:選択,F:非選択]</param>
		/// <param name="gridRow">対象のグリッド行</param>
		private void ChangedSelect(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
		{
			if (gridRow == null) return;

			// 対象行の選択色を設定する
			if (isSelected)
			{
				gridRow.Appearance.BackColor = _selectedBackColor;
				gridRow.Appearance.BackColor2 = _selectedBackColor2;
				gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			}
			else
			{
				if (gridRow.Index % 2 == 1)
					gridRow.Appearance.BackColor = Color.Lavender;
				else
					gridRow.Appearance.BackColor = Color.White;
				gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			}

			// 選択・非選択
            gridRow.Cells[CT_Select].Value = isSelected;
		}

		#endregion

		#region ◆　グリッドの描画処理
		/// <summary>
		/// グリッドのセッティング描画処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : グリッド全体のセルスタイル・文字色を設定する。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.09.29</br>
        /// </remarks>
		private void SettingGridRowEditor()
		{
            int cnt = this.uGrid_SearchResult.Rows.Count;

			if (this.InvokeRequired == false)
			{
				// 描画を一時停止
                this.uGrid_SearchResult.BeginUpdate();
				try
				{
					for (int i = 0; i < cnt; i++)
					{
						SettingGridRowEditor(i);
					}
				}
				finally
				{
					// 描画を開始
					this.uGrid_SearchResult.EndUpdate();
				}
			}
			else
			{
				settingHandler _setting = new settingHandler(SettingGridRowEditor);
				for (int i = 0; i < cnt; i++)
				{
					Object[] pList = { i };
					this.BeginInvoke(_setting, pList);
				}

			}
		}

		/// <summary>
		/// 表示グリッド行単位でのセル描画処理
		/// </summary>
		/// <param name="row">指定行</param>
		/// <remarks>
		/// <br>Note       : グリッド全体のセルスタイル・文字色を設定する。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.09.29</br>
        /// </remarks>
		private void SettingGridRowEditor(int row)
		{

		
		}
		#endregion

		#region ◆　グリッドキーマッピング設定
		/// <summary>
		/// グリッドのキーマッピングを設定します。
		/// </summary>
		/// <param name="grid">設定対象のグリッド</param>
		/// <remarks>
		/// <br>Note       : グリッドに追加キーをマッピングします</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.09.29</br>
        /// </remarks>
		private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
		{
			Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

			//----- Enterキー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Enter,
				Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
				Infragistics.Win.SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			//----- Shift + Enterキー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Enter,
				Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
				Infragistics.Win.SpecialKeys.AltCtrl,
				Infragistics.Win.SpecialKeys.Shift);
			grid.KeyActionMappings.Add(enterMap);

			//----- ↑キー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Up,
				Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
				Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			//----- ↓キー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Down,
				Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
				Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			//----- 前頁キー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Prior,
				Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			//----- 次頁キー
			enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
				Keys.Next,
				Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
				0,
				Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
				Infragistics.Win.SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

		}
		#endregion

		#endregion

		// --------------------------------------------------
		#region < 抽出条件関連の処理 >

		/// <summary>
		/// 検索条件取得処理
		/// </summary>
		/// <returns>検索条件マスタ</returns>
		/// <remarks>
		/// <br>Note		: 画面から検索パラメータを取得します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.09.29</br>
        /// </remarks>
		private StockSearchPara GetSearchParameter()
		{
			StockSearchPara stockSearchPara = new StockSearchPara();

			// 企業コード
			stockSearchPara.EnterpriseCode = this._enterpriseCode;

			// メーカーコード
            stockSearchPara.GoodsMakerCd = this._goodsMakerCd;
            
			// 品番
            stockSearchPara.GoodsNoSrchTyp = 0; // 完全一致
            stockSearchPara.GoodsNo = this._goodsNo;
;

			return stockSearchPara;
		}

		#endregion

		// --------------------------------------------------
		#region < 検索処理 >

		/// <summary>
		/// 検索メイン処理
		/// </summary>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note		: 検索のメイン処理です。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.09.29</br>
        /// <br>UpdateNote : 2016/06/02 3H 石雨静</br>
        /// <br>管理番号   : 11201042-00 中村オートパーツ㈱</br>
        /// <br>           : 拠点切替追加</br>
        /// </remarks>
        private int SearchMainProc( StockSearchPara searchPara )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            System.Windows.Forms.Application.DoEvents();

            // 共通処理中画面生成
            SFCMN00299CA progressForm = new SFCMN00299CA();
            progressForm.DispCancelButton = false;
            progressForm.Title = "データ抽出中";
            progressForm.Message = "現在、データ抽出中です．．．";

            try
            {
                // 検索処理
                string msg;
                List<Stock> retStockList;

                try
                {
                    progressForm.Show(this);

                    status = this._searchStockAcs.Search(searchPara, out retStockList, out msg);

                    // 抽出結果をクリア
                    this._stockDataTable.Rows.Clear();
                }
                finally
                {
                    // 共通処理中画面終了
                    progressForm.Close();
                }

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // 検索モード設定
                            status = this.SetStockDataTable(retStockList, out msg);
                            switch (status)
                            {
                                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                    // --- ADD 3H 石雨静 2016/06/02 ---------->>>>>
                                    // データ切替
                                    setGridChange();
                                    // --- ADD 3H 石雨静 2016/06/02 ----------<<<<<
                                    break;
                                case (int)ConstantManagement.MethodResult.ctFNC_WARNING:
                                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, 0, MessageBoxButtons.OK);
                                    break;
                                default:
                                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, msg, 0, MessageBoxButtons.OK);
                                    break;

                            }

                            this.ColReSize_Timer.Enabled = true;

                            if (this._stockDataView.Count == 0)
                            {
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, "該当する在庫が見つかりませんでした。", 0, MessageBoxButtons.OK);
                            }
                            else
                            {
                            }

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, "該当する在庫が見つかりませんでした。", 0, MessageBoxButtons.OK);
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, msg, status, MessageBoxButtons.OK);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, ex.Message, status, MessageBoxButtons.OK);
            }

            return status;
        }

		/// <summary>
		/// 在庫データテーブル設定処理
		/// </summary>
		/// <param name="stockList">在庫クラスリスト</param>
		/// <param name="msg">エラーメッセージ</param>
        /// <remarks> 
        /// <br>UpdateNote : 2016/06/02 3H 石雨静</br>
        /// <br>管理番号   : 11201042-00 中村オートパーツ㈱</br>
        /// <br>           : 拠点切替追加</br>
        /// </remarks>
		private int SetStockDataTable(List<Stock> stockList, out string msg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			msg = "";

			if (stockList == null) return 0;
			if (stockList.Count == 0) return 0;

			this._stockDataTable.BeginLoadData();

			try
			{
				foreach (Stock stock in stockList)
				{

                    //if (this._stockDataTable.Rows.Count >= CT_MaxRowCount)
                    //{
                    //    msg = "表示最大行数になりました。検索条件を絞って検索して下さい";
                    //    status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                    //    return status;
                    //}
					
					DataRow row = this._stockDataTable.NewRow();

					// 列選択
					row[CT_Select] = false;

                    row[CT_WarehouseName] = stock.WarehouseName;              // 倉庫名
                    row[CT_WarehouseCode] = stock.WarehouseCode;              // 倉庫コード
                    row[CT_WarehouseShelfNo] = stock.WarehouseShelfNo;        // 棚番
                    row[CT_ShipmentPosCnt] = stock.ShipmentPosCnt;            // 出荷可能数
                    row[CT_DuplicationShelfNo1] = stock.DuplicationShelfNo1;  // 棚番1
                    row[CT_DuplicationShelfNo2] = stock.DuplicationShelfNo2;  // 棚番2

					// 選択用在庫データ格納
                    row[CT_StockSearchRet] = stock.Clone();

                    this._stockDataTable.Rows.Add(row);
                    // --- ADD 3H 石雨静 2016/06/02 ---------->>>>>
                    // 全社拠点
                    this._sectionCodeList.Add(stock.SectionCode);
                    // --- ADD 3H 石雨静 2016/06/02 ----------<<<<<

				}
                
				status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			catch (Exception ex)
			{
				msg = "在庫テーブル作成中にて例外が発生しました[" + ex.Message + "]";
			}
			finally
			{
				this._stockDataTable.EndLoadData();
			}

			return status;
		}

		/// <summary>
		/// 在庫リスト取得
		/// </summary>
        /// <remarks>呼び出し元がすべてコメントアウトされているので、使われていない？</remarks>
		/// <returns></returns>
		private List<StockExpansion> GetStockListDataTable()
		{
			List<StockExpansion> retList = new List<StockExpansion>();

			try
			{
				if (this._stockDataView.Count > 0)
				{
					for (int i = 0; i < this._stockDataView.Count; ++i)
					{
                        StockExpansion stock = this._stockDataView[i].Row[CT_StockSearchRet] != DBNull.Value ? ( ( StockExpansion ) this._stockDataView[i].Row[CT_StockSearchRet] ).Clone() : null;
						if (stock != null)
							retList.Add(stock);
					}
				}

			}
			catch (Exception)
			{
			}
			return retList;
            //return retListStk;
        }

        /// <summary>
		/// 検索結果データ選択処理
		/// </summary>
		/// <param name="selRow">選択された対象行</param>
		private void SelectRowData(Infragistics.Win.UltraWinGrid.UltraGridRow selRow)
		{
			if (selRow == null) return;

            if (this._selStock == null)
                this._selStock = new List<Stock>();

            Stock retStock = ( selRow.Cells[CT_StockSearchRet].Value != DBNull.Value ) ? (Stock)selRow.Cells[CT_StockSearchRet].Value : null;

            // 選択した行を選択在庫情報の追加
            this._selStock.Add(retStock.Clone());
        }

		#endregion

		#endregion

		// ===============================================================================
		// コントロールイベント
		// ===============================================================================
		#region Control Event

		#region < Form_Loadイベント >

		/// <summary>
		/// 画面ロードイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note        : 画面がロードされた際、発生するイベントです。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.09.29</br>
        /// <br>UpdateNote : 2016/06/02 3H 石雨静</br>
        /// <br>管理番号   : 11201042-00 中村オートパーツ㈱</br>
        /// <br>           : 拠点切替追加</br>
        /// </remarks>
		private void MAZAI04117U_Load(object sender, EventArgs e)
		{
			this._isEvent = false;

			// 初回起動時のみ
			if (this._initialCounter == 0)
			{
				// 画面のスキンを設定する
				this._controlScreenSkin.LoadSkin();

				this._controlScreenSkin.SettingScreenSkin(this);

				// アイコンイメージリストの設定
				this._imageList16 = IconResourceManagement.ImageList16;

				// ツールバーの初期設定
				this.InitSettingToolBar();

				// キーマッピングの設定
				this.MakeKeyMappingForGrid(this.uGrid_SearchResult);
                // --- ADD 3H 石雨静 2016/06/02 ---------->>>>>
                // 前回値の読込
                this.uiMemInput1.ReadMemInput();
                // --- ADD 3H 石雨静 2016/06/02 ----------<<<<<

			}
			
			// グリッドのバインドを解除しておく
			this.uGrid_SearchResult.DataSource = null;

			this.Initial_Timer.Enabled = true;
		}

		#endregion

		#region < FormClosedイベント >

		/// <summary>
		/// 画面Closedイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note        : 画面が閉じられた後、発生するイベントです。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.09.29</br>
        /// </remarks>
		private void MAZAI04117U_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
			}
			catch (Exception)
			{
			}
		}

		#endregion

		#region < Timerイベント >

		/// <summary>
		/// 起動タイマーイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
        /// <remarks> 
        /// <br>UpdateNote : 2016/06/02 3H 石雨静</br>
        /// <br>管理番号   : 11201042-00 中村オートパーツ㈱</br>
        /// <br>           : 拠点切替追加</br>
        /// </remarks>
		private void Initial_Timer_Tick(object sender, EventArgs e)
		{
			this.Initial_Timer.Enabled = false;

			try
			{
				// バインドをはずす
				this.uGrid_SearchResult.DataSource = null;
				
				// 初回起動時のみ処理を行います
				if (this._initialCounter == 0)
				{
				}

				// データセット・データテーブルの作成
				this.SettingDataSet();

				// グリッドにデータビューをバインドする
				this.uGrid_SearchResult.DataSource = this._gridBindDataView;
  
				// グリッド列設定
                this.SettingStockGridColumns();

				// グリッド設定情報取得
				GridStateController.GridStateInfo gridStateInfo =
					this._gridStateController.GetGridStateInfo(ref this.uGrid_SearchResult);

				if (gridStateInfo != null)
				{
					// グリッドに設定
					this._gridStateController.SetGridStateToGrid(ref this.uGrid_SearchResult);
				}
				else
				{
				}
				
				// 抽出条件を画面に設定
                this._setSearchParam = this.GetSearchParameter();

                // 検索処理
                int status = this.SearchMainProc(this._setSearchParam);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.uGrid_SearchResult.Focus();
                    // --- ADD 3H 石雨静 2016/06/02 ---------->>>>>
                    if (this._gridBindDataView.Count != 0)
                    {
                        // --- ADD 3H 石雨静 2016/06/02 ----------<<<<<
                        this.uGrid_SearchResult.Rows[0].Activate();
                        this.uGrid_SearchResult.Rows[0].Selected = true; ;
                    } // --- ADD 3H 石雨静 2016/06/02
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    this.Close();
                }


				// 起動回数カウントアップ
				this._initialCounter++;
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, ex.Message + "\n\r" + ex.StackTrace, -1, MessageBoxButtons.OK);
			}
			finally
			{
				this._isEvent = true;
			}
		}

		/// <summary>
		/// グリッドリサイズタイマーイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
		private void ColReSize_Timer_Tick(object sender, EventArgs e)
		{
			this.ColReSize_Timer.Enabled  = false;

			this.uGrid_SearchResult.Refresh();
		}


		#endregion

        #region < UltraGrid系のイベント関連 >

        /// <summary>
        /// グリッドレイアウト初期化 イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void uGrid_SearchResult_InitializeLayout( object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e )
        {
            this.InitializeLayoutGridCommon(this.uGrid_SearchResult, e);
        }

        /// <summary>
        /// グリッドクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void uGrid_SearchResult_Click( object sender, EventArgs e )
        {
            // イベントソースの取得
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            try
            {
                // マウスポインタがグリッドのどの位置にあるかを判定する
                Point point = System.Windows.Forms.Cursor.Position;
                point = targetGrid.PointToClient(point);

                // UIElementを取得する。
                Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
                if (objUIElement == null)
                    return;

                // マウスポインターが列のヘッダ上にあるかチェック。
                Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
                    (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

                if (objHeader != null) return;

                // マウスポインターが行の上にあるかチェック。
                Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
                    (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

                if (objRow == null) return;

                // マウスポインターが行の上にあるかチェック。
                Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                    (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

                // 選択・非選択セル以外はキャンセル
                if (objCell == null || objCell.Column.Key != CT_Select) return;

                bool isSelected = (bool)objRow.Cells[CT_Select].Value;

                // 選択・非選択状態を変更します
                this.ChangedSelect(!isSelected, objRow);
            }
            catch
            {
            }
        }

        /// <summary>
        /// グリッドダブルクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void uGrid_SearchResult_DoubleClick( object sender, EventArgs e )
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスが入った最後の要素を取得します。
            Infragistics.Win.UIElement lastElementEntered = targetGrid.DisplayLayout.UIElement.LastElementEntered;

            // チェーン内に RowUIElement があるかどうかを調べます。
            Infragistics.Win.UltraWinGrid.RowUIElement rowElement;
            if (lastElementEntered is Infragistics.Win.UltraWinGrid.RowUIElement)
                rowElement = (Infragistics.Win.UltraWinGrid.RowUIElement)lastElementEntered;
            else
            {
                rowElement = (Infragistics.Win.UltraWinGrid.RowUIElement)lastElementEntered.GetAncestor(typeof(Infragistics.Win.UltraWinGrid.RowUIElement));
            }

            if (rowElement == null) return;

            // 要素から行を取得します。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow = (Infragistics.Win.UltraWinGrid.UltraGridRow)rowElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            // 行が返されなかった場合、マウスは行の上にありません。
            if (objRow == null)
                return;

            // マウスは行の上にあります。

            // この部分はオプションです。しかし、ユーザーが行セレクタ間の行を
            // ダブルクリックした場合、デフォルトで行のサイズを自動調整します。
            // その場合、通常、ダブルクリックコードは記述しません。

            // 現在のマウスポインタの位置を取得してグリッド座標に変換します。
            Point MousePosition = targetGrid.PointToClient(Control.MousePosition);
            // 座標点が AdjustableElement 上にあるかどうかを調べます。すなわち、
            // ユーザーが行セレクタ上の行をクリックしているかどうか。
            if (lastElementEntered.AdjustableElementFromPoint(MousePosition) != null)
                return;

            if (objRow != null)
            {
                this.SelectRowData(objRow);
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void uGrid_SearchResult_KeyDown( object sender, KeyEventArgs e )
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        break;
                    }
                case Keys.Down:
                    {
                        break;
                    }
                case Keys.Enter:
                    {
                        Infragistics.Win.UltraWinToolbars.ButtonTool decideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Decision];
                        if (decideButton.SharedProps.Enabled)
                        {
                            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_SearchResult.ActiveRow;
                            if (row != null)
                            {
                                this.SelectRowData(row);
                                this.DialogResult = DialogResult.OK;
                            }
                        }

                        break;
                    }
                case Keys.Space:
                    {

                        break;
                    }
            }
        }

        #endregion

        #region < UltraToolbarsManagerのイベント関連 >

        /// <summary>
		/// UltraToolbarのクリックイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
        /// <remarks> 
        /// <br>UpdateNote : 2016/06/02 3H 石雨静</br>
        /// <br>管理番号   : 11201042-00 中村オートパーツ㈱</br>
        /// <br>           : 拠点切替追加</br>
        /// </remarks>
		private void Main_UToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				// -------------------------------------------------------------------------------
				// 終了
				// -------------------------------------------------------------------------------
				case CT_BUTTONTOOL_Back:
					{
						this.DialogResult = DialogResult.Cancel;
						break;
					}

                // -------------------------------------------------------------------------------
				// 確定
				// -------------------------------------------------------------------------------
				case CT_BUTTONTOOL_Decision:
					{
						// 単一選択の場合
                        if (this.uGrid_SearchResult.ActiveRow != null)
                        {
                            this.SelectRowData(this.uGrid_SearchResult.ActiveRow);
                        }

						this.DialogResult = DialogResult.OK;

						break;
					}
                // --- ADD 3H 石雨静 2016/06/02 ---------->>>>>
                // -------------------------------------------------------------------------------
                // 拠点切替
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_Search:
                    {
                        // 拠点切替
                        setKifKbn();
                        break;
                    }
                // --- ADD 3H 石雨静 2016/06/02 ----------<<<<<

				default:
					break;
			}
		}

		#endregion

       // --- ADD 3H 石雨静 2016/06/02 ---------->>>>>
        #region
        /// <summary>
        /// 拠点切替設定処理
        /// </summary>
        /// <remarks> 
        /// <br>UpdateNote : 2016/06/02 3H 石雨静</br>
        /// <br>管理番号   : 11201042-00 中村オートパーツ㈱</br>
        /// <br>           : 拠点切替追加</br>
        /// </remarks>
        private void setKifKbn()
        {
            ultraLabel2.Text = Convert.ToInt32(ultraLabel2.Text) == 0 ? "1" : "0";
            // データ切替
            setGridChange();
        }

        /// <summary>
        /// データ切替
        /// </summary>
        /// <remarks> 
        /// <br>UpdateNote : 2016/06/02 3H 石雨静</br>
        /// <br>管理番号   : 11201042-00 中村オートパーツ㈱</br>
        /// <br>           : 拠点切替追加</br>
        /// </remarks>
        private void setGridChange()
        {
            // 自拠点
            if (ultraLabel2.Text == "1")
            {
                DataTable _tempstockDataTable = new DataTable();
                _tempstockDataTable = this._stockDataTable.Copy();
                for (int i = this._sectionCodeList.Count; i > 0; i--)
                {
                    if (this._loginSectionCode.CompareTo(_sectionCodeList[i - 1].ToString().TrimEnd()) != 0)
                    {
                        _tempstockDataTable.Rows[i - 1].Delete();
                    }
                }
                _tempstockDataTable.AcceptChanges();
                this._gridBindDataView = new DataView(_tempstockDataTable);
            }
            else
            {
                this._gridBindDataView = new DataView(this._stockDataTable);
            }
            this.uGrid_SearchResult.DataSource = this._gridBindDataView;
        }
        #endregion
        // --- ADD 3H 石雨静 2016/06/02 ----------<<<<<
        #endregion
    }

}
