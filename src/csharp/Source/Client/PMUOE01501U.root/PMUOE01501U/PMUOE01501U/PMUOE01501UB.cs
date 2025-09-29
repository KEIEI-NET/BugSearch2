//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注処理
// プログラム概要   : 発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/06/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2012/02/06  修正内容 : 2012/03/28配信分 Redmine#28287の対応
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : wangyl
// 修 正 日  2013/02/06  修正内容 : 10900690-00 2013/03/13配信分の緊急対応
//                                  Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 発注処理 明細コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注処理の明細入力を行うコントロールクラスです。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009/06/01</br>
    /// <br></br>
    /// <br>UpdateNote :</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
    /// <br>              Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
    /// </remarks>
    public partial class PMUOE01501UB : UserControl
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constroctors
        /// <summary>
        /// 入力明細入力コントロールクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入力明細入力コントロールクラス デフォルトを行うコントロールクラスです。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// <br></br>
        /// <br>UpdateNote :</br>
        /// </remarks>
        public PMUOE01501UB()
        {
            InitializeComponent();

            // ボタン初期化
            this._rowSelectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowSelect"];
            this._rowCancellButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowCancell"];

            this._imageList16 = IconResourceManagement.ImageList16;
            this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            this._supplierAcs = SupplierAcs.GetInstance();
            this._orderDataTable = this._supplierAcs.orderDataTable;

        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members

        private Image _guideButtonImage;
        //ボタン定義
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowSelectButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowCancellButton;

        //カラー定義
        private static readonly Color READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

        private ImageList _imageList16 = null;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        private SupplierAcs _supplierAcs;
        private StockInputDataSet.OrderExpansionDataTable _orderDataTable;

        //ヘッダー部画面入力クラス
        private InpHedDisplay _inpHedDisplay = null;

        //業務区分
        private int _businessCode = ctTerminalDiv_Order;

        //グリッド入力前値
        private double _beforeAcceptAnOrderCnt = 0;	//数量  //ADD BY 凌小青 on 2012/02/06 for Redmine#28287
        # endregion

        //-------ADD BY 凌小青 on 2012/02/06 for Redmine#28287--------->>>>>>>
        // ===================================================================================== //
        // スタティック変数
        // ===================================================================================== //
        #region static 変数
        /// <summary>数量可入力フラグ</summary>
        public static bool _countFlg = false;
        #endregion
        //-------ADD BY 凌小青 on 2012/02/06 for Redmine#28287---------<<<<<<<

        // ===================================================================================== //

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        # region 業務区分
        /// <summary>
        /// 業務区分
        /// </summary>
        public int BusinessCode
        {
            get
            {
                return this._businessCode;
            }
            set
            {
                this._businessCode = value;
            }
        }
        # endregion
        # endregion

        // ===================================================================================== //
        // 定数
        // ===================================================================================== //
        # region Const Members
        //業務区分
        private const Int32 ctTerminalDiv_Order = 1;	//発注
        private const Int32 ctTerminalDiv_Cancel = 2;//取消処理

        //システム区分
        private const Int32 ctSysDiv_Input = 0;	//手入力
        private const Int32 ctSysDiv_Slip = 1;	//伝発発注
        private const Int32 ctSysDiv_Srch = 2;	//検索発注
        private const Int32 ctSysDiv_stock = 3;	//在庫一括
        # endregion

        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        # region private Control Event Methods

        #region ■Loadイベント
        private void PMUOE01501UB_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.DataSource = this._orderDataTable;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // グリッドキーマッピング設定処理
            this.MakeKeyMappingForGrid(this.uGrid_Details);

            // クリア処理
            this.Clear();
        }
        #endregion

        # region 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       :  画面初期化処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        internal void Clear()
        {
            // DataTable行クリア処理
            this._orderDataTable.Rows.Clear();

            // 明細グリッドセル設定処理
            this.SettingGrid();
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       :  画面初期化処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        internal void ClearUltr()
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                if (!this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || (this.uGrid_Details.ActiveCell == null))
                {
                    if (this.uGrid_Details.Rows.Count > 0)
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[this._orderDataTable.GoodsNoColumn.ColumnName];
                        // 次入力可能セル移動処理
                        this.MoveNextAllowEditCell(true);
                    }
                }
            }
        }
        # endregion

        # region ボタン初期設定処理
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       :  ボタン初期設定処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            //ImageList
            this.uButton_Select.ImageList = this._imageList16;
            this.uButton_Cancell.ImageList = this._imageList16;
            this.uButton_Guide.ImageList = this._imageList16;
            this.tToolbarsManager_Main.ImageListSmall = this._imageList16;

            //Appearance.Image
            this.uButton_Select.Appearance.Image = (int)Size16_Index.SELECT;
            this.uButton_Cancell.Appearance.Image = (int)Size16_Index.DELETE;
            this.uButton_Guide.Appearance.Image = (int)Size16_Index.GUIDE;

            //選択許可設定
            this.uButton_Select.Enabled = false;
            this.uButton_Cancell.Enabled = false;
            this.uButton_Guide.Enabled = false;

            //Appearance.Image
            this._rowSelectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SELECT;
            this._rowCancellButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
        }

        # endregion ボタン初期設定処理

        # region グリッドキーマッピング設定処理
        /// <summary>
        /// グリッドキーマッピング設定処理
        /// </summary>
        /// <param name="grid">設定対象のグリッド</param>
        /// <remarks>
        /// <br>Note       :  グリッドキーマッピング設定処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
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
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- Shift + Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↑キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↓キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- 前頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- 次頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);
        }
        # endregion

        # region ■ ヘッダー部のクリア
        /// <summary>
        /// ヘッダー部のクリア
        /// </summary>
        /// <remarks>
        /// <br>Note       : ヘッダー部のクリア処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        public void ClearHedaerItem()
        {
            _inpHedDisplay = null;

            this.tEdit_EmployeeCode.Clear();
            this.tEdit_UoeRemark1.Clear();
            this.tEdit_EmployeeName.Clear();

            this.tEdit_EmployeeCode.Enabled = false; //依頼者コード
            this.tEdit_EmployeeName.Enabled = false; //依頼者
            this.tEdit_UoeRemark1.Enabled = false; //ＵＯＥリマーク１
        }
        # endregion

        # region 明細グリッド設定処理
        /// <summary>
        /// 明細グリッド設定処理
        /// </summary>
        /// <param name="businessCode">業務区分</param>
        /// <remarks>
        /// <br>Note       : 明細グリッド設定処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        internal void SettingGrid(int businessCode)
        {
            BusinessCode = businessCode;
            SettingGrid();
        }

        /// <summary>
        /// 明細グリッド設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細グリッド設定処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// <br>Update Note: 2012/02/06 凌小青</br>
        /// <br>管理番号   ：2012/03/28配信分</br>
        /// <br>             Redmine#28287の対応</br>
        /// </remarks>
        internal void SettingGrid()
        {
            try
            {
                // 描画を一時停止
                this.uGrid_Details.BeginUpdate();

                //-------ADD BY 凌小青 on 2012/02/06 for Redmine#28287--------->>>>>>>>
                // 数量可入力チェック
                if (_countFlg)
                {
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else
                {
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                }
                //-------ADD BY 凌小青 on 2012/02/06 for Redmine#28287---------<<<<<<<<

                this.tToolbarsManager_Main.Enabled = true;

                // 描画が必要な明細件数を取得する。
                int cnt = this._orderDataTable.Count;

                // 各行ごとの設定
                for (int i = 0; i < cnt; i++)
                {
                    this.SettingGridRow(i);
                }

                // 表示用行番号調整処理
                this.AdjustRowNo();

                // セルアクティブ時ボタン有効無効コントロール処理
                this.ActiveCellButtonEnabledControl(null);

                //初期フォーカス位置
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);

            }
            finally
            {
                // 描画を開始
                this.uGrid_Details.EndUpdate();
            }
        }
        # endregion

        # region 明細グリッド・行単位でのセル設定
        /// <summary>
        /// 明細グリッド・行単位でのセル設定
        /// </summary>
        /// <param name="rowIndex">対象行インデックス</param>
        /// <remarks>
        /// <br>Note       : 明細グリッド・行単位でのセル設定を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void SettingGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // 指定行の全ての列に対して設定を行う。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // セル情報を取得
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
                if (cell == null) continue;

                if ((cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled) &&
                    (cell.Column.CellActivation != Infragistics.Win.UltraWinGrid.Activation.Disabled))
                {
                    if ((cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit) ||
                            (cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit))
                    {
                        cell.Appearance.BackColor = READONLY_CELL_COLOR;
                    }
                }
            }

        }
        # endregion

        # region 表示用行番号調整処理
        /// <summary>
        /// 表示用行番号調整処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 表示用行番号調整処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        public void AdjustRowNo()
        {
            int no = 1;
            foreach (StockInputDataSet.OrderExpansionRow row in this._orderDataTable)
            {
                if (row != null)
                {
                    row.OrderNo = no;
                    no++;
                }
            }
        }
        # endregion

        # region ヘッダー部画面入力
        /// <summary>
        /// ヘッダー部画面入力
        /// </summary>
        public InpHedDisplay inpHedDisplay
        {
            get
            {
                return this._inpHedDisplay;
            }
            set
            {
                this._inpHedDisplay = value;
            }
        }
        # endregion

        # region セルアクティブ時ボタン有効無効コントロール処理
        /// <summary>
        /// セルアクティブ時ボタン有効無効コントロール処理
        /// </summary>
        /// <param name="colKey">セルキー文字列</param>
        /// <remarks>
        /// <br>Note       : セルアクティブ時ボタン有効無効コントロール処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void ActiveCellButtonEnabledControl(string colKey)
        {
            //業務区分＝取消処理
            if (this._supplierAcs.IsDataChanged != false)
            {
                this.uButton_Select.Enabled = true;
                this.uButton_Cancell.Enabled = true;
            }
            else
            {
                this.uButton_Select.Enabled = false;
                this.uButton_Cancell.Enabled = false;
            }

            // ガイドボタンの有効無効を設定する
            if (colKey != null)
            {
                this.uButton_Guide.Enabled = true;
                this.uButton_Guide.Tag = colKey;
            }
            else
            {
                this.uButton_Guide.Enabled = false;
            }
        }
        # endregion

        #region ■グリッド列初期設定処理
        /// <summary>
        /// グリッド初期レイアウト設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッド初期レイアウト設定イベント処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // グリッド列初期設定処理
            this.InitialSettingGridCol(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド列初期設定処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
        /// <br>              RRedmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
        /// </remarks>
        private void InitialSettingGridCol(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            //表示順番
            int currentPosition = 0;

            string codeFormat = "#;";
            string codeFormat_GoodsMakerCd = "0000;";
            string codeFormat_CashRegisterNo = "000;";
            string codeFormat_OnlineNo = "000000000;";
            string numFormat = "##0;";
            string _dateFormat = "yyyy/MM/dd";

            // 明細部
            //[No.]
            #region [No.]
            //表示順位
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].Width = 44;
            //固定列
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].Header.Fixed = true;
            //タイトル名称
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].Header.Caption = "No.";
            //入力許可
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            // CellAppearance設定
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion

            //選択
            #region [選択]
            //表示順位
            Columns[this._orderDataTable.InpSelectColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InpSelectColumn.ColumnName].Width = 44;
            //固定列
            Columns[this._orderDataTable.InpSelectColumn.ColumnName].Header.Fixed = true;			// 固定項目
            //タイトル名称
            Columns[this._orderDataTable.InpSelectColumn.ColumnName].Header.Caption = "選択";
            //Style
            Columns[this._orderDataTable.InpSelectColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._orderDataTable.InpSelectColumn.ColumnName].AutoEdit = true;
            //入力許可
            Columns[this._orderDataTable.InpSelectColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            #endregion

            #region [端末]
            //[端末]
            //表示順位
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Width = 50;
            //固定列
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Header.Caption = "端末";
            //入力許可
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Format = codeFormat_CashRegisterNo;
            // MaxLength設定
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].MaxLength = 3;
            //CellAppearance
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

            #region [呼出番号]
            //[呼出番号] OrderNumber
            //表示順位
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Width = 80;
            //固定列
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Header.Caption = "呼出番号";
            //入力許可
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Format = codeFormat_OnlineNo;
            // MaxLength設定
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].MaxLength = 20;
            //CellAppearance
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

            //入力日
            #region [入力日]
            //[発注日] OrderDataCreateDate
            //表示順位
            Columns[this._orderDataTable.InputDayColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.InputDayColumn.ColumnName].Width = 90;
            //固定列
            Columns[this._orderDataTable.InputDayColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.InputDayColumn.ColumnName].Header.Caption = "入力日";
            //入力許可
            Columns[this._orderDataTable.InputDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.InputDayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            Columns[this._orderDataTable.InputDayColumn.ColumnName].Format = _dateFormat;
            //CellAppearance
            Columns[this._orderDataTable.InputDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

            //---ADD wangyl 2013/02/06 Redmine#34578------>>>>>
            //倉庫名
            #region [倉庫]
            //[倉庫名] WareHouseName
            //表示順位
            Columns[this._orderDataTable.WarehouseNameColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.WarehouseNameColumn.ColumnName].Width = 100;
            //固定列
            Columns[this._orderDataTable.WarehouseNameColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.WarehouseNameColumn.ColumnName].Header.Caption = "倉庫";
            //入力許可
            Columns[this._orderDataTable.WarehouseNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.WarehouseNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            #endregion
            //---ADD wangyl 2013/02/06 Redmine#34578------<<<<<

            //得意先
            #region [得意先名]
            //[得意先名] SalesCustomerSnm
            //表示順位
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            //Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Width = 130;// DEL wangyl 2013/02/06 Redmine#34578
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Width = 60; // ADD wangyl 2013/02/06 Redmine#34578
            //固定列
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Header.Caption = "得意先";
            //入力許可
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            #endregion

            //品番
            #region [品番]
            //表示順位
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            //Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Width = 160;// DEL wangyl 2013/02/06 Redmine#34578
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Width = 130;// ADD wangyl 2013/02/06 Redmine#34578
            //固定列
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Header.Caption = "品番";
            //入力許可
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Format = codeFormat;
            // MaxLength設定
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].MaxLength = 40;
            //CellAppearance
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].CharacterCasing = CharacterCasing.Normal;
            #endregion

            //メーカー
            #region [メーカー]
            //表示順位
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Width = 60;
            //固定列
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Header.Caption = "ﾒｰｶｰ";
            //入力許可
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Format = codeFormat_GoodsMakerCd;
            // MaxLength設定
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].MaxLength = 4;
            //CellAppearance
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

            //品名
            #region [品名]
            //表示順位
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Width = 170;
            //固定列
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Header.Caption = "品名";
            //入力許可
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // MaxLength設定
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].MaxLength = 100;
            // CellAppearance設定
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            #endregion

            //数量
            #region [数量]
            //[数量] InpAcceptAnOrderCnt
            //表示順位
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //表示幅
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].Width = 50;
            //固定列
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].Header.Fixed = false;
            //タイトル名称
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].Header.Caption = "数量";
            //入力許可
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // フォーマット設定
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].Format = numFormat;
            // MaxLength設定
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].MaxLength = 3;
            //CellAppearance
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

            //--------------------------------------
            // 非表示
            //--------------------------------------
            Columns[this._orderDataTable.UoeRemark1Column.ColumnName].Hidden = true;
            Columns[this._orderDataTable.EmployeeCodeColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.EmployeeNameColumn.ColumnName].Hidden = true;

            Columns[this._orderDataTable.OnlineRowNoColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.UOEKindColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.CommonSeqNoColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.SupplierFormalColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.StockSlipDtlNumColumn.ColumnName].Hidden = true;
        }

        #endregion

        #region ■全選択ボタンクリックイベント
        /// <summary>
        /// 全選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 全選択ボタンクリックイベントを行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void uButton_Select_Click(object sender, EventArgs e)
        {
            this._orderDataTable.AcceptChanges();

            // フィルター除外行を取得      
            Infragistics.Win.UltraWinGrid.UltraGridRow[] _rows =
                this.uGrid_Details.Rows.GetFilteredInNonGroupByRows();

            // 表示行は存在するか？
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow _row in _rows)
            {
                int uniqueID = (int)_row.Cells[_orderDataTable.OrderNoColumn.ColumnName].Value;
                this._supplierAcs.SelectedRow(uniqueID, true);
            }
        }

        # endregion

        #region ■全解除ボタンクリックイベント
        /// <summary>
        /// 全解除ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 全解除ボタンクリックイベントを行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void uButton_Cancell_Click(object sender, EventArgs e)
        {
            this._orderDataTable.AcceptChanges();

            Infragistics.Win.UltraWinGrid.UltraGridRow[] _rows =
                this.uGrid_Details.Rows.GetFilteredInNonGroupByRows();

            // 表示行は存在するか？
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow _row in _rows)
            {
                int uniqueID = (int)_row.Cells[_orderDataTable.OrderNoColumn.ColumnName].Value;
                this._supplierAcs.SelectedRow(uniqueID, false);
            }
        }

        #endregion

        /// <summary>
        /// グリッドセルアクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアクティブ後発生イベントを行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            //ヘッダー部のデータ設定
            Int32 onlineNo = (int)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.OnlineNoColumn.ColumnName].Value);
            SettingHedaerItem(onlineNo);

            // セルアクティブ時ボタン有効無効コントロール処理
            this.ActiveCellButtonEnabledControl(null);
        }

        # region ■ ヘッダー部のデータ設定
        /// <summary>
        /// ■ ヘッダー部のデータ設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : ヘッダー部のデータ設定を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        public void SettingHedaerItem(Int32 onlineNo)
        {
            //現在編集中のヘッダー情報と同一の場合は何もしない
            if ((_inpHedDisplay != null)
            && (onlineNo == _inpHedDisplay.OnlineNo)) return;

            if (this.uGrid_Details.ActiveRow != null)
            {
                _inpHedDisplay = new InpHedDisplay();
                // リマーク1
                _inpHedDisplay.UoeRemark1 = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.UoeRemark1Column.ColumnName].Value);
                // 依頼者
                _inpHedDisplay.EmployeeCode = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.EmployeeCodeColumn.ColumnName].Value);
                // 依頼名
                _inpHedDisplay.EmployeeName = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.EmployeeNameColumn.ColumnName].Value);
                // リマーク1
                tEdit_UoeRemark1.Text = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.UoeRemark1Column.ColumnName].Value);
                // 依頼者
                tEdit_EmployeeCode.Text = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.EmployeeCodeColumn.ColumnName].Value);
                // 依頼名
                tEdit_EmployeeName.Text = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.EmployeeNameColumn.ColumnName].Value);

                _inpHedDisplay.OnlineNo = (int)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.OnlineNoColumn.ColumnName].Value);
            }

            this.tEdit_UoeRemark1.Enabled = true;                   //ＵＯＥリマーク１
            this.tEdit_EmployeeCode.Enabled = true;                 //依頼者コード
            //this.tEdit_EmployeeName.Enabled = true;                 //依頼者コード
        }

        #endregion

        #region ■グリッド内イベント（グリッド進入・脱出関連）
        /// <summary>
        /// グリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドエンターイベントを行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                if (!this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || (this.uGrid_Details.ActiveCell == null))
                {
                    if (this.uGrid_Details.Rows.Count > 0)
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[this._orderDataTable.GoodsNoColumn.ColumnName];
                        // 次入力可能セル移動処理
                        this.MoveNextAllowEditCell(true);
                    }
                }
            }

            if (this.uGrid_Details.ActiveCell != null)
            {
                if ((!this.uGrid_Details.ActiveCell.IsInEditMode) && (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                else
                {
                    // 次入力可能セル移動処理
                    this.MoveNextAllowEditCell(true);
                }
            }

            // グリッドセルアクティブ後発生イベント
            uGrid_Details_AfterCellActivate(sender, e);
        }
        #endregion

        # region Returnキーダウン処理
        /// <summary>
        /// Returnキーダウン処理
        /// </summary>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : Returnキーダウン処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        internal bool ReturnKeyDown()
        {
            if (this.uGrid_Details.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            bool canMove = true;

            // 数量
            if (cell.Column.Key == this._orderDataTable.AcceptAnOrderCntColumn.ColumnName)
            {
                # region 数量
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                //canMove = this.MoveNextAllowEditCell(false);
                uButton_Select.Focus();

                # endregion
            }
            else
            {
                canMove = this.MoveNextAllowEditCell(false);
            }

            return canMove;
        }

        #endregion Returnキーダウン処理

        # region 次入力可能セル移動処理
        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 次入力可能セル移動処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            try
            {
                // 更新開始（描画ストップ）
                this.uGrid_Details.BeginUpdate();

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
            finally
            {
                // 更新終了（描画再開）
                this.uGrid_Details.EndUpdate();
            }

            return performActionResult;
        }
        # endregion

        /// <summary>
        /// （イベント）依頼者Ｅｎｔｅｒ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 依頼者Ｅｎｔｅｒ処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void tEdit_EmployeeCode_Enter(object sender, EventArgs e)
        {
            this.uButton_Guide.Enabled = true;
        }

        /// <summary>
        /// グリッド行アクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッド行アクティブ後発生イベント処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
            this.uButton_Guide.Enabled = false;
        }

        /// <summary>
        /// （イベント）リマーク１Ｅｎｔｅｒ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        /// <remarks>
        /// <br>Note       : リマーク１Ｅｎｔｅｒ処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void tEdit_UoeRemark1_Enter(object sender, EventArgs e)
        {
            this.uButton_Guide.Enabled = false;
        }

        /// <summary>
        /// （イベント）依頼者名Ｅｎｔｅｒ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 依頼者名Ｅｎｔｅｒ処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void tEdit_EmployeeName_Enter(object sender, EventArgs e)
        {
            this.uButton_Guide.Enabled = false;
        }

        /// <summary>
        /// （イベント）全選択Ｅｎｔｅｒ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 全選択Ｅｎｔｅｒ処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void uButton_Select_Enter(object sender, EventArgs e)
        {
            this.uButton_Guide.Enabled = false;
        }

        /// <summary>
        /// （イベント）全解除Ｅｎｔｅｒ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 全解除Ｅｎｔｅｒ処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void uButton_Cancell_Enter(object sender, EventArgs e)
        {
            this.uButton_Guide.Enabled = false;
        }

        /// <summary>
        /// ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ガイドボタンクリックイベント処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void uButton_Guide_Click(object sender, EventArgs e)
        {
            int status = -1;

            //インスタンス生成
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;

            //ガイド起動
            status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //項目に展開
                inpHedDisplay.EmployeeCode = employee.EmployeeCode.Trim();
                inpHedDisplay.EmployeeName = employee.Name;
                this.tEdit_EmployeeCode.Text = inpHedDisplay.EmployeeCode;
                this.tEdit_EmployeeName.Text = inpHedDisplay.EmployeeName;

                this._supplierAcs.UpdtHedaerItem(inpHedDisplay);
            }
        }

        /// <summary>
        /// （イベント）依頼者Ｌｅａｖｅ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 依頼者Ｌｅａｖｅ処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void tEdit_EmployeeCode_Leave(object sender, EventArgs e)
        {
            if (inpHedDisplay == null) return;

            bool bStatus = true;
            string setCd = inpHedDisplay.EmployeeCode;
            string setNm = inpHedDisplay.EmployeeName;
            string name = string.Empty;


            //-----------------------------------------------------------
            //入力値が空白
            //-----------------------------------------------------------
            if (this.tEdit_EmployeeCode.Text == string.Empty)
            {
                setCd = string.Empty;
                setNm = string.Empty;
            }
            //-----------------------------------------------------------
            //入力値の変更あり
            //-----------------------------------------------------------
            else if (this.tEdit_EmployeeCode.Text != inpHedDisplay.EmployeeCode)
            {
                //依頼者の取得
                //int cd = 0;
                string codeString = string.Empty;
                try
                {
                    //cd = int.Parse(this.tEdit_EmployeeCode.Text);
                    codeString = this.tEdit_EmployeeCode.Text.PadLeft(4, '0');
                }
                catch (Exception)
                {
                    //cd = 0;
                }
                //string codeString = cd.ToString("d4");

                if (this._supplierAcs.GetEmployeeName(codeString, out name) == true)
                {
                    setCd = codeString.Trim();
                    setNm = name;
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "依頼者が存在しません。",
                        -1,
                        MessageBoxButtons.OK);
                    bStatus = false;
                }
            }

            //-----------------------------------------------------------
            //値の設定
            //-----------------------------------------------------------
            _inpHedDisplay.EmployeeCode = setCd;
            _inpHedDisplay.EmployeeName = setNm;
            this._supplierAcs.UpdtHedaerItem(_inpHedDisplay);

            this.tEdit_EmployeeCode.Text = setCd;
            this.tEdit_EmployeeName.Text = setNm;

            //-----------------------------------------------------------
            // エラー処理
            //-----------------------------------------------------------
            if (bStatus == false)
            {
                this.tEdit_EmployeeCode.Focus();
            }
        }

        /// <summary>
        /// （イベント）リマーク１Ｌｅａｖｅ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">オブジェクト</param>
        /// <remarks>
        /// <br>Note       : リマーク１Ｌｅａｖｅ処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void tEdit_UoeRemark1_Leave(object sender, EventArgs e)
        {
            if (inpHedDisplay == null) return;
            _inpHedDisplay.UoeRemark1 = tEdit_UoeRemark1.Text;
            this._supplierAcs.UpdtHedaerItem(_inpHedDisplay);
        }

        /// <summary>
        /// グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアップデート後イベント処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            //なし           
        }

        #endregion

        /// <summary>
        /// グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアップデート後イベント処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// <br>Update Note: 2012/02/06 凌小青</br>
        /// <br>管理番号   ：2012/03/28配信分</br>
        /// <br>             Redmine#28287の対応</br>
        /// </remarks>
        private void uGrid_Details_CellChange(object sender, CellEventArgs e)
        {                 
            this._orderDataTable.AcceptChanges();
            if (e.Cell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
            int OnlineNo = this._orderDataTable[cell.Row.Index].OnlineNo;
            int rowIndex = e.Cell.Row.Index;
            bool check;

            //----ADD BY 凌小青 on 2012/02/06 for Redmine#28287 ------>>>>>>>>
            // 数量
            string columnData = e.Cell.Text.ToString(); //入力値
            double tempCount = 0;
            if (cell.Column.Key == this._orderDataTable.AcceptAnOrderCntColumn.ColumnName)
            {
                # region 数量
                try
                {
                    if (string.IsNullOrEmpty(columnData))
                    {
                        columnData = "0";
                    }
                    tempCount = Convert.ToDouble(columnData);
                }
                catch
                {
                    tempCount = 0.0;
                    this.uGrid_Details.ActiveCell.Value = 0;
                }
                this._orderDataTable[rowIndex].AcceptAnOrderCnt = tempCount;
                # endregion
            }
            //----ADD BY 凌小青 on 2012/02/06 for Redmine#28287 ------<<<<<<<<      

            if (BusinessCode == ctTerminalDiv_Order)
            {
                string checkString = this.uGrid_Details.Rows[cell.Row.Index].Cells[_orderDataTable.InpSelectColumn.ColumnName].Text;
                if ("True".Equals(checkString))
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
                //-----------------------------------------------------------
                // 選択
                //-----------------------------------------------------------
                if (cell.Column.Key == this._orderDataTable.InpSelectColumn.ColumnName)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        int uniqueOnlineNo = (int)row.Cells[_orderDataTable.OnlineNoColumn.ColumnName].Value;
                        int uniqueID = (int)row.Cells[_orderDataTable.OrderNoColumn.ColumnName].Value;

                        if (OnlineNo == uniqueOnlineNo)
                        {
                            this._supplierAcs.SelectedRow(uniqueID, check);
                        }
                    }

                }
            }
            else
            {
                string checkStringDel = this.uGrid_Details.Rows[cell.Row.Index].Cells[_orderDataTable.InpSelectColumn.ColumnName].Text;
                if ("True".Equals(checkStringDel))
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
                //-----------------------------------------------------------
                // 選択
                //-----------------------------------------------------------
                if (cell.Column.Key == this._orderDataTable.InpSelectColumn.ColumnName)
                {
                    this._supplierAcs.SelectedRow(this._orderDataTable[cell.Row.Index].OrderNo, check);
                }
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/06/01</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;
            int colIndex = uGrid.ActiveCell.Column.Index;
            string colKey = uGrid.ActiveCell.Column.Key;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            //
                        }
                        else
                        {
                            e.Handled = true;
                            uGrid.Rows[rowIndex - 1].Cells[colIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex != uGrid.Rows.Count - 1)
                        {
                            uGrid.Rows[rowIndex + 1].Cells[colIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
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
        /// <br>Programmer  : 凌小青</br>
        /// <br>Date        : 2012/02/06</br>
        /// <br>管理番号    : 2012/03/28配信分　Redmine#28287の対応</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // ActiveCellが数量の場合InpAcceptAnOrderCntColumn
            if (cell.Column.Key == this._orderDataTable.AcceptAnOrderCntColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        # region 数値入力チェック処理
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
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2012/02/06</br>
        /// <br>管理番号    : 2012/03/28配信分　Redmine#28287の対応</br>
        /// </remarks>
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

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
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
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
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
        # endregion
        
    }

}
