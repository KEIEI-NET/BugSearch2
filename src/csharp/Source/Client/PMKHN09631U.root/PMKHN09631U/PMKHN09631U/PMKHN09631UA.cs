//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/05/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/13  �C�����e : Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^���s���܂��B</br>
    /// <br>Programmer : ���N�n��</br>
    /// <br>Date       : 2011/05/20</br>
    /// <br>UpdateNote : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
    /// </remarks>
    public partial class PMKHN09631UA : Form
    {
        # region Private Constant
        
        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_UPDATEBUTTON_KEY = "ButtonTool_Update";
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guid";
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";
        private const string TOOLBAR_LOGINSECTIONLABLE_KEY = "LabelTool_LoginTitle";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LabelTool_LoginName";

        // �K�C�h����
        private const string ctGUIDE_NAME_Section = "tEdit_SectionCodeAllowZero";
        private const string ctGUIDE_NAME_CampaignCode = "CampaignCode_tNedit";
        private const string ctGUIDE_NAME_GoodsMakerCd = "tNedit_GoodsMakerCd";
        private const string ctGUIDE_NAME_BLGoodsCdSt = "tNedit_BLGoodsCode_St";
        //private const string ctGUIDE_NAME_BLGoodsCdEd = "tNedit_BLGoodsCode_Ed";  // DEL 2011/07/13 

        // �N���X��
        private string ct_PRINTNAME = "�L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^";

        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;					// �X�V�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;					// �K�C�h�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;					// �N���A�{�^��					
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;				// ���O�C���S���Җ���
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;

        private MakerAcs _makerAcs;                        // ���[�J�[�A�N�Z�X�N���X
        private string _enterpriseCode;                    // ��ƃR�[�h
        private DateGetAcs _dateGetAcs;                    // ���t�擾���i
        private int START_FLAG = 0;
        //private int END_FLAG = 1;   // DEL 2011/07/13 
        private BLGoodsCdAcs _blGoodsCdAcs = null;		   // BL�A�N�Z�X�N���X
        private CampaignStAcs _campaignStAcs;              // �L�����y�[���ݒ�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs;              // ���_���ݒ�A�N�Z�X�N���X
        private CampaignGoodsData _campaignGoodsData;
        /// <summary>�L�����y�[���A�N�Z�X�N���X</summary>
        public  CampaignGoodsStAcs _campaignGoodsStAcs=null;
        private string _guideKey;
        private SecInfoAcs _secInfoAcs;
        private Control _prevControl = null;
        private SFCMN00299CA msgForm = null;
        private PMKHN09631UB _PMKHN09631UB = null;
        /// <summary>�L�����y�[�������N���X�g</summary>
        public  ArrayList _campaignLinklist = null;
        private string _pregoodsMakerCd = "";
        private string _pregoodsMakerName = "";
        private string _prebLGoodsCode = "";  // ADD 2011/07/13 
        private string _prebLGoodsName = "";  // ADD 2011/07/13 
        private string _presectionCode = "00";
        private string _presectionName = "�S��";
        private int _retKeyFlag = -1;                       //����t���O

        private string _precampaignCode = "";
        private int _retgraflag = 0;

        # endregion

        // ===================================================================================== //
        // Constructor
        // ===================================================================================== //
        #region�@Constructor

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ���N�n��</br>
        /// <br>Date		: 2011/05/20</br>
        /// </remarks>
        public PMKHN09631UA()
        {
            InitializeComponent();
            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;

            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABLE_KEY];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_UPDATEBUTTON_KEY];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY];

            this._makerAcs = new MakerAcs();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._campaignStAcs = new CampaignStAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._campaignGoodsData = new CampaignGoodsData();
            this._campaignGoodsStAcs = CampaignGoodsStAcs.GetInstance();
            this._dateGetAcs = DateGetAcs.GetInstance();
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._secInfoAcs = new SecInfoAcs();
         
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
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : 2011/05/20</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            this.ToolBarInitilSetting();       // �c�[���o�[�����ݒ菈��
            this.SetGuidButtonIcon();          // �{�^���A�C�R���ݒ�
            this.InitialScreenData();          //������ʃf�[�^�ݒ�
        }

        /// <summary>
        /// ��ʏ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        private void Clear()
        {
            this.InitialScreenData();
            this.CampaignCode_tNedit.Text = string.Empty;
            this.tNedit_GoodsMakerCd.Text = string.Empty;
            this.tEdit_GoodsMakerName.Text = string.Empty;
            this.tEdit_gNoNHyphen.Text = string.Empty;
            this.tEdit_gNoNHyphen.Text = string.Empty;
            //this.tNedit_BLGoodsCode_Ed.Text = string.Empty;  // DEL 2011/07/13 
            this.tEdit_BLGoodsName.Text = string.Empty; // ADD 2011/07/13
            this.tNedit_BLGoodsCode_St.Text = string.Empty;
            this._campaignGoodsStAcs._precampaignLinkList = null;
            this.GoodsRCount_uLabel.Text="0 ��";
            this.CampaignMngAdd_uLabel.Text = "0 ��";
            //this.Initial_Timer.Enabled = true;      // DEL 2011/07/13 
            this.tNedit_GoodsMakerCd.Focus(); 
            //this.ActiveControl = this.tNedit_GoodsMakerCd;  // DEL 2011/07/13 
            this.SettingGuideButtonToolEnabled(this.ActiveControl);
            _pregoodsMakerCd = "";
            _pregoodsMakerName = "";
            _prebLGoodsCode = "";  // ADD 2011/07/13 
            _prebLGoodsName = "";  // ADD 2011/07/13 
            _presectionCode = "00";
            _presectionName = "�S��";
            _precampaignCode = "";
        }

        /// <summary>
        /// ��ʏ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void InitialScreenData()
        {
            this.CampaignName_tEdit.Text = string.Empty;
            this.tEdit_SectionCodeAllowZero.Text = "00";
            this.SectionName_tEdit.Text = "�S��";
            this.CampaignObjDiv_tComboEditor.SelectedIndex = 0;
            this.ApplyStaDate_TDateEdit.SetDateTime(DateTime.Now);
            this.ApplyEndDate_TDateEdit.SetDateTime(DateTime.Now);
            this.CampaignObjDiv_Button.Enabled = false;
            this._campaignLinklist = new ArrayList();
            this._campaignGoodsStAcs._precampaignLinkList = null;
        }

        /// <summary>
        /// �c�[���o�[�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������A�c�[���o�[�����ݒ菈�����s���܂��B</br>
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : 2011/05/20</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
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
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : 2011/05/20</br>
        /// <br>UpdateNote  : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            this.uButton_GoodsMakerCd.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGoodsCdFrm_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            //this.BLGoodsCdTo_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];  // DEL 2011/07/13 
            this.uButton_CampaignCode.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// �a�k�R�[�h�K�C�h�f�[�^�擾����
        /// </summary>
        /// <param name="flag">0:�J�n 1:�I��</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        private void ClickBLGoodsCodeGuide(int flag)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int status;
                BLGoodsCdUMnt blGoodsCdUMnt = null;

                // BL�R�[�h�K�C�h�\��
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    // BL�R�[�h�t���O
                    // ----- UPD 2011/07/13 ------- >>>>>>>>>
                    //if (flag == this.START_FLAG)
                    //{
                        this.tNedit_BLGoodsCode_St.Text=blGoodsCdUMnt.BLGoodsCode.ToString("00000");
                        this.tEdit_BLGoodsName.Text = blGoodsCdUMnt.BLGoodsHalfName;
                        // �t�H�[�J�X�ݒ�
                        //this.tNedit_BLGoodsCode_Ed.Focus();
                        this.CampaignCode_tNedit.Focus();
                    //}
                    //else
                    //{
                    //    this.tNedit_BLGoodsCode_Ed.Text=blGoodsCdUMnt.BLGoodsCode.ToString("00000");
                    //    // �t�H�[�J�X�ݒ�
                    //    this.CampaignCode_tNedit.Focus(); 
                    //}
                    
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);

                    this._prebLGoodsCode = blGoodsCdUMnt.BLGoodsCode.ToString();
                    this._prebLGoodsName = blGoodsCdUMnt.BLGoodsHalfName;
                    // ----- UPD 2011/07/13 ------- <<<<<<<<<
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �{�^���c�[���L�������ݒ菈��
        /// </summary>
        /// <param name="nextControl">���̃R���g���[��</param>
        /// <remarks>
        /// <br>Note		: �{�^���c�[���L�������ݒ菈��</br>
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : 2011/05/20</br>
        /// <br>UpdateNote  : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
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
                || targetControl.Name == ctGUIDE_NAME_CampaignCode
                || targetControl.Name == ctGUIDE_NAME_GoodsMakerCd
                || targetControl.Name == ctGUIDE_NAME_BLGoodsCdSt)
                //|| targetControl.Name == ctGUIDE_NAME_BLGoodsCdEd)  // DEL 2011/07/13 
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
        /// �u�K�C�h�v����
        /// </summary>
        /// <remarks>
        /// <br>Note		:�u�K�C�h�v����</br>
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : 2011/05/20</br>
        /// <br>UpdateNote  : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
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

                case ctGUIDE_NAME_CampaignCode:
                    {
                        this.uButton_CampaignCode_Click(this.uButton_CampaignCode, new EventArgs());
                        break;
                    }

                case ctGUIDE_NAME_GoodsMakerCd:
                    {
                        this.uButton_GoodsMakerCd_Click(this.uButton_GoodsMakerCd, new EventArgs());
                        break;
                    }

                case ctGUIDE_NAME_BLGoodsCdSt:
                    {
                        this.BLGoodsCdFrm_Button_Click(this.BLGoodsCdFrm_Button, new EventArgs());
                        break;
                    }

                // ----- DEL 2011/07/13 ------- >>>>>>>>>
                //case ctGUIDE_NAME_BLGoodsCdEd:
                //    {
                //        this.BLGoodsCdTo_Button_Click(this.BLGoodsCdTo_Button, new EventArgs());
                //        break;
                //    }
                // ----- DEL 2011/07/13 ------- <<<<<<<<<
            }
        }

        /// <summary>
        /// ��ʍX�V�O�`�F�b�N
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        private bool BeforeSearchCheck(int maxRow)
        {
            int yearDif = 0;
            DateGetAcs.CheckDateResult cdResult;

            // ���[�J�[�R�[�h
            if (this._campaignGoodsData.GoodsMakerCd == 0)
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

            // ----- DEL 2011/07/13 ------- >>>>>>>>>
            // �a�k�R�[�h��r
            //if (this._campaignGoodsData.BLGroupCodeSt > this._campaignGoodsData.BLGroupCodeEd && this._campaignGoodsData.BLGroupCodeEd != 0)
            //{
            //    // �Y���Ɍ�肪����܂�
            //    TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
            //                    emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
            //                    this.Name,											// �A�Z���u��ID
            //                    "�a�k�R�[�h�͈̔͂Ɍ�肪����܂��B",                 // �\�����郁�b�Z�[�W
            //                    -1,													// �X�e�[�^�X�l
            //                    MessageBoxButtons.OK);

            //    // �t�H�[�J�X�ݒ�
            //    this.tNedit_BLGoodsCode_St.Focus();
            //    this.SettingGuideButtonToolEnabled(this.ActiveControl);
            //    return false;
            //}
            // ----- DEL 2011/07/13 ------- <<<<<<<<<

            // ----- ADD 2011/07/13 ------- >>>>>>>>>
            // ���i�Ԃ������́A�Ŋ��a�k�R�[�h�������͂ŃG���[
            if (string.IsNullOrEmpty(this._campaignGoodsData.GoodsNoNoneHyphen) && this._campaignGoodsData.BLGoodsCode == 0)
            {
                // �Y���Ɍ�肪����܂�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�i�Ԃ��A�a�k�R�[�h����͂��ĉ������B",                 // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.tEdit_gNoNHyphen.Focus();
                return false;
            }
            // ----- ADD 2011/07/13 ------- <<<<<<<<<

            // �L�����y�[���R�[�h
            if (this._campaignGoodsData.CampaignCode == 0)
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�L�����y�[���R�[�h����͂��ĉ������B",                 // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.CampaignCode_tNedit.Focus();
                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                return false;
            }

            // �Ώۓ��Ӑ悪�ݒ�
            if (maxRow == 0 && CampaignObjDiv_Button.Enabled == true)
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�Ώۓ��Ӑ悪�ݒ肳��Ă��܂���B",                 // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.CampaignObjDiv_Button.Focus();
                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                return false;
            }

            // �Ώۓ��Ӑ悪�ݒ�
            if (this.CampaignObjDiv_tComboEditor.SelectedIndex != 0
                && this.CampaignObjDiv_tComboEditor.SelectedIndex != 1)
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�Ώۓ��Ӑ�敪����͂��ĉ������B",                 // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.CampaignObjDiv_tComboEditor.Focus();
                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                return false;
            }

            // �L�����y�[������
            if (string.IsNullOrEmpty(this._campaignGoodsData.CampaignName))
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�L�����y�[�����̂���͂��ĉ������B",                 // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.CampaignName_tEdit.Focus();
                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                return false;
            }

            // �K�p�J�n��
            if (CallCheckDate(out cdResult, ref this.ApplyStaDate_TDateEdit) == false)
            {
                // ������
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            // �s���l����͎��G��
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�K�p���̓��͂��s���ł��B",                         // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);

                            // �t�H�[�J�X�ݒ�
                            this.ApplyStaDate_TDateEdit.Focus();
                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            // �����͂̏ꍇ�G��
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�K�p���̓��͂��s���ł��B",                         // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);

                            // �t�H�[�J�X�ݒ�
                            this.ApplyStaDate_TDateEdit.Focus();
                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                        }
                        break;
                }
                return false;
            }

            // �K�p�I����
            if (CallCheckDate(out cdResult, ref this.ApplyEndDate_TDateEdit) == false)
            {
                // ������
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            // �s���l����͎��G��
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�K�p���̓��͂��s���ł��B",                         // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);

                            // �t�H�[�J�X�ݒ�
                            this.ApplyEndDate_TDateEdit.Focus();
                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            // �����͂̏ꍇ�G��
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�K�p���̓��͂��s���ł��B",                         // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);

                            // �t�H�[�J�X�ݒ�
                            this.ApplyEndDate_TDateEdit.Focus();
                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                        }
                        break;
                }
                return false;
            }

            // �K�p���̓���
            if (this.ApplyStaDate_TDateEdit.GetLongDate() > this.ApplyEndDate_TDateEdit.GetLongDate())
            {
                // �J�n���I��
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�K�p���̓��͂��s���ł��B",                         // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.ApplyStaDate_TDateEdit.Focus();
                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                return false;
            }
            yearDif = this.ApplyEndDate_TDateEdit.GetLongDate() - this.ApplyStaDate_TDateEdit.GetLongDate();

            // �K�p���͈̔�
            if (yearDif >= 10000)
            {
                // �J�n���I��
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�K�p���͈̔͂͂P�N�ȓ��œ��͂��ĉ������B",                         // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.ApplyStaDate_TDateEdit.Focus();
                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                return false;
            }

            return true;
        }


        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdResult"></param>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit)
        {
            cdResult = this._dateGetAcs.CheckDate(ref targetDateEdit, false);
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_���� ���Y��������̂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // �S�Ћ��ʃ`�F�b�N
            if (sectionCode.Trim().PadLeft(2, '0') == "00")
            {
                sectionName = "�S��";
                this.tEdit_SectionCodeAllowZero.Text = "00";
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
                sectionName = null;
            }
            catch
            {
                sectionName = null;
            }

            return sectionName;
        }

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[���� ���Y��������̂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        private string GetCoodsMaker(string goodsMakerCd)
        {
            string CoodsMakerName = string.Empty;
            MakerUMnt makerUMnt;
            try
            {
                int status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, Convert.ToInt32(goodsMakerCd));
                if (status == 0 && makerUMnt.LogicalDeleteCode == 0)
                {
                    // ���ʃZ�b�g
                    CoodsMakerName = makerUMnt.MakerName;
                }
                else
                {
                    // ���ʃZ�b�g
                    CoodsMakerName = null;
                }
            }
            catch
            {
                CoodsMakerName = null;
            }

            return CoodsMakerName;
        }

        /// <summary>
        /// BL�R�[�h���̎擾����
        /// </summary>
        /// <param name="blGoodsCd">BL�R�[�h</param>
        /// <returns>BL�R�[�h���� ���Y��������̂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h���̂��擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        private string GetBLGoodsName(string blGoodsCd)
        {
            string BLGoodsName = string.Empty;
            BLGoodsCdUMnt blGoodsCdUMnt = null;

            int status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, Convert.ToInt32(blGoodsCd));
            if (status == 0)
            {
                // ���ʃZ�b�g
                BLGoodsName = blGoodsCdUMnt.BLGoodsName;
            }
            else
            {
                // ���ʃZ�b�g
                BLGoodsName = null;
            }
            return BLGoodsName;
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note        : �G���[���b�Z�[�W�\������</br>
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : 2011/05/20</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                "PMKHN09631UA",						// �A�Z���u���h�c�܂��̓N���X�h�c
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
        ///	Form.Load �C�x���g(PMKHN09631U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer	: ���N�n��</br>
        /// <br>Date		: 2011/05/20</br>
        /// <br>UpdateNote  : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        private void PMKHN09631UA_Load(object sender, EventArgs e)
        {
            // ��ʏ�����
            InitialScreenSetting();

            this.Initial_Timer.Enabled = true; // ADD 2011/07/13 
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
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
                // �X�V
                case TOOLBAR_UPDATEBUTTON_KEY:
                    {
                        this.DataUpdate();
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
        /// Control.Click �C�x���g(uButton_GoodsMakerCd)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�K�C�h���N�b���N���ɔ������܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void uButton_GoodsMakerCd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt makerUMnt;
                
                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    // ���ʃZ�b�g
                    this.tNedit_GoodsMakerCd.Text=makerUMnt.GoodsMakerCd.ToString("0000");
                    this.tEdit_GoodsMakerName.Text = makerUMnt.MakerName;

                    // �t�H�[�J�X�ݒ�
                    this.tEdit_gNoNHyphen.Focus();

                    SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        ///Control.Click �C�x���g(BLGoodsCdFrm_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h���N�b���N���ɔ������܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void BLGoodsCdFrm_Button_Click(object sender, EventArgs e)
        {
            // �a�k�R�[�h�K�C�h�f�[�^�擾����
            this.ClickBLGoodsCodeGuide(START_FLAG);
        }

        // ----- DEL 2011/07/13 ------- >>>>>>>>>
        /// <summary>
        /// Control.Click �C�x���g(BLGoodsCdTo_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�I���K�C�h���N�b���N���ɔ������܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        //private void BLGoodsCdTo_Button_Click(object sender, EventArgs e)
        //{
        //    // �a�k�R�[�h�K�C�h�f�[�^�擾����
        //    this.ClickBLGoodsCodeGuide(END_FLAG);
        //}
        // ----- DEL 2011/07/13 ------- <<<<<<<<<

        /// <summary>
        /// Control.Click �C�x���g(uButton_CampaignCode)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �L�����y�[���R�[�h�K�C�h���N�b���N���ɔ������܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void uButton_CampaignCode_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CampaignSt campaignSt;

                // �K�C�h�N��
                int status = _campaignStAcs.ExecuteGuid(this._enterpriseCode,  out campaignSt);

                if (status == 0)
                {
                    if (this._precampaignCode != Convert.ToInt32(campaignSt.CampaignCode).ToString().Trim())
                    {
                        this._precampaignCode = this.CampaignCode_tNedit.GetInt().ToString().Trim();
                        // ���ʃZ�b�g
                        this.CampaignCode_tNedit.Text = campaignSt.CampaignCode.ToString("000000");
                        this.CampaignName_tEdit.Text = campaignSt.CampaignName;

                        campaignSt.EnterpriseCode = this._enterpriseCode;
                        campaignSt.CampaignCode = this.CampaignCode_tNedit.GetInt();
                        status = this._campaignGoodsStAcs.SearchCampaignSt(ref campaignSt);

                        if (status == 0)
                        {
                            this.CampaignName_tEdit.Text = campaignSt.CampaignName;
                            this.CampaignObjDiv_tComboEditor.SelectedIndex = campaignSt.CampaignObjDiv;
                            this.ApplyStaDate_TDateEdit.SetDateTime(campaignSt.ApplyStaDate);
                            this.ApplyEndDate_TDateEdit.SetDateTime(campaignSt.ApplyEndDate);
                            this.tEdit_SectionCodeAllowZero.Text = campaignSt.SectionCode.ToString().Trim();
                            this.SectionName_tEdit.Text = GetSectionName(campaignSt.SectionCode);

                            status = this._campaignGoodsStAcs.SearchCustomer(this.CampaignCode_tNedit.GetInt());

                            if (status == 0)
                            {
                                this._campaignLinklist = new ArrayList();

                                this._campaignLinklist = this._campaignGoodsStAcs._precampaignLinkList;
                            }
                            else
                            {
                                this._campaignLinklist = new ArrayList();

                                this._campaignGoodsStAcs._precampaignLinkList = null;
                            }
                        }

                    }

                    // �t�H�[�J�X�ݒ�
                    this.CampaignName_tEdit.Focus(); 
                    SettingGuideButtonToolEnabled(this.ActiveControl);
                }

                this._precampaignCode = this.CampaignCode_tNedit.GetInt().ToString().Trim();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Butto)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSet secInfoSet = new SecInfoSet();

                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();
                    // �t�H�[�J�X�ݒ�
                    this.CampaignObjDiv_tComboEditor.Focus();

                    SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(CampaignObjDiv_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : CampaignObjDiv_Button���N�b���N���ɔ������܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void CampaignObjDiv_Button_Click(object sender, EventArgs e)
        {
            //���Ӑ�ݒ��ʂ��J����
            this._PMKHN09631UB = new PMKHN09631UB();

            this._PMKHN09631UB.ShowDialog();
        }

        /// <summary>
        /// SelectionChanged �C�x���g(CampaignObjDiv_tComboEditor)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : SelectionChanged�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void CampaignObjDiv_tComboEditor_SelectionChanged(object sender, EventArgs e)
        {
            if (this.CampaignObjDiv_tComboEditor.SelectedIndex == 1)
            {
                this.CampaignObjDiv_Button.Enabled = true;
            }
            else
            {
                this.CampaignObjDiv_Button.Enabled = false;
            }

        }

        private void msgForm_CancelButtonClick(object sender, EventArgs e)
        {
            this._campaignGoodsStAcs.ExtractCancelFlag = true;
            // ���o�L�����Z��
            if (this.msgForm != null)
            {
                this.msgForm.Message = "���f���܂��B";
            }
        }

        /// <summary>
        /// ��ʍX�V
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        private void DataUpdate()
        {
            int readCount = 0;
            int addCount = 0;
            int maxRow = 0;
            this._retgraflag = 1;

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            this._campaignGoodsStAcs.ExtractCancelFlag = false;

            // �m�F���b�Z�[�W��\������B
            DialogResult result = TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,             // �G���[���x��
                        "PMKHN09631UA",						            // �A�Z���u���h�c�܂��̓N���X�h�c
                        ct_PRINTNAME,				                    // �v���O��������
                        "", 								            // ��������
                        "",									            // �I�y���[�V����
                        "�ꊇ�o�^�������J�n���Ă���낵���ł����H",		// �\�����郁�b�Z�[�W
                        -1, 							                // �X�e�[�^�X�l
                        null, 								            // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.YesNo, 				        // �\������{�^��
                        MessageBoxDefaultButton.Button1);	            // �����\���{�^��
            // ���͉�ʂ֖߂�B
            if (result == DialogResult.No)
            {
                return;
            }

            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʍX�V�����Ɏ��s���܂����B",
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

            //this._campaignGoodsData.BLGroupCodeSt = this.tNedit_BLGoodsCode_St.GetInt();  // DEL 2011/07/13
            this._campaignGoodsData.BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();      // ADD 2011/07/13
            //this._campaignGoodsData.BLGroupCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();  // DEL 2011/07/13 
            this._campaignGoodsData.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            this._campaignGoodsData.GoodsNoNoneHyphen = this.tEdit_gNoNHyphen.Text.ToString().Trim();
            this._campaignGoodsData.EnterpriseCode = this._enterpriseCode.ToString().Trim();
            this._campaignGoodsData.CampaignCode = this.CampaignCode_tNedit.GetInt();
            this._campaignGoodsData.SectionCode = this.tEdit_SectionCodeAllowZero.Text.ToString().Trim();
            this._campaignGoodsData.CampaignName = this.CampaignName_tEdit.Text.ToString().Trim();
            this._campaignGoodsData.CampaignObjDiv = Convert.ToInt32(this.CampaignObjDiv_tComboEditor.Value);
            this._campaignGoodsData.ApplyStaDate = this.ApplyStaDate_TDateEdit.GetLongDate();
            this._campaignGoodsData.ApplyEndDate = this.ApplyEndDate_TDateEdit.GetLongDate();


            if (this._campaignGoodsStAcs._precampaignLinkList == null)
            {
                maxRow = 0;
            }
            else
            {
                maxRow=this._campaignGoodsStAcs._precampaignLinkList.Count;
            }

            // �`�F�b�N
            bool isUpdate = this.BeforeSearchCheck(maxRow);

            if (!isUpdate)
            {
                return;
            }

            // ���o����ʕ��i�̃C���X�^���X���쐬
            msgForm = new SFCMN00299CA();
            msgForm.Title = "���o����";
            msgForm.Message = "���݁A�f�[�^���o���ł��B(ESC�Œ��f���܂�)��n���΂炭���҂���������";
            msgForm.DispCancelButton = true;
            msgForm.CancelButtonClick += new EventHandler(msgForm_CancelButtonClick);
          
            try
            {
                msgForm.Show();
                // ����
                if (this._campaignGoodsStAcs.ExtractCancelFlag == false)
                {
                    status = this._campaignGoodsStAcs.SearchData(_campaignGoodsData,this._campaignLinklist, ref readCount, ref addCount);
                }
                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        if (this._campaignGoodsStAcs.ExtractCancelFlag == false)
                        {
                            this.GoodsRCount_uLabel.Text = readCount.ToString("N0") + " " + "��";
                            this.CampaignMngAdd_uLabel.Text = addCount.ToString("N0") + " " + "��";
                        }

                        break;

                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        if (this._campaignGoodsStAcs.ExtractCancelFlag == false)
                        {
                            // 0���G���[
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^�����݂��܂���B", 0);
                        }

                        break;

                    default:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�X�V�Ɏ��s���܂����B", -1);
                        this.GoodsRCount_uLabel.Text = "0 " + "��";
                        this.CampaignMngAdd_uLabel.Text = "0 " + "��";
                        break;
                }
            }
            finally
            {
                msgForm.Close();
            }

            this._campaignLinklist = new ArrayList();

            this._campaignLinklist = this._campaignGoodsStAcs._precampaignLinkList;

            this.SettingGuideButtonToolEnabled(this.ActiveControl);
        }

        /// <summary>
        /// �t�H�[�J�X�ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // �t�H�[�J�X�ݒ�
            this.tNedit_GoodsMakerCd.Focus();
            this._guideKey = this.tNedit_GoodsMakerCd.Name;

            this.SettingGuideButtonToolEnabled(this.ActiveControl);

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            this._retKeyFlag = 0;

            if (e.PrevCtrl == null || e.NextCtrl.Name == "ultraExplorerBar1")
            {
                return;
            }

           
            this._prevControl = e.NextCtrl;

            switch (e.PrevCtrl.Name)
            {
                // ���[�J�[�R�[�h�K�C�h�{�^��
                case "uButton_GoodsMakerCd":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.uButton_GoodsMakerCd;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = this.uButton_GoodsMakerCd;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = this.tEdit_gNoNHyphen;
                            }
                            
                        }
                      
                        break;
                    }


                // ----- DEL 2011/07/13 ------- >>>>>>>>>
                // Goods�R�[�h�I���K�C�h�{�^��
                //case "BLGoodsCdTo_Button":
                //    {
                //        if (e.ShiftKey == false)
                //        {
                //            if (e.Key == Keys.Right)
                //            {
                //                e.NextCtrl = this.BLGoodsCdTo_Button;
                //            }
                //            else if (e.Key == Keys.Down)
                //            {
                //                e.NextCtrl = this.uButton_CampaignCode;
                //            }
                //            else if (e.Key == Keys.Up)
                //            {
                //                e.NextCtrl = this.tEdit_gNoNHyphen;
                //            }
                //        }

                //        break;
                //    }
                // ----- DEL 2011/07/13 ------- <<<<<<<<<

                // ----- ADD 2011/07/13 ------- >>>>>>>>>
                // Goods�R�[�h�J�n�K�C�h�{�^��
                case "BLGoodsCdFrm_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.BLGoodsCdFrm_Button;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = this.uButton_CampaignCode;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = this.tEdit_gNoNHyphen;
                            }
                        }

                        break;
                    }
                // ----- ADD 2011/07/13 ------- <<<<<<<<<


                // �L�����y�[���R�[�h�K�C�h�{�^��
                case "uButton_CampaignCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.uButton_CampaignCode;
                            }
                            else if(e.Key == Keys.Up)
                            {
                                // ----- UPD 2011/07/13 ------- <<<<<<<<<
                                //e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                                e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                // ----- UPD 2011/07/13 ------- >>>>>>>>>
                            }


                        }

                        break;
                    }

                // ���_�R�[�h�K�C�h�{�^��
                case "SectionGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.SectionGuide_Button;
                            }
                            if (e.Key == Keys.Down && this.CampaignObjDiv_Button.Enabled == false)
                            {
                                e.NextCtrl = this.CampaignObjDiv_tComboEditor;
                            }

                        }

                        break;
                    }

                // �L�����y�[������
                case "CampaignName_tEdit":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Down) && e.NextCtrl.Name != "_PMKHN09631UA_Toolbars_Dock_Area_Top")
                            {
                                if (this._retgraflag != 1)
                                {
                                    this._retgraflag = 0;
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = this.CampaignCode_tNedit;
                            }
                            
                        }
                        else
                        {
                            // ���͖���
                            if (string.IsNullOrEmpty(this.CampaignCode_tNedit.Text.Trim()))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.uButton_CampaignCode;
                                }
                           
                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.CampaignCode_tNedit;
                                }

                            }
                        }
                     
                        break;
                    }
                // ���_�R�[�h
                case ctGUIDE_NAME_Section:
                    {

                        // ���_�R�[�h�擾
                        string sectionCode = this.tEdit_SectionCodeAllowZero.DataText;
                        // ���_���̎擾
                        string sectionName = GetSectionName(sectionCode);

                        int code = 0;
                        try
                        {
                            code = Convert.ToInt32(sectionCode);

                        }
                        catch
                        {
                            code = 0;
                        }

                        if (code == 0)
                        {
                            this.tEdit_SectionCodeAllowZero.Text = "00";
                            this.SectionName_tEdit.Text = "�S��";
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(sectionName))
                            {
                                this.SectionName_tEdit.Text = sectionName;
                            }
                            else if (sectionName == null)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "���_�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK
                                );
                                this.tEdit_SectionCodeAllowZero.Text = this._presectionCode;
                                this.SectionName_tEdit.Text = this._presectionName;
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                e.NextCtrl.Select();
                                return;
                            }
                        
                        }

                        this._presectionName = this.SectionName_tEdit.Text;
                        this._presectionCode = this.tEdit_SectionCodeAllowZero.Text.ToString().Trim();
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.SectionName_tEdit.DataText.Trim() != "")
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.CampaignObjDiv_tComboEditor;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.SectionName_tEdit.DataText.Trim() != "")
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.CampaignName_tEdit;
                                }
                            }
                        }
                        break;
                    }
                // ���[�J�[�R�[�h
                case ctGUIDE_NAME_GoodsMakerCd:
                    {
                        // ���[�J�[�R�[�h�擾
                        string goodsMakerCd = this.tNedit_GoodsMakerCd.DataText;

                        int code = this.tNedit_GoodsMakerCd.GetInt();

                        if (code == 0)
                        {
                            this.tNedit_GoodsMakerCd.Text = string.Empty;
                            this.tEdit_GoodsMakerName.Text = string.Empty;
                        }
                        else
                        {
                            // ���[�J�[���̎擾
                            string goodsMakerName = GetCoodsMaker(goodsMakerCd);
                            if (!string.IsNullOrEmpty(goodsMakerName))
                            {
                                this.tNedit_GoodsMakerCd.Text = goodsMakerCd;
                                this.tEdit_GoodsMakerName.Text = goodsMakerName;
                            }
                            else
                            {
                                if (goodsMakerName == null)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "���[�J�[�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK
                                    );
                                    this.tNedit_GoodsMakerCd.Text = this._pregoodsMakerCd;
                                    this.tEdit_GoodsMakerName.Text = this._pregoodsMakerName;
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    e.NextCtrl.Select();
                                    return;
                                }

                            } 
                        }
                      
                        this._pregoodsMakerCd = this.tNedit_GoodsMakerCd.Text.ToString().Trim();
                        this._pregoodsMakerName = this.tEdit_GoodsMakerName.Text.ToString().Trim();

                        if (e.ShiftKey == false)
                        {

                            // ���͖���
                            if (string.IsNullOrEmpty(this.tNedit_GoodsMakerCd.Text.Trim()))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab )
                                {
                                    e.NextCtrl = this.uButton_GoodsMakerCd;
                                }
                                else if (e.Key == Keys.Up)
                                {
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    if (this._retgraflag != 1)
                                    {
                                        this._retgraflag = 0;
                                        e.NextCtrl = this.tEdit_gNoNHyphen;
                                    }
                                }
                                else if (e.Key == Keys.Up)
                                {
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }

                            }
                        }
                        else
                        {
                            e.NextCtrl = this.ApplyEndDate_TDateEdit;
                        }

                        if (this.tNedit_GoodsMakerCd.Text != "")
                        {
                            this.tNedit_GoodsMakerCd.Text = this.tNedit_GoodsMakerCd.GetInt().ToString("0000");
                        }

                        break;
                    }

                // BL�R�[�h�J�n
                case ctGUIDE_NAME_BLGoodsCdSt:
                    {
                        // BL�R�[�h�擾
                        // ----- UPD 2011/07/13 ------- >>>>>>>>>
                        //string blGoodsCd = this.tNedit_BLGoodsCode_St.Text;
                        int blGoodsCd = this.tNedit_BLGoodsCode_St.GetInt();

                        //if (blGoodsCd == "")
                        if (blGoodsCd == 0)
                        {
                            this.tNedit_BLGoodsCode_St.Clear();
                            this.tEdit_BLGoodsName.Clear(); 
                        }
                        else
                        {
                            BLGoodsCdUMnt blGoodsCdUMnt = null;
                            // BL�R�[�h�\��
                            int status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, blGoodsCd);

                            if (status == 0)
                            {
                                this.tEdit_BLGoodsName.Text = blGoodsCdUMnt.BLGoodsHalfName;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "BL�R�[�h�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK
                                );
                                this.tNedit_BLGoodsCode_St.Text = this._prebLGoodsCode;
                                this.tEdit_BLGoodsName.Text = this._prebLGoodsName;
                                e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                e.NextCtrl.Select();
                                break;
                            }
                        }

                        this._prebLGoodsCode = this.tNedit_BLGoodsCode_St.Text.Trim();
                        this._prebLGoodsName = this.tEdit_BLGoodsName.Text.Trim();
                        // ----- UPD 2011/07/13 ------- <<<<<<<<<

                        if (e.ShiftKey == false)
                        {
                            // ���͖���
                            if (string.IsNullOrEmpty(this.tNedit_BLGoodsCode_St.Text.Trim()))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.BLGoodsCdFrm_Button;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ----- UPD 2011/07/13 ------- <<<<<<<<<
                                    //e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                                    e.NextCtrl = this.CampaignCode_tNedit;
                                    // ----- UPD 2011/07/13 ------- >>>>>>>>>
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_gNoNHyphen;
                            }
                        }

                        if (this.tNedit_BLGoodsCode_St.Text != "")
                        {
                            this.tNedit_BLGoodsCode_St.Text = this.tNedit_BLGoodsCode_St.GetInt().ToString("000000");
                        }
                        break;
                    }

                // ----- DEL 2011/07/13 ------- >>>>>>>>>
                // BL�R�[�h�I��
                //case ctGUIDE_NAME_BLGoodsCdEd:
                //    {
                //        // BL�R�[�h�擾
                //        string blGoodsCd = this.tNedit_BLGoodsCode_Ed.Text;
                //        if (blGoodsCd == "")
                //        {
                //            this.tNedit_BLGoodsCode_Ed.Clear();
                //        }

                //        if (e.ShiftKey == false)
                //        {
                //            // ���͖���
                //            if (string.IsNullOrEmpty(this.tNedit_BLGoodsCode_Ed.Text.Trim()))
                //            {
                //                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                //                {
                //                    e.NextCtrl = this.BLGoodsCdTo_Button;
                //                }
                //            }
                //            else
                //            {
                //                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                //                {
                //                    e.NextCtrl = this.CampaignCode_tNedit;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            // ���͖���
                //            if (string.IsNullOrEmpty(this.tNedit_BLGoodsCode_St.Text.Trim()))
                //            {
                //                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                //                {
                //                    e.NextCtrl = this.BLGoodsCdFrm_Button;
                //                }
                //            }
                //            else
                //            {
                //                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                //                {
                //                    e.NextCtrl = this.tNedit_BLGoodsCode_St;
                //                }
                //            }
                //        }

                //        if (e.ShiftKey == false)
                //        {
                //            if (e.Key == Keys.Down)
                //            {
                //                e.NextCtrl = this.uButton_CampaignCode;
                //            }
                //        }

                //        if (this.tNedit_BLGoodsCode_Ed.Text != "")
                //        {
                //            this.tNedit_BLGoodsCode_Ed.Text = this.tNedit_BLGoodsCode_Ed.GetInt().ToString("000000");
                //        }
                //        break;
                //    }
                // ----- DEL 2011/07/13 ------- <<<<<<<<<

                //�@�L�����y�[���R�[�h
                case ctGUIDE_NAME_CampaignCode:
                    {
                        if (this.CampaignCode_tNedit.Text.ToString() != string.Empty)
                        {
                            int status = 0;
                            CampaignSt campaignSt = new CampaignSt();
                            campaignSt.EnterpriseCode = this._enterpriseCode;
                            campaignSt.CampaignCode = this.CampaignCode_tNedit.GetInt();
                            status = this._campaignGoodsStAcs.SearchCampaignSt(ref campaignSt);
                            if (status == 0)
                            {

                                if (this._precampaignCode != this.CampaignCode_tNedit.GetInt().ToString().Trim())
                                {
                                    this.CampaignName_tEdit.Text = campaignSt.CampaignName;
                                    this.CampaignObjDiv_tComboEditor.SelectedIndex = campaignSt.CampaignObjDiv;
                                    this.ApplyStaDate_TDateEdit.SetDateTime(campaignSt.ApplyStaDate);
                                    this.ApplyEndDate_TDateEdit.SetDateTime(campaignSt.ApplyEndDate);
                                    this.tEdit_SectionCodeAllowZero.Text = campaignSt.SectionCode.ToString().Trim();
                                    // ���_���̎擾
                                    this.SectionName_tEdit.Text = GetSectionName(campaignSt.SectionCode);
                                }
                                
                            }
                            else
                            {
                                if (this._precampaignCode != this.CampaignCode_tNedit.GetInt().ToString().Trim())
                                {
                                    InitialScreenData();
                                }
                            }

                            if (this._precampaignCode != this.CampaignCode_tNedit.GetInt().ToString().Trim())
                            {
                                status = this._campaignGoodsStAcs.SearchCustomer(this.CampaignCode_tNedit.GetInt());

                                if (status == 0)
                                {
                                    this._campaignLinklist = new ArrayList();

                                    this._campaignLinklist = this._campaignGoodsStAcs._precampaignLinkList;
                                }
                                else
                                {
                                    this._campaignLinklist = new ArrayList();
                                    this._campaignGoodsStAcs._precampaignLinkList = null;
                                }
                            }
                        }
                        else
                        {
                            InitialScreenData();
                        }

                        this._precampaignCode = this.CampaignCode_tNedit.GetInt().ToString().Trim();

                        if (e.ShiftKey == false)
                        {
                            // ���͖���
                            if (string.IsNullOrEmpty(this.CampaignCode_tNedit.Text.Trim()))
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (this._retgraflag != 1)
                                    {
                                        this._retgraflag = 0;
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.uButton_CampaignCode;
                                    }
                                   
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (this._retgraflag != 1)
                                    {
                                        this._retgraflag = 0;
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.CampaignName_tEdit;
                                    } 
                                }
                            }
                        }
                        else
                        {
                            // ���͖���
                            // ----- UPD 2011/07/13 ------- >>>>>>>>>
                            //if (string.IsNullOrEmpty(this.tNedit_BLGoodsCode_Ed.Text.Trim()))
                            if (string.IsNullOrEmpty(this.tNedit_BLGoodsCode_St.Text.Trim()))
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // �t�H�[�J�X�ݒ�
                                    //e.NextCtrl = this.BLGoodsCdTo_Button;
                                    e.NextCtrl = this.BLGoodsCdFrm_Button;
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // �t�H�[�J�X�ݒ�
                                    //e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                                    e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                }
                            }
                            // ----- UPD 2011/07/13 ------- <<<<<<<<<
                        }
                        if (this.CampaignCode_tNedit.Text != "")
                        {
                            this.CampaignCode_tNedit.Text = this.CampaignCode_tNedit.GetInt().ToString("000000");
                            if (this.CampaignCode_tNedit.GetInt() == 0)
                            {
                                this.CampaignCode_tNedit.Text = "";
                            }
                        }
                        break;
                    }
                
                //�Ώۓ��Ӑ�ݒ� 
                case "CampaignObjDiv_tComboEditor":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                e.NextCtrl = this.ApplyStaDate_TDateEdit;
                            }
                            else if (e.Key == Keys.Right && this.CampaignObjDiv_Button.Enabled == false)
                            {
                                e.NextCtrl = this.CampaignObjDiv_tComboEditor;
                            }

                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                            }

                        }

                        break;
                    }

                // �K�p���J�n
                case "ApplyStaDate_TDateEdit":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                e.NextCtrl = this.ApplyEndDate_TDateEdit;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                e.NextCtrl = this.CampaignObjDiv_tComboEditor;
                            }

                        }
                        break;
                    }
                // �K�p���I��  
                case "ApplyEndDate_TDateEdit":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                            }
                            else if (e.Key == Keys.Up && this.CampaignObjDiv_Button.Enabled == false)
                            {
                                e.NextCtrl = this.CampaignObjDiv_tComboEditor;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                e.NextCtrl = this.ApplyStaDate_TDateEdit;
                            }

                        }
                        break;
                    }
                //�@���i��
                case "tEdit_gNoNHyphen":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Down)
                            {
                                e.NextCtrl = this.tNedit_BLGoodsCode_St;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tEdit_gNoNHyphen;
                            }
                        }
                        else
                        {
                            // ���͖���
                            if (string.IsNullOrEmpty(this.tNedit_GoodsMakerCd.Text.Trim()))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.uButton_GoodsMakerCd;
                                }
                            }
                            else
                            {
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                            }
                        }

                        break;
                    }
                    
            }

            this._prevControl = e.NextCtrl;

            // �K�C�h�{�^���c�[���L�������ݒ菈��
            if ((e.NextCtrl != null) && (e.NextCtrl.TabStop) && this._retgraflag == 0)
            {
                this.SettingGuideButtonToolEnabled(e.NextCtrl);
            }

            this._retgraflag = 0;
            this._retKeyFlag = 1;
        }

        /// <summary>
        /// GroupCollapsing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup ���k�������O�ɔ������܂��B</br>
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : 2011/05/20</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "SearchGroup") ||
                (e.Group.Key == "SetContestGroup") ||
                (e.Group.Key == "ResultSettingGroup"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }

        /// <summary>
        /// GroupExpanding �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup ���W�J�����O�ɔ������܂��B</br>
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : 2011/05/20</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "SearchGroup") ||
                (e.Group.Key == "SetContestGroup") ||
                (e.Group.Key == "ResultSettingGroup"))
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }
        }

        # endregion

        #region �� �I�t���C����ԃ`�F�b�N����
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