using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Globarization;// ADD 杍^  2019/01/08 FOR �V�����̑Ή�

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
    /// <br>            : �݌ɂ̑I����@���`�F�b�N�����ɕύX�i���`�F�b�N�Ŏ���I���\�ɕύX�j</br>
    /// <br>Programmer	: 22018�@��� ���b</br>
    /// <br>Date		: 2009.03.31</br>
    /// <br></br>
    /// <br>Update Note	: ��֕\���̏C��</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009/10/19</br>
    /// <br></br>
    /// <br>Update Note	: 11470076-00 �V�����̑Ή�</br>
    /// <br>Programmer	: 杍^</br>
    /// <br>Date		: 2019/01/08</br>
    /// </remarks>
    public partial class SelectionPrimeBLParts : Form
    {
        #region [ Private Member ]
        /// <summary>�f�[�^�Z�b�g</summary>
        private OriginalParts _dataSet = null;
        private PartsInfoDataSet _orgDataSet = null;
        private OriginalParts.OfrPrimePartsDataTable _primeSearchParts = null;
        private OriginalParts.ModelPartsDetailDataTable _partsDetailTable = null;
        private OriginalParts.StockDataTable _StockTable = null;
        private PartsInfoDataSet.UsrGoodsInfoRow _prevRow = null;

        private int _mode; // 0:�ʏ�@1:�������ϐ�p

        private bool isSelectChangeDisabled = false;
        private readonly int conditionCellCount = 15;
        private Dictionary<RowFilterKind, string> rowFilterList = new Dictionary<RowFilterKind, string>(18);
        private Dictionary<string, RowFilterKind> lstEnum = new Dictionary<string, RowFilterKind>(18);
        private List<string> colToShow;
        /// <summary>0:���Y�N�� 1:�V���V�[NO </summary>
        private int PartsNarrowing = 0;
        private bool eraNameDispDiv;    // false:����  true:�a��
        private bool uiControlFlg;      // false:PM7�X�^�C��   true:PM.NS�X�^�C��
        private int substFlg;          // 0:��ւ��Ȃ�  1:��ւ���i�݌ɔ��肠��j 2:��ւ���i�݌ɔ���Ȃ��j
        private int userSubstFlg;
        private int enterFlg;           // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
        private int totalAmountDispWay;       // ���z�\�����@�敪 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j

        private DateTimeFormatInfo dtfi;
        private SelectionInfo _prevSelInfo;
        private bool isDialogShown = true;
        /// <summary> �_�C�A���O���\���ۃt���O�i�f�[�^���ɂ�莩������j </summary>
        public bool IsDialogShown
        {
            get { return isDialogShown; }
        }
        #endregion

        #region [ �R���X�g���N�^ ]
        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        /// <param name="dsSource">�O���b�h�ɕ\������f�[�^���w�肵�܂��B</param>
        public SelectionPrimeBLParts(PartsInfoDataSet dsSource)
        {
            InitializeMain(dsSource);
        }

        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        /// <param name="dsSource">�O���b�h�ɕ\������f�[�^���w�肵�܂��B</param>
        /// <param name="mode">0:�ʏ�@1:�������ϐ�p</param>
        public SelectionPrimeBLParts(PartsInfoDataSet dsSource, int mode)
        {
            _mode = mode;
            InitializeMain(dsSource);
        }
        #endregion

        #region [ ������ ]
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="dsSource">�O���b�h�ɕ\������f�[�^���w�肵�܂��B</param>
        private void InitializeMain(PartsInfoDataSet dsSource)
        {
            _orgDataSet = dsSource;
            SearchCntSetWork cond = dsSource.SearchCondition.SearchCntSetWork;
            eraNameDispDiv = Convert.ToBoolean(cond.EraNameDispCd1); // 0:����^1:�a��
            uiControlFlg = Convert.ToBoolean(cond.SearchUICntDivCd); // 0:PM7�X�^�C���^1:PM.NS�X�^�C��
            substFlg = cond.PrmSubstCondDivCd; // 0:��ւ��Ȃ�  1:��ւ���i�݌ɔ��肠��j 2:��ւ���i�݌ɔ���Ȃ��j
            userSubstFlg = cond.SubstApplyDivCd;
            enterFlg = cond.EnterProcDivCd; // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
            totalAmountDispWay = cond.TotalAmountDispWayCd; // 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j
            if (eraNameDispDiv) // �a��\���̏ꍇ
            {
                dtfi = new CultureInfo("ja-JP").DateTimeFormat;
                dtfi.Calendar = new JapaneseCalendar();
            }

            InitializeComponent();
            InitializeTable();
            InitializeData();

            MakeConditionGridData();
            // �X�e�[�^�X�o�[�̏�����
            StatusBar.Panels[0].Text = "";
            // �c�[���o�[�̃C���[�W(16x16)�⃁�b�Z�[�W��ݒ肷��
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            ToolbarsManager.Tools["Button_Subst"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARADD;
            ToolbarsManager.Tools["Button_Set"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODEL;
            ToolbarsManager.Tools["Btn_Spec"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SUBMENU;
            ToolbarsManager.Tools["BtnClear"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            ToolbarsManager.Tools["BtnClear"].SharedProps.Visible = false;
            if (uiControlFlg && _mode == 0) // PM.NS����ʐ���@���@�ʏ탂�[�h
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODEL;
            }
            else// PM7����ʐ���@���́@�������ϐ�p���[�h
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.Visible = false;
            }
            if (substFlg != 0)
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARADD;
                //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            }
            else
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Visible = false;
            }
        }

        /// <summary>
        /// �e�[�u���쐬�y�уf�[�^�Z�b�g�ւ̒ǉ��A�����[�V�����ݒ�
        /// </summary>
        private void InitializeTable()
        {
            // DataTable �̐ݒ�
            _dataSet = new OriginalParts();
            _primeSearchParts = _dataSet.OfrPrimeParts;
            _partsDetailTable = _dataSet.ModelPartsDetail;
            _StockTable = _dataSet.Stock;

            gridOriginalP.DataSource = _dataSet.OfrPrimeParts.DefaultView;
            gridStock.DataSource = _StockTable.DefaultView;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
            SettingStockView( _StockTable.DefaultView );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
        /// <summary>
        /// �݌ɂ�DataSource�ƂȂ�View��ݒ肵�܂�
        /// </summary>
        /// <param name="dataView"></param>
        private void SettingStockView( DataView dataView )
        {
            // �\�[�g�ݒ�
            dataView.Sort = string.Format( "{0}, {1}",
                                            _StockTable.SortDivColumn.ColumnName,
                                            _StockTable.WarehouseCodeColumn.ColumnName );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD

        //---- ADD 杍^  2019/01/08 FOR �V�����̑Ή� ---->>>>>
        /// <summary>
        /// ���Y�N��������擾����
        /// </summary>
        /// <param name="produceTypeOfYear">���Y�N��</param>
        /// <remarks>
        /// <br>Note	   : ���Y�N����a��́uGG YY�NMM���v�`���ɕϊ�����</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/01/08</br>
        /// </remarks>
        private string GetStrFromDt(DateTime produceTypeOfYear)
        {
            string retYear = string.Empty;
            retYear = TDateTime.DateTimeToString("GGYYMM", produceTypeOfYear);
            string gg = retYear.Substring(0, 2);
            string yymm = retYear.Substring(2, 6);
            retYear = gg + " " + yymm;
            return retYear;
        }
        //---- ADD 杍^  2019/01/08 FOR �V�����̑Ή� ----<<<<<

        /// <summary>
        /// �R���g���[���̃f�[�^�Z�b�g��胍�[�J���f�[�^�Z�b�g�ւ̃f�[�^�R�s�[
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote   2019/01/08  杍^</br>
        /// <br>�C�����e     �V�����̑Ή�</br>
        /// </remarks>
        private void InitializeData()
        {
            // 2009.02.10 Add >>>
            //this.SettingPriceTargetData();
            // 2009.02.10 Add <<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
            this.SettingPriceTargetData();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
            _primeSearchParts.BeginLoadData();
            try
            {
                string filter = string.Empty;
                int makerCd;
                string partsNo, newPartsNo, partsNoInUse;

                _primeSearchParts.Merge(_orgDataSet.OfrPrimeParts, true, MissingSchemaAction.Ignore);
                _partsDetailTable.Merge(_orgDataSet.ModelPartsDetail, true, MissingSchemaAction.Ignore);

                int cnt = _primeSearchParts.Count;
                for (int i = 0; i < cnt; i++)
                {
                    #region [ �N���E�ԑ�ԍ��EQTY�ݒ菈�� ]
                    // �N�����ҏW
                    if (eraNameDispDiv) // �a��
                    {
                        if (_primeSearchParts[i].StProduceTypeOfYear > 0)
                            //---- UPD 杍^  2019/01/08 FOR �V�����̑Ή� ---->>>>>
                            //_primeSearchParts[i].YearStart = GetDtFromInt(_primeSearchParts[i].StProduceTypeOfYear).ToString("gg yy�NMM��", dtfi);
                            _primeSearchParts[i].YearStart = GetStrFromDt(GetDtFromInt(_primeSearchParts[i].StProduceTypeOfYear));
                            //---- UPD 杍^  2019/01/08 FOR �V�����̑Ή� ----<<<<<
                        if (_primeSearchParts[i].StProduceTypeOfYear > 0 && _primeSearchParts[i].EdProduceTypeOfYear != 999999)
                            //---- UPD 杍^  2019/01/08 FOR �V�����̑Ή� ---->>>>>
                            //_primeSearchParts[i].YearEnd = GetDtFromInt(_primeSearchParts[i].EdProduceTypeOfYear).ToString("gg yy�NMM��", dtfi);
                            _primeSearchParts[i].YearStart = GetStrFromDt(GetDtFromInt(_primeSearchParts[i].EdProduceTypeOfYear));
                            //---- UPD 杍^  2019/01/08 FOR �V�����̑Ή� ----<<<<<
                    }
                    else                // ����
                    {
                        if (_primeSearchParts[i].StProduceTypeOfYear > 0)
                            _primeSearchParts[i].YearStart = _primeSearchParts[i].StProduceTypeOfYear.ToString("####�N ##��");
                        if (_primeSearchParts[i].StProduceTypeOfYear > 0 && _primeSearchParts[i].EdProduceTypeOfYear != 999999)
                            _primeSearchParts[i].YearEnd = _primeSearchParts[i].EdProduceTypeOfYear.ToString("####�N ##��");
                    }
                    _primeSearchParts[i].FrameNoStart = _primeSearchParts[i].StProduceFrameNo.ToString();

                    // �t���[���ԍ����ҏW
                    if (_primeSearchParts[i].EdProduceFrameNo != 99999999)
                        _primeSearchParts[i].FrameNoEnd = _primeSearchParts[i].EdProduceFrameNo.ToString();

                    // QTY���ҏW
                    if (_primeSearchParts[i].PrimeQty == 0)
                        _primeSearchParts[i].PrimeQty = 1;
                    #endregion

                    makerCd = _primeSearchParts[i].PartsMakerCd;
                    partsNo = _primeSearchParts[i].PrimeOldPartsNo;
                    newPartsNo = _primeSearchParts[i].PrimePartsNo;
                    if (newPartsNo == string.Empty)
                        newPartsNo = partsNo;

                    PartsInfoDataSet.UsrGoodsInfoRow row; // = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);

                    ///////////////////////////////////////////////////////////////////////////////////////
                    if (substFlg == 1 && PartsStockCheck(partsNo, makerCd))
                    {       // ��֏����F�݌ɔ���L�@���@���i�݌ɂ���̏ꍇ
                        partsNoInUse = partsNo;  // ���i�E�݌ɁE�Z�b�g�����J�^���O�i�Ԃ���擾
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);
                    }
                    else
                    {
                        // 2009/10/19 >>>
                        //row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                        // 2009/10/19 <<<
                        if (userSubstFlg != 0)
                        {
                            PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst(row);
                            if (rowSubst.Equals(row))
                            {
                                row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                                rowSubst = _orgDataSet.GetUsrSubst(row);
                                if (rowSubst.Equals(row) == false) // �ŐV�i�ɑ΂��ă��[�U�[��ւ�����ꍇ
                                {
                                    _primeSearchParts[i].PartsMakerCd = makerCd = rowSubst.GoodsMakerCd;
                                    partsNoInUse = rowSubst.GoodsNo;      // ���i�E�݌ɁE�Z�b�g�����ŐV�i�Ԃ���擾
                                    partsNo = newPartsNo = partsNoInUse;
                                    _primeSearchParts[i].PrimeOldPartsNo = partsNoInUse;
                                    row = rowSubst;
                                    _primeSearchParts[i].UsrSubst = true;
                                    _primeSearchParts[i].PrimePartsNo = string.Empty;
                                }
                                else // ���[�U�[��ւ��Ȃ��ꍇ
                                {
                                    partsNoInUse = newPartsNo;      // ���i�E�݌ɁE�Z�b�g�����ŐV�i�Ԃ���擾
                                }
                            }
                            else // ���ɑ΂��ă��[�U�[��ւ�����ꍇ
                            {
                                _primeSearchParts[i].PartsMakerCd = makerCd = rowSubst.GoodsMakerCd;
                                partsNoInUse = rowSubst.GoodsNo;      // ���i�E�݌ɁE�Z�b�g�����ŐV�i�Ԃ���擾
                                partsNo = newPartsNo = partsNoInUse;
                                _primeSearchParts[i].PrimeOldPartsNo = partsNoInUse;
                                row = rowSubst;
                                _primeSearchParts[i].UsrSubst = true;
                                _primeSearchParts[i].PrimePartsNo = string.Empty;
                            }
                        }
                        else // ���[�U�[��ւ��Ȃ��ꍇ
                        {
                            row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                            partsNoInUse = newPartsNo;      // ���i�E�݌ɁE�Z�b�g�����ŐV�i�Ԃ���擾
                        }
                    }
                    ///////////////////////////////////////////////////////////////////////////////////////

                    // 2009/10/19 >>>
                    //_primeSearchParts[i].PrmOrgPartsNo = _primeSearchParts[i].PrimeOldPartsNo;
                    _primeSearchParts[i].PrmOrgPartsNo = _primeSearchParts[i].PrimePartsNo;
                    // 2009/10/19 <<<
                    _primeSearchParts[i].PrimeOldPartsNo = partsNoInUse;
                    if (row != null)
                    {
                        if (row.GoodsName != string.Empty)
                        {
                            _primeSearchParts[i].PrimePartsName = row.GoodsName;
                        }
                        else
                        {
                            _primeSearchParts[i].PrimePartsName = row.GoodsOfrName;
                        }
                        if (totalAmountDispWay == 1) //���z�\������i�ō��݁j
                        {
                            _primeSearchParts[i].Price = row.PriceTaxInc;
                            _primeSearchParts[i].Genka = row.UnitCostTaxInc;
                            _primeSearchParts[i].Urika = row.SalesUnitPriceTaxInc;
                        }
                        else
                        {
                            _primeSearchParts[i].Price = row.PriceTaxExc;
                            _primeSearchParts[i].Genka = row.UnitCostTaxExc;
                            _primeSearchParts[i].Urika = row.SalesUnitPriceTaxExc;
                        }
                        // �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
                        _primeSearchParts[i].Ararigaku = row.SalesUnitPriceTaxExc - row.UnitCostTaxExc;
                        if (row.SalesUnitPriceTaxExc != 0)
                            _primeSearchParts[i].Arariritu = _primeSearchParts[i].Ararigaku / row.SalesUnitPriceTaxExc;

                        //PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])row.GetChildRows("UsrGoodsInfo_Stock");
                        //if (stockRows != null && stockRows.Length > 0)
                        //{
                        //    _primeSearchParts[i].StockCnt = stockRows[0].ShipmentPosCnt;
                        //    _primeSearchParts[i].Warehouse = stockRows[0].WarehouseName;
                        //    _primeSearchParts[i].Shelf = stockRows[0].WarehouseShelfNo;
                        //}

                        #region [ �݌ɐݒ� ]
                        //�݌ɐݒ�
                        bool flgStock = false;
                        filter = string.Format("{0}={1} AND {2}='{3}'",
                                    _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, makerCd,
                                    _orgDataSet.Stock.GoodsNoColumn.ColumnName, partsNo);
                        PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(filter);
                        for (int j = 0; j < stockRows.Length; j++)
                        {
                            if (_StockTable.FindByWarehouseCodeGoodsMakerCdGoodsNo(stockRows[j].WarehouseCode,
                                    stockRows[j].GoodsMakerCd, stockRows[j].GoodsNo) == null)
                            {
                                OriginalParts.StockRow stockRow = _StockTable.NewStockRow();
                                stockRow.GoodsMakerCd = stockRows[j].GoodsMakerCd;
                                stockRow.GoodsNo = stockRows[j].GoodsNo;
                                stockRow.MaximumStockCnt = stockRows[j].MaximumStockCnt;
                                stockRow.MinimumStockCnt = stockRows[j].MinimumStockCnt;
                                stockRow.ShipmentPosCnt = stockRows[j].ShipmentPosCnt;
                                stockRow.WarehouseCode = stockRows[j].WarehouseCode;
                                stockRow.WarehouseName = stockRows[j].WarehouseName;
                                stockRow.WarehouseShelfNo = stockRows[j].WarehouseShelfNo;
                                stockRow.SelectionState = stockRows[j].SelectionState;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
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
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
                                _StockTable.AddStockRow(stockRow);
                                if (stockRows[j].SelectionState)
                                {
                                    _primeSearchParts[i].Shelf = stockRow.WarehouseShelfNo;
                                    _primeSearchParts[i].StockCnt = stockRow.ShipmentPosCnt;
                                    _primeSearchParts[i].Warehouse = stockRow.WarehouseName;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
                                    _primeSearchParts[i].WarehouseCode = stockRow.WarehouseCode;
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
                                        _primeSearchParts[i].Shelf = stockRows[k].WarehouseShelfNo;
                                        _primeSearchParts[i].StockCnt = stockRows[k].ShipmentPosCnt;
                                        _primeSearchParts[i].Warehouse = stockRows[k].WarehouseName;
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
                                        _primeSearchParts[i].WarehouseCode = stockRows[k].WarehouseCode;
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
                        //    _primeSearchParts[i].Shelf = stockRows[0].WarehouseShelfNo;
                        //    _primeSearchParts[i].StockCnt = stockRows[0].ShipmentPosCnt;
                        //    _primeSearchParts[i].Warehouse = stockRows[0].WarehouseName;
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
                        //    _primeSearchParts[i].WarehouseCode = stockRows[0].WarehouseCode;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 DEL
                        #endregion
                    }

                    // 2009/10/19 >>>
                    //if (SubstExists(partsNo, makerCd))
                    if (SubstExists(newPartsNo, makerCd))
                    // 2009/10/19 <<<
                    {
                        _primeSearchParts[i].Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                    }
                    if (SetExists(partsNoInUse, makerCd))
                    {
                        _primeSearchParts[i].Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                    }
                }
            }
            finally
            {
                _primeSearchParts.AcceptChanges();
                _primeSearchParts.EndLoadData();
            }

            lstEnum.Add(_partsDetailTable.ModelGradeNmColumn.ColumnName, RowFilterKind.ModelGradeNm);
            lstEnum.Add(_partsDetailTable.BodyNameColumn.ColumnName, RowFilterKind.BodyName);
            lstEnum.Add(_partsDetailTable.DoorCountColumn.ColumnName, RowFilterKind.DoorCount);
            lstEnum.Add(_partsDetailTable.EngineModelNmColumn.ColumnName, RowFilterKind.EngineModelNm);
            lstEnum.Add(_partsDetailTable.EngineDisplaceNmColumn.ColumnName, RowFilterKind.EngineDisplaceNm);
            lstEnum.Add(_partsDetailTable.EDivNmColumn.ColumnName, RowFilterKind.EDivNm);
            lstEnum.Add(_partsDetailTable.TransmissionNmColumn.ColumnName, RowFilterKind.TransmissionNm);
            lstEnum.Add(_partsDetailTable.ShiftNmColumn.ColumnName, RowFilterKind.ShiftNm);
            lstEnum.Add(_partsDetailTable.WheelDriveMethodNmColumn.ColumnName, RowFilterKind.WheelDriveMethodNm);
            lstEnum.Add(_partsDetailTable.AddiCarSpec1Column.ColumnName, RowFilterKind.AddiCarSpec1);
            lstEnum.Add(_partsDetailTable.AddiCarSpec2Column.ColumnName, RowFilterKind.AddiCarSpec2);
            lstEnum.Add(_partsDetailTable.AddiCarSpec3Column.ColumnName, RowFilterKind.AddiCarSpec3);
            lstEnum.Add(_partsDetailTable.AddiCarSpec4Column.ColumnName, RowFilterKind.AddiCarSpec4);
            lstEnum.Add(_partsDetailTable.AddiCarSpec5Column.ColumnName, RowFilterKind.AddiCarSpec5);
            lstEnum.Add(_partsDetailTable.AddiCarSpec6Column.ColumnName, RowFilterKind.AddiCarSpec6);
        }

        // 2009.02.10 Add >>>
        /// <summary>
        /// �Ώۃf�[�^�̉��i�ݒ�
        /// </summary>
        private void SettingPriceTargetData()
        {
            if (_orgDataSet.CalculateGoodsPrice == null) return;

            List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList = new List<PartsInfoDataSet.GoodsPrimaryKey>();

            foreach (PartsInfoDataSet.OfrPrimePartsRow row in _orgDataSet.OfrPrimeParts)
            {
                goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(row.PrimePartsNo, row.PartsMakerCd));
                // 2009/10/19 Add >>>
                if (( row.PrimePartsNo != row.PrimeOldPartsNo ) & ( row.PrimeOldPartsNo != String.Empty )) //--add
                    goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(row.PrimeOldPartsNo, row.PartsMakerCd));//--add
                // 2009/10/19 Add <<<
            }
            // ���i��񂪑��݂���ꍇ�͉��i�v�Z
            if (goodsPrimaryKeyList.Count > 0)
            {
                _orgDataSet.SettingGoodsPrice(goodsPrimaryKeyList);
            }
        }

        // 2009.02.10 Add <<<
        #endregion

        #region [ �t�H�[���C�x���g ]
        /// <summary>
        /// �_�C�A���O��\������B[���̉�ʂ��J�����O�ɑ�֏������������ꍇ��֌��i�Ԃ����֐�i�Ԃւ̐؂�ւ��������s��]
        /// </summary>
        /// <returns></returns>
        // 2009.02.19 >>>
        //public new DialogResult ShowDialog()
        public new DialogResult ShowDialog(IWin32Window owner)
        // 2009.02.19 <<<
        {
            #region [ �\������f�[�^��1�������Ȃ��Ƃ��̏����|�I�����I�� ]
            if (gridOriginalP.Rows.Count == 1
                && (substFlg == 0 || gridOriginalP.Rows[0].Cells[_primeSearchParts.SubstColumn.ColumnName].Value.Equals(DBNull.Value)))
            {
                int makerCd = (int)gridOriginalP.Rows[0].Cells[_primeSearchParts.PartsMakerCdColumn.ColumnName].Value;
                string goodsNo = gridOriginalP.Rows[0].Cells[_primeSearchParts.PrimeOldPartsNoColumn.ColumnName].Value.ToString();
                SelectionInfo selInfo = new SelectionInfo();
                selInfo.Depth = 0;
                selInfo.Key = gridOriginalP.Rows[0].ListIndex;
                selInfo.RowGoods = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);
                _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                isDialogShown = false;
                if (gridOriginalP.Rows[0].Cells[_primeSearchParts.SetColumn.ColumnName].Value.Equals(DBNull.Value))
                {
                    selInfo.Selected = true;

                    string filter = string.Format("{0}={1} AND {2}='{3}' ",
                        _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                        _StockTable.GoodsNoColumn.ColumnName, goodsNo);
                    _StockTable.DefaultView.RowFilter = filter;
                    if (_orgDataSet.ListPriorWarehouse != null) // �D��q�Ɏw�肠��
                    {
                        for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
                        {
                            // 2009.02.16 >>>
                            //string warehouseCd = _orgDataSet.ListPriorWarehouse[i];
                            string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
                            // 2009.02.16 <<<
                            for (int j = 0; j < _StockTable.DefaultView.Count; j++)
                            {
                                if (warehouseCd.Equals(_StockTable.DefaultView[j][_StockTable.WarehouseCodeColumn.ColumnName]))
                                {
                                    selInfo.WarehouseCode = warehouseCd;
                                    return DialogResult.OK;
                                }
                            }
                        }
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 DEL // �D��q�ɂɂȂ��ꍇ�͎��ɂ���
                    //if (_StockTable.DefaultView.Count > 0)
                    //    selInfo.WarehouseCode = _StockTable.DefaultView[0][_StockTable.WarehouseCodeColumn.ColumnName].ToString();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 DEL
                }
                else
                {
                    if (uiControlFlg)
                    {
                        _orgDataSet.UsrGoodsInfo.RowToProcess = selInfo.RowGoods;
                        _orgDataSet.SetSrcSelInf = selInfo;
                        _orgDataSet.UIKind = SelectUIKind.Set;
                        return DialogResult.Retry;
                    }
                }

                return DialogResult.OK;
            }
            #endregion
            if (_prevRow != null && _prevRow.NewGoodsNo != string.Empty) //��ւ��ꂽ���i�����邩�`�F�b�N[NewGoodsNo:��֐�i��]
            {
                #region [ ��֑I��UI���Ə��� ]
                string partsNo;
                UltraGridRow gridRow = gridOriginalP.Rows.GetRowWithListIndex(_prevSelInfo.Key);
                // ��ւ���O�̑I������������E�Z�b�g�q���i���N���A
                _prevSelInfo.ListChildGoods.Clear();
                _prevSelInfo.ListChildGoods2.Clear();
                if (_prevSelInfo.ListPlrlSubst.Count > 0)
                    _prevSelInfo.ListPlrlSubst.RemoveAt(0); // 1�ڂ͑�֕i���Ȃ̂ō폜���Ă����B
                if (_prevRow.NewGoodsNo == _prevRow.GoodsNo) // ��֑I��UI�ő�ւƂ��đ�֌��i�Ԃ�I�񂾎��̏���
                {
                    //_prevRow.NewGoodsNo = string.Empty;
                    gridRow.Cells[_primeSearchParts.OldPartsNoColumn.ColumnName].Value = gridRow.Cells[_primeSearchParts.PrimeOldPartsNoColumn.ColumnName].Value;
                    gridRow.Cells[_primeSearchParts.SelectionStateColumn.ColumnName].Value = _prevRow.SelectionState;
                    gridRow.Cells[_primeSearchParts.PrimeOldPartsNoColumn.ColumnName].Value = _prevRow.GoodsNo;
                    partsNo = _prevRow.GoodsNo;
                    gridRow.Cells[_primeSearchParts.PrimePartsNameColumn.ColumnName].Value = _prevRow.GoodsName;
                    if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                    {
                        gridRow.Cells[_primeSearchParts.PriceColumn.ColumnName].Value = _prevRow.PriceTaxInc;
                        gridRow.Cells[_primeSearchParts.UrikaColumn.ColumnName].Value = _prevRow.SalesUnitPriceTaxInc;
                        gridRow.Cells[_primeSearchParts.GenkaColumn.ColumnName].Value = _prevRow.UnitCostTaxInc;
                    }
                    else
                    {
                        gridRow.Cells[_primeSearchParts.PriceColumn.ColumnName].Value = _prevRow.PriceTaxExc;
                        gridRow.Cells[_primeSearchParts.UrikaColumn.ColumnName].Value = _prevRow.SalesUnitPriceTaxExc;
                        gridRow.Cells[_primeSearchParts.GenkaColumn.ColumnName].Value = _prevRow.UnitCostTaxExc;
                    }
                    // �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
                    gridRow.Cells[_primeSearchParts.ArarigakuColumn.ColumnName].Value = _prevRow.SalesUnitPriceTaxExc - _prevRow.UnitCostTaxExc;
                    if (_prevRow.UnitCostTaxExc != 0)
                        gridRow.Cells[_primeSearchParts.ArarirituColumn.ColumnName].Value = (_prevRow.SalesUnitPriceTaxExc - _prevRow.UnitCostTaxExc) / _prevRow.UnitCostTaxExc;

                    gridRow.Cells[_primeSearchParts.PrimeQtyColumn.ColumnName].Value = ((_prevRow.QTY != 0) ? _prevRow.QTY : 1);
                    gridRow.Cells[_primeSearchParts.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    gridRow.Cells[_primeSearchParts.SelectionStateColumn.ColumnName].Value = true;
                }
                else                                        // ��L�ȊO��ւ������̏���
                {
                    PartsInfoDataSet.UsrGoodsInfoRow newRow =
                            _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_prevRow.GoodsMakerCd, _prevRow.NewGoodsNo);

                    gridRow.Cells[_primeSearchParts.OldPartsNoColumn.ColumnName].Value = gridRow.Cells[_primeSearchParts.PrimeOldPartsNoColumn.ColumnName].Value;
                    gridRow.Cells[_primeSearchParts.PrimeOldPartsNoColumn.ColumnName].Value = newRow.GoodsNo;
                    partsNo = newRow.GoodsNo;
                    gridRow.Cells[_primeSearchParts.PrimePartsNameColumn.ColumnName].Value = newRow.GoodsName;
                    if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                    {
                        gridRow.Cells[_primeSearchParts.PriceColumn.ColumnName].Value = newRow.PriceTaxInc;
                        gridRow.Cells[_primeSearchParts.UrikaColumn.ColumnName].Value = newRow.SalesUnitPriceTaxInc;
                        gridRow.Cells[_primeSearchParts.GenkaColumn.ColumnName].Value = newRow.UnitCostTaxInc;
                    }
                    else
                    {
                        gridRow.Cells[_primeSearchParts.PriceColumn.ColumnName].Value = newRow.PriceTaxExc;
                        gridRow.Cells[_primeSearchParts.UrikaColumn.ColumnName].Value = newRow.SalesUnitPriceTaxExc;
                        gridRow.Cells[_primeSearchParts.GenkaColumn.ColumnName].Value = newRow.UnitCostTaxExc;
                    }
                    // �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
                    gridRow.Cells[_primeSearchParts.ArarigakuColumn.ColumnName].Value = newRow.SalesUnitPriceTaxExc - newRow.UnitCostTaxExc;
                    if (newRow.UnitCostTaxExc != 0)
                        gridRow.Cells[_primeSearchParts.ArarirituColumn.ColumnName].Value = (newRow.SalesUnitPriceTaxExc - newRow.UnitCostTaxExc) / newRow.UnitCostTaxExc;

                    PartsInfoDataSet.PartsInfoRow rowPartsInfo =
                        _orgDataSet.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(newRow.GoodsMakerCd, newRow.GoodsNo);
                    if (rowPartsInfo != null)
                    {
                        gridRow.Cells[_primeSearchParts.PrimeQtyColumn.ColumnName].Value = ((rowPartsInfo.PartsQty != 0) ? rowPartsInfo.PartsQty : 1);
                    }
                    gridRow.Cells[_primeSearchParts.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    gridRow.Cells[_primeSearchParts.SelectionStateColumn.ColumnName].Value = true;
                    //_prevRow.NewGoodsNo = string.Empty;
                }
                if (SetExists(partsNo, _prevRow.GoodsMakerCd)) // TODO
                {
                    gridRow.Cells[_primeSearchParts.SetColumn.ColumnName].Value = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                }
                else
                {
                    gridRow.Cells[_primeSearchParts.SetColumn.ColumnName].Value = DBNull.Value;
                }
                //string primePartsNo;                
                _prevRow.NewGoodsNo = string.Empty;
                _prevRow = null;
                SelectionInfo selInfo = _prevSelInfo;
                if (selInfo != null)
                {
                    UltraGridRow row = gridOriginalP.Rows.GetRowWithListIndex(selInfo.Key);
                    row.Cells[_primeSearchParts.WarehouseCodeColumn.ColumnName].Value = selInfo.WarehouseCode;
                }
                _primeSearchParts.AcceptChanges();
                #endregion
            }
            else // ��֑I��UI�ȊO�̉�ʂ���̑J�ڂ̏ꍇ�̍X�V�������s���B
            {
                //_orgRow = _orgDataSet.UsrGoodsInfo.RowToProcess;
                SelectionInfo selInfo = _prevSelInfo;
                if (selInfo != null)
                {
                    UltraGridRow row = gridOriginalP.Rows.GetRowWithListIndex(selInfo.Key);

                    row.Cells[_primeSearchParts.SelectionStateColumn.ColumnName].Value = selInfo.Selected;
                    row.Cells[_primeSearchParts.WarehouseCodeColumn.ColumnName].Value = selInfo.WarehouseCode;
                    if (selInfo.Selected)
                    {
                        row.Cells[_primeSearchParts.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    }
                    else
                    {
                        row.Cells[_primeSearchParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                    }
                }
            }
            // �݌ɕ\���X�V
            gridOriginalP_AfterSelectChange(this, null);

            //isUserClose = true; // �~�{�^������t���O�@���Z�b�g

            if (gridOriginalP.Selected.Rows.Count > 0)
            {
                gridOriginalP.Selected.Rows[0].Activated = true;
                //int makerCd;
                //string goodsNo;
                //if (gridOriginalP.Selected.Rows[0].Band.ParentBand == null)
                //{
                //    makerCd = (int)gridOriginalP.Selected.Rows[0].Cells[_primeSearchParts.CatalogPartsMakerCdColumn.ColumnName].Value;
                //    goodsNo = gridOriginalP.Selected.Rows[0].Cells[_primeSearchParts.PartsNoColumn.ColumnName].Value.ToString();
                //    //goodsNo = gridOriginalP.Selected.Rows[0].Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                //    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);

                //    if (row.SelectionComplete)
                //    {
                //        gridOriginalP.Selected.Rows[0].Cells[_primeSearchParts.SelImageColumn.ColumnName].Appearance.BackColor = Color.DarkKhaki;
                //        gridOriginalP.Selected.Rows[0].Cells[_primeSearchParts.SelImageColumn.ColumnName].SelectedAppearance.BackColor = Color.DarkKhaki;
                //        gridOriginalP.Selected.Rows[0].Cells[_primeSearchParts.SelImageColumn.ColumnName].SelectedAppearance.BackColor2 = Color.DarkKhaki;
                //    }
                //    else
                //    {
                //        gridOriginalP.Selected.Rows[0].Cells[_primeSearchParts.SelImageColumn.ColumnName].Appearance.ResetBackColor();
                //        gridOriginalP.Selected.Rows[0].Cells[_primeSearchParts.SelImageColumn.ColumnName].SelectedAppearance.ResetBackColor();
                //        gridOriginalP.Selected.Rows[0].Cells[_primeSearchParts.SelImageColumn.ColumnName].SelectedAppearance.ResetBackColor2();
                //    }
                //}
            }
            else
            {
                gridOriginalP.Rows[0].Activate();
                gridOriginalP.Rows[0].Selected = true;
            }
            // 2009.02.19 >>>
            //return base.ShowDialog();
            return base.ShowDialog(owner);
            // 2009.02.19 <<<
        }

        /// <summary>
        /// FormClosed �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResult��OK�̏ꍇ�ɂ̂݁A�O���b�h��őI������Ă���s�Ɋ֘A����DataRow�I�u�W�F�N�g���擾���A</br>
        /// <br>"�I�����"�ɑ������鏈�����s���܂��B</br>
        /// </remarks>
        private void SelectionPrimeBLParts_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            int cnt = gridOriginalP.Rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = null;
                UltraGridRow gridRow = gridOriginalP.Rows[i];

                if (gridRow.Cells[_primeSearchParts.SelectionStateColumn.ColumnName].Value.Equals(true))
                {
                    if (gridRow.Cells[_primeSearchParts.UsrSubstColumn.ColumnName].Value.Equals(true)) // ���[�U�[��ւ��ꂽ�ꍇ
                    {
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo((int)gridRow.Cells[_primeSearchParts.PartsMakerCdColumn.ColumnName].Value,
                                gridRow.Cells[_primeSearchParts.PrimeOldPartsNoColumn.ColumnName].Value.ToString());
                        if (row != null)
                        {
                            SelectionInfo selInfo = new SelectionInfo();
                            selInfo.Depth = 0;
                            selInfo.Key = gridRow.ListIndex;
                            selInfo.RowGoods = row;
                            selInfo.WarehouseCode = gridRow.Cells[_primeSearchParts.WarehouseCodeColumn.ColumnName].Value.ToString();
                            if (uiControlFlg && gridRow.Cells[_primeSearchParts.SelImageColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                                selInfo.Selected = true;
                            else
                                selInfo.Selected = false;
                            _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                            if (gridOriginalP.ActiveRow != null && i == gridOriginalP.ActiveRow.Index)
                            {
                                if (_orgDataSet.UIKind == SelectUIKind.Set)
                                    _orgDataSet.SetSrcSelInf = selInfo;
                                _prevSelInfo = selInfo;
                            }
                        }
                    }
                    else // �ʏ�P�[�X
                    {
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo((int)gridRow.Cells[_primeSearchParts.PartsMakerCdColumn.ColumnName].Value,
                                gridRow.Cells[_primeSearchParts.PrimeOldPartsNoColumn.ColumnName].Value.ToString());
                        if (row != null)
                        {
                            SelectionInfo selInfo = new SelectionInfo();
                            selInfo.Depth = 0;
                            selInfo.Key = gridRow.ListIndex;
                            selInfo.RowGoods = row;
                            selInfo.WarehouseCode = gridRow.Cells[_primeSearchParts.WarehouseCodeColumn.ColumnName].Value.ToString();
                            if (uiControlFlg && gridRow.Cells[_primeSearchParts.SelImageColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                                selInfo.Selected = true;
                            else
                                selInfo.Selected = false;
                            _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                            if (gridOriginalP.ActiveRow != null && i == gridOriginalP.ActiveRow.Index)
                            {
                                switch (_orgDataSet.UIKind)
                                {
                                    case SelectUIKind.Set:
                                        _orgDataSet.SetSrcSelInf = selInfo;
                                        break;
                                    case SelectUIKind.Subst:
                                        _orgDataSet.SubstSrcSelInf = selInfo;
                                        break;
                                }
                                _prevSelInfo = selInfo;
                            }
                            /*if (substFlg == 1 && gridRow.Cells[_primeSearchParts.StockCntColumn.ColumnName].Value.Equals(0) // �݌ɂ��Ȃ��Ƃ��͕��ʂ̑�֏��������邽�ߍ݌ɐ��`�F�b�N
                                && gridRow.Cells[_primeSearchParts.PrimePartsNoColumn.ColumnName].Value.Equals(gridRow.Cells[_primeSearchParts.NewPrtsNoWithHyphenColumn.ColumnName].Value) == false)
                            {   // ��֏����敪���݌ɔ���L���݌ɂ��聕�J�^���O�i�Ԃ��ŐV�i�ԂƈقȂ�Ƃ�
                                row.NewGoodsNo = _primeSearchParts[i].PartsNo;  // �݌ɗL���ɂ�蔻�肳�ꂽ�i�Ԃɑ�ւ���B
                            }
                            else if (gridRow.Cells[_primeSearchParts.NewPrtsNoWithHyphenColumn.ColumnName].Value.Equals(gridRow.Cells[_primeSearchParts.ClgPrtsNoWithHyphenColumn.ColumnName].Value) == false)
                            {
                                // �������i�Ԃ̐ݒ�
                                if (gridRow.Cells[_primeSearchParts.JoinSrcPartsNoColumn.ColumnName].Value.Equals(gridRow.Cells[_primeSearchParts.PartsNoColumn.ColumnName].Value))
                                {   // ��֑I��UI�ő�ւ����ꍇ
                                    row.NewGoodsNo = gridRow.Cells[_primeSearchParts.PartsNoColumn.ColumnName].Value.ToString();
                                }
                                else
                                {
                                    row.NewGoodsNo = gridRow.Cells[_primeSearchParts.NewPrtsNoWithHyphenColumn.ColumnName].Value.ToString();
                                }
                                row.QTY = (double)gridRow.Cells[_primeSearchParts.PrimeQtyColumn.ColumnName].Value;
                            }*/
                        }
                    }
                }
                else
                {
                    _orgDataSet.RemoveSelectionInfo(_orgDataSet.ListSelectionInfo, gridRow.ListIndex);
                }
                if (row != null)
                    row.GoodsKindResolved = (int)GoodsKind.Parent;
            }
        }
#if Old        
        private void SelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                return;
            }
            int cnt = gridOriginalP.Rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = null;
                UltraGridRow gridRow = gridOriginalP.Rows[i];

                if (gridRow.Cells[_primeSearchParts.SelectionStateColumn.ColumnName].Value.Equals(true))
                {
                    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo((int)gridRow.Cells[_primeSearchParts.PartsMakerCdColumn.ColumnName].Value,
                                gridRow.Cells[_primeSearchParts.PrimeOldPartsNoColumn.ColumnName].Value.ToString());

                    SelectionInfo selInfo = new SelectionInfo();
                    selInfo.Depth = 0;
                    selInfo.Key = gridRow.ListIndex;
                    selInfo.RowGoods = row;
                    selInfo.WarehouseCode = gridRow.Cells[_primeSearchParts.WarehouseCodeColumn.ColumnName].Value.ToString();
                    //if (uiControlFlg && gridRow.Cells[_dataSet.TBOInfo.SelImageColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                    //    selInfo.Selected = true;
                    //else
                    //    selInfo.Selected = false;
                    selInfo.Selected = true;
                    _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);

                }
            }
        }
#endif

        /// <summary>
        /// ESC�L�[�����ɂ��I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionPrimeBLParts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
            /*
        else if (e.KeyCode == Keys.Enter)
        {
            if (this.DataGrid.ActiveRow != null)
            {
                DataRow wkRow = (DataRow)this.DataGrid.ActiveRow.Cells[COL_WR].Value;
                DataRow wkRow2 = (DataRow)this.DataGrid.ActiveRow.Cells[COL_RW].Value;
                if (wkRow[OfrPrimeSearchPartsInfo.COL_PRIMESEARCH_SELECTED] != System.DBNull.Value)
                {
                    wkRow[OfrPrimeSearchPartsInfo.COL_PRIMESEARCH_SELECTED] = System.DBNull.Value;
                    DataRowSelecting(ref wkRow2, false);

                }
                else
                {
                    wkRow[OfrPrimeSearchPartsInfo.COL_PRIMESEARCH_SELECTED] =
                      NSResource.GetBitmap("BMP24GENERAL_071");
                    DataRowSelecting(ref wkRow2, true);
                }

                UltraGridRow ugr = this.DataGrid.ActiveRow.GetSibling(SiblingRow.Next);
                if (ugr != null)
                {
                    ugr.Selected = true;
                    ugr.Activate();
                }
            }
        }
             * */
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
        private void gridOriginalP_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            colToShow = new List<string>(new string[]{ 
                _partsDetailTable.ModelGradeNmColumn.ColumnName,            // 0
                _partsDetailTable.BodyNameColumn.ColumnName,                // 1
                _partsDetailTable.DoorCountColumn.ColumnName,               // 2
                _partsDetailTable.EngineModelNmColumn.ColumnName,           // 3
                _partsDetailTable.EngineDisplaceNmColumn.ColumnName,        // 4
                _partsDetailTable.EDivNmColumn.ColumnName,                  // 5
                _partsDetailTable.TransmissionNmColumn.ColumnName,          // 6
                _partsDetailTable.ShiftNmColumn.ColumnName,                 // 7
                _partsDetailTable.WheelDriveMethodNmColumn.ColumnName,      // 8
                _partsDetailTable.AddiCarSpec1Column.ColumnName,            // 9
                _partsDetailTable.AddiCarSpec2Column.ColumnName,            // 10
                _partsDetailTable.AddiCarSpec3Column.ColumnName,            // 11
                _partsDetailTable.AddiCarSpec4Column.ColumnName,            // 12
                _partsDetailTable.AddiCarSpec5Column.ColumnName,            // 13
                _partsDetailTable.AddiCarSpec6Column.ColumnName             // 14                
            });

            // �񕝂̎����������@
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            #region ���i�O���b�h�i�o���h�O�j�̐ݒ�
            // �o���h�̎擾
            UltraGridBand band0 = e.Layout.Bands[0];
            band0.UseRowLayout = true;
            band0.Indentation = 0;

            for (int Index = 0; Index < band0.Columns.Count; Index++)
            {
                // �����\���ʒu
                if ((band0.Columns[Index].DataType == typeof(int)) ||
                   (band0.Columns[Index].DataType == typeof(double)) ||
                   (band0.Columns[Index].DataType == typeof(Int64)))
                {
                    band0.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (band0.Columns[Index].DataType == typeof(Image))
                {
                    band0.Columns[Index].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                }
                else
                {
                    band0.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band0.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // �����\���ʒu
                band0.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            band0.Columns[_primeSearchParts.GoodsMGroupColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.TbsPartsCodeColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.PartsMakerCdColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.PrmSetDtlNo1Column.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.PrmSetDtlNo2Column.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.PrimePartsNoColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.SetPartsFlgColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.SelectionStateColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.MakerDispOrderColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.PrimeDispOrderColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.PrimeSearchDispOrderColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.PartsMakerCdColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.PrmPartsProperNoColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.StockColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.WarehouseCodeColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.OldPartsNoColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.UsrSubstColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.PrmOrgPartsNoColumn.ColumnName].Hidden = true;

            band0.Columns[_primeSearchParts.StProduceTypeOfYearColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.EdProduceTypeOfYearColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.StProduceFrameNoColumn.ColumnName].Hidden = true;
            band0.Columns[_primeSearchParts.EdProduceFrameNoColumn.ColumnName].Hidden = true;

            //�Q�i
            ColInfo.SetColInfo(band0, _primeSearchParts.SelImageColumn.ColumnName, 2, 0, 2, 4, 12);

            //��i
            //ColInfo.SetColInfo(band0, _primeSearchParts.PartsMakerCdColumn.ColumnName, 4, 0, 4, 2, 50);
            ColInfo.SetColInfo(band0, _primeSearchParts.PartsMakerNameColumn.ColumnName, 4, 0, 12, 2, 120);
            ColInfo.SetColInfo(band0, _primeSearchParts.PrimePartsNameColumn.ColumnName, 16, 0, 14, 2, 140);

            if (PartsNarrowing == 0)
            {
                ColInfo.SetColInfo(band0, _primeSearchParts.YearStartColumn.ColumnName, 30, 0, 6, 2, 60);
                ColInfo.SetColInfo(band0, _primeSearchParts.YearEndColumn.ColumnName, 36, 0, 6, 2, 60);
                band0.Columns[_primeSearchParts.FrameNoStartColumn.ColumnName].Hidden = true;
                band0.Columns[_primeSearchParts.FrameNoEndColumn.ColumnName].Hidden = true;
            }
            else
            {
                ColInfo.SetColInfo(band0, _primeSearchParts.FrameNoStartColumn.ColumnName, 30, 0, 6, 2, 60);
                ColInfo.SetColInfo(band0, _primeSearchParts.FrameNoEndColumn.ColumnName, 36, 0, 6, 2, 60);
                band0.Columns[_primeSearchParts.YearStartColumn.ColumnName].Hidden = true;
                band0.Columns[_primeSearchParts.YearEndColumn.ColumnName].Hidden = true;
            }
            ColInfo.SetColInfo(band0, _primeSearchParts.PrimeQtyColumn.ColumnName, 42, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _primeSearchParts.GenkaColumn.ColumnName, 46, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _primeSearchParts.ArarirituColumn.ColumnName, 50, 0, 4, 2, 40);
            //ColInfo.SetColInfo(band0, _primeSearchParts.PriceColumn.ColumnName, 50, 0, 4, 2, 40);

            //���i            
            ColInfo.SetColInfo(band0, _primeSearchParts.PrimeSpecialNoteColumn.ColumnName, 4, 2, 18, 2, 180);
            ColInfo.SetColInfo(band0, _primeSearchParts.PrimeOldPartsNoColumn.ColumnName, 22, 2, 8, 2, 80);

            ColInfo.SetColInfo(band0, _primeSearchParts.WarehouseColumn.ColumnName, 30, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _primeSearchParts.ShelfColumn.ColumnName, 34, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _primeSearchParts.StockCntColumn.ColumnName, 38, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _primeSearchParts.PriceColumn.ColumnName, 42, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _primeSearchParts.UrikaColumn.ColumnName, 46, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _primeSearchParts.ArarigakuColumn.ColumnName, 50, 2, 4, 2, 40);
            //ColInfo.SetColInfo(band0, _primeSearchParts.ArarirituColumn.ColumnName, 50, 2, 4, 2, 40);

            if (_mode == 0) // �ʏ탂�[�h�̏ꍇ
            {
                if (substFlg == 0) // ��ւ��Ȃ�
                {
                    ColInfo.SetColInfo(band0, _primeSearchParts.SetColumn.ColumnName, 54, 0, 1, 4, 12);
                    band0.Columns[_primeSearchParts.SubstColumn.ColumnName].Hidden = true;
                }
                else
                {
                    ColInfo.SetColInfo(band0, _primeSearchParts.SubstColumn.ColumnName, 54, 0, 1, 4, 12);
                    ColInfo.SetColInfo(band0, _primeSearchParts.SetColumn.ColumnName, 55, 0, 1, 4, 12);
                }
            }
            else            // �������ϐ�p���[�h�̏ꍇ
            {
                band0.Columns[_primeSearchParts.SetColumn.ColumnName].Hidden = true;
                if (substFlg == 0) // ��ւ��Ȃ�
                {
                    band0.Columns[_primeSearchParts.SubstColumn.ColumnName].Hidden = true;
                }
                else
                {
                    ColInfo.SetColInfo(band0, _primeSearchParts.SubstColumn.ColumnName, 54, 0, 1, 4, 12);
                }
            }

            band0.Columns[_primeSearchParts.PriceColumn.ColumnName].Format = "C";
            band0.Columns[_primeSearchParts.GenkaColumn.ColumnName].Format = "C";
            band0.Columns[_primeSearchParts.UrikaColumn.ColumnName].Format = "C";
            band0.Columns[_primeSearchParts.ArarigakuColumn.ColumnName].Format = "C";
            band0.Columns[_primeSearchParts.ArarirituColumn.ColumnName].Format = "#%";
            band0.Columns[_primeSearchParts.StockCntColumn.ColumnName].Format = "###,###,##0.00";
            band0.Columns[_primeSearchParts.PrimeQtyColumn.ColumnName].Format = "###,###,##0.00";
            #endregion

            #region �����O���b�h�i�o���h�P�j�̐ݒ�

            // �o���h�̎擾
            UltraGridBand band1 = e.Layout.Bands[1];
            band1.Indentation = 0;
            band1.UseRowLayout = true;
            //band1.Override.DefaultRowHeight = 20;
            band1.Override.RowSizing = RowSizing.Fixed;
            band1.Override.AllowColSizing = AllowColSizing.None;
            band1.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            for (int Index = 0; Index <= band1.Columns.Count - 1; Index++)
            {
                // �����\���ʒu
                if ((band1.Columns[Index].DataType == typeof(int)) ||
                   (band1.Columns[Index].DataType == typeof(Int64)))
                {
                    band1.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    band1.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }

                // �����\���ʒu
                band1.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }

            band1.Columns[_partsDetailTable.FullModelFixedNoColumn.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.PartsNoColumn.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.PartsMakerCdColumn.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.SelectionStateColumn.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.PartsUniqueNoColumn.ColumnName].Hidden = true;
            //band1.Columns[_partsDetailTable.PrmPartsProperNoRFColumn.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.PartsUniqueNoColumn.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.AddiCarSpec1Column.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.AddiCarSpec2Column.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.AddiCarSpec3Column.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.AddiCarSpec4Column.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.AddiCarSpec5Column.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.AddiCarSpec6Column.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.AddiCarSpecTitle1Column.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.AddiCarSpecTitle2Column.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.AddiCarSpecTitle3Column.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.AddiCarSpecTitle4Column.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.AddiCarSpecTitle5Column.ColumnName].Hidden = true;
            band1.Columns[_partsDetailTable.AddiCarSpecTitle6Column.ColumnName].Hidden = true;

            ColInfo.SetColInfo(band1, _partsDetailTable.SelImageColumn.ColumnName, 2, 0, 1, 2, 13);
            ColInfo.SetColInfo(band1, colToShow[0], 3, 0, 6, 2, 50);
            ColInfo.SetColInfo(band1, colToShow[1], 9, 0, 6, 2, 50);
            ColInfo.SetColInfo(band1, colToShow[2], 15, 0, 6, 2, 50);
            ColInfo.SetColInfo(band1, colToShow[3], 21, 0, 6, 2, 50);
            ColInfo.SetColInfo(band1, colToShow[4], 27, 0, 6, 2, 50);
            ColInfo.SetColInfo(band1, colToShow[5], 33, 0, 6, 2, 50);
            ColInfo.SetColInfo(band1, colToShow[6], 39, 0, 5, 2, 50);
            ColInfo.SetColInfo(band1, colToShow[7], 44, 0, 4, 2, 50);
            ColInfo.SetColInfo(band1, colToShow[8], 48, 0, 4, 2, 50);
            #endregion

        }

        /// <summary>
        /// �A�N�e�B�u�s�ύX��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridOriginalP_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (isSelectChangeDisabled)
                return;
            bool enaSet = false;
            bool enaSubst = false;
            UltraGridRow activeRow = gridOriginalP.ActiveRow;
            if (activeRow == null || activeRow.Band.ParentBand != null) // �q�o���h�����ΏۊO
                return;
            #region [ �݌ɃO���b�h�t�B���^�����O���� ]
            string filter = string.Empty;
            try
            {
                filter = string.Format("{0}={1} AND {2}='{3}' ",
                    _StockTable.GoodsMakerCdColumn.ColumnName,
                    activeRow.Cells[_primeSearchParts.PartsMakerCdColumn.ColumnName].Value,
                    _StockTable.GoodsNoColumn.ColumnName,
                    activeRow.Cells[_primeSearchParts.PrimeOldPartsNoColumn.ColumnName].Value);
            }
            finally
            {
                _StockTable.DefaultView.RowFilter = filter;
            }
            #endregion

            SetStockGridSelect();

            try
            {
                enaSet = (gridOriginalP.ActiveRow.Cells[_primeSearchParts.SetColumn.ColumnName].Value != System.DBNull.Value);
                enaSubst = (gridOriginalP.ActiveRow.Cells[_primeSearchParts.SubstColumn.ColumnName].Value != System.DBNull.Value);
            }
            finally
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.Enabled = enaSet;
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled = enaSubst;
            }
            if (activeRow.Expanded)
            {
                ToolbarsManager.Tools["Btn_Spec"].SharedProps.Caption = "�i�ԒP��(F3)";
            }
            else
            {
                ToolbarsManager.Tools["Btn_Spec"].SharedProps.Caption = "�����ڍ�(F3)";
            }
        }

        /// <summary>
        /// �s���_�u���N���b�N���ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// �f�[�^���\������Ă��Ȃ��s���_�u���N���b�N���Ă��{�C�x���g�͔������Ȃ��B
        /// </remarks>
        private void gridOriginalP_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SetSelect(false);
            //if (gridOriginalP.ActiveRow != null && gridOriginalP.ActiveRow.Band.ParentBand == null) //�@�e�o���h�̂ݑI����
            //{
            //    if (gridOriginalP.ActiveRow.Cells[_primeSearchParts.SelImageColumn.ColumnName].Value != DBNull.Value)
            //    {
            //        gridOriginalP.ActiveRow.Cells[_primeSearchParts.SelImageColumn.ColumnName].Value = DBNull.Value;
            //        gridOriginalP.ActiveRow.Cells[_primeSearchParts.SelectionStateColumn.ColumnName].Value = false;
            //    }
            //    else
            //    {
            //        gridOriginalP.ActiveRow.Cells[_primeSearchParts.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
            //        gridOriginalP.ActiveRow.Cells[_primeSearchParts.SelectionStateColumn.ColumnName].Value = true;
            //    }
            //}
        }

        /// <summary>
        /// �O���b�h���Enter�L�[�������ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridOriginalP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                gridOriginalP.Selected.Rows[0].ExpandAll();
            }

            else if (e.KeyCode == Keys.Subtract)
            {
                gridOriginalP.Selected.Rows[0].CollapseAll();
            }

            else if (e.KeyCode == Keys.Enter)
            {
                SetSelect(true);
                //if (gridOriginalP.ActiveRow != null && gridOriginalP.ActiveRow.Band.ParentBand == null) //�@�e�o���h�̂ݑI����
                //{
                //    if (gridOriginalP.ActiveRow.Cells[_primeSearchParts.SelImageColumn.ColumnName].Value != DBNull.Value)
                //    {
                //        gridOriginalP.ActiveRow.Cells[_primeSearchParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                //        gridOriginalP.ActiveRow.Cells[_primeSearchParts.SelectionStateColumn.ColumnName].Value = false;
                //    }
                //    else
                //    {
                //        gridOriginalP.ActiveRow.Cells[_primeSearchParts.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                //        gridOriginalP.ActiveRow.Cells[_primeSearchParts.SelectionStateColumn.ColumnName].Value = true;
                //    }
                //    UltraGridRow ugr = this.gridOriginalP.ActiveRow.GetSibling(SiblingRow.Next);
                //    if (ugr != null)
                //    {
                //        ugr.Selected = true;
                //        ugr.Activate();
                //    }
                //}
            }
        }

        /// <summary>
        /// Enter�L�[(�_�u���N���b�N)�ɂ��I������
        /// </summary>
        /// <param name="moveFlg">true:���̍s��I����ԂɁ^false:�Ȃɂ����Ȃ��i�}�E�X�_�u���N���b�N���j</param>
        private void SetSelect(bool moveFlg)
        {
            UltraGridRow activeRow = gridOriginalP.ActiveRow;
            if (activeRow != null)
            {
                CellsCollection activeCells = activeRow.Cells;
                if (activeRow.Band.ParentBand == null // �e�o���h��(�q�o���h�͎ԗ����̂��߁j
                    && enterFlg != 2) // �iPM.NS�������Enter�L�[���u����ʁv�j�ȊO��
                {
                    if (activeCells[_primeSearchParts.SelImageColumn.ColumnName].Value != DBNull.Value)
                    {
                        activeCells[_primeSearchParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                        activeCells[_primeSearchParts.SelectionStateColumn.ColumnName].Value = false;
                        if (_orgDataSet.ListSelectionInfo.ContainsKey(activeRow.ListIndex)) // �I���������镔�i�̌�����Ȃǂ̑I����ԉ���
                        {
                            _orgDataSet.ListSelectionInfo.Remove(activeRow.ListIndex);
                        }
                    }
                    else
                    {
                        activeCells[_primeSearchParts.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                        activeCells[_primeSearchParts.SelectionStateColumn.ColumnName].Value = true;
                    }
                    _primeSearchParts.AcceptChanges();
                }
                switch (enterFlg) // �G���^�[�L�[�����敪
                {
                    case 2: // Enter�L�[���u����ʁv�̏ꍇ
                        foreach (UltraGridRow row in gridOriginalP.Rows) // ����ʂ̎��͑I���s�ȊO�͑I����������
                        {
                            if (row.Equals(activeRow) == false && row.Cells[_primeSearchParts.SelImageColumn.ColumnName].Value != DBNull.Value)
                            {
                                row.Cells[_primeSearchParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                                row.Cells[_primeSearchParts.SelectionStateColumn.ColumnName].Value = false;
                                if (_orgDataSet.ListSelectionInfo.ContainsKey(row.ListIndex))
                                {
                                    _orgDataSet.ListSelectionInfo.Remove(row.ListIndex);
                                }
                            }
                        }
                        if (uiControlFlg) // PM.NS����
                        {
                            //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                            if (activeCells[_primeSearchParts.SetColumn.ColumnName].Value != DBNull.Value) // �Z�b�g��񂠂�
                            {
                                PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo
                                    ((int)activeCells[_primeSearchParts.PartsMakerCdColumn.ColumnName].Value,
                                     activeCells[_primeSearchParts.PrimeOldPartsNoColumn.ColumnName].Value.ToString());
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                _orgDataSet.UIKind = SelectUIKind.Set;
                                DialogResult = DialogResult.Retry;
                            }
                            else
                            {
                                DialogResult = DialogResult.OK;
                            }
                            //activeCells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                            //activeCells[_partsInfo.SelectionStateColumn.ColumnName].Value = true; // ����ʂ��Ȃ��ꍇ�I�����I��
                        }
                        else // PM7����
                        {
                            //activeCells[_partsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
                            //activeCells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                            DialogResult = DialogResult.OK;
                        }
                        activeCells[_primeSearchParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                        activeCells[_primeSearchParts.SelectionStateColumn.ColumnName].Value = true;
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

        private void gridCondition_CellListSelect(object sender, CellEventArgs e)
        {
            if (isSelectChangeDisabled)
                return;

            RowFilterKind selected = lstEnum[e.Cell.Column.Key];
            if (e.Cell.Text == string.Empty)
            {
                if (rowFilterList.ContainsKey(selected))
                {
                    rowFilterList.Remove(selected);
                }
            }
            else
            {
                string filterString = string.Format("{0} = '{1}'", e.Cell.Column.Key, e.Cell.Text);
                if (rowFilterList.ContainsKey(selected))
                {
                    rowFilterList[selected] = filterString;
                }
                else
                {
                    rowFilterList.Add(selected, filterString);
                }
            }

            gridCondition.UpdateData();

            GridFiltering();
        }
        #endregion

        #region [ �݌ɃO���b�h�C�x���g���� ]
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
            band.Columns[_StockTable.SortDivColumn.ColumnName].Hidden = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
            for (int Index = 0; Index < band.Columns.Count; Index++)
            {
                // �����\���ʒu
                if ((band.Columns[Index].DataType == typeof(int)) ||
                   (band.Columns[Index].DataType == typeof(double)))
                {
                    band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // �����\���ʒu
                band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 ADD
            ColInfo.SetColInfo( band, _StockTable.SelImageColumn.ColumnName, 0, 0, 10 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 ADD
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

        private void gridStock_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 DEL
            //if (gridStock.ActiveRow != null && gridOriginalP.ActiveRow != null)
            //{
            //    gridOriginalP.ActiveRow.Cells[_primeSearchParts.WarehouseColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
            //    gridOriginalP.ActiveRow.Cells[_primeSearchParts.ShelfColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
            //    gridOriginalP.ActiveRow.Cells[_primeSearchParts.StockCntColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
            //    gridOriginalP.ActiveRow.Cells[_primeSearchParts.WarehouseCodeColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
            //    gridStock.ActiveRow.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
            //    gridOriginalP.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 DEL
        }

        private void gridStock_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 DEL
            //if (gridStock.Selected.Rows.Count > 0)
            //    gridStock.Selected.Rows[0].Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 DEL
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
                if ( gridOriginalP.ActiveRow != null )
                {
                    if ( (bool)activeCells[_StockTable.SelectionStateColumn.ColumnName].Value == true )
                    {
                        // ���i�O���b�h�ɍ݌ɏ��\��
                        gridOriginalP.ActiveRow.Cells[_primeSearchParts.WarehouseColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
                        gridOriginalP.ActiveRow.Cells[_primeSearchParts.ShelfColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
                        gridOriginalP.ActiveRow.Cells[_primeSearchParts.StockCntColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
                        gridOriginalP.ActiveRow.Cells[_primeSearchParts.WarehouseCodeColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
                    }
                    else
                    {
                        // ���i�O���b�h�̍݌ɏ����N���A
                        gridOriginalP.ActiveRow.Cells[_primeSearchParts.WarehouseColumn.ColumnName].Value = string.Empty;
                        gridOriginalP.ActiveRow.Cells[_primeSearchParts.ShelfColumn.ColumnName].Value = string.Empty;
                        gridOriginalP.ActiveRow.Cells[_primeSearchParts.StockCntColumn.ColumnName].Value = 0;
                        gridOriginalP.ActiveRow.Cells[_primeSearchParts.WarehouseCodeColumn.ColumnName].Value = string.Empty;
                    }
                    gridOriginalP.UpdateData();
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

        /// <summary>
        /// �݌ɃO���b�h�I�������i���[�U�[�I�����D��q�Ɂ��擪�s�̏��őI���j
        /// </summary>
        private void SetStockGridSelect()
        {
            if (gridOriginalP.ActiveRow.Cells[_primeSearchParts.WarehouseCodeColumn.ColumnName].Value.Equals(string.Empty) == false)
            {
                for (int i = 0; i < gridStock.Rows.Count; i++)
                {
                    if (gridStock.Rows[i].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value
                        .Equals(gridOriginalP.ActiveRow.Cells[_primeSearchParts.WarehouseCodeColumn.ColumnName].Value))
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
                // �Y���Ȃ��̏ꍇ�͐擪�s�Ƀt�H�[�J�X�̂݃Z�b�g
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/31 DEL
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
            //    gridOriginalP.ActiveRow.Cells[_primeSearchParts.WarehouseColumn.ColumnName].Value = string.Empty;
            //    gridOriginalP.ActiveRow.Cells[_primeSearchParts.ShelfColumn.ColumnName].Value = string.Empty;
            //    gridOriginalP.ActiveRow.Cells[_primeSearchParts.StockCntColumn.ColumnName].Value = 0;
            //    gridOriginalP.ActiveRow.Cells[_primeSearchParts.WarehouseCodeColumn.ColumnName].Value = string.Empty;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/31 DEL
        }

        #region [ �c�[���o�[�C�x���g���� ]
        /// <summary>
        /// �c�[���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            UltraGridRow activeRow = gridOriginalP.ActiveRow;
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
                        if (_primeSearchParts.Select("SelectionState = true").Length == 0
                           && (_orgDataSet.ListSelectionInfo.Count == 0 ||
                           (_orgDataSet.ListSelectionInfo.ContainsKey(_prevSelInfo.Key) && _orgDataSet.ListSelectionInfo[_prevSelInfo.Key].IsThereSelection == false)))
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
                    if (substFlg != 0 && activeRow != null)
                    {
                        if (activeRow.Cells[_primeSearchParts.SubstColumn.ColumnName].Value != DBNull.Value)
                        {
                            DialogResult = DialogResult.OK;
                            int makerCd = (int)activeRow.Cells[_primeSearchParts.PartsMakerCdColumn.ColumnName].Value;
                            string partsNo = activeRow.Cells[_primeSearchParts.PrmOrgPartsNoColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                //_orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                activeRow.Cells[_primeSearchParts.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                //_prevRow = row;
                                _prevRow = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd,
                                    activeRow.Cells[_primeSearchParts.PrimeOldPartsNoColumn.ColumnName].Value.ToString());
                                _orgDataSet.UIKind = SelectUIKind.Subst;
                                DialogResult = DialogResult.Retry;
                            }
                        }
                    }
                    break;

                case "Button_Set":
                    // �Z�b�g������ꍇ�Z�b�g�I��UI�\��
                    if (uiControlFlg && activeRow != null && activeRow.Band == gridOriginalP.DisplayLayout.Bands[0])
                    {
                        if (activeRow.Cells[_primeSearchParts.SetColumn.ColumnName].Value != DBNull.Value)
                        {
                            DialogResult = DialogResult.OK;
                            int makerCd = (int)activeRow.Cells[_primeSearchParts.PartsMakerCdColumn.ColumnName].Value;
                            string partsNo = activeRow.Cells[_primeSearchParts.PrimeOldPartsNoColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                //_orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                activeRow.Cells[_primeSearchParts.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                _orgDataSet.UIKind = SelectUIKind.Set;
                                DialogResult = DialogResult.Retry;
                            }
                        }
                    }
                    break;

                case "BtnClear":
                    ClearCondition();
                    break;

                case "Btn_Spec":
                    if (ToolbarsManager.Tools["Btn_Spec"].SharedProps.Caption.Equals("�����ڍ�(F3)"))
                        SetSpecVisible();
                    else
                        SetSpecInvisible();
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

        /// <summary>
        /// �������\��
        /// </summary>
        private void SetSpecVisible()
        {
            if (gridOriginalP.ActiveRow != null && gridOriginalP.ActiveRow.Band.ParentBand == null)
            {
                if (gridOriginalP.ActiveRow.ChildBands.Count > 0)
                {
                    gridOriginalP.ActiveRow.ExpandAll();
                    ToolbarsManager.Tools["Btn_Spec"].SharedProps.Caption = "�i�ԒP��(F3)";
                }
            }
        }

        /// <summary>
        /// ��������\��
        /// </summary>
        private void SetSpecInvisible()
        {
            if (gridOriginalP.ActiveRow != null)
            {
                if (gridOriginalP.ActiveRow.Band.ParentBand == null)
                {
                    gridOriginalP.ActiveRow.CollapseAll();
                    ToolbarsManager.Tools["Btn_Spec"].SharedProps.Caption = "�����ڍ�(F3)";
                }
                else
                {
                    gridOriginalP.ActiveRow.ParentRow.CollapseAll();
                    ToolbarsManager.Tools["Btn_Spec"].SharedProps.Caption = "�����ڍ�(F3)";
                }
            }
        }

        private void ClearCondition()
        {
            isSelectChangeDisabled = true;
            for (int i = 0; i < conditionCellCount; i++)
            {
                if (gridCondition.Rows[0].Cells[i].Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                {
                    gridCondition.Rows[0].Cells[i].Value = string.Empty;
                }
            }
            isSelectChangeDisabled = false;

            gridCondition.UpdateData();
            rowFilterList.Clear();

            GridFiltering();
            //isSelectChangeDisabled = true;
            //gridOriginalP.Selected.Rows.Clear();
            //isSelectChangeDisabled = false;
            //RefreshDataCount();
        }
        #endregion

        #region [ �i���֘A���� ]
        private void MakeConditionGridData()
        {
            List<Infragistics.Win.ValueList> vlist = new List<Infragistics.Win.ValueList>();

            for (int i = 0; i < conditionCellCount; i++)
            {
                vlist.Add(new Infragistics.Win.ValueList());
                vlist[i].ValueListItems.Add("");
            }

            gridCondition.BeginUpdate();

            gridCondition.DisplayLayout.Bands[0].AddNew();

            for (int i = 0; i < conditionCellCount; i++)
            {
                gridCondition.Rows[0].Cells[i].ValueList = vlist[i];
            }
            SetAddCarSpecColumn(gridCondition.DisplayLayout.Bands[0]);

            for (int i = 0; i < _partsDetailTable.DefaultView.Count; i++)
            {
                OriginalParts.ModelPartsDetailRow rowToComp = (OriginalParts.ModelPartsDetailRow)_partsDetailTable.DefaultView[i].Row;

                if (vlist[0].FindByDataValue(rowToComp.ModelGradeNm) == null)      // �^���O���[�h����
                    vlist[0].ValueListItems.Add(rowToComp.ModelGradeNm);
                if (vlist[1].FindByDataValue(rowToComp.BodyName) == null)          // �{�f�B�[����
                    vlist[1].ValueListItems.Add(rowToComp.BodyName);
                if (rowToComp.DoorCount != 0 && vlist[2].FindByDataValue(rowToComp.DoorCount) == null)         // �h�A��
                    vlist[2].ValueListItems.Add(rowToComp.DoorCount);
                if (vlist[3].FindByDataValue(rowToComp.EngineModelNm) == null)     // �G���W���^������
                    vlist[3].ValueListItems.Add(rowToComp.EngineModelNm);
                if (vlist[4].FindByDataValue(rowToComp.EngineDisplaceNm) == null)  // �r�C�ʖ���
                    vlist[4].ValueListItems.Add(rowToComp.EngineDisplaceNm);
                if (vlist[5].FindByDataValue(rowToComp.EDivNm) == null)            // E�敪����
                    vlist[5].ValueListItems.Add(rowToComp.EDivNm);
                if (vlist[6].FindByDataValue(rowToComp.TransmissionNm) == null)    // �~�b�V��������
                    vlist[6].ValueListItems.Add(rowToComp.TransmissionNm);
                if (vlist[7].FindByDataValue(rowToComp.ShiftNm) == null)           // �V�t�g����
                    vlist[7].ValueListItems.Add(rowToComp.ShiftNm);
                if (vlist[8].FindByDataValue(rowToComp.WheelDriveMethodNm) == null)// �쓮��������
                    vlist[8].ValueListItems.Add(rowToComp.WheelDriveMethodNm);
                if (vlist[9].FindByDataValue(rowToComp.AddiCarSpec1) == null)      // �ǉ�����1
                    vlist[9].ValueListItems.Add(rowToComp.AddiCarSpec1);
                if (vlist[10].FindByDataValue(rowToComp.AddiCarSpec2) == null)      // �ǉ�����2
                    vlist[10].ValueListItems.Add(rowToComp.AddiCarSpec2);
                if (vlist[11].FindByDataValue(rowToComp.AddiCarSpec3) == null)      // �ǉ�����3
                    vlist[11].ValueListItems.Add(rowToComp.AddiCarSpec3);
                if (vlist[12].FindByDataValue(rowToComp.AddiCarSpec4) == null)      // �ǉ�����4
                    vlist[12].ValueListItems.Add(rowToComp.AddiCarSpec4);
                if (vlist[13].FindByDataValue(rowToComp.AddiCarSpec5) == null)      // �ǉ�����5
                    vlist[13].ValueListItems.Add(rowToComp.AddiCarSpec5);
                if (vlist[14].FindByDataValue(rowToComp.AddiCarSpec6) == null)      // �ǉ�����6
                    vlist[14].ValueListItems.Add(rowToComp.AddiCarSpec6);
            }

            for (int i = 0; i < conditionCellCount; i++)
            {
                if (vlist[i].ValueListItems.Count <= 2) // �i��������1�i�擪�󔒊܂߂�2�j�����Ȃ��ꍇ
                {
                    gridCondition.Rows[0].Cells[i].Column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                    gridCondition.Rows[0].Cells[i].Column.CellClickAction = CellClickAction.CellSelect;
                    if (vlist[i].ValueListItems.Count == 2)
                        gridCondition.Rows[0].Cells[i].Value = vlist[i].ValueListItems[1].DisplayText;
                }
            }
            gridCondition.UpdateData();
            gridCondition.EndUpdate();

            UltraGridBand band = gridCondition.DisplayLayout.Bands[0];
            band.UseRowLayout = true;
            gridCondition.DisplayLayout.Override.RowSelectorWidth = gridOriginalP.DisplayLayout.Override.RowSelectorWidth;
            ColInfo.SetColInfo(band, colToShow[0], 2, 0, 4, 2, 120);    // ModelGradeNm
            ColInfo.SetColInfo(band, colToShow[1], 6, 0, 4, 2, 120);    // BodyName
            ColInfo.SetColInfo(band, colToShow[2], 10, 0, 2, 2, 60);    // DoorCount
            ColInfo.SetColInfo(band, colToShow[3], 12, 0, 4, 2, 120);   // EngineModelNm
            ColInfo.SetColInfo(band, colToShow[4], 16, 0, 4, 2, 120);    // EngineDisplaceNm
            ColInfo.SetColInfo(band, colToShow[5], 20, 0, 2, 2, 60);   // EDivNm
            ColInfo.SetColInfo(band, colToShow[6], 22, 0, 4, 2, 120);   // TransmissionNm
            ColInfo.SetColInfo(band, colToShow[7], 26, 0, 3, 2, 90);   // ShiftNm
            ColInfo.SetColInfo(band, colToShow[8], 29, 0, 3, 2, 90);   // WheelDriveMethodNm
            // 3�i
            int originX = 2;
            if (band.Columns[colToShow[9]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[9], originX, 2, 5, 2, 150);   // �ǉ�����1
                originX += 5;
            }
            if (band.Columns[colToShow[10]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[10], originX, 2, 5, 2, 150);   // �ǉ�����2
                originX += 5;
            }
            if (band.Columns[colToShow[11]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[11], originX, 2, 5, 2, 150);  // �ǉ�����3
                originX += 5;
            }
            if (band.Columns[colToShow[12]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[12], originX, 2, 5, 2, 150);  // �ǉ�����4
                originX += 5;
            }
            if (band.Columns[colToShow[13]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[13], originX, 2, 5, 2, 150);  // �ǉ�����5
                originX += 5;
            }
            if (band.Columns[colToShow[14]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[14], originX, 2, 5, 2, 120);  // �ǉ�����6
            }

            if (originX > 2) // �ǉ�������񂪂���ꍇ
            {
                gridCondition.Height = 94;
                gridOriginalP.Top += 48;
                gridOriginalP.Height -= 48;
            }
            else
            {
                gridCondition.Height = 48;
            }
        }

        private List<String> SetAddCarSpecColumn(UltraGridBand band)
        {
            //UltraGridBand band0 = gridOriginalP.DisplayLayout.Bands[0];
            //UltraGridBand band = gridOriginalP.DisplayLayout.Bands[1];
            List<String> ret = new List<string>();
            //�ǉ������̕\���ݒ�i�擪���\���̏ꍇ�S�ĕ\������j
            if (_partsDetailTable[0].AddiCarSpec1 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec1Column.ColumnName].Hidden = true;
                band.Columns[_partsDetailTable.AddiCarSpec1Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_partsDetailTable.AddiCarSpec1Column.ColumnName);
                band.Columns[_partsDetailTable.AddiCarSpec1Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec1Column.Caption;
            }
            if (_partsDetailTable[0].AddiCarSpec2 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec2Column.ColumnName].Hidden = true;
                band.Columns[_partsDetailTable.AddiCarSpec2Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_partsDetailTable.AddiCarSpec2Column.ColumnName);
                band.Columns[_partsDetailTable.AddiCarSpec2Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec2Column.Caption;
            }
            if (_partsDetailTable[0].AddiCarSpec3 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec3Column.ColumnName].Hidden = true;
                band.Columns[_partsDetailTable.AddiCarSpec3Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_partsDetailTable.AddiCarSpec3Column.ColumnName);
                band.Columns[_partsDetailTable.AddiCarSpec3Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec3Column.Caption;
            }
            if (_partsDetailTable[0].AddiCarSpec4 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec4Column.ColumnName].Hidden = true;
                band.Columns[_partsDetailTable.AddiCarSpec4Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_partsDetailTable.AddiCarSpec4Column.ColumnName);
                band.Columns[_partsDetailTable.AddiCarSpec4Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec4Column.Caption;
            }
            if (_partsDetailTable[0].AddiCarSpec5 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec5Column.ColumnName].Hidden = true;
                band.Columns[_partsDetailTable.AddiCarSpec5Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_partsDetailTable.AddiCarSpec5Column.ColumnName);
                band.Columns[_partsDetailTable.AddiCarSpec5Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec5Column.Caption;
            }
            if (_partsDetailTable[0].AddiCarSpec6 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec6Column.ColumnName].Hidden = true;
                band.Columns[_partsDetailTable.AddiCarSpec6Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_partsDetailTable.AddiCarSpec6Column.ColumnName);
                band.Columns[_partsDetailTable.AddiCarSpec6Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec6Column.Caption;
            }
            return ret;
        }

        private void GridFiltering()
        {
            string filter = MakeRowFilterString();

            gridOriginalP.BeginUpdate();
            _primeSearchParts.DefaultView.RowFilter = filter;
            gridOriginalP.EndUpdate();
            if (gridOriginalP.Rows.Count > 0)
            {
                gridOriginalP.Rows[0].Activate();
                gridOriginalP.Rows[0].Selected = true;
            }
            //gridOriginalP_AfterSelectChange(this, null);
            //RefreshDataCount();
        }

        /// <summary>
        /// �e��i�������ɂ��t�B���^�����O�N�G���쐬
        /// </summary>
        /// <returns></returns>
        private string MakeRowFilterString()
        {

            List<long> lstProperNoFromCarInfo = new List<long>();
            StringBuilder retRowFilter = new StringBuilder();

            if (rowFilterList.Values.Count > 0)
            {
                StringBuilder modelFilter = new StringBuilder();
                foreach (string rowFilter in rowFilterList.Values)
                {
                    modelFilter.Append(" AND " + rowFilter);
                }
                modelFilter.Remove(0, 4);
                OriginalParts.ModelPartsDetailRow[] modelRows = (OriginalParts.ModelPartsDetailRow[])_partsDetailTable.Select(modelFilter.ToString());
                for (int i = 0; i < modelRows.Length; i++)
                {
                    if (lstProperNoFromCarInfo.Contains(modelRows[i].PartsUniqueNo) == false)
                        lstProperNoFromCarInfo.Add(modelRows[i].PartsUniqueNo);
                }
                retRowFilter.Append("PrmPartsProperNo in (");


                if (lstProperNoFromCarInfo.Count == 0)
                    return "false";
                for (int i = 0; i < lstProperNoFromCarInfo.Count; i++)
                {
                    retRowFilter.Append(lstProperNoFromCarInfo[i]);
                    retRowFilter.Append(", ");
                }

                retRowFilter.Remove(retRowFilter.Length - 2, 2);
                retRowFilter.Append(")");

                ToolbarsManager.Tools["BtnClear"].SharedProps.Visible = true;
            }
            else
            {
                ToolbarsManager.Tools["BtnClear"].SharedProps.Visible = false;
            }

            return retRowFilter.ToString();
        }
        #endregion

        #region [ ���̑����� ]
        /// <summary>
        /// �J�^���O�i�Ԃ̌��݌ɐ��`�F�b�N
        /// </summary>
        /// <param name="parts">�i��</param>
        /// <param name="maker">���[�J�[</param>
        /// <returns>true:���݌ɐ�����@false:���݌ɂȂ�</returns>
        internal bool PartsStockCheck(string parts, int maker)
        {
            bool ret = false;
            string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        _orgDataSet.Stock.GoodsNoColumn.ColumnName, parts,
                        _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, maker);
            PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(rowFilter);
            if (rowStock.Length > 0) // ���͉��L�̃R�����g���ꂽ�����������Ɛ������Ǝv���邪�APM7�ɍ��킹���ق���
                ret = true;          // �����Ƃ������Ƃɂ�肱�̏����ɂ���B
            //for (int i = 0; i < rowStock.Length; i++)
            //{
            //    if (rowStock[i].ShipmentPosCnt > 0)
            //    {
            //        ret = true;
            //        break;
            //    }
            //}
            return ret;
        }

        internal bool SubstExists(string parts, int maker)
        {
            if (substFlg == 0) // �u��ւ��Ȃ��v�̎��͖�����false
                return false;
            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4} = true", // ��֑I��UI�ɂ͒񋟂̂ݕ\��
                _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, parts,
                _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, maker, _orgDataSet.UsrSubstParts.OfferKubunColumn.ColumnName);
            if (_orgDataSet.UsrSubstParts.Select(rowFilter).Length > 0)
            {
                if (substFlg == 2) // �u�݌ɔ���Ȃ��v�̎��́@��ւ����邾����true
                {
                    return true;
                }
                else // �u�݌ɔ��肠��v�̎��͑�ւ��芎��֌��i�̌��݌ɐ��Ȃ��̎��̂�true
                {
                    if (PartsStockCheck(parts, maker) == false) // ���݌ɂȂ��Ȃ�u�݌ɔ���L�v�ł���։�
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal bool SetExists(string parts, int maker)
        {
            string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                _orgDataSet.UsrSetParts.ParentGoodsNoColumn.ColumnName, parts,
                _orgDataSet.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, maker);

            if (_orgDataSet.UsrSetParts.Select(rowFilter).Length > 0)
                return true;
            return false;
        }

        private DateTime GetDtFromInt(int dt)
        {
            if (dt <= 101)
                return DateTime.MinValue;
            if (dt > 300000)
                return DateTime.MaxValue;
            int year = dt / 100;
            int month = dt % 100;

            return new DateTime(year, month, 1);
        }
        #endregion

        #region ColInfo �C���^�[�i��
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
                sizeHeader.Height = 24;
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
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }

        }
        #endregion
    }
}