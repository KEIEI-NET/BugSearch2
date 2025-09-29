using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace UriDenSimulator
{
    public partial class UriDenSim : Form
    {
        #region [ private member ]
        private CarSearchController _CarSearchController;
        private PartsSearchController _PartsSearchController;
        private PMKEN01010E carInfo;
        private PartsInfoDataSet partsInfo;
        private Dictionary<int, BLGoodsCdUMnt> blList;
        private SalesSlip _salesSlip;
        private string _enterpriseCode;
        private CustomerInfoAcs _customerInfoAcs;
        private SupplierAcs _supplierAcs;
        private UnitPriceCalculation _unitPriceCalculation;
        /// <summary>メーカーデータ格納バッファ(KEY:メーカーコード, VALUE:メーカーマスタオブジェクト)</summary>
        private static Dictionary<int, MakerUMnt> _drMaker;
        /// <summary>優良設定情報格納バッファ(VALUE:優良設定情報オブジェクト)</summary>
        // 2009.02.12 >>>
        //private static Dictionary<PrmSettingKey, PrmSettingUWork> _drPrmSettingWork;
        private static List<PrmSettingUWork> _drPrmSettingWork;
        // 2009.02.12 <<<
        #endregion

        public UriDenSim()
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            System.Threading.Thread thread = new System.Threading.Thread(InitializeData);
            thread.Start();
            InitializeComponent();

            _CarSearchController = new CarSearchController();
            _PartsSearchController = new PartsSearchController();

            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _salesSlip = new SalesSlip();
            _customerInfoAcs = new CustomerInfoAcs();
            _supplierAcs = new SupplierAcs();
            _unitPriceCalculation = new UnitPriceCalculation();

            _salesSlip.CustomerCode = 1; // FOR TEST
            _salesSlip.CustRateGrpCode = 1;
            _salesSlip.ConsTaxRate = 5;
            _salesSlip.TotalAmountDispWayCd = 1;

            RdoSearchFlag.CheckedIndex = 2;
            cmbUserSubst.Value = 0;
            cmbClgSubst.Value = 0;
            cmbPrimeSubst.Value = 0;
            cmbUICon.Value = 0;
            cmbEnterCnt.Value = 0;
            cmbDispOrder.Value = 0;
            cmbGengo.Value = 0;
            cmbBL.Value = 0;

            _drMaker = new Dictionary<int, MakerUMnt>();
            CustomSerializeArrayList workList = new CustomSerializeArrayList();

            GoodsUCndtnWork goodsUCndtnWork = new GoodsUCndtnWork();
            goodsUCndtnWork.EnterpriseCode = _enterpriseCode;
            MakerUWork makerUWork = new MakerUWork();
            makerUWork.EnterpriseCode = _enterpriseCode;
            workList.Add(makerUWork);

            // 優良設定情報
            PrmSettingUWork prmSettingUWork = new PrmSettingUWork();
            prmSettingUWork.EnterpriseCode = _enterpriseCode;
            workList.Add(prmSettingUWork);

            IUsrJoinPartsSearchDB _iGoodsURelationDataDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();
            object retObj = workList;
            _iGoodsURelationDataDB.Search(ref retObj, goodsUCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
            workList = retObj as CustomSerializeArrayList;
            if (workList[0] is ArrayList)
            {
                foreach (ArrayList arList in workList)
                {
                    if (arList == null || arList.Count == 0)
                        continue;
                    // メーカーか
                    if (arList[0] is MakerUWork)
                    {
                        foreach (MakerUWork work in arList)
                        {
                            MakerUMnt makerUMnt = new MakerUMnt();
                            makerUMnt.GoodsMakerCd = work.GoodsMakerCd;
                            makerUMnt.MakerName = work.MakerName;
                            makerUMnt.MakerKanaName = work.MakerKanaName;
                            makerUMnt.DivisionName = "ユーザー";

                            if (!_drMaker.ContainsKey(makerUMnt.GoodsMakerCd))
                            {
                                _drMaker.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                            }
                            else
                            {
                                _drMaker[makerUMnt.GoodsMakerCd] = makerUMnt;
                            }
                        }
                    }

                    // 優良設定か
                    if (arList[0] is PrmSettingUWork)
                    {
                        // 2009.02.12 >>>
                        //_drPrmSettingWork = new Dictionary<PrmSettingKey, PrmSettingUWork>();
                        //foreach (PrmSettingUWork prmSetting in arList)
                        //{
                        //    PrmSettingKey prmKey = new PrmSettingKey(prmSetting.SectionCode.Trim(), prmSetting.GoodsMGroup, prmSetting.TbsPartsCode, prmSetting.PartsMakerCd);
                        //    if (_drPrmSettingWork.ContainsKey(prmKey))
                        //    {
                        //        _drPrmSettingWork[prmKey] = prmSetting;
                        //    }
                        //    else
                        //    {
                        //        _drPrmSettingWork.Add(prmKey, prmSetting);
                        //    }
                        //}
                        _drPrmSettingWork = new List<PrmSettingUWork>();
                        foreach (PrmSettingUWork prmSetting in arList)
                        {
                            _drPrmSettingWork.Add(prmSetting);
                        }

                        // 2009.02.12 <<<
                    }

                }
            }
            _PartsSearchController.PartsMakerList = _drMaker;
            _PartsSearchController.BLGoodsCdUMntList = blList;

        }

        private void InitializeData()
        {
            try
            {
                blList = new Dictionary<int, BLGoodsCdUMnt>();

                BLGoodsCdAcs blAcs = new BLGoodsCdAcs();
                ArrayList retList;
                blAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                foreach (BLGoodsCdUMnt blinfo in retList)
                {
                    blList.Add(blinfo.BLGoodsCode, blinfo);
                }
            }
            catch { }
        }

        #region [ 車種処理 ]
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
            condition.EraNameDispCd1 = Convert.ToInt32(cmbGengo.Value);
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
                    Refresh();
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
                    Refresh();
                    ret = _CarSearchController.Search(condition, ref carInfo);
                }
                else
                {
                    return;
                }
            }

            System.Threading.Thread thread = new System.Threading.Thread(SetOfrBl);
            thread.Start();

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
            Band.Columns[carInfo.CarModelUIData.SearchFrameNoColumn.ColumnName].Hidden = true;
            Band.Columns[carInfo.CarModelUIData.FrameNoColumn.ColumnName].Hidden = true;
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
                #region [ To Delete ]
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
                #endregion
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

            if (carInfo.CarModelUIData.Count > 0)
            {
                // 2009.01.28 >>>
                //if (carInfo.CarModelUIData[0].ProduceFrameNoInput > 0)
                //{
                //    txtFrameNo.Text = carInfo.CarModelUIData[0].ProduceFrameNoInput.ToString();
                //}
                if (carInfo.CarModelUIData[0].SearchFrameNo > 0)
                {
                    txtFrameNo.Text = carInfo.CarModelUIData[0].FrameNo;
                }
                // 2009.01.28 <<<
                if (carInfo.CarModelUIData[0].ProduceTypeOfYearInput > 0)
                {
                    int year = carInfo.CarModelUIData[0].ProduceTypeOfYearInput / 100;
                    int month = carInfo.CarModelUIData[0].ProduceTypeOfYearInput % 100;
                    if (year > 0 && month > 0 && month < 13)
                    {
                        tDateEdit_FirstEntryDate.SetDateTime(new DateTime(year, month, 1));
                    }
                }
            }
            //_PartsSearchController.CarInfo = carInfo;

            //txtRui1.Text = _CarSearchController.OwnerCarInfoClass.ModelDesignationNo.ToString();
            //txtRui2.Text = _CarSearchController.OwnerCarInfoClass.CategoryNo.ToString();

            // FOR TEST
            //test();

            // TEST
            //int[] fullModelFixedNo = _CarSearchController.GetFullModelFixedNoArray(carInfo.CarModelInfo);
            //PMKEN01010E newData = new PMKEN01010E();

            //_CarSearchController.SearchByFullModelFixedNo(fullModelFixedNo, condition.ModelDesignationNo, condition.CategoryNo, ref newData);
            //while (thread.ThreadState == System.Threading.ThreadState.Running)
            //    System.Threading.Thread.Sleep(10);
        }

        private void SetOfrBl()
        {
            _PartsSearchController.CarInfo = carInfo;
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
            txtPartNo.Clear();
            txtBLCode.Clear();
            txtGoodsSearch.Clear();
            txtPartsMakerCd.Clear();
        }

        #region [ ガイド ]

        private void btnBLGuide_Click(object sender, EventArgs e)
        {
            List<int> lstBlCd;

            DialogResult ret = SelectionOfrBL.ShowDialog(out lstBlCd, _PartsSearchController.BLInfo, blList, "23", 1);

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

            //PartsInfoDataSet partsInfo;
            string sectionCode = "23";

            int status = _PartsSearchController.GetTBOInfo(out partsInfo, LoginInfoAcquisition.EnterpriseCode, sectionCode, _drPrmSettingWork);
            if (status == 0 && partsInfo.TBOInfo.Count > 0)
            {
                //テスト用優先倉庫設定
                List<string> lst = new List<string>();
                lst.Add("0003");
                lst.Add("2001");
                lst.Add("0004");
                partsInfo.ListPriorWarehouse = lst;
                partsInfo.SearchCondition = new PartsSearchUIData();
                SearchCntSetWork SearchCntSetWork = new SearchCntSetWork();
                SearchCntSetWork.EraNameDispCd1 = Convert.ToInt32(cmbGengo.Value);
                SearchCntSetWork.SearchUICntDivCd = Convert.ToInt32(cmbUICon.Value);
                SearchCntSetWork.SubstCondDivCd = Convert.ToInt32(cmbClgSubst.Value);
                SearchCntSetWork.PrmSubstCondDivCd = Convert.ToInt32(cmbPrimeSubst.Value);
                SearchCntSetWork.SubstApplyDivCd = Convert.ToInt32(cmbUserSubst.Value);
                SearchCntSetWork.EnterProcDivCd = Convert.ToInt32(cmbEnterCnt.Value);
                SearchCntSetWork.JoinInitDispDiv = Convert.ToInt32(cmbDispOrder.Value);
                SearchCntSetWork.TotalAmountDispWayCd = Convert.ToInt32(cmbBL.Value);

                partsInfo.SearchCondition.SearchCntSetWork = SearchCntSetWork;

                DialogResult retDialog = SelectionCarInfoJoinParts.ShowDialog(this, carInfo, partsInfo);
                if (retDialog == DialogResult.OK)
                {
                    SetPartsInfo(true);
                }
            }
            else
            {
                MessageBox.Show("TBO情報がありません。");
            }
        }

        #endregion

        #region [ 部品検索 ]

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
                if (cmbBL.Value.Equals(0)) // ＢＬ検索が純正優先か
                    _partsSearchUIData.SearchFlg = SearchFlag.BlSearch;
                else // ＢＬ検索が優良優先か
                    _partsSearchUIData.SearchFlg = SearchFlag.PrimeBlSearch;
                _partsSearchUIData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                _partsSearchUIData.PrmSettingWork = _drPrmSettingWork;
                _partsSearchUIData.SectionCode = "23";

                SearchCntSetWork SearchCntSetWork = new SearchCntSetWork();
                SearchCntSetWork.EraNameDispCd1 = Convert.ToInt32(cmbGengo.Value);
                SearchCntSetWork.SearchUICntDivCd = Convert.ToInt32(cmbUICon.Value);
                SearchCntSetWork.SubstCondDivCd = Convert.ToInt32(cmbClgSubst.Value);
                SearchCntSetWork.PrmSubstCondDivCd = Convert.ToInt32(cmbPrimeSubst.Value);
                SearchCntSetWork.SubstApplyDivCd = Convert.ToInt32(cmbUserSubst.Value);
                SearchCntSetWork.EnterProcDivCd = Convert.ToInt32(cmbEnterCnt.Value);
                SearchCntSetWork.JoinInitDispDiv = Convert.ToInt32(cmbDispOrder.Value);
                SearchCntSetWork.TotalAmountDispWayCd = Convert.ToInt32(cmbBL.Value);
                _partsSearchUIData.SearchCntSetWork = SearchCntSetWork;


                if (tDateEdit_FirstEntryDate.GetDateYear() != 0)
                {
                    carInfo.CarModelUIData[0].ProduceTypeOfYearInput = tDateEdit_FirstEntryDate.GetDateYear() * 100 + tDateEdit_FirstEntryDate.GetDateMonth();
                }
                else
                {
                    carInfo.CarModelUIData[0].ProduceTypeOfYearInput = 0;
                }
                if (txtFrameNo.Text != string.Empty)
                {
                    // 2009.01.28 >>>
                    //carInfo.CarModelUIData[0].ProduceFrameNoInput = Convert.ToInt32(txtFrameNo.Text);
                    carInfo.CarModelUIData[0].FrameNo = txtFrameNo.Text;
                    carInfo.CarModelUIData[0].SearchFrameNo = Convert.ToInt32(txtFrameNo.Text);
                    // 2009.01.28 <<<
                }
                else
                {
                    // 2009.01.28 >>>
                    //carInfo.CarModelUIData[0].ProduceFrameNoInput = 0;
                    carInfo.CarModelUIData[0].FrameNo= string.Empty;
                    carInfo.CarModelUIData[0].SearchFrameNo = 0;
                    // 2009.01.28 <<<
                }
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

                // 仮処理 ↓↓↓↓↓
                int cnt = partsInfo.UsrGoodsInfo.Count;
                int priceApplyDate = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
                for (int i = 0; i < cnt; i++)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow rowPrice =
                        partsInfo.UsrGoodsPrice.FindApplyPrice(partsInfo.UsrGoodsInfo[i].GoodsMakerCd, partsInfo.UsrGoodsInfo[i].GoodsNo, priceApplyDate);
                    if (rowPrice != null)
                    {
                        if (partsInfo.UsrGoodsInfo[i].TaxationDivCd == 2) // 内税
                        {
                            partsInfo.UsrGoodsInfo[i].PriceTaxExc = rowPrice.ListPrice * 100.0 / 105.0;
                            partsInfo.UsrGoodsInfo[i].SalesUnitPriceTaxExc = rowPrice.ListPrice * 100.0 / 105.0;
                            partsInfo.UsrGoodsInfo[i].PriceTaxInc = rowPrice.ListPrice;
                            partsInfo.UsrGoodsInfo[i].SalesUnitPriceTaxInc = rowPrice.ListPrice;
                        }
                        else if (partsInfo.UsrGoodsInfo[i].TaxationDivCd == 0)  // 外税
                        {
                            partsInfo.UsrGoodsInfo[i].PriceTaxExc = rowPrice.ListPrice;
                            partsInfo.UsrGoodsInfo[i].SalesUnitPriceTaxExc = rowPrice.ListPrice;
                            partsInfo.UsrGoodsInfo[i].PriceTaxInc = rowPrice.ListPrice * 1.05; // 仮に５％
                            partsInfo.UsrGoodsInfo[i].SalesUnitPriceTaxInc = rowPrice.ListPrice * 1.05;
                        }
                        else
                        {
                            partsInfo.UsrGoodsInfo[i].PriceTaxExc = rowPrice.ListPrice;
                            partsInfo.UsrGoodsInfo[i].SalesUnitPriceTaxExc = rowPrice.ListPrice;
                            partsInfo.UsrGoodsInfo[i].PriceTaxInc = rowPrice.ListPrice;
                            partsInfo.UsrGoodsInfo[i].SalesUnitPriceTaxInc = rowPrice.ListPrice;
                        }
                    }
                }
                partsInfo.AcceptChanges();

                //テスト用優先倉庫設定
                List<string> lst = new List<string>();
                lst.Add("0003");
                lst.Add("0007");
                lst.Add("0004");
                partsInfo.ListPriorWarehouse = lst;
                //partsInfo.PrmSettingWork = _drPrmSettingWork;
                //partsInfo.SectionCode = "23    ";

                // 仮処理 ↑↑↑↑↑
                //List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfo.GetGoodsList(false).ToArray(typeof(GoodsUnitData)));
                //List<UnitPriceCalcRet> lstUnitPrice = CalclationUnitPrice(goodsUnitDataList);
                //partsInfo.SetUnitPriceInfo(lstUnitPrice);//, DateTime.Now);

                DialogResult retDialog = UIDisplayControl.ProcessPartsSearch(this, carInfo, partsInfo);

                if (retDialog == DialogResult.OK)
                {
                    SetPartsInfo(true);
                }
            }
            txtBLCode.Clear();
        }

        private void txtPartNo_Leave(object sender, EventArgs e)
        {
            if (txtPartNo.Text == string.Empty)
                return;

            GridParts.DataSource = null;
            PartsSearchUIData _partsSearchUIData = new PartsSearchUIData();
            SearchCntSetWork SearchCntSetWork = new SearchCntSetWork();
            SearchCntSetWork.EraNameDispCd1 = Convert.ToInt32(cmbGengo.Value);

            SearchCntSetWork.SearchUICntDivCd = Convert.ToInt32(cmbUICon.Value);
            SearchCntSetWork.SubstCondDivCd = Convert.ToInt32(cmbClgSubst.Value);
            SearchCntSetWork.PrmSubstCondDivCd = Convert.ToInt32(cmbPrimeSubst.Value);
            SearchCntSetWork.SubstApplyDivCd = Convert.ToInt32(cmbUserSubst.Value);
            SearchCntSetWork.EnterProcDivCd = Convert.ToInt32(cmbEnterCnt.Value);
            SearchCntSetWork.JoinInitDispDiv = Convert.ToInt32(cmbDispOrder.Value);

            _partsSearchUIData.SearchCntSetWork = SearchCntSetWork;
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
            switch (RdoSearchFlag.CheckedIndex)
            {
                case 0:
                    _partsSearchUIData.SearchFlg = SearchFlag.GoodsInfoOnly;
                    break;
                case 1:
                    _partsSearchUIData.SearchFlg = SearchFlag.GoodsAndSetInfo;
                    break;
                case 2:
                    _partsSearchUIData.SearchFlg = SearchFlag.PartsNoJoinSearch;
                    break;
            }
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

            // 仮処理 ↓↓↓↓↓
            int cnt = partsInfo.UsrGoodsInfo.Count;
            int priceApplyDate = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.UsrGoodsPriceRow rowPrice =
                    partsInfo.UsrGoodsPrice.FindApplyPrice(partsInfo.UsrGoodsInfo[i].GoodsMakerCd, partsInfo.UsrGoodsInfo[i].GoodsNo, priceApplyDate);
                if (rowPrice != null)
                {
                    partsInfo.UsrGoodsInfo[i].PriceTaxExc = rowPrice.ListPrice;
                    partsInfo.UsrGoodsInfo[i].SalesUnitPriceTaxExc = rowPrice.ListPrice;
                }
            }
            partsInfo.AcceptChanges();

            //テスト用優先倉庫設定
            List<string> lst = new List<string>();
            lst.Add("0003");
            lst.Add("0001");
            lst.Add("0005");
            partsInfo.ListPriorWarehouse = lst;

            // 仮処理 ↑↑↑↑↑
            //List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfo.GetGoodsList(false).ToArray(typeof(GoodsUnitData)));
            //List<UnitPriceCalcRet> lstUnitPrice = CalclationUnitPrice(goodsUnitDataList);
            //partsInfo.SetUnitPriceInfo(lstUnitPrice);//, DateTime.Now);

            DialogResult retDialog = UIDisplayControl.ProcessPartsSearch(this, null, partsInfo);

            if (retDialog == DialogResult.OK)
            {
                SetPartsInfo(true);
                //List<GoodsUnitData> goodsList = partsInfo.GetGoodsList(4, partsInfo.UsrGoodsInfo[0].GoodsMakerCd, partsInfo.UsrGoodsInfo[0].GoodsNo); // 結合先
            }
            txtPartNo.Clear();
        }


        private void txtGoodsSearch_Leave(object sender, EventArgs e)
        {
            if (txtGoodsSearch.Text == string.Empty)
                return;

            GridParts.DataSource = null;
            PartsSearchUIData _partsSearchUIData = new PartsSearchUIData();
            _partsSearchUIData.PrmSettingWork = _drPrmSettingWork;
            _partsSearchUIData.SectionCode = "23";
            _partsSearchUIData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            int maker;
            int.TryParse(txtPartsMakerCd.Text, out maker);
            string partsNo = txtGoodsSearch.Text;

            ArrayList lstSrchCond = new ArrayList();
            SrchCond con = new SrchCond();
            con.makerCd = maker;
            con.partsNo = partsNo;
            lstSrchCond.Add(con);

            con = new SrchCond();
            con.makerCd = 1003;
            con.partsNo = "NN1065";
            lstSrchCond.Add(con);

            con = new SrchCond();
            con.makerCd = 1003;
            con.partsNo = "NN1061";
            lstSrchCond.Add(con);

            con = new SrchCond();
            con.makerCd = 1;
            con.partsNo = "04000-11130";
            lstSrchCond.Add(con);

            con = new SrchCond();
            con.makerCd = 1;
            con.partsNo = "90915-10003";
            lstSrchCond.Add(con);

            con = new SrchCond();
            con.makerCd = 1;
            con.partsNo = "ddd2";
            lstSrchCond.Add(con);

            int ret = (int)_PartsSearchController.PrtNoListSearch(_partsSearchUIData, lstSrchCond, out partsInfo);


            //int ret = (int)_PartsSearchController.GetJoinSrcParts(LoginInfoAcquisition.EnterpriseCode, maker, partsNo, out partsInfo);

            //if (ret == 4)
            //{
            //    MessageBox.Show("No Parts");
            //    return;
            //}
            //if (ret != 0)
            //{
            //    MessageBox.Show("Error");
            //    return;
            //}

            //#region [テスト用]仮価格設定処理
            //int cnt = partsInfo.UsrGoodsInfo.Count;
            ////int today = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
            //for (int i = 0; i < cnt; i++)
            //{
            //    PartsInfoDataSet.UsrGoodsPriceRow[] priceInfoRow =
            //        (PartsInfoDataSet.UsrGoodsPriceRow[])partsInfo.UsrGoodsInfo[i].GetChildRows(partsInfo.Relations["UsrGoodsInfo_UsrGoodsPrice"]);
            //    int pricecnt = priceInfoRow.Length;
            //    for (int j = 0; j < pricecnt; j++)
            //    {
            //        if (priceInfoRow[j].PriceStartDate < DateTime.Now)
            //        {
            //            partsInfo.UsrGoodsInfo[i].PriceTaxExc = priceInfoRow[j].ListPrice;
            //            break;
            //        }
            //    }
            //}
            //#endregion

            ////List<int> lstMaker = null;
            ////lstMaker = new List<int>();
            ////lstMaker.Add(1);
            ////lstMaker.Add(5);

            SetPartsInfo(false);

            txtGoodsSearch.Clear();
        }

        //private void txtGoodsSearch_Leave(object sender, EventArgs e)
        //{
        //    if (txtGoodsSearch.Text == string.Empty)
        //        return;

        //    GridParts.DataSource = null;
        //    PartsSearchUIData _partsSearchUIData = new PartsSearchUIData();

        //    int maker;
        //    if (int.TryParse(txtPartsMakerCd.Text, out maker))
        //        _partsSearchUIData.PartsMakerCode = maker;
        //    string partsNo = txtGoodsSearch.Text;
        //    if (partsNo.EndsWith("*"))
        //    {
        //        partsNo = partsNo.Substring(0, partsNo.Length - 1);
        //        if (partsNo.StartsWith("*"))
        //        {
        //            partsNo = partsNo.Substring(1, partsNo.Length - 1);
        //            _partsSearchUIData.SearchType = SearchType.FreeSearch;
        //        }
        //        else
        //        {
        //            _partsSearchUIData.SearchType = SearchType.PrefixSearch;
        //        }
        //    }
        //    else if (partsNo.StartsWith("*"))
        //    {
        //        partsNo = partsNo.Substring(1, partsNo.Length - 1);
        //        _partsSearchUIData.SearchType = SearchType.SuffixSearch;
        //    }
        //    else
        //    {
        //        if (partsNo.Contains("-"))
        //        {
        //            _partsSearchUIData.SearchType = SearchType.WholeWord;
        //        }
        //        else
        //        {
        //            _partsSearchUIData.SearchType = SearchType.WholeWordWithNoHyphen;
        //        }
        //    }
        //    _partsSearchUIData.PartsNo = partsNo;
        //    _partsSearchUIData.SearchFlg = SearchFlag.GoodsAndSetInfo;
        //    _partsSearchUIData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        //    int ret = (int)_PartsSearchController.GetPartsInfoMain(null, _partsSearchUIData, out partsInfo);

        //    if (ret == 4)
        //    {
        //        MessageBox.Show("No Parts");
        //        return;
        //    }
        //    if (ret != 0)
        //    {
        //        MessageBox.Show("Error");
        //        return;
        //    }

        //    #region [テスト用]仮価格設定処理
        //    int cnt = partsInfo.UsrGoodsInfo.Count;
        //    //int today = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
        //    for (int i = 0; i < cnt; i++)
        //    {
        //        PartsInfoDataSet.UsrGoodsPriceRow[] priceInfoRow =
        //            (PartsInfoDataSet.UsrGoodsPriceRow[])partsInfo.UsrGoodsInfo[i].GetChildRows(partsInfo.Relations["UsrGoodsInfo_UsrGoodsPrice"]);
        //        int pricecnt = priceInfoRow.Length;
        //        for (int j = 0; j < pricecnt; j++)
        //        {
        //            if (priceInfoRow[j].PriceStartDate < DateTime.Now)
        //            {
        //                partsInfo.UsrGoodsInfo[i].PriceTaxExc = priceInfoRow[j].ListPrice;
        //                break;
        //            }
        //        }
        //    }
        //    #endregion
        //    ArrayList lst = partsInfo.GetGoodsList(false);

        //    PartsInfoDataSet partsInfo2 = new PartsInfoDataSet();
        //    partsInfo2.SetGoodsListToDataSet(lst);

        //    partsInfo2.PartsInfo.DefaultView.RowFilter = string.Empty;
        //    partsInfo2.JoinParts.DefaultView.RowFilter = string.Empty;
        //    partsInfo2.UsrGoodsInfo.DefaultView.RowFilter = string.Empty;

        //    DialogResult retDialog = DialogResult.OK;
        //    List<int> lstMaker = null;
        //    //lstMaker = new List<int>();
        //    //lstMaker.Add(1);
        //    //lstMaker.Add(5);

        //    retDialog = SelectionSamePartsNo.ShowDialog(partsInfo, 3, lstMaker);

        //    if (retDialog == DialogResult.OK)
        //    {
        //        SetPartsInfo();
        //    }
        //    txtGoodsSearch.Clear();
        //}

        private void SetPartsInfo(bool flg)
        {
            ArrayList goodsList = partsInfo.GetGoodsList(flg, 1);
            //List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])goodsList.ToArray(typeof(GoodsUnitData)));
            //List<UnitPriceCalcRet> lstUnitPrice = CalclationUnitPrice(goodsUnitDataList);
            //partsInfo.SetUnitPriceInfo(lstUnitPrice, DateTime.Now);
            //List<GoodsUnitData> goodsList2 = partsInfo.GetGoodsList(0);
            //List<GoodsUnitData> goodsList3 = partsInfo.GetGoodsList(1); // 結合先
            //List<GoodsUnitData> goodsList4 = partsInfo.GetGoodsList(2); // セット子
            //List<GoodsUnitData> goodsList5 = partsInfo.GetGoodsList(4); // 代替先
            //List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfo.GetGoodsList(true).ToArray(typeof(GoodsUnitData)));
            DataSet1.DataTable1DataTable dt = new DataSet1.DataTable1DataTable();
            string filter = string.Format("{0} = True", partsInfo.UsrGoodsInfo.SelectionStateColumn.ColumnName);
            PartsInfoDataSet.UsrGoodsInfoRow[] usrRows = (PartsInfoDataSet.UsrGoodsInfoRow[])partsInfo.UsrGoodsInfo.Select(filter);

            //for (int i = 0; i < usrRows.Length; i++)
            foreach (GoodsUnitData u in goodsList)
            {
                DataSet1.DataTable1Row row = dt.NewDataTable1Row();
                row.BL = u.BLGoodsCode; //usrRows[i].BlGoodsCode;
                row.PartsNo = u.GoodsNo; //usrRows[i].GoodsNo;
                row.PartsNm = u.GoodsName; //usrRows[i].GoodsName;
                row.Maker = u.MakerName; //usrRows[i].GoodsMakerNm;
                row.MakerCd = u.GoodsMakerCd; //usrRows[i].GoodsMakerCd;
                if (u.GoodsPriceList.Count > 0)
                    row.Price = u.GoodsPriceList[0].ListPrice; ;  //usrRows[i].Price;
                switch (u.GoodsKindResolved)
                {
                    case (int)GoodsKind.Join:
                        row.QTY = u.JoinQty;
                        break;
                    case (int)GoodsKind.Set:
                        row.QTY = u.SetQty;
                        break;
                    case (int)GoodsKind.Subst:
                    case (int)GoodsKind.SubstPlrl:
                    case (int)GoodsKind.Parent:
                        row.QTY = u.PartsQty;
                        break;
                }
                for (int i = 0; i < partsInfo.Stock.Count; i++)
                {
                    if (partsInfo.Stock[i].WarehouseCode == u.SelectedWarehouseCode
                            && partsInfo.Stock[i].GoodsMakerCd == u.GoodsMakerCd
                            && partsInfo.Stock[i].GoodsNo == u.GoodsNo)
                    {
                        row.ShelfNo = partsInfo.Stock[i].WarehouseShelfNo;
                        row.WareHouse = partsInfo.Stock[i].WarehouseName;
                        row.Cnt = partsInfo.Stock[i].ShipmentPosCnt;
                    }
                }
                //PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])usrRows[i].GetChildRows("UsrGoodsInfo_Stock");
                //for (int j = 0; j < stockRows.Length; j++)
                //{
                //    if (stockRows[j].SelectionState)
                //    {
                //        row.ShelfNo = stockRows[j].WarehouseShelfNo;
                //        row.WareHouse = stockRows[j].WarehouseName;
                //        row.Cnt = stockRows[j].ShipmentPosCnt;
                //        break;
                //    }
                //}
                dt.AddDataTable1Row(row);
            }
            GridParts.DataSource = dt;
        }

        #endregion

        private void test()
        {
            string filter = "SelectionState = True";// string.Format("");
            PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])carInfo.CEqpDefDspInfo.Select(filter);

            //バイナリ化
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            byte[] byteArray = null;
            ms.Write(BitConverter.GetBytes(rows.Length), 0, sizeof(int));
            foreach (PMKEN01010E.CEqpDefDspInfoRow row in rows)
            {
                ms.Write(BitConverter.GetBytes(row.EquipmentCode), 0, sizeof(int));
                ms.Write(BitConverter.GetBytes(row.EquipmentDispOrder), 0, sizeof(int));
                ms.Write(BitConverter.GetBytes(row.EquipmentGenreCd), 0, sizeof(int));
                byteArray = Encoding.Default.GetBytes(row.EquipmentGenreNm);
                ms.Write(BitConverter.GetBytes(byteArray.Length), 0, sizeof(int));
                ms.Write(byteArray, 0, byteArray.Length);
                ms.Write(BitConverter.GetBytes(row.EquipmentIconCode), 0, sizeof(int));
                byteArray = Encoding.Default.GetBytes(row.EquipmentName);
                ms.Write(BitConverter.GetBytes(byteArray.Length), 0, sizeof(int));
                ms.Write(byteArray, 0, byteArray.Length);
                byteArray = Encoding.Default.GetBytes(row.EquipmentShortName);
                ms.Write(BitConverter.GetBytes(byteArray.Length), 0, sizeof(int));
                ms.Write(byteArray, 0, byteArray.Length);
                ms.Write(BitConverter.GetBytes(row.MakerCode), 0, sizeof(int));
                ms.Write(BitConverter.GetBytes(row.ModelCode), 0, sizeof(int));
                ms.Write(BitConverter.GetBytes(row.ModelSubCode), 0, sizeof(int));
                ms.Write(BitConverter.GetBytes(row.SelectionState), 0, sizeof(bool));
                ms.Write(BitConverter.GetBytes(row.SystematicCode), 0, sizeof(int));
            }
            byte[] verbinary = ms.ToArray();
            ms.Close();

            //テストなのでそのまま先ほどのbyte[]変数をつかっちゃう。
            int idx = 0;
            int strLen = 0;
            int rowCount = BitConverter.ToInt32(verbinary, idx);//verbinary.Length / sizeof(PMKEN01010E.CEqpDefDspInfoRow);
            idx += sizeof(int);
            PMKEN01010E.CEqpDefDspInfoDataTable dbData = new PMKEN01010E.CEqpDefDspInfoDataTable();
            for (int i = 0; i < rowCount; i++)
            {
                PMKEN01010E.CEqpDefDspInfoRow row = dbData.NewCEqpDefDspInfoRow();
                row.EquipmentCode = BitConverter.ToInt32(verbinary, idx);
                idx += sizeof(int);
                row.EquipmentDispOrder = BitConverter.ToInt32(verbinary, idx);
                idx += sizeof(int);
                row.EquipmentGenreCd = BitConverter.ToInt32(verbinary, idx);
                idx += sizeof(int);
                strLen = BitConverter.ToInt32(verbinary, idx);
                idx += sizeof(int);
                row.EquipmentGenreNm = Encoding.Default.GetString(verbinary, idx, strLen);
                idx += strLen;
                row.EquipmentIconCode = BitConverter.ToInt32(verbinary, idx);
                idx += sizeof(int);
                strLen = BitConverter.ToInt32(verbinary, idx);
                idx += sizeof(int);
                row.EquipmentName = Encoding.Default.GetString(verbinary, idx, strLen);
                idx += strLen;
                strLen = BitConverter.ToInt32(verbinary, idx);
                idx += sizeof(int);
                row.EquipmentShortName = Encoding.Default.GetString(verbinary, idx, strLen);
                idx += strLen;
                row.MakerCode = BitConverter.ToInt32(verbinary, idx);
                idx += sizeof(int);
                row.ModelCode = BitConverter.ToInt32(verbinary, idx);
                idx += sizeof(int);
                row.ModelSubCode = BitConverter.ToInt32(verbinary, idx);
                idx += sizeof(int);
                row.SelectionState = BitConverter.ToBoolean(verbinary, idx);
                idx += sizeof(bool);
                row.SystematicCode = BitConverter.ToInt32(verbinary, idx);
                idx += sizeof(int);
                dbData.AddCEqpDefDspInfoRow(row);
            }

            byte[] test;
            test = carInfo.CEqpDefDspInfo.GetByteArray(true);
            PMKEN01010E.CEqpDefDspInfoDataTable dbData2 = new PMKEN01010E.CEqpDefDspInfoDataTable();
            dbData2.SetTableFromByteArray(test);
            int cnt = dbData2.Count;
        }

        private void GridParts_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band0 = e.Layout.Bands[0];
            band0.Columns["MakerCd"].Hidden = true;
        }

        /// <summary>
        /// 単価算出モジュールにより、単価を産出します。
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <returns></returns>
        private List<UnitPriceCalcRet> CalclationUnitPrice(List<GoodsUnitData> goodsUnitDataList)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                {
                    UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

                    unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                     // BLコード
                    unitPriceCalcParam.CountFl = 0;                                                 // 数量
                    unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;                 // 得意先コード
                    unitPriceCalcParam.CustRateGrpCode = this._salesSlip.CustRateGrpCode;           // 得意先掛率グループコード
                    unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                   // メーカーコード
                    unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                             // 商品番号
                    unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                 // 商品掛率ランク
                    unitPriceCalcParam.PriceApplyDate = DateTime.Now; // 元のソースとは違って仮に【今日】を価格日とする

                    // 売上単価端数処理コード(得意先マスタより取得)
                    int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                    unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;                   // 売上単価端数処理コード
                    unitPriceCalcParam.SectionCode = this._salesSlip.DemandAddUpSecCd;// 拠点コード
                    // 仕入単価端数処理コード(得意先マスタより取得)
                    int stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                    unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd; // 仕入単価端数処理コード
                    unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd; // 仕入先コード
                    unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                           // 課税区分

                    unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;                       // 税率
                    unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd; // 総額表示方法区分

                    // 0:(税込金額×掛率)
                    // 1:(税抜金額×掛率)から消費税を求め合算(消費税算出時消費税の端数処理が動作)
                    unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;				// 総額表示掛率適用区分

                    // 売上消費税端数処理コード(得意先マスタより取得)
                    int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
                    unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;
                    // 仕入消費税端数処理コード(仕入先マスタより取得)
                    int stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                    unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
                }
            }

            this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);

            return unitPriceCalcRetList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            switch (RdoSearchFlag.CheckedIndex)
            {
                case 0:
                    _partsSearchUIData.SearchFlg = SearchFlag.GoodsInfoOnly;
                    break;
                case 1:
                    _partsSearchUIData.SearchFlg = SearchFlag.GoodsAndSetInfo;
                    break;
                case 2:
                    _partsSearchUIData.SearchFlg = SearchFlag.PartsNoJoinSearch;
                    break;
            }
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

            // 仮処理 ↓↓↓↓↓
            int cnt = partsInfo.UsrGoodsInfo.Count;
            int priceApplyDate = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.UsrGoodsPriceRow rowPrice =
                    partsInfo.UsrGoodsPrice.FindApplyPrice(partsInfo.UsrGoodsInfo[i].GoodsMakerCd, partsInfo.UsrGoodsInfo[i].GoodsNo, priceApplyDate);
                if (rowPrice != null)
                {
                    partsInfo.UsrGoodsInfo[i].PriceTaxExc = rowPrice.ListPrice;
                    partsInfo.UsrGoodsInfo[i].SalesUnitPriceTaxExc = rowPrice.ListPrice;
                }
            }
            // 仮処理 ↑↑↑↑↑
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfo.GetGoodsList(false).ToArray(typeof(GoodsUnitData)));
            List<UnitPriceCalcRet> lstUnitPrice = CalclationUnitPrice(goodsUnitDataList);
            partsInfo.SetUnitPriceInfo(lstUnitPrice);//, DateTime.Now);
            List<int> makerCodeList = new List<int>();
            makerCodeList.Add(1);
            makerCodeList.Add(2);
            makerCodeList.Add(3);
            DialogResult retDialog = SelectionSamePartsNo.ShowDialog(this, partsInfo, 0, makerCodeList);
            //DialogResult retDialog = UIDisplayControl.ProcessPartsSearch(null, partsInfo);

            if (retDialog == DialogResult.OK)
            {
                SetPartsInfo(true);
                List<GoodsUnitData> goodsList = partsInfo.GetGoodsList(4, partsInfo.UsrGoodsInfo[0].GoodsMakerCd, partsInfo.UsrGoodsInfo[0].GoodsNo); // 結合先
            }
        }

        private void gridSoubi_CellListSelect(object sender, CellEventArgs e)
        {
            string query = string.Format("{0}='{1}'",
                carInfo.CEqpDefDspInfo.EquipmentGenreNmColumn.ColumnName, e.Cell.ValueList.ToString());
            PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])carInfo.CEqpDefDspInfo.Select(query);
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].EquipmentName.Equals(e.Cell.ValueList.GetText(e.Cell.ValueList.SelectedItemIndex)))
                    rows[i].SelectionState = true;
                else
                    rows[i].SelectionState = false;
            }
            //string query = string.Format("{0}='{1}' AND {2}='{3}'",
            //    carInfo.CEqpDefDspInfo.EquipmentGenreNmColumn.ColumnName, e.Cell.ValueList.ToString(),
            //    carInfo.CEqpDefDspInfo.EquipmentNameColumn.ColumnName, e.Cell.ValueList.GetText(e.Cell.ValueList.SelectedItemIndex));
            //PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])carInfo.CEqpDefDspInfo.Select(query);
            //if (rows.Length > 0)
            //    rows[0].SelectionState = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name;
            int status = PartsSearchController.GetPartsName(Convert.ToInt32(txtPartsMakerCd.Text), txtPartNo.Text, out name);
            if (status == 0)
            {
                MessageBox.Show(name);
            }
            else
            {
                MessageBox.Show("Ooops");
            }
        }

        private void txtTBO_Leave(object sender, EventArgs e)
        {
            //PartsInfoDataSet partsInfo;
            string sectionCode = "23";
            int equipCd = 1001; // 1001(バッテリ), 1005(タイヤ)
            int status = _PartsSearchController.GetTBOInfo(out partsInfo, LoginInfoAcquisition.EnterpriseCode, equipCd, txtTBO.Text, sectionCode, _drPrmSettingWork);
            if (status == 0 && partsInfo.TBOInfo.Count > 0)
            {
                ////テスト用優先倉庫設定
                //List<string> lst = new List<string>();
                //lst.Add("0003");
                //lst.Add("2001");
                //lst.Add("0004");
                //partsInfo.ListPriorWarehouse = lst;
                //partsInfo.SearchCondition = new PartsSearchUIData();
                //SearchCntSetWork SearchCntSetWork = new SearchCntSetWork();
                //SearchCntSetWork.EraNameDispCd1 = Convert.ToInt32(cmbGengo.Value);
                //SearchCntSetWork.SearchUICntDivCd = Convert.ToInt32(cmbUICon.Value);
                //SearchCntSetWork.SubstCondDivCd = Convert.ToInt32(cmbClgSubst.Value);
                //SearchCntSetWork.PrmSubstCondDivCd = Convert.ToInt32(cmbPrimeSubst.Value);
                //SearchCntSetWork.SubstApplyDivCd = Convert.ToInt32(cmbUserSubst.Value);
                //SearchCntSetWork.EnterProcDivCd = Convert.ToInt32(cmbEnterCnt.Value);
                //SearchCntSetWork.JoinInitDispDiv = Convert.ToInt32(cmbDispOrder.Value);
                //SearchCntSetWork.TtlAmntDspRateDivCd = Convert.ToInt32(cmbBL.Value);

                //partsInfo.SearchCondition.SearchCntSetWork = SearchCntSetWork;

                //DialogResult retDialog = SelectionCarInfoJoinParts.ShowDialog(carInfo, partsInfo);
                //if (retDialog == DialogResult.OK)
                //{
                //    SetPartsInfo(true);
                //}
            }
        }

        // BL
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                return;
            GridParts.DataSource = null;
            int maker, bl;
            int.TryParse(textBox1.Text, out maker);
            int.TryParse(textBox2.Text, out bl);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
            //int ret = _PartsSearchController.SearchOfrParts( maker, string.Empty, bl, 500, out partsInfo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            int ret = _PartsSearchController.SearchOfrParts( maker, string.Empty, bl, 500, string.Empty, new List<PrmSettingUWork>(), out partsInfo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD

            // 仮処理 ↓↓↓↓↓
            int cnt = partsInfo.UsrGoodsInfo.Count;
            int priceApplyDate = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.UsrGoodsPriceRow rowPrice =
                    partsInfo.UsrGoodsPrice.FindApplyPrice(partsInfo.UsrGoodsInfo[i].GoodsMakerCd, partsInfo.UsrGoodsInfo[i].GoodsNo, priceApplyDate);
                if (rowPrice != null)
                {
                    partsInfo.UsrGoodsInfo[i].PriceTaxExc = rowPrice.ListPrice;
                    partsInfo.UsrGoodsInfo[i].SalesUnitPriceTaxExc = rowPrice.ListPrice;
                }
            }
            partsInfo.AcceptChanges();
            SetPartsInfo(false);
        }

        // 品番
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox3.Text == string.Empty)
                return;
            GridParts.DataSource = null;
            int maker;
            int.TryParse(textBox1.Text, out maker);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
            //int ret = _PartsSearchController.SearchOfrParts( maker, textBox3.Text, 0, 500, out partsInfo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            int ret = _PartsSearchController.SearchOfrParts( maker, textBox3.Text, 0, 500, string.Empty, new List<PrmSettingUWork>(), out partsInfo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD

            // 仮処理 ↓↓↓↓↓
            int cnt = partsInfo.UsrGoodsInfo.Count;
            int priceApplyDate = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.UsrGoodsPriceRow rowPrice =
                    partsInfo.UsrGoodsPrice.FindApplyPrice(partsInfo.UsrGoodsInfo[i].GoodsMakerCd, partsInfo.UsrGoodsInfo[i].GoodsNo, priceApplyDate);
                if (rowPrice != null)
                {
                    partsInfo.UsrGoodsInfo[i].PriceTaxExc = rowPrice.ListPrice;
                    partsInfo.UsrGoodsInfo[i].SalesUnitPriceTaxExc = rowPrice.ListPrice;
                }
            }
            partsInfo.AcceptChanges();
            SetPartsInfo(false);
        }
    }
}