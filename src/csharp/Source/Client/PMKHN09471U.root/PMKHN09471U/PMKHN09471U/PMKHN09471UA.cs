//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j 
// �v���O�����T�v   : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�̏������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2010/08/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  2010/08/26  �쐬�S�� : ������
// �C �� ��              �C�����e : Redmine#13690�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���i��
// �C �� ��  2010/09/09  �C�����e : Redmine#14492�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using System.Net.NetworkInformation;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.UltraWinToolbars;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j
    /// </summary>
    /// <remarks>
    /// <br>Note        : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�ݒ菈���ł��B</br>
    /// <br>Programmer  : ������</br>
    /// <br>Date        : 2010/08/10</br>
    /// <br>Update Note : 2010/08/26 ������</br>
    /// <br>              Redmine#13690�Ή�</br>
    /// <br>Update Note : 2010/09/09 ���i��</br>
    /// <br>              Redmine#14492�Ή�</br>
    /// </remarks>
    public partial class PMKHN09471UA : Form
    {
        #region �� Private member ��
        private ImageList _imageList16;
        private ControlScreenSkin _controlScreenSkin;
        private RateProtyMngDataSet.RateProtyMngDataTable _rateProtyMngDataTable;// �|���D��Ǘ��}�X�^�f�[�^�e�[�u��
        // �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�A�N�Z�X
        private RateProtyMngPatternAcs _rateProtyMngPatternAcs;
        private string _enterpriseCode;
        // ���O�C�����_(�����_)
        private string _loginSectionCode;
        private SecInfoSetAcs _secInfoSetAcs;//���_�A�N�Z�X
        private SecInfoAcs _secInfoAcs;
        private string _preSectionCd = string.Empty;//�O�񋒓_�R�[�h
        private string _preSectionNm = string.Empty;//�O�񋒓_����
        /// <summary>�O���b�h�ŏ�ʍs�L�[�_�E���C�x���g</summary>
        internal event EventHandler GridKeyDownTopRow;

        private bool _initMode = false;

        #endregion �� Private member ��

        #region �� Const ��
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// �I��
        //private const string TOOLBAR_NEWBUTTON_KEY = "ButtonTool_New";						// �V�K          // DEL 2010/09/09
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";						// �N���A        // ADD 2010/09/09
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";						// �K�C�h        // ADD 2010/09/09
        private const string TOOLBAR_LOGINTITLELABEL_KEY = "LabelTool_LoginTitle";				// ���O�C���S���҃^�C�g��
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LabelTool_LoginName";				// ���O�C���S���Җ���
        private const string TOOLBAR_SECTIONTITLELABEL_KEY = "LabelTool_SectionTitle";			// ���O�C�����_
        private const string TOOLBAR_SECTIONNAMELABEL_KEY = "LabelTool_SectionName";			// ���O�C�����_����
        private const string ct_PGID = "PMKHN09471UA";
        private const string ct_PGName = "�|���ݒ�}�X�^�����e�i���X";
        // --------UPD 2010/09/09-------->>>>>
        //private const string UNITPRICEKIND_1 = "�����ݒ�";
        //private const string UNITPRICEKIND_2 = "�����ݒ�";
        //private const string UNITPRICEKIND_3 = "���i�ݒ�";
        private const string UNITPRICEKIND_1 = "1:�����ݒ�";
        private const string UNITPRICEKIND_2 = "2:�����ݒ�";
        private const string UNITPRICEKIND_3 = "3:���i�ݒ�";
        // --------UPD 2010/09/09--------<<<<<
        private const string SECTION_CD = "00";
        private const string SECTION_NM = "�S��";
        #endregion �� Const ��

        #region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKHN09471UA()
        {
            InitializeComponent();
            this._controlScreenSkin = new ControlScreenSkin();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._rateProtyMngPatternAcs = RateProtyMngPatternAcs.GetInstance();
            this._rateProtyMngDataTable = _rateProtyMngPatternAcs.RateProtyMngDataSet.RateProtyMng;
            this.uGrid_Detail.DataSource = this._rateProtyMngDataTable;
            GridKeyDownTopRow += new EventHandler(this.uGrid_Detail_GridKeyDownTopRow);
        }
        #endregion �� �R���X�g���N�^ ��

        #region �� �t�H�[�����[�h ��
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void PMKHN09471UA_Load(object sender, EventArgs e)
        {
            ButtonInitialSetting();

            // �P�����
            this.tComboEditor_UnitPriceKind.Items.Clear();
            this.tComboEditor_UnitPriceKind.Items.Add("1", UNITPRICEKIND_1);
            this.tComboEditor_UnitPriceKind.Items.Add("2", UNITPRICEKIND_2);
            this.tComboEditor_UnitPriceKind.Items.Add("3", UNITPRICEKIND_3);

            this._initMode = true;
            this.ClearScreen();
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this._initMode = false;

        }
        #endregion �� �t�H�[�����[�h ��

        #region �� Private Method ��
        /// <summary>
        /// ��ʃ{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʃ{�^�������ݒ���s���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks> 
        private void ButtonInitialSetting()
        {
            // �C���[�W���X�g�ݒ�
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

            //----------------------------
            // �c�[���A�C�R���ݒ�
            //----------------------------
            // �I��
            this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // ----------UPD 2010/09/09------------>>>>>
            // �V�K
            //this.tToolsManager_MainMenu.Tools[TOOLBAR_NEWBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // �N���A
            this.tToolsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // �K�C�h
            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            // ----------UPD 2010/09/09------------<<<<<
            // ���O�C�����_
            this.tToolsManager_MainMenu.Tools[TOOLBAR_SECTIONTITLELABEL_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            // ���O�C�����_��
            ToolBase loginName = this.tToolsManager_MainMenu.Tools[TOOLBAR_SECTIONNAMELABEL_KEY];
            if (loginName != null && LoginInfoAcquisition.Employee != null)
            {
                SecInfoSet secInfoSet = new SecInfoSet();
                this._secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
                if (secInfoSet != null)
                {
                    loginName.SharedProps.Caption = secInfoSet.SectionGuideNm;
                }
            }
            // ���O�C���S����
            this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINTITLELABEL_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // �S���ҕ\��
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABEL_KEY].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            // �A�C�R���ݒ�
            this._imageList16 = IconResourceManagement.ImageList16;

            this.uButton_SectionGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void ClearScreen()
        {
            // ���_
            this.tEdit_SectionCodeAllowZero.Clear();
            this.tEdit_SectionCodeAllowZero.Text = SECTION_CD;
            this.tEdit_SectionName.Text = SECTION_NM;
            this._preSectionCd = SECTION_CD;
            this._preSectionNm = SECTION_NM;
            // �P�����
            this.tComboEditor_UnitPriceKind.SelectedIndex = 0;

            if (!this._initMode)
            {
                this.InitialDataGrid();
            }

            // �t�H�[�J�X�̐ݒ�
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// �O���b�h�̏���������
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �O���b�h�̏������������s���B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void InitialDataGrid()
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʌ��������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }
            int status = 0;
            string errMess = string.Empty;
            this._rateProtyMngDataTable.Rows.Clear();

            // �|���D��Ǘ��}�X�^�ǂݍ���
            RateProtyMngWork rateProtyMngWork = new RateProtyMngWork();
            rateProtyMngWork.EnterpriseCode = this._enterpriseCode;
            // ���_
            if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
            {
                rateProtyMngWork.SectionCode = SECTION_CD;
            }
            else
            {
                rateProtyMngWork.SectionCode = tEdit_SectionCodeAllowZero.Text.Trim();
            }
            //�P�����
            rateProtyMngWork.UnitPriceKind = tComboEditor_UnitPriceKind.SelectedIndex + 1;

            status = this._rateProtyMngPatternAcs.Search(rateProtyMngWork, out errMess);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                this.uGrid_Detail.Focus();
                this.uGrid_Detail.ActiveRow = this.uGrid_Detail.Rows[0];
                this.uGrid_Detail.ActiveRow.Selected = true;
            }
            else if(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�Y���f�[�^�����݂��܂���B",
                            0,
                            MessageBoxButtons.OK);
            }
            else
            {
                // �G���[��
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    errMess,
                    -1,
                    MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <br>Update Note : 2010/09/09 ������</br>
        /// <br>            : Redmine#14490�Ή�</br>
        private bool ReadSectionCodeAllowZeroName(out string code, out string name)
        {
            // ���͒l���擾
            string sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
            code = sectionCode;
            name = tEdit_SectionName.Text;

            if (_preSectionCd == sectionCode)
            {
                this.tEdit_SectionCodeAllowZero.Text = sectionCode;
                return true;
            }

            // 00:�S��
            if (sectionCode == SECTION_CD)
            {
                code = sectionCode;
                name = SECTION_NM;
                return true;
            }
            else if (!String.IsNullOrEmpty(sectionCode.Trim()))
            {
                // ���_�����擾
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // �X�e�[�^�X������̏ꍇ��UI�ɃZ�b�g
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // --------UPD 2010/09/09-------->>>>>
                    //code = sectionInfo.SectionCode.TrimEnd();
                    //name = sectionInfo.SectionGuideSnm.TrimEnd();
                    //return true;

                    if (sectionInfo.LogicalDeleteCode != 0)
                    {
                        code = _preSectionCd;
                        name = _preSectionNm;
                        return false;
                    }
                    else
                    {
                        code = sectionInfo.SectionCode.TrimEnd();
                        name = sectionInfo.SectionGuideSnm.TrimEnd();
                        return true;
                    }
                    // --------UPD 2010/09/09--------<<<<<
                }
                else
                {
                    code = _preSectionCd;
                    name = _preSectionNm;
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                name = string.Empty;
                return true;
            }
        }

        /// <summary>
        /// �I�𖾍׃f�[�^�擾
        /// </summary>
        /// <param name="gridRow">�I���������׃f�[�^</param>
        /// <param name="rateProtyMng">�|���D��Ǘ��}�X�^</param>
        /// <br>Note       : �I�𖾍׃f�[�^�擾���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        private void GridDetailToRateProtyMng(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow, ref RateProtyMng rateProtyMng)
        {
            rateProtyMng.RateSettingDivide = (string)gridRow.Cells[this._rateProtyMngDataTable.RateSettingDivideColumn.ColumnName].Value;
            rateProtyMng.RatePriorityOrder = (int)gridRow.Cells[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Value;
            rateProtyMng.RateMngGoodsNm = (string)gridRow.Cells[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Value;
            rateProtyMng.RateMngCustNm = (string)gridRow.Cells[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Value;
            rateProtyMng.UnitPriceKind = (int)gridRow.Cells[this._rateProtyMngDataTable.UnitPriceKindColumn.ColumnName].Value;
            rateProtyMng.SectionCode = (string)gridRow.Cells[this._rateProtyMngDataTable.SectionCodeColumn.ColumnName].Value;
            rateProtyMng.RateMngCustCd = (string)gridRow.Cells[this._rateProtyMngDataTable.RateMngCustCdColumn.ColumnName].Value;
            rateProtyMng.RateMngGoodsCd = (string)gridRow.Cells[this._rateProtyMngDataTable.RateMngGoodsCdColumn.ColumnName].Value;
        }

        /// <summary>
        /// �I�𖾍׃f�[�^�ɂ���āA�e�p�^�[����ʂ̋N���B
        /// </summary>
        /// <param name="rateProtyMng">�|���D��Ǘ��}�X�^</param>
        /// <br>Note       : �I�𖾍׃f�[�^�ɂ���āA�e�p�^�[����ʂ��N������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        private void ShowChildForm(RateProtyMng rateProtyMng)
        {
            switch (rateProtyMng.RatePriorityOrder)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    {
                        // �|���ݒ�}�X�^�i�|���D��Ǘ�����݁j(�i�Ԏw��)
                        PMKHN09472UA _pMKHN09472UA = new PMKHN09472UA(rateProtyMng);
                        _pMKHN09472UA.ShowDialog();
                        break;
                    }
                case 7:
                case 9:
                case 13:
                case 18:
                case 20:
                case 24:
                case 29:
                case 31:
                case 35:
                case 40:
                case 42:
                case 46:
                case 51:
                case 53:
                case 57:
                case 62:
                case 64:
                    {
                        // �|���ݒ�}�X�^�i�|���D��Ǘ�����݁j(BL���ގw��)
                        PMKHN09477UA _pMKHN09477UA = new PMKHN09477UA(rateProtyMng);
                        _pMKHN09477UA.ShowDialog();
                        break;
                    }
                case 8:
                case 10:
                case 14:
                case 19:
                case 21:
                case 25:
                case 30:
                case 32:
                case 36:
                case 41:
                case 43:
                case 47:
                case 52:
                case 54:
                case 58:
                case 63:
                case 65:
                    {
                        // �|���ݒ�}�X�^�i�|���D��Ǘ�����݁j(��ٰ�ߺ��ގw��)
                        PMKHN09476UA _pMKHN09476UA = new PMKHN09476UA(rateProtyMng);
                        _pMKHN09476UA.ShowDialog();
                        break;
                    }
                case 11:
                case 15:
                case 22:
                case 26:
                case 33:
                case 37:
                case 44:
                case 48:
                case 55:
                case 59:
                case 66:
                    {
                        // �|���ݒ�}�X�^�i�|���D��Ǘ�����݁j(���i�|����ٰ�ߎw��)
                        PMKHN09475UA _pMKHN09475UA = new PMKHN09475UA(rateProtyMng);
                        _pMKHN09475UA.ShowDialog();
                        break;
                    }
                case 12:
                case 23:
                case 34:
                case 45:
                case 56:
                case 67:
                    {
                        // �|���ݒ�}�X�^�i�|���D��Ǘ�����݁j(�w�ʎw��)
                        PMKHN09474UA _pMKHN09474UA = new PMKHN09474UA(rateProtyMng);
                        _pMKHN09474UA.ShowDialog();
                        break;
                    }
                case 16:
                case 27:
                case 38:
                case 49:
                case 60:
                    {
                        // �|���ݒ�}�X�^�i�|���D��Ǘ�����݁j(���[�J�[�w��)
                        PMKHN09478UA _pMKHN09478UA = new PMKHN09478UA(rateProtyMng);
                        _pMKHN09478UA.ShowDialog();
                        break;
                    }
                case 17:
                case 28:
                case 39:
                case 50:
                case 61:
                case 68:
                case 69:
                case 70:
                case 71:
                    {
                        // �|���ݒ�}�X�^�i�|���D��Ǘ�����݁j(�P�Ǝw��)
                        PMKHN09473UA _pMKHN09473UA = new PMKHN09473UA(rateProtyMng);
                        _pMKHN09473UA.ShowDialog();
                        break;
                    }
                default:
                    {
                        break;
                    }

            }
        }

        #region �� uGrid_Detail�̊֘A���� ��

        #endregion �� uGrid_Detail�̊֘A���� ��

        /// <summary>
        /// �O���b�h�ŏ�ʍs�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʃw�b�_�N���A�������s���B </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private void uGrid_Detail_GridKeyDownTopRow(object sender, EventArgs e)
        {
            this.tComboEditor_UnitPriceKind.Focus();
        }

        #region �� �I�t���C����ԃ`�F�b�N����
        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N�������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        public static bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������				
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// �����[�g�ڑ��\����
        /// </summary>
        /// <returns>���茋��</returns>
        /// <remarks>
        /// <br>Note       : �����[�g�ڑ��\������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private static bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #endregion �� Private Method ��

        #region �� �C�x���g ��
        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/09/09 ���i��</br>
        /// <br>              Redmine#14492�Ή�</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.Close();
                        break;
                    }
                //case "ButtonTool_New":// DEL 2010/09/09
                case "ButtonTool_Clear":// ADD 2010/09/09
                    {
                        // �N���A����
                        ClearScreen();
                        break;
                    }
                 // -------ADD 2010/09/09------->>>>>
                case "ButtonTool_Guide":
                    {
                        // �K�C�h����
                        if (this.tEdit_SectionCodeAllowZero.Focused)
                        {
                            uButton_SectionGuide_Click(sender, e);
                        }
                        
                        break;
                    }
                // --------ADD 2010/09/09-------<<<<<
            }
        }

        /// <summary>
        /// �O���b�h�������C�A�E�g�ݒ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A�O���b�h�������C�A�E�g�ݒ���s���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/08/26 ������</br>
        /// <br>              Redmine#13690�Ή�</br>
        /// </remarks>
        private void uGrid_Detail_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Detail.DisplayLayout.Bands[0];
            if (band == null) return;

            int visiblePosition = 0;
            this.uGrid_Detail.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in band.Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            }

            // ----------UPD 2010/08/26--------->>>>>

            // �\������
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // Fix�ݒ�
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Header.Fixed = true;

            // �^�C�g���ݒ�
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Header.Caption = "�|���D�揇��";
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Header.Caption = "�|���ݒ薼��(���Ӑ�)";
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Header.Caption = "�|���ݒ薼��(���i)";

            // �^�C�g���̋l�ߕ�
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // ���͋��ݒ�
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �\�����ݒ�
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Width = 100;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Width = 180;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Width = 180;

            // �Œ��ݒ�
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            // �l�ߕ��ݒ�
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // Style�ݒ�
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // ��\���ݒ�
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Hidden = false;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Hidden = false;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Hidden = false;
            // ----------UPD 2010/08/26---------<<<<<

        }

        /// <summary>
        /// Button_Click �C�x���g(SectionGuide_Click)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            // -----------ADD 2010/09/09 -------------->>>>>
            #region ���K�C�h�L�������̐ݒ�
                this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
            #endregion
            // -----------ADD 2010/09/09 --------------<<<<<
            // ���_�K�C�h�\��
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.Trim();
                this.tEdit_SectionName.Text = sectionInfo.SectionGuideNm.Trim();
                // ���_���ύX���ďꍇ
                if (_preSectionCd != sectionInfo.SectionCode.Trim())
                {
                    this.InitialDataGrid();
                }
                this._preSectionCd = sectionInfo.SectionCode.Trim();
                this._preSectionNm = sectionInfo.SectionGuideSnm.Trim();
                // ���t�H�[�J�X
                this.tComboEditor_UnitPriceKind.Focus();
            }

        }

        /// <summary>
        /// ChangeFocus �C�x���g(tArrowKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                //-----------------------------------------------------
                // ���_
                //-----------------------------------------------------
                case "tEdit_SectionCodeAllowZero":
                    {
                        # region [���_]
                        string inputValue = this.tEdit_SectionCodeAllowZero.Text;

                        string code;
                        string name;
                        bool status = ReadSectionCodeAllowZeroName(out code, out name);

                        if (status == true)
                        {
                            this.tEdit_SectionCodeAllowZero.Text = code;
                            this.tEdit_SectionName.Text = name;

                            // ���_���ύX���ďꍇ
                            if (_preSectionCd != code)
                            {
                                this.InitialDataGrid();
                            }
                            _preSectionCd = code;
                            _preSectionNm = name;


                            #region [�t�H�[�J�X����]
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                    case Keys.Up:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SectionGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_UnitPriceKind;
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                }
                            }
                            #endregion [�t�H�[�J�X����]
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���_�R�[�h�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�߂�
                            this.tEdit_SectionCodeAllowZero.Text = code;
                            this.tEdit_SectionName.Text = name;
                            this.tEdit_SectionCodeAllowZero.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        # endregion
                        break;
                    }
                //-----------------------------------------------------
                // ���_�{�^��
                //-----------------------------------------------------
                case "uButton_SectionGuide":
                    {
                        # region [�t�H�[�J�X����]
                        // �t�H�[�J�X����
                        if (!e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tComboEditor_UnitPriceKind;
                                        break;
                                    }
                            }
                        }
                        #endregion
                        break;
                    }
                //-----------------------------------------------------
                // �P�����
                //-----------------------------------------------------
                case "tComboEditor_UnitPriceKind":
                    {
                        # region [�t�H�[�J�X����]
                        // �t�H�[�J�X����
                        if (!e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        // �ړ����Ȃ�
                                        e.NextCtrl = this.uGrid_Detail;
                                        if ((this.uGrid_Detail.ActiveRow == null) && (this.uGrid_Detail.Rows.Count != 0))
                                        {
                                            this.uGrid_Detail.ActiveRow = this.uGrid_Detail.Rows[0];
                                            this.uGrid_Detail.ActiveRow.Selected = true;
                                        }
                                        else if (this.uGrid_Detail.Rows.Count == 0)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else
                                        {
                                            this.uGrid_Detail.ActiveRow.Selected = true;
                                        }
                                        break;
                                    }
                            }
                        }
                        #endregion
                        break;
                    }
                //-----------------------------------------------------
                // ����
                //-----------------------------------------------------
                case "uGrid_Detail":
                    {
                       # region [�t�H�[�J�X����]
                        // �t�H�[�J�X����
                        if (!e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                    {
                                        if (this.uGrid_Detail.ActiveRow != null)
                                        {
                                            int rowIndex = this.uGrid_Detail.ActiveRow.Index;

                                            #region [�I�𖾍׃f�[�^�擾]
                                            RateProtyMng rateProtyMng = new RateProtyMng();
                                            GridDetailToRateProtyMng(this.uGrid_Detail.Rows[rowIndex], ref rateProtyMng);
                                            #endregion [�I�𖾍׃f�[�^�擾]

                                            // �I�𖾍׃f�[�^�ɂ���āA�e�p�^�[����ʂ��N������
                                            ShowChildForm(rateProtyMng);
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                            }
                        }
                        #endregion
                       break;
                    }
            }

            // ---ADD 2010/09/09---------------------->>>>>
            #region ���K�C�h�L�������̐ݒ�
            if (this.tEdit_SectionCodeAllowZero.Focused)
            {
                this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
            }
            else
            {
                this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
            }
            #endregion
            // ---ADD 2010/09/09----------------------<<<<<

        }

        /// <summary>
        /// uGrid_Detail_DoubleClick�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : uGrid_Detail_DoubleClick�C�x���g���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        private void uGrid_Detail_DoubleClick(object sender, EventArgs e)
        {
            if (this.uGrid_Detail.ActiveRow == null) return;

            int rowIndex = this.uGrid_Detail.ActiveRow.Index;

            #region [�I�𖾍׃f�[�^�擾]
            RateProtyMng rateProtyMng = new RateProtyMng();
            GridDetailToRateProtyMng(this.uGrid_Detail.Rows[rowIndex], ref rateProtyMng);
            #endregion [�I�𖾍׃f�[�^�擾]

            // �I�𖾍׃f�[�^�ɂ���āA�e�p�^�[����ʂ��N������
            ShowChildForm(rateProtyMng);
        }

        /// <summary>
        /// uGrid_Detail_KeyDown�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : uGrid_Detail_KeyDown�C�x���g���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        private void uGrid_Detail_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Detail.ActiveRow == null) return;

            // �ŏ�s�ł́��L�[
            if (this.uGrid_Detail.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    if (this.GridKeyDownTopRow != null)
                    {
                        this.GridKeyDownTopRow(this, new EventArgs());
                        // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                        e.Handled = true;
                    }

                }
            }
            // �����L�[
            if (e.KeyCode == Keys.Right)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
                // �O���b�h�\�����E�ɃX�N���[��
                this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position + 40;
            }

            // �����L�[
            if (e.KeyCode == Keys.Left)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
                if (this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position == 0)
                {
                    //
                }
                else
                {
                    // �O���b�h�\�������ɃX�N���[��
                    this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position - 40;
                }
            }

            // Home�L�[
            if (e.KeyCode == Keys.Home)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;

                // ���L�[�Ƃ̑g���������̏ꍇ
                if (e.Modifiers == Keys.None)
                {
                    // �O���b�h�\�������擪�ɃX�N���[��
                    this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position = 0;
                }

                // Control�L�[�Ƃ̑g�����̏ꍇ
                if (e.Modifiers == Keys.Control)
                {
                    // �擪�s�Ɉړ�
                    this.uGrid_Detail.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                }
            }

            // End�L�[
            if (e.KeyCode == Keys.End)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;

                // ���L�[�Ƃ̑g���������̏ꍇ
                if (e.Modifiers == Keys.None)
                {
                    // �O���b�h�\�������擪�ɃX�N���[��
                    this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Range;
                }

                // Control�L�[�Ƃ̑g�����̏ꍇ
                if (e.Modifiers == Keys.Control)
                {
                    // �ŏI�s�Ɉړ�
                    this.uGrid_Detail.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                }
            }
        }

        /// <summary>
        /// tComboEditor_UnitPriceKind_ValueChanged�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>Note       : tComboEditor_UnitPriceKind_ValueChanged�C�x���g���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/10</br>
        /// <br>Update Note : 2010/09/09 ���i��</br>
        /// <br>              Redmine#14492�Ή�</br>
        private void tComboEditor_UnitPriceKind_ValueChanged(object sender, EventArgs e)
        {
            // ---------ADD 2010/09/09-------------->>>>>
            if (this.tComboEditor_UnitPriceKind.Value!= null)
            {
                string str =this.tComboEditor_UnitPriceKind.Value.ToString();
                if (!Regex.IsMatch(str,"^[1-3]$"))
                {
                    this.tComboEditor_UnitPriceKind.Value = 1;
                }
                this.InitialDataGrid();
            }
            // ---------ADD 2010/09/09--------------<<<<<

            
        }

        // ---------ADD 2010/09/09-------------->>>>>
        /// <summary>
        /// Enter�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Programmer  : ���i��</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_Enter(object sender, EventArgs e)
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Programmer  : ���i��</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Programmer  : ���i��</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private void tComboEditor_UnitPriceKind_Leave(object sender, EventArgs e)
        {
            if (this.tComboEditor_UnitPriceKind.Value == null)
            {
                    this.tComboEditor_UnitPriceKind.Value = 1;
                this.InitialDataGrid();
            }
        }
        // ---------ADD 2010/09/09-------------->>>>>
        #endregion �� �C�x���g ��

    }
}