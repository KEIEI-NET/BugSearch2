using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// 選択ガイド
    /// </summary>
    /// <remarks>
    /// <br>本クラスはinternalで宣言されている為、外部アセンブリからは直接参照できない。</br>
    /// <br>外部アセンブリから本クラスにアクセスする場合は、操作クラスにインターフェース</br>
    /// <br>となるメソッドやプロパティを作成する事</br>
    /// <br></br>
    /// <br>Update Note	: 速度チューニング対応（表示対象データの価格一括取得を追加）</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009.02.10</br>
    /// <br></br>
    /// <br>Update Note	: 優先倉庫にトリムをかけてチェックするように修正</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009.02.16</br>
    /// <br></br>
    /// <br>Update Note	: 在庫表示順で優先倉庫が上に表示されるよう変更</br>
    /// <br>             : 在庫の選択方法をチェック方式に変更（未チェックで取寄を選択可能に変更）</br>
    /// <br>Programmer	: 22018　鈴木 正臣</br>
    /// <br>Date		: 2009.03.27</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応（８月分）</br>
    /// <br>             : 　・在庫の明細件数がゼロの場合は、在庫グリッドに移動しないように変更。</br>
    /// <br>Programmer   : 22018　鈴木 正臣</br>
    /// <br>Date         : 2010/10/26</br>
    /// </remarks>
    public partial class SelectionFormSb : Form
    {
        #region private メンバー
        /// <summary>データセット</summary>
        private PartsInfoDataSet _orgDataSet = null;
        private PartsInfoDataSet.UsrGoodsInfoRow _orgRow = null;
        private PartsInfoDataSet.UsrGoodsInfoRow _prevRow = null;
        private Subst _dsSubst = null;
        private Subst.StockDataTable _StockTable;

        private SelectionInfo _selInf;

        //public Subst DsSubst
        //{
        //    get
        //    {
        //        return _dsSubst;
        //    }
        //}

        private int totalAmountDispWay;       // 総額表示方法区分 0:総額表示しない（税抜き）,1:総額表示する（税込み）

        private bool isUserClose = true;
        private string _oldPartsNoWithHyphen = null;
        #endregion

        #region [ 初期処理 ]
        /// <summary>
        /// 選択画面コンストラクタ
        /// </summary>
        /// <param name="dsSource">グリッドに表示するデータを指定します。</param>
        public SelectionFormSb(PartsInfoDataSet dsSource)
        {
            InitializeComponent();

            _orgDataSet = dsSource;
            _prevRow = _orgRow;
            _orgRow = dsSource.UsrGoodsInfo.RowToProcess;
            _dsSubst = new Subst();
            _StockTable = _dsSubst.Stock;
            _oldPartsNoWithHyphen = _orgRow.GoodsNo;
            _selInf = _orgDataSet.SubstSrcSelInf;

            totalAmountDispWay = dsSource.SearchCondition.SearchCntSetWork.TotalAmountDispWayCd; // 0:総額表示しない（税抜き）,1:総額表示する（税込み）

            InitializeData();
            gridSubst.DataSource = _dsSubst.OriginParts;
            gridStock.DataSource = _StockTable.DefaultView;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            SettingStockView( _StockTable.DefaultView );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD

            // ツールバーのイメージ(16x16)やメッセージを設定する
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            ToolbarsManager.Tools["Button_PlrSubst"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODEL;

            // 先頭行を選択状態にする
            gridSubst.Rows[0].Activate();
            gridSubst.Rows[0].Selected = true;
            gridSubst.Rows[0].Fixed = true;
            gridSubst.Rows[0].Expanded = true;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
        /// <summary>
        /// 在庫のDataSourceとなるViewを設定します
        /// </summary>
        /// <param name="dataView"></param>
        private void SettingStockView( DataView dataView )
        {
            // ソート設定
            dataView.Sort = string.Format( "{0}, {1}",
                                            _StockTable.SortDivColumn.ColumnName,
                                            _StockTable.WarehouseCodeColumn.ColumnName );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD

        /// <summary>
        /// 表示用データをDataTableに登録するためのサブスレッド
        /// </summary>
        private void InitializeData()
        {
            // 2009.02.10 Add >>>
            this.SettingPriceTargetData();
            // 2009.02.10 Add <<<
            Subst.OriginPartsRow rowMain = _dsSubst.OriginParts.NewOriginPartsRow();
            rowMain.ChgDestGoodsNo = _orgRow.GoodsNo;
            rowMain.ChgDestMakerCd = _orgRow.GoodsMakerCd;
            if (_orgRow.GoodsName != string.Empty)
            {
                rowMain.GoodsNm = _orgRow.GoodsName;
            }
            else
            {
                rowMain.GoodsNm = _orgRow.GoodsOfrName;
            }
            rowMain.MakerNm = _orgRow.GoodsMakerNm;
            if (totalAmountDispWay == 1) // 総額表示する（税込み）
            {
                rowMain.Price = _orgRow.PriceTaxInc;
                rowMain.Genka = _orgRow.UnitCostTaxInc;
                rowMain.Urika = _orgRow.SalesUnitPriceTaxInc;
            }
            else
            {
                rowMain.Price = _orgRow.PriceTaxExc;
                rowMain.Genka = _orgRow.UnitCostTaxExc;
                rowMain.Urika = _orgRow.SalesUnitPriceTaxExc;
            }
            _dsSubst.OriginParts.AddOriginPartsRow(rowMain);
            #region [ 在庫設定 ]
            //在庫設定
            bool flgStock = false;
            PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])_orgRow.GetChildRows("UsrGoodsInfo_Stock");
            for (int i = 0; i < stockRows.Length; i++)
            {
                Subst.StockRow stockRow = _StockTable.NewStockRow();
                stockRow.GoodsMakerCd = stockRows[i].GoodsMakerCd;
                stockRow.GoodsNo = stockRows[i].GoodsNo;
                stockRow.MaximumStockCnt = stockRows[i].MaximumStockCnt;
                stockRow.MinimumStockCnt = stockRows[i].MinimumStockCnt;
                stockRow.ShipmentPosCnt = stockRows[i].ShipmentPosCnt;
                stockRow.WarehouseCode = stockRows[i].WarehouseCode;
                stockRow.WarehouseName = stockRows[i].WarehouseName;
                stockRow.WarehouseShelfNo = stockRows[i].WarehouseShelfNo;
                stockRow.SelectionState = stockRows[i].SelectionState;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
                // 在庫情報のソートに使用する区分値をセットする
                if ( _orgDataSet.ListPriorWarehouse != null )
                {
                    int index = _orgDataSet.ListPriorWarehouse.IndexOf( stockRow.WarehouseCode.Trim() );
                    if ( index >= 0 )
                    {
                        // 優先倉庫リストにあればindexをセット
                        stockRow.SortDiv = index;
                    }
                    else
                    {
                        // 優先倉庫リストになければリストのCount(最大のindex+1)
                        stockRow.SortDiv = _orgDataSet.ListPriorWarehouse.Count;
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
                _StockTable.AddStockRow(stockRow);
                if (stockRows[i].SelectionState)
                {
                    rowMain.StockCnt = stockRow.ShipmentPosCnt;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                    rowMain.WarehouseCode = stockRow.WarehouseCode;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                    flgStock = true;
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL // 優先倉庫にない場合は取寄にする
            //if (flgStock == false && stockRows.Length > 0)
            //{
            //    rowMain.StockCnt = stockRows[0].ShipmentPosCnt;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            //    rowMain.WarehouseCode = stockRows[0].WarehouseCode;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
            #endregion

            string filter = string.Format("{0}={1} AND {2}='{3}' AND {4} = true", // 代替選択UIには提供のみ表示
                _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, _orgRow.GoodsMakerCd,
                _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, _orgRow.GoodsNo,
                _orgDataSet.UsrSubstParts.OfferKubunColumn.ColumnName);
            PartsInfoDataSet.UsrSubstPartsRow[] substRows =
                (PartsInfoDataSet.UsrSubstPartsRow[])_orgDataSet.UsrSubstParts.Select(filter);
            int cnt = substRows.Length;
            for (int i = 0; i < cnt; i++)
            {
                int makerCd = substRows[i].ChgDestMakerCd;
                string goodsNo = substRows[i].ChgDestGoodsNo;

                PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow =
                    _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);

                if (goodsInfoRow == null || (goodsInfoRow.GoodsKind & (int)GoodsKind.Subst) == (int)GoodsKind.Subst) //代替
                {
                    Subst.UsrSubstPartsRow sRow = _dsSubst.UsrSubstParts.NewUsrSubstPartsRow();
                    sRow.ChgSrcGoodsNo = substRows[i].ChgSrcGoodsNo;
                    sRow.ChgSrcMakerCd = substRows[i].ChgSrcMakerCd;
                    sRow.ChgDestGoodsNo = goodsNo;
                    sRow.ChgDestMakerCd = makerCd;
                    sRow.ApplyStDate = substRows[i].ApplyStDate;
                    sRow.ApplyEdDate = substRows[i].ApplyEdDate;
                    if (goodsInfoRow != null)
                    {
                        sRow.MakerNm = goodsInfoRow.GoodsMakerNm;
                        if (goodsInfoRow.GoodsName != string.Empty)
                        {
                            sRow.GoodsNm = goodsInfoRow.GoodsName;
                        }
                        else
                        {
                            sRow.GoodsNm = goodsInfoRow.GoodsOfrName;
                        }
                        if (totalAmountDispWay == 1) // 総額表示する（税込み）
                        {
                            sRow.Price = goodsInfoRow.PriceTaxInc;
                            sRow.Genka = goodsInfoRow.UnitCostTaxInc;
                            sRow.Urika = goodsInfoRow.SalesUnitPriceTaxInc;
                        }
                        else
                        {
                            sRow.Price = goodsInfoRow.PriceTaxExc;
                            sRow.Genka = goodsInfoRow.UnitCostTaxExc;
                            sRow.Urika = goodsInfoRow.SalesUnitPriceTaxExc;
                        }
                        PartsInfoDataSet.SubstPartsInfoRow[] ofrSubstRows
                            = (PartsInfoDataSet.SubstPartsInfoRow[])goodsInfoRow.GetChildRows("UsrGoodsInfo_SubstPartsInfo");
                        if (ofrSubstRows.Length > 0)
                        {
                            sRow.Comment = ofrSubstRows[0].PartsPluralSubstCmnt;
                            sRow.QTY = ofrSubstRows[0].PartsQty;
                        }
                    }

                    _dsSubst.UsrSubstParts.AddUsrSubstPartsRow(sRow);
                    #region [ 在庫設定 ]
                    filter = string.Format("{0}={1} AND {2}='{3}'",
                                _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, sRow.ChgDestMakerCd,
                                _orgDataSet.Stock.GoodsNoColumn.ColumnName, sRow.ChgDestGoodsNo);
                    stockRows = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(filter);
                    for (int j = 0; j < stockRows.Length; j++)
                    {
                        if (_dsSubst.Stock.FindByWarehouseCodeGoodsMakerCdGoodsNo(stockRows[j].WarehouseCode,
                                stockRows[j].GoodsMakerCd, stockRows[j].GoodsNo) == null)
                        {
                            Subst.StockRow stockRow = _StockTable.NewStockRow();
                            stockRow.GoodsMakerCd = stockRows[j].GoodsMakerCd;
                            stockRow.GoodsNo = stockRows[j].GoodsNo;
                            stockRow.MaximumStockCnt = stockRows[j].MaximumStockCnt;
                            stockRow.MinimumStockCnt = stockRows[j].MinimumStockCnt;
                            stockRow.ShipmentPosCnt = stockRows[j].ShipmentPosCnt;
                            stockRow.WarehouseCode = stockRows[j].WarehouseCode;
                            stockRow.WarehouseName = stockRows[j].WarehouseName;
                            stockRow.WarehouseShelfNo = stockRows[j].WarehouseShelfNo;
                            stockRow.SelectionState = stockRows[j].SelectionState;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
                            // 在庫情報のソートに使用する区分値をセットする
                            if ( _orgDataSet.ListPriorWarehouse != null )
                            {
                                int index = _orgDataSet.ListPriorWarehouse.IndexOf( stockRow.WarehouseCode.Trim() );
                                if ( index >= 0 )
                                {
                                    // 優先倉庫リストにあればindexをセット
                                    stockRow.SortDiv = index;
                                }
                                else
                                {
                                    // 優先倉庫リストになければリストのCount(最大のindex+1)
                                    stockRow.SortDiv = _orgDataSet.ListPriorWarehouse.Count;
                                }
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
                            _StockTable.AddStockRow(stockRow);
                            if (stockRows[j].SelectionState)
                            {
                                sRow.StockCnt = stockRow.ShipmentPosCnt;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                                sRow.WarehouseCode = stockRow.WarehouseCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                                flgStock = true;
                            }
                        }
                    }
                    if (flgStock == false && _orgDataSet.ListPriorWarehouse != null)
                    {
                        for (int j = 0; j < _orgDataSet.ListPriorWarehouse.Count; j++)
                        {
                            // 2009.02.16 >>>
                            //string warehouseCd = _orgDataSet.ListPriorWarehouse[j];
                            string warehouseCd = _orgDataSet.ListPriorWarehouse[j].Trim();
                            // 2009.02.16 <<<
                            for (int k = 0; k < stockRows.Length; k++)
                            {
                                if (stockRows[k].WarehouseCode.Equals(warehouseCd))
                                {
                                    sRow.StockCnt = stockRows[k].ShipmentPosCnt;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                                    sRow.WarehouseCode = stockRows[k].WarehouseCode;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                                    flgStock = true;
                                    break;
                                }
                            }
                            if (flgStock)
                                break;
                        }
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL // 優先倉庫にない場合は取寄にする
                    //if (flgStock == false && stockRows.Length > 0)
                    //{
                    //    sRow.StockCnt = stockRows[0].ShipmentPosCnt;
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                    //    sRow.WarehouseCode = stockRows[0].WarehouseCode;
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
                    #endregion
                }
                else if ((goodsInfoRow.GoodsKind & (int)GoodsKind.SubstPlrl) == (int)GoodsKind.SubstPlrl)  //代替互換か？
                {
                    Subst.DUsrSubstPartsRow sRow = _dsSubst.DUsrSubstParts.NewDUsrSubstPartsRow();
                    sRow.ChgSrcGoodsNo = substRows[i].ChgSrcGoodsNo;
                    sRow.ChgSrcMakerCd = substRows[i].ChgSrcMakerCd;
                    sRow.ChgDestGoodsNo = goodsNo;
                    sRow.ChgDestMakerCd = makerCd;
                    sRow.ApplyStDate = substRows[i].ApplyStDate;
                    sRow.ApplyEdDate = substRows[i].ApplyEdDate;

                    sRow.MakerNm = goodsInfoRow.GoodsMakerNm;
                    if (goodsInfoRow.GoodsName != string.Empty)
                    {
                        sRow.GoodsNm = goodsInfoRow.GoodsName;
                    }
                    else
                    {
                        sRow.GoodsNm = goodsInfoRow.GoodsOfrName;
                    }
                    if (totalAmountDispWay == 1) // 総額表示する（税込み）
                    {
                        sRow.Price = goodsInfoRow.PriceTaxInc;
                        sRow.Genka = goodsInfoRow.UnitCostTaxInc;
                        sRow.Urika = goodsInfoRow.SalesUnitPriceTaxInc;
                    }
                    else
                    {
                        sRow.Price = goodsInfoRow.PriceTaxExc;
                        sRow.Genka = goodsInfoRow.UnitCostTaxExc;
                        sRow.Urika = goodsInfoRow.SalesUnitPriceTaxExc;
                    }
                    _dsSubst.DUsrSubstParts.AddDUsrSubstPartsRow(sRow);
                    #region [ 在庫設定 ]
                    filter = string.Format("{0}={1} AND {2}='{3}'",
                                _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, sRow.ChgDestMakerCd,
                                _orgDataSet.Stock.GoodsNoColumn.ColumnName, sRow.ChgDestGoodsNo);
                    stockRows = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(filter);
                    for (int j = 0; j < stockRows.Length; j++)
                    {
                        if (_dsSubst.Stock.FindByWarehouseCodeGoodsMakerCdGoodsNo(stockRows[j].WarehouseCode,
                                stockRows[j].GoodsMakerCd, stockRows[j].GoodsNo) == null)
                        {
                            Subst.StockRow stockRow = _StockTable.NewStockRow();
                            stockRow.GoodsMakerCd = stockRows[j].GoodsMakerCd;
                            stockRow.GoodsNo = stockRows[j].GoodsNo;
                            stockRow.MaximumStockCnt = stockRows[j].MaximumStockCnt;
                            stockRow.MinimumStockCnt = stockRows[j].MinimumStockCnt;
                            stockRow.ShipmentPosCnt = stockRows[j].ShipmentPosCnt;
                            stockRow.WarehouseCode = stockRows[j].WarehouseCode;
                            stockRow.WarehouseName = stockRows[j].WarehouseName;
                            stockRow.WarehouseShelfNo = stockRows[j].WarehouseShelfNo;
                            stockRow.SelectionState = stockRows[j].SelectionState;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
                            // 在庫情報のソートに使用する区分値をセットする
                            if ( _orgDataSet.ListPriorWarehouse != null )
                            {
                                int index = _orgDataSet.ListPriorWarehouse.IndexOf( stockRow.WarehouseCode.Trim() );
                                if ( index >= 0 )
                                {
                                    // 優先倉庫リストにあればindexをセット
                                    stockRow.SortDiv = index;
                                }
                                else
                                {
                                    // 優先倉庫リストになければリストのCount(最大のindex+1)
                                    stockRow.SortDiv = _orgDataSet.ListPriorWarehouse.Count;
                                }
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
                            _StockTable.AddStockRow(stockRow);
                            if (stockRows[j].SelectionState)
                            {
                                sRow.StockCnt = stockRow.ShipmentPosCnt;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                                sRow.WarehouseCode = stockRow.WarehouseCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                                flgStock = true;
                            }
                        }
                    }
                    if (flgStock == false && _orgDataSet.ListPriorWarehouse != null)
                    {
                        for (int j = 0; j < _orgDataSet.ListPriorWarehouse.Count; j++)
                        {
                            // 2009.02.16 >>>
                            //string warehouseCd = _orgDataSet.ListPriorWarehouse[j];
                            string warehouseCd = _orgDataSet.ListPriorWarehouse[j].Trim();
                            // 2009.02.16 <<<
                            for (int k = 0; k < stockRows.Length; k++)
                            {
                                if (stockRows[k].WarehouseCode.Equals(warehouseCd))
                                {
                                    sRow.StockCnt = stockRows[k].ShipmentPosCnt;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                                    sRow.WarehouseCode = stockRows[k].WarehouseCode;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                                    flgStock = true;
                                    break;
                                }
                            }
                            if (flgStock)
                                break;
                        }
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL // 優先倉庫にない場合は取寄にする
                    //if (flgStock == false && stockRows.Length > 0)
                    //{
                    //    sRow.StockCnt = stockRows[0].ShipmentPosCnt;
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                    //    sRow.WarehouseCode = stockRows[0].WarehouseCode;
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
                    #endregion
                }

            }
            cnt = _dsSubst.DUsrSubstParts.Count;
            for (int i = 0; i < cnt; i++)
            {
                Subst.DUsrSubstPartsRow sRow = _dsSubst.DUsrSubstParts[i];
                int makerCd = sRow.ChgDestMakerCd;
                string goodsNo = sRow.ChgDestGoodsNo;

                PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow =
                    _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);
                PartsInfoDataSet.DSubstPartsInfoRow[] ofrDsubstRows
                            = (PartsInfoDataSet.DSubstPartsInfoRow[])goodsInfoRow.GetChildRows("UsrGoodsInfo_DSubstPartsInfo");
                //if (ofrDsubstRows.Length > 0)
                for (int j = 0; j < ofrDsubstRows.Length; j++)
                {
                    if (ofrDsubstRows[j].OldPartsNoWithHyphen == sRow.ChgSrcGoodsNo)
                    {
                        sRow.Comment = ofrDsubstRows[j].PartsPluralSubstCmnt;
                        sRow.QTY = ofrDsubstRows[j].PartsQty;
                        filter = string.Format("{0}={1} AND {2}='{3}'",
                                    _dsSubst.UsrSubstParts.ChgDestMakerCdColumn.ColumnName, ofrDsubstRows[j].CatalogPartsMakerCd,
                                    _dsSubst.UsrSubstParts.ChgDestGoodsNoColumn.ColumnName, ofrDsubstRows[j].PlrlSubNewPrtNoHypn);
                        Subst.UsrSubstPartsRow[] parentRows =
                            (Subst.UsrSubstPartsRow[])_dsSubst.UsrSubstParts.Select(filter);
                        if (parentRows.Length > 0)
                        {
                            sRow.UsrSubstPartsRowParent = parentRows[0];
                            parentRows[0].Gokan = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                        }
                    }
                }
            }

        }

        // 2009.02.10 Add >>>
        /// <summary>
        /// 対象データの価格設定
        /// </summary>
        private void SettingPriceTargetData()
        {
            if (_orgDataSet.CalculateGoodsPrice == null) return;

            List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList = new List<PartsInfoDataSet.GoodsPrimaryKey>();

            // 代替元
            goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(_orgRow.GoodsNo, _orgRow.GoodsMakerCd));

            string filter = string.Format("{0}={1} AND {2}='{3}' AND {4} = true", // 代替選択UIには提供のみ表示
                _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, _orgRow.GoodsMakerCd,
                _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, _orgRow.GoodsNo,
                _orgDataSet.UsrSubstParts.OfferKubunColumn.ColumnName);
            PartsInfoDataSet.UsrSubstPartsRow[] substRows =
                (PartsInfoDataSet.UsrSubstPartsRow[])_orgDataSet.UsrSubstParts.Select(filter);
            int cnt = substRows.Length;
            for (int i = 0; i < cnt; i++)
            {
                int makerCd = substRows[i].ChgDestMakerCd;
                string goodsNo = substRows[i].ChgDestGoodsNo;

                PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow =
                    _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);

                if (goodsInfoRow == null || ( goodsInfoRow.GoodsKind & (int)GoodsKind.Subst ) == (int)GoodsKind.Subst) //代替
                {
                    //goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(goodsInfoRow.GoodsNo, goodsInfoRow.GoodsMakerCd));
                    goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(goodsNo, makerCd));

                    //Subst.UsrSubstPartsRow sRow = _dsSubst.UsrSubstParts.NewUsrSubstPartsRow();
                    //sRow.ChgSrcGoodsNo = substRows[i].ChgSrcGoodsNo;
                    //sRow.ChgSrcMakerCd = substRows[i].ChgSrcMakerCd;
                    //sRow.ChgDestGoodsNo = goodsNo;
                    //sRow.ChgDestMakerCd = makerCd;
                    //sRow.ApplyStDate = substRows[i].ApplyStDate;
                    //sRow.ApplyEdDate = substRows[i].ApplyEdDate;
                    //if (goodsInfoRow != null)
                    //{
                    //    sRow.MakerNm = goodsInfoRow.GoodsMakerNm;
                    //    if (goodsInfoRow.GoodsName != string.Empty)
                    //    {
                    //        sRow.GoodsNm = goodsInfoRow.GoodsName;
                    //    }
                    //    else
                    //    {
                    //        sRow.GoodsNm = goodsInfoRow.GoodsOfrName;
                    //    }
                    //    if (totalAmountDispWay == 1) // 総額表示する（税込み）
                    //    {
                    //        sRow.Price = goodsInfoRow.PriceTaxInc;
                    //        sRow.Genka = goodsInfoRow.UnitCostTaxInc;
                    //        sRow.Urika = goodsInfoRow.SalesUnitPriceTaxInc;
                    //    }
                    //    else
                    //    {
                    //        sRow.Price = goodsInfoRow.PriceTaxExc;
                    //        sRow.Genka = goodsInfoRow.UnitCostTaxExc;
                    //        sRow.Urika = goodsInfoRow.SalesUnitPriceTaxExc;
                    //    }
                    //    PartsInfoDataSet.SubstPartsInfoRow[] ofrSubstRows
                    //        = (PartsInfoDataSet.SubstPartsInfoRow[])goodsInfoRow.GetChildRows("UsrGoodsInfo_SubstPartsInfo");
                    //    if (ofrSubstRows.Length > 0)
                    //    {
                    //        sRow.Comment = ofrSubstRows[0].PartsPluralSubstCmnt;
                    //        sRow.QTY = ofrSubstRows[0].PartsQty;
                    //    }
                    //}

                    //_dsSubst.UsrSubstParts.AddUsrSubstPartsRow(sRow);
                }
                else if (( goodsInfoRow.GoodsKind & (int)GoodsKind.SubstPlrl ) == (int)GoodsKind.SubstPlrl)  //代替互換か？
                {
                    //goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(goodsInfoRow.GoodsNo, goodsInfoRow.GoodsMakerCd));
                    goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(goodsNo, makerCd));

                    //Subst.DUsrSubstPartsRow sRow = _dsSubst.DUsrSubstParts.NewDUsrSubstPartsRow();
                    //sRow.ChgSrcGoodsNo = substRows[i].ChgSrcGoodsNo;
                    //sRow.ChgSrcMakerCd = substRows[i].ChgSrcMakerCd;
                    //sRow.ChgDestGoodsNo = goodsNo;
                    //sRow.ChgDestMakerCd = makerCd;
                    //sRow.ApplyStDate = substRows[i].ApplyStDate;
                    //sRow.ApplyEdDate = substRows[i].ApplyEdDate;

                    //sRow.MakerNm = goodsInfoRow.GoodsMakerNm;
                    //if (goodsInfoRow.GoodsName != string.Empty)
                    //{
                    //    sRow.GoodsNm = goodsInfoRow.GoodsName;
                    //}
                    //else
                    //{
                    //    sRow.GoodsNm = goodsInfoRow.GoodsOfrName;
                    //}
                    //if (totalAmountDispWay == 1) // 総額表示する（税込み）
                    //{
                    //    sRow.Price = goodsInfoRow.PriceTaxInc;
                    //    sRow.Genka = goodsInfoRow.UnitCostTaxInc;
                    //    sRow.Urika = goodsInfoRow.SalesUnitPriceTaxInc;
                    //}
                    //else
                    //{
                    //    sRow.Price = goodsInfoRow.PriceTaxExc;
                    //    sRow.Genka = goodsInfoRow.UnitCostTaxExc;
                    //    sRow.Urika = goodsInfoRow.SalesUnitPriceTaxExc;
                    //}
                    //_dsSubst.DUsrSubstParts.AddDUsrSubstPartsRow(sRow);
                }
            }

            // 商品情報が存在する場合は価格計算
            if (goodsPrimaryKeyList.Count > 0)
            {
                _orgDataSet.SettingGoodsPrice(goodsPrimaryKeyList);
            }
        }

        // 2009.02.10 Add <<<

        private void SetBandProperty(UltraGridBand band)
        {
            List<string> colToShow = new List<string>(new string[]{ 
                _dsSubst.UsrSubstParts.SelImageColumn.ColumnName,          // 0
                _dsSubst.UsrSubstParts.ChgDestGoodsNoColumn.ColumnName,    // 1
                _dsSubst.UsrSubstParts.GoodsNmColumn.ColumnName,
                _dsSubst.UsrSubstParts.PriceColumn.ColumnName,
                _dsSubst.UsrSubstParts.GenkaColumn.ColumnName,
                _dsSubst.UsrSubstParts.UrikaColumn.ColumnName,
                _dsSubst.UsrSubstParts.StockCntColumn.ColumnName
            });

            for (int Index = 0; Index < band.Columns.Count; Index++)
            {
                if (colToShow.Contains(band.Columns[Index].Key))
                {
                    band.Columns[Index].Hidden = false;
                    // 水平表示位置
                    if (band.Columns[Index].DataType == typeof(int) || band.Columns[Index].DataType == typeof(double))
                    {
                        band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    }
                    else
                    {
                        band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    }
                    band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

                    // 垂直表示位置
                    band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                }
                else
                {
                    band.Columns[Index].Hidden = true;
                }
            }
        }
        #endregion

        #region [ フォームイベント処理 ]
        /// <summary>
        /// FormClosed イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResultがOKの場合にのみ、グリッド上で選択されている行に関連するDataRowオブジェクトを取得し、</br>
        /// <br>"選択状態"に相当する処理を行います。</br>
        /// </remarks>
        private void SelectionFormSb_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel || DialogResult == DialogResult.Abort)
            {
                return;
            }
            UltraGridRow row = gridSubst.ActiveRow;

            if (row.Band == gridSubst.DisplayLayout.Bands[2])
                row = row.ParentRow;

            int makerCd = (int)row.Cells[_dsSubst.UsrSubstParts.ChgDestMakerCdColumn.ColumnName].Value;
            string pGoodsNo = row.Cells[_dsSubst.UsrSubstParts.ChgDestGoodsNoColumn.ColumnName].Value.ToString();

            PartsInfoDataSet.UsrGoodsInfoRow rowUsrGoods = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, pGoodsNo);
            //rowUsrGoods.SelectionState = true;
            rowUsrGoods.QTY = (double)row.Cells[_dsSubst.UsrSubstParts.QTYColumn.ColumnName].Value;
            if (row.Band.ParentBand == null)
            {
                rowUsrGoods.GoodsKindResolved = (int)GoodsKind.Parent;
            }
            else
            {
                rowUsrGoods.GoodsKindResolved = (int)GoodsKind.Subst;
            }

            if (row.Band != gridSubst.DisplayLayout.Bands[1] || row.Expanded == false
                || row.Cells[_dsSubst.UsrSubstParts.SelImageColumn.ColumnName].Value != DBNull.Value)
            {
                SelectionInfo selInfoSub = new SelectionInfo();
                selInfoSub.Depth = _selInf.Depth;
                selInfoSub.Key = row.ListIndex;
                selInfoSub.RowGoods = rowUsrGoods;
                selInfoSub.WarehouseCode = row.Cells[_dsSubst.UsrSubstParts.WarehouseCodeColumn.ColumnName].Value.ToString();
                selInfoSub.Selected = true;
                _selInf.ListPlrlSubst.Add(selInfoSub);
            }

            if (row.Band == gridSubst.DisplayLayout.Bands[1] && row.Expanded)
            {
                //_orgDataSet.UsrSubstParts.FindByChgDestGoodsNoChgSrcGoodsNoChgSrcMakerCd(
                //    pGoodsNo, _orgRow.GoodsNo, makerCd).SelectionState = true;
                for (int i = 0; i < _dsSubst.DUsrSubstParts.Count; i++)
                {
                    Subst.UsrSubstPartsRow pRow = (Subst.UsrSubstPartsRow)_dsSubst.DUsrSubstParts[i].GetParentRow("UsrSubstParts_DUsrSubstParts");
                    if (_dsSubst.DUsrSubstParts[i][_dsSubst.DUsrSubstParts.SelImageColumn.ColumnName] != DBNull.Value
                        && pRow.ChgDestMakerCd == makerCd && pRow.ChgDestGoodsNo == pGoodsNo)
                    {
                        makerCd = _dsSubst.DUsrSubstParts[i].ChgDestMakerCd;
                        string goodsNo = _dsSubst.DUsrSubstParts[i].ChgDestGoodsNo;
                        PartsInfoDataSet.UsrGoodsInfoRow rowUsrGoodsD = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);
                        rowUsrGoodsD.GoodsKindResolved = (int)GoodsKind.SubstPlrl;
                        rowUsrGoodsD.QTY = (double)row.Cells[_dsSubst.UsrSubstParts.QTYColumn.ColumnName].Value;

                        SelectionInfo selInfoSub = new SelectionInfo();
                        selInfoSub.Depth = _selInf.Depth;
                        selInfoSub.Key = row.ListIndex;
                        selInfoSub.RowGoods = rowUsrGoodsD;
                        selInfoSub.WarehouseCode = row.Cells[_dsSubst.DUsrSubstParts.WarehouseCodeColumn.ColumnName].Value.ToString();
                        selInfoSub.Selected = true;

                        _selInf.ListPlrlSubst.Add(selInfoSub);
                        //_orgDataSet.AddSelectionInfo(selInfo.ListPlrlSubst, row.ListIndex, ref selInfoSub);

                        //rowUsrGoodsD.SelectionState = true;
                        //rowUsrGoodsD.GoodsKindResolved = (int)GoodsKind.SubstPlrl;
                        //rowUsrGoodsD.QTY = (double)row.Cells[_dsSubst.UsrSubstParts.QTYColumn.ColumnName].Value;
                        //_orgDataSet.UsrSubstParts.FindByChgDestGoodsNoChgSrcGoodsNoChgSrcMakerCd(
                        //    goodsNo, _orgRow.GoodsNo, makerCd).SelectionState = true;
                    }
                }
            }
        }

        private void SelectionFormSb_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (e.CloseReason == CloseReason.UserClosing && isUserClose)
            //{
            //    if (TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Text,
            //        "以前の選択画面に戻らず、選択をキャンセルしますか？", 0, MessageBoxButtons.YesNo)
            //        == DialogResult.Yes)
            //    {
            //        this.DialogResult = DialogResult.Abort;
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }

        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionFormSb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                isUserClose = false;
            }
        }
        #endregion

        #region [ ツールーバーイベント処理 ]
        /// <summary>
        /// ツールボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Button_Select":
                    if (gridSubst.ActiveRow != null)
                    {
                        if ((gridSubst.ActiveRow.Band == gridSubst.DisplayLayout.Bands[1] && gridSubst.ActiveRow.Expanded)
                            || (gridSubst.ActiveRow.Band == gridSubst.DisplayLayout.Bands[2])) // 複数互換バンドの場合
                        {
                            UltraGridRow row = gridSubst.ActiveRow.GetSibling(SiblingRow.First);
                            bool selFlg = false;
                            if (row.ParentRow.Cells[_dsSubst.UsrSubstParts.SelImageColumn.ColumnName].Value != DBNull.Value)
                                selFlg = true;
                            // 複数互換の部品中いづれか選択されたのがあるか
                            while (row != null)
                            {
                                if (row.Cells[_dsSubst.DUsrSubstParts.SelImageColumn.ColumnName].Value != DBNull.Value)
                                {
                                    selFlg = true;
                                    break;
                                }
                                row = row.GetSibling(SiblingRow.Next);
                            }
                            if (selFlg == false) // 選択されたのがない場合
                            {
                                SetStatusBarText(1, "データの選択がされていません。");
                                break;
                            }
                            //gridSubst.ActiveRow.Cells[_dsSubst.DUsrSubstParts.SelImageColumn.ColumnName].Value
                            //    = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                        }
                        DialogResult = DialogResult.OK;
                        isUserClose = false;
                    }
                    break;

                case "Button_Back":
                    // 前の画面に戻る
                    DialogResult = DialogResult.Cancel;
                    isUserClose = false;
                    break;

                case "Button_PlrSubst": // 複数互換処理
                    if (gridSubst.ActiveRow != null
                        && gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.GokanColumn.ColumnName].Value != null)
                    {
                        if (gridSubst.ActiveRow.Expanded)
                        {
                            gridSubst.ActiveRow.CollapseAll();
                        }
                        else
                        {
                            gridSubst.ActiveRow.ExpandAll();
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// ステータスバー設定
        /// </summary>
        /// <param name="mode">0:黒字　1:赤字</param>
        /// <param name="msg">設定するメッセージ</param>
        private void SetStatusBarText(int mode, string msg)
        {
            StatusBar.Panels[0].Text = msg;
            switch (mode)
            {
                case 0: // 0:黒字
                    StatusBar.Panels[0].Appearance.Reset();
                    break;
                case 1: // 1:赤字
                    StatusBar.Panels[0].Appearance.ForeColor = Color.Red;
                    StatusBar.Panels[0].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    break;
            }
        }

        #endregion

        #region [ グリッドイベント処理 ]
        /// <summary>
        /// InitializeLayout イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>グリッドのレイアウト初期化処理</br>
        /// </remarks>
        private void gridSubst_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // 列幅の自動調整方法
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;

            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            gridSubst.DisplayLayout.InterBandSpacing = 3;
            // バンドの取得
            UltraGridBand band0 = e.Layout.Bands[0];

            band0.Indentation = 0;
            band0.ColHeadersVisible = false;
            band0.Override.RowSizing = RowSizing.Fixed;
            band0.Override.AllowColSizing = AllowColSizing.None;
            band0.UseRowLayout = true;
            band0.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;

            SetBandProperty(band0);

            band0.Columns[_dsSubst.OriginParts.GokanColumn.ColumnName].Hidden = false;
            band0.Columns[_dsSubst.OriginParts.GokanColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band0.Columns[_dsSubst.OriginParts.GokanColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;

            ColInfo.SetColInfo(band0, _dsSubst.OriginParts.SelImageColumn.ColumnName, 2, 0, 1, 2, 10);
            ColInfo.SetColInfo(band0, _dsSubst.OriginParts.ChgDestGoodsNoColumn.ColumnName, 3, 0, 5, 2, 50);
            ColInfo.SetColInfo(band0, _dsSubst.OriginParts.GoodsNmColumn.ColumnName, 8, 0, 10, 2, 100);
            ColInfo.SetColInfo(band0, _dsSubst.OriginParts.PriceColumn.ColumnName, 18, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSubst.OriginParts.GenkaColumn.ColumnName, 22, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSubst.OriginParts.UrikaColumn.ColumnName, 26, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSubst.OriginParts.StockCntColumn.ColumnName, 30, 0, 3, 2, 30);
            ColInfo.SetColInfo(band0, _dsSubst.OriginParts.GokanColumn.ColumnName, 33, 0, 10);
            band0.Columns[_dsSubst.OriginParts.PriceColumn.ColumnName].Format = "C";
            band0.Columns[_dsSubst.OriginParts.GenkaColumn.ColumnName].Format = "C";
            band0.Columns[_dsSubst.OriginParts.UrikaColumn.ColumnName].Format = "C";
            band0.Columns[_dsSubst.OriginParts.StockCntColumn.ColumnName].Format = "###,###,##0.00";

            // バンドの取得
            UltraGridBand band1 = e.Layout.Bands[1];

            band1.Indentation = 0;
            band1.Override.HeaderPlacement = HeaderPlacement.FixedOnTop;
            band1.Override.RowSizing = RowSizing.Fixed;
            band1.Override.AllowColSizing = AllowColSizing.None;
            band1.UseRowLayout = true;

            SetBandProperty(band1);

            band1.Columns[_dsSubst.UsrSubstParts.GokanColumn.ColumnName].Hidden = false;
            band1.Columns[_dsSubst.UsrSubstParts.GokanColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band1.Columns[_dsSubst.UsrSubstParts.GokanColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;

            ColInfo.SetColInfo(band1, _dsSubst.UsrSubstParts.SelImageColumn.ColumnName, 2, 0, 1, 2, 10);
            ColInfo.SetColInfo(band1, _dsSubst.UsrSubstParts.ChgDestGoodsNoColumn.ColumnName, 3, 0, 5, 2, 50);
            ColInfo.SetColInfo(band1, _dsSubst.UsrSubstParts.GoodsNmColumn.ColumnName, 8, 0, 10, 2, 100);
            ColInfo.SetColInfo(band1, _dsSubst.UsrSubstParts.PriceColumn.ColumnName, 18, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSubst.UsrSubstParts.GenkaColumn.ColumnName, 22, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSubst.UsrSubstParts.UrikaColumn.ColumnName, 26, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSubst.UsrSubstParts.StockCntColumn.ColumnName, 30, 0, 3, 2, 30);
            ColInfo.SetColInfo(band1, _dsSubst.UsrSubstParts.GokanColumn.ColumnName, 33, 0, 10);
            band1.Columns[_dsSubst.UsrSubstParts.PriceColumn.ColumnName].Format = "C";
            band1.Columns[_dsSubst.UsrSubstParts.GenkaColumn.ColumnName].Format = "C";
            band1.Columns[_dsSubst.UsrSubstParts.UrikaColumn.ColumnName].Format = "C";
            band1.Columns[_dsSubst.UsrSubstParts.StockCntColumn.ColumnName].Format = "###,###,##0.00";

            // バンドの取得
            UltraGridBand band2 = e.Layout.Bands[2];
            band2.Indentation = 6;
            band2.Override.RowSizing = RowSizing.Fixed;
            band2.Override.AllowColSizing = AllowColSizing.None;
            band2.UseRowLayout = true;

            SetBandProperty(band2);

            band2.Columns[_dsSubst.DUsrSubstParts.SelImageColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;

            ColInfo.SetColInfo(band2, _dsSubst.DUsrSubstParts.SelImageColumn.ColumnName, 2, 0, 1, 2, 6);
            //ColInfo.SetColInfo(band2, _dsSubst.DUsrSubstParts.MakerNmColumn.ColumnName, 4, 0, 40);
            ColInfo.SetColInfo(band2, _dsSubst.DUsrSubstParts.ChgDestGoodsNoColumn.ColumnName, 3, 0, 5, 2, 50);
            ColInfo.SetColInfo(band2, _dsSubst.DUsrSubstParts.GoodsNmColumn.ColumnName, 8, 0, 10, 2, 100);
            ColInfo.SetColInfo(band2, _dsSubst.DUsrSubstParts.PriceColumn.ColumnName, 18, 0, 4, 2, 40);
            ColInfo.SetColInfo(band2, _dsSubst.DUsrSubstParts.GenkaColumn.ColumnName, 22, 0, 4, 2, 40);
            ColInfo.SetColInfo(band2, _dsSubst.DUsrSubstParts.UrikaColumn.ColumnName, 26, 0, 4, 2, 40);
            ColInfo.SetColInfo(band2, _dsSubst.DUsrSubstParts.StockCntColumn.ColumnName, 30, 0, 4, 2, 40);
            band2.Columns[_dsSubst.UsrSubstParts.PriceColumn.ColumnName].Format = "C";
            band2.Columns[_dsSubst.UsrSubstParts.GenkaColumn.ColumnName].Format = "C";
            band2.Columns[_dsSubst.UsrSubstParts.UrikaColumn.ColumnName].Format = "C";
            band2.Columns[_dsSubst.UsrSubstParts.StockCntColumn.ColumnName].Format = "###,###,##0.00";
        }

        /// <summary>
        /// アクティブ行変更後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridSubst_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (gridSubst.Selected.Rows.Count == 0)
                return;
            if (gridSubst.Selected.Rows[0].Equals(gridSubst.ActiveRow) == false)
                gridSubst.Selected.Rows[0].Activate();

            if (gridSubst.ActiveRow.Band != gridSubst.DisplayLayout.Bands[2] && // 互換バンドでない場合
                gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.GokanColumn.ColumnName].Value != System.DBNull.Value)
            {
                ToolbarsManager.Tools["Button_PlrSubst"].SharedProps.Enabled = true;
            }
            else
            {
                ToolbarsManager.Tools["Button_PlrSubst"].SharedProps.Enabled = false;
            }
            string filter = string.Format("{0}={1} AND {2}='{3}' ",
                    _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName,
                    gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.ChgDestMakerCdColumn.ColumnName].Value,
                    _orgDataSet.Stock.GoodsNoColumn.ColumnName,
                    gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.ChgDestGoodsNoColumn.ColumnName].Value);
            _StockTable.DefaultView.RowFilter = filter;

            SetStockGridSelect();
        }

        /// <summary>
        /// 行をダブルクリックされた場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// データが表示されていない行をダブルクリックしても本イベントは発生しない。
        /// </remarks>
        private void gridSubst_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SelectionProc(false);
        }

        /// <summary>
        /// グリッド上でEnterキーが押された場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridSubst_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGridRow activeRow = gridSubst.ActiveRow;
            if (activeRow == null)
                return;
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (activeRow.ChildBands != null)
                    {
                        if (activeRow.ChildBands.Count > 0 && activeRow.ChildBands[0].Rows.Count > 0  // 子バンドがあるか
                            && activeRow.Expanded)
                        {
                            //activeRow.ChildBands[0].Rows[0].Activate();
                            //activeRow.Selected = true;
                            activeRow.ChildBands[0].Rows[0].Selected = true;
                            e.Handled = true;
                        }
                    }
                    else if (activeRow.GetSibling(SiblingRow.Next) == null && activeRow.ParentRow != null)
                    {
                        UltraGridRow ugr = activeRow.ParentRow.GetSibling(SiblingRow.Next);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                    }
                    break;

                case Keys.Up:
                    if (activeRow.Band.ParentBand != null // 子バンドか
                        && activeRow.Index == 0)
                    {
                        //activeRow.ParentRow.Activate();
                        //activeRow.Selected = true;
                        activeRow.ParentRow.Selected = true;
                        e.Handled = true;
                    }
                    break;

                case Keys.Enter:
                    SelectionProc(true);
                    break;
            }
        }

        private void gridStock_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            UltraGridBand band = e.Layout.Bands[0];
            band.UseRowLayout = true;
            band.Indentation = 0;

            band.Columns[_StockTable.SelectionStateColumn.ColumnName].Hidden = true;
            band.Columns[_StockTable.GoodsMakerCdColumn.ColumnName].Hidden = true;
            band.Columns[_StockTable.GoodsNoColumn.ColumnName].Hidden = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            band.Columns[_StockTable.SortDivColumn.ColumnName].Hidden = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
            for (int i = 0; i < band.Columns.Count; i++)
            {
                // 水平表示位置
                if ((band.Columns[i].DataType == typeof(int)) ||
                   (band.Columns[i].DataType == typeof(double)))
                {
                    band.Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (band.Columns[i].DataType == typeof(Image))
                {
                    band.Columns[i].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    band.Columns[i].CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                }
                else
                {
                    band.Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band.Columns[i].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // 垂直表示位置
                band.Columns[i].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            ColInfo.SetColInfo( band, _StockTable.SelImageColumn.ColumnName, 0, 0, 10 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
            ColInfo.SetColInfo(band, _StockTable.WarehouseCodeColumn.ColumnName, 2, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.WarehouseNameColumn.ColumnName, 5, 0, 100);
            ColInfo.SetColInfo(band, _StockTable.WarehouseShelfNoColumn.ColumnName, 7, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.ShipmentPosCntColumn.ColumnName, 9, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.MinimumStockCntColumn.ColumnName, 11, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.MaximumStockCntColumn.ColumnName, 13, 0, 50);
            band.Columns[_StockTable.ShipmentPosCntColumn.ColumnName].Format = "###,###,##0.00";
            band.Columns[_StockTable.MinimumStockCntColumn.ColumnName].Format = "###,###,##0.00";
            band.Columns[_StockTable.MaximumStockCntColumn.ColumnName].Format = "###,###,##0.00";
        }

        /// <summary>
        /// 在庫情報選択反映
        /// </summary>
        /// <remarks>在庫情報を選択すると部品情報の在庫情報を更新する</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //if (gridStock.ActiveRow != null && gridSubst.ActiveRow != null)// && gridJoinParts.ActiveRow.Band.ParentBand != null)
            //{
            //    gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.StockCntColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
            //    gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.WarehouseCodeColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
            //    gridStock.ActiveRow.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
            //    gridSubst.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
        }

        private void gridStock_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //if (gridStock.Selected.Rows.Count > 0)
            //    gridStock.Selected.Rows[0].Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
        }

        /// <summary>
        /// 選択処理
        /// </summary>
        /// <param name="moveFlg">true:次の行に移動　false:行移動なし</param>
        private void SelectionProc(bool moveFlg)
        {
            UltraGridRow activeRow = gridSubst.ActiveRow;
            if (activeRow.Band != gridSubst.DisplayLayout.Bands[2] &&  // 複数互換バンドでない場合
                (activeRow.Band != gridSubst.DisplayLayout.Bands[1]
                    || activeRow.Expanded == false)) // 互換が展開されていない
            {
                DialogResult = DialogResult.OK;
                isUserClose = false;
            }
            else
            {
                if (activeRow.Cells[_dsSubst.DUsrSubstParts.SelImageColumn.ColumnName].Value != DBNull.Value)
                {
                    activeRow.Cells[_dsSubst.DUsrSubstParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                }
                else
                {
                    activeRow.Cells[_dsSubst.DUsrSubstParts.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                }
                if (moveFlg)
                {
                    if (activeRow.Band == gridSubst.DisplayLayout.Bands[1])
                    {
                        activeRow.ChildBands[0].Rows[0].Activate();
                        activeRow.ChildBands[0].Rows[0].Selected = true;
                    }
                    else if (activeRow.Band == gridSubst.DisplayLayout.Bands[2])
                    {
                        UltraGridRow ugr = activeRow.GetSibling(SiblingRow.Next);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                    }
                }
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
        /// <summary>
        /// 在庫グリッド・Enterキー(ダブルクリック)による選択処理
        /// </summary>
        /// <param name="moveFlg"></param>
        private void SetSelectStock( bool moveFlg )
        {
            SetSelectStock( moveFlg, false );
        }
        /// <summary>
        /// 在庫グリッド・Enterキー(ダブルクリック)による選択処理
        /// </summary>
        /// <param name="moveFlg">true:次の行を選択状態に／false:なにもしない（マウスダブルクリック時）</param>
        /// <param name="setTrue">true:選択状態TRUEにする／選択状態を反転する</param>
        private void SetSelectStock( bool moveFlg, bool setTrue )
        {
            UltraGridRow activeRow = gridStock.ActiveRow;
            if ( activeRow != null )
            {
                CellsCollection activeCells = activeRow.Cells;

                // 選択/非選択の切り替え
                if ( activeCells[_StockTable.SelImageColumn.ColumnName].Value != DBNull.Value && !setTrue )
                {
                    activeCells[_StockTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                    activeCells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
                }
                else
                {
                    activeCells[_StockTable.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    activeCells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
                }
                _StockTable.AcceptChanges();

                // 他の行は選択解除する
                # region [他の行は選択解除する]
                foreach ( UltraGridRow row in gridStock.Rows )
                {
                    if ( row.Equals( activeRow ) == false && row.Cells[_StockTable.SelImageColumn.ColumnName].Value != DBNull.Value )
                    {
                        row.Cells[_StockTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                        row.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
                    }
                }
                # endregion

                // 部品グリッドの在庫情報表示を更新
                # region [部品グリッドの在庫情報表示を更新]
                if ( gridSubst.ActiveRow != null )
                {
                    if ( (bool)activeCells[_StockTable.SelectionStateColumn.ColumnName].Value == true )
                    {
                        // 部品グリッドに在庫情報表示
                        //gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.WarehouseColumn.ColumnName].Value
                        //    = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
                        //gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.ShelfColumn.ColumnName].Value
                        //    = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
                        gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.StockCntColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
                        gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.WarehouseCodeColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
                    }
                    else
                    {
                        // 部品グリッドの在庫情報をクリア
                        //gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.WarehouseColumn.ColumnName].Value = string.Empty;
                        //gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.ShelfColumn.ColumnName].Value = string.Empty;
                        gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.StockCntColumn.ColumnName].Value = 0;
                        gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.WarehouseCodeColumn.ColumnName].Value = string.Empty;
                    }
                    gridSubst.UpdateData();
                }
                # endregion
            }
        }
        /// <summary>
        /// 在庫グリッド・行ダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_DoubleClickRow( object sender, DoubleClickRowEventArgs e )
        {
            SetSelectStock( false );
        }
        /// <summary>
        /// 在庫グリッド・キーダウン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_KeyDown( object sender, KeyEventArgs e )
        {
            switch ( e.KeyCode )
            {
                case Keys.Enter:
                    SetSelectStock( true );
                    break;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD   
        #endregion

        /// <summary>
        /// 在庫グリッド選択処理（ユーザー選択→優先倉庫→先頭行の順で選択）
        /// </summary>
        private void SetStockGridSelect()
        {
            if (gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.WarehouseCodeColumn.ColumnName].Value.Equals(string.Empty) == false)
            {
                for (int i = 0; i < gridStock.Rows.Count; i++)
                {
                    if (gridStock.Rows[i].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value
                        .Equals(gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.WarehouseCodeColumn.ColumnName].Value))
                    {
                        gridStock.Rows[i].Activate();
                        gridStock.Rows[i].Selected = true;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                        SetSelectStock( false, true );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                        return;
                    }
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                // 該当なしの場合は先頭行にフォーカスのみセット
                if ( gridStock.Rows.Count > 0 )
                {
                    gridStock.Rows[0].Activate();
                    gridStock.Rows[0].Selected = true;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            else
            {
                // 在庫未選択(取寄扱い)ならば在庫行の選択解除
                foreach ( UltraGridRow row in gridStock.Rows )
                {
                    if ( row.Cells[_StockTable.SelImageColumn.ColumnName].Value != DBNull.Value )
                    {
                        row.Cells[_StockTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                        row.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
                    }
                }
                // 在庫を全て選択解除した後、フォーカスは先頭の在庫
                if ( gridStock.Rows.Count > 0 )
                {
                    gridStock.Rows[0].Activate();
                    gridStock.Rows[0].Selected = true;
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //if (_orgDataSet.ListPriorWarehouse != null)
            //{
            //    for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
            //    {
            //        // 2009.02.16 >>>
            //        //string warehouseCd = _orgDataSet.ListPriorWarehouse[i];
            //        string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
            //        // 2009.02.16 <<<
            //        for (int j = 0; j < gridStock.Rows.Count; j++)
            //        {
            //            if (gridStock.Rows[j].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value.Equals(warehouseCd))
            //            {
            //                gridStock.Rows[j].Activate();
            //                gridStock.Rows[j].Selected = true;
            //                return;
            //            }
            //        }
            //    }
            //}
            //if (gridStock.Rows.Count > 0)
            //{
            //    gridStock.Rows[0].Activate();
            //    gridStock.Rows[0].Selected = true;
            //    gridStock.Rows[0].Cells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
            //}
            //else
            //{
            //    gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.StockCntColumn.ColumnName].Value = 0;
            //    gridSubst.ActiveRow.Cells[_dsSubst.UsrSubstParts.WarehouseCodeColumn.ColumnName].Value = string.Empty;
            //    gridSubst.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
        }

        internal static class ColInfo
        {
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 20;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int spanX, int spanY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;
                Band.Columns[colname].RowLayoutColumnInfo.SpanX = spanX;
                Band.Columns[colname].RowLayoutColumnInfo.SpanY = spanY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 20;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            }
        }

        // --- ADD m.suzuki 2010/00/00 ---------->>>>>
        /// <summary>
        /// 在庫グリッド進入時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_Enter( object sender, EventArgs e )
        {
            if ( gridStock.Rows.Count == 0 )
            {
                // 強制的に部品グリッドに移動する。
                gridSubst.Focus();
            }
        }
        // --- ADD m.suzuki 2010/00/00 ----------<<<<<
    }
}