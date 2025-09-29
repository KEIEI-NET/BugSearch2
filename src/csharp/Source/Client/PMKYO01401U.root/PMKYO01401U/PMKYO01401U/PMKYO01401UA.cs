//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�}�X�^���o�������
// �v���O�����T�v   : ���i�}�X�^���o�����̐ݒ�E�Q�Ə������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����Y
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
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�}�X�^���o������ʃt�H�[���N���X
    /// </summary>
    /// <remarks>
    /// Note       : ���i�}�X�^���o�����̐ݒ�E�Q�Ə����ł��B<br />
    /// Programmer : �����Y<br />
    /// Date       : 2011.07.27<br />
    /// </remarks>
    public partial class PMKYO01401UA : Form
    {

        #region �� Const Memebers ��

        private const string PROGRAM_ID = "PMKYO01401UA";
        
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


        private string _loginName;
        private string _enterpriseCode;
        private string _loginEmplooyCode;
        private string _loginSectionCode;

        # endregion �� Private field ��

        #region �� Public Memebers ��
        /// <summary>
        /// 1:�V�K���[�h 2:�Q�ƃ��[�h
        /// </summary>
        public int Mode; 
        /// <summary>
        /// APGoodsProcParamWork
        /// </summary>
        public APGoodsProcParamWork _goodsProcParam;

        #endregion �� Public Memebers ��

        #region  �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈���ł��B</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011.07.27</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SupplierStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SupplierEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsMakerCdStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsMakerCdEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGoodsCodeStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGoodsCodeEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;
        }
        # endregion �� �{�^�������ݒ菈�� ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKYO01401UA()
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

                this.tNedit_SupplierCd_St.Enabled = false;
                this.tNedit_SupplierCd_Ed.Enabled = false;
                this.SupplierStGuide_Button.Enabled = false;
                this.SupplierEdGuide_Button.Enabled = false;
                this.tNedit_GoodsMakerCd_St.Enabled = false;
                this.tNedit_GoodsMakerCd_Ed.Enabled = false;
                this.GoodsMakerCdStGuide_Button.Enabled = false;
                this.GoodsMakerCdEdGuide_Button.Enabled = false;
                this.tNedit_BLGoodsCode_St.Enabled = false;
                this.tNedit_BLGoodsCode_Ed.Enabled = false;
                this.BLGoodsCodeStGuide_Button.Enabled = false;
                this.BLGoodsCodeEdGuide_Button.Enabled = false;
                this.tEdit_GoodsNo_St.Enabled = false;
                this.tEdit_GoodsNo_Ed.Enabled = false;
            }
            //�V�K���[�h
            else
            {
                this._saveButton.SharedProps.Visible = true;
                this._clearButton.SharedProps.Visible = true;
                this.tNedit_SupplierCd_St.Enabled = true;
                this.tNedit_SupplierCd_Ed.Enabled = true;
                this.SupplierStGuide_Button.Enabled = true;
                this.SupplierEdGuide_Button.Enabled = true;
                this.tNedit_GoodsMakerCd_St.Enabled = true;
                this.tNedit_GoodsMakerCd_Ed.Enabled = true;
                this.GoodsMakerCdStGuide_Button.Enabled = true;
                this.GoodsMakerCdEdGuide_Button.Enabled = true;
                this.tNedit_BLGoodsCode_St.Enabled = true;
                this.tNedit_BLGoodsCode_Ed.Enabled = true;
                this.BLGoodsCodeStGuide_Button.Enabled = true;
                this.BLGoodsCodeEdGuide_Button.Enabled = true;
                this.tEdit_GoodsNo_St.Enabled = true;
                this.tEdit_GoodsNo_Ed.Enabled = true;
            }

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
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            if (this._goodsProcParam != null)
            {
                // �d����
                this.tNedit_SupplierCd_St.SetInt(Convert.ToInt32(_goodsProcParam.SupplierCdBeginRF));
                this.tNedit_SupplierCd_Ed.SetInt(Convert.ToInt32(_goodsProcParam.SupplierCdEndRF));


                // ���[�J�[
                this.tNedit_GoodsMakerCd_St.SetInt(Convert.ToInt32(_goodsProcParam.GoodsMakerCdBeginRF));
                this.tNedit_GoodsMakerCd_Ed.SetInt(Convert.ToInt32(_goodsProcParam.GoodsMakerCdEndRF));

                // BL�R�[�h
                this.tNedit_BLGoodsCode_St.SetInt(Convert.ToInt32(_goodsProcParam.BLGoodsCodeBeginRF));
                this.tNedit_BLGoodsCode_Ed.SetInt(Convert.ToInt32(_goodsProcParam.BLGoodsCodeEndRF));

                // �i��
                this.tEdit_GoodsNo_St.Text = Convert.ToString(_goodsProcParam.GoodsNoBeginRF);
                this.tEdit_GoodsNo_Ed.Text = Convert.ToString(_goodsProcParam.GoodsNoEndRF);
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
        /// <br>Programmer	: �����Y</br>	
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void Save()
        {
            string errMessage = "";
            // ��ʃf�[�^�`�F�b�N����
            if (!this.ScreenInputCheck(ref errMessage))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                //�t�H�[�J�X���d����J�n�ֈړ�
                switch (errMessage)
                {
                    case "�d����͈̔͂��s���ł��B":
                        {
                            if (this.tNedit_SupplierCd_St.Enabled)
                            {
                                this.tNedit_SupplierCd_St.Focus();
                            }
                        }
                        break;
                    case "���[�J�[�͈̔͂��s���ł��B":
                        {
                            if (this.tNedit_GoodsMakerCd_St.Enabled)
                            {
                                this.tNedit_GoodsMakerCd_St.Focus();
                            }
                        }
                        break;
                    case "BL�R�[�h�͈̔͂��s���ł��B":
                        {
                            if (this.tNedit_BLGoodsCode_St.Enabled)
                            {
                                this.tNedit_BLGoodsCode_St.Focus();
                            }
                        }
                        break;
                    case "�i�Ԃ͈̔͂��s���ł��B":
                        {
                            if (this.tEdit_GoodsNo_St.Enabled)
                            {
                                this.tEdit_GoodsNo_St.Focus();
                            }
                        }
                        break;
                }
                
                return;
            }
            if (_goodsProcParam == null)
            {
                _goodsProcParam = new APGoodsProcParamWork();
            }
            else
            {
                // �d����
                _goodsProcParam.SupplierCdBeginRF = this.tNedit_SupplierCd_St.GetInt();
                _goodsProcParam.SupplierCdEndRF = this.tNedit_SupplierCd_Ed.GetInt();

                // ���[�J�[
                _goodsProcParam.GoodsMakerCdBeginRF = this.tNedit_GoodsMakerCd_St.GetInt();
                _goodsProcParam.GoodsMakerCdEndRF = this.tNedit_GoodsMakerCd_Ed.GetInt();

                // BL�R�[�h
                _goodsProcParam.BLGoodsCodeBeginRF = this.tNedit_BLGoodsCode_St.GetInt();
                _goodsProcParam.BLGoodsCodeEndRF = this.tNedit_BLGoodsCode_Ed.GetInt();

                // �i��
                _goodsProcParam.GoodsNoBeginRF = this.tEdit_GoodsNo_St.Text;
                _goodsProcParam.GoodsNoEndRF = this.tEdit_GoodsNo_Ed.Text;
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
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void Clear()
        {
            // �d����
            this.tNedit_SupplierCd_St.SetInt(0);
            this.tNedit_SupplierCd_Ed.SetInt(0);
            // ���[�J�[
            this.tNedit_GoodsMakerCd_St.SetInt(0);
            this.tNedit_GoodsMakerCd_Ed.SetInt(0);
            // BL�R�[�h
            this.tNedit_BLGoodsCode_St.SetInt(0);
            this.tNedit_BLGoodsCode_Ed.SetInt(0);
            // �i��
            this.tEdit_GoodsNo_St.Text = String.Empty;
            this.tEdit_GoodsNo_Ed.Text = String.Empty;
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
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // �d����
                case "tNedit_SupplierCd_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SupplierCd_St.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_SupplierCd_Ed;
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
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_GoodsMakerCd_St;
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
                                if (this.tNedit_SupplierCd_St.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
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
                                if (this.tNedit_SupplierCd_Ed.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_BLGoodsCode_St;
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

                // BL�R�[�h
                case "tNedit_BLGoodsCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SupplierCd_St.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
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
                                if (this.tNedit_SupplierCd_Ed.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tEdit_GoodsNo_St;
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

                // �i��
                case "tEdit_GoodsNo_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                e.NextCtrl = this.tEdit_GoodsNo_Ed;
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
                                e.NextCtrl = this.tNedit_SupplierCd_St;
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
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: �����Y</br>
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage)
        {
            bool status = true;
            const string ct_RangeError = "�͈̔͂��s���ł��B";

            // �d����
            if (this.tNedit_SupplierCd_Ed.GetInt() > 0 && this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt())
            {
                errMessage = "�d����" + ct_RangeError;
                status = false;
                return status;
            }
            // ���[�J�[
            if (this.tNedit_GoodsMakerCd_Ed.GetInt() > 0 && this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = "���[�J�[" + ct_RangeError;
                status = false;
                return status;
            }
            // BL�R�[�h
            if (this.tNedit_BLGoodsCode_Ed.GetInt() > 0 && this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                errMessage = "BL�R�[�h" + ct_RangeError;
                status = false;
                return status;
            }
            // �i��
            if (String.Compare(this.tEdit_GoodsNo_Ed.Text, "0") > 0 && String.Compare(this.tEdit_GoodsNo_St.Text, this.tEdit_GoodsNo_Ed.Text) > 0)
            {
                errMessage = "�i��" + ct_RangeError;
                status = false;
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
        /// <br>Date        : 2011.07.27</br>
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
                    }
                    else
                    {
                        this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
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
        /// <br>Date        : 2011.07.27</br>
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
                    }
                    else
                    {
                        this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
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
        /// <br>Date        : 2011.07.27</br>
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
                    }
                    else
                    {
                        this.tNedit_BLGoodsCode_Ed.SetInt(blGoodsCdUMnt.BLGoodsCode);
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
        /// <br>Programmer	: �����Y</br>
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
		private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// ��ɃL�����Z��
			e.Cancel = true;
		}
		/// <summary>
		/// �O���[�v�k��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// ��ɃL�����Z��
			e.Cancel = true;
		}
		# endregion ��  ��
    }
}