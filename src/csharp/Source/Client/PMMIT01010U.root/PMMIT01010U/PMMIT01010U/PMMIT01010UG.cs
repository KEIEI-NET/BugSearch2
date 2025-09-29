using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// カラー・トリム・装備情報選択コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車輌情報のカラー・トリム・装備情報の選択を行うコントロールクラスです。フォームクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2008.05.13</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.05.13 對馬 大輔 新規作成</br>
    /// <br>UpDate:  2011/02/14 譚洪</br>
    /// <br> 　　　　修正呼出時の「カラー・トリム・装備」情報の制御変更</br>
    /// </remarks>
    public partial class PMMIT01010UG : UserControl
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region Private Members
        private EstimateInputAcs _salesSlipInputAcs;
        private PMKEN01010E.ColorCdInfoDataTable _colorCdInfoDataTable;
        private PMKEN01010E.TrimCdInfoDataTable _trimCdInfoDataTable;
        private PMKEN01010E.CEqpDefDspInfoDataTable _cEqpDefDspInfoDataTable;
        private Guid _carRelationGuid;

        private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
        private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);

        // --- ADD 2011/02/14 -------- >>>>>
        private bool colorGridFlag = false;
        private bool trimGridFlag = false;
        // --- ADD 2011/02/14 -------- <<<<<
        #endregion

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        #region Delegate
        /// <summary>
        /// カラー情報設定デリゲート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="colorCode"></param>
        internal delegate void SettingColorEventHandler(object sender, string colorCode);

        /// <summary>
        /// トリム情報設定デリゲート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="trimCode"></param>
        internal delegate void SettingTrimEventHandler(object sender, string trimCode);
        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region Event
        /// <summary>カラー情報設定イベント</summary>
        internal event SettingColorEventHandler SettingColorInfo;
        /// <summary>トリム情報設定イベント</summary>
        internal event SettingTrimEventHandler SettingTrimInfo;
        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region Properties
        /// <summary>
        /// カラー情報データテーブル
        /// </summary>
        public PMKEN01010E.ColorCdInfoDataTable ColorCdInfoDataTable
        {
            set
            {
                this._colorCdInfoDataTable = value;
                this.uGrid_ColorInfo.DataSource = this._colorCdInfoDataTable;
            }
            get { return this._colorCdInfoDataTable; }
        }
        /// <summary>
        /// トリム情報データテーブル
        /// </summary>
        public PMKEN01010E.TrimCdInfoDataTable TrimCdInfoDataTable
        {
            set
            {
                this._trimCdInfoDataTable = value;
                this.uGrid_TrimInfo.DataSource = this._trimCdInfoDataTable;
            }
            get { return this._trimCdInfoDataTable; }
        }
        /// <summary>
        /// 装備情報データテーブル
        /// </summary>
		public PMKEN01010E.CEqpDefDspInfoDataTable CEqpDefDspInfoDataTable
		{
			set { this._cEqpDefDspInfoDataTable = value; }
			get { return this._cEqpDefDspInfoDataTable; }
		}

        /// <summary>
        /// 車輌情報共通キー
        /// </summary>
        public Guid CarRelationGuid
        {
            set { this._carRelationGuid = value; }
            get { return this._carRelationGuid; }
        }
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region Constructors
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public PMMIT01010UG( EstimateInputAcs estimateInputAcs )
		{
            InitializeComponent();

			this._salesSlipInputAcs = estimateInputAcs;

			this._colorCdInfoDataTable = new PMKEN01010E.ColorCdInfoDataTable();
			this._trimCdInfoDataTable = new PMKEN01010E.TrimCdInfoDataTable();
			this._cEqpDefDspInfoDataTable = new PMKEN01010E.CEqpDefDspInfoDataTable();
			
		}
        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region Event
        /// <summary>
        /// コントロールロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// グリッドレイアウト初期化イベント(カラー情報)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_ColorInfo.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;

                if ((col.Key == this._colorCdInfoDataTable.ColorCodeColumn.ColumnName) ||
                    (col.Key == this._colorCdInfoDataTable.ColorName1Column.ColumnName) ||
                    (col.Key == this._colorCdInfoDataTable.SelectionStateColumn.ColumnName))
                {
                    col.Hidden = false;
                }
            }

            // 幅自動調整設定
            this.uGrid_ColorInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // 固定列区切り線設定
            this.uGrid_ColorInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_ColorInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// グリッドレイアウト初期化イベント(トリム情報)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid2_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_TrimInfo.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;

                if ((col.Key == this._trimCdInfoDataTable.TrimCodeColumn.ColumnName) ||
                    (col.Key == this._trimCdInfoDataTable.TrimNameColumn.ColumnName) ||
                    (col.Key == this._trimCdInfoDataTable.SelectionStateColumn.ColumnName))
                {
                    col.Hidden = false;
                }
            }

            // 幅自動調整設定
            this.uGrid_TrimInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // 固定列区切り線設定
            this.uGrid_TrimInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_ColorInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// グリッドレイアウト初期化イベント(装備情報)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid3_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // 幅自動調整設定
            this.uGrid_EquipInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // 固定列区切り線設定
            this.uGrid_EquipInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_ColorInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// グリッドクリックイベント(カラー情報)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid1_Click(object sender, EventArgs e)
        {
            // --- ADD 2011/02/14 -------- >>>>>
            if (!colorGridFlag)
            {
                return;
            }
            // --- ADD 2011/02/14 -------- <<<<<

            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

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

            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
              (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

            string colorCode = (string)objRow.Cells[this._colorCdInfoDataTable.ColorCodeColumn.ColumnName].Value;

            //-----------------------------------------------------------
            // カラー情報設定処理
            //-----------------------------------------------------------
            this.SettingColorInfoProc(colorCode);
        }

        /// <summary>
        /// グリッドクリックイベント(トリム情報)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid2_Click(object sender, EventArgs e)
        {
            // --- ADD 2011/02/14 -------- >>>>>
            if (!trimGridFlag)
            {
                return;
            }
            // --- ADD 2011/02/14 -------- <<<<<

            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

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

            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
              (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

            this.SettingTrimEventCall((string)objRow.Cells[this._trimCdInfoDataTable.TrimCodeColumn.ColumnName].Value);

            string trimCode = (string)objRow.Cells[this._trimCdInfoDataTable.TrimCodeColumn.ColumnName].Value;
            
            //-----------------------------------------------------------
            // トリム情報設定処理
            //-----------------------------------------------------------
            this.SettingTrimInfoProc(trimCode);
        }
        
        /// <summary>
        /// セルリストセレクトイベント(装備情報)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_EquipInfo_CellListSelect( object sender, CellEventArgs e )
        {

            int rowIndex = e.Cell.Row.Index;
            string key = (string)this.uGrid_EquipInfo.Rows[rowIndex].Cells["kind"].Value;
            Infragistics.Win.ValueList valueList = (Infragistics.Win.ValueList)this.uGrid_EquipInfo.Rows[rowIndex].Cells["value"].ValueList;
            int selectedIndex = 0;
            if (valueList != null) selectedIndex = valueList.SelectedIndex;

            //-----------------------------------------------------------
            // 装備情報設定処理
            //-----------------------------------------------------------
            this.SettingEquipInfoProc(key, selectedIndex);
        }


        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region Private Methods
        /// <summary>
        /// カラー情報設定処理
        /// </summary>
        /// <param name="colorCode"></param>
        private void SettingColorInfoProc( string colorCode )
        {
            this.SettingColorEventCall(colorCode);
            this._salesSlipInputAcs.SelectColorInfo(this._carRelationGuid, colorCode);
        }

        /// <summary>
        /// トリム情報設定処理
        /// </summary>
        /// <param name="trimCode"></param>
        private void SettingTrimInfoProc( string trimCode )
        {
            this.SettingTrimEventCall(trimCode);
            this._salesSlipInputAcs.SelectTrimInfo(this._carRelationGuid, trimCode);
        }

        /// <summary>
        /// 装備情報設定処理
        /// </summary>
        /// <param name="equipmentGenreCd"></param>
        /// <param name="selectIndex"></param>
        private void SettingEquipInfoProc( string equipmentGenreCd, int selectIndex )
        {
            this._salesSlipInputAcs.SelectEquipInfo(this._carRelationGuid, equipmentGenreCd, selectIndex);
        }

        /// <summary>
        /// カラー情報設定イベントコール
        /// </summary>
        /// <param name="colorCode">カラーコード</param>
        private void SettingColorEventCall( string colorCode )
        {
            if (this.SettingColorInfo != null) this.SettingColorInfo(this, colorCode);
        }

        /// <summary>
        /// トリム情報設定イベントコール
        /// </summary>
        /// <param name="trimCode">トリムコード</param>
        private void SettingTrimEventCall( string trimCode )
        {
            if (this.SettingTrimInfo != null) this.SettingTrimInfo(this, trimCode);
        }
        /// <summary>
        /// 装備グリッドレイアウト設定処理
        /// </summary>
        public void SettingEquipGridLayout()
        {
            
            if (( this._cEqpDefDspInfoDataTable != null ) && ( this._cEqpDefDspInfoDataTable.Count != 0 ))
            {
                this._cEqpDefDspInfoDataTable.BeginLoadData();
                try
                {
                    this.ultraDataSource1.Rows.Clear();
                    Dictionary<string, Infragistics.Win.ValueList> lst = this._cEqpDefDspInfoDataTable.GetEquipUIInfo();
                    foreach (string key in lst.Keys)
                    {
                        UltraGridRow row = this.uGrid_EquipInfo.DisplayLayout.Bands[0].AddNew();
                        row.Cells[0].Value = key;
                        row.Cells[1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                        row.Cells[1].ValueList = lst[key];
                        if (lst[key].SelectedItem != null)
                        {
                            row.Cells[1].Value = lst[key].SelectedItem.ToString();
                        }
                    }
                }
                finally
                {
                    this._cEqpDefDspInfoDataTable.EndLoadData();
                }
            }
            else
            {
                this.ultraDataSource1.Rows.Clear();
            }
        }
        
        /// <summary>
        /// Returnキーダウン処理
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        internal bool ReturnKeyDown(Control ctrl)
        {
            if (!(ctrl is UltraGrid)) return false;

            UltraGrid gridCtrl = (UltraGrid)ctrl;
            UltraGridRow row = null;
            if (gridCtrl.ActiveRow != null) row = gridCtrl.ActiveRow;

            switch (gridCtrl.Name)
            {
                //---------------------------------------------------------------
                // カラー情報グリッド
                //---------------------------------------------------------------
                case "uGrid_ColorInfo":
                    {
                        string colorCode = string.Empty;
                        if (row != null)
                        {
                            colorCode = (string)row.Cells[this._colorCdInfoDataTable.ColorCodeColumn.ColumnName].Value;
                            this.SettingColorInfoProc(colorCode);
                        }
                        break;
                    }
                //---------------------------------------------------------------
                // トリム情報グリッド
                //---------------------------------------------------------------
                case "uGrid_TrimInfo":
                    {
                        string trimCode = string.Empty;
                        if (row != null)
                        {
                            trimCode = (string)row.Cells[this._trimCdInfoDataTable.TrimCodeColumn.ColumnName].Value;
                            this.SettingTrimInfoProc(trimCode);
                        }
                        break;
                    }
                //---------------------------------------------------------------
                // 装備情報グリッド
                //---------------------------------------------------------------
                case "uGrid_EquipInfo":
                    {
                        if (this.uGrid_EquipInfo.ActiveCell != null)
                        {
                            int rowIndex = this.uGrid_EquipInfo.ActiveCell.Row.Index;
                            string key = (string)this.uGrid_EquipInfo.Rows[rowIndex].Cells["kind"].Value;
                            Infragistics.Win.ValueList valueList = (Infragistics.Win.ValueList)this.uGrid_EquipInfo.Rows[rowIndex].Cells["value"].ValueList;
                            int selectedIndex = 0;
                            if (valueList != null) selectedIndex = valueList.SelectedIndex;
                            this.SettingEquipInfoProc(key, selectedIndex);
                        }
                        this.uGrid_EquipInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        break;
                    }
            }

            return true;
        }

        /// <summary>
        /// 選択・非選択変更処理（背景色のみ）
        /// </summary>
        /// <param name="isSelected"></param>
        /// <param name="gridRow"></param>
        private void ChangedSelectColor(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
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
                {
                    gridRow.Appearance.BackColor = Color.Lavender;
                }
                else
                {
                    gridRow.Appearance.BackColor = Color.White;
                }
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            }
        }

        /// <summary>
        /// 全ての行の背景色変更
        /// </summary>
        /// <param name="isSelected"></param>
        private void ChangedSelectColorAll(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ultraGrid.Rows)
            {
                ChangedSelectColor(isSelected, row);
            }
        }
        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region Public Methods

        // --- ADD 2011/02/14 -------- >>>>>
        /// <summary>
        /// カラー操作情報設定処理
        /// </summary>
        /// <param name="enableFlg"></param>
        public void uGrid_ColorInfoEnableSet(bool enableFlg)
        {
            if (enableFlg)
            {
                colorGridFlag = true;
            }
            else
            {
                colorGridFlag = false;
            }
        }

        /// <summary>
        /// トリム操作情報設定処理
        /// </summary>
        /// <param name="enableFlg"></param>
        public void uGrid_TrimInfoEnableSet(bool enableFlg)
        {
            if (enableFlg)
            {
                trimGridFlag = true;
            }
            else
            {
                trimGridFlag = false;
            }
        }

        /// <summary>
        /// 装備操作情報設定処理
        /// </summary>
        /// <param name="enableFlg"></param>
        public void uGrid_EquipInfoEnableSet(bool enableFlg)
        {
            if (enableFlg)
            {
                this.uGrid_EquipInfo.DisplayLayout.Bands[0].Columns[1].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            }
            else
            {
                this.uGrid_EquipInfo.DisplayLayout.Bands[0].Columns[1].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
        }
        // --- ADD 2011/02/14 -------- <<<<<

        #endregion

    }
}
