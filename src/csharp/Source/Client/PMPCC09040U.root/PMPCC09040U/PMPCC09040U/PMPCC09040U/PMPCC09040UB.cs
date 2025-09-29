//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : PCC品目設定
// プログラム概要   : PCC品目設定 フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011/07/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2013/05/30  修正内容 : 2013/99/99配信 SCM障害№10541対応 
//----------------------------------------------------------------------------//
// 管理番号  11470103-00  作成担当 : 譚洪
// 作 成 日  2018/07/26   修正内容 : BLパーツオーダー自動回答不具合対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using System.Text.RegularExpressions;
using System.Collections;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 品目グリッド設定タブのフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Node        : 品目グリッド設定タブのフォームクラスです。</br>
    /// <br>Programmer  : 黄海霞</br>
    /// <br>Date        : 2011.07.20</br>
    /// <br>Update Note : BLパーツオーダー自動回答不具合対応</br>
    /// <br>Programmer  : 譚洪</br>
    /// <br>Date        : 2018/07/26</br>
    /// </remarks>
    public partial class PMPCC09040UB : UserControl
    {

        #region Constructor
        /// <summary>
        /// 品目グリッド設定タブフォームコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 品目グリッドフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public PMPCC09040UB(string enterpriseCode, int startMode)
        {
            InitializeComponent();
            this._dsArry = new DataSet[GRIDCOUNT];
            this._dsAll = new DataSet();
            this.InitAllDateSet(PCCITEMST_TABLE);
            for (int gridNo = 0; gridNo < TablePanel_Grids.Controls.Count ; gridNo ++)
            {
                DataSet dataSet = this._dsArry[gridNo];
                UltraGrid ultraGridEach = TablePanel_Grids.Controls[gridNo] as UltraGrid;
                string name = ultraGridEach.Name;
                this.InitGrid(ref dataSet, ref ultraGridEach, gridNo);
            }
           
            _bLGoodsCdAcs = new BLGoodsCdAcs();
            _enterpriseCode = enterpriseCode;
            _startMode = startMode;
            //BLコード情報リスト取得
            GetBLGoodsCdUMntList();
        }
        #endregion

        #region Const Members
        /// <summary>PCC品目設定テーブル</summary>
        private const string PCCITEMST_TABLE = "PCCITEMST_TABLE";
        private const string PCCITEMST_TABLE2 = "PCCITEMST_TABLE2";
        private const string BLSELECT_TITLE = "SELECT";
        private const string BLGOODSCODE_TITLE = "BLCD";
        /// <summary>ガイドボタン列</summary>
        private const string BLGUID_TITLE = "GUID";
        private const string BLGOODSNAME_TITLE = "商品名";
        private const string BLGOODSQTY_TITLE = "QTY";
        private const string BLGRIDNO_TITLE = "GRIDNO";

        private const string BLSELECT_NAME = "";
        private const string BLGOODSCODE_NAME = "BLCD";
        /// <summary>ガイドボタン列</summary>
        private const string BLGUID_NAME = "";
        private const string BLGOODSNAME_NAME = "商品名";
        private const string BLGOODSQTY_NAME = "QTY";
        private const int MAXROW = 8;
        private const int MAXALLROW = 64;
        private const int GRIDCOUNT = 8;
        #endregion

        #region Private Members
        /// <summary>グリッド1表示用データセット</summary>
        private DataSet [] _dsArry = null;
        private DataSet _dsAll = null;
        private string _enterpriseCode;
        private int _startMode;
        private UltraGrid _seletedUtraGrid = null;
        private int _gridNo = 0;

        private BLGoodsCdAcs _bLGoodsCdAcs;
        /// <summary>
        /// 元BLコード
        /// </summary>
        private int _beforeBLGoodsCode = 0;
        //品目選択区分Hashtable
        private Hashtable _blCheckedInfoTb = null;
        //品目BLコード情報Hashtable
        private Hashtable _bLGoodsCdUMntTb = null;
        //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 ----->>>>>
        /// <summary>
        /// 品目選択区分Hashtable
        /// </summary>
        public Hashtable BlCheckedInfoTb
        {
            get
            {
                return this._blCheckedInfoTb;
            }
            set
            {
                this._blCheckedInfoTb = value;
            }
        }
        //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 -----<<<<<

        #endregion

        #region Private Methods
         /// <summary>
        /// グリッドの初期化
        /// </summary>
        /// <param name="tableName">グリッド名称</param>
        /// <remarks>
        /// <br>Note       : グリッドの初期化を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void InitAllDateSet(string tableName)
        {
            if (this._dsAll.Tables[tableName] == null)
            {
                if (this._dsAll.Tables[tableName] == null)
                {
                    // テーブルの定義
                    DataTable dt1 = new DataTable(tableName);
                    dt1.Columns.Add(BLSELECT_TITLE, typeof(bool));
                    dt1.Columns.Add(BLGOODSCODE_TITLE, typeof(int));
                    dt1.Columns.Add(BLGUID_TITLE, typeof(string));
                    dt1.Columns.Add(BLGOODSNAME_TITLE, typeof(string));
                    dt1.Columns.Add(BLGOODSQTY_TITLE, typeof(int));
                    dt1.Columns.Add(BLGRIDNO_TITLE, typeof(int));
                    this._dsAll.Tables.Add(dt1);
                }
            }

            if (this._dsAll.Tables[tableName] != null)
            {
                this._dsAll.Tables[tableName].Clear();
                for (int index = 0; index < MAXALLROW; index++)
                {

                    // 新規と判断して、行を追加する
                    DataRow dataRow = this._dsAll.Tables[tableName].NewRow();
                    this._dsAll.Tables[tableName].Rows.Add(dataRow);
                    this._dsAll.Tables[tableName].Rows[index][BLSELECT_TITLE] = false;
                    this._dsAll.Tables[tableName].Rows[index][BLGOODSCODE_TITLE] = DBNull.Value;
                    this._dsAll.Tables[tableName].Rows[index][BLGOODSNAME_TITLE] = string.Empty;
                    this._dsAll.Tables[tableName].Rows[index][BLGOODSQTY_TITLE] = DBNull.Value;
                    this._dsAll.Tables[tableName].Rows[index][BLGRIDNO_TITLE] = index / GRIDCOUNT;
                }
            }
        }

        /// <summary>
        /// グリッドの初期化
        /// </summary>
        /// <param name="dataSet">グリッドのDataSet</param>
        /// <param name="ultraGrid">グリッド</param>
        /// <param name="gridNo">グリッドNO</param>
        /// <remarks>
        /// <br>Note       : グリッドの初期化を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// <br>Update Note: BLパーツオーダー自動回答不具合対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2018/07/26</br>
        /// </remarks>
        private void InitGrid(ref DataSet dataSet, ref UltraGrid ultraGrid, int gridNo)
        {
            // グリッドの初期設定処理
            // グリッドへバインド
            if (_dsAll.Tables[PCCITEMST_TABLE] != null)
            {
                dataSet = _dsAll.Copy();

                DataView dataView = dataSet.Tables[PCCITEMST_TABLE].DefaultView;
                dataView.RowFilter = BLGRIDNO_TITLE + " = " + gridNo;
                ultraGrid.DataSource = dataView;

                UltraGridBand editBand = ultraGrid.DisplayLayout.Bands[PCCITEMST_TABLE];
                ultraGrid.DisplayLayout.Override.EditCellAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
                ultraGrid.DisplayLayout.Override.EditCellAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
                //列の表示Style設定
                editBand.Columns[BLSELECT_TITLE].Header.Caption = BLSELECT_NAME;
                editBand.Columns[BLGOODSCODE_TITLE].Header.Caption = BLGOODSCODE_NAME;
                editBand.Columns[BLGUID_TITLE].Header.Caption = BLGUID_TITLE;
                editBand.Columns[BLGOODSNAME_TITLE].Header.Caption = BLGOODSNAME_NAME;
                editBand.Columns[BLGOODSQTY_TITLE].Header.Caption = BLGOODSQTY_NAME;
                editBand.Columns[BLGRIDNO_TITLE].Header.Caption = BLGRIDNO_TITLE;
                //グリッドタイプ
                editBand.Columns[BLSELECT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                editBand.Columns[BLGUID_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                
                //
                editBand.Columns[BLSELECT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                editBand.Columns[BLGOODSCODE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                editBand.Columns[BLGUID_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                editBand.Columns[BLGOODSNAME_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                editBand.Columns[BLGOODSQTY_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                editBand.Columns[BLGRIDNO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                editBand.Columns[BLGOODSNAME_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                
               //初期化値の設定
                editBand.Columns[BLSELECT_TITLE].DefaultCellValue = false;
                editBand.Columns[BLGOODSCODE_TITLE].DefaultCellValue = DBNull.Value;
                editBand.Columns[BLGOODSNAME_TITLE].DefaultCellValue = string.Empty;
                editBand.Columns[BLGOODSQTY_TITLE].DefaultCellValue = DBNull.Value;
                editBand.Columns[BLGRIDNO_TITLE].DefaultCellValue = gridNo;
               this._beforeBLGoodsCode = 0;
               //編集グリッドグループ設定
               if (editBand == null)
               {
                   return;
               }
                
               editBand.Groups.Clear();
               // グループヘッダのみ表示するようにする
               editBand.ColHeadersVisible = false;
               if (gridNo >= (GRIDCOUNT / 2))
               {
                   editBand.GroupHeadersVisible = false;
               }
               else
               {
                   editBand.GroupHeadersVisible = true;
               }
               // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
               ////BL選択
               //UltraGridGroup ultraGridGroup = editBand.Groups.Add(BLSELECT_TITLE, editBand.Columns[BLSELECT_TITLE].Header.Caption);
               //ultraGridGroup.Columns.Add(editBand.Columns[BLSELECT_TITLE]);
               // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
               //BLコードグループ
               // ---UPD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
               //ultraGridGroup = editBand.Groups.Add(BLGOODSCODE_TITLE, editBand.Columns[BLGOODSCODE_TITLE].Header.Caption);
               UltraGridGroup ultraGridGroup = editBand.Groups.Add(BLGOODSCODE_TITLE, editBand.Columns[BLGOODSCODE_TITLE].Header.Caption);
               // ---UPD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
               ultraGridGroup.Columns.Add(editBand.Columns[BLGOODSCODE_TITLE]);
               ultraGridGroup.Columns.Add(editBand.Columns[BLGUID_TITLE]);
               //BL名称
               ultraGridGroup = editBand.Groups.Add(BLGOODSNAME_TITLE, editBand.Columns[BLGOODSNAME_TITLE].Header.Caption);
               ultraGridGroup.Columns.Add(editBand.Columns[BLGOODSNAME_TITLE]);
               //BL名称
               ultraGridGroup = editBand.Groups.Add(BLGOODSQTY_TITLE, editBand.Columns[BLGOODSQTY_TITLE].Header.Caption);
               ultraGridGroup.Columns.Add(editBand.Columns[BLGOODSQTY_TITLE]);

               editBand.Columns[BLGRIDNO_TITLE].Hidden = true;
                
               // ボタンのスタイルを設定する
               ImageList imageList16 = IconResourceManagement.ImageList16;
               editBand.Columns[BLGUID_TITLE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
               editBand.Columns[BLGUID_TITLE].CellButtonAppearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
               editBand.Columns[BLGUID_TITLE].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
               editBand.Columns[BLGUID_TITLE].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;

               //editBand.Columns[BLSELECT_TITLE].Width = 10; // DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
               editBand.Columns[BLGOODSCODE_TITLE].Width = 50;
               editBand.Columns[BLGUID_TITLE].Width = 20;
               // ---UPD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
               //editBand.Columns[BLGOODSNAME_TITLE].Width = 95;
               editBand.Columns[BLGOODSNAME_TITLE].Width = 113;
               // ---UPD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
               editBand.Columns[BLGOODSQTY_TITLE].Width = 40;
               ultraGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

               //BL商品コードはNUｌｌ場合、品目選択区分、品目QTYは入力不可
               for (int rowIndex = 0; rowIndex < ultraGrid.Rows.Count; rowIndex++)
               {
                   UltraGridRow ultraGridRow = ultraGrid.Rows[rowIndex];
                   if (ultraGridRow.Cells[BLGOODSCODE_TITLE].Value == DBNull.Value)
                   {
                       ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                       ultraGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activation = Activation.NoEdit;
                   }
                   else
                   {
                       ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                       ultraGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activation = Activation.AllowEdit;
                   }
               }
            }
        }

        /// <summary>
        /// PCC品目グループデータセット展開処理
        /// </summary>
        /// <param name="pccItemSt">PCC品目設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : PCC品目設定をデータセットに格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemStToDataSet(PccItemSt pccItemSt)
        {
            if (pccItemSt == null)
            {
                return;
            }
            //品目選択区分 0:OFF 1:選択ｳｨﾝﾄﾞｳ表示
            int rowIndex = pccItemSt.ItemDspPos1;
            int colIndex = pccItemSt.ItemDspPos2;
            int nowIndex = 0;
            if (colIndex >= MAXROW)
            {
                nowIndex = (rowIndex + GRIDCOUNT / 2 -1) * MAXROW + colIndex;
            }
            else
            {
                nowIndex = rowIndex * MAXROW + colIndex;
            }
            DataRow dataRow = this._dsAll.Tables[PCCITEMST_TABLE].Rows[nowIndex];
            bool itemSelectFlag = false;
            if (pccItemSt.ItemSelectDiv == 0)
            {
                itemSelectFlag = false;
            }
            else
            {
                itemSelectFlag = true;
            }
            dataRow[BLSELECT_TITLE] = itemSelectFlag;
            if (pccItemSt.BLGoodsCode == 0)
            {
                dataRow[BLGOODSCODE_TITLE] = DBNull.Value;
            }
            else
            {
                dataRow[BLGOODSCODE_TITLE] = pccItemSt.BLGoodsCode;
               
            }
            dataRow[BLGOODSNAME_TITLE] = pccItemSt.BLGoodsName;
            dataRow[BLGOODSQTY_TITLE] = pccItemSt.ItemQty;
        }

        /// <summary>
        /// PCC品目の８つグリッド展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note       :  PCC品目の８つグリッドを展開処理します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void GridGroupBy()
        {
            DataView[] dataViewArrys = new DataView[GRIDCOUNT];
            for (int daIndex = 0; daIndex < this._dsArry.Length; daIndex++)
            {
                int daIndexAdd = daIndex;
                UltraGrid ultraGrid = (UltraGrid)this.TablePanel_Grids.Controls[daIndex];
                dataViewArrys[daIndex] = this._dsAll.Copy().Tables[PCCITEMST_TABLE].DefaultView;
                dataViewArrys[daIndex].RowFilter = BLGRIDNO_TITLE + " = " + daIndexAdd;
                ultraGrid.DataSource = dataViewArrys[daIndex];
               //BL商品コードはNUｌｌ場合、品目選択区分、品目QTYは入力不可
                for (int rowIndex = 0; rowIndex < ultraGrid.Rows.Count; rowIndex++)
                {
                    UltraGridRow ultraGridRow = ultraGrid.Rows[rowIndex];
                    if (ultraGridRow.Cells[BLGOODSCODE_TITLE].Value == DBNull.Value)
                    {
                        ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                        ultraGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activation = Activation.NoEdit;
                    }
                    else
                    {
                        ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                        ultraGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activation = Activation.AllowEdit;
                    }
                }
            }
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <param name="ultraGrid">ultraGrid</param>
        /// <param name="gridNo">gridNo</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 次入力可能セル移動処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool MoveDownAllowEditCell(bool activeCellCheck, ref  UltraGrid ultraGrid, ref int gridNo, KeyEventArgs e)
        {
            bool performActionResult = false;
            string key = ultraGrid.ActiveCell.Column.Key;
            int rowIndex = ultraGrid.ActiveCell.Row.Index;
            int columnIndex = ultraGrid.ActiveCell.Column.Index;
            try
            {
                // 更新開始（描画ストップ）
                ultraGrid.BeginUpdate();
                if ((ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                    (ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                }
                switch (e.KeyCode)
                {
                    case Keys.Up :
                        {
                            if (ultraGrid.ActiveCell != null && ultraGrid.ActiveCell.Row.Index == 0
                            && gridNo > 0)
                            {
                                ultraGrid.ActiveCell.Activated = false;
                                // 更新終了（描画再開）
                                ultraGrid.EndUpdate(false);
                                gridNo = gridNo - 1;

                                ultraGrid = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                                ultraGrid.Focus();
                                ultraGrid.Rows[MAXROW - 1].Cells[key].Activate();
                                if ((ultraGrid.Rows[MAXROW - 1].Cells[key].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                       (ultraGrid.Rows[MAXROW - 1].Cells[key].Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                                {
                                    ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                }
                                rowIndex = MAXROW - 1;
                            }
                            break;
                        }
                    case Keys.Down:
                        {
                            if (ultraGrid.ActiveCell != null && ultraGrid.ActiveCell.Row.Index == (MAXROW - 1) && gridNo < 7)
                            {
                                ultraGrid.ActiveCell.Activated = false;
                                // 更新終了（描画再開）
                                ultraGrid.EndUpdate(false);
                                gridNo = gridNo + 1;
                                ultraGrid = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;

                                ultraGrid.Focus();
                                ultraGrid.Rows[0].Cells[key].Activate();
                                if ((ultraGrid.Rows[0].Cells[key].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                      (ultraGrid.Rows[0].Cells[key].Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                                {
                                    ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                }
                                rowIndex = 0;
                            }
                            break;
                        }
                    case Keys.Left:
                        {
                            if (ultraGrid.ActiveCell != null && gridNo == 0 && key.Equals(BLSELECT_TITLE) && rowIndex == 0)
                            {
                                return performActionResult;
                            }
                            if (ultraGrid.ActiveCell != null && key.Equals(BLSELECT_TITLE))
                            {
                                ultraGrid.ActiveCell.Activated = false;
                                // 更新終了（描画再開）
                                ultraGrid.EndUpdate(false);
                                if (gridNo % (GRIDCOUNT / 2) == 0)
                                {
                                    rowIndex--;
                                    if (gridNo < (GRIDCOUNT / 2))
                                    {
                                        gridNo = (GRIDCOUNT / 2) -1;
                                    }
                                    else
                                    {
                                        gridNo = GRIDCOUNT -1;
                                    }
                                    if (rowIndex == -1)
                                    {
                                        rowIndex = MAXROW - 1;
                                        gridNo = (GRIDCOUNT / 2) - 1;
                                    }
                                }
                                else
                                {
                                    gridNo = gridNo - 1;
                                }
                                ultraGrid = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                                ultraGrid.Focus();
                                ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activate();
                                 if ((ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                       (ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                                {
                                    ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                 }
                                e.Handled = true;
                            }
                            break;
                        }
                    case Keys.Right:
                        {
                            if (ultraGrid.ActiveCell != null && gridNo == (GRIDCOUNT - 1) && key.Equals(BLGOODSQTY_TITLE) && rowIndex == MAXROW -1)
                            {
                                return performActionResult;
                            }
                            if (ultraGrid.ActiveCell != null && key.Equals(BLGOODSQTY_TITLE))
                            {
                                ultraGrid.ActiveCell.Activated = false;
                                // 更新終了（描画再開）
                                ultraGrid.EndUpdate(false);
                                if (gridNo % (GRIDCOUNT / 2) == 3)
                                {
                                    rowIndex++;
                                    if (gridNo < (GRIDCOUNT / 2))
                                    {
                                        gridNo = 0;
                                    }
                                    else
                                    {
                                        gridNo = GRIDCOUNT / 2;
                                    }
                                    if (rowIndex == MAXROW)
                                    {
                                        rowIndex = 0;
                                        gridNo = GRIDCOUNT / 2;
                                    }
                                }
                                else
                                {
                                    gridNo++;
                                }
                                ultraGrid = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                                ultraGrid.Focus();
                                ultraGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activate();
                                e.Handled = true;
                            }
                            break;
                        }
                }
               

            }
            finally
            {
                // 更新終了（描画再開）
                ultraGrid.EndUpdate();
            }

            return performActionResult;
        }

        /// <summary>
        /// 正数字判断
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="charCount">文字列位数</param>
        /// <returns>True:数字; False:非数字</returns>
        /// <remarks>
        /// <br>Note       : 正数字判断処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool IsDigitAdd(String str, int charCount)
        {

            string regex1 = "^[0-9]{0," + charCount + "}$";
            Regex objRegex = new Regex(regex1);
            return objRegex.IsMatch(str);
        }

        /// <summary>
        /// BLコード情報リスト取得
        /// </summary>
        /// <remarks>
        /// <br>Note       :  BLコード情報リスト取得を処理します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void GetBLGoodsCdUMntList()
        {
            ArrayList bLGoodsCdUMntList = null;
            int status = _bLGoodsCdAcs.SearchAll(out bLGoodsCdUMntList, this._enterpriseCode);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                _bLGoodsCdUMntTb = new Hashtable();
                foreach (BLGoodsCdUMnt bLGoodsCdUMnt in bLGoodsCdUMntList)
                {
                    if (bLGoodsCdUMnt.LogicalDeleteCode == 0)
                    {
                        _bLGoodsCdUMntTb.Add(bLGoodsCdUMnt.BLGoodsCode, bLGoodsCdUMnt.BLGoodsHalfName);
                    }
                }
            }
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// グリッドのクリア
        /// </summary>
        /// <remarks>
        /// <br>Note       : クリアの初期化を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>>
        public void ClearTable()
        {
            if (this._dsAll != null)
            {
                for (int index = 0; index < MAXALLROW; index++)
                {

                    // 新規と判断して、行を追加する
                    DataRow dataRow = this._dsAll.Tables[PCCITEMST_TABLE].Rows[index];
                    dataRow[BLSELECT_TITLE] = false;
                    dataRow[BLGOODSCODE_TITLE] = DBNull.Value;
                    dataRow[BLGOODSNAME_TITLE] = string.Empty;
                    dataRow[BLGOODSQTY_TITLE] = DBNull.Value;
                    dataRow[BLGRIDNO_TITLE] = index / GRIDCOUNT;
                }
            }
            //PCC品目の８つグリッド展開処理
            GridGroupBy();
            SetInitFocus((int)PMPCC09040UA.StartMode.MODE_NEW);
        }

        /// <summary>
        /// PCC品目画面展開処理
        /// </summary>
        /// <param name="pccItemStList">PCC品目設定リスト</param>
        /// <remarks>
        /// <br>Note       : 画面展開処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public void PccItemToGrid(List<PccItemSt> pccItemStList)
        {
            if (this._dsAll.Tables[PCCITEMST_TABLE] != null)
            {
                int index = 0;
                foreach (PccItemSt pccItemSt in pccItemStList)
                {
                    index = pccItemSt.ItemDspPos1;
                    PccItemStToDataSet(pccItemSt.Clone());
                   
                }
                //PCC品目の８つグリッド展開処理
                GridGroupBy();
            }
       

        }

        /// <summary>
        /// PCC品目画面展開処理
        /// </summary>
        /// <param name="pccItemStDic">PCC品目設定リスト</param>
        /// <param name="pccItemGrid">PCC品目グループリスト</param>
        /// <param name="tabOrder">Tabb番号</param>
        /// <remarks>
        /// <br>Note       : 画面展開処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// <br>Update Note: BLパーツオーダー自動回答不具合対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2018/07/26</br>
        /// </remarks>
        public void GridToPccItem(out Dictionary<int, PccItemSt> pccItemStDic, PccItemGrid pccItemGrid, int tabOrder)
        {
            //PCC品目設定ディクショナリーの初期化
            pccItemStDic = new Dictionary<int, PccItemSt>();
            //
            for (int gridNo = 0; gridNo < this.TablePanel_Grids.Controls.Count; gridNo++)
            {
                UltraGrid ultraGridEach = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                if (ultraGridEach == null || ultraGridEach.Rows.Count == 0)
                {
                    continue;
                }
                int gridCount = ultraGridEach.Rows.Count;
                for (int i = 0; i < gridCount; i++)
                {
                    UltraGridRow dataRow = ultraGridEach.Rows[i];
                    PccItemSt pccItemSt = new PccItemSt();
                    if (dataRow.Cells[BLGOODSCODE_TITLE].Value == DBNull.Value)
                    {
                        pccItemSt.BLGoodsCode = 0;
                        continue;
                    }
                    else
                    {
                        pccItemSt.BLGoodsCode = (int)dataRow.Cells[BLGOODSCODE_TITLE].Value;
                    }
                    pccItemSt.BLGoodsName = (string)dataRow.Cells[BLGOODSNAME_TITLE].Value;
                    //品目表示位置1 横(X)方向の位置
                    int itemDspPos1 = 0;
                    int listDiv = 0;
                    if (gridNo >= (GRIDCOUNT / 2))
                    {
                        itemDspPos1 = gridNo - (GRIDCOUNT / 2);
                        //品目表示位置2 縦(Y)方向の位置
                        pccItemSt.ItemDspPos2 = i + MAXROW;
                        listDiv = (itemDspPos1 + ((GRIDCOUNT / 2))) * MAXROW + i;
                    }
                    else
                    {
                        itemDspPos1 = gridNo;
                        pccItemSt.ItemDspPos2 = i;
                        listDiv = itemDspPos1 * MAXROW + i;
                    }
                    pccItemSt.ItemDspPos1 = itemDspPos1;

                    // ---UPD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
                    //int itemSelectDiv = 0;
                    //if (dataRow.Cells[BLGOODSQTY_TITLE].Value is System.DBNull || dataRow.Cells[BLGOODSQTY_TITLE].Value == DBNull.Value)
                    //{
                    //    itemSelectDiv = 0;
                    //}
                    //else
                    //{
                    //    if (!(bool)dataRow.Cells[BLSELECT_TITLE].Value)
                    //    {
                    //        itemSelectDiv = 0;
                    //    }
                    //    else
                    //    {
                    //        itemSelectDiv = 1;
                    //    }
                    //}
                    //pccItemSt.ItemSelectDiv = itemSelectDiv;
                    pccItemSt.ItemSelectDiv = 1;
                    // ---UPD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<

                    int itemQty = 0;
                    if (dataRow.Cells[BLGOODSQTY_TITLE].Value is System.DBNull || dataRow.Cells[BLGOODSQTY_TITLE].Value == DBNull.Value)
                    {
                        itemQty = 0;

                    }
                    else
                    {
                        itemQty = (int)dataRow.Cells[BLGOODSQTY_TITLE].Value;
                    }
                    pccItemSt.ItemQty = itemQty;
                    pccItemSt.InqOriginalEpCd = pccItemGrid.InqOriginalEpCd.Trim();//@@@@20230303
                    pccItemSt.InqOriginalSecCd = pccItemGrid.InqOriginalSecCd;
                    pccItemSt.InqOtherEpCd = pccItemGrid.InqOtherEpCd;
                    pccItemSt.InqOtherSecCd = pccItemGrid.InqOtherSecCd;
                    pccItemSt.PccCompanyCode = pccItemGrid.PccCompanyCode;
                    pccItemSt.ItemGroupCode = tabOrder;

                    
                  
                    pccItemStDic.Add(listDiv, pccItemSt);
                }
            }
        }

        /// <summary>
        /// BLコードチェックテプッル取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLコードチェックテプッル取得処理</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public void InitBlCheckedTb()
        {
            //_blCheckedInfoTb = new Hashtable(); // DEL by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921
            //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 ----->>>>>
            if (_blCheckedInfoTb == null)
            {
                _blCheckedInfoTb = new Hashtable();
            }
            //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 -----<<<<<
            for (int gridNo = 0; gridNo < this.TablePanel_Grids.Controls.Count; gridNo++)
            {
                UltraGrid ultraGridEach = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                if (ultraGridEach == null || ultraGridEach.Rows.Count == 0)
                {
                    continue;
                }
                int gridCount = ultraGridEach.Rows.Count;
                for (int i = 0; i < gridCount; i++)
                {
                    UltraGridRow dataRow = ultraGridEach.Rows[i];
                    int blCode = 0;
                    if (dataRow.Cells[BLGOODSCODE_TITLE].Value == DBNull.Value)
                    {
                        blCode = 0;
                        continue;
                    }
                    else
                    {
                        blCode = (int)dataRow.Cells[BLGOODSCODE_TITLE].Value;
                    }


                    bool itemSelectDiv = false;
                    if (dataRow.Cells[BLGOODSQTY_TITLE].Value is System.DBNull || dataRow.Cells[BLGOODSQTY_TITLE].Value == DBNull.Value)
                    {
                        itemSelectDiv = false;
                    }
                    else
                    {
                        itemSelectDiv = (bool)dataRow.Cells[BLSELECT_TITLE].Value;
                    }
                    if (!_blCheckedInfoTb.ContainsKey(blCode))
                    {
                        _blCheckedInfoTb.Add(blCode, itemSelectDiv);
                    }
                }
            }
        }

        //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 ----->>>>>
        /// <summary>
        /// BLコードチェック更新処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLコードチェック更新処理</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public void SetBlChecked()
        {
            if (_blCheckedInfoTb != null)
            {
                //同じBLコードの選択更新
                for (int gridNo = 0; gridNo < this.TablePanel_Grids.Controls.Count; gridNo++)
                {
                    UltraGrid ultraGridEach = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                    if (ultraGridEach == null || ultraGridEach.Rows.Count == 0)
                    {
                        continue;
                    }
                    int gridCount = ultraGridEach.Rows.Count;
                    for (int i = 0; i < gridCount; i++)
                    {
                        UltraGridRow dataRow = ultraGridEach.Rows[i];
                        int blGroupCode = 0;
                        if (dataRow.Cells[BLGOODSCODE_TITLE].Value != DBNull.Value && dataRow.Cells[BLGOODSCODE_TITLE].Value != null)
                        {
                            blGroupCode = (int)dataRow.Cells[BLGOODSCODE_TITLE].Value;
                            if (_blCheckedInfoTb != null && _blCheckedInfoTb.ContainsKey(blGroupCode))
                            {
                                bool checkValue = (bool)dataRow.Cells[BLSELECT_TITLE].Value;
                                bool checkValueSave = !(bool)_blCheckedInfoTb[blGroupCode];
                                if (!checkValue.Equals((bool)_blCheckedInfoTb[blGroupCode]))
                                {
                                    dataRow.Cells[BLSELECT_TITLE].Value = _blCheckedInfoTb[blGroupCode];
                                }
                            }
                        }
                        
                    }
                }

            }
        }
        //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 -----<<<<<

        /// <summary>
        /// 画面グリッド編集許可制御処理
        /// </summary>
        /// <param name="enabled">入力許可設定値</param>
        /// <remarks>
        /// <br>Note       : 画面のグリッド編集を制御します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public void PermissionControl(bool enabled)
        {
             //
            for (int gridNo = 0; gridNo < this.TablePanel_Grids.Controls.Count; gridNo++)
            {
                UltraGrid ultraGridEach = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                if (ultraGridEach == null || ultraGridEach.Rows.Count == 0)
                {
                    continue;
                }
                ultraGridEach.Enabled = enabled;
            }
        }

        /// <summary>タブ表示の初期フォーカスの設定</summary>
        /// <param name="startMode">募集型企画旅行　マネージメントクラス</param>
        /// <remarks>
        /// Note       : タブ表示の初期フォーカスを設定します<br />
        /// Programmer : 黄海霞<br />
        /// Date       : 2011.07.20<br />
        /// </remarks>
        public void SetInitFocus(int startMode)
        {
            this._startMode = startMode;
            // 論理削除データ以外の場合
            if (this._startMode != (int)PMPCC09040UA.StartMode.MODE_EDITLOGICDELETE)
            {
                for (int gridNo = 0; gridNo < TablePanel_Grids.Controls.Count; gridNo++)
                {
                    UltraGrid ultraGridEach = TablePanel_Grids.Controls[gridNo] as UltraGrid;
                    if (ultraGridEach.Rows.Count > 0)
                    {
                        ultraGridEach.ActiveCell = null;
                        // 更新終了（描画再開）
                        ultraGridEach.EndUpdate(false);
                    }
                }
            }
            UltraGrid ultraGrid = TablePanel_Grids.Controls[0] as UltraGrid;
            ultraGrid.Focus();
        }

        #region ReturnKeyDown
        /// <summary>
        /// ReturnKey押下処理(グリッド内)
        /// </summary>
        /// <param name="mode">モード</param>
        /// <param name="e">イベントハンドラ</param>
        /// <param name="ultraGrid">ultraGrid</param>
        /// <param name="gridNo">gridNo</param>
        /// <remarks>
        /// <br>Note       : ReturnKey押下処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public void ReturnKeyDown(ref ChangeFocusEventArgs e, int mode, ref  UltraGrid ultraGrid, int gridNo)
        {

            if (ultraGrid.Rows.Count > 0)
            {
                if ((ultraGrid.ActiveCell == null) && (ultraGrid.ActiveRow == null))
                {
                    ultraGrid.Rows[0].Cells[BLGOODSCODE_TITLE].Activate();
                }

                string columnKey;
                int rowIndex;

                if (ultraGrid.ActiveCell != null)
                {
                    columnKey = ultraGrid.ActiveCell.Column.Key;
                    rowIndex = ultraGrid.ActiveCell.Row.Index;
                }
                else
                {
                    columnKey = BLGOODSCODE_TITLE;
                    rowIndex = ultraGrid.ActiveRow.Index;
                }

                e.NextCtrl = null;

                ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                if (ultraGrid.ActiveCell != null)
                {
                    MoveNextAllowEditCell(false, ref ultraGrid, gridNo);
                }
                else if(ultraGrid.ActiveRow != null)
                {
                    ultraGrid.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                    ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <param name="ultraGrid">ultraGrid</param>
        /// <param name="gridNo">gridNo</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 次入力可能セル移動処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck, ref  UltraGrid ultraGrid, int gridNo)
        {
            bool moved = false;
            bool performActionResult = false;

            try
            {
                // 更新開始（描画ストップ）
                ultraGrid.BeginUpdate();

                if ((activeCellCheck) && (ultraGrid.ActiveCell != null))
                {
                    if ((!ultraGrid.ActiveCell.Column.Hidden) &&
                        (ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                }

                while (!moved)
                {
                    if (ultraGrid.ActiveCell != null && ultraGrid.ActiveCell.Row.Index == ultraGrid.Rows.Count - 1
                        && ultraGrid.ActiveCell.Column.Key == BLGOODSQTY_TITLE && gridNo < (GRIDCOUNT - 1))
                    {
                        ultraGrid.ActiveCell = null;
                        // 更新終了（描画再開）
                        ultraGrid.EndUpdate(false);
                        ultraGrid = this.TablePanel_Grids.Controls[gridNo + 1] as UltraGrid;
                        //BLCD
                        int blCd = 0;
                        if (ultraGrid.Rows[0].Cells[BLGOODSCODE_TITLE].Value != DBNull.Value)
                        {
                            blCd = (int)ultraGrid.Rows[0].Cells[BLGOODSCODE_TITLE].Value;
                        }
                        if (blCd == 0)
                        {
                            ultraGrid.Rows[0].Cells[BLGOODSCODE_TITLE].Activate();
                        }
                        else
                        {
                            ultraGrid.Rows[0].Cells[BLSELECT_TITLE].Activate();
                        }
                        this._gridNo = gridNo + 1;
                        moved = true;
                    }

                    else
                    {
                        //BLCD
                        int blCd = 0;
                        if (ultraGrid.Rows[MAXROW - 1].Cells[BLGOODSCODE_TITLE].Value != DBNull.Value)
                        {
                            blCd = (int)ultraGrid.Rows[MAXROW - 1].Cells[BLGOODSCODE_TITLE].Value;
                        }
                        //一つグリッドの第一行
                        if (ultraGrid.ActiveCell != null && ultraGrid.ActiveCell.Row.Index == MAXROW - 1
                            && ultraGrid.ActiveCell.Column.Key == BLGOODSCODE_TITLE && blCd == 0 && this._gridNo == (GRIDCOUNT - 1))
                        {
                            moved = false;
                            break;
                        }
                        performActionResult = ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                        if (performActionResult)
                        {
                            if ((ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                (ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                }

                if (moved)
                {
                    ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // 更新終了（描画再開）
                ultraGrid.EndUpdate();
            }

            return performActionResult;
        }

        #endregion ReturnKeyDown

        #region ShiftKeyDown
        /// <summary>
        /// ShiftKey押下処理(グリッド内)
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <param name="mode">モード</param>
        /// <param name="ultraGrid">ultraGrid</param>
        /// <param name="gridNo">gridNo</param>
        /// <remarks>
        /// <br>Note       : ShiftKey押下処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public void ShiftKeyDown(ref ChangeFocusEventArgs e, int mode, ref  UltraGrid ultraGrid, int gridNo)
        {

            if ((ultraGrid.ActiveCell == null) && (ultraGrid.ActiveRow == null))
            {
                ultraGrid.Rows[0].Cells[BLGOODSCODE_TITLE].Activate();
            }

            string columnKey;
            int rowIndex;

            if (ultraGrid.ActiveCell != null)
            {
                columnKey = ultraGrid.ActiveCell.Column.Key;
                rowIndex = ultraGrid.ActiveCell.Row.Index;
            }
            else
            {
                columnKey = BLGOODSCODE_TITLE;
                rowIndex = ultraGrid.ActiveRow.Index;
            }

            e.NextCtrl = null;

            ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            if (ultraGrid.ActiveCell != null)
            {
                MovePreAllowEditCell(false, ref ultraGrid, gridNo);
            }
            else if (ultraGrid.ActiveRow != null)
            {
                ultraGrid.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                this._gridNo = gridNo;
            }
        }

        /// <summary>
        /// 前入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <param name="ultraGrid">ultraGrid</param>
        /// <param name="gridNo">gridNo</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 前入力可能セル移動処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool MovePreAllowEditCell(bool activeCellCheck, ref UltraGrid ultraGrid, int gridNo)
        {
            bool moved = false;
            bool performActionResult = false;
            //BLCD
            int blCd = 0;
            try
            {
                // 更新開始（描画ストップ）
                ultraGrid.BeginUpdate();

                if ((activeCellCheck) && (ultraGrid.ActiveCell != null))
                {
                    if ((!ultraGrid.ActiveCell.Column.Hidden) &&
                        (ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                }

                while (!moved)
                {
                    if (ultraGrid.ActiveCell != null && ultraGrid.ActiveCell.Row.Index == 0
                                    && ultraGrid.ActiveCell.Column.Key == BLSELECT_TITLE && gridNo > 0)
                    {
                        ultraGrid.ActiveCell = null;
                        // 更新終了（描画再開）
                        ultraGrid.EndUpdate(false);
                        ultraGrid = this.TablePanel_Grids.Controls[gridNo - 1] as UltraGrid;
                        ultraGrid.Focus();

                        if (ultraGrid.Rows[MAXROW - 1].Cells[BLGOODSCODE_TITLE].Value != DBNull.Value)
                        {
                            blCd = (int)ultraGrid.Rows[MAXROW - 1].Cells[BLGOODSCODE_TITLE].Value;
                        }
                        if (blCd == 0)
                        {
                            ultraGrid.Rows[MAXROW - 1].Cells[BLGOODSCODE_TITLE].Activate();
                        }
                        else
                        {
                            ultraGrid.Rows[MAXROW - 1].Cells[BLGOODSQTY_TITLE].Activate();
                        }
                        this._gridNo = gridNo - 1;

                        moved = true;
                    }
                    else
                    {
                        //BLCD
                        blCd = 0;
                        if (ultraGrid.Rows[0].Cells[BLGOODSCODE_TITLE].Value != DBNull.Value)
                        {
                            blCd = (int)ultraGrid.Rows[0].Cells[BLGOODSCODE_TITLE].Value;
                        }
                        //一つグリッドの第一行
                        if (ultraGrid.ActiveCell != null && ultraGrid.ActiveCell.Row.Index == 0
                            && ultraGrid.ActiveCell.Column.Key == BLGOODSCODE_TITLE && blCd == 0 && this._gridNo == 0)
                        {
                            moved = false;
                            break;
                        }
                        performActionResult = ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                        if (performActionResult)
                        {

                            if ((ultraGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                (ultraGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                }

                if (moved)
                {
                    ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // 更新終了（描画再開）
                ultraGrid.EndUpdate();
            }

            return performActionResult;
        }

        #endregion ShiftKeyDown

        // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 画像番号コンボ設定
        /// </summary>
        /// <param name="itemGrpImgCode">品目グループ画像コード</param>
        /// <remarks>
        /// <br>Note       : 画像番号コンボに値を設定する</br>
        /// <br>Programmer : 三戸 伸悟</br>
        /// <br>Date       : 2013/05/30</br>
        /// </remarks>
        public void ImageComboSet(short itemGrpImgCode)
        {
            try
            {
                this.tComboEditor_ImageIDX.Value = itemGrpImgCode;
            }
            catch
            {
                this.tComboEditor_ImageIDX.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// 画像番号コンボの値取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画像番号コンボに値を設定する</br>
        /// <br>Programmer : 三戸 伸悟</br>
        /// <br>Date       : 2013/05/30</br>
        /// </remarks>
        public short GetItemGrpImgCode()
        {
            if (this.tComboEditor_ImageIDX.Value == null) return 0;
            return short.Parse(this.tComboEditor_ImageIDX.Value.ToString());
        }
        // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion
      
        #region イベント

        #region ガイドボタンクリックイベント

        /// <summary>
        /// ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : ボタンがクリックされた際のイベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGrid ug = (UltraGrid)sender;
            UltraGridRow activeRow = ug.ActiveRow;

            //BLコードガイド
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            //BLコードガイド起動
            int status = _bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return;
            }
            else
            {
                activeRow.Cells[BLGOODSCODE_TITLE].Value = bLGoodsCdUMnt.BLGoodsCode;
                activeRow.Cells[BLGOODSNAME_TITLE].Value = bLGoodsCdUMnt.BLGoodsHalfName;
                activeRow.Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                activeRow.Cells[BLSELECT_TITLE].Activation = Activation.AllowEdit;
            }
            ug.PerformAction(UltraGridAction.ExitEditMode);
            ug.PerformAction(UltraGridAction.CommitRow);
        }

        #endregion

        /// <summary>
        /// グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアップデート後のイベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
            UltraGridCell cell = e.Cell;
            int rowIndex = e.Cell.Row.Index;
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            if (cell.Column.Key == BLGOODSCODE_TITLE)
            {
                int blCode = 0;
                if (cell.Value != null && cell.Value != DBNull.Value)
                {
                    blCode = (int)cell.Value; ;
                }
                if (blCode != 0)
                {
                    //BLコードガイド起動
                    if (_beforeBLGoodsCode != blCode)
                    {
                        if (this._bLGoodsCdUMntTb != null && this._bLGoodsCdUMntTb.ContainsKey(blCode))
                        {
                            ultraGrid.Rows[rowIndex].Cells[BLGOODSNAME_TITLE].Value = (string)this._bLGoodsCdUMntTb[blCode];
                            this._beforeBLGoodsCode = blCode;
                            ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value = 1;
                            bool blChecked = false;
                            if (this._blCheckedInfoTb != null && _blCheckedInfoTb.ContainsKey(blCode))
                            {
                                blChecked = (bool)_blCheckedInfoTb[blCode];
                            }
                            ultraGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Value = blChecked;
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
                            // BLコードを元に戻す
                           cell.Value = this._beforeBLGoodsCode;
                           
                        }
                    }
                }
                else
                {
                    ultraGrid.Rows[rowIndex].Cells[BLGOODSNAME_TITLE].Value = string.Empty;
                    ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value = DBNull.Value;
                    ultraGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Value = false;
                    this._beforeBLGoodsCode = 0;
                }
            }
            //-----DEL by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 ----->>>>>
            ////選択項目
            //else if (cell.Column.Key == BLSELECT_TITLE)
            //{
            //    //Blコード
            //    int blCode = 0;
            //    bool blChecked = (bool)cell.Value;
            //    if (ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value != DBNull.Value && ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value != null)
            //    {
            //        blCode = (int)ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value;
            //    }
            //    if (this._blCheckedInfoTb != null && _blCheckedInfoTb.ContainsKey(blCode))
            //    {
            //        _blCheckedInfoTb.Remove(blCode);
            //        _blCheckedInfoTb.Add(blCode, blChecked);
            //        //同じBLコードの選択更新
            //        for (int gridNo = 0; gridNo < this.TablePanel_Grids.Controls.Count; gridNo++)
            //        {
            //            UltraGrid ultraGridEach = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
            //            if (ultraGridEach == null || ultraGridEach.Rows.Count == 0)
            //            {
            //                continue;
            //            }
            //            int gridCount = ultraGridEach.Rows.Count;
            //            for (int i = 0; i < gridCount; i++)
            //            {
            //                UltraGridRow dataRow = ultraGridEach.Rows[i];
            //                int blGroupCode = 0;
            //                if (dataRow.Cells[BLGOODSCODE_TITLE].Value != DBNull.Value && dataRow.Cells[BLGOODSCODE_TITLE].Value != null)
            //                {
            //                    blGroupCode = (int)dataRow.Cells[BLGOODSCODE_TITLE].Value;
            //                    if (blGroupCode != blCode)
            //                    {
            //                        continue;
            //                    }
            //                }
            //                if (this._blCheckedInfoTb != null && _blCheckedInfoTb.ContainsKey(blGroupCode))
            //                {
            //                    bool checkValue = (bool)dataRow.Cells[BLSELECT_TITLE].Value;
            //                    bool checkValueSave = !(bool)_blCheckedInfoTb[blGroupCode];
            //                    if (!checkValue.Equals((bool)_blCheckedInfoTb[blGroupCode]))
            //                    {
            //                        dataRow.Cells[BLSELECT_TITLE].Value = _blCheckedInfoTb[blGroupCode];
            //                    }
            //                }
            //            }
            //        }

            //    }
            //    else
            //    {
            //        if (this._blCheckedInfoTb == null)
            //        {
            //            _blCheckedInfoTb = new Hashtable();
            //        }
            //        _blCheckedInfoTb.Add(blCode, blChecked);
            //    }
            //}
            //-----DEL by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 -----<<<<<
        }

        //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 ----->>>>>
        /// <summary>
        /// グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアップデート後のイベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid1_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
            UltraGridCell cell = e.Cell;
            int rowIndex = e.Cell.Row.Index;
            //選択項目
            if (cell.Column.Key == BLSELECT_TITLE)
            {
              
                //Blコード
                int blCode = 0;
                ultraGrid.UpdateData();
                bool blChecked = (bool)cell.Value;
                if (ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value != DBNull.Value && ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value != null)
                {
                    blCode = (int)ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value;
                }
                if (this._blCheckedInfoTb == null)
                {
                    _blCheckedInfoTb = new Hashtable();
                }
                if(!_blCheckedInfoTb.ContainsKey(blCode))
                {
                    _blCheckedInfoTb.Add(blCode, blChecked);
                }
                else
                {
                    _blCheckedInfoTb.Remove(blCode);
                    _blCheckedInfoTb.Add(blCode, blChecked);
                }
                    //同じBLコードの選択更新
                for (int gridNo = 0; gridNo < this.TablePanel_Grids.Controls.Count; gridNo++)
                {
                    UltraGrid ultraGridEach = this.TablePanel_Grids.Controls[gridNo] as UltraGrid;
                    if (ultraGridEach == null || ultraGridEach.Rows.Count == 0)
                    {
                        continue;
                    }
                    int gridCount = ultraGridEach.Rows.Count;
                    for (int i = 0; i < gridCount; i++)
                    {
                        UltraGridRow dataRow = ultraGridEach.Rows[i];
                        int blGroupCode = 0;
                        if (dataRow.Cells[BLGOODSCODE_TITLE].Value != DBNull.Value && dataRow.Cells[BLGOODSCODE_TITLE].Value != null)
                        {
                            blGroupCode = (int)dataRow.Cells[BLGOODSCODE_TITLE].Value;
                            if (blGroupCode != blCode)
                            {
                                continue;
                            }
                        }
                        if (this._blCheckedInfoTb != null && _blCheckedInfoTb.ContainsKey(blGroupCode))
                        {
                            bool checkValue = (bool)dataRow.Cells[BLSELECT_TITLE].Value;
                            bool checkValueSave = !(bool)_blCheckedInfoTb[blGroupCode];
                            if (!checkValue.Equals((bool)_blCheckedInfoTb[blGroupCode]))
                            {
                                dataRow.Cells[BLSELECT_TITLE].Value = _blCheckedInfoTb[blGroupCode];
                            }
                        }
                    }
                }
            }
        }
        //-----ADD by huanghx for #25387 BLパーツオーダー品目設定のチェックボックス制御 on 20110921 -----<<<<<
        
        /// <summary>
        ///  グリッドセルアップデート前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       :  グリッドセルアップデート前イベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;
            //BLコード
            if (cell.Column.Key == BLGOODSCODE_TITLE)
            {
                this._beforeBLGoodsCode = (e.Cell.Value is DBNull) ? 0 : Convert.ToInt32(e.Cell.Value);
            }
        }

        #region GridのMouseUp イベント

        /// <summary>
        ///  GridのMouseUp イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       :  GridのMouseUp イベントイベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_MouseUp(object sender, MouseEventArgs e)
        {
            UltraGrid ug = (UltraGrid)sender;
            if (ug != null && e.Button == MouseButtons.Right)
            {
                Infragistics.Win.UIElement aUIElement = ug.DisplayLayout.UIElement.ElementFromPoint(
                                 new Point(e.X, e.Y));

                if (aUIElement == null) return;

                // 当前行
                UltraGridRow aRow = (UltraGridRow)aUIElement.GetContext(typeof(UltraGridRow));
                // 当前cell
                UltraGridCell aCell = (UltraGridCell)aUIElement.GetContext(typeof(UltraGridCell));

                if (aCell != null && aCell.Column.Index > 2 && ug.ActiveCell != null)
                {
                    // 選択された行をクリアする
                    if (ug.Selected != null && ug.Selected.Rows != null && ug.Selected.Rows.Count > 0)
                    {
                        ug.Selected.Rows.Clear();
                    }
                    // 当前Cellを選択する
                    aCell.Activated = true;
                    aCell.Selected = true;
                }
                else
                {
                    if (aCell != null && ug.ActiveCell != null
                        && ((ug.ActiveCell.Column.Index > 2 && aCell.Column.Index <= 2)
                            || (ug.ActiveCell.Column.Index <= 2 && aCell.Column.Index > 2)))
                    {
                        return;
                    }
                    
                    if (aRow != null)
                    {
                        // 当前行は選択された行かどうかフラッグ
                        bool inSel = false;
                        if (ug.Selected != null && ug.Selected.Rows != null && ug.Selected.Rows.Count > 0)
                        {
                            foreach (UltraGridRow row in ug.Selected.Rows)
                            {
                                if (row.Index == aRow.Index)
                                {
                                    inSel = true;
                                }
                            }
                        }

                        // 当前行は選択された行ではない
                        if (!inSel)
                        {
                            // 選択された行をクリアする
                            if (ug.Selected != null && ug.Selected.Rows != null && ug.Selected.Rows.Count > 0)
                            {
                                ug.Selected.Rows.Clear();
                            }

                            // 当前行を選択する
                            aRow.Activated = true;
                            aRow.Selected = true;
                        }
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// グリッドアクション処理後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドアクション処理後時に発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                    // アクティブなセルがあるか？または編集可能セルか？
                    UltraGridCell ugCell = ultraGrid.ActiveCell;
                    if ((ugCell != null) &&
                        (ugCell.Column.CellActivation == Activation.AllowEdit) &&
                        (ugCell.Activation == Activation.AllowEdit))
                    {
                        // アクティブセルのスタイルを取得
                        switch (ultraGrid.ActiveCell.StyleResolved)
                        {
                            // エディット系スタイル
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                                {
                                    // 編集モードにある？
                                    if (ultraGrid.PerformAction(UltraGridAction.EnterEditMode))
                                    {
                                        if ((ultraGrid.ActiveCell.Value is System.DBNull) ||
                                            (ultraGrid.ActiveCell.Value == DBNull.Value))
                                        {
                                        }
                                        else
                                        {
                                            if (ultraGrid.ActiveCell.IsInEditMode)
                                            {
                                                // 全選択
                                                ultraGrid.ActiveCell.SelectAll();
                                            }
                                        }
                                    }
                                    break;
                                }
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Button:
                                {
                                    break;
                                }
                            default:
                                {
                                    // エディット系以外のスタイルであれば、編集状態にする。
                                    ultraGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        #region KeyUpイベント
        /// <summary>
        /// KeyUpイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : キーを話した際のイベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            // Spaceキー押下
            if (e.KeyCode == Keys.Space)
            {
                UltraGrid ultraGrid = (UltraGrid)sender;
                if (ultraGrid == null)
                {
                    return;
                }
                // 料金グループ一覧グリッド
                else
                {
                    if (ultraGrid.ActiveCell == null)
                    {
                        return;
                    }

                    CellEventArgs cellE = null;
                    // 押下場所がガイドボタンだった場合はガイド起動
                    if ((ultraGrid != null) && (ultraGrid.ActiveCell.Column.ToString().Trim() == BLGUID_TITLE.Trim()))
                    {
                        // カラーガイドコールイベント
                        PccItemSt_UltraGrid_ClickCellButton(sender, cellE);
                    }
                }
            }
        }
        #endregion

        #region ツールバー内アイテム選択イベント
        /// <summary>
        /// ツールバー内アイテム選択イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : ツールバー内のアイテムを選択(クリック)した際に発生するイベントです。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void Grid_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // 論理削除データの場合
           
            if (this._startMode == (int)PMPCC09040UA.StartMode.MODE_EDITLOGICDELETE)
            {
                return;
            }
            if (this._seletedUtraGrid == null)
            {
                return;
            }

            // カーソル変更
            this.Cursor = Cursors.WaitCursor;
            
            try
            {
                //画面8つ度グリッドの値を取得
                int gridEachNo = 0;
                int gridAllRowIndex = 0;
                foreach (Control ctr in TablePanel_Grids.Controls)
                {
                    UltraGrid uGrid = ctr as UltraGrid;
                    if (uGrid != null)
                    {
                        for (int i = 0; i < uGrid.Rows.Count; i++)
                        {
                            UltraGridRow dataRow = uGrid.Rows[i];
                            gridAllRowIndex = i + gridEachNo * MAXROW;
                            DataRow drAll = this._dsAll.Tables[PCCITEMST_TABLE].Rows[gridAllRowIndex];
                            //品目選択区分
                            drAll[BLSELECT_TITLE] = (bool)dataRow.Cells[BLSELECT_TITLE].Value;
                            //BL商品コード
                            if (dataRow.Cells[BLGOODSCODE_TITLE].Value != DBNull.Value)
                            {
                                drAll[BLGOODSCODE_TITLE] = (int)dataRow.Cells[BLGOODSCODE_TITLE].Value;
                            }
                            //BL商品名
                            drAll[BLGOODSNAME_TITLE] = (string)dataRow.Cells[BLGOODSNAME_TITLE].Value;
                            //品目QTY
                            if (dataRow.Cells[BLGOODSQTY_TITLE].Value != DBNull.Value)
                            {
                                drAll[BLGOODSQTY_TITLE] = (int)dataRow.Cells[BLGOODSQTY_TITLE].Value;
                            }

                        }
                        gridEachNo++;
                    }
                }
                //選択したグリッド
                UltraGrid uGridSelected = this._seletedUtraGrid;
                //画面8つ度グリッドの値を取得
                int gridNo = _gridNo;
                if (uGridSelected.ActiveCell != null)
                {
                    int rowIndex = uGridSelected.ActiveCell.Row.Index;
                    uGridSelected.Rows[rowIndex].Selected = true;
                }
                // 行追加
                if (e.Tool.Key == "Add_BtnTool")
                {
                    
                    // 行追加イベント
                    if (uGridSelected.Selected != null
                        && uGridSelected.Selected.Rows.Count > 0)
                    {
                        int insertIndex = StartInsertIndex(uGridSelected);
                        int insertIndexOld = insertIndex;
                        for (int i = 0; i < uGridSelected.Selected.Rows.Count; i++)
                        {
                            UltraGridRow row = uGridSelected.Rows.TemplateAddRow;
                            insertIndex = insertIndex  + gridNo * MAXROW;
                        }
                        DataRow dr = this._dsAll.Tables[PCCITEMST_TABLE].NewRow();
                        dr[BLSELECT_TITLE] = false;
                        dr[BLGOODSCODE_TITLE] = DBNull.Value;
                        dr[BLGOODSNAME_TITLE] = string.Empty;
                        dr[BLGOODSQTY_TITLE] = DBNull.Value;
                        dr[BLGRIDNO_TITLE] = DBNull.Value;
                        this._dsAll.Tables[PCCITEMST_TABLE].Rows.InsertAt(dr, insertIndex);


                        for (int i = 0; i < this._dsAll.Tables[PCCITEMST_TABLE].Rows.Count; i++)
                        {
                            DataRow dRow = this._dsAll.Tables[PCCITEMST_TABLE].Rows[i];
                            if (i >= MAXALLROW)
                            {
                                this._dsAll.Tables[PCCITEMST_TABLE].Rows.Remove(dRow);
                            }
                            dRow[BLGRIDNO_TITLE] = i / GRIDCOUNT;

                        }
                        //PCC品目の８つグリッド展開処理
                        this.GridGroupBy();
                        uGridSelected.Rows[insertIndexOld].Cells[BLGOODSCODE_TITLE].Activate();
                        uGridSelected.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode); 
                    }
                }
                // 行削除
                else if (e.Tool.Key == "Del_BtnTool")
                {

                    if (uGridSelected.Selected != null
                        && uGridSelected.Selected.Rows.Count > 0)
                    {
                        int minIndex = uGridSelected.Selected.Rows[0].Index;

                        UltraGridRow[] rows = new UltraGridRow[uGridSelected.Selected.Rows.Count];
                        for (int i = 0; i < uGridSelected.Selected.Rows.Count; i++)
                        {
                            rows[i] = uGridSelected.Selected.Rows[i];

                            if (minIndex > rows[i].Index)
                            {
                                minIndex = rows[i].Index;
                            }
                        }

                        bool delRet = true;
                        foreach (UltraGridRow row in rows)
                        {
                            // 行削除
                            DataRow delDr = null;
                            int deleteIndex = row.Index + gridNo * MAXROW;
                            delDr = this._dsAll.Tables[PCCITEMST_TABLE].Rows[deleteIndex];
                           
                            if (delDr != null)
                            {
                                this._dsAll.Tables[PCCITEMST_TABLE].Rows.Remove(delDr);
                            }
                        }


                        for (int insertIndex = this._dsAll.Tables[PCCITEMST_TABLE].Rows.Count; insertIndex < MAXALLROW; insertIndex++)
                        {
                            DataRow dr = this._dsAll.Tables[PCCITEMST_TABLE].NewRow();
                            dr[BLSELECT_TITLE] = false;
                            dr[BLGOODSCODE_TITLE] = DBNull.Value;
                            dr[BLGOODSNAME_TITLE] = string.Empty;
                            dr[BLGOODSQTY_TITLE] = DBNull.Value;
                            dr[BLGRIDNO_TITLE] = DBNull.Value;
                            this._dsAll.Tables[PCCITEMST_TABLE].Rows.InsertAt(dr, insertIndex);


                        }
                        for (int i = 0; i < this._dsAll.Tables[PCCITEMST_TABLE].Rows.Count; i++)
                        {
                            DataRow dRow = this._dsAll.Tables[PCCITEMST_TABLE].Rows[i];

                            dRow[BLGRIDNO_TITLE] = i / GRIDCOUNT;

                        }
                        //PCC品目の８つグリッド展開処理
                        this.GridGroupBy();

                        if (delRet)
                        {
                            if (uGridSelected.Rows.Count > 0)
                            {
                                if (minIndex > 0)
                                {
                                    uGridSelected.Rows[minIndex - 1].Cells[BLGOODSCODE_TITLE].Activate();
                                    uGridSelected.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    uGridSelected.Rows[minIndex].Cells[BLGOODSCODE_TITLE].Activate();
                                    uGridSelected.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                    }
                    return;
                }
            }
            finally
            {
                // カーソル変更
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region 最小行目の取得処理

        /// <summary>
        /// 最小行目の取得処理
        /// </summary>
        /// <returns>最小行目</returns>
        /// <remarks>
        /// <br>Note	   : 選択された行の最小行目を取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private int StartInsertIndex(UltraGrid uGrid)
        {
            int insertIndex = 0;

            if (uGrid.Selected != null
              && uGrid.Selected.Rows.Count > 0)
            {
                insertIndex = uGrid.Selected.Rows[0].Index;
                foreach (UltraGridRow row in uGrid.Selected.Rows)
                {
                    if (row.Index < insertIndex) insertIndex = row.Index;
                }
            }

            return insertIndex;
        }

        #endregion

        /// <summary>
        /// KeyPress イベント(grdPaymentKind)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : グリッド上でKeyが押されたときに発生します。 </br>
        /// <br>Programmer  : 黄海霞</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;
            int columnIndex = uGrid.ActiveCell.Column.Index;
            if (!uGrid.ActiveCell.IsInEditMode)
            {
                return;
            }
            bool digitFiag = true;
            switch (columnIndex)
            {
                case 1:
                case 4:
                    {
                        int length = 0;
                        if (columnIndex == 1)
                        {
                            length = 5;
                        }
                        else
                        {
                            length = 3;
                        }
                        // Backspaceのチェック
                        if ((byte)e.KeyChar == (byte)'\b' || e.KeyChar == (char)3 || e.KeyChar == (char)22) //ADD ③CTRL+「C」、CTRL+「V」でコピーや貼り付けが出来ないについて #18182
                        {
                            return;
                        }

                        // 数値以外は、ＮＧ
                        string regex = "^[0-9]*$";
                        Regex objRegex = new Regex(regex);
                        // 対象セルのテキスト取得
                        string targetText = uGrid.ActiveCell.Text;

                        digitFiag = objRegex.IsMatch(targetText);
                        if (!digitFiag)
                        {
                            e.Handled = true;
                            return;
                        }
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);

                        // セルのテキストが選択されている場合
                        if (uGrid.ActiveCell.SelText == targetText)
                        {
                            // 数値のみ入力可
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                e.KeyChar = '\0';
                            } 
                        }
                        else
                        {

                            if (targetText.Length == length)
                            {
                                e.KeyChar = '\0';
                            }
                            else
                            {

                                if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                                {
                                    e.KeyChar = '\0';
                                }
                                
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント(PccItemSt_UltraGrid_InitializeRow)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : セルの編集モードが終了したときに発生します。 </br>
        /// <br>Programmer  : 黄海霞</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;
            string  columnKey = uGrid.ActiveCell.Column.Key;
            switch (columnKey)
            {
                case BLGOODSCODE_TITLE:
                    {
                        if (uGrid.ActiveCell.Value == DBNull.Value || uGrid.ActiveCell.Value == null)
                        {
                            uGrid.ActiveCell.Value = DBNull.Value;
                            uGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activation = Activation.NoEdit;
                            uGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                            return;
                        }
                        if ((int)uGrid.ActiveCell.Value == 0)
                        {
                            uGrid.ActiveCell.Value = DBNull.Value;
                            uGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activation = Activation.NoEdit;
                            uGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                        }
                        else
                        {
                            uGrid.Rows[rowIndex].Cells[BLSELECT_TITLE].Activation = Activation.AllowEdit;
                           
                            uGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                        }
                        break;
                    }
                case BLGOODSQTY_TITLE:
                    {
                        if (uGrid.ActiveCell.Value == DBNull.Value || uGrid.ActiveCell.Value == null)
                        {
                            uGrid.ActiveCell.Value = DBNull.Value;
                            return;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        ///  セルのデータチェック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : データチェックを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void UGrid_CellDataError(object sender, CellDataErrorEventArgs e)
        {

            UltraGrid ultraGrid = (UltraGrid)sender;

            if (ultraGrid.ActiveCell == null)
            {
                return;
            }
            string columnKey = ultraGrid.ActiveCell.Column.Key;
            int numLen = 0;
            //
            if (BLGOODSCODE_TITLE.Equals(columnKey))
            {
                //BLコード
                numLen = 8;
            }
            else if (BLGOODSQTY_TITLE.Equals(columnKey))
            {
                //BL数量
                numLen = 3;
            }
           
            if (ultraGrid.ActiveCell.Column.DataType == typeof(Int32))
            {
                Infragistics.Win.EmbeddableEditorBase editorBase = ultraGrid.ActiveCell.EditorResolved;
                string currentEditText = editorBase.CurrentEditText;
                bool checkNumber = IsDigitAdd(currentEditText, numLen);
                if (!checkNumber)
                {
                    ultraGrid.ActiveCell.Value = DBNull.Value;
                }

            }
            e.RaiseErrorEvent = false;   // エラーイベントは発生させない
            e.RestoreOriginalValue = false;  // セルの値を元に戻さない 
            e.StayInEditMode = false;   // 編集モードは抜ける
        }

        /// <summary>
        /// フォーカス変換処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォーカス変換処理します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            UltraGrid ultraGrid = null;

           

            // 名前により分岐
            switch (e.NextCtrl.Name)
            {
                // PCC品目設定グリッド1
                case "PccItemSt_UltraGrid1":
                    {
                        _gridNo = 0;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                       break;
                    }
                // PCC品目設定グリッド2
                case "PccItemSt_UltraGrid2":
                    {
                        _gridNo = 1;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                         break;
                    }
                // PCC品目設定グリッド3
                case "PccItemSt_UltraGrid3":
                    {
                        _gridNo = 2;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                          break;
                    }
                // PCC品目設定グリッド4
                case "PccItemSt_UltraGrid4":
                    {
                        _gridNo = 3;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                         break;
                    }
                // PCC品目設定グリッド5
                case "PccItemSt_UltraGrid5":
                    {
                        _gridNo = 4;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                        break;
                    }
                // PCC品目設定グリッド6
                case "PccItemSt_UltraGrid6":
                    {
                        _gridNo =5;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                        break;
                    }
                // PCC品目設定グリッド7
                case "PccItemSt_UltraGrid7":
                    {
                        _gridNo = 6;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                        break;
                    }
                // PCC品目設定グリッド8
                case "PccItemSt_UltraGrid8":
                    {
                        _gridNo = 7;
                        ultraGrid = (UltraGrid)e.NextCtrl;
                        break;
                    }
            }
            _seletedUtraGrid = ultraGrid;

        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドキーダウン時に発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemSt_UltraGrid_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if(ultraGrid == null)
            {
                return;
            }
            
            
            //アクティブセルが存在するとき
            if (ultraGrid.ActiveCell != null)
            {
                //対象のセルを取得
                UltraGridCell cell = ultraGrid.ActiveCell;
                int columnIndex = ultraGrid.ActiveCell.Column.Index;
                int rowIndex = ultraGrid.ActiveCell.Row.Index;
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            MoveDownAllowEditCell(false, ref ultraGrid, ref this._gridNo, e);
                            
                            break;
                        }
                    case Keys.Down:
                        {
                           MoveDownAllowEditCell(false, ref ultraGrid, ref this._gridNo, e);
                          
                            break;
                        }
                    case Keys.Left:
                        {
                            MoveDownAllowEditCell(false, ref ultraGrid, ref this._gridNo, e);
                            break;
                        }
                    case Keys.Right:
                        {
                            MoveDownAllowEditCell(false, ref ultraGrid, ref this._gridNo, e);
                            break;
                        }
                    case Keys.Space:
                        {
                            if (ultraGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                UltraGridCell ultraGridCell = ultraGrid.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                                this.PccItemSt_UltraGrid_ClickCellButton(sender, cellEventArgs);
                            }
                            break;
                        }
                }
               
            }
            else if (ultraGrid.ActiveRow != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            ultraGrid.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                            ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            break;
                        }
                    case Keys.Down:
                        {
                            ultraGrid.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                            ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            break;
                        }
                    case Keys.Left:
                        {
                            ultraGrid.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                            ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            break;
                        }
                    case Keys.Right:
                        {
                            ultraGrid.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                            ultraGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            break;
                        }
                }
            }
        }

        // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 画像番号コンボチェンジ
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : コンボの画像に対応する画像を表示する</br>
        /// <br>Programmer : 三戸 伸悟</br>
        /// <br>Date       : 2013/05/30</br>
        /// </remarks>
        private void tComboEditor_ImageIDX_ValueChanged(object sender, EventArgs e)
        {
            short cmbImageNo = short.Parse(this.tComboEditor_ImageIDX.Value.ToString());
            switch (cmbImageNo)
            {
                case 1:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg01;
                        break;
                    }
                case 2:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg02;
                        break;
                    }
                case 3:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg03;
                        break;
                    }
                case 4:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg04;
                        break;
                    }
                //case 5:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg05;
                //        break;
                //    }
                //case 6:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg06;
                //        break;
                //    }
                //case 7:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg07;
                //        break;
                //    }
                //case 8:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg08;
                //        break;
                //    }
                //case 9:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg09;
                //        break;
                //    }
                //case 10:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg10;
                //        break;
                //    }
                case 11:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg11;
                        break;
                    }
                case 12:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg12;
                        break;
                    }
                case 13:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg13;
                        break;
                    }
                case 14:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg14;
                        break;
                    }
                case 15:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg15;
                        break;
                    }
                //case 16:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg16;
                //        break;
                //    }
                //case 17:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg17;
                //        break;
                //    }
                //case 18:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg18;
                //        break;
                //    }
                //case 19:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg19;
                //        break;
                //    }
                //case 20:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg20;
                //        break;
                //    }
                case 21:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg21;
                        break;
                    }
                case 22:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg22;
                        break;
                    }
                case 23:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg23;
                        break;
                    }
                case 24:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg24;
                        break;
                    }
                case 25:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg25;
                        break;
                    }
                //case 26:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg26;
                //        break;
                //    }
                //case 27:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg27;
                //        break;
                //    }
                //case 28:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg28;
                //        break;
                //    }
                //case 29:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg29;
                //        break;
                //    }
                //case 30:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg30;
                //        break;
                //    }
                case 31:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg31;
                        break;
                    }
                case 32:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg32;
                        break;
                    }
                case 33:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg33;
                        break;
                    }
                case 34:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg34;
                        break;
                    }
                case 35:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg35;
                        break;
                    }
                //case 36:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg36;
                //        break;
                //    }
                //case 37:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg37;
                //        break;
                //    }
                //case 38:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg38;
                //        break;
                //    }
                //case 39:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg39;
                //        break;
                //    }
                //case 40:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg40;
                //        break;
                //    }
                case 41:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg41;
                        break;
                    }
                case 42:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg42;
                        break;
                    }
                case 43:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg43;
                        break;
                    }
                case 44:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg44;
                        break;
                    }
                case 45:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg45;
                        break;
                    }
                //case 46:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg46;
                //        break;
                //    }
                //case 47:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg47;
                //        break;
                //    }
                //case 48:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg48;
                //        break;
                //    }
                //case 49:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg49;
                //        break;
                //    }
                //case 50:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg50;
                //        break;
                //    }
                case 51:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg51;
                        break;
                    }
                case 52:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg52;
                        break;
                    }
                case 53:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg53;
                        break;
                    }
                case 54:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg54;
                        break;
                    }
                case 55:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg55;
                        break;
                    }
                //case 56:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg56;
                //        break;
                //    }
                //case 57:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg57;
                //        break;
                //    }
                //case 58:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg58;
                //        break;
                //    }
                //case 59:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg59;
                //        break;
                //    }
                //case 60:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg60;
                //        break;
                //    }
                //case 61:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg61;
                //        break;
                //    }
                //case 62:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg62;
                //        break;
                //    }
                //case 63:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg63;
                //        break;
                //    }
                //case 64:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg64;
                //        break;
                //    }
                //case 65:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg65;
                //        break;
                //    }
                //case 66:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg66;
                //        break;
                //    }
                //case 67:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg67;
                //        break;
                //    }
                //case 68:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg68;
                //        break;
                //    }
                //case 69:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg69;
                //        break;
                //    }
                //case 70:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg70;
                //        break;
                //    }
                //case 71:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg71;
                //        break;
                //    }
                //case 72:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg72;
                //        break;
                //    }
                //case 73:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg73;
                //        break;
                //    }
                //case 74:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg74;
                //        break;
                //    }
                //case 75:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg75;
                //        break;
                //    }
                //case 76:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg76;
                //        break;
                //    }
                //case 77:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg77;
                //        break;
                //    }
                //case 78:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg78;
                //        break;
                //    }
                //case 79:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg79;
                //        break;
                //    }
                //case 80:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg80;
                //        break;
                //    }
                case 81:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg81;
                        break;
                    }
                case 82:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg82;
                        break;
                    }
                case 83:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg83;
                        break;
                    }
                case 84:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg84;
                        break;
                    }
                case 85:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg85;
                        break;
                    }
                case 86:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg86;
                        break;
                    }
                case 87:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg87;
                        break;
                    }
                case 88:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg88;
                        break;
                    }
                case 89:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg89;
                        break;
                    }
                //case 90:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg90;
                //        break;
                //    }
                //case 91:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg91;
                //        break;
                //    }
                //case 92:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg92;
                //        break;
                //    }
                //case 93:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg93;
                //        break;
                //    }
                //case 94:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg94;
                //        break;
                //    }
                //case 95:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg95;
                //        break;
                //    }
                //case 96:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg96;
                //        break;
                //    }
                //case 97:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg97;
                //        break;
                //    }
                //case 98:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg98;
                //        break;
                //    }
                //case 99:
                //    {
                //        this.ImageInfoData_UltraPictureBox.Image = Properties.Resources.ItemGrpImg99;
                //        break;
                //    }
                default:
                    {
                        this.ImageInfoData_UltraPictureBox.Image = null;
                        break;
                    }
            }
        }
        // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion
    }
}
