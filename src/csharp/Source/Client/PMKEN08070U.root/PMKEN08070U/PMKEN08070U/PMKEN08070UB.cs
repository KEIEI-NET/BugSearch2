using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
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
    /// <br>Update Note	: MANTIS�Ή�[0011539],[0012230]
    ///                   �@�����\���������A���[�J�[�A�i�ԏ��ɕύX
    ///                   �A�i���\���u�񋟗D��v���Ƀ��[�U�[�o�^�i�̕i�����\������Ȃ��s��̏C��</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009.02.19</br>
    /// <br></br>
    /// <br>Update Note	: �݌ɕ\�����ŗD��q�ɂ���ɕ\�������悤�ύX</br>
    /// <br>             : �݌ɂ̑I����@���`�F�b�N�����ɕύX�i���`�F�b�N�Ŏ���I���\�ɕύX�j</br>
    /// <br>Programmer	: 22018�@��� ���b</br>
    /// <br>Date		: 2009.03.27</br>
    /// <br></br>
    /// <br>Update Note	: �i���\���敪���񋟗D�掞�̕\�����ʕύX</br>
    /// <br>Programmer	: 20056 ���n ���</br>
    /// <br>Date		: 2009.08.03</br>
    /// <br></br>
    /// <br>Update Note	: �i�Ԍ����œ���i�ԃE�B���h�E�ŕ��i�I����A�����錻�ۂ̏C��(MANTIS[0014749])</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009/12/03</br>
    /// <br></br>
    /// <br>Update Note	: �@�Z�b�g�E�����i�̏ꍇ�ɁA�D��q�ɏ�񂪃Z�b�g����Ȃ����ۂ̏C��(MANTIS[0014650])</br>
    /// <br>            : �A��֌�A���ꕔ�i���������݂���ꍇ�ɗ����錻�ۂ̏C��(MANTIS[0014772])</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009/12/14</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/08�@�����@��Q���ǑΉ��i�V�������[�X���j�̑Ή�</br>
    /// <br>             �\���\�ő匏���𒴂����ꍇ�̓��b�Z�[�W��\������l�ɕύX</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ��i�W�����j</br>
    /// <br>             :   �E�݌ɂ̖��׌������[���Ȃ�΍݌ɃO���b�h�Ɉړ����Ȃ��悤�ύX�B</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2010/10/26</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ��i���������j</br>
    /// <br>             :   �@��ւ���ꍇ����֌��̏���\������悤�ɕύX�B</br>
    /// <br>             :   �A��ւ���/���Ȃ��̔�����o�l�V�����̎d�l�ɕύX�B</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2011/01/31</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ��i���������j</br>
    /// <br>             :   �E2011/01/31���̏C���B�݌ɗL������͗D��q�ɂ̂ݑΏۂƂ���B(PM7����)</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2011/02/09</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ�(��������)</br>
    /// <br>             :   �E2011/02/09���̏C���B�D��q�ɖ��ݒ�̏ꍇ�̏������C��(�ُ�I�������Ȃ�)</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2011/02/18</br>
    /// <br></br>
    /// <br>Update Note: 2011/07/25�@杍^�@�A��No.702�̑Ή�</br>
    /// <br>             ��ւ���i�݌ɖ��j�̏ꍇ�A�݌ɐ����P�ł̏����ɂ��ė~�����B�i�ԓ��͂̏ꍇ���A�݌ɏ������Q�Ƃ��ė~����</br>
    /// <br>Update Note  : 2011/11/29�@yangmj�@redmine#7759 �̑Ή�</br>
    /// <br>               �����I�����\������Ȃ��̏C��</br>
    /// <br>Update Note�@: 2011/12/26�@�c����</br>
    /// <br>             �@Redmine#27481 ����`�[����/�D��q�ɂ̎擾�̑Ή�</br>
    /// <br>Update Note�@: 2014/03/03�@�e�c ���V</br>
    /// <br>             �@�d�|�ꗗ ��2311 �i�ԍ��ڕ\�����ύX�Ή�</br>
    /// <br>Update Note�@: 2014/03/04�@�e�c ���V</br>
    /// <br>             �@�d�|�ꗗ ��2311 �V�X�e���e�X�g��Q�Ή�</br>
    /// </remarks>
    public partial class SelectionSamePartsNoParts : Form
    {
        # region DataTable�X�L�[�}��� (DataGrid�\���p)
        private PartsInfoDataSet _orgDataSet = null;
        private SameParts dataSet = null;
        private SameParts.SamePartsDataTable _PartsTable = null;
        private SameParts.StockDataTable _StockTable = null;
        //internal SameParts.SamePartsDataTable SamePartsTable
        //{
        //    get
        //    {
        //        return _PartsTable;
        //    }
        //}
        #endregion

        #region [ Private Member ]
        /// <summary>0:�i�Ԍ��� 1:�i�Ԍ������� 2:�i�Ԍ���[�G���g���p] 3:�݌ɑg�� </summary>
        private int _mode = 0;
        private bool isUserClose = true;
        private bool uiControlFlg; // false:PM7�X�^�C���@�@true:PM.NS�X�^�C��
        //private bool substFlg;     // false:��ւȂ�       true:��ւ���
        private int userSubstFlg;
        private int enterFlg;           // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
        private int totalAmountDispWay;       // ���z�\�����@�敪 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j

        private List<int> _makerList = null;
        private SelectionInfo _prevSelInfo;
        private bool isDialogShown = true;
        /// <summary> �_�C�A���O���\���ۃt���O�i�f�[�^���ɂ�莩������j </summary>
        public bool IsDialogShown
        {
            get { return isDialogShown; }
        }
        # endregion

        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        /// <param name="dsSource">�O���b�h�ɕ\������f�[�^���w�肵�܂��B</param>
        /// <param name="Mode">0:�i�Ԍ���[�}�X�����p] 1:�i�Ԍ������� 2:�i�Ԍ���[�G���g���p] 3:�݌ɑg��</param>
        /// <param name="makerList"></param>
        public SelectionSamePartsNoParts(PartsInfoDataSet dsSource, int Mode, List<int> makerList)
        {
            InitializeComponent(); // ADD 2010/06/08

            _mode = Mode;
            _makerList = makerList;
            _orgDataSet = dsSource;
            Thread initialProcThread = new Thread(InitializeData);
            initialProcThread.Start();

            if (dsSource.SearchCondition != null)
            {
                uiControlFlg = Convert.ToBoolean(dsSource.SearchCondition.SearchCntSetWork.SearchUICntDivCd); // 0:PM7�X�^�C���^1:PM.NS�X�^�C��
                //substFlg = (dsSource.SearchCondition.SearchCntSetWork.SubstCondDivCd != 0);
                //substFlg = false; // �i�Ԍ������񋟑�֏����擾���Ȃ����Ƃɂ���B�@20081011 Ahn
                userSubstFlg = dsSource.SearchCondition.SearchCntSetWork.SubstApplyDivCd;
                enterFlg = dsSource.SearchCondition.SearchCntSetWork.EnterProcDivCd; // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
                totalAmountDispWay = dsSource.SearchCondition.SearchCntSetWork.TotalAmountDispWayCd; // 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j
            }
            else // �}�X�����Ȃǒ��œ���i�ԑI��UI��\������ꍇ
            {
                uiControlFlg = true;
                //substFlg = false;
                userSubstFlg = 0;
            }

            //InitializeComponent(); // DEL 2010/06/08
            if (_mode == 1)
            {
                Width = 1010;
            }
            else
            {
                Width = 950;
            }
            // �c�[���o�[�̃C���[�W(16x16)�⃁�b�Z�[�W��ݒ肷��
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            ToolbarsManager.Tools["Button_Subst"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARADD;
            ToolbarsManager.Tools["Button_SubstOff"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            if (uiControlFlg && _mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo)
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODEL;
                ToolbarsManager.Tools["Button_Join"].SharedProps.Visible = false;
            }
            else if (_mode != 1 || uiControlFlg == false)
            {
                //if (_mode == 0)
                //{
                //    ToolbarsManager.Tools["Button_Subst"].SharedProps.Visible = false;
                //}
                ToolbarsManager.Tools["Button_Set"].SharedProps.Visible = false;
                ToolbarsManager.Tools["Button_Join"].SharedProps.Visible = false;
            }
            else
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODEL;
                ToolbarsManager.Tools["Button_Join"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARCHANGE;
            }
            ToolbarsManager.Tools["Button_Subst"].SharedProps.Visible = false; // �i�Ԍ����̒񋟑�ւȂ��Ƃ��� 20081011 Ahn
            ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
            StatusBar.Text = "";

            while (initialProcThread.ThreadState == ThreadState.Running)
            {
                Thread.Sleep(10);
            }
            //InitializeData();
            InitializeTable();

        }

        private void InitializeTable()
        {
            gridParts.BeginUpdate();
            // 2009.03.06 >>>
            //gridParts.DataSource = _PartsTable;
            gridParts.DataSource = _PartsTable.DefaultView;
            // 2009.03.06 <<<
            gridParts.EndUpdate();
            gridStock.DataSource = _StockTable.DefaultView;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            SettingStockView( _StockTable.DefaultView );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
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

        /// <summary>
        /// �_�C�A���O��\�����܂��B�i�����A�Z�b�g�I��UI�ɂČ����i��I�������ꍇ�͕\�������A�I�����܂��j
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="previousRet"></param>
        /// <returns></returns>
        // 2009.02.19 >>>
        //public DialogResult ShowDialog(DialogResult previousRet)
        public DialogResult ShowDialog(IWin32Window owner, DialogResult previousRet)
        // 2009.02.19 <<<
        {
            if (previousRet != DialogResult.Cancel)
            {
                //string filter = string.Format("{0} = 0 AND {1} = True",
                //    _orgDataSet.UsrGoodsInfo.GoodsKindColumn.ColumnName,
                //    _orgDataSet.UsrGoodsInfo.SelectionStateColumn.ColumnName);
                //string filter = string.Format("{0} = True",
                //    _orgDataSet.UsrGoodsInfo.SelectionStateColumn.ColumnName);
                //if (_orgDataSet.UsrGoodsInfo.Select(filter).Length > 0)
                //    return DialogResult.OK;
                if (_prevSelInfo != null && _orgDataSet.ListSelectionInfo.ContainsKey(_prevSelInfo.Key)
                    && _orgDataSet.ListSelectionInfo[_prevSelInfo.Key].IsThereSelection)
                    return DialogResult.OK;
            }
            if (CheckCount())
            {
                if (uiControlFlg)
                {
                    return DialogResult.Retry;
                }
                return DialogResult.OK;
            }

            if (previousRet == DialogResult.OK)
            {
                PartsInfoDataSet.UsrGoodsInfoRow orgRow = _orgDataSet.UsrGoodsInfo.RowToProcess;
                if (orgRow != null && orgRow.NewGoodsNo != string.Empty) //��ւ��ꂽ���i�����邩�`�F�b�N[NewGoodsNo:��֐�i��]
                {
                    SameParts.SamePartsRow oldRow = _PartsTable.FindByMakerCodePartsNo(orgRow.GoodsMakerCd, orgRow.GoodsNo);
                    PartsInfoDataSet.UsrGoodsInfoRow newRow =
                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(orgRow.GoodsMakerCd, orgRow.NewGoodsNo);

                    // ��ւ���O�̑I������������E�Z�b�g�q���i���N���A
                    _prevSelInfo.ListChildGoods.Clear();
                    _prevSelInfo.ListChildGoods2.Clear();
                    if (_prevSelInfo.ListPlrlSubst.Count > 0)
                        _prevSelInfo.ListPlrlSubst.RemoveAt(0); // 1�ڂ͑�֕i���Ȃ̂ō폜���Ă����B

                    oldRow.OldPartsNo = oldRow.PartsNo;
                    oldRow.PartsNo = newRow.GoodsNo;
                    oldRow.PartsName = newRow.GoodsName;
                    if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                    {
                        oldRow.Price = newRow.PriceTaxInc;
                    }
                    else // ���z�\�����Ȃ��i�Ŕ����j
                    {
                        oldRow.Price = newRow.PriceTaxExc;
                    }
                    SetImage(oldRow);
                    SetButtonState();
                    ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = true;

                    orgRow.SelectionState = false;
                    orgRow.NewGoodsNo = string.Empty;
                }
            }
            isUserClose = true;
            // 2009.02.19 >>>
            //return base.ShowDialog();
            return base.ShowDialog(owner);
            // 2009.02.19 <<<
        }

        /// <summary>
        /// ����i�ԑI��UI��\������
        /// </summary>
        /// <returns></returns>
        // 2009.02.19 >>>
        //public new DialogResult ShowDialog()
        public new DialogResult ShowDialog(IWin32Window owner)
        // 2009.02.19 <<<
        {
            if (CheckCount())
            {
                if (uiControlFlg && (_orgDataSet.JoinSrcSelInf != null || _orgDataSet.SetSrcSelInf != null))
                {
                    return DialogResult.Retry;
                }
                return DialogResult.OK;
            }
            // 2009.02.19 >>>
            //return base.ShowDialog();
            return base.ShowDialog(owner);
            // 2009.02.19 <<<
        }

        /// <summary>
        /// UOE�̃��[�J�[���X�g�ɂ��i�����̕\�����i���`�F�b�N����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 2011/12/26�@�c����</br>
        /// <br>              Redmine#27481 ����`�[����/�D��q�ɂ̎擾�̑Ή�</br>
        /// </remarks>
        private bool CheckCount()
        {
            if (_PartsTable.Count == 0) // ���[�J�[�����w��ɂ��i���̏ꍇ�A���̉�ʂ��J���Ă��\�����镔�i���Ȃ��ꍇ������B
                return true;

            bool flg = (_orgDataSet.UsrJoinParts.Count == 0 && _orgDataSet.UsrSetParts.Count == 0);// && _orgDataSet.UsrSubstParts.Count == 0);
            //string query = string.Format("{0}={1} AND {2}='{3}'",
            //    _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, _PartsTable[0].MakerCode,
            //    _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, _PartsTable[0].PartsNo);
            if (_PartsTable.Count == 1) // �i�Ԍ����̑Ώۂ�1�����Ȃ��ꍇ
            {
                //if (_mode == 0                                // �i�Ԍ����̏ꍇ�F���i1�Ȃ炻�̂܂ܑI��UI�I��
                //          || (_mode == 1 && flg) // �i�Ԍ��������F�������g��������ȂǂɂȂ�P�[�X�ڗ�
                //    //          || (_mode == 1 && _orgDataSet.UsrGoodsInfo.Count == 1 && flg) // �i�Ԍ��������F�������g��������ȂǂɂȂ�P�[�X�ڗ�
                //    //          || (uiControlFlg == false && _orgDataSet.UsrSubstParts.Select(query).Length == 0) // PM7���F��ւ��Ȃ��ꍇ���̂܂ܑI��UI�I��
                //    )
                //{
                // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                //PartsInfoDataSet.UsrGoodsInfoRow row =
                //    _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( _PartsTable[0].MakerCode, _PartsTable[0].PartsNoToShow );
                PartsInfoDataSet.UsrGoodsInfoRow row =
                    _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( _PartsTable[0].MakerCodeToShow, _PartsTable[0].PartsNoToShow );
                // --- UPD m.suzuki 2011/01/31 ----------<<<<<

                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                SelectionInfo selInfo = new SelectionInfo();
                selInfo.Depth = 0;
                selInfo.Key = gridParts.Rows[0].ListIndex;
                selInfo.RowGoods = row;
                _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                if (gridParts.Rows[0].Cells[_PartsTable.JoinColumn.ColumnName].Value.Equals(DBNull.Value)
                        && gridParts.Rows[0].Cells[_PartsTable.SetColumn.ColumnName].Value.Equals(DBNull.Value))
                { // �������Z�b�g���Ȃ��ꍇ
                    selInfo.Selected = true;

                    string filter = string.Format("{0}={1} AND {2}='{3}' ",
                        // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                        //_StockTable.GoodsMakerCdColumn.ColumnName, _PartsTable[0].MakerCode,
                        _StockTable.GoodsMakerCdColumn.ColumnName, _PartsTable[0].MakerCodeToShow,
                        // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                        _StockTable.GoodsNoColumn.ColumnName, _PartsTable[0].PartsNoToShow);
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
                                    return true;
                                }
                            }
                        }
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL // �D��q�ɂɂȂ��ꍇ�͎��ɂ���
                    //if (_StockTable.DefaultView.Count > 0)
                    //    selInfo.WarehouseCode = _StockTable.DefaultView[0][_StockTable.WarehouseCodeColumn.ColumnName].ToString();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
                }
                else
                {
                    bool flgStock = false; // ADD 2011/12/26 tianjw Redmine#27481
                    // 2009/12/14 Add >>>
                    if (_orgDataSet.ListPriorWarehouse != null) // �D��q�Ɏw�肠��
                    {
                        string orgFilter = _StockTable.DefaultView.RowFilter;
                        try
                        {
                            string filter = string.Format("{0}={1} AND {2}='{3}' ",
                                _StockTable.GoodsMakerCdColumn.ColumnName, _PartsTable[0].MakerCode,
                                // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                                //_StockTable.GoodsNoColumn.ColumnName, _PartsTable[0].PartsNoToShow);
                                _StockTable.GoodsNoColumn.ColumnName, _PartsTable[0].PartsNo);
                                // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                            _StockTable.DefaultView.RowFilter = filter;
                            //if (_StockTable.DefaultView.Count > 0) // DEL 2011/12/26 tianjw Redmine#27481
                            if (flgStock == false && _StockTable.DefaultView.Count > 0) // ADD 2011/12/26 tianjw Redmine#27481
                            {
                                for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
                                {
                                    string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
                                    for (int j = 0; j < _StockTable.DefaultView.Count; j++)
                                    {
                                        if (warehouseCd.Equals(_StockTable.DefaultView[j][_StockTable.WarehouseCodeColumn.ColumnName]))
                                        {
                                            selInfo.WarehouseCode = warehouseCd;
                                            // --- ADD 2011/12/26 tianjw Redmine#27481 --->>>>>
                                            flgStock = true;
                                            break;
                                            // --- ADD 2011/12/26 tianjw Redmine#27481 ---<<<<<
                                        }
                                    }
                                    // --- ADD 2011/12/26 tianjw Redmine#27481 --->>>>>
                                    if (flgStock)
                                    {
                                        break;
                                    }
                                    // --- ADD 2011/12/26 tianjw Redmine#27481 ---<<<<<
                                }
                            }
                        }
                        finally
                        {
                            _StockTable.DefaultView.RowFilter = orgFilter;
                        }
                    }
                    // 2009/12/14 Add <<<
                    if (uiControlFlg)
                    {
                        if (gridParts.Rows[0].Cells[_PartsTable.JoinColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                        {
                            _orgDataSet.JoinSrcSelInf = selInfo;
                            _orgDataSet.UIKind = SelectUIKind.Join;
                        }
                        else if (gridParts.Rows[0].Cells[_PartsTable.SetColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                        {
                            _orgDataSet.SetSrcSelInf = selInfo;
                            _orgDataSet.UIKind = SelectUIKind.Set;
                        }
                    }
                }
                isDialogShown = false;
                return true;
            }
            return false;
        }

        #region �C���^�[�i��
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

        private void InitializeData()
        {
            // 2009.02.10 Add >>>
            this.SettingPriceTargetData();
            // 2009.02.10 Add <<<
            #region �f�[�^�Z�b�g

            dataSet = new SameParts();
            _PartsTable = dataSet._SameParts;
            _StockTable = dataSet.Stock;

            try
            {
                SameParts.SamePartsRow wkRow = null;
                SameParts.StockRow stockRow = null;

                #region [ �t�B���^�����O�����Z�o ]
                string filter = string.Empty;
                string cond = string.Empty;
                string colName = string.Empty;
                string queryOp = string.Empty;
                string goodsNo = string.Empty;

                if (_orgDataSet.SearchCondition != null)
                {
                    switch (_orgDataSet.SearchCondition.SearchType)
                    {
                        case SearchType.WholeWord:
                            queryOp = " = ";
                            goodsNo = _orgDataSet.SearchCondition.PartsNo;
                            break;
                        case SearchType.WholeWordWithNoHyphen:
                            queryOp = " = ";
                            goodsNo = _orgDataSet.SearchCondition.PartsNo;
                            colName = _orgDataSet.UsrGoodsInfo.GoodsNoNoneHyphenColumn.ColumnName;
                            break;
                        case SearchType.FreeSearch:
                            queryOp = " LIKE ";
                            goodsNo = "%" + _orgDataSet.SearchCondition.PartsNo + "%";
                            break;
                        case SearchType.PrefixSearch:
                            queryOp = " LIKE ";
                            goodsNo = _orgDataSet.SearchCondition.PartsNo + "%";
                            break;
                        case SearchType.SuffixSearch:
                            queryOp = " LIKE ";
                            goodsNo = "%" + _orgDataSet.SearchCondition.PartsNo;
                            break;
                        default:
                            queryOp = " = ";
                            goodsNo = _orgDataSet.SearchCondition.PartsNo;
                            break;
                    }
                    if (colName == string.Empty)
                    {
                        if (goodsNo.Contains("-"))
                        {
                            colName = _orgDataSet.UsrGoodsInfo.GoodsNoColumn.ColumnName;
                        }
                        else
                        {
                            colName = _orgDataSet.UsrGoodsInfo.GoodsNoNoneHyphenColumn.ColumnName;
                        }
                    }
                    if (_orgDataSet.SearchCondition.PartsMakerCode != 0)
                    {
                        cond = string.Format("{0} {1} '{2}' AND {3} = {4}", colName, queryOp, goodsNo,
                                _orgDataSet.UsrGoodsInfo.GoodsMakerCdColumn.ColumnName, _orgDataSet.SearchCondition.PartsMakerCode);
                    }
                    else
                    {
                        cond = string.Format("{0} {1} '{2}'", colName, queryOp, goodsNo);
                    }
                    string cond2 = string.Empty;
                    if (_makerList != null)
                    {
                        for (int i = 0; i < _makerList.Count; i++)
                        {
                            cond2 += string.Format(" {0} = {1} OR ", _orgDataSet.UsrGoodsInfo.GoodsMakerCdColumn.ColumnName, _makerList[i]);
                        }
                        cond2 = cond2.Remove(cond2.Length - 3);
                    }

                    if (_orgDataSet.UsrGoodsInfo.DefaultView.RowFilter.Length == 0)
                    {
                        filter = cond;
                    }
                    else
                    {
                        filter = string.Format("( {0} ) AND {1} ",
                            _orgDataSet.UsrGoodsInfo.DefaultView.RowFilter, cond);
                    }
                    if (cond2 != string.Empty)
                    {
                        filter = string.Format("( {0} ) AND ( {1} )", filter, cond2);
                    }
                    if (_mode == 3) // �݌ɑg���p
                    {
                        filter = string.Format("( {0} ) AND ( {1} <= 2 )", filter, _orgDataSet.UsrGoodsInfo.OfferKubunColumn.ColumnName); // ���[�U�[�o�^���i��
                    }
                }
                #endregion
                _PartsTable.BeginLoadData();
                PartsInfoDataSet.UsrGoodsInfoRow[] usrRows =
                    (PartsInfoDataSet.UsrGoodsInfoRow[])_orgDataSet.UsrGoodsInfo.Select(filter, _orgDataSet.UsrGoodsInfo.OfferKubunColumn.ColumnName);
                //for (int i = 0; i < usrRows.Length; i++) // DEL 2010/06/08
                for (int i = 0; i < usrRows.Length && i < 200; i++) // ADD 2010/06/08
                {
                    #region [ ���i���ݒ� ]
                    PartsInfoDataSet.UsrGoodsInfoRow row;

                    // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                    //if (userSubstFlg > 0 && 
                    //    (_mode == 1 || 
                    //    (_mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo)))
                    //    row = _orgDataSet.GetUsrSubst(usrRows[i]);
                    //else
                    //    row = usrRows[i];
                    ////if (_mode == 0 || _mode == 3 || userSubstFlg == 0)
                    ////    row = usrRows[i];
                    ////else
                    ////    row = _orgDataSet.GetUsrSubst(usrRows[i]);
                    // --- UPD 2011/07/25 ---- >>>>>
                    //if ( userSubstFlg > 0 &&
                    //    (_mode == 1 ||
                    //    (_mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo)) )
                    // --- UPD 2011/11/29 ---- >>>>>
                    //if ((_mode == 1 ||
                    //(_mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo)))
                     if ( userSubstFlg > 0 &&
                        (_mode == 1 ||
                        (_mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo)) )
                    // --- UPD 2011/11/29 ---- <<<<<
                    // --- UPD 2011/07/25 ---- <<<<<
                    {
                        if ( CatalogPartsStockCheck( usrRows[i].GoodsNo, usrRows[i].GoodsMakerCd ) )
                        {
                            // ��֌��i�Ԃ̍݌ɂ����݂���ꍇ�́A��֌�
                            row = usrRows[i];
                        }
                        else
                        {
                            // ��֐�
                            row = _orgDataSet.GetUsrSubst( usrRows[i] );
                        }
                    }
                    else
                    {
                        // ��֌�
                        row = usrRows[i];
                    }
                    // --- UPD m.suzuki 2011/01/31 ----------<<<<<

                    // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                    //// 2009/12/14 Add >>>
                    //if (_PartsTable.FindByMakerCodePartsNo(row.GoodsMakerCd, usrRows[i].GoodsNo) != null) continue;
                    //// 2009/12/14 Add <<<
                    if ( _PartsTable.FindByMakerCodePartsNo( usrRows[i].GoodsMakerCd, usrRows[i].GoodsNo ) != null ) continue;
                    // --- UPD m.suzuki 2011/01/31 ----------<<<<<

                    // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                    //PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])row.GetChildRows( "UsrGoodsInfo_Stock" );
                    // (��֐��)�݌�
                    List<PartsInfoDataSet.StockRow> stockRowList = new List<PartsInfoDataSet.StockRow>( (PartsInfoDataSet.StockRow[])row.GetChildRows( "UsrGoodsInfo_Stock" ) );
                    if ( usrRows[i].GoodsNo != row.GoodsNo || usrRows[i].GoodsMakerCd != row.GoodsMakerCd )
                    {
                        // ��֌��̍݌�
                        stockRowList.AddRange( (PartsInfoDataSet.StockRow[])usrRows[i].GetChildRows( "UsrGoodsInfo_Stock" ) );
                    }
                    PartsInfoDataSet.StockRow[] stockRows = stockRowList.ToArray();
                    // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                    if (_mode == 3)�@// �݌ɑg���̏ꍇ
                    {
                        if (_orgDataSet.UsrSetParts.SetExist(row.GoodsMakerCd, row.GoodsNo) == false) // �Z�b�g��񂪂Ȃ��ꍇ�o�^���Ȃ��B
                            continue;
                        if (stockRows.Length == 0) // �݌ɂ��Ȃ��ꍇ�o�^���Ȃ��B
                            continue;
                    }

                    wkRow = _PartsTable.NewSamePartsRow();
                    // �f�[�^�Z�b�g
                    // --- DEL m.suzuki 2011/01/31 ---------->>>>>
                    # region // DEL
                    //wkRow.MakerCode = row.GoodsMakerCd;
                    //wkRow.MakerName = row.GoodsMakerNm;
                    //wkRow.PartsNo = usrRows[i].GoodsNo; // ���[�U�[��ւ����Ƃ��A���̕i�Ԃ����j�[�N
                    //wkRow.PartsNoToShow = row.GoodsNo;  // ���̕i�Ԃ��\�������B���[�U�[��ւ����Ƃ��̓��j�[�N�łȂ�����
                    //if (_orgDataSet.PartsNameDspDivCd == 0) // �i���\���敪�����i�D��̏ꍇ
                    //{
                    //    if (row.GoodsName != string.Empty)
                    //    {
                    //        wkRow.PartsName = row.GoodsName;
                    //    }
                    //    else
                    //    {
                    //        wkRow.PartsName = row.GoodsOfrName;
                    //    }
                    //}
                    //else  // �i���\���敪���񋟗D��̏ꍇ
                    //{
                    //    // 2009.08.03 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //    //// 2009.03.06 >>>
                    //    ////if (row.GoodsName != string.Empty)
                    //    //if (row.GoodsOfrName != string.Empty)
                    //    //// 2009.03.06 <<<
                    //    //{
                    //    //    wkRow.PartsName = row.GoodsOfrName;
                    //    //}
                    //    //else
                    //    //{
                    //    //    wkRow.PartsName = row.GoodsName;
                    //    //}
                    //    if (row.GoodsName != string.Empty)
                    //    {
                    //        wkRow.PartsName = row.GoodsName;
                    //    }
                    //    else
                    //    {
                    //        wkRow.PartsName = row.GoodsOfrName;
                    //    }
                    //    // 2009.08.03 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    //}
                    //if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                    //{
                    //    wkRow.Price = row.PriceTaxInc;
                    //}
                    //else // ���z�\�����Ȃ��i�Ŕ����j
                    //{
                    //    wkRow.Price = row.PriceTaxExc;
                    //}
                    //
                    //SetImage(wkRow);
                    //if (row.OfferKubun == 0)
                    //    wkRow.Attr = "����";
                    //else
                    //    wkRow.Attr = "�D��";
                    # endregion
                    // --- DEL m.suzuki 2011/01/31 ----------<<<<<
                    // --- ADD m.suzuki 2011/01/31 ---------->>>>>
                    // ��֌��FPartsNo, MakerCode
                    // ��֐�FPartsNoToShow, MakerCodeToShow
                    wkRow.PartsNoToShow = row.GoodsNo;  // ��֌�̕i��
                    wkRow.MakerCodeToShow = row.GoodsMakerCd; // ��֌�̃��[�J�[�R�[�h

                    wkRow.MakerCode = usrRows[i].GoodsMakerCd; // ��֑O�̃��[�J�[�R�[�h

                    // ���ȉ��A��֌��̏��ɕύX
                    wkRow.MakerName = usrRows[i].GoodsMakerNm;
                    wkRow.PartsNo = usrRows[i].GoodsNo; // ���[�U�[��ւ����Ƃ��A���̕i�Ԃ����j�[�N
                    if ( _orgDataSet.PartsNameDspDivCd == 0 ) // �i���\���敪�����i�D��̏ꍇ
                    {
                        if ( usrRows[i].GoodsName != string.Empty )
                        {
                            wkRow.PartsName = usrRows[i].GoodsName;
                        }
                        else
                        {
                            wkRow.PartsName = usrRows[i].GoodsOfrName;
                        }
                    }
                    else  // �i���\���敪���񋟗D��̏ꍇ
                    {
                        if ( usrRows[i].GoodsName != string.Empty )
                        {
                            wkRow.PartsName = usrRows[i].GoodsName;
                        }
                        else
                        {
                            wkRow.PartsName = usrRows[i].GoodsOfrName;
                        }
                    }
                    if ( totalAmountDispWay == 1 ) // ���z�\������i�ō��݁j
                    {
                        wkRow.Price = usrRows[i].PriceTaxInc;
                    }
                    else // ���z�\�����Ȃ��i�Ŕ����j
                    {
                        wkRow.Price = usrRows[i].PriceTaxExc;
                    }

                    SetImage( wkRow );
                    if ( usrRows[i].OfferKubun == 0 )
                        wkRow.Attr = "����";
                    else
                        wkRow.Attr = "�D��";
                    // --- ADD m.suzuki 2011/01/31 ----------<<<<<

                    _PartsTable.AddSamePartsRow(wkRow);
                    #endregion

                    bool flgStock = false;

                    for (int j = 0; j < stockRows.Length; j++)
                    {
                        if (_StockTable.FindByWarehouseCodeGoodsMakerCdGoodsNo(stockRows[j].WarehouseCode,
                            stockRows[j].GoodsMakerCd, stockRows[j].GoodsNo) == null)
                        {
                            stockRow = _StockTable.NewStockRow();
                            stockRow.GoodsMakerCd = stockRows[j].GoodsMakerCd;
                            stockRow.GoodsNo = stockRows[j].GoodsNo;
                            stockRow.MaximumStockCnt = stockRows[j].MaximumStockCnt;
                            stockRow.MinimumStockCnt = stockRows[j].MinimumStockCnt;
                            stockRow.ShipmentPosCnt = stockRows[j].ShipmentPosCnt;
                            stockRow.WarehouseCode = stockRows[j].WarehouseCode;
                            stockRow.WarehouseName = stockRows[j].WarehouseName;
                            stockRow.WarehouseShelfNo = stockRows[j].WarehouseShelfNo;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
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
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
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
                                // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                                //if (stockRows[k].WarehouseCode.Equals(warehouseCd))
                                if ( stockRows[k].WarehouseCode.Equals( warehouseCd ) &&
                                     wkRow.PartsNo == stockRows[k].GoodsNo &&
                                     wkRow.MakerCode == stockRows[k].GoodsMakerCd )
                                // --- UPD m.suzuki 2011/01/31 ----------<<<<<
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
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2009/03/27 DEL // �D��q�ɂɂȂ��ꍇ�͎��ɂ���
                    //if (flgStock == false && stockRows.Length > 0)
                    //{
                    //    wkRow.Shelf = stockRows[0].WarehouseShelfNo;
                    //    wkRow.StockCnt = stockRows[0].ShipmentPosCnt;
                    //    wkRow.Warehouse = stockRows[0].WarehouseName;
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                    //    wkRow.WarehouseCode = stockRows[0].WarehouseCode;
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2009/03/27 DEL
                }
                // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                //// 2009.03.06 Add >>>
                //this._PartsTable.DefaultView.Sort = string.Format("{0},{1}", this._PartsTable.MakerCodeColumn.ColumnName, this._PartsTable.PartsNoToShowColumn.ColumnName);
                //// 2009.03.06 Add <<<
                this._PartsTable.DefaultView.Sort = string.Format("{0},{1}", this._PartsTable.MakerCodeColumn.ColumnName, this._PartsTable.PartsNoColumn.ColumnName);
                // --- UPD m.suzuki 2011/01/31 ----------<<<<<

                // --- ADD 2010/06/08 ---------->>>>>
                if (usrRows.Length > 200)
                {
                    StatusBar.Text = "�������ׂ��Q�O�O���𒴂��Ă��܂�";
                }
                else
                {
                    StatusBar.Text = "";
                }
                // --- ADD 2010/06/08 ----------<<<<<
            }
            finally
            {
                _PartsTable.EndLoadData();
            }
            #endregion
        }

        // --- ADD m.suzuki 2011/01/31 ---------->>>>>
        /// <summary>
        /// �J�^���O�i�ԍ݌Ƀ`�F�b�N����
        /// </summary>
        /// <param name="parts"></param>
        /// <param name="maker"></param>
        /// <returns></returns>
        internal bool CatalogPartsStockCheck( string parts, int maker )
        {
            bool ret = false;
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

            // �݌Ƀ}�X�^�̐��ʂ��`�F�b�N����
            // �i�����R�[�h����E���݌ɐ��[���͍݌ɖ����Ɣ��f����B�j
            for ( int i = 0; i < rowStock.Length; i++ )
            {
                if ( rowStock[i].ShipmentPosCnt > 0 )
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        // --- ADD m.suzuki 2011/01/31 ----------<<<<<

        // 2009.02.10 Add >>>
        /// <summary>
        /// �Ώۃf�[�^�̒艿�ݒ�
        /// </summary>
        private void SettingPriceTargetData()
        {
            if (_orgDataSet.CalculatePrice == null) return;

            List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList = new List<PartsInfoDataSet.GoodsPrimaryKey>();

            #region [ �t�B���^�����O�����Z�o ]
            string filter = string.Empty;
            string cond = string.Empty;
            string colName = string.Empty;
            string queryOp = string.Empty;
            string goodsNo = string.Empty;

            if (_orgDataSet.SearchCondition != null)
            {
                switch (_orgDataSet.SearchCondition.SearchType)
                {
                    case SearchType.WholeWord:
                        queryOp = " = ";
                        goodsNo = _orgDataSet.SearchCondition.PartsNo;
                        break;
                    case SearchType.WholeWordWithNoHyphen:
                        queryOp = " = ";
                        goodsNo = _orgDataSet.SearchCondition.PartsNo;
                        colName = _orgDataSet.UsrGoodsInfo.GoodsNoNoneHyphenColumn.ColumnName;
                        break;
                    case SearchType.FreeSearch:
                        queryOp = " LIKE ";
                        goodsNo = "%" + _orgDataSet.SearchCondition.PartsNo + "%";
                        break;
                    case SearchType.PrefixSearch:
                        queryOp = " LIKE ";
                        goodsNo = _orgDataSet.SearchCondition.PartsNo + "%";
                        break;
                    case SearchType.SuffixSearch:
                        queryOp = " LIKE ";
                        goodsNo = "%" + _orgDataSet.SearchCondition.PartsNo;
                        break;
                    default:
                        queryOp = " = ";
                        goodsNo = _orgDataSet.SearchCondition.PartsNo;
                        break;
                }
                if (colName == string.Empty)
                {
                    if (goodsNo.Contains("-"))
                    {
                        colName = _orgDataSet.UsrGoodsInfo.GoodsNoColumn.ColumnName;
                    }
                    else
                    {
                        colName = _orgDataSet.UsrGoodsInfo.GoodsNoNoneHyphenColumn.ColumnName;
                    }
                }
                if (_orgDataSet.SearchCondition.PartsMakerCode != 0)
                {
                    cond = string.Format("{0} {1} '{2}' AND {3} = {4}", colName, queryOp, goodsNo,
                            _orgDataSet.UsrGoodsInfo.GoodsMakerCdColumn.ColumnName, _orgDataSet.SearchCondition.PartsMakerCode);
                }
                else
                {
                    cond = string.Format("{0} {1} '{2}'", colName, queryOp, goodsNo);
                }
                string cond2 = string.Empty;
                if (_makerList != null)
                {
                    for (int i = 0; i < _makerList.Count; i++)
                    {
                        cond2 += string.Format(" {0} = {1} OR ", _orgDataSet.UsrGoodsInfo.GoodsMakerCdColumn.ColumnName, _makerList[i]);
                    }
                    cond2 = cond2.Remove(cond2.Length - 3);
                }

                if (_orgDataSet.UsrGoodsInfo.DefaultView.RowFilter.Length == 0)
                {
                    filter = cond;
                }
                else
                {
                    filter = string.Format("( {0} ) AND {1} ",
                        _orgDataSet.UsrGoodsInfo.DefaultView.RowFilter, cond);
                }
                if (cond2 != string.Empty)
                {
                    filter = string.Format("( {0} ) AND ( {1} )", filter, cond2);
                }
                if (_mode == 3) // �݌ɑg���p
                {
                    filter = string.Format("( {0} ) AND ( {1} <= 2 )", filter, _orgDataSet.UsrGoodsInfo.OfferKubunColumn.ColumnName); // ���[�U�[�o�^���i��
                }
            }
            #endregion

            PartsInfoDataSet.UsrGoodsInfoRow[] usrRows =
                (PartsInfoDataSet.UsrGoodsInfoRow[])_orgDataSet.UsrGoodsInfo.Select(filter, _orgDataSet.UsrGoodsInfo.OfferKubunColumn.ColumnName);
            for (int i = 0; i < usrRows.Length; i++)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row;

                // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                //if (userSubstFlg > 0 &&
                //    ( _mode == 1 ||
                //    ( _mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo ) ))
                //    row = _orgDataSet.GetUsrSubst(usrRows[i]);
                //else
                //    row = usrRows[i];

                // ��ւ���/���Ȃ��̔���ɂ�炸�A��ɑ�֌��̏���\������B
                row = usrRows[i];
                // --- UPD m.suzuki 2011/01/31 ----------<<<<<

                PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])row.GetChildRows("UsrGoodsInfo_Stock");
                if (_mode == 3)�@// �݌ɑg���̏ꍇ
                {
                    if (_orgDataSet.UsrSetParts.SetExist(row.GoodsMakerCd, row.GoodsNo) == false) // �Z�b�g��񂪂Ȃ��ꍇ�o�^���Ȃ��B
                        continue;
                    if (stockRows.Length == 0) // �݌ɂ��Ȃ��ꍇ�o�^���Ȃ��B
                        continue;
                }

                goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(row.GoodsNo, row.GoodsMakerCd));
            }
            // ���i��񂪑��݂���ꍇ�͒艿�v�Z
            if (goodsPrimaryKeyList.Count > 0)
            {
                _orgDataSet.SettingDefaultListPrice(goodsPrimaryKeyList);
            }
        }
        // 2009.02.10 Add <<<

        private void SetImage(SameParts.SamePartsRow wkRow)
        {
            if (!(_mode == 1 || (_mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo)))
                return;
            //if (SubstExists(wkRow.PartsNoToShow, wkRow.MakerCode))
            //{
            //    wkRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
            //}
            //else
            //{
            //    wkRow[_PartsTable.SubstColumn] = DBNull.Value;
            //}
            // --- UPD m.suzuki 2011/01/31 ---------->>>>>
            //if (SetExists(wkRow.PartsNoToShow, wkRow.MakerCode))
            if ( SetExists( wkRow.PartsNo, wkRow.MakerCode ) )
            // --- UPD m.suzuki 2011/01/31 ----------<<<<<
            {
                wkRow.Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
            }
            else
            {
                wkRow[_PartsTable.SetColumn] = DBNull.Value;
            }
            // --- UPD m.suzuki 2011/01/31 ---------->>>>>
            //if (JoinExists(wkRow.PartsNoToShow, wkRow.MakerCode))
            if ( JoinExists( wkRow.PartsNo, wkRow.MakerCode ) )
            // --- UPD m.suzuki 2011/01/31 ----------<<<<<
            {
                wkRow.Join = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARCHANGE];
            }
            else
            {
                wkRow[_PartsTable.JoinColumn] = DBNull.Value;
            }
        }

        #region [ ��ցE�Z�b�g�E�������ݐ��`�F�b�N ]
        internal bool SubstExists(string parts, int maker)
        {
            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4} = true", // ��֑I��UI�ɂ͒񋟂̂ݕ\��
                _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, parts,
                _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, maker, _orgDataSet.UsrSubstParts.OfferKubunColumn.ColumnName);
            if (_orgDataSet.UsrSubstParts.Select(rowFilter).Length > 0)
                return true;
            return false;
        }

        internal bool SetExists(string parts, int maker)
        {
            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}=true",
                _orgDataSet.UsrSetParts.ParentGoodsNoColumn.ColumnName, parts,
                _orgDataSet.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, maker,
                _orgDataSet.UsrSetParts.PrmSettingFlgColumn.ColumnName);

            if (_orgDataSet.UsrSetParts.Select(rowFilter).Length > 0)
                return true;
            return false;
        }

        internal bool JoinExists(string parts, int maker)
        {
            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}=true",
                _orgDataSet.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, parts,
                _orgDataSet.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, maker,
                _orgDataSet.UsrJoinParts.PrmSettingFlgColumn.ColumnName);
            if (_orgDataSet.UsrJoinParts.Select(rowFilter).Length > 0)
                return true;
            return false;
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
        private void SelectionSamePartsNoParts_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel || _PartsTable.Count == 0)
            {
                return;
            }
            //int cnt = _PartsTable.Count;
            //string filter = string.Format("{0} = True", _PartsTable.SelectionStateColumn.ColumnName);
            //_PartsTable.AcceptChanges();
            //SameParts.SamePartsRow[] samePartsRows = (SameParts.SamePartsRow[])_PartsTable.Select(filter);

            //if (samePartsRows.Length > 0 && _orgDataSet.UsrGoodsInfo.Count > 0)
            //{
            //    PartsInfoDataSet.UsrGoodsInfoRow rowUsr = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(samePartsRows[0].MakerCode, samePartsRows[0].PartsNoToShow);
            //    if (rowUsr != null)
            //    {
            //        rowUsr.SelectionState = true;
            //        rowUsr.GoodsKindResolved = (int)GoodsKind.Parent;
            //    }
            //}
            int cnt = gridParts.Rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = null;
                UltraGridRow gridRow = gridParts.Rows[i];
                if (gridRow.Cells[_PartsTable.SelectionStateColumn.ColumnName].Value.Equals(true))
                {
                    gridRow.Cells[_PartsTable.SelectionStateColumn.ColumnName].Value = false; // ����̂��߃N���A���Ă����B
                    // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                    //row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo((int)gridRow.Cells[_PartsTable.MakerCodeColumn.ColumnName].Value,
                    //        gridRow.Cells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString());
                    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( (int)gridRow.Cells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value,
                            gridRow.Cells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString() );
                    // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                    if (row != null)
                    {
                        _orgDataSet.ListSelectionInfo.Clear();
                        SelectionInfo selInfo = new SelectionInfo();
                        selInfo.Depth = 0;
                        selInfo.Key = gridRow.ListIndex;
                        selInfo.RowGoods = row;
                        selInfo.WarehouseCode = gridRow.Cells[_PartsTable.WarehouseCodeColumn.ColumnName].Value.ToString();
                        //if (uiControlFlg && gridRow.Cells[_PartsTable.SelImageColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                        //    selInfo.Selected = true;
                        //else
                        selInfo.Selected = false;
                        _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                        if (gridParts.ActiveRow != null && i == gridParts.ActiveRow.Index)
                        {
                            switch (_orgDataSet.UIKind)
                            {
                                case SelectUIKind.Join:
                                    _orgDataSet.JoinSrcSelInf = selInfo;
                                    break;
                                case SelectUIKind.Set:
                                    _orgDataSet.SetSrcSelInf = selInfo;
                                    break;
                                case SelectUIKind.Subst:
                                    _orgDataSet.SubstSrcSelInf = selInfo;
                                    break;
                            }
                            //if (_orgDataSet.UIKind == SelectUIKind.Join)
                            //    _orgDataSet.JoinSrcSelInf = selInfo;
                            //else if (_orgDataSet.UIKind == SelectUIKind.Set)
                            //    _orgDataSet.SetSrcSelInf = selInfo;
                            //else 
                            //if (uiControlFlg // PM7������̏ꍇ�͎��̉�ʂ��\������邽�ߑI�����Ȃ��B
                            //   || _orgDataSet.SearchCondition == null // ���œ���i�ԑI��UI���J���Ƃ�
                            if (_mode == 3 // �݌ɑg���̏ꍇ
                               || _orgDataSet.SearchCondition == null // ���œ���i�ԑI��UI���J���Ƃ�
                               || _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsInfoOnly) // �i�Ԍ����݂̂̏ꍇ
                                selInfo.Selected = true;
                            _prevSelInfo = selInfo;
                        }
                    }
                }
                else
                {
                    _orgDataSet.RemoveSelectionInfo(_orgDataSet.ListSelectionInfo, gridRow.ListIndex);
                }
            }

        }

        private void SelectionSamePartsNoParts_Shown(object sender, EventArgs e)
        {
            if (gridParts.Rows.Count == 0)
                return;
            // �擪�s��I����Ԃɂ���
            gridParts.Focus();
            gridParts.Rows[0].Activate();
            gridParts.Rows[0].Selected = true;
        }

        private void SelectionSamePartsNoParts_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (uiControlFlg && e.CloseReason == CloseReason.UserClosing && isUserClose)
            //{
            //    if (TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Text, "�I��UI���I�����܂����H", 0, MessageBoxButtons.YesNo)
            //        == DialogResult.Yes)
            //    {
            //        this.DialogResult = DialogResult.Cancel;
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }

        /// <summary>
        /// ESC�L�[�����ɂ��I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionSamePartsNoParts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                isUserClose = false;
            }
        }

        /// <summary>
        /// �c�[���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            UltraGridRow activeRow = gridParts.ActiveRow;
            switch (e.Tool.Key)
            {
                case "Button_Select":
                    // �I������Ă���s���m�肷��
                    DialogResult = DialogResult.OK;
                    isUserClose = false;
                    //if (uiControlFlg == false)
                    SetSelect();
                    break;

                case "Button_Back":
                    // �O�̉�ʂɖ߂�
                    DialogResult = DialogResult.Cancel;
                    isUserClose = false;
                    break;

                case "Button_Subst":
                    // ��ւ�����ꍇ���UI�\��
                    if (activeRow != null)
                    {
                        if (activeRow.Cells[_PartsTable.SubstColumn.ColumnName].Value != DBNull.Value)
                        {
                            //DialogResult = DialogResult.OK;
                            isUserClose = false;
                            // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                            //int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeColumn.ColumnName].Value;
                            int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value;
                            // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                            string partsNo = activeRow.Cells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                _orgDataSet.UIKind = SelectUIKind.Subst;
                                DialogResult = DialogResult.Retry;
                            }
                        }
                    }
                    break;

                case "Button_Set":
                    // �Z�b�g������ꍇ�Z�b�g�I��UI�\��
                    if (uiControlFlg && activeRow != null)
                    {
                        if (activeRow.Cells[_PartsTable.SetColumn.ColumnName].Value != DBNull.Value)
                        {
                            //DialogResult = DialogResult.OK;
                            isUserClose = false;
                            // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                            //int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeColumn.ColumnName].Value;
                            int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value;
                            // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                            string partsNo = activeRow.Cells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                activeRow.Cells[_PartsTable.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                _orgDataSet.UIKind = SelectUIKind.Set;
                                DialogResult = DialogResult.Retry;
                            }
                        }
                    }
                    break;

                case "Button_Join":
                    if (uiControlFlg && activeRow != null)
                    {
                        if (activeRow.Cells[_PartsTable.JoinColumn.ColumnName].Value != DBNull.Value)
                        {
                            DialogResult = DialogResult.OK;
                            isUserClose = false;
                            // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                            //int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeColumn.ColumnName].Value;
                            int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value;
                            // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                            string partsNo = activeRow.Cells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                activeRow.Cells[_PartsTable.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                _orgDataSet.UIKind = SelectUIKind.Join;
                                DialogResult = DialogResult.Retry;
                            }
                        }
                    }
                    break;

                case "Button_SubstOff":
                    if (activeRow != null &&
                        activeRow.Cells[_PartsTable.OldPartsNoColumn.ColumnName].Value.Equals(string.Empty) == false)
                    {
                        // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                        //int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeColumn.ColumnName].Value;
                        int makerCd = (int)activeRow.Cells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value;
                        // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                        string partsNo = activeRow.Cells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString();
                        string oldPartsNo = activeRow.Cells[_PartsTable.OldPartsNoColumn.ColumnName].Value.ToString();
                        SameParts.SamePartsRow oldRow = _PartsTable.FindByMakerCodePartsNo(makerCd, partsNo);
                        PartsInfoDataSet.UsrGoodsInfoRow newRow =
                            _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, oldPartsNo);

                        oldRow.OldPartsNo = string.Empty;
                        oldRow.PartsNo = newRow.GoodsNo;
                        oldRow.PartsName = newRow.GoodsName;
                        if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                        {
                            oldRow.Price = newRow.PriceTaxInc;
                        }
                        else // ���z�\�����Ȃ��i�Ŕ����j
                        {
                            oldRow.Price = newRow.PriceTaxExc;
                        }
                        SetImage(oldRow);

                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo).SelectionState = false;
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

                        SetButtonState();
                        ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
                    }
                    break;
            }
        }
        #endregion

        #region [ ���C���O���b�h�C�x���g���� ]
        /// <summary>
        /// InitializeLayout �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�O���b�h�̃��C�A�E�g����������</br>
        /// </remarks>
        private void gridParts_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // �񕝂̎����������@
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            List<string> colShow = new List<string>(new string[]{
                _PartsTable.MakerCodeColumn.ColumnName,  // 0
                _PartsTable.MakerNameColumn.ColumnName,  // 1
                // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                //_PartsTable.PartsNoToShowColumn.ColumnName,    // 2
                _PartsTable.PartsNoColumn.ColumnName,    // 2
                // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                _PartsTable.PartsNameColumn.ColumnName,  // 3
                _PartsTable.PriceColumn.ColumnName,      // 4
                _PartsTable.SetColumn.ColumnName,        // 5
                //_PartsTable.SubstColumn.ColumnName,      // 6
                _PartsTable.JoinColumn.ColumnName,       // 7
                _PartsTable.WarehouseColumn.ColumnName,  // 8
                _PartsTable.ShelfColumn.ColumnName,      // 9
                _PartsTable.StockCntColumn.ColumnName    // 10
                });
            // �o���h�̎擾
            UltraGridBand Band = e.Layout.Bands[0];
            Band.UseRowLayout = true;

            for (int Index = 0; Index < Band.Columns.Count; Index++)
            {
                if (colShow.Contains(Band.Columns[Index].Key))
                {
                    // ��̕\���E��\��
                    //Band.Columns[Index].PerformAutoResize(PerformAutoSizeType.AllRowsInBand, true);  // �񕝂̃��T�C�Y
                    Band.Columns[Index].Hidden = false;
                }
                else
                {
                    Band.Columns[Index].Hidden = true;
                }

                // �����\���ʒu
                if (Band.Columns[Index].DataType == typeof(int) || Band.Columns[Index].DataType == typeof(double))
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (Band.Columns[Index].DataType == typeof(Image))
                {
                    Band.Columns[Index].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    Band.Columns[Index].CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                }
                else
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                Band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // �����\���ʒu
                Band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }

            // --- UPD 2014/03/04 Y.Wakita ---------->>>>>
            //ColInfo.SetColInfo(Band, _PartsTable.MakerCodeColumn.ColumnName, 2, 0, 40);
            ColInfo.SetColInfo(Band, _PartsTable.MakerCodeColumn.ColumnName, 2, 0, 36);
            // --- UPD 2014/03/04 Y.Wakita ----------<<<<<
            ColInfo.SetColInfo(Band, _PartsTable.MakerNameColumn.ColumnName, 6, 0, 100);
            // --- UPD m.suzuki 2011/01/31 ---------->>>>>
            //ColInfo.SetColInfo(Band, _PartsTable.PartsNoToShowColumn.ColumnName, 16, 0, 80);
            // --- UPD 2014/03/03 Y.Wakita ---------->>>>>
            //ColInfo.SetColInfo(Band, _PartsTable.PartsNoColumn.ColumnName, 16, 0, 80);
            ColInfo.SetColInfo(Band, _PartsTable.PartsNoColumn.ColumnName, 16, 0, 84);
            // --- UPD 2014/03/03 Y.Wakita ----------<<<<<
            // --- UPD m.suzuki 2011/01/31 ----------<<<<<
            ColInfo.SetColInfo(Band, _PartsTable.PartsNameColumn.ColumnName, 24, 0, 160);
            ColInfo.SetColInfo(Band, _PartsTable.PriceColumn.ColumnName, 40, 0, 60);
            ColInfo.SetColInfo(Band, _PartsTable.WarehouseColumn.ColumnName, 46, 0, 60);
            ColInfo.SetColInfo(Band, _PartsTable.ShelfColumn.ColumnName, 52, 0, 30);
            ColInfo.SetColInfo(Band, _PartsTable.StockCntColumn.ColumnName, 55, 0, 40);

            if (_mode == 2 && _orgDataSet.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo)
            {
                ColInfo.SetColInfo(Band, _PartsTable.SetColumn.ColumnName, 59, 0, 20);
                Band.Columns[_PartsTable.JoinColumn.ColumnName].Hidden = true;
            }
            else if (_mode != 1)
            {
                //Band.Columns[_PartsTable.SubstColumn.ColumnName].Hidden = true;
                Band.Columns[_PartsTable.SetColumn.ColumnName].Hidden = true;
                Band.Columns[_PartsTable.JoinColumn.ColumnName].Hidden = true;
            }
            else // �i�Ԍ�������
            {
                //ColInfo.SetColInfo(Band, _PartsTable.SubstColumn.ColumnName, 59, 0, 20);
                //ColInfo.SetColInfo(Band, _PartsTable.SetColumn.ColumnName, 61, 0, 20);
                //ColInfo.SetColInfo(Band, _PartsTable.JoinColumn.ColumnName, 63, 0, 20);
                ColInfo.SetColInfo(Band, _PartsTable.SetColumn.ColumnName, 59, 0, 20);
                ColInfo.SetColInfo(Band, _PartsTable.JoinColumn.ColumnName, 61, 0, 20);
            }

            // �\���t�H�[�}�b�g
            Band.Columns[_PartsTable.MakerCodeColumn.ColumnName].Format = "D4";
            Band.Columns[_PartsTable.PriceColumn.ColumnName].Format = "C";
            Band.Columns[_PartsTable.StockCntColumn.ColumnName].Format = "###,###,##0.00";
        }

        /// <summary>
        /// �A�N�e�B�u�s�ύX��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridParts_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            #region [ �݌ɃO���b�h�t�B���^�����O���� ]
            string filter = string.Empty;
            try
            {
                if (gridParts.ActiveRow == null)
                    return;

                filter = string.Format("{0}={1} AND {2}='{3}' ",
                    _StockTable.GoodsMakerCdColumn.ColumnName,
                    gridParts.ActiveRow.Cells[_PartsTable.MakerCodeColumn.ColumnName].Value,
                    _StockTable.GoodsNoColumn.ColumnName,
                    // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                    //gridParts.ActiveRow.Cells[_PartsTable.PartsNoToShowColumn.ColumnName].Value);
                    gridParts.ActiveRow.Cells[_PartsTable.PartsNoColumn.ColumnName].Value);
                    // --- UPD m.suzuki 2011/01/31 ----------<<<<<

                SetButtonState();
            }
            finally
            {
                _StockTable.DefaultView.RowFilter = filter;
            }
            #endregion

            SetStockGridSelect();
            if (gridParts.Selected.Rows.Count > 0 &&
                gridParts.Selected.Rows[0].Cells[_PartsTable.OldPartsNoColumn.ColumnName].Value.Equals(string.Empty) == false)
            {
                ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = true;
            }
            else
            {
                ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
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
        private void gridParts_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SetSelect();
        }

        /// <summary>
        /// �O���b�h���Enter�L�[�������ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridParts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetSelect();
            }
        }
        #endregion

        #region [ ���̑����\�b�h ]
        private void SetButtonState()
        {
            bool enaSet = false;
            bool enaSubst = false;
            bool enaJoin = false;
            try
            {
                if (this.gridParts.ActiveRow == null) return;//
                if (this.gridParts.ActiveRow.Band != gridParts.DisplayLayout.Bands[0]) return;
                //DataRow wkRow = (DataRow)this.grid.ActiveRow.Cells[COL_WR].Value;
                enaSet = (gridParts.ActiveRow.Cells[_PartsTable.SetColumn.ColumnName].Value != System.DBNull.Value);
                enaSubst = (gridParts.ActiveRow.Cells[_PartsTable.SubstColumn.ColumnName].Value != System.DBNull.Value);
                enaJoin = (gridParts.ActiveRow.Cells[_PartsTable.JoinColumn.ColumnName].Value != System.DBNull.Value);
                //enaSubst = enaSet = enaJoin = true;
            }
            finally
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.Enabled = enaSet;
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled = enaSubst;
                ToolbarsManager.Tools["Button_Join"].SharedProps.Enabled = enaJoin;
            }
        }

        private void SetSelect()
        {
            if (gridParts.ActiveRow != null)
            {
                CellsCollection activeCells = gridParts.ActiveRow.Cells;
                //if (uiControlFlg == false || enterFlg != 2)
                //{
                activeCells["SelectionState"].Value = true;
                //}
                //if (uiControlFlg && (enterFlg == 0 || enterFlg == 2)) // PM.NS�����䁕Enter�L�[��PM7���͎���ʂ̏ꍇ
                if (uiControlFlg && enterFlg == 2) // PM.NS�����䁕Enter�L�[������ʂ̏ꍇ
                {
                    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo
                        // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                        //((int)activeCells[_PartsTable.MakerCodeColumn.ColumnName].Value,
                        ((int)activeCells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value,
                        // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                         activeCells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString());
                    _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                    //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                    if (activeCells[_PartsTable.JoinColumn.ColumnName].Value != DBNull.Value)
                    {
                        _orgDataSet.UIKind = SelectUIKind.Join;
                        DialogResult = DialogResult.Retry;
                    }
                    else if (activeCells[_PartsTable.SetColumn.ColumnName].Value != DBNull.Value)
                    {
                        _orgDataSet.UIKind = SelectUIKind.Set;
                        DialogResult = DialogResult.Retry;
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    // 2009/12/03 Add >>>
                    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo
                        // --- UPD m.suzuki 2011/01/31 ---------->>>>>
                        //((int)activeCells[_PartsTable.MakerCodeColumn.ColumnName].Value,
                        ((int)activeCells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value,
                        // --- UPD m.suzuki 2011/01/31 ----------<<<<<
                         activeCells[_PartsTable.PartsNoToShowColumn.ColumnName].Value.ToString());
                    _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                    // 2009/12/03 Add <<<
                    DialogResult = DialogResult.OK;
                }
                isUserClose = false;
            }
            SetStockGridSelect();

            // --- ADD m.suzuki 2011/01/31 ---------->>>>>
            // ��֌����I�����ꂽ�ꍇ�̑�֐�݌ɑI������
            SetStockGridSelectOnClose();
            // --- ADD m.suzuki 2011/01/31 ----------<<<<<
        }

        /// <summary>
        /// �݌ɃO���b�h�I�������i���[�U�[�I�����D��q�Ɂ��擪�s�̏��őI���j
        /// </summary>
        private void SetStockGridSelect()
        {
            if (gridParts.ActiveRow.Cells[_PartsTable.WarehouseCodeColumn.ColumnName].Value.Equals(string.Empty) == false)
            {
                for (int i = 0; i < gridStock.Rows.Count; i++)
                {
                    if (gridStock.Rows[i].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value
                        .Equals(gridParts.ActiveRow.Cells[_PartsTable.WarehouseCodeColumn.ColumnName].Value))
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
                // �Y�����Ȃ��ꍇ�͐擪�s�Ƀt�H�[�J�X�̂݃Z�b�g
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //if (_orgDataSet.ListPriorWarehouse != null)
            //{
            //    for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
            //    {
            //        string warehouseCd = _orgDataSet.ListPriorWarehouse[i];
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
            //    gridParts.ActiveRow.Cells[_PartsTable.WarehouseColumn.ColumnName].Value = string.Empty;
            //    gridParts.ActiveRow.Cells[_PartsTable.ShelfColumn.ColumnName].Value = string.Empty;
            //    gridParts.ActiveRow.Cells[_PartsTable.StockCntColumn.ColumnName].Value = 0;
            //    gridParts.ActiveRow.Cells[_PartsTable.WarehouseCodeColumn.ColumnName].Value = string.Empty;
            //    gridParts.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
        }
        // --- ADD m.suzuki 2011/01/31 ---------->>>>>
        /// <summary>
        /// �I�����ɑ�֐�݌ɂ̗D��q�ɂ𔽉f������
        /// </summary>
        private void SetStockGridSelectOnClose()
        {
            CellsCollection activeCells = gridParts.ActiveRow.Cells;
            if (activeCells != null)
            {
                int makerCodeToShow = (int)activeCells[_PartsTable.MakerCodeToShowColumn.ColumnName].Value;
                int makerCode = (int)activeCells[_PartsTable.MakerCodeColumn.ColumnName].Value;
                string partsNoToShow = (string)activeCells[_PartsTable.PartsNoToShowColumn.ColumnName].Value;
                string partsNo = (string)activeCells[_PartsTable.PartsNoColumn.ColumnName].Value;

                // ��֌���I�������ꍇ
                if (makerCodeToShow != makerCode ||
                    partsNoToShow != partsNo)
                {
                    // �݌ɑI������
                    for ( int k = 0; k < _StockTable.Rows.Count; k++ )
                    {
                        _StockTable.Rows[k][_StockTable.SelectionStateColumn.ColumnName] = false;
                    }
                    activeCells[_PartsTable.WarehouseCodeColumn.ColumnName].Value = string.Empty;
                    activeCells[_PartsTable.WarehouseColumn.ColumnName].Value = string.Empty;
                    activeCells[_PartsTable.ShelfColumn.ColumnName].Value = string.Empty;
                    activeCells[_PartsTable.StockCntColumn.ColumnName].Value = 0;


                    // ��֐�݌ɂ�I���i�D��q�ɂ���I���j
                    if ( _orgDataSet.ListPriorWarehouse != null )
                    {
                        bool flgStock = false;

                        for ( int j = 0; j < _orgDataSet.ListPriorWarehouse.Count; j++ )
                        {
                            string warehouseCd = _orgDataSet.ListPriorWarehouse[j].Trim();

                            for ( int k = 0; k < _StockTable.Rows.Count; k++ )
                            {
                                // ��֐�̍݌�
                                if ( _StockTable.Rows[k][_StockTable.WarehouseCodeColumn.ColumnName].Equals( warehouseCd ) &&
                                     partsNoToShow == (string)_StockTable.Rows[k][_StockTable.GoodsNoColumn.ColumnName] &&
                                     makerCodeToShow == (int)_StockTable.Rows[k][_StockTable.GoodsMakerCdColumn.ColumnName] )
                                {
                                    // �݌ɑI��
                                    _StockTable.Rows[k][_StockTable.SelectionStateColumn.ColumnName] = true;
                                    
                                    // ���iTable�X�V(�݌ɏ��X�V)
                                    activeCells[_PartsTable.WarehouseCodeColumn.ColumnName].Value = _StockTable.Rows[k][_StockTable.WarehouseCodeColumn.ColumnName];
                                    activeCells[_PartsTable.WarehouseColumn.ColumnName].Value = _StockTable.Rows[k][_StockTable.WarehouseNameColumn.ColumnName];
                                    activeCells[_PartsTable.ShelfColumn.ColumnName].Value = _StockTable.Rows[k][_StockTable.WarehouseShelfNoColumn.ColumnName];
                                    activeCells[_PartsTable.StockCntColumn.ColumnName].Value = _StockTable.Rows[k][_StockTable.ShipmentPosCntColumn.ColumnName];
                                    flgStock = true;
                                    break;
                                }
                            }
                            if ( flgStock )
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        // --- ADD m.suzuki 2011/01/31 ----------<<<<<
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            band.Columns[_StockTable.SortDivColumn.ColumnName].Hidden = true;
            if ( this.VisibleStockSelectCheckBox() )
            {
                band.Columns[_StockTable.SelImageColumn.ColumnName].Hidden = false;
            }
            else
            {
                band.Columns[_StockTable.SelImageColumn.ColumnName].Hidden = true;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            ColInfo.SetColInfo( band, _StockTable.SelImageColumn.ColumnName, 0, 0, 10 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            if ( !this.VisibleStockSelectCheckBox() )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            {
                if ( gridStock.ActiveRow != null && gridParts.ActiveRow != null )
                {
                    gridParts.ActiveRow.Cells[_PartsTable.WarehouseColumn.ColumnName].Value
                        = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
                    gridParts.ActiveRow.Cells[_PartsTable.ShelfColumn.ColumnName].Value
                        = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
                    gridParts.ActiveRow.Cells[_PartsTable.StockCntColumn.ColumnName].Value
                        = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
                    gridParts.ActiveRow.Cells[_PartsTable.WarehouseCodeColumn.ColumnName].Value
                        = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
                    gridStock.ActiveRow.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
                    gridParts.UpdateData();
                }
            }
        }

        private void gridStock_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            if ( !this.VisibleStockSelectCheckBox() )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            {
                if ( gridStock.Selected.Rows.Count > 0 )
                    gridStock.Selected.Rows[0].Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
        /// <summary>
        /// �݌ɑI���`�F�b�N�{�b�N�X�\���`�F�b�N
        /// </summary>
        /// <returns></returns>
        private bool VisibleStockSelectCheckBox()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 DEL
            //// 2:�G���g��, 3:�݌ɑg���̏ꍇ
            //return (_mode == 2 || _mode == 3);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
            // ��ɕ\������B
            return true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
        }
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
                if ( gridParts.ActiveRow != null )
                {
                    if ( (bool)activeCells[_StockTable.SelectionStateColumn.ColumnName].Value == true )
                    {
                        // ���i�O���b�h�ɍ݌ɏ��\��
                        gridParts.ActiveRow.Cells[_PartsTable.WarehouseColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
                        gridParts.ActiveRow.Cells[_PartsTable.ShelfColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
                        gridParts.ActiveRow.Cells[_PartsTable.StockCntColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
                        gridParts.ActiveRow.Cells[_PartsTable.WarehouseCodeColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
                    }
                    else
                    {
                        // ���i�O���b�h�̍݌ɏ����N���A
                        gridParts.ActiveRow.Cells[_PartsTable.WarehouseColumn.ColumnName].Value = string.Empty;
                        gridParts.ActiveRow.Cells[_PartsTable.ShelfColumn.ColumnName].Value = string.Empty;
                        gridParts.ActiveRow.Cells[_PartsTable.StockCntColumn.ColumnName].Value = 0;
                        gridParts.ActiveRow.Cells[_PartsTable.WarehouseCodeColumn.ColumnName].Value = string.Empty;
                    }
                    gridParts.UpdateData();
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
                // �����I�ɕ��i�O���b�h�Ɉړ�
                gridParts.Focus();
            }
        }
        // --- ADD m.suzuki 2010/10/26 ----------<<<<<
        #endregion

    }
}