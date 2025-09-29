using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫仕入入力画面用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫仕入入力画面用のユーザー設定フォームクラスです。</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2008/07/24</br>
    /// </remarks>
    public partial class MAZAI04350UC : Form
    {
        #region Constants

        private const string COLUMNROWNO = "ColumnRowNo";
        private const string COLUMNCAPTIONKEY = "ColumnCaptionKey";
        private const string COLUMNCAPTIONNAME = "ColumnCaptionName";
        private const string COLUMNVISIBLE = "ColumnVisible";
        private const string COLUMNVISIBLEALLOW = "ColumnVisibleAllow";
        private const string COLUMNVISIBLEPOSITION = "ColumnVisiblePosition";
        private const string COLUMNMOVEALLOW = "ColumnMoveAllow";

        #endregion Constants

        #region Private Member

        private ArrayList _userSettingList;
        private ImageList _imageList16 = null;
        private ControlScreenSkin _controlScreenSkin;

        #endregion Private Member

        #region Property

        public ArrayList UserSettingList
        {
            get { return _userSettingList; }
            set { _userSettingList = value; }
        }

        #endregion Property

        #region Constructor

        /// <summary>
        /// 在庫仕入入力画面用ユーザー設定クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫仕入入力画面用ユーザー設定クラスの初期処理を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// <br></br>
        /// </remarks>
        public MAZAI04350UC(ArrayList userSettingList)
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._controlScreenSkin = new ControlScreenSkin();
            this._userSettingList = userSettingList;
        }

        #endregion Constructor

        #region Private Methods

        /// <summary>
        /// グリッド設定処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : グリッドの設定を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/24</br>
        /// </remarks>
        private void SetGrid(ArrayList userSettingList)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(COLUMNROWNO, typeof(Int32));
            dataTable.Columns.Add(COLUMNCAPTIONKEY, typeof(String));
            dataTable.Columns.Add(COLUMNCAPTIONNAME, typeof(String));
            dataTable.Columns.Add(COLUMNVISIBLE, typeof(Boolean));
            dataTable.Columns.Add(COLUMNVISIBLEALLOW, typeof(Boolean));
            dataTable.Columns.Add(COLUMNVISIBLEPOSITION, typeof(Int32));
            dataTable.Columns.Add(COLUMNMOVEALLOW, typeof(Boolean));

            ArrayList captionKeyList = new ArrayList();
            captionKeyList = (ArrayList)userSettingList[0];

            ArrayList captionNameList = new ArrayList();
            captionNameList = (ArrayList)userSettingList[1];

            ArrayList visibleList = new ArrayList();
            visibleList = (ArrayList)userSettingList[2];

            ArrayList visibleAllowList = new ArrayList();
            visibleAllowList = (ArrayList)userSettingList[3];

            ArrayList visiblePositionList = new ArrayList();
            visiblePositionList = (ArrayList)userSettingList[4];

            ArrayList moveAllowList = new ArrayList();
            moveAllowList = (ArrayList)userSettingList[5];

            DataRow dataRow;

            for (int index = 0; index < captionKeyList.Count; index++)
            {
                dataRow = dataTable.NewRow();
                dataRow[COLUMNROWNO] = index + 1;
                dataRow[COLUMNCAPTIONKEY] = captionKeyList[index];
                dataRow[COLUMNCAPTIONNAME] = captionNameList[index];
                dataRow[COLUMNVISIBLE] = visibleList[index];
                dataRow[COLUMNVISIBLEALLOW] = visibleAllowList[index];
                dataRow[COLUMNVISIBLEPOSITION] = visiblePositionList[index];
                dataRow[COLUMNMOVEALLOW] = moveAllowList[index];
                dataTable.Rows.Add(dataRow);
            }

            this.uGrid_DetailControl.DataSource = dataTable;


            ColumnsCollection Columns = this.uGrid_DetailControl.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------

            this.uGrid_DetailControl.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // №
            Columns[COLUMNROWNO].Header.Fixed = true;
            Columns[COLUMNROWNO].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            Columns[COLUMNROWNO].CellAppearance.BackColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[COLUMNROWNO].CellAppearance.BackColor2 = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[COLUMNROWNO].CellAppearance.BackGradientStyle = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[COLUMNROWNO].CellAppearance.FontData.Bold = DefaultableBoolean.True;
            Columns[COLUMNROWNO].CellAppearance.ForeColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[COLUMNROWNO].CellAppearance.ForeColorDisabled = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[COLUMNROWNO].Hidden = false;
            Columns[COLUMNROWNO].Width = 25;
            Columns[COLUMNROWNO].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[COLUMNROWNO].CellActivation = Activation.Disabled;
            Columns[COLUMNROWNO].CellAppearance.TextHAlign = HAlign.Right;
            Columns[COLUMNROWNO].CellAppearance.BackColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[COLUMNROWNO].Header.VisiblePosition = visiblePosition++;
            Columns[COLUMNROWNO].Header.Caption = "No."; ;

            // 項目名
            Columns[COLUMNCAPTIONNAME].Header.Fixed = true;
            Columns[COLUMNCAPTIONNAME].Hidden = false;
            Columns[COLUMNCAPTIONNAME].Width = 100;
            Columns[COLUMNCAPTIONNAME].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[COLUMNCAPTIONNAME].CellActivation = Activation.NoEdit;
            Columns[COLUMNCAPTIONNAME].CellAppearance.TextHAlign = HAlign.Left;
            Columns[COLUMNCAPTIONNAME].Header.VisiblePosition = visiblePosition++;
            Columns[COLUMNCAPTIONNAME].Header.Caption = "項目";

            // 表示有無
            Columns[COLUMNVISIBLE].Header.Fixed = true;
            Columns[COLUMNVISIBLE].Hidden = false;
            Columns[COLUMNVISIBLE].Width = 40;
            Columns[COLUMNVISIBLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[COLUMNVISIBLE].Header.VisiblePosition = visiblePosition++;
            Columns[COLUMNVISIBLE].Header.Caption = "表示";

            Columns[COLUMNCAPTIONKEY].Hidden = true;
            Columns[COLUMNVISIBLEALLOW].Hidden = true;
            Columns[COLUMNVISIBLEPOSITION].Hidden = true;
            Columns[COLUMNMOVEALLOW].Hidden = true;

            for (int rowIndex = 0; rowIndex < this.uGrid_DetailControl.Rows.Count; rowIndex++)
            {
                bool visibleAllow = (bool)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLEALLOW].Value;

                if (visibleAllow == false)
                {
                    this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLE].Activation = Activation.Disabled;
                }
                else
                {
                    this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLE].Activation = Activation.AllowEdit;
                }
            }
        }

        /// <summary>
        /// ユーザー設定情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 画面からユーザー設定情報を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/24</br>
        /// </remarks>
        private void ScreenToArrayVisible()
        {
            ArrayList captionKeyList = new ArrayList();
            ArrayList captionNameList = new ArrayList();
            ArrayList visibleList = new ArrayList();
            ArrayList visibleAllowList = new ArrayList();
            ArrayList visiblePositionList = new ArrayList();
            ArrayList moveAllowList = new ArrayList();

            for (int rowIndex = 0; rowIndex < this.uGrid_DetailControl.Rows.Count; rowIndex++)
            {
                string captionKey = (string)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNCAPTIONKEY].Value;
                string captionName = (string)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNCAPTIONNAME].Value;
                bool visible = (bool)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLE].Value;
                bool visibleAllow = (bool)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLEALLOW].Value;
                int visiblePosition = (int)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLEPOSITION].Value;
                bool moveAllow = (bool)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNMOVEALLOW].Value;

                captionKeyList.Add(captionKey);
                captionNameList.Add(captionName);
                visibleList.Add(!visible);
                visibleAllowList.Add(visibleAllow);
                visiblePositionList.Add(visiblePosition);
                moveAllowList.Add(moveAllow);
            }

            this._userSettingList = new ArrayList();
            this._userSettingList.Add(captionKeyList);
            this._userSettingList.Add(captionNameList);
            this._userSettingList.Add(visibleList);
            this._userSettingList.Add(visibleAllowList);
            this._userSettingList.Add(visiblePositionList);
            this._userSettingList.Add(moveAllowList);
        }

        /// <summary>
        /// 初期ユーザー設定情報作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 初期ユーザー設定情報を作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/24</br>
        /// </remarks>
        private ArrayList CreateInitialSettingList()
        {
            ArrayList initialSettingList = new ArrayList();
            ArrayList captionKeyList = new ArrayList();
            ArrayList captionNameList = new ArrayList();
            ArrayList visibleList = new ArrayList();
            ArrayList visibleAllowList = new ArrayList();
            ArrayList visiblePositionList = new ArrayList();
            ArrayList moveAllowList = new ArrayList();

            captionKeyList.Add(AdjustStockAcs.ctCOL_RowNum);
            captionKeyList.Add(AdjustStockAcs.ctCOL_GoodsNo);
            captionKeyList.Add(AdjustStockAcs.ctCOL_GoodsName);
            captionKeyList.Add(AdjustStockAcs.ctCOL_BLGoodsCode);
            captionKeyList.Add(AdjustStockAcs.ctCOL_GoodsMakerCd);
            captionKeyList.Add(AdjustStockAcs.ctCOL_SupplierCd);
            captionKeyList.Add(AdjustStockAcs.ctCOL_ListPriceFl);
            captionKeyList.Add(AdjustStockAcs.ctCOL_StockUnitPrice);
            captionKeyList.Add(AdjustStockAcs.ctCOL_SalesOrderUnit);
            captionKeyList.Add(AdjustStockAcs.ctCOL_AfSalesOrderUnit);
            captionKeyList.Add(AdjustStockAcs.ctCOL_WarehouseShelfNo);
            captionKeyList.Add(AdjustStockAcs.ctCOL_SalesOrderCount);
            captionKeyList.Add(AdjustStockAcs.ctCOL_SupplierStock);
            captionKeyList.Add(AdjustStockAcs.ctCOL_DtlNote);

            captionNameList.Add("No");
            captionNameList.Add("品番");
            captionNameList.Add("品名");
            captionNameList.Add("BLコード");
            captionNameList.Add("メーカー");
            captionNameList.Add("仕入先");
            captionNameList.Add("標準価格");
            captionNameList.Add("原単価");
            captionNameList.Add("仕入数");
            captionNameList.Add("仕入後数");
            captionNameList.Add("棚番");
            captionNameList.Add("発注残");
            captionNameList.Add("在庫数");
            captionNameList.Add("明細備考");

            for (int index = 0; index < 15; index++)
            {
                visibleList.Add(true);
            }

            visibleAllowList.Add(false);
            visibleAllowList.Add(false);
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            visibleAllowList.Add(false);
            visibleAllowList.Add(false);
            visibleAllowList.Add(false);
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);

            visiblePositionList = (ArrayList)this._userSettingList[4];

            moveAllowList.Add(false);
            moveAllowList.Add(false);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);

            initialSettingList.Add(captionKeyList);
            initialSettingList.Add(captionNameList);
            initialSettingList.Add(visibleList);
            initialSettingList.Add(visibleAllowList);
            initialSettingList.Add(visiblePositionList);
            initialSettingList.Add(moveAllowList);
            return initialSettingList;
        }

        /// <summary>
        /// 表示位置変更可能チェック
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        /// <param name="upDownMode">UpDownモード(0:Up  1:Down)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 表示位置を変更できるかどうかチェックします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private bool CheckVisiblePositionChange(int rowIndex, int upDownMode)
        {
            if ((bool)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNMOVEALLOW].Value == false)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "変更できない項目です。",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                return (false);
            }

            if (upDownMode == 0)
            {
                if (rowIndex <= 2)
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "移動出来ません。",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                    return (false);
                }
            }
            else
            {
                if (rowIndex == this.uGrid_DetailControl.Rows.Count - 1)
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "移動出来ません。",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                    return (false);
                }
            }

            return (true);
        }
        #endregion Private Methods

        #region Control Events
        /// <summary>
        /// Form.Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/24</br>
        /// </remarks>
        private void MAZAI04350UC_Load(object sender, EventArgs e)
        {
            this.Ok_Button.ImageList = this._imageList16;
            this.Ok_Button.Appearance.Image = (int)Size16_Index.DECISION;
            this.Cancel_Button.ImageList = this._imageList16;
            this.Cancel_Button.Appearance.Image = (int)Size16_Index.BEFORE;

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // グリッド設定
            SetGrid(this._userSettingList);
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/24</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // 画面情報取得
            ScreenToArrayVisible();

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : 初期値に戻すボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/24</br>
        /// </remarks>
        private void uButton_DetailFocusUndo_Click(object sender, EventArgs e)
        {
            for (int rowIndex = 0; rowIndex < this.uGrid_DetailControl.Rows.Count; rowIndex++)
            {
                if ((Boolean)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLE].Value != true)
                {
                    this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLE].Value = true;
                }
            }

            // 初期データ作成
            ArrayList initialSettingList = CreateInitialSettingList();

            SetGrid(initialSettingList);

            this.uGrid_DetailControl.UpdateData();

            this.uGrid_DetailControl.Rows[0].Activate();
        }

        /// <summary>
        /// Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : ▲ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/24</br>
        /// </remarks>
        private void uButton_UpDetailItem_Click(object sender, EventArgs e)
        {
            if (this.uGrid_DetailControl.ActiveRow == null)
            {
                return;
            }

            int activeRowIndex = this.uGrid_DetailControl.ActiveRow.Index;

            this.uGrid_DetailControl.BeginUpdate();

            try
            {
                // 表示位置変更可能チェック
                if (CheckVisiblePositionChange(activeRowIndex, 0) != true)
                {
                    return;
                }

                // 行番号変更
                this.uGrid_DetailControl.Rows[activeRowIndex].Cells[COLUMNROWNO].Value = activeRowIndex;
                this.uGrid_DetailControl.Rows[activeRowIndex - 1].Cells[COLUMNROWNO].Value = activeRowIndex + 1;

                int visiblePosition = (int)this.uGrid_DetailControl.Rows[activeRowIndex].Cells[COLUMNVISIBLEPOSITION].Value;
                int afterVisiblePosition = (int)this.uGrid_DetailControl.Rows[activeRowIndex - 1].Cells[COLUMNVISIBLEPOSITION].Value;

                this.uGrid_DetailControl.Rows[activeRowIndex].Cells[COLUMNVISIBLEPOSITION].Value = afterVisiblePosition;
                this.uGrid_DetailControl.Rows[activeRowIndex - 1].Cells[COLUMNVISIBLEPOSITION].Value = visiblePosition;

                // 行移動
                this.uGrid_DetailControl.Rows.Move(this.uGrid_DetailControl.ActiveRow, activeRowIndex - 1);
            }
            finally
            {
                this.uGrid_DetailControl.EndUpdate();
            }
        }

        /// <summary>
        /// Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : ▼ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/24</br>
        /// </remarks>
        private void uButton_DownDetailItem_Click(object sender, EventArgs e)
        {
            if (this.uGrid_DetailControl.ActiveRow == null)
            {
                return;
            }

            int activeRowIndex = this.uGrid_DetailControl.ActiveRow.Index;

            this.uGrid_DetailControl.BeginUpdate();

            try
            {
                // 表示位置変更可能チェック
                if (CheckVisiblePositionChange(activeRowIndex, 1) != true)
                {
                    return;
                }

                // 行番号変更
                this.uGrid_DetailControl.Rows[activeRowIndex].Cells[COLUMNROWNO].Value = activeRowIndex + 2;
                this.uGrid_DetailControl.Rows[activeRowIndex + 1].Cells[COLUMNROWNO].Value = activeRowIndex + 1;

                int visiblePosition = (int)this.uGrid_DetailControl.Rows[activeRowIndex].Cells[COLUMNVISIBLEPOSITION].Value;
                int afterVisiblePosition = (int)this.uGrid_DetailControl.Rows[activeRowIndex + 1].Cells[COLUMNVISIBLEPOSITION].Value;

                this.uGrid_DetailControl.Rows[activeRowIndex].Cells[COLUMNVISIBLEPOSITION].Value = afterVisiblePosition;
                this.uGrid_DetailControl.Rows[activeRowIndex + 1].Cells[COLUMNVISIBLEPOSITION].Value = visiblePosition;

                // 行移動
                this.uGrid_DetailControl.Rows.Move(this.uGrid_DetailControl.ActiveRow, activeRowIndex + 1);
            }
            finally
            {
                this.uGrid_DetailControl.EndUpdate();
            }
        }
        #endregion Control Events
    }
}