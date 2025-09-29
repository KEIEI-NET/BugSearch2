//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�}�X�^���o�������
// �v���O�����T�v   : ���Ӑ�}�X�^���o�����̐ݒ�E�Q�Ə������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g���Y
// �� �� ��  2011.07.27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Ӑ�}�X�^���o������ʃt�H�[���N���X
    /// </summary>
    /// <remarks>
    /// Note       : ���Ӑ�}�X�^���o�����̐ݒ�E�Q�Ə����ł��B<br />
    /// Programmer : �g���Y<br />
    /// Date       : 2011.07.27<br />
    /// </remarks>
    public partial class PMKYO01301UA : Form
    {

        #region �� Const Memebers ��

        private const string PROGRAM_ID = "PMKYO01301UA";
        
        #endregion �� Const Memebers ��

        # region �� Private field ��

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        // ���Ӑ�}�X�^�A�N�Z�X
        CustomerInfoAcs _customerInfoAcs;
        // ���_�}�X�^�A�N�Z�X
        SecInfoSetAcs _secInfoSetAcs;
        // �]�ƈ��}�X�^�A�N�Z�X
        private EmployeeAcs _employeeAcs;
        // ���[�U�}�X�^�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs;
        // ���Ӑ�K�C�h�ݒ萬���t���O
        private bool _customerGuidOK;

        
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

        # endregion �� Private field ��

        #region �� Public Memebers ��
        /// <summary>
        /// 1:�V�K���[�h 2:�Q�ƃ��[�h
        /// </summary>
        public int Mode;
        /// <summary>
        /// APCustomerProcParamWork
        /// </summary>
        public APCustomerProcParamWork _customerProcParam;

        #endregion �� Public Memebers ��

        #region  �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈���ł��B</br>
        /// <br>Programmer : �g���Y</br>
        /// <br>Date       : 2011.07.27</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }
        # endregion �� �{�^�������ݒ菈�� ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKYO01301UA()
        {
            InitializeComponent();

            // ���Ӑ�K�C�h�p�A�N�Z�X�N���X
            _customerInfoAcs = new CustomerInfoAcs();
            // ���_�K�C�h�p�A�N�Z�X�N���X
            this._secInfoSetAcs = new SecInfoSetAcs();
            // �]�ƈ��K�C�h�p�A�N�Z�X�N���X
            this._employeeAcs = new EmployeeAcs();
            // ���[�U�[�K�C�h�p�A�N�Z�X�N���X
            this._userGuideAcs = new UserGuideAcs();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();

        }
        # endregion �� �R���X�g���N�^ ��

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: �g���Y</br>	
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void PMKYO01201UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.ButtonInitialSetting();

            //�Q�ƃ��[�h
            if (this.Mode == 2)
            {
                this._saveButton.SharedProps.Visible = false;
                this._clearButton.SharedProps.Visible = false;
                this.tNedit_CustomerCode_St.Enabled = false;
                this.tNedit_CustomerCode_Ed.Enabled = false;
                this.tEdit_Kana_St.Enabled = false;
                this.tEdit_Kana_Ed.Enabled = false;
                this.tEdit_SectionCode_St.Enabled = false;
                this.tEdit_SectionCode_Ed.Enabled = false;
                this.tEdit_EmployeeCode_St.Enabled = false;
                this.tEdit_EmployeeCode_Ed.Enabled = false;
                this.tNedit_SalesAreaCode_St.Enabled = false;
                this.tNedit_SalesAreaCode_Ed.Enabled = false;
                this.tNedit_BusinessTypeCode_St.Enabled = false;
                this.tNedit_BusinessTypeCode_Ed.Enabled = false;
                this.CustomerStGuide_Button.Enabled = false;
                this.CustomerEdGuide_Button.Enabled = false;
                this.SectionStGuide_Button.Enabled = false;
                this.SectionEdGuide_Button.Enabled = false;
                this.EmployeeStGuide_Button.Enabled = false;
                this.EmployeeEdGuide_Button.Enabled = false;
                this.AreaStGuide_Button.Enabled = false;
                this.AreaEdGuide_Button.Enabled = false;
                this.BusinessTypeCodeSt_Button.Enabled = false;
                this.BusinessTypeCodeEd_Button.Enabled = false;

            }
            //�V�K���[�h
            else
            {
                this._saveButton.SharedProps.Visible = true;
                this._clearButton.SharedProps.Visible = true;
                this.tNedit_CustomerCode_St.Enabled = true;
                this.tNedit_CustomerCode_Ed.Enabled = true;
                this.tEdit_Kana_St.Enabled = true;
                this.tEdit_Kana_Ed.Enabled = true;
                this.tEdit_SectionCode_St.Enabled = true;
                this.tEdit_SectionCode_Ed.Enabled = true;
                this.tEdit_EmployeeCode_St.Enabled = true;
                this.tEdit_EmployeeCode_Ed.Enabled = true;
                this.tNedit_SalesAreaCode_St.Enabled = true;
                this.tNedit_SalesAreaCode_Ed.Enabled = true;
                this.tNedit_BusinessTypeCode_St.Enabled = true;
                this.tNedit_BusinessTypeCode_Ed.Enabled = true;
                this.CustomerStGuide_Button.Enabled = true;
                this.CustomerEdGuide_Button.Enabled = true;
                this.SectionStGuide_Button.Enabled = true;
                this.SectionEdGuide_Button.Enabled = true;
                this.EmployeeStGuide_Button.Enabled = true;
                this.EmployeeEdGuide_Button.Enabled = true;
                this.AreaStGuide_Button.Enabled = true;
                this.AreaEdGuide_Button.Enabled = true;
                this.BusinessTypeCodeSt_Button.Enabled = true;
                this.BusinessTypeCodeEd_Button.Enabled = true;
            }
            
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.CustomerStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.EmployeeStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.EmployeeEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.AreaStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.AreaEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BusinessTypeCodeSt_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BusinessTypeCodeEd_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            this.timer_InitialSetFocus.Enabled = true;
        }
        # endregion �� �t�H�[�����[�h ��

        # region �� ��ʏ�������C�x���g ��
        /// <summary>
        /// ��ʏ�������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ�������C�x���g�����������܂��B</br>
        /// <br>Programmer	: �g���Y</br>
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            if (this._customerProcParam != null)
            {
                //�J�n����1(���Ӑ�)
                this.tNedit_CustomerCode_St.SetInt(_customerProcParam.CustomerCodeBeginRF);
                //�I������1(���Ӑ�)
                this.tNedit_CustomerCode_Ed.SetInt(_customerProcParam.CustomerCodeEndRF);
                //�J�n����2(�J�i)
                this.tEdit_Kana_St.DataText = _customerProcParam.KanaBeginRF;
                //�I������2(�J�i)
                this.tEdit_Kana_Ed.DataText = _customerProcParam.KanaEndRF;
                //�J�n����3(���_)
                this.tEdit_SectionCode_St.DataText = _customerProcParam.MngSectionCodeBeginRF.Trim();
                //�I������3(���_)
                this.tEdit_SectionCode_Ed.DataText = _customerProcParam.MngSectionCodeEndRF.Trim();
                //�J�n����4(�S����)
                this.tEdit_EmployeeCode_St.DataText = _customerProcParam.CustomerAgentCdBeginRF;
                //�I������4(�S����)
                this.tEdit_EmployeeCode_Ed.DataText = _customerProcParam.CustomerAgentCdEndRF;
                //�J�n����5(�n��)
                this.tNedit_SalesAreaCode_St.SetInt(_customerProcParam.SalesAreaCodeBeginRF);
                //�I������5(�n��)
                this.tNedit_SalesAreaCode_Ed.SetInt(_customerProcParam.SalesAreaCodeEndRF);
                //�J�n����6(�Ǝ�)
                this.tNedit_BusinessTypeCode_St.SetInt(_customerProcParam.BusinessTypeCodeBeginRF);
                //�I������6(�Ǝ�)
                this.tNedit_BusinessTypeCode_Ed.SetInt(_customerProcParam.BusinessTypeCodeEndRF);
            }
            
        }
        #endregion

        # region �� �c�[���o�[���� ��

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: �g���Y</br>	
        /// <br>Date		: 2011.07.27</br>
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
                case "ButtonTool_Save":
                    {
                        //�ۑ�����
                        this.Save();
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // �N���A����
                        this.Clear();
                        break;
                    }
                
            }
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �ۑ������ł��B</br>
        /// <br>Programmer	: �g���Y</br>	
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void Save()
        {
            string errMessage = "";
            Control errCtrl = null;
            // ��ʃf�[�^�`�F�b�N����
            if (!this.ScreenInputCheck(out errCtrl, ref errMessage))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                //�t�H�[�J�X���G���[���ڂֈړ�
                if (null != errCtrl && errCtrl.Enabled)
                {
                    errCtrl.Focus();
                }
                return;
            }
            if (_customerProcParam == null)
            {
                _customerProcParam = new APCustomerProcParamWork();
            }
            else
            {
                //�J�n����1(���Ӑ�)
                _customerProcParam.CustomerCodeBeginRF = this.tNedit_CustomerCode_St.GetInt();
                //�I������1(���Ӑ�)
                _customerProcParam.CustomerCodeEndRF =  this.tNedit_CustomerCode_Ed.GetInt();
                //�J�n����2(�J�i)
                _customerProcParam.KanaBeginRF =  this.tEdit_Kana_St.DataText;
                //�I������2(�J�i)
                _customerProcParam.KanaEndRF = this.tEdit_Kana_Ed.DataText;
                //�J�n����3(���_)
                _customerProcParam.MngSectionCodeBeginRF = this.tEdit_SectionCode_St.DataText;
                //�I������3(���_)
                _customerProcParam.MngSectionCodeEndRF =  this.tEdit_SectionCode_Ed.DataText;
                //�J�n����4(�S����)
                _customerProcParam.CustomerAgentCdBeginRF =  this.tEdit_EmployeeCode_St.DataText;
                //�I������4(�S����)
                _customerProcParam.CustomerAgentCdEndRF =  this.tEdit_EmployeeCode_Ed.DataText;
                //�J�n����5(�n��)
                _customerProcParam.SalesAreaCodeBeginRF = this.tNedit_SalesAreaCode_St.GetInt();
                //�I������5(�n��)
                _customerProcParam.SalesAreaCodeEndRF = this.tNedit_SalesAreaCode_Ed.GetInt();
                //�J�n����6(�Ǝ�)
                _customerProcParam.BusinessTypeCodeBeginRF =  this.tNedit_BusinessTypeCode_St.GetInt();
                //�I������6(�Ǝ�)
                _customerProcParam.BusinessTypeCodeEndRF =  this.tNedit_BusinessTypeCode_Ed.GetInt();
            }

            //�ۑ������������ʂ����
            this.Close();
        }

        /// <summary>
        /// �N���A����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �N���A�����ł��B</br>
        /// <br>Programmer	: �g���Y</br>	
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void Clear()
        {
            this.tNedit_CustomerCode_St.SetInt(0);
            this.tNedit_CustomerCode_Ed.SetInt(0);
            this.tEdit_Kana_St.DataText = string.Empty;
            this.tEdit_Kana_Ed.DataText = string.Empty;
            this.tEdit_SectionCode_St.DataText = string.Empty;
            this.tEdit_SectionCode_Ed.DataText = string.Empty;
            this.tEdit_EmployeeCode_St.DataText = string.Empty;
            this.tEdit_EmployeeCode_Ed.DataText = string.Empty;
            this.tNedit_SalesAreaCode_St.SetInt(0);
            this.tNedit_SalesAreaCode_Ed.SetInt(0);
            this.tNedit_BusinessTypeCode_St.SetInt(0);
            this.tNedit_BusinessTypeCode_Ed.SetInt(0);
        }

        #endregion region �� �c�[���o�[���� ��

        #region �� Private Method ��

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�����[�h�C�x���g�����������܂��B</br>
        /// <br>Programmer	: �g���Y</br>
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //���Ӑ�(�J�n)
                case "tNedit_CustomerCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_CustomerCode_St.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.CustomerStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //���Ӑ�(�I��)
                case "tNedit_CustomerCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_CustomerCode_Ed.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tEdit_Kana_St;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.CustomerEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //���_(�J�n)
                case "tEdit_SectionCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tEdit_SectionCode_St.DataText))
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tEdit_SectionCode_Ed;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.SectionStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //���_(�I��)
                case "tEdit_SectionCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tEdit_SectionCode_Ed.DataText))
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tEdit_EmployeeCode_St;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.SectionEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //�S����(�J�n)
                case "tEdit_EmployeeCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tEdit_EmployeeCode_St.DataText))
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.EmployeeStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //�S����(�I��)
                case "tEdit_EmployeeCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tEdit_EmployeeCode_Ed.DataText))
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_SalesAreaCode_St;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.EmployeeEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //�n��(�J�n)
                case "tNedit_SalesAreaCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SalesAreaCode_St.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.AreaStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //�n��(�I��)
                case "tNedit_SalesAreaCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SalesAreaCode_Ed.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_BusinessTypeCode_St;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.AreaEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //�Ǝ�(�J�n)
                case "tNedit_BusinessTypeCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_BusinessTypeCode_St.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_BusinessTypeCode_Ed;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.BusinessTypeCodeSt_Button;
                                }
                            }
                        }
                        break;
                    }
                //�Ǝ�(�I��)
                case "tNedit_BusinessTypeCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_BusinessTypeCode_Ed.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_CustomerCode_St;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.BusinessTypeCodeEd_Button;
                                }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errCtrl">Control</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: �g���Y</br>
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private bool ScreenInputCheck(out Control errCtrl, ref string errMessage)
        {
            bool status = true;
            errCtrl = null;
            const string ct_RangeError = "�͈̔͂��s���ł��B";

            //���Ӑ�͈̓`�F�b�N
            if (this.tNedit_CustomerCode_Ed.GetInt() > 0 && this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
            {
                errMessage = this.ultraLabel_Customer.Text + ct_RangeError;
                errCtrl = tNedit_CustomerCode_St;
                status = false;
                return status;
            }
            //�J�i�͈̓`�F�b�N
            if (!string.IsNullOrEmpty(this.tEdit_Kana_Ed.DataText.Trim()) &&
                0 < this.tEdit_Kana_St.DataText.CompareTo(this.tEdit_Kana_Ed.DataText))
            {
                errMessage = this.ultraLabel_Kana.Text + ct_RangeError;
                errCtrl = tEdit_Kana_St;
                status = false;
                return status;
            }
            //���_�͈̓`�F�b�N
            if (!string.IsNullOrEmpty(this.tEdit_SectionCode_Ed.DataText.Trim()) &&
                0 < this.tEdit_SectionCode_St.DataText.CompareTo(this.tEdit_SectionCode_Ed.DataText))
            {
                errMessage = this.ultraLabel_Section.Text + ct_RangeError;
                errCtrl = tEdit_SectionCode_St;
                status = false;
                return status;
            }
            //�S���Ҕ͈̓`�F�b�N
            if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.DataText.Trim()) &&
                0 < this.tEdit_EmployeeCode_St.DataText.CompareTo(this.tEdit_EmployeeCode_Ed.DataText))
            {
                errMessage = this.ultraLabel_Employee.Text + ct_RangeError;
                errCtrl = tEdit_EmployeeCode_St;
                status = false;
                return status;
            }
            //�n��͈̓`�F�b�N
            if (this.tNedit_SalesAreaCode_Ed.GetInt() > 0 && this.tNedit_SalesAreaCode_St.GetInt() > this.tNedit_SalesAreaCode_Ed.GetInt())
            {
                errMessage = this.ultraLabel_Area.Text + ct_RangeError;
                errCtrl = tNedit_SalesAreaCode_St;
                status = false;
                return status;
            }
            //�Ǝ�͈̓`�F�b�N
            if (this.tNedit_BusinessTypeCode_Ed.GetInt() > 0 && this.tNedit_BusinessTypeCode_St.GetInt() > this.tNedit_BusinessTypeCode_Ed.GetInt())
            {
                errMessage = this.ultraLabel_BusinessType.Text + ct_RangeError;
                errCtrl = tNedit_BusinessTypeCode_St;
                status = false;
                return status;
            }
            return status;
        }

        /// <summary>
        /// Control.Click �C�x���g(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���Ӑ�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011.07.27</br>
        /// </remarks>
        private void CustomerStGuide_Button_Click(object sender, EventArgs e)
        {
            this._customerGuidOK = false;
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (this._customerGuidOK)
            {
                this.tNedit_CustomerCode_Ed.Focus();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���Ӑ�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011.07.27</br>
        /// </remarks>
        private void CustomerEdGuide_Button_Click(object sender, EventArgs e)
        {
            this._customerGuidOK = false;
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (this._customerGuidOK)
            {
                this.tEdit_Kana_St.Focus();
            }
        }

        /// <summary>
		/// ���Ӑ�I���������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // �擾�������Ӑ�R�[�h(�J�n)����ʂɕ\������
            this.tNedit_CustomerCode_St.SetInt(customerSearchRet.CustomerCode);
            this._customerGuidOK = true;
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // �擾�������Ӑ�R�[�h(�I��)����ʂɕ\������
            this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
            this._customerGuidOK = true;
        }

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011.07.27</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet = new SecInfoSet();

                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    //�擾�������_�R�[�h����ʂɕ\������
                    if ("SectionStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tEdit_SectionCode_St.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionCode_Ed.Focus();
                    }
                    else
                    {
                        this.tEdit_SectionCode_Ed.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_EmployeeCode_St.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(EmployeeGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �S���҃K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011.07.27</br>
        /// </remarks>
        private void EmployeeGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Employee employee = new Employee();

                status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);
                if (status == 0)
                {
                    //�擾�����S���҃R�[�h����ʂɕ\������
                    if ("EmployeeStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tEdit_EmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_EmployeeCode_Ed.Focus();
                    }
                    else
                    {
                        this.tEdit_EmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                        this.tNedit_SalesAreaCode_St.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(AreaGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �n��K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011.07.27</br>
        /// </remarks>
        private void AreaGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdBd userGdBd = new UserGdBd();
                UserGdHd userGdHd = new UserGdHd();

                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);
                if (status == 0)
                {
                    //�擾�����n��R�[�h����ʂɕ\������
                    if ("AreaStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_SalesAreaCode_St.SetInt(userGdBd.GuideCode);
                        this.tNedit_SalesAreaCode_Ed.Focus();
                    }
                    else
                    {
                        this.tNedit_SalesAreaCode_Ed.SetInt(userGdBd.GuideCode);
                        this.tNedit_BusinessTypeCode_St.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(BusinessTypeGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �Ǝ�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �g���Y</br>
        /// <br>Date        : 2011.07.27</br>
        /// </remarks>
        private void BusinessTypeGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdBd userGdBd = new UserGdBd();
                UserGdHd userGdHd = new UserGdHd();

                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);
                if (status == 0)
                {
                    //�擾�����Ǝ�R�[�h����ʂɕ\������
                    if ("BusinessTypeCodeSt_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_BusinessTypeCode_St.SetInt(userGdBd.GuideCode);
                        this.tNedit_BusinessTypeCode_Ed.Focus();
                    }
                    else
                    {
                        this.tNedit_BusinessTypeCode_Ed.SetInt(userGdBd.GuideCode);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �G���[���b�Z�[�W����
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">STATUS</param>
        /// <returns>true:�`�F�b�N���� false:�`�F�b�N������</returns>
        /// <remarks>
        /// <br>Note		: �G���[���b�Z�[�W���s���B</br>
        /// <br>Programmer	: �g���Y</br>
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                PROGRAM_ID,
                "",
                "",
                "",
                message,
                status,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
        }

        #endregion Private Method

		# region �� ExplorerBar�̏k���E�W�J���� ��
		/// <summary>
		/// �O���[�v�W�J
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// ��ɃL�����Z��
			e.Cancel = true;
		}
		/// <summary>
		/// �O���[�v�k��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// ��ɃL�����Z��
			e.Cancel = true;
		}
		# endregion ��  ��
    }
}