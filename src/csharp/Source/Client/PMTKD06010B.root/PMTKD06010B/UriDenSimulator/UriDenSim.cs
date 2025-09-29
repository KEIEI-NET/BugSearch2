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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace UriDenSimulator
{
    public partial class UriDenSim : Form
    {
        private CarSearchController _CarSearchController = new CarSearchController();
        public UriDenSim()
        {
            InitializeComponent();
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
            PMKEN01010E dat = new PMKEN01010E();
            ret = _CarSearchController.Search(condition, ref dat);
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
                if (SelectionCarKind.ShowDialog(dat.CarKindInfo, condition) == DialogResult.OK)
                {
                    ret = _CarSearchController.Search(condition, ref dat);
                }
                else
                {
                    return; // TODO
                }
            }
            if (ret == CarSearchResultReport.retMultipleCarModel)
            {
                if (SelectionCarModel.ShowDialog(dat) == DialogResult.OK)
                {
                    ret = _CarSearchController.Search(condition, ref dat);
                }
                else
                {
                    return; // TODO
                }
            }

            ultraGrid1.DataSource = dat.CarModelUIData;
            //dat.CarModelUIData[0].ProduceTypeOfYearInput = 200002;

            UltraGridBand Band = ultraGrid1.DisplayLayout.Bands[0];

            Band.Columns[dat.CarModelUIData.MakerCodeColumn.ColumnName].Hidden = true;
            Band.Columns[dat.CarModelUIData.MakerFullNameColumn.ColumnName].Hidden = true;
            Band.Columns[dat.CarModelUIData.ModelCodeColumn.ColumnName].Hidden = true;
            Band.Columns[dat.CarModelUIData.ModelSubCodeColumn.ColumnName].Hidden = true;
            Band.Columns[dat.CarModelUIData.ModelFullNameColumn.ColumnName].Hidden = true;
            Band.Columns[dat.CarModelUIData.ProduceTypeOfYearInputColumn.ColumnName].Hidden = true;
            Band.Columns[dat.CarModelUIData.StProduceTypeOfYearColumn.ColumnName].Hidden = true;
            Band.Columns[dat.CarModelUIData.EdProduceTypeOfYearColumn.ColumnName].Hidden = true;
            Band.Columns[dat.CarModelUIData.StProduceFrameNoColumn.ColumnName].Hidden = true;
            Band.Columns[dat.CarModelUIData.EdProduceFrameNoColumn.ColumnName].Hidden = true;
            Band.Columns[dat.CarModelUIData.FullModelColumn.ColumnName].Hidden = true;
            //Band.Columns[dat.CarModelUIData.ProduceFrameNoInputColumn.ColumnName].Hidden = true;

            Band.Columns[dat.CarModelUIData.DoorCountColumn.ColumnName].Format = "#";
            PMKEN01010E.CarModelUIRow datRow = dat.CarModelUIData[0];
            txtKatasiki.Text = datRow.FullModel;
            txtMakerCd.Text = datRow.MakerCode.ToString("d3");
            txtModel.Text = datRow.ModelCode.ToString("d3");
            if (datRow.ModelSubCode != 0)
                txtModelSubCd.Text = datRow.ModelSubCode.ToString("d3");
            if (datRow.IsStProduceFrameNoNull() == false && datRow.IsEdProduceFrameNoNull() == false &&
                (datRow.StProduceFrameNo != 0 || datRow.EdProduceFrameNo != 0))
                txtSyadai.Text = datRow.StProduceFrameNo.ToString() + " - " + datRow.EdProduceFrameNo.ToString();
            if (datRow.IsStProduceTypeOfYearNull() == false && datRow.IsEdProduceTypeOfYearNull() == false)
                txtNensiki.Text = datRow.StProduceTypeOfYear.ToString("####/##") + " - " + datRow.EdProduceTypeOfYear.ToString("####/##");
            txtSyamei.Text = datRow.ModelFullName;

            gridColor.DataSource = dat.ColorCdInfo;
            gridTrim.DataSource = dat.TrimCdInfo;

            Dictionary<string, Infragistics.Win.ValueList> lst = dat.CEqpDefDspInfo.GetEquipUIInfo();
            UltraGridBand band = gridSoubi.DisplayLayout.Bands[0];

            gridSoubi.BeginUpdate();
            foreach (string key in lst.Keys)
            {
                UltraGridRow row = band.AddNew();
                row.Cells[0].Value = key;
                if (lst[key].ValueListItems.Count == 3 && lst[key].FindByDataValue("無し") != null
                    && lst[key].FindByDataValue("有り") != null)
                {
                    row.Cells[1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    row.Cells[1].Value = false;
                }
                else
                {
                    row.Cells[1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                    row.Cells[1].ValueList = lst[key];
                }
            }
            if (gridSoubi.Rows.Count > 0)
                gridSoubi.Rows[0].Activate();
            gridSoubi.EndUpdate();

            //txtRui1.Text = _CarSearchController.OwnerCarInfoClass.ModelDesignationNo.ToString();
            //txtRui2.Text = _CarSearchController.OwnerCarInfoClass.CategoryNo.ToString();

        }

    }
}