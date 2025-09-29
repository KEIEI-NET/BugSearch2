using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 検索見積 結合登録フォームクラス
    /// </summary>
	public partial class PMMIT01010UJ : Form
	{
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMMIT01010UJ(EstimateInputAcs estimateInputAcs)
        {
            InitializeComponent();

            this._estimateInputAcs = estimateInputAcs;

            this._backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_Back"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_Save"];
            this._allSelectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_AllSelect"];
            this._allCancelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_AllCancel"];

            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolbarsManager_Main.ImageListSmall = this._imageList16;
            this._backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._allSelectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLSELECT;
            this._allCancelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._joinPartsUAcs = new JoinPartsUAcs();

            this._controlScreenSkin = new ControlScreenSkin();
        }

        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■Private Members

        private EstimateInputAcs _estimateInputAcs;
        private DataTable _entryJoinPartsTable;
        private DataView _displayView;
        private DataView _editView;
        private DialogResult _result = DialogResult.Cancel;
        private JoinPartsUAcs _joinPartsUAcs;
        private ControlScreenSkin _controlScreenSkin;
            
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;


        private ImageList _imageList16 = null;									// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _backButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _allSelectButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _allCancelButton;

        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ■Public Methods

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="estimateDetailDataTable">見積明細テーブル</param>
        /// <returns>DialogResult</returns>
        public DialogResult ShowDialog(IWin32Window owner, EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable)
        {
            this._entryJoinPartsTable = this.CreateEntryJoinPartsTable(estimateDetailDataTable);
            this._editView = new DataView(this._entryJoinPartsTable);
            this._displayView = new DataView(this._entryJoinPartsTable);
            this._editView.Sort = string.Format("{0},{1},{2},{3}", EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH, EntryJoinPartsTable.ctColName_JoinSourceMakerCode, EntryJoinPartsTable.ctColName_JoinDestPartsNo, EntryJoinPartsTable.ctColName_JoinDestMakerCd);
            this._displayView.Sort = string.Format("{0},{1},{2},{3}", EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH, EntryJoinPartsTable.ctColName_JoinSourceMakerCode, EntryJoinPartsTable.ctColName_JoinDestPartsNo, EntryJoinPartsTable.ctColName_JoinDestMakerCd);

            if (this._entryJoinPartsTable.Rows.Count == 0)
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,
                   this.Name,
                   "結合登録の対象となるデータが存在しません。",
                   0,
                   MessageBoxButtons.OK);
                return DialogResult.None;
            }

            this.DeleteOverlapRows();

            return this.ShowDialog(owner);
        }

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods

        /// <summary>
        /// 結合登録テーブルを生成します。
        /// </summary>
        /// <param name="estimateDetailDataTable"></param>
        /// <returns></returns>
        private DataTable CreateEntryJoinPartsTable(EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable)
        {
            DataTable table = null;
            EntryJoinPartsTable.CreateTable(ref table);

            string select = string.Format("{0}<>'' AND {1}<>0 AND {0}<>'' AND {1}<>0", estimateDetailDataTable.GoodsNoColumn.ColumnName, 
                                                                                       estimateDetailDataTable.GoodsMakerCdColumn.ColumnName, 
                                                                                       estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, 
                                                                                       estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName);
            EstimateInputDataSet.EstimateDetailRow[] rows = this._estimateInputAcs.SelectEstimateDetailRows(select, estimateDetailDataTable);

            if (( rows == null ) && ( rows.Length == 0 )) return table;

            List<GoodsCndtn> goodsCndtnList;
            this._estimateInputAcs.GetGoodsCndtnList(this._estimateInputAcs.SalesSlip, rows, GoodsCndtn.JoinSearchDivType.Search, out goodsCndtnList);

            if (( goodsCndtnList == null ) || ( goodsCndtnList.Count == 0 )) return table;

            Dictionary<GoodsUnitData, PartsInfoDataSet> goodsDictionary;

            this._estimateInputAcs.JoinPartsSearch(goodsCndtnList, out goodsDictionary);

            if (( goodsDictionary == null ) || ( goodsDictionary.Count == 0 )) return table;

            foreach (EstimateInputDataSet.EstimateDetailRow row in rows)
            {
                if (( this._estimateInputAcs.GetGoodsUnitDataFromCache(row.GoodsNo, row.GoodsMakerCd) == null ) ||
                    ( this._estimateInputAcs.GetGoodsUnitDataFromCache(row.GoodsNo_Prime, row.GoodsMakerCd_Prime) == null ))
                {
                    continue;
                }
                bool isOfferData = false;

                foreach (GoodsUnitData goodsUnitData in goodsDictionary.Keys)
                {
                    if (( goodsUnitData.GoodsNo == row.GoodsNo ) && ( goodsUnitData.GoodsMakerCd == row.GoodsMakerCd ))
                    {
                        PartsInfoDataSet partsInfoDataSet = goodsDictionary[goodsUnitData];
                        if (partsInfoDataSet.UsrJoinParts.IsOfferData(row.GoodsMakerCd, row.GoodsNo, row.GoodsMakerCd_Prime, row.GoodsNo_Prime))
                        {
                            isOfferData = true;
                        }
                        break;
                    }
                }
                if (isOfferData) continue;

                DataRow newRow = table.NewRow();

                #region 行生成
                newRow[EntryJoinPartsTable.ctColName_Select] = false;
                newRow[EntryJoinPartsTable.ctColName_SalesRowNo] = row.SalesRowNo;
                newRow[EntryJoinPartsTable.ctColName_JoinSourceMakerCode] = row.GoodsMakerCd;
                // 結合元品番が取得できない場合は画面の純正品番を使用する
                newRow[EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH] = ( string.IsNullOrEmpty(row.JoinSourPartsNoWithH) ) ? row.GoodsNo : row.JoinSourPartsNoWithH;
                //newRow[EntryJoinPartsTable.ctColName_JoinSourPartsNoNoneH] = false;
                newRow[EntryJoinPartsTable.ctColName_JoinDestMakerCd] = row.GoodsMakerCd_Prime;
                newRow[EntryJoinPartsTable.ctColName_JoinDestPartsNo] = row.GoodsNo_Prime;
                newRow[EntryJoinPartsTable.ctColName_JoinQty] = row.ShipmentCnt_Prime;
                newRow[EntryJoinPartsTable.ctColName_EstimateDetailRow] = row;
                newRow[EntryJoinPartsTable.ctColName_DataGUID] = Guid.NewGuid();

                #endregion

                table.Rows.Add(newRow);
            }

            //foreach (EstimateInputDataSet.EstimateDetailRow row in estimateDetailDataTable)
            //{
            //    if (( this._estimateInputAcs.GetGoodsUnitDataFromCache(row.GoodsNo, row.GoodsMakerCd) == null ) ||
            //        ( this._estimateInputAcs.GetGoodsUnitDataFromCache(row.GoodsNo_Prime, row.GoodsMakerCd_Prime) == null ))
            //    {
            //        continue;
            //    }

            //    DataRow newRow = table.NewRow();

            //    #region 行生成
            //    newRow[EntryJoinPartsTable.ctColName_Select] = false;
            //    newRow[EntryJoinPartsTable.ctColName_SalesRowNo] = row.SalesRowNo;
            //    newRow[EntryJoinPartsTable.ctColName_JoinSourceMakerCode] = row.GoodsMakerCd;
            //    // 結合元品番が取得できない場合は画面の純正品番を使用する
            //    newRow[EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH] = ( string.IsNullOrEmpty(row.JoinSourPartsNoWithH) ) ? row.GoodsNo : row.JoinSourPartsNoWithH;
            //    //newRow[EntryJoinPartsTable.ctColName_JoinSourPartsNoNoneH] = false;
            //    newRow[EntryJoinPartsTable.ctColName_JoinDestMakerCd] = row.GoodsMakerCd_Prime;
            //    newRow[EntryJoinPartsTable.ctColName_JoinDestPartsNo] = row.GoodsNo_Prime;
            //    newRow[EntryJoinPartsTable.ctColName_JoinQty] = row.ShipmentCnt_Prime;
            //    newRow[EntryJoinPartsTable.ctColName_EstimateDetailRow] = row;
            //    newRow[EntryJoinPartsTable.ctColName_DataGUID] = Guid.NewGuid();

            //    #endregion

            //    table.Rows.Add(newRow);
            //}

            return table;
        }

        /// <summary>
        /// 登録条件（結合元品番、結合元メーカー、結合先品番、結合先メーカー、QTY）が重複している行を削除します。
        /// </summary>
        private void DeleteOverlapRows()
        {
            string rowFilter = this._editView.RowFilter;
            try
            {
                List<Guid> delRowList = new List<Guid>();

                foreach (DataRow dr in this._entryJoinPartsTable.Rows)
                {
                    if (!delRowList.Contains((Guid)dr[EntryJoinPartsTable.ctColName_DataGUID]))
                    {
                        string selectFilter = string.Format("{0}<>'{1}' AND {2}='{3}' AND {4}={5} AND {6}='{7}' AND {8}={9} AND {10}={11}",
                            EntryJoinPartsTable.ctColName_DataGUID, (Guid)dr[EntryJoinPartsTable.ctColName_DataGUID],
                            EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH, (string)dr[EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH],
                            EntryJoinPartsTable.ctColName_JoinSourceMakerCode, (int)dr[EntryJoinPartsTable.ctColName_JoinSourceMakerCode],
                            EntryJoinPartsTable.ctColName_JoinDestPartsNo, (string)dr[EntryJoinPartsTable.ctColName_JoinDestPartsNo],
                            EntryJoinPartsTable.ctColName_JoinDestMakerCd, (int)dr[EntryJoinPartsTable.ctColName_JoinDestMakerCd],
                            EntryJoinPartsTable.ctColName_JoinQty, (double)dr[EntryJoinPartsTable.ctColName_JoinQty]);

                        this._editView.RowFilter = selectFilter;

                        foreach (DataRowView drv in this._editView)
                        {
                            delRowList.Add((Guid)drv[EntryJoinPartsTable.ctColName_DataGUID]);
                        }
                    }
                }

                if (delRowList.Count == 0) return;

                foreach (Guid guid in delRowList)
                {
                    DataRow row = this._entryJoinPartsTable.Rows.Find(guid);
                    if (row != null)
                    {
                        this._entryJoinPartsTable.Rows.Remove(row);
                    }
                }
            }
            finally
            {
                this._editView.RowFilter = rowFilter;
            }
        }

        /// <summary>
        /// 全選択処理
        /// </summary>
        private void AllSelect()
        {
            this._entryJoinPartsTable.AcceptChanges();
            this.uGrid_EntryJoinParts.BeginUpdate();
            
            try
            {
                foreach (DataRowView drv in this._displayView)
                {
                    this.SelectRow((Guid)drv[EntryJoinPartsTable.ctColName_DataGUID], true);
                }
            }
            finally
            {
                this.uGrid_EntryJoinParts.EndUpdate();
            }
        }

        /// <summary>
        /// 全解除処理
        /// </summary>
        private void AllCancel()
        {
            this._entryJoinPartsTable.AcceptChanges();
            this.uGrid_EntryJoinParts.BeginUpdate();
            try
            {
                foreach (DataRowView drv in this._displayView)
                {
                    drv[EntryJoinPartsTable.ctColName_Select] = false;
                }
            }
            finally
            {
                this.uGrid_EntryJoinParts.EndUpdate();
            }
        }

        /// <summary>
        /// 行選択処理
        /// </summary>
        /// <param name="rowIndex">行Index</param>
        /// <param name="select">選択</param>
        private void SelectRow(Guid guid, bool select)
        {
            this._entryJoinPartsTable.AcceptChanges();
            this.uGrid_EntryJoinParts.BeginUpdate();
            string rowFilter = this._editView.RowFilter;
            try
            {
                DataRow row = this._entryJoinPartsTable.Rows.Find(guid);
                if ( row != null )
                {
                    row[EntryJoinPartsTable.ctColName_Select] = select;

                    // 選択する場合は、同一結合元の結合先違い、QTY違いのデータの選択を外す
                    if (select)
                    {
                        string selectFilter = string.Format("{0}<>'{1}' AND {2}='{3}' AND {4}={5}",
                            EntryJoinPartsTable.ctColName_DataGUID, guid,
                            EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH, (string)row[EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH],
                            EntryJoinPartsTable.ctColName_JoinSourceMakerCode, (int)row[EntryJoinPartsTable.ctColName_JoinSourceMakerCode]);

                        this._editView.RowFilter = selectFilter;

                        if (this._editView.Count > 0)
                        {
                            foreach (DataRowView rowView in this._editView)
                            {
                                rowView[EntryJoinPartsTable.ctColName_Select] = false;
                            }
                        }
                    }
                }
            }
            finally
            {
                this._editView.RowFilter = rowFilter;
                this.uGrid_EntryJoinParts.EndUpdate();
            }
        }

        /// <summary>
        /// 保存対象データが存在するかチェックします。
        /// </summary>
        private bool ExistSaveData()
        {
            string rowFiler = this._editView.RowFilter;
            bool ret = false;
            try
            {
                string selectFilter = string.Format("{0}='{1}'", EntryJoinPartsTable.ctColName_Select, true);
                this._editView.RowFilter = selectFilter;
                ret = ( this._editView.Count > 0 );
            }
            finally
            {
                this._editView.RowFilter = rowFiler;
            }

            return ret;
        }

        /// <summary>
        /// データ保存処理
        /// </summary>
        private bool Save()
        {
            bool ret = false;

            if (!this.ExistSaveData())
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "結合登録するデータを選択して下さい。",
                    0,
                    MessageBoxButtons.OK);
                return false;
            }

            DataRow[] rows = this._entryJoinPartsTable.Select(string.Format("{0}='{1}'", EntryJoinPartsTable.ctColName_Select, true));

            // 選択されたデータのユーザー結合データを取得する
            List<JoinPartsUAcs.F_DATA_JOINSOURCEKEY> joinSourceKeyList = new List<JoinPartsUAcs.F_DATA_JOINSOURCEKEY>();
            Dictionary<JoinPartsUAcs.F_DATA_JOINSOURCEKEY, List<JoinPartsU>> joinPartsDictionary;

            foreach (DataRow row in rows)
            {
                joinSourceKeyList.Add(new JoinPartsUAcs.F_DATA_JOINSOURCEKEY((string)row[EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH], (int)row[EntryJoinPartsTable.ctColName_JoinSourceMakerCode]));
            }

            this._joinPartsUAcs.Search(this._enterpriseCode, joinSourceKeyList, out joinPartsDictionary);

            List<JoinPartsU> saveJoinPartsUList = new List<JoinPartsU>();
            List<GoodsUnitData> saveGoodUnitDataList = new List<GoodsUnitData>();

            foreach (DataRow row in rows)
            {
                JoinPartsUAcs.F_DATA_JOINSOURCEKEY joinsourceKey = new JoinPartsUAcs.F_DATA_JOINSOURCEKEY((string)row[EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH], (int)row[EntryJoinPartsTable.ctColName_JoinSourceMakerCode]);
                bool exist = false;
                if (joinPartsDictionary.ContainsKey(joinsourceKey))
                {
                    List<JoinPartsU> joinPartsUList = joinPartsDictionary[joinsourceKey];
                    int index = 1;
                    foreach (JoinPartsU joinPartsU in joinPartsUList)
                    {
                        if (( joinPartsU.JoinDestPartsNo == (string)row[EntryJoinPartsTable.ctColName_JoinDestPartsNo] ) &&
                            ( joinPartsU.JoinDestMakerCd == (int)row[EntryJoinPartsTable.ctColName_JoinDestMakerCd] ))
                        {
                            joinPartsU.JoinDispOrder = 0;
                            joinPartsU.JoinQty = (double)row[EntryJoinPartsTable.ctColName_JoinQty];
                            exist = true;
                        }
                        else
                        {
                            joinPartsU.JoinDispOrder = index;
                            index++;
                        }
                    }
                    saveJoinPartsUList.AddRange(joinPartsUList);
                }

                // ユーザー結合マスタに新規登録
                if (!exist)
                {
                    JoinPartsU joinPartsU = new JoinPartsU();
                    joinPartsU.JoinSourPartsNoWithH = (string)row[EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH];
                    joinPartsU.JoinSourPartsNoNoneH = ( (string)row[EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH] ).Replace("-", "");
                    joinPartsU.JoinSourceMakerCode = (int)row[EntryJoinPartsTable.ctColName_JoinSourceMakerCode];
                    joinPartsU.JoinDestPartsNo = (string)row[EntryJoinPartsTable.ctColName_JoinDestPartsNo];
                    joinPartsU.JoinDestMakerCd = (int)row[EntryJoinPartsTable.ctColName_JoinDestMakerCd];
                    joinPartsU.JoinDispOrder = 0;
                    joinPartsU.JoinQty = (double)row[EntryJoinPartsTable.ctColName_JoinQty];

                    saveJoinPartsUList.Add(joinPartsU);

                    GoodsUnitData goodsUnitData = this._estimateInputAcs.GetGoodsUnitDataFromCache(joinPartsU.JoinDestPartsNo, joinPartsU.JoinDestMakerCd);

                    // 提供区分が3以上は提供データなので、商品ユーザーデータに登録
                    if (goodsUnitData.OfferKubun >= 3)
                    {
                        saveGoodUnitDataList.Add(goodsUnitData);
                    }
                }

                if (saveJoinPartsUList.Count > 0)
                {
                    string retMessage;
                    int status = this._joinPartsUAcs.Write(saveJoinPartsUList, ref saveGoodUnitDataList, out retMessage);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "結合マスタに登録しました。",
                            0,
                            MessageBoxButtons.OK);

                        this._estimateInputAcs.CacheGoodsUnitData(saveGoodUnitDataList);
                        ret = true;
                    }
                    else
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_STOPDISP,
                           this.Name,
                           "登録に失敗しました。" + "\r\n" + "\r\n" + retMessage,
                           status,
                           MessageBoxButtons.OK);
                    }
                }
            }

            return ret;
        }

        // ===================================================================================== //
        // コントロールのイベント
        // ===================================================================================== //
        #region Control Events
        /// <summary>
        /// 画面 Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMMIT01010UK_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.uGrid_EntryJoinParts.DataSource = this._displayView;

            this.uGrid_EntryJoinParts.Rows[0].Selected = true;
        }

        /// <summary>
        ///  フォームクローズ後発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMMIT01010UK_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = this._result;
        }
       
        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager_Main_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 戻る
                case "ButtonTool_Back":
                    {
                        this.Close();
                        break;
                    }
                // 保存
                case "ButtonTool_Save":
                    {
                        if (this.Save())
                        {
                            this._result = DialogResult.OK;
                            this.Close();
                        }
                        break;
                    }
                // 全選択
                case "ButtonTool_AllSelect":
                    {
                        this.AllSelect();
                        break;
                    }
                // 全解除
                case "ButtonTool_AllCancel":
                    {
                        this.AllCancel();
                        break;
                    }
            }
        }


        #region ■グリッド関連
        /// <summary>
        /// グリッド InitializeLayoutイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_EntryJoinParts_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            string decimalFormat = "#,##0.00;-#,##0.00;''";

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_EntryJoinParts.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                column.Header.Fixed = false;
                //入力許可設定
                //column.AutoEdit = false;
            }

            int visiblePosition = 1;
            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------
            #region カラム情報の設定

            // 選択フラグ
            Columns[EntryJoinPartsTable.ctColName_Select].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[EntryJoinPartsTable.ctColName_Select].AutoEdit = true;
            Columns[EntryJoinPartsTable.ctColName_Select].Hidden = false;
            Columns[EntryJoinPartsTable.ctColName_Select].Header.Caption = "選択";
            Columns[EntryJoinPartsTable.ctColName_Select].Header.Fixed = true;
            Columns[EntryJoinPartsTable.ctColName_Select].Header.VisiblePosition = visiblePosition++;
            Columns[EntryJoinPartsTable.ctColName_Select].Width = 20;

            // 結合元品番
            Columns[EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH].Hidden = false;
            Columns[EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH].Header.VisiblePosition = visiblePosition++;
            Columns[EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH].Header.Caption = "結合元品番";
            Columns[EntryJoinPartsTable.ctColName_JoinSourPartsNoWithH].Width = 140;

            // メーカーコード
            Columns[EntryJoinPartsTable.ctColName_JoinSourceMakerCode].Hidden = false;
            Columns[EntryJoinPartsTable.ctColName_JoinSourceMakerCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[EntryJoinPartsTable.ctColName_JoinSourceMakerCode].Header.VisiblePosition = visiblePosition++;
            Columns[EntryJoinPartsTable.ctColName_JoinSourceMakerCode].Header.Caption = "結合元ﾒｰｶｰ";
            Columns[EntryJoinPartsTable.ctColName_JoinSourceMakerCode].Width = 65;
            Columns[EntryJoinPartsTable.ctColName_JoinSourceMakerCode].Format = "0000";

            // 結合先品番
            Columns[EntryJoinPartsTable.ctColName_JoinDestPartsNo].Hidden = false;
            Columns[EntryJoinPartsTable.ctColName_JoinDestPartsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[EntryJoinPartsTable.ctColName_JoinDestPartsNo].Header.VisiblePosition = visiblePosition++;
            Columns[EntryJoinPartsTable.ctColName_JoinDestPartsNo].Header.Caption = "結合先品番";
            Columns[EntryJoinPartsTable.ctColName_JoinDestPartsNo].Width = 140;

            // 結合先メーカー
            Columns[EntryJoinPartsTable.ctColName_JoinDestMakerCd].Hidden = false;
            Columns[EntryJoinPartsTable.ctColName_JoinDestMakerCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[EntryJoinPartsTable.ctColName_JoinDestMakerCd].Header.VisiblePosition = visiblePosition++;
            Columns[EntryJoinPartsTable.ctColName_JoinDestMakerCd].Header.Caption = "結合先ﾒｰｶｰ";
            Columns[EntryJoinPartsTable.ctColName_JoinDestMakerCd].Format = "0000";
            Columns[EntryJoinPartsTable.ctColName_JoinDestMakerCd].Width = 65;

            // QTY
            Columns[EntryJoinPartsTable.ctColName_JoinQty].Hidden = false;
            Columns[EntryJoinPartsTable.ctColName_JoinQty].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[EntryJoinPartsTable.ctColName_JoinQty].Header.VisiblePosition = visiblePosition++;
            Columns[EntryJoinPartsTable.ctColName_JoinQty].Format = decimalFormat;
            Columns[EntryJoinPartsTable.ctColName_JoinQty].Header.Caption = "QTY";
            Columns[EntryJoinPartsTable.ctColName_JoinQty].Width = 80;

            #endregion

            // 固定列区切り線設定
            this.uGrid_EntryJoinParts.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_EntryJoinParts.DisplayLayout.Override.HeaderAppearance.BackColor2;

            this.uGrid_EntryJoinParts.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }

        /// <summary>
        /// グリッドクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_EntryJoinParts_MouseClick(object sender, MouseEventArgs e)
        {
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

            this.SelectRow((Guid)objRow.Cells[EntryJoinPartsTable.ctColName_DataGUID].Value, !(bool)objRow.Cells[EntryJoinPartsTable.ctColName_Select].Value);
        }

        /// <summary>
        /// グリッド　キーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_EntryJoinParts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (this.uGrid_EntryJoinParts.ActiveRow != null)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_EntryJoinParts.ActiveRow;
                    this.SelectRow((Guid)row.Cells[EntryJoinPartsTable.ctColName_DataGUID].Value, !(bool)row.Cells[EntryJoinPartsTable.ctColName_Select].Value);
                    e.Handled = true;
                }
            }
        }

 
        #endregion

        
        #endregion

        #endregion
    }

    #region 表示用のテーブルスキーマ定義クラス

    /// <summary>
    /// 結合登録用のテーブルスキーマ定義クラス
    /// </summary>
    internal class EntryJoinPartsTable
    {
        public EntryJoinPartsTable()
        {
        }

        public const string ctTableName = "EntryJoinPartsTable";

        public const string ctColName_Select = "Select";
        public const string ctColName_SalesRowNo = "SalesRowNo";
        public const string ctColName_JoinSourceMakerCode = "JoinSourceMakerCode";
        public const string ctColName_JoinSourPartsNoWithH = "JoinSourPartsNoWithH";
        public const string ctColName_JoinSourPartsNoNoneH = "JoinSourPartsNoNoneH";
        public const string ctColName_JoinDestMakerCd = "JoinDestMakerCd";
        public const string ctColName_JoinDestPartsNo = "JoinDestPartsNo";
        public const string ctColName_JoinQty = "JoinQty";
        public const string ctColName_EstimateDetailRow = "EstimateDetailRow ";
        public const string ctColName_DataGUID = "Guid";

        static public void CreateTable(ref DataTable dt)
        {
            if (dt == null)
            {
                dt = new DataTable(ctTableName);
            }
            dt.Rows.Clear();

            // カラム生成
            dt.Columns.Add(ctColName_SalesRowNo, typeof(int));
            dt.Columns[ctColName_SalesRowNo].DefaultValue = 0;

            dt.Columns.Add(ctColName_Select, typeof(bool));
            dt.Columns[ctColName_Select].DefaultValue = false;

            dt.Columns.Add(ctColName_JoinSourceMakerCode, typeof(int));
            dt.Columns[ctColName_JoinSourceMakerCode].DefaultValue = 0;

            dt.Columns.Add(ctColName_JoinSourPartsNoNoneH, typeof(string));
            dt.Columns[ctColName_JoinSourPartsNoNoneH].DefaultValue = string.Empty;

            dt.Columns.Add(ctColName_JoinSourPartsNoWithH, typeof(string));
            dt.Columns[ctColName_JoinSourPartsNoWithH].DefaultValue = string.Empty;

            dt.Columns.Add(ctColName_JoinDestMakerCd, typeof(int));
            dt.Columns[ctColName_JoinDestMakerCd].DefaultValue = 0;

            dt.Columns.Add(ctColName_JoinDestPartsNo, typeof(string));
            dt.Columns[ctColName_JoinDestPartsNo].DefaultValue = string.Empty;

            dt.Columns.Add(ctColName_JoinQty, typeof(double));
            dt.Columns[ctColName_JoinQty].DefaultValue = 0;

            dt.Columns.Add(ctColName_DataGUID, typeof(Guid));
            dt.Columns[ctColName_DataGUID].DefaultValue = Guid.Empty;


            dt.Columns.Add(ctColName_EstimateDetailRow, typeof(EstimateInputDataSet.EstimateDetailRow));
            dt.Columns[ctColName_EstimateDetailRow].DefaultValue = null;

            dt.PrimaryKey = new DataColumn[] { dt.Columns[ctColName_DataGUID] };
        }
    }

    #endregion
}