//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10701342-00 �쐬�S�� : ������
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/06  �C�����e : Redmine#22776 �L�����y�[���Ώۏ��i�ݒ�}�X�^�^�ǉ��s�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/07  �C�����e : Redmine#22810 �@���׍��ڂ̕��E�����T�C�Y�͕ύX���ɕۑ��̑Ή�
//                                                �A���ׁh���[�J�[���́h����h�J�i���́h�ɕύX�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/06  �C�����e : Redmine#22776 �s�ǉ��̓��Ӑ�̃`�F�b�N�Ɋւ��Ă̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ������
// �C �� ��  2011/07/12  �C�����e : Redmine#22919 �@����N�����̕����T�C�Y�ƍ��ڕ��̕ύX
//                                                �A���ׂ̃L�����y�[���R�[�h�ɏ����\������悤�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ������
// �C �� ��  2011/07/14  �C�����e : Redmine#22962 ���_�Ⴂ�œo�^�\�ɂ���悤�ɕύX�Ή�
//                                  Redmine#22957 �Ώۓ��Ӑ�ɐݒ肵�Ă���ꍇ�A�S���Ӑ悪���͂ł���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ������
// �C �� ��  2011/07/14  �C�����e : Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ������
// �C �� ��  2011/07/15  �C�����e : Redmine#22984 �����敪���قȂ�ݒ�ɂ���ƁA���ꏤ�i�ݒ���d���`�F�b�N
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ������
// �C �� ��  2011/07/21  �C�����e : Redmine#23119 �ŏI���׍s�ł̃t�H�[�J�X�J�ڕs���̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/22  �C�����e : Redmine#23119 �񋟗D�Ǖi�Ԃ̕i�����󔒂̂��̂�����܂��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ���N�n��
// �C �� ��  2011/09/05  �C�����e : Redmine#23965 �L�����y�[���Ǘ��@����`�[���́iDelphi�j�̕ύX���̒����̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��
// �C �� ��  2014/03/20  �C�����e : Redmine#42174 �X�V��Column�ǉ��̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;   // ADD 2011/07/07 
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;  // ADD 2011/07/07 
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^ ���׃R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^ ���׃R���g���[���N���X</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br>UpdateNote : 2011/07/06 杍^ Redmine#22776 �L�����y�[���Ώۏ��i�ݒ�}�X�^�^�ǉ��s�̑Ή�</br>
    /// <br>UpdateNote : 2011/07/07 杍^ Redmine#22810 �@���׍��ڂ̕��E�����T�C�Y�͕ύX���ɕۑ��̑Ή�</br>
    /// <br>                                           �A���ׁh���[�J�[���́h����h�J�i���́h�ɕύX�̑Ή�</br>
    /// <br>UpdateNote : 2011/07/11 杍^ Redmine#22776 �s�ǉ��̓��Ӑ�̃`�F�b�N�Ɋւ��Ă̏C��</br>
    /// <br>UpdateNote : 2011/07/12 ������ Redmine#22919 �@����N�����̕����T�C�Y�ƍ��ڕ��̕ύX</br>
    /// <br>�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ �A���ׂ̃L�����y�[���R�[�h�ɏ����\������悤�ɕύX</br>
    /// <br>UpdateNote : 2011/07/14 ������ Redmine#22962 ���_�Ⴂ�œo�^�\�ɂ���悤�ɕύX�Ή�</br>
    /// <br>UpdateNote : 2011/07/14 ������ Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�</br>
    /// <br>UpdateNote : 2011/07/15 ������ Redmine#22984 �����敪���قȂ�ݒ�ɂ���ƁA���ꏤ�i�ݒ���d���`�F�b�N</br>
    /// <br>UpdateNote : 2011/07/21 杍^ Redmine#23119 �ŏI���׍s�ł̃t�H�[�J�X�J�ڕs���̏C��</br>
    /// <br>UpdateNote : 2011/07/22 杍^ Redmine#23119 �񋟗D�Ǖi�Ԃ̕i�����󔒂̂��̂�����܂��̑Ή�</br>
    /// <br>UpdateNote : 2011/09/05 ���N�n�� Redmine#23965 �L�����y�[���Ǘ��@����`�[���́iDelphi�j�̕ύX���̒����̑Ή�</br>
    /// </remarks>
    public partial class PMKHN09621UB : UserControl
    {
        # region Private Members
        private CampaignMngDataSet.CampaignMngDataTable _campaignMngDataTable;
        private CampaignObjGoodsStAcs _campaignObjGoodsStAcs = null;
        private Dictionary<Guid, CampaignObjGoodsSt> _prevCampaignMngDic = new Dictionary<Guid, CampaignObjGoodsSt>();

        private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

        private const string TOOLBAR_ROWDELETEBUTTON_KEY = "ButtonTool_RowDelete";						// �s�폜
        private const string TOOLBAR_ALLDELETEBUTTON_KEY = "ButtonTool_AllRowDelete";					// �S�폜
        private const string TOOLBAR_REVIVALBUTTON_KEY = "ButtonTool_Revival";						    // ����
        private const string TOOLBAR_GETPRICEBUTTON_KEY = "ButtonTool_GetPriceDate";					// ���i���擾

        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "PMKHN09620U_Construction.XML";   // ADD 2011/07/07 

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;
        private string _loginSectionCode = string.Empty;
        /// <summary>BL�R�[�h</summary>
        private int _swBLGoodsCode = 0;
        /// <summary>�i��</summary>
        private string _swGoodsNo = string.Empty;
        /// <summary>���[�J�[�R�[�h</summary>
        private int _swGoodsMakerCd = 0;

        private string _swSectionCode = "00";
        private int _swBLGroupU = 0;
        private string _swUserGdBd = string.Empty;
        private string _swCustomerInfo = string.Empty;
        private int _swCampaignCd = 0;

        private CustomerSearchRet _customerSearchRet = null;

        /// <summary>DCKHN09092A)BL�R�[�h</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;

        private bool focusFlg = true;
        private bool leftFocusFlg = false;    // ADD 2011/07/07 

        // ���[�U�[�ݒ�
        private CampaignMngUserSet _userSetting; // ADD 2011/07/07 

        private CampaignLinkAcs _campaignLinkAcs;
        private SecInfoSetAcs _secInfoSetAcs;
        private MakerAcs _makerAcs;
        private BLGroupUAcs _blGroupUAcs;
        private UserGuideAcs _userGuideAcs;

        internal event SetGuidButtonEventHandler SetGuidButton;
        internal delegate void SetGuidButtonEventHandler(Boolean enable);

        // ---ADD 2011/07/12--------------->>>>>
        internal event GetCampaignInfoEventHandler GetCampaignInfo;
        internal delegate void GetCampaignInfoEventHandler(out string campaignCode, out string campaignName, out string sectionCode);
        // ---ADD 2011/07/12---------------<<<<<

        /// <summary>�t�H�[�J�X�̕ω�</summary>
        internal event EventHandler GridKeyUpTopRow;
        #endregion

        #region �v���p�e�B
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^ �A�N�Z�X�N���X�v���p�e�B
        /// </summary>
        public CampaignObjGoodsStAcs CampaignObjGoodsStAcs
        {
            get { return this._campaignObjGoodsStAcs; }
        }
        /// <summary>
        /// ���ו��Ƀt�H�[�J�X����v���p�e�B
        /// </summary>
        public Boolean FocusFlg
        {
            get { return this.focusFlg; }
        }

        // ----- ADD 2011/07/07 ------- <<<<<<<<<
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
        public CampaignMngUserSet UserSetting
        {
            get { return this._userSetting; }
        }
        // ----- ADD 2011/07/07 ------- <<<<<<<<<
        #endregion

        # region Constroctors
        /// <summary>
        /// ���͖��ד��̓R���g���[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���͖��ד��̓R���g���[���N���X �f�t�H���g���s���R���g���[���N���X�ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/07 杍^ Redmine#22810 ���׍��ڂ̕��E�����T�C�Y�͕ύX���ɕۑ��̑Ή�</br>
        /// </remarks>
        public PMKHN09621UB()
        {
            InitializeComponent();
            this._campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();
            this._campaignMngDataTable = this._campaignObjGoodsStAcs.CampaignMngDataTable;

            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._campaignLinkAcs = new CampaignLinkAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._makerAcs = new MakerAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();

            this._userSetting = new CampaignMngUserSet();  // ADD 2011/07/07 
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void PMKHN09621UB_Load(object sender, EventArgs e)
        {
            // �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
            this.uGrid_Details.DataSource = this._campaignObjGoodsStAcs.CampaignMngDataTable;

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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
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
                // ���i���擾
                case TOOLBAR_GETPRICEBUTTON_KEY:
                    {
                        this.uButton_GetPriceDate_Click(sender, new EventArgs());
                        break;
                    }
            }
        }

        /// <summary>
        /// ���׏������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note	   : ���׏������C�x���g���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
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
                        if ((int)row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                        {
                            //�폜�w��敪:0
                            if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                            {
                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                                    this.SetGuidButton(false);
                                }

                                // �s�폜��BackColor�̐ݒ�(�s���N�F)�A���͋��ݒ�
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    cell.Appearance.BackColor = Color.Pink;
                                    cell.Appearance.BackColor2 = Color.Pink;
                                    cell.Appearance.BackColorDisabled = Color.Pink;
                                    cell.Appearance.BackColorDisabled2 = Color.Pink;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;

                                    cell.Activation = Activation.NoEdit;
                                }
                                row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                            }
                            //�폜�w��敪:1
                            else
                            {
                                // �s�폜��BackColor�̐ݒ�(�s���N�F)�A���͋��ݒ�
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    cell.Appearance.BackColor = Color.Pink;
                                    cell.Appearance.BackColor2 = Color.Pink;
                                    cell.Appearance.BackColorDisabled = Color.Pink;
                                    cell.Appearance.BackColorDisabled2 = Color.Pink;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                                row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                            }
                        }
                        else
                        {
                            //�폜�w��敪:0
                            if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                            {
                                #region �s�폜����
                                // �V�K�s�̔��f
                                bool isNewRow = false;

                                if ((Guid)row.Cells[this._campaignMngDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                                {
                                    isNewRow = true;
                                }

                                #region ���͋��ݒ�
                                row.Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Activation = Activation.AllowEdit;
                                if (isNewRow == true)
                                {
                                    row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                    row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activation = Activation.AllowEdit;
                                }
                                switch ((int)row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Value)
                                {
                                    case 1:
                                        {
                                            row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.AllowEdit;
                                            break;
                                        }
                                    case 2:
                                        {
                                            row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            break;
                                        }
                                    case 3:
                                        {
                                            row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            break;
                                        }
                                    case 4:
                                        {
                                            row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            break;
                                        }
                                    case 5:
                                        {
                                            row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            break;
                                        }
                                    case 6:
                                        {
                                            row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                            break;
                                        }
                                }
                                if ((int)row.Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Value == 1)
                                {
                                    row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                    row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Activation = Activation.AllowEdit;
                                    if ((int)row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Value == 1)
                                    {
                                        row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.AllowEdit;
                                    }
                                    row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activation = Activation.AllowEdit;
                                    row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activation = Activation.AllowEdit;
                                    row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activation = Activation.AllowEdit;
                                }
                                #endregion

                                // �s�폜������BackColor�̐ݒ�(�ʏ�F)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Activation == Activation.NoEdit
                                        && cell.Column.Key != this._campaignMngDataTable.RowNoColumn.ColumnName)
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
                                    if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CampaignCodeColumn.ColumnName
                                        || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName
                                        || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName
                                        || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName
                                        || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName
                                        || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SalesCodeColumn.ColumnName
                                        || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CustomerCodeColumn.ColumnName)
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
                                row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
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
                                    if (cell.Column.Key == this._campaignMngDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                                row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
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
                if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                {
                    for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                    {
                        if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value == 0)
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
                            if ((Guid)row.Cells[this._campaignMngDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                            {
                                isNewRow = true;
                            }

                            row.Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                            row.Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Activation = Activation.AllowEdit;
                            if (isNewRow == true)
                            {
                                row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activation = Activation.AllowEdit;
                            }
                            switch ((int)row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Value)
                            {
                                case 1:
                                    {
                                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.AllowEdit;
                                        break;
                                    }
                                case 2:
                                    {
                                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        break;
                                    }
                                case 3:
                                    {
                                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        break;
                                    }
                                case 4:
                                    {
                                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        break;
                                    }
                                case 5:
                                    {
                                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        break;
                                    }
                                case 6:
                                    {
                                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                        break;
                                    }
                            }
                            if ((int)row.Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Value == 1)
                            {
                                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Activation = Activation.AllowEdit;
                                if ((int)row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Value == 1)
                                {
                                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.AllowEdit;
                                }
                                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activation = Activation.AllowEdit;
                            }
                        }
                        #endregion

                        // �s�폜������BackColor�̐ݒ�(�ʏ�F)
                        foreach (UltraGridRow row in this.uGrid_Details.Rows)
                        {
                            if ((int)row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value == 1)
                            {
                                // �s�폜������BackColor�̐ݒ�(�ʏ�F)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Activation != Activation.NoEdit
                                        || cell.Column.Key == this._campaignMngDataTable.RowNoColumn.ColumnName)
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

                            row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        if (this.uGrid_Details.ActiveCell != null)
                        {
                            if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CampaignCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SalesCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CustomerCodeColumn.ColumnName)
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
                            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                            {
                                // �s�폜��BackColor�̐ݒ�(�s���N�F)�A���͋��ݒ�
                                foreach (UltraGridCell cell in this.uGrid_Details.Rows[rowIndex].Cells)
                                {
                                    cell.Appearance.BackColor = Color.Pink;
                                    cell.Appearance.BackColor2 = Color.Pink;
                                    cell.Appearance.BackColorDisabled = Color.Pink;
                                    cell.Appearance.BackColorDisabled2 = Color.Pink;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;

                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                        }
                    }

                }
                //�폜�w��敪:1
                else
                {
                    for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                    {
                        if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
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
                            if ((int)row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value == 1)
                            {
                                // �s�폜������BackColor�̐ݒ�(�ʏ�F)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Column.Key == this._campaignMngDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
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

                            row.Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                    }
                    else
                    {
                        for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                        {
                            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                            {
                                // �s�폜��BackColor�̐ݒ�(�s���N�F)�A���͋��ݒ�
                                foreach (UltraGridCell cell in this.uGrid_Details.Rows[rowIndex].Cells)
                                {
                                    cell.Appearance.BackColor = Color.Pink;
                                    cell.Appearance.BackColor2 = Color.Pink;
                                    cell.Appearance.BackColorDisabled = Color.Pink;
                                    cell.Appearance.BackColorDisabled2 = Color.Pink;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;

                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
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
                        if ((int)this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value != 2)
                        {
                            //��������
                            foreach (UltraGridCell cell in this.uGrid_Details.Rows[row.Index].Cells)
                            {
                                if (cell.Column.Key == this._campaignMngDataTable.RowNoColumn.ColumnName)
                                {
                                    cell.Appearance.BackColor = Color.Empty;
                                    cell.Appearance.BackColor2 = Color.Empty;
                                    cell.Appearance.BackColorDisabled = Color.Empty;
                                    cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                                else
                                {
                                    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                            }

                            this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 2;
                        }
                        else
                        {
                            //������������
                            foreach (UltraGridCell cell in this.uGrid_Details.Rows[row.Index].Cells)
                            {
                                if (cell.Column.Key != this._campaignMngDataTable.RowNoColumn.ColumnName)
                                {
                                    cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                    cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                                    cell.Appearance.BackColorDisabled = ct_DISABLE_COLOR;
                                    cell.Appearance.BackColorDisabled2 = ct_DISABLE_COLOR;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                            }

                            this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
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
        /// ���i���擾����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���i���擾�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_GetPriceDate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "��ʂɕ\������Ă���S���ׂɑ΂��āA���i�����Đݒ肵�܂��B" + "\r\n" + "\r\n" +
                        "��낵���ł����H",
                        0,
                        MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
            this.SetGuidButton(false);

            foreach (CampaignMngDataSet.CampaignMngRow row in this._campaignMngDataTable.Rows)
            {
                if (row.SalesPriceSetDiv == 1)
                {
                    CampaignSt campaignSt;
                    if (this._campaignObjGoodsStAcs.CampaignStDic.ContainsKey(row.CampaignCode))
                    {
                        campaignSt = this._campaignObjGoodsStAcs.CampaignStDic[row.CampaignCode];

                        string strDate = string.Empty; 
                        int intDate = 0;
                        strDate = campaignSt.ApplyStaDate.Date.ToString("yyyyMMdd");
                        if (int.TryParse(strDate, out intDate))
                        {
                            row.PriceStartDate = intDate;
                        }

                        strDate = campaignSt.ApplyEndDate.Date.ToString("yyyyMMdd");
                        if (int.TryParse(strDate, out intDate))
                        {
                            row.PriceEndDate = intDate;
                        }
                    }
                }
            }
            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            if (this.uGrid_Details.ActiveCell != null)
            {
                if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CampaignCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SalesCodeColumn.ColumnName
                                            || this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CustomerCodeColumn.ColumnName)
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

        /// <summary>
        /// �Z���̃f�[�^�`�F�b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : �Z���̃f�[�^�`�F�b�N�����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
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
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName)
                        {
                            editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// �O��l���Z�b�g
                        }
                        else if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
                        {
                            editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// �O��l���Z�b�g
                        }
                        else
                        {
                            editorBase.Value = 0;				// 0���Z�b�g
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�				
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName)
                        {
                            editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// �O��l���Z�b�g
                        }
                        else if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
                        {
                            editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// �O��l���Z�b�g
                        }
                        else
                        {
                            editorBase.Value = 0;				// 0���Z�b�g
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
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
                            if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName)
                            {
                                editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// �O��l���Z�b�g
                            }
                            else if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
                            {
                                editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// �O��l���Z�b�g
                            }
                            else
                            {
                                editorBase.Value = 0;				// 0���Z�b�g
                                this.uGrid_Details.ActiveCell.Value = 0;
                            }
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            this.SetGridGuid();
        }

        /// <summary>
        /// �O���b�h�Z���ҏW���[�h�ɓ������㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Z���ҏW���[�h�ɓ������㔭���C�x���g</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void uGrid_Details_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName)
                {
                    if (this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                    {
                        int inputValue = 0;
                        if (int.TryParse(this.uGrid_Details.ActiveCell.Text, out inputValue))
                        {
                            this.uGrid_Details.ActiveCell.Value = inputValue.ToString();
                        }
                        else
                        {
                            this.uGrid_Details.ActiveCell.Value = "0";
                        }
                    }
                    this.uGrid_Details.ActiveCell.SelectAll();
                }
            }
        }

        /// <summary>
        /// �O���b�h�Z���o��㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Z���o��㔭���C�x���g</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                if (this.uGrid_Details.ActiveCell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName)
                {
                    this.uGrid_Details.ActiveCell.Value = this.uGrid_Details.ActiveCell.Text.PadLeft(2, '0');
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;

            if (cell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName)
            {
                this._swSectionCode = e.Cell.Value.ToString().Trim().PadLeft(2, '0');
            }
            else if (cell.Column.Key == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName)
            {
                this._swGoodsMakerCd = (Int32)e.Cell.Value;
            }
            else if (cell.Column.Key == this._campaignMngDataTable.GoodsNoColumn.ColumnName)
            {
                this._swGoodsNo = e.Cell.Value.ToString().Trim();
            }
            else if (cell.Column.Key == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName)
            {
                this._swBLGoodsCode = (Int32)e.Cell.Value;
            }
            else if (cell.Column.Key == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName)
            {
                this._swBLGroupU = (Int32)e.Cell.Value;
            }
            else if (cell.Column.Key == this._campaignMngDataTable.SalesCodeColumn.ColumnName)
            {
                this._swUserGdBd = e.Cell.Value.ToString().Trim();
            }
            else if (cell.Column.Key == this._campaignMngDataTable.CustomerCodeColumn.ColumnName)
            {
                this._swCustomerInfo = e.Cell.Value.ToString().Trim();
            }
            else if (cell.Column.Key == this._campaignMngDataTable.CampaignCodeColumn.ColumnName)
            {
                this._swCampaignCd = (Int32)e.Cell.Value;
            }
        }

        /// <summary>
        /// CellChange �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����value��ω����ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void uGrid_Details_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;
            UltraGridRow row = e.Cell.Row;

            // �ݒ���
            if (cell.Column.Key == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName)
            {
                this.CampaignSettingKindChanged(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Text, row);
            }
            // �����敪
            else if (cell.Column.Key == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
            {
                int cellValue = 0;
                int.TryParse(cell.Text, out cellValue);

                this.SalesPriceSetDivChanged(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Text, row);

                if ((int)this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value != 0 && ("1:�L��".Equals(cell.Text) || cellValue == 1))
                {
                    CampaignSt campaignSt = null;
                    if (this._campaignObjGoodsStAcs.CampaignStDic.ContainsKey((int)this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value))
                    {
                        campaignSt = this._campaignObjGoodsStAcs.CampaignStDic[(int)this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value];
                    }

                    if (campaignSt != null)
                    {
                        this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Value = Convert.ToInt32(campaignSt.ApplyStaDate.Date.ToString("yyyyMMdd"));
                        this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Value = Convert.ToInt32(campaignSt.ApplyEndDate.Date.ToString("yyyyMMdd"));
                    }
                }
            }
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
        /// <br>UpdateNote :  2011/07/06 杍^ Redmine#22776 �L�����y�[���Ώۏ��i�ݒ�}�X�^�^�ǉ��s�̑Ή�</br>
        /// <br>UpdateNote :  2011/07/07 杍^ Redmine#22810 ���E�[�̍��ڂŎ~�܂�悤�ɏC���B</br>
        /// <br>UpdateNote : 2011/07/12 ������ Redmine#22919 �@����N�����̕����T�C�Y�ƍ��ڕ��̕ύX</br>
        /// <br>UpdateNote : 2011/07/14 ������ Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�</br>
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
            }

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
                                if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                                {
                                    // ----- UPD 2011/07/06 ------- >>>>>>>>>
                                    if (CheckDateForDown())
                                    {
                                        #region �ŏI�s�̏ꍇ�A�V�K�s��ǉ�����
                                        CampaignMngDataSet.CampaignMngRow newRow = this._campaignMngDataTable.NewCampaignMngRow();
                                        newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                                        newRow.FilterGuid = Guid.Empty;
                                        newRow.SectionCode = "00";
                                        newRow.GoodsName = "";
                                        newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");

                                        this._campaignMngDataTable.AddCampaignMngRow(newRow);

                                        this.DetailGridInitSetting();
                                        #endregion
                                        // ---UPD 2011/07/12---------------->>>>>
                                        //if (rowIndex < this.uGrid_Details.Rows.Count - 1)
                                        //{
                                        //    this.uGrid_Details.Rows[rowIndex + 1].Cells[columnKey].Activate();
                                        //}

                                        string campaignCode = string.Empty;
                                        string campaignName = string.Empty;
                                        string sectionCode = string.Empty;
                                        this.GetCampaignInfo(out campaignCode, out campaignName, out sectionCode);
                                        if (campaignCode == string.Empty &&
                                            campaignName == string.Empty &&
                                            sectionCode == string.Empty)
                                        {
                                            if (rowIndex < this.uGrid_Details.Rows.Count - 1)
                                            {
                                                this.uGrid_Details.Rows[rowIndex + 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                                            }
                                        }
                                        else
                                        {
                                            this.uGrid_Details.Rows[rowIndex + 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                                            this.uGrid_Details.Rows[rowIndex + 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = campaignCode;
                                            this.uGrid_Details.Rows[rowIndex + 1].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = campaignName;
                                            this.uGrid_Details.Rows[rowIndex + 1].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = sectionCode;

                                            this.uGrid_Details.Rows[rowIndex + 1].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                                        }

                                        // ---ADD 2011/07/14------------->>>>>
                                        CampaignObjGoodsSt campaignObjGoodsSt = null;
                                        this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                                        this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                                        // ---ADD 2011/07/14-------------<<<<<
                                        // ---UPD 2011/07/12----------------<<<<<
                                    }
                                    // ----- UPD 2011/07/06 ------- <<<<<<<<<
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

                        // ----- UPD 2011/07/07 ------- >>>>>>>>>
                        //if ((rowIndex == 0) &&
                        //       (columnKey == this._campaignMngDataTable.CampaignCodeColumn.ColumnName))
                        if (columnKey == this._campaignMngDataTable.CampaignCodeColumn.ColumnName
                            || columnKey == this._campaignMngDataTable.UpdateTimeColumn.ColumnName)
                        {
                            // ���[��VisiblePosition���擾
                            //int firstPosition = this.GetGridFirstPosition(this.uGrid_Details);

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
                        // ----- UPD 2011/07/07 ------- <<<<<<<<<
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
                                    columnName = this._campaignMngDataTable.PriceEndDateColumn.ColumnName;
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

                        // ----- UPD 2011/07/07 ------- >>>>>>>>>
                        if (columnKey == this._campaignMngDataTable.UpdateTimeColumn.ColumnName)
                        {
                            // �Ȃ��B
                        }
                        // UPD �� 2014/03/20 -------------------------------------------------------------->>>>>
                        //else if (columnKey == this._campaignMngDataTable.PriceEndDateColumn.ColumnName)
                        else if (columnKey == this._campaignMngDataTable.UpdateTime2Column.ColumnName)
                        // UPD �� 2014/03/20 --------------------------------------------------------------<<<<<
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
                                        columnName = this._campaignMngDataTable.CampaignCodeColumn.ColumnName;
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
                        // ----- UPD 2011/07/07 ------- <<<<<<<<<
                        break;
                    }
            }
            this.focusFlg = true;
        }

        // ----- ADD 2011/07/07 ------- >>>>>>>>>
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
        // ----- ADD 2011/07/07 ------- <<<<<<<<<

        /// <summary>
        /// �O���b�h�Z���A�v�f�g�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Z���A�v�f�g�㔭���C�x���g</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
        /// <br>UpdateNote  : 2011/07/07 杍^ Redmine#22810 ���ׁh���[�J�[���́h����h�J�i���́h�ɕύX�̑Ή�</br>
        /// <br>UpdateNote  : 2011/07/22 杍^ Redmine#23119 �񋟗D�Ǖi�Ԃ̕i�����󔒂̂��̂�����܂��̑Ή�</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;
            UltraGridRow row = e.Cell.Row;

            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
            // �ݒ���
            if (cell.Column.Key == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName)
            {
                //�Ȃ��B
            }
            // �����敪
            else if (cell.Column.Key == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
            {
                //�Ȃ��B
            }
            // ����
            else if (cell.Column.Key == this._campaignMngDataTable.CampaignCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // ���͒l���擾
                Int32.TryParse(cell.Value.ToString(), out inputValue);

                if (inputValue != 0)
                {
                    CampaignSt campaignSt = null;
                    if (this._campaignObjGoodsStAcs.CampaignStDic.ContainsKey(inputValue))
                    {
                        campaignSt = this._campaignObjGoodsStAcs.CampaignStDic[inputValue];
                    }

                    if (campaignSt != null && campaignSt.LogicalDeleteCode == 0)
                    {
                        // �L�����y�[���R�[�h�̒l�ݒ�
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = inputValue;
                        this._swCampaignCd = inputValue;

                        // �L�����y�[�����̒l�ݒ�
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = campaignSt.CampaignName;

                        // ���_�̒l�ݒ�
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = campaignSt.SectionCode.Trim().PadLeft(2, '0');
                        this._swSectionCode = campaignSt.SectionCode.Trim().PadLeft(2, '0');

                        // �K�p���̒l�ݒ�
                        if ((int)this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Value == 1)
                        {
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Value = Convert.ToInt32(campaignSt.ApplyStaDate.Date.ToString("yyyyMMdd"));
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Value = Convert.ToInt32(campaignSt.ApplyEndDate.Date.ToString("yyyyMMdd"));
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�L�����y�[���R�[�h�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = this._swCampaignCd;
                        this.focusFlg = false;
                    }
                }
                else
                {
                    // �L�����y�[���R�[�h�̒l�ݒ�
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = 0;
                    this._swCampaignCd = 0;

                    // �L�����y�[�����̒l�ݒ�
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = string.Empty;
                }
            }
            // ���_
            else if (cell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName)
            {
                string inputValue = e.Cell.Value.ToString().Trim().PadLeft(2, '0');

                if (!"00".Equals(inputValue))
                {
                    SecInfoSet secInfoSet = null;
                    if (this._campaignObjGoodsStAcs.SecInfoSetDic.ContainsKey(inputValue))
                    {
                        secInfoSet = this._campaignObjGoodsStAcs.SecInfoSetDic[inputValue];
                    }

                    if (secInfoSet != null)
                    {
                        this._swSectionCode = secInfoSet.SectionCode.Trim();
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���_�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = this._swSectionCode;
                        this.focusFlg = false;
                    }
                }
                else
                {
                    this._swSectionCode = "00";
                }
            }
            // Ұ��
            else if (cell.Column.Key == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // ���͒l���擾
                Int32.TryParse(cell.Value.ToString(), out inputValue);


                if (inputValue != 0)
                {
                    MakerUMnt makerUMnt = null;
                    if (this._campaignObjGoodsStAcs.MakerUMntDic.ContainsKey(inputValue))
                    {
                        makerUMnt = this._campaignObjGoodsStAcs.MakerUMntDic[inputValue];
                    }

                    if (makerUMnt != null)
                    {
                        if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Text.Trim()))
                        {
                            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                            GoodsUnitData goodsUnitData = new GoodsUnitData();
                            string msg = string.Empty;
                            GoodsCndtn cndtn = new GoodsCndtn();
                            cndtn.EnterpriseCode = this._enterpriseCode;
                            cndtn.GoodsMakerCd = inputValue;
                            cndtn.GoodsNo = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Text.Trim();
                            cndtn.GoodsKindCode = 9;
                            int status = this._campaignObjGoodsStAcs.GoodsAcsClass.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg);

                            if (goodsUnitDataList.Count > 0)
                            {
                                goodsUnitData = goodsUnitDataList[0];

                                if (goodsUnitData.LogicalDeleteCode == 0)
                                {
                                    this._swGoodsMakerCd = inputValue;
                                    //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerName;   // DEL 2011/07/07 
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerKanaName; // ADD 2011/07/07 
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = goodsUnitData.GoodsNo;
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = goodsUnitData.GoodsNameKana;
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

                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = this._swGoodsMakerCd;
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                this.focusFlg = false;
                            }
                        }
                        else
                        {
                            this._swGoodsMakerCd = inputValue;
                            //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerName; // DEL 2011/07/07 
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerKanaName;   // ADD 2011/07/07 
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

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = this._swGoodsMakerCd;
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        this.focusFlg = false;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Text.Trim()))
                    {
                        List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        string msg = string.Empty;
                        GoodsCndtn cndtn = new GoodsCndtn();
                        cndtn.EnterpriseCode = this._enterpriseCode;

                        if (inputValue != 0)
                        {
                            cndtn.GoodsMakerCd = inputValue;
                        }
                        cndtn.GoodsNo = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Text.Trim();
                        cndtn.GoodsKindCode = 9;
                        int status = this._campaignObjGoodsStAcs.GoodsAcsClass.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg);

                        if (goodsUnitDataList.Count > 0)
                        {
                            goodsUnitData = goodsUnitDataList[0];

                            if (goodsUnitData.LogicalDeleteCode == 0)
                            {
                                this._swGoodsMakerCd = goodsUnitData.GoodsMakerCd;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = goodsUnitData.GoodsMakerCd;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = goodsUnitData.GoodsNameKana;
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

                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = this._swGoodsMakerCd;
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            this.focusFlg = false;
                        }
                    }
                    else
                    {
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = 0;
                        this._swGoodsMakerCd = 0;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = string.Empty;
                    }
                }
            }
            // �i��
            else if (cell.Column.Key == this._campaignMngDataTable.GoodsNoColumn.ColumnName)
            {
                string goodsNo = cell.Value.ToString();
                int goodsMakerCd = (int)this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value;

                if (!String.IsNullOrEmpty(goodsNo))
                {
                    if (!this._swGoodsNo.Equals(goodsNo))
                    {
                        List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        string msg = string.Empty;
                        GoodsCndtn cndtn = new GoodsCndtn();
                        cndtn.EnterpriseCode = this._enterpriseCode;
                        cndtn.SectionCode = this._loginSectionCode;  // ADD 2011/07/22
                        if (goodsMakerCd != 0)
                        {
                            cndtn.GoodsMakerCd = goodsMakerCd;
                        }
                        cndtn.GoodsNo = cell.Value.ToString().Trim();
                        cndtn.GoodsKindCode = 9;

                        int status = this._campaignObjGoodsStAcs.GoodsAcsClass.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg);

                        // ADD 2011/07/22 --- >>>
                        if (goodsUnitDataList.Count == 0)
                        {
                            cndtn.SectionCode = "00";
                            status = this._campaignObjGoodsStAcs.GoodsAcsClass.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg);
                        }
                        // ADD 2011/07/22 --- <<<
                        if (goodsUnitDataList.Count > 0)
                        {
                            goodsUnitData = goodsUnitDataList[0];

                            if (goodsUnitData.LogicalDeleteCode == 0)
                            {
                                this._swGoodsNo = goodsUnitData.GoodsNo;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = goodsUnitData.GoodsMakerCd;
                                MakerUMnt makerUMnt = null;
                                try
                                {
                                    makerUMnt = this._campaignObjGoodsStAcs.MakerUMntDic[goodsUnitData.GoodsMakerCd];
                                }
                                catch
                                {
                                }
                                finally
                                {
                                    if (makerUMnt != null)
                                    {
                                        //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerName;   // DEL 2011/07/07 
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerKanaName; // ADD 2011/07/07 
                                    }
                                }
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = goodsUnitData.GoodsNo;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = goodsUnitData.GoodsNameKana;
                            }
                        }
                        else if (status == -1)
                        {
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = string.Empty;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
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

                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = this._swGoodsNo;
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            this.focusFlg = false;
                        }
                    }
                }
                else
                {
                    this._swGoodsNo = string.Empty;
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = 0;
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = string.Empty;
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                }
            }
            // BL����
            else if (cell.Column.Key == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // ���͒l���擾
                Int32.TryParse(cell.Value.ToString(), out inputValue);
                if (inputValue != 0)
                {
                    BLGoodsCdUMnt blGoodsCdUMnt = null;
                    if (this._campaignObjGoodsStAcs.BLGoodsCdDic.ContainsKey(inputValue))
                    {
                        blGoodsCdUMnt = this._campaignObjGoodsStAcs.BLGoodsCdDic[inputValue];
                    }

                    if (blGoodsCdUMnt != null)
                    {
                        this._swBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsCode;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsHalfName;
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

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = this._swBLGoodsCode;
                        this.focusFlg = false;
                    }
                }
                else
                {
                    this._swBLGoodsCode = 0;
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = 0;
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                }
            }
            // ��ٰ�
            else if (cell.Column.Key == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // ���͒l���擾
                Int32.TryParse(cell.Value.ToString(), out inputValue);

                if (inputValue != 0)
                {
                    BLGroupU blGroupU = null;
                    if (this._campaignObjGoodsStAcs.BLGroupDic.ContainsKey(inputValue))
                    {
                        blGroupU = this._campaignObjGoodsStAcs.BLGroupDic[inputValue];
                    }

                    if (blGroupU != null)
                    {
                        this._swBLGroupU = blGroupU.BLGroupCode;
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�O���[�v�R�[�h�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = this._swBLGroupU;
                        this.focusFlg = false;
                    }
                }
                else
                {
                    this._swBLGroupU = 0;
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = 0;
                }
            }
            // �̔��敪
            else if (cell.Column.Key == this._campaignMngDataTable.SalesCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // ���͒l���擾
                Int32.TryParse(cell.Value.ToString(), out inputValue);
                if (cell.Value.ToString().Trim() != string.Empty)
                {
                    UserGdBd userGdBd = null;
                    if (this._campaignObjGoodsStAcs.UserGdBdDic.ContainsKey(inputValue))
                    {
                        userGdBd = this._campaignObjGoodsStAcs.UserGdBdDic[inputValue];
                    }

                    if (userGdBd != null)
                    {
                        this._swUserGdBd = userGdBd.GuideCode.ToString().PadLeft(4, '0');
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = userGdBd.GuideCode.ToString().PadLeft(4, '0');
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�̔��敪�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = this._swUserGdBd;
                        this.focusFlg = false;
                    }
                }
                else
                {
                    this._swUserGdBd = string.Empty;
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = string.Empty;
                }
            }
            // ���Ӑ�
            else if (cell.Column.Key == this._campaignMngDataTable.CustomerCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // ���͒l���擾
                Int32.TryParse(cell.Value.ToString(), out inputValue);

                if (cell.Value.ToString().Trim() != string.Empty)
                {
                    CustomerInfo customerInfo = null;
                    if (this._campaignObjGoodsStAcs.CustomerDic.ContainsKey(inputValue))
                    {
                        customerInfo = this._campaignObjGoodsStAcs.CustomerDic[inputValue];
                    }

                    if (customerInfo != null || inputValue == 0)
                    {
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Value = inputValue.ToString().PadLeft(8, '0');
                        this._swCustomerInfo = inputValue.ToString().PadLeft(8, '0');
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���Ӑ悪���݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Value = this._swCustomerInfo.ToString().PadLeft(8, '0');
                        this.focusFlg = false;
                    }
                }
                else
                {
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Value = string.Empty;
                    this._swCustomerInfo = string.Empty;
                }
            }
            // ���i�J�n��
            else if (cell.Column.Key == this._campaignMngDataTable.PriceStartDateColumn.ColumnName)
            {
                //�Ȃ��B
            }
            // ���i�I����
            else if (cell.Column.Key == this._campaignMngDataTable.PriceEndDateColumn.ColumnName)
            {
                //�Ȃ��B
            }
            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
        }

        /// <summary>
        /// �O���b�h�Z��KeyPress�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Z��KeyPress�����C�x���g</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (!cell.IsInEditMode) return;

            //----------------------------------------------
            // ActiveCell���L�����y�[���R�[�h�̏ꍇ
            //----------------------------------------------
            if (cell.Column.Key == this._campaignMngDataTable.CampaignCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(6, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell�����_�̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.SectionCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell���ݒ��ʁA�����敪�̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(1, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell�����[�J�[�A�̔��敪�̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName
                  || cell.Column.Key == this._campaignMngDataTable.SalesCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell��BL���ށA��ٰ�ߺ��ނ̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName
                  || cell.Column.Key == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(5, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell�����Ӑ�A���i�J�n���A���i�I�����̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.CustomerCodeColumn.ColumnName
                   || cell.Column.Key == this._campaignMngDataTable.PriceStartDateColumn.ColumnName
                   || cell.Column.Key == this._campaignMngDataTable.PriceEndDateColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell���l�����̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.DiscountRateColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(5, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell���������̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.RateValColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell�������z�̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._campaignMngDataTable.PriceFlColumn.ColumnName)
            {
                if (e.KeyChar == '-')
                {
                    if ((cell.Text.Trim().Contains("-") && cell.SelLength == 14)
                        || (!cell.Text.Trim().Contains("-") && cell.SelLength == 13))
                    {
                        return;
                    }

                    if (cell.Text.Trim().Contains("-") || cell.SelStart != 0)
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else
                {
                    if (e.KeyChar != '.')
                    {
                        if (cell.Text.Trim().Contains("-"))
                        {
                            if (cell.SelStart == 11)
                            {
                                e.Handled = true;
                                return;
                            }
                        }
                    }

                    if (cell.Text.Trim().Contains("-"))
                    {
                        if (!this.KeyPressNumCheck(14, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    else
                    {
                        if (!this.KeyPressNumCheck(13, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                        {
                            e.Handled = true;
                            return;
                        }
                    }
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/12 ������ Redmine#22919 �@����N�����̕����T�C�Y�ƍ��ڕ��̕ύX</br>
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
                if (col.Key != this._campaignMngDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = ct_DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
                }
            }

            #region ���\�����ݒ�
            // ---UPD 2011/07/12---------------->>>>>
            //editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].Width = 55;		            // ��
            //editBand.Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].Width = 80;		        // �폜��
            //editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Width = 70;			    // ����
            //editBand.Columns[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Width = 120;			// ����
            //editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Width = 40;		    	// ���_
            //editBand.Columns[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Width = 140;		// �ݒ���
            //editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Width = 50;		    // Ұ��
            //editBand.Columns[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Width = 180;			// Ұ����
            //editBand.Columns[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Width = 150;	                // �i��
            //editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Width = 60;		        // BL����
            //editBand.Columns[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Width = 150;				// �i��
            //editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Width = 60;			    // ��ٰ��
            //editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Width = 80;			    // �̔��敪
            //editBand.Columns[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Width = 75;		    // �����敪
            //editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Width = 80;		        // ���Ӑ�
            //editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Width = 60;		        // �l����
            //editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].Width = 60;				    // ������
            //editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].Width = 150;			        // �����z
            //editBand.Columns[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Width = 90;			// ���i�J�n��
            //editBand.Columns[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Width = 90;			// ���i�I����

            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].Width = 40;		            // ��
            editBand.Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].Width = 80;		        // �폜��
            editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Width = 55;			    // ����
            editBand.Columns[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Width = 120;			// ����
            editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Width = 35;		    	// ���_
            editBand.Columns[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Width = 125;		// �ݒ���
            editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Width = 40;		    // Ұ��
            editBand.Columns[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Width = 85;			// Ұ����
            editBand.Columns[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Width = 115;	                // �i��
            editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Width = 50;		        // BL����
            editBand.Columns[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Width = 150;				// �i��
            editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Width = 50;			    // ��ٰ��
            editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Width = 60;			    // �̔��敪
            editBand.Columns[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Width = 70;		    // �����敪
            editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Width = 65;		        // ���Ӑ�
            editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Width = 50;		        // �l����
            editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].Width = 55;				    // ������
            editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].Width = 130;			        // �����z
            editBand.Columns[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Width = 75;			// ���i�J�n��
            editBand.Columns[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Width = 75;			// ���i�I����
            // ADD �� 2014/03/20 --------------------------------------------------------------->>>>>
            editBand.Columns[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Width = 75;			// �X�V��
            // ADD �� 2014/03/20 ---------------------------------------------------------------<<<<<
            // ---UPD 2011/07/12----------------<<<<<
            #endregion

            #region ���Œ��ݒ�
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].Header.Fixed = true;		            // ��
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;		            // ��
            #endregion
            
            #region ��CellAppearance�ݒ�
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;                 // ��
            editBand.Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			    // �폜��
            editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; 			// ����
            editBand.Columns[this._campaignMngDataTable.CampaignNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// ����
            editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		    // ���_
            editBand.Columns[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	// �ݒ���
            editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		    // Ұ��
            editBand.Columns[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// Ұ����
            editBand.Columns[this._campaignMngDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	            // �i��
            editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		    // BL����
            editBand.Columns[this._campaignMngDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;				// �i��
            editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;			// ��ٰ��
            editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;			    // �̔��敪
            editBand.Columns[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;		// �����敪
            editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		    // ���Ӑ�
            editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		    // �l����
            editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;				// ������
            editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;			    // �����z
            editBand.Columns[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// ���i�J�n��
            editBand.Columns[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// ���i�I����
            // ADD �� 2014/03/20 --------------------------------------------------------------->>>>>
            editBand.Columns[this._campaignMngDataTable.UpdateTime2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;             // �X�V��
            // ADD �� 2014/03/20 --------------------------------------------------------------->>>>>


            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion

            #region �����͋��ݒ�
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;		        // ��
            editBand.Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;			    // �폜��
            editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;		// ����
            editBand.Columns[this._campaignMngDataTable.CampaignNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;			// ����
            editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;		    // ���_
            editBand.Columns[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;	// �ݒ���
            editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;		// Ұ��
            editBand.Columns[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;			// Ұ����
            editBand.Columns[this._campaignMngDataTable.GoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 	        // �i��
            editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// BL����
            editBand.Columns[this._campaignMngDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; 				// �i��
            editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 	    // ��ٰ��
            editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 			// �̔��敪
            editBand.Columns[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 	// �����敪
            editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// ���Ӑ�
            editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;		// �l����
            editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 			// ������
            editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 			// �����z
            editBand.Columns[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// ���i�J�n��
            editBand.Columns[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// ���i�I����
            // ADD �� 2014/03/20 --------------------------------------------------------------->>>>>
            editBand.Columns[this._campaignMngDataTable.UpdateTime2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;         //�X�V��
            // ADD �� 2014/03/20 ---------------------------------------------------------------<<<<<
            #endregion

            #region ��Style�ݒ�
            editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			            // ����
            editBand.Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			            // �폜��
            editBand.Columns[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			            // ����
            editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		    	        // ���_
            editBand.Columns[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;	// �ݒ���
            editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		            // Ұ��
            editBand.Columns[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			        // Ұ����
            editBand.Columns[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;	                        // �i��
            editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		                // BL����
            editBand.Columns[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			         	// �i��
            editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			            // ��ٰ��
            editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			            // �̔��敪
            editBand.Columns[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;		// �����敪
            editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		                // ���Ӑ�
            editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;		                // �l����
            editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;				            // ������
            editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			                // �����z
            editBand.Columns[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			        // ���i�J�n��
            editBand.Columns[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;			            // ���i�I����
            // ADD �� 2014/03/20 --------------------------------------------------------------->>>>>
            editBand.Columns[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                       // �X�V��
            // ADD �� 2014/03/20 ---------------------------------------------------------------<<<<<          
            #endregion

            #region ���t�H�[�}�b�g�ݒ�
            string decimalFormat = "#,##0.00;-#,##0.00;''";
            string codeFormat1 = "#000000;-#0000000;''";
            string codeFormat2 = "#00;-#00;''";
            string codeFormat3 = "#0000;-#0000;''";
            string codeFormat4 = "#00000;-#00000;''";
            string codeFormat5 = "#00000000;-#00000000;''";

            editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Format = codeFormat1;			// ����
            editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Format = codeFormat2;		    // ���_
            editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Format = codeFormat3;		    // Ұ��
            editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Format = codeFormat4;		    // BL����
            editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Format = codeFormat4;			// ��ٰ��
            editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Format = codeFormat3;			    // �̔��敪
            editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Format = codeFormat5;		    // ���Ӑ�
            editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Format = decimalFormat;		    // �l����
            editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].Format = decimalFormat;				// ������
            editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].Format = decimalFormat;			    // �����z
            editBand.Columns[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Format = codeFormat5;		    // ���i�J�n��
            editBand.Columns[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Format = codeFormat5;		    // ���i�I����
            // ADD �� 2014/03/20 --------------------------------------------------------------->>>>>
            editBand.Columns[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Format = codeFormat5;             // �X�V��
            // ADD �� 2014/03/20 ---------------------------------------------------------------<<<<<
            #endregion

            #region ��MaxLength�ݒ�
            editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].MaxLength = 6;			    // ����
            editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].MaxLength = 2;		    	// ���_
            editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].MaxLength = 4;		    // Ұ��
            editBand.Columns[this._campaignMngDataTable.GoodsNoColumn.ColumnName].MaxLength = 24;	                // �i��
            editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].MaxLength = 5;		        // BL����
            editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].MaxLength = 5;			    // ��ٰ��
            editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].MaxLength = 4;			        // �̔��敪
            editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].MaxLength = 8;		        // ���Ӑ�
            editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].MaxLength = 5;		        // �l����
            editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].MaxLength = 6;				    // ������
            editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].MaxLength = 17;			        // �����z
            #endregion

            #region ��DropDownList�ݒ�
            // �ݒ��ʐݒ�
            Infragistics.Win.ValueList list = new Infragistics.Win.ValueList();
            list.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DisplayText;
            list.DropDownListMinWidth = 0;
            list.MaxDropDownItems = 10;

            Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
            listItem0.DataValue = 1;
            listItem0.DisplayText = "1�FҰ��+�i��";

            Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
            listItem1.DataValue = 2;
            listItem1.DisplayText = "2�FҰ��+BL����";

            Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
            listItem2.DataValue = 3;
            listItem2.DisplayText = "3�FҰ��+��ٰ��";

            Infragistics.Win.ValueListItem listItem3 = new Infragistics.Win.ValueListItem();
            listItem3.DataValue = 4;
            listItem3.DisplayText = "4�FҰ��";

            Infragistics.Win.ValueListItem listItem4 = new Infragistics.Win.ValueListItem();
            listItem4.DataValue = 5;
            listItem4.DisplayText = "5�FBL����";

            Infragistics.Win.ValueListItem listItem5 = new Infragistics.Win.ValueListItem();
            listItem5.DataValue = 6;
            listItem5.DisplayText = "6�F�̔��敪";

            list.ValueListItems.Add(listItem0);
            list.ValueListItems.Add(listItem1);
            list.ValueListItems.Add(listItem2);
            list.ValueListItems.Add(listItem3);
            list.ValueListItems.Add(listItem4);
            list.ValueListItems.Add(listItem5);

            this.uGrid_Details.DisplayLayout.ValueLists.Add(list);
            editBand.Columns[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].ValueList = list;

            // �����敪�ݒ�
            Infragistics.Win.ValueList list2 = new Infragistics.Win.ValueList();
            list2.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DisplayText;
            list2.DropDownListMinWidth = 0;
            list2.MaxDropDownItems = 10;

            Infragistics.Win.ValueListItem list2Item0 = new Infragistics.Win.ValueListItem();
            list2Item0.DataValue = 0;
            list2Item0.DisplayText = "0:����";

            Infragistics.Win.ValueListItem list2Item1 = new Infragistics.Win.ValueListItem();
            list2Item1.DataValue = 1;
            list2Item1.DisplayText = "1:�L��";

            list2.ValueListItems.Add(list2Item0);
            list2.ValueListItems.Add(list2Item1);

            this.uGrid_Details.DisplayLayout.ValueLists.Add(list2);
            editBand.Columns[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].ValueList = list2;
            #endregion

            #region ���O���b�h��\����\���ݒ菈��
            editBand.Columns[this._campaignMngDataTable.RowNoColumn.ColumnName].Hidden = false;		            // ��
            editBand.Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].Hidden = true;		        // �폜��
            editBand.Columns[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Hidden = false;		     	// ����
            editBand.Columns[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Hidden = false;			    // ����
            editBand.Columns[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Hidden = false;		    	// ���_
            editBand.Columns[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Hidden = false;		// �ݒ���
            editBand.Columns[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Hidden = false;		    // Ұ��
            editBand.Columns[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Hidden = false;			// Ұ����
            editBand.Columns[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Hidden = false;	                // �i��
            editBand.Columns[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Hidden = false;		        // BL����
            editBand.Columns[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Hidden = false;				// �i��
            editBand.Columns[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Hidden = false;			    // ��ٰ��
            editBand.Columns[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Hidden = false;			    // �̔��敪
            editBand.Columns[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Hidden = false;		    // �����敪
            editBand.Columns[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Hidden = false;		        // ���Ӑ�
            editBand.Columns[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Hidden = false;		        // �l����
            editBand.Columns[this._campaignMngDataTable.RateValColumn.ColumnName].Hidden = false;				    // ������
            editBand.Columns[this._campaignMngDataTable.PriceFlColumn.ColumnName].Hidden = false;			        // �����z
            editBand.Columns[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Hidden = false;			// ���i�J�n��
            editBand.Columns[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Hidden = false;			    // ���i�I����
            // ADD �� 2014/03/20 --------------------------------------------------------------->>>>>
            editBand.Columns[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Hidden = false;               // �X�V��
            // ADD �� 2014/03/20 ---------------------------------------------------------------<<<<<
            #endregion
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʏ������������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void Clear(bool settingGrid)
        {
            this._campaignObjGoodsStAcs.PrevCampaignMngDic.Clear();

            this.SetButtonEnabled(1);
            // ����DataTable�s�N���A����
            this._campaignObjGoodsStAcs.CampaignMngDataTable.Rows.Clear();

            // �\�[�g�ݒ�̉���
            this.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();

            // �O���b�h�s�����ݒ菈��
            this._campaignObjGoodsStAcs.DetailRowInitialSetting(1);
            this.DetailGridInitSetting();

            if (settingGrid)
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].Hidden = true;
            }
        }

        /// <summary>
        /// �O���b�h��s���͐F�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �O���b�h��s���͐F�ݒ肵�܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
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
                if (cell.Column.Key == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.SalesCodeColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.CustomerCodeColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.DiscountRateColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.RateValColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.PriceFlColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.PriceStartDateColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.PriceEndDateColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.CampaignNameColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName
                    // UPD �� 2014/03/20 --------------------------------------------------------------->>>>>
                    || cell.Column.Key == this._campaignMngDataTable.GoodsNameColumn.ColumnName
                    || cell.Column.Key == this._campaignMngDataTable.UpdateTime2Column.ColumnName)
                    // UPD �� 2014/03/20 ---------------------------------------------------------------<<<<<
                {
                    cell.Activation = Activation.NoEdit;
                    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                }
            }
        }

        /// <summary>
        /// �L�����y�[���R�[�h�K�C�h�N��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note	   : �L�����y�[���R�[�h�K�C�h�N���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void CampaignCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CampaignSt campaignSt;

                // �K�C�h�N��
                int status = this._campaignLinkAcs.CampaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignSt);
                if (status == 0)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = campaignSt.CampaignCode;
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = campaignSt.CampaignName;

                    CampaignSt campaignStObj;
                    int sts = this._campaignLinkAcs.CampaignStAcs.Read(out campaignStObj, this._enterpriseCode, campaignSt.CampaignCode);
                    {
                        // ���ʃZ�b�g
                        this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = campaignStObj.SectionCode.Trim().PadLeft(2, '0');
                    }

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���_�R�[�h�K�C�h�N��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note	   : ���_�R�[�h�K�C�h�N���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void SectionCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ���_�K�C�h�Ăяo��
                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out secInfoSet);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���ʃZ�b�g
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = secInfoSet.SectionCode.Trim().PadLeft(2, '0');

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���[�J�[�R�[�h�K�C�h�N��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note	   : ���[�J�[�R�[�h�K�C�h�N���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/12 ������ Redmine#22810 ���ׁh���[�J�[���́h����h�J�i���́h�ɕύX�̑Ή�</br>
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
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = makerInfo.GoodsMakerCd;
                    //this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerInfo.MakerName; // DEL 2011/07/12
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = makerInfo.MakerKanaName; // ADD 2011/07/12

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activate();
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void BLGoodsCodeGuide(int rowIndex)
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
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = blGoodsUnit.BLGoodsCode;
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = blGoodsUnit.BLGoodsHalfName;

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �a�k�O���[�v�R�[�h�K�C�h�N��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note	   : �a�k�O���[�v�R�[�h�K�C�h�N���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void BLGroupCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �K�C�h�\��
                BLGroupU blGroupUInfo;
                int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupUInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���ʃZ�b�g
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = blGroupUInfo.BLGroupCode;

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �̔��敪�K�C�h�N��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note	   : �̔��敪�K�C�h�N���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        internal void SalesCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int userGuideDivCd_SalesCode = 71;  // �̔��敪�F71

                // �R�[�h���疼�̂֕ϊ�
                UserGdHd userGuideHdInfo;
                UserGdBd userGuideBdInfo;
                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, userGuideDivCd_SalesCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���ʃZ�b�g
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = userGuideBdInfo.GuideCode.ToString().PadLeft(4, '0');

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activate();
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
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
                    // ���Ӑ�R�[�h
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Value = this._customerSearchRet.CustomerCode.ToString().PadLeft(8, '0');

                    MoveNextAllowEditCell(false);
                    this._customerSearchRet = null;
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activate();
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
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
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_GetPriceDate"].SharedProps.Enabled = true;
                        this.uButton_GetPriceDate.Enabled = true;
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
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_GetPriceDate"].SharedProps.Enabled = true;
                        this.uButton_GetPriceDate.Enabled = true;
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
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_GetPriceDate"].SharedProps.Enabled = false;
                        this.uButton_GetPriceDate.Enabled = false;
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
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2011/04/26</br>
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private int GetNextColumnIndexByTab(int mode, int rowIndex, string columnKey)
        {
            int columnIndex = -1;
            switch (mode)
            {
                case 0:
                    #region Tab
                    if (columnKey == this._campaignMngDataTable.CampaignCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.CampaignNameColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.SectionCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsNoColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsNameColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.SalesCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.CustomerCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.DiscountRateColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.RateValColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.PriceFlColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.PriceStartDateColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.PriceEndDateColumn.ColumnName)
                    {
                        // UPD �� 2014/03/20 -------------------------->>>>>
                        //columnIndex = -1;
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Column.Index;
                        // UPD �� 2014/03/20 --------------------------<<<<<
                    }
                    // ADD �� 2014/03/20 --------------------------------------------------------->>>>>
                    else if (columnKey == this._campaignMngDataTable.UpdateTime2Column.ColumnName)
                    {
                        columnIndex = -1;
                    }
                    // ADD �� 2014/03/20 ---------------------------------------------------------<<<<<
                    break;
                    #endregion Tab
                case 1:
                    #region Shift + Tab
                    if (columnKey == this._campaignMngDataTable.CampaignCodeColumn.ColumnName)
                    {
                        columnIndex = -1;
                    }
                    else if (columnKey == this._campaignMngDataTable.CampaignNameColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.SectionCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsNoColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.GoodsNameColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.BLGroupCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.SalesCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.CustomerCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.DiscountRateColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.RateValColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.PriceFlColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.PriceStartDateColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._campaignMngDataTable.PriceEndDateColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Column.Index;
                    }
                    // ADD �� 2014/03/20 --------------------------------------------------------->>>>>
                    else if (columnKey == this._campaignMngDataTable.UpdateTime2Column.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Column.Index;
                    }
                    // ADD �� 2014/03/20 ---------------------------------------------------------<<<<<
                    break;
                    #endregion Shift + Tab
            }

            return columnIndex;
        }

        /// <summary>
        /// �ݒ��ʕω����A�Z���ω�
        /// </summary>
        /// <param name="campaignSettingKind">�ݒ���</param>
        /// <param name="row">��</param>
        /// <remarks>
        /// <br>Note        : �ݒ��ʕω����A�Z���ω�</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void CampaignSettingKindChanged(string campaignSettingKind, UltraGridRow row)
        {
            switch (campaignSettingKind)
            {
                case "1�FҰ��+�i��":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        if (row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value.ToString().Trim() == string.Empty)
                        {
                            row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                        }
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = string.Empty;
                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        break;
                    }
                case "2�FҰ��+BL����":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = string.Empty;
                        if ((int)row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value == 0)
                        {
                            row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                        }
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = string.Empty;
                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        break;
                    }
                case "3�FҰ��+��ٰ��":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = string.Empty;
                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        break;
                    }
                case "4�FҰ��":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = string.Empty;
                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        break;
                    }
                case "5�FBL����":
                    {
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = string.Empty;
                        if ((int)row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value == 0)
                        {
                            row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                        }
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value = string.Empty;
                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        break;
                    }
                case "6�F�̔��敪":
                    {
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Value = 0;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Value = 0;
                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        break;
                    }
            }

            if ((int)row.Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Value == 1)
            {
                if (campaignSettingKind != "1�FҰ��+�i��")
                {
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Value = 0;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                }
                else
                {
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.AllowEdit;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = Color.Empty;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                }
            }
        }

        /// <summary>
        /// ����������A�ݒ��ʂ��A�Z���ω�
        /// </summary>
        /// <param name="campaignSettingKind">�ݒ���</param>
        /// <param name="row">��</param>
        /// <remarks>
        /// <br>Note        : ����������A�ݒ��ʂ��A�Z���ω�</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SetCampaignSettingKind(string campaignSettingKind, UltraGridRow row)
        {
            switch (campaignSettingKind)
            {
                case "1�FҰ��+�i��":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        break;
                    }
                case "2�FҰ��+BL����":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        break;
                    }
                case "3�FҰ��+��ٰ��":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        break;
                    }
                case "4�FҰ��":
                    {
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        break;
                    }
                case "5�FBL����":
                    {
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        break;
                    }
                case "6�F�̔��敪":
                    {
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                        row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                        break;
                    }
            }
        }

        /// <summary>
        /// �����敪�ω����A�Z���ω�
        /// </summary>
        /// <param name="salesPriceSetDiv">�����敪</param>
        /// <param name="row">��</param>
        /// <remarks>
        /// <br>Note        : �����敪�ω����A�Z���ω�</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SalesPriceSetDivChanged(string salesPriceSetDiv, UltraGridRow row)
        {
            int cellValue = 0;
            int.TryParse(salesPriceSetDiv, out cellValue);

            if ("1:�L��".Equals(salesPriceSetDiv) || cellValue == 1)
            {
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                // ADD �� 2014/03/20 --------------------------------------------------------------------->>>>>
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                // ADD �� 2014/03/20 ---------------------------------------------------------------------<<<<<

                if ((int)row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Value != 1)
                {
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Value = 0;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                }
            }
            else if ("0:����".Equals(salesPriceSetDiv) || cellValue == 0)
            {
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                // ADD �� 2014/03/20 --------------------------------------------------------------------->>>>>
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                // ADD �� 2014/03/20 ---------------------------------------------------------------------<<<<<

                // �u0:�����v�֕ύX���A�������ځi���Ӑ�A�l�����A�������A�����z�A���i�J�n���A���i�I�����j���󔒕\���֕ύX����
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Value = "";
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Value = 0;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Value = 0;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Value = 0;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Value = 0;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Value = 0;
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            }
            else
            {
                //�Ȃ��B
            }
        }

        /// <summary>
        /// ����������A�����敪���A�Z���ω�
        /// </summary>
        /// <param name="salesPriceSetDiv">�����敪</param>
        /// <param name="row">��</param>
        /// <remarks>
        /// <br>Note        : ����������A�����敪���A�Z���ω�</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SetSalesPriceSetDiv(string salesPriceSetDiv, UltraGridRow row)
        {
            if ("1:�L��".Equals(salesPriceSetDiv))
            {
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                // ADD �� 2014/03/20 --------------------------------------------------------------------->>>>>
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                // ADD �� 2014/03/20 ---------------------------------------------------------------------<<<<<

                if ((int)row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Value != 1)
                {
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                }
            }
            else if ("0:����".Equals(salesPriceSetDiv))
            {
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceFlColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                // ADD �� 2014/03/20 --------------------------------------------------------------------->>>>>
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Activation = Activation.NoEdit;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                // ADD �� 2014/03/20 ---------------------------------------------------------------------<<<<<
            }
            else
            {
                //�Ȃ��B
            }
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        public void GetSaveDate(out List<CampaignObjGoodsSt> delList, out List<CampaignObjGoodsSt> updList)
        {
            this._prevCampaignMngDic = this._campaignObjGoodsStAcs.PrevCampaignMngDic;
            List<CampaignObjGoodsSt> dList = new List<CampaignObjGoodsSt>();
            List<CampaignObjGoodsSt> uList = new List<CampaignObjGoodsSt>();

            CampaignObjGoodsSt campaignMng = new CampaignObjGoodsSt();
            CampaignObjGoodsSt campaignMngUPD = new CampaignObjGoodsSt();
            if (this._campaignMngDataTable.Rows.Count > 0)
            {
                foreach (CampaignMngDataSet.CampaignMngRow row in this._campaignMngDataTable.Rows)
                {
                    campaignMng = new CampaignObjGoodsSt();
                    this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow(row, ref campaignMng);
                    // ���C�s�̏ꍇ
                    if (_prevCampaignMngDic.ContainsKey(row.FilterGuid))
                    {
                        bool keyChanged = this._campaignObjGoodsStAcs.CompareKey(campaignMng, _prevCampaignMngDic[row.FilterGuid]);

                        // �s�폜�̏ꍇ
                        if (row.RowDeleteFlg == 0)
                        {
                            if (this._campaignObjGoodsStAcs.Compare(campaignMng, _prevCampaignMngDic[row.FilterGuid]))
                            {
                                dList.Add(_prevCampaignMngDic[row.FilterGuid]);
                                campaignMngUPD = campaignMng.Clone();
                                campaignMngUPD.LogicalDeleteCode = 0;
                                campaignMngUPD.GoodsMGroup = _prevCampaignMngDic[row.FilterGuid].GoodsMGroup;
                                campaignMngUPD.SalesTargetCount = _prevCampaignMngDic[row.FilterGuid].SalesTargetCount;
                                campaignMngUPD.SalesTargetMoney = _prevCampaignMngDic[row.FilterGuid].SalesTargetMoney;
                                campaignMngUPD.SalesTargetProfit = _prevCampaignMngDic[row.FilterGuid].SalesTargetProfit;
                                if (!keyChanged)
                                {
                                    campaignMngUPD.IsUpdRow = true;
                                }
                                uList.Add(campaignMngUPD);
                            }
                        }
                        else
                        {
                            campaignMng = _prevCampaignMngDic[row.FilterGuid];
                            campaignMngUPD = campaignMng.Clone();
                            campaignMngUPD.LogicalDeleteCode = 1;
                            if (!keyChanged)
                            {
                                campaignMngUPD.IsUpdRow = true;
                            }
                            uList.Add(campaignMngUPD);
                        }
                    }
                    // �V�K�s�̏ꍇ
                    else
                    {
                        if (this._campaignObjGoodsStAcs.IsRowUpdate(row) && row.RowDeleteFlg == 0)
                        {
                            campaignMngUPD = campaignMng.Clone();
                            campaignMngUPD.EnterpriseCode = this._enterpriseCode;
                            campaignMngUPD.LogicalDeleteCode = 0;
                            campaignMngUPD.IsUpdRow = false;
                            uList.Add(campaignMngUPD);
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/14 ������ Redmine#22962 ���_�Ⴂ�œo�^�\�ɂ���悤�ɕύX�Ή�</br>
        /// <br>                               Redmine#22957 �Ώۓ��Ӑ�ɐݒ肵�Ă���ꍇ�A�S���Ӑ悪���͂ł���</br>
        /// <br>UpdateNote : 2011/07/15 ������ Redmine#22984 �����敪���قȂ�ݒ�ɂ���ƁA���ꏤ�i�ݒ���d���`�F�b�N</br>
        /// <br>UpdateNote : 2011/09/05 ���N�n�� Redmine#23965 �L�����y�[���Ǘ��@����`�[���́iDelphi�j�̕ύX���̒����̑Ή�</br>
        /// </remarks>
        public bool CheckSaveDate(out List<CampaignObjGoodsSt> deleteList, out List<CampaignObjGoodsSt> updateList)
        {
            List<CampaignObjGoodsSt> delList = new List<CampaignObjGoodsSt>();
            List<CampaignObjGoodsSt> updList = new List<CampaignObjGoodsSt>();

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
                CampaignSt campaignSt = null;
                CampaignLink campaignLink = null;
                int rowIndex = -1;
                foreach (CampaignObjGoodsSt campaign in updateList)
                {
                    campaignSt = null;
                    campaignLink = null;
                    // �s�폜�̃f�[�^���`�F�b�N�Ȃ�
                    if (campaign.LogicalDeleteCode == 1)
                    {
                        continue;
                    }

                    // �L�����y�[���ݒ�}�X�^�擾
                    if (this._campaignObjGoodsStAcs.CampaignStDic.ContainsKey(campaign.CampaignCode))
                    {
                        campaignSt = this._campaignObjGoodsStAcs.CampaignStDic[campaign.CampaignCode];
                    }

                    //�s�ԍ����擾
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        if (campaign.RowIndex == (int)row.Cells[this._campaignMngDataTable.RowNoColumn.ColumnName].Value)
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }

                    // �L�����y�[���֘A�}�X�^�擾
                    foreach (CampaignLink work in this._campaignObjGoodsStAcs.CampaignLinkList)
                    {
                        if (work.CampaignCode == campaign.CampaignCode && work.CustomerCode == campaign.CustomerCode)
                        {
                            campaignLink = work;
                            break;
                        }
                    }

                    // �L�����y�[���R�[�h����̓`�F�b�N
                    if (campaign.CampaignCode == 0)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "�L�����y�[���R�[�h����͂��ĉ������B",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;

                    }
                    // ���[�J�[�R�[�h����̓`�F�b�N
                    if (campaign.GoodsMakerCd == 0
                        && (campaign.CampaignSettingKind == 1
                            || campaign.CampaignSettingKind == 2
                            || campaign.CampaignSettingKind == 3
                            || campaign.CampaignSettingKind == 4))
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
                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                    // �i�Ԃ���̓`�F�b�N
                    if (string.IsNullOrEmpty(campaign.GoodsNo.Trim()) && campaign.CampaignSettingKind == 1)
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
                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                    // �a�k�R�[�h����̓`�F�b�N
                    if (campaign.BLGoodsCode == 0
                        && (campaign.CampaignSettingKind == 2
                            || campaign.CampaignSettingKind == 5))
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "�a�k�R�[�h����͂��ĉ������B",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                    // �O���[�v�R�[�h����̓`�F�b�N
                    if (campaign.BLGroupCode == 0
                        && campaign.CampaignSettingKind == 3)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "�O���[�v�R�[�h����͂��ĉ������B",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                    // �̔��敪����̓`�F�b�N
                    if (this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Value.ToString().Trim() == string.Empty
                        && campaign.CampaignSettingKind == 6)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "�̔��敪����͂��ĉ������B",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }

                    // �����敪���P�̏ꍇ
                    // ---UPD 2011/07/14---------------->>>>>
                    // ---UPD 2011/09/05---------------->>>>>
                    if (campaign.SalesPriceSetDiv == 1)
                    //if (campaign.SalesPriceSetDiv == 1 && campaign.CustomerCode != 0)
                    // ---UPD 2011/09/05----------------<<<<<
                    // ---UPD 2011/07/14----------------<<<<<
                    {
                        if (campaignSt != null)
                        {
                            // ����߰ݐݒ�Ͻ�.����߰ݑΏۋ敪=1:�Ώۓ��Ӑ�
                            if (campaignSt.CampaignObjDiv == 1)
                            {
                                // ����߰݊֘AϽ�.���Ӑ恂���Ӑ�̏ꍇ�A�G���[
                                // ---UPD 2011/09/05---------------->>>>>
                                if (campaignLink == null && campaign.CustomerCode != 0)
                                //if (campaignLink == null)
                                // ---UPD 2011/09/05----------------<<<<<
                                {
                                    TMsgDisp.Show(
                                         this,
                                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                         this.Name,
                                         "�ΏۊO�̓��Ӑ�ł��B",
                                         0,
                                         MessageBoxButtons.OK);
                                    if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                    {
                                        this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CustomerCodeColumn.ColumnName].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    return false;
                                }
                            }
                        }

                        // �l�����A����������̓`�F�b�N
                        // ---UPD 2011/07/15------------->>>>>
                        //if (campaign.CampaignSettingKind == 3
                        //    || campaign.CampaignSettingKind == 4
                        //    || campaign.CampaignSettingKind == 5
                        //    || campaign.CampaignSettingKind == 6)
                        if (campaign.CampaignSettingKind == 2
                            || campaign.CampaignSettingKind == 3
                            || campaign.CampaignSettingKind == 4
                            || campaign.CampaignSettingKind == 5
                            || campaign.CampaignSettingKind == 6)
                        // ---UPD 2011/07/15-------------<<<<<
                        {
                            if (campaign.RateVal == 0 && campaign.DiscountRate == 0)
                            {
                                TMsgDisp.Show(
                                     this,
                                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                     this.Name,
                                     "�l�����܂��͔���������͂��ĉ������B",
                                     0,
                                     MessageBoxButtons.OK);
                                if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                return false;
                            }
                        }

                        // �ݒ��ʁ�1�FҰ��+�i�Ԃ̏ꍇ�̂݃`�F�b�N
                        if (campaign.CampaignSettingKind == 1)
                        {
                            if (campaign.RateVal == 0 && campaign.PriceFl == 0 && campaign.DiscountRate == 0)
                            {
                                TMsgDisp.Show(
                                     this,
                                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                     this.Name,
                                     "�l�����A�������A�����z�̂����ꂩ����͂��ĉ������B",
                                     0,
                                     MessageBoxButtons.OK);
                                if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                return false;
                            }
                            if (campaign.DiscountRate != 0 && campaign.PriceFl != 0)
                            {
                                TMsgDisp.Show(
                                     this,
                                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                     this.Name,
                                     "�l�����Ɣ����z�͗����ݒ�ł��܂���B",
                                     0,
                                     MessageBoxButtons.OK);
                                if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                return false;
                            }
                            if (campaign.RateVal != 0 && campaign.PriceFl != 0)
                            {
                                TMsgDisp.Show(
                                     this,
                                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                     this.Name,
                                     "�������Ɣ����z�͗����ݒ�ł��܂���B",
                                     0,
                                     MessageBoxButtons.OK);
                                if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.RateValColumn.ColumnName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                return false;
                            }
                        }

                        if (campaign.DiscountRate != 0 && campaign.RateVal != 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "�l�����Ɣ������͗����ݒ�ł��܂���B",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.DiscountRateColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // ���i�J�n������̓`�F�b�N
                        if (campaign.PriceStartDate == 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "���i�J�n������͂��ĉ������B",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // ���i���͈̔̓`�F�b�N
                        if (campaign.PriceStartDate > campaign.PriceEndDate && campaign.PriceEndDate != 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "���i���͈͎̔w��Ɍ�肪����܂��B",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // �L�����y�[���̓K�p���͈͊O�`�F�b�N
                        if (campaignSt != null)
                        {
                            if (Convert.ToInt32(campaignSt.ApplyStaDate.Date.ToString("yyyyMMdd")) > campaign.PriceStartDate)
                            {
                                TMsgDisp.Show(
                                     this,
                                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                     this.Name,
                                     "�L�����y�[���̓K�p���͈͊O�ł��B",
                                     0,
                                     MessageBoxButtons.OK);
                                if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceStartDateColumn.ColumnName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                return false;
                            }
                        }

                        // ���i�I��������̓`�F�b�N
                        if (campaign.PriceEndDate == 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "���i�I��������͂��ĉ������B",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // �L�����y�[���̓K�p���͈͊O�`�F�b�N
                        if (campaignSt != null)
                        {
                            if (Convert.ToInt32(campaignSt.ApplyEndDate.Date.ToString("yyyyMMdd")) < campaign.PriceEndDate)
                            {
                                TMsgDisp.Show(
                                     this,
                                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                     this.Name,
                                     "�L�����y�[���̓K�p���͈͊O�ł��B",
                                     0,
                                     MessageBoxButtons.OK);
                                if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                return false;
                            }
                        }
                    }
                }
            }

            if (updateList.Count != 0)
            {
                CampaignSt campaignSt = null;
                CampaignLink campaignLink = null;
                int rowIndex = -1;
                foreach (CampaignObjGoodsSt campaign in updateList)
                {
                    // �s�폜�̃f�[�^���`�F�b�N�Ȃ�
                    if (campaign.LogicalDeleteCode == 1)
                    {
                        continue;
                    }

                    // �L�����y�[���ݒ�}�X�^�擾
                    if (this._campaignObjGoodsStAcs.CampaignStDic.ContainsKey(campaign.CampaignCode))
                    {
                        campaignSt = this._campaignObjGoodsStAcs.CampaignStDic[campaign.CampaignCode];
                    }

                    //�s�ԍ����擾
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        if (campaign.RowIndex == (int)row.Cells[this._campaignMngDataTable.RowNoColumn.ColumnName].Value)
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }

                    // �L�����y�[���֘A�}�X�^�擾
                    foreach (CampaignLink work in this._campaignObjGoodsStAcs.CampaignLinkList)
                    {
                        if (work.CampaignCode == campaign.CampaignCode && work.CustomerCode == campaign.CustomerCode)
                        {
                            campaignLink = work;
                            break;
                        }
                    }

                    int flag = 0;
                    string errorMsg = string.Empty;

                    #region �����敪�u0:�����v�̏ꍇ�A�d�����R�[�h�̑��݃`�F�b�N
                    if (campaign.SalesPriceSetDiv == 0)
                    {
                        foreach (CampaignMngDataSet.CampaignMngRow row in this._campaignMngDataTable.Rows)
                        {
                            if (row.FilterGuid == Guid.Empty && row.RowDeleteFlg == 1)
                            {
                                continue;
                            }
                            // ---UPD 2011/07/15---------------->>>>>
                            //if (row.SalesPriceSetDiv == 0)
                            //{
                                // ---UPD 2011/07/14------------------>>>>>
                                //if (row.CampaignCode == campaign.CampaignCode && row.CampaignSettingKind == campaign.CampaignSettingKind)
                                if (row.CampaignCode == campaign.CampaignCode
                                    && row.CampaignSettingKind == campaign.CampaignSettingKind
                                    && row.SectionCode == campaign.SectionCode)
                                // ---UPD 2011/07/14------------------<<<<<
                                {
                                    switch (campaign.CampaignSettingKind)
                                    {
                                        case 1:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.GoodsNo.Trim() == row.GoodsNo.Trim()))
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 1�FҰ��+�i�ԁAҰ���F" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "�A�i�ԁF" + campaign.GoodsNo.Trim();
                                                    flag++;
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.BLGoodsCode == row.BLGoodsCode))
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 2�FҰ��+BL���ށAҰ���F" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "�ABL���ށF" + campaign.BLGoodsCode.ToString().PadLeft(5, '0');
                                                    flag++;
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.BLGroupCode == row.BLGroupCode))
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 3�FҰ��+��ٰ�߁AҰ���F" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "�A��ٰ�߁F" + campaign.BLGroupCode.ToString().PadLeft(5, '0');
                                                    flag++;
                                                }
                                                break;
                                            }
                                        case 4:
                                            {
                                                if (campaign.GoodsMakerCd == row.GoodsMakerCode)
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 4�FҰ���AҰ���F" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0');
                                                    flag++;
                                                }
                                                break;
                                            }
                                        case 5:
                                            {
                                                if (campaign.BLGoodsCode == row.BLGoodsCode)
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 5�FBL���ށABL���ށF" + campaign.BLGoodsCode.ToString().PadLeft(5, '0');
                                                    flag++;
                                                }
                                                break;
                                            }
                                        case 6:
                                            {
                                                int inputValue = 0;
                                                int.TryParse(row.SalesCode, out inputValue);
                                                if (campaign.SalesCode == inputValue)
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 6�F�̔��敪�A�̔��敪�F" + campaign.SalesCode.ToString().PadLeft(4, '0');
                                                    flag++;
                                                }
                                                break;
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
                                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                        return false;
                                    }
                                }
                            //}
                            // ---UPD 2011/07/15----------------<<<<<
                        }
                    }
                    #endregion �����敪�u0:�����v�̏ꍇ�A�d�����R�[�h�̑��݃`�F�b�N

                    #region �����敪�u1:�L��v�̏ꍇ�A�d�����R�[�h�̑��݃`�F�b�N
                    if (campaign.SalesPriceSetDiv == 1)
                    {
                        flag = 0;
                        int flag2 = 0;
                        foreach (CampaignMngDataSet.CampaignMngRow row in this._campaignMngDataTable.Rows)
                        {
                            if (row.FilterGuid == Guid.Empty && row.RowDeleteFlg == 1)
                            {
                                continue;
                            }

                            if (row.SalesPriceSetDiv == 1)
                            {
                                if (row.SectionCode.Trim().PadLeft(2, '0') == campaign.SectionCode.Trim().PadLeft(2, '0')
                                    && row.CampaignSettingKind == campaign.CampaignSettingKind
                                    && row.CustomerCode.Trim().PadLeft(8, '0') == campaign.CustomerCode.ToString().PadLeft(8, '0'))
                                {
                                    switch (campaign.CampaignSettingKind)
                                    {
                                        case 1:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.GoodsNo.Trim() == row.GoodsNo.Trim()))
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 1�FҰ��+�i�ԁAҰ���F" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "�A�i�ԁF" + campaign.GoodsNo.Trim() + "�A���Ӑ�F" + campaign.CustomerCode.ToString().PadLeft(8, '0') + "�A���i���F" + campaign.PriceStartDate.ToString().PadLeft(6, '0') + "�`" + campaign.PriceEndDate.ToString().PadLeft(6, '0');
                                                    if ((row.PriceStartDate <= campaign.PriceStartDate
                                                        && campaign.PriceStartDate <= row.PriceEndDate)
                                                        || (row.PriceStartDate <= campaign.PriceEndDate
                                                        && campaign.PriceEndDate <= row.PriceEndDate))
                                                    {
                                                        flag++;
                                                    }
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.BLGoodsCode == row.BLGoodsCode))
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 2�FҰ��+BL���ށAҰ���F" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "�ABL���ށF" + campaign.BLGoodsCode.ToString().PadLeft(5, '0') + "�A���Ӑ�F" + campaign.CustomerCode.ToString().PadLeft(8, '0') + "�A���i���F" + campaign.PriceStartDate.ToString().PadLeft(6, '0') + "�`" + campaign.PriceEndDate.ToString().PadLeft(6, '0');
                                                    if ((row.PriceStartDate <= campaign.PriceStartDate
                                                        && campaign.PriceStartDate <= row.PriceEndDate)
                                                        || (row.PriceStartDate <= campaign.PriceEndDate
                                                        && campaign.PriceEndDate <= row.PriceEndDate))
                                                    {
                                                        flag++;
                                                    }
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.BLGroupCode == row.BLGroupCode))
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 3�FҰ��+��ٰ�߁AҰ���F" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "�A��ٰ�߁F" + campaign.BLGroupCode.ToString().PadLeft(5, '0') + "�A���Ӑ�F" + campaign.CustomerCode.ToString().PadLeft(8, '0') + "�A���i���F" + campaign.PriceStartDate.ToString().PadLeft(6, '0') + "�`" + campaign.PriceEndDate.ToString().PadLeft(6, '0');
                                                    if ((row.PriceStartDate <= campaign.PriceStartDate
                                                        && campaign.PriceStartDate <= row.PriceEndDate)
                                                        || (row.PriceStartDate <= campaign.PriceEndDate
                                                        && campaign.PriceEndDate <= row.PriceEndDate))
                                                    {
                                                        flag++;
                                                    }
                                                }
                                                break;
                                            }
                                        case 4:
                                            {
                                                if (campaign.GoodsMakerCd == row.GoodsMakerCode)
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 4�FҰ���AҰ���F" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "�A���Ӑ�F" + campaign.CustomerCode.ToString().PadLeft(8, '0') + "�A���i���F" + campaign.PriceStartDate.ToString().PadLeft(6, '0') + "�`" + campaign.PriceEndDate.ToString().PadLeft(6, '0');
                                                    if ((row.PriceStartDate <= campaign.PriceStartDate
                                                        && campaign.PriceStartDate <= row.PriceEndDate)
                                                        || (row.PriceStartDate <= campaign.PriceEndDate
                                                        && campaign.PriceEndDate <= row.PriceEndDate))
                                                    {
                                                        flag++;
                                                    }
                                                }
                                                break;
                                            }
                                        case 5:
                                            {
                                                if (campaign.BLGoodsCode == row.BLGoodsCode)
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 5�FBL���ށABL���ށF" + campaign.BLGoodsCode.ToString().PadLeft(5, '0') + "�A���Ӑ�F" + campaign.CustomerCode.ToString().PadLeft(8, '0') + "�A���i���F" + campaign.PriceStartDate.ToString().PadLeft(6, '0') + "�`" + campaign.PriceEndDate.ToString().PadLeft(6, '0');
                                                    if ((row.PriceStartDate <= campaign.PriceStartDate
                                                        && campaign.PriceStartDate <= row.PriceEndDate)
                                                        || (row.PriceStartDate <= campaign.PriceEndDate
                                                        && campaign.PriceEndDate <= row.PriceEndDate))
                                                    {
                                                        flag++;
                                                    }
                                                }
                                                break;
                                            }
                                        case 6:
                                            {
                                                if (campaign.SalesCode == Convert.ToInt32(row.SalesCode))
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 6�F�̔��敪�A�̔��敪�F" + campaign.SalesCode.ToString().PadLeft(4, '0') + "�A���Ӑ�F" + campaign.CustomerCode.ToString().PadLeft(8, '0') + "�A���i���F" + campaign.PriceStartDate.ToString().PadLeft(6, '0') + "�`" + campaign.PriceEndDate.ToString().PadLeft(6, '0');
                                                    if ((row.PriceStartDate <= campaign.PriceStartDate
                                                        && campaign.PriceStartDate <= row.PriceEndDate)
                                                        || (row.PriceStartDate <= campaign.PriceEndDate
                                                        && campaign.PriceEndDate <= row.PriceEndDate))
                                                    {
                                                        flag++;
                                                    }
                                                }
                                                break;
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
                                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                if (row.CampaignCode == campaign.CampaignCode
                                       && row.CampaignSettingKind == campaign.CampaignSettingKind
                                       && row.SectionCode == campaign.SectionCode)
                                {
                                    switch (campaign.CampaignSettingKind)
                                    {
                                        case 1:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.GoodsNo.Trim() == row.GoodsNo.Trim()))
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 1�FҰ��+�i�ԁAҰ���F" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "�A�i�ԁF" + campaign.GoodsNo.Trim();
                                                    flag2++;
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.BLGoodsCode == row.BLGoodsCode))
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 2�FҰ��+BL���ށAҰ���F" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "�ABL���ށF" + campaign.BLGoodsCode.ToString().PadLeft(5, '0');
                                                    flag2++;
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                if ((campaign.GoodsMakerCd == row.GoodsMakerCode) && (campaign.BLGroupCode == row.BLGroupCode))
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 3�FҰ��+��ٰ�߁AҰ���F" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0') + "�A��ٰ�߁F" + campaign.BLGroupCode.ToString().PadLeft(5, '0');
                                                    flag2++;
                                                }
                                                break;
                                            }
                                        case 4:
                                            {
                                                if (campaign.GoodsMakerCd == row.GoodsMakerCode)
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 4�FҰ���AҰ���F" + campaign.GoodsMakerCd.ToString().PadLeft(4, '0');
                                                    flag2++;
                                                }
                                                break;
                                            }
                                        case 5:
                                            {
                                                if (campaign.BLGoodsCode == row.BLGoodsCode)
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 5�FBL���ށABL���ށF" + campaign.BLGoodsCode.ToString().PadLeft(5, '0');
                                                    flag2++;
                                                }
                                                break;
                                            }
                                        case 6:
                                            {
                                                int inputValue = 0;
                                                int.TryParse(row.SalesCode, out inputValue);
                                                if (campaign.SalesCode == inputValue)
                                                {
                                                    errorMsg = "����߰ݺ��ށF" + campaign.CampaignCode.ToString().PadLeft(6, '0') + "�A�ݒ��� 6�F�̔��敪�A�̔��敪�F" + campaign.SalesCode.ToString().PadLeft(4, '0');
                                                    flag2++;
                                                }
                                                break;
                                            }
                                    }
                                    if (flag2 > 0)
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
                                            this.uGrid_Details.Rows[rowIndex].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                        return false;
                                    }
                                } 
                            }
                        }
                    }
                    #endregion �����敪�u1:�L��v�̏ꍇ�A�d�����R�[�h�̑��݃`�F�b�N
                }
            }
            #endregion

            return true;
        }


        // ----- ADD 2011/07/06 ------- >>>>>>>>>
        /// <summary>
        /// DOWN�O�`�F�b�N����
        /// </summary>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��O�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2011/07/06</br>
        /// <br>UpdateNote : 2011/07/11 杍^ Redmine#22776 �s�ǉ��̓��Ӑ�̃`�F�b�N�Ɋւ��Ă̏C��</br>
        /// <br>UpdateNote : 2011/07/14 ������ Redmine#22957 �Ώۓ��Ӑ�ɐݒ肵�Ă���ꍇ�A�S���Ӑ悪���͂ł���</br>
        /// </remarks>
        public bool CheckDateForDown()
        {
            CampaignMngDataSet.CampaignMngRow row = (CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1];
            // �s�폜�̃f�[�^���`�F�b�N�Ȃ�
            if (row.RowDeleteFlg == 1)
            {
                return true;
            }

            CampaignObjGoodsSt campaign = new CampaignObjGoodsSt();
            this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref campaign);

            // �s�폜�̃f�[�^���`�F�b�N�Ȃ�
            if (campaign.LogicalDeleteCode == 1)
            {
                return true;
            }

            CampaignSt campaignSt = null;
            //CampaignLink campaignLink = null;  // DEL 2011/07/11

            // �L�����y�[���ݒ�}�X�^�擾
            if (this._campaignObjGoodsStAcs.CampaignStDic.ContainsKey(campaign.CampaignCode))
            {
                campaignSt = this._campaignObjGoodsStAcs.CampaignStDic[campaign.CampaignCode];
            }

            // ----- DEL 2011/07/11 ------- >>>>>>>>>
            // �L�����y�[���֘A�}�X�^�擾
            //foreach (CampaignLink work in this._campaignObjGoodsStAcs.CampaignLinkList)
            //{
            //    if (work.CampaignCode == campaign.CampaignCode && work.CustomerCode == campaign.CustomerCode)
            //    {
            //        campaignLink = work;
            //        break;
            //    }
            //}
            // ----- DEL 2011/07/11 ------- <<<<<<<<<

            // �L�����y�[���R�[�h����̓`�F�b�N
            if (campaign.CampaignCode == 0)
            {
                return false;
            }

            // ���[�J�[�R�[�h����̓`�F�b�N
            if (campaign.GoodsMakerCd == 0
                && (campaign.CampaignSettingKind == 1
                    || campaign.CampaignSettingKind == 2
                    || campaign.CampaignSettingKind == 3
                    || campaign.CampaignSettingKind == 4))
            {
                return false;
            }

            // �i�Ԃ���̓`�F�b�N
            if (string.IsNullOrEmpty(campaign.GoodsNo.Trim()) && campaign.CampaignSettingKind == 1)
            {
                return false;
            }

            // �a�k�R�[�h����̓`�F�b�N
            if (campaign.BLGoodsCode == 0
                && (campaign.CampaignSettingKind == 2
                    || campaign.CampaignSettingKind == 5))
            {
                return false;
            }

            // �O���[�v�R�[�h����̓`�F�b�N
            if (campaign.BLGroupCode == 0
                && campaign.CampaignSettingKind == 3)
            {
                return false;
            }

            // �̔��敪����̓`�F�b�N
            if (campaign.SalesCode == 0
                && campaign.CampaignSettingKind == 6)
            {
                return false;
            }

            // �����敪���P�̏ꍇ
            if (campaign.SalesPriceSetDiv == 1)
            {
                if (campaignSt != null)
                {
                    // ����߰ݐݒ�Ͻ�.����߰ݑΏۋ敪=1:�Ώۓ��Ӑ�
                    if (campaignSt.CampaignObjDiv == 1)
                    {
                        // ----- UPD 2011/07/11 ------- >>>>>>>>>
                        // ����߰݊֘AϽ�.���Ӑ恂���Ӑ�̏ꍇ�A�G���[
                        //if (campaignLink == null)
                        //{
                        //    return false;
                        //}
                        // ---UPD 2011/07/14------------->>>>>
                        //if (campaign.CustomerCode == 0)
                        //{
                        //    return false;
                        //}

                        if (string.IsNullOrEmpty(this._campaignMngDataTable[this._campaignMngDataTable.Count - 1].CustomerCode.Trim()))
                        {
                            return false;
                        }
                        // ---UPD 2011/07/14-------------<<<<<
                        // ----- UPD 2011/07/11 ------- <<<<<<<<<
                    }
                }

                // �l�����A����������̓`�F�b�N
                if (campaign.CampaignSettingKind == 3
                    || campaign.CampaignSettingKind == 4
                    || campaign.CampaignSettingKind == 5
                    || campaign.CampaignSettingKind == 6)
                {
                    if (campaign.RateVal == 0 && campaign.DiscountRate == 0)
                    {
                        return false;
                    }
                }

                // �ݒ��ʁ�1�FҰ��+�i�Ԃ̏ꍇ�̂݃`�F�b�N
                if (campaign.CampaignSettingKind == 1)
                {
                    if (campaign.RateVal == 0 && campaign.PriceFl == 0 && campaign.DiscountRate == 0)
                    {
                        return false;
                    }

                    if (campaign.DiscountRate != 0 && campaign.PriceFl != 0)
                    {
                        return false;
                    }

                    if (campaign.RateVal != 0 && campaign.PriceFl != 0)
                    {
                        return false;
                    }
                }

                if (campaign.DiscountRate != 0 && campaign.RateVal != 0)
                {
                    return false;
                }

                // ���i�J�n������̓`�F�b�N
                if (campaign.PriceStartDate == 0)
                {
                    return false;
                }

                // ���i���͈̔̓`�F�b�N
                if (campaign.PriceStartDate > campaign.PriceEndDate && campaign.PriceEndDate != 0)
                {
                    return false;
                }

                // �L�����y�[���̓K�p���͈͊O�`�F�b�N
                if (campaignSt != null)
                {
                    if (Convert.ToInt32(campaignSt.ApplyStaDate.Date.ToString("yyyyMMdd")) > campaign.PriceStartDate)
                    {
                        return false;
                    }
                }

                // ���i�I��������̓`�F�b�N
                if (campaign.PriceEndDate == 0)
                {
                    return false;
                }

                // �L�����y�[���̓K�p���͈͊O�`�F�b�N
                if (campaignSt != null)
                {
                    if (Convert.ToInt32(campaignSt.ApplyEndDate.Date.ToString("yyyyMMdd")) < campaign.PriceEndDate)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        // ----- ADD 2011/07/06 ------- <<<<<<<<<

        /// <summary>
        /// �ۑ��O�`�F�b�N�����i�폜�w��敪���P�j
        /// </summary>
        /// <param name="deleteList">�폜���X�g</param>
        /// <param name="updateList">�X�V���X�g</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��O�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void ReturnSaveDate(out List<CampaignObjGoodsSt> deleteList, out List<CampaignObjGoodsSt> updateList)
        {
            this._prevCampaignMngDic = this._campaignObjGoodsStAcs.PrevCampaignMngDic;
            List<CampaignObjGoodsSt> delList = new List<CampaignObjGoodsSt>();
            List<CampaignObjGoodsSt> updList = new List<CampaignObjGoodsSt>();

            CampaignObjGoodsSt campaignMng = new CampaignObjGoodsSt();
            CampaignObjGoodsSt campaignMngUPD = new CampaignObjGoodsSt();
            if (this._campaignMngDataTable.Rows.Count > 0)
            {
                foreach (CampaignMngDataSet.CampaignMngRow row in this._campaignMngDataTable.Rows)
                {
                    this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow(row, ref campaignMng);
                    if (row.RowDeleteFlg == 1)
                    {
                        delList.Add(this._prevCampaignMngDic[row.FilterGuid]);
                    }
                    else if (row.RowDeleteFlg == 2)
                    {
                        campaignMng = this._prevCampaignMngDic[row.FilterGuid];
                        campaignMngUPD = campaignMng.Clone();
                        campaignMngUPD.LogicalDeleteCode = 0;
                        updList.Add(campaignMngUPD);
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/12 ������ Redmine#22919 �@����N�����̕����T�C�Y�ƍ��ڕ��̕ύX</br>
        /// <br>�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ �A���ׂ̃L�����y�[���R�[�h�ɏ����\������悤�ɕύX</br>
        /// </remarks>
        public void GridSettingAfterSearch(bool deleteFlg)
        {
            //�폜�w��敪:0
            if (deleteFlg == false)
            {
                this.SetButtonEnabled(1);
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].Hidden = true;
                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    row.Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                    if (!Guid.Empty.Equals((Guid)row.Cells[this._campaignMngDataTable.FilterGuidColumn.ColumnName].Value))
                    {
                        row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    }
                    else
                    {
                        row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activation = Activation.AllowEdit;
                    }
                    // ADD �� 214/03/20---------------------------------------------------------------------------------->>>>>
                    row.Cells[this._campaignMngDataTable.UpdateTime2Column.ColumnName].Activation = Activation.NoEdit;
                    // ADD �� 214/03/20----------------------------------------------------------------------------------<<<<<
                    row.Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.GoodsMakerNameColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._campaignMngDataTable.GoodsNameColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    this.SetCampaignSettingKind(this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Text, row);
                    row.Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Activation = Activation.AllowEdit;
                    this.SetSalesPriceSetDiv(this.uGrid_Details.Rows[row.Index].Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Text, row);
                }
            }
            //�폜�w��敪:1
            else
            {
                this.SetButtonEnabled(2);
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].Hidden = false;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._campaignMngDataTable.UpdateTimeColumn.ColumnName].CellAppearance.ForeColor = Color.Red;
                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    foreach (UltraGridCell cell in row.Cells)
                    {
                        if (cell.Column.Key != this._campaignMngDataTable.RowNoColumn.ColumnName)
                        {
                            cell.Appearance.BackColor = ct_DISABLE_COLOR;
                            cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                            cell.Activation = Activation.NoEdit;
                        }
                    }
                }
            }

            //this.SetFocusAfterSearch();  // DEL 2011/07/12
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �����͉\�Z���ړ��������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/06 杍^ Redmine#22776 �L�����y�[���Ώۏ��i�ݒ�}�X�^�^�ǉ��s�̑Ή�</br>
        /// <br>UpdateNote : 2011/07/12 ������ Redmine#22919 �@����N�����̕����T�C�Y�ƍ��ڕ��̕ύX</br>
        /// <br>UpdateNote : 2011/07/14 ������ Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�</br>
        /// <br>UpdateNote : 2011/07/21 杍^ Redmine#23119 �ŏI���׍s�ł̃t�H�[�J�X�J�ڕs���̏C��</br>
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
                    if (this.uGrid_Details.ActiveRow.Index == this._campaignMngDataTable.Count - 1)
                    {
                        if ((Int32)this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Value == 0)
                        {
                            if (this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key)
                                || this._campaignMngDataTable.PriceEndDateColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            {
                                if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                                {
                                    // ----- UPD 2011/07/06 ------- >>>>>>>>>
                                    if (CheckDateForDown())
                                    {
                                        #region �ŏI�s�̏ꍇ�A�V�K�s��ǉ�����
                                        CampaignMngDataSet.CampaignMngRow newRow = this._campaignMngDataTable.NewCampaignMngRow();
                                        newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                                        newRow.FilterGuid = Guid.Empty;
                                        newRow.SectionCode = "00";
                                        newRow.GoodsName = "";
                                        newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");

                                        this._campaignMngDataTable.AddCampaignMngRow(newRow);

                                        this.DetailGridInitSetting();
                                        // ---ADD 2011/07/12------------------>>>>>
                                        string campaignCode = string.Empty;
                                        string campaignName = string.Empty;
                                        string sectionCode = string.Empty;
                                        this.GetCampaignInfo(out campaignCode, out campaignName, out sectionCode);
                                        if (campaignCode == string.Empty &&
                                            campaignName == string.Empty &&
                                            sectionCode == string.Empty)
                                        {
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---ADD 2011/07/14------------->>>>>
                                            CampaignObjGoodsSt campaignObjGoodsSt = null;
                                            this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                                            this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                                            // ---ADD 2011/07/14-------------<<<<<
                                            return true;
                                        }
                                        else
                                        {
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = campaignCode;
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = campaignName;
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = sectionCode;

                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---ADD 2011/07/14------------->>>>>
                                            CampaignObjGoodsSt campaignObjGoodsSt = null;
                                            this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                                            this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                                            // ---ADD 2011/07/14-------------<<<<<
                                            return true;
                                        }
                                        // ---ADD 2011/07/12------------------<<<<<
                                        #endregion
                                    }
                                    // ----- UPD 2011/07/06 ------- <<<<<<<<<
                                    // ----- ADD 2011/07/21 ------- >>>>>>>>>
                                    else
                                    {
                                        moved = false;
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        break;
                                    }
                                    // ----- ADD 2011/07/21 ------- <<<<<<<<<
                                }
                            }
                        }
                        else
                        {
                            if (this._campaignMngDataTable.PriceEndDateColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            {
                                if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                                {
                                    // ----- UPD 2011/07/06 ------- >>>>>>>>>
                                    if (CheckDateForDown())
                                    {
                                        #region �ŏI�s�̏ꍇ�A�V�K�s��ǉ�����
                                        CampaignMngDataSet.CampaignMngRow newRow = this._campaignMngDataTable.NewCampaignMngRow();
                                        newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                                        newRow.FilterGuid = Guid.Empty;
                                        newRow.SectionCode = "00";
                                        newRow.GoodsName = "";
                                        newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");

                                        this._campaignMngDataTable.AddCampaignMngRow(newRow);

                                        this.DetailGridInitSetting();
                                        // ---ADD 2011/07/12------------------>>>>>
                                        string campaignCode = string.Empty;
                                        string campaignName = string.Empty;
                                        string sectionCode = string.Empty;
                                        this.GetCampaignInfo(out campaignCode, out campaignName, out sectionCode);
                                        if (campaignCode == string.Empty &&
                                            campaignName == string.Empty &&
                                            sectionCode == string.Empty)
                                        {
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---ADD 2011/07/14------------->>>>>
                                            CampaignObjGoodsSt campaignObjGoodsSt = null;
                                            this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                                            this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                                            // ---ADD 2011/07/14-------------<<<<<
                                            return true;
                                        }
                                        else
                                        {
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = campaignCode;
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = campaignName;
                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = sectionCode;

                                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---ADD 2011/07/14------------->>>>>
                                            CampaignObjGoodsSt campaignObjGoodsSt = null;
                                            this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                                            this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                                            // ---ADD 2011/07/14-------------<<<<<
                                            return true;
                                        }
                                        // ---ADD 2011/07/12------------------<<<<<
                                        #endregion
                                    }
                                    // ----- UPD 2011/07/06 ------- <<<<<<<<<
                                    // ----- ADD 2011/07/21 ------- >>>>>>>>>
                                    else
                                    {
                                        moved = false;
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        break;
                                    }
                                    // ----- ADD 2011/07/21 ------- <<<<<<<<<
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
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
                        if (this.uGrid_Details.Rows[0].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation != Activation.AllowEdit)
                        {
                            if ("SectionCode".Equals(this.uGrid_Details.ActiveCell.Column.Key))
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void ReturnKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                this.uGrid_Details.Rows[0].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
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
                columnKey = this._campaignMngDataTable.CampaignCodeColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected)
                {
                    if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                    {
                        if (this.uGrid_Details.ActiveRow.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                        {
                            this.uGrid_Details.ActiveRow.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            this.uGrid_Details.ActiveRow.Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Activate();
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void ShiftKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                this.uGrid_Details.Rows[0].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
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
                columnKey = this._campaignMngDataTable.CampaignCodeColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected)
                {
                    if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                    {
                        if (this.uGrid_Details.ActiveRow.Index > 0)
                        {
                            if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activation == Activation.AllowEdit)
                            {
                                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._campaignMngDataTable.PriceEndDateColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Activate();
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void SetGridGuid()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                switch (this.uGrid_Details.ActiveCell.Column.Key)
                {
                    case "CampaignCode":
                    case "SectionCode":
                    case "GoodsMakerCode":
                    case "BLGoodsCode":
                    case "BLGroupCode":
                    case "SalesCode":
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/04/26</br>
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
                int _Rketa = CampaignObjGoodsStAcs.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/14 ������ Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�</br>
        /// </remarks>
        public void SetFocusAfterSearch()
        {
            if (this.uGrid_Details.Rows.Count > 0)
            {
                if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
                {
                    bool flag = false;
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        // ---UPD 2011/07/12------------------->>>>>
                        //if (row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Text.Trim() == string.Empty
                        //    && row.Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Text.Trim() == "00"
                        //    && (int)row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Value == 1
                        //    && row.Cells[this._campaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Text.Trim() == string.Empty
                        //    && row.Cells[this._campaignMngDataTable.GoodsNoColumn.ColumnName].Text.Trim() == string.Empty
                        //    && row.Cells[this._campaignMngDataTable.BLGoodsCodeColumn.ColumnName].Text.Trim() == string.Empty
                        //    && row.Cells[this._campaignMngDataTable.BLGroupCodeColumn.ColumnName].Text.Trim() == string.Empty
                        //    && row.Cells[this._campaignMngDataTable.SalesCodeColumn.ColumnName].Text.Trim() == string.Empty
                        //    && (int)row.Cells[this._campaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Value == 0)
                        //{
                        //    if (row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                        //    {
                        //        row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                        //        flag = true;
                        //        break;
                        //    }
                        //}

                        if (row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                        {
                            flag = true;
                            if (row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Text.Trim() == string.Empty)
                            {
                                string campaignCode = string.Empty;
                                string campaignName = string.Empty;
                                string sectionCode = string.Empty;
                                this.GetCampaignInfo(out campaignCode, out campaignName, out sectionCode);
                                if (campaignCode == string.Empty)
                                {
                                    row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                                }
                                else
                                {
                                    row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                                    row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = campaignCode;
                                    row.Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = campaignName;
                                    row.Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = sectionCode;

                                    row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                                }
                            }
                            else
                            {
                                row.Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                                row.Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                            }
                            break;
                        }
                        // ---UPD 2011/07/12-------------------<<<<<
                    }

                    // ---UPD 2011/07/12----------------->>>>>
                    if (flag == false)
                    {
                        #region �ŏI�s�̏ꍇ�A�V�K�s��ǉ�����
                        CampaignMngDataSet.CampaignMngRow newRow = this._campaignMngDataTable.NewCampaignMngRow();
                        newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                        newRow.FilterGuid = Guid.Empty;
                        newRow.SectionCode = "00";
                        newRow.GoodsName = "";
                        newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");

                        this._campaignMngDataTable.AddCampaignMngRow(newRow);

                        this.DetailGridInitSetting();
                        #endregion
                        //this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                        
                        string campaignCode = string.Empty;
                        string campaignName = string.Empty;
                        string sectionCode = string.Empty;
                        this.GetCampaignInfo(out campaignCode, out campaignName, out sectionCode);
                        if (campaignCode == string.Empty)
                        {
                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                        }
                        else
                        {
                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignCodeColumn.ColumnName].Value = campaignCode;
                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignNameColumn.ColumnName].Value = campaignName;
                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.SectionCodeColumn.ColumnName].Value = sectionCode;

                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._campaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                        }
                        // ---ADD 2011/07/14------------->>>>>
                        CampaignObjGoodsSt campaignObjGoodsSt = null;
                        this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                        this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                        // ---ADD 2011/07/14-------------<<<<<
                    }
                    // ---UPD 2011/07/12-----------------<<<<<
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


        // ----- ADD 2011/07/07 ------- >>>>>>>>>
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
                    this._userSetting = UserSettingController.DeserializeUserSetting<CampaignMngUserSet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new CampaignMngUserSet();
                }
            }
        }
    }



    /// <summary>
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�p�O���b�h�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�p�O���b�h�ݒ�N���X</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class CampaignMngUserSet
    {
        // �o�͌`��
        private int _outputStyle;

        // ���׃O���b�h�J�������X�g
        private List<ColumnInfo> _detailColumnsList;

        // ���׃O���b�h�����T�C�Y����
        private bool _autoAdjustDetail;

        # region �R���X�g���N�^
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�p�O���b�h�ݒ�N���X
        /// </summary>
        public CampaignMngUserSet()
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
    // ----- ADD 2011/07/07 ------- <<<<<<<<<
}
