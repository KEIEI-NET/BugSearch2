//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������i�ݒ�}�X�^
// �v���O�����T�v   : ���������i�ݒ�}�X�^���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �� �� ��  2015/02/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/03  �C�����e : RedMine#309 �i�ԓ��͌�A�ʂ̕i�Ԃ���͂����
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�u���i�����݂��܂���v�Əo�ĕύX�ł��Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/04  �C�����e : RedMine#319 ���P���Ɋ|���}�X�^�̋��_���Ƃ̐ݒ肪�K�p����Ȃ�
//                                  RedMine#320 ���P���ɃL�����y�[���}�X�^�̋��_���Ƃ̐ݒ肪�K�p����Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/10  �C�����e : RedMine#351 ���P���̌����ɐ������������Ă��Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : ���I ���
// �X �V ��  2015/03/13  �C�����e : ���P����K�{���͂ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/16  �C�����e : ��Q �����\�����Ɍ��J�敪��OFF�̏ꍇ�A���ڂ��񊈐��ɂȂ�Ȃ�
//                                       �܂��s�ړ��������l
//                                  �v�] ���J�敪��OFF�ɂ����ꍇ�ɔ񊈐����ڂ̒l���N���A���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/23  �C�����e : �i��Redmine#3158 �ۑ�Ǘ��\��37
//                                  ���J�敪�`�F�b�N���͂�������Ԃł���Ή��o�^�ł���悤�ɑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/24  �C�����e : �i��Redmine#3093 �ۑ�Ǘ��\��35
//                                  ���[�J�[��]���i�E�W�����i�̍Čv�Z�@�\����������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/25  �C�����e : ���[�J�[���i�擾���@�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/26  �C�����e : �i��Redmine#3247
//                                  PM���i�}�X�^(���[�U�[�o�^)����擾�������[�J�[���i�ɑ΂��ė����ݒ肪���f�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{ ����
// �X �V ��  2015/03/31  �C�����e : �V�X�e���e�X�g��Q ��61
//                                  ���i�Ď擾��Ƀv���r���[���X�V����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/04/01  �C�����e : �V�X�e���e�X�g��Q ��63
//                                  ���J�敪�`�F�b�N�Ȃ��ŕۑ�����ꍇ�A���[�J�[���i�����ݒ�̂܂ܕۑ������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/04/02  �C�����e : �V�X�e���e�X�g��Q ��65
//                                  ���i�Ď擾��ɓ��Ӑ�ʐݒ����͂��Ă����[�J�[���i���ύX�O�̂܂�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/04/08  �C�����e : �i��Redmine#3452
//                                  �s�폜�{�^���������ēx�s�폜�{�^���������������ɖ��ׂ̕\���F�����ɖ߂�Ȃ�
//                                  �i�S�폜�{�^�������������l�j
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Globalization; // ���t�`�F�b�N
using System.Diagnostics;

