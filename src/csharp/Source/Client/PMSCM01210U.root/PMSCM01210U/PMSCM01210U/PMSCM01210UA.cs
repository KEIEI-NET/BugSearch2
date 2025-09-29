//****************************************************************************//
// �V�X�e��         : PM.NS                                                   //
// �v���O��������   : ����f�[�^���o����                                      //
// �v���O�����T�v   : ����f�[�^���o����                                      //
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.                       //
//============================================================================//
// ����                                                                       //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� :  ���e                                     //
// �� �� ��  2011/07/29  �C�����e : �V�K�쐬                                  //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� :                                           //
// �C �� ��              �C�����e :                                           //
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
using System.IO;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// ����f�[�^���o�����t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^���o�������s���܂��B</br>
    /// <br>Programmer : ���e</br>
    /// <br>Date       : 2011/07/29</br>
    /// </remarks>
    public partial class PMSCM01210UA : Form
    {

        # region << Private Members >>

        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_UPDATEBUTTON_KEY = "ButtonTool_Update";

        private const string TOOLBAR_LOGINSECTIONLABLE_KEY = "LabelTool_LoginTitle";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LabelTool_LoginName";

        private const int INIT_MODE = 0;
        private const int SEARCH_MODE = 1;

        private string CT_PGID = "PMSCM01210U";             // �N���X��

        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;           // �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;          // �X�V�{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;        // ���O�C���S����Title
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;         // ���O�C���S���Җ���

        private string _enterpriseCode;                     //��ƃR�[�h
        private string _sectionCode;                        //���_�R�[�h

        private SecInfoAcs _secInfoAcs;                     // ���_���A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = null;        // ���_�A�N�Z�X�N���X

        private InpDisplay _inpDisplay;                     //��ʃf�[�^�N���X
        private SndAndRcvProcAcs _sndAndRcvProcAcs;         //��������M�o�b�`�A�N�Z�X�N���X

        private PM7RkSettingAcs _pM7RkSettingAcs;           //PM7�A�g�S�̐ݒ�A�N�Z�X�N���X
        private PM7RkSetting _pM7RkSetting;                 //PM7�A�g�S�̐ݒ�}�X�^

        private DateGetAcs _dateGet;

        private InpDisplay _para;

        private SalesSlipSearchAcs _salesSlipSearchAcs;

        private SFCMN00299CA _progressForm;

        # endregion

        #region << Constructor >>

        /// <summary>
        /// ����f�[�^���o�����t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ����f�[�^���o�����t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ���e</br>
        /// <br>Date		: 2011/07/29</br>
        /// </remarks>
        public PMSCM01210UA()
        {
            InitializeComponent();

            //��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //���_�R�[�h�擾
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._secInfoSetAcs = new SecInfoSetAcs();
            this._secInfoAcs = new SecInfoAcs();

            //��������M�o�b�`�A�N�Z�X�N���X
            this._sndAndRcvProcAcs = new SndAndRcvProcAcs();
            //��ʃf�[�^�N���X
            this._inpDisplay = new InpDisplay();
            //PM7�A�g�S�̐ݒ�A�N�Z�X�N���X
            this._pM7RkSettingAcs = new PM7RkSettingAcs();

            //PM7�A�g�S�̐ݒ�}�X�^
            this._pM7RkSetting = new PM7RkSetting();
            this._pM7RkSetting.EnterpriseCode = this._enterpriseCode;
            this._pM7RkSetting.SectionCode = this._sectionCode;

            this._para = new InpDisplay();

            this._salesSlipSearchAcs = new SalesSlipSearchAcs();
        }

        #endregion

        #region << Private Methods >>

        /// <summary>
        /// ������ʐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������ɔ������܂��B</br>      
        /// <br>Programmer  : ���e</br>
        /// <br>Date        : 2011/07/29</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            SectionSt_DirGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            SectionSt_DirGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            SectionEd_DirGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            SectionEd_DirGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;

            CustomerSt_DirGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            CustomerSt_DirGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            CustomerEd_DirGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            CustomerEd_DirGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;

            TextSaveFolder_DirGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            TextSaveFolder_DirGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            
            // �c�[���o�[�����ݒ菈��
            this.ToolBarInitilSetting();
        }

        /// <summary>
        /// �c�[���o�[�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������A�c�[���o�[�����ݒ菈�����s���܂��B</br>
        /// <br>Programmer  : ���e</br>
        /// <br>Date        : 2011/07/29</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�X�V����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N���X�V�������s���B</br>
        /// <br>Programmer : ���e</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private bool UpdateProc()
        {
            bool result = false;

            Control control = null;
            string errorMessage = "";
            if (this.ScreenDataCheck(ref control, ref errorMessage) == false)
            {
                // ���̓`�F�b�N
                TMsgDisp.Show(
                    this,                                  // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO,    // �G���[���x��
                    CT_PGID,                               // �A�Z���u���h�c�܂��̓N���X�h�c
                    errorMessage,                               // �\�����郁�b�Z�[�W
                    0,                                     // �X�e�[�^�X�l
                    MessageBoxButtons.OK);                // �\������{�^��

                // �R���g���[����I��
                control.Focus();
                if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                return result;
            }
            if (this.TextSaveFolderCheck() == false)
            {
                return result;
            }

            try
            {
                _progressForm = new SFCMN00299CA();
                _progressForm.Title = "����f�[�^���o����";
                _progressForm.Message = "�����A����f�[�^���o�������ł��D�D�D";

                Int32 outSalesTotal = 0;
                string errMsg = "";
                SndAndRcvProcAcs pMSCM01201A = new SndAndRcvProcAcs();
                this.GetDisplay();
                Int32 SalesDateSt = Int32.Parse(this._inpDisplay.SalesDateSt.ToString("yyyyMMdd"));
                Int32 SalesDateEd = Int32.Parse(this._inpDisplay.SalesDateEd.ToString("yyyyMMdd"));
                Int32 InpDateSt = Int32.Parse(this._inpDisplay.InpDateSt.ToString("yyyyMMdd"));
                Int32 InpDateEd = Int32.Parse(this._inpDisplay.InpDateEd.ToString("yyyyMMdd"));
                if (InpDateSt == Int32.Parse(DateTime.MinValue.ToString("yyyyMMdd")))
                {
                    InpDateSt = 0;
                }
                if (InpDateEd == Int32.Parse(DateTime.MinValue.ToString("yyyyMMdd")))
                {
                    InpDateEd = 0;
                }

                Int32 SectionCodeSt = 0;
                if (this._inpDisplay.SectionCodeSt != "")
                {
                    SectionCodeSt = Int32.Parse(this._inpDisplay.SectionCodeSt);
                }
                else
                {
                    SectionCodeSt = 0;
                }
                Int32 SectionCodeEd = 0;
                if (this._inpDisplay.SectionCodeEd != "")
                {
                    SectionCodeEd = Int32.Parse(this._inpDisplay.SectionCodeEd);
                }
                else
                {
                    SectionCodeEd = 0;
                }

                _progressForm.Show(this);

                int status = pMSCM01201A.SearchAndTextout(0,
                SalesDateSt,
                SalesDateEd,
                InpDateSt,
                InpDateEd,
                SectionCodeSt,
                SectionCodeEd,
                this._inpDisplay.CustomerCodeSt,
                this._inpDisplay.CustomerCodeEd,
                this._inpDisplay.SlipNoSt,
                this._inpDisplay.SlipNoEd,
                this._inpDisplay.TextSaveFolder,
                ref outSalesTotal,
                ref errMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    OutpCount_ultraLabel.Text = outSalesTotal.ToString("#,##0");
                    result = true;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                {
                    if (_progressForm != null)
                    {
                        _progressForm.Close();
                        _progressForm = null;
                    }
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMsg,
                    -1,
                    MessageBoxButtons.OK);
                    OutpCount_ultraLabel.Text = "0";
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    if (_progressForm != null)
                    {
                        _progressForm.Close();
                        _progressForm = null;
                    }
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�Ώۃf�[�^������܂���B",
                    -1,
                    MessageBoxButtons.OK);
                    OutpCount_ultraLabel.Text = "0";
                }
                else
                {
                    OutpCount_ultraLabel.Text = "0";
                }

            }
            finally
            {
                if (_progressForm != null)
                {
                    _progressForm.Close();
                    _progressForm = null;
                }
            }

            Refresh();
            return result;
        }

        #endregion

        #region << ��ʃf�[�^�N���X�i�[���� >>

        /// <summary>
        /// ��ʁ���ʃf�[�^�N���X�i�[����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʁ���ʃf�[�^�N���X�i�[�������s���܂��B</br>
        /// <returns></returns>
        /// <br>Programmer : ���e</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        public InpDisplay GetDisplay()
        {
            this._inpDisplay = new InpDisplay();

            _inpDisplay.SalesDateSt = this.SalesDateSt_tDateEdit.GetDateTime();
            _inpDisplay.SalesDateEd = this.SalesDateEd_tDateEdit.GetDateTime();

            _inpDisplay.InpDateSt = this.InpDateSt_tDateEdit.GetDateTime();
            _inpDisplay.InpDateEd = this.InpDateEd_tDateEdit.GetDateTime();

            _inpDisplay.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
            _inpDisplay.CustomerNameSt = this.CustomerNameSt_tEdit.Text;

            _inpDisplay.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
            _inpDisplay.CustomerNameEd = this.CustomerNameEd_tEdit.Text;

            _inpDisplay.SectionCodeSt = this.tEdit_SectionCode_St.Text;
            _inpDisplay.SectionNameSt = this.SectionNameSt_tEdit.Text;

            _inpDisplay.SectionCodeEd = this.tEdit_SectionCode_Ed.Text;
            _inpDisplay.SectionNameEd = this.SectionNameEd_tEdit.Text;

            _inpDisplay.SlipNoSt = this.tNedit_SupplierSlipNo_St.GetInt();
            _inpDisplay.SlipNoEd = this.tNedit_SupplierSlipNo_Ed.GetInt();

            _inpDisplay.TextSaveFolder = this.TextSaveFolder_tEdit.Text;

            _inpDisplay.OutpCount = 0;

            return _inpDisplay;
        }

        #endregion

        # region << Control Events >>

        /// <summary>
        /// Form.Load �C�x���g(PMSCM01210U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer	: ���e</br>
        /// <br>Date        : 2011/07/29</br>
        /// </remarks>
        private void PMSCM01210U_Load(object sender, EventArgs e)
        {

            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABLE_KEY];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_UPDATEBUTTON_KEY];

            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            this.SalesDateSt_tDateEdit.SetDateTime(DateTime.Now);
            this.SalesDateEd_tDateEdit.SetDateTime(DateTime.Now);

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                status = this._pM7RkSettingAcs.Read(ref this._pM7RkSetting);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.TextSaveFolder_tEdit.Text = this._pM7RkSetting.TextSaveFolder;
                }
                else
                {
                    this.TextSaveFolder_tEdit.Text = "";
                }
            }
            catch (Exception)
            {
                this.TextSaveFolder_tEdit.Text = "";
            }

            // ��ʏ�����
            this.InitialScreenSetting();
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : ���e</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I������
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        Close();
                        break;
                    }
                // �X�V����
                case TOOLBAR_UPDATEBUTTON_KEY:
                    {
                        bool result = this.UpdateProc();
                        if (!result)
                        {
                            return;
                        }
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
        /// <br>Programmer : ���e</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            InpDisplay para = this._para.Clone();

            switch (e.PrevCtrl.Name)
            {
                // ���_�R�[�hFrom
                case "tEdit_SectionCode_St":
                    {
                        //------------------------------------
                        // ���_�[���R�[�h�擾
                        //------------------------------------
                        UiSet uiset;
                        uiSetControl1.ReadUISet(out uiset, tEdit_SectionCode_St.Name);
                        string sectionCodeZero = new string('0', uiset.Column);

                        //------------------------------------
                        // ���_�R�[�h�擾
                        //------------------------------------
                        string sectionCode = this.tEdit_SectionCode_St.Text.TrimEnd();

                        if (this.tEdit_SectionCode_St.GetInt() == 0)
                        {
                            sectionCode = "";
                            this.tEdit_SectionCode_St.Text = "";
                            this.SectionNameSt_tEdit.Text = "";
                            this._para.SectionCodeSt = "";
                            this._para.SectionNameSt = "";
                        }

                        if (sectionCode.Length == 1)
                        {
                            sectionCode = "0" + sectionCode;
                        }

                        if (sectionCode != para.SectionCodeSt)
                        {

                            //------------------------------------
                            // ����
                            //------------------------------------
                            if (sectionCode != string.Empty && sectionCode != sectionCodeZero)
                            {
                                if (_secInfoSetAcs == null)
                                {
                                    _secInfoSetAcs = new SecInfoSetAcs();
                                }
                                SecInfoSet sectionInfo;
                                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // �p�����[�^�ɕۑ�
                                    this._para.SectionCodeSt = sectionInfo.SectionCode.TrimEnd();
                                    this._para.SectionNameSt = sectionInfo.SectionGuideNm.TrimEnd();

                                    if (sectionInfo.LogicalDeleteCode == 1)
                                    {
                                        this.SectionNameSt_tEdit.Text = "";
                                        this._para.SectionNameSt = "";
                                    }
                                    else
                                    {
                                        this.SectionNameSt_tEdit.Text = this._para.SectionNameSt;
                                    }
                                    e.NextCtrl = tEdit_SectionCode_Ed;
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����鋒�_�����݂��܂���B",
                                        status,
                                        MessageBoxButtons.OK);

                                    this.tEdit_SectionCode_St.Text = this._para.SectionCodeSt;
                                    this.SectionNameSt_tEdit.Text = this._para.SectionNameSt;
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "���_���̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK);

                                    this.tEdit_SectionCode_St.Text = this._para.SectionCodeSt;
                                }
                            }
                        }

                    }
                    break;

                // ���_�R�[�hTo
                case "tEdit_SectionCode_Ed":
                    {
                        //------------------------------------
                        // ���_�[���R�[�h�擾
                        //------------------------------------
                        UiSet uiset;
                        uiSetControl1.ReadUISet(out uiset, tEdit_SectionCode_Ed.Name);
                        string sectionCodeZero = new string('0', uiset.Column);

                        //------------------------------------
                        // ���_�R�[�h�擾
                        //------------------------------------
                        string sectionCode = this.tEdit_SectionCode_Ed.Text.TrimEnd();

                        if (this.tEdit_SectionCode_Ed.GetInt() == 0)
                        {
                            sectionCode = "";
                            this.tEdit_SectionCode_Ed.Text = "";
                            this.SectionNameEd_tEdit.Text = "";
                            this._para.SectionCodeEd = "";
                            this._para.SectionNameEd = "";
                        }

                        if (sectionCode.Length == 1)
                        {
                            sectionCode = "0" + sectionCode;
                        }

                        if (sectionCode != para.SectionCodeEd)
                        {

                            //------------------------------------
                            // ����
                            //------------------------------------
                            if (sectionCode != string.Empty && sectionCode != sectionCodeZero)
                            {
                                if (_secInfoSetAcs == null)
                                {
                                    _secInfoSetAcs = new SecInfoSetAcs();
                                }
                                SecInfoSet sectionInfo;
                                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // �p�����[�^�ɕۑ�
                                    this._para.SectionCodeEd = sectionInfo.SectionCode.TrimEnd();
                                    this._para.SectionNameEd = sectionInfo.SectionGuideNm.TrimEnd();

                                    if (sectionInfo.LogicalDeleteCode == 1)
                                    {
                                        this.SectionNameEd_tEdit.Text = "";
                                        this._para.SectionNameEd = "";
                                    }
                                    else
                                    {
                                        this.SectionNameEd_tEdit.Text = this._para.SectionNameEd;
                                    }
                                    e.NextCtrl = tNedit_CustomerCode_St;
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����鋒�_�����݂��܂���B",
                                        status,
                                        MessageBoxButtons.OK);

                                    this.tEdit_SectionCode_Ed.Text = this._para.SectionCodeEd;
                                    this.SectionNameEd_tEdit.Text = this._para.SectionNameEd;
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "���_���̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK);

                                    this.tEdit_SectionCode_Ed.Text = this._para.SectionCodeEd;
                                }
                            }
                        }

                    }
                    break;

                //���Ӑ�R�[�hFrom
                case "tNedit_CustomerCode_St":
                    {
                        int code = this.tNedit_CustomerCode_St.GetInt();

                        if (para.CustomerCodeSt != code)
                        {
                            if (code == 0)
                            {
                                this._para.CustomerCodeSt = 0;
                                this._para.CustomerNameSt = "";
                                this.tNedit_CustomerCode_St.Text = "";
                                this.CustomerNameSt_tEdit.Text = "";
                            }
                            else
                            {
                                CustomerInfo data;
                                int status = this._salesSlipSearchAcs.GetCustomer(this._enterpriseCode, code, out data);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    this._para.CustomerCodeSt = data.CustomerCode;
                                    this._para.CustomerNameSt = data.Name + " " + data.Name2;

                                    this.CustomerNameSt_tEdit.Text = this._para.CustomerNameSt;
                                    e.NextCtrl = tNedit_CustomerCode_Ed;
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����链�Ӑ悪���݂��܂���B",
                                        status,
                                        MessageBoxButtons.OK);

                                    if (this._para.CustomerCodeSt == 0)
                                    {
                                        this.tNedit_CustomerCode_St.Text = "";
                                    }
                                    else
                                    {
                                        this.tNedit_CustomerCode_St.Text = this._para.CustomerCodeSt.ToString();
                                    }
                                    this.CustomerNameSt_tEdit.Text = this._para.CustomerNameSt;
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "���Ӑ於�̂̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK);
                                    this.tNedit_CustomerCode_St.Text = this._para.CustomerCodeSt.ToString();
                                }
                            }
                        }
                        break;
                    }

                // ���Ӑ�R�[�hTo
                case "tNedit_CustomerCode_Ed":
                    {
                        int code = this.tNedit_CustomerCode_Ed.GetInt();

                        if (para.CustomerCodeEd != code)
                        {
                            if (code == 0)
                            {
                                this._para.CustomerCodeEd = 0;
                                this._para.CustomerNameEd = "";

                                this.tNedit_CustomerCode_Ed.Text = "";
                                this.CustomerNameEd_tEdit.Text = "";
                            }
                            else
                            {
                                CustomerInfo data;
                                int status = this._salesSlipSearchAcs.GetCustomer(this._enterpriseCode, code, out data);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    this._para.CustomerCodeEd = data.CustomerCode;
                                    this._para.CustomerNameEd = data.Name + " " + data.Name2;

                                    this.CustomerNameEd_tEdit.Text = this._para.CustomerNameEd;
                                    e.NextCtrl = tNedit_SupplierSlipNo_St;
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����链�Ӑ悪���݂��܂���B",
                                        status,
                                        MessageBoxButtons.OK);

                                    if (this._para.CustomerCodeEd == 0)
                                    {
                                        this.tNedit_CustomerCode_Ed.Text = "";
                                    }
                                    else
                                    {
                                        this.tNedit_CustomerCode_Ed.Text = this._para.CustomerCodeEd.ToString();
                                    }
                                    this.CustomerNameEd_tEdit.Text = this._para.CustomerNameEd;
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "���Ӑ於�̂̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK);
                                    this.tNedit_CustomerCode_Ed.Text = this._para.CustomerCodeEd.ToString();
                                }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// GroupExpanding �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup ���W�J�����O�ɔ������܂��B</br>
        /// <br>Programmer  : ���e</br>
        /// <br>Date        : 2011/07/29</br>
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
        /// <br>Programmer  : ���e</br>
        /// <br>Date        : 2011/07/29</br>
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

        /// <summary>
        /// Control.Click �C�x���g(SectionSt_DirGuide_uButton)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_From�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���e</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void SectionSt_DirGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    // �ݒ�l��ۑ�
                    this.tEdit_SectionCode_St.Text = secInfoSet.SectionCode.Trim();
                    this.SectionNameSt_tEdit.Text = secInfoSet.SectionGuideNm.Trim();
                    this.tEdit_SectionCode_Ed.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// Control.Click �C�x���g(SectionEd_DirGuide_uButton)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_To�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���e</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void SectionEd_DirGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    // �ݒ�l��ۑ�
                    this.tEdit_SectionCode_Ed.Text = secInfoSet.SectionCode.Trim();
                    this.SectionNameEd_tEdit.Text = secInfoSet.SectionGuideNm.Trim();
                    this.tNedit_CustomerCode_St.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// Control.Click �C�x���g(CustomerSt_DirGuide_uButton)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���Ӑ�To�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���e</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void CustomerSt_DirGuide_uButton_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h�p���C�u�������ύX
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// ���Ӑ挟���A�N�Z�X�N���X
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect1);
            DialogResult ret = customerSearchForm.ShowDialog(this);
            this.tNedit_CustomerCode_Ed.Focus();
        }

        /// <summary>
        /// Control.Click �C�x���g(CustomerEd_DirGuide_uButton)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���Ӑ�To�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���e</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void CustomerEd_DirGuide_uButton_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h�p���C�u�������ύX
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// ���Ӑ挟���A�N�Z�X�N���X
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect2);
            DialogResult ret = customerSearchForm.ShowDialog(this);
            this.tNedit_SupplierSlipNo_St.Focus();
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�I���������C�x���g�������s���܂��B</br>
        /// <br>Programmer : ���e</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect1(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                return;
            }

            this._inpDisplay.CustomerCodeSt = customerSearchRet.CustomerCode;                    // ���Ӑ�R�[�h
            this._inpDisplay.CustomerNameSt = customerSearchRet.Name + customerSearchRet.Name2;   // ���Ӑ於��

            this.tNedit_CustomerCode_St.SetInt(this._inpDisplay.CustomerCodeSt);
            this.CustomerNameSt_tEdit.Text = this._inpDisplay.CustomerNameSt;

            // ����
            ((PMKHN04005UA)sender).DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�I���������C�x���g�������s���܂��B</br>
        /// <br>Programmer : ���e</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect2(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                return;
            }

            this._inpDisplay.CustomerCodeEd = customerSearchRet.CustomerCode;                    // ���Ӑ�R�[�h
            this._inpDisplay.CustomerNameEd = customerSearchRet.Name + customerSearchRet.Name2;   // ���Ӑ於��

            this.tNedit_CustomerCode_Ed.SetInt(this._inpDisplay.CustomerCodeEd);
            this.CustomerNameEd_tEdit.Text = this._inpDisplay.CustomerNameEd;

            // ����
            ((PMKHN04005UA)sender).DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Control.Click �C�x���g(TextSaveFolder_DirGuide_uButton)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �e�L�X�g�i�[�t�H���_�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���e</br>
        /// <br>Date       : 2011.07.29</br>
        /// </remarks>
        private void TextSaveFolder_DirGuide_uButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            dlg.RootFolder = Environment.SpecialFolder.Desktop;
            dlg.Description = "�R���o�[�g�f�[�^�̃t�H���_���w�肵�ĉ������B";
            DialogResult ret = dlg.ShowDialog();
            if (ret == DialogResult.OK)
            {
                TextSaveFolder_tEdit.Text = dlg.SelectedPath;
            }
        }

        #endregion

        #region << ���͍��ڃ`�F�b�N >>

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <param name="mode"></param>
        /// <param name="ym"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���t�`�F�b�N�����Ăяo�����s���B </br>
        /// <br>Programmer : ���e</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate, bool mode, int ym)
        {
            _dateGet = DateGetAcs.GetInstance();
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, ym, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, mode);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// ���͍��ڃ`�F�b�N����
        /// </summary>
        /// <param name="control"></param>
        /// <param name="errorMessage"></param>
        /// <returns>result</returns>
        /// <remarks>
        /// <br>Note       : ���͍��ڃ`�F�b�N�������s���B </br>
        /// <br>Programmer : ���e</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string errorMessage)
        {
            bool result = false;

            string kbnNm = SalesDate_ultraLabel.Text;

            DateGetAcs.CheckDateRangeResult cdrResult;

            //������i�J�n�`�I���j
            if (CallCheckDateRange(out cdrResult, ref SalesDateSt_tDateEdit, ref SalesDateEd_tDateEdit, true, 0) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errorMessage = string.Format("�J�n" + kbnNm + "{0}", "�̓��͂��s���ł��B");
                            control = this.SalesDateSt_tDateEdit;
                            return result;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errorMessage = string.Format("�I��" + kbnNm + "{0}", "�̓��͂��s���ł��B");
                            control = this.SalesDateEd_tDateEdit;
                            return result;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errorMessage = string.Format(kbnNm + "{0}", "�͈͎̔w��Ɍ�肪����܂��B");
                            control = this.SalesDateSt_tDateEdit;
                            return result;
                        }
                }
            }

            kbnNm = this.InpDate_ultraLabel.Text;

            //���J���i�J�n�`�I���j
            if (CallCheckDateRange(out cdrResult, ref InpDateSt_tDateEdit, ref InpDateEd_tDateEdit, true, 0) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errorMessage = string.Format("�J�n" + kbnNm + "{0}", "�̓��͂��s���ł��B");
                            control = this.InpDateSt_tDateEdit;
                            return result;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errorMessage = string.Format("�I��" + kbnNm + "{0}", "�̓��͂��s���ł��B");
                            control = this.InpDateEd_tDateEdit;
                            return result;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errorMessage = string.Format(kbnNm + "{0}", "�͈͎̔w��Ɍ�肪����܂��B");
                            control = this.InpDateSt_tDateEdit;
                            return result;
                        }
                }
            }

            //�K�{���̓`�F�b�N
            //������e������
            if (this.SalesDateSt_tDateEdit.GetDateTime() == DateTime.MinValue)
            {
                control = this.SalesDateSt_tDateEdit;
                errorMessage = "�J�n���������͂��Ă��������B";
                return result;
            }
            //������s��
            if (this.SalesDateEd_tDateEdit.GetDateTime() == DateTime.MinValue)
            {
                control = this.SalesDateEd_tDateEdit;
                errorMessage = "�I�����������͂��Ă��������B";
                return result;
            }
            //�e�L�X�g�i�[�t�H���_
            if (this.TextSaveFolder_tEdit.Text.Trim() == "")
            {
                this.TextSaveFolder_tEdit.Clear();
                control = this.TextSaveFolder_tEdit;
                errorMessage = "�e�L�X�g�i�[�t�H���_����͂��Ă��������B";
                return result;
            }

            //���͒l�w��͈̓`�F�b�N
            //�����
            if (this.SalesDateEd_tDateEdit.GetLongDate() != 0)
            {
                if (this.SalesDateSt_tDateEdit.GetLongDate() > this.SalesDateEd_tDateEdit.GetLongDate())
                {
                    control = this.SalesDateSt_tDateEdit;
                    errorMessage = "������͈͎̔w��Ɍ�肪����܂��B";
                    return result;
                }
            }
            //���͓�
            if (this.InpDateEd_tDateEdit.GetLongDate() != 0)
            {
                if (this.InpDateSt_tDateEdit.GetLongDate() > this.InpDateEd_tDateEdit.GetLongDate())
                {
                    control = this.InpDateSt_tDateEdit;
                    errorMessage = "���͓��͈͎̔w��Ɍ�肪����܂��B";
                    return result;
                }
            }
            //���_
            if (this.tEdit_SectionCode_Ed.GetInt() != 0)
            {
                if (this.tEdit_SectionCode_St.GetInt() > this.tEdit_SectionCode_Ed.GetInt())
                {
                    control = this.tEdit_SectionCode_St;
                    errorMessage = "���_�͈͎̔w��Ɍ�肪����܂��B";
                    return result;
                }
            }
            //���Ӑ�
            if (this.tNedit_CustomerCode_Ed.GetInt() != 0)
            {
                if (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
                {
                    control = this.tNedit_CustomerCode_St;
                    errorMessage = "���Ӑ�͈͎̔w��Ɍ�肪����܂��B";
                    return result;
                }
            }
            //�`�[�ԍ�
            if (this.tNedit_SupplierSlipNo_Ed.GetInt() != 0)
            {
                if (this.tNedit_SupplierSlipNo_St.GetInt() > this.tNedit_SupplierSlipNo_Ed.GetInt())
                {
                    control = this.tNedit_SupplierSlipNo_St;
                    errorMessage = "�`�[�ԍ��͈͎̔w��Ɍ�肪����܂��B";
                    return result;
                }
            }

            result = true;

            return result;
        }

        /// <summary>
        /// �e�L�X�g�i�[�t�H���_���ݐ��`�F�b�N
        /// </summary>
        /// <returns>result</returns>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�i�[�t�H���_���ݐ��`�F�b�N�������s���B </br>
        /// <br>Programmer : ���e</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private bool TextSaveFolderCheck()
        {
            bool result = true;
            //�e�L�X�g�i�[�t�H���_���ݐ��`�F�b�N
            if (!Directory.Exists(this.TextSaveFolder_tEdit.Text))
            {
                result = false;
                this.TextSaveFolder_tEdit.Clear();
                this.TextSaveFolder_tEdit.Focus();
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                "�w�肵���t�H���_�����݂��܂���B", 0, MessageBoxButtons.OK);
                return result;
            }

            return result;
        }

        #endregion

    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              