using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using System.Collections;


namespace Broadleaf.Windows.Forms
{
    public partial class PMMIT01010UH : UserControl
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■Constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="estimateInputAcs"></param>
        public PMMIT01010UH( EstimateInputAcs estimateInputAcs )
        {
            InitializeComponent();

            this._estimateInputAcs = estimateInputAcs;

            this._primeInfoView = this._estimateInputAcs.PrimeInfoView;
            this._primeInfoDataTable = this._estimateInputAcs.PrimeInfoDataTable;
            this.uGrid_PrimeInfo.DataSource = this._primeInfoView;
            this._estimateInputAcs.PimeInfoFilterChanged += new EventHandler(this.PrimeInfoChanged);
        }

        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■Private Member

        private EstimateInputAcs _estimateInputAcs;
        private EstimateInputDataSet.PrimeInfoDataTable _primeInfoDataTable;
        private DataView _primeInfoView;

        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■Properties
        /// <summary>優良データ数</summary>
        internal int PrimeDataCount
        {
            get { return this.uGrid_PrimeInfo.Rows.Count; }
        }
        #endregion

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        #region ■Control Event

        /// <summary>
        /// グリッド InitializeLayoutイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_PrimeInfo_InitializeLayout( object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e )
        {
            string moneyFormat = "#,##0;-#,##0;''";
            string decimalFormat = "#,##0.00;-#,##0.00;''";

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_PrimeInfo.DisplayLayout.Bands[0].Columns;

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

            //this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, false, 54));					// BLコード
            //this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, false, 140));					// 商品名
            //this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, false, 140));					// 品番
            //this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, false, 48));				// メーカーコード
            //this._estimateDetailDataTable.MakerNameColumn.ColumnName, visiblePosition++, false, 100));					// メーカー名称
            //this._estimateDetailDataTable.ShipmentCntDisplayColumn.ColumnName, visiblePosition++, false, 40));			// QTY
            //this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, false, 90));			// 定価
            //this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, visiblePosition++, false, 30));			// OP
            //this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName, visiblePosition++, false, 45));				// 倉庫
            //this._estimateDetailDataTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, false, 72));			// 棚番
            //this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName, visiblePosition++, false, 55));				// 現在庫数
            //this._estimateDetailDataTable.SetExistsColumn.ColumnName, visiblePosition++, false, 42));					// セット
            //this._estimateDetailDataTable.SupplierCdColumn.ColumnName, visiblePosition++, false, 72));					// 仕入先
            //this._estimateDetailDataTable.PrintSelectColumn.ColumnName, visiblePosition++, false, 42));					// 印刷
            //this._estimateDetailDataTable.OrderSelectColumn.ColumnName, visiblePosition++, false, 42));					// 発注

            // 選択フラグ
            Columns[this._primeInfoDataTable.SelectionStateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._primeInfoDataTable.SelectionStateColumn.ColumnName].AutoEdit = true;
            Columns[this._primeInfoDataTable.SelectionStateColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.SelectionStateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._primeInfoDataTable.SelectionStateColumn.ColumnName].Header.Fixed = true;
            Columns[this._primeInfoDataTable.SelectionStateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 品番
            Columns[this._primeInfoDataTable.GoodsNoColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._primeInfoDataTable.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.GoodsNoColumn.ColumnName].Header.Fixed = true;
            Columns[this._primeInfoDataTable.GoodsNoColumn.ColumnName].Width = 140;

            // 品名
            Columns[this._primeInfoDataTable.GoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._primeInfoDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.GoodsNameColumn.ColumnName].Header.Fixed = true;
            Columns[this._primeInfoDataTable.GoodsNameColumn.ColumnName].Width = 140;

            // メーカーコード
            Columns[this._primeInfoDataTable.GoodsMakerCdColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._primeInfoDataTable.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.GoodsMakerCdColumn.ColumnName].Header.Fixed = true;
            Columns[this._primeInfoDataTable.GoodsMakerCdColumn.ColumnName].Width = 48;

            // メーカー名
            Columns[this._primeInfoDataTable.MakerNameColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._primeInfoDataTable.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.MakerNameColumn.ColumnName].Header.Fixed = true;
            Columns[this._primeInfoDataTable.MakerNameColumn.ColumnName].Width = 140;

            // 標準価格
            Columns[this._primeInfoDataTable.ListPriceDisplayColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.ListPriceDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._primeInfoDataTable.ListPriceDisplayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.ListPriceDisplayColumn.ColumnName].Format = moneyFormat;
            Columns[this._primeInfoDataTable.ListPriceDisplayColumn.ColumnName].Width = 90;

            // QTY
            Columns[this._primeInfoDataTable.ShipmentCntColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.ShipmentCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._primeInfoDataTable.ShipmentCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.ShipmentCntColumn.ColumnName].Format = decimalFormat;
            Columns[this._primeInfoDataTable.ShipmentCntColumn.ColumnName].Width = 60;

            // 倉庫
            Columns[this._primeInfoDataTable.WarehouseCodeColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.WarehouseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._primeInfoDataTable.WarehouseCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.WarehouseCodeColumn.ColumnName].Width = 45;

            // 棚番
            Columns[this._primeInfoDataTable.WarehouseShelfNoColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._primeInfoDataTable.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.WarehouseShelfNoColumn.ColumnName].Width = 72;

            // 現在庫数
            Columns[this._primeInfoDataTable.ShipmentPosCntColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.ShipmentPosCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._primeInfoDataTable.ShipmentPosCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.ShipmentPosCntColumn.ColumnName].Format = decimalFormat;
            Columns[this._primeInfoDataTable.ShipmentPosCntColumn.ColumnName].Width = 55;

            // セット有無
            Columns[this._primeInfoDataTable.ExistSetInfo_DisplayColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.ExistSetInfo_DisplayColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._primeInfoDataTable.ExistSetInfo_DisplayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.ExistSetInfo_DisplayColumn.ColumnName].Width = 42;

            // 発注選択有無
            Columns[this._primeInfoDataTable.OrderSelectColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.OrderSelectColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._primeInfoDataTable.OrderSelectColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.OrderSelectColumn.ColumnName].Width = 42;

            // 結合備考
            Columns[this._primeInfoDataTable.JoinSpecialNoteColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.JoinSpecialNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._primeInfoDataTable.JoinSpecialNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.JoinSpecialNoteColumn.ColumnName].Width = 200;

            // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 種別
            Columns[this._primeInfoDataTable.PrmSetDtlName2Column.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.PrmSetDtlName2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._primeInfoDataTable.PrmSetDtlName2Column.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.PrmSetDtlName2Column.ColumnName].Width = 200;
            Columns[this._primeInfoDataTable.PrmSetDtlName2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            #endregion

            // 固定列区切り線設定
            this.uGrid_PrimeInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_PrimeInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
            
        }

        /// <summary>
        /// グリッド Clickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 鄧潘ハン 2011/11/24</br>
        /// <br>            : redmine#8034,外車データの部品検索で標準価格選択の品番表示で元品番が表示されるの修正</br>
        private void uGrid_PrimeInfo_Click( object sender, EventArgs e )
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

            if (objRow != null)
            {
                Guid primeRelationGuid = (Guid)objRow.Cells[this._primeInfoDataTable.PrimeInfoRelationGuidColumn.ColumnName].Value;
                int joinDispOrder = (Int32)objRow.Cells[this._primeInfoDataTable.JoinDispOrderColumn.ColumnName].Value;
                //---------ADD 2009/11/13-------->>>>>
                EstimateInputDataSet.PrimeInfoRow primeInfoRow = this._estimateInputAcs.PrimeInfoDataTable.FindByPrimeInfoRelationGuidJoinDispOrder(primeRelationGuid, joinDispOrder);
                if (primeRelationGuid == Guid.Empty || primeInfoRow == null) return;
                if (primeInfoRow.SelectionState == true) return;
                //---------ADD 2009/11/13--------<<<<<
                this._estimateInputAcs.SelectPrimeInfo(primeRelationGuid, joinDispOrder);
                //-----------ADD 2009/10/22-------->>>>>
                EstimateInputDataSet.PrimeInfoRow row = this._estimateInputAcs.PrimeInfoDataTable.FindByPrimeInfoRelationGuidJoinDispOrder(primeRelationGuid, joinDispOrder);

                if (row != null)
                {
                    #region 標準価格選択ウインドウ
                    // 画面入力値の標準価格選択が「する」の場合
                    if (this._estimateInputAcs._priceSelectValue == 1)
                    {
                        // 抽出条件設定
                        GoodsCndtn cndtn = new GoodsCndtn();
                        cndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        cndtn.SectionCode = this._estimateInputAcs.SalesSlip.ResultsAddUpSecCd;
                        cndtn.GoodsMakerCd = row.GoodsMakerCd;
                        cndtn.GoodsNo = row.GoodsNo;

                        //-----------UPD 2009/11/05--------->>>>>
                        PartsInfoDataSet _partsInfoDataSet = null;
                        ArrayList custRateGroupList;
                        ArrayList displayDivList;

                        // 結合元検索
                        if (this._estimateInputAcs._primeRelationDic.ContainsKey(row.PrimeInfoRelationGuid))
                        {
                            _partsInfoDataSet = this._estimateInputAcs._primeRelationDic[row.PrimeInfoRelationGuid];
                        }
                        if (_partsInfoDataSet == null) return;
                        // 得意先掛率グループコードマスタの全件取得
                        this._estimateInputAcs.GetCustRateGrpList(out custRateGroupList, cndtn.EnterpriseCode);
                        // 標準価格選択設定マスタの取得
                        this._estimateInputAcs.GetDisplayDivList(out displayDivList, cndtn.EnterpriseCode);
                        List<PriceSelectSet> priceSelectSet = new List<PriceSelectSet>((PriceSelectSet[])displayDivList.ToArray(typeof(PriceSelectSet)));

                        //結合元検索ﾃﾞﾘｹﾞｰﾄ
                        if (_partsInfoDataSet.SearchPartsForSrcParts == null)
                        {
                            _partsInfoDataSet.SearchPartsForSrcParts += new PartsInfoDataSet.SearchPartsForSrcPartsCallBack(this._estimateInputAcs.SearchPartsForSrcParts);
                        }
                        //得意先掛率ｸﾞﾙｰﾌﾟ取得ﾃﾞﾘｹﾞｰﾄ
                        if (_partsInfoDataSet.GetCustRateGrp == null)
                        {
                            _partsInfoDataSet.GetCustRateGrp += new PartsInfoDataSet.GetCustRateGrpCallBack(this._estimateInputAcs.GetCustRateGrp);
                        }
                        //表示区分取得ﾃﾞﾘｹﾞｰﾄ
                        if (_partsInfoDataSet.GetDisplayDiv == null)
                        {
                            _partsInfoDataSet.GetDisplayDiv += new PartsInfoDataSet.GetDisplayDivCallBack(this._estimateInputAcs.GetDisplayDiv);
                        }
                        // 結合元検索
                        _partsInfoDataSet.SettingSrcPartsInfo(cndtn);
                        if (_partsInfoDataSet.PartsInfoDataSetSrcParts == null) return;
                        // 得意先掛率ｸﾞﾙｰﾌﾟｺｰﾄﾞ取得
                        _partsInfoDataSet.SettingCustRateGrpCode(custRateGroupList, this._estimateInputAcs.SalesSlip.CustomerCode, row.GoodsNo, row.GoodsMakerCd);
                        PartsInfoDataSet.UsrGoodsInfoRow urrentRow = _partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(row.GoodsMakerCd, row.GoodsNo);
                        // 表示区分取得ﾞ取得
                        _partsInfoDataSet.SettingDisplayDiv(priceSelectSet, row.GoodsNo, row.GoodsMakerCd, row.BLGoodsCode, this._estimateInputAcs.SalesSlip.CustomerCode, urrentRow.CustRateGrpCode);
                        urrentRow = _partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(row.GoodsMakerCd, row.GoodsNo);

                        _partsInfoDataSet.GoodsNoSel = this._estimateInputAcs.GoodsEstimateNo;// ADD 鄧潘ハン 2011/11/24 Redmine#8034
                        // 標準価格選択ウインドウ表示処理
                        SelectionListPrice selectionListPrice = new SelectionListPrice(row.GoodsMakerCd, row.MakerName, row.GoodsNo, row.GoodsName, row.ListPriceTaxExcFl, _partsInfoDataSet, urrentRow.PriceSelectDiv);
                        selectionListPrice.ShowDialog(this);
                        //-----------UPD 2009/11/05---------<<<<<

                        PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow = _partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(row.GoodsMakerCd, row.GoodsNo);
                        // 1:定価(選択)を使用する
                        if (usrGoodsInfoRow.SelectedListPriceDiv == 1)
                        {
                            row.ListPriceDisplay = usrGoodsInfoRow.SelectedListPrice;
                            //-------UPD 2009/11/12------->>>>>
                            EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = (EstimateInputDataSet.EstimateDetailRow[])this._estimateInputAcs.EstimateDetailDataTable.Select(string.Format("{0}='{1}'", this._estimateInputAcs.EstimateDetailDataTable.PrimeInfoRelationGuidColumn.ColumnName, row.PrimeInfoRelationGuid));
                            if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 ))
                            {

                                estimateDetailRows[0].ListPriceDisplay_Prime = usrGoodsInfoRow.SelectedListPrice;
                                estimateDetailRows[0].AcceptChanges();
                                this._estimateInputAcs.EstimateDetailRowListPriceSetting(estimateDetailRows[0].SalesRowNo, EstimateInputAcs.TargetData.PrimeParts, EstimateInputAcs.PriceInputType.PriceDisplay, estimateDetailRows[0].ListPriceDisplay_Prime);// ADD 2009/11/13

                            }
                            //-------UPD 2009/11/12-------<<<<<
                            row.AcceptChanges();
                        }
                    }

                    #endregion
                }
                //-----------ADD 2009/10/22--------<<<<<
            }
        }

        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ■Public Methods

        /// <summary>
        /// グリッド再描画処理
        /// </summary>
        public void GridRefresh()
        {
            this.PrimeInfoChanged(this.uGrid_PrimeInfo, new EventArgs());
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods

        /// <summary>
        /// 優良データビューのフィルターが変更された時に発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimeInfoChanged( object sender, EventArgs e )
        {
            try
            {
                this.uGrid_PrimeInfo.BeginUpdate();
                for (int index = 0; index < this.uGrid_PrimeInfo.Rows.Count; index++)
                {
                    this.PrimeInfoIconSetting(index);
                }
            }
            finally
            {
                this.uGrid_PrimeInfo.EndUpdate();
            }
        }

        /// <summary>
        /// グリッドアイコン設定
        /// </summary>
        /// <param name="rowIndex"></param>
        private void PrimeInfoIconSetting(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_PrimeInfo.DisplayLayout.Bands[0];

			if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                if (col.Key == this._primeInfoDataTable.ExistSetInfo_DisplayColumn.ColumnName)
                {
                    this.DisplayExistSetInfo(rowIndex);
                }
                if (col.Key == this._primeInfoDataTable.OrderSelectColumn.ColumnName)
                {
                    this.DisplayExistUOEOrderInfo(rowIndex);
                }
            }
        }

        /// <summary>
        /// セット情報アイコン表示
        /// </summary>
        /// <param name="rowIndex"></param>
        private void DisplayExistSetInfo( int rowIndex )
        {
            if (rowIndex == -1) return;
            if (this._primeInfoView[rowIndex] != null)
            {
                if ((bool)this.uGrid_PrimeInfo.Rows[rowIndex].Cells[this._primeInfoDataTable.ExistSetInfoColumn.ColumnName].Value == true)
                {
                    this.uGrid_PrimeInfo.Rows[rowIndex].Cells[this._primeInfoDataTable.ExistSetInfo_DisplayColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                }
                else
                {
                    this.uGrid_PrimeInfo.Rows[rowIndex].Cells[this._primeInfoDataTable.ExistSetInfo_DisplayColumn.ColumnName].Appearance.Image = null;
                }
            }
        }

        /// <summary>
        /// 発注アイコン表示
        /// </summary>
        /// <param name="rowIndex"></param>
        private void DisplayExistUOEOrderInfo(int rowIndex)
        {
            if (rowIndex == -1) return;
            if (this._primeInfoView[rowIndex] != null)
            {
                if ((Guid)this.uGrid_PrimeInfo.Rows[rowIndex].Cells[this._primeInfoDataTable.UOEOrderGuidColumn.ColumnName].Value != Guid.Empty)
                {
                    this.uGrid_PrimeInfo.Rows[rowIndex].Cells[this._primeInfoDataTable.OrderSelectColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                }
                else
                {
                    this.uGrid_PrimeInfo.Rows[rowIndex].Cells[this._primeInfoDataTable.OrderSelectColumn.ColumnName].Appearance.Image = null;
                }
            }
        }    

        #endregion
    }
}
