//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^���o�������
// �v���O�����T�v   : �|���}�X�^���o������ʁE�Q�Ə������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����Y
// �� �� ��  2011.08.08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g���Y
// �� �� ��  2011.08.25  �C�����e : #23972 �u�P����ށF�S�āv�̏����͐ݒ�s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011.09.07  �C�����e : #24537 �|���}�X�^���o������ʃK�C�h�ǉ��˗�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����Y
// �� �� ��  2011.09.15  �C�����e : #24537 �|���}�X�^���o������ʃK�C�h�ǉ��˗�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI���� �f��
// �� �� ��  2012.07.26  �C�����e : ���_�����ڂɒǉ�
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
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �|���}�X�^���o������ʃt�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^���o�����̐ݒ�E�Q�Ə����ł��B</br>
    /// <br>Programer  : LDNS �����Y</br>
    /// <br>Date       : 2011.08.08</br>
    /// </remarks>

    public partial class PMKYO01601UA : Form
    {

        #region �� Const Memebers ��

        private const string PROGRAM_ID = "PMKYO01601UA";

        // --- ADD 2012/07/26 ---------->>>>>
        private const string LABEL_GDDOSNO = "�i��";                     // ���x�������� - �i��
        private const string LABEL_GDDOSNO_SINGLE = LABEL_GDDOSNO + "*"; // ���x�������� - �i�ԁi�P�Ǝ��j
        // --- ADD 2012/07/26 ----------<<<<<

        #endregion �� Const Memebers ��

        # region �� Private field ��

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        private SupplierAcs _supplierAcs;       //  �d����p
        private BLGoodsCdAcs _blGoodsCdAcs;     //  BL�R�[�h�p
        private MakerAcs _makerAcs;             // ���[�J�[�p
        private UserGuideAcs _userGuideAcs = null;			// ���[�U�[�K�C�h�A�N�Z�X�N���X
        // --- ADD 2012/07/26 ---------->>>>>
        private SecInfoSetAcs _secInfoSetAcs;  // ���_�p
        // --- ADD 2012/07/26 ----------<<<<<

        // ���Ӑ�K�C�h�p
        private UltraButton _customerGuideSender;

		// ���i�|����ٰ��
		GoodsGroupUAcs _goodsGroupUAcs; // ADD 2011.09.07

        private string _loginName;
        private string _enterpriseCode;
        private string _loginEmplooyCode;
        private string _loginSectionCode;
        // --- DEL 2012/07/26 ---------->>>>>
        //private int _flag;
        // --- DEL 2012/07/26 ----------<<<<<

        # endregion �� Private field ��

        #region �� Public Memebers ��
        /// <summary>
        /// 1:�V�K���[�h 2:�Q�ƃ��[�h
        /// </summary>
        public int Mode;
        /// <summary>
        /// APRateProcParamWork
        /// </summary>
        public APRateProcParamWork _rateProcParam;

        #endregion �� Public Memebers ��

        #region  �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈���ł��B</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            ImageList imageList16 = IconResourceManagement.ImageList16;
            // --- ADD 2012/07/26 ---------->>>>>
            this.SectionStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            // --- ADD 2012/07/26 ----------<<<<<
            this.CustRateGrpCodeStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustRateGrpCodeEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            this.CustomerCodeStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerCodeEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            
            this.SupplierStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SupplierEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            
            this.GoodsMakerCdStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsMakerCdEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            
            this.BLGoodsCodeStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGoodsCodeEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

			// ADD 2011.09.07 -------- >>>>>
			this.ub_St_MediumGoodsGanreCodeGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
			this.ub_Ed_MediumGoodsGanreCodeGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
			// ADD 2011.09.07 -------- <<<<<

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            // DropDown Style
            this.tComboEditor_PriceKind.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_SetMethod.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
        }
        # endregion �� �{�^�������ݒ菈�� ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKYO01601UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._supplierAcs = new SupplierAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            // --- ADD 2012/07/26 ---------->>>>>
            this._secInfoSetAcs = new SecInfoSetAcs();
            // --- ADD 2012/07/26 ----------<<<<<

            this._loginName = LoginInfoAcquisition.Employee.Name;
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

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
        /// <br>Programmer	: �����Y</br>	
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        private void PMKYO01201UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this.ButtonInitialSetting();

            this.ModeSelect(); 

            this.timer_InitialSetFocus.Enabled = true;
                 
        }

        /// <summary>
        /// ���mode�I������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// <br>Update      : 2011/09/15 �����Y</br>
        /// <br>            : Redmine �d�l�A�� #24537</br>
        /// </remarks>
        void ModeSelect(){
            //�Q�ƃ��[�h
            if (this.Mode == 2)
            {
                this._saveButton.SharedProps.Visible = false;
                this._clearButton.SharedProps.Visible = false;

                this.tComboEditor_PriceKind.Enabled = false;
                this.tComboEditor_SetMethod.Enabled = false;

                // --- ADD 2012/07/26 ---------->>>>>
                // ���_
                this.checkBox_SectionCode.Enabled = false;
                this.tEdit_SectionCodeAllowZero_St.Enabled = false;
                this.tEdit_SectionCodeAllowZero_Ed.Enabled = false;
                this.SectionStGuide_Button.Enabled = false;
                this.SectionEdGuide_Button.Enabled = false;
                // --- ADD 2012/07/26 ----------<<<<<
                // ���Ӑ�|���O���[�v
                this.checkBox_CustRateGrpCode.Enabled = false;
                this.tNedit_CustRateGrpCode_St.Enabled = false;
                this.tNedit_CustRateGrpCode_Ed.Enabled = false;
                this.CustRateGrpCodeStGuide_Button.Enabled = false;
                this.CustRateGrpCodeEdGuide_Button.Enabled = false;

                // ���Ӑ�R�[�h
                this.checkBox_CustomerCode.Enabled = false;
                this.tNedit_CustomerCode_St.Enabled = false;
                this.tNedit_CustomerCode_Ed.Enabled = false;
                this.CustomerCodeStGuide_Button.Enabled = false;
                this.CustomerCodeEdGuide_Button.Enabled = false;

                // �d����R�[�h
                this.checkBox_SupplierCd.Enabled = false;
                this.tNedit_SupplierCd_St.Enabled = false;
                this.tNedit_SupplierCd_Ed.Enabled = false;
                this.SupplierStGuide_Button.Enabled = false;
                this.SupplierEdGuide_Button.Enabled = false;

                // ���[�J�[
                this.checkBox_GoodsMakerCd.Enabled = false;
                this.tNedit_GoodsMakerCd_St.Enabled = false;
                this.tNedit_GoodsMakerCd_Ed.Enabled = false;
                this.GoodsMakerCdStGuide_Button.Enabled = false;
                this.GoodsMakerCdEdGuide_Button.Enabled = false;

                // �w��
                this.checkBox_GoodsRateRank.Enabled = false;
                this.tNedit_GoodsRateRank_St.Enabled = false;
                this.tNedit_GoodsRateRank_Ed.Enabled = false;

                // ���i�|���f
                this.checkBox_GoodsRateGrpCode.Enabled = false;
                this.tNedit_GoodsRateGrpCode_St.Enabled = false;
                this.tNedit_GoodsRateGrpCode_Ed.Enabled = false;
                this.ub_St_MediumGoodsGanreCodeGuide.Enabled = false;   //  ADD dingjx  2011/09/15
                this.ub_Ed_MediumGoodsGanreCodeGuide.Enabled = false;   //  ADD dingjx  2011/09/15

                // BL�R�[�h
                this.checkBox_BLGoodsCode.Enabled = false;
                this.tNedit_BLGoodsCode_St.Enabled = false;
                this.tNedit_BLGoodsCode_Ed.Enabled = false;
                this.BLGoodsCodeStGuide_Button.Enabled = false;
                this.BLGoodsCodeEdGuide_Button.Enabled = false;

                // �i��
                this.checkBox_GoodsNo.Enabled = false;
                this.tEdit_GoodsNo_St.Enabled = false;
                this.tEdit_GoodsNo_Ed.Enabled = false;
            }
            //�V�K���[�h
            else
            {
                this._saveButton.SharedProps.Visible = true;
                this._clearButton.SharedProps.Visible = true;

                this.tComboEditor_PriceKind.Enabled = true;
                this.tComboEditor_SetMethod.Enabled = true;

                // --- ADD 2012/07/26 ---------->>>>>
                // ���_
                this.checkBox_SectionCode.Enabled = true;
                this.tEdit_SectionCodeAllowZero_St.Enabled = true;
                this.tEdit_SectionCodeAllowZero_Ed.Enabled = true;
                this.SectionStGuide_Button.Enabled = true;
                this.SectionEdGuide_Button.Enabled = true;
                // --- ADD 2012/07/26 ----------<<<<<
                // ���Ӑ�|���O���[�v
                this.checkBox_CustRateGrpCode.Enabled = true;
                this.tNedit_CustRateGrpCode_St.Enabled = true;
                this.tNedit_CustRateGrpCode_Ed.Enabled = true;
                this.CustRateGrpCodeStGuide_Button.Enabled = true;
                this.CustRateGrpCodeEdGuide_Button.Enabled = true;

                // ���Ӑ�R�[�h
                this.checkBox_CustomerCode.Enabled = true;
                this.tNedit_CustomerCode_St.Enabled = true;
                this.tNedit_CustomerCode_Ed.Enabled = true;
                this.CustomerCodeStGuide_Button.Enabled = true;
                this.CustomerCodeEdGuide_Button.Enabled = true;

                // �d����R�[�h
                this.checkBox_SupplierCd.Enabled = true;
                this.tNedit_SupplierCd_St.Enabled = true;
                this.tNedit_SupplierCd_Ed.Enabled = true;
                this.SupplierStGuide_Button.Enabled = true;
                this.SupplierEdGuide_Button.Enabled = true;

                // ���[�J�[
                this.checkBox_GoodsMakerCd.Enabled = true;
                this.tNedit_GoodsMakerCd_St.Enabled = true;
                this.tNedit_GoodsMakerCd_Ed.Enabled = true;
                this.GoodsMakerCdStGuide_Button.Enabled = true;
                this.GoodsMakerCdEdGuide_Button.Enabled = true;

                // �w��
                this.checkBox_GoodsRateRank.Enabled = true;
                this.tNedit_GoodsRateRank_St.Enabled = true;
                this.tNedit_GoodsRateRank_Ed.Enabled = true;

                // ���i�|���f
                this.checkBox_GoodsRateGrpCode.Enabled = true;
                this.tNedit_GoodsRateGrpCode_St.Enabled = true;
                this.tNedit_GoodsRateGrpCode_Ed.Enabled = true;
                this.ub_St_MediumGoodsGanreCodeGuide.Enabled = true;   //  ADD dingjx  2011/09/15
                this.ub_Ed_MediumGoodsGanreCodeGuide.Enabled = true;   //  ADD dingjx  2011/09/15

                // BL�R�[�h
                this.checkBox_BLGoodsCode.Enabled = true;
                this.tNedit_BLGoodsCode_St.Enabled = true;
                this.tNedit_BLGoodsCode_Ed.Enabled = true;
                this.BLGoodsCodeStGuide_Button.Enabled = true;
                this.BLGoodsCodeEdGuide_Button.Enabled = true;

                // �i��
                this.checkBox_GoodsNo.Enabled = true;
                this.tEdit_GoodsNo_St.Enabled = true;
                this.tEdit_GoodsNo_Ed.Enabled = true;
            }
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
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            if (this._rateProcParam != null)
            {
                // �P�����
                if (_rateProcParam.UnitPriceKindRF.Equals(""))
                {
                    this.tComboEditor_PriceKind.SelectedIndex = 0;
                }
                else
                {
                    this.tComboEditor_PriceKind.SelectedIndex = Convert.ToInt32(_rateProcParam.UnitPriceKindRF);
                }

                // �ݒ���@
                if (_rateProcParam.SetFunRF.Equals(""))
                {
                    this.tComboEditor_SetMethod.SelectedIndex = 0;
                }
                else
                {
                    this.tComboEditor_SetMethod.SelectedIndex = Convert.ToInt32(_rateProcParam.SetFunRF) - 1;
                }
                // --- ADD 2012/07/26 ---------->>>>>
                // ���_
                if (string.IsNullOrEmpty(_rateProcParam.SectionCodeBeginRF) && string.IsNullOrEmpty(_rateProcParam.SectionCodeEndRF))
                {
                    //������
                    this.tEdit_SectionCodeAllowZero_St.Text = _rateProcParam.SectionCodeBeginRF;
                    this.tEdit_SectionCodeAllowZero_Ed.Text = _rateProcParam.SectionCodeEndRF;
                }
                else if (0 == _rateProcParam.SectionCodeBeginRF.CompareTo(_rateProcParam.SectionCodeEndRF))
                {
                    this.tEdit_SectionCodeAllowZero_St.Text = _rateProcParam.SectionCodeBeginRF;
                    this.checkBox_SectionCode.Checked = true;
                    this.tEdit_SectionCodeAllowZero_Ed.Enabled = false;
                }
                else
                {
                    this.tEdit_SectionCodeAllowZero_St.Text = _rateProcParam.SectionCodeBeginRF;
                    this.tEdit_SectionCodeAllowZero_Ed.Text = _rateProcParam.SectionCodeEndRF;
                }
                // --- ADD 2012/07/26 ----------<<<<<

                // ���Ӑ�|���O���[�v
                if (_rateProcParam.CustRateGrpCodeBeginRF == 0 && _rateProcParam.CustRateGrpCodeEndRF == 0)
                {
                    //������
                    this.tNedit_CustRateGrpCode_St.SetInt(Convert.ToInt32(_rateProcParam.CustRateGrpCodeBeginRF));
                    this.tNedit_CustRateGrpCode_Ed.SetInt(Convert.ToInt32(_rateProcParam.CustRateGrpCodeEndRF));
                }
                else if (Convert.ToInt32(_rateProcParam.CustRateGrpCodeBeginRF) == Convert.ToInt32(_rateProcParam.CustRateGrpCodeEndRF))
                {
                    this.tNedit_CustRateGrpCode_St.SetInt(Convert.ToInt32(_rateProcParam.CustRateGrpCodeBeginRF));
                    this.checkBox_CustRateGrpCode.Checked = true;
                    this.tNedit_CustRateGrpCode_Ed.Enabled = false;
                }
                else
                {
                    this.tNedit_CustRateGrpCode_St.SetInt(Convert.ToInt32(_rateProcParam.CustRateGrpCodeBeginRF));
                    this.tNedit_CustRateGrpCode_Ed.SetInt(Convert.ToInt32(_rateProcParam.CustRateGrpCodeEndRF));
                }

                // ���Ӑ�R�[�h
                if (_rateProcParam.CustomerCodeBeginRF == 0 && _rateProcParam.CustomerCodeEndRF == 0)
                {
                    //������
                    this.tNedit_CustomerCode_St.SetInt(Convert.ToInt32(_rateProcParam.CustomerCodeBeginRF));
                    this.tNedit_CustomerCode_Ed.SetInt(Convert.ToInt32(_rateProcParam.CustomerCodeEndRF));
                }
                else if (Convert.ToInt32(_rateProcParam.CustomerCodeBeginRF) == Convert.ToInt32(_rateProcParam.CustomerCodeEndRF))
                {
                    this.tNedit_CustomerCode_St.SetInt(Convert.ToInt32(_rateProcParam.CustomerCodeBeginRF));
                    this.checkBox_CustomerCode.Checked = true;
                    this.tNedit_CustomerCode_Ed.Enabled = false;
                }
                else
                {
                    this.tNedit_CustomerCode_St.SetInt(Convert.ToInt32(_rateProcParam.CustomerCodeBeginRF));
                    this.tNedit_CustomerCode_Ed.SetInt(Convert.ToInt32(_rateProcParam.CustomerCodeEndRF));
                }
                
                // �d����
                if (_rateProcParam.SupplierCdBeginRF == 0 && _rateProcParam.SupplierCdEndRF == 0)
                {
                    //������
                    this.tNedit_SupplierCd_St.SetInt(Convert.ToInt32(_rateProcParam.SupplierCdBeginRF));
                    this.tNedit_SupplierCd_Ed.SetInt(Convert.ToInt32(_rateProcParam.SupplierCdEndRF));
                }
                else if (Convert.ToInt32(_rateProcParam.SupplierCdBeginRF) == Convert.ToInt32(_rateProcParam.SupplierCdEndRF))
                {
                    this.tNedit_SupplierCd_St.SetInt(Convert.ToInt32(_rateProcParam.SupplierCdBeginRF));
                    this.checkBox_SupplierCd.Checked = true;
                    this.tNedit_SupplierCd_Ed.Enabled = false;
                }
                else
                {
                    this.tNedit_SupplierCd_St.SetInt(Convert.ToInt32(_rateProcParam.SupplierCdBeginRF));
                    this.tNedit_SupplierCd_Ed.SetInt(Convert.ToInt32(_rateProcParam.SupplierCdEndRF));
                }

                // ���[�J�[
                if (_rateProcParam.GoodsMakerCdBeginRF == 0 && _rateProcParam.GoodsMakerCdEndRF == 0)
                {
                    //������
                    this.tNedit_GoodsMakerCd_St.SetInt(Convert.ToInt32(_rateProcParam.GoodsMakerCdBeginRF));
                    this.tNedit_GoodsMakerCd_Ed.SetInt(Convert.ToInt32(_rateProcParam.GoodsMakerCdEndRF));
                }
                else if (Convert.ToInt32(_rateProcParam.GoodsMakerCdBeginRF) == Convert.ToInt32(_rateProcParam.GoodsMakerCdEndRF))
                {
                    this.tNedit_GoodsMakerCd_St.SetInt(Convert.ToInt32(_rateProcParam.GoodsMakerCdBeginRF));
                    this.checkBox_GoodsMakerCd.Checked = true;
                    this.tNedit_GoodsMakerCd_Ed.Enabled = false;
                }
                else
                {
                    this.tNedit_GoodsMakerCd_St.SetInt(Convert.ToInt32(_rateProcParam.GoodsMakerCdBeginRF));
                    this.tNedit_GoodsMakerCd_Ed.SetInt(Convert.ToInt32(_rateProcParam.GoodsMakerCdEndRF));
                }

                // �w��
                if (_rateProcParam.GoodsRateRankBeginRF.Equals("") && _rateProcParam.GoodsRateRankEndRF.Equals(""))
                {
                    //������
                    this.tNedit_GoodsRateRank_St.Text = "";
                    this.tNedit_GoodsRateRank_Ed.Text = "";
                }else if (!_rateProcParam.GoodsRateRankBeginRF.Equals("") && !_rateProcParam.GoodsRateRankEndRF.Equals("")
                    && _rateProcParam.GoodsRateRankBeginRF.CompareTo(_rateProcParam.GoodsRateRankEndRF) == 0)
                {
                    this.tNedit_GoodsRateRank_St.Text = _rateProcParam.GoodsRateRankBeginRF;
                    this.checkBox_GoodsRateRank.Checked = true;
                    this.tNedit_GoodsRateRank_Ed.Enabled = false;
                }
                else
                {
                    if (!_rateProcParam.GoodsRateRankBeginRF.Equals(""))
                        this.tNedit_GoodsRateRank_St.Text = _rateProcParam.GoodsRateRankBeginRF;
                        //this.tNedit_GoodsRateRank_St.SetInt(Convert.ToInt32(_rateProcParam.GoodsRateRankBeginRF));
                    if (! _rateProcParam.GoodsRateRankEndRF.Equals(""))
                        this.tNedit_GoodsRateRank_Ed.Text = _rateProcParam.GoodsRateRankEndRF; ;
                }

                // ���i�|���f
                if (_rateProcParam.GoodsRateGrpCodeBeginRF == 0 && _rateProcParam.GoodsRateGrpCodeEndRF == 0)
                {
                    //������
                    this.tNedit_GoodsRateGrpCode_St.SetInt(Convert.ToInt32(_rateProcParam.GoodsRateGrpCodeBeginRF));
                    this.tNedit_GoodsRateGrpCode_St.SetInt(Convert.ToInt32(_rateProcParam.GoodsRateGrpCodeEndRF));
                }
                else if (Convert.ToInt32(_rateProcParam.GoodsRateGrpCodeBeginRF) == Convert.ToInt32(_rateProcParam.GoodsRateGrpCodeEndRF))
                {
                    this.tNedit_GoodsRateGrpCode_St.SetInt(Convert.ToInt32(_rateProcParam.GoodsRateGrpCodeBeginRF));
                    this.checkBox_GoodsRateGrpCode.Checked = true;
                    this.tNedit_GoodsRateGrpCode_Ed.Enabled = false;
                }
                else
                {
                    this.tNedit_GoodsRateGrpCode_St.SetInt(Convert.ToInt32(_rateProcParam.GoodsRateGrpCodeBeginRF));
                    this.tNedit_GoodsRateGrpCode_Ed.SetInt(Convert.ToInt32(_rateProcParam.GoodsRateGrpCodeEndRF));
                }

                // BL�R�[�h
                if (_rateProcParam.BLGoodsCodeBeginRF == 0 && _rateProcParam.BLGoodsCodeEndRF == 0)
                {
                    //������
                    this.tNedit_BLGoodsCode_St.SetInt(Convert.ToInt32(_rateProcParam.BLGoodsCodeBeginRF));
                    this.tNedit_BLGoodsCode_Ed.SetInt(Convert.ToInt32(_rateProcParam.BLGoodsCodeEndRF));
                }
                else if(Convert.ToInt32(_rateProcParam.BLGoodsCodeBeginRF) == Convert.ToInt32(_rateProcParam.BLGoodsCodeEndRF))
                {
                    this.tNedit_BLGoodsCode_St.SetInt(Convert.ToInt32(_rateProcParam.BLGoodsCodeBeginRF));
                    this.checkBox_BLGoodsCode.Checked = true;
                    this.tNedit_BLGoodsCode_Ed.Enabled = false;
                }
                else
                {
                    this.tNedit_BLGoodsCode_St.SetInt(Convert.ToInt32(_rateProcParam.BLGoodsCodeBeginRF));
                    this.tNedit_BLGoodsCode_Ed.SetInt(Convert.ToInt32(_rateProcParam.BLGoodsCodeEndRF));
                }

                // �i��
                if (_rateProcParam.GoodsNoBeginRF.Equals("") && _rateProcParam.GoodsNoEndRF.Equals(""))
                {
                    //������
                    this.tEdit_GoodsNo_St.Text = "";
                    this.tEdit_GoodsNo_Ed.Text = "";
                    if (this.tComboEditor_SetMethod.SelectedIndex == 0)
                    {
                        this.checkBox_GoodsNo.Checked = false;
                        this.checkBox_GoodsNo.Enabled = false;
                        this.tEdit_GoodsNo_St.Enabled = false;
                        this.tEdit_GoodsNo_Ed.Enabled = false;
                    }
                }else if (_rateProcParam.GoodsNoBeginRF.CompareTo(_rateProcParam.GoodsNoEndRF) == 0)
                {
                    this.tEdit_GoodsNo_St.Text = Convert.ToString(_rateProcParam.GoodsNoBeginRF);
                    this.checkBox_GoodsNo.Checked = true;
                    this.tEdit_GoodsNo_Ed.Enabled = false;
                }
                else
                {
                    this.tEdit_GoodsNo_St.Text = _rateProcParam.GoodsNoBeginRF;
                    this.tEdit_GoodsNo_Ed.Text = _rateProcParam.GoodsNoEndRF;
                }
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
        /// <br>Programmer	: �����Y</br>	
        /// <br>Date		: 2011.08.08</br>
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
        /// <br>Programmer	: �����Y</br>	
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        private void Save()
        {
            // --- DEL 2012/07/26 ---------->>>>>
            //string errMessage = "";
            // ��ʃf�[�^�`�F�b�N����
            //if (!this.ScreenInputCheck(ref errMessage))
            //{
            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                //�t�H�[�J�X���d����J�n�ֈړ�
            //    switch (_flag)
            //    {
            //        case 1:
            //            {
            //                if (this.tNedit_CustRateGrpCode_St.Enabled)
            //                {
            //                    this.tNedit_CustRateGrpCode_St.Focus();
            //                }
            //            }
            //            break;
            //        case 2:
            //            {
            //                if (this.tNedit_CustomerCode_St.Enabled)
            //                {
            //                    this.tNedit_CustomerCode_St.Focus();
            //                }
            //            }
            //            break;
            //        case 3:
            //            {
            //                if (this.tNedit_SupplierCd_St.Enabled)
            //                {
            //                    this.tNedit_SupplierCd_St.Focus();
            //                }
            //            }
            //            break;
            //        case 4:
            //            {
            //                if (this.tNedit_GoodsMakerCd_St.Enabled)
            //                {
            //                    this.tNedit_GoodsMakerCd_St.Focus();
            //                }
            //            }
            //            break;
            //        case 5:
            //            {
            //                if (this.tNedit_GoodsRateRank_St.Enabled)
            //                {
            //                    this.tNedit_GoodsRateRank_St.Focus();
            //                }
            //            }
            //            break;
            //        case 6:
            //            {
            //                if (this.tNedit_GoodsRateGrpCode_St.Enabled)
            //                {
            //                    this.tNedit_GoodsRateGrpCode_St.Focus();
            //                }
            //            }
            //            break;
            //        case 7:
            //            {
            //                if (this.tNedit_BLGoodsCode_St.Enabled)
            //                {
            //                    this.tNedit_BLGoodsCode_St.Focus();
            //                }
            //            }
            //            break;
            //        case 8:
            //            {
            //                if (this.tEdit_GoodsNo_St.Enabled)
            //                {
            //                    this.tEdit_GoodsNo_St.Focus();
            //                }
            //            }
            //            break;
            //    }
                
            //    return;
            //}
            // --- DEL 2012/07/26 ----------<<<<<
            // --- ADD 2012/07/26 ---------->>>>>
            string errMessage = "";
            Control errCtrl = null;
            // ��ʃf�[�^�`�F�b�N����
            if (!this.ScreenInputCheck(out errCtrl, ref errMessage))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                // �t�H�[�J�X���G���[���ڂֈړ�
                if (null != errCtrl && errCtrl.Enabled)
                {
                    errCtrl.Focus();
                }
                
                return;
            }
            // --- ADD 2012/07/26 ----------<<<<<
            if (_rateProcParam == null)
            {
                _rateProcParam = new APRateProcParamWork();
            }
            else
            {
                // �P�����
                //_rateProcParam.UnitPriceKindRF = this.tComboEditor_PriceKind.SelectedIndex.ToString();//DEL 2011.08.25
                //-----ADD 2011.08.25----->>>>>
                if (this.tComboEditor_PriceKind.SelectedIndex == 0)
                {
                    _rateProcParam.UnitPriceKindRF = string.Empty;
                }
                else
                {
                    _rateProcParam.UnitPriceKindRF = this.tComboEditor_PriceKind.SelectedIndex.ToString();
                }
                //-----ADD 2011.08.25-----<<<<<

                // �ݒ���@
                _rateProcParam.SetFunRF = (this.tComboEditor_SetMethod.SelectedIndex + 1).ToString();

                // --- ADD 2012/07/26 ---------->>>>>
                // ���_
                if (this.checkBox_SectionCode.Checked)
                {
                    _rateProcParam.SectionCodeBeginRF = this.tEdit_SectionCodeAllowZero_St.Text;
                    _rateProcParam.SectionCodeEndRF = this.tEdit_SectionCodeAllowZero_St.Text;
                }
                else
                {
                    _rateProcParam.SectionCodeBeginRF = this.tEdit_SectionCodeAllowZero_St.Text;
                    _rateProcParam.SectionCodeEndRF = this.tEdit_SectionCodeAllowZero_Ed.Text;
                }
                // --- ADD 2012/07/26 ----------<<<<<
                // ���Ӑ�|���O���[�v
                if (this.checkBox_CustRateGrpCode.Checked)
                {
                    _rateProcParam.CustRateGrpCodeBeginRF = this.tNedit_CustRateGrpCode_St.GetInt();
                    _rateProcParam.CustRateGrpCodeEndRF = this.tNedit_CustRateGrpCode_St.GetInt();
                }
                else
                {
                    _rateProcParam.CustRateGrpCodeBeginRF = this.tNedit_CustRateGrpCode_St.GetInt();
                    _rateProcParam.CustRateGrpCodeEndRF = this.tNedit_CustRateGrpCode_Ed.GetInt();
                }

                // ���Ӑ�R�[�h
                if (this.checkBox_CustomerCode.Checked)
                {
                    _rateProcParam.CustomerCodeBeginRF = this.tNedit_CustomerCode_St.GetInt();
                    _rateProcParam.CustomerCodeEndRF = this.tNedit_CustomerCode_St.GetInt();
                }
                else
                {
                    _rateProcParam.CustomerCodeBeginRF = this.tNedit_CustomerCode_St.GetInt();
                    _rateProcParam.CustomerCodeEndRF = this.tNedit_CustomerCode_Ed.GetInt();
                }

                // �d����
                if (this.checkBox_SupplierCd.Checked)
                {
                    _rateProcParam.SupplierCdBeginRF = this.tNedit_SupplierCd_St.GetInt();
                    _rateProcParam.SupplierCdEndRF = this.tNedit_SupplierCd_St.GetInt();
                }
                else
                {
                    _rateProcParam.SupplierCdBeginRF = this.tNedit_SupplierCd_St.GetInt();
                    _rateProcParam.SupplierCdEndRF = this.tNedit_SupplierCd_Ed.GetInt();
                }

                // ���[�J�[
                if (this.checkBox_GoodsMakerCd.Checked)
                {
                    _rateProcParam.GoodsMakerCdBeginRF = this.tNedit_GoodsMakerCd_St.GetInt();
                    _rateProcParam.GoodsMakerCdEndRF = this.tNedit_GoodsMakerCd_St.GetInt();
                }
                else
                {
                    _rateProcParam.GoodsMakerCdBeginRF = this.tNedit_GoodsMakerCd_St.GetInt();
                    _rateProcParam.GoodsMakerCdEndRF = this.tNedit_GoodsMakerCd_Ed.GetInt();
                }

                // �w��
                if (this.checkBox_GoodsRateRank.Checked)
                {
                    _rateProcParam.GoodsRateRankBeginRF = this.tNedit_GoodsRateRank_St.Text;
                    _rateProcParam.GoodsRateRankEndRF = this.tNedit_GoodsRateRank_St.Text;
                }
                else
                {
                    _rateProcParam.GoodsRateRankBeginRF = this.tNedit_GoodsRateRank_St.Text;
                    _rateProcParam.GoodsRateRankEndRF = this.tNedit_GoodsRateRank_Ed.Text;
                }

                // ���i�|���f
                if (this.checkBox_GoodsRateGrpCode.Checked)
                {
                    _rateProcParam.GoodsRateGrpCodeBeginRF = this.tNedit_GoodsRateGrpCode_St.GetInt();
                    _rateProcParam.GoodsRateGrpCodeEndRF = this.tNedit_GoodsRateGrpCode_St.GetInt();
                }
                else
                {
                    _rateProcParam.GoodsRateGrpCodeBeginRF = this.tNedit_GoodsRateGrpCode_St.GetInt();
                    _rateProcParam.GoodsRateGrpCodeEndRF = this.tNedit_GoodsRateGrpCode_Ed.GetInt();
                }

                // BL�R�[�h
                if (this.checkBox_BLGoodsCode.Checked)
                {
                    _rateProcParam.BLGoodsCodeBeginRF = this.tNedit_BLGoodsCode_St.GetInt();
                    _rateProcParam.BLGoodsCodeEndRF = this.tNedit_BLGoodsCode_St.GetInt();
                }
                else
                {
                    _rateProcParam.BLGoodsCodeBeginRF = this.tNedit_BLGoodsCode_St.GetInt();
                    _rateProcParam.BLGoodsCodeEndRF = this.tNedit_BLGoodsCode_Ed.GetInt();
                }

                // �i��
                if (this.checkBox_GoodsNo.Checked)
                {
                    _rateProcParam.GoodsNoBeginRF = this.tEdit_GoodsNo_St.Text;
                    _rateProcParam.GoodsNoEndRF = this.tEdit_GoodsNo_St.Text;
                }
                else
                {
                    _rateProcParam.GoodsNoBeginRF = this.tEdit_GoodsNo_St.Text;
                    _rateProcParam.GoodsNoEndRF = this.tEdit_GoodsNo_Ed.Text;
                }
            }

            //�ۑ������������ʂ����
            this.Close();
        }

        /// <summary>
        /// �N���A����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �N���A�����ł��B</br>
        /// <br>Programmer	: �����Y</br>	
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        private void Clear()
        {
            // �P�����
            this.tComboEditor_PriceKind.SelectedIndex = 0;
            // �ݒ���@
            this.tComboEditor_SetMethod.SelectedIndex = 0;
            // --- ADD 2012/07/26 ---------->>>>>
            // ���_
            this.checkBox_SectionCode.Checked = false;
            this.tEdit_SectionCodeAllowZero_St.Text = String.Empty;
            this.tEdit_SectionCodeAllowZero_Ed.Text = String.Empty;
            // --- ADD 2012/07/26 ----------<<<<<
            // ���Ӑ�|���O���[�v
            this.checkBox_CustRateGrpCode.Checked = false;
            this.tNedit_CustRateGrpCode_St.SetInt(0);
            this.tNedit_CustRateGrpCode_Ed.SetInt(0);
            // ���Ӑ�R�[�h
            this.checkBox_CustomerCode.Checked = false;
            this.tNedit_CustomerCode_St.SetInt(0);
            this.tNedit_CustomerCode_Ed.SetInt(0);
            // �d����
            this.checkBox_SupplierCd.Checked = false;
            this.tNedit_SupplierCd_St.SetInt(0);
            this.tNedit_SupplierCd_Ed.SetInt(0);
            // ���[�J�[
            this.checkBox_GoodsMakerCd.Checked = false;
            this.tNedit_GoodsMakerCd_St.SetInt(0);
            this.tNedit_GoodsMakerCd_Ed.SetInt(0);
            // �w��
            this.checkBox_GoodsRateRank.Checked = false;
            this.tNedit_GoodsRateRank_St.Text = String.Empty;
            this.tNedit_GoodsRateRank_Ed.Text = String.Empty;
            // ���i�|���f
            this.checkBox_GoodsRateGrpCode.Checked = false;
            this.tNedit_GoodsRateGrpCode_St.SetInt(0);
            this.tNedit_GoodsRateGrpCode_Ed.SetInt(0);
            // BL�R�[�h
            this.checkBox_BLGoodsCode.Checked = false;
            this.tNedit_BLGoodsCode_St.SetInt(0);
            this.tNedit_BLGoodsCode_Ed.SetInt(0);
            // �i��
            this.checkBox_GoodsNo.Checked = false;
            this.tEdit_GoodsNo_St.Text = String.Empty;
            this.tEdit_GoodsNo_Ed.Text = String.Empty;
            // --- ADD 2012/07/26 ---------->>>>>
            this.tComboEditor_PriceKind.Focus();
            // --- ADD 2012/07/26 ----------<<<<<
        }

        #endregion region �� �c�[���o�[���� ��

        #region �� Event ��

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�����[�h�C�x���g�����������܂��B</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // --- ADD 2012/07/26 ---------->>>>>
                // ���_
                case "tEdit_SectionCodeAllowZero_St":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero_St.DataText))
                            this.tEdit_SectionCodeAllowZero_St.DataText = this.tEdit_SectionCodeAllowZero_St.DataText.PadLeft(this.tEdit_SectionCodeAllowZero_St.MaxLength, '0');
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tEdit_SectionCodeAllowZero_St.DataText))
                                {
                                    if (this.tEdit_SectionCodeAllowZero_Ed.Enabled == false)
                                    {
                                        if (this.tComboEditor_PriceKind.SelectedIndex == 2)
                                        {
                                            e.NextCtrl = this.checkBox_SupplierCd;

                                            if (this.tComboEditor_SetMethod.SelectedIndex == 1)
                                            {
                                                e.NextCtrl = checkBox_GoodsMakerCd;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = checkBox_CustRateGrpCode;
                                        }
                                    }
                                    else
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero_Ed;
                                    }
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
                case "tEdit_SectionCodeAllowZero_Ed":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero_Ed.DataText))
                            this.tEdit_SectionCodeAllowZero_Ed.DataText = this.tEdit_SectionCodeAllowZero_Ed.DataText.PadLeft(this.tEdit_SectionCodeAllowZero_Ed.MaxLength, '0');
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tEdit_SectionCodeAllowZero_Ed.DataText))
                                {
                                    if (this.tComboEditor_PriceKind.SelectedIndex == 2)
                                    {
                                        e.NextCtrl = this.checkBox_SupplierCd;

                                        if (this.tComboEditor_SetMethod.SelectedIndex == 1)
                                        {
                                            e.NextCtrl = checkBox_GoodsMakerCd;
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = checkBox_CustRateGrpCode;
                                    }
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

                // --- ADD 2012/07/26 ----------<<<<<
                // ���Ӑ�|���O���[�v
                case "tNedit_CustRateGrpCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_CustRateGrpCode_St.GetInt() > 0)
                                {
                                    if (this.tNedit_CustRateGrpCode_Ed.Enabled == false)
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        // --- DEL 2012/07/26 ---------->>>>>
                                        //e.NextCtrl = this.tNedit_CustomerCode_St;
                                        // --- DEL 2012/07/26 ----------<<<<<
                                        // --- ADD 2012/07/26 ---------->>>>>
                                        e.NextCtrl = this.checkBox_CustomerCode;
                                        // --- ADD 2012/07/26 ----------<<<<<
                                    }
                                    else
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.tNedit_CustRateGrpCode_Ed;
                                    }
                                    
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.CustRateGrpCodeStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_CustRateGrpCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_CustRateGrpCode_Ed.GetInt() > 0)
                                {
                                    // --- DEL 2012/07/26 ---------->>>>>
                                    // �t�H�[�J�X�ݒ�
                                    //e.NextCtrl = this.tNedit_CustomerCode_St;
                                    // --- DEL 2012/07/26 ----------<<<<<
                                    // --- ADD 2012/07/26 ---------->>>>>
                                    e.NextCtrl = this.checkBox_CustomerCode;
                                    // --- ADD 2012/07/26 ----------<<<<<
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.CustRateGrpCodeEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                // ���Ӑ�R�[�h
                case "tNedit_CustomerCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_CustomerCode_St.GetInt() > 0)
                                {
                                    if (this.tNedit_CustomerCode_Ed.Enabled == false)
                                    {
                                        if (this.tNedit_SupplierCd_St.Enabled == true)
                                        {
                                            // �t�H�[�J�X�ݒ�
                                            // --- DEL 2012/07/26 ---------->>>>>
                                            //e.NextCtrl = this.tNedit_SupplierCd_St;
                                            // --- DEL 2012/07/26 ----------<<<<<
                                            // --- ADD 2012/07/26 ---------->>>>>
                                            e.NextCtrl = this.checkBox_SupplierCd;
                                            // --- ADD 2012/07/26 ----------<<<<<

                                        }else{
                                            // �t�H�[�J�X�ݒ�
                                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                                        }
                                       
                                    }
                                    else 
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                    }
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.CustomerCodeStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_CustomerCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_CustomerCode_Ed.GetInt() > 0)
                                {
                                    if (this.tNedit_SupplierCd_St.Enabled == false)
                                    {
                                        // --- DEL 2012/07/26 ---------->>>>>
                                        // �t�H�[�J�X�ݒ�
                                        //e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                                        // --- DEL 2012/07/26 ----------<<<<<
                                        // --- ADD 2012/07/26 ---------->>>>>
                                        if (this.tComboEditor_SetMethod.SelectedIndex == 1)
                                        {
                                            // �t�H�[�J�X�ݒ�
                                            e.NextCtrl = this.checkBox_GoodsMakerCd;
                                        }
                                        else
                                        {
                                            // �t�H�[�J�X�ݒ�
                                            e.NextCtrl = this.checkBox_SupplierCd;
                                        }
                                        // --- ADD 2012/07/26 ----------<<<<<
                                    }
                                    else
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        // --- DEL 2012/07/26 ---------->>>>>
                                        //e.NextCtrl = this.tNedit_SupplierCd_St;
                                        // --- DEL 2012/07/26 ----------<<<<<
                                        // --- ADD 2012/07/26 ---------->>>>>
                                        e.NextCtrl = this.checkBox_SupplierCd;
                                        // --- ADD 2012/07/26 ----------<<<<<
                                    }
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.CustomerCodeEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                // �d����
                case "tNedit_SupplierCd_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SupplierCd_St.GetInt() > 0)
                                {
                                    if (this.tNedit_SupplierCd_Ed.Enabled == false)
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        // --- DEL 2012/07/26 ---------->>>>>
                                        //e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                                        // --- DEL 2012/07/26 ----------<<<<<
                                        // --- ADD 2012/07/26 ---------->>>>>
                                        e.NextCtrl = this.checkBox_GoodsMakerCd;
                                        // --- ADD 2012/07/26 ----------<<<<<
                                    }
                                    else
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                                    }
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.SupplierStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SupplierCd_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SupplierCd_Ed.GetInt() > 0)
                                {
                                    // --- DEL 2012/07/26 ---------->>>>>
                                    // �t�H�[�J�X�ݒ�
                                    //e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                                    // --- DEL 2012/07/26 ----------<<<<<
                                    // --- ADD 2012/07/26 ---------->>>>>
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.checkBox_GoodsMakerCd;
                                    // --- ADD 2012/07/26 ----------<<<<<
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.SupplierEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }

                // ���[�J�[
                case "tNedit_GoodsMakerCd_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_GoodsMakerCd_St.GetInt() > 0)
                                {
                                    if (this.tNedit_GoodsMakerCd_Ed.Enabled == false)
                                    {
                                        if (this.tNedit_GoodsRateRank_St.Enabled == false)
                                        {
                                            // �t�H�[�J�X�ݒ�
                                            // --- DEL 2012/07/26 ---------->>>>>
                                            //e.NextCtrl = this.tEdit_GoodsNo_St;
                                            // --- DEL 2012/07/26 ----------<<<<<
                                            // --- ADD 2012/07/26 ---------->>>>>
                                            e.NextCtrl = this.checkBox_GoodsNo;
                                            // --- ADD 2012/07/26 ----------<<<<<
                                        }
                                        else
                                        {
                                            // �t�H�[�J�X�ݒ�
                                            // --- DEL 2012/07/26 ---------->>>>>
                                            //e.NextCtrl = this.tNedit_GoodsRateRank_St;
                                            // --- DEL 2012/07/26 ----------<<<<<
                                            // --- ADD 2012/07/26 ---------->>>>>
                                            e.NextCtrl = this.checkBox_GoodsRateRank;
                                            // --- ADD 2012/07/26 ----------<<<<<
                                        }
                                        
                                    }
                                    else
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                                    }
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.GoodsMakerCdStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_GoodsMakerCd_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_GoodsMakerCd_Ed.GetInt() > 0)
                                {
                                    if (this.tNedit_GoodsRateRank_St.Enabled == false)
                                    {
                                        // --- DEL 2012/07/26 ---------->>>>>
                                        // �t�H�[�J�X�ݒ�
                                        //e.NextCtrl = this.tEdit_GoodsNo_St;
                                        // --- DEL 2012/07/26 ----------<<<<<
                                        // --- ADD 2012/07/26 ---------->>>>>
                                        if (this.tComboEditor_SetMethod.SelectedIndex == 1)
                                        {
                                            // �t�H�[�J�X�ݒ�
                                            e.NextCtrl = this.checkBox_GoodsNo;
                                        }
                                        else
                                        {
                                            // �t�H�[�J�X�ݒ�
                                            e.NextCtrl = this.checkBox_GoodsRateRank;
                                        }
                                        // --- ADD 2012/07/26 ----------<<<<<
                                    }
                                    else
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        // --- DEL 2012/07/26 ---------->>>>>
                                        //e.NextCtrl = this.tNedit_GoodsRateRank_St;
                                        // --- DEL 2012/07/26 ----------<<<<<
                                        // --- ADD 2012/07/26 ---------->>>>>
                                        e.NextCtrl = this.checkBox_GoodsRateRank;
                                        // --- ADD 2012/07/26 ----------<<<<<
                                    }
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.GoodsMakerCdEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }

                // �w��
                case "tNedit_GoodsRateRank_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_GoodsRateRank_Ed.Enabled == false)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    // --- DEL 2012/07/26 ---------->>>>>
                                    //e.NextCtrl = this.tNedit_GoodsRateGrpCode_St;
                                    // --- DEL 2012/07/26 ----------<<<<<
                                    // --- ADD 2012/07/26 ---------->>>>>
                                    e.NextCtrl = this.checkBox_GoodsRateGrpCode;
                                    // --- ADD 2012/07/26 ----------<<<<<
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_GoodsRateRank_Ed;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_GoodsRateRank_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // --- DEL 2012/07/26 ---------->>>>>
                                // �t�H�[�J�X�ݒ�
                                //e.NextCtrl = this.tNedit_GoodsRateGrpCode_St;
                                // --- DEL 2012/07/26 ----------<<<<<
                                // --- ADD 2012/07/26 ---------->>>>>
                                // �t�H�[�J�X�ݒ�
                                e.NextCtrl = this.checkBox_GoodsRateGrpCode;
                                // --- ADD 2012/07/26 ----------<<<<<
                            }
                        }
                        break;
                    }

                // ���i�|���f
                case "tNedit_GoodsRateGrpCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
								// DEL 2011.09.07 ------->>>>>
								//if (this.tNedit_GoodsRateGrpCode_Ed.Enabled == false)
								//{
								//    // �t�H�[�J�X�ݒ�
								//    e.NextCtrl = this.tNedit_BLGoodsCode_St;
								//}
								//else
								//{
								//    // �t�H�[�J�X�ݒ�
								//    e.NextCtrl = this.tNedit_GoodsRateGrpCode_Ed;
								//}
								// DEL 2011.09.07 -------<<<<<
								// ADD 2011.09.07 ------->>>>>
								if (this.tNedit_GoodsRateGrpCode_St.GetInt() > 0)
								{
									if (this.tNedit_GoodsRateGrpCode_Ed.Enabled == false)
									{
										// �t�H�[�J�X�ݒ�
                                        // --- DEL 2012/07/26 ---------->>>>>
										//e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                        // --- DEL 2012/07/26 ----------<<<<<
                                        // --- ADD 2012/07/26 ---------->>>>>
                                        e.NextCtrl = this.checkBox_BLGoodsCode;
                                        // --- ADD 2012/07/26 ----------<<<<<
									}
									else
									{
										// �t�H�[�J�X�ݒ�
										e.NextCtrl = this.tNedit_GoodsRateGrpCode_Ed;
									}
								}
								else
								{
									e.NextCtrl = this.ub_St_MediumGoodsGanreCodeGuide;
								}
								// ADD 2011.09.07 -------<<<<<
                            }
                        }
                        break;
                    }
                case "tNedit_GoodsRateGrpCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
							// DEL 2011.09.07 ------->>>>>
							//if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
							//{
							//    // �t�H�[�J�X�ݒ�
							//    e.NextCtrl = this.tNedit_BLGoodsCode_St;
							//}
							// DEL 2011.09.07 -------<<<<<
							// ADD 2011.09.07 ------->>>>>
							if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
							{
								if (this.tNedit_GoodsRateGrpCode_Ed.GetInt() > 0)
								{
                                    // --- DEL 2012/07/26 ---------->>>>>
                                    // �t�H�[�J�X�ݒ�
                                    //e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                    // --- DEL 2012/07/26 ----------<<<<<
                                    // --- ADD 2012/07/26 ---------->>>>>
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.checkBox_BLGoodsCode;
                                    // --- ADD 2012/07/26 ----------<<<<<
								}
								else
								{
									e.NextCtrl = this.ub_Ed_MediumGoodsGanreCodeGuide;
								}
							}
							// ADD 2011.09.07 -------<<<<<
                        }
                        break;
                    }
                // BL�R�[�h
                case "tNedit_BLGoodsCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_BLGoodsCode_St.GetInt() > 0)
                                {
                                    if (this.tNedit_BLGoodsCode_Ed.Enabled == false)
                                    {
                                        if (this.tEdit_GoodsNo_St.Enabled == true)
                                        {
                                            // �t�H�[�J�X�ݒ�
                                            // --- DEL 2012/07/26 ---------->>>>>
                                            //e.NextCtrl = this.tEdit_GoodsNo_St;
                                            // --- DEL 2012/07/26 ----------<<<<<
                                            // --- ADD 2012/07/26 ---------->>>>>
                                            e.NextCtrl = this.checkBox_GoodsNo;
                                            // --- ADD 2012/07/26 ----------<<<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tComboEditor_PriceKind;
                                        }      
                                    }
                                    else
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                                    }
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.BLGoodsCodeStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_BLGoodsCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_BLGoodsCode_Ed.GetInt() > 0)
                                {
                                    if (this.tEdit_GoodsNo_St.Enabled == false)
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.tComboEditor_PriceKind;
                                    }
                                    else
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        // --- DEL 2012/07/26 ---------->>>>>
                                        //e.NextCtrl = this.tEdit_GoodsNo_St;
                                        // --- DEL 2012/07/26 ----------<<<<<
                                        // --- ADD 2012/07/26 ---------->>>>>
                                        e.NextCtrl = this.checkBox_GoodsNo;
                                        // --- ADD 2012/07/26 ----------<<<<<
                                    }
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.BLGoodsCodeEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "BLGoodsCodeEdGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_BLGoodsCode_Ed.GetInt() <= 0)
                                {
                                    if (this.tEdit_GoodsNo_St.Enabled == false)
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.tComboEditor_PriceKind;
                                    }
                                   
                                }
                                // --- ADD 2012/07/26 ---------->>>>>
                                else
                                {
                                    if (this.tEdit_GoodsNo_St.Enabled == false)
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.tComboEditor_PriceKind;
                                    }
                                }
                                // --- ADD 2012/07/26 ----------<<<<<
                            }
                        }
                        break;
                    }

                // �i��
                case "tEdit_GoodsNo_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_GoodsNo_Ed.Enabled == false)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tComboEditor_PriceKind;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tEdit_GoodsNo_Ed;
                                }
                            }
                        }
                        break;
                    }
                case "tEdit_GoodsNo_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                e.NextCtrl = this.tComboEditor_PriceKind;
                            }
                        }
                        break;
                    }

                // �P�����
                case "tComboEditor_PriceKind":
                    {
                        if (e.ShiftKey == true)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_GoodsNo_Ed.Enabled == false)
                                {
                                    if (this.tEdit_GoodsNo_St.Enabled == true)
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.tEdit_GoodsNo_St;
                                    }
                                    // --- ADD 2012/07/26 ---------->>>>>
                                    if (this.checkBox_GoodsNo.Checked == true)
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = tEdit_GoodsNo_St;
                                    }
                                    // --- ADD 2012/07/26 ----------<<<<<
                                    else
                                    {
                                        if (this.BLGoodsCodeEdGuide_Button.Enabled == false)
                                        {
                                            // --- DEL 2012/07/26 ---------->>>>>
                                            // �t�H�[�J�X�ݒ�
                                            //e.NextCtrl = this.BLGoodsCodeStGuide_Button;
                                            // --- DEL 2012/07/26 ----------<<<<<

                                            // --- ADD 2012/07/26 ---------->>>>>
                                            if (checkBox_BLGoodsCode.Checked == true)
                                            {
                                                e.NextCtrl = BLGoodsCodeStGuide_Button;
                                            }
                                            else
                                            {
                                                // �t�H�[�J�X�ݒ�
                                                e.NextCtrl = this.BLGoodsCodeEdGuide_Button;
                                            }
                                            // --- ADD 2012/07/26 ----------<<<<<

                                        }
                                        else
                                        {
                                            // �t�H�[�J�X�ݒ�
                                            e.NextCtrl = this.BLGoodsCodeEdGuide_Button;
                                        }
                                      
                                    }
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tEdit_GoodsNo_Ed;
                                }

                            }
                        }
                        break;
                    }

                // BLGoodsCodeSt��Button
                case "BLGoodsCodeStGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_BLGoodsCode_Ed.Enabled == false)
                                {
                                    if (this.tEdit_GoodsNo_St.Enabled == true)
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.tEdit_GoodsNo_St;
                                    }
                                    else
                                    {
                                        // �t�H�[�J�X�ݒ�
                                        e.NextCtrl = this.tComboEditor_PriceKind;
                                    }
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
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
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        // --- DEL 2012/07/26 ---------->>>>>
        //private bool ScreenInputCheck(ref string errMessage)
        // --- DEL 2012/07/26 ----------<<<<<
        // --- ADD 2012/07/26 ---------->>>>>
        private bool ScreenInputCheck(out Control errCtrl, ref string errMessage)
        // --- ADD 2012/07/26 ----------<<<<<
        {
            // --- DEL 2012/07/26 ---------->>>>>
            //_flag = 0;
            // --- DEL 2012/07/26 ----------<<<<<
            bool status = true;
            // --- ADD 2012/07/26 ---------->>>>>
            errCtrl = null;
            // --- ADD 2012/07/26 ----------<<<<<
            const string ct_RangeError = "�͈̔͂��s���ł��B";

            // --- ADD 2012/07/26 ---------->>>>>
            bool isEmptySectionCodeSt = string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero_St.DataText.Trim());
            bool isEmptySectionCodeEd = string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero_Ed.DataText.Trim());

            // �ꊇ�[���l�ߏ���
            uiSetControl1.SettingAllControlsZeroPaddedText();

            if (!isEmptySectionCodeSt)
                this.tEdit_SectionCodeAllowZero_St.DataText = this.tEdit_SectionCodeAllowZero_St.DataText.PadLeft(this.tEdit_SectionCodeAllowZero_St.MaxLength, '0');
            if (!isEmptySectionCodeEd)
                this.tEdit_SectionCodeAllowZero_Ed.DataText = this.tEdit_SectionCodeAllowZero_Ed.DataText.PadLeft(this.tEdit_SectionCodeAllowZero_Ed.MaxLength, '0');

            // ���_
            if (String.Compare(this.tEdit_SectionCodeAllowZero_Ed.Text, "0") > 0 && String.Compare(this.tEdit_SectionCodeAllowZero_St.Text, this.tEdit_SectionCodeAllowZero_Ed.Text) > 0)
            {
                errMessage = "���_" + ct_RangeError;
                status = false;
                errCtrl = tEdit_SectionCodeAllowZero_St;
                return status;
            }
            // --- ADD 2012/07/26 ----------<<<<<
            // ���Ӑ�|���O���[�v
            if (this.tNedit_CustRateGrpCode_Ed.GetInt() > 0 && this.tNedit_CustRateGrpCode_St.GetInt() > this.tNedit_CustRateGrpCode_Ed.GetInt())
            {
                errMessage = "���Ӑ�|���O���[�v" + ct_RangeError;
                status = false;
                // --- DEL 2012/07/26 ---------->>>>>
                //_flag = 1;
                // --- DEL 2012/07/26 ----------<<<<<
                // --- ADD 2012/07/26 ---------->>>>>
                errCtrl = tNedit_CustRateGrpCode_St;
                // --- ADD 2012/07/26 ----------<<<<<
                return status;
            }
            // ���Ӑ�R�[�h
            if (this.tNedit_CustomerCode_Ed.GetInt() > 0 && this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
            {
                errMessage = "���Ӑ�R�[�h" + ct_RangeError;
                status = false;
                // --- DEL 2012/07/26 ---------->>>>>
                //_flag = 2;
                // --- DEL 2012/07/26 ----------<<<<<
                // --- ADD 2012/07/26 ---------->>>>>
                errCtrl = tNedit_CustomerCode_St;
                // --- ADD 2012/07/26 ----------<<<<<
                return status;
            }
            // �d����
            if (this.tNedit_SupplierCd_Ed.GetInt() > 0 && this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt())
            {
                errMessage = "�d����" + ct_RangeError;
                status = false;
                // --- DEL 2012/07/26 ---------->>>>>
                //_flag = 3;
                // --- DEL 2012/07/26 ----------<<<<<
                // --- ADD 2012/07/26 ---------->>>>>
                errCtrl = tNedit_SupplierCd_St;
                // --- ADD 2012/07/26 ----------<<<<<
                return status;
            }
            // ���[�J�[
            if (this.tNedit_GoodsMakerCd_Ed.GetInt() > 0 && this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = "���[�J�[" + ct_RangeError;
                status = false;
                // --- DEL 2012/07/26 ---------->>>>>
                //_flag = 4;
                // --- DEL 2012/07/26 ----------<<<<<
                // --- ADD 2012/07/26 ---------->>>>>
                errCtrl = tNedit_GoodsMakerCd_St;
                // --- ADD 2012/07/26 ----------<<<<<
                return status;
            }
            // �w��
            if (String.Compare(this.tNedit_GoodsRateRank_Ed.Text, "0") > 0 && String.Compare(this.tNedit_GoodsRateRank_St.Text, this.tNedit_GoodsRateRank_Ed.Text) > 0)
            {
                errMessage = "�w��" + ct_RangeError;
                status = false;
                // --- DEL 2012/07/26 ---------->>>>>
                //_flag = 5;
                // --- DEL 2012/07/26 ----------<<<<<
                // --- ADD 2012/07/26 ---------->>>>>
                errCtrl = tNedit_GoodsRateRank_St;
                // --- ADD 2012/07/26 ----------<<<<<
                return status;
            }
            // ���i�|���f
            if (this.tNedit_GoodsRateGrpCode_Ed.GetInt() > 0 && this.tNedit_GoodsRateGrpCode_St.GetInt() > this.tNedit_GoodsRateGrpCode_Ed.GetInt())
            {
                errMessage = "���i�|���f" + ct_RangeError;
                status = false;
                // --- DEL 2012/07/26 ---------->>>>>
                //_flag = 6;
                // --- DEL 2012/07/26 ----------<<<<<
                // --- ADD 2012/07/26 ---------->>>>>
                errCtrl = tNedit_GoodsRateGrpCode_St;
                // --- ADD 2012/07/26 ----------<<<<<
                return status;
            }
            // BL�R�[�h
            if (this.tNedit_BLGoodsCode_Ed.GetInt() > 0 && this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                errMessage = "BL�R�[�h" + ct_RangeError;
                status = false;
                // --- DEL 2012/07/26 ---------->>>>>
                //_flag = 7;
                // --- DEL 2012/07/26 ----------<<<<<
                // --- ADD 2012/07/26 ---------->>>>>
                errCtrl = tNedit_BLGoodsCode_St;
                // --- ADD 2012/07/26 ----------<<<<<
                return status;
            }
            // �i��
            if (String.Compare(this.tEdit_GoodsNo_Ed.Text, "0") > 0 && String.Compare(this.tEdit_GoodsNo_St.Text, this.tEdit_GoodsNo_Ed.Text) > 0)
            {
                errMessage = "�i��" + ct_RangeError;
                status = false;
                // --- DEL 2012/07/26 ---------->>>>>
                //_flag = 8;
                // --- DEL 2012/07/26 ----------<<<<<
                // --- ADD 2012/07/26 ---------->>>>>
                errCtrl = tEdit_GoodsNo_St;
                // --- ADD 2012/07/26 ----------<<<<<
                return status;
            }

            return status;
        }

        /// <summary>
        /// Control.Click �C�x���g(SupplierGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �d����K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����Y</br>
        /// <br>Date        : 2011.08.08</br>
        /// </remarks>
        private void SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            Supplier supplier;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, this._loginSectionCode);
                if (status == 0)
                {
                    if ("SupplierStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                        // --- ADD 2012/07/26 ---------->>>>>
                        this.tNedit_SupplierCd_Ed.Focus();
                        // --- ADD 2012/07/26 ----------<<<<<
                    }
                    else
                    {
                        this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                        // --- ADD 2012/07/26 ---------->>>>>
                        if (checkBox_GoodsMakerCd.Checked == true)
                        {
                            this.tNedit_GoodsMakerCd_St.Focus();
                        }
                        else
                        {
                            this.tNedit_GoodsMakerCd_St.Focus();
                        }
                        // --- ADD 2012/07/26 ----------<<<<<
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(GoodsMakerCdStGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���[�J�[�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����Y</br>
        /// <br>Date        : 2011.08.08</br>
        /// </remarks>
        private void GoodsMakerCdStGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            MakerUMnt makerUMnt;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if ("GoodsMakerCdStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                        // --- ADD 2012/07/26 ---------->>>>>
                        this.tNedit_GoodsMakerCd_Ed.Focus();
                        // --- ADD 2012/07/26 ----------<<<<<
                    }
                    else
                    {
                        this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                        // --- ADD 2012/07/26 ---------->>>>>
                        if (this.tComboEditor_SetMethod.SelectedIndex == 1)
                        {
                            if (checkBox_GoodsNo.Checked == true)
                            {
                                this.tEdit_GoodsNo_St.Focus();
                            }
                            else
                            {
                                this.tEdit_GoodsNo_St.Focus();
                            }
                        }
                        else
                        {
                            if (checkBox_GoodsRateRank.Checked == true)
                            {
                                this.tNedit_GoodsRateRank_St.Focus();
                            }
                            else
                            {
                                this.tNedit_GoodsRateRank_St.Focus();
                            }
                        }
                        // --- ADD 2012/07/26 ----------<<<<<
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(BLGoodsCodeStGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : BL�R�[�h�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����Y</br>
        /// <br>Date        : 2011.08.08</br>
        /// </remarks>
        private void BLGoodsCodeStGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            BLGoodsCdUMnt blGoodsCdUMnt;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    if ("BLGoodsCodeStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_BLGoodsCode_St.SetInt(blGoodsCdUMnt.BLGoodsCode);
                        // --- ADD 2012/07/26 ---------->>>>>
                        this.tNedit_BLGoodsCode_Ed.Focus();
                        // --- ADD 2012/07/26 ----------<<<<<
                    }
                    else
                    {
                        this.tNedit_BLGoodsCode_Ed.SetInt(blGoodsCdUMnt.BLGoodsCode);
                        // --- ADD 2012/07/26 ---------->>>>>
                        this.tComboEditor_PriceKind.Focus();
                        // --- ADD 2012/07/26 ----------<<<<<
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : FSI���� �f��</br>
        /// <br>Date        : 2012.07.26</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet = new SecInfoSet();

                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    //�擾�������_�R�[�h����ʂɕ\������
                    if ("SectionStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tEdit_SectionCodeAllowZero_St.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionCodeAllowZero_Ed.Focus();
                    }
                    else
                    {
                        this.tEdit_SectionCodeAllowZero_Ed.DataText = secInfoSet.SectionCode.Trim();

                        if (this.tComboEditor_PriceKind.SelectedIndex == 2)
                        {
                            if (this.tComboEditor_SetMethod.SelectedIndex == 1)
                            {
                                if (checkBox_GoodsMakerCd.Checked == true)
                                {
                                    this.tNedit_GoodsMakerCd_St.Focus();
                                }
                                else
                                {
                                    this.tNedit_GoodsMakerCd_St.Focus();
                                }
                            }
                            else
                            {
                                if (checkBox_SupplierCd.Checked == true)
                                {
                                    this.tNedit_SupplierCd_St.Focus();
                                }
                                else
                                {
                                    this.tNedit_SupplierCd_St.Focus();
                                }
                            }
                        }
                        else
                        {
                            if (checkBox_CustRateGrpCode.Checked == true)
                            {
                                this.tNedit_CustRateGrpCode_St.Focus();
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCode_St.Focus();
                            }
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���o����͈͂��w�肷��B</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        private void CustomerCodeStGuide_Button_Click(object sender, EventArgs e)
        {
            // �������ꂽ�{�^����ޔ�
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
            // --- ADD 2012/07/26 ---------->>>>>
            if (_customerGuideSender == this.CustomerCodeStGuide_Button)
            {
                this.tNedit_CustomerCode_Ed.Focus();
            }
            else
            {
                if (this.tComboEditor_SetMethod.SelectedIndex == 1)
                {
                    if (checkBox_GoodsMakerCd.Checked == true)
                    {
                        this.tNedit_GoodsMakerCd_St.Focus();
                    }
                    else
                    {
                        this.tNedit_GoodsMakerCd_St.Focus();
                    }
                }
                else
                {
                    if (checkBox_SupplierCd.Checked == true)
                    {
                        this.tNedit_SupplierCd_St.Focus();
                    }
                    else
                    {
                        this.tNedit_SupplierCd_St.Focus();
                    }
                }
            }
            // --- ADD 2012/07/26 ----------<<<<<
        }

        /// <summary>
        /// ���Ӑ�K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">�C�x���g�p�����[�^</param>
        void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;
            if (_customerGuideSender == this.CustomerCodeStGuide_Button)
            {
                this.tNedit_CustomerCode_St.SetInt(customerSearchRet.CustomerCode);
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
            }
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v�K�C�h
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note		: ���Ӑ�|���O���[�v�K�C�h</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        private void CustRateGrpCodeStGuide_Button_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            int GuideNo = 43;

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, GuideNo);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_CustRateGrpCode_St;
                nextControl = this.tNedit_CustRateGrpCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_CustRateGrpCode_Ed;
                // --- DEL 2012/07/26 ---------->>>>>
                //nextControl = this.tNedit_CustomerCode_St;
                // --- DEL 2012/07/26 ----------<<<<<
                // --- ADD 2012/07/26 ---------->>>>>
                if (checkBox_CustomerCode.Checked == true)
                {
                    nextControl = this.tNedit_CustomerCode_St;
                }
                else
                {
                    nextControl = this.tNedit_CustomerCode_St;
                }
                // --- ADD 2012/07/26 ----------<<<<<
            }
            else
            {
                return;
            }

            targetControl.DataText = userGdBd.GuideCode.ToString("0000");

            // �t�H�[�J�X�ړ�
            nextControl.Focus();
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
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
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

        /// <summary>
        /// �P�����ValueChanged�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note		: �P�����ValueChanged�C�x���g</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        private void tComboEditor_PriceKind_ValueChanged(object sender, EventArgs e)
        {
            if(this.Mode != 2){
                switch (this.tComboEditor_PriceKind.SelectedIndex)
                {
                    //0�F�S��
                    case 0:
                    //1�F�����ݒ�
                    case 1:
                    //3�F���i�ݒ�
                    case 3:
                        {
                            // ���Ӑ�|���O���[�v                        
                            this.checkBox_CustRateGrpCode.Enabled = true;                           
                            this.tNedit_CustRateGrpCode_St.Enabled = true;
                            this.tNedit_CustRateGrpCode_Ed.Enabled = true;
                            this.CustRateGrpCodeStGuide_Button.Enabled = true;
                            this.CustRateGrpCodeEdGuide_Button.Enabled = true;
                            if (this.checkBox_CustRateGrpCode.Checked == true)
                            {
                                this.tNedit_CustRateGrpCode_Ed.Enabled = false;
                                this.CustRateGrpCodeEdGuide_Button.Enabled = false;
                            }

                            // ���Ӑ�R�[�h                        
                            this.checkBox_CustomerCode.Enabled = true;
                            this.tNedit_CustomerCode_St.Enabled = true;
                            this.tNedit_CustomerCode_Ed.Enabled = true;
                            this.CustomerCodeStGuide_Button.Enabled = true;
                            this.CustomerCodeEdGuide_Button.Enabled = true;
                            if (this.checkBox_CustomerCode.Checked == true)
                            {
                                this.tNedit_CustomerCode_Ed.Enabled = false;
                                this.CustomerCodeEdGuide_Button.Enabled = false;
                            }

                        }
                        break;
                    //2�F�����ݒ�
                    case 2:
                        {
                            // ���Ӑ�|���O���[�v                        
                            this.checkBox_CustRateGrpCode.Enabled = false;
                            this.checkBox_CustRateGrpCode.Checked = false;
                            this.tNedit_CustRateGrpCode_St.Clear();
                            this.tNedit_CustRateGrpCode_Ed.Clear();
                            this.tNedit_CustRateGrpCode_St.Enabled = false;
                            this.tNedit_CustRateGrpCode_Ed.Enabled = false;
                            this.CustRateGrpCodeStGuide_Button.Enabled = false;
                            this.CustRateGrpCodeEdGuide_Button.Enabled = false;

                            // ���Ӑ�R�[�h                        
                            this.checkBox_CustomerCode.Enabled = false;
                            this.checkBox_CustomerCode.Checked = false;
                            this.tNedit_CustomerCode_St.Clear();
                            this.tNedit_CustomerCode_Ed.Clear();
                            this.tNedit_CustomerCode_St.Enabled = false;
                            this.tNedit_CustomerCode_Ed.Enabled = false;
                            this.CustomerCodeStGuide_Button.Enabled = false;
                            this.CustomerCodeEdGuide_Button.Enabled = false;
                        }
                        break;
                }
            }
            
        }

        /// <summary>
        /// �ݒ���@ValueChanged�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note		: �ݒ���@ValueChanged�C�x���g</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// <br>Update      : 2011/09/15 �����Y</br>
        /// <br>            : Redmine �d�l�A�� #24537</br>
        /// </remarks>
        private void tComboEditor_SetMethod_ValueChanged(object sender, EventArgs e)
        {
            if (this.Mode != 2)
            {
                switch (this.tComboEditor_SetMethod.SelectedIndex)
                {
                    //1�F�O���[�v�ݒ�
                    case 0:
                        {
                            // �i��
                            this.checkBox_GoodsNo.Checked = false;
                            this.checkBox_GoodsNo.Enabled = false;
                            this.tEdit_GoodsNo_St.Clear();
                            this.tEdit_GoodsNo_Ed.Clear();
                            this.tEdit_GoodsNo_St.Enabled = false;
                            this.tEdit_GoodsNo_Ed.Enabled = false;

                            // �d����R�[�h
                            this.checkBox_SupplierCd.Checked = false;
                            this.checkBox_SupplierCd.Enabled = true;
                            this.tNedit_SupplierCd_St.Enabled = true;
                            this.tNedit_SupplierCd_Ed.Enabled = true;
                            this.SupplierStGuide_Button.Enabled = true;
                            this.SupplierEdGuide_Button.Enabled = true;

                            // �w��
                            this.checkBox_GoodsRateRank.Checked = false;
                            this.checkBox_GoodsRateRank.Enabled = true;
                            this.tNedit_GoodsRateRank_St.Enabled = true;
                            this.tNedit_GoodsRateRank_Ed.Enabled = true;

                            // ���i�|���f
                            this.checkBox_GoodsRateGrpCode.Checked = false;
                            this.checkBox_GoodsRateGrpCode.Enabled = true;
                            this.tNedit_GoodsRateGrpCode_St.Enabled = true;
                            this.tNedit_GoodsRateGrpCode_Ed.Enabled = true;
                            //  ADD dingjx  2011/09/15  ------------------>>>>>>
                            this.ub_St_MediumGoodsGanreCodeGuide.Enabled = true;
                            this.ub_Ed_MediumGoodsGanreCodeGuide.Enabled = true;
                            //  ADD dingjx  2011/09/15  ------------------<<<<<<

                            // BL�R�[�h
                            this.checkBox_BLGoodsCode.Checked = false;
                            this.checkBox_BLGoodsCode.Enabled = true;
                            this.tNedit_BLGoodsCode_St.Enabled = true;
                            this.tNedit_BLGoodsCode_Ed.Enabled = true;
                            this.BLGoodsCodeStGuide_Button.Enabled = true;
                            this.BLGoodsCodeEdGuide_Button.Enabled = true;
                        }
                        break;
                    //2�F�P�i�ݒ�
                    case 1:
                        {
                            // �i��
                            this.checkBox_GoodsNo.Checked = false;
                            this.checkBox_GoodsNo.Enabled = true;
                            this.tEdit_GoodsNo_St.Clear();
                            this.tEdit_GoodsNo_Ed.Clear();
                            this.tEdit_GoodsNo_St.Enabled = true;
                            this.tEdit_GoodsNo_Ed.Enabled = true;

                            // �d����R�[�h
                            this.checkBox_SupplierCd.Checked = false;
                            this.checkBox_SupplierCd.Enabled = false;
                            this.tNedit_SupplierCd_St.Clear();
                            this.tNedit_SupplierCd_Ed.Clear();
                            this.tNedit_SupplierCd_St.Enabled = false;
                            this.tNedit_SupplierCd_Ed.Enabled = false;
                            this.SupplierStGuide_Button.Enabled = false;
                            this.SupplierEdGuide_Button.Enabled = false;

                            // �w��
                            this.checkBox_GoodsRateRank.Checked = false;
                            this.checkBox_GoodsRateRank.Enabled = false;
                            this.tNedit_GoodsRateRank_St.Clear();
                            this.tNedit_GoodsRateRank_Ed.Clear();
                            this.tNedit_GoodsRateRank_St.Enabled = false;
                            this.tNedit_GoodsRateRank_Ed.Enabled = false;

                            // ���i�|���f
                            this.checkBox_GoodsRateGrpCode.Checked = false;
                            this.checkBox_GoodsRateGrpCode.Enabled = false;
                            this.tNedit_GoodsRateGrpCode_St.Clear();
                            this.tNedit_GoodsRateGrpCode_Ed.Clear();
                            this.tNedit_GoodsRateGrpCode_St.Enabled = false;
                            this.tNedit_GoodsRateGrpCode_Ed.Enabled = false;
                            //  ADD dingjx  2011/09/15  ------------------>>>>>>
                            this.ub_St_MediumGoodsGanreCodeGuide.Enabled = false;
                            this.ub_Ed_MediumGoodsGanreCodeGuide.Enabled = false;
                            //  ADD dingjx  2011/09/15  ------------------<<<<<<

                            // BL�R�[�h
                            this.checkBox_BLGoodsCode.Checked = false;
                            this.checkBox_BLGoodsCode.Enabled = false;
                            this.tNedit_BLGoodsCode_St.Clear();
                            this.tNedit_BLGoodsCode_Ed.Clear();
                            this.tNedit_BLGoodsCode_St.Enabled = false;
                            this.tNedit_BLGoodsCode_Ed.Enabled = false;
                            this.BLGoodsCodeStGuide_Button.Enabled = false;
                            this.BLGoodsCodeEdGuide_Button.Enabled = false;
                        }
                        break;
                }
            }
            
        }

        /// <summary>
        /// CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note		: CheckedChanged�C�x���g</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        private void checkBox_CustRateGrpCode_CheckedChanged(object sender, EventArgs e)
        {
            // ���Ӑ�|���O���[�v
            if (this.checkBox_CustRateGrpCode.Checked)
            {
                this.tNedit_CustRateGrpCode_Ed.Enabled = false;
                this.CustRateGrpCodeEdGuide_Button.Enabled = false;
                this.tNedit_CustRateGrpCode_Ed.Text = "";
            }
            else
            {
                this.tNedit_CustRateGrpCode_Ed.Enabled = true;
                this.CustRateGrpCodeEdGuide_Button.Enabled = true;
            }
        }
        /// <summary>
        /// CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note		: CheckedChanged�C�x���g</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        private void checkBox_CustomerCode_CheckedChanged(object sender, EventArgs e)
        {
            // ���Ӑ�R�[�h
            if (this.checkBox_CustomerCode.Checked)
            {
                this.tNedit_CustomerCode_Ed.Enabled = false;
                this.CustomerCodeEdGuide_Button.Enabled = false;
                this.tNedit_CustomerCode_Ed.Text = "";
            }
            else
            {
                this.tNedit_CustomerCode_Ed.Enabled = true;
                this.CustomerCodeEdGuide_Button.Enabled = true;
            }
        }
        /// <summary>
        /// CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note		: CheckedChanged�C�x���g</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        private void checkBox_SupplierCd_CheckedChanged(object sender, EventArgs e)
        {
            // �d����R�[�h
            if (this.checkBox_SupplierCd.Checked)
            {
                this.tNedit_SupplierCd_Ed.Enabled = false;
                this.SupplierEdGuide_Button.Enabled = false;
                this.tNedit_SupplierCd_Ed.Text = "";
            }
            else
            {
                this.tNedit_SupplierCd_Ed.Enabled = true;
                this.SupplierEdGuide_Button.Enabled = true;
            }
        }
        /// <summary>
        /// CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note		: CheckedChanged�C�x���g</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        private void checkBox_GoodsMakerCd_CheckedChanged(object sender, EventArgs e)
        {
            // ���[�J�[
            if (this.checkBox_GoodsMakerCd.Checked)
            {
                this.tNedit_GoodsMakerCd_Ed.Enabled = false;
                this.GoodsMakerCdEdGuide_Button.Enabled = false;
                this.tNedit_GoodsMakerCd_Ed.Text = "";
            }
            else
            {
                this.tNedit_GoodsMakerCd_Ed.Enabled = true;
                this.GoodsMakerCdEdGuide_Button.Enabled = true;
            }
        }
        /// <summary>
        /// CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note		: CheckedChanged�C�x���g</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        private void checkBox_GoodsRateRank_CheckedChanged(object sender, EventArgs e)
        {
            // �w��
            if (this.checkBox_GoodsRateRank.Checked)
            {
                this.tNedit_GoodsRateRank_Ed.Enabled = false;
                this.tNedit_GoodsRateRank_Ed.Text = "";
            }
            else
            {
                this.tNedit_GoodsRateRank_Ed.Enabled = true;
            }
        }
        /// <summary>
        /// CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note		: CheckedChanged�C�x���g</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// <br>Update      : 2011/09/15 �����Y</br>
        /// <br>            : Redmine �d�l�A�� #24537</br>
        /// </remarks>
        private void checkBox_GoodsRateGrpCode_CheckedChanged(object sender, EventArgs e)
        {
            // ���i�|���f
            if (this.checkBox_GoodsRateGrpCode.Checked)
            {
                this.tNedit_GoodsRateGrpCode_Ed.Enabled = false;
                this.ub_Ed_MediumGoodsGanreCodeGuide.Enabled = false;   //  ADD dingjx  2011/09/15
                this.tNedit_GoodsRateGrpCode_Ed.Text = "";
            }
            else
            {
                this.tNedit_GoodsRateGrpCode_Ed.Enabled = true;
                this.ub_Ed_MediumGoodsGanreCodeGuide.Enabled = true;   //  ADD dingjx  2011/09/15
            }
        }
        /// <summary>
        /// CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note		: CheckedChanged�C�x���g</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// </remarks>
        private void checkBox_BLGoodsCode_CheckedChanged(object sender, EventArgs e)
        {
            // BL�R�[�h
            if (this.checkBox_BLGoodsCode.Checked)
            {
                this.tNedit_BLGoodsCode_Ed.Enabled = false;
                this.BLGoodsCodeEdGuide_Button.Enabled = false;
                this.tNedit_BLGoodsCode_Ed.Text = "";
            }
            else
            {
                this.tNedit_BLGoodsCode_Ed.Enabled = true;
                this.BLGoodsCodeEdGuide_Button.Enabled = true;
            }
        }

        /// <summary>
        /// CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note		: CheckedChanged�C�x���g</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.08.08</br>
        /// <br>Update      : 2012.07.26 FSI���� �f��</br>
        /// <br>            : �i�Ԃ����܂������Ή�</br>
        /// </remarks>
        private void checkBox_GoodsNo_CheckedChanged(object sender, EventArgs e)
        {
            // �i��
            if (this.checkBox_GoodsNo.Checked)
            {
                this.tEdit_GoodsNo_Ed.Enabled = false;
                this.tEdit_GoodsNo_Ed.Text = "";
                // --- ADD 2012/07/26 ---------->>>>>
                this.ultraLabel6.Text = LABEL_GDDOSNO_SINGLE;
                // --- ADD 2012/07/26 ----------<<<<<
            }
            else
            {
                this.tEdit_GoodsNo_Ed.Enabled = true;
                // --- ADD 2012/07/26 ---------->>>>>
                this.ultraLabel6.Text = LABEL_GDDOSNO;
                // --- ADD 2012/07/26 ----------<<<<<
            }

        }

        // --- ADD 2012/07/26 ---------->>>>>
        /// <summary>
        /// CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note		: CheckedChanged�C�x���g</br>
        /// <br>Programmer	: FSI���� �f��</br>
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void checkBox_SectionCode_CheckedChanged(object sender, EventArgs e)
        {
            // ���_
            if (this.checkBox_SectionCode.Checked)
            {
                this.tEdit_SectionCodeAllowZero_Ed.Enabled = false;
                this.tEdit_SectionCodeAllowZero_Ed.Text = string.Empty;
                this.SectionEdGuide_Button.Enabled = false;
            }
            else
            {
                this.tEdit_SectionCodeAllowZero_Ed.Enabled = true;
                this.SectionEdGuide_Button.Enabled = true;
            }

        }
        // --- ADD 2012/07/26 ----------<<<<<

        #endregion �� Event ��

		# region �� ExplorerBar�̏k���E�W�J���� ��
		/// <summary>
		/// �O���[�v�W�J
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// ��ɃL�����Z��
			e.Cancel = true;
		}
		/// <summary>
		/// �O���[�v�k��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// ��ɃL�����Z��
			e.Cancel = true;
		}
		# endregion ��  ��

		// ADD 2011.09.07 -------- >>>>>
		/// <summary>
		/// ���i�|����ٰ�߃K�C�h�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ub_St_MediumGoodsGanreCodeGuide_Click(object sender, EventArgs e)
		{
			if (this._goodsGroupUAcs == null)
			{
				this._goodsGroupUAcs = new GoodsGroupUAcs();
			}

			GoodsGroupU goodsGroupU;

			int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU, false);  // �K�C�h�f�[�^�T�[�`���[�h(1:�����[�g)

			if (status != 0) return;

			TNedit targetControl;
			Control nextControl;
			if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
			{
				targetControl = this.tNedit_GoodsRateGrpCode_St;
				nextControl = this.tNedit_GoodsRateGrpCode_Ed;
			}
			else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
			{
				targetControl = this.tNedit_GoodsRateGrpCode_Ed;
				// --- DEL 2012/07/26 ---------->>>>>
				//nextControl = this.tNedit_BLGoodsCode_St;
				// --- DEL 2012/07/26 ----------<<<<<
                // --- ADD 2012/07/26 ---------->>>>>
                if (checkBox_BLGoodsCode.Checked == true)
                {
                    nextControl = this.tNedit_BLGoodsCode_St;
                }
                else
                {
                    nextControl = this.tNedit_BLGoodsCode_St;
                }
                // --- ADD 2012/07/26 ----------<<<<<
            }
			else
			{
				return;
			}
			targetControl.SetInt(goodsGroupU.GoodsMGroup);

			// �t�H�[�J�X�ړ�
			nextControl.Focus();
		}
		// ADD 2011.09.07 -------- <<<<<

	}
}