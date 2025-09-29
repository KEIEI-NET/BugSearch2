//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�݌Ɉꊇ�o�^�C��
// �v���O�����T�v   : ���i�݌ɂ̈ꊇ�o�^�E�ꊇ�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �� �� ��  2008/12/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/02/02  �C�����e : �r�����䏈���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/02/23  �C�����e : ��Q�Ή�10766 �����s�I��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/03/02  �C�����e : ��Q�Ή�12082,12072,12087,12076
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/03/03  �C�����e : ��Q�Ή�12104,12103,12081,12074,12075
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/03/03  �C�����e : ��Q�Ή�12084
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/03/05  �C�����e : ��Q�Ή�12072,12085
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/03/05  �C�����e : ��Q�Ή�12082,12070,12132,12073,12205
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/03/10  �C�����e : ��Q�Ή�12080
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/03/10  �C�����e : ��Q�Ή�12223
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/06  �C�����e : ��Q�Ή�13112
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2010/06/08  �C�����e : ��Q�E���ǑΉ��i�V�������[�X�Č��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2010/08/11  �C�����e : ��Q���ǑΉ��i�W�����j �L�[�{�[�h����̉��ǂ��s���B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : yangmj
// �� �� ��  2012/09/11  �C�����e : ��Q�E���ǑΉ� Redmine#32095 ���i�݌Ɉꊇ�o�^�C���Łu�S�Ẳ��i��񂪏�����v
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �{�{
// �� �� ��  2012/10/05  �C�����e : ��Q�E���ǑΉ� �ړ����擾�֐��C��(��ړ����̑Ή�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : yangyi
// �� �� ��  2013/05/11  �C�����e : 20150515�z�M��
//                                  Redmine#35018 �u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���@���̂Q�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�݌Ɉꊇ�o�^�C���R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�݌Ɉꊇ�o�^�C���̖��ו\���A���͂��s��</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.12.22</br>
    /// <br></br>
    /// <br>Update Note: 2009.02.02 30452 ��� �r��</br>
    /// <br>            �E�r�����䏈���ǉ�</br>
    /// <br>Update Note: 2009/02/23 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�10766 �����s�I��Ή�</br>
    /// <br>Update Note: 2009/03/02 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12082,12072,12087,12076</br>
    /// <br>Update Note: 2009/03/03 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12104,12103,12081,12074,12075</br>
    /// <br>Update Note: 2009/03/03 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12084</br>
    /// <br>Update Note: 2009/03/05 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12072,12085</br>
    /// <br>Update Note: 2009/03/05 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12082,12070,12132,12073,12205</br>
    /// <br>Update Note: 2009/03/10 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12080</br>
    /// <br>Update Note: 2009/03/10 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12223</br>
    /// <br>Update Note: 2009/04/06 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�13112</br>
    /// <br>UpdateNote   : 2010/06/08 ���� ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
    /// <br>UpdateNote   : 2010/08/11 ���� 
    ///                 �E��Q���ǑΉ��i�W�����j �L�[�{�[�h����̉��ǂ��s���B</br>
    /// <br>UpdateNote   : 2012/09/11 yangmj ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
    /// <br>�Ǘ��ԍ�     : 10707327-00 PM1203G</br> 							
    /// <br>               Redmine32095 ���i�݌Ɉꊇ�o�^�C���Łu�S�Ẳ��i��񂪏�����v</br>
    /// <br>Update Note�@: 2013/05/11 yangyi</br>
    /// <br>�Ǘ��ԍ�   �@: 10801804-00 20150515�z�M���̑Ή�</br>
    /// <br>           �@: Redmine#35018 �u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���@���̂Q�Ή�</br>
    /// </remarks>
    public partial class PMZAI09201UB : UserControl
    {
        # region ��Inner Class
        /// <summary>
        /// �Z�����������N���X�iIMergedCellEvaluator �C���^�t�F�[�X���C���v�������g�j
        /// </summary>
        private class CustomMergedCellEvaluatorGoods : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            /// <summary>
            /// �Z�������������菈��
            /// </summary>
            /// <param name="row1">�s�P</param>
            /// <param name="row2">�s�Q</param>
            /// <param name="column">��</param>
            /// <returns>��Ɋ֘A�t����ꂽrow1��row2�̃Z�������������ꍇ�ATrue��Ԃ��܂�</returns>
            public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
            {
                if (row1.Cells["GoodsMaker"].Value == null || row1.Cells["GoodsMaker"].Value.ToString() == string.Empty
                    || row2.Cells["GoodsMaker"].Value == null || row2.Cells["GoodsMaker"].Value.ToString() == string.Empty
                    || row1.Cells["GoodsNo"].Value == null || row1.Cells["GoodsNo"].Value.ToString() == string.Empty
                    || row2.Cells["GoodsNo"].Value == null || row2.Cells["GoodsNo"].Value.ToString() == string.Empty)
                {
                    return false;
                }

                int makerCode1 = Convert.ToInt32(row1.Cells["GoodsMaker"].Value);
                int makerCode2 = Convert.ToInt32(row2.Cells["GoodsMaker"].Value);

                string goodsCode1 = row1.Cells["GoodsNo"].Value.ToString();
                string goodsCode2 = row2.Cells["GoodsNo"].Value.ToString();

                if ((goodsCode1.Trim() == "") || (goodsCode2.Trim() == "")) return false;
                return ((makerCode1 == makerCode2) && (goodsCode1 == goodsCode2));
            }
        }

        // --- ADD 2009/03/02 -------------------------------->>>>>
        /// <summary>
        /// �s�ԍ���\�[�gComparere
        /// </summary>
        private class RowNumberSortComparer : IComparer
        {
            public RowNumberSortComparer()
            {
            }

            public int Compare(object x, object y)
            {
                UltraGridCell xCell = (UltraGridCell)x;
                UltraGridCell yCell = (UltraGridCell)y;

                /*
                                            // �w��s�͎w��J�����������`�F�b�N
                                            for (int i = colIndex + 1; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
                                            {
                                                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                                    && this.uGrid_Details.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                                    && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                                {
                                                    // ���͉\�s��ColumnKey���擾
                                                    ActivationColIndex = i;
                                                    ActivationRowIndex = j;
                                                    return this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            // ���s�ȍ~�̓J���������Ƀ`�F�b�N
                                            for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
                                            {
                                                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                                    && this.uGrid_Details.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                                    && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                                {
                                                    // ���͉\�s��ColumnKey���擾
                                                    ActivationColIndex = i;
                                                    ActivationRowIndex = j;
                                                    return this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key;
                                                }
                                            }
                                        }
                */
                // --- DEL 2009/03/09 -------------------------------->>>>>
                //if (xCell.Value.ToString() == "�V�K")
                //{
                //    if (yCell.Value.ToString() == "�V�K")
                //    {
                //        return 0;
                //    }
                //    else
                //    {
                //        return 1;
                //    }
                //}
                //else
                //{
                //    if (yCell.Value.ToString() == "�V�K")
                //    {
                //        return -1;
                //    }
                //    else
                //    {
                //        return (Convert.ToInt32(xCell.Value).CompareTo(Convert.ToInt32(yCell.Value)));
                //    }
                //}
                // --- DEL 2009/03/09 --------------------------------<<<<<
                // --- ADD 2009/03/09 -------------------------------->>>>>
                int xValue = 0;
                int yValue = 0;

                Int32.TryParse(xCell.Value.ToString(), out xValue);
                Int32.TryParse(yCell.Value.ToString(), out yValue);

                if (xValue == 0)
                {
                    if (yValue == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    if (yValue == 0)
                    {
                        return -1;
                    }
                    else
                    {
                        return (xValue.CompareTo(yValue));
                    }
                }
                // --- ADD 2009/03/09 --------------------------------<<<<<
            }
        }
        // --- ADD 2009/03/02 --------------------------------<<<<<
        #endregion

        #region ��private�萔
        // ��ʏ�ԕۑ��p�t�@�C����
        private const string XML_FILE_INITIAL_DATA = "PMZAI09201U.dat";
        #endregion

        #region ��private�ϐ�
        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin;
        // �C���[�W���X�g
        private ImageList _imageList16 = null;

        // ��ƃR�[�h
        private string _enterpriseCode;
        // ���O�C�����_�R�[�h
        private string _loginSectionCode;
                
        // ���i�݌Ƀe�[�u��
        private GoodsStockDataSet.GoodsStockDataTable _goodsStockDataTable;
        // ���i�݌Ɉꊇ�o�^�A�N�Z�X
        private GoodsStockAcs _goodsStockAcs;

        // ���[�J�[�K�C�h�A�N�Z�X
        private MakerAcs _makerAcs;
        // BL�R�[�h�A�N�Z�X
        private BLGoodsCdAcs _blGoodsCdAcs;
        // �q�ɃA�N�Z�X
        private WarehouseAcs _warehouseAcs;
        // ���[�U�[�K�C�h�A�N�Z�X
        private UserGuideAcs _userGuideAcs;
        // �d����K�C�h�A�N�Z�X
        private SupplierAcs _supplierAcs;
        // ���i�����ރK�C�h
        private GoodsGroupUAcs _goodsGroupUAcs;
        // �O���[�v�R�[�h�K�C�h
        private BLGroupUAcs _blGroupUAcs;
        
        // �O�񌟍����s���̒��o����
        // ���\���敪�A�Ώۋ敪�ύX���ɃN���A�����d�l�ɂȂ�A�K�v�Ȃ��Ȃ�܂����B // ADD 2009/02/04
        private ExtractInfo _beforeSearchExtractInfo;

        // ���̕\����ԃt���O(true:�\��)
        private bool _visibleNameColumnsStat;

        // �O���b�h�ݒ萧��N���X
        private GridStateController _gridStateController;

        // �O���b�h���ڂ̍X�V�O���ڒl
        private string _tmpGoodsNo = string.Empty;
        private int _tmpGoodsMaker = 0;
        private int _tmpBLGoodsCode = 0;
        private int _tmpEnterpriseGanreCode = 0;
        private string _tmpWarehouseCode = string.Empty;
        private int _tmpStockSupplierCode = 0;
        private string _tmpPriceStartDate1;
        private string _tmpPriceStartDate2;
        private string _tmpPriceStartDate3;
        private string _tmpPriceStartDate4; // ADD 2010/08/31
        private string _tmpPriceStartDate5; // ADD 2010/08/31
        private int _tmpSalesOrderUnit;
        private double _tmpMinimumStockCnt;
        private double _tmpMaximumStockCnt;

        //// �O�A�N�e�B�u�s�C���f�b�N�X(�w�i�F�ݒ�p)
        //private int _tmpActiveRowIndex = -1; // DEL 2009/02/23
        // �O�I���s�C���f�b�N�X(�w�i�F�ݒ�p)
        private List<int> _beforeSelectRowIndexList = new List<int>(); // ADD 2009/02/23

        // �I���s�ɘ_���폜�ύs���܂ނ��H(���S�폜�A������Warning�\���p)
        private bool _includeGoodsLogicalDeleted = false; // ADD 2009/02/23
        private bool _includeStockLogicalDeleted = false; // ADD 2009/02/23

        private object _preComboEditorValue = null; // ADD 2010/08/11

        //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.7 ----->>>>>
        private string _gridGoodsNo;
        private int _gridGoodsMakerCd;
        //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.7 -----<<<<<

        #endregion

        //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.7 ----->>>>>
        public string GridGoodsNo
        {
            get { return this._gridGoodsNo; }
        }
        public int GridGoodsMakerCd
        {
            get { return this._gridGoodsMakerCd; }
        }
        //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.7 -----<<<<<

        #region ���f���Q�[�g
        /// <summary>
        /// ���o�����擾�f���Q�[�g
        /// </summary>
        /// <returns></returns>
        internal delegate ExtractInfo GetExtractInfoHander();

        /// <summary>
        /// �t�H�[�J�X�ݒ�f���Q�[�g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="itemName">���ږ���</param>
        internal delegate void SettingFocusEventHandler(string itemName);

        // --- ADD 2009/02/03 -------------------------------->>>>>
        /// <summary>
        /// �ۑ��{�^�������ې���C�x���g
        /// </summary>
        internal delegate void SetSaveButtonEnableHandler();
        // --- ADD 2009/02/03 --------------------------------<<<<<
        #endregion

        #region ���C�x���g
        /// <summary>���o�����擾�C�x���g</summary>
        internal event GetExtractInfoHander GetExtractInfo;
        /// <summary>�t�H�[�J�X�ݒ�C�x���g</summary>
        internal event SettingFocusEventHandler SetFocus;
        // --- ADD 2009/02/03 -------------------------------->>>>>
        /// <summary>�ۑ��{�^�������ېݒ�C�x���g</summary>
        internal event SetSaveButtonEnableHandler SetSaveButton;
        // --- ADD 2009/02/03 --------------------------------<<<<<

        // --- ADD 2010/08/11 -------------------------------->>>>>
        /// <summary>
        /// �K�C�h�̐ݒ�
        /// </summary>
        internal delegate void SetGuideEnabled(bool enabled);
        internal event SetGuideEnabled SetGuide;
        // --- ADD 2010/08/11 --------------------------------<<<<<
        #endregion

        #region ���R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMZAI09201UB()
        {
            InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();
            this._imageList16 = IconResourceManagement.ImageList16;

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();

            this._goodsStockAcs = GoodsStockAcs.GetInstance();
            this._goodsStockDataTable = this._goodsStockAcs.GoodsStockDataTable;

            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._supplierAcs = new SupplierAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._blGroupUAcs = new BLGroupUAcs();

            this._gridStateController = new GridStateController();
        }
        #endregion

        #region ���v���p�e�B
        /// <summary>�������̒��o����</summary>
        internal ExtractInfo BeforeSearchExtractInfo
        {
            get
            {
                return this._beforeSearchExtractInfo;
            }
            set
            {
                this._beforeSearchExtractInfo = value;
            }
        }
        #endregion

        #region ��public���\�b�h

        #region �� ����������
        /// <summary>
        /// ������(�N���A)����
        /// </summary>
        internal void Initialize()
        {
            // ��ʍ��ڏ�����
            InitializeScreen();

            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// ���׃O���b�h�Z���ݒ菈��
            //this.SetGridSettings();

            //// DataTable�s�N���A����
            //this._goodsStockAcs.GoodsStockDataTable.Clear();
            //this._goodsStockAcs.OriginalGoodsStockDataTable.Clear();
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/02/23 -------------------------------->>>>>

            // DataTable�s�N���A����
            this._goodsStockAcs.GoodsStockDataTable.Clear();
            this._goodsStockAcs.OriginalGoodsStockDataTable.Clear();

            // ���׃O���b�h�Z���ݒ菈��
            this.SetGridSettings();

            // �\�[�g�ݒ�̉���
            this.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();
            // --- ADD 2009/02/23 --------------------------------<<<<<

            // �����\�����̒��o������ۑ�
            this._beforeSearchExtractInfo = this.GetExtractInfo();
        }
        #endregion

        #region �� �t�H�[�J�X�J�ڐ���
        /// <summary>
        /// �O���b�h�^�u�ړ�����
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        internal void SetGridTabFocus(ref ChangeFocusEventArgs e)
        {
            // ���t�H�[�J�X��J������
            string nextFocusColumn;
            int activationColIndex;
            int activationRowIndex;

            if (this.uGrid_Details.ActiveCell == null)
            {
                // �A�N�e�B�u�Ȃ� �܂��� �s�A�N�e�B�u
                e.NextCtrl = null;
                this.uGrid_Details.Focus();

                int colIndex = 0;
                int rowIndex = 0;

                if (this.uGrid_Details.ActiveRow != null)
                {
                    rowIndex = this.uGrid_Details.ActiveRow.Index;
                }
                    

                // 1�s�ڂ̍ŏ��̓��͉\�s�Ƀt�H�[�J�X
                nextFocusColumn = this.GetNextFocusColumnKey(colIndex, rowIndex, false, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.SetFocus("tComboEditor_DisplayDiv");
                }

                return;
            }
            else
            {
                // �Z���A�N�e�B�u
                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                int colIndex = this.uGrid_Details.ActiveCell.Column.Index;

                // �O���b�h�E�o���p�̃R���g���[����ێ�
                //Control tmpCntl = e.NextCtrl;
                e.NextCtrl = null;
                this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                this.uGrid_Details.Focus();

                // ���Z���擾
                nextFocusColumn = GetNextFocusColumnKey(colIndex, rowIndex, false, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.SetFocus("tComboEditor_DisplayDiv");
                }
            }
        }

        /// <summary>
        /// �O���b�h�V�t�g�^�u����
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        internal void SetGridShiftTabFocus(ref ChangeFocusEventArgs e)
        {
            // ���t�H�[�J�X��J������
            string nextFocusColumn;
            int activationColIndex;
            int activationRowIndex;

            //int lastColumnIndex = this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1;

            if (this.uGrid_Details.ActiveCell == null)
            {
                // �A�N�e�B�u�Ȃ� �܂��� �s�A�N�e�B�u
                e.NextCtrl = null;
                this.uGrid_Details.Focus();

                int colIndex = this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1;
                int rowIndex = this.uGrid_Details.Rows.Count - 1;

                if (this.uGrid_Details.ActiveRow != null)
                {
                    colIndex = 0;
                    rowIndex = uGrid_Details.ActiveRow.Index;
                }

                // 1�s�ڂ̍Ō�̓��͉\�s�Ƀt�H�[�J�X
                nextFocusColumn = this.GetNextFocusColumnKey(colIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    //this.SetFocus("uButton_EmployeeCdGuide"); // DEL 2009/03/06
                    this.SetFocus("Before_Grid"); // ADD 2009/03/06
                }

                return;
            }
            else
            {
                // �Z���A�N�e�B�u
                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                int columnIndex = this.uGrid_Details.ActiveCell.Column.Index;

                // �O���b�h�E�o���p�̃R���g���[����ێ�
                //Control tmpCntl = e.NextCtrl;
                e.NextCtrl = null;
                this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                this.uGrid_Details.Focus();

                // ���Z���擾
                nextFocusColumn = GetNextFocusColumnKey(columnIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    //this.SetFocus("uButton_EmployeeCdGuide"); // DEL 2009/03/06
                    this.SetFocus("Before_Grid"); // ADD 2009/03/06
                }
            }
        }

        /// <summary>
        /// ���̓��͉\���Key���擾����
        /// </summary>
        /// <param name="colIndex">�`�F�b�N�J�n��index�AActivation�\���Ԃ�</param>
        /// <param name="rowIndex">�`�F�b�N�J�n�sindex�AActivation�\�s��Ԃ�</param>
        /// <param param name="isShift">true:�V�t�g���� false:�V�t�g�Ȃ�</param>
        /// <returns>Activation�\��̃L�[�B�Ȃ��ꍇ��string.Empty</returns>
        internal string GetNextFocusColumnKey(int colIndex, int rowIndex, bool isShift, out int ActivationColIndex, out int ActivationRowIndex)
        {
            ActivationColIndex = 0;
            ActivationRowIndex = 0;

            // �w���̎��̓��͉\�������
            if (!isShift)
            {
                // �V�t�g��
                for (int j = rowIndex; j < this.uGrid_Details.Rows.Count; j++)
                {
                    if (!this.uGrid_Details.Rows[j].IsFilteredOut) // ADD 2009/03/06
                    {
                        /* --- DEL 2012/10/05 -------------------------------->>>>>
                        if (j == rowIndex)
                        {
                            // �w��s�͎w��J�����������`�F�b�N
                            for (int i = colIndex + 1; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
                            {
                                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Details.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // ���͉\�s��ColumnKey���擾
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                        else
                        {
                            // ���s�ȍ~�̓J���������Ƀ`�F�b�N
                            for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
                            {
                                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Details.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // ���͉\�s��ColumnKey���擾
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                           --- DEL 2012/10/05 --------------------------------<<<<< */
                        // --- ADD 2012/10/05 -------------------------------->>>>>
                        if (j == rowIndex)
                        {
                            // �w��s�͎w��J�����������`�F�b�N
                            for (int k = this.uGrid_Details.DisplayLayout.Bands[0].Columns[colIndex].Header.VisiblePosition + 1; k < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; k++)
                            {
                                for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
                                {
                                    if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Header.VisiblePosition == k
                                     && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                     && this.uGrid_Details.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                     && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                    {
                                        // ���͉\�s��ColumnKey���擾
                                        ActivationColIndex = i;
                                        ActivationRowIndex = j;
                                        return this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // ���s�ȍ~�̓J���������Ƀ`�F�b�N
                            for (int k = 0; k < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; k++)
                            {
                                for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
                                {
                                    if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Header.VisiblePosition == k
                                     && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                     && this.uGrid_Details.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                     && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                    {
                                        // ���͉\�s��ColumnKey���擾
                                        ActivationColIndex = i;
                                        ActivationRowIndex = j;
                                        return this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key;
                                    }
                                }
                            }
                        }
                        // --- ADD 2012/10/05 --------------------------------<<<<<
                    }
                }
            }
            else
            {
                // �V�t�g����
                for (int j = rowIndex; j >= 0; j--)
                {
                    if (!this.uGrid_Details.Rows[j].IsFilteredOut) // ADD 2009/03/06
                    {
                        /* --- DEL 2012/10/05 -------------------------------->>>>>
                        if (j == rowIndex)
                        {
                            for (int i = colIndex - 1; i >= 0; i--)
                            {
                                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Details.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // ���͉\�s��ColumnKey���擾
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                        else
                        {
                            for (int i = this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1; i >= 0; i--)
                            {

                                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Details.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // ���͉\�s��ColumnKey���擾
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                           --- DEL 2012/10/05 --------------------------------<<<<< */
                        // --- ADD 2012/10/05 -------------------------------->>>>>
                        if (j == rowIndex)
                        {
                            for (int k = this.uGrid_Details.DisplayLayout.Bands[0].Columns[colIndex].Header.VisiblePosition - 1; k >= 0; k--)
                            {
                                for (int i = this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1; i >= 0; i--)
                                {
                                    if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Header.VisiblePosition == k
                                     && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                     && this.uGrid_Details.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                     && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                    {
                                        // ���͉\�s��ColumnKey���擾
                                        ActivationColIndex = i;
                                        ActivationRowIndex = j;
                                        return this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int k = this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1; k >= 0; k--)
                            {
                                for (int i = this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1; i >= 0; i--)
                                {
                                    if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Header.VisiblePosition == k
                                     && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                     && this.uGrid_Details.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                     && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                    {
                                        // ���͉\�s��ColumnKey���擾
                                        ActivationColIndex = i;
                                        ActivationRowIndex = j;
                                        return this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key;
                                    }
                                }
                            }
                        }
                        // --- ADD 2012/10/05 --------------------------------<<<<<
                    }
                }
            }


            return string.Empty;
        }

        #endregion

        #region �{�^����������
        // --- ADD 2009/02/23 -------------------------------->>>>>
        /// <summary>
        /// �{�^�����������Cell�A�N�e�B�u��Row�A�N�e�B�u�ŐU�蕪����
        /// </summary>
        internal void SetButtonEnable()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                this.SetButtonEnableByCell(this.uGrid_Details.ActiveCell.Row.Index, this.uGrid_Details.ActiveCell.Column.Key);
            }
            else
            {
                this.SetButtonEnableBySelectedRows();
            }
        }
        // --- ADD 2009/02/23 --------------------------------<<<<<
        #endregion

        #endregion

        #region ��private���\�b�h

        #region �� ��ʕ\���֘A
        #region �� �����\���ݒ�
        /// <summary>
        /// ��ʏ�����
        /// </summary>
        private void InitializeScreen()
        {
            // �X�L���ݒ�
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // �{�^���ݒ�
            this.uButton_RowGoodsDelete.ImageList = this._imageList16;
            this.uButton_RowGoodsRevive.ImageList = this._imageList16;
            this.uButton_RowStockDelete.ImageList = this._imageList16;
            this.uButton_RowStockRevive.ImageList = this._imageList16;
            this.uButton_RowAdd.ImageList = this._imageList16;
            this.uButton_RowDispPrice.ImageList = this._imageList16;
            this.uButton_RowDispNames.ImageList = this._imageList16;
            //this.uButton_RowExcuteGuide.ImageList = this._imageList16; // DEL 2010/08/11

            this.uButton_RowGoodsDelete.Appearance.Image = (int)Size16_Index.ROWDELETE;
            this.uButton_RowGoodsRevive.Appearance.Image = (int)Size16_Index.RENEWAL;
            this.uButton_RowStockDelete.Appearance.Image = (int)Size16_Index.ROWDELETE;
            this.uButton_RowStockRevive.Appearance.Image = (int)Size16_Index.RENEWAL;
            this.uButton_RowAdd.Appearance.Image = (int)Size16_Index.ROWADD;
            this.uButton_RowDispPrice.Appearance.Image = (int)Size16_Index.GRIDDISPLAY;
            this.uButton_RowDispNames.Appearance.Image = (int)Size16_Index.GRIDDISPLAY;
            //this.uButton_RowExcuteGuide.Appearance.Image = (int)Size16_Index.GUIDE; // DEL 2010/08/11

            this.uButton_RowGoodsDelete.Enabled = false;
            this.uButton_RowGoodsRevive.Enabled = false;
            this.uButton_RowStockDelete.Enabled = false;
            this.uButton_RowStockRevive.Enabled = false;
            this.uButton_RowAdd.Enabled = true;
            this.uButton_RowDispPrice.Enabled = true;
            this.uButton_RowDispNames.Enabled = true;
            //this.uButton_RowExcuteGuide.Enabled = false; // DEL 2010/08/11
            this.SetGuide(false); // ADD 2010/08/11
        }

        /// <summary>
        /// �O���b�h��̏�����
        /// </summary>
        private void InitializeGrid()
        {
            // �O���b�h�O�ϐݒ�
            this.SetGridInitialSetting();

            // �{�^�����́A�\���A��\���ݒ菈��
            this.SetButtonEnableByExtactInfo();

            // �O���b�h��\����\���ݒ菈��
            this.SetGridColSetting();

            // �����\�����̒��o������ۑ�
            this._beforeSearchExtractInfo = this.GetExtractInfo();
        }
        #endregion

        #region �� �O���b�h�\���ݒ�
        /// <summary>
        /// �O���b�h��\����\���ݒ�
        /// </summary>
        /// <remarks>
        /// <br>��L</br>
        /// <br>CellActivation�͌Œ�Ƃ��A�\���敪�A�Ώۋ敪�ɂ��Hidden��ύX���Ă���</br>
        /// <br>�O���b�h���̃L�[�J�ڂ�CellActivation=Allow�AHidden=false�̍s����͉\�s�Ƃ��Đ��䂵�Ă���</br>
        /// <br>UpdateNote       : 2010/06/08 ���� ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
        /// </remarks>
        private void SetGridInitialSetting()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];
            if (band == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in band.Columns)
            {
                // �S�񋤒ʐݒ�
                // �\���ʒu(vertical)
                col.CellAppearance.TextVAlign = VAlign.Middle;
            }

            GoodsStockDataSet.GoodsStockDataTable table = this._goodsStockDataTable;

            // �s�ԍ���̂݃Z���\���F�ύX
            band.Columns[table.RowNumberColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            band.Columns[table.RowNumberColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            band.Columns[table.RowNumberColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            band.Columns[table.RowNumberColumn.ColumnName].CellAppearance.ForeColor = Color.White;
            band.Columns[table.RowNumberColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.White;

            // �s�ԍ���N���b�N���͍sActive
            band.Columns[table.RowNumberColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // ADD 2009/02/05
            // �s�ԍ���̃\�[�g���w��
            band.Columns[table.RowNumberColumn.ColumnName].SortComparer = new RowNumberSortComparer(); // ADD 2009/03/02

            // �Œ��ݒ�
            band.Columns[table.RowNumberColumn.ColumnName].Header.Fixed = true; // �s�ԍ�
            band.Columns[table.GoodsDeleteDateColumn.ColumnName].Header.Fixed = true; // ���i�폜��
            band.Columns[table.StockDeleteDateColumn.ColumnName].Header.Fixed = true; // �݌ɍ폜��
            band.Columns[table.GoodsNoColumn.ColumnName].Header.Fixed = true; // �i��

            // �\�����ݒ�
            band.Columns[table.RowNumberColumn.ColumnName].Width = 50; // �s�ԍ�
            band.Columns[table.GoodsDeleteDateColumn.ColumnName].Width = 80; // ���i�폜��
            band.Columns[table.StockDeleteDateColumn.ColumnName].Width = 80; // �݌ɍ폜��
            band.Columns[table.GoodsNoColumn.ColumnName].Width = 200; // �i��
            band.Columns[table.GoodsNameColumn.ColumnName].Width = 200; // �i��
            band.Columns[table.GoodsMakerColumn.ColumnName].Width = 100; // ���[�J�[�R�[�h
            band.Columns[table.GoodsMakerNameColumn.ColumnName].Width = 100; // ���[�J�[����
            // --- DEL 2010/06/08 ---------->>>>>
            //band.Columns[table.GoodsNameKanaColumn.ColumnName].Width = 200; // �i���J�i
            // --- DEL 2010/06/08 ----------<<<<<
            band.Columns[table.JanColumn.ColumnName].Width = 120; // JAN�R�[�h
            band.Columns[table.BLGoodsCodeColumn.ColumnName].Width = 100; // BL�R�[�h
            band.Columns[table.BLGoodsNameColumn.ColumnName].Width = 100; // BL�R�[�h��
            band.Columns[table.EnterpriseGanreCodeColumn.ColumnName].Width = 100; // ���i�敪
            band.Columns[table.EnterpriseGanreNameColumn.ColumnName].Width = 100; // ���i�敪��
            band.Columns[table.GoodsRateRankColumn.ColumnName].Width = 100; // �w��
            band.Columns[table.GoodsKindCodeColumn.ColumnName].Width = 100; // ���i����
            band.Columns[table.TaxationDivCdColumn.ColumnName].Width = 100; // �ېŋ敪
            band.Columns[table.GoodsMGroupColumn.ColumnName].Width = 100; // ���i������
            band.Columns[table.GoodsMGroupNameColumn.ColumnName].Width = 200; // ���i�����ޖ�
            band.Columns[table.BLGroupCodeColumn.ColumnName].Width = 130; // �O���[�v�R�[�h
            band.Columns[table.BLGroupNameColumn.ColumnName].Width = 200; // �O���[�v�R�[�h��
            band.Columns[table.PriceStartDate1Column.ColumnName].Width = 120; // ���i�J�n��1
            band.Columns[table.ListPrice1Column.ColumnName].Width = 100; // ���i1
            band.Columns[table.OpenPriceDiv1Column.ColumnName].Width = 160; // �I�[�v�����i�敪1
            band.Columns[table.StockRate1Column.ColumnName].Width = 100; // �d����1
            band.Columns[table.SalesUnitCost1Column.ColumnName].Width = 100; // ���P��1
            band.Columns[table.PriceStartDate2Column.ColumnName].Width = 120; // ���i�J�n��2
            band.Columns[table.ListPrice2Column.ColumnName].Width = 100; // ���i2
            band.Columns[table.OpenPriceDiv2Column.ColumnName].Width = 160; // �I�[�v�����i�敪2
            band.Columns[table.StockRate2Column.ColumnName].Width = 100; // �d����2
            band.Columns[table.SalesUnitCost2Column.ColumnName].Width = 100; // ���P��2
            band.Columns[table.PriceStartDate3Column.ColumnName].Width = 120; // ���i�J�n��3
            band.Columns[table.ListPrice3Column.ColumnName].Width = 100; // ���i3
            band.Columns[table.OpenPriceDiv3Column.ColumnName].Width = 160; // �I�[�v�����i�敪3
            band.Columns[table.StockRate3Column.ColumnName].Width = 100; // �d����3
            band.Columns[table.SalesUnitCost3Column.ColumnName].Width = 100; // ���P��3
            // --- ADD 2010/08/11 ---------->>>>>
            band.Columns[table.PriceStartDate4Column.ColumnName].Width = 120; // ���i�J�n��4
            band.Columns[table.ListPrice4Column.ColumnName].Width = 100; // ���i4
            band.Columns[table.OpenPriceDiv4Column.ColumnName].Width = 160; // �I�[�v�����i�敪4
            band.Columns[table.StockRate4Column.ColumnName].Width = 100; // �d����4
            band.Columns[table.SalesUnitCost4Column.ColumnName].Width = 100; // ���P��4
            band.Columns[table.PriceStartDate5Column.ColumnName].Width = 120; // ���i�J�n��5
            band.Columns[table.ListPrice5Column.ColumnName].Width = 100; // ���i5
            band.Columns[table.OpenPriceDiv5Column.ColumnName].Width = 160; // �I�[�v�����i�敪5
            band.Columns[table.StockRate5Column.ColumnName].Width = 100; // �d����5
            band.Columns[table.SalesUnitCost5Column.ColumnName].Width = 100; // ���P��5
            // --- ADD 2010/08/11 ----------<<<<<
            band.Columns[table.PriceFlColumn.ColumnName].Width = 120; // ���[�U�[���i
            band.Columns[table.UpRateColumn.ColumnName].Width = 100; // UP��
            band.Columns[table.WarehouseCodeColumn.ColumnName].Width = 100; // �q�ɃR�[�h
            band.Columns[table.WarehouseNameColumn.ColumnName].Width = 100; // �q�ɖ�
            // --- ADD 2009/03/10 -------------------------------->>>>>
            band.Columns[table.SectionCodeColumn.ColumnName].Width = 130; // �Ǘ����_�R�[�h
            band.Columns[table.SectionGuideSnmColumn.ColumnName].Width = 130; // �Ǘ����_��
            // --- ADD 2009/03/10 --------------------------------<<<<<
            band.Columns[table.WarehouseShelfNoColumn.ColumnName].Width = 100; // �I��
            band.Columns[table.DuplicationShelfNo1Column.ColumnName].Width = 100; // �d���I��1
            band.Columns[table.DuplicationShelfNo2Column.ColumnName].Width = 100; // �d���I��2
            band.Columns[table.PartsManagementDivide1Column.ColumnName].Width = 100; // �Ǘ��敪1
            band.Columns[table.PartsManagementDivide2Column.ColumnName].Width = 100; // �Ǘ��敪2
            band.Columns[table.StockSupplierCodeColumn.ColumnName].Width = 100; // ������R�[�h
            band.Columns[table.StockSupplierSnmColumn.ColumnName].Width = 150; // �����於
            band.Columns[table.StockDivColumn.ColumnName].Width = 100; // �݌ɋ敪
            band.Columns[table.SalesOrderUnitColumn.ColumnName].Width = 100; // �������b�g
            band.Columns[table.MinimumStockCntColumn.ColumnName].Width = 100; // �Œ�݌ɐ�
            band.Columns[table.MaximumStockCntColumn.ColumnName].Width = 100; // �ő�݌ɐ�
            band.Columns[table.SupplierStockColumn.ColumnName].Width = 100; // �d���݌ɐ�
            band.Columns[table.ArrivalCntColumn.ColumnName].Width = 150; // ���א�
            band.Columns[table.ShipmentCntColumn.ColumnName].Width = 150; // �o�א�
            band.Columns[table.AcpOdrCountColumn.ColumnName].Width = 100; // �󒍐�
            band.Columns[table.MovingSupliStockColumn.ColumnName].Width = 100; // �ړ����d���݌ɐ�
            band.Columns[table.NowStockCntColumn.ColumnName].Width = 100; // ���݌ɐ�
            // --- ADD 2009/03/05 -------------------------------->>>>>
            band.Columns[table.StockUnitPriceRateColumn.ColumnName].Width = 150;
            band.Columns[table.StockUnitPriceFlColumn.ColumnName].Width = 150;
            // --- ADD 2009/03/05 --------------------------------<<<<<
            band.Columns[table.ErrorMessageColumn.ColumnName].Width = 500; // �G���[���b�Z�[�W // ADD 2009/03/10

            // ���͉�
            band.Columns[table.RowNumberColumn.ColumnName].CellActivation = Activation.Disabled; // �s�ԍ�
            band.Columns[table.GoodsLogicalDeleteFlgColumn.ColumnName].CellActivation = Activation.Disabled; // ���i�}�X�^�_���폜�t���O
            band.Columns[table.StockLogicalDeleteFlgColumn.ColumnName].CellActivation = Activation.Disabled; // �݌Ƀ}�X�^�_���폜�t���O
            band.Columns[table.GoodsDeleteDateColumn.ColumnName].CellActivation = Activation.Disabled; // ���i�폜��
            band.Columns[table.StockDeleteDateColumn.ColumnName].CellActivation = Activation.Disabled; // �݌ɍ폜��
            band.Columns[table.GoodsNoColumn.ColumnName].CellActivation = Activation.AllowEdit; // �i��
            band.Columns[table.GoodsNameColumn.ColumnName].CellActivation = Activation.AllowEdit; // �i��
            band.Columns[table.GoodsMakerColumn.ColumnName].CellActivation = Activation.AllowEdit; // ���[�J�[�R�[�h
            band.Columns[table.GoodsMakerNameColumn.ColumnName].CellActivation = Activation.Disabled; // ���[�J�[����
            // --- DEL 2010/06/08 ---------->>>>>
            //band.Columns[table.GoodsNameKanaColumn.ColumnName].CellActivation = Activation.AllowEdit; // �i���J�i
            // --- DEL 2010/06/08 ----------<<<<<
            band.Columns[table.JanColumn.ColumnName].CellActivation = Activation.AllowEdit; // JAN�R�[�h
            band.Columns[table.BLGoodsCodeColumn.ColumnName].CellActivation = Activation.AllowEdit; // BL�R�[�h
            band.Columns[table.BLGoodsNameColumn.ColumnName].CellActivation = Activation.Disabled; // BL�R�[�h��
            band.Columns[table.EnterpriseGanreCodeColumn.ColumnName].CellActivation = Activation.AllowEdit; // ���i�敪
            band.Columns[table.EnterpriseGanreNameColumn.ColumnName].CellActivation = Activation.Disabled; // ���i�敪��
            band.Columns[table.GoodsRateRankColumn.ColumnName].CellActivation = Activation.AllowEdit; // �w��
            band.Columns[table.GoodsKindCodeColumn.ColumnName].CellActivation = Activation.AllowEdit; // ���i����
            band.Columns[table.TaxationDivCdColumn.ColumnName].CellActivation = Activation.AllowEdit; // �ېŋ敪
            band.Columns[table.GoodsMGroupColumn.ColumnName].CellActivation = Activation.Disabled; // ���i������
            band.Columns[table.GoodsMGroupNameColumn.ColumnName].CellActivation = Activation.Disabled; // ���i�����ޖ�
            band.Columns[table.BLGroupCodeColumn.ColumnName].CellActivation = Activation.Disabled; // �O���[�v�R�[�h
            band.Columns[table.BLGroupNameColumn.ColumnName].CellActivation = Activation.Disabled; // �O���[�v�R�[�h��
            band.Columns[table.PriceStartDate1Column.ColumnName].CellActivation = Activation.AllowEdit; // ���i�J�n��1
            band.Columns[table.ListPrice1Column.ColumnName].CellActivation = Activation.AllowEdit; // ���i1
            band.Columns[table.OpenPriceDiv1Column.ColumnName].CellActivation = Activation.AllowEdit; // �I�[�v�����i�敪1
            band.Columns[table.StockRate1Column.ColumnName].CellActivation = Activation.AllowEdit; // �d����1
            band.Columns[table.SalesUnitCost1Column.ColumnName].CellActivation = Activation.AllowEdit; // ���P��1
            band.Columns[table.PriceStartDate2Column.ColumnName].CellActivation = Activation.AllowEdit; // ���i�J�n��2
            band.Columns[table.ListPrice2Column.ColumnName].CellActivation = Activation.AllowEdit; // ���i2
            band.Columns[table.OpenPriceDiv2Column.ColumnName].CellActivation = Activation.AllowEdit; // �I�[�v�����i�敪2
            band.Columns[table.StockRate2Column.ColumnName].CellActivation = Activation.AllowEdit; // �d����2
            band.Columns[table.SalesUnitCost2Column.ColumnName].CellActivation = Activation.AllowEdit; // ���P��2
            band.Columns[table.PriceStartDate3Column.ColumnName].CellActivation = Activation.AllowEdit; // ���i�J�n��3
            band.Columns[table.ListPrice3Column.ColumnName].CellActivation = Activation.AllowEdit; // ���i3
            band.Columns[table.OpenPriceDiv3Column.ColumnName].CellActivation = Activation.AllowEdit; // �I�[�v�����i�敪3
            band.Columns[table.StockRate3Column.ColumnName].CellActivation = Activation.AllowEdit; // �d����3
            band.Columns[table.SalesUnitCost3Column.ColumnName].CellActivation = Activation.AllowEdit; // ���P��3
            // --- ADD 2010/08/11 ---------->>>>>
            band.Columns[table.PriceStartDate4Column.ColumnName].CellActivation = Activation.AllowEdit; // ���i�J�n��4
            band.Columns[table.ListPrice4Column.ColumnName].CellActivation = Activation.AllowEdit; // ���i4
            band.Columns[table.OpenPriceDiv4Column.ColumnName].CellActivation = Activation.AllowEdit; // �I�[�v�����i�敪4
            band.Columns[table.StockRate4Column.ColumnName].CellActivation = Activation.AllowEdit; // �d����4
            band.Columns[table.SalesUnitCost4Column.ColumnName].CellActivation = Activation.AllowEdit; // ���P��4
            band.Columns[table.PriceStartDate5Column.ColumnName].CellActivation = Activation.AllowEdit; // ���i�J�n��5
            band.Columns[table.ListPrice5Column.ColumnName].CellActivation = Activation.AllowEdit; // ���i5
            band.Columns[table.OpenPriceDiv5Column.ColumnName].CellActivation = Activation.AllowEdit; // �I�[�v�����i�敪5
            band.Columns[table.StockRate5Column.ColumnName].CellActivation = Activation.AllowEdit; // �d����5
            band.Columns[table.SalesUnitCost5Column.ColumnName].CellActivation = Activation.AllowEdit; // ���P��5
            // --- ADD 2010/08/11 ----------<<<<<
            band.Columns[table.PriceFlColumn.ColumnName].CellActivation = Activation.AllowEdit; // ���[�U�[���i
            band.Columns[table.UpRateColumn.ColumnName].CellActivation = Activation.AllowEdit; // UP��
            band.Columns[table.WarehouseCodeColumn.ColumnName].CellActivation = Activation.AllowEdit; // �q�ɃR�[�h
            band.Columns[table.WarehouseNameColumn.ColumnName].CellActivation = Activation.Disabled; // �q�ɖ�
            // --- ADD 2009/03/10 -------------------------------->>>>>
            band.Columns[table.SectionCodeColumn.ColumnName].CellActivation = Activation.Disabled; // �Ǘ����_�R�[�h
            band.Columns[table.SectionGuideSnmColumn.ColumnName].CellActivation = Activation.Disabled; // �Ǘ����_��
            // --- ADD 2009/03/10 --------------------------------<<<<<
            band.Columns[table.WarehouseShelfNoColumn.ColumnName].CellActivation = Activation.AllowEdit; // �I��
            band.Columns[table.DuplicationShelfNo1Column.ColumnName].CellActivation = Activation.AllowEdit; // �d���I��1
            band.Columns[table.DuplicationShelfNo2Column.ColumnName].CellActivation = Activation.AllowEdit; // �d���I��2
            band.Columns[table.PartsManagementDivide1Column.ColumnName].CellActivation = Activation.AllowEdit; // �Ǘ��敪1
            band.Columns[table.PartsManagementDivide2Column.ColumnName].CellActivation = Activation.AllowEdit; // �Ǘ��敪2
            band.Columns[table.StockSupplierCodeColumn.ColumnName].CellActivation = Activation.AllowEdit; // ������R�[�h
            band.Columns[table.StockSupplierSnmColumn.ColumnName].CellActivation = Activation.Disabled; // �����於
            band.Columns[table.StockDivColumn.ColumnName].CellActivation = Activation.AllowEdit; // �݌ɋ敪
            band.Columns[table.SalesOrderUnitColumn.ColumnName].CellActivation = Activation.AllowEdit; // �������b�g
            band.Columns[table.MinimumStockCntColumn.ColumnName].CellActivation = Activation.AllowEdit; // �Œ�݌ɐ�
            band.Columns[table.MaximumStockCntColumn.ColumnName].CellActivation = Activation.AllowEdit; // �ő�݌ɐ�
            band.Columns[table.SupplierStockColumn.ColumnName].CellActivation = Activation.AllowEdit; // �d���݌ɐ�
            // --- DEL 2009/03/06 -------------------------------->>>>>
            //band.Columns[table.ArrivalCntColumn.ColumnName].CellActivation = Activation.AllowEdit; // ���א�
            //band.Columns[table.ShipmentCntColumn.ColumnName].CellActivation = Activation.AllowEdit; // �o�א�
            //band.Columns[table.AcpOdrCountColumn.ColumnName].CellActivation = Activation.AllowEdit; // �󒍐�
            //band.Columns[table.MovingSupliStockColumn.ColumnName].CellActivation = Activation.AllowEdit; // �ړ����d���݌ɐ�
            // --- DEL 2009/03/06 --------------------------------<<<<<
            // --- ADD 2009/03/06 -------------------------------->>>>>
            band.Columns[table.ArrivalCntColumn.ColumnName].CellActivation = Activation.Disabled; // ���א�
            band.Columns[table.ShipmentCntColumn.ColumnName].CellActivation = Activation.Disabled; // �o�א�
            band.Columns[table.AcpOdrCountColumn.ColumnName].CellActivation = Activation.Disabled; // �󒍐�
            band.Columns[table.MovingSupliStockColumn.ColumnName].CellActivation = Activation.Disabled; // �ړ����d���݌ɐ�
            // --- ADD 2009/03/06 --------------------------------<<<<<
            band.Columns[table.NowStockCntColumn.ColumnName].CellActivation = Activation.Disabled; // ���݌ɐ�
            // --- ADD 2009/03/05 -------------------------------->>>>>
            band.Columns[table.StockUnitPriceRateColumn.ColumnName].CellActivation = Activation.AllowEdit; // �I���]����
            band.Columns[table.StockUnitPriceFlColumn.ColumnName].CellActivation = Activation.AllowEdit; // �I���]���P��
            // --- ADD 2009/03/05 --------------------------------<<<<<
            band.Columns[table.ErrorMessageColumn.ColumnName].CellActivation = Activation.Disabled; // �G���[���b�Z�[�W // ADD 2009/03/10

            // --- ADD 2009/02/23 -------------------------------->>>>>
            // �I��s�s�̓N���b�N���s�I���ɂ���
            band.Columns[table.GoodsLogicalDeleteFlgColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.StockLogicalDeleteFlgColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.GoodsDeleteDateColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.StockDeleteDateColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.GoodsMakerNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.BLGoodsNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.EnterpriseGanreNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.GoodsMGroupColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.GoodsMGroupNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.BLGroupCodeColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.BLGroupNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.WarehouseNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            // --- ADD 2009/03/10 -------------------------------->>>>>
            band.Columns[table.SectionCodeColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // �Ǘ����_�R�[�h
            band.Columns[table.SectionGuideSnmColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // �Ǘ����_��
            // --- ADD 2009/03/10 --------------------------------<<<<<
            band.Columns[table.StockSupplierSnmColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            band.Columns[table.NowStockCntColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            // --- ADD 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/03/06 -------------------------------->>>>>
            band.Columns[table.ArrivalCntColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // ���א�
            band.Columns[table.ShipmentCntColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // �o�א�
            band.Columns[table.AcpOdrCountColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // �󒍐�
            band.Columns[table.MovingSupliStockColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // �ړ����d���݌ɐ�
            // --- ADD 2009/03/06 --------------------------------<<<<<
            band.Columns[table.ErrorMessageColumn.ColumnName].CellActivation = Activation.Disabled; // �G���[���b�Z�[�W

            // ���͉\����
            band.Columns[table.RowNumberColumn.ColumnName].MaxLength = 8; // �s�ԍ�
            band.Columns[table.GoodsNoColumn.ColumnName].MaxLength = 24; // �i��
            band.Columns[table.GoodsNameColumn.ColumnName].MaxLength = 40; // �i��
            band.Columns[table.GoodsMakerColumn.ColumnName].MaxLength = 4; // ���[�J�[�R�[�h
            band.Columns[table.GoodsMakerNameColumn.ColumnName].MaxLength = 10; // ���[�J�[����
            // --- DEL 2010/06/08 ---------->>>>>
            //band.Columns[table.GoodsNameKanaColumn.ColumnName].MaxLength = 40; // �i���J�i
            // --- DEL 2010/06/08 ----------<<<<<
            band.Columns[table.JanColumn.ColumnName].MaxLength = 13; // JAN�R�[�h
            band.Columns[table.BLGoodsCodeColumn.ColumnName].MaxLength = 5; // BL�R�[�h
            band.Columns[table.BLGoodsNameColumn.ColumnName].MaxLength = 20; // BL�R�[�h��
            band.Columns[table.EnterpriseGanreCodeColumn.ColumnName].MaxLength = 4; // ���i�敪
            band.Columns[table.EnterpriseGanreNameColumn.ColumnName].MaxLength = 15; // ���i�敪��
            band.Columns[table.GoodsRateRankColumn.ColumnName].MaxLength = 2; // �w��
            band.Columns[table.GoodsMGroupColumn.ColumnName].MaxLength = 4; // ���i������
            band.Columns[table.GoodsMGroupNameColumn.ColumnName].MaxLength = 20; // ���i�����ޖ�
            band.Columns[table.BLGroupCodeColumn.ColumnName].MaxLength = 5; // �O���[�v�R�[�h
            band.Columns[table.BLGroupNameColumn.ColumnName].MaxLength = 20; // �O���[�v�R�[�h��
            band.Columns[table.PriceStartDate1Column.ColumnName].MaxLength = 8; // ���i�J�n��1
            band.Columns[table.ListPrice1Column.ColumnName].MaxLength = 7; // ���i1
            band.Columns[table.StockRate1Column.ColumnName].MaxLength = 6; // �d����1
            band.Columns[table.SalesUnitCost1Column.ColumnName].MaxLength = 10; // ���P��1
            band.Columns[table.PriceStartDate2Column.ColumnName].MaxLength = 8; // ���i�J�n��2
            band.Columns[table.ListPrice2Column.ColumnName].MaxLength = 7; // ���i2
            band.Columns[table.StockRate2Column.ColumnName].MaxLength = 6; // �d����2
            band.Columns[table.SalesUnitCost2Column.ColumnName].MaxLength = 10; // ���P��2
            band.Columns[table.PriceStartDate3Column.ColumnName].MaxLength = 8; // ���i�J�n��3
            band.Columns[table.ListPrice3Column.ColumnName].MaxLength = 7; // ���i3
            band.Columns[table.StockRate3Column.ColumnName].MaxLength = 6; // �d����3
            band.Columns[table.SalesUnitCost3Column.ColumnName].MaxLength = 10; // ���P��3
            // --- ADD 2010/08/11 ---------->>>>>
            band.Columns[table.PriceStartDate4Column.ColumnName].MaxLength = 8; // ���i�J�n��4
            band.Columns[table.ListPrice4Column.ColumnName].MaxLength = 7; // ���i4
            band.Columns[table.StockRate4Column.ColumnName].MaxLength = 6; // �d����4
            band.Columns[table.SalesUnitCost4Column.ColumnName].MaxLength = 10; // ���P��4
            band.Columns[table.PriceStartDate5Column.ColumnName].MaxLength = 8; // ���i�J�n��5
            band.Columns[table.ListPrice5Column.ColumnName].MaxLength = 7; // ���i5
            band.Columns[table.StockRate5Column.ColumnName].MaxLength = 6; // �d����5
            band.Columns[table.SalesUnitCost5Column.ColumnName].MaxLength = 10; // ���P��5

            // --- ADD 2010/08/11 ----------<<<<<
            band.Columns[table.PriceFlColumn.ColumnName].MaxLength = 9; // ���[�U�[���i
            band.Columns[table.UpRateColumn.ColumnName].MaxLength = 6; // UP��
            band.Columns[table.WarehouseCodeColumn.ColumnName].MaxLength = 4; // �q�ɃR�[�h
            band.Columns[table.WarehouseNameColumn.ColumnName].MaxLength = 10; // �q�ɖ�
            // --- ADD 2009/03/10 -------------------------------->>>>>
            band.Columns[table.SectionCodeColumn.ColumnName].MaxLength = 2; // �Ǘ����_�R�[�h
            band.Columns[table.SectionGuideSnmColumn.ColumnName].MaxLength = 10; // �Ǘ����_��
            // --- ADD 2009/03/10 --------------------------------<<<<<
            band.Columns[table.WarehouseShelfNoColumn.ColumnName].MaxLength = 8; // �I��
            band.Columns[table.DuplicationShelfNo1Column.ColumnName].MaxLength = 8; // �d���I��1
            band.Columns[table.DuplicationShelfNo2Column.ColumnName].MaxLength = 8; // �d���I��2
            band.Columns[table.PartsManagementDivide1Column.ColumnName].MaxLength = 1; // �Ǘ��敪1
            band.Columns[table.PartsManagementDivide2Column.ColumnName].MaxLength = 1; // �Ǘ��敪2
            band.Columns[table.StockSupplierCodeColumn.ColumnName].MaxLength = 6; // ������R�[�h
            band.Columns[table.StockSupplierSnmColumn.ColumnName].MaxLength = 20; // �����於
            band.Columns[table.SalesOrderUnitColumn.ColumnName].MaxLength = 6; // �������b�g
            band.Columns[table.MinimumStockCntColumn.ColumnName].MaxLength = 9; // �Œ�݌ɐ�
            band.Columns[table.MaximumStockCntColumn.ColumnName].MaxLength = 9; // �ő�݌ɐ�
            band.Columns[table.SupplierStockColumn.ColumnName].MaxLength = 9; // �d���݌ɐ�
            band.Columns[table.ArrivalCntColumn.ColumnName].MaxLength = 9; // ���א�
            band.Columns[table.ShipmentCntColumn.ColumnName].MaxLength = 9; // �o�א�
            band.Columns[table.AcpOdrCountColumn.ColumnName].MaxLength = 9; // �󒍐�
            band.Columns[table.MovingSupliStockColumn.ColumnName].MaxLength = 9; // �ړ����d���݌ɐ�
            band.Columns[table.NowStockCntColumn.ColumnName].MaxLength = 9; // ���݌ɐ�
            // --- ADD 2009/03/05 -------------------------------->>>>>
            band.Columns[table.StockUnitPriceRateColumn.ColumnName].MaxLength = 6;
            band.Columns[table.StockUnitPriceFlColumn.ColumnName].MaxLength = 9;
            // --- ADD 2009/03/05 --------------------------------<<<<<

            // �\���ʒu(horizon)
            band.Columns[table.RowNumberColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // �s�ԍ�
            band.Columns[table.GoodsDeleteDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // ���i�폜��
            band.Columns[table.StockDeleteDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �݌ɍ폜��
            band.Columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �i��
            band.Columns[table.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �i��
            band.Columns[table.GoodsMakerColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���[�J�[�R�[�h
            //band.Columns[table.GoodsMakerNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���[�J�[���� // DEL 2009/02/03
            band.Columns[table.GoodsMakerNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // ���[�J�[���� // ADD 2009/02/03
            // --- DEL 2010/06/08 ---------->>>>>
            //band.Columns[table.GoodsNameKanaColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �i���J�i
            // --- DEL 2010/06/08 ----------<<<<<
            band.Columns[table.JanColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // JAN�R�[�h
            band.Columns[table.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // BL�R�[�h
            band.Columns[table.BLGoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // BL�R�[�h��
            band.Columns[table.EnterpriseGanreCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���i�敪
            band.Columns[table.EnterpriseGanreNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // ���i�敪��
            band.Columns[table.GoodsRateRankColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �w��
            band.Columns[table.GoodsKindCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // ���i����
            band.Columns[table.TaxationDivCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �ېŋ敪
            band.Columns[table.GoodsMGroupColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���i������
            band.Columns[table.GoodsMGroupNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // ���i�����ޖ�
            band.Columns[table.BLGroupCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // �O���[�v�R�[�h
            band.Columns[table.BLGroupNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �O���[�v�R�[�h��
            band.Columns[table.PriceStartDate1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���i�J�n��1
            band.Columns[table.ListPrice1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���i1
            band.Columns[table.OpenPriceDiv1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �I�[�v�����i�敪1
            band.Columns[table.StockRate1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // �d����1
            band.Columns[table.SalesUnitCost1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���P��1
            band.Columns[table.PriceStartDate2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���i�J�n��2
            band.Columns[table.ListPrice2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���i2
            band.Columns[table.OpenPriceDiv2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �I�[�v�����i�敪2
            band.Columns[table.StockRate2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // �d����2
            band.Columns[table.SalesUnitCost2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���P��2
            band.Columns[table.PriceStartDate3Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���i�J�n��3
            band.Columns[table.ListPrice3Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���i3
            band.Columns[table.OpenPriceDiv3Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �I�[�v�����i�敪3
            band.Columns[table.StockRate3Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // �d����3
            band.Columns[table.SalesUnitCost3Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���P��3
            // --- ADD 2010/08/11 ---------->>>>>
            band.Columns[table.PriceStartDate4Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���i�J�n��4
            band.Columns[table.ListPrice4Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���i4
            band.Columns[table.OpenPriceDiv4Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �I�[�v�����i�敪4
            band.Columns[table.StockRate4Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // �d����4
            band.Columns[table.SalesUnitCost4Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���P��4
            band.Columns[table.PriceStartDate5Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���i�J�n��5
            band.Columns[table.ListPrice5Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���i5
            band.Columns[table.OpenPriceDiv5Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �I�[�v�����i�敪5
            band.Columns[table.StockRate5Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // �d����5
            band.Columns[table.SalesUnitCost5Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���P��5
            // --- ADD 2010/08/11 ----------<<<<<
            band.Columns[table.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���[�U�[���i
            band.Columns[table.UpRateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // UP��
            band.Columns[table.WarehouseCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �q�ɃR�[�h
            band.Columns[table.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �q�ɖ�
            // --- ADD 2009/03/10 -------------------------------->>>>>
            band.Columns[table.SectionCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �Ǘ����_�R�[�h
            band.Columns[table.SectionGuideSnmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �Ǘ����_��
            // --- ADD 2009/03/10 --------------------------------<<<<<
            band.Columns[table.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �I��
            band.Columns[table.DuplicationShelfNo1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �d���I��1
            band.Columns[table.DuplicationShelfNo2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �d���I��2
            band.Columns[table.PartsManagementDivide1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �Ǘ��敪1
            band.Columns[table.PartsManagementDivide2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �Ǘ��敪2
            band.Columns[table.StockSupplierCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ������R�[�h
            band.Columns[table.StockSupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �����於
            band.Columns[table.StockDivColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �݌ɋ敪
            band.Columns[table.SalesOrderUnitColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // �������b�g
            band.Columns[table.MinimumStockCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // �Œ�݌ɐ�
            band.Columns[table.MaximumStockCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // �ő�݌ɐ�
            band.Columns[table.SupplierStockColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // �d���݌ɐ�
            band.Columns[table.ArrivalCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���א�
            band.Columns[table.ShipmentCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // �o�א�
            band.Columns[table.AcpOdrCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // �󒍐�
            band.Columns[table.MovingSupliStockColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // �ړ����d���݌ɐ�
            band.Columns[table.NowStockCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right; // ���݌ɐ�
            // --- ADD 2009/03/05 -------------------------------->>>>>
            band.Columns[table.StockUnitPriceRateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns[table.StockUnitPriceFlColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            // --- ADD 2009/03/05 --------------------------------<<<<<
            band.Columns[table.ErrorMessageColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left; // �G���[���b�Z�[�W

            // ���X�g�{�b�N�X�ݒ�
            ValueList valueList = new ValueList();
            valueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

            // ���i����
            valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "����"); // DEL 2010/08/11
            //valueList.ValueListItems.Add(1, "���̑�"); // DEL 2010/08/11
            //band.Columns[table.GoodsKindCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList; // DEL 2010/08/11
            valueList.ValueListItems.Add(0, "0:����"); // ADD 2010/08/11
            valueList.ValueListItems.Add(1, "1:���̑�"); // ADD 2010/08/11
            band.Columns[table.GoodsKindCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown; // ADD 2010/08/11
            band.Columns[table.GoodsKindCodeColumn.ColumnName].ValueList = valueList.Clone();

            // �ېŋ敪
            valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "�O��"); // DEL 2010/08/11
            //valueList.ValueListItems.Add(1, "��ې�"); // DEL 2010/08/11
            //band.Columns[table.TaxationDivCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList; // DEL 2010/08/11
            valueList.ValueListItems.Add(0, "0:�O��");  // ADD 2010/08/11
            valueList.ValueListItems.Add(1, "1:��ې�"); // ADD 2010/08/11
            band.Columns[table.TaxationDivCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown; // ADD 2010/08/11
            band.Columns[table.TaxationDivCdColumn.ColumnName].ValueList = valueList.Clone();

            // �I�[�v�����i�敪1
            valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "�ʏ�"); // DEL 2010/08/11
            //valueList.ValueListItems.Add(1, "�I�[�v�����i"); // DEL 2010/08/11
            //band.Columns[table.OpenPriceDiv1Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList; // DEL 2010/08/11
            valueList.ValueListItems.Add(0, "0:�ʏ�"); // ADD 2010/08/11
            valueList.ValueListItems.Add(1, "1:�I�[�v�����i"); // ADD 2010/08/11
            band.Columns[table.OpenPriceDiv1Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown; // ADD 2010/08/11
            band.Columns[table.OpenPriceDiv1Column.ColumnName].ValueList = valueList.Clone();

            // �I�[�v�����i�敪2
            valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "�ʏ�"); // DEL 2010/08/11
            //valueList.ValueListItems.Add(1, "�I�[�v�����i"); // DEL 2010/08/11
            //band.Columns[table.OpenPriceDiv2Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList; // DEL 2010/08/11
            valueList.ValueListItems.Add(0, "0:�ʏ�"); // ADD 2010/08/11
            valueList.ValueListItems.Add(1, "1:�I�[�v�����i"); // ADD 2010/08/11
            band.Columns[table.OpenPriceDiv2Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown; // ADD 2010/08/11
            band.Columns[table.OpenPriceDiv2Column.ColumnName].ValueList = valueList.Clone();

            // �I�[�v�����i�敪3
            valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "�ʏ�"); // DEL 2010/08/11
            //valueList.ValueListItems.Add(1, "�I�[�v�����i"); // DEL 2010/08/11
            //band.Columns[table.OpenPriceDiv3Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList; // DEL 2010/08/11
            valueList.ValueListItems.Add(0, "0:�ʏ�"); // ADD 2010/08/11
            valueList.ValueListItems.Add(1, "1:�I�[�v�����i"); // ADD 2010/08/11
            band.Columns[table.OpenPriceDiv3Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown; // ADD 2010/08/11
            band.Columns[table.OpenPriceDiv3Column.ColumnName].ValueList = valueList.Clone();

            // --- ADD 2010/08/11 ---------->>>>>
            // �I�[�v�����i�敪4
            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, "0:�ʏ�");
            valueList.ValueListItems.Add(1, "1:�I�[�v�����i");
            band.Columns[table.OpenPriceDiv4Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            band.Columns[table.OpenPriceDiv4Column.ColumnName].ValueList = valueList.Clone();

            // �I�[�v�����i�敪5
            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, "0:�ʏ�");
            valueList.ValueListItems.Add(1, "1:�I�[�v�����i");
            band.Columns[table.OpenPriceDiv5Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            band.Columns[table.OpenPriceDiv5Column.ColumnName].ValueList = valueList.Clone();

            // --- ADD 2010/08/11 ----------<<<<<

            // �݌ɋ敪
            valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "����"); // DEL 2010/08/11
            //valueList.ValueListItems.Add(1, "���"); // DEL 2010/08/11
            //band.Columns[table.StockDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList; // DEL 2010/08/11
            valueList.ValueListItems.Add(0, "0:����"); // ADD 2010/08/11
            valueList.ValueListItems.Add(1, "1:���"); // ADD 2010/08/11
            band.Columns[table.StockDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown; // ADD 2010/08/11
            band.Columns[table.StockDivColumn.ColumnName].ValueList = valueList.Clone();

            // �t�H�[�}�b�g�ݒ�
            string deleteDateFormat = "yy/MM/dd"; // �폜���t
            string intCommaFormat = "#,##0"; // �R���}�t�������t�H�[�}�b�g
            string decCommaFormat = "#,##0.00"; // �R���}�t�������_2�ʃt�H�[�}�b�g
            string decNoCommaFormat = "0.00"; // �R���}���������_2�ʃt�H�[�}�b�g

            band.Columns[table.GoodsDeleteDateColumn.ColumnName].Format = deleteDateFormat;	// ���i�폜��
            band.Columns[table.StockDeleteDateColumn.ColumnName].Format = deleteDateFormat;	// �݌ɍ폜��
            band.Columns[table.GoodsMakerColumn.ColumnName].Format = "0000"; // ���[�J�[�R�[�h
            band.Columns[table.BLGoodsCodeColumn.ColumnName].Format = "00000"; // BL�R�[�h
            band.Columns[table.EnterpriseGanreCodeColumn.ColumnName].Format = "0000"; // ���i�敪
            band.Columns[table.GoodsMGroupColumn.ColumnName].Format = "0000"; // ���i������
            band.Columns[table.BLGroupCodeColumn.ColumnName].Format = "00000"; // �O���[�v�R�[�h
            band.Columns[table.ListPrice1Column.ColumnName].Format = intCommaFormat; // ���i1
            band.Columns[table.StockRate1Column.ColumnName].Format = decNoCommaFormat; // �d����1
            band.Columns[table.SalesUnitCost1Column.ColumnName].Format = decCommaFormat; // ���P��1
            band.Columns[table.ListPrice2Column.ColumnName].Format = intCommaFormat; // ���i2
            band.Columns[table.StockRate2Column.ColumnName].Format = decNoCommaFormat; // �d����2
            band.Columns[table.SalesUnitCost2Column.ColumnName].Format = decCommaFormat; // ���P��2
            band.Columns[table.ListPrice3Column.ColumnName].Format = intCommaFormat; // ���i3
            band.Columns[table.StockRate3Column.ColumnName].Format = decNoCommaFormat; // �d����3
            band.Columns[table.SalesUnitCost3Column.ColumnName].Format = decCommaFormat; // ���P��3
            // --- ADD 2010/08/11 ---------->>>>>
            band.Columns[table.ListPrice4Column.ColumnName].Format = intCommaFormat; // ���i4
            band.Columns[table.StockRate4Column.ColumnName].Format = decNoCommaFormat; // �d����4
            band.Columns[table.SalesUnitCost4Column.ColumnName].Format = decCommaFormat; // ���P��4
            band.Columns[table.ListPrice5Column.ColumnName].Format = intCommaFormat; // ���i5
            band.Columns[table.StockRate5Column.ColumnName].Format = decNoCommaFormat; // �d����5
            band.Columns[table.SalesUnitCost5Column.ColumnName].Format = decCommaFormat; // ���P��5

            // --- ADD 2010/08/11 ----------<<<<<
            band.Columns[table.PriceFlColumn.ColumnName].Format = intCommaFormat; // ���[�U�[���i
            band.Columns[table.UpRateColumn.ColumnName].Format = decNoCommaFormat; // UP��
            band.Columns[table.WarehouseCodeColumn.ColumnName].Format = "0000"; // �q�ɃR�[�h
            band.Columns[table.SectionCodeColumn.ColumnName].Format = "00"; // �Ǘ����_�R�[�h // ADD 2009/03/10
            band.Columns[table.StockSupplierCodeColumn.ColumnName].Format = "000000";
            band.Columns[table.SalesOrderUnitColumn.ColumnName].Format = intCommaFormat; // �������b�g
            band.Columns[table.MinimumStockCntColumn.ColumnName].Format = decCommaFormat; // �Œ�݌ɐ�
            band.Columns[table.MaximumStockCntColumn.ColumnName].Format = decCommaFormat; // �ő�݌ɐ�
            band.Columns[table.SupplierStockColumn.ColumnName].Format = decCommaFormat; // �d���݌ɐ�
            band.Columns[table.ArrivalCntColumn.ColumnName].Format = decCommaFormat; // ���א�
            band.Columns[table.ShipmentCntColumn.ColumnName].Format = decCommaFormat; // �o�א�
            band.Columns[table.AcpOdrCountColumn.ColumnName].Format = decCommaFormat; // �󒍐�
            band.Columns[table.MovingSupliStockColumn.ColumnName].Format = decCommaFormat; // �ړ����d���݌ɐ�
            band.Columns[table.NowStockCntColumn.ColumnName].Format = decCommaFormat; // ���݌ɐ�
            // --- ADD 2009/03/05 -------------------------------->>>>>
            band.Columns[table.StockUnitPriceRateColumn.ColumnName].Format = decCommaFormat;
            band.Columns[table.StockUnitPriceFlColumn.ColumnName].Format = decCommaFormat;
            // --- ADD 2009/03/05 --------------------------------<<<<<

            // �Z���̌���
            List<string> mergedColumnList = new List<string>();
            mergedColumnList.Add(table.GoodsDeleteDateColumn.ColumnName);
            mergedColumnList.Add(table.GoodsNoColumn.ColumnName);
            mergedColumnList.Add(table.GoodsNameColumn.ColumnName);
            mergedColumnList.Add(table.GoodsMakerColumn.ColumnName);
            mergedColumnList.Add(table.GoodsMakerNameColumn.ColumnName);
            // --- DEL 2010/06/08 ---------->>>>>
            //mergedColumnList.Add(table.GoodsNameKanaColumn.ColumnName);
            // --- DEL 2010/06/08 ----------<<<<<
            mergedColumnList.Add(table.JanColumn.ColumnName);
            mergedColumnList.Add(table.BLGoodsCodeColumn.ColumnName);
            mergedColumnList.Add(table.BLGoodsNameColumn.ColumnName);
            mergedColumnList.Add(table.EnterpriseGanreCodeColumn.ColumnName);
            mergedColumnList.Add(table.EnterpriseGanreNameColumn.ColumnName);
            mergedColumnList.Add(table.GoodsRateRankColumn.ColumnName);
            mergedColumnList.Add(table.GoodsKindCodeColumn.ColumnName);
            mergedColumnList.Add(table.TaxationDivCdColumn.ColumnName);
            mergedColumnList.Add(table.GoodsMGroupColumn.ColumnName);
            mergedColumnList.Add(table.GoodsMGroupNameColumn.ColumnName);
            mergedColumnList.Add(table.BLGroupCodeColumn.ColumnName);
            mergedColumnList.Add(table.BLGroupNameColumn.ColumnName);
            mergedColumnList.Add(table.PriceStartDate1Column.ColumnName);
            mergedColumnList.Add(table.ListPrice1Column.ColumnName);
            mergedColumnList.Add(table.OpenPriceDiv1Column.ColumnName);
            mergedColumnList.Add(table.StockRate1Column.ColumnName);
            mergedColumnList.Add(table.SalesUnitCost1Column.ColumnName);
            mergedColumnList.Add(table.PriceStartDate2Column.ColumnName);
            mergedColumnList.Add(table.ListPrice2Column.ColumnName);
            mergedColumnList.Add(table.OpenPriceDiv2Column.ColumnName);
            mergedColumnList.Add(table.StockRate2Column.ColumnName);
            mergedColumnList.Add(table.SalesUnitCost2Column.ColumnName);
            mergedColumnList.Add(table.PriceStartDate3Column.ColumnName);
            mergedColumnList.Add(table.ListPrice3Column.ColumnName);
            mergedColumnList.Add(table.OpenPriceDiv3Column.ColumnName);
            mergedColumnList.Add(table.StockRate3Column.ColumnName);
            mergedColumnList.Add(table.SalesUnitCost3Column.ColumnName);
            // --- ADD 2010/08/11 ---------->>>>>
            mergedColumnList.Add(table.PriceStartDate4Column.ColumnName);
            mergedColumnList.Add(table.ListPrice4Column.ColumnName);
            mergedColumnList.Add(table.OpenPriceDiv4Column.ColumnName);
            mergedColumnList.Add(table.StockRate4Column.ColumnName);
            mergedColumnList.Add(table.SalesUnitCost4Column.ColumnName);
            mergedColumnList.Add(table.PriceStartDate5Column.ColumnName);
            mergedColumnList.Add(table.ListPrice5Column.ColumnName);
            mergedColumnList.Add(table.OpenPriceDiv5Column.ColumnName);
            mergedColumnList.Add(table.StockRate5Column.ColumnName);
            mergedColumnList.Add(table.SalesUnitCost5Column.ColumnName);

            // --- ADD 2010/08/11 ----------<<<<<
            mergedColumnList.Add(table.PriceFlColumn.ColumnName);
            mergedColumnList.Add(table.UpRateColumn.ColumnName);

            foreach (string key in mergedColumnList)
            {
                band.Columns[key].MergedCellStyle = MergedCellStyle.Always;
                band.Columns[key].MergedCellContentArea = MergedCellContentArea.VisibleRect;
                band.Columns[key].MergedCellEvaluator = new CustomMergedCellEvaluatorGoods();
                band.Columns[key].MergedCellAppearance.BackGradientStyle = GradientStyle.None;
            }
        }

        /// <summary>
        /// �O���b�h��\����\���ݒ�
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote       : 2010/06/08 ���� ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
        /// </remarks>
        private void SetGridColSetting()
        {
            ExtractInfo extractInfo = this.GetExtractInfo();

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];
            if (band == null) return;

            GoodsStockDataSet.GoodsStockDataTable table = this._goodsStockDataTable;

            #region �� ���͉ېݒ�
            // �i�ԁA���[�J�[�A�q�ɂ͍s���Ƃɓ��͉ۂ𐧌䂷�邽�߁A�����ł͐ݒ肵�Ȃ�

            // �i����̐ݒ�
            if (extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            {
                band.Columns[table.GoodsNameColumn.ColumnName].CellActivation = Activation.Disabled; // �i��
            }
            else
            {
                band.Columns[table.GoodsNameColumn.ColumnName].CellActivation = Activation.AllowEdit; // �i��
            }
            #endregion

            #region �� �\���E��\���ݒ�
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in band.Columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                col.Hidden = true;
            }
            
            if (
                (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods) // �V�K�o�^-���i
                ||
                (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods) // �C���o�^-���i
                )
            {
                band.Columns[table.RowNumberColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsNoColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsNameColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMakerColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMakerNameColumn.ColumnName].Hidden = false;
                // --- DEL 2010/06/08 ---------->>>>>
                //band.Columns[table.GoodsNameKanaColumn.ColumnName].Hidden = false;
                // --- DEL 2010/06/08 ----------<<<<<
                band.Columns[table.JanColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGoodsCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGoodsNameColumn.ColumnName].Hidden = false;
                band.Columns[table.EnterpriseGanreCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.EnterpriseGanreNameColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsRateRankColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsKindCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.TaxationDivCdColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMGroupColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMGroupNameColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGroupCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGroupNameColumn.ColumnName].Hidden = false;


                band.Columns[table.PriceStartDate1Column.ColumnName].Hidden = false;
                band.Columns[table.ListPrice1Column.ColumnName].Hidden = false;
                band.Columns[table.OpenPriceDiv1Column.ColumnName].Hidden = false;
                band.Columns[table.StockRate1Column.ColumnName].Hidden = false;
                band.Columns[table.SalesUnitCost1Column.ColumnName].Hidden = false;

                if (this._goodsStockAcs.RateProtyMngExist)
                {
                    // �|���D��Ǘ���񂪂���Ε\��
                    band.Columns[table.PriceFlColumn.ColumnName].Hidden = false;
                    band.Columns[table.UpRateColumn.ColumnName].Hidden = false;
                }
            }
            else if (
                (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock) // �V�K�o�^-�݌�
                ||
            (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock) // �C���o�^-�݌�
                )
            {
                band.Columns[table.RowNumberColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsNoColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsNameColumn.ColumnName].Hidden = false;

                // --- ADD 2009/03/10 -------------------------------->>>>>
                band.Columns[table.SectionCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.SectionGuideSnmColumn.ColumnName].Hidden = false;
                // --- ADD 2009/03/10 --------------------------------<<<<<
                band.Columns[table.WarehouseShelfNoColumn.ColumnName].Hidden = false;
                band.Columns[table.DuplicationShelfNo1Column.ColumnName].Hidden = false;
                band.Columns[table.DuplicationShelfNo2Column.ColumnName].Hidden = false;
                band.Columns[table.PartsManagementDivide1Column.ColumnName].Hidden = false;
                band.Columns[table.PartsManagementDivide2Column.ColumnName].Hidden = false;
                band.Columns[table.StockSupplierCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.StockSupplierSnmColumn.ColumnName].Hidden = false;
                band.Columns[table.StockDivColumn.ColumnName].Hidden = false;
                band.Columns[table.SalesOrderUnitColumn.ColumnName].Hidden = false;
                band.Columns[table.MinimumStockCntColumn.ColumnName].Hidden = false;
                band.Columns[table.MaximumStockCntColumn.ColumnName].Hidden = false;
                band.Columns[table.SupplierStockColumn.ColumnName].Hidden = false;
                band.Columns[table.ArrivalCntColumn.ColumnName].Hidden = false;
                band.Columns[table.ShipmentCntColumn.ColumnName].Hidden = false;
                band.Columns[table.AcpOdrCountColumn.ColumnName].Hidden = false;
                band.Columns[table.MovingSupliStockColumn.ColumnName].Hidden = false;
                band.Columns[table.NowStockCntColumn.ColumnName].Hidden = false;
                // --- ADD 2009/03/05 -------------------------------->>>>>
                band.Columns[table.StockUnitPriceRateColumn.ColumnName].Hidden = false;
                band.Columns[table.StockUnitPriceFlColumn.ColumnName].Hidden = false;
                // --- ADD 2009/03/05 --------------------------------<<<<<
            }
            else
            {
                // �C���o�^-���i�݌ɁA�݌ɏ��i
                band.Columns[table.RowNumberColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsNoColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsNameColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMakerColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMakerNameColumn.ColumnName].Hidden = false;

                // ���i���
                // --- DEL 2010/06/08 ---------->>>>>
                //band.Columns[table.GoodsNameKanaColumn.ColumnName].Hidden = false;
                // --- DEL 2010/06/08 ----------<<<<<
                band.Columns[table.JanColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGoodsCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGoodsNameColumn.ColumnName].Hidden = false;
                band.Columns[table.EnterpriseGanreCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.EnterpriseGanreNameColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsRateRankColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsKindCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.TaxationDivCdColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMGroupColumn.ColumnName].Hidden = false;
                band.Columns[table.GoodsMGroupNameColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGroupCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.BLGroupNameColumn.ColumnName].Hidden = false;

                band.Columns[table.PriceStartDate1Column.ColumnName].Hidden = false;
                band.Columns[table.ListPrice1Column.ColumnName].Hidden = false;
                band.Columns[table.OpenPriceDiv1Column.ColumnName].Hidden = false;
                band.Columns[table.StockRate1Column.ColumnName].Hidden = false;
                band.Columns[table.SalesUnitCost1Column.ColumnName].Hidden = false;

                if (this._goodsStockAcs.RateProtyMngExist)
                {
                    // �|���D��Ǘ���񂪂���Ε\��
                    band.Columns[table.PriceFlColumn.ColumnName].Hidden = false;
                    band.Columns[table.UpRateColumn.ColumnName].Hidden = false;
                }

                // �݌ɏ��
                band.Columns[table.WarehouseCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.WarehouseNameColumn.ColumnName].Hidden = false;
                // --- ADD 2009/03/10 -------------------------------->>>>>
                band.Columns[table.SectionCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.SectionGuideSnmColumn.ColumnName].Hidden = false;
                // --- ADD 2009/03/10 --------------------------------<<<<<
                band.Columns[table.WarehouseShelfNoColumn.ColumnName].Hidden = false;
                band.Columns[table.DuplicationShelfNo1Column.ColumnName].Hidden = false;
                band.Columns[table.DuplicationShelfNo2Column.ColumnName].Hidden = false;
                band.Columns[table.PartsManagementDivide1Column.ColumnName].Hidden = false;
                band.Columns[table.PartsManagementDivide2Column.ColumnName].Hidden = false;
                band.Columns[table.StockSupplierCodeColumn.ColumnName].Hidden = false;
                band.Columns[table.StockSupplierSnmColumn.ColumnName].Hidden = false;
                band.Columns[table.StockDivColumn.ColumnName].Hidden = false;
                band.Columns[table.SalesOrderUnitColumn.ColumnName].Hidden = false;
                band.Columns[table.MinimumStockCntColumn.ColumnName].Hidden = false;
                band.Columns[table.MaximumStockCntColumn.ColumnName].Hidden = false;
                band.Columns[table.SupplierStockColumn.ColumnName].Hidden = false;
                band.Columns[table.ArrivalCntColumn.ColumnName].Hidden = false;
                band.Columns[table.ShipmentCntColumn.ColumnName].Hidden = false;
                band.Columns[table.AcpOdrCountColumn.ColumnName].Hidden = false;
                band.Columns[table.MovingSupliStockColumn.ColumnName].Hidden = false;
                band.Columns[table.NowStockCntColumn.ColumnName].Hidden = false;
                // --- ADD 2009/03/05 -------------------------------->>>>>
                band.Columns[table.StockUnitPriceRateColumn.ColumnName].Hidden = false;
                band.Columns[table.StockUnitPriceFlColumn.ColumnName].Hidden = false;
                // --- ADD 2009/03/05 --------------------------------<<<<<
            }

            #endregion

            // --- ADD 2009/02/23 -------------------------------->>>>>
            #region �N���b�N�����쐧��
            if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                band.Columns[table.GoodsNoColumn.ColumnName].CellClickAction = CellClickAction.Edit;
                band.Columns[table.GoodsMakerColumn.ColumnName].CellClickAction = CellClickAction.Edit;
            }
            else
            {
                // �i�ԁA���[�J�[���I��s�Ȃ̂ōs�Z���N�g
                band.Columns[table.GoodsNoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
                band.Columns[table.GoodsMakerColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            }

            if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                band.Columns[table.WarehouseCodeColumn.ColumnName].CellClickAction = CellClickAction.Edit;
            }
            else
            {
                // �q�ɂ��I��s�Ȃ̂ōs�Z���N�g
                band.Columns[table.WarehouseCodeColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            }
            #endregion
            // --- ADD 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// ���׃O���b�h�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>�ŐV�̒��o�������Q�Ƃ���ׁA���������⌟�����s���ȊO�͎g�p�s��</br>
        /// </remarks>
        internal void SetGridSettings()
        {
            try
            {
                // �`����ꎞ��~
                this.uGrid_Details.BeginUpdate();

                this.tToolbarsManager_Main.Enabled = true;

                // �{�^���\���A��\���ݒ菈��
                this.SetButtonEnableByExtactInfo();

                // �O���b�h��\����\���ݒ菈��
                this.SetGridColSetting();

                // �O���b�h�w�i�F�ݒ�
                this.SetGridColorAll();
            }
            finally
            {
                // �`����J�n
                this.uGrid_Details.EndUpdate();
            }
        }
        #endregion

        #region �� �w�i�F�ݒ�
        /// <summary>
        /// �e�f�[�^�̏�Ԃɉ������w�i�F��ݒ�
        /// </summary>
        /// <remarks>
        /// <br>���L�̗D�揇�ŐF�ݒ�</br>
        /// <br>�폜�s�F��</br>
        /// <br>�X�V�s�F�W��</br>
        /// <br>�݌ɓo�^����Ă��鏤�i�F�s���N</br>
        /// </remarks>
        private void SetGridColorAll()
        {
            UltraGridRow dr;

            for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
            {
                dr = this.uGrid_Details.Rows[i];

                this.SetGridColorRow(dr);
            }
        }

        /// <summary>
        /// �e�f�[�^�̏�Ԃɉ������w�i�F��ݒ�
        /// </summary>
        /// <remarks>
        /// <br>���L�̗D�揇�ŐF�ݒ�</br>
        /// <br>�폜�s�F��</br>
        /// <br>�X�V�s�F�W��</br>
        /// <br>�݌ɓo�^����Ă��鏤�i�F�s���N</br>
        /// </remarks>
        private void SetGridColorRow(UltraGridRow dr)
        {
            // �s�ԍ��Z���̐ݒ�(�X�V�G���[���̂ݐԐF)
            if ((int)dr.Cells[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName].Value == 0)
            {
                // ����
                dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Appearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
                dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Appearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);

                // --- ADD 2009/03/06 -------------------------------->>>>>
                // �폜�\��s�̂ݐF�ύX
                if (dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() != "�V�K"
                    &&
                    ((int)dr.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                    && (int)dr.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0))
                {
                    if (
                        ((int)dr.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                        && (int)dr.Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value != 0)
                        ||
                        ((int)dr.Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value != 0
                        && (int)dr.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0)
                        )
                    {
                        // �폜�\��s�̓s���N
                        dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Appearance.BackColorDisabled = Color.Pink;
                        dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Pink;
                    }
                }
                // --- ADD 2009/03/06 --------------------------------<<<<<
            }
            else
            {
                // �X�V�G���[
                dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Appearance.BackColorDisabled = Color.Red;
                dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Red;
            }

            if (dr.Selected)
            {
                // �I���s�̏ꍇ
                foreach (UltraGridCell cell in dr.Cells)
                {
                    if (cell.Column.Key != this._goodsStockDataTable.RowNumberColumn.ColumnName)
                    {
                        // �����s��Active�Z���F�ŏ㏑��
                        cell.Appearance.BackColor = Color.FromArgb(251, 230, 148);
                        cell.Appearance.BackColor2 = Color.FromArgb(238, 149, 21);
                        cell.Appearance.BackColorDisabled = Color.FromArgb(251, 230, 148);
                        cell.Appearance.BackColorDisabled2 = Color.FromArgb(238, 149, 21);
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                    }
                }

                
            }
            else
            {
                // �ʏ�F�ݒ�
                if (dr.Index % 2 == 0)
                {
                    foreach (UltraGridCell cell in dr.Cells)
                    {
                        if (cell.Column.Key != this._goodsStockDataTable.RowNumberColumn.ColumnName)
                        {
                            cell.Appearance.BackColor = Color.White;
                            cell.Appearance.BackColor2 = Color.White;
                            cell.Appearance.BackColorDisabled = Color.White;
                            cell.Appearance.BackColorDisabled2 = Color.White;
                        }
                    }

                }
                else
                {
                    foreach (UltraGridCell cell in dr.Cells)
                    {
                        if (cell.Column.Key != this._goodsStockDataTable.RowNumberColumn.ColumnName)
                        {
                            cell.Appearance.BackColor = Color.Lavender;
                            cell.Appearance.BackColor2 = Color.Lavender;
                            cell.Appearance.BackColorDisabled = Color.Lavender;
                            cell.Appearance.BackColorDisabled2 = Color.Lavender;
                        }
                    }
                }

                // �ǉ��s�͑ΏۊO(�ʏ�F�ǂ���)
                if (dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() == "�V�K")
                {
                    return;
                }

                // �_���폜�s�͑ΏۊO
                if ((int)dr.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value != 0
                    || (int)dr.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value != 0)
                {
                    return;
                }

                // ��Ԃɂ���ď㏑��
                //if (dr.Cells[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value != null
                //    && dr.Cells[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value != DBNull.Value
                //    && (int)dr.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0) // DEL 2009/02/05
                if ((int)dr.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                    && (int)dr.Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value != 0) // ADD 2009/02/05
                {
                    // ���i�폜�\��s
                    foreach (UltraGridCell cell in dr.Cells)
                    {
                        //if (cell.Column.Key != this._goodsStockDataTable.RowNumberColumn.ColumnName) // DEL 2009/03/06
                        //{
                        // --- DEL 2009/03/06 -------------------------------->>>>>
                        //cell.Appearance.BackColor = Color.Red;
                        //cell.Appearance.BackColor2 = Color.Red;
                        //cell.Appearance.BackColorDisabled = Color.Red;
                        //cell.Appearance.BackColorDisabled2 = Color.Red;
                        // --- DEL 2009/03/06 --------------------------------<<<<<
                        // --- ADD 2009/03/06 -------------------------------->>>>>
                        cell.Appearance.BackColor = Color.Pink;
                        cell.Appearance.BackColor2 = Color.Pink;
                        cell.Appearance.BackColorDisabled = Color.Pink;
                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                        // --- ADD 2009/03/06 --------------------------------<<<<<
                        //}
                    }

                    return;
                }
                //else if (dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value != null
                //    && dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value != DBNull.Value
                //    && (int)dr.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0) // DEL 2009/02/05
                else if ((int)dr.Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value != 0
                    && (int)dr.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0) // ADD 2009/02/05
                {
                    // �݌ɍ폜�\��s
                    // �q�ɃR�[�h�ȍ~�̔w�i�F��ύX
                    int warehouseColIndex = this.uGrid_Details.DisplayLayout.Bands[0]
                        .Columns[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;

                    // --- ADD 2009/03/06 -------------------------------->>>>>
                    // �s�ԍ����ݒ�
                    dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName]
                        .Appearance.BackColor = Color.Pink;
                    dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName]
                        .Appearance.BackColor2 = Color.Pink;
                    dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName]
                        .Appearance.BackColorDisabled = Color.Pink;
                    dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName]
                        .Appearance.BackColorDisabled2 = Color.Pink;
                    // --- ADD 2009/03/06 --------------------------------<<<<<

                    // �݌ɍ폜�����ݒ�
                    // --- DEL 2009/03/06 -------------------------------->>>>>
                    //dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                    //    .Appearance.BackColor = Color.Red;
                    //dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                    //    .Appearance.BackColor2 = Color.Red;
                    //dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                    //    .Appearance.BackColorDisabled = Color.Red;
                    //dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                    //    .Appearance.BackColorDisabled2 = Color.Red;
                    // --- DEL 2009/03/06 --------------------------------<<<<<
                    // --- ADD 2009/03/06 -------------------------------->>>>>
                    dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                        .Appearance.BackColor = Color.Pink;
                    dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                        .Appearance.BackColor2 = Color.Pink;
                    dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                        .Appearance.BackColorDisabled = Color.Pink;
                    dr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName]
                        .Appearance.BackColorDisabled2 = Color.Pink;
                    // --- ADD 2009/03/06 --------------------------------<<<<<

                    if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
                    {
                        // �Ώۋ敪�u�݌Ɂv�̏ꍇ�A�i�ԁA�i�����ݒ�
                        // --- DEL 2009/03/06 -------------------------------->>>>>
                        //dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                        //.Appearance.BackColor = Color.Red;
                        //dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                        //    .Appearance.BackColor2 = Color.Red;
                        //dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                        //    .Appearance.BackColorDisabled = Color.Red;
                        //dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                        //    .Appearance.BackColorDisabled2 = Color.Red;

                        //dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                        //.Appearance.BackColor = Color.Red;
                        //dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                        //    .Appearance.BackColor2 = Color.Red;
                        //dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                        //    .Appearance.BackColorDisabled = Color.Red;
                        //dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                        //    .Appearance.BackColorDisabled2 = Color.Red;
                        // --- DEL 2009/03/06 --------------------------------<<<<<
                        // --- ADD 2009/03/06 -------------------------------->>>>>
                        dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                        .Appearance.BackColor = Color.Pink;
                        dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                            .Appearance.BackColor2 = Color.Pink;
                        dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                            .Appearance.BackColorDisabled = Color.Pink;
                        dr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName]
                            .Appearance.BackColorDisabled2 = Color.Pink;

                        dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                        .Appearance.BackColor = Color.Pink;
                        dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                            .Appearance.BackColor2 = Color.Pink;
                        dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                            .Appearance.BackColorDisabled = Color.Pink;
                        dr.Cells[this._goodsStockDataTable.GoodsNameColumn.ColumnName]
                            .Appearance.BackColorDisabled2 = Color.Pink;
                        // --- ADD 2009/03/06 --------------------------------<<<<<
                    }

                    for (int k = warehouseColIndex; k < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; k++)
                    {
                        // --- DEL 2009/03/06 -------------------------------->>>>>
                        //dr.Cells[k].Appearance.BackColor = Color.Red;
                        //dr.Cells[k].Appearance.BackColor2 = Color.Red;
                        //dr.Cells[k].Appearance.BackColorDisabled = Color.Red;
                        //dr.Cells[k].Appearance.BackColorDisabled2 = Color.Red;
                        // --- DEL 2009/03/06 --------------------------------<<<<<
                        // --- ADD 2009/03/06 -------------------------------->>>>>
                        dr.Cells[k].Appearance.BackColor = Color.Pink;
                        dr.Cells[k].Appearance.BackColor2 = Color.Pink;
                        dr.Cells[k].Appearance.BackColorDisabled = Color.Pink;
                        dr.Cells[k].Appearance.BackColorDisabled2 = Color.Pink;
                        // --- ADD 2009/03/06 --------------------------------<<<<<
                    }
                }
                else
                {
                    if (dr.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != null
                      && dr.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != DBNull.Value)
                    {
                        if (this._beforeSearchExtractInfo.TargetDiv != ExtractInfo.TargetDivState.Stock) // ADD 2009/02/23
                        {
                            // �݌ɕێ��s�ݒ�
                            int upRateColIndex = this.uGrid_Details.DisplayLayout.Bands[0]
                                .Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index;

                            for (int m = 1; m <= upRateColIndex; m++)
                            {
                                // --- DEL 2009/03/06 -------------------------------->>>>>
                                //dr.Cells[m].Appearance.BackColor = Color.Pink;
                                //dr.Cells[m].Appearance.BackColor2 = Color.Pink;
                                //dr.Cells[m].Appearance.BackColorDisabled = Color.Pink;
                                //dr.Cells[m].Appearance.BackColorDisabled2 = Color.Pink;
                                // --- DEL 2009/03/06 --------------------------------<<<<<
                                // --- ADD 2009/03/06 -------------------------------->>>>>
                                dr.Cells[m].Appearance.BackColor = Color.Thistle;
                                dr.Cells[m].Appearance.BackColor2 = Color.Thistle;
                                dr.Cells[m].Appearance.BackColorDisabled = Color.Thistle;
                                dr.Cells[m].Appearance.BackColorDisabled2 = Color.Thistle;
                                // --- ADD 2009/03/06 --------------------------------<<<<<
                            }
                        }
                    }

                    // �X�V�Z���ݒ�
                    //DataRow originalDr = this._goodsStockAcs.OriginalGoodsStockDataTable
                    //    .Select(this._goodsStockDataTable.RowNumberColumn.ColumnName + " = '"
                    //    + dr.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() + "'")[0]; // DEL 2009/03/06
                    DataRow originalDr = this._goodsStockAcs.OriginalGoodsStockDataTable
                        .Select(this._goodsStockDataTable.RowIndexColumn.ColumnName + " = '"
                        + dr.Cells[this._goodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() + "'")[0]; // ADD 2009/03/06

                    for (int j = 0; j < this._goodsStockDataTable.Columns.Count; j++)
                    {
                        if (dr.Cells[j].Value.ToString() != originalDr[j].ToString())
                        {
                            // �G���[���e�s�͏���
                            if (dr.Cells[j].Column.Key != this._goodsStockDataTable.ErrorMessageColumn.ColumnName) // ADD 2009/03/10
                            {
                                dr.Cells[j].Appearance.BackColor = Color.Lime;
                                dr.Cells[j].Appearance.BackColor2 = Color.Lime;
                                dr.Cells[j].Appearance.BackColorDisabled = Color.Lime;
                                dr.Cells[j].Appearance.BackColorDisabled2 = Color.Lime;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region �� �{�^���\������
        /// <summary>
        /// �{�^���\����\���ݒ�
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote       : 2010/08/11 ���� ��Q���ǑΉ��i�W�����j �L�[�{�[�h����̉��ǂ��s���B</br>
        /// </remarks>
        private void SetButtonEnableByExtactInfo()
        {
            ExtractInfo extractInfo = this.GetExtractInfo();

            if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                this.tToolbarsManager_Main.Toolbars[0].Tools["Container_GoodsAdd"].SharedProps.Visible = true;
                this.uButton_RowAdd.Enabled = true; // ADD 2009/02/04
                // --- UPD 2010/08/11 -------------------------------->>>>>
                //this.uButton_RowAdd.Text = "���i�ǉ�(&I)"; // ADD 2009/03/03
                this.uButton_RowAdd.Text = "���i�ǉ�(F11)";
                // --- UPD 2010/08/11 --------------------------------<<<<<
            }
            else if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                this.tToolbarsManager_Main.Toolbars[0].Tools["Container_GoodsAdd"].SharedProps.Visible = true;
                this.uButton_RowAdd.Enabled = false; // ADD 2009/02/04
                // --- UPD 2010/08/11 -------------------------------->>>>>
                //this.uButton_RowAdd.Text = "�݌ɒǉ�(&I)"; // ADD 2009/03/03
                this.uButton_RowAdd.Text = "�݌ɒǉ�(F11)";
                // --- UPD 2010/08/11 --------------------------------<<<<<
            }
            else
            {
                this.tToolbarsManager_Main.Toolbars[0].Tools["Container_GoodsAdd"].SharedProps.Visible = false;
            }

            // --- ADD 2009/03/03 -------------------------------->>>>>
            // �폜�E�����{�^������
            if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            {
                // --- UPD 2010/08/11 -------------------------------->>>>>
                //this.uButton_RowGoodsDelete.Text = "���i��\��(&D)";
                //this.uButton_RowStockDelete.Text = "�݌ɔ�\��(&A)";
                this.uButton_RowGoodsDelete.Text = "���i��\��(F3)";
                this.uButton_RowStockDelete.Text = "�݌ɔ�\��(F6)";
                // --- UPD 2010/08/11 --------------------------------<<<<<
            }
            else
            {
                // --- UPD 2010/08/11 -------------------------------->>>>>
                //this.uButton_RowGoodsDelete.Text = "���i�폜(&D)";
                //this.uButton_RowStockDelete.Text = "�݌ɍ폜(&A)";
                this.uButton_RowGoodsDelete.Text = "���i�폜(F3)";
                this.uButton_RowStockDelete.Text = "�݌ɍ폜(F6)";
                // --- UPD 2010/08/11 --------------------------------<<<<<
            }
            // --- ADD 2009/03/03 --------------------------------<<<<<
            // --- ADD 2009/02/04 -------------------------------->>>>>
            //if (extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            //{
            //    this.uButton_RowDispPrice.Enabled = false;
            //}
            //else
            //{
            //    this.uButton_RowDispPrice.Enabled = true;
            //}
            // --- ADD 2009/02/04 --------------------------------<<<<<
        }

        /// <summary>
        /// �w��O���b�h�s�̏�Ԃɉ������{�^�������ې�����s���B
        /// </summary>
        /// <remarks>
        /// </remarks>
        //private void SetButtonEnableByRow(int rowIndex, string columnKey) // DEL 2009/02/23
        private void SetButtonEnableByCell(int rowIndex, string columnKey) // ADD 2009/02/23
        {
            #region �폜�A�����{�^������
            bool isGoodsLogicalDelete; // ���i���_���폜�ς݂�
            bool isGoodsReserveDelete; // ���i���폜�\��
            bool isStockLogicalDelete; // �݌ɂ��_���폜�ς݂�
            bool isStockReserveDelete; // �݌ɂ��폜�\��

            // �w��s�̏�Ԏ擾
            // ���i�͘_���폜��Ԃ�
            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0)
            {
                isGoodsLogicalDelete = false;
            }
            else
            {
                isGoodsLogicalDelete = true;
            }

            // ���i�͍폜�\���Ԃ�
            //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value == null
            //    || this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value == DBNull.Value) // DEL 2009/02/05
            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0) // ADD 2009/02/05
            {
                isGoodsReserveDelete = false;
            }
            else
            {
                isGoodsReserveDelete = true;
            }

            // �݌Ɏ��̂������ꍇ�����邽�߁A�vNull�`�F�b�N
            // �݌ɂ͘_���폜��Ԃ�
            if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == null
                || this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == DBNull.Value
                || (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0)
            {
                isStockLogicalDelete = false;
            }
            else
            {
                isStockLogicalDelete = true;
            }

            // �݌ɂ͍폜�\���Ԃ�
            //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value == null
            //    || this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value == DBNull.Value) // DEL 2009/02/05
            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value == 0) // ADD 2009/02/05
            {
                isStockReserveDelete = false;
            }
            else
            {
                isStockReserveDelete = true;
            }

            // --- ADD 2009/02/23 -------------------------------->>>>>
            if (isGoodsLogicalDelete) this._includeGoodsLogicalDeleted = true;
            else this._includeGoodsLogicalDeleted = false;

            if (isStockLogicalDelete) this._includeStockLogicalDeleted = true;
            else this._includeStockLogicalDeleted = false;
            // --- ADD 2009/02/23 --------------------------------<<<<<


            // �폜�E�����{�^��
            if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            {
                // �V�K�o�^
                if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods) // ���i
                {
                    // �݌Ƀ{�^���s��
                    this.uButton_RowStockDelete.Enabled = false;
                    this.uButton_RowStockRevive.Enabled = false;

                    if (isGoodsReserveDelete)
                    {
                        // �폜�\��s�Ȃ̂ŁA�폜�����s��
                        this.uButton_RowGoodsDelete.Enabled = false;
                        this.uButton_RowGoodsRevive.Enabled = true;
                    }
                    else
                    {
                        // �폜�\��\�A�����s��
                        this.uButton_RowGoodsDelete.Enabled = true;
                        this.uButton_RowGoodsRevive.Enabled = false;
                    }
                }
                else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock) // �݌�
                {
                    // ���i�{�^���s��
                    this.uButton_RowGoodsDelete.Enabled = false;
                    this.uButton_RowGoodsRevive.Enabled = false;

                    if (isStockReserveDelete)
                    {
                        // �폜�\��s�Ȃ̂ŁA�폜�����s��
                        this.uButton_RowStockDelete.Enabled = false;
                        this.uButton_RowStockRevive.Enabled = true;
                    }
                    else
                    {
                        // �폜�\��\�A�����s��
                        this.uButton_RowStockDelete.Enabled = true;
                        this.uButton_RowStockRevive.Enabled = false;
                    }
                }
            }
            else
            {
                // �C���o�^
                if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods) // ���i
                {
                    // �݌Ƀ{�^���s��
                    this.uButton_RowStockDelete.Enabled = false;
                    this.uButton_RowStockRevive.Enabled = false;

                    if (isGoodsLogicalDelete)
                    {
                        // �_���폜�s�̏ꍇ�A�폜�A�����\
                        this.uButton_RowGoodsDelete.Enabled = true;
                        this.uButton_RowGoodsRevive.Enabled = true;
                    }
                    else if (isGoodsReserveDelete)
                    {
                        // �폜�\��s�̏ꍇ�A�폜�s�A�����\
                        this.uButton_RowGoodsDelete.Enabled = false;
                        this.uButton_RowGoodsRevive.Enabled = true;
                    }
                    else
                    {
                        this.uButton_RowGoodsDelete.Enabled = true;
                        this.uButton_RowGoodsRevive.Enabled = false;
                    }
                }
                else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock
                    || this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods) // �݌ɂƍ݌ɏ��i
                {
                    // ���i�{�^���s��
                    this.uButton_RowGoodsDelete.Enabled = false;
                    this.uButton_RowGoodsRevive.Enabled = false;

                    if (isStockLogicalDelete)
                    {
                        // �_���폜�s�̏ꍇ�A�폜�A�����\
                        this.uButton_RowStockDelete.Enabled = true;
                        this.uButton_RowStockRevive.Enabled = true;
                    }
                    else if (isStockReserveDelete)
                    {
                        // �폜�\��s�̏ꍇ�A�폜�s�A�����\
                        this.uButton_RowStockDelete.Enabled = false;
                        this.uButton_RowStockRevive.Enabled = true;
                    }
                    else
                    {
                        this.uButton_RowStockDelete.Enabled = true;
                        this.uButton_RowStockRevive.Enabled = false;
                    }
                }
                else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock) // ���i�݌�
                {
                    // ���i�{�^��
                    if (isGoodsLogicalDelete)
                    {
                        // �_���폜�s�̏ꍇ�A�폜�A�����\
                        this.uButton_RowGoodsDelete.Enabled = true;
                        this.uButton_RowGoodsRevive.Enabled = true;
                        this.uButton_RowStockDelete.Enabled = false;
                        this.uButton_RowStockRevive.Enabled = false;
                    }
                    else if (isGoodsReserveDelete)
                    {
                        // �폜�\��s�̏ꍇ�A�폜�s�A�����\
                        this.uButton_RowGoodsDelete.Enabled = false;
                        this.uButton_RowGoodsRevive.Enabled = true;
                        this.uButton_RowStockDelete.Enabled = false;
                        this.uButton_RowStockRevive.Enabled = false;
                    }
                    else
                    {
                        this.uButton_RowGoodsDelete.Enabled = true;
                        this.uButton_RowGoodsRevive.Enabled = false;

                        // �݌Ƀ{�^��
                        if (isStockLogicalDelete)
                        {
                            // �_���폜�s�̏ꍇ�A�폜�A�����\
                            this.uButton_RowStockDelete.Enabled = true;
                            this.uButton_RowStockRevive.Enabled = true;
                        }
                        else if (isStockReserveDelete)
                        {
                            // �폜�\��s�̏ꍇ�A�폜�s�A�����\
                            this.uButton_RowStockDelete.Enabled = false;
                            this.uButton_RowStockRevive.Enabled = true;
                        }
                        else
                        {
                            this.uButton_RowStockDelete.Enabled = true;
                            this.uButton_RowStockRevive.Enabled = false;
                        }
                    }
                }

                if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value == null
                || this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value == DBNull.Value)
                {
                    //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() != "�V�K") // DEL 2009/03/06
                    if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() != "�V�K") // ADD 2009/03/06
                    {
                        // �C���o�^�ō݌ɂ��Ȃ���΍݌Ƀ{�^�������s��
                        // (���i�݌ɂŁA�����̍݌ɂȂ����i�͍݌ɍ폜�s��)
                        this.uButton_RowStockDelete.Enabled = false;
                        this.uButton_RowStockRevive.Enabled = false;
                    }
                }
            }

            #endregion

            #region �K�C�h�{�^������

            // �K�C�h�{�^���ݒ�
            switch (columnKey)
            {
                case "GoodsMaker":
                case "BLGoodsCode":
                case "EnterpriseGanreCode":
                case "WarehouseCode":
                case "PartsManagementDivide1":
                case "PartsManagementDivide2":
                case "StockSupplierCode":
                    {
                        //this.uButton_RowExcuteGuide.Enabled = true; // DEL 2010/08/11
                        this.SetGuide(true); // ADD 2010/08/11
                        break;
                    }
                default:
                    {
                        //this.uButton_RowExcuteGuide.Enabled = false; // DEL 2010/08/11
                        this.SetGuide(false); // ADD 2010/08/11
                        break;
                    }
            }

            #endregion

            #region ���i�ǉ��{�^��
            if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                this.uButton_RowAdd.Enabled = true;
            }
            else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                // --- DEL 2009/02/23 -------------------------------->>>>>
                //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value == null
                //    || this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value == DBNull.Value)
                //{
                //    // �݌ɂ������ꍇ�͉����s��
                //    this.uButton_RowAdd.Enabled = false;
                //}
                //else
                //{
                //    this.uButton_RowAdd.Enabled = true;
                //}
                // --- DEL 2009/02/23 --------------------------------<<<<<
                // --- DEL 2009/03/03 -------------------------------->>>>>
                //// --- ADD 2009/02/23 -------------------------------->>>>>
                //if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                //    && (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0
                //    && this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != null
                //    && this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != DBNull.Value)
                //{
                //    // ���i���폜�s�łȂ����q�ɂ̓��͂����݂���ꍇ�A�����\
                //    this.uButton_RowAdd.Enabled = true;
                //}
                //else
                //{
                //    this.uButton_RowAdd.Enabled = false;
                //}
                //// --- ADD 2009/02/23 --------------------------------<<<<<
                // --- DEL 2009/03/03 --------------------------------<<<<<
                // --- ADD 2009/03/03 -------------------------------->>>>>
                // ���i������s�̏ꍇ�̂ݍ݌ɂ̏����`�F�b�N
                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                && (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0)
                {
                    bool noStockExistFlg = this.CheckStockNotExist(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(),
                        (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value);

                    if (noStockExistFlg)
                    {
                        this.uButton_RowAdd.Enabled = false;
                    }
                    else
                    {
                        this.uButton_RowAdd.Enabled = true;
                    }
                }
                else
                {
                    this.uButton_RowAdd.Enabled = false;
                }
                // --- ADD 2009/03/03 --------------------------------<<<<<
            }
            else
            {
                this.uButton_RowAdd.Enabled = false;
            }
            #endregion
        }

        // --- ADD 2009/02/23 -------------------------------->>>>>
        /// <summary>
        /// �w��O���b�h�s�̏�Ԃɉ������{�^�������ې�����s���B
        /// </summary>
        /// <remarks>
        /// </remarks>
        private void SetButtonEnableBySelectedRows()
        {
            #region �폜�A�����{�^������

            bool isGoodsLogicalDelete = false; // 1�ł����i���_���폜�ς̏ꍇtrue
            bool isGoodsReserveDelete = false; // 1�ł����i���폜�\��̏ꍇtrue
            bool isStockLogicalDelete = false; // 1�ł��݌ɂ��_���폜�ς̏ꍇtrue
            bool isStockReserveDelete = false; // 1�ł��݌ɂ��폜�\��̏ꍇtrue
            bool isGoodsNotDelete = false;     // 1�ł����i������(�폜�ΏۂłȂ�)�̏ꍇtrue
            bool isStockNotDelete = false;     // 1�ł��݌ɂ�����(�폜�ΏۂłȂ�)�̏ꍇtrue

            bool isStockExist = false;         // 1���݌ɂ̂Ȃ����i������ (���i�ǉ��{�^���̐���p)

            #region �s��ԃ`�F�b�N
            foreach (UltraGridRow ultraRow in this.uGrid_Details.Selected.Rows)
            {
                if ((int)ultraRow.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value != 0)
                {
                    isGoodsLogicalDelete = true; // ���i�_���폜�s����
                }
                
                if ((int)ultraRow.Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value != 0)
                {
                    isGoodsReserveDelete = true; // ���i�폜�\��s����
                }

                if ((int)ultraRow.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                    && (int)ultraRow.Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0)
                {
                    isGoodsNotDelete = true; // ���i����s(�폜�ΏۊO�s)����
                }

                // ���i������s�̏ꍇ�̂ݍ݌ɂ̏����`�F�b�N
                if ((int)ultraRow.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                && (int)ultraRow.Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0)
                {
                    // �C���o�^�̏ꍇ�͍݌ɏ�񂪂���s�̂݃`�F�b�N
                    if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                        ||
                        (ultraRow.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != null
                        && ultraRow.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != DBNull.Value
                        //&& ultraRow.Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() != "�V�K")) // DEL 2009/03/06
                        && ultraRow.Cells[this._goodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() != "�V�K")) // ADD 2009/03/06
                    {

                        if ((int)ultraRow.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value != 0)
                        {
                            isStockLogicalDelete = true; // �݌ɘ_���폜�s����
                        }

                        if ((int)ultraRow.Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value != 0)
                        {
                            isStockReserveDelete = true; // �݌ɍ폜�\��s����
                        }

                        if ((int)ultraRow.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0
                            && (int)ultraRow.Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value == 0)
                        {
                            isStockNotDelete = true; // �݌ɐ���s(�폜�ΏۊO�s)����
                        }

                        //isStockExist = true; // DEL 2009/03/03
                    }
                    // --- ADD 2009/03/03 -------------------------------->>>>>
                    if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
                    {
                        // ���i�݌ɂ̏ꍇ�̂ݍ݌ɑ��݃`�F�b�N(�݌ɒǉ��{�^���p)
                        // �s�ǉ��̓A�N�e�B�u�s�̂ݑΏ�
                        if (ultraRow.IsActiveRow
                            && !this.CheckStockNotExist(ultraRow.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(),
                            (int)ultraRow.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value))
                        {
                            isStockExist = true;
                        }
                    }
                    // --- ADD 2009/03/03 --------------------------------<<<<<
                }
            }

            if (isGoodsLogicalDelete) this._includeGoodsLogicalDeleted = true;
            else this._includeGoodsLogicalDeleted = false;

            if (isStockLogicalDelete) this._includeStockLogicalDeleted = true;
            else this._includeStockLogicalDeleted = false;
            #endregion

            #region �폜�E�����{�^������
            if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            {
                // �V�K�o�^
                if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods) // ���i
                {
                    // �݌Ƀ{�^���s��
                    this.uButton_RowStockDelete.Enabled = false;
                    this.uButton_RowStockRevive.Enabled = false;

                    // ���i�{�^������Utrue��
                    this.uButton_RowGoodsDelete.Enabled = true;
                    this.uButton_RowGoodsRevive.Enabled = true;

                    if (!isGoodsReserveDelete)
                    {
                        // �폜�\��s���Ȃ��ꍇ�A�����{�^�������s��
                        this.uButton_RowGoodsRevive.Enabled = false;
                    }

                    if (!isGoodsNotDelete)
                    {
                        // ����s�������ꍇ�A�폜�{�^�������s��
                        this.uButton_RowGoodsDelete.Enabled = false;
                    }
                }
                else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock) // �݌�
                {
                    // ���i�{�^���s��
                    this.uButton_RowGoodsDelete.Enabled = false;
                    this.uButton_RowGoodsRevive.Enabled = false;

                    // �݌Ƀ{�^������Utrue��
                    this.uButton_RowStockDelete.Enabled = true;
                    this.uButton_RowStockRevive.Enabled = true;

                    if (!isStockReserveDelete)
                    {
                        // �폜�\��s���Ȃ��ꍇ�A�����{�^�������s��
                        this.uButton_RowStockRevive.Enabled = false;
                    }

                    if (!isStockNotDelete)
                    {
                        // ����s�������ꍇ�A�폜�{�^�������s��
                        this.uButton_RowStockDelete.Enabled = false;
                    }
                }
            }
            else
            {
                // �C���o�^
                if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods) // ���i
                {
                    // �݌Ƀ{�^���s��
                    this.uButton_RowStockDelete.Enabled = false;
                    this.uButton_RowStockRevive.Enabled = false;

                    // ���i�{�^������Utrue��
                    this.uButton_RowGoodsDelete.Enabled = true;
                    this.uButton_RowGoodsRevive.Enabled = true;

                    if (!isGoodsLogicalDelete)
                    {
                        // �_���폜�s������ꍇ�A�폜�A�����Ƃ��\
                        if (!isGoodsReserveDelete)
                        {
                            // �_���폜�s���Ȃ����폜�\��s���Ȃ��ꍇ�A�����{�^�������s��
                            this.uButton_RowGoodsRevive.Enabled = false;
                        }

                        if (!isGoodsNotDelete)
                        {
                            // �_���폜�s���Ȃ�������s�������ꍇ�A�폜�{�^�������s��
                            this.uButton_RowGoodsDelete.Enabled = false;
                        }
                    }
                }
                else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock
                    || this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods) // �݌ɂƍ݌ɏ��i
                {
                    // ���i�{�^���s��
                    this.uButton_RowGoodsDelete.Enabled = false;
                    this.uButton_RowGoodsRevive.Enabled = false;

                    // �݌Ƀ{�^������Utrue��
                    this.uButton_RowStockDelete.Enabled = true;
                    this.uButton_RowStockRevive.Enabled = true;

                    if (!isStockLogicalDelete)
                    {
                        // �_���폜�s������ꍇ�A�폜�A�����Ƃ��\
                        if (!isStockReserveDelete)
                        {
                            // �_���폜�s���Ȃ����폜�\��s���Ȃ��ꍇ�A�����{�^�������s��
                            this.uButton_RowStockRevive.Enabled = false;
                        }

                        if (!isStockNotDelete)
                        {
                            // �_���폜�s���Ȃ�������s�������ꍇ�A�폜�{�^�������s��
                            this.uButton_RowStockDelete.Enabled = false;
                        }
                    }
                }
                else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock) // ���i�݌�
                {
                    // ���i�{�^���A�݌Ƀ{�^������Utrue��
                    this.uButton_RowGoodsDelete.Enabled = true;
                    this.uButton_RowGoodsRevive.Enabled = true;

                    this.uButton_RowStockDelete.Enabled = true;
                    this.uButton_RowStockRevive.Enabled = true;

                    if (!isGoodsLogicalDelete)
                    {
                        // �_���폜�s������ꍇ�A�폜�A�����Ƃ��\
                        if (!isGoodsReserveDelete)
                        {
                            // �_���폜�s���Ȃ����폜�\��s���Ȃ��ꍇ�A�����{�^�������s��
                            this.uButton_RowGoodsRevive.Enabled = false;
                        }

                        if (!isGoodsNotDelete)
                        {
                            // �_���폜�s���Ȃ�������s�������ꍇ�A�폜�{�^�������s��
                            this.uButton_RowGoodsDelete.Enabled = false;
                        }
                    }

                    if (!isStockLogicalDelete)
                    {
                        // �_���폜�s������ꍇ�A�폜�A�����Ƃ��\
                        if (!isStockReserveDelete)
                        {
                            // �_���폜�s���Ȃ����폜�\��s���Ȃ��ꍇ�A�����{�^�������s��
                            this.uButton_RowStockRevive.Enabled = false;
                        }

                        if (!isStockNotDelete)
                        {
                            // �_���폜�s���Ȃ�������s�������ꍇ�A�폜�{�^�������s��
                            this.uButton_RowStockDelete.Enabled = false;
                        }
                    }
                }
            }
            #endregion

            #endregion

            // �K�C�h�{�^������(�s�̏ꍇ�͉����s��)
            //this.uButton_RowExcuteGuide.Enabled = false; // DEL 2010/08/11
            this.SetGuide(false); // ADD 2010/08/11

            #region ���i�ǉ��{�^��
            if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                this.uButton_RowAdd.Enabled = true;
            }
            else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                if (isStockExist)
                {
                    this.uButton_RowAdd.Enabled = true;
                }
                else
                {
                    // �݌ɂ������ꍇ�͉����s��
                    this.uButton_RowAdd.Enabled = false;
                }
            }
            else
            {
                this.uButton_RowAdd.Enabled = false;
            }
            #endregion
        }
        // --- ADD 2009/02/23 --------------------------------<<<<<
        #endregion

        #region �� XML����
        /// <summary>
        /// �w�l�k�f�[�^�̓Ǎ�����
        /// </summary>
        public void LoadStateXmlData()
        {
            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }

        /// <summary>
        /// �w�l�k�f�[�^�̕ۑ�����
        /// </summary>
        public void SaveStateXmlData()
        {
            // �O���b�h����ۑ�
            this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }
        #endregion XML����

        #endregion

        #region �� �O���b�h���͐���֘A

        /// <summary>
        /// �Z��Activation�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>�������A�Z���P�ʂ̓��͋��ݒ���s��</br>
        /// <br>�i���A���[�J�[�A�q�ɂ͗�P�ʂœ��͉ۂ����܂�Ȃ��ׁA�Z���P�ʂŐ��䂷��</br>
        /// </remarks>
        internal void SetCellActivation()
        {
            foreach (UltraGridRow ultraRow in this.uGrid_Details.Rows)
            {
                // �����̃L�[�l�i���i�A���[�J�[�A�q�Ɂj�͓��͕s��(���i�A�݌ɂ̒ǉ����̂ݕҏW�\�ɂ���)
                ultraRow.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Activation = Activation.Disabled;
                ultraRow.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Activation = Activation.Disabled;
                
                if (ultraRow.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != null
                    && ultraRow.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != DBNull.Value)
                {
                    // �q�ɂ������ꍇ�͕ҏW�\
                    ultraRow.Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Activation = Activation.Disabled;
                }

                // ���i�_���폜�s�͕ҏW�s��
                if ((int)ultraRow.Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value != 0)
                {
                    foreach (UltraGridCell ultraCell in ultraRow.Cells)
                    {
                        ultraCell.Activation = Activation.Disabled;
                    }
                }

                // �݌ɘ_���폜�s�͍݌ɏ��̂ݕҏW�s��
                if ((int)ultraRow.Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value != 0)
                {
                    int stockColIndex = ultraRow.Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Column.Index;

                    for (int i = stockColIndex; i < ultraRow.Cells.Count; i++)
                    {
                        ultraRow.Cells[i].Activation = Activation.Disabled;
                    }
                }
            }
        }
        #endregion

        #region �� ���̑�����
        #region �� �폜�ς݃f�[�^�̕\���֘A����
        /// <summary>
        /// �폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X�̔��f
        /// </summary>
        internal void DeleteIndicationSetting(bool isChecked)
        {
            if (isChecked)
            {
                if (this._beforeSearchExtractInfo.TargetDiv != ExtractInfo.TargetDivState.Stock
                    && this._beforeSearchExtractInfo.TargetDiv != ExtractInfo.TargetDivState.StockGoods) // ADD 2009/02/03
                {
                    // �݌ɁA�݌ɏ��i�̏ꍇ�A���i�폜���͕\�����Ȃ�
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Hidden = false;
                }

                if (this._beforeSearchExtractInfo.TargetDiv != ExtractInfo.TargetDivState.Goods)
                {
                    // ���i�̏ꍇ�A�݌ɍ폜���͕\�����Ȃ�
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Hidden = false;
                }
            }
            else
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Hidden = true;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Hidden = true;
            }

            // �_���폜�t�B���^�ݒ�
            this.SetGridFiltering(isChecked);

            // --- ADD 2009/02/23 -------------------------------->>>>>
            // �t�B���^�ύX�ɂ��A�N�e�B�u�s�A�I���s����
            this.SetActivationStatByFilteredOut();

            // �I���s�̏�Ԃ��ς��̂Ń{�^����������
            this.SetButtonEnable();

            // �I���s�̏�Ԃ��ς��̂Ŕw�i�F���t���b�V��
            this.SetGridColorAll();
            // --- ADD 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// �t�B���^�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>�_���폜�s�t�B���^�̂ݍĐݒ�</br>
        /// </remarks>
        private void SetGridFiltering()
        {
            ExtractInfo extractInfo = this.GetExtractInfo();

            this.SetGridFiltering(extractInfo.DeleteIndication);

            // --- ADD 2009/02/23 -------------------------------->>>>>
            // �t�B���^�ύX�ɂ��A�N�e�B�u�s�A�I���s����
            this.SetActivationStatByFilteredOut();

            // �I���s�̏�Ԃ��ς��̂Ń{�^����������
            this.SetButtonEnable();

            // �I���s�̏�Ԃ��ς��̂Ŕw�i�F���t���b�V��
            this.SetGridColorAll();
            // --- ADD 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// �t�B���^�ݒ�
        /// </summary>
        private void SetGridFiltering(bool deleteDispChecked)
        {
            Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFilters = this.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters;
            //columnFilters.ClearAllFilters(); // ��ʂŎw�肵���t�B���^���O��Ă��܂��̂Ł~�B

            columnFilters[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].FilterConditions.Clear();
            columnFilters[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].FilterConditions.Clear();

            if (!deleteDispChecked)
            {
                // �󔒂�Null�ȊO���t�B���^�ɐݒ肷��
                columnFilters[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, "");
                columnFilters[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, null);
                columnFilters[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].LogicalOperator = Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or;

                if (this._beforeSearchExtractInfo.TargetDiv != ExtractInfo.TargetDivState.Goods)
                {
                    // �Ώۋ敪�u���i�v�ȊO�̏ꍇ�́A�݌ɍ폜���ł��t�B���^
                    columnFilters[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, "");
                    columnFilters[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, null);
                    columnFilters[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].LogicalOperator = Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or;
                }
            }
        }

        // --- ADD 2009/02/23 -------------------------------->>>>>
        /// <summary>
        /// �t�B���^�ύX�ɂ��s�̃A�N�e�B�u�A�I���s����
        /// </summary>
        private void SetActivationStatByFilteredOut()
        {
            // �A�N�e�B�u�Z���̃`�F�b�N
            if (this.uGrid_Details.ActiveCell != null)
            {
                if (this.uGrid_Details.ActiveCell.Row.IsFilteredOut)
                {
                    if (!this.uGrid_Details.PerformAction(UltraGridAction.BelowCell))
                    {
                        if (!this.uGrid_Details.PerformAction(UltraGridAction.BelowRow))
                        {
                            if (!this.uGrid_Details.PerformAction(UltraGridAction.AboveCell))
                            {
                                if (!this.uGrid_Details.PerformAction(UltraGridAction.AboveRow))
                                {
                                    // �\���s���Ȃ�
                                    this.uGrid_Details.ActiveCell = null;
                                    this.uGrid_Details.ActiveRow = null;
                                }
                            }
                        }
                    }
                }

                if (this.uGrid_Details.ActiveCell != null)
                {
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            // �I���s�̃`�F�b�N
            else if (this.uGrid_Details.Selected.Rows.Count != 0)
            {
                foreach (UltraGridRow ultraRow in this.uGrid_Details.Selected.Rows)
                {
                    if (ultraRow.IsFilteredOut)
                    {
                        if (ultraRow.Activated)
                        {
                            // �A�N�e�B�u�s�̏ꍇ�A�\���s�ɕύX
                            if (!this.uGrid_Details.PerformAction(UltraGridAction.BelowRow))
                            {
                                if (!this.uGrid_Details.PerformAction(UltraGridAction.AboveRow))
                                {
                                    // �\���s���Ȃ�
                                    this.uGrid_Details.ActiveCell = null;
                                    this.uGrid_Details.ActiveRow = null;
                                    ultraRow.Selected = false;
                                }
                            }
                        }
                        else
                        {
                            // �I���s�̏ꍇ�A��I����
                            ultraRow.Selected = false;
                        }
                    }
                }
            }
        }
        // --- ADD 2009/02/23 --------------------------------<<<<<
        #endregion

        /// <summary>
        /// ���׃O���b�h�I���s�A�A�N�e�B�u�Z���̍sindex�擾
        /// </summary>
        /// <returns>�s�ԍ�(�����ꍇ�͋�̃��X�g)</returns>
        /// <remarks>
        /// <br>�����s�I���ɑΉ�</br>
        /// </remarks>
        //private int GetSelectRowIndex() // DEL 2009/02/23
        private List<int> GetSelectRowIndex() // ADD 2009/02/23
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //if (this.uGrid_Details.ActiveRow != null)
            //{
            //    return this.uGrid_Details.ActiveRow.Index;
            //}
            //else if (this.uGrid_Details.ActiveCell != null)
            //{
            //    return this.uGrid_Details.ActiveCell.Row.Index;
            //}

            //return -1;
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/02/23 -------------------------------->>>>>
            List<int> rowIndexList = new List<int>();

            if (this.uGrid_Details.ActiveCell != null)
            {
                // �Z���A�N�e�B�u
                rowIndexList.Add(this.uGrid_Details.ActiveCell.Row.Index);
            }
            else if (this.uGrid_Details.Selected.Rows.Count != 0)
            {
                foreach (UltraGridRow ultraRow in this.uGrid_Details.Selected.Rows)
                {
                    rowIndexList.Add(ultraRow.Index);
                }
            }

            return rowIndexList;
            // --- ADD 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// DBNull���܂ލ��ڂ̐��l�ϊ�����(�����p)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private double ConvertToDoubleFromGridValue(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(obj);
            }
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <remarks>�R�s�[���FMAKHN09280UC.cs��KeyPressNumCheck()</remarks>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        private bool CheckKeyPressNumber(
            int keta,
            int priod,
            string prevVal,
            char key,
            int selstart,
            int sellength,
            Boolean minusFlg
        )
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }

            // 1�����ڂ�'.'��NG
            if (string.IsNullOrEmpty(prevVal) && key.Equals('.'))
            {
                return false;
            }

            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // �����_�ȉ��̃`�F�b�N
            if (priod > 0)
            {
                // �����_�̈ʒu����
                int _pointPos = _strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // --- ADD 2009/03/03 -------------------------------->>>>>
        /// <summary>
        /// �݌ɗL���`�F�b�N
        /// </summary>
        /// <returns>true;�݌ɂ̖����f�[�^������ false:�݌ɂ̖����f�[�^������</returns>
        /// <remarks>
        /// <br>�����i�ō݌ɂ̂Ȃ��f�[�^�����邩�`�F�b�N����</br>
        /// <br>Update Note : 2012/09/11 yangmj ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
        /// <br>�Ǘ��ԍ�    : 10707327-00 PM1203G</br> 							
        /// <br>              Redmine32095 ���i�݌Ɉꊇ�o�^�C���Łu�S�Ẳ��i��񂪏�����v</br> 		 
        /// </remarks>
        private bool CheckStockNotExist(string goodsNo, int goodsMakerCode)
        {
            StringBuilder filSb = new StringBuilder();
            //----- ADD YANGMJ 2012/09/11 REDMINE#32095 ----->>>>>
            if (goodsNo.Contains("'"))
            {
                goodsNo = goodsNo.Replace("'", "''");
            }
            //----- ADD YANGMJ 2012/09/11 REDMINE#32095 -----<<<<<
            filSb.Append(this._goodsStockDataTable.GoodsNoColumn.ColumnName);
            filSb.Append(" = '");
            filSb.Append(goodsNo);
            filSb.Append("' AND ");
            filSb.Append(this._goodsStockDataTable.GoodsMakerColumn.ColumnName);
            filSb.Append(" = ");
            filSb.Append(goodsMakerCode);

            DataRow[] drList = this._goodsStockDataTable.Select(filSb.ToString());

            if (drList.Length > 0)
            {
                foreach (DataRow dr in drList)
                {
                    if (dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName] == null
                        || dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName] == DBNull.Value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        // --- ADD 2009/03/03 --------------------------------<<<<<
        #endregion

        #region �� �폜����
        /// <summary>
        /// ���i�폜���C������
        /// </summary>
        /// <param name="rowIndex">�Ώۍs</param>
        /// <remarks>
        /// <br>�����s�I���ɑΉ�</br>
        /// </remarks>
        //private void GoodsDeleteMain(int rowIndex) // DEL 2009/02/23
        private void GoodsDeleteMain() // ADD 2009/02/23
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() == "�V�K")
            //{
            //    // �ǉ��s�̏ꍇ�A�폜����
            //    this.uGrid_Details.Rows[rowIndex].Delete();
            //    return;
            //}

            //if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            //{
            //    // �폜�\�񏈗�
            //    this.GoodsLogicalDeleteReserve(rowIndex);
            //}
            //else
            //{
            //    // ���i
            //    if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 1)
            //    {
            //        // ���i���_���폜�ς̏ꍇ�A�����폜����(���i�A�݌ɂƂ�)
            //        this.GoodsCompleteDelete(rowIndex);
            //    }
            //    else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0)
            //    {
            //        // �폜�\�񏈗�
            //        this.GoodsLogicalDeleteReserve(rowIndex);
            //    }
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/02/23 -------------------------------->>>>>
            List<int> rowIndexList = this.GetSelectRowIndex();
            rowIndexList.Sort();

            if (rowIndexList.Count == 0)
            {
                // �I���s�A�A�N�e�B�u�Z���������ꍇ�A�����Ȃ�
                return;
            }

            if (this._includeGoodsLogicalDeleted)
            {
                // ���S�폜���܂ޏꍇ�͌x����\��
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "�I���������i�̂����A�폜�ς݃f�[�^�����S�폜���܂��B" + "\r\n" + "\r\n" +
                        "��낵���ł����H",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �����Ϗ��i���X�g
            Dictionary<string, List<int>> deletedDic = new Dictionary<string, List<int>>();
            // �����폜�Ώۏ��i���X�g
            ArrayList completeDeletedList = new ArrayList();

            // ���S�폜���A�s���폜����邽��Index���傫�������珈��
            for (int i = rowIndexList.Count - 1; i >= 0; i--)
            {
                int rowIndex = rowIndexList[i];

                //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() == "�V�K") // DEL 2009/03/06
                if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() == "�V�K") // ADD 2009/03/06
                {
                    // �ǉ��s�̏ꍇ�A�폜����
                    this.uGrid_Details.Rows[rowIndex].Delete(false);
                    continue;
                }

                if (deletedDic.ContainsKey(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString())
                    && deletedDic[this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString()]
                    .Contains((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value))
                {
                    // �����ς�
                    continue;
                }

                // ���i
                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 1)
                {
                    // �����폜�Ώۏ��i���X�g�̍쐬
                    // �����폜�͕����s�폜�ɂ��Index�����邽�߁A��ōs���B
                    // �܂��A�����i�͏����ς݃��X�g�̕��ŏ������
                    ArrayList list = new ArrayList();
                    list.Add(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value);
                    list.Add(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value);
                    
                    completeDeletedList.Add(list);
                }
                else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0)
                {
                    // �폜�\�񏈗�
                    this.GoodsLogicalDeleteReserve(rowIndex);
                }
                else
                {
                    // �����ΏۊO(���ɗ\��ς̍s�Ȃ�)
                    continue;
                }

                // �����σ��X�g�̍쐬
                if (deletedDic.ContainsKey(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString()))
                {
                    deletedDic[this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString()]
                        .Add((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value);
                }
                else
                {
                    List<int> makerList = new List<int>();
                    makerList.Add((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value);

                    deletedDic.Add(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(), makerList);
                }
            }

            // ���S�폜����
            if (completeDeletedList.Count != 0)
            {
                foreach (ArrayList goodsList in completeDeletedList)
                {
                    // �����폜����(���i�A�݌ɂƂ�)
                    status = this.GoodsCompleteDelete(goodsList[0].ToString(), (int)goodsList[1]);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        break;
                    }
                }
            }

            if (this._includeGoodsLogicalDeleted
                && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���S�폜�s�����݂��S�Đ���Ɋ������̓��b�Z�[�W��\��
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "���S�폜���܂����B",
                    0,
                    MessageBoxButtons.OK);

                // �ۑ��{�^�������ېݒ�
                if (this._goodsStockDataTable.Rows.Count == 0)
                {
                    this.SetSaveButton();
                }
            }

            // �_���폜�s���ăt�B���^
            this.SetGridFiltering();
            // --- ADD 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// ���i�_���폜����
        /// </summary>
        /// <param name="rowIndex"></param>
        private void GoodsLogicalDeleteReserve(int rowIndex)
        {
            // �I���s�̃L�[�l���擾
            string goodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            int goodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;

            foreach (UltraGridRow ultraGr in this.uGrid_Details.Rows)
            {
                if (ultraGr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
                    && (int)ultraGr.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd)
                {
                    // �����i�A�݌ɂ̍폜���Ɍ��ݓ�����ݒ�
                    // --- DEL 2009/02/05 -------------------------------->>>>>
                    //ultraGr.Cells[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value = DateTime.Today;
                    //ultraGr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value = DateTime.Today;
                    // --- DEL 2009/02/05 --------------------------------<<<<<
                    // --- ADD 2009/02/05 -------------------------------->>>>>
                    ultraGr.Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value = 1;

                    // �݌ɂ�����ꍇ�̂ݐݒ�
                    if (ultraGr.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != null
                        && ultraGr.Cells[this._goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value != DBNull.Value)// ADD 2009/03/02
                    {
                        ultraGr.Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value = 1;
                    }

                    if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
                    {
                        ultraGr.Cells[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value = DateTime.Today;
                        ultraGr.Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value = DateTime.Today;
                    }
                    // --- ADD 2009/02/05 --------------------------------<<<<<

                    // �_���폜�\��s�͕ҏW�s�ɕύX
                    foreach (UltraGridCell ultraCell in ultraGr.Cells)
                    {
                        ultraCell.Activation = Activation.Disabled;
                    }
                }
            }

            // �w�i�F�ݒ�
            //this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]); // DEL 2009/02/23

            // �_���폜�s���ăt�B���^
            //this.SetGridFiltering(); // DEL 2009/02/23
        }

        /// <summary>
        /// ���i���S�폜����
        /// </summary>
        /// <returns>�������ʃX�e�[�^�X</returns>
        //private int GoodsCompleteDelete(int rowIndex)
        private int GoodsCompleteDelete(string goodsNo, int goodsMakerCd)
        {
            // �����s�̈ꊇ�폜�̂��߁A1�s���ł͒��ӕ�����\�����Ȃ� // ADD 2009/02/23
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// ���ӕ����\��
            //DialogResult dialogResult = TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_QUESTION,
            //        this.Name,
            //        "�I���������i�����S�폜���܂��B" + "\r\n" + "\r\n" +
            //        "��낵���ł����H",
            //        0,
            //        MessageBoxButtons.YesNo,
            //        MessageBoxDefaultButton.Button1);

            //if (dialogResult != DialogResult.Yes)
            //{
            //    return;
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<

            //string goodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(); // DEL 2009/02/23
            //int goodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value; // DEL 2009/02/23

            // ���S�폜���s
            int status = this._goodsStockAcs.GoodsCompleteDelete(goodsNo, goodsMakerCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �����s�̈ꊇ�폜�Ή��̂��߁A1�s���ł͕�����\�����Ȃ� // ADD 2009/02/23
                // --- DEL 2009/02/23 -------------------------------->>>>>
                //TMsgDisp.Show(
                //    this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "���S�폜���܂����B",
                //    0,
                //    MessageBoxButtons.OK);
                // --- DEL 2009/02/23 --------------------------------<<<<<

                // ���i�݌Ƀe�[�u�����폜
                for (int i = this._goodsStockDataTable.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = this._goodsStockDataTable.Rows[i];

                    if (dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                        && (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd)
                    {
                        this._goodsStockDataTable.Rows.RemoveAt(i);
                    }
                }

                // �X�V�p�e�[�u�������l�ɍX�V
                for (int i = this._goodsStockAcs.OriginalGoodsStockDataTable.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = this._goodsStockAcs.OriginalGoodsStockDataTable.Rows[i];

                    if (dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                        && (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd)
                    {
                        this._goodsStockAcs.OriginalGoodsStockDataTable.Rows.RemoveAt(i);
                    }
                }

                // --- DEL 2009/02/23 -------------------------------->>>>>
                //// �_���폜�s���ăt�B���^
                //this.SetGridFiltering();

                //// --- ADD 2009/02/03 -------------------------------->>>>>
                //// �ۑ��{�^�������ېݒ�
                //if (this._goodsStockDataTable.Rows.Count == 0)
                //{
                //    this.SetSaveButton();
                //}
                //// --- ADD 2009/02/03 --------------------------------<<<<<
                // --- DEL 2009/02/23 --------------------------------<<<<<
            }
            // --- ADD 2009/02/02 -------------------------------->>>>>
            else
            {
                switch (status)
                {

                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "�V�F�A�`�F�b�N�G���[(��ƃ��b�N)�ł��B" + "\r\n"
                                + "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n"
                                + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "�V�F�A�`�F�b�N�G���[(���_���b�N)�ł��B" + "\r\n"
                                + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n"
                                + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "�V�F�A�`�F�b�N�G���[(�q�Ƀ��b�N)�ł��B" + "\r\n"
                                + "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n"
                                + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "���S�폜�����ŃG���[���������܂����B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                }
            }
            // --- ADD 2009/02/02 --------------------------------<<<<<

            return status; // ADD 2009/02/23
        }

        /// <summary>
        /// �݌ɍ폜���C������
        /// </summary>
        /// <param name="rowIndex">�Ώۍs</param>
        /// <remarks>
        /// </remarks>
        //private void StockDeleteMain(int rowIndex)
        private void StockDeleteMain()
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() == "�V�K")
            //{
            //    // �ǉ��s�̏ꍇ�A�폜����
            //    this.uGrid_Details.Rows[rowIndex].Delete();
            //    return;
            //}

            //// �C���o�^�̏ꍇ
            //if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 1)
            //{
            //    // �݌ɂ��_���폜�ς̏ꍇ�A�����폜����
            //    this.StockCompleteDelete(rowIndex);
            //}
            //else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0)
            //{
            //    // �폜�\�񏈗�
            //    this.StockLogicalDeleteReserve(rowIndex);
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/02/23 -------------------------------->>>>>
            List<int> rowIndexList = this.GetSelectRowIndex();
            rowIndexList.Sort();

            if (rowIndexList.Count == 0)
            {
                // �I���s�A�A�N�e�B�u�Z���������ꍇ�A�����Ȃ�
                return;
            }

            // --- ADD 2009/03/05 -------------------------------->>>>>
            if (this.uGrid_Details.ActiveCell != null)
            {
                // �Z���A�N�e�B�u�̏ꍇ�A
                // �}�[�W�Z���̔�\�������œ����i�̃f�[�^���폜����Ă���̂Ō��ɖ߂�
                this.uGrid_Details_BeforeCellDeactivate();
            }
            // --- ADD 2009/03/05 --------------------------------<<<<<

            if (this._includeStockLogicalDeleted)
            {
                // ���S�폜���܂ޏꍇ�͌x����\��
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "�I�������݌ɂ̂����A�폜�ς݃f�[�^�����S�폜���܂��B" + "\r\n" + "\r\n" +
                        "��낵���ł����H",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ���S�폜���A�s���폜����邽��Index���傫�������珈��
            for (int i = rowIndexList.Count - 1; i >= 0; i--)
            {
                int rowIndex = rowIndexList[i];

                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value != 0
                    || (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value != 0)
                {
                    // ���i���_���폜�ς܂��͍폜�\��s�̏ꍇ�A�݌ɂ͍폜���Ȃ�
                    continue;
                }

                //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() == "�V�K") // DEL 2009/03/06
                if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() == "�V�K") // ADD 2009/03/06
                {
                    // �ǉ��s�̏ꍇ�A�폜����
                    this.uGrid_Details.Rows[rowIndex].Delete(false);
                    continue;
                }

                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 1)
                {
                    // �݌ɂ��_���폜�ς̏ꍇ�A�����폜����
                    status = this.StockCompleteDelete(rowIndex);
                }
                else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value == 0)
                {
                    // �폜�\�񏈗�
                    this.StockLogicalDeleteReserve(rowIndex);
                }
            }

            if (this._includeStockLogicalDeleted
                && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���S�폜�s�����݂��S�Đ���Ɋ������̓��b�Z�[�W��\��
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "���S�폜���܂����B",
                    0,
                    MessageBoxButtons.OK);

                // �ۑ��{�^�������ېݒ�
                if (this._goodsStockDataTable.Rows.Count == 0)
                {
                    this.SetSaveButton();
                }
            }

            // �_���폜�s���ăt�B���^
            this.SetGridFiltering();
            // --- ADD 2009/02/23 -------------------------------->>>>>
        }

        /// <summary>
        /// �݌ɘ_���폜����
        /// </summary>
        /// <param name="rowIndex"></param>
        private void StockLogicalDeleteReserve(int rowIndex)
        {
            this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value = 1; // ADD 2009/02/05
            
            if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            {
                this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value = DateTime.Today;
            }

            int stockColIndex = this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;

            for (int i = stockColIndex; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                // �݌ɏ���ҏW�s�ɕύX
                this.uGrid_Details.Rows[rowIndex].Cells[i].Activation = Activation.Disabled;
            }

            //// �w�i�F�ݒ�
            //this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]); // DEL 2009/02/23

            //// �_���폜�s���ăt�B���^
            //this.SetGridFiltering(); // DEL 2009/02/23
        }
        
        /// <summary>
        /// �݌Ɋ��S�폜����
        /// </summary>
        /// <returns>�������ʃX�e�[�^�X</returns>
        /// <br>Update Note : 2012/09/11 yangmj ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
        /// <br>�Ǘ��ԍ�    : 10707327-00 PM1203G</br> 							
        /// <br>              Redmine32095 ���i�݌Ɉꊇ�o�^�C���Łu�S�Ẳ��i��񂪏�����v</br> 		 
        //private void StockCompleteDelete(int rowIndex)
        private int StockCompleteDelete(int rowIndex)
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// ���ӕ����\��
            //DialogResult dialogResult = TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_QUESTION,
            //        this.Name,
            //        "�I�������݌ɂ����S�폜���܂��B" + "\r\n" + "\r\n" +
            //        "��낵���ł����H",
            //        0,
            //        MessageBoxButtons.YesNo,
            //        MessageBoxDefaultButton.Button1);

            //if (dialogResult != DialogResult.Yes)
            //{
            //    return;
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<

            string goodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            int goodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;
            string warehouseCd = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value.ToString();


            int status = this._goodsStockAcs.StockCompleteDelete(goodsNo, goodsMakerCd, warehouseCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // --- DEL 2009/02/23 -------------------------------->>>>>
                //TMsgDisp.Show(
                //    this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "���S�폜���܂����B",
                //    0,
                //    MessageBoxButtons.OK);
                // --- DEL 2009/02/23 --------------------------------<<<<<
                // --- DEL 2009/03/03 -------------------------------->>>>>
                //// ���i�݌Ƀe�[�u�����폜
                //for (int i = this._goodsStockDataTable.Rows.Count - 1; i >= 0; i--)
                //{
                //    DataRow dr = this._goodsStockDataTable.Rows[i];

                //    if (dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                //        && (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd
                //        && dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString() == warehouseCd)
                //    {
                //        this._goodsStockDataTable.Rows.RemoveAt(i);
                //    }
                //}

                //// �X�V�p�e�[�u�������l�ɍX�V
                //for (int i = this._goodsStockAcs.OriginalGoodsStockDataTable.Rows.Count - 1; i >= 0; i--)
                //{
                //    DataRow dr = this._goodsStockAcs.OriginalGoodsStockDataTable.Rows[i];

                //    if (dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                //        && (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd
                //        && dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString() == warehouseCd)
                //    {
                //        this._goodsStockAcs.OriginalGoodsStockDataTable.Rows.RemoveAt(i);
                //    }
                //}
                // --- DEL 2009/03/03 --------------------------------<<<<<
                // --- ADD 2009/03/05 -------------------------------->>>>>
                // �폜�Ώۍs�ȊO�œ����i������ꍇ�͍s�폜�A�Ȃ���΍݌ɏ��̂ݍ폜
                StringBuilder filSb = new StringBuilder();
                //----- ADD YANGMJ 2012/09/11 REDMINE#32095 ----->>>>>
                if (goodsNo.Contains("'"))
                {
                    goodsNo = goodsNo.Replace("'", "''");
                }
                //----- ADD YANGMJ 2012/09/11 REDMINE#32095 -----<<<<<
                filSb.Append(this._goodsStockDataTable.GoodsNoColumn.ColumnName);
                filSb.Append(" = '");
                filSb.Append(goodsNo);
                filSb.Append("' AND ");
                filSb.Append(this._goodsStockDataTable.GoodsMakerColumn.ColumnName);
                filSb.Append(" = ");
                filSb.Append(goodsMakerCd);

                DataRow[] deleteRowList = this._goodsStockDataTable.Select(filSb.ToString());

                int stockStartIndex = this.uGrid_Details.DisplayLayout.Bands[0]
                                .Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index + 1;
                int stockEndIndex = this.uGrid_Details.DisplayLayout.Bands[0]
                                .Columns[this._goodsStockDataTable.StockUnitPriceFlColumn.ColumnName].Index; // ADD 2009/03/10

                if (this.BeforeSearchExtractInfo.TargetDiv != ExtractInfo.TargetDivState.Stock // ADD 2009/03/05
                    && deleteRowList.Length == 1)
                {
                    DataRow dr = deleteRowList[0];
                    
                    // �݌ɂ̂ݍ폜
                    // �_���폜�֘A
                    dr[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] = 0;
                    dr[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName] = 0;
                    dr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] = DBNull.Value;
                    
                    // UP���ȍ~�̍݌Ɋ֘A���ڂ�������
                    for (int i = stockStartIndex; i <= stockEndIndex; i++)
                    {
                        if (dr[i].GetType() == typeof(Int32)
                            || dr[i].GetType() == typeof(double))
                        {
                            dr[i] = 0;
                        }
                        else
                        {
                            dr[i] = DBNull.Value;
                        }

                        // �O���b�h��ҏW�\�ɂ���
                        this.uGrid_Details.Rows[rowIndex].Cells[i].Activation = Activation.AllowEdit;
                    }
                }
                else if (this.BeforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock // ADD 2009/03/05
                    || deleteRowList.Length > 1)
                {
                    // �s���ƍ폜
                    foreach (DataRow dr in deleteRowList)
                    {
                        if (dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString() == warehouseCd)
                        {
                            this._goodsStockDataTable.Rows.Remove(dr);
                            break;
                        }
                    }
                }

                // �X�V�p�e�[�u�������l�ɍX�V
                DataRow[] originalDeleteRowList = this._goodsStockAcs.OriginalGoodsStockDataTable.Select(filSb.ToString());

                if (originalDeleteRowList.Length == 1)
                {
                    DataRow dr = originalDeleteRowList[0];

                    // �݌ɂ̂ݍ폜
                    // �_���폜�֘A
                    dr[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] = 0;
                    dr[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName] = 0;
                    dr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] = DBNull.Value;

                    // UP���ȍ~�̍݌Ɋ֘A����
                    for (int i = stockStartIndex; i <= stockEndIndex; i++)
                    {
                        if (dr[i].GetType() == typeof(Int32)
                            || dr[i].GetType() == typeof(double))
                        {
                            dr[i] = 0;
                        }
                        else
                        {
                            dr[i] = DBNull.Value;
                        }
                    }
                }
                else if (originalDeleteRowList.Length > 1)
                {
                    // �s���ƍ폜
                    foreach (DataRow dr in originalDeleteRowList)
                    {
                        if (dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString() == warehouseCd)
                        {
                            this._goodsStockAcs.OriginalGoodsStockDataTable.Rows.Remove(dr);
                            break;
                        }
                    }
                }
                // --- ADD 2009/03/05 --------------------------------<<<<<

                // �_���폜�s���ăt�B���^
                //this.SetGridFiltering(); // DEL 2009/02/23
            }
            // --- ADD 2009/02/02 -------------------------------->>>>>
            else
            {
                switch (status)
                {

                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�V�F�A�`�F�b�N�G���[(��ƃ��b�N)�ł��B" + "\r\n"
                                + "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n"
                                + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�V�F�A�`�F�b�N�G���[(���_���b�N)�ł��B" + "\r\n"
                                + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n"
                                + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�V�F�A�`�F�b�N�G���[(�q�Ƀ��b�N)�ł��B" + "\r\n"
                                + "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n"
                                + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "���S�폜�����ŃG���[���������܂����B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                }
            }
            // --- ADD 2009/02/02 --------------------------------<<<<<

            return status; // ADD 2009/02/23
        }
        #endregion

        #region �� ��������

        /// <summary>
        /// �������C������
        /// </summary>
        /// <param name="rowIndex">�O���b�h��̑Ώۍs</param>
        //private void GoodsReviveMain(int rowIndex) // DEL 2009/02/23
        private void GoodsReviveMain() // ADD 2009/02/23
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            //{
            //    // �폜�\��L�����Z������
            //    this.GoodsDeleteReserveCancel(rowIndex);
            //}
            //else
            //{
            //    if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 1)
            //    {
            //        // ���i���_���폜�ς̏ꍇ�A��������
            //        this.GoodsRevive(rowIndex);
            //    }
            //    else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0)
            //    {
            //        // �폜�\��L�����Z������
            //        this.GoodsDeleteReserveCancel(rowIndex);
            //    }
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<

            // --- ADD 2009/02/23 -------------------------------->>>>>
            List<int> rowIndexList = this.GetSelectRowIndex();

            if (rowIndexList.Count == 0)
            {
                // �I���s�A�A�N�e�B�u�Z���������ꍇ�A�����Ȃ�
                return;
            }

            if (this._includeGoodsLogicalDeleted)
            {
                // �������܂ޏꍇ�͌x����\��
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "�I���������i�̂����A�폜�ς݃f�[�^�𕜊����܂��B" + "\r\n" + "\r\n" +
                        "��낵���ł����H",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �����Ϗ��i���X�g
            Dictionary<string, List<int>> revivedDic = new Dictionary<string, List<int>>();

            foreach (int rowIndex in rowIndexList)
            {
                if (revivedDic.ContainsKey(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString())
                    && revivedDic[this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString()]
                    .Contains((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value))
                {
                    // �����ς�
                    continue;
                }

                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 1)
                {
                    // ���i���_���폜�ς̏ꍇ�A��������
                    status = this.GoodsRevive(rowIndex);
                }
                else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 1)
                {
                    // �폜�\��L�����Z������
                    this.GoodsDeleteReserveCancel(rowIndex);
                }
                else
                {
                    continue;
                }

                // �����σ��X�g�̍쐬
                if (revivedDic.ContainsKey(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString()))
                {
                    revivedDic[this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString()]
                        .Add((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value);
                }
                else
                {
                    List<int> makerList = new List<int>();
                    makerList.Add((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value);

                    revivedDic.Add(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(), makerList);
                }
            }

            if (this._includeGoodsLogicalDeleted
                && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���S�폜�s�����݂��S�Đ���Ɋ������̓��b�Z�[�W��\��
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�������܂����B",
                    0,
                    MessageBoxButtons.OK);
            }

            // �_���폜�s���ăt�B���^
            this.SetGridFiltering();
            // --- ADD 2009/02/23 --------------------------------<<<<<

        }

        /// <summary>
        /// ���i�폜�\��L�����Z������
        /// </summary>
        /// <param name="rowIndex"></param>
        private void GoodsDeleteReserveCancel(int rowIndex)
        {
            // �I���s�̃L�[�l���擾
            string goodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            int goodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;

            // �݌ɏ��̍ŏ��̗�C���f�b�N�X
            int stockColIndex = this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;

            foreach (UltraGridRow ultraGr in this.uGrid_Details.Rows)
            {
                if (ultraGr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
                    && (int)ultraGr.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd)
                {
                    // �����i�̍폜�����N���A
                    // --- ADD 2009/02/05 -------------------------------->>>>>
                    ultraGr.Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value = 0;
                    // --- ADD 2009/02/05 --------------------------------<<<<<

                    ultraGr.Cells[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value = DBNull.Value;

                    if ((int)ultraGr.Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value != 0) // ADD 2009/03/03
                    {
                        // ���i��ҏW�\�ɂ���
                        for (int i = 0; i < stockColIndex; i++)
                        {
                            // �L�[�l�ȊO��ҏW�\��
                            if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.GoodsNoColumn.ColumnName
                                && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.GoodsMakerColumn.ColumnName)
                            {
                                ultraGr.Cells[i].Activation = Activation.AllowEdit;
                            }
                        }
                    }
                    else
                    {
                        // �݌ɂ��폜�\��ł͂Ȃ��ꍇ(�������݌ɂ̂Ȃ��s�̂�)�A�S�ĕҏW�\��
                        // ���i��ҏW�\�ɂ���
                        for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            // �L�[�l�ȊO��ҏW�\��
                            if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.GoodsNoColumn.ColumnName
                                && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.GoodsMakerColumn.ColumnName)
                            {
                                ultraGr.Cells[i].Activation = Activation.AllowEdit;
                            }
                        }
                    }

                }
            }

            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// �w�i�F�ݒ�
            //this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]);

            //// �_���폜�s���ăt�B���^
            //this.SetGridFiltering();
            // --- DEL 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// ���i��������
        /// </summary>
        //private void GoodsRevive(int rowIndex) // DEL 2009/02/23
        private int GoodsRevive(int rowIndex) // ADD 2009/02/23
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// ���ӕ����\��
            //DialogResult dialogResult = TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_QUESTION,
            //        this.Name,
            //        "�I���������i�𕜊����܂��B" + "\r\n" + "\r\n" +
            //        "��낵���ł����H",
            //        0,
            //        MessageBoxButtons.YesNo,
            //        MessageBoxDefaultButton.Button1);

            //if (dialogResult != DialogResult.Yes)
            //{
            //    return;
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<

            string goodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            int goodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;

            // �������s
            int status = this._goodsStockAcs.GoodsRevive(goodsNo, goodsMakerCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // --- DEL 2009/02/23 -------------------------------->>>>>
                //TMsgDisp.Show(
                //    this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "�������܂����B",
                //    0,
                //    MessageBoxButtons.OK);
                // --- DEL 2009/02/23 --------------------------------<<<<<

                // ���i�_���폜�̒l���X�V
                foreach (DataRow dr in this._goodsStockDataTable.Rows)
                {
                    if (dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                        && (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd)
                    {
                        dr[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] = 0;
                        dr[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName] = 0; // ADD 2009/02/05
                        dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] = DBNull.Value;

                        dr[this._goodsStockDataTable.RowNumberColumn.ColumnName] = "����"; // ADD 2009/03/06
                    }
                }

                // �X�V�p�e�[�u�������l�ɍX�V
                foreach (DataRow originalDr in this._goodsStockAcs.OriginalGoodsStockDataTable.Rows)
                {
                    if (originalDr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                        && (int)originalDr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd)
                    {
                        originalDr[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] = 0;
                        originalDr[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName] = 0; // ADD 2009/02/05
                        originalDr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] = DBNull.Value;

                        originalDr[this._goodsStockDataTable.RowNumberColumn.ColumnName] = "����"; // ADD 2009/03/06
                    }
                }

                // ���i���̂ݕҏW�\��
                int stockColIndex = this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;

                foreach (UltraGridRow ultraRow in this.uGrid_Details.Rows)
                {
                    if (ultraRow.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
                        && (int)ultraRow.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd)
                    {
                        for (int i = 0; i < stockColIndex; i++)
                        {
                            // �L�[�l�ȊO��ҏW�\��
                            if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.GoodsNoColumn.ColumnName
                                && this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.GoodsMakerColumn.ColumnName)
                            {
                                ultraRow.Cells[i].Activation = Activation.AllowEdit;
                            }
                        }
                    }
                }

                // --- DEL 2009/02/23 -------------------------------->>>>>
                //// �w�i�F�ݒ�
                //this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]);

                //// �_���폜�s���ăt�B���^
                //this.SetGridFiltering();
                // --- DEL 2009/02/23 --------------------------------<<<<<
            }
            // --- ADD 2009/02/02 -------------------------------->>>>>
            else
            {
                switch (status)
                {

                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�V�F�A�`�F�b�N�G���[(��ƃ��b�N)�ł��B" + "\r\n"
                                + "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n"
                                + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�V�F�A�`�F�b�N�G���[(���_���b�N)�ł��B" + "\r\n"
                                + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n"
                                + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�V�F�A�`�F�b�N�G���[(�q�Ƀ��b�N)�ł��B" + "\r\n"
                                + "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n"
                                + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "���������ŃG���[���������܂����B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                }
            }
            // --- ADD 2009/02/02 --------------------------------<<<<<

            return status; // ADD 2009/02/23
        }

        /// <summary>
        /// �݌ɕ������C������
        /// </summary>
        /// <param name="rowIndex">�Ώۍs</param>
        //private void StockReviveMain(int rowIndex) // DEL 2009/02/23
        private void StockReviveMain() // ADD 2009/02/23
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            //{
            //    // �V�K�o�^�̏ꍇ�A�݌ɕ����͉����s��
            //    return;
            //}
            //else
            //{
            //    if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 1)
            //    {
            //        // �݌ɂ��_���폜�ς̏ꍇ�A��������
            //        this.StockRevive(rowIndex);
            //    }
            //    else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 0)
            //    {
            //        // �폜�\��L�����Z������
            //        this.StockDeleteReserveCancel(rowIndex);
            //    }
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/02/23 -------------------------------->>>>>
            List<int> rowIndexList = this.GetSelectRowIndex();

            if (rowIndexList.Count == 0)
            {
                // �I���s�A�A�N�e�B�u�Z���������ꍇ�A�����Ȃ�
                return;
            }

            if (this._includeStockLogicalDeleted)
            {
                // �������܂ޏꍇ�͌x����\��
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "�I�������݌ɂ̂����A�폜�ς݃f�[�^�𕜊����܂��B" + "\r\n" + "\r\n" +
                        "��낵���ł����H",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            foreach (int rowIndex in rowIndexList)
            {
                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value != 0
                    || (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value != 0)
                {
                    // ���i���_���폜�ς܂��͍폜�\��s�̏ꍇ�A�݌ɂ͕������Ȃ�
                    continue;
                }

                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName].Value == 1)
                {
                    // �݌ɂ��_���폜�ς̏ꍇ�A��������
                    status = this.StockRevive(rowIndex);
                }
                else if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value == 1)
                {
                    // �폜�\��L�����Z������
                    this.StockDeleteReserveCancel(rowIndex);
                }
            }

            if (this._includeStockLogicalDeleted
                && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���S�폜�s�����݂��S�Đ���Ɋ������̓��b�Z�[�W��\��
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�������܂����B",
                    0,
                    MessageBoxButtons.OK);
            }

            // �_���폜�s���ăt�B���^
            this.SetGridFiltering();
            // --- ADD 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// �݌ɍ폜�\��L�����Z������
        /// </summary>
        /// <param name="rowIndex"></param>
        private void StockDeleteReserveCancel(int rowIndex)
        {
            this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName].Value = 0; // ADD 2009/02/05
            this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName].Value = DBNull.Value;

            int stockColIndex = this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;

            for (int i = stockColIndex; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                // �L�[�l�ȊO��ҏW�\��
                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.WarehouseCodeColumn.ColumnName)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[i].Activation = Activation.AllowEdit;
                }
            }

            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// �w�i�F�ݒ�
            //this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]);

            //// �_���폜�s���ăt�B���^
            //this.SetGridFiltering();
            // --- DEL 2009/02/23 --------------------------------<<<<<
        }

        /// <summary>
        /// �݌ɕ�������
        /// </summary>
        //private void StockRevive(int rowIndex) // DEL 2009/02/23
        private int StockRevive(int rowIndex) // ADD 2009/02/23
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// ���ӕ����\��
            //DialogResult dialogResult = TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_QUESTION,
            //        this.Name,
            //        "�I�������݌ɂ𕜊����܂��B" + "\r\n" + "\r\n" +
            //        "��낵���ł����H",
            //        0,
            //        MessageBoxButtons.YesNo,
            //        MessageBoxDefaultButton.Button1);

            //if (dialogResult != DialogResult.Yes)
            //{
            //    return;
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<

            string goodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            int goodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;
            string warehouseCd = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value.ToString();

            int status = this._goodsStockAcs.StockRevive(goodsNo, goodsMakerCd, warehouseCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // --- DEL 2009/02/23 -------------------------------->>>>>
                //TMsgDisp.Show(
                //    this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "�������܂����B",
                //    0,
                //    MessageBoxButtons.OK);
                // --- DEL 2009/02/23 --------------------------------<<<<<

                // �݌ɘ_���폜�̒l���X�V
                foreach (DataRow dr in this._goodsStockDataTable.Rows)
                {
                    if (dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                        && (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd
                        && dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString() == warehouseCd)
                    {
                        dr[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] = 0;
                        dr[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName] = 0; // ADD 2009/02/05
                        dr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] = DBNull.Value;

                        dr[this._goodsStockDataTable.RowNumberColumn.ColumnName] = "����"; // ADD 2009/03/06

                        break;
                    }
                }

                // �X�V�p�e�[�u�������l�ɍX�V
                foreach (DataRow originalDr in this._goodsStockAcs.OriginalGoodsStockDataTable.Rows)
                {
                    if (originalDr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == goodsNo
                        && (int)originalDr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == goodsMakerCd
                        && originalDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString() == warehouseCd)
                    {
                        originalDr[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] = 0;
                        originalDr[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName] = 0; // ADD 2009/02/05
                        originalDr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] = DBNull.Value;

                        originalDr[this._goodsStockDataTable.RowNumberColumn.ColumnName] = "����"; // ADD 2009/03/06
                    }
                }

                // �݌ɏ��̂ݕҏW�\��
                int stockColIndex = this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;

                foreach (UltraGridRow ultraRow in this.uGrid_Details.Rows)
                {
                    if (ultraRow.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
                        && (int)ultraRow.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd
                        && ultraRow.Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value.ToString() == warehouseCd)
                    {
                        for (int i = stockColIndex; i < ultraRow.Cells.Count; i++)
                        {
                            // �L�[�l�ȊO��ҏW�\��
                            if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Key != this._goodsStockDataTable.WarehouseCodeColumn.ColumnName)
                            {
                                ultraRow.Cells[i].Activation = Activation.AllowEdit;
                            }
                        }
                    }
                }

                // --- DEL 2009/02/23 -------------------------------->>>>>
                //// �w�i�F�ݒ�
                //this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]);

                //// �_���폜�s���ăt�B���^
                //this.SetGridFiltering();
                // --- DEL 2009/02/23 --------------------------------<<<<<
            }
            // --- ADD 2009/02/02 -------------------------------->>>>>
            else
            {
                switch (status)
                {

                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�V�F�A�`�F�b�N�G���[(��ƃ��b�N)�ł��B" + "\r\n"
                                + "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n"
                                + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�V�F�A�`�F�b�N�G���[(���_���b�N)�ł��B" + "\r\n"
                                + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n"
                                + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�V�F�A�`�F�b�N�G���[(�q�Ƀ��b�N)�ł��B" + "\r\n"
                                + "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n"
                                + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "���������ŃG���[���������܂����B", // ADD 2009/03/03
                                status,
                                MessageBoxButtons.OK);

                            break;
                        }
                }
            }
            // --- ADD 2009/02/02 --------------------------------<<<<<

            return status; // ADD 2009/02/23
        }
        #endregion

        #region �� ���i�ǉ�����
        /// <summary>
        /// ���i�ǉ����C������
        /// </summary>
        /// <param name="rowIndex"></param>
        //private void AddNewRowMain(int rowIndex) // DEL 2009/02/23
        private void AddNewRowMain() // ADD 2009/02/23
        {
            //DataRow newDr = this._goodsStockAcs.GoodsStockDataTable.NewRow(); // DEL 2009/02/23
            DataRow newDr; // ADD 2009/02/23

            if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                // ���i�ǉ�
                newDr = this._goodsStockAcs.GoodsStockDataTable.NewRow(); // ADD 2009/02/23

                // �ŏI�s�ɒǉ�����
                this._goodsStockAcs.GoodsStockDataTable.Rows.Add(newDr);

                // --- ADD 2009/02/03 -------------------------------->>>>>
                // �t�H�[�J�X�ݒ�
                int activationCol;
                int activationRow;

                string nextFocusColumnKey = this.GetNextFocusColumnKey(0, this._goodsStockAcs.GoodsStockDataTable.Rows.Count - 1, false, out activationCol, out activationRow);

                if (nextFocusColumnKey != string.Empty)
                {
                    this.uGrid_Details.Rows[activationRow].Cells[nextFocusColumnKey].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    // (���肦�Ȃ���)�����ꍇ�͍s�A�N�e�B�u
                    this.uGrid_Details.Rows[this._goodsStockAcs.GoodsStockDataTable.Rows.Count - 1].Activate();
                }
                // --- ADD 2009/02/03 --------------------------------<<<<<

                this.SetGridColorAll(); // �w�i�F�Đݒ� // ADD 2009/03/05
            }
            else if (this._beforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {

                // --- DEL 2009/02/23 -------------------------------->>>>>
                #region �폜
                //if (rowIndex == -1)
                //{
                //    // Active�s�������ꍇ�͒ǉ����Ȃ�
                //    return;
                //}

                //// �݌ɒǉ�
                //// �݌ɂ�����(�q�ɃR�[�h�̓��͂�����)�ꍇ�́A�ǉ����Ȃ�(�{�^�������ۂŐ���)
                //if (this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != null
                //    && this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != DBNull.Value)
                //{
                //    // �\�[�g�A�t�B���^��Ԃ̊m�F
                //    SortedColumnsCollection sr = this.uGrid_Details.DisplayLayout.Bands[0].SortedColumns;
                //    ColumnFiltersCollection fr = this.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters;

                //    if (sr.Count != 0 || fr.Count != 0)
                //    {
                //        DialogResult dialogResult = TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_QUESTION,
                //            this.Name,
                //            "���݂̃t�B���^�A�\�[�g������j�����Ă���낵���ł����H",
                //            0,
                //            MessageBoxButtons.YesNo,
                //            MessageBoxDefaultButton.Button1);

                //        if (dialogResult == DialogResult.Yes)
                //        {
                //            // �I���s�̃L�[�l��ێ�
                //            string goodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
                //            int goodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;
                //            string warehouseCd = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value.ToString();

                //            sr.Clear();
                //            sr.RefreshSort(true); // �ă\�[�g���s(true���ƍs)
                //            fr.ClearAllFilters();

                //            // �\�[�g�������RowIndex���擾
                //            for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
                //            {
                //                if (this.uGrid_Details.Rows[i].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != null
                //                    && this.uGrid_Details.Rows[i].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != DBNull.Value)
                //                {
                //                    if (this.uGrid_Details.Rows[i].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
                //                        && (int)this.uGrid_Details.Rows[i].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd
                //                        && this.uGrid_Details.Rows[i].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value.ToString() == warehouseCd)
                //                    {
                //                        rowIndex = i;
                //                        break;
                //                    }
                //                }
                //            }

                //            // �݌ɒǉ��̏ꍇ�A�I���s�̏��i�����R�s�[
                //            int goodsLastColIndex = this.uGrid_Details.DisplayLayout.Bands[0]
                //                .Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index;

                //            for (int i = 1; i < goodsLastColIndex; i++)
                //            {
                //                newDr[i] = this.uGrid_Details.Rows[rowIndex].Cells[i].Value;
                //            }

                //            // �w��s�ɒǉ�
                //            this._goodsStockDataTable.Rows.InsertAt(newDr, rowIndex + 1);

                //            // --- ADD 2009/02/04 -------------------------------->>>>>
                //            // �i�Ԃƃ��[�J�[�͕ύX�s�\(���̑����͕s�s�͗�P�ʂŐ��䂳��Ă���̂�Activation�w��s�v)
                //            this.uGrid_Details.Rows[rowIndex + 1].Cells[
                //                this._goodsStockDataTable.GoodsNoColumn.ColumnName].Activation = Activation.Disabled;
                //            this.uGrid_Details.Rows[rowIndex + 1].Cells[
                //                this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Activation = Activation.Disabled;
                //            // --- ADD 2009/02/04 --------------------------------<<<<<

                //            // --- DEL 2009/02/23 -------------------------------->>>>>
                //            //int activationCol;
                //            //int activationRow;

                //            //string nextFocusColumnKey = this.GetNextFocusColumnKey(0, rowIndex + 1, false, out activationCol, out activationRow);

                //            //if (nextFocusColumnKey != string.Empty)
                //            //{
                //            //    this.uGrid_Details.Rows[activationRow].Cells[nextFocusColumnKey].Activate();
                //            //    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                //            //}
                //            //else
                //            //{
                //            //    // (���肦�Ȃ���)�����ꍇ�͍s�A�N�e�B�u
                //            //    this.uGrid_Details.Rows[rowIndex + 1].Activate();
                //            //}
                //            // --- DEL 2009/02/23 --------------------------------<<<<<

                //            // --- ADD 2009/02/23 -------------------------------->>>>>
                //            // �ǉ��s�̑q�ɃR�[�h�Ƀt�H�[�J�X
                //            this.uGrid_Details.Rows[rowIndex + 1].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Activate();
                //            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                //            // --- ADD 2009/02/23 --------------------------------<<<<<

                //            // �_���폜�t�B���^���Đݒ�
                //            SetGridFiltering();

                //            return;
                //        }
                //        else
                //        {
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        // �݌ɒǉ��̏ꍇ�A�I���s�̏��i�����R�s�[
                //        int goodsLastColIndex = this.uGrid_Details.DisplayLayout.Bands[0]
                //            .Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index;

                //        for (int i = 1; i < goodsLastColIndex; i++)
                //        {
                //            newDr[i] = this.uGrid_Details.Rows[rowIndex].Cells[i].Value;
                //        }

                //        // �w��s�ɒǉ�
                //        this._goodsStockDataTable.Rows.InsertAt(newDr, rowIndex + 1);
                //    }
                //}
                #endregion
                // --- DEL 2009/02/23 --------------------------------<<<<<
                // --- ADD 2009/02/23 -------------------------------->>>>>


                //List<int> addRowIndexList = new List<int>();
                //foreach (int selectedRowIndex in selectedRowIndexList)
                //{
                //    // ���i���폜�ςłȂ����폜�\��s�łȂ����q�ɃR�[�h�ɓ��͂�����
                //    if ((int)this.uGrid_Details.Rows[selectedRowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                //        && (int)this.uGrid_Details.Rows[selectedRowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0
                //        && this.uGrid_Details.Rows[selectedRowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != null
                //        && this.uGrid_Details.Rows[selectedRowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != DBNull.Value)
                //    {
                //        addRowIndexList.Add(selectedRowIndex);
                //    }
                //}

                //if (addRowIndexList.Count == 0)
                //{
                //    // �Ώۍs�Ȃ�(�{�^������ł��̃P�[�X�͏�����Ă���͂�)
                //    return;
                //}

                // �\�[�g�A�t�B���^��Ԃ̊m�F
                SortedColumnsCollection sr = this.uGrid_Details.DisplayLayout.Bands[0].SortedColumns;
                ColumnFiltersCollection fr = this.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters;

                if (sr.Count != 0 || fr.Count != 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        //"���݂̃t�B���^�A�\�[�g������j�����Ă���낵���ł����H", // DEL 2009/03/05
                        "���ׂ̕\���ɂ��ă\�[�g��i�荞�݂��s���Ă���ꍇ�A" + "\r\n"
                        + "�����̐ݒ肪�N���A����܂�����낵���ł��傤���H", // ADD 2009/03/05
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        sr.Clear();
                        sr.RefreshSort(true); // �ă\�[�g���s(true���ƍs)
                        fr.ClearAllFilters();
                    }
                    else
                    {
                        return; // ADD 2009/03/03
                    }
                }

                //// �I���s�擾(�\�[�g�t�B���^�������Index�ɂȂ�)
                //List<int> selectedRowIndexList = this.GetSelectRowIndex(); // DEL 2009/03/03

                // �݌ɒǉ��̓A�N�e�B�u�s�ɑ΂��čs��
                int rowIndex = this.uGrid_Details.ActiveRow.Index; // ADD 2009/03/03

                // �݌ɃJ�����J�nIndex
                int goodsLastColIndex = this.uGrid_Details.DisplayLayout.Bands[0]
                    .Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index;

                //for (int rowIndex = selectedRowIndexList.Count - 1; rowIndex >= 0; rowIndex--) // DEL 2009/03/02
                // --- DEL 2009/03/03 -------------------------------->>>>>
                //for (int j = selectedRowIndexList.Count - 1; j >= 0; j--) // ADD 2009/03/02
                //{
                //    int rowIndex = selectedRowIndexList[j]; // ADD 2009/03/02
                // --- DEL 2009/03/03 --------------------------------<<<<<

                //// ���i���폜�ςłȂ����폜�\��s�łȂ����q�ɃR�[�h�ɓ��͂�����
                //if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                //    && (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0
                //    && this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != null
                //    && this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value != DBNull.Value) // DEL 2009/03/03
                // ���i���폜�ςłȂ����폜�\��s�łȂ��������i�őq�ɃR�[�h�ɓ��̖͂����f�[�^���Ȃ�
                if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value == 0
                    && (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value == 0
                    && !this.CheckStockNotExist(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(),
                        (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value))
                {
                    newDr = this._goodsStockAcs.GoodsStockDataTable.NewRow();

                    // �݌ɒǉ��̏ꍇ�A�I���s�̏��i�����R�s�[
                    for (int i = 1; i <= goodsLastColIndex; i++)
                    {
                        // �݌ɂ̘_���폜�A�폜�\��͏���
                        if (this.uGrid_Details.Rows[rowIndex].Cells[i].Column.Key != this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName
                            && this.uGrid_Details.Rows[rowIndex].Cells[i].Column.Key != this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName
                            && this.uGrid_Details.Rows[rowIndex].Cells[i].Column.Key != this._goodsStockDataTable.StockDeleteDateColumn.ColumnName) // ADD 2009/03/03
                        {
                            newDr[i] = this.uGrid_Details.Rows[rowIndex].Cells[i].Value;
                        }
                    }

                    // �w��s�ɒǉ�
                    this._goodsStockDataTable.Rows.InsertAt(newDr, rowIndex + 1);

                    // �i�Ԃƃ��[�J�[�͕ύX�s�\(���̑����͕s�s�͗�P�ʂŐ��䂳��Ă���̂�Activation�w��s�v)
                    this.uGrid_Details.Rows[rowIndex + 1].Cells[
                        this._goodsStockDataTable.GoodsNoColumn.ColumnName].Activation = Activation.Disabled;
                    this.uGrid_Details.Rows[rowIndex + 1].Cells[
                        this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Activation = Activation.Disabled;

                    // �ǉ��s�̑q�ɃR�[�h�Ƀt�H�[�J�X
                    this.uGrid_Details.Rows[rowIndex + 1].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                //} // DEL 2009/03/03

                // �_���폜�t�B���^���Đݒ�
                SetGridFiltering();
                // --- ADD 2009/02/23 --------------------------------<<<<<
            }

            // ���i�ǉ���͕ۑ��{�^����
            this.SetSaveButton(); // ADD 2009/02/23
        }
        #endregion

        #region �� ���i�\������
        /// <summary>
        /// ���i�\���̕ύX���s��
        /// </summary>
        private void DispPriceMain()
        {
            if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            {
                // �Ώۋ敪�u�݌Ɂv�̏ꍇ�A�\���Ώۂł͂Ȃ��̂Ő���Ȃ�
                return;
            }

            bool hiddenStat;

            if (this.uGrid_Details.DisplayLayout.Bands[0]
                .Columns[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Hidden == true)
            {
                hiddenStat = false;
            }
            else
            {
                hiddenStat = true;
            }

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];

            // --- UPD 2010/08/11 ---------->>>>>
            //// ���i���X�g2�A3�̕\����Ԃ�ݒ�
            //band.Columns[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.ListPrice2Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.OpenPriceDiv2Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.StockRate2Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.SalesUnitCost2Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.PriceStartDate3Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.ListPrice3Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.OpenPriceDiv3Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.StockRate3Column.ColumnName].Hidden = hiddenStat;
            //band.Columns[this._goodsStockDataTable.SalesUnitCost3Column.ColumnName].Hidden = hiddenStat;

            PriceChgSetAcs priceChgSetAcs = new PriceChgSetAcs();
            PriceChgSet priceChgSet = new PriceChgSet();

            int status = priceChgSetAcs.Read(out priceChgSet, this._enterpriseCode);
            
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                switch (priceChgSet.PriceMngCnt)
                {
                    case 3:
                        {
                            // ���i���X�g2�A3�̕\����Ԃ�ݒ�
                            band.Columns[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate4Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.ListPrice4Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv4Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.StockRate4Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost4Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.PriceStartDate5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.ListPrice5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.StockRate5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost5Column.ColumnName].Hidden = true;
                            break;
                        }
                    case 4:
                        {
                            // ���i���X�g2�A3�A4�̕\����Ԃ�ݒ�
                            band.Columns[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.ListPrice5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.StockRate5Column.ColumnName].Hidden = true;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost5Column.ColumnName].Hidden = true;
                            break;
                        }
                    case 5:
                        {
                            // ���i���X�g2�A3�A4�A5�̕\����Ԃ�ݒ�
                            band.Columns[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost2Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost3Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost4Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.PriceStartDate5Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.ListPrice5Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.OpenPriceDiv5Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.StockRate5Column.ColumnName].Hidden = hiddenStat;
                            band.Columns[this._goodsStockDataTable.SalesUnitCost5Column.ColumnName].Hidden = hiddenStat;
                            break;
                        }
                }
            }
            // --- UPD 2010/08/11 ----------<<<<<
        }
        #endregion

        #region �� ���̕\������
        /// <summary>
        /// ���̕\���̕ύX���s��
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote       : 2010/06/08 ���� ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
        /// </remarks>
        private void DispNameMain()
        {
            bool hiddenStat;

            if (this._visibleNameColumnsStat)
            {
                // �\�����Ȃ�
                hiddenStat = true;
            }
            else
            {
                // �\������
                hiddenStat = false;
            }

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];

            if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                band.Columns[this._goodsStockDataTable.GoodsNameColumn.ColumnName].Hidden = hiddenStat; // �i��
                band.Columns[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].Hidden = hiddenStat; // ���[�J�[��
                // --- DEL 2010/06/08 ---------->>>>>
                //band.Columns[this._goodsStockDataTable.GoodsNameKanaColumn.ColumnName].Hidden = hiddenStat; // �i���J�i
                // --- DEL 2010/06/08 ----------<<<<<
                band.Columns[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].Hidden = hiddenStat; // BL�R�[�h
                band.Columns[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].Hidden = hiddenStat; // ���i�敪��
                band.Columns[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName].Hidden = hiddenStat; // ���i�����ޖ�
                band.Columns[this._goodsStockDataTable.BLGroupNameColumn.ColumnName].Hidden = hiddenStat; // �O���[�v�R�[�h��
            }
            else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            {
                band.Columns[this._goodsStockDataTable.GoodsNameColumn.ColumnName].Hidden = hiddenStat; // �i��

                band.Columns[this._goodsStockDataTable.WarehouseNameColumn.ColumnName].Hidden = hiddenStat; // �q�ɖ�
                band.Columns[this._goodsStockDataTable.StockSupplierSnmColumn.ColumnName].Hidden = hiddenStat; // �����於

            }
            else if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock
                || this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods)
            {
                band.Columns[this._goodsStockDataTable.GoodsNameColumn.ColumnName].Hidden = hiddenStat; // �i��
                band.Columns[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].Hidden = hiddenStat; // ���[�J�[��
                // --- DEL 2010/06/08 ---------->>>>>
                //band.Columns[this._goodsStockDataTable.GoodsNameKanaColumn.ColumnName].Hidden = hiddenStat; // �i���J�i
                // --- DEL 2010/06/08 ----------<<<<<
                band.Columns[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].Hidden = hiddenStat; // BL�R�[�h
                band.Columns[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].Hidden = hiddenStat; // ���i�敪��
                band.Columns[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName].Hidden = hiddenStat; // ���i�����ޖ�
                band.Columns[this._goodsStockDataTable.BLGroupNameColumn.ColumnName].Hidden = hiddenStat; // �O���[�v�R�[�h��

                band.Columns[this._goodsStockDataTable.WarehouseNameColumn.ColumnName].Hidden = hiddenStat; // �q�ɖ�
                band.Columns[this._goodsStockDataTable.StockSupplierSnmColumn.ColumnName].Hidden = hiddenStat; // �����於
            }

            // ���̕\����ԃt���O�̍X�V
            if (hiddenStat)
            {
                this._visibleNameColumnsStat = false;
            }
            else
            {
                this._visibleNameColumnsStat = true;
            }
        }
        #endregion

        #region �� �K�C�h����
        /// <summary>
        /// �K�C�h�������C��
        /// </summary>
        //private void ExecuteGuideMain() // DEL 2010/08/11
        public void ExecuteGuideMain() // ADD 2010/08/11
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell activeCell = this.uGrid_Details.ActiveCell;

            if (activeCell == null)
            {
                // �Z�����I������Ă��Ȃ���Ώ������Ȃ�
                return;
            }

            int status;

            switch (activeCell.Column.Key)
            {
                case "GoodsMaker":
                    {
                        MakerUMnt makerUMnt;

                        // ���[�J�[�K�C�h�N��
                        status = this.ExecuteMakerGuide(out makerUMnt);

                        if (status == 0)
                        {
                            activeCell.Value = makerUMnt.GoodsMakerCd;
                            this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerName;

                            // �t�H�[�J�X�ړ�
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                case "BLGoodsCode":
                    {
                        BLGoodsCdUMnt bLGoodsCdUMnt;

                        // BL�R�[�h�K�C�h�N��
                        status = this.ExecuteBLGoodsCodeGuide(out bLGoodsCdUMnt);

                        if (status == 0)
                        {
                            activeCell.Value = bLGoodsCdUMnt.BLGoodsCode;
                            this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].Value = bLGoodsCdUMnt.BLGoodsHalfName;

                            status = this._blGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, bLGoodsCdUMnt.BLGoodsCode);


                            if (status == 0)
                            {
                                // �O���[�v�R�[�h
                                BLGroupU bLGroupU;

                                status = this._blGroupUAcs.Search(out bLGroupU, this._enterpriseCode, bLGoodsCdUMnt.BLGloupCode);

                                if (status == 0)
                                {
                                    this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.BLGroupCodeColumn.ColumnName].Value = bLGroupU.BLGroupCode;
                                    this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.BLGroupNameColumn.ColumnName].Value = bLGroupU.BLGroupName;

                                    // �����ރR�[�h
                                    GoodsGroupU goodsGroupU;

                                    status = this._goodsGroupUAcs.Search(out goodsGroupU, this._enterpriseCode, bLGroupU.GoodsMGroup);

                                    if (status == 0)
                                    {
                                        this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.GoodsMGroupColumn.ColumnName].Value = goodsGroupU.GoodsMGroup;
                                        this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName].Value = goodsGroupU.GoodsMGroupName;
                                    }
                                }
                            }

                            // �t�H�[�J�X�ݒ�
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                case "EnterpriseGanreCode":
                    {
                        UserGdHd userGdHd;
                        UserGdBd userGdBd;

                        // ���i�敪�K�C�h�N��
                        status = this.ExecuteEnterpriseGanreCodeGuide(out userGdHd, out userGdBd);

                        if (status == 0)
                        {
                            activeCell.Value = userGdBd.GuideCode;
                            this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].Value = userGdBd.GuideName;

                            // �t�H�[�J�X�ݒ�
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                case "WarehouseCode":
                    {
                        Warehouse warehouse;

                        // �q�ɃK�C�h�N��
                        status = this.ExecuteWarehouseGuide(out warehouse);
                        

                        if (status == 0)
                        {
                            activeCell.Value = warehouse.WarehouseCode.Trim();
                            this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.WarehouseNameColumn.ColumnName].Value = warehouse.WarehouseName;

                            // �t�H�[�J�X�ݒ�
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                case "PartsManagementDivide1":
                    {
                        UserGdHd userGdHd;
                        UserGdBd userGdBd;

                        // �Ǘ��敪�K�C�h1�N��
                        status = this.ExecutePartsManagementDivide1Guide(out userGdHd, out userGdBd);

                        if (status == 0)
                        {
                            activeCell.Value = userGdBd.GuideCode;

                            // �t�H�[�J�X�ݒ�
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                case "PartsManagementDivide2":
                    {
                        UserGdHd userGdHd;
                        UserGdBd userGdBd;

                        // �Ǘ��敪�K�C�h2�N��
                        status = this.ExecutePartsManagementDivide2Guide(out userGdHd, out userGdBd);

                        if (status == 0)
                        {
                            activeCell.Value = userGdBd.GuideCode;

                            // �t�H�[�J�X�ݒ�
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                case "StockSupplierCode":
                    {
                        // �d����K�C�h�N��
                        Supplier supplier;

                        status = this.ExecuteSupplierGuide(out supplier);

                        if (status == 0)
                        {
                            activeCell.Value = supplier.SupplierCd;
                            this.uGrid_Details.Rows[activeCell.Row.Index].Cells[this._goodsStockDataTable.StockSupplierSnmColumn.ColumnName].Value = supplier.SupplierSnm;

                            // �t�H�[�J�X�ݒ�
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// ���[�J�[�K�C�h
        /// </summary>
        internal int ExecuteMakerGuide(out MakerUMnt makerUmnt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            makerUmnt = new MakerUMnt();

            try
            {
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUmnt);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// BL�R�[�h�K�C�h
        /// </summary>
        /// <param name="bLGoodsCdUMnt"></param>
        /// <returns></returns>
        internal int ExecuteBLGoodsCodeGuide(out BLGoodsCdUMnt bLGoodsCdUMnt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            bLGoodsCdUMnt = new BLGoodsCdUMnt();

            try
            {
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        ///  ���Е���(���i�敪)�K�C�h�N��
        /// </summary>
        /// <returns></returns>
        private int ExecuteEnterpriseGanreCodeGuide(out UserGdHd userGdHd, out UserGdBd userGdBd)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            userGdHd = new UserGdHd();
            userGdBd = new UserGdBd();

            try
            {
                status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 41);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// �d����K�C�h�N��
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        private int ExecuteSupplierGuide(out Supplier supplier)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            supplier = new Supplier();

            try
            {
                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, this._loginSectionCode);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        ///  �q�ɃK�C�h�N��
        /// </summary>
        /// <returns></returns>
        internal int ExecuteWarehouseGuide(out Warehouse warehouse)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            warehouse = new Warehouse();

            try
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// �Ǘ��敪�K�C�h1�N��
        /// </summary>
        /// <param name="userGdHd"></param>
        /// <param name="userGdBd"></param>
        /// <returns></returns>
        private int ExecutePartsManagementDivide1Guide(out UserGdHd userGdHd, out UserGdBd userGdBd)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            userGdHd = new UserGdHd();
            userGdBd = new UserGdBd();

            try
            {
                status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 72);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// �Ǘ��敪�K�C�h2�N��
        /// </summary>
        /// <param name="userGdHd"></param>
        /// <param name="userGdBd"></param>
        /// <returns></returns>
        private int ExecutePartsManagementDivide2Guide(out UserGdHd userGdHd, out UserGdBd userGdBd)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            userGdHd = new UserGdHd();
            userGdBd = new UserGdBd();

            try
            {
                status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 73);
            }
            catch
            {
                status = -1;
            }

            return status;
        }
        #endregion
        #endregion

        #region ���R���g���[���C�x���g

        #region �� �����C�x���g
        /// <summary>
        /// PMZAI09201UB_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI09201UB_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.DataSource = this._goodsStockDataTable;

            string errMsg = string.Empty;

            // �R���g���[��������
            this.InitializeScreen();

            // �O���b�h������
            this.InitializeGrid();

            // �����\�����A���̕\����Ԃ�true
            this._visibleNameColumnsStat = true;

            // �O���b�h�L�[�}�b�s���O�ݒ菈��
            // ����Ȃ��H�@�ҏW���[�h�ɂȂ�Ȃ��B�B�B
            //this.MakeKeyMappingForGrid(this.uGrid_Details);
        }

        /// <summary>
        /// InitializeLayout�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�񖼃N���b�N�ɂ��\�[�g�A�t�B���^�ݒ���s���B</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �w�b�_�N���b�N�A�N�V�����̐ݒ�(�\�[�g����)
            e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            // �s�t�B���^�[�ݒ�
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            // �����s�I����
            e.Layout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag; // ADD 2009/02/23
        }
        #endregion

        #region �� �O���b�h�Z���X�V�C�x���g
        /// <summary>
        /// �Z���A�N�e�B�u�O�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2013/05/11 yangyi</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
        /// <br>           : Redmine#35018 �u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���@���̂Q�Ή�</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.7 ----->>>>>
            this._gridGoodsNo = string.Empty;
            this._gridGoodsMakerCd = 0;
            //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.7 -----<<<<<

            #region ���Z���ҏW�֘A
            // ���ʐݒ�ɏ]��IME���[�h�ݒ�
            this.uGrid_Details.ImeMode = this.uiSetControl2.GetSettingImeMode(e.Cell.Column.Key);

            // �[���l�߉������s
            if (e.Cell.Column.DataType == typeof(string) &&
                e.Cell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
            {
                if (e.Cell.Value != DBNull.Value)
                {
                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value =
                        this.uiSetControl2.GetZeroPadCanceledText(e.Cell.Column.Key,
                        (string)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value);
                }
            }
            #endregion

            #region ���ҏW�O���ڒl�ۑ�
            switch (e.Cell.Column.Key)
            {
                case "GoodsNo":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpGoodsNo = string.Empty;
                        }
                        else
                        {
                            this._tmpGoodsNo = e.Cell.Value.ToString();
                        }

                        break;
                    }
                case "GoodsMaker":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value || e.Cell.Value.ToString() == string.Empty)
                        {
                            this._tmpGoodsMaker = 0;
                        }
                        else
                        {
                            this._tmpGoodsMaker = (int)e.Cell.Value;
                        }

                        break;
                    }
                case "BLGoodsCode":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value || e.Cell.Value.ToString() == string.Empty)
                        {
                            this._tmpBLGoodsCode = 0;
                        }
                        else
                        {
                            this._tmpBLGoodsCode = (int)e.Cell.Value;
                        }

                        break;
                    }
                case "EnterpriseGanreCode":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value || e.Cell.Value.ToString() == string.Empty)
                        {
                            this._tmpEnterpriseGanreCode = 0;
                        }
                        else
                        {
                            this._tmpEnterpriseGanreCode = (int)e.Cell.Value;
                        }

                        break;
                    }
                case "WarehouseCode":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpWarehouseCode = string.Empty;
                        }
                        else
                        {
                            this._tmpWarehouseCode = e.Cell.Value.ToString();
                        }

                        break;
                    }
                case "StockSupplierCode":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value || e.Cell.Value.ToString() == string.Empty)
                        {
                            this._tmpStockSupplierCode = 0;
                        }
                        else
                        {
                            this._tmpStockSupplierCode = (int)e.Cell.Value;
                        }

                        break;
                    }
                case "PriceStartDate1":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpPriceStartDate1 = string.Empty;
                        }
                        else
                        {
                            this._tmpPriceStartDate1 = e.Cell.Value.ToString();
                        }

                        break;
                    }
                case "PriceStartDate2":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpPriceStartDate2 = string.Empty;
                        }
                        else
                        {
                            this._tmpPriceStartDate2 = e.Cell.Value.ToString();
                        }

                        break;
                    }
                case "PriceStartDate3":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpPriceStartDate3 = string.Empty;
                        }
                        else
                        {
                            this._tmpPriceStartDate3 = e.Cell.Value.ToString();
                        }

                        break;
                    }
                // --- ADD 2010/08/31 ---------->>>>>
                case "PriceStartDate4":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpPriceStartDate4 = string.Empty;
                        }
                        else
                        {
                            this._tmpPriceStartDate4 = e.Cell.Value.ToString();
                        }

                        break;
                    }
                case "PriceStartDate5":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpPriceStartDate5 = string.Empty;
                        }
                        else
                        {
                            this._tmpPriceStartDate5 = e.Cell.Value.ToString();
                        }

                        break;
                    }
                // --- ADD 2010/08/31 ----------<<<<<
                case "SalesOrderUnit":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value || e.Cell.Value.ToString() == string.Empty)
                        {
                            this._tmpSalesOrderUnit = 0;
                        }
                        else
                        {
                            this._tmpSalesOrderUnit = (int)e.Cell.Value;
                        }

                        break;
                    }
                case "MinimumStockCnt":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value || e.Cell.Value.ToString() == string.Empty)
                        {
                            this._tmpMinimumStockCnt = 0;
                        }
                        else
                        {
                            this._tmpMinimumStockCnt = (double)e.Cell.Value;
                        }

                        break;
                    }
                case "MaximumStockCnt":
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value || e.Cell.Value.ToString() == string.Empty)
                        {
                            this._tmpMaximumStockCnt = 0;
                        }
                        else
                        {
                            this._tmpMaximumStockCnt = (double)e.Cell.Value;
                        }

                        break;
                    }
            }
            #endregion

            // --- ADD 2009/02/04 -------------------------------->>>>>
            #region �������i�����ڍ폜����
            // ���i���ڈꊇ�ύX����(�����i�̐ݒ�l������)
            if (this._beforeSearchExtractInfo != null
                &&
                (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock
                || this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods)
                )
            {
                // ���i�̃J�����̂�
                if (e.Cell.Column.Index <= this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index)
                {
                    // �݌ɍ폜���͏���
                    if (e.Cell.Column.Key != this._goodsStockDataTable.StockDeleteDateColumn.ColumnName)
                    {
                        string goodsNo = this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
                        int goodsMakerCd = (int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;

                        //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.7 ----->>>>>
                        this._gridGoodsNo = goodsNo;
                        this._gridGoodsMakerCd = goodsMakerCd;
                        //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.7 -----<<<<<

                        // �����i�̓���̏�������(��\���ɂ���B��A�N�e�B�u�C�x���g�ŕҏW�Z���̒l���R�s�[����)
                        foreach (UltraGridRow ultraGr in this.uGrid_Details.Rows)
                        {
                            if (ultraGr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
                                && (int)ultraGr.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd)
                            {
                                // �ҏW�s���̂͏���
                                if (ultraGr.Index != e.Cell.Row.Index)
                                {
                                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                                    ultraGr.Cells[e.Cell.Column.Index].Value = DBNull.Value;
                                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            // --- ADD 2009/02/04 --------------------------------<<<<<

            // �{�^������
            //this.SetButtonEnableByRow(e.Cell.Row.Index, e.Cell.Column.Key); // DEL 2009/02/23
            this.SetButtonEnableByCell(e.Cell.Row.Index, e.Cell.Column.Key); // ADD 2009/02/23
        }

        /// <summary>
        /// uGrid_Details_AfterCellUpdate�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns; // 2010/08/11
            switch (e.Cell.Column.Key)
            {
                case "GoodsNo":
                    {
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value != null
                            && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value != DBNull.Value
                            && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value != null
                            && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value != DBNull.Value
                            && (int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value != 0) // ADD 2009/03/03
                        {
                            // �i�Ԃ̐ݒ肪����ꍇ�A���i�̃L�[�d���`�F�b�N
                            if (!this._goodsStockAcs.CheckKeyDuplication(
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(),
                                (int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value,
                                string.Empty))
                            {
                                // �Y���Ȃ�
                                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                this.Name,											// �A�Z���u��ID
                                                "�w�肳�ꂽ���i�͊��ɓo�^����Ă��܂��B",           // �\�����郁�b�Z�[�W
                                                -1,													// �X�e�[�^�X�l
                                                MessageBoxButtons.OK);								// �\������{�^��

                                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                                e.Cell.Value = this._tmpGoodsNo;
                                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                            }
                        }

                        break;
                    }
                case "GoodsMaker":
                    {

                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == null
                            || this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == DBNull.Value
                            || (int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == 0) // ADD 2009/03/03
                        {
                            // ���͂�������΃`�F�b�N���Ȃ�
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].Value = 0; // ADD 2009/03/03
                            break;
                        }

                        MakerUMnt makerUMnt;

                        int goodsMakerCd = (int)e.Cell.Value;

                        int status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, goodsMakerCd);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || makerUMnt == null || (makerUMnt != null && makerUMnt.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status != 0)
                        {
                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����Ń��[�J�[�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            e.Cell.Value = this._tmpGoodsMaker;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;

                            break;
                        }

                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value != null
                                && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value != DBNull.Value)
                        {
                            // �i�Ԃ̐ݒ肪����ꍇ�A���i�̃L�[�d���`�F�b�N
                            if (!this._goodsStockAcs.CheckKeyDuplication(
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(),
                                goodsMakerCd, string.Empty))
                            {
                                // �Y���Ȃ�
                                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                this.Name,											// �A�Z���u��ID
                                                "�w�肳�ꂽ���i�͊��ɓo�^����Ă��܂��B",           // �\�����郁�b�Z�[�W
                                                -1,													// �X�e�[�^�X�l
                                                MessageBoxButtons.OK);								// �\������{�^��

                                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                                e.Cell.Value = this._tmpGoodsMaker;
                                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                            }
                            else
                            {
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerName;
                            }
                        }
                        else
                        {
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerName; // ADD 2009/02/03
                        }

                        break;
                    }
                case "BLGoodsCode":
                    {
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.BLGoodsCodeColumn.ColumnName].Value == null
                            || this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.BLGoodsCodeColumn.ColumnName].Value == DBNull.Value)
                        {
                            // ���͂�������΃`�F�b�N���Ȃ�
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].Value = string.Empty;
                            break;
                        }

                        BLGoodsCdUMnt bLGoodsCdUMnt;

                        int blGoodsCd = (int)e.Cell.Value;

                        int status = this._blGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, blGoodsCd);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || bLGoodsCdUMnt == null || (bLGoodsCdUMnt != null && bLGoodsCdUMnt.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == 0)
                        {
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].Value = bLGoodsCdUMnt.BLGoodsHalfName;

                            // �O���[�v�R�[�h
                            BLGroupU bLGroupU;

                            status = this._blGroupUAcs.Search(out bLGroupU, this._enterpriseCode, bLGoodsCdUMnt.BLGloupCode);

                            if (status == 0)
                            {
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.BLGroupCodeColumn.ColumnName].Value = bLGroupU.BLGroupCode;
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.BLGroupNameColumn.ColumnName].Value = bLGroupU.BLGroupName;

                                // �����ރR�[�h
                                GoodsGroupU goodsGroupU;

                                status = this._goodsGroupUAcs.Search(out goodsGroupU, this._enterpriseCode, bLGroupU.GoodsMGroup);

                                if (status == 0)
                                {
                                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMGroupColumn.ColumnName].Value = goodsGroupU.GoodsMGroup;
                                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName].Value = goodsGroupU.GoodsMGroupName;
                                }
                            }
                        }
                        else
                        {
                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����ła�k�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            e.Cell.Value = this._tmpBLGoodsCode;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }

                        break;
                    }
                case "EnterpriseGanreCode":
                    {
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.EnterpriseGanreCodeColumn.ColumnName].Value == null
                            || this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.EnterpriseGanreCodeColumn.ColumnName].Value == DBNull.Value)
                        {
                            // ���͂�������΃`�F�b�N���Ȃ�
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].Value = string.Empty;
                            break;
                        }

                        UserGdBd userGdBd;

                        int enterpriseGanreCode = (int)e.Cell.Value;

                        UserGuideAcsData userGuideAcsData = UserGuideAcsData.UserBodyData;
                        int status = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 41, enterpriseGanreCode, ref userGuideAcsData);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || userGdBd == null || (userGdBd != null && userGdBd.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == 0)
                        {
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].Value = userGdBd.GuideName;
                        }
                        else
                        {
                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����ŏ��i�敪�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            e.Cell.Value = this._tmpEnterpriseGanreCode;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }

                        break;
                    }
                case "WarehouseCode":
                    {
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value == null
                            || this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].Value == DBNull.Value)
                        {
                            // ���͂�������΃`�F�b�N���Ȃ�
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.WarehouseNameColumn.ColumnName].Value = string.Empty;
                            break;
                        }

                        // �q�ɂ�0���ߏ������s��
                        Warehouse warehouse;

                        string warehouseCd = e.Cell.Value.ToString().TrimEnd().PadLeft(4, '0');

                        int status = this._warehouseAcs.Read(out warehouse, this._enterpriseCode, string.Empty, warehouseCd);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || warehouse == null || (warehouse != null && warehouse.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status != 0)
                        {
                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����őq�ɃR�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            e.Cell.Value = this._tmpWarehouseCode;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;

                            break;
                        }

                        // �݌ɂ̃L�[�d���`�F�b�N
                        if (!this._goodsStockAcs.CheckKeyDuplication(
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString(),
                            (int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value,
                            warehouseCd))
                        {
                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�݌ɂ͊��ɓo�^����Ă��܂��B",           // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;   
                            e.Cell.Value = this._tmpWarehouseCode;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }
                        else
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            e.Cell.Value = warehouseCd.PadLeft(4, '0');
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.WarehouseNameColumn.ColumnName].Value = warehouse.WarehouseName;
                        }

                        break;
                    }
                case "StockSupplierCode":
                    {
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.StockSupplierCodeColumn.ColumnName].Value == null
                            || this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.StockSupplierCodeColumn.ColumnName].Value == DBNull.Value)
                        {
                            // ���͂�������΃`�F�b�N���Ȃ�
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.StockSupplierSnmColumn.ColumnName].Value = string.Empty;
                            break;
                        }

                        Supplier supplier;

                        int supplierCd = (int)e.Cell.Value;

                        int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCd);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || supplier == null || (supplier != null && supplier.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == 0)
                        {
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.StockSupplierSnmColumn.ColumnName].Value = supplier.SupplierSnm;
                        }
                        else
                        {
                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����Ŕ�����R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            e.Cell.Value = this._tmpStockSupplierCode;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }

                        break;
                    }

                // --- ADD 2010/08/11 ---------->>>>>
                case "GoodsKindCode":
                case "TaxationDivCd":
                case "OpenPriceDiv1":
                case "OpenPriceDiv2":
                case "OpenPriceDiv3":
                case "OpenPriceDiv4": // ADD 2010/08/31
                case "OpenPriceDiv5": // ADD 2010/08/31
                case "StockDiv":
                    {
                        if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
                        {
                            bool inputErrorFlg = true;
                            Infragistics.Win.ValueList list = (Infragistics.Win.ValueList)Columns[e.Cell.Column.Key].ValueList;
                            foreach (Infragistics.Win.ValueListItem item in list.ValueListItems)
                            {
                                if (item.DataValue.Equals(e.Cell.Value))
                                {
                                    inputErrorFlg = false;
                                    break;
                                }
                            }

                            if (inputErrorFlg)
                            {
                                e.Cell.Value = this._preComboEditorValue;
                            }
                            else
                            {
                                this._preComboEditorValue = e.Cell.Value;
                            }
                        }
                        else
                        {
                            e.Cell.Value = this._preComboEditorValue;
                        }
                        break;
                    }
                // --- ADD 2010/08/11 ----------<<<<<
            }

            // ���͌`���`�F�b�N
            // ���i�J�n��
            if (e.Cell.Column.Key == "PriceStartDate1"
                || e.Cell.Column.Key == "PriceStartDate2"
                || e.Cell.Column.Key == "PriceStartDate3"
                || e.Cell.Column.Key == "PriceStartDate4"  // ADD 2010/08/31
                || e.Cell.Column.Key == "PriceStartDate5")   // ADD 2010/08/31
            {
                if (e.Cell.Value != null && e.Cell.Value != DBNull.Value)
                {
                    bool isDateFormat = false;

                    if (e.Cell.Value.ToString().Length == 8)
                    {
                        DateTime tmpDate;

                        if (DateTime.TryParseExact(e.Cell.Value.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out tmpDate))
                        {
                            isDateFormat = true;
                        }
                    }

                    if (!isDateFormat)
                    {
                        TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                        emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                        this.Name,											// �A�Z���u��ID
                                        "���i�J�n���͓��t8��(��:20080101)�œ��͂��Ă�������", // �\�����郁�b�Z�[�W
                                        -1,													// �X�e�[�^�X�l
                                        MessageBoxButtons.OK);								// �\������{�^��

                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        if (e.Cell.Column.Key == "PriceStartDate1")
                        {
                            if (this._tmpPriceStartDate1 == string.Empty)
                            {
                                e.Cell.Value = DBNull.Value;
                            }
                            else
                            {
                                e.Cell.Value = Convert.ToInt32(this._tmpPriceStartDate1);
                            }
                        }
                        else if (e.Cell.Column.Key == "PriceStartDate2")
                        {
                            if (this._tmpPriceStartDate2 == string.Empty)
                            {
                                e.Cell.Value = DBNull.Value;
                            }
                            else
                            {
                                e.Cell.Value = Convert.ToInt32(this._tmpPriceStartDate2);
                            }
                        }
                        else if (e.Cell.Column.Key == "PriceStartDate3")
                        {
                            if (this._tmpPriceStartDate3 == string.Empty)
                            {
                                e.Cell.Value = DBNull.Value;
                            }
                            else
                            {
                                e.Cell.Value = Convert.ToInt32(this._tmpPriceStartDate3);
                            }
                        }
                        // --- ADD 2010/08/31 ---------->>>>>
                        else if (e.Cell.Column.Key == "PriceStartDate4")
                        {
                            if (this._tmpPriceStartDate4 == string.Empty)
                            {
                                e.Cell.Value = DBNull.Value;
                            }
                            else
                            {
                                e.Cell.Value = Convert.ToInt32(this._tmpPriceStartDate4);
                            }
                        }
                        else if (e.Cell.Column.Key == "PriceStartDate5")
                        {
                            if (this._tmpPriceStartDate5 == string.Empty)
                            {
                                e.Cell.Value = DBNull.Value;
                            }
                            else
                            {
                                e.Cell.Value = Convert.ToInt32(this._tmpPriceStartDate5);
                            }
                        }
                        // --- ADD 2010/08/31 ----------<<<<<

                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                    }
                }
            }

            // ���l���ڃ`�F�b�N
            if (e.Cell.Column.Key == "ListPrice1"
                || e.Cell.Column.Key == "StockRate1"
                || e.Cell.Column.Key == "SalesUnitCost1"
                || e.Cell.Column.Key == "ListPrice2"
                || e.Cell.Column.Key == "StockRate2"
                || e.Cell.Column.Key == "SalesUnitCost2"
                || e.Cell.Column.Key == "ListPrice3"
                || e.Cell.Column.Key == "StockRate3"
                || e.Cell.Column.Key == "SalesUnitCost3"
                // --- ADD 2010/08/31 ---------->>>>>
                || e.Cell.Column.Key == "ListPrice4"
                || e.Cell.Column.Key == "StockRate4"
                || e.Cell.Column.Key == "SalesUnitCost4"
                || e.Cell.Column.Key == "ListPrice5"
                || e.Cell.Column.Key == "StockRate5"
                || e.Cell.Column.Key == "SalesUnitCost5"
                // --- ADD 2010/08/31 ----------<<<<<
                || e.Cell.Column.Key == "PriceFl"
                || e.Cell.Column.Key == "UpRate"
                || e.Cell.Column.Key == "SalesOrderUnit"
                || e.Cell.Column.Key == "MinimumStockCnt"
                || e.Cell.Column.Key == "MaximumStockCnt"
                || e.Cell.Column.Key == "SupplierStock"
                || e.Cell.Column.Key == "ArrivalCnt"
                || e.Cell.Column.Key == "ShipmentCnt"
                || e.Cell.Column.Key == "AcpOdrCount"
                || e.Cell.Column.Key == "MovingSupliStock"
                )
            {
                // ���͂������ꍇ�A0��ݒ�
                if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                {
                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                    e.Cell.Value = 0;
                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                }
            }

            // �֘A���ڃ`�F�b�N(�Œ�݌ɐ� <= �ō��݌ɐ��A�������b�g<=�ō��݌ɐ�)
            if (e.Cell.Column.Key == "SalesOrderUnit"
                || e.Cell.Column.Key == "MinimumStockCnt"
                || e.Cell.Column.Key == "MaximumStockCnt")
            {
                if (e.Cell.Column.Key != "SalesOrderUnit"
                    &&
                    ((double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.MinimumStockCntColumn.ColumnName].Value
                    > (double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.MaximumStockCntColumn.ColumnName].Value))
                {
                    TMsgDisp.Show(this, 									// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                        this.Name,											// �A�Z���u��ID
                        "�Œ�݌ɐ�<=�ō��݌ɐ��ƂȂ�悤�ɓ��͂��Ă�������", // �\�����郁�b�Z�[�W
                        -1,													// �X�e�[�^�X�l
                        MessageBoxButtons.OK);								// �\������{�^��

                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                    if (e.Cell.Column.Key == "MinimumStockCnt")
                    {
                        e.Cell.Value = this._tmpMinimumStockCnt;
                    }
                    else if (e.Cell.Column.Key == "MaximumStockCnt")
                    {
                        e.Cell.Value = this._tmpMaximumStockCnt;
                    }
                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                }
                else if (e.Cell.Column.Key != "MinimumStockCnt"
                    &&
                    ((int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.SalesOrderUnitColumn.ColumnName].Value
                    > (double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.MaximumStockCntColumn.ColumnName].Value))
                {
                    TMsgDisp.Show(this, 									// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                        this.Name,											// �A�Z���u��ID
                        "�������b�g<=�ō��݌ɐ��ƂȂ�悤�ɓ��͂��Ă�������", // �\�����郁�b�Z�[�W
                        -1,													// �X�e�[�^�X�l
                        MessageBoxButtons.OK);								// �\������{�^��

                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                    if (e.Cell.Column.Key == "SalesOrderUnit")
                    {
                        e.Cell.Value = this._tmpSalesOrderUnit;
                    }
                    else if (e.Cell.Column.Key == "MaximumStockCnt")
                    {
                        e.Cell.Value = this._tmpMaximumStockCnt;
                    }
                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                }
            }

            // --- DEL 2009/02/04 -------------------------------->>>>>
            //// ���i���ڈꊇ�ύX����
            //if (this._beforeSearchExtractInfo != null
            //    &&
            //    (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock
            //    || this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods)
            //    )
            //{
            //    // ���i�̃J�����̂�
            //    if (e.Cell.Column.Index <= this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index)
            //    {
            //        // �݌ɍ폜���͏���
            //        if (e.Cell.Column.Key != this._goodsStockDataTable.StockDeleteDateColumn.ColumnName)
            //        {
            //            string goodsNo = this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            //            int goodsMakerCd = (int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;

            //            // �Z���l���X�V���ꂽ�ꍇ�A�����i�̓���̏����㏑������
            //            foreach (UltraGridRow ultraGr in this.uGrid_Details.Rows)
            //            {
            //                if (ultraGr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
            //                    && (int)ultraGr.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd)
            //                {
            //                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
            //                    ultraGr.Cells[e.Cell.Column.Index].Value = e.Cell.Value;
            //                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            //                }
            //            }
            //        }
            //    }
            //}
            // --- DEL 2009/02/04 --------------------------------<<<<<

            // ���݌Ɍv�Z����
            if (e.Cell.Column.Key == this._goodsStockDataTable.SupplierStockColumn.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.ArrivalCntColumn.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.ShipmentCntColumn.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.AcpOdrCountColumn.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.MovingSupliStockColumn.ColumnName)
            {
                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.NowStockCntColumn.ColumnName].Value
                = ConvertToDoubleFromGridValue(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.SupplierStockColumn.ColumnName].Value)
                + ConvertToDoubleFromGridValue(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.ArrivalCntColumn.ColumnName].Value)
                - ConvertToDoubleFromGridValue(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.ShipmentCntColumn.ColumnName].Value)
                - ConvertToDoubleFromGridValue(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.AcpOdrCountColumn.ColumnName].Value)
                - ConvertToDoubleFromGridValue(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.MovingSupliStockColumn.ColumnName].Value);
            }

            // --- ADD 2009/03/05 -------------------------------->>>>>
            // �I���]���P���v�Z����
            // ���i�J�n���A���i�A�I���]����
            if (e.Cell.Column.Key == this._goodsStockDataTable.PriceStartDate1Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.ListPrice1Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.PriceStartDate2Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.ListPrice2Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.PriceStartDate3Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.ListPrice3Column.ColumnName
                // --- ADD 2010/08/11 ---------->>>>>
                || e.Cell.Column.Key == this._goodsStockDataTable.PriceStartDate4Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.ListPrice4Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.PriceStartDate5Column.ColumnName
                || e.Cell.Column.Key == this._goodsStockDataTable.ListPrice5Column.ColumnName
                // --- ADD 2010/08/11 ----------<<<<<
                || e.Cell.Column.Key == this._goodsStockDataTable.StockUnitPriceRateColumn.ColumnName
                )
            {
                // �I���]���P����0�łȂ��ꍇ�͌v�Z���s��Ȃ�
                if ((double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.OriginalStockUnitPriceFlColumn.ColumnName].Value == 0)
                {
                    Int32 now = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
                    double listPrice = 0;

                    SortedList<Int32, double> sortedList = new SortedList<Int32, double>();

                    if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate1Column.ColumnName].Value != null
                        && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate1Column.ColumnName].Value != DBNull.Value)
                    {
                        sortedList.Add((Int32)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate1Column.ColumnName].Value,
                            (double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.ListPrice1Column.ColumnName].Value);
                    }

                    if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Value != null
                        && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Value != DBNull.Value)
                    {
                        sortedList.Add((Int32)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate2Column.ColumnName].Value,
                            (double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.ListPrice2Column.ColumnName].Value);
                    }

                    if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate3Column.ColumnName].Value != null
                        && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate3Column.ColumnName].Value != DBNull.Value)
                    {
                        sortedList.Add((Int32)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate3Column.ColumnName].Value,
                            (double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.ListPrice3Column.ColumnName].Value);
                    }

                    // --- ADD 2010/08/11 ---------->>>>>
                    if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate4Column.ColumnName].Value != null
                        && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate4Column.ColumnName].Value != DBNull.Value)
                    {
                        sortedList.Add((Int32)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate4Column.ColumnName].Value,
                            (double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.ListPrice4Column.ColumnName].Value);
                    }

                    if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate5Column.ColumnName].Value != null
                        && this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate5Column.ColumnName].Value != DBNull.Value)
                    {
                        sortedList.Add((Int32)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.PriceStartDate5Column.ColumnName].Value,
                            (double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.ListPrice5Column.ColumnName].Value);
                    }

                    // --- ADD 2010/08/11 ----------<<<<<

                    for (int i = 0; i < sortedList.Count; i++)
                    {
                        if (sortedList.Keys[i] <= now)
                        {
                            listPrice = sortedList.Values[i];
                        }
                    }

                    double StockUnitPriceFlColumn = listPrice * ((double)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.StockUnitPriceRateColumn.ColumnName].Value) / 100;

                    // �����_3���ȉ��ɂ͂Ȃ肦�Ȃ��̂ŁA�[�������K�v�Ȃ�
                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._goodsStockDataTable.StockUnitPriceFlColumn.ColumnName].Value = StockUnitPriceFlColumn;
                }
            }
            // --- ADD 2009/03/05 --------------------------------<<<<<
        }

        /// <summary>
        /// uGrid_Details_KeyPress�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // �ҏW��
            if (cell.IsInEditMode)
            {
                // UI���ʐݒ��Ǎ��݁A�`���`�F�b�N
                if (this.uiSetControl2.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
                {
                    e.Handled = true;
                    return;
                }

                // --- ADD 2009/04/06 -------------------------------->>>>>
                // �I�Ԃ�8�o�C�g�܂�
                if (cell.Column.Key == "WarehouseShelfNo"
                    || cell.Column.Key == "DuplicationShelfNo1"
                    || cell.Column.Key == "DuplicationShelfNo2")
                {
                    if (!Char.IsControl(e.KeyChar))
                    {
                        string prevStr = cell.Text;
                        string resultStr = prevStr.Substring(0, cell.SelStart) // �I��O�̕���
                                         + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                         + prevStr.Substring(cell.SelStart + cell.SelLength, prevStr.Length - (cell.SelStart + cell.SelLength)); // �I����̕���

                        Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                        int byteLength = sjis.GetByteCount(resultStr);

                        // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                        if (byteLength > 8)
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }
                // --- ADD 2009/04/06 --------------------------------<<<<<
                // ���l���ڂ̓��͐���
                else if (cell.Column.Key == "PriceFl")
                {
                    // 9������
                    if (!this.CheckKeyPressNumber(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else if (cell.Column.Key == "ListPrice1"
                || cell.Column.Key == "ListPrice2"
                    || cell.Column.Key == "ListPrice3"
               || cell.Column.Key == "ListPrice4" // ADD 2010/08/31
               || cell.Column.Key == "ListPrice5" // ADD 2010/08/31
                )
                {
                    // 7������
                    if (!this.CheckKeyPressNumber(7, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else if (cell.Column.Key == "SalesOrderUnit")
                {
                    // 6������
                    if (!this.CheckKeyPressNumber(6, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else if (cell.Column.Key == "SalesUnitCost1"
                || cell.Column.Key == "SalesUnitCost2"
                || cell.Column.Key == "SalesUnitCost3"
                || cell.Column.Key == "SalesUnitCost4" // ADD 2010/08/31
                || cell.Column.Key == "SalesUnitCost5" // ADD 2010/08/31
                || cell.Column.Key == "StockUnitPriceFl") // ADD 2009/03/05
                {
                    // 7��+�����_2��
                    if (!this.CheckKeyPressNumber(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else if
                    (cell.Column.Key == "MinimumStockCnt"
                || cell.Column.Key == "MaximumStockCnt"
                || cell.Column.Key == "SupplierStock"
                || cell.Column.Key == "ArrivalCnt"
                || cell.Column.Key == "ShipmentCnt"
                || cell.Column.Key == "AcpOdrCount"
                || cell.Column.Key == "MovingSupliStock")
                {
                    // 6��+�����_2��
                    //if (!this.CheckKeyPressNumber(9, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false)) // DEL 2009/02/03
                    if (!this.CheckKeyPressNumber(9, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true)) // ADD 2009/02/03
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else if
               (cell.Column.Key == "StockRate1"
               || cell.Column.Key == "StockRate2"
               || cell.Column.Key == "StockRate3"
               || cell.Column.Key == "StockRate4"  // ADD 2010/08/31
               || cell.Column.Key == "StockRate5" // ADD 2010/08/31
               || cell.Column.Key == "UpRate"
               || cell.Column.Key == "StockUnitPriceRate" // ADD 2009/03/05
           )
                {
                    // ������(3��+�����_2��)
                    if (!this.CheckKeyPressNumber(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }

            }
        }
        #endregion

        #region �� �{�^���N���b�N�C�x���g
        /// <summary>
        /// ���i�폜�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowDelete_Click(object sender, EventArgs e)
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// Active�sindex�擾
            //int selectRowIndex = this.GetSelectRowIndex();

            //if (selectRowIndex == -1)
            //{
            //    // Active�s��������Ώ������Ȃ�
            //    return;
            //}

            //// �폜����
            //this.GoodsDeleteMain(selectRowIndex);
            // --- DEL 2009/02/23 --------------------------------<<<<<

            // �폜����
            this.GoodsDeleteMain(); // ADD 2009/02/23
        }

        /// <summary>
        /// �݌ɍ폜�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowStockDelete_Click(object sender, EventArgs e)
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// Active�sindex�擾
            //int selectRowIndex = this.GetSelectRowIndex();

            //if (selectRowIndex == -1)
            //{
            //    // Active�s��������Ώ������Ȃ�
            //    return;
            //}

            //// �폜����
            //this.StockDeleteMain(selectRowIndex);
            // --- DEL 2009/02/23 --------------------------------<<<<<

            // �폜����
            this.StockDeleteMain(); // ADD 2009/02/23
        }

        /// <summary>
        /// �����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowRevive_Click(object sender, EventArgs e)
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// Active�sindex�擾
            //int selectRowIndex = this.GetSelectRowIndex();

            //if (selectRowIndex == -1)
            //{
            //    // Active�s��������Ώ������Ȃ�
            //    return;
            //}
            
            //// ��������
            //this.GoodsReviveMain(selectRowIndex);
            // --- DEL 2009/02/23 --------------------------------<<<<<

            // ��������
            this.GoodsReviveMain(); // ADD 2009/02/23
        }

        /// <summary>
        /// �݌ɕ����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowStockRevive_Click(object sender, EventArgs e)
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// Active�sindex�擾
            //int selectRowIndex = this.GetSelectRowIndex();

            //if (selectRowIndex == -1)
            //{
            //    // Active�s��������Ώ������Ȃ�
            //    return;
            //}

            //// ��������
            //this.StockReviveMain(selectRowIndex);
            // --- DEL 2009/02/23 --------------------------------<<<<<

            // ��������
            this.StockReviveMain(); // ADD 2009/02/23
        }

        /// <summary>
        /// ���i�ǉ��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowAdd_Click(object sender, EventArgs e)
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// Active�sindex�擾
            //int selectRowIndex = this.GetSelectRowIndex();

            //this.AddNewRowMain(selectRowIndex);

            //// �w�i�F�ݒ�
            //this.SetGridColorAll();
            // --- DEL 2009/02/23 --------------------------------<<<<<

            // ���i(�݌�)�ǉ�
            this.AddNewRowMain(); // ADD 2009/02/23
        }

        /// <summary>
        /// ���i�\���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowDispPrice_Click(object sender, EventArgs e)
        {
            // ���i�\������
            this.DispPriceMain();
        }

        /// <summary>
        /// ���̕\���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowDispNames_Click(object sender, EventArgs e)
        {
            // ���̕\������
            this.DispNameMain();
        }

        /// <summary>
        /// �K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_RowExcuteGuide_Click(object sender, EventArgs e)
        {
            // �K�C�h����
            this.ExecuteGuideMain();
        }

        #endregion

        #region �� �t�H�[�J�X�J�ڊ֘A�C�x���g
        /// <summary>
        /// uGrid_Details_KeyDown�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if ((uGrid.Rows.Count == 0) ||
                ((uGrid.ActiveCell == null) && (uGrid.ActiveRow == null)))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            this.SetFocus("tEdit_GoodsNo");
                            break;
                        }
                    case Keys.Down:
                    case Keys.Right:
                        {
                            this.SetFocus("tComboEditor_DisplayDiv");
                            break;
                        }
                    case Keys.Left:
                        {
                            //this.SetFocus("uButton_EmployeeCdGuide");  // DEL 2009/03/06
                            this.SetFocus("Before_Grid");  // ADD 2009/03/06
                            break;
                        }
                }
                return;
            }

            int rowIndex;
            int columnIndex;
            string columnKey;

            if (uGrid.ActiveCell != null)
            {
                // �A�N�e�B�u�Z��
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
                columnKey = uGrid.ActiveCell.Column.Key;
            }
            else
            {
                // �A�N�e�B�u�s
                rowIndex = uGrid.ActiveRow.Index;
                columnIndex = 0;
                columnKey = uGrid.ActiveRow.Cells[columnIndex].Column.Key;
            }

            string nextFocusColumn;
            bool doActivate = false;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            this.SetFocus("tEdit_GoodsNo");
                        }
                        else
                        {
                            if (uGrid.ActiveCell != null)
                            {
                                // �Z���A�N�e�B�u��DDL
                                if (uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                                {
                                    e.Handled = true;
                                    if (uGrid.ActiveCell.ValueListResolved.SelectedItemIndex != 0)
                                    {
                                        // �I�𒆂�ValueList���ŏ��łȂ���΃L�[�J�ڂ��Ȃ�
                                        uGrid.ActiveCell.ValueListResolved.SelectedItemIndex = uGrid.ActiveCell.ValueListResolved.SelectedItemIndex - 1;
                                        break;
                                    }
                                    else
                                    {
                                        for (int i = rowIndex - 1; i >= 0; i--)
                                        {
                                            if (uGrid.Rows[i].Cells[columnIndex].Activation == Activation.AllowEdit)
                                            {
                                                uGrid.Rows[i].Cells[columnIndex].Activate();
                                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                doActivate = true;
                                                break;
                                            }
                                        }

                                        if (!doActivate)
                                        {
                                            this.SetFocus("tEdit_GoodsNo");
                                        }

                                        break;
                                    }
                                }
                            }

                            // �L�[�l�̍s�̓Z������Activation���قȂ�P�[�X������
                            // --- DEL 2009/02/23 -------------------------------->>>>>
                            //for (int i = rowIndex; i >= 1; i--)
                            //{
                            //    if (uGrid.Rows[i - 1].Cells[columnIndex].Activation == Activation.AllowEdit)
                            //    {
                            //        uGrid.Rows[i - 1].Cells[columnIndex].Activate();
                            //        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            //        doActivate = true;
                            //        break;
                            //    }
                            //}

                            //if (!doActivate)
                            //{
                            //    this.SetFocus("tEdit_GoodsNo");
                            //}
                            // --- DEL 2009/02/23 --------------------------------<<<<<
                            // --- ADD 2009/02/23 -------------------------------->>>>>
                            if (uGrid.ActiveCell != null)
                            {
                                e.Handled = true;

                                for (int i = rowIndex; i >= 1; i--)
                                {
                                    // �\���s�T��
                                    if (!uGrid.Rows[i - 1].IsFilteredOut)
                                    {
                                        if (uGrid.Rows[i - 1].Cells[columnIndex].Activation == Activation.AllowEdit)
                                        {
                                            uGrid.Rows[i - 1].Cells[columnIndex].Activate();
                                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                        else
                                        {

                                            // �s�A�N�e�B�u
                                            uGrid.Rows[i - 1].Activate();
                                            uGrid.Rows[i - 1].Selected = true;
                                            doActivate = true;
                                            break;

                                        }
                                    }
                                }
                                
                                if (!doActivate)
                                {
                                    this.SetFocus("tEdit_GoodsNo");
                                }
                            }
                            // --- ADD 2009/02/23 -------------------------------->>>>>
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (rowIndex == uGrid.Rows.Count - 1)
                        {
                            e.Handled = true;
                            this.SetFocus("tComboEditor_DisplayDiv");
                        }
                        else
                        {
                            if (uGrid.ActiveCell != null)
                            {
                                if (uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                                {
                                    e.Handled = true;
                                    if (uGrid.ActiveCell.ValueListResolved.SelectedItemIndex != uGrid.ActiveCell.ValueListResolved.ItemCount - 1)
                                    {
                                        // �I�𒆂�ValueList���ő�łȂ���΃L�[�J�ڂ��Ȃ�
                                        uGrid.ActiveCell.ValueListResolved.SelectedItemIndex = uGrid.ActiveCell.ValueListResolved.SelectedItemIndex + 1;
                                        break;
                                    }
                                    else
                                    {
                                        for (int i = rowIndex + 1; i < uGrid.Rows.Count; i++)
                                        {
                                            if (uGrid.Rows[i].Cells[columnIndex].Activation == Activation.AllowEdit)
                                            {
                                                uGrid.Rows[i].Cells[columnIndex].Activate();
                                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                doActivate = true;
                                                break;
                                            }
                                        }

                                        if (!doActivate)
                                        {
                                            this.SetFocus("tComboEditor_DisplayDiv");
                                        }

                                        break;
                                    }
                                }
                            }

                            // --- DEL 2009/02/23 -------------------------------->>>>>
                            //// �L�[�l�̍s�̓Z������Activation���قȂ�P�[�X������
                            //for (int i = rowIndex; i < uGrid.Rows.Count - 1; i++)
                            //{
                            //    if (uGrid.Rows[i + 1].Cells[columnIndex].Activation == Activation.AllowEdit)
                            //    {
                            //        uGrid.Rows[i + 1].Cells[columnIndex].Activate();
                            //        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            //        doActivate = true;
                            //        break;
                            //    }
                            //}

                            //if (!doActivate)
                            //{
                            //    this.SetFocus("tComboEditor_DisplayDiv");
                            //}
                            // --- DEL 2009/02/23 --------------------------------<<<<<
                            // --- ADD 2009/02/23 -------------------------------->>>>>
                            if (uGrid.ActiveCell != null)
                            {
                                e.Handled = true;

                                for (int i = rowIndex; i < uGrid.Rows.Count - 1; i++)
                                {
                                    // �\���s�T��
                                    if (!uGrid.Rows[i + 1].IsFilteredOut)
                                    {
                                        if (uGrid.Rows[i + 1].Cells[columnIndex].Activation == Activation.AllowEdit)
                                        {
                                            uGrid.Rows[i + 1].Cells[columnIndex].Activate();
                                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                        else
                                        {

                                            // �s�A�N�e�B�u
                                            uGrid.Rows[i + 1].Activate();
                                            uGrid.Rows[i + 1].Selected = true;
                                            doActivate = true;
                                            break;

                                        }
                                    }
                                }

                                if (!doActivate)
                                {
                                    this.SetFocus("tComboEditor_DisplayDiv");
                                }
                            }
                            // --- ADD 2009/02/23 -------------------------------->>>>>
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (uGrid.ActiveCell == null)
                        {
                            // �s�A�N�e�B�u
                            int activationColIndex;
                            int activationRowIndex;

                            // ����Shift+Tab�Ɠ���
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                //this.SetFocus("uButton_EmployeeCdGuide"); // DEL 2009/03/06
                                this.SetFocus("Before_Grid"); // ADD 2009/03/06
                            }

                            break;
                        }

                        if (
                            (uGrid.ActiveCell.IsInEditMode)
                            &&
                            ((uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
                            &&
                            (uGrid.ActiveCell.SelStart != 0)
                            )
                        {
                            break;
                        }
                        else
                        {
                            e.Handled = true;

                            int activationColIndex;
                            int activationRowIndex;

                            // ����Shift+Tab�Ɠ���
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                //this.SetFocus("uButton_EmployeeCdGuide"); // DEL 2009/03/06
                                this.SetFocus("Before_Grid"); // ADD 2009/03/06
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (uGrid.ActiveCell == null)
                        {
                            // �s�A�N�e�B�u
                            int activationColIndex;
                            int activationRowIndex;

                            // �E��Tab�Ɠ���
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, false, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.SetFocus("tComboEditor_DisplayDiv");
                            }
                            break;
                        }

                        if (
                            (uGrid.ActiveCell.IsInEditMode)
                            &&
                            ((uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
                            &&
                            (uGrid.ActiveCell.SelStart < uGrid.ActiveCell.Text.Length)
                            )
                        {
                            break;
                        }
                        else
                        {

                            e.Handled = true;

                            int activationColIndex;
                            int activationRowIndex;

                            // �E��Tab�Ɠ���
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, false, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.SetFocus("tComboEditor_DisplayDiv");
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI09201UB_Leave(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveCell = null;
            this.uGrid_Details.ActiveRow = null;
            this.uGrid_Details.Selected.Rows.Clear();

            // --- ADD 2009/03/02 -------------------------------->>>>>
            // �{�^����s�ɂ���
            this.uButton_RowGoodsDelete.Enabled = false;
            this.uButton_RowGoodsRevive.Enabled = false;
            this.uButton_RowStockDelete.Enabled = false;
            this.uButton_RowStockRevive.Enabled = false;
            //this.uButton_RowExcuteGuide.Enabled = false; // DEL 2010/08/11

            if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                this.uButton_RowAdd.Enabled = false;
            }
            // --- ADD 2009/03/02 --------------------------------<<<<<

            this.SetGridColorAll(); // ADD 2009/02/23
        }
        #endregion

        #region �� �w�i�F�ݒ�֘A�C�x���g
        // --- ADD 2009/03/05 -------------------------------->>>>>
        /// <summary>
        /// BeforeCellDeactivate�C�x���g
        /// </summary>
        private void uGrid_Details_BeforeCellDeactivate()
        {
            this.uGrid_Details_BeforeCellDeactivate(new Object(), new CancelEventArgs());
        }
        // --- ADD 2009/03/05 --------------------------------<<<<<

        /// <summary>
        /// BeforeCellDeactivate�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // �w�i�F�ݒ�
                this.SetGridColorRow(this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index]);
            }

            // --- ADD 2009/02/04 -------------------------------->>>>>
            // �����i�̍��ڍ폜�������ǉ����ꂽ���߁A��������CellUpdate����ړ��B
            // ���i���ڈꊇ�ύX����
            if (this._beforeSearchExtractInfo != null
                &&
                (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock
                || this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods)
                )
            {
                // ���i�̃J�����̂�
                if (this.uGrid_Details.ActiveCell.Column.Index <= this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsStockDataTable.UpRateColumn.ColumnName].Index)
                {
                    // �݌ɍ폜���͏���
                    if (this.uGrid_Details.ActiveCell.Column.Key != this._goodsStockDataTable.StockDeleteDateColumn.ColumnName)
                    {
                        string goodsNo = this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString();
                        int goodsMakerCd = (int)this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value;

                        // �Z���l���X�V���ꂽ�ꍇ�A�����i�̓���̏����㏑������
                        foreach (UltraGridRow ultraGr in this.uGrid_Details.Rows)
                        {
                            if (ultraGr.Cells[this._goodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == goodsNo
                                && (int)ultraGr.Cells[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].Value == goodsMakerCd)
                            {
                                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                                ultraGr.Cells[this.uGrid_Details.ActiveCell.Column.Index].Value = this.uGrid_Details.ActiveCell.Value;
                                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;

                                this.SetGridColorRow(ultraGr); // ADD 2009/02/04
                            }
                        }
                    }
                }
            }
            // --- ADD 2009/02/04 --------------------------------<<<<<
        }

        /// <summary>
        /// ��A�N�e�B�u�O�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�s�I�����̔w�i�F��߂����߂ɍsindex��ۑ�</br>
        /// </remarks>
        private void uGrid_Details_BeforeRowDeactivate(object sender, CancelEventArgs e)
        {
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //if (this.uGrid_Details.ActiveRow != null)
            //{
            //    // �O�A�N�e�B�u�s�C���f�b�N�X�̕ۑ�
            //    this._tmpActiveRowIndex = this.uGrid_Details.ActiveRow.Index;
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- DEL 2009/03/05 -------------------------------->>>>>
            // --- ADD 2009/02/23 -------------------------------->>>>>
            //// �����s�I�����\�ɂ������߁A�I���s���c���悤�ɏC��
            //foreach (UltraGridRow ultraGridRow in this.uGrid_Details.Selected.Rows)
            //{
            //    this._beforeSelectRowIndexList.Add(ultraGridRow.Index);
            //}
            // --- ADD 2009/02/23 --------------------------------<<<<<
            // --- DEL 2009/03/05 --------------------------------<<<<<
        }

        /// <summary>
        /// �I���s�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>������̔w�i�F��ݒ�</br>
        /// </remarks>
        private void uGrid_Details_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            this._goodsStockAcs.GoodsStockDataTable.AcceptChanges(); // ADD 2009/03/10

            // --- DEL 2009/02/23 -------------------------------->>>>>
            // �O�A�N�e�B�u�s�̐ݒ�
            //if (this._tmpActiveRowIndex != -1
            //    && this._tmpActiveRowIndex <= this.uGrid_Details.Rows.Count)
            //{
            //    this.SetGridColorRow(this.uGrid_Details.Rows[this._tmpActiveRowIndex]);
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/02/23 -------------------------------->>>>>
            if (this._beforeSelectRowIndexList.Count != 0)
            {
                foreach(int rowIndex in this._beforeSelectRowIndexList)
                {
                    if (rowIndex <= this.uGrid_Details.Rows.Count - 1) // ADD 2009/03/05
                    {
                        this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]);
                    }
                }

                this._beforeSelectRowIndexList.Clear();
            }
            // --- ADD 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/03/05 -------------------------------->>>>>
            // BeforeRowDeactivate����ړ�
            foreach (UltraGridRow ultraGridRow in this.uGrid_Details.Selected.Rows)
            {
                this._beforeSelectRowIndexList.Add(ultraGridRow.Index);
            }
            // --- ADD 2009/03/05 --------------------------------<<<<<
            // --- DEL 2009/02/23 -------------------------------->>>>>
            //// �A�N�e�B�u�s�̐ݒ�
            //if (this.uGrid_Details.ActiveRow != null)
            //{
            //    this.SetGridColorRow(this.uGrid_Details.ActiveRow);
            //}
            // --- DEL 2009/02/23 --------------------------------<<<<<
            // --- ADD 2009/02/23 -------------------------------->>>>>
            // �I���s�̔w�i�F�ݒ�
            if (this.uGrid_Details.Selected.Rows.Count != 0)
            {
                foreach (UltraGridRow ultraGr in this.uGrid_Details.Selected.Rows)
                {
                    this.SetGridColorRow(ultraGr);
                }
            }
            // --- ADD 2009/02/23 --------------------------------<<<<<


            if (this.uGrid_Details.ActiveCell != null)
            {
                this.SetGridColorRow(this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index]);
            }

            // --- ADD 2009/02/23 -------------------------------->>>>>
            this.SetButtonEnable();
            // --- ADD 2009/02/23 --------------------------------<<<<<
        }
        #endregion

        #region �� �{�^������֘A�C�x���g
        // --- DEL 2009/02/23 -------------------------------->>>>>
        ///// <summary>
        ///// uGrid_Details_BeforeRowActivate
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void uGrid_Details_BeforeRowActivate(object sender, RowEventArgs e)
        //{
        //    // �{�^������
        //    this.SetButtonEnableByRow(e.Row.Index, string.Empty);
        //}
        // --- DEL 2009/02/23 --------------------------------<<<<<

        /// <summary>
        /// uGrid_Details_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            // --- DEL 2009/03/02 -------------------------------->>>>>
            //// �{�^����s�ɂ���
            //this.uButton_RowGoodsDelete.Enabled = false;
            //this.uButton_RowGoodsRevive.Enabled = false;
            //this.uButton_RowStockDelete.Enabled = false;
            //this.uButton_RowStockRevive.Enabled = false;
            //this.uButton_RowExcuteGuide.Enabled = false;

            //// --- ADD 2009/02/04 -------------------------------->>>>>
            //if (this._beforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            //{
            //    this.uButton_RowAdd.Enabled = false;
            //}
            //// --- ADD 2009/02/04 --------------------------------<<<<<
            // --- DEL 2009/03/02 --------------------------------<<<<<
        }
        #endregion

        #region �� �t�B���^�ύX�C�x���g
        // --- ADD 2009/02/23 -------------------------------->>>>>
        /// <summary>
        /// uGrid_Details_AfterRowFilterChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_AfterRowFilterChanged(object sender, AfterRowFilterChangedEventArgs e)
        {
            this.SetActivationStatByFilteredOut();

            // �I���s�̏�Ԃ��ς��̂Ń{�^����������
            this.SetButtonEnable();

            // �I���s�̏�Ԃ��ς��̂Ŕw�i�F���t���b�V��
            this.SetGridColorAll();
        }

        // --- ADD 2009/02/23 --------------------------------<<<<<
        #endregion

        //---ADD 2010/08/09---------->>>>>
        /// <summary>
        /// BeforeCellUpdate�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            switch(e.Cell.Column.Key) 
            {
                case "GoodsKindCode": // ���i����
                case "TaxationDivCd": // �ېŋ敪
                case "OpenPriceDiv1": // �I�[�v�����i�敪1
                case "OpenPriceDiv2": // �I�[�v�����i�敪2
                case "OpenPriceDiv3": // �I�[�v�����i�敪3
                case "OpenPriceDiv4": // �I�[�v�����i�敪4
                case "OpenPriceDiv5": // �I�[�v�����i�敪5
                case "StockDiv": // �݌ɋ敪
                    {
                        if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
                        {
                            this._preComboEditorValue = e.Cell.Value;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �L�[�����C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void PMZAI09201UB_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) 
            {
                case Keys.F3:
                    {
                        uButton_RowDelete_Click(sender, e);
                        break;
                    }
                case Keys.F4:
                    {
                        uButton_RowRevive_Click(sender, e);
                        break;
                    }
                case Keys.F6:
                    {
                        uButton_RowStockDelete_Click(sender, e);
                        break;
                    }
                case Keys.F8:
                    {
                        uButton_RowStockRevive_Click(sender, e);
                        break;
                    }
                case Keys.F11:
                    {
                        uButton_RowAdd_Click(sender, e);
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// uGrid_Details_CellDataError
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            e.RaiseErrorEvent = false;
            e.StayInEditMode = false;
        }
        //---ADD 2010/08/09----------<<<<<

        #endregion
    }       
}
