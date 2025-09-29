//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^���o�������
// �v���O�����T�v   : �݌Ƀ}�X�^���o�����̐ݒ�E�Q�Ə������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X
// �� �� ��  2011.07.30   �C�����e : �V�K�쐬
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
    /// �݌Ƀ}�X�^���o������ʃt�H�[���N���X
    /// </summary>
    /// <remarks>
    /// Note       : �݌Ƀ}�X�^���o�����̐ݒ�E�Q�Ə����ł��B<br />
    /// Programmer : ���X<br />
    /// Date       : 2011.07.30 <br />
    /// </remarks>
    public partial class PMKYO01701UA : Form
    {

        #region �� Const Memebers ��

        private const string PROGRAM_ID = "PMKYO01701UA";
        
        #endregion �� Const Memebers ��

        # region �� Private field ��

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        private SupplierAcs _supplierAcs;       // �d����p
        private MakerAcs _makerAcs;             // ���[�J�[�p
        private WarehouseAcs _warehouseAcs;     // �q�ɗp
        private BLGroupUAcs _blGroupUAcs;       // �O���[�v�R�[�h�p
        
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
        /// APStockProcParamWork
        /// </summary>
        public APStockProcParamWork _stockProcParam;

        #endregion �� Public Memebers ��

        #region  �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈���ł��B</br>
        /// <br>Programmer : ���X</br>
        /// <br>Date       : 2011.07.30 </br>
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
        public PMKYO01701UA()
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
            this._warehouseAcs = new WarehouseAcs();
            this._blGroupUAcs = new BLGroupUAcs();

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
        /// <br>Programmer	: ���X</br>	
        /// <br>Date		: 2011.07.30 </br>
        /// </remarks>
        private void PMKYO01701UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.ButtonInitialSetting();

            //�Q�ƃ��[�h
            if (this.Mode == 2)
            {
                this._saveButton.SharedProps.Visible = false;
                this._clearButton.SharedProps.Visible = false;
                //�q��
                this.tNedit_Store_St.Enabled = false;
                this.tNedit_Store_Ed.Enabled = false;
                this.StoreStGuide_Button.Enabled = false;
                this.StoreEdGuide_Button.Enabled = false;
                //�I��
                this.tEdit_ShelfNo_St.Enabled = false;
                this.tEdit_ShelfNo_Ed.Enabled = false;
                //�d����
                this.tNedit_SupplierCd_St.Enabled = false;
                this.tNedit_SupplierCd_Ed.Enabled = false;
                this.SupplierStGuide_Button.Enabled = false;
                this.SupplierEdGuide_Button.Enabled = false;
                //���[�J�[
                this.tNedit_Manuf_St.Enabled = false;
                this.tNedit_Manuf_Ed.Enabled = false;
                this.ManufStGuide_Button.Enabled = false;
                this.ManufEdGuide_Button.Enabled = false;
                //�O���[�v�R�[�h
                this.tNedit_GroupCd_St.Enabled = false;
                this.tNedit_GroupCd_Ed.Enabled = false;
                this.GroupCdStGuide_Button.Enabled = false;
                this.GroupCdEdGuide_Button.Enabled = false;
                //�i��
                this.tEdit_GoodsNo_St .Enabled = false;
                this.tEdit_GoodsNo_Ed.Enabled = false;
            }
            //�V�K���[�h
            else
            {
                this._saveButton.SharedProps.Visible = true;
                this._clearButton.SharedProps.Visible = true;
                //�q��
                this.tNedit_Store_St.Enabled = true;
                this.tNedit_Store_Ed.Enabled = true;
                this.StoreStGuide_Button.Enabled = true;
                this.StoreEdGuide_Button.Enabled = true;
                //�I��
                this.tEdit_ShelfNo_St.Enabled = true;
                this.tEdit_ShelfNo_Ed.Enabled = true;
                //�d����
                this.tNedit_SupplierCd_St.Enabled = true;
                this.tNedit_SupplierCd_Ed.Enabled = true;
                this.SupplierStGuide_Button.Enabled = true;
                this.SupplierEdGuide_Button.Enabled = true;
                //���[�J�[
                this.tNedit_Manuf_St.Enabled = true;
                this.tNedit_Manuf_Ed.Enabled = true;
                this.ManufStGuide_Button.Enabled = true;
                this.ManufEdGuide_Button.Enabled = true;
                //�O���[�v�R�[�h
                this.tNedit_GroupCd_St.Enabled = true;
                this.tNedit_GroupCd_Ed.Enabled = true;
                this.GroupCdStGuide_Button.Enabled = true;
                this.GroupCdEdGuide_Button.Enabled = true;
                //�i��
                this.tEdit_GoodsNo_St .Enabled = true;
                this.tEdit_GoodsNo_Ed.Enabled = true;
            }
            
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.StoreStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.StoreEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SupplierStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SupplierEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.ManufStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.ManufEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GroupCdStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GroupCdEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

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
        /// <br>Programmer	: ���X</br>
        /// <br>Date		: 2011.07.30 </br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            if (this._stockProcParam != null)
            {
                // �q��
                if (_stockProcParam.WarehouseCodeBeginRF != null && !_stockProcParam.WarehouseCodeBeginRF.Equals(""))
                this.tNedit_Store_St.SetInt(Convert.ToInt32(_stockProcParam.WarehouseCodeBeginRF));
            if (_stockProcParam.WarehouseCodeEndRF != null && !_stockProcParam.WarehouseCodeEndRF.Equals(""))
                this.tNedit_Store_Ed.SetInt(Convert.ToInt32(_stockProcParam.WarehouseCodeEndRF));
                // �I��
                this.tEdit_ShelfNo_St.Text = _stockProcParam.WarehouseShelfNoBeginRF;
                this.tEdit_ShelfNo_Ed.Text = _stockProcParam.WarehouseShelfNoEndRF;
                // �d����
                this.tNedit_SupplierCd_St.SetInt(_stockProcParam.SupplierCdBeginRF);
                this.tNedit_SupplierCd_Ed.SetInt(_stockProcParam.SupplierCdEndRF);
                // ���[�J�[
                this.tNedit_Manuf_St.SetInt(_stockProcParam.GoodsMakerCdBeginRF);
                this.tNedit_Manuf_Ed.SetInt(_stockProcParam.GoodsMakerCdEndRF);
                // �O���[�v�R�[�h
                this.tNedit_GroupCd_St.SetInt(_stockProcParam.BLGloupCodeBeginRF);
                this.tNedit_GroupCd_Ed.SetInt(_stockProcParam.BLGloupCodeEndRF);
                // �i��
                this.tEdit_GoodsNo_St.Text = _stockProcParam.GoodsNoBeginRF;
                this.tEdit_GoodsNo_Ed.Text = _stockProcParam.GoodsNoEndRF;
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
        /// <br>Programmer	: ���X</br>	
        /// <br>Date		: 2011.07.30 </br>
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
        /// <br>Programmer	: ���X</br>	
        /// <br>Date		: 2011.07.30 </br>
        /// </remarks>
        private void Save()
        {
            string errMessage = "";
            // ��ʃf�[�^�`�F�b�N����
            if (!this.ScreenInputCheck(ref errMessage))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                //�t�H�[�J�X��q�ɊJ�n�ֈړ�
                switch (errMessage)
                {
                    case "�q�ɂ͈̔͂��s���ł��B":
                        {
                            if (this.tNedit_Store_St.Enabled)
                            {
                                this.tNedit_Store_St.Focus();
                            }
                        }
                        break;
                    case "�I�Ԃ͈̔͂��s���ł��B":
                        {
                            if (this.tEdit_ShelfNo_St.Enabled)
                            {
                                this.tEdit_ShelfNo_St.Focus();
                            }
                        }
                        break;
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
                            if (this.tNedit_Manuf_St.Enabled)
                            {
                                this.tNedit_Manuf_St.Focus();
                            }
                        }
                        break;
                    case "�O���[�v�R�[�h�͈̔͂��s���ł��B":
                        {
                            if (this.tNedit_GroupCd_St.Enabled)
                            {
                                this.tNedit_GroupCd_St.Focus();
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
            if (_stockProcParam == null)
            {
                _stockProcParam = new APStockProcParamWork();
            }
            else
            {
                // �q��
                _stockProcParam.WarehouseCodeBeginRF = this.tNedit_Store_St.Text.Trim();
                _stockProcParam.WarehouseCodeEndRF = this.tNedit_Store_Ed.Text.Trim();
                // �I��
                _stockProcParam.WarehouseShelfNoBeginRF = this.tEdit_ShelfNo_St.Text;
                _stockProcParam.WarehouseShelfNoEndRF = this.tEdit_ShelfNo_Ed.Text;
                // �d����
                _stockProcParam.SupplierCdBeginRF = this.tNedit_SupplierCd_St.GetInt();
                _stockProcParam.SupplierCdEndRF = this.tNedit_SupplierCd_Ed.GetInt();
                // ���[�J�[
                _stockProcParam.GoodsMakerCdBeginRF = this.tNedit_Manuf_St.GetInt();
                _stockProcParam.GoodsMakerCdEndRF = this.tNedit_Manuf_Ed.GetInt();
                // �O���[�v�R�[�h
                _stockProcParam.BLGloupCodeBeginRF = this.tNedit_GroupCd_St.GetInt();
                _stockProcParam.BLGloupCodeEndRF = this.tNedit_GroupCd_Ed.GetInt();
                // �i��
                _stockProcParam.GoodsNoBeginRF = this.tEdit_GoodsNo_St.Text;
                _stockProcParam.GoodsNoEndRF = this.tEdit_GoodsNo_Ed.Text;
            }

            //�ۑ������������ʂ����
            this.Close();
        }

        /// <summary>
        /// �N���A����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �N���A�����ł��B</br>
        /// <br>Programmer	: ���X</br>	
        /// <br>Date		: 2011.07.30 </br>
        /// </remarks>
        private void Clear()
        {
            //�q��
            this.tNedit_Store_St.SetInt(0);
            this.tNedit_Store_Ed.SetInt(0);
            //�I��
            this.tEdit_ShelfNo_St.Text = "";
            this.tEdit_ShelfNo_Ed.Text = "";
            //�d����
            this.tNedit_SupplierCd_St.SetInt(0);
            this.tNedit_SupplierCd_Ed.SetInt(0);
            //���[�J�[
            this.tNedit_Manuf_St.SetInt(0);
            this.tNedit_Manuf_Ed.SetInt(0);
            //�O���[�v�R�[�h
            this.tNedit_GroupCd_St.SetInt(0);
            this.tNedit_GroupCd_Ed.SetInt(0);
            //�i��
            this.tEdit_GoodsNo_St.Text = "";
            this.tEdit_GoodsNo_Ed.Text = "";
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
        /// <br>Programmer	: ���X</br>
        /// <br>Date		: 2011.07.30 </br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_Store_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_Store_St.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_Store_Ed;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.StoreStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_Store_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_Store_Ed.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tEdit_ShelfNo_St;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.StoreEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tEdit_ShelfNo_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                e.NextCtrl = this.tEdit_ShelfNo_Ed;
                            }
                        }
                        break;
                    }
                case "tEdit_ShelfNo_Ed":
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
                                    e.NextCtrl = this.tNedit_Manuf_St;
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
                case "tNedit_Manuf_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_Manuf_St.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_Manuf_Ed;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.ManufStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_Manuf_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_Manuf_Ed.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_GroupCd_St;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.ManufEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_GroupCd_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_GroupCd_St.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_GroupCd_Ed;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.GroupCdStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_GroupCd_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_GroupCd_Ed.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tEdit_GoodsNo_St ;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.GroupCdEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tEdit_GoodsCd_St ":
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
                case "tEdit_GoodsCd_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                e.NextCtrl = this.tNedit_Store_St;
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
        /// <br>Programmer	: ���X</br>
        /// <br>Date		: 2011.07.30 </br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage)
        {
            bool status = true;
            const string ct_RangeError = "�͈̔͂��s���ł��B";
            // �q��
            if (this.tNedit_Store_Ed.GetInt() > 0 && this.tNedit_Store_St.GetInt() > this.tNedit_Store_Ed.GetInt())
            {
                errMessage = "�q��" + ct_RangeError;
                status = false;
                return status;
            }
            // �I��
            if (!this.tEdit_ShelfNo_Ed.Text.Equals("") && this.tEdit_ShelfNo_St.Text.CompareTo(this.tEdit_ShelfNo_Ed.Text) > 0)
            {
                errMessage = "�I��" + ct_RangeError;
                status = false;
                return status;
            }
            // �d����
            if (this.tNedit_SupplierCd_Ed.GetInt() > 0 && this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt())
            {
                errMessage = "�d����" + ct_RangeError;
                status = false;
                return status;
            }
            // ���[�J�[
            if (this.tNedit_Manuf_Ed.GetInt() > 0 && this.tNedit_Manuf_St.GetInt() > this.tNedit_Manuf_Ed.GetInt())
            {
                errMessage = "���[�J�[" + ct_RangeError;
                status = false;
                return status;
            }
            // �O���[�v�R�[�h
            if (this.tNedit_GroupCd_Ed.GetInt() > 0 && this.tNedit_GroupCd_St.GetInt() > this.tNedit_GroupCd_Ed.GetInt())
            {
                errMessage = "�O���[�v�R�[�h" + ct_RangeError;
                status = false;
                return status;
            }
            // �i��
            if (!this.tEdit_GoodsNo_Ed.Text.Equals("") && this.tEdit_GoodsNo_St.Text.CompareTo(this.tEdit_GoodsNo_Ed.Text)>0)
            {
                errMessage = "�i��" + ct_RangeError;
                status = false;
                return status;
            }

            return status;
        }

        /// <summary>
        /// Control.Click �C�x���g(StoreGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �q�ɃK�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���X</br>
        /// <br>Date        : 2011.07.30 </br>
        /// </remarks>
        private void StoreGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            Warehouse warehouse;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode, this._loginSectionCode);
                if (status == 0)
                {
                    if ("StoreStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_Store_St.Text = warehouse.WarehouseCode;
                    }
                    else
                    {
                        this.tNedit_Store_Ed.Text = warehouse.WarehouseCode;
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
        /// <br>Note�@�@�@ : �d����K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���X</br>
        /// <br>Date        : 2011.07.30 </br>
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
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���[�J�[�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���X</br>
        /// <br>Date        : 2011.07.30 </br>
        /// </remarks>
        private void ManufGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            MakerUMnt maker;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out maker);
                if (status == 0)
                {
                    if ("ManufStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_Manuf_St.SetInt(maker.GoodsMakerCd);
                    }
                    else
                    {
                        this.tNedit_Manuf_Ed.SetInt(maker.GoodsMakerCd);
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
        /// <br>Note�@�@�@ : �O���[�v�R�[�h�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���X</br>
        /// <br>Date        : 2011.07.30 </br>
        /// </remarks>
        private void GroupCdGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            BLGroupU bLGroupU;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out bLGroupU);
                if (status == 0)
                {
                    if ("GroupCdStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_GroupCd_St.SetInt(bLGroupU.BLGroupCode);
                    }
                    else
                    {
                        this.tNedit_GroupCd_Ed.SetInt(bLGroupU.BLGroupCode);
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
        /// <br>Programmer	: ���X</br>
        /// <br>Date		: 2011.07.30 </br>
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