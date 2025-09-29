using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace SearchEstimate
{
    public partial class UriDenSim : Form
    {
        private CarSearchController _CarSearchController = new CarSearchController();
        private PartsSearchController _PartsSearchController = new PartsSearchController();
        private PMKEN01010E carInfo;
        private PartsInfoDataSet partsInfo;
        private Dictionary<int, BLGoodsCdUMnt> blList = new Dictionary<int, BLGoodsCdUMnt>();

        private DataSet1.DataTable1DataTable dt = new DataSet1.DataTable1DataTable();
        private DataSet1.JoinPartsDataTable joinDt = new DataSet1.JoinPartsDataTable();
        public UriDenSim()
        {
            InitializeComponent();
            BLGoodsCdAcs blAcs = new BLGoodsCdAcs();
            ArrayList retList;
            blAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            foreach (BLGoodsCdUMnt blinfo in retList)
            {
                blList.Add(blinfo.BLGoodsCode, blinfo);
            }
            //_PartsSearchController.BLGoodsCdUMntList = blList;
        }

        #region [車種処理]
        private void txtMakerCd_Leave(object sender, EventArgs e)
        {

        }

        private void txtModel_Leave(object sender, EventArgs e)
        {

        }

        private void txtModelSubCd_Leave(object sender, EventArgs e)
        {

        }
        #endregion

        #region [ 車両検索 ]

        private void txtRui1_Leave(object sender, EventArgs e)
        {
            int modelDesignationNo, categoryNo;
            if (int.TryParse(txtRui1.Text, out modelDesignationNo)
                && int.TryParse(txtRui2.Text, out categoryNo))
            {
                CarSearchCondition con = new CarSearchCondition();
                con.ModelDesignationNo = modelDesignationNo;
                con.CategoryNo = categoryNo;
                con.Type = CarSearchType.csCategory;
                CarSearch(con);
            }
        }

        private void txtRui2_Leave(object sender, EventArgs e)
        {
            int modelDesignationNo, categoryNo;
            if (int.TryParse(txtRui1.Text, out modelDesignationNo)
                && int.TryParse(txtRui2.Text, out categoryNo))
            {
                CarSearchCondition con = new CarSearchCondition();
                con.ModelDesignationNo = modelDesignationNo;
                con.CategoryNo = categoryNo;
                con.Type = CarSearchType.csCategory;
                CarSearch(con);
            }
        }

        private void txtEngine_Leave(object sender, EventArgs e)
        {
            if (txtEngine.Text != "")
            {
                CarSearchCondition con = new CarSearchCondition();
                con.EngineModel.FullModel = txtEngine.Text;
                con.Type = CarSearchType.csEngineModel;
                CarSearch(con);
            }
        }

        private void txtKatasiki_Leave(object sender, EventArgs e)
        {
            if (txtKatasiki.Text != "")
            {
                CarSearchCondition con = new CarSearchCondition();
                con.CarModel.FullModel = txtKatasiki.Text;
                con.Type = CarSearchType.csModel;
                CarSearch(con);
            }
        }

        private void txtPlate_Leave(object sender, EventArgs e)
        {
            if (txtPlate.Text != "")
            {
                CarSearchCondition con = new CarSearchCondition();
                con.ModelPlate = txtPlate.Text;
                con.Type = CarSearchType.csPlate;
                CarSearch(con);
            }
        }

        private void txtFrameNo_Leave(object sender, EventArgs e)
        {
            int frameNo;
            if (int.TryParse(txtFrameNo.Text, out frameNo) == false)
            {
                txtFrameNo.Clear();
                return;
            }
            if (carInfo == null)
            {
                return;
            }
            string filter = string.Format("{0}<={1} AND {2}>={3}",
                carInfo.PrdTypYearInfo.StProduceFrameNoColumn.ColumnName, frameNo,
                carInfo.PrdTypYearInfo.EdProduceFrameNoColumn.ColumnName, frameNo);
            PMKEN01010E.PrdTypYearInfoRow[] row =
                (PMKEN01010E.PrdTypYearInfoRow[])carInfo.PrdTypYearInfo.Select(filter);
            if (row.Length > 0)
            {
                int year = row[0].ProduceTypeOfYear / 100;
                int month = row[0].ProduceTypeOfYear % 100;
                tDateEdit_FirstEntryDate.SetDateTime(new DateTime(year, month, 1));
            }
            else
            {
                tDateEdit_FirstEntryDate.Clear();
            }
            //            int cnt = carInfo.PrdTypYearInfo.Count;
            //            for (int i = 0; i < cnt; i++)
            //            {
            //carInfo.PrdTypYearInfo[i].
            //            }

        }

        private void CarSearch(CarSearchCondition condition)
        {
            int makerCd, modelCd, modelSubCd;
            if (int.TryParse(txtMakerCd.Text, out makerCd))
            {
                condition.MakerCode = makerCd;
            }
            if (int.TryParse(txtModel.Text, out modelCd))
            {
                condition.ModelCode = modelCd;
            }
            if (int.TryParse(txtModelSubCd.Text, out modelSubCd))
            {
                condition.ModelSubCode = modelSubCd;
            }
            CarSearchResultReport ret;
            carInfo = new PMKEN01010E();
            ret = _CarSearchController.Search(condition, ref carInfo);
            if (ret == CarSearchResultReport.retFailed)
            {
                MessageBox.Show("検索結果 0件です");
                return;
            }
            else if (ret == CarSearchResultReport.retError)
            {
                MessageBox.Show("検索中エラーが発生しました");
                return;
            }
            if (ret == CarSearchResultReport.retMultipleCarKind)
            {
                if (SelectionCarKind.ShowDialog(carInfo.CarKindInfo, condition) == DialogResult.OK)
                {
                    ret = _CarSearchController.Search(condition, ref carInfo);
                }
                else
                {
                    return;
                }
            }
            if (ret == CarSearchResultReport.retMultipleCarModel)
            {
                if (SelectionCarModel.ShowDialog(carInfo) == DialogResult.OK)
                {
                    ret = _CarSearchController.Search(condition, ref carInfo);
                }
                else
                {
                    return;
                }
            }

            PMKEN01010E.CarModelUIRow datRow = carInfo.CarModelUIData[0];
            txtKatasiki.Text = datRow.FullModel;
            txtMakerCd.Text = datRow.MakerCode.ToString("d3");
            txtModel.Text = datRow.ModelCode.ToString("d3");
            if (datRow.ModelSubCode != 0)
            {
                txtModelSubCd.Text = datRow.ModelSubCode.ToString("d3");
            }
            if (datRow.IsStProduceFrameNoNull() == false && datRow.IsEdProduceFrameNoNull() == false &&
                (datRow.StProduceFrameNo != 0 || datRow.EdProduceFrameNo != 0))
            {
                txtSyadai.Text = datRow.StProduceFrameNo.ToString() + " - " + datRow.EdProduceFrameNo.ToString();
            }
            else
            {
                txtSyadai.Text = carInfo.PrdTypYearInfo.GetFrameNoRange();
            }
            if (datRow.IsStProduceTypeOfYearNull() == false && datRow.IsEdProduceTypeOfYearNull() == false)
            {
                txtNensiki.Text = datRow.StProduceTypeOfYear.ToString("####/##") + " - " + datRow.EdProduceTypeOfYear.ToString("####/##");
            }
            txtSyamei.Text = datRow.ModelFullName;
            this.Refresh();

            GridCarModel.BeginUpdate();

            GridCarModel.DataSource = carInfo.CarModelUIData;
            //dat.CarModelUIData[0].ProduceTypeOfYearInput = 200002;

            UltraGridBand Band = GridCarModel.DisplayLayout.Bands[0];

            Band.Columns[carInfo.CarModelUIData.MakerCodeColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.CarModelUIData.MakerFullNameColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.CarModelUIData.ModelCodeColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.CarModelUIData.ModelSubCodeColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.CarModelUIData.ModelFullNameColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.CarModelUIData.ProduceTypeOfYearInputColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.CarModelUIData.StProduceTypeOfYearColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.CarModelUIData.EdProduceTypeOfYearColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.CarModelUIData.StProduceFrameNoColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.CarModelUIData.EdProduceFrameNoColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.CarModelUIData.FullModelColumn.ColumnName].Hidden = true;
            // 2009.01.28 >>>
            //Band.Columns[carInfo.CarModelUIData.ProduceFrameNoInputColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.CarModelUIData.FrameNoColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.CarModelUIData.SearchFrameNoColumn.ColumnName].Hidden = true;
            // 2009.01.28 <<<
            Band.Columns[carInfo.CarModelUIData.CategoryNoColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.CarModelUIData.ModelDesignationNoColumn.ColumnName].Hidden = true;

            Band.Columns[carInfo.CarModelUIData.DoorCountColumn.ColumnName].Format = "#";

            GridCarModel.EndUpdate();
            this.Refresh();

            gridColor.BeginUpdate();
            carInfo.ColorCdInfo.ColorCodeColumn.ReadOnly = true;
            carInfo.ColorCdInfo.ColorName1Column.ReadOnly = true;
            gridColor.DataSource = carInfo.ColorCdInfo;
            gridColor.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            Band = gridColor.DisplayLayout.Bands[0];
            //Band.Columns[carInfo.ColorCdInfo.ColorCdDupDerivedNoColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.ColorCdInfo.MakerCodeColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.ColorCdInfo.ModelCodeColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.ColorCdInfo.ModelSubCodeColumn.ColumnName].Hidden = true;
            //Band.Columns[carInfo.ColorCdInfo.ProduceTypeOfYearCdColumn.ColumnName].Hidden = true;
            //Band.Columns[carInfo.ColorCdInfo.SystematicCodeColumn.ColumnName].Hidden = true;
            Band.UseRowLayout = true;

            System.Drawing.Size sizeCell = new Size();
            sizeCell.Height = 18;
            sizeCell.Width = 30;
            Band.Columns[carInfo.ColorCdInfo.ColorCodeColumn.ColumnName].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            Band.Columns[carInfo.ColorCdInfo.SelectionStateColumn.ColumnName].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            gridColor.EndUpdate();
            this.Refresh();

            gridTrim.BeginUpdate();
            carInfo.TrimCdInfo.TrimCodeColumn.ReadOnly = true;
            carInfo.TrimCdInfo.TrimNameColumn.ReadOnly = true;
            gridTrim.DataSource = carInfo.TrimCdInfo;
            gridTrim.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            Band = gridTrim.DisplayLayout.Bands[0];
            Band.Columns[carInfo.TrimCdInfo.MakerCodeColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.TrimCdInfo.ModelCodeColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.TrimCdInfo.ModelSubCodeColumn.ColumnName].Hidden = true;
            //Band.Columns[carInfo.TrimCdInfo.ProduceTypeOfYearCdColumn.ColumnName].Hidden = true;
            //Band.Columns[carInfo.TrimCdInfo.SystematicCodeColumn.ColumnName].Hidden = true;
            Band.UseRowLayout = true;
            Band.Columns[carInfo.TrimCdInfo.TrimCodeColumn.ColumnName].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            Band.Columns[carInfo.TrimCdInfo.SelectionStateColumn.ColumnName].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            gridTrim.EndUpdate();
            this.Refresh();

            Dictionary<string, Infragistics.Win.ValueList> lst = carInfo.CEqpDefDspInfo.GetEquipUIInfo();
            UltraGridBand band = gridSoubi.DisplayLayout.Bands[0];

            gridSoubi.BeginUpdate();
            foreach (string key in lst.Keys)
            {
                UltraGridRow row = band.AddNew();
                row.Cells[0].Value = key;
                //if (lst[key].ValueListItems.Count == 3 && lst[key].FindByDataValue("無し") != null
                //    && lst[key].FindByDataValue("有り") != null)
                //{
                //    row.Cells[1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                //    if (lst[key].SelectedItem != null && lst[key].SelectedItem.ToString() == "有り")
                //        row.Cells[1].Value = true;
                //    else
                //        row.Cells[1].Value = false;
                //}
                //else
                //{
                row.Cells[1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                row.Cells[1].ValueList = lst[key];
                if (lst[key].SelectedItem != null)
                {
                    row.Cells[1].Value = lst[key].SelectedItem.ToString();
                }
                //}
            }
            gridSoubi.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            if (gridSoubi.Rows.Count > 0)
                gridSoubi.Rows[0].Activate();
            gridSoubi.EndUpdate();
            this.Refresh();
            _PartsSearchController.CarInfo = carInfo;
            //txtRui1.Text = _CarSearchController.OwnerCarInfoClass.ModelDesignationNo.ToString();
            //txtRui2.Text = _CarSearchController.OwnerCarInfoClass.CategoryNo.ToString();

        }

        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMakerCd.Clear();
            txtModel.Clear();
            txtModelSubCd.Clear();
            txtNensiki.Clear();
            txtEngine.Clear();
            txtPlate.Clear();
            txtRui1.Clear();
            txtRui2.Clear();
            txtSyadai.Clear();
            txtSyamei.Clear();
            txtKatasiki.Clear();
            txtFrameNo.Clear();
            tDateEdit_FirstEntryDate.Clear();
            GridCarModel.DataSource = null;
            gridColor.DataSource = null;
            gridTrim.DataSource = null;
            ultraDataSource1.Rows.Clear();
            GridParts.DataSource = null;
            gridJoin.DataSource = null;
            txtPartNo.Clear();
            txtBLCode.Clear();
            txtPartsMakerCd.Clear();
        }

        #region [ ガイド ]

        private void btnBLGuide_Click(object sender, EventArgs e)
        {
            List<int> lstBlCd;
            DialogResult ret = SelectionOfrBL.ShowDialog(out lstBlCd, _PartsSearchController.BLInfo, blList, "1", 1);
            if (ret == DialogResult.OK)
            {
                for (int i = 0; i < lstBlCd.Count; i++)
                {
                    txtBLCode.Text = lstBlCd[i].ToString();
                    txtBLCode_Leave(this, new EventArgs());
                }
            }
            //else
            //{
            //    MessageBox.Show("BLガイドを表示できません。");
            //}
        }

        private void btn_TBO_Click(object sender, EventArgs e)
        {
            if (carInfo == null)
                return;
            PartsInfoDataSet partsInfo;
            int status = _PartsSearchController.GetTBOInfo(out partsInfo, LoginInfoAcquisition.EnterpriseCode);
            if (status == 0 && partsInfo.TBOInfo.Count > 0)
            {
                DialogResult retDialog = SelectionCarInfoJoinParts.ShowDialog(this, carInfo, partsInfo);
                if (retDialog == DialogResult.OK)
                {
                    SetPartsInfo();
                }
            }
            else
            {
                MessageBox.Show("TBO情報がありません。");
            }
        }

        #endregion

        private void txtBLCode_Leave(object sender, EventArgs e)
        {
            int blCode;
            if (carInfo == null)
                return;
            GridParts.DataSource = null;
            if (int.TryParse(txtBLCode.Text, out blCode))
            {
                //PartsInfoDataSet partsInfo;
                PartsSearchUIData _partsSearchUIData = new PartsSearchUIData();
                _partsSearchUIData.TbsPartsCode = blCode;
                _partsSearchUIData.SearchFlg = SearchFlag.NoPrimeBlSearchFlag;
                _partsSearchUIData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                int ret = _PartsSearchController.GetPartsInfoMain(carInfo, _partsSearchUIData, out partsInfo);

                if (ret == 4)
                {
                    MessageBox.Show("No Parts");
                    return;
                }
                if (ret != 0)
                {
                    MessageBox.Show("Error");
                    return;
                }

                if (partsInfo.UsrGoodsInfo.Count == 0)
                {
                    MessageBox.Show("No Parts");
                    return;
                }
                partsInfo.AcceptChanges();
                int flg = 1;
                if (chkShowUI.Checked)
                    flg = 0;
                DialogResult retDialog = UIDisplayControl.SearchEstimateBL(this, carInfo, partsInfo, flg);

                if (retDialog == DialogResult.OK)
                {
                    SetPartsInfo();
                }
            }
        }

        private void txtPartNo_Leave(object sender, EventArgs e)
        {
            if (txtPartNo.Text == string.Empty)
                return;

            GridParts.DataSource = null;
            PartsSearchUIData _partsSearchUIData = new PartsSearchUIData();
            string partsNo = txtPartNo.Text;
            if (partsNo.EndsWith("*"))
            {
                partsNo = partsNo.Substring(0, partsNo.Length - 1);
                if (partsNo.StartsWith("*"))
                {
                    partsNo = partsNo.Substring(1, partsNo.Length - 1);
                    _partsSearchUIData.SearchType = SearchType.FreeSearch;
                }
                else
                {
                    _partsSearchUIData.SearchType = SearchType.PrefixSearch;
                }
            }
            else if (partsNo.StartsWith("*"))
            {
                partsNo = partsNo.Substring(1, partsNo.Length - 1);
                _partsSearchUIData.SearchType = SearchType.SuffixSearch;
            }
            else
            {
                if (partsNo.Contains("-"))
                {
                    _partsSearchUIData.SearchType = SearchType.WholeWord;
                }
                else
                {
                    _partsSearchUIData.SearchType = SearchType.WholeWordWithNoHyphen;
                }
            }
            _partsSearchUIData.PartsNo = partsNo;
            int maker;
            if (int.TryParse(txtPartsMakerCd.Text, out maker))
                _partsSearchUIData.PartsMakerCode = maker;
            _partsSearchUIData.SearchFlg = SearchFlag.GoodsInfoOnly;// GoodsAndSetInfo;
            _partsSearchUIData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            int ret = _PartsSearchController.GetPartsInfoMain(carInfo, _partsSearchUIData, out partsInfo);

            if (ret == 4)
            {
                MessageBox.Show("No Parts");
                return;
            }
            if (ret != 0)
            {
                MessageBox.Show("Error");
                return;
            }

            if (partsInfo.UsrGoodsInfo.Count == 0)
            {
                MessageBox.Show("No Parts");
                return;
            }
            partsInfo.AcceptChanges();

            int flg = 1;
            if (chkShowUI.Checked)
                flg = 0;
            DialogResult retDialog = UIDisplayControl.SearchEstimatePNo(this, partsInfo, flg);

            if (retDialog == DialogResult.OK)
            {
                SetPartsInfo();
            }
        }

        /// <summary>純正部品情報をグリッドへセット</summary>
        private void SetPartsInfo()
        {
            ArrayList goodsList = partsInfo.GetGoodsList(true);
            List<GoodsUnitData> goodsList2 = partsInfo.GetGoodsList(0);
            List<GoodsUnitData> goodsList3 = partsInfo.GetGoodsList(1); // 結合先
            List<GoodsUnitData> goodsList4 = partsInfo.GetGoodsList(2); // セット子
            List<GoodsUnitData> goodsList5 = partsInfo.GetGoodsList(4); // 代替先

            dt.Clear();
            joinDt.Clear();
            List<GenuinePartsRet> ret = partsInfo.GetSelectedGenuineParts();
            for (int i = 0; i < ret.Count; i++)
            {
                DataSet1.DataTable1Row row = dt.NewDataTable1Row();

                row.BL = ret[i].BLGoodsCode;
                row.PartsNm = ret[i].GoodsName;
                row.MakerCd = ret[i].GoodsMakerCd;
                row.Maker = ret[i].GoodsMakerNm;
                row.PartsNo = ret[i].GoodsNo;
                row.CtlgPartsNo = ret[i].CtlgPartsNo;
                row.NewPartsNo = ret[i].NewPartsNo;
                row.JoinSrcPartsNo = ret[i].JoinSrcPartsNo;

                dt.AddDataTable1Row(row);
                SetJoinData(row.MakerCd, row.JoinSrcPartsNo, row.NewPartsNo);
            }
            GridParts.DataSource = dt;

            gridJoin.DataSource = joinDt.DefaultView;

            if (GridParts.Rows.Count > 0)
                GridParts.Rows[0].Selected = true;
        }

        private void SetJoinData(int makerCd, string ctlgPartsNo, string newPartsNo)
        {
            string filter = string.Format("({0}='{1}' OR {2}='{3}') AND {4}={5}",
                        partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, ctlgPartsNo,
                        partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, newPartsNo,
                        partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, makerCd);
            PartsInfoDataSet.UsrJoinPartsRow[] rows =
                (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(filter, partsInfo.UsrJoinParts.JoinDispOrderColumn.ColumnName);
            int cnt = rows.Length;
            for (int i = 0; i < cnt; i++)
            {
                DataSet1.JoinPartsRow rowJoin = joinDt.FindByJoinSourPartsNoJoinDestPartsNoJoinDestMakerCd(rows[i].JoinSrcPartsNoWithH, rows[i].JoinDestPartsNo, rows[i].JoinDestMakerCd);
                if (rowJoin == null)
                {
                    DataSet1.JoinPartsRow joinRow = joinDt.NewJoinPartsRow();

                    joinRow.JoinDestMakerCd = rows[i].JoinDestMakerCd;
                    joinRow.JoinDestPartsNo = rows[i].JoinDestPartsNo;
                    joinRow.JoinDispOrder = rows[i].JoinDispOrder;
                    joinRow.JoinQty = rows[i].JoinQty;
                    joinRow.JoinSourMaker = rows[i].JoinSourceMakerCode;
                    joinRow.JoinSourPartsNo = rows[i].JoinSrcPartsNoWithH;
                    joinRow.JoinSpecialNote = rows[i].JoinSpecialNote;

                    PartsInfoDataSet.UsrGoodsInfoRow joinPartsRow =
                        partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(joinRow.JoinDestMakerCd, joinRow.JoinDestPartsNo);
                    if (joinPartsRow != null)
                    {
                        joinRow.JoinDestMakerNm = joinPartsRow.GoodsMakerNm;
                        joinRow.Price = joinPartsRow.PriceTaxExc;
                        joinRow.PrimePartsName = joinPartsRow.GoodsName;

                        PartsInfoDataSet.JoinPartsRow[] ofrJoinPartsRow =
                            (PartsInfoDataSet.JoinPartsRow[])joinPartsRow.GetChildRows("UsrGoodsInfo_JoinParts");
                        if (ofrJoinPartsRow.Length > 0)
                        {
                            joinRow.PrmSetDtlNo2 = ofrJoinPartsRow[0].PrmSetDtlNo2;
                            joinRow.SetPartsFlg = ofrJoinPartsRow[0].SetPartsFlg;
                            if (ofrJoinPartsRow[0].SetPartsFlg != 0)
                                joinRow.Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                        }
                    }

                    if (SubstExists(joinRow.JoinDestPartsNo, joinRow.JoinDestMakerCd))
                        joinRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];

                    joinDt.AddJoinPartsRow(joinRow);
                }
                else
                {
                    if (rowJoin.JoinSourPartsNo == newPartsNo && rows[i].JoinSrcPartsNoWithH == ctlgPartsNo)
                    {
                        rowJoin.JoinSourPartsNo = ctlgPartsNo;
                    }
                }
            }
        }

        private bool SubstExists(string parts, int maker)
        {
            string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                partsInfo.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, parts,
                partsInfo.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, maker);
            if (partsInfo.UsrSubstParts.Select(rowFilter).Length > 0)
                return true;
            return false;
        }

        private void GridParts_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (GridParts.Selected.Rows.Count > 0)
            {
                int makerCd = (int)GridParts.Selected.Rows[0].Cells[dt.MakerCdColumn.ColumnName].Value;
                string partsNo = GridParts.Selected.Rows[0].Cells[dt.CtlgPartsNoColumn.ColumnName].Value.ToString();
                string ctlgPartsNo = partsNo;
                string newPartsNo = partsNo;

                PartsInfoDataSet.PartsInfoRow row = partsInfo.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(makerCd, partsNo);
                if (row != null)
                {
                    newPartsNo = row.NewPrtsNoWithHyphen;
                    ctlgPartsNo = row.ClgPrtsNoWithHyphen;
                }
                ctlgPartsNo = GridParts.Selected.Rows[0].Cells[dt.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                string filter = string.Format(" {0} = '{1}' OR {2} = '{3}'",
                     joinDt.JoinSourPartsNoColumn.ColumnName, newPartsNo, joinDt.JoinSourPartsNoColumn.ColumnName, ctlgPartsNo);
                joinDt.DefaultView.RowFilter = filter;

                List<GoodsUnitData> lst;
                PartsInfoDataSet.UsrJoinPartsRow[] usrJoinPartsRows = partsInfo.GetJoinDestParts(makerCd, ctlgPartsNo, newPartsNo, out lst);
                System.Diagnostics.Debug.WriteLine("リストカウント : " + lst.Count.ToString());
                System.Diagnostics.Debug.WriteLine("結合情報行数 : " + usrJoinPartsRows.Length.ToString());

            }
        }

        private void gridJoin_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (gridJoin.Selected.Rows.Count > 0)
            {
                int makerCd = (int)gridJoin.Selected.Rows[0].Cells[joinDt.JoinDestMakerCdColumn.ColumnName].Value;
                string partsNo = gridJoin.Selected.Rows[0].Cells[joinDt.JoinDestPartsNoColumn.ColumnName].Value.ToString();
                if (partsInfo.UsrSetParts.SetExist(makerCd, partsNo))
                {
                    btn_Set.Enabled = true;
                }
                else
                {
                    btn_Set.Enabled = false;
                }
            }
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            if (gridJoin.Selected.Rows.Count > 0)
            {
                //partsInfo.UsrGoodsInfo.ResetSelectionState();
                int makerCd = (int)gridJoin.Selected.Rows[0].Cells[joinDt.JoinDestMakerCdColumn.ColumnName].Value;
                string partsNo = gridJoin.Selected.Rows[0].Cells[joinDt.JoinDestPartsNoColumn.ColumnName].Value.ToString();
                //partsInfo.UsrGoodsInfo.RowToProcess = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                //SelectionFormSet frmSetParts = new SelectionFormSet(partsInfo);
                DialogResult retDialog = UIDisplayControl.SESetUI(this, partsInfo, makerCd, partsNo);
                if (retDialog == DialogResult.OK)
                {
                    PartsInfoDataSet.UsrGoodsInfoRow[] rowsSelected = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                    int cnt = rowsSelected.Length;
                    for (int i = 0; i < rowsSelected.Length; i++)
                    {
                        DataSet1.DataTable1Row row = dt.NewDataTable1Row();
                        row.BL = rowsSelected[i].BlGoodsCode;
                        row.PartsNo = rowsSelected[i].GoodsNo;
                        row.PartsNm = rowsSelected[i].GoodsName;
                        row.Maker = rowsSelected[i].GoodsMakerNm;
                        row.Price = rowsSelected[i].PriceTaxExc;
                        PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])rowsSelected[i].GetChildRows("UsrGoodsInfo_Stock");
                        for (int j = 0; j < stockRows.Length; j++)
                        {
                            if (stockRows[j].SelectionState)
                            {
                                row.ShelfNo = stockRows[j].WarehouseShelfNo;
                                row.WareHouse = stockRows[j].WarehouseName;
                                row.Cnt = stockRows[j].ShipmentPosCnt;
                                break;
                            }
                        }
                        PartsInfoDataSet.PartsInfoRow[] rowOrg = (PartsInfoDataSet.PartsInfoRow[])rowsSelected[i].GetChildRows("UsrGoodsInfo_PartsInfo");
                        for (int j = 0; j < rowOrg.Length; j++)
                        {
                            row.NewPartsNo = rowOrg[j].NewPrtsNoWithHyphen;
                            row.CtlgPartsNo = rowOrg[j].ClgPrtsNoWithHyphen;
                            System.Diagnostics.Debug.WriteLine(string.Format("[INDEX{0} : New{1} Ctlg{2}]", j, row.NewPartsNo, row.CtlgPartsNo));
                        }
                        dt.AddDataTable1Row(row);
                    }
                }
            }
        }

    }
}