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
    /// �I���K�C�h
    /// </summary>
    /// <remarks>
    /// <br>�{�N���X��internal�Ő錾����Ă���ׁA�O���A�Z���u������͒��ڎQ�Ƃł��Ȃ��B</br>
    /// <br>�O���A�Z���u������{�N���X�ɃA�N�Z�X����ꍇ�́A����N���X�ɃC���^�[�t�F�[�X</br>
    /// <br>�ƂȂ郁�\�b�h��v���p�e�B���쐬���鎖</br>
    /// <br></br>
    /// <br>Update Note	: ���x�`���[�j���O�Ή��i�\���Ώۃf�[�^�̉��i�ꊇ�擾��ǉ��j</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009.02.10</br>
    /// <br></br>
    /// <br>Update Note	: �D��q�ɂɃg�����������ă`�F�b�N����悤�ɏC��</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009.02.16</br>
    /// <br></br>
    /// <br>Update Note	: �I�[�i�[�t�H�[���Ή�</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009.02.19</br>
    /// <br></br>
    /// <br>Update Note	: �݌ɕ\�����ŗD��q�ɂ���ɕ\�������悤�ύX</br>
    /// <br>             : �݌ɂ̑I����@���`�F�b�N�����ɕύX�i���`�F�b�N�Ŏ���I���\�ɕύX�j</br>
    /// <br>Programmer	: 22018�@��� ���b</br>
    /// <br>Date		: 2009.03.27</br>
    /// <br>Update Note : 2009/11/13 ����� �ێ�˗��B�Ή�</br>
    /// <br>            �@ ��ʕ\���̕ύX</br>
    /// <br>Update Note : 2013/04/19 ������ 2013/05/15�z�M���Ή�</br>
    /// <br>�@�@�@�@�@  : Redmine#34377��No.30��No.31�̑Ή�</br>
    /// </remarks>
    internal partial class SelectionForm : Form
    {
        #region [ Private Member ]
        /// <summary>�f�[�^�Z�b�g</summary>
        private TBO _dataSet = null;
        private PMKEN01010E _orgCarInfo = null;
        private PartsInfoDataSet _orgDataSet = null;
        private PMKEN01010E.CategoryEquipmentInfoDataTable _orgCtgEquip = null;
        private TBO.TBOInfoDataTable _carInfoJoinParts = null;
        private TBO.StockDataTable _StockTable = null;
        private PartsInfoDataSet.UsrGoodsInfoRow _prevRow = null;

        private int substFlg;          // 0:��ւ��Ȃ�  1:��ւ���i�݌ɔ��肠��j 2:��ւ���i�݌ɔ���Ȃ��j
        private int userSubstFlg;
        private int enterFlg;           // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
        private int totalAmountDispWay;       // ���z�\�����@�敪 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j

        /// <summary>�������ރR�[�h�ɂ��i��</summary>
        private string rowFilter1 = string.Empty; // �������ރR�[�h�ɂ��i��
        /// <summary>�����Ǘ��敪�ɂ��i��</summary>
        private string rowFilter2 = string.Empty; // �����Ǘ��敪�ɂ��i��
        /// <summary>BL�ɂ��i��</summary>
        private string rowFilter3 = string.Empty; // BL�ɂ��i��
        /// <summary>���[�J�[�ɂ��i��</summary>
        private string rowFilterMaker = string.Empty; // ���[�J�[�ɂ��i��
        private bool selectionChanged = false;

        private bool _equipmentGenreCdHaveFlag = true; // ADD 2009/11/13
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        /// <param name="carInfo"></param>
        /// <param name="dsSource">�O���b�h�ɕ\������f�[�^���w�肵�܂��B</param>
        /// <br>Update Note : 2009/11/13 ����� �ێ�˗��B�Ή�</br>
        /// <br>            �@ ��ʕ\���̕ύX</br>
        public SelectionForm(PMKEN01010E carInfo, PartsInfoDataSet dsSource)
        {
            _orgCarInfo = carInfo;
            _orgDataSet = dsSource;
            _orgCtgEquip = carInfo.CategoryEquipmentInfo;
            InitializeComponent();
            InitializeTable();
            //InitializeData(); // DEL 2009/11/13

            // --- ADD 2009/11/13 ---------->>>>>
            if (_orgDataSet.TBOInitializeFlg == 0)
            {
                // �i�Ԍ����ABL�R�[�h���������TBO�I���̕\��
                InitializeData();
            }
            else
            {
                // TBO�{�^�������TBO�I���̕\��
                InitializeData2();
            }
            // --- ADD 2009/11/13 ----------<<<<<

            // �c�[���o�[�̃C���[�W(16x16)�⃁�b�Z�[�W��ݒ肷��
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            if (substFlg != 0)
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARADD;
            }
            else
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Visible = false;
            }

            // --- UPD 2009/11/13 ---------->>>>>
            if (gridTBO.Rows.Count > 0)
            {
                // �擪�s��I����Ԃɂ���
                gridTBO.Rows[0].Selected = true;
                gridTBO.Rows[0].Activate();
            }
            // --- UPD 2009/11/13 ----------<<<<<

        }
        #endregion

        // --- ADD 2009/11/13 ---------->>>>>
        //================================================================================
        //  �v���p�e�B
        //================================================================================
        #region Public Property
        /// <summary>
        ///  �ΏۂƂȂ鑕���R�[�h
        /// </summary>
        public bool EquipmentGenreCdHaveFlag
        {
            get { return _equipmentGenreCdHaveFlag; }
            set { _equipmentGenreCdHaveFlag = value; }
        }
        #endregion
        // --- ADD 2009/11/13 ----------<<<<<

        #region [ �������� ]
        private void InitializeTable()
        {
            // DataTable �̐ݒ�
            _dataSet = new TBO();
            _carInfoJoinParts = _dataSet.TBOInfo;
            _StockTable = _dataSet.Stock;

            if (_orgDataSet.SearchCondition != null)
            {
                substFlg = _orgDataSet.SearchCondition.SearchCntSetWork.PrmSubstCondDivCd; // 0:��ւ��Ȃ�  1:��ւ���i�݌ɔ��肠��j 2:��ւ���i�݌ɔ���Ȃ��j
                userSubstFlg = _orgDataSet.SearchCondition.SearchCntSetWork.SubstApplyDivCd;
                enterFlg = _orgDataSet.SearchCondition.SearchCntSetWork.EnterProcDivCd; // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
                totalAmountDispWay = _orgDataSet.SearchCondition.SearchCntSetWork.TotalAmountDispWayCd; // 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j
            }

            gridTBO.DataSource = _carInfoJoinParts.DefaultView;
            gridKind.DataSource = _orgCtgEquip.DefaultView;
            gridStock.DataSource = _dataSet.Stock.DefaultView;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            SettingStockView( _dataSet.Stock.DefaultView );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
            gridMaker.DataSource = _dataSet.Maker.DefaultView;
            _carInfoJoinParts.DefaultView.Sort = string.Format("{0},{1},{2} DESC",
                _carInfoJoinParts.OfferKubunColumn.ColumnName,
                _carInfoJoinParts.CarInfoJoinDispOrderColumn.ColumnName,
                _carInfoJoinParts.KubunColumn.ColumnName);
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
        /// <summary>
        /// �݌ɂ�DataSource�ƂȂ�View��ݒ肵�܂�
        /// </summary>
        /// <param name="dataView"></param>
        private void SettingStockView( DataView dataView )
        {
            // �\�[�g�ݒ�
            dataView.Sort = string.Format( "{0}, {1}",
                                            _dataSet.Stock.SortDivColumn.ColumnName,
                                            _dataSet.Stock.WarehouseCodeColumn.ColumnName );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD

        /// <summary>
        /// �\���p�f�[�^��DataTable�ɓo�^���邽�߂̃T�u�X���b�h
        /// </summary>
        private void InitializeData()
        {
            // 2009.02.10 Add >>>
            this.SettingPriceTargetData();
            // 2009.02.10 Add <<<
            _carInfoJoinParts.BeginLoadData();
            try
            {
                _carInfoJoinParts.Merge(_orgDataSet.TBOInfo, true, MissingSchemaAction.Ignore);

                if (_carInfoJoinParts.Count == 0)
                    return;

                int cnt = _carInfoJoinParts.Count;
                for (int i = 0; i < cnt; i++)
                {
                    PartsInfoDataSet.UsrGoodsInfoRow rowGoods = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                        _carInfoJoinParts[i].JoinDestMakerCd, _carInfoJoinParts[i].JoinDestPartsNo);
                    if (rowGoods != null)
                    {
                        if (rowGoods.GoodsName != string.Empty)
                        {
                            _carInfoJoinParts[i].PrimePartsName = rowGoods.GoodsName;
                        }
                        else
                        {
                            _carInfoJoinParts[i].PrimePartsName = rowGoods.GoodsOfrName;
                        }
                        if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                        {
                            _carInfoJoinParts[i].Genka = rowGoods.UnitCostTaxInc;
                            _carInfoJoinParts[i].Price = rowGoods.PriceTaxInc;
                            _carInfoJoinParts[i].Urika = rowGoods.SalesUnitPriceTaxInc;
                        }
                        else
                        {
                            _carInfoJoinParts[i].Genka = rowGoods.UnitCostTaxExc;
                            _carInfoJoinParts[i].Price = rowGoods.PriceTaxExc;
                            _carInfoJoinParts[i].Urika = rowGoods.SalesUnitPriceTaxExc;
                        }
                        // �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
                        _carInfoJoinParts[i].Ararigaku = rowGoods.SalesUnitPriceTaxExc - rowGoods.UnitCostTaxExc;
                        if (rowGoods.SalesUnitPriceTaxExc != 0)
                            _carInfoJoinParts[i].Arariritu = _carInfoJoinParts[i].Ararigaku / rowGoods.SalesUnitPriceTaxExc;
                    }
                    string filter = String.Format("{0} = {1} AND {2} = '{3}'",
                        _orgCtgEquip.EquipmentGenreCdColumn.ColumnName, _carInfoJoinParts[i].EquipGenreCode,
                        _orgCtgEquip.EquipmentNameColumn.ColumnName, _carInfoJoinParts[i].EquipName);
                    //�Ⴆ�΃X�^�b�h���X�^�C���̓^�C����BL�R�[�h���Ⴄ���߁A�ȉ����R�����g����
                    //_orgCtgEquip.TbsPartsCodeColumn.ColumnName, _carInfoJoinParts[i].TbsPartsCode);
                    PMKEN01010E.CategoryEquipmentInfoRow[] cEIrows =
                            (PMKEN01010E.CategoryEquipmentInfoRow[])_orgCtgEquip.Select(filter);
                    if (cEIrows.Length > 0)
                    {
                        _carInfoJoinParts[i].Kubun = cEIrows[0].EquipmentMngName;
                        _carInfoJoinParts[i].EquipmentDispOrder = cEIrows[0].EquipmentDispOrder;

                        if (_dataSet.Maker.FindByEquipGenreCodeMakerCd(_carInfoJoinParts[i].EquipGenreCode,
                                _carInfoJoinParts[i].JoinDestMakerCd) == null)
                        {
                            TBO.MakerRow rowMaker = _dataSet.Maker.NewMakerRow();
                            rowMaker.EquipGenreCode = _carInfoJoinParts[i].EquipGenreCode;
                            rowMaker.MakerCd = _carInfoJoinParts[i].JoinDestMakerCd;
                            rowMaker.MakerNm = _carInfoJoinParts[i].JoinDestMakerNm;
                            _dataSet.Maker.AddMakerRow(rowMaker);
                        }

                        if (cEIrows.Length > 1) // ���ꑕ������2�敪�ȏ�̏ꍇ�̏���
                        {
                            for (int j = 1; j < cEIrows.Length; j++)
                            {
                                TBO.TBOInfoRow row = _carInfoJoinParts.NewTBOInfoRow();
                                row.Ararigaku = _carInfoJoinParts[i].Ararigaku;
                                row.Arariritu = _carInfoJoinParts[i].Arariritu;
                                row.CarInfoJoinDispOrder = _carInfoJoinParts[i].CarInfoJoinDispOrder;
                                row.CatalogDeleteFlag = _carInfoJoinParts[i].CatalogDeleteFlag;
                                row.EquipGenreCode = _carInfoJoinParts[i].EquipGenreCode;
                                row.EquipName = _carInfoJoinParts[i].EquipName;
                                row.EquipSpecialNote = _carInfoJoinParts[i].EquipSpecialNote;
                                row.Genka = _carInfoJoinParts[i].Genka;
                                row.GoodsMGroup = _carInfoJoinParts[i].GoodsMGroup;
                                row.JoinDestMakerCd = _carInfoJoinParts[i].JoinDestMakerCd;
                                row.JoinDestMakerNm = _carInfoJoinParts[i].JoinDestMakerNm;
                                row.JoinDestPartsNo = _carInfoJoinParts[i].JoinDestPartsNo;
                                row.JoinQty = _carInfoJoinParts[i].JoinQty;
                                row.Kubun = cEIrows[j].EquipmentMngName;
                                row.MakerDispOrder = _carInfoJoinParts[i].MakerDispOrder;
                                row.PartsAttribute = _carInfoJoinParts[i].PartsAttribute;
                                row.PartsLayerCd = _carInfoJoinParts[i].PartsLayerCd;
                                row.Price = _carInfoJoinParts[i].Price;
                                row.PrimePartsName = _carInfoJoinParts[i].PrimePartsName;
                                row.PrimePartsSpecialNote = _carInfoJoinParts[i].PrimePartsSpecialNote;
                                row.Shelf = _carInfoJoinParts[i].Shelf;
                                row.StockCnt = _carInfoJoinParts[i].StockCnt;
                                row.Urika = _carInfoJoinParts[i].Urika;
                                row.Warehouse = _carInfoJoinParts[i].Warehouse;
                                row.TbsPartsCode = _carInfoJoinParts[i].TbsPartsCode;//ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�
                                _carInfoJoinParts.AddTBOInfoRow(row);

                            }
                        }
                    }
                    if (SubstExists(_carInfoJoinParts[i].JoinDestPartsNo, _carInfoJoinParts[i].JoinDestMakerCd))
                        _carInfoJoinParts[i].Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];

                    #region [ �݌ɐݒ� ]
                    bool flgStock = false;
                    filter = string.Format("{0}={1} AND {2}='{3}'",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, _carInfoJoinParts[i].JoinDestMakerCd,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName, _carInfoJoinParts[i].JoinDestPartsNo);
                    PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(filter);
                    for (int j = 0; j < stockRows.Length; j++)
                    {
                        if (_StockTable.FindByWarehouseCodeGoodsMakerCdGoodsNo(stockRows[j].WarehouseCode,
                            stockRows[j].GoodsMakerCd, stockRows[j].GoodsNo) == null)
                        {
                            TBO.StockRow stockRow = _dataSet.Stock.NewStockRow();
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
                            // �݌ɏ��̃\�[�g�Ɏg�p����敪�l���Z�b�g����
                            if ( _orgDataSet.ListPriorWarehouse != null )
                            {
                                int index = _orgDataSet.ListPriorWarehouse.IndexOf( stockRow.WarehouseCode.Trim() );
                                if ( index >= 0 )
                                {
                                    // �D��q�Ƀ��X�g�ɂ����index���Z�b�g
                                    stockRow.SortDiv = index;
                                }
                                else
                                {
                                    // �D��q�Ƀ��X�g�ɂȂ���΃��X�g��Count(�ő��index+1)
                                    stockRow.SortDiv = _orgDataSet.ListPriorWarehouse.Count;
                                }
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
                            _StockTable.AddStockRow(stockRow);
                            if (stockRows[j].SelectionState)
                            {
                                _carInfoJoinParts[i].Shelf = stockRow.WarehouseShelfNo;
                                _carInfoJoinParts[i].StockCnt = stockRow.ShipmentPosCnt;
                                _carInfoJoinParts[i].Warehouse = stockRow.WarehouseName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
                                _carInfoJoinParts[i].WarehouseCode = stockRow.WarehouseCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
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
                                    _carInfoJoinParts[i].Shelf = stockRows[k].WarehouseShelfNo;
                                    _carInfoJoinParts[i].StockCnt = stockRows[k].ShipmentPosCnt;
                                    _carInfoJoinParts[i].Warehouse = stockRows[k].WarehouseName;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
                                    _carInfoJoinParts[i].WarehouseCode = stockRows[k].WarehouseCode;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
                                    flgStock = true;
                                    break;
                                }
                            }
                            if (flgStock)
                                break;
                        }
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 DEL // �D��q�ɂɂȂ��ꍇ�͎��ɂ���
                    //if (flgStock == false && stockRows.Length > 0)
                    //{
                    //    _carInfoJoinParts[i].Shelf = stockRows[0].WarehouseShelfNo;
                    //    _carInfoJoinParts[i].StockCnt = stockRows[0].ShipmentPosCnt;
                    //    _carInfoJoinParts[i].Warehouse = stockRows[0].WarehouseName;
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
                    //    _carInfoJoinParts[i].WarehouseCode = stockRows[0].WarehouseCode;
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 DEL
                    #endregion
                }

                List<int> EquipCdList = _carInfoJoinParts.GetEquipCdList();
                if (EquipCdList.Count > 1)
                {
                    for (int i = 0; i < EquipCdList.Count; i++)
                    {
                        string filter = String.Format("{0} = {1}", _orgCtgEquip.EquipmentGenreCdColumn.ColumnName, EquipCdList[i]);
                        PMKEN01010E.CategoryEquipmentInfoRow[] cEIrows =
                            (PMKEN01010E.CategoryEquipmentInfoRow[])_orgCtgEquip.Select(filter);
                        if (cEIrows.Length > 0)
                        {
                            cmbGenre.Items.Add(cEIrows[0].EquipmentGenreNm);
                        }
                    }
                    cmbGenre.SelectedIndex = 0;
                }
                else
                {
                    string format = string.Empty;
                    //txtEquipName.Text = _carInfoJoinParts[0].EquipName;
                    for (int i = 0; i < _orgCtgEquip.Count; i++)
                    {
                        if (_orgCtgEquip[i].EquipmentGenreCd == EquipCdList[0])
                        {
                            txtGenre.Text = _orgCtgEquip[i].EquipmentGenreNm;
                            cmbGenre.Visible = false;
                            txtGenre.Visible = true;
                            break;
                        }
                    }
                    string rowFilter = String.Format("{0} = {1}", _orgCtgEquip.EquipmentGenreCdColumn.ColumnName,
                        _carInfoJoinParts[0].EquipGenreCode);
                    _orgCtgEquip.DefaultView.RowFilter = rowFilter;
                    cmbSoubiNm.Items.Add(string.Empty);
                    for (int i = 0; i < _orgCtgEquip.DefaultView.Count; i++)
                    {
                        PMKEN01010E.CategoryEquipmentInfoRow rowCE = (PMKEN01010E.CategoryEquipmentInfoRow)_orgCtgEquip.DefaultView[i].Row;
                        cmbSoubiNm.Items.Add(string.Format("{0}[{1}]", rowCE.EquipmentName, rowCE.EquipmentMngName));
                    }
                    cmbBL.Items.Add(string.Empty);
                    for (int i = 0; i < _carInfoJoinParts.DefaultView.Count; i++)
                    {
                        TBO.TBOInfoRow rowTBO = (TBO.TBOInfoRow)_carInfoJoinParts.DefaultView[i].Row;
                        if (rowTBO.TbsPartsCode != 0 && cmbBL.Items.Contains(rowTBO.TbsPartsCode) == false)
                        {
                            cmbBL.Items.Add(rowTBO.TbsPartsCode);
                        }
                    }
                }

            }
            finally
            {
                _carInfoJoinParts.EndLoadData();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
                // TBO���בI��
                if ( gridTBO.Rows.Count > 0 )
                {
                    gridTBO.Select();
                    gridTBO.Rows[0].Activate();
                    gridTBO.Rows[0].Selected = true;
                }
                // �݌ɍi�荞�ݓK�p
                FilteringStockGrid();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
            }
        }

        // --- ADD 2009/11/13 ---------->>>>> 
        /// <summary>
        /// �\���p�f�[�^��DataTable�ɓo�^���邽�߂̃T�u�X���b�h
        /// </summary>
        /// <remarks>
        /// <br>Note        : �\���p�f�[�^��DataTable�ɓo�^���邽�߂̃T�u�X���b�h�B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/11/13</br>
        /// </remarks>
        private void InitializeData2()
        {
            this.SettingPriceTargetData();
            _carInfoJoinParts.BeginLoadData();
            try
            {
                _carInfoJoinParts.Merge(_orgDataSet.TBOInfo, true, MissingSchemaAction.Ignore);

                // TBO���̌������u0�v�ł��I�����Ȃ��B
                //if (_carInfoJoinParts.Count == 0)
                //    return;

                int cnt = _carInfoJoinParts.Count;
                for (int i = 0; i < cnt; i++)
                {
                    PartsInfoDataSet.UsrGoodsInfoRow rowGoods = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                        _carInfoJoinParts[i].JoinDestMakerCd, _carInfoJoinParts[i].JoinDestPartsNo);
                    if (rowGoods != null)
                    {
                        if (rowGoods.GoodsName != string.Empty)
                        {
                            _carInfoJoinParts[i].PrimePartsName = rowGoods.GoodsName;
                        }
                        else
                        {
                            _carInfoJoinParts[i].PrimePartsName = rowGoods.GoodsOfrName;
                        }
                        if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                        {
                            _carInfoJoinParts[i].Genka = rowGoods.UnitCostTaxInc;
                            _carInfoJoinParts[i].Price = rowGoods.PriceTaxInc;
                            _carInfoJoinParts[i].Urika = rowGoods.SalesUnitPriceTaxInc;
                        }
                        else
                        {
                            _carInfoJoinParts[i].Genka = rowGoods.UnitCostTaxExc;
                            _carInfoJoinParts[i].Price = rowGoods.PriceTaxExc;
                            _carInfoJoinParts[i].Urika = rowGoods.SalesUnitPriceTaxExc;
                        }
                        // �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
                        _carInfoJoinParts[i].Ararigaku = rowGoods.SalesUnitPriceTaxExc - rowGoods.UnitCostTaxExc;
                        if (rowGoods.SalesUnitPriceTaxExc != 0)
                            _carInfoJoinParts[i].Arariritu = _carInfoJoinParts[i].Ararigaku / rowGoods.SalesUnitPriceTaxExc;
                    }
                    string filter = String.Format("{0} = {1} AND {2} = '{3}'",
                        _orgCtgEquip.EquipmentGenreCdColumn.ColumnName, _carInfoJoinParts[i].EquipGenreCode,
                        _orgCtgEquip.EquipmentNameColumn.ColumnName, _carInfoJoinParts[i].EquipName);
                    //�Ⴆ�΃X�^�b�h���X�^�C���̓^�C����BL�R�[�h���Ⴄ���߁A�ȉ����R�����g����
                    //_orgCtgEquip.TbsPartsCodeColumn.ColumnName, _carInfoJoinParts[i].TbsPartsCode);
                    PMKEN01010E.CategoryEquipmentInfoRow[] cEIrows =
                            (PMKEN01010E.CategoryEquipmentInfoRow[])_orgCtgEquip.Select(filter);
                    if (cEIrows.Length > 0)
                    {
                        _carInfoJoinParts[i].Kubun = cEIrows[0].EquipmentMngName;
                        _carInfoJoinParts[i].EquipmentDispOrder = cEIrows[0].EquipmentDispOrder;

                        if (_dataSet.Maker.FindByEquipGenreCodeMakerCd(_carInfoJoinParts[i].EquipGenreCode,
                                _carInfoJoinParts[i].JoinDestMakerCd) == null)
                        {
                            TBO.MakerRow rowMaker = _dataSet.Maker.NewMakerRow();
                            rowMaker.EquipGenreCode = _carInfoJoinParts[i].EquipGenreCode;
                            rowMaker.MakerCd = _carInfoJoinParts[i].JoinDestMakerCd;
                            rowMaker.MakerNm = _carInfoJoinParts[i].JoinDestMakerNm;
                            _dataSet.Maker.AddMakerRow(rowMaker);
                        }

                        if (cEIrows.Length > 1) // ���ꑕ������2�敪�ȏ�̏ꍇ�̏���
                        {
                            for (int j = 1; j < cEIrows.Length; j++)
                            {
                                TBO.TBOInfoRow row = _carInfoJoinParts.NewTBOInfoRow();
                                row.Ararigaku = _carInfoJoinParts[i].Ararigaku;
                                row.Arariritu = _carInfoJoinParts[i].Arariritu;
                                row.CarInfoJoinDispOrder = _carInfoJoinParts[i].CarInfoJoinDispOrder;
                                row.CatalogDeleteFlag = _carInfoJoinParts[i].CatalogDeleteFlag;
                                row.EquipGenreCode = _carInfoJoinParts[i].EquipGenreCode;
                                row.EquipName = _carInfoJoinParts[i].EquipName;
                                row.EquipSpecialNote = _carInfoJoinParts[i].EquipSpecialNote;
                                row.Genka = _carInfoJoinParts[i].Genka;
                                row.GoodsMGroup = _carInfoJoinParts[i].GoodsMGroup;
                                row.JoinDestMakerCd = _carInfoJoinParts[i].JoinDestMakerCd;
                                row.JoinDestMakerNm = _carInfoJoinParts[i].JoinDestMakerNm;
                                row.JoinDestPartsNo = _carInfoJoinParts[i].JoinDestPartsNo;
                                row.JoinQty = _carInfoJoinParts[i].JoinQty;
                                row.Kubun = cEIrows[j].EquipmentMngName;
                                row.MakerDispOrder = _carInfoJoinParts[i].MakerDispOrder;
                                row.PartsAttribute = _carInfoJoinParts[i].PartsAttribute;
                                row.PartsLayerCd = _carInfoJoinParts[i].PartsLayerCd;
                                row.Price = _carInfoJoinParts[i].Price;
                                row.PrimePartsName = _carInfoJoinParts[i].PrimePartsName;
                                row.PrimePartsSpecialNote = _carInfoJoinParts[i].PrimePartsSpecialNote;
                                row.Shelf = _carInfoJoinParts[i].Shelf;
                                row.StockCnt = _carInfoJoinParts[i].StockCnt;
                                row.Urika = _carInfoJoinParts[i].Urika;
                                row.Warehouse = _carInfoJoinParts[i].Warehouse;
                                row.TbsPartsCode = _carInfoJoinParts[i].TbsPartsCode;//ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�
                                _carInfoJoinParts.AddTBOInfoRow(row);

                            }
                        }
                    }
                    if (SubstExists(_carInfoJoinParts[i].JoinDestPartsNo, _carInfoJoinParts[i].JoinDestMakerCd))
                        _carInfoJoinParts[i].Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];

                    #region [ �݌ɐݒ� ]
                    bool flgStock = false;
                    filter = string.Format("{0}={1} AND {2}='{3}'",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, _carInfoJoinParts[i].JoinDestMakerCd,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName, _carInfoJoinParts[i].JoinDestPartsNo);
                    PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(filter);
                    for (int j = 0; j < stockRows.Length; j++)
                    {
                        if (_StockTable.FindByWarehouseCodeGoodsMakerCdGoodsNo(stockRows[j].WarehouseCode,
                            stockRows[j].GoodsMakerCd, stockRows[j].GoodsNo) == null)
                        {
                            TBO.StockRow stockRow = _dataSet.Stock.NewStockRow();
                            stockRow.GoodsMakerCd = stockRows[j].GoodsMakerCd;
                            stockRow.GoodsNo = stockRows[j].GoodsNo;
                            stockRow.MaximumStockCnt = stockRows[j].MaximumStockCnt;
                            stockRow.MinimumStockCnt = stockRows[j].MinimumStockCnt;
                            stockRow.ShipmentPosCnt = stockRows[j].ShipmentPosCnt;
                            stockRow.WarehouseCode = stockRows[j].WarehouseCode;
                            stockRow.WarehouseName = stockRows[j].WarehouseName;
                            stockRow.WarehouseShelfNo = stockRows[j].WarehouseShelfNo;
                            stockRow.SelectionState = stockRows[j].SelectionState;

                            // �݌ɏ��̃\�[�g�Ɏg�p����敪�l���Z�b�g����
                            if (_orgDataSet.ListPriorWarehouse != null)
                            {
                                int index = _orgDataSet.ListPriorWarehouse.IndexOf(stockRow.WarehouseCode.Trim());
                                if (index >= 0)
                                {
                                    // �D��q�Ƀ��X�g�ɂ����index���Z�b�g
                                    stockRow.SortDiv = index;
                                }
                                else
                                {
                                    // �D��q�Ƀ��X�g�ɂȂ���΃��X�g��Count(�ő��index+1)
                                    stockRow.SortDiv = _orgDataSet.ListPriorWarehouse.Count;
                                }
                            }

                            _StockTable.AddStockRow(stockRow);
                            if (stockRows[j].SelectionState)
                            {
                                _carInfoJoinParts[i].Shelf = stockRow.WarehouseShelfNo;
                                _carInfoJoinParts[i].StockCnt = stockRow.ShipmentPosCnt;
                                _carInfoJoinParts[i].Warehouse = stockRow.WarehouseName;
                                _carInfoJoinParts[i].WarehouseCode = stockRow.WarehouseCode;
                                flgStock = true;
                            }
                        }
                    }
                    if (flgStock == false && _orgDataSet.ListPriorWarehouse != null)
                    {
                        for (int j = 0; j < _orgDataSet.ListPriorWarehouse.Count; j++)
                        {
                            string warehouseCd = _orgDataSet.ListPriorWarehouse[j].Trim();
                            for (int k = 0; k < stockRows.Length; k++)
                            {
                                if (stockRows[k].WarehouseCode.Equals(warehouseCd))
                                {
                                    _carInfoJoinParts[i].Shelf = stockRows[k].WarehouseShelfNo;
                                    _carInfoJoinParts[i].StockCnt = stockRows[k].ShipmentPosCnt;
                                    _carInfoJoinParts[i].Warehouse = stockRows[k].WarehouseName;
                                    _carInfoJoinParts[i].WarehouseCode = stockRows[k].WarehouseCode;
                                    flgStock = true;
                                    break;
                                }
                            }
                            if (flgStock)
                                break;
                        }
                    }
                    #endregion
                }

                // �ΏۂƂȂ鑕���R�[�h(EquipmentGenreCd)�̈ꗗ�����q�������ʂ̑������(_orgCtgEquip)����擾����B
                for (int i = 0; i < _orgCtgEquip.Count; i++)
                {
                    if (_orgCtgEquip[i].EquipmentGenreCd == 1001
                        || _orgCtgEquip[i].EquipmentGenreCd == 1005
                        || _orgCtgEquip[i].EquipmentGenreCd == 1010)
                    {
                        if (!cmbGenre.Items.Contains(_orgCtgEquip[i].EquipmentGenreNm))
                        {
                            cmbGenre.Items.Add(_orgCtgEquip[i].EquipmentGenreNm);
                        }
                    }
                }

                // ��������
                if (cmbGenre.Items.Count > 0)
                {
                    cmbGenre.SelectedIndex = 0;
                }
                else
                {
                    // �ΏۂƂȂ鑕���R�[�h�ŊY�����郌�R�[�h���P�������݂��Ȃ������ꍇ
                    this._equipmentGenreCdHaveFlag = false;
                }
            }
            finally
            {
                _carInfoJoinParts.EndLoadData();
                // TBO���בI��
                if (gridTBO.Rows.Count > 0)
                {
                    gridTBO.Select();
                    gridTBO.Rows[0].Activate();
                    gridTBO.Rows[0].Selected = true;
                }

                // �݌ɍi�荞�ݓK�p
                FilteringStockGrid();
            }
        }
        // --- ADD 2009/11/13 ----------<<<<<

        internal bool SubstExists(string parts, int maker)
        {
            string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, parts,
                _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, maker);
            if (_orgDataSet.UsrSubstParts.Select(rowFilter).Length > 0)
                return true;
            return false;
        }

        // 2009.02.10 Add >>>
        /// <summary>
        /// �Ώۃf�[�^�̉��i�ݒ�
        /// </summary>
        private void SettingPriceTargetData()
        {
            if (_orgDataSet.CalculateGoodsPrice == null) return;

            List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList = new List<PartsInfoDataSet.GoodsPrimaryKey>();

            foreach (PartsInfoDataSet.TBOInfoRow row in _orgDataSet.TBOInfo)
            {
                goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(row.JoinDestPartsNo, row.JoinDestMakerCd));
            }

            // ���i��񂪑��݂���ꍇ�͉��i�v�Z
            if (goodsPrimaryKeyList.Count > 0)
            {
                _orgDataSet.SettingGoodsPrice(goodsPrimaryKeyList);
            }
        }

        #endregion

        #region Internal

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

        #endregion

        #region [ �t�H�[���C�x���g���� ]
        /// <summary>
        /// FormClosed �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResult��OK�̏ꍇ�ɂ̂݁A�O���b�h��őI������Ă���s�Ɋ֘A����DataRow�I�u�W�F�N�g���擾���A</br>
        /// <br>"�I�����"�ɑ������鏈�����s���܂��B</br>
        /// </remarks>
        private void SelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            int cnt = gridTBO.Rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = null;
                UltraGridRow gridRow = gridTBO.Rows[i];

                if (gridRow.Cells[_dataSet.TBOInfo.SelectionStateColumn.ColumnName].Value.Equals(true))
                {
                    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo((int)gridRow.Cells[_dataSet.TBOInfo.JoinDestMakerCdColumn.ColumnName].Value,
                                gridRow.Cells[_dataSet.TBOInfo.JoinDestPartsNoColumn.ColumnName].Value.ToString());

                    SelectionInfo selInfo = new SelectionInfo();
                    selInfo.Depth = 0;
                    selInfo.Key = gridRow.ListIndex;
                    selInfo.RowGoods = row;
                    selInfo.WarehouseCode = gridRow.Cells[_dataSet.TBOInfo.WarehouseCodeColumn.ColumnName].Value.ToString();
                    //if (uiControlFlg && gridRow.Cells[_dataSet.TBOInfo.SelImageColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                    //    selInfo.Selected = true;
                    //else
                    //    selInfo.Selected = false;
                    selInfo.Selected = true;
                    _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                    if (gridTBO.ActiveRow != null && i == gridTBO.ActiveRow.Index && _orgDataSet.UIKind == SelectUIKind.Subst)
                    {
                        _orgDataSet.SubstSrcSelInf = selInfo;
                        selInfo.Selected = false;
                    }
                }
            }

        }

        /// <summary>
        /// ESC�L�[�����ɂ��I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
        #endregion

        #region [ �c�[���o�[�C�x���g���� ]
        /// <summary>
        /// �c�[���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Button_Select":
                    // �I������Ă���s���m�肷��
                    if (enterFlg == 2)
                    {
                        SetSelect(false);
                    }
                    else
                    {
                        if (_carInfoJoinParts.Select("SelectionState = true").Length == 0)
                        {
                            SetStatusBarText(1, "�f�[�^�̑I��������Ă��܂���B");
                            break;
                        }
                        DialogResult = DialogResult.OK;
                    }
                    break;

                case "Button_Back":
                    // �O�̉�ʂɖ߂�
                    DialogResult = DialogResult.Cancel;
                    break;

                case "Button_Subst":
                    // ��ւ�����ꍇ���UI�\��
                    if (substFlg != 0 && gridTBO.ActiveRow != null)
                    {
                        if (gridTBO.ActiveRow.Cells[_carInfoJoinParts.SubstColumn.ColumnName].Value != DBNull.Value)
                        {
                            DialogResult = DialogResult.OK;
                            int makerCd = (int)gridTBO.ActiveRow.Cells[_carInfoJoinParts.JoinDestMakerCdColumn.ColumnName].Value;
                            string partsNo = gridTBO.ActiveRow.Cells[_carInfoJoinParts.JoinDestOrgPartsNoColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                //_orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                gridTBO.ActiveRow.Cells[_carInfoJoinParts.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                //_prevRow = row;
                                _prevRow = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd,
                                    gridTBO.ActiveRow.Cells[_carInfoJoinParts.JoinDestPartsNoColumn.ColumnName].Value.ToString());
                                _orgDataSet.UIKind = SelectUIKind.Subst;
                                DialogResult = DialogResult.Retry;
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// �X�e�[�^�X�o�[�ݒ�
        /// </summary>
        /// <param name="mode">0:�����@1:�Ԏ�</param>
        /// <param name="msg">�ݒ肷�郁�b�Z�[�W</param>
        private void SetStatusBarText(int mode, string msg)
        {
            StatusBar.Panels[0].Text = msg;
            switch (mode)
            {
                case 0: // 0:����
                    StatusBar.Panels[0].Appearance.Reset();
                    break;
                case 1: // 1:�Ԏ�
                    StatusBar.Panels[0].Appearance.ForeColor = Color.Red;
                    StatusBar.Panels[0].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    break;
            }
        }
        #endregion

        #region [ �O���b�h�C�x���g���� ]
        /// <summary>
        /// InitializeLayout �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�O���b�h�̃��C�A�E�g����������</br>
        /// </remarks>
        private void gridTBO_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // �񕝂̎����������@
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;
            e.Layout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // �o���h�̎擾
            UltraGridBand Band = e.Layout.Bands[0];
            Band.Indentation = 0;
            Band.Override.RowSizing = RowSizing.Fixed;
            Band.Override.AllowColSizing = AllowColSizing.None;
            Band.UseRowLayout = true;

            for (int Index = 0; Index < Band.Columns.Count; Index++)
            {
                // �����\���ʒu
                if ((Band.Columns[Index].DataType == typeof(int)) ||
                   (Band.Columns[Index].DataType == typeof(double)) ||
                   (Band.Columns[Index].DataType == typeof(Int64)))
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (Band.Columns[Index].DataType == typeof(Image))
                {
                    Band.Columns[Index].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                }
                else
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                Band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // �����\���ʒu
                Band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            Band.Columns[_carInfoJoinParts.GoodsMGroupColumn.ColumnName].Hidden = true;
            Band.Columns[_carInfoJoinParts.TbsPartsCodeColumn.ColumnName].Hidden = true;
            Band.Columns[_carInfoJoinParts.EquipGenreCodeColumn.ColumnName].Hidden = true;
            Band.Columns[_carInfoJoinParts.EquipNameColumn.ColumnName].Hidden = true;
            Band.Columns[_carInfoJoinParts.CarInfoJoinDispOrderColumn.ColumnName].Hidden = true;
            //Band.Columns[_carInfoJoinParts.JoinDestMakerCdColumn.ColumnName].Hidden = true;
            Band.Columns[_carInfoJoinParts.PartsLayerCdColumn.ColumnName].Hidden = true;
            Band.Columns[_carInfoJoinParts.PrimePartsSpecialNoteColumn.ColumnName].Hidden = true;
            Band.Columns[_carInfoJoinParts.PartsAttributeColumn.ColumnName].Hidden = true;
            Band.Columns[_carInfoJoinParts.MakerDispOrderColumn.ColumnName].Hidden = true;
            Band.Columns[_carInfoJoinParts.CatalogDeleteFlagColumn.ColumnName].Hidden = true;
            Band.Columns[_carInfoJoinParts.SelectionStateColumn.ColumnName].Hidden = true;
            Band.Columns[_carInfoJoinParts.EquipmentDispOrderColumn.ColumnName].Hidden = true;
            Band.Columns[_carInfoJoinParts.WarehouseCodeColumn.ColumnName].Hidden = true;
            Band.Columns[_carInfoJoinParts.JoinDestOrgPartsNoColumn.ColumnName].Hidden = true;
            Band.Columns[_carInfoJoinParts.OfferKubunColumn.ColumnName].Hidden = true;

            ColInfo.SetColInfo(Band, _carInfoJoinParts.SelImageColumn.ColumnName, 2, 0, 1, 4, 15);

            //ColInfo.SetColInfo(Band, _carInfoJoinParts.EquipNameColumn.ColumnName, 4, 0, 100);
            ColInfo.SetColInfo(Band, _carInfoJoinParts.JoinDestMakerCdColumn.ColumnName, 3, 0, 2, 2, 25);
            ColInfo.SetColInfo(Band, _carInfoJoinParts.JoinDestMakerNmColumn.ColumnName, 5, 0, 10, 2, 95);
            ColInfo.SetColInfo(Band, _carInfoJoinParts.PrimePartsNameColumn.ColumnName, 15, 0, 12, 2, 120);
            ColInfo.SetColInfo(Band, _carInfoJoinParts.KubunColumn.ColumnName, 27, 0, 3, 2, 30);
            ColInfo.SetColInfo(Band, _carInfoJoinParts.WarehouseColumn.ColumnName, 30, 0, 3, 2, 30);
            ColInfo.SetColInfo(Band, _carInfoJoinParts.JoinQtyColumn.ColumnName, 33, 0, 4, 2, 40);
            ColInfo.SetColInfo(Band, _carInfoJoinParts.GenkaColumn.ColumnName, 37, 0, 4, 2, 40);
            ColInfo.SetColInfo(Band, _carInfoJoinParts.ArarirituColumn.ColumnName, 41, 0, 4, 2, 40);

            ColInfo.SetColInfo(Band, _carInfoJoinParts.EquipSpecialNoteColumn.ColumnName, 3, 2, 15, 2, 150);
            ColInfo.SetColInfo(Band, _carInfoJoinParts.JoinDestPartsNoColumn.ColumnName, 18, 2, 9, 2, 90);
            ColInfo.SetColInfo(Band, _carInfoJoinParts.ShelfColumn.ColumnName, 27, 2, 3, 2, 30);
            ColInfo.SetColInfo(Band, _carInfoJoinParts.StockCntColumn.ColumnName, 30, 2, 3, 2, 30);
            ColInfo.SetColInfo(Band, _carInfoJoinParts.PriceColumn.ColumnName, 33, 2, 4, 2, 40);
            ColInfo.SetColInfo(Band, _carInfoJoinParts.UrikaColumn.ColumnName, 37, 2, 4, 2, 40);
            ColInfo.SetColInfo(Band, _carInfoJoinParts.ArarigakuColumn.ColumnName, 41, 2, 4, 2, 40);
            if (substFlg == 0) // ��ւ��Ȃ�
            {
                Band.Columns[_carInfoJoinParts.SubstColumn.ColumnName].Hidden = true;
            }
            else
            {
                ColInfo.SetColInfo(Band, _carInfoJoinParts.SubstColumn.ColumnName, 45, 0, 1, 4, 15);
            }
            //ColInfo.SetColInfo(Band, _carInfoJoinParts.JoinDestMakerNmColumn.ColumnName, 4, 0, 6, 2, 60);
            //ColInfo.SetColInfo(Band, _carInfoJoinParts.JoinDestPartsNoColumn.ColumnName, 10, 0, 4, 2, 40);
            //ColInfo.SetColInfo(Band, _carInfoJoinParts.PrimePartsNameColumn.ColumnName, 14, 0, 12, 2, 120);
            //ColInfo.SetColInfo(Band, _carInfoJoinParts.KubunColumn.ColumnName, 26, 0, 6, 2, 60);
            //ColInfo.SetColInfo(Band, _carInfoJoinParts.JoinQtyColumn.ColumnName, 32, 0, 4, 2, 40);
            //ColInfo.SetColInfo(Band, _carInfoJoinParts.GenkaColumn.ColumnName, 36, 0, 4, 2, 40);
            //ColInfo.SetColInfo(Band, _carInfoJoinParts.ArarirituColumn.ColumnName, 40, 0, 4, 2, 40);

            //ColInfo.SetColInfo(Band, _carInfoJoinParts.EquipSpecialNoteColumn.ColumnName, 4, 2, 19, 2, 190);
            //ColInfo.SetColInfo(Band, _carInfoJoinParts.WarehouseColumn.ColumnName, 23, 2, 3, 2, 30);
            //ColInfo.SetColInfo(Band, _carInfoJoinParts.ShelfColumn.ColumnName, 26, 2, 3, 2, 30);
            //ColInfo.SetColInfo(Band, _carInfoJoinParts.StockCntColumn.ColumnName, 29, 2, 4, 2, 30);

            //ColInfo.SetColInfo(Band, _carInfoJoinParts.PriceColumn.ColumnName, 32, 2, 4, 2, 40);
            //ColInfo.SetColInfo(Band, _carInfoJoinParts.UrikaColumn.ColumnName, 36, 2, 4, 2, 40);
            //ColInfo.SetColInfo(Band, _carInfoJoinParts.ArarigakuColumn.ColumnName, 40, 2, 4, 2, 40);

            //ColInfo.SetColInfo(Band, _carInfoJoinParts.SubstColumn.ColumnName, 44, 0, 2, 4, 15);

            Band.Columns[_carInfoJoinParts.PriceColumn.ColumnName].Format = "C";
            Band.Columns[_carInfoJoinParts.GenkaColumn.ColumnName].Format = "C";
            Band.Columns[_carInfoJoinParts.UrikaColumn.ColumnName].Format = "C";
            Band.Columns[_carInfoJoinParts.ArarigakuColumn.ColumnName].Format = "C";
            Band.Columns[_carInfoJoinParts.ArarirituColumn.ColumnName].Format = "#%";
            Band.Columns[_carInfoJoinParts.JoinDestMakerCdColumn.ColumnName].Format = "0000";
            Band.Columns[_carInfoJoinParts.StockCntColumn.ColumnName].Format = "###,###,##0.00";
            Band.Columns[_carInfoJoinParts.JoinQtyColumn.ColumnName].Format = "###,###,##0.00";
        }

        /// <summary>
        /// �A�N�e�B�u�s�ύX��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridTBO_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 DEL
            //bool enaSubst = false;
            //try
            //{
            //    if (gridTBO.ActiveRow == null)
            //        return;
            //    enaSubst = (gridTBO.ActiveRow.Cells[_carInfoJoinParts.SubstColumn.ColumnName].Value != System.DBNull.Value);
            //    string filter = string.Format("{0}={1} AND {2}='{3}'",
            //                _dataSet.Stock.GoodsMakerCdColumn.ColumnName,
            //                gridTBO.ActiveRow.Cells[_carInfoJoinParts.JoinDestMakerCdColumn.ColumnName].Value,
            //                _dataSet.Stock.GoodsNoColumn.ColumnName,
            //                gridTBO.ActiveRow.Cells[_carInfoJoinParts.JoinDestPartsNoColumn.ColumnName].Value);
            //    _dataSet.Stock.DefaultView.RowFilter = filter;
            //    SetStockGridSelect();
            //}
            //finally
            //{
            //    ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled = enaSubst;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
            FilteringStockGrid();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
        /// <summary>
        /// �݌ɃO���b�h�i�荞�ݓK�p����(gridTBO_AfterSelectChange���R�����g�A�E�g���ē��e���ڍs)
        /// </summary>
        /// <br>Update Note : 2009/11/13 ����� �ێ�˗��B�Ή�</br>
        /// <br>            �@�݌ɏ��\���̏C��</br>
        private void FilteringStockGrid()
        {
            bool enaSubst = false;
            try
            {
                // --- UPD 2009/11/13 ---------->>>>> 
                if (gridTBO.ActiveRow == null)
                {
                    string filter2 = string.Format("{0}={1} AND {2}='{3}'",
                            _dataSet.Stock.GoodsMakerCdColumn.ColumnName, 0,
                            _dataSet.Stock.GoodsNoColumn.ColumnName, "");
                                    _dataSet.Stock.DefaultView.RowFilter = filter2;
                    return;
                }
                // --- UPD 2009/11/13 ----------<<<<<
                enaSubst = (gridTBO.ActiveRow.Cells[_carInfoJoinParts.SubstColumn.ColumnName].Value != System.DBNull.Value);
                string filter = string.Format( "{0}={1} AND {2}='{3}'",
                            _dataSet.Stock.GoodsMakerCdColumn.ColumnName,
                            gridTBO.ActiveRow.Cells[_carInfoJoinParts.JoinDestMakerCdColumn.ColumnName].Value,
                            _dataSet.Stock.GoodsNoColumn.ColumnName,
                            gridTBO.ActiveRow.Cells[_carInfoJoinParts.JoinDestPartsNoColumn.ColumnName].Value );
                _dataSet.Stock.DefaultView.RowFilter = filter;
                SetStockGridSelect();
            }
            finally
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled = enaSubst;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD

        /// <summary>
        /// �s���_�u���N���b�N���ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// �f�[�^���\������Ă��Ȃ��s���_�u���N���b�N���Ă��{�C�x���g�͔������Ȃ��B
        /// </remarks>
        private void gridTBO_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SetSelect(false);
        }

        /// <summary>
        /// �O���b�h���Enter�L�[�������ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridTBO_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SetSelect(true);
                    break;
            }
        }

        /// <summary>
        /// Enter�L�[(�_�u���N���b�N)�ɂ��I������
        /// </summary>
        /// <param name="moveFlg">true:���̍s��I����ԂɁ^false:�Ȃɂ����Ȃ��i�}�E�X�_�u���N���b�N���j</param>
        private void SetSelect(bool moveFlg)
        {
            UltraGridRow activeRow = gridTBO.ActiveRow;
            if (activeRow != null)
            {
                CellsCollection activeCells = activeRow.Cells;
                if (activeRow.Band.ParentBand == null // �e�o���h��(�q�o���h�͎ԗ����̂��߁j
                    && enterFlg != 2) // �iPM.NS�������Enter�L�[���u����ʁv�j�ȊO��
                {
                    if (activeCells[_carInfoJoinParts.SelImageColumn.ColumnName].Value != DBNull.Value)
                    {
                        activeCells[_carInfoJoinParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                        activeCells[_carInfoJoinParts.SelectionStateColumn.ColumnName].Value = false;
                        if (_orgDataSet.ListSelectionInfo.ContainsKey(activeRow.ListIndex)) // �I���������镔�i�̌�����Ȃǂ̑I����ԉ���
                        {
                            _orgDataSet.ListSelectionInfo.Remove(activeRow.ListIndex);
                        }
                    }
                    else
                    {
                        activeCells[_carInfoJoinParts.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                        activeCells[_carInfoJoinParts.SelectionStateColumn.ColumnName].Value = true;
                    }
                    _carInfoJoinParts.AcceptChanges();
                }
                switch (enterFlg) // �G���^�[�L�[�����敪
                {
                    case 2: // Enter�L�[���u����ʁv�̏ꍇ
                        foreach (UltraGridRow row in gridTBO.Rows) // ����ʂ̎��͑I���s�ȊO�͑I����������
                        {
                            if (row.Equals(activeRow) == false && row.Cells[_carInfoJoinParts.SelImageColumn.ColumnName].Value != DBNull.Value)
                            {
                                row.Cells[_carInfoJoinParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                                row.Cells[_carInfoJoinParts.SelectionStateColumn.ColumnName].Value = false;
                                if (_orgDataSet.ListSelectionInfo.ContainsKey(row.ListIndex))
                                {
                                    _orgDataSet.ListSelectionInfo.Remove(row.ListIndex);
                                }
                            }
                        }
                        DialogResult = DialogResult.OK;
                        activeCells[_carInfoJoinParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                        activeCells[_carInfoJoinParts.SelectionStateColumn.ColumnName].Value = true;
                        break;
                    default: // Enter�L�[���u�I���v�uPM7�v�̏ꍇ�F�����I�𓮍�̂��ߎ��s��I����ԂƂ���B
                        if (moveFlg)
                        {
                            UltraGridRow ugr = activeRow.GetSibling(SiblingRow.Next);
                            if (ugr != null)
                            {
                                ugr.Selected = true;
                                ugr.Activate();
                            }
                        }
                        break;
                }
            }
        }

        private void gridKind_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // �񕝂̎����������@
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;
            e.Layout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // �o���h�̎擾
            UltraGridBand Band = e.Layout.Bands[0];
            Band.Indentation = 0;
            Band.Override.RowSizing = RowSizing.Fixed;
            Band.Override.AllowColSizing = AllowColSizing.None;
            Band.UseRowLayout = true;

            for (int Index = 0; Index < Band.Columns.Count; Index++)
            {
                // �����\���ʒu
                if ((Band.Columns[Index].DataType == typeof(int)) ||
                   (Band.Columns[Index].DataType == typeof(double)) ||
                   (Band.Columns[Index].DataType == typeof(Int64)))
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (Band.Columns[Index].DataType == typeof(Image))
                {
                    Band.Columns[Index].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                }
                else
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                Band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // �����\���ʒu
                Band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            Band.Columns[_orgCtgEquip.EquipmentCodeColumn.ColumnName].Hidden = true;
            //Band.Columns[_orgCtgEquip.EquipmentComment1Column.ColumnName].Hidden = true;
            Band.Columns[_orgCtgEquip.EquipmentComment2Column.ColumnName].Hidden = true;
            Band.Columns[_orgCtgEquip.EquipmentDispOrderColumn.ColumnName].Hidden = true;
            Band.Columns[_orgCtgEquip.EquipmentGenreCdColumn.ColumnName].Hidden = true;
            Band.Columns[_orgCtgEquip.EquipmentGenreNmColumn.ColumnName].Hidden = true;
            Band.Columns[_orgCtgEquip.EquipmentIconCodeColumn.ColumnName].Hidden = true;
            Band.Columns[_orgCtgEquip.EquipmentMngCodeColumn.ColumnName].Hidden = true;
            Band.Columns[_orgCtgEquip.EquipmentShortNameColumn.ColumnName].Hidden = true;
            Band.Columns[_orgCtgEquip.EquipmentUnitCodeColumn.ColumnName].Hidden = true;
            Band.Columns[_orgCtgEquip.TbsPartsCodeColumn.ColumnName].Hidden = true;
            Band.Columns[_orgCtgEquip.SelectionStateColumn.ColumnName].Hidden = true;

            ColInfo.SetColInfo(Band, _orgCtgEquip.EquipmentNameColumn.ColumnName, 2, 0, 80);
            ColInfo.SetColInfo(Band, _orgCtgEquip.EquipmentMngNameColumn.ColumnName, 4, 0, 40);
            ColInfo.SetColInfo(Band, _orgCtgEquip.EquipmentCntColumn.ColumnName, 6, 0, 15);
            ColInfo.SetColInfo(Band, _orgCtgEquip.EquipmentUnitNameColumn.ColumnName, 8, 0, 15);
            ColInfo.SetColInfo(Band, _orgCtgEquip.EquipmentComment1Column.ColumnName, 10, 0, 100);
        }

        private void gridKind_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            string equipmentMngName = string.Empty;
            string equipName = string.Empty;
            string rowFilter;
            if (gridKind.Selected.Rows.Count > 0)
            {
                equipmentMngName = gridKind.Selected.Rows[0].Cells[_orgCtgEquip.EquipmentMngNameColumn.ColumnName].Value.ToString();
                equipName = gridKind.Selected.Rows[0].Cells[_orgCtgEquip.EquipmentNameColumn.ColumnName].Value.ToString();
            }
            if (equipmentMngName == string.Empty) // �i�������N���A���i�O���b�h�_�u���N���b�N�ɂ��i���������j
            {
                rowFilter2 = string.Empty;
                rowFilter = rowFilter1;
            }
            else
            {
                rowFilter2 = String.Format("{0} = '{1}' AND {2} = '{3}'",
                    _carInfoJoinParts.KubunColumn.ColumnName, equipmentMngName,
                    _carInfoJoinParts.EquipNameColumn.ColumnName, equipName);
                if (rowFilter1 != string.Empty)
                    rowFilter = rowFilter1 + " AND " + rowFilter2;
                else
                    rowFilter = rowFilter2;
            }
            //----ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�---->>>>>
            if (rowFilter3 != string.Empty)
            {
                if (rowFilter != string.Empty)
                    rowFilter += " AND ";
                rowFilter += rowFilter3;
            }
            //----ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�----<<<<<
            if (rowFilterMaker != string.Empty)
            {
                rowFilter += " AND " + rowFilterMaker;
            }

            _carInfoJoinParts.DefaultView.RowFilter = rowFilter;
            selectionChanged = true;

            if (gridTBO.Rows.Count > 0)
            {
                gridTBO.Select();
                gridTBO.Rows[0].Activate();
                gridTBO.Rows[0].Selected = true;
            }

            // --- ADD 2009/11/13 ---------->>>>> 
            // �݌ɃO���b�h�i�荞�ݓK�p����
            this.FilteringStockGrid();
            // --- ADD 2009/11/13 ----------<<<<<
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
        private void FilteringCarInfoJoinParts()
        {
            string equipmentMngName = string.Empty;
            string equipName = string.Empty;
            string rowFilter;
            if ( gridKind.Selected.Rows.Count > 0 )
            {
                equipmentMngName = gridKind.Selected.Rows[0].Cells[_orgCtgEquip.EquipmentMngNameColumn.ColumnName].Value.ToString();
                equipName = gridKind.Selected.Rows[0].Cells[_orgCtgEquip.EquipmentNameColumn.ColumnName].Value.ToString();
            }
            if ( equipmentMngName == string.Empty ) // �i�������N���A���i�O���b�h�_�u���N���b�N�ɂ��i���������j
            {
                rowFilter2 = string.Empty;
                rowFilter = rowFilter1;
            }
            else
            {
                rowFilter2 = String.Format( "{0} = '{1}' AND {2} = '{3}'",
                    _carInfoJoinParts.KubunColumn.ColumnName, equipmentMngName,
                    _carInfoJoinParts.EquipNameColumn.ColumnName, equipName );
                if ( rowFilter1 != string.Empty )
                    rowFilter = rowFilter1 + " AND " + rowFilter2;
                else
                    rowFilter = rowFilter2;
            }
            //----ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�---->>>>>
            if (rowFilter3 != string.Empty)
            {
                if (rowFilter != string.Empty)
                    rowFilter += " AND ";
                rowFilter += rowFilter3;
            }
            //----ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�----<<<<<
            if ( rowFilterMaker != string.Empty )
            {
                rowFilter += " AND " + rowFilterMaker;
            }

            _carInfoJoinParts.DefaultView.RowFilter = rowFilter;
            selectionChanged = true;

            if ( gridTBO.Rows.Count > 0 )
            {
                gridTBO.Select();
                gridTBO.Rows[0].Activate();
                gridTBO.Rows[0].Selected = true;
            }

            // --- ADD 2009/11/13 ---------->>>>> 
            // �݌ɃO���b�h�i�荞�ݓK�p����
            this.FilteringStockGrid();
            // --- ADD 2009/11/13 ----------<<<<<
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD

        private void gridKind_Click(object sender, EventArgs e)
        {
            if (selectionChanged == true)
            {
                selectionChanged = false;
            }
            else
            {
                gridKind.Selected.Rows.Clear();
                gridKind.ActiveRow = null;
                //rowFilter2 = string.Empty;
                //string rowFilter = rowFilter1;
                //_carInfoJoinParts.DefaultView.RowFilter = rowFilter;
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

            band.Columns[_dataSet.Stock.SelectionStateColumn.ColumnName].Hidden = true;
            band.Columns[_dataSet.Stock.GoodsMakerCdColumn.ColumnName].Hidden = true;
            band.Columns[_dataSet.Stock.GoodsNoColumn.ColumnName].Hidden = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            band.Columns[_dataSet.Stock.SortDivColumn.ColumnName].Hidden = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
            for (int Index = 0; Index < band.Columns.Count; Index++)
            {
                // �����\���ʒu
                if ((band.Columns[Index].DataType == typeof(int)) ||
                   (band.Columns[Index].DataType == typeof(Int64)))
                {
                    band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (band.Columns[Index].DataType == typeof(Image))
                {
                    band.Columns[Index].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    band.Columns[Index].CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                }
                else
                {
                    band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // �����\���ʒu
                band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            ColInfo.SetColInfo( band, _dataSet.Stock.SelImageColumn.ColumnName, 0, 0, 10 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
            ColInfo.SetColInfo(band, _dataSet.Stock.WarehouseCodeColumn.ColumnName, 2, 0, 50);
            ColInfo.SetColInfo(band, _dataSet.Stock.WarehouseNameColumn.ColumnName, 5, 0, 100);
            ColInfo.SetColInfo(band, _dataSet.Stock.WarehouseShelfNoColumn.ColumnName, 7, 0, 50);
            ColInfo.SetColInfo(band, _dataSet.Stock.ShipmentPosCntColumn.ColumnName, 9, 0, 50);
            ColInfo.SetColInfo(band, _dataSet.Stock.MinimumStockCntColumn.ColumnName, 11, 0, 50);
            ColInfo.SetColInfo(band, _dataSet.Stock.MaximumStockCntColumn.ColumnName, 13, 0, 50);
            band.Columns[_dataSet.Stock.ShipmentPosCntColumn.ColumnName].Format = "###,###,##0.00";
            band.Columns[_dataSet.Stock.MinimumStockCntColumn.ColumnName].Format = "###,###,##0.00";
            band.Columns[_dataSet.Stock.MaximumStockCntColumn.ColumnName].Format = "###,###,##0.00";
        }

        private void gridStock_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/30 DEL
            //if (gridStock.ActiveRow != null && gridTBO.ActiveRow != null)
            //{
            //    gridTBO.ActiveRow.Cells[_carInfoJoinParts.WarehouseColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_dataSet.Stock.WarehouseCodeColumn.ColumnName].Value;
            //    gridTBO.ActiveRow.Cells[_carInfoJoinParts.ShelfColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_dataSet.Stock.WarehouseShelfNoColumn.ColumnName].Value;
            //    gridTBO.ActiveRow.Cells[_carInfoJoinParts.StockCntColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_dataSet.Stock.ShipmentPosCntColumn.ColumnName].Value;
            //    gridTBO.ActiveRow.Cells[_carInfoJoinParts.WarehouseCodeColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
            //    gridStock.ActiveRow.Cells[_dataSet.Stock.SelectionStateColumn.ColumnName].Value = true;
            //    gridTBO.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/30 DEL
        }

        private void gridStock_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/30 DEL
            //if (gridStock.Selected.Rows.Count > 0)
            //    gridStock.Selected.Rows[0].Cells[_dataSet.Stock.SelectionStateColumn.ColumnName].Value = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/30 DEL
        }

        /// <summary>
        /// �݌ɃO���b�h�I�������i���[�U�[�I�����D��q�Ɂ��擪�s�̏��őI���j
        /// </summary>
        private void SetStockGridSelect()
        {
            if (gridTBO.ActiveRow.Cells[_carInfoJoinParts.WarehouseCodeColumn.ColumnName].Value.Equals(string.Empty) == false)
            {
                for (int i = 0; i < gridStock.Rows.Count; i++)
                {
                    if (gridStock.Rows[i].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value
                        .Equals(gridTBO.ActiveRow.Cells[_carInfoJoinParts.WarehouseCodeColumn.ColumnName].Value))
                    {
                        gridStock.Rows[i].Activate();
                        gridStock.Rows[i].Selected = true;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
                        SetSelectStock( false, true );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
                        return;
                    }
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                // �݌ɂ�S�đI������������A�t�H�[�J�X�͐擪�̍݌�
                if ( gridStock.Rows.Count > 0 )
                {
                    gridStock.Rows[0].Activate();
                    gridStock.Rows[0].Selected = true;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
            else
            {
                // �݌ɖ��I��(��񈵂�)�Ȃ�΍݌ɍs�̑I������
                foreach ( UltraGridRow row in gridStock.Rows )
                {
                    if ( row.Cells[_StockTable.SelImageColumn.ColumnName].Value != DBNull.Value )
                    {
                        row.Cells[_StockTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                        row.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
                    }
                }
                // �݌ɂ�S�đI������������A�t�H�[�J�X�͐擪�̍݌�
                if ( gridStock.Rows.Count > 0 )
                {
                    gridStock.Rows[0].Activate();
                    gridStock.Rows[0].Selected = true;
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/30 DEL
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
            //    gridTBO.ActiveRow.Cells[_carInfoJoinParts.WarehouseColumn.ColumnName].Value = string.Empty;
            //    gridTBO.ActiveRow.Cells[_carInfoJoinParts.ShelfColumn.ColumnName].Value = string.Empty;
            //    gridTBO.ActiveRow.Cells[_carInfoJoinParts.StockCntColumn.ColumnName].Value = 0;
            //    gridTBO.ActiveRow.Cells[_carInfoJoinParts.WarehouseCodeColumn.ColumnName].Value = string.Empty;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/30 DEL
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
        /// <summary>
        /// �݌ɃO���b�h�EEnter�L�[(�_�u���N���b�N)�ɂ��I������
        /// </summary>
        /// <param name="moveFlg"></param>
        private void SetSelectStock( bool moveFlg )
        {
            SetSelectStock( moveFlg, false );
        }
        /// <summary>
        /// �݌ɃO���b�h�EEnter�L�[(�_�u���N���b�N)�ɂ��I������
        /// </summary>
        /// <param name="moveFlg">true:���̍s��I����ԂɁ^false:�Ȃɂ����Ȃ��i�}�E�X�_�u���N���b�N���j</param>
        /// <param name="setTrue">true:�I�����TRUE�ɂ���^�I����Ԃ𔽓]����</param>
        private void SetSelectStock( bool moveFlg, bool setTrue )
        {
            UltraGridRow activeRow = gridStock.ActiveRow;
            if ( activeRow != null )
            {
                CellsCollection activeCells = activeRow.Cells;

                // �I��/��I���̐؂�ւ�
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

                // ���̍s�͑I����������
                # region [���̍s�͑I����������]
                foreach ( UltraGridRow row in gridStock.Rows )
                {
                    if ( row.Equals( activeRow ) == false && row.Cells[_StockTable.SelImageColumn.ColumnName].Value != DBNull.Value )
                    {
                        row.Cells[_StockTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                        row.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
                    }
                }
                # endregion

                // ���i�O���b�h�̍݌ɏ��\�����X�V
                # region [���i�O���b�h�̍݌ɏ��\�����X�V]
                if ( gridTBO.ActiveRow != null )
                {
                    if ( (bool)activeCells[_StockTable.SelectionStateColumn.ColumnName].Value == true )
                    {
                        // ���i�O���b�h�ɍ݌ɏ��\��
                        gridTBO.ActiveRow.Cells[_carInfoJoinParts.WarehouseColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
                        gridTBO.ActiveRow.Cells[_carInfoJoinParts.ShelfColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
                        gridTBO.ActiveRow.Cells[_carInfoJoinParts.StockCntColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
                        gridTBO.ActiveRow.Cells[_carInfoJoinParts.WarehouseCodeColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
                    }
                    else
                    {
                        // ���i�O���b�h�̍݌ɏ����N���A
                        gridTBO.ActiveRow.Cells[_carInfoJoinParts.WarehouseColumn.ColumnName].Value = string.Empty;
                        gridTBO.ActiveRow.Cells[_carInfoJoinParts.ShelfColumn.ColumnName].Value = string.Empty;
                        gridTBO.ActiveRow.Cells[_carInfoJoinParts.StockCntColumn.ColumnName].Value = 0;
                        gridTBO.ActiveRow.Cells[_carInfoJoinParts.WarehouseCodeColumn.ColumnName].Value = string.Empty;
                    }
                    gridTBO.UpdateData();
                }
                # endregion
            }
        }
        /// <summary>
        /// �݌ɃO���b�h�E�s�_�u���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_DoubleClickRow( object sender, DoubleClickRowEventArgs e )
        {
            SetSelectStock( false );
        }
        /// <summary>
        /// �݌ɃO���b�h�E�L�[�_�E��
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
        #endregion

        #region [ �i������ ]
        private void lblmaker_Click(object sender, EventArgs e)
        {
            if (pnlMaker.Visible)
            {
                pnlMaker.Visible = false;
            }
            else
            {
                pnlMaker.Visible = true;
                gridMaker.Select();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            pnlMaker.Visible = false;
            //----ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�---->>>>>
            if (gridTBO.Rows.Count > 0)
            {
                gridTBO.Select();
                gridTBO.Rows[0].Activate();
                gridTBO.Rows[0].Selected = true;
            }
            //----ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�----<<<<<<
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridMaker.Rows.Count; i++)
            {
                gridMaker.Rows[i].Cells[_dataSet.Maker.SelImgColumn.ColumnName].Value = DBNull.Value;
            }
            rowFilterMaker = string.Empty;
            string rowFilter = rowFilter1;
            if (rowFilter2 != string.Empty)
            {
                if (rowFilter != string.Empty)
                    rowFilter += " AND ";
                rowFilter += rowFilter2;
            }
            _carInfoJoinParts.DefaultView.RowFilter = rowFilter;
            pnlMaker.Visible = false;
            //----ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�---->>>>>
            if (gridTBO.Rows.Count > 0)
            {
                gridTBO.Select();
                gridTBO.Rows[0].Activate();
                gridTBO.Rows[0].Selected = true;
            }
            //----ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�----<<<<<<
        }

        private void gridMaker_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand Band = e.Layout.Bands[0];
            Band.UseRowLayout = true;
            Band.Columns[_dataSet.Maker.EquipGenreCodeColumn.ColumnName].Hidden = true;
            ColInfo.SetColInfo(Band, _dataSet.Maker.SelImgColumn.ColumnName, 2, 0, 2, 2, 20);
            ColInfo.SetColInfo(Band, _dataSet.Maker.MakerCdColumn.ColumnName, 4, 0, 3, 2, 30);
            ColInfo.SetColInfo(Band, _dataSet.Maker.MakerNmColumn.ColumnName, 7, 0, 16, 2, 160);
            Band.Columns[_dataSet.Maker.SelImgColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            Band.Columns[_dataSet.Maker.MakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Band.Columns[_dataSet.Maker.MakerCdColumn.ColumnName].Format = "0000";
        }

        private void gridMaker_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            CellsCollection activeCells = e.Row.Cells;
            if (activeCells[_dataSet.Maker.SelImgColumn.ColumnName].Value != DBNull.Value)
            {
                activeCells[_dataSet.Maker.SelImgColumn.ColumnName].Value = DBNull.Value;
            }
            else
            {
                activeCells[_dataSet.Maker.SelImgColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
            }
            rowFilterMaker = string.Empty;
            for (int i = 0; i < gridMaker.Rows.Count; i++)
            {
                if (gridMaker.Rows[i].Cells[_dataSet.Maker.SelImgColumn.ColumnName].Value != DBNull.Value)
                {
                    rowFilterMaker += string.Format("{0}={1} OR ",
                        _carInfoJoinParts.JoinDestMakerCdColumn.ColumnName,
                        gridMaker.Rows[i].Cells[_dataSet.Maker.MakerCdColumn.ColumnName].Value);
                }
            }
            if (rowFilterMaker.Length > 0)
            {
                rowFilterMaker = "(" + rowFilterMaker.Remove(rowFilterMaker.Length - 3) + ")";
            }
            Filtering();
        }

        private void pnlMaker_Leave(object sender, EventArgs e)
        {
            pnlMaker.Visible = false;
        }

        private void cmbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string equipGenreNm = cmbGenre.SelectedItem.ToString();
                int equipGenreCd = 0;
                string filter = String.Format( "{0} = '{1}'", _orgCtgEquip.EquipmentGenreNmColumn.ColumnName,
                                equipGenreNm );
                PMKEN01010E.CategoryEquipmentInfoRow[] cEIrows =
                    (PMKEN01010E.CategoryEquipmentInfoRow[])_orgCtgEquip.Select( filter );
                if ( cEIrows.Length > 0 )
                {
                    equipGenreCd = cEIrows[0].EquipmentGenreCd;
                }

                rowFilter1 = String.Format( "{0} = {1}", _carInfoJoinParts.EquipGenreCodeColumn.ColumnName,
                                  equipGenreCd );
                string rowFilter;
                rowFilter = rowFilter1;
                rowFilter2 = string.Empty;
                rowFilterMaker = string.Empty;
                _carInfoJoinParts.DefaultView.RowFilter = rowFilter;
                _dataSet.Maker.DefaultView.RowFilter = rowFilter;

                string rowFilterCar = string.Format( "{0} = {1}", _orgCtgEquip.EquipmentGenreCdColumn.ColumnName,
                                  equipGenreCd );
                _orgCtgEquip.DefaultView.RowFilter = rowFilterCar;

                cmbSoubiNm.Items.Clear();
                cmbSoubiNm.Items.Add( string.Empty );
                for ( int i = 0; i < _orgCtgEquip.DefaultView.Count; i++ )
                {
                    PMKEN01010E.CategoryEquipmentInfoRow rowCE = (PMKEN01010E.CategoryEquipmentInfoRow)_orgCtgEquip.DefaultView[i].Row;
                    cmbSoubiNm.Items.Add( string.Format( "{0}[{1}]", rowCE.EquipmentName, rowCE.EquipmentMngName ) );
                }
                rowFilter3 = string.Empty; // BL�ɂ��i�������N���A
                cmbBL.Items.Clear();
                cmbBL.Items.Add( string.Empty );
                for ( int i = 0; i < _carInfoJoinParts.DefaultView.Count; i++ )
                {
                    TBO.TBOInfoRow rowTBO = (TBO.TBOInfoRow)_carInfoJoinParts.DefaultView[i].Row;
                    if ( rowTBO.TbsPartsCode != 0 && cmbBL.Items.Contains( rowTBO.TbsPartsCode ) == false )
                    {
                        cmbBL.Items.Add( rowTBO.TbsPartsCode );
                    }
                }
                Filtering();

                if ( gridTBO.Rows.Count > 0 )
                {
                    gridTBO.Select();
                    gridTBO.Rows[0].Activate();
                    gridTBO.Rows[0].Selected = true;
                }

                // --- ADD 2009/11/13 ---------->>>>> 
                // �݌ɃO���b�h�i�荞�ݓK�p����
                this.FilteringStockGrid();
                // --- ADD 2009/11/13 ----------<<<<<

                //----ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�---->>>>>
                // �A�N�e�B�u��������
                if (gridKind.ActiveRow != null)
                {
                    gridKind.ActiveRow = null;
                }
                gridKind.Selected.Rows.Clear();
                //----ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�----<<<<<
            }
            catch
            {
            }
        }

        private void cmbSoubiNm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/30 DEL
                //if ( cmbSoubiNm.SelectedIndex == 0 )
                //{
                //    gridKind.Selected.Rows.Clear();
                //    cmbGenre_SelectedIndexChanged( this, new EventArgs() );
                //}
                //else
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/30 DEL
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/30 DEL
                    //string equipGenreNm = cmbGenre.SelectedItem.ToString();
                    //int equipGenreCd = 0;
                    //string filter = String.Format( "{0} = '{1}'", _orgCtgEquip.EquipmentGenreNmColumn.ColumnName,
                    //                equipGenreNm );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/30 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/30 ADD
                    int equipGenreCd = 0;
                    string filter = string.Empty;

                    if ( cmbSoubiNm.SelectedItem != null )
                    {
                        string equipGenreNm = cmbSoubiNm.SelectedItem.ToString();

                        if ( equipGenreNm.Contains( "[" ) && equipGenreNm.Contains( "]" ) )
                        {
                            int ed = equipGenreNm.IndexOf( '[' ) - 1;
                            if ( ed >= 0 )
                            {
                                equipGenreNm = equipGenreNm.Substring( 0, ed + 1 );
                            }
                        }

                        if ( !string.IsNullOrEmpty( equipGenreNm ) )
                        {
                            filter = String.Format( "{0} = '{1}'", _orgCtgEquip.EquipmentNameColumn.ColumnName, equipGenreNm );
                        }
                        else
                        {
                            //----ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�---->>>>>
                            string equipGenreName = cmbGenre.SelectedItem.ToString();
                            filter = String.Format("{0} = '{1}'", _orgCtgEquip.EquipmentGenreNmColumn.ColumnName,
                                            equipGenreName);
                            //----ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�----<<<<<
                            //filter = string.Empty; //DEL BY ������ on 2013/04/19 for Redmine#34377�̑Ή�
                        }
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/30 ADD
                    PMKEN01010E.CategoryEquipmentInfoRow[] cEIrows =
                        (PMKEN01010E.CategoryEquipmentInfoRow[])_orgCtgEquip.Select( filter );
                    if ( cEIrows.Length > 0 )
                    {
                        equipGenreCd = cEIrows[0].EquipmentGenreCd;
                    }
                    string sel = cmbSoubiNm.SelectedItem.ToString();
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 DEL
                    //string equipNm = sel.Substring( 0, sel.IndexOf( '[' ) );
                    //string kubun = sel.Substring( sel.IndexOf( '[' ) + 1, sel.IndexOf( ']' ) - sel.IndexOf( '[' ) - 1 );

                    //string rowFilterCar = string.Format( "{0}={1} AND {2}='{3}' AND {4}='{5}'",
                    //     _orgCtgEquip.EquipmentGenreCdColumn.ColumnName, equipGenreCd,
                    //     _orgCtgEquip.EquipmentMngNameColumn.ColumnName, kubun,
                    //     _orgCtgEquip.EquipmentNameColumn.ColumnName, equipNm );
                    //_orgCtgEquip.DefaultView.RowFilter = rowFilterCar;
                    //if ( gridKind.Rows.Count > 0 )
                    //{
                    //    gridKind.Rows[0].Activate();
                    //    gridKind.Rows[0].Selected = true;
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
                    string rowFilterCar = string.Empty;

                    if ( !string.IsNullOrEmpty( sel ) )
                    {
                        string equipNm = sel.Substring( 0, sel.IndexOf( '[' ) );
                        string kubun = sel.Substring( sel.IndexOf( '[' ) + 1, sel.IndexOf( ']' ) - sel.IndexOf( '[' ) - 1 );

                        rowFilterCar = string.Format( "{0}={1} AND {2}='{3}' AND {4}='{5}'",
                             _orgCtgEquip.EquipmentGenreCdColumn.ColumnName, equipGenreCd,
                             _orgCtgEquip.EquipmentMngNameColumn.ColumnName, kubun,
                             _orgCtgEquip.EquipmentNameColumn.ColumnName, equipNm );

                        _orgCtgEquip.DefaultView.RowFilter = rowFilterCar;
                        if ( gridKind.Rows.Count > 0 )
                        {
                            gridKind.Rows[0].Activate();
                            gridKind.Rows[0].Selected = true;
                        }
                    }
                    else
                    {
                        rowFilterCar = string.Format( "{0}={1}",
                             _orgCtgEquip.EquipmentGenreCdColumn.ColumnName, equipGenreCd );

                        _orgCtgEquip.DefaultView.RowFilter = rowFilterCar;

                        // �A�N�e�B�u��������
                        if ( gridKind.ActiveRow != null )
                        {
                            gridKind.ActiveRow = null;
                        }
                        gridKind.Selected.Rows.Clear();
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
                    Filtering();
                    //rowFilter2 = String.Format("{0} = '{1}' AND {2} = '{3}'",
                    //    _carInfoJoinParts.KubunColumn.ColumnName, kubun,
                    //    _carInfoJoinParts.EquipNameColumn.ColumnName, equipNm);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
                    FilteringCarInfoJoinParts();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
                }
            }
            catch
            {
            }
        }

        private void cmbBL_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ( cmbBL.SelectedIndex == 0 )
                {
                    rowFilter3 = string.Empty;
                }
                else
                {
                    rowFilter3 = string.Format( "{0}={1}", _carInfoJoinParts.TbsPartsCodeColumn.ColumnName, cmbBL.SelectedItem );
                }
                Filtering();
                //----ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�---->>>>>
                if (gridTBO.Rows.Count > 0)
                {
                    gridTBO.Select();
                    gridTBO.Rows[0].Activate();
                    gridTBO.Rows[0].Selected = true;
                }
                //----ADD BY ������ on 2013/04/19 for Redmine#34377�̑Ή�----<<<<<<
            }
            catch
            {
            }
        }

        /// <summary>
        /// �e�i�������ɂ��i������
        /// </summary>
        private void Filtering()
        {
            string rowFilter = rowFilter1;
            if (rowFilter2 != string.Empty)
            {
                if (rowFilter != string.Empty)
                    rowFilter += " AND ";
                rowFilter += rowFilter2;
            }
            if (rowFilter3 != string.Empty)
            {
                if (rowFilter != string.Empty)
                    rowFilter += " AND ";
                rowFilter += rowFilter3;
            }
            if (rowFilterMaker != string.Empty)
            {
                if (rowFilter != string.Empty)
                    rowFilter += " AND ";
                rowFilter += rowFilterMaker;
            }
            _carInfoJoinParts.DefaultView.RowFilter = rowFilter;
        }
        #endregion
    }
}