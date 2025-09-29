//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�Ǘ��}�X�^(�ꊇ����)
// �v���O�����T�v   : ���q�Ǘ��}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/09/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2009/10/10  �C�����e : ��Q��Redmine#537�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2009/10/21  �C�����e : MANTIS�F0014457 ��Q��Redmine#784�̏C��
//                                  MANTIS�F0014458 ��Q��Redmine#784�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2009/10/26  �C�����e : ��Q��Redmine#831,879,878�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �C �� ��  2010/06/08  �C�����e : �Ǘ��ԍ��I�����̕s��C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900269-00 �쐬�S�� : FSI���� ����
// �C �� ��  2013/03/22  �C�����e : SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �e�c ���V
// �C �� ��  2013/05/14  �C�����e : �S�̏����\���ݒ�̌����\���敪�i�N���j�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11270098-00 �쐬�S�� : ���R
// �� �� ��  2016/12/13  �C�����e : Redmine#48934 PMNS�i���o�[�v���[�g�p�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770175-00 �쐬�S�� : ���X�ؘj
// �C �� ��  2021/11/02  �C�����e : OUT OF MEMORY�Ή�(4GB�Ή�) ���q�Ǘ��}�X�^�ێ�
//                                  ���o�Ώی������ő匏��20001���܂Łi20000���܂ŉ�ʕ\���j
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Library.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���q�Ǘ��}�X�^�R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���q�Ǘ��}�X�^�̖��ו\���A���͂��s��</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009/09/07</br>
    /// <br>Update Note : ���� 2009/10/10</br>
    /// <br>            : ��Q��Redmine#537�̏C��</br>
    /// <br>Update Note : ����� 2010/06/08 ��Q���ǑΉ��i�V�����j</br>
    /// <br>            : �Ǘ��ԍ��I�����̕s��C��</br>
    /// <br>UpdateNote  : 2016/12/13 ���R</br>
    /// <br>�Ǘ��ԍ�    : 11270098-00</br>
    /// <br>            : Redmine#48934 PMNS�i���o�[�v���[�g�p�����Ή�</br>
    /// </remarks>
    public partial class PMSYA09021UB : UserControl
    {
        #region ��private�萔
        // �O���b�h��
        private const string column_No = "RowNo";
        private const string column_CarRelationGuid = "CarRelationGuid";
        private const string column_DeleteDate = "DeleteDate";
        private const string column_CustomerCode = "CustomerCode";
        private const string column_CustomerCodeGuide = "CustomerCodeGuide";
        private const string column_CarMngCode = "CarMngCode";
        private const string column_CarMngCodeGuide = "CarMngCodeGuide";
        private const string column_ModelFullName = "ModelFullName";
        private const string column_FullModel = "FullModel";
        private const string column_ModelDesignationNo = "ModelDesignationNo";
        private const string column_CategoryNo = "CategoryNo";
        private const string column_EngineModelNm = "EngineModelNm";
        private const string column_FirstEntryDate = "FirstEntryDate";
        private const string column_FrameNo = "FrameNo";
        private const string column_ColorCode = "ColorCode";
        private const string column_TrimCode = " TrimCode";
        private const string column_EngineModel = "EngineModel";
        private const string column_CarAddInfo1 = "CarAddInfo1";
        private const string column_CarAddInfo2 = "CarAddInfo2";
        private const string column_NumberPlate1Code = "NumberPlate1Code";
        private const string column_NumberPlate1CodeGuide = "NumberPlate1CodeGuide";
        private const string column_NumberPlate1Name = "NumberPlate1Name";
        private const string column_NumberPlate2 = "NumberPlate2";
        private const string column_NumberPlate3 = "NumberPlate3";
        private const string column_NumberPlate4 = "NumberPlate4";
        private const string column_Mileage = "Mileage";
        private const string column_CarInspectYear = "CarInspectYear";
        private const string column_EntryDate = "EntryDate";
        private const string column_LTimeCiMatDate = "LTimeCiMatDate";
        private const string column_InspectMaturityDate = "InspectMaturityDate";
        private const string column_CarNote = "CarNote";
        private const string column_CarNoteGuide = "CarNoteGuide";

        /// <summary>���l�K�C�h�敪�R�[�h�P</summary>
        public const int ctDIVCODE_NoteGuideDivCd = 201;

        //�J���[��`
        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color READONLY_COLOR = Color.WhiteSmoke;
        private static readonly Color ROWSTATUS_COPY_COLOR = Color.Pink;
        private static readonly Color ROWSTATUS_CUT_COLOR = Color.Gray;
        private static readonly Color REDUCTION_FONT_COLOR = Color.Green;
        private static readonly Color READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

        // �s�I�����
        private const int MODE_SELECTEDSINGLE = 1;
        private const int MODE_SELECTEDMULTI = 2;

        // ��ʏ�ԕۑ��p�t�@�C����
        private const string XML_FILE_INITIAL_DATA = "PMSYA09021U.dat";
        #endregion

        #region ��private�ϐ�
        // ��ƃR�[�h
        private string _enterpriseCode;

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin;
        // �C���[�W���X�g
        private ImageList _imageList16 = null;

        // ���q�Ǘ��}�X�^�e�[�u���A�N�Z�X�N���X
        private CarMngListInputAcs _carMngListInputAcs;
        private CarMngInputAcs _carMngInputAcs;

        // ���i�݌Ƀe�[�u��
        private CarMngInputDataSet.CarInfoDataTable _carInfoDataTable;
        private DataTable _originalCarInfoDataTable;

        private CustomerSearchRet _customerSearchRet;
        private bool _cusotmerGuideSelected;

        // ���[�U�[�K�C�h�}�X�^�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs;
        // ���l�K�C�h�}�X�^�A�N�Z�X�N���X
        private NoteGuidAcs _noteGuidAcs;

        private CustomerSearchAcs _customerSearchAcs;

        //�{�^����`
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowCopyButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowPasteButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowDeleteButton;

        // �O�I���s�C���f�b�N�X(�w�i�F�ݒ�p)
        private List<int> _beforeSelectRowIndexList = new List<int>();

        // �O���b�h�ݒ萧��N���X
        private GridStateController _gridStateController;

        // �O���b�h���ڂ̍X�V�O���ڒl
        private string _tmpCustomerCode = string.Empty;
        private string _tmpCarMngCode = string.Empty;
        private string _tmpNumberPlate1Code = string.Empty;
        #endregion

        #region ���C�x���g
        /// <summary>�t�H�[�J�X�ݒ�C�x���g</summary>
        internal event SettingFocusEventHandler SetFocus;
        /// <summary>�ҏW�{�^�������ېݒ�C�x���g</summary>
        internal event SetEditButtonEnableHandler SetEditButton;
        /// <summary>�f�[�^���͉�ʂ��N���C�x���g</summary>
        internal event StartInPutHandler StartInPut;

        private bool _canMove = true;
        private bool _chooseFlg = true;
        /// <summary>
        /// ChooseFlg
        /// </summary>
        public bool ChooseFlg
        {
            get { return _chooseFlg; }
            set { _chooseFlg = value; }
        }
        #endregion

        #region ���f���Q�[�g
        /// <summary>
        /// �t�H�[�J�X�ݒ�f���Q�[�g
        /// </summary>
        /// <param name="itemName">���ږ���</param>
        internal delegate void SettingFocusEventHandler(string itemName);

        /// <summary>
        /// �ҏW�{�^�������ې���C�x���g
        /// </summary>
        /// <param name="flag">�ې���</param>
        internal delegate void SetEditButtonEnableHandler(bool flag);

        /// <summary>
        /// �f�[�^���͉�ʂ��N���C�x���g
        /// </summary>
        /// <param name="key">�ԗ���񋤒ʃL�[</param>
        internal delegate void StartInPutHandler(object key);
        #endregion


        // --- ADD 2009/10/26 -------------------------------->>>>>
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
            }
        }
        // --- ADD 2009/10/26 --------------------------------<<<<<

        #region ���R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMSYA09021UB()
        {
            InitializeComponent();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._controlScreenSkin = new ControlScreenSkin();
            this._imageList16 = IconResourceManagement.ImageList16;

            this._carMngListInputAcs = CarMngListInputAcs.GetInstance();
            this._carMngInputAcs = CarMngInputAcs.GetInstance();
            this._carInfoDataTable = this._carMngListInputAcs.CarInfoDataTable;
            this._originalCarInfoDataTable = this._carMngListInputAcs.OriginalCarInfoDataTable;

            // �ϐ�������
            this._userGuideAcs = new UserGuideAcs();
            this._noteGuidAcs = new NoteGuidAcs();

            this._customerSearchAcs = new CustomerSearchAcs();

            this._gridStateController = new GridStateController();
        }
        #endregion

        #region ��public���\�b�h
        #region �� ����������
        /// <summary>
        /// ������(�N���A)����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������(�N���A)�������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        internal void Initialize()
        {
            // ��ʍ��ڏ�����
            InitializeScreen();

            this._carMngListInputAcs.CarInfoDataTable.Clear();
            this._carMngListInputAcs.OriginalCarInfoDataTable.Clear();

            // �{�^������L������
            this.SetButtonEnable();
        }
        #endregion

        #region �� �t�H�[�J�X�J�ڐ���
        /// <summary>
        /// �O���b�h�^�u�ړ�����
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�^�u�ړ�������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        internal void SetGridTabFocus(ref ChangeFocusEventArgs e)
        {
            // ���t�H�[�J�X��J������
            string nextFocusColumn;
            int activationColIndex = 0;
            int activationRowIndex = 0;

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
                    this.SetFocus("tNedit_CustomerCode_St");
                }

                return;
            }
            else
            {
                // �Z���A�N�e�B�u
                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                int colIndex = this.uGrid_Details.ActiveCell.Column.Index;

                // �O���b�h�E�o���p�̃R���g���[����ێ�
                e.NextCtrl = null;
                this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                this.uGrid_Details.Focus();

                // �}�X�^�`�F�b�N�����ꍇ�A�t�H�[�J�X�ړ�
                if (this._canMove)
                {
                    nextFocusColumn = string.Empty;

                    // ---- ADD 2009/10/10 ------->>>>>
                    // ����Ԍ���
                    if (this.uGrid_Details.ActiveCell.Column.Key == column_CarInspectYear
                        || this.uGrid_Details.ActiveCell.Column.Key == column_LTimeCiMatDate
                        || this.uGrid_Details.ActiveCell.Column.Key == column_InspectMaturityDate)
                    {
                        // �O��Ԍ�������͌�A����Ԍ������󔒂̏ꍇ�́A����Ԍ����֑O��Ԍ����{���Ԃŏ����\������
                        string lTimeCiMatDate = this.uGrid_Details.Rows[rowIndex].Cells["LTimeCiMatDate"].Value.ToString();
                        string inspectMaturityDate = this.uGrid_Details.Rows[rowIndex].Cells["InspectMaturityDate"].Value.ToString();
                        int carInspectYear = Convert.ToInt32(this.uGrid_Details.Rows[rowIndex].Cells["CarInspectYear"].Value.ToString());
                        if (!string.Empty.Equals(lTimeCiMatDate) && string.Empty.Equals(inspectMaturityDate)
                            && Convert.ToDateTime(lTimeCiMatDate) != DateTime.MinValue)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells["InspectMaturityDate"].Value = (object)Convert.ToDateTime(lTimeCiMatDate).AddYears(carInspectYear).ToString();
                        }
                    }

                    // ---- ADD 2009/10/10 -------<<<<<

                    // ���Ӑ�R�[�h
                    if (this.uGrid_Details.ActiveCell.Column.Key == column_CustomerCode)
                    {
                        activationRowIndex = rowIndex;

                        // ���͂����ꍇ
                        if (this.uGrid_Details.ActiveCell.Value != DBNull.Value
                            && (string)this.uGrid_Details.ActiveCell.Value != string.Empty)
                        {
                            nextFocusColumn = column_CarMngCode;
                        }
                        else
                        {
                            nextFocusColumn = column_CustomerCodeGuide;
                        }

                    }
                    // ���^�������ԍ�
                    else if (this.uGrid_Details.ActiveCell.Column.Key == column_NumberPlate1Code)
                    {
                        activationRowIndex = rowIndex;

                        // ���͂����ꍇ
                        if (this.uGrid_Details.ActiveCell.Value != DBNull.Value
                            && (string)this.uGrid_Details.ActiveCell.Value != string.Empty)
                        {
                            nextFocusColumn = column_NumberPlate2;
                        }
                        else
                        {
                            nextFocusColumn = column_NumberPlate1CodeGuide;
                        }
                    }
                    // ���q���l
                    else if (this.uGrid_Details.ActiveCell.Column.Key == column_CarNote)
                    {
                        // ���͂����ꍇ
                        if (this.uGrid_Details.ActiveCell.Value != DBNull.Value
                            && (string)this.uGrid_Details.ActiveCell.Value != string.Empty)
                        {
                            colIndex = colIndex + 1;
                            // ���Z���擾
                            nextFocusColumn = GetNextFocusColumnKey(colIndex, rowIndex, false, out activationColIndex, out activationRowIndex);
                        }
                        else
                        {
                            activationRowIndex = rowIndex;
                            nextFocusColumn = column_CarNoteGuide;
                        }
                    }
                    else
                    {
                        // ���Z���擾
                        nextFocusColumn = GetNextFocusColumnKey(colIndex, rowIndex, false, out activationColIndex, out activationRowIndex);
                    }

                    if (nextFocusColumn != string.Empty)
                    {
                        this.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.SetFocus("uCheckEditor_AutoFillToColumn");
                    }
                }
                // �t�H�[�J�X���ړ����Ȃ��B
                else
                {
                    nextFocusColumn = string.Empty;
                   

                    // ���Ӑ�R�[�h
                    if (this.uGrid_Details.ActiveCell.Column.Key == column_CustomerCode)
                    {
                        nextFocusColumn = column_CustomerCode;
                    }
                    // �Ǘ��ԍ�
                    else if (this.uGrid_Details.ActiveCell.Column.Key == column_CarMngCode)
                    {
                        nextFocusColumn = column_CarMngCode;
                    }
                    // ���^�������ԍ�
                    else if (this.uGrid_Details.ActiveCell.Column.Key == column_NumberPlate1Code)
                    {
                        nextFocusColumn = column_NumberPlate1Code;
                    }
                    if (nextFocusColumn != string.Empty)
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[nextFocusColumn].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.SetFocus("tNedit_CustomerCode_St");
                    }

                    
                    this._canMove = true;
                }
            }
        }

        /// <summary>
        /// �O���b�h�V�t�g�^�u����
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�V�t�g�^�u������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        internal void SetGridShiftTabFocus(ref ChangeFocusEventArgs e)
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
                    this.SetFocus("Before_Grid");
                }

                return;
            }
            else
            {
                // �Z���A�N�e�B�u
                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                int columnIndex = this.uGrid_Details.ActiveCell.Column.Index;

                // �O���b�h�E�o���p�̃R���g���[����ێ�
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
                    this.SetFocus("Before_Grid");
                }
            }
        }

        /// <summary>
        /// ���̓��͉\���Key���擾����
        /// </summary>
        /// <param name="colIndex">�`�F�b�N�J�n��index�AActivation�\���Ԃ�</param>
        /// <param name="rowIndex">�`�F�b�N�J�n�sindex�AActivation�\�s��Ԃ�</param>
        /// <param name="isShift">true:�V�t�g���� false:�V�t�g�Ȃ�</param>
        /// <param name="ActivationColIndex">Activation�\��Index</param>
        /// <param name="ActivationRowIndex">Activation�\�sIndex</param>
        /// <returns>Activation�\��̃L�[�B�Ȃ��ꍇ��string.Empty</returns>
        /// <remarks>
        /// <br>Note       : ���̓��͉\���Key���擾���s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
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
                    if (!this.uGrid_Details.Rows[j].IsFilteredOut)
                    {
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
                    }
                }
            }
            else
            {
                // �V�t�g����
                for (int j = rowIndex; j >= 0; j--)
                {
                    if (!this.uGrid_Details.Rows[j].IsFilteredOut)
                    {
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
                    }
                }
            }

            return string.Empty;
        }
        #endregion

        #region �� ���̑�����
        /// <summary>
        /// ��T�C�Y�̎��������`�F�b�N�{�b�N�X�̔��f
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        internal void AutoFillToColumnSetting(bool isChecked)
        {
            if (isChecked)
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

                // ��ʃ��[�h���̗񕝂ɖ߂��܂�
                this.SetGridInitialLayout();
            }
        }

        /// <summary>
        /// �����T�C�Y�̔��f
        /// </summary>
        /// <remarks>
        /// <br>Note        : �����T�C�Y�̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        internal void GridFontSizeSetting(int size)
        {
            this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = size;
        }

        /// <summary>
        /// �폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X�̔��f
        /// </summary>
        /// <remarks>
        /// <br>Note        : �폜�ς݃f�[�^�\���{�^���N�̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        internal void DeleteIndicationSetting(bool isChecked)
        {
            if (isChecked)
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._carInfoDataTable.DeleteDateColumn.ColumnName].Hidden = false;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._carInfoDataTable.DeleteDateColumn.ColumnName].Hidden = true;
            }

            this.SetGridFiltering(isChecked);
        }

        /// <summary>
        /// �t�B���^�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�B���^�ݒ菈�����s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SetGridFiltering(bool deleteDispChecked)
        {
            Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFilters = this.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters;

            columnFilters[this._carInfoDataTable.DeleteDateColumn.ColumnName].FilterConditions.Clear();

            if (!deleteDispChecked)
            {
                // �󔒂�Null�ȊO���t�B���^�ɐݒ肷��
                columnFilters[this._carInfoDataTable.DeleteDateColumn.ColumnName].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, "");
                columnFilters[this._carInfoDataTable.DeleteDateColumn.ColumnName].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, null);
                columnFilters[this._carInfoDataTable.DeleteDateColumn.ColumnName].LogicalOperator = Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or;
            }
        }
        #endregion
        #endregion

        #region ��private���\�b�h
        #region �� �K�C�h����
        /// <summary>
        /// ���Ӑ�K�C�h�\������
        /// </summary>
        /// <param name="customerSearchRet">���Ӑ�}�X�^</param>
        /// <param name="searchMode">����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ���Ӑ�K�C�h��\�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private int ShowCustomerGuide(out CustomerSearchRet customerSearchRet, int searchMode)
        {
            customerSearchRet = new CustomerSearchRet();

            this._cusotmerGuideSelected = false;

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(searchMode, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (this._cusotmerGuideSelected == true)
            {
                customerSearchRet = this._customerSearchRet;
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note        : ���Ӑ�K�C�h�œ��Ӑ��I���������ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // �I���������Ӑ�}�X�^���o�b�t�@�ɕێ�
            this._customerSearchRet = customerSearchRet.Clone();

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�\������
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���[�U�[�K�C�h��\�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private int ShowUserGuide(out UserGdBd userGdBd, int userGuideDivCd)
        {
            int status;
            UserGdHd userGdHd = new UserGdHd();

            userGdBd = new UserGdBd();

            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, userGuideDivCd);

            return status;
        }

        /// <summary>
        /// ���l�K�C�h�\������
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���l�K�C�h��\�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private int ShowNoteGuide(out NoteGuidBd noteGuidBd, int noteGuideDivCd)
        {
            int status;

            noteGuidBd = new NoteGuidBd();

            status = this._noteGuidAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, noteGuideDivCd);

            return status;
        }
        #endregion

        # region �� �����͉\�Z���ړ�����
        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �����͉\�Z���ړ��������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            try
            {
                // �X�V�J�n�i�`��X�g�b�v�j
                this.uGrid_Details.BeginUpdate();

                if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
                {
                    if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                        (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                }

                while (!moved)
                {
                    performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (moved)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // �X�V�I���i�`��ĊJ�j
                this.uGrid_Details.EndUpdate();
            }

            return performActionResult;
        }
        # endregion

        # region �� ���׃O���b�h�ݒ菈��
        /// <summary>
        /// ���׃O���b�h�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���׃O���b�h�ݒ菈�����s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        internal void SettingGrid()
        {
            try
            {
                // �`����ꎞ��~
                this.uGrid_Details.BeginUpdate();

                // �`�悪�K�v�Ȗ��׌������擾����B
                int cnt = this._carInfoDataTable.Count;

                // �e�s���Ƃ̐ݒ�
                for (int i = 0; i < cnt; i++)
                {
                    // Color�ݒ�
                    this.SetGridColorRow(this.uGrid_Details.Rows[i]);
                    // �Z��Activation�ݒ�
                    this.SetCellActivation(this.uGrid_Details.Rows[i]);
                    
                }
            }
            finally
            {
                // �`����J�n
                this.uGrid_Details.EndUpdate();
            }
        }
        # endregion

        # region �� ���׃O���b�h�E�s�P�ʂł̃Z���ݒ�
        /// <summary>
        /// ���׃O���b�h�E�s�P�ʂł̃Z��Color�ݒ�
        /// </summary>
        /// <param name="ultraRow">�Ώۍs</param>
        /// <remarks>
        /// <br>Note		: ���׃O���b�h�E�s�P�ʂł̃Z���ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void SetGridColorRow(UltraGridRow ultraRow)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            if (ultraRow.Selected)
            {
                // �I���s�̏ꍇ
                foreach (UltraGridCell cell in ultraRow.Cells)
                {
                    if (cell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
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
                if (ultraRow.Index % 2 == 0)
                {
                    foreach (UltraGridCell ultraCell in ultraRow.Cells)
                    {
                        if (ultraCell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
                        {
                            ultraCell.Appearance.BackColor = Color.White;
                            ultraCell.Appearance.BackColor2 = Color.White;
                            ultraCell.Appearance.BackColorDisabled = Color.White;
                            ultraCell.Appearance.BackColorDisabled2 = Color.White;
                        }
                    }
                }
                else
                {
                    foreach (UltraGridCell ultraCell in ultraRow.Cells)
                    {
                        if (ultraCell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
                        {
                            ultraCell.Appearance.BackColor = Color.Lavender;
                            ultraCell.Appearance.BackColor2 = Color.Lavender;
                            ultraCell.Appearance.BackColorDisabled = Color.Lavender;
                            ultraCell.Appearance.BackColorDisabled2 = Color.Lavender;
                        }
                    }
                }

                int status = (int)ultraRow.Cells[this._carInfoDataTable.RowStatusColumn.ColumnName].Value;
                int deleteFlag = (int)ultraRow.Cells[this._carInfoDataTable.DeleteFlagColumn.ColumnName].Value;

                // COPY�s
                if (status == CarMngListInputAcs.ROWSTATUS_COPY)
                {
                    foreach (UltraGridCell ultraCell in ultraRow.Cells)
                    {
                        if (ultraCell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
                        {
                            ultraCell.Appearance.BackColor = Color.Pink;
                            ultraCell.Appearance.BackColor2 = Color.Pink;
                            ultraCell.Appearance.BackColorDisabled = Color.Pink;
                            ultraCell.Appearance.BackColorDisabled2 = Color.Pink;
                        }
                    }
                }
                // �_���폜�s
                else if (deleteFlag == CarMngListInputAcs.DELETE_FLAG1)
                {
                    foreach (UltraGridCell ultraCell in ultraRow.Cells)
                    {
                        if (ultraCell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
                        {
                            ultraCell.Appearance.BackColor = Color.Red;
                            ultraCell.Appearance.BackColor2 = Color.Red;
                            ultraCell.Appearance.BackColorDisabled = Color.Red;
                            ultraCell.Appearance.BackColorDisabled2 = Color.Red;
                        }
                    }
                }
                else
                {
                    // �ǉ��s�͑ΏۊO(�ʏ�F�ǂ���)
                    if (ultraRow.Cells[this._carInfoDataTable.RowNoColumn.ColumnName].Value.ToString() == CarMngListInputAcs.ROWNO_NEW)
                    {
                        return;
                    }

                    // �X�V�Z���ݒ�
                    if (this._carMngListInputAcs.OriginalCarInfoDataTable.Rows.Count == 0)
                    {
                        return;
                    }

                    DataRow[] originalDrs = this._carMngListInputAcs.OriginalCarInfoDataTable
                        .Select(this._carInfoDataTable.CarRelationGuidColumn.ColumnName + " = '"
                        + ultraRow.Cells[this._carInfoDataTable.CarRelationGuidColumn.ColumnName].Value.ToString() + "'");
                    if (originalDrs.Length > 0)
                    {
                        DataRow originalDr = originalDrs[0];
                        for (int j = 0; j < this._carInfoDataTable.Columns.Count; j++)
                        {
                            if (ultraRow.Cells[j].Value.ToString() != originalDr[j].ToString())
                            {
                                ultraRow.Cells[j].Appearance.BackColor = Color.Lime;
                                ultraRow.Cells[j].Appearance.BackColor2 = Color.Lime;
                                ultraRow.Cells[j].Appearance.BackColorDisabled = Color.Lime;
                                ultraRow.Cells[j].Appearance.BackColorDisabled2 = Color.Lime;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �Z��Activation�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������A�Z���P�ʂ̓��͋��ݒ���s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        internal void SetCellActivation(UltraGridRow ultraRow)
        {
            // �_���폜�s�͕ҏW�s��
            if ((int)ultraRow.Cells[this._carInfoDataTable.DeleteFlagColumn.ColumnName].Value == CarMngListInputAcs.DELETE_FLAG1
                || ultraRow.Cells[this._carInfoDataTable.DeleteDateColumn.ColumnName].Value != DBNull.Value)
            {
                foreach (UltraGridCell ultraCell in ultraRow.Cells)
                {
                    //ultraCell.Activation = Activation.NoEdit;
                    ultraCell.Activation = Activation.Disabled;  // ADD 2009/10/10
                }
                ultraRow.Cells[this._carInfoDataTable.CustomerCodeGuideColumn.ColumnName].Activation = Activation.Disabled;
                ultraRow.Cells[this._carInfoDataTable.CarNoteGuideColumn.ColumnName].Activation = Activation.Disabled;
                ultraRow.Cells[this._carInfoDataTable.NumberPlate1CodeGuideColumn.ColumnName].Activation = Activation.Disabled;
                // ---- ADD 2009/10/10 ------>>>>>
                //�폜�{�^����������A���������ł��Ȃ��B�폜�{�^���������́A�ԐF�ɕύX����̂ł͂Ȃ��O���b�g�ォ������悤�ɕύX
                string delDt = ultraRow.Cells[this._carInfoDataTable.DeleteDateColumn.ColumnName].Value.ToString();
                if (string.Empty.Equals(delDt))
                {
                    ultraRow.Hidden = true;
                }
                else
                {
                    ultraRow.Hidden = false;
                }
                // ---- ADD 2009/10/10 ------<<<<<
            }
            else
            {
                // �ҏW��ԂɍX�V
                ultraRow.Cells[this._carInfoDataTable.CarNoteGuideColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.NumberPlate1CodeGuideColumn.ColumnName].Activation = Activation.AllowEdit;

                ultraRow.Cells[this._carInfoDataTable.EngineModelColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.CarAddInfo1Column.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.CarAddInfo2Column.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.NumberPlate1CodeColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.NumberPlate2Column.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.NumberPlate3Column.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.NumberPlate4Column.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.MileageColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.CarInspectYearColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.EntryDateColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.LTimeCiMatDateColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.InspectMaturityDateColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.CarNoteColumn.ColumnName].Activation = Activation.AllowEdit;
            }

            // �V�K�s,���͂��\�Ƃ���B
            if ((string)ultraRow.Cells[this._carInfoDataTable.RowNoColumn.ColumnName].Value == CarMngListInputAcs.ROWNO_NEW)
            {
                ultraRow.Cells[this._carInfoDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.CustomerCodeGuideColumn.ColumnName].Activation = Activation.AllowEdit;
                ultraRow.Cells[this._carInfoDataTable.CarMngCodeColumn.ColumnName].Activation = Activation.AllowEdit;
            }
            else
            {
                //ultraRow.Cells[this._carInfoDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                ultraRow.Cells[this._carInfoDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.Disabled;  // ADD 2009/10/10
                ultraRow.Cells[this._carInfoDataTable.CustomerCodeGuideColumn.ColumnName].Activation = Activation.Disabled;
                //ultraRow.Cells[this._carInfoDataTable.CarMngCodeColumn.ColumnName].Activation = Activation.NoEdit;
                ultraRow.Cells[this._carInfoDataTable.CarMngCodeColumn.ColumnName].Activation = Activation.Disabled;  // ADD 2009/10/10
            }
        }
        #endregion

        # region �� �폜����
        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="selectedStockRowNoList"></param>
        /// <remarks>
        /// <br>Note       : �폜�������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void RowDelete(List<Guid> selectedStockRowNoList)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �s�폜����
                this._carMngListInputAcs.DeleteCarInfoRow(selectedStockRowNoList);

                // ���׃O���b�h�Z���ݒ菈��
                this.SettingGrid();

                // �����͉\�Z���ړ�����
                this.MoveNextAllowEditCell(true);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region �� �{�^��Enabled�ύX��C�x���g
        /// <summary>
        /// ���p���ʃ{�^��Enabled�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : ���p���ʃ{�^��Enabled�ύX���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uButton_RowCopy_EnabledChanged(object sender, EventArgs e)
        {
            this._rowCopyButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// ���p�\�t�{�^��Enabled�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : ���p�\�t�{�^��Enabled�ύX���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uButton_RowCopyAdd_EnabledChanged(object sender, EventArgs e)
        {
            this._rowPasteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// �폜�{�^��Enabled�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �폜�{�^��Enabled�ύX���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uButton_RowDelete_EnabledChanged(object sender, EventArgs e)
        {
            this._rowDeleteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// CellDataError �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �s���Ȓl�����͂��ꂽ��ԂŃZ���l���X�V���悤�Ƃ������ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            e.RaiseErrorEvent = false;
            e.StayInEditMode = false;

            if (this.uGrid_Details.ActiveCell != null)
            {
                // ���l���ڂ̏ꍇ
                if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // �����͂�0�ɂ���
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // �ʏ����
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
                            this.uGrid_Details.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�
                    e.StayInEditMode = false;			// �ҏW���[�h�͔�����
                }
            }
        }
        #endregion

        #region �� ���̑�����
        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// <br>Note        : ���l�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
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
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
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
                int _pointPos = strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
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
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //----- ADD 2016/12/13 ���R Redmine#48934 PMNS�i���o�[�v���[�g�p�����Ή� ----->>>>>
        /// <summary>
        /// ��������̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// <br>Note        : �p�����̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2016/12/13</br>
        /// </remarks>
        private bool KeyPressChrCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }

            string value = key.ToString();

            Regex r = new Regex(@"^[a-z��-��A-Z�`-�y0-9�O-�X]+(\.)?[a-z��-��A-Z�`-�y0-9�O-�X]*$");

            if ((!String.IsNullOrEmpty(value)) && !r.IsMatch(value))
            {
                return false;
            }
               
            return true;
        }
        //----- ADD 2016/12/13 ���R Redmine#48934 PMNS�i���o�[�v���[�g�p�����Ή� -----<<<<<

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// <br>Note        : �Ȃ��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private bool KeyPressStringCheck(int keta, string prevVal, char key, int selstart, int sellength)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
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

            return true;
        }

        /// <summary>
        /// �I���ςݎd���s�ԍ����X�g�擾����
        /// </summary>
        /// <returns>�I���ςݎd���s�ԍ����X�g</returns>
        /// <remarks>
        /// <br>Note       : �I���ςݎd���s�ԍ����X�g�擾�������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>UpdateNote : ���� 2009/10/21 </br>
        /// <br>           : MANTIS�F0014458 �\�[�g��ɍ폜���s���ƁA�\�[�g�O�̎��q���폜�����B</br>
        /// </remarks>
        public List<Guid> GetSelectedRowNoList()
        {
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;
            if (rows == null) return null;

            List<Guid> selectedRowNoList = new List<Guid>();

            if (rows != null)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
                {
                    // --- UPD 2009/10/21 MANTIS�F0014458 ----->>>>> 
                    //selectedRowNoList.Add(this._carInfoDataTable[row.Index].CarRelationGuid);
                    selectedRowNoList.Add((Guid)this.uGrid_Details.Rows[row.Index].Cells[0].Value);
                    // --- UPD 2009/10/21 MANTIS�F0014458 -----<<<<<

                }
            }

            return selectedRowNoList;
        }

        /// <summary>
        /// ���q�Ǘ��}�X�^�`�F�b�N����
        /// </summary>
        /// <param name="row">�s</param>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��}�X�^�`�F�b�N�������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void CarManagementCheck(UltraGridRow row)
        {
            this._chooseFlg = true;
            string customer = (string)row.Cells[column_CustomerCode].Value;
            string carMngCode = (string)row.Cells[column_CarMngCode].Value;
            // ���Ӑ�R�[�h�ƊǗ��ԍ��͓��͂����ꍇ
            if (customer != string.Empty && carMngCode != string.Empty)
            {
                CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();

                paramInfo.IsCheckCustomerCode = true;
                paramInfo.CustomerCode = this._carMngListInputAcs.StrObjToInt(customer);
                paramInfo.IsCheckCarMngCode = true;
                paramInfo.CarMngCode = carMngCode;
                paramInfo.IsCheckCarMngDivCd = false;
                paramInfo.EnterpriseCode = this._enterpriseCode;

                int status = this._carMngInputAcs.ExecuteGuidBeforeDataCheck(paramInfo);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "���͂��ꂽ�R�[�h�̎��q�Ǘ��}�X�^��񂪊��ɓo�^����Ă��܂��B" + "\r\n" + "\r\n" +
                        "�ʂ̎��q�Ƃ��ē��͂��s���܂����H",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        this._canMove = true;

                        row.Cells["SaveCanFlag"].Value = 0; // 2009/10/26 ADD
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this._canMove = false;
                        this._chooseFlg = false;
                        row.Cells["SaveCanFlag"].Value = 1; // 2009/10/26 ADD
                    }
                }
                else
                {
                    this._canMove = true;

                    row.Cells["SaveCanFlag"].Value = 0; // 2009/10/26 ADD
                }
            }
            else
            {
                this._canMove = true;
            }
        }
        #endregion
        #endregion

        #region ���R���g���[���C�x���g

        #region �� �����C�x���g
        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : UserControl��Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void PMSYA09021UB_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.DataSource = this._carInfoDataTable;

            // �R���g���[��������
            this.InitializeScreen();
        }

        /// <summary>
        /// ��ʏ�����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A�O���b�h�����f�[�^�ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // �X�L���ݒ�
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // �{�^���ݒ�
            this.uButton_RowCopy.ImageList = this._imageList16;
            this.uButton_RowCopyAdd.ImageList = this._imageList16;
            this.uButton_RowDelete.ImageList = this._imageList16;

            this.uButton_RowCopy.Appearance.Image = (int)Size16_Index.ROWCOPY;
            this.uButton_RowCopyAdd.Appearance.Image = (int)Size16_Index.ROWPASTE;
            this.uButton_RowDelete.Appearance.Image = (int)Size16_Index.ROWDELETE;

            // �{�^��������
            this._rowCopyButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowCopy"];
            this._rowDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowDelete"];
            this._rowPasteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowPaste"];

            this.tToolbarsManager_Main.ImageListSmall = this._imageList16;

            this._rowCopyButton.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ROWCOPY;
            this._rowDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ROWDELETE;
            this._rowPasteButton.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ROWPASTE;
        }

        /// <summary>
        /// �O���b�h�������C�A�E�g�ݒ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A�O���b�h�������C�A�E�g�ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �O���b�h�񏉊��ݒ菈��
            this.SetGridInitialLayout();

            // �O���b�h��\����\���ݒ菈��
            this.SetGridColVisible();

            // �{�^������L������
            this.SetButtonEnable();
        }

        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ������̎��A�O���b�h�񏉊��ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// <br>Update Note : SPK�ԑ�ԍ�������Ή��ɔ����n���h���ʒu�`�F�b�N�����̒ǉ�</br>
        /// <br>Programmer  : FSI���� ����</br>
        /// <br>Date        : 2013/03/22</br>
        /// <br>UpdateNote  : 2016/12/13 ���R</br>
        /// <br>�Ǘ��ԍ�    : 11270098-00</br>
        /// <br>            : Redmine#48934 PMNS�i���o�[�v���[�g�p�����Ή�</br>
        /// </remarks>
        private void SetGridInitialLayout()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // �w�b�_�N���b�N�A�N�V�����̐ݒ�(�\�[�g����)
            editBand.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            // �s�t�B���^�[�ݒ�
            editBand.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            // �����s�I����
            editBand.Layout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;

            editBand.ColHeadersVisible = true;

            CarMngInputDataSet.CarInfoDataTable table = this._carInfoDataTable;
            ColumnsCollection columns = editBand.Columns;


            // �s�ԍ���̂݃Z���\���F�ύX
            columns[table.RowNoColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columns[table.RowNoColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columns[table.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[table.RowNoColumn.ColumnName].CellAppearance.ForeColor = Color.White;
            columns[table.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.White;

            // �s�ԍ���̃\�[�g���w��
            columns[table.RowNoColumn.ColumnName].SortComparer = new RowNumberSortComparer(); // ADD 2009/10/26


            //--------------------------------------
            // �Œ�w�b�_�[
            //--------------------------------------
            // �u���v�u�폜���v�u���Ӑ�R�[�h�v�u�Ǘ��ԍ��v�u�Ԏ�v�u�^���v
            columns[table.RowNoColumn.ColumnName].Header.Fixed = true;
            editBand.Columns[table.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            columns[table.DeleteDateColumn.ColumnName].Header.Fixed = true;
            columns[table.CustomerCodeColumn.ColumnName].Header.Fixed = true;
            columns[table.CustomerCodeGuideColumn.ColumnName].Header.Fixed = true;
            columns[table.CarMngCodeColumn.ColumnName].Header.Fixed = true;
            columns[table.CarMngCodeGuideColumn.ColumnName].Header.Fixed = true;
            columns[table.ModelFullNameColumn.ColumnName].Header.Fixed = true;
            //columns[table.FullModelColumn.ColumnName].Header.Fixed = true;   // DEL 2009/10/10

            //--------------------------------------
            // ���͕s��
            //--------------------------------------
            columns[table.RowNoColumn.ColumnName].CellActivation = Activation.Disabled;
            // ---- UPD 2009/10/10 ---->>>>>
            //columns[table.DeleteDateColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.ModelFullNameColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.FullModelColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.ModelDesignationNoColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.CategoryNoColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.EngineModelNmColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.FirstEntryDateColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.FrameNoColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.ColorCodeColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.TrimCodeColumn.ColumnName].CellActivation = Activation.NoEdit;
            //columns[table.NumberPlate1NameColumn.ColumnName].CellActivation = Activation.NoEdit;

            columns[table.DeleteDateColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.ModelFullNameColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.FullModelColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.ModelDesignationNoColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.CategoryNoColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.EngineModelNmColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.FirstEntryDateColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.FrameNoColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.ColorCodeColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.TrimCodeColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.NumberPlate1NameColumn.ColumnName].CellActivation = Activation.Disabled;
            // ---- UPD 2009/10/10 ----<<<<<

            //--------------------------------------
            // �L���v�V����
            //--------------------------------------
            columns[table.RowNoColumn.ColumnName].Header.Caption = "No.";
            columns[table.DeleteDateColumn.ColumnName].Header.Caption = "�폜��";
            columns[table.CustomerCodeColumn.ColumnName].Header.Caption = "���Ӑ�R�[�h";
            columns[table.CustomerCodeGuideColumn.ColumnName].Header.Caption = "";
            columns[table.CarMngCodeColumn.ColumnName].Header.Caption = "�Ǘ��ԍ�";
            columns[table.CarMngCodeGuideColumn.ColumnName].Header.Caption = "";
            columns[table.ModelFullNameColumn.ColumnName].Header.Caption = "�Ԏ�";
            columns[table.FullModelColumn.ColumnName].Header.Caption = "�^��";
            columns[table.ModelDesignationNoColumn.ColumnName].Header.Caption = "�^���w��ԍ�";
            columns[table.CategoryNoColumn.ColumnName].Header.Caption = "�ޕʔԍ�";
            columns[table.EngineModelNmColumn.ColumnName].Header.Caption = "�G���W���^��";
            columns[table.FirstEntryDateColumn.ColumnName].Header.Caption = "�N��";
            columns[table.FrameNoColumn.ColumnName].Header.Caption = "�ԑ�ԍ�";
            columns[table.ColorCodeColumn.ColumnName].Header.Caption = "�J���[";
            columns[table.TrimCodeColumn.ColumnName].Header.Caption = "�g����";
            columns[table.EngineModelColumn.ColumnName].Header.Caption = "�����@�^��";
            columns[table.CarAddInfo1Column.ColumnName].Header.Caption = "�ǉ����P";
            columns[table.CarAddInfo2Column.ColumnName].Header.Caption = "�ǉ����Q";
            columns[table.NumberPlate1CodeColumn.ColumnName].Header.Caption = "���^�������ԍ�";
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].Header.Caption = "";
            columns[table.NumberPlate1NameColumn.ColumnName].Header.Caption = "���^�����ǖ���";
            columns[table.NumberPlate2Column.ColumnName].Header.Caption = "�o�^�ԍ��i��ʁj";
            columns[table.NumberPlate3Column.ColumnName].Header.Caption = "�o�^�ԍ��i�J�i�j";
            columns[table.NumberPlate4Column.ColumnName].Header.Caption = "�o�^�ԍ��i�v���[�g�ԍ��j";
            columns[table.MileageColumn.ColumnName].Header.Caption = "���s����";
            columns[table.CarInspectYearColumn.ColumnName].Header.Caption = "�Ԍ�����";
            columns[table.EntryDateColumn.ColumnName].Header.Caption = "�o�^�N����";
            columns[table.LTimeCiMatDateColumn.ColumnName].Header.Caption = "�O��Ԍ���";
            columns[table.InspectMaturityDateColumn.ColumnName].Header.Caption = "����Ԍ���";
            columns[table.CarNoteColumn.ColumnName].Header.Caption = "���q���l";
            columns[table.CarNoteGuideColumn.ColumnName].Header.Caption = "";

            //--------------------------------------
            // ��
            //--------------------------------------
            // --- UPD ���X�ؘj 2021/11/02 ------>>>>> 
            //columns[table.RowNoColumn.ColumnName].Width = 45;
            columns[table.RowNoColumn.ColumnName].Width = 50;
            // --- UPD ���X�ؘj 2021/11/02 ------<<<<<
            columns[table.DeleteDateColumn.ColumnName].Width = 90;
            // ---- UPD 2009/10/10 ---->>>>>
            //columns[table.CustomerCodeColumn.ColumnName].Width = 120;
            columns[table.CustomerCodeColumn.ColumnName].Width = 75;
            columns[table.CustomerCodeGuideColumn.ColumnName].Width = 24;
            //columns[table.CarMngCodeColumn.ColumnName].Width = 170;
            columns[table.CarMngCodeColumn.ColumnName].Width = 155;
            columns[table.CarMngCodeGuideColumn.ColumnName].Width = 24;
            //columns[table.ModelFullNameColumn.ColumnName].Width = 150;
            columns[table.ModelFullNameColumn.ColumnName].Width = 140;
            // ---- UPD 2009/10/10 ----<<<<<
            columns[table.FullModelColumn.ColumnName].Width = 130;
            columns[table.ModelDesignationNoColumn.ColumnName].Width = 130;
            columns[table.CategoryNoColumn.ColumnName].Width = 90;
            columns[table.EngineModelNmColumn.ColumnName].Width = 120;
            // --- UPD 2013/05/14 Y.Wakita ---------->>>>>
            //columns[table.FirstEntryDateColumn.ColumnName].Width = 90;
            columns[table.FirstEntryDateColumn.ColumnName].Width = 105;
            // --- UPD 2013/05/14 Y.Wakita ----------<<<<<
            // --- UPD 2013/03/22 ---------->>>>>
            // VIN�R�[�h17���\���o����悤�ɗ񕝂��C��
            //columns[table.FrameNoColumn.ColumnName].Width = 100;
            columns[table.FrameNoColumn.ColumnName].Width = 160;
            // --- UPD 2013/03/22 ----------<<<<<
            columns[table.ColorCodeColumn.ColumnName].Width = 90;
            columns[table.TrimCodeColumn.ColumnName].Width = 90;
            columns[table.EngineModelColumn.ColumnName].Width = 110;
            columns[table.CarAddInfo1Column.ColumnName].Width = 160;
            columns[table.CarAddInfo2Column.ColumnName].Width = 160;
            columns[table.NumberPlate1CodeColumn.ColumnName].Width = 130;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].Width = 24;
            columns[table.NumberPlate1NameColumn.ColumnName].Width = 130;
            columns[table.NumberPlate2Column.ColumnName].Width = 150;
            columns[table.NumberPlate3Column.ColumnName].Width = 150;
            columns[table.NumberPlate4Column.ColumnName].Width = 210;
            columns[table.MileageColumn.ColumnName].Width = 90;
            columns[table.CarInspectYearColumn.ColumnName].Width = 100;
            columns[table.EntryDateColumn.ColumnName].Width = 130;
            columns[table.LTimeCiMatDateColumn.ColumnName].Width = 130;
            columns[table.InspectMaturityDateColumn.ColumnName].Width = 130;
            columns[table.CarNoteColumn.ColumnName].Width = 210;
            columns[table.CarNoteGuideColumn.ColumnName].Width = 24;

            //--------------------------------------
            // ���͌���
            //--------------------------------------
            //columns[table.RowNoColumn.ColumnName].MaxLength = 4;
            //columns[table.DeleteDateColumn.ColumnName].MaxLength = 4;
            columns[table.CustomerCodeColumn.ColumnName].MaxLength = 8;
            //columns[table.CustomerCodeGuideColumn.ColumnName].MaxLength = 4;
            columns[table.CarMngCodeColumn.ColumnName].MaxLength = 18;
            //columns[table.CarMngCodeGuideColumn.ColumnName].MaxLength = 4;
            columns[table.ModelFullNameColumn.ColumnName].MaxLength = 4;
            columns[table.FullModelColumn.ColumnName].MaxLength = 4;
            columns[table.ModelDesignationNoColumn.ColumnName].MaxLength = 4;
            columns[table.CategoryNoColumn.ColumnName].MaxLength = 4;
            columns[table.EngineModelNmColumn.ColumnName].MaxLength = 4;
            //columns[table.FirstEntryDateColumn.ColumnName].MaxLength = 4;
            columns[table.FrameNoColumn.ColumnName].MaxLength = 4;
            columns[table.ColorCodeColumn.ColumnName].MaxLength = 4;
            columns[table.TrimCodeColumn.ColumnName].MaxLength = 4;
            columns[table.EngineModelColumn.ColumnName].MaxLength = 12;
            columns[table.CarAddInfo1Column.ColumnName].MaxLength = 15;
            columns[table.CarAddInfo2Column.ColumnName].MaxLength = 15;
            columns[table.NumberPlate1CodeColumn.ColumnName].MaxLength = 4;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].MaxLength = 4;
            columns[table.NumberPlate1NameColumn.ColumnName].MaxLength = 4;
            columns[table.NumberPlate2Column.ColumnName].MaxLength = 3;
            columns[table.NumberPlate3Column.ColumnName].MaxLength = 1;
            columns[table.NumberPlate4Column.ColumnName].MaxLength = 4;
            columns[table.MileageColumn.ColumnName].MaxLength = 7;
            columns[table.CarInspectYearColumn.ColumnName].MaxLength = 2;
            //columns[table.EntryDateColumn.ColumnName].MaxLength = 20;
            //columns[table.LTimeCiMatDateColumn.ColumnName].MaxLength = 20;
            //columns[table.InspectMaturityDateColumn.ColumnName].MaxLength = 20;
            columns[table.CarNoteColumn.ColumnName].MaxLength = 30;
            columns[table.CarNoteGuideColumn.ColumnName].MaxLength = 4;

            //--------------------------------------
            // �e�L�X�g�ʒu(HAlign)
            //--------------------------------------
            columns[table.RowNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.DeleteDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.CustomerCodeGuideColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;
            columns[table.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            //columns[table.CarMngCodeGuideColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;
            columns[table.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.FullModelColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.ModelDesignationNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.CategoryNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.EngineModelNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.FirstEntryDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.FrameNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;  // ADD 2013/03/22
            columns[table.ColorCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.TrimCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.EngineModelColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.CarAddInfo1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.CarAddInfo2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.NumberPlate1CodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;
            columns[table.NumberPlate1NameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            //----- UPD 2016/12/13 ���R Redmine#48934 PMNS�i���o�[�v���[�g�p�����Ή� ----->>>>>
            //columns[table.NumberPlate2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.NumberPlate2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            //----- UPD 2016/12/13 ���R Redmine#48934 PMNS�i���o�[�v���[�g�p�����Ή� -----<<<<<
            columns[table.NumberPlate3Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.NumberPlate4Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.MileageColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.CarInspectYearColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.EntryDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.LTimeCiMatDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.InspectMaturityDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.CarNoteColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.CarNoteGuideColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;
            //--------------------------------------
            // �e�L�X�g�ʒu(VAlign)
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.TextVAlign = VAlign.Middle;
            }

            //--------------------------------------
            // ���t�R���g���[���ݒ�
            //--------------------------------------
            //columns[table.FirstEntryDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            columns[table.EntryDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            columns[table.LTimeCiMatDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            columns[table.InspectMaturityDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;

            //columns[table.FirstEntryDateColumn.ColumnName].CellDisplayStyle = CellDisplayStyle.FormattedText;
            columns[table.EntryDateColumn.ColumnName].CellDisplayStyle = CellDisplayStyle.FormattedText;
            columns[table.LTimeCiMatDateColumn.ColumnName].CellDisplayStyle = CellDisplayStyle.FormattedText;
            columns[table.InspectMaturityDateColumn.ColumnName].CellDisplayStyle = CellDisplayStyle.FormattedText;

            //columns[table.FirstEntryDateColumn.ColumnName].Format = "yyyy�NMM��";
            columns[table.EntryDateColumn.ColumnName].Format = "yyyy�NMM��dd��";
            columns[table.LTimeCiMatDateColumn.ColumnName].Format = "yyyy�NMM��dd��";
            columns[table.InspectMaturityDateColumn.ColumnName].Format = "yyyy�NMM��dd��";
            columns[table.DeleteDateColumn.ColumnName].Format = "yyyy/MM/dd";
            columns[table.MileageColumn.ColumnName].Format = "###,###,##0";

            //--------------------------------------
            // �K�C�h�{�^���ݒ�
            //--------------------------------------
            Image guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            columns[table.CustomerCodeGuideColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[table.CarMngCodeGuideColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[table.CarNoteGuideColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;

            columns[table.CustomerCodeGuideColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[table.CarMngCodeGuideColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[table.CarNoteGuideColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;

            columns[table.CustomerCodeGuideColumn.ColumnName].CellButtonAppearance.Image = guideButtonImage;
            columns[table.CarMngCodeGuideColumn.ColumnName].CellButtonAppearance.Image = guideButtonImage;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].CellButtonAppearance.Image = guideButtonImage;
            columns[table.CarNoteGuideColumn.ColumnName].CellButtonAppearance.Image = guideButtonImage;

            columns[table.CustomerCodeGuideColumn.ColumnName].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[table.CarMngCodeGuideColumn.ColumnName].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[table.CarNoteGuideColumn.ColumnName].CellButtonAppearance.ImageHAlign = HAlign.Center;

            columns[table.CustomerCodeGuideColumn.ColumnName].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[table.CarMngCodeGuideColumn.ColumnName].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[table.CarNoteGuideColumn.ColumnName].CellButtonAppearance.ImageVAlign = VAlign.Middle;

            columns[table.CustomerCodeGuideColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            columns[table.CarMngCodeGuideColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            columns[table.CarNoteGuideColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;

            //--------------------------------------
            // �N���b�N�����쐧��
            //--------------------------------------
            columns[table.RowNoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.DeleteDateColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            //columns[table.CustomerCodeColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            //columns[table.CustomerCodeGuideColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            // ---- ADD 2009/10/10 ------>>>>>
            columns[table.DeleteDateColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.ModelFullNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.FullModelColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.ModelDesignationNoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.CategoryNoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.EngineModelNmColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.FirstEntryDateColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.FrameNoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.ColorCodeColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.TrimCodeColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.NumberPlate1NameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            // ---- ADD 2009/10/10 ------<<<<<

            //--------------------------------------
            // �t�H�[�}�b�g�ݒ�
            //--------------------------------------
            //columns[table.CustomerCodeColumn.ColumnName].CellDisplayStyle = CellDisplayStyle.FormattedText;
            //columns[table.CustomerCodeColumn.ColumnName].Format = "00000000";

            columns[table.DeleteDateColumn.ColumnName].CellAppearance.ForeColor = Color.Red;
            columns[table.DeleteDateColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Red;
        }

        /// <summary>
        /// �O���b�h��\����\���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ������̎��A�O���b�h�񏉊��ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void SetGridColVisible()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            CarMngInputDataSet.CarInfoDataTable table = this._carInfoDataTable;
            ColumnsCollection columns = editBand.Columns;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                col.Hidden = true;
            }

            columns[table.RowNoColumn.ColumnName].Hidden = false;
            columns[table.DeleteDateColumn.ColumnName].Hidden = true;
            columns[table.CustomerCodeColumn.ColumnName].Hidden = false;
            columns[table.CustomerCodeGuideColumn.ColumnName].Hidden = false;
            columns[table.CarMngCodeColumn.ColumnName].Hidden = false;
            columns[table.CarMngCodeGuideColumn.ColumnName].Hidden = true;
            columns[table.ModelFullNameColumn.ColumnName].Hidden = false;
            columns[table.FullModelColumn.ColumnName].Hidden = false;
            columns[table.ModelDesignationNoColumn.ColumnName].Hidden = false;
            columns[table.CategoryNoColumn.ColumnName].Hidden = false;
            columns[table.EngineModelNmColumn.ColumnName].Hidden = false;
            columns[table.FirstEntryDateColumn.ColumnName].Hidden = false;
            columns[table.FrameNoColumn.ColumnName].Hidden = false;
            columns[table.ColorCodeColumn.ColumnName].Hidden = false;
            columns[table.TrimCodeColumn.ColumnName].Hidden = false;
            columns[table.EngineModelColumn.ColumnName].Hidden = false;
            columns[table.CarAddInfo1Column.ColumnName].Hidden = false;
            columns[table.CarAddInfo2Column.ColumnName].Hidden = false;
            columns[table.NumberPlate1CodeColumn.ColumnName].Hidden = false;
            columns[table.NumberPlate1CodeGuideColumn.ColumnName].Hidden = false;
            columns[table.NumberPlate1NameColumn.ColumnName].Hidden = false;
            columns[table.NumberPlate2Column.ColumnName].Hidden = false;
            columns[table.NumberPlate3Column.ColumnName].Hidden = false;
            columns[table.NumberPlate4Column.ColumnName].Hidden = false;
            columns[table.MileageColumn.ColumnName].Hidden = false;
            columns[table.CarInspectYearColumn.ColumnName].Hidden = false;
            columns[table.EntryDateColumn.ColumnName].Hidden = false;
            columns[table.LTimeCiMatDateColumn.ColumnName].Hidden = false;
            columns[table.InspectMaturityDateColumn.ColumnName].Hidden = false;
            columns[table.CarNoteColumn.ColumnName].Hidden = false;
            columns[table.CarNoteGuideColumn.ColumnName].Hidden = false;

        }

        /// <summary>
        /// �{�^������L������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �{�^������L���������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        public void SetButtonEnable()
        {
            // �{�^������L������(���p����,�폜)
            this.SetCopyDeleteButtonEnable();

            // �{�^������L������(���p�\�t)
            this.SetPasteButtonEnable();
        }

        /// <summary>
        /// �{�^������L������(���p����,�폜)
        /// </summary>
        /// <remarks>
        /// <br>Note		: �{�^������L������(���p����,�폜)���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void SetCopyDeleteButtonEnable()
        {
            int mode = -1;

            // �{�^����������
            // �I���ςݍs�ԍ����X�g�擾����
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;
            if (rows == null || rows.Count == 0)
            {
                this.SetEditButton(false);
                mode = -1;
            }
            // �I���ςݍs����
            else if (rows.Count > 1)
            {
                mode = MODE_SELECTEDMULTI;
            }
            else
            {
                mode = MODE_SELECTEDSINGLE;
            }

            switch (mode)
            {
                // �I���ςݍs�����ȊO
                case MODE_SELECTEDSINGLE:
                    {
                        this.uButton_RowCopy.Enabled = true;

                        // �_���폜�ς̏ꍇ,�{�^���𖳌�
                        if (rows[0].Cells[this._carInfoDataTable.DeleteDateColumn.ColumnName].Value != DBNull.Value
                            && (DateTime)rows[0].Cells[this._carInfoDataTable.DeleteDateColumn.ColumnName].Value != DateTime.MinValue)
                        {
                            this.uButton_RowDelete.Enabled = false;
                        }
                        else
                        {
                            this.uButton_RowDelete.Enabled = true;
                        }

                        // �V�K�̏ꍇ�A�ҏW�s��
                        if ((string)rows[0].Cells[column_No].Value == CarMngListInputAcs.ROWNO_NEW)
                        {
                            this.SetEditButton(false);
                        }
                        else
                        {
                            this.SetEditButton(true);
                        }
                        break;
                    }
                // �I���ςݍs����
                case MODE_SELECTEDMULTI:
                    {
                        this.uButton_RowCopy.Enabled = true;
                        this.uButton_RowDelete.Enabled = false;

                        this.SetEditButton(false);
                        break;
                    }
                default:
                    {
                        this.uButton_RowCopy.Enabled = false;
                        this.uButton_RowDelete.Enabled = false;

                        this.SetEditButton(false);
                        break;
                    }
            }
        }

        /// <summary>
        /// �{�^������L������(���p�\�t)
        /// </summary>
        /// <remarks>
        /// <br>Note		: �{�^������L������(���p�\�t)���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void SetPasteButtonEnable()
        {
            // �R�s�[�s�ԍ��擾����
            List<Guid> copyRowNoList = this._carMngListInputAcs.GetCopyCarInfoRowNo();

            if (copyRowNoList == null || copyRowNoList.Count == 0)
            {
                this.uButton_RowCopyAdd.Enabled = false;
            }
            else
            {
                this.uButton_RowCopyAdd.Enabled = true;
            }
        }
        #endregion

        #region �� �{�^���N���b�N�C�x���g
        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void tToolbarsManager_Main_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                //���p����
                case "ButtonTool_RowCopy":
                    {
                        this.uButton_RowCopy_Click(this.uButton_RowCopy, new EventArgs());
                        break;
                    }
                //���p�\�t
                case "ButtonTool_RowPaste":
                    {
                        this.uButton_RowCopyAdd_Click(this.uButton_RowCopyAdd, new EventArgs());
                        break;
                    }
                //�폜
                case "ButtonTool_RowDelete":
                    {
                        this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
                        break;
                    }
            }
        }

        /// <summary>
        /// ClickCellButton �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Z���{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uGrid_Details_ClickCellButton(object sender, CellEventArgs e)
        {
            int status;

            UltraGrid uGrid = (UltraGrid)sender;
            int rowIndex = e.Cell.Row.Index;
            int columnIndex = e.Cell.Column.Index;

            switch (e.Cell.Column.Key)
            {
                // ���Ӑ�K�C�h
                case column_CustomerCodeGuide:
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        CustomerSearchRet customerSearchRet;

                        status = ShowCustomerGuide(out customerSearchRet, PMKHN04005UA.SEARCHMODE_NORMAL);

                        if (status == 0)
                        {
                            uGrid.Rows[rowIndex].Cells[this._carInfoDataTable.CustomerCodeColumn.ColumnName].Value = customerSearchRet.CustomerCode.ToString();

                            // �t�H�[�J�X�ݒ�
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                    break;
                // �Ǘ��ԍ��K�C�h
                case column_CarMngCodeGuide:
                    // �Ȃ�
                    break;

                // ���^�������ԍ��K�C�h
                case column_NumberPlate1CodeGuide:
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        UserGdBd userGdBd = new UserGdBd();

                        status = ShowUserGuide(out userGdBd, 80);

                        if (status == 0)
                        {
                            uGrid.Rows[rowIndex].Cells[this._carInfoDataTable.NumberPlate1CodeColumn.ColumnName].Value = userGdBd.GuideCode.ToString();
                            //uGrid.Rows[rowIndex].Cells[this._carInfoDataTable.NumberPlate1NameColumn.ColumnName].Value = userGdBd.GuideName;
                            if (userGdBd.GuideName.Length>4)
                            {
                                uGrid.Rows[rowIndex].Cells[this._carInfoDataTable.NumberPlate1NameColumn.ColumnName].Value = userGdBd.GuideName.Substring(0, 4);
                            }
                            else
                            {
                                uGrid.Rows[rowIndex].Cells[this._carInfoDataTable.NumberPlate1NameColumn.ColumnName].Value = userGdBd.GuideName;
                            }
                           
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                    break;

                // ���l�K�C�h
                case column_CarNoteGuide:
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            NoteGuidBd noteGuidBd;

                            status = this.ShowNoteGuide(out noteGuidBd, ctDIVCODE_NoteGuideDivCd);

                            if (status == 0)
                            {
                                uGrid.Rows[rowIndex].Cells[this._carInfoDataTable.CarNoteColumn.ColumnName].Value = noteGuidBd.NoteGuideName;
                            }
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }
                        break;
                    }
            }

            // �s�P�ʂł̃Z��Color�ݒ�
            this.SetGridColorRow(uGrid.Rows[rowIndex]);
        }

        /// <summary>
        /// ���p���ʃ{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ���p���ʃ{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uButton_RowCopy_Click(object sender, EventArgs e)
        {
            this._carInfoDataTable.AcceptChanges();

            // �I���ςݍs�ԍ����X�g�擾����
            List<Guid> selectedStockRowNoList = this.GetSelectedRowNoList();
            if (selectedStockRowNoList == null) return;

            // --- UPD 2009/10/26 -------------------------------->>>>>
            //// �f�[�^�e�[�u��RowStatus��l�ݒ菈��
            //this._carMngListInputAcs.SetCarInfoRowStatusColumn(selectedStockRowNoList, CarMngListInputAcs.ROWSTATUS_COPY);
            // �R�s�[�s�ԍ��擾����
            List<Guid> myCopyRowNoList = this._carMngListInputAcs.GetCopyCarInfoRowNo();
            List<Guid> removeRowNoList = new List<Guid>();
            if (myCopyRowNoList != null)
            {
                for (int i = 0; i < selectedStockRowNoList.Count; i++)
                {
                    if (myCopyRowNoList.Contains(selectedStockRowNoList[i]))
                    {
                        //���p���ʂƂ��đI���ς݂̍s��I�����A�u���p���ʃ{�^���v���������ꍇ�A�I���s�̈��p���ʂ���������B
                        removeRowNoList.Add(selectedStockRowNoList[i]);
                    }
                }
            }
            if (selectedStockRowNoList.Count > 0)
            {
                // �f�[�^�e�[�u��RowStatus��l�ݒ菈��
                this._carMngListInputAcs.SetCarInfoRowStatusColumn(selectedStockRowNoList, CarMngListInputAcs.ROWSTATUS_COPY);
            }
            if (removeRowNoList != null && removeRowNoList.Count > 0)
            {
                this._carMngListInputAcs.SetCarInfoRowStatusColumn(removeRowNoList, CarMngListInputAcs.ROWSTATUS_NORMAL);
            }
            // --- UPD 2009/10/26 --------------------------------<<<<<
            // ���׃O���b�h�ݒ菈��
            this.SettingGrid();

            // �����͉\�Z���ړ�����
            this.MoveNextAllowEditCell(true);

            this.SetButtonEnable();
        }

        /// <summary>
        /// ���p�\�t�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ���p�\�t�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uButton_RowCopyAdd_Click(object sender, EventArgs e)
        {
            this._carInfoDataTable.AcceptChanges();

            // �R�s�[�s�ԍ��擾����
            List<Guid> copyRowNoList = this._carMngListInputAcs.GetCopyCarInfoRowNo();
            if (copyRowNoList == null) return;

            this._carMngListInputAcs.PasteInsertCarInfoRow(copyRowNoList);

            this._carMngListInputAcs.SetCarInfoRowStatusColumn(copyRowNoList, CarMngListInputAcs.ROWSTATUS_NORMAL);

            // ���׃O���b�h�Z���ݒ菈��
            this.SettingGrid();

            // �����͉\�Z���ړ�����
            this.MoveNextAllowEditCell(true);

            this.SetButtonEnable();

            // --- ADD 2009/10/21 MANTIS�F0014457 ------>>>>>
            _beforeSelectRowIndexList.Clear();
            foreach (UltraGridRow ultraGridRow in this.uGrid_Details.Selected.Rows)
            {
                this._beforeSelectRowIndexList.Add(ultraGridRow.Index);
            }
            // --- ADD 2009/10/21 MANTIS�F0014457 ------<<<<<
        }

        /// <summary>
        /// �폜�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �폜�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uButton_RowDelete_Click(object sender, EventArgs e)
        {
            this._carInfoDataTable.AcceptChanges();

            // �I���ςݍs�ԍ����X�g�擾����
            List<Guid> selectedRowNoList = this.GetSelectedRowNoList();
            if (selectedRowNoList == null) return;
            if (selectedRowNoList.Count <= 0) return;

            this.RowDelete(selectedRowNoList);

            this.SetButtonEnable();
        }
        #endregion

        #region �� �O���b�h�Z���X�V�C�x���g
        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
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
                            this.SetFocus("tEdit_CarMngCode");
                            break;
                        }
                    case Keys.Down:
                    case Keys.Right:
                        {
                            this.SetFocus("tNedit_CustomerCode_St");
                            break;
                        }
                    case Keys.Left:
                        {
                            this.SetFocus("Before_Grid");
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
                            //this.SetFocus("tEdit_CarMngCode");  // DEL 2009/10/10
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
                                            //this.SetFocus("tEdit_CarMngCode");  // DEL 2009/10/10
                                        }

                                        break;
                                    }
                                }
                            }

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
                                    //this.SetFocus("tEdit_CarMngCode");  // DEL 2009/10/10
                                }
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (rowIndex == uGrid.Rows.Count - 1)
                        {
                            e.Handled = true;
                            //this.SetFocus("tNedit_CustomerCode_St");  // DEL 2009/10/10
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
                                            //this.SetFocus("tNedit_CustomerCode_St");  // DEL 2009/10/10
                                        }

                                        break;
                                    }
                                }
                            }

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
                                    //this.SetFocus("tNedit_CustomerCode_St");  // DEL 2009/10/10
                                }
                            }
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
                                this.SetFocus("Before_Grid");
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
                                // ----- UPD 2009/10/10 -------->>>>>
                                // �O���b�g���̍��E���̃t�H�[�J�X�͉E�[�ƍ��[�Ŏ~�܂�悤�ɏC���B
                                if (nextFocusColumn.Equals("CarNoteGuide"))
                                {
                                    uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                
                            }
                            //else
                            //{
                            //    this.SetFocus("Before_Grid");
                            //}
                            // ----- UPD 2009/10/10 --------<<<<<
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
                                this.SetFocus("tNedit_CustomerCode_St");
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
                                // ----- UPD 2009/10/10 -------->>>>>
                                // �O���b�g���̍��E���̃t�H�[�J�X�͉E�[�ƍ��[�Ŏ~�܂�悤�ɏC���B
                                if ((nextFocusColumn.Equals("EngineModel")
                                    && activationRowIndex != rowIndex) || (nextFocusColumn.Equals("CustomerCode")))
                                {
                                    uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }

                            }
                            //else
                            //{
                            //    this.SetFocus("Before_Grid");
                            //}
                            // ----- UPD 2009/10/10 --------<<<<<
                        }

                        break;
                    }
                case Keys.Space:
                    {
                        uGrid_Details_ClickCellButton(this.uGrid_Details, new CellEventArgs(uGrid_Details.ActiveCell));
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// <br>UpdateNote  : 2016/12/13 ���R</br>
        /// <br>�Ǘ��ԍ�    : 11270098-00</br>
        /// <br>            : Redmine#48934 PMNS�i���o�[�v���[�g�p�����Ή�</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (cell.IsInEditMode)
            {
                // ���Ӑ�R�[�h
                if (cell.Column.Key == this._carInfoDataTable.CustomerCodeColumn.ColumnName)
                {
                    if (!KeyPressNumCheck(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // ���^�������ԍ�,�o�^�ԍ��i�v���[�g�ԍ��j
                if (cell.Column.Key == this._carInfoDataTable.NumberPlate1CodeColumn.ColumnName
                    || cell.Column.Key == this._carInfoDataTable.NumberPlate4Column.ColumnName)
                {
                    if (!KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // �o�^�ԍ��i��ʁj
                else if (cell.Column.Key == this._carInfoDataTable.NumberPlate2Column.ColumnName)
                {
                    //----- UPD 2016/12/13 ���R Redmine#48934 PMNS�i���o�[�v���[�g�p�����Ή� ----->>>>>
                    //if (!KeyPressNumCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    if (!KeyPressChrCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    //----- UPD 2016/12/13 ���R Redmine#48934 PMNS�i���o�[�v���[�g�p�����Ή� -----<<<<<
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // ���s����
                else if (cell.Column.Key == this._carInfoDataTable.MileageColumn.ColumnName)
                {
                    if (!KeyPressNumCheck(7, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // �Ԍ�����
                else if (cell.Column.Key == this._carInfoDataTable.CarInspectYearColumn.ColumnName)
                {
                    if (!KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else
                {
                    // UI�ݒ���Q��
                    if (this.uiSetControl1.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// �Z���A�N�e�B�u�O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Z���A�N�e�B�u�O���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            #region ���Z���ҏW�֘A
            // ���ڂɏ]��IME���[�h�ݒ�
            string cellKey = e.Cell.Column.Key;

            switch (cellKey)
            {
                // ���p
                case column_CustomerCode:
                case column_EngineModel:
                case column_NumberPlate1Code:
                case column_NumberPlate2:
                case column_NumberPlate4:
                case column_Mileage:
                case column_CarInspectYear:
                case column_EntryDate:
                case column_LTimeCiMatDate:
                case column_InspectMaturityDate:
                    {
                        // IME���N�����Ȃ�
                        this.uGrid_Details.ImeMode = ImeMode.Disable;
                        break;
                    }
                case column_NumberPlate3:
                case column_CarNote:
                    {
                        this.uGrid_Details.ImeMode = ImeMode.Hiragana;
                        break;
                    }
                // ��
                case column_CarAddInfo1:
                case column_CarAddInfo2:
                    {
                        this.uGrid_Details.ImeMode = ImeMode.KatakanaHalf;
                        break;
                    }
                case column_CarMngCode:
                    {
                        this.uGrid_Details.ImeMode = ImeMode.Close;
                        break;
                    }
                default:
                    {
                        this.uGrid_Details.ImeMode = ImeMode.NoControl;
                        break;
                    }
            }

            // �[���l�߉������s
            if (e.Cell.Column.DataType == typeof(string) &&
                e.Cell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
            {
                if (e.Cell.Value != DBNull.Value)
                {
                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value =
                        this.uiSetControl1.GetZeroPadCanceledText(e.Cell.Column.Key,
                        (string)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value);
                }
            }
            #endregion

            #region ���ҏW�O���ڒl�ۑ�
            switch (e.Cell.Column.Key)
            {
                // ���Ӑ�R�[�h
                case column_CustomerCode:
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpCustomerCode = string.Empty;
                        }
                        else
                        {
                            this._tmpCustomerCode = e.Cell.Value.ToString();
                        }
                        break;
                    }
                // �Ǘ��ԍ�
                case column_CarMngCode:
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpCarMngCode = string.Empty;
                        }
                        else
                        {
                            this._tmpCarMngCode = e.Cell.Value.ToString();
                        }
                        break;
                    }
                // ���^�������ԍ�
                case column_NumberPlate1Code:
                    {
                        if (e.Cell.Value == null || e.Cell.Value == DBNull.Value)
                        {
                            this._tmpNumberPlate1Code = string.Empty;
                        }
                        else
                        {
                            this._tmpNumberPlate1Code = e.Cell.Value.ToString();
                        }
                        break;
                    }
            #endregion
            }
        }

        /// <summary>
        /// AfterCellUpdate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Z���̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            switch (e.Cell.Column.Key)
            {
                // ���Ӑ�R�[�h
                case column_CustomerCode:
                    {
                        this._canMove = true;
                        string code;
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_CustomerCode].Value != DBNull.Value
                            && !string.Empty.Equals(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_CustomerCode].Value.ToString()))
                        {
                            code = (string)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_CustomerCode].Value;
                        }
                        else
                        {
                            return;
                        }

                        if (!this._carMngListInputAcs.CustomerSearchRetDic.ContainsKey(this._carMngListInputAcs.StrObjToInt(code)))
                        {
                            this._canMove = false;
                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "���Ӑ悪���݂��܂���B",                           // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_CustomerCode].Value =
                                    this._carMngListInputAcs.StrPadLeft0(this._tmpCustomerCode, 8);
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }
                        else
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_CustomerCode].Value =
                                    this._carMngListInputAcs.StrPadLeft0(code, 8);
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;

                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells["SaveCanFlag"].Value = 1; // 2009/10/26 ADD
                        }

                        break;
                    }
                // �Ǘ��ԍ�
                case column_CarMngCode:
                    {
                        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells["SaveCanFlag"].Value = 1; // 2009/10/26 ADD
                        break;
                    }
                // �����@�^��
                case column_EngineModel:
                    {
                        break;
                    }
                // ���^�������ԍ�
                case column_NumberPlate1Code:
                    {
                        this._canMove = true;
                        string code;
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Code].Value != DBNull.Value)
                        {
                            code = (string)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Code].Value;
                        }
                        else
                        {
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Name].Value = string.Empty;
                            return;
                        }

                        if (this._carMngListInputAcs.NumberPlate1CodeDic.ContainsKey(this._carMngListInputAcs.StrObjToInt(code)))
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Code].Value = this._carMngListInputAcs.StrPadLeft0(code, 4);
                            string NumberPlate1Name = this._carMngListInputAcs.NumberPlate1CodeDic[this._carMngListInputAcs.StrObjToInt(code)].GuideName.Trim();
                            //this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Name].Value = NumberPlate1Name;
                            if (NumberPlate1Name.Length>4)
                            {
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Name].Value = NumberPlate1Name.Substring(0,4);// ADD 2009/10/10
                            }
                            else
                            {
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Name].Value = NumberPlate1Name;
                            }
                            
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }
                        else
                        {
                            this._canMove = false;
                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "���^�������R�[�h�����݂��܂���B",                 // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��

                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_NumberPlate1Code].Value = this._tmpNumberPlate1Code;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }

                        break;
                    }
                // ���s����
                case column_Mileage:
                    {
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_Mileage].Value == DBNull.Value)
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_Mileage].Value = 0;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }
                        break;
                    }

                // �Ԍ�����
                case column_CarInspectYear:
                    {
                        if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_CarInspectYear].Value == DBNull.Value)
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[column_CarInspectYear].Value = 0;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// CellChange �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Z���̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// <br>UpdateNote  : 2016/12/13 ���R</br>
        /// <br>�Ǘ��ԍ�    : 11270098-00</br>
        /// <br>            : Redmine#48934 PMNS�i���o�[�v���[�g�p�����Ή�</br>
        /// </remarks>
        private void uGrid_Details_CellChange(object sender, CellEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            switch (e.Cell.Column.Key)
            {
                //----- UPD 2016/12/13 ���R Redmine#48934 PMNS�i���o�[�v���[�g�p�����Ή� ----->>>>>
                //// ���Ӑ�R�[�h
                //case column_CustomerCode:
                //// �o�^�ԍ��i��ʁj
                //case column_NumberPlate2:
                // �o�^�ԍ��i��ʁj
                case column_NumberPlate2:
                    {
                        // ���p�p�����̂ݓ��͉\
                        string value = cell.Text;

                        Regex r = new Regex(@"^[a-z��-��A-Z�`-�y0-9�O-�X]+(\.)?[a-z��-��A-Z�`-�y0-9�O-�X]*$");

                        if ((!String.IsNullOrEmpty(value)) && !r.IsMatch(value))
                        {
                            cell.Value = string.Empty;
                        }

                        break;
                    }
                // ���Ӑ�R�[�h
                case column_CustomerCode:
                //----- UPD 2016/12/13 ���R Redmine#48934 PMNS�i���o�[�v���[�g�p�����Ή� -----<<<<<
                // �o�^�ԍ��i�v���[�g�ԍ��j
                case column_NumberPlate4:
                    {
                        // ���p�����̂ݓ��͉\
                        string value = cell.Text;

                        Regex r = new Regex(@"^\d+(\.)?\d*$");

                        if ((!String.IsNullOrEmpty(value)) && !r.IsMatch(value))
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            cell.Value = string.Empty;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }

                        break;
                    }
                // �o�^�ԍ��i�J�i�j
                case column_NumberPlate3:
                    {
                        // �S�p�����̂ݓ��͉\
                        string value = cell.Text;


                        // �S�p�����𔻒f����
                        bool isKana = true;
                        for (int i = 0; i < value.Length; i++)
                        {
                            String cutStr = value.Substring(i, 1);
                            if (ASCIIEncoding.Default.GetByteCount(cutStr) == 1)
                            {
                                isKana = false;
                                break;
                            }
                        }

                        // ���p������̏ꍇ�A�N���A����
                        if (!isKana)
                        {
                            cell.Value = string.Empty;
                        }
                        break;
                    }
                // �Ǘ��ԍ�
                case column_CarMngCode:
                // �����@�^��
                case column_EngineModel:
                    {
                        // ���p�̂ݓ��͉\
                        string value = cell.Text;

                        // ���p�𔻒f����
                        bool isHalfKana = true;
                        for (int i = 0; i < value.Length; i++)
                        {
                            String cutStr = value.Substring(i, 1);
                            if (ASCIIEncoding.Default.GetByteCount(cutStr) == 2)
                            {
                                isHalfKana = false;
                                break;
                            }
                        }

                        // ���p������̏ꍇ�A�N���A����
                        if (!isHalfKana)
                        {
                            cell.Value = string.Empty;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �I���s�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �I���s�ύX���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void uGrid_Details_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // �O�A�N�e�B�u�s�̐ݒ�
            if (this._beforeSelectRowIndexList.Count != 0)
            {
                foreach (int rowIndex in this._beforeSelectRowIndexList)
                {
                    if (rowIndex <= this.uGrid_Details.Rows.Count - 1)
                    {
                        this.SetGridColorRow(this.uGrid_Details.Rows[rowIndex]);
                    }
                }

                this._beforeSelectRowIndexList.Clear();
            }

            // BeforeRowDeactivate����ړ�
            foreach (UltraGridRow ultraGridRow in this.uGrid_Details.Selected.Rows)
            {
                this._beforeSelectRowIndexList.Add(ultraGridRow.Index);
            }

            // �I���s�̔w�i�F�ݒ�
            if (this.uGrid_Details.Selected.Rows.Count != 0)
            {
                foreach (UltraGridRow ultraGr in this.uGrid_Details.Selected.Rows)
                {
                    this.SetGridColorRow(ultraGr);
                }
            }
            if (this.uGrid_Details.ActiveCell != null)
            {
                this.SetGridColorRow(this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index]);
            }

            // �{�^������L������
            this.SetButtonEnable();

        }

        /// <summary>
        /// �O���b�h�}�E�X�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�}�E�X�N���b�N�ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// <br>Update Note : ����� 2010/06/08 ��Q���ǑΉ��i�V�����j</br>
        /// <br>            : �Ǘ��ԍ��I�����̕s��C��</br>
        /// </remarks>
        private void uGrid_Details_MouseClick(object sender, MouseEventArgs e)
        {
            // --- ADD 2010/06/08 ---------->>>>>
            if (e.Button == MouseButtons.Left)
            {
                Point lastMouseDown = new Point(e.X, e.Y);
                // UIElement�𗘗p���č��W�ʒu�̃R���g���[�����擾
                UIElement element = this.uGrid_Details.DisplayLayout.UIElement.ElementFromPoint(lastMouseDown);
                // �N���b�N�����ʒu��GridRow�̏ꍇ�̂ݏ������s��
                UltraGridRow ultraRow = element.GetContext(typeof(UltraGridRow)) as UltraGridRow;

                if (ultraRow != null && (string)ultraRow.Cells[this._carInfoDataTable.RowNoColumn.ColumnName].Value != CarMngListInputAcs.ROWNO_NEW)
                {
                    this.uGrid_Details.AfterSelectChange -= new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.uGrid_Details_AfterSelectChange);
                    this.uGrid_Details.Selected.Rows.Clear();
                    this.uGrid_Details.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.uGrid_Details_AfterSelectChange);
                    ultraRow.Activated = true;
                    ultraRow.Selected = true;
                }
            }
            // --- ADD 2010/06/08 ----------<<<<<

            // �E�N���b�N�ȊO�̏ꍇ
            if (e.Button != MouseButtons.Right) return;
            if (this.uGrid_Details.ActiveRow == null) return;

            System.Drawing.Point nowPos = new Point(e.X, e.Y);

            Infragistics.Win.UIElement objElement = this.uGrid_Details.DisplayLayout.UIElement.ElementFromPoint(nowPos);

            // �N���b�N�ʒu����w�b�_�[������
            bool isColumnHeader = false;

            if (objElement != null)
            {
                if ((objElement.SelectableItem is Infragistics.Win.UltraWinGrid.ColumnHeader) ||
                    (objElement is Infragistics.Win.UltraWinGrid.HeaderUIElement))
                {
                    isColumnHeader = true;
                }
            }

            if (isColumnHeader)
            {
                // ��w�b�_�[�E�N���b�N���͉������Ȃ�
            }
            else
            {
                // ����ȊO�ŉE�N���b�N���ꂽ�ꍇ�́A�ҏW�̃|�b�v�A�b�v��\������
                ((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Edit"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_Details);

                if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow != null))
                {
                    if (this.uGrid_Details.ActiveRow.Selected)
                    {
                        //
                    }
                    else
                    {
                        this.uGrid_Details.Selected.Rows.Clear();
                        this.uGrid_Details.ActiveRow.Selected = true;
                    }
                }
            }
            
        }

        /// <summary>
        /// �O���b�h�}�E�XDoule�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�}�E�XDoule�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uGrid_Details_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            // ActiveRow��null�ꍇ�A�������Ȃ�
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            // ActiveRow�s
            UltraGridRow row = this.uGrid_Details.ActiveRow;

            // �V�K�s�ꍇ�A�������Ȃ�
            if ((string)row.Cells[column_No].Value == CarMngListInputAcs.ROWNO_NEW)
            {
                return;
            }

            this.uGrid_Details.Selected.Rows.Clear();
            this.uGrid_Details.ActiveRow.Selected = true;

            // �f�[�^���͉�ʂ��N��
            this.StartInPut((Guid)row.Cells[column_CarRelationGuid].Value);
        }

        /// <summary>
        /// BeforeCellDeactivate�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : �Z���A�N�e�B�u�㎞�ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            // --- ADD 2009/10/26 ----->>>>>
            if (!_chooseFlg)
            {
                _chooseFlg = true;
            }
            // --- ADD 2009/10/26 -----<<<<<
            if (this.uGrid_Details.ActiveCell != null)
            {
                // �w�i�F�ݒ�
                this.SetGridColorRow(this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index]);
            }
        }

        /// <summary>
        /// AfterExitEditMode�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : �Z���ҏW�㎞�ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            switch (cell.Column.Key)
            {
                // ���Ӑ�R�[�h
                case column_CustomerCode:
                    {
                        this._canMove = true;
                        if (this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CustomerCode].Value != DBNull.Value &&
                            (string)this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CustomerCode].Text != string.Empty
                            && this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CarMngCode].Value != DBNull.Value &&
                            (string)this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CarMngCode].Text != string.Empty
                            && (int)this.uGrid_Details.Rows[cell.Row.Index].Cells["SaveCanFlag"].Value == 1  // 2009/10/26 add
                            && cell.Activation.Equals(Activation.AllowEdit))
                        {
                            // ���q�Ǘ��}�X�^�`�F�b�N����
                            this.CarManagementCheck(this.uGrid_Details.Rows[cell.Row.Index]);
                            if(!_chooseFlg)
                            {
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CustomerCode].Value = this._tmpCustomerCode;
                            }
                        }
                        break;
                    }
                // �Ǘ��ԍ�
                case column_CarMngCode:
                    {
                        this._canMove = true;
                        if (this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CustomerCode].Value != DBNull.Value &&
                            (string)this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CustomerCode].Text != string.Empty
                            && this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CarMngCode].Value != DBNull.Value &&
                            (string)this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CarMngCode].Text != string.Empty
                            && (int)this.uGrid_Details.Rows[cell.Row.Index].Cells["SaveCanFlag"].Value == 1  // 2009/10/26 add
                            && cell.Activation.Equals(Activation.AllowEdit))
                        {
                            // ���q�Ǘ��}�X�^�`�F�b�N����
                            this.CarManagementCheck(this.uGrid_Details.Rows[cell.Row.Index]);
                            if (!_chooseFlg)
                            {
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[column_CarMngCode].Value = this._tmpCarMngCode;
                            }
                        }
                        break;
                    }
            }
            
        }
        #endregion

        #region �� �{�^������֘A�C�x���g
        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : Leave���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void PMSYA09021UB_Leave(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveCell = null;
            this.uGrid_Details.ActiveRow = null;
            this.uGrid_Details.Selected.Rows.Clear();

            // �{�^����s�ɂ���
            this.SetButtonEnable();

            this.SettingGrid();
        }
        #endregion

        // --- ADD 2009/10/21 MANTIS�F0014457 ------>>>>>
        /// <summary>
        /// �\�[�g�ύX��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �\�[�g�ύX��C�x���g�C�x���g���s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2009/10/21</br>
        /// </remarks>
        private void uGrid_Details_AfterSortChange(object sender, BandEventArgs e)
        {
            _beforeSelectRowIndexList.Clear();
            foreach (UltraGridRow ultraGridRow in this.uGrid_Details.Selected.Rows)
            {
                if (ultraGridRow.Index == -1) return;
                this._beforeSelectRowIndexList.Add(ultraGridRow.Index);
            }

            foreach (UltraGridRow gridRow in this.uGrid_Details.Rows)
            {
                if (gridRow.Selected)
                {
                    // �I���s�̏ꍇ
                    foreach (UltraGridCell cell in gridRow.Cells)
                    {
                        if (cell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
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
                    if (gridRow.Index % 2 == 0)
                    {
                        foreach (UltraGridCell ultraCell in gridRow.Cells)
                        {
                            if (ultraCell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
                            {
                                if (ultraCell.Appearance.BackColor == Color.White
                                    || ultraCell.Appearance.BackColor == Color.Lavender)
                                {
                                    ultraCell.Appearance.BackColor = Color.White;
                                    ultraCell.Appearance.BackColor2 = Color.White;
                                    ultraCell.Appearance.BackColorDisabled = Color.White;
                                    ultraCell.Appearance.BackColorDisabled2 = Color.White;
                                }
                                else
                                {
                                    continue;
                                }
                                
                            }
                        }
                    }
                    else
                    {
                        foreach (UltraGridCell ultraCell in gridRow.Cells)
                        {
                            if (ultraCell.Column.Key != this._carInfoDataTable.RowNoColumn.ColumnName)
                            {
                                if (ultraCell.Appearance.BackColor == Color.White
                                    || ultraCell.Appearance.BackColor == Color.Lavender)
                                {
                                    ultraCell.Appearance.BackColor = Color.Lavender;
                                    ultraCell.Appearance.BackColor2 = Color.Lavender;
                                    ultraCell.Appearance.BackColorDisabled = Color.Lavender;
                                    ultraCell.Appearance.BackColorDisabled2 = Color.Lavender;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }

                }
            }

        }
        // --- ADD 2009/10/21 MANTIS�F0014457 ------<<<<<
        #endregion
    }
}
