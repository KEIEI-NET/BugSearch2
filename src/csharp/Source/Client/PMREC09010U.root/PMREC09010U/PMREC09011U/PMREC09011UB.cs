//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����h���i�֘A�ݒ�}�X�^
// �v���O�����T�v   : ���R�����h���i�֘A�ݒ�}�X�^�̕ێ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/01/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : ���B
// �� �� ��  2015/02/09  �C�����e : �@�Z���̌���
//                                  �A�}���A�R�s�[�A�\��t���@�\�̒ǉ�
//                                  �B���͕ۊǁi��̃Z�����R�s�[�j�@�\��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/02/10  �C�����e : �@BL�R�[�h���͎��ɏ��i�R�����g(��)��\��
//                                  �A���ׂ̊m�蔻������i�R�����g��ɏC��
// �� �� ��  2015/02/10  �C�����e : �V�X�e���e�X�g��Q#183
//                                  �E���Z���̃N���b�N�ōs�I����Ԃɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/02/12  �C�����e : �V�X�e���e�X�g��Q#195,196
//                                  �E�V�K�s�Ɋ�{���̓��Ӑ�\�����ɖ⍇������ƁE���_���Z�b�g
//                                  �V�X�e���e�X�g��Q#203
//                                  �E���א擪�s�ł͑O�s�̒l���R�s�[���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c���V
// �� �� ��  2015/02/16  �C�����e : �V�X�e���e�X�g��Q#217
//                                  �E���Ӑ�R�[�h�𖢓��͂ŕۑ�����ƃG���[���\�������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/02  �C�����e : �T���v���捞���̓o�^�σ`�F�b�N�ɐV�K���͖��ׂ��܂߂�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/02  �C�����e : Redmine#217
//                                  �ۑ��`�F�b�N���ɓ��Ӑ斢���͂̏ꍇ�A����ƁE�����_�Ƀ[�����Z�b�g
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/04  �C�����e : Redmine#318 �T���v���捞���̐V�K���͖��ׂƂ̏d���`�F�b�N��
//                                              ���͒�(���m��)�̖��ׂ͑ΏۊO�ɂ���
//                                  Redmine#321 �T���v���捞���̐V�K���͖��ׂƂ̏d���`�F�b�N��
//                                              �X�y�[�X�J�b�g���ăR�[�h�̔�r���s���悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c���V
// �� �� ��  2015/03/05  �C�����e : Redmine#330 �}��������͂���ƕۑ����ɃG���[���\�������
// �@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ Redmine#332 �폜���[�h�Ō������A���׍s�̉E�N���b�N�Łu�폜�v�ȊO�̋@�\���I���ł��Ă��܂�
// �@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ Redmine#333 �E�N���b�N�̍s�R�s�[��I�������Ƃ��̖��ׂ̐F���s�폜�Ɠ����F�ł킩�肸�炢
// �@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ Redmine#335 �����̖͂��ׂ��s�R�s�[����ƃG���[���\�������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/06  �C�����e : Redmine#338 �S���Ӑ�ݒ���e��萔��
//                                  Redmine#341 �\��t�����ɃR�s�[���̍폜�敪�͈����p���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/09  �C�����e : Redmine#341 ������BL�R�[�h�ȍ~�̓��͉ېݒ��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �� �B
// �� �� ��  2015/03/13  �C�����e : ���_�R�[�h��0���߂���Ȃ���Q�̏C��
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���R�����h���i�֘A�ݒ�}�X�^ ���׃R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^ ���׃R���g���[���N���X</br>
    /// <br>Programmer : �{�{����</br>
    /// <br>Date       : 2015/01/20</br>
    /// </remarks>
    public partial class PMREC09011UB : UserControl
    {
        # region Private Members
        private RecGoodsLkDataSet.RecGoodsLkDataTable _recGoodsLkDataTable;
        private RecGoodsLkStAcs _recGoodsLkStAcs = null;
        private Dictionary<Guid, RecGoodsLkSt> _prevRecGoodsLkDic = new Dictionary<Guid, RecGoodsLkSt>();

        private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

        private const string TOOLBAR_ROWDELETEBUTTON_KEY = "ButtonTool_RowDelete";     // �s�폜
        private const string TOOLBAR_ROWDELETEBUTTON_KEY1 = "ButtonTool_RowDelete1";     // �s�폜
        private const string TOOLBAR_ALLDELETEBUTTON_KEY = "ButtonTool_AllRowDelete";  // �S�폜
        private const string TOOLBAR_REVIVALBUTTON_KEY   = "ButtonTool_Revival";       // ����
        // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
        private const string TOOLBAR_ROWINSERTBUTTON_KEY =  "ButtonTool_RowInsert";  // �s�}��
        private const string TOOLBAR_ROWCUTBUTTON_KEY    =  "ButtonTool_RowCut";     // �؂���
        private const string TOOLBAR_ROWCOPYBUTTON_KEY   =  "ButtonTool_RowCopy";    // �R�s�[
        private const string TOOLBAR_ROWPASTEBUTTON_KEY  =  "ButtonTool_RowPaste";    // �\��t��
        // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<


        // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------>>>>>
        private const int DELETEFLG_DEFAULT = 0;       // �ʏ�
        private const int DELETEFLG_DELETE  = 1;       // �폜
        private const int DELETEFLG_REVIVAL = 2;       // ����
        private const int DELETEFLG_SAMPLE  = 9;       // �T���v���捞
        // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------<<<<<

        // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
        /// <summary>�s�X�e�[�^�X�i�ʏ�s�j</summary>
        public static readonly int ctROWSTATUS_NORMAL = 0;
        /// <summary>�s�X�e�[�^�X�i�R�s�[�s�j</summary>
        public static readonly int ctROWSTATUS_COPY = 1;
        /// <summary>�s�X�e�[�^�X�i�J�b�g�s�j</summary>
        public static readonly int ctROWSTATUS_CUT = 2;

        private static readonly Color ct_ROWSTATUS_COPY_COLOR = Color.Pink;
        private static readonly Color ct_ROWSTATUS_CUT_COLOR = Color.Gray;
        // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<


        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "PMREC09010U_Construction.XML";

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;
        private string _loginSectionCode = string.Empty;

        /// <summary>���Ӑ�R�[�h</summary>
        private string _swCustomerInfo = string.Empty;
        /// <summary>���_�R�[�h</summary>
        private string _swSectionInfo = string.Empty;
        /// <summary>������BL�R�[�h</summary>
        private int _swRecSourceBLGoodsCd = 0;
        /// <summary>������BL�R�[�h</summary>
        private int _swRecDestBLGoodsCd = 0;
        // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
        /// <summary>���i�R�����g</summary>
        private string _swGoodsComment = string.Empty;
        // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<

        private CustomerSearchRet _customerSearchRet = null;
        //private SectionSearchRet _customerSearchRet = null;

        /// <summary>DCKHN09092A)BL�R�[�h</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;

        private bool focusFlg = true;
        private bool leftFocusFlg = false;

        // ���[�U�[�ݒ�
        private RecGoodsLkUserSet _userSetting;
        private SecInfoSetAcs _secInfoSetAcs;
        private UserGuideAcs _userGuideAcs;

        private ImageList _imageList16 = null;

        // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------>>>>>
        internal event SetSampleButtonEventHandler SetSampleButton;
        internal delegate void SetSampleButtonEventHandler(Boolean enable);
        // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------<<<<<

        internal event SetGuidButtonEventHandler SetGuidButton;
        internal delegate void SetGuidButtonEventHandler(Boolean enable);

        internal event GetCustomerInfoEventHandler GetCustomerInfo;
        internal delegate void GetCustomerInfoEventHandler(out Int32 customerCode, out string customerName);

        internal event GetSectionInfoEventHandler GetSectionInfo;
        internal delegate void GetSectionInfoEventHandler(out string sectionCode, out string sectionName);


        /// <summary>�t�H�[�J�X�̕ω�</summary>
        internal event EventHandler GridKeyUpTopRow;
        #endregion

        #region �v���p�e�B
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^ �A�N�Z�X�N���X�v���p�e�B
        /// </summary>
        public RecGoodsLkStAcs RecGoodsLkStAcs
        {
            get { return this._recGoodsLkStAcs; }
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
        public RecGoodsLkUserSet UserSetting
        {
            get { return this._userSetting; }
        }
        #endregion

        # region Constroctors
        /// <summary>
        /// ���͖��ד��̓R���g���[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���͖��ד��̓R���g���[���N���X �f�t�H���g���s���R���g���[���N���X�ł��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public PMREC09011UB()
        {
            InitializeComponent();
            this._recGoodsLkStAcs = new RecGoodsLkStAcs();
            this._recGoodsLkDataTable = this._recGoodsLkStAcs.RecGoodsLkDataTable;

            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._userGuideAcs = new UserGuideAcs();

            this._userSetting = new RecGoodsLkUserSet();

            this._imageList16 = IconResourceManagement.ImageList16; // ADD 2015/03/06 T.Miyamoto Redmine#339
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void PMREC09011UB_Load(object sender, EventArgs e)
        {
            // �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
            this.uGrid_Details.DataSource = this._recGoodsLkStAcs.RecGoodsLkDataTable;

            // --- ADD 2015/03/06 T.Miyamoto Redmine#339 ------------------------------>>>>>
            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();
            // --- ADD 2015/03/06 T.Miyamoto Redmine#339 ------------------------------<<<<<

            // �O���b�h�N���A
            this.Clear(false);
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note	   : �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �s�폜
                case TOOLBAR_ROWDELETEBUTTON_KEY:
                case TOOLBAR_ROWDELETEBUTTON_KEY1:
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
                // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
                // �s�}��
                case TOOLBAR_ROWINSERTBUTTON_KEY:
                    {
                        this.uButton_RowInsert_Click(this.uButton_RowInsert, new EventArgs());
                        break;
                    }
                // �؂���
                case TOOLBAR_ROWCUTBUTTON_KEY:
                    {
                        this.uButton_RowCut_Click(this.uButton_RowCut, new EventArgs());
                        break;
                    }
                // �R�s�[
                case TOOLBAR_ROWCOPYBUTTON_KEY:
                    {
                        this.uButton_RowCopy_Click(this.uButton_RowCopy, new EventArgs());
                        break;
                    }
                // �\��t��
                case TOOLBAR_ROWPASTEBUTTON_KEY:
                    {
                        this.uButton_RowPaste_Click(this.uButton_RowPaste, new EventArgs());
                        break;
                    }
                // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<

            }
        }

        // --- ADD 2015/03/06 T.Miyamoto Redmine#339 ------------------------------>>>>>
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowInsert"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWINSERT;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWDELETE;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowCopy"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWCOPY;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowPaste"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWPASTE;
        }
        // --- ADD 2015/03/06 T.Miyamoto Redmine#339 ------------------------------<<<<<

        /// <summary>
        /// ���׏������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note	   : ���׏������C�x���g���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
                        if ((int)row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                        {
                            //�폜�w��敪:0
                            if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                            {
                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                                    this.SetGuidButton(false);
                                }

                                // �s�폜��BackColor�̐ݒ�(�s���N�F)�A���͋��ݒ�
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName) // ADD 2015/02/10 �s�F T.Miyamoto
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                    }
                                    cell.Activation = Activation.NoEdit;
                                }
                                row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                            }
                            //�폜�w��敪:1
                            else
                            {
                                // �s�폜��BackColor�̐ݒ�(�s���N�F)�A���͋��ݒ�
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName) // ADD 2015/02/10 �s�F T.Miyamoto
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                        // --- ADD 2015/02/10 �s�F T.Miyamoto ------------------------------>>>>>
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                        // --- ADD 2015/02/10 �s�F T.Miyamoto ------------------------------<<<<<
                                    }
                                }
                                row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                            }
                        }
                        else
                        {
                            //�폜�w��敪:0
                            if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                            {
                                #region �s�폜����
                                // �V�K�s�̔��f
                                bool isNewRow = false;
                                if ((Guid)row.Cells[this._recGoodsLkDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                                {
                                    isNewRow = true;
                                }

                                #region ���͋��ݒ�
                                row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit; // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�
                                if (isNewRow == true)
                                {
                                    row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                    row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;
                                }
                                #endregion

                                // �s�폜������BackColor�̐ݒ�(�ʏ�F)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Activation == Activation.NoEdit
                                     && cell.Column.Key != this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }

                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    this.uGrid_Details.ActiveCell.Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    if (this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName
                                     || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName
                                     || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName
                                     || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName
                                     || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName) // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�
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
                                row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
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
                                    if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                                row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
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
        /// �S�폜����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �S�폜�������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
                if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                {
                    for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                    {
                        if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value == 0)
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
                            if ((Guid)row.Cells[this._recGoodsLkDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                            {
                                isNewRow = true;
                            }
                            row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                            row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                            row.Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit; // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�
                            if (isNewRow == true)
                            {
                                row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;
                            }
                        }
                        #endregion

                        // �s�폜������BackColor�̐ݒ�(�ʏ�F)
                        foreach (UltraGridRow row in this.uGrid_Details.Rows)
                        {
                            if ((int)row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value == 1)
                            {
                                // �s�폜������BackColor�̐ݒ�(�ʏ�F)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Activation != Activation.NoEdit
                                        || cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                            }

                            row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        if (this.uGrid_Details.ActiveCell != null)
                        {
                            if (this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName
                             || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName
                             || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName
                             || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName
                             || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName) // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�
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
                            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                            {
                                // �s�폜��BackColor�̐ݒ�(�s���N�F)�A���͋��ݒ�
                                foreach (UltraGridCell cell in this.uGrid_Details.Rows[rowIndex].Cells)
                                {
                                    if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName) // ADD 2015/02/10 �s�F T.Miyamoto
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                    }
                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                        }
                    }

                }
                //�폜�w��敪:1
                else
                {
                    for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                    {
                        if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
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
                            if ((int)row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value == 1)
                            {
                                // �s�폜������BackColor�̐ݒ�(�ʏ�F)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                        // --- ADD 2015/02/10 �s�F T.Miyamoto ------------------------------>>>>>
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                        // --- ADD 2015/02/10 �s�F T.Miyamoto ------------------------------<<<<<
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColorDisabled = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColorDisabled2 = ct_DISABLE_COLOR;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;

                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                    }
                    else
                    {
                        for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                        {
                            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                            {
                                // �s�폜��BackColor�̐ݒ�(�s���N�F)�A���͋��ݒ�
                                foreach (UltraGridCell cell in this.uGrid_Details.Rows[rowIndex].Cells)
                                {
                                    if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName) // ADD 2015/02/10 �s�F T.Miyamoto
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                        // --- ADD 2015/02/10 �s�F T.Miyamoto ------------------------------>>>>>
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                        // --- ADD 2015/02/10 �s�F T.Miyamoto ------------------------------<<<<<
                                    }
                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
                        if ((int)this.uGrid_Details.Rows[row.Index].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value != 2)
                        {
                            //��������
                            foreach (UltraGridCell cell in this.uGrid_Details.Rows[row.Index].Cells)
                            {
                                // --- UPD 2015/02/10 �s�F T.Miyamoto ------------------------------>>>>>
                                //if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                //{
                                //    cell.Appearance.BackColor = Color.Empty;
                                //    cell.Appearance.BackColor2 = Color.Empty;
                                //    cell.Appearance.BackColorDisabled = Color.Empty;
                                //    cell.Appearance.BackColorDisabled2 = Color.Empty;
                                //    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                //}
                                //else
                                //{
                                //    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                //    cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                //    cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                //    cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                //    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                //}
                                if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                {
                                    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                    cell.Appearance.ForeColor = ct_DISABLE_FONT_COLOR;
                                    cell.Appearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
                                }
                                // --- UPD 2015/02/10 �s�F T.Miyamoto ------------------------------<<<<<
                            }

                            this.uGrid_Details.Rows[row.Index].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 2;
                        }
                        else
                        {
                            //������������
                            foreach (UltraGridCell cell in this.uGrid_Details.Rows[row.Index].Cells)
                            {
                                // --- UPD 2015/02/10 �s�F T.Miyamoto ------------------------------>>>>>
                                //if (cell.Column.Key != this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                //{
                                //    cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                //    cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                                //    cell.Appearance.BackColorDisabled = ct_DISABLE_COLOR;
                                //    cell.Appearance.BackColorDisabled2 = ct_DISABLE_COLOR;
                                //    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                //}
                                if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                {
                                    cell.Appearance.BackColor = Color.Empty;
                                    cell.Appearance.BackColor2 = Color.Empty;
                                    cell.Appearance.BackColorDisabled = Color.Empty;
                                    cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                    cell.Appearance.ForeColor = Color.Empty;
                                    cell.Appearance.ForeColorDisabled = Color.Empty;
                                }
                                // --- UPD 2015/02/10 �s�F T.Miyamoto ------------------------------<<<<<
                            }

                            this.uGrid_Details.Rows[row.Index].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
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
        /// �Z���̃f�[�^�`�F�b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : �Z���̃f�[�^�`�F�b�N�����B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
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
                            editorBase.Value = 0;				// 0���Z�b�g
                            this.uGrid_Details.ActiveCell.Value = 0;
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
        /// <br>Note       : �O���b�h�Z���A�N�e�B�u�㔭���C�x���g</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            this.SetGridGuid();
            this.SetSampleButton(true);
        }

        /// <summary>
        /// �O���b�h�Z���ҏW���[�h�ɓ������㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���ҏW���[�h�ɓ������㔭���C�x���g</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
            }
        }

        /// <summary>
        /// �O���b�h�Z���o��㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���o��㔭���C�x���g</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
                UltraGridCell cell = this.uGrid_Details.ActiveCell;
                UltraGridRow row = this.uGrid_Details.ActiveCell.Row;
                if (cell.Value == null)
                {
                    return;
                }


                // ���Ӑ�R�[�h
                if (cell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName)
                {
                    // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
                    //int inputValue = 0;
                    //// ���͒l���擾
                    //Int32.TryParse(cell.Value.ToString(), out inputValue);
                    string inputValue = string.Empty;
                    // ���͒l���擾
                    inputValue = cell.Value.ToString().Trim();
                    // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<
                    // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
                    //// --- UPD 2015/02/12 T.Miyamoto ����ýď�Q#203 ------------------------------>>>>>
                    ////if (inputValue == 0 && row.Index != -1)
                    if (inputValue == string.Empty && row.Index > 0)
                    // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<
                    // --- UPD 2015/02/12 T.Miyamoto ����ýď�Q#203 ------------------------------<<<<<
                    {
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = this.uGrid_Details.Rows[cell.Row.Index - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value;
                    }
                }


                // ���_�R�[�h
                else if (cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName)
                {
                    string inputValue = "";
                    // ���͒l���擾
                    inputValue = cell.Value.ToString().Trim();
                    // --- UPD 2015/02/12 T.Miyamoto ����ýď�Q#203 ------------------------------>>>>>
                    //if (inputValue == "" && row.Index != -1)
                    if (inputValue == "" && row.Index > 0)
                    // --- UPD 2015/02/12 T.Miyamoto ����ýď�Q#203 ------------------------------<<<<<
                    {
                        // --- UPD 2015/03/13 T.Nishi ------------------------------>>>>>
                        //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.uGrid_Details.Rows[cell.Row.Index - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.uGrid_Details.Rows[cell.Row.Index - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString().Trim().PadLeft(2, '0');
                        // --- UPD 2015/03/13 T.Nishi ------------------------------<<<<<
                    }
                }


                // ������BL����/������BL����
                else if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                {
                    int inputValue = 0;
                    // ���͒l���擾
                    Int32.TryParse(cell.Value.ToString(), out inputValue);
                    // --- UPD 2015/02/12 T.Miyamoto ����ýď�Q#203 ------------------------------>>>>>
                    //if (inputValue == 0 && row.Index != -1)
                    if (inputValue == 0 && row.Index > 0)
                    // --- UPD 2015/02/12 T.Miyamoto ����ýď�Q#203 ------------------------------<<<<<
                    {
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = this.uGrid_Details.Rows[cell.Row.Index - 1].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value;
                    }
                }


                // ���Ӑ�R�[�h
                if (cell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName)
                {
                    int inputValue = 0;
                    // ���͒l���擾
                    Int32.TryParse(cell.Value.ToString(), out inputValue);

                    if (!this.CustomerCheck_Detail(inputValue, cell.Row.Index))
                    {
                        this.focusFlg = false;
                    }
                }

                // ���_�R�[�h
                else if (cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName)
                {
                    string inputValue = "";
                    // ���͒l���擾
                    inputValue = cell.Value.ToString().Trim();
                    if (!this.SectionCheck_Detail(inputValue, cell.Row.Index))
                    {
                        this.focusFlg = false;
                    }
                }


                // ������BL����/������BL����
                else if ((cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                      || (cell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName))
                {
                    int inputValue = 0;
                    // ���͒l���擾
                    Int32.TryParse(cell.Value.ToString(), out inputValue);
                    if (inputValue != 0)
                    {
                        BLGoodsCdUMnt blGoodsCdUMnt = null;
                        if (this._recGoodsLkStAcs.BLGoodsCdDic.ContainsKey(inputValue))
                        {
                            blGoodsCdUMnt = this._recGoodsLkStAcs.BLGoodsCdDic[inputValue];
                        }

                        if (blGoodsCdUMnt != null)
                        {
                            if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                            {
                                this._swRecSourceBLGoodsCd = blGoodsCdUMnt.BLGoodsCode;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsCode;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsHalfName;
                            }
                            else
                            {
                                this._swRecDestBLGoodsCd = blGoodsCdUMnt.BLGoodsCode;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsCode;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsHalfName;
                            }
                            // --- ADD 2015/02/10�@ T.Miyamoto ------------------------------>>>>>
                            // BL�R�[�h���珤�i�R�����g(��)���擾
                            this.GoodsCommentDsp(cell.Row.Index);
                            // --- ADD 2015/02/10�@ T.Miyamoto ------------------------------<<<<<
                        }
                        else
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�a�k�R�[�h�����݂��܂���B",
                            -1,
                            MessageBoxButtons.OK);

                            if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                            {
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = this._swRecSourceBLGoodsCd;
                            }
                            else
                            {
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value = this._swRecDestBLGoodsCd;
                            }
                            this.focusFlg = false;
                        }
                    }
                    else
                    {
                        if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                        {
                            this._swRecSourceBLGoodsCd = 0;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = 0;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Value = string.Empty;
                        }
                        else
                        {
                            this._swRecDestBLGoodsCd = 0;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value = 0;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Value = string.Empty;
                        }
                    }
                }
                // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<
            }
        }

        /// <summary>
        /// �O���b�h�Z���A�N�e�B�u�O�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���A�N�e�B�u�O�����C�x���g</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;

            this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Off; // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�

            if (cell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName)
            {
                this._swCustomerInfo = e.Cell.Value.ToString().Trim();
            }
            else if (cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName)
            {
                this._swSectionInfo = e.Cell.Value.ToString().Trim();
            }
            else if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
            {
                this._swRecSourceBLGoodsCd = (Int32)e.Cell.Value;
            }
            else if (cell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName)
            {
                this._swRecDestBLGoodsCd = (Int32)e.Cell.Value;
            }
            // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
            else if (cell.Column.Key == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName)
            {
                this._swGoodsComment = e.Cell.Value.ToString().Trim();
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            }
            // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
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

            if (this.uGrid_Details.ActiveCell.IsInEditMode)
            {
                if (e.KeyCode == Keys.Left && this.uGrid_Details.ActiveCell.SelStart != 0)
                {
                    return;
                }
                if (e.KeyCode == Keys.Right && this.uGrid_Details.ActiveCell.SelStart < this.uGrid_Details.ActiveCell.Text.Length)
                {
                    return;
                }
                if (e.KeyCode == Keys.Escape)
                {
                    return;
                }
            }

            switch (e.KeyCode)
            {
				case Keys.Escape:
    				{
					    // ���׃f�[�^�e�[�u��RowStatus�񏉊�������
					    this.InitializeRecGoodsLkRowStatusColumn();

					    // ���׃O���b�h�Z���ݒ菈��
					    this.SettingGrid();
                        break;
    				}
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
                                if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                                {
                                    if (CheckDateForDown())
                                    {
                                        #region �ŏI�s�̏ꍇ�A�V�K�s��ǉ����� --DEL
                                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------>>>>>
                                        //RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
                                        //newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                                        //newRow.FilterGuid = Guid.Empty;
                                        //newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                                        //newRow.InqOtherEpCd = this._enterpriseCode;
                                        ////newRow.InqOtherSecCd = this._loginSectionCode;

                                        //this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);

                                        //this.DetailGridInitSetting();
                                        //#endregion

                                        ////���Ӑ���̏����l�Z�b�g
                                        //Int32 customerCode = 0;
                                        //string customerName = string.Empty;
                                        //this.GetCustomerInfo(out customerCode, out customerName);
                                        //if (customerCode != 0)
                                        //{
                                        //    this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = customerCode;
                                        //    this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = customerName;
                                        //}

                                        ////���_���̏����l�Z�b�g
                                        //string sectionCode = string.Empty;
                                        //string sectionName = string.Empty;
                                        //this.GetSectionInfo(out sectionCode, out sectionName);
                                        //if (sectionCode != string.Empty)
                                        //{
                                        //    this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode;
                                        //    this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = sectionName;
                                        //}

                                        ////�����t�H�[�J�X�ʒu�Z�b�g
                                        //if (customerCode != 0 || sectionCode != string.Empty)
                                        //{
                                        //    if (sectionCode == string.Empty)
                                        //    {
                                        //        this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                        //    }
                                        //    else if (customerCode == 0)
                                        //    {
                                        //        this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                                        //    }
                                        //    else
                                        //    {
                                        //        this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    //�����Ƃ��󔒂̏ꍇ�͋��_�R�[�h�Ƀt�H�[�J�X�Z�b�g
                                        //    this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                        //}
                                        #endregion 
                                        this.NewRowAdd(rowIndex + 1);
                                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------<<<<<

                                        RecGoodsLkSt recGoodsLkSt = null;
                                        this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow((RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkDataTable.Rows[this._recGoodsLkDataTable.Count - 1], ref recGoodsLkSt);
                                        this._recGoodsLkStAcs.NewRecGoodsLkObj = recGoodsLkSt.Clone();
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

                        if (columnKey == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName
                         || columnKey == this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName)
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
                                    // --- UPD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
                                    //columnName = this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName;
                                    columnName = this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName;
                                    // --- UPD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<
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

                        if (columnKey == this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName)
                        {
                            // �Ȃ��B
                        }
                        // --- UPD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
                        //else if (columnKey == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName)
                        else if (columnKey == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName)
                        // --- UPD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<
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
                                        columnName = this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName;
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

            int colCount = 7;
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
        /// <br>Note       : �O���b�h�Z���A�v�f�g�㔭���C�x���g</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            // --- DEL 2015/02/09 T.Nishi ------------------------------>>>>>
            /*
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;
            UltraGridRow row = e.Cell.Row;

            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
            // ���Ӑ�R�[�h
            if (cell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // ���͒l���擾
                Int32.TryParse(cell.Value.ToString(), out inputValue);
                if (!this.CustomerCheck_Detail(inputValue, cell.Row.Index))
                {
                    this.focusFlg = false;
                }
            }

            // ���_�R�[�h
            else if (cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName)
            {
                string inputValue = "";
                // ���͒l���擾
                inputValue = cell.Value.ToString().Trim();
                if (!this.SectionCheck_Detail(inputValue.PadLeft(2, '0'), cell.Row.Index))
                {
                    this.focusFlg = false;
                }
            }


            // ������BL����/������BL����
            else if ((cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                  || (cell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName))
            {
                int inputValue = 0;
                // ���͒l���擾
                Int32.TryParse(cell.Value.ToString(), out inputValue);
                if (inputValue != 0)
                {
                    BLGoodsCdUMnt blGoodsCdUMnt = null;
                    if (this._recGoodsLkStAcs.BLGoodsCdDic.ContainsKey(inputValue))
                    {
                        blGoodsCdUMnt = this._recGoodsLkStAcs.BLGoodsCdDic[inputValue];
                    }

                    if (blGoodsCdUMnt != null)
                    {
                        if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                        {
                            this._swRecSourceBLGoodsCd = blGoodsCdUMnt.BLGoodsCode;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsCode;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsHalfName;
                        }
                        else
                        {
                            this._swRecDestBLGoodsCd = blGoodsCdUMnt.BLGoodsCode;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsCode;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsHalfName;
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�a�k�R�[�h�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                        if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                        {
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = this._swRecSourceBLGoodsCd;
                        }
                        else
                        {
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value = this._swRecDestBLGoodsCd;
                        }
                        this.focusFlg = false;
                    }
                }
                else
                {
                    if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                    {
                        this._swRecSourceBLGoodsCd = 0;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = 0;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Value = string.Empty;
                    }
                    else
                    {
                        this._swRecDestBLGoodsCd = 0;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value = 0;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Value = string.Empty;
                    }
                }
            }
            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            */ 
            // --- DEL 2015/02/09 T.Nishi ------------------------------<<<<<
        }

        // --- ADD 2015/02/10�@ T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// ���i�R�����g�\��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note       : �w��s��BL�R�[�h���͎��ɏ��i�R�����g(��)���擾���ĕ\������</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/10</br>
        /// </remarks>
        private void GoodsCommentDsp(int rowIndex)
        {
            int recSourceBLGoodsCd = 0;
            Int32.TryParse(this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value.ToString().Trim(), out recSourceBLGoodsCd);
            int recDestBLGoodsCd = 0;
            Int32.TryParse(this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value.ToString().Trim(), out recDestBLGoodsCd);

            if (recSourceBLGoodsCd != 0
             && recDestBLGoodsCd != 0
             && (this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Value.ToString().Trim() == string.Empty))
            {
                // BL�R�[�h���珤�i�R�����g(��)���擾
                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Value = this._recGoodsLkStAcs.SampleRead(recSourceBLGoodsCd, recDestBLGoodsCd);
            }
        }
        // --- ADD 2015/02/10�@ T.Miyamoto ------------------------------<<<<<

        /// <summary>
        /// �O���b�h�Z��KeyPress�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z��KeyPress�����C�x���g</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (!cell.IsInEditMode) return;

            //----------------------------------------------
            // ActiveCell�����Ӑ�R�[�h�̏ꍇ
            //----------------------------------------------
            if (cell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell�����_�R�[�h�̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell��������BL���ށA������BL���ނ̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName
                  || cell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(5, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
                if (col.Key != this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = ct_DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
                }
            }

            #region ���\�����ݒ�
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Width = 40;            // ��
            editBand.Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].Width = 80;       // �폜��
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Width = 60;     // ���_�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Width = 180;     // ���_����
            editBand.Columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Width = 80;     // ���Ӑ�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Width = 180;     // ���Ӑ旪��
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Width = 70; // ������BL�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Width = 220; // ������BL�R�[�h��
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Width = 70;   // ������BL�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Width = 240;   // ������BL�R�[�h��
            editBand.Columns[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Width = 400;   // ���i�R�����g
            #endregion

            #region ���Œ��ݒ�
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Header.Fixed = true;                                     // ��
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None; // ��
            // �s�ԍ���N���b�N���͍sActive
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // ADD 2015/02/10 ����ýď�Q#183 T.Miyamoto
            #endregion

            #region ��CellAppearance�ݒ�
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;           // ��
            editBand.Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;       // �폜��
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;    // ���_�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;      // ���_����
            editBand.Columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;    // ���Ӑ�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;      // ���Ӑ旪��
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // ������BL�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;  // ������BL�R�[�h��
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;   // ������BL�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;    // ������BL�R�[�h��
            editBand.Columns[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;    // ���i�R�����g

            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion

            #region �����͋��ݒ�
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;            // ��
            editBand.Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;         // �폜��
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;    // ���_�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;        // ���_����
            editBand.Columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;    // ���Ӑ�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;        // ���Ӑ旪��
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // ������BL�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;    // ������BL�R�[�h��
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;   // ������BL�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;      // ������BL�R�[�h��
            editBand.Columns[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;    // ���i�R�����g

            #endregion

            #region ��Style�ݒ�
            editBand.Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // �폜��
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // ���_�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;     // ���_����
            editBand.Columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // ���Ӑ�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;     // ���Ӑ旪��
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; // ������BL�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; // ������BL�R�[�h��
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;   // ������BL�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;   // ������BL�R�[�h��
            editBand.Columns[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;   // ���i�R�����g
            #endregion

            #region ���t�H�[�}�b�g�ݒ�
            
            string decimalFormat = "#,##0.00;-#,##0.00;''";
            string codeFormat1 = "#000000;-#0000000;''";
            string codeFormat2 = "#00;-#00;''";
            string codeFormat3 = "#0000;-#0000;''";
            string codeFormat4 = "#00000;-#00000;''";
            string codeFormat5 = "#00000000;-#00000000;''";
            editBand.Columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Format = codeFormat5;    // ���Ӑ�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Format = codeFormat2;    // ���_�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Format = codeFormat4; // ������BL�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Format = codeFormat4;   // ������BL�R�[�h
            
            #endregion

            #region ��MaxLength�ݒ�
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].MaxLength = 2;    // ���_�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].MaxLength = 8;    // ���Ӑ�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].MaxLength = 5; // ������BL�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].MaxLength = 5;   // ������BL�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].MaxLength = 200;   // ���i�R�����g
            #endregion

            #region ���O���b�h��\����\���ݒ菈��
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Hidden = false;           // ��
            editBand.Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].Hidden = true;       // �폜��
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Hidden = false;    // ���_�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Hidden = false;     // ���_����
            editBand.Columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Hidden = false;    // ���Ӑ�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Hidden = false;     // ���Ӑ旪��
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Hidden = false; // ������BL�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Hidden = false; // ������BL�R�[�h��
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Hidden = false;   // ������BL�R�[�h
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Hidden = false;   // ������BL�R�[�h��
            editBand.Columns[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Hidden = false;   // ���i�R�����g
            #endregion
            // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
            # region [�Z�������ݒ�]
            try
            {
                this.uGrid_Details.BeginUpdate();
                ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

                List<string> colNameList = new List<string>(new string[] 
                                            { 
                                                this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName,
                                                this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName,
                                                this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName,
                                                this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName,
                                                this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName,
                                                this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName,
                                                this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName,
                                                this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName
                                            });
                Infragistics.Win.Appearance margedCellAppearance = new Infragistics.Win.Appearance();

                for (int index = 0; index < colNameList.Count; index++)
                {
                    string colName = colNameList[index];

                    // CellAppearance�������I�ɓ��ꂷ��i�s���͏����j
                    if (!columns[colName].Key.Trim().Equals(this._recGoodsLkDataTable.RowNoColumn.ColumnName.Trim()))
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
                columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName);

                // ���_
                columns[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName);

                // ���Ӑ�F���_�A���Ӑ悪����̃Z��������
                columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName);

                // ���Ӑ�F���_�A���Ӑ悪����̃Z��������
                columns[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName);

                // ������BL���ށF���_�A���Ӑ�A������BL���ނ�����̃Z��������
                columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName);

                // ������BL���ށF���_�A���Ӑ�A������BL���ނ�����̃Z��������
                columns[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName);

                // ������BL���ށF���_�A���Ӑ�A������BL���ނ�����̃Z��������
                columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName);

                // ������BL���ށF���_�A���Ӑ�A������BL���ނ�����̃Z��������
                columns[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName);
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }
            # endregion
            // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<
        }
        // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
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
        // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<
        # endregion

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʏ������������܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        internal void Clear(bool settingGrid)
        {
            this._recGoodsLkStAcs.PrevRecGoodsLkDic.Clear();

            this.SetButtonEnabled(1);
            // ����DataTable�s�N���A����
            this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows.Clear();

            // �\�[�g�ݒ�̉���
            this.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();

            // �O���b�h�s�����ݒ菈��
            this._recGoodsLkStAcs.DetailRowInitialSetting(1);
            this.DetailGridInitSetting();

            if (settingGrid)
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].Hidden = true;
            }
        }

        /// <summary>
        /// �O���b�h��s���͐F�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �O���b�h��s���͐F�ݒ肵�܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        internal void DetailGridInitSetting()
        {
            if (this.uGrid_Details == null || this.uGrid_Details.Rows.Count < 1)
            {
                return;
            }

            UltraGridRow row = this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1];

            foreach (UltraGridCell cell in row.Cells)
            {
                if (cell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName    //���Ӑ�R�[�h
                 || cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName //���_�R�[�h
                 || cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName //������BL�R�[�h
                 || cell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName  //������BL�R�[�h
                 || cell.Column.Key == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName)  //���i�R�����g // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�
                {
                    cell.Activation = Activation.AllowEdit;
                    cell.Appearance.BackColor = Color.Empty;
                }
                else
                if (cell.Column.Key == this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName     //���Ӑ旪��
                 || cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName //���_��
                 || cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName //������BL�R�[�h��
                 || cell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName)  //������BL�R�[�h��
                {
                    cell.Activation = Activation.NoEdit;
                    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                }
            }
        }

        /// <summary>
        /// ���_�K�C�h�N��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note	   : ���_�K�C�h�N���B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        internal void SectionCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �R�[�h���疼�̂֕ϊ�
                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���ʃZ�b�g
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = secInfoSet.SectionCode;
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = secInfoSet.SectionGuideNm;
                    MoveNextAllowEditCell(false);
                }
                else
                {
                    // ���ʃZ�b�g
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �a�k�R�[�h�K�C�h�N��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note	   : �a�k�R�[�h�K�C�h�N���B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        internal void BLGoodsCodeGuide(int rowIndex, string keyName)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �R�[�h���疼�̂֕ϊ�
                BLGoodsCdUMnt blGoodsUnit;
                int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsUnit);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���ʃZ�b�g
                    switch (keyName)
                    {
                        case "RecSourceBLGoodsCd":
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = blGoodsUnit.BLGoodsCode;
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Value = blGoodsUnit.BLGoodsHalfName;
                                break;
                            }
                        case "RecDestBLGoodsCd":
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value = blGoodsUnit.BLGoodsCode;
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Value = blGoodsUnit.BLGoodsHalfName;
                                break;
                            }
                    }
                    MoveNextAllowEditCell(false);
                }
                else
                {
                    // ���ʃZ�b�g
                    switch (keyName)
                    {
                        case "RecSourceBLGoodsCd":
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                                break;
                            }
                        case "RecDestBLGoodsCd":
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activate();
                                break;
                            }
                    }
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�R�[�h�K�C�h�N��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note	   : ���Ӑ�R�[�h�K�C�h�N���B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        internal void CustomerCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ���Ӑ�K�C�h
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (this._customerSearchRet != null)
                {
                    if (CustomerCheck_Detail(this._customerSearchRet.CustomerCode, rowIndex))
                    {
                        MoveNextAllowEditCell(false);
                    }
                    this._customerSearchRet = null;
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �����{�^������/�L���ݒ�
        /// </summary>
        /// <param name="mode">mode1,2,3</param>
        /// <remarks>
        /// <br>Note	   : �����{�^������/�L���ݒ�B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        internal void SetButtonEnabled(int mode)
        {
            switch (mode)
            {
                case 1:
                    {
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Revival"].SharedProps.Enabled = false;     // ����
                        this.uButton_Revival.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = true;    // �s�폜
                        this.uButton_RowDelete.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllRowDelete"].SharedProps.Enabled = true; // �S�폜
                        this.uButton_AllRowDelete.Enabled = true;
                        // --- ADD 2015/03/05 Y.Wakita Redmine#332 ---------->>>>>
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowInsert"].SharedProps.Enabled = true;    // �s�}��
                        this.uButton_RowInsert.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowCut"].SharedProps.Enabled = true;       // �؂���
                        this.uButton_RowCut.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowCopy"].SharedProps.Enabled = true;      // �R�s�[
                        this.uButton_RowCopy.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowPaste"].SharedProps.Enabled = true;     // �\��t��
                        this.uButton_RowPaste.Enabled = true;
                        // --- ADD 2015/03/05 Y.Wakita Redmine#332 ----------<<<<<
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
                        // --- ADD 2015/03/05 Y.Wakita Redmine#332 ---------->>>>>
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowInsert"].SharedProps.Enabled = false; // �s�}��
                        this.uButton_RowInsert.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowCut"].SharedProps.Enabled = false; // // �؂���
                        this.uButton_RowCut.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowCopy"].SharedProps.Enabled = false; // // �R�s�[
                        this.uButton_RowCopy.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowPaste"].SharedProps.Enabled = false; // // �\��t��
                        this.uButton_RowPaste.Enabled = false;
                        // --- ADD 2015/03/05 Y.Wakita Redmine#332 ----------<<<<<
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
                        // --- ADD 2015/03/05 Y.Wakita Redmine#332 ---------->>>>>
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowInsert"].SharedProps.Enabled = false;   // �s�}��
                        this.uButton_RowInsert.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowCut"].SharedProps.Enabled = false;      // �؂���
                        this.uButton_RowCut.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowCopy"].SharedProps.Enabled = false;     // �R�s�[
                        this.uButton_RowCopy.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowPaste"].SharedProps.Enabled = false;    // �\��t��
                        this.uButton_RowPaste.Enabled = false;
                        // --- ADD 2015/03/05 Y.Wakita Redmine#332 ----------<<<<<
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
        /// <br>Note       : ���Ӑ�I�����ɔ������܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
        /// ���Ӑ�`�F�b�N����
        /// </summary>
        public bool CustomerCheck_Detail(int customerCode, int rowIndex)
        {
            string errMsg;
            CustomerInfo retCustomerInfo;

            bool checkResult = this._recGoodsLkStAcs.CheckCustomer(customerCode, true, out errMsg, out retCustomerInfo);
            if (checkResult)
            {
                // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
                if (customerCode == 0)
                {
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------>>>>>
                    //this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = customerCode.ToString().PadLeft(8, '0'); //���Ӑ�R�[�h
                    //this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = "�S���Ӑ�"; //���Ӑ旪��
                    //this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOriginalEpCdColumn.ColumnName].Value = "0000000000000000";                       //���Ӑ��ƃR�[�h
                    //this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOriginalSecCdColumn.ColumnName].Value = "000000";                     //���Ӑ拒�_�R�[�h
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_CUSTOMERCODE;      //���Ӑ�R�[�h
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_CUSTOMERNAME;       //���Ӑ旪��
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOriginalEpCdColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_ORIGINALEPCD;   //���Ӑ��ƃR�[�h
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOriginalSecCdColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_ORIGINALSECCD; //���Ӑ拒�_�R�[�h
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------<<<<<
                }
                // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = retCustomerInfo.CustomerCode.ToString().PadLeft(8, '0'); //���Ӑ�R�[�h
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = retCustomerInfo.CustomerSnm;                              //���Ӑ旪��
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOriginalEpCdColumn.ColumnName].Value = retCustomerInfo.CustomerEpCode;                       //���Ӑ��ƃR�[�h
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOriginalSecCdColumn.ColumnName].Value = retCustomerInfo.CustomerSecCode;                     //���Ӑ拒�_�R�[�h
                    this._swCustomerInfo = retCustomerInfo.CustomerCode.ToString().PadLeft(8, '0');
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

                if (this._swCustomerInfo != string.Empty)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = this._swCustomerInfo.ToString().PadLeft(8, '0'); //�O�̒l�ɖ߂�
                }
            }
            return checkResult;
        }
        /// <summary>
        /// ���_�`�F�b�N����
        /// </summary>
        public bool SectionCheck_Detail(string sectionCode, int rowIndex)
        {
            string errMsg;
            SecInfoSet retSectionInfo;

            bool checkResult = this._recGoodsLkStAcs.CheckSection(sectionCode, false, out errMsg, out retSectionInfo);
            if (checkResult)
            {
                // --- UPD 2015/02/12 T.Miyamoto ------------------------------>>>>>
                //if (sectionCode == "00")
                Int32 chkSectionCode = 0;
                Int32.TryParse(sectionCode, out chkSectionCode);
                if (chkSectionCode == 0)
                // --- UPD 2015/02/12 T.Miyamoto ------------------------------<<<<<
                {
                    // --- UPD 2015/02/12 T.Miyamoto ------------------------------>>>>>
                    //this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode; //���_�R�[�h
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = chkSectionCode.ToString().PadLeft(2, '0'); ; //���_�R�[�h
                    // --- UPD 2015/02/12 T.Miyamoto ------------------------------<<<<<
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = "�S�Ћ���";  //���_����
                    this._swSectionInfo = sectionCode;
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = retSectionInfo.SectionCode.Trim().PadLeft(2, '0'); //���_�R�[�h
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = retSectionInfo.SectionGuideNm; //���_����
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

                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this._swSectionInfo.ToString().PadLeft(2, '0');
            }
            return checkResult;
        }

        /// <summary>
        /// �O���b�hNext�t�H�[�J�X�擾����
        /// </summary>
        /// <param name="mode">���[�h(0:Tab;1;Shift + Tab)</param>
        /// <param name="rowIndex">rowIndex</param>
        /// <param name="columnKey">columnKey</param>
        /// <returns>columnIndex</returns>
        /// <remarks>
        /// <br>Note       : �O���b�hNext�t�H�[�J�X�擾���s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private int GetNextColumnIndexByTab(int mode, int rowIndex, string columnKey)
        {
            int columnIndex = -1;
            switch (mode)
            {
                case 0:
                    #region Tab
                    if (columnKey == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName)
                    // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName)
                    // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<
                    {
                        columnIndex = -1;
                    }
                    break;
                    #endregion Tab
                case 1:
                    #region Shift + Tab
                    if (columnKey == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName)
                    {
                        columnIndex = -1;
                    }
                    if (columnKey == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Column.Index;
                    }
                    // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
                    else if (columnKey == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Column.Index;
                    }
                    // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<
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
        /// <br>Note       : �ω��f�[�^�擾����</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void GetSaveDate(out List<RecGoodsLkSt> delList, out List<RecGoodsLkSt> updList)
        {
            this._prevRecGoodsLkDic = this._recGoodsLkStAcs.PrevRecGoodsLkDic;
            List<RecGoodsLkSt> dList = new List<RecGoodsLkSt>();
            List<RecGoodsLkSt> uList = new List<RecGoodsLkSt>();

            RecGoodsLkSt recGoodsLk = new RecGoodsLkSt();
            RecGoodsLkSt recGoodsLkUPD = new RecGoodsLkSt();
            if (this._recGoodsLkDataTable.Rows.Count > 0)
            {
                foreach (RecGoodsLkDataSet.RecGoodsLkRow row in this._recGoodsLkDataTable.Rows)
                {
                    recGoodsLk = new RecGoodsLkSt();
                    this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow(row, ref recGoodsLk);
                    // ���C�s�̏ꍇ
                    if (_prevRecGoodsLkDic.ContainsKey(row.FilterGuid))
                    {
                        bool keyChanged = this._recGoodsLkStAcs.CompareKey(recGoodsLk, _prevRecGoodsLkDic[row.FilterGuid]);

                        if (row.RowDeleteFlg == 0)
                        {
                            if (this._recGoodsLkStAcs.Compare(recGoodsLk, _prevRecGoodsLkDic[row.FilterGuid]))
                            {
                                dList.Add(_prevRecGoodsLkDic[row.FilterGuid]);
                                recGoodsLkUPD = recGoodsLk.Clone();
                                recGoodsLkUPD.LogicalDeleteCode = 0;
                                recGoodsLkUPD.IsUpdRow = false;
                                uList.Add(recGoodsLkUPD);
                            }
                        }
                        else
                        {
                            // �s�폜�̏ꍇ
                            recGoodsLk = _prevRecGoodsLkDic[row.FilterGuid];
                            recGoodsLkUPD = recGoodsLk.Clone();
                            recGoodsLkUPD.LogicalDeleteCode = 1;
                            if (!keyChanged)
                            {
                                recGoodsLkUPD.IsUpdRow = true;
                            }
                            uList.Add(recGoodsLkUPD);
                        }
                    }
                    // �V�K�s�̏ꍇ
                    else
                    {
                        if (this._recGoodsLkStAcs.IsRowUpdate(row) && row.RowDeleteFlg == 0)
                        {
                            recGoodsLkUPD = recGoodsLk.Clone();
                            recGoodsLkUPD.LogicalDeleteCode = 0;
                            recGoodsLkUPD.IsUpdRow = false;
                            uList.Add(recGoodsLkUPD);
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckSaveDate(out List<RecGoodsLkSt> deleteList, out List<RecGoodsLkSt> updateList)
        {
            List<RecGoodsLkSt> delList = new List<RecGoodsLkSt>();
            List<RecGoodsLkSt> updList = new List<RecGoodsLkSt>();

            this.GetSaveDate(out delList, out updList);
            deleteList = delList;
            updateList = updList;

            if (updateList.Count == 0)
            {
                return false;
            }

            #region
            if (updateList.Count != 0)
            {
                int rowIndex = -1;
                foreach (RecGoodsLkSt recGoodsLk in updateList)
                {
                    // �s�폜�̃f�[�^���`�F�b�N�Ȃ�
                    if (recGoodsLk.LogicalDeleteCode == 1)
                    {
                        continue;
                    }

                    //�s�ԍ����擾
                    rowIndex = recGoodsLk.RowIndex;

                    // ���_�R�[�h����̓`�F�b�N
                    //int inqOtherSecCd = 0;
                    //int.TryParse(recGoodsLk.InqOtherSecCd.Trim(), out inqOtherSecCd);
                    if (recGoodsLk.InqOtherSecCd.Trim() == string.Empty)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "���_�R�[�h����͂��ĉ������B",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }

                    // --- DEL 2015/02/09 T.Nishi ------------------------------>>>>>
                    //// ���Ӑ�R�[�h����̓`�F�b�N
                    //if (recGoodsLk.CustomerCode == 0)
                    //{
                    //    TMsgDisp.Show(
                    //         this,
                    //         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    //         this.Name,
                    //         "���Ӑ�R�[�h����͂��ĉ������B",
                    //         0,
                    //         MessageBoxButtons.OK);
                    //    if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                    //    {
                    //        this.uGrid_Details.Rows[rowIndex-1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                    //        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    //    }
                    //    return false;
                    //}
                    // --- DEL 2015/02/09 T.Nishi ------------------------------<<<<<

                    // --- ADD 2015/02/16 Y.Wakita RedMine#217 ------------------------------>>>>>
                    // ���Ӑ�R�[�h����̓`�F�b�N
                    string errMsg;
                    CustomerInfo retCustomerInfo;

                    bool checkResult = this._recGoodsLkStAcs.CheckCustomer(recGoodsLk.CustomerCode, true, out errMsg, out retCustomerInfo);
                    if (!(checkResult))
                    {
                        TMsgDisp.Show(this
                                     , emErrorLevel.ERR_LEVEL_EXCLAMATION
                                     , this.Name
                                     , errMsg
                                     , 0
                                     , MessageBoxButtons.OK);

                        if (this._swCustomerInfo != string.Empty)
                        {
                            this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                    // --- ADD 2015/02/16 Y.Wakita RedMine#217 ------------------------------<<<<<
                    // --- ADD 2015/03/02 T.Miyamoto RedMine#217 ------------------------------>>>>>
                    if (recGoodsLk.CustomerCode == 0)
                    {
                        // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------>>>>>
                        //this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = "00000000";            //���Ӑ�R�[�h
                        //this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = "�S���Ӑ�";             //���Ӑ旪��
                        //this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.InqOriginalEpCdColumn.ColumnName].Value = "0000000000000000"; //���Ӑ��ƃR�[�h
                        //this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.InqOriginalSecCdColumn.ColumnName].Value = "000000";          //���Ӑ拒�_�R�[�h
                        //recGoodsLk.InqOriginalEpCd = "0000000000000000";
                        //recGoodsLk.InqOriginalSecCd = "000000";
                        this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_CUSTOMERCODE;      //���Ӑ�R�[�h
                        this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_CUSTOMERNAME;       //���Ӑ旪��
                        this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.InqOriginalEpCdColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_ORIGINALEPCD;   //���Ӑ��ƃR�[�h
                        this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.InqOriginalSecCdColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_ORIGINALSECCD; //���Ӑ拒�_�R�[�h
                        recGoodsLk.InqOriginalEpCd = RecGoodsLkStAcs.ALL_ORIGINALEPCD;
                        recGoodsLk.InqOriginalSecCd = RecGoodsLkStAcs.ALL_ORIGINALSECCD;
                        // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------<<<<<
                    }
                    // --- ADD 2015/03/02 T.Miyamoto RedMine#217 ------------------------------<<<<<

                    // ������BL�R�[�h����̓`�F�b�N
                    if (recGoodsLk.RecSourceBLGoodsCd == 0)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "������BL�R�[�h����͂��ĉ������B",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex-1].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }

                    // ������BL�R�[�h����̓`�F�b�N
                    if (recGoodsLk.RecDestBLGoodsCd == 0)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "������BL�R�[�h����͂��ĉ������B",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex-1].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                    else
                    {
                        if (recGoodsLk.RecSourceBLGoodsCd == recGoodsLk.RecDestBLGoodsCd)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "������BL�R�[�h�Ɛ�����BL�R�[�h������ł��B",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex-1].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }
                    }
                }
            }

            if (updateList.Count != 0)
            {
                int rowIndex = -1;
                foreach (RecGoodsLkSt recGoodsLk in updateList)
                {
                    // �폜�s�̓`�F�b�N�Ȃ�
                    if (recGoodsLk.LogicalDeleteCode == 1)
                    {
                        continue;
                    }

                    //�s�ԍ����擾
                    rowIndex = recGoodsLk.RowIndex;

                    #region �d�����R�[�h�̑��݃`�F�b�N
                    foreach (RecGoodsLkDataSet.RecGoodsLkRow row in this._recGoodsLkDataTable.Rows)
                    {
                        Int32 chkCustomerCode = 0;
                        Int32.TryParse(row.CustomerCode, out chkCustomerCode);
                        if (row.UpdateTime == DateTime.MinValue.ToString("yy/MM/dd")
                         && chkCustomerCode == 0)
                        {
                            continue;
                        }
                        if (row.FilterGuid == Guid.Empty && row.RowDeleteFlg == 1)
                        {
                            continue;
                        }
                        if (row.RowNo == recGoodsLk.RowIndex)
                        {
                            continue;
                        }
                        if (chkCustomerCode == recGoodsLk.CustomerCode
                         && row.InqOtherSecCd.Trim().PadLeft(2, '0') == recGoodsLk.InqOtherSecCd.Trim().PadLeft(2, '0')
                         && row.RecSourceBLGoodsCd == recGoodsLk.RecSourceBLGoodsCd
                         && row.RecDestBLGoodsCd == recGoodsLk.RecDestBLGoodsCd)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "����̏��i�ݒ肪���ɓo�^����Ă��܂��B" + "\r\n" +
                                 "�E���_���ށ@  �F" + recGoodsLk.InqOtherSecCd.ToString().PadLeft(2, '0') + "\r\n" +
                                 "�E���Ӑ溰�ށ@�F" + recGoodsLk.CustomerCode.ToString().PadLeft(8, '0') + "\r\n" +
                                 "�E������BL���ށF" + recGoodsLk.RecSourceBLGoodsCd.ToString().PadLeft(5, '0') + "\r\n" +
                                 "�E������BL���ށF" + recGoodsLk.RecDestBLGoodsCd.ToString().PadLeft(5, '0'),
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex-1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }
                    }
                    #endregion �d�����R�[�h�̑��݃`�F�b�N
                }
            }
            #endregion

            return true;
        }

        // --- ADD 2015/03/02 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// �T���v���W�J�O�`�F�b�N����
        /// </summary>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �T���v���W�J�O�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/03/02</br>
        /// </remarks>
        public bool CheckSampleData(string sampleSecCd, string sampleSecNm, CustomerInfo sampleCustomerInfo)
        {
            foreach (RecGoodsLkDataSet.RecGoodsLkRow row in this._recGoodsLkDataTable.Rows)
            {
                if (this._recGoodsLkStAcs.IsRowUpdate(row) && row.RowDeleteFlg == 0) // ADD 2015/03/04 T.Miyamoto Redmine#318
                {
                    // --- UPD 2015/03/04 T.Miyamoto Redmine#321 ------------------------------>>>>>
                    //if ((row.InqOtherSecCd == sampleSecCd.Trim())
                    // && (row.CustomerCode == sampleCustomerInfo.CustomerCode.ToString().PadLeft(8, '0'))
                    // && (row.InqOriginalEpCd == sampleCustomerInfo.CustomerEpCode)
                    // && (row.InqOriginalSecCd == sampleCustomerInfo.CustomerSecCode))
                    if ((row.InqOtherSecCd.Trim() == sampleSecCd.Trim())
                     && (row.CustomerCode.Trim() == sampleCustomerInfo.CustomerCode.ToString().PadLeft(8, '0'))
                     && (row.InqOriginalEpCd.Trim() == sampleCustomerInfo.CustomerEpCode.Trim())
                     && (row.InqOriginalSecCd.Trim() == sampleCustomerInfo.CustomerSecCode.Trim()))
                    // --- UPD 2015/03/04 T.Miyamoto Redmine#321 ------------------------------<<<<<
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        // --- ADD 2015/03/02 T.Miyamoto ------------------------------<<<<<


        /// <summary>
        /// DOWN�O�`�F�b�N����
        /// </summary>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��O�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckDateForDown()
        {
            RecGoodsLkDataSet.RecGoodsLkRow row = (RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkDataTable.Rows[this._recGoodsLkDataTable.Count - 1];
            // �s�폜�̃f�[�^���`�F�b�N�Ȃ�
            if (row.RowDeleteFlg == 1)
            {
                return true;
            }

            RecGoodsLkSt recGoodsLk = new RecGoodsLkSt();
            this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow((RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkDataTable.Rows[this._recGoodsLkDataTable.Count - 1], ref recGoodsLk);

            // �s�폜�̃f�[�^���`�F�b�N�Ȃ�
            if (recGoodsLk.LogicalDeleteCode == 1)
            {
                return true;
            }

            // ���_�R�[�h���̓`�F�b�N
            if (recGoodsLk.InqOtherSecCd == string.Empty)
            {
                return false;
            }
            // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
            //// ���Ӑ�R�[�h���̓`�F�b�N
            //if (recGoodsLk.CustomerCode == 0)
            //{
            //    return false;
            //}
            // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
            // ������BL�R�[�h���̓`�F�b�N
            if (recGoodsLk.RecSourceBLGoodsCd == 0)
            {
                return false;
            }
            // ������BL�R�[�h���̓`�F�b�N
            if (recGoodsLk.RecDestBLGoodsCd == 0)
            {
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void ReturnSaveDate(out List<RecGoodsLkSt> deleteList, out List<RecGoodsLkSt> updateList)
        {
            this._prevRecGoodsLkDic = this._recGoodsLkStAcs.PrevRecGoodsLkDic;
            List<RecGoodsLkSt> delList = new List<RecGoodsLkSt>();
            List<RecGoodsLkSt> updList = new List<RecGoodsLkSt>();

            RecGoodsLkSt recGoodsLk = new RecGoodsLkSt();
            RecGoodsLkSt recGoodsLkUPD = new RecGoodsLkSt();
            if (this._recGoodsLkDataTable.Rows.Count > 0)
            {
                foreach (RecGoodsLkDataSet.RecGoodsLkRow row in this._recGoodsLkDataTable.Rows)
                {
                    this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow(row, ref recGoodsLk);
                    if (row.RowDeleteFlg == 1)
                    {
                        delList.Add(this._prevRecGoodsLkDic[row.FilterGuid]);
                    }
                    else if (row.RowDeleteFlg == 2)
                    {
                        recGoodsLk = this._prevRecGoodsLkDic[row.FilterGuid];
                        recGoodsLkUPD = recGoodsLk.Clone();
                        recGoodsLkUPD.LogicalDeleteCode = 0;
                        updList.Add(recGoodsLkUPD);
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void GridSettingAfterSearch(bool deleteFlg)
        {
            //�폜�w��敪:0
            if (deleteFlg == false)
            {
                this.SetButtonEnabled(1);
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].Hidden = true;

                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    // �V�K�s�ȊO
                    if (!Guid.Empty.Equals((Guid)row.Cells[this._recGoodsLkDataTable.FilterGuidColumn.ColumnName].Value))
                    {
                        row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    }
                    else
                    {
                        row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;
                    }
                    row.Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                    row.Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                    row.Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit; // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�
                }
            }
            //�폜�w��敪:1
            else
            {
                this.SetButtonEnabled(2);
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].Hidden = false;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].CellAppearance.ForeColor = Color.Red;
                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    foreach (UltraGridCell cell in row.Cells)
                    {
                        if (cell.Column.Key != this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                        {
                            cell.Appearance.BackColor = ct_DISABLE_COLOR;
                            cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                            cell.Activation = Activation.NoEdit;
                        }
                    }
                }
            }
        }

        // --- UPD 2015/02/09 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------>>>>>
        /// <summary>
        /// �T���v���捞��A���ו��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �T���v���捞��A���ו��ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/09</br>
        /// </remarks>
        public void GridSettingAfterSampleSet()
        {
            int ActiveRow = 0;
            this.SetButtonEnabled(1);
            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {
                if ((int)row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value == DELETEFLG_SAMPLE)
                {
                    if (ActiveRow == 0) ActiveRow = row.Index;
                    //���_
                    row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;
                    row.Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    //���Ӑ�
                    row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                    row.Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    //������BL�R�[�h
                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    //������BL�R�[�h
                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    //���i�R�����g
                    row.Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit;

                    row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = DELETEFLG_DEFAULT;
                }
            }
        }
        // --- UPD 2015/02/09 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------<<<<<

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �����͉\�Z���ړ��������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
                    if (this.uGrid_Details.ActiveRow.Index == this._recGoodsLkDataTable.Count - 1)
                    {
                        if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Text.Trim() == string.Empty)
                        {
                            // --- UPD 2015/02/10�A T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
                            //if (this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            if (this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            // --- UPD 2015/02/10�A T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<
                            {
                                if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                                {
                                    if (CheckDateForDown())
                                    {
                                        #region �ŏI�s�̏ꍇ�A�V�K�s��ǉ�����
                                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------>>>>>
                                        //RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
                                        //newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                                        //newRow.FilterGuid = Guid.Empty;
                                        //newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                                        //newRow.InqOtherEpCd = this._enterpriseCode;
                                        ////newRow.InqOtherSecCd = this._loginSectionCode;
                                        //this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);

                                        //this.DetailGridInitSetting();
                                        ////���Ӑ���̏����l�Z�b�g
                                        //Int32 customerCode = 0;
                                        //string customerName = string.Empty;
                                        //this.GetCustomerInfo(out customerCode, out customerName);
                                        //if (customerCode != 0)
                                        //{
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = customerCode; //���Ӑ�R�[�h
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = customerName;  //���Ӑ旪��
                                        //}

                                        ////���_���̏����l�Z�b�g
                                        //string sectionCode = string.Empty;
                                        //string sectionName = string.Empty;
                                        //this.GetSectionInfo(out sectionCode, out sectionName);
                                        //if (sectionCode != string.Empty)
                                        //{
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode;
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = sectionName;
                                        //}

                                        ////�����t�H�[�J�X�ʒu�Z�b�g
                                        //if (customerCode != 0 || sectionCode != string.Empty)
                                        //{
                                        //    if (sectionCode == string.Empty)
                                        //    {
                                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                        //    }
                                        //    else if (customerCode == 0)
                                        //    {
                                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                                        //    }
                                        //    else
                                        //    {
                                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    //�����Ƃ��󔒂̏ꍇ�͋��_�R�[�h�Ƀt�H�[�J�X�Z�b�g
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                        //}
                                        this.NewRowAdd(this.uGrid_Details.Rows.Count);
                                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------<<<<<

                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return true;
                                        #endregion
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
                        else
                        {
                            // --- UPD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
                            //if (this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            if (this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            // --- UPD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<
                            {
                                if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                                {
                                    if (CheckDateForDown())
                                    {
                                        #region �ŏI�s�̏ꍇ�A�V�K�s��ǉ�����
                                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------>>>>>
                                        //RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
                                        //newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                                        //newRow.FilterGuid = Guid.Empty;
                                        //newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                                        //newRow.InqOtherEpCd = this._enterpriseCode;
                                        ////newRow.InqOtherSecCd = this._loginSectionCode;
                                        //this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);

                                        //this.DetailGridInitSetting();
                                        ////���Ӑ���̏����l�Z�b�g
                                        //Int32 customerCode = 0;
                                        //string customerName = string.Empty;
                                        //this.GetCustomerInfo(out customerCode, out customerName);
                                        //if (customerCode != 0)
                                        //{
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = customerCode; //���Ӑ�R�[�h
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = customerName;  //���Ӑ旪��
                                        //}

                                        ////���_���̏����l�Z�b�g
                                        //string sectionCode = string.Empty;
                                        //string sectionName = string.Empty;
                                        //this.GetSectionInfo(out sectionCode, out sectionName);
                                        //if (sectionCode != string.Empty)
                                        //{
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode;
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = sectionName;
                                        //}

                                        ////�����t�H�[�J�X�ʒu�Z�b�g
                                        ////�����Ƃ��󔒂̏ꍇ�͋��_�R�[�h�Ƀt�H�[�J�X�Z�b�g
                                        //if (customerCode != 0 || sectionCode != string.Empty)
                                        //{
                                        //    if (sectionCode == string.Empty)
                                        //    {
                                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                        //    }
                                        //    else if (customerCode == 0)
                                        //    {
                                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                                        //    }
                                        //    else
                                        //    {
                                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    //�����Ƃ��󔒂̏ꍇ�͋��_�R�[�h�Ƀt�H�[�J�X�Z�b�g
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                        //}
                                        this.NewRowAdd(this.uGrid_Details.Rows.Count);
                                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------<<<<<

                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                                        return true;
                                        #endregion
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
                        if (this.uGrid_Details.Rows[0].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation != Activation.AllowEdit
                         && this.uGrid_Details.Rows[0].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation != Activation.AllowEdit)
                        {
                            if ("RecSourceBLGoodsCd".Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                break;
                            }
                        }
                        else
                        {
                            if ("CampaignCode".Equals(this.uGrid_Details.ActiveCell.Column.Key))
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void ReturnKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                return;
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
                columnKey = this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected)
                {
                    if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                    {
                        if (this.uGrid_Details.ActiveRow.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                        {
                            this.uGrid_Details.ActiveRow.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            this.uGrid_Details.ActiveRow.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void ShiftKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                return;
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
                columnKey = this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected)
                {
                    if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                    {
                        if (this.uGrid_Details.ActiveRow.Index > 0)
                        {
                            // --- UPD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
                            //this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activate();
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Activate();
                            // --- UPD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void SetGridGuid()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                switch (this.uGrid_Details.ActiveCell.Column.Key)
                {
                    case "InqOtherSecCd":    //���_�R�[�h
                    case "CustomerCode":    //���Ӑ�R�[�h
                    case "RecSourceBLGoodsCd": //������BL�R�[�h
                    case "RecDestBLGoodsCd":   //������BL�R�[�h
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
        /// <br>Note       : ���l���̓`�F�b�N����</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
                //int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                int _Rketa = RecGoodsLkStAcs.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
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
        /// �w�b�_������AENTER�ATAB�A���������A�ŏI���׍s�{�P�s�ڂ̃R�[�h�փt�H�[�J�X��J�ڂ���B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �w�b�_������AENTER�ATAB�A���������A�ŏI���׍s�{�P�s�ڂ̃R�[�h�փt�H�[�J�X��J�ڂ���B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void SetFocusAfterSearch()
        {
            if (this.uGrid_Details.Rows.Count > 0)
            {
                if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                {
                    bool flag = false;
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        if (row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                        {
                            flag = true;
                            Int32 customerCode = 0;
                            string sectionCode = string.Empty;
                            if (row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Text.Trim() == string.Empty)
                            {
                                //���_���̏����l�Z�b�g
                                string customerName = string.Empty;
                                this.GetCustomerInfo(out customerCode, out customerName);
                                if (customerCode != 0)
                                {
                                    row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = customerCode;
                                    row.Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = customerName;
                                }
                            }
                            if (row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Text.Trim() == string.Empty)
                            {
                                string sectionName = string.Empty;
                                this.GetSectionInfo(out sectionCode, out sectionName);
                                if (sectionCode != string.Empty)
                                {
                                    // --- UPD 2015/03/13 T.Nishi ------------------------------>>>>>
                                    //row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode;
                                    row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode.Trim().PadLeft(2,'0');
                                    // --- UPD 2015/03/13 T.Nishi ------------------------------<<<<<
                                    row.Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = sectionName;
                                }
                            }

                            //�����t�H�[�J�X�ʒu�Z�b�g
                            if (customerCode != 0 || sectionCode != string.Empty)
                            {
                                if (sectionCode == string.Empty)
                                {
                                    row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                }
                                else if (customerCode == 0)
                                {
                                    row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                                }
                                else
                                {
                                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                                }
                            }
                            else
                            {
                                //�����Ƃ��󔒂̏ꍇ�͋��_�R�[�h�Ƀt�H�[�J�X�Z�b�g
                                row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                            }

                            break;
                        }
                    }

                    if (flag == false)
                    {
                        #region �ŏI�s�̏ꍇ�A�V�K�s��ǉ�����
                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------>>>>>
                        //RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
                        //newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                        //newRow.FilterGuid = Guid.Empty;
                        //newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                        //newRow.InqOtherEpCd = this._enterpriseCode;
                        ////newRow.InqOtherSecCd = this._loginSectionCode;

                        //this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);

                        //this.DetailGridInitSetting();
                        //#endregion

                        //Int32 customerCode = 0;
                        //string customerName = string.Empty;
                        //this.GetCustomerInfo(out customerCode, out customerName);
                        //if (customerCode != 0)
                        //{
                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = customerCode;
                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = customerName;
                        //}

                        ////���_���̏����l�Z�b�g
                        //string sectionCode = string.Empty;
                        //string sectionName = string.Empty;
                        //this.GetSectionInfo(out sectionCode, out sectionName);
                        //if (sectionCode != string.Empty)
                        //{
                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode;
                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = sectionName;
                        //}

                        ////�����t�H�[�J�X�ʒu�Z�b�g
                        //if (customerCode != 0 || sectionCode != string.Empty)
                        //{
                        //    if (sectionCode == string.Empty)
                        //    {
                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                        //    }
                        //    else if (customerCode == 0)
                        //    {
                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                        //    }
                        //    else
                        //    {
                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                        //    }
                        //}
                        //else
                        //{
                        //    //�����Ƃ��󔒂̏ꍇ�͋��_�R�[�h�Ƀt�H�[�J�X�Z�b�g
                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                        //}
                        this.NewRowAdd(this.uGrid_Details.Rows.Count);
                        #endregion
                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------<<<<<
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

        // --- ADD 2015/02/06 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// �V�K���׍s�ǉ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K���׍s��ǉ�����B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        public void NewRowAdd(int addRowIndex)
        {
            RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
            newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
            newRow.FilterGuid = Guid.Empty;
            newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
            newRow.InqOtherEpCd = this._enterpriseCode;

            this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);
            this.DetailGridInitSetting();

            //���Ӑ���̏����l�Z�b�g
            Int32 customerCode = 0;
            string customerName = string.Empty;
            this.GetCustomerInfo(out customerCode, out customerName);
            if (customerCode != 0)
            {
                this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = customerCode;
                this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = customerName;
                // --- ADD 2015/02/12 T.Miyamoto ����ýď�Q#196 ------------------------------>>>>>
                this.CustomerCheck_Detail(customerCode, addRowIndex);
                // --- ADD 2015/02/12 T.Miyamoto ����ýď�Q#196 ------------------------------<<<<<
            }

            //���_���̏����l�Z�b�g
            string sectionCode = string.Empty;
            string sectionName = string.Empty;
            this.GetSectionInfo(out sectionCode, out sectionName);
            if (sectionCode != string.Empty)
            {
                // --- UPD 2015/03/13 T.Nishi ------------------------------>>>>>
                //this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode;
                this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode.Trim().PadLeft(2, '0');
                // --- UPD 2015/03/13 T.Nishi ------------------------------<<<<<
                this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = sectionName;
            }

            //�����t�H�[�J�X�ʒu�Z�b�g
            if (customerCode != 0 || sectionCode != string.Empty)
            {
                if (sectionCode == string.Empty)
                {
                    this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                }
                else if (customerCode == 0)
                {
                    this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                }
                else
                {
                    this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                }
            }
            else
            {
                //�����Ƃ��󔒂̏ꍇ�͋��_�R�[�h�Ƀt�H�[�J�X�Z�b�g
                this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
            }
        }
        // --- ADD 2015/02/06 T.Miyamoto ------------------------------<<<<<

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
        /// ���Ӑ�d�q�����p���[�U�[�ݒ�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�d�q�����p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<RecGoodsLkUserSet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new RecGoodsLkUserSet();
                }
            }
        }
    

    // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>

        /// <summary>
        /// ActiveRow�C���f�b�N�X�擾����
        /// </summary>
        /// <returns>ActiveRow�C���f�b�N�X</returns>
        private int GetActiveRowIndex()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                return this.uGrid_Details.ActiveCell.Row.Index;
            }
            else if (this.uGrid_Details.ActiveRow != null)
            {
                return this.uGrid_Details.ActiveRow.Index;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// ���׍s�I�u�W�F�N�g�̒ǉ����s���܂��B
        /// </summary>
        public void AddRecGoodsLkRow()
        {
            int rowCount = this._recGoodsLkDataTable.Rows.Count;

            RecGoodsLkDataSet.RecGoodsLkRow row = this._recGoodsLkDataTable.NewRecGoodsLkRow();
            this._recGoodsLkDataTable.AddRecGoodsLkRow(row);
        }

        # region  ���R�s�[����

        /// <summary>
        /// �R�s�[�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_RowCopy_Click(object sender, EventArgs e)
        {
           
            this._recGoodsLkDataTable.AcceptChanges();
            
            // �I���ςݍs�ԍ����X�g�擾����
            List<int> selectedRecGoodsLkRowNoList = this.GetSelectedrecGoodsLkRowNoList();
            if (selectedRecGoodsLkRowNoList == null) return;

            // ���׃f�[�^�e�[�u��RowStatus�񏉊�������
            this.InitializeRecGoodsLkRowStatusColumn();

            // ���׃f�[�^�e�[�u��RowStatus��l�ݒ菈��
            this.SetRecGoodsLkRowStatusColumn(selectedRecGoodsLkRowNoList, ctROWSTATUS_COPY);

            //// ���׃O���b�h�Z���ݒ菈��
            this.SettingGrid();

            //// �O���b�h�񏉊��ݒ菈��
            //this.InitialSettingGridCol();

            // --- DEL 2015/03/05 Y.Wakita Redmine#335 ---------->>>>>
            //// �����͉\�Z���ړ�����
            //this.MoveNextAllowEditCell(true);
            // --- DEL 2015/03/05 Y.Wakita Redmine#335 ----------<<<<<
        }
        /// <summary>
        /// �I���ςݍs�ԍ����X�g�擾����
        /// </summary>
        /// <returns>�I���ςݍs�ԍ����X�g</returns>
        private List<int> GetSelectedrecGoodsLkRowNoList() 
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;
            if ((cell == null) && (rows == null)) return null;

            List<int> selectedRecRowNoList = new List<int>();
            List<int> selectedIndexList = new List<int>();

            if (cell != null)
            {
                // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
                //selectedRecRowNoList.Add(this._recGoodsLkDataTable[cell.Row.Index].RowNo);
                selectedRecRowNoList.Add(int.Parse(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString()));
                // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<
                selectedIndexList.Add(cell.Row.Index);
            }
            else if (rows != null)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
                {
                    // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
                    //selectedRecRowNoList.Add(this._recGoodsLkDataTable[row.Index].RowNo);
                    selectedRecRowNoList.Add(int.Parse(this.uGrid_Details.Rows[row.Index].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString()));
                    // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<
                    selectedIndexList.Add(row.Index);
                }
            }

            return selectedRecRowNoList;
        }

        /// <summary>
        /// ���׃f�[�^�e�[�u���̍s�X�e�[�^�X��̒l�����������܂��B
        /// </summary>
        public void InitializeRecGoodsLkRowStatusColumn()
        {
            RecGoodsLkDataSet.RecGoodsLkRow[] rows = (RecGoodsLkDataSet.RecGoodsLkRow[])this._recGoodsLkDataTable.Select(this._recGoodsLkDataTable.RowStatusColumn.ColumnName + " <> " + ctROWSTATUS_NORMAL.ToString());

            this._recGoodsLkDataTable.BeginLoadData();
            foreach (RecGoodsLkDataSet.RecGoodsLkRow row in rows)
            {
                row.RowStatus = 0;
            }
            this._recGoodsLkDataTable.EndLoadData();
        }

        /// <summary>
        /// �w�肵���s�ԍ��̃��X�g�����ɁA�Y�����閾�׍s�I�u�W�F�N�g�̍s�X�e�[�^�X�ɒl��ݒ肵�܂��B
        /// </summary>
        /// <param name="stockRowNoList">���׍s�ԍ����X�g</param>
        /// <param name="rowStatus">RowStatus�l</param>
        public void SetRecGoodsLkRowStatusColumn(List<int> RecGoodsLkRowNoList, int rowStatus)
        {
            this._recGoodsLkDataTable.BeginLoadData();
            foreach (int RecGoodsLkRowNo in RecGoodsLkRowNoList)
            {
                RecGoodsLkDataSet.RecGoodsLkRow row = this.GetRecGoodsLkRow(RecGoodsLkRowNo);

                //if ((string.IsNullOrEmpty(row.GoodsName)) && (string.IsNullOrEmpty(row.GoodsNo))) continue;

                row.RowStatus = rowStatus;
            }
            this._recGoodsLkDataTable.EndLoadData();
        }

        /// <summary>
        /// �s�擾����
        /// </summary>
        /// <param name="stockRowNo"></param>
        /// <returns></returns>
        /// <br>Update Note : </br>
        /// <br>�Ǘ��ԍ�    : </br>
        /// <br>            : </br>
        public RecGoodsLkDataSet.RecGoodsLkRow GetRecGoodsLkRow(int RecRowNo)
        {
            return this._recGoodsLkDataTable.FindByRowNo(RecRowNo);
        }

        # endregion 

        # region  ���\��t������


        /// <summary>
        /// �\��t���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_RowPaste_Click(object sender, EventArgs e)
        {
            try
            {
                this._recGoodsLkDataTable.AcceptChanges();

                // ActiveRow�C���f�b�N�X�擾����
                int rowIndex = this.GetActiveRowIndex();
                if (rowIndex == -1) return;

                // �R�s�[���׍s�ԍ��擾����
                List<int> copyRecGoodsLkRowNoList = this.GetCopyRecGoodsLkRowNo();
                if (copyRecGoodsLkRowNoList == null) return;

                // --- DEL 2015/02/12 T.Nishi ------------------------------>>>>>
                //�����ōs�}���������s���ƁA��̏����ł����̂ňʒu�����炷�B
                //for (int i = 0; i < copyRecGoodsLkRowNoList.Count; i++)
                //{
                //    // ���׍s�}������
                //    this.InsertRecGoodsLkRow(rowIndex);
                //}
                // --- DEL 2015/02/12 T.Nishi ------------------------------<<<<<

                // �\���s���擾����
                int prevVisibleRowCount = this.GetVisibleRowCount();

                // ���׍s�\��t������
                this.PasteRecGoodsLkRow(copyRecGoodsLkRowNoList, rowIndex);

                // ���׃O���b�h�Z���ݒ菈��
                this.SettingGrid();
                //this.InitialSettingGridCol();

                // �\���s���擾����
                int afterVisibleRowCount = this.GetVisibleRowCount();

                // �\������s�����������ꍇ�A��������
                if (afterVisibleRowCount < prevVisibleRowCount)
                {
                    for (int i = afterVisibleRowCount; i < prevVisibleRowCount; i++)
                    {
                        this.AddRecGoodsLkRow();
                    }

                    // ���׃O���b�h�Z���ݒ菈��
                    this.SettingGrid();
                    //this.InitialSettingGridCol();
                }
            }
            finally
            {
                if (this.uGrid_Details.ActiveCell != null)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());
            }
        }

        /// <summary>
        /// ���׃f�[�^�e�[�u���ɃR�s�[�s�̍s�ԍ����X�g���擾���܂��B
        /// </summary>
        /// <returns>�s�ԍ����X�g</returns>
        public List<int> GetCopyRecGoodsLkRowNo()
        {
            RecGoodsLkDataSet.RecGoodsLkRow[] rows = (RecGoodsLkDataSet.RecGoodsLkRow[])this._recGoodsLkDataTable.Select(this._recGoodsLkDataTable.RowStatusColumn.ColumnName + " <> " + ctROWSTATUS_NORMAL.ToString());

            if ((rows != null) && (rows.Length > 0))
            {
                List<int> recGoodsLkRowNoList = new List<int>();
                foreach (RecGoodsLkDataSet.RecGoodsLkRow row in rows)
                {
                    recGoodsLkRowNoList.Add(row.RowNo);
                }

                return recGoodsLkRowNoList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// �w�肵���C���f�b�N�X�̖��׃f�[�^�s�ɑ΂��čs�\��t�����s���ہA�m�F���K�v���ǂ������`�F�b�N���܂��B
        /// </summary>
        /// <param name="copyStockRowNoList">�R�s�[�s�s�ԍ����X�g</param>
        /// <param name="pasteIndex">�\��t���sIndex</param>
        /// <returns>0:�`�F�b�N�s�v 1:�`�F�b�N�K�v 2:�\��t���s��</returns>
        public int CheckPasteRecGoodsLkRow(List<int> copyRecGoodsLkRowNoList, int pasteIndex)
        {
            int check = 0;
            // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
            //int pasteRecGoodsLkRowNo = this._recGoodsLkDataTable[pasteIndex].RowNo;
            int pasteRecGoodsLkRowNo = int.Parse(this.uGrid_Details.Rows[pasteIndex].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString());
            // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<

            for (int i = 0; i < copyRecGoodsLkRowNoList.Count; i++)
            {
                RecGoodsLkDataSet.RecGoodsLkRow sourceRow = this._recGoodsLkDataTable.FindByRowNo(copyRecGoodsLkRowNoList[i]);

                if (sourceRow == null)
                {
                    continue;
                }

                RecGoodsLkDataSet.RecGoodsLkRow row = this._recGoodsLkDataTable.FindByRowNo(pasteRecGoodsLkRowNo + i);

                if (row != null)
                {
                    if (this.ExistRecGoodsLkInput(row))
                    {
                        check = 1;
                    }
                }
            }

            return check;
        }

        /// <summary>
        /// �\���s���擾����
        /// </summary>
        /// <returns>�\���s��</returns>
        private int GetVisibleRowCount()
        {
            int count = 0;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_Details.Rows)
            {
                if (!row.Hidden)
                {
                    count++;
                }
            }

            return count;
        }
        /// <summary>
        /// ���׃f�[�^�s�I�u�W�F�N�g�̓\��t�����s���܂��B
        /// </summary>
        /// <param name="copyStockRowNoList">�R�s�[�s�s�ԍ����X�g</param>
        /// <param name="pasteIndex">�\��t���sIndex</param>
        public void PasteRecGoodsLkRow(List<int> copyRecGoodsLkRowNoList, int pasteIndex)
        {
            // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
            //int pasteTargetRecGoodsLkRowNo = this._recGoodsLkDataTable[pasteIndex].RowNo;
            int pasteTargetRecGoodsLkRowNo = int.Parse(this.uGrid_Details.Rows[pasteIndex].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString());
            // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<

            this._recGoodsLkDataTable.BeginLoadData();
            List<int> cutRecGoodsLkRowNoList = new List<int>();
            List<int> pasteRecGoodsLkRowNoList = new List<int>();
            List<int> deleteRecGoodsLkRowNoList = new List<int>();
            List<RecGoodsLkDataSet.RecGoodsLkRow> copyRecGoodsLkRowList = new List<RecGoodsLkDataSet.RecGoodsLkRow>();

            foreach (int RecGoodsLkRowNo in copyRecGoodsLkRowNoList)
            {
                RecGoodsLkDataSet.RecGoodsLkRow row = this.GetRecGoodsLkRow(RecGoodsLkRowNo);

                if (row != null)
                {
                    copyRecGoodsLkRowList.Add(this.CloneRecGoodsLkRow(row));

                    if (row.RowStatus == ctROWSTATUS_CUT)
                    {
                        cutRecGoodsLkRowNoList.Add(row.RowNo);
                    }
                }
            }

            if (cutRecGoodsLkRowNoList.Count > 0)
            {
                // ���׍s�N���A����
                for (int i = 0; i < cutRecGoodsLkRowNoList.Count; i++)
                {
                    this.ClearRecGoodsLkRow(this.GetRecGoodsLkRow(cutRecGoodsLkRowNoList[i]));
                }
            }

            // --- ADD 2015/02/12 T.Nishi ------------------------------>>>>>
            // ���׍s�}������
            for (int i = 0; i < copyRecGoodsLkRowNoList.Count; i++)
            {
                // ���׍s�}������
                this.InsertRecGoodsLkRow(pasteIndex);
            }
            // --- ADD 2015/02/12 T.Nishi ------------------------------<<<<<

            for (int i = 0; i < copyRecGoodsLkRowList.Count; i++)
            {
                RecGoodsLkDataSet.RecGoodsLkRow sourceRow = copyRecGoodsLkRowList[i];
                RecGoodsLkDataSet.RecGoodsLkRow targetRow = null;

                if ((pasteIndex + i) < this._recGoodsLkDataTable.Count)
                {


                    // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
                    //targetRow = this._recGoodsLkDataTable[pasteIndex + i];
                    targetRow = this.GetRecGoodsLkRow(int.Parse(this.uGrid_Details.Rows[pasteIndex + i].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString()));
                    // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<

                    // --- ADD 2015/02/12 T.Nishi ------------------------------>>>>>
                    this.CopyRecGoodsLkRow(sourceRow, targetRow);
                    //�R�s�[���Ȃ��Ă������ڂ��N���A
                    targetRow.UpdateTime = string.Empty;          // �X�V���t
                    targetRow.InqOtherSecCd = string.Empty;       // �⍇���拒�_�R�[�h
                    targetRow.InqOtherSecNm = string.Empty;       // �⍇���拒�_��
                    targetRow.CustomerCode = string.Empty;        // ���Ӑ�R�[�h
                    targetRow.CustomerSnm = string.Empty;         // ���Ӑ於
                    targetRow.FilterGuid = Guid.Empty;
                    // --- ADD 2015/02/12 T.Nishi ------------------------------<<<<<
                    // --- ADD 2015/03/06 T.Miyamoto Redmine#341 ------------------------------>>>>>
                    // �\��t���f�[�^�̍폜�t���O��OFF
                    targetRow.RowDeleteFlg = 0;
                    // --- ADD 2015/03/06 T.Miyamoto Redmine#341 ------------------------------<<<<<
                    pasteRecGoodsLkRowNoList.Add(targetRow.RowNo);
                }
            }
            this._recGoodsLkDataTable.EndLoadData();

            // �s�v�ȍs���폜����
            this.DeleteRecGoodsLkRow(deleteRecGoodsLkRowNoList, true);

        }

        /// <summary>
        /// ���׍s���f�[�^���͍ς݂��`�F�b�N���܂��B
        /// </summary>
        /// <returns></returns>
        public bool ExistRecGoodsLkInput(RecGoodsLkDataSet.RecGoodsLkRow row)
        {
            return ((!string.IsNullOrEmpty(row.InqOtherSecCd)) || (!string.IsNullOrEmpty(row.CustomerCode))
                || (!string.IsNullOrEmpty(row.RecDestBLGoodsCd.ToString())) || (!string.IsNullOrEmpty(row.RecSourceBLGoodsCd.ToString())));
        }


        /// <summary>
        /// ���׍s�I�u�W�F�N�g�̍폜���s���܂��B�i�I�[�o�[���[�h�j
        /// </summary> 
        /// <param name="stockRowNoList">�폜�sStockRowNo���X�g</param>
        /// <param name="changeRowCount">true:�s����ύX���� false:�s����ύX����͕ύX���Ȃ�</param>
        public void DeleteRecGoodsLkRow(List<int> RecGoodsLkRowNoList, bool changeRowCount)
        {
            if (RecGoodsLkRowNoList.Count == 0) return;

            this._recGoodsLkDataTable.BeginLoadData();
            foreach (int RecGoodsLkRowNo in RecGoodsLkRowNoList)
            {
                RecGoodsLkDataSet.RecGoodsLkRow targetRow = this.GetRecGoodsLkRow(RecGoodsLkRowNo);

                if (targetRow == null) continue;

                this._recGoodsLkDataTable.RemoveRecGoodsLkRow(targetRow);
            }

            // �f�[�^�e�[�u��RecGoodsLkRowNo�񏉊�������
            this.InitializeRecGoodsLkRowNoColumn();

            if (!changeRowCount)
            {
                // �폜�����������V�K�ɍs��ǉ�����
                for (int i = 0; i < RecGoodsLkRowNoList.Count; i++)
                {
                    this.AddRecGoodsLkRow();
                }
            }
            this._recGoodsLkDataTable.EndLoadData();
        }

        /// <summary>
        /// �f�[�^�e�[�u���̍s�ԍ����������i�č̔ԁj���܂��B
        /// </summary>
        public void InitializeRecGoodsLkRowNoColumn()
        {
            this._recGoodsLkDataTable.BeginLoadData();
            for (int i = 0; i < this._recGoodsLkDataTable.Rows.Count; i++)
            {
                int oldRecGoodsLkRowNo = this._recGoodsLkDataTable[i].RowNo;
                this._recGoodsLkDataTable[i].RowNo = i + 1;
            }
            this._recGoodsLkDataTable.EndLoadData();
        }


        # endregion



        # region ���؂��菈��
        /// <summary>
        /// �؂���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_RowCut_Click(object sender, EventArgs e)
        {
            this._recGoodsLkDataTable.AcceptChanges();

            // �I���ςݍs�ԍ����X�g�擾����
            List<int> selectedrecGoodsLkRowNoList = this.GetSelectedrecGoodsLkRowNoList();
            if (selectedrecGoodsLkRowNoList == null) return;

            // �f�[�^�e�[�u��RowStatus�񏉊�������
            this.InitializeRecGoodsLkRowStatusColumn();

            // �f�[�^�e�[�u��RowStatus��l�ݒ菈��
            this.SetRecGoodsLkRowStatusColumn(selectedrecGoodsLkRowNoList, ctROWSTATUS_CUT);

            // ���׃O���b�h�Z���ݒ菈��
            this.SettingGrid();
            //this.InitialSettingGridCol();

            // �����͉\�Z���ړ�����
            this.MoveNextAllowEditCell(true);

        }
        # endregion


        # region ���}������
        /// <summary>
        /// �}���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_RowInsert_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
            }
            this._recGoodsLkDataTable.AcceptChanges();

            // ActiveRow�C���f�b�N�X�擾����
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            string message;
            bool judge = this.InsertRecGoodsLkRowCheck(out message);
            if (!judge)
            {
                TMsgDisp.Show(
                     this,
                     emErrorLevel.ERR_LEVEL_INFO,
                     this.Name,
                     message,
                     0,
                     MessageBoxButtons.OK);

                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ���׍s�}������
                this.InsertRecGoodsLkRow(rowIndex);

                // ���׃O���b�h�Z���ݒ菈��
                this.SettingGrid();
                //this.InitialSettingGridCol();

                // �����͉\�Z���ړ�����
                this.MoveNextAllowEditCell(true);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            if (this.uGrid_Details.ActiveCell != null)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
        }

        /// <summary>
        /// ���׍s�I�u�W�F�N�g�̑}�����s���܂��B
        /// </summary>
        /// <param name="insertIndex">�}���sIndex</param>
        public void InsertRecGoodsLkRow(int insertIndex)
        {
            this.InsertRecGoodsLkRow(insertIndex, 1);
        }

        /// <summary>
        /// ���׍s�I�u�W�F�N�g�̑}�����s���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="insertIndex">�}���sIndex</param>
        /// <param name="line">�}���i��</param>
        public void InsertRecGoodsLkRow(int insertIndex, int line)
        {
            if (line == 0) return;

            this._recGoodsLkDataTable.BeginLoadData();

            //�}���O��1�s�V�K�s��ǉ�����
            RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
            newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
            newRow.FilterGuid = Guid.Empty;
            newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
            newRow.InqOtherEpCd = this._enterpriseCode;
            //newRow.InqOtherSecCd = this._loginSectionCode;
            this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);

            int lastRowIndex = this._recGoodsLkDataTable.Rows.Count - 1;
            int RecGoodsLkRowNo = this._recGoodsLkDataTable[insertIndex].RowNo;

            // �ŏI�s����}���Ώۍs�܂ł̍s�����w��i�����ɃR�s�[����
            for (int i = lastRowIndex; i >= insertIndex; i--)
            {
                if ((i + line) < this._recGoodsLkDataTable.Rows.Count)
                {
                    // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
                    //RecGoodsLkDataSet.RecGoodsLkRow sourceRow = this.GetRecGoodsLkRow(this._recGoodsLkDataTable[i].RowNo);
                    //RecGoodsLkDataSet.RecGoodsLkRow targetRow = this.GetRecGoodsLkRow(this._recGoodsLkDataTable[i + line].RowNo);
                    RecGoodsLkDataSet.RecGoodsLkRow sourceRow = this.GetRecGoodsLkRow(int.Parse(this.uGrid_Details.Rows[i].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString()));
                    RecGoodsLkDataSet.RecGoodsLkRow targetRow = this.GetRecGoodsLkRow(int.Parse(this.uGrid_Details.Rows[i + line].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString()));
                    // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<

                    this.CopyRecGoodsLkRow(sourceRow, targetRow);
                }
            }

            // �}���Ώۍs���N���A����
            // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
            //RecGoodsLkDataSet.RecGoodsLkRow clearRow = this.GetRecGoodsLkRow(this._recGoodsLkDataTable[insertIndex].RowNo);
            RecGoodsLkDataSet.RecGoodsLkRow clearRow = this.GetRecGoodsLkRow(int.Parse(this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString()));
            // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<
            this.ClearRecGoodsLkRow(clearRow);
            // --- ADD 2015/03/05 Y.Wakita Redmine#330 ---------->>>>>
            clearRow.InqOtherEpCd = this._enterpriseCode;
            // --- ADD 2015/03/05 Y.Wakita Redmine#330 ----------<<<<<
            // �N���A�s�̓��̓��[�h��ύX����B
            if (!Guid.Empty.Equals(clearRow.FilterGuid))
            {
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.NoEdit;

                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
            }
            else
            {
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;

                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Appearance.BackColor = Color.Empty;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
            }

            this._recGoodsLkDataTable.EndLoadData();
        }

        /// <summary>
        /// ���׍s�ɍs�}���\���ǂ����`�F�b�N���܂��B
        /// </summary>
        /// <param name="message"></param>
        /// <returns>true:�}���\ false:�}���s��</returns>
        public bool InsertRecGoodsLkRowCheck(out string message)
        {
            message = string.Empty;
            RecGoodsLkDataSet.RecGoodsLkRow row = (RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkDataTable.Rows[this._recGoodsLkDataTable.Rows.Count - 1];

            if (row != null)
            {
                //if (this.ExistRecGoodsLkInput(row))
                //{
                //    message = "�ŏI�s�����͍ςׁ݂̈A�s�}���ł��܂���B";
                //    return false;
                //}
            }
            return true;
        }

        /// <summary>
        /// ���׍s�I�u�W�F�N�g�̃R�s�[���s���܂��B
        /// </summary>
        /// <param name="sourceRow">�R�s�[�����׍s�I�u�W�F�N�g</param>
        /// <param name="targetRow">�R�s�[�斾�׍s�I�u�W�F�N�g</param>
        private void CopyRecGoodsLkRow(RecGoodsLkDataSet.RecGoodsLkRow sourceRow, RecGoodsLkDataSet.RecGoodsLkRow targetRow)
        {
            if ((sourceRow == null) || (targetRow == null)) return;

            #region �����ڃZ�b�g

            targetRow.InqOriginalEpCd = sourceRow.InqOriginalEpCd;              // �⍇������ƃR�[�h
            targetRow.InqOriginalSecCd = sourceRow.InqOriginalSecCd;            // �⍇�������_�R�[�h
            targetRow.InqOtherEpCd = sourceRow.InqOtherEpCd;                    // �⍇�����ƃR�[�h
            targetRow.InqOtherSecCd = sourceRow.InqOtherSecCd;                  // �⍇���拒�_�R�[�h
            targetRow.InqOtherSecNm = sourceRow.InqOtherSecNm;                  // �⍇���拒�_��
            targetRow.CustomerCode = sourceRow.CustomerCode;                    // ���Ӑ�R�[�h
            targetRow.CustomerSnm = sourceRow.CustomerSnm;                      // ���Ӑ於
            targetRow.RecDestBLGoodsCd = sourceRow.RecDestBLGoodsCd;            // ������BL���i�R�[�h
            targetRow.RecDestBLGoodsNm = sourceRow.RecDestBLGoodsNm;            // ������BL���i�R�[�h����
            targetRow.RecSourceBLGoodsCd = sourceRow.RecSourceBLGoodsCd;        // ������BL���i�R�[�h
            targetRow.RecSourceBLGoodsNm = sourceRow.RecSourceBLGoodsNm;        // ������BL���i�R�[�h����
            targetRow.GoodsComment = sourceRow.GoodsComment;                    // ���i�R�����g
            targetRow.FilterGuid = sourceRow.FilterGuid;
            targetRow.RowDeleteFlg = sourceRow.RowDeleteFlg;
            targetRow.UpdateTime = sourceRow.UpdateTime;

            // --- UPD 2015/03/06 T.Miyamoto Redmine#341 ------------------------------>>>>>
            //targetRow.RowStatus = ctROWSTATUS_NORMAL;
            targetRow.RowStatus = sourceRow.RowStatus;
            // --- UPD 2015/03/06 T.Miyamoto Redmine#341 ------------------------------<<<<<

            #endregion
        }
        /// <summary>
        /// ���׍s�I�u�W�F�N�g�̃N���A���s���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="row">���׍s�I�u�W�F�N�g</param>
        private void ClearRecGoodsLkRow(RecGoodsLkDataSet.RecGoodsLkRow row)
        {
            if (row == null) return;

            #region �����ڃN���A
            row.UpdateTime = string.Empty;          // �X�V���t
            row.InqOriginalEpCd = string.Empty;     // �⍇������ƃR�[�h
            row.InqOriginalSecCd = string.Empty;    // �⍇�������_�R�[�h
            row.InqOtherEpCd = string.Empty;        // �⍇�����ƃR�[�h
            row.InqOtherSecCd = string.Empty;       // �⍇���拒�_�R�[�h
            row.InqOtherSecNm = string.Empty;       // �⍇���拒�_��
            row.CustomerCode = string.Empty;        // ���Ӑ�R�[�h
            row.CustomerSnm = string.Empty;         // ���Ӑ於
            row.RecDestBLGoodsCd = 0;               // ������BL���i�R�[�h
            row.RecDestBLGoodsNm = string.Empty;    // ������BL���i�R�[�h����
            row.RecSourceBLGoodsCd = 0;             // ������BL���i�R�[�h
            row.RecSourceBLGoodsNm = string.Empty;  // ������BL���i�R�[�h����
            row.GoodsComment = string.Empty;        // ���i�R�����g
            row.RowDeleteFlg = 0;
            row.FilterGuid = Guid.Empty;

            row.RowStatus = ctROWSTATUS_NORMAL;

            #endregion
        }

        /// <summary>
        /// ���׍s�I�u�W�F�N�g�𕡐����܂��B
        /// </summary>
        /// <param name="sourceRow">���׍s�I�u�W�F�N�g</param>
        /// <returns>�����㖾�׍s�I�u�W�F�N�g</returns>
        private RecGoodsLkDataSet.RecGoodsLkRow CloneRecGoodsLkRow(RecGoodsLkDataSet.RecGoodsLkRow sourceRow)
        {
            RecGoodsLkDataSet.RecGoodsLkRow targetRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();

            #region �����ڃZ�b�g

            targetRow.InqOriginalEpCd = sourceRow.InqOriginalEpCd;              // �⍇������ƃR�[�h
            targetRow.InqOriginalSecCd = sourceRow.InqOriginalSecCd;            // �⍇�������_�R�[�h
            targetRow.InqOtherEpCd = sourceRow.InqOtherEpCd;                    // �⍇�����ƃR�[�h
            targetRow.InqOtherSecCd = sourceRow.InqOtherSecCd;                  // �⍇���拒�_�R�[�h
            targetRow.InqOtherSecNm = sourceRow.InqOtherSecNm;                  // �⍇���拒�_��
            targetRow.CustomerCode = sourceRow.CustomerCode;                    // ���Ӑ�R�[�h
            targetRow.CustomerSnm = sourceRow.CustomerSnm;                      // ���Ӑ於
            targetRow.RecDestBLGoodsCd = sourceRow.RecDestBLGoodsCd;            // ������BL���i�R�[�h
            targetRow.RecDestBLGoodsNm = sourceRow.RecDestBLGoodsNm;            // ������BL���i�R�[�h����
            targetRow.RecSourceBLGoodsCd = sourceRow.RecSourceBLGoodsCd;        // ������BL���i�R�[�h
            targetRow.RecSourceBLGoodsNm = sourceRow.RecSourceBLGoodsNm;        // ������BL���i�R�[�h����
            targetRow.GoodsComment = sourceRow.GoodsComment;                    // ���i�R�����g
            targetRow.FilterGuid = sourceRow.FilterGuid;
            targetRow.RowDeleteFlg = sourceRow.RowDeleteFlg;
            targetRow.UpdateTime = sourceRow.UpdateTime;

            targetRow.RowStatus = ctROWSTATUS_NORMAL;

            #endregion

            return targetRow;
        }

        # endregion
        /// <summary>
        /// ���׃O���b�h�ݒ菈��
        /// </summary>
        internal void SettingGrid()
        {
            try
            {
                // �`����ꎞ��~
                this.uGrid_Details.BeginUpdate();

                // �`�悪�K�v�Ȗ��׌������擾����B
                int cnt = this._recGoodsLkDataTable.Count;

                // �e�s���Ƃ̐ݒ�
                for (int i = 0; i < cnt; i++)
                {
                    this.SettingGridRow(i);
                }

            }
            finally
            {
                // �`����J�n
                this.uGrid_Details.EndUpdate();
            }
        }


		/// <summary>
		/// ���׃O���b�h�E�s�P�ʂł̃Z���ݒ�
		/// </summary>
		/// <param name="rowIndex">�Ώۍs�C���f�b�N�X</param>
        /// <param name="stockSlip">�f�[�^�N���X�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Update Note : 2012/10/15 �c����</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00�A2012/11/14�z�M��</br>
        /// <br>              Redmine#32862 ���i�ύX�������ׁA�F��ς���悤�ɏC��</br>
        /// </remarks>
        private void SettingGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // �s�X�e�[�^�X���擾
            // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
            //int rowStatus = this._recGoodsLkDataTable[rowIndex].RowStatus;
            RecGoodsLkDataSet.RecGoodsLkRow targetRow = this.GetRecGoodsLkRow(int.Parse(this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString()));
            int rowStatus = targetRow.RowStatus;
            // �sGuid���擾
            Guid filterGuid = targetRow.FilterGuid;
            // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<
            
            // �w��s�̑S�Ă̗�ɑ΂��Đݒ���s���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // �Z�������擾
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];

                if (cell == null) continue;

                cell.Row.Hidden = false;

                // �A���_�[���C����S�ẴZ���ɑ΂��Ĕ�\���Ƃ���
                cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;

                if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName) // ADD 2015/02/10 �s�F T.Miyamoto
                {
                    if (rowStatus == ctROWSTATUS_COPY)
                    {
                        // --- UPD 2015/03/05 Y.Wakita Redmine#333 ---------->>>>>
                        //cell.Appearance.BackColor = Color.Pink;
                        //cell.Appearance.BackColor2 = Color.Pink;
                        //cell.Appearance.BackColorDisabled = Color.Pink;
                        //cell.Appearance.BackColorDisabled2 = Color.Pink;
                        //cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                        cell.Appearance.BackColor = Color.Orange;
                        cell.Appearance.BackColor2 = Color.Orange;
                        cell.Appearance.BackColorDisabled = Color.Orange;
                        cell.Appearance.BackColorDisabled2 = Color.Orange;
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                        // --- UPD 2015/03/05 Y.Wakita Redmine#333 ----------<<<<<

                        //cell.Activation = Activation.NoEdit;

                    }
                    else if (rowStatus == ctROWSTATUS_CUT)
                    {
                        cell.Appearance.BackColor = Color.Pink;
                        cell.Appearance.BackColor2 = Color.Pink;
                        cell.Appearance.BackColorDisabled = Color.Pink;
                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;

                        //cell.Activation = Activation.NoEdit;
                    }
                    // --- ADD 2015/03/06 T.Miyamoto Redmine#341 ------------------------------>>>>>
                    else if (targetRow.RowDeleteFlg == 1)
                    {
                        cell.Appearance.BackColor = Color.Pink;
                        cell.Appearance.BackColor2 = Color.Pink;
                        cell.Appearance.BackColorDisabled = Color.Pink;
                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                    }
                    // --- ADD 2015/03/06 T.Miyamoto Redmine#341 ------------------------------<<<<<
                    else
                    {
                        // --- DEL 2015/03/06 T.Miyamoto Redmine#341 ------------------------------>>>>>
                        //// --- ADD 2015/03/05 Y.Wakita Redmine#333 ---------->>>>>
                        //if (cell.Appearance.BackColor != Color.Orange) continue;
                        //// --- ADD 2015/03/05 Y.Wakita Redmine#333 ----------<<<<<
                        // --- DEL 2015/03/06 T.Miyamoto Redmine#341 ------------------------------<<<<<
                        cell.Appearance.BackColor = Color.Empty;
                        cell.Appearance.BackColor2 = Color.Empty;
                        cell.Appearance.BackColorDisabled = Color.Empty;
                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                    }
                }
                else if (cell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName
                    || cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName) // 2015/02/12
                {
                        // �N���A�s�̓��̓��[�h��ύX����B
                        if (!Guid.Empty.Equals(filterGuid))
                        {
                            cell.Activation = Activation.NoEdit;
                        }
                        else
                        {
                            cell.Activation = Activation.AllowEdit;
                        }
                }
                // --- ADD 2015/03/09 T.Miyamoto Redmine#341 ------------------------------>>>>>
                else if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName
                 || cell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName
                 || cell.Column.Key == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName)
                {
                    if (targetRow.RowDeleteFlg == 1)
                    {
                        cell.Activation = Activation.NoEdit;
                    }
                    else
                    {
                        cell.Activation = Activation.AllowEdit;
                    }
                }
                // --- UPD 2015/03/09 T.Miyamoto Redmine#341 ------------------------------<<<<<
            }
        }


        /// <summary>
        /// MouseClick�C�x���g
        /// </summary>
        /// <returns></returns>
        private void uGrid_Details_MouseClick(object sender, MouseEventArgs e)
        {
            // �E�N���b�N�ȊO�̏ꍇ
            if (e.Button != MouseButtons.Right) return;

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
                    // string columnName = ((Infragistics.Win.UltraWinGrid.ColumnHeader)objElement.SelectableItem).Column.Key;
                }
            }

            if (isColumnHeader)
            {
                // ��w�b�_�[�E�N���b�N���͉������Ȃ�
            }
            else
            {
                // ����ȊO�ŉE�N���b�N���ꂽ�ꍇ�́A�ҏW�̃|�b�v�A�b�v��\������
                ((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_MainMenu.Tools["PopupMenuTool_Edit"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_Details);

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

        private void uButton_RowInsert_Click_1(object sender, EventArgs e)
        {

            MessageBox.Show("1");
        }

        private void uButton_RowInsert_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("");
        }
    }
    // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<


    /// <summary>
    /// ���R�����h���i�֘A�ݒ�}�X�^�p�O���b�h�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^�p�O���b�h�ݒ�N���X</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RecGoodsLkUserSet
    {
        // �o�͌`��
        private int _outputStyle;

        // ���׃O���b�h�J�������X�g
        private List<ColumnInfo> _detailColumnsList;

        // ���׃O���b�h�����T�C�Y����
        private bool _autoAdjustDetail;

        # region �R���X�g���N�^
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�p�O���b�h�ݒ�N���X
        /// </summary>
        public RecGoodsLkUserSet()
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
