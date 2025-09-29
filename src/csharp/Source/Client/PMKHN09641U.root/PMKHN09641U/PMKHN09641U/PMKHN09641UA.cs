//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Broadleaf.Application.Controller;
using System.Collections;
using System.Net.NetworkInformation;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜���s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2011/04/26</br>
    /// </remarks>
    public partial class PMKHN09641UA : Form
    {
        # region Private Constant
        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_UPDATEBUTTON_KEY = "ButtonTool_Update";
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";
        private const string TOOLBAR_LOGINSECTIONLABLE_KEY = "LabelTool_LoginTitle";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LabelTool_LoginName";

        private const string ctGUIDE_NAME_Section = "tEdit_SectionCodeAllowZero";
        private const string ctGUIDE_NAME_GoodsMakerCd = "tNedit_GoodsMakerCd";
        private const string ctGUIDE_NAME_HGoodsNo = "tEdit_HGoodsNo";
        private const string ctGUIDE_NAME_Grid = "ultraGrid_DeleteObject";

        private const int INIT_MODE = 0;
        private const int SEARCH_MODE = 1;

        // �N���X��
        private string ct_PRINTNAME = "�L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜";
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;					// �����{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;					// �X�V�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;					// �K�C�h�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;					// �N���A�{�^��					
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;				// ���O�C���S���Җ���
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;

        private string _enterpriseCode;
        private CampaignGoodsStAcs _campaignGoodsStAcs = null;
        private SecInfoAcs _secInfoAcs;                     // ���_���A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = null;        // ���_�A�N�Z�X�N���X
        private MakerAcs _makerAcs = null;					// ���[�J�[�A�N�Z�X�N���X
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Control _prevControl = null;									// ���݂̃R���g���[��
        private string _guideKey;
        private int _retKeyFlag = -1;                       //����t���O

        private CampaignGoodsDataSet.CampaignGoodsDataTable _campaignGoodsDataTable;
        # endregion

        // ===================================================================================== //
        // Constructor
        // ===================================================================================== //
        #region�@Constructor
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2011/04/26</br>
        /// </remarks>
        public PMKHN09641UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;

            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABLE_KEY];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_SEARCHBUTTON_KEY];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_UPDATEBUTTON_KEY];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY];

            //�@��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._campaignGoodsStAcs = CampaignGoodsStAcs.GetInstance();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._makerAcs = new MakerAcs();
            this._secInfoAcs = new SecInfoAcs();

            this._campaignGoodsDataTable = this._campaignGoodsStAcs.CampaignGoodsDataTable;

            // �}�X�^�Ǎ�
            ReadSecInfoSet();
            // ���[�J�[�}�X�^�Ǎ�����
            LoadMakerUMnt();

            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
        }
        #endregion

        // ===================================================================================== //
        //  Private Methods
        // ===================================================================================== //
        #region�@Private Methods
        /// <summary>
        /// ������ʐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            // �c�[���o�[�����ݒ菈��
            this.ToolBarInitilSetting();

            // �{�^���A�C�R���ݒ�
            this.SetGuidButtonIcon();

            // �c�[���{�^��Enable�ݒ菈��
            this.SetControlEnabled(INIT_MODE);
        }

        /// <summary>
        /// �c�[���o�[�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������A�c�[���o�[�����ݒ菈�����s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;

            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
        }

        /// <summary>
        /// �K�C�h�{�^���̃A�C�R���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �K�C�h�{�^���̃A�C�R����ݒ肵�܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            this.SectionGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.MakerGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// �R���g���[��Enabled���䏈��
        /// </summary>
        /// <param name="editMode">�ҏW���[�h</param>
        /// <remarks>
        /// <br>Note       : �R���g���[����Enabled������s���܂��B</br>
        /// <br>Programer  : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void SetControlEnabled(int editMode)
        {
            if (editMode == INIT_MODE)
            {
                this._updateButton.SharedProps.Enabled = false;
            }
            else
            {
                this._updateButton.SharedProps.Enabled = true;
            }

            this.SettingGuideButtonToolEnabled(this.ActiveControl);
        }

        /// <summary>
        /// ��ʕ\��
        /// </summary>
        /// <param name="campaignGoodsData">��ʃf�[�^</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void SetDisplay(CampaignGoodsData campaignGoodsData)
        {
            if (campaignGoodsData == null) return;

            // start
            this.tEdit_SectionCodeAllowZero.BeginUpdate();
            this.tNedit_GoodsMakerCd.BeginUpdate();
            this.tEdit_HGoodsNo.BeginUpdate();


            // ��ʏ���\������
            this.tEdit_SectionCodeAllowZero.Text = campaignGoodsData.SectionCode;
            this.tEdit_SectionName.Text = campaignGoodsData.SectionName;
            this.tNedit_GoodsMakerCd.SetInt(campaignGoodsData.GoodsMakerCd);
            if (campaignGoodsData.GoodsMakerNm.Length > 10)
            {
                this.tEdit_MakerNm.Text = campaignGoodsData.GoodsMakerNm.Substring(0, 10);
            }
            else
            {
                this.tEdit_MakerNm.Text = campaignGoodsData.GoodsMakerNm;
            }
            this.tEdit_HGoodsNo.Text = campaignGoodsData.HeaderGoodsNo;

            this.GoodsStCount_uLabel.Text = campaignGoodsData.GoodsStCount.ToString("N0") + " " + "��";
            this.NameStCount_uLabel.Text = campaignGoodsData.NameStCount.ToString("N0") + " " + "��";
            this.CustomStCount_uLabel.Text = campaignGoodsData.CustomStCount.ToString("N0") + " " + "��";
            this.TargetStCount_uLabel.Text = campaignGoodsData.TargetStCount.ToString("N0") + " " + "��";

            // ���ENABLE
            this.tEdit_SectionCodeAllowZero.Enabled = true;
            this.SectionGuide_Button.Enabled = true;

            // end
            this.tEdit_SectionCodeAllowZero.EndUpdate();
            this.tNedit_GoodsMakerCd.EndUpdate();
            this.tEdit_HGoodsNo.EndUpdate();
        }

        /// <summary>
        /// ��ʏ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void Clear()
        {
            // ��ʏ������f�[�^
            this._campaignGoodsStAcs.CreateCampaignGoodsInitialData();
            // ��ʏ������\��
            this.SetDisplay(this._campaignGoodsStAcs.CampaignGoodsData);
            // �폜�Ώۃf�[�^��ʏ������\��
            this._campaignGoodsDataTable.Clear();
            // �R���g���[��Enabled���䏈��
            this.SetControlEnabled(INIT_MODE);

            this.timer_SetFocus.Enabled = true;
        }

        /// <summary>
        /// �u�K�C�h�v����
        /// </summary>
        private void ExecuteGuide()
        {
            switch (this._guideKey)
            {
                // ���_
                case ctGUIDE_NAME_Section:
                    {
                        this.SectionGuide_Button_Click(this.SectionGuide_Button, new EventArgs());
                        break;
                    }
                // ���[�J�[
                case ctGUIDE_NAME_GoodsMakerCd:
                    {
                        this.MakerGuide_Button_Click(this.MakerGuide_Button, new EventArgs());
                        break;
                    }

            }
        }

        /// <summary>
        /// ��ʌ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void Search()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

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

            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
                if (this._retKeyFlag != 1)
                {
                    return; 
                }
            }
            // �`�F�b�N
            bool isSave = this.BeforeSearchCheck();

            if (!isSave)
            {
                return;
            }

            // ����
            string errMessge;
            status = this._campaignGoodsStAcs.SearchData(out errMessge);

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    this.SetControlEnabled(SEARCH_MODE);
                    break;

                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    // 0���G���[
                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0);
                    this.SetControlEnabled(INIT_MODE);
                    break;

                default:
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�����Ɏ��s���܂����B", -1);
                    this.SetControlEnabled(INIT_MODE);
                    break;
            }

            this.GoodsStCount_uLabel.Text = "0 ��";
            this.NameStCount_uLabel.Text = "0 ��";
            this.CustomStCount_uLabel.Text = "0 ��";
            this.TargetStCount_uLabel.Text = "0 ��";
        }

        /// <summary>
        /// �ꊇ�폜����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ꊇ�폜�������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void DeleteAll()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
            }

            // �m�F���b�Z�[�W��\������B
            DialogResult result = TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,             // �G���[���x��
                        "PMKHN09641UA",						            // �A�Z���u���h�c�܂��̓N���X�h�c
                        ct_PRINTNAME,				                    // �v���O��������
                        "", 								            // ��������
                        "",									            // �I�y���[�V����
                        "�ꊇ�폜�������J�n���Ă���낵���ł����H",		// �\�����郁�b�Z�[�W
                        -1, 							                // �X�e�[�^�X�l
                        null, 								            // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.YesNo, 				        // �\������{�^��
                        MessageBoxDefaultButton.Button1);	            // �����\���{�^��
            // ���͉�ʂ֖߂�B
            if (result == DialogResult.No)
            {
                return;
            }

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "�X�V��";
            msgForm.Message = "�X�V���ł��B";
            try
            {
                msgForm.Show();

                string msg = string.Empty;
                // �X�V����
                status = this._campaignGoodsStAcs.DeleteData(ref msg);

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        this.SetDisplay(this._campaignGoodsStAcs.CampaignGoodsData);
                        // �t�H�[�J�X�͋��_�ɖ߂�
                        this.tEdit_SectionCodeAllowZero.Focus();
                        this.SetControlEnabled(INIT_MODE);

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        "PMKHN09641U",							// �A�Z���u��ID
                        "�L�����y�[���Ώۏ��i�ݒ�}�X�^��\n���ɑ��[���ɂ��X�V����Ă���ׁA�����𒆒f���܂����B\n�Ď��s���邩�A���΂炭�҂��Ă���ēx���������s���ĉ������B",	    // �\�����郁�b�Z�[�W
                        status,									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��

                        // �t�H�[�J�X�͋��_�ɖ߂�
                        this.tEdit_SectionCodeAllowZero.Focus();
                        this.SetControlEnabled(INIT_MODE);

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                       TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                       "PMKHN09641U",							// �A�Z���u��ID
                       "�L�����y�[���Ώۏ��i�ݒ�}�X�^��\n���ɑ��[���ɂ��폜����Ă���ׁA�����𒆒f���܂����B\n�Ď��s���邩�A���΂炭�҂��Ă���ēx���������s���ĉ������B",	    // �\�����郁�b�Z�[�W
                       status,									// �X�e�[�^�X�l
                       MessageBoxButtons.OK);					// �\������{�^��
                        // �t�H�[�J�X�͋��_�ɖ߂�
                        this.tEdit_SectionCodeAllowZero.Focus();
                        this.SetControlEnabled(INIT_MODE);

                        break;

                    default:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�X�V�Ɏ��s���܂����B", 0);
                        this.SetControlEnabled(INIT_MODE);
                        break;
                }
            }
            finally
            {
                msgForm.Close();
            }
        }

        /// <summary>
        /// ��ʌ����O�`�F�b�N
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private bool BeforeSearchCheck()
        {
            CampaignGoodsData campaignGoodsData = this._campaignGoodsStAcs.CampaignGoodsData;

            // ���_���̓`�F�b�N
            if (string.IsNullOrEmpty(campaignGoodsData.SectionCode))
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "���_���ݒ肳��Ă��܂���B",                       // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.tEdit_SectionCodeAllowZero.Focus();
                return false;
            }

            // ���[�J�[���̓`�F�b�N
            if (campaignGoodsData.GoodsMakerCd == 0)
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "���[�J�[�R�[�h����͂��ĉ������B",                 // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.tNedit_GoodsMakerCd.Focus();
                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                return false;
            }

            return true;
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_��</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (sectionCode == "00")
            {
                return "�S��";
            }

            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
            }

            return "";
        }

        /// <summary>
        /// Ұ�����擾����
        /// </summary>
        /// <param name="goodsMakerCd">Ұ���R�[�h</param>
        /// <returns>Ұ����</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private string GetGoodsMakerNm(int goodsMakerCd)
        {
            if (this._makerUMntDic.ContainsKey(goodsMakerCd))
            {
                return this._makerUMntDic[goodsMakerCd].MakerName.Trim();
            }

            return "";
        }

        /// <summary>
        /// ���_���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void LoadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// �{�^���c�[���L�������ݒ菈��
        /// </summary>
        /// <param name="nextControl">���̃R���g���[��</param>
        /// <remarks>
        /// <br>Note		: �{�^���c�[���L�������ݒ菈��</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SettingGuideButtonToolEnabled(Control nextControl)
        {
            if (nextControl == null) return;

            Control targetControl = nextControl;
            if (nextControl.Parent != null)
            {
                if ((nextControl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                    (nextControl.Parent is Broadleaf.Library.Windows.Forms.TEdit))
                {
                    targetControl = nextControl.Parent;
                }
            }

            if (targetControl.Name == ctGUIDE_NAME_Section
                || targetControl.Name == ctGUIDE_NAME_GoodsMakerCd)
            {
                this._guideButton.SharedProps.Enabled = true;
                this._guideKey = targetControl.Name;
            }
            else
            {
                this._guideButton.SharedProps.Enabled = false;
            }
        }

        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ������̎��A�O���b�h�񏉊��ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SetGridInitialLayout()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid_DeleteObject.DisplayLayout.Bands[0];
            if (editBand == null) return;

            CampaignGoodsDataSet.CampaignGoodsDataTable table = this._campaignGoodsDataTable;
            ColumnsCollection columns = editBand.Columns;

            editBand.ColHeadersVisible = true;

            // ����
            columns[table.CampaignCodeColumn.ColumnName].Header.Caption = "����";
            columns[table.CampaignNameColumn.ColumnName].Header.Caption = "����";
            columns[table.SectionCodeColumn.ColumnName].Header.Caption = "���_";
            columns[table.SectionNameColumn.ColumnName].Header.Caption = "���_��";
            columns[table.CampaignSettingKindNmColumn.ColumnName].Header.Caption = "�ݒ���";
            columns[table.GoodsMakerCdColumn.ColumnName].Header.Caption = "Ұ��";
            columns[table.GoodsMakerNmColumn.ColumnName].Header.Caption = "Ұ����";
            columns[table.GoodsNoColumn.ColumnName].Header.Caption = "�i��";
            columns[table.GoodsNameColumn.ColumnName].Header.Caption = "�i��";
            columns[table.CustomerCodeColumn.ColumnName].Header.Caption = "���Ӑ�";
            columns[table.CustomerNameColumn.ColumnName].Header.Caption = "���Ӑ於";
            columns[table.DiscountRateColumn.ColumnName].Header.Caption = "�l����";
            columns[table.PriceFlColumn.ColumnName].Header.Caption = "�����z";
            columns[table.RateValColumn.ColumnName].Header.Caption = "������";
            columns[table.PriceStartDateColumn.ColumnName].Header.Caption = "���i�J�n��";
            columns[table.PriceEndDateColumn.ColumnName].Header.Caption = "���i�I����";

            // �\�����ݒ�
            columns[table.CampaignCodeColumn.ColumnName].Width = 90;
            columns[table.CampaignNameColumn.ColumnName].Width = 120;
            columns[table.SectionCodeColumn.ColumnName].Width = 90;
            columns[table.SectionNameColumn.ColumnName].Width = 170;
            columns[table.CampaignSettingKindNmColumn.ColumnName].Width = 120;
            columns[table.GoodsMakerCdColumn.ColumnName].Width = 90;
            columns[table.GoodsMakerNmColumn.ColumnName].Width = 170;
            columns[table.GoodsNoColumn.ColumnName].Width = 170;
            columns[table.GoodsNameColumn.ColumnName].Width = 300;
            columns[table.CustomerCodeColumn.ColumnName].Width = 90;
            columns[table.CustomerNameColumn.ColumnName].Width = 170;
            columns[table.DiscountRateColumn.ColumnName].Width = 90;
            columns[table.PriceFlColumn.ColumnName].Width = 150;
            columns[table.RateValColumn.ColumnName].Width = 90;
            columns[table.PriceStartDateColumn.ColumnName].Width = 100;
            columns[table.PriceEndDateColumn.ColumnName].Width = 100;

            // ���͋��ݒ�
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // �S�Ă̗�������������͂ɂ���B
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            // �l��
            columns[table.CampaignCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.CampaignNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.SectionCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.SectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.CampaignSettingKindNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.GoodsMakerNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.CustomerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.DiscountRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[table.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[table.RateValColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[table.PriceStartDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[table.PriceEndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            string FORMAT1 = "##0.00;-##0.00;''";
            string FORMAT2 = "#,###,###,##0.00;-#,###,###,##0.00;''";
            string FORMAT3 = "0000;''";

            // Format
            columns[table.GoodsMakerCdColumn.ColumnName].Format = FORMAT3;
            columns[table.DiscountRateColumn.ColumnName].Format = FORMAT1;
            columns[table.RateValColumn.ColumnName].Format = FORMAT1;
            columns[table.PriceFlColumn.ColumnName].Format = FORMAT2;
        }

        /// <summary>
        /// �O���b�h��\����\���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ������̎��A�O���b�h�񏉊��ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SetGridColVisible()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid_DeleteObject.DisplayLayout.Bands[0];
            if (editBand == null) return;

            CampaignGoodsDataSet.CampaignGoodsDataTable table = this._campaignGoodsDataTable;
            ColumnsCollection columns = editBand.Columns;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                col.Hidden = true;
            }

            // ����
            columns[table.CampaignCodeColumn.ColumnName].Hidden = false;
            // ����
            columns[table.CampaignNameColumn.ColumnName].Hidden = false;
            // ���_
            columns[table.SectionCodeColumn.ColumnName].Hidden = false;
            // ���_��
            columns[table.SectionNameColumn.ColumnName].Hidden = false;
            // �ݒ���
            columns[table.CampaignSettingKindNmColumn.ColumnName].Hidden = false;
            // Ұ��
            columns[table.GoodsMakerCdColumn.ColumnName].Hidden = false;
            // Ұ����
            columns[table.GoodsMakerNmColumn.ColumnName].Hidden = false;
            // �i��
            columns[table.GoodsNoColumn.ColumnName].Hidden = false;
            // �i��
            columns[table.GoodsNameColumn.ColumnName].Hidden = false;
            // ���Ӑ�
            columns[table.CustomerCodeColumn.ColumnName].Hidden = false;
            // ���Ӑ於
            columns[table.CustomerNameColumn.ColumnName].Hidden = false;
            // ������
            columns[table.DiscountRateColumn.ColumnName].Hidden = false;
            // ������
            columns[table.PriceFlColumn.ColumnName].Hidden = false;
            // �����z
            columns[table.RateValColumn.ColumnName].Hidden = false;
            // ���i�J�n��
            columns[table.PriceStartDateColumn.ColumnName].Hidden = false;
            // ���i�I����
            columns[table.PriceEndDateColumn.ColumnName].Hidden = false;
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note        : �G���[���b�Z�[�W�\������</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                "PMKHN09641UA",						// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PRINTNAME,				        // �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion

        // ===================================================================================== //
        // �e�R���g���[���C�x���g����
        // ===================================================================================== //
        # region Control Event Methods
        /// <summary>
        ///	Form.Load �C�x���g(PMKHN09641U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2011/04/26</br>
        /// </remarks>
        private void PMKHN09641U_Load(object sender, EventArgs e)
        {
            // ��ʏ�����
            InitialScreenSetting();

            this.ultraGrid_DeleteObject.DataSource = this._campaignGoodsDataTable;

            // ��ʏ�����
            this.Clear();
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I��
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        // �I������
                        Close();
                        break;
                    }
                // ����
                case TOOLBAR_SEARCHBUTTON_KEY:
                    {
                        this.Search();
                        break;
                    }
                // �ꊇ�폜����
                case TOOLBAR_UPDATEBUTTON_KEY:
                    {
                        this.DeleteAll();
                        break;
                    }
                // �N���A
                case TOOLBAR_CLEARBUTTON_KEY:
                    {
                        // �N���A����
                        this.Clear();
                        break;
                    }
                // �K�C�h
                case TOOLBAR_GUIDEBUTTON_KEY:
                    {
                        this.ExecuteGuide();
                        break;
                    }
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            this._retKeyFlag = 0;

            if (e.PrevCtrl == null || e.NextCtrl.Name == "ultraExplorerBar1")
            {
                return;
            }

            this._prevControl = e.NextCtrl;

            CampaignGoodsData campaignGoodsDataCurrent = this._campaignGoodsStAcs.CampaignGoodsData;
            if (campaignGoodsDataCurrent == null) return;

            CampaignGoodsData campaignGoodsData = campaignGoodsDataCurrent.Clone();

            switch (e.PrevCtrl.Name)
            {
�@�@�@�@�@�@�@�@// Grid
                case "ultraGrid_DeleteObject":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                if (this.ultraGrid_DeleteObject.ActiveCell != null)
                                {
                                    this.ultraGrid_DeleteObject.ActiveCell.Activate();
                                    e.NextCtrl = null;
                                }
                                if (this.ultraGrid_DeleteObject.ActiveRow != null)
                                {
                                    e.NextCtrl = null;
                                }
                               
                            }
                        }
                        break;
                    
                    }
                // ���_�R�[�h
                case ctGUIDE_NAME_Section:
                    {
                        string code = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');

                        if (string.IsNullOrEmpty(code) || "00".Equals(code))
                        {
                            code = "00";
                            campaignGoodsData.SectionCode = code;
                            campaignGoodsData.SectionName = GetSectionName(code);
                        }

                        // ���͕ύX�Ȃ�
                        if (code.Equals(campaignGoodsData.SectionCode))
                        {
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (string.IsNullOrEmpty(code))
                                    {
                                        e.NextCtrl = this.SectionGuide_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Up)
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    }
                                
                                }

                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Up)
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            
                            }
                            
                           
                            break;
                        }
                        else
                        {
                            // ���͖���
                            if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                            {
                                // �ݒ�l�ۑ��A���̂̃N���A
                                campaignGoodsData.SectionCode = string.Empty;
                                campaignGoodsData.SectionName = string.Empty;

                                // �t�H�[�J�X�ݒ�
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.SectionGuide_Button;
                                }

                                break;
                            }

                            if (!string.IsNullOrEmpty(GetSectionName(code)))
                            {
                                // ���ʂ���ʂɐݒ�
                                campaignGoodsData.SectionCode = code;
                                campaignGoodsData.SectionName = GetSectionName(code);
                            }
                            else
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���_�����݂��܂���B", -1);
                                // ��ʕ\��
                                this.SetDisplay(campaignGoodsData);
                                e.NextCtrl = e.PrevCtrl;
                                return;
                            }
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }
                            
                        }

                        break;
                    }
                // ���_�{�^��
                case "SectionGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = this.SectionGuide_Button;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                            }
                        }
                        break;
                    }

                // ���[�J�[�{�^��
                case "MakerGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                e.NextCtrl = this.tEdit_HGoodsNo;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                if (this.ultraGrid_DeleteObject.Rows.Count > 0)
                                {
                                    this.ultraGrid_DeleteObject.Focus();
                                    this.ultraGrid_DeleteObject.ActiveRow = this.ultraGrid_DeleteObject.Rows[0];
                                    this.ultraGrid_DeleteObject.ActiveRow.Selected = true;
                                    e.NextCtrl = this.ultraGrid_DeleteObject;
                                }
                                else
                                {
                                    e.NextCtrl = this.MakerGuide_Button;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                            }
                        }
                        break;
                    }
                // ���[�J�[
                case ctGUIDE_NAME_GoodsMakerCd:
                    {
                        int code = this.tNedit_GoodsMakerCd.GetInt();
                    
                        // ���͕ύX�Ȃ�
                        if (code == campaignGoodsData.GoodsMakerCd)
                        {
                            
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (code == 0)
                                    {
                                        e.NextCtrl = this.MakerGuide_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = tEdit_HGoodsNo;
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Right && code == 0)
                                    {
                                        e.NextCtrl = this.MakerGuide_Button;
                                    }
                                    else if (e.Key == Keys.Up)
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }

                            break;
                        }
                        else
                        {
                            // ���͖���
                            if (code == 0)
                            {

                                // �ݒ�l�ۑ��A���̂̃N���A
                                campaignGoodsData.GoodsMakerCd = 0;
                                campaignGoodsData.GoodsMakerNm = string.Empty;
                                if (e.ShiftKey == false)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                    {
                                        e.NextCtrl = this.MakerGuide_Button;
                                    }
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    }
                                }


                                break;
                            }

                            if (!string.IsNullOrEmpty(GetGoodsMakerNm(code)))
                            {
                                // ���ʂ���ʂɐݒ�
                                campaignGoodsData.GoodsMakerCd = code;
                                campaignGoodsData.GoodsMakerNm = GetGoodsMakerNm(code);
                            }
                            else
                            {
                                // �Y���Ȃ�
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���[�J�[�����݂��܂���B", -1);
                                // ��ʕ\��
                                this.SetDisplay(campaignGoodsData);
                                e.NextCtrl = e.PrevCtrl;
                                return;
                            }
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tEdit_HGoodsNo;
                                }
                            }
                            else
                            {
                                // �t�H�[�J�X�ݒ�
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }
                        }
                        break;
                    }
                // ���i��
                case ctGUIDE_NAME_HGoodsNo:
                    {
                        campaignGoodsData.HeaderGoodsNo = this.tEdit_HGoodsNo.DataText.Trim();

                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ
                                if (this.ultraGrid_DeleteObject.Rows.Count > 0)
                                {
                                    this.ultraGrid_DeleteObject.Focus();
                                    this.ultraGrid_DeleteObject.ActiveRow = this.ultraGrid_DeleteObject.Rows[0];
                                    this.ultraGrid_DeleteObject.ActiveRow.Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_HGoodsNo;
                                }

                            }
                            if (e.Key == Keys.Down)
                            {
                                if (this.ultraGrid_DeleteObject.Rows.Count > 0)
                                {
                                    this.ultraGrid_DeleteObject.Focus();
                                    this.ultraGrid_DeleteObject.ActiveRow = this.ultraGrid_DeleteObject.Rows[0];
                                    this.ultraGrid_DeleteObject.ActiveRow.Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_HGoodsNo;
                                }
                            }
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tEdit_HGoodsNo;
                            }
                        }
                        else
                        {
                            if (this.tNedit_GoodsMakerCd.Text == "")
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.MakerGuide_Button;
                                }
                                
                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }
                            }
                            
                        }
                        break;
                    }
            }

            this._prevControl = e.NextCtrl;

            // ��������̓��e�Ɣ�r����
            ArrayList arRetList = campaignGoodsData.Compare(campaignGoodsDataCurrent);

            if (arRetList.Count > 0)
            {
                this._campaignGoodsStAcs.CacheCampaignGoodsData(campaignGoodsData);

                // ��ʕ\��
                this.SetDisplay(campaignGoodsData);
            }


            // �K�C�h�{�^���c�[���L�������ݒ菈��
            if ((e.NextCtrl != null) && (e.NextCtrl.TabStop))
            {
                this.SettingGuideButtonToolEnabled(e.NextCtrl);
            }

            this._retKeyFlag = 1;
        }

        /// <summary>
        /// Control.Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �L���b�V������
                CampaignGoodsData campaignGoodsData = this._campaignGoodsStAcs.CampaignGoodsData;

                int status;
                SecInfoSet secInfoSet = new SecInfoSet();

                // ���_�K�C�h�\��
                status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    if (secInfoSet.SectionCode.Trim() != campaignGoodsData.SectionCode)
                    {
                        // ���_�R�[�h
                        campaignGoodsData.SectionCode = secInfoSet.SectionCode.Trim();

                        // ���_����
                        campaignGoodsData.SectionName = secInfoSet.SectionGuideNm.Trim();

                        // ��ʍĕ\��
                        this.SetDisplay(campaignGoodsData);

                        // �L���b�V������
                        this._campaignGoodsStAcs.CacheCampaignGoodsData(campaignGoodsData);
                    }

                    // �t�H�[�J�X�ݒ�
                    this.tNedit_GoodsMakerCd.Focus();
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(MakerGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���[�J�[�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �L���b�V������
                CampaignGoodsData campaignGoodsData = this._campaignGoodsStAcs.CampaignGoodsData;

                int status;
                MakerUMnt makerUMnt = new MakerUMnt();

                // ���[�J�[�K�C�h�\��
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if (makerUMnt.GoodsMakerCd != campaignGoodsData.GoodsMakerCd)
                    {
                        campaignGoodsData.GoodsMakerCd = makerUMnt.GoodsMakerCd;
                        campaignGoodsData.GoodsMakerNm = makerUMnt.MakerName;

                        // ���[�J�[�R�[�h
                        this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                        if (makerUMnt.MakerName.Length > 10)
                        {
                            this.tEdit_MakerNm.Text = makerUMnt.MakerName.Substring(0, 10);
                        }
                        else
                        {
                            this.tEdit_MakerNm.Text = makerUMnt.MakerName;
                        }
                        this.tEdit_HGoodsNo.Focus();
                        this.SettingGuideButtonToolEnabled(this.ActiveControl);
                    }
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �t�H�[�J�X�ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void timer_SetFocus_Tick(object sender, EventArgs e)
        {
            // �t�H�[�J�X�ݒ�
            this.tEdit_SectionCodeAllowZero.Focus();
            this._guideKey = this.tEdit_SectionCodeAllowZero.Name;
            this.SettingGuideButtonToolEnabled(this.ActiveControl);

            this.timer_SetFocus.Enabled = false;
        }

        /// <summary>
        /// �O���b�h�������C�A�E�g�ݒ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A�O���b�h�������C�A�E�g�ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void ultraGrid_DeleteObject_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �O���b�h�񏉊��ݒ菈��
            this.SetGridInitialLayout();

            // �O���b�h��\����\���ݒ菈��
            this.SetGridColVisible();
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h���A�N�e�B�u��ԂŃL�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void ultraGrid_DeleteObject_KeyDown(object sender, KeyEventArgs e)
        {
            int rowIndex;
            int columnIndex;


            if (this.ultraGrid_DeleteObject.ActiveCell == null)
            {
                if (this.ultraGrid_DeleteObject.ActiveRow == null)
                {
                    rowIndex = 0;
                    columnIndex = 0;
                }
                else
                {
                    rowIndex = this.ultraGrid_DeleteObject.ActiveRow.Index;
                    columnIndex = 0;
                }
            }
            else
            {
                rowIndex = this.ultraGrid_DeleteObject.ActiveCell.Row.Index;
                columnIndex = this.ultraGrid_DeleteObject.ActiveCell.Column.Index;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        e.Handled = true;

                        if (rowIndex == 0)
                        {
                            if (this.ultraGrid_DeleteObject.ActiveRow != null)
                            {
                                this.ultraGrid_DeleteObject.ActiveRow.Selected = false;
                                this.ultraGrid_DeleteObject.ActiveRow = null;
                            }
                            this.tEdit_HGoodsNo.Focus();
                        }
                        else
                        {
                            if (this.ultraGrid_DeleteObject.ActiveCell == null)
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex - 1].Activate();
                                this.ultraGrid_DeleteObject.Rows[rowIndex - 1].Selected = true;
                            }
                            else
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex < this.ultraGrid_DeleteObject.Rows.Count - 1)
                        {
                            if (this.ultraGrid_DeleteObject.ActiveCell == null)
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex + 1].Activate();
                                this.ultraGrid_DeleteObject.Rows[rowIndex + 1].Selected = true;
                            }
                            else
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        e.Handled = true;

                        if (rowIndex != 0)
                        {
                            if (columnIndex != 0)
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                            }
                        }
                        else
                        {
                            if (columnIndex != 0)
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                            }
                        }

                        break;
                    }
                case Keys.Right:
                    {
                        e.Handled = true;
                        if (rowIndex != this.ultraGrid_DeleteObject.Rows.Count - 1)
                        {
                            if ((this.ultraGrid_DeleteObject.Rows.Count - 1) < 0)
                            {
                                return;
                            }

                            if (columnIndex != this.ultraGrid_DeleteObject.Rows[rowIndex].Cells["PriceEndDate"].Column.Index)
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex].Cells[columnIndex + 1].Activate();
                            }
                        }
                        else
                        {
                            if (columnIndex != this.ultraGrid_DeleteObject.Rows[rowIndex].Cells["PriceEndDate"].Column.Index)
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex].Cells[columnIndex + 1].Activate();
                            }
                        
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// AfterCellActivate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �v���p�e�B�̒l���ύX���ꂽ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void ultraGrid_DeleteObject_AfterCellActivate(object sender, EventArgs e)
        {
            this.ultraGrid_DeleteObject.ActiveCell.Row.Selected = true;
        }

        /// <summary>
        /// GroupExpanding �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup ���W�J�����O�ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "SearchGroup") ||
                (e.Group.Key == "DeleteObjectGroup") ||
                (e.Group.Key == "ResultSettingGroup"))
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }
        }

        /// <summary>
        /// GroupCollapsing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup ���k�������O�ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "SearchGroup") ||
                (e.Group.Key == "DeleteObjectGroup") ||
                (e.Group.Key == "ResultSettingGroup"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }
        #endregion

        #region �I�t���C����ԃ`�F�b�N����
        /// <summary>				
        /// ���O�I�����I�����C����ԃ`�F�b�N����				
        /// </summary>				
        /// <returns>�`�F�b�N��������</returns>				
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

    }
}