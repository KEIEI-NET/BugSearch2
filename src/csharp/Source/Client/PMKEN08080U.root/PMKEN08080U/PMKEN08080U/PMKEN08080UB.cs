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
    /// <br>             : �݌ɂ̑I����@���`�F�b�N�����ɕύX�i���`�F�b�N�Ŏ���I���\�ɕύX�j</br>
    /// <br>Programmer	: 22018�@��� ���b</br>
    /// <br>Date		: 2009.03.27</br>
    /// <br></br>
    /// <br>Update Note	: ���������i���\�����i��1���̏ꍇ�ɃJ�^���O�i�Ԃ̌�����񂪕\������Ȃ��s��̏C��</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009/09/29</br>
    /// <br></br>
    /// <br>Update Note	: SCM�����񓚑Ή�</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2010/03/16</br>
    /// <br></br>
    /// <br>Update Note	: ��Q���ǑΉ��i�W�����j�i�����������ԕ��i �Ή��j</br>
    /// <br>             :   �E�݌Ƀ[�����̏ꍇ�́A�݌ɃO���b�h�Ƀt�H�[�J�X�ړ����Ȃ��悤�ɕύX�B</br>
    /// <br>Programmer	: 22018�@��� ���b</br>
    /// <br>Date		: 2010/10/26</br>
    /// <br></br>
    /// <br>Update Note	:liyp 2010/12/03  ��Q���ǑΉ��i�P�Q�����j</br>
    /// <br>             ���������\���敪���u�݌ɏ��v�̏ꍇ�̃\�[�g��̕ύX���s��</br>
    /// <br></br>
    /// <br>Update Note	: ��Q�Ή�</br>
    /// <br>            :   �u���������\���敪�F�݌ɏ��v�ɂ����ꍇ�AQTY������ɃZ�b�g����Ȃ����̑Ή�</br>
    /// <br>Programmer	: 20056�@���n ���</br>
    /// <br>Date		: 2010/12/09</br>
    /// <br></br>
    /// <br>Update Note	: ��Q���ǑΉ��i�������j</br>
    /// <br>             :   �E��֐�����o�l�V�����̓���ɏC���B</br>
    /// <br>                   �i��֌��̍݌ɂ�����΁A��ւ��Ȃ��B(�������I������̑�ւ̓��[�U�[��ւ̂�)�j</br>
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
    /// <br></br>
    /// <br>UpdateNote   : 2012/12/11 zhuhh</br>
    /// <br>�Ǘ��ԍ�     : 10806793-00�@2013/03/13�z�M��</br>
    /// <br>             : redmine #33834 �����I����ʂ̏C��</br>
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
    /// <br>Update Note  : SCM��Q��10462�Ή�</br>
    /// <br>             :   �E�c�[���o�[�̊m��{�^��(F10)�������ɑI����Ԃ̍s���L���ɂȂ�Ȃ���Q�̑Ή�</br>
    /// <br>Programmer   : 30744  ���� ����q</br>
    /// <br>Date         : 2013/01/11</br>
    /// <br></br>
    /// <br>Update Note: 2015/12/18 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 11170207-00 �d�|�ꗗ ��2810</br>
    /// <br>           : ���L�������\������Ȃ���Q�̑Ή�</br>
    /// </remarks>
    public partial class SelectionFormJ : Form
    {
        #region [ Private Member Variable ]
        /// <summary>�f�[�^�Z�b�g</summary>
        private PartsInfoDataSet _orgDataSet = null;
        private PartsInfoDataSet.UsrJoinPartsDataTable _orgUsrJoin = null;
        /// <summary>�������郍�[�i�񋟏������i���̓��[�U�[�o�^���i�j</summary>
        private PartsInfoDataSet.UsrGoodsInfoRow _orgRow = null;
        // 2009/09/29 Add >>>
        /// <summary>�ŐV�i�Ԃ̕��i���</summary>
        private PartsInfoDataSet.UsrGoodsInfoRow _newPartsRow = null;
        // 2009/09/29 Add <<<
        private PartsInfoDataSet.UsrGoodsInfoRow _prevRow = null;
        /// <summary>�����̌����񋟏������i�̏ꍇ���̏������i���������[</summary>
        private PartsInfoDataSet.PartsInfoRow _partsInfoRow = null;
        private dsParts _joinParts = null;
        private dsParts.StockDataTable _StockTable = null;
        //public dsParts JoinParts
        //{
        //    get
        //    {
        //        return _joinParts;
        //    }
        //}
        //private bool orgRowChged = false;
        private string _clgPartsNo; // �J�^���O�i��(�������i��)
        private string _newPartsNo; // �ŐV�i��
        //private string _selectedPartsNo; // �I��i��
        private int _makerCd;

        // 2010/03/16 Add >>>
        /// <summary>
        /// ���[�h(0:�ʏ�,1:�����S�I��)
        /// </summary>
        private int _mode;
        // 2010/03/16 Add <<<

        private bool isUserClose = true;

        #region [ �\���I�v�V�����֘A�ϐ� ]
        /// <summary>UI��������@[false:PM7�X�^�C���@�@true:PM.NS�X�^�C��]</summary> 
        private bool uiControlFlg;      // false:PM7�X�^�C���@�@true:PM.NS�X�^�C��
        private int substFlg;           // 0:��ւ��Ȃ�  1:��ւ���i�݌ɔ��肠��j 2:��ւ���i�݌ɔ���Ȃ��j
        private int userSubstFlg;
        private int enterFlg;           // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
        private int displayOrder;       // 0:�\���� 1:�݌ɏ�
        private int totalAmountDispWay;       // ���z�\�����@�敪 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j

        #endregion
        private bool isDialogShown = true;

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

        /// <summary> �_�C�A���O���\���ۃt���O�i�f�[�^���ɂ�莩������j </summary>
        public bool IsDialogShown
        {
            get { return isDialogShown; }
        }

        /// <summary> ������i�Ԃ̑I�����X�g </summary>
        private Dictionary<int, SelectionInfo> _lstSelInf;
        /// <summary> �������i�Ԃ̑I����� </summary>
        private SelectionInfo _selInf;
        private SelectionInfo _prevSelInfo;
        #endregion

        #region [ Constructor ]
        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        /// <param name="dsSource">�O���b�h�ɕ\������f�[�^���w�肵�܂��B</param>
        public SelectionFormJ(PartsInfoDataSet dsSource)
        {
            _orgDataSet = dsSource;
            _orgUsrJoin = dsSource.UsrJoinParts;
            //_prevRow = _orgRow;
            _orgRow = dsSource.UsrGoodsInfo.RowToProcess;
            // 2009/09/29 Add >>>
            _newPartsRow = _orgRow;
            // 2009/09/29 Add <<<
            SearchCntSetWork cond = dsSource.SearchCondition.SearchCntSetWork;
            uiControlFlg = Convert.ToBoolean(cond.SearchUICntDivCd); // 0:PM7�X�^�C���^1:PM.NS�X�^�C��
            substFlg = cond.PrmSubstCondDivCd; // 0:��ւ��Ȃ�  1:��ւ���i�݌ɔ��肠��j 2:��ւ���i�݌ɔ���Ȃ��j
            userSubstFlg = cond.SubstApplyDivCd;
            enterFlg = cond.EnterProcDivCd; // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
            displayOrder = cond.JoinInitDispDiv; // 0:�\���� 1:�݌ɏ�
            totalAmountDispWay = cond.TotalAmountDispWayCd; // 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j
            //////////////////////////////

            InitializeComponent();
            InitializeForm();
            InitializeTable();

            //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
        }

        // 2010/03/16 Add >>>
        /// <summary>
        /// �I����ʃR���X�g���N�^�i��ʕ\������)
        /// </summary>
        /// <param name="dsSource">�f�[�^�\�[�X</param>
        /// <param name="mode">0:�ʏ� 1:�����S�I��</param>
        public SelectionFormJ(PartsInfoDataSet dsSource, int mode)
        {
            _orgDataSet = dsSource;
            _orgUsrJoin = dsSource.UsrJoinParts;
            _orgRow = dsSource.UsrGoodsInfo.RowToProcess;
            _newPartsRow = _orgRow;
            _orgDataSet = dsSource;
            _orgUsrJoin = dsSource.UsrJoinParts;
            //_prevRow = _orgRow;
            _orgRow = dsSource.UsrGoodsInfo.RowToProcess;
            // 2009/09/29 Add >>>
            _newPartsRow = _orgRow;
            // 2009/09/29 Add <<<
            SearchCntSetWork cond = dsSource.SearchCondition.SearchCntSetWork;
            uiControlFlg = Convert.ToBoolean(cond.SearchUICntDivCd); // 0:PM7�X�^�C���^1:PM.NS�X�^�C��
            substFlg = cond.PrmSubstCondDivCd; // 0:��ւ��Ȃ�  1:��ւ���i�݌ɔ��肠��j 2:��ւ���i�݌ɔ���Ȃ��j
            userSubstFlg = cond.SubstApplyDivCd;
            enterFlg = cond.EnterProcDivCd; // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
            displayOrder = cond.JoinInitDispDiv; // 0:�\���� 1:�݌ɏ�
            totalAmountDispWay = cond.TotalAmountDispWayCd; // 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j

            this.InitializeTable2();
        }
        // 2010/03/16 Add <<<
        #endregion

        #region [ �C�j�V�������� ]
        private void InitializeForm()
        {
            // �X�e�[�^�X�o�[�̏�����
            StatusBar.Panels[0].Text = "";
            // �c�[���o�[�̃C���[�W(16x16)�⃁�b�Z�[�W��ݒ肷��
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            if (uiControlFlg)
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODEL;
            }
            else
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
        /// <br>Update Note :liyp 2010/12/03</br>
        /// <br>             ���������\���敪���u�݌ɏ��v�̏ꍇ�̃\�[�g��̕ύX���s��</br>
        /// <br>UpdateNote   : 2012/12/11 zhuhh</br>
        /// <br>�Ǘ��ԍ�     : 10806793-00�@2013/03/13�z�M��</br>
        /// <br>             : redmine #33834 �����I����ʂ̏C��</br>
        private void InitializeTable()
        {
            _orgRow = _orgDataSet.UsrGoodsInfo.RowToProcess;
            //_prevRow = _orgDataSet.UsrGoodsInfo.PreviouslyProcessedRow;

            // �������i���擾����
            PartsInfoDataSet.PartsInfoRow[] childRows = (PartsInfoDataSet.PartsInfoRow[])_orgRow.GetChildRows("UsrGoodsInfo_PartsInfo");
            if (childRows.Length > 0)
            {
                _partsInfoRow = childRows[0];
            }
            //if (_partsInfoRow != null)
            //{
            //    _clgPartsNo = _partsInfoRow.ClgPrtsNoWithHyphen;
            //    _newPartsNo = _partsInfoRow.NewPrtsNoWithHyphen;
            //    _selectedPartsNo = _orgDataSet.GoodsNoSel;
            //    _makerCd = _partsInfoRow.CatalogPartsMakerCd;
            //    if (_clgPartsNo != _newPartsNo &&
            //        ((_orgRow.NewGoodsNo != _clgPartsNo && _orgRow.NewGoodsNo != _selectedPartsNo) // �J�^���O�i�ԈȊO�ɑ�ւ����ꍇ
            //        //(_orgRow.NewGoodsNo != _clgPartsNo // �J�^���O�i�ԈȊO�ɑ�ւ����ꍇ
            //        || _selectedPartsNo == _clgPartsNo)) // �J�^���O�i�Ԃɑ�ւ����ꍇ
            //    { // NewGoodsNo�͏������i�I��UI�ł̑�ւȂǂɂ�鏈���̂��ߎg���B
            //        _newPartsNo = _clgPartsNo;
            //        _orgRow = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_makerCd, _newPartsNo);
            //        orgRowChged = true; // ���̃t���O��InitializeTable��ShowDialog��2��ڎ��s����邱�Ƃ�h��
            //    }
            //    else
            //    {
            //        orgRowChged = false;
            //    }
            //}
            //else
            //{
            _clgPartsNo = _orgRow.GoodsNo;
            if (_orgRow.NewGoodsNo == string.Empty)
                _newPartsNo = _clgPartsNo;
            else
                _newPartsNo = _orgRow.NewGoodsNo;
            _makerCd = _orgRow.GoodsMakerCd;
            //}

            // 2009/09/29 Add >>>
            // �ŐV�i�Ԃ̏��ݒ�
            _newPartsRow = ( _newPartsNo != _clgPartsNo ) ? _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_makerCd, _newPartsNo) : _newPartsRow = _orgRow;

            // �ʏ킠�肦�Ȃ�
            if (_newPartsRow == null) _newPartsRow = _orgRow;
            // 2009/09/29 Add <<<

            // 2010/03/16 >>>
            //InitializeData();
            InitializeData(true);
            // 2010/03/16 <<<

            // 2010/03/16 Add >>>
            gridJoinParts.DataSource = _joinParts.PartsInfo.DefaultView;

            gridStock.DataSource = _StockTable.DefaultView;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            SettingStockView(_StockTable.DefaultView);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD

            if (displayOrder == 1) // 1:�݌ɏ���
            {
                //gridJoinParts.Rows[0].ChildBands[0].Band.SortedColumns.Add(_joinParts.JoinParts.StockCntColumn.ColumnName, true);
                gridJoinParts.DisplayLayout.Bands[1].SortedColumns.Add(_joinParts.JoinParts.StockCntColumn.ColumnName, true);
            }
            else
            {
                gridJoinParts.DisplayLayout.Bands[1].SortedColumns.Add(_joinParts.JoinParts.JoinDispOrderColumn.ColumnName, false);
            }

            Infragistics.Win.Appearance app = new Infragistics.Win.Appearance();
            //app.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            app.ForeColor = Color.Red;
            // ----- ADD zhuhh 2012/12/11 for Redmine #33834 ----->>>>>
            Infragistics.Win.Appearance app2 = new Infragistics.Win.Appearance();
            app2.BackColor = Color.Cyan;
            bool flag = false;
            // ----- ADD zhuhh 2012/12/11 for Redmine #33834 -----<<<<<

            for (int i = 0; i < gridJoinParts.Rows[0].ChildBands[0].Rows.Count; i++)
            {
                string joinSrcPartsNo = gridJoinParts.Rows[0].ChildBands[0].Rows[i].Cells[_joinParts.JoinParts.JoinSourPartsNoColumn.ColumnName].Text;
                if (_clgPartsNo != _newPartsNo && _newPartsNo == joinSrcPartsNo)
                {
                    gridJoinParts.Rows[0].ChildBands[0].Rows[i].Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Appearance = app;
                    gridJoinParts.Rows[0].ChildBands[0].Rows[i].Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].SelectedAppearance = app;   
                }
                // ----- ADD zhuhh 2012/12/11 for Redmine #33834 ----->>>>>
                if (_clgPartsNo == joinSrcPartsNo && _newPartsNo != joinSrcPartsNo) 
                {
                    gridJoinParts.Rows[0].ChildBands[0].Rows[i].Cells[_joinParts.JoinParts.JoinSourPartsNoColumn.ColumnName].Appearance = app2;
                    flag = true;  
                }
                // ----- ADD zhuhh 2012/12/11 for Redmine #33834 -----<<<<<
            }
            if (flag) gridJoinParts.Rows[0].Appearance = app2;//ADD zhuhh 2012/12/11 for Redmine #33834
            // 2010/03/16 Add <<<

            // --------------- ADD 2010/12/03 -----------------<<<<<
            if (displayOrder == 1) // 1:�݌ɏ���
            {
                gridJoinParts.Rows[0].ChildBands[0].Band.Columns[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].SortIndicator = SortIndicator.Descending;
                gridJoinParts.Rows[0].ChildBands[0].Band.Columns[_joinParts.JoinParts.StockCntColumn.ColumnName].SortIndicator = SortIndicator.Descending;
                gridJoinParts.Rows[0].ChildBands[0].Band.SortedColumns.Add(_joinParts.JoinParts.WarehouseCodeColumn.ColumnName, true); 
                gridJoinParts.Rows[0].ChildBands[0].Band.SortedColumns.Add(_joinParts.JoinParts.StockCntColumn.ColumnName, true);
            }
            // --------------- ADD 2010/12/03 ----------------->>>>>

            // �擪�s��I����Ԃɂ���
            //gridJoinParts.Rows[0].Activate();
            //gridJoinParts.Rows[0].Selected = true;
            gridJoinParts.Rows[0].ExpandAll();
            gridJoinParts.Rows[0].Fixed = true;
        }

        /// <summary>
        /// �R���g���[���̃f�[�^�Z�b�g��胍�[�J���f�[�^�Z�b�g�ւ̃f�[�^�R�s�[
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2015/12/18 �e�c ���V</br>
        /// <br>�Ǘ��ԍ�   : 11170207-00 �d�|�ꗗ ��2810</br>
        /// <br>           : ���L�������\������Ȃ���Q�̑Ή�</br>
        /// </remarks>
        // 2010/03/16 >>>
        //private void InitializeData()
        private void InitializeData(bool setPrice)
        // 2010/03/16 <<<
        {
            // 2010/03/16 >>>
            //// 2009.02.10 Add >>>
            //this.SettingPriceTargetData();
            //// 2009.02.10 Add <<<

            if (setPrice)
            {
                this.SettingPriceTargetData();
            }
            // 2010/03/16 <<<
            _joinParts = new dsParts();
            _StockTable = _joinParts.Stock;

            #region [ �������i�ݒ� ]
            dsParts.PartsInfoRow row = _joinParts.PartsInfo.NewPartsInfoRow();
            row.ClgPrtsNo = _orgRow.GoodsNo;
            row.MakerCd = _orgRow.GoodsMakerCd;
            row.MakerName = _orgRow.GoodsMakerNm;

            // 2009/09/29 ���i���͍ŐV���i�̏���\������ >>>
            //if ((_orgRow.OfferKubun == 1 || _orgRow.OfferKubun == 3) &&  // �Z�b�g�e��������
            //    _orgRow.SearchPartsFullName != string.Empty)
            //{
            //    row.PartsName = _orgRow.SearchPartsFullName;
            //}
            //else if (_orgRow.GoodsName != string.Empty)
            //{
            //    row.PartsName = _orgRow.GoodsName;
            //}
            //else
            //{
            //    row.PartsName = _orgRow.GoodsOfrName;
            //}

            //if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
            //{
            //    row.Price = _orgRow.PriceTaxInc;
            //    row.UriTanka = _orgRow.SalesUnitPriceTaxInc;
            //    row.GenTanka = _orgRow.UnitCostTaxInc;
            //}
            //else
            //{
            //    row.Price = _orgRow.PriceTaxExc;
            //    row.UriTanka = _orgRow.SalesUnitPriceTaxExc;
            //    row.GenTanka = _orgRow.UnitCostTaxExc;
            //}
            //// �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
            //row.Ararigaku = _orgRow.SalesUnitPriceTaxExc - _orgRow.UnitCostTaxExc;
            //if (_orgRow.SalesUnitPriceTaxExc != 0)
            //    row.Arariritu = row.Ararigaku / _orgRow.SalesUnitPriceTaxExc;

            if (( _newPartsRow.OfferKubun == 1 || _newPartsRow.OfferKubun == 3 ) &&  // �Z�b�g�e��������
                _newPartsRow.SearchPartsFullName != string.Empty)
            {
                row.PartsName = _newPartsRow.SearchPartsFullName;
            }
            else if (_newPartsRow.GoodsName != string.Empty)
            {
                row.PartsName = _newPartsRow.GoodsName;
            }
            else
            {
                row.PartsName = _newPartsRow.GoodsOfrName;
            }

            if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
            {
                row.Price = _newPartsRow.PriceTaxInc;
                row.UriTanka = _newPartsRow.SalesUnitPriceTaxInc;
                row.GenTanka = _newPartsRow.UnitCostTaxInc;
            }
            else
            {
                row.Price = _newPartsRow.PriceTaxExc;
                row.UriTanka = _newPartsRow.SalesUnitPriceTaxExc;
                row.GenTanka = _newPartsRow.UnitCostTaxExc;
            }
            // �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
            row.Ararigaku = _newPartsRow.SalesUnitPriceTaxExc - _newPartsRow.UnitCostTaxExc;
            if (_newPartsRow.SalesUnitPriceTaxExc != 0)
                row.Arariritu = row.Ararigaku / _newPartsRow.SalesUnitPriceTaxExc;
            // 2009/09/29 <<<

            row.NewPrtsNo = _newPartsNo;
            row.PrmSetDtlNo2 = string.Empty;

            if (_partsInfoRow != null) // �������i��񂪂��邩(InitializeTable�Q��)
            {
                row.PartsOpNm = _partsInfoRow.PartsOpNm; // �������i�̓��L����
                row.PartsQty = _partsInfoRow.PartsQty;
                //row.ClgPrtsNo = _partsInfoRow.ClgPrtsNoWithHyphen;
                //if (_orgRow.NewGoodsNo != string.Empty)
                //    row.NewPrtsNo = _orgRow.NewGoodsNo;
                row.StandardName = _partsInfoRow.StandardName;
            }
            else
            {
                // 2009/09/29 >>>
                //row.PartsQty = _orgRow.QTY;
                row.PartsQty = _newPartsRow.QTY;
                // 2009/09/29 <<<
            }
            if (row.PartsQty == 0)
                row.PartsQty = 1;

            if (SubstExists(row.NewPrtsNo, row.MakerCd))
                row.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
            if (SetExists(row.NewPrtsNo, row.MakerCd))
                row.Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
            _joinParts.PartsInfo.AddPartsInfoRow(row);

            #region [ �݌ɐݒ� ]
            //�݌ɐݒ�
            bool flgStock = false;
            // 2009/09/29 >>>
            //PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])_orgRow.GetChildRows("UsrGoodsInfo_Stock");
            PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])_newPartsRow.GetChildRows("UsrGoodsInfo_Stock");
            // 2009/09/29 <<<
            for (int i = 0; i < stockRows.Length; i++)
            {
                dsParts.StockRow stockRow = _StockTable.NewStockRow();
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
                    row.Shelf = stockRow.WarehouseShelfNo;
                    row.StockCnt = stockRow.ShipmentPosCnt;
                    row.Warehouse = stockRow.WarehouseName;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                    row.WarehouseCode = stockRow.WarehouseCode;
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
                            row.Shelf = stockRows[k].WarehouseShelfNo;
                            row.StockCnt = stockRows[k].ShipmentPosCnt;
                            row.Warehouse = stockRows[k].WarehouseName;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                            row.WarehouseCode = stockRows[k].WarehouseCode;
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
            //    row.Shelf = stockRows[0].WarehouseShelfNo;
            //    row.StockCnt = stockRows[0].ShipmentPosCnt;
            //    row.Warehouse = stockRows[0].WarehouseName;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            //    row.WarehouseCode = stockRows[0].WarehouseCode;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
            #endregion
            #endregion

            //if(_joinParts.PartsInfo[0].ClgPrtsNo = _joinParts.PartsInfo[0].join
            //�������i�ݒ�
            string filter = string.Format("({0}='{1}' OR {2}='{3}') AND {4}={5}",
                        _orgUsrJoin.JoinSrcPartsNoWithHColumn.ColumnName, _clgPartsNo,
                        _orgUsrJoin.JoinSrcPartsNoWithHColumn.ColumnName, _newPartsNo,
                        _orgUsrJoin.JoinSourceMakerCodeColumn.ColumnName, _makerCd);
            PartsInfoDataSet.UsrJoinPartsRow[] rows =
                (PartsInfoDataSet.UsrJoinPartsRow[])_orgUsrJoin.Select(filter);//, _orgUsrJoin.JoinDispOrderColumn.ColumnName);
            for (int i = 0; i < rows.Length; i++)
            {
                PartsInfoDataSet.UsrJoinPartsRow rowToGetInfo = rows[i];

                PartsInfoDataSet.UsrGoodsInfoRow joinPartsRow =
                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(rowToGetInfo.JoinDestMakerCd, rowToGetInfo.JoinDestPartsNo);
                if (joinPartsRow == null) // ������Ƃ���ȃP�[�X�͂Ȃ�Ƃ����Ă���B�������E������B
                    continue;

                // --- UPD m.suzuki 2011/02/02 ---------->>>>>
                # region // DEL
                //if (substFlg != 1 || PartsStockCheck(rowToGetInfo.JoinDestPartsNo, rowToGetInfo.JoinDestMakerCd) == false)
                //{       // [��֏����F�݌ɔ���L�@���@���i�݌ɂ���̏ꍇ]�ȊO�͍ŐV�i�Ԃɑ�ւ���B
                //    PartsInfoDataSet.UsrGoodsInfoRow rowNew = _orgDataSet.GetOfrSubst(joinPartsRow);
                //    if (userSubstFlg != 0) // ���[�U�[��ւ��Ȃ��ȊO�̏ꍇ
                //    {
                //        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst(joinPartsRow);
                //        if (rowSubst.Equals(joinPartsRow)) // ���D�Ǖi�ɑ΂����[�U�[��ւ��Ȃ�
                //        {
                //            if (rowNew.Equals(joinPartsRow) == false) // �ŐV�i�Ԃ�����ꍇ
                //            {
                //                rowSubst = _orgDataSet.GetUsrSubst(rowNew);
                //                if (rowSubst.Equals(rowNew)) // �ŐV�i�ɑ΂����[�U�[��ւȂ�
                //                {
                //                    joinPartsRow = rowNew;
                //                }
                //                else // �ŐV�i�ɑ΂����[�U�[��ւ���
                //                {
                //                    joinPartsRow = rowSubst;
                //                }
                //            }
                //        }
                //        else // ���D�Ǖi�ɑ΂����[�U�[��ւ�����ꍇ
                //        {
                //            joinPartsRow = rowSubst;
                //        }
                //    }
                //    else // ���[�U�[��ւ��Ȃ��̏ꍇ�ŐV�i�Ԃɑ�ւ���B
                //    {
                //        joinPartsRow = rowNew;
                //    }
                //    //row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);
                //}
                # endregion

                // ��֌��̍݌Ƀ`�F�b�N
                bool stockCountNotZero;
                if ( PartsStockCheck( rowToGetInfo.JoinDestPartsNo, rowToGetInfo.JoinDestMakerCd, out stockCountNotZero ) == false ||
                     stockCountNotZero == false )
                {
                    // ���[�U�[��֋敪
                    if ( userSubstFlg != 0 )
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( joinPartsRow );
                        if ( rowSubst.Equals( joinPartsRow ) == false )
                        {
                            // ���[�U�[��֐�ɑ��
                            joinPartsRow = rowSubst;
                        }
                    }
                }
                // --- UPD m.suzuki 2011/02/02 ----------<<<<<

                dsParts.JoinPartsRow joinRow =
                    _joinParts.JoinParts.FindByJoinDestPartsNoJoinDestMakerCd(joinPartsRow.GoodsNo, joinPartsRow.GoodsMakerCd);
                //_joinParts.JoinParts.FindByJoinDestPartsNoJoinDestMakerCd(rowToGetInfo.JoinDestPartsNo, rowToGetInfo.JoinDestMakerCd);
                if (joinRow == null)
                {
                    joinRow = _joinParts.JoinParts.NewJoinPartsRow();

                    joinRow.JoinDestMakerCd = joinPartsRow.GoodsMakerCd; // rowToGetInfo.JoinDestMakerCd;
                    joinRow.JoinDestPartsNo = joinPartsRow.GoodsNo; // rowToGetInfo.JoinDestPartsNo;
                    joinRow.JoinDestOrgPrtNo = rowToGetInfo.JoinDestPartsNo;
                    // 2009.02.17 >>>
                    //joinRow.JoinDispOrder = joinPartsRow.DisplayOrder; // TODO //prmSetting.MakerDispOrder; //rowToGetInfo.JoinDispOrder;

                    joinRow.JoinDispOrder = rowToGetInfo.JoinDispOrder;
                    // 2009.02.17 <<<
                    joinRow.JoinQty = rowToGetInfo.JoinQty;
                    if (joinRow.JoinQty == 0)
                        joinRow.JoinQty = row.PartsQty;
                    //joinRow.JoinQty  = _orgDataSet.GetQty(row.MakerCd, row.ClgPrtsNo, joinRow.JoinDestMakerCd, joinRow.JoinDestPartsNo);
                    //joinRow.JoinQty = 1;
                    joinRow.JoinSourMaker = rowToGetInfo.JoinSourceMakerCode;
                    joinRow.JoinSourPartsNo = rowToGetInfo.JoinSrcPartsNoWithH;
                    joinRow.JoinSpecialNote = rowToGetInfo.JoinSpecialNote;

                    joinRow.JoinDestMakerNm = joinPartsRow.GoodsMakerNm;
                    if (joinPartsRow.GoodsName != string.Empty)
                    {
                        joinRow.PrimePartsName = joinPartsRow.GoodsName;
                    }
                    else
                    {
                        joinRow.PrimePartsName = joinPartsRow.GoodsOfrName;
                    }
                    if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                    {
                        joinRow.Price = joinPartsRow.PriceTaxInc;
                        joinRow.UriTanka = joinPartsRow.SalesUnitPriceTaxInc;
                        joinRow.GenTanka = joinPartsRow.UnitCostTaxInc;
                    }
                    else // ���z�\�����Ȃ��i�Ŕ����j
                    {
                        joinRow.Price = joinPartsRow.PriceTaxExc;
                        joinRow.UriTanka = joinPartsRow.SalesUnitPriceTaxExc;
                        joinRow.GenTanka = joinPartsRow.UnitCostTaxExc;
                    }
                    // �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
                    joinRow.Ararigaku = joinPartsRow.SalesUnitPriceTaxExc - joinPartsRow.UnitCostTaxExc;
                    if (joinPartsRow.SalesUnitPriceTaxExc != 0)
                        joinRow.Arariritu = joinRow.Ararigaku / joinPartsRow.SalesUnitPriceTaxExc;

                    joinRow.PrmSetDtlNo2 = joinPartsRow.PrmSetDtlName2;
                    //PartsInfoDataSet.JoinPartsRow[] ofrJoinPartsRow =
                    //    (PartsInfoDataSet.JoinPartsRow[])joinPartsRow.GetChildRows("UsrGoodsInfo_JoinParts");
                    //if (ofrJoinPartsRow.Length > 0)
                    //{
                    //    joinRow.PrmSetDtlNo2 = ofrJoinPartsRow[0].PrmSetDtlNo2;
                    //    joinRow.SetPartsFlg = ofrJoinPartsRow[0].SetPartsFlg;
                    //    //if (ofrJoinPartsRow[0].SetPartsFlg != 0)
                    //    //    joinRow.Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                    //}
                    //}

                    if (SubstExists(joinRow.JoinDestOrgPrtNo, joinRow.JoinDestMakerCd))
                        joinRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                    if (SetExists(joinRow.JoinDestPartsNo, joinRow.JoinDestMakerCd))
                        joinRow.Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                    //joinRow.PartsInfoRowParent = row;

                    _joinParts.JoinParts.AddJoinPartsRow(joinRow);
                }
                else
                {
                    if (joinRow.JoinSourPartsNo == _newPartsNo && rowToGetInfo.JoinSrcPartsNoWithH == _clgPartsNo)
                    {
                        // �\���p�f�[�^�e�[�u���ɍŐV�i�Ԃ��ݒ肳��Ă���ꍇ�A�J�^���O�i�Ԃ̏����Đݒ肷��
                        joinRow.JoinSourPartsNo = _clgPartsNo;
                        // --- ADD 2015/12/18 Y.Wakita ---------->>>>>
                        joinRow.JoinSpecialNote = rowToGetInfo.JoinSpecialNote;
                        // --- ADD 2015/12/18 Y.Wakita ----------<<<<<
                    }
                }

                #region [ �݌ɐݒ� ]
                //filter = string.Format("{0}={1} AND ({2}='{3}' OR {4}='{5}')",
                //            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, joinRow.JoinDestMakerCd,
                //            _orgDataSet.Stock.GoodsNoColumn.ColumnName, joinRow.JoinDestPartsNo,
                //            _orgDataSet.Stock.GoodsNoColumn.ColumnName, joinRow.JoinDestOrgPrtNo);
                filter = string.Format("{0}={1} AND {2}='{3}'",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, joinRow.JoinDestMakerCd,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName, joinRow.JoinDestPartsNo);
                stockRows = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(filter);
                flgStock = false;
                for (int j = 0; j < stockRows.Length; j++)
                {
                    if (_StockTable.FindByWarehouseCodeGoodsMakerCdGoodsNo(stockRows[j].WarehouseCode,
                            stockRows[j].GoodsMakerCd, stockRows[j].GoodsNo) == null)
                    {
                        dsParts.StockRow stockRow = _StockTable.NewStockRow();
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
                            joinRow.Shelf = stockRow.WarehouseShelfNo;
                            joinRow.StockCnt = stockRow.ShipmentPosCnt;
                            joinRow.Warehouse = stockRow.WarehouseName;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                            joinRow.WarehouseCode = stockRow.WarehouseCode;
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
                                joinRow.Shelf = stockRows[k].WarehouseShelfNo;
                                joinRow.StockCnt = stockRows[k].ShipmentPosCnt;
                                joinRow.Warehouse = stockRows[k].WarehouseName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                                joinRow.WarehouseCode = stockRows[k].WarehouseCode;
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
                //    joinRow.Shelf = stockRows[0].WarehouseShelfNo;
                //    joinRow.StockCnt = stockRows[0].ShipmentPosCnt;
                //    joinRow.Warehouse = stockRows[0].WarehouseName;
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                //    joinRow.WarehouseCode = stockRows[0].WarehouseCode;
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
                #endregion
            }
            _joinParts.AcceptChanges();///////

            // 2010/03/16 Del >>>
            #region �ʃ��\�b�h�ֈړ�����׍폜
            //gridJoinParts.DataSource = _joinParts.PartsInfo.DefaultView;

            //gridStock.DataSource = _StockTable.DefaultView;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            //SettingStockView(_StockTable.DefaultView);
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD

            //if (displayOrder == 1) // 1:�݌ɏ���
            //{
            //    //gridJoinParts.Rows[0].ChildBands[0].Band.SortedColumns.Add(_joinParts.JoinParts.StockCntColumn.ColumnName, true);
            //    gridJoinParts.DisplayLayout.Bands[1].SortedColumns.Add(_joinParts.JoinParts.StockCntColumn.ColumnName, true);
            //}
            //else
            //{
            //    gridJoinParts.DisplayLayout.Bands[1].SortedColumns.Add(_joinParts.JoinParts.JoinDispOrderColumn.ColumnName, false);
            //}

            //Infragistics.Win.Appearance app = new Infragistics.Win.Appearance();
            ////app.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //app.ForeColor = Color.Red;

            //for (int i = 0; i < gridJoinParts.Rows[0].ChildBands[0].Rows.Count; i++)
            //{
            //    string joinSrcPartsNo = gridJoinParts.Rows[0].ChildBands[0].Rows[i].Cells[_joinParts.JoinParts.JoinSourPartsNoColumn.ColumnName].Text;
            //    if (_clgPartsNo != _newPartsNo && _newPartsNo == joinSrcPartsNo)
            //    {
            //        gridJoinParts.Rows[0].ChildBands[0].Rows[i].Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Appearance = app;
            //        gridJoinParts.Rows[0].ChildBands[0].Rows[i].Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].SelectedAppearance = app;
            //    }
            //}
            #endregion
            // 2010/03/16 Del <<<
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

            //if(_joinParts.PartsInfo[0].ClgPrtsNo = _joinParts.PartsInfo[0].join
            //�������i�ݒ�
            string filter = string.Format("({0}='{1}' OR {2}='{3}') AND {4}={5}",
                        _orgUsrJoin.JoinSrcPartsNoWithHColumn.ColumnName, _clgPartsNo,
                        _orgUsrJoin.JoinSrcPartsNoWithHColumn.ColumnName, _newPartsNo,
                        _orgUsrJoin.JoinSourceMakerCodeColumn.ColumnName, _makerCd);
            PartsInfoDataSet.UsrJoinPartsRow[] rows =
                (PartsInfoDataSet.UsrJoinPartsRow[])_orgUsrJoin.Select(filter);//, _orgUsrJoin.JoinDispOrderColumn.ColumnName);
            for (int i = 0; i < rows.Length; i++)
            {
                PartsInfoDataSet.UsrJoinPartsRow rowToGetInfo = rows[i];

                PartsInfoDataSet.UsrGoodsInfoRow joinPartsRow =
                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(rowToGetInfo.JoinDestMakerCd, rowToGetInfo.JoinDestPartsNo);
                if (joinPartsRow == null) // ������Ƃ���ȃP�[�X�͂Ȃ�Ƃ����Ă���B�������E������B
                    continue;

                // --- UPD m.suzuki 2011/02/02 ---------->>>>>
                # region // DEL
                //if (substFlg != 1 || PartsStockCheck(rowToGetInfo.JoinDestPartsNo, rowToGetInfo.JoinDestMakerCd) == false)
                //{       // [��֏����F�݌ɔ���L�@���@���i�݌ɂ���̏ꍇ]�ȊO�͍ŐV�i�Ԃɑ�ւ���B
                //    PartsInfoDataSet.UsrGoodsInfoRow rowNew = _orgDataSet.GetOfrSubst(joinPartsRow);
                //    if (userSubstFlg != 0) // ���[�U�[��ւ��Ȃ��ȊO�̏ꍇ
                //    {
                //        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst(joinPartsRow);
                //        if (rowSubst.Equals(joinPartsRow)) // ���D�Ǖi�ɑ΂����[�U�[��ւ��Ȃ�
                //        {
                //            if (rowNew.Equals(joinPartsRow) == false) // �ŐV�i�Ԃ�����ꍇ
                //            {
                //                rowSubst = _orgDataSet.GetUsrSubst(rowNew);
                //                if (rowSubst.Equals(rowNew)) // �ŐV�i�ɑ΂����[�U�[��ւȂ�
                //                {
                //                    joinPartsRow = rowNew;
                //                }
                //                else // �ŐV�i�ɑ΂����[�U�[��ւ���
                //                {
                //                    joinPartsRow = rowSubst;
                //                }
                //            }
                //        }
                //        else // ���D�Ǖi�ɑ΂����[�U�[��ւ�����ꍇ
                //        {
                //            joinPartsRow = rowSubst;
                //        }
                //    }
                //    else // ���[�U�[��ւ��Ȃ��̏ꍇ�ŐV�i�Ԃɑ�ւ���B
                //    {
                //        joinPartsRow = rowNew;
                //    }
                //}
                # endregion

                // ��֌��̍݌Ƀ`�F�b�N
                bool stockCountNotZero;
                if ( PartsStockCheck( rowToGetInfo.JoinDestPartsNo, rowToGetInfo.JoinDestMakerCd, out stockCountNotZero ) == false ||
                     stockCountNotZero == false)
                {
                    // ���[�U�[��֋敪
                    if ( userSubstFlg != 0 )
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( joinPartsRow );
                        if ( rowSubst.Equals( joinPartsRow ) == false )
                        {
                            // ���[�U�[��֐�ɑ��
                            joinPartsRow = rowSubst;
                        }
                    }
                }
                // --- UPD m.suzuki 2011/02/02 ----------<<<<<

                if (joinPartsRow != null)
                {
                    goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(joinPartsRow.GoodsNo, joinPartsRow.GoodsMakerCd));
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
        /// 
        /// </summary>
        /// <returns></returns>
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

            if (_joinParts.JoinParts.Count == 0)
            {
                isDialogShown = false;
                if (uiControlFlg)
                {
                    _orgDataSet.UsrGoodsInfo.RowToProcess = _orgRow;
                    _orgDataSet.UIKind = SelectUIKind.Set;
                    return DialogResult.Retry;
                }
                else
                {
                    _orgRow.SelectionState = true;
                    return DialogResult.OK;
                }
            }

            // 2010/03/16 Add >>>
            if (_mode == 1)
            {
                isDialogShown = false;
                return DialogResult.None;
            }
            // 2010/03/16 Add <<<

            #region [ ��֑I��UI���Ə��� ]
            if (_prevRow != null && _prevRow.NewGoodsNo != string.Empty) // ��ւ��ꂽ��
            {
                if (_prevSelInfo != null)
                {
                    _prevSelInfo.ListChildGoods.Clear();
                    _prevSelInfo.ListChildGoods2.Clear();
                    if (_prevSelInfo.ListPlrlSubst.Count > 0)
                    {
                        _prevSelInfo.Selected = true;
                        _prevSelInfo.ListPlrlSubst.RemoveAt(0); // 1�ڂ͑�֕i���Ȃ̂ō폜���Ă����B
                    }
                }
                PartsInfoDataSet.UsrGoodsInfoRow newRow =
                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_prevRow.GoodsMakerCd, _prevRow.NewGoodsNo);
                //if (_joinParts.PartsInfo[0].Equals(_prevRow)) // �������ɑ΂����ւ͏o���Ȃ��悤�ɐ�������B
                //{
                //_joinParts.PartsInfo[0].OldPartsNo = _joinParts.PartsInfo[0].ClgPrtsNo;
                //_joinParts.PartsInfo[0].ClgPrtsNo = newRow.GoodsNo;
                //_joinParts.PartsInfo[0].PartsName = newRow.GoodsName;
                //_joinParts.PartsInfo[0].Price = newRow.Price;
                //}
                //else
                if (_joinParts.PartsInfo[0].Equals(_prevRow) == false) // �������i�Ԃ͑�ւ����Ȃ�
                {
                    string filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName, _prevRow.GoodsMakerCd,
                        //_joinParts.JoinParts.JoinDestOrgPrtNoColumn.ColumnName, _prevRow.GoodsNo);
                            _joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName, _prevRow.GoodsNo);
                    dsParts.JoinPartsRow oldRow = ((dsParts.JoinPartsRow[])_joinParts.JoinParts.Select(filter))[0];
                    //dsParts.JoinPartsRow oldRow =
                    //    _joinParts.JoinParts.FindByJoinDestPartsNoJoinDestMakerCd(_prevRow.GoodsNo, _prevRow.GoodsMakerCd);

                    oldRow.OldPartsNo = oldRow.JoinDestPartsNo;
                    oldRow.JoinDestPartsNo = newRow.GoodsNo;
                    oldRow.PrimePartsName = newRow.GoodsName;
                    if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                    {
                        oldRow.Price = newRow.PriceTaxInc;
                        oldRow.UriTanka = newRow.SalesUnitPriceTaxInc;
                        oldRow.GenTanka = newRow.UnitCostTaxInc;
                    }
                    else // ���z�\�����Ȃ��i�Ŕ����j
                    {
                        oldRow.Price = newRow.PriceTaxExc;
                        oldRow.UriTanka = newRow.SalesUnitPriceTaxExc;
                        oldRow.GenTanka = newRow.UnitCostTaxExc;
                    }
                    // �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
                    oldRow.Ararigaku = newRow.SalesUnitPriceTaxExc - newRow.UnitCostTaxExc;
                    if (newRow.SalesUnitPriceTaxExc != 0)
                        oldRow.Arariritu = oldRow.Ararigaku / newRow.SalesUnitPriceTaxExc;

                    oldRow.JoinSpecialNote = newRow.GoodsSpecialNote;
                    //oldRow[_joinParts.JoinParts.SubstColumn] = DBNull.Value;    // ��ւ������i�͂���ɑ�֑I��s��
                    if (SetExists(oldRow.JoinDestPartsNo, oldRow.JoinDestMakerCd))
                        oldRow.Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                    else
                        oldRow[_joinParts.JoinParts.SetColumn] = DBNull.Value;
                    filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName,
                            gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName,
                            gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value);
                    _StockTable.DefaultView.RowFilter = filter;
                    SetStockGridSelect();
                    if (gridStock.Rows.Count == 0)
                    {
                        oldRow.Shelf = string.Empty;
                        oldRow.StockCnt = 0;
                        oldRow.Warehouse = string.Empty;
                    }
                    _joinParts.JoinParts.AcceptChanges(); /////
                    //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = true;
                }
                if (_prevRow.Equals(newRow) == false)
                    _prevRow.SelectionState = false;
                _prevRow.NewGoodsNo = string.Empty;
                _prevRow = null;
                gridJoinParts_AfterSelectChange(this, null);
            }
            #endregion

            SetButtonState();

            isUserClose = true;
            //if (_orgRow.Equals(_orgDataSet.UsrGoodsInfo.RowToProcess) == false && orgRowChged == false)
            {
                InitializeTable();
            }
            _selInf = _orgDataSet.JoinSrcSelInf;
            _lstSelInf = _selInf.ListChildGoods;

            //orgRowChged = false;

            _joinParts.PartsInfo[0].SelectionState = _selInf.Selected;
            _joinParts.PartsInfo[0].WarehouseCode = _selInf.WarehouseCode;
            if (_selInf.Selected)
            {
                _joinParts.PartsInfo[0].SelImage = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
            }
            else
            {
                _joinParts.PartsInfo[0][_joinParts.PartsInfo.SelImageColumn] = DBNull.Value;
            }

            Infragistics.Win.UltraWinGrid.RowsCollection rows = gridJoinParts.Rows[0].ChildBands[0].Rows;
            int cnt = rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                if (_lstSelInf.ContainsKey(rows[i].ListIndex) && _lstSelInf[rows[i].ListIndex].Selected)
                {
                    rows[i].Cells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = true;
                    rows[i].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                }
                else
                {
                    rows[i].Cells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = false;
                    //rows[i].SelectionState = false;
                    rows[i].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                }
            }

            //for (int i = 0; i < cnt; i++)
            //{
            //    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
            //        _joinParts.JoinParts[i].JoinDestMakerCd, _joinParts.JoinParts[i].JoinDestPartsNo);
            //    if (row != null)
            //    {
            //        _joinParts.JoinParts[i].SelectionState = row.SelectionState;
            //        if (row.SelectionState)
            //        {
            //            _joinParts.JoinParts[i].SelImage = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
            //        }
            //        else
            //        {
            //            _joinParts.JoinParts[i][_joinParts.JoinParts.SelImageColumn] = DBNull.Value;
            //        }
            //    }
            //}

            if (gridJoinParts.Selected.Rows.Count > 0)
            {
                gridJoinParts.Selected.Rows[0].Activated = true;
                int makerCd;
                string goodsNo;
                if (gridJoinParts.Selected.Rows[0].Band.ParentBand == null)
                {
                    makerCd = (int)gridJoinParts.Selected.Rows[0].Cells[_joinParts.PartsInfo.MakerCdColumn.ColumnName].Value;
                    goodsNo = gridJoinParts.Selected.Rows[0].Cells[_joinParts.PartsInfo.ClgPrtsNoColumn.ColumnName].Value.ToString();
                    if (goodsNo.Equals(string.Empty)) // �{���͂����Ă͂����Ȃ��P�[�X�����A����f�[�^�̖��ɂ��A��Q���������鋰�ꂪ����B
                    {                                 // ���̃`�F�b�N�����Ŗh���B
                        goodsNo = gridJoinParts.Selected.Rows[0].Cells[_joinParts.PartsInfo.NewPrtsNoColumn.ColumnName].Value.ToString();
                    }
                }
                else
                {
                    makerCd = (int)gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value;
                    goodsNo = gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value.ToString();
                }
                PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);

                if (row.SelectionComplete)
                {
                    gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].Appearance.BackColor = Color.DarkKhaki;
                    gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].SelectedAppearance.BackColor = Color.DarkKhaki;
                    gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].SelectedAppearance.BackColor2 = Color.DarkKhaki;
                }
                else
                {
                    gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].Appearance.ResetBackColor();
                    gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].SelectedAppearance.ResetBackColor();
                    gridJoinParts.Selected.Rows[0].Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].SelectedAppearance.ResetBackColor2();
                }
            }
            else
            {
                gridJoinParts.Rows[0].Activate();
                gridJoinParts.Rows[0].Selected = true;
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
            gridJoinParts.UpdateData();
            // 2009.02.19 >>>
            //return base.ShowDialog();
            return base.ShowDialog(owner);
            // 2009.02.19 <<<
        }

        #region [ �`�F�b�N���� ]
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
        #endregion

        #region internal[2007]
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
                return;
            }

            //_orgRow.SelectionState = _joinParts.PartsInfo[0].SelectionState;
            //if (uiControlFlg && _joinParts.PartsInfo[0].SelImage.Equals(DBNull.Value) == false)
            if (uiControlFlg) // PM.NS������
            {
                if (_joinParts.PartsInfo[0][_joinParts.PartsInfo.SelImageColumn.ColumnName].Equals(DBNull.Value) == false)
                    _selInf.Selected = true;
                if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Equals(gridJoinParts.Rows[0]))
                {
                    if (_orgDataSet.UIKind == SelectUIKind.Set)
                    {
                        _selInf.JoinSet = true;
                        _orgDataSet.SetSrcSelInf = _selInf;
                        _prevSelInfo = _selInf;
                    }
                    //if (_orgDataSet.UIKind == SelectUIKind.Subst) // �������i�Ɋւ��Ă͑�ւȂ�
                    //{
                    //    _orgDataSet.SubstSrcSelInf = _selInf;
                    //    _prevSelInfo = _selInf;
                    //}
                }
            }
            else�@// PM7������
            {
                if (_joinParts.PartsInfo[0][_joinParts.PartsInfo.SelImageColumn.ColumnName].Equals(DBNull.Value) == false)
                {
                    _selInf.JoinSet = true;
                    //if (_orgDataSet.UIKind == SelectUIKind.Subst)
                    //{
                    //    _orgDataSet.SubstSrcSelInf = _selInf;
                    //    _prevSelInfo = _selInf;
                    //}
                }

                //if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Equals(gridJoinParts.Rows[0]))
                //{
                //    _selInf.JoinSet = true;
                //    if (enterFlg == 0 || enterFlg == 2) // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
                //        _selInf.Selected = false;
                //    else if (_joinParts.PartsInfo[0][_joinParts.PartsInfo.SelImageColumn.ColumnName].Equals(DBNull.Value) == false)
                //        _selInf.Selected = true;
                //}
                //else
                //{
                //    if (_joinParts.PartsInfo[0][_joinParts.PartsInfo.SelImageColumn.ColumnName].Equals(DBNull.Value) == false)
                //    {
                //        _selInf.JoinSet = true;
                //        _selInf.Selected = true;
                //    }
                //}
            }
            if (_joinParts.PartsInfo[0].SelectionState)
            {
                _selInf.RowGoods.QTY = _joinParts.PartsInfo[0].PartsQty;
                _selInf.RowGoods.GoodsKindResolved = (int)GoodsKind.Parent;
                _selInf.WarehouseCode = _joinParts.PartsInfo[0].WarehouseCode;
            }

            Infragistics.Win.UltraWinGrid.RowsCollection rows = gridJoinParts.Rows[0].ChildBands[0].Rows;
            int cnt = rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                UltraGridRow gridRow = rows[i];
                if (gridRow.Cells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value.Equals(true))
                {
                    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                        (int)gridRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value,
                        gridRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value.ToString());
                    //_joinParts.JoinParts[i].JoinDestMakerCd,
                    //_joinParts.JoinParts[i].JoinDestPartsNo);
                    if (row != null)
                    {
                        //>>>2010/12/09 �\�����F�݌ɏ��ɂ����ꍇ�AQTY������ɃZ�b�g����Ȃ����̑Ή�
                        //row.QTY = _joinParts.JoinParts[i].JoinQty;
                        row.QTY = (double)gridRow.Cells[_joinParts.JoinParts.JoinQtyColumn.ColumnName].Value;
                        //<<<2010/12/09 �\�����F�݌ɏ��ɂ����ꍇ�AQTY������ɃZ�b�g����Ȃ����̑Ή�
                        row.GoodsKindResolved = (int)GoodsKind.Join;

                        SelectionInfo selInfo = new SelectionInfo();
                        selInfo.Depth = 1;
                        selInfo.Key = gridRow.ListIndex;
                        selInfo.RowGoods = row;
                        selInfo.WarehouseCode = gridRow.Cells[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Value.ToString();
                        if (uiControlFlg) // PM.NS������
                        {
                            if (gridRow.Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                                selInfo.Selected = true;
                            if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Index == i)
                            {
                                if (_orgDataSet.UIKind == SelectUIKind.Set)
                                {
                                    _orgDataSet.SetSrcSelInf = selInfo;
                                    _prevSelInfo = selInfo;
                                }
                            }
                        }
                        if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Index == i
                            && _orgDataSet.UIKind == SelectUIKind.Subst)
                        {
                            _orgDataSet.SubstSrcSelInf = selInfo;
                            _prevSelInfo = selInfo;
                        }
                        //else�@// PM7������
                        //{
                        //    if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Index == i)
                        //    {
                        //        if (enterFlg == 0 || enterFlg == 2) // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
                        //            selInfo.Selected = false;
                        //        else if (gridRow.Cells[_joinParts.JoinParts.SetColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                        //            selInfo.Selected = true;
                        //    }
                        //    else
                        //    {
                        //        if (gridRow.Cells[_joinParts.JoinParts.SetColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                        //            selInfo.Selected = true;
                        //    }
                        //}
                        _orgDataSet.AddSelectionInfo(_lstSelInf, gridRow.ListIndex, ref selInfo);
                        //if (_orgDataSet.UsrGoodsInfo.RowToProcess.Equals(row))                        
                    }
                }
                else
                {
                    _orgDataSet.RemoveSelectionInfo(_lstSelInf, gridRow.ListIndex);
                }
            }

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
                isUserClose = false;
            }
        }

        /// <summary>
        /// FormClosing �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// </remarks>
        private void SelectionForm_FormClosing(object sender, FormClosingEventArgs e)
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
            UltraGridRow activeRow = gridJoinParts.ActiveRow;
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
                        // UPD 2013/01/11 2013/03/13�z�M�\�� SCM��Q��10462�Ή� ---------------------------->>>>>
                        //if (uiControlFlg == false && _joinParts.PartsInfo[0].SelectionState == false
                        //   && _joinParts.JoinParts.Select("SelectionState = true").Length == 0)
                        //{
                        //    SetStatusBarText(1, "�f�[�^�̑I��������Ă��܂���B");
                        //    break;
                        //}
                        //DialogResult = DialogResult.OK;
                        SetSelect(true);
                        // UPD 2013/01/11 2013/03/13�z�M�\�� SCM��Q��10462�Ή� ----------------------------<<<<<
                    }
                    isUserClose = false;
                    break;

                case "Button_Back":
                    // �O�̉�ʂɖ߂�                    
                    DialogResult = DialogResult.Cancel;
                    isUserClose = false;
                    break;

                case "Button_Subst":
                    if (activeRow != null)
                    {
                        if (activeRow.Cells[_joinParts.JoinParts.SubstColumn.ColumnName].Value != DBNull.Value)
                        {
                            int makerCd;
                            string partsNo;
                            if (activeRow.Band.ParentBand == null) // �e�o���h�̏ꍇ
                            {
                                makerCd = (int)activeRow.Cells[_joinParts.PartsInfo.MakerCdColumn.ColumnName].Value;
                                partsNo = activeRow.Cells[_joinParts.PartsInfo.ClgPrtsNoColumn.ColumnName].Value.ToString();
                            }
                            else
                            {
                                makerCd = (int)activeRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value;
                                partsNo = activeRow.Cells[_joinParts.JoinParts.JoinDestOrgPrtNoColumn.ColumnName].Value.ToString();
                            }
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                if (row.SelectionComplete)
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Text,
                                        "�Z�b�g�I��UI�őI���������ڂ����邽�߁A��֏o���܂���B", 0,
                                        MessageBoxButtons.OK);
                                }
                                else
                                {
                                    //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                    activeRow.Cells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = true;
                                    _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                    //_prevRow = row;
                                    _prevRow = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd,
                                        activeRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value.ToString());
                                    _orgDataSet.UIKind = SelectUIKind.Subst;
                                    DialogResult = DialogResult.Retry;
                                    isUserClose = false;
                                }
                            }
                        }
                    }
                    break;

                case "Button_Set":
                    // �Z�b�g������ꍇ�Z�b�g�I��UI�\��
                    if (uiControlFlg && activeRow != null)
                    {
                        if (activeRow.Cells[_joinParts.JoinParts.SetColumn.ColumnName].Value != DBNull.Value)
                        {
                            isUserClose = false;
                            int makerCd;
                            string partsNo;
                            if (activeRow.Band.ParentBand == null) // �e�o���h�̏ꍇ
                            {
                                makerCd = (int)activeRow.Cells[_joinParts.PartsInfo.MakerCdColumn.ColumnName].Value;
                                //partsNo = activeRow.Cells[_joinParts.PartsInfo.ClgPrtsNoColumn.ColumnName].Value.ToString();
                                partsNo = activeRow.Cells[_joinParts.PartsInfo.NewPrtsNoColumn.ColumnName].Value.ToString();
                            }
                            else
                            {
                                makerCd = (int)activeRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value;
                                partsNo = activeRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value.ToString();
                            }
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                activeRow.Cells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                _orgDataSet.UIKind = SelectUIKind.Set;
                                DialogResult = DialogResult.Retry;
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
                    if (activeRow != null &&
                        activeRow.Cells[_joinParts.JoinParts.OldPartsNoColumn.ColumnName].Value.Equals(string.Empty) == false)
                    {
                        int makerCd = (int)activeRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value;
                        string partsNo = activeRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value.ToString();
                        string oldPartsNo = activeRow.Cells[_joinParts.JoinParts.OldPartsNoColumn.ColumnName].Value.ToString();
                        string joinDestPrtNo = activeRow.Cells[_joinParts.JoinParts.JoinDestOrgPrtNoColumn.ColumnName].Value.ToString();
                        dsParts.JoinPartsRow oldRow = _joinParts.JoinParts.FindByJoinDestPartsNoJoinDestMakerCd(partsNo, makerCd); // TODO : ������
                        PartsInfoDataSet.UsrGoodsInfoRow newRow =
                            _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, oldPartsNo);

                        oldRow.OldPartsNo = string.Empty;
                        oldRow.JoinDestPartsNo = newRow.GoodsNo;
                        oldRow.PrimePartsName = newRow.GoodsName;
                        oldRow.Price = newRow.Price;
                        oldRow.GenTanka = newRow.UnitCost;
                        oldRow.UriTanka = newRow.SalesUnitPrice;
                        oldRow.Ararigaku = newRow.SalesUnitPrice - newRow.UnitCost;
                        if (newRow.UnitCost != 0)
                            oldRow.Arariritu = oldRow.Ararigaku / newRow.UnitCost;
                        if (SubstExists(joinDestPrtNo, makerCd))
                        {
                            oldRow.Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                        }
                        if (SetExists(oldRow.JoinDestPartsNo, oldRow.JoinDestMakerCd))
                            oldRow.Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                        else
                            oldRow[_joinParts.JoinParts.SetColumn] = DBNull.Value;
                        string filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName,
                            activeRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName,
                            activeRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value);
                        _StockTable.DefaultView.RowFilter = filter;
                        SetStockGridSelect();
                        if (gridStock.Rows.Count == 0)
                        {
                            oldRow.Shelf = string.Empty;
                            oldRow.StockCnt = 0;
                            oldRow.Warehouse = string.Empty;
                        }

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
                        //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
                        gridJoinParts_AfterSelectChange(this, null);
                    }
                    break;*/
            }
        }

        // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- >>>
        /// <summary>
        /// �ԗ�����\���ؑ֏���
        /// </summary>
        private void SetPnlCarInfoVisible(bool carInfoVisible)
        {
            if (carInfoVisible)
            {
                this.gridJoinParts.Location = new System.Drawing.Point(0, this.pnl_CarInfo.Height);
                // --- ADD 2014/11/04 T.Miyamoto �d�|�ꗗ ��2577 ------------------------------>>>>>
                this.gridJoinParts.Height = this.SelectionForm_Fill_Panel.Height - this.pnl_CarInfo.Height;
                // --- ADD 2014/11/04 T.Miyamoto �d�|�ꗗ ��2577 ------------------------------<<<<<
            }
            else
            {
                this.gridJoinParts.Location = new System.Drawing.Point(0, 0);
                // --- UPD 2014/11/04 T.Miyamoto �d�|�ꗗ ��2577 ------------------------------>>>>>
                //this.gridJoinParts.Height = this.gridJoinParts.Height + this.pnl_CarInfo.Height;
                this.gridJoinParts.Height = this.SelectionForm_Fill_Panel.Height;
                // --- UPD 2014/11/04 T.Miyamoto �d�|�ꗗ ��2577 ------------------------------<<<<<
            }
        }
        // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- <<<

        private void SetButtonState()
        {
            bool ena = false;
            bool enaSubst = false;
            try
            {
                if (gridJoinParts.ActiveRow == null)
                    return;
                ena = (gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.SetColumn.ColumnName].Value != System.DBNull.Value);
                if (gridJoinParts.ActiveRow.Band.ParentBand != null)
                {
                    enaSubst = (gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.SubstColumn.ColumnName].Value != System.DBNull.Value);
                }
            }
            finally
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.Enabled = ena;
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled = enaSubst;
            }
        }
        #endregion

        #region [ �O���b�h�C�x���g���� ]
        /// <summary>
        /// �A�N�e�B�u�s�ύX��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridJoinParts_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            string filter = string.Empty;
            try
            {
                if (gridJoinParts.Selected.Rows.Count == 0)
                    return;
                if (gridJoinParts.Selected.Rows[0].Activated == false)
                    gridJoinParts.Selected.Rows[0].Activate();
                if (gridJoinParts.ActiveRow.Band.ParentBand == null)
                {
                    filter = string.Format("{0}={1} AND ({2}='{3}' OR {4}='{5}')",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, _makerCd,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName, _clgPartsNo,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName, _newPartsNo);
                    //gridJoinParts.DisplayLayout.Bands[1].Columns[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].
                    //    Header.Caption = "�ŐV�i��";
                }
                else
                {
                    filter = string.Format("{0}={1} AND {2}='{3}' ",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName,
                            gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName,
                            gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value);
                    //gridJoinParts.DisplayLayout.Bands[1].Columns[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].
                    //    Header.Caption = "�D�Ǖi��";
                }
                SetButtonState();
            }
            finally
            {
                _StockTable.DefaultView.RowFilter = filter;
            }

            SetStockGridSelect();

            if (gridJoinParts.ActiveRow.Band.ParentBand != null)
            {
                string joinSrcPartsNo = gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.JoinSourPartsNoColumn.ColumnName].Text;
                if (_clgPartsNo != _newPartsNo && joinSrcPartsNo == _newPartsNo)
                {
                    SetStatusBarText(1, "���i���[�J�[�Ɋm�F�̏�A���g�p�������B");
                }
                else
                {
                    SetStatusBarText(0, string.Empty);
                }
            }
            else
            {
                SetStatusBarText(0, string.Empty);
            }
        }

        /// <summary>
        /// InitializeLayout �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�O���b�h�̃��C�A�E�g����������</br>
        /// </remarks>
        private void gridJoinParts_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // �񕝂̎����������@
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            gridJoinParts.DisplayLayout.InterBandSpacing = 3;

            #region �����O���b�h�i�o���h�O�j�̐ݒ�
            // �o���h�̎擾
            UltraGridBand band0 = e.Layout.Bands[0];
            //band0.Override.HeaderPlacement = HeaderPlacement.FixedOnTop;
            band0.UseRowLayout = true;
            band0.Indentation = 0;

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
            band0.Columns[_joinParts.PartsInfo.SelectionStateColumn.ColumnName].Hidden = true;
            band0.Columns[_joinParts.PartsInfo.StandardNameColumn.ColumnName].Hidden = true;
            band0.Columns[_joinParts.PartsInfo.OldPartsNoColumn.ColumnName].Hidden = true;
            band0.Columns[_joinParts.PartsInfo.WarehouseCodeColumn.ColumnName].Hidden = true;
            if (substFlg == 0) // �u��ւ��Ȃ��v�͑�փJ������\�����Ȃ��B
            {
                band0.Columns[_joinParts.PartsInfo.SubstColumn.ColumnName].Hidden = true;
            }
            //�Q�i
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.SelImageColumn.ColumnName, 2, 0, 1, 4, 16);

            //��i
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.MakerCdColumn.ColumnName, 3, 0, 3, 2, 25);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.MakerNameColumn.ColumnName, 6, 0, 10, 2, 95);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.PartsNameColumn.ColumnName, 16, 0, 14, 2, 140);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.WarehouseColumn.ColumnName, 30, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.PrmSetDtlNo2Column.ColumnName, 34, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.PartsQtyColumn.ColumnName, 38, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.GenTankaColumn.ColumnName, 42, 0, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.ArarirituColumn.ColumnName, 46, 0, 4, 2, 40);

            //���i
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.PartsOpNmColumn.ColumnName, 3, 2, 13, 2, 130);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.ClgPrtsNoColumn.ColumnName, 16, 2, 7, 2, 70);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.NewPrtsNoColumn.ColumnName, 23, 2, 7, 2, 70);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.ShelfColumn.ColumnName, 30, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.StockCntColumn.ColumnName, 34, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.PriceColumn.ColumnName, 38, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.UriTankaColumn.ColumnName, 42, 2, 4, 2, 40);
            ColInfo.SetColInfo(band0, _joinParts.PartsInfo.ArarigakuColumn.ColumnName, 46, 2, 4, 2, 40);
            if (substFlg == 0) // �u��ւ��Ȃ��v�͑�փJ������\�����Ȃ��B
            {
                ColInfo.SetColInfo(band0, _joinParts.PartsInfo.SetColumn.ColumnName, 50, 0, 1, 4, 14);
            }
            else
            {
                ColInfo.SetColInfo(band0, _joinParts.PartsInfo.SubstColumn.ColumnName, 50, 0, 1, 4, 13);
                ColInfo.SetColInfo(band0, _joinParts.PartsInfo.SetColumn.ColumnName, 51, 0, 1, 4, 13);
            }

            band0.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;
            band0.Columns[_joinParts.PartsInfo.MakerCdColumn.ColumnName].Format = "0000";
            band0.Columns[_joinParts.PartsInfo.PriceColumn.ColumnName].Format = "C";
            band0.Columns[_joinParts.PartsInfo.GenTankaColumn.ColumnName].Format = "C";
            band0.Columns[_joinParts.PartsInfo.UriTankaColumn.ColumnName].Format = "C";
            band0.Columns[_joinParts.PartsInfo.ArarigakuColumn.ColumnName].Format = "C";
            band0.Columns[_joinParts.PartsInfo.ArarirituColumn.ColumnName].Format = "#%";
            band0.Columns[_joinParts.PartsInfo.StockCntColumn.ColumnName].Format = "###,###,##0.00";
            band0.Columns[_joinParts.PartsInfo.PartsQtyColumn.ColumnName].Format = "###,###,##0.00";
            #endregion

            UltraGridBand band1 = e.Layout.Bands[1];
            //band1.ColHeadersVisible = false;
            band1.Override.HeaderPlacement = HeaderPlacement.FixedOnTop;
            band0.ColHeadersVisible = false;
            band1.UseRowLayout = true;
            band1.Indentation = 0;

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
            band1.Columns[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Hidden = true;
            band1.Columns[_joinParts.JoinParts.JoinSourMakerColumn.ColumnName].Hidden = true;
            band1.Columns[_joinParts.JoinParts.SetPartsFlgColumn.ColumnName].Hidden = true;
            band1.Columns[_joinParts.JoinParts.JoinDispOrderColumn.ColumnName].Hidden = true;
            band1.Columns[_joinParts.JoinParts.OldPartsNoColumn.ColumnName].Hidden = true;
            band1.Columns[_joinParts.JoinParts.JoinDestOrgPrtNoColumn.ColumnName].Hidden = true;
            band1.Columns[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Hidden = true;
            band1.Columns[_joinParts.JoinParts.PrimeDispOrderColumn.ColumnName].Hidden = true;  // 2009.02.17 Add
            band1.Columns[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            if (substFlg == 0) // �u��ւ��Ȃ��v�͑�փJ������\�����Ȃ��B
            {
                band1.Columns[_joinParts.JoinParts.SubstColumn.ColumnName].Hidden = true;
            }

            //�Q�i
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.SelImageColumn.ColumnName, 2, 0, 1, 4, 16);

            //��i
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName, 3, 0, 3, 2, 25);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.JoinDestMakerNmColumn.ColumnName, 6, 0, 10, 2, 95);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.PrimePartsNameColumn.ColumnName, 16, 0, 14, 2, 140);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.WarehouseColumn.ColumnName, 30, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.PrmSetDtlNo2Column.ColumnName, 34, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.JoinQtyColumn.ColumnName, 38, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.GenTankaColumn.ColumnName, 42, 0, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.ArarirituColumn.ColumnName, 46, 0, 4, 2, 40);

            //���i
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.JoinSpecialNoteColumn.ColumnName, 3, 2, 13, 2, 130);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.JoinSourPartsNoColumn.ColumnName, 16, 2, 7, 2, 70);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName, 23, 2, 7, 2, 70);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.ShelfColumn.ColumnName, 30, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.StockCntColumn.ColumnName, 34, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.PriceColumn.ColumnName, 38, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.UriTankaColumn.ColumnName, 42, 2, 4, 2, 40);
            ColInfo.SetColInfo(band1, _joinParts.JoinParts.ArarigakuColumn.ColumnName, 46, 2, 4, 2, 40);

            if (substFlg == 0) // �u��ւ��Ȃ��v�͑�փJ������\�����Ȃ��B
            {
                ColInfo.SetColInfo(band1, _joinParts.PartsInfo.SetColumn.ColumnName, 50, 0, 1, 4, 14);
            }
            else
            {
                ColInfo.SetColInfo(band1, _joinParts.PartsInfo.SubstColumn.ColumnName, 50, 0, 1, 4, 13);
                ColInfo.SetColInfo(band1, _joinParts.PartsInfo.SetColumn.ColumnName, 51, 0, 1, 4, 13);
            }

            band1.Columns[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Format = "0000";
            band1.Columns[_joinParts.JoinParts.PriceColumn.ColumnName].Format = "C";
            band1.Columns[_joinParts.JoinParts.GenTankaColumn.ColumnName].Format = "C";
            band1.Columns[_joinParts.JoinParts.UriTankaColumn.ColumnName].Format = "C";
            band1.Columns[_joinParts.JoinParts.ArarigakuColumn.ColumnName].Format = "C";
            band1.Columns[_joinParts.JoinParts.ArarirituColumn.ColumnName].Format = "#%";
            band1.Columns[_joinParts.JoinParts.StockCntColumn.ColumnName].Format = "###,###,##0.00";
            band1.Columns[_joinParts.JoinParts.JoinQtyColumn.ColumnName].Format = "###,###,##0.00";
        }

        /// <summary>
        /// �s���_�u���N���b�N���ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// �f�[�^���\������Ă��Ȃ��s���_�u���N���b�N���Ă��{�C�x���g�͔������Ȃ��B
        /// </remarks>
        private void gridJoinParts_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SetSelect(false);
        }

        /// <summary>
        /// �O���b�h���Enter�L�[�������ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridJoinParts_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Band.ParentBand == null) // �e�o���h��
                    {
                        gridJoinParts.ActiveRow.ChildBands[0].Rows[0].Activate();
                        gridJoinParts.ActiveRow.Selected = true;
                        e.Handled = true;
                    }
                    break;

                case Keys.Up:
                    if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Band.ParentBand != null // �q�o���h��
                        && gridJoinParts.ActiveRow.Index == 0)
                    {
                        //gridJoinParts.ActiveRow.ParentRow.Activate();
                        gridJoinParts.Rows[0].Activate();
                        gridJoinParts.ActiveRow.Selected = true;
                        e.Handled = true;
                    }
                    break;

                case Keys.Enter:
                    SetSelect(true);
                    break;

                case Keys.PageDown:
                    if (gridJoinParts.ActiveRow != null && gridJoinParts.ActiveRow.Band.ParentBand == null)
                    {
                        gridJoinParts.ActiveRow.ChildBands[0].Rows[0].Activate();
                        gridJoinParts.ActiveRow.Selected = true;
                        gridJoinParts_KeyDown(sender, e);
                    }
                    break;

            }
        }

        //private void gridJoinParts_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
        //{
        //    if (e.Element != null)
        //    {
        //        System.Diagnostics.Trace.WriteLine(e.Element.ToString());
        //        string tmp = string.Format("X=[{0}] Y=[{1}] TOP=[{2}] BOTTOM[{3}]", e.Element.Rect.X, e.Element.Rect.Y, e.Element.Rect.Top, e.Element.Rect.Bottom);

        //        System.Diagnostics.Trace.WriteLine(tmp);

        //        if (e.Element.Equals(gridJoinParts.Rows[0].ChildBands[0].Rows[0].Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].GetUIElement()))
        //            System.Diagnostics.Trace.WriteLine("�D�Ǖi��");
        //    }
        //    else
        //        System.Diagnostics.Trace.WriteLine("Element Null");
        //}

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

        /// <summary>
        /// �݌ɏ��I�𔽉f
        /// </summary>
        /// <remarks>�݌ɏ���I������ƕ��i���̍݌ɏ����X�V����</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //if (gridStock.ActiveRow != null && gridJoinParts.ActiveRow != null)// && gridJoinParts.ActiveRow.Band.ParentBand != null)
            //{
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.ShelfColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.StockCntColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
            //    gridStock.ActiveRow.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
            //    gridJoinParts.UpdateData();
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
                if ( gridJoinParts.ActiveRow != null )
                {
                    if ( (bool)activeCells[_StockTable.SelectionStateColumn.ColumnName].Value == true )
                    {
                        // ���i�O���b�h�ɍ݌ɏ��\��
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.ShelfColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.StockCntColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
                    }
                    else
                    {
                        // ���i�O���b�h�̍݌ɏ����N���A
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseColumn.ColumnName].Value = string.Empty;
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.ShelfColumn.ColumnName].Value = string.Empty;
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.StockCntColumn.ColumnName].Value = 0;
                        gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Value = string.Empty;
                    }
                    gridJoinParts.UpdateData();
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
        /// �݌ɃO���b�h�I�������i���[�U�[�I�����D��q�Ɂ��擪�s�̏��őI���j
        /// </summary>
        private void SetStockGridSelect()
        {
            if (gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Value.Equals(string.Empty) == false)
            {
                for (int i = 0; i < gridStock.Rows.Count; i++)
                {
                    if (gridStock.Rows[i].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value
                        .Equals(gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Value))
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
                // �Y���Ȃ��̏ꍇ�͐擪�s�Ƀt�H�[�J�X�̂݃Z�b�g
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
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseColumn.ColumnName].Value = string.Empty;
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.ShelfColumn.ColumnName].Value = string.Empty;
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.StockCntColumn.ColumnName].Value = 0;
            //    gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.WarehouseCodeColumn.ColumnName].Value = string.Empty;
            //    gridJoinParts.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
        }

        /// <summary>
        /// Enter�L�[(�_�u���N���b�N)�ɂ��I������
        /// </summary>
        /// <param name="moveFlg">true:���̍s��I����ԂɁ^false:�Ȃɂ����Ȃ��i�}�E�X�_�u���N���b�N���j</param>
        private void SetSelect(bool moveFlg)
        {
            UltraGridRow activeRow = gridJoinParts.ActiveRow;
            if (activeRow != null)
            {
                CellsCollection activeCells = activeRow.Cells;
                if (uiControlFlg == false || enterFlg == 1) // PM7�����䖔��Enter�L�[���u�I���v��
                {
                    if (activeCells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value != DBNull.Value)
                    {
                        activeCells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                        activeCells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = false;
                        if (activeRow.ParentRow == null) // �������i(�e�o���h)��
                        {
                            _selInf.Selected = false;
                            //_selInf.ListChildGoods.Clear();  // �I���������镔�i�̌�����Ȃǂ̑I����ԉ���
                            _selInf.ListChildGoods2.Clear();
                            _selInf.ListPlrlSubst.Clear();
                        }
                        else  // ������i(�q�o���h)��
                        {
                            if (_lstSelInf.ContainsKey(activeRow.ListIndex)) // �I���������镔�i�̌�����Ȃǂ̑I����ԉ���
                            {
                                _lstSelInf.Remove(activeRow.ListIndex);
                            }
                        }
                    }
                    else
                    {
                        activeCells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                        activeCells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = true;
                    }
                }
                if (enterFlg == 0 || enterFlg == 2) // �G�����[�L�[��[PM7]����[�����]�̏ꍇ
                {
                    if (gridJoinParts.Rows[0].Equals(activeRow) == false
                        && gridJoinParts.Rows[0].Cells[_joinParts.PartsInfo.SelImageColumn.ColumnName].Value != DBNull.Value)
                    {
                        gridJoinParts.Rows[0].Cells[_joinParts.PartsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
                        gridJoinParts.Rows[0].Cells[_joinParts.PartsInfo.SelectionStateColumn.ColumnName].Value = false;
                        _selInf.Selected = false;
                        //_selInf.ListChildGoods.Clear();  // �I���������镔�i�̌�����Ȃǂ̑I����ԉ���
                        _selInf.ListChildGoods2.Clear();
                        _selInf.ListPlrlSubst.Clear();
                    }
                    foreach (UltraGridRow row in gridJoinParts.Rows[0].ChildBands[0].Rows) // �I���s�ȊO�͑I����������
                    {
                        if (row.Equals(activeRow) == false && row.Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value != DBNull.Value)
                        {
                            row.Cells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value = DBNull.Value;
                            row.Cells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = false;
                            if (_lstSelInf.ContainsKey(row.ListIndex))
                            {
                                _lstSelInf.Remove(row.ListIndex);
                            }
                        }
                    }
                }
                switch (enterFlg) // �G���^�[�L�[�����敪
                {
                    case 1: // Enter�L�[���u�I���v�̏ꍇ�F�����I�𓮍�̂��ߎ��s��I����ԂƂ���B
                        if (moveFlg) // �}�E�X�_�u���N���b�N�ɂ��ꍇ�͈ȉ��̏������Ȃ��B
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
                    case 0: // Enter�L�[���uPM7�v�̏ꍇ(�����I��UI�ɂ́uPM7�v�Ɓu����ʁv�͓���)
                    case 2: // Enter�L�[���u����ʁv�̏ꍇ
                        if (uiControlFlg)
                        {
                            if (activeCells[_joinParts.JoinParts.SetColumn.ColumnName].Value != DBNull.Value) // �Z�b�g��񂠂�
                            {
                                int makerCd;
                                string partsNo;
                                if (gridJoinParts.ActiveRow.Band.ParentBand == null) // �e�o���h�̏ꍇ
                                {
                                    makerCd = (int)gridJoinParts.ActiveRow.Cells[_joinParts.PartsInfo.MakerCdColumn.ColumnName].Value;
                                    //partsNo = gridJoinParts.ActiveRow.Cells[_joinParts.PartsInfo.ClgPrtsNoColumn.ColumnName].Value.ToString();
                                    partsNo = activeRow.Cells[_joinParts.PartsInfo.NewPrtsNoColumn.ColumnName].Value.ToString();
                                }
                                else
                                {
                                    makerCd = (int)gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.JoinDestMakerCdColumn.ColumnName].Value;
                                    partsNo = gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.JoinDestPartsNoColumn.ColumnName].Value.ToString();
                                }
                                PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                                gridJoinParts.ActiveRow.Cells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                _orgDataSet.UIKind = SelectUIKind.Set;
                                DialogResult = DialogResult.Retry; // ����ʂ��聨�I���Ȃ��Ŏ���ʊJ���B
                            }
                            else // �Z�b�g���Ȃ�
                            {
                                activeCells[_joinParts.JoinParts.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                                activeCells[_joinParts.JoinParts.SelectionStateColumn.ColumnName].Value = true; // ����ʂ��Ȃ��ꍇ�I�����I��
                                if (enterFlg == 2)
                                    DialogResult = DialogResult.Ignore; // �c��̉�ʂ𖳎����I���m�肷��B
                                else // 
                                    DialogResult = DialogResult.OK; // ���i�I��UI�֖߂�B
                            }
                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                        }
                        break;

                }
                gridJoinParts.UpdateData();
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

        // 2010/03/16 Add >>>
        /// <summary>
        /// �e�[�u���쐬�y�уf�[�^�Z�b�g�ւ̒ǉ��A�����[�V�����ݒ�
        /// </summary>
        private void InitializeTable2()
        {
            _orgRow = _orgDataSet.UsrGoodsInfo.RowToProcess;

            // �������i���擾����
            PartsInfoDataSet.PartsInfoRow[] childRows = (PartsInfoDataSet.PartsInfoRow[])_orgRow.GetChildRows("UsrGoodsInfo_PartsInfo");
            if (childRows.Length > 0)
            {
                _partsInfoRow = childRows[0];
            }
            _clgPartsNo = _orgRow.GoodsNo;
            if (_orgRow.NewGoodsNo == string.Empty)
                _newPartsNo = _clgPartsNo;
            else
                _newPartsNo = _orgRow.NewGoodsNo;
            _makerCd = _orgRow.GoodsMakerCd;

            // �ŐV�i�Ԃ̏��ݒ�
            _newPartsRow = ( _newPartsNo != _clgPartsNo ) ? _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_makerCd, _newPartsNo) : _newPartsRow = _orgRow;

            // �ʏ킠�肦�Ȃ�
            if (_newPartsRow == null) _newPartsRow = _orgRow;
            InitializeData(false);
        }

        /// <summary>
        /// �����S�I��
        /// </summary>
        public void SelectAllJoinParts()
        {
            _selInf = _orgDataSet.JoinSrcSelInf;
            _lstSelInf = _selInf.ListChildGoods;

            dsParts.JoinPartsRow[] rows = (dsParts.JoinPartsRow[])_joinParts.PartsInfo[0].GetChildRows("PartsInfo_JoinParts");
            if (rows != null && rows.Length > 0)
            {
                int index =1;
                foreach (dsParts.JoinPartsRow joinrow in rows)
                {

                    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                        joinrow.JoinDestMakerCd, joinrow.JoinDestPartsNo);
                    if (row != null)
                    {
                        row.QTY = joinrow.JoinQty;
                        row.GoodsKindResolved = (int)GoodsKind.Join;
                        row.SelectionState = true;

                        SelectionInfo selInfo = new SelectionInfo();
                        selInfo.Depth = 1;
                        selInfo.Key = index;
                        selInfo.RowGoods = row;
                        selInfo.WarehouseCode = joinrow.WarehouseCode;
                        selInfo.Selected = true;

                        //_orgDataSet.AddSelectionInfo(_lstSelInf, index, ref selInfo);
                        _orgDataSet.AddSelectionInfo(_lstSelInf, index, ref selInfo);
                        index++;
                    }
                }

            }
        }
        // 2010/03/16 Add <<<
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
                // �����I�Ɍ������i�O���b�h�Ɉړ�
                gridJoinParts.Focus();
            }
        }
        // --- ADD m.suzuki 2010/10/26 ----------<<<<<

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