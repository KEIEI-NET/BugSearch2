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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.UIData;

using System.IO;   // ADD 杍^ 2014/09/01 FOR Redmine#43289
using Broadleaf.Application.Resources; // ADD 杍^ 2014/09/01 FOR Redmine#43289
using Broadleaf.Application.Common;  // ADD 杍^ 2014/09/01 FOR Redmine#43289
using System.Threading; // ADD 杍^ 2014/09/01 FOR Redmine#43289
using Broadleaf.Library.Globarization; // ADD 杍^ 2014/09/01 FOR Redmine#43289

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
    /// <br>Date		: 2009.03.30</br>
    /// <br></br>
    /// <br>Update Note	: �q�i�Ԃ̑q�ɂ�ύX�����ꍇ�ɃG���g����ʂɔ��f����Ȃ���Q�̏C��(MANTIS[0014650])</br>
    /// <br>            : �Z�b�g�q�i�Ԃ�I�������ꍇ�ɁA���i���(�����Ȃ�)�ɃZ�b�g�q���Z�b�g����悤�ɏC��(MANTIS[0014690])</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009/11/26</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ��i�W�����j</br>
    /// <br>             : �@�E�݌ɂ̖��׌������[���̏ꍇ�́A�݌ɃO���b�h�Ƀt�H�[�J�X�ړ����Ȃ��悤�ɕύX�B</br>
    /// <br>Programmer   : 22018�@��� ���b</br>
    /// <br>Date         : 2010/10/26</br>
    /// <br></br>
    /// <br>Update Note	: ��Q���ǑΉ��i�������j</br>
    /// <br>             :   �E��֐�����o�l�V�����̓���ɏC���B</br>
    /// <br>                   �i��֌��̍݌ɂ�����΁A��ւ��Ȃ��B(���Z�b�g�I������̑�ւ̓��[�U�[��ւ̂�)�j</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2011/02/02</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ�(��������)</br>
    /// <br>             :   �E2011/02/02���̏C���B�݌ɗL������͗D��q�ɂ̂ݑΏۂƂ���B(PM7����)</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2011/02/09</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ�(��������)</br>
    /// <br>             :   �E2011/02/09���̏C���B�D��q�ɖ��ݒ�̏ꍇ�̏������C��(�ُ�I�������Ȃ�)</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2011/02/18</br>
    /// <br>Update Note  : 11070184-00 Redmine#43289�Ή�</br>
    /// <br>                 �ԗ����E���l��񂪕\������Ă����Ԃŕ��i�I����ʂ��N������悤���ǂ������Ȃ��܂��B</br>
    /// <br>Programmer   : 杍^</br>
    /// <br>Date         : 2014/09/01</br>
    /// <br>Update Note: 2014/09/01 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11070184-00�@SCM��Q�Ή� ��190�@RedMine#43289</br>
    /// <br>         �@: SF����⍇���̎��q���E���l�𔄏�`�[���͂ɕ\������</br>
    /// <br>Update Note: 2014/09/22 ���� ��Y</br>
    /// <br>�Ǘ��ԍ�   : 11070184-00�@SCM�d�|�ꗗNo.10598</br>
    /// <br>         �@: ������ԑ�ԍ��ł̔����E�⍇���Ή�</br>
    /// <br>Update Note: 2014/11/04 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 11070221-00�@�d�|�ꗗ ��2577</br>
    /// <br>         �@: �ԗ�����\���ؑ֎��̖��׃O���b�h�̍��������������C��</br>
    /// <br></br>
    /// </remarks>
    public partial class SelectionFormSet : Form
    {
        #region [ Private Member Variable ]
        /// <summary>�f�[�^�Z�b�g</summary>
        private PartsInfoDataSet _orgDataSet = null;
        private PartsInfoDataSet.UsrSetPartsDataTable _setPartsTable = null;
        private PartsInfoDataSet.UsrGoodsInfoRow _orgRow = null;
        private PartsInfoDataSet.UsrGoodsInfoRow _prevRow = null;
        private SetParts _dsSet = null;
        private SetParts.StockDataTable _StockTable;
        //public SetParts DsSet
        //{
        //    get
        //    {
        //        return _dsSet;
        //    }
        //}
        private string _JoinPartsNo = string.Empty;
        private int _JoinMakerCode = 0;
        private bool isUserClose = true;
        private bool uiControlFlg;      // false:PM7�X�^�C���@�@true:PM.NS�X�^�C��
        private int substFlg;           // 0:��ւ��Ȃ�  1:��ւ���i�݌ɔ��肠��j 2:��ւ���i�݌ɔ���Ȃ��j
        private int userSubstFlg;
        private int enterFlg;           // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
        private int totalAmountDispWay;       // ���z�\�����@�敪 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j

        private bool isSelectChangeDisabled = false;

        /// <summary> �Z�b�g�q�i�Ԃ̑I�����X�g </summary>
        private Dictionary<int, SelectionInfo> _lstSelInf;
        /// <summary> �Z�b�g�e�i�Ԃ̑I����� </summary>
        private SelectionInfo _selInf;
        private SelectionInfo _prevSelInfo;

        private PMKEN01010E _orgCar = null;

        // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- >>>
        private string _pgid = string.Empty;
        /// <summary>�ԗ�����\���pXML�t�@�C�����i���`��ʁj</summary>
        private const string MAHNB01001U_PMKEN08060U_CARINFOSELETED = "MAHNB01001U_PMKEN08060U_CarInfoSeleted.XML";
        /// <summary>�ԗ�����\���pXML�t�@�C�����i���ω�ʁj</summary>
        private const string PMMIT01010U_PMKEN08060U_CARINFOSELETED = "PMMIT01010U_PMKEN08060U_CarInfoSeleted.XML";
        /// <summary>���`���PGID</summary>
        private const string MAHNB01001U_PGID = "MAHNB01001U";
        /// <summary>���ω��PGID</summary>
        private const string PMMIT01010U_PGID = "PMMIT01010U";
        /// <summary>�ԗ����\���pSOLT</summary>
        private const string CARINFOSOLT = "CARINFOSOLT";
        private LocalDataStoreSlot carInfoSolt = null;
        // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- <<<

        #endregion

        #region [ Constructor ]
        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        /// <param name="dsSource">�O���b�h�ɕ\������f�[�^���w�肵�܂��B</param>
        public SelectionFormSet(PartsInfoDataSet dsSource)
        {
            _orgDataSet = dsSource;

            _setPartsTable = dsSource.UsrSetParts;
            if (dsSource.SearchCondition != null)
            {
                uiControlFlg = Convert.ToBoolean(dsSource.SearchCondition.SearchCntSetWork.SearchUICntDivCd); // 0:PM7�X�^�C���^1:PM.NS�X�^�C��
                substFlg = dsSource.SearchCondition.SearchCntSetWork.PrmSubstCondDivCd; // 0:��ւ��Ȃ�  1:��ւ���i�݌ɔ��肠��j 2:��ւ���i�݌ɔ���Ȃ��j
                userSubstFlg = dsSource.SearchCondition.SearchCntSetWork.SubstApplyDivCd;
                enterFlg = dsSource.SearchCondition.SearchCntSetWork.EnterProcDivCd; // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
                totalAmountDispWay = dsSource.SearchCondition.SearchCntSetWork.TotalAmountDispWayCd; // 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j
            }
            else // �}�X�����Ȃǒ��œ���i�ԑI��UI��\������ꍇ
            {
                uiControlFlg = true;
                substFlg = 0;
                userSubstFlg = 0;
                enterFlg = 1;
            }
            InitializeComponent();
            InitializeTable();
            InitializeForm();
            StatusBar.Text = "";

            // �c�[���o�[�̃C���[�W(16x16)�⃁�b�Z�[�W��ݒ肷��
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            if (substFlg != 0)
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARADD;
                //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            }
            else
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Visible = false;
            }
            //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
        }
        #endregion

        #region [ �C�j�V�������� ]
        private void InitializeForm()
        {
            //_prevRow = _orgRow;
            _orgRow = _orgDataSet.UsrGoodsInfo.RowToProcess;
            InitializeData();
            gridSetParts.Rows[0].ExpandAll();
            gridSetParts.Rows[0].Fixed = true;
        }

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <returns>�_�C�A���O�߂�l</returns>
        // 2009.02.19 >>>
        //public new DialogResult ShowDialog()
        public new DialogResult ShowDialog(IWin32Window owner)
        // 2009.02.19 <<<
        {
            // --- ADD 杍^ 2014/09/01 Redmine#43289 -------------------- >>>
            // Thread���A�ԗ������擾���܂�
            carInfoSolt = Thread.GetNamedDataSlot(CARINFOSOLT);
            string carInfoStr = string.Empty;
            // Thread���A�ԗ������擾�ł���ꍇ�A
            if (Thread.GetData(carInfoSolt) != null)
            {
                CarInfoThreadData carInfoThreadData = (CarInfoThreadData)Thread.GetData(carInfoSolt);


                // �ޕ�(PM�̏��)
                this.tNedit_ModelDesignationNo.SetInt(carInfoThreadData.ModelDesignationNo);
                // �ԍ�(PM�̏��)
                this.tNedit_CategoryNo.SetInt(carInfoThreadData.CategoryNo);
                // �ԑ�ԍ�(PM��SF�v�Z��̏��)
                this.tEdit_ProduceFrameNo.Text = carInfoThreadData.FrameNo;
                // VIN�R�[�h�u1:���Y,2:�O�ԁv
                if (carInfoThreadData.FrameNoKubun == 2)
                {
                    this.uLabel_ProduceFrameNoTitle.Text = "VIN�R�[�h";
                    this.uLabel_ProduceFrameNoTitle.Size = new Size(80, 24);
                    // --- DEL 2014/09/22 ���� �d�|�ꗗ ��10598 ------------------------------>>>>>
                    //this.tEdit_ProduceFrameNo.Size = new Size(147, 24);
                    // --- DEL 2014/09/22 ���� �d�|�ꗗ ��10598 ------------------------------<<<<<
                }
                else
                {
                    this.uLabel_ProduceFrameNoTitle.Text = "�ԑ�ԍ�";
                    this.uLabel_ProduceFrameNoTitle.Size = new Size(67, 24);
                    // --- DEL 2014/09/22 ���� �d�|�ꗗ ��10598 ------------------------------>>>>>
                    //this.tEdit_ProduceFrameNo.Size = new Size(76, 24);
                    // --- DEL 2014/09/22 ���� �d�|�ꗗ ��10598 ------------------------------<<<<<
                }
                // �N���敪(PM�̏��)�S�̏����l�ݒ�}�X�^�́u0:����@1:�a��i�N���j�v
                if (carInfoThreadData.FirstEntryDateKubun == 0)
                {
                    // ����
                    this.tEdit_Gango.Visible = false;
                    this.tNedit_Wareki_Year.Visible = false;
                    this.tNedit_Sereki_Year.Visible = true;

                    // ����
                    if (carInfoThreadData.FirstEntryDate != 0)
                    {
                        this.tNedit_Sereki_Year.SetInt(carInfoThreadData.FirstEntryDate / 100); // ����N
                        this.tNedit_Month.SetInt(carInfoThreadData.FirstEntryDate % 100);�@// ���
                    }
                }
                else
                {
                    // �a��
                    this.tEdit_Gango.Visible = true;
                    this.tNedit_Wareki_Year.Visible = true;
                    this.tNedit_Sereki_Year.Visible = false;

                    // �a��
                    if (carInfoThreadData.FirstEntryDate != 0)
                    {
                        this.tNedit_Wareki_Year.SetInt(GetDateFW(carInfoThreadData.FirstEntryDate * 100 + 1)); // �a��N
                        this.tEdit_Gango.Text = TDateTime.LongDateToString("GG", carInfoThreadData.FirstEntryDate * 100 + 1); // �a���
                        this.tNedit_Month.SetInt(carInfoThreadData.FirstEntryDate % 100); // �a�
                    }
                }
                // ���[�J�[(PM�̏��)
                this.tNedit_MakerCode.SetInt(carInfoThreadData.MakerCode);
                // �Ԏ�(PM�̏��)(PM�̏��)
                this.tNedit_ModelCode.SetInt(carInfoThreadData.ModelCode);
                // �Ԏ�T�u�R�[�h(PM�̏��)
                this.tNedit_ModelSubCode.SetInt(carInfoThreadData.ModelSubCode);
                // �Ԏ햼(PM�̏��)
                this.tEdit_ModelFullName.Text = carInfoThreadData.ModelFullName;
                // �^��(PM��SF�v�Z��̏��)
                this.tEdit_FullModel.Text = carInfoThreadData.FullModel;
                // ���l(PM��SF�v�Z��̏��)
                this.tEdit_Note.Text = carInfoThreadData.Note;
                // ��ʌ�
                this._pgid = carInfoThreadData.Pgid;
            }

            // �������ω�ʂ�XML�t�@�C����ǂ�
            if (this._pgid.Equals(PMMIT01010U_PGID))
            {
                bool carInfoFlg = Deserialize(PMMIT01010U_PMKEN08060U_CARINFOSELETED);
                this.pnl_CarInfo.Visible = carInfoFlg;
                this.SetPnlCarInfoVisible(carInfoFlg);
            }
            // ���`��ʂ�XML�t�@�C����ǂ�
            else if (this._pgid.Equals(MAHNB01001U_PGID))
            {
                bool carInfoFlg = Deserialize(MAHNB01001U_PMKEN08060U_CARINFOSELETED);
                this.pnl_CarInfo.Visible = carInfoFlg;
                this.SetPnlCarInfoVisible(carInfoFlg);
            }
            // --- ADD 杍^ 2014/09/01 Redmine#43289 -------------------- <<<

            if (_prevRow != null && _prevRow.NewGoodsNo != string.Empty)
            {
                if (_prevSelInfo != null && _prevSelInfo.ListPlrlSubst.Count > 0)
                {
                    _prevSelInfo.Selected = true;
                    _prevSelInfo.ListPlrlSubst.RemoveAt(0); // 1�ڂ͑�֕i���Ȃ̂ō폜���Ă����B
                }
                PartsInfoDataSet.UsrGoodsInfoRow newRow =
                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_prevRow.GoodsMakerCd, _prevRow.NewGoodsNo);
                //if (_dsSet.SetMain[0].Equals(_prevRow)) // �Z�b�g�e�ɑ΂����ւ͏o���Ȃ��悤�ɐ�������B
                //{
                //    //_joinParts.PartsInfo[0].OldPartsNo = _joinParts.PartsInfo[0].ClgPrtsNo;
                //    //_joinParts.PartsInfo[0].ClgPrtsNo = newRow.GoodsNo;
                //    //_joinParts.PartsInfo[0].PartsName = newRow.GoodsName;
                //    //_joinParts.PartsInfo[0].Price = newRow.Price;
                //}
                //else
                if (_dsSet.SetMain[0].Equals(_prevRow) == false)
                {
                    string filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName, _prevRow.GoodsMakerCd,
                        //_dsSet.GoodsSet.SetSubOrgPrtNoColumn.ColumnName, _prevRow.GoodsNo);
                            _dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName, _prevRow.GoodsNo);
                    SetParts.GoodsSetRow oldRow = ((SetParts.GoodsSetRow[])_dsSet.GoodsSet.Select(filter))[0];
                    //SetParts.GoodsSetRow oldRow =
                    //    _dsSet.GoodsSet.FindBySetSubMakerCdSetSubPartsNo(_prevRow.GoodsMakerCd, _prevRow.GoodsNo);

                    oldRow.OldPartsNo = oldRow.SetSubPartsNo;
                    oldRow.SetSubPartsNo = newRow.GoodsNo;
                    oldRow.SubGoodsName = newRow.GoodsName;
                    if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                    {
                        oldRow.SetPrice = newRow.PriceTaxInc;
                        oldRow.GenTanka = newRow.UnitCostTaxInc;
                        oldRow.UriTanka = newRow.SalesUnitPriceTaxInc;
                    }
                    else
                    {
                        oldRow.SetPrice = newRow.PriceTaxExc;
                        oldRow.GenTanka = newRow.UnitCostTaxExc;
                        oldRow.UriTanka = newRow.SalesUnitPriceTaxExc;
                    }
                    // �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
                    oldRow.Ararigaku = newRow.SalesUnitPriceTaxExc - newRow.UnitCostTaxExc;
                    if (newRow.SalesUnitPriceTaxExc != 0)
                        oldRow.Arariritu = oldRow.Ararigaku / newRow.SalesUnitPriceTaxExc;

                    //oldRow.SetSpecialNote = newRow.GoodsSpecialNote;
                    //oldRow[_dsSet.GoodsSet.SubstColumn] = DBNull.Value;    // ��ւ������i�͂���ɑ�֑I��s��
                    filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName,
                            gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName].Value,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName,
                            gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName].Value);
                    _StockTable.DefaultView.RowFilter = filter;
                    SetStockGridSelect();
                    if (gridStock.Rows.Count == 0)
                    {
                        oldRow.Shelf = string.Empty;
                        oldRow.StockCnt = 0;
                        oldRow.Warehouse = string.Empty;
                    }
                    _dsSet.GoodsSet.AcceptChanges(); ////
                    //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = true;
                    ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled =
                            (gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SubstColumn.ColumnName].Value != System.DBNull.Value);
                }
                if (_prevRow.Equals(newRow) == false)
                    _prevRow.SelectionState = false;
                _prevRow.NewGoodsNo = string.Empty;
                _prevRow = null;
                GridSetParts_AfterSelectChange(this, null);
            }

            isUserClose = true;
            if (_orgRow.Equals(_orgDataSet.UsrGoodsInfo.RowToProcess) == false)
            {
                InitializeForm();
            }
            _selInf = _orgDataSet.SetSrcSelInf;
            if (_selInf.Depth == 0) // ���i�I��UI����̃Z�b�g�I���̏ꍇ
                _lstSelInf = _selInf.ListChildGoods2;
            else
                _lstSelInf = _selInf.ListChildGoods;

            _dsSet.SetMain[0].SelectionState = _selInf.Selected;
            _dsSet.SetMain[0].WarehouseCode = _selInf.WarehouseCode;
            if (_selInf.Selected)
            {
                _dsSet.SetMain[0].SelImage = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
            }
            else
            {
                _dsSet.SetMain[0][_dsSet.SetMain.SelImageColumn] = DBNull.Value;
            }

            Infragistics.Win.UltraWinGrid.RowsCollection rows = gridSetParts.Rows[0].ChildBands[0].Rows;
            int cnt = rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                if (_lstSelInf.ContainsKey(rows[i].ListIndex) && _lstSelInf[rows[i].ListIndex].Selected)
                {
                    rows[i].Cells[_dsSet.GoodsSet.SelectionStateColumn.ColumnName].Value = true;
                    rows[i].Cells[_dsSet.GoodsSet.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                }
                else
                {
                    rows[i].Cells[_dsSet.GoodsSet.SelectionStateColumn.ColumnName].Value = false;
                    //rows[i].SelectionState = false;
                    rows[i].Cells[_dsSet.GoodsSet.SelImageColumn.ColumnName].Value = DBNull.Value;
                }
            }

            //int cnt = _dsSet.GoodsSet.Count;
            //for (int i = 0; i < cnt; i++)
            //{
            //    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
            //        _dsSet.GoodsSet[i].SetSubMakerCd, _dsSet.GoodsSet[i].SetSubPartsNo);

            //    if (row != null)
            //    {
            //        _dsSet.GoodsSet[i].SelectionState = row.SelectionState;
            //        if (row.SelectionState)
            //        {
            //            _dsSet.GoodsSet[i].SelImage = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
            //        }
            //        else
            //        {
            //            _dsSet.GoodsSet[i][_dsSet.GoodsSet.SelImageColumn] = DBNull.Value;
            //        }
            //    }
            //}

            if (gridSetParts.Selected.Rows.Count > 0)
            {
                gridSetParts.Selected.Rows[0].Activated = true;
            }
            else
            {
                gridSetParts.Rows[0].Activate();
                gridSetParts.Rows[0].Selected = true;
            }

            cnt = _StockTable.Count;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.StockRow stockRow = _orgDataSet.Stock.FindByWarehouseCodeGoodsNoGoodsMakerCd(
                    _StockTable[i].WarehouseCode, _StockTable[i].GoodsNo, _StockTable[i].GoodsMakerCd);
                if (stockRow != null)
                {
                    _StockTable[i].SelectionState = stockRow.SelectionState;
                }
            }
            SetStockGridSelect();
            gridSetParts.UpdateData();
            // 2009.02.19 >>>
            //return base.ShowDialog();
            return base.ShowDialog(owner);
            // 2009.02.19 <<<
        }

        /// <summary>
        /// �e�[�u���쐬�y�уf�[�^�Z�b�g�ւ̒ǉ��A�����[�V�����ݒ�
        /// </summary>
        private void InitializeTable()
        {
            // DataTable �̐ݒ�

        }

        /// <summary>
        /// �R���g���[���̃f�[�^�Z�b�g��胍�[�J���f�[�^�Z�b�g�ւ̃f�[�^�R�s�[
        /// </summary>
        private void InitializeData()
        {
            // 2009.02.10 Add >>>
            this.SettingPriceTargetData();
            // 2009.02.10 Add <<<
            _dsSet = new SetParts();
            _StockTable = _dsSet.Stock;
            # region �f�[�^�̐ݒ�
            //_dsSet.GoodsSet.BeginLoadData();
            try
            {
                #region [ �Z�b�g�e�̐ݒ� ]
                if (_orgRow.NewGoodsNo != string.Empty)
                {
                    PartsInfoDataSet.UsrGoodsInfoRow rowNewPartsNo =
                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_orgRow.GoodsMakerCd, _orgRow.NewGoodsNo);
                    if (rowNewPartsNo != null)
                        _orgRow = rowNewPartsNo;
                }

                _JoinPartsNo = _orgRow.GoodsNo;
                _JoinMakerCode = _orgRow.GoodsMakerCd;

                SetParts.SetMainRow mainRow = _dsSet.SetMain.NewSetMainRow();
                mainRow.MakerCd = _orgRow.GoodsMakerCd;
                mainRow.MakerNm = _orgRow.GoodsMakerNm;
                mainRow.PartsNo = _orgRow.GoodsNo;
                if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                {
                    mainRow.Price = _orgRow.PriceTaxInc;
                    mainRow.UriTanka = _orgRow.SalesUnitPriceTaxInc;
                    mainRow.GenTanka = _orgRow.UnitCostTaxInc;
                }
                else
                {
                    mainRow.Price = _orgRow.PriceTaxExc;
                    mainRow.UriTanka = _orgRow.SalesUnitPriceTaxExc;
                    mainRow.GenTanka = _orgRow.UnitCostTaxExc;
                }
                // �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
                mainRow.Ararigaku = _orgRow.SalesUnitPriceTaxExc - _orgRow.UnitCostTaxExc;
                if (_orgRow.SalesUnitPriceTaxExc != 0)
                    mainRow.Arariritu = mainRow.Ararigaku / _orgRow.SalesUnitPriceTaxExc;

                if ((_orgRow.OfferKubun == 1 || _orgRow.OfferKubun == 3) &&  // �Z�b�g�e��������
                        _orgRow.SearchPartsFullName != string.Empty)
                {
                    mainRow.PrimePartsName = _orgRow.SearchPartsFullName;
                }
                else if (_orgRow.GoodsName != string.Empty)
                {
                    mainRow.PrimePartsName = _orgRow.GoodsName;
                }
                else
                {
                    mainRow.PrimePartsName = _orgRow.GoodsOfrName;
                }

                mainRow.SetSpecialNote = _orgRow.GoodsSpecialNote;
                mainRow.Qty = _orgRow.QTY;
                if (mainRow.Qty == 0)
                    mainRow.Qty = 1;

                //string filter = string.Format("{0}={1} AND {2}='{3}'",
                //    _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, mainRow.MakerCd,
                //    _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, mainRow.PartsNo);
                //if (_orgDataSet.UsrSubstParts.Select(filter).Length > 0)
                //    mainRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                if (SubstExists(mainRow.PartsNo, mainRow.MakerCd))
                {
                    mainRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                }

                _dsSet.SetMain.AddSetMainRow(mainRow);

                //�݌ɐݒ�
                bool flgStock = false;
                PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])_orgRow.GetChildRows("UsrGoodsInfo_Stock");
                for (int i = 0; i < stockRows.Length; i++)
                {
                    //mainRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN];
                    SetParts.StockRow stockRow = _StockTable.NewStockRow();
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
                    if (stockRows[i].SelectionState)
                    {
                        mainRow.Shelf = stockRow.WarehouseShelfNo;
                        mainRow.StockCnt = stockRow.ShipmentPosCnt;
                        mainRow.Warehouse = stockRow.WarehouseName;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                        mainRow.WarehouseCode = stockRow.WarehouseCode;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                        flgStock = true;
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
                                mainRow.Shelf = stockRows[k].WarehouseShelfNo;
                                mainRow.StockCnt = stockRows[k].ShipmentPosCnt;
                                mainRow.Warehouse = stockRows[k].WarehouseName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                                mainRow.WarehouseCode = stockRows[k].WarehouseCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                                flgStock = true;
                                break;
                            }
                        }
                        if (flgStock)
                            break;
                    }
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL // �D��q�ɂɂȂ��ꍇ�͎��ɂ���
                //if (flgStock == false && stockRows.Length > 0)
                //{
                //    mainRow.Shelf = stockRows[0].WarehouseShelfNo;
                //    mainRow.StockCnt = stockRows[0].ShipmentPosCnt;
                //    mainRow.Warehouse = stockRows[0].WarehouseName;
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                //    mainRow.WarehouseCode = stockRows[0].WarehouseCode;
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
                #endregion

                string filter = String.Format("{0}='{1}' and {2}={3}",
                    _setPartsTable.ParentGoodsNoColumn.ColumnName, _JoinPartsNo,
                    _setPartsTable.ParentGoodsMakerCdColumn.ColumnName, _JoinMakerCode);
                PartsInfoDataSet.UsrSetPartsRow[] setRows = (PartsInfoDataSet.UsrSetPartsRow[])_setPartsTable.Select(filter,
                    _setPartsTable.DisplayOrderColumn.ColumnName);

                for (int i = 0; i < setRows.Length; i++)
                {
                    PartsInfoDataSet.UsrSetPartsRow setRow = setRows[i];
                    PartsInfoDataSet.UsrGoodsInfoRow setPartsRow =
                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(setRow.SubGoodsMakerCd, setRow.SubGoodsNo);
                    if (setPartsRow == null) // null�ɂȂ�P�[�X�͂Ȃ��͂��Ȃ̂ŁB
                        continue;
                    // --- UPD m.suzuki 2011/02/02 ---------->>>>>
                    # region // DEL
                    //if (substFlg != 1 || PartsStockCheck(setRow.SubGoodsNo, setRow.SubGoodsMakerCd) == false)
                    //{       // [��֏����F�݌ɔ���L�@���@���i�݌ɂ���̏ꍇ]�ȊO�͍ŐV�i�Ԃɑ�ւ���B
                    //    PartsInfoDataSet.UsrGoodsInfoRow rowNew = _orgDataSet.GetOfrSubst(setPartsRow);
                    //    if (userSubstFlg != 0) // ���[�U�[��ւ��Ȃ��ȊO�̏ꍇ
                    //    {
                    //        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst(setPartsRow);
                    //        if (rowSubst.Equals(setPartsRow)) // ���D�Ǖi�ɑ΂����[�U�[��ւ��Ȃ�
                    //        {
                    //            if (rowNew.Equals(setPartsRow) == false) // �ŐV�i�Ԃ�����ꍇ
                    //            {
                    //                rowSubst = _orgDataSet.GetUsrSubst(rowNew);
                    //                if (rowSubst.Equals(rowNew)) // �ŐV�i�ɑ΂����[�U�[��ւȂ�
                    //                {
                    //                    setPartsRow = rowNew;
                    //                }
                    //                else // �ŐV�i�ɑ΂����[�U�[��ւ���
                    //                {
                    //                    setPartsRow = rowSubst;
                    //                }
                    //            }
                    //        }
                    //        else // ���D�Ǖi�ɑ΂����[�U�[��ւ�����ꍇ
                    //        {
                    //            setPartsRow = rowSubst;
                    //        }
                    //    }
                    //    else // ���[�U�[��ւ��Ȃ��̏ꍇ�ŐV�i�Ԃɑ�ւ���B
                    //    {
                    //        setPartsRow = rowNew;
                    //    }
                    //    //row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);
                    //}
                    # endregion

                    // ��֌��̍݌Ƀ`�F�b�N
                    bool stockCountNotZero;
                    if ( PartsStockCheck( setRow.SubGoodsNo, setRow.SubGoodsMakerCd, out stockCountNotZero ) == false ||
                         stockCountNotZero == false )
                    {
                        // ���[�U�[��֋敪
                        if ( userSubstFlg != 0 )
                        {
                            PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( setPartsRow );
                            if ( rowSubst.Equals( setPartsRow ) == false )
                            {
                                // ���[�U�[��֐�ɑ��
                                setPartsRow = rowSubst;
                            }
                        }
                    }
                    // --- UPD m.suzuki 2011/02/02 ----------<<<<<

                    SetParts.GoodsSetRow wkRow = _dsSet.GoodsSet.NewGoodsSetRow();

                    wkRow.SetMainPartsNo = setRow.ParentGoodsNo;
                    wkRow.SetSubPartsNo = setPartsRow.GoodsNo;
                    wkRow.SetSubOrgPrtNo = setRow.SubGoodsNo;
                    wkRow.SetSubMakerCd = setPartsRow.GoodsMakerCd;
                    wkRow.SetQty = setRow.CntFl;
                    if (wkRow.SetQty == 0)
                        wkRow.SetQty = 1;
                    wkRow.SetSpecialNote = setRow.SetSpecialNote;
                    wkRow.CatalogShapeNo = setRow.CatalogShapeNo;
                    wkRow.SetMainRowParent = mainRow;

                    wkRow.SetSubMakerName = setPartsRow.GoodsMakerNm;
                    if (setPartsRow.GoodsName != string.Empty)
                    {
                        wkRow.SubGoodsName = setPartsRow.GoodsName;
                    }
                    else
                    {
                        wkRow.SubGoodsName = setPartsRow.GoodsOfrName;
                    }
                    if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                    {
                        wkRow.SetPrice = setPartsRow.PriceTaxInc;
                        wkRow.UriTanka = setPartsRow.SalesUnitPriceTaxInc;
                        wkRow.GenTanka = setPartsRow.UnitCostTaxInc;
                    }
                    else
                    {
                        wkRow.SetPrice = setPartsRow.PriceTaxExc;
                        wkRow.UriTanka = setPartsRow.SalesUnitPriceTaxExc;
                        wkRow.GenTanka = setPartsRow.UnitCostTaxExc;
                    }
                    // �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
                    wkRow.Ararigaku = setPartsRow.SalesUnitPriceTaxExc - setPartsRow.UnitCostTaxExc;
                    if (setPartsRow.SalesUnitPriceTaxExc != 0)
                        wkRow.Arariritu = wkRow.Ararigaku / setPartsRow.SalesUnitPriceTaxExc;

                    filter = String.Format("{0}='{1}' and {2}={3}",
                                _orgDataSet.GoodsSet.SetMainPartsNoColumn.ColumnName, _JoinPartsNo,
                                _orgDataSet.GoodsSet.SetMainMakerCdColumn.ColumnName, _JoinMakerCode);
                    PartsInfoDataSet.GoodsSetRow[] ofrSetRows = (PartsInfoDataSet.GoodsSetRow[])_orgDataSet.GoodsSet.Select(filter);
                    if (ofrSetRows.Length > 0)
                    {
                        wkRow.SetName = ofrSetRows[0].SetName;
                    }
                    if (SubstExists(wkRow.SetSubOrgPrtNo, wkRow.SetSubMakerCd))
                    {
                        wkRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                    }
                    _dsSet.GoodsSet.AddGoodsSetRow(wkRow);

                    #region [ �݌ɐݒ� ]
                    filter = string.Format("{0}={1} AND {2}='{3}'",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, wkRow.SetSubMakerCd,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName, wkRow.SetSubPartsNo);
                    stockRows = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(filter);
                    flgStock = false;
                    for (int j = 0; j < stockRows.Length; j++)
                    {
                        if (_StockTable.FindByWarehouseCodeGoodsMakerCdGoodsNo(stockRows[j].WarehouseCode,
                            stockRows[j].GoodsMakerCd, stockRows[j].GoodsNo) == null)
                        {
                            SetParts.StockRow stockRow = _StockTable.NewStockRow();
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
                                wkRow.Shelf = stockRow.WarehouseShelfNo;
                                wkRow.StockCnt = stockRow.ShipmentPosCnt;
                                wkRow.Warehouse = stockRow.WarehouseName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                                wkRow.WarehouseCode = stockRow.WarehouseCode;
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
                                    wkRow.Shelf = stockRows[k].WarehouseShelfNo;
                                    wkRow.StockCnt = stockRows[k].ShipmentPosCnt;
                                    wkRow.Warehouse = stockRows[k].WarehouseName;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                                    wkRow.WarehouseCode = stockRows[k].WarehouseCode;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                                    flgStock = true;
                                    break;
                                }
                            }
                            if (flgStock)
                                break;
                        }
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL // �D��q�ɂɖ����ꍇ�͎��ɂ���
                    //if (flgStock == false && stockRows.Length > 0)
                    //{
                    //    wkRow.Shelf = stockRows[0].WarehouseShelfNo;
                    //    wkRow.StockCnt = stockRows[0].ShipmentPosCnt;
                    //    wkRow.Warehouse = stockRows[0].WarehouseName;
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                    //    wkRow.WarehouseCode = stockRows[0].WarehouseCode;
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
                    #endregion
                }
            }
            finally
            {
                _dsSet.AcceptChanges();
                //_dsSet.GoodsSet.EndLoadData();
                gridSetParts.BeginUpdate();
                gridSetParts.DataSource = _dsSet.SetMain.DefaultView;
                gridSetParts.EndUpdate();
                gridStock.DataSource = _StockTable.DefaultView;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
                SettingStockView( _StockTable.DefaultView );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
            }

            # endregion
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
                                            _StockTable.SortDivColumn.ColumnName,
                                            _StockTable.WarehouseCodeColumn.ColumnName );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD

        // 2009.02.10 Add >>>
        /// <summary>
        /// �Ώۃf�[�^�̉��i�ݒ�
        /// </summary>
        private void SettingPriceTargetData()
        {
            if (_orgDataSet.CalculateGoodsPrice == null) return;

            List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList = new List<PartsInfoDataSet.GoodsPrimaryKey>();

            // ������
            goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(_orgRow.GoodsNo, _orgRow.GoodsMakerCd));

            string filter = String.Format("{0}='{1}' and {2}={3}",
                _setPartsTable.ParentGoodsNoColumn.ColumnName, _orgRow.GoodsNo,
                _setPartsTable.ParentGoodsMakerCdColumn.ColumnName, _orgRow.GoodsMakerCd);
            PartsInfoDataSet.UsrSetPartsRow[] setRows = (PartsInfoDataSet.UsrSetPartsRow[])_setPartsTable.Select(filter,
                _setPartsTable.DisplayOrderColumn.ColumnName);

            for (int i = 0; i < setRows.Length; i++)
            {
                PartsInfoDataSet.UsrSetPartsRow setRow = setRows[i];
                PartsInfoDataSet.UsrGoodsInfoRow setPartsRow =
                    _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(setRow.SubGoodsMakerCd, setRow.SubGoodsNo);
                if (setPartsRow == null) // null�ɂȂ�P�[�X�͂Ȃ��͂��Ȃ̂ŁB
                    continue;
                // --- UPD m.suzuki 2011/02/02 ---------->>>>>
                # region // DEL
                //if (substFlg != 1 || PartsStockCheck(setRow.SubGoodsNo, setRow.SubGoodsMakerCd) == false)
                //{       // [��֏����F�݌ɔ���L�@���@���i�݌ɂ���̏ꍇ]�ȊO�͍ŐV�i�Ԃɑ�ւ���B
                //    PartsInfoDataSet.UsrGoodsInfoRow rowNew = _orgDataSet.GetOfrSubst(setPartsRow);
                //    if (userSubstFlg != 0) // ���[�U�[��ւ��Ȃ��ȊO�̏ꍇ
                //    {
                //        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst(setPartsRow);
                //        if (rowSubst.Equals(setPartsRow)) // ���D�Ǖi�ɑ΂����[�U�[��ւ��Ȃ�
                //        {
                //            if (rowNew.Equals(setPartsRow) == false) // �ŐV�i�Ԃ�����ꍇ
                //            {
                //                rowSubst = _orgDataSet.GetUsrSubst(rowNew);
                //                if (rowSubst.Equals(rowNew)) // �ŐV�i�ɑ΂����[�U�[��ւȂ�
                //                {
                //                    setPartsRow = rowNew;
                //                }
                //                else // �ŐV�i�ɑ΂����[�U�[��ւ���
                //                {
                //                    setPartsRow = rowSubst;
                //                }
                //            }
                //        }
                //        else // ���D�Ǖi�ɑ΂����[�U�[��ւ�����ꍇ
                //        {
                //            setPartsRow = rowSubst;
                //        }
                //    }
                //    else // ���[�U�[��ւ��Ȃ��̏ꍇ�ŐV�i�Ԃɑ�ւ���B
                //    {
                //        setPartsRow = rowNew;
                //    }
                //    //row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);
                //}
                # endregion

                // ��֌��̍݌Ƀ`�F�b�N
                bool stockCountNotZero;
                if ( PartsStockCheck( setRow.SubGoodsNo, setRow.SubGoodsMakerCd, out stockCountNotZero ) == false ||
                     stockCountNotZero == false )
                {
                    // ���[�U�[��֋敪
                    if ( userSubstFlg != 0 )
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( setPartsRow );
                        if ( rowSubst.Equals( setPartsRow ) == false )
                        {
                            // ���[�U�[��֐�ɑ��
                            setPartsRow = rowSubst;
                        }
                    }
                }
                // --- UPD m.suzuki 2011/02/02 ----------<<<<<

                if (setPartsRow != null)
                {
                    goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(setPartsRow.GoodsNo, setPartsRow.GoodsMakerCd));
                }
            }

            // ���i��񂪑��݂���ꍇ�͉��i�v�Z
            if (goodsPrimaryKeyList.Count > 0)
            {
                _orgDataSet.SettingGoodsPrice(goodsPrimaryKeyList);
            }
        }
        // 2009.02.10 Add <<<

        #endregion

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
        // --- ADD m.suzuki 2011/02/02 ---------->>>>>
        /// <summary>
        /// �J�^���O�i�Ԃ̌��݌ɐ��`�F�b�N(2)
        /// </summary>
        /// <param name="parts">�i��</param>
        /// <param name="maker">���[�J�[</param>
        /// <param name="stockCountNotZero"></param>
        /// <returns>true:���݌ɐ�����@false:���݌ɂȂ�</returns>
        internal bool PartsStockCheck( string parts, int maker, out bool stockCountNotZero )
        {
            bool ret = false;
            stockCountNotZero = false;

            // --- ADD m.suzuki 2011/02/09 ---------->>>>>
            if ( _orgDataSet.ListPriorWarehouse == null ||
                 _orgDataSet.ListPriorWarehouse.Count == 0 )
            {
                return false;
            }
            // --- ADD m.suzuki 2011/02/09 ----------<<<<<
            // --- ADD m.suzuki 2011/02/18 ---------->>>>>
            bool settingFlag = false;
            foreach ( string warehouseCd in _orgDataSet.ListPriorWarehouse )
            {
                if ( !string.IsNullOrEmpty( warehouseCd ) )
                {
                    settingFlag = true;
                    break;
                }
            }
            if ( settingFlag == false )
            {
                return false;
            }
            // --- ADD m.suzuki 2011/02/18 ----------<<<<<
            string rowFilter = String.Format( "{0}='{1}' AND {2}={3}",
                        _orgDataSet.Stock.GoodsNoColumn.ColumnName, parts,
                        _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, maker );
            // --- ADD m.suzuki 2011/02/09 ---------->>>>>
            rowFilter += " AND (";
            foreach ( string priorWarehouse in _orgDataSet.ListPriorWarehouse )
            {
                if ( string.IsNullOrEmpty( priorWarehouse ) ) continue;
                rowFilter += string.Format( " {0}='{1}' OR", _orgDataSet.Stock.WarehouseCodeColumn.ColumnName, priorWarehouse );
            }
            rowFilter = rowFilter.Remove( rowFilter.Length - 2, 2 );
            rowFilter += ")";
            // --- ADD m.suzuki 2011/02/09 ----------<<<<<
            PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select( rowFilter );

            if ( rowStock.Length > 0 )
            {
                // �݌Ƀ��R�[�h����
                ret = true;

                // �݌ɐ�>0�̃��R�[�h�L���𔻒�
                for ( int i = 0; i < rowStock.Length; i++ )
                {
                    if ( rowStock[i].ShipmentPosCnt > 0 )
                    {
                        // �݌ɐ�>0�̍݌ɂ����݂���
                        stockCountNotZero = true;
                        break;
                    }
                }
            }

            return ret;
        }
        // --- ADD m.suzuki 2011/02/02 ----------<<<<<

        internal bool SubstExists(string parts, int maker)
        {
            // --- UPD m.suzuki 2011/02/02 ---------->>>>>
            //if (substFlg == 0) // �u��ւ��Ȃ��v�̎��͖�����false
            //    return false;
            //string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4} = true", // ��֑I��UI�ɂ͒񋟂̂ݕ\��
            //    _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, parts,
            //    _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, maker, _orgDataSet.UsrSubstParts.OfferKubunColumn.ColumnName);
            //if (_orgDataSet.UsrSubstParts.Select(rowFilter).Length > 0)
            //{
            //    if (substFlg == 2) // �u�݌ɔ���Ȃ��v�̎��́@��ւ����邾����true
            //    {
            //        return true;
            //    }
            //    else // �u�݌ɔ��肠��v�̎��͑�ւ��芎��֌��i�̌��݌ɐ��Ȃ��̎��̂�true
            //    {
            //        if (PartsStockCheck(parts, maker) == false) // ���݌ɂȂ��Ȃ�u�݌ɔ���L�v�ł���։�
            //        {
            //            return true;
            //        }
            //    }
            //}
            //return false;
            return false;
            // --- UPD m.suzuki 2011/02/02 ----------<<<<<
        }

        #region [ �t�H�[���C�x���g���� ]
        /// <summary>
        /// ESC�L�[�����ɂ��I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionFormSet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                isUserClose = false;
            }
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
        private void SelectionFormSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- >>>
            bool carInfoFlg = this.pnl_CarInfo.Visible;

            if (this._pgid.Equals(PMMIT01010U_PGID))
            {
                Serialize(carInfoFlg, PMMIT01010U_PMKEN08060U_CARINFOSELETED);
            }
            else if (this._pgid.Equals(MAHNB01001U_PGID))
            {
                Serialize(carInfoFlg, MAHNB01001U_PMKEN08060U_CARINFOSELETED);
            }
            // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- <<<

            if (DialogResult == DialogResult.Cancel)
            {
                //_orgDataSet.UsrGoodsInfo.RowToProcess = _orgDataSet.UsrGoodsInfo.PreviouslyProcessedRow;
                return;
            }
            //bool flg = false;

            //_orgRow.SelectionState = _dsSet.SetMain[0].SelectionState;
            _selInf.Selected = _dsSet.SetMain[0].SelectionState;
            if (_dsSet.SetMain[0].SelectionState)
            {
                _selInf.RowGoods.QTY = _dsSet.SetMain[0].Qty;
                _selInf.RowGoods.GoodsKindResolved = (int)GoodsKind.Parent;
                _selInf.WarehouseCode = _dsSet.SetMain[0].WarehouseCode;
            }

            Infragistics.Win.UltraWinGrid.RowsCollection rows = gridSetParts.Rows[0].ChildBands[0].Rows;
            int cnt = rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                if (rows[i].Cells[_dsSet.GoodsSet.SelectionStateColumn.ColumnName].Value.Equals(true))
                {
                    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                        (int)rows[i].Cells[_dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName].Value,
                        rows[i].Cells[_dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName].Value.ToString());
                    //_joinParts.JoinParts[i].JoinDestMakerCd,
                    //_joinParts.JoinParts[i].JoinDestPartsNo);
                    if (row != null)
                    {
                        row.QTY = _dsSet.GoodsSet[i].SetQty;
                        // 2009/11/26 >>>
                        //row.GoodsKindResolved = (int)GoodsKind.Join;
                        row.GoodsKindResolved = (int)GoodsKind.Set;
                        // 2009/11/26 <<<

                        SelectionInfo selInfo = new SelectionInfo();
                        selInfo.Depth = 2;
                        selInfo.Key = rows[i].ListIndex;
                        selInfo.RowGoods = row;
                        selInfo.Selected = true;
                        // 2009/11/26 >>>
                        selInfo.WarehouseCode = rows[i].Cells[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Value.ToString();
                        // 2009/11/26 <<<
                        if (gridSetParts.ActiveRow != null && gridSetParts.ActiveRow.Index == i
                            && _orgDataSet.UIKind == SelectUIKind.Subst)
                        {
                            _orgDataSet.SubstSrcSelInf = selInfo;
                            _prevSelInfo = selInfo;
                        }
                        _orgDataSet.AddSelectionInfo(_lstSelInf, rows[i].ListIndex, ref selInfo);
                    }
                }
                else
                {
                    _orgDataSet.RemoveSelectionInfo(_lstSelInf, rows[i].ListIndex);
                }
            }
            //int cnt = _dsSet.GoodsSet.Count;
            //for (int i = 0; i < cnt; i++)
            //{
            //    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
            //        _dsSet.GoodsSet[i].SetSubMakerCd,
            //        _dsSet.GoodsSet[i].SetSubPartsNo);
            //    if (row != null)
            //    {
            //        row.SelectionState = _dsSet.GoodsSet[i].SelectionState;
            //        if (_dsSet.GoodsSet[i].SelectionState)
            //        {
            //            row.QTY = _dsSet.GoodsSet[i].SetQty;
            //            row.GoodsKindResolved = (int)GoodsKind.Set;
            //        }
            //        if (row.SelectionState)
            //            flg = true;
            //    }
            //}

            cnt = _StockTable.Count;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.StockRow stockRow = _orgDataSet.Stock.FindByWarehouseCodeGoodsNoGoodsMakerCd(
                    _StockTable[i].WarehouseCode, _StockTable[i].GoodsNo, _StockTable[i].GoodsMakerCd);
                if (stockRow != null)
                {
                    stockRow.SelectionState = _StockTable[i].SelectionState;
                }
            }
        }

        private void SelectionFormSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (uiControlFlg && e.CloseReason == CloseReason.UserClosing && isUserClose)
            //{
            //    if (TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Text,
            //        "�ȑO�̑I����ʂɖ߂炸�A�I�����L�����Z�����܂����H", 0, MessageBoxButtons.YesNo)
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
                    //_orgDataSet.UsrGoodsInfo.RowToProcess = _orgDataSet.UsrGoodsInfo.PreviouslyProcessedRow;
                    if (enterFlg == 2) // Enter�L�[���u����ʁv�̏ꍇ
                    {
                        SetSelect(false);
                    }
                    else
                    {
                        if (uiControlFlg == false && _dsSet.SetMain[0].SelectionState == false
                           && _dsSet.GoodsSet.Select("SelectionState = true").Length == 0)
                        {
                            SetStatusBarText(1, "�f�[�^�̑I��������Ă��܂���B");
                            break;
                        }
                        DialogResult = DialogResult.OK;
                    }
                    isUserClose = false;
                    break;

                case "Button_Back":
                    // �O�̉�ʂɖ߂�
                    DialogResult = DialogResult.Cancel;
                    isUserClose = false;
                    break;

                case "Button_Subst":
                    UltraGridRow activeRow = gridSetParts.ActiveRow;
                    if (activeRow != null)
                    {
                        if (activeRow.Cells[_dsSet.GoodsSet.SubstColumn.ColumnName].Value != DBNull.Value)
                        {
                            int makerCd;
                            string partsNo;
                            if (activeRow.Band.ParentBand == null) // �e�o���h�̏ꍇ
                            {
                                makerCd = (int)activeRow.Cells[_dsSet.SetMain.MakerCdColumn.ColumnName].Value;
                                partsNo = activeRow.Cells[_dsSet.SetMain.PartsNoColumn.ColumnName].Value.ToString();
                            }
                            else
                            {
                                makerCd = (int)activeRow.Cells[_dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName].Value;
                                partsNo = activeRow.Cells[_dsSet.GoodsSet.SetSubOrgPrtNoColumn.ColumnName].Value.ToString();
                            }
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                activeRow.Cells[_dsSet.GoodsSet.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                //_prevRow = row;
                                _prevRow = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd,
                                       activeRow.Cells[_dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName].Value.ToString());
                                _orgDataSet.UIKind = SelectUIKind.Subst;
                                DialogResult = DialogResult.Retry;
                                isUserClose = false;
                            }
                        }
                    }
                    break;

                // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- >>>
                case "Button_Car":
                    if (this.pnl_CarInfo.Visible == false)
                    {
                        this.pnl_CarInfo.Visible = true;
                    }
                    else
                    {
                        this.pnl_CarInfo.Visible = false;
                    }

                    this.SetPnlCarInfoVisible(this.pnl_CarInfo.Visible);
                    break;
                // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- <<<

                /*case "Button_SubstOff":
                    if (gridSetParts.ActiveRow != null &&
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.OldPartsNoColumn.ColumnName].Value.Equals(string.Empty) == false)
                    {
                        int makerCd = (int)gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName].Value;
                        string partsNo = gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName].Value.ToString();
                        string oldPartsNo = gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.OldPartsNoColumn.ColumnName].Value.ToString();
                        string setDestNo = gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubOrgPrtNoColumn.ColumnName].Value.ToString();
                        SetParts.GoodsSetRow oldRow = _dsSet.GoodsSet.FindBySetSubMakerCdSetSubPartsNo(makerCd, partsNo); // TODO : ������
                        PartsInfoDataSet.UsrGoodsInfoRow newRow =
                            _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, oldPartsNo);

                        oldRow.OldPartsNo = string.Empty;
                        oldRow.SetSubPartsNo = newRow.GoodsNo;
                        oldRow.SubGoodsName = newRow.GoodsName;
                        oldRow.SetPrice = newRow.Price;
                        oldRow.GenTanka = newRow.UnitCost;
                        oldRow.UriTanka = newRow.SalesUnitPrice;
                        if (newRow.UnitCost != 0)
                            oldRow.Arariritu = oldRow.Ararigaku / newRow.UnitCost;
                        //oldRow.SetSpecialNote = newRow.GoodsSpecialNote;
                        if (SubstExists(setDestNo, makerCd))
                        {
                            oldRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                        }

                        string filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName,
                            gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName].Value,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName,
                            gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName].Value);
                        _dsSet.Stock.DefaultView.RowFilter = filter;
                        SetStockGridSelect();
                        if (gridStock.Rows.Count == 0)
                        {
                            oldRow.ShelfNo = string.Empty;
                            oldRow.StockCnt = 0;
                            oldRow.Warehouse = string.Empty;
                        }

                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo).SelectionState = false; // ��։����������i�̑I����Ԃ�false�ɂ���B
                        PartsInfoDataSet.SubstPartsInfoRow substRow = _orgDataSet.SubstPartsInfo.
                            FindByNewPartsNoWithHyphenCatalogPartsMakerCdOldPartsNoWithHyphen(partsNo, makerCd, oldPartsNo);
                        if (substRow != null)
                        {
                            PartsInfoDataSet.DSubstPartsInfoRow[] dSubstRows = substRow.GetDSubstPartsInfoRows();
                            for (int i = 0; i < dSubstRows.Length; i++)
                            {
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(dSubstRows[i].CatalogPartsMakerCd, dSubstRows[i].NewPartsNoWithHyphen).SelectionState = false;
                            }
                        }

                        ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled =
                            (gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SubstColumn.ColumnName].Value != System.DBNull.Value);
                        //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
                        GridSetParts_AfterSelectChange(this, null);
                    }
                    break;*/
            }
        }
        #endregion

        #region [ �O���b�h�C�x���g���� ]
        /// <summary>
        /// �A�N�e�B�u�s�ύX��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridSetParts_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (isSelectChangeDisabled)
                return;
            bool ena = false;
            bool enaSubstOff = false;
            string filter = string.Empty;
            try
            {
                if (gridSetParts.Selected.Rows.Count == 0)
                    return;
                if (gridSetParts.Selected.Rows[0].Activated == false)
                    gridSetParts.Selected.Rows[0].Activate();
                if (gridSetParts.ActiveRow.Band.ParentBand == null)
                {
                    filter = string.Format("{0}={1} AND {2}='{3}'",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, _orgRow.GoodsMakerCd,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName, _orgRow.GoodsNo);
                }
                else
                {
                    ena = (gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SubstColumn.ColumnName].Value != System.DBNull.Value);
                    enaSubstOff = (gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.OldPartsNoColumn.ColumnName].Value.Equals(string.Empty) == false);
                    filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName,
                            gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName].Value,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName,
                            gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName].Value);
                }
            }
            finally
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled = ena;
                //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = enaSubstOff;
                _StockTable.DefaultView.RowFilter = filter;
            }
            SetStockGridSelect();
        }

        /// <summary>
        /// InitializeLayout �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�O���b�h�̃��C�A�E�g����������</br>
        /// </remarks>
        private void GridSetParts_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // �񕝂̎����������@
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            UltraGridBand band0 = e.Layout.Bands[0];
            band0.Indentation = 0;
            //band0.Override.HeaderPlacement = HeaderPlacement.FixedOnTop;
            band0.Override.RowSelectorWidth = 24;
            band0.UseRowLayout = true;

            ColInfo.SetColInfo(band0, _dsSet.SetMain.SelImageColumn.ColumnName, 2, 0, 1, 4, 16);
            if (substFlg != 0) // �u��ւ��Ȃ��v�ȊO
            {
                ColInfo.SetColInfo(band0, _dsSet.SetMain.SubstColumn.ColumnName, 46, 0, 1, 4, 16);
            }
            ColInfo.SetColInfo(band0, _dsSet.SetMain.MakerCdColumn.ColumnName, 3, 0, 3, 2, 25);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.MakerNmColumn.ColumnName, 6, 0, 10, 2, 95);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.PrimePartsNameColumn.ColumnName, 16, 0, 14, 2, 140);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.WarehouseColumn.ColumnName, 30, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.QtyColumn.ColumnName, 34, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.GenTankaColumn.ColumnName, 38, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.ArarirituColumn.ColumnName, 42, 0, 4, 2, 40);

            ColInfo.SetColInfo(band0, _dsSet.SetMain.SetSpecialNoteColumn.ColumnName, 3, 2, 13, 2, 130);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.PartsNoColumn.ColumnName, 16, 2, 10, 2, 100);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.ShelfColumn.ColumnName, 26, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.StockCntColumn.ColumnName, 30, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.PriceColumn.ColumnName, 34, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.UriTankaColumn.ColumnName, 38, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _dsSet.SetMain.ArarigakuColumn.ColumnName, 42, 2, 4, 2, 40);

            band0.Columns[_dsSet.SetMain.SelectionStateColumn.ColumnName].Hidden = true;
            band0.Columns[_dsSet.SetMain.CatalogShapeNoColumn.ColumnName].Hidden = true;
            //band0.Columns[_dsSet.SetMain.MakerCdColumn.ColumnName].Hidden = true;
            band0.Columns[_dsSet.SetMain.OldPartsNoColumn.ColumnName].Hidden = true;
            band0.Columns[_dsSet.SetMain.WarehouseCodeColumn.ColumnName].Hidden = true;
            if (substFlg == 0) // �u��ւ��Ȃ��v�͑�փJ������\�����Ȃ��B
            {
                band0.Columns[_dsSet.SetMain.SubstColumn.ColumnName].Hidden = true;
            }

            for (int i = 0; i < band0.Columns.Count; i++)
            {
                // �����\���ʒu
                if ((band0.Columns[i].DataType == typeof(int)) ||
                   (band0.Columns[i].DataType == typeof(double)) ||
                   (band0.Columns[i].DataType == typeof(Int64)))
                {
                    band0.Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (band0.Columns[i].DataType == typeof(Image))
                {
                    band0.Columns[i].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    band0.Columns[i].CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                }
                else
                {
                    band0.Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band0.Columns[i].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // �����\���ʒu
                band0.Columns[i].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            band0.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;

            band0.Columns[_dsSet.SetMain.MakerCdColumn.ColumnName].Format = "0000";
            band0.Columns[_dsSet.SetMain.PriceColumn.ColumnName].Format = "C";
            band0.Columns[_dsSet.SetMain.GenTankaColumn.ColumnName].Format = "C";
            band0.Columns[_dsSet.SetMain.UriTankaColumn.ColumnName].Format = "C";
            band0.Columns[_dsSet.SetMain.ArarigakuColumn.ColumnName].Format = "C";
            band0.Columns[_dsSet.SetMain.ArarirituColumn.ColumnName].Format = "#%";
            band0.Columns[_dsSet.SetMain.StockCntColumn.ColumnName].Format = "###,###,##0.00";
            band0.Columns[_dsSet.SetMain.QtyColumn.ColumnName].Format = "###,###,##0.00";
            gridSetParts.DisplayLayout.InterBandSpacing = 3;

            // �o���h�̎擾
            UltraGridBand band1 = e.Layout.Bands[1];
            band0.ColHeadersVisible = false;
            band1.Override.HeaderPlacement = HeaderPlacement.FixedOnTop;
            band1.Indentation = 0;
            band1.UseRowLayout = true;
            band1.Override.DefaultRowHeight = 20;
            band1.Override.RowSelectorWidth = 24;

            for (int i = 0; i < band1.Columns.Count; i++)
            {
                // �����\���ʒu
                if ((band1.Columns[i].DataType == typeof(int)) ||
                   (band1.Columns[i].DataType == typeof(double)) ||
                   (band1.Columns[i].DataType == typeof(Int64)))
                {
                    band1.Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (band1.Columns[i].DataType == typeof(Image))
                {
                    band1.Columns[i].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    band1.Columns[i].CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                }
                else
                {
                    band1.Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band1.Columns[i].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // �����\���ʒu
                band1.Columns[i].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            band1.Columns[_dsSet.GoodsSet.CatalogShapeNoColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.SetDisplayOrderColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.SetMainMakerCdColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.SetMainPartsNoColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.SetNameColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.SelectionStateColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.OldPartsNoColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.SetSubOrgPrtNoColumn.ColumnName].Hidden = true;
            band1.Columns[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Hidden = true;
            if (substFlg == 0) // �u��ւ��Ȃ��v�͑�փJ������\�����Ȃ��B
            {
                band1.Columns[_dsSet.GoodsSet.SubstColumn.ColumnName].Hidden = true;
            }
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SelImageColumn.ColumnName, 2, 0, 1, 4, 16);
            if (substFlg != 0) // �u��ւ��Ȃ��v�ȊO
            {
                ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SubstColumn.ColumnName, 46, 0, 1, 4, 16);
            }
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName, 3, 0, 3, 2, 25);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SetSubMakerNameColumn.ColumnName, 6, 0, 10, 2, 95);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SubGoodsNameColumn.ColumnName, 16, 0, 14, 2, 140);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.WarehouseColumn.ColumnName, 30, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SetQtyColumn.ColumnName, 34, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.GenTankaColumn.ColumnName, 38, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.ArarirituColumn.ColumnName, 42, 0, 4, 2, 40);

            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SetSpecialNoteColumn.ColumnName, 3, 2, 13, 2, 130);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SetSubPartsNoColumn.ColumnName, 16, 2, 10, 2, 100);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.ShelfColumn.ColumnName, 26, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.StockCntColumn.ColumnName, 30, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.SetPriceColumn.ColumnName, 34, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.UriTankaColumn.ColumnName, 38, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _dsSet.GoodsSet.ArarigakuColumn.ColumnName, 42, 2, 4, 2, 40);

            band1.Columns[_dsSet.GoodsSet.SetSubMakerCdColumn.ColumnName].Format = "0000";
            band1.Columns[_dsSet.GoodsSet.SetPriceColumn.ColumnName].Format = "C";
            band1.Columns[_dsSet.GoodsSet.GenTankaColumn.ColumnName].Format = "C";
            band1.Columns[_dsSet.GoodsSet.UriTankaColumn.ColumnName].Format = "C";
            band1.Columns[_dsSet.GoodsSet.ArarigakuColumn.ColumnName].Format = "C";
            band1.Columns[_dsSet.GoodsSet.ArarirituColumn.ColumnName].Format = "#%";
            band1.Columns[_dsSet.GoodsSet.StockCntColumn.ColumnName].Format = "###,###,##0.00";
            band1.Columns[_dsSet.GoodsSet.SetQtyColumn.ColumnName].Format = "###,###,##0.00";
        }

        /// <summary>
        /// �s���_�u���N���b�N���ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// �f�[�^���\������Ă��Ȃ��s���_�u���N���b�N���Ă��{�C�x���g�͔������Ȃ��B
        /// </remarks>
        private void GridSetParts_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SetSelect(false);
        }

        /// <summary>
        /// �O���b�h���Enter�L�[�������ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridSetParts_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (gridSetParts.ActiveRow != null && gridSetParts.ActiveRow.ParentRow == null) // �e�o���h��
                    {
                        gridSetParts.ActiveRow.ChildBands[0].Rows[0].Activate();
                        gridSetParts.ActiveRow.Selected = true;
                        e.Handled = true;
                    }
                    break;

                case Keys.Up:
                    if (gridSetParts.ActiveRow != null && gridSetParts.ActiveRow.ParentRow != null // �q�o���h��
                        && gridSetParts.ActiveRow.Index == 0)
                    {
                        gridSetParts.Rows[0].Activate();
                        gridSetParts.ActiveRow.Selected = true;
                        e.Handled = true;
                    }
                    break;

                case Keys.Enter:
                    SetSelect(true);
                    break;

                case Keys.PageDown:
                    if (gridSetParts.ActiveRow != null && gridSetParts.ActiveRow.Band.ParentBand == null)
                    {
                        gridSetParts.ActiveRow.ChildBands[0].Rows[0].Activate();
                        gridSetParts.ActiveRow.Selected = true;
                        GridSetParts_KeyDown(sender, e);
                    }
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
                // �����\���ʒu
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
                // �����\���ʒu
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

        private void gridStock_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/30 DEL
            //if (gridStock.ActiveRow != null && gridSetParts.ActiveRow != null)// && gridSetParts.ActiveRow.Band.ParentBand != null)
            //{
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.ShelfColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.StockCntColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
            //    gridStock.ActiveRow.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/30 DEL
        }

        private void gridStock_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/30 DEL
            //if (gridStock.Selected.Rows.Count > 0)
            //    gridStock.Selected.Rows[0].Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/30 DEL
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
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
                if ( gridSetParts.ActiveRow != null )
                {
                    if ( (bool)activeCells[_StockTable.SelectionStateColumn.ColumnName].Value == true )
                    {
                        // ���i�O���b�h�ɍ݌ɏ��\��
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.ShelfColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.StockCntColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
                    }
                    else
                    {
                        // ���i�O���b�h�̍݌ɏ����N���A
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseColumn.ColumnName].Value = string.Empty;
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.ShelfColumn.ColumnName].Value = string.Empty;
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.StockCntColumn.ColumnName].Value = 0;
                        gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Value = string.Empty;
                    }
                    gridSetParts.UpdateData();
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD   
        #endregion

        /// <summary>
        /// Enter�L�[(�_�u���N���b�N)�ɂ��I������
        /// </summary>
        /// <param name="moveFlg">true:���̍s��I����ԂɁ^false:�Ȃɂ����Ȃ��i�}�E�X�_�u���N���b�N���j</param>
        private void SetSelect(bool moveFlg)
        {
            UltraGridRow activeRow = gridSetParts.ActiveRow;
            if (gridSetParts.Selected.Rows.Count > 0 && activeRow != gridSetParts.Selected.Rows[0])
            {
                gridSetParts.Selected.Rows[0].Activate();
                activeRow = gridSetParts.ActiveRow;
            }
            if (activeRow != null)
            {
                UltraGridCell cell = activeRow.Cells[_dsSet.GoodsSet.SelImageColumn.ColumnName];

                if (cell.Value != DBNull.Value)
                {
                    if (uiControlFlg == false || enterFlg != 2) // �iPM.NS�������Enter�L�[���u����ʁv�j�ȊO��
                    {
                        cell.Value = DBNull.Value;
                        activeRow.Cells["SelectionState"].Value = false;
                    }
                }
                else
                {
                    if (activeRow.ParentRow == null) // �Z�b�g�e�i��
                    {
                        isSelectChangeDisabled = true;
                        foreach (UltraGridRow row in gridSetParts.Rows[0].ChildBands[0].Rows)
                        {
                            row.Cells[_dsSet.GoodsSet.SelImageColumn.ColumnName].Value = DBNull.Value; // �e�i�̑I����Ԃ�����
                            row.Cells["SelectionState"].Value = false;
                        }
                        isSelectChangeDisabled = false;
                    }
                    else // �Z�b�g�q�i��
                    {
                        isSelectChangeDisabled = true;
                        gridSetParts.Rows[0].Cells[_dsSet.SetMain.SelImageColumn.ColumnName].Value = DBNull.Value; // �e�i�̑I����Ԃ�����
                        gridSetParts.Rows[0].Cells["SelectionState"].Value = false;
                        isSelectChangeDisabled = false;
                    }
                    cell.Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    activeRow.Cells["SelectionState"].Value = true;
                }

                switch (enterFlg)
                {
                    case 2: // Enter�L�[���u����ʁv�̏ꍇ
                        if (gridSetParts.Rows[0].Equals(activeRow) == false
                        && gridSetParts.Rows[0].Cells[_dsSet.SetMain.SelImageColumn.ColumnName].Value != DBNull.Value)
                        {
                            gridSetParts.Rows[0].Cells[_dsSet.SetMain.SelImageColumn.ColumnName].Value = DBNull.Value;
                            gridSetParts.Rows[0].Cells[_dsSet.SetMain.SelectionStateColumn.ColumnName].Value = false;
                            _selInf.ListPlrlSubst.Clear();
                        }
                        foreach (UltraGridRow row in gridSetParts.Rows[0].ChildBands[0].Rows) // �I���s�ȊO�͑I����������
                        {
                            if (row.Equals(activeRow) == false && row.Cells[_dsSet.GoodsSet.SelImageColumn.ColumnName].Value != DBNull.Value)
                            {
                                row.Cells[_dsSet.GoodsSet.SelImageColumn.ColumnName].Value = DBNull.Value;
                                row.Cells[_dsSet.GoodsSet.SelectionStateColumn.ColumnName].Value = false;
                                if (_lstSelInf.ContainsKey(row.ListIndex))
                                {
                                    _lstSelInf.Remove(row.ListIndex);
                                }
                            }
                        }
                        if (uiControlFlg)
                        {
                            DialogResult = DialogResult.Ignore; // �c��̉�ʂ𖳎����I���m�肷��B
                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                        }
                        break;
                    default: // Enter�L�[���u�I���v�uPM7�v�̏ꍇ�F�����I�𓮍�̂��ߎ��s��I����ԂƂ���B                        
                        if (moveFlg)
                        {
                            if (activeRow.Band.ParentBand == null) // �e�o���h��
                            {
                                activeRow.ChildBands[0].Rows[0].Activate();
                                activeRow.ChildBands[0].Rows[0].Selected = true;
                            }
                            else
                            {
                                UltraGridRow ugr = activeRow.GetSibling(SiblingRow.Next);
                                if (ugr != null)
                                {
                                    ugr.Activate();
                                    ugr.Selected = true;
                                }
                            }
                        }
                        break;
                }
                gridSetParts.UpdateData();

            }
        }

        /// <summary>
        /// �݌ɃO���b�h�I�������i���[�U�[�I�����D��q�Ɂ��擪�s�̏��őI���j
        /// </summary>
        private void SetStockGridSelect()
        {
            if (gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Value.Equals(string.Empty) == false)
            {
                for (int i = 0; i < gridStock.Rows.Count; i++)
                {
                    if (gridStock.Rows[i].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value
                        .Equals(gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Value))
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
                // �Y�����Ȃ���ΐ擪�s�փt�H�[�J�X�Z�b�g
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
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD

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
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseColumn.ColumnName].Value = string.Empty;
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.ShelfColumn.ColumnName].Value = string.Empty;
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.StockCntColumn.ColumnName].Value = 0;
            //    gridSetParts.ActiveRow.Cells[_dsSet.GoodsSet.WarehouseCodeColumn.ColumnName].Value = string.Empty;
            //    gridSetParts.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/30 DEL
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

        #region [ Utility Class ]
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

        // --- ADD m.suzuki 2010/10/26 ---------->>>>>
        /// <summary>
        /// �݌ɃO���b�h�i����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_Enter( object sender, EventArgs e )
        {
            if ( gridStock.Rows.Count == 0 )
            {
                // �����I�ɕ��i�O���b�h�Ɉړ�����
                gridSetParts.Focus();
            }
        }
        // --- ADD m.suzuki 2010/10/26 ----------<<<<<

        // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- >>>
        /// <summary>
        /// �ԗ�����\���ؑ֏���
        /// </summary>
        private void SetPnlCarInfoVisible(bool carInfoVisible)
        {
            if (carInfoVisible)
            {
                this.gridSetParts.Location = new System.Drawing.Point(0, this.pnl_CarInfo.Height);
                // --- ADD 2014/11/04 T.Miyamoto �d�|�ꗗ ��2577 ------------------------------>>>>>
                this.gridSetParts.Height = this.SelectionForm_Fill_Panel.Height - this.pnl_CarInfo.Height;
                // --- ADD 2014/11/04 T.Miyamoto �d�|�ꗗ ��2577 ------------------------------<<<<<
            }
            else
            {
                this.gridSetParts.Location = new System.Drawing.Point(0, 0);
                // --- UPD 2014/11/04 T.Miyamoto �d�|�ꗗ ��2577 ------------------------------>>>>>
                //this.gridSetParts.Height = this.gridSetParts.Height + this.pnl_CarInfo.Height;
                this.gridSetParts.Height = this.SelectionForm_Fill_Panel.Height;
                // --- UPD 2014/11/04 T.Miyamoto �d�|�ꗗ ��2577 ------------------------------<<<<<
            }
        }
        // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- <<<

        // ADD 杍^ 2014/09/01 FOR Redmine#43289�@--- >>>
        /// <summary>
        /// XML�t�@�C����ۑ�����
        /// </summary>
        /// <param name="carInfoFlg">�ԗ����{�^���\���t���O</param>
        /// <param name="fileName">�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : XML�t�@�C����ۑ��������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        private void Serialize(bool carInfoFlg, string fileName)
        {
            UserSettingController.SerializeUserSetting(carInfoFlg, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
        }


        /// <summary>
        /// XML�t�@�C����ǂݏ���
        /// </summary>
        /// <param name="fileName">�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : XML�t�@�C����ǂݏ������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        private bool Deserialize(string fileName)
        {
            bool carInfoFlg = false;

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)))
            {
                try
                {
                    carInfoFlg = UserSettingController.DeserializeUserSetting<bool>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
                }
            }

            return carInfoFlg;
        }

        /// <summary>
        /// �a��N�擾�����iH20��"20"�݂̂��擾����j
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int GetDateFW(int date)
        {
            // �a������擾
            string date_gg = TDateTime.LongDateToString("gg", date);  // H
            string date_exggyy = TDateTime.LongDateToString("exggyy", date);  // H20

            // "H20" ���� "H" ����菜���� "20" ���擾����
            return ToInt(date_exggyy.Substring(date_gg.Length, date_exggyy.Length - date_gg.Length));

        }

        /// <summary>
        /// ���l�ϊ�����
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static int ToInt(string text)
        {
            try
            {
                return Int32.Parse(text);
            }
            catch
            {
                return 0;
            }
        }
        // ADD 杍^ 2014/09/01 FOR Redmine#43289�@--- <<<
    }
}