using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���������i�ݒ�}�X�^ ���׃R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���������i�ݒ�}�X�^ ���׃R���g���[���N���X</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2015/02/20</br>
    /// </remarks>
    public partial class PMREC09021UB : UserControl
    {
        # region Private Members
        private RecBgnGdsDataSet.RecBgnGdsDataTable _recBgnGdsDataTable;
        private RecBgnGdsDataSet.SecCusSetDataTable _secCusSetDataTable;
      
        private RecBgnGdsAcs _recBgnGdsAcs = null;
        private Calculator _calculator = null;

        private Dictionary<Guid, RecBgnGds> _prevRecBgnGdsDic = new Dictionary<Guid, RecBgnGds>();
        private ButtonTextCustomizableMessageBox _imageMsg = new ButtonTextCustomizableMessageBox();

        private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

        private const string TOOLBAR_ROWDELETEBUTTON_KEY = "ButtonTool_RowDelete";						// �s�폜
        private const string TOOLBAR_ALLDELETEBUTTON_KEY = "ButtonTool_AllRowDelete";					// �S�폜
        private const string TOOLBAR_REVIVALBUTTON_KEY = "ButtonTool_Revival";						    // ����
        private const string TOOLBAR_RECAPTUREBUTTON_KEY = "ButtonTool_Recapture";						// ���i�Ď擾 // ADD 2015/03/24 Y.Wakita

        /// <summary>�S�Аݒ�</summary>
        private const string ALL_SECTION_CODE = "00";
        private const string ALL_SECTION_NAME = "�S�Ћ���";

        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "PMREC09020U_Construction.XML";

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;
        private string _loginSectionCode = string.Empty;

        /// <summary>���_�R�[�h</summary>
        private string _swSectionInfo = string.Empty;

        /// <summary>�i��</summary>
        private string _swGoodsNo = string.Empty;

        /// <summary>���Ӑ�</summary>
        private string _swCustomerInfo = string.Empty;

        /// <summary>���[�J�[�R�[�h</summary>
        private int _swGoodsMakerCd = 0;

        /// <summary>���������i��ٰ�߃R�[�h</summary>
        private int _swBrgnGoodsGrpCode = 0;

        /// <summary>���J�J�n��</summary>
        private string _swApplyStaDate = string.Empty;

        /// <summary>���J�I����</summary>
        private string _swApplyEndDate = string.Empty;
        
        private CustomerSearchRet _customerSearchRet = null;

        /// <summary>DCKHN09092A)BL�R�[�h</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;

        /// <summary> SCM��ƘA���f�[�^�A�N�Z�X�N���X </summary>
        private ScmEpScCntAcs _scmEpScCntAcs;

        /// <summary> ���_�}�X�^���X�g </summary>
        private List<SecInfoSet> _secInfoSetList;
        /// <summary> ���������i�O���[�v��������</summary>
        private RecBgnGrpRet _recBgnGrpRet = null;

        private bool focusFlg = true;
        private bool leftFocusFlg = false;

        private int _rowIndex = 0;

        // ���[�U�[�ݒ�
        private RecBgnGdsUserSet _userSetting;
        private SecInfoSetAcs _secInfoSetAcs;
        private MakerAcs _makerAcs;
        private BLGroupUAcs _blGroupUAcs;
        private UserGuideAcs _userGuideAcs;
        internal event SetGuidButtonEventHandler SetGuidButton;
        internal delegate void SetGuidButtonEventHandler(Boolean enable);

        internal event GetBaseInfoEventHandler GetBaseInfo;
        internal delegate void GetBaseInfoEventHandler(out string sectionCode, out string sectionName);

        internal event OpenGoodsImgFileEventHandler OpenGoodsImgFile;
        internal delegate void OpenGoodsImgFileEventHandler(out Byte[] dats);

        internal event GoodsInfoPreviewEventHandler GoodsInfoPreview;
        internal delegate void GoodsInfoPreviewEventHandler(int rowIndex);

        internal event PreviewColumnSyncEventHandler PreviewColumnSync;
        internal delegate void PreviewColumnSyncEventHandler(int rowIndex, string columnKeyName);

        internal event GoodsInfoPreviewClearEventHandler GoodsInfoPreviewClear;
        internal delegate void GoodsInfoPreviewClearEventHandler();

        /// <summary>�t�H�[�J�X�̕ω�</summary>
        internal event EventHandler GridKeyUpTopRow;

        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string GOODSIMG_FILE_TRUE = "�L";
        #endregion

        #region �v���p�e�B
        /// <summary>
        /// ���������i�ݒ�}�X�^ �A�N�Z�X�N���X�v���p�e�B
        /// </summary>
        public RecBgnGdsAcs RecBgnGdsAcs
        {
            get { return this._recBgnGdsAcs; }
        }

        /// <summary>
        /// ���������i�ݒ�}�X�^ ���i�Z�o�A�N�Z�X�N���X�v���p�e�B
        /// </summary>
        public Calculator Calculator
        {
            get { return this._calculator; }
        }

        /// <summary>
        /// ���ו��Ƀt�H�[�J�X����v���p�e�B
        /// </summary>
        public Boolean FocusFlg
        {
            get { return this.focusFlg; }
        }

        /// <summary>
        /// ���ו��Ƀt�H�[�J�X����v���p�e�B
        /// </summary>
        public Boolean LeftFocusFlg
        {
            set { this.leftFocusFlg = value; }
        }

        /// <summary>
        /// ���[�U�̃v���p�e�B
        /// </summary>
        public RecBgnGdsUserSet UserSetting
        {
            get { return this._userSetting; }
        }

        /// <summary>
        /// RowIndex
        /// </summary>
        public int RowIndex
        {
            get { return this._rowIndex; }
        }

        /// <summary>
        /// SetBrgnGoodsGrpCode
        /// </summary>
        public int SetBrgnGoodsGrpCode
        {
            set { this._swBrgnGoodsGrpCode = value; }
        }

        /// <summary>
        /// SetApplyStaDate
        /// </summary>
        public string SetApplyStaDate
        {
            set { this._swApplyStaDate = value; }
        }

        /// <summary>
        /// SetApplyEndDate
        /// </summary>
        public string SetApplyEndDate
        {
            set { this._swApplyEndDate = value; }
        }

        #endregion

        # region Constroctors
        /// <summary>
        /// ���͖��ד��̓R���g���[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���͖��ד��̓R���g���[���N���X �f�t�H���g���s���R���g���[���N���X�ł��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public PMREC09021UB()
        {
            InitializeComponent();

            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._recBgnGdsAcs = new RecBgnGdsAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._makerAcs = new MakerAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._userSetting = new RecBgnGdsUserSet();
            this._scmEpScCntAcs = new ScmEpScCntAcs();
            this._secInfoSetList = new List<SecInfoSet>();
            this._secCusSetDataTable = new RecBgnGdsDataSet.SecCusSetDataTable();
            this._calculator = new Calculator();

            this._recBgnGdsDataTable = this._recBgnGdsAcs.RecBgnGdsDataTable;

        }
        #endregion

        #region �C�x���g
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note	   : �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void PMREC09021UB_Load(object sender, EventArgs e)
        {
            // �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
            this.uGrid_Details.DataSource = this._recBgnGdsAcs.RecBgnGdsDataTable;

            // �O���b�h�N���A
            this.Clear(false);

            #region �q��ʗp�ǉ�
            // ���_���̃L���b�V��
            ArrayList list = new ArrayList();
            this._secInfoSetAcs.Search(out list, this._enterpriseCode);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetType().Equals(typeof(SecInfoSet)))
                {
                    this._secInfoSetList.Add((SecInfoSet)list[i]);
                }
            }
            #endregion
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note	   : �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �s�폜
                case TOOLBAR_ROWDELETEBUTTON_KEY:
                    {
                        this.uButton_RowDelete_Click(sender, new EventArgs());
                        break;
                    }
                // �S�폜
                case TOOLBAR_ALLDELETEBUTTON_KEY:
                    {
                        this.uButton_AllRowDelete_Click(sender, new EventArgs());
                        break;
                    }
                // ����
                case TOOLBAR_REVIVALBUTTON_KEY:
                    {
                        this.uButton_Revival_Click(sender, new EventArgs());
                        break;
                    }
                // --- ADD 2015/03/24 Y.Wakita ---------->>>>>
                // ���i�Ď擾
                case TOOLBAR_RECAPTUREBUTTON_KEY:
                    {
                        this.uButton_Recapture_Click(sender, new EventArgs());
                        break;
                    }
                // --- ADD 2015/03/24 Y.Wakita ----------<<<<<
            }
        }

        /// <summary>
        /// ���׏������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note	   : ���׏������C�x���g���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.uGrid_Details.BeginUpdate();

            // �O���b�h�񏉊��ݒ菈��
            this.InitialSettingGridCol();

            this.uGrid_Details.EndUpdate();
        }

        /// <summary>
        /// �s�폜����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �s�폜�������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uButton_RowDelete_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.WaitCursor;

                this.uGrid_Details.BeginUpdate();

                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    if (row.Selected || row.IsActiveRow)
                    {
                        if ((int)row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                        {
                            //�폜�w��敪:0
                            if (this._recBgnGdsAcs.DeleteSearchMode == false)
                            {
                                //if (row.Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activation != Activation.NoEdit)
                                //{
                                //    // ���m��̐V�K�s�̓N���A����
                                //    this.NewRowClear(this.uGrid_Details.ActiveRow.Index);
                                //    break;
                                //}
                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                                    this.SetGuidButton(false);
                                }

                                // �s�폜��BackColor�̐ݒ�(�s���N�F)�A���͋��ݒ�
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName) // �F�͍s�ԍ���̂�
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    cell.Activation = Activation.NoEdit;

                                    if (cell.Column.Key == this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName ||
                                        cell.Column.Key == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                                    {
                                        cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                                    }
                                }
                                row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                            }
                            //�폜�w��敪:1
                            else
                            {
                                // �s�폜��BackColor�̐ݒ�(�s���N�F)�A���͋��ݒ�
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName) // �F�͍s�ԍ���̂�
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                }
                                row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                            }
                        }
                        else
                        {
                            //�폜�w��敪:0
                            if (this._recBgnGdsAcs.DeleteSearchMode == false)
                            {
                                #region �s�폜����
                                // �V�K�s�̔��f
                                bool isNewRow = false;
                                if ((Guid)row.Cells[this._recBgnGdsDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                                {
                                    isNewRow = true;
                                }

                                #region ���͋��ݒ�
                                row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Activation = Activation.AllowEdit;           // �i��
                                row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit;        // ���i����
                                row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button; ;       // ���i�C���[�W
                                row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Activation = Activation.AllowEdit;                               // ���i�C���[�W
                                row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activation = Activation.AllowEdit;        // ���J�J�n��
                                row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Activation = Activation.AllowEdit;        // ���J�I����
                                row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Activation = Activation.AllowEdit;      // ���J�敪
                                // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                                if (row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Text != "0")
                                {
                                    // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                                    row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.AllowEdit;    // ���������i��ٰ��
                                    row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;        // ������
                                    row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.AllowEdit;           // ���P��
                                    // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                                }
                                // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                                row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;   // ���Ӑ�ʐݒ�
                                row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Activation = Activation.AllowEdit;                          // ���Ӑ�ʐݒ�
                                if (isNewRow == true)
                                {
                                    row.Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;   // ���_
                                    row.Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activation = Activation.AllowEdit;         // �i��
                                    row.Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;  // ���[�J�[
                                }
                                #endregion

                                // �s�폜������BackColor�̐ݒ�(�ʏ�F)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Activation == Activation.NoEdit
                                     && cell.Column.Key != this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                                    {
                                        // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                                        if ((Guid)row.Cells[this._recBgnGdsDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                                        {
                                            // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                                            cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                            cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                            cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                            cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                            // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                                        }
                                        else
                                        {
                                            cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                            cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                                            cell.Appearance.BackColorDisabled = ct_DISABLE_COLOR;
                                            cell.Appearance.BackColorDisabled2 = ct_DISABLE_COLOR;
                                        }
                                        // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    //cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }

                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    this.uGrid_Details.ActiveCell.Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    if ((this.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName)
                                     || (this.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
                                     || (this.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName))
                                        {
                                        if (this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                                        {
                                            this.SetGuidButton(true);
                                        }
                                        else
                                        {
                                            this.SetGuidButton(false);
                                        }
                                    }
                                    else
                                    {
                                        this.SetGuidButton(false);
                                    }
                                }
                                row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                                #endregion
                            }
                            //�폜�w��敪:1
                            else
                            {
                                #region �s�폜����
                                // �s�폜������BackColor�̐ݒ�(DiabledColor)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    cell.Appearance.BackColor = Color.Gainsboro;
                                    cell.Appearance.BackColor2 = Color.Gainsboro;
                                    cell.Appearance.BackColorDisabled = Color.Gainsboro;
                                    cell.Appearance.BackColorDisabled2 = Color.Gainsboro;
                                    cell.Appearance.ForeColor = Color.Empty;
                                    cell.Appearance.ForeColorDisabled = Color.Empty;
                                    if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                                row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                                #endregion
                            }
                        }
                    }
                }

                this.uGrid_Details.EndUpdate();
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �V�K�s�̍s�폜�i�N���A�j
        /// </summary>
        private void NewRowClear(int ActiveRowIndex)
        {
            DialogResult dialogResult = TMsgDisp.Show(this
                                                     , emErrorLevel.ERR_LEVEL_QUESTION
                                                     , this.Name
                                                     , "���ׂ��N���A���Ă���낵���ł����H"
                                                     , 0
                                                     , MessageBoxButtons.YesNo
                                                     , MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.Yes)
            {
                //�s�N���A
                RecBgnGdsDataSet.RecBgnGdsRow row = (RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[ActiveRowIndex];
                this._recBgnGdsDataTable.Rows.Remove(row);
                this.NewRowAdd();
            }
        }


        /// <summary>
        /// �S�폜����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �S�폜�������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uButton_AllRowDelete_Click(object sender, EventArgs e)
        {
            bool isAllDelete = true;
            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.WaitCursor;

                this.uGrid_Details.BeginUpdate();

                //�폜�w��敪:0
                if (this._recBgnGdsAcs.DeleteSearchMode == false)
                {
                    for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                    {
                        if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value == 0)
                        {
                            isAllDelete = false;
                            break;
                        }
                    }

                    if (isAllDelete == true)
                    {
                        #region ���͋��ݒ�
                        bool isNewRow = false;
                        foreach (UltraGridRow row in this.uGrid_Details.Rows)
                        {
                            if ((Guid)row.Cells[this._recBgnGdsDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                            {
                                isNewRow = true;
                            }
                            // --- DEL 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                            //if (isNewRow == true)
                            //{
                            //    row.Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;       // ���_
                            //    row.Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activation = Activation.AllowEdit;             // �i��
                            //    row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Activation = Activation.AllowEdit;           // �i��
                            //    row.Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;      // Ұ��
                            //    row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit;        // ���i����
                            //    row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Activation = Activation.AllowEdit;       // ���i�Ұ����а
                            //    row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.AllowEdit;    // ���������i��ٰ��
                            //    row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Activation = Activation.AllowEdit;      // �\���敪
                            //    row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activation = Activation.AllowEdit;        // ���J�J�n��
                            //    row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Activation = Activation.AllowEdit;        // ���J�I����
                            //    row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;        // ������
                            //    row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.AllowEdit;           // ���P��
                            //}
                            // --- DEL 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                            // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                            row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Activation = Activation.AllowEdit;           // �i��
                            row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit;        // ���i����
                            row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button; ;       // ���i�C���[�W
                            row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Activation = Activation.AllowEdit;                               // ���i�C���[�W
                            row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activation = Activation.AllowEdit;        // ���J�J�n��
                            row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Activation = Activation.AllowEdit;        // ���J�I����
                            row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Activation = Activation.AllowEdit;      // ���J�敪
                            if (row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Text != "0")
                            {
                                row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.AllowEdit;    // ���������i��ٰ��
                                row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;        // ������
                                row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.AllowEdit;           // ���P��
                            }
                            row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;   // ���Ӑ�ʐݒ�
                            row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Activation = Activation.AllowEdit;                          // ���Ӑ�ʐݒ�
                            if (isNewRow == true)
                            {
                                row.Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;   // ���_
                                row.Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activation = Activation.AllowEdit;         // �i��
                                row.Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;  // ���[�J�[
                            }
                            // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                        }
                        #endregion

                        // �s�폜������BackColor�̐ݒ�(�ʏ�F)
                        foreach (UltraGridRow row in this.uGrid_Details.Rows)
                        {
                            if ((int)row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value == 1)
                            {
                                // �s�폜������BackColor�̐ݒ�(�ʏ�F)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    // --- DEL 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                                    //if (cell.Column.Key != this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                                    //{
                                    //    cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                    //    cell.Appearance.BackColor2 = ct_DISABLE_COLOR;

                                    //    if (cell.Column.Key == this._recBgnGdsDataTable.GoodsNameColumn.ColumnName ||    //�i��
                                    //        cell.Column.Key == this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName || //���i����
                                    //        cell.Column.Key == this._recBgnGdsDataTable.UnitPriceColumn.ColumnName)      //���P��
                                    //    {
                                    //        cell.Activation = Activation.AllowEdit;
                                    //        cell.Appearance.BackColor = Color.Empty;
                                    //        cell.Appearance.BackColor2 = Color.Empty;
                                    //        cell.Appearance.BackColorDisabled = Color.Empty;
                                    //        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    //        cell.Appearance.ForeColor = Color.Empty;
                                    //        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    //    }
                                    //}
                                    // --- DEL 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                                    // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                                    if (cell.Activation == Activation.NoEdit
                                     && cell.Column.Key != this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                                    {
                                        if ((Guid)row.Cells[this._recBgnGdsDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                                        {
                                            cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                            cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                            cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                            cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                        }
                                        else
                                        {
                                            cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                            cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                                            cell.Appearance.BackColorDisabled = ct_DISABLE_COLOR;
                                            cell.Appearance.BackColorDisabled2 = ct_DISABLE_COLOR;
                                        }
                                    }
                                    // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                                    else
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                            }

                            row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        if (this.uGrid_Details.ActiveCell != null)
                        {
                            if (this.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName)
                            {
                                if (this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                                {
                                    this.SetGuidButton(true);
                                }
                                else
                                {
                                    this.SetGuidButton(false);
                                }
                            }
                            else
                            {
                                this.SetGuidButton(false);
                            }
                        }
                    }
                    else
                    {
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                        this.SetGuidButton(false);
                        
                        for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                        {
                            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                            {
                                // �s�폜��BackColor�̐ݒ�(�s���N�F)�A���͋��ݒ�
                                foreach (UltraGridCell cell in this.uGrid_Details.Rows[rowIndex].Cells)
                                {
                                    if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName) // �F�͍s�ԍ���̂�
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    cell.Activation = Activation.NoEdit;

                                    // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                                    if (cell.Column.Key == this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName ||
                                        cell.Column.Key == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                                    {
                                        cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                                    }
                                    // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                                }
                            }

                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                        }
                    }

                }
                //�폜�w��敪:1
                else
                {
                    for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                    {
                        if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                        {
                            isAllDelete = false;
                            break;
                        }
                    }

                    if (isAllDelete == true)
                    {
                        // �s�폜������BackColor�̐ݒ�(�ʏ�F)
                        foreach (UltraGridRow row in this.uGrid_Details.Rows)
                        {
                            if ((int)row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value == 1)
                            {
                                // �s�폜������BackColor�̐ݒ�(�ʏ�F)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColorDisabled = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColorDisabled2 = ct_DISABLE_COLOR;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;

                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                    }
                    else
                    {
                        for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                        {
                            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                            {
                                // �s�폜��BackColor�̐ݒ�(�s���N�F)�A���͋��ݒ�
                                foreach (UltraGridCell cell in this.uGrid_Details.Rows[rowIndex].Cells)
                                {
                                    if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName) // �F�͍s�ԍ���̂�
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                        }
                    }
                }

                this.uGrid_Details.EndUpdate();
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uButton_Revival_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.uGrid_Details.BeginUpdate();

                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    if (row.Selected || row.IsActiveRow)
                    {
                        if ((int)this.uGrid_Details.Rows[row.Index].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value != 2)
                        {
                            //��������
                            foreach (UltraGridCell cell in this.uGrid_Details.Rows[row.Index].Cells)
                            {
                                if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                                {
                                    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                    cell.Appearance.ForeColor = ct_DISABLE_FONT_COLOR;
                                    cell.Appearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
                                }
                            }

                            this.uGrid_Details.Rows[row.Index].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 2;
                        }
                        else
                        {
                            //������������
                            foreach (UltraGridCell cell in this.uGrid_Details.Rows[row.Index].Cells)
                            {
                                if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                                {
                                    cell.Appearance.BackColor = Color.Empty;
                                    cell.Appearance.BackColor2 = Color.Empty;
                                    cell.Appearance.BackColorDisabled = Color.Empty;
                                    cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                    cell.Appearance.ForeColor = Color.Empty;
                                    cell.Appearance.ForeColorDisabled = Color.Empty;
                                }
                            }

                            this.uGrid_Details.Rows[row.Index].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                    }
                }

                this.uGrid_Details.EndUpdate();
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.Default;
            }
        }

        // --- ADD 2015/03/24 Y.Wakita ---------->>>>>
        /// <summary>
        /// ���i�Ď擾����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���i�Ď擾�������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/03/24 Y.Wakita</br>
        /// </remarks>
        private void uButton_Recapture_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            DialogResult dialogResult = TMsgDisp.Show(this
                                         , emErrorLevel.ERR_LEVEL_QUESTION
                                         , this.Name
                                         , "���[�J�[���i���Ď擾���܂����H"
                                         , 0
                                         , MessageBoxButtons.YesNo
                                         , MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.No) return;

            SFCMN00299CA msgForm = new SFCMN00299CA();
            try
            {
                // ���o����ʕ��i�̃C���X�^���X���쐬
                msgForm.Title = "���i�Ď擾";
                msgForm.Message = "���i�Ď擾���ł��B";
                msgForm.DispCancelButton = false;
                msgForm.Show();

                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

                GoodsUnitData goodsUnitData = new GoodsUnitData();
                // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
                Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

                string msg = string.Empty;

                string goodsNo = string.Empty;
                int goodsMakerCd = 0;
                string applyStaDate = string.Empty;

                string sectionCode = string.Empty;  // ���_
                int customerCode = 0;               // ���Ӑ�
                long mkrSuggestRtPric = 0;          // ���[�J�[��]���i
                DateTime startTime;                 // �J�n��
                long listPrice = 0;                 // �艿
                long unitPrice = 0;                 // ����
                bool uPricDiv = false;              // ADD 2015/03/26 Y.Wakita

                this.uGrid_Details.BeginUpdate();

                foreach (RecBgnGdsDataSet.RecBgnGdsRow row in this._recBgnGdsDataTable.Rows)
                {
                    goodsNo = row.GoodsNo;
                    goodsMakerCd = row.GoodsMakerCode;
                    applyStaDate = row.ApplyStaDate;

                    if (goodsNo != string.Empty && goodsMakerCd != 0 && applyStaDate != string.Empty)
                    {
                        // ���i����
                        // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                        //int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(goodsNo, goodsMakerCd, out goodsUnitData, out msg);
                        int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(goodsNo, goodsMakerCd, out goodsUnitData, out partsInfoDataSet, out mkrSuggestRtPricList, out mkrSuggestRtPricUList, out msg);
                        // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
                        if (goodsUnitData != null)
                        {
                            sectionCode = row.InqOtherSecCd;    // ���_
                            customerCode = 0;   // ���Ӑ�
                            startTime = DateTime.Parse(applyStaDate);   // �J�n��
                            mkrSuggestRtPric = 0;          // ���[�J�[��]���i
                            listPrice = 0;                 // �艿
                            unitPrice = 0;                 // ����

                            // ���i�擾
                            Calculator.GetUnitPrice(customerCode
                                                  , goodsUnitData
                                                  , startTime
                                                  , sectionCode
                                                  , mkrSuggestRtPricList
                                                  , mkrSuggestRtPricUList
                                                  , out uPricDiv    // ADD 2015/03/26 Y.Wakita
                                                  , out mkrSuggestRtPric
                                                  , out listPrice
                                                  , out unitPrice);

                            // Ұ����]�������i
                            row.MkrSuggestRtPric = mkrSuggestRtPric;
                            // �艿
                            row.ListPrice = listPrice;

                            // --- ADD 2015/03/26 Y.Wakita ---------->>>>>
                            int retPartsFlag = 0;
                            status = this._recBgnGdsAcs.GetPartsArticleInfo(goodsUnitData, uPricDiv, out retPartsFlag);
                            row.ModelFitDiv = (short)retPartsFlag;     // �K���Ԏ�敪
                            // --- ADD 2015/03/26 Y.Wakita ----------<<<<<

                            row.RowDevelopFlg = 1;  // ADD 2015/04/01 Y.Wakita �V�X�e���e�X�g��Q ��63 

                            // --- ADD 2015/04/02 Y.Wakita �V�X�e���e�X�g��Q ��65 ---------->>>>>
                            row.goodsUnitData = goodsUnitData;
                            row.mkrSuggestRtPricList = mkrSuggestRtPricList;
                            row.mkrSuggestRtPricUList = mkrSuggestRtPricUList;
                            // --- ADD 2015/04/02 Y.Wakita �V�X�e���e�X�g��Q ��65 ----------<<<<<

                            #region ���Ӑ�ʐݒ�
                            // ���Ӑ�ʐݒ�
                            int rowNo = row.RowNo;

                            RecBgnGdsCustInfo recBgnGdsCustInfo = null;
                            if (this._recBgnGdsAcs.RecBgnGdsCustInfoDic.ContainsKey(rowNo))
                            {
                                recBgnGdsCustInfo = this._recBgnGdsAcs.RecBgnGdsCustInfoDic[rowNo];
                            }
                            if (recBgnGdsCustInfo != null)
                            {
                                foreach (RecBgnGdsDataSet.RecBgnCustRow RecBgnCustRow in recBgnGdsCustInfo.recBgnCust)
                                {
                                    sectionCode = RecBgnCustRow.MngSectionCode;                 // ���_
                                    customerCode = int.Parse(RecBgnCustRow.CustomerCode);       // ���Ӑ�
                                    mkrSuggestRtPric = RecBgnCustRow.MkrSuggestRtPric;          // ���[�J�[��]���i
                                    startTime = DateTime.Parse(RecBgnCustRow.ApplyStaDate);     // �J�n��
                                    listPrice = 0;                                              // �艿
                                    unitPrice = 0;                                              // ����

                                    // ��蒼��
                                    this._calculator.GetUnitPrice(customerCode
                                                               , goodsUnitData
                                                               , startTime
                                                               , sectionCode
                                                               , mkrSuggestRtPricList
                                                               , mkrSuggestRtPricUList
                                                               , out uPricDiv   // ADD 2015/03/26 Y.Wakita
                                                               , out mkrSuggestRtPric
                                                               , out listPrice
                                                               , out unitPrice);

                                    RecBgnCustRow.MkrSuggestRtPric = mkrSuggestRtPric;  // ���[�J�[��]���i
                                    RecBgnCustRow.ListPrice = listPrice;                // �艿
                                }
                            }
                            #endregion
                        }
                    }
                }
                this.uGrid_Details.EndUpdate();

                this.GoodsInfoPreview(this.uGrid_Details.ActiveRow.Index); // ADD 2015/03/31 T.Miyamoto �V�X�e���e�X�g��Q ��61
            }
            finally
            {
                msgForm.Dispose();
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;

                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���i�Ď擾���������܂����B",
                                -1,
                                MessageBoxButtons.OK);

                this.Cursor = Cursors.Default;

                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Recapture"].SharedProps.Enabled = true;
                this.uButton_Recapture.Enabled = true;

                this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        // --- ADD 2015/03/24 Y.Wakita ----------<<<<<

        /// <summary>
        /// �Z���̃f�[�^�`�F�b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : �Z���̃f�[�^�`�F�b�N�����B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // ���l���ڂ̏ꍇ
                if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int16)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // �����͂�0�ɂ���				
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        //if (this.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsDataTable.SalesPriceSetDivColumn.ColumnName)
                        //{
                        //    editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// �O��l���Z�b�g
                        //}
                        //else
                        //{
                        //    editorBase.Value = 0;				// 0���Z�b�g
                        //    this.uGrid_Details.ActiveCell.Value = 0;
                        //}
                    }
                    // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�				
                    else if ((editorBase.CurrentEditText.Trim() == "-")
                          || (editorBase.CurrentEditText.Trim() == ".")
                          || (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        //if (this.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsDataTable.SalesPriceSetDivColumn.ColumnName)
                        //{
                            editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// �O��l���Z�b�g
                        //}
                        //else
                        //{
                        //    editorBase.Value = 0;				// 0���Z�b�g
                        //    this.uGrid_Details.ActiveCell.Value = 0;
                        //}
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
                            //if (this.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsDataTable.SalesPriceSetDivColumn.ColumnName)
                            //{
                                editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// �O��l���Z�b�g
                            //}
                            //else
                            //{
                            //    editorBase.Value = 0;				// 0���Z�b�g
                            //    this.uGrid_Details.ActiveCell.Value = 0;
                            //}
                        }
                    }
                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�	
                    e.StayInEditMode = false;			// �ҏW���[�h�͔�����
                }
            }
        }

        /// <summary>
        /// �O���b�h�Z���A�N�e�B�u�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Z���A�N�e�B�u�㔭���C�x���g</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            this.SetGridGuid();

            UltraGridCell cell_RowNo = this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName];
            UltraGridCell cell_RowDel = this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName];

            if (cell_RowDel.Text == "0")
            {
                cell_RowNo.Appearance.BackColor = Color.Orange;
                cell_RowNo.Appearance.BackColor2 = Color.Orange;
                cell_RowNo.Appearance.BackColorDisabled = Color.Orange;
                cell_RowNo.Appearance.BackColorDisabled2 = Color.Orange;
            }

            // --- ADD 2015/03/24 Y.Wakita ---------->>>>>
            if (this._recBgnGdsAcs.DeleteSearchMode == false)
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Recapture"].SharedProps.Enabled = true;
                this.uButton_Recapture.Enabled = true;
            }
            // --- ADD 2015/03/24 Y.Wakita ----------<<<<<
        }

        /// <summary>
        /// �O���b�h�Z���A�N�e�B�u�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Z���A�N�e�B�u�㔭���C�x���g</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
            // ���i���v���r���[�\��
            this.GoodsInfoPreview(this.uGrid_Details.ActiveRow.Index);

            this._rowIndex = this.uGrid_Details.ActiveRow.Index;
        }

        /// <summary>
        /// �O���b�h�Z���o��㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Z���o��㔭���C�x���g</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                UltraGridCell cell = this.uGrid_Details.ActiveCell;
                UltraGridRow row = this.uGrid_Details.ActiveCell.Row;
                if (cell.Value == null)
                {
                    return;
                }

                // ���_�R�[�h
                if (cell.Column.Key == this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName)
                {
                    string inputValue = "";
                    // ���͒l���擾
                    inputValue = cell.Value.ToString().Trim();
                    if (!this.SectionCheck_Detail(inputValue, cell.Row.Index))
                    {
                        this.focusFlg = false;
                    }
                }
            }
        }

        /// <summary>
        /// �O���b�h�Z���A�N�e�B�u�O�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Z���A�N�e�B�u�O�����C�x���g</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;

            // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
            if ((int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value == 1) return;
            // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<

            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                // ���̑� IME�𖳌�
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Off;

                if (cell.Column.Key == this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName)
                {
                    // ���_
                    this._swSectionInfo = e.Cell.Value.ToString().Trim();
                }
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsNoColumn.ColumnName)
                {
                    // �i��
                    this._swGoodsNo = e.Cell.Value.ToString().Trim();
                }
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
                {
                    // Ұ��
                    this._swGoodsMakerCd = (Int32)e.Cell.Value;
                }
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsNameColumn.ColumnName)
                {
                    // �i��
                    // IME��ON
                    this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
                }
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName)
                {
                    // ���i�R�����g
                    // IME��ON
                    this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
                }
                else if (cell.Column.Key == this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
                {
                    // ���������i��ٰ��
                    this._swBrgnGoodsGrpCode = (Int16)e.Cell.Value;
                }
                else if (cell.Column.Key == this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName)
                {
                    // ���J�J�n��
                    this._swApplyStaDate = e.Cell.Value.ToString();
                    if (e.Cell.Value.ToString() == string.Empty)
                    {
                        e.Cell.Value = DateTime.Now.ToString("yyyy/MM/dd");
                    }
                }
                else if (cell.Column.Key == this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName)
                {
                    // ���J�I����
                    this._swApplyEndDate = e.Cell.Value.ToString();
                    if (e.Cell.Value.ToString() == string.Empty)
                    {
                        e.Cell.Value = DateTime.Now.ToString("yyyy/MM/dd");
                    }
                }
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            }
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
		// ��2015/03/02 Enter
        //private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        internal void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
		// ��2015/03/02 Enter
        {
            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected && this.uGrid_Details.ActiveRow.Index == 0)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        if (this.GridKeyUpTopRow != null)
                        {
                            this.GridKeyUpTopRow(this, new EventArgs());
                            this.uGrid_Details.ActiveRow.Selected = false;
                            this.uGrid_Details.ActiveRow = null;
                            e.Handled = true;
                        }
                    }
                }
            }
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            string columnKey = this.uGrid_Details.ActiveCell.Column.Key;
            // ���i�R�����g�Z����Alt�{Enter�L�[�������ɉ��s�R�[�h���Z�b�g����
            if (e.Alt && (e.KeyCode == Keys.Enter))
            {
                if (columnKey == this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName)
                {
                    string sVal = this.uGrid_Details.ActiveCell.Text;  //�Ώە�����
                    int iPos = this.uGrid_Details.ActiveCell.SelStart; //�J�[�\���ʒu(���s�R�[�h�}���ʒu)
                    // ���s�R�[�h�}��
                    this.uGrid_Details.ActiveCell.Value = sVal.Substring(0, iPos)
                                                        + Environment.NewLine
                                                        + sVal.Substring(iPos, (this.uGrid_Details.ActiveCell.Text.Length - iPos));
                    // ���s�����擪�ɃJ�[�\���ړ�
                    this.uGrid_Details.ActiveCell.SelStart = iPos + Environment.NewLine.Length;
                }
            }

            //if (this.uGrid_Details.ActiveCell.IsInEditMode)
            //{
            //    if (e.KeyCode == Keys.Left && this.uGrid_Details.ActiveCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
            //    {
            //        return;
            //    }
            //    if (e.KeyCode == Keys.Left && this.uGrid_Details.ActiveCell.SelStart != 0)
            //    {
            //        return;
            //    }
            //    if (e.KeyCode == Keys.Right && this.uGrid_Details.ActiveCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
            //    {
            //        return;
            //    }
            //    if (e.KeyCode == Keys.Right && this.uGrid_Details.ActiveCell.SelStart < this.uGrid_Details.ActiveCell.Text.Length)
            //    {
            //        return;
            //    }
            //    if (e.KeyCode == Keys.Up && this.uGrid_Details.ActiveCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
            //    {
            //        return;
            //    }
            //    if (e.KeyCode == Keys.Up && this.uGrid_Details.ActiveCell.SelStart > 0)
            //    {
            //        string sChkVal = this.uGrid_Details.ActiveCell.Text;
            //        sChkVal = sChkVal.Substring(0, this.uGrid_Details.ActiveCell.SelStart); //�J�[�\���ʒu�܂ł̕�����
            //        if (sChkVal.IndexOf(Environment.NewLine) >= 0)
            //        {
            //            // ���L�[�������ɃJ�[�\���ʒu�̑O�ŉ��s����Ă���ꍇ�͐���ΏۊO
            //            return;
            //        }
            //    }
            //    if (e.KeyCode == Keys.Down && this.uGrid_Details.ActiveCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
            //    {
            //        return;
            //    }
            //    if (e.KeyCode == Keys.Down && this.uGrid_Details.ActiveCell.SelStart < this.uGrid_Details.ActiveCell.Text.Length)
            //    {
            //        string sChkVal = this.uGrid_Details.ActiveCell.Text;
            //        sChkVal = sChkVal.Substring(this.uGrid_Details.ActiveCell.SelStart, (sChkVal.Length - this.uGrid_Details.ActiveCell.SelStart)); //�J�[�\���ʒu�܂ł̕�����
            //        if (sChkVal.IndexOf(Environment.NewLine) >= 0)
            //        {
            //            // ���L�[�������ɃJ�[�\���ʒu�̌�ŉ��s����Ă���ꍇ�͐���ΏۊO
            //            return;
            //        }
            //    }
            //}

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        this.focusFlg = true;
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                        if (rowIndex == 0)
                        {
                            if (focusFlg)
                            {
                                if (this.GridKeyUpTopRow != null)
                                {
                                    this.GridKeyUpTopRow(this, new EventArgs());
                                    this.uGrid_Details.ActiveCell.Selected = false;
                                    this.uGrid_Details.ActiveCell = null;
                                    e.Handled = true;
                                }
                            }
                            else
                            {
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            e.Handled = true;
                            if (focusFlg)
                            {
                                this.uGrid_Details.Rows[rowIndex - 1].Cells[columnKey].Activate();
                            }
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        this.focusFlg = true;
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                        if (rowIndex == this.uGrid_Details.Rows.Count - 1)
                        {
                            e.Handled = true;
                            if (focusFlg)
                            {
                                if (this._recBgnGdsAcs.DeleteSearchMode == false)
                                {
                                    if (CheckDateForDown())
                                    {
                                        #region �ŏI�s�̏ꍇ�A�V�K�s��ǉ�����
                                        this.NewRowAdd();
                                        #endregion
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.Handled = true;
                            if (focusFlg)
                            {
                                this.uGrid_Details.Rows[rowIndex + 1].Cells[columnKey].Activate();
                            }
                        }
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                case Keys.Left:
                    {
                        this.focusFlg = true;
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                        // ���_�̏ꍇ
                        if ((columnKey == this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName)
                          ||(columnKey == this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName))
                            {
                            // ���[���玟�s���[�Ɉړ������Ȃ�
                            if (this.uGrid_Details.ActiveCell.Column.Header.VisiblePosition == 1)
                            {
                                e.Handled = true;
                            }
                            else
                            {
                                if (!this.leftFocusFlg)
                                {
                                    e.Handled = true;
                                }
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                            }
                        }
                        else
                        {
                            // ���Z���擾
                            string columnName = columnKey;
                            // ���Z���擾
                            int targetColumnIndex = GetNextColumnIndexByTab(1, rowIndex, columnName);

                            if (targetColumnIndex != -1)
                            {
                                if (focusFlg)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[targetColumnIndex].Activate();
                                }
                            }
                            else
                            {
                                if (focusFlg)
                                {
                                    // ���s
                                    columnName = this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName;
                                    this.uGrid_Details.Rows[rowIndex - 1].Cells[columnName].Activate();
                                }
                            }
                        }

                        e.Handled = true;
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                case Keys.Right:
                    {
                        this.focusFlg = true;

                        if (columnKey == this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName)
                        {
                            // �Ȃ��B
                        }
                        else if (columnKey == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                        {
                            // �E�[��VisiblePosition���擾
                            int lastPosition = this.GetGridLastPosition(this.uGrid_Details);

                            // �E�[���玟�s���[�Ɉړ������Ȃ�
                            if (this.uGrid_Details.ActiveCell.Column.Header.VisiblePosition == lastPosition)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                            // ���Z���擾
                            string columnName = columnKey;
                            // ���Z���擾
                            int targetColumnIndex = GetNextColumnIndexByTab(0, rowIndex, columnName);

                            if (targetColumnIndex != -1)
                            {
                                if (focusFlg)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[targetColumnIndex].Activate();
                                }
                            }
                            else
                            {
                                if (focusFlg)
                                {
                                    if (rowIndex < this.uGrid_Details.Rows.Count - 1)
                                    {
                                        // ���s
                                        columnName = this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName;
                                        this.uGrid_Details.Rows[rowIndex + 1].Cells[columnName].Activate();
                                    }
                                    else
                                    {
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                }
                            }

                            e.Handled = true;
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                // --- ADD 2015/03/04 CellButtonKeyDown ------------------------------>>>>>
                case Keys.Space:
                    {
                        if (columnKey == this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName)
                        {
                            // ���i�C���[�W
                            Byte[] dats = new byte[0];
                            if (this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value.ToString().Trim().Length != 0)
                                dats = (Byte[])this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;

                            this.OpenGoodsImgFile(out dats);

                            if (dats != null)
                            {
                                this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value = dats;

                                // ���i���v���r���[�\��
                                this.GoodsInfoPreview(this.uGrid_Details.ActiveRow.Index);
                                this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Value = GOODSIMG_FILE_TRUE;
                            }
                        }
                        else if (columnKey == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                        {
                            // ���Ӑ�ʐݒ��ʌĂяo��
                            //this.OpenRecBgnCustDialog(e.Cell.Row.Index);
                            this.OpenRecBgnCustDialog(rowIndex);
                        }
                        break;
                    }
                // --- ADD 2015/03/04 CellButtonKeyDown ------------------------------<<<<<
            }
            this.focusFlg = true;
        }

        /// <summary>
        /// �O���b�h���̍Ō��VisiblePosition�擾
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetGridLastPosition(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            if (grid.ActiveRow == null) return 0;

            int colCount = 0;
            for (int index = 0; index < grid.ActiveRow.Cells.Count; index++)
            {
                if (grid.ActiveRow.Cells[index].Column.Hidden == false)
                {
                    if (colCount < grid.ActiveRow.Cells[index].Column.Header.VisiblePosition)
                    {
                        colCount = grid.ActiveRow.Cells[index].Column.Header.VisiblePosition;
                    }
                }
            }
            return colCount;
        }

        /// <summary>
        /// �O���b�h���̍őO��VisiblePosition�擾
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetGridFirstPosition(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            if (grid.ActiveRow == null) return 0;

            int colCount = 5;
            for (int index = 0; index < grid.ActiveRow.Cells.Count; index++)
            {
                if (grid.ActiveRow.Cells[index].Column.Hidden == false)
                {
                    if (colCount > grid.ActiveRow.Cells[index].Column.Header.VisiblePosition)
                    {
                        colCount = grid.ActiveRow.Cells[index].Column.Header.VisiblePosition;
                    }
                }
            }
            return colCount;
        }

        /// <summary>
        /// �O���b�h�Z���A�v�f�g�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Z���A�v�f�g�㔭���C�x���g</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;
            UltraGridRow row = e.Cell.Row;
            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.uGrid_Details.CellChange -= this.uGrid_Details_CellChange;

                string ErrMsg = string.Empty;
                string PriceClearMsg = "���i�ݒ�";
                string CustClearMsg = "���Ӑ�ʐݒ�";

                string applyStaDate = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Text;
                string recBgnCust = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Text;

                #region �i��
                // �i��
                if (cell.Column.Key == this._recBgnGdsDataTable.GoodsNoColumn.ColumnName)
                {
                    string goodsNo = cell.Value.ToString();
                    int goodsMakerCd = (int)this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value;

                    // --- ADD 2015/03/03 Y.Wakita Redmine#309 ---------->>>>>
                    goodsMakerCd = 0;
                    // --- ADD 2015/03/03 Y.Wakita Redmine#309 ----------<<<<<
                    if (!String.IsNullOrEmpty(goodsNo))
                    {
                        if (!this._swGoodsNo.Equals(goodsNo))
                        {
// --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                            //if ((this._swGoodsNo != string.Empty)
                            // && (this._swGoodsMakerCd != 0)
                            // && (this._swApplyStaDate != string.Empty))
                            if (((this._swGoodsNo != string.Empty)
                             && (this._swGoodsMakerCd != 0)
                             && (this._swApplyStaDate != string.Empty))
                             && (this._swGoodsNo != goodsNo))
// --- UPD 2015/03/25 Y.Wakita ----------<<<<<
                            {
                                if (applyStaDate != string.Empty)
                                {
                                    ErrMsg += PriceClearMsg;
                                }
                                if (recBgnCust != string.Empty)
                                {
                                    if (ErrMsg != string.Empty)
                                    {
                                        ErrMsg += "�A";
                                    }
                                    ErrMsg += CustClearMsg;
                                }

                                if (ErrMsg != string.Empty)
                                {
                                    DialogResult dialogResult = TMsgDisp.Show(this
                                         , emErrorLevel.ERR_LEVEL_QUESTION
                                         , this.Name
                                         , ErrMsg + "���N���A���܂��B" + "\r\n" + "\r\n" +
                                           "��낵���ł����H"
                                         , 0
                                         , MessageBoxButtons.YesNo
                                         , MessageBoxDefaultButton.Button1);

                                    if (dialogResult == DialogResult.No)
                                    {
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value = this._swGoodsNo;
                                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        //this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                        return;
                                    }
                                }
                            }

                            GoodsUnitData goodsUnitData = new GoodsUnitData();
                            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                            PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
                            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

                            string msg = string.Empty;

                            // ���i����
                            // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                            //int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(cell.Value.ToString().Trim(), goodsMakerCd, out goodsUnitData, out msg);
                            int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(cell.Value.ToString().Trim(), goodsMakerCd, out goodsUnitData, out partsInfoDataSet, out mkrSuggestRtPricList, out mkrSuggestRtPricUList, out msg);
                            // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
                            if (goodsUnitData != null)
                            {
                                if (goodsUnitData.LogicalDeleteCode == 0)
                                {
                                    this._swGoodsNo = goodsUnitData.GoodsNo;
                                    this._swGoodsMakerCd = goodsUnitData.GoodsMakerCd;

                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = goodsUnitData.GoodsMakerCd;
                                    MakerUMnt makerUMnt = null;
                                    try
                                    {
                                        makerUMnt = this._recBgnGdsAcs.MakerUMntDic[goodsUnitData.GoodsMakerCd];
                                    }
                                    catch
                                    {
                                    }
                                    finally
                                    {
                                        if (makerUMnt != null)
                                        {
                                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerKanaName; 
                                        }
                                    }
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value = goodsUnitData.GoodsNo;           // �i��
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Value = goodsUnitData.GoodsNameKana;   // �i��
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BLGoodsCodeColumn.ColumnName].Value = goodsUnitData.BLGoodsCode;   // BL���i����
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BLGroupCodeColumn.ColumnName].Value = goodsUnitData.BLGroupCode;   // BL��ٰ�ߺ���
                                    // --- DEL 2015/03/26 Y.Wakita ---------->>>>>
                                    //int retPartsFlag = 0;
                                    //status = this._recBgnGdsAcs.GetPartsArticleInfo(goodsUnitData, out retPartsFlag);
                                    //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ModelFitDivColumn.ColumnName].Value = retPartsFlag;                // �K���Ԏ�敪
                                    // --- DEL 2015/03/26 Y.Wakita ----------<<<<<

                                    int nIndex = cell.Row.Index;
                                    for (int iRowNo = this.uGrid_Details.Rows.Count - 1; 0 < iRowNo; iRowNo--)
                                    {
                                        int sIndex = iRowNo - 1;
                                        if ((this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString() ==
                                             this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString())
                                        &&  (this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value.ToString() ==
                                             this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value.ToString()))
                                        {
                                            // ���i��
                                            this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Value = this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Value;
                                            // ���i�R�����g
                                            this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Value = this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Value;
                                            // ���i�C���[�W
                                            this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value = this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;
                                            this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Value = this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Value;
                                            // ���������i��ٰ��
                                            this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value;
                                            this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value;
                                            break;
                                        }
                                    }

                                    // ���i���
                                    this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.goodsUnitDataColumn.ColumnName].Value = goodsUnitData;
                                    // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                                    this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricListColumn.ColumnName].Value = mkrSuggestRtPricList;
                                    this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricUListColumn.ColumnName].Value = mkrSuggestRtPricUList;
                                    // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

                                    if (applyStaDate != string.Empty)
                                    {
                                        // ���i�擾
                                        this.SetUnitPrice(cell.Row.Index);
                                    }

                                    if (recBgnCust != string.Empty)
                                    {
                                        // ���Ӑ�ʐݒ�폜
                                        this.DelRecBgnGdsCustInfo(cell.Row.Index);
                                    }

                                    // �݌Ƀ}�X�^�`�F�b�N
                                    bool stockFlg = false;
                                    foreach (Stock stock in goodsUnitData.StockList)
                                    {
                                        if (stock.SupplierStock != 0)
                                        {
                                            stockFlg = true;
                                            break;
                                        }
                                    }

                                    if (!(stockFlg))
                                    {
                                        // �݌Ƀ}�X�^�ɑ��݂��Ȃ��A�܂��͍݌ɐ����Ȃ��ꍇ
                                        DialogResult dialogResult = TMsgDisp.Show(this
                                                                     , emErrorLevel.ERR_LEVEL_QUESTION
                                                                     , this.Name
                                                                     , "�݌ɐ��ʂ�����܂���B" + "\r\n" + "\r\n" +
                                                                       "�݌ɂ̓o�^���s���܂����H"
                                                                     , 0
                                                                     , MessageBoxButtons.YesNo
                                                                     , MessageBoxDefaultButton.Button1);

                                        if (dialogResult == DialogResult.Yes)
                                        {
                                            // ���[�U�[�f�[�^
                                            if (goodsUnitData.OfferKubun < 3)
                                            {
                                                // �_���폜����Ă���݌ɂ�����ꍇ�͎擾
                                                TBOSearchUAcs _tboSearchAcs = new TBOSearchUAcs();
                                                List<Stock> stockList;
                                                if (_tboSearchAcs.GetStockList(out stockList, goodsUnitData.Clone()) == 0)
                                                {
                                                    goodsUnitData.StockList = new List<Stock>();
                                                    goodsUnitData.StockList = stockList;
                                                }
                                            }
                                            // �񋟃f�[�^
                                            else
                                            {
                                                goodsUnitData.CreateDateTime = DateTime.Now;
                                                // �񋟓��t���폜
                                                goodsUnitData.OfferDate = DateTime.MinValue;
                                                if (goodsUnitData.GoodsPriceList != null)
                                                {
                                                    foreach (GoodsPrice price in goodsUnitData.GoodsPriceList)
                                                    {
                                                        price.OfferDate = DateTime.MinValue;
                                                    }
                                                }
                                            }
                                            AllDefSet allDefSet = this._recBgnGdsAcs.AllDefSet;
                                            if (allDefSet != null && allDefSet.GoodsStockMSTBootDiv == 1)
                                            {
                                                //���i�݌Ƀ}�X�^�U���N��
                                                PMKHN09380UA goodsStockMaster = new PMKHN09380UA(this._recBgnGdsAcs.GoodsAcsClass);
                                                goodsStockMaster.ShowDialog(this, ref goodsUnitData);
                                            }
                                            else
                                            {
                                                //���i�݌Ƀ}�X�^���N��
                                                MAKHN09280UA goodsStockMaster = new MAKHN09280UA(this._recBgnGdsAcs.GoodsAcsClass);
                                                goodsStockMaster.ShowDialog(this, ref goodsUnitData);
                                            }
                                        }
                                    }
                                }
                            }
                            else if (status == -1)
                            {
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value = string.Empty;        // �i��
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;      // �i��
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BLGoodsCodeColumn.ColumnName].Value = 0;               // BL���i����
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BLGroupCodeColumn.ColumnName].Value = 0;               // BL��ٰ�ߺ���
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ModelFitDivColumn.ColumnName].Value = 0;               // �K���Ԏ�敪
                                
                                this._swGoodsNo = string.Empty;
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                this.focusFlg = false;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���i�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value = this._swGoodsNo;
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                this.focusFlg = false;
                            }
                        }
                    }
                    else
                    {
                        this._swGoodsNo = string.Empty;
                        //�s�N���A
                        RecBgnGdsDataSet.RecBgnGdsRow rowNo = (RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[this.uGrid_Details.ActiveRow.Index];
                        //this._recBgnGdsDataTable.Rows.Remove(rowNo);
                        //this.NewRowAdd();

                        //RecBgnGdsDataSet.RecBgnGdsRow clearRow = this.GetRecBgnGdsRow(int.Parse(this._recBgnGdsDataTable.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Value.ToString()));
                        this.ClearRecBgnGdsRow(rowNo);
                        this.GoodsInfoPreviewClear();
                    }

                    this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion 
                #region �i��
                // �i��
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsNameColumn.ColumnName)
                {
                    //�Ȃ��B
                    this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion
                #region ���i�C���[�W
                // ���i�C���[�W
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsImageColumn.ColumnName)
                {
                    this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion
                #region ���[�J�[
                // Ұ��
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
                {
                    int inputValue = 0;
                    // ���͒l���擾
                    Int32.TryParse(cell.Value.ToString(), out inputValue);

                    if (inputValue != 0)
                    {
                        MakerUMnt makerUMnt = null;
                        if (this._recBgnGdsAcs.MakerUMntDic.ContainsKey(inputValue))
                        {
                            makerUMnt = this._recBgnGdsAcs.MakerUMntDic[inputValue];
                        }

                        if (makerUMnt != null)
                        {
                            if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Text.Trim()))
                            {
// --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                                if ((this._swGoodsNo == this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Text.Trim())
                                 && (this._swGoodsMakerCd == inputValue))
                                {
                                    return;
                                }
// --- ADD 2015/03/25 Y.Wakita ----------<<<<<

// --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                                //if ((this._swGoodsNo != string.Empty)
                                // && (this._swGoodsMakerCd != 0)
                                // && (this._swApplyStaDate != string.Empty))
                                if (((this._swGoodsNo != string.Empty)
                                 && (this._swGoodsMakerCd != 0)
                                 && (this._swApplyStaDate != string.Empty))
                                 && (this._swGoodsMakerCd != inputValue))
// --- UPD 2015/03/25 Y.Wakita ----------<<<<<
                                {
                                    if (applyStaDate != string.Empty)
                                    {
                                        ErrMsg += PriceClearMsg;
                                    }
                                    if (recBgnCust != string.Empty)
                                    {
                                        if (ErrMsg != string.Empty)
                                        {
                                            ErrMsg += "�A";
                                        }
                                        ErrMsg += CustClearMsg;
                                    }

                                    if (ErrMsg != string.Empty)
                                    {
                                        DialogResult dialogResult = TMsgDisp.Show(this
                                             , emErrorLevel.ERR_LEVEL_QUESTION
                                             , this.Name
                                             , ErrMsg + "���N���A���܂��B" + "\r\n" + "\r\n" +
                                               "��낵���ł����H"
                                             , 0
                                             , MessageBoxButtons.YesNo
                                             , MessageBoxDefaultButton.Button1);

                                        if (dialogResult == DialogResult.No)
                                        {
                                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = this._swGoodsMakerCd;
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                            //this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                            return;
                                        }
                                    }
                                }

                                GoodsUnitData goodsUnitData = new GoodsUnitData();
                                // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                                PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
                                Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                                Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                                // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

                                string msg = string.Empty;
                                string goodsNo = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Text.Trim();

                                // ���i����
                                // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                                //int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(goodsNo, inputValue, out goodsUnitData, out msg);
                                int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(goodsNo, inputValue, out goodsUnitData, out partsInfoDataSet, out mkrSuggestRtPricList, out mkrSuggestRtPricUList, out msg);
                                // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
                                if (goodsUnitData != null)
                                {
                                    if (goodsUnitData.LogicalDeleteCode == 0)
                                    {
                                        this._swGoodsMakerCd = inputValue;
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerKanaName;  // Ұ����
                                        //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value = goodsUnitData.GoodsNo;           // �i��	// DEL 2015/03/25 Y.Wakita
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Value = goodsUnitData.GoodsNameKana;   // �i��
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BLGoodsCodeColumn.ColumnName].Value = goodsUnitData.BLGoodsCode;   // BL����
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BLGroupCodeColumn.ColumnName].Value = goodsUnitData.BLGroupCode;   // BL��ٰ�ߺ���
                                        // --- DEL 2015/03/26 Y.Wakita ---------->>>>>
                                        //int retPartsFlag = 0;
                                        //status = this._recBgnGdsAcs.GetPartsArticleInfo(goodsUnitData, out retPartsFlag);
                                        //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ModelFitDivColumn.ColumnName].Value = retPartsFlag;                // �K���Ԏ�敪
                                        // --- DEL 2015/03/26 Y.Wakita ----------<<<<<

                                        // ���i���
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.goodsUnitDataColumn.ColumnName].Value = goodsUnitData;
                                        // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricListColumn.ColumnName].Value = mkrSuggestRtPricList;
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricUListColumn.ColumnName].Value = mkrSuggestRtPricUList;
                                        // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

                                        if (applyStaDate != string.Empty)
                                        {
                                            // ���i�擾
                                            this.SetUnitPrice(cell.Row.Index);
                                        }

                                        if (recBgnCust != string.Empty)
                                        {
                                            // ���Ӑ�ʐݒ�폜
                                            this.DelRecBgnGdsCustInfo(cell.Row.Index);
                                        }
                                    }
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���i�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = this._swGoodsMakerCd;
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    this.focusFlg = false;
                                }
                            }
                            else
                            {
                                this._swGoodsMakerCd = inputValue;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerKanaName;
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���[�J�[�R�[�h�����݂��܂���B",
                            -1,
                            MessageBoxButtons.OK);

                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = this._swGoodsMakerCd;
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            this.focusFlg = false;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Text.Trim()))
                        {
                            GoodsUnitData goodsUnitData = new GoodsUnitData();
                            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                            PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
                            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
                            string msg = string.Empty;

                            string goodsNo = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Text.Trim();
                            
                            // ���i����
                            // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                            //int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(goodsNo, inputValue, out goodsUnitData, out msg);
                            int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(goodsNo, inputValue, out goodsUnitData, out partsInfoDataSet, out mkrSuggestRtPricList, out mkrSuggestRtPricUList, out msg);
                            // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
                            if (goodsUnitData != null)
                            {
                                if (goodsUnitData.LogicalDeleteCode == 0)
                                {
                                    this._swGoodsMakerCd = goodsUnitData.GoodsMakerCd;
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = goodsUnitData.GoodsMakerCd;   // Ұ��
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Value = goodsUnitData.GoodsNameKana;       // Ұ����

                                    // ���i���
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.goodsUnitDataColumn.ColumnName].Value = goodsUnitData;
                                    // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricListColumn.ColumnName].Value = mkrSuggestRtPricList;
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricUListColumn.ColumnName].Value = mkrSuggestRtPricUList;
                                    // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���i�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = this._swGoodsMakerCd;
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                this.focusFlg = false;
                            }
                        }
                        else
                        {
                            this._swGoodsMakerCd = 0;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = 0;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Value = string.Empty;
                        }
                    }
                        this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion 
                #region ���i�R�����g
                // ���i����
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName)
                {
                    // �s�T�C�Y�ύX�i���͌�ɔ��f����Ȃ����߁A�ݒ����U�Œ�ɂ��Ă��玩���T�C�Y�ɖ߂��j
                    this.uGrid_Details.DisplayLayout.Override.RowSizing = RowSizing.Fixed;
                    this.uGrid_Details.DisplayLayout.Override.RowSizing = RowSizing.AutoFree;

                    this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion
                #region �\���敪
                // �\���敪
                else if (cell.Column.Key == this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName)
                {
                    int inputValue = 0;
                    // ���͒l���擾
                    Int32.TryParse(cell.Text, out inputValue);

                    // --- DEL 2015/03/16 Y.Wakita ��Q ---------->>>>>
                    #region �폜
                    //if (inputValue == 0)
                    //{
                    //    // �`�F�b�NOFF

                    //    // ���������i��ٰ��
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = 0;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.NoEdit;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;
                    //    // ���������i��ٰ�ߖ�
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = string.Empty;
                    //    // ���[�J�[���i
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value = 0;
                    //    // �W�����i
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ListPriceColumn.ColumnName].Value = 0;
                    //    // ������
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value = 0;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.NoEdit;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;

                    //    // ���P��
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Value = 0;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.NoEdit;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;
                    //}
                    //else
                    //{
                    //    // �`�F�b�NON
                    //    // ���i�擾
                    //    this.SetUnitPrice(cell.Row.Index);
                    //    // ���������i��ٰ��
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;

                    //    // ������
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;

                    //    // ���P��
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.AllowEdit;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor = Color.Empty;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                    //}
                    //this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                    #endregion
                    // --- DEL 2015/03/16 Y.Wakita ��Q ----------<<<<<
                    // --- ADD 2015/03/16 Y.Wakita ��Q ---------->>>>>
                    this.ChangeDisplayDiv(cell.Row.Index, inputValue);
                    // --- ADD 2015/03/16 Y.Wakita ��Q ----------<<<<<
                }
                #endregion
                #region ���������i�O���[�v
                // ���������i��ٰ��
                else if (cell.Column.Key == this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
                {
                    short gdsGrpCode = 0;
                    short.TryParse(cell.Value.ToString(), out gdsGrpCode);

                    // ���͒l���擾
                    if (!cell.Value.ToString().Trim().Equals(string.Empty))
                    {
                        string errMsg = string.Empty;

                        if (this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Text == "1")
                        {
                            if (this._recBgnGdsAcs.CheckRecBgnGrp(string.Empty, string.Empty, gdsGrpCode, true, out errMsg))
                            {
                                string recBgnGrpName = this._recBgnGdsAcs.GetRecBgnGrpName(string.Empty, string.Empty, gdsGrpCode);

                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = recBgnGrpName;
                                this._swBrgnGoodsGrpCode = gdsGrpCode;
                            }
                            else
                            {
                                TMsgDisp.Show(this
                                             , emErrorLevel.ERR_LEVEL_EXCLAMATION
                                             , this.Name
                                             , errMsg
                                             , 0
                                             , MessageBoxButtons.OK);

                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this._swBrgnGoodsGrpCode;
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                this.focusFlg = false;
                            }
                        }
                    }
                    else
                    {
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = 0;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = string.Empty;
                        this._swBrgnGoodsGrpCode = 0;
                    }

                        this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion
                #region ���J�J�n��/�I����
                // ���J�J�n��/�I����
                else if (cell.Column.Key == this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName
                      || cell.Column.Key == this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName)
                {
                    bool chkFlg = true;
                    string sErrMsg = string.Empty;
                    string sColumnName = string.Empty;

                    string iApplyDate = string.Empty;

                    if (cell.Column.Key == this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName)
                    {
                        sColumnName = this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName; //��
                        sErrMsg = this._recBgnGdsDataTable.ApplyStaDateColumn.Caption;        //��^�C�g��
                        iApplyDate = this._swApplyStaDate;
                    }
                    else
                    {
                        sColumnName = this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName;
                        sErrMsg = this._recBgnGdsDataTable.ApplyEndDateColumn.Caption;
                        iApplyDate = this._swApplyEndDate;
                    }

                    if (!cell.Value.ToString().Equals(string.Empty))
                    {
                        string sApplyDate = cell.Value.ToString();

                        // ���t�`�F�b�N
                        chkFlg = CheckDateValue(ref sApplyDate);
                        if (!chkFlg)
                        {
                            sErrMsg = sErrMsg + "�Ɍ�肪����܂��B";
                        }
                        else
                        {
                            if (this.uGrid_Details.Rows[cell.Row.Index].Cells[sColumnName].Text != sApplyDate)	// ADD 2015/03/25 Y.Wakita
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[sColumnName].Value = sApplyDate;

                            //�J�n����ύX�i�I�����J�n�j�����ꍇ
                            if (this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Text.Trim() != string.Empty)
                            {
                                DateTime startDate = DateTime.Parse(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Text.Trim());
                                DateTime endDate = DateTime.MinValue;
                                if (!this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Text.Trim().Equals(string.Empty))
                                {
                                    endDate = DateTime.Parse(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Text.Trim());
                                }
                                if (startDate > endDate && endDate != DateTime.MinValue)
                                {
                                    chkFlg = false;
                                    sErrMsg = "���J���͈͎̔w��Ɍ�肪����܂��B";
                                }
                            }
                        }
                        if (chkFlg)
                        {
                            if (sColumnName == this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName)
                            {
                                // ���J�J�n�����ύX���ꂽ�ꍇ
                                if ((this._swGoodsNo != string.Empty)
                                 && (this._swGoodsMakerCd != 0)
                                 && (this._swApplyStaDate != string.Empty))
                                {
                                    if (applyStaDate != string.Empty)
                                    {
                                        ErrMsg += PriceClearMsg;
                                    }
                                    if (recBgnCust != string.Empty)
                                    {
                                        if (ErrMsg != string.Empty)
                                        {
                                            ErrMsg += "�A";
                                        }
                                        ErrMsg += CustClearMsg;
                                    }

                                    if (ErrMsg != string.Empty)
                                    {
                                        DialogResult dialogResult = TMsgDisp.Show(this
                                             , emErrorLevel.ERR_LEVEL_QUESTION
                                             , this.Name
                                             , ErrMsg + "���N���A���܂��B" + "\r\n" + "\r\n" +
                                               "��낵���ł����H"
                                             , 0
                                             , MessageBoxButtons.YesNo
                                             , MessageBoxDefaultButton.Button1);

                                        if (dialogResult == DialogResult.No)
                                        {
                                            this.uGrid_Details.Rows[cell.Row.Index].Cells[sColumnName].Value = iApplyDate; //�߂�
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                            //this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                            return;
                                        }
                                    }
                                }

                                if (applyStaDate != string.Empty)
                                {
                                    // ���i�擾
                                    this.SetUnitPrice(cell.Row.Index);
                                }

                                if (recBgnCust != string.Empty)
                                {
                                    // ���Ӑ�ʐݒ�폜
                                    this.DelRecBgnGdsCustInfo(cell.Row.Index);
                                }

                                this._swApplyStaDate = sApplyDate;
                            }
                            else
                            {
                                // ���J�I�������ύX���ꂽ�ꍇ
                                if ((this._swGoodsNo != string.Empty)
                                 && (this._swGoodsMakerCd != 0)
                                 && (this._swApplyEndDate != string.Empty))
                                {
                                    if (recBgnCust != string.Empty)
                                    {
                                        ErrMsg += CustClearMsg;
                                    }

                                    if (ErrMsg != string.Empty)
                                    {
                                        DialogResult dialogResult = TMsgDisp.Show(this
                                             , emErrorLevel.ERR_LEVEL_QUESTION
                                             , this.Name
                                             , ErrMsg + "���N���A���܂��B" + "\r\n" + "\r\n" +
                                               "��낵���ł����H"
                                             , 0
                                             , MessageBoxButtons.YesNo
                                             , MessageBoxDefaultButton.Button1);

                                        if (dialogResult == DialogResult.No)
                                        {
                                            this.uGrid_Details.Rows[cell.Row.Index].Cells[sColumnName].Value = iApplyDate; //�߂�
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                            //this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                            return;
                                        }
                                    }
                                }

                                if (recBgnCust != string.Empty)
                                {
                                    // ���Ӑ�ʐݒ�폜
                                    this.DelRecBgnGdsCustInfo(cell.Row.Index);
                                }

                                this._swApplyEndDate = sApplyDate;
                            }
                        }
                    }
                    else
                    {
                        if (this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString() != string.Empty)
                        //�l("0")���������ꍇ
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[sColumnName].Value = iApplyDate; //�߂�
                    }
                    if (!chkFlg)
                    {
                        TMsgDisp.Show(this
                                     , emErrorLevel.ERR_LEVEL_EXCLAMATION
                                     , this.Name
                                     , sErrMsg
                                     , 0
                                     , MessageBoxButtons.OK);

                        this.focusFlg = false;

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[sColumnName].Value = iApplyDate; //�߂�
                    }
                        this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion 
                #region ������
                // ������
                else if (cell.Column.Key == this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName)
                {
                    double inputValue = 0.0;
                    double.TryParse(cell.Value.ToString(), out inputValue);
                    bool status = IndispensableColumCheck(RowIndex);
                    if (status)
                    {
                        string sectionCode = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString(); // ���_
                        int customerCode = 0; // ���Ӑ�
                        long mkrSuggestRtPric = int.Parse(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value.ToString()); // Ұ����]�������i
                        DateTime startDate = DateTime.Parse(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Text.Trim()); // �J�n��
                        double listPrice = 0; // �艿
                        double unitPrice = 0; // ����

                        object goodsUnitDataObj = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.goodsUnitDataColumn.ColumnName].Value;
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        goodsUnitData = goodsUnitDataObj as GoodsUnitData;

                        if (inputValue > 0)
                        {
                            // ���i�v�Z
                            this._calculator.GetUnitPriceFromRate(sectionCode, customerCode, mkrSuggestRtPric, inputValue, goodsUnitData, startDate, out listPrice, out unitPrice);

                            // �艿
                            this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.ListPriceColumn.ColumnName].Value = listPrice;

                            // ���P��
                            this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Value = unitPrice;
                        }
                        else
                        {
                            // ���i�擾
                            this.SetUnitPrice(RowIndex);
                        }
                    }
                    this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion	// ADD 2015/03/25 Y.Wakita
                #region �P��
                else if (cell.Column.Key == this._recBgnGdsDataTable.UnitPriceColumn.ColumnName)
                {
                    this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion
                #region ���Ӑ�ʐݒ�
                else if (cell.Column.Key == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                {
                    this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion
			//#endregion	// DEL 2015/03/25 Y.Wakita

                // ���i���v���r���[�\��
                    //this.GoodsInfoPreview(cell.Row.Index);
                
                this._rowIndex = cell.Row.Index;

                //this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                this.uGrid_Details.CellChange += this.uGrid_Details_CellChange;
            }
        }

        ///// <summary>
        ///// �s�擾����
        ///// </summary>
        ///// <param name="stockRowNo"></param>
        ///// <returns></returns>
        ///// <br>Update Note : </br>
        ///// <br>�Ǘ��ԍ�    : </br>
        ///// <br>            : </br>
        //public RecBgnGdsDataSet.RecBgnGdsRow GetRecBgnGdsRow(int RecRowNo)
        //{
        //    return this._recBgnGdsDataTable.(RecRowNo);
        //}

        /// <summary>
        /// ���׍s�I�u�W�F�N�g�̃N���A���s���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="row">���׍s�I�u�W�F�N�g</param>
        private void ClearRecBgnGdsRow(RecBgnGdsDataSet.RecBgnGdsRow row)
        {
            if (row == null) return;

            GoodsUnitData goodsUnitData = new GoodsUnitData();

            #region �����ڃN���A
            row.GoodsMakerCode = 0;                     // Ұ��
            row.GoodsMakerName = string.Empty;          // Ұ����
            row.GoodsNo = string.Empty;                 // �i��
            row.GoodsName = string.Empty;               // �i��
            row.BLGroupCode = 0;                        // BL�O���[�v�R�[�h
            row.BLGoodsCode = 0;                        // BL���i�R�[�h
            row.GoodsComment = string.Empty;            // ���i�R�����g
            row.MkrSuggestRtPric = 0;                   // Ұ����]�������i
            row.ListPrice = 0;                          // �艿
            row.UnitCalcRate = 0;                       // �P���Z�o�|��
            row.UnitPrice = 0;                          // ���P��
            row.ApplyStaDate = string.Empty;            // �K�p�J�n��
            row.ApplyEndDate = string.Empty;            // �K�p�I����
            row.ModelFitDiv = 0;                        // �K���Ԏ�敪
            row.CustRateGrpCode = 0;                    // ���Ӑ�|���O���[�v�R�[�h
            row.DisplayDivCode = 1;                     // �\���敪
            row.BrgnGoodsGrpCode = 0;                   // ���������i�O���[�v�R�[�h
            row.BrgnGoodsGrpName = string.Empty;        // ���������i�O���[�v��
            row.GoodsImage = new Byte[0];               // ���i�摜
            row.GoodsImageDmy = string.Empty;
            row.RowDevelopFlg = 0;
            row.RecBgnCust = string.Empty;
            row.goodsUnitData = goodsUnitData;          // ���i���
            row.RowDeleteFlg = 0;
            row.FilterGuid = Guid.Empty;
            #endregion
        }

        /// <summary>
        /// �K�{���ڃ`�F�b�N
        /// </summary>
        /// <param name="RowIndex"></param>
        private bool IndispensableColumCheck(int RowIndex)
        {
            // ���_�R�[�h���̓`�F�b�N
            string inqOtherSecCd = this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString();
            if (string.IsNullOrEmpty(inqOtherSecCd.Trim()))
            {
                return false;
            }

            // �i�Ԃ���̓`�F�b�N
            string goodsNo = this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            if (string.IsNullOrEmpty(goodsNo.Trim()))
            {
                return false;
            }

            // ���[�J�[�R�[�h����̓`�F�b�N
            int goodsMakerCd = (int)this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value;
            if (goodsMakerCd == 0)
            {
                return false;
            }

            // ���J�J�n������̓`�F�b�N
            string applyStaDate = this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Text;
            if (string.IsNullOrEmpty(applyStaDate.Trim()))
            {
                return false;
            }

            // ���J�I��������̓`�F�b�N
            string applyEndDate = this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Text;
            if (string.IsNullOrEmpty(applyEndDate.Trim()))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �ʐݒ�폜
        /// </summary>
        /// <param name="RowIndex"></param>
        private void DelRecBgnGdsCustInfo(int RowIndex)
        {
            int rowNo = (int)this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Value;
            this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Remove(rowNo);

            // �ʐݒ�
            this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Value = string.Empty;
        }

        /// <summary>
        /// ���i�擾����
        /// </summary>
        /// <param name="RowIndex"></param>
        private void SetUnitPrice(int RowIndex)
        {
            // �i��
            if (this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString().Trim() == string.Empty) return;

            // Ұ��
            if (this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value.ToString().Trim() == string.Empty) return;

            // ���J�J�n��
            if (this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString().Trim() == string.Empty) return;

            // ���J�J�n�����ύX���ꂽ�ꍇ
            long wkMkrSuggestRtPric = 0;
            long wkListPrice = 0;
            long wkUnitPrice = 0;
            string sApplyDate = this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString().Trim();

            bool status = this.GetUnitPrice(RowIndex, sApplyDate, out wkMkrSuggestRtPric, out wkListPrice, out wkUnitPrice);

			// --- UPD 2015/03/25 Y.Wakita ---------->>>>>
            //// Ұ����]�������i
            //this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value = wkMkrSuggestRtPric;
            //// �艿
            //this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.ListPriceColumn.ColumnName].Value = wkListPrice;
            //// ������
            //this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value = 0.0;
            //// ���P��
            //this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Value = wkUnitPrice;

            RecBgnGdsDataSet.RecBgnGdsRow row = this._recBgnGdsDataTable[RowIndex];

            // Ұ����]�������i
            row.MkrSuggestRtPric = wkMkrSuggestRtPric;
            // �艿
            row.ListPrice = wkListPrice;
            // ������
            row.UnitCalcRate = 0;
            // ���P��
            row.UnitPrice = wkUnitPrice;
			// --- UPD 2015/03/25 Y.Wakita ----------<<<<<
            row.RowDevelopFlg = 1;  // ADD 2015/04/01 Y.Wakita �V�X�e���e�X�g��Q ��63 
        }

        /// <summary>
        /// ���t�`�F�b�N����
        /// </summary>
        /// <param name="sChkDate"></param>
        public bool CheckDateValue(ref string sChkDate)
        {
            string cellValue = sChkDate;
            string nowString = DateTime.Now.Date.ToString("yyyyMMdd");
            int n =  sChkDate.Length - sChkDate.Replace("/", "").Length;
            string format = "yyyy/M/d";

            // �X���b�V���Ȃ�
            switch (n)
            {
                case 0:
                    switch (sChkDate.Length)
                    {
                        case 1: // ���̂ݓ���
                            cellValue = nowString.Substring(0, 6) + "0" + cellValue;
                            cellValue = cellValue.Insert(4, "/");
                            cellValue = cellValue.Insert(7, "/");
                            break;
                        case 3: // ���E���̂ݓ���
                            cellValue = nowString.Substring(0, 4) + "0" + cellValue;
                            cellValue = cellValue.Insert(4, "/");
                            cellValue = cellValue.Insert(7, "/");
                            break;
                        case 0:
                        case 5:
                        case 7:
                            break;
                        default:
                            cellValue = nowString.Substring(0, 8 - cellValue.Length) + cellValue;
                            cellValue = cellValue.Insert(4, "/");
                            cellValue = cellValue.Insert(7, "/");
                            break;
                    }
                    break;
                case 1:
                    cellValue = nowString.Substring(0, 4) + cellValue;
                    cellValue = cellValue.Insert(4, "/");
                    break;

                case 2:
                    if (cellValue.Split('/')[0].Length < 3) format = "y/M/d";
                    break;
            }

            DateTime parseDate;
            if (!DateTime.TryParseExact(cellValue, format, null, DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite | DateTimeStyles.AllowInnerWhite, out parseDate))
            {
                return false;
            }
            sChkDate = parseDate.ToString("yyyy/MM/dd");
            return true;
        }

        /// <summary>
        /// �O���b�h�Z��KeyPress�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Z��KeyPress�����C�x���g</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (!cell.IsInEditMode) return;

            //----------------------------------------------
            // ActiveCell�����[�J�[�̏ꍇ
            //----------------------------------------------
            if (cell.Column.Key == this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell�����J�J�n���A���J�I�����̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName
                  || cell.Column.Key == this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName)
            {
                if (!this.KeyPressDateCheck(10, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell�����������i�O���[�v�R�[�h�̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell���������̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// ���ו�����������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���ו��������������܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                col.Hidden = true;
                col.Header.Fixed = false;

                // �uNo��v�ȊO�̑S�ẴZ����DiabledColor��ݒ肷��B
                if (col.Key != this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = ct_DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
                }
            }

            #region ���\�����ݒ�
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Width = 40;		        // ��
            editBand.Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].Width = 80;		    // �폜��
            //-------------------------------------------------------------------------------------------------------
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.RowNoColumn.ColumnName].Width = 40;		        // ��
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.UpdateTimeColumn.ColumnName].Width = 80;		    // �폜��
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Width = 35;		// ���_
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Width = 85;		// ���_��
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNoColumn.ColumnName].Width = 115;	        // �i��
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Width = 150;			// �i��
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Width = 40;		// Ұ��
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Width = 85;		// Ұ����
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsCommentColumn.ColumnName].Width = 200;		// ���i����
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Width = 45;		// ���i�Ұ������
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Width = 65;	// ���������i��ٰ��
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Width = 85;	// ���������i��ٰ�ߖ�
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Width = 45;	    // ���i���J�敪
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Width = 80;		// ���J�J�n��
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Width = 80;		// ���J�I����
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Width = 75;	// Ұ����]�������i
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Width = 50;       // ���|��
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Width = 75;          // ���P��
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.RecBgnCustColumn.ColumnName].Width = 45;         // ���Ӑ��
            #endregion

            #region ���Œ��ݒ�
            //editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Header.Fixed = true;		            // ��
            //editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;		            // ��
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Header.Fixed = false;
            #endregion
            
            #region ��CellAppearance�ݒ�
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;                // ��
            editBand.Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// �폜��
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// ���_
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;         // ���_��
            editBand.Columns[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	            // �i��
            editBand.Columns[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;				// �i��
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// Ұ��
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;		// Ұ����
            editBand.Columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// ���i����
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;		// ���i�Ұ������
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// ���������i��ٰ��
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;		// ���������i��ٰ�ߖ�
            editBand.Columns[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;		// ���i���J�敪
            editBand.Columns[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// ���J�J�n��
            editBand.Columns[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// ���J�I����
            editBand.Columns[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;     // Ұ����]�������i
            editBand.Columns[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;         // ���P��
            editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;			// ���P��
            editBand.Columns[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;		    // ���Ӑ�ʐݒ�

            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            //editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            //editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            //editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion

            #region �����͋��ݒ�

            //editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;		        // ��
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellActivation = Activation.NoEdit;
            editBand.Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;			// �폜��
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;		// ���_
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		    // ���_��
            editBand.Columns[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 	        // �i��
            editBand.Columns[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 			// �i��
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;		// Ұ��
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		// Ұ����
            editBand.Columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;		// ���i����
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;      // ���i�Ұ������
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 	// ���������i��ٰ��
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;      // ���������i��ٰ�ߖ�
            editBand.Columns[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 	    // ���i���J�敪
            editBand.Columns[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// ���J�J�n��
            editBand.Columns[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// ���J�I����
            editBand.Columns[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;      // Ұ����]�������i
            editBand.Columns[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;       // ���P��
            editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		    // ���P��
            editBand.Columns[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;         // ���Ӑ�ʐݒ�
            #endregion

            #region ��Style�ݒ�
            editBand.Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;        // �폜��
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;     // ���_
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;     // ���_��
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // Ұ��
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // Ұ����
            editBand.Columns[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;           // �i��
            editBand.Columns[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // �i��
            editBand.Columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // ���i����
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;        // ���i�Ұ��
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;   // ���i�Ұ������
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // ���������i��ٰ��
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // ���������i��ٰ�ߖ�
            editBand.Columns[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;  // ���i���J�敪
            editBand.Columns[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // ���J�J�n��
            editBand.Columns[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // ���J�I����
            editBand.Columns[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // Ұ����]�������i
            editBand.Columns[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // ������
            editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // ���P��
            editBand.Columns[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;      // ���Ӑ�ʐݒ�
            editBand.Columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].CellMultiLine = DefaultableBoolean.True; //�����s�`���ŕ\��
            this.uGrid_Details.DisplayLayout.Override.RowSizing = RowSizing.AutoFree;          //�s�T�C�Y�̐ݒ聁�����T�C�Y�ݒ�(�ύX��)
            this.uGrid_Details.DisplayLayout.Override.RowSizingArea = RowSizingArea.EntireRow; //�s�T�C�Y�ύX�Ɏg�p�ł��镔�����s�S��(���R�[�h�Z���N�^�E���E��)
            #endregion

            #region ���t�H�[�}�b�g�ݒ�

            string decimalFormat2 = "#,##0;-#,##0;''";
            string codeFormat1 = "#00;-#00;''";
            string codeFormat2 = "#0000;-#0000;''";
            string codeFormat3 = "#0;-#0;''";
            string doubleFormat = "##0.#0;-##0.#0;''";

            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Format = codeFormat1;		    // ���_
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Format = codeFormat2;		// Ұ��
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Format = codeFormat3;		// ���������i��ٰ��
            editBand.Columns[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Format = decimalFormat2;	// Ұ����]�������i
            editBand.Columns[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Format = doubleFormat;		// ������
            editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Format = decimalFormat2;			// ���P��
            #endregion

            #region ��MaxLength�ݒ�
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].MaxLength = 2;        // ���_
            editBand.Columns[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].MaxLength = 24;             // �i��
            editBand.Columns[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].MaxLength = 100;          // �i��
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].MaxLength = 4;       // Ұ��
            editBand.Columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].MaxLength = 200;       // ���i����
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].MaxLength = 4;		// ���������i��ٰ��
            editBand.Columns[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].MaxLength = 10;		// ���J�J�n��
            editBand.Columns[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].MaxLength = 10;        // ���J�I����
            editBand.Columns[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].MaxLength = 6;			// ������
            // --- UPD 2015/03/09 Y.Wakita Redmine#351 ---------->>>>>
            //editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].MaxLength = 17;			// ���P��
            editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].MaxLength = 7;			// ���P��
            // --- UPD 2015/03/09 Y.Wakita Redmine#351 ----------<<<<<
            #endregion

            #region ���O���b�h��\����\���ݒ菈��
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Hidden = false;		        // ��
            editBand.Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].Hidden = true;		    // �폜��
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Hidden = false;		// ���_
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Hidden = false;		// ���_��
            editBand.Columns[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Hidden = false;	            // �i��
            editBand.Columns[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Hidden = false;			// �i��
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Hidden = false;		// Ұ��
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Hidden = false;		// Ұ����
            editBand.Columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Hidden = false;		// ���i����
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Hidden = true;		    // ���i�Ұ��
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Hidden = false;		// ���i�Ұ������
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Hidden = false;	// ���������i��ٰ��
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Hidden = false;	// ���������i��ٰ�ߖ�
            editBand.Columns[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Hidden = false;	    // ���i���J�敪
            editBand.Columns[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Hidden = false;		// ���J�J�n��
            editBand.Columns[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Hidden = false;		// ���J�I����
            editBand.Columns[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Hidden = false;    // Ұ����]�������i
            editBand.Columns[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Hidden = false;		// ������
            editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Hidden = false;			// ���P��
            editBand.Columns[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Hidden = false;			// ���Ӑ�ʐݒ�
            #endregion

            #region ���O���b�h��\�[�g�ݒ菈��
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].SortIndicator = SortIndicator.Disabled;               // ��
            editBand.Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;          // �폜��
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// ���_
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// ���_��
            editBand.Columns[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	            // �i��
            editBand.Columns[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].SortIndicator = SortIndicator.Disabled;			// �i��
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	    // Ұ��
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	    // Ұ����
            editBand.Columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// ���i����
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		    // ���i�Ұ��
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// ���i�Ұ��
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	// ���������i��ٰ��
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	// ���������i��ٰ�ߖ�
            editBand.Columns[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	    // ���i���J�敪
            editBand.Columns[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// ���J�J�n��
            editBand.Columns[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// ���J�I����
            editBand.Columns[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].SortIndicator = SortIndicator.Disabled;    // Ұ����]�������i
            editBand.Columns[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].SortIndicator = SortIndicator.Disabled; 		// ������
            editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].SortIndicator = SortIndicator.Disabled;			// ���P��
            editBand.Columns[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].SortIndicator = SortIndicator.Disabled;			// ���Ӑ�ʐݒ�
            #endregion

            try
            {
                this.uGrid_Details.BeginUpdate();
                ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

                # region [�Z�������ݒ�]
                List<string> colNameList = new List<string>(new string[] 
                                            { 
                                                this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName,
                                                this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName,
                                                this._recBgnGdsDataTable.GoodsNoColumn.ColumnName,
                                                this._recBgnGdsDataTable.GoodsNameColumn.ColumnName,
                                                this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName,
                                                this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName,
                                                this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName,
                                                this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName,
                                                this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName,
                                            });
                Infragistics.Win.Appearance margedCellAppearance = new Infragistics.Win.Appearance();

                for (int index = 0; index < colNameList.Count; index++)
                {
                    string colName = colNameList[index];

                    // CellAppearance�������I�ɓ��ꂷ��i�s���͏����j
                    if (!columns[colName].Key.Trim().Equals(this._recBgnGdsDataTable.RowNoColumn.ColumnName.Trim()))
                    {
                        columns[colName].MergedCellAppearance = margedCellAppearance;
                        columns[colName].CellAppearance.TextVAlign = VAlign.Top;
                    }
                    // �Z�������ݒ�
                    columns[colName].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
                    columns[colName].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
                    columns[colName].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
                }

                // �Z�������ݒ�ڍׁi�e��𔻒�Ɋ܂߂�j
                // ���_
                columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName);

                // ���_��
                columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName);

                // �i��
                columns[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNoColumn.ColumnName);

                // �i��
                columns[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNoColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNameColumn.ColumnName);

                // Ұ��
                columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNoColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName);

                // Ұ����
                columns[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNoColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName);

                // ���i�R�����g
                columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNoColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName);

                // ���������i�O���[�v�R�[�h
                columns[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNoColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName,
                                                    this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName);

                // ���������i�O���[�v��
                columns[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNoColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName,
                                                    this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName,
                                                    this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName);

                # endregion
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }
        }

        # region [�O���b�h�Z����������N���X]
        /// <summary>
        /// �O���b�h�Z����������N���X(�J�X�^�}�C�Y)
        /// </summary>
        public class CustomMergedCellEvaluator : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            /// <summary>���������Z�����X�g</summary>
            private List<string> _joinColList;
            /// <summary>
            /// ���������Z�����X�g
            /// </summary>
            public List<string> JoinColList
            {
                get { return _joinColList; }
                set { _joinColList = value; }
            }

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public CustomMergedCellEvaluator()
            {
                _joinColList = new List<string>();
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public CustomMergedCellEvaluator(params string[] joinCols)
            {
                _joinColList = new List<string>(joinCols);
            }

            /// <summary>
            /// �Z���������菈��
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
            {
                foreach (string joinColName in JoinColList)
                {
                    if (!EqualCellValue(row1, row2, joinColName)) return false;
                }
                return true;
            }
            /// <summary>
            /// �Z��Value��r����
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="columnName"></param>
            /// <returns></returns>
            private bool EqualCellValue(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, string columnName)
            {
                return ((row1.Cells[columnName].Value.ToString().Trim() == row2.Cells[columnName].Value.ToString().Trim()));
            }
        }

        # endregion

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʏ������������܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void Clear(bool settingGrid)
        {
            this._recBgnGdsAcs.PrevRecBgnGdsDic.Clear();

            this.SetButtonEnabled(1);
            // ����DataTable�s�N���A����
            this._recBgnGdsAcs.RecBgnGdsDataTable.Rows.Clear();
            // �\�[�g�ݒ�̉���
            this.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();
            // �O���b�h�s�����ݒ菈��
            this._recBgnGdsAcs.DetailRowInitialSetting(1);
            this.DetailGridInitSetting();

            if (settingGrid)
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].Hidden = true;
            }
            //// ���i���v���r���[�N���A
            //this.GoodsInfoPreview(0);
        }

        /// <summary>
        /// �O���b�h��s���͐F�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �O���b�h��s���͐F�ݒ肵�܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void DetailGridInitSetting()
        {
            if (this.uGrid_Details == null || this.uGrid_Details.Rows.Count < 1)
            {
                return;
            }

            UltraGridRow row = this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count-1];
            
            foreach (UltraGridCell cell in row.Cells)
            {
                // ���_���A���[�J�[���A���������i��ٰ�ߖ��AҰ����]�������i
                if (cell.Column.Key == this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName
                 || cell.Column.Key == this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName
                 || cell.Column.Key == this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName
                 || cell.Column.Key == this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName)
                {
                    cell.Activation = Activation.NoEdit;
                    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                }
            }
        }

        /// <summary>
        /// ���[�J�[�R�[�h�K�C�h�N��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note	   : ���[�J�[�R�[�h�K�C�h�N���B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void GoodsMakerCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �R�[�h���疼�̂֕ϊ�
                MakerUMnt makerInfo;
                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerInfo);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���ʃZ�b�g
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = makerInfo.GoodsMakerCd;
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Value = makerInfo.MakerKanaName;

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// ���_�K�C�h�N��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note	   : ���_�K�C�h�N���B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void SectionGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ���_�K�C�h�Ăяo��
                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���ʃZ�b�g
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value = secInfoSet.SectionCode.ToString().Trim().PadLeft(2, '0');
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Value = secInfoSet.SectionGuideNm;

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// ���������i�O���[�v�K�C�h�N��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note	   : ���������i�O���[�v�K�C�h�N��</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void SetGdsGrpCodeGuide(int rowIndex, int customerCode)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ���������i�O���[�v�K�C�h
                PMREC09030UA recBgnGrpSearchForm = new PMREC09030UA(PMREC09030UA.GUIDETYPE_NORMAL, customerCode, new ArrayList(this._recBgnGdsAcs.CustomerSearchRetList));
                recBgnGrpSearchForm.RecBgnGrpSelect += new PMREC09030UA.RecBgnGrpSelectEventHandler(this.RecBgnGrpSearchForm_RecBgnGrpSelect);
                recBgnGrpSearchForm.ShowDialog(this);

                if (this._recBgnGrpRet != null)
                {
                    // ���������i�O���[�v
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this._recBgnGrpRet.BrgnGoodsGrpCode.ToString().PadLeft(4, '0');

                    MoveNextAllowEditCell(false);
                    this._customerSearchRet = null;
                }
                else
                {

                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���������i�O���[�v�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���������i�O���[�v�����߂�l�N���X</param>
        /// <remarks>
        /// <br>Note        : ���������i�O���[�v�I�����ɔ������܂��B</br>
        /// <br>Programmer	: �e�c ���V</br>
        /// <br>Date		: 2015/02/20</br>
        /// </remarks>
        private void RecBgnGrpSearchForm_RecBgnGrpSelect(object sender, RecBgnGrpRet recBgnGrpRet)
        {
            if (recBgnGrpRet == null)
            {
                this._recBgnGrpRet = null;
                return;
            }
            this._recBgnGrpRet = recBgnGrpRet;
        }

        /// <summary>
        /// �����{�^������/�L���ݒ�
        /// </summary>
        /// <param name="mode">mode1,2,3</param>
        /// <remarks>
        /// <br>Note	   : �����{�^������/�L���ݒ�B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void SetButtonEnabled(int mode)
        {
            switch (mode)
            {
                case 1:
                    {
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Revival"].SharedProps.Enabled = false;
                        this.uButton_Revival.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = true;
                        this.uButton_RowDelete.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllRowDelete"].SharedProps.Enabled = true;
                        this.uButton_AllRowDelete.Enabled = true;
                        // --- ADD 2015/03/24 Y.Wakita ---------->>>>>
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Recapture"].SharedProps.Enabled = false;
                        this.uButton_Recapture.Enabled = false;
                        // --- ADD 2015/03/24 Y.Wakita ----------<<<<<
                        break;
                    }
                case 2:
                    {
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Revival"].SharedProps.Enabled = true;
                        this.uButton_Revival.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = true;
                        this.uButton_RowDelete.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllRowDelete"].SharedProps.Enabled = true;
                        this.uButton_AllRowDelete.Enabled = true;
                        // --- ADD 2015/03/24 Y.Wakita ---------->>>>>
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Recapture"].SharedProps.Enabled = false;
                        this.uButton_Recapture.Enabled = false;
                        // --- ADD 2015/03/24 Y.Wakita ----------<<<<<
                        break;
                    }
                case 3:
                    {
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Revival"].SharedProps.Enabled = false;
                        this.uButton_Revival.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                        this.uButton_RowDelete.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllRowDelete"].SharedProps.Enabled = false;
                        this.uButton_AllRowDelete.Enabled = false;
                        // --- ADD 2015/03/24 Y.Wakita ---------->>>>>
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Recapture"].SharedProps.Enabled = false;
                        this.uButton_Recapture.Enabled = false;
                        // --- ADD 2015/03/24 Y.Wakita ----------<<<<<
                        break;
                    }
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note        : ���Ӑ�I�����ɔ������܂��B</br>
        /// <br>Programmer	: �e�c ���V</br>
        /// <br>Date		: 2015/02/20</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._customerSearchRet = null;
                return;
            }
            this._customerSearchRet = customerSearchRet;
        }

        /// <summary>
        /// �O���b�hNext�t�H�[�J�X�擾����
        /// </summary>
        /// <param name="mode">���[�h(0:Tab;1;Shift + Tab)</param>
        /// <param name="rowIndex">rowIndex</param>
        /// <param name="columnKey">columnKey</param>
        /// <returns>columnIndex</returns>
        /// <remarks>
        /// <br>Note        : �O���b�hNext�t�H�[�J�X�擾���s���܂��B</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private int GetNextColumnIndexByTab(int mode, int rowIndex, string columnKey)
        {
            int columnIndex = -1;
            switch (mode)
            {
                case 0:
                    #region Tab
                    // ���_
                    if (columnKey == this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName)
                    {
                        // ���_��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Column.Index;
                    }
                    // ���_��
                    else if (columnKey == this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName)
                    {
                        // �i��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Column.Index;
                    }
                    // �i��
                    if (columnKey == this._recBgnGdsDataTable.GoodsNoColumn.ColumnName)
                    {
                        // �i��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Column.Index;
                    }
                    // �i��
                    else if (columnKey == this._recBgnGdsDataTable.GoodsNameColumn.ColumnName)
                    {
                        // Ұ��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Column.Index;
                    }
                    // Ұ��
                    if (columnKey == this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
                    {
                        // Ұ����
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Column.Index;
                    }
                    // Ұ����
                    else if (columnKey == this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName)
                    {
                        // ���i����
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Column.Index;
                    }
                    // ���i����
                    else if (columnKey == this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName)
                    {
                        // �摜�Ұ��(����)
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Column.Index;
                    }
                    // �摜�Ұ��(����)
                    else if (columnKey == this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName)
                    {
                        // ���J�J�n��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Column.Index;
                    }
                    // ���J�J�n��
                    else if (columnKey == this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName)
                    {
                        // ���J�I����
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Column.Index;
                    }
                    // ���J�I����
                    else if (columnKey == this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName)
                    {
                        // �\���敪
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Column.Index;
                    }
                    // �\���敪
                    else if (columnKey == this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName)
                    {
                        // ���������i��ٰ��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Column.Index;
                    }
                    // ���������i��ٰ��
                    else if (columnKey == this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
                    {
                        // ���������i��ٰ�ߖ�
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Column.Index;
                    }
                    // ���������i��ٰ�ߖ�
                    else if (columnKey == this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName)
                    {
                        // Ұ����]�������i
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Column.Index;
                    }
                    // Ұ����]�������i
                    else if (columnKey == this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName)
                    {
                        // ������
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Column.Index;
                    }
                    // ������
                    else if (columnKey == this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName)
                    {
                        // ���P��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Column.Index;
                    }
                    // ���P��
                    else if (columnKey == this._recBgnGdsDataTable.UnitPriceColumn.ColumnName)
                    {
                        // ���Ӑ�ʐݒ�
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Column.Index;
                    }
                    // ���Ӑ�ʐݒ�
                    else if (columnKey == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                    {
                        columnIndex = -1;
                    }
                    break;
                    #endregion Tab
                case 1:
                    #region Shift + Tab
                    // ���_
                    if (columnKey == this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName)
                    {
                        columnIndex = -1;
                    }
                    // ���_��
                    else if (columnKey == this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName)
                    {
                        // ���_
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Column.Index;
                    }
                    // �i��
                    if (columnKey == this._recBgnGdsDataTable.GoodsNoColumn.ColumnName)
                    {
                        // ���_��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Column.Index;
                    }
                    // �i��
                    else if (columnKey == this._recBgnGdsDataTable.GoodsNameColumn.ColumnName)
                    {
                        // �i��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Column.Index;
                    }
                    // Ұ��
                    else if (columnKey == this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
                    {
                        // �i��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Column.Index;
                    }
                    // Ұ����
                    else if (columnKey == this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName)
                    {
                        // Ұ��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Column.Index;
                    }
                    // ���i����
                    else if (columnKey == this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName)
                    {
                        //  Ұ����
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Column.Index;
                    }
                    // �摜�Ұ��(����)
                    else if (columnKey == this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName)
                    {
                        // ���i����
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Column.Index;
                    }
                    // ���J�J�n��
                    else if (columnKey == this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName)
                    {
                        // �摜�Ұ��(����)
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Column.Index;
                    }
                    // ���J�I����
                    else if (columnKey == this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName)
                    {
                        // ���J�J�n��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Column.Index;
                    }
                    // �\���敪
                    else if (columnKey == this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName)
                    {
                        // ���J�I����
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Column.Index;
                    }
                    // ���������i��ٰ��
                    else if (columnKey == this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
                    {
                        // �\���敪
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Column.Index;
                    }
                    // ���������i��ٰ�ߖ�
                    else if (columnKey == this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName)
                    {
                        // ���������i��ٰ��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Column.Index;
                    }
                    // Ұ����]�������i
                    else if (columnKey == this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName)
                    {
                        // ���������i��ٰ�ߖ�
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Column.Index;
                    }
                    // ������
                    else if (columnKey == this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName)
                    {
                        // Ұ����]�������i
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Column.Index;
                    }
                    // ���P��
                    else if (columnKey == this._recBgnGdsDataTable.UnitPriceColumn.ColumnName)
                    {
                        // ������
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Column.Index;
                    }
                    // ���Ӑ�ʐݒ�
                    else if (columnKey == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                    {
                        // ���P��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Column.Index;
                    }
                    break;
                    #endregion Shift + Tab
            }

            return columnIndex;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// �ω��f�[�^�擾����
        /// </summary>
        /// <param name="delList">�폜���X�g</param>
        /// <param name="updList">�o�^���X�g</param>
        /// <remarks>
        /// <br>Note        : �ω��f�[�^�擾����</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        public void GetSaveDate(out List<RecBgnGds> delList, out List<RecBgnGds> updList)
        {
            this._prevRecBgnGdsDic = this._recBgnGdsAcs.PrevRecBgnGdsDic;
            List<RecBgnGds> dList = new List<RecBgnGds>();
            List<RecBgnGds> uList = new List<RecBgnGds>();

            RecBgnGds recBgnGds = new RecBgnGds();
            RecBgnGds recBgnGdsUPD = new RecBgnGds();
            if (this._recBgnGdsDataTable.Rows.Count > 0)
            {
                foreach (RecBgnGdsDataSet.RecBgnGdsRow row in this._recBgnGdsDataTable.Rows)
                {
                    recBgnGds = new RecBgnGds();
                    this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow(row, ref recBgnGds);

                    // ���C�s�̏ꍇ
                    if (_prevRecBgnGdsDic.ContainsKey(row.FilterGuid))
                    {
                        bool keyChanged = this._recBgnGdsAcs.CompareKey(recBgnGds, _prevRecBgnGdsDic[row.FilterGuid]);

                        // �s�폜�̏ꍇ
                        if (row.RowDeleteFlg == 0)
                        {
                            if (this._recBgnGdsAcs.Compare(recBgnGds, _prevRecBgnGdsDic[row.FilterGuid]))
                            {
                                dList.Add(_prevRecBgnGdsDic[row.FilterGuid]);
                                recBgnGdsUPD = recBgnGds.Clone();
                                recBgnGdsUPD.LogicalDeleteCode = 0;

                                if (!keyChanged)
                                {
                                    recBgnGdsUPD.IsUpdRow = true;
                                }
                                uList.Add(recBgnGdsUPD);
                            }
                            else if (row.CustUpdFlg == 1)
                            {
                                dList.Add(_prevRecBgnGdsDic[row.FilterGuid]);
                                recBgnGdsUPD = recBgnGds.Clone();
                                recBgnGdsUPD.LogicalDeleteCode = 0;

                                if (!keyChanged)
                                {
                                    recBgnGdsUPD.IsUpdRow = true;
                                }
                                uList.Add(recBgnGdsUPD);
                            }
                        }
                        else
                        {
                            recBgnGds = _prevRecBgnGdsDic[row.FilterGuid];
                            recBgnGdsUPD = recBgnGds.Clone();
                            recBgnGdsUPD.LogicalDeleteCode = 1;
                            if (!keyChanged)
                            {
                                recBgnGdsUPD.IsUpdRow = true;
                            }
                            uList.Add(recBgnGdsUPD);
                        }
                    }
                    // �V�K�s�̏ꍇ
                    else
                    {
                        if (this._recBgnGdsAcs.IsRowUpdate(row) && row.RowDeleteFlg == 0)
                        {
                            recBgnGdsUPD = recBgnGds.Clone();
                            recBgnGdsUPD.InqOtherEpCd = this._enterpriseCode;
                            recBgnGdsUPD.LogicalDeleteCode = 0;
                            recBgnGdsUPD.IsUpdRow = false;

                            uList.Add(recBgnGdsUPD);
                        }
                    }
                }
            }

            delList = dList;
            updList = uList;
        }

        /// <summary>
        /// �ۑ��O�`�F�b�N����
        /// </summary>
        /// <param name="deleteList">�폜���X�g</param>
        /// <param name="updateList">�X�V���X�g</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��O�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public bool CheckSaveDate(out List<RecBgnGds> deleteList, out List<RecBgnGds> updateList)
        {
            List<RecBgnGds> delList = new List<RecBgnGds>();
            List<RecBgnGds> updList = new List<RecBgnGds>();

            this.GetSaveDate(out delList, out updList);
            deleteList = delList;
            updateList = updList;

            if (updateList.Count == 0)
            {
                return false;
            }
            #region �K�{�`�F�b�N
            if (updateList.Count != 0)
            {
                int rowIndex = -1;
                foreach (RecBgnGds bgn in updateList)
                {
                    // �s�폜�̃f�[�^���`�F�b�N�Ȃ�
                    if (bgn.LogicalDeleteCode == 1)
                    {
                        continue;
                    }

                    //�s�ԍ����擾
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        if (bgn.RowIndex == (int)row.Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Value)
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }

                    // �i�Ԃ���̓`�F�b�N
                    if (string.IsNullOrEmpty(bgn.GoodsNo.Trim()))
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "�i�Ԃ���͂��ĉ������B",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }

                    // ���[�J�[�R�[�h����̓`�F�b�N
                    if (bgn.GoodsMakerCd == 0)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "���[�J�[�R�[�h����͂��ĉ������B",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }

                    // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
                    bool custFlg = CheckCustDisplayDiv(bgn.RowIndex);

                    // �\���敪
                    if (bgn.DisplayDivCode == 1 || custFlg)
                    {
                    // --- ADD 2015/03/23 Y.Wakita ----------<<<<<
                        // �i������̓`�F�b�N
                        if (string.IsNullOrEmpty(bgn.GoodsName.Trim()))
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "�i������͂��ĉ������B",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // �i���̓��͌����`�F�b�N
                        if (bgn.GoodsName.Length > 40)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "�i���̓��͉\���������K��l(40����)�𒴂��Ă��܂��B",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // ���i�R�����g����̓`�F�b�N
                        if (string.IsNullOrEmpty(bgn.GoodsComment.Trim()))
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "�I�X�X��POINT����͂��ĉ������B",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // ���i�C���[�W����̓`�F�b�N
                        if (bgn.GoodsImage.Length == 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "���i�C���[�W����͂��ĉ������B",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }
                    // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
                    }
                    // --- ADD 2015/03/23 Y.Wakita ----------<<<<<

                    // ���J�J�n������̓`�F�b�N
                    if (bgn.ApplyStaDate == 0)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "���J�J�n������͂��ĉ������B",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }

                    // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
                    // �\���敪
                    if (bgn.DisplayDivCode == 1 || custFlg)
                    {
                    // --- ADD 2015/03/23 Y.Wakita ----------<<<<<
                        // ���J�I��������̓`�F�b�N
                        if (bgn.ApplyEndDate == 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "���J�I��������͂��ĉ������B",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }
                    // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
                    }
                    // --- ADD 2015/03/23 Y.Wakita ----------<<<<<

                    // ���J���͈̔̓`�F�b�N
                    if (bgn.ApplyStaDate > bgn.ApplyEndDate && bgn.ApplyEndDate != 0)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "���J���͈͎̔w��Ɍ�肪����܂��B",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }

                    // �\���敪
                    if (bgn.DisplayDivCode == 1)
                    {

                        // ���������i�O���[�v�R�[�h����̓`�F�b�N
                        if (bgn.BrgnGoodsGrpCode == 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "���������i�O���[�v�R�[�h����͂��ĉ������B",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // ���P������̓`�F�b�N
                        if (bgn.UnitPrice == 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "���P������͂��ĉ������B",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }                      
                    }
                    // --- ADD 2015/04/01 Y.Wakita �V�X�e���e�X�g��Q ��63 ---------->>>>>
                    // ���m�薾�׃`�F�b�N
                    if (int.Parse(this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RowDevelopFlgColumn.ColumnName].Text) == 0)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "���m��Ȗ��ׂ����݂��܂��B",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                    // --- ADD 2015/04/01 Y.Wakita �V�X�e���e�X�g��Q ��63 ----------<<<<<
                }
            }
            #endregion

            #region �d���`�F�b�N
            if (updateList.Count != 0)
            {
                RecBgnGds recBgnGds = null;
                int rowIndex = -1;
                foreach (RecBgnGds bgn in updateList)
                {
                    // �s�폜�̃f�[�^���`�F�b�N�Ȃ�
                    if (bgn.LogicalDeleteCode == 1)
                    {
                        continue;
                    }

                    // ���������i�ݒ�}�X�^�擾
                    if (this._recBgnGdsAcs.RecBgnGdsDic.ContainsKey(bgn.GoodsMakerCd))
                    {
                        recBgnGds = this._recBgnGdsAcs.RecBgnGdsDic[bgn.GoodsMakerCd];
                    }

                    //�s�ԍ����擾
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        if (bgn.RowIndex == (int)row.Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Value)
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }

                    int flag = 0;
                    string errorMsg = string.Empty;

                    #region �d�����R�[�h�̑��݃`�F�b�N
                    flag = 0;
                    foreach (RecBgnGdsDataSet.RecBgnGdsRow row in this._recBgnGdsDataTable.Rows)
                    {
                        if (row.FilterGuid == Guid.Empty && row.RowDeleteFlg == 1)
                        {
                            continue;
                        }

                        if (bgn.InqOtherEpCd == row.InqOtherEpCd
                            && bgn.InqOtherSecCd.ToString().PadLeft(2, '0') == row.InqOtherSecCd.ToString().PadLeft(2, '0')
                            && bgn.GoodsMakerCd == row.GoodsMakerCode
                            && bgn.GoodsNo.Trim() == row.GoodsNo.Trim())
                        {
                            errorMsg = "���_�F" + bgn.InqOtherSecCd.ToString().PadLeft(2, '0')
                                   +"�A�i�ԁF" + bgn.GoodsNo.Trim()
                                   + "�AҰ���F" + bgn.GoodsMakerCd.ToString().PadLeft(4, '0')
                                   + "�A���J���F" + bgn.ApplyStaDate.ToString().PadLeft(6, '0')
                                   + "�`" + bgn.ApplyEndDate.ToString().PadLeft(6, '0');

                            int startDate = 0;
                            if (!row.ApplyStaDate.Trim().Equals(string.Empty)) startDate = int.Parse(row.ApplyStaDate.Trim().Replace("/", ""));
                            int endDate = 0;
                            if (!row.ApplyEndDate.Trim().Equals(string.Empty)) endDate = int.Parse(row.ApplyEndDate.Trim().Replace("/", ""));

                            if ((startDate <= bgn.ApplyStaDate
                                && bgn.ApplyStaDate <= endDate)
                                || (startDate <= bgn.ApplyEndDate
                                && bgn.ApplyEndDate <= endDate))
                            {
                                flag++;
                            }
                        }
                        if (flag > 1)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "����̏��i�ݒ肪���ɓo�^����Ă��܂��B" + "\r\n" +
                                 errorMsg,
                                 0,
                                 MessageBoxButtons.OK);

                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }
                    }
                    #endregion
                }
            }
            #endregion

            return true;
        }

        /// <summary>
        /// DOWN�O�`�F�b�N����
        /// </summary>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��O�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2011/07/06</br>
        /// </remarks>
        public bool CheckDateForDown()
        {
            RecBgnGdsDataSet.RecBgnGdsRow row = (RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[this._recBgnGdsDataTable.Count - 1];
            // �s�폜�̃f�[�^���`�F�b�N�Ȃ�
            if (row.RowDeleteFlg == 1)
            {
                return true;
            }
            RecBgnGds recBgnGds = new RecBgnGds();
            this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[this._recBgnGdsDataTable.Count - 1], ref recBgnGds);


            string errMsg = string.Empty;

            // �s�폜�̃f�[�^���`�F�b�N�Ȃ�
            if (recBgnGds.LogicalDeleteCode == 1)
            {
                return true;
            }

            // ���_�R�[�h���̓`�F�b�N
            if (string.IsNullOrEmpty(recBgnGds.InqOtherSecCd.Trim()))
            {
                errMsg = "���_";
            }

            // �i�Ԃ���̓`�F�b�N
            if (string.IsNullOrEmpty(recBgnGds.GoodsNo.Trim()))
            {
                if (errMsg.Length != 0)
                    errMsg += "�A";

                errMsg += "�i��";
            }

            // ���[�J�[�R�[�h����̓`�F�b�N
            if (recBgnGds.GoodsMakerCd == 0)
            {
                if (errMsg.Length != 0)
                    errMsg += "�A";

                errMsg += "Ұ��";
            }

            // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
            bool custFlg = CheckCustDisplayDiv(recBgnGds.RowIndex);

            // �\���敪
            if (recBgnGds.DisplayDivCode == 1 || custFlg)
            {
            // --- ADD 2015/03/23 Y.Wakita ----------<<<<<
                // �i������̓`�F�b�N
                if (string.IsNullOrEmpty(recBgnGds.GoodsName.Trim()))
                {
                    if (errMsg.Length != 0)
                        errMsg += "�A";

                    errMsg += "�i��";
                }

                // ���i�R�����g����̓`�F�b�N
                if (string.IsNullOrEmpty(recBgnGds.GoodsComment.Trim()))
                {
                    if (errMsg.Length != 0)
                        errMsg += "�A";

                    errMsg += "�I�X�X��POINT";
                }

                // ���i�C���[�W����̓`�F�b�N
                if (recBgnGds.GoodsImage.Length == 0)
                {
                    if (errMsg.Length != 0)
                        errMsg += "�A";

                    errMsg += "���i�Ұ��";
                }
            // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
            }
            // --- ADD 2015/03/23 Y.Wakita ----------<<<<<

            // ���J�J�n������̓`�F�b�N
            if (recBgnGds.ApplyStaDate == 0)
            {
                if (errMsg.Length != 0)
                    errMsg += "�A";

                errMsg += "���J�J�n��";
            }

            // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
            // �\���敪
            if (recBgnGds.DisplayDivCode == 1 || custFlg)
            {
            // --- ADD 2015/03/23 Y.Wakita ----------<<<<<
                // ���J�I��������̓`�F�b�N
                if (recBgnGds.ApplyEndDate == 0)
                {
                    if (errMsg.Length != 0)
                        errMsg += "�A";

                    errMsg += "���J�I����";
                }
            // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
            }
            // --- ADD 2015/03/23 Y.Wakita ----------<<<<<

            // ���J���͈̔̓`�F�b�N
            if (recBgnGds.ApplyStaDate > recBgnGds.ApplyEndDate && recBgnGds.ApplyEndDate != 0)
            {
                return false;
            }

            // �\���敪
            if (recBgnGds.DisplayDivCode == 1)
            {
                // ���������i�O���[�v
                if (recBgnGds.BrgnGoodsGrpCode == 0)
                {
                    if (errMsg.Length != 0)
                        errMsg += "�A";

                    errMsg += "���������i��ٰ��";
                }

                // ���P������̓`�F�b�N
                if (recBgnGds.UnitPrice == 0)
                {
                    if (errMsg.Length != 0)
                        errMsg += "�A";

                    errMsg += "���P��";
                }
            }

            if (errMsg.Length != 0)
            {
                TMsgDisp.Show(
                     this,
                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                     this.Name,
                     "�s��" + row.RowNo.ToString() + "�̕K�{���ڂ����͂���Ă��܂���B" + "\r\n" + "\r\n" + errMsg,
                     0,
                     MessageBoxButtons.OK);

                return false;
            }

            return true;
        }

        /// <summary>
        /// �ۑ��O�`�F�b�N�����i�폜�w��敪���P�j
        /// </summary>
        /// <param name="deleteList">�폜���X�g</param>
        /// <param name="updateList">�X�V���X�g</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��O�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void ReturnSaveDate(out List<RecBgnGds> deleteList, out List<RecBgnGds> updateList)
        {
            this._prevRecBgnGdsDic = this._recBgnGdsAcs.PrevRecBgnGdsDic;
            List<RecBgnGds> delList = new List<RecBgnGds>();
            List<RecBgnGds> updList = new List<RecBgnGds>();

            RecBgnGds recBgnGds = new RecBgnGds();
            RecBgnGds recBgnGdsUPD = new RecBgnGds();

            if (this._recBgnGdsDataTable.Rows.Count > 0)
            {
                foreach (RecBgnGdsDataSet.RecBgnGdsRow row in this._recBgnGdsDataTable.Rows)
                {
                    this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow(row, ref recBgnGds);

                    if (row.RowDeleteFlg == 1)
                    {
                        delList.Add(this._prevRecBgnGdsDic[row.FilterGuid]);
                    }
                    else if (row.RowDeleteFlg == 2)
                    {
                        recBgnGds = this._prevRecBgnGdsDic[row.FilterGuid];
                        recBgnGdsUPD = recBgnGds.Clone();
                        recBgnGdsUPD.LogicalDeleteCode = 0;
                        updList.Add(recBgnGdsUPD);
                    }
                }
            }

            deleteList = delList;
            updateList = updList;
        }

        /// <summary>
        /// ������A���ו��ݒ菈��
        /// </summary>
        /// <param name="deleteFlg">�폜�w��敪</param>
        /// <remarks>
        /// <br>Note       : ������A���ו��ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void GridSettingAfterSearch(bool deleteFlg)
        {
            //�폜�w��敪:0
            if (deleteFlg == false)
            {
                this.SetButtonEnabled(1);
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].Hidden = true;
                // �S���ڎg�p�s��
                this.AllCellNoEdit(1);
            }
            //�폜�w��敪:1
            else
            {
                this.SetButtonEnabled(2);
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].Hidden = false;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].CellAppearance.ForeColor = Color.Red;
                // �S���ڎg�p�s��
                this.AllCellNoEdit(2);
            }
        }

        /// <summary>
        /// ���͕s�\�Z���ݒ菈��
        /// </summary>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void AllCellNoEdit(int mode)
        {
            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {
                if (mode == 1)
                {
                    if ((Guid)row.Cells[this._recBgnGdsDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                    {
                        continue;
                    }
                }
                foreach (UltraGridCell cell in row.Cells)
                {
                    if (cell.Column.Key != this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                    {
                        cell.Appearance.BackColor = ct_DISABLE_COLOR;
                        cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                        cell.Activation = Activation.NoEdit;
                    }
                    // �摜�C���[�W�{�^�����g�p�s�iStyle��Edit�ɕύX�j
                    if (cell.Column.Key == this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName)
                    {
                        if (mode == 2)
                            cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

                        Byte[] dats = new byte[0];
                        if (row.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value.ToString().Trim().Length != 0)
                            dats = (Byte[])row.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;

                        if (dats.Length == 0)
                        {
                            cell.Value = "";
                        }
                        else
                        {
                            cell.Value = GOODSIMG_FILE_TRUE;
                        }

                        cell.Row.Activate();

                    }
                    else if (cell.Column.Key == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                    {
                        if (mode == 2)
                            cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

                        cell.Row.Activate();
                    }
                }
            }

            // �i���A���i���āA���P�����g�p��
            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {

                if (mode == 2) break;   // �폜�̏ꍇ

                if (mode == 1)
                {
                    if ((Guid)row.Cells[this._recBgnGdsDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                    {
                        continue;
                    }
                }
                // �i��
                row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // ���i����
                row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // ���i�Ұ��
                row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // ���������i�O���[�v�R�[�h
                row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // �\���敪
                row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // �K�p�J�n��
                row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // �K�p�I����
                row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // �P���Z�o�|��
                row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // ���P��
                row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // ���Ӑ�ʐݒ�
                row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
            }
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �����͉\�Z���ړ��������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
                    if (this.uGrid_Details.ActiveRow.Index == this._recBgnGdsDataTable.Count - 1)
                    {
                        if (this.uGrid_Details.ActiveCell == null) break;

                        if (this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                        {
                            if (this._recBgnGdsAcs.DeleteSearchMode == false)
                            {
                                if (CheckDateForDown())
                                {
                                    #region �ŏI�s�̏ꍇ�A�V�K�s��ǉ�����
                                    this.NewRowAdd();
                                    #endregion

                                    return true;
                                }
                                else
                                {
                                    moved = false;
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                            }
                        }
                    }

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

        /// <summary>
        /// �O���͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �O���͉\�Z���ړ��������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private bool MovePreAllowEditCell(bool activeCellCheck)
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
                    if (this.uGrid_Details.ActiveRow.Index == 0)
                    {
                        if (this.uGrid_Details.Rows[0].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activation != Activation.AllowEdit)
                        {
                            //if ("SectionCode".Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            //{
                            //    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            //    break;
                            //}
                        }
                        else
                        {
                            if ("GoodsMakerCode".Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                break;
                            }
                        }
                    }

                    performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

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

        #region ReturnKeyDown
        /// <summary>
        /// ReturnKey��������(�O���b�h��)
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ReturnKey�����������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void ReturnKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                this.uGrid_Details.Rows[0].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activate();
            }

            string columnKey;
            int rowIndex;

            if (this.uGrid_Details.ActiveCell != null)
            {
                columnKey = this.uGrid_Details.ActiveCell.Column.Key;
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }
            else
            {
                columnKey = this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected)
                {
                    if (this._recBgnGdsAcs.DeleteSearchMode == false)
                    {
                        if (this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                        {
                            this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
                    else
                    {
                        if (this.uGrid_Details.ActiveRow.Index < this.uGrid_Details.Rows.Count - 1)
                        {
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Selected = false;
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index + 1].Activate();
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Selected = true;
                        }
                    }
                    return;
                }
            }

            this.focusFlg = true;
            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

            if (this.focusFlg)
            {
                MoveNextAllowEditCell(false);
            }
            else
            {
                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        #endregion ReturnKeyDown

        #region ShiftKeyDown
        /// <summary>
        /// ShiftKey��������(�O���b�h��)
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ShiftKey�����������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void ShiftKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                this.uGrid_Details.Rows[0].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activate();
            }

            string columnKey;
            int rowIndex;

            if (this.uGrid_Details.ActiveCell != null)
            {
                columnKey = this.uGrid_Details.ActiveCell.Column.Key;
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }
            else
            {
                columnKey = this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected)
                {
                    if (this._recBgnGdsAcs.DeleteSearchMode == false)
                    {
                        if (this.uGrid_Details.ActiveRow.Index > 0)
                        {
                            if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activation == Activation.AllowEdit)
                            {
                                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                //this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recBgnGdsDataTable.SalesPriceSetDivColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                    }
                    else
                    {
                        if (this.uGrid_Details.ActiveRow.Index > 0)
                        {
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Selected = false;
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Activate();
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Selected = true;
                        }
                    }
                    return;
                }
            }

            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

            if (this.focusFlg)
            {
                MovePreAllowEditCell(false);
            }
            else
            {
                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        #endregion ReturnKeyDown

        /// <summary>
        /// ���ו��A�N�b�`�u�L�[���擾
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note       : ���ו��A�N�b�`�u�L�[���擾���s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public string GetFocusColumnKey(out int rowIndex)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                rowIndex = -1;
                return string.Empty;
            }

            rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            return this.uGrid_Details.ActiveCell.Column.Key;
        }

        /// <summary>
        /// �K�C�h�{�^���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �K�C�h�{�^���ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void SetGridGuid()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                switch (this.uGrid_Details.ActiveCell.Column.Key)
                {
                    case "InqOtherSecCd":
                    case "BrgnGoodsGrpCode":
                    case "GoodsMakerCode":
                    case "BLGoodsCode":
                    case "BLGroupCode":
                    case "CustomerCode":
                        {
                            if (this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                            {
                                this.SetGuidButton(true);
                            }
                            else
                            {
                                this.SetGuidButton(false);
                            }
                            break;
                        }
                    default:
                        {
                            this.SetGuidButton(false);
                            break;
                        }
                }
            }
            else
            {
                this.SetGuidButton(false);
            }
        }

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
        /// <br>Note        : ���l���̓`�F�b�N����</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        public bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
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
            string _strResult = string.Empty;
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
                int _Rketa = RecBgnGdsAcs.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
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

        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�X���b�V���������܂܂�)</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <remarks>
        /// <br>Note        : ���t���̓`�F�b�N����</br>
        /// <br>Programmer  : ���� ��Y</br>
        /// <br>Date        : 2015/02/09</br>
        /// </remarks>
        public bool KeyPressDateCheck(int keta, string prevVal, char key, int selstart, int sellength)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                // �X���b�V���ȊO
                if (key != '/') return false;
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
                if (_strResult[0] == '/')
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
        /// �w�b�_������AENTER�ATAB�A���������A�ŏI���׍s�{�P�s�ڂ̃R�[�h�փt�H�[�J�X��J�ڂ���B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �w�b�_������AENTER�ATAB�A���������A�ŏI���׍s�{�P�s�ڂ̃R�[�h�փt�H�[�J�X��J�ڂ���B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void SetFocusAfterSearch()
        {
            if (this.uGrid_Details.Rows.Count > 0)
            {
                if (this._recBgnGdsAcs.DeleteSearchMode == false)
                {
                    bool flag = false;
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        if (row.Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                        {
                            flag = true;
                            row.Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activate();
                            break;
                        }
                    }

                    if (flag == false)
                    {
                        #region �ŏI�s�̏ꍇ�A�V�K�s��ǉ�����
                        this.NewRowAdd();
                        #endregion

                    }
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.Rows[0].Activate();
                    this.uGrid_Details.Rows[0].Selected = true;
                }
            }
        }
        #endregion

        /// <summary>
        /// �V�K�s��ǉ�����
        /// </summary>
		// ��2015/03/02 Enter
        //private void NewRowAdd()
        internal void NewRowAdd()
		// ��2015/03/02 Enter
        {
            string sectionCodeWk = string.Empty;
            string sectionNameWk = string.Empty;
            this.GetBaseInfo(out sectionCodeWk, out sectionNameWk);

            // ���_
            if (sectionCodeWk == ALL_SECTION_CODE)
            {
                sectionCodeWk = ALL_SECTION_CODE;
                sectionNameWk = ALL_SECTION_NAME;
            }
            
            RecBgnGdsDataSet.RecBgnGdsRow newRow = this._recBgnGdsDataTable.NewRecBgnGdsRow();
            newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
            newRow.FilterGuid = Guid.Empty;
            newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
            newRow.InqOtherEpCd = this._enterpriseCode;
            newRow.InqOtherSecCd = sectionCodeWk;
            newRow.InqOtherSecNm = sectionNameWk;
            newRow.GoodsName = string.Empty;
            newRow.GoodsComment = string.Empty;
            newRow.DisplayDivCode = 1;
            newRow.ApplyStaDate = string.Empty;
            newRow.ApplyEndDate = string.Empty;

            this._recBgnGdsDataTable.AddRecBgnGdsRow(newRow);

            this.DetailGridInitSetting();

            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activate();

            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            RecBgnGds recBgnGds = null;
            this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[this._recBgnGdsDataTable.Count - 1], ref recBgnGds);
            this._recBgnGdsAcs.NewRecBgnGdsObj = recBgnGds.Clone();
        }

        /// <summary>
        /// �O���b�h�J�������̕ۑ�
        /// </summary>
        /// <param name="fontSize">fontSize</param>
        /// <param name="autoFillToGrid">autoFillToGrid</param>
        public void SaveSettings(int fontSize, bool autoFillToGrid)
        {
            // ���׃O���b�h
            List<ColumnInfo> detailColumnsList;
            this.SaveGridColumnsSetting(uGrid_Details, out detailColumnsList);
            this._userSetting.DetailColumnsList = detailColumnsList;
            this._userSetting.OutputStyle = fontSize;
            this._userSetting.AutoAdjustDetail = autoFillToGrid;
        }

        /// <summary>
        /// �O���b�h�J�������̓ǂݍ���
        /// </summary>
        public void LoadSettings()
        {
            this.LoadGridColumnsSetting(ref uGrid_Details, this._userSetting.DetailColumnsList);
        }

        /// <summary>
        /// �O���b�h�J�������̕ۑ�
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        private void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new ColumnInfo(ultraGridColumn.Key, ultraGridColumn.Width));
            }
        }

        /// <summary>
        /// �O���b�h�J�������̓ǂݍ���
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        private void LoadGridColumnsSetting(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<ColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Width = columnInfo.Width;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// ���Ӑ�d�q�����p���[�U�[�ݒ�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�d�q�����p���[�U�[�ݒ�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

        }

        /// <summary>
        /// ���������i�p���[�U�[�ݒ�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������i�p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<RecBgnGdsUserSet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new RecBgnGdsUserSet();
                }
            }
        }

        /// <summary>
        /// �O���b�h�{�^����������
        /// </summary>
        private void uGrid_Details_ClickCellButton(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;

            if (cell.Column.Key == this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName)
            {
                // ���i�C���[�W
                Byte[] dats = new byte[0];
                if (this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value.ToString().Trim().Length != 0)
                    dats = (Byte[])this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;

                this.OpenGoodsImgFile(out dats);

                if (dats != null)
                {
                    this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value = dats;

                    // ���i���v���r���[�\��
                    //this.GoodsInfoPreview(this.uGrid_Details.ActiveRow.Index);
                    this.PreviewColumnSync(this.uGrid_Details.ActiveRow.Index, cell.Column.Key);

                    this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Value = GOODSIMG_FILE_TRUE;
                }
            }
            else if (cell.Column.Key == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
            {
                // ���Ӑ�ʐݒ��ʌĂяo��
                this.OpenRecBgnCustDialog(e.Cell.Row.Index);
            }
        }

        /// <summary>
        /// ���Ӑ�ʐݒ��ʌĂяo��
        /// </summary>
        public void OpenRecBgnCustDialog(int indexRow)
        {
            // --- DEL 2015/03/23 Y.Wakita ---------->>>>>
            #region ���\�[�X
            //int rowNo = (int)this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Value;

            //RecBgnGdsCustInfo recBgnGdsCustInfo = null;
            //if (this._recBgnGdsAcs.RecBgnGdsCustInfoDic.ContainsKey(rowNo))
            //{
            //    recBgnGdsCustInfo = this._recBgnGdsAcs.RecBgnGdsCustInfoDic[rowNo];
            //}

            //// �f�B�N�V���i�����Ȃ��ꍇ
            //if (recBgnGdsCustInfo == null)
            //{
            //    // �����𖞂����Ă���ꍇ�A�f�B�N�V���i���쐬

            //    string goodsNo = this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            //    int goodsMakerCode = int.Parse(this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value.ToString());
            //    string applyStaDate = this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString();
            //    string applyEndDate = this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value.ToString();

            //    if (!((goodsNo == string.Empty) || (goodsMakerCode == 0) || (applyStaDate == string.Empty) || (applyEndDate == string.Empty)))
            //    {
            //        // �w�b�_�[
            //        RecBgnGdsDataSet.RecBgnGdsRow newRow = (RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[indexRow];
            //        recBgnGdsCustInfo = new RecBgnGdsCustInfo();
            //        recBgnGdsCustInfo.recBgnGdsRow = newRow;
            //        // ����
            //        RecBgnGdsDataSet.RecBgnCustDataTable recBgnCustDataTable = new RecBgnGdsDataSet.RecBgnCustDataTable();
            //        recBgnGdsCustInfo.recBgnCust = recBgnCustDataTable;
            //        this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Add(rowNo, recBgnGdsCustInfo);
            //    }
            //    else
            //    {
            //        string errMsg = string.Empty;
            //        if (goodsNo == string.Empty)
            //        {
            //            errMsg += "�i��";
            //        }

            //        if (goodsMakerCode == 0)
            //        {
            //            if (errMsg.Length != 0)
            //                errMsg += "�A";

            //            errMsg += "�i��";
            //        }

            //        if (applyStaDate == string.Empty)
            //        {
            //            if (errMsg.Length != 0)
            //                errMsg += "�A";

            //            errMsg += "���J�J�n��";
            //        }

            //        if (applyEndDate == string.Empty)
            //        {
            //            if (errMsg.Length != 0)
            //                errMsg += "�A";

            //            errMsg += "���J�I����";
            //        }

            //        TMsgDisp.Show(
            //                 this,
            //                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //                 this.Name,
            //                 errMsg + "����͂��Ă��������B",
            //                 0,
            //                 MessageBoxButtons.OK);

            //    }
            //}

            //if (recBgnGdsCustInfo != null)
            //{
            //    PMREC09021UD recBgnCustDialog = new PMREC09021UD(recBgnGdsCustInfo);
            //    DialogResult dialogResult = recBgnCustDialog.ShowDialog();
            //    if (dialogResult == DialogResult.OK)
            //    {
            //        // �߂��Ă����l��ݒ�
            //        recBgnGdsCustInfo.recBgnCust = recBgnCustDialog.RecBgnCustDataTable;

            //        this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.CustUpdFlgColumn.ColumnName].Value = 1;
            //        if (recBgnGdsCustInfo.recBgnCust.Count == 0)
            //            this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Value = string.Empty;
            //        else
            //            this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Value = GOODSIMG_FILE_TRUE;
            //    }
            //    recBgnCustDialog.Close();
            //}
            #endregion
            // --- DEL 2015/03/23 Y.Wakita ----------<<<<<

            // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
            // �K�{���ڃ`�F�b�N
            string goodsNo = this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            int goodsMakerCode = int.Parse(this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value.ToString());
            string applyStaDate = this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString();
            string applyEndDate = this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value.ToString();

            if ((goodsNo == string.Empty) || (goodsMakerCode == 0) || (applyStaDate == string.Empty) || (applyEndDate == string.Empty))
            {
                string errMsg = string.Empty;
                if (goodsNo == string.Empty)
                {
                    errMsg += "�i��";
                }

                if (goodsMakerCode == 0)
                {
                    if (errMsg.Length != 0)
                        errMsg += "�A";

                    errMsg += "�i��";
                }

                if (applyStaDate == string.Empty)
                {
                    if (errMsg.Length != 0)
                        errMsg += "�A";

                    errMsg += "���J�J�n��";
                }

                if (applyEndDate == string.Empty)
                {
                    if (errMsg.Length != 0)
                        errMsg += "�A";

                    errMsg += "���J�I����";
                }

                TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                         this.Name,
                         errMsg + "����͂��Ă��������B",
                         0,
                         MessageBoxButtons.OK);
                return;
            }

            int rowNo = (int)this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Value;

            RecBgnGdsCustInfo recBgnGdsCustInfo = null;
            if (this._recBgnGdsAcs.RecBgnGdsCustInfoDic.ContainsKey(rowNo))
            {
                recBgnGdsCustInfo = this._recBgnGdsAcs.RecBgnGdsCustInfoDic[rowNo];
            }

            // �f�B�N�V���i�����Ȃ��ꍇ
            if (recBgnGdsCustInfo == null)
            {
                // �w�b�_�[
                RecBgnGdsDataSet.RecBgnGdsRow newRow = (RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[indexRow];
                recBgnGdsCustInfo = new RecBgnGdsCustInfo();
                recBgnGdsCustInfo.recBgnGdsRow = newRow;
                // ����
                RecBgnGdsDataSet.RecBgnCustDataTable recBgnCustDataTable = new RecBgnGdsDataSet.RecBgnCustDataTable();
                recBgnGdsCustInfo.recBgnCust = recBgnCustDataTable;
                this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Add(rowNo, recBgnGdsCustInfo);
            }

            if (recBgnGdsCustInfo != null)
            {
                PMREC09021UD recBgnCustDialog = new PMREC09021UD(recBgnGdsCustInfo);
                DialogResult dialogResult = recBgnCustDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    // �߂��Ă����l��ݒ�
                    recBgnGdsCustInfo.recBgnCust = recBgnCustDialog.RecBgnCustDataTable;

                    this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.CustUpdFlgColumn.ColumnName].Value = 1;
                    if (recBgnGdsCustInfo.recBgnCust.Count == 0)
                        this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Value = string.Empty;
                    else
                        this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Value = GOODSIMG_FILE_TRUE;
                }
                recBgnCustDialog.Close();
            }
            // --- ADD 2015/03/23 Y.Wakita----------<<<<<
        }

        /// <summary>
        /// ���דW�J����
        /// </summary>
        public bool GetUnitPrice(int rowIndex, string date, out long wkMkrSuggestRtPric, out long wkListPrice, out long wkUnitPrice)
        {
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

            string sectionCode = string.Empty;
            string msg = string.Empty;
            int customerCode = 0;
            bool uPricDiv = false;  // ADD 2015/03/26 Y.Wakita

            wkMkrSuggestRtPric = 0;
            wkListPrice = 0;
            wkUnitPrice = 0;

            // --- ADD 2015/03/04 Y.Wakita Redmine#319 ---------->>>>>
            // ���_
            sectionCode = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString();
            // --- ADD 2015/03/04 Y.Wakita Redmine#319 ----------<<<<<

            // ���i���
            object goodsUnitDataObj = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.goodsUnitDataColumn.ColumnName].Value;
            goodsUnitData = goodsUnitDataObj as GoodsUnitData;

            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            object mkrSuggestRtPricListObj = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricListColumn.ColumnName].Value;
            mkrSuggestRtPricList = mkrSuggestRtPricListObj as Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>;
            
            object mkrSuggestRtPricUListObj = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricUListColumn.ColumnName].Value;
            mkrSuggestRtPricUList = mkrSuggestRtPricUListObj as Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>;
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

            // ���J�J�n��
            DateTime startDate = DateTime.Parse(date);

            // ���i�擾
            // --- UPD 2015/03/04 Y.Wakita Redmine#319 ---------->>>>>
            //Calculator.GetUnitPrice(customerCode
            //                      , goodsUnitData
            //                      , startDate
            //                      , ALL_SECTION_CODE
            //                      , out wkMkrSuggestRtPric
            //                      , out wkListPrice
            //                      , out wkUnitPrice);
            // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
            //Calculator.GetUnitPrice(customerCode
            //                      , goodsUnitData
            //                      , startDate
            //                      , sectionCode
            //                      , out wkMkrSuggestRtPric
            //                      , out wkListPrice
            //                      , out wkUnitPrice);
            Calculator.GetUnitPrice(customerCode
                                  , goodsUnitData
                                  , startDate
                                  , sectionCode
                                  , mkrSuggestRtPricList
                                  , mkrSuggestRtPricUList
                                  , out uPricDiv    // ADD 2015/03/26 Y.Wakita
                                  , out wkMkrSuggestRtPric
                                  , out wkListPrice
                                  , out wkUnitPrice);
            // --- UPD 2015/03/25 Y.Wakita ----------<<<<<

            // --- ADD 2015/03/26 Y.Wakita ---------->>>>>
            RecBgnGdsDataSet.RecBgnGdsRow row = this._recBgnGdsDataTable[rowIndex];
            int retPartsFlag = 0;
            int status = this._recBgnGdsAcs.GetPartsArticleInfo(goodsUnitData, uPricDiv, out retPartsFlag);
            row.ModelFitDiv = (short)retPartsFlag;     // �K���Ԏ�敪
            // --- ADD 2015/03/26 Y.Wakita ----------<<<<<

            return true;
        }

        /// <summary>
        /// ���_�`�F�b�N����
        /// </summary>
        public bool SectionCheck_Detail(string sectionCode, int rowIndex)
        {
            string errMsg;
            SecInfoSet retSectionInfo;

            bool checkResult = this._recBgnGdsAcs.CheckSection(sectionCode, false, out errMsg, out retSectionInfo);
            if (checkResult)
            {
                Int32 chkSectionCode = 0;
                Int32.TryParse(sectionCode, out chkSectionCode);
                if (chkSectionCode == 0)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value = ALL_SECTION_CODE;  //���_�R�[�h
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Value = ALL_SECTION_NAME;  //���_����
                    this._swSectionInfo = sectionCode;
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value = retSectionInfo.SectionCode.Trim().PadLeft(2, '0'); //���_�R�[�h
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Value = retSectionInfo.SectionGuideNm; //���_����
                    this._swSectionInfo = retSectionInfo.SectionCode.Trim().PadLeft(2, '0');
                }
            }
            else
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_EXCLAMATION
                             , this.Name
                             , errMsg
                             , 0
                             , MessageBoxButtons.OK);

                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value = this._swSectionInfo.ToString().PadLeft(2, '0');
            }
            return checkResult;
        }

        /// <summary>
        /// �O���b�h �Z���ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;

            if (e.Cell.Column.Key == this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // ���͒l���擾
                Int32.TryParse(e.Cell.Text, out inputValue);

                // --- DEL 2015/03/16 Y.Wakita ��Q ---------->>>>>
                #region �폜
                //if (inputValue == 0)
                //{
                //    // �`�F�b�NOFF

                //    // ���������i��ٰ��
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = 0;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.NoEdit;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;

                //    // ���������i��ٰ�ߖ�
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = string.Empty;
                //    // ���[�J�[���i
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value = 0;
                //    // �W�����i
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.ListPriceColumn.ColumnName].Value = 0;

                //    // ������
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value = 0;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.NoEdit;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;

                //    // ���P��
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Value = 0;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.NoEdit;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;
                //}
                //else
                //{
                //    // �`�F�b�NON
                //    // ���i�擾
                //    this.SetUnitPrice(e.Cell.Row.Index);
                //    // ���������i��ٰ��
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;

                //    // ������
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;

                //    // ���P��
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.AllowEdit;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor = Color.Empty;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                //}

                //// ���i���v���r���[�\��
                //this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                //this._rowIndex = e.Cell.Row.Index;
                #endregion
                // --- DEL 2015/03/16 Y.Wakita ��Q ----------<<<<<
                // --- ADD 2015/03/16 Y.Wakita ��Q ---------->>>>>
                this.ChangeDisplayDiv(e.Cell.Row.Index, inputValue);
                // --- ADD 2015/03/16 Y.Wakita ��Q ----------<<<<<
            }
        }

        /// <summary>
        /// �O���b�h �s�ړ����C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_BeforeRowActivate(object sender, RowEventArgs e)
        {

            // �i��
            this._swGoodsNo = e.Row.Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString().Trim();
            // Ұ��
            this._swGoodsMakerCd = (Int32)e.Row.Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value;
            // ���J�J�n��
            this._swApplyStaDate = e.Row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString();
            // ���J�I����
            this._swApplyEndDate = e.Row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value.ToString();

        }

        /// <summary>
        /// �O���b�h �Z���񊈐����C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

                UltraGridCell cell = this.uGrid_Details.ActiveCell;

                switch (cell.Column.Key)
                {
                    case "ApplyStaDate":    // ���J�J�n��
                        if (cell.Text == this._swApplyStaDate) break;

                        // ���i�擾
                        this.SetUnitPrice(cell.Row.Index);

                        // �ʐݒ�폜
                        this.DelRecBgnGdsCustInfo(cell.Row.Index);

                        this._swApplyStaDate = cell.Value.ToString();

                        this.PreviewColumnSync(cell.Row.Index, cell.Column.Key);
                        break;
                    
                    case "ApplyEndDate":    // ���J�I����
                        if (cell.Text == this._swApplyEndDate) break;

                        this._swApplyEndDate = cell.Value.ToString();

                        this.PreviewColumnSync(cell.Row.Index, cell.Column.Key);
                        break;
                }
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            }
        }

        /// <summary>
        /// �O���b�h �s�񊈐����C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_BeforeRowDeactivate(object sender, CancelEventArgs e)
        {
            if (_rowIndex < 0) return;

            UltraGridCell cell_RowNo = this.uGrid_Details.Rows[_rowIndex].Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName];
            UltraGridCell cell_RowDel = this.uGrid_Details.Rows[_rowIndex].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName];

            if (cell_RowDel.Text == "0")
            {
                // �I���s�̇��̐F��ς���
                cell_RowNo.Appearance.BackColor = Color.Empty;
                cell_RowNo.Appearance.BackColor2 = Color.Empty;
                cell_RowNo.Appearance.BackColorDisabled = Color.Empty;
                cell_RowNo.Appearance.BackColorDisabled2 = Color.Empty;
            }
        }

        // --- ADD 2015/03/16 Y.Wakita ��Q ---------->>>>>
        /// <summary>
        /// ���J�敪�ύX���C�x���g
        /// </summary>
        /// <param name="index"></param>
        /// <param name="inputValue"></param>
        public void ChangeDisplayDiv(int index, int inputValue)
        {
            if (inputValue == 0)
            {
                // �`�F�b�NOFF

                // ���������i��ٰ��
                // --- DEL 2015/03/16 Y.Wakita �v�] ---------->>>>>
                //this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = 0;
                // --- DEL 2015/03/16 Y.Wakita �v�] ----------<<<<<
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.NoEdit;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;

                // --- DEL 2015/03/16 Y.Wakita �v�] ---------->>>>>
                //// ���������i��ٰ�ߖ�
                //this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = string.Empty;
                //// ���[�J�[���i
                //this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value = 0;
                //// �W�����i
                //this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.ListPriceColumn.ColumnName].Value = 0;
                // --- DEL 2015/03/16 Y.Wakita �v�] ----------<<<<<

                // ������
                // --- DEL 2015/03/16 Y.Wakita �v�] ---------->>>>>
                //this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value = 0;
                // --- DEL 2015/03/16 Y.Wakita �v�] ----------<<<<<
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.NoEdit;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;

                // ���P��
                // --- DEL 2015/03/16 Y.Wakita �v�] ---------->>>>>
                //this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Value = 0;
                // --- DEL 2015/03/16 Y.Wakita �v�] ----------<<<<<
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.NoEdit;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;
            }
            else
            {
                // �`�F�b�NON
                // --- DEL 2015/03/16 Y.Wakita �v�] ---------->>>>>
                //// ���i�擾
                //this.SetUnitPrice(index);
                // --- DEL 2015/03/16 Y.Wakita �v�] ----------<<<<<
                // ���������i��ٰ��
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;

                // ������
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;

                // ���P��
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.AllowEdit;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor = Color.Empty;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
            }

            // ���i���v���r���[�\��
            this.PreviewColumnSync(index, this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName);
            this._rowIndex = index;       
        }
        // --- ADD 2015/03/16 Y.Wakita ��Q ----------<<<<<
        // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
        /// <summary>
        /// CheckCustDisplayDiv
        /// </summary>
        /// <param name="RowIndex"></param>
        /// <returns></returns>
        public bool CheckCustDisplayDiv(int RowIndex)
        {
            bool ret = false;

            if (this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Count == 0) return ret;

            RecBgnGdsCustInfo recBgnGdsCustInfo = null;
            if (this._recBgnGdsAcs.RecBgnGdsCustInfoDic.ContainsKey(RowIndex))
            {
                recBgnGdsCustInfo = this._recBgnGdsAcs.RecBgnGdsCustInfoDic[RowIndex];
            }

            // �f�B�N�V���i�����Ȃ��ꍇ
            if (recBgnGdsCustInfo == null)
            {
                return ret;
            }
            else
            {
                foreach (RecBgnGdsDataSet.RecBgnCustRow RecBgnCustRow in recBgnGdsCustInfo.recBgnCust)
                {
                    if (RecBgnCustRow.DisplayDivCode == 1)
                    {
                        ret = true;
                        break;
                    }
                }
            }

            return ret;
        }
        // --- ADD 2015/03/23 Y.Wakita ----------<<<<<

        // --- ADD 2015/03/24 Y.Wakita ---------->>>>>
        /// <summary>
        /// uGrid_Details_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Recapture"].SharedProps.Enabled = false;
            this.uButton_Recapture.Enabled = false;
        }
        // --- ADD 2015/03/24 Y.Wakita ----------<<<<<
    }

    # region RecBgnGdsUserSet
    /// <summary>
    /// ���������i�ݒ�}�X�^�p�O���b�h�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���������i�ݒ�}�X�^�p�O���b�h�ݒ�N���X</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RecBgnGdsUserSet
    {
        // �o�͌`��
        private int _outputStyle;

        // ���׃O���b�h�J�������X�g
        private List<ColumnInfo> _detailColumnsList;

        // ���׃O���b�h�����T�C�Y����
        private bool _autoAdjustDetail;

        # region �R���X�g���N�^
        /// <summary>
        /// ���������i�ݒ�}�X�^�p�O���b�h�ݒ�N���X
        /// </summary>
        public RecBgnGdsUserSet()
        {

        }
        # endregion

        /// <summary>�o�͌^��</summary>
        public int OutputStyle
        {
            get { return this._outputStyle; }
            set { this._outputStyle = value; }
        }

        /// <summary>���׃O���b�h�J�������X�g</summary>
        public List<ColumnInfo> DetailColumnsList
        {
            get { return this._detailColumnsList; }
            set { this._detailColumnsList = value; }
        }

        /// <summary>���׃O���b�h�����T�C�Y����</summary>
        public bool AutoAdjustDetail
        {
            get { return _autoAdjustDetail; }
            set { _autoAdjustDetail = value; }
        }
    }
    # endregion

    # region [ColumnInfo]
    /// <summary>
    /// ColumnInfo
    /// </summary>
    [Serializable]
    public struct ColumnInfo
    {
        /// <summary>��</summary>
        private string _columnName;

        /// <summary>��</summary>
        private int _width;

        /// <summary>
        /// ��
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        /// <summary>
        /// ��
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="columnName">��</param>
        /// <param name="width">��</param>
        public ColumnInfo(string columnName, int width)
        {
            _columnName = columnName;
            _width = width;
        }
    }
    # endregion
}
