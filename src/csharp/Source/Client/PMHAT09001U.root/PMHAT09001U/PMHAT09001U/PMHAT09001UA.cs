//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタメンテナンス
// プログラム概要   : 発注点設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/03/31  修正内容 : 新規作成
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
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using System.Net.NetworkInformation;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 発注点設定マスタフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定マスタのフォームクラスです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.03.31</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.03.31 lizc 新規作成</br>
    /// </remarks>
    public partial class PMHAT09001UA : Form
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region コンストラクタ
        /// <summary>
        /// 発注点設定マスタフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタのコンストラクタです。</br>      
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        public PMHAT09001UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._orderPointStListTable = new Hashtable();

            this._orderPointStDataTable = new OrderPointStDataSet.OrderPointStDataTable();
            this._orderPointStDataTableClone = new OrderPointStDataSet.OrderPointStDataTable();
            this._orderPointStAcs = new OrderPointStAcs();

            this._secInfoAcs = new SecInfoAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._makerAcs = new MakerAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._supplierAcs = new SupplierAcs();

            this._orderPointStClone = new OrderPointSt();
            this._orderPointStDicClone = new Dictionary<int, OrderPointSt>();
        }
        # endregion

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        # region Private Constant

        // ツールバーツールキー設定
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";
        private const string TOOLBAR_LOGICALDELETE_KEY = "ButtonTool_LogicalDelete";
        private const string TOOLBAR_DELETE_KEY = "ButtonTool_Delete";
        private const string TOOLBAR_REVIVAL_KEY = "ButtonTool_Revival";
        private const string TOOLBAR_LOGINSECTIONLABLE_KEY = "LableTool_LoginSection";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LableTool_LoginName";
        private const string TOOLBAR_ROWDELETE_KEY = "ButtonTool_delRow";

        private const string TOOLBAR_LOGINSECTIONLABEL_TITLE = "LableTool_LoginSectionTitle";
        private const string TOOLBAR_LOGINLABEL_TITLE = "LableTool_LoginTitle";

        private const string AVGSUMDIV_1 = "平均";
        private const string AVGSUMDIV_2 = "合計";

        private const string COLUMNKEY_1 = "ShipScopeMore";         // 出荷数範囲(以上)
        private const string COLUMNKEY_2 = "ShipScopeLess";         // 出荷数範囲(以下)
        private const string COLUMNKEY_3 = "MinimumStockCnt";       // 最低在庫数
        private const string COLUMNKEY_4 = "MaximumStockCnt";       // 最高在庫数
        private const string COLUMNKEY_5 = "SalesOrderUnit";        // 発注単位

        private const string ASSEMBLY_ID = "PMHAT09001U";

        private const string COLUMN_SHIPSCOPEMORE = "ShipScopeMore";
        private const string COLUMN_SHIPSCOPELESS = "ShipScopeLess";
        private const string COLUMN_MINIMUMSTOCKCNT = "MinimumStockCnt";
        private const string COLUMN_MAXIMUMSTOCKCNT = "MaximumStockCnt";
        private const string COLUMN_SALESORDERUNIT = "SalesOrderUnit";

        private const string FORMAT_NUM = "###,##0.00";
        private const string FORMAT_NUM2 = "###,###";

        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        private const string UPDATE_DIV_0 = "未更新";
        private const string UPDATE_DIV_1 = "更新済";

        private const int COLUMN_COUNT = 6;                    // 列数
        private const int ROW_COUNT = 20;                       // 行数
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        // 企業コード取得用
        private string _enterpriseCode;
        // ログイン拠点(自拠点)
        private string _loginSectionCode;

        private Hashtable _orderPointStListTable;

        // 保存比較用Clone
        private OrderPointSt _orderPointStClone;
        private OrderPointStDataSet.OrderPointStDataTable _orderPointStDataTableClone;

        private OrderPointStDataSet.OrderPointStDataTable _orderPointStDataTable;
        private OrderPointStAcs _orderPointStAcs;

        private ImageList _imageList16 = null;											// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// 保存ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;				// 検索ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;				// クリアボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _logicDeleteButton;		// 論理削除
        private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteButton;				// 削除
        private Infragistics.Win.UltraWinToolbars.ButtonTool _revivalButton;			// 復活
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionTitleLabel;	// ログイン拠点名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionLabel;			// ログイン拠点名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;		    // ログイン担当者名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;		    // ログイン担当者名称

        // 行削除
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowDelButton;

        // アクセスクラス
        private WarehouseAcs _warehouseAcs = null;           //倉庫ガイド
        private MakerAcs _makerAcs = null;					// メーカーアクセスクラス
        private GoodsGroupUAcs _goodsGroupUAcs = null;      // 中分類アクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs = null;			// BLアクセスクラス
        private BLGroupUAcs _blGroupUAcs = null;            // BLグループアクセスクラス
        private SupplierAcs _supplierAcs = null;            // 仕入先アクセスクラス
        private SecInfoAcs _secInfoAcs = null;              // 拠点情報アクセスクラス

        private Dictionary<string, Warehouse> _warehouseDic;
        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<int, BLGroupU> _blGroupUDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;

        private Dictionary<int, OrderPointSt> _orderPointStDicClone;

        // 前回値保持用変数
        private int _prevPatterNo;
        private string _prevWarehouseCode;
        private int _prevSupplierCd;
        private int _prevMakerCode;
        private int _prevBLGroupCode;
        private int _prevBLGoodsCode;
        private int _prevGoodsMGroupCd;

        # endregion

        // ===================================================================================== //
        // プライベート
        // ===================================================================================== //
        # region Private Method
        # region 画面初期化
        /// <summary>
        /// 初期画面設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.03.31</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            // ツールバー初期設定処理
            this.ToolBarInitilSetting();

            // ボタンアイコン設定
            this.SetGuidButtonIcon();

            // ツールボタンEnable設定処理
            this.SetControlEnabled(INSERT_MODE);

            // 初期画面データ設定
            this.InitialScreenData();

            //this.SetBlankGrid();
            this.FillDetailRow();
        }

        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時、ツールバー初期設定処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.03.31</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            // 終了のアイコン設定
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            if (this._closeButton != null)
            {
                this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.CLOSE];
            }

            // 保存のアイコン設定
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY];
            if (this._saveButton != null)
            {
                this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.SAVE];
            }

            // 検索のアイコン設定
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SEARCHBUTTON_KEY];
            if (this._searchButton != null)
            {
                this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.SEARCH];
            }

            // クリアのアイコン設定
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY];
            if (this._clearButton != null)
            {
                this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.ALLCANCEL];
            }

            // 論理削除
            this._logicDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGICALDELETE_KEY];
            {
                this._logicDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.DELETE];
            }

            // 削除
            this._deleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_DELETE_KEY];
            {
                this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.DELETE];
            }

            // 復活
            this._revivalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_REVIVAL_KEY];
            {
                this._revivalButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.UNDO];
            }

            // ログイン拠点のアイコン設定
            this._loginSectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABEL_TITLE];
            if (this._loginSectionTitleLabel != null)
            {
                this._loginSectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.BASE]; ;
            }

            // ログイン担当者のアイコン設定
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINLABEL_TITLE];
            if (this._loginTitleLabel != null)
            {
                this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.EMPLOYEE];
            }

            // ログイン拠点名
            this._loginSectionLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABLE_KEY];
            if (this._loginSectionLabel != null && LoginInfoAcquisition.Employee != null)
            {
                SecInfoSet secInfoSet = new SecInfoSet();
                this._secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
                if (secInfoSet != null)
                {
                    this._loginSectionLabel.SharedProps.Caption = secInfoSet.SectionGuideNm;
                }
            }

            // ログイン担当者名
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            if (this._loginNameLabel != null && LoginInfoAcquisition.Employee != null)
            {
                Employee employee = new Employee();
                employee = LoginInfoAcquisition.Employee;
                this._loginNameLabel.SharedProps.Caption = employee.Name;
            }

            // 行削除
            this._rowDelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_ROWDELETE_KEY];
            {
                this._rowDelButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.ROWDELETE];
            }
        }

        /// <summary>
        /// ガイドボタンのアイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ガイドボタンのアイコンを設定します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.03.31</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            // -----------------------------
            // ボタンアイコン設定
            // -----------------------------
            this.WarehouseGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.SupplierGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.MakerGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsMGroupGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGroupGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGoodsCdGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// 初期画面データ設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.03.31</br>
        /// </remarks> 
        private void InitialScreenData()
        {
            // 平均・合計区分
            this.tComboEditor_OrderApplyDiv.Items.Clear();
            this.tComboEditor_OrderApplyDiv.Items.Add("1", AVGSUMDIV_1);
            this.tComboEditor_OrderApplyDiv.Items.Add("2", AVGSUMDIV_2);
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <param name="clearFlag">クリア設定コード</param>
        /// <remarks>
        /// <br>Note       : 画面情報をクリアします。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.02</br>
        /// </remarks>
        private void ClearScreen(bool clearFlag)
        {
            if (clearFlag)
            {
                this.tNedit_PatterNo.Clear();
            }

            // 基本情報
            this.tEdit_WarehouseCode.Clear();
            this.tNedit_SupplierCd.Clear();
            this.tNedit_GoodsMGroup.Clear();
            this.tNedit_GoodsMakerCd.Clear();
            this.tNedit_BLGloupCode.Clear();
            this.tNedit_BLGoodsCode.Clear();

            //　条件情報
            this.tDateEdit_StckShipMonthSt.Clear();
            this.tDateEdit_StckShipMonthEd.SetDateTime(System.DateTime.Now);
            this.tDateEdit_StockCreateDate.SetDateTime(System.DateTime.Now);
            this.tComboEditor_OrderApplyDiv.Value = "1";

            //　詳細情報
            this.ClearGrid();

            this._prevPatterNo = 0;
            this._prevWarehouseCode = string.Empty;
            this._prevBLGroupCode = 0;
            this._prevBLGoodsCode = 0;
            this._prevMakerCode = 0;
            this._prevSupplierCd = 0;
            this._prevGoodsMGroupCd = 0;

            this.UpdateDiv_Label.Text = UPDATE_DIV_0;

            this.SetControlEnabled(INSERT_MODE);

            ScreenToOrderPointSt(ref this._orderPointStClone);
            // フォーカスの設定
            this.tNedit_PatterNo.Focus();

            // scrollbarの位置
            this.Detail_uGrid.ActiveRowScrollRegion.FirstRow = this.Detail_uGrid.Rows[0];
        }

        /// <summary>
        /// グリッド初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッド情報を初期化します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void ClearGrid()
        {
            for (int index = 0; index < ROW_COUNT; index++)
            {
                this.Detail_uGrid.Rows[index].Cells[COLUMN_SHIPSCOPEMORE].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_SHIPSCOPELESS].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_MINIMUMSTOCKCNT].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_MAXIMUMSTOCKCNT].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_SALESORDERUNIT].Value = "";
            }
            this.Detail_uGrid.UpdateData();
            this._orderPointStDicClone.Clear();
        }
        # endregion 画面初期化

        #region 画面設定
        /// <summary>
        /// ツールボタンEnable設定処理
        /// </summary>
        /// <param name="mode">編集モード</param>
        /// <remarks>
        /// <br>Note       : ツールボタンEnableを設定する</br>
        /// <br>Programer  : 李占川</br>
        /// <br>Date       : 2009/04/21</br>
        /// </remarks>
        private void SetToolButtonVisible(string mode)
        {
            switch (mode)
            {
                // 新規
                case INSERT_MODE:
                    {
                        this._saveButton.SharedProps.Visible = true;
                        this._logicDeleteButton.SharedProps.Visible = false;
                        this._deleteButton.SharedProps.Visible = false;
                        this._revivalButton.SharedProps.Visible = false;

                        this.Mode_Label.Text = INSERT_MODE;
                        break;
                    }
                // 更新
                case UPDATE_MODE:
                    {
                        this._saveButton.SharedProps.Visible = true;
                        this._logicDeleteButton.SharedProps.Visible = true;
                        this._deleteButton.SharedProps.Visible = false;
                        this._revivalButton.SharedProps.Visible = false;

                        this.Mode_Label.Text = UPDATE_MODE;
                        break;
                    }
                // 削除
                case DELETE_MODE:
                    {
                        this._saveButton.SharedProps.Visible = false;
                        this._logicDeleteButton.SharedProps.Visible = false;
                        this._deleteButton.SharedProps.Visible = true;
                        this._revivalButton.SharedProps.Visible = true;

                        this.Mode_Label.Text = DELETE_MODE;
                        break;
                    }
            }
        }

        /// <summary>
        /// コントロールEnabled制御処理
        /// </summary>
        /// <param name="editMode">編集モード</param>
        /// <remarks>
        /// <br>Note       : コントロールのEnabled制御を行います。</br>
        /// <br>Programer  : 李占川</br>
        /// <br>Date       : 2009/04/21</br>
        /// </remarks>
        private void SetControlEnabled(string editMode)
        {
            switch (editMode)
            {
                // 新規
                case INSERT_MODE:
                    {
                        // 基本情報コード
                        this.tEdit_WarehouseCode.Enabled = true;
                        this.tNedit_GoodsMGroup.Enabled = true;
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGloupCode.Enabled = true;
                        this.tNedit_SupplierCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = true;

                        // 基本情報button
                        this.WarehouseGuide_Button.Enabled = true;
                        this.GoodsMGroupGuide_Button.Enabled = true;
                        this.SupplierGuide_Button.Enabled = true;
                        this.BLGroupGuide_Button.Enabled = true;
                        this.MakerGuide_Button.Enabled = true;
                        this.BLGoodsCdGuide_Button.Enabled = true;

                        // 条件情報
                        this.tDateEdit_StckShipMonthSt.Enabled = true;
                        this.tDateEdit_StckShipMonthEd.Enabled = true;
                        this.tDateEdit_StockCreateDate.Enabled = true;
                        this.tComboEditor_OrderApplyDiv.Enabled = true;

                        // 詳細情報
                        this.Detail_uGrid.Enabled = true;

                        this._saveButton.SharedProps.Visible = true;
                        this._logicDeleteButton.SharedProps.Visible = false;
                        this._deleteButton.SharedProps.Visible = false;
                        this._revivalButton.SharedProps.Visible = false;

                        this.Mode_Label.Text = INSERT_MODE;

                        this.tRetKeyControl1.OwnerForm = this;

                        break;
                    }
                // 更新
                case UPDATE_MODE:
                    {
                        // 基本情報コード
                        this.tEdit_WarehouseCode.Enabled = true;
                        this.tNedit_GoodsMGroup.Enabled = true;
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGloupCode.Enabled = true;
                        this.tNedit_SupplierCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = true;

                        // 基本情報button
                        this.WarehouseGuide_Button.Enabled = true;
                        this.GoodsMGroupGuide_Button.Enabled = true;
                        this.SupplierGuide_Button.Enabled = true;
                        this.BLGroupGuide_Button.Enabled = true;
                        this.MakerGuide_Button.Enabled = true;
                        this.BLGoodsCdGuide_Button.Enabled = true;

                        // 条件情報
                        this.tDateEdit_StckShipMonthSt.Enabled = true;
                        this.tDateEdit_StckShipMonthEd.Enabled = true;
                        this.tDateEdit_StockCreateDate.Enabled = true;
                        this.tComboEditor_OrderApplyDiv.Enabled = true;

                        // 詳細情報
                        this.Detail_uGrid.Enabled = true;

                        this._saveButton.SharedProps.Visible = true;
                        this._logicDeleteButton.SharedProps.Visible = true;
                        this._deleteButton.SharedProps.Visible = false;
                        this._revivalButton.SharedProps.Visible = false;

                        this.Mode_Label.Text = UPDATE_MODE;

                        this.tRetKeyControl1.OwnerForm = this;
                        break;
                    }
                // 削除
                case DELETE_MODE:
                    {
                        // 基本情報コード
                        this.tEdit_WarehouseCode.Enabled = false;
                        this.tNedit_GoodsMGroup.Enabled = false;
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.tNedit_SupplierCd.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;

                        // 基本情報button
                        this.WarehouseGuide_Button.Enabled = false;
                        this.GoodsMGroupGuide_Button.Enabled = false;
                        this.SupplierGuide_Button.Enabled = false;
                        this.BLGroupGuide_Button.Enabled = false;
                        this.MakerGuide_Button.Enabled = false;
                        this.BLGoodsCdGuide_Button.Enabled = false;

                        // 条件情報
                        this.tDateEdit_StckShipMonthSt.Enabled = false;
                        this.tDateEdit_StckShipMonthEd.Enabled = false;
                        this.tDateEdit_StockCreateDate.Enabled = false;
                        this.tComboEditor_OrderApplyDiv.Enabled = false;

                        // 詳細情報
                        this.Detail_uGrid.Enabled = false;

                        this._saveButton.SharedProps.Visible = false;
                        this._logicDeleteButton.SharedProps.Visible = false;
                        this._deleteButton.SharedProps.Visible = true;
                        this._revivalButton.SharedProps.Visible = true;

                        this.Mode_Label.Text = DELETE_MODE;

                        this.tRetKeyControl1.OwnerForm = this.Detail_uGrid;

                        break;
                    }
            }
        }
        # endregion 画面設定

        # region マスタ読込
        /// <summary>
        /// 倉庫マスタ読込処理
        /// </summary>
        private void LoadWarehouse()
        {
            int status = 0;

            this._warehouseDic = new Dictionary<string, Warehouse>();

            try
            {
                ArrayList retList;

                status = this._warehouseAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Warehouse warehouse in retList)
                    {
                        if (warehouse.LogicalDeleteCode == 0)
                        {
                            this._warehouseDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                        }
                    }
                }
            }
            catch
            {
                this._warehouseDic = new Dictionary<string, Warehouse>();
            }
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
        /// 中分類マスタ読込処理
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
        /// BLコードマスタ読込処理
        /// </summary>
        private void LoadBLGoodsCdUMnt()
        {
            int status = 0;

            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
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
        # endregion マスタ読込

        # region 保存処理
        /// <summary>
        ///　保存処理(SaveProc())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool SaveProc()
        {
            bool bStatus = false;

            // 入力チェック
            bStatus = CheckInputScreen(true);

            if (bStatus != true)
            {
                return (false);
            }

            int status = 0;

            // 新規モードの場合
            if (this.Mode_Label.Text.Equals(INSERT_MODE))
            {
                List<OrderPointSt> retList = new List<OrderPointSt>();
                status = this._orderPointStAcs.Search(out retList, this.tNedit_PatterNo.GetInt(), this._enterpriseCode);
                if (retList.Count > 0)
                {
                    ExclusiveTransaction((int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE);

                    return false;
                }
            }

            List<OrderPointSt> orderPointStList = new List<OrderPointSt>();

            this.ScreenToOrderPointStList(ref orderPointStList);

            // 削除リスト取得
            List<OrderPointSt> deleteList = new List<OrderPointSt>();
            foreach (OrderPointSt orderPointSt in this._orderPointStDicClone.Values)
            {
                // TODO:問題がある
                deleteList.Add(orderPointSt);
            }

            // 削除処理
            if (deleteList.Count > 0)
            {
                status = this._orderPointStAcs.Delete(deleteList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    default:
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                           "SaveProc",
                                           "保存処理に失敗しました。",
                                           status,
                                           MessageBoxButtons.OK);

                            return false;
                        }
                }
            }

            // 保存処理
            status = this._orderPointStAcs.Write(ref orderPointStList);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        this.ClearScreen(true);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

                        return false;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "保存処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return false;
                    }
            }
            return bStatus;
        }
        # endregion 保存処理

        # region 検索処理
        /// <summary>
        ///　検索処理(SearchProc())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 検索処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private int SearchProc()
        {
            bool bStatus = false;

            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面検索処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return -1;
            }

            int patterNo = this.tNedit_PatterNo.GetInt();

            if (this._prevPatterNo != 0)
            {
                // 入力中のデータチャック
                if (!this.CompareInputScreen())
                {
                    this.tNedit_PatterNo.SetInt(this._prevPatterNo);
                    return (-1);
                }
            }

            this.tNedit_PatterNo.SetInt(patterNo);
            // 入力チェック
            bStatus = CheckInputScreen(false);
            if (bStatus != true)
            {
                return (-1);
            }

            int status = 0;

            List<OrderPointSt> orderPointList;

            status = this._orderPointStAcs.Search(out orderPointList, patterNo, this._enterpriseCode);

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        // 編集モード設定
                        if (orderPointList[0].LogicalDeleteCode == 0)
                        {
                            this.Mode_Label.Text = UPDATE_MODE;

                            // コントロールEnabled制御
                            SetControlEnabled(UPDATE_MODE);
                        }
                        else
                        {
                            this.Mode_Label.Text = DELETE_MODE;

                            // コントロールEnabled制御
                            SetControlEnabled(DELETE_MODE);
                        }

                        // 更新区分
                        if (orderPointList[0].OrderPProcUpdFlg == 0)
                        {
                            this.UpdateDiv_Label.Text = UPDATE_DIV_0;
                        }
                        else
                        {
                            this.UpdateDiv_Label.Text = UPDATE_DIV_1;
                        }

                        // バッファ更新
                        this._orderPointStDicClone.Clear();
                        foreach (OrderPointSt orderPointSt in orderPointList)
                        {
                            this._orderPointStDicClone.Add(orderPointSt.PatternNoDerivedNo, orderPointSt);
                        }


                        this.OrderPointStToScreen(_orderPointStDicClone);

                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        // ツールボタンEnable設定処理
                        this.SetControlEnabled(INSERT_MODE);
                        this.UpdateDiv_Label.Text = UPDATE_DIV_0;

                        this.ClearScreen(false);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                            ASSEMBLY_ID,							// アセンブリID
                            this.Text,                              // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",				// 表示するメッセージ
                            status,									// ステータス値
                            this._orderPointStAcs,					    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,					// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

                        break;
                    }
            }

            return status;
        }
        # endregion 検索処理

        # region チェック処理
        /// <summary>
        /// 画面情報入力チェック処理
        /// </summary>
        /// <param name="saveFlag">保存フラグ(True:保存前チェック　False:検索条件チェック)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool CheckInputScreen(bool saveFlag)
        {
            string errMsg = "";
            bool bStatus;

            try
            {
                // 設定コード
                if (this.tNedit_PatterNo.DataText.Trim() == "")
                {
                    errMsg = "設定コードを入力してください。";

                    this.tNedit_PatterNo.Focus();
                    return (false);
                }

                if (saveFlag)
                {
                    // 基本情報チェック
                    bStatus = CheckBaseInfo(out errMsg);
                    if (!bStatus)
                    {
                        return (false);
                    }

                    // 条件情報チェック
                    bStatus = CheckCondtionInfo(out errMsg);
                    if (!bStatus)
                    {
                        return (false);
                    }

                    // 詳細情報チェック
                    bStatus = CheckDetailInfo(out errMsg);
                    if (!bStatus)
                    {
                        return (false);
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                                 , this.ToString()
                                 , errMsg
                                 , 0
                                 , MessageBoxButtons.OK);
                }
            }

            return true;
        }

        /// <summary>
        /// 画面情報入力チェック処理(基本情報)
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool CheckBaseInfo(out string errMsg)
        {
            errMsg = "";

            // 倉庫コード
            if (this.tEdit_WarehouseCode.DataText.Trim() != string.Empty)
            {
                if (this._warehouseDic == null)
                {
                    // 倉庫マスタ読込処理
                    LoadWarehouse();
                }

                if (!this._warehouseDic.ContainsKey(this.tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0')))
                {
                    errMsg = "指定された条件の倉庫コードは存在しませんでした。";

                    this.tEdit_WarehouseCode.Focus();
                    return (false);
                }
            }
            // 中分類
            if (this.tNedit_GoodsMGroup.GetInt() != 0)
            {
                if (this._goodsGroupUDic == null)
                {
                    // 中分類マスタ読込処理
                    LoadGoodsGroupU();
                }

                if (!this._goodsGroupUDic.ContainsKey(this.tNedit_GoodsMGroup.GetInt()))
                {
                    errMsg = "指定された条件の中分類コードは存在しませんでした。";

                    this.tNedit_GoodsMGroup.Focus();
                    return (false);
                }
            }
            // 仕入先
            if (this.tNedit_SupplierCd.GetInt() != 0)
            {
                if (this._supplierDic == null)
                {
                    // 仕入先マスタ読込処理
                    LoadSupplier();
                }

                if (!this._supplierDic.ContainsKey(this.tNedit_SupplierCd.GetInt()))
                {
                    errMsg = "指定された条件の仕入先コードは存在しませんでした。";

                    this.tNedit_SupplierCd.Focus();
                    return (false);
                }
            }
            // グループコード
            if (this.tNedit_BLGloupCode.GetInt() != 0)
            {
                if (this._blGroupUDic == null)
                {
                    // グループマスタ読込処理
                    LoadBLGroupU();
                }

                if (!this._blGroupUDic.ContainsKey(this.tNedit_BLGloupCode.GetInt()))
                {
                    errMsg = "指定された条件のグループコードは存在しませんでした。";

                    this.tNedit_BLGloupCode.Focus();
                    return (false);
                }
            }
            // メーカーコード
            if (this.tNedit_GoodsMakerCd.GetInt() != 0)
            {
                if (this._makerUMntDic == null)
                {
                    // グループマスタ読込処理
                    LoadMakerUMnt();
                }

                if (!this._makerUMntDic.ContainsKey(this.tNedit_GoodsMakerCd.GetInt()))
                {
                    errMsg = "指定された条件のメーカーコードは存在しませんでした。";

                    this.tNedit_GoodsMakerCd.Focus();
                    return (false);
                }
            }
            // BLコード
            if (this.tNedit_BLGoodsCode.GetInt() != 0)
            {
                if (this._blGoodsCdUMntDic == null)
                {
                    // グループマスタ読込処理
                    LoadBLGoodsCdUMnt();
                }

                if (!this._blGoodsCdUMntDic.ContainsKey(this.tNedit_BLGoodsCode.GetInt()))
                {
                    errMsg = "指定された条件のBLコードは存在しませんでした。";

                    this.tNedit_BLGoodsCode.Focus();
                    return (false);
                }
            }
            //
            return true;
        }

        /// <summary>
        /// 画面情報入力チェック処理(条件情報)
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool CheckCondtionInfo(out string errMsg)
        {
            errMsg = "";
            if (this.tDateEdit_StckShipMonthSt.GetDateYear() == 0
                && this.tDateEdit_StckShipMonthSt.GetDateMonth() == 0
                && this.tDateEdit_StckShipMonthSt.GetDateDay() == 0)
            {
                errMsg = "在庫出荷対象期間(開始)を入力してください。\r\n";

                this.tDateEdit_StckShipMonthSt.Focus();
                return false;
            }

            // 在庫出荷対象期間　開始
            if (this.tDateEdit_StckShipMonthSt.LongDate != 0
                && this.tDateEdit_StckShipMonthSt.GetDateTime() == DateTime.MinValue)
            {
                errMsg = "在庫出荷対象期間(開始)の入力が不正です。\r\n";

                this.tDateEdit_StckShipMonthSt.Focus();
                return false;
            }

            if (this.tDateEdit_StckShipMonthEd.GetDateYear() == 0
                && this.tDateEdit_StckShipMonthEd.GetDateMonth() == 0
                && this.tDateEdit_StckShipMonthEd.GetDateDay() == 0)
            {
                errMsg = "在庫出荷対象期間(終了)を入力してください。\r\n";

                this.tDateEdit_StckShipMonthEd.Focus();
                return false;
            }

            // 在庫出荷対象期間　終了
            if (this.tDateEdit_StckShipMonthEd.LongDate != 0
                && this.tDateEdit_StckShipMonthEd.GetDateTime() == DateTime.MinValue)
            {
                errMsg = "在庫出荷対象期間(終了)の入力が不正です。\r\n";

                this.tDateEdit_StckShipMonthEd.Focus();
                return false;
            }
            // 終了日付＜開始日付チェック
            if (this.tDateEdit_StckShipMonthSt.GetDateTime() != DateTime.MinValue
                && this.tDateEdit_StckShipMonthEd.GetDateTime() != DateTime.MinValue
                && this.tDateEdit_StckShipMonthSt.GetDateTime().CompareTo(this.tDateEdit_StckShipMonthEd.GetDateTime()) > 0)
            {
                errMsg = "在庫出荷対象期間の範囲指定に誤りがあります。\r\n";

                this.tDateEdit_StckShipMonthSt.Focus();
                return false;
            }

            if (this.tDateEdit_StockCreateDate.GetDateYear() == 0
                && this.tDateEdit_StockCreateDate.GetDateMonth() == 0
                && this.tDateEdit_StockCreateDate.GetDateDay() == 0)
            {
                errMsg = "在庫登録日付を入力してください。\r\n";

                this.tDateEdit_StockCreateDate.Focus();
                return false;
            }

            // 在庫登録日付
            if (this.tDateEdit_StockCreateDate.LongDate != 0
                && this.tDateEdit_StockCreateDate.GetDateTime() == DateTime.MinValue)
            {
                errMsg = "在庫登録日付の入力が不正です。\r\n";

                this.tDateEdit_StockCreateDate.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 画面情報入力チェック処理(詳細情報)
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool CheckDetailInfo(out string errMsg)
        {
            errMsg = "";

            return this.CheckGridStockCnt(ref errMsg); ;
        }

        /// <summary>
        /// 画面情報変更チェック処理
        /// </summary>
        /// <returns>ステータス(True:変更なし　False:変更あり)</returns>
        /// <remarks>
        /// <br>Note        : 画面情報が変更されているかどうかチェックします。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool CompareInputScreen()
        {
            OrderPointSt compareOrderPointSt = new OrderPointSt();
            compareOrderPointSt = this._orderPointStClone.Clone();

            this.ScreenToOrderPointSt(ref compareOrderPointSt);

            // データ比較
            if (!this._orderPointStClone.Equals(compareOrderPointSt)
                || CompareDetailGrid())
            {
                //return false;

                // 画面情報が変更されていた場合は、保存確認メッセージを表示
                DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                    ASSEMBLY_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
                    null, 					                              // 表示するメッセージ
                    0, 					                                  // ステータス値
                    MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            return this.SaveProc();
                        }

                    case DialogResult.No:
                        {
                            return true;
                        }

                    default:
                        {
                            return false;
                        }
                }
            }
            return true;
        }
        # endregion チェック処理

        # region 画面情報取得
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面情報発注点設定マスタクラス格納処理
        /// </summary>
        /// <param name="orderPointSt">発注点設定マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note        : 画面情報から発注点設定マスタオブジェクトにデータを格納します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private void ScreenToOrderPointSt(ref OrderPointSt orderPointSt)
        {
            if (orderPointSt == null)
            {
                // 新規の場合
                orderPointSt = new OrderPointSt();
            }

            // 企業コード
            orderPointSt.EnterpriseCode = this._enterpriseCode;
            // パターン番号
            orderPointSt.PatterNo = this._prevPatterNo;
            // 倉庫コード
            orderPointSt.WarehouseCode = this.tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0');
            // 仕入先コード
            orderPointSt.SupplierCd = this.tNedit_SupplierCd.GetInt();
            // 商品メーカーコード
            orderPointSt.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // 商品中分類コード
            orderPointSt.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();
            // BLグループコード
            orderPointSt.BLGroupCode = this.tNedit_BLGloupCode.GetInt();
            // BL商品コード
            orderPointSt.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            // 在庫出荷対象開始月
            orderPointSt.StckShipMonthSt = Convert.ToInt32(this.tDateEdit_StckShipMonthSt.GetDateTime().ToString("yyyyMMdd"));
            // 在庫出荷対象終了月
            orderPointSt.StckShipMonthEd = Convert.ToInt32(this.tDateEdit_StckShipMonthEd.GetDateTime().ToString("yyyyMMdd"));
            // 在庫登録日
            orderPointSt.StockCreateDate = Convert.ToInt32(this.tDateEdit_StockCreateDate.GetDateTime().ToString("yyyyMMdd"));
            // 発注適用区分
            orderPointSt.OrderApplyDiv = this.tComboEditor_OrderApplyDiv.SelectedIndex;
        }

        /// <summary>
        /// 画面情報発注点設定マスタクラス格納処理
        /// </summary>
        /// <param name="orderPointStList">発注点設定マスタList</param>
        /// <remarks>
        /// <br>Note        : 画面情報から発注点設定マスタオブジェクトにデータを格納します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private void ScreenToOrderPointStList(ref List<OrderPointSt> orderPointStList)
        {
            for (int i = 0; i < ROW_COUNT; i++)
            {
                // 画面でこのLineが未入力場合
                if (ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_SHIPSCOPELESS].Value) == 0
                    && ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_SHIPSCOPEMORE].Value) == 0
                    && ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_MINIMUMSTOCKCNT].Value) == 0
                    && ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_MAXIMUMSTOCKCNT].Value) == 0
                    && ChangeCellValueToInt(this.Detail_uGrid.Rows[i].Cells[COLUMN_SALESORDERUNIT].Value) == 0)
                {
                    continue;
                }

                //// R使用の更新日時
                //OrderPointSt orderPointStTem = this._orderPointStListTable[0] as OrderPointSt;
                //OrderPointSt orderPointSt = null;
                //if (orderPointStTem != null)
                //{
                //    orderPointSt = orderPointStTem.Clone();
                //}
                //else
                //{
                //    orderPointSt = new OrderPointSt();
                //}

                OrderPointSt orderPointSt = new OrderPointSt();
                this.ScreenToOrderPointSt(ref orderPointSt);

                // パターン番号枝番
                orderPointSt.PatternNoDerivedNo = i + 1;
                // 出荷数範囲(以上)
                orderPointSt.ShipScopeMore = ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_SHIPSCOPEMORE].Value);
                // 出荷数範囲(以下)
                orderPointSt.ShipScopeLess = ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_SHIPSCOPELESS].Value);
                // 最低在庫数
                orderPointSt.MinimumStockCnt = ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_MINIMUMSTOCKCNT].Value);
                // 最高在庫数
                orderPointSt.MaximumStockCnt = ChangeCellValueToDouble(this.Detail_uGrid.Rows[i].Cells[COLUMN_MAXIMUMSTOCKCNT].Value);
                // 発注単位
                orderPointSt.SalesOrderUnit = ChangeCellValueToInt(this.Detail_uGrid.Rows[i].Cells[COLUMN_SALESORDERUNIT].Value);

                orderPointStList.Add(orderPointSt);
            }
        }
        # endregion

        #region 画面展開
        /// <summary>
        /// 画面展開処理(発注点設定)
        /// </summary>
        /// <param name="orderPointStDic">発注点設定マスタリスト</param>
        /// <remarks>
        /// <br>Note        : 発注点設定マスタリストを画面展開します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void OrderPointStToScreen(Dictionary<int, OrderPointSt> orderPointStDic)
        {
            //------------------------------
            // 目標情報初期化
            //------------------------------
            // 基本情報
            this.tEdit_WarehouseCode.Clear();
            this.tNedit_SupplierCd.Clear();
            this.tNedit_GoodsMGroup.Clear();
            this.tNedit_GoodsMakerCd.Clear();
            this.tNedit_BLGloupCode.Clear();
            this.tNedit_BLGoodsCode.Clear();

            //　条件情報
            this.tDateEdit_StckShipMonthSt.Clear();
            this.tDateEdit_StckShipMonthEd.SetDateTime(System.DateTime.Now);
            this.tDateEdit_StockCreateDate.SetDateTime(System.DateTime.Now);
            this.tComboEditor_OrderApplyDiv.Value = "1";

            for (int index = 0; index < ROW_COUNT; index++)
            {
                this.Detail_uGrid.Rows[index].Cells[COLUMN_SHIPSCOPEMORE].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_SHIPSCOPELESS].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_MINIMUMSTOCKCNT].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_MAXIMUMSTOCKCNT].Value = "";
                this.Detail_uGrid.Rows[index].Cells[COLUMN_SALESORDERUNIT].Value = "";
            }

            // scrollbarの位置
            this.Detail_uGrid.ActiveRowScrollRegion.FirstRow = this.Detail_uGrid.Rows[0];

            //------------------------------
            // 目標情報設定
            //------------------------------
            for (int index = 1; index < 21; index++)
            {
                // 回数
                int times = 0;

                if (!orderPointStDic.ContainsKey(index))
                {
                    continue;
                }

                OrderPointSt orderPointSt = (OrderPointSt)orderPointStDic[index];
                // コードの設定
                if (times == 0)
                {
                    this.tEdit_WarehouseCode.DataText = orderPointSt.WarehouseCode.Trim();
                    this._prevWarehouseCode = orderPointSt.WarehouseCode.Trim();
                    this.tNedit_GoodsMGroup.SetInt(orderPointSt.GoodsMGroup);
                    this._prevGoodsMGroupCd = orderPointSt.GoodsMGroup;
                    this.tNedit_SupplierCd.SetInt(orderPointSt.SupplierCd);
                    this._prevSupplierCd = orderPointSt.SupplierCd;
                    this.tNedit_BLGloupCode.SetInt(orderPointSt.BLGroupCode);
                    this._prevBLGroupCode = orderPointSt.BLGroupCode;
                    this.tNedit_GoodsMakerCd.SetInt(orderPointSt.GoodsMakerCd);
                    this._prevMakerCode = orderPointSt.GoodsMakerCd;
                    this.tNedit_BLGoodsCode.SetInt(orderPointSt.BLGoodsCode);
                    this._prevBLGoodsCode = orderPointSt.BLGoodsCode;

                    this.tDateEdit_StckShipMonthSt.SetLongDate(orderPointSt.StckShipMonthSt);
                    this.tDateEdit_StckShipMonthEd.SetLongDate(orderPointSt.StckShipMonthEd);
                    this.tDateEdit_StockCreateDate.SetLongDate(orderPointSt.StockCreateDate);
                    this.tComboEditor_OrderApplyDiv.SelectedIndex = orderPointSt.OrderApplyDiv;
                }
                times++;

                // 0の処理
                //if (orderPointSt.ShipScopeMore != 0)
                //{
                //    this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_SHIPSCOPEMORE].Value = orderPointSt.ShipScopeMore.ToString(FORMAT_NUM);
                //}

                //if (orderPointSt.ShipScopeLess != 0)
                //{
                //    this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_SHIPSCOPELESS].Value = orderPointSt.ShipScopeLess.ToString(FORMAT_NUM);
                //}

                //if (orderPointSt.MinimumStockCnt != 0)
                //{
                //    this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_MINIMUMSTOCKCNT].Value = orderPointSt.MinimumStockCnt.ToString(FORMAT_NUM);
                //}

                //if (orderPointSt.MaximumStockCnt != 0)
                //{
                //    this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_MAXIMUMSTOCKCNT].Value = orderPointSt.MaximumStockCnt.ToString(FORMAT_NUM);
                //}

                //if (orderPointSt.SalesOrderUnit != 0)
                //{
                //    this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_SALESORDERUNIT].Value = orderPointSt.SalesOrderUnit.ToString(FORMAT_NUM2);
                //}

                this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_SHIPSCOPEMORE].Value = orderPointSt.ShipScopeMore.ToString(FORMAT_NUM);
                this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_SHIPSCOPELESS].Value = orderPointSt.ShipScopeLess.ToString(FORMAT_NUM);
                this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_MINIMUMSTOCKCNT].Value = orderPointSt.MinimumStockCnt.ToString(FORMAT_NUM);
                this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_MAXIMUMSTOCKCNT].Value = orderPointSt.MaximumStockCnt.ToString(FORMAT_NUM);
                this.Detail_uGrid.Rows[index - 1].Cells[COLUMN_SALESORDERUNIT].Value = orderPointSt.SalesOrderUnit.ToString(FORMAT_NUM2);
            }
            this.Detail_uGrid.UpdateData();

            this.ScreenToOrderPointSt(ref this._orderPointStClone);
        }
        # endregion

        # region 論理削除処理
        /// <summary>
        /// 論理削除クリック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 論理削除ボタンがクリックされたときに発生</br>
        /// <br>Programer  : 李占川</br>
        /// <br>Date       : 2009/04/22</br>
        /// </remarks>
        private int LogicalDeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<OrderPointSt> orderPointStList = new List<OrderPointSt>();

            foreach (OrderPointSt orderPointSt in this._orderPointStDicClone.Values)
            {
                orderPointStList.Add(orderPointSt);
            }

            // 論理削除
            status = this._orderPointStAcs.LogicalDelete(ref orderPointStList);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // コントロールEnabled制御
                        SetControlEnabled(DELETE_MODE);

                        // バッファ更新
                        this._orderPointStDicClone.Clear();
                        foreach (OrderPointSt orderPointSt in orderPointStList)
                        {
                            this._orderPointStDicClone.Add(orderPointSt.PatternNoDerivedNo, orderPointSt);
                        }

                        // 画面展開
                        OrderPointStToScreen(this._orderPointStDicClone);

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "LogicalDeleteProc",
                                       "削除処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        # endregion 論理削除処理

        # region 物理削除処理
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定を物理削除します。</br>
        /// <br>Programer  : 李占川</br>
        /// <br>Date       : 2009/04/22</br>
        /// </remarks>
        private int DeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<OrderPointSt> orderPointStList = new List<OrderPointSt>();

            foreach (OrderPointSt orderPointSt in this._orderPointStDicClone.Values)
            {
                orderPointStList.Add(orderPointSt);
            }

            // 物理削除
            status = this._orderPointStAcs.Delete(orderPointStList);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード変更
                        this.Mode_Label.Text = INSERT_MODE;

                        // コントロールEnabled制御
                        SetControlEnabled(INSERT_MODE);

                        // 画面クリア
                        ClearScreen(true);

                        // バッファ更新
                        this._orderPointStDicClone.Clear();

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "DeleteProc",
                                       "完全削除処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        # endregion 物理削除処理

        #region 復活処理
        /// <summary>
        /// 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 発注点設定を復活します。</br>
        /// <br>Programer  : 李占川</br>
        /// <br>Date       : 2009/04/22</br>
        /// </remarks>
        private int RevivalProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<OrderPointSt> orderPointStList = new List<OrderPointSt>();

            foreach (OrderPointSt orderPointSt in this._orderPointStDicClone.Values)
            {
                orderPointStList.Add(orderPointSt);
            }
            // 復活
            status = this._orderPointStAcs.Revival(ref orderPointStList);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // コントロールEnabled制御
                        SetControlEnabled(UPDATE_MODE);

                        // バッファ更新
                        this._orderPointStDicClone.Clear();
                        foreach (OrderPointSt orderPointSt in orderPointStList)
                        {
                            this._orderPointStDicClone.Add(orderPointSt.PatternNoDerivedNo, orderPointSt);
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "RevivalProc",
                                       "復活処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        # endregion

        # region 排他処理
        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : 排他制御を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            string errMsg = "";

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        errMsg = "既に他端末より更新されています。";
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        errMsg = "既に他端末より削除されています。";
                        break;
                    }
            }

            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           errMsg,
                           status,
                           MessageBoxButtons.OK,
                           MessageBoxDefaultButton.Button1);
        }
        # endregion 排他処理

        # region メッセージボックス表示

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                       // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSEMBLY_ID, 		  　　			// アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._orderPointStAcs,				// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }

        # endregion メッセージボックス表示

        #region 文字列編集処理

        /// <summary>
        /// カンマ・ピリオド削除処理
        /// </summary>
        /// <param name="targetText">カンマ・ピリオド削除前テキスト</param>
        /// <param name="retText">カンマ・ピリオド削除済みテキスト</param>
        /// <param name="periodDelFlg">ピリオド削除フラグ(True:カンマ・ピリオド削除  False:カンマ削除)</param>
        /// <remarks>
        /// <br>Note	   : 対象のテキストからカンマ・ピリオドを削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        private void RemoveCommaPeriod(string targetText, out string retText, bool periodDelFlg)
        {
            retText = "";

            if (targetText == string.Empty)
            {
                return;
            }
            // セル値編集用にカンマ・ピリオド削除
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                // カンマ・ピリオド削除
                if (periodDelFlg == true)
                {
                    if ((targetText[i].ToString() == ",") || (targetText[i].ToString() == "."))
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
                // カンマのみ削除
                else
                {
                    if (targetText[i].ToString() == ",")
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
            }

            retText = targetText;
        }

        /// <summary>
        /// 小数点取得処理
        /// </summary>
        /// <param name="targetText">チェック対象テキスト</param>
        /// <param name="retText">小数部分テキスト</param>
        /// <remarks>
        /// <br>Note	   : 対象のテキストから小数部分のみを返します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        private void GetDecimal(string targetText, out string retText)
        {
            retText = "";

            for (int i = targetText.IndexOf(".") + 1; i < targetText.Length; i++)
            {
                retText += targetText[i].ToString();
            }
        }

        #endregion 文字列編集処理

        # endregion Private Method

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        # region Control Event Methods
        /// <summary>
        /// ロードイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 画面がロード時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.03.31</br>
        /// </remarks>
        private void PMHAT09001UA_Load(object sender, EventArgs e)
        {
            // 画面初期化
            InitialScreenSetting();

            this.Detail_uGrid.DataSource = this._orderPointStDataTable;

            // 画面クリア処理
            this.ClearScreen(true);
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : ツールバークリック時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.01</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                        if (this.Detail_uGrid.ActiveCell != null)
                        {
                            this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        // 入力中のデータチャック
                        if (!this.CompareInputScreen())
                        {
                            return;
                        }

                        this.Close();
                        break;
                    }

                // 保存
                case TOOLBAR_SAVEBUTTON_KEY:
                    {
                        // オフライン状態チェック
                        if (!CheckOnline())
                        {
                            TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Text,
                                this.Text + "画面保存処理に失敗しました。",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                        if (this.Detail_uGrid.ActiveCell != null)
                        {
                            this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        SaveProc();
                        break;
                    }

                // 検索
                case TOOLBAR_SEARCHBUTTON_KEY:
                    {
                        SearchProc();
                        break;
                    }

                // クリア
                case TOOLBAR_CLEARBUTTON_KEY:
                    {
                        // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                        if (this.Detail_uGrid.ActiveCell != null)
                        {
                            this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        this.ClearScreen(true);
                        break;
                    }
                // 論理削除
                case TOOLBAR_LOGICALDELETE_KEY:
                    {
                        // オフライン状態チェック
                        if (!CheckOnline())
                        {
                            TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Text,
                                this.Text + "画面論理削除処理に失敗しました。",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        // 論理削除確認
                        // 論理削除確認
                        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                             "データを論理削除します。\r\nよろしいですか？",
                                                             0,
                                                             MessageBoxButtons.OKCancel,
                                                             MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }

                        LogicalDeleteProc();
                        break;
                    }
                // 削除
                case TOOLBAR_DELETE_KEY:
                    {
                        // オフライン状態チェック
                        if (!CheckOnline())
                        {
                            TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Text,
                                this.Text + "画面物理削除処理に失敗しました。",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        // 完全削除確認
                        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                             "データを物理削除します。\r\nよろしいですか？",
                                                             0,
                                                             MessageBoxButtons.OKCancel,
                                                             MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }

                        DeleteProc();
                        break;
                    }
                // 復活
                case TOOLBAR_REVIVAL_KEY:
                    {
                        // オフライン状態チェック
                        if (!CheckOnline())
                        {
                            TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Text,
                                this.Text + "画面復活処理に失敗しました。",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        RevivalProc();
                        break;
                    }
                // 行削除
                case TOOLBAR_ROWDELETE_KEY:
                    {
                        RowDelete();
                        break;
                    }
            }
        }

        /// <summary>
        /// ChangeFocus イベント(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.02</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // グリッド
            if (e.PrevCtrl == this.Detail_uGrid)
            {
                if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                {
                    if (this.Detail_uGrid.ActiveCell == null)
                    {
                        this.Detail_uGrid.PerformAction(UltraGridAction.NextCell);
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        e.NextCtrl = null;
                        return;
                    }

                    int activeRowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                    int activeColumnIndex = this.Detail_uGrid.ActiveCell.Column.Index;

                    if (e.ShiftKey == false)
                    {
                        for (int rowIndex = activeRowIndex; rowIndex < ROW_COUNT; rowIndex++)
                        {
                            if (rowIndex == activeRowIndex)
                            {
                                for (int columnIndex = activeColumnIndex + 1; columnIndex < COLUMN_COUNT; columnIndex++)
                                {
                                    if ((this.Detail_uGrid.Rows[rowIndex].Activation == Activation.AllowEdit) &&
                                        (this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activation == Activation.AllowEdit))
                                    {
                                        this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                for (int columnIndex = 1; columnIndex < COLUMN_COUNT; columnIndex++)
                                {
                                    if ((this.Detail_uGrid.Rows[rowIndex].Activation == Activation.AllowEdit) &&
                                        (this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activation == Activation.AllowEdit))
                                    {
                                        this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        return;
                                    }
                                }
                            }
                        }

                        // gridの最後のcell
                        if ((activeRowIndex + 1 == ROW_COUNT) && (activeColumnIndex + 1 == COLUMN_COUNT))
                        {
                            e.NextCtrl = this.tNedit_PatterNo;
                            return;
                        }
                    }
                    else
                    {
                        for (int rowIndex = activeRowIndex; rowIndex >= 0; rowIndex--)
                        {
                            if (rowIndex == activeRowIndex)
                            {
                                for (int columnIndex = activeColumnIndex - 1; columnIndex >= 1; columnIndex--)
                                {
                                    if ((this.Detail_uGrid.Rows[rowIndex].Activation == Activation.AllowEdit) &&
                                        (this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activation == Activation.AllowEdit))
                                    {
                                        this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                for (int columnIndex = COLUMN_COUNT - 1; columnIndex >= 1; columnIndex--)
                                {
                                    if ((this.Detail_uGrid.Rows[rowIndex].Activation == Activation.AllowEdit) &&
                                        (this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activation == Activation.AllowEdit))
                                    {
                                        this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // 設定コード
            else if (e.PrevCtrl == this.tNedit_PatterNo)
            {
                // フォーカス設定
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.tEdit_WarehouseCode;
                    }
                }
                else
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.Detail_uGrid;
                        this.Detail_uGrid.Rows[ROW_COUNT - 1].Cells[COLUMN_SALESORDERUNIT].Activate();
                    }
                }

                int patterNo = this.tNedit_PatterNo.GetInt();

                // 設定コードが変わらないとき
                if (patterNo == this._prevPatterNo)
                {
                    return;
                }

                // 設定コードが空場合
                if (patterNo == 0)
                {
                    // 警告
                    this.ClearScreen(true);
                    return;
                }

                if (SearchProc() != -1)
                {
                    this._prevPatterNo = patterNo;
                }
            }
            // 倉庫コード
            else if (e.PrevCtrl == this.tEdit_WarehouseCode)
            {
                // 倉庫コード取得
                string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim();

                // 入力しない
                if (warehouseCode == string.Empty)
                {
                    this._prevWarehouseCode = string.Empty;
                    return;
                }

                if (this._warehouseDic == null)
                {
                    // 倉庫マスタ読込処理
                    LoadWarehouse();
                }

                bool existFlag = false;

                if (this._warehouseDic.ContainsKey(warehouseCode.PadLeft(4, '0')))
                {
                    this._prevWarehouseCode = warehouseCode.PadLeft(4, '0');
                    existFlag = true;
                }
                else
                {
                    existFlag = false;
                    this.tEdit_WarehouseCode.DataText = this._prevWarehouseCode;
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                         , this.ToString()
                         , "指定された条件の倉庫コードは存在しませんでした。"
                         , 0
                         , MessageBoxButtons.OK);
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (existFlag)
                        {
                            e.NextCtrl = this.tNedit_GoodsMGroup;
                        }
                        else
                        {
                            // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                            // e.NextCtrl = this.WarehouseGuide_Button;
                            e.NextCtrl = e.PrevCtrl;
                            // ↑ 2009.07.07 劉洋
                        }
                    }
                }
            }
            // 中分類コード
            else if (e.PrevCtrl == this.tNedit_GoodsMGroup)
            {
                // 中分類コード取得
                int goodsMGroupCode = this.tNedit_GoodsMGroup.GetInt();

                // 入力しない
                if (this.tNedit_GoodsMGroup.DataText == string.Empty)
                {
                    this._prevGoodsMGroupCd = 0;
                    return;
                }

                // 中分類コードマスタの検索
                if (this._goodsGroupUDic == null)
                {
                    // 中分類マスタ読込処理
                    LoadGoodsGroupU();
                }

                bool existFlag = false;

                if (_goodsGroupUDic.ContainsKey(goodsMGroupCode))
                {
                    this._prevGoodsMGroupCd = goodsMGroupCode;
                    existFlag = true;
                }
                else
                {
                    existFlag = false;
                    this.tNedit_GoodsMGroup.SetInt(this._prevGoodsMGroupCd);
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                         , this.ToString()
                         , "指定された条件の中分類コードは存在しませんでした。"
                         , 0
                         , MessageBoxButtons.OK);
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (existFlag)
                        {
                            e.NextCtrl = this.tNedit_SupplierCd;
                        }
                        else
                        {
                            // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                            // e.NextCtrl = this.GoodsMGroupGuide_Button;
                            e.NextCtrl = e.PrevCtrl;
                            // ↑ 2009.07.07 劉洋
                        }
                    }
                }

            }
            // 仕入先コード
            else if (e.PrevCtrl == this.tNedit_SupplierCd)
            {
                // 仕入先コード取得
                int supplierCode = this.tNedit_SupplierCd.GetInt();

                // 入力しない
                if (this.tNedit_SupplierCd.DataText == string.Empty)
                {
                    this._prevSupplierCd = 0;
                    return;
                }

                // 仕入先コードマスタの検索
                if (this._supplierDic == null)
                {
                    // 仕入先マスタ読込処理
                    LoadSupplier();
                }

                bool existFlag = false;

                if (_supplierDic.ContainsKey(supplierCode))
                {
                    this._prevSupplierCd = supplierCode;
                    existFlag = true;
                }
                else
                {
                    existFlag = false;
                    this.tNedit_SupplierCd.SetInt(this._prevSupplierCd);
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                         , this.ToString()
                         , "指定された条件の仕入先コードは存在しませんでした。"
                         , 0
                         , MessageBoxButtons.OK);
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (existFlag)
                        {
                            e.NextCtrl = this.tNedit_BLGloupCode;
                        }
                        else
                        {
                            // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                            // e.NextCtrl = this.SupplierGuide_Button;
                            e.NextCtrl = e.PrevCtrl;
                            // ↑ 2009.07.07 劉洋
                        }
                    }
                }
            }
            // グループコード
            else if (e.PrevCtrl == this.tNedit_BLGloupCode)
            {
                // グループコード取得
                int groupCode = this.tNedit_BLGloupCode.GetInt();

                // 入力しない
                if (this.tNedit_BLGloupCode.DataText == string.Empty)
                {
                    this._prevBLGroupCode = 0;
                    return;
                }

                // グループコードマスタの検索
                if (this._blGroupUDic == null)
                {
                    // グループコードマスタ読込処理
                    LoadBLGroupU();
                }

                bool existFlag = false;

                if (this._blGroupUDic.ContainsKey(groupCode))
                {
                    this._prevBLGroupCode = groupCode;
                    existFlag = true;
                }
                else
                {
                    existFlag = false;

                    this.tNedit_BLGloupCode.SetInt(this._prevBLGroupCode);
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                         , this.ToString()
                         , "指定された条件のグループコードは存在しませんでした。"
                         , 0
                         , MessageBoxButtons.OK);
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (existFlag)
                        {
                            e.NextCtrl = this.tNedit_GoodsMakerCd;
                        }
                        else
                        {
                            // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                            // e.NextCtrl = this.BLGroupGuide_Button;
                            e.NextCtrl = e.PrevCtrl;
                            // ↑ 2009.07.07 劉洋
                        }
                    }
                }
            }
            // メーカーコード
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd)
            {
                // メーカーコード取得
                int makerCode = this.tNedit_GoodsMakerCd.GetInt();

                // 入力しない
                if (this.tNedit_GoodsMakerCd.DataText == string.Empty)
                {
                    this._prevMakerCode = 0;
                    return;
                }

                // メーカーコードマスタの検索
                if (this._makerUMntDic == null)
                {
                    // メーカーマスタ読込処理
                    LoadMakerUMnt();
                }

                bool existFlag = false;

                if (this._makerUMntDic.ContainsKey(makerCode))
                {
                    this._prevMakerCode = makerCode;
                    existFlag = true;
                }
                else
                {
                    existFlag = false;

                    this.tNedit_GoodsMakerCd.SetInt(this._prevMakerCode);
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                         , this.ToString()
                         , "指定された条件のメーカーコードは存在しませんでした。"
                         , 0
                         , MessageBoxButtons.OK);
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (existFlag)
                        {
                            e.NextCtrl = this.tNedit_BLGoodsCode;
                        }
                        else
                        {
                            // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                            // e.NextCtrl = this.MakerGuide_Button;
                            e.NextCtrl = e.PrevCtrl;
                            // ↑ 2009.07.07 劉洋 modify
                        }
                    }
                }
            }
            // BLコード
            else if (e.PrevCtrl == this.tNedit_BLGoodsCode)
            {
                // BLコード取得
                int bLGoodsCode = this.tNedit_BLGoodsCode.GetInt();

                // 入力しない
                if (this.tNedit_BLGoodsCode.DataText == string.Empty)
                {
                    this._prevBLGoodsCode = 0;
                    return;
                }

                // BLコードマスタの検索
                if (this._blGoodsCdUMntDic == null)
                {
                    // BLコードマスタ読込処理
                    LoadBLGoodsCdUMnt();
                }

                bool existFlag = false;

                if (this._blGoodsCdUMntDic.ContainsKey(bLGoodsCode))
                {
                    this._prevBLGoodsCode = bLGoodsCode;
                    existFlag = true;
                }
                else
                {
                    existFlag = false;

                    this.tNedit_BLGoodsCode.SetInt(this._prevBLGoodsCode);
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                         , this.ToString()
                         , "指定された条件のBLコードは存在しませんでした。"
                         , 0
                         , MessageBoxButtons.OK);
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (existFlag)
                        {
                            e.NextCtrl = this.tDateEdit_StckShipMonthSt;
                        }
                        else
                        {
                            // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                            // e.NextCtrl = this.BLGoodsCdGuide_Button;
                            e.NextCtrl = e.PrevCtrl;
                            // ↑ 2009.07.07 劉洋 modify
                        }
                    }
                }
            }
            // BLガイド
            else if (e.PrevCtrl == this.BLGoodsCdGuide_Button)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = this.tDateEdit_StckShipMonthSt;
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = this.tNedit_BLGoodsCode;
                    }
                }
            }
            else if (e.PrevCtrl == this.tComboEditor_OrderApplyDiv)
            {
                // フォーカス設定
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.Detail_uGrid;
                    }
                }
            }

            if (e.NextCtrl == this.Detail_uGrid)
            {
                e.NextCtrl = null;

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                    {
                        this.Detail_uGrid.Rows[0].Cells[COLUMN_SHIPSCOPEMORE].Activate();
                    }
                }
                else
                {
                    this.Detail_uGrid.Rows[ROW_COUNT].Cells[COLUMN_SALESORDERUNIT].Activate();
                }

                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            }

        }

        /// <summary>
        /// Button_Click イベント(SupplierGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 倉庫ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.02</br>
        /// </remarks>
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Warehouse warehouse = null;

                int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode, this._loginSectionCode);

                if (status == 0)
                {
                    // 入力データと前回データは違い場合
                    if (warehouse.WarehouseCode != this._prevWarehouseCode)
                    {
                        this._prevWarehouseCode = warehouse.WarehouseCode.Trim();

                        this.tEdit_WarehouseCode.DataText = warehouse.WarehouseCode.Trim();
                        this.tNedit_GoodsMGroup.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(MGroupGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 中分類ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void MGroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                GoodsGroupU goodsGroupU = new GoodsGroupU();

                // 中分類ガイド表示
                status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);
                if (status == 0)
                {
                    if (goodsGroupU.GoodsMGroup != this._prevGoodsMGroupCd)
                    {
                        this._prevGoodsMGroupCd = goodsGroupU.GoodsMGroup;

                        // 中分類コード
                        this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);

                        this.tNedit_SupplierCd.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(SupplierGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 仕入先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                Supplier supplier = null;

                // 仕入先ガイド表示
                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, this._loginSectionCode);
                if (status == 0)
                {
                    if (supplier.SupplierCd != this._prevSupplierCd)
                    {
                        this._prevSupplierCd = supplier.SupplierCd;

                        // 仕入先コード
                        this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);

                        this.tNedit_BLGloupCode.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(GroupGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: グループガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void GroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGroupU blGroupU = new BLGroupU();

                // BLグループガイド表示
                status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
                if (status == 0)
                {
                    if (blGroupU.BLGroupCode != this._prevBLGroupCode)
                    {
                        this._prevBLGroupCode = blGroupU.BLGroupCode;

                        // BLグループコード
                        this.tNedit_BLGloupCode.SetInt(blGroupU.BLGroupCode);

                        this.tNedit_GoodsMakerCd.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(MakerGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: メーカーガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                MakerUMnt makerUMnt = new MakerUMnt();

                // メーカーガイド表示
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if (makerUMnt.GoodsMakerCd != this._prevMakerCode)
                    {
                        this._prevMakerCode = makerUMnt.GoodsMakerCd;

                        // メーカーコード
                        this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);

                        this.tNedit_BLGoodsCode.Focus();
                    }
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(BLGoodsGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: BLコードガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void BLGroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGoodsCdUMnt blGoodsCdUMnt = null;

                // BLコードガイド表示
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    if (blGoodsCdUMnt.BLGoodsCode != this._prevBLGoodsCode)
                    {
                        this._prevBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;

                        // BLコード
                        this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);

                        this.tDateEdit_StckShipMonthSt.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// KeyDownイベント(tNedit_PatterNo)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 設定コードされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void tNedit_PatterNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                int patterNo = this.tNedit_PatterNo.GetInt();
                // 設定コードが空場合
                if (patterNo == 0)
                {
                    // 警告
                    this.ClearScreen(true);
                    return;
                }

                if (SearchProc() != -1)
                {
                    this._prevPatterNo = patterNo;
                }
            }
        }
        # endregion

        // ===================================================================================== //
        // Detail_uGridの関連処理
        // ===================================================================================== //
        # region Detail_uGridの関連処理
        /// <summary>
        /// グリッド初期レイアウト設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化時、グリッド初期レイアウト設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void Detail_uGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // グリッド列初期設定処理
            this.InitialSettingGridCol();
        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化の時、グリッド列初期設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.Detail_uGrid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            editBand.ColHeadersVisible = false;

            // 表示幅設定
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].Width = 45;
            editBand.Columns[this._orderPointStDataTable.ShipScopeMoreColumn.ColumnName].Width = 130;
            editBand.Columns[this._orderPointStDataTable.ShipScopeLessColumn.ColumnName].Width = 130;
            editBand.Columns[this._orderPointStDataTable.MinimumStockCntColumn.ColumnName].Width = 130;
            editBand.Columns[this._orderPointStDataTable.MaximumStockCntColumn.ColumnName].Width = 130;
            editBand.Columns[this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName].Width = 110;

            //---------------------------------------------------------------------
            // 入力許可設定
            //---------------------------------------------------------------------
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[this._orderPointStDataTable.ShipScopeMoreColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            editBand.Columns[this._orderPointStDataTable.ShipScopeLessColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            editBand.Columns[this._orderPointStDataTable.MinimumStockCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            editBand.Columns[this._orderPointStDataTable.MaximumStockCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            editBand.Columns[this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

            // 固定列設定
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].Header.Fixed = true;
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[this._orderPointStDataTable.ShipScopeMoreColumn.ColumnName].Header.Fixed = true;
            editBand.Columns[this._orderPointStDataTable.ShipScopeMoreColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[this._orderPointStDataTable.ShipScopeLessColumn.ColumnName].Header.Fixed = true;
            editBand.Columns[this._orderPointStDataTable.ShipScopeLessColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[this._orderPointStDataTable.MinimumStockCntColumn.ColumnName].Header.Fixed = true;
            editBand.Columns[this._orderPointStDataTable.MinimumStockCntColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[this._orderPointStDataTable.MaximumStockCntColumn.ColumnName].Header.Fixed = true;
            editBand.Columns[this._orderPointStDataTable.MaximumStockCntColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName].Header.Fixed = true;
            editBand.Columns[this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            // 詰め
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[this._orderPointStDataTable.ShipScopeMoreColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[this._orderPointStDataTable.ShipScopeLessColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[this._orderPointStDataTable.MinimumStockCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[this._orderPointStDataTable.MaximumStockCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // RowNo設定
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.BackColor2;
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor;
            editBand.Columns[this._orderPointStDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor;
        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドからフォーカスが離れた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void Detail_uGrid_Leave(object sender, EventArgs e)
        {
            this.Detail_uGrid.ActiveCell = null;
            this.Detail_uGrid.ActiveRow = null;
        }

        /// <summary>
        /// グリッドマウスクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドからフォーカスが離れた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.04.07</br>
        /// </remarks>
        private void Detail_uGrid_MouseClick(object sender, MouseEventArgs e)
        {
            // 右クリック以外の場合
            if (e.Button != MouseButtons.Right) return;

            if (this.Detail_uGrid.ActiveRow == null) return;

            System.Drawing.Point nowPos = new Point(e.X, e.Y);

            Infragistics.Win.UIElement objElement = this.Detail_uGrid.DisplayLayout.UIElement.ElementFromPoint(nowPos);

            // クリック位置が列ヘッダーか判定
            bool isColumnHeader = false;

            if (objElement != null)
            {
                if ((objElement.SelectableItem is Infragistics.Win.UltraWinGrid.ColumnHeader) ||
                    (objElement is Infragistics.Win.UltraWinGrid.HeaderUIElement))
                {
                    isColumnHeader = true;
                    // string columnName = ((Infragistics.Win.UltraWinGrid.ColumnHeader)objElement.SelectableItem).Column.Key;
                }
            }

            if (isColumnHeader)
            {
                // 列ヘッダー右クリック時は何もしない
            }
            else
            {
                // それ以外で右クリックされた場合は、編集のポップアップを表示する
                ((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_MainMenu.Tools["PopupMenuTool_grid"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.Detail_uGrid);

                if ((this.Detail_uGrid.ActiveCell == null) && (this.Detail_uGrid.ActiveRow != null))
                {
                    if (this.Detail_uGrid.ActiveRow.Selected)
                    {
                        //
                    }
                    else
                    {
                        this.Detail_uGrid.Selected.Rows.Clear();
                        this.Detail_uGrid.ActiveRow.Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// Gridデータ変化の判断
        /// </summary>
        /// <returns>Gridデータ変化の判断結果</returns>
        /// <remarks>
        /// <br>Note        : Gridデータ変化する時処理を行います。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool CompareDetailGrid()
        {
            List<OrderPointSt> orderPointStList = new List<OrderPointSt>();
            ScreenToOrderPointStList(ref orderPointStList);

            if (orderPointStList.Count != this._orderPointStDicClone.Count)
            {
                return true;
            }

            foreach (OrderPointSt orderPointSt in orderPointStList)
            {
                int patternNoDerivedNo = orderPointSt.PatternNoDerivedNo;
                if (!this._orderPointStDicClone.ContainsKey(patternNoDerivedNo))
                {
                    return true;
                }

                if (orderPointSt.ShipScopeMore != this._orderPointStDicClone[patternNoDerivedNo].ShipScopeMore
                    || orderPointSt.ShipScopeLess != this._orderPointStDicClone[patternNoDerivedNo].ShipScopeLess
                    || orderPointSt.MinimumStockCnt != this._orderPointStDicClone[patternNoDerivedNo].MinimumStockCnt
                    || orderPointSt.MaximumStockCnt != this._orderPointStDicClone[patternNoDerivedNo].MaximumStockCnt
                    || orderPointSt.SalesOrderUnit != this._orderPointStDicClone[patternNoDerivedNo].SalesOrderUnit)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>Double型</returns>
        /// <remarks>
        /// <br>Note        : セル値をDouble型に変換します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private double ChangeCellValueToDouble(object cellValue)
        {
            // cellValueが入力しない場合
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return double.Parse((string)cellValue);
            }
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>Int型</returns>
        /// <remarks>
        /// <br>Note        : セル値をInt型に変換します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private int ChangeCellValueToInt(object cellValue)
        {
            // cellValueが入力しない場合
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                double value = double.Parse((string)cellValue);
                return Convert.ToInt32(value);
            }
        }

        /// <summary>
        /// グリッドの在庫数チェック処理
        /// </summary>
        /// <param name="errMsg">errMsg</param>
        /// <remarks>
        /// <br>Note       : グリッドの在庫数チェック処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private bool CheckGridStockCnt(ref string errMsg)
        {
            bool bstatus = true;
            int inputDataNum = 0;

            DataRowCollection rows = this._orderPointStDataTable.Rows;

            for (int i = 0; i < rows.Count; i++)
            {
                OrderPointStDataSet.OrderPointStRow row = (OrderPointStDataSet.OrderPointStRow)rows[i];

                // 入力データを取得
                double shipScopeMore = this.ChangeCellValueToDouble(row[this._orderPointStDataTable.ShipScopeMoreColumn]);
                double shipScopeLess = this.ChangeCellValueToDouble(row[this._orderPointStDataTable.ShipScopeLessColumn]);
                double minimumStockCnt = this.ChangeCellValueToDouble(row[this._orderPointStDataTable.MinimumStockCntColumn]);
                double maximumStockCnt = this.ChangeCellValueToDouble(row[this._orderPointStDataTable.MaximumStockCntColumn]);
                int salesOrderUnit = this.ChangeCellValueToInt(row[this._orderPointStDataTable.SalesOrderUnitColumn]);

                // 入力しない場合
                if (shipScopeMore == 0 && shipScopeLess == 0
                    && minimumStockCnt == 0 & maximumStockCnt == 0
                    && salesOrderUnit == 0)
                {
                    continue;
                }

                inputDataNum++;

                // 以上＜以下チェック
                if (shipScopeMore > shipScopeLess)
                {
                    errMsg = (i + 1) + "行目で在出荷数の範囲の入力が不正です。";

                    bstatus = false;
                    break;
                }

                // 最低数＞最高数
                if (minimumStockCnt > maximumStockCnt)
                {
                    errMsg = (i + 1) + "行目で最低数と最高数の範囲の入力が不正です。";

                    bstatus = false;
                    break;
                }

                // 最高数＜ロット数
                if (maximumStockCnt < salesOrderUnit)
                {
                    errMsg = (i + 1) + "行目で最高数とロット数の範囲の入力が不正です。";

                    bstatus = false;
                    break;
                }

                // 在庫出荷数他明細との範囲重複チェック
                for (int j = 0; j < i; j++)
                {
                    OrderPointStDataSet.OrderPointStRow compareRow = (OrderPointStDataSet.OrderPointStRow)rows[j];

                    double compareShipScopeMore = this.ChangeCellValueToDouble(compareRow[this._orderPointStDataTable.ShipScopeMoreColumn]);
                    double compareShipScopeLess = this.ChangeCellValueToDouble(compareRow[this._orderPointStDataTable.ShipScopeLessColumn]);
                    double compareMinimumStockCnt = this.ChangeCellValueToDouble(compareRow[this._orderPointStDataTable.MinimumStockCntColumn]);
                    double compareMaximumStockCnt = this.ChangeCellValueToDouble(compareRow[this._orderPointStDataTable.MaximumStockCntColumn]);
                    int compareSalesOrderUnit = this.ChangeCellValueToInt(compareRow[this._orderPointStDataTable.SalesOrderUnitColumn]);


                    if (compareShipScopeMore == 0
                        && compareShipScopeLess == 0
                        && compareMinimumStockCnt == 0
                        && compareMaximumStockCnt == 0
                        && compareSalesOrderUnit == 0)
                    {
                        continue;
                    }

                    // 範囲重複チェック
                    if ((shipScopeMore >= compareShipScopeMore && shipScopeMore <= compareShipScopeLess)
                        || (shipScopeLess >= compareShipScopeMore && shipScopeLess <= compareShipScopeLess)
                        || (shipScopeMore < compareShipScopeMore && shipScopeLess > compareShipScopeLess))
                    {
                        errMsg = (i + 1) + "行目で" + (j + 1) + "行目と出荷数の範囲が重複します。";

                        bstatus = false;
                        break;
                    }
                }

                if (!errMsg.Equals(""))
                {
                    bstatus = false;
                    break;
                }
            }

            if (inputDataNum == 0)
            {
                errMsg = "保存対象データが存在しません。";
                bstatus = false;
            }
            return bstatus;
        }

        /// <summary>
        /// AfterEnterEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルが編集モードになった時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private void Detail_uGrid_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                return;
            }

            if ((this.Detail_uGrid.ActiveCell.Value == DBNull.Value) ||
                ((string)this.Detail_uGrid.ActiveCell.Value == ""))
            {
                return;
            }

            string retText;
            string targetText = (string)this.Detail_uGrid.ActiveCell.Value;

            // カンマのみ削除
            RemoveCommaPeriod(targetText, out retText, false);

            this.Detail_uGrid.ActiveCell.Value = retText;
            this.Detail_uGrid.ActiveCell.SelStart = 0;
            this.Detail_uGrid.ActiveCell.SelLength = retText.Length;
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private void Detail_uGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                return;
            }

            try
            {
                if ((this.Detail_uGrid.ActiveCell.Value != DBNull.Value) &&
                     ((string)this.Detail_uGrid.ActiveCell.Value != ""))
                {
                    string retText;
                    string targetText = (string)this.Detail_uGrid.ActiveCell.Value;

                    // カンマのみ削除
                    RemoveCommaPeriod(targetText, out retText, false);

                    double targetValue = double.Parse(retText);

                    UltraGridCell cell = this.Detail_uGrid.ActiveCell;

                    if (cell.Column.Key == this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName)
                    {
                        this.Detail_uGrid.ActiveCell.Value = targetValue.ToString(FORMAT_NUM2);
                    }
                    else
                    {
                        this.Detail_uGrid.ActiveCell.Value = targetValue.ToString(FORMAT_NUM);
                    }
                }
            }
            catch
            {
                this.Detail_uGrid.ActiveCell.Value = string.Empty;
            }

            //if (this.Detail_uGrid.ActiveCell.Column.Key == this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName)
            //{
            //    int intNum = ChangeCellValueToInt(this.Detail_uGrid.ActiveCell.Value);
            //    // 0は空白表示
            //    if (intNum == 0)
            //    {
            //        this.Detail_uGrid.ActiveCell.Value = string.Empty;
            //    }
            //}
            //else
            //{
            //    // 入力値取得
            //    double num = ChangeCellValueToDouble(this.Detail_uGrid.ActiveCell.Value);

            //    // 0は空白表示
            //    if (num == 0)
            //    {
            //       this.Detail_uGrid.ActiveCell.Value = string.Empty;
            //    }
            //}
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private void Detail_uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (this.Detail_uGrid.ActiveCell == null)
            {
                if (this.Detail_uGrid.ActiveRow == null)
                {
                    rowIndex = 0;
                    columnIndex = 1;
                }
                else
                {
                    rowIndex = this.Detail_uGrid.ActiveRow.Index;
                    columnIndex = 1;
                }
            }
            else
            {
                rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                columnIndex = this.Detail_uGrid.ActiveCell.Column.Index;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        e.Handled = true;

                        if (rowIndex == 0)
                        {
                            this.tComboEditor_OrderApplyDiv.Focus();
                        }
                        else
                        {
                            this.Detail_uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex < ROW_COUNT - 1)
                        {
                            this.Detail_uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (this.Detail_uGrid.ActiveCell.IsInEditMode)
                        {
                            if (this.Detail_uGrid.ActiveCell.SelStart == 0)
                            {
                                e.Handled = true;

                                //if (columnIndex <= 1)
                                //{
                                //    //int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                                //    //if (targetContrastCd == 45)
                                //    //{
                                //    //    this.EnterpriseGanreGuide_Button.Focus();
                                //    //}
                                //    //else
                                //    //{
                                //    //    this.SectionGuide_Button.Focus();
                                //    //}
                                //}
                                //else
                                //{
                                //    this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                                //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                //}

                                if (columnIndex == 1 && rowIndex == 0)
                                {
                                    this.tComboEditor_OrderApplyDiv.Focus();
                                }
                                else if (columnIndex == 1)
                                {
                                    this.Detail_uGrid.Rows[rowIndex - 1].Cells[COLUMN_COUNT - 1].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (this.Detail_uGrid.ActiveCell.IsInEditMode)
                        {
                            if (this.Detail_uGrid.ActiveCell.SelStart >= this.Detail_uGrid.ActiveCell.Text.Length)
                            {
                                e.Handled = true;

                                if (columnIndex == COLUMN_COUNT - 1 && rowIndex == ROW_COUNT - 1)
                                {
                                    this.tNedit_PatterNo.Focus();
                                }
                                else if (columnIndex == COLUMN_COUNT - 1)
                                {
                                    this.Detail_uGrid.Rows[rowIndex + 1].Cells[1].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex + 1].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
        private void Detail_uGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = this.Detail_uGrid.ActiveCell;

            // ActiveCellがロットの場合
            if (cell.Column.Key == this._orderPointStDataTable.SalesOrderUnitColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    // ZZ9.99
                    if (!KeyPressNumCheck(6, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            else
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    // ZZ9.99
                    if (!KeyPressNumCheck(9, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
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
        /// <remarks>
        /// <br>Note        : 数値の入力チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/08</br>
        /// </remarks>
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

            // キーが押されたと仮定した場合の文字列を生成する。
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
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
                int _pointPos = strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
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
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        # region 行の削除処理の関連処理
        /// <summary>
        /// 行削除処理
        /// </summary>
        private void RowDelete()
        {
            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "選択行を削除してもよろしいですか？",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            int rowIndex = this.GetActiveRowIndex();

            if (rowIndex == -1)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._orderPointStDataTable.BeginLoadData();
                OrderPointStDataSet.OrderPointStRow targetRow = (OrderPointStDataSet.OrderPointStRow)this._orderPointStDataTable.Rows[rowIndex];
                this._orderPointStDataTable.RemoveOrderPointStRow(targetRow);

                this.InitializeDetailRowNoColumn();

                this.FillDetailRow();

                this._orderPointStDataTable.EndLoadData();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ActiveRowインデックス取得処理
        /// </summary>
        /// <returns>ActiveRowインデックス</returns>
        private int GetActiveRowIndex()
        {
            if (this.Detail_uGrid.ActiveCell != null)
            {
                return this.Detail_uGrid.ActiveCell.Row.Index;
            }
            else if (this.Detail_uGrid.ActiveRow != null)
            {
                return this.Detail_uGrid.ActiveRow.Index;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 明細データテーブルRowNo列初期化処理
        /// </summary>
        public void InitializeDetailRowNoColumn()
        {
            this._orderPointStDataTable.BeginLoadData();
            for (int i = 0; i < this._orderPointStDataTable.Rows.Count; i++)
            {
                if (this._orderPointStDataTable[i].RowNo != 0)
                {
                    // 元の行番号より新しい行番号を取得する
                    this._orderPointStDataTable[i].RowNo = i + 1;
                }
            }
            this._orderPointStDataTable.EndLoadData();
        }

        /// <summary>
        /// 明細行追加処理
        /// </summary>
        public void FillDetailRow()
        {
            int rowCount = this._orderPointStDataTable.Rows.Count;

            for (int index = rowCount; index < ROW_COUNT; index++)
            {
                OrderPointStDataSet.OrderPointStRow row = this._orderPointStDataTable.NewOrderPointStRow();
                row.RowNo = index + 1;
                this._orderPointStDataTable.AddOrderPointStRow(row);
            }
        }
        # endregion 行の削除処理の関連処理
        # endregion

        #region ◎ オフライン状態チェック処理
        /// <summary>				
        /// ログオン時オンライン状態チェック処理				
        /// </summary>				
        /// <returns>チェック処理結果</returns>				
        public static bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定				
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>				
        /// リモート接続可能判定				
        /// </summary>				
        /// <returns>判定結果</returns>				
        private static bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態				
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}